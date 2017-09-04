using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;


namespace Ecm.Domain.Pol
{
    public class Pol_Dm_Right
    {
        private object id_right;
        private object id_right_parent;
        private object right_system_name;
        private object right_display_name;
        private object right_description;
        private object build_in;

        [System.Xml.Serialization.XmlElement()]
        public object Id_Right
        {
            set { id_right = value; }
            get { return id_right; }
        }
        [System.Xml.Serialization.XmlElement()]
        public object Id_Right_Parent
        {
            set { id_right_parent = value; }
            get { return id_right_parent; }
        }
        [System.Xml.Serialization.XmlElement()]
        public object Right_System_Name
        {
            set { right_system_name = value; }
            get { return right_system_name; }
        }
        [System.Xml.Serialization.XmlElement()]
        public object Right_Display_Name
        {
            set { right_display_name = value; }
            get { return right_display_name; }
        }
        [System.Xml.Serialization.XmlElement()]
        public object Right_Description
        {
            set { right_description = value; }
            get { return right_description; }
        }
        [System.Xml.Serialization.XmlElement()]
        public object Build_In
        {
            set { build_in = value; }
            get { return build_in; }
        }
    }
}
