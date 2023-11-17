using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace frmLogin
{
    public partial class frmChiTietHoaDon : Form
    {
        public frmChiTietHoaDon()
        {
            InitializeComponent();
        }

        ChiTietHoaDonDao cthd = new ChiTietHoaDonDao();
        SanPhamDao sp = new SanPhamDao();
        KhachHangDao kh = new KhachHangDao();
        NhanVienDao nv = new NhanVienDao();
        private DataTable dataTable;
        private void frmChiTietHoaDon_Load(object sender, EventArgs e)
        {
            // Khởi tạo DataTable và cài đặt cột
            dataTable = new DataTable();
            dataTable.Columns.Add("TenSP", typeof(string));
            dataTable.Columns.Add("MaKH", typeof(string));
            dataTable.Columns.Add("TenKH", typeof(string));
            dataTable.Columns.Add("SoLuong", typeof(int));
            dataTable.Columns.Add("Gia", typeof(float));
            dataTable.Columns.Add("ThanhTien", typeof(float));

            // Gán DataTable làm nguồn dữ liệu cho DataGridView
            dgv1.DataSource = dataTable;
            loadDSChiTietHoaDon();
            loadDSTenSP();
            loadDSMaTenKH();
            loadDSTenNV();
        }
        private void loadDSChiTietHoaDon()
        {
            dgv1.DataSource = cthd.GetChiTietHoaDonList();
        }
        private void loadDSTenSP()
        {
            cbTenSP.DataSource = sp.GetSanPhamList();
            cbTenSP.DisplayMember = "TenSP";

        }
        private void loadDSMaTenKH()
        {
            cbMaKH.DataSource = kh.GetKhachHangList();
            cbMaKH.DisplayMember = "MaKH";
            cbTenKH.DataSource = kh.GetKhachHangList();
            cbTenKH.DisplayMember = "TenKH";
        }
        private void loadDSTenNV()
        {
            cbTenNV.DataSource = nv.GetNhanVienList();
            cbTenNV.DisplayMember = "TenNV";
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = e.RowIndex;
                if (rowindex == -1 || rowindex >= dgv1.Rows.Count - 1)
                {
                    throw new Exception("Chưa chọn chi tiết hóa đơn");
                }
                cbTenSP.Text = dgv1.Rows[rowindex].Cells["TenSP"].Value.ToString();
                cbMaKH.Text = dgv1.Rows[rowindex].Cells["MaKH"].Value.ToString();
                cbTenKH.Text = dgv1.Rows[rowindex].Cells["TenKH"].Value.ToString();
                txtSoLuong.Text = dgv1.Rows[rowindex].Cells["SoLuong"].Value.ToString();
                txtGia.Text = dgv1.Rows[rowindex].Cells["Gia"].Value.ToString();
                txtThanhTien.Text = dgv1.Rows[rowindex].Cells["ThanhTien"].Value.ToString();
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
                // Lấy dữ liệu từ TextBox và ComboBox
                string tenSP = cbTenSP.Text;
                string maKH = cbMaKH.Text;
                string tenKH = cbTenKH.Text;
                int soLuong = int.Parse(txtSoLuong.Text); // Giả sử dữ liệu số lượng là kiểu số nguyên
                decimal gia = decimal.Parse(txtGia.Text); // Giả sử dữ liệu giá là kiểu số thập phân

                // Thêm dữ liệu vào DataTable
                dataTable.Rows.Add(tenSP, maKH, tenKH, soLuong, gia, soLuong * gia);

                // Xóa dữ liệu từ TextBox sau khi thêm
                ClearTextBoxes();

                MessageBox.Show("Dữ liệu đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearTextBoxes()
        {
            throw new NotImplementedException();
        }

        private void cbTenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string tenSP = cbTenSP.Text;
                string maKH = cbMaKH.Text;
                string tenKH = cbTenKH.Text;
                int soLuong = int.Parse(txtSoLuong.Text); // Kiểm tra hợp lệ ở đây
                float gia = float.Parse(txtGia.Text); // Kiểm tra hợp lệ ở đây
                float thanhTien = soLuong * gia;
                // Kiểm tra xem đã chọn sản phẩm và khách hàng chưa
                if (string.IsNullOrEmpty(cbTenSP.Text) || string.IsNullOrEmpty(cbMaKH.Text) || string.IsNullOrEmpty(txtSoLuong.Text))
                {
                    throw new Exception("Vui lòng chọn sản phẩm, khách hàng và nhập số lượng.");
                }

                // Lấy thông tin từ các điều khiển
               
                

                // Thêm vào DataGridView
                
                
                loadDSChiTietHoaDon();
                MessageBox.Show("Thêm KH mới thành công", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
    }
}
