using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Phucap
    {
        private object id_phucap;

       
        private object ma_phucap;
        private object ten_phucap;
        private object heso_phucap;
        private object luong_phucap;
        private object id_parent;
        private object chiuthue;
        private object phucap_chung;
        private object id_chucvu;

        [System.Xml.Serialization.XmlElement()]
        public object Id_Dm_Phucap
        {
            get { return id_phucap; }
            set { id_phucap = value; }
        }

        [System.Xml.Serialization.XmlElement()]
        public object Ma_Phucap
        {
            set { ma_phucap = value; }
            get { return ma_phucap; }
        }

        [System.Xml.Serialization.XmlElement()]
        public object Ten_Phucap
        {
            set { ten_phucap = value; }
            get { return ten_phucap; }
        }
        [System.Xml.Serialization.XmlElement()]
        public object Heso_Phucap
        {
            set { heso_phucap = value; }
            get { return heso_phucap; }
        }
        [System.Xml.Serialization.XmlElement()]
        public object Luong_Phucap
        {
            set { luong_phucap = value; }
            get { return luong_phucap; }
        }

        [System.Xml.Serialization.XmlElement()]
        public object Id_Parent
        {
            set { id_parent = value; }
            get { return id_parent; }
        }

        [System.Xml.Serialization.XmlElement()]
        public object Chiuthue
        {
            set { chiuthue = value; }
            get { return chiuthue; }
        }

        [System.Xml.Serialization.XmlElement()]
        public object Phucap_Chung
        {
            set { phucap_chung = value; }
            get { return phucap_chung; }
        }

        [System.Xml.Serialization.XmlElement()]
        public object Id_Chucvu
        {
            set { id_chucvu = value; }
            get { return id_chucvu; }
        }
    }
}
