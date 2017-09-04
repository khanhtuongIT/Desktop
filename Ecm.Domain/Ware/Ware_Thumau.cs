using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Ware
{
    public class Ware_Thumau
    {
        private object id_thumau;
        private object id_nhansu;
        private object ten_lobanh;
        private object id_hanghoa_ban;
        private object soluong;
        private object dongia;
        private object tenhang_doithu;
        private object dongia_doithu;
        private object ngaythu;
        private object sanluong;
        private object ketqua;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Thumau
        {
            get { return id_thumau; }
            set { id_thumau = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu
        {
            get { return id_nhansu; }
            set { id_nhansu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Lobanh
        {
            get { return ten_lobanh; }
            set { ten_lobanh = value; }
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
        public object Dongia
        {
            get { return dongia; }
            set { dongia = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Tenhang_Doithu
        {
            get { return tenhang_doithu; }
            set { tenhang_doithu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Dongia_Doithu
        {
            get { return dongia_doithu; }
            set { dongia_doithu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngaythu
        {
            get { return ngaythu; }
            set { ngaythu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Sanluong
        {
            get { return sanluong; }
            set { sanluong = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ketqua
        {
            get { return ketqua; }
            set { ketqua = value; }
        }
       
    }
}
