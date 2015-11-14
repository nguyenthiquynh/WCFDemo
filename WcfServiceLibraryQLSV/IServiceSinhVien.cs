using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibraryQLSV
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceSinhVien" in both code and config file together.
    [ServiceContract]
    public interface IServiceSinhVien
    {
        [OperationContract]
        List<SinhVien> ListSinhVien();
        [OperationContract]
        SinhVien HienThi1SinhVien(int id);
        [OperationContract]
        int XoaSinhVien(int id);
        [OperationContract]
        int ThemSinhVien(SinhVien sv);
        [OperationContract]
        int CapNhatSinhVien(SinhVien sv);
    }

    [DataContract]
    public class SinhVien
    {
        private int ID;
        [DataMember]
        public int _ID
        {
            get { return ID; }
            set { ID = value; }
        }

        private string MSSV;
        [DataMember]
        public string _MSSV
        {
            get { return MSSV; }
            set { MSSV = value; }
        }

        private string HOTEN;
        [DataMember]
        public string _HOTEN
        {
            get { return HOTEN; }
            set { HOTEN = value; }
        }

        private string LOP;
        [DataMember]
        public string _LOP
        {
            get { return LOP; }
            set { LOP = value; }
        }

        private DateTime NGAYSINH;
        [DataMember]
        public DateTime _NGAYSINH
        {
            get { return NGAYSINH; }
            set { NGAYSINH = value; }
        }

        private string GIOITINH;
        [DataMember]
        public string _GIOITINH
        {
            get { return GIOITINH; }
            set { GIOITINH = value; }
        }

        private string TENDANGNHAP;
        [DataMember]
        public string _TENDANGNHAP
        {
            get { return TENDANGNHAP; }
            set { TENDANGNHAP = value; }
        }

        private string MATKHAU;
        [DataMember]
        public string _MATKHAU
        {
            get { return MATKHAU; }
            set { MATKHAU = value; }
        }
    }

}
