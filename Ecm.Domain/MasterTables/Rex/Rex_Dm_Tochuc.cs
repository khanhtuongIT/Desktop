using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Tochuc
    {
        private object id_tochuc;
        private object ma_tochuc;
        private object ten_tochuc;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Tochuc
        {
            get { return id_tochuc; }
            set { id_tochuc = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Tochuc
        {
            get { return ma_tochuc; }
            set { ma_tochuc = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Tochuc
        {
            get { return ten_tochuc; }
            set { ten_tochuc = value; }
        }
    }
}