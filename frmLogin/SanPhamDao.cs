using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace frmLogin
{
    public class SanPhamDao
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataAdapter adt = null;
        KetNoi kn = new KetNoi();

        public SanPhamDao()
        {
            conn = kn.getConnect();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public DataTable GetSanPhamList()
        {
            string sql = "SELECT * FROM SanPham";
            cmd = new SqlCommand(sql, conn);
            adt = new SqlDataAdapter(cmd);

            DataTable dataTable = new DataTable();
            adt.Fill(dataTable);

            return dataTable;
        }
        
        public void InsertSanPham(SanPham sp)
        {
            // Code để thêm sản phẩm vào CSDL
            // Ví dụ:
            string sql = "INSERT INTO SanPham (MaSP, TenSP, SoLuong, Gia, Image, GhiChu) VALUES (@MaSP, @TenSP, @Gia,@SoLuong, @Image, @GhiChu)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaSP", sp.MaSP);
            cmd.Parameters.AddWithValue("@TenSP", sp.TenSP);
            cmd.Parameters.AddWithValue("@SoLuong", sp.SoLuong);
            cmd.Parameters.Add("@Image", SqlDbType.VarBinary, -1).Value = sp.Image;
            cmd.Parameters.AddWithValue("@Gia", sp.Gia);
            cmd.Parameters.AddWithValue("@GhiChu", sp.GhiChu);

            cmd.ExecuteNonQuery();
        }

        public void DeleteSanPham(int maSanPham)
        {
            // Code để xóa sản phẩm từ CSDL
            // Ví dụ:
            string sql = "DELETE FROM SanPham WHERE MaSP = @MaSP";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaSP", maSanPham);
            cmd.ExecuteNonQuery();
        }

        public void UpdateSanPham(SanPham sp)
        {
            // Code để cập nhật thông tin sản phẩm trong CSDL
            // Ví dụ:
            string sql = "UPDATE SanPham SET TenSP = @TenSP, Gia = @Gia, SoLuong = @SoLuong, Image = @Image, GhiChu = @GhiChu WHERE MaSP = @MaSP";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaSP", sp.MaSP);
            cmd.Parameters.AddWithValue("@TenSP", sp.TenSP);
            cmd.Parameters.AddWithValue("@Gia", sp.Gia);
            cmd.Parameters.AddWithValue("@SoLuong", sp.SoLuong);
            cmd.Parameters.AddWithValue("@Image", sp.Image);
            cmd.Parameters.AddWithValue("@GhiChu", sp.GhiChu);

            cmd.ExecuteNonQuery();
        }
    }
}
