using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Ware
{
    public class Ware_Vip_Member
    {
        private object id_vip_member;
        private object ma_vip_member;
        private object ten_vip_member;
        private object ghichu;
        private object mark_rate;
        private object duration;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Vip_Member
        {
            get { return id_vip_member; }
            set { id_vip_member = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Vip_Member
        {
            get { return ma_vip_member; }
            set { ma_vip_member = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Vip_Member
        {
            get { return ten_vip_member; }
            set { ten_vip_member = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ghichu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Mark_Rate   
        {
            get { return mark_rate; }
            set { mark_rate = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Duration
        {
            get { return duration; }
            set { duration = value; }
        }
        
          
       
      
    }
}
