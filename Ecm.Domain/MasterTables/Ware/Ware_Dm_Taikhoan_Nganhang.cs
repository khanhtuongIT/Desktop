using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.MasterTables.Ware
{
    public class Ware_Dm_Taikhoan_Nganhang
    {
        private object id_taikhoan_nganhang;
        private object ma_taikhoan_nganhang;
        private object ten_taikhoan_nganhang;
        private object so_taikhoan_nganhang;
        private object id_nganhang;
        private object id_tiente;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Taikhoan_Nganhang
        {
            get { return id_taikhoan_nganhang; }
            set { id_taikhoan_nganhang = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Taikhoan_Nganhang
        {
            get { return ma_taikhoan_nganhang; }
            set { ma_taikhoan_nganhang = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Taikhoan_Nganhang
        {
            get { return ten_taikhoan_nganhang; }
            set { ten_taikhoan_nganhang = value; }
        }

        public object So_Taikhoan_Nganhang
        {
            get { return so_taikhoan_nganhang; }
            set { so_taikhoan_nganhang = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nganhang
        {
            get { return id_nganhang; }
            set { id_nganhang = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Tiente
        {
            get { return id_tiente; }
            set { id_tiente = value; }
        }
    }
}
