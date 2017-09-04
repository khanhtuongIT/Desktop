using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Ware
{
    public class DocumentProcessStatus
    {
        private object doc_process_status;
        private object id_nhansu_test;
        private object ghichu_test;
        private object id_nhansu_verify;
        private object ghichu_verify;
        
        private object tablename;
        private object pk_name;
        private object identity;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Doc_Process_Status
        {
            get { return doc_process_status; }
            set { doc_process_status = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu_Test
        {
            get { return id_nhansu_test; }
            set { id_nhansu_test = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ghichu_Test
        {
            get { return ghichu_test; }
            set { ghichu_test = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu_Verify
        {
            get { return id_nhansu_verify; }
            set { id_nhansu_verify = value; }
        }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ghichu_Verify
        {
            get { return ghichu_verify; }
            set { ghichu_verify = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Tablename
        {
            get { return tablename; }
            set { tablename = value; }
        }    

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Identity
        {
            get { return identity; }
            set { identity = value; }
        }      
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object PK_Name
        {
            get { return pk_name; }
            set { pk_name = value; }
        }      
 
    }
}
