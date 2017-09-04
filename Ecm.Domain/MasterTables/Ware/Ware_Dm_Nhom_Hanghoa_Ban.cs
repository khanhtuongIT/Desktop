using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Ware
{
    public class Ware_Dm_Nhom_Hanghoa_Ban
    {
        private object id_nhom_hanghoa_ban;
        private object ma_nhom_hanghoa_ban;
        private object ten_nhom_hanghoa_ban;
        private object bc_doanhso;
        private object bc_nxt;
        private object bc_nguyenlieu_chebien;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhom_Hanghoa_Ban
        {
            get { return id_nhom_hanghoa_ban; }
            set { id_nhom_hanghoa_ban = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Nhom_Hanghoa_Ban
        {
            get { return ma_nhom_hanghoa_ban; }
            set { ma_nhom_hanghoa_ban = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Nhom_Hanghoa_Ban
        {
            get { return ten_nhom_hanghoa_ban; }
            set { ten_nhom_hanghoa_ban = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Bc_Doanhso {
            get {
                return this.bc_doanhso;
            }
            set {
                this.bc_doanhso = value;
            }
        }


        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Bc_Nxt {
            get {
                return this.bc_nxt;
            }
            set {
                this.bc_nxt = value;
            }
        }


        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Bc_Nguyenlieu_Chebien {
            get {
                return this.bc_nguyenlieu_chebien;
            }
            set {
                this.bc_nguyenlieu_chebien = value;
            }
        }



    }
}
