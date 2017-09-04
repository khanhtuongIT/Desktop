using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Ware
{
    public class Ware_Congtac_Services
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Ware_Congtac_Services(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService

        public string Ware_Congtac_Select_ById_Nhansu_Vitri(object Id_Nhansu, object lo_at)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Congtac_Select_ById_Nhansu_Vitri", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Id_Nhansu));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@lo_at", lo_at));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Ware_Kehoach_Banhang_GetAll(object Id_Nhansu, object Ngay_Chungtu)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Kehoach_Banhang_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Id_Nhansu));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", Ngay_Chungtu));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }   

        public string Ware_Congtac_SelectAll(object Id_Nhansu, object Year)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Congtac_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Id_Nhansu));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Year", Year));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Ware_Congtac_SelectByDate(object Thang_Congtac, object Nam_Congtac, object Id_Nhansu)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Congtac_SelectByDate", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thang_Congtac", Thang_Congtac));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nam_Congtac", Nam_Congtac));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Id_Nhansu));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        /// <summary>
        /// Insert đối tượng Ware_Ctrinh_Kmai vào DB.
        /// </summary>
        /// <param name="Ware_Ctrinh_Kmai"></param>
        /// <returns></returns>
        public object Ware_Congtac_Insert(Ecm.Domain.Ware.Ware_Congtac ware_congtac)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Congtac_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Congtac", System.Data.OleDb.OleDbType.BigInt));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", ware_congtac.Id_Nhansu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", ware_congtac.Id_Khachhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Congtac", ware_congtac.Ngay_Congtac));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", ware_congtac.Id_Cuahang_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Noidung", ware_congtac.Noidung));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ketqua", ware_congtac.Ketqua));
                oleDbCommand.Parameters["@Id_Congtac"].Direction = ParameterDirection.Output;
                oleDbCommand.ExecuteNonQuery();
                return oleDbCommand.Parameters["@Id_Congtac"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Ware_Congtac_Update(Ecm.Domain.Ware.Ware_Congtac ware_congtac)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Congtac_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Congtac", ware_congtac.Id_Congtac));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", ware_congtac.Id_Nhansu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", ware_congtac.Id_Khachhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Congtac", ware_congtac.Ngay_Congtac));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", ware_congtac.Id_Cuahang_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Noidung", ware_congtac.Noidung));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ketqua", ware_congtac.Ketqua));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update vị trí công tác
        /// </summary>
        /// <param name="ware_congtac"></param>
        /// <returns></returns>
        public object Ware_Congtac_Update_Vitri(object Id_Congtac, object Vitri, object Lo_laf, object Lo_log)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Congtac_Update_Vitri", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Congtac", Id_Congtac));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Vitri", Vitri));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@lo_lat", Lo_laf));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@lo_log", Lo_log));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }


        public object Ware_Congtac_Update_Vitri_Text(Ecm.Domain.Ware.Ware_Congtac ware_congtac)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Congtac_Update_Vitri_Text", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Congtac", ware_congtac.Id_Congtac));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Vitri", ware_congtac.Vitri));
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
        /// Delete đối tượng Ware_Ctrinh_Kmai vào DB.
        /// </summary>
        /// <param name="ware_congtac"></param>
        /// <returns></returns>
        public object Ware_Congtac_Delete(object Id_Congtac)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Congtac_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Congtac", Id_Congtac));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Update_Ware_Ware_Congtac_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Congtac", _SqlConnection);
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

        public string Ware_Kehoach_Banhang_SelectAll(object Id_Nhansu, object Ngay_Chungtu)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Kehoach_Banhang_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Id_Nhansu));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", Ngay_Chungtu));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Ware_Congtac_SelectKhachhang_New()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Congtac_SelectKhachhangNew", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        #endregion

    }
}
