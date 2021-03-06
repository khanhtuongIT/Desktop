using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;

namespace Ecm.Service.Pol
{
    public class Pol_User_Right_Service : MarshalByRefObject
    {
        #region private fields
        private System.Data.OleDb.OleDbConnection _SqlMapper;
        #endregion

        #region Properties
        public string DataSet_Pol_User_Right
        {
            get { return DataSet_Pol_User_Right; }
        }
        #endregion

        #region Method
        public Pol_User_Right_Service(System.Data.OleDb.OleDbConnection sqlmapper)
        {
            this._SqlMapper = sqlmapper;
        }

        private Domain.Pol.Pol_User_Right Get_Pol_User_Right(DataRow row)
        {
            Domain.Pol.Pol_User_Right Pol_User_Right = new Ecm.Domain.Pol.Pol_User_Right();
            if ("" + row["Id_User"] != "")
                Pol_User_Right.Id_User = row["Id_User"];
            if ("" + row["Id_Right"] != "")
                Pol_User_Right.Id_Right = row["Id_Right"];
            if ("" + row["Allow_Add"] != "")
                Pol_User_Right.Allow_Add = row["Allow_Add"];
            if ("" + row["Allow_Edit"] != "")
                Pol_User_Right.Allow_Edit = row["Allow_Edit"];
            if ("" + row["Allow_Delete"] != "")
                Pol_User_Right.Allow_Delete = row["Allow_Delete"];
            if ("" + row["Allow_Query"] != "")
                Pol_User_Right.Allow_Query = row["Allow_Query"];
            if ("" + row["Allow_Print"] != "")
                Pol_User_Right.Allow_Print = row["Allow_Print"];
            if ("" + row["Allow_Full"] != "")
                Pol_User_Right.Allow_Full = row["Allow_Full"];
            if ("" + row["Allow_None"] != "")
                Pol_User_Right.Allow_None = row["Allow_None"];
            return Pol_User_Right;
        }
        #endregion

        #region implemetns IObService
       

        /// <summary>
        /// Chọn các đối tượng dữ liệu Pol_User_Right theo điều kiện Id_Right, trả về một mảng Pol_Dm_Right_Collection
        /// </summary>
        /// <returns>Pol_Dm_User_Collection</returns>
        public string Pol_User_Right_Select_ByIDRight(Ecm.Domain.Pol.Pol_User_Right Pol_User_Right)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_User_Right_Select_ByIDRight", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            //Parameters
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Id_Right", Pol_User_Right.Id_Right));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Chọn các đối tượng dữ liệu Pol_User_Right theo điều kiện Id_User, trả về một mảng Pol_Dm_Right_Collection
        /// </summary>
        /// <returns>Pol_Dm_User_Collection</returns>
        public string Pol_User_Right_Select_ByIDUser(Ecm.Domain.Pol.Pol_User_Right Pol_User_Right)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_User_Right_Select_ByIDUser", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            //Parameters
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Id_User", Pol_User_Right.Id_User));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Thêm một đối tượng dữ liệu Pol_User_Right
        /// </summary>
        public object Pol_User_Right_Insert(Ecm.Domain.Pol.Pol_User_Right Pol_User_Right)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_User_Right_Insert", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            //Parameters
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_User", Pol_User_Right.Id_User));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Right", Pol_User_Right.Id_Right));

            oleDbCommand.ExecuteNonQuery();
            return null;//_SqlMapper.Insert("Pol_User_Right_Insert", Pol_User_Right);
        }

        /// <summary>
        /// Cập nhật một đối tượng dữ liệu Pol_User_Right
        /// </summary>
        public object Update_Pol_User_Right(Ecm.Domain.Pol.Pol_User_Right Pol_User_Right)
        {
            return null;//_SqlMapper.Update("Update_Pol_User_Right", Pol_User_Right);
        }

        /// <summary>
        /// Xóa một đối tượng dữ liệu Pol_User_Right
        /// </summary>
        public object Pol_User_Right_Delete(Ecm.Domain.Pol.Pol_User_Right Pol_User_Right)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_User_Right_Delete", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            //Parameters
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_User", Pol_User_Right.Id_User));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Right", Pol_User_Right.Id_Right));

            oleDbCommand.ExecuteNonQuery();
            return null;//_SqlMapper.Delete("Pol_User_Right_Delete", Pol_User_Right);
        }

        /// <summary>
        /// Cập nhật một đối tượng dữ liệu Pol_User_Right trong DataSet đồng thời cập nhật trong CSDL
        /// </summary>
        public bool Update_Pol_User_Right_Collection(DataSet ds_Pol_User_Right)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Pol_User_Right", _SqlMapper);
                System.Data.OleDb.OleDbCommandBuilder oleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(oleDbDataAdapter);
                oleDbDataAdapter = oleDbCommandBuilder.DataAdapter;

                oleDbDataAdapter.Update(ds_Pol_User_Right, "GridTable");

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
