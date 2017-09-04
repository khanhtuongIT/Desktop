using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Rex
{
    public class Rex_Quatrinh_Congtac
    {
        private object id_quatrinh_congtac;
        private object id_nhansu;
        private object tu_nam;
        private object den_nam;
        private object congviec;
        private object id_chucvu;
        private object id_coquan;
        private object bophan;
        private object diachi;
        private object cvchinh_thanhtichnoibac;
        private object luong_khinghiviec;
        private object lydo_nghiviec;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Quatrinh_Congtac
        {
            get { return id_quatrinh_congtac; }
            set { id_quatrinh_congtac = value; }
        }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu
        {
            get { return id_nhansu; }
            set { id_nhansu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Tu_Nam
        {
            get { return tu_nam; }
            set { tu_nam = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Den_Nam
        {
            get { return den_nam; }
            set { den_nam = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Congviec
        {
            get { return congviec; }
            set { congviec = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Chucvu
        {
            get { return id_chucvu; }
            set { id_chucvu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Coquan
        {
            get { return id_coquan; }
            set { id_coquan = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Bophan
        {
            get { return bophan; }
            set { bophan = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Diachi
        {
            get { return diachi; }
            set { diachi = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Cvchinh_Thanhtichnoibac
        {
            get { return cvchinh_thanhtichnoibac; }
            set { cvchinh_thanhtichnoibac = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Luong_Khinghiviec
        {
            get { return luong_khinghiviec; }
            set { luong_khinghiviec = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Lydo_Nghiviec
        {
            get { return lydo_nghiviec; }
            set { lydo_nghiviec = value; }
        }


    }
}
