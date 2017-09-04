using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Quyetdinh
    {
        private object id_quyetdinh;
        private object ma_quyetdinh;
        private object sohieu;
        private object trichyeu;
        private object noidung;
        private object nguoiky;
        private object ngayky;
        private object ngaybatdau;
        private object ngayketthuc;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Quyetdinh
        {
            get { return id_quyetdinh; }
            set { id_quyetdinh = value; }
        }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Quyetdinh
        {
            get { return ma_quyetdinh; }
            set { ma_quyetdinh = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Sohieu
        {
            get { return sohieu; }
            set { sohieu = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Trichyeu
        {
            get { return trichyeu; }
            set { trichyeu = value; }
        }    
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Noidung
        {
            get { return noidung; }
            set { noidung = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Nguoiky
        {
            get { return nguoiky; }
            set { nguoiky = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngayky
        {
            get { return ngayky; }
            set { ngayky = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngaybatdau
        {
            get { return ngaybatdau; }
            set { ngaybatdau = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngayketthuc
        {
            get { return ngayketthuc; }
            set { ngayketthuc = value; }
        }
    
    }
}
