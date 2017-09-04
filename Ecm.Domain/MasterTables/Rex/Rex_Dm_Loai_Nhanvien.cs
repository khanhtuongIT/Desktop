using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ecm.Domain.MasterTables.Rex
{
    public class Rex_Dm_Loai_Nhanvien
    {
        private object id_loai_nhanvien;
        private object ma_loai_nhanvien;
        private object ten_loai_nhanvien;

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Loai_Nhanvien
        {
            get { return id_loai_nhanvien; }
            set { id_loai_nhanvien = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Loai_Nhanvien
        {
            get { return ma_loai_nhanvien; }
            set { ma_loai_nhanvien = value; }
        }

        [System.Xml.Serialization.XmlElement][System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Loai_Nhanvien
        {
            get { return ten_loai_nhanvien; }
            set { ten_loai_nhanvien = value; }
        }
    }
}
