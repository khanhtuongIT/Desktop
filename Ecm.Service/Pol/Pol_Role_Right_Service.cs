using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;

namespace Ecm.Service.Pol
{
    public class Pol_Role_Right_Service : MarshalByRefObject
    {
        #region private fields
        private System.Data.OleDb.OleDbConnection _SqlMapper;
        #endregion

        #region Properties
        public string DataSet_Pol_Role_Right
        {
            get { return DataSet_Pol_Role_Right; }
        }
        #endregion

        #region Method
        public Pol_Role_Right_Service(System.Data.OleDb.OleDbConnection sqlmapper)
        {
            this._SqlMapper = sqlmapper;
        }

        private Domain.Pol.Pol_Role_Right Get_Pol_Role_Right(DataRow row)
        {
            Domain.Pol.Pol_Role_Right Pol_Role_Right = new Ecm.Domain.Pol.Pol_Role_Right();
            if ("" + row["Id_Role"] != "")
                Pol_Role_Right.Id_Role = row["Id_Role"];
            if ("" + row["Id_Right"] != "")
                Pol_Role_Right.Id_Right = row["Id_Right"];
            if ("" + row["Allow_Add"] != "")
                Pol_Role_Right.Allow_Add = row["Allow_Add"];
            if ("" + row["Allow_Edit"] != "")
                Pol_Role_Right.Allow_Edit = row["Allow_Edit"];
            if ("" + row["Allow_Delete"] != "")
                Pol_Role_Right.Allow_Delete = row["Allow_Delete"];
            if ("" + row["Allow_Query"] != "")
                Pol_Role_Right.Allow_Query = row["Allow_Query"];
            if ("" + row["Allow_Print"] != "")
                Pol_Role_Right.Allow_Print = row["Allow_Print"];
            if ("" + row["Allow_Full"] != "")
                Pol_Role_Right.Allow_Full = row["Allow_Full"];
            if ("" + row["Allow_None"] != "")
                Pol_Role_Right.Allow_None = row["Allow_None"];
            return Pol_Role_Right;
        }
        #endregion

        #region implemetns IObService
        
        /// <summary>
        /// Chọn các đối tượng dữ liệu Pol_Role_Right theo điều kiện Id_Role, trả về một mảng Pol_Dm_Right_Collection
        /// </summary>
        /// <returns>Pol_Dm_Right_Collection</returns>
        public string Pol_Role_Right_Select_ByIDRole(Ecm.Domain.Pol.Pol_Role_Right Pol_Role_Right)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_Role_Right_Select_ByIDRole", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            //Parameters
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Id_Role", Pol_Role_Right.Id_Role));
            //oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Id_Right", Pol_Role_Right.Id_Right));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 

        }
  
        /// <summary>
        /// fr 20101104
        /// Chọn các đối tượng dữ liệu Pol_Role_Right theo điều kiện Id_Role, trả về một mảng Pol_Dm_Right_Collection
        /// </summary>
        /// <returns>Pol_Dm_Right_Collection</returns>
        public string Pol_Role_Right_SelectAll()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_Role_Right_SelectAll", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 

        }


        /// <summary>
        /// /// Chọn các đối tượng dữ liệu Pol_Role_Right theo điều kiện Id_Right, trả về một mảng Pol_Dm_Role_Collection
        /// </summary>
        /// <returns>Pol_Dm_Role_Collection</returns>
        public string Pol_Role_Right_Select_ByIDRight(Ecm.Domain.Pol.Pol_Role_Right Pol_Role_Right)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_Role_Right_Select_ByIDRight", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            //Parameters
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Id_Right", Pol_Role_Right.Id_Right));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// fr 20101105
        /// init Pol_Role_Right
        /// </summary>
        public object Pol_Role_Right_Init()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_Role_Right_Init", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.ExecuteNonQuery();
            return true;// _SqlMapper.Insert("Pol_Role_Right_Insert", Pol_Role_Right);
        }
 
        /// <summary>
        /// fr 20101105
        /// reset Pol_Role_Right
        /// </summary>
        public object Pol_Role_Right_Reset()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_Role_Right_Reset", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.ExecuteNonQuery();
            return true;// _SqlMapper.Insert("Pol_Role_Right_Insert", Pol_Role_Right);
        }
        /// <summary>
        /// Thêm một đối tượng dữ liệu Pol_Role_Right
        /// </summary>
        public object Pol_Role_Right_Insert(Ecm.Domain.Pol.Pol_Role_Right Pol_Role_Right)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_Role_Right_Insert", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            //Parameters
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Role", Pol_Role_Right.Id_Role));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Right", Pol_Role_Right.Id_Right));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Allow_Add", Pol_Role_Right.Allow_Add));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Allow_Edit", Pol_Role_Right.Allow_Edit));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Allow_Delete", Pol_Role_Right.Allow_Delete));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Allow_Query", Pol_Role_Right.Allow_Query));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Allow_Print", Pol_Role_Right.Allow_Print));

            oleDbCommand.ExecuteNonQuery();
            return null;// _SqlMapper.Insert("Pol_Role_Right_Insert", Pol_Role_Right);
        }

        /// <summary>
        /// Cập nhật một đối tượng dữ liệu Pol_Role_Right
        /// </summary>
        public object Update_Pol_Role_Right(Ecm.Domain.Pol.Pol_Role_Right Pol_Role_Right)
        {
            return null;//_SqlMapper.Update("Update_Pol_Role_Right", Pol_Role_Right);
        }

        /// <summary>
        /// Xóa một đối tượng dữ liệu Pol_Role_Right
        /// </summary>
        public object Pol_Role_Right_Delete(Ecm.Domain.Pol.Pol_Role_Right Pol_Role_Right)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_Role_Right_Delete", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            //Parameters
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Role", Pol_Role_Right.Id_Role));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Right", Pol_Role_Right.Id_Right));

            oleDbCommand.ExecuteNonQuery();
            return null;//_SqlMapper.Delete("Pol_Role_Right_Delete", Pol_Role_Right);
        }

        /// <summary>
        /// Cập nhật các đối tượng dữ liệu Pol_Role_Right trong DataSet đồng thời cập nhật trong CSDL
        /// </summary>
        public bool Update_Pol_Role_Right_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Pol_Role_Right", _SqlMapper);
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
