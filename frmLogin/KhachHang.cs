using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmLogin
{
    public class KhachHang
    {
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }

        public KhachHang() { }
        public KhachHang(int makh, string tenkh, string diachi, string sdt)
        {
            this.MaKH = makh;
            this.TenKH = tenkh;
            this.DiaChi = diachi;
            this.SoDienThoai = sdt;
        }

       
    }
}
