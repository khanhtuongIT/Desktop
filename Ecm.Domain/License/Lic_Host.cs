using System;
using System.Data;
using System.Configuration;
namespace Ecm.Domain.License
{

    /// <summary>
    /// Summary description for License_Host
    /// </summary>
    public class Lic_Host
    {
        private object id_license_host;
        private object mac;
        private object host;
        private object ip4;
        private object username;
        private object desktop_bmp;
        private object runtime;
        private object codebase;


        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_License_Host
        {
            get { return id_license_host; }
            set { id_license_host = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Mac
        {
            get { return mac; }
            set { mac = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Host
        {
            get { return host; }
            set { host = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ip4
        {
            get { return ip4; }
            set { ip4 = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object UserName
        {
            get { return username; }
            set { username = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Desktop_Bmp
        {
            get { return desktop_bmp; }
            set { desktop_bmp = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Runtime
        {
            get { return runtime; }
            set { runtime = value; }
        }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Codebase
        {
            get { return codebase; }
            set { codebase = value; }
        }

    }
}