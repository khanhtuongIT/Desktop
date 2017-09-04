using System;
using System.Data;
using System.Collections.Generic;
using System.Text;


namespace Ecm.Service.MasterTables.Bar
{
    public class Bar_Dm_Khuvuc_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Bar_Dm_Khuvuc_Service(System.Data.OleDb.OleDbConnection sqlMaper)
        {
            this._SqlConnection = sqlMaper;
        }
        #endregion

        #region implemetns IObService
        
        /// <summary>
        /// Trả về một dataset Dm_Table
        /// </summary>
        /// <returns></returns>
        public string Get_All_Bar_Dm_Khuvuc_Collection()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Dm_Khuvuc_SelectAll", this._SqlConnection);
            OleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(OleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Get_All_Bar_Dm_Khuvuc_ByCuahang(Ecm.Domain.MasterTables.Bar.Bar_Dm_Khuvuc bar_dm_khuvuc)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Dm_Khuvuc_SelectAll", this._SqlConnection);
            OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", bar_dm_khuvuc.Id_Cuahang_Ban));
            OleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(OleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        
        /// <summary>
        /// Insert 1 đoi tuong Bar_Dm_Khuvuc vao DB
        /// </summary>
        /// <param name="bar_dm_khuvuc"></param>
        /// <returns></returns>
        public object Insert_Bar_Dm_Khuvuc(Ecm.Domain.MasterTables.Bar.Bar_Dm_Khuvuc bar_dm_khuvuc)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Dm_Khuvuc_Insert", _SqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;

                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Khuvuc", bar_dm_khuvuc.Ma_Khuvuc));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Khuvuc", bar_dm_khuvuc.Ten_Khuvuc));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", bar_dm_khuvuc.Id_Cuahang_Ban));


                OleDbCommand.ExecuteNonQuery();
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Dm_Khuvuc", DateTime.Now);
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
        /// <param name="bar_dm_khuvuc"></param>
        /// <returns></returns>
        public object Update_Bar_Dm_Khuvuc(Ecm.Domain.MasterTables.Bar.Bar_Dm_Khuvuc bar_dm_khuvuc)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Dm_Khuvuc_Update", _SqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;

                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khuvuc", bar_dm_khuvuc.Id_Khuvuc));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Khuvuc", bar_dm_khuvuc.Ma_Khuvuc));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Khuvuc", bar_dm_khuvuc.Ten_Khuvuc));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", bar_dm_khuvuc.Id_Cuahang_Ban));


                OleDbCommand.ExecuteNonQuery();
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Dm_Khuvuc", DateTime.Now);
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
        /// <param name="bar_dm_khuvuc"></param>
        /// <returns></returns>
        public object Delete_Bar_Dm_Khuvuc(Ecm.Domain.MasterTables.Bar.Bar_Dm_Khuvuc bar_dm_khuvuc)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Dm_Khuvuc_Delete",_SqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;

                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khuvuc", bar_dm_khuvuc.Id_Khuvuc));

                OleDbCommand.ExecuteNonQuery();
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Dm_Khuvuc", DateTime.Now);
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
        public object Update_Bar_Dm_Khuvuc_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Bar_Dm_Khuvuc", _SqlConnection);
                System.Data.OleDb.OleDbCommandBuilder OleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(oleDbDataAdapter);
                oleDbDataAdapter = OleDbCommandBuilder.DataAdapter;

                oleDbDataAdapter.Update(dsCollection, "GridTable");
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Dm_Khuvuc", DateTime.Now);
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
