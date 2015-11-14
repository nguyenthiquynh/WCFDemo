using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibraryQLSV
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceSinhVien" in both code and config file together.
    public class ServiceSinhVien : IServiceSinhVien
    {
        public List<SinhVien> ListSinhVien()
        {
            List<SinhVien> listSV = new List<SinhVien>();
            try
            {
                DataTable dt = new DataTable();
                dt = SqlDatabase.ExecuteQueryWithDataTable("SELECT * FROM SINHIEN.dbo.DSSV ");
                listSV = (from DataRow dr in dt.Rows
                          select new SinhVien()
                          {
                              _ID = Convert.ToInt32(dr["ID"]),
                              _MSSV = dr["MSSV"].ToString(),
                              _HOTEN = dr["HOTEN"].ToString(),
                              _LOP = dr["LOP"].ToString(),
                              _NGAYSINH = DateTime.Parse(dr["NGAYSINH"].ToString()),
                              _GIOITINH = dr["GIOITINH"].ToString(),
                              _TENDANGNHAP = dr["TENDANGNHAP"].ToString(),
                              _MATKHAU = dr["MATKHAU"].ToString(),
                          }).ToList();
            }
            catch { }
            return listSV;
        }
        public SinhVien HienThi1SinhVien(int id)
        {
            SinhVien sv1 = new SinhVien();
            try
            {
                DataTable dt = new DataTable();
                dt = SqlDatabase.ExecuteQueryWithDataTable("SELECT * FROM DSSV WHERE id = " + id);
                DataRow dr = dt.Rows[0];

                sv1._ID = Convert.ToInt32(dr["ID"]);
                sv1._MSSV = dr["MSSV"].ToString();
                sv1._HOTEN = dr["HOTEN"].ToString();
                sv1._LOP = dr["LOP"].ToString();
                sv1._NGAYSINH = DateTime.Parse(dr["NGAYSINH"].ToString());
                sv1._GIOITINH = dr["GIOITINH"].ToString();
                sv1._TENDANGNHAP = dr["TENDANGNHAP"].ToString();
                sv1._MATKHAU = dr["MATKHAU"].ToString();
            }
            catch { }
            return sv1;
        }

        public int XoaSinhVien(int id)
        {
            try
            {
                int result = SqlDatabase.ExecuteNonQuery("DELETE FROM DSSV WHERE ID = " + id);
                return result;
            }
            catch
            {
                return -1;
            }
        }

        public int ThemSinhVien(SinhVien sv)
        {
            try
            {
                //int result = SqlDatabase.ExecuteNonQuery("insert into DSSV (MSSV,HOTEN,LOP,NGAYSINH,GIOITINH,TENDANGNHAP,MATKHAU) values ('" + sv._MSSV + "','','','','','','')");
                int result = SqlDatabase.ExecuteNonQuery(string.Format("insert into DSSV (MSSV,HOTEN,LOP,NGAYSINH,GIOITINH,TENDANGNHAP,MATKHAU) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", sv._MSSV, sv._HOTEN, sv._LOP, sv._NGAYSINH, sv._GIOITINH, sv._TENDANGNHAP, sv._MATKHAU));
                return result;
            }
            catch
            {
                return -1;
            }
        }
        public int CapNhatSinhVien(SinhVien sv)
        {
            try
            {
                int result = SqlDatabase.ExecuteNonQuery(string.Format("UPDATE SINHIEN.dbo.DSSV SET (MSSV,HOTEN,LOP,NGAYSINH,GIOITINH,TENDANGNHAP,MATKHAU) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')  WHERE id = {7}", sv._MSSV, sv._HOTEN, sv._LOP, sv._NGAYSINH, sv._GIOITINH, sv._TENDANGNHAP, sv._MATKHAU, sv._ID));
                return result;
            }
            catch
            {
                return -1;
            }
        }
    }
}

