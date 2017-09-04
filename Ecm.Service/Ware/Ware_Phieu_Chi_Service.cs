using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Ware
{
    public class Ware_Phieu_Chi_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Ware_Phieu_Chi_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService
        /// <summary>
        /// Trả về một dataset Phieu_Chi
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Phieu_Chi()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieu_Chi_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string GetAll_Ware_Phieu_Chi(object Id_Cuahang_Ban)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieu_Chi_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string GetAll_Ware_Phieu_Chi_Date(object Id_Cuahang_Ban, object Thangnam)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieu_Chi_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thangnam", Thangnam));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        /// <summary>
        /// Insert đối tượng Ware_Phieu_Chi vào DB.
        /// </summary>
        /// <param name="ware_Phieu_Chi"></param>
        /// <returns></returns>
        public object Insert_Ware_Phieu_Chi(Ecm.Domain.Ware.Ware_Phieu_Chi ware_Phieu_Chi)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieu_Chi_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Phieu_Chi", ware_Phieu_Chi.Id_Phieu_Chi));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", ware_Phieu_Chi.Ngay_Chungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", ware_Phieu_Chi.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chungtu_Goc", ware_Phieu_Chi.Chungtu_Goc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Lydo", ware_Phieu_Chi.Lydo));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Lapphieu", ware_Phieu_Chi.Id_Nhansu_Lapphieu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Doituong", ware_Phieu_Chi.Ma_Doituong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nguoi_Nhan", ware_Phieu_Chi.Nguoi_Nhan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien", ware_Phieu_Chi.Sotien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Tiente", ware_Phieu_Chi.Id_Tiente));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tygia", ware_Phieu_Chi.Tygia));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Quydoi", ware_Phieu_Chi.Sotien_Quydoi));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Taikhoan_Nganhang_Chuyen", ware_Phieu_Chi.Id_Taikhoan_Nganhang_Chuyen));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Taikhoan_Nganhang_Nhan", ware_Phieu_Chi.Id_Taikhoan_Nganhang_Nhan));

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kho_Hanghoa_Mua", ware_Phieu_Chi.Id_Kho_Hanghoa_Mua));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", ware_Phieu_Chi.Id_Cuahang_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Kho_Hanghoa", ware_Phieu_Chi.Ma_Kho_Hanghoa));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Ncc", ware_Phieu_Chi.Id_Ncc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chiphi", ware_Phieu_Chi.Chiphi));
                oleDbCommand.Parameters["@Id_Phieu_Chi"].Direction = ParameterDirection.Output;
                oleDbCommand.ExecuteNonQuery();
                return oleDbCommand.Parameters["@Id_Phieu_Chi"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update đối tượng Ware_Phieu_Chi vào DB.
        /// </summary>
        /// <param name="ware_Phieu_Chi"></param>
        /// <returns></returns>
        public object Update_Ware_Phieu_Chi(Ecm.Domain.Ware.Ware_Phieu_Chi ware_Phieu_Chi)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieu_Chi_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Phieu_Chi", ware_Phieu_Chi.Id_Phieu_Chi));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", ware_Phieu_Chi.Ngay_Chungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", ware_Phieu_Chi.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chungtu_Goc", ware_Phieu_Chi.Chungtu_Goc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Lydo", ware_Phieu_Chi.Lydo));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Lapphieu", ware_Phieu_Chi.Id_Nhansu_Lapphieu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Doituong", ware_Phieu_Chi.Ma_Doituong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nguoi_Nhan", ware_Phieu_Chi.Nguoi_Nhan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien", ware_Phieu_Chi.Sotien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Tiente", ware_Phieu_Chi.Id_Tiente));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tygia", ware_Phieu_Chi.Tygia));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Quydoi", ware_Phieu_Chi.Sotien_Quydoi));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Taikhoan_Nganhang_Chuyen", ware_Phieu_Chi.Id_Taikhoan_Nganhang_Chuyen));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Taikhoan_Nganhang_Nhan", ware_Phieu_Chi.Id_Taikhoan_Nganhang_Nhan));

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kho_Hanghoa_Mua", ware_Phieu_Chi.Id_Kho_Hanghoa_Mua));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", ware_Phieu_Chi.Id_Cuahang_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Kho_Hanghoa", ware_Phieu_Chi.Ma_Kho_Hanghoa));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Ncc", ware_Phieu_Chi.Id_Ncc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chiphi", ware_Phieu_Chi.Chiphi));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete đối tượng Ware_Phieu_Chi vào DB.
        /// </summary>
        /// <param name="ware_Phieu_Chi"></param>
        /// <returns></returns>
        public object Delete_Ware_Phieu_Chi(Ecm.Domain.Ware.Ware_Phieu_Chi ware_Phieu_Chi)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieu_Chi_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Phieu_Chi", ware_Phieu_Chi.Id_Phieu_Chi));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update một Collection Ware_Phieu_Chi vào DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Ware_Phieu_Chi_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Phieu_Chi", _SqlConnection);
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
        #endregion
    }
}
