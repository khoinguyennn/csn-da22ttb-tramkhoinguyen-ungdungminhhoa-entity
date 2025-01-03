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
    public partial class frmThongTinKhach : Form
    {
        public frmThongTinKhach()
        {
            InitializeComponent();
        }

        private void txtTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var db = new QL_KhachSanEntities())
            {
                var query = db.KhachHangs.Select(k => new
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
                    gia = k.Phong.gia,
                    k.checkout
                });

                // Lọc dữ liệu dựa trên lựa chọn
                if (txtTimKiem.SelectedIndex == 0) // Tất cả khách hàng
                {
                    dgvThongTinKhach.DataSource = query.ToList();
                }
                else if (txtTimKiem.SelectedIndex == 1) // Chưa checkout
                {
                    var filteredData = query.Where(k => k.checkout == null).ToList();
                    dgvThongTinKhach.DataSource = filteredData;
                }
                else if (txtTimKiem.SelectedIndex == 2) // Đã checkout
                {
                    var filteredData = query.Where(k => k.checkout != null).ToList();
                    dgvThongTinKhach.DataSource = filteredData;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}