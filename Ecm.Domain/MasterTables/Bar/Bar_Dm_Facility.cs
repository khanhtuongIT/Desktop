using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecm.Domain.MasterTables.Bar
{
    public class Bar_Dm_Facility
    {
        private object id_facility;
        private object ma_facility;
        private object ten_facility;
        private object ghichu;






        [System.Xml.Serialization.XmlElement]
        public object Id_Facility { get { return id_facility; } set { id_facility = value; } }
        [System.Xml.Serialization.XmlElement]
        public object Ma_Facility { get { return ma_facility; } set { ma_facility = value; } }
        [System.Xml.Serialization.XmlElement]
        public object Ten_Facility { get { return ten_facility; } set { ten_facility = value; } }
        [System.Xml.Serialization.XmlElement]
        public object Ghichu { get { return ghichu; } set { ghichu = value; } }






    }														

}
