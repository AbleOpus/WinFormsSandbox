using System.Windows.Forms;

namespace WinFormsSandbox.Forms
{
    /// <summary>
    /// Represents a dialog box for displaying the return value of a method.
    /// </summary>
    public partial class MethodReturnValueDialog : DialogBox
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MethodReturnValueDialog"/> class.
        /// </summary>
        public MethodReturnValueDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the return object to be displayed.
        /// </summary>
        public void SetReturnObject(object obj)
        {
            if (obj == null)
            {
                ShowStringResult("Null returned.");
                return;
            }

            var objType = obj.GetType();

            if (objType == typeof(string) || objType.IsPrimitive)
            {
                ShowStringResult(obj.ToString());
                return;
            }

            splitContainer.Panel2Collapsed = true;
            propertyGridResult.SelectedObject = obj;
        }

        private void ShowStringResult(string text)
        {
            splitContainer.Panel1Collapsed = true;
            textBoxResult.Text = text;
        }
    }
}
