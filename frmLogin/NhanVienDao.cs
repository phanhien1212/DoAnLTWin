using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmLogin
{
    public class NhanVienDao
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataAdapter adt = null;
        KetNoi kn = new KetNoi();


        public NhanVienDao()
        {
            conn = kn.getConnect();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public DataTable GetNhanVienList()
        {
            string sql = "SELECT * FROM NhanVien";
            cmd = new SqlCommand(sql, conn);
            adt = new SqlDataAdapter(cmd);

            DataTable dataTable = new DataTable();
            adt.Fill(dataTable);

            return dataTable;
        }
        public void InsertNhanVien(NhanVien nv)
        {

            string sql = "INSERT INTO NhanVien(MaNV, TenNV, DiaChi, SoDienThoai, Email) VALUES(@MaNV,@TenNV,@DiaChi,@SoDienThoai,@Email)";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaNV", nv.MaNV);
            cmd.Parameters.AddWithValue("@TenNV", nv.TenNV);
            cmd.Parameters.AddWithValue("@DiaChi", nv.DiaChi);
            cmd.Parameters.AddWithValue("@SoDienThoai", nv.SoDienThoai);
            cmd.Parameters.AddWithValue("@Email", nv.Email);
            cmd.ExecuteNonQuery();

        }

        public void UpdateNhanVien(NhanVien nv)
        {
            string sql = "UPDATE NhanVien SET MaNV = @MaNV, TenNV= @TenNV, DiaChi = @DiaChi, SoDienThoai = @SoDienThoai, Email = @Email WHERE MaNV = @MaNV";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaNV", nv.MaNV);
            cmd.Parameters.AddWithValue("@TenNV", nv.TenNV);
            cmd.Parameters.AddWithValue("@DiaChi", nv.DiaChi);
            cmd.Parameters.AddWithValue("@SoDienThoai", nv.SoDienThoai);
            cmd.Parameters.AddWithValue("@Email", nv.Email);

            cmd.ExecuteNonQuery();

        }



        public void DeleteNhanVien(int maNV)
        {
            string sql = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaNV", maNV);

            cmd.ExecuteNonQuery();

        }
    }
}
