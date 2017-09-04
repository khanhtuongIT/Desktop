using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Ecm.Domain.Bar;
using Ecm.Service.Bar;
using Ecm.Service.Ware;

namespace Ecm.Webservice
{
    /// <summary>
    /// Summary description for BarService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BarService : System.Web.Services.WebService
    {
        //Connectiion
        System.Data.OleDb.OleDbConnection sqlConnection = Ecm.Webservice.DbConnection.OleDbConnection;

        #region Khai báo các đối tượng service - bar
        Bar_Table_Order_Service _Bar_Table_Order_Service;
        Bar_Table_Booking_Service _Bar_Table_Booking_Service;
        Bar_Kitchen_Printer_Service _Bar_Kitchen_Printer_Service;
        Bar_Winecard_Service _Bar_Winecard_Service;
        Bar_Rentcost_Service _Bar_Rentcost_Service;
        Bar_Rent_Reserve_Service _Bar_Rent_Reserve_Service;
        Bar_Rent_Checkin_Service _Bar_Rent_Checkin_Service;
        #endregion

        DocumentProcessStatus_Service _DocumentProcessStatus_Service;


        public BarService()
        {
            #region Khởi tạo các đối tượng service - bar

            _Bar_Table_Order_Service = new Bar_Table_Order_Service(sqlConnection);
            _Bar_Table_Booking_Service = new Bar_Table_Booking_Service(sqlConnection);
            _Bar_Kitchen_Printer_Service = new Bar_Kitchen_Printer_Service(sqlConnection);
            _Bar_Winecard_Service = new Bar_Winecard_Service(sqlConnection);
            _Bar_Rentcost_Service = new Bar_Rentcost_Service(sqlConnection);
            _Bar_Rent_Reserve_Service = new Bar_Rent_Reserve_Service(sqlConnection);
            _Bar_Rent_Checkin_Service = new Bar_Rent_Checkin_Service(sqlConnection);
            #endregion

            _DocumentProcessStatus_Service = new DocumentProcessStatus_Service(sqlConnection);
        }

        #region Bar_Table_Order

        [WebMethod(BufferResponse = true, Description = "update lại trạng thái lock của bar_table_order")]
        public object Bar_Table_Order_Update_Lock(object Id_Table_Order, object Lock_Status)
        {
            //RemoveOutputCacheItem
            HttpResponse.RemoveOutputCacheItem("/Ecm.Webservices/BarService.asmx");

            return _Bar_Table_Order_Service.Bar_Table_Order_Update_Lock(Id_Table_Order, Lock_Status);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public object Bar_Table_Order_Xuat_Nvl(object Id_Cuahang_Ban, object Id_Table_Order, object Id_Checkin)
        {
            return _Bar_Table_Order_Service.Bar_Table_Order_Xuat_Nvl(Id_Cuahang_Ban, Id_Table_Order, Id_Checkin);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Bar_Table_Order")]
        public string Get_All_Bar_Table_Order(object Without_Empty_Table, object Id_Cuahang_Ban)
        {
            return _Bar_Table_Order_Service.Get_All_Bar_Table_Order(Without_Empty_Table, Id_Cuahang_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Bar_Table_Order By Id_Cuahang_Ban")]
        public string Get_All_Bar_Table_Order_By_Id_Cuahang(object Id_Cuahang_Ban)
        {
            return _Bar_Table_Order_Service.Get_All_Bar_Table_Order_By_Id_Cuahang(Id_Cuahang_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Bar_Table_Order By Id_Cuahang_Ban And Id_Khuvuc")]
        public string Get_All_Bar_Table_Order_By_Id_Cuahang_And_Id_Khuvuc(object Id_Cuahang_Ban, object Id_Khuvuc)
        {
            return _Bar_Table_Order_Service.Get_All_Bar_Table_Order_By_Id_Cuahang_And_Id_Khuvuc(Id_Cuahang_Ban, Id_Khuvuc);
        }
        

        [WebMethod(BufferResponse = true, Description = "")]
        public object Get_Finish_Bar_Table_Order(object Id_Table_Order)
        {
            return _Bar_Table_Order_Service.Get_Finish_Bar_Table_Order(Id_Table_Order);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Bar_Table_Order by ngày order or vitri")]
        public string Get_All_Bar_Table_Order_By_DateOrder(object Without_Empty_Table, object ngayOrder, object viTri)
        {
            return _Bar_Table_Order_Service.Get_All_Bar_Table_Order_By_Date_Order(Without_Empty_Table, ngayOrder, viTri);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Bar_Table_Order_Chitiet")]
        public string Get_All_Bar_Table_Order_Chitiet()
        {
            return _Bar_Table_Order_Service.Get_All_Bar_Table_Order_Chitiet();
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Bar_Table_Order_Chitiet")]
        public string Get_All_Bar_Table_Order_Chitiet_ById_Nhom_Hanghoa_Ban(object Id_Nhom_Hanghoa_Ban, object Id_Cuahang_Ban)
        {
            return _Bar_Table_Order_Service.Get_All_Bar_Table_Order_Chitiet(Id_Nhom_Hanghoa_Ban, Id_Cuahang_Ban);
        }
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Bar_Table_Order_Chitiet")]
        public string Get_Book_Bar_Table_Order_Chitiet(object Id_Nhom_Hanghoa_Ban)
        {
            return _Bar_Table_Order_Service.Get_Book_Bar_Table_Order_Chitiet(Id_Nhom_Hanghoa_Ban);
        }
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Bar_Table_Order_Chitiet")]
        public string Get_All_Bar_Table_Order_Chitiet_Served()
        {
            return _Bar_Table_Order_Service.Get_All_Bar_Table_Order_Chitiet_Served();
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Bar_Table_Order")]
        public string Get_All_Bar_Table_Order_Chitiet_ById_Order(object id_order)
        {
            return _Bar_Table_Order_Service.Get_All_Bar_Table_Order_Chitiet_ById_Order(id_order);
        }



        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Bar_Table_Order")]
        public string Get_All_Bar_Table_Order_Chitiet_Log_ById_Order(object id_order)
        {
            return _Bar_Table_Order_Service.Get_All_Bar_Table_Order_Chitiet_Log_ById_Order(id_order);
        }
        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Bar_Table_Order vào DB")]
        public object Insert_Bar_Table_Order(Domain.Bar.Bar_Table_Order Bar_Table_Order)
        {
            //RemoveOutputCacheItem
            HttpResponse.RemoveOutputCacheItem("/Ecm.Webservices/BarService.asmx");

            return _Bar_Table_Order_Service.Insert_Bar_Table_Order(Bar_Table_Order);
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Bar_Table_Order vào DB")]
        public object Insert_Bar_Table_Order_For_Web(object Id_Nhansu_Order, object Ngay_Order,
            object Id_Ca_Lamviec, object Id_Table, object Id_Cuahang_Ban, object Sochungtu)
        {
            //RemoveOutputCacheItem
            HttpResponse.RemoveOutputCacheItem("/Ecm.Webservices/BarService.asmx");

            return _Bar_Table_Order_Service.Insert_Bar_Table_Order_For_Web(Id_Nhansu_Order, Ngay_Order, Id_Ca_Lamviec, Id_Table, Id_Cuahang_Ban, Sochungtu);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Bar_Table_Order vào DB")]
        public object Update_Bar_Table_Order_For_Web(object Id_Table_Order, object Id_Nhansu_Order, object Ngay_Order,
            object Id_Ca_Lamviec, object Id_Table, object Id_Cuahang_Ban, object Sochungtu)
        {
            //RemoveOutputCacheItem
            HttpResponse.RemoveOutputCacheItem("/Ecm.Webservices/BarService.asmx");

            return _Bar_Table_Order_Service.Update_Bar_Table_Order_For_Web(Id_Table_Order, Id_Nhansu_Order,Ngay_Order,Id_Ca_Lamviec,Id_Table,Id_Cuahang_Ban,Sochungtu);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Bar_Table_Order vào DB")]
        public object Update_Bar_Table_Order(Ecm.Domain.Bar.Bar_Table_Order Bar_Table_Order)
        {
            //RemoveOutputCacheItem
            HttpResponse.RemoveOutputCacheItem("/Ecm.Webservices/BarService.asmx");

            return _Bar_Table_Order_Service.Update_Bar_Table_Order(Bar_Table_Order);
        }

        [WebMethod(BufferResponse = true, Description = "Update thành tiền km = null khi tách, ghép bàn")]
        public object Update_Id_Khachhang_Bar_Table_Order(object id_Table_Order)
        {
            //RemoveOutputCacheItem
            HttpResponse.RemoveOutputCacheItem("/Ecm.Webservices/BarService.asmx");

            return _Bar_Table_Order_Service.Update_Id_Khachhang_Bar_Table_Order(id_Table_Order);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Bar_Table_Order vào DB")]
        public object Update_Bar_Table_Order_Chitiet(object id_table_order_chitiet, object soluong_phucvu, object Hotel)
        {
            //RemoveOutputCacheItem
            HttpResponse.RemoveOutputCacheItem("/Ecm.Webservices/BarService.asmx");
            return _Bar_Table_Order_Service.Update_Bar_Table_Order_Chitiet(id_table_order_chitiet, soluong_phucvu, Hotel);
        }


        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Bar_Table_Order vào DB")]
        public object Delete_Bar_Table_Order(Ecm.Domain.Bar.Bar_Table_Order Bar_Table_Order)
        {
            //RemoveOutputCacheItem
            HttpResponse.RemoveOutputCacheItem("/Ecm.Webservices/BarService.asmx");

            return _Bar_Table_Order_Service.Delete_Bar_Table_Order(Bar_Table_Order);
        }

        [WebMethod(BufferResponse = true, Description = "Update Collection Bar_Table_Order vào DB")]
        public object Update_Bar_Table_Order_Chitiet_Collection(DataSet dsCollection)
        {
            try
            {
                //RemoveOutputCacheItem
                HttpResponse.RemoveOutputCacheItem("/Ecm.Webservices/BarService.asmx");

                object result = _Bar_Table_Order_Service.Update_Bar_Table_Order_Chitiet_Collection(dsCollection);
                return result;
            }
            catch (Exception ex)
            {
                //RemoveOutputCacheItem
                HttpResponse.RemoveOutputCacheItem("/Ecm.Webservices/BarService.asmx");
                throw ex;               
            }
        }

        [WebMethod(BufferResponse = true, Description = "Update Collection Bar_Table_Order vào DB")]
        public object Update_Bar_Table_Order_Chitiet_Log_Collection(DataSet dsCollection)
        {
            //RemoveOutputCacheItem
            HttpResponse.RemoveOutputCacheItem("/Ecm.Webservices/BarService.asmx");

            return _Bar_Table_Order_Service.Update_Bar_Table_Order_Chitiet_Log_Collection(dsCollection);
        }
      
        #endregion

        #region Bar_Table_Booking
        [WebMethod(BufferResponse = true, Description = "return list all booking")]
        public string Get_All_Bar_Table_Booking()
        {
            return _Bar_Table_Booking_Service.Get_All_Table_Booking();
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public object GetBar_Table_Booking_Tien_Booking_By_Id_Booking(object Id_Booking)
        {
            return _Bar_Table_Booking_Service.GetBar_Table_Booking_Tien_Booking_By_Id_Booking(Id_Booking);
        }

        [WebMethod(BufferResponse = true, Description = "Insert đối tượng Bar_Table_Booking vào DB")]
        public object Insert_Bar_Table_Booking(Ecm.Domain.Bar.Bar_Table_Booking Bar_Table_Booking)
        {
            return _Bar_Table_Booking_Service.Insert_Bar_Table_Booking(Bar_Table_Booking);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Bar_Table_Booking vào DB")]
        public object Update_Bar_Table_Booking(Ecm.Domain.Bar.Bar_Table_Booking Bar_Table_Booking)
        {
            return _Bar_Table_Booking_Service.Update_Bar_Table_Booking(Bar_Table_Booking);
        }

        [WebMethod(BufferResponse = true, Description = "Update đối tượng Bar_Table_Booking sau khi kết thúc bàn")]
        public object Update_Bar_Table_Booking_to_Finish(object id_Booking)
        {
            return _Bar_Table_Booking_Service.Update_Bar_Table_Booking_Finish(id_Booking);
        }

        [WebMethod(BufferResponse = true, Description = "Delete đối tượng Bar_Table_Booking")]
        public object Delete_Bar_Table_Booking(object Id_Booking)
        {
            return _Bar_Table_Booking_Service.Delete_Bar_Table_Booking(Id_Booking);
        }

        [WebMethod(BufferResponse = true, Description = "GetAll_Bar_Table_Booking_Chitiet_By_Id_Booking")]
        public string GetAll_Bar_Table_Booking_Chitiet_By_Id_Booking(object Id_Booking)
        {
            return _Bar_Table_Booking_Service.Get_All_Bar_Table_Booking_Chitiet_ById_Booking(Id_Booking);
        }

        [WebMethod(BufferResponse = true, Description = "Update Collection Bar_Table_Booking_Chitiet vào DB")]
        public object Update_Bar_Table_Booking_Chitiet_Collection(DataSet dsCollection)
        {
            return _Bar_Table_Booking_Service.Update_Bar_Table_Booking_Chitiet_Collection(dsCollection);

        }
        #endregion

        #region Bar_Kitchen_Printer_Service
        [WebMethod(BufferResponse = true, Description = "")]
        public string Get_All_Bar_Kitchen_Printer()
        {
            return _Bar_Kitchen_Printer_Service.Get_All_Bar_Kitchen_Printer();
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public string Get_All_Bar_Kitchen_Printer_ByPC_Code(object PC_Code)
        {
            return _Bar_Kitchen_Printer_Service.Get_All_Bar_Kitchen_Printer_ByPC_Code(PC_Code);
        }
        [WebMethod(BufferResponse = true, Description = "")]

        public string GetPrinter_From_Bar_Kitchen_Printer(object PC_Code)
        {
            return _Bar_Kitchen_Printer_Service.GetPrinter_From_Bar_Kitchen_Printer(PC_Code);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public object Insert_Bar_Kitchen_Printer(Ecm.Domain.Bar.Bar_Kitchen_Printer bar_kitchen_printer)
        {
            return _Bar_Kitchen_Printer_Service.Insert_Bar_Kitchen_Printer(bar_kitchen_printer);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public object Update_Bar_Kitchen_Printer(Ecm.Domain.Bar.Bar_Kitchen_Printer bar_kitchen_printer)
        {
            return _Bar_Kitchen_Printer_Service.Update_Bar_Kitchen_Printer(bar_kitchen_printer);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public object Delete_Bar_Kitchen_Printer(Ecm.Domain.Bar.Bar_Kitchen_Printer bar_kitchen_printer)
        {
            return _Bar_Kitchen_Printer_Service.Delete_Bar_Kitchen_Printer(bar_kitchen_printer);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public object Update_Bar_Kitchen_Printer_Collection(DataSet dsCollection)
        {
            return _Bar_Kitchen_Printer_Service.Update_Bar_Kitchen_Printer_Collection(dsCollection);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public string FetchPrinter_Bar_Kitchen_Order_Chitiet(object PC_Code, object Id_Cuahang_Ban)
        {
            return _Bar_Kitchen_Printer_Service.FetchPrinter_Bar_Kitchen_Order_Chitiet(PC_Code, Id_Cuahang_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public string GetLog_Bar_Kitchen_Order_Chitiet(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Cuahang_Ban)
        {
            return _Bar_Kitchen_Printer_Service.GetLog_Bar_Kitchen_Order_Chitiet(Ngay_Batdau, Ngay_Ketthuc, Id_Cuahang_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public string GetTopLog_Bar_Kitchen_Order_Chitiet(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Cuahang_Ban)
        {
            return _Bar_Kitchen_Printer_Service.GetTopLog_Bar_Kitchen_Order_Chitiet(Ngay_Batdau, Ngay_Ketthuc, Id_Cuahang_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public string GetNotLog_Bar_Kitchen_Order_Chitiet(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Cuahang_Ban)
        {
            return _Bar_Kitchen_Printer_Service.GetNotLog_Bar_Kitchen_Order_Chitiet(Ngay_Batdau, Ngay_Ketthuc, Id_Cuahang_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public string GetServed_Bar_Kitchen_Order_Chitiet(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Cuahang_Ban)
        {
            return _Bar_Kitchen_Printer_Service.GetServed_Bar_Kitchen_Order_Chitiet(Ngay_Batdau, Ngay_Ketthuc, Id_Cuahang_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public string GetNVL_Bar_Kitchen_Order_Chitiet(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Cuahang_Ban)
        {
            return _Bar_Kitchen_Printer_Service.GetNVL_Bar_Kitchen_Order_Chitiet(Ngay_Batdau, Ngay_Ketthuc, Id_Cuahang_Ban);
        }
        #endregion

        #region Bar_Winecard_Service - 130318
        [WebMethod(BufferResponse = true, Description = "")]
        public string Get_All_Bar_Winecard(object Id_Cuahang_Ban, object ThangNam, object Id_Khachhang)
        {
            return _Bar_Winecard_Service.Get_All_Bar_Winecard(Id_Cuahang_Ban, ThangNam, Id_Khachhang);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public string GetBar_Winecard_ById(object Id_Winecard)
        {
            return _Bar_Winecard_Service.GetBar_Winecard_ById(Id_Winecard);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public object Insert_Bar_Winecard(Ecm.Domain.Bar.Bar_Winecard bar_winecard)
        {
            return _Bar_Winecard_Service.Insert_Bar_Winecard(bar_winecard);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public object Update_Bar_Winecard(Ecm.Domain.Bar.Bar_Winecard bar_winecard)
        {
            return _Bar_Winecard_Service.Update_Bar_Winecard(bar_winecard);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public object Delete_Bar_Winecard(Ecm.Domain.Bar.Bar_Winecard bar_winecard)
        {
            return _Bar_Winecard_Service.Delete_Bar_Winecard(bar_winecard);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public object Update_Bar_Winecard_Collection(DataSet dsCollection)
        {
            return _Bar_Winecard_Service.Update_Bar_Winecard_Collection(dsCollection);
        }

        #endregion

        #region Bar_Rentcost - 130801
        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Bar_Dm_Table")]
        public string Get_All_Bar_Rentcost_Collection(object Id_Cuahang_Ban, object Id_Class, object Ngay_Batdau)
        {
            return _Bar_Rentcost_Service.Get_All_Bar_Rentcost_Collection(Id_Cuahang_Ban, Id_Class, Ngay_Batdau);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Bar_Dm_Table")]
        public object Update_Bar_Rentcost_Collection(DataSet dsCollection)
        {
            return _Bar_Rentcost_Service.Update_Bar_Rentcost_Collection(dsCollection);
        }

        [WebMethod(BufferResponse = true, Description = "Trả về một dataset Bar_Dm_Table")]
        public bool Bar_Rentcost_CheckDate(Ecm.Domain.Bar.Bar_Rentcost Bar_Rentcost)
        {
            return _Bar_Rentcost_Service.Bar_Rentcost_CheckDate(Bar_Rentcost);
        }

        #endregion

        #region Bar_Rent_Reserve_Service - 130806

        [WebMethod(BufferResponse = true, Description = "")]
        public string Get_All_Bar_Rent_Reserve(object ThangNam, object Id_Cuahang_Ban)
        {
            return _Bar_Rent_Reserve_Service.Get_All_Bar_Rent_Reserve(ThangNam, Id_Cuahang_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public string Get_All_Bar_Rent_Reserve_ByArrivalDate(object ThangNam, object Id_Cuahang_Ban)
        {
            return _Bar_Rent_Reserve_Service.Get_All_Bar_Rent_Reserve_ByArrivalDate(ThangNam, Id_Cuahang_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public string GetBar_Rent_Reserve_ById(object Id_Reserve)
        {
            return _Bar_Rent_Reserve_Service.GetBar_Rent_Reserve_ById(Id_Reserve);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public object Insert_Bar_Rent_Reserve(Ecm.Domain.Bar.Bar_Rent_Reserve Bar_Rent_Reserve)
        {
            return _Bar_Rent_Reserve_Service.Insert_Bar_Rent_Reserve(Bar_Rent_Reserve);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public object Update_Bar_Rent_Reserve(Ecm.Domain.Bar.Bar_Rent_Reserve Bar_Rent_Reserve)
        {
            return _Bar_Rent_Reserve_Service.Update_Bar_Rent_Reserve(Bar_Rent_Reserve);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public object Delete_Bar_Rent_Reserve(Ecm.Domain.Bar.Bar_Rent_Reserve Bar_Rent_Reserve)
        {
            return _Bar_Rent_Reserve_Service.Delete_Bar_Rent_Reserve(Bar_Rent_Reserve);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public object Update_Bar_Rent_Reserve_Collection(DataSet dsCollection)
        {
            return _Bar_Rent_Reserve_Service.Update_Bar_Rent_Reserve_Collection(dsCollection);
        }

        [WebMethod]
        public string Get_All_Bar_Rent_Reserve_Table(object Guid_Reserve)
        {
            return _Bar_Rent_Reserve_Service.Get_All_Bar_Rent_Reserve_Table(Guid_Reserve);
        }

        [WebMethod]
        public object Update_Bar_Rent_Reserve_Table_Collection(DataSet dsCollection)
        {
            return _Bar_Rent_Reserve_Service.Update_Bar_Rent_Reserve_Table_Collection(dsCollection);
        }

        [WebMethod]
        public string Get_All_Bar_Rent_Reserve_Phieuthu(object Guid_Reserve)
        {
            return _Bar_Rent_Reserve_Service.Get_All_Bar_Rent_Reserve_Phieuthu(Guid_Reserve);
        }

        [WebMethod]
        public object Update_Bar_Rent_Reserve_Phieuthu_Collection(DataSet dsCollection)
        {
            return _Bar_Rent_Reserve_Service.Update_Bar_Rent_Reserve_Phieuthu_Collection(dsCollection);
        }

        [WebMethod]
        public string Get_Bar_Rent_Reserve_Table_Lookup(object Id_Cuahang_Ban, object Ngay_Batdau, object Ngay_Ketthuc)
        {
            return _Bar_Rent_Reserve_Service.Get_Bar_Rent_Reserve_Table_Lookup(Id_Cuahang_Ban, Ngay_Batdau, Ngay_Ketthuc);
        }
        #endregion

        #region Bar_Rent_Checkin_Service - 130826

        [WebMethod(BufferResponse = true, Description = "")]
        public string Get_All_Bar_Rent_Checkin_Khachhang(object Guid_Checkin)
        {
            return _Bar_Rent_Checkin_Service.Get_All_Bar_Rent_Checkin_Khachhang(Guid_Checkin);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public string Bar_Rent_Checkin_Khachhang_SelectByGuid_Checkin_Table(object Guid_Checkin_Table)
        {
            return _Bar_Rent_Checkin_Service.Bar_Rent_Checkin_Khachhang_SelectByGuid_Checkin_Table(Guid_Checkin_Table);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public object Update_Bar_Rent_Checkin_Khachhang_Collection(DataSet dsCollection)
        {
            return _Bar_Rent_Checkin_Service.Update_Bar_Rent_Checkin_Khachhang_Collection(dsCollection);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public object Update_Bar_Rent_Check_Out(object Id_Checkin)
        {
            return _Bar_Rent_Checkin_Service.Update_Bar_Rent_Check_Out(Id_Checkin);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public string Get_Bar_Rent_Checkin_Table_Report_Total(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Cuahang_Ban)
        {
            return _Bar_Rent_Checkin_Service.Get_Bar_Rent_Checkin_Table_Report_Total(Ngay_Batdau, Ngay_Ketthuc, Id_Cuahang_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public string Get_Bar_Rent_Checkin_Order_Report_Total(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Cuahang_Ban)
        {
            return _Bar_Rent_Checkin_Service.Get_Bar_Rent_Checkin_Order_Report_Total(Ngay_Batdau, Ngay_Ketthuc, Id_Cuahang_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public string Get_All_Bar_Rent_Checkin(object ThangNam, object Id_Cuahang_Ban, object Check_Out)
        {
            return _Bar_Rent_Checkin_Service.Get_All_Bar_Rent_Checkin(ThangNam, Id_Cuahang_Ban, Check_Out);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public string Get_All_Bar_Rent_Checkin_ByArrivalDate(object ThangNam, object Id_Cuahang_Ban)
        {
            return _Bar_Rent_Checkin_Service.Get_All_Bar_Rent_Checkin_ByArrivalDate(ThangNam, Id_Cuahang_Ban);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public string GetBar_Rent_Checkin_ById(object Id_Reserve)
        {
            return _Bar_Rent_Checkin_Service.GetBar_Rent_Checkin_ById(Id_Reserve);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public string GetBar_Rent_Checkin_ById4Print(object Id_Reserve, object Id_Rentlevel, object Ngay_Ketthuc)
        {
            return _Bar_Rent_Checkin_Service.GetBar_Rent_Checkin_ById4Print(Id_Reserve, Id_Rentlevel, Ngay_Ketthuc);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public object Insert_Bar_Rent_Checkin(Ecm.Domain.Bar.Bar_Rent_Checkin Bar_Rent_Checkin)
        {
            return _Bar_Rent_Checkin_Service.Insert_Bar_Rent_Checkin(Bar_Rent_Checkin);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public object Insert_Bar_Rent_Checkin_ByReserved(object Id_Reserved, object Sochungtu, object Ngay_Chungtu)
        {
            return _Bar_Rent_Checkin_Service.Insert_Bar_Rent_Checkin_ByReserved(Id_Reserved, Sochungtu, Ngay_Chungtu);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public object Update_Bar_Rent_Checkin(Ecm.Domain.Bar.Bar_Rent_Checkin Bar_Rent_Checkin)
        {
            return _Bar_Rent_Checkin_Service.Update_Bar_Rent_Checkin(Bar_Rent_Checkin);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public object Delete_Bar_Rent_Checkin(Ecm.Domain.Bar.Bar_Rent_Checkin Bar_Rent_Checkin)
        {
            return _Bar_Rent_Checkin_Service.Delete_Bar_Rent_Checkin(Bar_Rent_Checkin);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public object Get_Bar_Rent_Checkin_Dathanhtoan_ById_Checkin(object Id_Checkin)
        {
            return _Bar_Rent_Checkin_Service.Get_Bar_Rent_Checkin_Dathanhtoan_ById_Checkin(Id_Checkin);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public object Update_Bar_Rent_Checkin_Collection(DataSet dsCollection)
        {
            return _Bar_Rent_Checkin_Service.Update_Bar_Rent_Checkin_Collection(dsCollection);
        }

        [WebMethod]
        public string Get_All_Bar_Rent_Checkin_Table(object Guid_Checkin)
        {
            return _Bar_Rent_Checkin_Service.Get_All_Bar_Rent_Checkin_Table(Guid_Checkin);
        }

        [WebMethod]
        public string Bar_Rent_Checkin_Table_SelectById_4Print(object Id_Checkin_Table, object Id_Rentlevel) 
        {
            return _Bar_Rent_Checkin_Service.Bar_Rent_Checkin_Table_SelectById_4Print(Id_Checkin_Table, Id_Rentlevel);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public object Bar_Rent_Checkin_Table_ChangeTable(object Id_Checkin_Table, object Id_Table_new)
        {
            return _Bar_Rent_Checkin_Service.Bar_Rent_Checkin_Table_ChangeTable(Id_Checkin_Table, Id_Table_new);
        }

        [WebMethod]
        public object Update_Bar_Rent_Checkin_Table_Collection(DataSet dsCollection)
        {
            return _Bar_Rent_Checkin_Service.Update_Bar_Rent_Checkin_Table_Collection(dsCollection);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public object Update_Bar_Rent_Checkin_Table_Check_Out(object Id_Checkin_Table)
        {
            return _Bar_Rent_Checkin_Service.Update_Bar_Rent_Checkin_Table_Check_Out(Id_Checkin_Table);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public object Update_Bar_Rent_Checkin_Table_Reset_Table_Reserved(object Id_Checkin, object Guid_Checkin)
        {
            return _Bar_Rent_Checkin_Service.Update_Bar_Rent_Checkin_Table_Reset_Table_Reserved(Id_Checkin, Guid_Checkin);
        }

        [WebMethod]
        public string Get_All_Bar_Rent_Checkin_Phieuthu(object Guid_Checkin)
        {
            return _Bar_Rent_Checkin_Service.Get_All_Bar_Rent_Checkin_Phieuthu(Guid_Checkin);
        }

        [WebMethod]
        public object Update_Bar_Rent_Checkin_Phieuthu_Collection(DataSet dsCollection)
        {
            return _Bar_Rent_Checkin_Service.Update_Bar_Rent_Checkin_Phieuthu_Collection(dsCollection);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public object Update_Bar_Rent_Checkin_PhieuThu_Trangthai(object Id_Checkin_Phieuthu, object Id_Checkin_Table)
        {
            return _Bar_Rent_Checkin_Service.Update_Bar_Rent_Checkin_PhieuThu_Trangthai(Id_Checkin_Phieuthu, Id_Checkin_Table);
        }   
        
        #endregion

        #region  Bar_Rent_Checkin_table_Hanghoa

        [WebMethod(BufferResponse = true, Description = "")]
        public string Get_All_Bar_Rent_Checkin_table_Hanghoa()
        {
            return _Bar_Rent_Checkin_Service.Get_All_Bar_Rent_Checkin_Table_Hanghoa();
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public string Get_Bar_Rent_Checkin_table_Hanghoa_By_Checkin_Table(object Id_Bar_Rent_Checkin_Table)
        {
            return _Bar_Rent_Checkin_Service.Get_Bar_Rent_Checkin_table_Hanghoa_By_Checkin_Table(Id_Bar_Rent_Checkin_Table);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public string Get_Bar_Rent_Checkin_table_Hanghoa_By_Checkin_Table_4Print(object Id_Bar_Rent_Checkin_Table)
        {
            return _Bar_Rent_Checkin_Service.Get_Bar_Rent_Checkin_table_Hanghoa_By_Checkin_Table_4Print(Id_Bar_Rent_Checkin_Table);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public string Get_Bar_Rent_Checkin_Hanghoa_By_Checkin_4Print(object Id_Checkin)
        {
            return _Bar_Rent_Checkin_Service.Get_Bar_Rent_Checkin_Hanghoa_By_Checkin_4Print(Id_Checkin);
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public object Update_Bar_Rent_Checkin_table_Hanghoa_Collection(DataSet dsCollection)
        {
            return _Bar_Rent_Checkin_Service.Update_Bar_Rent_Checkin_table_Hanghoa_Collection(dsCollection);
        }

        #endregion

        #region extends SystemService

        [WebMethod(BufferResponse = true, Description = "")]
        public DateTime GetServerDateTime()
        {
            return SystemService.GetServerDateTime();
        }

        [WebMethod(BufferResponse = true, Description = "")]
        public string GetCurrentTimeZone()
        {

            return SystemService.CurrentTimeZone.StandardName;
        }


        [WebMethod(BufferResponse = true, Description = "")]
        public object GetNew_Sochungtu(object Table_Name, object Column_Name, object Prefix)
        {
            return _DocumentProcessStatus_Service.GetNew_Sochungtu(Table_Name, Column_Name, Prefix);
        }

        #endregion
   
    }
}
