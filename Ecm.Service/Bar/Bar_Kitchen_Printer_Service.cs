using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Bar
{
    public class Bar_Kitchen_Printer_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _sqlConnection;
        #endregion

        #region Method
        public Bar_Kitchen_Printer_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._sqlConnection = sqlConnection;
        }
        #endregion

        #region Bar_Kitchen_Printer
        /// <summary>
        /// Return dataSet Bar_Kitchen_Printer
        /// </summary>
        /// <returns></returns>
        public string Get_All_Bar_Kitchen_Printer()
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Kitchen_Printer_SelectAll", this._sqlConnection);
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
        /// nhanvuong - 05/11/2010
        /// Return dataSet Bar_Kitchen_Printer by Id_Cuahang
        /// </summary>
        /// <returns></returns>
        public string Get_All_Bar_Kitchen_Printer_ByPC_Code(object PC_Code)  
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Kitchen_Printer_SelectByPc_Code", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@PC_Code", PC_Code));

                System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(OleDbCommand);
                OleDbDataAdapter.Fill(dsCollection, "GridTable");

                            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
            }
            catch (Exception ex)
            {
                throw ex;                
            }
        }

        public string GetPrinter_From_Bar_Kitchen_Printer(object PC_Code)  
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Kitchen_Printer_SelectPrinter", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@PC_Code", PC_Code));

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
        /// Insert đối tượng Bar_Kitchen_Printer vào DB
        /// </summary>
        /// <param name="Bar_Kitchen_Printer"></param>
        /// <returns>Identity new value</returns>
        public object Insert_Bar_Kitchen_Printer(Domain.Bar.Bar_Kitchen_Printer bar_kitchen_printer)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Kitchen_Printer_Insert", this._sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Pc_Code", bar_kitchen_printer.Pc_Code));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Pc_Name", bar_kitchen_printer.Pc_Name));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", bar_kitchen_printer.Id_Cuahang_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Printer", bar_kitchen_printer.Printer));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhom_Hanghoa_Ban", bar_kitchen_printer.Id_Nhom_Hanghoa_Ban));

                oleDbCommand.ExecuteNonQuery();

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Kitchen_Printer", DateTime.Now);
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
        /// Update đối tượng Bar_Kitchen_Printer vào DB
        /// </summary>
        /// <param name="Bar_Kitchen_Printer"></param>
        /// <returns>bool</returns>
        public object Update_Bar_Kitchen_Printer(Domain.Bar.Bar_Kitchen_Printer bar_kitchen_printer)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Kitchen_Printer_Update", this._sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kitchen_Printer", bar_kitchen_printer.Id_Kitchen_Printer));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Pc_Code", bar_kitchen_printer.Pc_Code));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Pc_Name", bar_kitchen_printer.Pc_Name));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", bar_kitchen_printer.Id_Cuahang_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Printer", bar_kitchen_printer.Printer));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhom_Hanghoa_Ban", bar_kitchen_printer.Id_Nhom_Hanghoa_Ban));

                oleDbCommand.ExecuteNonQuery();

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Kitchen_Printer", DateTime.Now);
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
        /// Delete đối tượng Bar_Kitchen_Printer vào DB
        /// </summary>
        /// <param name="Bar_Kitchen_Printer"></param>
        /// <returns>bool</returns>
        public object Delete_Bar_Kitchen_Printer(Domain.Bar.Bar_Kitchen_Printer bar_kitchen_printer)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Kitchen_Printer_Delete", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;

                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kitchen_Printer", bar_kitchen_printer.Id_Kitchen_Printer));
                OleDbCommand.ExecuteNonQuery();

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Kitchen_Printer", DateTime.Now);
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
        /// Update Dataset Bar_Kitchen_Printer vào DB
        /// </summary>
        /// <param name="Bar_Kitchen_Printer"></param>
        /// <returns>bool</returns>
        public object Update_Bar_Kitchen_Printer_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("Select * From Bar_Kitchen_Printer", this._sqlConnection);
                System.Data.OleDb.OleDbCommandBuilder OleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(OleDbDataAdapter);
                OleDbDataAdapter = OleDbCommandBuilder.DataAdapter;

                OleDbDataAdapter.Update(dsCollection, "GridTable");

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Kitchen_Printer", DateTime.Now);
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

        #region bar_kitchen_order_chitiet

        /// <summary>
        /// Update Dataset Bar_Kitchen_Order_Chitiet vào DB
        /// </summary>
        /// <param name="Bar_Kitchen_Printer"></param>
        /// <returns>bool</returns>
        public object Update_Bar_Kitchen_Order_Chitiet_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("Select * From Bar_Kitchen_Order_Chitiet", this._sqlConnection);
                System.Data.OleDb.OleDbCommandBuilder OleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(OleDbDataAdapter);
                OleDbDataAdapter = OleDbCommandBuilder.DataAdapter;

                OleDbDataAdapter.Update(dsCollection, "GridTable");

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Kitchen_Order_Chitiet", DateTime.Now);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public string FetchPrinter_Bar_Kitchen_Order_Chitiet(object PC_Code, object Id_Cuahang_Ban)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Kitchen_Order_Chitiet_FetchPrinter", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@PC_Code", PC_Code));
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

        public string GetLog_Bar_Kitchen_Order_Chitiet(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Cuahang_Ban)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Kitchen_Order_Chitiet_GetLog", this._sqlConnection);
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
                return null;
            }
        }
        public string GetTopLog_Bar_Kitchen_Order_Chitiet(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Cuahang_Ban)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Kitchen_Order_Chitiet_GetTopLog", this._sqlConnection);
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
                return null;
            }
        }
        public string GetNotLog_Bar_Kitchen_Order_Chitiet(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Cuahang_Ban)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Kitchen_Order_Chitiet_GetNotPrint", this._sqlConnection);
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
                return null;
            }
        }
        public string GetServed_Bar_Kitchen_Order_Chitiet(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Cuahang_Ban)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Kitchen_Order_Chitiet_GetServed", this._sqlConnection);
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
                return null;
            }
        }

        public string GetNVL_Bar_Kitchen_Order_Chitiet(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Cuahang_Ban)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Kitchen_Order_Chitiet_GetNVL", this._sqlConnection);
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
                return null;
            }
        }       
#endregion
    }
}
