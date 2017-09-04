using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Ware
{
    public class Ware_Hh_Kho_Hanghoa_Mua_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Ware_Hh_Kho_Hanghoa_Mua_Service(System.Data.OleDb.OleDbConnection sHhConnection)
        {
            this._SqlConnection = sHhConnection;
        }
        #endregion

        #region implemetns IObService
        /// <summary>
        /// Trả về một dataset Hh_Kho_Hanghoa_Mua
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Hh_Kho_Hanghoa_Mua()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hh_Kho_Hanghoa_Mua_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Insert đối tượng Ware_Hh_Kho_Hanghoa_Mua vào DB.
        /// </summary>
        /// <param name="ware_Hh_Kho_Hanghoa_Mua"></param>
        /// <returns></returns>
        public object Insert_Ware_Hh_Kho_Hanghoa_Mua(Ecm.Domain.Ware.Ware_Hh_Kho_Hanghoa_Mua ware_Hh_Kho_Hanghoa_Mua)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hh_Kho_Hanghoa_Mua_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kho_Hanghoa_Mua", ware_Hh_Kho_Hanghoa_Mua.Id_Kho_Hanghoa_Mua));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Mua", ware_Hh_Kho_Hanghoa_Mua.Id_Hanghoa_Mua));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu",             ware_Hh_Kho_Hanghoa_Mua.Ghichu));

                oleDbCommand.ExecuteNonQuery();
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Ware_Hh_Kho_Hanghoa_Mua", DateTime.Now);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        /// <summary>
        /// Update đối tượng Ware_Hh_Kho_Hanghoa_Mua vào DB.
        /// </summary>
        /// <param name="ware_Hh_Kho_Hanghoa_Mua"></param>
        /// <returns></returns>
        public object Update_Ware_Hh_Kho_Hanghoa_Mua(Ecm.Domain.Ware.Ware_Hh_Kho_Hanghoa_Mua ware_Hh_Kho_Hanghoa_Mua)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hh_Kho_Hanghoa_Mua_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hh_Kho_Hanghoa_Mua", ware_Hh_Kho_Hanghoa_Mua.Id_Hh_Kho_Hanghoa_Mua));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kho_Hanghoa_Mua", ware_Hh_Kho_Hanghoa_Mua.Id_Kho_Hanghoa_Mua));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Mua", ware_Hh_Kho_Hanghoa_Mua.Id_Hanghoa_Mua));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", ware_Hh_Kho_Hanghoa_Mua.Ghichu));

                oleDbCommand.ExecuteNonQuery();
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Ware_Hh_Kho_Hanghoa_Mua", DateTime.Now);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        /// <summary>
        /// Delete đối tượng Ware_Hh_Kho_Hanghoa_Mua vào DB.
        /// </summary>
        /// <param name="ware_Hh_Kho_Hanghoa_Mua"></param>
        /// <returns></returns>
        public object Delete_Ware_Hh_Kho_Hanghoa_Mua(Ecm.Domain.Ware.Ware_Hh_Kho_Hanghoa_Mua ware_Hh_Kho_Hanghoa_Mua)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hh_Kho_Hanghoa_Mua_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hh_Kho_Hanghoa_Mua", ware_Hh_Kho_Hanghoa_Mua.Id_Hh_Kho_Hanghoa_Mua));

                oleDbCommand.ExecuteNonQuery();
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Ware_Hh_Kho_Hanghoa_Mua", DateTime.Now);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        /// <summary>
        /// Update một Collection Ware_Hh_Kho_Hanghoa_Mua vào DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Ware_Hh_Kho_Hanghoa_Mua_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Hh_Kho_Hanghoa_Mua", _SqlConnection);
                System.Data.OleDb.OleDbCommandBuilder oleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(oleDbDataAdapter);
                oleDbDataAdapter = oleDbCommandBuilder.DataAdapter;

                oleDbDataAdapter.Update(dsCollection, "GridTable");
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Ware_Hh_Kho_Hanghoa_Mua", DateTime.Now);
                }
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
