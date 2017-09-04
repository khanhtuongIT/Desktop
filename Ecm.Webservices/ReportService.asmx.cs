
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Ecm.Service.Reports;

namespace Ecm.Webservice
{
    /// <summary>
    /// Summary description for ReportServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.Web.Script.Services.ScriptService]
    public class ReportService : System.Web.Services.WebService
    {
        //Connection
        System.Data.OleDb.OleDbConnection sqlConnection = DbConnection.OleDbConnection;

        #region Khai bao cac doi tuong Service
        WareReport_Service _WareReport_Service;
        #endregion

        public ReportService()
        {
            #region Khoi tao cac doi tuong
            _WareReport_Service = new WareReport_Service(sqlConnection);
            #endregion
        }

        #region hoa don ban hang

        [WebMethod(Description = "RptWare_Hdbanhang")]
        public string RptWare_Hdbanhang(object Ngay_Batdau, object Ngay_Ketthuc)
        {
            return _WareReport_Service.RptWare_Hdbanhang(Ngay_Batdau, Ngay_Ketthuc);
        }

        //nhanvuong - 29/10/2010
        [WebMethod(Description = "RptWare_Hdbanhang_ByNhanvien")]
        public string RptWare_Hdbanhang_ByNhanvien(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Nhansu, object id_Doituong)
        {
            return _WareReport_Service.RptWare_Hdbanhang_ByNhanvien(Ngay_Batdau, Ngay_Ketthuc, Id_Nhansu, id_Doituong);
        }

        [WebMethod(Description = "RptWare_Hdbanhang_ByNhanvien")]
        public string RptWare_Hdbanhang_ByNhanvien_Loaihang(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Nhansu, object id_Doituong, object Id_Loai_Hanghoa_Ban)
        {
            return _WareReport_Service.RptWare_Hdbanhang_ByNhanvien_Loaihang(Ngay_Batdau, Ngay_Ketthuc, Id_Nhansu, id_Doituong, Id_Loai_Hanghoa_Ban);
        }

        [WebMethod(Description = "RptWare_Hdbanhang_ByKhachhang")]
        public string RptWare_Tonghop_Banhang_ByKhachhang(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Khachhang)
        {
            return _WareReport_Service.RptWare_Tonghop_Banhang_ByKhachhang(Ngay_Batdau, Ngay_Ketthuc, Id_Khachhang);
        }

        [WebMethod(Description = "RptWare_Hdbanhang_ByKhachhang")]
        public string RptWare_Hdbanhang_ByKhachhang(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Khachhang)
        {
            return _WareReport_Service.RptWare_Hdbanhang_ByKhachhang(Ngay_Batdau, Ngay_Ketthuc, Id_Khachhang);
        }

        [WebMethod(Description = "RptWare_Hdbanhang_ByKhohanghoa")]
        public string RptWare_Hdbanhang_ByKhohanghoa(object Ngay_Batdau, object Ngay_Ketthuc, object Ma_Kho_Hanghoa)
        {
            return _WareReport_Service.RptWare_Hdbanhang_ByKhohanghoa(Ngay_Batdau, Ngay_Ketthuc, Ma_Kho_Hanghoa);
        }

        [WebMethod(Description = "RptWare_Hdbanhang_ByKhuvuc")]
        public string RptWare_Hdbanhang_ByKhuvuc(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Cuahang_Ban)
        {
            return _WareReport_Service.RptWare_Hdbanhang_ByKhuvuc(Ngay_Batdau, Ngay_Ketthuc, Id_Cuahang_Ban);
        }

        [WebMethod(Description = "RptWare_Hdbanhang_ByLoaihanghoa")]
        public string RptWare_Hdbanhang_ByLoaihanghoa(object Ngay_Batdau, object Ngay_Ketthuc, object id_Doituong, object Id_Nhansu_Bh, object Id_Cuahang_Ban)
        {
            return _WareReport_Service.RptWare_Hdbanhang_ByLoaihanghoa(Ngay_Batdau, Ngay_Ketthuc, id_Doituong, Id_Nhansu_Bh, Id_Cuahang_Ban);
        }

        [WebMethod(Description = "RptWare_Hdbanhang_ByLoaihanghoa_new")]
        public string RptWare_Hdbanhang_ByLoaihanghoa_new(object Ngay_Batdau, object Ngay_Ketthuc, object id_Doituong, object Id_Nhansu_Bh, object Id_Cuahang_Ban, object Id_Loai_Hanghoa_Ban)
        {
            return _WareReport_Service.RptWare_Hdbanhang_ByLoaihanghoa_new(Ngay_Batdau, Ngay_Ketthuc, id_Doituong, Id_Nhansu_Bh, Id_Cuahang_Ban, Id_Loai_Hanghoa_Ban);
        }

        [WebMethod(Description = "RptWare_Hdbanhang_ByLoaihanghoa")]
        public string RptWare_Hdbanhang_ByLoaihanghoa_ByNhanvien(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Nhansu_Bh, object Id_Cuahang_Ban)
        {
            return _WareReport_Service.RptWare_Hdbanhang_ByLoaihanghoa_ByNhanvien(Ngay_Batdau, Ngay_Ketthuc, Id_Nhansu_Bh, Id_Cuahang_Ban);
        }

        [WebMethod(Description = "RptWare_Hdbanhang_ByLoaihanghoa_ByNhanvien_New")]
        public string RptWare_Hdbanhang_ByLoaihanghoa_ByNhanvien_New(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Nhansu_Bh, object Id_Cuahang_Ban, object Id_Loai_Hanghoa_Ban)
        {
            return _WareReport_Service.RptWare_Hdbanhang_ByLoaihanghoa_ByNhanvien_New(Ngay_Batdau, Ngay_Ketthuc, Id_Nhansu_Bh, Id_Cuahang_Ban, Id_Loai_Hanghoa_Ban);
        }

        #endregion

        #region nhap xuat ton

        [WebMethod(Description = "Rptware_Nxt_Hhmua")]
        public string Rptware_Nxt_Hhmua(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Kho_Hanghoa_Mua)
        {
            return _WareReport_Service.Rptware_Nxt_Hhmua(Ngay_Batdau, Ngay_Ketthuc, Id_Kho_Hanghoa_Mua);
        }

        [WebMethod(Description = "RptWare_Hdmuahang")]
        public string RptWare_Hdmuahang(object Ngay_Batdau, object Ngay_Ketthuc)
        {
            return _WareReport_Service.RptWare_Hdmuahang(Ngay_Batdau, Ngay_Ketthuc);
        }



        [WebMethod(Description = "RptWare_Donmuahang")]
        public string RptWare_Donmuahang_Kh(object Ngay_Batdau, object Ngay_Ketthuc)
        {
            return _WareReport_Service.RptWare_Donmuahang_Kh(Ngay_Batdau, Ngay_Ketthuc);
        }

        [WebMethod(Description = "Rptware_Nxt_Hhban")]
        public string Rptware_Nxt_Hhban(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Cuahang_Ban)
        {
            return _WareReport_Service.Rptware_Nxt_Hhban(Ngay_Batdau, Ngay_Ketthuc, Id_Cuahang_Ban);
        }

        [WebMethod(Description = "Rptware_Nxt_Hhban_Quydoi_Hhmua")]
        public string Rptware_Nxt_Hhban_Quydoi_Hhmua(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Cuahang_Ban)
        {
            return _WareReport_Service.Rptware_Nxt_Hhban_Quydoi_Hhmua(Ngay_Batdau, Ngay_Ketthuc, Id_Cuahang_Ban);
        }
        #endregion

        #region Giao ca
        [WebMethod(Description = "RptSplit_Sum_Hhmua")]
        public string RptSplit_Sum_Hhmua(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Kho_Hanghoa_Mua)
        {
            return _WareReport_Service.RptSplit_Sum_Hhmua(Ngay_Batdau, Ngay_Ketthuc, Id_Kho_Hanghoa_Mua);
        }

        [WebMethod(Description = "RptSplit_Sum_Hhmua")]
        public string RptSplit_Sum_Hhban(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Cuahang_Ban)
        {
            return _WareReport_Service.RptSplit_Sum_Hhban(Ngay_Batdau, Ngay_Ketthuc, Id_Cuahang_Ban);
        }

        [WebMethod(Description = "RptSplit_Sum_Hhban_4Bar")]
        public string RptSplit_Sum_Hhban_4Bar(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Cuahang_Ban)
        {
            return _WareReport_Service.RptSplit_Sum_Hhban_4Bar(Ngay_Batdau, Ngay_Ketthuc, Id_Cuahang_Ban);
        }
        #endregion

        #region so quy tien mat
        [WebMethod(Description = "RptWare_Hdmuahang")]
        public string RptWare_SoQTM(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Soquy)
        {
            return _WareReport_Service.RptWare_SoQTM(Ngay_Batdau, Ngay_Ketthuc, Id_Soquy);
        }

        [WebMethod(Description = "RptWare_Hdmuahang")]
        public string RptWare_SoQTM_ByKhohanghoa(object Ngay_Batdau, object Ngay_Ketthuc, object Ma_Kho_Hanghoa)
        {
            return _WareReport_Service.RptWare_SoQTM_ByKhohanghoa(Ngay_Batdau, Ngay_Ketthuc, Ma_Kho_Hanghoa);
        }
        [WebMethod(Description = "RptWare_Hdmuahang")]
        public string RptWare_SoQTM_2(object Ngay_Batdau, object Ngay_Ketthuc)
        {
            return _WareReport_Service.RptWare_SoQTM_2(Ngay_Batdau, Ngay_Ketthuc);
        }
        [WebMethod(Description = "RptWare_Hdmuahang")]
        public string RptWare_SoQTM_GetTon(object Ngay_Batdau, object Ngay_Ketthuc)
        {
            return _WareReport_Service.RptWare_SoQTM_GetTon(Ngay_Batdau, Ngay_Ketthuc);
        }

        [WebMethod(Description = "RptWare_Hh_Kh_Tra")]
        public string RptWare_Hh_Kh_Tra(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Kho_Hanghoa_Mua, object Id_Cuahang_Ban, object id_Hanghoa_Ban, object id_Loai_Hanghoa_Ban)
        {
            return _WareReport_Service.RptWare_Hh_Kh_Tra(Ngay_Batdau, Ngay_Ketthuc, Id_Kho_Hanghoa_Mua, Id_Cuahang_Ban, id_Hanghoa_Ban, id_Loai_Hanghoa_Ban);
        }
        #endregion

        #region Rptware_Thekho
        [WebMethod]
        public string Rptware_Thekho(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Cuahang_Ban, object Id_Hanghoa)
        {
            return _WareReport_Service.Rptware_Thekho(Ngay_Batdau, Ngay_Ketthuc, Id_Cuahang_Ban, Id_Hanghoa);
        }
        #endregion

        #region Rptware_Kiemke_Khohang
        [WebMethod]
        public string Rptware_Kiemke_Khohang(object Id_Cuahang_Ban, object Ngay_Batdau, object Ngay_Ketthuc)
        {
            return _WareReport_Service.Rptware_Kiemke_Khohang(Id_Cuahang_Ban, Ngay_Batdau, Ngay_Ketthuc);
        }
        #endregion

        #region Rptware_Kiemke_Khohang
        [WebMethod]
        public string Rptware_Nhapxuatton(object Id_Cuahang_Ban, object Ngay_Batdau, object Ngay_Ketthuc, object id_Hanghoa_Ban, object id_Loai_Hanghoa_Ban)
        {
            return _WareReport_Service.Rptware_Nhapxuatton(Id_Cuahang_Ban, Ngay_Batdau, Ngay_Ketthuc, id_Hanghoa_Ban, id_Loai_Hanghoa_Ban);
        }

        [WebMethod]
        public string Rptware_Nhapxuatton_Nguyenlieu(object Id_Cuahang_Ban, object Ngay_Batdau, object Ngay_Ketthuc, object id_Hanghoa_Ban, object id_Loai_Hanghoa_Ban)
        {
            return _WareReport_Service.Rptware_Nhapxuatton_Nguyenlieu(Id_Cuahang_Ban, Ngay_Batdau, Ngay_Ketthuc, id_Hanghoa_Ban, id_Loai_Hanghoa_Ban);
        }

        [WebMethod]
        public string Rptware_Nhapxuatton_mail(object Id_Cuahang_Ban, object Ngay_Batdau, object Ngay_Ketthuc, object Id_Loai_Hanghoa_Ban)
        {
            return _WareReport_Service.Rptware_Nhapxuatton_mail(Id_Cuahang_Ban, Ngay_Batdau, Ngay_Ketthuc, Id_Loai_Hanghoa_Ban);
        }

        [WebMethod]
        public string Rptware_Nhapxuatton_Giatri_Ton(object Ngay_Batdau, object Ngay_Ketthuc)
        {
            return _WareReport_Service.Rptware_Nhapxuatton_Giatri_Ton(Ngay_Batdau, Ngay_Ketthuc);
        }

        #endregion

        #region Rptware_Muahang_Xuattra_Chitiet
        [WebMethod]
        public string Rptware_Muahang_Xuattra_Chitiet(object Ngay_Batdau, object Ngay_Ketthuc, object id_cuahang_ban, object id_doituong)
        {
            return _WareReport_Service.Rptware_Muahang_Xuattra_Chitiet(Ngay_Batdau, Ngay_Ketthuc, id_cuahang_ban, id_doituong);
        }
        #endregion

        #region Rptware_Muahang_Congno_Tonghop
        [WebMethod]
        public string Rptware_Muahang_Congno_Tonghop(object Ngay_Batdau, object Ngay_Ketthuc, object id_Doituong)
        {
            return _WareReport_Service.Rptware_Muahang_Congno_Tonghop(Ngay_Batdau, Ngay_Ketthuc, id_Doituong);
        }

        #endregion

        #region Rptware_Banhang_Congno_Tonghop

        [WebMethod]
        public string Rptware_Banhang_Congno_Tonghop(object Ngay_Batdau, object Ngay_Ketthuc, object id_Doituong)
        {
            return _WareReport_Service.Rptware_Banhang_Congno_Tonghop(Ngay_Batdau, Ngay_Ketthuc, id_Doituong);
        }

        [WebMethod]
        public string Rptware_Banhang_Congno_Tonghop_Khuvuc(object Ngay_Batdau, object Ngay_Ketthuc, object id_Doituong, object Id_Cuahang_Ban)
        {
            return _WareReport_Service.Rptware_Banhang_Congno_Tonghop_Khuvuc(Ngay_Batdau, Ngay_Ketthuc, id_Doituong, Id_Cuahang_Ban);
        }

        [WebMethod]
        public string Rptware_Banhang_Congno_Tonghop_Khuvuc_New(object Ngay_Batdau, object Ngay_Ketthuc, object Ma_Doituong, object Id_Cuahang_Ban)
        {
            return _WareReport_Service.Rptware_Banhang_Congno_Tonghop_Khuvuc_New(Ngay_Batdau, Ngay_Ketthuc, Ma_Doituong, Id_Cuahang_Ban);
        }

        [WebMethod]
        public string Rptware_Banhang_Congno_Tonghop_Sale(object Ngay_Batdau, object Ngay_Ketthuc, object id_Doituong, object Id_Cuahang_Ban, object Id_Nhansu)
        {
            return _WareReport_Service.Rptware_Banhang_Congno_Tonghop_Sale(Ngay_Batdau, Ngay_Ketthuc, id_Doituong, Id_Cuahang_Ban, Id_Nhansu);
        }

        [WebMethod]
        public string Rptware_Banhang_Congno_Tonghop_Ncc(object Ngay_Batdau, object Ngay_Ketthuc, object id_Doituong)
        {
            return _WareReport_Service.Rptware_Banhang_Congno_Tonghop_Ncc(Ngay_Batdau, Ngay_Ketthuc, id_Doituong);
        }

        #endregion

        #region Rptware_Banhang_Congno_Tonghop
        [WebMethod]
        public string Rptware_Congno_Chitiet(object Ngay_Batdau, object Ngay_Ketthuc, object id_Doituong)
        {
            return _WareReport_Service.Rptware_Congno_Chitiet(Ngay_Batdau, Ngay_Ketthuc, id_Doituong);
        }      


        [WebMethod]
        public string Rptware_Banhang_Chitiet(object Ngay_Batdau, object Ngay_Ketthuc, object id_Doituong)
        {
            return _WareReport_Service.Rptware_Banhang_Chitiet(Ngay_Batdau, Ngay_Ketthuc, id_Doituong);
        }


        [WebMethod]
        public string Rptware_Banhang_Chitiet_Hanghoa(object Ngay_Batdau, object Ngay_Ketthuc, object id_Doituong, object Id_Hanghoa_Ban)
        {
            return _WareReport_Service.Rptware_Banhang_Chitiet_Hanghoa(Ngay_Batdau, Ngay_Ketthuc, id_Doituong, Id_Hanghoa_Ban);
        }

        [WebMethod]
        public string Ware_Congno_Phaithu_ByKhuvuc(object Id_Cuahang_Ban, object Id_Nhansu_Bh, object Id_Loai_Hanghoa_Ban, object Ngay_Chungtu)
        {
            return _WareReport_Service.Ware_Congno_Phaithu_ByKhuvuc(Id_Cuahang_Ban, Id_Nhansu_Bh, Id_Loai_Hanghoa_Ban, Ngay_Chungtu);
        }

        [WebMethod]
        public string Rpt_Congno_Chitiet_New(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Khachhang)
        {
            return _WareReport_Service.Rpt_Congno_Chitiet_New(Ngay_Batdau, Ngay_Ketthuc, Id_Khachhang);
        }

        [WebMethod]
        public string Rpt_Congno_Chitiet_New2(object Ngay_Batdau, object Ngay_Ketthuc, object Ma_Doituong)
        {
            return _WareReport_Service.Rpt_Congno_Chitiet_New2(Ngay_Batdau, Ngay_Ketthuc, Ma_Doituong);
        }

        [WebMethod]
        public string RptCongno_Sendmail(object Id_Nhansu)
        {
            return _WareReport_Service.RptCongno_Sendmail(Id_Nhansu);
        }

        [WebMethod]
        public string Ware_Hdbanhang_Chitiet_Dudoan_Dathang_SenMail(object Id_Nhansu)
        {
            return _WareReport_Service.Ware_Hdbanhang_Chitiet_Dudoan_Dathang_SenMail(Id_Nhansu);
        }

        [WebMethod]
        public string Rpt_Congno_Chitiet_Khuvuc(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Khachhang, object Id_Cuahang_Ban)
        {
            return _WareReport_Service.Rpt_Congno_Chitiet_Khuvuc(Ngay_Batdau, Ngay_Ketthuc, Id_Khachhang, Id_Cuahang_Ban);
        }

        [WebMethod]
        public string RptCongno_NCC_Chitiet(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Ncc)
        {
            return _WareReport_Service.RptCongno_NCC_Chitiet(Ngay_Batdau, Ngay_Ketthuc, Id_Ncc);
        }

        #endregion

        #region Rptware_Tonghop_Hoadon_Muahang_Thue
        [WebMethod]
        public string Rptware_Tonghop_Hoadon_Muahang_Thue(object Ngay_Batdau, object Ngay_Ketthuc)
        {
            return _WareReport_Service.Rptware_Tonghop_Hoadon_Muahang_Thue(Ngay_Batdau, Ngay_Ketthuc);
        }
        #endregion



        #region RptWare_Baocao_Trigia_Giavon_Giaban
        [WebMethod]
        public string RptWare_Baocao_Trigia_Giavon_Giaban(object Ngay_Batdau, object Ngay_Ketthuc, object id_Doituong, object Id_Cuahang_Ban, object Id_Loai_Hanghoa_Ban, object Id_Hanghoa_Ban)
        {
            return _WareReport_Service.RptWare_Baocao_Trigia_Giavon_Giaban(Ngay_Batdau, Ngay_Ketthuc, id_Doituong, Id_Cuahang_Ban, Id_Loai_Hanghoa_Ban, Id_Hanghoa_Ban);
        }
        #endregion
    }
}
