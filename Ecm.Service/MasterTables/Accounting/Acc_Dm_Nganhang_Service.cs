using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Ecm.Service.MasterTables.Accounting
{
    public class Acc_Dm_Nganhang_Service : MarshalByRefObject
    {
        #region Connection
        System.Data.OleDb.OleDbConnection sqlConnection;
        #endregion

        #region Properties
        public string DataSet_Acc_Dm_Nganhang
        {
            get { return DataSet_Acc_Dm_Nganhang; }
        }
        #endregion

        #region Method
        public Acc_Dm_Nganhang_Service(System.Data.OleDb.OleDbConnection _sqlConnection)
        {
            this.sqlConnection = _sqlConnection;
        }

        private Domain.MasterTables.Accounting.Acc_Dm_Nganhang Get_Acc_Dm_Nganhang(DataRow row)
        {
            Domain.MasterTables.Accounting.Acc_Dm_Nganhang Acc_Dm_Nganhang = new Domain.MasterTables.Accounting.Acc_Dm_Nganhang();
            if (row["Id_Nganhang"] != null)
                Acc_Dm_Nganhang.Id_Nganhang = row["Id_Nganhang"];
            if (row["Ma_Nganhang"] != null)
                Acc_Dm_Nganhang.Ma_Nganhang = row["Ma_Nganhang"];
            if (row["Ten_Nganhang"] != null)
                Acc_Dm_Nganhang.Ten_Nganhang = row["Ten_Nganhang"];
            if (row["Diachi"] != null)
                Acc_Dm_Nganhang.Diachi = row["Diachi"];
            if (row["Dienthoai"] != null)
                Acc_Dm_Nganhang.Dienthoai = row["Dienthoai"];
            if (row["Fax"] != null)
                Acc_Dm_Nganhang.Fax = row["Fax"];
            if (row["Telex"] != null)
                Acc_Dm_Nganhang.Telex = row["Telex"];
            if (row["Swiftcode"] != null)
                Acc_Dm_Nganhang.Swiftcode = row["Swiftcode"];
            if (row["Ten_Nganhang_Gdqt"] != null)
                Acc_Dm_Nganhang.Ten_Nganhang_Gdqt = row["Ten_Nganhang_Gdqt"];
            return Acc_Dm_Nganhang;
        }
        #endregion

        #region implemetns IObService
        public string Get_Acc_Dm_Nganhang_Collection()
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("GetAll_Acc_Dm_Nganhang", sqlConnection);
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

        public string Get_Acc_Dm_Nganhang_Collection_By_Kyluong(Hashtable kyluong)
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Acc_Dm_Nganhang_GetAllBy_Kyluong", sqlConnection);
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


        public string GetDs_Acc_Dm_Nganhang_Collection()
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Acc_Dm_Nganhang_GetAll", sqlConnection);
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

        public object Insert_Acc_Dm_Nganhang(Domain.MasterTables.Accounting.Acc_Dm_Nganhang Acc_Dm_Nganhang)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Insert_Acc_Dm_Nganhang", this.sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Nganhang", Acc_Dm_Nganhang.Ma_Nganhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Nganhang", Acc_Dm_Nganhang.Ten_Nganhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Diachi", Acc_Dm_Nganhang.Diachi));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dienthoai", Acc_Dm_Nganhang.Dienthoai));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Fax", Acc_Dm_Nganhang.Fax));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Telex", Acc_Dm_Nganhang.Telex));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Swiftcode", Acc_Dm_Nganhang.Swiftcode));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Nganhang_Gdqt", Acc_Dm_Nganhang.Ten_Nganhang_Gdqt));
                oleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object Update_Acc_Dm_Nganhang(Domain.MasterTables.Accounting.Acc_Dm_Nganhang Acc_Dm_Nganhang)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Update_Acc_Dm_Nganhang", this.sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Nganhang", Acc_Dm_Nganhang.Ma_Nganhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Nganhang", Acc_Dm_Nganhang.Ten_Nganhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Diachi", Acc_Dm_Nganhang.Diachi));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dienthoai", Acc_Dm_Nganhang.Dienthoai));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Fax", Acc_Dm_Nganhang.Fax));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Telex", Acc_Dm_Nganhang.Telex));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Swiftcode", Acc_Dm_Nganhang.Swiftcode));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Nganhang_Gdqt", Acc_Dm_Nganhang.Ten_Nganhang_Gdqt));
                oleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object Delete_Acc_Dm_Nganhang(Domain.MasterTables.Accounting.Acc_Dm_Nganhang Acc_Dm_Nganhang)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Delete_Acc_Dm_Nganhang", this.sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nganhang", Acc_Dm_Nganhang.Id_Nganhang));
                oleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public bool Update_Acc_Dm_Nganhang_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("Select * from Acc_Dm_Nganhang", sqlConnection);
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
        #endregion
    }
}
