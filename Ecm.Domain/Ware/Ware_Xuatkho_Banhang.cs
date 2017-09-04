using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Ware
{
    public class Ware_Xuatkho_Banhang
    {
        private object id_xuatkho_banhang; 
        private object sochungtu;
        private object ngay_chungtu;
        private object ngay_thanhtoan;
        private object id_khachhang;    
        private object hoten_nguoimua;
        private object id_nhansu_bh;
        private object id_cuahang_ban;
        private object sotien;
        private object per_vat;
        private object sotien_vat;
        private object per_hoadon;
        private object id_nhansu_edit;
        private object ghichu_edit;
        private object nguoinhan;
        private object per_chietkhau;
        private object thanhtien_chietkhau;
        private object id_hdbanhang;

        //waregen
        private object gen_fr_hhsx;
        private object id_donmuahang;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Xuatkho_Banhang  
        {
            get { return id_xuatkho_banhang; }
            set { id_xuatkho_banhang = value; }
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
        public object Id_Nhansu_Bh
        {
            get { return id_nhansu_bh; }
            set { id_nhansu_bh = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Cuahang_Ban
        {
            get { return id_cuahang_ban; }
            set { id_cuahang_ban = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Sotien
        {
            get { return sotien; }
            set { sotien = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Per_Vat
        {
            get { return per_vat; }
            set { per_vat = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Sotien_Vat
        {
            get { return sotien_vat; }
            set { sotien_vat = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Per_Hoadon
        {
            get { return per_hoadon; }
            set { per_hoadon = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu_Edit
        {
            get { return id_nhansu_edit; }
            set { id_nhansu_edit = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ghichu_Edit
        {
            get { return ghichu_edit; }
            set { ghichu_edit = value; }
        }

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Hdbanhang
        {
            get { return id_hdbanhang; }
            set { id_hdbanhang = value; }
        }

        #region ware gen
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Gen_Fr_Hhsx
        {
            get { return gen_fr_hhsx; }
            set { gen_fr_hhsx = value; }
        }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Donmuahang
        {
            get { return id_donmuahang; }
            set { id_donmuahang = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Nguoinhan
        {
            get { return nguoinhan; }
            set { nguoinhan = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Per_Chietkhau
        {
            get { return per_chietkhau; }
            set { per_chietkhau = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Thanhtien_Chietkhau
        {
            get { return thanhtien_chietkhau; }
            set { thanhtien_chietkhau = value; }
        }

        #endregion

    }
}
