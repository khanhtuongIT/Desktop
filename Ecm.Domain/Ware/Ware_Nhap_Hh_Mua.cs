using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Ware
{
    public class Ware_Nhap_Hh_Mua
    {
        private object id_nhap_hh_mua;
        private object id_kho_hanghoa_mua;
        private object sochungtu;
        private object ngay_nhanhang;
        private object nguoi_giaohang;
        private object id_nhansu_nhanhang;
        private object ghichu;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhap_Hh_Mua
        {
            get { return id_nhap_hh_mua; }
            set { id_nhap_hh_mua = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Kho_Hanghoa_Mua
        {
            get { return id_kho_hanghoa_mua; }
            set { id_kho_hanghoa_mua = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Sochungtu
        {
            get { return sochungtu; }
            set { sochungtu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Nhanhang
        {
            get { return ngay_nhanhang; }
            set { ngay_nhanhang = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Nguoi_Giaohang
        {
            get { return nguoi_giaohang; }
            set { nguoi_giaohang = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu_Nhanhang
        {
            get { return id_nhansu_nhanhang; }
            set { id_nhansu_nhanhang = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ghichu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }


    }
}
