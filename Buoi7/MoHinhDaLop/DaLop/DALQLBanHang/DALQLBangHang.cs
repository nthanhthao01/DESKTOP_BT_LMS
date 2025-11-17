using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTOQLBanHang;

namespace DALQLBanHang
{
    public class DALSanPham : DBConnect
    {
        public DataTable SelectSanPham()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from SanPham", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                da.Dispose();
                //conn.Close();

                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool InsertSanPham(DTOSanPham sp)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into SanPham(MaSP, TenSP, DVTinh, DonGia, MaLoai) values (@maSP, @tenSP, @dVT, @donGia, @maLoai)", conn);
                cmd.Parameters.AddWithValue("@maSP", sp.MaSp);
                cmd.Parameters.AddWithValue("@tenSP", sp.TenSP);
                cmd.Parameters.AddWithValue("@dVT", sp.DVTinh);
                cmd.Parameters.AddWithValue("@donGia", sp.DonGia);
                cmd.Parameters.AddWithValue("@maLoai", sp.MaLoai);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    cmd.Dispose();
                    conn.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
    }
}
