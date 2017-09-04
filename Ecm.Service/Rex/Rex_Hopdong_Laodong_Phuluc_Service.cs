using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Rex
{
    public class Rex_Hopdong_Laodong_Phuluc_Service
    {
        /// <summary>
        /// Author:		<Author, nhanvuong>
        /// Create date: <Create Date, 23/08/2010>
        /// Description: <service of domain Rex_Hopdong_Laodong_Phuluc (gia hạn HĐLĐ) >
        /// </summary>

        #region Connection
        System.Data.OleDb.OleDbConnection sqlConnection;
        #endregion

        public Rex_Hopdong_Laodong_Phuluc_Service(System.Data.OleDb.OleDbConnection _sqlConnection)
        {
            this.sqlConnection = _sqlConnection;
        }

        /// <summary>
        /// Get danh sách hợp đồng lao động phụ lục
        /// </summary>       
        /// <returns> </returns>
        public string Get_All_Rex_Hopdong_Laodong_Phuluc_SelectAll()
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Hopdong_Laodong_Phuluc_SelectAll", sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

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
        /// Get hợp đồng lao động phụ lục By Id_Hopdong_Laodong_Phuluc
        /// </summary>       
        /// <returns> </returns>
        public string Get_Rex_Hopdong_Laodong_Phuluc_By_Id_Phuluc(object id_Hopdong_Laodong_Phuluc)
        {
           
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Hopdong_Laodong_Phuluc_Select_By_Id_Phuluc", sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hopdong_Laodong_Phuluc", id_Hopdong_Laodong_Phuluc));

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
        /// Get danh sách hợp đồng lao động phụ lục By Id_Hopdong_Laodong
        /// </summary>       
        /// <returns> </returns>
        public string Get_All_Rex_Hopdong_Laodong_Phuluc_Select_By_Id_Hdld(object Id_Hopdong_Laodong)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Hopdong_Laodong_Phuluc_Select_By_Id_Hopdong", sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hopdong_Laodong", Id_Hopdong_Laodong));

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
        /// Get danh sách hợp đồng lao động phụ lục By Id_Nhansu_Nld
        /// </summary>       
        /// <returns> </returns>
        public string Get_All_Rex_Hopdong_Laodong_Phuluc_Select_By_Id_Nhansu_Nld(object Id_Nhansu_Nld) 
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Hopdong_Laodong_Phuluc_Select_By_Id_Nhansu_Nld", sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Nld", Id_Nhansu_Nld));

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
        /// Insert hợp đồng lao động phụ lục 
        /// </summary>       
        /// <returns> </returns>
        public object Rex_Hopdong_Laodong_Phuluc_Insert(Domain.Rex.Rex_Hopdong_Laodong_Phuluc Rex_Hopdong_Laodong_Phuluc)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Hopdong_Laodong_Phuluc_Insert", sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@NoiKy", Rex_Hopdong_Laodong_Phuluc.Noiky));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@NgayKy", Rex_Hopdong_Laodong_Phuluc.Ngayky));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tendonvi", Rex_Hopdong_Laodong_Phuluc.Tendonvi));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@@Ma_Hopdong_Laodong_Phuluc", Rex_Hopdong_Laodong_Phuluc.Ma_Hopdong_Laodong_Phuluc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Nld", Rex_Hopdong_Laodong_Phuluc.Id_Nhansu_Nld));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Nsd", Rex_Hopdong_Laodong_Phuluc.Id_Nhansu_Nsd));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Noidung_Thaydoi", Rex_Hopdong_Laodong_Phuluc.Noidung_Thaydoi));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thoigian_Thuchien_Tu", Rex_Hopdong_Laodong_Phuluc.Thoigian_Thuchien_Tu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thoigian_Thuchien_Den", Rex_Hopdong_Laodong_Phuluc.Thoigian_Thuchien_Den));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hopdong_Laodong", Rex_Hopdong_Laodong_Phuluc.Id_Hopdong_Laodong));

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
        /// update hợp đồng lao động phụ lục 
        /// </summary>       
        /// <returns> </returns>
        public object Rex_Hopdong_Laodong_Phuluc_Update(Domain.Rex.Rex_Hopdong_Laodong_Phuluc Rex_Hopdong_Laodong_Phuluc)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Hopdong_Laodong_Phuluc_Update", sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@NoiKy", Rex_Hopdong_Laodong_Phuluc.Noiky));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@NgayKy", Rex_Hopdong_Laodong_Phuluc.Ngayky));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tendonvi", Rex_Hopdong_Laodong_Phuluc.Tendonvi));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@@Ma_Hopdong_Laodong_Phuluc", Rex_Hopdong_Laodong_Phuluc.Ma_Hopdong_Laodong_Phuluc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Nld", Rex_Hopdong_Laodong_Phuluc.Id_Nhansu_Nld));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Nsd", Rex_Hopdong_Laodong_Phuluc.Id_Nhansu_Nsd));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Noidung_Thaydoi", Rex_Hopdong_Laodong_Phuluc.Noidung_Thaydoi));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thoigian_Thuchien_Tu", Rex_Hopdong_Laodong_Phuluc.Thoigian_Thuchien_Tu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thoigian_Thuchien_Den", Rex_Hopdong_Laodong_Phuluc.Thoigian_Thuchien_Den));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hopdong_Laodong", Rex_Hopdong_Laodong_Phuluc.Id_Hopdong_Laodong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@ID_Hopdong_Laodong_Phuluc", Rex_Hopdong_Laodong_Phuluc.Id_Hopdong_Laodong_Phuluc));

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
        /// Delete hợp đồng lao động phụ lục 
        /// </summary>       
        /// <returns> </returns>
        public object Rex_Hopdong_Laodong_Phuluc_Delete(object Id_Rex_Hopdong_Laodong_Phuluc)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Hopdong_Laodong_Phuluc_Delete", sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hopdong_Laodong_Phuluc", Id_Rex_Hopdong_Laodong_Phuluc));

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
        /// Lay so ID moi nhat + 1 lam so HDLD phu luc
        /// </summary>
        /// <param name=""></param>
        /// <returns>IDHopdongLaoDongPhuluc+1</returns>
        public object Get_Rex_Hopdong_Laodong_Phuluc_SoHD() 
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Hopdong_Laodong_Phuluc_SoHD", sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@So_Hopdong_Laodong_Phuluc", System.Data.OleDb.OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@So_Hopdong_Laodong_Phuluc"].Direction = ParameterDirection.Output;
                oleDbCommand.ExecuteNonQuery();
                return oleDbCommand.Parameters["@So_Hopdong_Laodong_Phuluc"].Value + "/PLHĐLĐ/" + DateTime.Now.Year;
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }

    }
}
