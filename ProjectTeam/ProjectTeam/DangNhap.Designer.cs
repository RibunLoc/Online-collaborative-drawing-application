namespace ProjectTeam
{
    partial class DangNhap
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangNhap));
            this.lblTitle = new System.Windows.Forms.Label();
            this.Panel_login = new System.Windows.Forms.Panel();
            this.PanelPassword = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnShowHide = new System.Windows.Forms.Button();
            this.pasword = new System.Windows.Forms.ImageList(this.components);
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.PanelUsername = new System.Windows.Forms.Panel();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.linkForgotPassword = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.img_title = new System.Windows.Forms.PictureBox();
            this.btnLogin = new ProjectTeam.Controls.RJButton();
            this.Panel_login.SuspendLayout();
            this.PanelPassword.SuspendLayout();
            this.PanelUsername.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_title)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15.85714F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(71, 48);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(628, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ỨNG DỤNG VẼ CHUNG QUA MẠNG";
            // 
            // Panel_login
            // 
            this.Panel_login.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_login.AutoSize = true;
            this.Panel_login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(224)))));
            this.Panel_login.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_login.Controls.Add(this.btnLogin);
            this.Panel_login.Controls.Add(this.PanelPassword);
            this.Panel_login.Controls.Add(this.linkLabel2);
            this.Panel_login.Controls.Add(this.PanelUsername);
            this.Panel_login.Controls.Add(this.linkForgotPassword);
            this.Panel_login.Controls.Add(this.label2);
            this.Panel_login.Controls.Add(this.lblUsername);
            this.Panel_login.Controls.Add(this.img_title);
            this.Panel_login.Controls.Add(this.lblTitle);
            this.Panel_login.Location = new System.Drawing.Point(357, 53);
            this.Panel_login.Name = "Panel_login";
            this.Panel_login.Size = new System.Drawing.Size(765, 775);
            this.Panel_login.TabIndex = 1;
            // 
            // PanelPassword
            // 
            this.PanelPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelPassword.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PanelPassword.Controls.Add(this.txtPassword);
            this.PanelPassword.Controls.Add(this.btnShowHide);
            this.PanelPassword.Location = new System.Drawing.Point(200, 472);
            this.PanelPassword.Name = "PanelPassword";
            this.PanelPassword.Size = new System.Drawing.Size(488, 60);
            this.PanelPassword.TabIndex = 6;
            this.PanelPassword.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelPassword_Paint);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Arial", 11.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtPassword.Location = new System.Drawing.Point(15, 15);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(407, 30);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtUsername_TextChanged_1);
            // 
            // btnShowHide
            // 
            this.btnShowHide.AccessibleRole = System.Windows.Forms.AccessibleRole.Sound;
            this.btnShowHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowHide.AutoSize = true;
            this.btnShowHide.BackColor = System.Drawing.Color.Transparent;
            this.btnShowHide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShowHide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowHide.FlatAppearance.BorderSize = 0;
            this.btnShowHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowHide.Font = new System.Drawing.Font("Segoe UI", 14.14286F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowHide.ImageIndex = 0;
            this.btnShowHide.ImageList = this.pasword;
            this.btnShowHide.Location = new System.Drawing.Point(438, 13);
            this.btnShowHide.Name = "btnShowHide";
            this.btnShowHide.Size = new System.Drawing.Size(45, 35);
            this.btnShowHide.TabIndex = 9;
            this.btnShowHide.UseVisualStyleBackColor = false;
            this.btnShowHide.Click += new System.EventHandler(this.btnShowHide_Click);
            // 
            // pasword
            // 
            this.pasword.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("pasword.ImageStream")));
            this.pasword.TransparentColor = System.Drawing.Color.Transparent;
            this.pasword.Images.SetKeyName(0, "eye_9070512.png");
            this.pasword.Images.SetKeyName(1, "hide_9070514.png");
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Segoe UI", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.linkLabel2.Location = new System.Drawing.Point(194, 546);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(96, 32);
            this.linkLabel2.TabIndex = 8;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Đăng kí";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // PanelUsername
            // 
            this.PanelUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelUsername.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PanelUsername.Controls.Add(this.txtUsername);
            this.PanelUsername.Location = new System.Drawing.Point(200, 389);
            this.PanelUsername.Name = "PanelUsername";
            this.PanelUsername.Padding = new System.Windows.Forms.Padding(16);
            this.PanelUsername.Size = new System.Drawing.Size(491, 60);
            this.PanelUsername.TabIndex = 6;
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Arial", 11.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtUsername.Location = new System.Drawing.Point(15, 15);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(470, 30);
            this.txtUsername.TabIndex = 5;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged_1);
            // 
            // linkForgotPassword
            // 
            this.linkForgotPassword.ActiveLinkColor = System.Drawing.Color.Red;
            this.linkForgotPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkForgotPassword.AutoSize = true;
            this.linkForgotPassword.Font = new System.Drawing.Font("Segoe UI", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.linkForgotPassword.LinkColor = System.Drawing.Color.Blue;
            this.linkForgotPassword.Location = new System.Drawing.Point(530, 546);
            this.linkForgotPassword.Name = "linkForgotPassword";
            this.linkForgotPassword.Size = new System.Drawing.Size(191, 32);
            this.linkForgotPassword.TabIndex = 7;
            this.linkForgotPassword.TabStop = true;
            this.linkForgotPassword.Text = "Quên mật khẩu?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 491);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mật khẩu:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(74, 406);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(124, 27);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Tài khoản:";
            this.lblUsername.Click += new System.EventHandler(this.label1_Click);
            // 
            // img_title
            // 
            this.img_title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.img_title.ErrorImage = ((System.Drawing.Image)(resources.GetObject("img_title.ErrorImage")));
            this.img_title.Image = ((System.Drawing.Image)(resources.GetObject("img_title.Image")));
            this.img_title.Location = new System.Drawing.Point(85, 119);
            this.img_title.Name = "img_title";
            this.img_title.Size = new System.Drawing.Size(606, 264);
            this.img_title.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_title.TabIndex = 1;
            this.img_title.TabStop = false;
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogin.BackColor = System.Drawing.Color.SteelBlue;
            this.btnLogin.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.btnLogin.BorderColor = System.Drawing.Color.Black;
            this.btnLogin.BorderRadius = 40;
            this.btnLogin.BorderSize = 0;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(200, 613);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(217, 62);
            this.btnLogin.TabIndex = 9;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.TextColor = System.Drawing.Color.White;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click_1);
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(168F, 168F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.ClientSize = new System.Drawing.Size(1406, 895);
            this.Controls.Add(this.Panel_login);
            this.Font = new System.Drawing.Font("Arial", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Draw - Đăng nhập";
            this.Load += new System.EventHandler(this.SignUp_Load);
            this.Panel_login.ResumeLayout(false);
            this.Panel_login.PerformLayout();
            this.PanelPassword.ResumeLayout(false);
            this.PanelPassword.PerformLayout();
            this.PanelUsername.ResumeLayout(false);
            this.PanelUsername.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_title)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

            #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel Panel_login;
        private System.Windows.Forms.PictureBox img_title;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkForgotPassword;
        private System.Windows.Forms.Button btnShowHide;
        private System.Windows.Forms.Label lblUsername;
        public System.Windows.Forms.ImageList pasword;
        private System.Windows.Forms.Panel PanelPassword;
        private System.Windows.Forms.Panel PanelUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private Controls.RJButton btnLogin;
    }
}

