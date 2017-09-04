using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Ecm.Service.Ware
{
    public class Ware_Nhap_Hh_Ban_Err_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Ware_Nhap_Hh_Ban_Err_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService
        /// <summary>
        /// Trả về một dataset Nhap_Hh_Ban_Err
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Nhap_Hh_Ban_Err(object Ngay_Chungtu)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Nhap_Hh_Ban_Err_SelectAll", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", Ngay_Chungtu));
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Trả về một dataset
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Nhap_Hh_Ban_Err_Chitiet_By_Nhap_Hh_Ban_Err(object id_Nhap_Hh_Ban_Err)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Nhap_Hh_Ban_Err_Chitiet_SelectByFK", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhap_Hh_Ban_Err", id_Nhap_Hh_Ban_Err));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Insert đối tượng Ware_Nhap_Hh_Ban_Err vào DB.
        /// </summary>
        /// <param name="ware_Nhap_Hh_Ban_Err"></param>
        /// <returns></returns>
        public object Insert_Ware_Nhap_Hh_Ban_Err(Ecm.Domain.Ware.Ware_Nhap_Hh_Ban_Err ware_Nhap_Hh_Ban_Err)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Nhap_Hh_Ban_Err_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhap_Hh_Ban_Err", ware_Nhap_Hh_Ban_Err.Id_Nhap_Hh_Ban_Err));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", ware_Nhap_Hh_Ban_Err.Id_Cuahang_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", ware_Nhap_Hh_Ban_Err.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Nhap", ware_Nhap_Hh_Ban_Err.Ngay_Nhap));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Nhap", ware_Nhap_Hh_Ban_Err.Id_Nhansu_Nhap));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", ware_Nhap_Hh_Ban_Err.Ghichu));

                oleDbCommand.Parameters["@Id_Nhap_Hh_Ban_Err"].Direction = ParameterDirection.Output;
                oleDbCommand.ExecuteNonQuery();

                return oleDbCommand.Parameters["@Id_Nhap_Hh_Ban_Err"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        /// <summary>
        /// Update đối tượng Ware_Nhap_Hh_Ban_Err vào DB.
        /// </summary>
        /// <param name="ware_Nhap_Hh_Ban_Err"></param>
        /// <returns></returns>
        public object Update_Ware_Nhap_Hh_Ban_Err(Ecm.Domain.Ware.Ware_Nhap_Hh_Ban_Err ware_Nhap_Hh_Ban_Err)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Nhap_Hh_Ban_Err_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhap_Hh_Ban_Err", ware_Nhap_Hh_Ban_Err.Id_Nhap_Hh_Ban_Err));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", ware_Nhap_Hh_Ban_Err.Id_Cuahang_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", ware_Nhap_Hh_Ban_Err.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Nhap", ware_Nhap_Hh_Ban_Err.Ngay_Nhap));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Nhap", ware_Nhap_Hh_Ban_Err.Id_Nhansu_Nhap));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", ware_Nhap_Hh_Ban_Err.Ghichu));

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
        /// Delete đối tượng Ware_Nhap_Hh_Ban_Err vào DB.
        /// </summary>
        /// <param name="ware_Nhap_Hh_Ban_Err"></param>
        /// <returns></returns>
        public object Delete_Ware_Nhap_Hh_Ban_Err(Ecm.Domain.Ware.Ware_Nhap_Hh_Ban_Err ware_Nhap_Hh_Ban_Err)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Nhap_Hh_Ban_Err_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhap_Hh_Ban_Err", ware_Nhap_Hh_Ban_Err.Id_Nhap_Hh_Ban_Err));

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
        /// Update một Collection Ware_Nhap_Hh_Ban_Err_Chitiet vào DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Ware_Nhap_Hh_Ban_Err_Chitiet_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Nhap_Hh_Ban_Err_Chitiet", _SqlConnection);
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
