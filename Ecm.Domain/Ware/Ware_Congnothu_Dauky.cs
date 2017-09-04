using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Ware
{
    public class Ware_Congnothu_Dauky
    {
        private object id_congnothu_dauky;
        private object id_khachhang;
        private object sotien_no;
        private object sotien_co;
        private object ghichu;
        private object chungtu_goc;
        private object ngay_chungtu;
        private object sotien_quydoi;
        private object id_tiente;
        private object tygia;
        private object id_ncc;
        private object ma_doituong;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Congnothu_Dauky
        {
            get { return id_congnothu_dauky; }
            set { id_congnothu_dauky = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Khachhang
        {
            get { return id_khachhang; }
            set { id_khachhang = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Sotien_No
        {
            get { return sotien_no; }
            set { sotien_no = value; }
        }
        
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Sotien_Co
        {
            get { return sotien_co; }
            set { sotien_co = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ghichu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Chungtu_goc
        {
            get { return chungtu_goc; }
            set { chungtu_goc = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_chungtu
        {
            get { return ngay_chungtu; }
            set { ngay_chungtu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Sotien_quydoi
        {
            get { return sotien_quydoi; }
            set { sotien_quydoi = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_tiente
        {
            get { return id_tiente; }
            set { id_tiente = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Tygia
        {
            get { return tygia; }
            set { tygia = value; }
        }

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Ncc
        {
            get { return id_ncc; }
            set { id_ncc = value; }
        }

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Doituong
        {
            get { return ma_doituong; }
            set { ma_doituong = value; }
        }

    }
}
