﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Ware
{
    public class Ware_Phantich_Thitruong_Services
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Ware_Phantich_Thitruong_Services(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService

        public string Ware_Phantich_Thitruong_SelectAll(object Id_Nhansu, object Ngay_Taophieu)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phantich_Thitruong_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Id_Nhansu));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Taophieu", Ngay_Taophieu));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public object Ware_Phantich_Thitruong_Insert(Ecm.Domain.Ware.Ware_Phantich_Thitruong ware_phantich_thitruong)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phantich_Thitruong_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Phantich_Thitruong", System.Data.OleDb.OleDbType.BigInt));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", ware_phantich_thitruong.Id_Nhansu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Taophieu", ware_phantich_thitruong.Ngay_Taophieu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khuvuc", ware_phantich_thitruong.Id_Khuvuc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tuyen_Banhang", ware_phantich_thitruong.Tuyen_Banhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", ware_phantich_thitruong.Ghichu));
                oleDbCommand.Parameters["@Id_Phantich_Thitruong"].Direction = ParameterDirection.Output;
                oleDbCommand.ExecuteNonQuery();
                return oleDbCommand.Parameters["@Id_Phantich_Thitruong"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Ware_Phantich_Thitruong_Update(Ecm.Domain.Ware.Ware_Phantich_Thitruong ware_phantich_thitruong)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phantich_Thitruong_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Phantich_Thitruong", ware_phantich_thitruong.Id_Phantich_Thitruong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", ware_phantich_thitruong.Id_Nhansu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Taophieu", ware_phantich_thitruong.Ngay_Taophieu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khuvuc", ware_phantich_thitruong.Id_Khuvuc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tuyen_Banhang", ware_phantich_thitruong.Tuyen_Banhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", ware_phantich_thitruong.Ghichu));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Ware_Phantich_Thitruong_Delete(object Id_Phantich_Thitruong)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phantich_Thitruong_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Phantich_Thitruong", Id_Phantich_Thitruong));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public object Update_Ware_Phantich_Thitruong_Collection(DataSet dsCollection)
        //{
        //    try
        //    {
        //        System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Phantich_Thitruong", _SqlConnection);
        //        System.Data.OleDb.OleDbCommandBuilder oleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(oleDbDataAdapter);
        //        oleDbDataAdapter = oleDbCommandBuilder.DataAdapter;
        //        oleDbDataAdapter.Update(dsCollection, "GridTable");
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        #endregion

    }
}
