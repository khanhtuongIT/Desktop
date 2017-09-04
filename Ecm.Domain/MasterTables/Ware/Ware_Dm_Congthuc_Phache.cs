using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Ware
{
    public class Ware_Dm_Congthuc_Phache
    {
        private object id_congthuc_phache;
        private object ma_congthuc_phache;
        private object ten_congthuc_phache;
        private object id_hanghoa_ban;
        private object id_donvitinh;
        private object soluong;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Congthuc_Phache
        {
            get { return id_congthuc_phache; }
            set { id_congthuc_phache = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Congthuc_Phache
        {
            get { return ma_congthuc_phache; }
            set { ma_congthuc_phache = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Congthuc_Phache
        {
            get { return ten_congthuc_phache; }
            set { ten_congthuc_phache = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Hanghoa_Ban
        {
            get { return id_hanghoa_ban; }
            set { id_hanghoa_ban = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Donvitinh
        {
            get { return id_donvitinh; }
            set { id_donvitinh = value; }
        }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Soluong
        {
            get { return soluong; }
            set { soluong = value; }
        }
    }
}
