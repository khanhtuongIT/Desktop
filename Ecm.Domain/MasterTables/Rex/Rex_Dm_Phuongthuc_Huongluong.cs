using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Phuongthuc_Huongluong
    {
        private object id_phuongthuc_huongluong;
        private object ma_phuongthuc_huongluong;
        private object ten_phuongthuc_huongluong;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Phuongthuc_Huongluong
        {
            get { return id_phuongthuc_huongluong; }
            set { id_phuongthuc_huongluong = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Phuongthuc_Huongluong
        {
            get { return ma_phuongthuc_huongluong; }
            set { ma_phuongthuc_huongluong = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Phuongthuc_Huongluong
        {
            get { return ten_phuongthuc_huongluong; }
            set { ten_phuongthuc_huongluong = value; }
        }
    }
}
