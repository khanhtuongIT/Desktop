using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Chuyenmon
    {
        private object id_chuyenmon;
        private object ma_chuyenmon;
        private object ten_chuyenmon;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Chuyenmon
        {
            get { return id_chuyenmon; }
            set { id_chuyenmon = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Chuyenmon
        {
            get { return ma_chuyenmon; }
            set { ma_chuyenmon = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Chuyenmon
        {
            get { return ten_chuyenmon; }
            set { ten_chuyenmon = value; }
        }
    }
}
