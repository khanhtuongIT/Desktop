using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.MasterTables.Ware
{
    public class Ware_Dm_Donvitinh_Quydoi_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Ware_Dm_Donvitinh_Quydoi_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService
        /// <summary>
        /// Trả về một dataset Dm_Donvitinh_Quydoi
        /// </summary>
        /// <returns></returns>
        /// 

        public object ware_dm_donvitinh_quydoi_Text(object Id_Hanghoa_Ban, object Id_Donvitinh, object Soluong)
        {
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("ware_dm_donvitinh_quydoi_Text", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Ban", Id_Hanghoa_Ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Donvitinh", Id_Donvitinh));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong", Soluong));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@DVT_Quydoi", System.Data.OleDb.OleDbType.VarChar));
            oleDbCommand.Parameters["@DVT_Quydoi"].Direction = ParameterDirection.Output;
            oleDbCommand.Parameters["@DVT_Quydoi"].Size = 100;
            oleDbCommand.ExecuteNonQuery();
            return oleDbCommand.Parameters["@DVT_Quydoi"].Value;
        }

        public string Ware_Dm_Donvitinh_Quydoi_By_Id_Hanghoa_Ban_New(object Id_Hanghoa_Ban)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Donvitinh_Quydoi_By_Id_Hanghoa_Ban_New", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Ban", Id_Hanghoa_Ban));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Get_All_Ware_Dm_Donvitinh_Quydoi()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Donvitinh_Quydoi_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Search_Ware_Dm_Donvitinh_Quydoi(Ecm.Domain.MasterTables.Ware.Ware_Dm_Hanghoa_Ban ware_Dm_Hanghoa_Ban)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Donvitinh_Quydoi_SelectAll", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Hanghoa_Ban", ware_Dm_Hanghoa_Ban.Ma_Hanghoa_Ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Hanghoa_Ban", ware_Dm_Hanghoa_Ban.Ten_Hanghoa_Ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Barcode_Txt", ware_Dm_Hanghoa_Ban.Barcode_Txt));
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Insert đối tượng Ware_Dm_Donvitinh_Quydoi vào DB.
        /// </summary>
        /// <param name="ware_Dm_Donvitinh_Quydoi"></param>
        /// <returns></returns>
        public object Insert_Ware_Dm_Donvitinh_Quydoi(Ecm.Domain.MasterTables.Ware.Ware_Dm_Donvitinh_Quydoi ware_Dm_Donvitinh_Quydoi)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Donvitinh_Quydoi_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Donvitinh1", ware_Dm_Donvitinh_Quydoi.Id_Hanghoa_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Donvitinh2", ware_Dm_Donvitinh_Quydoi.Id_Donvitinh2));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong1", ware_Dm_Donvitinh_Quydoi.Soluong1));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong2", ware_Dm_Donvitinh_Quydoi.Soluong2));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", ware_Dm_Donvitinh_Quydoi.Ghichu));

                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update đối tượng Ware_Dm_Donvitinh_Quydoi vào DB.
        /// </summary>
        /// <param name="ware_Dm_Donvitinh_Quydoi"></param>
        /// <returns></returns>
        public object Update_Ware_Dm_Donvitinh_Quydoi(Ecm.Domain.MasterTables.Ware.Ware_Dm_Donvitinh_Quydoi ware_Dm_Donvitinh_Quydoi)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Donvitinh_Quydoi_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Donvitinh_Quydoi", ware_Dm_Donvitinh_Quydoi.Id_Donvitinh_Quydoi));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Donvitinh1", ware_Dm_Donvitinh_Quydoi.Id_Hanghoa_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Donvitinh2", ware_Dm_Donvitinh_Quydoi.Id_Donvitinh2));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong1", ware_Dm_Donvitinh_Quydoi.Soluong1));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong2", ware_Dm_Donvitinh_Quydoi.Soluong2));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", ware_Dm_Donvitinh_Quydoi.Ghichu));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete đối tượng Ware_Dm_Donvitinh_Quydoi vào DB.
        /// </summary>
        /// <param name="ware_Dm_Donvitinh_Quydoi"></param>
        /// <returns></returns>
        public object Delete_Ware_Dm_Donvitinh_Quydoi(Ecm.Domain.MasterTables.Ware.Ware_Dm_Donvitinh_Quydoi ware_Dm_Donvitinh_Quydoi)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Donvitinh_Quydoi_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Donvitinh_Quydoi", ware_Dm_Donvitinh_Quydoi.Id_Donvitinh_Quydoi));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update một Collection Ware_Dm_Donvitinh_Quydoi vào DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Ware_Dm_Donvitinh_Quydoi_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Dm_Donvitinh_Quydoi", _SqlConnection);
                System.Data.OleDb.OleDbCommandBuilder oleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(oleDbDataAdapter);
                oleDbDataAdapter = oleDbCommandBuilder.DataAdapter;
                oleDbDataAdapter.Update(dsCollection, "GridTable");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
