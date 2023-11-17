using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmLogin
{
     public class ChiTietHoaDon
    {
        public int MaHD { get; set; }
        public int MaSP { get; set; }
        public int SoLuong  { get; set; }
        public float Gia { get; set; }

        public ChiTietHoaDon(string maKH) { }
        public ChiTietHoaDon(int mahd, int masp, int soluong, float gia)
        {
            this.MaHD = mahd;
            this.MaSP = masp;
            this.SoLuong = soluong;
            this.Gia = gia;
        }
    }
}
