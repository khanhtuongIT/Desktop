using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Rex
{
    public class Rex_Quanhe_Giadinh
    {
        private object id_quanhe_giadinh;
        private object id_nhansu;
        private object id_loai_quanhe_giadinh;
        private object ho_ten;
        private object namsinh;
        private object nghe_nghiep;
        private object diachi_thuongtru;
        private object ghi_chu;
        private object ngay_batdau;
        private object ngay_ketthuc;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Quanhe_Giadinh
        {
            get { return id_quanhe_giadinh; }
            set { id_quanhe_giadinh = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu
        {
            get { return id_nhansu; }
            set { id_nhansu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Loai_Quanhe_Giadinh
        {
            get { return id_loai_quanhe_giadinh; }
            set { id_loai_quanhe_giadinh = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ho_Ten
        {
            get { return ho_ten; }
            set { ho_ten = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Namsinh
        {
            get { return namsinh; }
            set { namsinh = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Nghe_Nghiep
        {
            get { return nghe_nghiep; }
            set { nghe_nghiep = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Diachi_Thuongtru
        {
            get { return diachi_thuongtru; }
            set { diachi_thuongtru = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ghi_Chu
        {
            get { return ghi_chu; }
            set { ghi_chu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Batdau
        {
            get
            {
                if ("" + ngay_batdau != "") return ngay_batdau; else return null;
            }
            set { ngay_batdau = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Ketthuc
        {
            get
            {
                if ("" + ngay_ketthuc != "") return ngay_ketthuc; else return null;
            }
            set { ngay_ketthuc = value; }
        }
    }
}