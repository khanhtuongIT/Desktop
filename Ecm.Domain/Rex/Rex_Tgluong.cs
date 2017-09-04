using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Rex
{
    public class Rex_Tgluong
    {
        private object id_tgluong;
        private object id_nhansu;
        private object id_ndung_tgluong;
        private object id_kyluong;
        private object sotien;
        private object id_bophan;
        private object nam_kyluong;
        private object thang_kyluong;

        [System.Xml.Serialization.XmlElement()]
        public object Id_Tgluong
        {
            get { return id_tgluong; }
            set { id_tgluong = value; }
        }

        [System.Xml.Serialization.XmlElement()]
        public object Id_Nhansu
        {
            get { return id_nhansu; }
            set { id_nhansu = value; }
        }

        [System.Xml.Serialization.XmlElement()]
        public object Id_Ndung_Tgluong
        {
            get { return id_ndung_tgluong; }
            set { id_ndung_tgluong = value; }
        }

        [System.Xml.Serialization.XmlElement()]
        public object Id_Kyluong
        {
            get { return id_kyluong; }
            set { id_kyluong = value; }
        }

        [System.Xml.Serialization.XmlElement()]
        public object Sotien
        {
            get { return sotien; }
            set { sotien = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Bophan { get { if ("" + id_bophan != "") return id_bophan; else return null; } set { id_bophan = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Nam_Kyluong { get { if ("" + nam_kyluong != "") return nam_kyluong; else return null; } set { nam_kyluong = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Thang_Kyluong { get { if ("" + thang_kyluong != "") return thang_kyluong; else return null; } set { thang_kyluong = value; } }
    }
}