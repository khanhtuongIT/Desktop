using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Ware
{
    public class Ware_Congtac
    {
        private object id_congtac;
        private object id_nhansu;
        private object id_khachhang;
        private object ngay_congtac;
        private object id_cuahang_ban;
        private object noidung;
        private object ketqua;
        private object ten_khachhang;
        private object diachi;
        private object dienthoai;
        private object nguoi_daidien;
        private object lo_laf;
        private object lo_log;
        private object vitri;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Congtac
        {
            get { return id_congtac; }
            set { id_congtac = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu
        {
            get { return id_nhansu; }
            set { id_nhansu = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Khachhang
        {
            get { return id_khachhang; }
            set { id_khachhang = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Congtac
        {
            get { return ngay_congtac; }
            set { ngay_congtac = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Cuahang_Ban
        {
            get { return id_cuahang_ban; }
            set { id_cuahang_ban = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Noidung
        {
            get { return noidung; }
            set { noidung = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ketqua
        {
            get { return ketqua; }
            set { ketqua = value; }
        }

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Khachhang
        {
            get { return ten_khachhang; }
            set { ten_khachhang = value; }
        }

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Diachi
        {
            get { return diachi; }
            set { diachi = value; }
        }

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Dienthoai
        {
            get { return dienthoai; }
            set { dienthoai = value; }
        }

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Nguoi_Daidien
        {
            get { return nguoi_daidien; }
            set { nguoi_daidien = value; }
        }

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Lo_log
        {
            get { return lo_log; }
            set { lo_log = value; }
        }

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Lo_laf
        {
            get { return lo_laf; }
            set { lo_laf = value; }
        }

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Vitri
        {
            get { return vitri; }
            set { vitri = value; }
        }
      
    }
}
