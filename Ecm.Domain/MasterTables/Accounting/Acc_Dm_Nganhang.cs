using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.MasterTables.Accounting
{
    public class Acc_Dm_Nganhang
    {
        private object id_nganhang;
        private object ma_nganhang;
        private object ten_nganhang;
        private object diachi;
        private object dienthoai;
        private object fax;
        private object telex;
        private object swiftcode;
        private object ten_Nganhang_gdqt;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nganhang
        {
            get { return id_nganhang; }
            set { id_nganhang = value; }
        }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Nganhang
        {
            get { return ma_nganhang; }
            set { ma_nganhang = value; }
        }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Nganhang
        {
            get { return ten_nganhang; }
            set { ten_nganhang = value; }
        }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Diachi
        {
            get { return diachi; }
            set { diachi = value; }
        }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Dienthoai
        {
            get { return dienthoai; }
            set { dienthoai = value; }
        }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Fax
        {
            get { return fax; }
            set { fax = value; }
        }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Telex
        {
            get { return telex; }
            set { telex = value; }
        }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Swiftcode
        {
            get { return swiftcode; }
            set { swiftcode = value; }
        }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Nganhang_Gdqt
        {
            get { return ten_Nganhang_gdqt; }
            set { ten_Nganhang_gdqt = value; }
        }
    }
}
