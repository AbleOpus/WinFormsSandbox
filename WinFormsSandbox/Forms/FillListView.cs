using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsSandbox.Forms
{
    /// <summary>
    /// Represents a <see cref="ListView"/> that automatically adjusts the width of its last
    /// column so that it fills the otherwise remaining space.
    /// </summary>
    class FillListView : ListView
    {
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            AutoSizeLastColumn();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            AutoSizeLastColumn();
        }

        private void AutoSizeLastColumn()
        {
            if (Columns.Count > 0)
            {
                int width = 0;

                for (int i = 0; i < Columns.Count - 1; i++)
                {
                    width += Columns[i].Width;
                }

                Columns[Columns.Count - 1].Width = ClientSize.Width - width;
            }
        }
    }
}
