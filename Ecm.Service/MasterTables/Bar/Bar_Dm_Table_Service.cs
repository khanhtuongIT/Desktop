using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.MasterTables.Bar
{
    public class Bar_Dm_Table_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Bar_Dm_Table_Service(System.Data.OleDb.OleDbConnection sqlMaper)
        {
            this._SqlConnection = sqlMaper;
        }
        #endregion

        #region implemetns IObService
        
        /// <summary>
        /// Trả về một dataset Dm_Table
        /// </summary>
        /// <returns></returns>
        public string Get_All_Bar_Dm_Table_Collection()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Dm_Table_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Get_All_Bar_Dm_Table_WithClass(object Id_Cuahang_Ban, object Id_Khuvuc, object Id_Class, object Allow_Housekeeping)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Dm_Table_SelectAll", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khuvuc", Id_Khuvuc));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Class", Id_Class));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Allow_Housekeeping", Allow_Housekeeping));
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Get_All_Bar_Dm_Table_ByKhuvuc(Ecm.Domain.MasterTables.Bar.Bar_Dm_Table bar_Dm_Table)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Dm_Table_SelectAll", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", null));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khuvuc", bar_Dm_Table.Id_Khuvuc));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Class", null));
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Trả về một dataset (distinct) vị trí trong bar_dm_table 
        /// </summary>
        /// <returns></returns>
        public string Get_All_ViTri_Dm_Bar_Table()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Dm_Table_Select_Vitri", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }
        
        /// <summary>
        /// Insert 1 đoi tuong Bar_Dm_Table vao DB
        /// </summary>
        /// <param name="bar_Dm_Table"></param>
        /// <returns></returns>
        public object Insert_Bar_Dm_Table(Ecm.Domain.MasterTables.Bar.Bar_Dm_Table bar_Dm_Table)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Dm_Table_Insert",_SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Table",   bar_Dm_Table.Ma_Table));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Table",  bar_Dm_Table.Ten_Table));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Vitri",      bar_Dm_Table.Vitri));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong",    bar_Dm_Table.Soluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu",     bar_Dm_Table.Ghichu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Hinh", bar_Dm_Table.Hinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khuvuc", bar_Dm_Table.Id_Khuvuc));

                oleDbCommand.ExecuteNonQuery();
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Dm_Table", DateTime.Now);
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
        /// Update 1 doi tuong Dm_Table vao DB
        /// </summary>
        /// <param name="bar_Dm_Table"></param>
        /// <returns></returns>
        public object Update_Bar_Dm_Table(Ecm.Domain.MasterTables.Bar.Bar_Dm_Table bar_Dm_Table)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Dm_Table_Update",_SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Table",   bar_Dm_Table.Id_Table));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Table",   bar_Dm_Table.Ma_Table));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Table",  bar_Dm_Table.Ten_Table));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Vitri",      bar_Dm_Table.Vitri));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong",    bar_Dm_Table.Soluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu",     bar_Dm_Table.Ghichu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Hinh",       bar_Dm_Table.Hinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khuvuc", bar_Dm_Table.Id_Khuvuc));

                oleDbCommand.ExecuteNonQuery();
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Dm_Table", DateTime.Now);
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
        /// Delete 1 doi tuong Dm_Table trong DB
        /// </summary>
        /// <param name="bar_Dm_Table"></param>
        /// <returns></returns>
        public object Delete_Bar_Dm_Table(Ecm.Domain.MasterTables.Bar.Bar_Dm_Table bar_Dm_Table)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Dm_Table_Delete",_SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Table", bar_Dm_Table.Id_Table));

                oleDbCommand.ExecuteNonQuery();
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Dm_Table", DateTime.Now);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }


        public object Delete_Bar_Dm_Table_ChiTiet(object Id)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Dm_Table_ChiTiet_Delete", _SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@id_table_order_chitiet", Id));

                oleDbCommand.ExecuteNonQuery();
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Dm_Table_ChiTiet", DateTime.Now);
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
        /// Update 1 collection Dm_Table vao DB
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Bar_Dm_Table_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Bar_Dm_Table", _SqlConnection);
                System.Data.OleDb.OleDbCommandBuilder oleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(oleDbDataAdapter);
                oleDbDataAdapter = oleDbCommandBuilder.DataAdapter;

                oleDbDataAdapter.Update(dsCollection, "GridTable");
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Dm_Table", DateTime.Now);
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
