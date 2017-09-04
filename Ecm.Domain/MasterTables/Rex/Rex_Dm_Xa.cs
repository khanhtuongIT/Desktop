using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Xa
    {
        private object id_xa;
        private object ma_xa;
        private object ten_xa;
        private object id_huyen;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Xa
        {
            get { return id_xa; }
            set { id_xa = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Xa
        {
            get { return ma_xa; }
            set { ma_xa = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Xa
        {
            get { return ten_xa; }
            set { ten_xa = value; }
        }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Huyen
        {
            get { return id_huyen; }
            set { id_huyen = value; }
        }
    }
}
