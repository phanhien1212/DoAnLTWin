using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmLogin
{
    public class ThanhVien
    {
        public int MaTV { get; set; }
        public string TenTV { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ThanhVien() { }
        public ThanhVien(int matv, string tentv, string diachi, string sdt, string email, string password)
        {
            this.MaTV = matv;
            this.TenTV = tentv;
            this.DiaChi = diachi;
            this.SoDienThoai = sdt;
            this.Email = email;
            this.Password = password;
        }

    }
}

