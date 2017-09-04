using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.MasterTables.Ware
{
    public class Ware_Dm_Xe
    {
        private object id_xe;
        private object ma_xe;
        private object ten_xe;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Xe
        {
            get { return id_xe; }
            set { id_xe = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Xe
        {
            get { return ma_xe; }
            set { ma_xe = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Xe
        {
            get { return ten_xe; }
            set { ten_xe = value; }
        }
        
    }
}
