using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecm.Service.Bar
{
    public class Bar_Rentcost_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Bar_Rentcost_Service(System.Data.OleDb.OleDbConnection sqlMaper)
        {
            this._SqlConnection = sqlMaper;
        }
        #endregion

        #region implemetns IObService
        
        /// <summary>
        /// Trả về một dataset Dm_Table
        /// </summary>
        /// <returns></returns>
        public string Get_All_Bar_Rentcost_Collection(object Id_Cuahang_Ban, object Id_Class, object Ngay_Batdau)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Rentcost_SelectAll", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban",Id_Cuahang_Ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Class",Id_Class));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", Ngay_Batdau));
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

       

        /// <summary>
        /// Update 1 collection Dm_Table vao DB
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Bar_Rentcost_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter();
                //System.Data.OleDb.OleDbCommandBuilder oleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(oleDbDataAdapter);
                //oleDbDataAdapter = oleDbCommandBuilder.DataAdapter;

                oleDbDataAdapter.SelectCommand = new System.Data.OleDb.OleDbCommand("Bar_Rentcost_SelectAll", _SqlConnection);
                oleDbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                oleDbDataAdapter.InsertCommand = new System.Data.OleDb.OleDbCommand("Bar_Rentcost_Insert", _SqlConnection);
                oleDbDataAdapter.InsertCommand.Parameters.Add("@Id_Class", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Class");
                oleDbDataAdapter.InsertCommand.Parameters.Add("@Id_Rentlevel", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Rentlevel");
                oleDbDataAdapter.InsertCommand.Parameters.Add("@Dongia", System.Data.OleDb.OleDbType.Decimal, 18, "Dongia");
                oleDbDataAdapter.InsertCommand.Parameters.Add("@Ngay_Batdau", System.Data.OleDb.OleDbType.DBDate, 18, "Ngay_Batdau");
                oleDbDataAdapter.InsertCommand.Parameters.Add("@Ngay_Ketthuc", System.Data.OleDb.OleDbType.DBDate, 18, "Ngay_Ketthuc");
                oleDbDataAdapter.InsertCommand.Parameters.Add("@Id_Cuahang_Ban", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Cuahang_Ban");
                oleDbDataAdapter.InsertCommand.CommandType = CommandType.StoredProcedure;

                oleDbDataAdapter.UpdateCommand = new System.Data.OleDb.OleDbCommand("Bar_Rentcost_Update", _SqlConnection);
                oleDbDataAdapter.UpdateCommand.Parameters.Add("@Id_Rentcost", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Rentcost");
                oleDbDataAdapter.UpdateCommand.Parameters.Add("@Id_Class", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Class");
                oleDbDataAdapter.UpdateCommand.Parameters.Add("@Id_Rentlevel", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Rentlevel");
                oleDbDataAdapter.UpdateCommand.Parameters.Add("@Dongia", System.Data.OleDb.OleDbType.Decimal, 18, "Dongia");
                oleDbDataAdapter.UpdateCommand.Parameters.Add("@Ngay_Batdau", System.Data.OleDb.OleDbType.DBDate, 18, "Ngay_Batdau");
                oleDbDataAdapter.UpdateCommand.Parameters.Add("@Ngay_Ketthuc", System.Data.OleDb.OleDbType.DBDate, 18, "Ngay_Ketthuc");
                oleDbDataAdapter.UpdateCommand.Parameters.Add("@Id_Cuahang_Ban", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Cuahang_Ban");
                oleDbDataAdapter.UpdateCommand.CommandType = CommandType.StoredProcedure;

                oleDbDataAdapter.DeleteCommand = new System.Data.OleDb.OleDbCommand("Bar_Rentcost_Delete", _SqlConnection);
                oleDbDataAdapter.DeleteCommand.Parameters.Add("@Id_Rentcost", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Rentcost");
                oleDbDataAdapter.DeleteCommand.CommandType = CommandType.StoredProcedure;

                oleDbDataAdapter.Update(dsCollection, "GridTable");
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Rentcost", DateTime.Now);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public bool Bar_Rentcost_CheckDate(Domain.Bar.Bar_Rentcost Bar_Rentcost)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("bar_rentcost_checkdate", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Bar_Rentcost.Id_Cuahang_Ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Class", Bar_Rentcost.Id_Class));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Rentlevel", Bar_Rentcost.Id_Rentlevel));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", Bar_Rentcost.Ngay_Batdau));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", Bar_Rentcost.Ngay_Ketthuc));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@valid", System.Data.OleDb.OleDbType.Boolean));
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters["@valid"].Direction = ParameterDirection.Output;

            oleDbCommand.ExecuteNonQuery();

            bool valid = false;
            bool.TryParse("" + oleDbCommand.Parameters["@valid"].Value, out valid);

            return valid;
        }
        #endregion
    }
}
