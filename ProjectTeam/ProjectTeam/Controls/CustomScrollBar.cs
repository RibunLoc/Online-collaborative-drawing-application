using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectTeam.Controls
{
    public class CustomScrollBar : VScrollBar
    {
        public CustomScrollBar()
        {
            this.BackColor = Color.White; // Màu nền của thanh cuộn
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillRectangle(new SolidBrush(Color.Gray), this.ClientRectangle); // Màu nền
        }
    }
}
