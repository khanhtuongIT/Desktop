using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Bacluong
    {
        private object id_ngachluong;
        private object id_bacluong;
        private object ma_bacluong;
        private object ten_bacluong;
        private object heso;
        private object luong_thoathuan;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Ngachluong
        {
            get { return id_ngachluong; }
            set { id_ngachluong = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Bacluong
        {
            get { return id_bacluong; }
            set { id_bacluong = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Bacluong
        {
            get { return ma_bacluong; }
            set { ma_bacluong = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Bacluong
        {
            get { return ten_bacluong; }
            set { ten_bacluong = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Heso
        {
            get { return heso; }
            set { heso = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Luong_Thoathuan
        {
            get { return luong_thoathuan; }
            set { luong_thoathuan = value; }
        }

       
    
    }
}
