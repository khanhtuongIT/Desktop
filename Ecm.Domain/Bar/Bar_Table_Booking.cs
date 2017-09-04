using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Bar
{
    public class Bar_Table_Booking
    {
        private object id_booking;
        private object ma_booking;
        private object ten_khachhang_booking;
        private object tien_booking;
        private object ngay_nhan_booking;
        private object ngay_den;
        private object ngay_xacnhan;
        private object ghichu;
        private object nhansu_booking;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Booking {
            get { return id_booking; }
            set { this.id_booking = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Booking {
            get { return ma_booking; }
            set { this.ma_booking = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Khachhang_Booking {
            get { return ten_khachhang_booking; }
            set { this.ten_khachhang_booking = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Tien_Booking {
            get { return tien_booking; }
            set { this.tien_booking = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Nhan_Booking {
            get { return ngay_nhan_booking; }
            set { this.ngay_nhan_booking = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Den {
            get { return ngay_den; }
            set { this.ngay_den = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Xacnhan
        {
            get
            {
                return ngay_xacnhan;
            }
            set
            {
                
                ngay_xacnhan = value;
            }
        }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object GhiChu {
            get { return ghichu; }
            set { this.ghichu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object NhanSu_Booking {
            get { return nhansu_booking; }
            set { this.nhansu_booking = value; }
        }


    }
}
