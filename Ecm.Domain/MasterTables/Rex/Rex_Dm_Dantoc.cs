using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Dantoc
    {
        private object id_dantoc;
        private object ma_dantoc;
        private object ten_dantoc;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Dantoc
        {
            get { return id_dantoc; }
            set { id_dantoc = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Dantoc
        {
            get { return ma_dantoc; }
            set { ma_dantoc = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Dantoc
        {
            get { return ten_dantoc; }
            set { ten_dantoc = value; }
        }
    }
}
