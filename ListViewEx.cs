using System;
using System.Windows.Forms;

namespace GG
{
    public class ListViewEx : ListView
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int ShowScrollBar(IntPtr hWnd, int iBar, int bShow);
        const int SB_HORZ = 0;
        const int SB_VERT = 1;
        protected override void WndProc(ref Message m)
        {
            if (this.View == View.List || this.View == View.Details)
            {
                ShowScrollBar(this.Handle, SB_HORZ, 0);
            }
            base.WndProc(ref m);
        }
    }
}
