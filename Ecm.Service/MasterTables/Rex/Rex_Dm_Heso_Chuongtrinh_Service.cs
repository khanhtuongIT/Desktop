using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.MasterTables.Rex
{
    public class Rex_Dm_Heso_Chuongtrinh_Service : MarshalByRefObject
    {
        #region private fields
        //private QueryIDs _QueryIDs;
        System.Data.OleDb.OleDbConnection _SqlConnection;
        private DataSet _Rex_Dm_Heso_Chuongtrinh_Collection;
        #endregion

        #region Properties
        //public QueryIDs QueryIDs
        //{
        //    get { return _QueryIDs; }
        //    set { _QueryIDs = value; }
        //}

        public string DataSet_Rex_Dm_Heso_Chuongtrinh
        {
            get { return DataSet_Rex_Dm_Heso_Chuongtrinh; }
        }
        #endregion

        #region Method
        public Rex_Dm_Heso_Chuongtrinh_Service(System.Data.OleDb.OleDbConnection sqlMaper)
        {
            this._SqlConnection = sqlMaper;
        }

        private Domain.MasterTables.Rex.Rex_Dm_Heso_Chuongtrinh Get_Rex_Dm_Heso_Chuongtrinh(DataRow row)
        {
            Domain.MasterTables.Rex.Rex_Dm_Heso_Chuongtrinh Rex_Dm_Heso_Chuongtrinh = new Ecm.Domain.MasterTables.Rex.Rex_Dm_Heso_Chuongtrinh();

            if ("" + row["Id_Heso_Chuongtrinh"] != "")
                Rex_Dm_Heso_Chuongtrinh.Id_Heso_Chuongtrinh     = row["Id_Heso_Chuongtrinh"];

            if ("" + row["Ma_Heso_Chuongtrinh"] != "")
                Rex_Dm_Heso_Chuongtrinh.Ma_Heso_Chuongtrinh     = row["Ma_Heso_Chuongtrinh"];

            if ("" + row["Ten_Heso_Chuongtrinh"] != "")
                Rex_Dm_Heso_Chuongtrinh.Ten_Heso_Chuongtrinh    = row["Ten_Heso_Chuongtrinh"];

            if ("" + row["Heso"] != "")
                Rex_Dm_Heso_Chuongtrinh.Heso                    = row["Heso"];
            if ("" + row["Nhom_Heso_Chuongtrinh"] != "")
                Rex_Dm_Heso_Chuongtrinh.Nhom_Heso_Chuongtrinh   = row["Nhom_Heso_Chuongtrinh"];
            if ("" + row["Ghichu"] != "")
                Rex_Dm_Heso_Chuongtrinh.Ghichu = row["Ghichu"];
            if ("" + row["Regx"] != "")
                Rex_Dm_Heso_Chuongtrinh.Regx = row["Regx"];
            return Rex_Dm_Heso_Chuongtrinh;
        }
        #endregion

        #region implemetns IObService
 
        public string Get_Rex_Dm_Heso_Chuongtrinh_Collection()
        {

            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Dm_Heso_Chuongtrinh_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string GetDs_Rex_Dm_Heso_Chuongtrinh_Collection()
        {

            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Dm_Heso_Chuongtrinh_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None);            
        }

        public string GetAll_Rex_Dm_Heso_Chuongtrinh_By_Nhomheso(object Nhom_Heso_Chuongtrinh)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Dm_Heso_Chuongtrinh_SelectBy_Nhomheso", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nhom_Heso_Chuongtrinh", Nhom_Heso_Chuongtrinh));
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 

        }
       
        public object Insert_Rex_Dm_Heso_Chuongtrinh(Ecm.Domain.MasterTables.Rex.Rex_Dm_Heso_Chuongtrinh rex_Dm_Heso_Chuongtrinh)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Dm_Heso_Chuongtrinh_Insert", _SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Heso_Chuongtrinh", rex_Dm_Heso_Chuongtrinh.Ma_Heso_Chuongtrinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Heso_Chuongtrinh", rex_Dm_Heso_Chuongtrinh.Ten_Heso_Chuongtrinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Heso", rex_Dm_Heso_Chuongtrinh.Heso));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nhom_Heso_Chuongtrinh", rex_Dm_Heso_Chuongtrinh.Nhom_Heso_Chuongtrinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", rex_Dm_Heso_Chuongtrinh.Ghichu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Regx", rex_Dm_Heso_Chuongtrinh.Regx));

                oleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }


        public object Update_Rex_Dm_Heso_Chuongtrinh(Ecm.Domain.MasterTables.Rex.Rex_Dm_Heso_Chuongtrinh rex_Dm_Heso_Chuongtrinh)
        {

            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Dm_Heso_Chuongtrinh_Update", _SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Heso_Chuongtrinh", rex_Dm_Heso_Chuongtrinh.Id_Heso_Chuongtrinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Heso_Chuongtrinh", rex_Dm_Heso_Chuongtrinh.Ma_Heso_Chuongtrinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Heso_Chuongtrinh", rex_Dm_Heso_Chuongtrinh.Ten_Heso_Chuongtrinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Heso", rex_Dm_Heso_Chuongtrinh.Heso));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nhom_Heso_Chuongtrinh", rex_Dm_Heso_Chuongtrinh.Nhom_Heso_Chuongtrinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", rex_Dm_Heso_Chuongtrinh.Ghichu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Regx", rex_Dm_Heso_Chuongtrinh.Regx));

                oleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }


        public object Delete_Rex_Dm_Heso_Chuongtrinh(Ecm.Domain.MasterTables.Rex.Rex_Dm_Heso_Chuongtrinh rex_Dm_Heso_Chuongtrinh)
        {

            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Dm_Heso_Chuongtrinh_Delete", _SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Heso_Chuongtrinh", rex_Dm_Heso_Chuongtrinh.Id_Heso_Chuongtrinh));

                oleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }


        public bool Update_Rex_Dm_Heso_Chuongtrinh_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Rex_Dm_Heso_Chuongtrinh", _SqlConnection);
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
