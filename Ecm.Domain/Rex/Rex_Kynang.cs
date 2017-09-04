using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Rex
{
    public class Rex_Kynang
    {
        private object id_kynang;
        private object id_nhansu;
        private object id_kynang_chuyenmon;
        private object trinhdo;
        private object sonam_sudung;
        private object ghichu;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Kynang
        {
            get { return id_kynang; }
            set { id_kynang = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu
        {
            get { return id_nhansu; }
            set { id_nhansu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Kynang_Chuyenmon
        {
            get { return id_kynang_chuyenmon; }
            set { id_kynang_chuyenmon = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Trinhdo
        {
            get { return trinhdo; }
            set { trinhdo = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Sonam_Sudung
        {
            get { return sonam_sudung; }
            set { sonam_sudung = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ghichu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }
    }
}
