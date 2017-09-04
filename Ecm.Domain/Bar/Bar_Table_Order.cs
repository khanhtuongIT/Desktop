using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Bar
{
    public class Bar_Table_Order
    {
        private object id_table_order;
        private object id_nhansu_order;
        private object ngay_order;
        private object id_ca_lamviec;
        private object id_table;
        private object id_nhansu_casher;
        private object ngay_casher;
        private object sotien;
        private object finish;
        private object id_cuahang_ban;
        private object id_vip_member_card;
        private object id_nhansu_bill;
        private object id_khachhang;
        private object sochungtu;
        private object id_nhansu_km;
        private object id_booking;
        private object tien_booking;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Table_Order
        {
            get { return id_table_order; }
            set { id_table_order = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu_Order
        {
            get { return id_nhansu_order; }
            set { id_nhansu_order = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Order
        {
            get { return ngay_order; }
            set { ngay_order = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Ca_Lamviec
        {
            get { return id_ca_lamviec; }
            set { id_ca_lamviec = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Table
        {
            get { return id_table; }
            set { id_table = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu_Casher
        {
            get { return id_nhansu_casher; }
            set { id_nhansu_casher = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Casher
        {
            get { return ngay_casher; }
            set { ngay_casher = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Sotien
        {
            get { return sotien; }
            set { sotien = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Finish
        {
            get { return finish; }
            set { finish = value; }
        }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Cuahang_Ban
        {
            get { return id_cuahang_ban; }
            set { id_cuahang_ban = value; }
        }    
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Vip_Member_Card
        {
            get { return id_vip_member_card; }
            set { id_vip_member_card = value; }
        }        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu_Bill
        {
            get { return id_nhansu_bill; }
            set { id_nhansu_bill = value; }
        }        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Khachhang
        {
            get { return id_khachhang; }
            set { id_khachhang = value; }
        }        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Sochungtu
        {
            get { return sochungtu; }
            set { sochungtu = value; }
        }        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu_Km
        {
            get { return id_nhansu_km; }
            set { id_nhansu_km = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Booking {
            get {
                return this.id_booking;
            }
            set {
                this.id_booking = value;
            }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Tien_Booking {
            get {
                return this.tien_booking;
            }
            set {
                this.tien_booking = value;
            }
        }

    }
}
