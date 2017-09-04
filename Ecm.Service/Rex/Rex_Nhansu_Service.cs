using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Service.Rex
{
    public class Rex_Nhansu_Service
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        #region Method
        public Rex_Nhansu_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }
        #endregion

        #region implemetns IObService
        /// <summary>
        /// Trả về một dataset Rex_Nhansu
        /// </summary>
        /// <returns></returns>
        public string Get_All_Rex_Nhansu_Chuabotri()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_Select_Chuabotri", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Trả về một dataset Rex_Nhansu (không có bộ phận)
        /// </summary>
        /// <returns></returns>
        public string Get_All_Rex_Nhansu_None_Bophan()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_SelectAll_None_Bophan", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Trả về một dataset Rex_Nhansu (có Bộ phận)
        /// </summary>
        /// <returns></returns>
        public string Get_All_Rex_Nhansu_Collection()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Rex_Nhansu_SelectMail()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_SelectMail", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Get_Rex_Nhansu_ByBoPhan(object Id_Bophan)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_SelectByBP", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", Id_Bophan));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// load danh sach nhan su hop dong ( chua nghi viec)
        /// </summary>
        /// <param name="Id_Bophan"></param>
        /// <returns></returns>
        public string Get_Rex_NhansuNghiphep_ByBoPhan(object Id_Bophan)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_NhansuNghiphep_SelectByBP", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", Id_Bophan));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// load danh sach nhan su  ( có mã sản xuất)
        /// </summary>
        /// <param name="Id_Bophan"></param>
        /// <returns></returns>
        public string Get_Rex_Nhansu_Co_Ma_Sx(object Vitri1, object Vitri2)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_Select_Ma_Nhansu_Sx_NotNull", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Vitri1", Vitri1));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Vitri2", Vitri2));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Get_Rex_NhansuChamcomg_ByBoPhan(object id_Bophan, object nam_Kyluong, object thang_Kyluong, object ngay_BD, object ngay_KT)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_SelectchamcongByBP", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nam_Kyluong", nam_Kyluong));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thang_Kyluong", thang_Kyluong));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", id_Bophan));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_BD", ngay_BD));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_KT", ngay_KT));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public Ecm.Domain.Rex.Rex_Nhansu Get_Rex_Nhansu_ById(object Id_Nhansu)
        {
            Ecm.Domain.Rex.Rex_Nhansu objRex_Nhansu = new Ecm.Domain.Rex.Rex_Nhansu();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_SelectById", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Id_Nhansu));
            System.Data.OleDb.OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
            if (oleDbDataReader.Read())
            {
                objRex_Nhansu.Id_Nhansu = Id_Nhansu;
                objRex_Nhansu.Cmnd = "" + oleDbDataReader["Cmnd"];
                objRex_Nhansu.Diachi_Tamtru = "" + oleDbDataReader["Diachi_Tamtru"];
                objRex_Nhansu.Diachi_Thuongtru = "" + oleDbDataReader["Diachi_Thuongtru"];
                objRex_Nhansu.Dienthoai = "" + oleDbDataReader["Dienthoai"];
                objRex_Nhansu.Gioitinh = oleDbDataReader["Gioitinh"];
                objRex_Nhansu.Hinh = (oleDbDataReader["Hinh"] + "" == "") ? null : oleDbDataReader["Hinh"];
                objRex_Nhansu.Ho_Nhansu = "" + oleDbDataReader["Ho_Nhansu"];
                objRex_Nhansu.Id_Dantoc = "" + oleDbDataReader["Id_Dantoc"];
                objRex_Nhansu.Id_Honnhan = "" + oleDbDataReader["Id_Honnhan"];
                objRex_Nhansu.Id_Quocgia = "" + oleDbDataReader["Id_Quocgia"];
                objRex_Nhansu.Id_Tongiao = "" + oleDbDataReader["Id_Tongiao"];
                objRex_Nhansu.Id_Tpbanthan = "" + oleDbDataReader["Id_Tpbanthan"];
                objRex_Nhansu.Id_Tpgiadinh = "" + oleDbDataReader["Id_Tpgiadinh"];
                objRex_Nhansu.Id_Vanhoa = "" + oleDbDataReader["Id_Vanhoa"];
                objRex_Nhansu.Id_Ngoaingu = "" + oleDbDataReader["Id_Ngoaingu"];
                objRex_Nhansu.Id_Tinhoc = "" + oleDbDataReader["Id_Tinhoc"];
                objRex_Nhansu.Id_Chuyenmon = "" + oleDbDataReader["Id_Chuyenmon"];
                objRex_Nhansu.Ma_Nhansu = "" + oleDbDataReader["Ma_Nhansu"];
                objRex_Nhansu.Ngay_Thoiviec = "" + oleDbDataReader["Ngay_Thoiviec"];
                objRex_Nhansu.Ngay_Vaolam = "" + oleDbDataReader["Ngay_Vaolam"];
                objRex_Nhansu.Ngaycap = "" + oleDbDataReader["Ngaycap"];
                //objRex_Nhansu.Ngaysinh = "" + oleDbDataReader["Ngaysinh"];
                objRex_Nhansu.Ngay_Sinh = "" + oleDbDataReader["Ngay_Sinh"];
                objRex_Nhansu.Thangsinh = "" + oleDbDataReader["Thangsinh"];
                objRex_Nhansu.Namsinh = "" + oleDbDataReader["Namsinh"];
                objRex_Nhansu.Noicap = "" + oleDbDataReader["Noicap"];
                objRex_Nhansu.Noisinh = "" + oleDbDataReader["Noisinh"];
                objRex_Nhansu.Quequan = "" + oleDbDataReader["Quequan"];
                objRex_Nhansu.Ten_Nhansu = "" + oleDbDataReader["Ten_Nhansu"];

                objRex_Nhansu.Hochieu = "" + oleDbDataReader["Hochieu"];
                objRex_Nhansu.Ngaycap_Hochieu = "" + oleDbDataReader["Ngaycap_Hochieu"];
                objRex_Nhansu.Noicap_Hochieu = "" + oleDbDataReader["Noicap_Hochieu"];
                objRex_Nhansu.Ngay_Vaodoan = "" + oleDbDataReader["Ngay_Vaodoan"];
                objRex_Nhansu.Noi_Vaodoan = "" + oleDbDataReader["Noi_Vaodoan"];
                objRex_Nhansu.Ngay_Vaodang = "" + oleDbDataReader["Ngay_Vaodang"];
                objRex_Nhansu.Noi_Vaodang = "" + oleDbDataReader["Noi_Vaodang"];
                objRex_Nhansu.Thamgia_Quandoi = ("" + oleDbDataReader["Thamgia_Quandoi"] == "") ? false : oleDbDataReader["Thamgia_Quandoi"];
                objRex_Nhansu.Khuyet_Tat = ("" + oleDbDataReader["Khuyet_Tat"] == "") ? false : oleDbDataReader["Khuyet_Tat"];
                objRex_Nhansu.Hokhau_Thuongtru = "" + oleDbDataReader["Hokhau_Thuongtru"];
                objRex_Nhansu.Dienthoai_Nharieng = "" + oleDbDataReader["Dienthoai_Nharieng"];
                objRex_Nhansu.Fax = "" + oleDbDataReader["Fax"];
                objRex_Nhansu.Email = "" + oleDbDataReader["Email"];
                objRex_Nhansu.Ngay_Tuyendung = "" + oleDbDataReader["Ngay_Tuyendung"];
                objRex_Nhansu.Id_Hopdong_Laodong = "" + oleDbDataReader["Id_Hopdong_Laodong"];
                objRex_Nhansu.Id_Loai_Hopdong = "" + oleDbDataReader["Id_Loai_Hopdong"];
                objRex_Nhansu.Id_Bophan = "" + oleDbDataReader["Id_Bophan"];
                objRex_Nhansu.Id_Chucvu = "" + oleDbDataReader["Id_Chucvu"];
                objRex_Nhansu.Nghi_Bhxh = ("" + oleDbDataReader["Nghi_Bhxh"] == "") ? false : oleDbDataReader["Nghi_Bhxh"];


                objRex_Nhansu.Tenkhac = "" + oleDbDataReader["Tenkhac"];
                //objRex_Nhansu.TT_Suckhoe = "" + oleDbDataReader["TT_Suckhoe"];
                objRex_Nhansu.Chieucao = "" + oleDbDataReader["Chieucao"];
                objRex_Nhansu.Cannang = "" + oleDbDataReader["Cannang"];
                objRex_Nhansu.Nhommau = "" + oleDbDataReader["Nhommau"];
                objRex_Nhansu.Thuongbinh_Hang = "" + oleDbDataReader["Thuongbinh_Hang"];
                objRex_Nhansu.Con_Chinh_Sach = "" + oleDbDataReader["Con_Chinh_Sach"];
                objRex_Nhansu.Ngayvaodang_Chinhthuc = "" + oleDbDataReader["Ngayvaodang_Chinhthuc"];
                objRex_Nhansu.Ngay_Nhapngu = "" + oleDbDataReader["Ngay_Nhapngu"];
                objRex_Nhansu.Ngay_Xuatngu = "" + oleDbDataReader["Ngay_Xuatngu"];
                objRex_Nhansu.Quan_Ham = "" + oleDbDataReader["Quan_Ham"];
                objRex_Nhansu.Danhhieu_Caonhat = "" + oleDbDataReader["Danhhieu_Caonhat"];
                objRex_Nhansu.Lyluan_Chinhtri = "" + oleDbDataReader["Lyluan_Chinhtri"];
                objRex_Nhansu.Quanly_Nhanuoc = "" + oleDbDataReader["Quanly_Nhanuoc"];
                objRex_Nhansu.Bibat_Bitu = "" + oleDbDataReader["Bibat_Bitu"];
                objRex_Nhansu.Thamgia_Chinhtri = "" + oleDbDataReader["Thamgia_Chinhtri"];
                objRex_Nhansu.Thannhan_Nuocngoai = "" + oleDbDataReader["Thannhan_Nuocngoai"];
                objRex_Nhansu.Nghenghiep_Tuyendung = "" + oleDbDataReader["Nghenghiep_Tuyendung"];
                objRex_Nhansu.Coquan_Tuyendung = "" + oleDbDataReader["Coquan_Tuyendung"];
                objRex_Nhansu.Congviec_Chinh = "" + oleDbDataReader["Congviec_Chinh"];
                objRex_Nhansu.Sotruong_Ct = "" + oleDbDataReader["Sotruong_Ct"];
                objRex_Nhansu.So_Sobhxh = "" + oleDbDataReader["So_Sobhxh"];
                objRex_Nhansu.Id_Loai_Nhanvien = "" + oleDbDataReader["Id_Loai_Nhanvien"];

                objRex_Nhansu.Ngaycap_Bhxh = "" + oleDbDataReader["Ngaycap_Bhxh"];
                objRex_Nhansu.Noicap_Bhxh = "" + oleDbDataReader["Noicap_Bhxh"];
                objRex_Nhansu.So_Sobhyt = "" + oleDbDataReader["So_Sobhyt"];
                objRex_Nhansu.Ngaycap_Bhyt = "" + oleDbDataReader["Ngaycap_Bhyt"];
                objRex_Nhansu.Noicap_Bhyt = "" + oleDbDataReader["Noicap_Bhyt"];
                objRex_Nhansu.So_Sobhtn = "" + oleDbDataReader["So_Sobhtn"];
                objRex_Nhansu.Ngaycap_Bhtn = "" + oleDbDataReader["Ngaycap_Bhtn"];
                objRex_Nhansu.Noicap_Bhtn = "" + oleDbDataReader["Noicap_Bhtn"];
                objRex_Nhansu.Tuoihuu = "" + oleDbDataReader["Tuoihuu"];
            }

            return objRex_Nhansu;
        }

        public Ecm.Domain.Rex.Rex_Nhansu Rex_Nhansu_SelectMail_Nhansu_KTVP()
        {
            Ecm.Domain.Rex.Rex_Nhansu objRex_Nhansu = new Ecm.Domain.Rex.Rex_Nhansu();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_SelectMail_Nhansu_KTVP", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            System.Data.OleDb.OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
            if (oleDbDataReader.Read())
            {
                objRex_Nhansu.Id_Nhansu = oleDbDataReader["Id_Nhansu"];
                objRex_Nhansu.Dienthoai = "" + oleDbDataReader["Dienthoai"];
                objRex_Nhansu.Ho_Nhansu = "" + oleDbDataReader["Ho_Nhansu"];
                objRex_Nhansu.Ten_Nhansu = "" + oleDbDataReader["Ma_Nhansu"];
                objRex_Nhansu.Email = "" + oleDbDataReader["Email"];
            }
            return objRex_Nhansu;
        }

        public string DsRex_Nhansu_SelectMail_Nhansu_KTVP()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_SelectMail_Nhansu_KTVP", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Rex_Nhansu_SelectEmail_ByChungtu(object Sochungtu)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_SelectEmail_ByChungtu", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sochungtu", Sochungtu));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Rex_Nhansu_SelectMail_Nhansu_KTVP_Mobile()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_SelectMail_Nhansu_KTVP", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);
        }

        public string Get_DsRex_Nhansu_ById(object Id_Nhansu)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_SelectById", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Id_Nhansu));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Insert đối tượng Rex_Nhansu vào DB.
        /// </summary>
        /// <param name="Rex_Nhansu"></param>
        /// <returns></returns>
        public object Insert_Rex_Nhansu(Ecm.Domain.Rex.Rex_Nhansu Rex_Nhansu)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Cmnd", Rex_Nhansu.Cmnd));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Diachi_Tamtru", Rex_Nhansu.Diachi_Tamtru));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Diachi_Thuongtru", Rex_Nhansu.Diachi_Thuongtru));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dienthoai", Rex_Nhansu.Dienthoai));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Gioitinh", Rex_Nhansu.Gioitinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Hinh", Rex_Nhansu.Hinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ho_Nhansu", Rex_Nhansu.Ho_Nhansu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Dantoc", Rex_Nhansu.Id_Dantoc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Honnhan", Rex_Nhansu.Id_Honnhan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Quocgia", Rex_Nhansu.Id_Quocgia));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Tongiao", Rex_Nhansu.Id_Tongiao));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Tpbanthan", Rex_Nhansu.Id_Tpbanthan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Vanhoa", Rex_Nhansu.Id_Vanhoa));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Chuyenmon", Rex_Nhansu.Id_Chuyenmon));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Tpgiadinh", Rex_Nhansu.Id_Tpgiadinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Nhansu", Rex_Nhansu.Ma_Nhansu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Thoiviec", Rex_Nhansu.Ngay_Thoiviec));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Vaolam", Rex_Nhansu.Ngay_Vaolam));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngaycap", Rex_Nhansu.Ngaycap));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Sinh", Rex_Nhansu.Ngay_Sinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thangsinh", Rex_Nhansu.Thangsinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Namsinh", Rex_Nhansu.Namsinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Noicap", Rex_Nhansu.Noicap));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Noisinh", Rex_Nhansu.Noisinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Quequan", Rex_Nhansu.Quequan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Nhansu", Rex_Nhansu.Ten_Nhansu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nganhang", Rex_Nhansu.Id_Nganhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Taikhoan_Nganhang", Rex_Nhansu.Taikhoan_Nganhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Hochieu", Rex_Nhansu.Hochieu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngaycap_Hochieu", Rex_Nhansu.Ngaycap_Hochieu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Noicap_Hochieu", Rex_Nhansu.Noicap_Hochieu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dienthoai_Nharieng", Rex_Nhansu.Dienthoai_Nharieng));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Email", Rex_Nhansu.Email));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Vaodang", Rex_Nhansu.Ngay_Vaodang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Vaodoan", Rex_Nhansu.Ngay_Vaodoan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Vaocongdoan", Rex_Nhansu.Ngay_Vaocongdoan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Truongnhom", Rex_Nhansu.Truongnhom));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", Rex_Nhansu.Id_Bophan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Taixe", Rex_Nhansu.Taixe));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sale", Rex_Nhansu.Sale));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", System.Data.OleDb.OleDbType.BigInt, 18, "Id_Nhansu"));
                oleDbCommand.Parameters["@Id_Nhansu"].Direction = ParameterDirection.Output;

                oleDbCommand.ExecuteNonQuery();
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Rex_Nhansu", DateTime.Now);
                }
                return oleDbCommand.Parameters["@Id_Nhansu"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }


        /// <summary>
        /// Update đối tượng Rex_Nhansu vào DB.
        /// </summary>
        /// <param name="Rex_Nhansu"></param>
        /// <returns></returns>
        public object Update_Rex_Nhansu(Ecm.Domain.Rex.Rex_Nhansu Rex_Nhansu)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Rex_Nhansu.Id_Nhansu));

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Cmnd", Rex_Nhansu.Cmnd));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Diachi_Tamtru", Rex_Nhansu.Diachi_Tamtru));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Diachi_Thuongtru", Rex_Nhansu.Diachi_Thuongtru));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dienthoai", Rex_Nhansu.Dienthoai));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Gioitinh", Rex_Nhansu.Gioitinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Hinh", Rex_Nhansu.Hinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ho_Nhansu", Rex_Nhansu.Ho_Nhansu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Dantoc", Rex_Nhansu.Id_Dantoc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Honnhan", Rex_Nhansu.Id_Honnhan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Quocgia", Rex_Nhansu.Id_Quocgia));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Tongiao", Rex_Nhansu.Id_Tongiao));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Tpbanthan", Rex_Nhansu.Id_Tpbanthan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Vanhoa", Rex_Nhansu.Id_Vanhoa));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Chuyenmon", Rex_Nhansu.Id_Chuyenmon));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Tpgiadinh", Rex_Nhansu.Id_Tpgiadinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Nhansu", Rex_Nhansu.Ma_Nhansu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Thoiviec", Rex_Nhansu.Ngay_Thoiviec));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Vaolam", Rex_Nhansu.Ngay_Vaolam));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngaycap", Rex_Nhansu.Ngaycap));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Sinh", Rex_Nhansu.Ngay_Sinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thangsinh", Rex_Nhansu.Thangsinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Namsinh", Rex_Nhansu.Namsinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Noicap", Rex_Nhansu.Noicap));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Noisinh", Rex_Nhansu.Noisinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Quequan", Rex_Nhansu.Quequan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Nhansu", Rex_Nhansu.Ten_Nhansu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nganhang", Rex_Nhansu.Id_Nganhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Taikhoan_Nganhang", Rex_Nhansu.Taikhoan_Nganhang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Hochieu", Rex_Nhansu.Hochieu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngaycap_Hochieu", Rex_Nhansu.Ngaycap_Hochieu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Noicap_Hochieu", Rex_Nhansu.Noicap_Hochieu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dienthoai_Nharieng", Rex_Nhansu.Dienthoai_Nharieng));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Email", Rex_Nhansu.Email));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Vaodang", Rex_Nhansu.Ngay_Vaodang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Vaodoan", Rex_Nhansu.Ngay_Vaodoan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Vaocongdoan", Rex_Nhansu.Ngay_Vaocongdoan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", Rex_Nhansu.Id_Bophan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Truongnhom", Rex_Nhansu.Truongnhom));
                oleDbCommand.ExecuteNonQuery();
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Rex_Nhansu", DateTime.Now);
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
        /// Update đối tượng Rex_NhansuInfo vào DB.
        /// </summary>
        /// <param name="Rex_Nhansu"></param>
        /// <returns></returns>
        public object Update_Rex_NhansuInfo(Ecm.Domain.Rex.Rex_Nhansu Rex_Nhansu)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_NhansuInfo_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Rex_Nhansu.Id_Nhansu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Cmnd", Rex_Nhansu.Cmnd));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Diachi_Tamtru", Rex_Nhansu.Diachi_Tamtru));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Diachi_Thuongtru", Rex_Nhansu.Diachi_Thuongtru));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dienthoai", Rex_Nhansu.Dienthoai));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Gioitinh", Rex_Nhansu.Gioitinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Hinh", Rex_Nhansu.Hinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ho_Nhansu", Rex_Nhansu.Ho_Nhansu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Dantoc", Rex_Nhansu.Id_Dantoc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Honnhan", Rex_Nhansu.Id_Honnhan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Quocgia", Rex_Nhansu.Id_Quocgia));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Tongiao", Rex_Nhansu.Id_Tongiao));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Tpbanthan", Rex_Nhansu.Id_Tpbanthan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Tpgiadinh", Rex_Nhansu.Id_Tpgiadinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Vanhoa", Rex_Nhansu.Id_Vanhoa));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Ngoaingu", Rex_Nhansu.Id_Ngoaingu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Tinhoc", Rex_Nhansu.Id_Tinhoc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Chuyenmon", Rex_Nhansu.Id_Chuyenmon));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Nhansu", Rex_Nhansu.Ma_Nhansu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Thoiviec", Rex_Nhansu.Ngay_Thoiviec));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Vaolam", Rex_Nhansu.Ngay_Vaolam));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngaycap", Rex_Nhansu.Ngaycap));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_sinh", Rex_Nhansu.Ngay_Sinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thangsinh", Rex_Nhansu.Thangsinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Namsinh", Rex_Nhansu.Namsinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Noicap", Rex_Nhansu.Noicap));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Noisinh", Rex_Nhansu.Noisinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Quequan", Rex_Nhansu.Quequan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Nhansu", Rex_Nhansu.Ten_Nhansu));

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Hochieu", Rex_Nhansu.Hochieu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngaycap_Hochieu", Rex_Nhansu.Ngaycap_Hochieu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Noicap_Hochieu", Rex_Nhansu.Noicap_Hochieu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Vaodoan", Rex_Nhansu.Ngay_Vaodoan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Noi_Vaodoan", Rex_Nhansu.Noi_Vaodoan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Vaodang", Rex_Nhansu.Ngay_Vaodang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Noi_Vaodang", Rex_Nhansu.Noi_Vaodang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thamgia_Quandoi", Rex_Nhansu.Thamgia_Quandoi));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Khuyet_Tat", Rex_Nhansu.Khuyet_Tat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Hokhau_Thuongtru", Rex_Nhansu.Hokhau_Thuongtru));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dienthoai_Nharieng", Rex_Nhansu.Dienthoai_Nharieng));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Fax", Rex_Nhansu.Fax));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Email", Rex_Nhansu.Email));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Tuyendung", Rex_Nhansu.Ngay_Tuyendung));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hopdong_Laodong", Rex_Nhansu.Id_Hopdong_Laodong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Loai_Hopdong", Rex_Nhansu.Id_Loai_Hopdong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", Rex_Nhansu.Id_Bophan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Chucvu", Rex_Nhansu.Id_Chucvu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nghi_Bhxh", Rex_Nhansu.Nghi_Bhxh));


                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tenkhac", Rex_Nhansu.Tenkhac));
                //oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@TT_Suckhoe",Rex_Nhansu.TT_Suckhoe));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Chieucao", Rex_Nhansu.Chieucao));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Cannang", Rex_Nhansu.Cannang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nhommau", Rex_Nhansu.Nhommau));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thuongbinh_Hang", Rex_Nhansu.Thuongbinh_Hang));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Con_Chinh_Sach", Rex_Nhansu.Con_Chinh_Sach));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngayvaodang_Chinhthuc", Rex_Nhansu.Ngayvaodang_Chinhthuc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Nhapngu", Rex_Nhansu.Ngay_Nhapngu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Xuatngu", Rex_Nhansu.Ngay_Xuatngu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Quan_Ham", Rex_Nhansu.Quan_Ham));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Danhhieu_Caonhat", Rex_Nhansu.Danhhieu_Caonhat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Lyluan_Chinhtri", Rex_Nhansu.Lyluan_Chinhtri));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Quanly_Nhanuoc", Rex_Nhansu.Quanly_Nhanuoc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Bibat_Bitu", Rex_Nhansu.Bibat_Bitu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thamgia_Chinhtri", Rex_Nhansu.Thamgia_Chinhtri));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thannhan_Nuocngoai", Rex_Nhansu.Thannhan_Nuocngoai));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nghenghiep_Tuyendung", Rex_Nhansu.Nghenghiep_Tuyendung));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Coquan_Tuyendung", Rex_Nhansu.Coquan_Tuyendung));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Loai_Nhanvien", Rex_Nhansu.Id_Loai_Nhanvien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Congviec_Chinh", Rex_Nhansu.Congviec_Chinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotruong_Ct", Rex_Nhansu.Sotruong_Ct));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@So_Sobhxh", Rex_Nhansu.So_Sobhxh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngaycap_Bhxh", Rex_Nhansu.Ngaycap_Bhxh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Noicap_Bhxh", Rex_Nhansu.Noicap_Bhxh));

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@So_Sobhyt", Rex_Nhansu.So_Sobhyt));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngaycap_Bhyt", Rex_Nhansu.Ngaycap_Bhyt));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Noicap_Bhyt", Rex_Nhansu.Noicap_Bhyt));

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@So_Sobhtn", Rex_Nhansu.So_Sobhtn));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngaycap_Bhtn", Rex_Nhansu.Ngaycap_Bhtn));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Noicap_Bhtn", Rex_Nhansu.Noicap_Bhtn));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tuoihuu", Rex_Nhansu.Tuoihuu));
                oleDbCommand.ExecuteNonQuery();
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Rex_Nhansu", DateTime.Now);
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
        /// Delete đối tượng Rex_Nhansu vào DB.
        /// </summary>
        /// <param name="Rex_Nhansu"></param>
        /// <returns></returns>
        public object Delete_Rex_Nhansu(Ecm.Domain.Rex.Rex_Nhansu Rex_Nhansu)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_Delete", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Rex_Nhansu.Id_Nhansu));

                oleDbCommand.ExecuteNonQuery();
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Rex_Nhansu", DateTime.Now);
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
        /// Update một Collection Rex_Nhansu vào DB.
        /// </summary>
        /// <param name="dsCollection"></param>
        /// <returns></returns>
        public object Update_Rex_Nhansu_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select id_nhansu,Finger_Userid from Rex_Nhansu", _SqlConnection);
                System.Data.OleDb.OleDbCommandBuilder oleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(oleDbDataAdapter);
                oleDbDataAdapter = oleDbCommandBuilder.DataAdapter;

                oleDbDataAdapter.Update(dsCollection, "GridTable");
                //notify last change in data
                using (Sys.Sys_Service _Sys_Service = new Ecm.Service.Sys.Sys_Service(this._SqlConnection))
                {
                    _Sys_Service.Update_Sys_Lognotify("Rex_Nhansu", DateTime.Now);
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
        /// Insert Rex_Botri_Nhansu
        /// </summary>
        /// <param name="Rex_Botri_Nhansu"></param>
        /// <returns></returns>
        public object Insert_Rex_Botri_Nhansu(Domain.Rex.Rex_Botri_Nhansu Rex_Botri_Nhansu)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Botri_Nhansu_Insert", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Rex_Botri_Nhansu.Id_Nhansu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", Rex_Botri_Nhansu.Id_Bophan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Quyetdinh", Rex_Botri_Nhansu.Id_Quyetdinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Chucvu", Rex_Botri_Nhansu.Id_Chucvu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", Rex_Botri_Nhansu.Ngay_Batdau));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", Rex_Botri_Nhansu.Ngay_Ketthuc));

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
        /// Insert Rex_Botri_Nhansu
        /// </summary>
        /// <param name="Rex_Botri_Nhansu"></param>
        /// <returns></returns>
        public object Update_Rex_Botri_Nhansu(Domain.Rex.Rex_Botri_Nhansu Rex_Botri_Nhansu)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Botri_Nhansu_Update", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Botri_Nhansu", Rex_Botri_Nhansu.Id_Botri_Nhansu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Rex_Botri_Nhansu.Id_Nhansu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", Rex_Botri_Nhansu.Id_Bophan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Quyetdinh", Rex_Botri_Nhansu.Id_Quyetdinh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Chucvu", Rex_Botri_Nhansu.Id_Chucvu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", Rex_Botri_Nhansu.Ngay_Batdau));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", Rex_Botri_Nhansu.Ngay_Ketthuc));

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
        /// Lay thong tin nhan vien de in the
        /// </summary>
        /// <param name="Rex_Nhansu"></param>
        /// <returns>Dataset</returns>
        public string Get_NhansuInfo_Inthe(Domain.Rex.Rex_Nhansu Rex_Nhansu)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_Select_Inthe", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Rex_Nhansu.Id_Nhansu));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Lay thong tin nhan vien de in ly lich
        /// </summary>
        /// <param name="Rex_Nhansu"></param>
        /// <returns>Dataset</returns>
        /// 
        public string Get_NhansuInfo_In_Hoso(Domain.Rex.Rex_Nhansu Rex_Nhansu)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_Select_In_Hoso", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Rex_Nhansu.Id_Nhansu));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "rex_nhansu");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Lay thong tin qua trinh cong tac cua nhan vien de in ly lich
        /// </summary>
        /// <param name="Id_Nhansu"></param>
        /// <returns>Dataset</returns>
        /// 
        public string Get_Quatrinh_Congtac_In_Hoso_Nhansu(object Id_Nhansu)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Quatrinh_Congtac_Select_In_Hoso_Nhansu", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Id_Nhansu));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "rex_nhansu");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Lay thong tin quan he gia dinh cua nhan vien de in ly lich
        /// </summary>
        /// <param name="Id_Nhansu"></param>
        /// <returns>Dataset</returns>
        /// 
        public string Get_Quanhe_Giadinh_In_Hoso_Nhansu(object Id_Nhansu)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Quanhe_Giadinh_Select_In_Hoso", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Id_Nhansu));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "rex_nhansu");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Lay thong tin qua trinh cong tac cua nhan vien de in ly lich
        /// </summary>
        /// <param name="Rex_Nhansu"></param>
        /// <returns>Dataset</returns>
        /// 
        public string Get_Quatrinh_Daotao_In_Hoso_Nhansu(object Id_Nhansu)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Quatrinh_Daotao_Select_In_Hoso", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Id_Nhansu));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "rex_nhansu");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }
        /// <summary>
        /// Lay thong tin qua trinh cong tac cua nhan vien de in ly lich
        /// </summary>
        /// <param name="Rex_Nhansu"></param>
        /// <returns>Dataset</returns>
        /// 
        public string Get_Dienbien_Luong_In_Hoso_Nhansu(object Id_Nhansu)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Dienbien_Luong_Select_In_Hoso", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Id_Nhansu));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "rex_nhansu");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }
        /// <summary>
        /// Lay danh sach nhan vien thuoc bo phan de in ly lich trich ngang
        /// </summary>
        /// <param name="Id_Bophan"></param>
        /// <returns>Dataset</returns>
        /// 
        public string Get_Danhsach_Nhansu_In_Lylich_Trichngang(object Id_Bophan)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_Select_In_Lylich_Trichngang", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", Id_Bophan));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "rex_nhansu");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ngay_Batdau"></param>
        /// <param name="ngay_Ketthuc"></param>
        /// <param name="id_Bophan"></param>
        /// <returns></returns>
        public string Get_Danhsach_Nhansu_Thuviec(object ngay_Batdau, object ngay_Ketthuc, object id_Bophan)
        {
            if (id_Bophan == null) throw new ArgumentNullException("id_Bophan");
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_Select_Thuviec", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", ngay_Batdau));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", ngay_Ketthuc));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", id_Bophan));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "rex_nhansu");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ngay_Batdau"></param>
        /// <param name="ngay_Ketthuc"></param>
        /// <param name="id_Bophan"></param>
        /// <returns></returns>
        public string Get_Danhsach_Nhansu_Dentuoihuu(object ngay_Batdau, object ngay_Ketthuc, object id_Bophan)
        {
            if (id_Bophan == null) throw new ArgumentNullException("id_Bophan");
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_Select_Dentuoihuu", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", ngay_Batdau));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", ngay_Ketthuc));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", id_Bophan));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "rex_nhansu");
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
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_Select_HethanHD", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Batdau", ngay_Batdau));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ngay_Ketthuc", ngay_Ketthuc));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", id_Bophan));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "rex_nhansu");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public object Get_Nhansu_Trangthai_Hopdong(object Id_Nhansu)
        {
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_Trangthai_Hopdong", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Id_Nhansu));
            return oleDbCommand.ExecuteScalar();
        }

        public object Rex_Nhansu_Cohopdong(object Id_Nhansu)
        {
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_Cohopdong", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Id_Nhansu));
            return oleDbCommand.ExecuteScalar();
        }
        /// <summary>
        /// search nhan su
        /// </summary>
        /// <returns></returns>
        public string Get_Search_Rex_Nhansu(Ecm.Domain.Rex.Rex_Nhansu Rex_Nhansu)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_Search", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Nhansu", Rex_Nhansu.Ma_Nhansu));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ho_Nhansu", Rex_Nhansu.Ho_Nhansu));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ten_Nhansu", Rex_Nhansu.Ten_Nhansu));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dienthoai", Rex_Nhansu.Dienthoai));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Cmnd", Rex_Nhansu.Cmnd));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Diachi_Thuongtru", Rex_Nhansu.Diachi_Thuongtru));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Diachi_Tamtru", Rex_Nhansu.Diachi_Tamtru));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Hochieu", Rex_Nhansu.Hochieu));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dienthoai_Nharieng", Rex_Nhansu.Dienthoai_Nharieng));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Fax", Rex_Nhansu.Fax));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Email", Rex_Nhansu.Email));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tenkhac", Rex_Nhansu.Tenkhac));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "rex_nhansu");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id_Bophan"></param>
        /// <returns></returns>
        public string Get_NhansuInfo_In_Hoso_ByBophan(object Id_Bophan)
        {

            if (Id_Bophan == null) throw new ArgumentNullException("id_Bophan");
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_Select_In_Hoso_ByBophan", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", Id_Bophan));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "rex_nhansu");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 

        }

        public string Get_Dienbien_Luong_In_Hoso_ByBophan(object Id_Bophan)
        {

            if (Id_Bophan == null) throw new ArgumentNullException("id_Bophan");
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Dienbien_Luong_Select_In_Hoso_ByBophan", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", Id_Bophan));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "rex_nhansu");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 

        }

        public string Get_Quatrinh_Daotao_In_Hoso_ByBophan(object Id_Bophan)
        {

            if (Id_Bophan == null) throw new ArgumentNullException("id_Bophan");
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Quatrinh_Daotao_Select_In_Hoso_ByBophan", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", Id_Bophan));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "rex_nhansu");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 

        }

        public string Get_Quatrinh_Congtac_In_Hoso_ByBophan(object Id_Bophan)
        {

            if (Id_Bophan == null) throw new ArgumentNullException("id_Bophan");
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Quatrinh_Congtac_Select_In_Hoso_ByBophan", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", Id_Bophan));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "rex_nhansu");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 

        }

        public string Get_Quanhe_Giadinh_In_Hoso_ByBophan(object Id_Bophan)
        {

            if (Id_Bophan == null) throw new ArgumentNullException("id_Bophan");
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Quanhe_Giadinh_Select_In_Hoso_ByBophan", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", Id_Bophan));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "rex_nhansu");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 

        }

        public string Get_Phucap_In_Hoso_ByBophan(object Id_Bophan)
        {

            if (Id_Bophan == null) throw new ArgumentNullException("id_Bophan");
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Phucap_Select_In_Hoso_ByBophan", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", Id_Bophan));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "rex_nhansu");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 

        }



        public string Rex_Nhansu_Get_DM_Phucap(object id_chucvu)
        {

            if (id_chucvu == null) throw new ArgumentNullException("id_chucvu");
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_Get_Phucap_By_Chucvu", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Chucvu", id_chucvu));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "rex_nhansu");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Rex_Nhansu_Get_Phucap(object id_nhansu)
        {

            if (id_nhansu == null) throw new ArgumentNullException("id_nhansu");
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Phucap_Select_In_Hoso_ByBophan", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", id_nhansu));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "rex_nhansu");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// cap nhat tai khoan ngan hang
        /// </summary>
        /// <param name="Rex_Nhansu">para: ma nhan su</param>
        /// <returns></returns>
        public object Update_Rex_Nhansu_Taikhoan_Nganhang(Ecm.Domain.Rex.Rex_Nhansu Rex_Nhansu)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_Update_Taikhoan_Nganhang", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Taikhoan_Nganhang", Rex_Nhansu.Taikhoan_Nganhang));
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
        /// Update Mã số sản xuất vào đối trượng Rex_Nhansu.
        /// </summary>
        /// <param name="Rex_Nhansu"></param>
        /// <returns></returns>
        public object Update_Rex_Nhansu_Ma_Sx(Ecm.Domain.Rex.Rex_Nhansu Rex_Nhansu)
        {

            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_Update_Ma_Nhansu_Sx", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Nhansu_Sx", Rex_Nhansu.Ma_Nhansu_Sx));
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
        /// Reset Mã số sản xuất vào đối trượng Rex_Nhansu.
        /// </summary>
        /// <param name="Rex_Nhansu"></param>
        /// <returns></returns>
        public object Update_Rex_Nhansu_Ma_Sx_To_Null(Ecm.Domain.Rex.Rex_Nhansu Rex_Nhansu)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_Reset_Ma_Nhansu_Sx", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Ma_Nhansu_Sx", Rex_Nhansu.Ma_Nhansu_Sx));
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

        #region Thống kê Nhân sự

        /// <summary>
        /// Get về danh sách Nhân sự thống kê theo kỹ năng
        /// -- Author:		<Author, nhanvuong>
        ///-- Create date: <Create Date, 08/11/2010>
        /// </summary>
        /// <param name="Id_Kynang_Chuyenmon"></param>
        /// <returns>Dataset</returns>
        public string Rex_Nhansu_ThongKe_By_KynangChuyenmon(object Thoigian_Batdau, object Thoigian_Kethuc)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_Thongke_KyNang", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thoigian_Batdau", Thoigian_Batdau));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thoigian_Ketthuc", Thoigian_Kethuc));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "Rex_Nhansu");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Get về danh sách Nhân sự với các tham số truyền vào (có thể rỗng) để thống kê nhân sự
        /// -- Author:		<Author, nhanvuong>
        ///-- Create date: <Create Date, 26/08/2010>
        /// </summary>
        /// <param name="Dotuoi_From"></param>
        /// <param name="Dotuoi_To"></param>
        /// <param name="Gioitinh"></param>
        /// <param name="Id_Vanhoa"></param>
        /// <param name="Id_Chuyenmon"></param>
        /// <param name="Id_Dantoc"></param>
        /// <param name="Id_Tongiao"></param>
        /// <param name="Id_Tpgiadinh"></param>
        /// <param name="Id_Kynang_Chuyenmon"></param>
        /// <returns>Dataset</returns>
        public string Rex_Nhansu_ThongKe(object Thoigian_Batdau, object Thoigian_Kethuc, object Dotuoi_From, object Dotuoi_To, object Gioitinh,
                                object Id_Vanhoa, object Id_Chuyenmon, object Id_Dantoc, object Id_Tongiao, object Id_Tpgiadinh, object Id_Kynang, object Value)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_Thongke_Return_Dataset", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thoigian_Batdau", Thoigian_Batdau));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thoigian_Ketthuc", Thoigian_Kethuc));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dotuoi_From", Dotuoi_From));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Dotuoi_To", Dotuoi_To));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Gioitinh", Gioitinh));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Vanhoa", Id_Vanhoa));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Chuyenmon", Id_Chuyenmon));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Dantoc", Id_Dantoc));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Tongiao", Id_Tongiao));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Tpgiadinh", Id_Tpgiadinh));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kynang", Id_Kynang));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Value", Value));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "Rex_Nhansu");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Get về danh sách Nhân sự thống kê chi tiết, tham số là thời gian bắt đầu và kết thúc
        /// -- Author:		<Author, nhanvuong>
        ///-- Create date: <Create Date, 01/09/2010>
        /// </summary>
        /// <param name="Thoigian_Batdau"></param>
        /// <param name="Thoigian_Kethuc"></param>
        /// <returns>Dataset</returns>
        public string Rex_Nhansu_ThongKe_Chitiet(object Thoigian_Batdau, object Thoigian_Kethuc)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_Thongke_Chitiet", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thoigian_Batdau", Thoigian_Batdau));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thoigian_Ketthuc", Thoigian_Kethuc));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "Rex_Nhansu");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Get vể danh sách Nhân sự thống kê chi tiết by Loại Hợp đồng
        /// -- Author:		<Author, nhanvuong>
        ///-- Create date: <Create Date, 11/09/2010>
        /// </summary>
        /// <param name="Thoigian_Batdau"></param>
        /// <param name="Thoigian_Ketthuc"></param>
        /// <param name="Id_Bophan"></param>
        /// <param name="Id_Loai_Hopdong"></param>
        /// <returns></returns>
        public string Rex_Nhansu_Thongke_By_LoaiHD(object Thoigian_Batdau, object Thoigian_Ketthuc, object Id_Bophan, object Id_Loai_Hopdong)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_Thongke_By_LoaiHD", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thoigian_Batdau", Thoigian_Batdau));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thoigian_Ketthuc", Thoigian_Ketthuc));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", Id_Bophan));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Loai_Hopdong", Id_Loai_Hopdong));
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "Rex_Nhansu");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        #endregion

        #region Finger links
        /// <summary>
        /// get all Finger_Userinfo
        /// </summary>
        /// <returns></returns>
        public string Get_All_Finger_Userinfo()
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Finger_Userinfo_SelectAll", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Author: deonguyen - Date: 25/08/2010
        /// Kiểm tra tình trạng nghỉ việc của nhân sự
        /// </summary>
        /// <param name="Id_Nhansu">object Id_Nhansu</param>
        /// <returns>Trả về DataSet thông tin nghỉ việc của nhân sự</returns>
        public string Get_Rex_Nhansu_Tamhoan(object Id_Nhansu)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_Tamhoan", this._SqlConnection);
            oleDbCommand.Parameters.Add("@Id_Nhansu", Id_Nhansu);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        /// <summary>
        /// Author: deonguyen - Date: 25/08/2010
        /// Kiểm tra tình trạng tạm hoãn hợp đồng của nhân sự
        /// </summary>
        /// <param name="Id_Nhansu">object Id_Nhansu</param>
        /// <returns>Trả về DataSet thông tin tạm hoãn hợp đồng của nhân sự</returns>
        public string Get_Rex_Nhansu_Nghiviec(object Id_Nhansu)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Nhansu_Nghiviec", this._SqlConnection);
            oleDbCommand.Parameters.Add("@Id_Nhansu", Id_Nhansu);
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        #endregion
    }
}
