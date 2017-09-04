using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;
using Ecm.Service;
using Ecm.Service.Ware;
using Ecm.Service.Sys;
using Ecm.Service.MasterTables.Ware;
using Newtonsoft.Json;

namespace Ecm.Webservice
{

    /// <summary>
    /// Summary description for WareService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.Web.Script.Services.ScriptService]
    public class WareService : System.Web.Services.WebService
    {
        //Connection
        System.Data.OleDb.OleDbConnection sqlConnection = DbConnection.OleDbConnection;

        #region Khai báo các đối tượng service - ware
        //ware
        Ware_Xuat_Nguyenlieu_Service _Ware_Xuat_Nguyenlieu_Service;
        Ware_Dongia_Cap_Service _Ware_Dongia_Cap_Service;
        Ware_Dondathang_Service _Ware_Dondathang_Service;
        Ware_Congnothu_Dauky_Service _Ware_Congnothu_Dauky_Service;
        Ware_Congnotra_Dauky_Service _Ware_Congnotra_Dauky_Service;
        Ware_Hanghoa_Ban_Dauky_Service _Ware_Hanghoa_Ban_Dauky_Service;
        Ware_Donmuahang_Service _Ware_Donmuahang_Service;
        Ware_Donmuahang_Kh_Service _Ware_Donmuahang_Kh_Service;
        Ware_Hdmuahang_Service _Ware_Hdmuahang_Service;
        Ware_Nhap_Hh_Ban_Service _Ware_Nhap_Hh_Ban_Service;
        Ware_Hdbanhang_Service _Ware_Hdbanhang_Service;
        Ware_Hdbanhang_Vat_Service _Ware_Hdbanhang_Vat_Service;
        Ware_Hanghoa_Dinhgia_Service _Ware_Hanghoa_Dinhgia_Service;
        Ware_Hanghoa_Dinhgia_Khuvuc_Service _Ware_Hanghoa_Dinhgia_Khuvuc_Service;
        Ware_Phieu_Thu_Service _Ware_Phieu_Thu_Service;
        Ware_Phieu_Chi_Service _Ware_Phieu_Chi_Service;
        Ware_Phieuchi_Congno_Service _Ware_Phieuchi_Congno_Service;
        Ware_Phieuthu_Congno_Service _Ware_Phieuthu_Congno_Service;
        Ware_Kk_Hh_Ban_Service _Ware_Kk_Hh_Ban_Service;
        Ware_Kh_Hh_Ban_Service _Ware_Kh_Hh_Ban_Service;
        Ware_Ql_Cuahang_Ban_Service _Ware_Ql_Cuahang_Ban_Service;
        Ware_Xuat_Hh_Ban_Service _Ware_Xuat_Hh_Ban_Service;
        Ware_Xuat_Hh_Mua_Service _Ware_Xuat_Hh_Mua_Service;
        Ware_Hh_Cuahang_Ban_Service _Ware_Hh_Cuahang_Ban_Service;
        DocumentProcessStatus_Service _DocumentProcessStatus_Service;
        //Ware_Khachhang_Vip_Service _Ware_Khachhang_Vip_Service;
        //Ware_Khachhang_Quota_Service _Ware_Khachhang_Quota_Service;
        Ware_Hdbanhang_Sum_Service _Ware_Hdbanhang_Sum_Service;
        Rptware_Hanghoa_Service _Rptware_Hanghoa_Service;
        Ware_Xuatkho_Banhang_Service _Ware_Xuatkho_Banhang_Service;
        Ware_Congtac_Services _Ware_Congtac_Services;
        Ware_Thumau_Services _Ware_Thumau_Services;
        Ware_Kehoach_Banhang_Services _Ware_Kehoach_Banhang_Services;
        Ware_Kehoach_Banhang_Chitiet_Services _Ware_Kehoach_Banhang_Chitiet_Services;
        Ware_Phantich_Thitruong_Services _Ware_Phantich_Thitruong_Services;
        Ware_Phantich_Thitruong_Chitiet_Services _Ware_Phantich_Thitruong_Chitiet_Services;
        Ware_Kehoach_Dathang_Services _Ware_Kehoach_Dathang_Services;
        Ware_Kehoach_Dathang_Chitiet_Services _Ware_Kehoach_Dathang_Chitiet_Services;
        Ware_Dieuxe_Service _Ware_Dieuxe_Service;
        //waregen
        //WareGen_Dm_Congthuc_Phache_Service _WareGen_Dm_Congthuc_Phache_Service;
        //WareGen_Dm_Congthuc_Phache_Chitiet_Service _WareGen_Dm_Congthuc_Phache_Chitiet_Service;
        WareGen_Hdbanhang_Service _WareGen_Hdbanhang_Service;
        WareGen_Donmuahang_Service _WareGen_Donmuahang_Service;

        Sys_Service _Sys_Service;

        Ware_So_Quytm_Service _Ware_So_Quytm_Service;
        //Ware_Quytm_Dauky_Service _Ware_Quytm_Dauky_Service;
        //Ware_Hanghoa_Mua_Dauky_Service _Ware_Hanghoa_Mua_Dauky_Service;
        //Ware_Ctrinh_Kmai_Service _Ware_Ctrinh_Kmai_Service;
        //Ware_Vip_Member_Service _Ware_Vip_Member_Service;
        //Ware_Hh_Mua_Tra_Ncc_Service _Ware_Hh_Mua_Tra_Ncc_Service;
        //Ware_Nhap_Hh_Mua_Service _Ware_Nhap_Hh_Mua_Service;
        //Ware_Nhap_Hh_Ban_Err_Service _Ware_Nhap_Hh_Ban_Err_Service;
        //Ware_Ql_Kho_Hanghoa_Mua_Service _Ware_Ql_Kho_Hanghoa_Mua_Service;
        Ware_Hh_Kh_Tra_Service _Ware_Hh_Kh_Tra_Service;
        //Ware_Hh_Kho_Hanghoa_Mua_Service _Ware_Hh_Kho_Hanghoa_Mua_Service;
        #endregion

        public WareService()
        {
            #region Khởi tạo các đối tượng service - ware
            //ware
            _Ware_Xuat_Nguyenlieu_Service = new Ware_Xuat_Nguyenlieu_Service(sqlConnection);
            _Ware_Dongia_Cap_Service = new Ware_Dongia_Cap_Service(sqlConnection);
            _Ware_Dondathang_Service = new Ware_Dondathang_Service(sqlConnection);
            _Ware_Congnothu_Dauky_Service = new Ware_Congnothu_Dauky_Service(sqlConnection);
            _Ware_Congnotra_Dauky_Service = new Ware_Congnotra_Dauky_Service(sqlConnection);
            _Ware_Hanghoa_Ban_Dauky_Service = new Ware_Hanghoa_Ban_Dauky_Service(sqlConnection);
            _Ware_Donmuahang_Service = new Ware_Donmuahang_Service(sqlConnection);
            _Ware_Donmuahang_Kh_Service = new Ware_Donmuahang_Kh_Service(sqlConnection);
            _Ware_Hdmuahang_Service = new Ware_Hdmuahang_Service(sqlConnection);
            _Ware_Nhap_Hh_Ban_Service = new Ware_Nhap_Hh_Ban_Service(sqlConnection);
            _Ware_Hdbanhang_Service = new Ware_Hdbanhang_Service(sqlConnection);
            _Ware_Hdbanhang_Vat_Service = new Ware_Hdbanhang_Vat_Service(sqlConnection);
            _Ware_Hanghoa_Dinhgia_Service = new Ware_Hanghoa_Dinhgia_Service(sqlConnection);
            _Ware_Hanghoa_Dinhgia_Khuvuc_Service = new Ware_Hanghoa_Dinhgia_Khuvuc_Service(sqlConnection);
            _Ware_Phieu_Thu_Service = new Ware_Phieu_Thu_Service(sqlConnection);
            _Ware_Kk_Hh_Ban_Service = new Ware_Kk_Hh_Ban_Service(sqlConnection);
            _Ware_Phieu_Chi_Service = new Ware_Phieu_Chi_Service(sqlConnection);
            _Ware_Phieuchi_Congno_Service = new Ware_Phieuchi_Congno_Service(sqlConnection);
            _Ware_Phieuthu_Congno_Service = new Ware_Phieuthu_Congno_Service(sqlConnection);
            _Ware_Ql_Cuahang_Ban_Service = new Ware_Ql_Cuahang_Ban_Service(sqlConnection);
            _Ware_Xuat_Hh_Ban_Service = new Ware_Xuat_Hh_Ban_Service(sqlConnection);
            _Ware_Xuat_Hh_Mua_Service = new Ware_Xuat_Hh_Mua_Service(sqlConnection);
            _Ware_Hh_Cuahang_Ban_Service = new Ware_Hh_Cuahang_Ban_Service(sqlConnection);
            _DocumentProcessStatus_Service = new DocumentProcessStatus_Service(sqlConnection);
            //_Ware_Khachhang_Vip_Service = new Ware_Khachhang_Vip_Service(sqlConnection);
            //_Ware_Khachhang_Quota_Service = new Ware_Khachhang_Quota_Service(sqlConnection);
            _Ware_Hdbanhang_Sum_Service = new Ware_Hdbanhang_Sum_Service(sqlConnection);
            _Ware_Kh_Hh_Ban_Service = new Ware_Kh_Hh_Ban_Service(sqlConnection);
            _Rptware_Hanghoa_Service = new Rptware_Hanghoa_Service(sqlConnection);
            _Ware_Xuatkho_Banhang_Service = new Ware_Xuatkho_Banhang_Service(sqlConnection);
            _Ware_Congtac_Services = new Ware_Congtac_Services(sqlConnection);
            _Ware_Thumau_Services = new Ware_Thumau_Services(sqlConnection);
            _Ware_Kehoach_Banhang_Services = new Ware_Kehoach_Banhang_Services(sqlConnection);
            _Ware_Kehoach_Banhang_Chitiet_Services = new Ware_Kehoach_Banhang_Chitiet_Services(sqlConnection);
            _Ware_Phantich_Thitruong_Services = new Ware_Phantich_Thitruong_Services(sqlConnection);
            _Ware_Phantich_Thitruong_Chitiet_Services = new Ware_Phantich_Thitruong_Chitiet_Services(sqlConnection);
            //_WareGen_Dm_Congthuc_Phache_Service = new WareGen_Dm_Congthuc_Phache_Service(sqlConnection);
            //_WareGen_Dm_Congthuc_Phache_Chitiet_Service = new WareGen_Dm_Congthuc_Phache_Chitiet_Service(sqlConnection);
            _WareGen_Hdbanhang_Service = new WareGen_Hdbanhang_Service(sqlConnection);
            _WareGen_Donmuahang_Service = new WareGen_Donmuahang_Service(sqlConnection);
            _Ware_Kehoach_Dathang_Chitiet_Services = new Ware_Kehoach_Dathang_Chitiet_Services(sqlConnection);
            _Ware_Dieuxe_Service = new Ware_Dieuxe_Service(sqlConnection);
            _Ware_Kehoach_Dathang_Services = new Ware_Kehoach_Dathang_Services(sqlConnection);
            _Ware_So_Quytm_Service = new Ware_So_Quytm_Service(sqlConnection);

            _Ware_Hh_Kh_Tra_Service = new Ware_Hh_Kh_Tra_Service(sqlConnection);
            //Sys
            _Sys_Service = new Sys_Service(sqlConnection);
            #endregion
        }

        #region ware

        [WebMethod(Description = ".")]
        public Boolean Ware_Hdbanhang_Check_Hoadon_Congno_ByDate(object Id_Hdbanhang, object Date)
        {
            return _Ware_Hdbanhang_Service.Ware_Hdbanhang_Check_Hoadon_Congno_ByDate(Id_Hdbanhang, Date);
        }


        #region Ware_Xuat_Nguyenlieu_Service

        [WebMethod(Description = "")]
        public string Ware_Xuat_Nguyenlieu_SelectAll(object Ngay_Chungtu, object Id_Cuahang_Ban)
        {
            return _Ware_Xuat_Nguyenlieu_Service.Ware_Xuat_Nguyenlieu_SelectAll(Ngay_Chungtu, Id_Cuahang_Ban);
        }

        [WebMethod(Description = "")]
        public object Ware_Xuat_Nguyenlieu_Insert(Ecm.Domain.Ware.Ware_Xuat_Nguyenlieu _Ware_Xuat_Nguyenlieu)
        {
            return _Ware_Xuat_Nguyenlieu_Service.Ware_Xuat_Nguyenlieu_Insert(_Ware_Xuat_Nguyenlieu);
        }

        [WebMethod(Description = "")]
        public object Ware_Xuat_Nguyenlieu_Delete(Ecm.Domain.Ware.Ware_Xuat_Nguyenlieu _Ware_Xuat_Nguyenlieu)
        {
            return _Ware_Xuat_Nguyenlieu_Service.Ware_Xuat_Nguyenlieu_Delete(_Ware_Xuat_Nguyenlieu);
        }

        [WebMethod(Description = "")]
        public object Ware_Xuat_Nguyenlieu_Update(Ecm.Domain.Ware.Ware_Xuat_Nguyenlieu _Ware_Xuat_Nguyenlieu)
        {
            return _Ware_Xuat_Nguyenlieu_Service.Ware_Xuat_Nguyenlieu_Update(_Ware_Xuat_Nguyenlieu);
        }

        [WebMethod(Description = "")]
        public object Update_Ware_Xuat_Nguyenlieu_Chitiet_Collection(DataSet dsCollection)
        {
            return _Ware_Xuat_Nguyenlieu_Service.Update_Ware_Xuat_Nguyenlieu_Chitiet_Collection(dsCollection);
        }

        [WebMethod(Description = "")]
        public string Ware_Xuat_Nguyenlieu_Chitiet_SelectBy_Id_Xuat_Nguyenlieu(object Id_Xuat_Nguyenlieu)
        {
            return _Ware_Xuat_Nguyenlieu_Service.Ware_Xuat_Nguyenlieu_Chitiet_SelectBy_Id_Xuat_Nguyenlieu(Id_Xuat_Nguyenlieu);
        }

        #endregion

        #region Ware_Dongia_Cap_Service

        [WebMethod(Description = "")]
        public string Ware_Dongia_Cap_Selectall(object Id_Hanghoa_Dinhgia)
        {
            return _Ware_Dongia_Cap_Service.Ware_Dongia_Cap_Selectall(Id_Hanghoa_Dinhgia);
        }

        [WebMethod(Description = "")]
        public object Update_Ware_Dongia_Cap_Collection(DataSet DsCollection)
        {
            return _Ware_Dongia_Cap_Service.Update_Ware_Dongia_Cap_Collection(DsCollection);
        }

        #endregion

        #region Ware_Dondathang

        [WebMethod(Description = "")]
        public object Ware_Dondathang_Insert(Ecm.Domain.Ware.Ware_Dondathang _Ware_Dondathang)
        {
            return _Ware_Dondathang_Service.Ware_Dondathang_Insert(_Ware_Dondathang);
        }

        [WebMethod(Description = "")]
        public object Ware_Dondathang_Update(Ecm.Domain.Ware.Ware_Dondathang _Ware_Dondathang)
        {
            return _Ware_Dondathang_Service.Ware_Dondathang_Update(_Ware_Dondathang);
        }

        [WebMethod(Description = "")]
        public object Ware_Dondathang_Update_Doc(Ecm.Domain.Ware.Ware_Dondathang _Ware_Dondathang)
        {
            return _Ware_Dondathang_Service.Ware_Dondathang_Update_Doc(_Ware_Dondathang);
        }

        [WebMethod(Description = "")]
        public object Ware_Dondathang_Delete(Ecm.Domain.Ware.Ware_Dondathang _Ware_Dondathang)
        {
            return _Ware_Dondathang_Service.Ware_Dondathang_Delete(_Ware_Dondathang);
        }

        [WebMethod(Description = "")]
        public string Ware_Dondathang_SelectAll(object Ngay_Chungtu, object Id_Nhansu)
        {
            return _Ware_Dondathang_Service.Ware_Dondathang_SelectAll(Ngay_Chungtu, Id_Nhansu);
        }

        [WebMethod(Description = "")]
        public string Ware_Dondathang_Chitiet_SelectById_Dondathang(object Id_Dondathang)
        {
            return _Ware_Dondathang_Service.Ware_Dondathang_Chitiet_SelectById_Dondathang(Id_Dondathang);
        }

        [WebMethod(Description = "")]
        public object Update_Ware_Dondathang_Chitiet_Collection(DataSet DsCollection)
        {
            return _Ware_Dondathang_Service.Update_Ware_Dondathang_Chitiet_Collection(DsCollection);
        }

        #endregion

        #region Ware_Congnothu_Dauky
        [WebMethod(Description = "Trả về một dataset Congnothu_Dauky")]
        public string Get_All_Ware_Congnothu_Dauky()
        {
            return _Ware_Congnothu_Dauky_Service.Get_All_Ware_Congnothu_Dauky();
        }

        [WebMethod(Description = "Insert đối tượng Ware_Congnothu_Dauky vào DB.")]
        public object Insert_Ware_Congnothu_Dauky(Ecm.Domain.Ware.Ware_Congnothu_Dauky Ware_Congnothu_Dauky)
        {
            return _Ware_Congnothu_Dauky_Service.Insert_Ware_Congnothu_Dauky(Ware_Congnothu_Dauky);
        }

        [WebMethod(Description = "Update đối tượng Ware_Congnothu_Dauky vào DB.")]
        public object Update_Ware_Congnothu_Dauky(Ecm.Domain.Ware.Ware_Congnothu_Dauky Ware_Congnothu_Dauky)
        {
            return _Ware_Congnothu_Dauky_Service.Update_Ware_Congnothu_Dauky(Ware_Congnothu_Dauky);
        }

        [WebMethod(Description = "Delete đối tượng Ware_Congnothu_Dauky vào DB.")]
        public object Delete_Ware_Congnothu_Dauky(Ecm.Domain.Ware.Ware_Congnothu_Dauky Ware_Congnothu_Dauky)
        {
            return _Ware_Congnothu_Dauky_Service.Delete_Ware_Congnothu_Dauky(Ware_Congnothu_Dauky);
        }

        [WebMethod(Description = "Update collection Ware_Congnothu_Dauky vào DB.")]
        public object Update_Ware_Congnothu_Dauky_Collection(DataSet dsCollection)
        {
            return _Ware_Congnothu_Dauky_Service.Update_Ware_Congnothu_Dauky_Collection(dsCollection);
        }

        [WebMethod(Description = "Update collection Ware_Congnothu_Dauky vào DB.")]
        public object Update_Ware_Congnothu_Dauky_Collection2(DataSet dsCollection)
        {
            return _Ware_Congnothu_Dauky_Service.Update_Ware_Congnothu_Dauky_Collection2(dsCollection);
        }

        #endregion

        #region Ware_Congnotra_Dauky
        [WebMethod(Description = "Trả về một dataset Congnotra_Dauky")]
        public string Get_All_Ware_Congnotra_Dauky()
        {
            return _Ware_Congnotra_Dauky_Service.Get_All_Ware_Congnotra_Dauky();
        }

        [WebMethod(Description = "Insert đối tượng Ware_Congnotra_Dauky vào DB.")]
        public object Insert_Ware_Congnotra_Dauky(Ecm.Domain.Ware.Ware_Congnotra_Dauky Ware_Congnotra_Dauky)
        {
            return _Ware_Congnotra_Dauky_Service.Insert_Ware_Congnotra_Dauky(Ware_Congnotra_Dauky);
        }

        [WebMethod(Description = "Update đối tượng Ware_Congnotra_Dauky vào DB.")]
        public object Update_Ware_Congnotra_Dauky(Ecm.Domain.Ware.Ware_Congnotra_Dauky Ware_Congnotra_Dauky)
        {
            return _Ware_Congnotra_Dauky_Service.Update_Ware_Congnotra_Dauky(Ware_Congnotra_Dauky);
        }

        [WebMethod(Description = "Delete đối tượng Ware_Congnotra_Dauky vào DB.")]
        public object Delete_Ware_Congnotra_Dauky(Ecm.Domain.Ware.Ware_Congnotra_Dauky Ware_Congnotra_Dauky)
        {
            return _Ware_Congnotra_Dauky_Service.Delete_Ware_Congnotra_Dauky(Ware_Congnotra_Dauky);
        }

        [WebMethod(Description = "Update collection Ware_Congnotra_Dauky vào DB.")]
        public object Update_Ware_Congnotra_Dauky_Collection(DataSet dsCollection)
        {
            return _Ware_Congnotra_Dauky_Service.Update_Ware_Congnotra_Dauky_Collection(dsCollection);
        }
        #endregion

        #region Ware_Hanghoa_Ban_Dauky
        [WebMethod(Description = "Trả về một dataset Hanghoa_Ban_Dauky")]
        public string Get_All_Ware_Hanghoa_Ban_Dauky()
        {
            return _Ware_Hanghoa_Ban_Dauky_Service.Get_All_Ware_Hanghoa_Ban_Dauky();
        }

        [WebMethod(Description = "Insert đối tượng Ware_Hanghoa_Ban_Dauky vào DB.")]
        public object Insert_Ware_Hanghoa_Ban_Dauky(Ecm.Domain.Ware.Ware_Hanghoa_Ban_Dauky Ware_Hanghoa_Ban_Dauky)
        {
            return _Ware_Hanghoa_Ban_Dauky_Service.Insert_Ware_Hanghoa_Ban_Dauky(Ware_Hanghoa_Ban_Dauky);
        }

        [WebMethod(Description = "Update đối tượng Ware_Hanghoa_Ban_Dauky vào DB.")]
        public object Update_Ware_Hanghoa_Ban_Dauky(Ecm.Domain.Ware.Ware_Hanghoa_Ban_Dauky Ware_Hanghoa_Ban_Dauky)
        {
            return _Ware_Hanghoa_Ban_Dauky_Service.Update_Ware_Hanghoa_Ban_Dauky(Ware_Hanghoa_Ban_Dauky);
        }

        [WebMethod(Description = "Delete đối tượng Ware_Hanghoa_Ban_Dauky vào DB.")]
        public object Delete_Ware_Hanghoa_Ban_Dauky(Ecm.Domain.Ware.Ware_Hanghoa_Ban_Dauky Ware_Hanghoa_Ban_Dauky)
        {
            return _Ware_Hanghoa_Ban_Dauky_Service.Delete_Ware_Hanghoa_Ban_Dauky(Ware_Hanghoa_Ban_Dauky);
        }

        [WebMethod(Description = "Update collection Ware_Hanghoa_Ban_Dauky vào DB.")]
        public object Update_Ware_Hanghoa_Ban_Dauky_Collection(DataSet dsCollection)
        {
            return _Ware_Hanghoa_Ban_Dauky_Service.Update_Ware_Hanghoa_Ban_Dauky_Collection(dsCollection);
        }
        #endregion

        #region Ware_Hanghoa_Mua_Dauky

        //[WebMethod(Description = "Trả về một dataset Hanghoa_Mua_Dauky")]
        //public string Get_All_Ware_Hanghoa_Mua_Dauky()
        //{
        //    return _Ware_Hanghoa_Mua_Dauky_Service.Get_All_Ware_Hanghoa_Mua_Dauky();
        //}

        //[WebMethod(Description = "Insert đối tượng Ware_Hanghoa_Mua_Dauky vào DB.")]
        //public object Insert_Ware_Hanghoa_Mua_Dauky(Ecm.Domain.Ware.Ware_Hanghoa_Mua_Dauky Ware_Hanghoa_Mua_Dauky)
        //{
        //    return _Ware_Hanghoa_Mua_Dauky_Service.Insert_Ware_Hanghoa_Mua_Dauky(Ware_Hanghoa_Mua_Dauky);
        //}

        //[WebMethod(Description = "Update đối tượng Ware_Hanghoa_Mua_Dauky vào DB.")]
        //public object Update_Ware_Hanghoa_Mua_Dauky(Ecm.Domain.Ware.Ware_Hanghoa_Mua_Dauky Ware_Hanghoa_Mua_Dauky)
        //{
        //    return _Ware_Hanghoa_Mua_Dauky_Service.Update_Ware_Hanghoa_Mua_Dauky(Ware_Hanghoa_Mua_Dauky);
        //}

        //[WebMethod(Description = "Delete đối tượng Ware_Hanghoa_Mua_Dauky vào DB.")]
        //public object Delete_Ware_Hanghoa_Mua_Dauky(Ecm.Domain.Ware.Ware_Hanghoa_Mua_Dauky Ware_Hanghoa_Mua_Dauky)
        //{
        //    return _Ware_Hanghoa_Mua_Dauky_Service.Delete_Ware_Hanghoa_Mua_Dauky(Ware_Hanghoa_Mua_Dauky);
        //}

        //[WebMethod(Description = "Update collection Ware_Hanghoa_Mua_Dauky vào DB.")]
        //public object Update_Ware_Hanghoa_Mua_Dauky_Collection(DataSet dsCollection)
        //{
        //    return _Ware_Hanghoa_Mua_Dauky_Service.Update_Ware_Hanghoa_Mua_Dauky_Collection(dsCollection);
        //}

        #endregion

        #region Ware_Donmuahang
        [WebMethod(Description = "Trả về một dataset Donmuahang")]
        public string Get_All_Ware_Donmuahang(object Ngay_Chungtu)
        {
            return _Ware_Donmuahang_Service.Get_All_Ware_Donmuahang(Ngay_Chungtu);
        }

        [WebMethod(Description = "Trả về một dataset Donmuahang")]
        public string Get_All_Ware_Donmuahang_Chitiet_By_Donmuahang(object id_donmuahang)
        {
            return _Ware_Donmuahang_Service.Get_All_Ware_Donmuahang_Chitiet_By_Donmuahang(id_donmuahang);
        }

        [WebMethod(Description = "Trả về một dataset Donmuahang")]
        public string Get_All_Ware_Ncc_By_Donmuahang_Chitiet(object id_donmuahang_chitiet)
        {
            return _Ware_Donmuahang_Service.Get_All_Ware_Ncc_By_Donmuahang_Chitiet(id_donmuahang_chitiet);
        }

        [WebMethod(Description = "Trả về một dataset Donmuahang")]
        public string Get_All_Ware_Ncc_By_Donmuahang(object id_donmuahang)
        {
            return _Ware_Donmuahang_Service.Get_All_Ware_Ncc_By_Donmuahang(id_donmuahang);
        }

        [WebMethod(Description = "Insert đối tượng Ware_Donmuahang vào DB.")]
        public object Insert_Ware_Donmuahang(Ecm.Domain.Ware.Ware_Donmuahang Ware_Donmuahang)
        {
            return _Ware_Donmuahang_Service.Insert_Ware_Donmuahang(Ware_Donmuahang);
        }

        [WebMethod(Description = "Update đối tượng Ware_Donmuahang vào DB.")]
        public object Update_Ware_Donmuahang(Ecm.Domain.Ware.Ware_Donmuahang Ware_Donmuahang)
        {
            return _Ware_Donmuahang_Service.Update_Ware_Donmuahang(Ware_Donmuahang);
        }

        [WebMethod(Description = "Delete đối tượng Ware_Donmuahang vào DB.")]
        public object Delete_Ware_Donmuahang(Ecm.Domain.Ware.Ware_Donmuahang Ware_Donmuahang)
        {
            return _Ware_Donmuahang_Service.Delete_Ware_Donmuahang(Ware_Donmuahang);
        }

        [WebMethod(Description = "Update collection Ware_Donmuahang_Chitiet vào DB.")]
        public object Update_Ware_Donmuahang_Chitiet_Collection(DataSet dsCollection)
        {
            return _Ware_Donmuahang_Service.Update_Ware_Donmuahang_Chitiet_Collection(dsCollection);
        }

        [WebMethod(Description = "Update collection Ware_Donmuahang_Chitiet_Ncc vào DB.")]
        public object Update_Ware_Donmuahang_Chitiet_Ncc_Collection(DataSet dsCollection)
        {
            return _Ware_Donmuahang_Service.Update_Ware_Donmuahang_Chitiet_Ncc_Collection(dsCollection);
        }

        [WebMethod(Description = "Tra ve ds nxt hang hoa mua")]
        public string Get_All_Ware_Nxt_Hhmua(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Kho_Hanghoa_Mua)
        {
            return _Ware_Donmuahang_Service.Get_All_Ware_Nxt_Hhmua(Ngay_Batdau, Ngay_Ketthuc, Id_Kho_Hanghoa_Mua);
        }

        [WebMethod(Description = "Tra ve ds nxt hang hoa bán")]
        public string Get_All_Ware_Nxt_HhBan(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Cuahang_Ban)
        {
            return _Ware_Donmuahang_Service.Get_All_Ware_Nxt_HhBan(Ngay_Batdau, Ngay_Ketthuc, Id_Cuahang_Ban);
        }

        #endregion

        #region Ware_Donmuahang_Kh
        [WebMethod(Description = "Trả về một dataset Donmuahang_Kh")]
        public string Get_All_Ware_Donmuahang_Kh(object Ngay_Chungtu)
        {
            return _Ware_Donmuahang_Kh_Service.Get_All_Ware_Donmuahang_Kh(Ngay_Chungtu);
        }

        [WebMethod(Description = "Trả về một dataset Donmuahang_Kh")]
        public string Get_All_Ware_Donmuahang_Kh_Chitiet_By_Donmuahang_Kh(object id_Donmuahang_Kh)
        {
            return _Ware_Donmuahang_Kh_Service.Get_All_Ware_Donmuahang_Kh_Chitiet_By_Donmuahang_Kh(id_Donmuahang_Kh);
        }

        [WebMethod(Description = "Insert đối tượng Ware_Donmuahang_Kh vào DB.")]
        public object Insert_Ware_Donmuahang_Kh(Ecm.Domain.Ware.Ware_Donmuahang_Kh Ware_Donmuahang_Kh)
        {
            return _Ware_Donmuahang_Kh_Service.Insert_Ware_Donmuahang_Kh(Ware_Donmuahang_Kh);
        }

        [WebMethod(Description = "Update đối tượng Ware_Donmuahang_Kh vào DB.")]
        public object Update_Ware_Donmuahang_Kh(Ecm.Domain.Ware.Ware_Donmuahang_Kh Ware_Donmuahang_Kh)
        {
            return _Ware_Donmuahang_Kh_Service.Update_Ware_Donmuahang_Kh(Ware_Donmuahang_Kh);
        }

        [WebMethod(Description = "Delete đối tượng Ware_Donmuahang_Kh vào DB.")]
        public object Delete_Ware_Donmuahang_Kh(Ecm.Domain.Ware.Ware_Donmuahang_Kh Ware_Donmuahang_Kh)
        {
            return _Ware_Donmuahang_Kh_Service.Delete_Ware_Donmuahang_Kh(Ware_Donmuahang_Kh);
        }

        [WebMethod(Description = "Update collection Ware_Donmuahang_Kh_Chitiet vào DB.")]
        public object Update_Ware_Donmuahang_Kh_Chitiet_Collection(DataSet dsCollection)
        {
            return _Ware_Donmuahang_Kh_Service.Update_Ware_Donmuahang_Kh_Chitiet_Collection(dsCollection);
        }
        #endregion

        #region Ware_Hdmuahang
        [WebMethod(Description = "Trả về một dataset Hdmuahang")]
        public string Get_All_Ware_Hdmuahang(object Ngay_Chungtu)
        {
            return _Ware_Hdmuahang_Service.Get_All_Ware_Hdmuahang(Ngay_Chungtu);
        }

        [WebMethod(Description = "Trả về một dataset Hdmuahang")]
        public string Get_All_Ware_Hdmuahang_Chitiet_By_Hdmuahang(object id_donmuahang)
        {
            return _Ware_Hdmuahang_Service.Get_All_Ware_Hdmuahang_Chitiet_By_Hdmuahang(id_donmuahang);
        }

        [WebMethod(Description = "Trả về một dataset Hdmuahang")]
        public string Get_All_Ware_Hdmuahang_ByNhacungcap(object Id_Nhacungcap)
        {
            return _Ware_Hdmuahang_Service.Get_All_Ware_Hdmuahang_ByNhacungcap(Id_Nhacungcap);
        }

        [WebMethod(Description = "nhanvuong. Trả về một dataset Hdmuahang by NCC, ngày bắt đầu, ngày kết thúc")]
        public string Get_All_Ware_Hdmuahang_ByNhacungcap_ByDate(object Id_Nhacungcap, object Ngay_Batdau, object Ngay_Ketthuc)
        {
            return _Ware_Hdmuahang_Service.Get_All_Ware_Hdmuahang_ByNhacungcap_ByDate(Id_Nhacungcap, Ngay_Batdau, Ngay_Ketthuc);
        }

        [WebMethod(Description = "Kiểm tra hóa đơn mua hàng đã được chi tiền")]
        public bool Check_Hdmuahang_Dachi(object Chungtu_Goc)
        {
            return _Ware_Hdmuahang_Service.Check_Hdmuahang_Dachi(Chungtu_Goc);
        }

        [WebMethod(Description = "Insert đối tượng Ware_Hdmuahang vào DB.")]
        public object Insert_Ware_Hdmuahang(Ecm.Domain.Ware.Ware_Hdmuahang Ware_Hdmuahang)
        {
            return _Ware_Hdmuahang_Service.Insert_Ware_Hdmuahang(Ware_Hdmuahang);
        }

        [WebMethod(Description = "Update đối tượng Ware_Hdmuahang vào DB.")]
        public object Update_Ware_Hdmuahang(Ecm.Domain.Ware.Ware_Hdmuahang Ware_Hdmuahang)
        {
            return _Ware_Hdmuahang_Service.Update_Ware_Hdmuahang(Ware_Hdmuahang);
        }

        [WebMethod(Description = "Delete đối tượng Ware_Hdmuahang vào DB.")]
        public object Delete_Ware_Hdmuahang(Ecm.Domain.Ware.Ware_Hdmuahang Ware_Hdmuahang)
        {
            return _Ware_Hdmuahang_Service.Delete_Ware_Hdmuahang(Ware_Hdmuahang);
        }

        [WebMethod(Description = "Update collection Ware_Hdmuahang_Chitiet vào DB.")]
        public object Update_Ware_Hdmuahang_Chitiet_Collection(DataSet dsCollection)
        {
            return _Ware_Hdmuahang_Service.Update_Ware_Hdmuahang_Chitiet_Collection(dsCollection);
        }
        #endregion

        #region Ware_Hdbanhang

        [WebMethod(Description = "Update đối tượng Ware_Hdbanhang vào DB.")]
        public object Ware_Hdbanhang_Update_Duyet_Mobile(object Id_Hdbanhang, object Cap_Duyet, object Ghichu_Edit)
        {
            return _Ware_Hdbanhang_Service.Ware_Hdbanhang_Update_Duyet_Mobile(Id_Hdbanhang, Cap_Duyet, Ghichu_Edit);
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang duyệt mobile")]
        public string Ware_Hdbanhang_Select_4Kiemduyet_Mobile(object Ngay_Chungtu, object Cap_Duyet)
        {
            return _Ware_Hdbanhang_Service.Ware_Hdbanhang_Select_4Kiemduyet_Mobile(Ngay_Chungtu, Cap_Duyet);
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_Ware_Hdbanhang()
        {
            return _Ware_Hdbanhang_Service.Get_All_Ware_Hdbanhang();
        }

        [WebMethod(Description = "nhanvuong - Trả về một dataset hóa đơn bán hàng + xuất kho bán hàng")]
        public string Get_All_Ware_Hdbanhang_Xuatkho()
        {
            return _Ware_Hdbanhang_Service.Get_All_Ware_Hdbanhang_Xuatkho();
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_Ware_Hdbanhang_ById_Hdbanhang(object Id_Hdbanhang)
        {
            return _Ware_Hdbanhang_Service.Get_All_Ware_Hdbanhang_ById_Hdbanhang(Id_Hdbanhang);
        }


        [WebMethod(Description = "Trả về một dataset Hdbanhang_ById_HhBan_TheoCap")]
        public string Get_All_Ware_Hdbanhang_ById_HhBan_TheoCap(object Id_Khachhang, object Id_Hanghoa_Ban, object Id_Donvitinh)
        {
            return _Ware_Hdbanhang_Service.Get_All_Ware_Hdbanhang_ById_HhBan_TheoCap(Id_Khachhang, Id_Hanghoa_Ban, Id_Donvitinh);
        }


        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_Ware_Hdbanhang_ById_khachhang(object id_Khachhang)
        {
            return _Ware_Hdbanhang_Service.Get_All_Ware_Hdbanhang_ById_khachhang(id_Khachhang);
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_Ware_Hdbanhang_ByDate(object ngay_Bd, object ngay_Kt, object id_cuahang_ban)
        {
            return _Ware_Hdbanhang_Service.Get_All_Ware_Hdbanhang_ByDate(ngay_Bd, ngay_Kt, id_cuahang_ban);
        }


        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_Ware_Hdbanhang_ByCuahang(object Id_Cuahang_Ban)
        {
            return _Ware_Hdbanhang_Service.Get_All_Ware_Hdbanhang_ByCuahang(Id_Cuahang_Ban);
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_Ware_Hdbanhang_ByKhoHanghoa(object Id_Kho_Hanghoa_Mua)
        {
            return _Ware_Hdbanhang_Service.Get_All_Ware_Hdbanhang_ByKhoHanghoa(Id_Kho_Hanghoa_Mua);
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_Ware_Hdbanhang_Hhban()
        {
            return _Ware_Hdbanhang_Service.Get_All_Ware_Hdbanhang_Hhban();
        }

        [WebMethod(Description = "Trả về một dataset Hanghoa_Dinhgia_TheoCap By id hàng hóa bán")]
        public string Get_All_Ware_Hanghoa_Dinhgia_By_Id_HhBan_TheoCap(object Id_Hanghoa_Ban)
        {
            return _Ware_Hanghoa_Dinhgia_Service.Get_All_Ware_Hanghoa_Dinhgia_By_Id_HhBan_TheoCap(Id_Hanghoa_Ban);
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_Ware_Hdbanhang_Hhmua()
        {
            return _Ware_Hdbanhang_Service.Get_All_Ware_Hdbanhang_Hhmua();
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_Ware_Hdbanhang_Novat_Hhmua()
        {
            return _Ware_Hdbanhang_Service.Get_All_Ware_Hdbanhang_Novat_Hhmua();
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_Ware_Hdbanhang_Novat_Hhmua_ByKhohh(object Id_Kho_Hanghoa_Mua)
        {
            return _Ware_Hdbanhang_Service.Get_All_Ware_Hdbanhang_Novat_Hhmua_ByKhohh(Id_Kho_Hanghoa_Mua);
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_Ware_Hdbanhang_Novat_Hhmua_ByKhohh_2(object Id_Kho_Hanghoa_Mua, object Ngay_Chungtu)
        {
            return _Ware_Hdbanhang_Service.Get_All_Ware_Hdbanhang_Novat_Hhmua_ByKhohh(Id_Kho_Hanghoa_Mua, Ngay_Chungtu);
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_Ware_Hdbanhang_Novat_Hhban()
        {
            return _Ware_Hdbanhang_Service.Get_All_Ware_Hdbanhang_Novat_Hhban();
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_Ware_Hdbanhang_Novat_Hhban_ByCuahang(object Id_Cuahang_Ban)
        {
            return _Ware_Hdbanhang_Service.Get_All_Ware_Hdbanhang_Novat_Hhban_ByCuahang(Id_Cuahang_Ban);
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_Ware_Hdbanhang_Novat_Hhban_ByCuahang_2(object Id_Cuahang_Ban, object Ngay_Chungtu)
        {
            return _Ware_Hdbanhang_Service.Get_All_Ware_Hdbanhang_Novat_Hhban_ByCuahang(Id_Cuahang_Ban, Ngay_Chungtu);
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_Ware_Hdbanhang_Novat_Hhban_ByCuahang_3(object Id_Cuahang_Ban, object Ngay_Chungtu, object Id_Nhansu_Lap)
        {
            return _Ware_Hdbanhang_Service.Get_All_Ware_Hdbanhang_Novat_Hhban_ByCuahang(Id_Cuahang_Ban, Ngay_Chungtu, Id_Nhansu_Lap);
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_Ware_Hdbanhang_Novat_Hhban_ByCuahang_Khachhang(object Id_Cuahang_Ban, object Ngay_Chungtu, object Id_Nhansu_Lap, object Id_Khachhang)
        {
            return _Ware_Hdbanhang_Service.Get_All_Ware_Hdbanhang_Novat_Hhban_ByCuahang_Khachhang(Id_Cuahang_Ban, Ngay_Chungtu, Id_Nhansu_Lap, Id_Khachhang);
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_Ware_Hdbanhang_Novat_Hhban_Edit(object Id_Cuahang_Ban, object Ngay_Chungtu, object Id_Nhansu_Lap)
        {
            return _Ware_Hdbanhang_Service.Get_All_Ware_Hdbanhang_Novat_Hhban_Edit(Id_Cuahang_Ban, Ngay_Chungtu, Id_Nhansu_Lap);
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_Ware_Hdbanhang_Novat_Hhban_ByCuahang_IdKhachhang(object Id_Cuahang_Ban, object Ngay_Chungtu, object Id_Khachhang)
        {
            return _Ware_Hdbanhang_Service.Get_All_Ware_Hdbanhang_Novat_Hhban_ByCuahang_IdKhachhang(Id_Cuahang_Ban, Ngay_Chungtu, Id_Khachhang);
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_Ware_Hdbanhang_Novat_Hhban_Cash_ByCuahang(object Id_Cuahang_Ban)
        {
            return _Ware_Hdbanhang_Service.Get_All_Ware_Hdbanhang_Novat_Hhban_Cash_ByCuahang(Id_Cuahang_Ban);
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_Ware_Hdbanhang_Chitiet_By_Hdbanhang(object id_donbanhang)
        {
            return _Ware_Hdbanhang_Service.Get_All_Ware_Hdbanhang_Chitiet_ByHdbanhang(id_donbanhang);
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_Ware_Hdbanhang_Chitiet_ByHdbanhang_Mail(object id_donbanhang)
        {
            return _Ware_Hdbanhang_Service.Get_All_Ware_Hdbanhang_Chitiet_ByHdbanhang_Mail(id_donbanhang);
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang_Chitiet")]
        public string Get_All_Ware_Hdbanhang_Chitiet_Dudoan_Dathang(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Cuahang_Ban, object Id_Nhansu)
        {
            return _Ware_Hdbanhang_Service.Get_All_Ware_Hdbanhang_Chitiet_Dudoan_Dathang(Ngay_Batdau, Ngay_Ketthuc, Id_Cuahang_Ban, Id_Nhansu);
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_Ware_Hdbanhang_Chitiet_ByHdbanhang_Sochungtu(object Sochungtu)
        {
            return _Ware_Hdbanhang_Service.Get_All_Ware_Hdbanhang_Chitiet_ByHdbanhang_Sochungtu(Sochungtu);
        }
        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_Ware_Hdbanhang_Chitiet_Log_ByHdbanhang(object id_donbanhang)
        {
            return _Ware_Hdbanhang_Service.Get_All_Ware_Hdbanhang_Chitiet_Log_ByHdbanhang(id_donbanhang);
        }

        [WebMethod(Description = "Insert đối tượng Ware_Hdbanhang vào DB.")]
        public object Insert_Ware_Hdbanhang(Ecm.Domain.Ware.Ware_Hdbanhang Ware_Hdbanhang)
        {
            return _Ware_Hdbanhang_Service.Insert_Ware_Hdbanhang(Ware_Hdbanhang);
        }

        [WebMethod(Description = "Insert đối tượng Ware_Hdbanhang vào DB.")]
        public object Insert_Ware_Hdbanhang_New(Ecm.Domain.Ware.Ware_Hdbanhang Ware_Hdbanhang)
        {
            return _Ware_Hdbanhang_Service.Insert_Ware_Hdbanhang_New(Ware_Hdbanhang);
        }

        [WebMethod(Description = "Insert đối tượng Ware_Hdbanhang vào DB.")]
        public object Insert_Ware_Hdbanhang_New_Mobile(String objWare_Hdbanhang)
        {
            Ecm.Domain.Ware.Ware_Hdbanhang obj = new Domain.Ware.Ware_Hdbanhang();
            obj = JsonConvert.DeserializeObject<Ecm.Domain.Ware.Ware_Hdbanhang>(objWare_Hdbanhang);
            return _Ware_Hdbanhang_Service.Insert_Ware_Hdbanhang_New(obj);
        }

        [WebMethod(Description = "Update đối tượng Ware_Hdbanhang vào DB.")]
        public object Update_Ware_Hdbanhang_New_Mobile(String objWare_Hdbanhang)
        {
            Ecm.Domain.Ware.Ware_Hdbanhang obj = new Domain.Ware.Ware_Hdbanhang();
            obj = JsonConvert.DeserializeObject<Ecm.Domain.Ware.Ware_Hdbanhang>(objWare_Hdbanhang);
            return _Ware_Hdbanhang_Service.Update_Ware_Hdbanhang_New(obj);
        }

        [WebMethod(Description = "Delete đối tượng Ware_Hdbanhang vào DB.")]
        public object Delete_Ware_Hdbanhang_New_Mobile(String objWare_Hdbanhang)
        {
            Ecm.Domain.Ware.Ware_Hdbanhang obj = new Domain.Ware.Ware_Hdbanhang();
            obj = JsonConvert.DeserializeObject<Ecm.Domain.Ware.Ware_Hdbanhang>(objWare_Hdbanhang);
            return _Ware_Hdbanhang_Service.Delete_Ware_Hdbanhang(obj);
        }

        [WebMethod(Description = ".")]
        public bool Ware_Hdbanhang_Check_Hoadon_IsLast(object Id_Hdbanhang)
        {
            return _Ware_Hdbanhang_Service.Ware_Hdbanhang_Check_Hoadon_IsLast(Id_Hdbanhang);
        }

        [WebMethod(Description = ".")]
        public Boolean Ware_Hdbanhang_Check_Hoadon_Congno10(object Id_Hdbanhang)
        {
            return _Ware_Hdbanhang_Service.Ware_Hdbanhang_Check_Hoadon_Congno10(Id_Hdbanhang);
        }

        //[WebMethod(Description = "Insert đối tượng Ware_Hdbanhang vào DB.")]
        //public object Insert_Ware_Hdbanhang_Mobile(Dictionary<string, string> List_ware_Hdbanhang)
        //{
        //    return _Ware_Hdbanhang_Service.Insert_Ware_Hdbanhang_Mobile(List_ware_Hdbanhang);
        //}

        //[WebMethod(Description = "Upate đối tượng Ware_Hdbanhang vào DB.")]
        //public object Update_Ware_Hdbanhang_Mobile(Dictionary<string, string> List_ware_Hdbanhang)
        //{
        //    return _Ware_Hdbanhang_Service.Update_Ware_Hdbanhang_Mobile(List_ware_Hdbanhang);
        //}

        [WebMethod(Description = "Update đối tượng Ware_Hdbanhang vào DB.")]
        public object Update_Ware_Hdbanhang(Ecm.Domain.Ware.Ware_Hdbanhang Ware_Hdbanhang)
        {
            return _Ware_Hdbanhang_Service.Update_Ware_Hdbanhang(Ware_Hdbanhang);
        }

        [WebMethod(Description = "Update đối tượng Ware_Hdbanhang vào DB.")]
        public object Update_Ware_Hdbanhang_New(Ecm.Domain.Ware.Ware_Hdbanhang Ware_Hdbanhang)
        {
            return _Ware_Hdbanhang_Service.Update_Ware_Hdbanhang_New(Ware_Hdbanhang);
        }

        [WebMethod(Description = "Update đối tượng Ware_Hdbanhang vào DB.")]
        public object Ware_Hdbanhang_Update_Doc(Ecm.Domain.Ware.Ware_Hdbanhang Ware_Hdbanhang)
        {
            return _Ware_Hdbanhang_Service.Ware_Hdbanhang_Update_Doc(Ware_Hdbanhang);
        }

        [WebMethod(Description = "Delete đối tượng Ware_Hdbanhang vào DB.")]
        public object Delete_Ware_Hdbanhang(Ecm.Domain.Ware.Ware_Hdbanhang Ware_Hdbanhang)
        {
            return _Ware_Hdbanhang_Service.Delete_Ware_Hdbanhang(Ware_Hdbanhang);
        }

        [WebMethod(Description = "Update collection Ware_Hdbanhang_Chitiet vào DB.")]
        public object Update_Ware_Hdbanhang_Chitiet_Collection(DataSet dsCollection)
        {
            return _Ware_Hdbanhang_Service.Update_Ware_Hdbanhang_Chitiet_Collection(dsCollection);
        }

        [WebMethod(Description = "Update collection Ware_Hdbanhang_Chitiet vào DB.")]
        public object Update_Ware_Hdbanhang_Chitiet_Log_Collection(DataSet dsCollection)
        {
            return _Ware_Hdbanhang_Service.Update_Ware_Hdbanhang_Chitiet_Log_Collection(dsCollection);
        }

        [WebMethod(Description = "Trả về ds hàng hóa nxt")]
        public string Rptware_Nxt_Hhban(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Cuahang_Ban, object id_Hanghoa_Ban, object id_Loai_Hanghoa_Ban)
        {
            return _Ware_Hdbanhang_Service.Rptware_Nxt_Hhban(Ngay_Batdau, Ngay_Ketthuc, Id_Cuahang_Ban, id_Hanghoa_Ban, id_Loai_Hanghoa_Ban);
        }

        [WebMethod(Description = "Trả về ds hàng hóa nxt")]
        public string Rptware_Nxt_Hhban_ByKhsx(object Ngay_Baocao, object Id_Cuahang_Ban)
        {
            return _Ware_Hdbanhang_Service.Rptware_Nxt_Hhban_ByKhsx(Ngay_Baocao, Id_Cuahang_Ban);
        }

        [WebMethod(Description = "Get về danh sách hàng hóa (đã đc định giá) sau khi thông kê")]
        public string Get_All_Ware_Dm_Hanghoa_Ban_Dinhgia_After_Thongke(object Id_Cuahang_Ban)
        {
            return _Ware_Hdbanhang_Service.Get_All_Ware_Dm_Hanghoa_Ban_Dinhgia_After_Thongke(Id_Cuahang_Ban);
        }

        #endregion

        #region ware_hdbanhang_Vat

        [WebMethod(Description = "")]
        public object Delete_Ware_Hdbanhang_Vat(Ecm.Domain.Ware.Ware_Hdbanhang_Vat _Ware_Hdbanhang_Vat)
        {
            return _Ware_Hdbanhang_Vat_Service.Delete_Ware_Hdbanhang_Vat(_Ware_Hdbanhang_Vat);
        }

        [WebMethod(Description = "")]
        public object Insert_Ware_Hdbanhang_Vat(Ecm.Domain.Ware.Ware_Hdbanhang_Vat _Ware_Hdbanhang_Vat)
        {
            return _Ware_Hdbanhang_Vat_Service.Insert_Ware_Hdbanhang_Vat(_Ware_Hdbanhang_Vat);
        }

        [WebMethod(Description = "")]
        public object Update_Ware_Hdbanhang_Vat(Ecm.Domain.Ware.Ware_Hdbanhang_Vat _Ware_Hdbanhang_Vat)
        {
            return _Ware_Hdbanhang_Vat_Service.Update_Ware_Hdbanhang_Vat(_Ware_Hdbanhang_Vat);
        }

        [WebMethod(Description = "")]
        public object Update_Ware_Hdbanhang_Chitiet_Vat_Collection(DataSet dsCollection)
        {
            return _Ware_Hdbanhang_Vat_Service.Update_Ware_Hdbanhang_Chitiet_Vat_Collection(dsCollection);
        }

        [WebMethod(Description = "")]
        public string Ware_Hdbanhang_Vat_SelectAll()
        {
            return _Ware_Hdbanhang_Vat_Service.Ware_Hdbanhang_Vat_SelectAll();
        }

        [WebMethod(Description = "")]
        public string Ware_Hdbanhang_Vat_SelectAll_Hhban(object Id_Cuahang_Ban, object Ngay_Chungtu, object Id_Nhansu_Lap, object Id_Khachhang)
        {
            return _Ware_Hdbanhang_Vat_Service.Ware_Hdbanhang_Vat_SelectAll_Hhban(Id_Cuahang_Ban, Ngay_Chungtu, Id_Nhansu_Lap, Id_Khachhang);
        }

        [WebMethod(Description = "")]
        public string Ware_Hdbanhang_Vat_SelectBy_Id_Hdbanhang(object Id_Hdbanhang)
        {
            return _Ware_Hdbanhang_Vat_Service.Ware_Hdbanhang_Vat_SelectBy_Id_Hdbanhang(Id_Hdbanhang);
        }

        [WebMethod(Description = ".")]
        public bool Ware_Hdbanhang_Vat_Check_Ngayxuat(object Ngay_Xuat)
        {
            return _Ware_Hdbanhang_Vat_Service.Ware_Hdbanhang_Vat_Check_Ngayxuat(Ngay_Xuat);
        }

        [WebMethod(Description = "")]
        public string Ware_Hdbanhang_Vat_SelectByCuahang(object Id_Cuahang_Ban)
        {
            return _Ware_Hdbanhang_Vat_Service.Ware_Hdbanhang_Vat_SelectByCuahang(Id_Cuahang_Ban);
        }

        [WebMethod(Description = "")]
        public string Ware_Hdbanhang_Vat_SelectByDate(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Cuahang_Ban)
        {
            return _Ware_Hdbanhang_Vat_Service.Ware_Hdbanhang_Vat_SelectByDate(Ngay_Batdau, Ngay_Ketthuc, Id_Cuahang_Ban);
        }

        [WebMethod(Description = "")]
        public string Ware_Hdbanhang_Chitiet_Vat_SelectById_Hdbanhang_Vat(object Id_Hdbanhang)
        {
            return _Ware_Hdbanhang_Vat_Service.Ware_Hdbanhang_Chitiet_Vat_SelectById_Hdbanhang_Vat(Id_Hdbanhang);
        }

        [WebMethod(Description = "")]
        public string ware_Hdbanhang_Chitiet_CheckSL(object Id_Hanghoa_ban, object Id_Donvitinh, object Id_Hdbanhang_Chitiet_Vat)
        {
            return _Ware_Hdbanhang_Vat_Service.ware_Hdbanhang_Chitiet_CheckSL(Id_Hanghoa_ban, Id_Donvitinh, Id_Hdbanhang_Chitiet_Vat);
        }

        #endregion

        #region Ware_Xuatkho_Banhang nhanvuong - 11/10/2010

        [WebMethod(Description = "")]
        public string Get_All_Ware_Congno_Phaithu(object Thang, object Id_Khachhang, object Id_Nhansu_Bh)
        {
            return _Ware_Xuatkho_Banhang_Service.Get_All_Ware_Congno_Phaithu(Thang, Id_Khachhang, Id_Nhansu_Bh);
        }

        [WebMethod(Description = "Trả về một dataset Xuatkho_banhang By Id_Cuahang_Ban")]
        public string Get_All_Ware_Xuatkho_Banhang_ByCuahang(object Id_Cuahang_Ban)
        {
            return _Ware_Xuatkho_Banhang_Service.Get_All_Ware_Xuatkho_Banhang_ByCuahang(Id_Cuahang_Ban);
        }

        [WebMethod(Description = "Trả về một dataset Xuatkho_banhang By Id_Cuahang_Ban By Date (nếu ngay_chungtu = null --> lấy ngày hiện tại")]
        public string Get_All_Ware_Xuatkho_Banhang_ByCuahang_ByDate(object Id_Cuahang_Ban, object Ngay_Chungtu)
        {
            return _Ware_Xuatkho_Banhang_Service.Get_All_Ware_Xuatkho_Banhang_ByCuahang_ByDate(Id_Cuahang_Ban, Ngay_Chungtu);
        }

        [WebMethod(Description = "Trả về một dataset Xuatkho_banhang By Id_Cuahang_Ban By Date (nếu ngay_chungtu = null --> lấy ngày hiện tại")]
        public string Ware_Doituong_SelectByCuahang_ByDate(object Id_Cuahang_Ban, object Ngay_Chungtu, object Id_Dieuxe)
        {
            return _Ware_Xuatkho_Banhang_Service.Ware_Doituong_SelectByCuahang_ByDate(Id_Cuahang_Ban, Ngay_Chungtu, Id_Dieuxe);
        }

        [WebMethod(Description = "Trả về một dataset Xuatkho_banhang By Id_Cuahang_Ban By Date (nếu ngay_chungtu = null --> lấy ngày hiện tại")]
        public string Get_All_Ware_Xuatkho_Banhang_ByCuahang_ByKhachhang(object Id_Khachhang, object Ngay_Chungtu, object Id_Cuahang_Ban)
        {
            return _Ware_Xuatkho_Banhang_Service.Get_All_Ware_Xuatkho_Banhang_ByCuahang_ByKhachhang(Id_Khachhang, Ngay_Chungtu, Id_Cuahang_Ban);
        }

        [WebMethod(Description = "Trả về một dataset Xuatkho_banhang By Id_Cuahang_Ban By Date (nếu ngay_chungtu = null --> lấy ngày hiện tại")]
        public string Ware_Xuatkho_Banhang_ById_Dieuxe(object Id_Dieuxe)
        {
            return _Ware_Xuatkho_Banhang_Service.Ware_Xuatkho_Banhang_ById_Dieuxe(Id_Dieuxe);
        }

        [WebMethod(Description = "Trả về một dataset Xuatkho_banhang vat")]
        public string Get_RptWare_Tonghop_Hoadon_Banhang_Thue(object ngay_Batdau, object ngay_Ketthuc)
        {
            return _Ware_Xuatkho_Banhang_Service.Get_RptWare_Tonghop_Hoadon_Banhang_Thue(ngay_Batdau, ngay_Ketthuc);
        }

        [WebMethod(Description = "Trả về một dataset xuatkho_banhang")]
        public string Get_All_Ware_Xuatkho_Banhang()
        {
            return _Ware_Xuatkho_Banhang_Service.Get_All_Ware_Xuatkho_Banhang();
        }

        [WebMethod(Description = "Trả về một dataset xuatkho_banhang by Id")]
        public string Get_All_Ware_Xuatkho_Banhang_ById(object id_xuatkho_banhang)
        {
            return _Ware_Xuatkho_Banhang_Service.Get_All_Ware_Xuatkho_Banhang_ById(id_xuatkho_banhang);
        }

        [WebMethod(Description = "Trả về một dataset xuatkho_banhang_chitiet by id_xuatkho_banhang")]
        public string Ware_Xuatkho_Banhang_Chitiet_SelectBy_Sochungtu(object Sochungtu)
        {
            return _Ware_Xuatkho_Banhang_Service.Ware_Xuatkho_Banhang_Chitiet_SelectBy_Sochungtu(Sochungtu);
        }

        [WebMethod(Description = "Trả về một dataset xuatkho_banhang by Id")]
        public string Ware_Xuatkho_Banhang_SelectBy_Sochungtu(object Sochungtu)
        {
            return _Ware_Xuatkho_Banhang_Service.Ware_Xuatkho_Banhang_SelectBy_Sochungtu(Sochungtu);
        }

        [WebMethod(Description = "Trả về một dataset xuatkho_banhang by Id_Khachhang")]
        public string Get_All_Ware_Xuatkho_Banhang_ById_Khachhang(object id_khachhang)
        {
            return _Ware_Xuatkho_Banhang_Service.Get_All_Ware_Xuatkho_Banhang_ById_Khachhang(id_khachhang);
        }

        [WebMethod(Description = "Trả về một dataset xuatkho_banhang by Sochungtu")]
        public string Get_All_Ware_Xuatkho_Banhang_Chitiet_ByHdbanhang_Sochungtu(object Sochungtu)
        {
            return _Ware_Xuatkho_Banhang_Service.Get_All_Ware_Xuatkho_Banhang_Chitiet_ByHdbanhang_Sochungtu(Sochungtu);
        }

        [WebMethod(Description = "Trả về một dataset xuatkho_banhang_chitiet by id_xuatkho_banhang")]
        public string Get_All_Ware_Xuatkho_Banhang_Chitiet_By_Id_Xuatkho_Banhang(object id_xuatkho_banhang)
        {
            return _Ware_Xuatkho_Banhang_Service.Get_All_Ware_Xuatkho_Banhang_Chitiet_By_Id_Xuatkho_Banhang(id_xuatkho_banhang);
        }

        [WebMethod(Description = "Insert đối tượng Ware_Xuatkho_Banhang vào DB.")]
        public object Insert_ware_xuatkho_banhang(Ecm.Domain.Ware.Ware_Xuatkho_Banhang Ware_Xuatkho_Banhang)
        {
            return _Ware_Xuatkho_Banhang_Service.Insert_Ware_Xuatkho_Banhang(Ware_Xuatkho_Banhang);
        }

        [WebMethod(Description = "Update đối tượng Ware_Xuatkho_Banhang vào DB.")]
        public object Update_ware_xuatkho_banhang(Ecm.Domain.Ware.Ware_Xuatkho_Banhang Ware_Xuatkho_Banhang)
        {
            return _Ware_Xuatkho_Banhang_Service.Update_Ware_Xuatkho_Banhang(Ware_Xuatkho_Banhang);
        }

        [WebMethod(Description = "Update đối tượng Ware_Xuatkho_Banhang vào DB.")]
        public object Ware_Xuatkho_Banhang_Update_Print(Ecm.Domain.Ware.Ware_Xuatkho_Banhang Ware_Xuatkho_Banhang)
        {
            return _Ware_Xuatkho_Banhang_Service.Ware_Xuatkho_Banhang_Update_Print(Ware_Xuatkho_Banhang);
        }

        [WebMethod(Description = "Update đối tượng Ware_Xuatkho_Banhang vào DB.")]
        public object Ware_Xuatkho_Banhang_Chitiet_UpdateSocai(object Id_Xuatkho_Banhang)
        {
            return _Ware_Xuatkho_Banhang_Service.Ware_Xuatkho_Banhang_Chitiet_UpdateSocai(Id_Xuatkho_Banhang);
        }

        [WebMethod(Description = "")]
        public object Ware_Xuatkho_Banhang_Update_Doc(object Id_Xuatkho_Banhang, object Doc_Process_Status, object Id_Nhansu_Lap)
        {
            return _Ware_Xuatkho_Banhang_Service.Ware_Xuatkho_Banhang_Update_Doc(Id_Xuatkho_Banhang, Doc_Process_Status, Id_Nhansu_Lap);
        }

        [WebMethod(Description = "Delete đối tượng Ware_Xuatkho_Banhang (và thông tin trong Ware_Xuatkho_Banhang_Chitiet).")]
        public object Delete_Ware_Xuatkho_Banhang(object Id_Xuatkho_Banhang)
        {
            return _Ware_Xuatkho_Banhang_Service.Delete_Ware_Xuatkho_Banhang(Id_Xuatkho_Banhang);
        }

        [WebMethod(Description = "Update ds Ware_Xuatkho_Banhang vào DB.")]
        public object Update_Ware_Xuatkho_Banhang_Collection(DataSet dsCollection)
        {
            return _Ware_Xuatkho_Banhang_Service.Update_Ware_Xuatkho_Banhang_Collection(dsCollection);
        }

        [WebMethod(Description = "Update ds Ware_Xuatkho_Banhang_chitiet vào DB.")]
        public object Update_Ware_Xuatkho_Banhang_Chitiet_Collection(DataSet dsCollection)
        {
            return _Ware_Xuatkho_Banhang_Service.Update_Ware_Xuatkho_Banhang_Chitiet_Collection(dsCollection);
        }
        #endregion

        #region Ware_Nhap_Hh_Ban

        [WebMethod(Description = "Trả về một dataset Nhap_Hh_Ban")]
        public string Ware_Nhap_Hh_Ban_Chitiet_SelectById_Nhap_Chitiet(object Id_Nhap_Hh_Ban_Chitiet)
        {
            return _Ware_Nhap_Hh_Ban_Service.Ware_Nhap_Hh_Ban_Chitiet_SelectById_Nhap_Chitiet(Id_Nhap_Hh_Ban_Chitiet);
        }

        [WebMethod(Description = "Trả về một dataset Nhap_Hh_Ban")]
        public string Get_All_Ware_Nhap_Hh_Ban(object Ngay_Chungtu, object Id_Kho)
        {
            return _Ware_Nhap_Hh_Ban_Service.Get_All_Ware_Nhap_Hh_Ban(Ngay_Chungtu, Id_Kho);
        }

        [WebMethod(Description = "Trả về một dataset Nhap_Hh_Ban")]
        public string Get_All_Ware_Nhap_Hh_Ban_Chitiet_By_Nhap_Hh_Ban(object id_Nhap_Hh_Ban)
        {
            return _Ware_Nhap_Hh_Ban_Service.Get_All_Ware_Nhap_Hh_Ban_Chitiet_By_Nhap_Hh_Ban(id_Nhap_Hh_Ban);
        }

        [WebMethod(Description = "Trả về một dataset Nhap_Hh_Ban")]
        public string Ware_Nhap_Hh_Ban_Chitiet_SelectAll_DateHang(object Id_Kho)
        {
            return _Ware_Nhap_Hh_Ban_Service.Ware_Nhap_Hh_Ban_Chitiet_SelectAll_DateHang(Id_Kho);
        }

        [WebMethod(Description = "Insert đối tượng Ware_Nhap_Hh_Ban vào DB.")]
        public object Insert_Ware_Nhap_Hh_Ban(Ecm.Domain.Ware.Ware_Nhap_Hh_Ban Ware_Nhap_Hh_Ban)
        {
            return _Ware_Nhap_Hh_Ban_Service.Insert_Ware_Nhap_Hh_Ban(Ware_Nhap_Hh_Ban);
        }

        [WebMethod(Description = "Insert đối tượng Ware_Nhap_Hh_Ban vào DB.")]
        public object Insert_Ware_Nhap_Hh_Ban_FromXuatchuyen(Ecm.Domain.Ware.Ware_Nhap_Hh_Ban Ware_Nhap_Hh_Ban)
        {
            return _Ware_Nhap_Hh_Ban_Service.Insert_Ware_Nhap_Hh_Ban_FromXuatchuyen(Ware_Nhap_Hh_Ban);
        }

        [WebMethod(Description = "Update đối tượng Ware_Nhap_Hh_Ban vào DB.")]
        public object Update_Ware_Nhap_Hh_Ban(Ecm.Domain.Ware.Ware_Nhap_Hh_Ban Ware_Nhap_Hh_Ban)
        {
            return _Ware_Nhap_Hh_Ban_Service.Update_Ware_Nhap_Hh_Ban(Ware_Nhap_Hh_Ban);
        }

        [WebMethod(Description = "Delete đối tượng Ware_Nhap_Hh_Ban vào DB.")]
        public object Delete_Ware_Nhap_Hh_Ban(Ecm.Domain.Ware.Ware_Nhap_Hh_Ban Ware_Nhap_Hh_Ban)
        {
            return _Ware_Nhap_Hh_Ban_Service.Delete_Ware_Nhap_Hh_Ban(Ware_Nhap_Hh_Ban);
        }

        [WebMethod(Description = "Update collection Ware_Nhap_Hh_Ban_Chitiet vào DB.")]
        public object Update_Ware_Nhap_Hh_Ban_Chitiet_Collection(DataSet dsCollection)
        {
            return _Ware_Nhap_Hh_Ban_Service.Update_Ware_Nhap_Hh_Ban_Chitiet_Collection(dsCollection);
        }

        [WebMethod(Description = "thong ke danh sach nhap hang")]
        public string Get_All_Ware_Nhap_Chitiet(object id_cuahang, object ngay_Batdau, object ngay_Ketthuc, object id_Hanghoa_Ban, object id_Loai_Hanghoa_Ban)
        {
            return _Ware_Nhap_Hh_Ban_Service.Get_All_Ware_Nhap_Chitiet(id_cuahang, ngay_Batdau, ngay_Ketthuc, id_Hanghoa_Ban, id_Loai_Hanghoa_Ban);
        }

        [WebMethod(Description = "thong ke danh sach nhap xuat hang")]
        public string GetAll_Ware_Nhapxuat_Chitiet(object id_cuahang, object ngay_Batdau, object ngay_Ketthuc, object id_Hanghoa_Ban, object id_Loai_Hanghoa_Ban)
        {
            return _Ware_Nhap_Hh_Ban_Service.GetAll_Ware_Nhapxuat_Chitiet(id_cuahang, ngay_Batdau, ngay_Ketthuc, id_Hanghoa_Ban, id_Loai_Hanghoa_Ban);
        }

        [WebMethod(Description = "thong ke danh sach nhap hang")]
        public string Get_All_Ware_Nhap_Tonghop(object id_cuahang, object ngay_Batdau, object ngay_Ketthuc, object id_Hanghoa_Ban, object id_Loai_Hanghoa_Ban)
        {
            return _Ware_Nhap_Hh_Ban_Service.Get_All_Ware_Nhap_Tonghop(id_cuahang, ngay_Batdau, ngay_Ketthuc, id_Hanghoa_Ban, id_Loai_Hanghoa_Ban);
        }

        [WebMethod(Description = "")]
        public bool Ware_Nhap_Hh_Ban_CheckXuat_Chuyen()
        {
            return _Ware_Nhap_Hh_Ban_Service.Ware_Nhap_Hh_Ban_CheckXuat_Chuyen();
        }

        #endregion

        #region Ware_Xuat_Hh_Ban

        [WebMethod(Description = "Insert đối tượng Ware_Xuat_Hh_Ban vào DB.")]
        public object Insert_Ware_Nhap_Xuat_Chitiet(object Id_Xuat_Chitiet, object Id_Nhap_Chitiet, object Id_Hanghoa_Ban)
        {
            return _Ware_Xuat_Hh_Ban_Service.Insert_Ware_Nhap_Xuat_Chitiet(Id_Xuat_Chitiet, Id_Nhap_Chitiet, Id_Hanghoa_Ban);
        }

        [WebMethod(Description = "Trả về một dataset Xuat_Hh_Ban by Id_Kho Nhập")]
        public string Ware_Xuat_Hh_Ban_SelectAll_ById_Kho_Nhap(object Ngay_Chungtu, object Id_Kho_Nhap)
        {
            return _Ware_Xuat_Hh_Ban_Service.Ware_Xuat_Hh_Ban_SelectAll_ById_Kho_Nhap(Ngay_Chungtu, Id_Kho_Nhap);
        }

        [WebMethod(Description = "Trả về một dataset Xuat_Hh_Ban")]
        public string Get_All_Ware_Xuat_Hh_Ban(object Ngay_Chungtu, object Id_Kho)
        {
            return _Ware_Xuat_Hh_Ban_Service.Get_All_Ware_Xuat_Hh_Ban(Ngay_Chungtu, Id_Kho);
        }

        [WebMethod(Description = "Trả về một dataset Xuat_Hh_Ban")]
        public string Get_All_Ware_Xuat_Hh_Ban_Chitiet_By_Xuat_Hh_Ban(object id_Xuat_Hh_Ban)
        {
            return _Ware_Xuat_Hh_Ban_Service.Get_All_Ware_Xuat_Hh_Ban_Chitiet_ByXuat_Hh(id_Xuat_Hh_Ban);
        }

        [WebMethod(Description = "Insert đối tượng Ware_Xuat_Hh_Ban vào DB.")]
        public object Insert_Ware_Xuat_Hh_Ban(Ecm.Domain.Ware.Ware_Xuat_Hh_Ban Ware_Xuat_Hh_Ban)
        {
            return _Ware_Xuat_Hh_Ban_Service.Insert_Ware_Xuat_Hh_Ban(Ware_Xuat_Hh_Ban);
        }

        [WebMethod(Description = "Update đối tượng Ware_Xuat_Hh_Ban vào DB.")]
        public object Update_Ware_Xuat_Hh_Ban(Ecm.Domain.Ware.Ware_Xuat_Hh_Ban Ware_Xuat_Hh_Ban)
        {
            return _Ware_Xuat_Hh_Ban_Service.Update_Ware_Xuat_Hh_Ban(Ware_Xuat_Hh_Ban);
        }

        [WebMethod(Description = "Delete đối tượng Ware_Xuat_Hh_Ban vào DB.")]
        public object Delete_Ware_Xuat_Hh_Ban(Ecm.Domain.Ware.Ware_Xuat_Hh_Ban Ware_Xuat_Hh_Ban)
        {
            return _Ware_Xuat_Hh_Ban_Service.Delete_Ware_Xuat_Hh_Ban(Ware_Xuat_Hh_Ban);
        }

        [WebMethod(Description = "Update collection Ware_Xuat_Hh_Ban_Chitiet vào DB.")]
        public object Update_Ware_Xuat_Hh_Ban_Chitiet_Collection(DataSet dsCollection)
        {
            return _Ware_Xuat_Hh_Ban_Service.Update_Ware_Xuat_Hh_Ban_Chitiet_Collection(dsCollection);
        }

        [WebMethod(Description = "thong ke danh sach ban hang")]
        public string Get_All_Ware_Xuat_Chitiet(object id_cuahang, object ngay_Batdau, object ngay_Ketthuc, object id_Hanghoa_Ban, object id_Loai_Hanghoa_Ban)
        {
            return _Ware_Xuat_Hh_Ban_Service.Get_All_Ware_Xuat_Chitiet(id_cuahang, ngay_Batdau, ngay_Ketthuc, id_Hanghoa_Ban, id_Loai_Hanghoa_Ban);
        }

        [WebMethod(Description = "thong ke danh sach ban hang")]
        public string Get_All_Ware_Xuat_Tonghop(object id_cuahang, object ngay_Batdau, object ngay_Ketthuc, object id_Hanghoa_Ban, object id_Loai_Hanghoa_Ban)
        {
            return _Ware_Xuat_Hh_Ban_Service.Get_All_Ware_Xuat_Tonghop(id_cuahang, ngay_Batdau, ngay_Ketthuc, id_Hanghoa_Ban, id_Loai_Hanghoa_Ban);
        }

        #endregion

        #region Ware_Xuat_Hh_Mua
        [WebMethod(Description = "Trả về một dataset Xuat_Hh_Mua")]
        public string Get_All_Ware_Xuat_Hh_Mua()
        {
            return _Ware_Xuat_Hh_Mua_Service.Get_All_Ware_Xuat_Hh_Mua();
        }

        [WebMethod(Description = "Trả về một dataset Xuat_Hh_Mua")]
        public string Get_All_Ware_Xuat_Hh_Mua_Chitiet_By_Xuat_Hh_Mua(object id_Xuat_Hh_Mua)
        {
            return _Ware_Xuat_Hh_Mua_Service.Get_All_Ware_Xuat_Hh_Mua_Chitiet_ByXuat_Hh(id_Xuat_Hh_Mua);
        }

        [WebMethod(Description = "Insert đối tượng Ware_Xuat_Hh_Mua vào DB.")]
        public object Insert_Ware_Xuat_Hh_Mua(Ecm.Domain.Ware.Ware_Xuat_Hh_Mua Ware_Xuat_Hh_Mua)
        {
            return _Ware_Xuat_Hh_Mua_Service.Insert_Ware_Xuat_Hh_Mua(Ware_Xuat_Hh_Mua);
        }

        [WebMethod(Description = "Update đối tượng Ware_Xuat_Hh_Mua vào DB.")]
        public object Update_Ware_Xuat_Hh_Mua(Ecm.Domain.Ware.Ware_Xuat_Hh_Mua Ware_Xuat_Hh_Mua)
        {
            return _Ware_Xuat_Hh_Mua_Service.Update_Ware_Xuat_Hh_Mua(Ware_Xuat_Hh_Mua);
        }

        [WebMethod(Description = "Delete đối tượng Ware_Xuat_Hh_Mua vào DB.")]
        public object Delete_Ware_Xuat_Hh_Mua(Ecm.Domain.Ware.Ware_Xuat_Hh_Mua Ware_Xuat_Hh_Mua)
        {
            return _Ware_Xuat_Hh_Mua_Service.Delete_Ware_Xuat_Hh_Mua(Ware_Xuat_Hh_Mua);
        }

        [WebMethod(Description = "Update collection Ware_Xuat_Hh_Mua_Chitiet vào DB.")]
        public object Update_Ware_Xuat_Hh_Mua_Chitiet_Collection(DataSet dsCollection)
        {
            return _Ware_Xuat_Hh_Mua_Service.Update_Ware_Xuat_Hh_Mua_Chitiet_Collection(dsCollection);
        }
        #endregion

        #region Ware_Kk_Hh_Ban
        [WebMethod(Description = "Trả về một dataset Kk_Hh_Ban")]
        public string Get_All_Nxt_Hhban_Notify(object Ngay_Ketthuc, object Id_Cuahang_Ban)
        {
            return _Ware_Kk_Hh_Ban_Service.Get_All_Nxt_Hhban_Notify(Ngay_Ketthuc, Id_Cuahang_Ban);

        }
        [WebMethod(Description = "Trả về một dataset Kk_Hh_Ban")]
        public string Get_All_Ware_Kk_Hh_Ban(object Ngay_Chungtu, object Id_Kho)
        {
            return _Ware_Kk_Hh_Ban_Service.Get_All_Ware_Kk_Hh_Ban(Ngay_Chungtu, Id_Kho);
        }

        [WebMethod(Description = "Trả về một dataset Kk_Hh_Ban")]
        public string Get_All_Ware_Kk_Hh_Ban_Chitiet_By_Kk_Hh_Ban(object id_Kk_Hh_Ban)
        {
            return _Ware_Kk_Hh_Ban_Service.Get_All_Ware_Kk_Hh_Ban_Chitiet_By_Kk_Hh_Ban(id_Kk_Hh_Ban);
        }

        [WebMethod(Description = "Insert đối tượng Ware_Kk_Hh_Ban vào DB.")]
        public object Insert_Ware_Kk_Hh_Ban(Ecm.Domain.Ware.Ware_Kk_Hh_Ban Ware_Kk_Hh_Ban)
        {
            return _Ware_Kk_Hh_Ban_Service.Insert_Ware_Kk_Hh_Ban(Ware_Kk_Hh_Ban);
        }

        [WebMethod(Description = "Update đối tượng Ware_Kk_Hh_Ban vào DB.")]
        public object Update_Ware_Kk_Hh_Ban(Ecm.Domain.Ware.Ware_Kk_Hh_Ban Ware_Kk_Hh_Ban)
        {
            return _Ware_Kk_Hh_Ban_Service.Update_Ware_Kk_Hh_Ban(Ware_Kk_Hh_Ban);
        }

        [WebMethod(Description = "Delete đối tượng Ware_Kk_Hh_Ban vào DB.")]
        public object Delete_Ware_Kk_Hh_Ban(Ecm.Domain.Ware.Ware_Kk_Hh_Ban Ware_Kk_Hh_Ban)
        {
            return _Ware_Kk_Hh_Ban_Service.Delete_Ware_Kk_Hh_Ban(Ware_Kk_Hh_Ban);
        }

        [WebMethod(Description = "Update collection Ware_Kk_Hh_Ban_Chitiet vào DB.")]
        public object Update_Ware_Kk_Hh_Ban_Chitiet_Collection(DataSet dsCollection)
        {
            return _Ware_Kk_Hh_Ban_Service.Update_Ware_Kk_Hh_Ban_Chitiet_Collection(dsCollection);
        }
        #endregion


        [WebMethod(Description = "Trả về một dataset Kk_Hh_Ban By date")]
        public string Get_All_Ware_Hh_Kh_Tra_SelectBy_Date(object Thangnam)
        {
            return _Ware_Hh_Kh_Tra_Service.Get_All_Ware_Hh_Kh_Tra_SelectBy_Date(Thangnam);
        }



        #region Ware_Kk_Hh_Mua
        //[WebMethod]
        //public string Get_All_Nxt_Hhmua_Notify(object Ngay_Ketthuc, object Id_Kho_Hanghoa_Mua)
        //{
        //    return _Ware_Kk_Hh_Mua_Service.Get_All_Nxt_Hhmua_Notify(Ngay_Ketthuc, Id_Kho_Hanghoa_Mua);
        //}

        //[WebMethod(Description = "Trả về một dataset Kk_Hh_Mua")]
        //public string Get_All_Ware_Kk_Hh_Mua()
        //{
        //    return _Ware_Kk_Hh_Mua_Service.Get_All_Ware_Kk_Hh_Mua();
        //}

        //[WebMethod(Description = "Trả về một dataset Kk_Hh_Mua")]
        //public string Get_All_Ware_Kk_Hh_Mua_Chitiet_By_Kk_Hh_Mua(object id_Kk_Hh_Mua)
        //{
        //    return _Ware_Kk_Hh_Mua_Service.Get_All_Ware_Kk_Hh_Mua_Chitiet_By_Kk_Hh_Mua(id_Kk_Hh_Mua);
        //}

        //[WebMethod(Description = "Insert đối tượng Ware_Kk_Hh_Mua vào DB.")]
        //public object Insert_Ware_Kk_Hh_Mua(Ecm.Domain.Ware.Ware_Kk_Hh_Mua Ware_Kk_Hh_Mua)
        //{
        //    return _Ware_Kk_Hh_Mua_Service.Insert_Ware_Kk_Hh_Mua(Ware_Kk_Hh_Mua);
        //}

        //[WebMethod(Description = "Update đối tượng Ware_Kk_Hh_Mua vào DB.")]
        //public object Update_Ware_Kk_Hh_Mua(Ecm.Domain.Ware.Ware_Kk_Hh_Mua Ware_Kk_Hh_Mua)
        //{
        //    return _Ware_Kk_Hh_Mua_Service.Update_Ware_Kk_Hh_Mua(Ware_Kk_Hh_Mua);
        //}

        //[WebMethod(Description = "Delete đối tượng Ware_Kk_Hh_Mua vào DB.")]
        //public object Delete_Ware_Kk_Hh_Mua(Ecm.Domain.Ware.Ware_Kk_Hh_Mua Ware_Kk_Hh_Mua)
        //{
        //    return _Ware_Kk_Hh_Mua_Service.Delete_Ware_Kk_Hh_Mua(Ware_Kk_Hh_Mua);
        //}

        //[WebMethod(Description = "Update collection Ware_Kk_Hh_Mua_Chitiet vào DB.")]
        //public object Update_Ware_Kk_Hh_Mua_Chitiet_Collection(DataSet dsCollection)
        //{
        //    return _Ware_Kk_Hh_Mua_Service.Update_Ware_Kk_Hh_Mua_Chitiet_Collection(dsCollection);
        //}
        #endregion

        #region Ware_Nhap_Hh_Ban_Err
        //[WebMethod(Description = "Trả về một dataset Nhap_Hh_Ban")]
        //public string Get_All_Ware_Nhap_Hh_Ban_Err(object Ngay_Chungtu)
        //{
        //    return _Ware_Nhap_Hh_Ban_Err_Service.Get_All_Ware_Nhap_Hh_Ban_Err(Ngay_Chungtu);
        //}

        //[WebMethod(Description = "Trả về một dataset Nhap_Hh_Ban")]
        //public string Get_All_Ware_Nhap_Hh_Ban_Err_Chitiet_By_Nhap_Hh_Ban_Err(object id_Nhap_Hh_Ban_Err)
        //{
        //    return _Ware_Nhap_Hh_Ban_Err_Service.Get_All_Ware_Nhap_Hh_Ban_Err_Chitiet_By_Nhap_Hh_Ban_Err(id_Nhap_Hh_Ban_Err);
        //}

        //[WebMethod(Description = "Insert đối tượng Ware_Nhap_Hh_Ban_Err vào DB.")]
        //public object Insert_Ware_Nhap_Hh_Ban_Err(Ecm.Domain.Ware.Ware_Nhap_Hh_Ban_Err Ware_Nhap_Hh_Ban_Err)
        //{
        //    return _Ware_Nhap_Hh_Ban_Err_Service.Insert_Ware_Nhap_Hh_Ban_Err(Ware_Nhap_Hh_Ban_Err);
        //}

        //[WebMethod(Description = "Update đối tượng Ware_Nhap_Hh_Ban_Err vào DB.")]
        //public object Update_Ware_Nhap_Hh_Ban_Err(Ecm.Domain.Ware.Ware_Nhap_Hh_Ban_Err Ware_Nhap_Hh_Ban_Err)
        //{
        //    return _Ware_Nhap_Hh_Ban_Err_Service.Update_Ware_Nhap_Hh_Ban_Err(Ware_Nhap_Hh_Ban_Err);
        //}

        //[WebMethod(Description = "Delete đối tượng Ware_Nhap_Hh_Ban_Err vào DB.")]
        //public object Delete_Ware_Nhap_Hh_Ban_Err(Ecm.Domain.Ware.Ware_Nhap_Hh_Ban_Err Ware_Nhap_Hh_Ban_Err)
        //{
        //    return _Ware_Nhap_Hh_Ban_Err_Service.Delete_Ware_Nhap_Hh_Ban_Err(Ware_Nhap_Hh_Ban_Err);
        //}

        //[WebMethod(Description = "Update collection Ware_Nhap_Hh_Ban_Err_Chitiet vào DB.")]
        //public object Update_Ware_Nhap_Hh_Ban_Err_Chitiet_Collection(DataSet dsCollection)
        //{
        //    return _Ware_Nhap_Hh_Ban_Err_Service.Update_Ware_Nhap_Hh_Ban_Err_Chitiet_Collection(dsCollection);
        //}
        #endregion

        #region Ware_Nhap_Hh_Mua

        //[WebMethod(Description = "Trả về một dataset Nhap_Hh_Mua")]
        //public string Get_All_Ware_Nhap_Hh_Mua()
        //{
        //    return _Ware_Nhap_Hh_Mua_Service.Get_All_Ware_Nhap_Hh_Mua();
        //}

        //[WebMethod(Description = "Trả về một dataset Nhap_Hh_Mua")]
        //public string Get_All_Ware_Nhap_Hh_Mua_Chitiet_By_Nhap_Hh_Mua(object id_Nhap_Hh_Mua)
        //{
        //    return _Ware_Nhap_Hh_Mua_Service.Get_All_Ware_Nhap_Hh_Mua_Chitiet_By_Nhap_Hh(id_Nhap_Hh_Mua);
        //}

        //[WebMethod(Description = "Insert đối tượng Ware_Nhap_Hh_Mua vào DB.")]
        //public object Insert_Ware_Nhap_Hh_Mua(Ecm.Domain.Ware.Ware_Nhap_Hh_Mua Ware_Nhap_Hh_Mua)
        //{
        //    return _Ware_Nhap_Hh_Mua_Service.Insert_Ware_Nhap_Hh_Mua(Ware_Nhap_Hh_Mua);
        //}

        //[WebMethod(Description = "Update đối tượng Ware_Nhap_Hh_Mua vào DB.")]
        //public object Update_Ware_Nhap_Hh_Mua(Ecm.Domain.Ware.Ware_Nhap_Hh_Mua Ware_Nhap_Hh_Mua)
        //{
        //    return _Ware_Nhap_Hh_Mua_Service.Update_Ware_Nhap_Hh_Mua(Ware_Nhap_Hh_Mua);
        //}

        //[WebMethod(Description = "Delete đối tượng Ware_Nhap_Hh_Mua vào DB.")]
        //public object Delete_Ware_Nhap_Hh_Mua(Ecm.Domain.Ware.Ware_Nhap_Hh_Mua Ware_Nhap_Hh_Mua)
        //{
        //    return _Ware_Nhap_Hh_Mua_Service.Delete_Ware_Nhap_Hh_Mua(Ware_Nhap_Hh_Mua);
        //}

        //[WebMethod(Description = "Update collection Ware_Nhap_Hh_Mua_Chitiet vào DB.")]
        //public object Update_Ware_Nhap_Hh_Mua_Chitiet_Collection(DataSet dsCollection)
        //{
        //    return _Ware_Nhap_Hh_Mua_Service.Update_Ware_Nhap_Hh_Mua_Chitiet_Collection(dsCollection);
        //}

        //[WebMethod]
        //public object Ware_Nhap_Hh_Mua_Chitiet_UpdateDongia_FrHdmuahang(object id_hdmuahang, object Id_Nhap_Hh_Mua)
        //{
        //    return _Ware_Nhap_Hh_Mua_Service.Ware_Nhap_Hh_Mua_Chitiet_UpdateDongia_FrHdmuahang(id_hdmuahang, Id_Nhap_Hh_Mua);
        //}

        //[WebMethod]
        //public object Ware_Nhap_Hh_Chitiet_UpdateDongia_FrHdmuahang(object id_hdmuahang, object Id_Nhap_Hh_Ban)
        //{
        //    return _Ware_Nhap_Hh_Mua_Service.Ware_Nhap_Hh_Chitiet_UpdateDongia_FrHdmuahang(id_hdmuahang, Id_Nhap_Hh_Ban);
        //}

        #endregion

        #region Ware_Hh_Mua_Tra_Ncc

        //[WebMethod(Description = "Trả về một dataset Hh_Mua_Tra_Ncc")]
        //public string Get_All_Ware_Hh_Mua_Tra_Ncc(object Ngay_Chungtu)
        //{
        //    return _Ware_Hh_Mua_Tra_Ncc_Service.Get_All_Ware_Hh_Mua_Tra_Ncc(Ngay_Chungtu);
        //}

        //[WebMethod(Description = "Trả về một dataset Hh_Mua_Tra_Ncc")]
        //public string Get_All_Ware_Hh_Mua_Tra_Ncc_Chitiet_By_Hh_Mua_Tra_Ncc(object id_Hh_Mua_Tra_Ncc)
        //{
        //    return _Ware_Hh_Mua_Tra_Ncc_Service.Get_All_Ware_Hh_Mua_Tra_Ncc_Chitiet_By_Tra_Ncc(id_Hh_Mua_Tra_Ncc);
        //}

        //[WebMethod(Description = "Trả về một dataset ")]
        //public string Get_All_Ware_Xuathang_Tra_Nhacungcap(object id_cuahang, object ngay_Batdau, object ngay_Ketthuc, object id_Hanghoa_Ban, object id_Loai_Hanghoa_Ban)
        //{
        //    return _Ware_Hh_Mua_Tra_Ncc_Service.Get_All_Ware_Xuathang_Tra_Nhacungcap(id_cuahang, ngay_Batdau, ngay_Ketthuc, id_Hanghoa_Ban, id_Loai_Hanghoa_Ban);
        //}

        //[WebMethod(Description = "Insert đối tượng Ware_Hh_Mua_Tra_Ncc vào DB.")]
        //public object Insert_Ware_Hh_Mua_Tra_Ncc(Ecm.Domain.Ware.Ware_Hh_Mua_Tra_Ncc Ware_Hh_Mua_Tra_Ncc)
        //{
        //    return _Ware_Hh_Mua_Tra_Ncc_Service.Insert_Ware_Hh_Mua_Tra_Ncc(Ware_Hh_Mua_Tra_Ncc);
        //}

        //[WebMethod(Description = "Update đối tượng Ware_Hh_Mua_Tra_Ncc vào DB.")]
        //public object Update_Ware_Hh_Mua_Tra_Ncc(Ecm.Domain.Ware.Ware_Hh_Mua_Tra_Ncc Ware_Hh_Mua_Tra_Ncc)
        //{
        //    return _Ware_Hh_Mua_Tra_Ncc_Service.Update_Ware_Hh_Mua_Tra_Ncc(Ware_Hh_Mua_Tra_Ncc);
        //}

        //[WebMethod(Description = "Delete đối tượng Ware_Hh_Mua_Tra_Ncc vào DB.")]
        //public object Delete_Ware_Hh_Mua_Tra_Ncc(Ecm.Domain.Ware.Ware_Hh_Mua_Tra_Ncc Ware_Hh_Mua_Tra_Ncc)
        //{
        //    return _Ware_Hh_Mua_Tra_Ncc_Service.Delete_Ware_Hh_Mua_Tra_Ncc(Ware_Hh_Mua_Tra_Ncc);
        //}

        //[WebMethod(Description = "Update collection Ware_Hh_Mua_Tra_Ncc_Chitiet vào DB.")]
        //public object Update_Ware_Hh_Mua_Tra_Ncc_Chitiet_Collection(DataSet dsCollection)
        //{
        //    return _Ware_Hh_Mua_Tra_Ncc_Service.Update_Ware_Hh_Mua_Tra_Ncc_Chitiet_Collection(dsCollection);
        //}
        #endregion

        #region Ware_Hh_Kh_Tra

        [WebMethod(Description = "trả về ds khách hàng trả hàng chi tiết by khách hàng, ngày bắt đầu, ngày kết thúc --> báo cáo")]
        public string Get_All_Ware_Hh_Kh_Tra_Chitiet_ByKhachhang(object Id_Khachhang, object Ngay_Batdau, object Ngay_Ketthuc, object id_Cuahang_Ban)
        {
            return _Ware_Hh_Kh_Tra_Service.Get_All_Ware_Hh_Kh_Tra_Chitiet_ByKhachhang(Id_Khachhang, Ngay_Batdau, Ngay_Ketthuc, id_Cuahang_Ban);
        }

        [WebMethod(Description = "trả về ds khách hàng trả hàng (chỉ select phiếu trả hàng từ xuất kho bán hàng")]
        public string Get_All_Ware_Hh_Kh_Tra_PhieuXuatKho(object Id_Cuahang_Ban)
        {
            return _Ware_Hh_Kh_Tra_Service.Get_All_Ware_Hh_Kh_Tra_PhieuXuatKho(Id_Cuahang_Ban);
        }

        [WebMethod(Description = "trả về ds khách hàng trả hàng (chỉ select phiếu trả hàng từ hd bán hàng)")]
        public string Get_All_Ware_Hh_Kh_Tra_HdBanhang(object Id_Cuahang_Ban)
        {
            return _Ware_Hh_Kh_Tra_Service.Get_All_Ware_Hh_Kh_Tra_HdBanhang(Id_Cuahang_Ban);
        }

        [WebMethod(Description = "Trả về một dataset Hh_Mua_Tra_Ncc")]
        public string Get_All_Ware_Hh_Kh_Tra()
        {
            return _Ware_Hh_Kh_Tra_Service.Get_All_Ware_Hh_Kh_Tra();
        }

        [WebMethod(Description = "Trả về một dataset Hh_Mua_Tra_Chitiet")]
        public string Get_All_Ware_Hh_Kh_Tra_Chitiet()
        {
            return _Ware_Hh_Kh_Tra_Service.Get_All_Ware_Hh_Kh_Tra_Chitiet();
        }

        [WebMethod(Description = "Trả về một dataset Hh_Mua_Tra_Ncc")]
        public string Get_All_Ware_Hh_Kh_Tra_Hhban_ByCuahang(object Id_Cuahang_Ban)
        {
            return _Ware_Hh_Kh_Tra_Service.Get_All_Ware_Hh_Kh_Tra_Hhban_ByCuahang(Id_Cuahang_Ban);
        }

        [WebMethod(Description = "Trả về một dataset Hh_Mua_Tra_Ncc")]
        public string Get_All_Ware_Hh_Kh_Tra_Hhban()
        {
            return _Ware_Hh_Kh_Tra_Service.Get_All_Ware_Hh_Kh_Tra_Hhban();
        }

        [WebMethod(Description = "Trả về một dataset Hh_Mua_Tra_Ncc")]
        public string Get_All_Ware_Hh_Kh_Tra_Hhmua()
        {
            return _Ware_Hh_Kh_Tra_Service.Get_All_Ware_Hh_Kh_Tra_Hhmua();
        }

        [WebMethod(Description = "Trả về một dataset Hh_Mua_Tra_Ncc")]
        public string Get_All_Ware_Hh_Kh_Tra_Hhmua_ByKhoHanghoa(object Id_Kho_Hanghoa_Mua)
        {
            return _Ware_Hh_Kh_Tra_Service.Get_All_Ware_Hh_Kh_Tra_Hhmua_ByKhoHanghoa(Id_Kho_Hanghoa_Mua);
        }


        [WebMethod(Description = "Trả về một dataset Hh_Mua_Tra_Ncc")]
        public string Get_All_Ware_Hh_Kh_Tra_Chitiet_ByHh_Kh_Tra(object id_Hh_Mua_Tra_Ncc)
        {
            return _Ware_Hh_Kh_Tra_Service.Get_All_Ware_Hh_Kh_Tra_Chitiet_ByHh_Kh_Tra(id_Hh_Mua_Tra_Ncc);
        }

        [WebMethod(Description = "Insert đối tượng Ware_Hh_Kh_Tra vào DB.")]
        public object Insert_Ware_Hh_Kh_Tra(Ecm.Domain.Ware.Ware_Hh_Kh_Tra Ware_Hh_Kh_Tra)
        {
            return _Ware_Hh_Kh_Tra_Service.Insert_Ware_Hh_Kh_Tra(Ware_Hh_Kh_Tra);
        }

        [WebMethod(Description = "Update đối tượng Ware_Hh_Kh_Tra vào DB.")]
        public object Update_Ware_Hh_Kh_Tra(Ecm.Domain.Ware.Ware_Hh_Kh_Tra Ware_Hh_Kh_Tra)
        {
            return _Ware_Hh_Kh_Tra_Service.Update_Ware_Hh_Kh_Tra(Ware_Hh_Kh_Tra);
        }

        [WebMethod(Description = "Delete đối tượng Ware_Hh_Kh_Tra vào DB.")]
        public object Delete_Ware_Hh_Kh_Tra(Ecm.Domain.Ware.Ware_Hh_Kh_Tra Ware_Hh_Kh_Tra)
        {
            return _Ware_Hh_Kh_Tra_Service.Delete_Ware_Hh_Kh_Tra(Ware_Hh_Kh_Tra);
        }

        [WebMethod(Description = "Update collection Ware_Hh_Kh_Tra_Chitiet vào DB.")]
        public object Update_Ware_Hh_Kh_Tra_Chitiet_Collection(DataSet dsCollection)
        {
            return _Ware_Hh_Kh_Tra_Service.Update_Ware_Hh_Kh_Tra_Chitiet_Collection(dsCollection);
        }
        #endregion

        #region Ware_Hanghoa_Dinhgia
        [WebMethod(Description = "Trả về một dataset Hanghoa_Dinhgia")]
        public string Get_All_Ware_Hanghoa_Dinhgia()
        {
            return _Ware_Hanghoa_Dinhgia_Service.Get_All_Ware_Hanghoa_Dinhgia();
        }

        //[WebMethod(Description = "Trả về một dataset Hanghoa_Dinhgia by Id_Hh_Mua")]
        //public string Get_All_Ware_Hanghoa_Dinhgia_By_Id_hh_Mua(object id_Hh_Mua)
        //{
        //    return _Ware_Hanghoa_Dinhgia_Service.Get_All_Ware_Hanghoa_Dinhgia_By_Id_hh_Mua(id_Hh_Mua);
        //}

        [WebMethod(Description = "Trả về một dataset Hanghoa_Dinhgia")]
        public string Get_All_Ware_Hanghoa_Dinhgia_Log()
        {
            return _Ware_Hanghoa_Dinhgia_Service.Get_All_Ware_Hanghoa_Dinhgia_Log();
        }

        [WebMethod(Description = "Trả về một dataset Hanghoa_Dinhgia By id loại hàng hóa")]
        public string Get_All_Ware_Hanghoa_Dinhgia_By_Id_Loai_hh(object Id_Loai_Hanghoa)
        {
            return _Ware_Hanghoa_Dinhgia_Service.Get_All_Ware_Hanghoa_Dinhgia_By_Id_Loai_hh(Id_Loai_Hanghoa);
        }

        [WebMethod(Description = "Trả về một dataset Hanghoa_Dinhgia By id loại hàng hóa có giá tại thời điểm hiện tại")]
        public string Get_All_Ware_Hanghoa_Dinhgia_By_Loai_HH_By_Date(object Id_Loai_Hanghoa, object ngay_chungtu)
        {
            return _Ware_Hanghoa_Dinhgia_Service.Get_All_Ware_Hanghoa_Dinhgia_By_Loai_HH_By_Date(Id_Loai_Hanghoa, ngay_chungtu);
        }

        [WebMethod(Description = "Trả về một dataset Hanghoa_Dinhgia By id hàng hóa bán")]
        public string Get_All_Ware_Hanghoa_Dinhgia_By_Id_HhBan(object Id_Hanghoa_Ban)
        {
            return _Ware_Hanghoa_Dinhgia_Service.Get_All_Ware_Hanghoa_Dinhgia_By_Id_HhBan(Id_Hanghoa_Ban);
        }



        [WebMethod(Description = "Trả về một dataset Hanghoa_Mua_Dinhgia")]
        public string Get_All_Ware_Hanghoa_Mua_Dinhgia()
        {
            return _Ware_Hanghoa_Dinhgia_Service.Get_All_Ware_Hanghoa_Mua_Dinhgia();
        }

        [WebMethod(Description = "Trả về một dataset Hanghoa_Dinhgia_Log By Id_Loai_Hanghoa")]
        public string Get_All_Ware_Hanghoa_Dinhgia_Log_By_Id_LoaiHh(object Id_Loai_Hanghoa)
        {
            return _Ware_Hanghoa_Dinhgia_Service.Get_All_Ware_Hanghoa_Dinhgia_Log_By_Id_LoaiHh(Id_Loai_Hanghoa);
        }

        [WebMethod(Description = "Trả về một dataset Hanghoa_Mua_Dinhgia")]
        public string Get_All_Ware_Hanghoa_Mua_Dinhgia_ByDate(object Ngay_Chungtu)
        {
            return _Ware_Hanghoa_Dinhgia_Service.Get_All_Ware_Hanghoa_Mua_Dinhgia_ByDate(Ngay_Chungtu);
        }

        [WebMethod(Description = "Trả về một dataset Hanghoa_Ban_Dinhgia")]
        public string Get_All_Ware_Hanghoa_Ban_Dinhgia()
        {
            return _Ware_Hanghoa_Dinhgia_Service.Get_All_Ware_Hanghoa_Ban_Dinhgia();
        }

        [WebMethod(Description = "Trả về một dataset Hanghoa_Ban_Dinhgia")]
        public string Get_All_Ware_Hanghoa_Ban_Xuat_Luanchuyen_Chitiet(object id_cuahang_ban, object ngay_Batdau, object ngay_Ketthuc, object id_Hanghoa_Ban, object id_Loai_Hanghoa_Ban)
        {
            return _Ware_Xuat_Hh_Ban_Service.Get_All_Ware_Hanghoa_Ban_Xuat_Luanchuyen_Chitiet(id_cuahang_ban, ngay_Batdau, ngay_Ketthuc, id_Hanghoa_Ban, id_Loai_Hanghoa_Ban);
        }

        [WebMethod(Description = "Trả về một dataset Hanghoa_Ban_Dinhgia")]
        public string Get_All_Ware_Hanghoa_Ban_Xuat_Luanchuyen_Tonghop(object id_cuahang_ban, object ngay_Batdau, object ngay_Ketthuc, object id_Hanghoa_Ban, object id_Loai_Hanghoa_Ban)
        {
            return _Ware_Xuat_Hh_Ban_Service.Get_All_Ware_Hanghoa_Ban_Xuat_Luanchuyen_Tonghop(id_cuahang_ban, ngay_Batdau, ngay_Ketthuc, id_Hanghoa_Ban, id_Loai_Hanghoa_Ban);
        }

        [WebMethod(Description = "Trả về một dataset Hanghoa_Ban_Dinhgia")]
        public string Get_All_Ware_Hanghoa_Ban_Nhap_Luanchuyen_Chitiet(object id_cuahang_ban, object ngay_Batdau, object ngay_Ketthuc, object id_Hanghoa_Ban, object id_Loai_Hanghoa_Ban)
        {
            return _Ware_Xuat_Hh_Ban_Service.Get_All_Ware_Hanghoa_Ban_Nhap_Luanchuyen_Chitiet(id_cuahang_ban, ngay_Batdau, ngay_Ketthuc, id_Hanghoa_Ban, id_Loai_Hanghoa_Ban);
        }


        [WebMethod(Description = "Trả về một dataset Hanghoa_Ban_Dinhgia")]
        public string Get_All_Ware_Hanghoa_Ban_Nhap_Luanchuyen_Tonghop(object id_cuahang_ban, object ngay_Batdau, object ngay_Ketthuc, object id_Hanghoa_Ban, object id_Loai_Hanghoa_Ban)
        {
            return _Ware_Xuat_Hh_Ban_Service.Get_All_Ware_Hanghoa_Ban_Nhap_Luanchuyen_Tonghop(id_cuahang_ban, ngay_Batdau, ngay_Ketthuc, id_Hanghoa_Ban, id_Loai_Hanghoa_Ban);
        }


        [WebMethod(Description = "Trả về một dataset Hanghoa_Ban_Dinhgia")]
        public string Get_All_Ware_Hanghoa_Ban_Dinhgia_ByDate(object Ngay_Chungtu)
        {
            return _Ware_Hanghoa_Dinhgia_Service.Get_All_Ware_Hanghoa_Ban_Dinhgia_ByDate(Ngay_Chungtu);
        }

        [WebMethod(Description = "Insert đối tượng Ware_Hanghoa_Dinhgia vào DB.")]
        public object Insert_Ware_Hanghoa_Dinhgia(Ecm.Domain.Ware.Ware_Hanghoa_Dinhgia Ware_Hanghoa_Dinhgia)
        {
            return _Ware_Hanghoa_Dinhgia_Service.Insert_Ware_Hanghoa_Dinhgia(Ware_Hanghoa_Dinhgia);
        }

        [WebMethod(Description = "Update đối tượng Ware_Hanghoa_Dinhgia vào DB.")]
        public object Update_Ware_Hanghoa_Dinhgia(Ecm.Domain.Ware.Ware_Hanghoa_Dinhgia Ware_Hanghoa_Dinhgia)
        {
            return _Ware_Hanghoa_Dinhgia_Service.Update_Ware_Hanghoa_Dinhgia(Ware_Hanghoa_Dinhgia);
        }

        [WebMethod(Description = "Delete đối tượng Ware_Hanghoa_Dinhgia vào DB.")]
        public object Delete_Ware_Hanghoa_Dinhgia(Ecm.Domain.Ware.Ware_Hanghoa_Dinhgia Ware_Hanghoa_Dinhgia)
        {
            return _Ware_Hanghoa_Dinhgia_Service.Delete_Ware_Hanghoa_Dinhgia(Ware_Hanghoa_Dinhgia);
        }

        [WebMethod(Description = "Update collection Ware_Hanghoa_Dinhgia_Chitiet vào DB.")]
        public object Update_Ware_Hanghoa_Dinhgia_Log_Collection(DataSet dsCollection)
        {
            return _Ware_Hanghoa_Dinhgia_Service.Update_Ware_Hanghoa_Dinhgia_Log_Collection(dsCollection);
        }

        [WebMethod(Description = "Update collection Ware_Hanghoa_Dinhgia_Chitiet vào DB.")]
        public object Update_Ware_Hanghoa_Dinhgia_Collection(DataSet dsCollection)
        {
            return _Ware_Hanghoa_Dinhgia_Service.Update_Ware_Hanghoa_Dinhgia_Collection(dsCollection);
        }

        [WebMethod(Description = "Trả về một dataset Hanghoa_Ban_Dinhgia by Ten_hanghoa_ban")]
        public string Get_All_Ware_Hanghoa_Ban_Dinhgia_By_Ten_Hanghoa(object Ten_Hanghoa_Ban)
        {
            return _Ware_Hanghoa_Dinhgia_Service.Get_All_Ware_Hanghoa_Ban_Dinhgia_By_Ten_Hanghoa(Ten_Hanghoa_Ban);
        }

        [WebMethod(Description = "Trả về một dataset Hanghoa_Ban_Dinhgia by Ma_hanghoa_ban")]
        public string Get_All_Ware_Hanghoa_Ban_Dinhgia_By_Ma_Hanghoa(object Ma_Hanghoa_Ban)
        {
            return _Ware_Hanghoa_Dinhgia_Service.Get_All_Ware_Hanghoa_Ban_Dinhgia_By_Ma_Hanghoa(Ma_Hanghoa_Ban);
        }

        [WebMethod(Description = "Trả về một dataset Hanghoa_Ban_Dinhgia by Barcode")]
        public string Get_All_Ware_Hanghoa_Ban_Dinhgia_By_Barcode(object Barcode_Txt)
        {
            return _Ware_Hanghoa_Dinhgia_Service.Get_All_Ware_Hanghoa_Ban_Dinhgia_By_Barcode(Barcode_Txt);
        }

        [WebMethod()]
        public string Get_All_Ware_Hanghoa_Dinhgia_Khuvuc(object Id_Hanghoa_Dinhgia)
        {
            return _Ware_Hanghoa_Dinhgia_Khuvuc_Service.Get_All_Ware_Hanghoa_Dinhgia_Khuvuc(Id_Hanghoa_Dinhgia);
        }

        [WebMethod()]
        public object Update_Ware_Hanghoa_Dinhgia_Khuvuc_Collection(DataSet dsCollection)
        {
            return _Ware_Hanghoa_Dinhgia_Khuvuc_Service.Update_Ware_Hanghoa_Dinhgia_Khuvuc_Collection(dsCollection);
        }
        #endregion

        #region Ware_Phieu_Thu
        [WebMethod(Description = "Trả về một dataset Phieuthu")]
        public string Get_Schema_Ware_Phieu_Thu()
        {
            return _Ware_Phieu_Thu_Service.Get_Schema_Ware_Phieu_Thu();
        }

        [WebMethod(Description = "Trả về một dataset Phieuthu")]
        public string Get_All_Ware_Phieu_Thu()
        {
            return _Ware_Phieu_Thu_Service.Get_All_Ware_Phieu_Thu();
        }

        [WebMethod(Description = "Trả về một dataset Phieuthu")]
        public string Ware_Phieu_Thu_SelectXuatkho_NotPay(object Id_Khachhang)
        {
            return _Ware_Phieu_Thu_Service.Ware_Phieu_Thu_SelectXuatkho_NotPay(Id_Khachhang);
        }

        [WebMethod(Description = "Trả về một dataset Phieuthu")]
        public string Ware_Phieu_Thu_SelectXuatkho_NotPayByMa_Khachhang(object Ma_Khachhang)
        {
            return _Ware_Phieu_Thu_Service.Ware_Phieu_Thu_SelectXuatkho_NotPayByMa_Khachhang(Ma_Khachhang);
        }

        [WebMethod(Description = "Trả về một dataset Phieuthu")]
        public string Ware_Phieu_Thu_SelectXuatkho_NotPay_ById_Cuahang_Ban(object Id_Cuahang_Ban)
        {
            return _Ware_Phieu_Thu_Service.Ware_Phieu_Thu_SelectXuatkho_NotPay_ById_Cuahang_Ban(Id_Cuahang_Ban);
        }

        [WebMethod(Description = "Trả về một dataset Phieuthu")]
        public string Ware_Phieu_Thu_SelectPhieu_Xuatkho_ById_Cuahang_Ban(object Id_Cuahang_Ban)
        {
            return _Ware_Phieu_Thu_Service.Ware_Phieu_Thu_SelectPhieu_Xuatkho_ById_Cuahang_Ban(Id_Cuahang_Ban);
        }

        [WebMethod(Description = "Trả về một dataset Phieuthu")]
        public string Ware_Phieu_Thu_SelectXuatkho_All(object Id_Khachhang)
        {
            return _Ware_Phieu_Thu_Service.Ware_Phieu_Thu_SelectXuatkho_All(Id_Khachhang);
        }

        [WebMethod(Description = "Trả về một dataset Phieuthu")]
        public string Ware_Phieu_Thu_SelectXuatkho_By_Ma_Khachhang(object Ma_Khachhang)
        {
            return _Ware_Phieu_Thu_Service.Ware_Phieu_Thu_SelectXuatkho_By_Ma_Khachhang(Ma_Khachhang);
        }

        [WebMethod(Description = "Trả về một dataset Phieuthu")]
        public string GetAll_Ware_Phieu_Thu(object Id_Cuahang_Ban)
        {
            return _Ware_Phieu_Thu_Service.GetAll_Ware_Phieu_Thu(Id_Cuahang_Ban);
        }

        [WebMethod(Description = "Trả về một dataset Phieuthu")]
        public string GetAll_Ware_Phieu_Thu_Date(object Id_Cuahang_Ban, object Thangnam, object Id_Khachhang)
        {
            return _Ware_Phieu_Thu_Service.GetAll_Ware_Phieu_Thu_Date(Id_Cuahang_Ban, Thangnam, Id_Khachhang);
        }

        [WebMethod(Description = "Trả về một dataset Phieuthu")]
        public string Ware_Phieu_Thu_SelectAll_New(object Id_Cuahang_Ban, object Thangnam, object Id_Khachhang)
        {
            return _Ware_Phieu_Thu_Service.Ware_Phieu_Thu_SelectAll_New(Id_Cuahang_Ban, Thangnam, Id_Khachhang);
        }

        [WebMethod(Description = "Trả về một dataset Phieuthu")]
        public string Ware_Phieu_Thu_SelectBy_Guid_Ctu(object Guid_Ctu)
        {
            return _Ware_Phieu_Thu_Service.Ware_Phieu_Thu_SelectBy_Guid_Ctu(Guid_Ctu);
        }

        [WebMethod(Description = "Trả về một dataset Phieuthu")]
        public string Ware_Phieu_Thu_SelectBy_PhieuXuat(string Chungtu_Goc)
        {
            return _Ware_Phieu_Thu_Service.Ware_Phieu_Thu_SelectBy_PhieuXuat(Chungtu_Goc);
        }

        [WebMethod(Description = "Trả về một dataset Phieuthu")]
        public string Ware_Phieu_Thu_SelectBy_Guid_Ctu_Edit(string Guid_Ctu)
        {
            return _Ware_Phieu_Thu_Service.Ware_Phieu_Thu_SelectBy_Guid_Ctu_Edit(Guid_Ctu);
        }

        [WebMethod(Description = "Insert đối tượng Ware_Phieu_Thu vào DB.")]
        public object Insert_Ware_Phieu_Thu(Ecm.Domain.Ware.Ware_Phieu_Thu Ware_Phieu_Thu)
        {
            return _Ware_Phieu_Thu_Service.Insert_Ware_Phieu_Thu(Ware_Phieu_Thu);
        }

        [WebMethod(Description = "Update đối tượng Ware_Phieu_Thu vào DB.")]
        public object Update_Ware_Phieu_Thu(Ecm.Domain.Ware.Ware_Phieu_Thu Ware_Phieu_Thu)
        {
            return _Ware_Phieu_Thu_Service.Update_Ware_Phieu_Thu(Ware_Phieu_Thu);
        }

        [WebMethod(Description = "Delete đối tượng Ware_Phieu_Thu vào DB.")]
        public object Delete_Ware_Phieu_Thu(Ecm.Domain.Ware.Ware_Phieu_Thu Ware_Phieu_Thu)
        {
            return _Ware_Phieu_Thu_Service.Delete_Ware_Phieu_Thu(Ware_Phieu_Thu);
        }

        [WebMethod(Description = "Update collection Ware_Phieu_Thu vào DB.")]
        public object Update_Ware_Phieu_Thu_Collection(DataSet dsCollection)
        {
            return _Ware_Phieu_Thu_Service.Update_Ware_Phieu_Thu_Collection(dsCollection);
        }

        [WebMethod(Description = "Update collection Ware_Phieu_Thu vào DB.")]
        public object Update_Ware_Phieu_Thu_Collection2(DataSet dsCollection)
        {
            return _Ware_Phieu_Thu_Service.Update_Ware_Phieu_Thu_Collection2(dsCollection);
        }

        #endregion

        #region Ware_Phieuthu_Congno
        [WebMethod(Description = "Trả về một dataset Phieuthu")]
        public string Get_All_Ware_Phieuthu_Congno()
        {
            return _Ware_Phieuthu_Congno_Service.Get_All_Ware_Phieuthu_Congno();
        }

        [WebMethod(Description = "Trả về một dataset Phieuthu_Congno_chitiet")]
        public string Ware_Congno_Khachhang(object ma_khachhang)
        {
            return _Ware_Phieuthu_Congno_Service.Ware_Congno_Khachhang(ma_khachhang);
        }


        [WebMethod(Description = "Trả về một dataset Phieuthu_Congno_chitiet")]
        public string Get_RptWare_Banhang_Congno_Thu(object ngay_Batdau, object ngay_Ketthuc, object id_Doituong)
        {
            return _Ware_Phieuthu_Congno_Service.Get_RptWare_Banhang_Congno_Thu(ngay_Batdau, ngay_Ketthuc, id_Doituong);
        }


        [WebMethod(Description = "Trả về một dataset Phieuthu_Congno_chitiet")]
        public string Get_RptWare_Banhang_Congno_Chuathu(object id_khachhang)
        {
            return _Ware_Phieuthu_Congno_Service.Get_RptWare_Banhang_Congno_Chuathu(id_khachhang);
        }


        [WebMethod(Description = "Insert đối tượng Ware_Phieuthu_Congno vào DB.")]
        public object Insert_Ware_Phieuthu_Congno(Ecm.Domain.Ware.Ware_Phieuthu_Congno Ware_Phieuthu_Congno)
        {
            return _Ware_Phieuthu_Congno_Service.Insert_Ware_Phieuthu_Congno(Ware_Phieuthu_Congno);
        }

        [WebMethod(Description = "Update đối tượng Ware_Phieuthu_Congno vào DB.")]
        public object Update_Ware_Phieuthu_Congno(Ecm.Domain.Ware.Ware_Phieuthu_Congno Ware_Phieuthu_Congno)
        {
            return _Ware_Phieuthu_Congno_Service.Update_Ware_Phieuthu_Congno(Ware_Phieuthu_Congno);
        }

        [WebMethod(Description = "Delete đối tượng Ware_Phieuthu_Congno vào DB.")]
        public object Delete_Ware_Phieuthu_Congno(Ecm.Domain.Ware.Ware_Phieuthu_Congno Ware_Phieuthu_Congno)
        {
            return _Ware_Phieuthu_Congno_Service.Delete_Ware_Phieuthu_Congno(Ware_Phieuthu_Congno);
        }

        [WebMethod(Description = "Update collection Ware_Phieuthu_Congno vào DB.")]
        public object Update_Ware_Phieuthu_Congno_Collection(DataSet dsCollection)
        {
            return _Ware_Phieuthu_Congno_Service.Update_Ware_Phieuthu_Congno_Collection(dsCollection);
        }

        [WebMethod(Description = "Ware_Phieuthu_Congno_chitiet_Init.")]
        public string Ware_Phieuthu_Congno_chitiet_Init()
        {
            return _Ware_Phieuthu_Congno_Service.Ware_Phieuthu_Congno_chitiet_Init();
        }

        [WebMethod(Description = "Trả về một dataset Phieuthu_Congno_chitiet")]
        public string Get_Ware_Phieuthu_Congno_chitiet_ByPCCongno(object Id_Phieuthu_Congno)
        {
            return _Ware_Phieuthu_Congno_Service.Get_Ware_Phieuthu_Congno_chitiet_ByPCCongno(Id_Phieuthu_Congno);
        }

        [WebMethod(Description = "Insert đối tượng Ware_Phieuthu_Congno vào DB.")]
        public object Insert_Ware_Phieuthu_Congno_chitiet(Ecm.Domain.Ware.Ware_Phieuthu_Congno_Chitiet Ware_Phieuthu_Congno_Chitiet)
        {
            return _Ware_Phieuthu_Congno_Service.Insert_Ware_Phieuthu_Congno_chitiet(Ware_Phieuthu_Congno_Chitiet);
        }

        [WebMethod(Description = "Delete đối tượng Ware_Phieuthu_Congno vào DB.")]
        public object Delete_Ware_Phieuthu_Congno_chitiet(object Id_Phieuthu_Congno)
        {
            return _Ware_Phieuthu_Congno_Service.Delete_Ware_Phieuthu_Congno_chitiet(Id_Phieuthu_Congno);
        }

        [WebMethod(Description = "Update collection Ware_Phieuthu_Congno_chitiet vào DB.")]
        public object Update_Ware_Phieuthu_Congno_chitiet_Collection(DataSet dsCollection)
        {
            return _Ware_Phieuthu_Congno_Service.Update_Ware_Phieuthu_Congno_chitiet_Collection(dsCollection);
        }
        #endregion

        #region Ware_Phieu_Chi
        [WebMethod(Description = "Trả về một dataset PhieuChi")]
        public string Get_All_Ware_Phieu_Chi()
        {
            return _Ware_Phieu_Chi_Service.Get_All_Ware_Phieu_Chi();
        }

        [WebMethod(Description = "Trả về một dataset PhieuChi")]
        public string GetAll_Ware_Phieu_Chi(object Id_Cuahang_Ban)
        {
            return _Ware_Phieu_Chi_Service.GetAll_Ware_Phieu_Chi(Id_Cuahang_Ban);
        }

        [WebMethod(Description = "Trả về một dataset PhieuChi")]
        public string GetAll_Ware_Phieu_Chi_Date(object Id_Cuahang_Ban, object Thangnam)
        {
            return _Ware_Phieu_Chi_Service.GetAll_Ware_Phieu_Chi_Date(Id_Cuahang_Ban, Thangnam);
        }

        [WebMethod(Description = "Insert đối tượng Ware_Phieu_Chi vào DB.")]
        public object Insert_Ware_Phieu_Chi(Ecm.Domain.Ware.Ware_Phieu_Chi Ware_Phieu_Chi)
        {
            return _Ware_Phieu_Chi_Service.Insert_Ware_Phieu_Chi(Ware_Phieu_Chi);
        }

        [WebMethod(Description = "Update đối tượng Ware_Phieu_Chi vào DB.")]
        public object Update_Ware_Phieu_Chi(Ecm.Domain.Ware.Ware_Phieu_Chi Ware_Phieu_Chi)
        {
            return _Ware_Phieu_Chi_Service.Update_Ware_Phieu_Chi(Ware_Phieu_Chi);
        }

        [WebMethod(Description = "Delete đối tượng Ware_Phieu_Chi vào DB.")]
        public object Delete_Ware_Phieu_Chi(Ecm.Domain.Ware.Ware_Phieu_Chi Ware_Phieu_Chi)
        {
            return _Ware_Phieu_Chi_Service.Delete_Ware_Phieu_Chi(Ware_Phieu_Chi);
        }

        [WebMethod(Description = "Update collection Ware_Phieu_Chi vào DB.")]
        public object Update_Ware_Phieu_Chi_Collection(DataSet dsCollection)
        {
            return _Ware_Phieu_Chi_Service.Update_Ware_Phieu_Chi_Collection(dsCollection);
        }
        #endregion

        #region Ware_Phieuchi_Congno
        [WebMethod(Description = "Trả về một dataset PhieuChi")]
        public string Get_All_Ware_Phieuchi_Congno()
        {
            return _Ware_Phieuchi_Congno_Service.Get_All_Ware_Phieuchi_Congno();
        }

        [WebMethod(Description = "Trả về một dataset PhieuChi")]
        public string Get_RptWare_Muahang_Congno_Tra(object ngay_Batdau, object ngay_Ketthuc, object id_doituong)
        {
            return _Ware_Phieuchi_Congno_Service.Get_RptWare_Muahang_Congno_Tra(ngay_Batdau, ngay_Ketthuc, id_doituong);
        }

        [WebMethod(Description = "Trả về một dataset PhieuChi")]
        public string Get_RptWare_Muahang_Congno_Chuatra(object id_Khachhang)
        {
            return _Ware_Phieuchi_Congno_Service.Get_RptWare_Muahang_Congno_Chuatra(id_Khachhang);
        }

        [WebMethod(Description = "Insert đối tượng Ware_Phieuchi_Congno vào DB.")]
        public object Insert_Ware_Phieuchi_Congno(Ecm.Domain.Ware.Ware_Phieuchi_Congno Ware_Phieuchi_Congno)
        {
            return _Ware_Phieuchi_Congno_Service.Insert_Ware_Phieuchi_Congno(Ware_Phieuchi_Congno);
        }

        [WebMethod(Description = "Update đối tượng Ware_Phieuchi_Congno vào DB.")]
        public object Update_Ware_Phieuchi_Congno(Ecm.Domain.Ware.Ware_Phieuchi_Congno Ware_Phieuchi_Congno)
        {
            return _Ware_Phieuchi_Congno_Service.Update_Ware_Phieuchi_Congno(Ware_Phieuchi_Congno);
        }

        [WebMethod(Description = "Delete đối tượng Ware_Phieuchi_Congno vào DB.")]
        public object Delete_Ware_Phieuchi_Congno(Ecm.Domain.Ware.Ware_Phieuchi_Congno Ware_Phieuchi_Congno)
        {
            return _Ware_Phieuchi_Congno_Service.Delete_Ware_Phieuchi_Congno(Ware_Phieuchi_Congno);
        }

        [WebMethod(Description = "Update collection Ware_Phieuchi_Congno vào DB.")]
        public object Update_Ware_Phieuchi_Congno_Collection(DataSet dsCollection)
        {
            return _Ware_Phieuchi_Congno_Service.Update_Ware_Phieuchi_Congno_Collection(dsCollection);
        }

        [WebMethod(Description = "Trả về một dataset Phieuchi_Congno_Chitiet")]
        public string Get_Ware_Phieuchi_Congno_Chuatra_ByDoituong(object Ma_Doituong)
        {
            return _Ware_Phieuchi_Congno_Service.Get_Ware_Phieuchi_Congno_Chuatra_ByDoituong(Ma_Doituong);
        }

        [WebMethod(Description = "Trả về một dataset Phieuchi_Congno_Chitiet")]
        public string Get_Ware_Phieuchi_Congno_Chitiet_ByPCCongno(object Id_Phieuchi_Congno)
        {
            return _Ware_Phieuchi_Congno_Service.Get_Ware_Phieuchi_Congno_Chitiet_ByPCCongno(Id_Phieuchi_Congno);
        }

        [WebMethod(Description = "Insert đối tượng Ware_Phieuchi_Congno vào DB.")]
        public object Insert_Ware_Phieuchi_Congno_Chitiet(Ecm.Domain.Ware.Ware_Phieuchi_Congno_Chititet Ware_Phieuchi_Congno_Chititet)
        {
            return _Ware_Phieuchi_Congno_Service.Insert_Ware_Phieuchi_Congno_Chitiet(Ware_Phieuchi_Congno_Chititet);
        }

        [WebMethod(Description = "Delete đối tượng Ware_Phieuchi_Congno vào DB.")]
        public object Delete_Ware_Phieuchi_Congno_Chitiet_ByPCCongno(object Id_Phieuchi_Congno)
        {
            return _Ware_Phieuchi_Congno_Service.Delete_Ware_Phieuchi_Congno_Chitiet_ByPCCongno(Id_Phieuchi_Congno);
        }
        #endregion

        #region Ware_Ql_Cuahang_Ban
        [WebMethod(Description = "Trả về một dataset Ql_Cuahang_Ban")]
        public string Get_All_Ware_Ql_Cuahang_Ban()
        {
            return _Ware_Ql_Cuahang_Ban_Service.Get_All_Ware_Ql_Cuahang_Ban();
        }

        [WebMethod(Description = "Trả về một dataset Ql_Cuahang_Ban by Id_Nhansu. Kho (boolean)")]
        public string Get_Ware_Ql_Cuahang_Ban_By_Id_Nhansu(object Id_Nhansu, object Kho)
        {
            return _Ware_Ql_Cuahang_Ban_Service.Get_Ware_Ql_Cuahang_Ban_By_Id_Nhansu(Id_Nhansu, Kho);
        }

        [WebMethod(Description = "Insert đối tượng Ware_Ql_Cuahang_Ban vào DB.")]
        public object Insert_Ware_Ql_Cuahang_Ban(Ecm.Domain.Ware.Ware_Ql_Cuahang_Ban Ware_Ql_Cuahang_Ban)
        {
            return _Ware_Ql_Cuahang_Ban_Service.Insert_Ware_Ql_Cuahang_Ban(Ware_Ql_Cuahang_Ban);
        }

        [WebMethod(Description = "Update đối tượng Ware_Ql_Cuahang_Ban vào DB.")]
        public object Update_Ware_Ql_Cuahang_Ban(Ecm.Domain.Ware.Ware_Ql_Cuahang_Ban Ware_Ql_Cuahang_Ban)
        {
            return _Ware_Ql_Cuahang_Ban_Service.Update_Ware_Ql_Cuahang_Ban(Ware_Ql_Cuahang_Ban);
        }

        [WebMethod(Description = "Delete đối tượng Ware_Ql_Cuahang_Ban vào DB.")]
        public object Delete_Ware_Ql_Cuahang_Ban(Ecm.Domain.Ware.Ware_Ql_Cuahang_Ban Ware_Ql_Cuahang_Ban)
        {
            return _Ware_Ql_Cuahang_Ban_Service.Delete_Ware_Ql_Cuahang_Ban(Ware_Ql_Cuahang_Ban);
        }

        [WebMethod(Description = "Update collection Ware_Ql_Cuahang_Ban vào DB.")]
        public object Update_Ware_Ql_Cuahang_Ban_Collection(DataSet dsCollection)
        {
            return _Ware_Ql_Cuahang_Ban_Service.Update_Ware_Ql_Cuahang_Ban_Collection(dsCollection);
        }
        #endregion

        #region Ware_Ql_Kho_Hanghoa_Mua

        //[WebMethod(Description = "Trả về một dataset Ql_Kho_Hanghoa_Mua")]
        //public string Get_All_Ware_Ql_Kho_Hanghoa_Mua()
        //{
        //    return _Ware_Ql_Kho_Hanghoa_Mua_Service.Get_All_Ware_Ql_Kho_Hanghoa_Mua();
        //}

        //[WebMethod(Description = "Insert đối tượng Ware_Ql_Kho_Hanghoa_Mua vào DB.")]
        //public object Insert_Ware_Ql_Kho_Hanghoa_Mua(Ecm.Domain.Ware.Ware_Ql_Kho_Hanghoa_Mua Ware_Ql_Kho_Hanghoa_Mua)
        //{
        //    return _Ware_Ql_Kho_Hanghoa_Mua_Service.Insert_Ware_Ql_Kho_Hanghoa_Mua(Ware_Ql_Kho_Hanghoa_Mua);
        //}

        //[WebMethod(Description = "Update đối tượng Ware_Ql_Kho_Hanghoa_Mua vào DB.")]
        //public object Update_Ware_Ql_Kho_Hanghoa_Mua(Ecm.Domain.Ware.Ware_Ql_Kho_Hanghoa_Mua Ware_Ql_Kho_Hanghoa_Mua)
        //{
        //    return _Ware_Ql_Kho_Hanghoa_Mua_Service.Update_Ware_Ql_Kho_Hanghoa_Mua(Ware_Ql_Kho_Hanghoa_Mua);
        //}

        //[WebMethod(Description = "Delete đối tượng Ware_Ql_Kho_Hanghoa_Mua vào DB.")]
        //public object Delete_Ware_Ql_Kho_Hanghoa_Mua(Ecm.Domain.Ware.Ware_Ql_Kho_Hanghoa_Mua Ware_Ql_Kho_Hanghoa_Mua)
        //{
        //    return _Ware_Ql_Kho_Hanghoa_Mua_Service.Delete_Ware_Ql_Kho_Hanghoa_Mua(Ware_Ql_Kho_Hanghoa_Mua);
        //}

        //[WebMethod(Description = "Update collection Ware_Ql_Kho_Hanghoa_Mua vào DB.")]
        //public object Update_Ware_Ql_Kho_Hanghoa_Mua_Collection(DataSet dsCollection)
        //{
        //    return _Ware_Ql_Kho_Hanghoa_Mua_Service.Update_Ware_Ql_Kho_Hanghoa_Mua_Collection(dsCollection);
        //}
        #endregion

        #region Ware_Hh_Cuahang_Ban
        [WebMethod(Description = "Trả về một dataset Hh_Cuahang_Ban")]
        public string Get_All_Ware_Hh_Cuahang_Ban()
        {
            return _Ware_Hh_Cuahang_Ban_Service.Get_All_Ware_Hh_Cuahang_Ban();
        }

        [WebMethod(Description = "Insert đối tượng Ware_Hh_Cuahang_Ban vào DB.")]
        public object Insert_Ware_Hh_Cuahang_Ban(Ecm.Domain.Ware.Ware_Hh_Cuahang_Ban Ware_Hh_Cuahang_Ban)
        {
            object cmdReturn = _Ware_Hh_Cuahang_Ban_Service.Insert_Ware_Hh_Cuahang_Ban(Ware_Hh_Cuahang_Ban);
            return cmdReturn;
        }

        [WebMethod(Description = "Update đối tượng Ware_Hh_Cuahang_Ban vào DB.")]
        public object Update_Ware_Hh_Cuahang_Ban(Ecm.Domain.Ware.Ware_Hh_Cuahang_Ban Ware_Hh_Cuahang_Ban)
        {
            object cmdReturn = _Ware_Hh_Cuahang_Ban_Service.Update_Ware_Hh_Cuahang_Ban(Ware_Hh_Cuahang_Ban);
            return cmdReturn;
        }

        [WebMethod(Description = "Delete đối tượng Ware_Hh_Cuahang_Ban vào DB.")]
        public object Delete_Ware_Hh_Cuahang_Ban(Ecm.Domain.Ware.Ware_Hh_Cuahang_Ban Ware_Hh_Cuahang_Ban)
        {
            object cmdReturn = _Ware_Hh_Cuahang_Ban_Service.Delete_Ware_Hh_Cuahang_Ban(Ware_Hh_Cuahang_Ban);
            return cmdReturn;
        }

        [WebMethod(Description = "Update collection Ware_Hh_Cuahang_Ban vào DB.")]
        public object Update_Ware_Hh_Cuahang_Ban_Collection(DataSet dsCollection)
        {
            object cmdReturn = _Ware_Hh_Cuahang_Ban_Service.Update_Ware_Hh_Cuahang_Ban_Collection(dsCollection);
            return cmdReturn;
        }
        #endregion

        #region Ware_Hh_Kho_Hanghoa_Mua

        //[WebMethod(Description = "Trả về một dataset Hh_Kho_Hanghoa_Mua")]
        //public string Get_All_Ware_Hh_Kho_Hanghoa_Mua()
        //{
        //    return _Ware_Hh_Kho_Hanghoa_Mua_Service.Get_All_Ware_Hh_Kho_Hanghoa_Mua();
        //}

        //[WebMethod(Description = "Insert đối tượng Ware_Hh_Kho_Hanghoa_Mua vào DB.")]
        //public object Insert_Ware_Hh_Kho_Hanghoa_Mua(Ecm.Domain.Ware.Ware_Hh_Kho_Hanghoa_Mua Ware_Hh_Kho_Hanghoa_Mua)
        //{
        //    return _Ware_Hh_Kho_Hanghoa_Mua_Service.Insert_Ware_Hh_Kho_Hanghoa_Mua(Ware_Hh_Kho_Hanghoa_Mua);
        //}

        //[WebMethod(Description = "Update đối tượng Ware_Hh_Kho_Hanghoa_Mua vào DB.")]
        //public object Update_Ware_Hh_Kho_Hanghoa_Mua(Ecm.Domain.Ware.Ware_Hh_Kho_Hanghoa_Mua Ware_Hh_Kho_Hanghoa_Mua)
        //{
        //    return _Ware_Hh_Kho_Hanghoa_Mua_Service.Update_Ware_Hh_Kho_Hanghoa_Mua(Ware_Hh_Kho_Hanghoa_Mua);
        //}

        //[WebMethod(Description = "Delete đối tượng Ware_Hh_Kho_Hanghoa_Mua vào DB.")]
        //public object Delete_Ware_Hh_Kho_Hanghoa_Mua(Ecm.Domain.Ware.Ware_Hh_Kho_Hanghoa_Mua Ware_Hh_Kho_Hanghoa_Mua)
        //{
        //    return _Ware_Hh_Kho_Hanghoa_Mua_Service.Delete_Ware_Hh_Kho_Hanghoa_Mua(Ware_Hh_Kho_Hanghoa_Mua);
        //}

        //[WebMethod(Description = "Update collection Ware_Hh_Kho_Hanghoa_Mua vào DB.")]
        //public object Update_Ware_Hh_Kho_Hanghoa_Mua_Collection(DataSet dsCollection)
        //{
        //    return _Ware_Hh_Kho_Hanghoa_Mua_Service.Update_Ware_Hh_Kho_Hanghoa_Mua_Collection(dsCollection);
        //}
        #endregion

        #region DocumentProcessStatus_Service
        [WebMethod]
        public string GetEDocStatusText(Ecm.Domain.Enumerators.EDocumentProcessStatus EDocStatus)
        {
            string statusTxt = "";
            switch (EDocStatus)
            {
                case Ecm.Domain.Enumerators.EDocumentProcessStatus.NewDoc:
                    statusTxt = "Mới lập";
                    break;
                case Ecm.Domain.Enumerators.EDocumentProcessStatus.TestDoc:
                    statusTxt = "Đã kiểm tra";
                    break;
                case Ecm.Domain.Enumerators.EDocumentProcessStatus.VerifyDoc:
                    statusTxt = "Đã xác nhận";
                    break;
            }
            return statusTxt;
        }
        [WebMethod]
        public Ecm.Domain.Enumerators.EDocumentProcessStatus GetEDocumentProcessStatus(int ivalue)
        {
            Ecm.Domain.Enumerators.EDocumentProcessStatus edoc = Ecm.Domain.Enumerators.EDocumentProcessStatus.NewDoc;
            switch (ivalue)
            {
                case 0:
                    edoc = Ecm.Domain.Enumerators.EDocumentProcessStatus.NewDoc;
                    break;
                case 1:
                    edoc = Ecm.Domain.Enumerators.EDocumentProcessStatus.TestDoc;
                    break;
                case 2:
                    edoc = Ecm.Domain.Enumerators.EDocumentProcessStatus.VerifyDoc;
                    break;
            }

            return edoc;
        }

        [WebMethod(Description = "")]
        public Ecm.Domain.Ware.DocumentProcessStatus Get_DocumentProcessStatus(Ecm.Domain.Ware.DocumentProcessStatus DocumentProcessStatus)
        {
            return _DocumentProcessStatus_Service.Get_DocumentProcessStatus(DocumentProcessStatus);
        }

        [WebMethod(Description = "")]
        public object Update_DocumentProcessStatus(Ecm.Domain.Ware.DocumentProcessStatus DocumentProcessStatus)
        {
            return _DocumentProcessStatus_Service.Update_DocumentProcessStatus(DocumentProcessStatus);
        }

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
        public object Getnew_Sohoadon_VAT(object Ma_Kho_HH)
        {
            return _DocumentProcessStatus_Service.Getnew_Sohoadon_VAT(Ma_Kho_HH);
        }

        [WebMethod(Description = "Tra ve so hoa don moi nhat cua ware_xuatkho_banhang")]
        public object Getnew_Sohoadon_XuatkhoBh(object Ma_Kho_HH)
        {
            return _DocumentProcessStatus_Service.Getnew_Sohoadon_XuatkhoBh(Ma_Kho_HH);
        }

        [WebMethod]
        public object GetExistReferences(object Table_Name, object Column_Name, object Lookup_Value)
        {
            return _DocumentProcessStatus_Service.GetExistReferences(Table_Name, Column_Name, Lookup_Value);
        }
        #endregion

        #region Ware_Ctrinh_Kmai

        //[WebMethod(Description = "Trả về một dataset Ware_Ctrinh_Kmai")]
        //public string Get_All_Ware_Ctrinh_Kmai()
        //{
        //    return _Ware_Ctrinh_Kmai_Service.Get_All_Ware_Ctrinh_Kmai();
        //}

        //[WebMethod(Description = "Trả về một dataset Ware_Ctrinh_Kmai (khách sạn)")]
        //public string Get_All_Ware_Ctrinh_Kmai_Rent()
        //{
        //    return _Ware_Ctrinh_Kmai_Service.Get_All_Ware_Ctrinh_Kmai_Rent();
        //}

        //[WebMethod]
        //public string Get_All_Ware_Ctrinh_Kmai_ByDate(object Ngay_Thanhtoan, object Rent) // Rent is true --> Khách sạn
        //{
        //    return _Ware_Ctrinh_Kmai_Service.Get_All_Ware_Ctrinh_Kmai_ByDate(Ngay_Thanhtoan, Rent);
        //}

        //[WebMethod]
        //public string Get_All_Ware_Ctrinh_Kmai_Chitiet_ByDate(object Ngay_Thanhtoan)
        //{
        //    return _Ware_Ctrinh_Kmai_Service.Get_All_Ware_Ctrinh_Kmai_Chitiet_ByDate(Ngay_Thanhtoan);
        //}

        //[WebMethod]
        //public string Ware_Ctrinh_Kmai_Chitiet_SelectByDate_WithHanghoa(object Ngay_Thanhtoan, object Rent)
        //{
        //    return _Ware_Ctrinh_Kmai_Service.Ware_Ctrinh_Kmai_Chitiet_SelectByDate_WithHanghoa(Ngay_Thanhtoan, Rent);
        //}

        //[WebMethod(Description = "Trả về một dataset Ware_Ctrinh_Kmai")]
        //public string Get_All_Ware_Ctrinh_Kmai_Chitiet_By_Ctrinh_Kmai(object id_Ctrinh_Kmai)
        //{
        //    return _Ware_Ctrinh_Kmai_Service.Get_All_Ware_Ctrinh_Kmai_Chitiet_By_Ctrinh_Kmai(id_Ctrinh_Kmai);
        //}

        //[WebMethod(Description = "Trả về một dataset Ware_Ctrinh_Kmai khách sạn")]
        //public string Get_All_Ware_Ctrinh_Kmai_Rent_Chitiet_By_Ctrinh_Kmai(object id_Ctrinh_Kmai)
        //{
        //    return _Ware_Ctrinh_Kmai_Service.Get_All_Ware_Ctrinh_Kmai_Rent_Chitiet_By_Ctrinh_Kmai(id_Ctrinh_Kmai);
        //}

        //[WebMethod(Description = "Insert đối tượng Ware_Ctrinh_Kmai vào DB.")]
        //public object Insert_Ware_Ctrinh_Kmai(Ecm.Domain.Ware.Ware_Ctrinh_Kmai Ware_Ctrinh_Kmai)
        //{
        //    return _Ware_Ctrinh_Kmai_Service.Insert_Ware_Ctrinh_Kmai(Ware_Ctrinh_Kmai);
        //}

        //[WebMethod(Description = "Update đối tượng Ware_Ctrinh_Kmai vào DB.")]
        //public object Update_Ware_Ctrinh_Kmai(Ecm.Domain.Ware.Ware_Ctrinh_Kmai Ware_Ctrinh_Kmai)
        //{
        //    return _Ware_Ctrinh_Kmai_Service.Update_Ware_Ctrinh_Kmai(Ware_Ctrinh_Kmai);
        //}

        //[WebMethod(Description = "Delete đối tượng Ware_Ctrinh_Kmai vào DB.")]
        //public object Delete_Ware_Ctrinh_Kmai(Ecm.Domain.Ware.Ware_Ctrinh_Kmai Ware_Ctrinh_Kmai)
        //{
        //    return _Ware_Ctrinh_Kmai_Service.Delete_Ware_Ctrinh_Kmai(Ware_Ctrinh_Kmai);
        //}

        //[WebMethod(Description = "Update collection Ware_Ctrinh_Kmai_Chitiet vào DB.")]
        //public object Update_Ware_Ctrinh_Kmai_Chitiet_Collection(DataSet dsCollection)
        //{
        //    return _Ware_Ctrinh_Kmai_Service.Update_Ware_Ctrinh_Kmai_Chitiet_Collection(dsCollection);
        //}

        //[WebMethod(Description = "Update collection Ware_Ctrinh_Kmai_Rent_Chitiet vào DB.")]
        //public object Update_Ware_Ctrinh_Kmai_Rent_Chitiet_Collection(DataSet dsCollection)
        //{
        //    return _Ware_Ctrinh_Kmai_Service.Update_Ware_Ctrinh_Kmai_Rent_Chitiet_Collection(dsCollection);
        //}

        #endregion

        #region Ware_Hdbanhang_Sum_Service
        [WebMethod]
        public string Get_All_Ware_Hdbanhang_Sum(Ecm.Domain.Ware.Ware_Hdbanhang_Sum Ware_Hdbanhang_Sum)
        {
            return _Ware_Hdbanhang_Sum_Service.Get_All_Ware_Hdbanhang_Sum(Ware_Hdbanhang_Sum);
        }

        [WebMethod]
        public object RptWare_Hdbanhang_Sum_Cal(Ecm.Domain.Ware.Ware_Hdbanhang_Sum Ware_Hdbanhang_Sum)
        {
            return _Ware_Hdbanhang_Sum_Service.RptWare_Hdbanhang_Sum_Cal(Ware_Hdbanhang_Sum);
        }

        [WebMethod]
        public object Update_Ware_Hdbanhang_Sum_Collection(DataSet dsCollection)
        {
            return _Ware_Hdbanhang_Sum_Service.Update_Ware_Hdbanhang_Sum_Collection(dsCollection);
        }

        #endregion

        #region Ware_Kh_Hh_Ban

        [WebMethod(Description = "Trả về một dataset Kh_Hh_Ban")]
        public string Get_All_Ware_Kh_Hh_Ban()
        {
            return _Ware_Kh_Hh_Ban_Service.Get_All_Ware_Kh_Hh_Ban();
        }

        [WebMethod(Description = "Trả về một dataset Kh_Hh_Ban")]
        public string Get_All_Ware_Kh_Hh_Ban_Chitiet_By_Kh_Hh_Ban(object id_Kh_Hh_Ban)
        {
            return _Ware_Kh_Hh_Ban_Service.Get_All_Ware_Kh_Hh_Ban_Chitiet_By_Kh_Hh_Ban(id_Kh_Hh_Ban);
        }

        [WebMethod(Description = "Insert đối tượng Ware_Kh_Hh_Ban vào DB.")]
        public object Insert_Ware_Kh_Hh_Ban(Ecm.Domain.Ware.Ware_Kh_Hh_Ban Ware_Kh_Hh_Ban)
        {
            return _Ware_Kh_Hh_Ban_Service.Insert_Ware_Kh_Hh_Ban(Ware_Kh_Hh_Ban);
        }

        [WebMethod(Description = "Update đối tượng Ware_Kh_Hh_Ban vào DB.")]
        public object Update_Ware_Kh_Hh_Ban(Ecm.Domain.Ware.Ware_Kh_Hh_Ban Ware_Kh_Hh_Ban)
        {
            return _Ware_Kh_Hh_Ban_Service.Update_Ware_Kh_Hh_Ban(Ware_Kh_Hh_Ban);
        }

        [WebMethod(Description = "Delete đối tượng Ware_Kh_Hh_Ban vào DB.")]
        public object Delete_Ware_Kh_Hh_Ban(Ecm.Domain.Ware.Ware_Kh_Hh_Ban Ware_Kh_Hh_Ban)
        {
            return _Ware_Kh_Hh_Ban_Service.Delete_Ware_Kh_Hh_Ban(Ware_Kh_Hh_Ban);
        }

        [WebMethod(Description = "Update collection Ware_Kh_Hh_Ban_Chitiet vào DB.")]
        public object Update_Ware_Kh_Hh_Ban_Chitiet_Collection(DataSet dsCollection)
        {
            return _Ware_Kh_Hh_Ban_Service.Update_Ware_Kh_Hh_Ban_Chitiet_Collection(dsCollection);
        }
        #endregion

        #region Rptware_Hanghoa_Service


        [WebMethod]
        public string Rptware_Hanghoa_Bangke_Chitiet(object Ngay_Batdau, object Ngay_Ketthuc, object Ma_Ql)
        {
            return _Rptware_Hanghoa_Service.Rptware_Hanghoa_Bangke_Chitiet(Ngay_Batdau, Ngay_Ketthuc, Ma_Ql);
        }

        [WebMethod]
        public string Rptware_Hanghoa_Bangke_Doanhso(object Ngay_Batdau, object Ngay_Ketthuc, object Ma_Ql)
        {
            return _Rptware_Hanghoa_Service.Rptware_Hanghoa_Bangke_Doanhso(Ngay_Batdau, Ngay_Ketthuc, Ma_Ql);
        }

        [WebMethod]
        public string Rptware_Nxt_Hhban_Sum(object Ngay_Batdau, object Ngay_Ketthuc, object Ma_Ql)
        {
            return _Rptware_Hanghoa_Service.Rptware_Nxt_Hhban_Sum(Ngay_Batdau, Ngay_Ketthuc, Ma_Ql);
        }

        [WebMethod]
        public string Rptware_Nxt_Hhban_Bangke(object Ngay_Batdau, object Ngay_Ketthuc, object Ma_Ql)
        {
            return _Rptware_Hanghoa_Service.Rptware_Nxt_Hhban_Bangke(Ngay_Batdau, Ngay_Ketthuc, Ma_Ql);
        }

        [WebMethod]
        public string RptWare_Hdbanhang_ByKhachhang(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Khachhang)
        {
            return _Rptware_Hanghoa_Service.RptWare_Hdbanhang_ByKhachhang(Ngay_Batdau, Ngay_Ketthuc, Id_Khachhang);
        }

        [WebMethod]
        public string RptWare_GetAllDataLog(object Ngay_Batdau, object Ngay_Ketthuc)
        {
            return _Rptware_Hanghoa_Service.RptWare_GetAllDataLog(Ngay_Batdau, Ngay_Ketthuc);
        }

        [WebMethod]
        public string Rptware_Nxt_Hhban_Qdoi(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Cuahang_Ban, object Id_Hanghoa_Ban, object Id_Donvitinh)
        {
            return _Rptware_Hanghoa_Service.Rptware_Nxt_Hhban_Qdoi(Ngay_Batdau, Ngay_Ketthuc, Id_Cuahang_Ban, Id_Hanghoa_Ban, Id_Donvitinh);
        }

        //check ton kho vs id_xuatkho_chitiet
        [WebMethod]
        public string Rptware_Nxt_Hhban_Qdoi_Id_Xuat_Chitiet(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Cuahang_Ban, object Id_Hanghoa_ban, object Id_Donvitinh, object Id_Xuat_Nguyenlieu_Chitiet)
        {
            return _Rptware_Hanghoa_Service.Rptware_Nxt_Hhban_Qdoi_Id_Xuat_Chitiet(Ngay_Batdau, Ngay_Ketthuc, Id_Cuahang_Ban, Id_Hanghoa_ban, Id_Donvitinh, Id_Xuat_Nguyenlieu_Chitiet);
        }

        [WebMethod]
        public string Rptware_Nxt_Qdoi_Id_Xuat_Nguyenlieu(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Cuahang_Ban, object Id_Hanghoa_ban, object Id_Donvitinh, object Id_Xuat_Nguyenlieu_Chitiet)
        {
            return _Rptware_Hanghoa_Service.Rptware_Nxt_Qdoi_Id_Xuat_Nguyenlieu(Ngay_Batdau, Ngay_Ketthuc, Id_Cuahang_Ban, Id_Hanghoa_ban, Id_Donvitinh, Id_Xuat_Nguyenlieu_Chitiet);
        }

        [WebMethod]
        public string Rptware_Nxt_Hhban_Qdoi_Id_Xuat_Chuyen_Chitiet(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Cuahang_Ban, object Id_Hanghoa_ban, object Id_Donvitinh, object Id_Xuat_Hh_Ban_Chitiet)
        {
            return _Rptware_Hanghoa_Service.Rptware_Nxt_Hhban_Qdoi_Id_Xuat_Chuyen_Chitiet(Ngay_Batdau, Ngay_Ketthuc, Id_Cuahang_Ban, Id_Hanghoa_ban, Id_Donvitinh, Id_Xuat_Hh_Ban_Chitiet);
        }

        [WebMethod(Description = "")]
        public object Ware_Dm_Dinhluong_Update_Collection(DataSet dsCollection)
        {
            return _Rptware_Hanghoa_Service.Ware_Dm_Dinhluong_Update_Collection(dsCollection);
        }

        [WebMethod(Description = "")]
        public string Ware_Dm_Dinhluong_SelectAll()
        {
            return _Rptware_Hanghoa_Service.Ware_Dm_Dinhluong_SelectAll();
        }

        [WebMethod(Description = "")]
        public string Ware_Dm_Dinhluong_SelectById_Nhansu(object Id_Nhansu)
        {
            return _Rptware_Hanghoa_Service.Ware_Dm_Dinhluong_SelectById_Nhansu(Id_Nhansu);
        }

        #endregion

        #region Ware_So_Quytm

        [WebMethod(Description = "Trả về một dataset So_Quytm")]
        public string Get_All_Ware_So_Quytm()
        {
            return _Ware_So_Quytm_Service.Get_All_Ware_So_Quytm();
        }

        [WebMethod(Description = "Trả về một đối tương So_Quytm")]
        public Ecm.Domain.Ware.Ware_So_Quytm Get_Ware_So_Quytm_ByThang_Nam(object thang, object nam)
        {
            return _Ware_So_Quytm_Service.Get_Ware_So_Quytm_ByThang_Nam(thang, nam);
        }

        [WebMethod(Description = "Trả về một đối tương So_Quytm")]
        public Ecm.Domain.Ware.Ware_So_Quytm Get_Ware_So_Quytm_ByThang_Nam_IdSoquy(object thang, object nam, object Id_Soquy)
        {
            return _Ware_So_Quytm_Service.Get_Ware_So_Quytm_ByThang_Nam_IdSoquy(thang, nam, Id_Soquy);
        }

        [WebMethod(Description = "Trả về một đối tương So_Quytm")]
        public int Get_Ware_So_Quytm_ByCount()
        {
            return _Ware_So_Quytm_Service.Get_Ware_So_Quytm_ByCount();
        }

        [WebMethod(Description = "Insert đối tượng Ware_So_Quytm vào DB.")]
        public object Insert_Ware_So_Quytm(Ecm.Domain.Ware.Ware_So_Quytm Ware_So_Quytm)
        {
            return _Ware_So_Quytm_Service.Insert_Ware_So_Quytm(Ware_So_Quytm);
        }

        [WebMethod(Description = "Update đối tượng Ware_So_Quytm vào DB.")]
        public object Update_Ware_So_Quytm(Ecm.Domain.Ware.Ware_So_Quytm Ware_So_Quytm)
        {
            return _Ware_So_Quytm_Service.Update_Ware_So_Quytm(Ware_So_Quytm);
        }

        [WebMethod(Description = "Delete đối tượng Ware_So_Quytm vào DB.")]
        public object Delete_Ware_So_Quytm(Ecm.Domain.Ware.Ware_So_Quytm Ware_So_Quytm)
        {
            return _Ware_So_Quytm_Service.Delete_Ware_So_Quytm(Ware_So_Quytm);
        }
        #endregion

        #region Ware_Congtac

        [WebMethod(Description = "Trả về một dataset ware_congtac")]
        public string Ware_Congtac_SelectAll(object Id_Nhansu, object Year)
        {
            return _Ware_Congtac_Services.Ware_Congtac_SelectAll(Id_Nhansu, Year);
        }

        [WebMethod(Description = "Trả về một dataset ware_congtac")]
        public string Ware_Congtac_SelectByDate(object Thang_Congtac, object Nam_Congtac, object Id_Nhansu)
        {
            return _Ware_Congtac_Services.Ware_Congtac_SelectByDate(Thang_Congtac, Nam_Congtac, Id_Nhansu);
        }

        [WebMethod(Description = "trả về một dataset ware_congtac theo id_nhansu")]
        public string Ware_Congtac_Select_ById_Nhansu_Vitri(object Id_Nhansu, object Vitri)
        {
            return _Ware_Congtac_Services.Ware_Congtac_Select_ById_Nhansu_Vitri(Id_Nhansu, Vitri);
        }

        [WebMethod(Description = "")]
        public object Ware_Congtac_Insert(Ecm.Domain.Ware.Ware_Congtac ware_congtac)
        {
            return _Ware_Congtac_Services.Ware_Congtac_Insert(ware_congtac);
        }

        [WebMethod(Description = "")]
        public object Ware_Congtac_Insert_String_Mobile(string objWare_Congtac)
        {
            Ecm.Domain.Ware.Ware_Congtac obj = new Domain.Ware.Ware_Congtac();
            obj = JsonConvert.DeserializeObject<Ecm.Domain.Ware.Ware_Congtac>(objWare_Congtac);
            return _Ware_Congtac_Services.Ware_Congtac_Insert(obj);
        }


        [WebMethod(Description = "")]
        public object Ware_Congtac_Update(Ecm.Domain.Ware.Ware_Congtac ware_congtac)
        {
            return _Ware_Congtac_Services.Ware_Congtac_Update(ware_congtac);
        }

        [WebMethod(Description = "")]
        public object Ware_Congtac_Update_Vitri(object Id_Congtac, object Vitri, object Lo_laf, object Lo_log)
        {
            return _Ware_Congtac_Services.Ware_Congtac_Update_Vitri(Id_Congtac, Vitri, Lo_laf, Lo_log);
        }

        [WebMethod(Description = "")]
        public object Ware_Congtac_Update_Vitri_Text(Ecm.Domain.Ware.Ware_Congtac ware_congtac)
        {
            return _Ware_Congtac_Services.Ware_Congtac_Update_Vitri_Text(ware_congtac);
        }


        [WebMethod(Description = "")]
        public object Ware_Congtac_Delete(object Id_Congtac)
        {
            return _Ware_Congtac_Services.Ware_Congtac_Delete(Id_Congtac);
        }

        [WebMethod(Description = "")]
        public object Update_Ware_Ware_Congtac_Collection(DataSet dsCollection)
        {
            return _Ware_Congtac_Services.Update_Ware_Ware_Congtac_Collection(dsCollection);
        }

        [WebMethod(Description = "")]
        public string Ware_Congtac_SelectKhachhang_New()
        {
            return _Ware_Congtac_Services.Ware_Congtac_SelectKhachhang_New();
        }

        #endregion

        #region kehoach_banhang

        [WebMethod(Description = "Trả về một dataset ware_congtac")]
        public string Ware_Kehoach_Banhang_SelectAll(object Id_Nhansu, object Ngay_Chungtu)
        {
            return _Ware_Kehoach_Banhang_Services.Ware_Kehoach_Banhang_GetAll(Id_Nhansu, Ngay_Chungtu);
        }

        [WebMethod(Description = "")]
        public object Ware_Kehoach_Banhang_Insert(Ecm.Domain.Ware.Ware_Kehoach_Banhang Ware_Kehoach_Banhang)
        {
            return _Ware_Kehoach_Banhang_Services.Ware_Kehoach_Banhang_Insert(Ware_Kehoach_Banhang);
        }

        [WebMethod(Description = "")]
        public object Ware_Kehoach_Banhang_Update(Ecm.Domain.Ware.Ware_Kehoach_Banhang Ware_Kehoach_Banhang)
        {
            return _Ware_Kehoach_Banhang_Services.Ware_Kehoach_Banhang_Update(Ware_Kehoach_Banhang);
        }

        [WebMethod(Description = "")]
        public object Ware_Kehoach_Banhang_Update_Doc(Ecm.Domain.Ware.Ware_Kehoach_Banhang Ware_Kehoach_Banhang)
        {
            return _Ware_Kehoach_Banhang_Services.Ware_Kehoach_Banhang_Update_Doc(Ware_Kehoach_Banhang);
        }

        [WebMethod(Description = "")]
        public object Ware_Kehoach_Banhang_Delete(object Id_Kehoach_Banhang)
        {
            return _Ware_Kehoach_Banhang_Services.Ware_Kehoach_Banhang_Delete(Id_Kehoach_Banhang);
        }

        [WebMethod(Description = "")]
        public object Update_Ware_Kehoach_Banhang_Collection(DataSet dsCollection)
        {
            return _Ware_Kehoach_Banhang_Services.Update_Ware_Kehoach_Banhang_Collection(dsCollection);
        }

        #endregion

        #region ware_kehoach_banhang_chitiet

        [WebMethod(Description = "")]
        public string Ware_Kehoach_Banhang_Chitiet_SelectById_Kehoach(object Id_Kehoach_Banhang)
        {
            return _Ware_Kehoach_Banhang_Chitiet_Services.Ware_Kehoach_Banhang_Chitiet_SelectById_Kehoach(Id_Kehoach_Banhang);
        }

        [WebMethod(Description = "")]
        public object Update_Ware_Kehoach_Banhang_Chitiet_Collection(DataSet dsCollection)
        {
            return _Ware_Kehoach_Banhang_Chitiet_Services.Update_Ware_Kehoach_Banhang_Chitiet_Collection(dsCollection);
        }

        #endregion

        #region Ware_Thumau

        [WebMethod(Description = "Trả về một dataset ")]
        public string Ware_Thumau_SelectAll(object Id_Nhansu, object Ngay_Thu)
        {
            return _Ware_Thumau_Services.Ware_Thumau_SelectAll(Id_Nhansu, Ngay_Thu);
        }

        [WebMethod(Description = "Trả về một dataset ")]
        public string Ware_Thumau_SelectByDate(object Ngay_Thu)
        {
            return _Ware_Thumau_Services.Ware_Thumau_SelectByDate(Ngay_Thu);
        }

        [WebMethod(Description = "")]
        public object Ware_Thumau_Insert(Ecm.Domain.Ware.Ware_Thumau Ware_Thumau)
        {
            return _Ware_Thumau_Services.Ware_Thumau_Insert(Ware_Thumau);
        }

        [WebMethod(Description = "")]
        public object Ware_Thumau_Update(Ecm.Domain.Ware.Ware_Thumau Ware_Thumau)
        {
            return _Ware_Thumau_Services.Ware_Thumau_Update(Ware_Thumau);
        }

        [WebMethod(Description = "")]
        public object Ware_Thumau_Delete(object Id_Congtac)
        {
            return _Ware_Thumau_Services.Ware_Thumau_Delete(Id_Congtac);
        }

        [WebMethod(Description = "")]
        public object Update_Ware_Ware_Thumau_Collection(DataSet dsCollection)
        {
            return _Ware_Thumau_Services.Update_Ware_Ware_Thumau_Collection(dsCollection);
        }

        #endregion

        #region phantich_thitruong

        [WebMethod(Description = "Trả về một dataset ")]
        public string Ware_Phantich_Thitruong_SelectAll(object Id_Nhansu, object Ngay_Taophieu)
        {
            return _Ware_Phantich_Thitruong_Services.Ware_Phantich_Thitruong_SelectAll(Id_Nhansu, Ngay_Taophieu);
        }

        [WebMethod(Description = "")]
        public object Ware_Phantich_Thitruong_Insert(Ecm.Domain.Ware.Ware_Phantich_Thitruong _Ware_Phantich_Thitruong)
        {
            return _Ware_Phantich_Thitruong_Services.Ware_Phantich_Thitruong_Insert(_Ware_Phantich_Thitruong);
        }

        [WebMethod(Description = "")]
        public object Ware_Phantich_Thitruong_Update(Ecm.Domain.Ware.Ware_Phantich_Thitruong _Ware_Phantich_Thitruong)
        {
            return _Ware_Phantich_Thitruong_Services.Ware_Phantich_Thitruong_Update(_Ware_Phantich_Thitruong);
        }

        [WebMethod(Description = "")]
        public object Ware_Phantich_Thitruong_Delete(object Id_Phantich_Thitruong)
        {
            return _Ware_Phantich_Thitruong_Services.Ware_Phantich_Thitruong_Delete(Id_Phantich_Thitruong);
        }

        #endregion

        #region phantich_thitruong_chitiet

        [WebMethod(Description = "Trả về một dataset ")]
        public string Ware_Phantich_Thitruong_Chitiet_SelectBy_Id_Phantich_Thitruong(object Id_Phantich_Thitruong)
        {
            return _Ware_Phantich_Thitruong_Chitiet_Services.Ware_Phantich_Thitruong_Chitiet_SelectBy_Id_Phantich_Thitruong(Id_Phantich_Thitruong);
        }

        [WebMethod(Description = "")]
        public object Update_Ware_Phantich_Thitruong_Chitiet_Collection(DataSet dsCollection)
        {
            return _Ware_Phantich_Thitruong_Chitiet_Services.Update_Ware_Phantich_Thitruong_Chitiet_Collection(dsCollection);
        }

        #endregion

        #region kehoach_dathang

        [WebMethod(Description = "Trả về một dataset ")]
        public string Ware_Kehoach_Dathang_GetAll(object Id_Nhansu, object Ngay_Chungtu)
        {
            return _Ware_Kehoach_Dathang_Services.Ware_Kehoach_Dathang_GetAll(Id_Nhansu, Ngay_Chungtu);
        }

        [WebMethod(Description = " ")]
        public object Ware_Kehoach_Dathang_Insert(Ecm.Domain.Ware.Ware_Kehoach_Dathang ware_Kehoach_dathang)
        {
            return _Ware_Kehoach_Dathang_Services.Ware_Kehoach_Dathang_Insert(ware_Kehoach_dathang);
        }

        [WebMethod(Description = " ")]
        public object Ware_Kehoach_Dathang_Update(Ecm.Domain.Ware.Ware_Kehoach_Dathang ware_Kehoach_dathang)
        {
            return _Ware_Kehoach_Dathang_Services.Ware_Kehoach_Dathang_Update(ware_Kehoach_dathang);
        }

        [WebMethod(Description = " ")]
        public object Ware_Kehoach_Dathang_Delete(object Id_Kehoach_Dathang)
        {
            return _Ware_Kehoach_Dathang_Services.Ware_Kehoach_Dathang_Delete(Id_Kehoach_Dathang);
        }

        #endregion

        #region kehoach_dathang_chitiet

        [WebMethod(Description = "")]
        public string Ware_Kehoach_Dathang_Chitiet_SelectById_Kehoach_Dathang(object Id_Kehoach_Dathang)
        {
            return _Ware_Kehoach_Dathang_Chitiet_Services.Ware_Kehoach_Dathang_Chitiet_SelectById_Kehoach_Dathang(Id_Kehoach_Dathang);
        }

        [WebMethod(Description = "")]
        public object Update_Ware_Kehoach_Dathang_Chitiet_Collection(DataSet dsCollection)
        {
            return _Ware_Kehoach_Dathang_Chitiet_Services.Update_Ware_Kehoach_Dathang_Chitiet_Collection(dsCollection);
        }

        #endregion

        #region ware_dieuxe

        [WebMethod(Description = " ")]
        public object Update_Ware_Dieuxe_Chitiet_Collection(DataSet dsCollection)
        {
            return _Ware_Dieuxe_Service.Update_Ware_Dieuxe_Chitiet_Collection(dsCollection);
        }

        [WebMethod(Description = " ")]
        public object Update_Ware_Dieuxe_Chitiet_Collection2(DataSet dsCollection)
        {
            return _Ware_Dieuxe_Service.Update_Ware_Dieuxe_Chitiet_Collection2(dsCollection);
        }

        [WebMethod(Description = " ")]
        public object Update_Ware_Dieuxe_Chitiet_Tmp_Collection(DataSet dsCollection)
        {
            return _Ware_Dieuxe_Service.Update_Ware_Dieuxe_Chitiet_Tmp_Collection(dsCollection);
        }

        [WebMethod(Description = " ")]
        public object Ware_Dieuxe_Chitiet_Tmp_DeleteBy_Sochungtu(object Sochungtu)
        {
            return _Ware_Dieuxe_Service.Ware_Dieuxe_Chitiet_Tmp_DeleteBy_Sochungtu(Sochungtu);
        }

        [WebMethod(Description = " ")]
        public object Ware_Dieuxe_Chitiet_DeleteBy_Sochungtu(object Sochungtu)
        {
            return _Ware_Dieuxe_Service.Ware_Dieuxe_Chitiet_DeleteBy_Sochungtu(Sochungtu);
        }

        [WebMethod(Description = " ")]
        public object Ware_Dieuxe_Chitiet_Tmp_Delete()
        {
            return _Ware_Dieuxe_Service.Ware_Dieuxe_Chitiet_Tmp_Delete();
        }

        [WebMethod(Description = "Trả về một dataset ")]
        public string Ware_Dieuxe_Chitiet_SelectBy_Id_Dieuxe(object Id_Dieuxe)
        {
            return _Ware_Dieuxe_Service.Ware_Dieuxe_Chitiet_SelectBy_Id_Dieuxe(Id_Dieuxe);
        }

        [WebMethod(Description = "Trả về một dataset ")]
        public string Ware_Dieuxe_SelectBy_Mathang(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Hanghoa_Ban, object Id_Taixe, object Id_Xe)
        {
            return _Ware_Dieuxe_Service.Ware_Dieuxe_SelectBy_Mathang(Ngay_Batdau, Ngay_Ketthuc, Id_Hanghoa_Ban, Id_Taixe, Id_Xe);
        }

        [WebMethod(Description = "Trả về một dataset ")]
        public string Ware_Dieuxe_Chitiet_SelectBy_Id_Dieuxe_Group(object Id_Dieuxe)
        {
            return _Ware_Dieuxe_Service.Ware_Dieuxe_Chitiet_SelectBy_Id_Dieuxe_Group(Id_Dieuxe);
        }

        [WebMethod(Description = "Trả về một dataset ")]
        public string Ware_Dieuxe_Chitiet_Tmp_SelectBy_Guid_Dieuxe(object Guid_Dieuxe)
        {
            return _Ware_Dieuxe_Service.Ware_Dieuxe_Chitiet_Tmp_SelectBy_Guid_Dieuxe(Guid_Dieuxe);
        }

        [WebMethod(Description = "Trả về một dataset ")]
        public string Ware_Dieuxe_Chitiet_Tmp_SelectAll_By_Guid_Dieuxe(object Guid_Dieuxe)
        {
            return _Ware_Dieuxe_Service.Ware_Dieuxe_Chitiet_Tmp_SelectAll_By_Guid_Dieuxe(Guid_Dieuxe);
        }

        [WebMethod(Description = "Trả về một dataset ")]
        public string Ware_Dieuxe_Chitiet_SelectBy_Id_Dieuxe_Mail(object Id_Dieuxe)
        {
            return _Ware_Dieuxe_Service.Ware_Dieuxe_Chitiet_SelectBy_Id_Dieuxe_Mail(Id_Dieuxe);
        }

        [WebMethod(Description = "Trả về một dataset ")]
        public string Ware_Dieuxe_Thongke_ByXe(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Xe)
        {
            return _Ware_Dieuxe_Service.Ware_Dieuxe_Thongke_ByXe(Ngay_Batdau, Ngay_Ketthuc, Id_Xe);
        }

        [WebMethod(Description = "Trả về một dataset ")]
        public string Get_All_Ware_Dieuxe(object Thangnam, object Id_Cuahang_Ban)
        {
            return _Ware_Dieuxe_Service.Get_All_Ware_Dieuxe(Thangnam, Id_Cuahang_Ban);
        }

        [WebMethod(Description = "Trả về một dataset ")]
        public string Ware_Dieuxe_Thongke_Tonghop(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Cuahang_Ban)
        {
            return _Ware_Dieuxe_Service.Ware_Dieuxe_Thongke_Tonghop(Ngay_Batdau, Ngay_Ketthuc, Id_Cuahang_Ban);
        }

        [WebMethod(Description = "Trả về một dataset ")]
        public string Ware_Dieuxe_SelectBy_Id_Xuatkho(object Id_Xuatkho_Banhang)
        {
            return _Ware_Dieuxe_Service.Ware_Dieuxe_SelectBy_Id_Xuatkho(Id_Xuatkho_Banhang);
        }

        [WebMethod(Description = " ")]
        public object Insert_Ware_Dieuxe(Ecm.Domain.Ware.Ware_Dieuxe ware_dieuxe)
        {
            return _Ware_Dieuxe_Service.Insert_Ware_Dieuxe(ware_dieuxe);
        }

        [WebMethod(Description = " ")]
        public object Update_Ware_Dieuxe(Ecm.Domain.Ware.Ware_Dieuxe ware_dieuxe)
        {
            return _Ware_Dieuxe_Service.Update_Ware_Dieuxe(ware_dieuxe);
        }

        [WebMethod(Description = " ")]
        public object Delete_Ware_Dieuxe(Ecm.Domain.Ware.Ware_Dieuxe ware_dieuxe)
        {
            return _Ware_Dieuxe_Service.Delete_Ware_Dieuxe(ware_dieuxe);
        }

        [WebMethod(Description = " ")]
        public object Update_Ware_Dieuxe_Collection(DataSet dsCollection)
        {
            return _Ware_Dieuxe_Service.Update_Ware_Dieuxe_Collection(dsCollection);
        }

        [WebMethod(Description = " ")]
        public object Update_Ware_Dieuxe_Xuatkho_Collection(DataSet dsCollection)
        {
            return _Ware_Dieuxe_Service.Update_Ware_Dieuxe_Xuatkho_Collection(dsCollection);
        }

        [WebMethod(Description = " ")]
        public object Ware_Dieuxe_Xuatkho_Delete_ById_Dieuxe(object Id_Dieuxe)
        {
            return _Ware_Dieuxe_Service.Ware_Dieuxe_Xuatkho_Delete_ById_Dieuxe(Id_Dieuxe);
        }

        [WebMethod(Description = " ")]
        public object Update_Ware_Dieuxe_Cuahang_Ban_Collection(DataSet dsCollection)
        {
            return _Ware_Dieuxe_Service.Update_Ware_Dieuxe_Cuahang_Ban_Collection(dsCollection);
        }

        [WebMethod(Description = "Trả về một dataset ")]
        public string Get_Schema_Ware_Dieuxe_Xuatkho()
        {
            return _Ware_Dieuxe_Service.Get_Schema_Ware_Dieuxe_Xuatkho();
        }

        [WebMethod(Description = "Trả về một dataset ")]
        public string Get_Schema_Ware_Dieuxe_Cuahang_Ban()
        {
            return _Ware_Dieuxe_Service.Get_Schema_Ware_Dieuxe_Cuahang_Ban();
        }

        [WebMethod(Description = "Trả về một dataset ")]
        public string Ware_Dieuxe_Cuahang_Ban_SelectBy_Id_Dieuxe(object Id_Dieuxe)
        {
            return _Ware_Dieuxe_Service.Ware_Dieuxe_Cuahang_Ban_SelectBy_Id_Dieuxe(Id_Dieuxe);
        }

        [WebMethod(Description = " ")]
        public object Delete_Ware_Dieuxe_Xuatkho(object Id_Dieuxe_Xuatkho)
        {
            return _Ware_Dieuxe_Service.Delete_Ware_Dieuxe_Xuatkho(Id_Dieuxe_Xuatkho);
        }


        #endregion

        #endregion

        #region WareGen

        //#region WareGen_Dm_Congthuc_Phache
        //[WebMethod(Description = "Trả về một dataset Dm_Congthuc_Phache")]
        //public string Get_All_WareGen_Dm_Congthuc_Phache()
        //{
        //    return _WareGen_Dm_Congthuc_Phache_Service.Get_All_WareGen_Dm_Congthuc_Phache();
        //}

        //[WebMethod(Description = "Insert đối tượng WareGen_Dm_Congthuc_Phache vào DB.")]
        //public object Insert_WareGen_Dm_Congthuc_Phache(Ecm.Domain.MasterTables.Ware.Ware_Dm_Congthuc_Phache WareGen_Dm_Congthuc_Phache)
        //{
        //    return _WareGen_Dm_Congthuc_Phache_Service.Insert_WareGen_Dm_Congthuc_Phache(WareGen_Dm_Congthuc_Phache);
        //}

        //[WebMethod(Description = "Update đối tượng WareGen_Dm_Congthuc_Phache vào DB.")]
        //public object Update_WareGen_Dm_Congthuc_Phache(Ecm.Domain.MasterTables.Ware.Ware_Dm_Congthuc_Phache WareGen_Dm_Congthuc_Phache)
        //{
        //    return _WareGen_Dm_Congthuc_Phache_Service.Update_WareGen_Dm_Congthuc_Phache(WareGen_Dm_Congthuc_Phache);
        //}

        //[WebMethod(Description = "Delete đối tượng WareGen_Dm_Congthuc_Phache vào DB.")]
        //public object Delete_WareGen_Dm_Congthuc_Phache(Ecm.Domain.MasterTables.Ware.Ware_Dm_Congthuc_Phache WareGen_Dm_Congthuc_Phache)
        //{
        //    return _WareGen_Dm_Congthuc_Phache_Service.Delete_WareGen_Dm_Congthuc_Phache(WareGen_Dm_Congthuc_Phache);
        //}

        //[WebMethod(Description = "Update collection WareGen_Dm_Congthuc_Phache vào DB.")]
        //public object Update_WareGen_Dm_Congthuc_Phache_Collection(DataSet dsCollection)
        //{
        //    return _WareGen_Dm_Congthuc_Phache_Service.Update_WareGen_Dm_Congthuc_Phache_Collection(dsCollection);
        //}
        //#endregion

        //#region WareGen_Dm_Congthuc_Phache_Chitiet
        //[WebMethod(Description = "Trả về một dataset Dm_Congthuc_Phache_Chitiet")]
        //public string Get_All_WareGen_Dm_Congthuc_Phache_Chitiet()
        //{
        //    return _WareGen_Dm_Congthuc_Phache_Chitiet_Service.Get_All_WareGen_Dm_Congthuc_Phache_Chitiet();
        //}

        //[WebMethod(Description = "Trả về một dataset Dm_Congthuc_Phache_Chitiet")]
        //public string Get_All_WareGen_Dm_Congthuc_Phache_Chitiet_ByHHBan(object Id_Hanghoa_Ban)
        //{
        //    return _WareGen_Dm_Congthuc_Phache_Chitiet_Service.Get_All_WareGen_Dm_Congthuc_Phache_Chitiet_ByHHBan(Id_Hanghoa_Ban);
        //}

        //[WebMethod(Description = "Insert đối tượng WareGen_Dm_Congthuc_Phache_Chitiet vào DB.")]
        //public object Insert_WareGen_Dm_Congthuc_Phache_Chitiet(Ecm.Domain.MasterTables.Ware.Ware_Dm_Congthuc_Phache_Chitiet WareGen_Dm_Congthuc_Phache_Chitiet)
        //{
        //    return _WareGen_Dm_Congthuc_Phache_Chitiet_Service.Insert_WareGen_Dm_Congthuc_Phache_Chitiet(WareGen_Dm_Congthuc_Phache_Chitiet);
        //}

        //[WebMethod(Description = "Update đối tượng WareGen_Dm_Congthuc_Phache_Chitiet vào DB.")]
        //public object Update_WareGen_Dm_Congthuc_Phache_Chitiet(Ecm.Domain.MasterTables.Ware.Ware_Dm_Congthuc_Phache_Chitiet WareGen_Dm_Congthuc_Phache_Chitiet)
        //{
        //    return _WareGen_Dm_Congthuc_Phache_Chitiet_Service.Update_WareGen_Dm_Congthuc_Phache_Chitiet(WareGen_Dm_Congthuc_Phache_Chitiet);
        //}

        //[WebMethod(Description = "Delete đối tượng WareGen_Dm_Congthuc_Phache_Chitiet vào DB.")]
        //public object Delete_WareGen_Dm_Congthuc_Phache_Chitiet(Ecm.Domain.MasterTables.Ware.Ware_Dm_Congthuc_Phache_Chitiet WareGen_Dm_Congthuc_Phache_Chitiet)
        //{
        //    return _WareGen_Dm_Congthuc_Phache_Chitiet_Service.Delete_WareGen_Dm_Congthuc_Phache_Chitiet(WareGen_Dm_Congthuc_Phache_Chitiet);
        //}

        //[WebMethod(Description = "Update collection WareGen_Dm_Congthuc_Phache_Chitiet vào DB.")]
        //public object Update_WareGen_Dm_Congthuc_Phache_Chitiet_Collection(DataSet dsCollection)
        //{
        //    return _WareGen_Dm_Congthuc_Phache_Chitiet_Service.Update_WareGen_Dm_Congthuc_Phache_Chitiet_Collection(dsCollection);
        //}
        //#endregion

        #region WareGen_Hdbanhang
        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_WareGen_Hdbanhang()
        {
            return _WareGen_Hdbanhang_Service.Get_All_WareGen_Hdbanhang();
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_WareGen_Hdbanhang_2(object Ngay_Batdau, object Ngay_Ketthuc, object Ma_Kho_Hanghoa)
        {
            return _WareGen_Hdbanhang_Service.Get_All_WareGen_Hdbanhang(Ngay_Batdau, Ngay_Ketthuc, Ma_Kho_Hanghoa);
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang by Barcode")]
        public string Get_All_Ware_Hdbanhang_By_Barcode(object barCode)
        {
            return _WareGen_Hdbanhang_Service.Get_All_Ware_Hdbanhang_By_Barcode(barCode);
        }


        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_WareGen_Quydoi_Hhmua_Fr_Hhban(object Ngay_Batdau, object Ngay_Ketthuc)
        {
            return _WareGen_Hdbanhang_Service.Get_All_WareGen_Quydoi_Hhmua_Fr_Hhban(Ngay_Batdau, Ngay_Ketthuc);
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_WareGen_Hdbanhang_ByCuahang(object Id_Cuahang_Ban)
        {
            return _WareGen_Hdbanhang_Service.Get_All_WareGen_Hdbanhang_ByCuahang(Id_Cuahang_Ban);
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_WareGen_Hdbanhang_ByKhoHanghoa(object Id_Kho_Hanghoa_Mua)
        {
            return _WareGen_Hdbanhang_Service.Get_All_WareGen_Hdbanhang_ByKhoHanghoa(Id_Kho_Hanghoa_Mua);
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_WareGen_Hdbanhang_Hhban()
        {
            return _WareGen_Hdbanhang_Service.Get_All_WareGen_Hdbanhang_Hhban();
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_WareGen_Hdbanhang_Hhmua()
        {
            return _WareGen_Hdbanhang_Service.Get_All_WareGen_Hdbanhang_Hhmua();
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_WareGen_Hdbanhang_Novat_Hhmua()
        {
            return _WareGen_Hdbanhang_Service.Get_All_WareGen_Hdbanhang_Novat_Hhmua();
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_WareGen_Hdbanhang_Novat_Hhmua_ByKhohh(object Id_Kho_Hanghoa_Mua)
        {
            return _WareGen_Hdbanhang_Service.Get_All_WareGen_Hdbanhang_Novat_Hhmua_ByKhohh(Id_Kho_Hanghoa_Mua);
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_WareGen_Hdbanhang_Novat_Hhmua_ByKhohh_2(object Id_Kho_Hanghoa_Mua, object Ngay_Chungtu)
        {
            return _WareGen_Hdbanhang_Service.Get_All_WareGen_Hdbanhang_Novat_Hhmua_ByKhohh(Id_Kho_Hanghoa_Mua, Ngay_Chungtu);
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_WareGen_Hdbanhang_Novat_Hhban()
        {
            return _WareGen_Hdbanhang_Service.Get_All_WareGen_Hdbanhang_Novat_Hhban();
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_WareGen_Hdbanhang_Novat_Hhban_ByCuahang(object Id_Cuahang_Ban)
        {
            return _WareGen_Hdbanhang_Service.Get_All_WareGen_Hdbanhang_Novat_Hhban_ByCuahang(Id_Cuahang_Ban);
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_WareGen_Hdbanhang_Novat_Hhban_ByCuahang_2(object Id_Cuahang_Ban, object Ngay_Chungtu)
        {
            return _WareGen_Hdbanhang_Service.Get_All_WareGen_Hdbanhang_Novat_Hhban_ByCuahang(Id_Cuahang_Ban, Ngay_Chungtu);
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_WareGen_Hdbanhang_Novat_Hhban_Cash_ByCuahang(object Id_Cuahang_Ban)
        {
            return _WareGen_Hdbanhang_Service.Get_All_WareGen_Hdbanhang_Novat_Hhban_Cash_ByCuahang(Id_Cuahang_Ban);
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_WareGen_Hdbanhang_Chitiet_By_Hdbanhang(object id_donbanhang)
        {
            return _WareGen_Hdbanhang_Service.Get_All_WareGen_Hdbanhang_Chitiet_ByHdbanhang(id_donbanhang);
        }

        [WebMethod(Description = "Trả về một dataset Hdbanhang")]
        public string Get_All_WareGen_Hdbanhang_Chitiet_Log_ByHdbanhang(object id_donbanhang)
        {
            return _WareGen_Hdbanhang_Service.Get_All_WareGen_Hdbanhang_Chitiet_Log_ByHdbanhang(id_donbanhang);
        }

        [WebMethod(Description = "Insert đối tượng WareGen_Hdbanhang vào DB.")]
        public object Insert_WareGen_Hdbanhang(Ecm.Domain.Ware.Ware_Hdbanhang WareGen_Hdbanhang)
        {
            return _WareGen_Hdbanhang_Service.Insert_WareGen_Hdbanhang(WareGen_Hdbanhang);
        }

        [WebMethod(Description = "Update đối tượng WareGen_Hdbanhang vào DB.")]
        public object Update_WareGen_Hdbanhang(Ecm.Domain.Ware.Ware_Hdbanhang WareGen_Hdbanhang)
        {
            return _WareGen_Hdbanhang_Service.Update_WareGen_Hdbanhang(WareGen_Hdbanhang);
        }

        [WebMethod(Description = "Delete đối tượng WareGen_Hdbanhang vào DB.")]
        public object Delete_WareGen_Hdbanhang(Ecm.Domain.Ware.Ware_Hdbanhang WareGen_Hdbanhang)
        {
            return _WareGen_Hdbanhang_Service.Delete_WareGen_Hdbanhang(WareGen_Hdbanhang);
        }
        [WebMethod(Description = "Delete đối tượng WareGen_Hdbanhang vào DB.")]
        public object Delete_WareGen_Hdbanhang_ByDonmuahang(Ecm.Domain.Ware.Ware_Donmuahang Ware_Donmuahang)
        {
            return _WareGen_Hdbanhang_Service.Delete_WareGen_Hdbanhang_ByDonmuahang(Ware_Donmuahang);
        }

        [WebMethod(Description = "Update collection WareGen_Hdbanhang_Chitiet vào DB.")]
        public object Update_WareGen_Hdbanhang_Chitiet_Collection(DataSet dsCollection)
        {
            return _WareGen_Hdbanhang_Service.Update_WareGen_Hdbanhang_Chitiet_Collection(dsCollection);
        }

        [WebMethod(Description = "Update collection WareGen_Hdbanhang_Chitiet vào DB.")]
        public object Update_WareGen_Hdbanhang_Chitiet_Log_Collection(DataSet dsCollection)
        {
            return _WareGen_Hdbanhang_Service.Update_WareGen_Hdbanhang_Chitiet_Log_Collection(dsCollection);
        }

        #endregion

        #region WareGen_Donmuahang
        [WebMethod(Description = "Trả về một dataset Donmuahang")]
        public string Get_All_WareGen_Donmuahang()
        {
            return _WareGen_Donmuahang_Service.Get_All_WareGen_Donmuahang();
        }

        [WebMethod(Description = "Trả về một dataset Donmuahang")]
        public string Get_All_WareGen_Donmuahang_Chitiet_By_Donmuahang(object id_donmuahang)
        {
            return _WareGen_Donmuahang_Service.Get_All_WareGen_Donmuahang_Chitiet_By_Donmuahang(id_donmuahang);
        }

        [WebMethod(Description = "Trả về một dataset Donmuahang")]
        public string Get_All_WareGen_Hdbanhang_Chitiet_By_Donmuahang(object id_donmuahang)
        {
            return _WareGen_Donmuahang_Service.Get_All_WareGen_Hdbanhang_Chitiet_By_Donmuahang(id_donmuahang);
        }

        [WebMethod(Description = "Trả về một dataset Donmuahang")]
        public string Get_All_WareGen_Ncc_By_Donmuahang_Chitiet(object id_donmuahang_chitiet)
        {
            return _WareGen_Donmuahang_Service.Get_All_Ware_Ncc_By_Donmuahang_Chitiet(id_donmuahang_chitiet);
        }

        [WebMethod(Description = "Trả về một dataset Donmuahang")]
        public string Get_All_WareGen_Ncc_By_Donmuahang(object id_donmuahang)
        {
            return _WareGen_Donmuahang_Service.Get_All_Ware_Ncc_By_Donmuahang(id_donmuahang);
        }

        [WebMethod(Description = "Insert đối tượng WareGen_Donmuahang vào DB.")]
        public object Insert_WareGen_Donmuahang(Ecm.Domain.Ware.Ware_Donmuahang WareGen_Donmuahang)
        {
            return _WareGen_Donmuahang_Service.Insert_WareGen_Donmuahang(WareGen_Donmuahang);
        }

        [WebMethod(Description = "Update đối tượng WareGen_Donmuahang vào DB.")]
        public object Update_WareGen_Donmuahang(Ecm.Domain.Ware.Ware_Donmuahang WareGen_Donmuahang)
        {
            return _WareGen_Donmuahang_Service.Update_WareGen_Donmuahang(WareGen_Donmuahang);
        }

        [WebMethod(Description = "Delete đối tượng WareGen_Donmuahang vào DB.")]
        public object Delete_WareGen_Donmuahang(Ecm.Domain.Ware.Ware_Donmuahang WareGen_Donmuahang)
        {
            return _WareGen_Donmuahang_Service.Delete_WareGen_Donmuahang(WareGen_Donmuahang);
        }

        [WebMethod(Description = "Update collection WareGen_Donmuahang_Chitiet vào DB.")]
        public object Update_WareGen_Donmuahang_Chitiet_Collection(DataSet dsCollection)
        {
            return _WareGen_Donmuahang_Service.Update_WareGen_Donmuahang_Chitiet_Collection(dsCollection);
        }

        [WebMethod(Description = "Update collection WareGen_Donmuahang_Chitiet_Ncc vào DB.")]
        public object Update_WareGen_Donmuahang_Chitiet_Ncc_Collection(DataSet dsCollection)
        {
            return _WareGen_Donmuahang_Service.Update_WareGen_Donmuahang_Chitiet_Ncc_Collection(dsCollection);
        }

        [WebMethod(Description = "Tra ve ds nxt hang hoa mua")]
        public string Get_All_WareGen_Nxt_Hhmua(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Kho_Hanghoa_Mua)
        {
            return _WareGen_Donmuahang_Service.Get_All_Ware_Nxt_Hhmua(Ngay_Batdau, Ngay_Ketthuc, Id_Kho_Hanghoa_Mua);
        }
        #endregion

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

    }

}
