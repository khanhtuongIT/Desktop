using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Ware
{
    public class Ware_Hanghoa_Dinhgia
    {
        private object id_Hanghoa_dinhgia;
        private object id_hanghoa_ban;
        private object id_donvitinh;
        private object dongia_ban;
        private object dongia;
        private object dongia_bansi;
        private object ngay_batdau;
        private object ngay_ketthuc;
        private object ghichu;
        private object barcode;
        private object stt;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Hanghoa_Dinhgia
        {
            get { return id_Hanghoa_dinhgia; }
            set { id_Hanghoa_dinhgia = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Hanghoa_Ban
        {
            get { return id_hanghoa_ban; }
            set { id_hanghoa_ban = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Donvitinh
        {
            get { return id_donvitinh; }
            set { id_donvitinh = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Dongia_Ban
        {
            get { return dongia_ban; }
            set { dongia_ban = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Dongia
        {
            get { return dongia; }
            set { dongia = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Dongia_Bansi
        {
            get { return dongia_bansi; }
            set { dongia_bansi = value; }
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
        public object Barcode_Txt
        {
            get { return barcode; }
            set { barcode = value; }
        }

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Stt
        {
            get { return stt; }
            set { stt = value; }
        }

    }
}
