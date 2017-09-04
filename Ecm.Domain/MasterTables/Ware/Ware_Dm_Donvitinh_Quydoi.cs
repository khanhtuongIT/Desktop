using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Ware
{
    public class Ware_Dm_Donvitinh_Quydoi
    {
        private object id_donvitinh_quydoi;
        private object id_hanghoa_ban;
        private object id_donvitinh2;
        private object soluong1;
        private object soluong2;
        private object ghichu;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Donvitinh_Quydoi
        {
            get { return id_donvitinh_quydoi; }
            set { id_donvitinh_quydoi = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Hanghoa_Ban
        {
            get { return id_hanghoa_ban; }
            set { id_hanghoa_ban = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Donvitinh2
        {
            get { return id_donvitinh2; }
            set { id_donvitinh2 = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Soluong1
        {
            get { return soluong1; }
            set { soluong1 = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Soluong2
        {
            get { return soluong2; }
            set { soluong2 = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ghichu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }
    }
}
