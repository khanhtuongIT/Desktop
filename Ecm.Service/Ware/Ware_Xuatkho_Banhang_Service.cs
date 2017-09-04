using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Ware
{
    public class Ware_Xuatkho_Banhang_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Ware_Xuatkho_Banhang_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService

        /// <summary>
        /// Trả về một dataset Ware_Xuatkho_Banhang by Id_Cuahang_Ban
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Xuatkho_Banhang_ByCuahang(object Id_Cuahang_Ban)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Xuatkho_Banhang_SelectByCuahang", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Trả về một dataset Ware_Xuatkho_Banhang by Id_Cuahang_Ban && Current date (if Ngay_Chungtu = null --> Ngay_Chungtu = currentdate)
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Xuatkho_Banhang_ByCuahang_ByDate(object Id_Cuahang_Ban, object Ngay_Chungtu)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Xuatkho_Banhang_SelectByCuahang_ByDate", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", Ngay_Chungtu));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Ware_Doituong_SelectByCuahang_ByDate(object Id_Cuahang_Ban, object Ngay_Chungtu, object Id_Dieuxe)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Doituong_SelectByCuahang_ByDate", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", Ngay_Chungtu));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Dieuxe", Id_Dieuxe));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Ware_Xuatkho_Banhang_ById_Dieuxe(object Id_Dieuxe)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Xuatkho_Banhang_ById_Dieuxe", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Dieuxe", Id_Dieuxe));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Get_All_Ware_Xuatkho_Banhang_ByCuahang_ByKhachhang(object Id_Khachhang, object Ngay_Chungtu, object Id_Cuahang_Ban)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Xuatkho_Banhang_SelectByCuahang_ByKhachhang", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", Id_Khachhang));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", Ngay_Chungtu));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// tra ve nhung phieu cuat kho co thue vat
        /// </summary>
        /// <param name="ngay_Batdau"></param>
        /// <param name="ngay_Ketthuc"></param>
        /// <returns></returns>
        public string Get_RptWare_Tonghop_Hoadon_Banhang_Thue(object ngay_Batdau, object ngay_Ketthuc)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("rptWare_Tonghop_Hoadon_Banhang_Thue", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", ngay_Batdau));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", ngay_Ketthuc));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Trả về một dataset Ware_Xuatkho_Banhang
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Xuatkho_Banhang()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Xuatkho_Banhang_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Ware_Xuatkho_Banhang_Chitiet_SelectBy_Sochungtu(object Sochungtu)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Xuatkho_Banhang_Chitiet_SelectBy_Sochungtu", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", Sochungtu));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Get_All_Ware_Xuatkho_Banhang_ById(object Id_Xuatkho_Banhang)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Xuatkho_Banhang_SelectBy_Id", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Xuatkho_Banhang", Id_Xuatkho_Banhang));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Ware_Xuatkho_Banhang_SelectBy_Sochungtu(object Sochungtu)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Xuatkho_Banhang_SelectBy_Sochungtu", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", Sochungtu));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Get_All_Ware_Xuatkho_Banhang_ById_Khachhang(object id_khachhang)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Xuatkho_Banhang_SelectBy_Id_Khachhang", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_khachhang", id_khachhang));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Get_All_Ware_Xuatkho_Banhang_Chitiet_ByHdbanhang_Sochungtu(object Sochungtu)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Xuatkho_Banhang_Chitiet_SelectBySochungtu", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", Sochungtu));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Trả về một dataset Ware_Xuakho_Banhang_Chitiet by Id_Xuatkho_Banhang
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Xuatkho_Banhang_Chitiet_By_Id_Xuatkho_Banhang(object Id_Xuatkho_Banhang)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Xuatkho_Banhang_Chitiet_SelectBy_Id_Xuatkho_Banhang", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Xuatkho_Banhang", Id_Xuatkho_Banhang));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Insert đối tượng Ware_Xuatkho_Banhang vào DB.
        /// </summary>
        /// <param name="ware_xuatkho_banhang"></param>
        /// <returns></returns>
        public object Insert_Ware_Xuatkho_Banhang(Ecm.Domain.Ware.Ware_Xuatkho_Banhang ware_xuatkho_banhang)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Xuatkho_Banhang_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Xuatkho_Banhang", ware_xuatkho_banhang.Id_Xuatkho_Banhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", ware_xuatkho_banhang.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", ware_xuatkho_banhang.Ngay_Chungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Thanhtoan", ware_xuatkho_banhang.Ngay_Thanhtoan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachang", ware_xuatkho_banhang.Id_Khachhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Bh", ware_xuatkho_banhang.Id_Nhansu_Bh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", ware_xuatkho_banhang.Id_Cuahang_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien", ware_xuatkho_banhang.Sotien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Per_Vat", ware_xuatkho_banhang.Per_Vat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Vat", ware_xuatkho_banhang.Sotien_Vat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Per_Hoadon", ware_xuatkho_banhang.Per_Hoadon));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nguoinhan", ware_xuatkho_banhang.Nguoinhan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Per_Chietkhau", ware_xuatkho_banhang.Per_Chietkhau));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thanhtien_Chietkhau", ware_xuatkho_banhang.Thanhtien_Chietkhau));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hdbanhang", ware_xuatkho_banhang.Id_Hdbanhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu_Edit", ware_xuatkho_banhang.Ghichu_Edit));
                oleDbCommand.Parameters["@Id_Xuatkho_Banhang"].Direction = ParameterDirection.Output;
                oleDbCommand.ExecuteNonQuery();

                return oleDbCommand.Parameters["@Id_Xuatkho_Banhang"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update đối tượng ware_xuatkho_banhang vào DB.
        /// </summary>
        /// <param name="ware_xuatkho_banhang"></param>
        /// <returns></returns>
        public object Update_Ware_Xuatkho_Banhang(Ecm.Domain.Ware.Ware_Xuatkho_Banhang ware_xuatkho_banhang)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Xuatkho_Banhang_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Xuatkho_Banhang", ware_xuatkho_banhang.Id_Xuatkho_Banhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", ware_xuatkho_banhang.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", ware_xuatkho_banhang.Ngay_Chungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Thanhtoan", ware_xuatkho_banhang.Ngay_Thanhtoan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", ware_xuatkho_banhang.Id_Khachhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Bh", ware_xuatkho_banhang.Id_Nhansu_Bh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", ware_xuatkho_banhang.Id_Cuahang_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien", ware_xuatkho_banhang.Sotien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Per_Vat", ware_xuatkho_banhang.Per_Vat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Vat", ware_xuatkho_banhang.Sotien_Vat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Per_Hoadon", ware_xuatkho_banhang.Per_Hoadon));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Edit", ware_xuatkho_banhang.Id_Nhansu_Edit));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu_Edit", ware_xuatkho_banhang.Ghichu_Edit));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nguoinhan", ware_xuatkho_banhang.Nguoinhan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Per_Chietkhau", ware_xuatkho_banhang.Per_Chietkhau));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thanhtien_Chietkhau", ware_xuatkho_banhang.Thanhtien_Chietkhau));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Ware_Xuatkho_Banhang_Update_Print(Ecm.Domain.Ware.Ware_Xuatkho_Banhang ware_xuatkho_banhang)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Xuatkho_Banhang_Update_Print", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Xuatkho_Banhang", ware_xuatkho_banhang.Id_Xuatkho_Banhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Edit", ware_xuatkho_banhang.Id_Nhansu_Edit));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu_Edit", ware_xuatkho_banhang.Ghichu_Edit));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nguoinhan", ware_xuatkho_banhang.Nguoinhan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien", ware_xuatkho_banhang.Sotien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", ware_xuatkho_banhang.Id_Khachhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", ware_xuatkho_banhang.Id_Cuahang_Ban));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Ware_Xuatkho_Banhang_Chitiet_UpdateSocai(object Id_Xuatkho_Banhang)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Xuatkho_Banhang_Chitiet_UpdateSocai", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Xuatkho_Banhang", Id_Xuatkho_Banhang));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Xóa ware_xuatkho_banhang & ware_xuatkho_banhang_chitiet
        /// </summary>
        /// <param name="Id_Xuatkho_Banhang"></param>
        /// <returns></returns>
        public object Delete_Ware_Xuatkho_Banhang(object Id_Xuatkho_Banhang)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Xuatkho_Banhang_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Xuatkho_Banhang", Id_Xuatkho_Banhang));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update một Collection ware_xuatkho_banhang vào DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Ware_Xuatkho_Banhang_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from ware_xuatkho_banhang", _SqlConnection);
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

        /// <summary>
        /// Update một Collection ware_xuatkho_banhang_Chitiet vào DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Ware_Xuatkho_Banhang_Chitiet_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from ware_xuatkho_banhang_Chitiet", _SqlConnection);
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

        public object Ware_Xuatkho_Banhang_Update_Doc(object Id_Xuatkho_Banhang, object Doc_Process_Status, object Id_Nhansu_Lap)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Xuatkho_Banhang_Update_Doc", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Xuatkho_Banhang", Id_Xuatkho_Banhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Doc_Process_Status", Doc_Process_Status));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Lap", Id_Nhansu_Lap));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Get_All_Ware_Congno_Phaithu(object Thang, object Id_Khachhang, object Id_Nhansu_Bh)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Congno_Phaithu", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thang", Thang));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", Id_Khachhang));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Bh", Id_Nhansu_Bh));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }


        #endregion

    }
}
