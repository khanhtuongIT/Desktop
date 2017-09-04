using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Ware
{
    public class Ware_Dm_Kho_Hanghoa_Mua
    {
        private object id_kho_hanghoa_mua;
        private object ma_kho_hanghoa_mua;
        private object ten_kho_hanghoa_mua;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Kho_Hanghoa_Mua
        {
            get { return id_kho_hanghoa_mua; }
            set { id_kho_hanghoa_mua = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Kho_Hanghoa_Mua
        {
            get { return ma_kho_hanghoa_mua; }
            set { ma_kho_hanghoa_mua = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Kho_Hanghoa_Mua
        {
            get { return ten_kho_hanghoa_mua; }
            set { ten_kho_hanghoa_mua = value; }
        }
    }
}
