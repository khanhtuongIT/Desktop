using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.Pol
{
    public class Pol_Action_Role
    {
        private object id_action;
        private object id_role;
        private object id_right;

        [System.Xml.Serialization.XmlElement()]
        public object Id_Action
        {
            set { id_action = value; }
            get { return id_action; }
        }

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
    }
}
