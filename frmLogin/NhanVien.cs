using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmLogin
{
    public class NhanVien
    {
        public int MaNV { get; set; }
        public string TenNV { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public NhanVien() { }
        public NhanVien(int manv, string tennv, string diachi, string sdt, string email)
        {
            this.MaNV = manv;
            this.TenNV = tennv;
            this.DiaChi = diachi;
            this.SoDienThoai = sdt;
            this.Email = email;
        }

        
    }
}
