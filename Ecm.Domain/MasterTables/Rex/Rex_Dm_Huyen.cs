using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Huyen
    {
        private object id_huyen;
        private object ma_huyen;
        private object ten_huyen;
        private object id_tinh;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Huyen
        {
            get { return id_huyen; }
            set { id_huyen = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Huyen
        {
            get { return ma_huyen; }
            set { ma_huyen = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Huyen
        {
            get { return ten_huyen; }
            set { ten_huyen = value; }
        }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Tinh
        {
            get { return id_tinh; }
            set { id_tinh = value; }
        }
    }
}
