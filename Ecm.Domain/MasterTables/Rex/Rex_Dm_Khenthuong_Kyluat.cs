using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Khenthuong_Kyluat
    {
        private object id_khenthuong_kyluat;
        private object ma_khenthuong_kyluat;
        private object ten_khenthuong_kyluat;
        private object id_loai_ktkl;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Khenthuong_Kyluat
        {
            get { return id_khenthuong_kyluat; }
            set { id_khenthuong_kyluat = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Khenthuong_Kyluat
        {
            get { return ma_khenthuong_kyluat; }
            set { ma_khenthuong_kyluat = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Khenthuong_Kyluat
        {
            get { return ten_khenthuong_kyluat; }
            set { ten_khenthuong_kyluat = value; }
        }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Loai_Ktkl
        {
            get { return id_loai_ktkl; }
            set { id_loai_ktkl = value; }
        }
    }
}
