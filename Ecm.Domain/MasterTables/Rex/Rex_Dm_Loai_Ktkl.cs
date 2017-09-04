using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Loai_Ktkl
    {
        private object id_loai_ktkl;
        private object ma_loai_ktkl;
        private object ten_loai_ktkl;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Loai_Ktkl
        {
            get { return id_loai_ktkl; }
            set { id_loai_ktkl = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Loai_Ktkl
        {
            get { return ma_loai_ktkl; }
            set { ma_loai_ktkl = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Loai_Ktkl
        {
            get { return ten_loai_ktkl; }
            set { ten_loai_ktkl = value; }
        }
    }
}
