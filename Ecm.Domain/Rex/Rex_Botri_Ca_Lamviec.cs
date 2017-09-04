using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Rex
{
    public class Rex_Botri_Ca_Lamviec
    {
        private object id_botri_ca_lamviec;
        private object id_nhansu;
        private object id_ca_lamviec;
        private object ngay_batdau;
        private object ngay_ketthuc;
      

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Botri_Ca_Lamviec
        {
            get { return id_botri_ca_lamviec; }
            set { id_botri_ca_lamviec = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu
        {
            get { return id_nhansu; }
            set { id_nhansu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Ca_Lamviec
        {
            get { return id_ca_lamviec; }
            set { id_ca_lamviec = value; }
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
