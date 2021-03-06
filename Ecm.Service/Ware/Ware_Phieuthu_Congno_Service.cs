using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Ware
{
    public class Ware_Phieuthu_Congno_Service
    {
         #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Ware_Phieuthu_Congno_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService
        /// <summary>
        /// Trả về một dataset Phieu_thu
        /// </summary>
        /// <returns></returns>
        public string Get_All_Ware_Phieuthu_Congno()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieuthu_Congno_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Ware_Congno_Khachhang( object ma_khachhang)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Congno_Khachhang", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add("@Ma_khachhang", ma_khachhang);

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }


        public string Get_RptWare_Banhang_Congno_Thu(object ngay_Batdau, object ngay_Ketthuc, object id_Doituong)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("rptWare_Banhang_Congno_Thu", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add("@Ngay_Batdau", ngay_Batdau);
            oleDbCommand.Parameters.Add("@Ngay_Ketthuc", ngay_Ketthuc);
            oleDbCommand.Parameters.Add("@Id_Doituong", id_Doituong);

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }


        public string Get_RptWare_Banhang_Congno_Chuathu(object id_khachhang)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("rptWare_Banhang_Congno_Chuathu", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add("@Id_khachhang", id_khachhang);

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }


        /// <summary>
        /// Insert đối tượng Ware_Phieuthu_Congno vào DB.
        /// </summary>
        /// <param name="Ware_Phieuthu_Congno"></param>
        /// <returns></returns>
        public object Insert_Ware_Phieuthu_Congno(Ecm.Domain.Ware.Ware_Phieuthu_Congno Ware_Phieuthu_Congno)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieuthu_Congno_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Phieuthu_Congno", Ware_Phieuthu_Congno.Id_Phieuthu_Congno));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu",                   Ware_Phieuthu_Congno.Ngay_Chungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu",                      Ware_Phieuthu_Congno.Sochungtu));
                //oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chungtu_Goc",                    Ware_Phieuthu_Congno.Chungtu_Goc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Lydo",                           Ware_Phieuthu_Congno.Lydo));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Lapphieu",             Ware_Phieuthu_Congno.Id_Nhansu_Lapphieu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang",                   Ware_Phieuthu_Congno.Id_Khachhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Khachhang",                  Ware_Phieuthu_Congno.Ten_Khachhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nguoi_Nop",                      Ware_Phieuthu_Congno.Nguoi_Nop));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien",                         Ware_Phieuthu_Congno.Sotien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Tiente",                      Ware_Phieuthu_Congno.Id_Tiente));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tygia",                          Ware_Phieuthu_Congno.Tygia));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Quydoi",                  Ware_Phieuthu_Congno.Sotien_Quydoi));
                
                oleDbCommand.Parameters["@Id_Phieuthu_Congno"].Direction = ParameterDirection.Output;
                oleDbCommand.ExecuteNonQuery();

                return oleDbCommand.Parameters["@Id_Phieuthu_Congno"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        /// <summary>
        /// Update đối tượng Ware_Phieuthu_Congno vào DB.
        /// </summary>
        /// <param name="Ware_Phieuthu_Congno"></param>
        /// <returns></returns>
        public object Update_Ware_Phieuthu_Congno(Ecm.Domain.Ware.Ware_Phieuthu_Congno Ware_Phieuthu_Congno)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieuthu_Congno_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Phieuthu_Congno", Ware_Phieuthu_Congno.Id_Phieuthu_Congno));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", Ware_Phieuthu_Congno.Ngay_Chungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", Ware_Phieuthu_Congno.Sochungtu));
                //oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chungtu_Goc", Ware_Phieuthu_Congno.Chungtu_Goc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Lydo", Ware_Phieuthu_Congno.Lydo));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Lapphieu", Ware_Phieuthu_Congno.Id_Nhansu_Lapphieu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", Ware_Phieuthu_Congno.Id_Khachhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Khachhang", Ware_Phieuthu_Congno.Ten_Khachhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nguoi_Nop", Ware_Phieuthu_Congno.Nguoi_Nop));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien", Ware_Phieuthu_Congno.Sotien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Tiente", Ware_Phieuthu_Congno.Id_Tiente));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tygia", Ware_Phieuthu_Congno.Tygia));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Quydoi", Ware_Phieuthu_Congno.Sotien_Quydoi));
              
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
        /// Delete đối tượng Ware_Phieuthu_Congno vào DB.
        /// </summary>
        /// <param name="Ware_Phieuthu_Congno"></param>
        /// <returns></returns>
        public object Delete_Ware_Phieuthu_Congno(Ecm.Domain.Ware.Ware_Phieuthu_Congno Ware_Phieuthu_Congno)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieuthu_Congno_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Phieuthu_Congno", Ware_Phieuthu_Congno.Id_Phieuthu_Congno));

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
        /// Update một Collection Ware_Phieuthu_Congno vào DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Ware_Phieuthu_Congno_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Phieuthu_Congno", _SqlConnection);
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

        #region Ware_Phieuthu_Congno_chitiet
        public string Ware_Phieuthu_Congno_chitiet_Init()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieuthu_Congno_chitiet_Select_ByInit", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Get_Ware_Phieuthu_Congno_chitiet_ByPCCongno(object Id_Phieuthu_Congno)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieuthu_Congno_chitiet_Select_ByPCCongno", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add("@Id_Phieuthu_Congno", Id_Phieuthu_Congno);

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public object Insert_Ware_Phieuthu_Congno_chitiet(Ecm.Domain.Ware.Ware_Phieuthu_Congno_Chitiet Ware_Phieuthu_Congno_Chitiet)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieuthu_Congno_chitiet_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Phieuthu_Congno", Ware_Phieuthu_Congno_Chitiet.Id_Phieuthu_Congno));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chungtu_Goc", Ware_Phieuthu_Congno_Chitiet.Chungtu_Goc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien", Ware_Phieuthu_Congno_Chitiet.Sotien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Thanhtoan", Ware_Phieuthu_Congno_Chitiet.Sotien_Thanhtoan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_No", Ware_Phieuthu_Congno_Chitiet.Sotien_No));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Thanhtoan_Trongky", Ware_Phieuthu_Congno_Chitiet.Sotien_Thanhtoan_Trongky));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_No_Trongky", Ware_Phieuthu_Congno_Chitiet.Sotien_No_Trongky));
                oleDbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            return true;
        }

        public object Delete_Ware_Phieuthu_Congno_chitiet(object Id_Phieuthu_Congno)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Phieuthu_Congno_Chitiet_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Phieuthu_Congno", Id_Phieuthu_Congno));

                oleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object Update_Ware_Phieuthu_Congno_chitiet_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Phieuthu_Congno_chitiet", _SqlConnection);
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

        #endregion
    }
}
