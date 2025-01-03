using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace QLKhachSan_EF
{
    public partial class frmThanhToan : Form
    {
        public frmThanhToan()
        {
            InitializeComponent();
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {

            LoadData();
        }

        private void LoadData(string searchName = "")
        {
            dgvThanhToan.AutoGenerateColumns = false;
            using (var db = new QL_KhachSanEntities())
            {
                // Truy vấn danh sách khách hàng chưa thanh toán
                var query = db.KhachHangs
                    .Where(k => k.thanhtoan == "NO" &&
                                (string.IsNullOrEmpty(searchName) || k.tenkhach.Contains(searchName)))
                    .Select(k => new
                    {
                        k.idkhach,
                        k.tenkhach,
                        k.sodienthoai,
                        k.quoctich,
                        k.gioitinh,
                        k.ngaysinh,
                        k.cccd,
                        k.diachi,
                        k.checkin,
                        sophong = k.Phong.sophong,
                        loaiphong = k.Phong.loaiphong,
                        loaigiuong = k.Phong.loaigiuong,
                        gia = k.Phong.gia
                    }).ToList();

                // Gán dữ liệu vào DataGridView
                dgvThanhToan.DataSource = query;
            }
        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {
            string searchName = txtTen.Text.Trim();
            LoadData(searchName); // Gọi lại LoadData với tên cần tìm kiếm
        }
        int id;
        private void dgvThanhToan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvThanhToan.Rows[e.RowIndex].Cells[e.RowIndex].Value != null)
            {
                id = int.Parse(dgvThanhToan.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtTenKH.Text = dgvThanhToan.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSoPhong.Text = dgvThanhToan.Rows[e.RowIndex].Cells[9].Value.ToString();
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (txtTenKH.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc chắn không?", "Xác Nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    try
                    {
                        using (var db = new QL_KhachSanEntities())
                        {
                            // Lấy khách hàng cần cập nhật
                            var khachHang = db.KhachHangs.FirstOrDefault(k => k.idkhach == id);
                            if (khachHang != null)
                            {
                                // Cập nhật thông tin thanh toán
                                khachHang.thanhtoan = "YES";
                                khachHang.checkout = txtNgayThanhToan.Text.ToString();

                                // Lấy phòng liên quan để cập nhật trạng thái
                                var phong = db.Phongs.FirstOrDefault(p => p.sophong == txtSoPhong.Text);
                                if (phong != null)
                                {
                                    phong.dat = "NO";
                                }

                                // Lưu thay đổi vào cơ sở dữ liệu
                                db.SaveChanges();

                                // Hiển thị thông báo thành công
                                MessageBox.Show("Thanh toán thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Xóa dữ liệu form và tải lại danh sách
                                clearall();
                                LoadData();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy khách hàng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có khách hàng nào được chọn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        } 
            
            public void clearall()
            {
                txtTen.Clear();
                txtTenKH.Clear();
                txtSoPhong.Clear();
                txtNgayThanhToan.ResetText();
            }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
    }

