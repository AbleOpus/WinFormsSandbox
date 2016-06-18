using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsSandbox
{
    /// <summary>
    /// Provides functionality for retrieving extended information about reflectable structures.
    /// </summary>
    static class InfoGathering
    {
        /// <summary>
        /// Creates a query for MSDN lookups, based on the property specified.
        /// </summary>
        public static string GetMsdnPropertyQuery(PropertyInfo property)
        {
            return $@"{CSharpSourceGen.GetTypeName(property.DeclaringType, true)}.{property.Name}";
        }

        /// <summary>
        /// Creates a query for MSDN lookups, based on the method specified.
        /// </summary>
        public static string GetMsdnMethodQuery(MethodInfo method)
        {
            return CSharpSourceGen.GetTypeName(method.DeclaringType, true) + "." + method.Name;
        }

        /// <summary>
        /// Creates a query for MSDN lookups, based on the constructor specified.
        /// </summary>
        public static string GetMsdnConstructorQuery(ConstructorInfo constructor)
        {
            return CSharpSourceGen.GetTypeName(constructor.DeclaringType, true) + ".%23ctor";
        }

        /// <summary>
        /// Looks up the specified query on the MSDN website.
        /// </summary>
        /// <param name="query">The query used to build the URL-based request.</param>
        public static void LookupOnMsdn(string query)
        {
            try
            {
                const string FORMAT =
                    "http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k({0});k" +
                    "(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.5.2);k(DevLang-csharp)&rd=true";

                Process.Start(String.Format(FORMAT, query));
            }
            catch (Exception ex)
            {
                ex.ShowErrorDialog();
            }
        }

        /// <summary>
        /// Gets extended information about the specified constructor asynchronously.
        /// </summary>
        public static Task<string> DescribeConstructorTaskAsync(ConstructorInfo info)
        {
            return Task.Run(() =>
            {
                var SB = new StringBuilder();
                SB.AppendLine(CSharpSourceGen.GetConstructorSignature(info, true));
                SB.AppendLine();

                if (info.CustomAttributes.Any())
                {
                    SB.AppendLine("Attributes:");

                    foreach (var attrib in info.CustomAttributes)
                    {
                        SB.AppendLine(attrib.ToString());
                    }

                    SB.AppendLine();
                }

                SB.AppendLine($@"Method Impl Flags: {info.MethodImplementationFlags}");
                return SB.ToString();
            });
        }

        /// <summary>
        /// Gets extended information about the specified method asynchronously.
        /// </summary>
        public static Task<string> DescribeMethodTaskAsync(MethodInfo info)
        {
            return Task.Run(() =>
            {
                var SB = new StringBuilder();
                SB.AppendLine(CSharpSourceGen.GetMethodSignature(info, true));
                SB.AppendLine();

                if (info.CustomAttributes.Any())
                {
                    SB.AppendLine("Attributes:");

                    foreach (var attrib in info.CustomAttributes)
                    {
                        SB.AppendLine(attrib.ToString());
                    }

                    SB.AppendLine();
                }

                SB.AppendLine($@"Return Type: {CSharpSourceGen.GetTypeName(info.ReturnType, true)}");
                SB.AppendLine($@"Has Generic Params: {info.ContainsGenericParameters}");
                SB.AppendLine($@"Method Impl Flags: {info.MethodImplementationFlags}");
                SB.AppendLine();

                var genArgs = info.GetGenericArguments();

                if (genArgs.Length > 0)
                {
                    SB.AppendLine("Generic Arguments:");

                    foreach (var arg in genArgs)
                    {
                        SB.AppendLine(arg.ToString());
                    }
                }

                return SB.ToString();
            });
        }

        /// <summary>
        /// Gets extended information about the specified property asynchronously.
        /// </summary>
        public static Task<string> DescribePropertyTaskAsync(PropertyInfo info)
        {
            return Task.Run(() =>
            {
                var SB = new StringBuilder();

                foreach (var attrib in info.CustomAttributes)
                {
                    SB.AppendLine(attrib.ToString());
                }

                SB.Append(CSharpSourceGen.GetPropertySignature(info, true));
                SB.AppendLine();
                SB.AppendLine();

                try
                {
                    SB.AppendLine($@"Raw Const Value: {info.GetRawConstantValue()}");
                }
                catch (InvalidOperationException) { }

                try
                {
                    SB.AppendLine($@"Const Value: {info.GetConstantValue()}");
                }
                catch (InvalidOperationException) { }

                var reqCustomMods = info.GetRequiredCustomModifiers();

                if (reqCustomMods.Length > 0)
                {
                    SB.AppendLine("Required Custom Modifiers:");

                    foreach (var customMod in reqCustomMods)
                    {
                        SB.AppendLine(customMod.FullName);
                    }

                    SB.AppendLine();
                }

                var optCustomMods = info.GetOptionalCustomModifiers();

                if (optCustomMods.Length > 0)
                {
                    SB.AppendLine("Optional Custom Modifiers:");

                    foreach (var customMod in optCustomMods)
                    {
                        SB.AppendLine(customMod.FullName);
                    }

                    SB.AppendLine();
                }

                return SB.ToString();
            });
        }

        /// <summary>
        /// Gets extended information about the specified event asynchronously.
        /// </summary>
        public static Task<string> DescribeEventTaskAsync(EventInfo info)
        {
            return Task.Run(() =>
            {
                var SB = new StringBuilder();
                SB.AppendLine(info.ToString());
                SB.AppendLine();

                if (info.CustomAttributes.Any())
                {
                    SB.AppendLine("Attributes:");

                    foreach (var attrib in info.CustomAttributes)
                    {
                        SB.AppendLine(attrib.ToString());
                    }

                    SB.AppendLine();
                }

                var otherMethods = info.GetOtherMethods(); // Handlers?
                SB.AppendLine();

                if (otherMethods.Length > 0)
                {
                    SB.AppendLine("Other Methods (Handlers?):");

                    foreach (var method in otherMethods)
                    {
                        SB.AppendLine(method.ToString());
                    }
                }

                return SB.ToString();
            });
        }

        /// <summary>
        /// Gets extended information about the specified assembly asynchronously.
        /// </summary>
        public static Task<string> DescribeAssemblyTaskAsync(Assembly assembly)
        {
            return Task.Run(() =>
            {
                var SB = new StringBuilder();
                SB.AppendLine($@"// {assembly.FullName}").AppendLine();
                SB.AppendLine($@"// File Path: {assembly.GetLocalFilePath()}");
                SB.AppendLine($@"// Directory: {assembly.GetLocalParentDirectory()}");
                SB.AppendLine($@"// From GAC: {assembly.GlobalAssemblyCache}");
                SB.AppendLine($@"// Is Fully Trusted: {assembly.IsFullyTrusted}");
                SB.AppendLine();

                foreach (var attrib in assembly.CustomAttributes)
                    SB.AppendLine(attrib.ToString());

                return SB.ToString();
            });
        }

        /// <summary>
        /// Gets extended information about the specified Type asynchronously.
        /// </summary>
        public static Task<string> DescribeTypeTaskAsync(Type type)
        {
            return Task.Run(() =>
            {
                var SB = new StringBuilder();
                if (type.CustomAttributes.Any())
                {
                    foreach (var attrib in type.CustomAttributes)
                        SB.AppendLine(attrib.ToString());
                }
                SB.AppendLine(CSharpSourceGen.GetTypeSignature(type, true));
                SB.AppendLine();
                SB.AppendLine($@"// Namespace: " + type.Namespace);
                SB.AppendLine($@"// Base Type: {CSharpSourceGen.GetTypeName(type.BaseType, true)}");
                SB.AppendLine($@"// Serializable: {type.IsSerializable}");
                SB.AppendLine($@"// Nested: {type.IsNested}");
                SB.AppendLine($@"// Constructor Count: {type.GetConstructors().Length}");
                SB.AppendLine($@"// Property Count: {type.GetProperties().Length}");
                SB.AppendLine($@"// Event Count: {type.GetEvents().Length}");
                SB.AppendLine($@"// Method Count: {type.GetMethods().Length}");
                SB.AppendLine();

                var inters = type.GetInterfaces();

                if (inters.Length > 0)
                {
                    SB.AppendLine("// Implemented Interfaces:");

                    foreach (var inter in type.GetInterfaces())
                    {
                        SB.AppendLine("// " + inter.FullName);
                    }

                    SB.AppendLine();
                }

                SB.AppendLine();

                if (type.IsGenericParameter)
                {
                    var genericConstraints = type.GetGenericParameterConstraints();

                    if (genericConstraints.Length > 0)
                        SB.AppendLine("// Generic Parameter Constraints:");

                    foreach (var constraints in genericConstraints)
                    {
                        SB.AppendLine(constraints.FullName);
                    }
                }

                return SB.ToString();
            });
        }
    }
}
