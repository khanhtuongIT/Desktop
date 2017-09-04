using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Ecm.Domain.Rex
{
    // =============================================		
    // Author:	Phuongphan	
    // Create date: 	11/15/2011 7:45	
    // Description:	Domain class	
    // =============================================		
    public class Rex_Tamung_Ky1
    {
        #region private field
        private object id_tamung_ky1;
        private object nam_kyluong;
        private object thang_kyluong;
        private object id_bophan;
        private object id_nhansu;
        private object sotien;
        private object pb_khong_tamung;
        private object ghichu_khong_tamung;
        private object ngaycong;

        #endregion
        #region properties
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Tamung_Ky1 { get { if ("" + id_tamung_ky1 != "") return id_tamung_ky1; else return null; } set { id_tamung_ky1 = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Nam_Kyluong { get { if ("" + nam_kyluong != "") return nam_kyluong; else return null; } set { nam_kyluong = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Thang_Kyluong { get { if ("" + thang_kyluong != "") return thang_kyluong; else return null; } set { thang_kyluong = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Bophan { get { if ("" + id_bophan != "") return id_bophan; else return null; } set { id_bophan = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu { get { if ("" + id_nhansu != "") return id_nhansu; else return null; } set { id_nhansu = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Sotien { get { if ("" + sotien != "") return sotien; else return null; } set { sotien = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Pb_Khong_Tamung { get { if ("" + pb_khong_tamung != "") return pb_khong_tamung; else return null; } set { pb_khong_tamung = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ghichu_Khong_Tamung { get { if ("" + ghichu_khong_tamung != "") return ghichu_khong_tamung; else return null; } set { ghichu_khong_tamung = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngaycong { get { if ("" + ngaycong != "") return ngaycong; else return null; } set { ngaycong = value; } }

        #endregion
    }		

}
