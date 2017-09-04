using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Ware
{
    public class DocumentProcessStatus_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public DocumentProcessStatus_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService
        /// <summary>
        /// Trả về một dataset Congnothu_Dauky
        /// </summary>
        /// <returns></returns>
        public Domain.Ware.DocumentProcessStatus Get_DocumentProcessStatus(Domain.Ware.DocumentProcessStatus DocumentProcessStatus)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("DocumentProcessStatus_Select", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@TableName", DocumentProcessStatus.Tablename));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@PK_Name", DocumentProcessStatus.PK_Name));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Identity", DocumentProcessStatus.Identity));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter();
            oleDbDataAdapter.SelectCommand = oleDbCommand;
            oleDbDataAdapter.Fill(dsCollection, "GridTable");

            Domain.Ware.DocumentProcessStatus rDocumentProcessStatus = new Ecm.Domain.Ware.DocumentProcessStatus();
            rDocumentProcessStatus.Tablename = DocumentProcessStatus.Tablename;
            rDocumentProcessStatus.PK_Name = DocumentProcessStatus.PK_Name;
            rDocumentProcessStatus.Identity = DocumentProcessStatus.Identity;
            rDocumentProcessStatus.Doc_Process_Status = dsCollection.Tables[0].Rows[0]["Doc_Process_Status"];
            rDocumentProcessStatus.Ghichu_Verify = ""+dsCollection.Tables[0].Rows[0]["Ghichu_Verify"];
            rDocumentProcessStatus.Ghichu_Test = ""+dsCollection.Tables[0].Rows[0]["Ghichu_Test"];
            rDocumentProcessStatus.Id_Nhansu_Test = ""+dsCollection.Tables[0].Rows[0]["Id_Nhansu_Test"];
            rDocumentProcessStatus.Id_Nhansu_Verify = ""+dsCollection.Tables[0].Rows[0]["Id_Nhansu_Verify"];

            return rDocumentProcessStatus;
        }

        public string Get_DocumentProcessStatus(object Tablename, object PK_Name, object Identity)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("DocumentProcessStatus_Select", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@TableName", Tablename));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@PK_Name", PK_Name));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Identity", Identity));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter();
            oleDbDataAdapter.SelectCommand = oleDbCommand;
            oleDbDataAdapter.Fill(dsCollection, "GridTable");

            //Domain.Ware.DocumentProcessStatus rDocumentProcessStatus = new Ecm.Domain.Ware.DocumentProcessStatus();
            //rDocumentProcessStatus.Tablename = DocumentProcessStatus.Tablename;
            //rDocumentProcessStatus.PK_Name = DocumentProcessStatus.PK_Name;
            //rDocumentProcessStatus.Identity = DocumentProcessStatus.Identity;
            //rDocumentProcessStatus.Doc_Process_Status = dsCollection.Tables[0].Rows[0]["Doc_Process_Status"];
            //rDocumentProcessStatus.Ghichu_Verify = "" + dsCollection.Tables[0].Rows[0]["Ghichu_Verify"];
            //rDocumentProcessStatus.Ghichu_Test = "" + dsCollection.Tables[0].Rows[0]["Ghichu_Test"];
            //rDocumentProcessStatus.Id_Nhansu_Test = "" + dsCollection.Tables[0].Rows[0]["Id_Nhansu_Test"];
            //rDocumentProcessStatus.Id_Nhansu_Verify = "" + dsCollection.Tables[0].Rows[0]["Id_Nhansu_Verify"];

                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Update đối tượng DocumentProcessStatus vào DB.
        /// </summary>
        /// <param name="DocumentProcessStatus"></param>
        /// <returns></returns>
        public object Update_DocumentProcessStatus(Ecm.Domain.Ware.DocumentProcessStatus DocumentProcessStatus)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("DocumentProcessStatus_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tablename", DocumentProcessStatus.Tablename));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@PK_Name", DocumentProcessStatus.PK_Name));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Identity", DocumentProcessStatus.Identity));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Doc_Process_Status", DocumentProcessStatus.Doc_Process_Status));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Test", DocumentProcessStatus.Id_Nhansu_Test));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu_Test", DocumentProcessStatus.Ghichu_Test));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Verify", DocumentProcessStatus.Id_Nhansu_Verify));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu_Verify", DocumentProcessStatus.Ghichu_Verify));

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
        /// Tra ve so chung tu tu tang theo thu tu
        /// </summary>
        /// <param name="Table_Name"></param>
        /// <param name="Column_Name"></param>
        /// <param name="Prefix"></param>
        /// <returns></returns>
        public object GetNew_Sochungtu(object Table_Name, object Column_Name, object Prefix)
        {
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Document_Getnew_Sochungtu", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Table_Name", Table_Name));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Column_Name", Column_Name));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Prefix", Prefix));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Result", System.Data.OleDb.OleDbType.VarWChar, 200));

            oleDbCommand.Parameters["@Result"].Direction = ParameterDirection.Output;
            
            oleDbCommand.ExecuteNonQuery();

            return oleDbCommand.Parameters["@Result"].Value;
        }

        /// <summary>
        /// tra ve so hoa don ban le 
        /// (no vat)
        /// </summary>
        /// <param name="Ma_Kho_HH"></param>
        /// <returns></returns>
        public object Getnew_Sohoadon_NoVAT(object Ma_Kho_HH)
        {
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Document_Getnew_Sohoadon_NoVAT", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Kho_Hh", Ma_Kho_HH));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Result", System.Data.OleDb.OleDbType.VarWChar, 200));
            oleDbCommand.Parameters["@Result"].Direction = ParameterDirection.Output;
            oleDbCommand.ExecuteNonQuery();
            return oleDbCommand.Parameters["@Result"].Value;
        }

        public object Getnew_Sohoadon_VAT(object Ma_Kho_HH)
        {
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Document_Getnew_Sohoadon_VAT", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Kho_Hh", Ma_Kho_HH));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Result", System.Data.OleDb.OleDbType.VarWChar, 200));
            oleDbCommand.Parameters["@Result"].Direction = ParameterDirection.Output;
            oleDbCommand.ExecuteNonQuery();
            return oleDbCommand.Parameters["@Result"].Value;
        }

        /// <summary>
        /// tra ve so hoa don xuat kho ban hang -- nhanvuong
        /// 12/10/2010
        /// </summary>
        /// <param name="Ma_Kho_HH"></param>
        /// <returns></returns>
        public object Getnew_Sohoadon_XuatkhoBh(object Ma_Kho_HH)
        {
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Document_Getnew_Sohoadon_XuatkhoBh", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Kho_Hh", Ma_Kho_HH));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Result", System.Data.OleDb.OleDbType.VarWChar, 200));

            oleDbCommand.Parameters["@Result"].Direction = ParameterDirection.Output;

            oleDbCommand.ExecuteNonQuery();

            return oleDbCommand.Parameters["@Result"].Value;
        }

        /// <summary>
        /// Trả về số record của 1 master table đã được sử dụng.
        /// </summary>
        /// <param name="table_name"></param>
        /// <param name="column_name"></param>
        /// <param name="lookup_value"></param>
        /// <returns>numeric</returns>
        public object GetExistReferences(object table_name, object column_name, object lookup_value)
        {
            
            
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Document_GetExistReferences", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@table_name", table_name));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@column_name", column_name));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@lookup_value", lookup_value));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@result", System.Data.OleDb.OleDbType.Numeric));

                oleDbCommand.Parameters["@result"].Direction = ParameterDirection.Output;
                oleDbCommand.ExecuteNonQuery();

                return oleDbCommand.Parameters["@Result"].Value;
           

        }
        #endregion
    }
}
