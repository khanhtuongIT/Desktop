using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.MasterTables.Accounting
{
    public class Acc_Dm_Thue_Tncn_Luytien
    {
        private object id_thue_tncn_luytien;
        private object bacthue;
        private object thunhap_tinhthue_nam_from;
        private object thunhap_tinhthue_nam_to;
        private object thunhap_tinhthue_thang_from;
        private object thunhap_tinhthue_thang_to;
        private object thuesuat;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Thue_Tncn_Luytien
        {
            get
            {
                return id_thue_tncn_luytien;
            }
            set
            {
                id_thue_tncn_luytien = value;
            }

        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Bacthue
        {
            get
            {
                return bacthue;
            }
            set
            {
                bacthue = value;
            }

        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Thunhap_Tinhthue_Nam_From
        {
            get
            {
                return thunhap_tinhthue_nam_from;
            }
            set
            {
                thunhap_tinhthue_nam_from = value;
            }

        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Thunhap_Tinhthue_Nam_To
        {
            get
            {
                return thunhap_tinhthue_nam_to;
            }
            set
            {
                thunhap_tinhthue_nam_to = value;
            }

        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Thunhap_Tinhthue_Thang_From
        {
            get
            {
                return thunhap_tinhthue_thang_from;
            }
            set
            {
                thunhap_tinhthue_thang_from = value;
            }

        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Thunhap_Tinhthue_Thang_To
        {
            get
            {
                return thunhap_tinhthue_thang_to;
            }
            set
            {
                thunhap_tinhthue_thang_to = value;
            }

        }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Thuesuat
        {
            get
            {
                return thuesuat;
            }
            set
            {
                thuesuat = value;
            }

        }

    }
}
