using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Heso_Giotangca
    {
        private object id_heso_giotangca;
        private object ma_heso_giotangca;
        private object ten_heso_giotangca;
        private object heso;
        private object ngay_batdau;
        private object ngay_ketthuc;
                   

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Heso_Giotangca
        {
            get { return id_heso_giotangca; }
            set { id_heso_giotangca = value; }
        }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Heso_Giotangca
        {
            get { return ma_heso_giotangca; }
            set { ma_heso_giotangca = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Heso_Giotangca
        {
            get { return ten_heso_giotangca; }
            set { ten_heso_giotangca = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Heso
        {
            get { return heso; }
            set { heso = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Batdau
        {
            get { return ngay_batdau; }
            set { ngay_batdau = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Ketthuc
        {
            get { return ngay_ketthuc; }
            set { ngay_ketthuc = value; }
        }    
    
    }
}
