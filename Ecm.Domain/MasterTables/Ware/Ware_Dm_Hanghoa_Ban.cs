using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Ecm.Domain.MasterTables.Ware
{
    public class Ware_Dm_Hanghoa_Ban
    {
        private object id_hanghoa_ban;
        private object ma_hanghoa_ban;
        private object ten_hanghoa_ban;
        private object id_loai_hanghoa_ban;
        private object size;
        private object quycach;
        private object id_donvitinh;
        private object soluong_min;
        private object barcode_txt;
        private object hinh;
        private object dongia_mua;
        private object xuatxu;
        private object hamluong;
        private object id_khachhang;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Hanghoa_Ban
        {
            get { return id_hanghoa_ban; }
            set { id_hanghoa_ban = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Hanghoa_Ban
        {
            get { return ma_hanghoa_ban; }
            set { ma_hanghoa_ban = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Hanghoa_Ban
        {
            get { return ten_hanghoa_ban; }
            set { ten_hanghoa_ban = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Loai_Hanghoa_Ban
        {
            get { return id_loai_hanghoa_ban; }
            set { id_loai_hanghoa_ban = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Size
        {
            get { return size; }
            set { size = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Quycach
        {
            get { return quycach; }
            set { quycach = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Dongia_Mua
        {
            get { return dongia_mua; }
            set { dongia_mua = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Donvitinh
        {
            get { return id_donvitinh; }
            set { id_donvitinh = value; }
        }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Soluong_Min
        {
            get { return soluong_min; }
            set { soluong_min = value; }
        }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Barcode_Txt
        {
            get { return barcode_txt; }
            set { barcode_txt = value; }
        }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Hinh
        {
            get { return hinh; }
            set { hinh = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Hamluong
        {
            get { return hamluong; }
            set { hamluong = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Xuatxu
        {
            get { return xuatxu; }
            set { xuatxu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Khachhang
        {
            get { return id_khachhang; }
            set { id_khachhang = value; }
        }    
    }
}
