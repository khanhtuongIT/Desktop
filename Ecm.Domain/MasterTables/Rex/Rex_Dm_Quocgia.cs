using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Quocgia
    {
        private object id_quocgia;
        private object ma_quocgia;
        private object ten_quocgia;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Quocgia
        {
            get { return id_quocgia; }
            set { id_quocgia = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Quocgia
        {
            get { return ma_quocgia; }
            set { ma_quocgia = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Quocgia
        {
            get { return ten_quocgia; }
            set { ten_quocgia = value; }
        }
    }
}
