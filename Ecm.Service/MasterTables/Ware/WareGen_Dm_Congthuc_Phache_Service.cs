using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.MasterTables.Ware
{
    public class WareGen_Dm_Congthuc_Phache_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Constructor
        public WareGen_Dm_Congthuc_Phache_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService
        /// <summary>
        /// Trả về một dataset WareGen_Dm_Congthuc_Phache
        /// </summary>
        /// <returns></returns>
        public string Get_All_WareGen_Dm_Congthuc_Phache()
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("WareGen_Dm_Congthuc_Phache_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");

                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Insert đối tượng WareGen_Dm_Congthuc_Phache vào DB.
        /// </summary>
        /// <param name="ware_Dm_Donvitinh"></param>
        /// <returns></returns>
        public Object Insert_WareGen_Dm_Congthuc_Phache(Ecm.Domain.MasterTables.Ware.Ware_Dm_Congthuc_Phache WareGen_Dm_Congthuc_Phache)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("WareGen_Dm_Congthuc_Phache_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Congthuc_Phache", WareGen_Dm_Congthuc_Phache.Ma_Congthuc_Phache));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Congthuc_Phache", WareGen_Dm_Congthuc_Phache.Ten_Congthuc_Phache));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Mua", WareGen_Dm_Congthuc_Phache.Id_Hanghoa_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Donvitinh", WareGen_Dm_Congthuc_Phache.Id_Donvitinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong", WareGen_Dm_Congthuc_Phache.Soluong));

                oleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        /// <summary>
        /// Update đối tượng WareGen_Dm_Congthuc_Phache vào DB.
        /// </summary>
        /// <param name="ware_Dm_Donvitinh"></param>
        /// <returns></returns>
        public Object Update_WareGen_Dm_Congthuc_Phache(Ecm.Domain.MasterTables.Ware.Ware_Dm_Congthuc_Phache WareGen_Dm_Congthuc_Phache)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("WareGen_Dm_Congthuc_Phache_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Congthuc_Phache", WareGen_Dm_Congthuc_Phache.Id_Congthuc_Phache));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Congthuc_Phache", WareGen_Dm_Congthuc_Phache.Ma_Congthuc_Phache));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Congthuc_Phache", WareGen_Dm_Congthuc_Phache.Ten_Congthuc_Phache));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Mua", WareGen_Dm_Congthuc_Phache.Id_Hanghoa_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Donvitinh", WareGen_Dm_Congthuc_Phache.Id_Donvitinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong", WareGen_Dm_Congthuc_Phache.Soluong));

                oleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        /// <summary>
        /// Delete đối tượng WareGen_Dm_Congthuc_Phache vào DB.
        /// </summary>
        /// <param name="ware_Dm_Donvitinh"></param>
        /// <returns></returns>
        public Object Delete_WareGen_Dm_Congthuc_Phache(Ecm.Domain.MasterTables.Ware.Ware_Dm_Congthuc_Phache WareGen_Dm_Congthuc_Phache)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("WareGen_Dm_Congthuc_Phache_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Congthuc_Phache", WareGen_Dm_Congthuc_Phache.Id_Congthuc_Phache));

                oleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        /// <summary>
        /// Update Collection WareGen_Dm_Congthuc_Phache vào DB.
        /// </summary>
        /// <param name="ware_Dm_Donvitinh"></param>
        /// <returns></returns>
        public Object Update_WareGen_Dm_Congthuc_Phache_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from WareGen_Dm_Congthuc_Phache", this._SqlConnection);
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
    }
}
