using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;
using ProjectTeam.Model;

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
                var command = new NpgsqlCommand("SELECT maphong, tenphong, soluongtoida, chuphong, password_room, soluongthamgia FROM danhsachphongve", ketnoi);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var phong = new Model.Room
                        {
                            MaPhong = reader.GetString(0),
                            TenPhong = reader.GetString(1),
                            SoLuongToiDa = reader.GetInt32(2),
                            TenChuPhong = reader.GetString(3),
                            MatKhau = reader.IsDBNull(4) ? "công khai" : reader.GetString(4),
                            SoNguoiThamGia = reader.GetInt32(5)
                        };
                        danhsachphongve.Add(phong);
                    }
                }
            }
            return danhsachphongve;
        }

        public bool KiemTraTonTaiPhong(string MaPhong)
        {
            string truy_van = $"SELECT maphong FROM danhsachphongve WHERE maphong = '{MaPhong}'";
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

        public bool TaoDanhSachPhong(string MaPhong, string TenPhong, int SoLuongToiDa, string TenChu)
        {
            string query = "INSERT INTO danhsachphongve (maphong, tenphong, soluongtoida, chuphong) VALUES (@Maphong, @Tenphong, @Soluongtoida, @Tenchu)";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("Maphong", MaPhong);
                command.Parameters.AddWithValue("Tenphong", TenPhong);
                command.Parameters.AddWithValue("Soluongtoida", SoLuongToiDa);
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

        public bool TaoDanhSachPhongCoMatKhau(string MaPhong, string TenPhong, int SoLuongToiDa, string TenChu, string Password_room)
        {
            string query = "INSERT INTO danhsachphongve (maphong, tenphong, soluongtoida, chuphong, password_room) VALUES (@Maphong, @Tenphong, @Soluongtoida, @Tenchu, @Password_room)";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("Maphong", MaPhong);
                command.Parameters.AddWithValue("Tenphong", TenPhong);
                command.Parameters.AddWithValue("Soluongtoida", SoLuongToiDa);
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

        public bool ThemThanhVienPhongVe(string MaPhong, string ThanhVien, int User_id, string VaiTro)
        {
            string query = "INSERT INTO thanhvien (maphong, thanhvien, vaitro, id_member) VALUES (@MaPhong, @ThanhVien, @VaiTro, @User_id)";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("MaPhong", MaPhong);
                command.Parameters.AddWithValue("ThanhVien", ThanhVien);   
                command.Parameters.AddWithValue("VaiTro", VaiTro);
                command.Parameters.AddWithValue("User_id", User_id);

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

        public bool KiemTraSoLuongThamGia(string MaPhong)
        {
            string query = "SELECT soluongthamgia, soluongtoida FROM danhsachphongve WHERE maphong = @MaPhong";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("MaPhong", MaPhong);
                    try
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (reader.GetInt32(0) < reader.GetInt32(1))
                                    return true;
                                else
                                    return false;
                            }
                            else
                            {
                                throw new Exception("Không tìm thấy số lượng!");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");    
                    }
                }
            }
            return false;
        }

        public bool KiemTraMatKhau(string MaPhong, string MatKhau)
        {
            
            string storedHasedPassword = null;
            //truy vấn cơ sở dữ liệu để lấy mật khẩu đã băm
            using (var connection = new NpgsqlConnection(connectionString))
            {
                string query = "SELECT password_room FROM danhsachphongve WHERE maphong = @MaPhong";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("MaPhong", MaPhong);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            storedHasedPassword = reader["password_room"].ToString();
                        }
                        reader.Close();
                    }
                }
            }

            if (storedHasedPassword == null) return false;

            string hashedInputPassword = HamMaHoa.HamBamSha256(MatKhau);

            return storedHasedPassword == hashedInputPassword;
        }

        public user_info LayThongTinNguoiDung(int id)
        {
            var nguoidung = new user_info();
            string query = "SELECT userinfo.id, tennguoidung, sdt, user_id, gioi_tinh, ngay_sinh, email FROM userinfo inner join users on userinfo.id = users.id  WHERE userinfo.id = @id";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    try
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nguoidung.id = reader.GetInt32(0);
                                nguoidung.name = reader.GetString(1);
                                nguoidung.sdt = reader.GetString(2);
                                nguoidung.user_id = reader.GetInt32(3);
                                nguoidung.gioitinh = reader.GetString(4);
                                nguoidung.ngaysinh = reader.GetString(5);
                                nguoidung.email = reader.GetString(6);
                            }
                            else
                            {
                                throw new Exception("Không tìm thấy người dùng ID đã cung cấp.");
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    nguoidung.id = id;

                }         
            }
            return nguoidung;
        }

        public user_info LayThongTinNguoiDung(string TenDangNhap)
        {
            var nguoidung = new user_info();
            string query = "SELECT userinfo.tennguoidung, userinfo.sdt, userinfo.user_id, userinfo.id, email, gioi_tinh, ngay_sinh  FROM userinfo INNER JOIN users ON userinfo.id = users.id WHERE users.email = @TenDangNhap";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("TenDangNhap", TenDangNhap);
                    try
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nguoidung.name = reader.GetString(0);
                                nguoidung.sdt = reader.GetString(1);
                                nguoidung.user_id = reader.GetInt32(2);
                                nguoidung.id = reader.GetInt32(3);
                                nguoidung.email = reader.GetString(4);
                                nguoidung.gioitinh = reader.GetString(5);
                                nguoidung.ngaysinh = reader.GetString(6);
                            }
                            else
                            {
                                throw new Exception("Không tìm thấy người dùng ID đã cung cấp.");
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                  
                }
            }
            return nguoidung;
        }

        public bool XoaMotThanhVien(int user_id)
        {
            string query = "DELETE FROM thanhvien WHERE id_member = @user_id";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("user_id", user_id);
                    int rowAffected = command.ExecuteNonQuery();
                    if (rowAffected > 0)
                        return true;
                }
            }
            return false;
        }

        public int LayID(string tendangnhap)
        {
            int id = -1; // -1 là lỗi
            string query = "SELECT id FROM users WHERE email = @tendangnhap";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("tendangnhap", tendangnhap);
                    try
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                id = reader.GetInt32(0);
                                return id;
                            }
                        }
                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show($"Lỗi : {ex.Message}");
                        return -1;
                    }
                    
                }
            }
            return id;
        }

        public bool DangKiThongTinNguoiDung(int id, string tennguoidung, string sdt, string gioi_tinh, string ngay_sinh)
        {
            string query = "INSERT INTO userinfo (id, tennguoidung, sdt, gioi_tinh, ngay_sinh) " +
                "VALUES (@id, @tennguoidung, @sdt, @gioi_tinh, @ngay_sinh)";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("id",id);
                    command.Parameters.AddWithValue("tennguoidung", tennguoidung);
                    command.Parameters.AddWithValue("sdt", sdt);
                    command.Parameters.AddWithValue("gioi_tinh", gioi_tinh);
                    command.Parameters.AddWithValue("ngay_sinh", ngay_sinh);

                    try
                    {
                        command.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                    
                }    
            }    

        }






    }

}
