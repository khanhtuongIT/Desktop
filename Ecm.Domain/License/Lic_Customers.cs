using System;
using System.Data;
using System.Configuration;
namespace Ecm.Domain.License
{
    /// <summary>
    /// Summary description for Lic_Customers
    /// </summary>
    public class Lic_Customers
    {
        private object customer_code;
        private object product_gui;
        private object runtype;
        private object noseats;
        private object expired_date;
        private object email;
        private object create_date;





        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Customer_Code { get { return customer_code; } set { customer_code = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Product_Gui { get { return product_gui; } set { product_gui = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Runtype { get { return runtype; } set { runtype = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Noseats { get { return noseats; } set { noseats = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Expired_Date { get { return expired_date; } set { expired_date = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Email { get { return email; } set { email = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Create_Date { get { return create_date; } set { create_date = value; } }





    }
}