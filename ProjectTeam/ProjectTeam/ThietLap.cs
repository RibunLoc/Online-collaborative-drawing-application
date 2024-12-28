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


           if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(tbEmail.Text) || string.IsNullOrEmpty(cmbOptions.Text) || 
                string.IsNullOrEmpty(tb_NgaySinh.Text) || string.IsNullOrEmpty(tb_SoDienThoai.Text) || string.IsNullOrEmpty(tb_MatKhauCu.Text) ||
                string.IsNullOrEmpty(tb_MatKhauMoi.Text) || string.IsNullOrEmpty(tbNhapLaimatKhau.Text))
           {
                MessageBox.Show("Xin vui lòng nhập đầy đủ thông tin", "Thông báo");
                return;
           }

         
           
            string username = txtUsername.Text;
            string email = tbEmail.Text;
            string gioi_tinh = cmbOptions.Text;
            string ngay_sinh = tb_NgaySinh.Text;
            string sdt = tb_SoDienThoai.Text;
            string password = tb_MatKhauMoi.Text;
            string passwordOLD = tb_MatKhauCu.Text;


            string passwordHash256 = HamMaHoa.HamBamSha256(password);
            string passwordOldHash256 = HamMaHoa.HamBamSha256(passwordOLD);

            //kiem tra mat khau de thay doi tai khoan
            if (!dbhp.NguoiDungDangNhap(user_Info.email, passwordOldHash256))
            {
                MessageBox.Show("Mật khẩu không chính xác để thay đổi thông tin tài khoàn!", "Thông báo");
                tb_MatKhauCu.Clear();
                tb_MatKhauMoi.Clear();
                tbNhapLaimatKhau.Clear();
                return;
            }

            //kiem tra xac nhan lại mat khau
            if (!password.Equals(tbNhapLaimatKhau.Text.Trim()))
            {
                MessageBox.Show("Mật khẩu xác nhận không trùng với mật khẩu mới!", "Thông báo");
                tb_MatKhauMoi.Clear();
                tbNhapLaimatKhau.Clear();
                return;
            }

            int id = user_Info.id;
            bool CoEmail = true;
            if (user_Info.email.Equals(tbEmail.Text.Trim()))
            {
                CoEmail = false;
            }

           if (!dbhp.CapNhatThongTinNguoiDung(id, username, email, CoEmail, passwordHash256, sdt, gioi_tinh, ngay_sinh))
           {
               MessageBox.Show("Email này đã tồn tại xin vui lòng điền một tài khoản email đăng nhập khác!", "Thông báo");
               return;
           }
           else
           {
                var result = MessageBox.Show("Thay đổi thông tin tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    //
                } 
                user_Info = dbhp.LayThongTinNguoiDung(id);
                    
           } 
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
