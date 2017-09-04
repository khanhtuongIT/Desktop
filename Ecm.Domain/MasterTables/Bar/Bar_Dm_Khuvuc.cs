using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecm.Domain.MasterTables.Bar
{
    public class Bar_Dm_Khuvuc
    {
        private object id_khuvuc;
        private object ma_khuvuc;
        private object ten_khuvuc;
        private object id_cuahang_ban;
        private object allow_housekeeping;






        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Khuvuc { get { return id_khuvuc; } set { id_khuvuc = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Khuvuc { get { return ma_khuvuc; } set { ma_khuvuc = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Khuvuc { get { return ten_khuvuc; } set { ten_khuvuc = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Cuahang_Ban { get { return id_cuahang_ban; } set { id_cuahang_ban = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Allow_HouseKeeping { get { return allow_housekeeping; } set { allow_housekeeping = value; } }






    }														

}
