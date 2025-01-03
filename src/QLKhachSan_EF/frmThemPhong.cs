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
    public partial class frmThemPhong : Form
    {
        Phong p = new Phong();
        public frmThemPhong()
        {
            InitializeComponent();
            loadDataToGrv();
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            // Chỉ cho phép chọn giá trị trong ComboBox, không thể nhập vào


            // Tắt tính năng nhập liệu (AutoComplete)
            cbLoaiPhong.AutoCompleteMode = AutoCompleteMode.None;
            cbLoaiPhong.AutoCompleteSource = AutoCompleteSource.None;

            cbLoaiGiuong.AutoCompleteMode = AutoCompleteMode.None;
            cbLoaiGiuong.AutoCompleteSource = AutoCompleteSource.None;
        }

        public void ClearAll()
        {
            txtSoPhong.Clear();
            cbLoaiPhong.SelectedIndex = -1;
            cbLoaiGiuong.SelectedIndex = -1;
            txtGiaTien.Clear();
 
        }

        void loadDataToGrv()
        {
            dgvPhong.AutoGenerateColumns = false;
            using (QL_KhachSanEntities db = new QL_KhachSanEntities())
            {
                dgvPhong.DataSource = db.Phongs.ToList();
            }    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSoPhong.Text != "" && cbLoaiPhong.Text != "" && cbLoaiGiuong.Text != "" && txtGiaTien.Text != "")
                {
                    if (!long.TryParse(txtGiaTien.Text, out long giaTien))
                    {
                        MessageBox.Show("Vui lòng nhập giá hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtGiaTien.Focus();
                        return;
                    }

                    using (QL_KhachSanEntities db = new QL_KhachSanEntities())
                    {
                        var existingRoom = db.Phongs.FirstOrDefault(x => x.sophong == txtSoPhong.Text);
                        if (existingRoom != null)
                        {
                            MessageBox.Show("Số phòng này đã tồn tại! Vui lòng nhập số phòng khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        p.sophong = txtSoPhong.Text;
                        p.loaiphong = cbLoaiPhong.Text;
                        p.loaigiuong = cbLoaiGiuong.Text;
                        p.gia = giaTien;
                        p.dat = "NO";

                        db.Phongs.Add(p);
                        db.SaveChanges();
                    }

                    MessageBox.Show("Thêm thành công!", "Thông báo");
                    loadDataToGrv();
                    ClearAll();
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



        private void frmThemPhong_Load(object sender, EventArgs e)
        {

        }

        private void dgvPhong_Click(object sender, EventArgs e)
        {
            if (dgvPhong.CurrentRow.Index != -1)
            {
                p.idphong = Convert.ToInt32(dgvPhong.CurrentRow.Cells["idphong"].Value);
                using (QL_KhachSanEntities db = new QL_KhachSanEntities())
                {
                    p = db.Phongs.Where(x => x.idphong == p.idphong).FirstOrDefault();
                    txtSoPhong.Text = p.sophong;
                    cbLoaiPhong.Text = p.loaiphong;
                    cbLoaiGiuong.Text = p.loaigiuong;
                    txtGiaTien.Text = p.gia.ToString();
                }
                btnDelete.Enabled = true; // Kích hoạt nút xóa khi có dòng được chọn
                btnUpdate.Enabled = true; // Kích hoạt nút cập nhật
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa Phòng này không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (QL_KhachSanEntities db = new QL_KhachSanEntities())
                    {
                        var entry = db.Entry(p);
                        if (entry.State == EntityState.Detached)
                        {
                            db.Phongs.Attach(p);
                        }

                        db.Phongs.Remove(p);
                        db.SaveChanges();
                        loadDataToGrv();
                        MessageBox.Show("Xóa thành công", "Thông báo");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSoPhong.Text != "" && cbLoaiPhong.Text != "" && cbLoaiGiuong.Text != "" && txtGiaTien.Text != "")
                {
                    if (!long.TryParse(txtGiaTien.Text, out long giaTien))
                    {
                        MessageBox.Show("Vui lòng nhập giá hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtGiaTien.Focus();
                        return;
                    }

                    using (QL_KhachSanEntities db = new QL_KhachSanEntities())
                    {
                        var existingRoom = db.Phongs.FirstOrDefault(x => x.sophong == txtSoPhong.Text && x.idphong != p.idphong);
                        if (existingRoom != null)
                        {
                            MessageBox.Show("Số phòng này đã tồn tại! Vui lòng nhập số phòng khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        p.sophong = txtSoPhong.Text;
                        p.loaiphong = cbLoaiPhong.Text;
                        p.loaigiuong = cbLoaiGiuong.Text;
                        p.gia = giaTien;

                        db.Entry(p).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                    loadDataToGrv();
                    ClearAll();
                    btnDelete.Enabled = false;
                    btnUpdate.Enabled = false;
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


        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearAll(); // Xóa dữ liệu trong các Control
            btnDelete.Enabled = false; // Tắt nút Xóa
            btnUpdate.Enabled = false; // Tắt nút Cập nhật
            btnAddRoom.Enabled = true; // Bật nút Thêm phòng (nếu bạn muốn)
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSoPhong.Text != "" && cbLoaiPhong.Text != "" && cbLoaiGiuong.Text != "" && txtGiaTien.Text != "")
                {
                    if (!long.TryParse(txtGiaTien.Text, out long giaTien))
                    {
                        MessageBox.Show("Vui lòng nhập giá hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtGiaTien.Focus();
                        return;
                    }

                    using (QL_KhachSanEntities db = new QL_KhachSanEntities())
                    {
                        if (p.idphong == 0)
                        {
                            var existingRoom = db.Phongs.FirstOrDefault(x => x.sophong == txtSoPhong.Text);
                            if (existingRoom != null)
                            {
                                MessageBox.Show("Số phòng này đã tồn tại! Vui lòng nhập số phòng khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            p.sophong = txtSoPhong.Text;
                            p.loaiphong = cbLoaiPhong.Text;
                            p.loaigiuong = cbLoaiGiuong.Text;
                            p.gia = giaTien;
                            p.dat = "NO";

                            db.Phongs.Add(p);
                            MessageBox.Show("Thêm mới phòng thành công!", "Thông báo");
                        }
                        else
                        {
                            var roomToUpdate = db.Phongs.FirstOrDefault(x => x.idphong == p.idphong);
                            if (roomToUpdate != null)
                            {
                                roomToUpdate.sophong = txtSoPhong.Text;
                                roomToUpdate.loaiphong = cbLoaiPhong.Text;
                                roomToUpdate.loaigiuong = cbLoaiGiuong.Text;
                                roomToUpdate.gia = giaTien;

                                MessageBox.Show("Cập nhật phòng thành công!", "Thông báo");
                            }
                        }

                        db.SaveChanges();
                    }

                    loadDataToGrv();
                    ClearAll();
                    btnDelete.Enabled = false;
                    btnUpdate.Enabled = false;
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


    }
}
