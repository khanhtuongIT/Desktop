using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Coquan
    {
        private object id_coquan;
        private object ma_coquan;
        private object ten_coquan;
        private object diachi;
        private object masothue;        
        private object dienthoai;
        private object website;
        private object email;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Coquan {
            get { return id_coquan; }
            set { this.id_coquan = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Coquan {
            get { return ma_coquan; }
            set { this.ma_coquan = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Coquan {
            get { return ten_coquan; }
            set { this.ten_coquan = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Diachi {
            get { return diachi; }
            set { this.diachi = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Masothue {
            get { return masothue; }
            set { this.masothue = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Dienthoai {
            get { return dienthoai; }
            set { this.dienthoai = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Website {
            get { return website; }
            set { this.website = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Email {
            get { return email; }
            set { this.email = value; }
        }

    }
}
