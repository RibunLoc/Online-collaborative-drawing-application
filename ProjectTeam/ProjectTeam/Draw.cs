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
using System.Windows.Controls;
using System.Net;
using System.Net.Http;
using System.Drawing.Imaging;
using System.Web.UI.WebControls;
using System.IO;

namespace ProjectTeam
{

    public partial class Draw : Form
    {
        private DrawConnection drawConnection; // sử dụng lớp DrawConnection để gửi dữ liệu
        private bool isDrawing = false;        // Biến để kiểm tra trạng thái vẽ
        private DrawingPoint previousPoint;           // Điểm trước đó của chuột
        private Graphics graphics;             // Đối tượng Graphics để vẽ lên Panel
        private Pen pen;                       // Bút để vẽ
        private List<DrawingPoint> points;
        private BufferedGraphics bufferedGraphics; //Tránh hiệu ứng nhấp nháy
        private DateTime ThoiGianGuiLanCuoi = DateTime.MinValue;
        private readonly int senIntervalMs = 1;
        private bool isBufferInitialized = false;
        public event Action<string> YeuCauMoForm;
        private TcpListener server;
        private bool isRun = true;
        private List<(Point start, Point end)> lines = new List<(Point, Point)>(); // tạo danh sách lưu trữ đường vẽ
        private Queue<(Point start, Point end)> drawQueue = new Queue<(Point, Point)>();
        private bool isRunning = false;
        private user_info user; // thông tin xác định đầy đủ của người dùng 
        private string previous_form;
        private string roomId = GlobalVariables.Maphong;
        public class DrawingPoint
        {
            public Point point;
            public bool isLastStroke;
        }


        public Draw()
        {
            InitializeComponent();
        }
        public Draw(user_info TruyenUser, string form_truoc_do)
        {
            InitializeComponent();

            user = new user_info(); 
            user = TruyenUser; // truyền vào từ lớp cha
            richTextBox1.Text = roomId;
            previous_form = form_truoc_do;
        }

        private void SomeConditionMet()
        {
            if (previous_form == "Tao Ban Ve")
                YeuCauMoForm?.Invoke("OpenCreateDraw");
            else if (previous_form == "Tham Gia Phong Ve")
                YeuCauMoForm?.Invoke("OpenEnjoyRoom");
            else if (previous_form == "") // sau này nếu mở lại form trước đó hãy điền nó vào ""
            {
                return;
            }
            else
                return;
        }

        private void Draw_Load(object sender, EventArgs e)
        {

            //Khởi tạo draConnection
            drawConnection = new DrawConnection("localhost", 5000, roomId);

            drawConnection.isConnected = true;

            panel_Draw.MouseDown += Panel_Draw_MouseDown;
            panel_Draw.MouseUp += Panel_Draw_MouseUp;
            panel_Draw.MouseMove += Panel_Draw_MouseMove;
            panel_Draw.Paint += Panel_Draw_Paint_On_Canvas;
            panel_Draw.Resize += Panel_Draw_Resize;

            points = new List<DrawingPoint>();
            previousPoint = null;

            Task.Run(() =>
            {
                ProcessDrawQueue();
            });

            panel_Draw.Paint += panel_draw_Paint;

            _ = Task.Run(() => ListenForMessagesAsync(drawConnection.tcpClient));

        }

        private void InitializeBufferedGraphics()
        {
            if (!isBufferInitialized)
            {
                BufferedGraphicsContext NoiDungHienTai = BufferedGraphicsManager.Current;
                bufferedGraphics = NoiDungHienTai.Allocate(panel_Draw.CreateGraphics(), panel_Draw.ClientRectangle);
                isBufferInitialized = true;
            }
        }

        private void Panel_Draw_Paint_On_Canvas(object sender, PaintEventArgs e)
        {
            InitializeBufferedGraphics();
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
                isBufferInitialized = false;
            }

            panel_Draw.Invalidate(); // Yêu cầu vẽ lại
        }

        private void DrawLines(Graphics graphics, List<DrawingPoint> points, Color color, float pensize)
        {
            if (points.Count > 1)
            {
                using (Pen pen = new Pen(color, pensize))
                {
                    for (int i = 0; i < points.Count - 1; i++)
                    {
                        if (points[i].isLastStroke || points[i + 1].isLastStroke)
                        {
                            continue;
                        }

                        graphics.DrawLine(pen, points[i].point, points[i + 1].point);
                    }
                }
            }
        }

        private void Panel_Draw_Paint(object sender, PaintEventArgs e)
        {
            InitializeBufferedGraphics();
            if (bufferedGraphics == null) return;

            bufferedGraphics.Graphics.Clear(panel_Draw.BackColor);

            DrawLines(bufferedGraphics.Graphics, points, Color.Black, 2);

            bufferedGraphics.Render(e.Graphics);
        }

        private void Panel_Draw_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && e.Button == MouseButtons.Left)
            {
                InitializeBufferedGraphics();
                if (bufferedGraphics == null)
                {
                    Console.WriteLine("BufferedGraphics chưa được khởi tạo.");
                    return; // Dừng nếu buffer chưa khởi tạo
                }

                DrawingPoint currentPoint = new DrawingPoint();
                currentPoint.point = e.Location;
                currentPoint.isLastStroke = false;
                points.Add(currentPoint);

                // Làm sạch buffer trước khi vẽ
                bufferedGraphics.Graphics.Clear(panel_Draw.BackColor);

                // Vẽ lại tất cả các điểm trong danh sách
                DrawLines(bufferedGraphics.Graphics, points, Color.Black, 2);

                // Hiển thị buffer lên panel
                bufferedGraphics.Render(panel_Draw.CreateGraphics()); // Render trên Panel

                // Gửi dữ liệu tới server
                if (previousPoint != null && !previousPoint.isLastStroke)
                {
                    SendDrawDataToServer(previousPoint, currentPoint);
                }

                // Cập nhật điểm trước đó
                previousPoint = currentPoint;
            }
        }

        private void Panel_Draw_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            previousPoint = new DrawingPoint { point = e.Location, isLastStroke = false };
            points.Add(previousPoint); // Lưu điểm bắt đầu
        }

        private void Panel_Draw_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
            if (previousPoint != null)
            {
                previousPoint.isLastStroke = true;
            }
            previousPoint = null; // Reset điểm trước đó để tránh nối lại điểm khi bắt đầu vẽ mới
        }

        private async void SendDrawDataToServer(DrawingPoint start, DrawingPoint end)
        {
            if ((DateTime.Now - ThoiGianGuiLanCuoi).TotalMilliseconds >= senIntervalMs)
            {
                string DulieuVe = $"{start.point.X},{start.point.Y},{end.point.X},{end.point.Y},{panel_Draw.Width},{panel_Draw.Height}\n";
                await drawConnection.GuiDuLieuAsync(DulieuVe);
                ThoiGianGuiLanCuoi = DateTime.Now;
            }
        }

        private async void ProcessDrawQueue()
        {
            while (isRunning)
            {
                (Point start, Point end)? line = null;

                lock (drawQueue)
                {
                    if (drawQueue.Count > 0)
                    {
                        line = drawQueue.Dequeue();
                    }
                }

                if (line.HasValue)
                {
                    DrawLineOnServer(line.Value.start, line.Value.end);

                }

                await Task.Delay(5);
            }
        }


        private void panel_draw_Paint(object sender, PaintEventArgs e)
        {
            //lines.Add((start, end));

            using (Pen pen = new Pen(Color.Black, 2))
            {
                foreach (var line in lines)
                {
                    bufferedGraphics.Graphics.DrawLine(pen, line.start, line.end);
                }

            }

            bufferedGraphics.Render(e.Graphics);
        }

        private void DrawLineOnServer(Point start, Point end)
        {
            lines.Add((start, end));

            using (Graphics g = this.panel_Draw.CreateGraphics())
            {
                bufferedGraphics.Graphics.DrawLine(Pens.Black, start, end);

                Rectangle invalidRect = new Rectangle(
                Math.Min(start.X, end.X),
                Math.Min(start.Y, end.Y),
                Math.Abs(start.X - end.X),
                Math.Abs(start.Y - end.Y));

                const int margin = 5; // You can adjust this margin size if needed
                invalidRect.Inflate(margin, margin); // Increase the invalidation area by a small amount


                panel_Draw.Invalidate(invalidRect);
            }
        }

        private async Task ListenForMessagesAsync(TcpClient tcpClient)
        {
            NetworkStream stream = tcpClient.GetStream();

            byte[] bodem = new byte[1024];
            int bytesRead;
            while ((bytesRead = await stream.ReadAsync(bodem, 0, bodem.Length)) > 0)
            {
                try
                {
                    string data = Encoding.ASCII.GetString(bodem, 0, bytesRead);

                    //tách dữ liệu và xử lý
                    string[] lines = data.Split(new[] { '\n' } , StringSplitOptions.RemoveEmptyEntries);
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(',');
                        Point start = new Point(
                            int.Parse(parts[0]) * panel_Draw.Width / int.Parse(parts[4]),
                            int.Parse(parts[1]) * panel_Draw.Height / int.Parse(parts[5])
                            );
                        Point end = new Point(
                            int.Parse(parts[2]) * panel_Draw.Width / int.Parse(parts[4]),
                            int.Parse(parts[3]) * panel_Draw.Height / int.Parse(parts[5])
                            );

                       
                        panel_Draw.Invoke(new Action(() =>
                        {
                            DrawLineOnServer(start, end);
                        }));
                        lock (drawQueue)
                        {
                            drawQueue.Enqueue((start, end));
                        }
                    }        
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }       
       
        }

        public async Task CapturePanel(string filePath)
        {
            try
            {
                await Task.Run(() =>
                {
                    // Create a bitmap with the size of the panel
                    using (Bitmap bitmap = new Bitmap(panel_Draw.Width, panel_Draw.Height))
                    {
                        // Draw the panel's content into the bitmap
                        panel_Draw.DrawToBitmap(bitmap, new Rectangle(0, 0, panel_Draw.Width, panel_Draw.Height));

                        // Save the bitmap to the specified file path
                        bitmap.Save(filePath, ImageFormat.Png);
                    }
                });

                MessageBox.Show("Capture successfully saved to " + filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during capture: " + ex.Message);
            }
        }
        private void panel_Draw_Paint(object sender, EventArgs e)
        {

        }

        private void Bar_btn_2_Click(object sender, EventArgs e)
        {

        }


        private void btn_Thoat_Click(object sender, EventArgs e)
        {

            //DialogResult result = MessageBox.Show("Bạn có chắc sẽ thoát khỏi phòng này!", "Thông tin", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //if(result == DialogResult.OK)
            //{

            // cần xử lý ngắt tới server bất đồng bộ
            // here
            SomeConditionMet();
            // xóa người dùng trên cơ sở dữ liệu từ phòng vẽ đó
            DatabaseHelper dbhp = new DatabaseHelper();
            if (dbhp.XoaMotThanhVien(user.user_id)) ;
                    

            //}
           
           
        }


        public void UploadToFTP(string filePath, string ftpUrl, string username, string password)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    // Set FTP credentials
                    client.Credentials = new NetworkCredential(username, password);

                    // Upload the file
                    client.UploadFile(ftpUrl, WebRequestMethods.Ftp.UploadFile, filePath);
                }
                MessageBox.Show("Upload file successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during upload: " + ex.Message);
            }
        }

        

        public void DisplayImage(string filePath, PictureBox pictureBox)
        {
            // Load the image into the PictureBox
            pictureBox.Image = System.Drawing.Image.FromFile(filePath);
        }
        private async void Save_Click(object sender, EventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void Save_Click_1(object sender, EventArgs e)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string path = "C:\\Users\\ASUS\\Documents\\screenshot.png";
            string ftpUrl = $"ftp://eu-central-1.sftpcloud.io/uploads/screenshot_{user.user_id}_{timestamp}.png";
            await CapturePanel(path);

            UploadToFTP(path, ftpUrl, "ac28858bb11646e794d3c1fd8306cf89", "Gli0fgnQuirKCBD14FH3RqMtPTrs6asT");
        }
    }
}




