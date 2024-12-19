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
using System.Collections.Concurrent;

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
        private bool isBufferInitialized = false;
        public event Action<string> YeuCauMoForm;
        private TcpListener server;
        private bool isRun = true;
        private List<(Point start, Point end)> lines = new List<(Point, Point)>(); // tạo danh sách lưu trữ đường vẽ
        private ConcurrentQueue<(Point start, Point end)> drawQueue = new ConcurrentQueue<(Point, Point)>();
        private bool isRunning = true;
        private user_info user; // thông tin xác định đầy đủ của người dùng 
        private string previous_form;
        private string roomId = GlobalVariables.Maphong;
        private SortedList<int, (Point start, Point end)> pendingLines = new SortedList<int, (Point, Point)>();


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
            lblCodeRoom.Text = "mã phòng: " + roomId;
            //Khởi tạo draConnection
            drawConnection = new DrawConnection("127.0.0.1", 5000, roomId, user.name);

            drawConnection.isConnected = true;

            panel_Draw.MouseDown += Panel_Draw_MouseDown;
            panel_Draw.MouseUp += Panel_Draw_MouseUp;
            panel_Draw.MouseMove += Panel_Draw_MouseMove;
            panel_Draw.Paint += Panel_Draw_Paint_On_Canvas;
            panel_Draw.Resize += Panel_Draw_Resize;

            this.Resize += new EventHandler(Form_Resize);

            points = new List<DrawingPoint>();
            previousPoint = null;

            Task.Run(() =>
            {
                ProcessDrawQueue();
            });

            panel_Draw.Paint += Panel_Draw_Paint;

            _ = Task.Run(() => ListenForMessagesAsync(drawConnection.tcpClient));

        }



        private void SanhChinh_Resize(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void InitializeBufferedGraphics()
        {
            if (!isBufferInitialized || bufferedGraphics == null)
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

            foreach(var line in lines)
            {
                using (Pen pen = new Pen(Color.Black, 5))
                {
                    bufferedGraphics.Graphics.DrawLine(pen, line.start, line.end);  
                }
            }

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

            using (Pen pen = new Pen(Color.Black, 5))
            {
                foreach (var line in lines)
                {
                    bufferedGraphics.Graphics.DrawLine(pen, line.start, line.end);
                }
            }

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
                DrawLines(bufferedGraphics.Graphics, points, Color.Black, 5);

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
            string DulieuVe = $"{start.point.X},{start.point.Y},{end.point.X},{end.point.Y},{panel_Draw.Width},{panel_Draw.Height}\n";
            await drawConnection.GuiDuLieuAsync(DulieuVe);

        }

        private void DrawLineOnServer(Point start, Point end)
        {
            lines.Add((start, end));

            using (Graphics g = this.panel_Draw.CreateGraphics())
            {
                bufferedGraphics.Graphics.DrawLine(Pens.Black, start, end);

                //Rectangle invalidRect = new Rectangle(
                //Math.Min(start.X, end.X),
                //Math.Min(start.Y, end.Y),
                //Math.Abs(start.X - end.X),
                //Math.Abs(start.Y - end.Y));

                //const int margin = 5; // You can adjust this margin size if needed

                panel_Draw.Invalidate();
            }

        }

        private async Task ProcessDrawQueue()
        {
            while (isRunning)
            {
                if (drawQueue.TryDequeue(out var line))
                {
                    panel_Draw.Invoke(new Action(() =>
                    {
                        DrawLineOnServer(line.start, line.end);
                    }));
                }
                else
                {
                    await Task.Delay(5);

                }
            }
        }

        private void HienThiTinNhanChat(string messeage)
        {
            if (rtb_content.InvokeRequired)
            {
                rtb_content.Invoke(new Action(() => { HienThiTinNhanChat(messeage); }));
            }else
            {
                rtb_content.AppendText(messeage + "\n");
            }
        }

        private void ProcessLine(string line)
        {
            try
            {
                if (line.StartsWith("chat:"))
                {
                    string messeage = line.Substring(5);
                    HienThiTinNhanChat(messeage);
                }else
                {
                    string[] parts = line.Split(',');
                    int x1, x2;
                    int y1, y2;
                    x1 = int.Parse(parts[0]); y1 = int.Parse(parts[1]);

                    x2 = int.Parse(parts[2]); y2 = int.Parse(parts[3]);

                    Point start = new Point(x1, y1);
                    Point end = new Point(x2, y2);

                    drawQueue.Enqueue((start, end));
                }
                 
            }catch (Exception ex) 
            {

            }
        }

        private async Task ListenForMessagesAsync(TcpClient tcpClient)
        {
            NetworkStream stream = tcpClient.GetStream();
            StringBuilder incompleteData = new StringBuilder();

            byte[] bodem = new byte[8192];
            int bytesRead;

                while ((bytesRead = await stream.ReadAsync(bodem, 0, bodem.Length)) > 0)
                {
                    try
                    {
                        string incomingdata = Encoding.UTF8.GetString(bodem, 0, bytesRead);
                        
                        incompleteData.Append(incomingdata);

                        string data = incompleteData.ToString();
                        int NewlineIndex;

                        //tách dữ liệu và xử lý

                        while ((NewlineIndex = data.IndexOf('\n')) > 0)
                        {
                            string incompleteLine = data.Substring(0, NewlineIndex);
                            data = data.Substring(NewlineIndex + 1);

                            ProcessLine(incompleteLine);
                        }
                        incompleteData.Clear();
                        incompleteData.Append(data);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
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

            DialogResult result = MessageBox.Show("Bạn có chắc sẽ thoát khỏi phòng này!", "Thông tin", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {

                // xóa người dùng trên cơ sở dữ liệu từ phòng vẽ đó
                DatabaseHelper dbhp = new DatabaseHelper();
                if (dbhp.XoaMotThanhVien(user.user_id)) ;
                    SomeConditionMet();

                // Gửi tín hiệu ngắt kết nối
                drawConnection.GuiTinHieuThoat(user.name);

            }



        }

        private bool BienCoThuGon = true; // Biến cờ thu gọn
        
        private void Form_Resize(object sender, EventArgs e)
        {
            if (!BienCoThuGon)// chua thu gon
            {
                int x = this.ClientSize.Width - panel_KhungChat.Width;
                panel_KhungChat.Location = new Point(x, panel_KhungChat.Location.Y);
            }
        }

        
        private void btn_AnIcon_Click(object sender, EventArgs e)
        {

            int x = this.ClientSize.Width - panel_KhungChat.Width;
            if (BienCoThuGon)// thu nhỏ lại
            {
                BienCoThuGon = false;

                rtb_content.Visible = false;
                tb_chat.Visible = false;
                btn_Send.Visible = false;
                panel_ControlChat.Visible = false;
                panel_ControlContent.Visible = false;
                panel_KhungChat.Dock = DockStyle.None;
                panel_KhungChat.Height = 47;
                panel_KhungChat.Location = new Point(x, panel_KhungChat.Location.Y);
                
                
            }
            else // 
            {
                BienCoThuGon = true;
                panel_ControlChat.Visible = true;
                panel_ControlContent.Visible = true;
                panel_KhungChat.Dock = DockStyle.Right;
                rtb_content.Visible = true;
                tb_chat.Visible = true;
                btn_Send.Visible = true;
            
            }
        }

        private async void SendChatToServer(string messeage)
        {
            string DulieuVe = $"chat:{messeage}\n";
            await drawConnection.GuiDuLieuAsync(DulieuVe);

        }

        // client gửi tin nhắn tới server
        private void tb_chat__TextChanged(object sender, EventArgs e)
        {
 
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {

            string messeage = $"{user.name}: {tb_chat.Texts}";
            SendChatToServer(messeage);
            HienThiTinNhanChat(messeage);
         
        }
    }
}




