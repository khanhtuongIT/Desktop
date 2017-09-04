using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.MasterTables.Bar
{
    public class Bar_Dm_Menu
    {
        private object id_menu;
        private object ma_menu;
        private object ten_menu;
        private object ghichu;
        private object id_nhom_hanghoa_ban;
        private object visible;
        private object id_cuahang_ban;
        private object id_loai_hanghoa_ban;
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Menu
        {
            get { return id_menu; }
            set { id_menu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Menu
        {
            get { return ma_menu; }
            set { ma_menu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Menu
        {
            get { return ten_menu; }
            set { ten_menu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ghichu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhom_Hanghoa_Ban
        {
            get { return id_nhom_hanghoa_ban; }
            set { id_nhom_hanghoa_ban = value; }
        }


        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Visible
        {
            get { return visible; }
            set { visible = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Cuahang_Ban
        {
            get { return id_cuahang_ban; }
            set { id_cuahang_ban = value; }
        }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Loai_Hanghoa_Ban
        {
            get { return id_loai_hanghoa_ban; }
            set { id_loai_hanghoa_ban = value; }
        }
        
    }
}
