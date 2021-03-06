using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;

namespace Ecm.Service.Pol
{
    public class Pol_Dm_Action_Service : MarshalByRefObject
    {
        #region private fields
        private System.Data.OleDb.OleDbConnection _SqlMapper;
        #endregion

        #region Properties
        public string DataSet_Pol_Dm_Action
        {
            get { return DataSet_Pol_Dm_Action; }
        }
        #endregion

        #region Method
        public Pol_Dm_Action_Service(System.Data.OleDb.OleDbConnection sqlmapper)
        {
            this._SqlMapper = sqlmapper;
        }

        private Domain.Pol.Pol_Dm_Action Get_Pol_Dm_Action(DataRow row)
        {
            Domain.Pol.Pol_Dm_Action Pol_Dm_Action = new Ecm.Domain.Pol.Pol_Dm_Action();
            if ("" + row["Id_Action"] != "")
                Pol_Dm_Action.Id_Action = row["Id_Action"];
            Pol_Dm_Action.Action_Name = row["Action_Name"];
            Pol_Dm_Action.Action_Description = row["Action_Description"];
            return Pol_Dm_Action;
        }
        #endregion

        #region implemetns IObService
        /// <summary>
        /// Chọn tất cả đối tượng dữ liệu Pol_Dm_Action, trả về một mảng Pol_Dm_Action_Collection
        /// </summary>
        /// <returns>Pol_Dm_Action_Collection</returns>
        public string Get_Pol_Dm_Action_Collection()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_Dm_Action_SelectAll", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            //Parameters
            //oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Id_Role", Pol_Action_Role.Id_Role));
            //oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Id_Right", Pol_Action_Role.Id_Right));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None);  

        }

        /// <summary>
        /// Thêm một đối tượng dữ liệu Pol_Dm_Action
        /// </summary>
        public object Pol_Dm_Action_Insert(Ecm.Domain.Pol.Pol_Dm_Action Pol_Dm_Action)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_Dm_Action_Insert", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            //Parameters
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Action_Name", Pol_Dm_Action.Action_Name));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Action_Description", Pol_Dm_Action.Action_Description));
            oleDbCommand.ExecuteNonQuery();
            return null;// _SqlMapper.Insert("Pol_Dm_Action_Insert", Pol_Dm_Action);
        }

        public object Pol_Dm_Action_Update(Ecm.Domain.Pol.Pol_Dm_Action Pol_Dm_Action)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_Dm_Action_Update", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            //Parameters
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Action", Pol_Dm_Action.Id_Action));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Action_Name", Pol_Dm_Action.Action_Name));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Action_Description", Pol_Dm_Action.Action_Description));
            oleDbCommand.ExecuteNonQuery();
            return null;//_SqlMapper.Update("Pol_Dm_Action_Update", Pol_Dm_Action);
        }

        /// <summary>
        /// Thêm một đối tượng dữ liệu Pol_Dm_Action
        /// </summary>
        public object Pol_Dm_Action_Delete(Ecm.Domain.Pol.Pol_Dm_Action Pol_Dm_Action)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_Dm_Action_Delete", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            //Parameters
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Action", Pol_Dm_Action.Id_Action));
            oleDbCommand.ExecuteNonQuery();
            return null;//_SqlMapper.Delete("Pol_Dm_Action_Delete", Pol_Dm_Action);
        }

        /// <summary>
        /// Cập nhật các đối tượng dữ liệu Pol_Dm_Action trong DataSet đồng thời cập nhật trong CSDL
        /// </summary>
        public bool Update_Pol_Dm_Action_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Pol_Dm_Action", _SqlMapper);
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
