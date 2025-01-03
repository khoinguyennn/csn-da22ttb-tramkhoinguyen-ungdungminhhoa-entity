using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKhachSan_EF
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        void checkLogin()
        {
            using (var db = new QL_KhachSanEntities())
            {
                string username = tbTaiKhoan.Text;
                string password = HashPassword(tbMatKhau.Text); // Hàm mã hóa SHA-256

                // Kiểm tra thông tin đăng nhập
                var nhanVien = db.NhanViens
                    .FirstOrDefault(nv => nv.username == username && nv.pass == password);

                if (nhanVien != null)
                {
                    // Nếu đúng thông tin đăng nhập, lấy loại người dùng
                    string loaiNguoiDung = nhanVien.loainguoidung;

                    // Truyền loại người dùng sang form chính
                    frmTrangChinh dash = new frmTrangChinh
                    {
                        LoaiNguoiDung = loaiNguoiDung
                    };

                    this.Hide();
                    dash.Show();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkLogin();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Hàm mã hóa mật khẩu bằng SHA-256
        /// </summary>
        /// <param name="password">Mật khẩu gốc</param>
        /// <returns>Mã băm SHA-256</returns>
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);

                // Chuyển đổi byte[] sang chuỗi Hexadecimal
                StringBuilder result = new StringBuilder();
                foreach (byte b in hash)
                {
                    result.Append(b.ToString("x2"));
                }
                return result.ToString();
            }
        }
    }
}