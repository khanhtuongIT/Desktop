using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Tpbanthan
    {
        private object id_tpbanthan;
        private object ma_tpbanthan;
        private object ten_tpbanthan;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Tpbanthan
        {
            get { return id_tpbanthan; }
            set { id_tpbanthan = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Tpbanthan
        {
            get { return ma_tpbanthan; }
            set { ma_tpbanthan = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Tpbanthan
        {
            get { return ten_tpbanthan; }
            set { ten_tpbanthan = value; }
        }
    }
}
