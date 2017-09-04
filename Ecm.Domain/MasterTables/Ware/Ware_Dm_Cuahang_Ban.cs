using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Ware
{
    public class Ware_Dm_Cuahang_Ban
    {
        private object id_cuahang_ban;
        private object ma_cuahang_ban;
        private object ten_cuahang_ban;
        private object kho_hang;
        private object id_cap;


        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Cuahang_Ban
        {
            get { return id_cuahang_ban; }
            set { id_cuahang_ban = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Cuahang_Ban
        {
            get { return ma_cuahang_ban; }
            set { ma_cuahang_ban = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Cuahang_Ban
        {
            get { return ten_cuahang_ban; }
            set { ten_cuahang_ban = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Kho_Hang
        {
            get { return kho_hang; }
            set { kho_hang = value; }
        }

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Cap
        {
            get { return id_cap; }
            set { id_cap = value; }
        }

    }
}
