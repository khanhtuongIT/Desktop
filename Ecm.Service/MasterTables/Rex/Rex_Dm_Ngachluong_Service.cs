using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.MasterTables.Rex
{
    public class Rex_Dm_Ngachluong_Service
    {
        #region Connection
        System.Data.OleDb.OleDbConnection sqlConnection;
        #endregion

        public Rex_Dm_Ngachluong_Service(System.Data.OleDb.OleDbConnection _sqlConnection)
        {
            this.sqlConnection = _sqlConnection;
        }

        /// <summary>
        /// Get danh sách nhân sự được bố trí theo ca làm việc
        /// </summary>
        /// <param name="id_ca_lamviec"></param>
        /// <returns></returns>
        public string Get_All_Rex_Dm_Ngachluong_Collection()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Dm_Ngachluong_SelectAll", sqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");

                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Insert Rex_Dm_Ngachluong
        /// </summary>
        /// <param name="Rex_Dm_Ngachluong"></param>
        /// <returns></returns>
        public object Insert_Rex_Dm_Ngachluong(Domain.MasterTables.Rex.Rex_Dm_Ngachluong Rex_Dm_Ngachluong)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Dm_Ngachluong_Insert", this.sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Ngachluong", Rex_Dm_Ngachluong.Ma_Ngachluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Ngachluong", Rex_Dm_Ngachluong.Ten_Ngachluong));

                oleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        // <summary>
        /// Insert Rex_Dm_Ngachluong
        /// </summary>
        /// <param name="Rex_Dm_Ngachluong"></param>
        /// <returns></returns>
        public object Update_Rex_Dm_Ngachluong(Domain.MasterTables.Rex.Rex_Dm_Ngachluong Rex_Dm_Ngachluong)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Dm_Ngachluong_Update", this.sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Ngachluong", Rex_Dm_Ngachluong.Id_Ngachluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Ngachluong", Rex_Dm_Ngachluong.Ma_Ngachluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Ngachluong", Rex_Dm_Ngachluong.Ten_Ngachluong));

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
        /// Delete đối tượng Rex_Dm_Ngachluong vào DB.
        /// </summary>
        /// <param name="Rex_Dm_Ngachluong"></param>
        /// <returns></returns>
        public object Delete_Rex_Dm_Ngachluong(Ecm.Domain.MasterTables.Rex.Rex_Dm_Ngachluong Rex_Dm_Ngachluong)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Dm_Ngachluong_Delete", this.sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Ngachluong", Rex_Dm_Ngachluong.Id_Ngachluong));

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
        /// Update dataset to DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Rex_Dm_Ngachluong_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("Select * from Rex_Dm_Ngachluong", sqlConnection);
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
    }
}
