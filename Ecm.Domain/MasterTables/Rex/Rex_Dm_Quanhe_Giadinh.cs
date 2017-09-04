using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Quanhe_Giadinh
    {
        private object id_quanhe_giadinh;
        private object ma_quanhe_giadinh;
        private object ten_quanhe_giadinh;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Quanhe_Giadinh
        {
            get { return id_quanhe_giadinh; }
            set { id_quanhe_giadinh = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Quanhe_Giadinh
        {
            get { return ma_quanhe_giadinh; }
            set { ma_quanhe_giadinh = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Quanhe_Giadinh
        {
            get { return ten_quanhe_giadinh; }
            set { ten_quanhe_giadinh = value; }
        }
    }
}
