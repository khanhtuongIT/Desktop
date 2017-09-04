using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Bar
{
    public class Bar_Table_Booking_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _sqlConnection;
        #endregion

        #region Method
        public Bar_Table_Booking_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._sqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService
        /// <summary>
        /// Return dataset Bar_Table_Booking
        /// </summary>
        /// <param name="Id_Table_Order"></param>
        /// <returns></returns>
        /// 
        public string Get_All_Table_Booking()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Table_Booking_SelectAll", this._sqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public object GetBar_Table_Booking_Tien_Booking_By_Id_Booking(object Id_Booking)
        {
            System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Table_Booking_Select_Tien_Booking", this._sqlConnection);
            OleDbCommand.CommandType = CommandType.StoredProcedure;
            OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Booking", Id_Booking));
            OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tien_Booking", System.Data.OleDb.OleDbType.Double));

            OleDbCommand.Parameters["@Tien_Booking"].Direction = ParameterDirection.Output;
            OleDbCommand.ExecuteNonQuery();
            return OleDbCommand.Parameters["@Tien_Booking"].Value;
        }

        /// <summary>
        /// Insert đối tượng Bar_Table_Booking vào DB
        /// </summary>
        /// <param name="Bar_Table_Order"></param>
        /// <returns>Identity new value</returns>
        public object Insert_Bar_Table_Booking(Domain.Bar.Bar_Table_Booking Bar_Table_Booking)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Table_Booking_Insert", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;

                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Booking", System.Data.OleDb.OleDbType.BigInt));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Booking", Bar_Table_Booking.Ma_Booking));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_KhachHang_Booking", Bar_Table_Booking.Ten_Khachhang_Booking));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tien_Booking", Bar_Table_Booking.Tien_Booking));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Nhan_Booking", Bar_Table_Booking.Ngay_Nhan_Booking));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Den", Bar_Table_Booking.Ngay_Den));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Xacnhan", Bar_Table_Booking.Ngay_Xacnhan));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@GhiChu", Bar_Table_Booking.GhiChu));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@NhanSu_Booking", Bar_Table_Booking.NhanSu_Booking));
                OleDbCommand.Parameters["@Id_Booking"].Direction = ParameterDirection.Output;

                OleDbCommand.ExecuteNonQuery();

                return OleDbCommand.Parameters["@Id_Booking"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        /// <summary>
        /// Update đối tượng Bar_Table_Booking  vào DB
        /// </summary>
        /// <param name="Bar_Table_Order"></param>
        /// <returns>bool</returns>
        public object Update_Bar_Table_Booking(Domain.Bar.Bar_Table_Booking Bar_Table_Booking)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Table_Booking_Update", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Booking", Bar_Table_Booking.Id_Booking));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Booking", Bar_Table_Booking.Ma_Booking));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_KhachHang_Booking", Bar_Table_Booking.Ten_Khachhang_Booking));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tien_Booking", Bar_Table_Booking.Tien_Booking));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Nhan_Booking", Bar_Table_Booking.Ngay_Nhan_Booking));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Den", Bar_Table_Booking.Ngay_Den));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Xacnhan", Bar_Table_Booking.Ngay_Xacnhan));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@GhiChu", Bar_Table_Booking.GhiChu));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@NhanSu_Booking", Bar_Table_Booking.NhanSu_Booking));

                OleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object Update_Bar_Table_Booking_Finish(object Id_Booking)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Table_Booking_UpdateFinish", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;

                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Booking", Id_Booking));
                OleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object Delete_Bar_Table_Booking(object Id_Booking)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Table_Booking_Delete", this._sqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;

                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Booking", Id_Booking));
                OleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }


        public string Get_All_Bar_Table_Booking_Chitiet_ById_Booking(object Id_Booking)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Bar_Table_Booking_Chitiet_By_Id_Booking", this._sqlConnection);
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Booking", Id_Booking));
                OleDbCommand.CommandType = CommandType.StoredProcedure;

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


        /// <summary>
        /// Update Dataset Bar_Table_Order vào DB
        /// </summary>
        /// <param name="Bar_Table_Order"></param>
        /// <returns>bool</returns>
        public object Update_Bar_Table_Booking_Chitiet_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("Select * From Bar_Table_Booking_Chitiet", this._sqlConnection);
                System.Data.OleDb.OleDbCommandBuilder OleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(OleDbDataAdapter);
                OleDbDataAdapter = OleDbCommandBuilder.DataAdapter;

                OleDbDataAdapter.Update(dsCollection, "GridTable");

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
