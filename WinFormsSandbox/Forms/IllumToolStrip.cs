using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsSandbox.Forms
{
    /// <summary>
    /// Represents a <see cref="ToolStrip"/> that illuminates when the mouse hovers over it.
    /// </summary>
    class IllumToolStrip : ToolStrip
    {
        private Color lastColor, illumColor;

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            SetEffectColors();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            BackColor = illumColor;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            BackColor = lastColor;
        }

        private void SetEffectColors()
        {
            lastColor = BackColor;
            illumColor = BackColor.ChangeBrightness(15);
        }
    }
}
