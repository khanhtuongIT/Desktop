using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Rex
{
    public class Rex_Nghiviec
    {
        private object id_nghiviec;
        private object id_hopdong_laodong;
        private object id_nhansu;
        private object id_quyetdinh;
        private object ngay_hopdong;
        private object ngay_nghiviec;
        private object lydo;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nghiviec
        {
            get
            {
                return id_nghiviec;
            }
            set
            {
                if (id_nghiviec == value)
                    return;
                id_nghiviec = value;
            }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Hopdong_Laodong
        {
            get { return id_hopdong_laodong; }
            set { id_hopdong_laodong = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu
        {
            get
            {
                return id_nhansu;
            }
            set
            {
                if (id_nhansu == value)
                    return;
                id_nhansu = value;
            }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Quyetdinh
        {
            get
            {
                return id_quyetdinh;
            }
            set
            {
                if (id_quyetdinh == value)
                    return;
                id_quyetdinh = value;
            }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Hopdong
        {
            get
            {
                return ngay_hopdong;
            }
            set
            {
                if (ngay_hopdong == value)
                    return;
                ngay_hopdong = value;
            }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Nghiviec
        {
            get
            {
                return ngay_nghiviec;
            }
            set
            {
                if (ngay_nghiviec == value)
                    return;
                ngay_nghiviec = value;
            }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Lydo
        {
            get
            {
                return lydo;
            }
            set
            {
                if (lydo == value)
                    return;
                lydo = value;
            }
        }
    }
}
