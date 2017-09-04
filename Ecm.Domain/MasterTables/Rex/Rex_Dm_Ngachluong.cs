using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Ngachluong
    {
        private object id_ngachluong;
        private object ma_ngachluong;
        private object ten_ngachluong;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Ngachluong
        {
            get { return id_ngachluong; }
            set { id_ngachluong = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Ngachluong
        {
            get { return ma_ngachluong; }
            set { ma_ngachluong = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Ngachluong
        {
            get { return ten_ngachluong; }
            set { ten_ngachluong = value; }
        }
       
    
    }
}
