using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Ware
{
    public class Ware_Dm_Nhom_Hanghoa_Mua
    {
        private object id_nhom_hanghoa_mua;
        private object ma_nhom_hanghoa_mua;
        private object ten_nhom_hanghoa_mua;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhom_Hanghoa_Mua
        {
            get { return id_nhom_hanghoa_mua; }
            set { id_nhom_hanghoa_mua = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Nhom_Hanghoa_Mua
        {
            get { return ma_nhom_hanghoa_mua; }
            set { ma_nhom_hanghoa_mua = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Nhom_Hanghoa_Mua
        {
            get { return ten_nhom_hanghoa_mua; }
            set { ten_nhom_hanghoa_mua = value; }
        }
    }
}
