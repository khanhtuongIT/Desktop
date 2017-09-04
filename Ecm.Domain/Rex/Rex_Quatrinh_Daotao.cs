using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Rex
{
    public class Rex_Quatrinh_Daotao
    {
        private object id_quatrinh_daotao;
        private object id_nhansu;
        private object nam_nhaphoc;
        private object nam_totnghiep;
        private object noi_daotao;
        private object id_chuyenmon;
        private object loaihinh_daotao;        
        private object id_chungchi;
        private object ghichu;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Quatrinh_Daotao
        {
            get { return id_quatrinh_daotao; }
            set { id_quatrinh_daotao = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu
        {
            get { return id_nhansu; }
            set { id_nhansu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Nam_Nhaphoc
        {
            get { return nam_nhaphoc; }
            set { nam_nhaphoc= value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Nam_Totnghiep
        {
            get { return nam_totnghiep; }
            set { nam_totnghiep = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Noi_Daotao
        {
            get { return noi_daotao; }
            set { noi_daotao = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Loaihinh_Daotao
        {
            get { return loaihinh_daotao; }
            set { loaihinh_daotao = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Chuyenmon
        {
            get { return id_chuyenmon; }
            set { id_chuyenmon = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Chungchi
        {
            get { return id_chungchi; }
            set { id_chungchi = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ghichu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }
    }
}
