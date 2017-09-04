using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Rex
{
    public class Rex_Tamhoan
    {
        private object id_tamhoan;
        private object id_hopdong_laodong;
        private object id_nhansu;
        private object id_quyetdinh;
        private object ngay_batdau;
        private object ngay_ketthuc;
        private object lydo;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Tamhoan
        {
            get
            {
                return id_tamhoan;
            }
            set
            {
                if (id_tamhoan == value)
                    return;
                id_tamhoan = value;
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
        public object Ngay_Batdau
        {
            get
            {
                return ngay_batdau;
            }
            set
            {
                ngay_batdau = value;
            }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Ketthuc
        {
            get
            {
                return ngay_ketthuc;
            }
            set
            {
                ngay_ketthuc = value;
            }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Lydo
        {
            get { return lydo; }
            set { lydo = value; }
        }
    }
}
