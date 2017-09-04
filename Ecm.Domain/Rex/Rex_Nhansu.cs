using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Rex
{
    // =============================================								
    // Author:	Phuongphan							
    // Create date: 	1/8/2011 10:54							
    // Description:	Domain class							
    // =============================================								

    public class Rex_Nhansu
    {
        private object id_nhansu;
        private object ma_nhansu;
        private object ho_nhansu;
        private object ten_nhansu;
        private object dienthoai;
        private object id_dantoc;
        private object id_quocgia;
        private object id_tongiao;
        private object id_tpgiadinh;
        private object id_tpbanthan;
        private object id_honnhan;
        private object ngaysinh;
        private object gioitinh;
        private object cmnd;
        private object ngaycap;
        private object noicap;
        private object noisinh;
        private object quequan;
        private object diachi_thuongtru;
        private object diachi_tamtru;
        private object hinh;
        private object ngay_vaolam;
        private object ngay_thoiviec;
        private object uid;
        private object date_create;
        private object date_modify;
        private object guid;
        private object bibat_bitu;
        private object cannang;
        private object chieucao;
        private object con_chinh_sach;
        private object congviec_chinh;
        private object coquan_tuyendung;
        private object danhhieu_caonhat;
        private object dienthoai_nharieng;
        private object email;
        private object fax;
        private object finger_userid;
        private object hochieu;
        private object hokhau_thuongtru;
        private object id_bophan;
        private object id_chucvu;
        private object id_chuyenmon;
        private object id_hopdong_laodong;
        private object id_loai_hopdong;
        private object id_loai_nhanvien;
        private object id_ngoaingu;
        private object id_tinhoc;
        private object id_vanhoa;
        private object khuyet_tat;
        private object lyluan_chinhtri;
        private object ma_nhansu1;
        private object namsinh;
        private object ngay_nhapngu;
        private object ngay_sinh;
        private object ngay_tuyendung;
        private object ngay_vaodang;
        private object ngay_vaodoan;
        private object ngay_xuatngu;
        private object ngaycap_bhtn;
        private object ngaycap_bhxh;
        private object ngaycap_bhyt;
        private object ngaycap_hochieu;
        private object ngayvaodang_chinhthuc;
        private object nghenghiep_tuyendung;
        private object nghi_bhxh;
        private object nhommau;
        private object noi_vaodang;
        private object noi_vaodoan;
        private object noicap_bhtn;
        private object noicap_bhxh;
        private object noicap_bhyt;
        private object noicap_hochieu;
        private object quan_ham;
        private object quanly_nhanuoc;
        private object so_sobhtn;
        private object so_sobhxh;
        private object so_sobhyt;
        private object sotruong_ct;
        private object tenkhac;
        private object thamgia_chinhtri;
        private object thamgia_quandoi;
        private object thangsinh;
        private object thannhan_nuocngoai;
        private object thuongbinh_hang;
        private object tt_suckhoe;
        private object tuoihuu;
        private object masothue;
        private object hoten_nhansu;
        private object ma_nhansu_sx;
        private object id_nganhang;
        private object taikhoan_nganhang;
        private object ngay_vaocongdoan;
        private object truongnhom;
        private object taixe;
        private object sale;

        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nhansu { get { if ("" + id_nhansu != "") return id_nhansu; else return null; } set { id_nhansu = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Nhansu { get { if ("" + ma_nhansu != "") return ma_nhansu; else return null; } set { ma_nhansu = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Ho_Nhansu { get { if ("" + ho_nhansu != "") return ho_nhansu; else return null; } set { ho_nhansu = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Ten_Nhansu { get { if ("" + ten_nhansu != "") return ten_nhansu; else return null; } set { ten_nhansu = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Dienthoai { get { if ("" + dienthoai != "") return dienthoai; else return null; } set { dienthoai = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Dantoc { get { if ("" + id_dantoc != "") return id_dantoc; else return null; } set { id_dantoc = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Quocgia { get { if ("" + id_quocgia != "") return id_quocgia; else return null; } set { id_quocgia = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Tongiao { get { if ("" + id_tongiao != "") return id_tongiao; else return null; } set { id_tongiao = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Tpgiadinh { get { if ("" + id_tpgiadinh != "") return id_tpgiadinh; else return null; } set { id_tpgiadinh = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Tpbanthan { get { if ("" + id_tpbanthan != "") return id_tpbanthan; else return null; } set { id_tpbanthan = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Honnhan { get { if ("" + id_honnhan != "") return id_honnhan; else return null; } set { id_honnhan = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Ngaysinh { get { if ("" + ngaysinh != "") return ngaysinh; else return null; } set { ngaysinh = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Gioitinh { get { if ("" + gioitinh != "") return gioitinh; else return null; } set { gioitinh = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Cmnd { get { if ("" + cmnd != "") return cmnd; else return null; } set { cmnd = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Ngaycap { get { if ("" + ngaycap != "") return ngaycap; else return null; } set { ngaycap = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Noicap { get { if ("" + noicap != "") return noicap; else return null; } set { noicap = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Noisinh { get { if ("" + noisinh != "") return noisinh; else return null; } set { noisinh = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Quequan { get { if ("" + quequan != "") return quequan; else return null; } set { quequan = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Diachi_Thuongtru { get { if ("" + diachi_thuongtru != "") return diachi_thuongtru; else return null; } set { diachi_thuongtru = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Diachi_Tamtru { get { if ("" + diachi_tamtru != "") return diachi_tamtru; else return null; } set { diachi_tamtru = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Hinh { get { if ("" + hinh != "") return hinh; else return null; } set { hinh = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Vaolam { get { if ("" + ngay_vaolam != "") return ngay_vaolam; else return null; } set { ngay_vaolam = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Thoiviec { get { if ("" + ngay_thoiviec != "") return ngay_thoiviec; else return null; } set { ngay_thoiviec = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Uid { get { if ("" + uid != "") return uid; else return null; } set { uid = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Date_Create { get { if ("" + date_create != "") return date_create; else return null; } set { date_create = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Date_Modify { get { if ("" + date_modify != "") return date_modify; else return null; } set { date_modify = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Guid { get { if ("" + guid != "") return guid; else return null; } set { guid = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Bibat_Bitu { get { if ("" + bibat_bitu != "") return bibat_bitu; else return null; } set { bibat_bitu = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Cannang { get { if ("" + cannang != "") return cannang; else return null; } set { cannang = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Chieucao { get { if ("" + chieucao != "") return chieucao; else return null; } set { chieucao = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Con_Chinh_Sach { get { if ("" + con_chinh_sach != "") return con_chinh_sach; else return null; } set { con_chinh_sach = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Congviec_Chinh { get { if ("" + congviec_chinh != "") return congviec_chinh; else return null; } set { congviec_chinh = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Coquan_Tuyendung { get { if ("" + coquan_tuyendung != "") return coquan_tuyendung; else return null; } set { coquan_tuyendung = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Danhhieu_Caonhat { get { if ("" + danhhieu_caonhat != "") return danhhieu_caonhat; else return null; } set { danhhieu_caonhat = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Dienthoai_Nharieng { get { if ("" + dienthoai_nharieng != "") return dienthoai_nharieng; else return null; } set { dienthoai_nharieng = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Email { get { if ("" + email != "") return email; else return null; } set { email = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Fax { get { if ("" + fax != "") return fax; else return null; } set { fax = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Finger_Userid { get { if ("" + finger_userid != "") return finger_userid; else return null; } set { finger_userid = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Hochieu { get { if ("" + hochieu != "") return hochieu; else return null; } set { hochieu = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Hokhau_Thuongtru { get { if ("" + hokhau_thuongtru != "") return hokhau_thuongtru; else return null; } set { hokhau_thuongtru = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Bophan { get { if ("" + id_bophan != "") return id_bophan; else return null; } set { id_bophan = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Chucvu { get { if ("" + id_chucvu != "") return id_chucvu; else return null; } set { id_chucvu = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Chuyenmon { get { if ("" + id_chuyenmon != "") return id_chuyenmon; else return null; } set { id_chuyenmon = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Hopdong_Laodong { get { if ("" + id_hopdong_laodong != "") return id_hopdong_laodong; else return null; } set { id_hopdong_laodong = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Loai_Hopdong { get { if ("" + id_loai_hopdong != "") return id_loai_hopdong; else return null; } set { id_loai_hopdong = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Loai_Nhanvien { get { if ("" + id_loai_nhanvien != "") return id_loai_nhanvien; else return null; } set { id_loai_nhanvien = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Ngoaingu { get { if ("" + id_ngoaingu != "") return id_ngoaingu; else return null; } set { id_ngoaingu = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Tinhoc { get { if ("" + id_tinhoc != "") return id_tinhoc; else return null; } set { id_tinhoc = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Vanhoa { get { if ("" + id_vanhoa != "") return id_vanhoa; else return null; } set { id_vanhoa = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Khuyet_Tat { get { if ("" + khuyet_tat != "") return khuyet_tat; else return null; } set { khuyet_tat = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Lyluan_Chinhtri { get { if ("" + lyluan_chinhtri != "") return lyluan_chinhtri; else return null; } set { lyluan_chinhtri = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Nhansu1 { get { if ("" + ma_nhansu1 != "") return ma_nhansu1; else return null; } set { ma_nhansu1 = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Namsinh { get { if ("" + namsinh != "") return namsinh; else return null; } set { namsinh = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Nhapngu { get { if ("" + ngay_nhapngu != "") return ngay_nhapngu; else return null; } set { ngay_nhapngu = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Sinh { get { if ("" + ngay_sinh != "") return ngay_sinh; else return null; } set { ngay_sinh = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Tuyendung { get { if ("" + ngay_tuyendung != "") return ngay_tuyendung; else return null; } set { ngay_tuyendung = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Vaodang { get { if ("" + ngay_vaodang != "") return ngay_vaodang; else return null; } set { ngay_vaodang = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Vaodoan { get { if ("" + ngay_vaodoan != "") return ngay_vaodoan; else return null; } set { ngay_vaodoan = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Xuatngu { get { if ("" + ngay_xuatngu != "") return ngay_xuatngu; else return null; } set { ngay_xuatngu = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Ngaycap_Bhtn { get { if ("" + ngaycap_bhtn != "") return ngaycap_bhtn; else return null; } set { ngaycap_bhtn = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Ngaycap_Bhxh { get { if ("" + ngaycap_bhxh != "") return ngaycap_bhxh; else return null; } set { ngaycap_bhxh = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Ngaycap_Bhyt { get { if ("" + ngaycap_bhyt != "") return ngaycap_bhyt; else return null; } set { ngaycap_bhyt = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Ngaycap_Hochieu { get { if ("" + ngaycap_hochieu != "") return ngaycap_hochieu; else return null; } set { ngaycap_hochieu = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Ngayvaodang_Chinhthuc { get { if ("" + ngayvaodang_chinhthuc != "") return ngayvaodang_chinhthuc; else return null; } set { ngayvaodang_chinhthuc = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Nghenghiep_Tuyendung { get { if ("" + nghenghiep_tuyendung != "") return nghenghiep_tuyendung; else return null; } set { nghenghiep_tuyendung = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Nghi_Bhxh { get { if ("" + nghi_bhxh != "") return nghi_bhxh; else return null; } set { nghi_bhxh = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Nhommau { get { if ("" + nhommau != "") return nhommau; else return null; } set { nhommau = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Noi_Vaodang { get { if ("" + noi_vaodang != "") return noi_vaodang; else return null; } set { noi_vaodang = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Noi_Vaodoan { get { if ("" + noi_vaodoan != "") return noi_vaodoan; else return null; } set { noi_vaodoan = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Noicap_Bhtn { get { if ("" + noicap_bhtn != "") return noicap_bhtn; else return null; } set { noicap_bhtn = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Noicap_Bhxh { get { if ("" + noicap_bhxh != "") return noicap_bhxh; else return null; } set { noicap_bhxh = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Noicap_Bhyt { get { if ("" + noicap_bhyt != "") return noicap_bhyt; else return null; } set { noicap_bhyt = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Noicap_Hochieu { get { if ("" + noicap_hochieu != "") return noicap_hochieu; else return null; } set { noicap_hochieu = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Quan_Ham { get { if ("" + quan_ham != "") return quan_ham; else return null; } set { quan_ham = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Quanly_Nhanuoc { get { if ("" + quanly_nhanuoc != "") return quanly_nhanuoc; else return null; } set { quanly_nhanuoc = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object So_Sobhtn { get { if ("" + so_sobhtn != "") return so_sobhtn; else return null; } set { so_sobhtn = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object So_Sobhxh { get { if ("" + so_sobhxh != "") return so_sobhxh; else return null; } set { so_sobhxh = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object So_Sobhyt { get { if ("" + so_sobhyt != "") return so_sobhyt; else return null; } set { so_sobhyt = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Sotruong_Ct { get { if ("" + sotruong_ct != "") return sotruong_ct; else return null; } set { sotruong_ct = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Tenkhac { get { if ("" + tenkhac != "") return tenkhac; else return null; } set { tenkhac = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Thamgia_Chinhtri { get { if ("" + thamgia_chinhtri != "") return thamgia_chinhtri; else return null; } set { thamgia_chinhtri = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Thamgia_Quandoi { get { if ("" + thamgia_quandoi != "") return thamgia_quandoi; else return null; } set { thamgia_quandoi = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Thangsinh { get { if ("" + thangsinh != "") return thangsinh; else return null; } set { thangsinh = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Thannhan_Nuocngoai { get { if ("" + thannhan_nuocngoai != "") return thannhan_nuocngoai; else return null; } set { thannhan_nuocngoai = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Thuongbinh_Hang { get { if ("" + thuongbinh_hang != "") return thuongbinh_hang; else return null; } set { thuongbinh_hang = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Tt_Suckhoe { get { if ("" + tt_suckhoe != "") return tt_suckhoe; else return null; } set { tt_suckhoe = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Tuoihuu { get { if ("" + tuoihuu != "") return tuoihuu; else return null; } set { tuoihuu = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Masothue { get { if ("" + masothue != "") return masothue; else return null; } set { masothue = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Hoten_Nhansu { get { if ("" + hoten_nhansu != "") return hoten_nhansu; else return null; } set { hoten_nhansu = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Ma_Nhansu_Sx { get { if ("" + ma_nhansu_sx != "") return ma_nhansu_sx; else return null; } set { ma_nhansu_sx = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Id_Nganhang { get { if ("" + id_nganhang != "") return id_nganhang; else return null; } set { id_nganhang = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Taikhoan_Nganhang { get { if ("" + taikhoan_nganhang != "") return taikhoan_nganhang; else return null; } set { taikhoan_nganhang = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Ngay_Vaocongdoan { get { if ("" + ngay_vaocongdoan != "") return ngay_vaocongdoan; else return null; } set { ngay_vaocongdoan = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Truongnhom { get { if ("" + truongnhom != "") return truongnhom; else return null; } set { truongnhom = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Taixe { get { if ("" + taixe != "") return taixe; else return null; } set { taixe = value; } }
        [System.Xml.Serialization.XmlElement]
        [System.Runtime.Serialization.DataMemberAttribute]
        public object Sale { get { if ("" + sale != "") return taixe; else return null; } set { sale = value; } }
    }
}
