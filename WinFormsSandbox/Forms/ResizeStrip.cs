using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsSandbox.Forms
{
    /// <summary>
    /// Represents a horizontal strip used to resize the height of its parent control.
    /// </summary>
    class ResizeStrip : Control
    {
        private int lastY;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Cursor Cursor => Cursors.HSplit;

        /// <summary>
        /// Gets or sets the edges of the container to which a control is bound and determines how 
        /// a control is resized with its parent. 
        /// </summary>
        /// <returns>
        /// A bitwise combination of the <see cref="T:System.Windows.Forms.AnchorStyles"/> values.
        /// The default is Top and Left.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public override AnchorStyles Anchor
        {
            get { return AnchorStyles.Bottom; }
            set { base.Anchor = AnchorStyles.Bottom; }
        }

        public ResizeStrip()
        {
            base.BackColor = SystemColors.ControlDark;
            base.Dock = DockStyle.Bottom;
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            if (Parent != null)
            {
                Parent.ControlAdded += ParentOnControlAdded;
            }

            BringToFront();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            BringToFront();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left)
            {
                lastY = e.Y;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button == MouseButtons.Left && Parent != null)
            {
                Parent.Height = Parent.Height + e.Location.Y - lastY;
                Parent.Refresh();
            }
        }

        private void ParentOnControlAdded(object sender, ControlEventArgs e)
        {
            BringToFront();
        }
    }
}
