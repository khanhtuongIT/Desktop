using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.MasterTables.Rex
{
    public class Rex_Dm_Quyetdinh_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Rex_Dm_Quyetdinh_Service(System.Data.OleDb.OleDbConnection sqlMaper)
        {
            this._SqlConnection = sqlMaper;
        }
        #endregion

        #region implemetns IObService
        
        /// <summary>
        /// Trả về một dataset Dm_Quyetdinh
        /// </summary>
        /// <returns></returns>
        public string Get_All_Rex_Dm_Quyetdinh_Collection()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Dm_Quyetdinh_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Insert 1 đoi tuong Rex_Dm_Quyetdinh vao DB
        /// </summary>
        /// <param name="rex_Dm_Quyetdinh"></param>
        /// <returns></returns>
        public object Insert_Rex_Dm_Quyetdinh(Ecm.Domain.MasterTables.Rex.Rex_Dm_Quyetdinh rex_Dm_Quyetdinh)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Dm_Quyetdinh_Insert",_SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Quyetdinh", rex_Dm_Quyetdinh.Ma_Quyetdinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sohieu", rex_Dm_Quyetdinh.Sohieu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Trichyeu", rex_Dm_Quyetdinh.Trichyeu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Noidung", rex_Dm_Quyetdinh.Noidung));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nguoiky", rex_Dm_Quyetdinh.Nguoiky));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngayky", rex_Dm_Quyetdinh.Ngayky));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngaybatdau", rex_Dm_Quyetdinh.Ngaybatdau));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngayketthuc", rex_Dm_Quyetdinh.Ngayketthuc));

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
        /// Update 1 doi tuong Dm_Quyetdinh vao DB
        /// </summary>
        /// <param name="rex_Dm_Quyetdinh"></param>
        /// <returns></returns>
        public object Update_Rex_Dm_Quyetdinh(Ecm.Domain.MasterTables.Rex.Rex_Dm_Quyetdinh rex_Dm_Quyetdinh)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Dm_Quyetdinh_Update", _SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Quyetdinh", rex_Dm_Quyetdinh.Id_Quyetdinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Quyetdinh", rex_Dm_Quyetdinh.Ma_Quyetdinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sohieu", rex_Dm_Quyetdinh.Sohieu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Trichyeu", rex_Dm_Quyetdinh.Trichyeu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Noidung", rex_Dm_Quyetdinh.Noidung));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nguoiky", rex_Dm_Quyetdinh.Nguoiky));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngayky", rex_Dm_Quyetdinh.Ngayky));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngaybatdau", rex_Dm_Quyetdinh.Ngaybatdau));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngayketthuc", rex_Dm_Quyetdinh.Ngayketthuc));

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
        /// Delete 1 doi tuong Dm_Quyetdinh trong DB
        /// </summary>
        /// <param name="rex_Dm_Quyetdinh"></param>
        /// <returns></returns>
        public object Delete_Rex_Dm_Quyetdinh(Ecm.Domain.MasterTables.Rex.Rex_Dm_Quyetdinh rex_Dm_Quyetdinh)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Dm_Quyetdinh_Delete",_SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Quyetdinh", rex_Dm_Quyetdinh.Id_Quyetdinh));

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
        /// Update 1 collection Dm_Quyetdinh vao DB
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Rex_Dm_Quyetdinh_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Rex_Dm_Quyetdinh", _SqlConnection);
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
