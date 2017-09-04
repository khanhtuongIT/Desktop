using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Ware
{
    public class Ware_Xuat_Hh_Mua
    {
        private object id_xuat_hh_mua;
        private object id_kho_hanghoa_mua_xuat;
        private object sochungtu;
        private object ngay_chungtu_xuat;
        private object id_nhansu_xuat;
        private object id_kho_hanghoa_mua_nhap;
        private object ngay_chungtu_nhap;
        private object id_nhansu_nhap;
        private object ghichu;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Xuat_Hh_Mua
        {
            get { return id_xuat_hh_mua; }
            set { id_xuat_hh_mua = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Kho_Hanghoa_Mua_Xuat
        {
            get { return id_kho_hanghoa_mua_xuat; }
            set { id_kho_hanghoa_mua_xuat = value; }
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
        public object Id_Kho_Hanghoa_Mua_Nhap
        {
            get { return id_kho_hanghoa_mua_nhap; }
            set { id_kho_hanghoa_mua_nhap = value; }
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
    }
}
