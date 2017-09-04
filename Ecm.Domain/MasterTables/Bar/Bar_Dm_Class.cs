using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecm.Domain.MasterTables.Bar
{
    public class Bar_Dm_Class
    {
        private object id_class;
        private object ma_class;
        private object ten_class;
        private object ghichu;






        [System.Xml.Serialization.XmlElement]
        public object Id_Class { get { return id_class; } set { id_class = value; } }
        [System.Xml.Serialization.XmlElement]
        public object Ma_Class { get { return ma_class; } set { ma_class = value; } }
        [System.Xml.Serialization.XmlElement]
        public object Ten_Class { get { return ten_class; } set { ten_class = value; } }
        [System.Xml.Serialization.XmlElement]
        public object Ghichu { get { return ghichu; } set { ghichu = value; } }






    }														

}
