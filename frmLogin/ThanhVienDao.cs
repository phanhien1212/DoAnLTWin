using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace frmLogin
{
    class ThanhVienDao
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataAdapter adt = null;
        KetNoi kn = new KetNoi();


        public ThanhVienDao()
        {
            conn = kn.getConnect();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public DataTable GetThanhVienList()
        {
            string sql = "SELECT * FROM ThanhVien";
            cmd = new SqlCommand(sql, conn);
            adt = new SqlDataAdapter(cmd);

            DataTable dataTable = new DataTable();
            adt.Fill(dataTable);

            return dataTable;
        }
        public void InsertThanhVien(ThanhVien tv)
        {

            string sql = "INSERT INTO ThanhVien(MaTV, TenTV, DiaChi, SoDienThoai, Email, Password) VALUES(@MaTV,@TenTV,@DiaChi,@SoDienThoai,@Email,@Password)";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaTV", tv.MaTV);
            cmd.Parameters.AddWithValue("@TenTV", tv.TenTV);
            cmd.Parameters.AddWithValue("@DiaChi", tv.DiaChi);
            cmd.Parameters.AddWithValue("@SoDienThoai", tv.SoDienThoai);
            cmd.Parameters.AddWithValue("@Email", tv.Email);
            cmd.Parameters.AddWithValue("@Password", tv.Password);
            cmd.ExecuteNonQuery();

        }

        public void UpdateThanhVien(ThanhVien tv)
        {
            string sql = "UPDATE ThanhVien SET MaNV = @MaTV, TenTV= @TenNV, DiaChi = @DiaChi, SoDienThoai = @SoDienThoai, Email = @Email,  Password = @Password WHERE MaTV = @MaTV";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaTV", tv.MaTV);
            cmd.Parameters.AddWithValue("@TenTV", tv.TenTV);
            cmd.Parameters.AddWithValue("@DiaChi", tv.DiaChi);
            cmd.Parameters.AddWithValue("@SoDienThoai", tv.SoDienThoai);
            cmd.Parameters.AddWithValue("@Email", tv.Email);
            cmd.Parameters.AddWithValue("@Password", tv.Password);
            cmd.ExecuteNonQuery();

        }



        public void DeleteThanhVien(int maTV)
        {
            string sql = "DELETE FROM ThanhVien WHERE MaTV = @MaTV";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaTV", maTV);

            cmd.ExecuteNonQuery();

        }
        

    }
}
