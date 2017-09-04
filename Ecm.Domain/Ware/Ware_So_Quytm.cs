using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Ware
{
    public class Ware_So_Quytm
    {
        private object id_so_quytm;
        private object thang;
        private object nam;
        private object sotien;
        private object id_soquy;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_So_Quytm
        {
            get { return id_so_quytm; }
            set { id_so_quytm = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Thang
        {
            get { return thang; }
            set { thang = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Nam
        {
            get { return nam; }
            set { nam = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Sotien
        {
            get { return sotien; }
            set { sotien = value; }
        }

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Soquy
        {
            get { return id_soquy; }
            set { id_soquy = value; }
        }

    }
}
