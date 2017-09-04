using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Ware
{
    public class Ware_Phieu_Thu_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        public Ware_Phieu_Thu_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }

        #region implemetns IObService

        private Ecm.Domain.Ware.Ware_Phieu_Thu Get_Ware_Phieu_Thu(DataRow row)
        {
            Ecm.Domain.Ware.Ware_Phieu_Thu _Ware_Phieu_Thu = new Ecm.Domain.Ware.Ware_Phieu_Thu();
            if ("" + row["Id_Phieu_Thu"] != "")
                _Ware_Phieu_Thu.Id_Phieu_Thu = row["Id_Phieu_Thu"];
            if ("" + row["Ngay_Chungtu"] != "")
                _Ware_Phieu_Thu.Ngay_Chungtu = row["Ngay_Chungtu"];
            if ("" + row["Sochungtu"] != "")
                _Ware_Phieu_Thu.Sochungtu = row["Sochungtu"];
            if ("" + row["Chungtu_Goc"] != "")
                _Ware_Phieu_Thu.Chungtu_Goc = row["Chungtu_Goc"];
            if ("" + row["Lydo"] != "")
                _Ware_Phieu_Thu.Lydo = row["Lydo"];
            if ("" + row["Id_Nhansu_Lapphieu"] != "")
                _Ware_Phieu_Thu.Id_Nhansu_Lapphieu = row["Id_Nhansu_Lapphieu"];
            if ("" + row["Ma_Doituong"] != "")
                _Ware_Phieu_Thu.Ma_Doituong = row["Ma_Doituong"];
            if ("" + row["Nguoi_Nop"] != "")
                _Ware_Phieu_Thu.Nguoi_Nop = row["Nguoi_Nop"];
            if ("" + row["Sotien"] != "")
                _Ware_Phieu_Thu.Sotien = row["Sotien"];
            if ("" + row["Tygia"] != "")
                _Ware_Phieu_Thu.Tygia = row["Tygia"];
            if ("" + row["Sotien_Quydoi"] != "")
                _Ware_Phieu_Thu.Sotien_Quydoi = row["Sotien_Quydoi"];
            if ("" + row["Id_Taikhoan_Nganhang_Chuyen"] != "")
                _Ware_Phieu_Thu.Id_Taikhoan_Nganhang_Chuyen = row["Id_Taikhoan_Nganhang_Chuyen"];
            if ("" + row["Id_Taikhoan_Nganhang_Nhan"] != "")
                _Ware_Phieu_Thu.Id_Taikhoan_Nganhang_Nhan = row["Id_Taikhoan_Nganhang_Nhan"];
            if ("" + row["Id_Kho_Hanghoa_Mua"] != "")
                _Ware_Phieu_Thu.Id_Kho_Hanghoa_Mua = row["Id_Kho_Hanghoa_Mua"];
            if ("" + row["Id_Cuahang_Ban"] != "")
                _Ware_Phieu_Thu.Id_Cuahang_Ban = row["Id_Cuahang_Ban"];
            if ("" + row["Ma_Kho_Hanghoa"] != "")
                _Ware_Phieu_Thu.Ma_Kho_Hanghoa = row["Ma_Kho_Hanghoa"];
            if ("" + row["Ten_Doituong"] != "")
                _Ware_Phieu_Thu.Ten_Doituong = row["Ten_Doituong"];
            if ("" + row["Id_Tiente"] != "")
                _Ware_Phieu_Thu.Id_Tiente = row["Id_Tiente"];
            if ("" + row["Id_Khachhang"] != "")
                _Ware_Phieu_Thu.Id_Khachhang = row["Id_Khachhang"];
            if ("" + row["Guid_Ctu"] != "")
                _Ware_Phieu_Thu.Guid_Ctu = row["Guid_Ctu"];
            return _Ware_Phieu_Thu;
        }

        public string Get_All_Ware_Phieu_Thu()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieu_Thu_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string GetAll_Ware_Phieu_Thu(object Id_Cuahang_Ban)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieu_Thu_SelectAll", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string GetAll_Ware_Phieu_Thu_Date(object Id_Cuahang_Ban, object Thangnam, object Id_Khachhang)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieu_Thu_SelectAll", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thangnam", Thangnam));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", Id_Khachhang));
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Ware_Phieu_Thu_SelectAll_New(object Id_Cuahang_Ban, object Thangnam, object Id_Khachhang)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieu_Thu_SelectAll_New", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thangnam", Thangnam));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", Id_Khachhang));
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Ware_Phieu_Thu_SelectBy_Guid_Ctu(object Guid_Ctu)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieu_Thu_SelectBy_Guid_Ctu", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Ctu", Guid_Ctu));
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Ware_Phieu_Thu_SelectXuatkho_NotPay(object Id_Khachhang)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieu_Thu_SelectXuatkho_NotPay", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", Id_Khachhang));
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Ware_Phieu_Thu_SelectXuatkho_NotPayByMa_Khachhang(object Ma_Khachhang)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieu_Thu_SelectXuatkho_NotPay", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", null));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Khachhang", Ma_Khachhang));
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Ware_Phieu_Thu_SelectXuatkho_NotPay_ById_Cuahang_Ban(object Id_Cuahang_Ban)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieu_Thu_SelectXuatkho_NotPay_ById_Cuahang_Ban", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Ware_Phieu_Thu_SelectPhieu_Xuatkho_ById_Cuahang_Ban(object Id_Cuahang_Ban)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieu_Thu_SelectPhieu_Xuatkho_ById_Cuahang_Ban", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Ware_Phieu_Thu_SelectXuatkho_All(object Id_Khachhang)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieu_Thu_SelectXuatkho_All", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", Id_Khachhang));
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Ware_Phieu_Thu_SelectXuatkho_By_Ma_Khachhang(object Ma_Khachhang)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieu_Thu_SelectXuatkho_All", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", null));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Khachhang", Ma_Khachhang));
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Ware_Phieu_Thu_SelectBy_PhieuXuat(string Chungtu_Goc)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieu_Thu_SelectBy_PhieuXuat", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chungtu_Goc", Chungtu_Goc));
            oleDbCommand.CommandType = CommandType.StoredProcedure;


            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Ware_Phieu_Thu_SelectBy_Guid_Ctu_Edit(string Guid_Ctu)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieu_Thu_SelectBy_Guid_Ctu_Edit", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Ctu", Guid_Ctu));
            oleDbCommand.CommandType = CommandType.StoredProcedure;


            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Insert đối tượng Ware_Phieu_Thu vào DB.
        /// </summary>
        /// <param name="ware_Phieu_Thu"></param>
        /// <returns></returns>
        public object Insert_Ware_Phieu_Thu(Ecm.Domain.Ware.Ware_Phieu_Thu ware_Phieu_Thu)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieu_Thu_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Phieu_Thu", ware_Phieu_Thu.Id_Phieu_Thu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", ware_Phieu_Thu.Ngay_Chungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", ware_Phieu_Thu.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chungtu_Goc", ware_Phieu_Thu.Chungtu_Goc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Lydo", ware_Phieu_Thu.Lydo));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Lapphieu", ware_Phieu_Thu.Id_Nhansu_Lapphieu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Doituong", ware_Phieu_Thu.Ma_Doituong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Doituong", ware_Phieu_Thu.Ten_Doituong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nguoi_Nop", ware_Phieu_Thu.Nguoi_Nop));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien", ware_Phieu_Thu.Sotien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Tiente", ware_Phieu_Thu.Id_Tiente));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tygia", ware_Phieu_Thu.Tygia));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Quydoi", ware_Phieu_Thu.Sotien_Quydoi));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Taikhoan_Nganhang_Chuyen", ware_Phieu_Thu.Id_Taikhoan_Nganhang_Chuyen));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Taikhoan_Nganhang_Nhan", ware_Phieu_Thu.Id_Taikhoan_Nganhang_Nhan));

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kho_Hanghoa_Mua", ware_Phieu_Thu.Id_Kho_Hanghoa_Mua));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", ware_Phieu_Thu.Id_Cuahang_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Kho_Hanghoa", ware_Phieu_Thu.Ma_Kho_Hanghoa));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", ware_Phieu_Thu.Id_Khachhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Ctu", ware_Phieu_Thu.Guid_Ctu));
                oleDbCommand.Parameters["@Id_Phieu_Thu"].Direction = ParameterDirection.Output;
                oleDbCommand.ExecuteNonQuery();

                return oleDbCommand.Parameters["@Id_Phieu_Thu"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Insert_Ware_Phieu_Thu2(Ecm.Domain.Ware.Ware_Phieu_Thu ware_Phieu_Thu)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieu_Thu_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Phieu_Thu", ware_Phieu_Thu.Id_Phieu_Thu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", ware_Phieu_Thu.Ngay_Chungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", ware_Phieu_Thu.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chungtu_Goc", ware_Phieu_Thu.Chungtu_Goc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Lydo", ware_Phieu_Thu.Lydo));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Lapphieu", ware_Phieu_Thu.Id_Nhansu_Lapphieu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Doituong", ware_Phieu_Thu.Ma_Doituong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Doituong", ware_Phieu_Thu.Ten_Doituong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nguoi_Nop", ware_Phieu_Thu.Nguoi_Nop));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien", ware_Phieu_Thu.Sotien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Tiente", ware_Phieu_Thu.Id_Tiente));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tygia", ware_Phieu_Thu.Tygia));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Quydoi", ware_Phieu_Thu.Sotien_Quydoi));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Taikhoan_Nganhang_Chuyen", ware_Phieu_Thu.Id_Taikhoan_Nganhang_Chuyen));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Taikhoan_Nganhang_Nhan", ware_Phieu_Thu.Id_Taikhoan_Nganhang_Nhan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kho_Hanghoa_Mua", ware_Phieu_Thu.Id_Kho_Hanghoa_Mua));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", ware_Phieu_Thu.Id_Cuahang_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Kho_Hanghoa", ware_Phieu_Thu.Ma_Kho_Hanghoa));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", ware_Phieu_Thu.Id_Khachhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Ctu", ware_Phieu_Thu.Guid_Ctu));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update đối tượng Ware_Phieu_Thu vào DB.
        /// </summary>
        /// <param name="ware_Phieu_Thu"></param>
        /// <returns></returns>
        public object Update_Ware_Phieu_Thu(Ecm.Domain.Ware.Ware_Phieu_Thu ware_Phieu_Thu)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieu_Thu_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Phieu_Thu", ware_Phieu_Thu.Id_Phieu_Thu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", ware_Phieu_Thu.Ngay_Chungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", ware_Phieu_Thu.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chungtu_Goc", ware_Phieu_Thu.Chungtu_Goc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Lydo", ware_Phieu_Thu.Lydo));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Lapphieu", ware_Phieu_Thu.Id_Nhansu_Lapphieu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Doituong", ware_Phieu_Thu.Ma_Doituong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Doituong", ware_Phieu_Thu.Ten_Doituong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nguoi_Nop", ware_Phieu_Thu.Nguoi_Nop));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien", ware_Phieu_Thu.Sotien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Tiente", ware_Phieu_Thu.Id_Tiente));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tygia", ware_Phieu_Thu.Tygia));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Quydoi", ware_Phieu_Thu.Sotien_Quydoi));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Taikhoan_Nganhang_Chuyen", ware_Phieu_Thu.Id_Taikhoan_Nganhang_Chuyen));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Taikhoan_Nganhang_Nhan", ware_Phieu_Thu.Id_Taikhoan_Nganhang_Nhan));

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kho_Hanghoa_Mua", ware_Phieu_Thu.Id_Kho_Hanghoa_Mua));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", ware_Phieu_Thu.Id_Cuahang_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Kho_Hanghoa", ware_Phieu_Thu.Ma_Kho_Hanghoa));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", ware_Phieu_Thu.Id_Khachhang));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete đối tượng Ware_Phieu_Thu vào DB.
        /// </summary>
        /// <param name="ware_Phieu_Thu"></param>
        /// <returns></returns>
        public object Delete_Ware_Phieu_Thu(Ecm.Domain.Ware.Ware_Phieu_Thu ware_Phieu_Thu)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieu_Thu_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Phieu_Thu", ware_Phieu_Thu.Id_Phieu_Thu));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Update_Ware_Phieu_Thu_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Phieu_Thu", _SqlConnection);
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

        public object Update_Ware_Phieu_Thu_Collection2(DataSet ds_Ware_Dm_Kho_Vattu)
        {
            try
            {
                DataSet dsI = ds_Ware_Dm_Kho_Vattu.GetChanges(DataRowState.Added);
                DataSet dsU = ds_Ware_Dm_Kho_Vattu.GetChanges(DataRowState.Modified);
                DataSet dsD = ds_Ware_Dm_Kho_Vattu.GetChanges(DataRowState.Deleted);

                if (dsI != null)
                    foreach (DataRow dr in dsI.Tables[0].Rows)
                        this.Insert_Ware_Phieu_Thu2(this.Get_Ware_Phieu_Thu(dr));
                if (dsU != null)
                    foreach (DataRow dr in dsU.Tables[0].Rows)
                        this.Update_Ware_Phieu_Thu(this.Get_Ware_Phieu_Thu(dr));
                if (dsD != null)
                {
                    dsD.RejectChanges();
                    foreach (DataRow dr in dsD.Tables[0].Rows)
                        this.Delete_Ware_Phieu_Thu(this.Get_Ware_Phieu_Thu(dr));
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Get_Schema_Ware_Phieu_Thu()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add("GridTable");
            ds.Tables[0].Columns.Add("Id_Phieu_Thu");
            ds.Tables[0].Columns.Add("Ngay_Chungtu");
            ds.Tables[0].Columns.Add("Sochungtu");
            ds.Tables[0].Columns.Add("Chungtu_Goc");
            ds.Tables[0].Columns.Add("Lydo");
            ds.Tables[0].Columns.Add("Id_Nhansu_Lapphieu");
            ds.Tables[0].Columns.Add("Ma_Doituong");
            ds.Tables[0].Columns.Add("Nguoi_Nop");
            ds.Tables[0].Columns.Add("Sotien");
            ds.Tables[0].Columns.Add("Tygia");
            ds.Tables[0].Columns.Add("Sotien_Quydoi");
            //ds.Tables[0].Columns.Add("Id_Taikhoan_Nganhang_Chuyen");
            //ds.Tables[0].Columns.Add("Id_Taikhoan_Nganhang_Nhan");
            ds.Tables[0].Columns.Add("Doc_Process_Status");
            ds.Tables[0].Columns.Add("Id_Cuahang_Ban");
            ds.Tables[0].Columns.Add("Ten_Doituong");
            ds.Tables[0].Columns.Add("Guid_Ctu");
            ds.Tables[0].Columns.Add("Diachi");
            return FastJSON.JSON.Instance.ToJSON(ds);
        }

        #endregion

    }
}
