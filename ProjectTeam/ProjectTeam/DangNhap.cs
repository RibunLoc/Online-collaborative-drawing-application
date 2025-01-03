﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Npgsql;
using ProjectTeam.Model;


namespace ProjectTeam
{
    public partial class DangNhap : Form
    {
        private readonly DatabaseHelper databaseHelper;
        private bool isClicked = false; // hiện password
        public string username { get; set; }

        public DangNhap()
        {
            InitializeComponent();
            databaseHelper = new DatabaseHelper("ep-blue-pond-a5kovr60-pooler.us-east-2.aws.neon.tech", 5432, "neondb", "ThanhLoc", "4XGEjWJphk9R");
            
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            KhoiTaoHopNhap();
           
            
        }

        private void KhoiTaoHopNhap()
        {
            //txtUsername
            txtUsername.Text = "Nhập email đăng nhập...";
            txtUsername.ForeColor = Color.Gray;

            txtUsername.Enter += txtUsername_Enter;
            txtUsername.Leave += TxtUsername_Leave;

            //txtPassword
            txtPassword.Text = "Nhập mật khẩu...";
            txtPassword.ForeColor = Color.Gray;

            txtPassword.Enter += txtPassword_Enter;
            txtPassword.Leave += txtPassword_Leave;
            txtPassword.PasswordChar = '*'; // ẩn văn bản



        }


        private void txtUsername_TextChanged_1(object sender, EventArgs e)
        {

        }

        // cấu hình hiển thị ô textbox username 
        private void TxtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.Text = "Nhập email đăng nhập...";
                txtUsername.ForeColor = Color.Gray;
                
            }
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Nhập email đăng nhập...")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.Black;
                
            }
        }
        //

        // cấu hình hiển thị ô textbox cho password
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if(txtPassword.Text == "Nhập mật khẩu...")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                
            }    
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = "Nhập mật khẩu...";
                txtPassword.ForeColor = Color.Gray; // Hiển thị màu chữ mặc định
               
            }
        }

        private void btnShowHide_Click(object sender, EventArgs e) // ẩn hay hiện mật khẩu
        {
            isClicked = !isClicked;
            if (!isClicked)
            {
                txtPassword.PasswordChar = '*'; // ẩn văn bản
                btnShowHide.ImageIndex = 1; // Đặt mắt đóng

            }
            else
            {
                txtPassword.PasswordChar = '\0'; // hiển thị văn bản gốc
                btnShowHide.ImageIndex = 0; // Đặt mắt mở
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Controls.Clear();

            DangKyControl dangKyControl = new DangKyControl();
            dangKyControl.Dock = DockStyle.Fill;

            dangKyControl.BackClicked += DangKyControl_BackClickced;

            this.Controls.Add(dangKyControl);

        }

        private void DangKyControl_BackClickced(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            KhoiTaoHopNhap();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string email = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string checkUsername = "Nhập email đăng nhập...";
            string checkPassword = "Nhập mật khẩu...";

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || email.Equals(checkUsername) || password.Equals(checkPassword))
            {
                MessageBox.Show("Xin vui lòng điền đầy đủ thông tin đăng nhập!", "Thông báo");
                return;
            }

            string HashPassword = HamMaHoa.HamBamSha256(password);
            try
            {
                Cursor = Cursors.WaitCursor;
                if (databaseHelper.NguoiDungDangNhap(email, HashPassword))
                {
                    username = email;
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo");
                    this.DialogResult = DialogResult.OK;
                    Cursor = Cursors.Default;
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại. Kiểm tra lại thông tin.", "Lõi");
                    Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {

            }
            finally 
            {
                Cursor.Current = Cursors.Default;
            }
           
        }

        private void PanelPassword_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelUsername_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EnterKeyLogin(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
    }
}
