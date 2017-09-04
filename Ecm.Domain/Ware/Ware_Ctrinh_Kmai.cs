using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Ware
{
    public class Ware_Ctrinh_Kmai
    {
        private object id_ctrinh_kmai;
        private object ma_ctrinh_kmai;
        private object ten_ctrinh_kmai;
        private object ngay_batdau;
        private object ngay_ketthuc;
        private object ghichu;
        private object per_hoadon;
        private object giam_hoadon;
        private object kmai_rent;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Ctrinh_Kmai
        {
            get { return id_ctrinh_kmai; }
            set { id_ctrinh_kmai = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Ctrinh_Kmai
        {
            get { return ma_ctrinh_kmai; }
            set { ma_ctrinh_kmai = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Ctrinh_Kmai
        {
            get { return ten_ctrinh_kmai; }
            set { ten_ctrinh_kmai = value; }
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
        public object Ghichu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Per_Hoadon
        {
            get { return per_hoadon; }
            set { per_hoadon = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Giam_Hoadon
        {
            get { return giam_hoadon; }
            set { giam_hoadon = value; }
        }

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Kmai_Rent 
        {
            get { return kmai_rent; }
            set { kmai_rent = value; }
        }
       
      
    }
}
