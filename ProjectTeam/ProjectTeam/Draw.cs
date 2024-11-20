using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Net.Sockets;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR.Client;
using ProjectTeam.Model;



namespace ProjectTeam
{
    public partial class Draw : Form
    {
        private DrawConnection drawConnection; // sử dụng lớp DrawConnection để gửi dữ liệu
        private bool isDrawing = false;        // Biến để kiểm tra trạng thái vẽ
        private Point previousPoint;           // Điểm trước đó của chuột
        private Graphics graphics;             // Đối tượng Graphics để vẽ lên Panel
        private Pen pen;                       // Bút để vẽ
        private List<Point> points;
        private BufferedGraphics bufferedGraphics; //Tránh hiệu ứng nhấp nháy
        private DateTime ThoiGianGuiLanCuoi = DateTime.MinValue;
        private readonly int senIntervalMs = 50;
        public Draw()
        {
            InitializeComponent();
        }

        private void Draw_Load(object sender, EventArgs e)
        {

            //Khởi tạo draConnection
            drawConnection = new DrawConnection("localhost", 5000);

            panel_Draw.MouseDown += Panel_Draw_MouseDown;
            panel_Draw.MouseUp += Panel_Draw_MouseMove;
            panel_Draw.MouseMove += Panel_Draw_MouseMove;
            panel_Draw.Paint += Panel_Draw_Paint_On_Canvas;
            panel_Draw.Resize += Panel_Draw_Resize;


            points = new List<Point>();

            BufferedGraphicsContext NoiDungHienTai = BufferedGraphicsManager.Current;
            bufferedGraphics = NoiDungHienTai.Allocate(panel_Draw.CreateGraphics(), panel_Draw.ClientRectangle);
        }

        private void Panel_Draw_Paint_On_Canvas(object sender, PaintEventArgs e)
        {
            if (bufferedGraphics == null) return;

            bufferedGraphics.Graphics.Clear(panel_Draw.BackColor);

            DrawLines(bufferedGraphics.Graphics, points, Color.Black, 2);

            bufferedGraphics.Render(e.Graphics);
        }

        private void Panel_Draw_Resize(object sender, EventArgs e)
        {
            if (bufferedGraphics != null)
            {
                bufferedGraphics.Dispose(); // Giải phóng bộ nhớ cũ
            }

            BufferedGraphicsContext currentContext = BufferedGraphicsManager.Current;
            bufferedGraphics = currentContext.Allocate(panel_Draw.CreateGraphics(), panel_Draw.ClientRectangle);

            panel_Draw.Invalidate(); // Yêu cầu vẽ lại
        }


        private void DrawLines(Graphics graphics, List<Point> points, Color color, float pensize )
        {
            if (points.Count > 1)
            {
                using (Pen pen = new Pen(color, pensize))
                {
                    for (int i = 0; i < points.Count - 1; i++)
                    {
                        graphics.DrawLine(pen , points[i], points[i + 1]); 
                    }
                }

            }
        }

        private void Panel_Draw_Paint(object sender, PaintEventArgs e)
        {
            if (bufferedGraphics == null) return;

            bufferedGraphics.Graphics.Clear(panel_Draw.BackColor);

            DrawLines(bufferedGraphics.Graphics, points, Color.Black, 2);

            bufferedGraphics.Render(e.Graphics);
        }

        private void Panel_Draw_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && e.Button == MouseButtons.Left)
            {
                if (bufferedGraphics == null)
                {
                    Console.WriteLine("BufferedGraphics chưa được khởi tạo.");
                    return; // Dừng nếu buffer chưa khởi tạo
                }

                Point currentPoint = e.Location;
                points.Add(currentPoint);

                // Làm sạch buffer trước khi vẽ
                bufferedGraphics.Graphics.Clear(panel_Draw.BackColor);

                // Vẽ lại tất cả các điểm trong danh sách
                DrawLines(bufferedGraphics.Graphics, points, Color.Black, 2);

                // Hiển thị buffer lên panel
                bufferedGraphics.Render(panel_Draw.CreateGraphics()); // Render trên Panel

                // Gửi dữ liệu tới server
                SendDrawDataToServer(previousPoint, currentPoint);

                // Cập nhật điểm trước đó
                previousPoint = currentPoint;
            }
        }





        private void Panel_Draw_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            points.Clear();
            previousPoint = e.Location;
            points.Add(previousPoint); // Lưu điểm bắt đầu
        }




        private async void SendDrawDataToServer(Point start, Point end)
        {
            if ((DateTime.Now - ThoiGianGuiLanCuoi).TotalMilliseconds >= senIntervalMs)
            {
                string DulieuVe = $"{start.X},{start.Y},{end.X},{end.Y},{panel_Draw.Width},{panel_Draw.Height}";
                await drawConnection.GuiDuLieuAsync(DulieuVe);
                ThoiGianGuiLanCuoi = DateTime.Now;

            }
           
        }

        private void panel_Draw_Paint(object sender, EventArgs e)
        {

        }




    }
}
