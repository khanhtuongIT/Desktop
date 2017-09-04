using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Ware
{
    public class Ware_Dm_Soquy
    {
        private object id_soquy;
        private object ma_soquy;
        private object ten_soquy;
        private object id_cuahang_ban;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Soquy
        {
            get { return id_soquy; }
            set { id_soquy = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Soquy
        {
            get { return ma_soquy; }
            set { ma_soquy = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Soquy
        {
            get { return ten_soquy; }
            set { ten_soquy = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Cuahang_Ban
        {
            get { return id_cuahang_ban; }
            set { id_cuahang_ban = value; }
        }
    }
}
