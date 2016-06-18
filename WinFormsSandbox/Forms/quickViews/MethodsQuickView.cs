using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace WinFormsSandbox.Forms
{
    /// <summary>
    /// Groups method-related controls into a colapsable parent.
    /// </summary>
    public partial class MethodsQuickView : QuickView
    {
        /// <summary>
        /// Gets or sets whether to allow invocation of any selected method.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool InvokeEnabled
        {
            get { return buttonInvokeMethod.Enabled; }
            set { buttonInvokeMethod.Enabled = value; }
        }

        /// <summary>
        /// Gets the method selected in the UI.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MethodInfo SelectedMethod =>
            ((KeyValuePair<MethodInfo, string>?)comboMethods.SelectedItem)?.Key;

        /// <summary>
        /// Occurs when the "Invoke" <see cref="Button"/> is clicked.
        /// </summary>
        [Description("Occurs when the Invoke button is clicked.")]
        public event EventHandler<MethodInfo> InvokeButtonClick;

        /// <summary>
        /// Occurs when the selected method has changed.
        /// </summary>
        [Description("Occurs when the selected method has changed.")]
        public event EventHandler SelectedMethodChanged
        {
             add { comboMethods.SelectedIndexChanged += value; }
             remove { comboMethods.SelectedIndexChanged -= value; }
        }

        /// <summary>
        /// Occurs when the methods <see cref="ComboBox"/> has received focus.
        /// </summary>
        [Description("Occurs when the methods ComboBox has received focus.")]
        public event EventHandler MethodComboFocused
        {
            add { comboMethods.GotFocus += value; }
            remove { comboMethods.GotFocus -= value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodsQuickView"/> class.
        /// </summary>
        public MethodsQuickView()
        {
            InitializeComponent();
        }

        /// <returns>
        /// True if the character was processed by the control; otherwise, false.
        /// </returns>
        /// <param name="msg">A <see cref="T:System.Windows.Forms.Message"/>, passed by reference, that represents the window message to process. </param><param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys"/> values that represents the key to process. </param>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.F:
                    textBoxFind.Focus();
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Clears the listed methods.
        /// </summary>
        public void ClearMethods()
        {
            comboMethods.Items.Clear();
        }

        /// <summary>
        /// Populates the methods <see cref="ComboBox"/> with the specified methods.
        /// Property accessors are ignored.
        /// </summary>
        /// <param name="methods">The methods to filter and add to the <see cref="ComboBox"/>.</param>
        public void Populate(MethodInfo[] methods)
        {
            comboMethods.Items.Clear();
            
            foreach (MethodInfo methodInfo in methods)
            {
                // Skip event and property accessors.
                if (methodInfo.Name.StartsWithAny("get_", "set_", "add_", "remove_"))
                    continue;

                string result = CSharpSourceGen.GetMethodSignature(methodInfo, false, false);
                comboMethods.Items.Add(new KeyValuePair<MethodInfo, string>(methodInfo, result));
            }
        }

        private void buttonInvokeMethod_Click(object sender, EventArgs e)
        {
            if (SelectedMethod == null)
            {
                Program.ShowError("Select a method to invoke.");
            }
            else
            {
                InvokeButtonClick?.Invoke(this, SelectedMethod);
            }
        }

        private void textBoxFind_TextChanged(object sender, EventArgs e)
        {
            string query = textBoxFind.Text.ToLower();
            
            foreach (var item in comboMethods.Items)
            {
                MethodInfo method = ((KeyValuePair<MethodInfo, string>)item).Key;

                if (method.Name.ToLower().Contains(query))
                {
                    comboMethods.SelectedItem = item;
                    return;
                }
            }
        }
    }
}
