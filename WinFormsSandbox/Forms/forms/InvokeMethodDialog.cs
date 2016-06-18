using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace WinFormsSandbox.Forms
{
    /// <summary>
    /// Represents a dialog for invoking methods with specific arguments.
    /// </summary>
    public partial class InvokeMethodDialog : DialogBox
    {
        /// <summary>
        /// Wraps a value type so it can be displayed as a single property in a <see cref="PropertyGrid"/>.
        /// </summary>
        private class ValueTypeWrapper
        {
            /// <summary>
            /// Gets the value of the value type.
            /// </summary>
            public object StringValue { get; private set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="ValueTypeWrapper"/> class with the
            /// specified argument.
            /// </summary>
            /// <param name="stringValue">The value of the value type.</param>
            public ValueTypeWrapper(object stringValue)
            {
                if (stringValue is TypedReference)
                    throw new ArgumentException(
                        "Cannot be reference type. ValueTypeWrapper should not be used for reference types.");

                StringValue = stringValue;
            }
        }

        private MethodInfo methodInfo;

        /// <summary>
        /// Gets or sets the object to invoke on.
        /// </summary>
        public object Object { get; set; }

        /// <summary>
        /// Sets up the specified method so it can be invoked.
        /// </summary>
        /// <returns>Compilation errors that occurred when trying to build a dummy object
        /// for the specified method's parameters.</returns>
        public CompilerErrorCollection SetupMethod(MethodInfo method)
        {
            methodInfo = method;
            int paramsCount = methodInfo.GetParameters().Length;

            if (methodInfo.ReturnType == typeof(void))
            {
                HideOutputPanel();
            }

            if (paramsCount == 0)
            {
                HideInputPanel();
                buttonInvoke.Visible = false;
                buttonInvoke_Click(buttonInvoke, EventArgs.Empty);
                return new CompilerErrorCollection();
            }

            CompilerErrorCollection errors;
            var obj = DynamicUtilities.GetParametersObject(methodInfo.GetParameters(), out errors);
            propertyGridMethodInfo.SelectedObject = obj;
            return errors;
        }

        /// <summary>
        /// Hide the input panel (for when no arguments can be specified but data can be returned).
        /// </summary>
        private void HideInputPanel()
        {
            tableLayoutPanel.Controls.Remove(panelInput);
            tableLayoutPanel.SetColumn(panelOutput, 1);
            tableLayoutPanel.SetColumnSpan(panelOutput, 2);
        }

        /// <summary>
        /// Hide the output panel (for when no data can be returned but arguments can be specified).
        /// </summary>
        private void HideOutputPanel()
        {
            tableLayoutPanel.Controls.Remove(panelOutput);
            tableLayoutPanel.SetColumn(panelInput, 1);
            tableLayoutPanel.SetColumnSpan(panelInput, 2);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvokeMethodDialog"/> class.
        /// </summary>
        public InvokeMethodDialog()
        {
            InitializeComponent();
        }

        private void buttonInvoke_Click(object sender, EventArgs e)
        {
            try
            {
                object[] parameters = methodInfo.GetParameters().Length == 0 ? null :
                    DynamicUtilities.ExtractMethodArguments(methodInfo, propertyGridMethodInfo.SelectedObject);
                object result = methodInfo.Invoke(Object, parameters);

                if (result != null)
                {
                    Type resultType = result.GetType();

                    if (resultType.IsPrimitive || resultType == typeof(string))
                    {

                        labelStringResult.Text = "Null returned.";
                        labelStringResult.Visible = true;
                    }
                    else
                    {
                        labelStringResult.Visible = false;
                    }

                    var props = resultType.GetProperties(BindingFlags.Instance | BindingFlags.Public);

                    if (props.Length > 0)
                    {
                       // if (props.Length > 1)
                        //    propertyGridResult.PropertySort = PropertySort.CategorizedAlphabetical;

                        propertyGridResult.SelectedObject = result;
                    }
                    else
                    {
                       // propertyGridResult.PropertySort = PropertySort.NoSort;
                        propertyGridResult.SelectedObject = new ValueTypeWrapper(result);
                    }
                }
                else
                {
                    labelStringResult.Text = "Null returned.";
                    labelStringResult.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ex.ShowErrorDialog();
                Close();
            }
        }
    }
}
