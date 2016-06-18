using System;
using System.Windows.Forms;

namespace WinFormsSandbox.Forms
{
    /// <summary>
    /// Provides base functionality for a mechanism that colapses and expands 
    /// a <see cref="Control"/>. The mechanism can be used to adjust widths or distances as well.
    /// For instance, one implementation might track and adjust a splitter distance value.
    /// </summary>
    /// <typeparam name="T">The type of control to implement.</typeparam>
    public abstract class ControlColapser<T> where T : Control
    {
        private int lastHeight;
        private bool setLastHeight;

        /// <summary>
        /// Gets whether the control is colapsed.
        /// </summary>
        public bool IsColapsed => ControlHeight <= GetColapsedHeight();

        /// <summary>
        /// Gets the control in which this mechanism operates on.
        /// </summary>
        protected T Control { get; }

        /// <summary>
        /// Gets or sets the height to initially expand the control to.
        /// This height is used if a previous expanded height has not be set by the user.
        /// If the value is 0, then the control will expand to entail all of its controls.
        /// This value must be set if the controls are anchored to fill the <see cref="QuickView"/>.
        /// </summary>
        public int InitialExpandHeight { get; set; }

        /// <summary>
        /// Occurs when the colapsed state of the control has been toggled.
        /// Yields true, if colapsed, otherwise false.
        /// </summary>
        public event EventHandler<bool> ControlColapsedToggled;

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlColapser&lt;T&gt;"/> 
        /// class with the specified argument.
        /// </summary>
        /// <param name="control">The control to colapse/expand.</param>
        protected ControlColapser(T control)
        {
            Control = control;
        }

        /// <summary>
        /// Saves the height of the control so it can be restored later. This typically
        /// should be called when the control resizes.
        /// </summary>
        protected void SaveHeight()
        {
            if (setLastHeight)
            {
                lastHeight = ControlHeight;
            }
        }

        /// <summary>
        /// Gets the height in which this control must be, to make all of the child controls visible.
        /// </summary>
        protected virtual int GetAllEncompassingHeight()
        {
            int lowestEdge = -1;

            foreach (Control control in Control.Controls)
            {
                if (control.Bottom + control.Margin.Bottom > lowestEdge)
                    lowestEdge = control.Bottom + control.Margin.Bottom;
            }

            return lowestEdge;
        }

        /// <summary>
        /// Gets the minimum height that the control must be, for the control to be
        /// considered colapsed.
        /// </summary>
        /// <returns></returns>
        protected abstract int GetColapsedHeight();

        /// <summary>
        /// Gets the height the control resizes to when it colapses.
        /// </summary>
        protected virtual int GetColapseHeight()
        {
            return 0;
        }

        /// <summary>
        /// Gets or sets the height of the control.
        /// </summary>
        protected abstract int ControlHeight { get; set; }

        /// <summary>
        /// Colapses this control.
        /// </summary>
        public void Colapse()
        {
            // Whether the control is able to colapse from an expanded state.
            // The control will fully colapse even if it is already considered colapsed.
            bool isColapsing = (ControlHeight > GetColapsedHeight());

            setLastHeight = false;
            lastHeight = ControlHeight;
            ControlHeight = GetColapseHeight();
            setLastHeight = true;

            if (isColapsing)
                OnControlColapsedToggled(true);
        }

        /// <summary>
        /// Toggles the colapsed/expanded state.
        /// </summary>
        /// <returns>True, if the control is colapsed, otherwise false.</returns>
        public virtual bool Toggle()
        {
            if (ControlHeight > GetColapsedHeight())
            {
                Colapse();
                return true;
            }
            else
            {
                Expand();
                return false;
            }
        }

        /// <summary>
        /// Expands this control.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public void Expand()
        {
            if (!IsColapsed) return;

            setLastHeight = false;
            // Expand to last height if it is high enough.
            if (lastHeight > GetColapsedHeight())
            {
                ControlHeight = lastHeight;
                lastHeight = ControlHeight;
            }
            else if (InitialExpandHeight > 0) // Expand to the initial expand height if there is one.
            {
                ControlHeight = InitialExpandHeight;
                lastHeight = ControlHeight;
            }
            else
            {
                int lowest = GetAllEncompassingHeight();

                // Try to expand to entail the lowest control.
                // If there isn't one then
                if (lowest == -1)
                {
                    throw new InvalidOperationException("No controls in the quick view.");
                }

                ControlHeight = lowest;
                lastHeight = ControlHeight;
            }


            setLastHeight = true;
            OnControlColapsedToggled(false);
        }

        /// <summary>
        /// Raises the <see cref="ControlColapsedToggled"/> event.
        /// </summary>
        /// <param name="colapsed">True, if the control has been colapsed, otherwise false.</param>
        protected virtual void OnControlColapsedToggled(bool colapsed)
        {
            ControlColapsedToggled?.Invoke(this, colapsed);
        }
    }
}