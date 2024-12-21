using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
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
using System.Windows.Shapes;
using Path = System.IO.Path;
using System.Web.WebSockets;

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
        private bool EarseMode = false;
        private bool PenMode = false;
        private Cursor CursorCustom;
        private Cursor CursorEraser;
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
            // Bật DoubleBuffered cho panel_Draw
            typeof(System.Windows.Forms.Panel).InvokeMember(
                "DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null,
                panel_Draw,
                new object[] { true }
            );
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Directory.GetParent(basePath).Parent.Parent.FullName;

            string cursorPath = Path.Combine(projectDirectory, "Cursor", "pencil.cur");
            CursorCustom = new Cursor(cursorPath);

            string EraserPath = Path.Combine(projectDirectory, "Cursor", "eraser.cur");
            CursorEraser = new Cursor(EraserPath);








            lblCodeRoom.Text = "mã phòng: " + roomId;
            //Khởi tạo draConnection
            drawConnection = new DrawConnection("127.0.0.1", 5000, roomId, user.name);

            drawConnection.isConnected = true;

            tb_chat.PlaceholderText = user.name + " Trò chuyện.....";

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

            panel_Draw.Paint += Panel_Draw_Paint_On_Screen;

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
                bufferedGraphics?.Dispose();

                if(!panel_Draw.ClientRectangle.IsEmpty)
                {
                    bufferedGraphics = NoiDungHienTai.Allocate(panel_Draw.CreateGraphics(), panel_Draw.ClientRectangle);
                    isBufferInitialized = true;
                }

               
            }
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


        private void Panel_Draw_Paint_On_Canvas(object sender, PaintEventArgs e)
        {
            InitializeBufferedGraphics();
            if (bufferedGraphics == null) return;

            var g = bufferedGraphics.Graphics;

            if (!isBufferInitialized)
            {
                g.Clear(panel_Draw.BackColor);
                isBufferInitialized = true;
            }


            // Gọi DrawLinesFromList để vẽ tất cả các đường trong danh sách lines
            DrawLinesFromList(g);


         
            bufferedGraphics.Render(e.Graphics);
        }

        private void Panel_Draw_Paint_On_Screen(object sender, PaintEventArgs e)
        {
            InitializeBufferedGraphics();
            if (bufferedGraphics == null) return;

            var g = bufferedGraphics.Graphics;
            g.Clear(panel_Draw.BackColor);

            DrawLinesFromList(g);

            
            if(bufferedGraphics != null)
                bufferedGraphics.Render(e.Graphics);

        }

        // Phương thức tính khoảng cách từ điểm p đến đoạn thẳng ab
        private double DistancePointToLine(Point p, Point a, Point b)
        {
            double A = p.X - a.X;
            double B = p.Y - a.Y;
            double C = b.X - a.X;
            double D = b.Y - a.Y;

            double dot = A * C + B * D;
            double len_sq = C * C + D * D;
            double param = -1;
            if (len_sq != 0) // tránh chia cho 0
                param = dot / len_sq;

            double xx, yy;

            if (param < 0)
            {
                xx = a.X;
                yy = a.Y;
            }
            else if (param > 1)
            {
                xx = b.X;
                yy = b.Y;
            }
            else
            {
                xx = a.X + param * C;
                yy = a.Y + param * D;
            }

            double dx = p.X - xx;
            double dy = p.Y - yy;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        private void Panel_Draw_MouseMove(object sender, MouseEventArgs e)
        {

            if (EarseMode)
            {
                this.Cursor = CursorEraser;
            }else if (PenMode)
            {
                this.Cursor = CursorCustom;
            }else
            {
                this.Cursor = Cursors.Default;
            }

            if (isDrawing && e.Button == MouseButtons.Left)
            {
                DrawingPoint currentPoint = new DrawingPoint();
                currentPoint.point = e.Location;
                currentPoint.isLastStroke = false;
                points.Add(currentPoint);

                if (previousPoint != null && !previousPoint.isLastStroke)
                {
                    lock (lines)
                    {
                        if (EarseMode)
                        {
                            //Tìm xóa điểm Lines
                            double threhold = 5.0;

                            var linesToRemove = lines.Where(line => DistancePointToLine(currentPoint.point, line.start, line.end) <= threhold).ToList() ;


                            foreach(var line in linesToRemove)
                            {
                                lines.Remove(line);
                                DrawingPoint start = new DrawingPoint();
                                DrawingPoint end = new DrawingPoint();

                                start.point = line.start ;
                                start.isLastStroke = false;

                                end.point = line.end;
                                end.isLastStroke = true;
                               
                                SendDrawDataToServer(start, end);
                            }

                            if (linesToRemove.Count > 0)
                            {
                                panel_Draw.Invalidate();
                            }

                        } else if (PenMode)
                        {
                            lines.Add((previousPoint.point, currentPoint.point));
                            SendDrawDataToServer(previousPoint, currentPoint);

                        } else
                        {
                            // Chức năng khác 
                        }
                    }

                    
                }

                panel_Draw.Invalidate();
                // Cập nhật điểm trước đó
                previousPoint = currentPoint;
                
                
            }
        }

        private void Panel_Draw_MouseDown(object sender, MouseEventArgs e)
        {
              
            isDrawing = true;
            previousPoint = new DrawingPoint { point = e.Location, isLastStroke = false };
            
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




        private void DrawLinesFromList(Graphics g)
        {
            lock (lines)
            {
                foreach (var line in lines)
                {
                    using (Pen pen = new Pen(Color.Black, 5))
                    {
                        g.DrawLine(pen, line.start, line.end);
                    }
                }
            }
        }

        private async Task ProcessDrawQueue()
        {
            while (isRunning)
            {
                if (drawQueue.TryDequeue(out var line))
                {
                    lock (lines)
                    {
                        lines.Add(line);
                    }

                    panel_Draw.Invoke(new Action(() =>
                    {
                        panel_Draw.Invalidate();
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

        private async void SendDrawDataToServer(DrawingPoint start, DrawingPoint end)
        {
            string mode = " ";
            if (EarseMode)
                mode = "erase";
            else
                mode = "draw";

            string DulieuVe = $"{mode}:{start.point.X},{start.point.Y},{end.point.X},{end.point.Y},{panel_Draw.Width},{panel_Draw.Height}\n";
            await drawConnection.GuiDuLieuAsync(DulieuVe);

        }

        private void ProcessLine(string line)
        {
            try
            {
                if (line.StartsWith("chat:"))
                {
                    string messeage = line.Substring(5);
                    HienThiTinNhanChat(messeage);
                }else if (line.StartsWith("draw") ||line.StartsWith("erase"))
                {
                   
                    string[] parts = line.Split(':');

                    string mode = parts[0]; // draw hoac erase
                    string[] ToaDoDiem = parts[1].Split(',');

                    int x1, x2;
                    int y1, y2;
                    x1 = int.Parse(ToaDoDiem[0]); y1 = int.Parse(ToaDoDiem[1]);

                    x2 = int.Parse(ToaDoDiem[2]); y2 = int.Parse(ToaDoDiem[3]);

                    Point start = new Point(x1, y1);
                    Point end = new Point(x2, y2);

                    if (mode == "erase")
                    {
                        // xoa net ve
                        lock (lines)
                        {
                            lines.Remove((start, end));
                        }    
                       
                    }
                    else
                    {
                        drawQueue.Enqueue((start, end));
                    }
                }

                panel_Draw.Invoke(new Action(() => { panel_Draw.Invalidate(); }));
                 
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
                btn_AnIcon.IconChar = FontAwesome.Sharp.IconChar.Unsorted;
                btn_AnIcon.Text = "Mở rộng";
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

                btn_AnIcon.Text = "Thu gọn";
                btn_AnIcon.IconChar = FontAwesome.Sharp.IconChar.SquareMinus;
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
           string userinput = tb_chat.Texts.Trim();

            if (!(userinput == ""))
            {
                string messeage = $"{user.name}: {tb_chat.Texts}";
                SendChatToServer(messeage);
                HienThiTinNhanChat(messeage);
                tb_chat.Texts = "";
                tb_chat.PlaceholderText = user.name + " Trò chuyện.....";
            }
           
        }


        private void Bar_btn_2_Click(object sender, EventArgs e)
        {
            PenMode = !PenMode;
            if (EarseMode)
            {
                iconButton2.BackColor = Color.FromArgb(60, 61, 55);
                EarseMode = false;
            }

            if (PenMode)
            {
                Bar_btn_2.BackColor = Color.Gray;
            }
            else
            {
                Bar_btn_2.BackColor = Color.FromArgb(60, 61, 55);
            }
            

        }
        private void iconButton2_Click(object sender, EventArgs e) // ấn nút xóa
        {
            EarseMode = !EarseMode;

            if (PenMode)
            {
                Bar_btn_2.BackColor = Color.FromArgb(60, 61, 55);
                PenMode = false;
            }

            if (EarseMode)
            {
                iconButton2.BackColor = Color.Gray;
            }
            else
            {
              
                iconButton2.BackColor = Color.FromArgb(60, 61, 55);
            }
        }

        private void Draw_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            
        }

        private void tb_chat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (BienCoThuGon)
                {
                    btn_Send.Focus();
                    btn_Send.PerformClick();
                    e.Handled = true;
                   
                }




            } 
              
            
        }
    }


}





