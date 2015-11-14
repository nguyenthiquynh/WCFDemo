using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibraryQLSV
{
    public class SqlDatabase
    {
        public static string Sqlconnect = @"Data Source = QUYNHNT\SQLEXPRESS; Initial Catalog=SINHVIEN;Database = SINHVIEN; User ID=sa;Password=123456";

        public static DataTable ExecuteQueryWithDataTable(string strSQL)
        {
            SqlConnection cnn = new SqlConnection(Sqlconnect);
            SqlCommand cmd = new SqlCommand(strSQL, cnn);
            cmd.CommandType = CommandType.Text; //kiểu là text tức là bạn vứt chuỗi nào vào nó chạy y hệt như thế
            SqlDataAdapter da = new SqlDataAdapter(cmd);// result
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static int ExecuteNonQuery(string strSQL)
        {
            int result = 0;
            SqlConnection cnn = new SqlConnection(Sqlconnect);
            SqlCommand cmd = new SqlCommand(strSQL, cnn);
            cmd.CommandType = CommandType.Text;
            try
            {
                cnn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }
    }
}
