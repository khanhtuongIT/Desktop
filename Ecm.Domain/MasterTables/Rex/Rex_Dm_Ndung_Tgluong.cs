using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Ndung_Tgluong
    {
        private object id_ndung_tgluong;
        private object noidung;
        private object pb_tangluong;
        private object ma_ndung_tgluong;
        private object pb_thue_tncn;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Ndung_Tgluong
        {
            get { return id_ndung_tgluong; }
            set { id_ndung_tgluong = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Noidung
        {
            get { return noidung; }
            set { noidung = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Pb_Tangluong
        {
            get { return pb_tangluong; }
            set { pb_tangluong = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Ndung_Tgluong
        {
            get { return ma_ndung_tgluong; }
            set { ma_ndung_tgluong = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Pb_Thue_Tncn
        {
            get { return pb_thue_tncn; }
            set { pb_thue_tncn = value; }
        }
    }
}