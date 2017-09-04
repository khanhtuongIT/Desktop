using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecm.Domain.MasterTables.Bar
{
    public class Bar_Dm_Table_Facility
    {
        private object id_table_facility;
        private object id_table;
        private object id_facility;
        private object soluong;






        [System.Xml.Serialization.XmlElement]
        public object Id_Table_Facility { get { return id_table_facility; } set { id_table_facility = value; } }
        [System.Xml.Serialization.XmlElement]
        public object Id_Table { get { return id_table; } set { id_table = value; } }
        [System.Xml.Serialization.XmlElement]
        public object Id_Facility { get { return id_facility; } set { id_facility = value; } }
        [System.Xml.Serialization.XmlElement]
        public object Soluong { get { return soluong; } set { soluong = value; } }






    }														

}
