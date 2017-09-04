using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Ware
{
    public class Ware_Hh_Mua_Tra_Ncc
    {
        private object id_hh_mua_tra_ncc;
        private object id_cuahang_ban;
        private object sochungtu;
        private object ngay_chungtu;
        private object id_nhansu_lap;
        private object ghichu;
        private object id_khachhang;
        private object sotien;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Hh_Mua_Tra_Ncc
        {
            get { return id_hh_mua_tra_ncc; }
            set { id_hh_mua_tra_ncc = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Cuahang_Ban
        {
            get { return id_cuahang_ban; }
            set { id_cuahang_ban = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Sochungtu
        {
            get { return sochungtu; }
            set { sochungtu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Chungtu
        {
            get { return ngay_chungtu; }
            set { ngay_chungtu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu_Lap
        {
            get { return id_nhansu_lap; }
            set { id_nhansu_lap = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ghichu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Khachhang
        {
            get { return id_khachhang; }
            set { id_khachhang = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Sotien
        {
            get { return sotien; }
            set { sotien = value; }
        }
    }
}
