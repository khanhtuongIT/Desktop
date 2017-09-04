using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Rex
{
    public class Rex_Chamcong_Thang_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Rex_Chamcong_Thang_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService
        /// <summary>
        /// Trả về một dataset Dm_Donvitinh
        /// </summary>
        /// <returns></returns>
        public string Get_All_Rex_Chamcong_Thang(object Nam_Kyluong, object Thang_Kyluong, object Id_Bophan, object Baogom_Nghiphep, object Inc_Bophan_Tructhuoc)
        {
            try
            {
                System.Data.DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Chamcong_Thang_SelectAll", this._SqlConnection);
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nam_Kyluong", Nam_Kyluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thang_Kyluong", Thang_Kyluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", Id_Bophan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Baogom_Nghiphep", Baogom_Nghiphep));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Inc_Bophan_Tructhuoc", Inc_Bophan_Tructhuoc));
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
                oleDbDataAdapter.Fill(dsCollection, "GridTable");
                            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }

        public object Rex_Chamcong_Thang_Tinhgiocong(Domain.Rex.Rex_Chamcong_Thang rex_Chamcong_Thang)
        {
            try
            {
                System.Data.DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Chamcong_Thang_Tinhgiocong", this._SqlConnection);
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nam_Kyluong", rex_Chamcong_Thang.Nam_Kyluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thang_Kyluong", rex_Chamcong_Thang.Thang_Kyluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", rex_Chamcong_Thang.Id_Bophan));
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                return oleDbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }
       
        /// <summary>
        /// Update một Collection Rex_Chamcong_Thang vào DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Rex_Chamcong_Thang_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(
                    "select [id_chamcong_thang],[id_nhansu],[nam_kyluong],[thang_kyluong],[ngay01],[ngay02],[ngay03],"
                    +"[ngay04],[ngay05],[ngay06],[ngay07],[ngay08],[ngay09],[ngay10],[ngay11],[ngay12],[ngay13],[ngay14],"
                    +"[ngay15],[ngay16],[ngay17],[ngay18],[ngay19],[ngay20],[ngay21],[ngay22],[ngay23],[ngay24],[ngay25]"
                    +",[ngay26],[ngay27],[ngay28],[ngay29],[ngay30],[ngay31],[hs_chuyencan],[hs_trachnhiem] from Rex_Chamcong_Thang", _SqlConnection);
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

        public object Init_Rex_Chamcong_Thang_ByFinger(Domain.Rex.Rex_Chamcong_Thang Rex_Chamcong_Thang)
        {
            try
            {
                System.Data.DataSet dsCollection = new DataSet();
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Chamcong_Thang_Init_ByFinger", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nam_Kyluong", Rex_Chamcong_Thang.Nam_Kyluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thang_Kyluong", Rex_Chamcong_Thang.Thang_Kyluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", Rex_Chamcong_Thang.Id_Bophan));
            
                oleDbCommand.ExecuteNonQuery();
            
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
