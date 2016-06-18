using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace WinFormsSandbox
{
    /// <summary>
    /// Provides reflection and CodeDom based functionality specific to this application.
    /// </summary>
    public static class DynamicUtilities
    {
        /// <summary>
        /// Executes the specified method body source code within a execution wrapper.
        /// </summary>
        /// <returns>The results of the custom code execution operation.</returns>
        /// <param name="methodDefinition">The definition (or body) of the method to execute.</param>
        /// <param name="argument">The argument to pass into the method.</param>
        public static CustomCodeExecutionResults ExecuteMethodBody(string methodDefinition, object argument)
        {
            const string EXECUTE_METHOD_NAME = "Executer";
            const string EXECUTE_TYPE_NAME = "Program";
            const int LINE_OFFSET = 12;

            #region wrapper Code
            string fullCode =
    $@"using System;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;

public class {EXECUTE_TYPE_NAME}
{{
    [STAThread]
    static void Main() {{ }}

    public void {EXECUTE_METHOD_NAME}({CSharpSourceGen.GetTypeName(argument.GetType(), true)} obj)
    {{
{methodDefinition.Indent()}
    }}
}}";
            #endregion

            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CompilerParameters parameters = BuildCompilerParameters();
            CompilerResults results = provider.CompileAssemblyFromSource(parameters, fullCode);
            provider.Dispose();

            if (results.Errors.HasErrors)
            {
                return new CustomCodeExecutionResults(results.Errors, LINE_OFFSET);
            }

            Assembly outputAssembly = results.CompiledAssembly;
            Type outputType = outputAssembly.GetType(EXECUTE_TYPE_NAME);
            object outputObject = Activator.CreateInstance(outputType);
            MethodInfo executeMethod = outputType.GetMethod(EXECUTE_METHOD_NAME);
            executeMethod.Invoke(outputObject, new[] { argument });
            return new CustomCodeExecutionResults(results.Errors, LINE_OFFSET);
        }

        /// <summary>
        /// Gets a <see cref="UITypeEditor"/> that is designed to provide an editor for
        /// the specified Type.
        /// </summary>
        /// <param name="type">The Type to indicate what Type of UITypeEditor to look for.</param>
        /// <returns>Null, if no editor found.</returns>
        private static Type GetLocalUITypeEditor(Type type)
        {
            var assemTypes = Assembly.GetExecutingAssembly().GetTypes();
            var editors = assemTypes.Where(t => t.IsSubclassOf(typeof(UITypeEditor)));

            foreach (Type editor in editors)
            {
                var attrib = editor.GetCustomAttribute<TargetTypeAttribute>();

                if (attrib != null && attrib.Type == type)
                    return editor;
            }

            return null;
        }

        /// <summary>
        /// Gets a <see cref="TypeConverter"/> that is designed to provide extended conversion 
        /// functionality for the specified Type.
        /// </summary>
        /// <param name="type">The Type to indicate what Type of TypeConverter to look for.</param>
        /// <returns>Null, if no editor found.</returns>
        private static Type GetLocalTypeConverter(Type type)
        {
            if (type == typeof(object))
            {
                return typeof(StringConverter);
            }
            else
            {
                var assemTypes = Assembly.GetExecutingAssembly().GetTypes();
                var converters = assemTypes.Where(t => t.IsSubclassOf(typeof(TypeConverter)));

                foreach (Type converter in converters)
                {
                    var attrib = converter.GetCustomAttribute<TargetTypeAttribute>();

                    if (attrib != null && attrib.Type == type)
                        return converter;
                }
            }

            return null;
        }

        /// <summary>
        /// Builds dummy object code that represents the parameters of a method call as properties.
        /// </summary>
        /// <remarks>This is used to display method parameters into a <see cref="PropertyGrid"/></remarks>
        /// <param name="parameters">The parameters to get properties from.</param>
        /// <param name="dummyTypeName">The name of the dummy type.</param>
        /// <returns>The dummy-type source-code.</returns>
        public static string BuildParametersObjectCode(ParameterInfo[] parameters, string dummyTypeName)
        {
            StringBuilder SB = new StringBuilder();

            for (int i = 0; i < parameters.Length; i++)
            {
                ParameterInfo parameterInfo = parameters[i];
                Guid guid = Guid.NewGuid();
                string privateParam = parameterInfo.Name + guid.ToString("N");
                string paramTypeName = CSharpSourceGen.GetTypeName(parameterInfo.ParameterType, true);

                SB.Indent().AppendLine($@"private {paramTypeName} {privateParam};");

                var paramType = parameters[i].ParameterType;

                // Look for custom TypeConverter.
                var converter = GetLocalTypeConverter(paramType);
                if (converter != null)
                {
                    string converterName = CSharpSourceGen.GetTypeName(converter, true);
                    SB.Indent().AppendLine($@"[TypeConverter(typeof({converterName}))]");
                }

                // Look for UI type editor.
                var editor = GetLocalUITypeEditor(paramType);
                if (editor != null)
                {
                    string editorName = CSharpSourceGen.GetTypeName(editor, true);
                    SB.Indent().AppendLine($@"[Editor(typeof({editorName}))]");
                }

                SB.Indent().AppendLine($@"[System.ComponentModel.Category(""{i}"")]");
                SB.Indent().AppendLine($@"public {paramTypeName} @{parameterInfo.Name}");
                SB.Indent().AppendLine("{");
                SB.Indent().Indent().AppendLine($@"get {{ return {privateParam}; }}");
                SB.Indent().Indent().AppendLine($@"set {{ {privateParam} = value; }}");
                SB.Indent().AppendLine("}");
            }

            string autoProperties = SB.ToString();

            return
$@"using System;
using System.Windows.Forms;
using System.Reflection;
using System.ComponentModel;

public class {dummyTypeName}
{{
    {autoProperties}

    [STAThread]
    static void Main(){{}}
}}";
        }

        /// <summary>
        /// Build parameters for a compiler environment. The parameters describe that an
        /// executable should be generated in memory.
        /// </summary>
        private static CompilerParameters BuildCompilerParameters()
        {
            CompilerParameters compParameters = new CompilerParameters();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (Assembly appAssembly in assemblies)
            {
#if DEBUG
                try
                {
                    compParameters.ReferencedAssemblies.Add(appAssembly.Location);
                }
                catch (NotSupportedException) { }
#else
                try
                {
                    compParameters.ReferencedAssemblies.Add(appAssembly.Location);
                }
                catch (NotSupportedException) { }
#endif
            }

            compParameters.GenerateExecutable = true;
            compParameters.GenerateInMemory = true;
            compParameters.WarningLevel = 3;
            return compParameters;
        }

        /// <summary>
        /// Gets the object representation of the specified parameters.
        /// </summary>
        /// <remarks>The parameters are built into a dummy type so they can be presented in a property grid.</remarks>
        /// <param name="parameters">The parameters to build into an object.</param>
        /// <param name="errors">The compile-time errors that may arise.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static object GetParametersObject(ParameterInfo[] parameters, out CompilerErrorCollection errors)
        {
            var provider = CodeDomProvider.CreateProvider("CSharp");
            const string OBJECT_NAME = "DummyParametersObject";
            string code = BuildParametersObjectCode(parameters, OBJECT_NAME);

            if (String.IsNullOrEmpty(code))
                throw new ArgumentNullException(nameof(parameters), "No code to execute.");

            CompilerParameters compParameters = BuildCompilerParameters();
            CompilerResults results = provider.CompileAssemblyFromSource(compParameters, code);
            provider.Dispose();

            if (results.Errors.HasErrors)
            {
                errors = results.Errors;
                return null;
            }
            else
            {
                errors = new CompilerErrorCollection();
                Assembly outputAssembly = results.CompiledAssembly;
                Type outputType = outputAssembly.GetType(OBJECT_NAME);
                return Activator.CreateInstance(outputType);
            }
        }

        /// <summary>
        /// Gets the arguments from the specified instance.
        /// </summary>
        /// <exception cref="Exception">Cannot find value for property.</exception>
        public static object[] ExtractMethodArguments(MethodBase method, object dummyObject)
        {
            ParameterInfo[] parameters = method.GetParameters();
            PropertyInfo[] dummyParameters = dummyObject.GetType().GetProperties();
            object[] returnParameters = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                PropertyInfo matchingProperty = dummyParameters.FirstOrDefault(t => t.Name == parameters[i].Name);

                if (matchingProperty == null)
                    throw new Exception($@"Cannot find value for property ""{parameters[i].Name}"".");

                returnParameters[i] = matchingProperty.GetValue(dummyObject, null);
            }

            return returnParameters;
        }
    }
}
