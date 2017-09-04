using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SunLine.Domain.MasterTables.Ware
{
    public class Ware_Dm_Ca_Lamviec
    {
        private object id_ca_lamviec;
        private object ma_ca_lamviec;
        private object ten_ca_lamviec;
        private object gio_batdau;
        private object gio_ketthuc;

        [System.Xml.Serialization.XmlElement]
        public object Id_Ca_Lamviec
        {
            get { return id_ca_lamviec; }
            set { id_ca_lamviec = value; }
        }

        [System.Xml.Serialization.XmlElement]
        public object Ma_Ca_Lamviec
        {
            get { return ma_ca_lamviec; }
            set { ma_ca_lamviec = value; }
        }

        [System.Xml.Serialization.XmlElement]
        public object Ten_Ca_Lamviec
        {
            get { return ten_ca_lamviec; }
            set { ten_ca_lamviec = value; }
        }

        [System.Xml.Serialization.XmlElement]
        public object Gio_Batdau
        {
            get { return gio_batdau; }
            set { gio_batdau = value; }
        }

        [System.Xml.Serialization.XmlElement]
        public object Gio_Ketthuc
        {
            get { return gio_ketthuc; }
            set { gio_ketthuc = value; }
        }
    }
}
