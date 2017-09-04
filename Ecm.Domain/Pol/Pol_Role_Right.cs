using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;


namespace Ecm.Domain.Pol
{
    public class Pol_Role_Right
    {
        private object id_role;
        private object id_right;
        private object allow_add;
        private object allow_edit;
        private object allow_delete;
        private object allow_query;
        private object allow_print;
        private object allow_full;
        private object allow_none;

        [System.Xml.Serialization.XmlElement()]
        public object Id_Role
        {
            set { id_role = value; }
            get { return id_role; }
        }
        [System.Xml.Serialization.XmlElement()]
        public object Id_Right
        {
            set { id_right = value; }
            get { return id_right; }
        }
        [System.Xml.Serialization.XmlElement()]
        public object Allow_Add
        {
            set { allow_add = value; }
            get { return allow_add; }
        }
        [System.Xml.Serialization.XmlElement()]
        public object Allow_Edit
        {
            set { allow_edit = value; }
            get { return allow_edit; }
        }
        [System.Xml.Serialization.XmlElement()]
        public object Allow_Delete
        {
            set { allow_delete = value; }
            get { return allow_delete; }
        }
        [System.Xml.Serialization.XmlElement()]
        public object Allow_Query
        {
            set { allow_query = value; }
            get { return allow_query; }
        }
        [System.Xml.Serialization.XmlElement()]
        public object Allow_Print
        {
            set { allow_print = value; }
            get { return allow_print; }
        }
        [System.Xml.Serialization.XmlElement()]
        public object Allow_Full
        {
            set { allow_full = value; }
            get { return allow_full; }
        }
        [System.Xml.Serialization.XmlElement()]
        public object Allow_None
        {
            set { allow_none = value; }
            get { return allow_none; }
        }
    }
}