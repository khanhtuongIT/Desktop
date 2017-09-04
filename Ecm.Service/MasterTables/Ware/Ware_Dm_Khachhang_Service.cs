using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.MasterTables.Ware
{
    public class Ware_Dm_Khachhang_Service
    {
        System.Data.OleDb.OleDbConnection _SqlConnection;

        public Ware_Dm_Khachhang_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }


        private Ecm.Domain.MasterTables.Ware.Ware_Dm_Khachhang Get_Ware_Dm_Khachhang(DataRow row)
        {
            Ecm.Domain.MasterTables.Ware.Ware_Dm_Khachhang _Ware_Dm_Khachhang = new Ecm.Domain.MasterTables.Ware.Ware_Dm_Khachhang();
            if ("" + row["Id_Khachhang"] != "")
                _Ware_Dm_Khachhang.Id_Khachhang = row["Id_Khachhang"];
            if ("" + row["Ten_Khachhang"] != "")
                _Ware_Dm_Khachhang.Ten_Khachhang = row["Ten_Khachhang"];
            if ("" + row["Diachi_Khachhang"] != "")
                _Ware_Dm_Khachhang.Diachi_Khachhang = row["Diachi_Khachhang"];
            if ("" + row["Ma_Khachhang"] != "")
                _Ware_Dm_Khachhang.Ma_Khachhang = row["Ma_Khachhang"];
            if ("" + row["Dienthoai"] != "")
                _Ware_Dm_Khachhang.Dienthoai = row["Dienthoai"];
            if ("" + row["Fax"] != "")
                _Ware_Dm_Khachhang.Fax = row["Fax"];
            if ("" + row["Email"] != "")
                _Ware_Dm_Khachhang.Email = row["Email"];
            if ("" + row["Website"] != "")
                _Ware_Dm_Khachhang.Website = row["Website"];
            if ("" + row["Masothue"] != "")
                _Ware_Dm_Khachhang.Masothue = row["Masothue"];
            if ("" + row["Ngay_Sinh"] != "")
                _Ware_Dm_Khachhang.Ngay_Sinh = row["Ngay_Sinh"];
            if ("" + row["Dinhmuc_No"] != "")
                _Ware_Dm_Khachhang.Dinhmuc_No = row["Dinhmuc_No"];
            if ("" + row["Cmnd"] != "")
                _Ware_Dm_Khachhang.Cmnd = row["Cmnd"];
            if ("" + row["Pb_Tochuc"] != "")
                _Ware_Dm_Khachhang.Pb_Tochuc = row["Pb_Tochuc"];
            if ("" + row["Sotaikhoan"] != "")
                _Ware_Dm_Khachhang.Sotaikhoan = row["Sotaikhoan"];
            if ("" + row["Id_Nganhang"] != "")
                _Ware_Dm_Khachhang.Id_Nganhang = row["Id_Nganhang"];
            if ("" + row["Id_Khuvuc"] != "")
                _Ware_Dm_Khachhang.Id_Khuvuc = row["Id_Khuvuc"];
            if ("" + row["Nguoi_Daidien"] != "")
                _Ware_Dm_Khachhang.Nguoi_Daidien = row["Nguoi_Daidien"];
            if ("" + row["Congno_Thang"] != "")
                _Ware_Dm_Khachhang.Congno_Thang = row["Congno_Thang"];
            if ("" + row["Id_Cap"] != "")
                _Ware_Dm_Khachhang.Id_Cap = row["Id_Cap"];
            if ("" + row["Tinhcongno"] != "")
                _Ware_Dm_Khachhang.Tinhcongno = row["Tinhcongno"];
            return _Ware_Dm_Khachhang;
        }

        /// <summary>
        /// Trả về một dataset Ware_Dm_Khachhang
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Dm_Khachhang()
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Khachhang_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Ware_Dm_Khachhang_SelectById_Nhansu(object Id_Nhansu, object Id_Cuahang_Ban)
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Khachhang_SelectById_Nhansu", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Id_Nhansu));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        /// <summary>
        /// Trả về một dataset Ware_Dm_Khachhang
        /// </summary>
        /// <returns></returns>
        public string Ware_Dm_Khachhang_SelectBy_Khuvuc(object Id_Khuvuc)
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Khachhang_SelectBy_Khuvuc", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khuvuc", Id_Khuvuc));
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Ware_Dm_Khachhang_SelectBy_Khuvuc_New(object Id_Khuvuc)
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Khachhang_SelectBy_Khuvuc_New", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khuvuc", Id_Khuvuc));
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Ware_Dm_Khachhang_SelectBy_Khuvuc_Id_Nhansu(object Id_Khuvuc, object Id_Nhansu)
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Khachhang_SelectBy_Khuvuc_Id_Nhansu", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khuvuc", Id_Khuvuc));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Id_Nhansu));
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Search_Ware_Dm_Khachhang(Ecm.Domain.MasterTables.Ware.Ware_Dm_Khachhang Ware_Dm_Khachhang)
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Khachhang_Search", this._SqlConnection);
            OleDbCommand.CommandType = CommandType.StoredProcedure;
            OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Khachhang", Ware_Dm_Khachhang.Ma_Khachhang));
            OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Khachhang", Ware_Dm_Khachhang.Ten_Khachhang));
            OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Diachi_Khachhang", Ware_Dm_Khachhang.Diachi_Khachhang));
            OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Masothue", Ware_Dm_Khachhang.Masothue));
            OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dienthoai", Ware_Dm_Khachhang.Dienthoai));
            OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Fax", Ware_Dm_Khachhang.Fax));
            OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Email", Ware_Dm_Khachhang.Email));
            OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Website", Ware_Dm_Khachhang.Website));
            OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Sinh", Ware_Dm_Khachhang.Ngay_Sinh));
            OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dinhmuc_No", Ware_Dm_Khachhang.Dinhmuc_No));
            OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Cmnd", Ware_Dm_Khachhang.Cmnd));
            OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Pb_Tochuc", Ware_Dm_Khachhang.Pb_Tochuc));
            OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotaikhoan", Ware_Dm_Khachhang.Sotaikhoan));
            OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nganhang", Ware_Dm_Khachhang.Id_Nganhang));
            OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khuvuc", Ware_Dm_Khachhang.Id_Khuvuc));
            OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nguoi_Daidien", Ware_Dm_Khachhang.Nguoi_Daidien));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(OleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None);
        }

        /// <summary>
        /// Trả về một dataset Ware_Dm_Doituong
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Dm_Doituong()
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Doituong_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Insert đối tượng Ware_Dm_Khachhang vào DB.
        /// </summary>
        /// <param name="Ware_Dm_Khachhang"></param>
        /// <returns></returns>
        public object Insert_Ware_Dm_Khachhang(Ecm.Domain.MasterTables.Ware.Ware_Dm_Khachhang Ware_Dm_Khachhang)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Khachhang_Insert", _SqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Khachhang", Ware_Dm_Khachhang.Ma_Khachhang));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Khachhang", Ware_Dm_Khachhang.Ten_Khachhang));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Diachi_Khachhang", Ware_Dm_Khachhang.Diachi_Khachhang));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Masothue", Ware_Dm_Khachhang.Masothue));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dienthoai", Ware_Dm_Khachhang.Dienthoai));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Fax", Ware_Dm_Khachhang.Fax));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Email", Ware_Dm_Khachhang.Email));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Website", Ware_Dm_Khachhang.Website));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Sinh", Ware_Dm_Khachhang.Ngay_Sinh));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dinhmuc_No", Ware_Dm_Khachhang.Dinhmuc_No));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Cmnd", Ware_Dm_Khachhang.Cmnd));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Pb_Tochuc", Ware_Dm_Khachhang.Pb_Tochuc));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotaikhoan", Ware_Dm_Khachhang.Sotaikhoan));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nganhang", Ware_Dm_Khachhang.Id_Nganhang));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khuvuc", Ware_Dm_Khachhang.Id_Khuvuc));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nguoi_Daidien", Ware_Dm_Khachhang.Nguoi_Daidien));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Congno_Thang", Ware_Dm_Khachhang.Congno_Thang));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cap", Ware_Dm_Khachhang.Id_Cap));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tinhcongno", Ware_Dm_Khachhang.Tinhcongno));
                OleDbCommand.ExecuteNonQuery();
                //notify last change in data
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update đối tượng Ware_Dm_Khachhang vào DB.
        /// </summary>
        /// <param name="Ware_Dm_Khachhang"></param>
        /// <returns></returns>
        public object Update_Ware_Dm_Khachhang(Domain.MasterTables.Ware.Ware_Dm_Khachhang Ware_Dm_Khachhang)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Khachhang_Update", _SqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", Ware_Dm_Khachhang.Id_Khachhang));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Khachhang", Ware_Dm_Khachhang.Ma_Khachhang));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Khachhang", Ware_Dm_Khachhang.Ten_Khachhang));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Diachi_Khachhang", Ware_Dm_Khachhang.Diachi_Khachhang));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Masothue", Ware_Dm_Khachhang.Masothue));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dienthoai", Ware_Dm_Khachhang.Dienthoai));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Fax", Ware_Dm_Khachhang.Fax));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Email", Ware_Dm_Khachhang.Email));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Website", Ware_Dm_Khachhang.Website));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Sinh", Ware_Dm_Khachhang.Ngay_Sinh));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dinhmuc_No", Ware_Dm_Khachhang.Dinhmuc_No));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Cmnd", Ware_Dm_Khachhang.Cmnd));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Pb_Tochuc", Ware_Dm_Khachhang.Pb_Tochuc));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotaikhoan", Ware_Dm_Khachhang.Sotaikhoan));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nganhang", Ware_Dm_Khachhang.Id_Nganhang));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khuvuc", Ware_Dm_Khachhang.Id_Khuvuc));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nguoi_Daidien", Ware_Dm_Khachhang.Nguoi_Daidien));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Congno_Thang", Ware_Dm_Khachhang.Congno_Thang));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cap", Ware_Dm_Khachhang.Id_Cap));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tinhcongno", Ware_Dm_Khachhang.Tinhcongno));
                OleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete đối tượng Ware_Dm_Khachhang vào DB.
        /// </summary>
        /// <param name="Ware_Dm_Khachhang"></param>
        /// <returns></returns>
        public object Delete_Ware_Dm_Khachhang(Domain.MasterTables.Ware.Ware_Dm_Khachhang Ware_Dm_Khachhang)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Khachhang_Delete", _SqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", Ware_Dm_Khachhang.Id_Khachhang));

                OleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// kiem tra Delete đối tượng Ware_Dm_Khachhang trong DB.
        /// </summary>
        /// <param name="Ware_Dm_Khachhang"></param>
        /// <returns></returns>
        public object CheckDelete_Ware_Dm_Khachhang(object id_khachhang)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Khachhang_CheckDelete", _SqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", id_khachhang));

                OleDbCommand.ExecuteNonQuery();
                //notify last change in data
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update Collection Ware_Dm_Khachhang vào DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Ware_Dm_Khachhang_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Dm_Khachhang", _SqlConnection);
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

        public object Update_Ware_Dm_Khachhang_Collection2(DataSet ds_Ware_Dm_Kho_Vattu)
        {
            try
            {
                DataSet dsI = ds_Ware_Dm_Kho_Vattu.GetChanges(DataRowState.Added);
                DataSet dsU = ds_Ware_Dm_Kho_Vattu.GetChanges(DataRowState.Modified);
                DataSet dsD = ds_Ware_Dm_Kho_Vattu.GetChanges(DataRowState.Deleted);

                if (dsI != null)
                    foreach (DataRow dr in dsI.Tables[0].Rows)
                        this.Insert_Ware_Dm_Khachhang(this.Get_Ware_Dm_Khachhang(dr));
                if (dsU != null)
                    foreach (DataRow dr in dsU.Tables[0].Rows)
                        this.Update_Ware_Dm_Khachhang(this.Get_Ware_Dm_Khachhang(dr));
                if (dsD != null)
                {
                    dsD.RejectChanges();
                    foreach (DataRow dr in dsD.Tables[0].Rows)
                        this.Delete_Ware_Dm_Khachhang(this.Get_Ware_Dm_Khachhang(dr));
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Delete_Ware_Khachhang_Quota(object id_khachhang)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Khachhang_Quota_Delete", _SqlConnection);
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", id_khachhang));
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Update_Ware_Dm_Khachhang_Nhansu_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Dm_Khachhang_Nhansu", _SqlConnection);
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

        public string Ware_Dm_Khachhang_Nhansu_SelectAll()
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Khachhang_Nhansu_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Ware_Dm_Khachhang_LJoinNhansu()
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Khachhang_LJoinNhansu", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public object Ware_Dm_Khachhang_Nhansu_SelectChietkhau(object Id_Khachhang)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Khachhang_Nhansu_SelectChietkhau", this._SqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", Id_Khachhang));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chietkhau", System.Data.OleDb.OleDbType.Decimal));
                OleDbCommand.Parameters["@Chietkhau"].Direction = ParameterDirection.Output;
                OleDbCommand.ExecuteNonQuery();
                return OleDbCommand.Parameters["@Chietkhau"].Value; ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string Ware_Dm_Khachhang_SelectCongno_ById(object Id_Khachhang)
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Khachhang_SelectCongno_ById", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@d_Khachhang", Id_Khachhang));
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }
    }
}