using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Ware
{
    public class WareGen_Hdbanhang_Service
    {
         #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public WareGen_Hdbanhang_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService

        #region hh ban
        public string Get_All_WareGen_Hdbanhang_Novat_Hhban()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("WareGen_Hdbanhang_Novat_SelectAll_Hhban", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }
        public string Get_All_WareGen_Hdbanhang_Novat_Hhban_ByCuahang(object Id_Cuahang_Ban)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("WareGen_Hdbanhang_Novat_SelectAll_Hhban", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban",Id_Cuahang_Ban));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Get_All_WareGen_Hdbanhang_Novat_Hhban_ByCuahang(object Id_Cuahang_Ban, object Ngay_Chungtu)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("WareGen_Hdbanhang_Novat_SelectAll_Hhban", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", Ngay_Chungtu));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Get_All_WareGen_Hdbanhang_Novat_Hhban_Cash_ByCuahang(object Id_Cuahang_Ban)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("WareGen_Hdbanhang_Novat_SelectAll_Hhban_Cash", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban",Id_Cuahang_Ban));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }        
        
        public string Get_All_WareGen_Hdbanhang_Hhban()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("WareGen_Hdbanhang_SelectAll_Hhban", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Get_All_WareGen_Hdbanhang_ByCuahang(object Id_Cuahang_Ban)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("WareGen_Hdbanhang_SelectByCuahang", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }
        #endregion

        #region hh mua
        public string Get_All_WareGen_Hdbanhang_Novat_Hhmua()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("WareGen_Hdbanhang_Novat_SelectAll_Hhmua", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Get_All_WareGen_Hdbanhang_Novat_Hhmua_ByKhohh(object Id_Kho_Hanghoa_Mua)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("WareGen_Hdbanhang_Novat_SelectAll_Hhmua", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kho_Hanghoa_Mua", Id_Kho_Hanghoa_Mua));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Get_All_WareGen_Hdbanhang_Novat_Hhmua_ByKhohh(object Id_Kho_Hanghoa_Mua, object Ngay_Chungtu)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("WareGen_Hdbanhang_Novat_SelectAll_Hhmua", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kho_Hanghoa_Mua", Id_Kho_Hanghoa_Mua));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", Ngay_Chungtu));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }
        public string Get_All_WareGen_Hdbanhang_Hhmua()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("WareGen_Hdbanhang_SelectAll_Hhmua", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Get_All_WareGen_Hdbanhang_ByKhoHanghoa(object Id_Kho_Hanghoa_Mua)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("WareGen_Hdbanhang_SelectByKhoHanghoa", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kho_Hanghoa_Mua", Id_Kho_Hanghoa_Mua));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }
        #endregion

        /// <summary>
        /// Trả về một dataset Hdbanhang
        /// </summary>
        /// <returns></returns>
        public string Get_All_WareGen_Hdbanhang()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("WareGen_Hdbanhang_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Trả về một dataset Hdbanhang
        /// </summary>
        /// <returns></returns>
        public string Get_All_WareGen_Hdbanhang(object Ngay_Batdau, object Ngay_Ketthuc, object Ma_Kho_Hanghoa)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("WareGen_Hdbanhang_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", Ngay_Batdau));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", Ngay_Ketthuc));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Kho_Hanghoa", Ma_Kho_Hanghoa));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Trả về một dataset Hdbanhang by Barcode
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Hdbanhang_By_Barcode(object barCode)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Hanghoa_Mua_By_Barcode", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Barcode_Txt", barCode));


            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Get_All_WareGen_Quydoi_Hhmua_Fr_Hhban(object Ngay_Batdau, object Ngay_Ketthuc)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("WareGen_Quydoi_Hhmua_Fr_Hhban", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", Ngay_Batdau));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", Ngay_Ketthuc));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Trả về một dataset WareGen_Hdbanhang_Chitiet_SelectByFK
        /// </summary>
        /// <returns></returns>
        public string Get_All_WareGen_Hdbanhang_Chitiet_ByHdbanhang(object Id_Hdbanhang)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("WareGen_Hdbanhang_Chitiet_SelectByFK", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hdbanhang", Id_Hdbanhang));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }
        
        /// <summary>
        /// Trả về một dataset WareGen_Hdbanhang_Chitiet_SelectByFK
        /// </summary>
        /// <returns></returns>
        public string Get_All_WareGen_Hdbanhang_Chitiet_Log_ByHdbanhang(object Id_Hdbanhang)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("WareGen_Hdbanhang_Chitiet_Log_SelectByFK", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hdbanhang", Id_Hdbanhang));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Insert đối tượng WareGen_Hdbanhang vào DB.
        /// </summary>
        /// <param name="ware_Hdbanhang"></param>
        /// <returns></returns>
        public object Insert_WareGen_Hdbanhang(Ecm.Domain.Ware.Ware_Hdbanhang ware_Hdbanhang)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("WareGen_Hdbanhang_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hdbanhang",           ware_Hdbanhang.Id_Hdbanhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu",              ware_Hdbanhang.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu",           ware_Hdbanhang.Ngay_Chungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Thanhtoan",         ware_Hdbanhang.Ngay_Thanhtoan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachang",            ware_Hdbanhang.Id_Khachang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Diachi",                 ware_Hdbanhang.Diachi));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Maso_Thue",              ware_Hdbanhang.Maso_Thue));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Hoten_Nguoimua",         ware_Hdbanhang.Hoten_Nguoimua));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dienthoai",              ware_Hdbanhang.Dienthoai));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Bh",           ware_Hdbanhang.Id_Nhansu_Bh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban",         ware_Hdbanhang.Id_Cuahang_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kho_Hanghoa_Mua",     ware_Hdbanhang.Ghichu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien",                 ware_Hdbanhang.Sotien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Per_Vat",                ware_Hdbanhang.Per_Vat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Vat",             ware_Hdbanhang.Sotien_Vat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Phuongthuc_Thanhtoan",   ware_Hdbanhang.Phuongthuc_Thanhtoan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@So_Seri",                ware_Hdbanhang.So_Seri));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@NoVAT",                  ware_Hdbanhang.NoVAT));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Per_Hoadon",             ware_Hdbanhang.Per_Hoadon));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Vip_Member_Card",     ware_Hdbanhang.Id_Vip_Member_Card));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Km",           ware_Hdbanhang.Id_Nhansu_Km));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Gen_fr_hhsx",            ware_Hdbanhang.Gen_Fr_Hhsx));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Donmuahang",          ware_Hdbanhang.Id_Donmuahang));

                oleDbCommand.Parameters["@Id_Hdbanhang"].Direction = ParameterDirection.Output;
                oleDbCommand.ExecuteNonQuery();

                return oleDbCommand.Parameters["@Id_Hdbanhang"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object Insert_WareGen_Hdbanhang_NoVAT(Ecm.Domain.Ware.Ware_Hdbanhang ware_Hdbanhang)
        {
            ware_Hdbanhang.NoVAT = 1;
            return this.Insert_WareGen_Hdbanhang(ware_Hdbanhang);
        }

        /// <summary>
        /// Update đối tượng WareGen_Hdbanhang vào DB.
        /// </summary>
        /// <param name="ware_Hdbanhang"></param>
        /// <returns></returns>
        public object Update_WareGen_Hdbanhang(Ecm.Domain.Ware.Ware_Hdbanhang ware_Hdbanhang)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("WareGen_Hdbanhang_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hdbanhang",       ware_Hdbanhang.Id_Hdbanhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu",          ware_Hdbanhang.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu",       ware_Hdbanhang.Ngay_Chungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Thanhtoan",     ware_Hdbanhang.Ngay_Thanhtoan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachang",        ware_Hdbanhang.Id_Khachang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Diachi",             ware_Hdbanhang.Diachi));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Maso_Thue",          ware_Hdbanhang.Maso_Thue));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Hoten_Nguoimua",     ware_Hdbanhang.Hoten_Nguoimua));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dienthoai",          ware_Hdbanhang.Dienthoai));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Bh",       ware_Hdbanhang.Id_Nhansu_Bh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban",     ware_Hdbanhang.Id_Cuahang_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kho_Hanghoa_Mua", ware_Hdbanhang.Ghichu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien",             ware_Hdbanhang.Sotien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Per_Vat",            ware_Hdbanhang.Per_Vat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Vat",         ware_Hdbanhang.Sotien_Vat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Phuongthuc_Thanhtoan", ware_Hdbanhang.Phuongthuc_Thanhtoan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@So_Seri",            ware_Hdbanhang.So_Seri));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@NoVAT",              ware_Hdbanhang.NoVAT));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Per_Hoadon",         ware_Hdbanhang.Per_Hoadon));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Vip_Member_Card", ware_Hdbanhang.Id_Vip_Member_Card));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Casher",   ware_Hdbanhang.Id_Nhansu_Casher));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Mark_Deleted",       ware_Hdbanhang.Mark_Deleted));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Edit",     ware_Hdbanhang.Id_Nhansu_Edit));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Km",       ware_Hdbanhang.Id_Nhansu_Km));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu_Edit", ware_Hdbanhang.Ghichu_Edit));

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
        /// Delete đối tượng WareGen_Hdbanhang vào DB.
        /// </summary>
        /// <param name="ware_Hdbanhang"></param>
        /// <returns></returns>
        public object Delete_WareGen_Hdbanhang(Ecm.Domain.Ware.Ware_Hdbanhang ware_Hdbanhang)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("WareGen_Hdbanhang_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hdbanhang", ware_Hdbanhang.Id_Hdbanhang));

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
        /// Delete đối tượng WareGen_Hdbanhang vào DB.
        /// </summary>
        /// <param name="ware_Hdbanhang"></param>
        /// <returns></returns>
        public object Delete_WareGen_Hdbanhang_ByDonmuahang(Ecm.Domain.Ware.Ware_Donmuahang ware_Donmuahang)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("WareGen_Hdbanhang_Delete_ByDonmuahang", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Donmuahang", ware_Donmuahang.Id_Donmuahang));

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
        /// Update một Collection WareGen_Hdbanhang vào DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_WareGen_Hdbanhang_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from WareGen_Hdbanhang", _SqlConnection);
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
        /// Update một Collection WareGen_Hdbanhang_Chitiet vào DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_WareGen_Hdbanhang_Chitiet_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from WareGen_Hdbanhang_Chitiet", _SqlConnection);
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
        /// Update một Collection WareGen_Hdbanhang_Chitiet vào DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_WareGen_Hdbanhang_Chitiet_Log_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from WareGen_Hdbanhang_Chitiet_Log", _SqlConnection);
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
        /// Nhập xuất tồn hàng hóa bán
        /// </summary>
        /// <param name="Ngay_Batdau"></param>
        /// <param name="Ngay_Ketthuc"></param>
        /// <param name="Id_Cuahang_Ban"></param>
        /// <returns></returns>
        public string Rptware_Nxt_Hhban(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Cuahang_Ban)
        {
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rptware_Nxt_Hhban", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", Ngay_Batdau));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", Ngay_Ketthuc));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            DataSet dsCollection = new DataSet();
            oleDbDataAdapter.Fill(dsCollection, "GridTable");

                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }
 
        /// <summary>
        /// Nhập xuất tồn hàng hóa bán
        /// </summary>
        /// <param name="Ngay_Batdau"></param>
        /// <param name="Ngay_Ketthuc"></param>
        /// <param name="Id_Cuahang_Ban"></param>
        /// <returns></returns>
        public string Rptware_Nxt_Hhban_ByKhsx(object Ngay_Baocao, object Id_Cuahang_Ban)
        {
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rptware_Nxt_Hhban_ByKhsx", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Baocao", Ngay_Baocao));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            DataSet dsCollection = new DataSet();
            oleDbDataAdapter.Fill(dsCollection, "GridTable");

                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }        


        #endregion
    }
}
