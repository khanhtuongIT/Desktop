using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;


namespace Ecm.Domain.Pol
{
    public class Pol_Dm_Role
    {
        private object id_role;
        private object id_role_parent;
        private object role_system_name;
        private object role_display_name;
        private object role_description;
        private object build_in;

        [System.Xml.Serialization.XmlElement()]
        public object Id_Role
        {
            set { id_role = value; }
            get { return id_role; }
        }
        [System.Xml.Serialization.XmlElement()]
        public object Id_Role_Parent
        {
            set { id_role_parent = value; }
            get { return id_role_parent; }
        }
        [System.Xml.Serialization.XmlElement()]
        public object Role_System_Name
        {
            set { role_system_name = value; }
            get { return role_system_name; }
        }
        [System.Xml.Serialization.XmlElement()]
        public object Role_Display_Name
        {
            set { role_display_name = value; }
            get { return role_display_name; }
        }
        [System.Xml.Serialization.XmlElement()]
        public object Role_Description
        {
            set { role_description = value; }
            get { return role_description; }
        }
        [System.Xml.Serialization.XmlElement()]
        public object Build_In
        {
            set { build_in = value; }
            get { return build_in; }
        }
    }
}
