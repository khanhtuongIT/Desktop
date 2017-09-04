using System;
using System.Data;
using System.Configuration;
namespace Ecm.Domain.License
{

    /// <summary>
    /// Summary description for Lic_Products
    /// </summary>
    public class Lic_Products
    {
        private object product_gui;
        private object product_name;
        private object product_version;
        private object release_date;








        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Product_Gui { get { return product_gui; } set { product_gui = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Product_Name { get { return product_name; } set { product_name = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Product_Version { get { return product_version; } set { product_version = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Release_Date { get { return release_date; } set { release_date = value; } }








    }
}