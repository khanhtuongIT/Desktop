using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.MasterTables.Ware
{
    public class Ware_Dm_Nhasanxuat_Service
    {
        System.Data.OleDb.OleDbConnection _SqlConnection;

        public Ware_Dm_Nhasanxuat_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        /// <summary>
        /// Trả về một dataset Ware_Dm_Nhasanxuat
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Dm_Nhasanxuat()
        {
            DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Nhasanxuat_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");

                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Insert đối tượng Ware_Dm_Nhasanxuat vào DB.
        /// </summary>
        /// <param name="Ware_Dm_Nhasanxuat"></param>
        /// <returns></returns>
        public object Insert_Ware_Dm_Nhasanxuat(Ecm.Domain.MasterTables.Ware.Ware_Dm_Nhasanxuat Ware_Dm_Nhasanxuat)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Nhasanxuat_Insert", _SqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Nhasanxuat",  Ware_Dm_Nhasanxuat.Ma_Nhasanxuat));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Nhasanxuat", Ware_Dm_Nhasanxuat.Ten_Nhasanxuat));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Diachi",         Ware_Dm_Nhasanxuat.Diachi));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Masothue",       Ware_Dm_Nhasanxuat.Masothue));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dienthoai",      Ware_Dm_Nhasanxuat.Dienthoai));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Fax",            Ware_Dm_Nhasanxuat.Fax));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Email",          Ware_Dm_Nhasanxuat.Email));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Website",        Ware_Dm_Nhasanxuat.Website));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Quocgia",     Ware_Dm_Nhasanxuat.Id_Quocgia));

                OleDbCommand.ExecuteNonQuery();
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Ware_Dm_Nhasanxuat", DateTime.Now);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        /// <summary>
        /// Update đối tượng Ware_Dm_Nhasanxuat vào DB.
        /// </summary>
        /// <param name="Ware_Dm_Nhasanxuat"></param>
        /// <returns></returns>
        public object Update_Ware_Dm_Nhasanxuat(Domain.MasterTables.Ware.Ware_Dm_Nhasanxuat Ware_Dm_Nhasanxuat)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Nhasanxuat_Update", _SqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhasanxuat",      Ware_Dm_Nhasanxuat.Id_Nhasanxuat));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Nhasanxuat",      Ware_Dm_Nhasanxuat.Ma_Nhasanxuat));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Nhasanxuat",     Ware_Dm_Nhasanxuat.Ten_Nhasanxuat));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Diachi",             Ware_Dm_Nhasanxuat.Diachi));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Masothue",           Ware_Dm_Nhasanxuat.Masothue));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dienthoai",          Ware_Dm_Nhasanxuat.Dienthoai));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Fax",                Ware_Dm_Nhasanxuat.Fax));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Email",              Ware_Dm_Nhasanxuat.Email));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Website",            Ware_Dm_Nhasanxuat.Website));
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Quocgia",         Ware_Dm_Nhasanxuat.Id_Quocgia));

                OleDbCommand.ExecuteNonQuery();
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Ware_Dm_Nhasanxuat", DateTime.Now);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        /// <summary>
        /// Delete đối tượng Ware_Dm_Nhasanxuat vào DB.
        /// </summary>
        /// <param name="Ware_Dm_Nhasanxuat"></param>
        /// <returns></returns>
        public object Delete_Ware_Dm_Nhasanxuat(Domain.MasterTables.Ware.Ware_Dm_Nhasanxuat Ware_Dm_Nhasanxuat)
        {
            try
            {
                System.Data.OleDb.OleDbCommand OleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Dm_Nhasanxuat_Delete", _SqlConnection);
                OleDbCommand.CommandType = CommandType.StoredProcedure;
                OleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhasanxuat", Ware_Dm_Nhasanxuat.Id_Nhasanxuat));

                OleDbCommand.ExecuteNonQuery();
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Ware_Dm_Nhasanxuat", DateTime.Now);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        /// <summary>
        /// Update Collection Ware_Dm_Nhasanxuat vào DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Ware_Dm_Nhasanxuat_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Dm_Nhasanxuat", _SqlConnection);
                System.Data.OleDb.OleDbCommandBuilder oleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(oleDbDataAdapter);
                oleDbDataAdapter = oleDbCommandBuilder.DataAdapter;

                oleDbDataAdapter.Update(dsCollection, "GridTable");
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Ware_Dm_Nhasanxuat", DateTime.Now);
                }
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
