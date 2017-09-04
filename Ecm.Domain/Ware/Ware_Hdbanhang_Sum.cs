using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Ware
{
    public class Ware_Hdbanhang_Sum
    {
        private object id_hdbanhang;
        private object sochungtu;
        private object ngay_chungtu;
        private object id_cuahang_ban;
        private object id_kho_hanghoa_mua;
        private object thanhtien;
        private object id_nhansu_casher;
        private object id_nhansu_casherql;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Hdbanhang
        {
            get { return id_hdbanhang; }
            set { id_hdbanhang = value; }
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
        public object Id_Cuahang_Ban
        {
            get { return id_cuahang_ban; }
            set { id_cuahang_ban = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Kho_Hanghoa_Mua
        {
            get { return id_kho_hanghoa_mua; }
            set { id_kho_hanghoa_mua = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Thanhtien
        {
            get { return thanhtien; }
            set { thanhtien = value; }
        }


        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu_Casher
        {
            get { return id_nhansu_casher; }
            set { id_nhansu_casher = value; }
        }
    }
}
