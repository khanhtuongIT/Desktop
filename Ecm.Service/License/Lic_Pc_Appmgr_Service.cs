using System;
using System.Data;
using System.Configuration;
using Ecm.Domain.License;
namespace Ecm.Service.License
{

    /// <summary>
    /// Summary description for Lic_Pc_Appmgr_Service
    /// </summary>
    public class Lic_Pc_Appmgr_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        public Lic_Pc_Appmgr_Service(System.Data.OleDb.OleDbConnection sqlMaper)
        {
            this._SqlConnection = sqlMaper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Get_All_Lic_Pc_Appmgr()
        {
            try
            {
                DataSet ds = new DataSet();

                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand(
                       "Lic_Pc_Appmgr_selectall"
                       , _SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);

                oleDbDataAdapter.Fill(ds, "GridTable");
                return FastJSON.JSON.Instance.ToJSON(ds);
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }

        public string Get_Lic_Pc_Appmgr_ByPK(Lic_Pc_Appmgr _Lic_Pc_Appmgr)
        {
            try
            {
                DataSet ds = new DataSet();

                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand(
                       "Lic_Pc_Appmgr_SelectByPK"
                       , _SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Pc_Code", _Lic_Pc_Appmgr.Pc_Code));

                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);

                oleDbDataAdapter.Fill(ds, "GridTable");
                return FastJSON.JSON.Instance.ToJSON(ds);
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Lic_Pc_Appmgr"></param>
        /// <returns></returns>
        public object Insert_Lic_Pc_Appmgr(Lic_Pc_Appmgr Lic_Pc_Appmgr)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Lic_Pc_Appmgr_insert", _SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Pc_Code", Lic_Pc_Appmgr.Pc_Code));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Pc_Name", Lic_Pc_Appmgr.Pc_Name));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@User_Name", Lic_Pc_Appmgr.User_Name));

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
        /// 
        /// </summary>
        /// <param name="Lic_Pc_Appmgr"></param>
        /// <returns></returns>
        public object Update_Lic_Pc_Appmgr(Lic_Pc_Appmgr Lic_Pc_Appmgr)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Lic_Pc_Appmgr_update", _SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Pc_Code", Lic_Pc_Appmgr.Pc_Code));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Pc_Name", Lic_Pc_Appmgr.Pc_Name));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@User_Name", Lic_Pc_Appmgr.User_Name));

                oleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object Delete_Lic_Pc_Appmgr(Lic_Pc_Appmgr Lic_Pc_Appmgr)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Lic_Pc_Appmgr_delete", _SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Pc_Code", Lic_Pc_Appmgr.Pc_Code));

                oleDbCommand.ExecuteNonQuery();

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