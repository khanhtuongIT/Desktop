using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Kynang_Chuyenmon
    {
        private object id_kynang_chuyenmon;
        private object ma_kynang_chuyenmon;
        private object ten_kynang_chuyenmon;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Kynang_Chuyenmon
        {
            get { return id_kynang_chuyenmon; }
            set { id_kynang_chuyenmon = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Kynang_Chuyenmon
        {
            get { return ma_kynang_chuyenmon; }
            set { ma_kynang_chuyenmon = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Kynang_Chuyenmon
        {
            get { return ten_kynang_chuyenmon; }
            set { ten_kynang_chuyenmon = value; }
        }
    }
}
