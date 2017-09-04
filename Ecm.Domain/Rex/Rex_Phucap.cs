using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Rex
{
    public class Rex_Phucap
    {
        private object id_phucap;
        private object id_dm_phucap;      
        private object id_nhansu;       
        private object sotien;
        private object ngay_batdau;
        private object ngay_ketthuc;

      
          
        private object ghichu;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Phucap
        {
            get { return id_phucap; }
            set { id_phucap = value; }
        }
      
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu
        {
            get { return id_nhansu; }
            set { id_nhansu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Dm_Phucap
        {
            get { return id_dm_phucap; }
            set { id_dm_phucap = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Sotien
        {
            get { return sotien; }
            set { sotien = value; }
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

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ghichu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }


    }
}
