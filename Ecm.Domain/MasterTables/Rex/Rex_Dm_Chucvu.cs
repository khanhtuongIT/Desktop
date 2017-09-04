using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Chucvu
    {
        private object id_chucvu;
        private object ma_chucvu;
        private object ten_chucvu;
        private object heso_chucvu;
        private object luong_chucvu;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Chucvu
        {
            get { return id_chucvu; }
            set { id_chucvu = value; }
        }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Chucvu
        {
            get { return ma_chucvu; }
            set { ma_chucvu = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Chucvu
        {
            get { return ten_chucvu; }
            set { ten_chucvu = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Heso_Chucvu
        {
            get { return heso_chucvu; }
            set { heso_chucvu = value; }
        }    
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Luong_Chucvu
        {
            get { return luong_chucvu; }
            set { luong_chucvu = value; }
        }    
    
    }
}
