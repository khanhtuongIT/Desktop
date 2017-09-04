using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecm.Domain.Bar
{
    public class Bar_Rentcost
    {
        private object id_rentcost;
        private object id_class;
        private object id_rentlevel;
        private object dongia;
        private object ngay_batdau;
        private object ngay_ketthuc;
        private object id_cuahang_ban;



        [System.Xml.Serialization.XmlElement]
        public object Id_Rentcost { get { return id_rentcost; } set { id_rentcost = value; } }
        [System.Xml.Serialization.XmlElement]
        public object Id_Class { get { return id_class; } set { id_class = value; } }
        [System.Xml.Serialization.XmlElement]
        public object Id_Rentlevel { get { return id_rentlevel; } set { id_rentlevel = value; } }
        [System.Xml.Serialization.XmlElement]
        public object Dongia { get { return dongia; } set { dongia = value; } }
        [System.Xml.Serialization.XmlElement]
        public object Ngay_Batdau { get { return ngay_batdau; } set { ngay_batdau = value; } }
        [System.Xml.Serialization.XmlElement]
        public object Ngay_Ketthuc { get { return ngay_ketthuc; } set { ngay_ketthuc = value; } }
        [System.Xml.Serialization.XmlElement]
        public object Id_Cuahang_Ban { get { return id_cuahang_ban; } set { id_cuahang_ban = value; } }



    }														
									

}
