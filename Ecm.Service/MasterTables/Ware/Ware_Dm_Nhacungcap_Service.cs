using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.MasterTables.Ware
{
    public class Ware_Dm_Nhacungcap_Service
    {
        System.Data.OleDb.OleDbConnection _SqlConnection;

        public Ware_Dm_Nhacungcap_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        /// <summary>
        /// Trả về một dataset Ware_Dm_Nhacungcap
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Dm_Nhacungcap()
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Nhacungcap_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");

                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Insert đối tượng Ware_Dm_Nhacungcap vào DB.
        /// </summary>
        /// <param name="Ware_Dm_Nhacungcap"></param>
        /// <returns></returns>
        public object Insert_Ware_Dm_Nhacungcap(Ecm.Domain.MasterTables.Ware.Ware_Dm_Nhacungcap Ware_Dm_Nhacungcap)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Nhacungcap_Insert", _SqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Nhacungcap", Ware_Dm_Nhacungcap.Ma_Nhacungcap));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Nhacungcap", Ware_Dm_Nhacungcap.Ten_Nhacungcap));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Diachi_Nhacungcap", Ware_Dm_Nhacungcap.Diachi_Nhacungcap));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Masothue", Ware_Dm_Nhacungcap.Masothue));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dienthoai", Ware_Dm_Nhacungcap.Dienthoai));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Fax", Ware_Dm_Nhacungcap.Fax));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Email", Ware_Dm_Nhacungcap.Email));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Website", Ware_Dm_Nhacungcap.Website));

                OleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        /// <summary>
        /// Update đối tượng Ware_Dm_Nhacungcap vào DB.
        /// </summary>
        /// <param name="Ware_Dm_Nhacungcap"></param>
        /// <returns></returns>
        public object Update_Ware_Dm_Nhacungcap(Domain.MasterTables.Ware.Ware_Dm_Nhacungcap Ware_Dm_Nhacungcap)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Nhacungcap_Update", _SqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhacungcap",      Ware_Dm_Nhacungcap.Id_Nhacungcap));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Nhacungcap",      Ware_Dm_Nhacungcap.Ma_Nhacungcap));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Nhacungcap",     Ware_Dm_Nhacungcap.Ten_Nhacungcap));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Diachi_Nhacungcap",  Ware_Dm_Nhacungcap.Diachi_Nhacungcap));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Masothue",           Ware_Dm_Nhacungcap.Masothue));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dienthoai",          Ware_Dm_Nhacungcap.Dienthoai));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Fax",                Ware_Dm_Nhacungcap.Fax));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Email",              Ware_Dm_Nhacungcap.Email));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Website",            Ware_Dm_Nhacungcap.Website));

                OleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                //throw ex;
                return false;
            }
        }

        /// <summary>
        /// Delete đối tượng Ware_Dm_Nhacungcap vào DB.
        /// </summary>
        /// <param name="Ware_Dm_Nhacungcap"></param>
        /// <returns></returns>
        public object Delete_Ware_Dm_Nhacungcap(Domain.MasterTables.Ware.Ware_Dm_Nhacungcap Ware_Dm_Nhacungcap)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Nhacungcap_Delete", _SqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhacungcap", Ware_Dm_Nhacungcap.Id_Nhacungcap));

                OleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        /// <summary>
        /// Update Collection Ware_Dm_Nhacungcap vào DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Ware_Dm_Nhacungcap_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Dm_Nhacungcap", _SqlConnection);
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
    }
}
