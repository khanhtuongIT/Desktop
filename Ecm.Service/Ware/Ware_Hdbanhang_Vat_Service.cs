using System;
using System.Data;
using System.Collections.Generic;

namespace Ecm.Service.Ware
{
    public class Ware_Hdbanhang_Vat_Service
    {
        private System.Data.OleDb.OleDbConnection _SqlConnection;

        public Ware_Hdbanhang_Vat_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            _SqlConnection = sqlConnection;
        }

        public bool Ware_Hdbanhang_Vat_Check_Ngayxuat(object Ngay_Xuat)
        {
            //var dsCollection ;
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Vat_Check_Ngayxuat", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Xuat", Ngay_Xuat));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@valid", System.Data.OleDb.OleDbType.Boolean));
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters["@valid"].Direction = ParameterDirection.Output;
            oleDbCommand.ExecuteNonQuery();
            var valid = false;
            bool.TryParse(string.Empty + oleDbCommand.Parameters["@valid"].Value, out valid);
            return valid;
        }

        public string Ware_Hdbanhang_Vat_SelectByCuahang(object Id_Cuahang_Ban)
        {
            var dsCollection = new DataSet();
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Vat_SelectByCuahang", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Ware_Hdbanhang_Vat_SelectAll()
        {
            var dsCollection = new DataSet();
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Vat_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Ware_Hdbanhang_Vat_SelectAll_Hhban(object Id_Cuahang_Ban, object Ngay_Chungtu, object Id_Nhansu_Lap, object Id_Khachhang)
        {
            var dsCollection = new DataSet();
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_vat_SelectAll_Hhban", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", Id_Cuahang_Ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", Ngay_Chungtu));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Lap", Id_Nhansu_Lap));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachhang", Id_Khachhang));
            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Ware_Hdbanhang_Vat_SelectBy_Id_Hdbanhang(object Id_Hdbanhang)
        {
            var dsCollection = new DataSet();
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Vat_SelectBy_Id_Hdbanhang", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hdbanhang", Id_Hdbanhang));

            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Ware_Hdbanhang_Vat_SelectByDate(object ngay_Bd, object ngay_Kt, object id_cuahang_ban)
        {
            var dsCollection = new DataSet();
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Vat_SelectByDate", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Bd", ngay_Bd));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Kt", ngay_Kt));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_cuahang_ban", id_cuahang_ban));

            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public object Insert_Ware_Hdbanhang_Vat(Ecm.Domain.Ware.Ware_Hdbanhang_Vat ware_Hdbanhang_vat)
        {
            try
            {
                var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Vat_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hdbanhang", ware_Hdbanhang_vat.Id_Hdbanhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", ware_Hdbanhang_vat.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", ware_Hdbanhang_vat.Ngay_Chungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Thanhtoan", ware_Hdbanhang_vat.Ngay_Thanhtoan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachang", ware_Hdbanhang_vat.Id_Khachang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Diachi", ware_Hdbanhang_vat.Diachi));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Maso_Thue", ware_Hdbanhang_vat.Maso_Thue));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Hoten_Nguoimua", ware_Hdbanhang_vat.Hoten_Nguoimua));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dienthoai", ware_Hdbanhang_vat.Dienthoai));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Bh", ware_Hdbanhang_vat.Id_Nhansu_Bh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", ware_Hdbanhang_vat.Id_Cuahang_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", ware_Hdbanhang_vat.Ghichu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien", ware_Hdbanhang_vat.Sotien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Per_Vat", ware_Hdbanhang_vat.Per_Vat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Vat", ware_Hdbanhang_vat.Sotien_Vat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Phuongthuc_Thanhtoan", ware_Hdbanhang_vat.Phuongthuc_Thanhtoan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@So_Seri", ware_Hdbanhang_vat.So_Seri));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@NoVAT", ware_Hdbanhang_vat.NoVAT));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Per_Hoadon", ware_Hdbanhang_vat.Per_Hoadon));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tienmat", ware_Hdbanhang_vat.Tienmat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Xuat", ware_Hdbanhang_vat.Ngay_Xuat));
                oleDbCommand.Parameters["@Id_Hdbanhang"].Direction = ParameterDirection.Output;
                oleDbCommand.ExecuteNonQuery();
                return oleDbCommand.Parameters["@Id_Hdbanhang"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Update_Ware_Hdbanhang_Vat(Ecm.Domain.Ware.Ware_Hdbanhang_Vat ware_Hdbanhang_vat)
        {
            try
            {
                var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Vat_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hdbanhang", ware_Hdbanhang_vat.Id_Hdbanhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", ware_Hdbanhang_vat.Sochungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Chungtu", ware_Hdbanhang_vat.Ngay_Chungtu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Thanhtoan", ware_Hdbanhang_vat.Ngay_Thanhtoan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Khachang", ware_Hdbanhang_vat.Id_Khachang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Diachi", ware_Hdbanhang_vat.Diachi));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Maso_Thue", ware_Hdbanhang_vat.Maso_Thue));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Hoten_Nguoimua", ware_Hdbanhang_vat.Hoten_Nguoimua));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dienthoai", ware_Hdbanhang_vat.Dienthoai));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Bh", ware_Hdbanhang_vat.Id_Nhansu_Bh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Cuahang_Ban", ware_Hdbanhang_vat.Id_Cuahang_Ban));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu", ware_Hdbanhang_vat.Ghichu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien", ware_Hdbanhang_vat.Sotien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Per_Vat", ware_Hdbanhang_vat.Per_Vat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Vat", ware_Hdbanhang_vat.Sotien_Vat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Phuongthuc_Thanhtoan", ware_Hdbanhang_vat.Phuongthuc_Thanhtoan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@So_Seri", ware_Hdbanhang_vat.So_Seri));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@NoVAT", ware_Hdbanhang_vat.NoVAT));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Per_Hoadon", ware_Hdbanhang_vat.Per_Hoadon));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu_Edit", ware_Hdbanhang_vat.Id_Nhansu_Edit));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ghichu_Edit", ware_Hdbanhang_vat.Ghichu_Edit));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Donvi_Muahang", ware_Hdbanhang_vat.Donvi_muahang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Doc_Process_Status", ware_Hdbanhang_vat.Doc_Process_Status));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tienmat", ware_Hdbanhang_vat.Tienmat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Congno", ware_Hdbanhang_vat.Congno));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tinh_Dinhluong", ware_Hdbanhang_vat.Tinh_Dinhluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tinh_Chiphi", ware_Hdbanhang_vat.Tinh_Chiphi));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chiphi_Vanchuyen", ware_Hdbanhang_vat.Chiphi_Vanchuyen));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Congno", ware_Hdbanhang_vat.Sotien_Congno));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Xuat", ware_Hdbanhang_vat.Ngay_Xuat));
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Delete_Ware_Hdbanhang_Vat(Ecm.Domain.Ware.Ware_Hdbanhang_Vat ware_Hdbanhang_vat)
        {
            try
            {
                var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Vat_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hdbanhang", ware_Hdbanhang_vat.Id_Hdbanhang));

                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Update_Ware_Hdbanhang_Vat_Collection(DataSet dsCollection)
        {
            try
            {
                var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Hdbanhang_Vat", _SqlConnection);
                var oleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(oleDbDataAdapter);
                oleDbDataAdapter = oleDbCommandBuilder.DataAdapter;
                oleDbDataAdapter.Update(dsCollection, "GridTable");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update một Collection Ware_Hdbanhang_Chitiet vào DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Ware_Hdbanhang_Chitiet_Vat_Collection(DataSet dsCollection)
        {
            try
            {
                var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Ware_Hdbanhang_Chitiet_Vat", _SqlConnection);
                var oleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(oleDbDataAdapter);
                oleDbDataAdapter = oleDbCommandBuilder.DataAdapter;
                oleDbDataAdapter.Update(dsCollection, "GridTable");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Ware_Hdbanhang_Chitiet_Vat_SelectById_Hdbanhang_Vat(object Id_Hdbanhang)
        {
            var dsCollection = new DataSet();
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("Ware_Hdbanhang_Chitiet_Vat_SelectById_Hdbanhang_Vat", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hdbanhang", Id_Hdbanhang));
            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string ware_Hdbanhang_Chitiet_CheckSL(object Id_Hanghoa_ban, object Id_Donvitinh, object Id_Hdbanhang_Chitiet_Vat)
        {
            var dsCollection = new DataSet();
            var oleDbCommand = new System.Data.OleDb.OleDbCommand("ware_Hdbanhang_Chitiet_CheckSL", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hanghoa_ban", Id_Hanghoa_ban));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Donvitinh", Id_Donvitinh));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hdbanhang_Chitiet_Vat", Id_Hdbanhang_Chitiet_Vat));
            var oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

    }
}
