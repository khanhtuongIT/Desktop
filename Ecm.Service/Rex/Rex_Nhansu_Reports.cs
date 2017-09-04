using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Rex
{
    public class Rex_Nhansu_Reports
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        public Rex_Nhansu_Reports(System.Data.OleDb.OleDbConnection sqlMaper)
        {
            this._SqlConnection = sqlMaper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id_Bophan"></param>
        /// <param name="Ngay_Baocao"></param>
        /// <param name="Inc_Bophan_Tructhuoc"></param>
        /// <param name="Inc_Nhanvien_Thoiviec"></param>
        /// <returns></returns>
        public string Get_Danhsach_Nhansu_In_Lylich_Trichngang(object Id_Bophan, object Ngay_Baocao, object Inc_Bophan_Tructhuoc, object Inc_Nhanvien_Thoiviec)
        {
            //#Id_Bophan#,#Ngay_Baocao#,#Inc_Bophan_Tructhuoc#,#Inc_Nhanvien_Thoiviec#
            var htpara = new System.Collections.Hashtable();
            htpara.Add("Id_Bophan", Id_Bophan);
            htpara.Add("Ngay_Baocao", Ngay_Baocao);
            htpara.Add("Inc_Bophan_Tructhuoc", Inc_Bophan_Tructhuoc);
            htpara.Add("Inc_Nhanvien_Thoiviec", Inc_Nhanvien_Thoiviec);

            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_Select_In_Lylich_Trichngang", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id_Bophan"></param>
        /// <param name="Ngay_Baocao"></param>
        /// <param name="Inc_Bophan_Tructhuoc"></param>
        /// <param name="Inc_Nhanvien_Thoiviec"></param>
        /// <returns></returns>
        public string Get_Rex_Nhansu_Tgia_Bhxh(object Id_Bophan, object Ngay_Baocao, object Inc_Bophan_Tructhuoc, object Inc_Nhanvien_Thoiviec)
        {

            //#Id_Bophan#,#Ngay_Baocao#,#Inc_Bophan_Tructhuoc#,#Inc_Nhanvien_Thoiviec#
            var htpara = new System.Collections.Hashtable();
            htpara.Add("Id_Bophan", Id_Bophan);
            htpara.Add("Ngay_Baocao", Ngay_Baocao);
            htpara.Add("Inc_Bophan_Tructhuoc", Inc_Bophan_Tructhuoc);
            htpara.Add("Inc_Nhanvien_Thoiviec", Inc_Nhanvien_Thoiviec);

            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_Select_Tgia_Bhxh", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ngay_Batdau"></param>
        /// <param name="ngay_Ketthuc"></param>
        /// <param name="id_Bophan"></param>
        /// <returns></returns>
        public string Get_Danhsach_Nhansu_hethanHD(object ngay_Batdau, object ngay_Ketthuc, object id_Bophan)
        {
            if (id_Bophan == null) throw new ArgumentNullException("id_Bophan");
            System.Collections.Hashtable htparas = new System.Collections.Hashtable();
            htparas.Add("Ngay_Batdau", ngay_Batdau);
            htparas.Add("Ngay_Ketthuc", ngay_Ketthuc);
            htparas.Add("Id_Bophan", id_Bophan);
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_Select_HethanHD", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }


        /// <summary>
        /// 111219
        /// THONG KE NHAN SU THEO CAC CHI TIEU
        /// </summary>
        /// <param name="Chitieu"></param>
        /// <param name="Ngay_Baocao"></param>
        /// <param name="Inc_Nghiviec"></param>
        /// <returns></returns>
        public string Rex_Nhansu_Thongke_Chitieu(object Chitieu, object Ngay_Baocao, object Inc_Nghiviec)
        {
            Chitieu = null;
            var htpara = new System.Collections.Hashtable();
            htpara.Add("Chitieu", Chitieu);
            htpara.Add("Ngay_Baocao", Ngay_Baocao);
            htpara.Add("Inc_Nghiviec", Inc_Nghiviec);

            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_Thongke_Chitieu", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// 111219
        /// chi tiet ds nhan su theo tung chi tieu duoc chon
        /// </summary>
        /// <param name="Chitieu"></param>
        /// <param name="Ngay_Baocao"></param>
        /// <param name="Inc_Nghiviec"></param>
        /// <param name="Giatri"></param>
        /// <returns></returns>
        public string Rex_Nhansu_Thongke_Chitieu_Chitiet(object Chitieu, object Ngay_Baocao, object Inc_Nghiviec, object Giatri)
        {
            var htpara = new System.Collections.Hashtable();
            htpara.Add("Chitieu", Chitieu);
            htpara.Add("Ngay_Baocao", Ngay_Baocao);
            htpara.Add("Inc_Nghiviec", Inc_Nghiviec);
            htpara.Add("Giatri", Giatri);

            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_Thongke_Chitieu_Chitiet", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Rex_Nhansu_Thongke_Tinhhinh(object Ngay_Baocao, object Inc_Nghiviec)
        {
            var htpara = new System.Collections.Hashtable();
            htpara.Add("Ngay_Baocao", Ngay_Baocao);
            htpara.Add("Inc_Nghiviec", Inc_Nghiviec);

            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_Thongke_Tinhhinh", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// 111223-phuongphan-itvsbiz
        /// </summary>
        /// <param name="htpara"></param>
        /// <returns></returns>
        public string Rex_Thamgia_Tochuc_Thongke(object Id_Bophan, object Ngay_Baocao, object Id_Tochuc, object Inc_Nhanvien_Thoiviec)
        {
            
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Thamgia_Tochuc_Thongke", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Get_Rex_Luong_Tonghop_BHXH(object Nam_Kyluong, object Thang_Kyluong, object Id_Bophan, object Inc_Bophan_Tructhuoc)
        {

            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Luong_Tonghop_Select_BHXH", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Get_Rex_Luong_Tonghop_Kpcd(object Nam_Kyluong, object Thang_Kyluong, object Id_Bophan, object Inc_Bophan_Tructhuoc)
        {

            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Luong_Tonghop_Select_Kpcd", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Get_Rex_Luong_Tonghop_Tncn(object Nam_Kyluong, object Id_Bophan, object Inc_Bophan_Tructhuoc)
        {

            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Luong_Tonghop_Select_Tncn", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }



    }
}
