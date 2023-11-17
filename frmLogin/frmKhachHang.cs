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
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }
        KhachHangDao kh = new KhachHangDao();
        private BindingSource bindingSource;
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
           
            loadDSKhachHang();
            bindingSource = new BindingSource();
            bindingSource.DataSource = dgv1.DataSource;

            // Gán BindingSource cho DataGridView
            dgv1.DataSource = bindingSource;
        }

        private void loadDSKhachHang()
        {
            dgv1.DataSource = kh.GetKhachHangList();
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = e.RowIndex;
                if (rowindex == -1 || rowindex >= dgv1.Rows.Count - 1)
                {
                    throw new Exception("Chưa chọn khách hàng");
                }
                txtMaKH.Text = dgv1.Rows[rowindex].Cells["MaKH"].Value.ToString();
                txtTenKH.Text = dgv1.Rows[rowindex].Cells["TenKH"].Value.ToString();
                txtDiachi.Text = dgv1.Rows[rowindex].Cells["DiaChi"].Value.ToString();
                txtSdt.Text = dgv1.Rows[rowindex].Cells["SoDienThoai"].Value.ToString();
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
               
                string tenKH = txtTenKH.Text;
                string diaChi = txtDiachi.Text;
                string soDienThoai = txtSdt.Text;

              
                if (string.IsNullOrEmpty(tenKH) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(soDienThoai))
                {
                    throw new Exception("Vui lòng nhập đầy đủ thông tin khách hàng.");
                }
                if (!int.TryParse(txtMaKH.Text, out int maKH))
                {
                    throw new Exception("Mã KH không hợp lệ.");
                }
                KhachHang kh1 = new KhachHang(maKH, tenKH, diaChi, soDienThoai);
                kh.InsertKhachHang(kh1);
                loadDSKhachHang();
                MessageBox.Show("Thêm KH mới thành công", "Thông báo");
               
            }   
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaKH.Enabled = false;
            try
            {

                if (string.IsNullOrEmpty(txtMaKH.Text))
                {
                    throw new Exception("Chưa chọn khách hàng cần sửa.");
                }
                int maKH = int.Parse(txtMaKH.Text);
                string tenKH = txtTenKH.Text;
                string diaChi = txtDiachi.Text;
                string soDienThoai = txtSdt.Text;
                if (string.IsNullOrEmpty(tenKH) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(soDienThoai))
                {
                    throw new Exception("Vui lòng nhập đầy đủ thông tin khách hàng.");
                }
                KhachHang kh2 = new KhachHang(maKH, tenKH, diaChi, soDienThoai);
                kh.UpdateKhachHang(kh2);
                loadDSKhachHang();
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
                int maKH = int.Parse(txtMaKH.Text);
                if (string.IsNullOrEmpty(txtMaKH.Text))
                {
                    throw new Exception("Chưa chọn khách hàng cần xóa.");
                }
                
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    kh.DeleteKhachHang(maKH);
                    loadDSKhachHang(); 
                    MessageBox.Show("Xóa KH thành công", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
               
                string filterCondition = "";

                if (!string.IsNullOrEmpty(txtTimKiem.Text))
                {
                    filterCondition += $"TenKH LIKE '%{txtTimKiem.Text}%'";
                }
              
                bindingSource.Filter = filterCondition;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

