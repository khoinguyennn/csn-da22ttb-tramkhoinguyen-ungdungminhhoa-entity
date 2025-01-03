 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;


namespace QLKhachSan_EF
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
            GetMaxID();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            dgvTTNV.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgvTTNV.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgvTTNV2.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgvTTNV2.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
        }

        // Lấy ID lớn nhất từ bảng NhanVien
        public void GetMaxID()
        {
            using (var db = new QL_KhachSanEntities())
            {
                var maxID = db.NhanViens.Max(nv => (int?)nv.idnv) ?? 0;
                labelToSet.Text = (maxID + 1).ToString();
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem các trường có trống không
            if (txtHoTen.Text != "" && txtSoDienThoai.Text != "" && txtEmail.Text != "" && cbGioiTinh.Text != "" && txtTaiKhoan.Text != "" && txtMatKhau.Text != "" && cbLoai.Text != "")
            {
                string hoTen = txtHoTen.Text;
                string soDienThoai = txtSoDienThoai.Text;
                string gioiTinh = cbGioiTinh.Text;
                string email = txtEmail.Text;
                string taiKhoan = txtTaiKhoan.Text;
                string matKhau = HashPassword(txtMatKhau.Text); // Mã hóa mật khẩu
                string loaiNguoiDung = cbLoai.Text;

                // Kiểm tra số điện thoại hợp lệ
                if (soDienThoai.Length > 10 || !soDienThoai.All(char.IsDigit))
                {
                    MessageBox.Show("Số điện thoại chỉ được chứa các ký tự số và không vượt quá 10 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra email hợp lệ
                if (!email.Contains("@") || !email.Contains("."))
                {
                    MessageBox.Show("Email không hợp lệ. Vui lòng nhập lại email đúng định dạng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra tài khoản không chứa ký tự có dấu
                if (taiKhoan.Any(c => "áàảãạăắặẳẵâấầẩẫậéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵđ".Contains(c)))
                {
                    MessageBox.Show("Tài khoản không được chứa ký tự có dấu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thêm nhân viên vào cơ sở dữ liệu
                using (var db = new QL_KhachSanEntities())
                {
                    var nhanVien = new NhanVien
                    {
                        tennv = hoTen,
                        sodienthoainv = soDienThoai,
                        gioitinhnv = gioiTinh,
                        email = email,
                        username = taiKhoan,
                        pass = matKhau, // Lưu mật khẩu đã mã hóa
                        loainguoidung = loaiNguoiDung
                    };

                    db.NhanViens.Add(nhanVien);
                    db.SaveChanges();
                }

                MessageBox.Show("Đăng ký nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa dữ liệu trong các trường nhập liệu sau khi đăng ký thành công
                ClearAll();
                GetMaxID();
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        // Xóa tất cả dữ liệu trên form
        public void ClearAll()
        {
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            cbGioiTinh.SelectedIndex = -1;
            txtEmail.Clear();
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
            cbLoai.SelectedIndex = -1;
        }

        private void tabNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabNhanVien.SelectedIndex == 1)
            {
                SetNhanVien(dgvTTNV);
            }
            else if (tabNhanVien.SelectedIndex == 2)
            {
                SetNhanVien(dgvTTNV2);
            }
        }

        // Hiển thị danh sách nhân viên trong DataGridView
        public void SetNhanVien(DataGridView dgv)
        {
            using (var db = new QL_KhachSanEntities())
            {
                var nhanVienList = db.NhanViens
                    .Select(nv => new
                    {
                        nv.idnv,
                        nv.tennv,
                        nv.sodienthoainv,
                        nv.gioitinhnv,
                        nv.email,
                        nv.username,
                        nv.pass,
                        nv.loainguoidung
                    })
                    .ToList();

                dgv.DataSource = nhanVienList;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtID.Text))
            {
                if (MessageBox.Show("Bạn có chắc chắn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int id = int.Parse(txtID.Text);

                    using (var db = new QL_KhachSanEntities())
                    {
                        var nhanVien = db.NhanViens.Find(id);
                        if (nhanVien != null)
                        {
                            db.NhanViens.Remove(nhanVien);
                            db.SaveChanges();
                            MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            tabNhanVien_SelectedIndexChanged(this, null); // Cập nhật lại dữ liệu
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        private void frmNhanVien_Leave(object sender, EventArgs e)
        {
            ClearAll();
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2")); // Chuyển byte sang chuỗi hex
                }
                return builder.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
