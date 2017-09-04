using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Ware
{
    public class Ware_Hdbanhang_Sum_Service
    {
         #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Ware_Hdbanhang_Sum_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService

        /// <summary>
        /// Trả về một dataset Hdbanhang
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Hdbanhang_Sum(Ecm.Domain.Ware.Ware_Hdbanhang_Sum  Ware_Hdbanhang_Sum)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Sum_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu",Ware_Hdbanhang_Sum.Ngay_Chungtu));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban",Ware_Hdbanhang_Sum.Id_Cuahang_Ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kho_Hanghoa_Mua",Ware_Hdbanhang_Sum.Id_Kho_Hanghoa_Mua));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public object RptWare_Hdbanhang_Sum_Cal(Ecm.Domain.Ware.Ware_Hdbanhang_Sum Ware_Hdbanhang_Sum)
        {
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("RptWare_Hdbanhang_Sum_Cal", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu",Ware_Hdbanhang_Sum.Ngay_Chungtu));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban",Ware_Hdbanhang_Sum.Id_Cuahang_Ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kho_Hanghoa_Mua",Ware_Hdbanhang_Sum.Id_Kho_Hanghoa_Mua));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thanhtien", System.Data.OleDb.OleDbType.Decimal));

            oleDbCommand.Parameters["@Thanhtien"].Direction = ParameterDirection.Output;
            oleDbCommand.ExecuteNonQuery();

            return oleDbCommand.Parameters["@Thanhtien"].Value;
        }

       
        /// <summary>
        /// Update một Collection Ware_Hdbanhang vào DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Ware_Hdbanhang_Sum_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Hdbanhang_Sum", _SqlConnection);
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
