using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.MasterTables.Rex
{
    public class Rex_Dm_Heso_Giotangca_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Rex_Dm_Heso_Giotangca_Service(System.Data.OleDb.OleDbConnection sqlMaper)
        {
            this._SqlConnection = sqlMaper;
        }
        #endregion

        #region implemetns IObService
        
        /// <summary>
        /// Trả về một dataset Rex_Dm_Heso_Giotangca
        /// </summary>
        /// <returns></returns>
        public string Get_All_Rex_Dm_Heso_Giotangca_Collection()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Dm_Heso_Giotangca_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Insert 1 đoi tuong Rex_Dm_Heso_Giotangca vao DB
        /// </summary>
        /// <param name="Rex_Dm_Heso_Giotangca"></param>
        /// <returns></returns>
        public object Insert_Rex_Dm_Heso_Giotangca(Ecm.Domain.MasterTables.Rex.Rex_Dm_Heso_Giotangca rex_Dm_Heso_Giotangca)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Dm_Heso_Giotangca_Insert", _SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Heso_Giotangca", rex_Dm_Heso_Giotangca.Ma_Heso_Giotangca));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Heso_Giotangca", rex_Dm_Heso_Giotangca.Ten_Heso_Giotangca));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Heso", rex_Dm_Heso_Giotangca.Heso));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", rex_Dm_Heso_Giotangca.Ngay_Batdau));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", rex_Dm_Heso_Giotangca.Ngay_Ketthuc));
                 
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
        /// Update 1 doi tuong Rex_Dm_Heso_Giotangca vao DB
        /// </summary>
        /// <param name="Rex_Dm_Heso_Giotangca"></param>
        /// <returns></returns>
        public object Update_Rex_Dm_Heso_Giotangca(Ecm.Domain.MasterTables.Rex.Rex_Dm_Heso_Giotangca rex_Dm_Heso_Giotangca)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Dm_Heso_Giotangca_Update", _SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Heso_Giotangca", rex_Dm_Heso_Giotangca.Id_Heso_Giotangca));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Heso_Giotangca", rex_Dm_Heso_Giotangca.Ma_Heso_Giotangca));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Heso_Giotangca", rex_Dm_Heso_Giotangca.Ten_Heso_Giotangca));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Heso", rex_Dm_Heso_Giotangca.Heso));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", rex_Dm_Heso_Giotangca.Ngay_Batdau));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", rex_Dm_Heso_Giotangca.Ngay_Ketthuc));
                 
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
        /// Delete 1 doi tuong Rex_Dm_Heso_Giotangca trong DB
        /// </summary>
        /// <param name="Rex_Dm_Heso_Giotangca"></param>
        /// <returns></returns>
        public object Delete_Rex_Dm_Heso_Giotangca(Ecm.Domain.MasterTables.Rex.Rex_Dm_Heso_Giotangca rex_Dm_Heso_Giotangca)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Dm_Heso_Giotangca_Delete", _SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Heso_Giotangca", rex_Dm_Heso_Giotangca.Id_Heso_Giotangca));
                
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
        /// Update 1 collection Rex_Dm_Heso_Giotangca vao DB
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Rex_Dm_Heso_Giotangca_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Rex_Dm_Heso_Giotangca", _SqlConnection);
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
