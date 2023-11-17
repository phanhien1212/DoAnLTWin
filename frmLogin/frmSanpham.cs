using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmLogin
{
    public partial class frmTaiKhoan : Form
    {
        public frmTaiKhoan()
        {
            InitializeComponent();
        }
        SanPhamDao sp = new SanPhamDao();
        private BindingSource bindingSource;
        private void frmSanpham_Load(object sender, EventArgs e)
        {
            loadDSSanPham();
            bindingSource = new BindingSource();
            bindingSource.DataSource = dgvSanPham.DataSource;

            // Gán BindingSource cho DataGridView
            dgvSanPham.DataSource = bindingSource;
        }
        private void loadDSSanPham()
        {
            dgvSanPham.DataSource = sp.GetSanPhamList();
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = e.RowIndex;
                if (rowindex == -1 || rowindex >= dgvSanPham.Rows.Count - 1)
                {
                    throw new Exception("Chưa chọn sản phẩm");
                }

                txtMaSP.Text = dgvSanPham.Rows[rowindex].Cells["MaSP"].Value.ToString();
                txtTenSP.Text = dgvSanPham.Rows[rowindex].Cells["TenSP"].Value.ToString();
                txtSoLuong.Text = dgvSanPham.Rows[rowindex].Cells["SoLuong"].Value.ToString();
                txtGia.Text = dgvSanPham.Rows[rowindex].Cells["Gia"].Value.ToString();
                txtGhiChu.Text = dgvSanPham.Rows[rowindex].Cells["GhiChu"].Value.ToString();
                
                // Lấy dữ liệu hình ảnh từ ô cụ thể
                byte[] imageData = dgvSanPham.Rows[rowindex].Cells["Image"].Value as byte[];

                // Hiển thị hình ảnh trong PictureBox
                DisplayImage(imageData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DisplayImage(byte[] imageData)
        {
            if (imageData != null && imageData.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    // Chuyển đổi mảng byte thành hình ảnh
                    Image image = Image.FromStream(ms);

                    // Hiển thị hình ảnh trong PictureBox
                    pbAnh.Image = image;
                }
            }
            else
            {
                // Nếu không có dữ liệu hình ảnh, có thể hiển thị một hình ảnh mặc định hoặc thông báo khác
                pbAnh.Image = null; // hoặc hiển thị một hình ảnh mặc định
            }
        }
        private string imagePath = "";
        private void btnThem_Click(object sender, EventArgs e)
        {
           
            try
            {
                // Lấy dữ liệu từ các TextBox
                int maSP = Convert.ToInt32(txtMaSP.Text);
                string tenSP = txtTenSP.Text;
                int soLuong = Convert.ToInt32(txtSoLuong.Text);
                float gia = Convert.ToSingle(txtGia.Text);
                string ghiChu = txtGhiChu.Text;

                // Kiểm tra đường dẫn hình ảnh
                if (string.IsNullOrEmpty(imagePath))
                {
                    throw new Exception("Vui lòng chọn một hình ảnh.");
                }

                // Chuyển đổi hình ảnh từ đường dẫn sang mảng byte[]
                byte[] imageData = File.ReadAllBytes(imagePath);

                // Tạo đối tượng SanPham mới
                SanPham newSanPham = new SanPham
                {
                    MaSP = maSP,
                    TenSP = tenSP,
                    SoLuong = soLuong,
                    Gia = gia,
                    Image = imageData, // Gán mảng byte vào cột Image
                    GhiChu = ghiChu
                };
               
                // Thực hiện thêm sản phẩm vào CSDL bằng phương thức InsertSanPham
                SanPhamDao sanPhamDao = new SanPhamDao();
                sanPhamDao.InsertSanPham(newSanPham);

                // Hiển thị thông báo hoặc làm các công việc khác sau khi thêm sản phẩm thành công
                MessageBox.Show("Sản phẩm đã được thêm thành công!", "Thông báo");

                // Load lại danh sách sản phẩm
                loadDSSanPham();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin sản phẩm từ TextBox
                int maSP = Convert.ToInt32(txtMaSP.Text);
                string tenSP = txtTenSP.Text;
                int soLuong = Convert.ToInt32(txtSoLuong.Text);
                float gia = Convert.ToSingle(txtGia.Text);
                string ghiChu = txtGhiChu.Text;

                // Kiểm tra đường dẫn hình ảnh
                if (string.IsNullOrEmpty(imagePath))
                {
                    throw new Exception("Vui lòng chọn một hình ảnh.");
                }

                // Chuyển đổi hình ảnh từ đường dẫn sang mảng byte[]
                byte[] imageData = File.ReadAllBytes(imagePath);

                // Tạo đối tượng SanPham mới
                SanPham updatedSanPham = new SanPham
                {
                    MaSP = maSP,
                    TenSP = tenSP,
                    SoLuong = soLuong,
                    Gia = gia,
                    Image = imageData, // Gán mảng byte vào cột Image
                    GhiChu = ghiChu
                };

                // Thực hiện cập nhật sản phẩm vào CSDL bằng phương thức UpdateSanPham
                SanPhamDao sanPhamDao = new SanPhamDao();
                sanPhamDao.UpdateSanPham(updatedSanPham);

                // Hiển thị thông báo hoặc làm các công việc khác sau khi cập nhật sản phẩm thành công
                MessageBox.Show("Sản phẩm đã được cập nhật thành công!", "Thông báo");

                // Load lại danh sách sản phẩm
                loadDSSanPham();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn từ OpenFileDialog và hiển thị hình ảnh trong PictureBox
                imagePath = openFileDialog.FileName;
                pbAnh.Image = Image.FromFile(imagePath);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaSP.Text))
                {
                    throw new Exception("Chưa chọn sản phẩm cần xóa.");
                }

                int maSP = int.Parse(txtMaSP.Text);

                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    // Thực hiện xóa sản phẩm
                    sp.DeleteSanPham(maSP);

                    // Load lại danh sách sản phẩm
                    loadDSSanPham();

                    // Xóa trắng các TextBox sau khi xóa thành công
                    ClearTextBoxes();

                    MessageBox.Show("Xóa sản phẩm thành công", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearTextBoxes()
        {
            // Xóa trắng các TextBox
            txtMaSP.Text = string.Empty;
            txtTenSP.Text = string.Empty;
            txtSoLuong.Text = string.Empty;
            txtGia.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
            pbAnh.Image = null;
            // Đặt lại đường dẫn hình ảnh thành rỗng
            imagePath = string.Empty;
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra điều kiện lọc
                string filterCondition = "";

                if (!string.IsNullOrEmpty(txtTimKiem.Text))
                {
                    filterCondition += $"TenSP LIKE '%{txtTimKiem.Text}%'";
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

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
