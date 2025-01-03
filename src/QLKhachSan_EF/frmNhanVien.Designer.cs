namespace QLKhachSan_EF
{
    partial class frmNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhanVien));
            this.label1 = new System.Windows.Forms.Label();
            this.tabNhanVien = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.cbLoai = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.cbGioiTinh = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelToSet = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvTTNV = new System.Windows.Forms.DataGridView();
            this.idnv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tennv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sodienthoainv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gioitinhnv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loainguoidung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvTTNV2 = new System.Windows.Forms.DataGridView();
            this.idnv2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tennv2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sodienthoainv2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gioitinhnv2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pass2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loainguoidung2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXoa = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.tabNhanVien.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTTNV)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTTNV2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 37);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nhân Viên";
            // 
            // tabNhanVien
            // 
            this.tabNhanVien.Controls.Add(this.tabPage1);
            this.tabNhanVien.Controls.Add(this.tabPage2);
            this.tabNhanVien.Controls.Add(this.tabPage3);
            this.tabNhanVien.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabNhanVien.Location = new System.Drawing.Point(40, 113);
            this.tabNhanVien.Name = "tabNhanVien";
            this.tabNhanVien.SelectedIndex = 0;
            this.tabNhanVien.Size = new System.Drawing.Size(1198, 491);
            this.tabNhanVien.TabIndex = 5;
            this.tabNhanVien.SelectedIndexChanged += new System.EventHandler(this.tabNhanVien_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.cbLoai);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.btnDangKy);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txtMatKhau);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.txtTaiKhoan);
            this.tabPage1.Controls.Add(this.cbGioiTinh);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtEmail);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtSoDienThoai);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.labelToSet);
            this.tabPage1.Controls.Add(this.txtHoTen);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1190, 455);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Đăng Ký Nhân Viên";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(986, 363);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 49);
            this.button1.TabIndex = 31;
            this.button1.Text = "Trở Về";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbLoai
            // 
            this.cbLoai.FormattingEnabled = true;
            this.cbLoai.Items.AddRange(new object[] {
            "Nhân Viên",
            "Quản Lý"});
            this.cbLoai.Location = new System.Drawing.Point(794, 300);
            this.cbLoai.Name = "cbLoai";
            this.cbLoai.Size = new System.Drawing.Size(311, 31);
            this.cbLoai.TabIndex = 30;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(789, 259);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(148, 25);
            this.label11.TabIndex = 29;
            this.label11.Text = "Loại Người Dùng";
            // 
            // btnDangKy
            // 
            this.btnDangKy.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKy.Location = new System.Drawing.Point(818, 363);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(133, 49);
            this.btnDangKy.TabIndex = 28;
            this.btnDangKy.Text = "Đăng Ký";
            this.btnDangKy.UseVisualStyleBackColor = true;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(789, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 25);
            this.label8.TabIndex = 13;
            this.label8.Text = "Mật Khẩu";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau.Location = new System.Drawing.Point(794, 202);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(311, 31);
            this.txtMatKhau.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(789, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 25);
            this.label9.TabIndex = 11;
            this.label9.Text = "Tài Khoản";
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaiKhoan.Location = new System.Drawing.Point(794, 116);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(311, 31);
            this.txtTaiKhoan.TabIndex = 10;
            // 
            // cbGioiTinh
            // 
            this.cbGioiTinh.FormattingEnabled = true;
            this.cbGioiTinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác"});
            this.cbGioiTinh.Location = new System.Drawing.Point(63, 300);
            this.cbGioiTinh.Name = "cbGioiTinh";
            this.cbGioiTinh.Size = new System.Drawing.Size(311, 31);
            this.cbGioiTinh.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(58, 259);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 25);
            this.label7.TabIndex = 8;
            this.label7.Text = "Giới Tính";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(58, 344);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 25);
            this.label6.TabIndex = 7;
            this.label6.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(63, 381);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(311, 31);
            this.txtEmail.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(58, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Số Điện Thoại";
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoDienThoai.Location = new System.Drawing.Point(63, 202);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(311, 31);
            this.txtSoDienThoai.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(58, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tên";
            // 
            // labelToSet
            // 
            this.labelToSet.AutoSize = true;
            this.labelToSet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelToSet.Location = new System.Drawing.Point(108, 32);
            this.labelToSet.Name = "labelToSet";
            this.labelToSet.Size = new System.Drawing.Size(76, 28);
            this.labelToSet.TabIndex = 2;
            this.labelToSet.Text = "--------";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.Location = new System.Drawing.Point(63, 116);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(311, 31);
            this.txtHoTen.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "ID - ";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvTTNV);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1190, 455);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Thông Tin Nhân Viên";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvTTNV
            // 
            this.dgvTTNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTTNV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idnv,
            this.tennv,
            this.sodienthoainv,
            this.gioitinhnv,
            this.email,
            this.username,
            this.pass,
            this.loainguoidung});
            this.dgvTTNV.Location = new System.Drawing.Point(21, 77);
            this.dgvTTNV.Name = "dgvTTNV";
            this.dgvTTNV.RowHeadersWidth = 51;
            this.dgvTTNV.RowTemplate.Height = 24;
            this.dgvTTNV.Size = new System.Drawing.Size(1146, 356);
            this.dgvTTNV.TabIndex = 1;
            // 
            // idnv
            // 
            this.idnv.DataPropertyName = "idnv";
            this.idnv.HeaderText = "ID";
            this.idnv.MinimumWidth = 6;
            this.idnv.Name = "idnv";
            this.idnv.Width = 40;
            // 
            // tennv
            // 
            this.tennv.DataPropertyName = "tennv";
            this.tennv.HeaderText = "Họ tên";
            this.tennv.MinimumWidth = 6;
            this.tennv.Name = "tennv";
            this.tennv.Width = 155;
            // 
            // sodienthoainv
            // 
            this.sodienthoainv.DataPropertyName = "sodienthoainv";
            this.sodienthoainv.HeaderText = "Số điện thoại";
            this.sodienthoainv.MinimumWidth = 6;
            this.sodienthoainv.Name = "sodienthoainv";
            this.sodienthoainv.Width = 135;
            // 
            // gioitinhnv
            // 
            this.gioitinhnv.DataPropertyName = "gioitinhnv";
            this.gioitinhnv.HeaderText = "Giới tính";
            this.gioitinhnv.MinimumWidth = 6;
            this.gioitinhnv.Name = "gioitinhnv";
            this.gioitinhnv.Width = 125;
            // 
            // email
            // 
            this.email.DataPropertyName = "email";
            this.email.HeaderText = "Email";
            this.email.MinimumWidth = 6;
            this.email.Name = "email";
            this.email.Width = 250;
            // 
            // username
            // 
            this.username.DataPropertyName = "username";
            this.username.HeaderText = "Username";
            this.username.MinimumWidth = 6;
            this.username.Name = "username";
            this.username.Width = 140;
            // 
            // pass
            // 
            this.pass.DataPropertyName = "pass";
            this.pass.HeaderText = "Password";
            this.pass.MinimumWidth = 6;
            this.pass.Name = "pass";
            this.pass.Width = 115;
            // 
            // loainguoidung
            // 
            this.loainguoidung.DataPropertyName = "loainguoidung";
            this.loainguoidung.HeaderText = "Loại";
            this.loainguoidung.MinimumWidth = 6;
            this.loainguoidung.Name = "loainguoidung";
            this.loainguoidung.Width = 170;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(485, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(213, 28);
            this.label10.TabIndex = 0;
            this.label10.Text = "Thông Tin Nhân Viên";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvTTNV2);
            this.tabPage3.Controls.Add(this.btnXoa);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.txtID);
            this.tabPage3.Location = new System.Drawing.Point(4, 32);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1190, 455);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Xóa Nhân Viên";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvTTNV2
            // 
            this.dgvTTNV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTTNV2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idnv2,
            this.tennv2,
            this.sodienthoainv2,
            this.gioitinhnv2,
            this.email2,
            this.username2,
            this.pass2,
            this.loainguoidung2});
            this.dgvTTNV2.Location = new System.Drawing.Point(19, 199);
            this.dgvTTNV2.Name = "dgvTTNV2";
            this.dgvTTNV2.RowHeadersWidth = 51;
            this.dgvTTNV2.RowTemplate.Height = 24;
            this.dgvTTNV2.Size = new System.Drawing.Size(1155, 241);
            this.dgvTTNV2.TabIndex = 30;
            // 
            // idnv2
            // 
            this.idnv2.DataPropertyName = "idnv";
            this.idnv2.HeaderText = "ID";
            this.idnv2.MinimumWidth = 6;
            this.idnv2.Name = "idnv2";
            this.idnv2.Width = 40;
            // 
            // tennv2
            // 
            this.tennv2.DataPropertyName = "tennv";
            this.tennv2.HeaderText = "Họ tên";
            this.tennv2.MinimumWidth = 6;
            this.tennv2.Name = "tennv2";
            this.tennv2.Width = 155;
            // 
            // sodienthoainv2
            // 
            this.sodienthoainv2.DataPropertyName = "sodienthoainv";
            this.sodienthoainv2.HeaderText = "Số điện thoại";
            this.sodienthoainv2.MinimumWidth = 6;
            this.sodienthoainv2.Name = "sodienthoainv2";
            this.sodienthoainv2.Width = 135;
            // 
            // gioitinhnv2
            // 
            this.gioitinhnv2.DataPropertyName = "gioitinhnv";
            this.gioitinhnv2.HeaderText = "Giới tính";
            this.gioitinhnv2.MinimumWidth = 6;
            this.gioitinhnv2.Name = "gioitinhnv2";
            this.gioitinhnv2.Width = 125;
            // 
            // email2
            // 
            this.email2.DataPropertyName = "email";
            this.email2.HeaderText = "Email";
            this.email2.MinimumWidth = 6;
            this.email2.Name = "email2";
            this.email2.Width = 250;
            // 
            // username2
            // 
            this.username2.DataPropertyName = "username";
            this.username2.HeaderText = "Username";
            this.username2.MinimumWidth = 6;
            this.username2.Name = "username2";
            this.username2.Width = 140;
            // 
            // pass2
            // 
            this.pass2.DataPropertyName = "pass";
            this.pass2.HeaderText = "Password";
            this.pass2.MinimumWidth = 6;
            this.pass2.Name = "pass2";
            this.pass2.Width = 115;
            // 
            // loainguoidung2
            // 
            this.loainguoidung2.DataPropertyName = "loainguoidung";
            this.loainguoidung2.HeaderText = "Loại";
            this.loainguoidung2.MinimumWidth = 6;
            this.loainguoidung2.Name = "loainguoidung2";
            this.loainguoidung2.Width = 170;
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(606, 128);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(148, 49);
            this.btnXoa.TabIndex = 29;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(438, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 25);
            this.label12.TabIndex = 5;
            this.label12.Text = "Nhập ID:";
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(443, 72);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(311, 31);
            this.txtID.TabIndex = 4;
            // 
            // frmNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1278, 653);
            this.Controls.Add(this.tabNhanVien);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhân Viên";
            this.Load += new System.EventHandler(this.frmNhanVien_Load);
            this.Leave += new System.EventHandler(this.frmNhanVien_Leave);
            this.tabNhanVien.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTTNV)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTTNV2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabNhanVien;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelToSet;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.ComboBox cbGioiTinh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.DataGridView dgvTTNV;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbLoai;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dgvTTNV2;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.DataGridViewTextBoxColumn idnv;
        private System.Windows.Forms.DataGridViewTextBoxColumn tennv;
        private System.Windows.Forms.DataGridViewTextBoxColumn sodienthoainv;
        private System.Windows.Forms.DataGridViewTextBoxColumn gioitinhnv;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn pass;
        private System.Windows.Forms.DataGridViewTextBoxColumn loainguoidung;
        private System.Windows.Forms.DataGridViewTextBoxColumn idnv2;
        private System.Windows.Forms.DataGridViewTextBoxColumn tennv2;
        private System.Windows.Forms.DataGridViewTextBoxColumn sodienthoainv2;
        private System.Windows.Forms.DataGridViewTextBoxColumn gioitinhnv2;
        private System.Windows.Forms.DataGridViewTextBoxColumn email2;
        private System.Windows.Forms.DataGridViewTextBoxColumn username2;
        private System.Windows.Forms.DataGridViewTextBoxColumn pass2;
        private System.Windows.Forms.DataGridViewTextBoxColumn loainguoidung2;
        private System.Windows.Forms.Button button1;
    }
}