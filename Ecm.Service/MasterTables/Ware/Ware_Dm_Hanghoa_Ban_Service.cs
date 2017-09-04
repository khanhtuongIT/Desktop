using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.MasterTables.Ware
{
    public class Ware_Dm_Hanghoa_Ban_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Constructor
        public Ware_Dm_Hanghoa_Ban_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService
        /// <summary>
        /// Trả về một dataset Ware_Dm_Hanghoa_Ban
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Dm_Hanghoa_Ban_By_Nguyenlieu_Chebien()
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Hanghoa_Ban_SelectAll_By_Nguyenlieu_Chebien", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");

             return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Trả về một dataset Ware_Dm_Hanghoa_Ban
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Dm_Hanghoa_Ban()
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Hanghoa_Ban_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");

            //            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Ware_Dm_Hanghoa_Ban_Select_By_Id_Nhansu(object Id_Nhansu)
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Hanghoa_Ban_Select_By_Id_Nhansu", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Id_Nhansu));
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        /// <summary>
        /// Trả về một dataset Ware_Dm_Hanghoa_Ban (bao gom table Ware_Hanghoa_Dinhgia) By Id_Loai_Hanghoa_Ban 
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Dm_Hanghoa_Ban_By_Id_Loai_Hanghoa_Ban(object id_loai_hanghoa_ban)
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Hanghoa_Ban_Select_By_Loai_Hanghoa_Ban", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Loai_Hanghoa_Ban", id_loai_hanghoa_ban));
            oleDbCommand.CommandType = CommandType.StoredProcedure;


            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");

                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }


        /// <summary>
        /// Trả về một dataset Ware_Dm_Hanghoa_Ban By Id_Loai_Hanghoa_Ban (dùng cho form Danh mục/Hàng hóa)
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Dm_Hanghoa_Ban_By_Id_Loai_Hh_Ban_None_Dinhgia(object id_loai_hanghoa_ban, object Ma_Hanghoa_Ban, object Ten_Hanghoa_Ban, object Barcode_Txt)
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Hanghoa_Ban_Select_By_Loai_Hanghoa_Ban_None_Dinhgia", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Loai_Hanghoa_Ban", id_loai_hanghoa_ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Hanghoa_Ban", Ma_Hanghoa_Ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Hanghoa_Ban", Ten_Hanghoa_Ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Barcode_Txt", Barcode_Txt));
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");

            return FastJSON.JSON.Instance.ToJSON(dsCollection);//            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None);  
        }

        /// <summary>
        /// Trả về một dataset Ware_Dm_Hanghoa_Ban By Ma_hanghoa_Ban (dùng cho form Danh mục/Hàng hóa)
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Dm_Hanghoa_Ban_By_Ma_Hanghoa_Ban(object Ma_Hanghoa_Ban)
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Hanghoa_Ban_Select_By_Ma_Hanghoa_Ban", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Hanghoa_Ban", Ma_Hanghoa_Ban));
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");

                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Trả về một dataset Ware_Dm_Hanghoa_Ban By Ten_Hanghoa_Ban (dùng cho form Danh mục/Hàng hóa)
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Dm_Hanghoa_Ban_By_Ten_Hanghoa_Ban(object Ten_Hanghoa_Ban)
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Hanghoa_Ban_Select_By_Ten_Hanghoa_Ban", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Hanghoa_Ban", Ten_Hanghoa_Ban));
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");

                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Trả về một dataset Ware_Dm_Hanghoa_Ban By Barcode (dùng cho form Danh mục/Hàng hóa)
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Dm_Hanghoa_Ban_By_Barcode_Txt(object Barcode_Txt)
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Hanghoa_Ban_Select_By_Barcode_Txt", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Barcode_Txt", Barcode_Txt));
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");

                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Trả về một dataset Ware_Dm_Hanghoa_Ban By Id_Cuahang_Ban(Ware_Dm_Hh_Cuahang_Ban)
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Dm_Hanghoa_Ban_By_Id_Cuahang_Ban(object id_cuahang_ban, object ngay_chungtu)
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Hanghoa_Ban_SelectBy_Id_Cuahang_Ban", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", id_cuahang_ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@ngay_chungtu", ngay_chungtu));
            oleDbCommand.CommandType = CommandType.StoredProcedure;


            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");

                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Trả về một dataset Ware_Dm_Hanghoa_Ban By Id_Cuahang_Ban(Ware_Dm_Hh_Cuahang_Ban)
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Dm_Hanghoa_Ban_InMenu(object ngay_chungtu)
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Hanghoa_Ban_Select_Inmenu", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@ngay_chungtu", ngay_chungtu));
            oleDbCommand.CommandType = CommandType.StoredProcedure;


            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");

                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Get_All_Ware_Dm_Hanghoa_Ban_By_Id_Cuahang_Ban_From_Nhap_Hanghoa(object id_cuahang_ban)
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Hanghoa_Ban_SelectBy_Id_Cuahang_Ban_From_Nhap_Hanghoa", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", id_cuahang_ban));
            oleDbCommand.CommandType = CommandType.StoredProcedure;


            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");

                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Insert đối tượng Ware_Dm_Hanghoa_Ban vào DB.
        /// </summary>
        /// <param name="ware_Dm_Donvitinh"></param>
        /// <returns></returns>
        public Object Insert_Ware_Dm_Hanghoa_Ban(Ecm.Domain.MasterTables.Ware.Ware_Dm_Hanghoa_Ban Ware_Dm_Hanghoa_Ban)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Hanghoa_Ban_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Hanghoa_Ban", Ware_Dm_Hanghoa_Ban.Ma_Hanghoa_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Hanghoa_Ban", Ware_Dm_Hanghoa_Ban.Ten_Hanghoa_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Loai_Hanghoa_Ban", Ware_Dm_Hanghoa_Ban.Id_Loai_Hanghoa_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Quycach", Ware_Dm_Hanghoa_Ban.Quycach));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Size", Ware_Dm_Hanghoa_Ban.Size));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Donvitinh", Ware_Dm_Hanghoa_Ban.Id_Donvitinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong_Min", Ware_Dm_Hanghoa_Ban.Soluong_Min));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Barcode_Txt", Ware_Dm_Hanghoa_Ban.Barcode_Txt));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Hinh", Ware_Dm_Hanghoa_Ban.Hinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dongia_Mua", Ware_Dm_Hanghoa_Ban.Dongia_Mua));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Hamluong", Ware_Dm_Hanghoa_Ban.Hamluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Xuatxu", Ware_Dm_Hanghoa_Ban.Xuatxu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhasanxuat", Ware_Dm_Hanghoa_Ban.Id_Khachhang));
                oleDbCommand.ExecuteNonQuery();

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Ware_Dm_Hanghoa_Ban", DateTime.Now);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        /// <summary>
        /// Update đối tượng Ware_Dm_Hanghoa_Ban vào DB.
        /// </summary>
        /// <param name="ware_Dm_Donvitinh"></param>
        /// <returns></returns>
        public Object Update_Ware_Dm_Hanghoa_Ban(Ecm.Domain.MasterTables.Ware.Ware_Dm_Hanghoa_Ban Ware_Dm_Hanghoa_Ban)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Hanghoa_Ban_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Ban", Ware_Dm_Hanghoa_Ban.Id_Hanghoa_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Hanghoa_Ban", Ware_Dm_Hanghoa_Ban.Ma_Hanghoa_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Hanghoa_Ban", Ware_Dm_Hanghoa_Ban.Ten_Hanghoa_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Loai_Hanghoa_Ban", Ware_Dm_Hanghoa_Ban.Id_Loai_Hanghoa_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Quycach", Ware_Dm_Hanghoa_Ban.Quycach));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Size", Ware_Dm_Hanghoa_Ban.Size));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Donvitinh", Ware_Dm_Hanghoa_Ban.Id_Donvitinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Soluong_Min", Ware_Dm_Hanghoa_Ban.Soluong_Min));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Barcode_Txt", Ware_Dm_Hanghoa_Ban.Barcode_Txt));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Hinh", Ware_Dm_Hanghoa_Ban.Hinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dongia_Mua", Ware_Dm_Hanghoa_Ban.Dongia_Mua));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Hamluong", Ware_Dm_Hanghoa_Ban.Hamluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Xuatxu", Ware_Dm_Hanghoa_Ban.Xuatxu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhasanxuat", Ware_Dm_Hanghoa_Ban.Id_Khachhang));
                oleDbCommand.ExecuteNonQuery();

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Ware_Dm_Hanghoa_Ban", DateTime.Now);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        /// <summary>
        /// Delete đối tượng Ware_Dm_Hanghoa_Ban vào DB.
        /// </summary>
        /// <param name="ware_Dm_Donvitinh"></param>
        /// <returns></returns>
        public Object Delete_Ware_Dm_Hanghoa_Ban(Ecm.Domain.MasterTables.Ware.Ware_Dm_Hanghoa_Ban Ware_Dm_Hanghoa_Ban)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Hanghoa_Ban_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Ban", Ware_Dm_Hanghoa_Ban.Id_Hanghoa_Ban));

                oleDbCommand.ExecuteNonQuery();

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Ware_Dm_Hanghoa_Ban", DateTime.Now);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        /// <summary>
        /// Update Collection Ware_Dm_Hanghoa_Ban vào DB.
        /// </summary>
        /// <param name="ware_Dm_Donvitinh"></param>
        /// <returns></returns>
        public Object Update_Ware_Dm_Hanghoa_Ban_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Dm_Hanghoa_Ban", this._SqlConnection);
                System.Data.OleDb.OleDbCommandBuilder oleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(oleDbDataAdapter);
                oleDbDataAdapter = oleDbCommandBuilder.DataAdapter;

                oleDbDataAdapter.Update(dsCollection, "GridTable");

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Ware_Dm_Hanghoa_Ban", DateTime.Now);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public string Get_All_Ware_Dm_Hanghoa_Ban_Import(string block_no)
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Hanghoa_Ban_Import_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@block_no", block_no));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");

                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public Object Update_Ware_Dm_Hanghoa_Ban_Import_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Dm_Hanghoa_Ban_Import", this._SqlConnection);
                System.Data.OleDb.OleDbCommandBuilder oleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(oleDbDataAdapter);
                oleDbDataAdapter = oleDbCommandBuilder.DataAdapter;

                oleDbDataAdapter.Update(dsCollection, "GridTable");

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Ware_Dm_Hanghoa_Ban", DateTime.Now);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public Object InsertBatch_Ware_Dm_Hanghoa_Ban_Import(string block_no)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Hanghoa_Ban_Import_InsertBatch", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@block_no", block_no));

                oleDbCommand.ExecuteNonQuery();

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Ware_Dm_Hanghoa_Ban", DateTime.Now);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        #region Quy doi hang hoa mua --> tinh nguyen lieu sx
        /// <summary>
        /// Bang tinh nguyen lieu lam banh
        /// </summary>
        /// <returns></returns>
        public string Ware_Hhban_Quydoi_Hhmua_SelectAll()
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hhban_Quydoi_Hhmua_SelectAll", this._SqlConnection);

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");

                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Bang tinh nguyen lieu lam banh
        /// </summary>
        /// <returns></returns>
        public string Ware_Hhban_Quydoi_Hhmua_SelectByKhhhban(object Id_Kh_Hh_Ban)
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hhban_Quydoi_Hhmua_SelectByKhhhban", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kh_Hh_Ban", Id_Kh_Hh_Ban));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");

                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Bang tinh nguyen lieu lam banh
        /// </summary>
        /// <returns></returns>
        public string Ware_Hhban_Quydoi_Hhmua_SelectByHhsx(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Cuahang_Ban, object Filter_Cond)
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hhban_Quydoi_Hhmua_SelectByHhsx", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", Ngay_Batdau));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", Ngay_Ketthuc));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@@Filter_Cond", Filter_Cond));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");

                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// lap bang tinh nguyen lieu lam banh + gia von
        /// </summary>
        /// <returns></returns>
        public Object Ware_Hhban_Quydoi_Hhmua_Init()
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hhban_Quydoi_Hhmua_Init", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

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
        /// get ds đơn vị tính quy đổi ứng với id_hanghoa_Ban
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public string Ware_Dm_Donvitinh_Quydoi_By_Id_Hanghoa_Ban(object Id_Hanghoa_Ban)
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Donvitinh_Quydoi_By_Id_Hanghoa_Ban", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Ban", Id_Hanghoa_Ban));


            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");

                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }


        #endregion
        #endregion
    }
}
