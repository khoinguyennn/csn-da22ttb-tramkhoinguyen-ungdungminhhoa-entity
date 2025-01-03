using OfficeOpenXml.Style;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKhachSan_EF
{
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now.AddMonths(-1); // Mặc định từ 1 tháng trước
            dtpTo.Value = DateTime.Now; // Mặc định đến hôm nay
            cboThoiGian.Items.AddRange(new string[] { "Ngày", "Tháng", "Năm" }); // Các tùy chọn thời gian
            cboThoiGian.SelectedIndex = 0; // Chọn "Ngày" mặc định
            dgvThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThongKe.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Tự động điều chỉnh chiều cao
            dgvThongKe.DefaultCellStyle.WrapMode = DataGridViewTriState.True;   // Cho phép nội dung xuống dòng                                             

        }



        private void btnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new QL_KhachSanEntities())
                {
                    // Lấy khoảng thời gian từ DateTimePicker
                    DateTime fromDate = dtpFrom.Value.Date;
                    DateTime toDate = dtpTo.Value.Date;

                    // Lấy tất cả khách hàng từ cơ sở dữ liệu
                    var khachHangList = db.KhachHangs
                        .Where(k => k.checkout != null && k.thanhtoan == "YES")
                        .ToList();

                    // Lọc và chuyển đổi dữ liệu ngoài LINQ
                    var doanhThuChiTiet = khachHangList
                        .Where(k => DateTime.TryParse(k.checkout, out DateTime ngayThanhToan) &&
                                    ngayThanhToan >= fromDate &&
                                    ngayThanhToan <= toDate)
                        .Select(k => new
                        {
                            NgayThanhToan = DateTime.Parse(k.checkout),
                            TenKhachHang = k.tenkhach,
                            SoPhong = k.Phong.sophong,
                            LoaiPhong = k.Phong.loaiphong,
                            GiaPhong = k.Phong.gia
                        }).ToList();

                    // Lọc theo loại thời gian
                    string thoiGian = cboThoiGian.SelectedItem.ToString();
                    if (thoiGian == "Ngày")
                    {
                        // Hiển thị chi tiết từng khách hàng
                        dgvThongKe.DataSource = doanhThuChiTiet;
                    }
                    else if (thoiGian == "Tháng")
                    {
                        // Nhóm theo Tháng
                        var doanhThuThang = doanhThuChiTiet
                            .GroupBy(k => new { k.NgayThanhToan.Year, k.NgayThanhToan.Month })
                            .Select(g => new
                            {
                                ThoiGian = $"{g.Key.Year}-{g.Key.Month}",
                                TongDoanhThu = g.Sum(k => k.GiaPhong)
                            }).ToList();

                        dgvThongKe.DataSource = doanhThuThang;
                    }
                    else if (thoiGian == "Năm")
                    {
                        // Nhóm theo Năm
                        var doanhThuNam = doanhThuChiTiet
                            .GroupBy(k => k.NgayThanhToan.Year)
                            .Select(g => new
                            {
                                ThoiGian = g.Key.ToString(),
                                TongDoanhThu = g.Sum(k => k.GiaPhong)
                            }).ToList();

                        dgvThongKe.DataSource = doanhThuNam;
                    }

                    // Tính tổng doanh thu
                    decimal tongDoanhThu = doanhThuChiTiet.Sum(k => k.GiaPhong);
                    lblTongDoanhThu.Text = $"Tổng doanh thu: {tongDoanhThu:C}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvThongKe.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "ThongKeDoanhThu.xlsx" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        // Thiết lập LicenseContext
                        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                        using (ExcelPackage excel = new ExcelPackage())
                        {
                            var ws = excel.Workbook.Worksheets.Add("Doanh Thu");

                            // Tiêu đề báo cáo
                            ws.Cells["A1"].Value = "Báo cáo thống kê doanh thu";
                            ws.Cells["A1"].Style.Font.Size = 16;
                            ws.Cells["A1"].Style.Font.Bold = true;
                            ws.Cells["A1:D1"].Merge = true;
                            ws.Cells["A1:D1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                            // Ghi tiêu đề cột
                            for (int i = 0; i < dgvThongKe.Columns.Count; i++)
                            {
                                ws.Cells[3, i + 1].Value = dgvThongKe.Columns[i].HeaderText;
                                ws.Cells[3, i + 1].Style.Font.Bold = true;
                                ws.Cells[3, i + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            }

                            // Ghi dữ liệu từ DataGridView
                            for (int i = 0; i < dgvThongKe.Rows.Count; i++)
                            {
                                for (int j = 0; j < dgvThongKe.Columns.Count; j++)
                                {
                                    if (dgvThongKe.Columns[j].HeaderText.Contains("Ngày TT") || dgvThongKe.Columns[j].HeaderText.Contains("NgayThanhToan"))
                                    {
                                        // Chỉ định định dạng ngày
                                        if (DateTime.TryParse(dgvThongKe.Rows[i].Cells[j].Value?.ToString(), out DateTime parsedDate))
                                        {
                                            ws.Cells[i + 4, j + 1].Value = parsedDate.ToString("dd/MM/yyyy"); // Định dạng ngày tháng năm
                                        }
                                        else
                                        {
                                            ws.Cells[i + 4, j + 1].Value = dgvThongKe.Rows[i].Cells[j].Value?.ToString(); // Giá trị không hợp lệ
                                        }
                                    }
                                    else
                                    {
                                        ws.Cells[i + 4, j + 1].Value = dgvThongKe.Rows[i].Cells[j].Value?.ToString();
                                    }

                                    ws.Cells[i + 4, j + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                                }
                            }

                            // Tính tổng doanh thu
                            int lastRow = dgvThongKe.Rows.Count + 4; // Vị trí dòng tổng
                            ws.Cells[lastRow, 1].Value = "Tổng doanh thu:";
                            ws.Cells[lastRow, 1].Style.Font.Bold = true;
                            ws.Cells[lastRow, 1, lastRow, dgvThongKe.Columns.Count - 1].Merge = true;
                            ws.Cells[lastRow, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                            // Tính tổng cột "Doanh thu" hoặc cột chứa số tiền
                            int doanhThuColumnIndex = dgvThongKe.Columns.Cast<DataGridViewColumn>()
                                .FirstOrDefault(c => c.HeaderText.Contains("Doanh thu") || c.HeaderText.Contains("Giá"))?.Index + 1 ?? 0;

                            if (doanhThuColumnIndex > 0)
                            {
                                // Chuyển dữ liệu cột doanh thu thành kiểu số
                                for (int i = 0; i < dgvThongKe.Rows.Count; i++)
                                {
                                    var value = dgvThongKe.Rows[i].Cells[doanhThuColumnIndex - 1].Value;
                                    if (value != null && decimal.TryParse(value.ToString(), out decimal result))
                                    {
                                        ws.Cells[i + 4, doanhThuColumnIndex].Value = result; // Ghi lại giá trị dạng số
                                    }
                                    else
                                    {
                                        ws.Cells[i + 4, doanhThuColumnIndex].Value = 0; // Nếu không phải số, gán giá trị 0
                                    }
                                }

                                // Áp dụng công thức tính tổng
                                ws.Cells[lastRow, doanhThuColumnIndex].Formula = $"SUM({ws.Cells[4, doanhThuColumnIndex].Address}:{ws.Cells[lastRow - 1, doanhThuColumnIndex].Address})";
                                ws.Cells[lastRow, doanhThuColumnIndex].Style.Font.Bold = true;
                                ws.Cells[lastRow, doanhThuColumnIndex].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            }

                            ws.Cells[ws.Dimension.Address].AutoFitColumns();

                            // Lưu file Excel
                            FileInfo excelFile = new FileInfo(sfd.FileName);
                            excel.SaveAs(excelFile);
                        }

                        MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi xuất báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}