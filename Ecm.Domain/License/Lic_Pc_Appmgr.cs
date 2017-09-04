using System;
using System.Data;
using System.Configuration;
namespace Ecm.Domain.License
{

    // =============================================		
    // Author:	Phuongphan	
    // Create date: 	1/11/2011 11:54	
    // Description:	Domain class	
    // =============================================		
    public class Lic_Pc_Appmgr
    {
        private object pc_code;
        private object pc_name;
        private object user_name;
        private object activated;










        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Pc_Code { get { if ("" + pc_code != "") return pc_code; else return null; } set { pc_code = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Pc_Name { get { if ("" + pc_name != "") return pc_name; else return null; } set { pc_name = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object User_Name { get { if ("" + user_name != "") return user_name; else return null; } set { user_name = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Activated { get { if ("" + activated != "") return activated; else return null; } set { activated = value; } }









    }

}