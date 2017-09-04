using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Chungchi
    {
        private object id_chungchi;
        private object ma_chungchi;
        private object ten_chungchi;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Chungchi
        {
            get { return id_chungchi; }
            set { id_chungchi = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Chungchi
        {
            get { return ma_chungchi; }
            set { ma_chungchi = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Chungchi
        {
            get { return ten_chungchi; }
            set { ten_chungchi = value; }
        }
    }
}
