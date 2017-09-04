using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Ware
{
    public class Ware_Kk_Hh_Ban
    {
        private object id_kk_hh_ban;
        private object id_cuahang_ban;
        private object sochungtu;
        private object ngay_kk;
        private object id_nhansu_kk;
        private object ghichu;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Kk_Hh_Ban
        {
            get { return id_kk_hh_ban; }
            set { id_kk_hh_ban = value; }
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
        public object Ngay_Kk
        {
            get { return ngay_kk; }
            set { ngay_kk = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu_Kk
        {
            get { return id_nhansu_kk; }
            set { id_nhansu_kk = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ghichu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }
    }
}
