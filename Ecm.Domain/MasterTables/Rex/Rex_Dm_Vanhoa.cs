using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Vanhoa
    {
        private object id_vanhoa;
        private object ma_vanhoa;
        private object ten_vanhoa;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Vanhoa
        {
            get { return id_vanhoa; }
            set { id_vanhoa = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Vanhoa
        {
            get { return ma_vanhoa; }
            set { ma_vanhoa = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Vanhoa
        {
            get { return ten_vanhoa; }
            set { ten_vanhoa = value; }
        }
    }
}
