using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.MasterTables.Ware
{
    public class Ware_Dongia_Cap
    {
        private object id_cap;
        private object giatri;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Cap
        {
            get { return id_cap; }
            set { id_cap = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Giatri
        {
            get { return giatri; }
            set { giatri = value; }
        }
        
    }
}
