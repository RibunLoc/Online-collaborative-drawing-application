using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using ProjectTeam.Model;
using RJCodeAdvance.RJControls;


namespace ProjectTeam
{
    public partial class ThamGiaPhongVe : Form
    {
        private int ChonMaPhong;
        private bool CoMatKhauPhong = false;
        private SanhChinh sanhChinh;
        private user_info user;
        public event Action<string> YeuCauMoForm;

        public ThamGiaPhongVe()
        {
            sanhChinh = new SanhChinh();
            InitializeComponent();      
        }

        public ThamGiaPhongVe(user_info truyenUser)
        {
            sanhChinh = new SanhChinh();
            InitializeComponent();

            user = new user_info();
            user = truyenUser; // thông tin xác định người dùng

        }

        private void someConditionMet()
        {
            YeuCauMoForm?.Invoke("OpenDraw");
        }

        private void ThamGiaPhongVe_Load(object sender, EventArgs e)
        {
            DanhSachPhongVe.ItemSelectionChanged += DanhSachPhongVe_ItemSelectionChanged;
            KhoiTaoNutEye();
            TaiDanhSachDongBo();
        }

        private async void TaiDanhSachDongBo()
        {
            try
            {
                Progressbar.Visible = true;
                Progressbar.Minimum = 0;
                Progressbar.Maximum = 100;
                Progressbar.Value = 0;

                lbl_DangTai.Visible = true;

                //chạy tải dữ liệu không đồng bộ

                var danhsachphong = new List<Room>();
                var dbHelper = new DatabaseHelper("ep-blue-pond-a5kovr60-pooler.us-east-2.aws.neon.tech", 5432, "neondb", "ThanhLoc", "4XGEjWJphk9R");

                await Task.Run(() =>
                {
                    var rooms = dbHelper.LayDanhSachPhong();
                    int tong = rooms.Count;
                    int count = 0;

                    foreach (var phong in rooms)
                    {
                        danhsachphong.Add(phong);
                        count++;

                        int progress = (count * 100) / tong;
                        Invoke(new Action(() =>
                        {
                            Progressbar.Value = progress;

                        }));
                        Task.Delay(100).Wait();
                    }
                });
                

                DanhSachPhongVe.Items.Clear();
                foreach(var phong in danhsachphong)
                {
                    var listviewItem = new ListViewItem(phong.MaPhong);
                    listviewItem.SubItems.Add(phong.TenPhong);
                    listviewItem.SubItems.Add(phong.SoNguoiThamGia.ToString() + "/" + phong.SoLuongToiDa.ToString());
                    listviewItem.SubItems.Add(phong.TenChuPhong);

                    if (phong.MatKhau != "công khai")
                        listviewItem.SubItems.Add("riêng tư");
                    else
                        listviewItem.SubItems.Add(phong.MatKhau);

                    DanhSachPhongVe.Items.Add(listviewItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Progressbar.Visible = false;
                lbl_DangTai.Visible = false;
            }
        }

        private void DanhSachPhongVe_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
           if(e.IsSelected)
            {
                ChonMaPhong = int.Parse(e.Item.Text);
                TbNhapMaPhong.Texts = ChonMaPhong.ToString();

                string MatKhau = e.Item.SubItems[4].Text;
                if(MatKhau != "riêng tư")
                {
                    lbl_NhapMatKhau.Visible = false;
                    tb_NhapMatKhau.Visible = false;
                    iconbtn_Eye.Visible = false;
                    tb_NhapMatKhau.Texts = string.Empty;
                    CoMatKhauPhong = false;
                }    
                else
                {
                    lbl_NhapMatKhau.Visible = true;
                    tb_NhapMatKhau.Visible = true;
                    iconbtn_Eye.Visible = true;
                    CoMatKhauPhong = true;
                }    
            }
        }

        private void ThietKeDanhSachPhong()
        {
          
        }

        private void TieuDeMaCode_Click(object sender, EventArgs e)
        {

        }

        private void DanhSachPhongVe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            DanhSachPhongVe.Items.Clear();
            TaiDanhSachDongBo();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maphongtimkiem = TbNhapMaPhong.Texts.Trim();

            foreach(ListViewItem item in DanhSachPhongVe.Items)
            {
                if (maphongtimkiem == item.Text)
                {
                    //chọn mục đó
                    item.Selected = true;
                    item.Focused = true;

                    //cuộn tới mục đó
                    item.EnsureVisible();
                    return;
                }
            }
        }



        private void btnThamGia_Click(object sender, EventArgs e)
        {
            var databaseHelper = new DatabaseHelper();
            string maphong = TbNhapMaPhong.Texts.Trim();
            GlobalVariables.Maphong = maphong;
            bool isthamgia = false;
            string matkhau = tb_NhapMatKhau.Texts.Trim();
            Cursor.Current = Cursors.WaitCursor;

            if(CoMatKhauPhong)
            {
                if (string.IsNullOrEmpty(tb_NhapMatKhau.Texts.Trim()))
                {
                    MessageBox.Show("Lỗi chưa nhập mật khẩu phòng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Bước kiểm tra mật khẩu
                if (!databaseHelper.KiemTraMatKhau(maphong, matkhau))
                {
                    MessageBox.Show("Mật khẩu không chính xác!");
                    return;
                }   
            }

            try
            {
                if (databaseHelper.KiemTraSoLuongThamGia(maphong))
                {
                    isthamgia = databaseHelper.ThemThanhVienPhongVe(maphong, user.name, user.user_id, "member");
                    if (isthamgia)
                    {
                        someConditionMet();
                        MessageBox.Show("Tham gia thành công!");
                    }
                    else
                        MessageBox.Show("Lỗi khi tham gia phòng!");
                }
                else
                {
                    MessageBox.Show("Phòng đã đầy!");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }finally
            {
                Cursor.Current = Cursors.Default;
            }

            

        }

        private void KhoiTaoNutEye()
        {
            iconbtn_Eye.IconChar = FontAwesome.Sharp.IconChar.EyeLowVision;
        }
        private void iconbtn_Eye_Click(object sender, EventArgs e)
        {
            if(iconbtn_Eye.IconChar == FontAwesome.Sharp.IconChar.EyeLowVision)
            {
                iconbtn_Eye.IconChar = FontAwesome.Sharp.IconChar.Eye;
                tb_NhapMatKhau.PasswordChar = false;
            }
            else
            {
                iconbtn_Eye.IconChar = FontAwesome.Sharp.IconChar.EyeLowVision;
                tb_NhapMatKhau.PasswordChar = true;
            }
        }
    } 
}
