using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Ware
{
    public class Ware_Dm_Loai_Hanghoa_Ban
    {
        private object id_loai_hanghoa_ban;
        private object ma_loai_hanghoa_ban;
        private object ten_loai_hanghoa_ban;
        private object id_nhom_hanghoa_ban;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Loai_Hanghoa_Ban
        {
            get { return id_loai_hanghoa_ban; }
            set { id_loai_hanghoa_ban = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Loai_Hanghoa_Ban
        {
            get { return ma_loai_hanghoa_ban; }
            set { ma_loai_hanghoa_ban = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Loai_Hanghoa_Ban
        {
            get { return ten_loai_hanghoa_ban; }
            set { ten_loai_hanghoa_ban = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhom_Hanghoa_Ban
        {
            get { return id_nhom_hanghoa_ban; }
            set { id_nhom_hanghoa_ban = value; }
        }
    }
}
