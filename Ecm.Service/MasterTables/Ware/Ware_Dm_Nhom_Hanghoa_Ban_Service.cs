using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.MasterTables.Ware
{
    public class Ware_Dm_Nhom_Hanghoa_Ban_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Constructor
        public Ware_Dm_Nhom_Hanghoa_Ban_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService
        /// <summary>
        /// Trả về một dataset Ware_Dm_Nhom_Hanghoa_Ban
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Dm_Nhom_Hanghoa_Ban()
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Nhom_Hanghoa_Ban_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");

                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Trả về một dataset Ware_Dm_Nhom_Hanghoa_Ban_Select_ByBarMenu
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Dm_Nhom_Hanghoa_Ban_ByBarMenu()
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Nhom_Hanghoa_Ban_Select_ByBarMenu", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");

                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }
        /// <summary>
        /// Insert đối tượng Ware_Dm_Nhom_Hanghoa_Ban vào DB.
        /// </summary>
        /// <param name="ware_Dm_Donvitinh"></param>
        /// <returns></returns>
        public Object Insert_Ware_Dm_Nhom_Hanghoa_Ban(Ecm.Domain.MasterTables.Ware.Ware_Dm_Nhom_Hanghoa_Ban Ware_Dm_Nhom_Hanghoa_Ban)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Nhom_Hanghoa_Ban_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Nhom_Hanghoa_Ban", Ware_Dm_Nhom_Hanghoa_Ban.Ma_Nhom_Hanghoa_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Nhom_Hanghoa_Ban", Ware_Dm_Nhom_Hanghoa_Ban.Ten_Nhom_Hanghoa_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@bc_doanhso", Ware_Dm_Nhom_Hanghoa_Ban.Bc_Doanhso));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@bc_nxt", Ware_Dm_Nhom_Hanghoa_Ban.Bc_Nxt));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@bc_nguyenlieu_chebien", Ware_Dm_Nhom_Hanghoa_Ban.Bc_Nguyenlieu_Chebien));
                
                oleDbCommand.ExecuteNonQuery();

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Ware_Dm_Nhom_Hanghoa_Ban", DateTime.Now);
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
        /// Update đối tượng Ware_Dm_Nhom_Hanghoa_Ban vào DB.
        /// </summary>
        /// <param name="ware_Dm_Donvitinh"></param>
        /// <returns></returns>
        public Object Update_Ware_Dm_Nhom_Hanghoa_Ban(Ecm.Domain.MasterTables.Ware.Ware_Dm_Nhom_Hanghoa_Ban Ware_Dm_Nhom_Hanghoa_Ban)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Nhom_Hanghoa_Ban_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhom_Hanghoa_Ban", Ware_Dm_Nhom_Hanghoa_Ban.Id_Nhom_Hanghoa_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Nhom_Hanghoa_Ban", Ware_Dm_Nhom_Hanghoa_Ban.Ma_Nhom_Hanghoa_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Nhom_Hanghoa_Ban", Ware_Dm_Nhom_Hanghoa_Ban.Ten_Nhom_Hanghoa_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@bc_doanhso", Ware_Dm_Nhom_Hanghoa_Ban.Bc_Doanhso));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@bc_nxt", Ware_Dm_Nhom_Hanghoa_Ban.Bc_Nxt));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@bc_nguyenlieu_chebien", Ware_Dm_Nhom_Hanghoa_Ban.Bc_Nguyenlieu_Chebien));

                oleDbCommand.ExecuteNonQuery();
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Ware_Dm_Nhom_Hanghoa_Ban", DateTime.Now);
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
        /// Delete đối tượng Ware_Dm_Nhom_Hanghoa_Ban vào DB.
        /// </summary>
        /// <param name="ware_Dm_Donvitinh"></param>
        /// <returns></returns>
        public Object Delete_Ware_Dm_Nhom_Hanghoa_Ban(Ecm.Domain.MasterTables.Ware.Ware_Dm_Nhom_Hanghoa_Ban Ware_Dm_Nhom_Hanghoa_Ban)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Nhom_Hanghoa_Ban_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhom_Hanghoa_Ban", Ware_Dm_Nhom_Hanghoa_Ban.Id_Nhom_Hanghoa_Ban));

                oleDbCommand.ExecuteNonQuery();
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Ware_Dm_Nhom_Hanghoa_Ban", DateTime.Now);
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
        /// Update Collection Ware_Dm_Nhom_Hanghoa_Ban vào DB.
        /// </summary>
        /// <param name="ware_Dm_Donvitinh"></param>
        /// <returns></returns>
        public Object Update_Ware_Dm_Nhom_Hanghoa_Ban_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Dm_Nhom_Hanghoa_Ban", this._SqlConnection);
                System.Data.OleDb.OleDbCommandBuilder oleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(oleDbDataAdapter);
                oleDbDataAdapter = oleDbCommandBuilder.DataAdapter;

                oleDbDataAdapter.Update(dsCollection, "GridTable");
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Ware_Dm_Nhom_Hanghoa_Ban", DateTime.Now);
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
