using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Ware
{
    public class Ware_So_Quytm_Service
    {

        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Ware_So_Quytm_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService

        public string Get_All_Ware_So_Quytm()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_So_Quytm_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public Ecm.Domain.Ware.Ware_So_Quytm Get_Ware_So_Quytm_ByThang_Nam(object thang, object nam)
        {
            Ecm.Domain.Ware.Ware_So_Quytm ware_So_Quytm = new Ecm.Domain.Ware.Ware_So_Quytm();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_So_Quytm_SelectByThang_Nam", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thang", thang));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nam", nam));
            System.Data.OleDb.OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
            if (oleDbDataReader.Read())
            {
                ware_So_Quytm.Id_So_Quytm = Convert.ToInt64("" + oleDbDataReader["Id_So_Quytm"]);
                ware_So_Quytm.Thang = "" + oleDbDataReader["Thang"];
                ware_So_Quytm.Nam = "" + oleDbDataReader["Nam"];
                ware_So_Quytm.Sotien = Convert.ToDecimal("" + oleDbDataReader["Sotien"]);
            }
            return ware_So_Quytm;
        }

        public Ecm.Domain.Ware.Ware_So_Quytm Get_Ware_So_Quytm_ByThang_Nam_IdSoquy(object thang, object nam, object Id_Soquy)
        {
            Ecm.Domain.Ware.Ware_So_Quytm ware_So_Quytm = new Ecm.Domain.Ware.Ware_So_Quytm();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_So_Quytm_SelectByThang_Nam", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thang", thang));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nam", nam));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Soquy", Id_Soquy));
            System.Data.OleDb.OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
            if (oleDbDataReader.Read())
            {
                ware_So_Quytm.Id_So_Quytm = Convert.ToInt64("" + oleDbDataReader["Id_So_Quytm"]);
                ware_So_Quytm.Thang = "" + oleDbDataReader["Thang"];
                ware_So_Quytm.Nam = "" + oleDbDataReader["Nam"];
                ware_So_Quytm.Id_Soquy = "" + oleDbDataReader["Id_Soquy"];
                ware_So_Quytm.Sotien = Convert.ToDecimal("" + oleDbDataReader["Sotien"]);
            }
            return ware_So_Quytm;
        }

        public int Get_Ware_So_Quytm_ByCount()
        {
            Ecm.Domain.Ware.Ware_So_Quytm ware_So_Quytm = new Ecm.Domain.Ware.Ware_So_Quytm();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_So_Quytm_Select_ByCount", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            return (int)oleDbCommand.ExecuteScalar();
        }


        /// <summary>
        /// Insert đối tượng Ware_So_Quytm vào DB.
        /// </summary>
        /// <param name="ware_Quytm_Dauky"></param>
        /// <returns></returns>
        public object Insert_Ware_So_Quytm(Ecm.Domain.Ware.Ware_So_Quytm ware_So_Quytm)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_So_Quytm_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                //oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_So_Quytm", ware_So_Quytm.Id_So_Quytm));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thang", ware_So_Quytm.Thang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nam", ware_So_Quytm.Nam));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien", ware_So_Quytm.Sotien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Soquy", ware_So_Quytm.Id_Soquy));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update đối tượng Ware_So_Quytm vào DB.
        /// </summary>
        /// <param name="ware_Quytm_Dauky"></param>
        /// <returns></returns>
        public object Update_Ware_So_Quytm(Ecm.Domain.Ware.Ware_So_Quytm ware_So_Quytm)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_So_Quytm_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_So_Quytm", ware_So_Quytm.Id_So_Quytm));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thang", ware_So_Quytm.Thang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nam", ware_So_Quytm.Nam));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien", ware_So_Quytm.Sotien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Soquy", ware_So_Quytm.Id_Soquy));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete đối tượng Ware_So_Quytm vào DB.
        /// </summary>
        /// <param name="ware_Quytm_Dauky"></param>
        /// <returns></returns>
        public object Delete_Ware_So_Quytm(Ecm.Domain.Ware.Ware_So_Quytm ware_So_Quytm)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_So_Quytm_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_So_Quytm", ware_So_Quytm.Id_So_Quytm));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
