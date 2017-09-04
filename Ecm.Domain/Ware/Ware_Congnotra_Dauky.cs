using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Ware
{
    public class Ware_Congnotra_Dauky
    {
        private object id_congnotra_dauky;
        private object id_khachhang;
        private object chungtu_goc;
        private object ngay_chungtu;
        private object sotien;
        private object id_tiente;
        private object tygia;
        private object sotien_quydoi;
        private object ghichu;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Congnotra_Dauky
        {
            get { return id_congnotra_dauky; }
            set { id_congnotra_dauky = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Khachhang
        {
            get { return id_khachhang; }
            set { id_khachhang = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Chungtu_Goc
        {
            get { return chungtu_goc; }
            set { chungtu_goc = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Chungtu
        {
            get { return ngay_chungtu; }
            set { ngay_chungtu = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Sotien
        {
            get { return sotien; }
            set { sotien = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Tiente
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
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Sotien_Quydoi
        {
            get { return sotien_quydoi; }
            set { sotien_quydoi = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ghichu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }
    }
}
