using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Rex
{
    public class Rex_Kyluong
    {
        private object id_kyluong;
        private object ma_kyluong;
        private object ten_kyluong;
        private object thang_kyluong;
        private object nam_kyluong;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Kyluong
        {
            get { return id_kyluong; }
            set { id_kyluong = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Kyluong
        {
            get { return ma_kyluong; }
            set { ma_kyluong = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Kyluong
        {
            get { return ten_kyluong; }
            set { ten_kyluong = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Thang_Kyluong
        {
            get { return thang_kyluong; }
            set { thang_kyluong = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Nam_Kyluong
        {
            get { return nam_kyluong; }
            set { nam_kyluong = value; }
        }
    }
}
