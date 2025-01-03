using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
namespace QLKhachSan_EF
{
    public partial class frmDangKyKhach : Form
    {
        KhachHang kh = new KhachHang();
        public frmDangKyKhach()
        {
            InitializeComponent();
            txtQuocTich.DropDownHeight = 100;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void SetComboBox(ComboBox combo, IQueryable<string> query)
        {
            combo.Items.Clear();
            foreach (var item in query)
            {
                combo.Items.Add(item);
            }
        }

        private void frmDangKyKhach_Load(object sender, EventArgs e)
        {
            LoadBedTypes();
        }

        private void LoadBedTypes()
        {
            using (var db = new QL_KhachSanEntities())
            {
                var bedTypes = db.Phongs.Select(p => p.loaigiuong).Distinct();
                SetComboBox(cbLoaiGiuong, bedTypes);
            }
        }

        private void cbLoaiGiuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbLoaiPhong.SelectedIndex = -1;
            cbSoPhong.Items.Clear();
            txtGiaTien.Clear();

            if (cbLoaiGiuong.SelectedItem != null)
            {
                using (var db = new QL_KhachSanEntities())
                {
                    string selectedBedType = cbLoaiGiuong.SelectedItem.ToString();
                    var roomTypes = db.Phongs
                                     .Where(p => p.loaigiuong == selectedBedType)
                                     .Select(p => p.loaiphong)
                                     .Distinct();

                    SetComboBox(cbLoaiPhong, roomTypes);
                }
            }
        }

        private void cbLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbSoPhong.Items.Clear();
            txtGiaTien.Clear();

            if (cbLoaiGiuong.SelectedItem != null && cbLoaiPhong.SelectedItem != null)
            {
                using (var db = new QL_KhachSanEntities())
                {
                    string selectedBedType = cbLoaiGiuong.SelectedItem.ToString();
                    string selectedRoomType = cbLoaiPhong.SelectedItem.ToString();

                    var availableRooms = db.Phongs
                        .Where(p => p.loaigiuong == selectedBedType &&
                                    p.loaiphong == selectedRoomType &&
                                    p.dat == "NO")
                        .Select(p => p.sophong);

                    SetComboBox(cbSoPhong, availableRooms);
                }
            }
        }

        private void cbSoPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSoPhong.SelectedItem != null)
            {
                using (var db = new QL_KhachSanEntities())
                {
                    string selectedRoomNumber = cbSoPhong.SelectedItem.ToString();
                    var room = db.Phongs
                                 .Where(p => p.sophong == selectedRoomNumber)
                                 .Select(p => new { p.gia, p.idphong })
                                 .FirstOrDefault();

                    if (room != null)
                    {
                        txtGiaTien.Text = room.gia.ToString();
                        // rid = room.idphong; // Sử dụng nếu cần
                    }
                }
            }
        }

        private void btnThemKhach_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin khách hàng
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                string.IsNullOrWhiteSpace(txtSoCCCD.Text) ||
                string.IsNullOrWhiteSpace(cbGioiTinh.Text) ||
                string.IsNullOrWhiteSpace(txtQuocTich.Text) ||
                string.IsNullOrWhiteSpace(txtSoDienThoai.Text) ||
                string.IsNullOrWhiteSpace(cbSoPhong.Text) ||
                string.IsNullOrWhiteSpace(txtGiaTien.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Kiểm tra nếu số điện thoại không phải số hoặc độ dài vượt quá 10 ký tự
            if (!txtSoDienThoai.Text.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại chỉ được chứa các ký tự số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Không tiếp tục thêm khách hàng
            }

            // Kiểm tra độ dài số điện thoại
            if (txtSoDienThoai.Text.Length > 10)
            {
                MessageBox.Show("Số điện thoại không được vượt quá 10 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Không tiếp tục thêm khách hàng
            }

            if (!txtSoCCCD.Text.All(char.IsDigit))
            {
                MessageBox.Show("Số CCCD chỉ được chứa các ký tự số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Không tiếp tục thêm khách hàng
            }

            // Kiểm tra độ dài số điện thoại
            if (txtSoCCCD.Text.Length > 12)
            {
                MessageBox.Show("Số CCCD không được vượt quá 12 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Không tiếp tục thêm khách hàng
            }

            try
            {
                using (var db = new QL_KhachSanEntities())
                {
                    // Thêm khách hàng mới
                    var khachHang = new KhachHang
                    {
                        tenkhach = txtHoTen.Text,
                        sodienthoai = txtSoDienThoai.Text,
                        quoctich = txtQuocTich.Text,
                        gioitinh = cbGioiTinh.Text,
                        ngaysinh = txtDob.Text.ToString(),  // Gán DateTime trực tiếp từ DateTimePicker
                        cccd = txtSoCCCD.Text,
                        diachi = txtDiaChi.Text,
                        checkin = txtCheckin.Text.ToString(),  // Gán DateTime trực tiếp từ DateTimePicker
                        thanhtoan = "NO",
                        idphong = db.Phongs
                            .Where(p => p.sophong == cbSoPhong.Text)
                            .Select(p => p.idphong)
                            .FirstOrDefault()
                    };

                    // Thêm khách hàng vào cơ sở dữ liệu
                    db.KhachHangs.Add(khachHang);

                    // Cập nhật trạng thái phòng
                    var phong = db.Phongs.FirstOrDefault(p => p.sophong == cbSoPhong.Text);
                    if (phong != null)
                    {
                        phong.dat = "YES";  // Đánh dấu phòng đã được đặt
                    }

                    db.SaveChanges();
                    MessageBox.Show($"Số phòng {cbSoPhong.Text} đăng ký khách hàng thành công.", "Thông báo");

                    // Làm mới giao diện
                    LoadBedTypes();
                    cbLoaiPhong.SelectedIndex = -1;
                    cbGioiTinh.SelectedIndex = -1;
                    txtGiaTien.Clear();
                    txtHoTen.Clear();
                    txtDiaChi.Clear();
                    txtSoCCCD.Clear();
                    txtQuocTich.SelectedIndex = -1; 
                    txtSoDienThoai.Clear();
                    txtDob.Value = DateTime.Now;
                    cbLoaiGiuong.SelectedIndex = -1; // Không chọn mục nào
                    cbLoaiGiuong.Items.Clear();
                    cbSoPhong.SelectedIndex = -1; // Không chọn mục nào
                    cbSoPhong.Items.Clear();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Hiển thị danh sách nhân viên trong DataGridView
        public void SetKhachHang(DataGridView dgv)
        {
            using (var db = new QL_KhachSanEntities())
            {
                var khachhangList = db.KhachHangs
                    .Select(kh => new
                    {
                        kh.idkhach,
                        kh.tenkhach,
                        kh.sodienthoai,
                        kh.quoctich,
                        kh.gioitinh,
                        kh.ngaysinh,
                        kh.cccd,
                        kh.diachi,
                        kh.Phong.sophong
            })
                    .ToList();

                dgv.DataSource = khachhangList;
            }
            int tongkhachhang = dgvKhachHang.Rows.Cast<DataGridViewRow>().Count(row => row.Cells["idkhach"].Value != null);

            lbtongkhach.Text = $"Tổng số khách hàng: {tongkhachhang}";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            tbHoTen.Clear();
            tbDiaChi.Clear();
            tbSoCCCD.Clear();
            tbSoDienThoai.Clear();
            cbGTinh.SelectedIndex= -1;
            cbQuocTich.SelectedIndex= -1;
            tbSoPhong.Clear();
        }

        private void tabKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabKhachHang.SelectedIndex == 1)
            {
                SetKhachHang(dgvKhachHang);
            }
        }

        private void dgvKhachHang_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow.Index != -1)
            {
                kh.idkhach = Convert.ToInt32(dgvKhachHang.CurrentRow.Cells["idkhach"].Value);
                using (QL_KhachSanEntities db = new QL_KhachSanEntities())
                {
                    kh = db.KhachHangs.Where(x => x.idkhach == kh.idkhach).FirstOrDefault();
                    tbHoTen.Text = kh.tenkhach;
                    tbSoDienThoai.Text = kh.sodienthoai;
                    cbQuocTich.Text = kh.quoctich;
                    cbGTinh.Text = kh.gioitinh;
                    dtpNgaySinh.Text = kh.ngaysinh;
                    tbSoCCCD.Text = kh.cccd;
                    tbDiaChi.Text = kh.diachi;
                    tbSoPhong.Text = kh.Phong.sophong;

                }
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbHoTen.Text != "" && tbSoDienThoai.Text != "" && cbQuocTich.Text != "" && cbGTinh.Text != "" && tbSoCCCD.Text != "" && tbDiaChi.Text != "")
                {
                    
                    
                    
                    if (!tbSoDienThoai.Text.All(char.IsDigit))
                    {
                        MessageBox.Show("Số điện thoại chỉ được chứa các ký tự số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Không tiếp tục thêm khách hàng
                    }


                    if (tbSoDienThoai.Text.Length > 10 || !tbSoDienThoai.Text.All(char.IsDigit))
                    {
                        MessageBox.Show("Số điện thoại chỉ được chứa các ký tự số và không vượt quá 10 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!tbSoCCCD.Text.All(char.IsDigit))
                    {
                        MessageBox.Show("Số CCCD chỉ được chứa các ký tự số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Không tiếp tục thêm khách hàng
                    }

                    // Kiểm tra độ dài số điện thoại
                    if (tbSoCCCD.Text.Length > 12)
                    {
                        MessageBox.Show("Số CCCD không được vượt quá 12 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Không tiếp tục thêm khách hàng
                    }

                    using (QL_KhachSanEntities db = new QL_KhachSanEntities())
                    {
                        kh.tenkhach = tbHoTen.Text;
                        kh.sodienthoai = tbSoDienThoai.Text;
                        kh.quoctich = cbQuocTich.Text;
                        kh.gioitinh = cbGTinh.Text;
                        kh.ngaysinh = dtpNgaySinh.Text;
                        kh.cccd = tbSoCCCD.Text;
                        kh.diachi = tbDiaChi.Text;
                        db.Entry(kh).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                    SetKhachHang(dgvKhachHang);
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void clear()
        {
            tbHoTen.Clear();
            tbDiaChi.Clear();
            tbSoCCCD.Clear();
            tbSoDienThoai.Clear();
            cbGTinh.SelectedIndex = -1;
            cbQuocTich.SelectedIndex = -1;
            tbSoPhong.Clear();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa khách hàng này không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (QL_KhachSanEntities db = new QL_KhachSanEntities())
                    {
                        var entry = db.Entry(kh);
                        if (entry.State == EntityState.Detached)
                        {
                            db.KhachHangs.Attach(kh);
                        }


                        db.KhachHangs.Remove(kh);

                        var phong = db.Phongs.FirstOrDefault(p => p.sophong == tbSoPhong.Text);
                        if (phong != null)
                        {
                            phong.dat = "NO";
                        }
                        db.SaveChanges();
                        SetKhachHang(dgvKhachHang);
                        btnSua.Enabled = false;
                        btnXoa.Enabled = false;
                        clear();
                        MessageBox.Show("Xóa thành công", "Thông báo");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
