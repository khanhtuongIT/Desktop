using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Ecm.Service.Bar
{
    public class Bar_Winecard_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _sqlConnection;
        #endregion

        #region Costructor
        public Bar_Winecard_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._sqlConnection = sqlConnection;
        }
        #endregion

        #region Methods
        public string Get_All_Bar_Winecard(object Id_Cuahang_Ban, object ThangNam, object Id_Khachhang)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Winecard_Selectall", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@ThangNam", ThangNam));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", Id_Khachhang));

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

        public string GetBar_Winecard_ById(object Id_Winecard)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Winecard_SelectById", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Winecard", Id_Winecard));

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
        public object Insert_Bar_Winecard(Domain.Bar.Bar_Winecard bar_winecard)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Winecard_Insert", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Winecard", System.Data.OleDb.OleDbType.BigInt));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", bar_winecard.Id_Khachhang));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", bar_winecard.Ngay_Batdau));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", bar_winecard.Ngay_Ketthuc));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Lap", bar_winecard.Id_Nhansu_Lap));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Xnhan", bar_winecard.Id_Nhansu_Xnhan));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@So_Chungtu", bar_winecard.So_Chungtu));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Ban", bar_winecard.Id_Hanghoa_Ban));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", bar_winecard.Ghichu));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", bar_winecard.Id_Cuahang_Ban));

                OleDbCommand.Parameters["@Id_Winecard"].Direction = ParameterDirection.Output;

                OleDbCommand.ExecuteNonQuery();

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Winecard", DateTime.Now);
                }
                return OleDbCommand.Parameters["@Id_Winecard"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object Update_Bar_Winecard(Domain.Bar.Bar_Winecard bar_winecard)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Winecard_Update", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Winecard", bar_winecard.Id_Winecard));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", bar_winecard.Id_Khachhang));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", bar_winecard.Ngay_Batdau));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", bar_winecard.Ngay_Ketthuc));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Lap", bar_winecard.Id_Nhansu_Lap));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Xnhan", bar_winecard.Id_Nhansu_Xnhan));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@So_Chungtu", bar_winecard.So_Chungtu));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_Ban", bar_winecard.Id_Hanghoa_Ban));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", bar_winecard.Ghichu));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", bar_winecard.Id_Cuahang_Ban));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Return", bar_winecard.Id_Nhansu_Return));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Return", bar_winecard.Ngay_Return));

                OleDbCommand.ExecuteNonQuery();

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Winecard", DateTime.Now);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object Delete_Bar_Winecard(Domain.Bar.Bar_Winecard bar_winecard)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Winecard_Delete", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Winecard", bar_winecard.Id_Winecard));
                OleDbCommand.ExecuteNonQuery();

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Winecard", DateTime.Now);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object Update_Bar_Winecard_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("Select * From Bar_Winecard", this._sqlConnection);
                System.Data.OleDb.OleDbCommandBuilder OleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(OleDbDataAdapter);
                OleDbDataAdapter = OleDbCommandBuilder.DataAdapter;

                OleDbDataAdapter.Update(dsCollection, "GridTable");

                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._sqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Bar_Winecard", DateTime.Now);
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
    }
}
