using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace frmLogin
{
    class ChiTietHoaDonDao
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataAdapter adt = null;
        KetNoi kn = new KetNoi();


        public ChiTietHoaDonDao()
        {
            conn = kn.getConnect();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public DataTable GetChiTietHoaDonList()
        {
            string sql = "SELECT ChiTietHoaDon.MaHD, ChiTietHoaDon.MaSP, SanPham.TenSP, ChiTietHoaDon.SoLuong, ChiTietHoaDon.Gia " +
                 "FROM ChiTietHoaDon " +
                 "JOIN SanPham ON ChiTietHoaDon.MaSP = SanPham.MaSP";
            cmd = new SqlCommand(sql, conn);
            adt = new SqlDataAdapter(cmd);

            DataTable dataTable = new DataTable();
            adt.Fill(dataTable);

            return dataTable;
        }

        public void InsertChiTietHoaDon(ChiTietHoaDon cthd)
        {
            // Code để thêm sản phẩm vào CSDL
            // Ví dụ:
            string sql = "INSERT INTO ChiTietHoaDon (MaSP, TenSP, SoLuong, Gia) VALUES (@MaSP, @TenSP, @Gia,@SoLuong)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaSP", cthd.MaSP);
            
            cmd.Parameters.AddWithValue("@SoLuong", cthd.SoLuong);
            cmd.Parameters.AddWithValue("@Gia", cthd.Gia);

            cmd.ExecuteNonQuery();
        }
    }
}
