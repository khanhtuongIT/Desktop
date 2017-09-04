using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Tinh
    {
        private object id_tinh;
        private object ma_tinh;
        private object ten_tinh;
        private object id_quocgia;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Tinh
        {
            get { return id_tinh; }
            set { id_tinh = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Tinh
        {
            get { return ma_tinh; }
            set { ma_tinh = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Tinh
        {
            get { return ten_tinh; }
            set { ten_tinh = value; }
        }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Quocgia
        {
            get { return id_quocgia; }
            set { id_quocgia = value; }
        }
    }
}
