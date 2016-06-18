using System;
using System.Windows.Forms;

namespace WinFormsSandbox.Forms
{
    /// <summary>
    /// Represents a Form that can only be shown as a dialog (in blocking mode).
    /// </summary>
    public partial class DialogBox : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DialogBox"/> class.
        /// </summary>
        protected DialogBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        [Obsolete("Cannot show a modal dialog in non-blocking mode.", true)]
        public new void Show(){}
    }
}
