using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using System.Text;


namespace Ecm.Service.MasterTables.Accounting
{
    public class Acc_Dm_Thue_Tncn_Luytien_Service : MarshalByRefObject
    {
        #region Connection
        System.Data.OleDb.OleDbConnection sqlConnection;
        #endregion

        public Acc_Dm_Thue_Tncn_Luytien_Service(System.Data.OleDb.OleDbConnection _sqlConnection)
        {
            this.sqlConnection = _sqlConnection;
        }

        public string Get_Acc_Dm_Thue_Tncn_Luytien_Collection()
        {
            try
            {
                DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Acc_Dm_Thue_Tncn_Luytien_Selectall", sqlConnection);
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

        public object Insert_Acc_Dm_Thue_Tncn_Luytien(Ecm.Domain.MasterTables.Accounting.Acc_Dm_Thue_Tncn_Luytien acc_Dm_Thue_Tncn_Luytien)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Acc_Dm_Thue_Tncn_Luytien_Insert", this.sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Bacthue", acc_Dm_Thue_Tncn_Luytien.Bacthue));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thunhap_Tinhthue_Nam_From", acc_Dm_Thue_Tncn_Luytien.Thunhap_Tinhthue_Nam_From));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thunhap_Tinhthue_Nam_To", acc_Dm_Thue_Tncn_Luytien.Thunhap_Tinhthue_Nam_To));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thunhap_Tinhthue_Thang_From", acc_Dm_Thue_Tncn_Luytien.Thunhap_Tinhthue_Thang_From));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thunhap_Tinhthue_Thang_To", acc_Dm_Thue_Tncn_Luytien.Thunhap_Tinhthue_Thang_To));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thuesuat", acc_Dm_Thue_Tncn_Luytien.Thuesuat));
                oleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object Update_Acc_Dm_Thue_Tncn_Luytien(Ecm.Domain.MasterTables.Accounting.Acc_Dm_Thue_Tncn_Luytien acc_Dm_Thue_Tncn_Luytien)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Acc_Dm_Thue_Tncn_Luytien_Update", this.sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Thue_Tncn_Luytien", acc_Dm_Thue_Tncn_Luytien.Id_Thue_Tncn_Luytien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Bacthue", acc_Dm_Thue_Tncn_Luytien.Bacthue));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thunhap_Tinhthue_Nam_From", acc_Dm_Thue_Tncn_Luytien.Thunhap_Tinhthue_Nam_From));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thunhap_Tinhthue_Nam_To", acc_Dm_Thue_Tncn_Luytien.Thunhap_Tinhthue_Nam_To));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thunhap_Tinhthue_Thang_From", acc_Dm_Thue_Tncn_Luytien.Thunhap_Tinhthue_Thang_From));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thunhap_Tinhthue_Thang_To", acc_Dm_Thue_Tncn_Luytien.Thunhap_Tinhthue_Thang_To));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thuesuat", acc_Dm_Thue_Tncn_Luytien.Thuesuat));
                oleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object Delete_Acc_Dm_Thue_Tncn_Luytien(Ecm.Domain.MasterTables.Accounting.Acc_Dm_Thue_Tncn_Luytien acc_Dm_Thue_Tncn_Luytien)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Acc_Dm_Thue_Tncn_Luytien_Delete", this.sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Thue_Tncn_Luytien", acc_Dm_Thue_Tncn_Luytien.Id_Thue_Tncn_Luytien));
                oleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        private Ecm.Domain.MasterTables.Accounting.Acc_Dm_Thue_Tncn_Luytien Get_Acc_Dm_Thue_Tncn_Luytien(DataRow row)
        {
            var acc_Dm_Thue_Tncn_Luytien = new Ecm.Domain.MasterTables.Accounting.Acc_Dm_Thue_Tncn_Luytien();

            if ("" + row["Bacthue"] != "")
                acc_Dm_Thue_Tncn_Luytien.Bacthue = row["Bacthue"];
            if ("" + row["Id_Thue_Tncn_Luytien"] != "")
                acc_Dm_Thue_Tncn_Luytien.Id_Thue_Tncn_Luytien = row["Id_Thue_Tncn_Luytien"];
            if ("" + row["Thuesuat"] != "")
                acc_Dm_Thue_Tncn_Luytien.Thuesuat = row["Thuesuat"];
            if ("" + row["Thunhap_Tinhthue_Nam_From"] != "")
                acc_Dm_Thue_Tncn_Luytien.Thunhap_Tinhthue_Nam_From = row["Thunhap_Tinhthue_Nam_From"];
            if ("" + row["Thunhap_Tinhthue_Nam_To"] != "")
                acc_Dm_Thue_Tncn_Luytien.Thunhap_Tinhthue_Nam_To = row["Thunhap_Tinhthue_Nam_To"];
            if ("" + row["Thunhap_Tinhthue_Thang_From"] != "")
                acc_Dm_Thue_Tncn_Luytien.Thunhap_Tinhthue_Thang_From = row["Thunhap_Tinhthue_Thang_From"];
            if ("" + row["Thunhap_Tinhthue_Thang_To"] != "")
                acc_Dm_Thue_Tncn_Luytien.Thunhap_Tinhthue_Thang_To = row["Thunhap_Tinhthue_Thang_To"];

            return acc_Dm_Thue_Tncn_Luytien;
        }

        public object Update_Acc_Dm_Thue_Tncn_Luytien_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("Select * from Acc_Dm_Thue_Tncn_Luytien", sqlConnection);
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
