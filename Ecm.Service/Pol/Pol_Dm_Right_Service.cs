using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
namespace Ecm.Service.Pol
{
    public class Pol_Dm_Right_Service : MarshalByRefObject
    {
        #region private fields
        private System.Data.OleDb.OleDbConnection _SqlMapper;
        #endregion

        #region Properties
        public string DataSet_Pol_Dm_Right
        {
            get { return DataSet_Pol_Dm_Right; }
        }
        #endregion

        #region Method
        public Pol_Dm_Right_Service(System.Data.OleDb.OleDbConnection sqlmapper)
        {
            this._SqlMapper = sqlmapper;
        }

        private Domain.Pol.Pol_Dm_Right Get_Pol_Dm_Right(DataRow row)
        {
            Domain.Pol.Pol_Dm_Right Pol_Dm_Right = new Ecm.Domain.Pol.Pol_Dm_Right();
            if ("" + row["Id_Right"] != "")
                Pol_Dm_Right.Id_Right = row["Id_Right"];
            if ("" + row["Id_Right_Parent"] != "")
                Pol_Dm_Right.Id_Right_Parent = row["Id_Right_Parent"];
            if ("" + row["Right_System_Name"] != "")
                Pol_Dm_Right.Right_System_Name = row["Right_System_Name"];
            if ("" + row["Right_Display_Name"] != "")
                Pol_Dm_Right.Right_Display_Name = row["Right_Display_Name"];
            if ("" + row["Right_Description"] != "")
                Pol_Dm_Right.Right_Description = row["Right_Description"];
            if ("" + row["Build_In"] != "")
                Pol_Dm_Right.Build_In = row["Build_In"];
            return Pol_Dm_Right;
        }
        #endregion

        #region implemetns IObService
       
        public object Pol_Dm_Right_Insert(Ecm.Domain.Pol.Pol_Dm_Right Pol_Dm_Right)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_Dm_Right_Insert", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            //Parameters
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Right_Parent", Pol_Dm_Right.Id_Right_Parent));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Right_System_Name", Pol_Dm_Right.Right_System_Name));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Right_Display_Name", Pol_Dm_Right.Right_Display_Name));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Right_Description", Pol_Dm_Right.Right_Description));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Build_In", Pol_Dm_Right.Build_In));

            oleDbCommand.ExecuteNonQuery();
            return null;// _SqlMapper.Insert("Pol_Dm_Right_Insert", Pol_Dm_Right);
        }
        public object Pol_Dm_Right_Update(Ecm.Domain.Pol.Pol_Dm_Right Pol_Dm_Right)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_Dm_Right_Update", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            //Parameters
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Right", Pol_Dm_Right.Id_Right));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Right_Parent", Pol_Dm_Right.Id_Right_Parent));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Right_System_Name", Pol_Dm_Right.Right_System_Name));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Right_Display_Name", Pol_Dm_Right.Right_Display_Name));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Right_Description", Pol_Dm_Right.Right_Description));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Build_In", Pol_Dm_Right.Build_In));

            oleDbCommand.ExecuteNonQuery();
            return null;//_SqlMapper.Update("Pol_Dm_Right_Update", Pol_Dm_Right);
        }
        public object Pol_Dm_Right_Delete(Ecm.Domain.Pol.Pol_Dm_Right Pol_Dm_Right)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_Dm_Right_Delete", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            //Parameters
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Right", Pol_Dm_Right.Id_Right));
            oleDbCommand.ExecuteNonQuery();

            return null;//_SqlMapper.Delete("Pol_Dm_Right_Delete", Pol_Dm_Right);
        }
        public bool Update_Pol_Dm_Right_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Pol_Dm_Right", _SqlMapper);
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


        /// <summary>
        /// Chọn tất cả các đối tượng dữ liệu Pol_Dm_Right, trả về một mảng Pol_Dm_Right_Collection
        /// </summary>
        /// <returns>Pol_Dm_Right_Collection</returns>
        public string Get_Pol_Dm_Right_Collection()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_Dm_Right_SelectAll", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 

        }

        /// <summary>
        /// Chọn tất một đối tượng dữ liệu Pol_Dm_Right theo điều kiện Id_Right, trả về một mảng Pol_Dm_Right_Collection
        /// </summary>
        /// <returns>Pol_Dm_Right_Collection</returns>
        public string Pol_Dm_Right_Select_ByID(Ecm.Domain.Pol.Pol_Dm_Right Pol_Dm_Right)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_Dm_Right_Select_ByID", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            //Parameters
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Id_Right", Pol_Dm_Right.Id_Right));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 

        }

        /// <summary>
        /// Chọn một đối tượng dữ liệu Pol_Dm_Right theo điều kiện Right_System_Name, trả về một mảng Pol_Dm_Right_Collection
        /// </summary>
        /// <returns>Pol_Dm_Right_Collection</returns>
        public string Pol_Dm_Right_Select_ByName(Ecm.Domain.Pol.Pol_Dm_Right Pol_Dm_Right)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Pol_Dm_Right_Select_ByName", _SqlMapper);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            //Parameters
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Right_System_Name", Pol_Dm_Right.Right_System_Name));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

       
        #endregion
    }
}
