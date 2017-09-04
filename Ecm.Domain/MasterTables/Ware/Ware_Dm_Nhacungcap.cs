using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.MasterTables.Ware
{
    public class Ware_Dm_Nhacungcap
    {
        private object id_nhacungcap;
        private object ma_nhacungcap;
        private object ten_nhacungcap;
        private object diachi_nhacungcap;
        private object masothue;
        private object dienthoai;
        private object fax;
        private object email;
        private object website;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhacungcap
        {
            get { return id_nhacungcap; }
            set { id_nhacungcap = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Nhacungcap
        {
            get { return ma_nhacungcap; }
            set { ma_nhacungcap = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Nhacungcap
        {
            get { return ten_nhacungcap; }
            set { ten_nhacungcap = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Diachi_Nhacungcap
        {
            get { return diachi_nhacungcap; }
            set { diachi_nhacungcap = value; }
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
    }
}
