using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Ware
{
    public class Ware_Dm_Donvitinh
    {
        private object id_donvitinh;
        private object ma_donvitinh;
        private object ten_donvitinh;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Donvitinh
        {
            get { return id_donvitinh; }
            set { id_donvitinh = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Donvitinh
        {
            get { return ma_donvitinh; }
            set { ma_donvitinh = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Donvitinh
        {
            get { return ten_donvitinh; }
            set { ten_donvitinh = value; }
        }
    }
}
