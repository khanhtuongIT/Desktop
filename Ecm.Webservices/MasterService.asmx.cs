
using System;
using System.Web;
using System.Data;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using Ecm.Service;
using Ecm.Service.MasterTables;
using Ecm.Service.MasterTables.Accounting;
using Ecm.Service.MasterTables.Bar;
using Ecm.Service.MasterTables.Rex;
using Ecm.Service.MasterTables.Ware;
using Ecm.Service.MasterTables.Service;
using Ecm.Service.Sys;

namespace Ecm.Webservice
{
    /// <summary>
    /// Summary description for MasterService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.Web.Script.Services.ScriptService]
    public class MasterService : System.Web.Services.WebService
    {
        //Connectiion
        System.Data.OleDb.OleDbConnection sqlConnection = DbConnection.OleDbConnection;

        #region Khai bao cac doi tuong
        //accounting
        Acc_Dm_Nganhang_Service _Acc_Dm_Nganhang_Service;
        Acc_Dm_Thue_Tncn_Luytien_Service _Acc_Dm_Thue_Tncn_Luytien_Service;

        //bar
        Bar_Dm_Menu_Service _Bar_Dm_Menu_Service;
        Bar_Dm_Khuvuc_Service _Bar_Dm_Khuvuc_Service;
        Bar_Dm_Table_Service _Bar_Dm_Table_Service;
        Bar_Dm_Menu_Hanghoa_Ban_Service _Bar_Dm_Menu_Hanghoa_Ban_Service;
        Bar_Dm_Facility_Service _Bar_Dm_Facility_Service;
        Bar_Dm_Table_Facility_Service _Bar_Dm_Table_Facility_Service;
        Bar_Dm_Class_Service _Bar_Dm_Class_Service;
        Bar_Dm_Rentlevel_Service _Bar_Dm_Rentlevel_Service;

        //ware
        Ware_Dm_Cap_Service _Ware_Dm_Cap_Service;
        Ware_Dm_Donvitinh_Service _Ware_Dm_Donvitinh_Service;
        //Ware_Dm_Congthuc_Phache_Service _Ware_Dm_Congthuc_Phache_Service;
        Ware_Dm_Soquy_Service _Ware_Dm_Soquy_Service;
        Ware_Dm_Cuahang_Ban_Service _Ware_Dm_Cuahang_Ban_Service;
        Ware_Dm_Hanghoa_Ban_Service _Ware_Dm_Hanghoa_Ban_Service;
        Ware_Dm_Hanghoa_Mua_Service _Ware_Dm_Hanghoa_Mua_Service;
        //Ware_Dm_Kho_Hanghoa_Mua_Service _Ware_Dm_Kho_Hanghoa_Mua_Service;
        Ware_Dm_Loai_Hanghoa_Ban_Service _Ware_Dm_Loai_Hanghoa_Ban_Service;
        Ware_Dm_Loai_Hanghoa_Mua_Service _Ware_Dm_Loai_Hanghoa_Mua_Service;
        Ware_Dm_Nhom_Hanghoa_Ban_Service _Ware_Dm_Nhom_Hanghoa_Ban_Service;
        Ware_Dm_Nhom_Hanghoa_Mua_Service _Ware_Dm_Nhom_Hanghoa_Mua_Service;
        Ware_Dm_Nhacungcap_Service _Ware_Dm_Nhacungcap_Service;
        //Ware_Dm_Nhasanxuat_Service _Ware_Dm_Nhasanxuat_Service;
        Ware_Dm_Khachhang_Service _Ware_Dm_Khachhang_Service;
        //Ware_Dm_Congthuc_Phache_Chitiet_Service _Ware_Dm_Congthuc_Phache_Chitiet_Service;
        //Ware_Dm_Loai_Quytm_Service _Ware_Dm_Loai_Quytm_Service;
        Ware_Dm_Donvitinh_Quydoi_Service _Ware_Dm_Donvitinh_Quydoi_Service;
        Ware_Dm_Tiente_Service _Ware_Dm_Tiente_Service;
        Ware_Dm_Nganhang_Service _Ware_Dm_Nganhang_Service;
        Ware_Dm_Taikhoan_Nganhang_Service _Ware_Dm_Taikhoan_Nganhang_Service;
        Ware_Hanghoa_Service _Ware_Hanghoa_Service;
        Ecm.Service.Ware.Ware_Hanghoa_Dinhgia_Service _Ware_Hanghoa_Dinhgia_Service;
        Ecm.Service.Ware.Ware_Hanghoa_Dinhgia_Khuvuc_Service _Ware_Hanghoa_Dinhgia_Khuvuc_Service;
        Ware_Dm_Xe_Service _Ware_Dm_Xe_Service;
        Ware_Dm_Phanloai_Nhom_Hanghoa_Ban_Service _Ware_Dm_Phanloai_Nhom_Hanghoa_Ban_Service;

        //rex
        Rex_Dm_Ca_Lamviec_Service _Rex_Dm_Ca_Lamviec_Service;
        Rex_Dm_Bophan_Service _Rex_Dm_Bophan_Service;
        Rex_Dm_Dantoc_Service _Rex_Dm_Dantoc_Service;
        Rex_Dm_Honnhan_Service _Rex_Dm_Honnhan_Service;
        Rex_Dm_Quocgia_Service _Rex_Dm_Quocgia_Service;
        Rex_Dm_Tinh_Service _Rex_Dm_Tinh_Service;
        Rex_Dm_Huyen_Service _Rex_Dm_Huyen_Service;
        Rex_Dm_Xa_Service _Rex_Dm_Xa_Service;
        Rex_Dm_Loai_Ktkl_Service _Rex_Dm_Loai_Ktkl_Service;
        Rex_Dm_Loai_Bophan_Service _Rex_Dm_Loai_Bophan_Service;
        Rex_Dm_Chungchi_Service _Rex_Dm_Chungchi_Service;
        Rex_Dm_Tinhoc_Service _Rex_Dm_Tinhoc_Service;
        Rex_Dm_Tochuc_Service _Rex_Dm_Tochuc_Service;
        Rex_Dm_Xeploai_Service _Rex_Dm_Xeploai_Service;
        Rex_Dm_Ngoaingu_Service _Rex_Dm_Ngoaingu_Service;
        Rex_Dm_Loai_Nghiphep_Service _Rex_Dm_Loai_Nghiphep_Service;
        Rex_Dm_Tongiao_Service _Rex_Dm_Tongiao_Service;
        Rex_Dm_Tpbanthan_Service _Rex_Dm_Tpbanthan_Service;
        Rex_Dm_Tpgiadinh_Service _Rex_Dm_Tpgiadinh_Service;
        Rex_Dm_Vanhoa_Service _Rex_Dm_Vanhoa_Service;
        Rex_Dm_Loai_Hopdong_Service _Rex_Dm_Loai_Hopdong_Service;
        Rex_Dm_Ngachluong_Service _Rex_Dm_Ngachluong_Service;
        Rex_Dm_Bacluong_Service _Rex_Dm_Bacluong_Service;
        Rex_Dm_Chuyenmon_Service _Rex_Dm_Chuyenmon_Service;
        Rex_Dm_Kynang_Chuyenmon_Service _Rex_Dm_Kynang_Chuyenmon_Service;
        Rex_Dm_Coquan_Service _Rex_Dm_Coquan_Service;
        Rex_Dm_Phucap_Service _Rex_Dm_Phucap_Service;
        Rex_Dm_Chucvu_Service _Rex_Dm_Chucvu_Service;
        Rex_Dm_Ngaynghi_Service _Rex_Dm_Ngaynghi_Service;
        Rex_Dm_Heso_Giotangca_Service _Rex_Dm_Heso_Giotangca_Service;
        Rex_Dm_Phuongthuc_Huongluong_Service _Rex_Dm_Phuongthuc_Huongluong_Service;
        Rex_Dm_Quanhe_Giadinh_Service _Rex_Dm_Quanhe_Giadinh_Service;
        Rex_Dm_Khenthuong_Kyluat_Service _Rex_Dm_Khenthuong_Kyluat_Service;
        Rex_Dm_Quyetdinh_Service _Rex_Dm_Quyetdinh_Service;
        Rex_Dm_Loai_Nhanvien_Service _Rex_Dm_Loai_Nhanvien_Service;
        Rex_Dm_Ndung_Tgluong_Service _Rex_Dm_Ndung_Tgluong_Service;

        //service
        DocumentProcessStatus_Service _DocumentProcessStatus_Service;

        //Sys_Service
        Sys_Service _Sys_Service;
        Rex_Dm_Heso_Chuongtrinh_Service _Rex_Dm_Heso_Chuongtrinh_Service;

        #endregion

        public MasterService()
        {
            #region Khoi tao cac doi tuong - danh muc account
            _Acc_Dm_Nganhang_Service = new Acc_Dm_Nganhang_Service(sqlConnection);
            _Acc_Dm_Thue_Tncn_Luytien_Service = new Acc_Dm_Thue_Tncn_Luytien_Service(sqlConnection);
            #endregion

            #region Khoi tao cac doi tuong - danh muc bar
            _Bar_Dm_Menu_Hanghoa_Ban_Service = new Bar_Dm_Menu_Hanghoa_Ban_Service(sqlConnection);
            _Bar_Dm_Khuvuc_Service = new Bar_Dm_Khuvuc_Service(sqlConnection);
            _Bar_Dm_Menu_Service = new Bar_Dm_Menu_Service(sqlConnection);
            _Bar_Dm_Table_Service = new Bar_Dm_Table_Service(sqlConnection);
            _Bar_Dm_Facility_Service = new Bar_Dm_Facility_Service(sqlConnection);
            _Bar_Dm_Class_Service = new Bar_Dm_Class_Service(sqlConnection);
            _Bar_Dm_Table_Facility_Service = new Bar_Dm_Table_Facility_Service(sqlConnection);
            _Bar_Dm_Rentlevel_Service = new Bar_Dm_Rentlevel_Service(sqlConnection);
            #endregion

            #region Khoi tao cac doi tuong - danh muc ware
            _Ware_Dm_Cap_Service = new Ware_Dm_Cap_Service(sqlConnection);
            _Ware_Dm_Donvitinh_Service = new Ware_Dm_Donvitinh_Service(sqlConnection);
            //_Ware_Dm_Congthuc_Phache_Service = new Ware_Dm_Congthuc_Phache_Service(sqlConnection);
            _Ware_Dm_Cuahang_Ban_Service = new Ware_Dm_Cuahang_Ban_Service(sqlConnection);
            _Ware_Dm_Soquy_Service = new Ware_Dm_Soquy_Service(sqlConnection);
            _Ware_Dm_Hanghoa_Ban_Service = new Ware_Dm_Hanghoa_Ban_Service(sqlConnection);
            _Ware_Dm_Hanghoa_Mua_Service = new Ware_Dm_Hanghoa_Mua_Service(sqlConnection);
            //_Ware_Dm_Kho_Hanghoa_Mua_Service = new Ware_Dm_Kho_Hanghoa_Mua_Service(sqlConnection);
            _Ware_Dm_Loai_Hanghoa_Ban_Service = new Ware_Dm_Loai_Hanghoa_Ban_Service(sqlConnection);
            _Ware_Dm_Loai_Hanghoa_Mua_Service = new Ware_Dm_Loai_Hanghoa_Mua_Service(sqlConnection);
            _Ware_Dm_Nhom_Hanghoa_Ban_Service = new Ware_Dm_Nhom_Hanghoa_Ban_Service(sqlConnection);
            _Ware_Dm_Nhom_Hanghoa_Mua_Service = new Ware_Dm_Nhom_Hanghoa_Mua_Service(sqlConnection);
            _Ware_Dm_Nhacungcap_Service = new Ware_Dm_Nhacungcap_Service(sqlConnection);
            //_Ware_Dm_Nhasanxuat_Service = new Ware_Dm_Nhasanxuat_Service(sqlConnection);
            _Ware_Dm_Khachhang_Service = new Ware_Dm_Khachhang_Service(sqlConnection);
            //_Ware_Dm_Congthuc_Phache_Chitiet_Service = new Ware_Dm_Congthuc_Phache_Chitiet_Service(sqlConnection);
            //_Ware_Dm_Loai_Quytm_Service = new Ware_Dm_Loai_Quytm_Service(sqlConnection);
            _Ware_Dm_Donvitinh_Quydoi_Service = new Ware_Dm_Donvitinh_Quydoi_Service(sqlConnection);
            _Ware_Dm_Tiente_Service = new Ware_Dm_Tiente_Service(sqlConnection);
            _Ware_Dm_Nganhang_Service = new Ware_Dm_Nganhang_Service(sqlConnection);
            _Ware_Dm_Taikhoan_Nganhang_Service = new Ware_Dm_Taikhoan_Nganhang_Service(sqlConnection);
            _Ware_Hanghoa_Service = new Ware_Hanghoa_Service(sqlConnection);
            _Ware_Dm_Xe_Service = new Ware_Dm_Xe_Service(sqlConnection);
            //ware (not master)
            _Ware_Hanghoa_Dinhgia_Service = new Ecm.Service.Ware.Ware_Hanghoa_Dinhgia_Service(sqlConnection);
            _Ware_Hanghoa_Dinhgia_Khuvuc_Service = new Ecm.Service.Ware.Ware_Hanghoa_Dinhgia_Khuvuc_Service(sqlConnection);
            _Ware_Dm_Phanloai_Nhom_Hanghoa_Ban_Service = new Ware_Dm_Phanloai_Nhom_Hanghoa_Ban_Service(sqlConnection);
            #endregion

            #region Khoi tao cac doi tuong - danh muc rex
            _Rex_Dm_Ca_Lamviec_Service = new Rex_Dm_Ca_Lamviec_Service(sqlConnection);
            _Rex_Dm_Bophan_Service = new Rex_Dm_Bophan_Service(sqlConnection);
            _Rex_Dm_Dantoc_Service = new Rex_Dm_Dantoc_Service(sqlConnection);
            _Rex_Dm_Honnhan_Service = new Rex_Dm_Honnhan_Service(sqlConnection);
            _Rex_Dm_Quocgia_Service = new Rex_Dm_Quocgia_Service(sqlConnection);
            _Rex_Dm_Tinh_Service = new Rex_Dm_Tinh_Service(sqlConnection);
            _Rex_Dm_Huyen_Service = new Rex_Dm_Huyen_Service(sqlConnection);
            _Rex_Dm_Xa_Service = new Rex_Dm_Xa_Service(sqlConnection);
            _Rex_Dm_Loai_Ktkl_Service = new Rex_Dm_Loai_Ktkl_Service(sqlConnection);
            _Rex_Dm_Loai_Bophan_Service = new Rex_Dm_Loai_Bophan_Service(sqlConnection);
            _Rex_Dm_Chungchi_Service = new Rex_Dm_Chungchi_Service(sqlConnection);
            _Rex_Dm_Tinhoc_Service = new Rex_Dm_Tinhoc_Service(sqlConnection);
            _Rex_Dm_Ngoaingu_Service = new Rex_Dm_Ngoaingu_Service(sqlConnection);
            _Rex_Dm_Tochuc_Service = new Rex_Dm_Tochuc_Service(sqlConnection);
            _Rex_Dm_Xeploai_Service = new Rex_Dm_Xeploai_Service(sqlConnection);
            _Rex_Dm_Loai_Nghiphep_Service = new Rex_Dm_Loai_Nghiphep_Service(sqlConnection);
            _Rex_Dm_Tongiao_Service = new Rex_Dm_Tongiao_Service(sqlConnection);
            _Rex_Dm_Tpbanthan_Service = new Rex_Dm_Tpbanthan_Service(sqlConnection);
            _Rex_Dm_Tpgiadinh_Service = new Rex_Dm_Tpgiadinh_Service(sqlConnection);
            _Rex_Dm_Vanhoa_Service = new Rex_Dm_Vanhoa_Service(sqlConnection);
            _Rex_Dm_Loai_Hopdong_Service = new Rex_Dm_Loai_Hopdong_Service(sqlConnection);
            _Rex_Dm_Ngachluong_Service = new Rex_Dm_Ngachluong_Service(sqlConnection);
            _Rex_Dm_Bacluong_Service = new Rex_Dm_Bacluong_Service(sqlConnection);
            _Rex_Dm_Chuyenmon_Service = new Rex_Dm_Chuyenmon_Service(sqlConnection);
            _Rex_Dm_Kynang_Chuyenmon_Service = new Rex_Dm_Kynang_Chuyenmon_Service(sqlConnection);
            _Rex_Dm_Coquan_Service = new Rex_Dm_Coquan_Service(sqlConnection);
            _Rex_Dm_Phucap_Service = new Rex_Dm_Phucap_Service(sqlConnection);
            _Rex_Dm_Chucvu_Service = new Rex_Dm_Chucvu_Service(sqlConnection);
            _Rex_Dm_Ngaynghi_Service = new Rex_Dm_Ngaynghi_Service(sqlConnection);
            _Rex_Dm_Heso_Giotangca_Service = new Rex_Dm_Heso_Giotangca_Service(sqlConnection);
            _Rex_Dm_Phuongthuc_Huongluong_Service = new Rex_Dm_Phuongthuc_Huongluong_Service(sqlConnection);
            _Rex_Dm_Quanhe_Giadinh_Service = new Rex_Dm_Quanhe_Giadinh_Service(sqlConnection);
            _Rex_Dm_Khenthuong_Kyluat_Service = new Rex_Dm_Khenthuong_Kyluat_Service(sqlConnection);
            _Rex_Dm_Quyetdinh_Service = new Rex_Dm_Quyetdinh_Service(sqlConnection);

            _Rex_Dm_Loai_Nhanvien_Service = new Rex_Dm_Loai_Nhanvien_Service(sqlConnection);

            _Rex_Dm_Kynang_Chuyenmon_Service = new Rex_Dm_Kynang_Chuyenmon_Service(sqlConnection);
            _Rex_Dm_Ndung_Tgluong_Service = new Rex_Dm_Ndung_Tgluong_Service(sqlConnection);
            #endregion

            #region Khoi tao cac service
            _DocumentProcessStatus_Service = new DocumentProcessStatus_Service(sqlConnection);

            #endregion

            _Sys_Service = new Sys_Service(sqlConnection);
            _Rex_Dm_Heso_Chuongtrinh_Service = new Rex_Dm_Heso_Chuongtrinh_Service(sqlConnection);
        }

        #region Account - Webmethod
        #region Danh mục ngân hàng


        [WebMethod(BufferResponse = true, Description = "Trả về danh sách ngân hàng (trong một mảng) Acc_Dm_Nganhang_Collection")]
        public string Get_Acc_Dm_Nganhang_Collection1()
        {
            return _Acc_Dm_Nganhang_Service.Get_Acc_Dm_Nganhang_Collection(); ;
        }

        [WebMethod(BufferResponse = true, Description = "Trả về danh sách ngân hàng by ky luong Acc_Dm_Nganhang_Collection_By_Kyluong")]
        public string Get_Acc_Dm_Nganhang_Collection_By_Kyluong(object thang_kyluong, object nam_kyluong)
        {
            Hashtable kyluong = new Hashtable();
            kyluong.Add("thang_kyluong", thang_kyluong);
            kyluong.Add("nam_kyluong", nam_kyluong);

            var Acc_Dm_Nganhang_Collection = _Acc_Dm_Nganhang_Service.Get_Acc_Dm_Nganhang_Collection_By_Kyluong(kyluong);
            return Acc_Dm_Nganhang_Collection;
        }

        [WebMethod(BufferResponse = true, Description = "Trả về danh sách ngân hàng được Serialize thành DataSet")]
        public string Get_Acc_Dm_Nganhang_Collection3()
        {
            return _Acc_Dm_Nganhang_Service.GetDs_Acc_Dm_Nganhang_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Insert một đối tượng Acc_Dm_Nganhang vào bảng acc_dm_nganhang")]
        public object Insert_Acc_Dm_Nganhang(Ecm.Domain.MasterTables.Accounting.Acc_Dm_Nganhang Acc_Dm_Nganhang)
        {
            return _Acc_Dm_Nganhang_Service.Insert_Acc_Dm_Nganhang(Acc_Dm_Nganhang);
        }

        [WebMethod(BufferResponse = true, Description = "Cập nhật một đối tượng Acc_Dm_Nganhang trong bảng acc_dm_nganhang")]
        public object Update_Acc_Dm_Nganhang(Ecm.Domain.MasterTables.Accounting.Acc_Dm_Nganhang Acc_Dm_Nganhang)
        {
            return _Acc_Dm_Nganhang_Service.Update_Acc_Dm_Nganhang(Acc_Dm_Nganhang);
        }

        [WebMethod(BufferResponse = true, Description = "Xóa một đối tượng Acc_Dm_Nganhang trong bảng acc_dm_nganhang")]
        public object Delete_Acc_Dm_Nganhang(Ecm.Domain.MasterTables.Accounting.Acc_Dm_Nganhang Acc_Dm_Nganhang)
        {
            return _Acc_Dm_Nganhang_Service.Delete_Acc_Dm_Nganhang(Acc_Dm_Nganhang);
        }

        [WebMethod(BufferResponse = true, Description = "cập nhật một dataset Acc_Dm_Nganhang vào trong bảng acc_dm_nganhang")]
        public object Update_Acc_Dm_Nganhang_Collection(DataSet ds_Acc_Dm_Nganhang)
        {
            return _Acc_Dm_Nganhang_Service.Update_Acc_Dm_Nganhang_Collection(ds_Acc_Dm_Nganhang);
        }
        #endregion

        #region Acc_Dm_Thue_Tncn_Luytien_Service

        [WebMethod]
        public string Get_Acc_Dm_Thue_Tncn_Luytien_Collection()
        {
            return _Acc_Dm_Thue_Tncn_Luytien_Service.Get_Acc_Dm_Thue_Tncn_Luytien_Collection();
        }

        [WebMethod]
        public object Insert_Acc_Dm_Thue_Tncn_Luytien(Ecm.Domain.MasterTables.Accounting.Acc_Dm_Thue_Tncn_Luytien acc_Dm_Thue_Tncn_Luytien)
        {
            return _Acc_Dm_Thue_Tncn_Luytien_Service.Insert_Acc_Dm_Thue_Tncn_Luytien(acc_Dm_Thue_Tncn_Luytien);
        }

        [WebMethod]
        public object Update_Acc_Dm_Thue_Tncn_Luytien(Ecm.Domain.MasterTables.Accounting.Acc_Dm_Thue_Tncn_Luytien acc_Dm_Thue_Tncn_Luytien)
        {
            return _Acc_Dm_Thue_Tncn_Luytien_Service.Update_Acc_Dm_Thue_Tncn_Luytien(acc_Dm_Thue_Tncn_Luytien);
        }

        [WebMethod]
        public object Delete_Acc_Dm_Thue_Tncn_Luytien(Ecm.Domain.MasterTables.Accounting.Acc_Dm_Thue_Tncn_Luytien acc_Dm_Thue_Tncn_Luytien)
        {
            return _Acc_Dm_Thue_Tncn_Luytien_Service.Delete_Acc_Dm_Thue_Tncn_Luytien(acc_Dm_Thue_Tncn_Luytien);
        }

        [WebMethod]
        public object Update_Acc_Dm_Thue_Tncn_Luytien_Collection(DataSet dsAcc_Dm_Thue_Tncn_Luytien)
        {
            return _Acc_Dm_Thue_Tncn_Luytien_Service.Update_Acc_Dm_Thue_Tncn_Luytien_Collection(dsAcc_Dm_Thue_Tncn_Luytien);
        }
        #endregion

        #endregion

        #region Bar - Webmethod
        #region Bar_Dm_Menu
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Bar_Dm_Menu")]
        public string Get_All_Bar_Dm_Menu()
        {
            return _Bar_Dm_Menu_Service.Get_All_Bar_Dm_Menu_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Bar_Dm_Menu")]
        public string Get_Visible_Bar_Dm_Menu()
        {
            return _Bar_Dm_Menu_Service.Get_Visible_Bar_Dm_Menu_Collection();
        }
        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Bar_Dm_Menu vào DB")]
        public object Insert_Bar_Dm_Menu(Ecm.Domain.MasterTables.Bar.Bar_Dm_Menu Bar_Dm_Menu)
        {
            //RemoveOutputCacheItem
            HttpResponse.RemoveOutputCacheItem("/Ecm.Webservices/MasterService.asmx");

            return _Bar_Dm_Menu_Service.Insert_Bar_Dm_Menu(Bar_Dm_Menu);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Bar_Dm_Menu vào DB")]
        public object Update_Bar_Dm_Menu(Ecm.Domain.MasterTables.Bar.Bar_Dm_Menu Bar_Dm_Menu)
        {
            //RemoveOutputCacheItem
            HttpResponse.RemoveOutputCacheItem("/Ecm.Webservices/MasterService.asmx");

            return _Bar_Dm_Menu_Service.Update_Bar_Dm_Menu(Bar_Dm_Menu);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Bar_Dm_Menu vào DB")]
        public object Delete_Bar_Dm_Menu(Ecm.Domain.MasterTables.Bar.Bar_Dm_Menu Bar_Dm_Menu)
        {
            //RemoveOutputCacheItem
            HttpResponse.RemoveOutputCacheItem("/Ecm.Webservices/MasterService.asmx");

            return _Bar_Dm_Menu_Service.Delete_Bar_Dm_Menu(Bar_Dm_Menu);
        }

        [WebMethod(BufferResponse = true, Description = "Update Collection Bar_Dm_Menu vào DB")]
        public object Update_Bar_Dm_Menu_Collection(DataSet dsCollection)
        {
            //RemoveOutputCacheItem
            HttpResponse.RemoveOutputCacheItem("/Ecm.Webservices/MasterService.asmx");

            return _Bar_Dm_Menu_Service.Update_Bar_Dm_Menu_Collection(dsCollection);
        }

        [WebMethod]
        public object Init_Bar_Dm_Menu_WithNhom_Hanghoa_Ban(Ecm.Domain.MasterTables.Bar.Bar_Dm_Menu bar_Dm_Menu)
        {
            //RemoveOutputCacheItem
            HttpResponse.RemoveOutputCacheItem("/Ecm.Webservices/MasterService.asmx");

            return _Bar_Dm_Menu_Service.Init_Bar_Dm_Menu_WithNhom_Hanghoa_Ban(bar_Dm_Menu);
        }
        #endregion

        #region Bar_Dm_Menu_Hanghoa_Ban

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Bar_Dm_Menu_Hanghoa_Ban")]
        public string Get_All_Bar_Dm_Menu_Hanghoa_Ban()
        {
            return _Bar_Dm_Menu_Hanghoa_Ban_Service.Get_All_Bar_Dm_Menu_Hanghoa_Ban_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Bar_Dm_Menu_Hanghoa_Ban")]
        public string Get_All_Bar_Dm_Menu_Hanghoa_Ban_By_Id_Menu(object id_menu, object id_khuvuc)
        {
            return _Bar_Dm_Menu_Hanghoa_Ban_Service.Get_All_Bar_Dm_Menu_Hanghoa_Ban_By_Id_Menu_Collection(id_menu, id_khuvuc);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Bar_Dm_Menu_Hanghoa_Ban")]
        public string Get_Visible_Bar_Dm_Menu_Hanghoa_Ban_Collection(object ngay_chungtu, object id_khuvuc)
        {
            return _Bar_Dm_Menu_Hanghoa_Ban_Service.Get_Visible_Bar_Dm_Menu_Hanghoa_Ban_Collection(ngay_chungtu, id_khuvuc);
        }
        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Bar_Dm_Menu_Hanghoa_Ban vào DB")]
        public object Insert_Bar_Dm_Menu_Hanghoa_Ban(Ecm.Domain.MasterTables.Bar.Bar_Dm_Menu_Hanghoa_Ban Bar_Dm_Menu_Hanghoa_Ban)
        {
            //RemoveOutputCacheItem
            HttpResponse.RemoveOutputCacheItem("/Ecm.Webservices/MasterService.asmx");

            return _Bar_Dm_Menu_Hanghoa_Ban_Service.Insert_Bar_Dm_Menu_Hanghoa_Ban(Bar_Dm_Menu_Hanghoa_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Bar_Dm_Menu_Hanghoa_Ban vào DB")]
        public object Update_Bar_Dm_Menu_Hanghoa_Ban(Ecm.Domain.MasterTables.Bar.Bar_Dm_Menu_Hanghoa_Ban Bar_Dm_Menu_Hanghoa_Ban)
        {
            //RemoveOutputCacheItem
            HttpResponse.RemoveOutputCacheItem("/Ecm.Webservices/MasterService.asmx");

            return _Bar_Dm_Menu_Hanghoa_Ban_Service.Update_Bar_Dm_Menu_Hanghoa_Ban(Bar_Dm_Menu_Hanghoa_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Bar_Dm_Menu_Hanghoa_Ban vào DB")]
        public object Delete_Bar_Dm_Menu_Hanghoa_Ban(Ecm.Domain.MasterTables.Bar.Bar_Dm_Menu_Hanghoa_Ban Bar_Dm_Menu_Hanghoa_Ban)
        {
            //RemoveOutputCacheItem
            HttpResponse.RemoveOutputCacheItem("/Ecm.Webservices/MasterService.asmx");

            return _Bar_Dm_Menu_Hanghoa_Ban_Service.Delete_Bar_Dm_Menu_Hanghoa_Ban(Bar_Dm_Menu_Hanghoa_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "Update Collection Bar_Dm_Menu_Hanghoa_Ban vào DB")]
        public object Update_Bar_Dm_Menu_Hanghoa_Ban_Collection(DataSet dsCollection)
        {
            //RemoveOutputCacheItem
            HttpResponse.RemoveOutputCacheItem("/Ecm.Webservices/MasterService.asmx");

            return _Bar_Dm_Menu_Hanghoa_Ban_Service.Update_Bar_Dm_Menu_Hanghoa_Ban_Collection(dsCollection);
        }

        #endregion

        #region Bar_Dm_Khuvuc
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Bar_Dm_Khuvuc")]
        public string Get_All_Bar_Dm_Khuvuc()
        {
            return _Bar_Dm_Khuvuc_Service.Get_All_Bar_Dm_Khuvuc_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset (distinct) vị trí trong Bar_Dm_Khuvuc ")]
        public string Get_All_Bar_Dm_Khuvuc_ByCuahang(Ecm.Domain.MasterTables.Bar.Bar_Dm_Khuvuc Bar_Dm_Khuvuc)
        {
            return _Bar_Dm_Khuvuc_Service.Get_All_Bar_Dm_Khuvuc_ByCuahang(Bar_Dm_Khuvuc);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset (distinct) vị trí trong Bar_Dm_Khuvuc ")]
        public string Get_All_Bar_Dm_Khuvuc_ByCuahang_2(object _Id_Cuahang_Ban)
        {
            return _Bar_Dm_Khuvuc_Service.Get_All_Bar_Dm_Khuvuc_ByCuahang(new Domain.MasterTables.Bar.Bar_Dm_Khuvuc() { Id_Cuahang_Ban = _Id_Cuahang_Ban });
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Bar_Dm_Khuvuc vào DB")]
        public object Insert_Bar_Dm_Khuvuc(Ecm.Domain.MasterTables.Bar.Bar_Dm_Khuvuc Bar_Dm_Khuvuc)
        {
            return _Bar_Dm_Khuvuc_Service.Insert_Bar_Dm_Khuvuc(Bar_Dm_Khuvuc);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Bar_Dm_Khuvuc vào DB")]
        public object Update_Bar_Dm_Khuvuc(Ecm.Domain.MasterTables.Bar.Bar_Dm_Khuvuc Bar_Dm_Khuvuc)
        {
            return _Bar_Dm_Khuvuc_Service.Update_Bar_Dm_Khuvuc(Bar_Dm_Khuvuc);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Bar_Dm_Khuvuc vào DB")]
        public object Delete_Bar_Dm_Khuvuc(Ecm.Domain.MasterTables.Bar.Bar_Dm_Khuvuc Bar_Dm_Khuvuc)
        {
            return _Bar_Dm_Khuvuc_Service.Delete_Bar_Dm_Khuvuc(Bar_Dm_Khuvuc);
        }

        [WebMethod(BufferResponse = true, Description = "Update Collection Bar_Dm_Khuvuc vào DB")]
        public object Update_Bar_Dm_Khuvuc_Collection(DataSet dsCollection)
        {
            return _Bar_Dm_Khuvuc_Service.Update_Bar_Dm_Khuvuc_Collection(dsCollection);
        }

        #endregion

        #region Bar_Dm_Table
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Bar_Dm_Table")]
        public string Get_All_Bar_Dm_Table()
        {
            return _Bar_Dm_Table_Service.Get_All_Bar_Dm_Table_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Bar_Dm_Table")]
        public string Get_All_Bar_Dm_Table_WithClass(object Id_Cuahang_Ban, object Id_Khuvuc, object Id_Class, object Allow_Housekeeping)
        {
            return _Bar_Dm_Table_Service.Get_All_Bar_Dm_Table_WithClass(Id_Cuahang_Ban, Id_Khuvuc, Id_Class, Allow_Housekeeping);
        }

        [WebMethod]
        public string Get_All_Bar_Dm_Table_ByKhuvuc(Ecm.Domain.MasterTables.Bar.Bar_Dm_Table bar_Dm_Table)
        {
            return _Bar_Dm_Table_Service.Get_All_Bar_Dm_Table_ByKhuvuc(bar_Dm_Table);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset (distinct) vị trí trong bar_dm_table ")]
        public string Get_All_ViTri_Dm_Bar_Table()
        {
            return _Bar_Dm_Table_Service.Get_All_ViTri_Dm_Bar_Table();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Bar_Dm_Table vào DB")]
        public object Insert_Bar_Dm_Table(Ecm.Domain.MasterTables.Bar.Bar_Dm_Table Bar_Dm_Table)
        {
            return _Bar_Dm_Table_Service.Insert_Bar_Dm_Table(Bar_Dm_Table);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Bar_Dm_Table vào DB")]
        public object Update_Bar_Dm_Table(Ecm.Domain.MasterTables.Bar.Bar_Dm_Table Bar_Dm_Table)
        {
            return _Bar_Dm_Table_Service.Update_Bar_Dm_Table(Bar_Dm_Table);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Bar_Dm_Table vào DB")]
        public object Delete_Bar_Dm_Table(Ecm.Domain.MasterTables.Bar.Bar_Dm_Table Bar_Dm_Table)
        {
            return _Bar_Dm_Table_Service.Delete_Bar_Dm_Table(Bar_Dm_Table);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Bar_Dm_Table_ChiTiet vào DB")]
        public object Delete_Bar_Dm_Table_ChiTiet(object Id)
        {
            return _Bar_Dm_Table_Service.Delete_Bar_Dm_Table_ChiTiet(Id);
        }

        [WebMethod(BufferResponse = true, Description = "Update Collection Bar_Dm_Table vào DB")]
        public object Update_Bar_Dm_Table_Collection(DataSet dsCollection)
        {
            return _Bar_Dm_Table_Service.Update_Bar_Dm_Table_Collection(dsCollection);
        }

        #endregion

        #region Bar_Dm_Facility
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Bar_Dm_Table")]
        public string Get_All_Bar_Dm_Facility()
        {
            return _Bar_Dm_Facility_Service.Get_All_Bar_Dm_Facility_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Bar_Dm_Table")]
        public object Update_Bar_Dm_Facility_Collection(DataSet dsCollection)
        {
            return _Bar_Dm_Facility_Service.Update_Bar_Dm_Facility_Collection(dsCollection);
        }
        #endregion

        #region Bar_Dm_Class
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Bar_Dm_Table")]
        public string Get_All_Bar_Dm_Class()
        {
            return _Bar_Dm_Class_Service.Get_All_Bar_Dm_Class_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Bar_Dm_Table")]
        public object Update_Bar_Dm_Class_Collection(DataSet dsCollection)
        {
            return _Bar_Dm_Class_Service.Update_Bar_Dm_Class_Collection(dsCollection);
        }
        #endregion

        #region Bar_Dm_Table_Facility
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Bar_Dm_Table")]
        public string Get_All_Bar_Dm_Table_Facility_Collection(object Id_Table)
        {
            return _Bar_Dm_Table_Facility_Service.Get_All_Bar_Dm_Table_Facility_Collection(Id_Table);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Bar_Dm_Table")]
        public object Update_Bar_Dm_Table_Facility_Collection(DataSet dsCollection)
        {
            return _Bar_Dm_Table_Facility_Service.Update_Bar_Dm_Table_Facility_Collection(dsCollection);
        }

        #endregion

        #region Bar_Dm_Rentlevel
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Bar_Dm_Table")]
        public string Get_All_Bar_Dm_Rentlevel_Collection()
        {
            return _Bar_Dm_Rentlevel_Service.Get_All_Bar_Dm_Rentlevel_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Bar_Dm_Table")]
        public object Update_Bar_Dm_Rentlevel_Collection(DataSet dsCollection)
        {
            return _Bar_Dm_Rentlevel_Service.Update_Bar_Dm_Rentlevel_Collection(dsCollection);
        }

        #endregion


        #endregion

        #region Ware - Webmethod

        #region Ware_Dm_Donvitinh
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Donvitinh")]
        public string Get_All_Ware_Dm_Donvitinh()
        {
            return _Ware_Dm_Donvitinh_Service.Get_All_Ware_Dm_Donvitinh();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Ware_Dm_Donvitinh vào DB.")]
        public object Insert_Ware_Dm_Donvitinh(Ecm.Domain.MasterTables.Ware.Ware_Dm_Donvitinh Ware_Dm_Donvitinh)
        {
            return _Ware_Dm_Donvitinh_Service.Insert_Ware_Dm_Donvitinh(Ware_Dm_Donvitinh);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Ware_Dm_Donvitinh vào DB.")]
        public object Update_Ware_Dm_Donvitinh(Ecm.Domain.MasterTables.Ware.Ware_Dm_Donvitinh Ware_Dm_Donvitinh)
        {
            return _Ware_Dm_Donvitinh_Service.Update_Ware_Dm_Donvitinh(Ware_Dm_Donvitinh);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Ware_Dm_Donvitinh vào DB.")]
        public object Delete_Ware_Dm_Donvitinh(Ecm.Domain.MasterTables.Ware.Ware_Dm_Donvitinh Ware_Dm_Donvitinh)
        {
            return _Ware_Dm_Donvitinh_Service.Delete_Ware_Dm_Donvitinh(Ware_Dm_Donvitinh);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Ware_Dm_Donvitinh vào DB.")]
        public object Update_Ware_Dm_Donvitinh_Collection(DataSet dsCollection)
        {
            return _Ware_Dm_Donvitinh_Service.Update_Ware_Dm_Donvitinh_Collection(dsCollection);
        }
        #endregion

        #region ware_dm_soquy

        [WebMethod(BufferResponse = true, Description = "")]
        public string Ware_Dinhmuc_ByDate(object Ngay_Batdau, object Ngay_Ketthuc)
        {
            return _Ware_Dm_Soquy_Service.Ware_Dinhmuc_ByDate(Ngay_Batdau, Ngay_Ketthuc);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public string GetAll_Ware_Dm_Soquy(object id_cuahang_ban)
        {
            return _Ware_Dm_Soquy_Service.Get_All_Ware_Dm_Soquy(id_cuahang_ban);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public string GetAll_Ware_Dm_Soquy_By_Id_Nhansu(object id_nhansu)
        {
            return _Ware_Dm_Soquy_Service.GetAll_Ware_Dm_Soquy_By_Id_Nhansu(id_nhansu);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection vào DB.")]
        public object Update_Ware_Dm_Soquy_Collection(DataSet dsCollection)
        {
            return _Ware_Dm_Soquy_Service.Update_Ware_Dm_Soquy_Collection(dsCollection);
        }

        #endregion

        #region Ware_Dm_Cuahang_Ban
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Cuahang_Ban")]
        public string Get_All_Ware_Dm_Cuahang_Ban()
        {
            return _Ware_Dm_Cuahang_Ban_Service.Get_All_Ware_Dm_Cuahang_Ban();
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Cuahang_Ban")]
        public string Ware_Dm_Cuahang_Ban_Select_Kho()
        {
            return _Ware_Dm_Cuahang_Ban_Service.Ware_Dm_Cuahang_Ban_Select_Kho();
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Cuahang_Ban")]
        public string Ware_Dm_Cuahang_Ban_Select_Sale()
        {
            return _Ware_Dm_Cuahang_Ban_Service.Ware_Dm_Cuahang_Ban_Select_Sale();
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Cuahang_Ban by Id_Nhansu(Ware_Ql_Cuahang_Ban)")]
        public string Get_All_Ware_Dm_Cuahang_Ban_By_Id_Nhansu(object id_nhansu)
        {
            return _Ware_Dm_Cuahang_Ban_Service.Get_All_Ware_Dm_Cuahang_Ban_By_Id_Nhansu(id_nhansu);
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Ware_Dm_Cuahang_Ban vào DB.")]
        public object Insert_Ware_Dm_Cuahang_Ban(Ecm.Domain.MasterTables.Ware.Ware_Dm_Cuahang_Ban Ware_Dm_Cuahang_Ban)
        {
            return _Ware_Dm_Cuahang_Ban_Service.Insert_Ware_Dm_Cuahang_Ban(Ware_Dm_Cuahang_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Ware_Dm_Cuahang_Ban vào DB.")]
        public object Update_Ware_Dm_Cuahang_Ban(Ecm.Domain.MasterTables.Ware.Ware_Dm_Cuahang_Ban Ware_Dm_Cuahang_Ban)
        {
            return _Ware_Dm_Cuahang_Ban_Service.Update_Ware_Dm_Cuahang_Ban(Ware_Dm_Cuahang_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Ware_Dm_Cuahang_Ban vào DB.")]
        public object Delete_Ware_Dm_Cuahang_Ban(Ecm.Domain.MasterTables.Ware.Ware_Dm_Cuahang_Ban Ware_Dm_Cuahang_Ban)
        {
            return _Ware_Dm_Cuahang_Ban_Service.Delete_Ware_Dm_Cuahang_Ban(Ware_Dm_Cuahang_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Ware_Dm_Cuahang_Ban vào DB.")]
        public object Update_Ware_Dm_Cuahang_Ban_Collection(DataSet dsCollection)
        {
            return _Ware_Dm_Cuahang_Ban_Service.Update_Ware_Dm_Cuahang_Ban_Collection(dsCollection);
        }
        #endregion

        #region Ware_Dm_Hanghoa_Ban

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Hanghoa_Ban")]
        public string Get_All_Ware_Dm_Hanghoa_Ban()
        {
            return _Ware_Dm_Hanghoa_Ban_Service.Get_All_Ware_Dm_Hanghoa_Ban();
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Hanghoa_Ban")]
        public string Get_All_Ware_Dm_Hanghoa_Ban_By_Nguyenlieu_Chebien()
        {
            return _Ware_Dm_Hanghoa_Ban_Service.Get_All_Ware_Dm_Hanghoa_Ban_By_Nguyenlieu_Chebien();
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Hanghoa_Ban với định giá")]
        public string Get_All_Ware_Dm_Hanghoa_Ban_By_Id_Loai_Hanghoa_Ban(object id_loai_hanghoa_ban)
        {
            return _Ware_Dm_Hanghoa_Ban_Service.Get_All_Ware_Dm_Hanghoa_Ban_By_Id_Loai_Hanghoa_Ban(id_loai_hanghoa_ban);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Hanghoa_Ban")]
        public string Get_All_Ware_Dm_Hanghoa_Ban_By_Id_Loai_Hh_Ban_None_Dinhgia(object id_loai_hanghoa_ban, object Ma_Hanghoa_Ban, object Ten_Hanghoa_Ban, object Barcode_Txt)
        {
            return _Ware_Dm_Hanghoa_Ban_Service.Get_All_Ware_Dm_Hanghoa_Ban_By_Id_Loai_Hh_Ban_None_Dinhgia(id_loai_hanghoa_ban, Ma_Hanghoa_Ban, Ten_Hanghoa_Ban, Barcode_Txt);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Hanghoa_Ban By Ma_hanghoa_ban")]
        public string Get_All_Ware_Dm_Hanghoa_Ban_By_Ma_Hanghoa_Ban(object Ma_Hanghoa_Ban)
        {
            return _Ware_Dm_Hanghoa_Ban_Service.Get_All_Ware_Dm_Hanghoa_Ban_By_Ma_Hanghoa_Ban(Ma_Hanghoa_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Hanghoa_Ban By Ten_hanghoa_ban")]
        public string Get_All_Ware_Dm_Hanghoa_Ban_By_Ten_Hanghoa_Ban(object Ten_Hanghoa_Ban)
        {
            return _Ware_Dm_Hanghoa_Ban_Service.Get_All_Ware_Dm_Hanghoa_Ban_By_Ten_Hanghoa_Ban(Ten_Hanghoa_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Hanghoa_Ban By Barcode_Txt")]
        public string Get_All_Ware_Dm_Hanghoa_Ban_By_Barcode_Txt(object Barcode_Txt)
        {
            return _Ware_Dm_Hanghoa_Ban_Service.Get_All_Ware_Dm_Hanghoa_Ban_By_Barcode_Txt(Barcode_Txt);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Hanghoa_Ban")]
        public string Get_All_Ware_Dm_Hanghoa_Ban_By_Id_Cuahang_Ban(object id_cuahang_ban, object ngay_chungtu)
        {
            return _Ware_Dm_Hanghoa_Ban_Service.Get_All_Ware_Dm_Hanghoa_Ban_By_Id_Cuahang_Ban(id_cuahang_ban, ngay_chungtu);
        }
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Hanghoa_Ban")]
        public string Get_All_Ware_Dm_Hanghoa_Ban_InMenu(object ngay_chungtu)
        {
            return _Ware_Dm_Hanghoa_Ban_Service.Get_All_Ware_Dm_Hanghoa_Ban_InMenu(ngay_chungtu);
        }
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Hanghoa_Ban")]
        public string Get_All_Ware_Dm_Hanghoa_Ban_By_Id_Cuahang_Ban_From_Nhap_Hanghoa(object id_cuahang_ban)
        {
            return _Ware_Dm_Hanghoa_Ban_Service.Get_All_Ware_Dm_Hanghoa_Ban_By_Id_Cuahang_Ban_From_Nhap_Hanghoa(id_cuahang_ban);
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Ware_Dm_Hanghoa_Ban vào DB.")]
        public object Insert_Ware_Dm_Hanghoa_Ban(Ecm.Domain.MasterTables.Ware.Ware_Dm_Hanghoa_Ban Ware_Dm_Hanghoa_Ban)
        {
            //RemoveOutputCacheItem
            HttpResponse.RemoveOutputCacheItem("/Ecm.Webservices/MasterService.asmx");

            return _Ware_Dm_Hanghoa_Ban_Service.Insert_Ware_Dm_Hanghoa_Ban(Ware_Dm_Hanghoa_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Ware_Dm_Hanghoa_Ban vào DB.")]
        public object Update_Ware_Dm_Hanghoa_Ban(Ecm.Domain.MasterTables.Ware.Ware_Dm_Hanghoa_Ban Ware_Dm_Hanghoa_Ban)
        {
            //RemoveOutputCacheItem
            HttpResponse.RemoveOutputCacheItem("/Ecm.Webservices/MasterService.asmx");

            return _Ware_Dm_Hanghoa_Ban_Service.Update_Ware_Dm_Hanghoa_Ban(Ware_Dm_Hanghoa_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Ware_Dm_Hanghoa_Ban vào DB.")]
        public object Delete_Ware_Dm_Hanghoa_Ban(Ecm.Domain.MasterTables.Ware.Ware_Dm_Hanghoa_Ban Ware_Dm_Hanghoa_Ban)
        {
            //RemoveOutputCacheItem
            HttpResponse.RemoveOutputCacheItem("/Ecm.Webservices/MasterService.asmx");

            return _Ware_Dm_Hanghoa_Ban_Service.Delete_Ware_Dm_Hanghoa_Ban(Ware_Dm_Hanghoa_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Ware_Dm_Hanghoa_Ban vào DB.")]
        public object Update_Ware_Dm_Hanghoa_Ban_Collection(DataSet dsCollection)
        {
            //RemoveOutputCacheItem
            HttpResponse.RemoveOutputCacheItem("/Ecm.Webservices/MasterService.asmx");

            return _Ware_Dm_Hanghoa_Ban_Service.Update_Ware_Dm_Hanghoa_Ban_Collection(dsCollection);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Hanghoa_Mua")]
        public string Get_All_Ware_Dm_Hanghoa_Ban_Import(string block_no)
        {
            return _Ware_Dm_Hanghoa_Ban_Service.Get_All_Ware_Dm_Hanghoa_Ban_Import(block_no);
        }
        [WebMethod(BufferResponse = true, Description = "Update collection Ware_Dm_Hanghoa_Ban vào DB.")]
        public object Update_Ware_Dm_Hanghoa_Ban_Import_Collection(DataSet dsCollection)
        {
            return _Ware_Dm_Hanghoa_Ban_Service.Update_Ware_Dm_Hanghoa_Ban_Import_Collection(dsCollection);
        }
        [WebMethod(BufferResponse = true, Description = "Update collection Ware_Dm_Hanghoa_Ban vào DB.")]
        public object InsertBatch_Ware_Dm_Hanghoa_Ban_Import(string block_no)
        {
            return _Ware_Dm_Hanghoa_Ban_Service.InsertBatch_Ware_Dm_Hanghoa_Ban_Import(block_no);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Ware_Dm_Hanghoa_Ban vào DB.")]
        public object Ware_Hhban_Quydoi_Hhmua_Init()
        {
            return _Ware_Dm_Hanghoa_Ban_Service.Ware_Hhban_Quydoi_Hhmua_Init();
        }

        [WebMethod(BufferResponse = true, Description = "Trả về 1 dataset đơn vị tính ứng với id_hanghoa_ban .")]
        public string Ware_Dm_Donvitinh_Quydoi_By_Id_Hanghoa_Ban(object Id_Hanghoa_Ban)
        {
            return _Ware_Dm_Hanghoa_Ban_Service.Ware_Dm_Donvitinh_Quydoi_By_Id_Hanghoa_Ban(Id_Hanghoa_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Ware_Dm_Hanghoa_Ban vào DB.")]
        public string Ware_Hhban_Quydoi_Hhmua_SelectAll()
        {
            return _Ware_Dm_Hanghoa_Ban_Service.Ware_Hhban_Quydoi_Hhmua_SelectAll();
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Ware_Dm_Hanghoa_Ban vào DB.")]
        public string Ware_Hhban_Quydoi_Hhmua_SelectByKhhhban(object Id_Kh_Hh_Ban)
        {
            return _Ware_Dm_Hanghoa_Ban_Service.Ware_Hhban_Quydoi_Hhmua_SelectByKhhhban(Id_Kh_Hh_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Ware_Dm_Hanghoa_Ban vào DB.")]
        public string Ware_Hhban_Quydoi_Hhmua_SelectByHhsx(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Cuahang_Ban, object Filter_Cond)
        {
            return _Ware_Dm_Hanghoa_Ban_Service.Ware_Hhban_Quydoi_Hhmua_SelectByHhsx(Ngay_Batdau, Ngay_Ketthuc, Id_Cuahang_Ban, Filter_Cond);
        }
        #endregion

        #region Ware_Dm_Hanghoa_Mua
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Hanghoa_Mua")]
        public string Get_All_Ware_Dm_Hanghoa_Mua()
        {
            return _Ware_Dm_Hanghoa_Mua_Service.Get_All_Ware_Dm_Hanghoa_Mua();
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Hanghoa_Mua by Id_Loai_Hanghoa")]
        public string Get_All_Ware_Dm_Hanghoa_Mua_By_Id_Loai_Hh(object id_Loai_Hanghoa)
        {
            return _Ware_Dm_Hanghoa_Mua_Service.Get_All_Ware_Dm_Hanghoa_Mua_By_Id_Loai_Hh(id_Loai_Hanghoa);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Ware_Dm_Hanghoa_MuaBy_Id_Kho_Hh_Mua")]
        public string Get_All_Ware_Dm_Hanghoa_MuaBy_Id_Kho_Hh_Mua(object id_kho_hanghoa_mua, object ngay_chungtu)
        {
            return _Ware_Dm_Hanghoa_Mua_Service.Get_All_Ware_Dm_Hanghoa_MuaBy_Id_Kho_Hh_Mua(id_kho_hanghoa_mua, ngay_chungtu);
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Ware_Dm_Hanghoa_Mua vào DB.")]
        public object Insert_Ware_Dm_Hanghoa_Mua(Ecm.Domain.MasterTables.Ware.Ware_Dm_Hanghoa_Mua Ware_Dm_Hanghoa_Mua)
        {
            return _Ware_Dm_Hanghoa_Mua_Service.Insert_Ware_Dm_Hanghoa_Mua(Ware_Dm_Hanghoa_Mua);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Ware_Dm_Hanghoa_Mua vào DB.")]
        public object Update_Ware_Dm_Hanghoa_Mua(Ecm.Domain.MasterTables.Ware.Ware_Dm_Hanghoa_Mua Ware_Dm_Hanghoa_Mua)
        {
            return _Ware_Dm_Hanghoa_Mua_Service.Update_Ware_Dm_Hanghoa_Mua(Ware_Dm_Hanghoa_Mua);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Ware_Dm_Hanghoa_Mua vào DB.")]
        public object Delete_Ware_Dm_Hanghoa_Mua(Ecm.Domain.MasterTables.Ware.Ware_Dm_Hanghoa_Mua Ware_Dm_Hanghoa_Mua)
        {
            return _Ware_Dm_Hanghoa_Mua_Service.Delete_Ware_Dm_Hanghoa_Mua(Ware_Dm_Hanghoa_Mua);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Ware_Dm_Hanghoa_Mua vào DB.")]
        public object Update_Ware_Dm_Hanghoa_Mua_Collection(DataSet dsCollection)
        {
            return _Ware_Dm_Hanghoa_Mua_Service.Update_Ware_Dm_Hanghoa_Mua_Collection(dsCollection);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Hanghoa_Mua")]
        public string Get_All_Ware_Dm_Hanghoa_Mua_Import(string block_no)
        {
            return _Ware_Dm_Hanghoa_Mua_Service.Get_All_Ware_Dm_Hanghoa_Mua_Import(block_no);
        }
        [WebMethod(BufferResponse = true, Description = "Update collection Ware_Dm_Hanghoa_Mua vào DB.")]
        public object Update_Ware_Dm_Hanghoa_Mua_Import_Collection(DataSet dsCollection)
        {
            return _Ware_Dm_Hanghoa_Mua_Service.Update_Ware_Dm_Hanghoa_Mua_Import_Collection(dsCollection);
        }
        [WebMethod(BufferResponse = true, Description = "Update collection Ware_Dm_Hanghoa_Mua vào DB.")]
        public object InsertBatch_Ware_Dm_Hanghoa_Mua_Import(string block_no)
        {
            return _Ware_Dm_Hanghoa_Mua_Service.InsertBatch_Ware_Dm_Hanghoa_Mua_Import(block_no);
        }
        #endregion

        #region Ware_Dm_Loai_Hanghoa_Ban
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Loai_Hanghoa_Ban")]
        public string Get_All_Ware_Dm_Loai_Hanghoa_Ban()
        {
            return _Ware_Dm_Loai_Hanghoa_Ban_Service.Get_All_Ware_Dm_Loai_Hanghoa_Ban();
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Loai_Hanghoa_Ban_By_Id_Cuahang_Ban")]
        public string Ware_Dm_Loai_Hanghoa_Ban_SelectBy_Id_Phanloai_HHban(object Id_Phanloai_Nhom_Hanghoa_Ban)
        {
            return _Ware_Dm_Loai_Hanghoa_Ban_Service.Ware_Dm_Loai_Hanghoa_Ban_SelectBy_Id_Phanloai_HHban(Id_Phanloai_Nhom_Hanghoa_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Loai_Hanghoa_Ban_By_Id_Cuahang_Ban")]
        public string Get_All_Ware_Dm_Loai_Hanghoa_Ban_SelectBy_Id_Cuahang_Ban(object id_cuahang_ban)
        {
            return _Ware_Dm_Loai_Hanghoa_Ban_Service.Get_All_Ware_Dm_Loai_Hanghoa_Ban_SelectBy_Id_Cuahang_Ban(id_cuahang_ban);
        }

        [WebMethod]
        public string Ware_Dm_Loai_Hanghoa_Ban_SelectBy_Id_Nhansu(object id_nhansu)
        {
            return _Ware_Dm_Loai_Hanghoa_Ban_Service.Ware_Dm_Loai_Hanghoa_Ban_SelectBy_Id_Nhansu(id_nhansu);
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Ware_Dm_Loai_Hanghoa_Ban vào DB.")]
        public object Insert_Ware_Dm_Loai_Hanghoa_Ban(Ecm.Domain.MasterTables.Ware.Ware_Dm_Loai_Hanghoa_Ban Ware_Dm_Loai_Hanghoa_Ban)
        {
            return _Ware_Dm_Loai_Hanghoa_Ban_Service.Insert_Ware_Dm_Loai_Hanghoa_Ban(Ware_Dm_Loai_Hanghoa_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Ware_Dm_Loai_Hanghoa_Ban vào DB.")]
        public object Update_Ware_Dm_Loai_Hanghoa_Ban(Ecm.Domain.MasterTables.Ware.Ware_Dm_Loai_Hanghoa_Ban Ware_Dm_Loai_Hanghoa_Ban)
        {
            return _Ware_Dm_Loai_Hanghoa_Ban_Service.Update_Ware_Dm_Loai_Hanghoa_Ban(Ware_Dm_Loai_Hanghoa_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Ware_Dm_Loai_Hanghoa_Ban vào DB.")]
        public object Delete_Ware_Dm_Loai_Hanghoa_Ban(Ecm.Domain.MasterTables.Ware.Ware_Dm_Loai_Hanghoa_Ban Ware_Dm_Loai_Hanghoa_Ban)
        {
            return _Ware_Dm_Loai_Hanghoa_Ban_Service.Delete_Ware_Dm_Loai_Hanghoa_Ban(Ware_Dm_Loai_Hanghoa_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Ware_Dm_Loai_Hanghoa_Ban vào DB.")]
        public object Update_Ware_Dm_Loai_Hanghoa_Ban_Collection(DataSet dsCollection)
        {
            return _Ware_Dm_Loai_Hanghoa_Ban_Service.Update_Ware_Dm_Loai_Hanghoa_Ban_Collection(dsCollection);
        }

        [WebMethod(BufferResponse = true, Description = "update lại Id_Loai_hanghoa by Id_Cuahang.")]
        public object Update_Ware_Dm_Loai_Hanghoa_By_Id_Cuahang(object Id_Cuahang_Ban)
        {
            return _Ware_Dm_Loai_Hanghoa_Ban_Service.Update_Ware_Dm_Loai_Hanghoa_By_Id_Cuahang(Id_Cuahang_Ban);
        }

        #endregion

        #region Ware_Dm_Loai_Hanghoa_Mua
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Loai_Hanghoa_Mua")]
        public string Get_All_Ware_Dm_Loai_Hanghoa_Mua()
        {
            return _Ware_Dm_Loai_Hanghoa_Mua_Service.Get_All_Ware_Dm_Loai_Hanghoa_Mua();
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Loai_Hanghoa_Mua by id kho hh mua")]
        public string Get_All_Ware_Dm_Loai_Hanghoa_Mua_SelectBy_Id_Kho_HH_Mua(object id_Kho_Hh_Mua)
        {
            return _Ware_Dm_Loai_Hanghoa_Mua_Service.Get_All_Ware_Dm_Loai_Hanghoa_Mua_SelectBy_Id_Kho_HH_Mua(id_Kho_Hh_Mua);
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Ware_Dm_Loai_Hanghoa_Mua vào DB.")]
        public object Insert_Ware_Dm_Loai_Hanghoa_Mua(Ecm.Domain.MasterTables.Ware.Ware_Dm_Loai_Hanghoa_Mua Ware_Dm_Loai_Hanghoa_Mua)
        {
            return _Ware_Dm_Loai_Hanghoa_Mua_Service.Insert_Ware_Dm_Loai_Hanghoa_Mua(Ware_Dm_Loai_Hanghoa_Mua);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Ware_Dm_Loai_Hanghoa_Mua vào DB.")]
        public object Update_Ware_Dm_Loai_Hanghoa_Mua(Ecm.Domain.MasterTables.Ware.Ware_Dm_Loai_Hanghoa_Mua Ware_Dm_Loai_Hanghoa_Mua)
        {
            return _Ware_Dm_Loai_Hanghoa_Mua_Service.Update_Ware_Dm_Loai_Hanghoa_Mua(Ware_Dm_Loai_Hanghoa_Mua);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Ware_Dm_Loai_Hanghoa_Mua vào DB.")]
        public object Delete_Ware_Dm_Loai_Hanghoa_Mua(Ecm.Domain.MasterTables.Ware.Ware_Dm_Loai_Hanghoa_Mua Ware_Dm_Loai_Hanghoa_Mua)
        {
            return _Ware_Dm_Loai_Hanghoa_Mua_Service.Delete_Ware_Dm_Loai_Hanghoa_Mua(Ware_Dm_Loai_Hanghoa_Mua);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Ware_Dm_Loai_Hanghoa_Mua vào DB.")]
        public object Update_Ware_Dm_Loai_Hanghoa_Mua_Collection(DataSet dsCollection)
        {
            return _Ware_Dm_Loai_Hanghoa_Mua_Service.Update_Ware_Dm_Loai_Hanghoa_Mua_Collection(dsCollection);
        }
        #endregion

        #region Ware_Dm_Nhom_Hanghoa_Ban
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Nhom_Hanghoa_Ban")]
        public string Get_All_Ware_Dm_Nhom_Hanghoa_Ban()
        {
            return _Ware_Dm_Nhom_Hanghoa_Ban_Service.Get_All_Ware_Dm_Nhom_Hanghoa_Ban();
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Nhom_Hanghoa_Ban")]
        public string Get_All_Ware_Dm_Nhom_Hanghoa_Ban_ByBarMenu()
        {
            return _Ware_Dm_Nhom_Hanghoa_Ban_Service.Get_All_Ware_Dm_Nhom_Hanghoa_Ban_ByBarMenu();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Ware_Dm_Nhom_Hanghoa_Ban vào DB.")]
        public object Insert_Ware_Dm_Nhom_Hanghoa_Ban(Ecm.Domain.MasterTables.Ware.Ware_Dm_Nhom_Hanghoa_Ban Ware_Dm_Nhom_Hanghoa_Ban)
        {
            return _Ware_Dm_Nhom_Hanghoa_Ban_Service.Insert_Ware_Dm_Nhom_Hanghoa_Ban(Ware_Dm_Nhom_Hanghoa_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Ware_Dm_Nhom_Hanghoa_Ban vào DB.")]
        public object Update_Ware_Dm_Nhom_Hanghoa_Ban(Ecm.Domain.MasterTables.Ware.Ware_Dm_Nhom_Hanghoa_Ban Ware_Dm_Nhom_Hanghoa_Ban)
        {
            return _Ware_Dm_Nhom_Hanghoa_Ban_Service.Update_Ware_Dm_Nhom_Hanghoa_Ban(Ware_Dm_Nhom_Hanghoa_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Ware_Dm_Nhom_Hanghoa_Ban vào DB.")]
        public object Delete_Ware_Dm_Nhom_Hanghoa_Ban(Ecm.Domain.MasterTables.Ware.Ware_Dm_Nhom_Hanghoa_Ban Ware_Dm_Nhom_Hanghoa_Ban)
        {
            return _Ware_Dm_Nhom_Hanghoa_Ban_Service.Delete_Ware_Dm_Nhom_Hanghoa_Ban(Ware_Dm_Nhom_Hanghoa_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Ware_Dm_Nhom_Hanghoa_Ban vào DB.")]
        public object Update_Ware_Dm_Nhom_Hanghoa_Ban_Collection(DataSet dsCollection)
        {
            return _Ware_Dm_Nhom_Hanghoa_Ban_Service.Update_Ware_Dm_Nhom_Hanghoa_Ban_Collection(dsCollection);
        }

        #endregion

        #region ware_dm_phanloai_nhom_hanghoa_ban

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset ware_dm_phanloai_nhom_hanghoa_ban")]
        public string Get_All_Ware_Dm_Phanloai_Nhom_Hanghoa_Ban()
        {
            return _Ware_Dm_Phanloai_Nhom_Hanghoa_Ban_Service.Get_All_Ware_Dm_Phanloai_Nhom_Hanghoa_Ban();
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset ware_dm_phanloai_nhom_hanghoa_ban")]
        public string Get_All_Ware_Dm_Phanloai_Nhom_Hanghoa_Ban_Nxt(object Bc_Nxt)
        {
            return _Ware_Dm_Phanloai_Nhom_Hanghoa_Ban_Service.Get_All_Ware_Dm_Phanloai_Nhom_Hanghoa_Ban_Nxt(Bc_Nxt);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection ware_dm_phanloai_nhom_hanghoa_ban vào DB.")]
        public object Update_Ware_Dm_Phanloai_Nhom_Hanghoa_Ban_Collection(DataSet dsCollection)
        {
            return _Ware_Dm_Phanloai_Nhom_Hanghoa_Ban_Service.Update_Ware_Dm_Phanloai_Nhom_Hanghoa_Ban_Collection(dsCollection);
        }

        #endregion


        #region Ware_Dm_Nhom_Hanghoa_Mua
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Nhom_Hanghoa_Mua")]
        public string Get_All_Ware_Dm_Nhom_Hanghoa_Mua()
        {
            return _Ware_Dm_Nhom_Hanghoa_Mua_Service.Get_All_Ware_Dm_Nhom_Hanghoa_Mua();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Ware_Dm_Nhom_Hanghoa_Mua vào DB.")]
        public object Insert_Ware_Dm_Nhom_Hanghoa_Mua(Ecm.Domain.MasterTables.Ware.Ware_Dm_Nhom_Hanghoa_Mua Ware_Dm_Nhom_Hanghoa_Mua)
        {
            return _Ware_Dm_Nhom_Hanghoa_Mua_Service.Insert_Ware_Dm_Nhom_Hanghoa_Mua(Ware_Dm_Nhom_Hanghoa_Mua);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Ware_Dm_Nhom_Hanghoa_Mua vào DB.")]
        public object Update_Ware_Dm_Nhom_Hanghoa_Mua(Ecm.Domain.MasterTables.Ware.Ware_Dm_Nhom_Hanghoa_Mua Ware_Dm_Nhom_Hanghoa_Mua)
        {
            return _Ware_Dm_Nhom_Hanghoa_Mua_Service.Update_Ware_Dm_Nhom_Hanghoa_Mua(Ware_Dm_Nhom_Hanghoa_Mua);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Ware_Dm_Nhom_Hanghoa_Mua vào DB.")]
        public object Delete_Ware_Dm_Nhom_Hanghoa_Mua(Ecm.Domain.MasterTables.Ware.Ware_Dm_Nhom_Hanghoa_Mua Ware_Dm_Nhom_Hanghoa_Mua)
        {
            return _Ware_Dm_Nhom_Hanghoa_Mua_Service.Delete_Ware_Dm_Nhom_Hanghoa_Mua(Ware_Dm_Nhom_Hanghoa_Mua);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Ware_Dm_Nhom_Hanghoa_Mua vào DB.")]
        public object Update_Ware_Dm_Nhom_Hanghoa_Mua_Collection(DataSet dsCollection)
        {
            return _Ware_Dm_Nhom_Hanghoa_Mua_Service.Update_Ware_Dm_Nhom_Hanghoa_Mua_Collection(dsCollection);
        }
        #endregion

        #region Ware_Dm_Nhacungcap
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Ware_Dm_Nhacungcap")]
        public string Get_All_Ware_Dm_Nhacungcap()
        {
            return _Ware_Dm_Nhacungcap_Service.Get_All_Ware_Dm_Nhacungcap();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Ware_Dm_Nhacungcap vào DB")]
        public object Insert_Ware_Dm_Nhacungcap(Ecm.Domain.MasterTables.Ware.Ware_Dm_Nhacungcap Ware_Dm_Nhacungcap)
        {
            return _Ware_Dm_Nhacungcap_Service.Insert_Ware_Dm_Nhacungcap(Ware_Dm_Nhacungcap);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Ware_Dm_Nhacungcap vào DB")]
        public object Update_Ware_Dm_Nhacungcap(Ecm.Domain.MasterTables.Ware.Ware_Dm_Nhacungcap Ware_Dm_Nhacungcap)
        {
            return _Ware_Dm_Nhacungcap_Service.Update_Ware_Dm_Nhacungcap(Ware_Dm_Nhacungcap);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Ware_Dm_Nhacungcap vào DB")]
        public object Delete_Ware_Dm_Nhacungcap(Ecm.Domain.MasterTables.Ware.Ware_Dm_Nhacungcap Ware_Dm_Nhacungcap)
        {
            return _Ware_Dm_Nhacungcap_Service.Delete_Ware_Dm_Nhacungcap(Ware_Dm_Nhacungcap);
        }

        [WebMethod(BufferResponse = true, Description = "Update Collection Ware_Dm_Nhacungcap vào DB")]
        public object Update_Ware_Dm_Nhacungcap_Collection(DataSet dsCollection)
        {
            return _Ware_Dm_Nhacungcap_Service.Update_Ware_Dm_Nhacungcap_Collection(dsCollection);
        }

        #endregion

        #region Ware_Dm_Khachhang


        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Ware_Dm_Khachhang_SelectCongno_By_Idkhachhang")]
        public string Ware_Dm_Khachhang_SelectCongno_ById(object Id_Khachhang)
        {
            return _Ware_Dm_Khachhang_Service.Ware_Dm_Khachhang_SelectCongno_ById(Id_Khachhang);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Ware_Dm_Khachhang")]
        public string Get_All_Ware_Dm_Khachhang()
        {
            return _Ware_Dm_Khachhang_Service.Get_All_Ware_Dm_Khachhang();
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Ware_Dm_Khachhang")]
        public string Ware_Dm_Khachhang_SelectById_Nhansu(object Id_Nhansu, object Id_Cuahang_Ban)
        {
            return _Ware_Dm_Khachhang_Service.Ware_Dm_Khachhang_SelectById_Nhansu(Id_Nhansu, Id_Cuahang_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Ware_Dm_Khachhang")]
        public string Ware_Dm_Khachhang_SelectBy_Khuvuc(object Id_Khuvuc)
        {
            return _Ware_Dm_Khachhang_Service.Ware_Dm_Khachhang_SelectBy_Khuvuc(Id_Khuvuc);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Ware_Dm_Khachhang")]
        public string Ware_Dm_Khachhang_SelectBy_Khuvuc_New(object Id_Khuvuc)
        {
            return _Ware_Dm_Khachhang_Service.Ware_Dm_Khachhang_SelectBy_Khuvuc_New(Id_Khuvuc);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Ware_Dm_Khachhang")]
        public string Ware_Dm_Khachhang_SelectBy_Khuvuc_Id_Nhansu(object Id_Khuvuc, object Id_Nhansu)
        {
            return _Ware_Dm_Khachhang_Service.Ware_Dm_Khachhang_SelectBy_Khuvuc_Id_Nhansu(Id_Khuvuc, Id_Nhansu);
        }

        [WebMethod (BufferResponse = true, Description="Tra ve mot dataset ware_dm_khachhang theo dieu kien nhap")]
        public string Search_Ware_Dm_Khachhang(Ecm.Domain.MasterTables.Ware.Ware_Dm_Khachhang Ware_Dm_Khachhang)
        {
            return _Ware_Dm_Khachhang_Service.Search_Ware_Dm_Khachhang(Ware_Dm_Khachhang);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Ware_Dm_Doituong")]
        public string Get_All_Ware_Dm_Doituong()
        {
            return _Ware_Dm_Khachhang_Service.Get_All_Ware_Dm_Doituong();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Ware_Dm_Khachhang vào DB")]
        public object Insert_Ware_Dm_Khachhang(Ecm.Domain.MasterTables.Ware.Ware_Dm_Khachhang Ware_Dm_Khachhang)
        {
            return _Ware_Dm_Khachhang_Service.Insert_Ware_Dm_Khachhang(Ware_Dm_Khachhang);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Ware_Dm_Khachhang vào DB")]
        public object Update_Ware_Dm_Khachhang(Ecm.Domain.MasterTables.Ware.Ware_Dm_Khachhang Ware_Dm_Khachhang)
        {
            return _Ware_Dm_Khachhang_Service.Update_Ware_Dm_Khachhang(Ware_Dm_Khachhang);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Ware_Dm_Khachhang vào DB")]
        public object Delete_Ware_Dm_Khachhang(Ecm.Domain.MasterTables.Ware.Ware_Dm_Khachhang Ware_Dm_Khachhang)
        {
            return _Ware_Dm_Khachhang_Service.Delete_Ware_Dm_Khachhang(Ware_Dm_Khachhang);
        }


        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Ware_Dm_Khachhang vào DB")]
        public object CheckDelete_Ware_Dm_Khachhang(object id_khachhang)
        {
            return _Ware_Dm_Khachhang_Service.CheckDelete_Ware_Dm_Khachhang(id_khachhang);
        }

        [WebMethod(BufferResponse = true, Description = "Update Collection Ware_Dm_Khachhang vào DB")]
        public object Update_Ware_Dm_Khachhang_Collection(DataSet dsCollection)
        {
            return _Ware_Dm_Khachhang_Service.Update_Ware_Dm_Khachhang_Collection(dsCollection);
        }

        [WebMethod(BufferResponse = true, Description = "Update Collection Ware_Dm_Khachhang vào DB")]
        public object Update_Ware_Dm_Khachhang_Collection2(DataSet dsCollection)
        {
            return _Ware_Dm_Khachhang_Service.Update_Ware_Dm_Khachhang_Collection2(dsCollection);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public object Update_Ware_Dm_Khachhang_Nhansu_Collection(DataSet dsCollection)
        {
            return _Ware_Dm_Khachhang_Service.Update_Ware_Dm_Khachhang_Nhansu_Collection(dsCollection);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public string Ware_Dm_Khachhang_Nhansu_SelectAll()
        {
            return _Ware_Dm_Khachhang_Service.Ware_Dm_Khachhang_Nhansu_SelectAll();
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public string Ware_Dm_Khachhang_LJoinNhansu()
        {
            return _Ware_Dm_Khachhang_Service.Ware_Dm_Khachhang_LJoinNhansu();
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public object Ware_Dm_Khachhang_Nhansu_SelectChietkhau(object Id_Khachhang)
        {
            return _Ware_Dm_Khachhang_Service.Ware_Dm_Khachhang_Nhansu_SelectChietkhau(Id_Khachhang);
        }

        #endregion

        #region Ware_Khachhang_Quota
        [WebMethod]
        public object Delete_Ware_Khachhang_Quota(object id_khachhang)
        {
            return _Ware_Dm_Khachhang_Service.Delete_Ware_Khachhang_Quota(id_khachhang);
        }

        #endregion

        #region Ware_Dm_Hanghoa_Ban
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Hanghoa_Ban với định giá")]
        public string Ware_Dm_Hanghoa_Ban_Select_By_Id_Nhansu(object Id_Nhansu)
        {
            return _Ware_Dm_Hanghoa_Ban_Service.Ware_Dm_Hanghoa_Ban_Select_By_Id_Nhansu(Id_Nhansu);
        }
        #endregion

        #region Ware_Dm_Donvitinh_Quydoi

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Donvitinh_Quydoi")]
        public object ware_dm_donvitinh_quydoi_Text(object Id_Hanghoa_Ban, object Id_Donvitinh, object Soluong)
        {
            return _Ware_Dm_Donvitinh_Quydoi_Service.ware_dm_donvitinh_quydoi_Text(Id_Hanghoa_Ban, Id_Donvitinh, Soluong);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Donvitinh_Quydoi")]
        public string Ware_Dm_Donvitinh_Quydoi_By_Id_Hanghoa_Ban_New(object Id_Hanghoa_Ban)
        {
            return _Ware_Dm_Donvitinh_Quydoi_Service.Ware_Dm_Donvitinh_Quydoi_By_Id_Hanghoa_Ban_New(Id_Hanghoa_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Donvitinh_Quydoi")]
        public string Get_All_Ware_Dm_Donvitinh_Quydoi()
        {
            return _Ware_Dm_Donvitinh_Quydoi_Service.Get_All_Ware_Dm_Donvitinh_Quydoi();
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Donvitinh_Quydoi")]
        public string Search_Ware_Dm_Donvitinh_Quydoi(Ecm.Domain.MasterTables.Ware.Ware_Dm_Hanghoa_Ban ware_Dm_Hanghoa_Ban)
        {
            return _Ware_Dm_Donvitinh_Quydoi_Service.Search_Ware_Dm_Donvitinh_Quydoi(ware_Dm_Hanghoa_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Ware_Dm_Donvitinh_Quydoi vào DB.")]
        public object Insert_Ware_Dm_Donvitinh_Quydoi(Ecm.Domain.MasterTables.Ware.Ware_Dm_Donvitinh_Quydoi Ware_Dm_Donvitinh_Quydoi)
        {
            return _Ware_Dm_Donvitinh_Quydoi_Service.Insert_Ware_Dm_Donvitinh_Quydoi(Ware_Dm_Donvitinh_Quydoi);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Ware_Dm_Donvitinh_Quydoi vào DB.")]
        public object Update_Ware_Dm_Donvitinh_Quydoi(Ecm.Domain.MasterTables.Ware.Ware_Dm_Donvitinh_Quydoi Ware_Dm_Donvitinh_Quydoi)
        {
            return _Ware_Dm_Donvitinh_Quydoi_Service.Update_Ware_Dm_Donvitinh_Quydoi(Ware_Dm_Donvitinh_Quydoi);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Ware_Dm_Donvitinh_Quydoi vào DB.")]
        public object Delete_Ware_Dm_Donvitinh_Quydoi(Ecm.Domain.MasterTables.Ware.Ware_Dm_Donvitinh_Quydoi Ware_Dm_Donvitinh_Quydoi)
        {
            return _Ware_Dm_Donvitinh_Quydoi_Service.Delete_Ware_Dm_Donvitinh_Quydoi(Ware_Dm_Donvitinh_Quydoi);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Ware_Dm_Donvitinh_Quydoi vào DB.")]
        public object Update_Ware_Dm_Donvitinh_Quydoi_Collection(DataSet dsCollection)
        {
            return _Ware_Dm_Donvitinh_Quydoi_Service.Update_Ware_Dm_Donvitinh_Quydoi_Collection(dsCollection);
        }
        #endregion
        #region Ware_Dm_Tiente
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Donvitinh_Quydoi")]
        public string Get_All_Ware_Dm_Tiente()
        {
            return _Ware_Dm_Tiente_Service.Get_All_Ware_Dm_Tiente();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Ware_Dm_Tiente vào DB.")]
        public object Insert_Ware_Dm_Tiente(Ecm.Domain.MasterTables.Ware.Ware_Dm_Tiente Ware_Dm_Tiente)
        {
            return _Ware_Dm_Tiente_Service.Insert_Ware_Dm_Tiente(Ware_Dm_Tiente);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Ware_Dm_Tiente vào DB.")]
        public object Update_Ware_Dm_Tiente(Ecm.Domain.MasterTables.Ware.Ware_Dm_Tiente Ware_Dm_Tiente)
        {
            return _Ware_Dm_Tiente_Service.Update_Ware_Dm_Tiente(Ware_Dm_Tiente);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Ware_Dm_Tiente vào DB.")]
        public object Delete_Ware_Dm_Tiente(Ecm.Domain.MasterTables.Ware.Ware_Dm_Tiente Ware_Dm_Tiente)
        {
            return _Ware_Dm_Tiente_Service.Delete_Ware_Dm_Tiente(Ware_Dm_Tiente);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Ware_Dm_Tiente vào DB.")]
        public object Update_Ware_Dm_Tiente_Collection(DataSet dsCollection)
        {
            return _Ware_Dm_Tiente_Service.Update_Ware_Dm_Tiente_Collection(dsCollection);
        }
        #endregion

        #region Ware_Dm_Nganhang
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Nganhang")]
        public string Get_All_Ware_Dm_Nganhang()
        {
            return _Ware_Dm_Nganhang_Service.Get_All_Ware_Dm_Nganhang();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Ware_Dm_Nganhang vào DB.")]
        public object Insert_Ware_Dm_Nganhang(Ecm.Domain.MasterTables.Ware.Ware_Dm_Nganhang Ware_Dm_Nganhang)
        {
            return _Ware_Dm_Nganhang_Service.Insert_Ware_Dm_Nganhang(Ware_Dm_Nganhang);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Ware_Dm_Nganhang vào DB.")]
        public object Update_Ware_Dm_Nganhang(Ecm.Domain.MasterTables.Ware.Ware_Dm_Nganhang Ware_Dm_Nganhang)
        {
            return _Ware_Dm_Nganhang_Service.Update_Ware_Dm_Nganhang(Ware_Dm_Nganhang);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Ware_Dm_Nganhang vào DB.")]
        public object Delete_Ware_Dm_Nganhang(Ecm.Domain.MasterTables.Ware.Ware_Dm_Nganhang Ware_Dm_Nganhang)
        {
            return _Ware_Dm_Nganhang_Service.Delete_Ware_Dm_Nganhang(Ware_Dm_Nganhang);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Ware_Dm_Nganhang vào DB.")]
        public object Update_Ware_Dm_Nganhang_Collection(DataSet dsCollection)
        {
            return _Ware_Dm_Nganhang_Service.Update_Ware_Dm_Nganhang_Collection(dsCollection);
        }
        #endregion

        #region Ware_Dm_Taikhoan_Nganhang
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Taikhoan_Nganhang")]
        public string Get_All_Ware_Dm_Taikhoan_Nganhang()
        {
            return _Ware_Dm_Taikhoan_Nganhang_Service.Get_All_Ware_Dm_Taikhoan_Nganhang();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Ware_Dm_Taikhoan_Nganhang vào DB.")]
        public object Insert_Ware_Dm_Taikhoan_Nganhang(Ecm.Domain.MasterTables.Ware.Ware_Dm_Taikhoan_Nganhang Ware_Dm_Taikhoan_Nganhang)
        {
            return _Ware_Dm_Taikhoan_Nganhang_Service.Insert_Ware_Dm_Taikhoan_Nganhang(Ware_Dm_Taikhoan_Nganhang);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Ware_Dm_Taikhoan_Nganhang vào DB.")]
        public object Update_Ware_Dm_Taikhoan_Nganhang(Ecm.Domain.MasterTables.Ware.Ware_Dm_Taikhoan_Nganhang Ware_Dm_Taikhoan_Nganhang)
        {
            return _Ware_Dm_Taikhoan_Nganhang_Service.Update_Ware_Dm_Taikhoan_Nganhang(Ware_Dm_Taikhoan_Nganhang);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Ware_Dm_Taikhoan_Nganhang vào DB.")]
        public object Delete_Ware_Dm_Taikhoan_Nganhang(Ecm.Domain.MasterTables.Ware.Ware_Dm_Taikhoan_Nganhang Ware_Dm_Taikhoan_Nganhang)
        {
            return _Ware_Dm_Taikhoan_Nganhang_Service.Delete_Ware_Dm_Taikhoan_Nganhang(Ware_Dm_Taikhoan_Nganhang);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Ware_Dm_Taikhoan_Nganhang vào DB.")]
        public object Update_Ware_Dm_Taikhoan_Nganhang_Collection(DataSet dsCollection)
        {
            return _Ware_Dm_Taikhoan_Nganhang_Service.Update_Ware_Dm_Taikhoan_Nganhang_Collection(dsCollection);
        }
        #endregion

        #region Ware_Hanghoa_Service

        [WebMethod(BufferResponse = true, Description = "")]
        public string Ware_Dm_Nguyenlieu_SelectAll()
        {
            return _Ware_Hanghoa_Service.Ware_Dm_Nguyenlieu_SelectAll();
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public string Ware_Dm_Hanghoa_Vat_SelectAll()
        {
            return _Ware_Hanghoa_Service.Ware_Dm_Hanghoa_Vat_SelectAll();
        }

        [WebMethod(BufferResponse = true, Description = "Tra ve ds tat ca hang hoa bao gom hh mua, hh ban")]
        public string Get_All_Ware_Dm_Hanghoa()
        {
            return _Ware_Hanghoa_Service.Get_All_Ware_Dm_Hanghoa();
        }

        [WebMethod(BufferResponse = true, Description = "Tra ve ds tat ca hang hoa bao gom hh mua, hh ban")]
        public string Get_All_Ware_Dm_Hanghoa_Tree(object Bc_Doanhso, object Ma_Hanghoa_Ban, object Ten_Hanghoa_Ban)
        {
            return _Ware_Hanghoa_Service.Get_All_Ware_Dm_Hanghoa_Tree(Bc_Doanhso, Ma_Hanghoa_Ban, Ten_Hanghoa_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "Tra ve ds tat ca hang hoa bao gom hh mua, hh ban")]
        public string Get_All_Ware_Dm_Hanghoa_TreeFull(object Ngay_Chungtu)
        {
            return _Ware_Hanghoa_Service.Get_All_Ware_Dm_Hanghoa_TreeFull(Ngay_Chungtu);
        }

        [WebMethod(BufferResponse = true, Description = "Tra ve ds tat ca loai hang hoa bao gom hh mua, hh ban")]
        public string Get_All_Ware_Dm_Loai_Hanghoa()
        {
            return _Ware_Hanghoa_Service.Get_All_Ware_Dm_Loai_Hanghoa();
        }

        [WebMethod(BufferResponse = true, Description = "Tra ve ds tat ca kho hang hoa bao gom kho hh mua, cua hang hh ban")]
        public string Get_All_Ware_Dm_Kho_Hanghoa()
        {
            return _Ware_Hanghoa_Service.Get_All_Ware_Dm_Kho_Hanghoa();
        }

        //[WebMethod(BufferResponse = true, Description = "Tra ve ds hang hoa da dinh gia")]
        //public string Get_All_Ware_Hanghoa_Dinhgia()
        //{
        //    return _Ware_Hanghoa_Service.Get_All_Ware_Hanghoa_Dinhgia();
        //}

        #endregion

        #region Ware_Dm_Xe_Service

        [WebMethod(BufferResponse = true, Description = "")]
        public string GetAll_Ware_Dm_Xe()
        {
            return _Ware_Dm_Xe_Service.GetAll_Ware_Dm_Xe();
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public object Insert_Ware_Dm_Xe(Ecm.Domain.MasterTables.Ware.Ware_Dm_Xe _Ware_Dm_Xe)
        {
            return _Ware_Dm_Xe_Service.Insert_Ware_Dm_Xe(_Ware_Dm_Xe);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public object Update_Ware_Dm_Xe(Ecm.Domain.MasterTables.Ware.Ware_Dm_Xe _Ware_Dm_Xe)
        {
            return _Ware_Dm_Xe_Service.Update_Ware_Dm_Xe(_Ware_Dm_Xe);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public object Delete_Ware_Dm_Xe(Ecm.Domain.MasterTables.Ware.Ware_Dm_Xe _Ware_Dm_Xe)
        {
            return _Ware_Dm_Xe_Service.Delete_Ware_Dm_Xe(_Ware_Dm_Xe);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection vào DB.")]
        public object Update_Ware_Dm_Xe_Collection(DataSet dsCollection)
        {
            return _Ware_Dm_Xe_Service.Update_Ware_Dm_Xe_Collection(dsCollection);
        }

        #endregion

        #region Ware_Dm_Cap_Service

        [WebMethod(BufferResponse = true, Description = "")]
        public string Ware_Dm_Cap_SelectAll()
        {
            return _Ware_Dm_Cap_Service.Ware_Dm_Cap_SelectAll();
        }

        [WebMethod(BufferResponse = true, Description = "Update collection vào DB.")]
        public object Update_Ware_Dm_Cap_Collection(DataSet dsCollection)
        {
            return _Ware_Dm_Cap_Service.Update_Ware_Dm_Cap_Collection(dsCollection);
        }

        #endregion

        #endregion

        #region Rex - Webmethod
        #region Rex_Dm_Ca_Lamviec
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Ca_Lamviec")]
        public string Get_All_Rex_Dm_Ca_Lamviec()
        {
            return _Rex_Dm_Ca_Lamviec_Service.Get_All_Rex_Dm_Ca_Lamviec();
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Ca_Lamviec by hours")]
        public string Get_All_Rex_Dm_Ca_Lamviec_ByHours(object ngay_gio)
        {
            return _Rex_Dm_Ca_Lamviec_Service.Get_All_Rex_Dm_Ca_Lamviec_ByHours(ngay_gio);
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Rex_Dm_Ca_Lamviec vào DB.")]
        public object Insert_Rex_Dm_Ca_Lamviec(Ecm.Domain.MasterTables.Rex.Rex_Dm_Ca_Lamviec Rex_Dm_Ca_Lamviec)
        {
            return _Rex_Dm_Ca_Lamviec_Service.Insert_Rex_Dm_Ca_Lamviec(Rex_Dm_Ca_Lamviec);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Rex_Dm_Ca_Lamviec vào DB.")]
        public object Update_Rex_Dm_Ca_Lamviec(Ecm.Domain.MasterTables.Rex.Rex_Dm_Ca_Lamviec Rex_Dm_Ca_Lamviec)
        {
            return _Rex_Dm_Ca_Lamviec_Service.Update_Rex_Dm_Ca_Lamviec(Rex_Dm_Ca_Lamviec);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Rex_Dm_Ca_Lamviec vào DB.")]
        public object Delete_Rex_Dm_Ca_Lamviec(Ecm.Domain.MasterTables.Rex.Rex_Dm_Ca_Lamviec Rex_Dm_Ca_Lamviec)
        {
            return _Rex_Dm_Ca_Lamviec_Service.Delete_Rex_Dm_Ca_Lamviec(Rex_Dm_Ca_Lamviec);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Rex_Dm_Ca_Lamviec vào DB.")]
        public object Update_Rex_Dm_Ca_Lamviec_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Ca_Lamviec_Service.Update_Rex_Dm_Ca_Lamviec_Collection(dsCollection);
        }
        #endregion

        #region Rex_Dm_Bophan
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Bophan")]
        public string Get_All_Rex_Dm_Bophan_Collection()
        {
            return _Rex_Dm_Bophan_Service.Get_All_Rex_Dm_Bophan_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Dm_Bophan vào DB.")]
        public object Insert_Rex_Dm_Bophan(Ecm.Domain.MasterTables.Rex.Rex_Dm_Bophan Rex_Dm_Bophan)
        {
            return _Rex_Dm_Bophan_Service.Insert_Rex_Dm_Bophan(Rex_Dm_Bophan);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Dm_Bophan vào DB.")]
        public object Update_Rex_Dm_Bophan(Ecm.Domain.MasterTables.Rex.Rex_Dm_Bophan Rex_Dm_Bophan)
        {
            return _Rex_Dm_Bophan_Service.Update_Rex_Dm_Bophan(Rex_Dm_Bophan);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Dm_Bophan vào DB.")]
        public object Delete_Rex_Dm_Bophan(Ecm.Domain.MasterTables.Rex.Rex_Dm_Bophan Rex_Dm_Bophan)
        {
            return _Rex_Dm_Bophan_Service.Delete_Rex_Dm_Bophan(Rex_Dm_Bophan);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Dm_Bophan vào DB.")]
        public object Update_Rex_Dm_Bophan_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Bophan_Service.Update_Rex_Dm_Bophan_Collection(dsCollection);
        }
        #endregion

        #region Rex_Dm_Dantoc
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Dantoc")]
        public string Get_All_Rex_Dm_Dantoc_Collection()
        {
            return _Rex_Dm_Dantoc_Service.Get_All_Rex_Dm_Dantoc_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Dm_Dantoc vào DB.")]
        public object Insert_Rex_Dm_Dantoc(Ecm.Domain.MasterTables.Rex.Rex_Dm_Dantoc Rex_Dm_Dantoc)
        {
            return _Rex_Dm_Dantoc_Service.Insert_Rex_Dm_Dantoc(Rex_Dm_Dantoc);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Dm_Dantoc vào DB.")]
        public object Update_Rex_Dm_Dantoc(Ecm.Domain.MasterTables.Rex.Rex_Dm_Dantoc Rex_Dm_Dantoc)
        {
            return _Rex_Dm_Dantoc_Service.Update_Rex_Dm_Dantoc(Rex_Dm_Dantoc);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Dm_Dantoc vào DB.")]
        public object Delete_Rex_Dm_Dantoc(Ecm.Domain.MasterTables.Rex.Rex_Dm_Dantoc Rex_Dm_Dantoc)
        {
            return _Rex_Dm_Dantoc_Service.Delete_Rex_Dm_Dantoc(Rex_Dm_Dantoc);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Dm_Dantoc vào DB.")]
        public object Update_Rex_Dm_Dantoc_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Dantoc_Service.Update_Rex_Dm_Dantoc_Collection(dsCollection);
        }
        #endregion

        #region Rex_Dm_Honnhan
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Honnhan")]
        public string Get_All_Rex_Dm_Honnhan_Collection()
        {
            return _Rex_Dm_Honnhan_Service.Get_All_Rex_Dm_Honnhan_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Dm_Honnhan vào DB.")]
        public object Insert_Rex_Dm_Honnhan(Ecm.Domain.MasterTables.Rex.Rex_Dm_Honnhan Rex_Dm_Honnhan)
        {
            return _Rex_Dm_Honnhan_Service.Insert_Rex_Dm_Honnhan(Rex_Dm_Honnhan);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Dm_Honnhan vào DB.")]
        public object Update_Rex_Dm_Honnhan(Ecm.Domain.MasterTables.Rex.Rex_Dm_Honnhan Rex_Dm_Honnhan)
        {
            return _Rex_Dm_Honnhan_Service.Update_Rex_Dm_Honnhan(Rex_Dm_Honnhan);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Dm_Honnhan vào DB.")]
        public object Delete_Rex_Dm_Honnhan(Ecm.Domain.MasterTables.Rex.Rex_Dm_Honnhan Rex_Dm_Honnhan)
        {
            return _Rex_Dm_Honnhan_Service.Delete_Rex_Dm_Honnhan(Rex_Dm_Honnhan);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Dm_Honnhan vào DB.")]
        public object Update_Rex_Dm_Honnhan_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Honnhan_Service.Update_Rex_Dm_Honnhan_Collection(dsCollection);
        }
        #endregion

        #region Rex_Dm_Quocgia
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Quocgia")]
        public string Get_All_Rex_Dm_Quocgia_Collection()
        {
            return _Rex_Dm_Quocgia_Service.Get_All_Rex_Dm_Quocgia_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Dm_Quocgia vào DB.")]
        public object Insert_Rex_Dm_Quocgia(Ecm.Domain.MasterTables.Rex.Rex_Dm_Quocgia Rex_Dm_Quocgia)
        {
            return _Rex_Dm_Quocgia_Service.Insert_Rex_Dm_Quocgia(Rex_Dm_Quocgia);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Dm_Quocgia vào DB.")]
        public object Update_Rex_Dm_Quocgia(Ecm.Domain.MasterTables.Rex.Rex_Dm_Quocgia Rex_Dm_Quocgia)
        {
            return _Rex_Dm_Quocgia_Service.Update_Rex_Dm_Quocgia(Rex_Dm_Quocgia);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Dm_Quocgia vào DB.")]
        public object Delete_Rex_Dm_Quocgia(Ecm.Domain.MasterTables.Rex.Rex_Dm_Quocgia Rex_Dm_Quocgia)
        {
            return _Rex_Dm_Quocgia_Service.Delete_Rex_Dm_Quocgia(Rex_Dm_Quocgia);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Dm_Quocgia vào DB.")]
        public object Update_Rex_Dm_Quocgia_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Quocgia_Service.Update_Rex_Dm_Quocgia_Collection(dsCollection);
        }
        #endregion

        #region Rex_Dm_Tinh
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Tinh")]
        public string Get_All_Rex_Dm_Tinh_Collection()
        {
            return _Rex_Dm_Tinh_Service.Get_All_Rex_Dm_Tinh_Collection();
        }
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Tinh")]
        public string Get_All_Rex_Dm_Tinh_With_Tenquocgia_Collection()
        {
            return _Rex_Dm_Tinh_Service.Get_All_Rex_Dm_Tinh_With_Tenquocgia_Collection();
        }
        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Dm_Tinh vào DB.")]
        public object Insert_Rex_Dm_Tinh(Ecm.Domain.MasterTables.Rex.Rex_Dm_Tinh Rex_Dm_Tinh)
        {
            return _Rex_Dm_Tinh_Service.Insert_Rex_Dm_Tinh(Rex_Dm_Tinh);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Dm_Tinh vào DB.")]
        public object Update_Rex_Dm_Tinh(Ecm.Domain.MasterTables.Rex.Rex_Dm_Tinh Rex_Dm_Tinh)
        {
            return _Rex_Dm_Tinh_Service.Update_Rex_Dm_Tinh(Rex_Dm_Tinh);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Dm_Tinh vào DB.")]
        public object Delete_Rex_Dm_Tinh(Ecm.Domain.MasterTables.Rex.Rex_Dm_Tinh Rex_Dm_Tinh)
        {
            return _Rex_Dm_Tinh_Service.Delete_Rex_Dm_Tinh(Rex_Dm_Tinh);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Dm_Tinh vào DB.")]
        public object Update_Rex_Dm_Tinh_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Tinh_Service.Update_Rex_Dm_Tinh_Collection(dsCollection);
        }

        #endregion

        #region Rex_Dm_Huyen
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Huyen")]
        public string Get_All_Rex_Dm_Huyen_Collection()
        {
            return _Rex_Dm_Huyen_Service.Get_All_Rex_Dm_Huyen_Collection();
        }
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Huyen co them Ten Tinh")]
        public string Get_All_Rex_Dm_Huyen_With_Tentinh_Collection()
        {
            return _Rex_Dm_Huyen_Service.Get_All_Rex_Dm_Huyen_With_Tentinh_Collection();
        }
        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Dm_Huyen vào DB.")]
        public object Insert_Rex_Dm_Huyen(Ecm.Domain.MasterTables.Rex.Rex_Dm_Huyen Rex_Dm_Huyen)
        {
            return _Rex_Dm_Huyen_Service.Insert_Rex_Dm_Huyen(Rex_Dm_Huyen);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Dm_Huyen vào DB.")]
        public object Update_Rex_Dm_Huyen(Ecm.Domain.MasterTables.Rex.Rex_Dm_Huyen Rex_Dm_Huyen)
        {
            return _Rex_Dm_Huyen_Service.Update_Rex_Dm_Huyen(Rex_Dm_Huyen);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Dm_Huyen vào DB.")]
        public object Delete_Rex_Dm_Huyen(Ecm.Domain.MasterTables.Rex.Rex_Dm_Huyen Rex_Dm_Huyen)
        {
            return _Rex_Dm_Huyen_Service.Delete_Rex_Dm_Huyen(Rex_Dm_Huyen);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Dm_Huyen vào DB.")]
        public object Update_Rex_Dm_Huyen_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Huyen_Service.Update_Rex_Dm_Huyen_Collection(dsCollection);
        }

        #endregion

        #region Rex_Dm_Xa
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Xa")]
        public string Get_All_Rex_Dm_Xa_Collection()
        {
            return _Rex_Dm_Xa_Service.Get_All_Rex_Dm_Xa_Collection();
        }
        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Dm_Xa vào DB.")]
        public object Insert_Rex_Dm_Xa(Ecm.Domain.MasterTables.Rex.Rex_Dm_Xa Rex_Dm_Xa)
        {
            return _Rex_Dm_Xa_Service.Insert_Rex_Dm_Xa(Rex_Dm_Xa);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Dm_Xa vào DB.")]
        public object Update_Rex_Dm_Xa(Ecm.Domain.MasterTables.Rex.Rex_Dm_Xa Rex_Dm_Xa)
        {
            return _Rex_Dm_Xa_Service.Update_Rex_Dm_Xa(Rex_Dm_Xa);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Dm_Xa vào DB.")]
        public object Delete_Rex_Dm_Xa(Ecm.Domain.MasterTables.Rex.Rex_Dm_Xa Rex_Dm_Xa)
        {
            return _Rex_Dm_Xa_Service.Delete_Rex_Dm_Xa(Rex_Dm_Xa);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Dm_Xa vào DB.")]
        public object Update_Rex_Dm_Xa_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Xa_Service.Update_Rex_Dm_Xa_Collection(dsCollection);
        }

        #endregion

        #region Rex_Dm_Loai_Ktkl
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Loai_Ktkl")]
        public string Get_All_Rex_Dm_Loai_Ktkl_Collection()
        {
            return _Rex_Dm_Loai_Ktkl_Service.Get_All_Rex_Dm_Loai_Ktkl_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Dm_Loai_Ktkl vào DB.")]
        public object Insert_Rex_Dm_Loai_Ktkl(Ecm.Domain.MasterTables.Rex.Rex_Dm_Loai_Ktkl Rex_Dm_Loai_Ktkl)
        {
            return _Rex_Dm_Loai_Ktkl_Service.Insert_Rex_Dm_Loai_Ktkl(Rex_Dm_Loai_Ktkl);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Dm_Loai_Ktkl vào DB.")]
        public object Update_Rex_Dm_Loai_Ktkl(Ecm.Domain.MasterTables.Rex.Rex_Dm_Loai_Ktkl Rex_Dm_Loai_Ktkl)
        {
            return _Rex_Dm_Loai_Ktkl_Service.Update_Rex_Dm_Loai_Ktkl(Rex_Dm_Loai_Ktkl);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Dm_Loai_Ktkl vào DB.")]
        public object Delete_Rex_Dm_Loai_Ktkl(Ecm.Domain.MasterTables.Rex.Rex_Dm_Loai_Ktkl Rex_Dm_Loai_Ktkl)
        {
            return _Rex_Dm_Loai_Ktkl_Service.Delete_Rex_Dm_Loai_Ktkl(Rex_Dm_Loai_Ktkl);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Dm_Loai_Ktkl vào DB.")]
        public object Update_Rex_Dm_Loai_Ktkl_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Loai_Ktkl_Service.Update_Rex_Dm_Loai_Ktkl_Collection(dsCollection);
        }
        #endregion

        #region Rex_Dm_Loai_Bophan
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Loai_Bophan")]
        public string Get_All_Rex_Dm_Loai_Bophan_Collection()
        {
            return _Rex_Dm_Loai_Bophan_Service.Get_All_Rex_Dm_Loai_Bophan_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Dm_Loai_Bophan vào DB.")]
        public object Insert_Rex_Dm_Loai_Bophan(Ecm.Domain.MasterTables.Rex.Rex_Dm_Loai_Bophan Rex_Dm_Loai_Bophan)
        {
            return _Rex_Dm_Loai_Bophan_Service.Insert_Rex_Dm_Loai_Bophan(Rex_Dm_Loai_Bophan);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Dm_Loai_Bophan vào DB.")]
        public object Update_Rex_Dm_Loai_Bophan(Ecm.Domain.MasterTables.Rex.Rex_Dm_Loai_Bophan Rex_Dm_Loai_Bophan)
        {
            return _Rex_Dm_Loai_Bophan_Service.Update_Rex_Dm_Loai_Bophan(Rex_Dm_Loai_Bophan);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Dm_Loai_Bophan vào DB.")]
        public object Delete_Rex_Dm_Loai_Bophan(Ecm.Domain.MasterTables.Rex.Rex_Dm_Loai_Bophan Rex_Dm_Loai_Bophan)
        {
            return _Rex_Dm_Loai_Bophan_Service.Delete_Rex_Dm_Loai_Bophan(Rex_Dm_Loai_Bophan);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Dm_Loai_Bophan vào DB.")]
        public object Update_Rex_Dm_Loai_Bophan_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Loai_Bophan_Service.Update_Rex_Dm_Loai_Bophan_Collection(dsCollection);
        }
        #endregion

        #region Rex_Dm_Loai_Nghiphep
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Loai_Nghiphep")]
        public string Get_All_Rex_Dm_Loai_Nghiphep_Collection()
        {
            return _Rex_Dm_Loai_Nghiphep_Service.Get_All_Rex_Dm_Loai_Nghiphep_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Dm_Loai_Nghiphep vào DB.")]
        public object Insert_Rex_Dm_Loai_Nghiphep(Ecm.Domain.MasterTables.Rex.Rex_Dm_Loai_Nghiphep Rex_Dm_Loai_Nghiphep)
        {
            return _Rex_Dm_Loai_Nghiphep_Service.Insert_Rex_Dm_Loai_Nghiphep(Rex_Dm_Loai_Nghiphep);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Dm_Loai_Nghiphep vào DB.")]
        public object Update_Rex_Dm_Loai_Nghiphep(Ecm.Domain.MasterTables.Rex.Rex_Dm_Loai_Nghiphep Rex_Dm_Loai_Nghiphep)
        {
            return _Rex_Dm_Loai_Nghiphep_Service.Update_Rex_Dm_Loai_Nghiphep(Rex_Dm_Loai_Nghiphep);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Dm_Loai_Nghiphep vào DB.")]
        public object Delete_Rex_Dm_Loai_Nghiphep(Ecm.Domain.MasterTables.Rex.Rex_Dm_Loai_Nghiphep Rex_Dm_Loai_Nghiphep)
        {
            return _Rex_Dm_Loai_Nghiphep_Service.Delete_Rex_Dm_Loai_Nghiphep(Rex_Dm_Loai_Nghiphep);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Dm_Loai_Nghiphep vào DB.")]
        public object Update_Rex_Dm_Loai_Nghiphep_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Loai_Nghiphep_Service.Update_Rex_Dm_Loai_Nghiphep_Collection(dsCollection);
        }
        #endregion

        #region Rex_Dm_Chungchi
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Chungchi")]
        public string Get_All_Rex_Dm_Chungchi_Collection()
        {
            return _Rex_Dm_Chungchi_Service.Get_All_Rex_Dm_Chungchi_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Dm_Chungchi vào DB.")]
        public object Insert_Rex_Dm_Chungchi(Ecm.Domain.MasterTables.Rex.Rex_Dm_Chungchi Rex_Dm_Chungchi)
        {
            return _Rex_Dm_Chungchi_Service.Insert_Rex_Dm_Chungchi(Rex_Dm_Chungchi);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Dm_Chungchi vào DB.")]
        public object Update_Rex_Dm_Chungchi(Ecm.Domain.MasterTables.Rex.Rex_Dm_Chungchi Rex_Dm_Chungchi)
        {
            return _Rex_Dm_Chungchi_Service.Update_Rex_Dm_Chungchi(Rex_Dm_Chungchi);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Dm_Chungchi vào DB.")]
        public object Delete_Rex_Dm_Chungchi(Ecm.Domain.MasterTables.Rex.Rex_Dm_Chungchi Rex_Dm_Chungchi)
        {
            return _Rex_Dm_Chungchi_Service.Delete_Rex_Dm_Chungchi(Rex_Dm_Chungchi);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Dm_Chungchi vào DB.")]
        public object Update_Rex_Dm_Chungchi_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Chungchi_Service.Update_Rex_Dm_Chungchi_Collection(dsCollection);
        }
        #endregion

        #region Rex_Dm_Tinhoc
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Tinhoc")]
        public string Get_All_Rex_Dm_Tinhoc_Collection()
        {
            return _Rex_Dm_Tinhoc_Service.Get_All_Rex_Dm_Tinhoc_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Dm_Tinhoc vào DB.")]
        public object Insert_Rex_Dm_Tinhoc(Ecm.Domain.MasterTables.Rex.Rex_Dm_Tinhoc Rex_Dm_Tinhoc)
        {
            return _Rex_Dm_Tinhoc_Service.Insert_Rex_Dm_Tinhoc(Rex_Dm_Tinhoc);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Dm_Tinhoc vào DB.")]
        public object Update_Rex_Dm_Tinhoc(Ecm.Domain.MasterTables.Rex.Rex_Dm_Tinhoc Rex_Dm_Tinhoc)
        {
            return _Rex_Dm_Tinhoc_Service.Update_Rex_Dm_Tinhoc(Rex_Dm_Tinhoc);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Dm_Tinhoc vào DB.")]
        public object Delete_Rex_Dm_Tinhoc(Ecm.Domain.MasterTables.Rex.Rex_Dm_Tinhoc Rex_Dm_Tinhoc)
        {
            return _Rex_Dm_Tinhoc_Service.Delete_Rex_Dm_Tinhoc(Rex_Dm_Tinhoc);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Dm_Tinhoc vào DB.")]
        public object Update_Rex_Dm_Tinhoc_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Tinhoc_Service.Update_Rex_Dm_Tinhoc_Collection(dsCollection);
        }
        #endregion

        #region Rex_Dm_Ngoaingu
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Ngoaingu")]
        public string Get_All_Rex_Dm_Ngoaingu_Collection()
        {
            return _Rex_Dm_Ngoaingu_Service.Get_All_Rex_Dm_Ngoaingu_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Dm_Ngoaingu vào DB.")]
        public object Insert_Rex_Dm_Ngoaingu(Ecm.Domain.MasterTables.Rex.Rex_Dm_Ngoaingu Rex_Dm_Ngoaingu)
        {
            return _Rex_Dm_Ngoaingu_Service.Insert_Rex_Dm_Ngoaingu(Rex_Dm_Ngoaingu);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Dm_Ngoaingu vào DB.")]
        public object Update_Rex_Dm_Ngoaingu(Ecm.Domain.MasterTables.Rex.Rex_Dm_Ngoaingu Rex_Dm_Ngoaingu)
        {
            return _Rex_Dm_Ngoaingu_Service.Update_Rex_Dm_Ngoaingu(Rex_Dm_Ngoaingu);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Dm_Ngoaingu vào DB.")]
        public object Delete_Rex_Dm_Ngoaingu(Ecm.Domain.MasterTables.Rex.Rex_Dm_Ngoaingu Rex_Dm_Ngoaingu)
        {
            return _Rex_Dm_Ngoaingu_Service.Delete_Rex_Dm_Ngoaingu(Rex_Dm_Ngoaingu);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Dm_Ngoaingu vào DB.")]
        public object Update_Rex_Dm_Ngoaingu_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Ngoaingu_Service.Update_Rex_Dm_Ngoaingu_Collection(dsCollection);
        }
        #endregion

        #region Rex_Dm_Phuongthuc_Huongluong
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Phuongthuc_Huongluong")]
        public string Get_All_Rex_Dm_Phuongthuc_Huongluong_Collection()
        {
            return _Rex_Dm_Phuongthuc_Huongluong_Service.Get_All_Rex_Dm_Phuongthuc_Huongluong_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Dm_Phuongthuc_Huongluong vào DB.")]
        public object Insert_Rex_Dm_Phuongthuc_Huongluong(Ecm.Domain.MasterTables.Rex.Rex_Dm_Phuongthuc_Huongluong Rex_Dm_Phuongthuc_Huongluong)
        {
            return _Rex_Dm_Phuongthuc_Huongluong_Service.Insert_Rex_Dm_Phuongthuc_Huongluong(Rex_Dm_Phuongthuc_Huongluong);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Dm_Phuongthuc_Huongluong vào DB.")]
        public object Update_Rex_Dm_Phuongthuc_Huongluong(Ecm.Domain.MasterTables.Rex.Rex_Dm_Phuongthuc_Huongluong Rex_Dm_Phuongthuc_Huongluong)
        {
            return _Rex_Dm_Phuongthuc_Huongluong_Service.Update_Rex_Dm_Phuongthuc_Huongluong(Rex_Dm_Phuongthuc_Huongluong);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Dm_Phuongthuc_Huongluong vào DB.")]
        public object Delete_Rex_Dm_Phuongthuc_Huongluong(Ecm.Domain.MasterTables.Rex.Rex_Dm_Phuongthuc_Huongluong Rex_Dm_Phuongthuc_Huongluong)
        {
            return _Rex_Dm_Phuongthuc_Huongluong_Service.Delete_Rex_Dm_Phuongthuc_Huongluong(Rex_Dm_Phuongthuc_Huongluong);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Dm_Phuongthuc_Huongluong vào DB.")]
        public object Update_Rex_Dm_Phuongthuc_Huongluong_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Phuongthuc_Huongluong_Service.Update_Rex_Dm_Phuongthuc_Huongluong_Collection(dsCollection);
        }
        #endregion

        #region Rex_Dm_Khenthuong_Kyluat
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Khenthuong_Kyluat")]
        public string Get_All_Rex_Dm_Khenthuong_Kyluat_Collection()
        {
            return _Rex_Dm_Khenthuong_Kyluat_Service.Get_All_Rex_Dm_Khenthuong_Kyluat_Collection();
        }
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Khenthuong_Kyluat")]
        public string Get_All_Rex_Dm_Khenthuong_Kyluat_With_Ten_Ktkl_Collection()
        {
            return _Rex_Dm_Khenthuong_Kyluat_Service.Get_All_Rex_Dm_Khenthuong_Kyluat_With_Ten_Loai_Ktkl_Collection();
        }
        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Dm_Khenthuong_Kyluat vào DB.")]
        public object Insert_Rex_Dm_Khenthuong_Kyluat(Ecm.Domain.MasterTables.Rex.Rex_Dm_Khenthuong_Kyluat Rex_Dm_Khenthuong_Kyluat)
        {
            return _Rex_Dm_Khenthuong_Kyluat_Service.Insert_Rex_Dm_Khenthuong_Kyluat(Rex_Dm_Khenthuong_Kyluat);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Dm_Khenthuong_Kyluat vào DB.")]
        public object Update_Rex_Dm_Khenthuong_Kyluat(Ecm.Domain.MasterTables.Rex.Rex_Dm_Khenthuong_Kyluat Rex_Dm_Khenthuong_Kyluat)
        {
            return _Rex_Dm_Khenthuong_Kyluat_Service.Update_Rex_Dm_Khenthuong_Kyluat(Rex_Dm_Khenthuong_Kyluat);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Dm_Khenthuong_Kyluat vào DB.")]
        public object Delete_Rex_Dm_Khenthuong_Kyluat(Ecm.Domain.MasterTables.Rex.Rex_Dm_Khenthuong_Kyluat Rex_Dm_Khenthuong_Kyluat)
        {
            return _Rex_Dm_Khenthuong_Kyluat_Service.Delete_Rex_Dm_Khenthuong_Kyluat(Rex_Dm_Khenthuong_Kyluat);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Dm_Khenthuong_Kyluat vào DB.")]
        public object Update_Rex_Dm_Khenthuong_Kyluat_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Khenthuong_Kyluat_Service.Update_Rex_Dm_Khenthuong_Kyluat_Collection(dsCollection);
        }

        #endregion

        #region Rex_Dm_Quanhe_Giadinh
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Quanhe_Giadinh")]
        public string Get_All_Rex_Dm_Quanhe_Giadinh_Collection()
        {
            return _Rex_Dm_Quanhe_Giadinh_Service.Get_All_Rex_Dm_Quanhe_Giadinh_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Dm_Quanhe_Giadinh vào DB.")]
        public object Insert_Rex_Dm_Quanhe_Giadinh(Ecm.Domain.MasterTables.Rex.Rex_Dm_Quanhe_Giadinh Rex_Dm_Quanhe_Giadinh)
        {
            return _Rex_Dm_Quanhe_Giadinh_Service.Insert_Rex_Dm_Quanhe_Giadinh(Rex_Dm_Quanhe_Giadinh);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Dm_Quanhe_Giadinh vào DB.")]
        public object Update_Rex_Dm_Quanhe_Giadinh(Ecm.Domain.MasterTables.Rex.Rex_Dm_Quanhe_Giadinh Rex_Dm_Quanhe_Giadinh)
        {
            return _Rex_Dm_Quanhe_Giadinh_Service.Update_Rex_Dm_Quanhe_Giadinh(Rex_Dm_Quanhe_Giadinh);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Dm_Quanhe_Giadinh vào DB.")]
        public object Delete_Rex_Dm_Quanhe_Giadinh(Ecm.Domain.MasterTables.Rex.Rex_Dm_Quanhe_Giadinh Rex_Dm_Quanhe_Giadinh)
        {
            return _Rex_Dm_Quanhe_Giadinh_Service.Delete_Rex_Dm_Quanhe_Giadinh(Rex_Dm_Quanhe_Giadinh);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Dm_Quanhe_Giadinh vào DB.")]
        public object Update_Rex_Dm_Quanhe_Giadinh_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Quanhe_Giadinh_Service.Update_Rex_Dm_Quanhe_Giadinh_Collection(dsCollection);
        }
        #endregion

        #region Rex_Dm_Tochuc
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Tochuc")]
        public string Get_All_Rex_Dm_Tochuc_Collection()
        {
            return _Rex_Dm_Tochuc_Service.Get_All_Rex_Dm_Tochuc_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Dm_Tochuc vào DB.")]
        public object Insert_Rex_Dm_Tochuc(Ecm.Domain.MasterTables.Rex.Rex_Dm_Tochuc Rex_Dm_Tochuc)
        {
            return _Rex_Dm_Tochuc_Service.Insert_Rex_Dm_Tochuc(Rex_Dm_Tochuc);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Dm_Tochuc vào DB.")]
        public object Update_Rex_Dm_Tochuc(Ecm.Domain.MasterTables.Rex.Rex_Dm_Tochuc Rex_Dm_Tochuc)
        {
            return _Rex_Dm_Tochuc_Service.Update_Rex_Dm_Tochuc(Rex_Dm_Tochuc);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Dm_Tochuc vào DB.")]
        public object Delete_Rex_Dm_Tochuc(Ecm.Domain.MasterTables.Rex.Rex_Dm_Tochuc Rex_Dm_Tochuc)
        {
            return _Rex_Dm_Tochuc_Service.Delete_Rex_Dm_Tochuc(Rex_Dm_Tochuc);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Dm_Tochuc vào DB.")]
        public object Update_Rex_Dm_Tochuc_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Tochuc_Service.Update_Rex_Dm_Tochuc_Collection(dsCollection);
        }
        #endregion

        #region Rex_Dm_Xeploai
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Xeploai")]
        public string Get_All_Rex_Dm_Xeploai_Collection()
        {
            return _Rex_Dm_Xeploai_Service.Get_All_Rex_Dm_Xeploai_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Dm_Xeploai vào DB.")]
        public object Insert_Rex_Dm_Xeploai(Ecm.Domain.MasterTables.Rex.Rex_Dm_Xeploai Rex_Dm_Xeploai)
        {
            return _Rex_Dm_Xeploai_Service.Insert_Rex_Dm_Xeploai(Rex_Dm_Xeploai);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Dm_Xeploai vào DB.")]
        public object Update_Rex_Dm_Xeploai(Ecm.Domain.MasterTables.Rex.Rex_Dm_Xeploai Rex_Dm_Xeploai)
        {
            return _Rex_Dm_Xeploai_Service.Update_Rex_Dm_Xeploai(Rex_Dm_Xeploai);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Dm_Xeploai vào DB.")]
        public object Delete_Rex_Dm_Xeploai(Ecm.Domain.MasterTables.Rex.Rex_Dm_Xeploai Rex_Dm_Xeploai)
        {
            return _Rex_Dm_Xeploai_Service.Delete_Rex_Dm_Xeploai(Rex_Dm_Xeploai);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Dm_Xeploai vào DB.")]
        public object Update_Rex_Dm_Xeploai_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Xeploai_Service.Update_Rex_Dm_Xeploai_Collection(dsCollection);
        }
        #endregion

        #region Rex_Dm_Tongiao
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Tongiao")]
        public string Get_All_Rex_Dm_Tongiao_Collection()
        {
            return _Rex_Dm_Tongiao_Service.Get_All_Rex_Dm_Tongiao_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Dm_Tongiao vào DB.")]
        public object Insert_Rex_Dm_Tongiao(Ecm.Domain.MasterTables.Rex.Rex_Dm_Tongiao Rex_Dm_Tongiao)
        {
            return _Rex_Dm_Tongiao_Service.Insert_Rex_Dm_Tongiao(Rex_Dm_Tongiao);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Dm_Tongiao vào DB.")]
        public object Update_Rex_Dm_Tongiao(Ecm.Domain.MasterTables.Rex.Rex_Dm_Tongiao Rex_Dm_Tongiao)
        {
            return _Rex_Dm_Tongiao_Service.Update_Rex_Dm_Tongiao(Rex_Dm_Tongiao);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Dm_Tongiao vào DB.")]
        public object Delete_Rex_Dm_Tongiao(Ecm.Domain.MasterTables.Rex.Rex_Dm_Tongiao Rex_Dm_Tongiao)
        {
            return _Rex_Dm_Tongiao_Service.Delete_Rex_Dm_Tongiao(Rex_Dm_Tongiao);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Dm_Tongiao vào DB.")]
        public object Update_Rex_Dm_Tongiao_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Tongiao_Service.Update_Rex_Dm_Tongiao_Collection(dsCollection);
        }
        #endregion

        #region Rex_Dm_Tpbanthan
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Tpbanthan")]
        public string Get_All_Rex_Dm_Tpbanthan_Collection()
        {
            return _Rex_Dm_Tpbanthan_Service.Get_All_Rex_Dm_Tpbanthan_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Dm_Tpbanthan vào DB.")]
        public object Insert_Rex_Dm_Tpbanthan(Ecm.Domain.MasterTables.Rex.Rex_Dm_Tpbanthan Rex_Dm_Tpbanthan)
        {
            return _Rex_Dm_Tpbanthan_Service.Insert_Rex_Dm_Tpbanthan(Rex_Dm_Tpbanthan);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Dm_Tpbanthan vào DB.")]
        public object Update_Rex_Dm_Tpbanthan(Ecm.Domain.MasterTables.Rex.Rex_Dm_Tpbanthan Rex_Dm_Tpbanthan)
        {
            return _Rex_Dm_Tpbanthan_Service.Update_Rex_Dm_Tpbanthan(Rex_Dm_Tpbanthan);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Dm_Tpbanthan vào DB.")]
        public object Delete_Rex_Dm_Tpbanthan(Ecm.Domain.MasterTables.Rex.Rex_Dm_Tpbanthan Rex_Dm_Tpbanthan)
        {
            return _Rex_Dm_Tpbanthan_Service.Delete_Rex_Dm_Tpbanthan(Rex_Dm_Tpbanthan);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Dm_Tpbanthan vào DB.")]
        public object Update_Rex_Dm_Tpbanthan_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Tpbanthan_Service.Update_Rex_Dm_Tpbanthan_Collection(dsCollection);
        }
        #endregion

        #region Rex_Dm_Tpgiadinh
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Tpgiadinh")]
        public string Get_All_Rex_Dm_Tpgiadinh_Collection()
        {
            return _Rex_Dm_Tpgiadinh_Service.Get_All_Rex_Dm_Tpgiadinh_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Dm_Tpgiadinh vào DB.")]
        public object Insert_Rex_Dm_Tpgiadinh(Ecm.Domain.MasterTables.Rex.Rex_Dm_Tpgiadinh Rex_Dm_Tpgiadinh)
        {
            return _Rex_Dm_Tpgiadinh_Service.Insert_Rex_Dm_Tpgiadinh(Rex_Dm_Tpgiadinh);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Dm_Tpgiadinh vào DB.")]
        public object Update_Rex_Dm_Tpgiadinh(Ecm.Domain.MasterTables.Rex.Rex_Dm_Tpgiadinh Rex_Dm_Tpgiadinh)
        {
            return _Rex_Dm_Tpgiadinh_Service.Update_Rex_Dm_Tpgiadinh(Rex_Dm_Tpgiadinh);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Dm_Tpgiadinh vào DB.")]
        public object Delete_Rex_Dm_Tpgiadinh(Ecm.Domain.MasterTables.Rex.Rex_Dm_Tpgiadinh Rex_Dm_Tpgiadinh)
        {
            return _Rex_Dm_Tpgiadinh_Service.Delete_Rex_Dm_Tpgiadinh(Rex_Dm_Tpgiadinh);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Dm_Tpgiadinh vào DB.")]
        public object Update_Rex_Dm_Tpgiadinh_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Tpgiadinh_Service.Update_Rex_Dm_Tpgiadinh_Collection(dsCollection);
        }
        #endregion

        #region Rex_Dm_Vanhoa
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Vanhoa")]
        public string Get_All_Rex_Dm_Vanhoa_Collection()
        {
            return _Rex_Dm_Vanhoa_Service.Get_All_Rex_Dm_Vanhoa_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Dm_Vanhoa vào DB.")]
        public object Insert_Rex_Dm_Vanhoa(Ecm.Domain.MasterTables.Rex.Rex_Dm_Vanhoa Rex_Dm_Vanhoa)
        {
            return _Rex_Dm_Vanhoa_Service.Insert_Rex_Dm_Vanhoa(Rex_Dm_Vanhoa);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Dm_Vanhoa vào DB.")]
        public object Update_Rex_Dm_Vanhoa(Ecm.Domain.MasterTables.Rex.Rex_Dm_Vanhoa Rex_Dm_Vanhoa)
        {
            return _Rex_Dm_Vanhoa_Service.Update_Rex_Dm_Vanhoa(Rex_Dm_Vanhoa);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Dm_Vanhoa vào DB.")]
        public object Delete_Rex_Dm_Vanhoa(Ecm.Domain.MasterTables.Rex.Rex_Dm_Vanhoa Rex_Dm_Vanhoa)
        {
            return _Rex_Dm_Vanhoa_Service.Delete_Rex_Dm_Vanhoa(Rex_Dm_Vanhoa);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Dm_Vanhoa vào DB.")]
        public object Update_Rex_Dm_Vanhoa_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Vanhoa_Service.Update_Rex_Dm_Vanhoa_Collection(dsCollection);
        }
        #endregion

        #region Rex_Dm_Chuyenmon
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Chuyenmon")]
        public string Get_All_Rex_Dm_Chuyenmon_Collection()
        {
            return _Rex_Dm_Chuyenmon_Service.Get_All_Rex_Dm_Chuyenmon_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Dm_Chuyenmon vào DB.")]
        public object Insert_Rex_Dm_Chuyenmon(Ecm.Domain.MasterTables.Rex.Rex_Dm_Chuyenmon Rex_Dm_Chuyenmon)
        {
            return _Rex_Dm_Chuyenmon_Service.Insert_Rex_Dm_Chuyenmon(Rex_Dm_Chuyenmon);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Dm_Chuyenmon vào DB.")]
        public object Update_Rex_Dm_Chuyenmon(Ecm.Domain.MasterTables.Rex.Rex_Dm_Chuyenmon Rex_Dm_Chuyenmon)
        {
            return _Rex_Dm_Chuyenmon_Service.Update_Rex_Dm_Chuyenmon(Rex_Dm_Chuyenmon);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Dm_Chuyenmon vào DB.")]
        public object Delete_Rex_Dm_Chuyenmon(Ecm.Domain.MasterTables.Rex.Rex_Dm_Chuyenmon Rex_Dm_Chuyenmon)
        {
            return _Rex_Dm_Chuyenmon_Service.Delete_Rex_Dm_Chuyenmon(Rex_Dm_Chuyenmon);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Dm_Chuyenmon vào DB.")]
        public object Update_Rex_Dm_Chuyenmon_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Chuyenmon_Service.Update_Rex_Dm_Chuyenmon_Collection(dsCollection);
        }
        #endregion

        #region Rex_Dm_Loai_Hopdong
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Loai_Hopdong")]
        public string Get_All_Rex_Dm_Loai_Hopdong_Collection()
        {
            return _Rex_Dm_Loai_Hopdong_Service.Get_All_Rex_Dm_Loai_Hopdong_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Dm_Loai_Hopdong vào DB.")]
        public object Insert_Rex_Dm_Loai_Hopdong(Ecm.Domain.MasterTables.Rex.Rex_Dm_Loai_Hopdong Rex_Dm_Loai_Hopdong)
        {
            return _Rex_Dm_Loai_Hopdong_Service.Insert_Rex_Dm_Loai_Hopdong(Rex_Dm_Loai_Hopdong);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Dm_Loai_Hopdong vào DB.")]
        public object Update_Rex_Dm_Loai_Hopdong(Ecm.Domain.MasterTables.Rex.Rex_Dm_Loai_Hopdong Rex_Dm_Loai_Hopdong)
        {
            return _Rex_Dm_Loai_Hopdong_Service.Update_Rex_Dm_Loai_Hopdong(Rex_Dm_Loai_Hopdong);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Dm_Loai_Hopdong vào DB.")]
        public object Delete_Rex_Dm_Loai_Hopdong(Ecm.Domain.MasterTables.Rex.Rex_Dm_Loai_Hopdong Rex_Dm_Loai_Hopdong)
        {
            return _Rex_Dm_Loai_Hopdong_Service.Delete_Rex_Dm_Loai_Hopdong(Rex_Dm_Loai_Hopdong);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Dm_Loai_Hopdong vào DB.")]
        public object Update_Rex_Dm_Loai_Hopdong_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Loai_Hopdong_Service.Update_Rex_Dm_Loai_Hopdong_Collection(dsCollection);
        }
        #endregion

        #region Rex_Dm_Ngachluong
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Ngachluong")]
        public string Get_All_Rex_Dm_Ngachluong_Collection()
        {
            return _Rex_Dm_Ngachluong_Service.Get_All_Rex_Dm_Ngachluong_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Dm_Ngachluong vào DB.")]
        public object Insert_Rex_Dm_Ngachluong(Ecm.Domain.MasterTables.Rex.Rex_Dm_Ngachluong Rex_Dm_Ngachluong)
        {
            return _Rex_Dm_Ngachluong_Service.Insert_Rex_Dm_Ngachluong(Rex_Dm_Ngachluong);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Dm_Ngachluong vào DB.")]
        public object Update_Rex_Dm_Ngachluong(Ecm.Domain.MasterTables.Rex.Rex_Dm_Ngachluong Rex_Dm_Ngachluong)
        {
            return _Rex_Dm_Ngachluong_Service.Update_Rex_Dm_Ngachluong(Rex_Dm_Ngachluong);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Dm_Ngachluong vào DB.")]
        public object Delete_Rex_Dm_Ngachluong(Ecm.Domain.MasterTables.Rex.Rex_Dm_Ngachluong Rex_Dm_Ngachluong)
        {
            return _Rex_Dm_Ngachluong_Service.Delete_Rex_Dm_Ngachluong(Rex_Dm_Ngachluong);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Dm_Ngachluong vào DB.")]
        public object Update_Rex_Dm_Ngachluong_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Ngachluong_Service.Update_Rex_Dm_Ngachluong_Collection(dsCollection);
        }
        #endregion

        #region Rex_Dm_Bacluong
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Bacluong")]
        public string Get_All_Rex_Dm_Bacluong_Collection()
        {
            return _Rex_Dm_Bacluong_Service.Get_All_Rex_Dm_Bacluong_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Dm_Bacluong vào DB.")]
        public object Insert_Rex_Dm_Bacluong(Ecm.Domain.MasterTables.Rex.Rex_Dm_Bacluong Rex_Dm_Bacluong)
        {
            return _Rex_Dm_Bacluong_Service.Insert_Rex_Dm_Bacluong(Rex_Dm_Bacluong);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Dm_Bacluong vào DB.")]
        public object Update_Rex_Dm_Bacluong(Ecm.Domain.MasterTables.Rex.Rex_Dm_Bacluong Rex_Dm_Bacluong)
        {
            return _Rex_Dm_Bacluong_Service.Update_Rex_Dm_Bacluong(Rex_Dm_Bacluong);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Dm_Bacluong vào DB.")]
        public object Delete_Rex_Dm_Bacluong(Ecm.Domain.MasterTables.Rex.Rex_Dm_Bacluong Rex_Dm_Bacluong)
        {
            return _Rex_Dm_Bacluong_Service.Delete_Rex_Dm_Bacluong(Rex_Dm_Bacluong);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Dm_Bacluong vào DB.")]
        public object Update_Rex_Dm_Bacluong_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Bacluong_Service.Update_Rex_Dm_Bacluong_Collection(dsCollection);
        }
        #endregion

        #region Rex_Dm_Coquan
        [WebMethod(BufferResponse = true, Description = "Select all Rex_Dm_Coquan.")]
        public string Get_All_Rex_Dm_Coquan_Collection()
        {
            return _Rex_Dm_Coquan_Service.Get_All_Rex_Dm_Coquan();
        }

        [WebMethod(BufferResponse = true, Description = "Insert 1 đối tượng Rex_Dm_Coquan vào DB.")]
        public object Insert_Rex_Dm_Coquan(Ecm.Domain.MasterTables.Rex.Rex_Dm_Coquan Rex_Dm_Coquan)
        {
            return _Rex_Dm_Coquan_Service.Insert_Rex_Dm_Coquan(Rex_Dm_Coquan);
        }

        [WebMethod(BufferResponse = true, Description = "Delete Rex_Dm_Coquan.")]
        public object Detele_Rex_Dm_Coquan(Ecm.Domain.MasterTables.Rex.Rex_Dm_Coquan Rex_Dm_Coquan)
        {
            return _Rex_Dm_Coquan_Service.Delete_Rex_Dm_Coquan(Rex_Dm_Coquan);
        }

        [WebMethod(BufferResponse = true, Description = "Update Rex_Dm_Coquan.")]
        public object Update_Rex_Dm_Coquan(Ecm.Domain.MasterTables.Rex.Rex_Dm_Coquan Rex_Dm_Coquan)
        {
            return _Rex_Dm_Coquan_Service.Update_Rex_Dm_Coquan(Rex_Dm_Coquan);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Rex_Dm_Coquan vào DB.")]
        public object Update_Rex_Dm_Coquan_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Coquan_Service.Update_Rex_Dm_Coquan_Collection(dsCollection);
        }

        #endregion

        #region Rex_Dm_Phucap
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Phucap")]
        public string Get_All_Rex_Dm_Phucap_Collection()
        {
            return _Rex_Dm_Phucap_Service.Get_All_Rex_Dm_Phucap_Collection();
        }
        [WebMethod]
        public string Get_All_Rex_Dm_Phucaprieng_Collection()
        {
            return _Rex_Dm_Phucap_Service.Get_All_Rex_Dm_Phucaprieng_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Dm_Phucap vào DB.")]
        public object Insert_Rex_Dm_Phucap(Ecm.Domain.MasterTables.Rex.Rex_Dm_Phucap Rex_Dm_Phucap)
        {
            return _Rex_Dm_Phucap_Service.Insert_Rex_Dm_Phucap(Rex_Dm_Phucap);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Dm_Phucap vào DB.")]
        public object Update_Rex_Dm_Phucap(Ecm.Domain.MasterTables.Rex.Rex_Dm_Phucap Rex_Dm_Phucap)
        {
            return _Rex_Dm_Phucap_Service.Update_Rex_Dm_Phucap(Rex_Dm_Phucap);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Dm_Phucap vào DB.")]
        public object Delete_Rex_Dm_Phucap(Ecm.Domain.MasterTables.Rex.Rex_Dm_Phucap Rex_Dm_Phucap)
        {
            return _Rex_Dm_Phucap_Service.Delete_Rex_Dm_Phucap(Rex_Dm_Phucap);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Dm_Phucap vào DB.")]
        public object Update_Rex_Dm_Phucap_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Phucap_Service.Update_Rex_Dm_Phucap_Collection(dsCollection);
        }
        #endregion

        #region Rex_Dm_Kynang_Chuyenmon


        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Kynang_Chuyenmon")]
        public string Get_All_Rex_Dm_Kynang_Chuyenmon_Collection()
        {
            return _Rex_Dm_Kynang_Chuyenmon_Service.Get_All_Rex_Dm_Kynang_Chuyenmon_Collection();

        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Dm_Kynang_Chuyenmon vào DB.")]
        public object Insert_Rex_Dm_Kynang_Chuyenmon(Ecm.Domain.MasterTables.Rex.Rex_Dm_Kynang_Chuyenmon rex_Dm_Kynang_Chuyenmon)
        {
            return _Rex_Dm_Kynang_Chuyenmon_Service.Insert_Rex_Dm_Kynang_Chuyenmon(rex_Dm_Kynang_Chuyenmon);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Dm_Kynang_Chuyenmon vào DB.")]
        public object Update_Rex_Dm_Kynang_Chuyenmon(Ecm.Domain.MasterTables.Rex.Rex_Dm_Kynang_Chuyenmon rex_Dm_Kynang_Chuyenmon)
        {
            return _Rex_Dm_Kynang_Chuyenmon_Service.Update_Rex_Dm_Kynang_Chuyenmon(rex_Dm_Kynang_Chuyenmon);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Dm_Kynang_Chuyenmon vào DB.")]
        public object Delete_Rex_Dm_Kynang_Chuyenmon(Ecm.Domain.MasterTables.Rex.Rex_Dm_Kynang_Chuyenmon rex_Dm_Kynang_Chuyenmon)
        {
            return _Rex_Dm_Kynang_Chuyenmon_Service.Delete_Rex_Dm_Kynang_Chuyenmon(rex_Dm_Kynang_Chuyenmon);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Dm_Kynang_Chuyenmon vào DB.")]
        public object Update_Rex_Dm_Kynang_Chuyenmon_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Kynang_Chuyenmon_Service.Update_Rex_Dm_Kynang_Chuyenmon_Collection(dsCollection);
        }
        #endregion



        #region Rex_Dm_Chucvu
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Chucvu")]
        public string Get_All_Rex_Dm_Chucvu_Collection()
        {
            return _Rex_Dm_Chucvu_Service.Get_All_Rex_Dm_Chucvu_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Dm_Chucvu vào DB.")]
        public object Insert_Rex_Dm_Chucvu(Ecm.Domain.MasterTables.Rex.Rex_Dm_Chucvu Rex_Dm_Chucvu)
        {
            return _Rex_Dm_Chucvu_Service.Insert_Rex_Dm_Chucvu(Rex_Dm_Chucvu);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Dm_Chucvu vào DB.")]
        public object Update_Rex_Dm_Chucvu(Ecm.Domain.MasterTables.Rex.Rex_Dm_Chucvu Rex_Dm_Chucvu)
        {
            return _Rex_Dm_Chucvu_Service.Update_Rex_Dm_Chucvu(Rex_Dm_Chucvu);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Dm_Chucvu vào DB.")]
        public object Delete_Rex_Dm_Chucvu(Ecm.Domain.MasterTables.Rex.Rex_Dm_Chucvu Rex_Dm_Chucvu)
        {
            return _Rex_Dm_Chucvu_Service.Delete_Rex_Dm_Chucvu(Rex_Dm_Chucvu);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Dm_Chucvu vào DB.")]
        public object Update_Rex_Dm_Chucvu_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Chucvu_Service.Update_Rex_Dm_Chucvu_Collection(dsCollection);
        }
        #endregion

        #region Rex_Dm_Ngaynghi
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Ngaynghi")]
        public string Get_All_Rex_Dm_Ngaynghi_Collection()
        {
            return _Rex_Dm_Ngaynghi_Service.Get_All_Rex_Dm_Ngaynghi_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Dm_Ngaynghi vào DB.")]
        public object Insert_Rex_Dm_Ngaynghi(Ecm.Domain.MasterTables.Rex.Rex_Dm_Ngaynghi Rex_Dm_Ngaynghi)
        {
            return _Rex_Dm_Ngaynghi_Service.Insert_Rex_Dm_Ngaynghi(Rex_Dm_Ngaynghi);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Dm_Ngaynghi vào DB.")]
        public object Update_Rex_Dm_Ngaynghi(Ecm.Domain.MasterTables.Rex.Rex_Dm_Ngaynghi Rex_Dm_Ngaynghi)
        {
            return _Rex_Dm_Ngaynghi_Service.Update_Rex_Dm_Ngaynghi(Rex_Dm_Ngaynghi);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Dm_Ngaynghi vào DB.")]
        public object Delete_Rex_Dm_Ngaynghi(Ecm.Domain.MasterTables.Rex.Rex_Dm_Ngaynghi Rex_Dm_Ngaynghi)
        {
            return _Rex_Dm_Ngaynghi_Service.Delete_Rex_Dm_Ngaynghi(Rex_Dm_Ngaynghi);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Dm_Ngaynghi vào DB.")]
        public object Update_Rex_Dm_Ngaynghi_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Ngaynghi_Service.Update_Rex_Dm_Ngaynghi_Collection(dsCollection);
        }
        #endregion

        #region Rex_Dm_Heso_Giotangca
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Heso_Giotangca")]
        public string Get_All_Rex_Dm_Heso_Giotangca_Collection()
        {
            return _Rex_Dm_Heso_Giotangca_Service.Get_All_Rex_Dm_Heso_Giotangca_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Dm_Heso_Giotangca vào DB.")]
        public object Insert_Rex_Dm_Heso_Giotangca(Ecm.Domain.MasterTables.Rex.Rex_Dm_Heso_Giotangca Rex_Dm_Heso_Giotangca)
        {
            return _Rex_Dm_Heso_Giotangca_Service.Insert_Rex_Dm_Heso_Giotangca(Rex_Dm_Heso_Giotangca);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Dm_Heso_Giotangca vào DB.")]
        public object Update_Rex_Dm_Heso_Giotangca(Ecm.Domain.MasterTables.Rex.Rex_Dm_Heso_Giotangca Rex_Dm_Heso_Giotangca)
        {
            return _Rex_Dm_Heso_Giotangca_Service.Update_Rex_Dm_Heso_Giotangca(Rex_Dm_Heso_Giotangca);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Dm_Heso_Giotangca vào DB.")]
        public object Delete_Rex_Dm_Heso_Giotangca(Ecm.Domain.MasterTables.Rex.Rex_Dm_Heso_Giotangca Rex_Dm_Heso_Giotangca)
        {
            return _Rex_Dm_Heso_Giotangca_Service.Delete_Rex_Dm_Heso_Giotangca(Rex_Dm_Heso_Giotangca);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Dm_Heso_Giotangca vào DB.")]
        public object Update_Rex_Dm_Heso_Giotangca_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Heso_Giotangca_Service.Update_Rex_Dm_Heso_Giotangca_Collection(dsCollection);
        }
        #endregion


        #region Rex_Dm_Quyetdinh
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Quyetdinh")]
        public string Get_All_Rex_Dm_Quyetdinh_Collection()
        {
            return _Rex_Dm_Quyetdinh_Service.Get_All_Rex_Dm_Quyetdinh_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Dm_Quyetdinh vào DB.")]
        public object Insert_Rex_Dm_Quyetdinh(Ecm.Domain.MasterTables.Rex.Rex_Dm_Quyetdinh Rex_Dm_Quyetdinh)
        {
            return _Rex_Dm_Quyetdinh_Service.Insert_Rex_Dm_Quyetdinh(Rex_Dm_Quyetdinh);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Dm_Quyetdinh vào DB.")]
        public object Update_Rex_Dm_Quyetdinh(Ecm.Domain.MasterTables.Rex.Rex_Dm_Quyetdinh Rex_Dm_Quyetdinh)
        {
            return _Rex_Dm_Quyetdinh_Service.Update_Rex_Dm_Quyetdinh(Rex_Dm_Quyetdinh);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Dm_Quyetdinh vào DB.")]
        public object Delete_Rex_Dm_Quyetdinh(Ecm.Domain.MasterTables.Rex.Rex_Dm_Quyetdinh Rex_Dm_Quyetdinh)
        {
            return _Rex_Dm_Quyetdinh_Service.Delete_Rex_Dm_Quyetdinh(Rex_Dm_Quyetdinh);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Dm_Quyetdinh vào DB.")]
        public object Update_Rex_Dm_Quyetdinh_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Quyetdinh_Service.Update_Rex_Dm_Quyetdinh_Collection(dsCollection);
        }
        #endregion

        #region Rex_Dm_Ndung_Tgluong
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Rex_Dm_Ndung_Tgluong")]
        public string Get_All_Rex_Dm_Ndung_Tgluong_Collection()
        {
            return _Rex_Dm_Ndung_Tgluong_Service.Get_All_Rex_Dm_Ndung_Tgluong_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Rex_Dm_Ndung_Tgluong vào DB.")]
        public object Insert_Rex_Dm_Ndung_Tgluong(Ecm.Domain.MasterTables.Rex.Rex_Dm_Ndung_Tgluong Rex_Dm_Ndung_Tgluong)
        {
            return _Rex_Dm_Ndung_Tgluong_Service.Insert_Rex_Dm_Ndung_Tgluong(Rex_Dm_Ndung_Tgluong);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Rex_Dm_Ndung_Tgluong vào DB.")]
        public object Update_Rex_Dm_Ndung_Tgluong(Ecm.Domain.MasterTables.Rex.Rex_Dm_Ndung_Tgluong Rex_Dm_Ndung_Tgluong)
        {
            return _Rex_Dm_Ndung_Tgluong_Service.Update_Rex_Dm_Ndung_Tgluong(Rex_Dm_Ndung_Tgluong);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Rex_Dm_Ndung_Tgluong vào DB.")]
        public object Delete_Rex_Dm_Ndung_Tgluong(Ecm.Domain.MasterTables.Rex.Rex_Dm_Ndung_Tgluong Rex_Dm_Ndung_Tgluong)
        {
            return _Rex_Dm_Ndung_Tgluong_Service.Delete_Rex_Dm_Ndung_Tgluong(Rex_Dm_Ndung_Tgluong);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Rex_Dm_Ndung_Tgluong vào DB.")]
        public object Update_Rex_Dm_Ndung_Tgluong_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Ndung_Tgluong_Service.Update_Rex_Dm_Ndung_Tgluong_Collection(dsCollection);
        }
        #endregion

        #endregion

        #region service

        [WebMethod]
        public object GetNew_Sochungtu(object Table_Name, object Column_Name, object Prefix)
        {
            return _DocumentProcessStatus_Service.GetNew_Sochungtu(Table_Name, Column_Name, Prefix);
        }

        [WebMethod]
        public object Getnew_Sohoadon_NoVAT(object Ma_Kho_HH)
        {
            return _DocumentProcessStatus_Service.Getnew_Sohoadon_NoVAT(Ma_Kho_HH);
        }

        [WebMethod]
        public object GetExistReferences(object Table_Name, object Column_Name, object Lookup_Value)
        {
            return _DocumentProcessStatus_Service.GetExistReferences(Table_Name, Column_Name, Lookup_Value);
        }

        [WebMethod]
        public string GetRole_System_Name_ById_User(object Id_User)
        {
            return _DocumentProcessStatus_Service.GetRole_System_Name_ById_User(Id_User);
        }

        //[WebMethod(BufferResponse = true, Description = "Get Lognotify")]
        //public string Get_Sys_Lognotify(string table_name)
        //{
        //    using (Ecm.Service.Sys.Sys_Service Sys_Service = new Ecm.Service.Sys.Sys_Service(this.sqlConnection))
        //    {
        //        return Sys_Service.Get_Sys_Lognotify(table_name);
        //    }
        //}

        [WebMethod(BufferResponse = true, Description = "Get Lognotify")]
        public string Get_Sys_Lognotify_SelectLastChange_OfTables(string table_names)
        {
            using (Ecm.Service.Sys.Sys_Service Sys_Service = new Ecm.Service.Sys.Sys_Service(this.sqlConnection))
            {
                return Sys_Service.Get_Sys_Lognotify_SelectLastChange_OfTables(table_names);
            }
        }

        [WebMethod]
        public string GetAll_Sys_Lognotify()
        {
            using (Ecm.Service.Sys.Sys_Service Sys_Service = new Ecm.Service.Sys.Sys_Service(this.sqlConnection))
            {
                return Sys_Service.Get_Sys_Lognotify();
            }
        }
        #endregion

        #region Rex_Dm_Loai_Nhanvien
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Dm_Loai_Nhanvien")]
        public string Get_All_Rex_Dm_Loai_Nhanvien_Collection()
        {
            return _Rex_Dm_Loai_Nhanvien_Service.Get_All_Rex_Dm_Loai_Nhanvien_Collection();
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Dm_Loai_Nhanvien vào DB.")]
        public object Insert_Rex_Dm_Loai_Nhanvien(Ecm.Domain.MasterTables.Rex.Rex_Dm_Loai_Nhanvien Rex_Dm_Loai_Nhanvien)
        {
            return _Rex_Dm_Loai_Nhanvien_Service.Insert_Rex_Dm_Loai_Nhanvien(Rex_Dm_Loai_Nhanvien);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Dm_Loai_Bophan vào DB.")]
        public object Update_Rex_Dm_Loai_Nhanvien(Ecm.Domain.MasterTables.Rex.Rex_Dm_Loai_Nhanvien Rex_Dm_Loai_Nhanvien)
        {
            return _Rex_Dm_Loai_Nhanvien_Service.Update_Rex_Dm_Loai_Nhanvien(Rex_Dm_Loai_Nhanvien);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Dm_Loai_Nhanvien vào DB.")]
        public object Delete_Rex_Dm_Loai_Nhanvien(Ecm.Domain.MasterTables.Rex.Rex_Dm_Loai_Nhanvien Rex_Dm_Loai_Nhanvien)
        {
            return _Rex_Dm_Loai_Nhanvien_Service.Delete_Rex_Dm_Loai_Nhanvien(Rex_Dm_Loai_Nhanvien);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Dm_Loai_Nhanvien vào DB.")]
        public object Update_Rex_Dm_Loai_Nhanvien_Collection(DataSet dsCollection)
        {
            return _Rex_Dm_Loai_Nhanvien_Service.Update_Rex_Dm_Loai_Nhanvien_Collection(dsCollection);
        }
        #endregion

        #region Hệ số chương trình --> removed


        //[WebMethod(BufferResponse = true, Description = "Trả về danh sách hệ số chương trình (dưới dạng mảng)")]
        //public System.Data.Rex.Rex_Dm_Heso_Chuongtrinh_Collection Get_Rex_Dm_Heso_Chuongtrinh_Collection1()
        //{
        //    System.Data.Rex.Rex_Dm_Heso_Chuongtrinh_Collection Rex_Dm_Heso_Chuongtrinh_Collection = _Rex_Dm_Heso_Chuongtrinh_Service.Get_Rex_Dm_Heso_Chuongtrinh_Collection();
        //    return Rex_Dm_Heso_Chuongtrinh_Collection;
        //}

        [WebMethod(BufferResponse = true, Description = "Trả về danh sách hệ số chương trình được Serialize thành DataSet")]
        public string Get_Rex_Dm_Heso_Chuongtrinh_Collection3()
        {
            return _Rex_Dm_Heso_Chuongtrinh_Service.GetDs_Rex_Dm_Heso_Chuongtrinh_Collection();

        }

        [WebMethod(BufferResponse = true, Description = "Trả về danh sách hệ số chương trình bởi nhóm hệ số được Serialize thành DataSet")]
        public string Get_Rex_Dm_Heso_Chuongtrinh_By_Nhomheso(object nhom)
        {
            return _Rex_Dm_Heso_Chuongtrinh_Service.GetAll_Rex_Dm_Heso_Chuongtrinh_By_Nhomheso(nhom);

        }

        [WebMethod(BufferResponse = true, Description = "Insert một đối tượng Rex_Dm_Heso_Chuongtrinh vào bảng rex_dm_heso_chuongtrinh")]
        public object Insert_Rex_Dm_Heso_Chuongtrinh(Ecm.Domain.MasterTables.Rex.Rex_Dm_Heso_Chuongtrinh Rex_Dm_Heso_Chuongtrinh)
        {
            return _Rex_Dm_Heso_Chuongtrinh_Service.Insert_Rex_Dm_Heso_Chuongtrinh(Rex_Dm_Heso_Chuongtrinh);
        }

        [WebMethod(BufferResponse = true, Description = "Update một đối tượng Rex_Dm_Heso_Chuongtrinh vào bảng rex_dm_heso_chuongtrinh")]
        public object Update_Rex_Dm_Heso_Chuongtrinh(Ecm.Domain.MasterTables.Rex.Rex_Dm_Heso_Chuongtrinh Rex_Dm_Heso_Chuongtrinh)
        {
            return _Rex_Dm_Heso_Chuongtrinh_Service.Update_Rex_Dm_Heso_Chuongtrinh(Rex_Dm_Heso_Chuongtrinh);
        }

        [WebMethod(BufferResponse = true, Description = "Delete một đối tượng Rex_Dm_Heso_Chuongtrinh vào bảng rex_dm_heso_chuongtrinh")]
        public object Delete_Rex_Dm_Heso_Chuongtrinh(Ecm.Domain.MasterTables.Rex.Rex_Dm_Heso_Chuongtrinh Rex_Dm_Heso_Chuongtrinh)
        {
            return _Rex_Dm_Heso_Chuongtrinh_Service.Delete_Rex_Dm_Heso_Chuongtrinh(Rex_Dm_Heso_Chuongtrinh);
        }

        [WebMethod(BufferResponse = true, Description = "Cập nhật một dataset Rex_Dm_Heso_Chuongtrinh vào trong bảng Rex_Dm_Heso_Chuongtrinh")]
        public object Update_Rex_Dm_Heso_Chuongtrinh_Collection(DataSet ds_Rex_Dm_Heso_Chuongtrinh)
        {
            return _Rex_Dm_Heso_Chuongtrinh_Service.Update_Rex_Dm_Heso_Chuongtrinh_Collection(ds_Rex_Dm_Heso_Chuongtrinh);
        }

        #endregion

        #region Ware_Hanghoa_Dinhgia
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Hanghoa_Dinhgia")]
        public string Get_All_Ware_Hanghoa_Dinhgia()
        {
            return _Ware_Hanghoa_Dinhgia_Service.Get_All_Ware_Hanghoa_Dinhgia();
        }

        //[WebMethod(BufferResponse = true, Description = "Trả về một dataset Hanghoa_Dinhgia by Id_Hh_Mua")]
        //public string Get_All_Ware_Hanghoa_Dinhgia_By_Id_hh_Mua(object id_Hh_Mua)
        //{
        //    return _Ware_Hanghoa_Dinhgia_Service.Get_All_Ware_Hanghoa_Dinhgia_By_Id_hh_Mua(id_Hh_Mua);
        //}

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Hanghoa_Dinhgia")]
        public string Get_All_Ware_Hanghoa_Dinhgia_Log()
        {
            return _Ware_Hanghoa_Dinhgia_Service.Get_All_Ware_Hanghoa_Dinhgia_Log();
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Hanghoa_Dinhgia By id loại hàng hóa")]
        public string Get_All_Ware_Hanghoa_Dinhgia_By_Id_Loai_hh(object Id_Loai_Hanghoa)
        {
            return _Ware_Hanghoa_Dinhgia_Service.Get_All_Ware_Hanghoa_Dinhgia_By_Id_Loai_hh(Id_Loai_Hanghoa);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Hanghoa_Dinhgia By id loại hàng hóa có giá tại thời điểm hiện tại")]
        public string Get_All_Ware_Hanghoa_Dinhgia_By_Loai_HH_By_Date(object Id_Loai_Hanghoa, object ngay_chungtu)
        {
            return _Ware_Hanghoa_Dinhgia_Service.Get_All_Ware_Hanghoa_Dinhgia_By_Loai_HH_By_Date(Id_Loai_Hanghoa, ngay_chungtu);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Hanghoa_Dinhgia By id hàng hóa bán")]
        public string Get_All_Ware_Hanghoa_Dinhgia_By_Id_HhBan(object Id_Hanghoa_Ban)
        {
            return _Ware_Hanghoa_Dinhgia_Service.Get_All_Ware_Hanghoa_Dinhgia_By_Id_HhBan(Id_Hanghoa_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Hanghoa_Mua_Dinhgia")]
        public string Get_All_Ware_Hanghoa_Mua_Dinhgia()
        {
            return _Ware_Hanghoa_Dinhgia_Service.Get_All_Ware_Hanghoa_Mua_Dinhgia();
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Hanghoa_Dinhgia_Log By Id_Loai_Hanghoa")]
        public string Get_All_Ware_Hanghoa_Dinhgia_Log_By_Id_LoaiHh(object Id_Loai_Hanghoa)
        {
            return _Ware_Hanghoa_Dinhgia_Service.Get_All_Ware_Hanghoa_Dinhgia_Log_By_Id_LoaiHh(Id_Loai_Hanghoa);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Hanghoa_Mua_Dinhgia")]
        public string Get_All_Ware_Hanghoa_Mua_Dinhgia_ByDate(object Ngay_Chungtu)
        {
            return _Ware_Hanghoa_Dinhgia_Service.Get_All_Ware_Hanghoa_Mua_Dinhgia_ByDate(Ngay_Chungtu);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Hanghoa_Ban_Dinhgia")]
        public string Get_All_Ware_Hanghoa_Ban_Dinhgia()
        {
            return _Ware_Hanghoa_Dinhgia_Service.Get_All_Ware_Hanghoa_Ban_Dinhgia();
        }



        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Hanghoa_Ban_Dinhgia")]
        public string Get_All_Ware_Hanghoa_Ban_Dinhgia_ByDate(object Ngay_Chungtu)
        {
            return _Ware_Hanghoa_Dinhgia_Service.Get_All_Ware_Hanghoa_Ban_Dinhgia_ByDate(Ngay_Chungtu);
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Ware_Hanghoa_Dinhgia vào DB.")]
        public object Insert_Ware_Hanghoa_Dinhgia(Ecm.Domain.Ware.Ware_Hanghoa_Dinhgia Ware_Hanghoa_Dinhgia)
        {
            return _Ware_Hanghoa_Dinhgia_Service.Insert_Ware_Hanghoa_Dinhgia(Ware_Hanghoa_Dinhgia);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Ware_Hanghoa_Dinhgia vào DB.")]
        public object Update_Ware_Hanghoa_Dinhgia(Ecm.Domain.Ware.Ware_Hanghoa_Dinhgia Ware_Hanghoa_Dinhgia)
        {
            return _Ware_Hanghoa_Dinhgia_Service.Update_Ware_Hanghoa_Dinhgia(Ware_Hanghoa_Dinhgia);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Ware_Hanghoa_Dinhgia vào DB.")]
        public object Delete_Ware_Hanghoa_Dinhgia(Ecm.Domain.Ware.Ware_Hanghoa_Dinhgia Ware_Hanghoa_Dinhgia)
        {
            return _Ware_Hanghoa_Dinhgia_Service.Delete_Ware_Hanghoa_Dinhgia(Ware_Hanghoa_Dinhgia);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Ware_Hanghoa_Dinhgia_Chitiet vào DB.")]
        public object Update_Ware_Hanghoa_Dinhgia_Log_Collection(DataSet dsCollection)
        {
            return _Ware_Hanghoa_Dinhgia_Service.Update_Ware_Hanghoa_Dinhgia_Log_Collection(dsCollection);
        }

        [WebMethod(BufferResponse = true, Description = "Update collection Ware_Hanghoa_Dinhgia_Chitiet vào DB.")]
        public object Update_Ware_Hanghoa_Dinhgia_Collection(DataSet dsCollection)
        {
            return _Ware_Hanghoa_Dinhgia_Service.Update_Ware_Hanghoa_Dinhgia_Collection(dsCollection);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Hanghoa_Ban_Dinhgia by Ten_hanghoa_ban")]
        public string Get_All_Ware_Hanghoa_Ban_Dinhgia_By_Ten_Hanghoa(object Ten_Hanghoa_Ban)
        {
            return _Ware_Hanghoa_Dinhgia_Service.Get_All_Ware_Hanghoa_Ban_Dinhgia_By_Ten_Hanghoa(Ten_Hanghoa_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Hanghoa_Ban_Dinhgia by Ma_hanghoa_ban")]
        public string Get_All_Ware_Hanghoa_Ban_Dinhgia_By_Ma_Hanghoa(object Ma_Hanghoa_Ban)
        {
            return _Ware_Hanghoa_Dinhgia_Service.Get_All_Ware_Hanghoa_Ban_Dinhgia_By_Ma_Hanghoa(Ma_Hanghoa_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Hanghoa_Ban_Dinhgia by Barcode")]
        public string Get_All_Ware_Hanghoa_Ban_Dinhgia_By_Barcode(object Barcode_Txt)
        {
            return _Ware_Hanghoa_Dinhgia_Service.Get_All_Ware_Hanghoa_Ban_Dinhgia_By_Barcode(Barcode_Txt);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Hanghoa_Ban_Dinhgia ")]
        public string Search_Ware_Hanghoa_Ban_Dinhgia(Ecm.Domain.MasterTables.Ware.Ware_Dm_Hanghoa_Ban ware_Dm_Hanghoa_Ban)
        {
            return _Ware_Hanghoa_Dinhgia_Service.Search_Ware_Hanghoa_Ban_Dinhgia(ware_Dm_Hanghoa_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Hanghoa_Dinhgia")]
        public string Get_All_Ware_Hanghoa_Dinhgia_Khuvuc(object Id_Hanghoa_Dinhgia)
        {
            return _Ware_Hanghoa_Dinhgia_Khuvuc_Service.Get_All_Ware_Hanghoa_Dinhgia_Khuvuc(Id_Hanghoa_Dinhgia);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Hanghoa_Dinhgia")]
        public object Update_Ware_Hanghoa_Dinhgia_Khuvuc_Collection(DataSet dsCollection)
        {
            return _Ware_Hanghoa_Dinhgia_Khuvuc_Service.Update_Ware_Hanghoa_Dinhgia_Khuvuc_Collection(dsCollection);
        }

        #endregion

        #region extends SystemService
        [WebMethod]
        public DateTime GetServerDateTime()
        {
            return SystemService.GetServerDateTime();
        }

        [WebMethod]
        public string GetCurrentTimeZone()
        {

            return SystemService.CurrentTimeZone.StandardName;
        }




        #endregion


        #region Utils
        //public void RemoveOutputCacheItem_Refer_Hanghoaban()
        //{
        //    var paths = new string[] { 
        //        //bar
        //        "/Ecm.Webservices/MasterService.asmx/Get_All_Bar_Dm_Menu",
        //        "/Ecm.Webservices/MasterService.asmx/Get_Visible_Bar_Dm_Menu",
        //        "/Ecm.Webservices/MasterService.asmx/Get_All_Bar_Dm_Menu_Hanghoa_Ban",
        //        "/Ecm.Webservices/MasterService.asmx/Get_All_Bar_Dm_Menu_Hanghoa_Ban_By_Id_Menu",
        //        "/Ecm.Webservices/MasterService.asmx/Get_Visible_Bar_Dm_Menu_Hanghoa_Ban_Collection",

        //        //ware
        //        "/Ecm.Webservices/MasterService.asmx/Get_All_Ware_Dm_Hanghoa_Ban",
        //        "/Ecm.Webservices/MasterService.asmx/Get_All_Ware_Dm_Hanghoa_Ban_By_Id_Loai_Hh_Ban_None_Dinhgia",
        //        "/Ecm.Webservices/MasterService.asmx/Get_All_Ware_Dm_Hanghoa_Ban_By_Id_Cuahang_Ban",
        //    };
        //    foreach (var path in paths)
        //    {
        //        HttpResponse.RemoveOutputCacheItem(path);
        //    }
        //}
        #endregion
    }



}
