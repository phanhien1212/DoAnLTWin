using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmLogin
{
    class HoaDon
    {
        public int MaHD { get; set; }
        public int MaKH { get; set; }
        public DateTime ThoiGian { get; set; }
        public float TongTien { get; set; }

        public HoaDon() { }
        public HoaDon(int mahd, int makh, DateTime thoigian, float tongtien)
        {
            this.MaHD = mahd;
            this.MaKH = makh;
            this.ThoiGian = thoigian;
            this.TongTien = tongtien;
        }

    }
}
