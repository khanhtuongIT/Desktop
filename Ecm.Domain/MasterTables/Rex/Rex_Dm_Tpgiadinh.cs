using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Tpgiadinh
    {
        private object id_tpgiadinh;
        private object ma_tpgiadinh;
        private object ten_tpgiadinh;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Tpgiadinh
        {
            get { return id_tpgiadinh; }
            set { id_tpgiadinh = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Tpgiadinh
        {
            get { return ma_tpgiadinh; }
            set { ma_tpgiadinh = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Tpgiadinh
        {
            get { return ten_tpgiadinh; }
            set { ten_tpgiadinh = value; }
        }
    }
}
