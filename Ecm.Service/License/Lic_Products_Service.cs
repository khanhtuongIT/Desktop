using System;
using System.Data;
using System.Configuration;
using Ecm.Domain.License;
namespace Ecm.Service.License
{

    /// <summary>
    /// Summary description for Lic_Products_Service
    /// </summary>
    public class Lic_Products_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        public Lic_Products_Service(System.Data.OleDb.OleDbConnection sqlMaper)
        {
            this._SqlConnection = sqlMaper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Get_All_Lic_Products()
        {
            try
            {
                DataSet ds = new DataSet();

                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand(
                       "lic_products_selectall"
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

        public object Get_Lic_Products_ByPK(object Product_Gui)
        {
            try
            {

                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand(
                       "Lic_Products_SelectByPK"
                       , _SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Product_Gui", Product_Gui));

                return oleDbCommand.ExecuteScalar();
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
        /// <param name="lic_Products"></param>
        /// <returns></returns>
        public object Insert_Lic_Products(Lic_Products lic_products)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("lic_products_insert", _SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Product_Gui", lic_products.Product_Gui));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Product_Name", lic_products.Product_Name));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Product_Version", lic_products.Product_Version));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Release_Date", lic_products.Release_Date));

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
        /// <param name="lic_Products"></param>
        /// <returns></returns>
        public object Update_Lic_Products(Lic_Products lic_products)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("lic_products_update", _SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Product_Gui", lic_products.Product_Gui));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Product_Name", lic_products.Product_Name));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Product_Version", lic_products.Product_Version));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Release_Date", lic_products.Release_Date));

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
        /// <param name="lic_Products"></param>
        /// <returns></returns>
        public object Delete_Lic_Products(Lic_Products lic_products)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("lic_products_delete", _SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Product_Gui", lic_products.Product_Gui));

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