using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Rex
{
    public class Rex_Trichnop_Bhxh_Service : MarshalByRefObject
    {
        #region Fields
        System.Data.OleDb.OleDbConnection sqlConnection;
        #endregion

        #region Methods
        public Rex_Trichnop_Bhxh_Service(System.Data.OleDb.OleDbConnection _sqlConnection)
        {
            this.sqlConnection = _sqlConnection;
        }
        /// <summary>
        /// Trả về object Rex_Trichnop_Bhxh được gán giá trị từ một datarow.
        /// </summary>
        /// <param name="row"></param>
        /// <returns>Domain.Pro.Pro_Dm_Dinhmuc</returns>
        private Domain.Rex.Rex_Trichnop_Bhxh Get_Rex_Trichnop_Bhxh(DataRow row)
        {
            Domain.Rex.Rex_Trichnop_Bhxh rex_Trichnop_Bhxh = new Domain.Rex.Rex_Trichnop_Bhxh();

            if ("" + row["Id_Trichnop_Bhxh"] != "")
                rex_Trichnop_Bhxh.Id_Trichnop_Bhxh = row["Id_Trichnop_Bhxh"];

            if ("" + row["Pccv"] != "")
                rex_Trichnop_Bhxh.Pccv      = row["Pccv"];

            if ("" + row["Pctnvk"] != "")
                rex_Trichnop_Bhxh.Pctnvk    = row["Pctnvk"];

            if ("" + row["Pctnnn"] != "")
                rex_Trichnop_Bhxh.Pctnnn    = row["Pctnnn"];

            if ("" + row["Pckv"] != "")
                rex_Trichnop_Bhxh.Pckv      = row["Pckv"];

            if ("" + row["Bhxh"] != "")
                rex_Trichnop_Bhxh.Bhxh      = row["Bhxh"];

            if ("" + row["Bhyt"] != "")
                rex_Trichnop_Bhxh.Bhyt      = row["Bhyt"];

            if ("" + row["Ghichu"] != "")
                rex_Trichnop_Bhxh.Ghichu    = row["Ghichu"];
           
            return rex_Trichnop_Bhxh;
        }
        #endregion

        #region implemetns IObService
        /// <summary>
        /// Trả về 1 object Rex_Trichnop_Bhxh_Collection
        /// </summary>
        /// <returns></returns>
        public string Get_Rex_Trichnop_Bhxh_Collection()
        {

            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("GetAll_Rex_Trichnop_Bhxh", this.sqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Tra ve DataSet Rex_Trichnop_Bhxh
        /// </summary>
        /// <returns></returns>
        public string GetDs_Rex_Trichnop_Bhxh()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("GetAll_Rex_Trichnop_Bhxh", this.sqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Trả về 1 object Rex_Trichnop_Bhxh_Collection theo ky luong
        /// </summary>
        /// <returns></returns>
        //public itvsbiz.Model.Rex.Rex_Trichnop_Bhxh_Collection Get_Rex_Trichnop_Bhxh_Collection_By_Kyluong(itvsbiz.Domain.Rex.Rex_Trichnop_Bhxh rex_Trichnop_Bhxh)
        //{
        //    itvsbiz.Model.Rex.Rex_Trichnop_Bhxh_Collection rex_Luong_nhom_Collection = (itvsbiz.Model.Rex.Rex_Trichnop_Bhxh_Collection)_SqlMapper.QueryForList("GetAll_Rex_Trichnop_Bhxh_By_Kyluong", rex_Trichnop_Bhxh);
        //    return rex_Luong_nhom_Collection;
        //}

        /// <summary>
        /// Tra ve DataSet Rex_Trichnop_Bhxh_By_Kyluong
        /// </summary>
        /// <param name="rex_Trichnop_Bhxh"></param>
        /// <returns></returns>
        public string GetDs_Rex_Trichnop_Bhxh_By_Kyluong(Ecm.Domain.Rex.Rex_Trichnop_Bhxh rex_Trichnop_Bhxh)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("GetAll_Rex_Trichnop_Bhxh_By_Kyluong", this.sqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", rex_Trichnop_Bhxh.Id_Bophan));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thang_Kyluong", rex_Trichnop_Bhxh.Thang_Kyluong));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nam_Kyluong", rex_Trichnop_Bhxh.Nam_Kyluong));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Insert data vào bảng Rex_Trichnop_Bhxh từ một object Domain.Rex.Rex_Trichnop_Bhxh
        /// </summary>
        /// <param name="Rex_Luong_Hieunang"></param>
        /// <returns></returns>
        public object Insert_Rex_Trichnop_Bhxh(Ecm.Domain.Rex.Rex_Trichnop_Bhxh rex_Trichnop_Bhxh)
        {

            try
            {
                System.Data.DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("rex_trichnop_bhxh_init", this.sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nam_Kyluong", rex_Trichnop_Bhxh.Nam_Kyluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thang_Kyluong", rex_Trichnop_Bhxh.Thang_Kyluong));
                
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
        /// Update data vào bảng Rex_Trichnop_Bhxh từ một object Domain.Rex.Rex_Trichnop_Bhxh
        /// </summary>
        /// <param name="Rex_Trichnop_Bhxh"></param>
        /// <returns></returns>
        public object Update_Rex_Trichnop_Bhxh_Fresh(Ecm.Domain.Rex.Rex_Trichnop_Bhxh rex_Trichnop_Bhxh)
        {
            try
            {
                System.Data.DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("rex_trichnop_bhxh_refresh", this.sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nam_Kyluong", rex_Trichnop_Bhxh.Nam_Kyluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thang_Kyluong", rex_Trichnop_Bhxh.Thang_Kyluong));

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
        /// Update data vào bảng Rex_Trichnop_Bhxh từ một object Domain.Rex.Rex_Trichnop_Bhxh
        /// </summary>
        /// <param name="Rex_Trichnop_Bhxh"></param>
        /// <returns></returns>
        public object Update_Rex_Trichnop_Bhxh(Ecm.Domain.Rex.Rex_Trichnop_Bhxh rex_Trichnop_Bhxh)
        {
            try
            {
                System.Data.DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Update_Rex_Trichnop_Bhxh", this.sqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Pccv", rex_Trichnop_Bhxh.Pccv));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Pctnvk", rex_Trichnop_Bhxh.Pctnvk));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Pctnnn", rex_Trichnop_Bhxh.Pctnnn));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Pckv", rex_Trichnop_Bhxh.Pckv));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Bhxh", rex_Trichnop_Bhxh.Bhxh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Bhyt", rex_Trichnop_Bhxh.Bhyt));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", rex_Trichnop_Bhxh.Ghichu));

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
        /// Cập nhật trên một dataset, đồng thời cập nhật vào bảng Rex_Trichnop_Bhxh
        /// </summary>
        /// <param name="ds_Rex_Luong_Hieunang"></param>
        /// <returns>bool</returns>
        public bool Update_Rex_Trichnop_Bhxh_Collection(DataSet ds_Rex_Trichnop_Bhxh)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from rex_trichnop_bhxh", sqlConnection);
                System.Data.OleDb.OleDbCommandBuilder oleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(oleDbDataAdapter);
                oleDbDataAdapter = oleDbCommandBuilder.DataAdapter;

                oleDbDataAdapter.Update(ds_Rex_Trichnop_Bhxh, "GridTable");

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
