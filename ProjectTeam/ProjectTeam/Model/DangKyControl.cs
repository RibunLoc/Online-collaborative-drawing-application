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
    public partial class DangKyControl : UserControl
    {
        public event EventHandler BackClicked;
        private readonly DatabaseHelper databaseHelper;
        private bool isHide = false;

        public DangKyControl()
        {
            InitializeComponent();
            databaseHelper = new DatabaseHelper("ep-blue-pond-a5kovr60-pooler.us-east-2.aws.neon.tech", 5432, "neondb", "ThanhLoc", "4XGEjWJphk9R");
            Img_Avatar.Resize += pictureBox1_Resize;
        }

        private void DangKyControl_Load(object sender, EventArgs e)
        {
            int radius = 45; // Bán kính của góc bo tròn
            Rectangle rect = new Rectangle(0 ,0, Img_Avatar.Width, Img_Avatar.Height);
            Img_Avatar.Region = new Region(GetRoundedPath(rect , radius)); 

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

            if( string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Xin vui lòng nhập đúng thông tin");

                return;
            }

            if (databaseHelper.NguoiDungDangKi(email, password))
            {
                MessageBox.Show("Đăng kí thành công!", "Thông báo");

            }
            else
            {
                MessageBox.Show("Đăng kí thất bại. Email có thể đã tồn tại", "Lỗi");
            }
        }

        private void btnShowHide_Click(object sender, EventArgs e)
        {
            if (isHide)
            {
                btnShowHide.ImageIndex = 0; // hiện mắt
            }
            else
            {
                btnShowHide.ImageIndex = 1; // đóng mắt
            }
            isHide = !isHide;
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
    }
}
