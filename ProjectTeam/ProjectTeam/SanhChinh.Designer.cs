namespace ProjectTeam
{
    partial class SanhChinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SanhChinh));
            this.iconMenu = new System.Windows.Forms.ImageList(this.components);
            this.slogan = new System.Windows.Forms.Panel();
            this.icon_exit = new System.Windows.Forms.ImageList(this.components);
            this.taskbarMenu = new System.Windows.Forms.Panel();
            this.iconButton7 = new FontAwesome.Sharp.IconButton();
            this.iconButton6 = new FontAwesome.Sharp.IconButton();
            this.iconButton5 = new FontAwesome.Sharp.IconButton();
            this.iconButton4 = new FontAwesome.Sharp.IconButton();
            this.IconEnjoy = new FontAwesome.Sharp.IconButton();
            this.CreateDraw = new FontAwesome.Sharp.IconButton();
            this.IconHome = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMenu = new FontAwesome.Sharp.IconButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PanelTitleBar = new System.Windows.Forms.Panel();
            this.subheading = new System.Windows.Forms.Label();
            this.iconBtnScaleDesktop = new FontAwesome.Sharp.IconButton();
            this.iconBtnExpandDesktop = new FontAwesome.Sharp.IconButton();
            this.iconBtnCloseDesktop = new FontAwesome.Sharp.IconButton();
            this.Heading = new System.Windows.Forms.Label();
            this.PanelDesktop = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.taskbarMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PanelTitleBar.SuspendLayout();
            this.PanelDesktop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // iconMenu
            // 
            this.iconMenu.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconMenu.ImageStream")));
            this.iconMenu.TransparentColor = System.Drawing.Color.Transparent;
            this.iconMenu.Images.SetKeyName(0, "home.png");
            this.iconMenu.Images.SetKeyName(1, "group.png");
            // 
            // slogan
            // 
            this.slogan.AutoSize = true;
            this.slogan.Dock = System.Windows.Forms.DockStyle.Top;
            this.slogan.Location = new System.Drawing.Point(0, 0);
            this.slogan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.slogan.Name = "slogan";
            this.slogan.Size = new System.Drawing.Size(227, 0);
            this.slogan.TabIndex = 0;
            // 
            // icon_exit
            // 
            this.icon_exit.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icon_exit.ImageStream")));
            this.icon_exit.TransparentColor = System.Drawing.Color.Transparent;
            this.icon_exit.Images.SetKeyName(0, "logout.png");
            // 
            // taskbarMenu
            // 
            this.taskbarMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
            this.taskbarMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.taskbarMenu.Controls.Add(this.iconButton7);
            this.taskbarMenu.Controls.Add(this.iconButton6);
            this.taskbarMenu.Controls.Add(this.iconButton5);
            this.taskbarMenu.Controls.Add(this.iconButton4);
            this.taskbarMenu.Controls.Add(this.IconEnjoy);
            this.taskbarMenu.Controls.Add(this.CreateDraw);
            this.taskbarMenu.Controls.Add(this.IconHome);
            this.taskbarMenu.Controls.Add(this.panel1);
            this.taskbarMenu.Controls.Add(this.label2);
            this.taskbarMenu.Controls.Add(this.slogan);
            this.taskbarMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.taskbarMenu.Location = new System.Drawing.Point(0, 0);
            this.taskbarMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.taskbarMenu.Name = "taskbarMenu";
            this.taskbarMenu.Padding = new System.Windows.Forms.Padding(0, 0, 0, 36);
            this.taskbarMenu.Size = new System.Drawing.Size(229, 754);
            this.taskbarMenu.TabIndex = 2;
            this.taskbarMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.taskbarMenu_Paint);
            // 
            // iconButton7
            // 
            this.iconButton7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.iconButton7.FlatAppearance.BorderSize = 0;
            this.iconButton7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.iconButton7.IconChar = FontAwesome.Sharp.IconChar.SignOut;
            this.iconButton7.IconColor = System.Drawing.Color.Black;
            this.iconButton7.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton7.Location = new System.Drawing.Point(0, 665);
            this.iconButton7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.iconButton7.Name = "iconButton7";
            this.iconButton7.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.iconButton7.Size = new System.Drawing.Size(227, 51);
            this.iconButton7.TabIndex = 11;
            this.iconButton7.Tag = "Đăng xuất";
            this.iconButton7.Text = "Đăng xuất";
            this.iconButton7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton7.UseVisualStyleBackColor = true;
            this.iconButton7.Click += new System.EventHandler(this.iconButton7_Click);
            // 
            // iconButton6
            // 
            this.iconButton6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton6.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton6.FlatAppearance.BorderSize = 0;
            this.iconButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.iconButton6.IconChar = FontAwesome.Sharp.IconChar.Cog;
            this.iconButton6.IconColor = System.Drawing.Color.Black;
            this.iconButton6.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton6.Location = new System.Drawing.Point(0, 403);
            this.iconButton6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.iconButton6.Name = "iconButton6";
            this.iconButton6.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.iconButton6.Size = new System.Drawing.Size(227, 51);
            this.iconButton6.TabIndex = 10;
            this.iconButton6.Tag = "Cài đặt";
            this.iconButton6.Text = "cài đặt";
            this.iconButton6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton6.UseVisualStyleBackColor = true;
            this.iconButton6.Click += new System.EventHandler(this.iconButton6_Click);
            // 
            // iconButton5
            // 
            this.iconButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton5.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton5.FlatAppearance.BorderSize = 0;
            this.iconButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.iconButton5.IconChar = FontAwesome.Sharp.IconChar.EnvelopeOpen;
            this.iconButton5.IconColor = System.Drawing.Color.Black;
            this.iconButton5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton5.Location = new System.Drawing.Point(0, 352);
            this.iconButton5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.iconButton5.Name = "iconButton5";
            this.iconButton5.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.iconButton5.Size = new System.Drawing.Size(227, 51);
            this.iconButton5.TabIndex = 9;
            this.iconButton5.Tag = "Mời bạn bè";
            this.iconButton5.Text = "Mời bạn bè";
            this.iconButton5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton5.UseVisualStyleBackColor = true;
            // 
            // iconButton4
            // 
            this.iconButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton4.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton4.FlatAppearance.BorderSize = 0;
            this.iconButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.iconButton4.IconChar = FontAwesome.Sharp.IconChar.Images;
            this.iconButton4.IconColor = System.Drawing.Color.Black;
            this.iconButton4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton4.Location = new System.Drawing.Point(0, 301);
            this.iconButton4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.iconButton4.Name = "iconButton4";
            this.iconButton4.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.iconButton4.Size = new System.Drawing.Size(227, 51);
            this.iconButton4.TabIndex = 8;
            this.iconButton4.Tag = "Bản vẽ gần đây";
            this.iconButton4.Text = "Bản vẽ gần đây";
            this.iconButton4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton4.UseVisualStyleBackColor = true;
            // 
            // IconEnjoy
            // 
            this.IconEnjoy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IconEnjoy.Dock = System.Windows.Forms.DockStyle.Top;
            this.IconEnjoy.FlatAppearance.BorderSize = 0;
            this.IconEnjoy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IconEnjoy.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.IconEnjoy.IconChar = FontAwesome.Sharp.IconChar.PeopleGroup;
            this.IconEnjoy.IconColor = System.Drawing.Color.Black;
            this.IconEnjoy.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.IconEnjoy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.IconEnjoy.Location = new System.Drawing.Point(0, 250);
            this.IconEnjoy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.IconEnjoy.Name = "IconEnjoy";
            this.IconEnjoy.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.IconEnjoy.Size = new System.Drawing.Size(227, 51);
            this.IconEnjoy.TabIndex = 7;
            this.IconEnjoy.Tag = "Tham gia phòng vẽ";
            this.IconEnjoy.Text = "Tham gia phòng vẽ";
            this.IconEnjoy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.IconEnjoy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.IconEnjoy.UseVisualStyleBackColor = true;
            this.IconEnjoy.Click += new System.EventHandler(this.iconButton3_Click);
            // 
            // CreateDraw
            // 
            this.CreateDraw.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CreateDraw.Dock = System.Windows.Forms.DockStyle.Top;
            this.CreateDraw.FlatAppearance.BorderSize = 0;
            this.CreateDraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateDraw.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CreateDraw.IconChar = FontAwesome.Sharp.IconChar.Edit;
            this.CreateDraw.IconColor = System.Drawing.Color.Black;
            this.CreateDraw.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.CreateDraw.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreateDraw.Location = new System.Drawing.Point(0, 199);
            this.CreateDraw.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CreateDraw.Name = "CreateDraw";
            this.CreateDraw.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.CreateDraw.Size = new System.Drawing.Size(227, 51);
            this.CreateDraw.TabIndex = 6;
            this.CreateDraw.Tag = "Tạo bản vẽ";
            this.CreateDraw.Text = "Tạo bản vẽ";
            this.CreateDraw.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CreateDraw.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CreateDraw.UseVisualStyleBackColor = true;
            this.CreateDraw.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // IconHome
            // 
            this.IconHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IconHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.IconHome.FlatAppearance.BorderSize = 0;
            this.IconHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IconHome.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.IconHome.IconChar = FontAwesome.Sharp.IconChar.HomeUser;
            this.IconHome.IconColor = System.Drawing.Color.Black;
            this.IconHome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.IconHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.IconHome.Location = new System.Drawing.Point(0, 148);
            this.IconHome.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.IconHome.Name = "IconHome";
            this.IconHome.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.IconHome.Size = new System.Drawing.Size(227, 51);
            this.IconHome.TabIndex = 3;
            this.IconHome.Tag = "Home";
            this.IconHome.Text = "Nhà";
            this.IconHome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.IconHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.IconHome.UseVisualStyleBackColor = true;
            this.IconHome.Click += new System.EventHandler(this.IconHome_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnMenu);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(227, 148);
            this.panel1.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 8);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(181, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.IconChar = FontAwesome.Sharp.IconChar.AlignRight;
            this.btnMenu.IconColor = System.Drawing.Color.Black;
            this.btnMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMenu.IconSize = 40;
            this.btnMenu.Location = new System.Drawing.Point(182, 93);
            this.btnMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(43, 43);
            this.btnMenu.TabIndex = 3;
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(-3, 145);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(230, 3);
            this.label3.TabIndex = 2;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 1;
            // 
            // PanelTitleBar
            // 
            this.PanelTitleBar.BackColor = System.Drawing.Color.White;
            this.PanelTitleBar.Controls.Add(this.subheading);
            this.PanelTitleBar.Controls.Add(this.iconBtnScaleDesktop);
            this.PanelTitleBar.Controls.Add(this.iconBtnExpandDesktop);
            this.PanelTitleBar.Controls.Add(this.iconBtnCloseDesktop);
            this.PanelTitleBar.Controls.Add(this.Heading);
            this.PanelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTitleBar.Location = new System.Drawing.Point(229, 0);
            this.PanelTitleBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PanelTitleBar.Name = "PanelTitleBar";
            this.PanelTitleBar.Size = new System.Drawing.Size(963, 90);
            this.PanelTitleBar.TabIndex = 4;
            // 
            // subheading
            // 
            this.subheading.AutoSize = true;
            this.subheading.Location = new System.Drawing.Point(31, 58);
            this.subheading.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.subheading.Name = "subheading";
            this.subheading.Size = new System.Drawing.Size(215, 20);
            this.subheading.TabIndex = 4;
            this.subheading.Text = "Chào mừng bạn đã quay trở lại";
            // 
            // iconBtnScaleDesktop
            // 
            this.iconBtnScaleDesktop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconBtnScaleDesktop.BackColor = System.Drawing.Color.Transparent;
            this.iconBtnScaleDesktop.FlatAppearance.BorderSize = 0;
            this.iconBtnScaleDesktop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconBtnScaleDesktop.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.iconBtnScaleDesktop.IconColor = System.Drawing.Color.DarkGray;
            this.iconBtnScaleDesktop.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconBtnScaleDesktop.IconSize = 36;
            this.iconBtnScaleDesktop.Location = new System.Drawing.Point(821, 2);
            this.iconBtnScaleDesktop.Margin = new System.Windows.Forms.Padding(0);
            this.iconBtnScaleDesktop.Name = "iconBtnScaleDesktop";
            this.iconBtnScaleDesktop.Size = new System.Drawing.Size(46, 29);
            this.iconBtnScaleDesktop.TabIndex = 3;
            this.iconBtnScaleDesktop.UseVisualStyleBackColor = false;
            this.iconBtnScaleDesktop.Click += new System.EventHandler(this.iconBtnScaleDesktop_Click);
            // 
            // iconBtnExpandDesktop
            // 
            this.iconBtnExpandDesktop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconBtnExpandDesktop.BackColor = System.Drawing.Color.Transparent;
            this.iconBtnExpandDesktop.FlatAppearance.BorderSize = 0;
            this.iconBtnExpandDesktop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconBtnExpandDesktop.IconChar = FontAwesome.Sharp.IconChar.ExpandAlt;
            this.iconBtnExpandDesktop.IconColor = System.Drawing.Color.DarkGray;
            this.iconBtnExpandDesktop.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconBtnExpandDesktop.IconSize = 36;
            this.iconBtnExpandDesktop.Location = new System.Drawing.Point(868, 2);
            this.iconBtnExpandDesktop.Margin = new System.Windows.Forms.Padding(0);
            this.iconBtnExpandDesktop.Name = "iconBtnExpandDesktop";
            this.iconBtnExpandDesktop.Size = new System.Drawing.Size(46, 29);
            this.iconBtnExpandDesktop.TabIndex = 2;
            this.iconBtnExpandDesktop.UseVisualStyleBackColor = false;
            this.iconBtnExpandDesktop.Click += new System.EventHandler(this.iconBtnExpandDesktop_Click);
            // 
            // iconBtnCloseDesktop
            // 
            this.iconBtnCloseDesktop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconBtnCloseDesktop.BackColor = System.Drawing.Color.Transparent;
            this.iconBtnCloseDesktop.FlatAppearance.BorderSize = 0;
            this.iconBtnCloseDesktop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconBtnCloseDesktop.IconChar = FontAwesome.Sharp.IconChar.CircleXmark;
            this.iconBtnCloseDesktop.IconColor = System.Drawing.Color.DarkGray;
            this.iconBtnCloseDesktop.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconBtnCloseDesktop.IconSize = 36;
            this.iconBtnCloseDesktop.Location = new System.Drawing.Point(914, 2);
            this.iconBtnCloseDesktop.Margin = new System.Windows.Forms.Padding(0);
            this.iconBtnCloseDesktop.Name = "iconBtnCloseDesktop";
            this.iconBtnCloseDesktop.Size = new System.Drawing.Size(46, 29);
            this.iconBtnCloseDesktop.TabIndex = 1;
            this.iconBtnCloseDesktop.UseVisualStyleBackColor = false;
            this.iconBtnCloseDesktop.Click += new System.EventHandler(this.iconBtnCloseDesktop_Click);
            // 
            // Heading
            // 
            this.Heading.AutoSize = true;
            this.Heading.BackColor = System.Drawing.Color.Transparent;
            this.Heading.Font = new System.Drawing.Font("Segoe UI", 15.85714F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Heading.Location = new System.Drawing.Point(28, 22);
            this.Heading.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Heading.Name = "Heading";
            this.Heading.Size = new System.Drawing.Size(98, 37);
            this.Heading.TabIndex = 0;
            this.Heading.Text = "HOME";
            // 
            // PanelDesktop
            // 
            this.PanelDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PanelDesktop.Controls.Add(this.pictureBox2);
            this.PanelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelDesktop.Location = new System.Drawing.Point(229, 90);
            this.PanelDesktop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PanelDesktop.Name = "PanelDesktop";
            this.PanelDesktop.Size = new System.Drawing.Size(963, 664);
            this.PanelDesktop.TabIndex = 5;
            this.PanelDesktop.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelDesktop_Paint_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(963, 664);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // SanhChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.ClientSize = new System.Drawing.Size(1192, 754);
            this.Controls.Add(this.PanelDesktop);
            this.Controls.Add(this.PanelTitleBar);
            this.Controls.Add(this.taskbarMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(919, 528);
            this.Name = "SanhChinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Draw - Home";
            this.Load += new System.EventHandler(this.SanhChinh_Load);
            this.Resize += new System.EventHandler(this.SanhChinh_Resize);
            this.taskbarMenu.ResumeLayout(false);
            this.taskbarMenu.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PanelTitleBar.ResumeLayout(false);
            this.PanelTitleBar.PerformLayout();
            this.PanelDesktop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList iconMenu;
        private System.Windows.Forms.Panel slogan;
        private System.Windows.Forms.Panel taskbarMenu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList icon_exit;
        private System.Windows.Forms.Panel PanelTitleBar;
        private FontAwesome.Sharp.IconButton btnMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton CreateDraw;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton iconButton7;
        private FontAwesome.Sharp.IconButton iconButton6;
        private FontAwesome.Sharp.IconButton iconButton5;
        private FontAwesome.Sharp.IconButton iconButton4;
        private FontAwesome.Sharp.IconButton IconEnjoy;
        private System.Windows.Forms.Label Heading;
        private FontAwesome.Sharp.IconButton iconBtnCloseDesktop;
        private FontAwesome.Sharp.IconButton iconBtnScaleDesktop;
        private FontAwesome.Sharp.IconButton iconBtnExpandDesktop;
        private System.Windows.Forms.Label subheading;
        private System.Windows.Forms.Panel PanelDesktop;
        private FontAwesome.Sharp.IconButton IconHome;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}