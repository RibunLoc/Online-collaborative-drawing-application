namespace ProjectTeam
{
    partial class ThietLap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThietLap));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_ThayAvatar = new RJCodeAdvance.RJControls.RJButton();
            this.button3 = new System.Windows.Forms.Button();
            this.Avatar_Image = new System.Windows.Forms.PictureBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tbNhapLaimatKhau = new System.Windows.Forms.TextBox();
            this.tb_MatKhauCu = new System.Windows.Forms.TextBox();
            this.tb_MatKhauMoi = new System.Windows.Forms.TextBox();
            this.lbl_NhapLaiMatKhau = new System.Windows.Forms.Label();
            this.lblb_MatKhauCu = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.lbl_GioiTinh = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.cmbOptions = new System.Windows.Forms.ComboBox();
            this.lbl_NgaySinh = new System.Windows.Forms.Label();
            this.tb_NgaySinh = new System.Windows.Forms.TextBox();
            this.lbl_SoDienThoai = new System.Windows.Forms.Label();
            this.tb_SoDienThoai = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(224)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmbOptions);
            this.panel1.Controls.Add(this.btn_ThayAvatar);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.Avatar_Image);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.tbNhapLaimatKhau);
            this.panel1.Controls.Add(this.tb_MatKhauCu);
            this.panel1.Controls.Add(this.tb_MatKhauMoi);
            this.panel1.Controls.Add(this.lbl_NhapLaiMatKhau);
            this.panel1.Controls.Add(this.lblb_MatKhauCu);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tb_SoDienThoai);
            this.panel1.Controls.Add(this.tb_NgaySinh);
            this.panel1.Controls.Add(this.tbEmail);
            this.panel1.Controls.Add(this.lbl_SoDienThoai);
            this.panel1.Controls.Add(this.lbl_GioiTinh);
            this.panel1.Controls.Add(this.lbl_NgaySinh);
            this.panel1.Controls.Add(this.txtUsername);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblUsername);
            this.panel1.Location = new System.Drawing.Point(398, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(617, 718);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btn_ThayAvatar
            // 
            this.btn_ThayAvatar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btn_ThayAvatar.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.btn_ThayAvatar.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_ThayAvatar.BorderRadius = 0;
            this.btn_ThayAvatar.BorderSize = 0;
            this.btn_ThayAvatar.FlatAppearance.BorderSize = 0;
            this.btn_ThayAvatar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ThayAvatar.ForeColor = System.Drawing.Color.White;
            this.btn_ThayAvatar.Location = new System.Drawing.Point(216, 195);
            this.btn_ThayAvatar.Name = "btn_ThayAvatar";
            this.btn_ThayAvatar.Size = new System.Drawing.Size(160, 40);
            this.btn_ThayAvatar.TabIndex = 17;
            this.btn_ThayAvatar.Text = "Thay đổi ảnh";
            this.btn_ThayAvatar.TextColor = System.Drawing.Color.White;
            this.btn_ThayAvatar.UseVisualStyleBackColor = false;
            this.btn_ThayAvatar.Click += new System.EventHandler(this.btn_ThayAvatar_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(435, 504);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(33, 34);
            this.button3.TabIndex = 16;
            this.button3.Text = "👁";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnShowHide_Click);
            // 
            // Avatar_Image
            // 
            this.Avatar_Image.Image = ((System.Drawing.Image)(resources.GetObject("Avatar_Image.Image")));
            this.Avatar_Image.Location = new System.Drawing.Point(216, 22);
            this.Avatar_Image.Name = "Avatar_Image";
            this.Avatar_Image.Size = new System.Drawing.Size(160, 160);
            this.Avatar_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Avatar_Image.TabIndex = 13;
            this.Avatar_Image.TabStop = false;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.SteelBlue;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 9.857143F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(323, 651);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(262, 53);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Thay đổi tài khoản";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tbNhapLaimatKhau
            // 
            this.tbNhapLaimatKhau.Location = new System.Drawing.Point(216, 604);
            this.tbNhapLaimatKhau.Name = "tbNhapLaimatKhau";
            this.tbNhapLaimatKhau.Size = new System.Drawing.Size(252, 32);
            this.tbNhapLaimatKhau.TabIndex = 5;
            this.tbNhapLaimatKhau.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // tb_MatKhauCu
            // 
            this.tb_MatKhauCu.Location = new System.Drawing.Point(216, 506);
            this.tb_MatKhauCu.Name = "tb_MatKhauCu";
            this.tb_MatKhauCu.Size = new System.Drawing.Size(220, 32);
            this.tb_MatKhauCu.TabIndex = 5;
            this.tb_MatKhauCu.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // tb_MatKhauMoi
            // 
            this.tb_MatKhauMoi.Location = new System.Drawing.Point(216, 558);
            this.tb_MatKhauMoi.Name = "tb_MatKhauMoi";
            this.tb_MatKhauMoi.Size = new System.Drawing.Size(252, 32);
            this.tb_MatKhauMoi.TabIndex = 5;
            this.tb_MatKhauMoi.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // lbl_NhapLaiMatKhau
            // 
            this.lbl_NhapLaiMatKhau.AutoSize = true;
            this.lbl_NhapLaiMatKhau.Location = new System.Drawing.Point(35, 607);
            this.lbl_NhapLaiMatKhau.Name = "lbl_NhapLaiMatKhau";
            this.lbl_NhapLaiMatKhau.Size = new System.Drawing.Size(175, 24);
            this.lbl_NhapLaiMatKhau.TabIndex = 3;
            this.lbl_NhapLaiMatKhau.Text = "Nhập lại mật khẩu";
            this.lbl_NhapLaiMatKhau.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblb_MatKhauCu
            // 
            this.lblb_MatKhauCu.AutoSize = true;
            this.lblb_MatKhauCu.Location = new System.Drawing.Point(35, 515);
            this.lblb_MatKhauCu.Name = "lblb_MatKhauCu";
            this.lblb_MatKhauCu.Size = new System.Drawing.Size(129, 24);
            this.lblb_MatKhauCu.TabIndex = 3;
            this.lblb_MatKhauCu.Text = "Mật khẩu cũ:";
            this.lblb_MatKhauCu.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 566);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mật khẩu mới";
            this.label3.Click += new System.EventHandler(this.label2_Click);
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(216, 301);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(252, 32);
            this.tbEmail.TabIndex = 5;
            // 
            // lbl_GioiTinh
            // 
            this.lbl_GioiTinh.AutoSize = true;
            this.lbl_GioiTinh.Location = new System.Drawing.Point(35, 363);
            this.lbl_GioiTinh.Name = "lbl_GioiTinh";
            this.lbl_GioiTinh.Size = new System.Drawing.Size(102, 24);
            this.lbl_GioiTinh.TabIndex = 3;
            this.lbl_GioiTinh.Text = "Giới tính: ";
            this.lbl_GioiTinh.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(216, 247);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(252, 32);
            this.txtUsername.TabIndex = 4;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 301);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Email";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.Location = new System.Drawing.Point(35, 247);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(136, 31);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Tên tài khoản";
            this.lblUsername.Click += new System.EventHandler(this.lblUsername_Click);
            // 
            // cmbOptions
            // 
            this.cmbOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOptions.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cmbOptions.FormattingEnabled = true;
            this.cmbOptions.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cmbOptions.Location = new System.Drawing.Point(216, 360);
            this.cmbOptions.Name = "cmbOptions";
            this.cmbOptions.Size = new System.Drawing.Size(252, 32);
            this.cmbOptions.TabIndex = 18;
            // 
            // lbl_NgaySinh
            // 
            this.lbl_NgaySinh.AutoSize = true;
            this.lbl_NgaySinh.Location = new System.Drawing.Point(35, 416);
            this.lbl_NgaySinh.Name = "lbl_NgaySinh";
            this.lbl_NgaySinh.Size = new System.Drawing.Size(114, 24);
            this.lbl_NgaySinh.TabIndex = 3;
            this.lbl_NgaySinh.Text = "Ngày sinh: ";
            this.lbl_NgaySinh.Click += new System.EventHandler(this.label2_Click);
            // 
            // tb_NgaySinh
            // 
            this.tb_NgaySinh.Location = new System.Drawing.Point(216, 410);
            this.tb_NgaySinh.Name = "tb_NgaySinh";
            this.tb_NgaySinh.Size = new System.Drawing.Size(252, 32);
            this.tb_NgaySinh.TabIndex = 5;
            // 
            // lbl_SoDienThoai
            // 
            this.lbl_SoDienThoai.AutoSize = true;
            this.lbl_SoDienThoai.Location = new System.Drawing.Point(35, 463);
            this.lbl_SoDienThoai.Name = "lbl_SoDienThoai";
            this.lbl_SoDienThoai.Size = new System.Drawing.Size(140, 24);
            this.lbl_SoDienThoai.TabIndex = 3;
            this.lbl_SoDienThoai.Text = "Số điện thoại:";
            this.lbl_SoDienThoai.Click += new System.EventHandler(this.label2_Click);
            // 
            // tb_SoDienThoai
            // 
            this.tb_SoDienThoai.Location = new System.Drawing.Point(216, 457);
            this.tb_SoDienThoai.Name = "tb_SoDienThoai";
            this.tb_SoDienThoai.Size = new System.Drawing.Size(252, 32);
            this.tb_SoDienThoai.TabIndex = 5;
            // 
            // ThietLap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(168F, 168F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.ClientSize = new System.Drawing.Size(1412, 840);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Name = "ThietLap";
            this.Text = "QuenMatKhau";
            this.Load += new System.EventHandler(this.ThietLap_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar_Image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.PictureBox Avatar_Image;
        private System.Windows.Forms.TextBox tbNhapLaimatKhau;
        private System.Windows.Forms.TextBox tb_MatKhauMoi;
        private System.Windows.Forms.Label lbl_NhapLaiMatKhau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_GioiTinh;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox tb_MatKhauCu;
        private System.Windows.Forms.Label lblb_MatKhauCu;
        private RJCodeAdvance.RJControls.RJButton btn_ThayAvatar;
        private System.Windows.Forms.ComboBox cmbOptions;
        private System.Windows.Forms.TextBox tb_SoDienThoai;
        private System.Windows.Forms.TextBox tb_NgaySinh;
        private System.Windows.Forms.Label lbl_SoDienThoai;
        private System.Windows.Forms.Label lbl_NgaySinh;
    }
}