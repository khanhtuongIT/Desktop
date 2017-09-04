using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Ware
{
    public class Ware_Ql_Kho_Hanghoa_Mua
    {
        private object id_ql_kho_hanghoa_mua;
        private object id_nhansu;
        private object id_kho_hanghoa_mua;
        private object ghichu;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Ql_Kho_Hanghoa_Mua
        {
            get { return id_ql_kho_hanghoa_mua; }
            set { id_ql_kho_hanghoa_mua = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu
        {
            get { return id_nhansu; }
            set { id_nhansu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Kho_Hanghoa_Mua
        {
            get { return id_kho_hanghoa_mua; }
            set { id_kho_hanghoa_mua = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ghichu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }
    }
}
