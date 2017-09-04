using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.MasterTables.Ware
{
    public class Ware_Dm_Loai_Quytm
    {
        private object id_loai_quytm;
        private object ma_loai_quytm;
        private object ten_loai_quytm;
        private object ghichu;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Loai_Quytm
        {
            get { return id_loai_quytm; }
            set { id_loai_quytm = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Loai_Quytm
        {
            get { return ma_loai_quytm; }
            set { ma_loai_quytm = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Loai_Quytm
        {
            get { return ten_loai_quytm; }
            set { ten_loai_quytm = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ghichu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }
    }
}
