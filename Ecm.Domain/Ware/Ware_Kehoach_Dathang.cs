using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Ware
{
    public class Ware_Kehoach_Dathang_Chitiet
    {
        private object id_kehoach_dathang_chitiet;
        private object id_kehoach_dathang;
        private object id_khachhang;
        private object id_hanghoa_ban;
        private object soluong;

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Kehoach_Dathang_Chitiet
        {
            get { return id_kehoach_dathang_chitiet; }
            set { id_kehoach_dathang_chitiet = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Kehoach_Dathang
        {
            get { return id_kehoach_dathang; }
            set { id_kehoach_dathang = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Khachhang
        {
            get { return id_khachhang; }
            set { id_khachhang = value; }
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

    }
}
