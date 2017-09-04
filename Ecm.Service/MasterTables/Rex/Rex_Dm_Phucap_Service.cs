using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.MasterTables.Rex
{
    public class Rex_Dm_Phucap_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Rex_Dm_Phucap_Service(System.Data.OleDb.OleDbConnection sqlMaper)
        {
            this._SqlConnection = sqlMaper;
        }
        #endregion

        #region implemetns IObService
        
        /// <summary>
        /// Trả về một dataset Dm_Phucap
        /// </summary>
        /// <returns></returns>
        public string Get_All_Rex_Dm_Phucap_Collection()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Dm_Phucap_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Get_All_Rex_Dm_Phucaprieng_Collection()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Dm_Phucap_SelectAll_Pcrieng", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Insert 1 đoi tuong Rex_Dm_Phucap vao DB
        /// </summary>
        /// <param name="rex_Dm_Phucap"></param>
        /// <returns></returns>
        public object Insert_Rex_Dm_Phucap(Ecm.Domain.MasterTables.Rex.Rex_Dm_Phucap rex_Dm_Phucap)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Dm_Phucap_Insert",_SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Phucap", rex_Dm_Phucap.Ma_Phucap));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Phucap", rex_Dm_Phucap.Ten_Phucap));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Heso_Phucap", rex_Dm_Phucap.Heso_Phucap));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Luong_Phucap", rex_Dm_Phucap.Luong_Phucap));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Parent", rex_Dm_Phucap.Id_Parent));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chiuthue", rex_Dm_Phucap.Chiuthue));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Phucap_Chung", rex_Dm_Phucap.Phucap_Chung));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Chucvu", rex_Dm_Phucap.Id_Chucvu));

               

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
        /// Update 1 doi tuong Dm_Phucap vao DB
        /// </summary>
        /// <param name="rex_Dm_Phucap"></param>
        /// <returns></returns>
        public object Update_Rex_Dm_Phucap(Ecm.Domain.MasterTables.Rex.Rex_Dm_Phucap rex_Dm_Phucap)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Dm_Phucap_Update", _SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Dm_Phucap", rex_Dm_Phucap.Id_Dm_Phucap));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Phucap", rex_Dm_Phucap.Ma_Phucap));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Phucap", rex_Dm_Phucap.Ten_Phucap));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Heso_Phucap", rex_Dm_Phucap.Heso_Phucap));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Luong_Phucap", rex_Dm_Phucap.Luong_Phucap));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Parent", rex_Dm_Phucap.Id_Parent));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chiuthue", rex_Dm_Phucap.Chiuthue));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Phucap_Chung", rex_Dm_Phucap.Phucap_Chung));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Chucvu", rex_Dm_Phucap.Id_Chucvu));

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
        /// Delete 1 doi tuong Dm_Phucap trong DB
        /// </summary>
        /// <param name="rex_Dm_Phucap"></param>
        /// <returns></returns>
        public object Delete_Rex_Dm_Phucap(Ecm.Domain.MasterTables.Rex.Rex_Dm_Phucap rex_Dm_Phucap)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Dm_Phucap_Delete", _SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Phucap", rex_Dm_Phucap.Id_Dm_Phucap));

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
        /// Update 1 collection Dm_Phucap vao DB
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Rex_Dm_Phucap_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Rex_Dm_Phucap", _SqlConnection);
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
