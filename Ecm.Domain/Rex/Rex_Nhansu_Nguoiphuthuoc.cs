using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Rex
{
    public class Rex_Nhansu_Nguoiphuthuoc
    {
        private object id_nhansu_nguoiphuthuoc;
        private object id_nhansu;
        private object hoten;
        private object ngaysinh;
        private object masothue;
        private object cmnd;
        private object quanhe;
        private object thoidiem_giamtru;
        private object thoidiem_ketthuc;


        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu_Nguoiphuthuoc
        {
            get
            {
                return id_nhansu_nguoiphuthuoc;
            }
            set
            {
                id_nhansu_nguoiphuthuoc = value;
            }
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
                id_nhansu = value;
            }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Hoten
        {
            get
            {
                return hoten;
            }
            set
            {
                hoten = value;
            }
        }


        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngaysinh
        {
            get
            {
                return ngaysinh;
            }
            set
            {
                ngaysinh = value;
            }
        }


        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Masothue
        {
            get
            {
                return masothue;
            }
            set
            {
                masothue = value;
            }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Cmnd
        {
            get
            {
                return cmnd;
            }
            set
            {
                cmnd = value;
            }
        }


        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Quanhe
        {
            get
            {
                return quanhe;
            }
            set
            {
                quanhe = value;
            }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Thoidiem_Giamtru
        {
            get
            {
                return thoidiem_giamtru;
            }
            set
            {
                thoidiem_giamtru = value;
            }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Thoidiem_Ketthuc
        {
            get
            {
                return thoidiem_ketthuc;
            }
            set
            {
                thoidiem_ketthuc = value;
            }
        }

    }
}
