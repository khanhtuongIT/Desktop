using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Tinhoc
    {
        private object id_tinhoc;
        private object ma_tinhoc;
        private object ten_tinhoc;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Tinhoc
        {
            get { return id_tinhoc; }
            set { id_tinhoc = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Tinhoc
        {
            get { return ma_tinhoc; }
            set { ma_tinhoc = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Tinhoc
        {
            get { return ten_tinhoc; }
            set { ten_tinhoc = value; }
        }
    }
}
