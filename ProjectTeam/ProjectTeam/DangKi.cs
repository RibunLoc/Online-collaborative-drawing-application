using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ProjectTeam
{
    public partial class DangKi : Form
    {
        private readonly DatabaseHelper databaseHelper;

        public DangKi()
        {
            InitializeComponent();
            databaseHelper = new DatabaseHelper("ep-blue-pond-a5kovr60-pooler.us-east-2.aws.neon.tech", 5432, "neondb", "ThanhLoc", "4XGEjWJphk9R");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã nhấn vào ảnh đại diện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btn_Anh_Click(object sender, EventArgs e)
        {

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cmbOptions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if(databaseHelper.NguoiDungDangKi(email, password))
            {
                MessageBox.Show("Đăng kí thành công!", "Thông báo");

            }
            else
            {
                MessageBox.Show("Đăng kí thất bại. Email có thể đã tồn tại", "Lỗi");
            }
            
        }
    }
}
