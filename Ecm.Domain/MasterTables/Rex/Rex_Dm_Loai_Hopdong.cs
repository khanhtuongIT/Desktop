using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Loai_Hopdong
    {
        private object id_loai_hopdong;
        private object ma_loai_hopdong;
        private object ten_loai_hopdong;
        private object thoihan;
        private object bhxh;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Loai_Hopdong
        {
            get { return id_loai_hopdong; }
            set { id_loai_hopdong = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Loai_Hopdong
        {
            get { return ma_loai_hopdong; }
            set { ma_loai_hopdong = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Loai_Hopdong
        {
            get { return ten_loai_hopdong; }
            set { ten_loai_hopdong = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Thoihan
        {
            get { return thoihan; }
            set { thoihan = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Bhxh
        {
            get { return bhxh; }
            set { bhxh = value; }
        }
    }
}
