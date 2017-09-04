using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Ware
{
    public class Ware_Quytm_Dauky_Service
    {
         #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Ware_Quytm_Dauky_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService
        /// <summary>
        /// Trả về một dataset Quytm_Dauky
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Quytm_Dauky()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Quytm_Dauky_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Insert đối tượng Ware_Quytm_Dauky vào DB.
        /// </summary>
        /// <param name="ware_Quytm_Dauky"></param>
        /// <returns></returns>
        public object Insert_Ware_Quytm_Dauky(Ecm.Domain.Ware.Ware_Quytm_Dauky ware_Quytm_Dauky)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Quytm_Dauky_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Loai_Quytm",  ware_Quytm_Dauky.Id_Loai_Quytm));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien",         ware_Quytm_Dauky.Sotien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu",         ware_Quytm_Dauky.Ghichu));

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
        /// Update đối tượng Ware_Quytm_Dauky vào DB.
        /// </summary>
        /// <param name="ware_Quytm_Dauky"></param>
        /// <returns></returns>
        public object Update_Ware_Quytm_Dauky(Ecm.Domain.Ware.Ware_Quytm_Dauky ware_Quytm_Dauky)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Quytm_Dauky_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Quytm_Dauky", ware_Quytm_Dauky.Id_Quytm_Dauky));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Loai_Quytm",  ware_Quytm_Dauky.Id_Loai_Quytm));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien",         ware_Quytm_Dauky.Sotien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu",         ware_Quytm_Dauky.Ghichu));

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
        /// Delete đối tượng Ware_Quytm_Dauky vào DB.
        /// </summary>
        /// <param name="ware_Quytm_Dauky"></param>
        /// <returns></returns>
        public object Delete_Ware_Quytm_Dauky(Ecm.Domain.Ware.Ware_Quytm_Dauky ware_Quytm_Dauky)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Quytm_Dauky_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Quytm_Dauky", ware_Quytm_Dauky.Id_Quytm_Dauky));

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
        /// Update một Collection Ware_Quytm_Dauky vào DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Ware_Quytm_Dauky_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Quytm_Dauky", _SqlConnection);
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
