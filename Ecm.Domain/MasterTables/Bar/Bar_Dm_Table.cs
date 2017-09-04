using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.MasterTables.Bar
{
    public class Bar_Dm_Table
    {
        private object id_table;
        private object ma_table;
        private object ten_table;
        private object vitri;
        private object soluong;
        private object ghichu;
        private object hinh;
        private object id_khuvuc;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Table
        {
            get { return id_table; }
            set { id_table = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Table
        {
            get { return ma_table; }
            set { ma_table = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Table
        {
            get { return ten_table; }
            set { ten_table = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Vitri
        {
            get { return vitri; }
            set { vitri = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Soluong
        {
            get { return soluong; }
            set { soluong = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ghichu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Hinh
        {
            get { return hinh; }
            set { hinh = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Khuvuc
        {
            get { return id_khuvuc; }
            set { id_khuvuc = value; }
        }
    }
}
