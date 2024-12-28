namespace ProjectTeam
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.ThongBao = new System.Windows.Forms.ImageList(this.components);
            this.statusUser = new System.Windows.Forms.ImageList(this.components);
            this.taskBarUserInfo = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Status = new System.Windows.Forms.Panel();
            this.infoUser = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThongBao = new RJCodeAdvance.RJControls.RJButton();
            this.icon_Online = new System.Windows.Forms.Label();
            this.lbl_id = new System.Windows.Forms.Label();
            this.lbl_status = new System.Windows.Forms.Label();
            this.TxtName = new System.Windows.Forms.Label();
            this.Hello = new System.Windows.Forms.Label();
            this.avatar_personal = new RJCodeAdvance.RJControls.RJCircularPictureBox();
            this.icon_btn_close_info = new FontAwesome.Sharp.IconButton();
            this.screen = new System.Windows.Forms.Panel();
            this.taskBarUserInfo.SuspendLayout();
            this.panel3.SuspendLayout();
            this.Status.SuspendLayout();
            this.infoUser.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatar_personal)).BeginInit();
            this.SuspendLayout();
            // 
            // ThongBao
            // 
            this.ThongBao.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ThongBao.ImageStream")));
            this.ThongBao.TransparentColor = System.Drawing.Color.Transparent;
            this.ThongBao.Images.SetKeyName(0, "bell_3602215.png");
            this.ThongBao.Images.SetKeyName(1, "notification_3602467.png");
            // 
            // statusUser
            // 
            this.statusUser.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("statusUser.ImageStream")));
            this.statusUser.TransparentColor = System.Drawing.Color.Transparent;
            this.statusUser.Images.SetKeyName(0, "shape_16001361.png");
            this.statusUser.Images.SetKeyName(1, "circle.png");
            this.statusUser.Images.SetKeyName(2, "bell_3602215.png");
            this.statusUser.Images.SetKeyName(3, "notification_3602467.png");
            // 
            // taskBarUserInfo
            // 
            this.taskBarUserInfo.Controls.Add(this.panel3);
            this.taskBarUserInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.taskBarUserInfo.Location = new System.Drawing.Point(965, 0);
            this.taskBarUserInfo.Name = "taskBarUserInfo";
            this.taskBarUserInfo.Size = new System.Drawing.Size(447, 840);
            this.taskBarUserInfo.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.Status);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(447, 145);
            this.panel3.TabIndex = 0;
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
            this.Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Status.Controls.Add(this.infoUser);
            this.Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Status.Location = new System.Drawing.Point(0, 0);
            this.Status.Margin = new System.Windows.Forms.Padding(0);
            this.Status.Name = "Status";
            this.Status.Padding = new System.Windows.Forms.Padding(0, 20, 30, 0);
            this.Status.Size = new System.Drawing.Size(447, 145);
            this.Status.TabIndex = 12;
            this.Status.Paint += new System.Windows.Forms.PaintEventHandler(this.Status_Paint);
            // 
            // infoUser
            // 
            this.infoUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoUser.Controls.Add(this.panel1);
            this.infoUser.Controls.Add(this.avatar_personal);
            this.infoUser.Controls.Add(this.icon_btn_close_info);
            this.infoUser.Location = new System.Drawing.Point(0, 20);
            this.infoUser.Name = "infoUser";
            this.infoUser.Padding = new System.Windows.Forms.Padding(0, 10, 10, 0);
            this.infoUser.Size = new System.Drawing.Size(442, 106);
            this.infoUser.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnThongBao);
            this.panel1.Controls.Add(this.icon_Online);
            this.panel1.Controls.Add(this.lbl_id);
            this.panel1.Controls.Add(this.lbl_status);
            this.panel1.Controls.Add(this.TxtName);
            this.panel1.Controls.Add(this.Hello);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(124, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 96);
            this.panel1.TabIndex = 0;
            // 
            // btnThongBao
            // 
            this.btnThongBao.BackColor = System.Drawing.SystemColors.Info;
            this.btnThongBao.BackgroundColor = System.Drawing.SystemColors.Info;
            this.btnThongBao.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnThongBao.BorderRadius = 20;
            this.btnThongBao.BorderSize = 0;
            this.btnThongBao.FlatAppearance.BorderSize = 0;
            this.btnThongBao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongBao.ForeColor = System.Drawing.Color.White;
            this.btnThongBao.ImageIndex = 0;
            this.btnThongBao.ImageList = this.ThongBao;
            this.btnThongBao.Location = new System.Drawing.Point(113, -3);
            this.btnThongBao.Name = "btnThongBao";
            this.btnThongBao.Size = new System.Drawing.Size(36, 38);
            this.btnThongBao.TabIndex = 24;
            this.btnThongBao.TextColor = System.Drawing.Color.White;
            this.btnThongBao.UseVisualStyleBackColor = false;
            // 
            // icon_Online
            // 
            this.icon_Online.BackColor = System.Drawing.Color.Transparent;
            this.icon_Online.Dock = System.Windows.Forms.DockStyle.Right;
            this.icon_Online.ImageIndex = 0;
            this.icon_Online.ImageList = this.statusUser;
            this.icon_Online.Location = new System.Drawing.Point(235, 60);
            this.icon_Online.Name = "icon_Online";
            this.icon_Online.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.icon_Online.Size = new System.Drawing.Size(20, 36);
            this.icon_Online.TabIndex = 22;
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.BackColor = System.Drawing.Color.Transparent;
            this.lbl_id.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_id.Location = new System.Drawing.Point(4, 57);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lbl_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_id.Size = new System.Drawing.Size(153, 30);
            this.lbl_id.TabIndex = 17;
            this.lbl_id.Text = "ID: 99999999";
            this.lbl_id.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_status.Font = new System.Drawing.Font("Segoe UI", 6.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_status.Location = new System.Drawing.Point(255, 60);
            this.lbl_status.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(53, 21);
            this.lbl_status.TabIndex = 21;
            this.lbl_status.Text = "online";
            this.lbl_status.Click += new System.EventHandler(this.lbl_status_Click);
            // 
            // TxtName
            // 
            this.TxtName.AutoSize = true;
            this.TxtName.BackColor = System.Drawing.Color.Transparent;
            this.TxtName.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TxtName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.TxtName.Location = new System.Drawing.Point(0, 30);
            this.TxtName.Margin = new System.Windows.Forms.Padding(0);
            this.TxtName.Name = "TxtName";
            this.TxtName.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.TxtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtName.Size = new System.Drawing.Size(129, 30);
            this.TxtName.TabIndex = 19;
            this.TxtName.Text = "Thanh Lộc";
            this.TxtName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TxtName.Click += new System.EventHandler(this.TxtName_Click);
            // 
            // Hello
            // 
            this.Hello.AutoSize = true;
            this.Hello.BackColor = System.Drawing.Color.Transparent;
            this.Hello.Dock = System.Windows.Forms.DockStyle.Top;
            this.Hello.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Hello.Location = new System.Drawing.Point(0, 0);
            this.Hello.Margin = new System.Windows.Forms.Padding(0);
            this.Hello.Name = "Hello";
            this.Hello.Size = new System.Drawing.Size(111, 30);
            this.Hello.TabIndex = 18;
            this.Hello.Text = "Xin chào, ";
            this.Hello.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // avatar_personal
            // 
            this.avatar_personal.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.avatar_personal.BorderColor = System.Drawing.Color.RoyalBlue;
            this.avatar_personal.BorderColor2 = System.Drawing.Color.HotPink;
            this.avatar_personal.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.avatar_personal.BorderSize = 2;
            this.avatar_personal.Dock = System.Windows.Forms.DockStyle.Left;
            this.avatar_personal.GradientAngle = 50F;
            this.avatar_personal.Image = ((System.Drawing.Image)(resources.GetObject("avatar_personal.Image")));
            this.avatar_personal.InitialImage = global::ProjectTeam.Properties.Resources.question_953840;
            this.avatar_personal.Location = new System.Drawing.Point(30, 10);
            this.avatar_personal.Margin = new System.Windows.Forms.Padding(0);
            this.avatar_personal.Name = "avatar_personal";
            this.avatar_personal.Size = new System.Drawing.Size(94, 94);
            this.avatar_personal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avatar_personal.TabIndex = 20;
            this.avatar_personal.TabStop = false;
            // 
            // icon_btn_close_info
            // 
            this.icon_btn_close_info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
            this.icon_btn_close_info.Dock = System.Windows.Forms.DockStyle.Left;
            this.icon_btn_close_info.FlatAppearance.BorderSize = 0;
            this.icon_btn_close_info.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icon_btn_close_info.ForeColor = System.Drawing.SystemColors.ControlText;
            this.icon_btn_close_info.IconChar = FontAwesome.Sharp.IconChar.CaretRight;
            this.icon_btn_close_info.IconColor = System.Drawing.Color.Black;
            this.icon_btn_close_info.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icon_btn_close_info.Location = new System.Drawing.Point(0, 10);
            this.icon_btn_close_info.Name = "icon_btn_close_info";
            this.icon_btn_close_info.Size = new System.Drawing.Size(30, 96);
            this.icon_btn_close_info.TabIndex = 8;
            this.icon_btn_close_info.UseVisualStyleBackColor = false;
            this.icon_btn_close_info.Click += new System.EventHandler(this.icon_btn_close_info_Click);
            // 
            // screen
            // 
            this.screen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("screen.BackgroundImage")));
            this.screen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.screen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screen.Location = new System.Drawing.Point(0, 0);
            this.screen.Name = "screen";
            this.screen.Size = new System.Drawing.Size(965, 840);
            this.screen.TabIndex = 12;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(168F, 168F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1412, 840);
            this.Controls.Add(this.screen);
            this.Controls.Add(this.taskBarUserInfo);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.taskBarUserInfo.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.Status.ResumeLayout(false);
            this.infoUser.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatar_personal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList ThongBao;
        private System.Windows.Forms.ImageList statusUser;
        private System.Windows.Forms.Panel taskBarUserInfo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel Status;
        private System.Windows.Forms.Panel infoUser;
        private FontAwesome.Sharp.IconButton icon_btn_close_info;
        private System.Windows.Forms.Panel screen;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Hello;
        private System.Windows.Forms.Label lbl_id;
        private System.Windows.Forms.Label icon_Online;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Label TxtName;
        private RJCodeAdvance.RJControls.RJCircularPictureBox avatar_personal;
        private RJCodeAdvance.RJControls.RJButton btnThongBao;
    }
}