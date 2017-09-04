using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Ware
{
    public class Ware_Dieuxe_Chitiet
    {
        private object id_dieuxe_chitiet;
        private object id_dieuxe;
        private object id_xuatkho_banhang_chitiet;
        private object id_hanghoa_ban;
        private object id_donvitinh;
        private object soluong;
        private object dongia;
        private object id_cuahang_ban;
        private object guid_dieuxe_chitiet;

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Dieuxe_Chitiet
        {
            get { return id_dieuxe_chitiet; }
            set { id_dieuxe_chitiet = value; }
        }

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Dieuxe
        {
            get { return id_dieuxe; }
            set { id_dieuxe = value; }
        }

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Xuatkho_Banhang_Chitiet
        {
            get { return id_xuatkho_banhang_chitiet; }
            set { id_xuatkho_banhang_chitiet = value; }
        }

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Hanghoa_Ban
        {
            get { return id_hanghoa_ban; }
            set { id_hanghoa_ban = value; }
        }

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Donvitinh
        {
            get { return id_donvitinh; }
            set { id_donvitinh = value; }
        }

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Soluong
        {
            get { return soluong; }
            set { soluong = value; }
        }

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Dongia
        {
            get { return dongia; }
            set { dongia = value; }
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
        public object Guid_Dieuxe_Chitiet
        {
            get { return guid_dieuxe_chitiet; }
            set { guid_dieuxe_chitiet = value; }
        }
    }
}
