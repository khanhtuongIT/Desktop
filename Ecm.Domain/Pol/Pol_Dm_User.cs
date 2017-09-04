using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;


namespace Ecm.Domain.Pol
{
    public class Pol_Dm_User
    {
        private object id_user;
        private object id_user_parent;
        private object user_name;
        private object user_password;
        private object user_fullname;
        private object user_description;
        private object build_in;
        private object id_nhansu;
        private object user_disable;
        private object authcode;
        //private bool must_change; 
        //private bool cannot_change;
        //private bool expire_password;
        //private int expire_day;
        //private bool complex_password;
        //private bool disable;

        [System.Xml.Serialization.XmlElement()]
        public object Id_User
        {
            set { id_user = value; }
            get { if ("" + id_user != "") return id_user; else return null; }
        }
        [System.Xml.Serialization.XmlElement()]
        public object Id_User_Parent
        {
            set { id_user_parent = value; }
            get { if ("" + id_user_parent != "") return id_user_parent; else return null; }
        }
        [System.Xml.Serialization.XmlElement()]
        public object User_Name
        {
            set { user_name = value; }
            get { if ("" + user_name != "") return user_name; else return null; }
        }
        [System.Xml.Serialization.XmlElement()]
        public object User_Password
        {
            set { user_password = value; }
            get { if ("" + user_password != "") return user_password; else return null; }
        }
        [System.Xml.Serialization.XmlElement()]
        public object User_Fullname
        {
            set { user_fullname = value; }
            get { if ("" + user_fullname != "") return user_fullname; else return null; }
        }
        [System.Xml.Serialization.XmlElement()]
        public object User_Description
        {
            set { user_description = value; }
            get { if ("" + user_description != "") return user_description; else return null; }
        }
        [System.Xml.Serialization.XmlElement()]
        public object Build_In
        {
            set { build_in = value; }
            get { if ("" + build_in != "") return build_in; else return null; }
        }
        [System.Xml.Serialization.XmlElement()]
        public object Id_Nhansu
        {
            set { id_nhansu = value; }
            get { if ("" + id_nhansu != "") return id_nhansu; else return null; }
        }        

        [System.Xml.Serialization.XmlElement()]
        public object User_Disable
        {
            set { user_disable = value; }
            get { if ("" + user_disable != "") return user_disable; else return null; }
        }

        [System.Xml.Serialization.XmlElement()]
        public object AuthCode
        {
            set { authcode = value; }
            get { if ("" + authcode != "") return authcode; else return null; }
        }     
        
        //public bool Must_Change 
        //{ 
        //    set { must_change = value; } 
        //    get { return must_change; } 
        //}
        //public bool Cannot_Change 
        //{ 
        //    set { cannot_change = value; } 
        //    get { return cannot_change; } 
        //}
        //public bool Expire_Password 
        //{ 
        //    set { expire_password = value; } 
        //    get { return expire_password; } 
        //}
        //public int Expire_Day 
        //{ 
        //    set { expire_day = value; }
        //    get { return expire_day; } 
        //}
        //public bool Complex_Password 
        //{ 
        //    set { complex_password = value; } 
        //    get { return complex_password; } 
        //}
        //public bool Disable
        //{ 
        //    set { disable = value; }
        //    get { return disable; } 
        //}
    }
}
