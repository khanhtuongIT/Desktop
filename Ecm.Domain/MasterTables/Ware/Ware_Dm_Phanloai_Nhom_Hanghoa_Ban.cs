using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Ware
{
    public class Ware_Dm_Phanloai_Nhom_Hanghoa_Ban
    {
        private object id_phanloai_nhom_hanghoa_ban;
        private object ma_phanloai_nhom_hanghoa_ban;
        private object ten_phanloai_nhom_hanghoa_ban;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Phanloai_Nhom_Hanghoa_Ban
        {
            get { return ma_phanloai_nhom_hanghoa_ban; }
            set { ma_phanloai_nhom_hanghoa_ban = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Phanloai_Nhom_Hanghoa_Ban
        {
            get { return ma_phanloai_nhom_hanghoa_ban; }
            set { ma_phanloai_nhom_hanghoa_ban = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Phanloai_Nhom_Hanghoa_Ban
        {
            get { return ten_phanloai_nhom_hanghoa_ban; }
            set { ten_phanloai_nhom_hanghoa_ban = value; }
        }

    }
}
