using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Ecm.Service.Ware
{
    public class Ware_Dondathang_Service
    {
        System.Data.OleDb.OleDbConnection _SqlConnection;

        public Ware_Dondathang_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }

        #region implemetns IObService

        public string Ware_Dondathang_Chitiet_SelectById_Dondathang(object Id_Dondathang)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dondathang_Chitiet_SelectById_Dondathang", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Dondathang", Id_Dondathang));
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Ware_Dondathang_SelectAll(object Ngay_Chungtu, object Id_Nhansu)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dondathang_SelectAll", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Ngaychungtu", Ngay_Chungtu));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Id_Nhansu));
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public object Ware_Dondathang_Insert(Ecm.Domain.Ware.Ware_Dondathang _Ware_Dondathang)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dondathang_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Dondathang", System.Data.OleDb.OleDbType.BigInt));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", _Ware_Dondathang.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", _Ware_Dondathang.Ngay_Chungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", _Ware_Dondathang.Id_Nhansu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Ncc", _Ware_Dondathang.Id_Ncc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", _Ware_Dondathang.Ghichu));
                oleDbCommand.Parameters["@Id_Dondathang"].Direction = ParameterDirection.Output;
                oleDbCommand.ExecuteNonQuery();
                return oleDbCommand.Parameters["@Id_Dondathang"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Ware_Dondathang_Update(Ecm.Domain.Ware.Ware_Dondathang _Ware_Dondathang)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dondathang_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Dondathang", _Ware_Dondathang.Id_Dondathang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", _Ware_Dondathang.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", _Ware_Dondathang.Ngay_Chungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", _Ware_Dondathang.Id_Nhansu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Ncc", _Ware_Dondathang.Id_Ncc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", _Ware_Dondathang.Ghichu));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Ware_Dondathang_Update_Doc(Ecm.Domain.Ware.Ware_Dondathang _Ware_Dondathang)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dondathang_Update_Doc", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Dondathang", _Ware_Dondathang.Id_Dondathang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", _Ware_Dondathang.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", _Ware_Dondathang.Ngay_Chungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", _Ware_Dondathang.Id_Nhansu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Ncc", _Ware_Dondathang.Id_Ncc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", _Ware_Dondathang.Ghichu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Doc_Process_Status", _Ware_Dondathang.Doc_Process_Status));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Ware_Dondathang_Delete(Ecm.Domain.Ware.Ware_Dondathang _Ware_Dondathang)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dondathang_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Dondathang", _Ware_Dondathang.Id_Dondathang));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Update_Ware_Dondathang_Chitiet_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_dondathang_chitiet", _SqlConnection);
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
