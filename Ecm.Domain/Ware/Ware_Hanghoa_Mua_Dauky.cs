using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Ware
{
    public class Ware_Hanghoa_Mua_Dauky
    {
        private object id_hanghoa_mua_dauky;
        private object ngay_nhap;
        private object id_kho_hanghoa_mua;
        private object id_hanghoa_mua;
        private object soluong;
        private object id_donvitinh;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Hanghoa_Mua_Dauky
        {
            get { return id_hanghoa_mua_dauky; }
            set { id_hanghoa_mua_dauky = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Nhap
        {
            get { return ngay_nhap; }
            set { ngay_nhap = value; }
        }

        

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Kho_Hanghoa_Mua
        {
            get { return id_kho_hanghoa_mua; }
            set { id_kho_hanghoa_mua = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Hanghoa_Mua
        {
            get { return id_hanghoa_mua; }
            set { id_hanghoa_mua = value; }
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
