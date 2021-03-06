using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.MasterTables.Rex
{
    public class Rex_Dm_Coquan_Service
    {
        System.Data.OleDb.OleDbConnection _SqlConnection;

        public Rex_Dm_Coquan_Service(System.Data.OleDb.OleDbConnection sqlMapper)
        {
            this._SqlConnection = sqlMapper;
        }

        /// <summary>
        /// Get all rex_dm_coquan
        /// </summary>
        /// <param name="rex_dm_coquan"></param>
        /// <returns></returns>
        public string Get_All_Rex_Dm_Coquan()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand("Rex_Dm_Coquan_SelectAll", this._SqlConnection);
            command.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(command);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// insert 1 đối tượng rex_dm_coquan
        /// </summary>
        /// <param name="rex_dm_coquan"></param>
        /// <returns></returns>
        public object Insert_Rex_Dm_Coquan(Ecm.Domain.MasterTables.Rex.Rex_Dm_Coquan rex_dm_coquan)
        {
            try
            {
                System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand("Rex_Dm_Coquan_Insert", this._SqlConnection);
                command.CommandType = CommandType.StoredProcedure;

                //command.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Coquan", System.Data.OleDb.OleDbType.BigInt));
                command.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Coquan", rex_dm_coquan.Ma_Coquan));
                command.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Coquan", rex_dm_coquan.Ten_Coquan));
                command.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Masothue", rex_dm_coquan.Masothue));
                command.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Diachi", rex_dm_coquan.Diachi));
                command.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dienthoai", rex_dm_coquan.Dienthoai));
                command.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Website", rex_dm_coquan.Website));
                command.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Email", rex_dm_coquan.Email));
                //command.Parameters["@Id_Coquan"].Direction = ParameterDirection.Output;

                command.ExecuteNonQuery();
                //return command.Parameters["@Id_Coquan"].Value;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        /// <summary>
        /// update 1 đối tượng rex_dm_coquan
        /// </summary>
        /// <param name="rex_dm_coquan"></param>
        /// <returns></returns>
        public object Update_Rex_Dm_Coquan(Ecm.Domain.MasterTables.Rex.Rex_Dm_Coquan rex_dm_coquan)
        {
            try
            {
                System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand("Rex_Dm_Coquan_Update", this._SqlConnection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Coquan", rex_dm_coquan.Id_Coquan));
                command.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Coquan", rex_dm_coquan.Ma_Coquan));
                command.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Coquan", rex_dm_coquan.Ten_Coquan));
                command.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Masothue", rex_dm_coquan.Masothue));
                command.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Diachi", rex_dm_coquan.Diachi));
                command.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dienthoai", rex_dm_coquan.Dienthoai));
                command.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Website", rex_dm_coquan.Website));
                command.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Email", rex_dm_coquan.Email));
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        /// <summary>
        /// delete 1 đối tượng rex_dm_coquan
        /// </summary>
        /// <param name="rex_dm_coquan"></param>
        /// <returns></returns>
        public object Delete_Rex_Dm_Coquan(Ecm.Domain.MasterTables.Rex.Rex_Dm_Coquan rex_dm_coquan)
        {
            try
            {
                System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand("Rex_Dm_Coquan_Delete", this._SqlConnection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Coquan", rex_dm_coquan.Id_Coquan));
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        /// <summary>
        /// Update 1 Dataset rex_dm_coquan vào DB
        /// </summary>
        /// <param name="rex_dm_coquan"></param>
        /// <returns></returns>
        public object Update_Rex_Dm_Coquan_Collection(System.Data.DataSet dsCollection) {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Rex_Dm_Coquan", _SqlConnection);
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
