using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecm.Domain.Bar
{
    public class Bar_Winecard
    {
        private object id_winecard;
        private object id_khachhang;
        private object ngay_batdau;
        private object ngay_ketthuc;
        private object id_nhansu_lap;
        private object id_nhansu_xnhan;
        private object so_chungtu;
        private object id_hanghoa_ban;
        private object ghichu;
        private object id_cuahang_ban;
        private object id_nhansu_return;
        private object ngay_return;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Winecard { get { return id_winecard; } set { id_winecard = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Khachhang { get { return id_khachhang; } set { id_khachhang = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Batdau { get { return ngay_batdau; } set { ngay_batdau = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Ketthuc { get { return ngay_ketthuc; } set { ngay_ketthuc = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu_Lap { get { return id_nhansu_lap; } set { id_nhansu_lap = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu_Xnhan { get { return id_nhansu_xnhan; } set { id_nhansu_xnhan = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object So_Chungtu { get { return so_chungtu; } set { so_chungtu = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Hanghoa_Ban { get { return id_hanghoa_ban; } set { id_hanghoa_ban = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ghichu { get { return ghichu; } set { ghichu = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Cuahang_Ban { get { return id_cuahang_ban; } set { id_cuahang_ban = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu_Return { get { return id_nhansu_return; } set { id_nhansu_return = value; } }
        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Return { get { return ngay_return; } set { ngay_return = value; } }

    }														

}
