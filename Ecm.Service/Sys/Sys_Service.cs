using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Sys
{
    public class Sys_Service : System.IDisposable
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Sys_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService
        /// <summary>
        /// Trả về một dataset Dm_Donvitinh
        /// </summary>
        /// <returns></returns>
        public string Get_Rex_Dm_Heso_Chuongtrinh_Collection3()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Sys_Dm_Heso_Chuongtrinh_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        

        /// <summary>
        /// Update một Collection Rex_Nhansu vào DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Sys_Dm_Heso_Chuongtrinh_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Sys_Dm_Heso_Chuongtrinh", _SqlConnection);
                System.Data.OleDb.OleDbCommandBuilder oleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(oleDbDataAdapter);
                oleDbDataAdapter = oleDbCommandBuilder.DataAdapter;

                oleDbDataAdapter.Update(dsCollection, "GridTable");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

       
        #endregion

        #region [Sys_Lognotify]
        /// <summary>
        /// Sys_Lognotify_UpdateLastChange
        /// </summary>
        /// <param name="table_name"></param>
        /// <param name="last_change"></param>
        /// <returns></returns>
        public object Update_Sys_Lognotify(string table_name, DateTime last_change)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Sys_Lognotify_UpdateLastChange", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@table_name", table_name));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@last_change", last_change));

                oleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        ///// <summary>
        ///// Sys_Lognotify_SelectLastChange
        ///// </summary>
        ///// <param name="table_name"></param>
        ///// <param name="last_change"></param>
        ///// <returns></returns>
        //public string Get_Sys_Lognotify(string table_name)
        //{
        //    try
        //    {
        //        DataSet dsCollection = new DataSet();
        //        System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Sys_Lognotify_SelectLastChange", this._SqlConnection);
        //        oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@table_name", table_name));
        //        oleDbCommand.CommandType = CommandType.StoredProcedure;

        //        System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
        //        OleDbDataAdapter.Fill(dsCollection, "GridTable");

        //                    return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //        return null;
        //    }
        //}
 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table_name">table_names = '[table1], [table2], [table3]'</param>
        /// <returns></returns>
        public string Get_Sys_Lognotify_SelectLastChange_OfTables(string table_names)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Sys_Lognotify_SelectLastChange_OfTables", this._SqlConnection);
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@table_names", table_names));
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
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
        /// Sys_Lognotify_SelectAll
        /// </summary>
        /// <param name="table_name"></param>
        /// <returns></returns>
        public string Get_Sys_Lognotify()
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Sys_Lognotify_SelectAll", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
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

        #region override System.IDisposable
        public void Dispose()
        {
            //_SqlConnection = null;
        }
        #endregion
    }
}
