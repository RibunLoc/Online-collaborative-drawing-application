using ProjectTeam.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProjectTeam
{
    public partial class Home : Form
    {
        user_info user_Info;
        private DatabaseHelper databaseHelper;

        public Home()
        {
            InitializeComponent();
        }
        public Home(user_info user)
        {
            InitializeComponent();
            user_Info = new user_info();
            user_Info = user;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            databaseHelper = new DatabaseHelper();

            TxtName.Text = user_Info.name;
            lbl_id.Text = "User id: " + user_Info.user_id.ToString();
            //sau này load avatar
        }

        private void icon_btn_close_info_Click(object sender, EventArgs e)
        {
            ThuGonUerInfo();
        }

        private void ThuGonUerInfo()
        {
            if(this.taskBarUserInfo.Width > 200)
            {
                taskBarUserInfo.Width = 30;
                Hello.Visible = false;
                TxtName.Visible = false;
                btnThongBao.Visible = false;
                icon_Online.Visible = false;
                lbl_status.Visible = false;
                lbl_id.Visible = false;
                avatar_personal.Visible = false;

                

                icon_btn_close_info.Dock = DockStyle.Left;
                icon_btn_close_info.IconChar = FontAwesome.Sharp.IconChar.CaretDown;
                icon_btn_close_info.IconColor = Color.FromArgb(228, 224, 225);
                

                foreach (Button iconbutton in infoUser.Controls.OfType<Button>())
                {
                    iconbutton.ImageAlign = ContentAlignment.MiddleCenter;
                    iconbutton.Padding = new Padding(0);
                }

            }else
            {
                taskBarUserInfo.Width = 380;
                Hello.Visible = true;
                TxtName.Visible = true;
                btnThongBao.Visible = true;
                icon_Online.Visible = true;
                lbl_status.Visible = true;
                lbl_id.Visible = true;
                avatar_personal.Visible = true;
                icon_btn_close_info.Dock = DockStyle.Left;
                icon_btn_close_info.IconChar = FontAwesome.Sharp.IconChar.CaretRight;
                icon_btn_close_info.IconColor = Color.Black;

                foreach (Button iconbutton in infoUser.Controls.OfType<Button>())
                {
                    iconbutton.ImageAlign = ContentAlignment.MiddleCenter;
                    iconbutton.Padding = new Padding(0);
                }

            }
        }

        private void rjCircularPictureBox1_Click(object sender, EventArgs e) //avatar personal
        {

        }

        private void lbl_status_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Status_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

            
        }

        private void TxtName_Click(object sender, EventArgs e)
        {

        }
    }
}
