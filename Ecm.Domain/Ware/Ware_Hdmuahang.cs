using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Ware
{
    public class Ware_Hdmuahang
    {
        private object id_hdmuahang;
        private object sochungtu;
        private object ngay_chungtu;
        private object ngay_thanhtoan;
        private object id_khachhang; 
        private object hoten_nguoimua;
        private object hoten_nguoiban;
        private object sotien;
        private object phuongthuc_thanhtoan;
        private object so_seri;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Hdmuahang
        {
            get { return id_hdmuahang; }
            set { id_hdmuahang = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Sochungtu
        {
            get { return sochungtu; }
            set { sochungtu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Chungtu
        {
            get { return ngay_chungtu; }
            set { ngay_chungtu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Thanhtoan
        {
            get { return ngay_thanhtoan; }
            set { ngay_thanhtoan = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Khachhang
        {
            get { return id_khachhang; }
            set { id_khachhang = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Hoten_Nguoimua
        {
            get { return hoten_nguoimua; }
            set { hoten_nguoimua = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Hoten_Nguoiban
        {
            get { return hoten_nguoiban; }
            set { hoten_nguoiban = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Sotien
        {
            get { return sotien; }
            set { sotien = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Phuongthuc_Thanhtoan
        {
            get { return phuongthuc_thanhtoan; }
            set { phuongthuc_thanhtoan = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object So_Seri
        {
            get { return so_seri; }
            set { so_seri = value; }
        }
    }
}
