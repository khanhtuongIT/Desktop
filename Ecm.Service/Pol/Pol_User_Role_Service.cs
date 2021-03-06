using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;

namespace Ecm.Service.Pol
{
    public class Pol_User_Role_Service : MarshalByRefObject
    {
        #region private fields
        private System.Data.OleDb.OleDbConnection _SqlMapper;
        #endregion

        #region Properties
        public string DataSet_Pol_User_Role
        {
            get { return DataSet_Pol_User_Role; }
        }
        #endregion

        #region Method
        public Pol_User_Role_Service(System.Data.OleDb.OleDbConnection sqlmapper)
        {
            this._SqlMapper = sqlmapper;
        }

        private Domain.Pol.Pol_User_Role Get_Pol_User_Role(DataRow row)
        {
            Domain.Pol.Pol_User_Role Pol_User_Role = new Ecm.Domain.Pol.Pol_User_Role();
            if ("" + row["Id_User"] != null)
                Pol_User_Role.Id_User = row["Id_User"];
            if ("" + row["Id_Role"] != null)
                Pol_User_Role.Id_Role = row["Id_Role"];
            if ("" + row["Allow_Add"] != "")
                Pol_User_Role.Allow_Add = row["Allow_Add"];
            if ("" + row["Allow_Edit"] != "")
                Pol_User_Role.Allow_Edit = row["Allow_Edit"];
            if ("" + row["Allow_Delete"] != "")
                Pol_User_Role.Allow_Delete = row["Allow_Delete"];
            if ("" + row["Allow_Query"] != "")
                Pol_User_Role.Allow_Query = row["Allow_Query"];
            if ("" + row["Allow_Print"] != "")
                Pol_User_Role.Allow_Print = row["Allow_Print"];
            if ("" + row["Allow_Full"] != "")
                Pol_User_Role.Allow_Full = row["Allow_Full"];
            if ("" + row["Allow_None"] != "")
                Pol_User_Role.Allow_None = row["Allow_None"];
            return Pol_User_Role;
        }
        #endregion

        #region implemetns IObService
        /// <summary>
        ///Chọn các đối tượng dữ liệu Pol_User_Role theo điều kiện Id_User và Id_Role, trả về một mảng Pol_Dm_Role_Collection
        /// </summary>
        /// <returns>Pol_Dm_Role_Collection</returns>
        public string Select_Pol_User_Role_ByID_UserRole(Ecm.Domain.Pol.Pol_User_Role Pol_User_Role)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_User_Role_Select_ByID_UserRole", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            //Parameters
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_User", Pol_User_Role.Id_User));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Role", Pol_User_Role.Id_Role));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 

        }
        /// <summary>
        /// Chọn các đối tượng dữ liệu Pol_User_Role theo điều kiện Id_Role, trả về một mảng Pol_Dm_User_Collection
        /// </summary>
        /// <returns>Pol_Dm_User_Collection</returns>
        public string Pol_User_Role_Select_ByIDRole(Ecm.Domain.Pol.Pol_User_Role Pol_User_Role)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_User_Role_Select_ByIDRole", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            //Parameters
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Id_Role", Pol_User_Role.Id_Role));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Chọn các đối tượng dữ liệu Pol_User_Role theo điều kiện Id_User, trả về một mảng Pol_Dm_Role_Collection
        /// </summary>
        /// <returns>Pol_Dm_Role_Collection</returns>
        public string Pol_User_Role_Select_ByIDUser(Ecm.Domain.Pol.Pol_User_Role Pol_User_Role)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_User_Role_Select_ByIDUser", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            //Parameters
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_User", Pol_User_Role.Id_User));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

       

        /// <summary>
        ///Thêm một đối tượng dữ liệu Pol_User_Role
        /// </summary>
        public object Pol_User_Role_Insert(Ecm.Domain.Pol.Pol_User_Role Pol_User_Role)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_User_Role_Insert", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            //Parameters
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_User", Pol_User_Role.Id_User));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Role", Pol_User_Role.Id_Role));

            oleDbCommand.ExecuteNonQuery();
            return null;// _SqlMapper.Insert("Pol_User_Role_Insert", Pol_User_Role);
        }

        /// <summary>
        /// Cập nhật một đối tượng dữ liệu Pol_User_Role
        /// </summary>
        public object Update_Pol_User_Role(Ecm.Domain.Pol.Pol_User_Role Pol_User_Role)
        {

            return null;//_SqlMapper.Update("Update_Pol_User_Role", Pol_User_Role);
        }

        /// <summary>
        /// Xáo một đối tượng dữ liệu Pol_User_Role
        /// </summary>
        public object Pol_User_Role_Delete(Ecm.Domain.Pol.Pol_User_Role Pol_User_Role)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_User_Role_Delete", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            //Parameters
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_User", Pol_User_Role.Id_User));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Role", Pol_User_Role.Id_Role));

            oleDbCommand.ExecuteNonQuery();
            return null;//_SqlMapper.Delete("Pol_User_Role_Delete", Pol_User_Role);
        }

        /// <summary>
        /// Cập nhật các đối tượng dữ liệu Pol_User_Role trong DataSet đồng thời cập nhật CSDL
        /// </summary>
        public bool Update_Pol_User_Role_Collection(DataSet ds_Pol_User_Role)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Pol_User_Role", _SqlMapper);
                System.Data.OleDb.OleDbCommandBuilder oleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(oleDbDataAdapter);
                oleDbDataAdapter = oleDbCommandBuilder.DataAdapter;

                oleDbDataAdapter.Update(ds_Pol_User_Role, "GridTable");

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
