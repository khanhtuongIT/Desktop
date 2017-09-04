using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Rex
{
    // =============================================	
    // Author:	Phuongphan
    // Create date: 	10/16/2011 10:16
    // Description:	Domain class
    // =============================================	
    public class Rex_Botri_Nhansu_Stt
    {
        #region private field
        private object id_botri_nhansu_stt;
        private object id_botri_nhansu;
        private object stt;
        private object thang;
        private object nam;
        private Rex_Botri_Nhansu _Rex_Botri_Nhansu;

        #endregion
        #region properties
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Botri_Nhansu_Stt { get { if ("" + id_botri_nhansu_stt != "") return id_botri_nhansu_stt; else return null; } set { id_botri_nhansu_stt = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Botri_Nhansu { get { if ("" + id_botri_nhansu != "") return id_botri_nhansu; else return null; } set { id_botri_nhansu = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Stt { get { if ("" + stt != "") return stt; else return null; } set { stt = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Thang { get { if ("" + thang != "") return thang; else return null; } set { thang = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Nam { get { if ("" + nam != "") return nam; else return null; } set { nam = value; } }

        public Rex_Botri_Nhansu Rex_Botri_Nhansu
        {
            get { return _Rex_Botri_Nhansu; }
            set { _Rex_Botri_Nhansu = value; }
        }

        #endregion
    }
}