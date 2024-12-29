using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.AspNetCore.SignalR.Client;
using ProjectTeam.Model;


namespace ProjectTeam
{
    public partial class SanhChinh : Form
    {
        private int borderSize = 2;
        private Color defaultcolor_close_backcolor;
        private Color defaultcolor_close_iconcolor;
        private Form currentChildForm = null;
        private string username;
        private bool KoNenDangXuat = true;
        public user_info UserInfo;
        private string previous_form;

        private DatabaseHelper databaseHelper;

        public SanhChinh()
        {
            InitializeComponent();
            ThuGonMenu();

            this.Padding = new System.Windows.Forms.Padding(borderSize); //Border size
            this.BackColor = Color.FromArgb(196, 215, 255); //Border color
            PanelTitleBar.MouseDown += panelTitleBar_MouseDown;

            defaultcolor_close_backcolor = iconBtnCloseDesktop.BackColor;
            defaultcolor_close_iconcolor = iconBtnCloseDesktop.IconColor;
            iconBtnCloseDesktop.MouseDown += iconBtnCloseDesktop_MouseDown;
            iconBtnCloseDesktop.MouseUp += iconBtnCloseDesktop_MouseUp;

            OpenChildForm(new Home());
            Heading.Text = IconHome.Tag.ToString();
            subheading.Text = "Chào mừng bạn đã quay trờ lại";

        }

        public SanhChinh(string tendangnhap)
        {
            InitializeComponent();
            ThuGonMenu();
            username = tendangnhap;

            this.Padding = new System.Windows.Forms.Padding(borderSize); //Border size
            this.BackColor = Color.FromArgb(196, 215, 255); //Border color
            PanelTitleBar.MouseDown += panelTitleBar_MouseDown;

            defaultcolor_close_backcolor = iconBtnCloseDesktop.BackColor;
            defaultcolor_close_iconcolor = iconBtnCloseDesktop.IconColor;
            iconBtnCloseDesktop.MouseDown += iconBtnCloseDesktop_MouseDown;
            iconBtnCloseDesktop.MouseUp += iconBtnCloseDesktop_MouseUp;


            Heading.Text = IconHome.Tag.ToString();
            subheading.Text = "Chào mừng bạn đã quay trờ lại";

        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        //override methods
        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;
            const int WM_NCHITTEST = 0x84;
            const int HTLEFT = 10;
            const int HTRIGHT = 11;
            const int HTTOP = 12;
            const int HTTOPLEFT = 13;
            const int HTTOPRIGHT = 14;
            const int HTBOTTOM = 15;
            const int HTBOTTOMLEFT = 16;
            const int HTBOTTOMRIGHT = 17;


            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }    
            base.WndProc(ref m);

            if (m.Msg == WM_NCHITTEST && WindowState == FormWindowState.Normal)
            {
                // Lấy tọa độ con trỏ (client)
                int x = (m.LParam.ToInt32() & 0xFFFF);
                int y = (m.LParam.ToInt32() >> 16);
                Point pt = PointToClient(new Point(x, y));

                int resizeArea = 10; // khoảng cách từ viền để nhận resize

                bool left = pt.X <= resizeArea;
                bool right = pt.X >= this.ClientSize.Width - resizeArea;
                bool top = pt.Y <= resizeArea;
                bool bottom = pt.Y >= this.ClientSize.Height - resizeArea;

                if (left && top)
                    m.Result = (IntPtr)HTTOPLEFT;
                else if (right && top)
                    m.Result = (IntPtr)HTTOPRIGHT;
                else if (left && bottom)
                    m.Result = (IntPtr)HTBOTTOMLEFT;
                else if (right && bottom)
                    m.Result = (IntPtr)HTBOTTOMRIGHT;
                else if (left)
                    m.Result = (IntPtr)HTLEFT;
                else if (right)
                    m.Result = (IntPtr)HTRIGHT;
                else if (top)
                    m.Result = (IntPtr)HTTOP;
                else if (bottom)
                    m.Result = (IntPtr)HTBOTTOM;
            }
        }

        private void SanhChinh_Load(object sender, EventArgs e)
        {
            Label lineLabel = new Label// đường line phân cách
            {
                BorderStyle = BorderStyle.Fixed3D,
                AutoSize = false,
                Width = 1,              // Đặt chiều rộng nhỏ nếu muốn line dọc
                Height = taskbarMenu.Height, // Chiều cao của line
                Dock = DockStyle.Left,   // Đặt vị trí line ở bên trái
                BackColor = Color.Gray   // Màu của line
            };
            taskbarMenu.Controls.Add(lineLabel);

            databaseHelper = new DatabaseHelper();
            UserInfo = new user_info();
            UserInfo = databaseHelper.LayThongTinNguoiDung(username);


            OpenChildForm(new Home(UserInfo));
        }

        //thao tác form con
        public void OpenChildForm(Form childForm)
        {
            if (currentChildForm == childForm) return; // cố gắng fix ấn lại bị load lên lại

            if (currentChildForm != null)
                    currentChildForm.Close();
                

                currentChildForm = childForm;

            if (childForm is TaoBanVe create) // lắng nghe form TaoBanVe gọi draw
                create.YeuCauMoForm += GiaiQuyetYeuCauMoForm;

            if (childForm is Draw draw) // lắng nghe form draw gọi 2 form TaoBanVe hoặc ThamGiaPhongVe
                draw.YeuCauMoForm += GiaiQuyetYeuCauMoTaoBanVe;

            if (childForm is ThamGiaPhongVe thamgia) // lắng nghe form ThamGiaPhongVe gọi draw
                thamgia.YeuCauMoForm += GiaiQuyetYeuCauMoForm;
            

                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;

                PanelDesktop.Controls.Clear();
                PanelDesktop.Controls.Add(childForm);
                PanelDesktop.Tag = childForm;

                childForm.BringToFront();
                childForm.Show();

           
            
        }

        private void GiaiQuyetYeuCauMoForm(string forName)
        {
            if (forName == "OpenDraw")
            {
                OpenChildForm(new Draw(UserInfo, previous_form));
                CreateDraw.Enabled = false;
                IconEnjoy.Enabled = false;
                IconHome.Enabled = false;
                iconButton4.Enabled = false;
                iconButton5.Enabled = false;
                iconBtnCaiDat.Enabled = false;
                KoNenDangXuat = false;
            }
        }

        private void GiaiQuyetYeuCauMoTaoBanVe(string forName)
        {
            if(forName == "OpenCreateDraw")
            {
                OpenChildForm(new TaoBanVe(UserInfo));
                CreateDraw.Enabled = true;
                IconEnjoy.Enabled = true;
                IconHome.Enabled = true;
                iconButton4.Enabled = true;
                iconButton5.Enabled = true;
                iconBtnCaiDat.Enabled = true;
                KoNenDangXuat = true;
            }

            if (forName == "OpenEnjoyRoom")
            {
                OpenChildForm(new ThamGiaPhongVe(UserInfo));
                CreateDraw.Enabled = true;
                IconEnjoy.Enabled = true;
                IconHome.Enabled = true;
                iconButton4.Enabled = true;
                iconButton5.Enabled = true;
                iconBtnCaiDat.Enabled = true;
                KoNenDangXuat = true;
            }
        }



        private void btn_group_Click(object sender, EventArgs e)
        {

        }

        private void btn_home_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void taskbarMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            if(KoNenDangXuat)
            {
                this.Close();
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            else
                MessageBox.Show("Vui lòng thoát khỏi phòng trước khi đăng xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            


        }

        private void PanelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconBtnCloseDesktop_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void iconBtnCloseDesktop_MouseDown(object sender, MouseEventArgs e)
        {
            iconBtnCloseDesktop.BackColor = Color.Red;
            iconBtnCloseDesktop.IconColor = Color.White;
        }

        private void iconBtnCloseDesktop_MouseUp(object sender, MouseEventArgs e)
        {
            iconBtnCloseDesktop.BackColor = defaultcolor_close_backcolor;
            iconBtnCloseDesktop.IconColor = defaultcolor_close_iconcolor;
        }
        //Event methods
        private void SanhChinh_Resize(object sender, EventArgs e)
        {
            AdjustForm();
        }
        //Private methods
        private void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized:
                    this.Padding = new Padding(0, 8, 8, 0);
                    break;
                case FormWindowState.Normal:
                    if (this.Padding.Top != borderSize)
                        this.Padding = new Padding(borderSize);
                    break;

            }
        }

        private void iconBtnScaleDesktop_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void iconBtnExpandDesktop_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized; 
            else
                this.WindowState = FormWindowState.Normal;
            
        }

        private void btnMenu_Click(object sender, EventArgs e) // cài đặt taskbar
        {
            ThuGonMenu();
        }

        private void ThuGonMenu() 
        {
           if(this.taskbarMenu.Width > 200)
            {
                taskbarMenu.Width = 100;
                pictureBox1.Visible = false;
                btnMenu.Dock = DockStyle.Top;

                foreach(Button menuButton in taskbarMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "";
                    menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                    menuButton.Padding = new Padding(0);
                }

            }else
            {
                taskbarMenu.Width = 320;
                pictureBox1.Visible = true;
                btnMenu.Dock = DockStyle.None;

                foreach (Button menuButton in taskbarMenu.Controls.OfType<Button>())
                {
                    menuButton.Font = new Font(menuButton.Font, FontStyle.Bold);
                    menuButton.Text = "   " + menuButton.Tag.ToString();
                    menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                    menuButton.Padding = new Padding(10,10,10,10);
                }
            }
        }

        private void iconMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void rjCircularPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e) // click menu tạo bản vẽ
        {
            OpenChildForm(new TaoBanVe());
            previous_form = "Tao Ban Ve";
            Heading.Text = CreateDraw.Tag.ToString();
            subheading.Text = "Bản vẽ cho bạn";
        }

        private void IconHome_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Home(UserInfo));
            Heading.Text = IconHome.Tag.ToString();
            subheading.Text = "Chào mừng bạn đã quay trờ lại";
        }

        private void PanelDesktop_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ThietLap(UserInfo));
            Heading.Text = iconBtnCaiDat.Tag.ToString();
            subheading.Text = "Bạn có thể thay đổi thông tin tài khoản tại trang này";
        }

        private void iconButton3_Click(object sender, EventArgs e) // tham gia phong ve
        {
            OpenChildForm(new ThamGiaPhongVe(UserInfo));
            previous_form = "Tham Gia Phong Ve";
            Heading.Text = IconEnjoy.Tag.ToString();
            subheading.Text = "Phát triển kỹ năng hội họa và khám phá niềm đam mê nghệ thuật";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LuuBanVe(UserInfo));
            Heading.Text = iconButton4.Tag.ToString();
            subheading.Text = "Nơi lưu trữ ảnh chụp của các bản vẽ";
        }
    }
}
