using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Rex
{
    public class Rex_Thamgia_Tochuc
    {
        private object id_thamgia_tochuc;
        private object id_tochuc;
        private object id_chucvu;
        private object id_nhansu;
        private object ngay_batdau;
        private object ngay_ketthuc;
        private object noi_thamgia;
        private object con_sinhhoat;
        private object uid;
        private object date_create;
        private object date_modify;
        private object den_nam;
        private object tu_nam;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Thamgia_Tochuc
        {
            get { return id_thamgia_tochuc; }
            set { id_thamgia_tochuc = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Tochuc
        {
            get { return id_tochuc; }
            set { id_tochuc = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Chucvu
        {
            get { return id_chucvu; }
            set { id_chucvu= value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu
        {
            get { return id_nhansu; }
            set { id_nhansu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Batdau
        {
            get { return ngay_batdau; }
            set { ngay_batdau = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Ketthuc
        {
            get { return ngay_ketthuc; }
            set { ngay_ketthuc = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Noi_Thamgia
        {
            get { return noi_thamgia; }
            set { noi_thamgia = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Con_Sinhhoat
        {
            get { return con_sinhhoat; }
            set { con_sinhhoat = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Uid
        {
            get { return uid; }
            set { uid= value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Date_Create
        {
            get { return date_create; }
            set { date_create = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Date_Modify
        {
            get { return date_modify; }
            set { date_modify  = value; }
        } 

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Tu_Nam
        {
            get { return tu_nam; }
            set { tu_nam = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Den_Nam
        {
            get { return den_nam; }
            set { den_nam = value; }
        }
    }
}
