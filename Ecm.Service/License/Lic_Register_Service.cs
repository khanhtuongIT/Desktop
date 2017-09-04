using System;
using System.Data;
using System.Configuration;
using Ecm.Domain.License;
namespace Ecm.Service.License
{

    /// <summary>
    /// Summary description for Lic_Register_Service
    /// </summary>
    public class Lic_Register_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        public Lic_Register_Service(System.Data.OleDb.OleDbConnection sqlMaper)
        {
            this._SqlConnection = sqlMaper;
        }

        public string Get_All_Lic_Register()
        {
            try
            {
                DataSet dsCollection = new DataSet();

                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand(
                       "lic_Register_selectall"
                       , _SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);

                oleDbDataAdapter.Fill(dsCollection, "GridTable");
                            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }

        public string Get_Lic_Register(Lic_Register lic_register)
        {
            try
            {
                DataSet ds = new DataSet();

                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand(
                       "Lic_Register_SelectBy_RegCode"
                       , _SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Reg_Code", lic_register.Reg_Code));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Pc_Code", lic_register.Pc_Code));

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

        public object Insert_Lic_Register(Lic_Register lic_register)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("lic_Register_insert", _SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Reg_Code", lic_register.Reg_Code));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Pc_Code", lic_register.Pc_Code));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Product_Gui", lic_register.Product_Gui));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Customer_Code", lic_register.Customer_Code));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Pc_Name", lic_register.Pc_Name));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@User_Name", lic_register.User_Name));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Serial_Number", lic_register.Serial_Number));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Runtype", lic_register.Runtype));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Expired_Date", lic_register.Expired_Date));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Install_Date", lic_register.Install_Date));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Reg_Date", lic_register.Reg_Date));

                oleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object Update_Lic_Register(Lic_Register lic_register)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("lic_Register_update", _SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Reg_Code", lic_register.Reg_Code));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Pc_Code", lic_register.Pc_Code));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Product_Gui", lic_register.Product_Gui));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Customer_Code", lic_register.Customer_Code));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Pc_Name", lic_register.Pc_Name));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@User_Name", lic_register.User_Name));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Serial_Number", lic_register.Serial_Number));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Runtype", lic_register.Runtype));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Expired_Date", lic_register.Expired_Date));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Install_Date", lic_register.Install_Date));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Reg_Date", lic_register.Reg_Date));

                oleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }


        public object Delete_Lic_Register(Lic_Register lic_register)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Lic_Register_Delete", _SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Reg_Code", lic_register.Reg_Code));

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