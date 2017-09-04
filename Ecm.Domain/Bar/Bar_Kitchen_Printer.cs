using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Bar
{
    // =============================================		
    // Author:	Phuongphan	
    // Create date: 	3/26/2011 20:41	
    // Description:	Domain class	
    // =============================================		
    public class Bar_Kitchen_Printer
    {
        #region private field
        private object id_kitchen_printer;
        private object pc_code;
        private object pc_name;
        private object id_cuahang_ban;
        private object printer;
        private object id_nhom_hanghoa_ban;

























        #endregion

        #region properties
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Kitchen_Printer { get { if ("" + id_kitchen_printer != "") return id_kitchen_printer; else return null; } set { id_kitchen_printer = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Pc_Code { get { if ("" + pc_code != "") return pc_code; else return null; } set { pc_code = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Pc_Name { get { if ("" + pc_name != "") return pc_name; else return null; } set { pc_name = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Cuahang_Ban { get { if ("" + id_cuahang_ban != "") return id_cuahang_ban; else return null; } set { id_cuahang_ban = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Printer { get { if ("" + printer != "") return printer; else return null; } set { printer = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhom_Hanghoa_Ban { get { if ("" + id_nhom_hanghoa_ban != "") return id_nhom_hanghoa_ban; else return null; } set { id_nhom_hanghoa_ban = value; } }

























        #endregion
    }		

}
