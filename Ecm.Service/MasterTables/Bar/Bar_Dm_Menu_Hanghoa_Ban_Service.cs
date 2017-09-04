using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.MasterTables.Bar
{
    public class Bar_Dm_Menu_Hanghoa_Ban_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Bar_Dm_Menu_Hanghoa_Ban_Service(System.Data.OleDb.OleDbConnection sqlMaper)
        {
            this._SqlConnection = sqlMaper;
        }
        #endregion

        #region implemetns IObService
        
        /// <summary>
        /// Trả về một dataset Dm_Menu_Hanghoa_Ban
        /// </summary>
        /// <returns></returns>
        public string Get_All_Bar_Dm_Menu_Hanghoa_Ban_Collection()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Dm_Menu_Hanghoa_Ban_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Get_All_Bar_Dm_Menu_Hanghoa_Ban_By_Id_Menu_Collection(object id_menu, object id_khuvuc)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Dm_Menu_Hanghoa_Ban_SelectAll_By_Id_Menu", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@id_menu", id_menu));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@id_khuvuc", id_khuvuc));
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Trả về một dataset Dm_Menu_Hanghoa_Ban
        /// </summary>
        /// <returns></returns>
        public string Get_Visible_Bar_Dm_Menu_Hanghoa_Ban_Collection(object ngay_chungtu, object id_khuvuc)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Dm_Menu_Hanghoa_Ban_SelectVisible", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@ngay_chungtu", ngay_chungtu));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@id_khuvuc", id_khuvuc));
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }        
        /// <summary>
        /// Insert 1 đoi tuong Bar_Dm_Menu_Hanghoa_Ban_Hanghoa_Ban vao DB
        /// </summary>
        /// <param name="bar_Dm_Menu_Hanghoa_Ban"></param>
        /// <returns></returns>
        public object Insert_Bar_Dm_Menu_Hanghoa_Ban(Ecm.Domain.MasterTables.Bar.Bar_Dm_Menu_Hanghoa_Ban bar_Dm_Menu_Hanghoa_Ban)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Dm_Menu_Hanghoa_Ban_Insert",_SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Menu",        bar_Dm_Menu_Hanghoa_Ban.Id_Menu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Ban", bar_Dm_Menu_Hanghoa_Ban.Id_Hanghoa_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu",         bar_Dm_Menu_Hanghoa_Ban.Ghichu));

                oleDbCommand.ExecuteNonQuery();
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Dm_Menu_Hanghoa_Ban", DateTime.Now);
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
        /// Update 1 doi tuong Dm_Menu_Hanghoa_Ban vao DB
        /// </summary>
        /// <param name="bar_Dm_Menu_Hanghoa_Ban"></param>
        /// <returns></returns>
        public object Update_Bar_Dm_Menu_Hanghoa_Ban(Ecm.Domain.MasterTables.Bar.Bar_Dm_Menu_Hanghoa_Ban bar_Dm_Menu_Hanghoa_Ban)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Dm_Menu_Hanghoa_Ban_Update",_SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Menu_Hanghoa_Ban", bar_Dm_Menu_Hanghoa_Ban.Id_Menu_Hanghoa_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Menu",        bar_Dm_Menu_Hanghoa_Ban.Id_Menu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Ban", bar_Dm_Menu_Hanghoa_Ban.Id_Hanghoa_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu",         bar_Dm_Menu_Hanghoa_Ban.Ghichu));

                oleDbCommand.ExecuteNonQuery();
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Dm_Menu_Hanghoa_Ban", DateTime.Now);
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
        /// Delete 1 doi tuong Dm_Menu_Hanghoa_Ban trong DB
        /// </summary>
        /// <param name="bar_Dm_Menu_Hanghoa_Ban"></param>
        /// <returns></returns>
        public object Delete_Bar_Dm_Menu_Hanghoa_Ban(Ecm.Domain.MasterTables.Bar.Bar_Dm_Menu_Hanghoa_Ban bar_Dm_Menu_Hanghoa_Ban)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Dm_Menu_Hanghoa_Ban_Delete",_SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Menu_Hanghoa_Ban", bar_Dm_Menu_Hanghoa_Ban.Id_Menu_Hanghoa_Ban));

                oleDbCommand.ExecuteNonQuery();
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Dm_Menu_Hanghoa_Ban", DateTime.Now);
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
        /// Update 1 collection Dm_Menu_Hanghoa_Ban vao DB
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Bar_Dm_Menu_Hanghoa_Ban_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Bar_Dm_Menu_Hanghoa_Ban", _SqlConnection);
                System.Data.OleDb.OleDbCommandBuilder oleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(oleDbDataAdapter);
                oleDbDataAdapter = oleDbCommandBuilder.DataAdapter;

                oleDbDataAdapter.Update(dsCollection, "GridTable");
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Dm_Menu_Hanghoa_Ban", DateTime.Now);
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
