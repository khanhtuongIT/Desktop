using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Ware
{
    public class Ware_Thumau_Services
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Ware_Thumau_Services(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService


        public string Ware_Thumau_SelectAll(object Id_Nhansu, object Ngay_Thu)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Thumau_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Id_Nhansu));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Thu", Ngay_Thu));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Ware_Thumau_SelectByDate(object Ngay_Thumau)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Thumau_SelectByDate", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Thumau", Ngay_Thumau));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        /// <summary>
        /// Insert đối tượng Ware_Ctrinh_Kmai vào DB.
        /// </summary>
        /// <param name="Ware_Ctrinh_Kmai"></param>
        /// <returns></returns>
        public object Ware_Thumau_Insert(Ecm.Domain.Ware.Ware_Thumau Ware_Thumau)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Thumau_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                //oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Congtac", System.Data.OleDb.OleDbType.BigInt));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Ware_Thumau.Id_Nhansu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Lobanh", Ware_Thumau.Ten_Lobanh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Ban", Ware_Thumau.Id_Hanghoa_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong", Ware_Thumau.Soluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dongia", Ware_Thumau.Dongia));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tenhang_Doithu", Ware_Thumau.Tenhang_Doithu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngaythu", Ware_Thumau.Ngaythu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sanluong", Ware_Thumau.Sanluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ketqua", Ware_Thumau.Ketqua));
                //oleDbCommand.Parameters["@Id_Congtac"].Direction = ParameterDirection.Output;
                oleDbCommand.ExecuteNonQuery();
                //return oleDbCommand.Parameters["@Id_Congtac"].Value;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Ware_Thumau_Update(Ecm.Domain.Ware.Ware_Thumau Ware_Thumau)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Thumau_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Thumau", Ware_Thumau.Id_Thumau));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Ware_Thumau.Id_Nhansu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Lobanh", Ware_Thumau.Ten_Lobanh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Ban", Ware_Thumau.Id_Hanghoa_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong", Ware_Thumau.Soluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dongia", Ware_Thumau.Dongia));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tenhang_Doithu", Ware_Thumau.Tenhang_Doithu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngaythu", Ware_Thumau.Ngaythu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sanluong", Ware_Thumau.Sanluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ketqua", Ware_Thumau.Ketqua));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete đối tượng Ware_Ctrinh_Kmai vào DB.
        /// </summary>
        /// <param name="Ware_Thumau"></param>
        /// <returns></returns>
        public object Ware_Thumau_Delete(object Id_Thumau)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Thumau_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Thumau", Id_Thumau));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Update_Ware_Ware_Thumau_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Thumau", _SqlConnection);
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
