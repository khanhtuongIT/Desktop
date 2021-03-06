using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Rex
{
    public class Rex_Nghiphep_Service
    {
        #region Connection
        System.Data.OleDb.OleDbConnection sqlConnection;
        #endregion

        public Rex_Nghiphep_Service(System.Data.OleDb.OleDbConnection _sqlConnection)
        {
            this.sqlConnection = _sqlConnection;
        }

        public string Get_Rex_Nghiphep_ByNhansu_WithChamcong(object Id_Nhansu, object Ngay_Chamcong)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nghiphep_Select_ByNhansu_WithChamcong", sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Id_Nhansu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chamcong", Ngay_Chamcong));

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
        /// Get danh sách nhân sự được bố trí theo ca làm việc
        /// </summary>
        /// <param name="id_ca_lamviec"></param>
        /// <returns></returns>
        public string Get_All_Rex_Nghiphep_By_Bophan(object id_bophan)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nghiphep_Select_ByID", sqlConnection);
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

        public string Get_All_Rex_Nghiphep_By_Nhansu(object Id_Nhansu)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nghiphep_Select_ByNhansu", sqlConnection);
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
        ///  search nhan su nghi phep theo tung bo phan
        /// </summary>
        /// <param name="Ngay_Batdau"></param>
        /// <param name="Ngay_Ketthuc"></param>
        /// <param name="Id_Bophan"></param>
        /// <returns></returns>
     
        public string RptRex_Nghiphep_ByBophan(object Ngay_Batdau, object Ngay_Ketthuc, object Id_Bophan)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("RptRex_Nghiphep_ByBophan", sqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", Ngay_Batdau));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", Ngay_Ketthuc));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", Id_Bophan));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }
        
        /// <summary>
        /// Get danh sách ngày nghỉ cảu nhân sự trong tháng,năm
        /// </summary>
        /// <param name="id_Nhansu"></param>
        /// <param name="nam"></param>
        /// <param name="thang"></param>
        /// <returns></returns>
        public string Get_All_Rex_Nghiphep_By_Nhansu_Nam_Thang(object id_Nhansu,object nam,object thang)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nghiphep_Select_ByNhansu_Nam_Thang", sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", id_Nhansu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nam", nam));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thang", thang));

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

        public string Get_All_Rex_Nghiphep_By_Nhansu_Nam_Thang_Loainghiphep(object id_Nhansu, object nam, object thang, object id_Loai_Nghiphep)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nghiphep_Select_ByNhansu_Nam_Thang_Loai", sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", id_Nhansu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nam", nam));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thang", thang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Loai_Nghiphep", id_Loai_Nghiphep));

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
        /// 
        /// </summary>
        /// <param name="id_Bophan"></param>
        /// <param name="nam"></param>
        /// <param name="id_Loai_Nghiphep"></param>
        /// <returns></returns>
        public string Get_All_Rex_Nghiphep_By_Bophan_Loai_Nam(object id_Bophan, object nam, object id_Loai_Nghiphep)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nghiphep_By_Bophan_Loai_Nam", sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nam", nam));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", id_Bophan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Loai_Nghiphep", id_Loai_Nghiphep));

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
        /// 
        /// </summary>
        /// <param name="id_Bophan"></param>
        /// <param name="nam"></param>
        /// <returns></returns>
        public string Get_All_Rex_Nghiphep_By_Bophan_Nam(object id_Bophan, object nam)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nghiphep_By_Bophan_Nam", sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nam", nam));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", id_Bophan));

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
        /// Insert Rex_Nghiphep
        /// </summary>
        /// <param name="Rex_Nghiphep"></param>
        /// <returns></returns>
        public object Insert_Rex_Nghiphep(Domain.Rex.Rex_Nghiphep Rex_Nghiphep)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nghiphep_Insert", this.sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu",          Rex_Nghiphep.Id_Nhansu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Loai_Nghiphep", Rex_Nghiphep.Id_Loai_Nghiphep));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sogio_Nghiphep",     Rex_Nghiphep.Sogio_Nghiphep));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau",        Rex_Nghiphep.Ngay_Batdau));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc",       Rex_Nghiphep.Ngay_Ketthuc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu",             Rex_Nghiphep.Ghichu));

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
        /// Insert Rex_Nghiphep
        /// </summary>
        /// <param name="Rex_Nghiphep"></param>
        /// <returns></returns>
        public object Update_Rex_Nghiphep(Domain.Rex.Rex_Nghiphep Rex_Nghiphep)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nghiphep_Update", this.sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nghiphep",        Rex_Nghiphep.Id_Nghiphep));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu",          Rex_Nghiphep.Id_Nhansu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Loai_Nghiphep", Rex_Nghiphep.Id_Loai_Nghiphep));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sogio_Nghiphep",     Rex_Nghiphep.Sogio_Nghiphep));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau",        Rex_Nghiphep.Ngay_Batdau));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc",       Rex_Nghiphep.Ngay_Ketthuc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu",             Rex_Nghiphep.Ghichu));

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
        /// Delete đối tượng Rex_Nghiphep vào DB.
        /// </summary>
        /// <param name="Rex_Nghiphep"></param>
        /// <returns></returns>
        public object Delete_Rex_Nghiphep(Ecm.Domain.Rex.Rex_Nghiphep Rex_Nghiphep)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nghiphep_Delete", this.sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nghiphep", Rex_Nghiphep.Id_Nghiphep));

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
        public object Update_Nghiphep_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("Select * from Rex_Nghiphep", sqlConnection);
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
    }
}
