using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.MasterTables.Ware
{
    public class Ware_Dm_Tiente_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Constructor
        public Ware_Dm_Tiente_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService
        /// <summary>
        /// Trả về một dataset Ware_Dm_Tiente
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Dm_Tiente()
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Tiente_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");

                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Insert đối tượng Ware_Dm_Tiente vào DB.
        /// </summary>
        /// <param name="ware_Dm_Donvitinh"></param>
        /// <returns></returns>
        public Object Insert_Ware_Dm_Tiente(Ecm.Domain.MasterTables.Ware.Ware_Dm_Tiente Ware_Dm_Tiente)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Tiente_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Tiente", Ware_Dm_Tiente.Ma_Tiente));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Tiente", Ware_Dm_Tiente.Ten_Tiente));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tygia_Vnd", Ware_Dm_Tiente.Tygia_Vnd));

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
        /// Update đối tượng Ware_Dm_Tiente vào DB.
        /// </summary>
        /// <param name="ware_Dm_Donvitinh"></param>
        /// <returns></returns>
        public Object Update_Ware_Dm_Tiente(Ecm.Domain.MasterTables.Ware.Ware_Dm_Tiente Ware_Dm_Tiente)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Tiente_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Tiente", Ware_Dm_Tiente.Id_Tiente));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Tiente", Ware_Dm_Tiente.Ma_Tiente));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Tiente", Ware_Dm_Tiente.Ten_Tiente));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tygia_Vnd", Ware_Dm_Tiente.Tygia_Vnd));

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
        /// Delete đối tượng Ware_Dm_Tiente vào DB.
        /// </summary>
        /// <param name="ware_Dm_Donvitinh"></param>
        /// <returns></returns>
        public Object Delete_Ware_Dm_Tiente(Ecm.Domain.MasterTables.Ware.Ware_Dm_Tiente Ware_Dm_Tiente)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Tiente_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Tiente", Ware_Dm_Tiente.Id_Tiente));

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
        /// Update Collection Ware_Dm_Tiente vào DB.
        /// </summary>
        /// <param name="ware_Dm_Donvitinh"></param>
        /// <returns></returns>
        public Object Update_Ware_Dm_Tiente_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Dm_Tiente", this._SqlConnection);
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
