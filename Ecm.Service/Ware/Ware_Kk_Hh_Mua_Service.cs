using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Ecm.Service.Ware
{
    public class Ware_Kk_Hh_Mua_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Ware_Kk_Hh_Mua_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService
        /// <summary>
        /// Trả về một dataset Kk_Hh_Mua
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Kk_Hh_Mua()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Kk_Hh_Mua_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Ngay_Ketthuc"></param>
        /// <param name="Id_Cuahang_Ban"></param>
        /// <returns></returns>
        public string Get_All_Nxt_Hhmua_Notify(object Ngay_Ketthuc, object Id_Kho_Hanghoa_Mua)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rptware_Nxt_Hhmua_Notify", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", Ngay_Ketthuc));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kho_Hanghoa_Mua", Id_Kho_Hanghoa_Mua));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Trả về một dataset
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Kk_Hh_Mua_Chitiet_By_Kk_Hh_Mua(object Id_Kk_Hh_Mua)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Kk_Hh_Mua_Chitiet_SelectByFK", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kk_Hh_Mua", Id_Kk_Hh_Mua));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Insert đối tượng Ware_Kk_Hh_Mua vào DB.
        /// </summary>
        /// <param name="ware_Kk_Hh_Mua"></param>
        /// <returns></returns>
        public object Insert_Ware_Kk_Hh_Mua(Ecm.Domain.Ware.Ware_Kk_Hh_Mua ware_Kk_Hh_Mua)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Kk_Hh_Mua_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kk_Hh_Mua", System.Data.OleDb.OleDbType.BigInt));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kho_Hanghoa_Mua", ware_Kk_Hh_Mua.Id_Kho_Hanghoa_Mua));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", ware_Kk_Hh_Mua.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Kk", ware_Kk_Hh_Mua.Ngay_Kk));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Kk", ware_Kk_Hh_Mua.Id_Nhansu_Kk));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", ware_Kk_Hh_Mua.Ghichu));

                oleDbCommand.Parameters["@Id_Kk_Hh_Mua"].Direction = ParameterDirection.Output;
                oleDbCommand.ExecuteNonQuery();

                return oleDbCommand.Parameters["@Id_Kk_Hh_Mua"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        /// <summary>
        /// Update đối tượng Ware_Kk_Hh_Mua vào DB.
        /// </summary>
        /// <param name="ware_Kk_Hh_Mua"></param>
        /// <returns></returns>
        public object Update_Ware_Kk_Hh_Mua(Ecm.Domain.Ware.Ware_Kk_Hh_Mua ware_Kk_Hh_Mua)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Kk_Hh_Mua_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kk_Hh_Mua", System.Data.OleDb.OleDbType.BigInt));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kho_Hanghoa_Mua", ware_Kk_Hh_Mua.Id_Kho_Hanghoa_Mua));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", ware_Kk_Hh_Mua.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Kk", ware_Kk_Hh_Mua.Ngay_Kk));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Kk", ware_Kk_Hh_Mua.Id_Nhansu_Kk));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", ware_Kk_Hh_Mua.Ghichu));

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
        /// Delete đối tượng Ware_Kk_Hh_Mua vào DB.
        /// </summary>
        /// <param name="ware_Kk_Hh_Mua"></param>
        /// <returns></returns>
        public object Delete_Ware_Kk_Hh_Mua(Ecm.Domain.Ware.Ware_Kk_Hh_Mua ware_Kk_Hh_Mua)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Kk_Hh_Mua_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kk_Hh_Mua", ware_Kk_Hh_Mua.Id_Kk_Hh_Mua));

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
        /// Update một Collection Ware_Kk_Hh_Mua_Chitiet vào DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Ware_Kk_Hh_Mua_Chitiet_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Kk_Hh_Mua_Chitiet", _SqlConnection);
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
