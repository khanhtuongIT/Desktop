using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Rex
{
    public class Rex_Tamung_Ky1_Service
    {
        #region Connection
        System.Data.OleDb.OleDbConnection sqlConnection;
        #endregion

        public Rex_Tamung_Ky1_Service(System.Data.OleDb.OleDbConnection _sqlConnection)
        {
            this.sqlConnection = _sqlConnection;
        }

        public Domain.Rex.Rex_Tamung_Ky1 Get_Rex_Tamung_Ky1(DataRow row)
        {
            Domain.Rex.Rex_Tamung_Ky1 Rex_Tamung_Ky1 = new Ecm.Domain.Rex.Rex_Tamung_Ky1();

            if (row["Id_Tamung_Ky1"].ToString() != "")
                Rex_Tamung_Ky1.Id_Tamung_Ky1 = row["Id_Tamung_Ky1"];

            if (row["Id_Bophan"].ToString() != "")
                Rex_Tamung_Ky1.Id_Bophan = row["Id_Bophan"];

            if (row["Nam_Kyluong"].ToString() != "")
                Rex_Tamung_Ky1.Nam_Kyluong = row["Nam_Kyluong"];

            if (row["Thang_Kyluong"].ToString() != "")
                Rex_Tamung_Ky1.Thang_Kyluong = row["Thang_Kyluong"];

            if (row["Id_Nhansu"].ToString() != "")
                Rex_Tamung_Ky1.Id_Nhansu = row["Id_Nhansu"];

            if (row["Sotien"].ToString() != "")
                Rex_Tamung_Ky1.Sotien = row["Sotien"];

            if (row["Pb_Khong_Tamung"].ToString() != "")
                Rex_Tamung_Ky1.Pb_Khong_Tamung = row["Pb_Khong_Tamung"];

            if (row["Ghichu_Khong_Tamung"].ToString() != "")
                Rex_Tamung_Ky1.Ghichu_Khong_Tamung = row["Ghichu_Khong_Tamung"];


           return Rex_Tamung_Ky1;
        }

        public string Rex_Tamung_Ky1_SelectAll()
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Tamung_Ky1_SelectAll", sqlConnection);
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

        public string Rex_Tamung_Ky1_SelectByKyluong(object Nam_Kyluong, object Thang_Kyluong)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Tamung_Ky1_SelectByKyluong", sqlConnection);
                oleDbCommand.Parameters.Add("@Nam_Kyluong", Nam_Kyluong);
                oleDbCommand.Parameters.Add("@Thang_Kyluong", Thang_Kyluong);
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
        /// 
        /// </summary>
        /// <param name="Nam_Kyluong"></param>
        /// <param name="Thang_Kyluong"></param>
        /// <param name="Id_Bophan"></param>
        /// <param name="Inc_Bophan_Tructhuoc">true: bao gom bo phan truc thuoc</param>
        /// <returns></returns>
        public string Rex_Tamung_Ky1_SelectByBophan(object Nam_Kyluong, object Thang_Kyluong, object Id_Bophan, object Inc_Bophan_Tructhuoc)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Tamung_Ky1_SelectByBophan", sqlConnection);
                oleDbCommand.Parameters.Add("@Nam_Kyluong", Nam_Kyluong);
                oleDbCommand.Parameters.Add("@Thang_Kyluong", Thang_Kyluong);
                oleDbCommand.Parameters.Add("@Id_Bophan", Id_Bophan);
                oleDbCommand.Parameters.Add("@Inc_Bophan_Tructhuoc", Inc_Bophan_Tructhuoc);
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
       

        public object Insert_Rex_Tamung_Ky1(Domain.Rex.Rex_Tamung_Ky1 Rex_Tamung_Ky1)
        {
            try
            {
                System.Data.DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Tamung_Ky1_Insert", this.sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nam_Kyluong", Rex_Tamung_Ky1.Nam_Kyluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thang_Kyluong", Rex_Tamung_Ky1.Thang_Kyluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", Rex_Tamung_Ky1.Id_Bophan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Rex_Tamung_Ky1.Id_Nhansu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien", Rex_Tamung_Ky1.Sotien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Pb_Khong_Tamung", Rex_Tamung_Ky1.Pb_Khong_Tamung));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu_Khong_Tamung", Rex_Tamung_Ky1.Ghichu_Khong_Tamung));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngaycong", Rex_Tamung_Ky1.Ngaycong));

                oleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object Update_Rex_Tamung_Ky1(Domain.Rex.Rex_Tamung_Ky1 Rex_Tamung_Ky1)
        {
            try
            {
                System.Data.DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Tamung_Ky1_Update", this.sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nam_Kyluong", Rex_Tamung_Ky1.Nam_Kyluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thang_Kyluong", Rex_Tamung_Ky1.Thang_Kyluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", Rex_Tamung_Ky1.Id_Bophan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Rex_Tamung_Ky1.Id_Nhansu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien", Rex_Tamung_Ky1.Sotien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Pb_Khong_Tamung", Rex_Tamung_Ky1.Pb_Khong_Tamung));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu_Khong_Tamung", Rex_Tamung_Ky1.Ghichu_Khong_Tamung));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngaycong", Rex_Tamung_Ky1.Ngaycong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Tamung_Ky1", Rex_Tamung_Ky1.Id_Tamung_Ky1));
                oleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object Delete_Rex_Tamung_Ky1(Domain.Rex.Rex_Tamung_Ky1 Rex_Tamung_Ky1)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Tamung_Ky1_Delete", sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Tamung_Ky1", Rex_Tamung_Ky1.Id_Tamung_Ky1));

                oleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object Update_Rex_Tamung_Ky1_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("select * from Rex_Tamung_Ky1", sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
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