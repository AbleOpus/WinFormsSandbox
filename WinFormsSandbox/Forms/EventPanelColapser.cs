using System.Windows.Forms;

namespace WinFormsSandbox.Forms
{
    /// <summary>
    /// Provides a mechanism for colapsing and expanding a <see cref="SplitContainer"/> control.
    /// </summary>
    class EventPanelColapser : ControlColapser<SplitContainer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventPanelColapser"/> with
        /// the specified argument.
        /// </summary>
        /// <param name="control">The <see cref="SplitContainer"/> to be colapsed/expanded.</param>
        public EventPanelColapser(SplitContainer control) : base(control)
        {
            control.SplitterMoved += delegate
            {
                SaveHeight();
            };
        }

        /// <summary>
        /// Gets the minimum height that the control must be, for the control to be
        /// considered colapsed.
        /// </summary>
        /// <returns></returns>
        protected override int GetColapsedHeight()
        {
            return 50;
        }

        /// <summary>
        /// Gets or sets the height of the control.
        /// </summary>
        protected override int ControlHeight
        {
            get { return Control.Panel2.Width; }
            set
            {
                int newVal = Control.Width - value;

                if (newVal < 0)
                {
                    Control.SplitterDistance = 0;
                }
                else
                {
                    Control.SplitterDistance = newVal;
                }
            }
        }
    }
}
