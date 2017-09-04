using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Ecm.Service.Bar
{
    public class Bar_Rent_Reserve_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _sqlConnection;
        #endregion

        #region Costructor
        public Bar_Rent_Reserve_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._sqlConnection = sqlConnection;
        }
        #endregion

        #region Methods
        public string Get_All_Bar_Rent_Reserve(object ThangNam, object Id_Cuahang_Ban)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Reserve_Selectall", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@ThangNam", ThangNam));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));

                System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(OleDbCommand);
                OleDbDataAdapter.Fill(dsCollection, "GridTable");

                return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }

        public string Get_All_Bar_Rent_Reserve_ByArrivalDate(object ThangNam, object Id_Cuahang_Ban)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Reserve_SelectByArrivalDate", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@ThangNam", ThangNam));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));

                System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(OleDbCommand);
                OleDbDataAdapter.Fill(dsCollection, "GridTable");

                return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }
     
        public string GetBar_Rent_Reserve_ById(object Id_Reserve)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Reserve_SelectById", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Reserve", Id_Reserve));

                System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(OleDbCommand);
                OleDbDataAdapter.Fill(dsCollection, "GridTable");
                return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }
       
        public object Insert_Bar_Rent_Reserve(Domain.Bar.Bar_Rent_Reserve bar_rent_reserve)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Reserve_Insert", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Reserve", System.Data.OleDb.OleDbType.BigInt));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", bar_rent_reserve.Id_Khachhang));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", bar_rent_reserve.Ngay_Batdau));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", bar_rent_reserve.Ngay_Ketthuc));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Class", bar_rent_reserve.Id_Class));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong_Phong", bar_rent_reserve.Soluong_Phong));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong_Khach", bar_rent_reserve.Soluong_Khach));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Reserver_Hoten", bar_rent_reserve.Reserver_Hoten));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Reserver_Cmnd", bar_rent_reserve.Reserver_Cmnd));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Reserver_Tel", bar_rent_reserve.Reserver_Tel));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chietkhau_Tyle", bar_rent_reserve.Chietkhau_Tyle));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chietkhau_Tienmat", bar_rent_reserve.Chietkhau_Tienmat));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Reserver_Email", bar_rent_reserve.Reserver_Email));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thanhtoantruoc", bar_rent_reserve.Thanhtoantruoc));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", bar_rent_reserve.Ngay_Chungtu));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@So_Chungtu", bar_rent_reserve.So_Chungtu));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Ctu", bar_rent_reserve.Id_Nhansu_Ctu));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", bar_rent_reserve.Ghichu));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", bar_rent_reserve.Id_Cuahang_Ban));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Reserve", bar_rent_reserve.Guid_Reserve));



                OleDbCommand.Parameters["@Id_Reserve"].Direction = ParameterDirection.Output;

                OleDbCommand.ExecuteNonQuery();

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Rent_Reserve", DateTime.Now);
                }
                return OleDbCommand.Parameters["@Id_Reserve"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object Update_Bar_Rent_Reserve(Domain.Bar.Bar_Rent_Reserve bar_rent_reserve)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Reserve_Update", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Reserve", bar_rent_reserve.Id_Reserve));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", bar_rent_reserve.Id_Khachhang));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", bar_rent_reserve.Ngay_Batdau));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", bar_rent_reserve.Ngay_Ketthuc));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Class", bar_rent_reserve.Id_Class));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong_Phong", bar_rent_reserve.Soluong_Phong));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong_Khach", bar_rent_reserve.Soluong_Khach));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Reserver_Hoten", bar_rent_reserve.Reserver_Hoten));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Reserver_Cmnd", bar_rent_reserve.Reserver_Cmnd));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Reserver_Tel", bar_rent_reserve.Reserver_Tel));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chietkhau_Tyle", bar_rent_reserve.Chietkhau_Tyle));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chietkhau_Tienmat", bar_rent_reserve.Chietkhau_Tienmat));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Reserver_Email", bar_rent_reserve.Reserver_Email));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thanhtoantruoc", bar_rent_reserve.Thanhtoantruoc));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", bar_rent_reserve.Ngay_Chungtu));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@So_Chungtu", bar_rent_reserve.So_Chungtu));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Ctu", bar_rent_reserve.Id_Nhansu_Ctu));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", bar_rent_reserve.Ghichu));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", bar_rent_reserve.Id_Cuahang_Ban));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Reserve", bar_rent_reserve.Guid_Reserve));

                OleDbCommand.ExecuteNonQuery();

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Rent_Reserve", DateTime.Now);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object Delete_Bar_Rent_Reserve(Domain.Bar.Bar_Rent_Reserve bar_rent_reserve)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Reserve_Delete", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Reserve", bar_rent_reserve.Id_Reserve));
                OleDbCommand.ExecuteNonQuery();

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Rent_Reserve", DateTime.Now);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object Update_Bar_Rent_Reserve_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter();

                oleDbDataAdapter.SelectCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Reserve_Selectall", _sqlConnection);
                oleDbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                oleDbDataAdapter.InsertCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Reserve_Insert", _sqlConnection);
                oleDbDataAdapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Reserve", System.Data.OleDb.OleDbType.BigInt));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Khachhang"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", System.Data.OleDb.OleDbType.DBTimeStamp, 18, "Ngay_Batdau"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", System.Data.OleDb.OleDbType.DBTimeStamp, 18, "Ngay_Ketthuc"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Class", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Class"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong_Phong", System.Data.OleDb.OleDbType.Decimal, 18, "Soluong_Phong"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong_Khach", System.Data.OleDb.OleDbType.Decimal, 18, "Soluong_Khach"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Reserver_Hoten", System.Data.OleDb.OleDbType.VarWChar, 18, "Reserver_Hoten"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Reserver_Cmnd", System.Data.OleDb.OleDbType.VarWChar, 18, "Reserver_Cmnd"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Reserver_Tel", System.Data.OleDb.OleDbType.VarWChar, 18, "Reserver_Tel"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chietkhau_Tyle", System.Data.OleDb.OleDbType.Decimal, 18, "Chietkhau_Tyle"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chietkhau_Tienmat", System.Data.OleDb.OleDbType.Decimal, 18, "Chietkhau_Tienmat"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Reserver_Email", System.Data.OleDb.OleDbType.VarWChar, 18, "Reserver_Email"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thanhtoantruoc", System.Data.OleDb.OleDbType.Boolean, 18, "Thanhtoantruoc"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", System.Data.OleDb.OleDbType.DBTimeStamp, 18, "Ngay_Chungtu"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@So_Chungtu", System.Data.OleDb.OleDbType.VarWChar, 18, "So_Chungtu"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Ctu", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Nhansu_Ctu"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Cuahang_Ban"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Reserve", System.Data.OleDb.OleDbType.Guid, 18, "Guid_Reserve"));

                oleDbDataAdapter.UpdateCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Reserve_Update", _sqlConnection);
                oleDbDataAdapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Reserve", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Reserve"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Khachhang"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", System.Data.OleDb.OleDbType.DBTimeStamp, 18, "Ngay_Batdau"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", System.Data.OleDb.OleDbType.DBTimeStamp, 18, "Ngay_Ketthuc"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Class", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Class"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong_Phong", System.Data.OleDb.OleDbType.Decimal, 18, "Soluong_Phong"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong_Khach", System.Data.OleDb.OleDbType.Decimal, 18, "Soluong_Khach"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Reserver_Hoten", System.Data.OleDb.OleDbType.VarWChar, 18, "Reserver_Hoten"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Reserver_Cmnd", System.Data.OleDb.OleDbType.VarWChar, 18, "Reserver_Cmnd"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Reserver_Tel", System.Data.OleDb.OleDbType.VarWChar, 18, "Reserver_Tel"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chietkhau_Tyle", System.Data.OleDb.OleDbType.Decimal, 18, "Chietkhau_Tyle"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chietkhau_Tienmat", System.Data.OleDb.OleDbType.Decimal, 18, "Chietkhau_Tienmat"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Reserver_Email", System.Data.OleDb.OleDbType.VarWChar, 18, "Reserver_Email"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thanhtoantruoc", System.Data.OleDb.OleDbType.Boolean, 18, "Thanhtoantruoc"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", System.Data.OleDb.OleDbType.DBTimeStamp, 18, "Ngay_Chungtu"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@So_Chungtu", System.Data.OleDb.OleDbType.VarWChar, 18, "So_Chungtu"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Ctu", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Nhansu_Ctu"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Cuahang_Ban"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Reserve", System.Data.OleDb.OleDbType.Guid, 18, "Guid_Reserve"));

                oleDbDataAdapter.DeleteCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Reserve_Delete", _sqlConnection);
                oleDbDataAdapter.DeleteCommand.CommandType = CommandType.StoredProcedure;
                oleDbDataAdapter.DeleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Reserve", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Reserve"));

                oleDbDataAdapter.Update(dsCollection, "GridTable");

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Rent_Reserve", DateTime.Now);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        #region  Bar_Rent_Reserve_Table
        public string Get_All_Bar_Rent_Reserve_Table(object Guid_Reserve)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Reserve_Table_Selectall", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Reserve", Guid_Reserve));

                System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(OleDbCommand);
                OleDbDataAdapter.Fill(dsCollection, "GridTable");

                return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }

        public object Update_Bar_Rent_Reserve_Table_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter();

                oleDbDataAdapter.SelectCommand = new System.Data.OleDb.OleDbCommand("Select * from Bar_Rent_Reserve_Table", _sqlConnection);
                oleDbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                oleDbDataAdapter.InsertCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Reserve_Table_Insert", _sqlConnection);
                oleDbDataAdapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Reserve_Table", System.Data.OleDb.OleDbType.BigInt));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Reserve", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Reserve"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Table", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Table"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Reserve", System.Data.OleDb.OleDbType.Guid, 18, "Guid_Reserve"));

                oleDbDataAdapter.UpdateCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Reserve_Table_Update", _sqlConnection);
                oleDbDataAdapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Reserve_Table", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Reserve_Table"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Reserve", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Reserve"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Table", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Table"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Reserve", System.Data.OleDb.OleDbType.Guid, 18, "Guid_Reserve"));

                oleDbDataAdapter.DeleteCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Reserve_Table_Delete", _sqlConnection);
                oleDbDataAdapter.DeleteCommand.CommandType = CommandType.StoredProcedure;
                oleDbDataAdapter.DeleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Reserve_Table", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Reserve_Table"));

                oleDbDataAdapter.Update(dsCollection, "GridTable");

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Rent_Reserve", DateTime.Now);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }
        #endregion

        #region  Bar_Rent_Reserve_Phieuthu
        public string Get_All_Bar_Rent_Reserve_Phieuthu(object Guid_Reserve)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Reserve_Phieuthu_Selectall", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Reserve", Guid_Reserve));

                System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(OleDbCommand);
                OleDbDataAdapter.Fill(dsCollection, "GridTable");

                return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }

        public object Update_Bar_Rent_Reserve_Phieuthu_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter();

                oleDbDataAdapter.SelectCommand = new System.Data.OleDb.OleDbCommand("Select * from Bar_Rent_Reserve_Phieuthu", _sqlConnection);
                oleDbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                oleDbDataAdapter.InsertCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Reserve_Phieuthu_Insert", _sqlConnection);
                oleDbDataAdapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Reserve_Phieuthu", System.Data.OleDb.OleDbType.BigInt));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Reserve", System.Data.OleDb.OleDbType.Guid, 18, "Guid_Reserve"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Phieu_Thu", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Phieu_Thu"));
                oleDbDataAdapter.InsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Reserve", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Reserve"));

                oleDbDataAdapter.UpdateCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Reserve_Phieuthu_Update", _sqlConnection);
                oleDbDataAdapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Reserve_Phieuthu", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Reserve_Phieuthu"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Guid_Reserve", System.Data.OleDb.OleDbType.Guid, 18, "Guid_Reserve"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Phieu_Thu", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Phieu_Thu"));
                oleDbDataAdapter.UpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Reserve", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Reserve"));

                oleDbDataAdapter.DeleteCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Reserve_Phieuthu_Delete", _sqlConnection);
                oleDbDataAdapter.DeleteCommand.CommandType = CommandType.StoredProcedure;
                oleDbDataAdapter.DeleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Reserve_Phieuthu", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Reserve_Phieuthu"));

                oleDbDataAdapter.Update(dsCollection, "GridTable");

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Rent_Reserve", DateTime.Now);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }
        #endregion

        public string Get_Bar_Rent_Reserve_Table_Lookup(object Id_Cuahang_Ban, object Ngay_Batdau, object Ngay_Ketthuc)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Rent_Reserve_Table_Lookup", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", Ngay_Batdau));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", Ngay_Ketthuc));

                System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(OleDbCommand);
                OleDbDataAdapter.Fill(dsCollection, "GridTable");

                return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }
        
        #endregion
    }
}
