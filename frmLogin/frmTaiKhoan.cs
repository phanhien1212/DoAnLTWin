using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace frmLogin
{
    public partial class frmTaiKhoan : Form
    {
        private  ThanhVien userInfo;

        // Hàm tạo của frmTaiKhoan, nhận thông tin người dùng từ frmTrangChu
        public frmTaiKhoan(ThanhVien userInfo)
        {
           
            this.userInfo = userInfo;
            HienThiThongTinNguoiDung1();
        }
       
        // Hàm hiển thị thông tin người dùng trong TextBox
        private void HienThiThongTinNguoiDung1()
        {
            txtHoTen.Text = userInfo.TenTV;
            txtDiaChi.Text = userInfo.DiaChi;
            txtSdt.Text = userInfo.SoDienThoai;
            txtEmail.Text = userInfo.Email;
        }
        
        private void LoadData()
        {
           
        }
        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
          
        }

        
    }
}
