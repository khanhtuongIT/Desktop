using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;

namespace Ecm.Service.Pol
{
    public class Pol_Action_User_Service : MarshalByRefObject
    {
        #region private fields
        private System.Data.OleDb.OleDbConnection _SqlMapper;
        #endregion

        #region Properties
        public string DataSet_Pol_Action_User
        {
            get { return DataSet_Pol_Action_User; }
        }
        #endregion

        #region Method
        public Pol_Action_User_Service(System.Data.OleDb.OleDbConnection sqlmapper)
        {
            this._SqlMapper = sqlmapper;
        }

        private Domain.Pol.Pol_Action_User Get_Pol_Action_User(DataRow row)
        {
            Domain.Pol.Pol_Action_User Pol_Action_User = new Ecm.Domain.Pol.Pol_Action_User();
            if ("" + row["Id_Action"] != "")
                Pol_Action_User.Id_Action = row["Id_Action"];
            Pol_Action_User.Id_Right = row["Id_Right"];
            Pol_Action_User.Id_User = row["Id_User"];
            return Pol_Action_User;
        }
        #endregion

        #region implemetns IObService
        
        /// <summary>
        /// Chọn các đối tượng dữ liệu Pol_Action_User theo điều kiện Id_User và Id_Right, trả về một mảng Pol_Dm_Action_Collection
        /// </summary>
        /// <returns>Pol_Dm_Action_Collection</returns>
        public string Pol_Action_User_Select_ByID_UserRight(Ecm.Domain.Pol.Pol_Action_User Pol_Action_User)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_Action_User_Select_ByID_UserRight", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            //Parameters
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Id_User", Pol_Action_User.Id_User));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Id_Right", Pol_Action_User.Id_Right));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 

        }

        public string Pol_Action_User_Select_ByUSnRIName(string user_name, string right_system_name)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_Action_User_Select_ByUSnRIName", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            //Parameters
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("user_name", user_name));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("right_system_name", right_system_name));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 

        }
        /// <summary>
        /// Chọn các đối tượng dữ liệu Pol_Action_User theo điều kiện Id_User và Id_Right, trả về một mảng Pol_Dm_Action_Collection
        /// </summary>
        /// <returns>Pol_Dm_Action_Collection</returns>
        public string Pol_Action_User_Select_ByID_UserRight_ForAuth(Ecm.Domain.Pol.Pol_Action_User Pol_Action_User)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_Action_User_Select_ByID_UserRight_ForAuth", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            //Parameters
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Id_User", Pol_Action_User.Id_User));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Id_Right", Pol_Action_User.Id_Right));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 

        }

        /// <summary>
        /// Thêm một đối tượng dữ liệu Pol_Action_User
        /// </summary>
        public object Pol_Action_User_Insert(Ecm.Domain.Pol.Pol_Action_User Pol_Action_User)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_Action_User_Insert", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            //Parameters
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Id_Action", Pol_Action_User.Id_Action));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Id_User", Pol_Action_User.Id_User));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Id_Right", Pol_Action_User.Id_Right));

            oleDbCommand.ExecuteNonQuery();
            return null;//  _SqlMapper.Insert("Pol_Action_User_Insert", Pol_Action_User);
        }

        /// <summary>
        /// Cập nhật một đối tượng dữ liệu Pol_Action_User
        /// </summary>
        public object Update_Pol_Action_User(Ecm.Domain.Pol.Pol_Action_User Pol_Action_User)
        {
            return null;// _SqlMapper.Update("Update_Pol_Action_User", Pol_Action_User);
        }

        /// <summary>
        /// Xóa một đối tượng dữ liệu Pol_Action_User
        /// </summary>
        public object Pol_Action_User_Delete(Ecm.Domain.Pol.Pol_Action_User Pol_Action_User)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_Action_User_Delete", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            //Parameters
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Id_Action", Pol_Action_User.Id_Action));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Id_User", Pol_Action_User.Id_User));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Id_Right", Pol_Action_User.Id_Right));

            oleDbCommand.ExecuteNonQuery();
            return null;// _SqlMapper.Delete("Pol_Action_User_Delete", Pol_Action_User);
        }

        /// <summary>
        /// Cập nhật các đối tượng dữ liệu Pol_Action_User trong DataSet đồng thời cập nhật trong CSDL
        /// </summary>
        public bool Update_Pol_Action_User_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Pol_Action_User", _SqlMapper);
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
