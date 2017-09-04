using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;


namespace Ecm.Domain.Pol
{
    public class Pol_Dm_Action
    {
        private object id_action;
        private object action_name;
        private object action_description;

        [System.Xml.Serialization.XmlElement()]
        public object Id_Action
        {
            set { id_action = value; }
            get { return id_action; }
        }

        [System.Xml.Serialization.XmlElement()]
        public object Action_Name
        {
            set { action_name = value; }
            get { return action_name; }
        }

        [System.Xml.Serialization.XmlElement()]
        public object Action_Description
        {
            set { action_description = value; }
            get { return action_description; }
        }
    }
}
