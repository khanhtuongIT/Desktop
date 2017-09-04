using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Rex
{
    public class Rex_Khenthuong_Kyluat
    {
        private object id_khenthuong_kyluat;
        private object id_nhansu;
        private object id_loai_ktkl;
        private object nam_ktkl;
        private object id_coquan;
        private object ghichu;
        private object hinhthuc_ktkl;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Khenthuong_Kyluat
        {
            get { return id_khenthuong_kyluat; }
            set { id_khenthuong_kyluat = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu
        {
            get { return id_nhansu; }
            set { id_nhansu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Loai_Ktkl
        {
            get { return id_loai_ktkl; }
            set { id_loai_ktkl = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Nam_Ktkl
        {
            get { return nam_ktkl; }
            set { nam_ktkl = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Coquan
        {
            get { return id_coquan; }
            set { id_coquan = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ghichu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Hinhthuc_Ktkl
        {
            get { return hinhthuc_ktkl; }
            set { hinhthuc_ktkl = value; }
        }

    }
}
