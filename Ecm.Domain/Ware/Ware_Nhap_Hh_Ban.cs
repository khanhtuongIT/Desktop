using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Ware
{
    public class Ware_Nhap_Hh_Ban
    {
        private object id_nhap_hh_ban;
        private object id_cuahang_ban;
        private object sochungtu;
        private object ngay_nhanhang;
        private object nguoi_giaohang;
        private object id_nhansu_nhanhang; // nhân sự lập phiếu
        private object ghichu;
        private object doc_process_status;
        private object id_xuat_hh_ban;
        private object id_ncc;
        private object id_nhansu_nhan; // nhân sự nhận hàng
        private object is_vat;  // check GTGT
        private object nguyenlieu;

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhap_Hh_Ban
        {
            get { return id_nhap_hh_ban; }
            set { id_nhap_hh_ban = value; }
        }

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Cuahang_Ban
        {
            get { return id_cuahang_ban; }
            set { id_cuahang_ban = value; }
        }

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Sochungtu
        {
            get { return sochungtu; }
            set { sochungtu = value; }
        }

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Nhanhang
        {
            get { return ngay_nhanhang; }
            set { ngay_nhanhang = value; }
        }

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Nguoi_Giaohang
        {
            get { return nguoi_giaohang; }
            set { nguoi_giaohang = value; }
        }

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu_Nhanhang
        {
            get { return id_nhansu_nhanhang; }
            set { id_nhansu_nhanhang = value; }
        }

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Ghichu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Doc_Process_Status
        {
            get { return doc_process_status; }
            set { doc_process_status = value; }
        }

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Xuat_Hh_Ban
        {
            get { return id_xuat_hh_ban; }
            set { id_xuat_hh_ban = value; }
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
        public object Id_Nhansu_Nhan
        {
            get { return id_nhansu_nhan; }
            set { id_nhansu_nhan = value; }
        }


        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Is_Vat
        {
            get { return is_vat; }
            set { is_vat = value; }
        }

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Nguyenlieu
        {
            get { return nguyenlieu; }
            set { nguyenlieu = value; }
        }

    }
}
