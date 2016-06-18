using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using WinFormsSandbox.Properties;

namespace WinFormsSandbox.Forms
{
    /// <summary>
    /// Represents a dialog for constructing an instance of a <see cref="Type"/>.
    /// </summary>
    public partial class CreateInstanceDialog : DialogBox
    {
        private ConstructorInfo constructorInfo;

        /// <summary>
        /// Sets the constructor to build a parameter object from and invoke.
        /// </summary>
        /// <returns>Errors that occurred when compiling the dummy object.</returns>
        public CompilerErrorCollection SetConstructor(ConstructorInfo construtor)
        {
            if (construtor == null)
                throw new ArgumentNullException(nameof(construtor));

            CompilerErrorCollection errors;
            var obj = DynamicUtilities.GetParametersObject(construtor.GetParameters(), out errors);

            if (errors.HasErrors)
            {
                return errors;
            }

            constructorInfo = construtor;
            propertyViewCtorInfo.SelectedObject = obj;
            return errors;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateInstanceDialog"/>.
        /// </summary>
        public CreateInstanceDialog()
        {
            InitializeComponent();
            Icon = System.Drawing.Icon.FromHandle(Resources.Instantiate.GetHicon());
        }

        /// <summary>
        /// Gets the parameters set in the <see cref="PropertyGrid"/>.
        /// </summary>
        public object[] GetParameters()
        {
            return DynamicUtilities.ExtractMethodArguments(constructorInfo, propertyViewCtorInfo.SelectedObject);
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
