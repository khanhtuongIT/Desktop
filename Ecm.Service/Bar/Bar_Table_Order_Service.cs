using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Bar
{
    public class Bar_Table_Order_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _sqlConnection;
        #endregion

        #region Method
        public Bar_Table_Order_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._sqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService

        /// <summary>
        /// nhanvuong - 01/11/2010
        /// update lại trạng thái lock của bar_table_order
        /// </summary>
        /// <returns></returns>
        public object Bar_Table_Order_Update_Lock(object id_table_order, object lock_status)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Table_Order_Update_Lock", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Table_Order", id_table_order));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Lock", lock_status));
                OleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Bar_Table_Order_Xuat_Nvl(object Id_Cuahang_Ban, object Id_Table_Order, object Id_Checkin)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Table_Order_Xuat_Nvl", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Table_Order", Id_Table_Order));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Checkin", Id_Checkin));
                OleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Return dataSet Bar_Table_Order
        /// </summary>
        /// <returns></returns>
        public string Get_All_Bar_Table_Order(object Without_Empty_Table, object Id_Cuahang_Ban)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Table_Order_SelectAll", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Without_Empty_Table", Without_Empty_Table));
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

        /// <summary>
        /// nhanvuong - 05/11/2010
        /// Return dataSet Bar_Table_Order by Id_Cuahang
        /// </summary>
        /// <returns></returns>
        public string Get_All_Bar_Table_Order_By_Id_Cuahang(object Id_Cuahang_Ban)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Table_Order_SelectBy_Id_Cuahang_Ban", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
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


        /// <summary>
        /// nhitruong - 07/02/2014
        /// Return dataSet Bar_Table_Order by Id_Cuahang and Id_Khuvuc
        /// </summary>
        /// <returns></returns>
        public string Get_All_Bar_Table_Order_By_Id_Cuahang_And_Id_Khuvuc(object Id_Cuahang_Ban, object Id_Khuvuc)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Table_Order_SelectBy_Id_Cuahang_Ban_And_Id_Khuvuc", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khuvuc", Id_Khuvuc));
                System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(OleDbCommand);
                OleDbDataAdapter.Fill(dsCollection, "GridTable");

                return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Get_Finish_Bar_Table_Order(object Id_Table_Order)
        {
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("[Bar_Table_Order_Get_Finish]", this._sqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Table_Order", Id_Table_Order));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Finish", System.Data.OleDb.OleDbType.Boolean));

            oleDbCommand.Parameters["@Finish"].Direction = ParameterDirection.Output;

            oleDbCommand.ExecuteNonQuery();

            return oleDbCommand.Parameters["@Finish"].Value;
        }

        public string Get_All_Bar_Table_Order_By_Date_Order(object Without_Empty_Table, object ngayOrder, object vitri)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Table_Order_SelectAll_By_Date_Order", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Without_Empty_Table", Without_Empty_Table));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Order", ngayOrder));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", vitri));

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

        public string Get_All_Bar_Table_Order_Chitiet_Served()
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Table_Order_Chitiet_SelectAll_Served", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;

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
        /// <summary>
        /// Return dataSet Bar_Table_Order_Chitiet
        /// </summary>
        /// <returns></returns>
        public string Get_All_Bar_Table_Order_Chitiet()
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Table_Order_Chitiet_SelectAll", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;

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

        public string Get_All_Bar_Table_Order_Chitiet(object Id_Nhom_Hanghoa_Ban, object Id_Cuahang_Ban)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Table_Order_Chitiet_SelectAll", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhom_Hanghoa_Ban", Id_Nhom_Hanghoa_Ban));
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

        public string Get_Book_Bar_Table_Order_Chitiet(object Id_Nhom_Hanghoa_Ban)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Table_Order_Chitiet_SelectBook", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhom_Hanghoa_Ban", Id_Nhom_Hanghoa_Ban));
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

        /// <summary>
        /// Return dataSet Bar_Table_Order_Chitiet by Id_Table_Order
        /// </summary>
        /// <returns></returns>
        public string Get_All_Bar_Table_Order_Chitiet_ById_Order(object Id_Table_Order)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Table_Order_SelectAll_ByFk", this._sqlConnection);
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Table_Order", Id_Table_Order));
                OleDbCommand.CommandType = CommandType.StoredProcedure;

                System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(OleDbCommand);
                OleDbDataAdapter.Fill(dsCollection, "GridTable");

                //return dsCollection;

                return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }

        /// <summary>
        /// Return dataSet Bar_Table_Order_Chitiet by Id_Table_Order
        /// </summary>
        /// <returns></returns>
        public string Get_All_Bar_Table_Order_Chitiet_Log_ById_Order(object Id_Table_Order)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Table_Order_SelectAllLog_ByFk", this._sqlConnection);
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Table_Order", Id_Table_Order));
                OleDbCommand.CommandType = CommandType.StoredProcedure;

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

        /// <summary>
        /// Insert đối tượng Bar_Table_Order vào DB
        /// </summary>
        /// <param name="Bar_Table_Order"></param>
        /// <returns>Identity new value</returns>
        public object Insert_Bar_Table_Order(Domain.Bar.Bar_Table_Order Bar_Table_Order)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Table_Order_Insert", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;

                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Table_Order", System.Data.OleDb.OleDbType.BigInt));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Order", Bar_Table_Order.Id_Nhansu_Order));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Order", Bar_Table_Order.Ngay_Order));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Ca_Lamviec", Bar_Table_Order.Id_Ca_Lamviec));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Table", Bar_Table_Order.Id_Table));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Casher", Bar_Table_Order.Id_Nhansu_Casher));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Casher", Bar_Table_Order.Ngay_Casher));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien", Bar_Table_Order.Sotien));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Finish", Bar_Table_Order.Finish));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Bar_Table_Order.Id_Cuahang_Ban));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", Bar_Table_Order.Id_Khachhang));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", Bar_Table_Order.Sochungtu));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Booking", Bar_Table_Order.Id_Booking));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tien_Booking", Bar_Table_Order.Tien_Booking));
                OleDbCommand.Parameters["@Id_Table_Order"].Direction = ParameterDirection.Output;

                OleDbCommand.ExecuteNonQuery();

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Table_Order", DateTime.Now);
                }
                return OleDbCommand.Parameters["@Id_Table_Order"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object Insert_Bar_Table_Order_For_Web(object Id_Nhansu_Order, object Ngay_Order,
            object Id_Ca_Lamviec, object Id_Table, object Id_Cuahang_Ban,object Sochungtu)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Table_Order_Insert_On_Web", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;             
 

                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Table_Order", System.Data.OleDb.OleDbType.BigInt));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Order",Id_Nhansu_Order));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Order", Ngay_Order));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Ca_Lamviec", Id_Ca_Lamviec));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Table", Id_Table));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", Sochungtu));
                OleDbCommand.Parameters["@Id_Table_Order"].Direction = ParameterDirection.Output;

                OleDbCommand.ExecuteNonQuery();

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Table_Order", DateTime.Now);
                }
                return OleDbCommand.Parameters["@Id_Table_Order"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        /// <summary>
        /// Update đối tượng Bar_Table_Order vào DB
        /// </summary>
        /// <param name="Bar_Table_Order"></param>
        /// <returns>bool</returns>
        public object Update_Bar_Table_Order(Domain.Bar.Bar_Table_Order Bar_Table_Order)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Table_Order_Update", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;

                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Table_Oder", Bar_Table_Order.Id_Table_Order));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Order", Bar_Table_Order.Id_Nhansu_Order));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Order", Bar_Table_Order.Ngay_Order));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Ca_Lamviec", Bar_Table_Order.Id_Ca_Lamviec));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Table", Bar_Table_Order.Id_Table));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Casher", Bar_Table_Order.Id_Nhansu_Casher));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Casher", Bar_Table_Order.Ngay_Casher));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien", Bar_Table_Order.Sotien));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Finish", Bar_Table_Order.Finish));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Bar_Table_Order.Id_Cuahang_Ban));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Vip_Member_Card", Bar_Table_Order.Id_Vip_Member_Card));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Bill", Bar_Table_Order.Id_Nhansu_Bill));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", Bar_Table_Order.Id_Khachhang));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", Bar_Table_Order.Sochungtu));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Km", Bar_Table_Order.Id_Nhansu_Km));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Booking", Bar_Table_Order.Id_Booking));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tien_Booking", Bar_Table_Order.Tien_Booking));

                OleDbCommand.ExecuteNonQuery();

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Table_Order", DateTime.Now);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }


        public object Update_Bar_Table_Order_For_Web(object Id_Table_Order, object Id_Nhansu_Order, object Ngay_Order,
            object Id_Ca_Lamviec, object Id_Table, object Id_Cuahang_Ban, object Sochungtu)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Table_Order_Update_For_Web", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;

                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Table_Oder", Id_Table_Order));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Order", Id_Nhansu_Order));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Order", Ngay_Order));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Ca_Lamviec", Id_Ca_Lamviec));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Table", Id_Table));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", Sochungtu));

                OleDbCommand.ExecuteNonQuery();

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Table_Order", DateTime.Now);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        /// <summary>
        /// Update id khach hang = -1 (tách, ghép bàn)
        /// </summary>
        /// <param name="Bar_Table_Order"></param>
        /// <returns>bool</returns>
        public object Update_Id_Khachhang_Bar_Table_Order(object id_table_order)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Table_Order_Update_Id_Khachhang", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Table_Order", id_table_order));

                OleDbCommand.ExecuteNonQuery();

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Table_Order", DateTime.Now);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        /// <summary>
        /// Update đối tượng Số lượng phục vụ vào DB
        /// </summary>
        /// <param name="Bar_Table_Order"></param>
        /// <returns>bool</returns>
        public object Update_Bar_Table_Order_Chitiet(object id_table_order_chitiet, object soluong_phucvu, object Hotel)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Table_Order_Chitiet_Update", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;

                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Table_Order_Chitiet", id_table_order_chitiet));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong_Phucvu", soluong_phucvu));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Hotel", Hotel));
                OleDbCommand.ExecuteNonQuery();

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Table_Order_Chitiet", DateTime.Now);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }


        /// <summary>
        /// Delete đối tượng Bar_Table_Order vào DB
        /// </summary>
        /// <param name="Bar_Table_Order"></param>
        /// <returns>bool</returns>
        public object Delete_Bar_Table_Order(Domain.Bar.Bar_Table_Order Bar_Table_Order)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Table_Order_Delete", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;

                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Table_Oder", Bar_Table_Order.Id_Table_Order));
                OleDbCommand.ExecuteNonQuery();

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Table_Order", DateTime.Now);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        /// <summary>
        /// Update Dataset Bar_Table_Order vào DB
        /// </summary>
        /// <param name="Bar_Table_Order"></param>
        /// <returns>bool</returns>
        public object Update_Bar_Table_Order_Chitiet_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbCommand _cmd_Select = new System.Data.OleDb.OleDbCommand("Bar_Table_Order_Chitiet_SelectAll_1", this._sqlConnection);
                _cmd_Select.CommandType = CommandType.StoredProcedure;

                System.Data.OleDb.OleDbCommand _cmd_Insert = new System.Data.OleDb.OleDbCommand("Bar_Table_Order_Chitiet_Insert_1", this._sqlConnection);
                _cmd_Insert.CommandType = CommandType.StoredProcedure;
                _cmd_Insert.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Table_Order", System.Data.OleDb.OleDbType.BigInt, int.MaxValue, "Id_Table_Order"));
                _cmd_Insert.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Ban", System.Data.OleDb.OleDbType.BigInt, int.MaxValue, "Id_Hanghoa_Ban"));
                _cmd_Insert.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Donvitinh", System.Data.OleDb.OleDbType.BigInt, int.MaxValue, "Id_Donvitinh"));
                _cmd_Insert.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong", System.Data.OleDb.OleDbType.Decimal, int.MaxValue, "Soluong"));
                _cmd_Insert.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dongia", System.Data.OleDb.OleDbType.Decimal, int.MaxValue, "Dongia"));
                _cmd_Insert.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thanhtien", System.Data.OleDb.OleDbType.Decimal, int.MaxValue, "Thanhtien"));
                _cmd_Insert.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Booking", System.Data.OleDb.OleDbType.Boolean, int.MaxValue, "Booking"));
                _cmd_Insert.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Served", System.Data.OleDb.OleDbType.Boolean, int.MaxValue, "Served"));
                _cmd_Insert.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", System.Data.OleDb.OleDbType.VarWChar, int.MaxValue, "Ghichu"));
                _cmd_Insert.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Per_Dongia", System.Data.OleDb.OleDbType.Decimal, int.MaxValue, "Per_Dongia"));
                _cmd_Insert.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong_Phucvu", System.Data.OleDb.OleDbType.Decimal, int.MaxValue, "Soluong_Phucvu"));
                _cmd_Insert.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Order", System.Data.OleDb.OleDbType.Date, int.MaxValue, "Ngay_Order"));
                _cmd_Insert.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thanhtien_Km", System.Data.OleDb.OleDbType.Decimal, int.MaxValue, "Thanhtien_Km"));
                _cmd_Insert.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Order", System.Data.OleDb.OleDbType.BigInt, int.MaxValue, "Id_Nhansu_Order"));
                _cmd_Insert.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Octiet", System.Data.OleDb.OleDbType.Guid, int.MaxValue, "Guid_Octiet"));
                _cmd_Insert.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Table_Order_Chitiet_Old", System.Data.OleDb.OleDbType.BigInt, int.MaxValue, "Id_Table_Order_Chitiet_Old"));

                System.Data.OleDb.OleDbCommand _cmd_Update = new System.Data.OleDb.OleDbCommand("Bar_Table_Order_Chitiet_Update_1", this._sqlConnection);
                _cmd_Update.CommandType = CommandType.StoredProcedure;
                _cmd_Update.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Table_Order_Chitiet", System.Data.OleDb.OleDbType.BigInt, int.MaxValue, "Id_Table_Order_Chitiet"));
                _cmd_Update.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Table_Order", System.Data.OleDb.OleDbType.BigInt, int.MaxValue, "Id_Table_Order"));
                _cmd_Update.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Ban", System.Data.OleDb.OleDbType.BigInt, int.MaxValue, "Id_Hanghoa_Ban"));
                _cmd_Update.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Donvitinh", System.Data.OleDb.OleDbType.BigInt, int.MaxValue, "Id_Donvitinh"));
                _cmd_Update.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong", System.Data.OleDb.OleDbType.Decimal, int.MaxValue, "Soluong"));
                _cmd_Update.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dongia", System.Data.OleDb.OleDbType.Decimal, int.MaxValue, "Dongia"));
                _cmd_Update.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thanhtien", System.Data.OleDb.OleDbType.Decimal, int.MaxValue, "Thanhtien"));
                _cmd_Update.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Booking", System.Data.OleDb.OleDbType.Boolean, int.MaxValue, "Booking"));
                _cmd_Update.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Served", System.Data.OleDb.OleDbType.Boolean, int.MaxValue, "Served"));
                _cmd_Update.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", System.Data.OleDb.OleDbType.VarWChar, int.MaxValue, "Ghichu"));
                _cmd_Update.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Per_Dongia", System.Data.OleDb.OleDbType.Decimal, int.MaxValue, "Per_Dongia"));
                _cmd_Update.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong_Phucvu", System.Data.OleDb.OleDbType.Decimal, int.MaxValue, "Soluong_Phucvu"));
                _cmd_Update.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Order", System.Data.OleDb.OleDbType.Date, int.MaxValue, "Ngay_Order"));
                _cmd_Update.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thanhtien_Km", System.Data.OleDb.OleDbType.Decimal, int.MaxValue, "Thanhtien_Km"));
                _cmd_Update.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Order", System.Data.OleDb.OleDbType.BigInt, int.MaxValue, "Id_Nhansu_Order"));
                _cmd_Update.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Octiet", System.Data.OleDb.OleDbType.Guid, int.MaxValue, "Guid_Octiet"));
                _cmd_Update.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Table_Order_Chitiet_Old", System.Data.OleDb.OleDbType.BigInt, int.MaxValue, "Id_Table_Order_Chitiet_Old"));

                System.Data.OleDb.OleDbCommand _cmd_Delete = new System.Data.OleDb.OleDbCommand("Bar_Table_Order_Chitiet_Delete_1", this._sqlConnection);
                _cmd_Delete.CommandType = CommandType.StoredProcedure;
                _cmd_Delete.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Table_Order_Chitiet", System.Data.OleDb.OleDbType.BigInt, int.MaxValue, "Id_Table_Order_Chitiet"));


                System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(_cmd_Select);
                OleDbDataAdapter.InsertCommand = _cmd_Insert;
                OleDbDataAdapter.UpdateCommand = _cmd_Update;
                OleDbDataAdapter.DeleteCommand = _cmd_Delete;

                OleDbDataAdapter.Update(dsCollection, "GridTable");

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Table_Order_Chitiet", DateTime.Now);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw;
                return false;
            }
        }

        /// <summary>
        /// Update Dataset Bar_Table_Order vào DB
        /// </summary>
        /// <param name="Bar_Table_Order"></param>
        /// <returns>bool</returns>
        public object Update_Bar_Table_Order_Chitiet_Log_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("Select * From Bar_Table_Order_Chitiet_Log", this._sqlConnection);
                System.Data.OleDb.OleDbCommandBuilder OleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(OleDbDataAdapter);
                OleDbDataAdapter = OleDbCommandBuilder.DataAdapter;

                OleDbDataAdapter.Update(dsCollection, "GridTable");

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Table_Order_Chitiet_Log", DateTime.Now);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        #endregion

    }
}
