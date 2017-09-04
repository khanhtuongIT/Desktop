using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Ware
{
    public class Ware_Xuat_Hh_Ban
    {
        private object id_xuat_hh_ban;
        private object id_cuahang_ban_xuat;
        private object sochungtu;
        private object ngay_chungtu_xuat;
        private object id_nhansu_xuat;
        private object id_cuahang_ban_nhap;
        private object ngay_chungtu_nhap;
        private object id_nhansu_nhap;
        private object ghichu;
        private object doc_process_status;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Xuat_Hh_Ban
        {
            get { return id_xuat_hh_ban; }
            set { id_xuat_hh_ban = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Cuahang_Ban_Xuat
        {
            get { return id_cuahang_ban_xuat; }
            set { id_cuahang_ban_xuat = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Sochungtu
        {
            get { return sochungtu; }
            set { sochungtu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Chungtu_Xuat
        {
            get { return ngay_chungtu_xuat; }
            set { ngay_chungtu_xuat = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu_Xuat
        {
            get { return id_nhansu_xuat; }
            set { id_nhansu_xuat = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Cuahang_Ban_Nhap
        {
            get { return id_cuahang_ban_nhap; }
            set { id_cuahang_ban_nhap = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Chungtu_Nhap
        {
            get { return ngay_chungtu_nhap; }
            set { ngay_chungtu_nhap = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu_Nhap
        {
            get { return id_nhansu_nhap; }
            set { id_nhansu_nhap = value; }
        }
       
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ghichu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Doc_Process_Status
        {
            get { return doc_process_status; }
            set { doc_process_status = value; }
        }

    }
}
