using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Ware
{
    public class Ware_Phantich_Thitruong
    {
        private object id_phantich_thitruong;
        private object id_nhansu;
        private object ngay_taophieu;
        private object id_khuvuc;
        private object tuyen_banhang;
        private object ghichu;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Phantich_Thitruong
        {
            get { return id_phantich_thitruong; }
            set { id_phantich_thitruong = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu
        {
            get { return id_nhansu; }
            set { id_nhansu = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Taophieu
        {
            get { return ngay_taophieu; }
            set { ngay_taophieu = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Khuvuc
        {
            get { return id_khuvuc; }
            set { id_khuvuc = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Tuyen_Banhang
        {
            get { return tuyen_banhang; }
            set { tuyen_banhang = value; }
        }
        
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ghichu 
        {
            get { return ghichu; }
            set { ghichu = value; }
        }        
      
    }
}
