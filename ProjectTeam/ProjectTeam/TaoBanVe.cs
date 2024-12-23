﻿using MetroFramework.Controls;
using ProjectTeam.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace ProjectTeam
{
    public partial class TaoBanVe : Form
    {
        private DatabaseHelper dbhp;
        private HamMaHoa mahoa = new HamMaHoa();
        private user_info user;
        public event Action<string> YeuCauMoForm;
        public TaoBanVe( )
        {
            InitializeComponent();
        }

        public TaoBanVe(user_info TruyenUser)
        {
            InitializeComponent();
            user = new user_info();
            user = TruyenUser;
        }

        private void SomeConditionMet()
        {
            YeuCauMoForm?.Invoke("OpenDraw");
        }

        private void TaoBanVe_Load(object sender, EventArgs e)
        {
            Bo_Goc_Panel();
            Bo_goc_Panel_TieuDe();
            Dieu_Chinh_btn_TaoMa();
            
        }

        private void Bo_Goc_Panel()
        {
            int radius = 100;
            System.Drawing.Drawing2D.GraphicsPath path = new GraphicsPath();
            path.StartFigure();

            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
            path.AddArc(new Rectangle(panel_GiaoDien.Width - radius, 0, radius, radius), 270, 90);
            path.AddArc(new Rectangle(panel_GiaoDien.Width - radius, panel_GiaoDien.Height - radius, radius, radius), 0, 90);
            path.AddArc(new Rectangle(0, panel_GiaoDien.Height - radius, radius, radius), 90, 90);
            path.CloseFigure();

            panel_GiaoDien.Region = new Region(path);
        }

        private void Bo_goc_Panel_TieuDe()
        {
            int radius = 30;
            System.Drawing.Drawing2D.GraphicsPath path = new GraphicsPath();
            path.StartFigure();

            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
            path.AddArc(new Rectangle(panel_TieuDe.Width - radius, 0, radius, radius), 270, 90);
            path.AddArc(new Rectangle(panel_TieuDe.Width - radius, panel_TieuDe.Height - radius, radius, radius), 0, 90);
            path.AddArc(new Rectangle(0, panel_TieuDe.Height - radius, radius, radius), 90, 90);

            panel_TieuDe.Region = new Region(path);
        }

        private void Dieu_Chinh_btn_TaoMa()
        {
            btn_random.Font = new Font("Segoe UI", 14, FontStyle.Regular);
        }

        private void check_RiengTu_CheckedChanged(object sender, EventArgs e)
        {
            if(check_RiengTu.Checked)
            {
                if (check_CongKhai.Checked) check_CongKhai.Checked = false;

                lbl_NhapMatkhau.Visible = true;
                tb_NhapMatKhau.Visible = true;
            }


        }

        private void check_CongKhai_CheckedChanged(object sender, EventArgs e)
        {
            if(check_CongKhai.Checked)
            {
                if (check_RiengTu.Checked) check_RiengTu.Checked = false;

                lbl_NhapMatkhau.Visible = false;
                tb_NhapMatKhau.Visible = false;
            }
                
        }

        private void btn_random_Click(object sender, EventArgs e)
        {
            
            RandomCode random = new RandomCode();
            string code = random.TaoMaCode(5);
            tb_NhapMaPhong.Texts = code;
        }


        private void btn_TaoPhong_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_NhapMaPhong.Texts.Trim()) || string.IsNullOrEmpty(tb_NhapTenPhong.Texts.Trim()) || string.IsNullOrEmpty(combobox_SoLuong.Texts.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông tin phòng mã phòng, tên phòng hoặc chọn số người tham gia!", "Xin vui lòng nhập đầy đủ thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(check_RiengTu.Checked)
                if(string.IsNullOrEmpty(tb_NhapMatKhau.Texts.Trim()))
                {
                    MessageBox.Show("Bạn chưa nhập mật khẩu", "Xin vui lòng nhập đầy đủ thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //Khởi tạo databse
                var databaseHelper = new DatabaseHelper();
                bool check = false;
                string maphongcheck = tb_NhapMaPhong.Texts.Trim();
                string matkhau = "";
                string maphong = tb_NhapMaPhong.Texts.Trim();
                GlobalVariables.Maphong = maphong;
                string tenphong = tb_NhapTenPhong.Texts.Trim();
                int soluong = int.Parse(combobox_SoLuong.Texts.Trim());
                user_info user = new user_info();

                if (check_RiengTu.Checked)
                    matkhau = tb_NhapMatKhau.Texts.Trim();
                

                check = databaseHelper.KiemTraTonTaiPhong(maphongcheck);

                if (check)
                {
                    MessageBox.Show("Mã phòng đã tồn tại xin vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }  
                else
                {
                    // Người tạo phòng có vai trò là admin
                    user = databaseHelper.LayThongTinNguoiDung(1);

                    if (user == null || string.IsNullOrEmpty(user.name))
                    {
                        MessageBox.Show("Không tìm thấy thông tin người dùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // tạo truy vấn lưu vào csdl
                    if (check_RiengTu.Checked)
                    {
                        string MaHoaMatKhau = HamMaHoa.HamBamSha256(matkhau);
                        check = databaseHelper.TaoDanhSachPhongCoMatKhau(maphong, tenphong, soluong, user.name, MaHoaMatKhau);
                    }     
                    else
                        check = databaseHelper.TaoDanhSachPhong(maphong, tenphong, soluong, user.name);
 
                    
                } 

                if (check)
                {
                    // Thêm người dùng đó vào phòng vẽ
                    bool IsThemChua = false;
                    string vaitro = "admin";
                    IsThemChua = databaseHelper.ThemThanhVienPhongVe(maphong, user.name, user.user_id, vaitro);
                    if (IsThemChua)
                    {
                        MessageBox.Show("Tạo thành công!");
                        SomeConditionMet();
                    }
                    else
                        MessageBox.Show("Lỗi tạo phòng!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            
        }
    }


}
