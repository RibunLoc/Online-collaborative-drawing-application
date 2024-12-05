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
using Microsoft.AspNetCore.SignalR.Client;


namespace ProjectTeam
{
    public partial class SanhChinh : Form
    {
        private int borderSize = 2;
        private Color defaultcolor_close_backcolor;
        private Color defaultcolor_close_iconcolor;
        private Form currentChildForm = null;


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
            if(m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }    
            base.WndProc(ref m);
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
        }

        //thao tác form con
        public void OpenChildForm(Form childForm)
        {
            if (currentChildForm == childForm) return; // cố gắng fix ấn lại bị load lên lại

            if (currentChildForm != null)
                    currentChildForm.Close();
                

                currentChildForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;

                PanelDesktop.Controls.Clear();
                PanelDesktop.Controls.Add(childForm);
                PanelDesktop.Tag = childForm;

                childForm.BringToFront();
                childForm.Show();

                //// Xử lý các sự kiện giao diện ngay lập tức để đảm bảo form con hiển thị đúng
                //Application.DoEvents();
           
            
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
            this.Close();

            this.DialogResult = DialogResult.Cancel;
            this.Close();
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
            OpenChildForm(new Draw());
            Heading.Text = CreateDraw.Tag.ToString();
            subheading.Text = "Bản vẽ cho bạn";
        }

        private void IconHome_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Home());
            Heading.Text = IconHome.Tag.ToString();
            subheading.Text = "Chào mừng bạn đã quay trờ lại";
        }

        private void PanelDesktop_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QuenMatKhau());
            //Heading.Text = taskbarMenu.Tag.ToString();
        }

        private void iconButton3_Click(object sender, EventArgs e) // tham gia phong ve
        {
            OpenChildForm(new ThamGiaPhongVe());
            Heading.Text = IconEnjoy.Tag.ToString();
            subheading.Text = "Phát triển kỹ năng hội họa và khám phá niềm đam mệ nghệ thuật";
        }
    }
}
