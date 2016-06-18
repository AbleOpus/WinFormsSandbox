using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsSandbox.Forms
{
    /// <summary>
    /// Groups related controls into a colapsable parent.
    /// </summary>
    public partial class QuickView : UserControl
    {
        /// <summary>
        /// Provides a mechanism for colapsing and expanding a <see cref="QuickView"/> control.
        /// </summary>
        public class QuickViewControlColapser : ControlColapser<QuickView>
        {
            /// <summary>
            /// Gets or sets the height of the control.
            /// </summary>
            protected override int ControlHeight
            {
                get { return Control.Height; }
                set { Control.Height = value; }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="QuickViewControlColapser"/> with
            /// the specified argument.
            /// </summary>
            /// <param name="control">The <see cref="QuickView"/> to be colapsed/expanded.</param>
            public QuickViewControlColapser(QuickView control) : base(control)
            {
                control.SizeChanged += delegate { SaveHeight(); };
            }

            /// <summary>
            /// Gets the height in which this control must be, to make all of the child controls visible.
            /// </summary>
            protected override int GetAllEncompassingHeight()
            {
                return base.GetAllEncompassingHeight() + Control.ResizerMarginTop;
            }

            /// <summary>
            /// Gets the minimum height that the control must be, for the control to be
            /// considered colapsed.
            /// </summary>
            /// <returns></returns>
            protected override int GetColapsedHeight()
            {
                return Control.MinimumSize.Height + 20;
            }
        }

        /// <summary>
        /// Gets the Margin.Top value of the control's vertical resizer.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ResizerMarginTop => resizeStrip.Margin.Top;

        /// <summary>
        /// Gets or sets the height to initially expand the control to.
        /// This height is used if a previous expanded height has not be set by the user.
        /// If the value is 0, then the control will expand to entail all of its controls.
        /// This value must be set if the controls are anchored to fill the <see cref="QuickView"/>.
        /// </summary>
        [Category("Behavior"), DefaultValue(0)]
        [Description("The height to initially expand the control to.")]
        public int InitialExpandHeight
        {
            get { return Colapser.InitialExpandHeight; }
            set { Colapser.InitialExpandHeight = value; }
        }

        /// <summary>
        /// Gets the mechanism that expands and colapses the control.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public QuickViewControlColapser Colapser { get; }

        /// <summary>
        /// Gets or sets the caption that is displayed at the top of the control.
        /// </summary>
        [Category("Appearance"), DefaultValue("Caption")]
        [Description("The caption that is displayed at the top of the control.")]
        public string Caption
        {
            get { return labelCaption.Text; }
            set { labelCaption.Text = value; }
        }

        /// <summary>
        /// Gets or sets the size that is the lower limit that <see cref="M:System.Windows.Forms.Control.GetPreferredSize(System.Drawing.Size)"/> can specify.
        /// </summary>
        /// <returns>
        /// An ordered pair of type <see cref="T:System.Drawing.Size"/> representing the width and height of a rectangle.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Size MinimumSize =>
    new Size(base.MinimumSize.Width, toolStrip.Height + resizeStrip.Height - 1);

        /// <summary>
        /// Initializes a new instance of the <see cref="QuickView"/> class.
        /// </summary>
        public QuickView()
        {
            InitializeComponent();
            ResizeRedraw = true;
            Colapser = new QuickViewControlColapser(this);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Enter"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            Colapser.Expand();
        }

        private void toolStrip_Click(object sender, EventArgs e)
        {
            Colapser.Toggle();
            (Parent as Panel)?.ScrollControlIntoView(this);
        }
    }
}
