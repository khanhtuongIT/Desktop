using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Ware
{
    public class Ware_Hdmuahang_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Ware_Hdmuahang_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService
        /// <summary>
        /// Trả về một dataset Hdmuahang
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Hdmuahang(object Ngay_Chungtu)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdmuahang_SelectAll", this._SqlConnection);
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
        public string Get_All_Ware_Hdmuahang_Chitiet_By_Hdmuahang(object id_hdmuahang)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdmuahang_Chitiet_SelectByFK", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hdmuahang", id_hdmuahang));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Trả về một dataset
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Hdmuahang_ByNhacungcap(object Id_Nhacungcap)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdmuahang_Select_ByNhacungcap", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhacungcap", Id_Nhacungcap));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public bool Check_Hdmuahang_Dachi(object Chungtu_Goc)
        {
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdmuahang_Dachi", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chungtu_Goc", Chungtu_Goc));

            int rownumber = (int)oleDbCommand.ExecuteScalar();
            if (rownumber > 0)
                return true;

            return false;
        }

        
        /// <summary>
        /// Insert đối tượng Ware_Hdmuahang vào DB.
        /// </summary>
        /// <param name="ware_Hdmuahang"></param>
        /// <returns></returns>
        public object Insert_Ware_Hdmuahang(Ecm.Domain.Ware.Ware_Hdmuahang ware_Hdmuahang)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdmuahang_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hdmuahang", System.Data.OleDb.OleDbType.BigInt));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu",              ware_Hdmuahang.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu",           ware_Hdmuahang.Ngay_Chungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Thanhtoan",         ware_Hdmuahang.Ngay_Thanhtoan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang",           ware_Hdmuahang.Id_Khachhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Hoten_Nguoiban",         ware_Hdmuahang.Hoten_Nguoiban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Hoten_Nguoimua",         ware_Hdmuahang.Hoten_Nguoimua));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien",                 ware_Hdmuahang.Sotien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Phuongthuc_Thanhtoan",   ware_Hdmuahang.Phuongthuc_Thanhtoan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@So_Seri",                ware_Hdmuahang.So_Seri));
                oleDbCommand.Parameters["@Id_Hdmuahang"].Direction = ParameterDirection.Output;

                oleDbCommand.ExecuteNonQuery();

                return oleDbCommand.Parameters["@Id_Hdmuahang"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        /// <summary>
        /// Update đối tượng Ware_Hdmuahang vào DB.
        /// </summary>
        /// <param name="ware_Hdmuahang"></param>
        /// <returns></returns>
        public object Update_Ware_Hdmuahang(Ecm.Domain.Ware.Ware_Hdmuahang ware_Hdmuahang)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdmuahang_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hdmuahang",           ware_Hdmuahang.Id_Hdmuahang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu",              ware_Hdmuahang.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu",           ware_Hdmuahang.Ngay_Chungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Thanhtoan",         ware_Hdmuahang.Ngay_Thanhtoan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang",           ware_Hdmuahang.Id_Khachhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Hoten_Nguoiban",         ware_Hdmuahang.Hoten_Nguoiban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Hoten_Nguoimua",         ware_Hdmuahang.Hoten_Nguoimua));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien",                 ware_Hdmuahang.Sotien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Phuongthuc_Thanhtoan",   ware_Hdmuahang.Phuongthuc_Thanhtoan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@So_Seri",                ware_Hdmuahang.So_Seri));

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
        /// Delete đối tượng Ware_Hdmuahang vào DB.
        /// </summary>
        /// <param name="ware_Hdmuahang"></param>
        /// <returns></returns>
        public object Delete_Ware_Hdmuahang(Ecm.Domain.Ware.Ware_Hdmuahang ware_Hdmuahang)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdmuahang_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hdmuahang", ware_Hdmuahang.Id_Hdmuahang));

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
        /// Update một Collection Ware_Hdmuahang_Chitiet vào DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Ware_Hdmuahang_Chitiet_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("select * from Ware_Hdmuahang_Chitiet", this._SqlConnection);

                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
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
        /// nhanvuong - 25/10/2010
        /// trả về ds hd mua hàng by NCC, ngày bắt đầu, ngày kết thúc --> report BÁO CÁO CHI TIẾT HÀNG MUA VÀO
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Hdmuahang_ByNhacungcap_ByDate(object id_hdmuahang, object ngay_batdau, object ngay_ketthuc)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdmuahang_Select_ByNhacungcap_ByDate", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hdmuahang", id_hdmuahang));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", ngay_batdau));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", ngay_ketthuc));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        #endregion
    }
}
