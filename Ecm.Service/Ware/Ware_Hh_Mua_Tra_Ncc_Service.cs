using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Ware
{
    public class Ware_Hh_Mua_Tra_Ncc_Service
    {
         #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Ware_Hh_Mua_Tra_Ncc_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService
        /// <summary>
        /// Trả về một dataset Quytm_Dauky
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Hh_Mua_Tra_Ncc(object Ngay_Chungtu)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hh_Mua_Tra_Ncc_SelectAll", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", Ngay_Chungtu));
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
        public string Get_All_Ware_Hh_Mua_Tra_Ncc_Chitiet_By_Tra_Ncc(object Id_Hh_Mua_Tra_Ncc)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hh_Mua_Tra_Ncc_Chitiet_SelectByFK", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hh_Mua_Tra_Ncc", Id_Hh_Mua_Tra_Ncc));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }


        /// <summary>
        /// lấy những hàng hóa trả cho nha cung cấp theo của hàng bán
        /// </summary>
        /// <param name="id_cuahang"></param>
        /// <param name="ngay_Batdau"></param>
        /// <param name="ngay_Ketthuc"></param>
        /// <returns></returns>
        public string Get_All_Ware_Xuathang_Tra_Nhacungcap(object id_cuahang, object ngay_Batdau, object ngay_Ketthuc, object id_Hanghoa_Ban, object id_Loai_Hanghoa_Ban)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rptware_Xuathang_Tra_Nhacungcap", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_cuahang", id_cuahang));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", ngay_Batdau));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", ngay_Ketthuc));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Ban", id_Hanghoa_Ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Loai_Hanghoa_Ban", id_Loai_Hanghoa_Ban));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }


        /// <summary>
        /// Insert đối tượng Ware_Hh_Mua_Tra_Ncc vào DB.
        /// </summary>
        /// <param name="ware_Hh_Mua_Tra_Ncc"></param>
        /// <returns></returns>
        public object Insert_Ware_Hh_Mua_Tra_Ncc(Ecm.Domain.Ware.Ware_Hh_Mua_Tra_Ncc ware_Hh_Mua_Tra_Ncc)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hh_Mua_Tra_Ncc_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hh_Mua_Tra_Ncc", ware_Hh_Mua_Tra_Ncc.Id_Hh_Mua_Tra_Ncc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu",          ware_Hh_Mua_Tra_Ncc.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu",       ware_Hh_Mua_Tra_Ncc.Ngay_Chungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu",             ware_Hh_Mua_Tra_Ncc.Ghichu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Lap",      ware_Hh_Mua_Tra_Ncc.Id_Nhansu_Lap));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kho_Hanghoa_Mua", ware_Hh_Mua_Tra_Ncc.Id_Cuahang_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", ware_Hh_Mua_Tra_Ncc.Id_Khachhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien", ware_Hh_Mua_Tra_Ncc.Sotien));

                oleDbCommand.Parameters["@Id_Hh_Mua_Tra_Ncc"].Direction = System.Data.ParameterDirection.Output;

                oleDbCommand.ExecuteNonQuery();


                return oleDbCommand.Parameters["@Id_Hh_Mua_Tra_Ncc"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        /// <summary>
        /// Update đối tượng Ware_Hh_Mua_Tra_Ncc vào DB.
        /// </summary>
        /// <param name="ware_Hh_Mua_Tra_Ncc"></param>
        /// <returns></returns>
        public object Update_Ware_Hh_Mua_Tra_Ncc(Ecm.Domain.Ware.Ware_Hh_Mua_Tra_Ncc ware_Hh_Mua_Tra_Ncc)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hh_Mua_Tra_Ncc_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
           
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hh_Mua_Tra_Ncc", ware_Hh_Mua_Tra_Ncc.Id_Hh_Mua_Tra_Ncc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", ware_Hh_Mua_Tra_Ncc.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", ware_Hh_Mua_Tra_Ncc.Ngay_Chungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", ware_Hh_Mua_Tra_Ncc.Ghichu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Lap", ware_Hh_Mua_Tra_Ncc.Id_Nhansu_Lap));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kho_Hanghoa_Mua", ware_Hh_Mua_Tra_Ncc.Id_Cuahang_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", ware_Hh_Mua_Tra_Ncc.Id_Khachhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien", ware_Hh_Mua_Tra_Ncc.Sotien));

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
        /// Delete đối tượng Ware_Hh_Mua_Tra_Ncc vào DB.
        /// </summary>
        /// <param name="ware_Hh_Mua_Tra_Ncc"></param>
        /// <returns></returns>
        public object Delete_Ware_Hh_Mua_Tra_Ncc(Ecm.Domain.Ware.Ware_Hh_Mua_Tra_Ncc ware_Hh_Mua_Tra_Ncc)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hh_Mua_Tra_Ncc_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hh_Mua_Tra_Ncc", ware_Hh_Mua_Tra_Ncc.Id_Hh_Mua_Tra_Ncc));

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
        /// Update một Collection Ware_Hh_Mua_Tra_Ncc vào DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Ware_Hh_Mua_Tra_Ncc_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Hh_Mua_Tra_Ncc", _SqlConnection);
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
        public object Update_Ware_Hh_Mua_Tra_Ncc_Chitiet_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Hh_Mua_Tra_Ncc_Chitiet", _SqlConnection);
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
