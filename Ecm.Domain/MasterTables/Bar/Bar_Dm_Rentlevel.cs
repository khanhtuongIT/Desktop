using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecm.Domain.MasterTables.Bar
{
    public class Bar_Dm_Rentlevel
    {
        private object id_rentlevel;
        private object ma_rentlevel;
        private object ten_rentlevel;
        private object ghichu;






        [System.Xml.Serialization.XmlElement]
        public object Id_Rentlevel { get { return id_rentlevel; } set { id_rentlevel = value; } }
        [System.Xml.Serialization.XmlElement]
        public object Ma_Rentlevel { get { return ma_rentlevel; } set { ma_rentlevel = value; } }
        [System.Xml.Serialization.XmlElement]
        public object Ten_Rentlevel { get { return ten_rentlevel; } set { ten_rentlevel = value; } }
        [System.Xml.Serialization.XmlElement]
        public object Ghichu { get { return ghichu; } set { ghichu = value; } }






    }														

}
