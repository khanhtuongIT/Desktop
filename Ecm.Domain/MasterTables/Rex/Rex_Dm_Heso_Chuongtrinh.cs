using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Heso_Chuongtrinh
    {
        private object id_heso_chuongtrinh;
        private object ma_heso_chuongtrinh;
        private object ten_heso_chuongtrinh;
        private object heso;
        private object nhom_heso_chuongtrinh;
        private object ghichu;
        private object regx;

        [System.Xml.Serialization.XmlElement()]
        public object Id_Heso_Chuongtrinh
        {
            get { return id_heso_chuongtrinh; }
            set { id_heso_chuongtrinh = value; }
        }
        [System.Xml.Serialization.XmlElement()]
        public object Ma_Heso_Chuongtrinh
        {
            get { return ma_heso_chuongtrinh; }
            set { ma_heso_chuongtrinh = value; }
        }
        [System.Xml.Serialization.XmlElement()]
        public object Ten_Heso_Chuongtrinh
        {
            get { return ten_heso_chuongtrinh; }
            set { ten_heso_chuongtrinh = value; }
        }

        [System.Xml.Serialization.XmlElement()]
        public object Heso
        {
            get { return heso; }
            set { heso = value; }
        }
        [System.Xml.Serialization.XmlElement()]
        public object Nhom_Heso_Chuongtrinh
        {
            get { return nhom_heso_chuongtrinh; }
            set { nhom_heso_chuongtrinh = value; }
        }
        [System.Xml.Serialization.XmlElement()]
        public object Ghichu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }
        [System.Xml.Serialization.XmlElement()]
        public object Regx
        {
            get { return regx; }
            set { regx = value; }
        }

        
    }
}
