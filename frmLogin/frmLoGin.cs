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
    public partial class frmLoGin : Form
    {
       
        public frmLoGin()
        {
            InitializeComponent();
        }

        private void frmLoGin_Load(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text;
                string password = txtPassword.Text;

                // Thực hiện kiểm tra đăng nhập
                ThanhVien userInfo = ThucHienDangNhap(email, password);

                if (userInfo != null)
                {
                    MessageBox.Show("Đăng nhập thành công!");

                    // Chuyển sang frmTrangChu và truyền thông tin thành viên
                    frmTrangChu frmTrangChu = new frmTrangChu(userInfo);
                    this.Hide();
                    frmTrangChu.Show();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private ThanhVien ThucHienDangNhap(string email, string password)
        {
            ThanhVienDao thanhVienDao = new ThanhVienDao();
            DataTable dataTable = thanhVienDao.GetThanhVienList();

            foreach (DataRow row in dataTable.Rows)
            {
                string storedEmail = row["Email"].ToString();
                string storedPassword = row["Password"].ToString();

                // Kiểm tra xem email và password có khớp với dữ liệu trong CSDL không
                if (storedEmail == email && storedPassword == password)
                {
                    // Nếu khớp, trả về đối tượng ThanhVien với thông tin từ dòng dữ liệu
                    return new ThanhVien
                    {
                        MaTV = Convert.ToInt32(row["MaTV"]),
                        TenTV = row["TenTV"].ToString(),
                        DiaChi = row["DiaChi"].ToString(),
                        SoDienThoai = row["SoDienThoai"].ToString(),
                        Email = storedEmail,
                        Password = storedPassword
                    };
                }
            }

            // Nếu không tìm thấy thông tin, trả về null hoặc thông báo lỗi tùy thuộc vào yêu cầu của bạn
            return null;
        }


    }
}
