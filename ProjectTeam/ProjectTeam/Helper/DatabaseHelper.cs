using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using System.Windows.Forms;

namespace ProjectTeam
{
    internal class DatabaseHelper
    {
        private readonly string connectionString;

        public DatabaseHelper(string host, int port, string database, string user,  string password)
        {
            connectionString = $"Host={host};Port={port};Database={database};Username={user};Password={password}";
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
    }
}
