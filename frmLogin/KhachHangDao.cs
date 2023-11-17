using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace frmLogin
{
    public class KhachHangDao
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataAdapter adt = null;
        KetNoi kn = new KetNoi();


        public KhachHangDao()
        {
            conn = kn.getConnect();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public DataTable GetKhachHangList()
        {
            string sql = "SELECT * FROM KhachHang";
            cmd = new SqlCommand(sql, conn);
            adt = new SqlDataAdapter(cmd);

            DataTable dataTable = new DataTable();
            adt.Fill(dataTable);

            return dataTable;
        }

        public void InsertKhachHang(KhachHang kh)
        {

            string sql = "INSERT INTO KhachHang(MaKH, TenKH, DiaChi, SoDienThoai) VALUES(@MaKH,@TenKH,@DiaChi,@SoDienThoai)";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaKH", kh.MaKH);
            cmd.Parameters.AddWithValue("@TenKH", kh.TenKH);
            cmd.Parameters.AddWithValue("@DiaChi", kh.DiaChi);
            cmd.Parameters.AddWithValue("@SoDienThoai", kh.SoDienThoai);
            cmd.ExecuteNonQuery();

        }

        public void UpdateKhachHang(KhachHang kh)
        {
            string sql = "UPDATE KhachHang SET MaKH = @MaKH, TenKH = @TenKH, DiaChi = @DiaChi, SoDienThoai = @SoDienThoai WHERE MaKH = @MaKH";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaKH", kh.MaKH);
            cmd.Parameters.AddWithValue("@TenKH", kh.TenKH);
            cmd.Parameters.AddWithValue("@DiaChi", kh.DiaChi);
            cmd.Parameters.AddWithValue("@SoDienThoai", kh.SoDienThoai);

            cmd.ExecuteNonQuery();

        }



        public void DeleteKhachHang(int maKH)
        {
            string sql = "DELETE FROM KhachHang WHERE MaKH = @MaKH";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaKH", maKH);

            cmd.ExecuteNonQuery();

        }

        public void TimKiemKhachHang(string tenKH)
        {

        }
    }
}
