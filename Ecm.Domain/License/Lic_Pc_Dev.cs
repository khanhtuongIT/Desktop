using System;
using System.Data;
using System.Configuration;
using System.Xml.Serialization;
namespace Ecm.Domain.License
{
    /// <summary>
    /// Summary description for Lic_Pc_Dev
    /// </summary>
    public class Lic_Pc_Dev
    {
        // Fields
        private object entryassembly;
        private object ip4;
        private object pc_code;
        private object pc_name;
        private object runtime;
        private object user_name;

        public Lic_Pc_Dev()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        // Properties
        [XmlElement]
        public object EntryAssembly
        {
            get
            {
                if (("" + this.entryassembly) != "")
                {
                    return this.entryassembly;
                }
                return null;
            }
            set
            {
                this.entryassembly = value;
            }
        }

        [XmlElement]
        public object Ip4
        {
            get
            {
                if (("" + this.ip4) != "")
                {
                    return this.ip4;
                }
                return null;
            }
            set
            {
                this.ip4 = value;
            }
        }

        [XmlElement]
        public object Pc_Code
        {
            get
            {
                if (("" + this.pc_code) != "")
                {
                    return this.pc_code;
                }
                return null;
            }
            set
            {
                this.pc_code = value;
            }
        }

        [XmlElement]
        public object Pc_Name
        {
            get
            {
                if (("" + this.pc_name) != "")
                {
                    return this.pc_name;
                }
                return null;
            }
            set
            {
                this.pc_name = value;
            }
        }

        [XmlElement]
        public object Runtime
        {
            get
            {
                if (("" + this.runtime) != "")
                {
                    return this.runtime;
                }
                return null;
            }
            set
            {
                this.runtime = value;
            }
        }

        [XmlElement]
        public object User_Name
        {
            get
            {
                if (("" + this.user_name) != "")
                {
                    return this.user_name;
                }
                return null;
            }
            set
            {
                this.user_name = value;
            }
        }

    }
}