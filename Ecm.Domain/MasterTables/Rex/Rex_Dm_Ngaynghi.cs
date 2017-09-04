using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Ngaynghi
    {
        private object id_ngaynghi;
        private object ma_ngaynghi;
        private object ten_ngaynghi;
        private object ngaynghi;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Ngaynghi
        {
            get { return id_ngaynghi; }
            set { id_ngaynghi = value; }
        }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Ngaynghi
        {
            get { return ma_ngaynghi; }
            set { ma_ngaynghi = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Ngaynghi
        {
            get { return ten_ngaynghi; }
            set { ten_ngaynghi = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngaynghi
        {
            get { return ngaynghi; }
            set { ngaynghi = value; }
        }    
    
    }
}
