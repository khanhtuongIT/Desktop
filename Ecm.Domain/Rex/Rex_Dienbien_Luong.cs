using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Rex
{
    public class Rex_Dienbien_Luong
    {
        private object id_dienbien_luong;
        private object id_nhansu;
        private object id_quyetdinh;
        private object id_bacluong;
        private object bhxh;
        private object ngay_hieuluc_batdau;
        private object ngay_hieuluc_ketthuc;
        private object luong_thoathuan;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Dienbien_Luong
        {
            get { return id_dienbien_luong; }
            set { id_dienbien_luong = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu
        {
            get { return id_nhansu; }
            set { id_nhansu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Quyetdinh
        {
            get { return id_quyetdinh; }
            set { id_quyetdinh = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Bacluong
        {
            get { return id_bacluong; }
            set { id_bacluong = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Bhxh
        {
            get { return bhxh; }
            set { bhxh = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Hieuluc_Batdau
        {
            get { return ngay_hieuluc_batdau; }
            set { ngay_hieuluc_batdau = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Hieuluc_Ketthuc
        {
            get { return ngay_hieuluc_ketthuc; }
            set { ngay_hieuluc_ketthuc = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Luong_Thoathuan
        {
            get { return luong_thoathuan; }
            set { luong_thoathuan = value; }
        }
    }
}