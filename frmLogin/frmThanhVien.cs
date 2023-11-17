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
    public partial class frmThanhVien : Form
    {
        public frmThanhVien()
        {
            InitializeComponent();
        }
        ThanhVienDao tv = new ThanhVienDao();
        private BindingSource bindingSource;
        private void frmThanhVien_Load(object sender, EventArgs e)
        {
            loadDSThanhVien();
        }
        private void loadDSThanhVien()
        {
            dgv1.DataSource = tv.GetThanhVienList();
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
                    throw new Exception("Chưa chọn thành viên");
                }
                txtMaTV.Text = dgv1.Rows[rowindex].Cells["MaTV"].Value.ToString();
                txtTenTV.Text = dgv1.Rows[rowindex].Cells["TenTV"].Value.ToString();
                txtDiaChi.Text = dgv1.Rows[rowindex].Cells["DiaChi"].Value.ToString();
                txtSdt.Text = dgv1.Rows[rowindex].Cells["SoDienThoai"].Value.ToString();
                txtEmail.Text = dgv1.Rows[rowindex].Cells["Email"].Value.ToString();
                txtPassword.Text = dgv1.Rows[rowindex].Cells["Password"].Value.ToString();
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
                string tenTV = txtTenTV.Text;
                string diaChi = txtDiaChi.Text;
                string soDienThoai = txtSdt.Text;
                string email = txtEmail.Text;
                string password = txtPassword.Text;
                // Kiểm tra tính hợp lệ của dữ liệu (có thể thêm kiểm tra thêm)
                if (string.IsNullOrEmpty(tenTV) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(soDienThoai) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    throw new Exception("Vui lòng nhập đầy đủ thông tin thành viên.");
                }
                if (!int.TryParse(txtMaTV.Text, out int maTV))
                {
                    throw new Exception("Mã KH không hợp lệ.");
                }
                ThanhVien tv1 = new ThanhVien(maTV, tenTV, diaChi, soDienThoai, email, password);
                tv.InsertThanhVien(tv1);
                loadDSThanhVien();
                MessageBox.Show("Thêm TV mới thành công", "Thông báo");

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
                int maTV = int.Parse(txtMaTV.Text);
                if (string.IsNullOrEmpty(txtMaTV.Text))
                {
                    throw new Exception("Chưa chọn thành viên cần xóa.");
                }

                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa thành viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    tv.DeleteThanhVien(maTV);
                    loadDSThanhVien();
                    MessageBox.Show("Xóa TV thành công", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaTV.Enabled = false;
            try
            {

                if (string.IsNullOrEmpty(txtMaTV.Text))
                {
                    throw new Exception("Chưa chọn khách hàng cần sửa.");
                }
                int maTV = int.Parse(txtMaTV.Text);
                string tenTV = txtTenTV.Text;
                string diaChi = txtDiaChi.Text;
                string soDienThoai = txtSdt.Text;
                string email = txtEmail.Text;
                string password = txtPassword.Text;
                if (string.IsNullOrEmpty(tenTV) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(soDienThoai) || string.IsNullOrEmpty(password))
                {
                    throw new Exception("Vui lòng nhập đầy đủ thông tin khách hàng.");
                }
                ThanhVien tv2 = new ThanhVien(maTV, tenTV, diaChi, soDienThoai, email, password);
                tv.UpdateThanhVien(tv2);
                loadDSThanhVien();
                MessageBox.Show("Sửa TV thành công", "Thông báo");
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
                    filterCondition += $"TenTV LIKE '%{txtTimKiem.Text}%'";
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
