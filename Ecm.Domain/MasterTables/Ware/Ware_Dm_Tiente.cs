using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Ware
{
    public class Ware_Dm_Tiente
    {
        private object id_tiente;
        private object ma_tiente;
        private object ten_tiente;
        private object tygia_vnd;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Tiente
        {
            get { return id_tiente; }
            set { id_tiente = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Tiente
        {
            get { return ma_tiente; }
            set { ma_tiente = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Tiente
        {
            get { return ten_tiente; }
            set { ten_tiente = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Tygia_Vnd
        {
            get { return tygia_vnd; }
            set { tygia_vnd = value; }
        }

    }
}
