using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Loai_Bophan
    {
        private object id_loai_bophan;
        private object ma_loai_bophan;
        private object ten_loai_bophan;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Loai_Bophan
        {
            get { return id_loai_bophan; }
            set { id_loai_bophan = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Loai_Bophan
        {
            get { return ma_loai_bophan; }
            set { ma_loai_bophan = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Loai_Bophan
        {
            get { return ten_loai_bophan; }
            set { ten_loai_bophan = value; }
        }
    }
}
