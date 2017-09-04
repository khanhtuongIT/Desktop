using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Ecm.Service.Bar
{
    public class Bar_Rent_Checkin_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _sqlConnection;
        #endregion

        #region Costructor
        public Bar_Rent_Checkin_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._sqlConnection = sqlConnection;
        }
        #endregion

        #region Methods

        public string Get_Bar_Rent_Checkin_Table_Report_Total(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Cuahang_Ban)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Table_Report_Total", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", Ngay_Batdau));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", Ngay_Ketthuc));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
                System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(OleDbCommand);
                OleDbDataAdapter.Fill(dsCollection, "GridTable");

                return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Get_Bar_Rent_Checkin_Order_Report_Total(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Cuahang_Ban)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("RptSplit_Sum_Hhban_4Hotel", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", Ngay_Batdau));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", Ngay_Ketthuc));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
                System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(OleDbCommand);
                OleDbDataAdapter.Fill(dsCollection, "GridTable");

                return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Get_All_Bar_Rent_Checkin(object ThangNam, object Id_Cuahang_Ban, object Check_Out)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Selectall", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@ThangNam", ThangNam));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Check_Out", Check_Out));
                System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(OleDbCommand);
                OleDbDataAdapter.Fill(dsCollection, "GridTable");

                return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
            }
            catch (Exception ex)
            {
                throw ex;               
            }
        }

        public string Get_All_Bar_Rent_Checkin_ByArrivalDate(object ThangNam, object Id_Cuahang_Ban)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_SelectByArrivalDate", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@ThangNam", ThangNam));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));

                System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(OleDbCommand);
                OleDbDataAdapter.Fill(dsCollection, "GridTable");

                return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }

        public string GetBar_Rent_Checkin_ById(object Id_Checkin)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_SelectById", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Checkin", Id_Checkin));

                System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(OleDbCommand);
                OleDbDataAdapter.Fill(dsCollection, "GridTable");

                return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
            }
            catch (Exception ex)
            {
                throw ex;              
            }
        }

        public string GetBar_Rent_Checkin_ById4Print(object Id_Checkin, object Id_Rentlevel, object Ngay_Ketthuc)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_SelectById_4Print", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Checkin", Id_Checkin));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Rentlevel", Id_Rentlevel));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", Ngay_Ketthuc));

                System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(OleDbCommand);
                OleDbDataAdapter.Fill(dsCollection, "GridTable");

                return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }

        public object Insert_Bar_Rent_Checkin(Domain.Bar.Bar_Rent_Checkin bar_rent_checkin)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Insert", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Checkin", System.Data.OleDb.OleDbType.BigInt));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Reserve", bar_rent_checkin.Id_Reserve));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", bar_rent_checkin.Id_Khachhang));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", bar_rent_checkin.Ngay_Batdau));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", bar_rent_checkin.Ngay_Ketthuc));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Class", bar_rent_checkin.Id_Class));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong_Phong", bar_rent_checkin.Soluong_Phong));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong_Khach", bar_rent_checkin.Soluong_Khach));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Checkin_Hoten", bar_rent_checkin.Checkin_Hoten));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Checkin_Cmnd", bar_rent_checkin.Checkin_Cmnd));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Checkin_Tel", bar_rent_checkin.Checkin_Tel));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chietkhau_Tyle", bar_rent_checkin.Chietkhau_Tyle));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chietkhau_Tienmat", bar_rent_checkin.Chietkhau_Tienmat));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Checkin_Email", bar_rent_checkin.Checkin_Email));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thanhtoantruoc", bar_rent_checkin.Thanhtoantruoc));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", bar_rent_checkin.Ngay_Chungtu));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@So_Chungtu", bar_rent_checkin.So_Chungtu));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Ctu", bar_rent_checkin.Id_Nhansu_Ctu));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", bar_rent_checkin.Ghichu));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", bar_rent_checkin.Id_Cuahang_Ban));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Checkin", bar_rent_checkin.Guid_Checkin));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Rentlevel", bar_rent_checkin.Id_Rentlevel));

                OleDbCommand.Parameters["@Id_Checkin"].Direction = ParameterDirection.Output;

                OleDbCommand.ExecuteNonQuery();

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Rent_Checkin", DateTime.Now);
                }
                return OleDbCommand.Parameters["@Id_Checkin"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object Insert_Bar_Rent_Checkin_ByReserved(object Id_Reserved, object Sochungtu, object Ngay_Chungtu)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_checkin_Insert_ByReserved", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Reserve", Id_Reserved));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@So_Chungtu", Sochungtu));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", Ngay_Chungtu));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Checkin", System.Data.OleDb.OleDbType.BigInt));
                OleDbCommand.Parameters["@Id_Checkin"].Direction = ParameterDirection.Output;
                OleDbCommand.ExecuteNonQuery();

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Rent_checkin_Insert_ByReserved", DateTime.Now);
                }
                return OleDbCommand.Parameters["@Id_Checkin"].Value; ;
            }
            catch (Exception ex)
            {
                throw ex;                
            }
        }

        public object Update_Bar_Rent_Checkin(Domain.Bar.Bar_Rent_Checkin bar_rent_checkin)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Update", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Checkin", bar_rent_checkin.Id_Checkin));                
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", bar_rent_checkin.Id_Khachhang));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", bar_rent_checkin.Ngay_Batdau));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", bar_rent_checkin.Ngay_Ketthuc));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Class", bar_rent_checkin.Id_Class));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong_Phong", bar_rent_checkin.Soluong_Phong));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong_Khach", bar_rent_checkin.Soluong_Khach));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Checkin_Hoten", bar_rent_checkin.Checkin_Hoten));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Checkin_Cmnd", bar_rent_checkin.Checkin_Cmnd));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Checkin_Tel", bar_rent_checkin.Checkin_Tel));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chietkhau_Tyle", bar_rent_checkin.Chietkhau_Tyle));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chietkhau_Tienmat", bar_rent_checkin.Chietkhau_Tienmat));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Checkin_Email", bar_rent_checkin.Checkin_Email));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thanhtoantruoc", bar_rent_checkin.Thanhtoantruoc));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", bar_rent_checkin.Ngay_Chungtu));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@So_Chungtu", bar_rent_checkin.So_Chungtu));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Ctu", bar_rent_checkin.Id_Nhansu_Ctu));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", bar_rent_checkin.Ghichu));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", bar_rent_checkin.Id_Cuahang_Ban));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Checkin", bar_rent_checkin.Guid_Checkin));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Rentlevel", bar_rent_checkin.Id_Rentlevel));
                OleDbCommand.ExecuteNonQuery();

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Rent_Checkin", DateTime.Now);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object Update_Bar_Rent_Check_Out(object Id_Checkin)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Check_Out", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Checkin", Id_Checkin));
                OleDbCommand.ExecuteNonQuery();

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Rent_Checkin", DateTime.Now);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;               
            }
        }

        public object Delete_Bar_Rent_Checkin(Domain.Bar.Bar_Rent_Checkin bar_rent_checkin)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Delete", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Checkin", bar_rent_checkin.Id_Checkin));
                OleDbCommand.ExecuteNonQuery();

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Rent_Checkin", DateTime.Now);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object Update_Bar_Rent_Checkin_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter();

                oleDbDataAdapter.SelectCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Selectall", _sqlConnection);
                oleDbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                oleDbDataAdapter.InsertCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Insert", _sqlConnection);
                oleDbDataAdapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Checkin", System.Data.OleDb.OleDbType.BigInt));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Reserve", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Reserve"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Khachhang"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", System.Data.OleDb.OleDbType.DBTimeStamp, 18, "Ngay_Batdau"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", System.Data.OleDb.OleDbType.DBTimeStamp, 18, "Ngay_Ketthuc"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Class", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Class"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong_Phong", System.Data.OleDb.OleDbType.Decimal, 18, "Soluong_Phong"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong_Khach", System.Data.OleDb.OleDbType.Decimal, 18, "Soluong_Khach"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Checkin_Hoten", System.Data.OleDb.OleDbType.VarWChar, 18, "Checkin_Hoten"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Checkin_Cmnd", System.Data.OleDb.OleDbType.VarWChar, 18, "Checkin_Cmnd"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Checkin_Tel", System.Data.OleDb.OleDbType.VarWChar, 18, "Checkin_Tel"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chietkhau_Tyle", System.Data.OleDb.OleDbType.Decimal, 18, "Chietkhau_Tyle"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chietkhau_Tienmat", System.Data.OleDb.OleDbType.Decimal, 18, "Chietkhau_Tienmat"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Checkin_Email", System.Data.OleDb.OleDbType.VarWChar, 18, "Checkin_Email"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thanhtoantruoc", System.Data.OleDb.OleDbType.Boolean, 18, "Thanhtoantruoc"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", System.Data.OleDb.OleDbType.DBTimeStamp, 18, "Ngay_Chungtu"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@So_Chungtu", System.Data.OleDb.OleDbType.VarWChar, 18, "So_Chungtu"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Ctu", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Nhansu_Ctu"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Cuahang_Ban"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Checkin", System.Data.OleDb.OleDbType.Guid, 18, "Guid_Checkin"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Rentlevel", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Rentlevel"));

                oleDbDataAdapter.UpdateCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Update", _sqlConnection);
                oleDbDataAdapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Checkin", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Checkin"));                
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Khachhang"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", System.Data.OleDb.OleDbType.DBTimeStamp, 18, "Ngay_Batdau"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", System.Data.OleDb.OleDbType.DBTimeStamp, 18, "Ngay_Ketthuc"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Class", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Class"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong_Phong", System.Data.OleDb.OleDbType.Decimal, 18, "Soluong_Phong"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong_Khach", System.Data.OleDb.OleDbType.Decimal, 18, "Soluong_Khach"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Checkin_Hoten", System.Data.OleDb.OleDbType.VarWChar, 18, "Checkin_Hoten"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Checkin_Cmnd", System.Data.OleDb.OleDbType.VarWChar, 18, "Checkin_Cmnd"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Checkin_Tel", System.Data.OleDb.OleDbType.VarWChar, 18, "Checkin_Tel"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chietkhau_Tyle", System.Data.OleDb.OleDbType.Decimal, 18, "Chietkhau_Tyle"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chietkhau_Tienmat", System.Data.OleDb.OleDbType.Decimal, 18, "Chietkhau_Tienmat"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Checkin_Email", System.Data.OleDb.OleDbType.VarWChar, 18, "Checkin_Email"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thanhtoantruoc", System.Data.OleDb.OleDbType.Boolean, 18, "Thanhtoantruoc"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", System.Data.OleDb.OleDbType.DBTimeStamp, 18, "Ngay_Chungtu"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@So_Chungtu", System.Data.OleDb.OleDbType.VarWChar, 18, "So_Chungtu"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Ctu", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Nhansu_Ctu"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Cuahang_Ban"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Checkin", System.Data.OleDb.OleDbType.Guid, 18, "Guid_Checkin"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Rentlevel", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Rentlevel"));

                oleDbDataAdapter.DeleteCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Delete", _sqlConnection);
                oleDbDataAdapter.DeleteCommand.CommandType = CommandType.StoredProcedure;
                oleDbDataAdapter.DeleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Checkin", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Checkin"));

                oleDbDataAdapter.Update(dsCollection, "GridTable");

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Rent_Checkin", DateTime.Now);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;                
            }
        }

        public object Get_Bar_Rent_Checkin_Dathanhtoan_ById_Checkin(object Id_Checkin)
        {
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("[Bar_Rent_Checkin_Dathanhtoan_ById_Checkin]", this._sqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Checkin", Id_Checkin));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien", System.Data.OleDb.OleDbType.Decimal));

            oleDbCommand.Parameters["@Sotien"].Direction = ParameterDirection.Output;
            oleDbCommand.ExecuteNonQuery();
            return ("" + oleDbCommand.Parameters["@Sotien"].Value == "") ? 0 : oleDbCommand.Parameters["@Sotien"].Value;
        }

        #region  Bar_Rent_Checkin_Table

        public string Get_All_Bar_Rent_Checkin_Table(object Guid_Checkin)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Table_Selectall", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Checkin", Guid_Checkin));

                System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(OleDbCommand);
                OleDbDataAdapter.Fill(dsCollection, "GridTable");

                return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
            }
            catch (Exception ex)
            {
                throw ex;                
            }
        }

        public string Bar_Rent_Checkin_Table_SelectById_4Print(object Id_Checkin_Table, object Id_Rentlevel)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Table_SelectById_4Print", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Checkin_Table", Id_Checkin_Table));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Rentlevel", Id_Rentlevel));

                System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(OleDbCommand);
                OleDbDataAdapter.Fill(dsCollection, "GridTable");
                return FastJSON.JSON.Instance.ToJSON(dsCollection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Update_Bar_Rent_Checkin_Table_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter();

                oleDbDataAdapter.SelectCommand = new System.Data.OleDb.OleDbCommand("Select * from Bar_Rent_Checkin_Table", _sqlConnection);
                oleDbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                oleDbDataAdapter.InsertCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Table_Insert", _sqlConnection);
                oleDbDataAdapter.InsertCommand.CommandType = CommandType.StoredProcedure;                
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Checkin", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Checkin"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Table", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Table"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Checkin", System.Data.OleDb.OleDbType.Guid, 18, "Guid_Checkin"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Checkin_Table", System.Data.OleDb.OleDbType.Guid, 18, "Guid_Checkin_Table"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", System.Data.OleDb.OleDbType.DBTimeStamp, 18, "Ngay_Batdau"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", System.Data.OleDb.OleDbType.DBTimeStamp, 18, "Ngay_Ketthuc"));

                oleDbDataAdapter.UpdateCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Table_Update", _sqlConnection);
                oleDbDataAdapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Checkin_Table", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Checkin_Table"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Checkin", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Checkin"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Table", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Table"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Checkin", System.Data.OleDb.OleDbType.Guid, 18, "Guid_Checkin"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Checkin_Table", System.Data.OleDb.OleDbType.Guid, 18, "Guid_Checkin_Table"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", System.Data.OleDb.OleDbType.DBTimeStamp, 18, "Ngay_Batdau"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", System.Data.OleDb.OleDbType.DBTimeStamp, 18, "Ngay_Ketthuc"));

                oleDbDataAdapter.DeleteCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Table_Delete", _sqlConnection);
                oleDbDataAdapter.DeleteCommand.CommandType = CommandType.StoredProcedure;
                oleDbDataAdapter.DeleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Checkin_Table", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Checkin_Table"));

                oleDbDataAdapter.Update(dsCollection, "GridTable");

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Rent_Checkin", DateTime.Now);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;                
            }
        }

        public object Update_Bar_Rent_Checkin_Table_Check_Out(object Id_Checkin_Table)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Table_Check_Out", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Checkin_Table", Id_Checkin_Table));
                OleDbCommand.ExecuteNonQuery();                
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Rent_Checkin_Table", DateTime.Now);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Update_Bar_Rent_Checkin_Table_Reset_Table_Reserved(object Id_Checkin, object Guid_Checkin)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Table_Reset_Table_Reserved", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Checkin", Id_Checkin));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Checkin", Guid_Checkin));
                OleDbCommand.ExecuteNonQuery();
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Rent_Checkin_Table", DateTime.Now);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Bar_Rent_Checkin_Table_ChangeTable(object Id_Checkin_Table, object Id_Table_new)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Table_ChangeTable", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Checkin_Table", Id_Checkin_Table));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Table_new", Id_Table_new));
                OleDbCommand.ExecuteNonQuery();
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Rent_Checkin_Table", DateTime.Now);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region  Bar_Rent_Checkin_Khachhang

        public string Get_All_Bar_Rent_Checkin_Khachhang(object Guid_Checkin)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Khachhang_SelectBy_Guid_Checkin", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Checkin", Guid_Checkin));

                System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(OleDbCommand);
                OleDbDataAdapter.Fill(dsCollection, "GridTable");
                return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
            }
            catch (Exception ex)
            {
                throw ex;             
            }
        }

        public string Bar_Rent_Checkin_Khachhang_SelectByGuid_Checkin_Table(object Guid_Checkin_Table)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Khachhang_SelectByGuid_Checkin_Table", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Checkin_Table", Guid_Checkin_Table));
                System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(OleDbCommand);
                OleDbDataAdapter.Fill(dsCollection, "GridTable");
                return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Update_Bar_Rent_Checkin_Khachhang_Collection(DataSet dsCollection)
        {
            foreach (DataTable tb in dsCollection.Tables)
            {
                try
                {
                    System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter();

                    oleDbDataAdapter.SelectCommand = new System.Data.OleDb.OleDbCommand("Select * from Bar_Rent_Checkin_Khachhang", _sqlConnection);
                    oleDbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    oleDbDataAdapter.InsertCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Khachhang_Insert", _sqlConnection);
                    oleDbDataAdapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                    oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Checkin_Khachhang", System.Data.OleDb.OleDbType.BigInt));
                    oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Khachhang"));
                    oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Checkin", System.Data.OleDb.OleDbType.Guid, 18, "Guid_Checkin"));
                    oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Checkin_Table", System.Data.OleDb.OleDbType.Guid, 18, "Guid_Checkin_Table"));

                    oleDbDataAdapter.UpdateCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Khachhang_Update", _sqlConnection);
                    oleDbDataAdapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
                    oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Checkin_Khachhang", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Checkin_Khachhang"));
                    oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Khachhang"));
                    oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Checkin", System.Data.OleDb.OleDbType.Guid, 18, "Guid_Checkin"));
                    oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Checkin_Table", System.Data.OleDb.OleDbType.Guid, 18, "Guid_Checkin_Table"));

                    oleDbDataAdapter.DeleteCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Khachhang_Delete", _sqlConnection);
                    oleDbDataAdapter.DeleteCommand.CommandType = CommandType.StoredProcedure;
                    oleDbDataAdapter.DeleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Checkin_Khachhang", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Checkin_Khachhang"));

                    oleDbDataAdapter.Update(dsCollection, tb.TableName);
                    //notify last change in data
                    using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                    {
                        _Sys_Service.Update_Sys_Lognotify("Bar_Rent_Checkin", DateTime.Now);
                    }                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return true;
        }
        
        #endregion

        #region  Bar_Rent_Checkin_Phieuthu

        public string Get_All_Bar_Rent_Checkin_Phieuthu(object Guid_Checkin)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Phieuthu_Selectall", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Checkin", Guid_Checkin));

                System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(OleDbCommand);
                OleDbDataAdapter.Fill(dsCollection, "GridTable");

                return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }

        public object Update_Bar_Rent_Checkin_Phieuthu_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter();

                oleDbDataAdapter.SelectCommand = new System.Data.OleDb.OleDbCommand("Select * from Bar_Rent_Checkin_Phieuthu", _sqlConnection);
                oleDbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                oleDbDataAdapter.InsertCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Phieuthu_Insert", _sqlConnection);
                oleDbDataAdapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Checkin_Phieuthu", System.Data.OleDb.OleDbType.BigInt));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Checkin", System.Data.OleDb.OleDbType.Guid, 18, "Guid_Checkin"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Phieu_Thu", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Phieu_Thu"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Checkin", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Checkin"));

                oleDbDataAdapter.UpdateCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Phieuthu_Update", _sqlConnection);
                oleDbDataAdapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Checkin_Phieuthu", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Checkin_Phieuthu"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Checkin", System.Data.OleDb.OleDbType.Guid, 18, "Guid_Checkin"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Phieu_Thu", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Phieu_Thu"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Checkin", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Checkin"));

                oleDbDataAdapter.DeleteCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Phieuthu_Delete", _sqlConnection);
                oleDbDataAdapter.DeleteCommand.CommandType = CommandType.StoredProcedure;
                oleDbDataAdapter.DeleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Checkin_Phieuthu", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Checkin_Phieuthu"));

                oleDbDataAdapter.Update(dsCollection, "GridTable");

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Rent_Checkin", DateTime.Now);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object Update_Bar_Rent_Checkin_PhieuThu_Trangthai(object Id_Checkin_Phieuthu, object Id_Checkin_Table)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Phieuthu_Update_Trangthai", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Checkin_Phieuthu", Id_Checkin_Phieuthu));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Checkin_Table", Id_Checkin_Table));
                OleDbCommand.ExecuteNonQuery();
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Rent_Checkin_Phieuthu", DateTime.Now);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region  Bar_Rent_Checkin_table_Hanghoa

        public string Get_All_Bar_Rent_Checkin_Table_Hanghoa()
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Table_Hanghoa_SelectAll", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(OleDbCommand);
                OleDbDataAdapter.Fill(dsCollection, "GridTable");
                return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Get_Bar_Rent_Checkin_table_Hanghoa_By_Checkin_Table(object Id_Bar_Rent_Checkin_Table)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Table_Hanghoa_SelectBy_Checkin_Table", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bar_Rent_Checkin_Table", Id_Bar_Rent_Checkin_Table));
                System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(OleDbCommand);
                OleDbDataAdapter.Fill(dsCollection, "GridTable");
                return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Get_Bar_Rent_Checkin_table_Hanghoa_By_Checkin_Table_4Print(object Id_Bar_Rent_Checkin_Table)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Table_Hanghoa_SelectBy_Checkin_Table_4Print", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bar_Rent_Checkin_Table", Id_Bar_Rent_Checkin_Table));
                System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(OleDbCommand);
                OleDbDataAdapter.Fill(dsCollection, "GridTable");
                return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Get_Bar_Rent_Checkin_Hanghoa_By_Checkin_4Print(object Id_Checkin)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Hanghoa_SelectBy_Checkin_4Print", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Checkin", Id_Checkin));
                System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(OleDbCommand);
                OleDbDataAdapter.Fill(dsCollection, "GridTable");
                return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Update_Bar_Rent_Checkin_table_Hanghoa_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbCommand _cmd_Select = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Table_Hanghoa_SelectAll", this._sqlConnection);
                _cmd_Select.CommandType = CommandType.StoredProcedure;

                System.Data.OleDb.OleDbCommand _cmd_Insert = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Table_Hanghoa_Insert", this._sqlConnection);
                _cmd_Insert.CommandType = CommandType.StoredProcedure;
                _cmd_Insert.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bar_Rent_Checkin_Table", System.Data.OleDb.OleDbType.BigInt, int.MaxValue, "Id_Bar_Rent_Checkin_Table"));
                _cmd_Insert.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Ban", System.Data.OleDb.OleDbType.BigInt, int.MaxValue, "Id_Hanghoa_Ban"));
                _cmd_Insert.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Donvitinh", System.Data.OleDb.OleDbType.BigInt, int.MaxValue, "Id_Donvitinh"));
                _cmd_Insert.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong", System.Data.OleDb.OleDbType.Decimal, int.MaxValue, "Soluong"));
                _cmd_Insert.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dongia", System.Data.OleDb.OleDbType.Decimal, int.MaxValue, "Dongia"));
                _cmd_Insert.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thanhtien", System.Data.OleDb.OleDbType.Decimal, int.MaxValue, "Thanhtien"));
                _cmd_Insert.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Served", System.Data.OleDb.OleDbType.Boolean, int.MaxValue, "Served"));
                _cmd_Insert.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", System.Data.OleDb.OleDbType.VarWChar, int.MaxValue, "Ghichu"));
                _cmd_Insert.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Per_Dongia", System.Data.OleDb.OleDbType.Decimal, int.MaxValue, "Per_Dongia"));
                _cmd_Insert.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong_Phucvu", System.Data.OleDb.OleDbType.Decimal, int.MaxValue, "Soluong_Phucvu"));
                _cmd_Insert.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Order", System.Data.OleDb.OleDbType.Date, int.MaxValue, "Ngay_Order"));
                _cmd_Insert.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thanhtien_Km", System.Data.OleDb.OleDbType.Decimal, int.MaxValue, "Thanhtien_Km"));
                _cmd_Insert.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Order", System.Data.OleDb.OleDbType.BigInt, int.MaxValue, "Id_Nhansu_Order"));
                _cmd_Insert.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Octiet", System.Data.OleDb.OleDbType.Guid, int.MaxValue, "Guid_Octiet"));

                System.Data.OleDb.OleDbCommand _cmd_Update = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Table_Hanghoa_Update", this._sqlConnection);
                _cmd_Update.CommandType = CommandType.StoredProcedure;
                _cmd_Update.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bar_Rent_Checkin_Table_Hanghoa", System.Data.OleDb.OleDbType.BigInt, int.MaxValue, "Id_Bar_Rent_Checkin_Table_Hanghoa"));
                _cmd_Update.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bar_Rent_Checkin_Table", System.Data.OleDb.OleDbType.BigInt, int.MaxValue, "Id_Bar_Rent_Checkin_Table"));
                _cmd_Update.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Ban", System.Data.OleDb.OleDbType.BigInt, int.MaxValue, "Id_Hanghoa_Ban"));
                _cmd_Update.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Donvitinh", System.Data.OleDb.OleDbType.BigInt, int.MaxValue, "Id_Donvitinh"));
                _cmd_Update.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong", System.Data.OleDb.OleDbType.Decimal, int.MaxValue, "Soluong"));
                _cmd_Update.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dongia", System.Data.OleDb.OleDbType.Decimal, int.MaxValue, "Dongia"));
                _cmd_Update.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thanhtien", System.Data.OleDb.OleDbType.Decimal, int.MaxValue, "Thanhtien"));
                _cmd_Update.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Served", System.Data.OleDb.OleDbType.Boolean, int.MaxValue, "Served"));
                _cmd_Update.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", System.Data.OleDb.OleDbType.VarWChar, int.MaxValue, "Ghichu"));
                _cmd_Update.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Per_Dongia", System.Data.OleDb.OleDbType.Decimal, int.MaxValue, "Per_Dongia"));
                _cmd_Update.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong_Phucvu", System.Data.OleDb.OleDbType.Decimal, int.MaxValue, "Soluong_Phucvu"));
                _cmd_Update.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Order", System.Data.OleDb.OleDbType.Date, int.MaxValue, "Ngay_Order"));
                _cmd_Update.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thanhtien_Km", System.Data.OleDb.OleDbType.Decimal, int.MaxValue, "Thanhtien_Km"));
                _cmd_Update.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Order", System.Data.OleDb.OleDbType.BigInt, int.MaxValue, "Id_Nhansu_Order"));
                _cmd_Update.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Octiet", System.Data.OleDb.OleDbType.Guid, int.MaxValue, "Guid_Octiet"));

                System.Data.OleDb.OleDbCommand _cmd_Delete = new System.Data.OleDb.OleDbCommand("Bar_Rent_Checkin_Table_Hanghoa_Delete", this._sqlConnection);
                _cmd_Delete.CommandType = CommandType.StoredProcedure;
                _cmd_Delete.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bar_Rent_Checkin_Table_Hanghoa", System.Data.OleDb.OleDbType.BigInt, int.MaxValue, "Id_Bar_Rent_Checkin_Table_Hanghoa"));

                System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(_cmd_Select);
                OleDbDataAdapter.InsertCommand = _cmd_Insert;
                OleDbDataAdapter.UpdateCommand = _cmd_Update;
                OleDbDataAdapter.DeleteCommand = _cmd_Delete;

                OleDbDataAdapter.Update(dsCollection, "GridTable");

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Rent_Checkin_table_Hanghoa", DateTime.Now);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;                
            }
        }

        #endregion


        #endregion

    }
}
