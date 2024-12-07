using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;

namespace ProjectTeam
{
    internal class DatabaseHelper
    {
        private readonly string connectionString;

        public DatabaseHelper(string host, int port, string database, string user,  string password)
        {
            connectionString = $"Host={host};Port={port};Database={database};Username={user};Password={password}";
        }

        public DatabaseHelper()
        {
            connectionString = "Host=ep-blue-pond-a5kovr60.us-east-2.aws.neon.tech;Database=neondb;Username=neondb_owner;Password=nw43PjxOopbG";
        }


        public bool NguoiDungDangKi(String email, String password) 
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("INSERT INTO users (email, password) VALUES (@Email, @Password)", connection);
                command.Parameters.AddWithValue("Email", email);
                command.Parameters.AddWithValue("password", password);

                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi đăng ký: {ex.Message} ");
                    return false;
                }
            }
        }

        public bool NguoiDungDangNhap(String email, String password)
        {
            using(var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open ();
                var command = new NpgsqlCommand("SELECT COUNT(*) FROM users WHERE email = @Email AND password = @Password", connection);
                command.Parameters.AddWithValue("Email", email);
                command.Parameters.AddWithValue("Password", password);

                var result = (long)command.ExecuteScalar();
                return result > 0;
            }
        }

        public List<Model.Room> LayDanhSachPhong()
        {
            var danhsachphongve = new List<Model.Room>();

            using (var ketnoi = new NpgsqlConnection(connectionString))
            {
                ketnoi.Open ();
                var command = new NpgsqlCommand("SELECT maphong, tenphong, soluongtoida, chuphong, password_room FROM DanhSachPhongVe", ketnoi);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var phong = new Model.Room
                        {
                            MaPhong = reader.GetString(0),
                            TenPhong = reader.GetString(1),
                            SoNguoiThamGia = reader.GetInt32(2),
                            TenChuPhong = reader.GetString(3),
                            MatKhau = reader.IsDBNull(4) ? "công khai" : reader.GetString(4)
                        };
                        danhsachphongve.Add(phong);
                    }
                }
            }
            return danhsachphongve;
        }

        public bool KiemTraTonTaiPhong(string MaPhong)
        {
            string dbMaPhong;
            string truy_van = $"SELECT maphong FROM DanhSachPhongVe WHERE maphong = '{MaPhong}'";
            using (var ketnoi = new NpgsqlConnection(connectionString))
            {
                ketnoi.Open ();
                var command = new NpgsqlCommand(truy_van, ketnoi);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (MaPhong == reader.GetString(0))
                            return true;
                    };
                }
            }     
            return false;
        }

        public bool TaoDanhSachPhong(string MaPhong, string TenPhong, int SoLuong, string TenChu)
        {
            string query = "INSERT INTO danhsachphongve (maphong, tenphong, soluongtoida, chuphong) VALUES (@Maphong, @Tenphong, @Soluong, @Tenchu)";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("Maphong", MaPhong);
                command.Parameters.AddWithValue("Tenphong", TenPhong);
                command.Parameters.AddWithValue("Soluong", SoLuong);
                command.Parameters.AddWithValue("Tenchu", TenChu);

                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                    return false;

                }
            }     
        }

        public bool TaoDanhSachPhongCoMatKhau(string MaPhong, string TenPhong, int SoLuong, string TenChu, string Password_room)
        {
            string query = "INSERT INTO danhsachphongve (maphong, tenphong, sothamgia, chuphong, password_room) VALUES (@Maphong, @Tenphong, @Soluong, @Tenchu, @Password_room)";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("Maphong", MaPhong);
                command.Parameters.AddWithValue("Tenphong", TenPhong);
                command.Parameters.AddWithValue("Soluong", SoLuong);
                command.Parameters.AddWithValue("Tenchu", TenChu);
                command.Parameters.AddWithValue("Password_room", Password_room);

                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                    return false;

                }
            }
        }

    }
}
