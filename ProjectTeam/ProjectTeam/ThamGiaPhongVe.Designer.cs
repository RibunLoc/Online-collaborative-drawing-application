namespace ProjectTeam
{
    partial class ThamGiaPhongVe
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
            this.TieuDeMaCode = new System.Windows.Forms.Label();
            this.TbNhapMaPhong = new RJCodeAdvance.RJControls.RJTextBox();
            this.DanhSachPhongVe = new MaterialSkin.Controls.MaterialListView();
            this.MaPhong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TenPhong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SoNguoiThamGia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TenChuPhong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnTimKiem = new RJCodeAdvance.RJControls.RJButton();
            this.btnLamMoi = new RJCodeAdvance.RJControls.RJButton();
            this.btnThamGia = new MaterialSkin.Controls.MaterialButton();
            this.panelQuanLyDanhSachPhong = new System.Windows.Forms.Panel();
            this.Progressbar = new MaterialSkin.Controls.MaterialProgressBar();
            this.lbl_DangTai = new MaterialSkin.Controls.MaterialLabel();
            this.panelQuanLyDanhSachPhong.SuspendLayout();
            this.SuspendLayout();
            // 
            // TieuDeMaCode
            // 
            this.TieuDeMaCode.AutoSize = true;
            this.TieuDeMaCode.Location = new System.Drawing.Point(52, 56);
            this.TieuDeMaCode.Name = "TieuDeMaCode";
            this.TieuDeMaCode.Size = new System.Drawing.Size(275, 30);
            this.TieuDeMaCode.TabIndex = 0;
            this.TieuDeMaCode.Text = "Nhập mã để tham phòng vẽ";
            this.TieuDeMaCode.Click += new System.EventHandler(this.TieuDeMaCode_Click);
            // 
            // TbNhapMaPhong
            // 
            this.TbNhapMaPhong.BackColor = System.Drawing.SystemColors.Window;
            this.TbNhapMaPhong.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.TbNhapMaPhong.BorderFocusColor = System.Drawing.SystemColors.ActiveCaption;
            this.TbNhapMaPhong.BorderRadius = 0;
            this.TbNhapMaPhong.BorderSize = 2;
            this.TbNhapMaPhong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbNhapMaPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbNhapMaPhong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TbNhapMaPhong.Location = new System.Drawing.Point(344, 50);
            this.TbNhapMaPhong.Margin = new System.Windows.Forms.Padding(4);
            this.TbNhapMaPhong.Multiline = false;
            this.TbNhapMaPhong.Name = "TbNhapMaPhong";
            this.TbNhapMaPhong.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TbNhapMaPhong.PasswordChar = false;
            this.TbNhapMaPhong.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.TbNhapMaPhong.PlaceholderText = "";
            this.TbNhapMaPhong.Size = new System.Drawing.Size(381, 44);
            this.TbNhapMaPhong.TabIndex = 1;
            this.TbNhapMaPhong.Texts = "";
            this.TbNhapMaPhong.UnderlinedStyle = false;
            // 
            // DanhSachPhongVe
            // 
            this.DanhSachPhongVe.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.DanhSachPhongVe.AutoSizeTable = false;
            this.DanhSachPhongVe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DanhSachPhongVe.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DanhSachPhongVe.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MaPhong,
            this.TenPhong,
            this.SoNguoiThamGia,
            this.TenChuPhong});
            this.DanhSachPhongVe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DanhSachPhongVe.Depth = 0;
            this.DanhSachPhongVe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DanhSachPhongVe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.DanhSachPhongVe.FullRowSelect = true;
            this.DanhSachPhongVe.Location = new System.Drawing.Point(0, 0);
            this.DanhSachPhongVe.MinimumSize = new System.Drawing.Size(200, 100);
            this.DanhSachPhongVe.MouseLocation = new System.Drawing.Point(-1, -1);
            this.DanhSachPhongVe.MouseState = MaterialSkin.MouseState.OUT;
            this.DanhSachPhongVe.Name = "DanhSachPhongVe";
            this.DanhSachPhongVe.OwnerDraw = true;
            this.DanhSachPhongVe.Size = new System.Drawing.Size(1280, 546);
            this.DanhSachPhongVe.TabIndex = 3;
            this.DanhSachPhongVe.UseCompatibleStateImageBehavior = false;
            this.DanhSachPhongVe.View = System.Windows.Forms.View.Details;
            this.DanhSachPhongVe.SelectedIndexChanged += new System.EventHandler(this.DanhSachPhongVe_SelectedIndexChanged);
            // 
            // MaPhong
            // 
            this.MaPhong.Text = "Mã phòng";
            this.MaPhong.Width = 185;
            // 
            // TenPhong
            // 
            this.TenPhong.Text = "Tên phòng";
            this.TenPhong.Width = 240;
            // 
            // SoNguoiThamGia
            // 
            this.SoNguoiThamGia.Text = "Số người tham gia";
            this.SoNguoiThamGia.Width = 279;
            // 
            // TenChuPhong
            // 
            this.TenChuPhong.Text = "Tên chủ phòng";
            this.TenChuPhong.Width = 200;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(181)))));
            this.btnTimKiem.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(181)))));
            this.btnTimKiem.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnTimKiem.BorderRadius = 0;
            this.btnTimKiem.BorderSize = 0;
            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(162)))), ((int)(((byte)(255)))));
            this.btnTimKiem.Location = new System.Drawing.Point(757, 49);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(153, 45);
            this.btnTimKiem.TabIndex = 4;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(162)))), ((int)(((byte)(255)))));
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
            this.btnLamMoi.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
            this.btnLamMoi.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnLamMoi.BorderRadius = 0;
            this.btnLamMoi.BorderSize = 0;
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(319, 748);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(160, 59);
            this.btnLamMoi.TabIndex = 5;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.TextColor = System.Drawing.Color.White;
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnThamGia
            // 
            this.btnThamGia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnThamGia.AutoSize = false;
            this.btnThamGia.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnThamGia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThamGia.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnThamGia.Depth = 0;
            this.btnThamGia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThamGia.HighEmphasis = true;
            this.btnThamGia.Icon = null;
            this.btnThamGia.Location = new System.Drawing.Point(57, 748);
            this.btnThamGia.Margin = new System.Windows.Forms.Padding(10);
            this.btnThamGia.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnThamGia.Name = "btnThamGia";
            this.btnThamGia.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnThamGia.Padding = new System.Windows.Forms.Padding(50);
            this.btnThamGia.Size = new System.Drawing.Size(158, 59);
            this.btnThamGia.TabIndex = 6;
            this.btnThamGia.Text = "Tham Gia";
            this.btnThamGia.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnThamGia.UseAccentColor = false;
            this.btnThamGia.UseVisualStyleBackColor = true;
            this.btnThamGia.Click += new System.EventHandler(this.btnThamGia_Click);
            // 
            // panelQuanLyDanhSachPhong
            // 
            this.panelQuanLyDanhSachPhong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelQuanLyDanhSachPhong.Controls.Add(this.lbl_DangTai);
            this.panelQuanLyDanhSachPhong.Controls.Add(this.Progressbar);
            this.panelQuanLyDanhSachPhong.Controls.Add(this.DanhSachPhongVe);
            this.panelQuanLyDanhSachPhong.Location = new System.Drawing.Point(57, 141);
            this.panelQuanLyDanhSachPhong.Name = "panelQuanLyDanhSachPhong";
            this.panelQuanLyDanhSachPhong.Size = new System.Drawing.Size(1280, 546);
            this.panelQuanLyDanhSachPhong.TabIndex = 7;
            // 
            // Progressbar
            // 
            this.Progressbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Progressbar.BackColor = System.Drawing.SystemColors.Window;
            this.Progressbar.Depth = 0;
            this.Progressbar.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Progressbar.Location = new System.Drawing.Point(139, 281);
            this.Progressbar.MarqueeAnimationSpeed = 10;
            this.Progressbar.MouseState = MaterialSkin.MouseState.HOVER;
            this.Progressbar.Name = "Progressbar";
            this.Progressbar.Size = new System.Drawing.Size(978, 5);
            this.Progressbar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.Progressbar.TabIndex = 8;
            this.Progressbar.Visible = false;
            // 
            // lbl_DangTai
            // 
            this.lbl_DangTai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_DangTai.AutoSize = true;
            this.lbl_DangTai.Depth = 0;
            this.lbl_DangTai.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_DangTai.Location = new System.Drawing.Point(614, 259);
            this.lbl_DangTai.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbl_DangTai.Name = "lbl_DangTai";
            this.lbl_DangTai.Size = new System.Drawing.Size(73, 19);
            this.lbl_DangTai.TabIndex = 9;
            this.lbl_DangTai.Text = "Đang tải...";
            this.lbl_DangTai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ThamGiaPhongVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(168F, 168F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(247)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(1412, 840);
            this.Controls.Add(this.panelQuanLyDanhSachPhong);
            this.Controls.Add(this.btnThamGia);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.TbNhapMaPhong);
            this.Controls.Add(this.TieuDeMaCode);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Name = "ThamGiaPhongVe";
            this.Text = "ThamGiaPhongVe";
            this.Load += new System.EventHandler(this.ThamGiaPhongVe_Load);
            this.panelQuanLyDanhSachPhong.ResumeLayout(false);
            this.panelQuanLyDanhSachPhong.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TieuDeMaCode;
        private RJCodeAdvance.RJControls.RJTextBox TbNhapMaPhong;
        private MaterialSkin.Controls.MaterialListView DanhSachPhongVe;
        private RJCodeAdvance.RJControls.RJButton btnTimKiem;
        private RJCodeAdvance.RJControls.RJButton btnLamMoi;
        private System.Windows.Forms.ColumnHeader MaPhong;
        private System.Windows.Forms.ColumnHeader TenPhong;
        private System.Windows.Forms.ColumnHeader SoNguoiThamGia;
        private System.Windows.Forms.ColumnHeader TenChuPhong;
        private MaterialSkin.Controls.MaterialButton btnThamGia;
        private System.Windows.Forms.Panel panelQuanLyDanhSachPhong;
        private MaterialSkin.Controls.MaterialProgressBar Progressbar;
        private MaterialSkin.Controls.MaterialLabel lbl_DangTai;
    }
}