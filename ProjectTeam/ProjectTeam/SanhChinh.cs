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
    public partial class SanhChinh : Form
    {
        public SanhChinh()
        {
            InitializeComponent();
        }

        private void SanhChinh_Load(object sender, EventArgs e)
        {
            // Giả sử ảnh gốc đã được thêm vào nút, bạn cần chỉnh lại kích thước
            Image originalImage = Properties.Resources.home; // Đổi thành tên ảnh của bạn
            Image resizedImage = new Bitmap(originalImage, new Size(20, 20)); // Kích thước mới nhỏ hơn

            Image originalImage1 = Properties.Resources.group; // Đổi thành tên ảnh của bạn
            Image resizedImage1 = new Bitmap(originalImage1, new Size(20, 20)); // Kích thước mới nhỏ hơn

            // Thêm ảnh vào nút
            btn_home.Image = resizedImage;
            btn_group.Image = resizedImage1;
    


        }
    }
}
