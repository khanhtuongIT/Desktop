using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Ware
{
    public class Ware_Xuat_Nguyenlieu_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Ware_Xuat_Nguyenlieu_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService

        public string Ware_Xuat_Nguyenlieu_SelectAll(object Ngay_Chungtu, object Id_Cuahang_Ban)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Xuat_Nguyenlieu_SelectAll", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", Ngay_Chungtu));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public object Ware_Xuat_Nguyenlieu_Insert(Ecm.Domain.Ware.Ware_Xuat_Nguyenlieu _Ware_Xuat_Nguyenlieu)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Xuat_Nguyenlieu_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Xuat_Nguyenlieu", _Ware_Xuat_Nguyenlieu.Id_Xuat_Nguyenlieu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", _Ware_Xuat_Nguyenlieu.Id_Cuahang_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", _Ware_Xuat_Nguyenlieu.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", _Ware_Xuat_Nguyenlieu.Ngay_Chungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Xuat", _Ware_Xuat_Nguyenlieu.Id_Nhansu_Xuat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", _Ware_Xuat_Nguyenlieu.Ghichu));
                oleDbCommand.Parameters["@Id_Xuat_Nguyenlieu"].Direction = ParameterDirection.Output;
                oleDbCommand.ExecuteNonQuery();
                return oleDbCommand.Parameters["@Id_Xuat_Nguyenlieu"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Ware_Xuat_Nguyenlieu_Update(Ecm.Domain.Ware.Ware_Xuat_Nguyenlieu _Ware_Xuat_Nguyenlieu)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Xuat_Nguyenlieu_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Xuat_Nguyenlieu", _Ware_Xuat_Nguyenlieu.Id_Xuat_Nguyenlieu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", _Ware_Xuat_Nguyenlieu.Id_Cuahang_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", _Ware_Xuat_Nguyenlieu.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", _Ware_Xuat_Nguyenlieu.Ngay_Chungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Xuat", _Ware_Xuat_Nguyenlieu.Id_Nhansu_Xuat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", _Ware_Xuat_Nguyenlieu.Ghichu));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Ware_Xuat_Nguyenlieu_Delete(Ecm.Domain.Ware.Ware_Xuat_Nguyenlieu _Ware_Xuat_Nguyenlieu)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Xuat_Nguyenlieu_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Xuat_Nguyenlieu", _Ware_Xuat_Nguyenlieu.Id_Xuat_Nguyenlieu));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Update_Ware_Xuat_Nguyenlieu_Chitiet_Collection(DataSet dsCollection) 
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from ware_xuat_nguyenlieu_chitiet", _SqlConnection);
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

        public string Ware_Xuat_Nguyenlieu_Chitiet_SelectBy_Id_Xuat_Nguyenlieu(object Id_Xuat_Nguyenlieu)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Xuat_Nguyenlieu_Chitiet_SelectBy_Id_Xuat_Nguyenlieu", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Xuat_Nguyenlieu", Id_Xuat_Nguyenlieu));
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        #endregion

    }
}
