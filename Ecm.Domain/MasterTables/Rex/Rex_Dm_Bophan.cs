using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Bophan
    {
        private object id_bophan;
        private object ma_bophan;
        private object ten_bophan;
        private object id_bophan_ql;
        private object id_loai_bophan;
        private object id_phuongthuc_huongluong;
        private object id_taikhoan_chiphi;

        private object thuhai;
        private object thuba;
        private object thutu;
        private object thunam;
        private object thusau;
        private object thubay;
        private object chunhat;

        [System.Xml.Serialization.XmlElement()]
        public object Id_Taikhoan_Chiphi
        {
            get
            {
                return id_taikhoan_chiphi;
            }
            set
            {
                id_taikhoan_chiphi = value;
            }
        }

        [System.Xml.Serialization.XmlElement()]
        public object Id_Bophan
        {
            get { return id_bophan; }
            set { id_bophan = value; }
        }
        [System.Xml.Serialization.XmlElement()]
        public object Ma_Bophan
        {
            get { return ma_bophan; }
            set { ma_bophan = value; }
        }
        [System.Xml.Serialization.XmlElement()]
        public object Ten_Bophan
        {
            get { return ten_bophan; }
            set { ten_bophan = value; }
        }

        [System.Xml.Serialization.XmlElement()]
        public object Id_Loai_Bophan
        {
            get { return id_loai_bophan; }
            set { id_loai_bophan = value; }
        }
        
        [System.Xml.Serialization.XmlElement()]
        public object Id_Bophan_Ql
        {
            get { return id_bophan_ql; }
            set { id_bophan_ql = value; }
        }

        [System.Xml.Serialization.XmlElement()]
        public object Id_Phuongthuc_Huongluong
        {
            get { return id_phuongthuc_huongluong; }
            set { id_phuongthuc_huongluong = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object ThuHai
        {
            get { return this.thuhai; }
            set { this.thuhai = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object ThuBa
        {
            get { return thuba; }
            set { this.thuba = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object ThuTu
        {
            get { return thutu; }
            set { this.thutu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object ThuNam
        {
            get { return thunam; }
            set { this.thunam = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object ThuSau
        {
            get { return thusau; }
            set { this.thusau = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object ThuBay
        {
            get { return thubay; }
            set { this.thubay = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object ChuNhat
        {
            get { return chunhat; }
            set { this.chunhat = value; }
        }
    }
}
