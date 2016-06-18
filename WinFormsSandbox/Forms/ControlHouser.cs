using System.Drawing;
using System.Windows.Forms;

namespace WinFormsSandbox.Forms
{
    /// <summary>
    /// Represents a <see cref="Panel"/> that houses sandbox controls.
    /// It outlines all of its children in red.
    /// </summary>
    class ControlHouser : Panel
    {
        private readonly Pen borderPen = new Pen(Color.Red, 3f);

        /// <summary>
        /// Gets the internal spacing, in pixels, of the contents of a control.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Windows.Forms.Padding"/> that represents the internal spacing of the contents of a control.
        /// </returns>
        protected override Padding DefaultPadding => new Padding(6, 6, 6, 6);

        public ControlHouser()
        {
            ResizeRedraw = true;
            base.DoubleBuffered = true;
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            e.Control.LocationChanged += delegate { Invalidate(); };
            e.Control.SizeChanged += delegate { Invalidate(); };
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            foreach (Control control in Controls)
            {
                e.Graphics.DrawRectangle(
                    borderPen, 
                    control.Left - borderPen.Width / 2, 
                    control.Top - borderPen.Width / 2,
                    control.Width + borderPen.Width, 
                    control.Height + borderPen.Width);
            }
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Control"/> and its child controls and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources. </param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                borderPen.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
