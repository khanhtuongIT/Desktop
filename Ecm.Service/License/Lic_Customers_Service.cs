using System;
using System.Data;
using System.Configuration;
using Ecm.Domain.License;
namespace Ecm.Service.License
{

    /// <summary>
    /// Summary description for Lic_Customers_Service
    /// </summary>
    public class Lic_Customers_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        public Lic_Customers_Service(System.Data.OleDb.OleDbConnection sqlMaper)
        {
            this._SqlConnection = sqlMaper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Get_All_Lic_Customers()
        {
            try
            {
                var LicenseCode = global::Ecm.Service.Properties.Resources.LicenseCode;

                DataSet ds = new DataSet();
                    System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand(
                           "lic_customers_selectall"
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

        public string Get_Lic_Customers_ByPK(object Customer_Code, object Product_Gui)
        {
            try
            {
                DataSet ds = new DataSet();

                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand(
                       "Lic_Customers_SelectByPK"
                       , _SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Customer_Code", Customer_Code));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Product_Gui", Product_Gui));

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
        public string Get_Lic_Customers_ByProduct(object Product_Gui)
        {
            try
            {
                DataSet ds = new DataSet();

                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand(
                       "Lic_Customers_SelectByProduct"
                       , _SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Product_Gui", Product_Gui));

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
        /// <param name="lic_Customers"></param>
        /// <returns></returns>
        public object Insert_Lic_Customers(Lic_Customers lic_customers)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("lic_customers_insert", _SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Customer_Code", lic_customers.Customer_Code));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Product_Gui", lic_customers.Product_Gui));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Runtype", lic_customers.Runtype));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Noseats", lic_customers.Noseats));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Expired_Date", lic_customers.Expired_Date));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Email", lic_customers.Email));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Create_Date", lic_customers.Create_Date));

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
        /// <param name="lic_Customers"></param>
        /// <returns></returns>
        public object Update_Lic_Customers(Lic_Customers lic_customers)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("lic_customers_update", _SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Customer_Code", lic_customers.Customer_Code));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Product_Gui", lic_customers.Product_Gui));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Runtype", lic_customers.Runtype));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Noseats", lic_customers.Noseats));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Expired_Date", lic_customers.Expired_Date));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Email", lic_customers.Email));

                oleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object Delete_Lic_Customers(Lic_Customers lic_customers)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("lic_customers_delete", _SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Customer_Code", lic_customers.Customer_Code));

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