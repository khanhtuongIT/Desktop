using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Ware
{
    public class Ware_Nhap_Hh_Mua_Service
    {
         #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Ware_Nhap_Hh_Mua_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService
        /// <summary>
        /// Trả về một dataset Quytm_Dauky
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Nhap_Hh_Mua()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Nhap_Hh_Mua_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Trả về ds hàng hóa trong phiếu nhập hàng hóa được chọn
        /// </summary>
        /// <param name="Id_Nhap_Hh_Mua"></param>
        /// <returns></returns>
        public string Get_All_Ware_Nhap_Hh_Mua_Chitiet_By_Nhap_Hh(object Id_Nhap_Hh_Mua)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Nhap_Hh_Mua_Chitiet_SelectByFK", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhap_Hh_Mua", Id_Nhap_Hh_Mua));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Insert đối tượng Ware_Nhap_Hh_Mua vào DB.
        /// </summary>
        /// <param name="ware_Nhap_Hh_Mua"></param>
        /// <returns></returns>
        public object Insert_Ware_Nhap_Hh_Mua(Ecm.Domain.Ware.Ware_Nhap_Hh_Mua ware_Nhap_Hh_Mua)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Nhap_Hh_Mua_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhap_Hh_Mua",     ware_Nhap_Hh_Mua.Id_Nhap_Hh_Mua));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kho_Hanghoa_Mua", ware_Nhap_Hh_Mua.Id_Kho_Hanghoa_Mua));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu",          ware_Nhap_Hh_Mua.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Nhanhang",      ware_Nhap_Hh_Mua.Ngay_Nhanhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nguoi_Giaohang",     ware_Nhap_Hh_Mua.Nguoi_Giaohang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Nhanhang", ware_Nhap_Hh_Mua.Id_Nhansu_Nhanhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu",             ware_Nhap_Hh_Mua.Ghichu));

                oleDbCommand.Parameters["@Id_Nhap_Hh_Mua"].Direction = System.Data.ParameterDirection.Output;

                oleDbCommand.ExecuteNonQuery();


                return oleDbCommand.Parameters["@Id_Nhap_Hh_Mua"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        /// <summary>
        /// Update đối tượng Ware_Nhap_Hh_Mua vào DB.
        /// </summary>
        /// <param name="ware_Nhap_Hh_Mua"></param>
        /// <returns></returns>
        public object Update_Ware_Nhap_Hh_Mua(Ecm.Domain.Ware.Ware_Nhap_Hh_Mua ware_Nhap_Hh_Mua)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Nhap_Hh_Mua_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhap_Hh_Mua", ware_Nhap_Hh_Mua.Id_Nhap_Hh_Mua));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kho_Hanghoa_Mua", ware_Nhap_Hh_Mua.Id_Kho_Hanghoa_Mua));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", ware_Nhap_Hh_Mua.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Nhanhang", ware_Nhap_Hh_Mua.Ngay_Nhanhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nguoi_Giaohang", ware_Nhap_Hh_Mua.Nguoi_Giaohang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Nhanhang", ware_Nhap_Hh_Mua.Id_Nhansu_Nhanhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", ware_Nhap_Hh_Mua.Ghichu));

                oleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object Ware_Nhap_Hh_Chitiet_UpdateDongia_FrHdmuahang(object id_hdmuahang, object Id_Nhap_Hh_Ban)
        {
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Nhap_Hh_Chitiet_UpdateDongia_FrHdmuahang", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@id_hdmuahang", id_hdmuahang));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhap_Hh_Ban", Id_Nhap_Hh_Ban));
            
            oleDbCommand.ExecuteNonQuery();

            return true;
        }


        public object Ware_Nhap_Hh_Mua_Chitiet_UpdateDongia_FrHdmuahang(object id_hdmuahang, object Id_Nhap_Hh_Mua)
        {
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Nhap_Hh_Mua_Chitiet_UpdateDongia_FrHdmuahang", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@id_hdmuahang", id_hdmuahang));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhap_Hh_Mua", Id_Nhap_Hh_Mua));

            oleDbCommand.ExecuteNonQuery();

            return true;
        }

        /// <summary>
        /// Delete đối tượng Ware_Nhap_Hh_Mua vào DB.
        /// </summary>
        /// <param name="ware_Nhap_Hh_Mua"></param>
        /// <returns></returns>
        public object Delete_Ware_Nhap_Hh_Mua(Ecm.Domain.Ware.Ware_Nhap_Hh_Mua ware_Nhap_Hh_Mua)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Nhap_Hh_Mua_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhap_Hh_Mua", ware_Nhap_Hh_Mua.Id_Nhap_Hh_Mua));

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
        /// Update một Collection Ware_Nhap_Hh_Mua vào DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Ware_Nhap_Hh_Mua_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Nhap_Hh_Mua", _SqlConnection);
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

        /// <summary>
        /// Update một Collection ware_nhap_hh_mua_chitiet vào DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Ware_Nhap_Hh_Mua_Chitiet_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from ware_nhap_hh_mua_chitiet", _SqlConnection);
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
