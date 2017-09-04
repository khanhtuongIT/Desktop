using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Ware
{
    public class Ware_Khachhang_Quota
    {
        private object id_khachhang_quota;
        private object id_khachhang;
        private object max_quota;
        private object min_quota;
        private object songay_quota;
        private object ngay_batdau;
        private object ngay_ketthuc;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Khachhang_Quota
        {
            get { return id_khachhang_quota; }
            set { id_khachhang_quota = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Khachhang
        {
            get { return id_khachhang; }
            set { id_khachhang = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Max_Quota
        {
            get { return max_quota; }
            set { max_quota = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Min_Quota
        {
            get { return min_quota; }
            set { min_quota = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Songay_Quota
        {
            get { return songay_quota; }
            set { songay_quota = value; }
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
    
    }
}
