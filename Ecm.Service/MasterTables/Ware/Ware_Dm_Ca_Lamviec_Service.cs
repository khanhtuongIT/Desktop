using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace SunLine.Service.MasterTables.Ware
{
    public class Ware_Dm_Ca_Lamviec_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Constructor
        public Ware_Dm_Ca_Lamviec_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService
        /// <summary>
        /// Trả về một dataset Ware_Dm_Ca_Lamviec
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Dm_Ca_Lamviec()
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Ca_Lamviec_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");

            return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None);
        }

        /// <summary>
        /// Trả về một dataset Ware_Dm_Ca_Lamviec by hours
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Dm_Ca_Lamviec_ByHours(object ngay_gio)
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Ca_Lamviec_SelectAll_ByHours", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Gio", ngay_gio));
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");

            return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None);
        }

        /// <summary>
        /// Insert đối tượng Ware_Dm_Ca_Lamviec vào DB.
        /// </summary>
        /// <param name="ware_Dm_Donvitinh"></param>
        /// <returns></returns>
        public Object Insert_Ware_Dm_Ca_Lamviec(SunLine.Domain.MasterTables.Ware.Ware_Dm_Ca_Lamviec Ware_Dm_Ca_Lamviec)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Ca_Lamviec_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Ca_Lamviec", Ware_Dm_Ca_Lamviec.Ma_Ca_Lamviec));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Ca_Lamviec", Ware_Dm_Ca_Lamviec.Ten_Ca_Lamviec));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Gio_Batdau", Ware_Dm_Ca_Lamviec.Gio_Batdau));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Gio_Ketthuc", Ware_Dm_Ca_Lamviec.Gio_Ketthuc));

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
        /// Update đối tượng Ware_Dm_Ca_Lamviec vào DB.
        /// </summary>
        /// <param name="ware_Dm_Donvitinh"></param>
        /// <returns></returns>
        public Object Update_Ware_Dm_Ca_Lamviec(SunLine.Domain.MasterTables.Ware.Ware_Dm_Ca_Lamviec Ware_Dm_Ca_Lamviec)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Ca_Lamviec_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Ca_Lamviec", Ware_Dm_Ca_Lamviec.Id_Ca_Lamviec));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Ca_Lamviec", Ware_Dm_Ca_Lamviec.Ma_Ca_Lamviec));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Ca_Lamviec", Ware_Dm_Ca_Lamviec.Ten_Ca_Lamviec));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Gio_Batdau", Ware_Dm_Ca_Lamviec.Gio_Batdau));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Gio_Ketthuc", Ware_Dm_Ca_Lamviec.Gio_Ketthuc));

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
        /// Delete đối tượng Ware_Dm_Ca_Lamviec vào DB.
        /// </summary>
        /// <param name="ware_Dm_Donvitinh"></param>
        /// <returns></returns>
        public Object Delete_Ware_Dm_Ca_Lamviec(SunLine.Domain.MasterTables.Ware.Ware_Dm_Ca_Lamviec Ware_Dm_Ca_Lamviec)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Ca_Lamviec_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Ca_Lamviec", Ware_Dm_Ca_Lamviec.Id_Ca_Lamviec));

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
        /// Update Collection Ware_Dm_Ca_Lamviec vào DB.
        /// </summary>
        /// <param name="ware_Dm_Donvitinh"></param>
        /// <returns></returns>
        public Object Update_Ware_Dm_Ca_Lamviec_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Dm_Ca_Lamviec", this._SqlConnection);
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
