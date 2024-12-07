using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private readonly DatabaseHelper dbhp;
        private int ChonMaPhong;
        public ThamGiaPhongVe()
        {
            InitializeComponent();      
        }

        private void ThamGiaPhongVe_Load(object sender, EventArgs e)
        {
            DanhSachPhongVe.ItemSelectionChanged += DanhSachPhongVe_ItemSelectionChanged;
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
                    listviewItem.SubItems.Add("1/" + phong.SoNguoiThamGia.ToString());
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
            
        }
    }
}
