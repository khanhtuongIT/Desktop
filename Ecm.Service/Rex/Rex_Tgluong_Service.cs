using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Rex
{
    public class Rex_Tgluong_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        public Rex_Tgluong_Service(System.Data.OleDb.OleDbConnection sqlMaper)
        {
            this._SqlConnection = sqlMaper;
        }

        public Domain.Rex.Rex_Tgluong Get_Rex_Tgluong(DataRow row)
        {
            Domain.Rex.Rex_Tgluong Rex_Tgluong = new Ecm.Domain.Rex.Rex_Tgluong();

            if (row["Id_Tgluong"].ToString() != "")
                Rex_Tgluong.Id_Tgluong = row["Id_Tgluong"];

            if (row["Id_Nhansu"].ToString() != "")
                Rex_Tgluong.Id_Nhansu = row["Id_Nhansu"];

            if (row["Id_Ndung_Tgluong"].ToString() != "")
                Rex_Tgluong.Id_Ndung_Tgluong = row["Id_Ndung_Tgluong"];

            if (row["Id_Kyluong"].ToString() != "")
                Rex_Tgluong.Id_Kyluong = row["Id_Kyluong"];

            if (row["Sotien"].ToString() != "")
                Rex_Tgluong.Sotien = row["Sotien"];

            if (row["Id_Bophan"].ToString() != "")
                Rex_Tgluong.Id_Bophan = row["Id_Bophan"];

            if (row["Nam_Kyluong"].ToString() != "")
                Rex_Tgluong.Nam_Kyluong = row["Nam_Kyluong"];

            if (row["Thang_Kyluong"].ToString() != "")
                Rex_Tgluong.Thang_Kyluong = row["Thang_Kyluong"];

            return Rex_Tgluong;
        }

        public string Rex_Tgluong_Select_By_Id_Nhansu(Domain.Rex.Rex_Tgluong Rex_Tgluong)
        {

            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Tgluong_Select_By_Id_Nhansu", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Rex_Tgluong.Id_Nhansu));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", Rex_Tgluong.Id_Bophan));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Rex_Tgluong_Select_By_Id_Kyluong(Domain.Rex.Rex_Tgluong Rex_Tgluong)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Tgluong_Select_By_Id_Kyluong", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kyluong", Rex_Tgluong.Id_Kyluong));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", Rex_Tgluong.Id_Bophan));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 

        }

        public string Rex_Tgluong_Select_By_Id_Kyluong_Nhansu(Domain.Rex.Rex_Tgluong Rex_Tgluong)
        {
            //return Mapper.QueryForDataSet("Rex_Tgluong_Select_By_Id_Kyluong_Nhansu", Rex_Tgluong);
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Tgluong_Select_By_Id_Kyluong_Nhansu", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Rex_Tgluong.Id_Nhansu));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", Rex_Tgluong.Id_Bophan));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kyluong", Rex_Tgluong.Id_Kyluong));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public object Insert_Rex_Tgluong(Domain.Rex.Rex_Tgluong Rex_Tgluong)
        {
            try
            {
                System.Data.DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Tgluong_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Rex_Tgluong.Id_Nhansu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Ndung_Tgluong", Rex_Tgluong.Id_Ndung_Tgluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kyluong", Rex_Tgluong.Id_Kyluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien", Rex_Tgluong.Sotien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", Rex_Tgluong.Id_Bophan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nam_Kyluong", Rex_Tgluong.Nam_Kyluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thang_Kyluong", Rex_Tgluong.Thang_Kyluong));

                oleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object Update_Rex_Tgluong(Domain.Rex.Rex_Tgluong Rex_Tgluong)
        {
            try
            {
                System.Data.DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Tgluong_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Tgluong", Rex_Tgluong.Id_Tgluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Rex_Tgluong.Id_Nhansu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Ndung_Tgluong", Rex_Tgluong.Id_Ndung_Tgluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kyluong", Rex_Tgluong.Id_Kyluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien", Rex_Tgluong.Sotien));

                oleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object Delete_Rex_Tgluong(Domain.Rex.Rex_Tgluong Rex_Tgluong)
        {
          
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Tgluong_Delete", _SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Tgluong", Rex_Tgluong.Id_Tgluong));

                oleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object Update_Rex_Tgluong_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Rex_Tgluong", _SqlConnection);
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