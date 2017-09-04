using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Ware
{
    public class Ware_Hanghoa_Ban_Dauky_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Ware_Hanghoa_Ban_Dauky_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService
        /// <summary>
        /// Trả về một dataset Hanghoa_Ban_Dauky
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Hanghoa_Ban_Dauky()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hanghoa_Ban_Dauky_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Insert đối tượng Ware_Hanghoa_Ban_Dauky vào DB.
        /// </summary>
        /// <param name="ware_Hanghoa_Ban_Dauky"></param>
        /// <returns></returns>
        public object Insert_Ware_Hanghoa_Ban_Dauky(Ecm.Domain.Ware.Ware_Hanghoa_Ban_Dauky ware_Hanghoa_Ban_Dauky)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hanghoa_Ban_Dauky_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Nhap",          ware_Hanghoa_Ban_Dauky.Ngay_Nhap));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban",     ware_Hanghoa_Ban_Dauky.Id_Cuahang_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Ban",     ware_Hanghoa_Ban_Dauky.Id_Hanghoa_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong",            ware_Hanghoa_Ban_Dauky.Soluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Donvitinh",       ware_Hanghoa_Ban_Dauky.Id_Donvitinh));

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
        /// Update đối tượng Ware_Hanghoa_Ban_Dauky vào DB.
        /// </summary>
        /// <param name="ware_Hanghoa_Ban_Dauky"></param>
        /// <returns></returns>
        public object Update_Ware_Hanghoa_Ban_Dauky(Ecm.Domain.Ware.Ware_Hanghoa_Ban_Dauky ware_Hanghoa_Ban_Dauky)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hanghoa_Ban_Dauky_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Ban_Dauky", ware_Hanghoa_Ban_Dauky.Id_Hanghoa_Ban_Dauky));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Nhap",      ware_Hanghoa_Ban_Dauky.Ngay_Nhap));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", ware_Hanghoa_Ban_Dauky.Id_Cuahang_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Ban", ware_Hanghoa_Ban_Dauky.Id_Hanghoa_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong",        ware_Hanghoa_Ban_Dauky.Soluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Donvitinh",   ware_Hanghoa_Ban_Dauky.Id_Donvitinh));

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
        /// Delete đối tượng Ware_Hanghoa_Ban_Dauky vào DB.
        /// </summary>
        /// <param name="ware_Hanghoa_Ban_Dauky"></param>
        /// <returns></returns>
        public object Delete_Ware_Hanghoa_Ban_Dauky(Ecm.Domain.Ware.Ware_Hanghoa_Ban_Dauky ware_Hanghoa_Ban_Dauky)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hanghoa_Ban_Dauky_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Ban_Dauky", ware_Hanghoa_Ban_Dauky.Id_Hanghoa_Ban_Dauky));

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
        /// Update một Collection Ware_Hanghoa_Ban_Dauky vào DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Ware_Hanghoa_Ban_Dauky_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Hanghoa_Ban_Dauky", _SqlConnection);
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
