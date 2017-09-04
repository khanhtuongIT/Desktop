using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Ware
{
    public class Ware_Khachhang_Vip
    {
        private object id_khachhang_vip;
        private object id_khachhang;
        private object id_kho_hanghoa_mua;
        private object id_cuahang_ban;
        private object per_hoadon;
        private object ma_kho_hanghoa;
        private object ngay_batdau;
        private object ngay_ketthuc;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Khachhang_Vip
        {
            get { return id_khachhang_vip; }
            set { id_khachhang_vip = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Khachhang
        {
            get { return id_khachhang; }
            set { id_khachhang = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Kho_Hanghoa_Mua
        {
            get { return id_kho_hanghoa_mua; }
            set { id_kho_hanghoa_mua = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Cuahang_Ban
        {
            get { return id_cuahang_ban; }
            set { id_cuahang_ban = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Per_Hoadon
        {
            get { return per_hoadon; }
            set { per_hoadon = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Kho_Hanghoa
        {
            get { return ma_kho_hanghoa; }
            set { ma_kho_hanghoa = value; }
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
