using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;

namespace Ecm.Service.Pol
{
    public class Pol_Dm_Role_Service : MarshalByRefObject
    {
        #region private fields
        private System.Data.OleDb.OleDbConnection _SqlMapper;
        #endregion

        #region Properties
        public string DataSet_Pol_Dm_Role
        {
            get { return DataSet_Pol_Dm_Role; }
        }
        #endregion

        #region Method
        public Pol_Dm_Role_Service(System.Data.OleDb.OleDbConnection sqlmapper)
        {
            this._SqlMapper = sqlmapper;
        }

        private Domain.Pol.Pol_Dm_Role Get_Pol_Dm_Role(DataRow row)
        {
            Domain.Pol.Pol_Dm_Role Pol_Dm_Role = new Ecm.Domain.Pol.Pol_Dm_Role();
            if ("" + row["Id_Role"] != "")
                Pol_Dm_Role.Id_Role = row["Id_Role"];
            Pol_Dm_Role.Role_System_Name = row["Role_System_Name"];
            Pol_Dm_Role.Role_Description = row["Role_Description"];
            return Pol_Dm_Role;
        }
        #endregion

        #region implemetns IObService
        /// <summary>
        /// Chọn một đối tượng dữ liệu Pol_Dm_Role theo điều kiện Role_Name, trả về một mảng Pol_Dm_Role_Collection
        /// </summary>
        /// <returns>Pol_Dm_Role_Collection</returns>
        public string Select_Pol_Dm_Role_ByName(Ecm.Domain.Pol.Pol_Dm_Role Pol_Dm_Role)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_Dm_Role_Select_ByName", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            //Parameters
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Role_System_Name", Pol_Dm_Role.Role_System_Name));
            //oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Id_Right", Pol_Action_Role.Id_Right));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None);  

        }

        /// <summary>
        /// Chọn tất cả tượng dữ liệu Pol_Dm_Role, trả về một mảng Pol_Dm_Role_Collection
        /// </summary>
        /// <returns>Pol_Dm_Role_Collection</returns>
        public string Get_Pol_Dm_Role_Collection()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_Dm_Role_SelectAll", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            //Parameters
            //oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Id_Role", Pol_Action_Role.Id_Role));
            //oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Id_Right", Pol_Action_Role.Id_Right));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None);  

        }

        /// <summary>
        /// Chọn một đối tượng dữ liệu Pol_Dm_Role theo điều kiện Id_Role, trả về một mảng Pol_Dm_Role_Collection
        /// </summary>
        /// <returns>Pol_Dm_Role_Collection</returns>
        public string Pol_Dm_Role_Select_ByID(Ecm.Domain.Pol.Pol_Dm_Role Pol_Dm_Role)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_Dm_Role_Select_ByID", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            //Parameters
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Id_Role", Pol_Dm_Role.Id_Role));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None);  
        }

        /// <summary>
        /// Thêm một đối tượng dữ liệu Pol_Dm_Role
        /// </summary>
        public object Pol_Dm_Role_Insert(Ecm.Domain.Pol.Pol_Dm_Role Pol_Dm_Role)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_Dm_Role_Insert", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            //Parameters
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Role", System.Data.OleDb.OleDbType.BigInt));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Role_Parent", Pol_Dm_Role.Id_Role_Parent));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Role_System_Name", Pol_Dm_Role.Role_System_Name));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Role_Display_Name", Pol_Dm_Role.Role_Display_Name));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Role_Description", Pol_Dm_Role.Role_Description));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Build_In", Pol_Dm_Role.Build_In));

            oleDbCommand.Parameters["@Id_Role"].Direction = ParameterDirection.Output;

            oleDbCommand.ExecuteNonQuery();


            return oleDbCommand.Parameters["@Id_Role"].Value;// _SqlMapper.Insert("Pol_Dm_Role_Insert", Pol_Dm_Role);
        }

        /// <summary>
        /// Cập nhật một đối tượng dữ liệu Pol_Dm_Role
        /// </summary>
        public object Pol_Dm_Role_Update(Ecm.Domain.Pol.Pol_Dm_Role Pol_Dm_Role)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_Dm_Role_Update", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            //Parameters
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Role", Pol_Dm_Role.Id_Role));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Role_Parent", Pol_Dm_Role.Id_Role_Parent));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Role_System_Name", Pol_Dm_Role.Role_System_Name));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Role_Display_Name", Pol_Dm_Role.Role_Display_Name));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Role_Description", Pol_Dm_Role.Role_Description));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Build_In", Pol_Dm_Role.Build_In));


            oleDbCommand.ExecuteNonQuery();

            return null;// _SqlMapper.Update("Pol_Dm_Role_Update", Pol_Dm_Role);
        }

        /// <summary>
        /// Xóa một đối tượng dữ liệu Pol_Dm_Role
        /// </summary>
        public object Pol_Dm_Role_Delete(Ecm.Domain.Pol.Pol_Dm_Role Pol_Dm_Role)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_Dm_Role_Delete", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            //Parameters
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Role", Pol_Dm_Role.Id_Role));

            oleDbCommand.ExecuteNonQuery();
            return null;// _SqlMapper.Delete("Pol_Dm_Role_Delete", Pol_Dm_Role);
        }

        /// <summary>
        /// Cập nhật các đối tượng dữ liệu Pol_Dm_Role trong DataSet đồng thời cập nhật trong CSDL
        /// </summary>
        public bool Update_Pol_Dm_Role_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Pol_Dm_Role", _SqlMapper);
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
