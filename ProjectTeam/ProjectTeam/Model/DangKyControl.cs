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
using ProjectTeam.Model;

namespace ProjectTeam
{
    public partial class DangKyControl : UserControl
    {
        public event EventHandler BackClicked;
        private readonly DatabaseHelper databaseHelper;
        private bool isHide = false;
        private user_info user_Info;
        public DangKyControl()
        {
            InitializeComponent();
            databaseHelper = new DatabaseHelper();
            Img_Avatar.Resize += pictureBox1_Resize;
        }

        private void DangKyControl_Load(object sender, EventArgs e)
        {
            int radius = 45; // Bán kính của góc bo tròn
            Rectangle rect = new Rectangle(0 ,0, Img_Avatar.Width, Img_Avatar.Height);
            Img_Avatar.Region = new Region(GetRoundedPath(rect , radius)); 
            user_Info = new user_info();
            txtPassword.PasswordChar = '*';
            txtPasswordAuth.PasswordChar = '*';

        }

        public GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            // Thêm các góc bo tròn
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90); // Top-left
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90); // Top-right
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90); // Bottom-right
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90); // Bottom-left

            path.CloseAllFigures(); // Đóng đường path
            return path;
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            int radius = 45;
            Rectangle rect = new Rectangle(0, 0, Img_Avatar.Width, Img_Avatar.Height);
            Img_Avatar.Region = new Region(GetRoundedPath(rect, radius));
        }


        private void btn_back_Click(object sender, EventArgs e)
        {
            BackClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string HashPassword = HamMaHoa.HamBamSha256(password);

            if( string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Xin vui lòng nhập đúng thông tin");
                return;
            }else if (!password.Equals(txtPasswordAuth.Text.Trim()))
            {
                MessageBox.Show("Xác nhận mật khẩu không trùng với mật khẩu!", "Thông báo");
                return;
            }    

            

            if (databaseHelper.NguoiDungDangKi(email, HashPassword))
            {
                
                // ghi nhận lên cơ sở dữ liệu
                user_Info.email = email;
                user_Info.id = databaseHelper.LayID(email);
                if(user_Info.id == -1)
                {
                    MessageBox.Show("Lỗi lấy id đăng nhập");
                    return;
                }
                string tentaikhoan = txtUsername.Text.Trim();
                string sdt = txtSoDienThoai.Text.Trim();
                string gioitinh = cmbOptions.Text.Trim();
                string ngaysinh = txtNgaySinh.Text.Trim();

                if (databaseHelper.DangKiThongTinNguoiDung(user_Info.id, tentaikhoan, sdt, gioitinh, ngaysinh))
                {
                    DialogResult result = MessageBox.Show("Đăng kí tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        BackClicked?.Invoke(this, EventArgs.Empty);
                    }
                }



            }
            else
            {
                MessageBox.Show("Đăng kí thất bại. Email có thể đã tồn tại", "Lỗi");
            }
        }

        private void btnShowHide_Click(object sender, EventArgs e)
        {
            isHide = !isHide;
            if (isHide)
            {
                btnShowHide.ImageIndex = 0; // hiện mắt
                txtPasswordAuth.PasswordChar = default;
                txtPassword.PasswordChar = default;
            }
            else
            {
                btnShowHide.ImageIndex = 1; // đóng mắt
                txtPassword.PasswordChar = '*';
                txtPasswordAuth.PasswordChar = '*';
            }
            
        }

        private void btn_Anh_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd = new OpenFileDialog())
            {
                //Thiết lập chỉ cho phép các bộ ảnh
                ofd.Filter = "Image Files|*.jpg;*.png";
                ofd.Title = "Chọn ảnh đại diện";

                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    string img_path = ofd.FileName;

                    Img_Avatar.Image = Image.FromFile(img_path);

                    Img_Avatar.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private void Img_Avatar_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }
    }
}
