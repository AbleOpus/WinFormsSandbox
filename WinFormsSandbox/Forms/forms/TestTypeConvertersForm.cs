using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsSandbox.Forms
{
    /// <summary>
    /// Represents a Form for testing <see cref="TypeConverter"/>s.
    /// </summary>
    public partial class TestTypeConvertersForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestTypeConvertersForm"/> class.
        /// </summary>
        public TestTypeConvertersForm()
        {
            InitializeComponent();
            var pen = ((Pen)propertyGrid.SelectedGridItem.Value);
            base.Text = pen.Color + " " + pen.Width + " " + pen.Alignment;
            propertyGrid.SelectedObject = new TestType1(this);
        }

        /// <summary>
        /// Provides instances that are dummy object for the property grid test.
        /// </summary>
        private class TestType1
        {
            /// <summary>
            /// Gets or sets the property to test.
            /// </summary>
            public Control TestProp { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="TestType1"/> class
            /// with the specified argument.
            /// </summary>
            /// <param name="testProp">The property to test.</param>
            public TestType1(Control testProp)
            {
                TestProp = testProp;
            }
        }
    }
}
