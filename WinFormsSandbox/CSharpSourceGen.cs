using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFormsSandbox
{
    /// <summary>
    /// Provides functionality for generating C# source code based on reflected data.
    /// </summary>
    static class CSharpSourceGen
    {
        /// <summary>
        /// The regex used to replace Type names with their corresponding aliases.
        /// </summary>
        private static readonly Regex aliasRegex;
        #region
        private static readonly Dictionary<string, string> typeAliases = new Dictionary<string, string>
        {
            { "Boolean", "bool" },
            { "Byte", "byte" },
            { "SByte", "sbyte" },
            { "Char", "char" },
            { "Decimal", "decimal" },
            { "Double", "double" },
            { "Single", "float" },
            { "Int32", "int" },
            { "UInt32", "uint" },
            { "Int64", "long" },
            { "UInt64", "ulong" },
            { "Object", "object" },
            { "Int16", "Short" },
            { "String", "string" },
            { "UInt16", "ushort" },
            { "Void", "void" },
        };
        #endregion

        static CSharpSourceGen()
        {
            StringBuilder SB = new StringBuilder(@"\b(?<Type>");

            foreach (var alias in typeAliases)
                SB.Append(alias.Key).Append("|");

            string pattern = SB.ToString().TrimEnd('|') + @")\b";
            aliasRegex = new Regex(pattern, RegexOptions.Compiled);
        }

        /// <summary>
        /// Gets the modifiers string for the specified Type. The modifiers "static",
        /// "abstract", and "sealed" always come before the modifiers "public", "private",
        /// and "internal".
        /// </summary>
        /// <param name="type">The Type to reflect on.</param>
        /// <returns>A string representation of the Type's modifiers. Example: "public static".</returns>
        public static string GetModifiers(Type type)
        {
            StringBuilder SB = new StringBuilder();

            if (type.IsNestedPublic || type.IsPublic)
                SB.Append("public");
            else if (type.IsNestedPrivate)
                SB.Append("private");
            else
                SB.Append("internal");

            SB.Append(" ");

            if (type.IsStatic())
                SB.Append("static ");
            else if (type.IsAbstract)
                SB.Append("abstract ");
            else if (type.IsSealed && !type.IsValueType)
                SB.Append("sealed ");

            return SB.ToString();
        }

        /// <summary>
        /// Gets the modifiers string for the specified <see cref="MethodBase"/>. The modifiers "static",
        /// "abstract", and "virtual" always come before the modifiers "public", "private",
        /// and "internal".
        /// </summary>
        /// <param name="info">The method to reflect on.</param>
        /// <returns>A string representation of the Type's modifiers. Example: "public static".</returns>
        public static string GetModifiers(MethodBase info)
        {
            StringBuilder SB = new StringBuilder();

            if (info.IsPublic)
                SB.Append("public");
            else if (info.IsFamilyOrAssembly)
                SB.Append("protected internal");
            else if (info.IsFamily)
                SB.Append("protected");
            else if (info.IsAssembly)
                SB.Append("internal");
            else if (info.IsPrivate)
                SB.Append("private");

            if (info.IsStatic)
                SB.Append(" static");
            else if (info.IsAbstract)
                SB.Append(" abstract");
            else if (info.IsVirtual)
                SB.Append(" virtual");

            return SB.ToString();
        }

        /// <summary>
        /// Gets the signature of the specified <see cref="Type"/>.
        /// (Generic argument and parameters included).
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to reflect on.</param>
        /// <param name="fullyQualified">Determines whether the Type names are fully qualified.
        /// This only affects the resulting name of the derived Type.</param>
        /// <returns>A signature, such as "internal static class CSharpSourceGen".</returns>
        public static string GetTypeSignature(Type type, bool fullyQualified)
        {
            StringBuilder SB = new StringBuilder();
            SB.Append(GetModifiers(type));

            if (type.IsClass)
                SB.Append("class ");
            else if (type.IsInterface)
                SB.Append("interface ");
            else if (type.IsValueType)
                SB.Append("struct ");
            else if (type.IsEnum)
                SB.Append("enum ");

            SB.Append(GetTypeName(type, false));

            if (type.BaseType != null && type.BaseType != typeof(object)
                && type.BaseType != typeof(ValueType))
            {
                SB.Append(" : ");
                SB.Append(GetTypeName(type.BaseType, fullyQualified));
            }

            return SB.ToString();
        }

        /// <summary>
        /// Gets the C# representation of the specified generic parameters.
        /// Example: &lt;T1, T2, T3&gt;
        /// </summary>
        /// <param name="genericParams">The generic parameters to convert to a string.</param>
        /// <param name="fullyQualified">Determines whether the Type names are fully qualified.</param>
        public static string GetGenericsSet(Type[] genericParams, bool fullyQualified)
        {
            StringBuilder SB = new StringBuilder();

            if (genericParams.Length > 0)
            {
                SB.Append('<');

                for (int i = 0; i < genericParams.Length; i++)
                {
                    SB.Append(GetTypeName(genericParams[i], fullyQualified));

                    if (i < genericParams.Length - 1)
                        SB.Append(", ");
                }

                SB.Append('>');
            }

            return SB.ToString();
        }

        /// <summary>
        /// Gets the name of the Type (non-fully qualified).
        /// </summary>
        /// <param name="type">The Type to get the name of.</param>
        /// <param name="fullyQualified">Determines whether the Type names are fully qualified.</param>
        /// <param name="includeGenericsSet">Whether to include generic information.</param>
        public static string GetTypeName(Type type, bool fullyQualified, bool includeGenericsSet = true)
        {
            string name = (fullyQualified && type.FullName != null) ? type.FullName : type.Name;

            if (fullyQualified)
                name = name.Replace('+', '.');

            // Remove generic parameter count indicator.
            int index = name.IndexOf('`');

            if (index != -1)
                name = name.Remove(index, name.Length - index);

            Type[] genericsSet = null;

            if (includeGenericsSet)
            {
                if (type.ContainsGenericParameters)
                    genericsSet = type.GetGenericArguments();

                if (type.GenericTypeArguments.Length > 0)
                    genericsSet = type.GenericTypeArguments;

                if (genericsSet != null)
                    name += GetGenericsSet(genericsSet, fullyQualified);
            }

            if (!fullyQualified)
            {
                name = aliasRegex.Replace(name, ReplaceMatchEvaluator);
            }

            return name;
        }

        public static string GetPropertySignature(PropertyInfo property, bool fullyQualified)
        {
            StringBuilder SB = new StringBuilder();
            string highestMod = "private";
            string getMod = string.Empty;
            string setMod = string.Empty;

            if (property.CanRead)
            {
                getMod = highestMod = GetModifiers(property.GetMethod);
            }

            if (property.CanWrite)
            {
                setMod = GetModifiers(property.SetMethod);

                switch (setMod)
                {
                    case "protected":
                        if (highestMod == "private")
                            highestMod = setMod;
                        break;

                    case "protected internal":
                        if (highestMod.EqualsAny(new[] { "protected", "private" }))
                            highestMod = setMod;
                        break;

                    case "internal":
                        if (highestMod.EqualsAny(new[] { "protected", "private", "protected internal" }))
                            highestMod = setMod;
                        break;

                    case "public":
                        if (highestMod.EqualsAny(new[] { "protected", "private", "protected internal", "internal" }))
                            highestMod = setMod;
                        break;

                }
            }

            SB.Append(highestMod + " ");
            SB.Append($@"{GetTypeName(property.PropertyType, fullyQualified)} {property.Name} {{ ");

            if (property.CanRead)
            {
                getMod = getMod == highestMod ? string.Empty : getMod + " ";
                SB.Append(getMod + "get; ");
            }

            if (property.CanWrite)
            {
                setMod = setMod == highestMod ? string.Empty : setMod + " ";
                SB.Append(setMod + "set; ");
            }

            SB.Append("}");

            return SB.ToString();
        }

        /// <summary>
        /// Gets the signature of an event.
        /// Example: "public event MouseEventArgs MouseMove".
        /// </summary>
        /// <param name="info">The event info to reflect on.</param>
        public static string GetEventSignature(EventInfo info)
        {
            return $@"{GetModifiers(info.AddMethod)} event {GetTypeName(info.EventHandlerType, true)} {info.Name}";
        }

        /// <summary>
        /// Gets the signature of the specified method.
        /// </summary>
        /// <param name="info">The method info to reflect on.</param>
        /// <param name="fullyQualified">Whether to use fully qualified Type names.</param>
        /// <param name="includeModifiers">Whether to include modifiers in the resulting signature.</param>
        /// <returns>A signature such as: "public static string GetMethodSignature(info, bool)".</returns>
        public static string GetMethodSignature(MethodInfo info, bool fullyQualified, bool includeModifiers = true)
        {
            StringBuilder SB = new StringBuilder();
            string methodName = info.Name;
            string[] split = methodName.Split('.');

            if (split.Length > 1)
            {
                methodName = split[split.Length - 1];
            }

            string returnTypeString = GetTypeName(info.ReturnType, fullyQualified);

            if (includeModifiers)
            {
                SB.Append(GetModifiers(info) + " ");
            }

            SB.Append($@"{returnTypeString} {methodName}");

            if (info.ContainsGenericParameters)
            {
                if (SB.Length > 2)
                    SB = SB.Remove(SB.Length - 2, 2);

                SB.Append(GetGenericsSet(info.GetGenericArguments(), fullyQualified));
            }

            SB.Append('(');
            var parameters = info.GetParameters();

            for (int i = 0; i < parameters.Length; i++)
            {
                string paramTypeName = GetTypeName(parameters[i].ParameterType, fullyQualified);

                SB.Append($@"{paramTypeName} {parameters[i].Name}");

                if (i < parameters.Length - 1)
                    SB.Append(", ");
            }

            SB.Append(')');
            string result = SB.ToString();

            if (!fullyQualified)
            {
                result = UseAliases(result);
            }

            return result;
        }

        /// <summary>
        /// Gets the signature of the specified constructor.
        /// </summary>
        /// <param name="info">The constructor info to reflect on.</param>
        /// <param name="fullyQualified">Whether to use fully qualified Type names.</param>
        /// <returns>A signature such as: "public MainForm(string[])".</returns>
        public static string GetConstructorSignature(ConstructorInfo info, bool fullyQualified)
        {
            StringBuilder SB = new StringBuilder();
            string name = GetTypeName(info.DeclaringType, false, false);
            SB.Append($@"{GetModifiers(info)} {name}");
            SB.Append('(');
            var parameters = info.GetParameters();

            for (int i = 0; i < parameters.Length; i++)
            {
                string paramName = GetTypeName(parameters[i].ParameterType, fullyQualified);

                if (!fullyQualified)
                {
                    paramName = UseAliases(paramName);
                }

                SB.Append($@"{paramName} {parameters[i].Name}");

                if (i < parameters.Length - 1)
                    SB.Append(", ");
            }

            return SB.Append(")").ToString();
        }

        /// <summary>
        /// Adjusts the specified code so that the code uses the aliases built into
        /// C# (instead of the Type name).
        /// </summary>
        /// <param name="code">The code to process. The code should not have fully qualified
        /// type names, otherwise undesirable code might result such as "System.bool".</param>
        /// <returns>The adjusted code, using aliases.</returns>
        public static string UseAliases(string code)
        {
            return aliasRegex.Replace(code, ReplaceMatchEvaluator);
        }

        /// <summary>
        /// Provides a replacement match evaluator for the Type names that can be aliased.
        /// </summary>
        /// <param name="match">The match found.</param>
        /// <returns>The replacement string.</returns>
        private static string ReplaceMatchEvaluator(Match match)
        {
            string replacement;
            string groupVal = match.Groups["Type"].Value;
            typeAliases.TryGetValue(groupVal, out replacement);
            return replacement ?? groupVal;
        }
    }
}
