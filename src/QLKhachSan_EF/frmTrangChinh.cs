using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKhachSan_EF
{
    public partial class frmTrangChinh : Form
    {
        public string LoaiNguoiDung { get; set; } // Thuộc tính lưu loại người dùng

        private Form activeForm = null; // Biến lưu trữ form con hiện tại

        public frmTrangChinh()
        {
            InitializeComponent();
        }

        // Phương thức mở form con trong panelContent
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close(); // Đóng form con hiện tại nếu có

            activeForm = childForm; // Gán form con mới vào biến activeForm
            childForm.TopLevel = false; // Đặt form con không phải form cấp cao nhất
            childForm.FormBorderStyle = FormBorderStyle.None; // Bỏ viền form
            childForm.Dock = DockStyle.Fill; // Dock form con vào panel
            panelContent.Controls.Add(childForm); // Thêm form con vào panel
            panelContent.Tag = childForm;
            childForm.BringToFront(); // Đưa form con lên phía trước
            childForm.Show(); // Hiển thị form con
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThongKe()); // Mở form Thống Kê trong panelContent
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThemPhong()); // Mở form Thêm Phòng trong panelContent
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDangKyKhach()); // Mở form Đăng Ký Khách trong panelContent
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThanhToan()); // Mở form Thanh Toán trong panelContent
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThongTinKhach()); // Mở form Thông Tin Khách trong panelContent
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhanVien()); // Mở form Nhân Viên trong panelContent
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất không?", "Xác Nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                frmDangNhap dangNhap = new frmDangNhap();
                dangNhap.Show();
                this.Close();
            }
        }

        private void frmTrangChinh_Load(object sender, EventArgs e)
        {
            // Kiểm tra loại người dùng và bật/tắt button5
            if (LoaiNguoiDung != "Quản Lý") // Nếu không phải Quản Lý
            {
                button5.Enabled = false; // Vô hiệu hóa nút quản lý nhân viên
            }
        }

    }
}
