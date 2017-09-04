using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.MasterTables.Rex
{
    public class Rex_Dm_Loai_Hopdong_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Rex_Dm_Loai_Hopdong_Service(System.Data.OleDb.OleDbConnection sqlMaper)
        {
            this._SqlConnection = sqlMaper;
        }
        #endregion

        #region implemetns IObService

        /// <summary>
        /// Trả về một dataset Dm_Loai_Hopdong
        /// </summary>
        /// <returns></returns>
        public string Get_All_Rex_Dm_Loai_Hopdong_Collection()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Dm_Loai_Hopdong_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Insert 1 đoi tuong Rex_Dm_Loai_Hopdong vao DB
        /// </summary>
        /// <param name="rex_Dm_Loai_Hopdong"></param>
        /// <returns></returns>
        public object Insert_Rex_Dm_Loai_Hopdong(Ecm.Domain.MasterTables.Rex.Rex_Dm_Loai_Hopdong rex_Dm_Loai_Hopdong)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Dm_Loai_Hopdong_Insert", _SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Loai_Hopdong",    rex_Dm_Loai_Hopdong.Ma_Loai_Hopdong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Loai_Hopdong",   rex_Dm_Loai_Hopdong.Ten_Loai_Hopdong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thoihan",            rex_Dm_Loai_Hopdong.Thoihan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Bhxh",               rex_Dm_Loai_Hopdong.Bhxh));

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
        /// Update 1 doi tuong Dm_Loai_Hopdong vao DB
        /// </summary>
        /// <param name="rex_Dm_Loai_Hopdong"></param>
        /// <returns></returns>
        public object Update_Rex_Dm_Loai_Hopdong(Ecm.Domain.MasterTables.Rex.Rex_Dm_Loai_Hopdong rex_Dm_Loai_Hopdong)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Dm_Loai_Hopdong_Update", _SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Loai_Hopdong",    rex_Dm_Loai_Hopdong.Id_Loai_Hopdong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Loai_Hopdong",    rex_Dm_Loai_Hopdong.Ma_Loai_Hopdong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Loai_Hopdong",   rex_Dm_Loai_Hopdong.Ten_Loai_Hopdong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thoihan",            rex_Dm_Loai_Hopdong.Thoihan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Bhxh",               rex_Dm_Loai_Hopdong.Bhxh));

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
        /// Delete 1 doi tuong Dm_Loai_Hopdong trong DB
        /// </summary>
        /// <param name="rex_Dm_Loai_Hopdong"></param>
        /// <returns></returns>
        public object Delete_Rex_Dm_Loai_Hopdong(Ecm.Domain.MasterTables.Rex.Rex_Dm_Loai_Hopdong rex_Dm_Loai_Hopdong)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Dm_Loai_Hopdong_Delete", _SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Loai_Hopdong", rex_Dm_Loai_Hopdong.Id_Loai_Hopdong));

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
        /// Update 1 collection Dm_Loai_Hopdong vao DB
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Rex_Dm_Loai_Hopdong_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Rex_Dm_Loai_Hopdong", _SqlConnection);
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
