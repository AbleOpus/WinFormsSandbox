using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsSandbox.Properties;

namespace WinFormsSandbox.Forms
{
    /// <summary>
    /// Groups assembly-loading-related controls into a colapsable parent.
    /// </summary>
    public partial class LoadObjectsQuickView : QuickView
    {
        /// <summary>
        /// Gets the <see cref="ComboBox"/> used to select <see cref="Type"/>s.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ComboBox TypesComboBox => comboTypes;

        /// <summary>
        /// Gets the <see cref="ComboBox"/> used to select <see cref="Assembly"/>s.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ComboBox AssembliesComboBox => comboLoadedAssemblies;

        /// <summary>
        /// Gets the <see cref="ComboBox"/> used to select <see cref="ConstructorInfo"/>s.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ComboBox ConstructorsComboBox => comboCtor;

        /// <summary>
        /// Gets the assembly selected in the UI.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Assembly SelectedAssembly
        {
            get { return ((KeyValuePair<Assembly, string>?) comboLoadedAssemblies.SelectedItem)?.Key; }
            set
            {
                foreach (KeyValuePair<Assembly, string> item in comboLoadedAssemblies.Items)
                {
                    if (item.Key == value)
                    {
                        comboLoadedAssemblies.SelectedItem = item;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the Type selected in the UI.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Type SelectedType =>
            ((KeyValuePair<Type, string>?)comboTypes.SelectedItem)?.Key;

        /// <summary>
        /// Gets the constructor selected in the UI.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ConstructorInfo SelectedConstructor =>
            ((KeyValuePair<ConstructorInfo, string>?)comboCtor.SelectedItem)?.Key;

        /// <summary>
        /// Occurs when the user has selected an object to load and has clicked the
        /// "Load Object" <see cref="Button"/>.
        /// </summary>
        public event EventHandler<object> ObjectLoaded;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoadObjectsQuickView"/> class.
        /// </summary>
        public LoadObjectsQuickView()
        {
            InitializeComponent();
            PopulateAssembliesComboBox();
        }

        /// <summary>
        /// Raises the CreateControl event.
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (!DesignMode)
            {
                if (Settings.Default.LastAssemblyIndex < comboLoadedAssemblies.Items.Count)
                    comboLoadedAssemblies.SelectedIndex = Settings.Default.LastAssemblyIndex;

                if (Settings.Default.LastTypeIndex < comboTypes.Items.Count)
                    comboTypes.SelectedIndex = Settings.Default.LastTypeIndex;

                if (Settings.Default.LastCtorIndex != 0 && Settings.Default.LastCtorIndex < comboCtor.Items.Count)
                    comboCtor.SelectedIndex = Settings.Default.LastCtorIndex;
            }
        }

        /// <summary>
        /// Populates the constructors <see cref="ComboBox"/> with constructors of the selected
        /// <see cref="Type"/>. If no public constructors are found, non-public ones will be listed.
        /// </summary>
        private void PopulateConstructorsComboBox()
        {
            comboCtor.Items.Clear();
            Type selType = SelectedType;

            if (selType == null)
                return;

            var ctors = selType.GetConstructors();

            if (ctors.Length == 0)
                ctors = selType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (ConstructorInfo ctorInfo in ctors)
            {
                string ctorString = CSharpSourceGen.GetConstructorSignature(ctorInfo, false);
                comboCtor.Items.Add(new KeyValuePair<ConstructorInfo, string>(ctorInfo, ctorString));
            }

            if (comboCtor.Items.Count > 0)
            {
                comboCtor.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Gets the key/value pairs of iterated and filtered Types.
        /// </summary>
        /// <param name="assembly">The assembly to reflect on.</param>
        /// <returns>The key/value pairs with the Type and its string representation.</returns>
        private static Dictionary<Type, string> GetTypePairs(Assembly assembly)
        {
            var dictionary = new Dictionary<Type, string>();
            Type[] types;

            try
            {
                types = assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException ex)
            {
                ex.ShowErrorDialog();
                return new Dictionary<Type, string>();
            }

            foreach (Type type in types)
            {
                bool isCompilerGen = type.GetCustomAttribute<CompilerGeneratedAttribute>() != null;
                // Do not list enums, and abstract, static, compiler-generated classes.
                // For some reason, many compiler-generated classes are not marked with the 
                // CompilerGeneratedAttribute, but can be identified because they start with a "<".
                if (!type.IsEnum && !type.IsAbstract && !isCompilerGen && !type.FullName.StartsWith("<"))
                    dictionary.Add(type, CSharpSourceGen.GetTypeName(type, false));
            }

            return dictionary;
        }

        /// <summary>
        /// Populates the Types <see cref="ComboBox"/> with non-abstract and Component-derived Types.
        /// </summary>
        private void PopulateTypesComboBox()
        {
            comboTypes.Enabled = false;
            comboTypes.Items.Clear();
            Assembly assembly = SelectedAssembly;
            if (assembly == null) return;

            var dictionary = GetTypePairs(assembly);

            comboTypes.BeginUpdate();

            foreach (var pair in dictionary)
            {
                comboTypes.Items.Add(pair);
            }

            if (comboTypes.Items.Count > 0)
                comboTypes.SelectedIndex = 0;

            comboTypes.EndUpdate();
            comboTypes.Enabled = true;
        }

        /// <summary>
        /// Populates the assemblies <see cref="ComboBox"/> with the assemblies in the current domain.
        /// </summary>
        public void PopulateAssembliesComboBox()
        {
            comboLoadedAssemblies.BeginUpdate();
            comboLoadedAssemblies.Items.Clear();

            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                AssemblyName assemblyName = assembly.GetName();
                comboLoadedAssemblies.Items.Add(new KeyValuePair<Assembly, string>(assembly, assemblyName.Name));
            }

            if (comboLoadedAssemblies.Items.Count > 0)
                comboLoadedAssemblies.SelectedIndex = 0;

            comboLoadedAssemblies.EndUpdate();
        }

        private void comboLoadedAssemblies_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateTypesComboBox();
        }

        private void comboTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateConstructorsComboBox();
        }

        private void buttonLoadControl_Click(object sender, EventArgs e)
        {
            if (SelectedAssembly == null)
            {
                Program.ShowError("No assembly selected.");
                return;
            }

            // No type is selected by the type combo.
            // Check to see if the type is entered correctly. If it is, then
            // commit it and move on through the method.
            if (SelectedType == null)
            {
                if (comboTypes.SelectedText == string.Empty)
                {
                    Program.ShowError("No Type selected.");
                    return;
                }

                Type type = SelectedAssembly.GetType(comboTypes.SelectedText);

                if (type != null)
                {
                    comboTypes.SelectedItem = comboTypes.Items.OfType
                        <KeyValuePair<Type, string>>().First(pair => pair.Key == type);
                }
                else
                {
                    Program.ShowError("No Type selected.");
                    return;
                }
            }

            var selCtor = SelectedConstructor;

            if (selCtor == null)
            {
                Program.ShowError("No constructor selected.");
                return;
            }

            if (!selCtor.IsPublic)
            {
                Program.ShowError("Only public constructors can be invoked.");
                return;
            }

            object obj;

            if (SelectedType.ContainsGenericParameters)
            {
                Program.ShowError("Cannot create an instance of a class that has generic parameters.");
                return;
            }

            if (selCtor.GetParameters().Length == 0)
            {
                try
                {
                    obj = Activator.CreateInstance(SelectedType);
                }
                catch (COMException ex)
                {
                    ex.ShowErrorDialog();
                    return;
                }
            }
            else
            {
                using (CreateInstanceDialog dialogCreateInstance = new CreateInstanceDialog())
                {
                    var errors = dialogCreateInstance.SetConstructor(selCtor);

                    if (errors.HasErrors)
                    {
                        return;
                    }

                    if (dialogCreateInstance.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            obj = SelectedConstructor.Invoke(dialogCreateInstance.GetParameters());
                        }
                        catch (TargetInvocationException ex)
                        {
                            if (ex.InnerException == null)
                                ex.ShowErrorDialog();
                            else
                                ex.InnerException.ShowErrorDialog();
                            return;
                        }
                        catch (Exception ex)
                        {
                            ex.ShowErrorDialog();
                            return;
                        }
                    }
                    else return;
                }
            }

            ObjectLoaded?.Invoke(this, obj);
        }
    }
}