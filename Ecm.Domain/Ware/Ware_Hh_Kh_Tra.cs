using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Ware
{
    public class Ware_Hh_Kh_Tra
    {
        private object id_hh_kh_tra;
        private object ngay_chungtu;
        private object sochungtu;
        private object id_nhansu_lap;
        private object id_kho_hanghoa_mua;
        private object id_cuahang_ban;
        private object id_khachhang;
        private object ghichu;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Hh_Kh_Tra
        {
            get { return id_hh_kh_tra; }
            set { id_hh_kh_tra = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Chungtu
        {
            get { return ngay_chungtu; }
            set { ngay_chungtu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Sochungtu
        {
            get { return sochungtu; }
            set { sochungtu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu_Lap
        {
            get { return id_nhansu_lap; }
            set { id_nhansu_lap = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Kho_Hanghoa_Mua
        {
            get { return id_kho_hanghoa_mua; }
            set { id_kho_hanghoa_mua = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Cuahang_Ban
        {
            get { return id_cuahang_ban; }
            set { id_cuahang_ban = value; }
        }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Khachhang
        {
            get{  return id_khachhang;  }
            set { id_khachhang = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ghichu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }


    }
}
