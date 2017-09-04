using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecm.Domain.Ware
{
    public class Ware_Hanghoa_Dinhgia_Khuvuc
    {
        private object id_hanghoa_dinhgia_khuvuc;
        private object id_hanghoa_dinhgia;
        private object id_khuvuc;
        private object dongia;






        [System.Xml.Serialization.XmlElement]
        public object Id_Hanghoa_Dinhgia_Khuvuc { get { return id_hanghoa_dinhgia_khuvuc; } set { id_hanghoa_dinhgia_khuvuc = value; } }
        [System.Xml.Serialization.XmlElement]
        public object Id_Hanghoa_Dinhgia { get { return id_hanghoa_dinhgia; } set { id_hanghoa_dinhgia = value; } }
        [System.Xml.Serialization.XmlElement]
        public object Id_Khuvuc { get { return id_khuvuc; } set { id_khuvuc = value; } }
        [System.Xml.Serialization.XmlElement]
        public object Dongia { get { return dongia; } set { dongia = value; } }






    }														

}
