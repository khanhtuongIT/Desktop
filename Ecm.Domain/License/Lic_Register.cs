using System;
using System.Data;
using System.Configuration;
namespace Ecm.Domain.License
{
    /// <summary>
    /// Summary description for Lic_Register
    /// </summary>
    public class Lic_Register
    {
        private object reg_code;
        private object pc_code;
        private object product_gui;
        private object customer_code;
        private object pc_name;
        private object user_name;
        private object serial_number;
        private object runtype;
        private object expired_date;
        private object install_date;
        private object reg_date;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Reg_Code { get { return reg_code; } set { reg_code = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Pc_Code { get { return pc_code; } set { pc_code = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Product_Gui { get { return product_gui; } set { product_gui = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Customer_Code { get { return customer_code; } set { customer_code = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Pc_Name { get { return pc_name; } set { pc_name = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object User_Name { get { return user_name; } set { user_name = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Serial_Number { get { return serial_number; } set { serial_number = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Runtype { get { return runtype; } set { runtype = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Expired_Date { get { return expired_date; } set { expired_date = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Install_Date { get { return install_date; } set { install_date = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Reg_Date { get { return reg_date; } set { reg_date = value; } }

    }
}