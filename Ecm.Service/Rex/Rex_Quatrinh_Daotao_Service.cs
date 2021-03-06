using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Rex
{
    public class Rex_Quatrinh_Daotao_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Rex_Quatrinh_Daotao_Service(System.Data.OleDb.OleDbConnection sqlMaper)
        {
            this._SqlConnection = sqlMaper;
        }
        #endregion

        #region implemetns IObService
        
        /// <summary>
        /// Trả về một dataset Quatrinh_Daotao
        /// </summary>
        /// <returns></returns>
        public string Get_All_Rex_Quatrinh_Daotao_byNhanSu_Collection(Ecm.Domain.Rex.Rex_Nhansu rex_Nhansu)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Quatrinh_Daotao_SelectByNhansu", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", rex_Nhansu.Id_Nhansu));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Delete 1 doi tuong Quatrinh_Daotao trong DB
        /// </summary>
        /// <param name="rex_Quatrinh_Daotao"></param>
        /// <returns></returns>
        public object Delete_Rex_Quatrinh_Daotao(Ecm.Domain.Rex.Rex_Quatrinh_Daotao rex_Quatrinh_Daotao)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Quatrinh_Daotao_Delete",_SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Quatrinh_Daotao", rex_Quatrinh_Daotao.Id_Quatrinh_Daotao));

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
        /// Update 1 collection Quatrinh_Daotao vao DB
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Rex_Quatrinh_Daotao_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Rex_Quatrinh_Daotao", _SqlConnection);
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
