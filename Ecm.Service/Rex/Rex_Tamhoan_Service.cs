using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Rex
{
    public class Rex_Tamhoan_Service
    {
        #region Connection
        System.Data.OleDb.OleDbConnection sqlConnection;
        #endregion

        DataSet dsTamhoan;

        public Rex_Tamhoan_Service(System.Data.OleDb.OleDbConnection _sqlConnection)
        {
            this.sqlConnection = _sqlConnection;
        }

        public string Get_All_Rex_Tamhoan_ByHopdong(object Id_Hopdong_Laodong)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Tamhoan_Select_ByHopdong", sqlConnection);
                oleDbCommand.Parameters.Add("@Id_Hopdong_Laodong", Id_Hopdong_Laodong);
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

        public string Get_All_Rex_Tamhoan_ByNhansu(object Id_Nhansu)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Tamhoan_Select_ByNhansu", sqlConnection);
                oleDbCommand.Parameters.Add("@Id_Nhansu", Id_Nhansu);
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

        public string Get_Rex_Tamhoan_Report(object Id_Bophan, object Ngay_Batdau, object Ngay_Ketthuc)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Tamhoan_Reports", sqlConnection);
                oleDbCommand.Parameters.Add("@Id_Bophan", Id_Bophan);
                oleDbCommand.Parameters.Add("@Ngay_Batdau", Ngay_Batdau);
                oleDbCommand.Parameters.Add("@Ngay_Ketthuc", Ngay_Ketthuc);
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

        public object Update_Rex_Tamhoan_Collection(DataSet dsTamhoan)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Tamhoan_Select_All", sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
                System.Data.OleDb.OleDbCommandBuilder oleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(oleDbDataAdapter);
                oleDbDataAdapter = oleDbCommandBuilder.DataAdapter;

                oleDbDataAdapter.Update(dsTamhoan, "GridTable");

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
