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
    public partial class ThietLap : Form
    {
        public user_info user_Info;
        private DatabaseHelper dbhp;
        public ThietLap(user_info TruyenUser)
        {
            InitializeComponent();
            user_Info = new user_info();
            this.user_Info = TruyenUser;
        }
        private void ThietLap_Load(object sender, EventArgs e)
        {
            dbhp = new DatabaseHelper();

            txtUsername.Text = user_Info.name;
            tbEmail.Text = user_Info.email;

            if (user_Info.gioitinh == "Nam")
                cmbOptions.SelectedIndex = 0;
            else
                cmbOptions.SelectedIndex = 1;

            tb_NgaySinh.Text = user_Info.ngaysinh;
            tb_SoDienThoai.Text = user_Info.sdt;

        }


        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

      

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnShowHide_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_ThayAvatar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofdl = new OpenFileDialog())
            {
                //

                ofdl.Filter = "Image File|*.jpg;*.png";
                ofdl.Title = "Chọn ảnh đại diện";

                if (ofdl.ShowDialog() == DialogResult.OK)
                {
                    string image_path = ofdl.FileName;
                    Avatar_Image.Image = Image.FromFile(image_path);
                    Avatar_Image.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
