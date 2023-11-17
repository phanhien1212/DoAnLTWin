using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmLogin
{
    public class SanPham
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public float Gia { get; set; }
        public byte[] Image { get; set; }
        public string GhiChu { get; set; }

        public SanPham() { }
        public SanPham(int masp, string tensp, int soluong, float gia, byte[] image, string ghichu)
        {
            this.MaSP = masp;
            this.TenSP = tensp;
            this.SoLuong = soluong;
            this.Gia = gia;
            this.Image = image;
            this.GhiChu = ghichu;
        }

        
    }
}
