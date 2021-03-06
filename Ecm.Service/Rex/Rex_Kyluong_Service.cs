using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Ecm.Service.Rex
{
    public class Rex_Kyluong_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Rex_Kyluong_Service(System.Data.OleDb.OleDbConnection sqlMaper)
        {
            this._SqlConnection = sqlMaper;
        }
        #endregion

        #region implemetns IObService
        
        /// <summary>
        /// Trả về một dataset Kyluong
        /// </summary>
        /// <returns></returns>
        public string Get_All_Rex_Kyluong_Collection()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Kyluong_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Get_All_Rex_Kyluong_ByThangNam(int Thang_Kyluong, int Nam_Kyluong)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Kyluong_SelectByThangNam", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nam_Kyluong",Nam_Kyluong));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thang_Kyluong",Thang_Kyluong));
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Insert 1 đoi tuong Rex_Kyluong vao DB
        /// </summary>
        /// <param name="rex_Kyluong"></param>
        /// <returns></returns>
        public object Insert_Rex_Kyluong(Ecm.Domain.Rex.Rex_Kyluong rex_Kyluong)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Kyluong_Insert",_SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Kyluong", rex_Kyluong.Ma_Kyluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Kyluong", rex_Kyluong.Ten_Kyluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thang_Kyluong", rex_Kyluong.Thang_Kyluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nam_Kyluong", rex_Kyluong.Nam_Kyluong));

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
        /// Update 1 doi tuong Kyluong vao DB
        /// </summary>
        /// <param name="rex_Kyluong"></param>
        /// <returns></returns>
        public object Update_Rex_Kyluong(Ecm.Domain.Rex.Rex_Kyluong rex_Kyluong)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Kyluong_Update", _SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kyluong", rex_Kyluong.Id_Kyluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Kyluong", rex_Kyluong.Ma_Kyluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Kyluong", rex_Kyluong.Ten_Kyluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thang_Kyluong", rex_Kyluong.Thang_Kyluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nam_Kyluong", rex_Kyluong.Nam_Kyluong));

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
        /// Delete 1 doi tuong Kyluong trong DB
        /// </summary>
        /// <param name="rex_Kyluong"></param>
        /// <returns></returns>
        public object Delete_Rex_Kyluong(Ecm.Domain.Rex.Rex_Kyluong rex_Kyluong)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Kyluong_Delete",_SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kyluong", rex_Kyluong.Id_Kyluong));

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
        /// Update 1 collection Kyluong vao DB
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Rex_Kyluong_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Rex_Kyluong", _SqlConnection);
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
