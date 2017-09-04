using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Ware
{
    public class Ware_Hanghoa_Dinhgia_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Ware_Hanghoa_Dinhgia_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService
        /// <summary>
        /// Trả về một dataset Quytm_Dauky
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Hanghoa_Dinhgia()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hanghoa_Dinhgia_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }


        /// <summary>
        /// Ware_Hanghoa_Dinhgia_SelectAll_By_Id_Hang hoa mua
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Hanghoa_Dinhgia_By_Id_Loai_hh(object id_Loai_Hh)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hanghoa_Dinhgia_SelectAll_By_Id_Loai_Hh", this._SqlConnection);
            //oleDbCommand.Parameters.Add("@Id_Loai_Hanghoa_Ban", id_Loai_Hh);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Loai_Hanghoa_Ban", id_Loai_Hh));

            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Trả về dataset chứa các hàng hóa có giá tại thời điểm hiện tại theo loại hàng hóa
        /// </summary>
        /// <param name="id_loai_hanghoa"></param>
        /// <param name="ngay_chungtu"></param>
        /// <returns></returns>
        public string Get_All_Ware_Hanghoa_Dinhgia_By_Loai_HH_By_Date(object id_loai_hanghoa, object ngay_chungtu)
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hanghoa_Dinhgia_SelectAll_Hhban_By_Loai_HH_By_Date", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Loai_Hanghoa_Ban", id_loai_hanghoa));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", ngay_chungtu));
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// get hang hoa dinh gia by id_hanghoa_ban
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Hanghoa_Dinhgia_By_Id_HhBan(object id_hanghoa_ban)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hanghoa_Dinhgia_Select_By_Id_HhBan", this._SqlConnection);
            //oleDbCommand.Parameters.Add("@Id_Loai_Hanghoa_Ban", id_Loai_Hh);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Ban", id_hanghoa_ban));

            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }
        
        /// <summary>
        /// get hang hoa dinh gia theo cap by id_hanghoa_ban
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Hanghoa_Dinhgia_By_Id_HhBan_TheoCap(object id_hanghoa_ban)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hanghoa_Dinhgia_SelectBy_Id_HhBan_TheoCap", this._SqlConnection);
            //oleDbCommand.Parameters.Add("@Id_Loai_Hanghoa_Ban", id_Loai_Hh);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Ban", id_hanghoa_ban));

            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Ware_Hanghoa_Dinhgia_Log_SelectAll
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Hanghoa_Dinhgia_Log()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hanghoa_Dinhgia_Log_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }


        /// <summary>
        /// Ware_Hanghoa_Dinhgia_Log_SelectAll by Id_Loai_Hanghoa_Ban
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Hanghoa_Dinhgia_Log_By_Id_LoaiHh(object Id_Loai_Hanghoa)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hanghoa_Dinhgia_Log_Select_By_LoaiHh", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Loai_Hanghoa_Ban", Id_Loai_Hanghoa));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Trả về một dataset Ware_Hanghoa_Mua_Dinhgia_SelectAll
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Hanghoa_Mua_Dinhgia()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hanghoa_Dinhgia_SelectAll_Hhmua", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }
        /// <summary>
        /// Trả về một dataset Ware_Hanghoa_Mua_Dinhgia_SelectAll
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Hanghoa_Mua_Dinhgia_ByDate(object Ngay_Chungtu)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hanghoa_Dinhgia_SelectAll_Hhmua", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Ngay_Chungtu", Ngay_Chungtu));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }
        /// <summary>
        /// Trả về một dataset Ware_Hanghoa_Ban_Dinhgia_SelectAll
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Hanghoa_Ban_Dinhgia()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hanghoa_Dinhgia_SelectAll_Hhban", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Search_Ware_Hanghoa_Ban_Dinhgia(Ecm.Domain.MasterTables.Ware.Ware_Dm_Hanghoa_Ban ware_Dm_Hanghoa_Ban)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hanghoa_Dinhgia_SelectAll_Hhban", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", DateTime.Now));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Hanghoa_Ban", ware_Dm_Hanghoa_Ban.Ma_Hanghoa_Ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Hanghoa_Ban", ware_Dm_Hanghoa_Ban.Ten_Hanghoa_Ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Barcode_Txt", ware_Dm_Hanghoa_Ban.Barcode_Txt));
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }


        /// <summary>
        /// Trả về một dataset Ware_Hanghoa_Ban_Dinhgia_SelectAll
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Hanghoa_Ban_Dinhgia_ByDate(object Ngay_Chungtu)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hanghoa_Dinhgia_SelectAll_Hhban", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", Ngay_Chungtu));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Insert đối tượng Ware_Hanghoa_Dinhgia vào DB.
        /// </summary>
        /// <param name="ware_Hanghoa_Dinhgia"></param>
        /// <returns></returns>
        public object Insert_Ware_Hanghoa_Dinhgia(Ecm.Domain.Ware.Ware_Hanghoa_Dinhgia ware_Hanghoa_Dinhgia)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hanghoa_Dinhgia_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Dinhgia", ware_Hanghoa_Dinhgia.Id_Hanghoa_Dinhgia));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Ban", ware_Hanghoa_Dinhgia.Id_Hanghoa_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Donvitinh", ware_Hanghoa_Dinhgia.Id_Donvitinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dongia_Ban", ware_Hanghoa_Dinhgia.Dongia_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", ware_Hanghoa_Dinhgia.Ngay_Batdau));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", ware_Hanghoa_Dinhgia.Ngay_Ketthuc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", ware_Hanghoa_Dinhgia.Ghichu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dongia", ware_Hanghoa_Dinhgia.Dongia));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dongia_Bansi", ware_Hanghoa_Dinhgia.Dongia_Bansi));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Barcode", ware_Hanghoa_Dinhgia.Barcode_Txt));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Stt", ware_Hanghoa_Dinhgia.Stt));
                oleDbCommand.Parameters["@Id_Hanghoa_Dinhgia"].Direction = System.Data.ParameterDirection.Output;
                oleDbCommand.ExecuteNonQuery();
                return oleDbCommand.Parameters["@Id_Hanghoa_Dinhgia"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update đối tượng Ware_Hanghoa_Dinhgia vào DB.
        /// </summary>
        /// <param name="ware_Hanghoa_Dinhgia"></param>
        /// <returns></returns>
        public object Update_Ware_Hanghoa_Dinhgia(Ecm.Domain.Ware.Ware_Hanghoa_Dinhgia ware_Hanghoa_Dinhgia)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hanghoa_Dinhgia_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Dinhgia", ware_Hanghoa_Dinhgia.Id_Hanghoa_Dinhgia));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Ban", ware_Hanghoa_Dinhgia.Id_Hanghoa_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Donvitinh", ware_Hanghoa_Dinhgia.Id_Donvitinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dongia_Ban", ware_Hanghoa_Dinhgia.Dongia_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", ware_Hanghoa_Dinhgia.Ngay_Batdau));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", ware_Hanghoa_Dinhgia.Ngay_Ketthuc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", ware_Hanghoa_Dinhgia.Ghichu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dongia", ware_Hanghoa_Dinhgia.Dongia));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dongia_Bansi", ware_Hanghoa_Dinhgia.Dongia_Bansi));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Barcode", ware_Hanghoa_Dinhgia.Barcode_Txt));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Stt", ware_Hanghoa_Dinhgia.Stt));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete đối tượng Ware_Hanghoa_Dinhgia vào DB.
        /// </summary>
        /// <param name="ware_Hanghoa_Dinhgia"></param>
        /// <returns></returns>
        public object Delete_Ware_Hanghoa_Dinhgia(Ecm.Domain.Ware.Ware_Hanghoa_Dinhgia ware_Hanghoa_Dinhgia)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hanghoa_Dinhgia_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Dinhgia", ware_Hanghoa_Dinhgia.Id_Hanghoa_Dinhgia));
                oleDbCommand.ExecuteNonQuery();
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Ware_Hanghoa_Dinhgia", DateTime.Now);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update một Collection Ware_Hanghoa_Dinhgia vào DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Ware_Hanghoa_Dinhgia_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Hanghoa_Dinhgia", _SqlConnection);
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

        /// <summary>
        /// update collection of rows in Ware_Hanghoa_Dinhgia_Log
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Ware_Hanghoa_Dinhgia_Log_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Hanghoa_Dinhgia_Log", _SqlConnection);
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

        /// <summary>
        /// Trả về một dataset Ware_Hanghoa_Ban_Dinhgia by Ten_hanghoa_ban
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Hanghoa_Ban_Dinhgia_By_Ten_Hanghoa(object Ten_Hanghoa_Ban)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hanghoa_Dinhgia_Select_By_Ten_Hanghoa_Ban", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Hanghoa_Ban", Ten_Hanghoa_Ban));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Trả về một dataset Ware_Hanghoa_Ban_Dinhgia by Ma_hanghoa_ban
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Hanghoa_Ban_Dinhgia_By_Ma_Hanghoa(object Ma_Hanghoa_Ban)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hanghoa_Dinhgia_Select_By_Ma_Hanghoa_Ban", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Hanghoa_Ban", Ma_Hanghoa_Ban));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Trả về một dataset Ware_Hanghoa_Ban_Dinhgia by Barcode_txt
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Hanghoa_Ban_Dinhgia_By_Barcode(object Barcode_Txt)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hanghoa_Dinhgia_Select_By_Barcode", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Barcode", Barcode_Txt));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        #endregion
    }
}
