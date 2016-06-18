using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace WinFormsSandbox.Forms
{
    /// <summary>
    /// Represents a view to quick hide and show groupings of controls.
    /// </summary>
    public partial class CustomCodeQuickView : QuickView
    {
        /// <summary>
        /// Gets or sets whether the execute function of this quick view is enabled.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ExecuteEnabled
        {
            get { return buttonExecute.Enabled; }
            set { buttonExecute.Enabled = value; }
        }

        /// <summary>
        /// Gets or sets the custom code to compile.
        /// </summary>
        [Description("The custom code to compile.")]
        public string CustomCode
        {
            get { return textBoxCode.Text; }
            set { textBoxCode.Text = value; }
        }

        /// <summary>
        /// Occurs when the invoke <see cref="Button"/> is clicked.
        /// </summary>
        [Description("Occurs when the invoke Button is clicked.")]
        public event EventHandler InvokeButtonClick
        {
            add { buttonExecute.Click += value; }
            remove { buttonExecute.Click -= value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomCodeQuickView"/> class.
        /// </summary>
        public CustomCodeQuickView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Highlights the specified lines in the code box (offset around 1).
        /// </summary>
        /// <param name="lineNumbers">The line number to select.</param>
        public void HighlightLines(int[] lineNumbers)
        {
            textBoxCode.SetErrorLines(lineNumbers);
        }
    }
}
