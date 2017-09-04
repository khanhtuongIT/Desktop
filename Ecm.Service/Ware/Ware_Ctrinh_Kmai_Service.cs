using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Ware
{
    public class Ware_Ctrinh_Kmai_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Ware_Ctrinh_Kmai_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService

        /// <summary>
        /// Trả về một dataset Ware_Ctrinh_Kmai
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Ctrinh_Kmai()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Ctrinh_Kmai_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Trả về một dataset Ware_Ctrinh_Kmai (khách sạn)
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Ctrinh_Kmai_Rent()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Ctrinh_Kmai_Rent_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }


        public string Get_All_Ware_Ctrinh_Kmai_ByDate(object Ngay_Thanhtoan, object Rent) 
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Ctrinh_Kmai_SelectByDate", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Thanhtoan", Ngay_Thanhtoan));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Rent", Rent));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Get_All_Ware_Ctrinh_Kmai_Chitiet_By_Ctrinh_Kmai(object Id_Ctrinh_Kmai)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Ctrinh_Kmai_Chitiet_SelectByFK", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Ctrinh_Kmai",Id_Ctrinh_Kmai));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        // select khuyến mãi khách sạn chi tiết
        public string Get_All_Ware_Ctrinh_Kmai_Rent_Chitiet_By_Ctrinh_Kmai(object Id_Ctrinh_Kmai)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Ctrinh_Kmai_Chitiet_Rent_SelectByFK", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Ctrinh_Kmai", Id_Ctrinh_Kmai));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Get_All_Ware_Ctrinh_Kmai_Chitiet_ByDate(object Ngay_Thanhtoan)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Ctrinh_Kmai_Chitiet_SelectByDate", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Thanhtoan", Ngay_Thanhtoan));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Ware_Ctrinh_Kmai_Chitiet_SelectByDate_WithHanghoa(object Ngay_Thanhtoan, object Rent) // rent = True --> KM Khách sạn
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Ctrinh_Kmai_Chitiet_SelectByDate_WithHanghoa", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Thanhtoan", Ngay_Thanhtoan));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Rent", Rent));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Insert đối tượng Ware_Ctrinh_Kmai vào DB.
        /// </summary>
        /// <param name="Ware_Ctrinh_Kmai"></param>
        /// <returns></returns>
        public object Insert_Ware_Ctrinh_Kmai(Ecm.Domain.Ware.Ware_Ctrinh_Kmai Ware_Ctrinh_Kmai)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Ctrinh_Kmai_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Ctrinh_Kmai", Ware_Ctrinh_Kmai.Id_Ctrinh_Kmai));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Ctrinh_Kmai", Ware_Ctrinh_Kmai.Ma_Ctrinh_Kmai));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Ctrinh_Kmai", Ware_Ctrinh_Kmai.Ten_Ctrinh_Kmai));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", Ware_Ctrinh_Kmai.Ngay_Batdau));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", Ware_Ctrinh_Kmai.Ngay_Ketthuc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", Ware_Ctrinh_Kmai.Ghichu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Per_Hoadon", Ware_Ctrinh_Kmai.Per_Hoadon));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Giam_Hoadon", Ware_Ctrinh_Kmai.Giam_Hoadon));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Kmai_Rent", Ware_Ctrinh_Kmai.Kmai_Rent));
                oleDbCommand.Parameters["@Id_Ctrinh_Kmai"].Direction = ParameterDirection.Output;
                oleDbCommand.ExecuteNonQuery();
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Ware_Ctrinh_Kmai", DateTime.Now);
                }
                return oleDbCommand.Parameters["@Id_Ctrinh_Kmai"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        /// <summary>
        /// Update đối tượng Ware_Ctrinh_Kmai vào DB.
        /// </summary>
        /// <param name="Ware_Ctrinh_Kmai"></param>
        /// <returns></returns>
        public object Update_Ware_Ctrinh_Kmai(Ecm.Domain.Ware.Ware_Ctrinh_Kmai Ware_Ctrinh_Kmai)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Ctrinh_Kmai_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Ctrinh_Kmai", Ware_Ctrinh_Kmai.Id_Ctrinh_Kmai));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Ctrinh_Kmai", Ware_Ctrinh_Kmai.Ma_Ctrinh_Kmai));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Ctrinh_Kmai", Ware_Ctrinh_Kmai.Ten_Ctrinh_Kmai));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", Ware_Ctrinh_Kmai.Ngay_Batdau));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", Ware_Ctrinh_Kmai.Ngay_Ketthuc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", Ware_Ctrinh_Kmai.Ghichu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Per_Hoadon", Ware_Ctrinh_Kmai.Per_Hoadon));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Giam_Hoadon", Ware_Ctrinh_Kmai.Giam_Hoadon));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Kmai_Rent", Ware_Ctrinh_Kmai.Kmai_Rent));
                oleDbCommand.ExecuteNonQuery();
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Ware_Ctrinh_Kmai", DateTime.Now);
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
        /// Delete đối tượng Ware_Ctrinh_Kmai vào DB.
        /// </summary>
        /// <param name="Ware_Ctrinh_Kmai"></param>
        /// <returns></returns>
        public object Delete_Ware_Ctrinh_Kmai(Ecm.Domain.Ware.Ware_Ctrinh_Kmai Ware_Ctrinh_Kmai)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Ctrinh_Kmai_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Ctrinh_Kmai", Ware_Ctrinh_Kmai.Id_Ctrinh_Kmai));
                oleDbCommand.ExecuteNonQuery();
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Ware_Ctrinh_Kmai", DateTime.Now);
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
        /// Update một Collection Ware_Ctrinh_Kmai vào DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Ware_Ctrinh_Kmai_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Ctrinh_Kmai", _SqlConnection);
                System.Data.OleDb.OleDbCommandBuilder oleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(oleDbDataAdapter);
                oleDbDataAdapter = oleDbCommandBuilder.DataAdapter;

                oleDbDataAdapter.Update(dsCollection, "GridTable");
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Ware_Ctrinh_Kmai", DateTime.Now);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object Update_Ware_Ctrinh_Kmai_Chitiet_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Ctrinh_Kmai_Chitiet", _SqlConnection);
                System.Data.OleDb.OleDbCommandBuilder oleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(oleDbDataAdapter);
                oleDbDataAdapter = oleDbCommandBuilder.DataAdapter;
                oleDbDataAdapter.Update(dsCollection, "GridTable");
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Ware_Ctrinh_Kmai", DateTime.Now);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Update_Ware_Ctrinh_Kmai_Rent_Chitiet_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Ctrinh_Kmai_Rent_Chitiet", _SqlConnection);
                System.Data.OleDb.OleDbCommandBuilder oleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(oleDbDataAdapter);
                oleDbDataAdapter = oleDbCommandBuilder.DataAdapter;
                oleDbDataAdapter.Update(dsCollection, "GridTable");
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Ware_Ctrinh_Kmai", DateTime.Now);
                }
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
