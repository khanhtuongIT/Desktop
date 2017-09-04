using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Rex
{
    public class Rex_Hopdong_Laodong_Service
    {
        #region Connection
        System.Data.OleDb.OleDbConnection sqlConnection;
        #endregion

        public Rex_Hopdong_Laodong_Service(System.Data.OleDb.OleDbConnection _sqlConnection)
        {
            this.sqlConnection = _sqlConnection;
        }

        /// <summary>
        /// Get danh sách nhân sự được bố trí theo ca làm việc
        /// </summary>
        /// <param name="id_ca_lamviec"></param>
        /// <returns></returns>
        public string Get_All_Rex_Hopdong_Laodong_By_Bophan(object id_bophan)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Hopdong_Laodong_Select_ByID", sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", id_bophan));

                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
                oleDbDataAdapter.Fill(dsCollection, "GridTable");

                            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }
        
        public string GetAll_Rex_Hopdong_Laodong_ByBophan(object Id_Bophan, object Ngay_Bc)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Hopdong_Laodong_SelectAll_ByBophan", sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", Id_Bophan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Bc", Ngay_Bc));

                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
                oleDbDataAdapter.Fill(dsCollection, "GridTable");

                            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }

        public string Get_All_Rex_Hopdong_Laodong_By_Nhansu(object Id_Nhansu)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Hopdong_Laodong_Select_ByNhansu", sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Id_Nhansu));

                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
                oleDbDataAdapter.Fill(dsCollection, "GridTable");

                            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }

        /// <summary>
        /// Insert Rex_Hopdong_Laodong
        /// </summary>
        /// <param name="Rex_Hopdong_Laodong"></param>
        /// <returns></returns>
        public object Insert_Rex_Hopdong_Laodong(Domain.Rex.Rex_Hopdong_Laodong Rex_Hopdong_Laodong)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Hopdong_Laodong_Insert", this.sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Hopdong_Laodong", Rex_Hopdong_Laodong.Ma_Hopdong_Laodong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Loai_Hopdong",    Rex_Hopdong_Laodong.Id_Loai_Hopdong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Nld", Rex_Hopdong_Laodong.Id_Nhansu_Nld));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau",        Rex_Hopdong_Laodong.Ngay_Batdau));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc",       Rex_Hopdong_Laodong.Ngay_Ketthuc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", Rex_Hopdong_Laodong.Ghichu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Trangthai_Hopdong_Laodong", Rex_Hopdong_Laodong.Trangthai_Hopdong_Laodong));
                oleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        // <summary>
        /// Insert Rex_Hopdong_Laodong
        /// </summary>
        /// <param name="Rex_Hopdong_Laodong"></param>
        /// <returns></returns>
        public object Update_Rex_Hopdong_Laodong(Domain.Rex.Rex_Hopdong_Laodong Rex_Hopdong_Laodong)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Hopdong_Laodong_Update", this.sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hopdong_Laodong", Rex_Hopdong_Laodong.Id_Hopdong_Laodong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Hopdong_Laodong", Rex_Hopdong_Laodong.Ma_Hopdong_Laodong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Loai_Hopdong",    Rex_Hopdong_Laodong.Id_Loai_Hopdong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Nld", Rex_Hopdong_Laodong.Id_Nhansu_Nld));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau",        Rex_Hopdong_Laodong.Ngay_Batdau));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc",       Rex_Hopdong_Laodong.Ngay_Ketthuc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu",             Rex_Hopdong_Laodong.Ghichu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Trangthai_Hopdong_Laodong", Rex_Hopdong_Laodong.Trangthai_Hopdong_Laodong));
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
        /// Delete đối tượng Rex_Hopdong_Laodong vào DB.
        /// </summary>
        /// <param name="Rex_Hopdong_Laodong"></param>
        /// <returns></returns>
        public object Delete_Rex_Hopdong_Laodong(Ecm.Domain.Rex.Rex_Hopdong_Laodong Rex_Hopdong_Laodong)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Hopdong_Laodong_Delete", this.sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hopdong_Laodong", Rex_Hopdong_Laodong.Id_Hopdong_Laodong));

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
        /// Update dataset to DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Hopdong_Laodong_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("Select * from Rex_Hopdong_Laodong", sqlConnection);
                System.Data.OleDb.OleDbCommandBuilder oleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(oleDbDataAdapter);

                oleDbDataAdapter = oleDbCommandBuilder.DataAdapter;
                oleDbDataAdapter.Update(dsCollection, "GridTable");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        /// <summary>
        /// Lay so ID moi nhat + 1 lam so HDLD
        /// </summary>
        /// <param name=""></param>
        /// <returns>IDHopdongLaoDong+1</returns>
        public object Get_Rex_Hopdong_Laodong_SoHD()
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Hopdong_Laodong_SoHD", sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@So_Hopdong_Laodong", System.Data.OleDb.OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@So_Hopdong_Laodong"].Direction = ParameterDirection.Output;
                oleDbCommand.ExecuteNonQuery();
                return oleDbCommand.Parameters["@So_Hopdong_Laodong"].Value + "/HĐLĐ/" + DateTime.Now.Year;
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }

        [Flags]
        public enum TrangthaiHopdongLaodong
        {
            DangHopdong = 0,
            TamhoanHopdong = 1,
            KethucHopdong = 2,
            GiahanHopdong = 3,
        }   
    }
}
