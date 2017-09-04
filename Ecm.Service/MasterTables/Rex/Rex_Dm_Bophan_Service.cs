using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.MasterTables.Rex
{
    public class Rex_Dm_Bophan_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Rex_Dm_Bophan_Service(System.Data.OleDb.OleDbConnection sqlMaper)
        {
            this._SqlConnection = sqlMaper;
        }
        #endregion

        #region implemetns IObService
        
        /// <summary>
        /// Trả về một dataset Dm_Bophan
        /// </summary>
        /// <returns></returns>
        public string Get_All_Rex_Dm_Bophan_Collection()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Dm_Bophan_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }
        
        /// <summary>
        /// Insert 1 đoi tuong Rex_Dm_Bophan vao DB
        /// </summary>
        /// <param name="rex_Dm_Bophan"></param>
        /// <returns></returns>
        public object Insert_Rex_Dm_Bophan(Ecm.Domain.MasterTables.Rex.Rex_Dm_Bophan rex_Dm_Bophan)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Dm_Bophan_Insert",_SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Bophan", rex_Dm_Bophan.Ma_Bophan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Bophan", rex_Dm_Bophan.Ten_Bophan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan_Ql", rex_Dm_Bophan.Id_Bophan_Ql));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Loai_Bophan", rex_Dm_Bophan.Id_Loai_Bophan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Phuongthuc_Huongluong", rex_Dm_Bophan.Id_Phuongthuc_Huongluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@ThuHai", rex_Dm_Bophan.ThuHai));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@ThuBa", rex_Dm_Bophan.ThuBa));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@ThuTu", rex_Dm_Bophan.ThuTu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@ThuNam", rex_Dm_Bophan.ThuNam));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@ThuSau", rex_Dm_Bophan.ThuSau));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@ThuBay", rex_Dm_Bophan.ThuBay));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@ChuNhat", rex_Dm_Bophan.ChuNhat));

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
        /// Update 1 doi tuong Dm_Bophan vao DB
        /// </summary>
        /// <param name="rex_Dm_Bophan"></param>
        /// <returns></returns>
        public object Update_Rex_Dm_Bophan(Ecm.Domain.MasterTables.Rex.Rex_Dm_Bophan rex_Dm_Bophan)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Dm_Bophan_Update",_SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", rex_Dm_Bophan.Id_Bophan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Bophan", rex_Dm_Bophan.Ma_Bophan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Bophan", rex_Dm_Bophan.Ten_Bophan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan_Ql", rex_Dm_Bophan.Id_Bophan_Ql));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Loai_Bophan", rex_Dm_Bophan.Id_Loai_Bophan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Phuongthuc_Huongluong", rex_Dm_Bophan.Id_Phuongthuc_Huongluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@ThuHai", rex_Dm_Bophan.ThuHai));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@ThuBa", rex_Dm_Bophan.ThuBa));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@ThuTu", rex_Dm_Bophan.ThuTu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@ThuNam", rex_Dm_Bophan.ThuNam));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@ThuSau", rex_Dm_Bophan.ThuSau));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@ThuBay", rex_Dm_Bophan.ThuBay));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@ChuNhat", rex_Dm_Bophan.ChuNhat));

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
        /// Delete 1 doi tuong Dm_Bophan trong DB
        /// </summary>
        /// <param name="rex_Dm_Bophan"></param>
        /// <returns></returns>
        public object Delete_Rex_Dm_Bophan(Ecm.Domain.MasterTables.Rex.Rex_Dm_Bophan rex_Dm_Bophan)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Dm_Bophan_Delete",_SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", rex_Dm_Bophan.Id_Bophan));

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
        /// Update 1 collection Dm_Bophan vao DB
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Rex_Dm_Bophan_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Rex_Dm_Bophan", _SqlConnection);
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
