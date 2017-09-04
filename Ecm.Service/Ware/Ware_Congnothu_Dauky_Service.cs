using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Ware
{
    public class Ware_Congnothu_Dauky_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Ware_Congnothu_Dauky_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService
        /// <summary>
        /// Trả về một dataset Congnothu_Dauky
        /// </summary>
        /// <returns></returns>
        /// 
        private Ecm.Domain.Ware.Ware_Congnothu_Dauky Get_Ware_Congnothu_Dauky(DataRow row)
        {
            Ecm.Domain.Ware.Ware_Congnothu_Dauky _Ware_Congnothu_Dauky = new Ecm.Domain.Ware.Ware_Congnothu_Dauky();
            if ("" + row["Id_Congnothu_Dauky"] != "")
                _Ware_Congnothu_Dauky.Id_Congnothu_Dauky = row["Id_Congnothu_Dauky"];
            if ("" + row["Id_Khachhang"] != "")
                _Ware_Congnothu_Dauky.Id_Khachhang = row["Id_Khachhang"];
            if ("" + row["Sotien_No"] != "")
                _Ware_Congnothu_Dauky.Sotien_No = row["Sotien_No"];
            if ("" + row["Ghichu"] != "")
                _Ware_Congnothu_Dauky.Ghichu = row["Ghichu"];
            if ("" + row["Chungtu_goc"] != "")
                _Ware_Congnothu_Dauky.Chungtu_goc = row["Chungtu_goc"];
            if ("" + row["Id_tiente"] != "")
                _Ware_Congnothu_Dauky.Id_tiente = row["Id_tiente"];
            if ("" + row["Ngay_chungtu"] != "")
                _Ware_Congnothu_Dauky.Ngay_chungtu = row["Ngay_chungtu"];
            if ("" + row["Sotien_quydoi"] != "")
                _Ware_Congnothu_Dauky.Sotien_quydoi = row["Sotien_quydoi"];
            if ("" + row["Tygia"] != "")
                _Ware_Congnothu_Dauky.Tygia = row["Tygia"];
            if ("" + row["Sotien_Co"] != "")
                _Ware_Congnothu_Dauky.Sotien_Co = row["Sotien_Co"];
            if ("" + row["Id_Ncc"] != "")
                _Ware_Congnothu_Dauky.Id_Ncc = row["Id_Ncc"];
            if ("" + row["Ma_Doituong"] != "")
                _Ware_Congnothu_Dauky.Ma_Doituong = row["Ma_Doituong"];            
            return _Ware_Congnothu_Dauky;
        }

        public string Get_All_Ware_Congnothu_Dauky()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Congnothu_Dauky_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Insert đối tượng Ware_Congnothu_Dauky vào DB.
        /// </summary>
        /// <param name="ware_Congnothu_Dauky"></param>
        /// <returns></returns>
        public object Insert_Ware_Congnothu_Dauky(Ecm.Domain.Ware.Ware_Congnothu_Dauky ware_Congnothu_Dauky)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Congnothu_Dauky_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", ware_Congnothu_Dauky.Id_Khachhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_No", ware_Congnothu_Dauky.Sotien_No));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Co", ware_Congnothu_Dauky.Sotien_Co));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", ware_Congnothu_Dauky.Ghichu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chungtu_goc", ware_Congnothu_Dauky.Chungtu_goc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_chungtu", ware_Congnothu_Dauky.Ngay_chungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_quydoi", ware_Congnothu_Dauky.Sotien_quydoi));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_tiente", ware_Congnothu_Dauky.Id_tiente));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tygia", ware_Congnothu_Dauky.Tygia));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Ncc", ware_Congnothu_Dauky.Id_Ncc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Doituong", ware_Congnothu_Dauky.Ma_Doituong));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update đối tượng Ware_Congnothu_Dauky vào DB.
        /// </summary>
        /// <param name="ware_Congnothu_Dauky"></param>
        /// <returns></returns>
        public object Update_Ware_Congnothu_Dauky(Ecm.Domain.Ware.Ware_Congnothu_Dauky ware_Congnothu_Dauky)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Congnothu_Dauky_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Congnothu_Dauky", ware_Congnothu_Dauky.Id_Congnothu_Dauky));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", ware_Congnothu_Dauky.Id_Khachhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_No", ware_Congnothu_Dauky.Sotien_No));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Co", ware_Congnothu_Dauky.Sotien_Co));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", ware_Congnothu_Dauky.Ghichu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chungtu_goc", ware_Congnothu_Dauky.Chungtu_goc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_chungtu", ware_Congnothu_Dauky.Ngay_chungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_quydoi", ware_Congnothu_Dauky.Sotien_quydoi));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_tiente", ware_Congnothu_Dauky.Id_tiente));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tygia", ware_Congnothu_Dauky.Tygia));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Ncc", ware_Congnothu_Dauky.Id_Ncc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Doituong", ware_Congnothu_Dauky.Ma_Doituong));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete đối tượng Ware_Congnothu_Dauky vào DB.
        /// </summary>
        /// <param name="ware_Congnothu_Dauky"></param>
        /// <returns></returns>
        public object Delete_Ware_Congnothu_Dauky(Ecm.Domain.Ware.Ware_Congnothu_Dauky ware_Congnothu_Dauky)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Congnothu_Dauky_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Congnothu_Dauky", ware_Congnothu_Dauky.Id_Congnothu_Dauky));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update một Collection Ware_Congnothu_Dauky vào DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Ware_Congnothu_Dauky_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Congnothu_Dauky", _SqlConnection);
                System.Data.OleDb.OleDbCommandBuilder oleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(oleDbDataAdapter);
                oleDbDataAdapter = oleDbCommandBuilder.DataAdapter;
                oleDbDataAdapter.Update(dsCollection, "GridTable");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Update_Ware_Congnothu_Dauky_Collection2(DataSet dsCollection)
        {
            try
            {
                DataSet dsI = dsCollection.GetChanges(DataRowState.Added);
                DataSet dsU = dsCollection.GetChanges(DataRowState.Modified);
                DataSet dsD = dsCollection.GetChanges(DataRowState.Deleted);

                if (dsI != null)
                    foreach (DataRow dr in dsI.Tables[0].Rows)
                        this.Insert_Ware_Congnothu_Dauky(this.Get_Ware_Congnothu_Dauky(dr));
                if (dsU != null)
                    foreach (DataRow dr in dsU.Tables[0].Rows)
                        this.Update_Ware_Congnothu_Dauky(this.Get_Ware_Congnothu_Dauky(dr));
                if (dsD != null)
                {
                    dsD.RejectChanges();
                    foreach (DataRow dr in dsD.Tables[0].Rows)
                        this.Delete_Ware_Congnothu_Dauky(this.Get_Ware_Congnothu_Dauky(dr));
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
