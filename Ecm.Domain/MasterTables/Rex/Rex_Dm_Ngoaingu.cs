using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Ngoaingu
    {
        private object id_ngoaingu;
        private object ma_ngoaingu;
        private object ten_ngoaingu;
        private object ten_trinhdo;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Ngoaingu
        {
            get { return id_ngoaingu; }
            set { id_ngoaingu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Ngoaingu
        {
            get { return ma_ngoaingu; }
            set { ma_ngoaingu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Ngoaingu
        {
            get { return ten_ngoaingu; }
            set { ten_ngoaingu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Trinhdo
        {
            get { return ten_trinhdo; }
            set { ten_trinhdo = value; }
        }
    }
}
