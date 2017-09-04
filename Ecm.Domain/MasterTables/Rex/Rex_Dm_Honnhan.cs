using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Honnhan
    {
        private object id_honnhan;
        private object ma_honnhan;
        private object ten_honnhan;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Honnhan
        {
            get { return id_honnhan; }
            set { id_honnhan = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Honnhan
        {
            get { return ma_honnhan; }
            set { ma_honnhan = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Honnhan
        {
            get { return ten_honnhan; }
            set { ten_honnhan = value; }
        }
    }
}
