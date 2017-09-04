using System;
using System.Data;
using System.Collections.Generic;

namespace Ecm.Service.Ware
{
    public class Ware_Hdbanhang_Service
    {
        private System.Data.OleDb.OleDbConnection _SqlConnection;

        public Ware_Hdbanhang_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            _SqlConnection = sqlConnection;
        }

        public bool Ware_Hdbanhang_Check_Hoadon_IsLast(object Id_Hdbanhang)
        {
            //var dsCollection ;
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Check_Hoadon_IsLast", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hdbanhang", Id_Hdbanhang));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@valid", System.Data.OleDb.OleDbType.Boolean));
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters["@valid"].Direction = ParameterDirection.Output;
            oleDbCommand.ExecuteNonQuery();
            var valid = false;
            bool.TryParse(string.Empty + oleDbCommand.Parameters["@valid"].Value, out valid);
            return valid;
        }

        public Boolean Ware_Hdbanhang_Check_Hoadon_Congno_ByDate(object Id_Hdbanhang, object Date)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Check_Hoadon_Congno_ByDate", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hdbanhang", Id_Hdbanhang));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Date", Date));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@value", System.Data.OleDb.OleDbType.Boolean));
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters["@value"].Direction = ParameterDirection.Output;
            oleDbCommand.ExecuteNonQuery();
            Boolean valid = new Boolean();
            Boolean.TryParse("" + oleDbCommand.Parameters["@value"].Value, out valid);
            return valid;
        }


        public Boolean Ware_Hdbanhang_Check_Hoadon_Congno10(object Id_Hdbanhang)
        {
           // var dsCollection ;
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Check_Hoadon_Congno10", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hdbanhang", Id_Hdbanhang));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@value", System.Data.OleDb.OleDbType.Boolean));
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters["@value"].Direction = ParameterDirection.Output;
            oleDbCommand.ExecuteNonQuery();
            var valid = new Boolean();
            Boolean.TryParse(string.Empty + oleDbCommand.Parameters["@value"].Value, out valid);
            return valid;
        }

        public string Get_All_Ware_Hdbanhang_Novat_Hhban()
        {
            var dsCollection = new DataSet();
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Novat_SelectAll_Hhban", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }
        public string Get_All_Ware_Hdbanhang_Novat_Hhban_ByCuahang(object Id_Cuahang_Ban)
        {
            var dsCollection = new DataSet();
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Novat_SelectAll_Hhban", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));

            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Get_All_Ware_Hdbanhang_Novat_Hhban_ByCuahang(object Id_Cuahang_Ban, object Ngay_Chungtu)
        {
            var dsCollection = new DataSet();
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Novat_SelectAll_Hhban", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", Ngay_Chungtu));

            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Get_All_Ware_Hdbanhang_Novat_Hhban_ByCuahang(object Id_Cuahang_Ban, object Ngay_Chungtu, object Id_Nhansu_Lap)
        {
            var dsCollection = new DataSet();
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Novat_SelectAll_Hhban", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", Ngay_Chungtu));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Lap", Id_Nhansu_Lap));

            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Get_All_Ware_Hdbanhang_Novat_Hhban_ByCuahang_Khachhang(object Id_Cuahang_Ban, object Ngay_Chungtu, object Id_Nhansu_Lap, object Id_Khachhang)
        {
            var dsCollection = new DataSet();
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Novat_SelectAll_Hhban", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", Ngay_Chungtu));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Lap", Id_Nhansu_Lap));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", Id_Khachhang));
            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Get_All_Ware_Hdbanhang_Novat_Hhban_Edit(object Id_Cuahang_Ban, object Ngay_Chungtu, object Id_Nhansu_Lap)
        {
            var dsCollection = new DataSet();
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Novat_SelectAll_Hhban_Edit", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", Ngay_Chungtu));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Lap", Id_Nhansu_Lap));

            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Get_All_Ware_Hdbanhang_Novat_Hhban_ByCuahang_IdKhachhang(object Id_Cuahang_Ban, object Ngay_Chungtu, object Id_Khachhang)
        {
            var dsCollection = new DataSet();
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Novat_SelectAll_Hhban_Id_Khachhang", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", Ngay_Chungtu));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", Id_Khachhang));

            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Get_All_Ware_Hdbanhang_Novat_Hhban_Cash_ByCuahang(object Id_Cuahang_Ban)
        {
            var dsCollection = new DataSet();
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Novat_SelectAll_Hhban_Cash", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));

            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Get_All_Ware_Hdbanhang_Hhban()
        {
            var dsCollection = new DataSet();
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_SelectAll_Hhban", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Get_All_Ware_Hdbanhang_ByCuahang(object Id_Cuahang_Ban)
        {
            var dsCollection = new DataSet();
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_SelectByCuahang", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));

            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Get_All_Ware_Hdbanhang_Novat_Hhmua()
        {
            var dsCollection = new DataSet();
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Novat_SelectAll_Hhmua", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Get_All_Ware_Hdbanhang_Novat_Hhmua_ByKhohh(object Id_Kho_Hanghoa_Mua)
        {
            var dsCollection = new DataSet();
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Novat_SelectAll_Hhmua", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kho_Hanghoa_Mua", Id_Kho_Hanghoa_Mua));

            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Get_All_Ware_Hdbanhang_Novat_Hhmua_ByKhohh(object Id_Kho_Hanghoa_Mua, object Ngay_Chungtu)
        {
            var dsCollection = new DataSet();
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Novat_SelectAll_Hhmua", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kho_Hanghoa_Mua", Id_Kho_Hanghoa_Mua));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", Ngay_Chungtu));

            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }
        public string Get_All_Ware_Hdbanhang_Hhmua()
        {
            var dsCollection = new DataSet();
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_SelectAll_Hhmua", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Get_All_Ware_Hdbanhang_ByKhoHanghoa(object Id_Kho_Hanghoa_Mua)
        {
            var dsCollection = new DataSet();
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_SelectByKhoHanghoa", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kho_Hanghoa_Mua", Id_Kho_Hanghoa_Mua));

            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public object Ware_Hdbanhang_Update_Duyet_Mobile(object Id_Hdbanhang, object Cap_Duyet, object Ghichu_Edit)
        {
            try
            {
                var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Update_Mobile", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hdbanhang", Id_Hdbanhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Cap_Duyet", Cap_Duyet));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu_Edit", Ghichu_Edit));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Ware_Hdbanhang_Select_4Kiemduyet_Mobile(object Ngay_Chungtu, object Cap_Duyet)
        {
            var dsCollection = new DataSet();
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Select_4Kiemduyet_Mobile", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", Ngay_Chungtu));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Cap_Duyet", Cap_Duyet));
            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Get_All_Ware_Hdbanhang_Xuatkho()
        {
            var dsCollection = new DataSet();
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Xuakho_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        /// <summary>
        /// Trả về một dataset Hdbanhang
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Hdbanhang()
        {
            var dsCollection = new DataSet();
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Get_All_Ware_Hdbanhang_Chitiet_By_Hdbanhang(object Id_Hdbanhang)
        {
            var dsCollection = new DataSet();
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_SelectBy_Id_Hdbanhang", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hdbanhang", Id_Hdbanhang));

            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Get_All_Ware_Hdbanhang_ByDate(object ngay_Bd, object ngay_Kt, object id_cuahang_ban)
        {
            var dsCollection = new DataSet();
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_SelectByDate", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Bd", ngay_Bd));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Kt", ngay_Kt));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_cuahang_ban", id_cuahang_ban));

            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Get_All_Ware_Hdbanhang_ById_khachhang(object id_khachhang)
        {
            var dsCollection = new DataSet();
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_SelectBy_Id_Khachhang", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_khachhang", id_khachhang));

            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }


        /// <summary>
        /// Trả về một dataset Ware_Hdbanhang_Chitiet_SelectByFK
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Hdbanhang_Chitiet_ByHdbanhang_Sochungtu(object Sochungtu)
        {
            var dsCollection = new DataSet();
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Chitiet_SelectBySochungtu", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", Sochungtu));

            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        /// <summary>
        /// Trả về một dataset Ware_Hdbanhang_Chitiet_SelectByFK
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Hdbanhang_Chitiet_ByHdbanhang(object Id_Hdbanhang)
        {
            var dsCollection = new DataSet();
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Chitiet_SelectByFK", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hdbanhang", Id_Hdbanhang));

            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Get_All_Ware_Hdbanhang_Chitiet_ByHdbanhang_Mail(object Id_Hdbanhang)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Chitiet_SelectByFK_Mail", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hdbanhang", Id_Hdbanhang));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Get_All_Ware_Hdbanhang_Chitiet_Dudoan_Dathang(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Cuahang_Ban, object Id_Nhansu)
        {
            var dsCollection = new DataSet();
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Chitiet_Dudoan_Dathang", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", Ngay_Batdau));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", Ngay_Ketthuc));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Id_Nhansu));

            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        /// <summary>
        /// Trả về một dataset Ware_Hdbanhang_Chitiet_SelectByFK
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Hdbanhang_Chitiet_Log_ByHdbanhang(object Id_Hdbanhang)
        {
            var dsCollection = new DataSet();
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Chitiet_Log_SelectByFK", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hdbanhang", Id_Hdbanhang));

            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        /// <summary>
        /// Insert đối tượng Ware_Hdbanhang vào DB.
        /// </summary>
        /// <param name="ware_Hdbanhang"></param>
        /// <returns></returns>
        public object Insert_Ware_Hdbanhang(Ecm.Domain.Ware.Ware_Hdbanhang ware_Hdbanhang)
        {
            try
            {
                var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hdbanhang", ware_Hdbanhang.Id_Hdbanhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", ware_Hdbanhang.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", ware_Hdbanhang.Ngay_Chungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Thanhtoan", ware_Hdbanhang.Ngay_Thanhtoan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachang", ware_Hdbanhang.Id_Khachang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Diachi", ware_Hdbanhang.Diachi));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Maso_Thue", ware_Hdbanhang.Maso_Thue));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Hoten_Nguoimua", ware_Hdbanhang.Hoten_Nguoimua));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dienthoai", ware_Hdbanhang.Dienthoai));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Bh", ware_Hdbanhang.Id_Nhansu_Bh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", ware_Hdbanhang.Id_Cuahang_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", ware_Hdbanhang.Ghichu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien", ware_Hdbanhang.Sotien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Per_Vat", ware_Hdbanhang.Per_Vat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Vat", ware_Hdbanhang.Sotien_Vat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Phuongthuc_Thanhtoan", ware_Hdbanhang.Phuongthuc_Thanhtoan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@So_Seri", ware_Hdbanhang.So_Seri));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@NoVAT", ware_Hdbanhang.NoVAT));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Per_Hoadon", ware_Hdbanhang.Per_Hoadon));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Vip_Member_Card", ware_Hdbanhang.Id_Vip_Member_Card));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Km", ware_Hdbanhang.Id_Nhansu_Km));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tienmat", ware_Hdbanhang.Tienmat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Thutien", ware_Hdbanhang.Ngay_Thutien));
                oleDbCommand.Parameters["@Id_Hdbanhang"].Direction = ParameterDirection.Output;
                oleDbCommand.ExecuteNonQuery();
                return oleDbCommand.Parameters["@Id_Hdbanhang"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Insert_Ware_Hdbanhang_New(Ecm.Domain.Ware.Ware_Hdbanhang ware_Hdbanhang)
        {
            try
            {
                var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hdbanhang", ware_Hdbanhang.Id_Hdbanhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", ware_Hdbanhang.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", ware_Hdbanhang.Ngay_Chungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Thanhtoan", ware_Hdbanhang.Ngay_Thanhtoan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachang", ware_Hdbanhang.Id_Khachang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Diachi", ware_Hdbanhang.Diachi));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Maso_Thue", ware_Hdbanhang.Maso_Thue));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Hoten_Nguoimua", ware_Hdbanhang.Hoten_Nguoimua));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dienthoai", ware_Hdbanhang.Dienthoai));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Bh", ware_Hdbanhang.Id_Nhansu_Bh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", ware_Hdbanhang.Id_Cuahang_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", ware_Hdbanhang.Ghichu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien", ware_Hdbanhang.Sotien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Per_Vat", ware_Hdbanhang.Per_Vat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Vat", ware_Hdbanhang.Sotien_Vat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Phuongthuc_Thanhtoan", ware_Hdbanhang.Phuongthuc_Thanhtoan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@So_Seri", ware_Hdbanhang.So_Seri));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@NoVAT", ware_Hdbanhang.NoVAT));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Per_Hoadon", ware_Hdbanhang.Per_Hoadon));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Vip_Member_Card", ware_Hdbanhang.Id_Vip_Member_Card));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Km", ware_Hdbanhang.Id_Nhansu_Km));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tienmat", ware_Hdbanhang.Tienmat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Thutien", ware_Hdbanhang.Ngay_Thutien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tinh_Dinhluong", ware_Hdbanhang.Tinh_Dinhluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tinh_Chiphi", ware_Hdbanhang.Tinh_Chiphi));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chiphi_Vanchuyen", ware_Hdbanhang.Chiphi_Vanchuyen));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Congno", ware_Hdbanhang.Sotien_Congno));
                oleDbCommand.Parameters["@Id_Hdbanhang"].Direction = ParameterDirection.Output;
                oleDbCommand.ExecuteNonQuery();

                return oleDbCommand.Parameters["@Id_Hdbanhang"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Insert_Ware_Hdbanhang_Mobile(Dictionary<string, string> ware_Hdbanhang)
        {
            try
            {
                var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hdbanhang", ware_Hdbanhang["Id_Hdbanhang"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", ware_Hdbanhang["Sochungtu"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", ware_Hdbanhang["Ngay_Chungtu"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Thanhtoan", ware_Hdbanhang["Ngay_Thanhtoan"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachang", ware_Hdbanhang["Id_Khachang"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Diachi", ware_Hdbanhang["Diachi"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Maso_Thue", ware_Hdbanhang["Maso_Thue"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Hoten_Nguoimua", ware_Hdbanhang["Hoten_Nguoimua"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dienthoai", ware_Hdbanhang["Dienthoai"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Bh", ware_Hdbanhang["Id_Nhansu_Bh"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", ware_Hdbanhang["Id_Cuahang_Ban"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", ware_Hdbanhang["Ghichu"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien", ware_Hdbanhang["Sotien"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Per_Vat", ware_Hdbanhang["Per_Vat"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Vat", ware_Hdbanhang["Sotien_Vat"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Phuongthuc_Thanhtoan", ware_Hdbanhang["Phuongthuc_Thanhtoan"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@So_Seri", ware_Hdbanhang["So_Seri"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@NoVAT", ware_Hdbanhang["NoVAT"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Per_Hoadon", ware_Hdbanhang["Per_Hoadon"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Vip_Member_Card", ware_Hdbanhang["Id_Vip_Member_Card"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Km", ware_Hdbanhang["Id_Nhansu_Km"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tienmat", ware_Hdbanhang["Tienmat"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Thutien", ware_Hdbanhang["Ngay_Thutien"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tinh_Dinhluong", ware_Hdbanhang["Tinh_Dinhluong"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tinh_Chiphi", ware_Hdbanhang["Tinh_Chiphi"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chiphi_Vanchuyen", ware_Hdbanhang["Chiphi_Vanchuyen"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Congno", ware_Hdbanhang["Sotien_Congno"]));
                oleDbCommand.Parameters["@Id_Hdbanhang"].Direction = ParameterDirection.Output;
                oleDbCommand.ExecuteNonQuery();
                return oleDbCommand.Parameters["@Id_Hdbanhang"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Update_Ware_Hdbanhang_Mobile(Dictionary<string, string> ware_Hdbanhang)
        {
            try
            {
                var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hdbanhang", ware_Hdbanhang["Id_Hdbanhang"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", ware_Hdbanhang["Sochungtu"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", ware_Hdbanhang["Ngay_Chungtu"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Thanhtoan", ware_Hdbanhang["Ngay_Thanhtoan"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachang", ware_Hdbanhang["Id_Khachang"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Diachi", ware_Hdbanhang["Diachi"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Maso_Thue", ware_Hdbanhang["Maso_Thue"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Hoten_Nguoimua", ware_Hdbanhang["Hoten_Nguoimua"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dienthoai", ware_Hdbanhang["Dienthoai"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Bh", ware_Hdbanhang["Id_Nhansu_Bh"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", ware_Hdbanhang["Id_Cuahang_Ban"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", ware_Hdbanhang["Ghichu"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien", ware_Hdbanhang["Sotien"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Per_Vat", ware_Hdbanhang["Per_Vat"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Vat", ware_Hdbanhang["Sotien_Vat"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Phuongthuc_Thanhtoan", ware_Hdbanhang["Phuongthuc_Thanhtoan"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@So_Seri", ware_Hdbanhang["So_Seri"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@NoVAT", ware_Hdbanhang["NoVAT"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Per_Hoadon", ware_Hdbanhang["Per_Hoadon"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Vip_Member_Card", ware_Hdbanhang["Id_Vip_Member_Card"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Km", ware_Hdbanhang["Id_Nhansu_Km"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tienmat", ware_Hdbanhang["Tienmat"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Thutien", ware_Hdbanhang["Ngay_Thutien"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tinh_Dinhluong", ware_Hdbanhang["Tinh_Dinhluong"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tinh_Chiphi", ware_Hdbanhang["Tinh_Chiphi"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chiphi_Vanchuyen", ware_Hdbanhang["Chiphi_Vanchuyen"]));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Congno", ware_Hdbanhang["Sotien_Congno"]));
                oleDbCommand.Parameters["@Id_Hdbanhang"].Direction = ParameterDirection.Output;
                oleDbCommand.ExecuteNonQuery();
                return oleDbCommand.Parameters["@Id_Hdbanhang"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public object Insert_Ware_Hdbanhang_NoVAT(Ecm.Domain.Ware.Ware_Hdbanhang ware_Hdbanhang)
        {
            ware_Hdbanhang.NoVAT = 1;
            return Insert_Ware_Hdbanhang(ware_Hdbanhang);
        }

        /// <summary>
        /// Update đối tượng Ware_Hdbanhang vào DB.
        /// </summary>
        /// <param name="ware_Hdbanhang"></param>
        /// <returns></returns>
        public object Update_Ware_Hdbanhang(Ecm.Domain.Ware.Ware_Hdbanhang ware_Hdbanhang)
        {
            try
            {
                var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hdbanhang", ware_Hdbanhang.Id_Hdbanhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", ware_Hdbanhang.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", ware_Hdbanhang.Ngay_Chungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Thanhtoan", ware_Hdbanhang.Ngay_Thanhtoan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachang", ware_Hdbanhang.Id_Khachang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Diachi", ware_Hdbanhang.Diachi));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Maso_Thue", ware_Hdbanhang.Maso_Thue));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Hoten_Nguoimua", ware_Hdbanhang.Hoten_Nguoimua));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dienthoai", ware_Hdbanhang.Dienthoai));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Bh", ware_Hdbanhang.Id_Nhansu_Bh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", ware_Hdbanhang.Id_Cuahang_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", ware_Hdbanhang.Ghichu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien", ware_Hdbanhang.Sotien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Per_Vat", ware_Hdbanhang.Per_Vat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Vat", ware_Hdbanhang.Sotien_Vat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Phuongthuc_Thanhtoan", ware_Hdbanhang.Phuongthuc_Thanhtoan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@So_Seri", ware_Hdbanhang.So_Seri));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@NoVAT", ware_Hdbanhang.NoVAT));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Per_Hoadon", ware_Hdbanhang.Per_Hoadon));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Vip_Member_Card", ware_Hdbanhang.Id_Vip_Member_Card));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Casher", ware_Hdbanhang.Id_Nhansu_Casher));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Mark_Deleted", ware_Hdbanhang.Mark_Deleted));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Edit", ware_Hdbanhang.Id_Nhansu_Edit));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Km", ware_Hdbanhang.Id_Nhansu_Km));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu_Edit", ware_Hdbanhang.Ghichu_Edit));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Donvi_Muahang", ware_Hdbanhang.Donvi_muahang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Doc_Process_Status", ware_Hdbanhang.Doc_Process_Status));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tienmat", ware_Hdbanhang.Tienmat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Thutien", ware_Hdbanhang.Ngay_Thutien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Congno", ware_Hdbanhang.Congno));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tinh_Dinhluong", ware_Hdbanhang.Tinh_Dinhluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tinh_Chiphi", ware_Hdbanhang.Tinh_Chiphi));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chiphi_Vanchuyen", ware_Hdbanhang.Chiphi_Vanchuyen));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Congno", ware_Hdbanhang.Sotien_Congno));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Update_Ware_Hdbanhang_New(Ecm.Domain.Ware.Ware_Hdbanhang ware_Hdbanhang)
        {
            try
            {
                var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hdbanhang", ware_Hdbanhang.Id_Hdbanhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", ware_Hdbanhang.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", ware_Hdbanhang.Ngay_Chungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Thanhtoan", ware_Hdbanhang.Ngay_Thanhtoan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachang", ware_Hdbanhang.Id_Khachang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Diachi", ware_Hdbanhang.Diachi));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Maso_Thue", ware_Hdbanhang.Maso_Thue));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Hoten_Nguoimua", ware_Hdbanhang.Hoten_Nguoimua));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dienthoai", ware_Hdbanhang.Dienthoai));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Bh", ware_Hdbanhang.Id_Nhansu_Bh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", ware_Hdbanhang.Id_Cuahang_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", ware_Hdbanhang.Ghichu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien", ware_Hdbanhang.Sotien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Per_Vat", ware_Hdbanhang.Per_Vat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Vat", ware_Hdbanhang.Sotien_Vat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Phuongthuc_Thanhtoan", ware_Hdbanhang.Phuongthuc_Thanhtoan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@So_Seri", ware_Hdbanhang.So_Seri));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@NoVAT", ware_Hdbanhang.NoVAT));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Per_Hoadon", ware_Hdbanhang.Per_Hoadon));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Vip_Member_Card", ware_Hdbanhang.Id_Vip_Member_Card));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Casher", ware_Hdbanhang.Id_Nhansu_Casher));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Mark_Deleted", ware_Hdbanhang.Mark_Deleted));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Edit", ware_Hdbanhang.Id_Nhansu_Edit));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Km", ware_Hdbanhang.Id_Nhansu_Km));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu_Edit", ware_Hdbanhang.Ghichu_Edit));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Donvi_Muahang", ware_Hdbanhang.Donvi_muahang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Doc_Process_Status", ware_Hdbanhang.Doc_Process_Status));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tienmat", ware_Hdbanhang.Tienmat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Thutien", ware_Hdbanhang.Ngay_Thutien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Congno", ware_Hdbanhang.Congno));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tinh_Dinhluong", ware_Hdbanhang.Tinh_Dinhluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tinh_Chiphi", ware_Hdbanhang.Tinh_Chiphi));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chiphi_Vanchuyen", ware_Hdbanhang.Chiphi_Vanchuyen));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Congno", ware_Hdbanhang.Sotien_Congno));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public object Ware_Hdbanhang_Update_Doc(Ecm.Domain.Ware.Ware_Hdbanhang ware_Hdbanhang)
        {
            try
            {
                var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Update_Doc", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hdbanhang", ware_Hdbanhang.Id_Hdbanhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Doc_Process_Status", ware_Hdbanhang.Doc_Process_Status));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Congno", ware_Hdbanhang.Congno));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Delete đối tượng Ware_Hdbanhang vào DB.
        /// </summary>
        /// <param name="ware_Hdbanhang"></param>
        /// <returns></returns>
        public object Delete_Ware_Hdbanhang(Ecm.Domain.Ware.Ware_Hdbanhang ware_Hdbanhang)
        {
            try
            {
                var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hdbanhang", ware_Hdbanhang.Id_Hdbanhang));

                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update một Collection Ware_Hdbanhang vào DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Ware_Hdbanhang_Collection(DataSet dsCollection)
        {
            try
            {
                var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Hdbanhang", _SqlConnection);
                var oleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(oleDbDataAdapter);
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
        /// Update một Collection Ware_Hdbanhang_Chitiet vào DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Ware_Hdbanhang_Chitiet_Collection(DataSet dsCollection)
        {
            try
            {
                var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Hdbanhang_Chitiet", _SqlConnection);
                var oleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(oleDbDataAdapter);
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
        /// Update một Collection Ware_Hdbanhang_Chitiet vào DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Ware_Hdbanhang_Chitiet_Log_Collection(DataSet dsCollection)
        {
            try
            {
                var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Hdbanhang_Chitiet_Log", _SqlConnection);
                var oleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(oleDbDataAdapter);
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
        /// Nhập xuất tồn hàng hóa bán
        /// </summary>
        /// <param name="Ngay_Batdau"></param>
        /// <param name="Ngay_Ketthuc"></param>
        /// <param name="Id_Cuahang_Ban"></param>
        /// <returns></returns>
        public string Rptware_Nxt_Hhban(object Ngay_Batdau, object Ngay_Ketthuc, object id_Cuahang_Ban, object id_Hanghoa_Ban, object id_Loai_Hanghoa_Ban)
        {
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Rptware_Nxt_Hhban", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", Ngay_Batdau));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", Ngay_Ketthuc));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", id_Cuahang_Ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Ban", id_Hanghoa_Ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Loai_Hanghoa_Ban", id_Loai_Hanghoa_Ban));

            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            var dsCollection = new DataSet();
            oleDbDataAdapter.Fill(dsCollection, "GridTable");

            return FastJSON.JSON.Instance.ToJSON(dsCollection);
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
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Rptware_Nxt_Hhban_ByKhsx", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Baocao", Ngay_Baocao));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));

            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            var dsCollection = new DataSet();
            oleDbDataAdapter.Fill(dsCollection, "GridTable");

            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        /// <summary>
        /// author: nhanvuong - 04-10-2010
        /// Get về danh sách hàng hóa (đã đc định giá) sau khi thông kê
        /// </summary>
        /// <param name="block_no"></param>
        /// <returns></returns>
        public string Get_All_Ware_Dm_Hanghoa_Ban_Dinhgia_After_Thongke(object Id_Cuahang_Ban)
        {
            var dsCollection = new DataSet();
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hanghoa_Dinhgia_After_Thongke", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));

            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }


        public string Get_All_Ware_Hdbanhang_ById_Hdbanhang(object id_hdbanhang)
        {
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_SelectBy_Id_Hdbanhang", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hdbanhang", id_hdbanhang));
            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            var dsCollection = new DataSet();
            oleDbDataAdapter.Fill(dsCollection, "GridTable");

            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Get_All_Ware_Hdbanhang_ById_HhBan_TheoCap(object Id_Khachhang, object Id_Hanghoa_Ban, object Id_Donvitinh)
        {
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hanghoa_Dinhgia_SelectBy_Id_HhBan_TheoCap", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", Id_Khachhang));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Ban", Id_Hanghoa_Ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Donvitinh", Id_Donvitinh));
            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            var dsCollection = new DataSet();
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }
    }
}
