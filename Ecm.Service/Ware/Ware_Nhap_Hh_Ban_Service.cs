using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Ecm.Service.Ware
{
    public class Ware_Nhap_Hh_Ban_Service
    {
        System.Data.OleDb.OleDbConnection _SqlConnection;

        public Ware_Nhap_Hh_Ban_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }

        #region implemetns IObService

        public string Ware_Nhap_Hh_Ban_Chitiet_SelectById_Nhap_Chitiet(object Id_Nhap_Hh_Ban_Chitiet)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Nhap_Hh_Ban_Chitiet_SelectById_Nhap_Chitiet", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhap_Hh_Ban_Chitiet", Id_Nhap_Hh_Ban_Chitiet));
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        /// <summary>
        /// Trả về một dataset Nhap_Hh_Ban
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Nhap_Hh_Ban(object Ngay_Chungtu, object Id_Kho)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Nhap_Hh_Ban_SelectAll", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Ngaychungtu", Ngay_Chungtu));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kho", Id_Kho));
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Trả về một dataset
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Nhap_Hh_Ban_Chitiet_By_Nhap_Hh_Ban(object id_Nhap_Hh_Ban)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Nhap_Hh_Ban_Chitiet_SelectByFK", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhap_Hh_Ban", id_Nhap_Hh_Ban));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Ware_Nhap_Hh_Ban_Chitiet_SelectAll_DateHang(object Id_Kho)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Nhap_Hh_Ban_Chitiet_SelectAll_DateHang", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kho", Id_Kho));
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            //oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhap_Hh_Ban", id_Nhap_Hh_Ban));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        #region nhap hang hoa
        /// <summary>
        ///  
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Nhap_Chitiet(object id_cuahang_ban, object ngay_Batdau, object ngay_Ketthuc, object id_Hanghoa_Ban, object id_Loai_Hanghoa_Ban)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rptware_Nhap_Chitiet", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_cuahang", id_cuahang_ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", ngay_Batdau));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", ngay_Ketthuc));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Ban", id_Hanghoa_Ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Loai_Hanghoa_Ban", id_Loai_Hanghoa_Ban));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string GetAll_Ware_Nhapxuat_Chitiet(object id_cuahang_ban, object ngay_Batdau, object ngay_Ketthuc, object id_Hanghoa_Ban, object id_Loai_Hanghoa_Ban)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rptware_Nhapxuat_Chitiet", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_cuahang", id_cuahang_ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", ngay_Batdau));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", ngay_Ketthuc));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Ban", id_Hanghoa_Ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Loai_Hanghoa_Ban", id_Loai_Hanghoa_Ban));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        ///  
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Nhap_Tonghop(object id_cuahang_ban, object ngay_Batdau, object ngay_Ketthuc, object id_Hanghoa_Ban, object id_Loai_Hanghoa_Ban)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rptware_Nhap_Tonghop", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_cuahang", id_cuahang_ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", ngay_Batdau));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", ngay_Ketthuc));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Ban", id_Hanghoa_Ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Loai_Hanghoa_Ban", id_Loai_Hanghoa_Ban));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        #endregion

        /// <summary>
        /// Insert đối tượng Ware_Nhap_Hh_Ban vào DB.
        /// </summary>
        /// <param name="ware_Nhap_Hh_Ban"></param>
        /// <returns></returns>
        public object Insert_Ware_Nhap_Hh_Ban(Ecm.Domain.Ware.Ware_Nhap_Hh_Ban ware_Nhap_Hh_Ban)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Nhap_Hh_Ban_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhap_Hh_Ban", System.Data.OleDb.OleDbType.BigInt));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", ware_Nhap_Hh_Ban.Id_Cuahang_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", ware_Nhap_Hh_Ban.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Nhanhang", ware_Nhap_Hh_Ban.Ngay_Nhanhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nguoi_Giaohang", ware_Nhap_Hh_Ban.Nguoi_Giaohang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Nhanhang", ware_Nhap_Hh_Ban.Id_Nhansu_Nhanhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", ware_Nhap_Hh_Ban.Ghichu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Xuat_Hh_Ban", ware_Nhap_Hh_Ban.Id_Xuat_Hh_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Ncc", ware_Nhap_Hh_Ban.Id_Ncc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Nhan", ware_Nhap_Hh_Ban.Id_Nhansu_Nhan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Is_Vat", ware_Nhap_Hh_Ban.Is_Vat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nguyenlieu", ware_Nhap_Hh_Ban.Nguyenlieu));
                oleDbCommand.Parameters["@Id_Nhap_Hh_Ban"].Direction = ParameterDirection.Output;
                oleDbCommand.ExecuteNonQuery();
                return oleDbCommand.Parameters["@Id_Nhap_Hh_Ban"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Insert_Ware_Nhap_Hh_Ban_FromXuatchuyen(Ecm.Domain.Ware.Ware_Nhap_Hh_Ban ware_Nhap_Hh_Ban)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Nhap_Hh_Ban_Insert_From_Xuatchuyen", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhap_Hh_Ban", System.Data.OleDb.OleDbType.BigInt));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", ware_Nhap_Hh_Ban.Id_Cuahang_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", ware_Nhap_Hh_Ban.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Nhanhang", ware_Nhap_Hh_Ban.Ngay_Nhanhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nguoi_Giaohang", ware_Nhap_Hh_Ban.Nguoi_Giaohang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Nhanhang", ware_Nhap_Hh_Ban.Id_Nhansu_Nhanhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", ware_Nhap_Hh_Ban.Ghichu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Xuat_Hh_Ban", ware_Nhap_Hh_Ban.Id_Xuat_Hh_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Ncc", ware_Nhap_Hh_Ban.Id_Ncc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Nhan", ware_Nhap_Hh_Ban.Id_Nhansu_Nhan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Is_Vat", ware_Nhap_Hh_Ban.Is_Vat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nguyenlieu", ware_Nhap_Hh_Ban.Nguyenlieu));
                oleDbCommand.Parameters["@Id_Nhap_Hh_Ban"].Direction = ParameterDirection.Output;
                oleDbCommand.ExecuteNonQuery();
                return oleDbCommand.Parameters["@Id_Nhap_Hh_Ban"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update đối tượng Ware_Nhap_Hh_Ban vào DB.
        /// </summary>
        /// <param name="ware_Nhap_Hh_Ban"></param>
        /// <returns></returns>
        public object Update_Ware_Nhap_Hh_Ban(Ecm.Domain.Ware.Ware_Nhap_Hh_Ban ware_Nhap_Hh_Ban)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Nhap_Hh_Ban_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhap_Hh_Ban", ware_Nhap_Hh_Ban.Id_Nhap_Hh_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", ware_Nhap_Hh_Ban.Id_Cuahang_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", ware_Nhap_Hh_Ban.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Nhanhang", ware_Nhap_Hh_Ban.Ngay_Nhanhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nguoi_Giaohang", ware_Nhap_Hh_Ban.Nguoi_Giaohang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Nhanhang", ware_Nhap_Hh_Ban.Id_Nhansu_Nhanhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", ware_Nhap_Hh_Ban.Ghichu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Ncc", ware_Nhap_Hh_Ban.Id_Ncc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Nhan", ware_Nhap_Hh_Ban.Id_Nhansu_Nhan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Is_Vat", ware_Nhap_Hh_Ban.Is_Vat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nguyenlieu", ware_Nhap_Hh_Ban.Nguyenlieu));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete đối tượng Ware_Nhap_Hh_Ban vào DB.
        /// </summary>
        /// <param name="ware_Nhap_Hh_Ban"></param>
        /// <returns></returns>
        public object Delete_Ware_Nhap_Hh_Ban(Ecm.Domain.Ware.Ware_Nhap_Hh_Ban ware_Nhap_Hh_Ban)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Nhap_Hh_Ban_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhap_Hh_Ban", ware_Nhap_Hh_Ban.Id_Nhap_Hh_Ban));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update một Collection Ware_Nhap_Hh_Ban_Chitiet vào DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Ware_Nhap_Hh_Ban_Chitiet_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Nhap_Hh_Ban_Chitiet", _SqlConnection);
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

        public bool Ware_Nhap_Hh_Ban_CheckXuat_Chuyen()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("ware_nhap_hh_ban_checkXuat_Chuyen", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@valid", System.Data.OleDb.OleDbType.Boolean));
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters["@valid"].Direction = ParameterDirection.Output;
            oleDbCommand.ExecuteNonQuery();
            bool valid = false;
            bool.TryParse("" + oleDbCommand.Parameters["@valid"].Value, out valid);
            return valid;
        }

        #endregion
   
    }
}
