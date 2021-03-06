using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Ware
{
    public class Ware_Phieuchi_Congno_Service
    {
         #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Ware_Phieuchi_Congno_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService
        /// <summary>
        /// Trả về một dataset Phieu_Chi
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Phieuchi_Congno()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieuchi_Congno_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Trả về một dataset Phieu_Chi
        /// </summary>
        /// <returns></returns>
        public string Get_RptWare_Muahang_Congno_Tra(object ngay_Batdau, object ngay_Ketthuc, object id_doituong)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("RptWare_Muahang_Congno_Tra", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", ngay_Batdau));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@ngay_Ketthuc", ngay_Ketthuc));
             oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_doituong", id_doituong));
         

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Trả về một dataset Phieu_Chi
        /// </summary>
        /// <returns></returns>
        public string Get_RptWare_Muahang_Congno_Chuatra(object id_Khachhang)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("RptWare_Muahang_Congno_Chuatra", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", id_Khachhang));


            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }


        /// <summary>
        /// Insert đối tượng Ware_Phieuchi_Congno vào DB.
        /// </summary>
        /// <param name="Ware_Phieuchi_Congno"></param>
        /// <returns></returns>
        public object Insert_Ware_Phieuchi_Congno(Ecm.Domain.Ware.Ware_Phieuchi_Congno Ware_Phieuchi_Congno)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieuchi_Congno_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Phieuchi_Congno", Ware_Phieuchi_Congno.Id_Phieuchi_Congno));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu",                   Ware_Phieuchi_Congno.Ngay_Chungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu",                      Ware_Phieuchi_Congno.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Lydo",                           Ware_Phieuchi_Congno.Lydo));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Lapphieu",             Ware_Phieuchi_Congno.Id_Nhansu_Lapphieu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang",Ware_Phieuchi_Congno.Id_Khachhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nguoi_Nhan",                     Ware_Phieuchi_Congno.Nguoi_Nhan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien",                         Ware_Phieuchi_Congno.Sotien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Tiente",                      Ware_Phieuchi_Congno.Id_Tiente));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tygia",                          Ware_Phieuchi_Congno.Tygia));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Quydoi",                  Ware_Phieuchi_Congno.Sotien_Quydoi));
                
                oleDbCommand.Parameters["@Id_Phieuchi_Congno"].Direction = ParameterDirection.Output;
                oleDbCommand.ExecuteNonQuery();

                return oleDbCommand.Parameters["@Id_Phieuchi_Congno"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        /// <summary>
        /// Update đối tượng Ware_Phieuchi_Congno vào DB.
        /// </summary>
        /// <param name="Ware_Phieuchi_Congno"></param>
        /// <returns></returns>
        public object Update_Ware_Phieuchi_Congno(Ecm.Domain.Ware.Ware_Phieuchi_Congno Ware_Phieuchi_Congno)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieuchi_Congno_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Phieuchi_Congno", Ware_Phieuchi_Congno.Id_Phieuchi_Congno));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", Ware_Phieuchi_Congno.Ngay_Chungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", Ware_Phieuchi_Congno.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Lydo", Ware_Phieuchi_Congno.Lydo));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Lapphieu", Ware_Phieuchi_Congno.Id_Nhansu_Lapphieu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", Ware_Phieuchi_Congno.Id_Khachhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nguoi_Nhan", Ware_Phieuchi_Congno.Nguoi_Nhan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien", Ware_Phieuchi_Congno.Sotien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Tiente", Ware_Phieuchi_Congno.Id_Tiente));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tygia", Ware_Phieuchi_Congno.Tygia));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Quydoi", Ware_Phieuchi_Congno.Sotien_Quydoi));

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
        /// Delete đối tượng Ware_Phieuchi_Congno vào DB.
        /// </summary>
        /// <param name="Ware_Phieuchi_Congno"></param>
        /// <returns></returns>
        public object Delete_Ware_Phieuchi_Congno(Ecm.Domain.Ware.Ware_Phieuchi_Congno Ware_Phieuchi_Congno)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieuchi_Congno_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Phieuchi_Congno", Ware_Phieuchi_Congno.Id_Phieuchi_Congno));

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
        /// Update một Collection Ware_Phieuchi_Congno vào DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Ware_Phieuchi_Congno_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Phieuchi_Congno", _SqlConnection);
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

        #region Ware_Phieuchi_Congno_Chitiet
        public string Get_Ware_Phieuchi_Congno_Chuatra_ByDoituong(object Id_Khachhang)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieuchi_Congno_Chuatra_Select_ByDoituong", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add("@Id_Khachhang", Id_Khachhang);

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Get_Ware_Phieuchi_Congno_Chitiet_ByPCCongno(object Id_Phieuchi_Congno)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieuchi_Congno_Chitiet_Select_ByPCCongno", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add("@Id_Phieuchi_Congno", Id_Phieuchi_Congno);

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public object Insert_Ware_Phieuchi_Congno_Chitiet(Ecm.Domain.Ware.Ware_Phieuchi_Congno_Chititet Ware_Phieuchi_Congno_Chititet)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieuchi_Congno_Chitiet_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Phieuchi_Congno", Ware_Phieuchi_Congno_Chititet.Id_Phieuchi_Congno));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chungtu_Goc", Ware_Phieuchi_Congno_Chititet.Chungtu_Goc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien", Ware_Phieuchi_Congno_Chititet.Sotien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Thanhtoan", Ware_Phieuchi_Congno_Chititet.Sotien_Thanhtoan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_No", Ware_Phieuchi_Congno_Chititet.Sotien_No));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Thanhtoan_Trongky", Ware_Phieuchi_Congno_Chititet.Sotien_Thanhtoan_Trongky));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_No_Trongky", Ware_Phieuchi_Congno_Chititet.Sotien_No_Trongky));
                oleDbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            return true;
        }

        public object Delete_Ware_Phieuchi_Congno_Chitiet_ByPCCongno(object Id_Phieuchi_Congno)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieuchi_Congno_Chitiet_Delete_ByPCCongno", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Phieuchi_Congno", Id_Phieuchi_Congno));

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

        #endregion
    }
}
