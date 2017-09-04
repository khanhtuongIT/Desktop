using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Ware
{
    public class Ware_Dieuxe_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Ware_Dieuxe_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService

        private Ecm.Domain.Ware.Ware_Dieuxe_Chitiet Get_Ware_Dieuxe_Chitiet(DataRow row)
        {
            Ecm.Domain.Ware.Ware_Dieuxe_Chitiet _Ware_Dieuxe_Chitiet = new Ecm.Domain.Ware.Ware_Dieuxe_Chitiet();
            if ("" + row["Id_Dieuxe_Chitiet"] != "")
                _Ware_Dieuxe_Chitiet.Id_Dieuxe_Chitiet = row["Id_Dieuxe_Chitiet"];
            if ("" + row["Id_Dieuxe"] != "")
                _Ware_Dieuxe_Chitiet.Id_Dieuxe = row["Id_Dieuxe"];
            if ("" + row["Id_Xuatkho_Banhang_Chitiet"] != "")
                _Ware_Dieuxe_Chitiet.Id_Xuatkho_Banhang_Chitiet = row["Id_Xuatkho_Banhang_Chitiet"];
            if ("" + row["Id_Hanghoa_Ban"] != "")
                _Ware_Dieuxe_Chitiet.Id_Hanghoa_Ban = row["Id_Hanghoa_Ban"];
            if ("" + row["Id_Donvitinh"] != "")
                _Ware_Dieuxe_Chitiet.Id_Donvitinh = row["Id_Donvitinh"];
            if ("" + row["Soluong"] != "")
                _Ware_Dieuxe_Chitiet.Soluong = row["Soluong"];
            if ("" + row["Dongia"] != "")
                _Ware_Dieuxe_Chitiet.Dongia = row["Dongia"];
            if ("" + row["Id_Cuahang_Ban"] != "")
                _Ware_Dieuxe_Chitiet.Id_Cuahang_Ban = row["Id_Cuahang_Ban"];
            if ("" + row["Guid_Dieuxe_Chitiet"] != "")
                _Ware_Dieuxe_Chitiet.Guid_Dieuxe_Chitiet = row["Guid_Dieuxe_Chitiet"];
            return _Ware_Dieuxe_Chitiet;
        }

        public object Insert_Ware_Dieuxe_Chitiet(Ecm.Domain.Ware.Ware_Dieuxe_Chitiet __Ware_Dieuxe_Chitiet)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dieuxe_Chitiet_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Dieuxe", __Ware_Dieuxe_Chitiet.Id_Dieuxe));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Xuatkho_Banhang_Chitiet", __Ware_Dieuxe_Chitiet.Id_Xuatkho_Banhang_Chitiet));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Ban", __Ware_Dieuxe_Chitiet.Id_Hanghoa_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Donvitinh", __Ware_Dieuxe_Chitiet.Id_Donvitinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong", __Ware_Dieuxe_Chitiet.Soluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dongia", __Ware_Dieuxe_Chitiet.Dongia));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", __Ware_Dieuxe_Chitiet.Id_Cuahang_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Dieuxe_Chitiet", __Ware_Dieuxe_Chitiet.Guid_Dieuxe_Chitiet));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Update_Ware_Dieuxe_Chitiet(Ecm.Domain.Ware.Ware_Dieuxe_Chitiet __Ware_Dieuxe_Chitiet)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dieuxe_Chitiet_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Dieuxe_Chitiet", __Ware_Dieuxe_Chitiet.Id_Dieuxe_Chitiet));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Dieuxe", __Ware_Dieuxe_Chitiet.Id_Dieuxe));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Xuatkho_Banhang_Chitiet", __Ware_Dieuxe_Chitiet.Id_Xuatkho_Banhang_Chitiet));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Ban", __Ware_Dieuxe_Chitiet.Id_Hanghoa_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Donvitinh", __Ware_Dieuxe_Chitiet.Id_Donvitinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong", __Ware_Dieuxe_Chitiet.Soluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dongia", __Ware_Dieuxe_Chitiet.Dongia));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", __Ware_Dieuxe_Chitiet.Id_Cuahang_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Dieuxe_Chitiet", __Ware_Dieuxe_Chitiet.Guid_Dieuxe_Chitiet));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Delete_Ware_Dieuxe_Chitiet(object Id_Dieuxe_Chitiet)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dieuxe_Chitiet_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Dieuxe_Chitiet", Id_Dieuxe_Chitiet));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Update_Ware_Dieuxe_Chitiet_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Dieuxe_Chitiet", this._SqlConnection);
                System.Data.OleDb.OleDbCommandBuilder oleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(oleDbDataAdapter);
                oleDbDataAdapter = oleDbCommandBuilder.DataAdapter;
                oleDbDataAdapter.Update(dsCollection, "GridTable");
                //dsCollection.Tables[0].AcceptChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Update_Ware_Dieuxe_Chitiet_Collection2(DataSet dsCollection)
        {
            try
            {
                DataSet dsI = dsCollection.GetChanges(DataRowState.Added);
                DataSet dsU = dsCollection.GetChanges(DataRowState.Modified);
                DataSet dsD = dsCollection.GetChanges(DataRowState.Deleted);

                if (dsI != null)
                    foreach (DataRow dr in dsI.Tables[0].Rows)
                        this.Insert_Ware_Dieuxe_Chitiet(this.Get_Ware_Dieuxe_Chitiet(dr));
                if (dsU != null)
                    foreach (DataRow dr in dsU.Tables[0].Rows)
                        this.Update_Ware_Dieuxe_Chitiet(this.Get_Ware_Dieuxe_Chitiet(dr));
                if (dsD != null)
                {
                    dsD.RejectChanges();
                    foreach (DataRow dr in dsD.Tables[0].Rows)
                        this.Delete_Ware_Dieuxe_Chitiet(this.Get_Ware_Dieuxe_Chitiet(dr));
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Update_Ware_Dieuxe_Chitiet_Tmp_Collection(DataSet dsCollection)
        {
            try
            {              
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Dieuxe_Chitiet_Tmp", this._SqlConnection);
                System.Data.OleDb.OleDbCommandBuilder oleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(oleDbDataAdapter);
                oleDbDataAdapter = oleDbCommandBuilder.DataAdapter;
                oleDbDataAdapter.Update(dsCollection, "GridTable");
                dsCollection.Tables[0].AcceptChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Ware_Dieuxe_Chitiet_Tmp_Delete()
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dieuxe_Chitiet_Tmp_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Ware_Dieuxe_Chitiet_Tmp_DeleteBy_Sochungtu(object Sochungtu)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dieuxe_Chitiet_Tmp_DeleteBy_Sochungtu", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", Sochungtu));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Ware_Dieuxe_Chitiet_DeleteBy_Sochungtu(object Sochungtu)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dieuxe_Chitiet_DeleteBy_Sochungtu", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", Sochungtu));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Get_Schema_Ware_Dieuxe_Xuatkho()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add("GridTable");
            ds.Tables[0].Columns.Add("Id_Dieuxe_Xuatkho");
            ds.Tables[0].Columns.Add("Id_Dieuxe");
            ds.Tables[0].Columns.Add("Sochungtu");
            return FastJSON.JSON.Instance.ToJSON(ds);
        }

        public string Get_Schema_Ware_Dieuxe_Cuahang_Ban()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add("GridTable");
            ds.Tables[0].Columns.Add("Id_Dieuxe_Cuahang_Ban");
            ds.Tables[0].Columns.Add("Id_Dieuxe");
            ds.Tables[0].Columns.Add("Id_Cuahang_Ban");
            return FastJSON.JSON.Instance.ToJSON(ds);
        }

        public string Ware_Dieuxe_Cuahang_Ban_SelectBy_Id_Dieuxe(object Id_Dieuxe)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dieuxe_Cuahang_Ban_SelectBy_Id_Dieuxe", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Dieuxe", Id_Dieuxe));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Ware_Dieuxe_Chitiet_SelectBy_Id_Dieuxe(object Id_Dieuxe)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dieuxe_Chitiet_SelectBy_Id_Dieuxe", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Dieuxe", Id_Dieuxe));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Ware_Dieuxe_Chitiet_SelectBy_Id_Dieuxe_Group(object Id_Dieuxe)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dieuxe_Chitiet_SelectBy_Id_Dieuxe_Group", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Dieuxe", Id_Dieuxe));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Ware_Dieuxe_Chitiet_Tmp_SelectBy_Guid_Dieuxe(object Guid_Dieuxe)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dieuxe_Chitiet_Tmp_SelectBy_Guid_Dieuxe", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Dieuxe", Guid_Dieuxe));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Ware_Dieuxe_Chitiet_Tmp_SelectAll_By_Guid_Dieuxe(object Guid_Dieuxe) // not group
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dieuxe_Chitiet_Tmp_SelectAll_By_Guid_Dieuxe", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Dieuxe", Guid_Dieuxe));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Ware_Dieuxe_Chitiet_SelectBy_Id_Dieuxe_Mail(object Id_Dieuxe)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dieuxe_Chitiet_SelectBy_Id_Dieuxe_Mail", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Dieuxe", Id_Dieuxe));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Ware_Dieuxe_Thongke_ByXe(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Xe)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dieuxe_Thongke_ByXe", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", Ngay_Batdau));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", Ngay_Ketthuc));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Xe", Id_Xe));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Get_All_Ware_Dieuxe(object Thangnam, object Id_Cuahang_Ban)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dieuxe_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thangnam", Thangnam));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Ware_Dieuxe_Thongke_Tonghop(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Cuahang_Ban)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dieuxe_Thongke_Tonghop", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", Ngay_Batdau));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", Ngay_Ketthuc));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Ware_Dieuxe_SelectBy_Id_Xuatkho(object Id_Xuatkho_Banhang)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dieuxe_SelectBy_Id_Xuatkho", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Xuatkho_Banhang", Id_Xuatkho_Banhang));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Ware_Dieuxe_SelectBy_Mathang(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Hanghoa_Ban, object Id_Taixe, object Id_Xe)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dieuxe_SelectBy_Mathang", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", Ngay_Batdau));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", Ngay_Ketthuc));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Ban", Id_Hanghoa_Ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Taixe", Id_Taixe));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Xe", Id_Xe));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public object Insert_Ware_Dieuxe(Ecm.Domain.Ware.Ware_Dieuxe ware_dieuxe)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dieuxe_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Dieuxe", ware_dieuxe.Id_Dieuxe));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Xuatkho_Banhang", ware_dieuxe.Id_Xuatkho_Banhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Dieuxe", ware_dieuxe.Id_Nhansu_Dieuxe));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Xe", ware_dieuxe.Id_Xe));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Di", ware_dieuxe.Ngay_Di));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Den", ware_dieuxe.Ngay_Den));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ve", ware_dieuxe.Ngay_Ve));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Quangduong_Di", ware_dieuxe.Quangduong_Di));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", ware_dieuxe.Ghichu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Taixe", ware_dieuxe.Id_Taixe));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", ware_dieuxe.Id_Cuahang_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Taixe", ware_dieuxe.Ten_Taixe));
                oleDbCommand.Parameters["@Id_Dieuxe"].Size = 99999;
                oleDbCommand.Parameters["@Id_Dieuxe"].Direction = ParameterDirection.Output;
                oleDbCommand.ExecuteNonQuery();
                return oleDbCommand.Parameters["@Id_Dieuxe"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Update_Ware_Dieuxe(Ecm.Domain.Ware.Ware_Dieuxe ware_dieuxe)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dieuxe_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Dieuxe", ware_dieuxe.Id_Dieuxe));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Xuatkho_Banhang", ware_dieuxe.Id_Xuatkho_Banhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Dieuxe", ware_dieuxe.Id_Nhansu_Dieuxe));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Xe", ware_dieuxe.Id_Xe));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Di", ware_dieuxe.Ngay_Di));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Den", ware_dieuxe.Ngay_Den));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ve", ware_dieuxe.Ngay_Ve));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Quangduong_Di", ware_dieuxe.Quangduong_Di));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", ware_dieuxe.Ghichu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Taixe", ware_dieuxe.Id_Taixe));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", ware_dieuxe.Id_Cuahang_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Taixe", ware_dieuxe.Ten_Taixe));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Delete_Ware_Dieuxe(Ecm.Domain.Ware.Ware_Dieuxe ware_dieuxe)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dieuxe_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Dieuxe", ware_dieuxe.Id_Dieuxe));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Update_Ware_Dieuxe_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Dieuxe", this._SqlConnection);
                System.Data.OleDb.OleDbCommandBuilder oleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(oleDbDataAdapter);
                oleDbDataAdapter = oleDbCommandBuilder.DataAdapter;
                oleDbDataAdapter.Update(dsCollection, "GridTable");
                dsCollection.Tables[0].AcceptChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Update_Ware_Dieuxe_Xuatkho_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from ware_dieuxe_xuatkho", this._SqlConnection);
                System.Data.OleDb.OleDbCommandBuilder oleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(oleDbDataAdapter);
                oleDbDataAdapter = oleDbCommandBuilder.DataAdapter;
                oleDbDataAdapter.Update(dsCollection, "GridTable");
                dsCollection.Tables[0].AcceptChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Ware_Dieuxe_Xuatkho_Delete_ById_Dieuxe(object Id_Dieuxe)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dieuxe_Xuatkho_Delete_ById_Dieuxe", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Dieuxe", Id_Dieuxe));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Update_Ware_Dieuxe_Cuahang_Ban_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from ware_dieuxe_cuahang_ban", this._SqlConnection);
                System.Data.OleDb.OleDbCommandBuilder oleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(oleDbDataAdapter);
                oleDbDataAdapter = oleDbCommandBuilder.DataAdapter;
                oleDbDataAdapter.Update(dsCollection, "GridTable");
                dsCollection.Tables[0].AcceptChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Delete_Ware_Dieuxe_Xuatkho(object Id_Dieuxe_Xuatkho)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dieuxe_Xuatkho_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Dieuxe_Xuatkho", Id_Dieuxe_Xuatkho));
                oleDbCommand.ExecuteNonQuery();
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
