using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Ware
{
    public class Ware_Dongia_Cap
    {
        private object id_dongia_cap;
        private object id_hanghoa_dinhgia;
        private object id_cap;
        private object dongia_ban;
        private object ghichu;

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Dongia_Cap
        {
            get { return id_dongia_cap; }
            set { id_dongia_cap = value; }
        }

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Hanghoa_Dinhgia
        {
            get { return id_hanghoa_dinhgia; }
            set { id_hanghoa_dinhgia = value; }
        }

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Cap
        {
            get { return id_cap; }
            set { id_cap = value; }
        }

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Dongia_Ban
        {
            get { return dongia_ban; }
            set { dongia_ban = value; }
        }

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Ghichu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }

    }
}
