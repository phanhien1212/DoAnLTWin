using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace frmLogin
{
    class HoaDonDao
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataAdapter adt = null;
        KetNoi kn = new KetNoi();


        public HoaDonDao()
        {
            conn = kn.getConnect();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public DataTable GetHoaDonList()
        {
            string sql = "SELECT HoaDon.MaHD, HoaDon.MaKH, KhachHang.TenKH, HoaDon.ThoiGian, HoaDon.TongTien " +
                 "FROM HoaDon " +
                 "JOIN KhachHang ON HoaDon.MaKH = KhachHang.MaKH";
            cmd = new SqlCommand(sql, conn);
            adt = new SqlDataAdapter(cmd);

            DataTable dataTable = new DataTable();
            adt.Fill(dataTable);

            return dataTable;
        }
    }
}
