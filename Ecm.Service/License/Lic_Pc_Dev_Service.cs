using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using Ecm.Domain.License;
namespace Ecm.Service.License
{
    /// <summary>
    /// Summary description for Lic_Pc_Dev_Service
    /// </summary>
    public class Lic_Pc_Dev_Service
    {
        // Fields
        private OleDbConnection _SqlConnection;

        public Lic_Pc_Dev_Service()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        // Methods
        public Lic_Pc_Dev_Service(OleDbConnection sqlMaper)
        {
            this._SqlConnection = sqlMaper;
        }

        public object Delete_Lic_Pc_Dev(Lic_Pc_Dev Lic_Pc_Dev)
        {
            object obj2;
            try
            {
                OleDbCommand command = new OleDbCommand("Lic_Pc_Dev_delete", this._SqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new OleDbParameter("@Pc_Code", Lic_Pc_Dev.Pc_Code));
                command.ExecuteNonQuery();
                obj2 = true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return obj2;
        }

        public string Get_All_Lic_Pc_Dev()
        {
            try
            {
                DataSet dataSet = new DataSet();
                OleDbCommand selectCommand = new OleDbCommand("Lic_Pc_Dev_selectall", this._SqlConnection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                new OleDbDataAdapter(selectCommand).Fill(dataSet, "GridTable");
                return FastJSON.JSON.Instance.ToJSON(dataSet);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public string Get_Lic_Pc_Dev_ByPK(Lic_Pc_Dev _Lic_Pc_Dev)
        {
            DataSet set2;
            try
            {
                DataSet dataSet = new DataSet();
                OleDbCommand selectCommand = new OleDbCommand("Lic_Pc_Dev_SelectByPK", this._SqlConnection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.Add(new OleDbParameter("@Pc_Code", _Lic_Pc_Dev.Pc_Code));
                new OleDbDataAdapter(selectCommand).Fill(dataSet, "GridTable");
                return FastJSON.JSON.Instance.ToJSON(dataSet);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public object Insert_Lic_Pc_Dev(Lic_Pc_Dev Lic_Pc_Dev)
        {
            object obj2;
            try
            {
                OleDbCommand command = new OleDbCommand("Lic_Pc_Dev_insert", this._SqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new OleDbParameter("@Pc_Code", Lic_Pc_Dev.Pc_Code));
                command.Parameters.Add(new OleDbParameter("@Pc_Name", Lic_Pc_Dev.Pc_Name));
                command.Parameters.Add(new OleDbParameter("@User_Name", Lic_Pc_Dev.User_Name));
                command.Parameters.Add(new OleDbParameter("@Ip4", Lic_Pc_Dev.Ip4));
                command.Parameters.Add(new OleDbParameter("@Runtime", Lic_Pc_Dev.Runtime));
                command.Parameters.Add(new OleDbParameter("@EntryAssembly", Lic_Pc_Dev.EntryAssembly));
                command.ExecuteNonQuery();
                obj2 = true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return obj2;
        }

        public object Update_Lic_Pc_Dev(Lic_Pc_Dev Lic_Pc_Dev)
        {
            object obj2;
            try
            {
                OleDbCommand command = new OleDbCommand("Lic_Pc_Dev_update", this._SqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new OleDbParameter("@Pc_Code", Lic_Pc_Dev.Pc_Code));
                command.Parameters.Add(new OleDbParameter("@Pc_Name", Lic_Pc_Dev.Pc_Name));
                command.Parameters.Add(new OleDbParameter("@User_Name", Lic_Pc_Dev.User_Name));
                command.Parameters.Add(new OleDbParameter("@Ip4", Lic_Pc_Dev.Ip4));
                command.Parameters.Add(new OleDbParameter("@Runtime", Lic_Pc_Dev.Runtime));
                command.Parameters.Add(new OleDbParameter("@EntryAssembly", Lic_Pc_Dev.EntryAssembly));
                command.ExecuteNonQuery();
                obj2 = true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return obj2;
        }


    }
}