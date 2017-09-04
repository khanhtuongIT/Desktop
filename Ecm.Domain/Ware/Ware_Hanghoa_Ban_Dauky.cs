using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Ware
{
    public class Ware_Hanghoa_Ban_Dauky
    {
        private object id_hanghoa_ban_dauky;
        private object ngay_nhap;
        private object id_cuahang_ban;
        private object id_hanghoa_ban;
        private object soluong;
        private object id_donvitinh;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Hanghoa_Ban_Dauky
        {
            get { return id_hanghoa_ban_dauky; }
            set { id_hanghoa_ban_dauky = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Nhap
        {
            get { return ngay_nhap; }
            set { ngay_nhap = value; }
        }

       

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Cuahang_Ban
        {
            get { return id_cuahang_ban; }
            set { id_cuahang_ban = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Hanghoa_Ban
        {
            get { return id_hanghoa_ban; }
            set { id_hanghoa_ban = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Soluong
        {
            get { return soluong; }
            set { soluong = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Donvitinh
        {
            get { return id_donvitinh; }
            set { id_donvitinh = value; }
        }
    }
}
