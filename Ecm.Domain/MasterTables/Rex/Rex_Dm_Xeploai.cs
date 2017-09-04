using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Xeploai
    {
        private object id_xeploai;
        private object ma_xeploai;
        private object ten_xeploai;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Xeploai
        {
            get { return id_xeploai; }
            set { id_xeploai = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Xeploai
        {
            get { return ma_xeploai; }
            set { ma_xeploai = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Xeploai
        {
            get { return ten_xeploai; }
            set { ten_xeploai = value; }
        }
    }
}
