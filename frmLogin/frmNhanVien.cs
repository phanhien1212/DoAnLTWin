using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmLogin
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        NhanVienDao nv = new NhanVienDao();
        private BindingSource bindingSource;
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            loadDSNhanVien();
        }
        private void loadDSNhanVien()
        {
            dgv1.DataSource = nv.GetNhanVienList();
            bindingSource = new BindingSource();
            bindingSource.DataSource = dgv1.DataSource;

            // Gán BindingSource cho DataGridView
            dgv1.DataSource = bindingSource;
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = e.RowIndex;
                if (rowindex == -1 || rowindex >= dgv1.Rows.Count - 1)
                {
                    throw new Exception("Chưa chọn nhân viên");
                }
                txtMaNV.Text = dgv1.Rows[rowindex].Cells["MaNV"].Value.ToString();
                txtTenNV.Text = dgv1.Rows[rowindex].Cells["TenNV"].Value.ToString();
                txtDiaChi.Text = dgv1.Rows[rowindex].Cells["DiaChi"].Value.ToString();
                txtSdt.Text = dgv1.Rows[rowindex].Cells["SoDienThoai"].Value.ToString();
                txtEmail.Text = dgv1.Rows[rowindex].Cells["Email"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các TextBox
                string tenNV = txtTenNV.Text;
                string diaChi = txtDiaChi.Text;
                string soDienThoai = txtSdt.Text;
                string email = txtEmail.Text;
                // Kiểm tra tính hợp lệ của dữ liệu (có thể thêm kiểm tra thêm)
                if (string.IsNullOrEmpty(tenNV) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(soDienThoai) || string.IsNullOrEmpty(email))
                {
                    throw new Exception("Vui lòng nhập đầy đủ thông tin khách hàng.");
                }
                if (!int.TryParse(txtMaNV.Text, out int maNV))
                {
                    throw new Exception("Mã KH không hợp lệ.");
                }
                NhanVien nv1 = new NhanVien(maNV, tenNV, diaChi, soDienThoai, email);
                nv.InsertNhanVien(nv1);
                loadDSNhanVien();
                MessageBox.Show("Thêm NV mới thành công", "Thông báo");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaNV.Enabled = false;
            try
            {

                if (string.IsNullOrEmpty(txtMaNV.Text))
                {
                    throw new Exception("Chưa chọn khách hàng cần sửa.");
                }
                int maNV = int.Parse(txtMaNV.Text);
                string tenNV = txtTenNV.Text;
                string diaChi = txtDiaChi.Text;
                string soDienThoai = txtSdt.Text;
                string email = txtEmail.Text;
                if (string.IsNullOrEmpty(tenNV) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(soDienThoai))
                {
                    throw new Exception("Vui lòng nhập đầy đủ thông tin khách hàng.");
                }
                NhanVien nv2 = new NhanVien(maNV, tenNV, diaChi, soDienThoai,email);
                nv.UpdateNhanVien(nv2);
                loadDSNhanVien();
                MessageBox.Show("Sửa KH thành công", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int maNV = int.Parse(txtMaNV.Text);
                if (string.IsNullOrEmpty(txtMaNV.Text))
                {
                    throw new Exception("Chưa chọn nhân viên cần xóa.");
                }

                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    nv.DeleteNhanVien(maNV);
                    loadDSNhanVien();
                    MessageBox.Show("Xóa NV thành công", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra điều kiện tìm kiếm
                string searchCondition = $"TenNV LIKE '%{txtTimKiem.Text}%'";

                // Áp dụng điều kiện tìm kiếm
                bindingSource.Filter = searchCondition;

                // Nếu bạn muốn xóa điều kiện tìm kiếm, hãy sử dụng:
                // bindingSource.RemoveFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra điều kiện lọc
                string filterCondition = "";

                if (!string.IsNullOrEmpty(txtTimKiem.Text))
                {
                    filterCondition += $"TenNV LIKE '%{txtTimKiem.Text}%'";
                }

                // Áp dụng điều kiện lọc
                bindingSource.Filter = filterCondition;

                // Nếu bạn muốn xóa điều kiện lọc, hãy sử dụng:
                // bindingSource.RemoveFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
