using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Tongiao
    {
        private object id_tongiao;
        private object ma_tongiao;
        private object ten_tongiao;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Tongiao
        {
            get { return id_tongiao; }
            set { id_tongiao = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Tongiao
        {
            get { return ma_tongiao; }
            set { ma_tongiao = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Tongiao
        {
            get { return ten_tongiao; }
            set { ten_tongiao = value; }
        }
    }
}
