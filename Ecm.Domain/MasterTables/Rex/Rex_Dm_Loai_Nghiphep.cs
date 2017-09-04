using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Loai_Nghiphep
    {
        private object id_loai_nghiphep;
        private object ma_loai_nghiphep;
        private object ten_loai_nghiphep;
        private object huongluong;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Loai_Nghiphep
        {
            get { return id_loai_nghiphep; }
            set { id_loai_nghiphep = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Loai_Nghiphep
        {
            get { return ma_loai_nghiphep; }
            set { ma_loai_nghiphep = value; }
        }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Loai_Nghiphep
        {
            get { return ten_loai_nghiphep; }
            set { ten_loai_nghiphep = value; }
        }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Huongluong
        {
            get { return huongluong; }
            set { huongluong = value; }
        }
    }
}
