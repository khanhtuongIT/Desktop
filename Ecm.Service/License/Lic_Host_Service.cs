using System;
using System.Data;
using System.Configuration;
using Ecm.Domain.License;
namespace Ecm.Service.License
{
    /// <summary>
    /// Summary description for Lic_Host_Service
    /// </summary>
    public class Lic_Host_Service
    {
        System.Data.OleDb.OleDbConnection _oleDbConnection;

        public Lic_Host_Service()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public Lic_Host_Service(System.Data.OleDb.OleDbConnection oleDbConnection)
        {
            this._oleDbConnection = oleDbConnection;
        }

        public void Insert_Lic_Host(Lic_Host Lic_Host)
        {
            try
            {
                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(
                    " INSERT INTO [license_host] " +
                    " ([mac] " +
                    " ,[host] " +
                    " ,[ip4] " +
                    " ,[username] " +
                    " ,[desktop_bmp] " +
                    " ,[runtime] " +
                    " ,codebase) " +
                    " VALUES (?,?,?,?,?,?,?)"
                    , _oleDbConnection);

                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Mac", Lic_Host.Mac));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Host", Lic_Host.Host));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Ip4", Lic_Host.Ip4));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserName", Lic_Host.UserName));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Desktop_Bmp", Lic_Host.Desktop_Bmp));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Runtime", Lic_Host.Runtime));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Codebase", Lic_Host.Codebase));

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { throw ex; }
        }


        public string Get_All_Lic_Host()
        {
            try
            {
                DataSet ds = new DataSet();

                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(
                       " select Id_Lic_Host, Mac,Host, Ip4, UserName,Desktop_Bmp,Runtime,Codebase from license_host"
                       , _oleDbConnection);
                System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(cmd);

                da.Fill(ds, "Lic_Host");
                return FastJSON.JSON.Instance.ToJSON(ds);
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }
    }
}