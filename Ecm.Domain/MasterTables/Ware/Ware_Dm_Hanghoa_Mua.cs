using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Ware
{
    public class Ware_Dm_Hanghoa_Mua
    {
        private object id_hanghoa_mua;
        private object ma_hanghoa_mua;
        private object ten_hanghoa_mua;
        private object id_loai_hanghoa_mua;
        private object size;
        private object quycach;
        private object id_nhasanxuat;
        private object id_donvitinh;
        private object soluong_min;
        private object barcode_txt;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Hanghoa_Mua
        {
            get { return id_hanghoa_mua; }
            set { id_hanghoa_mua = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Hanghoa_Mua
        {
            get { return ma_hanghoa_mua; }
            set { ma_hanghoa_mua = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Hanghoa_Mua
        {
            get { return ten_hanghoa_mua; }
            set { ten_hanghoa_mua = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Loai_Hanghoa_Mua
        {
            get { return id_loai_hanghoa_mua; }
            set { id_loai_hanghoa_mua = value; }
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
        public object Id_Nhasanxuat
        {
            get { return id_nhasanxuat; }
            set { id_nhasanxuat = value; }
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
    }
}
