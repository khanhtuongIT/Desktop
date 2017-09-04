using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.MasterTables.Ware
{
    public class Ware_Dm_Nhasanxuat
    {
        private object id_nhasanxuat;
        private object ma_nhasanxuat;
        private object ten_nhasanxuat;
        private object diachi;
        private object masothue;
        private object dienthoai;
        private object fax;
        private object email;
        private object website;
        private object id_quocgia;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhasanxuat
        {
            get { return id_nhasanxuat; }
            set { id_nhasanxuat = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Nhasanxuat
        {
            get { return ma_nhasanxuat; }
            set { ma_nhasanxuat = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Nhasanxuat
        {
            get { return ten_nhasanxuat; }
            set { ten_nhasanxuat = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Diachi
        {
            get { return diachi; }
            set { diachi = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Masothue
        {
            get { return masothue; }
            set { masothue = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Dienthoai
        {
            get { return dienthoai; }
            set { dienthoai = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Email
        {
            get { return email; }
            set { email = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Website
        {
            get { return website; }
            set { website = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Quocgia
        {
            get { return id_quocgia; }
            set { id_quocgia = value; }
        }
    }
}
