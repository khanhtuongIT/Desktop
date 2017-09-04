using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Rex
{
    public class Rex_Luong_Thoigian_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Rex_Luong_Thoigian_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService
        /// <summary>
        /// Trả về một dataset Dm_Donvitinh
        /// </summary>
        /// <returns></returns>
        public string Get_All_Rex_Luong_Thoigian(Domain.Rex.Rex_Luong_Thoigian Rex_Luong_Thoigian)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Luong_Thoigian_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nam_Kyluong", Rex_Luong_Thoigian.Nam_Kyluong));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thang_Kyluong", Rex_Luong_Thoigian.Thang_Kyluong));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", Rex_Luong_Thoigian.Id_Bophan));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

       
        /// <summary>
        /// Update một Collection Rex_Luong_Thoigian vào DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Rex_Luong_Thoigian_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Rex_Luong_Thoigian", _SqlConnection);
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

        public object Init_Rex_Luong_Thoigian(Domain.Rex.Rex_Luong_Thoigian Rex_Luong_Thoigian)
        {
            try
            {
                System.Data.DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Luong_Thoigian_Init", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nam_Kyluong", Rex_Luong_Thoigian.Nam_Kyluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thang_Kyluong", Rex_Luong_Thoigian.Thang_Kyluong));
                //oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", Rex_Luong_Thoigian.Id_Bophan));
            
                oleDbCommand.ExecuteNonQuery();
            
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object Refresh_Rex_Luong_Thoigian(Domain.Rex.Rex_Luong_Thoigian Rex_Luong_Thoigian)
        {
            try
            {
                System.Data.DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("rex_luong_thoigian_refresh", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nam_Kyluong", Rex_Luong_Thoigian.Nam_Kyluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thang_Kyluong", Rex_Luong_Thoigian.Thang_Kyluong));
                //oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", Rex_Luong_Thoigian.Id_Bophan));

                oleDbCommand.ExecuteNonQuery();

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
