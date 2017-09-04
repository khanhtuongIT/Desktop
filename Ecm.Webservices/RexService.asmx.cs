#region edit
/*
 * edit     phuongphan
 * date     08/04/2011
 * content  new service Rex_Finger_Map_Service
 */
#endregion

using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;

using Ecm.Service;
using Ecm.Service.Rex;
using Ecm.Service.MasterTables.Rex;

namespace Ecm.Webservice
{
       /// <summary>
    /// Summary description for RexService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.Web.Script.Services.ScriptService]
    public class RexService : System.Web.Services.WebService
    {
        //Connection
        System.Data.OleDb.OleDbConnection sqlMapper = DbConnection.OleDbConnection;

        #region Khai báo các đối tượng service - rex

        Rex_Nhansu_Service _Rex_Nhansu_Service;
        Rex_Botri_Ca_Lamviec_Service _Rex_Botri_Ca_Lamviec_Service;
        Rex_Hopdong_Laodong_Service _Rex_Hopdong_Laodong_Service;
        Rex_Chamcong_Thang_Service _Rex_Chamcong_Thang_Service;
        Rex_Chamcong_Tangca_Service _Rex_Chamcong_Tangca_Service;
        //Rex_Luong_Thoigian_Service _Rex_Luong_Thoigian_Service;
        //Rex_Luong_Tonghop_Service _Rex_Luong_Tonghop_Service;
        //Rex_Xepca_Thang_Service _Rex_Xepca_Thang_Service;
        Rex_Botri_Nhansu_Service _Rex_Botri_Nhansu_Service;
        Rex_Hopdong_Laodong_Phuluc_Service _Rex_Hopdong_Laodong_Phuluc_Service;
        //Rex_Thamgia_Tochuc_Service _Rex_Thamgia_Tochuc_Service;
        Rex_Phucap_Service _Rex_Phucap_Service;
        //Rex_Dienbien_Luong_Service _Rex_Dienbien_Luong_Service;
        Rex_Quanhe_Giadinh_Service _Rex_Quanhe_Giadinh_Service;
        Rex_Khenthuong_Kyluat_Service _Rex_Khenthuong_Kyluat_Service;
        //Rex_Kynang_Service _Rex_Kynang_Service;
        Rex_Quatrinh_Congtac_Service _Rex_Quatrinh_Congtac_Service;
        Rex_Quatrinh_Daotao_Service _Rex_Quatrinh_Daotao_Service;
        //Rex_Kyluong_Service _Rex_Kyluong_Service;
        //Rex_Nghiphep_Service _Rex_Nghiphep_Service;
        Rex_Hopdong_Laodong_Info_Service _Rex_Hopdong_Laodong_Info_Service;
        
        #endregion

        public RexService()
        {
            #region Khởi tạo các đối tượng service - rex

            _Rex_Nhansu_Service = new Rex_Nhansu_Service(sqlMapper);
            _Rex_Botri_Ca_Lamviec_Service = new Rex_Botri_Ca_Lamviec_Service(sqlMapper);
            _Rex_Hopdong_Laodong_Service = new Rex_Hopdong_Laodong_Service(sqlMapper);
            //_Rex_Dienbien_Luong_Service = new Rex_Dienbien_Luong_Service(sqlMapper);
            _Rex_Chamcong_Thang_Service = new Rex_Chamcong_Thang_Service(sqlMapper);
            _Rex_Chamcong_Tangca_Service = new Rex_Chamcong_Tangca_Service(sqlMapper);
            //_Rex_Luong_Thoigian_Service = new Rex_Luong_Thoigian_Service(sqlMapper);
            //_Rex_Luong_Tonghop_Service = new Rex_Luong_Tonghop_Service(sqlMapper);
            //_Rex_Xepca_Thang_Service = new Rex_Xepca_Thang_Service(sqlMapper);
            //_Rex_Thamgia_Tochuc_Service = new Rex_Thamgia_Tochuc_Service(sqlMapper);
            _Rex_Botri_Nhansu_Service = new Rex_Botri_Nhansu_Service(sqlMapper);
            //_Rex_Thamgia_Tochuc_Service = new Rex_Thamgia_Tochuc_Service(sqlMapper);
            _Rex_Phucap_Service = new Rex_Phucap_Service(sqlMapper);
            //_Rex_Dienbien_Luong_Service = new Rex_Dienbien_Luong_Service(sqlMapper);
            _Rex_Quanhe_Giadinh_Service = new Rex_Quanhe_Giadinh_Service(sqlMapper);
            _Rex_Khenthuong_Kyluat_Service = new Rex_Khenthuong_Kyluat_Service(sqlMapper);
            //_Rex_Kynang_Service = new Rex_Kynang_Service(sqlMapper);
            _Rex_Quatrinh_Congtac_Service = new Rex_Quatrinh_Congtac_Service(sqlMapper);
            _Rex_Quatrinh_Daotao_Service = new Rex_Quatrinh_Daotao_Service(sqlMapper);
            //_Rex_Kyluong_Service = new Rex_Kyluong_Service(sqlMapper);
            //_Rex_Nghiphep_Service = new Rex_Nghiphep_Service(sqlMapper);
            _Rex_Hopdong_Laodong_Info_Service = new Rex_Hopdong_Laodong_Info_Service(sqlMapper);
            _Rex_Hopdong_Laodong_Phuluc_Service = new Rex_Hopdong_Laodong_Phuluc_Service(sqlMapper);
            #endregion
        }

        #region Rex - Webmethod

        #region Rex_Nhansu
        [WebMethod(Description = "Trả về một dataset Nhansu (có Bộ phận)")]
        public string Get_All_Rex_Nhansu_Collection()
        {
            return _Rex_Nhansu_Service.Get_All_Rex_Nhansu_Collection();
        }

        [WebMethod(Description = "Trả về một dataset Nhansu (có Email)")]
        public string Rex_Nhansu_SelectMail()
        {
            return _Rex_Nhansu_Service.Rex_Nhansu_SelectMail();
        }

        [WebMethod(Description = "Trả về một dataset Nhansu (Ko có B phận)")]
        public string Get_All_Rex_Nhansu_None_Bophan()
        {
            return _Rex_Nhansu_Service.Get_All_Rex_Nhansu_None_Bophan();
        }

        [WebMethod(Description = "Trả về một dataset Nhansu")]
        public string Get_All_Rex_Nhansu_Chuabotri_Collection()
        {
            return _Rex_Nhansu_Service.Get_All_Rex_Nhansu_Chuabotri();
        }

        [WebMethod(Description = "Trả về một dataset Nhansu")]
        public string Get_Rex_Nhansu_ByBoPhan_Collection(object Id_Bophan)
        {
            return _Rex_Nhansu_Service.Get_Rex_Nhansu_ByBoPhan(Id_Bophan);
        }

        [WebMethod(Description = "Trả về một dataset Nhansu")]
        public string Get_Rex_NhansuNghiphep_ByBoPhan_Collection(object Id_Bophan)
        {
            return _Rex_Nhansu_Service.Get_Rex_NhansuNghiphep_ByBoPhan(Id_Bophan);
        }

        [WebMethod(Description = "Trả về một  Nhansu")]
        public Ecm.Domain.Rex.Rex_Nhansu Get_Rex_Nhansu_ById(object Id_Nhansu)
        {
            return _Rex_Nhansu_Service.Get_Rex_Nhansu_ById(Id_Nhansu);
        }

        [WebMethod(Description = "Trả về một  Nhansu")]
        public Ecm.Domain.Rex.Rex_Nhansu Rex_Nhansu_SelectMail_Nhansu_KTVP()
        {
            return _Rex_Nhansu_Service.Rex_Nhansu_SelectMail_Nhansu_KTVP();
        }

        [WebMethod(Description = "Trả về một dataset Nhansu")]
        public string Get_DsRex_Nhansu_ById(object Id_Nhansu)
        {
            return _Rex_Nhansu_Service.Get_DsRex_Nhansu_ById(Id_Nhansu);
        }

        [WebMethod(Description = "Trả về một dataset Nhansu")]
        public string Get_Rex_NhansuChamcomg_ByBoPhan(object id_Bophan, object nam_Kyluong, object thang_Kyluong, object ngay_BD, object ngay_KT)
        {
            return _Rex_Nhansu_Service.Get_Rex_NhansuChamcomg_ByBoPhan(id_Bophan, nam_Kyluong, thang_Kyluong, ngay_BD, ngay_KT);
        }

        [WebMethod(Description = "Lấy danh mục phụ cấp cho nhân viên theo chuc vu")]
        public string Rex_Nhansu_Get_Phucap_By_Idchucvu(object id_chucvu)
        {
            return _Rex_Nhansu_Service.Rex_Nhansu_Get_DM_Phucap(id_chucvu);
        }

        [WebMethod(Description = "Lấy các phụ cấp của nhân viên theo id_nhansu")]
        public string Rex_Nhansu_Get_Phucap_By_Idnhansu(object id_nhansu)
        {
            return _Rex_Nhansu_Service.Rex_Nhansu_Get_Phucap(id_nhansu);
        }

        [WebMethod(Description = "Insert đối tượng Nhansu vào DB.")]
        public object Insert_Rex_Nhansu(Ecm.Domain.Rex.Rex_Nhansu Rex_Nhansu)
        {
            return _Rex_Nhansu_Service.Insert_Rex_Nhansu(Rex_Nhansu);
        }

        [WebMethod(Description = "Update đối tượng Nhansu vào DB.")]
        public object Update_Rex_Nhansu(Ecm.Domain.Rex.Rex_Nhansu Rex_Nhansu)
        {
            return _Rex_Nhansu_Service.Update_Rex_Nhansu(Rex_Nhansu);
        }
        [WebMethod(Description = "Update đối tượng Nhansu vào DB.")]
        public object Update_Rex_NhansuInfo(Ecm.Domain.Rex.Rex_Nhansu Rex_Nhansu)
        {
            return _Rex_Nhansu_Service.Update_Rex_NhansuInfo(Rex_Nhansu);
        }
        [WebMethod(Description = "Delete đối tượng Nhansu vào DB.")]
        public object Delete_Rex_Nhansu(Ecm.Domain.Rex.Rex_Nhansu Rex_Nhansu)
        {
            return _Rex_Nhansu_Service.Delete_Rex_Nhansu(Rex_Nhansu);
        }

        [WebMethod(Description = "Update collection Nhansu vào DB.")]
        public object Update_Rex_Nhansu_Collection(DataSet dsCollection)
        {
            return _Rex_Nhansu_Service.Update_Rex_Nhansu_Collection(dsCollection);
        }

        [WebMethod(Description = "Insert đối tượng Nhansu vào DB.")]
        public object Insert_Rex_Botri_Nhansu(Ecm.Domain.Rex.Rex_Botri_Nhansu Rex_Botri_Nhansu)
        {
            return _Rex_Nhansu_Service.Insert_Rex_Botri_Nhansu(Rex_Botri_Nhansu);
        }

        [WebMethod(Description = "Insert đối tượng Nhansu vào DB.")]
        public object Update_Rex_Botri_Nhansu(Ecm.Domain.Rex.Rex_Botri_Nhansu Rex_Botri_Nhansu)
        {
            return _Rex_Nhansu_Service.Update_Rex_Botri_Nhansu(Rex_Botri_Nhansu);
        }
        [WebMethod]
        public string Get_NhansuInfo_Inthe(Ecm.Domain.Rex.Rex_Nhansu Rex_Nhansu)
        {
            return _Rex_Nhansu_Service.Get_NhansuInfo_Inthe(Rex_Nhansu);
        }
        [WebMethod]
        public string Get_NhansuInfo_In_Hoso(Ecm.Domain.Rex.Rex_Nhansu Rex_Nhansu)
        {
            return _Rex_Nhansu_Service.Get_NhansuInfo_In_Hoso(Rex_Nhansu);
        }
        [WebMethod]
        public string Get_Quatrinh_Daotao_In_Hoso_Nhansu(object Id_Nhansu)
        {
            return _Rex_Nhansu_Service.Get_Quatrinh_Daotao_In_Hoso_Nhansu(Id_Nhansu);
        }
        [WebMethod]
        public string Get_Quanhe_Giadinh_In_Hoso_Nhansu(object Id_Nhansu)
        {
            return _Rex_Nhansu_Service.Get_Quanhe_Giadinh_In_Hoso_Nhansu(Id_Nhansu);
        }
        [WebMethod]
        public string Get_Quatrinh_Congtac_In_Hoso_Nhansu(object Id_Nhansu)
        {
            return _Rex_Nhansu_Service.Get_Quatrinh_Congtac_In_Hoso_Nhansu(Id_Nhansu);
        }
        [WebMethod]
        public string Get_Dienbien_Luong_In_Hoso_Nhansu(object Id_Nhansu)
        {
            return _Rex_Nhansu_Service.Get_Dienbien_Luong_In_Hoso_Nhansu(Id_Nhansu);
        }
        //[WebMethod]
        //public string Get_Danhsach_Nhansu_In_Lylich_Trichngang(object Id_Bophan)
        //{
        //    return _Rex_Nhansu_Service.Get_Danhsach_Nhansu_In_Lylich_Trichngang(Id_Bophan);
        //}
        [WebMethod]
        public string Get_All_Finger_Userinfo()
        {
            return _Rex_Nhansu_Service.Get_All_Finger_Userinfo();
        }

        [WebMethod]
        public string Get_Rex_Nhansu_Tamhoan(object Id_Nhansu)
        {
            return _Rex_Nhansu_Service.Get_Rex_Nhansu_Tamhoan(Id_Nhansu);
        }

        [WebMethod]
        public string Get_Rex_Nhansu_Nghiviec(object Id_Nhansu)
        {
            return _Rex_Nhansu_Service.Get_Rex_Nhansu_Nghiviec(Id_Nhansu);
        }

        [WebMethod]
        public string Get_Rex_Nhansu_Thuviec(object ngay_Batdau, object ngay_Ketthuc, object id_Bophan)
        {
            return _Rex_Nhansu_Service.Get_Danhsach_Nhansu_Thuviec(ngay_Batdau, ngay_Ketthuc, id_Bophan);
        }

        [WebMethod]
        public string Get_Rex_Nhansu_Dentuoihuu(object ngay_Batdau, object ngay_Ketthuc, object id_Bophan)
        {
            return _Rex_Nhansu_Service.Get_Danhsach_Nhansu_Dentuoihuu(ngay_Batdau, ngay_Ketthuc, id_Bophan);
        }

        [WebMethod]
        public object Get_Nhansu_Trangthai_Hopdong(object Id_Nhansu)
        {
            return _Rex_Nhansu_Service.Get_Nhansu_Trangthai_Hopdong(Id_Nhansu);
        }

        [WebMethod]
        public object Rex_Nhansu_Cohopdong(object Id_Nhansu)
        {
            return _Rex_Nhansu_Service.Rex_Nhansu_Cohopdong(Id_Nhansu);
        }

        [WebMethod]
        public string Get_Search_Rex_Nhansu(Ecm.Domain.Rex.Rex_Nhansu Rex_Nhansu)
        {
            return _Rex_Nhansu_Service.Get_Search_Rex_Nhansu(Rex_Nhansu);
        }


        [WebMethod]
        public string Get_NhansuInfo_In_Hoso_ByBophan(object Id_Bophan)
        {
            return _Rex_Nhansu_Service.Get_NhansuInfo_In_Hoso_ByBophan(Id_Bophan);
        }
        [WebMethod]
        public string Get_Dienbien_Luong_In_Hoso_ByBophan(object Id_Bophan)
        {
            return _Rex_Nhansu_Service.Get_Dienbien_Luong_In_Hoso_ByBophan(Id_Bophan);
        }
        [WebMethod]
        public string Get_Quatrinh_Daotao_In_Hoso_ByBophan(object Id_Bophan)
        {
            return _Rex_Nhansu_Service.Get_Quatrinh_Daotao_In_Hoso_ByBophan(Id_Bophan);
        }
        [WebMethod]
        public string Get_Quatrinh_Congtac_In_Hoso_ByBophan(object Id_Bophan)
        {
            return _Rex_Nhansu_Service.Get_Quatrinh_Congtac_In_Hoso_ByBophan(Id_Bophan);
        }
        [WebMethod]
        public string Get_Quanhe_Giadinh_In_Hoso_ByBophan(object Id_Bophan)
        {
            return _Rex_Nhansu_Service.Get_Quanhe_Giadinh_In_Hoso_ByBophan(Id_Bophan);
        }
        [WebMethod]
        public string Get_Phucap_In_Hoso_ByBophan(object Id_Bophan)
        {
            return _Rex_Nhansu_Service.Get_Phucap_In_Hoso_ByBophan(Id_Bophan);
        }

        [WebMethod(Description = "Trả về một dataset Nhansu")]
        public string DsRex_Nhansu_SelectMail_Nhansu_KTVP()
        {
            return _Rex_Nhansu_Service.DsRex_Nhansu_SelectMail_Nhansu_KTVP();
        }

        [WebMethod(Description = "Trả về một dataset Nhansu")]
        public string Rex_Nhansu_SelectMail_Nhansu_KTVP_Mobile()
        {
            return _Rex_Nhansu_Service.Rex_Nhansu_SelectMail_Nhansu_KTVP_Mobile();
        }


        [WebMethod(Description = "Trả về một dataset Nhansu")]
        public string Rex_Nhansu_SelectEmail_ByChungtu(object Sochungtu)
        {
            return _Rex_Nhansu_Service.Rex_Nhansu_SelectEmail_ByChungtu(Sochungtu);
        }


        [WebMethod(Description = "Trả về một dataset Nhansu có mã sản xuất")]
        public string Get_Rex_Nhansu_Co_Ma_Sx(object Vitri1, object Vitri2)
        {
            return _Rex_Nhansu_Service.Get_Rex_Nhansu_Co_Ma_Sx(Vitri1, Vitri2);
        }

        [WebMethod(Description = "Update đối tượng Nhansu vào DB.")]
        public object Update_Rex_Nhansu_Taikhoan_Nganhang(Ecm.Domain.Rex.Rex_Nhansu Rex_Nhansu)
        {
            return _Rex_Nhansu_Service.Update_Rex_Nhansu_Taikhoan_Nganhang(Rex_Nhansu);
        }

        [WebMethod(Description = "Update mã sản xuất vào Rex_Nhansu")]
        public object Update_Rex_Nhansu_Ma_Sx(Ecm.Domain.Rex.Rex_Nhansu rex_Nhansu)
        {
            return _Rex_Nhansu_Service.Update_Rex_Nhansu_Ma_Sx(rex_Nhansu);
        }

        [WebMethod(Description = "Reset mã sản xuất vào Rex_Nhansu")]
        public object Update_Rex_Nhansu_Ma_Sx_To_Null(Ecm.Domain.Rex.Rex_Nhansu rex_Nhansu)
        {
            return _Rex_Nhansu_Service.Update_Rex_Nhansu_Ma_Sx_To_Null(rex_Nhansu);
        }


        #endregion

        #region Rex_Nhansu thống kê

        [WebMethod(Description = "Get về danh sách Nhân sự thống kê theo kỹ năng")]
        public string Get_Rex_Nhansu_ThongKe_By_KynangChuyenmon(object Thoigian_Batdau, object Thoigian_Ketthuc)
        {
            return _Rex_Nhansu_Service.Rex_Nhansu_ThongKe_By_KynangChuyenmon(Thoigian_Batdau, Thoigian_Ketthuc);
        }

        [WebMethod(Description = "Trả về một dataset Rex_Nhansu bằng các tham số truyền vào, dùng để thống kê")]
        public string Get_Rex_Nhansu_Thongke(object Thoigian_Batdau, object Thoigian_Ketthuc, object Dotuoi_From, object Dotuoi_To, object Gioitinh,
                        object Id_Vanhoa, object Id_Chuyenmon, object Id_Dantoc, object Id_Tongiao, object Id_Tpgiadinh, object Id_Kynang, object Value)
        {
            return _Rex_Nhansu_Service.Rex_Nhansu_ThongKe(Thoigian_Batdau, Thoigian_Ketthuc, Dotuoi_From, Dotuoi_To, Gioitinh, Id_Vanhoa, Id_Chuyenmon, Id_Dantoc,
                                                        Id_Tongiao, Id_Tpgiadinh, Id_Kynang, Value);
        }

        [WebMethod(Description = "Trả về một dataset Rex_Nhansu chi tiết trong 1 khoảng thời gian")]
        public string Get_Rex_Nhansu_Thongke_Chitiet(object Thoigian_Batdau, object Thoigian_Ketthuc)
        {
            return _Rex_Nhansu_Service.Rex_Nhansu_ThongKe_Chitiet(Thoigian_Batdau, Thoigian_Ketthuc);
        }

        [WebMethod(Description = "Trả về một dataset Rex_Nhansu chi tiết By Id_Loai_Hopdong")]
        public string Get_Rex_Nhansu_Thongke_By_LoaiHD(object Thoigian_Batdau, object Thoigian_Ketthuc, object Id_Bophan, object Id_Loai_Hopdong)
        {
            return _Rex_Nhansu_Service.Rex_Nhansu_Thongke_By_LoaiHD(Thoigian_Batdau, Thoigian_Ketthuc, Id_Bophan, Id_Loai_Hopdong);
        }

        #endregion

        #region Bố trí nhan su


        [WebMethod(Description = "Trả về collection for hopdong_laodong(trong một mãng Rex_Botri_Nhansu)")]
        public string Get_Rex_Botri_Nhansu_For_Hopdong_Laodong_Collection(object id_nhansu, object ngay_batdau_hdld)
        {
            Hashtable htpara = new Hashtable();
            htpara.Add("Id_Nhansu", id_nhansu);
            htpara.Add("Ngay_Batdau_Hdld", ngay_batdau_hdld);

            return _Rex_Botri_Nhansu_Service.Get_Rex_Botri_Nhansu_For_Hopdong_Laodong_Collection(htpara);

        }

        [WebMethod(Description = "Trả về một dataSet Rex_Botri_Nhansu")]
        public string Get_All_Rex_Botri_Nhansu_byBophan_Collection(object Id_Bophan)
        {
            return _Rex_Botri_Nhansu_Service.Get_All_Rex_Botri_Nhansu_byBophan_Collection(Id_Bophan);
        }

        [WebMethod(Description = "Trả về Dataset (trong một mãng Rex_Botri_Nhansu)")]
        public string GetAll_Rex_Botri_Nhansu_Stt(object Id_Bophan, object Nam, object Thang)
        {
            return _Rex_Botri_Nhansu_Service.GetAll_Rex_Botri_Nhansu_Stt(Id_Bophan, Nam, Thang);
        }

        [WebMethod(Description = "Trả về một dataSet Rex_Botri_Nhansu")]
        public string Get_All_Rex_Botri_Nhansu_byNhanSu_Collection(Ecm.Domain.Rex.Rex_Nhansu rex_Nhansu)
        {
            return _Rex_Botri_Nhansu_Service.Get_All_Rex_Botri_Nhansu_byNhanSu_Collection(rex_Nhansu);
        }

        [WebMethod(Description = "Delete một đối tượng Rex_Botri_Nhansu vào bảng Rex_Botri_Nhansu")]
        public object Delete_Rex_Botri_Nhansu(Ecm.Domain.Rex.Rex_Botri_Nhansu rex_Botri_Nhansu)
        {
            return _Rex_Botri_Nhansu_Service.Delete_Rex_Botri_Nhansu(rex_Botri_Nhansu);
        }

        [WebMethod(Description = "Update Grid vao DB")]
        public object Update_Rex_Botri_Nhansu_Collection(DataSet dsCollection)
        {
            return _Rex_Botri_Nhansu_Service.Update_Rex_Botri_Nhansu_Collection(dsCollection);
        }

        [WebMethod(Description = "Update Grid vao DB")]
        public object Update_Rex_Botri_Nhansu_Stt_Collection(DataSet dsCollection)
        {
            return _Rex_Botri_Nhansu_Service.Update_Rex_Botri_Nhansu_Stt_Collection(dsCollection);
        }
        #endregion

        #region Bố trí ca làm việc
        [WebMethod(Description = "Trả về một dataSet Rex_Botri_Ca_Lamviec")]
        public string Get_All_Rex_Botri_Ca_Lamviec_By_Ca(object id_ca_lamviec)
        {
            return _Rex_Botri_Ca_Lamviec_Service.Get_All_Rex_Botri_Ca_Lamviec_By_Ca(id_ca_lamviec);
        }

        [WebMethod(Description = "Trả về một dataSet Rex_Botri_Ca_Lamviec")]
        public object Update_Botri_Ca_Lamviec_Collection(DataSet dsCollection)
        {
            return _Rex_Botri_Ca_Lamviec_Service.Update_Botri_Ca_Lamviec_Collection(dsCollection);
        }
        #endregion

        #region Rex_Hopdong_Laodong
        [WebMethod(Description = "Trả về một dataset Hopdong_Laodong")]
        public string Get_All_Rex_Hopdong_Laodong_By_Bophan(object Id_Bophan)
        {
            return _Rex_Hopdong_Laodong_Service.Get_All_Rex_Hopdong_Laodong_By_Bophan(Id_Bophan);
        }

        [WebMethod(Description = "Insert một đối tượng Rex_Hopdong_Laodong vào bảng Rex_Hopdong_Laodong")]
        public string GetAll_Rex_Hopdong_Laodong_ByBophan(object Id_Bophan, object Ngay_Bc)
        {
            return _Rex_Hopdong_Laodong_Service.GetAll_Rex_Hopdong_Laodong_ByBophan(Id_Bophan, Ngay_Bc);
        }

        [WebMethod(Description = "Trả về một dataset Hopdong_Laodong")]
        public string Get_All_Rex_Hopdong_Laodong_By_Nhansu(object Id_Nhansu)
        {
            return _Rex_Hopdong_Laodong_Service.Get_All_Rex_Hopdong_Laodong_By_Nhansu(Id_Nhansu);
        }
        [WebMethod(Description = "Insert đối tượng Hopdong_Laodong vào DB.")]
        public object Insert_Rex_Hopdong_Laodong(Ecm.Domain.Rex.Rex_Hopdong_Laodong Rex_Hopdong_Laodong)
        {
            return _Rex_Hopdong_Laodong_Service.Insert_Rex_Hopdong_Laodong(Rex_Hopdong_Laodong);
        }

        [WebMethod(Description = "Update đối tượng Hopdong_Laodong vào DB.")]
        public object Update_Rex_Hopdong_Laodong(Ecm.Domain.Rex.Rex_Hopdong_Laodong Rex_Hopdong_Laodong)
        {
            return _Rex_Hopdong_Laodong_Service.Update_Rex_Hopdong_Laodong(Rex_Hopdong_Laodong);
        }

        [WebMethod(Description = "Delete đối tượng Hopdong_Laodong vào DB.")]
        public object Delete_Rex_Hopdong_Laodong(Ecm.Domain.Rex.Rex_Hopdong_Laodong Rex_Hopdong_Laodong)
        {
            return _Rex_Hopdong_Laodong_Service.Delete_Rex_Hopdong_Laodong(Rex_Hopdong_Laodong);
        }

        [WebMethod(Description = "Update collection Hopdong_Laodong vào DB.")]
        public object Update_Rex_Hopdong_Laodong_Collection(DataSet dsCollection)
        {
            return _Rex_Hopdong_Laodong_Service.Update_Hopdong_Laodong_Collection(dsCollection);
        }

        [WebMethod(Description = "Lay so hop dong cuoi cung + 1 tu DB Rex_Hopdong_Laodong.")]
        public object Get_Rex_Hopdong_Laodong_SoHD()
        {
            return _Rex_Hopdong_Laodong_Service.Get_Rex_Hopdong_Laodong_SoHD();
        }

        [WebMethod]
        public int GetETrangthaiHopdongLaodong(Ecm.Domain.Enumerators.ETrangthaiHopdongLaodong Trangthai)
        {
            int reval = 0;
            switch (Trangthai)
            {
                case Ecm.Domain.Enumerators.ETrangthaiHopdongLaodong.DangHopdong:
                    reval = 0;
                    break;
                case Ecm.Domain.Enumerators.ETrangthaiHopdongLaodong.TamhoanHopdong:
                    reval = 1;
                    break;
                case Ecm.Domain.Enumerators.ETrangthaiHopdongLaodong.KetthucHopdong:
                    reval = 2;
                    break;
                case Ecm.Domain.Enumerators.ETrangthaiHopdongLaodong.HethanHopdong:
                    reval = 3;
                    break;
                case Ecm.Domain.Enumerators.ETrangthaiHopdongLaodong.GianhanHopdong:
                    reval = 4;
                    break;
            }

            return reval;
        }

        [WebMethod(Description = "Trả về danh sách tất cả Hợp đồng lao dong phu luc by id phụ lục")]
        public string Rex_Hopdong_Laodong_Phuluc_Select_By_Id_Phuluc(object Id_Hopdong_Laodong_Phuluc)
        {
            return _Rex_Hopdong_Laodong_Phuluc_Service.Get_Rex_Hopdong_Laodong_Phuluc_By_Id_Phuluc(Id_Hopdong_Laodong_Phuluc);
        }

        #endregion

        #region Rex_Chamcong_Thang
        [WebMethod(Description = "Trả về collection (trong một mãng Rex_Chamcong_Thang)")]
        public string Get_All_Rex_Chamcong_Thang_Collection(object Nam_Kyluong, object Thang_Kyluong, object Id_Bophan, object Baogom_Nghiphep, object Inc_Bophan_Tructhuoc)
        {
            var rex_Chamcong_Thang_Collection = _Rex_Chamcong_Thang_Service.Get_All_Rex_Chamcong_Thang(Nam_Kyluong, Thang_Kyluong, Id_Bophan, Baogom_Nghiphep, Inc_Bophan_Tructhuoc);
            return rex_Chamcong_Thang_Collection;
        }

        [WebMethod(Description = "Trả về collection (trong một mãng Rex_Chamcong_Thang)")]
        public object Rex_Chamcong_Thang_Tinhgiocong(Ecm.Domain.Rex.Rex_Chamcong_Thang _Rex_Chamcong_Thang)
        {
            return _Rex_Chamcong_Thang_Service.Rex_Chamcong_Thang_Tinhgiocong(_Rex_Chamcong_Thang);
        }

        [WebMethod(Description = "Update collection Rex_Chamcong_Thang vào DB.")]
        public object Update_Rex_Chamcong_Thang_Collection(DataSet dsCollection)
        {
            return _Rex_Chamcong_Thang_Service.Update_Rex_Chamcong_Thang_Collection(dsCollection);
        }

        [WebMethod]
        public object Init_Rex_Chamcong_Thang_ByFinger(Ecm.Domain.Rex.Rex_Chamcong_Thang Rex_Chamcong_Thang)
        {
            return _Rex_Chamcong_Thang_Service.Init_Rex_Chamcong_Thang_ByFinger(Rex_Chamcong_Thang);
        }
        #endregion

        #region Rex_Chamcong_Tangca
        [WebMethod(Description = "Trả về một dataset Rex_Chamcong_Tangca")]
        public string Get_All_Rex_Chamcong_Tangca_Collection(Ecm.Domain.Rex.Rex_Chamcong_Tangca Rex_Chamcong_Tangca)
        {
            return _Rex_Chamcong_Tangca_Service.Get_All_Rex_Chamcong_Tangca(Rex_Chamcong_Tangca);
        }

        [WebMethod(Description = "Update collection Rex_Chamcong_Tangca vào DB.")]
        public object Update_Rex_Chamcong_Tangca_Collection(DataSet dsCollection)
        {
            return _Rex_Chamcong_Tangca_Service.Update_Rex_Chamcong_Tangca_Collection(dsCollection);
        }

        [WebMethod]
        public object Init_Rex_Chamcong_Tangca_ByFinger(Ecm.Domain.Rex.Rex_Chamcong_Tangca Rex_Chamcong_Tangca)
        {
            return _Rex_Chamcong_Tangca_Service.Init_Rex_Chamcong_Tangca_ByFinger(Rex_Chamcong_Tangca);
        }
        #endregion

        #region Rex_Quanhe_Giadinh
        [WebMethod(Description = "Trả về một dataset Rex_Quanhe_Giadinh")]
        public string Get_All_Rex_Quanhe_Giadinh_ByNhanSu_Collection(Ecm.Domain.Rex.Rex_Nhansu Rex_Nhansu)
        {
            return _Rex_Quanhe_Giadinh_Service.Get_All_Rex_Quanhe_Giadinh_byNhanSu_Collection(Rex_Nhansu);
        }

        [WebMethod(Description = "Update collection Rex_Quanhe_Giadinh vào DB.")]
        public object Update_Rex_Quanhe_Giadinh_Collection(DataSet dsCollection)
        {
            return _Rex_Quanhe_Giadinh_Service.Update_Rex_Quanhe_Giadinh_Collection(dsCollection);
        }
        #endregion

        #region Rex_Khenthuong_Kyluat
        [WebMethod(Description = "Trả về một dataset Rex_Khenthuong_Kyluat")]
        public string Get_All_Rex_Khenthuong_Kyluat_ByNhanSu_Collection(Ecm.Domain.Rex.Rex_Nhansu Rex_Nhansu)
        {
            return _Rex_Khenthuong_Kyluat_Service.Get_All_Rex_Khenthuong_Kyluat_byNhanSu_Collection(Rex_Nhansu);
        }

        [WebMethod(Description = "Update collection Rex_Khenthuong_Kyluat vào DB.")]
        public object Update_Rex_Khenthuong_Kyluat_Collection(DataSet dsCollection)
        {
            return _Rex_Khenthuong_Kyluat_Service.Update_Rex_Khenthuong_Kyluat_Collection(dsCollection);
        }
        #endregion

        //#region Rex_Kynang
        //[WebMethod(Description = "Trả về một dataset Rex_Kynang")]
        //public string Get_All_Rex_Kynang_ByNhanSu_Collection(Ecm.Domain.Rex.Rex_Nhansu Rex_Nhansu)
        //{
        //    return _Rex_Kynang_Service.Get_All_Rex_Kynang_byNhanSu_Collection(Rex_Nhansu);
        //}

        //[WebMethod(Description = "Update collection Rex_Kynang vào DB.")]
        //public object Update_Rex_Kynang_Collection(DataSet dsCollection)
        //{
        //    return _Rex_Kynang_Service.Update_Rex_Kynang_Collection(dsCollection);
        //}
        //#endregion

        #region Rex_Quatrinh_Congtac
        [WebMethod(Description = "Trả về một dataset Rex_Quatrinh_Congtac")]
        public string Get_All_Rex_Quatrinh_Congtac_ByNhanSu_Collection(Ecm.Domain.Rex.Rex_Nhansu Rex_Nhansu)
        {
            return _Rex_Quatrinh_Congtac_Service.Get_All_Rex_Quatrinh_Congtac_byNhanSu_Collection(Rex_Nhansu);
        }

        [WebMethod(Description = "Update collection Rex_Quatrinh_Congtac vào DB.")]
        public object Update_Rex_Quatrinh_Congtac_Collection(DataSet dsCollection)
        {
            return _Rex_Quatrinh_Congtac_Service.Update_Rex_Quatrinh_Congtac_Collection(dsCollection);
        }
        #endregion

        #region Rex_Quatrinh_Daotao
        [WebMethod(Description = "Trả về một dataset Rex_Quatrinh_Daotao")]
        public string Get_All_Rex_Quatrinh_Daotao_ByNhanSu_Collection(Ecm.Domain.Rex.Rex_Nhansu Rex_Nhansu)
        {
            return _Rex_Quatrinh_Daotao_Service.Get_All_Rex_Quatrinh_Daotao_byNhanSu_Collection(Rex_Nhansu);
        }

        [WebMethod(Description = "Update collection Rex_Quatrinh_Daotao vào DB.")]
        public object Update_Rex_Quatrinh_Daotao_Collection(DataSet dsCollection)
        {
            return _Rex_Quatrinh_Daotao_Service.Update_Rex_Quatrinh_Daotao_Collection(dsCollection);
        }
        #endregion

        #region Rex_Hopdong_Laodong_Info
        [WebMethod(Description = "Trả về Hop dong lao dong chi tiet theo ID Hop dong")]
        public Ecm.Domain.Rex.Rex_Hopdong_Laodong Get_Rex_Hopdong_Laodong_Info_ByID_Hopdong(object Id_Hopdong_Laodong)
        {
            return _Rex_Hopdong_Laodong_Info_Service.Get_Rex_Hopdong_Laodong_Info_ByID_Hopdong(Id_Hopdong_Laodong);
        }

        [WebMethod(Description = "Update Hop dong lao dong chi tiet theo ID Hop dong")]
        public object Update_Rex_Hopdong_Laodong_Info_ByID_Hopdong(Ecm.Domain.Rex.Rex_Hopdong_Laodong Rex_Hopdong_Laodong)
        {
            return _Rex_Hopdong_Laodong_Info_Service.Update_Rex_Hopdong_Laodong_Info_ByID_Hopdong(Rex_Hopdong_Laodong);
        }

        [WebMethod(Description = "Insert Hop dong lao dong chi tiet")]
        public object Insert_Rex_Hopdong_Laodong_Info(Ecm.Domain.Rex.Rex_Hopdong_Laodong Rex_Hopdong_Laodong)
        {
            return _Rex_Hopdong_Laodong_Info_Service.Insert_Rex_Hopdong_Laodong_Info(Rex_Hopdong_Laodong);
        }

        [WebMethod]
        public string Get_Hopdong_Nhansu_Info_In_Hoso(object Id_Hopdong_Laodong)
        {
            return _Rex_Hopdong_Laodong_Info_Service.Get_Hopdong_Nhansu_Info_In_Hoso(Id_Hopdong_Laodong);
        }
        #endregion

        #region Rex_Hopdong_Laodong_Phuluc

        [WebMethod(Description = "Trả về danh sách tất cả Hợp đồng lao dong phu luc ")]
        public string Get_Rex_Hopdong_Laodong_Phuluc_SelectAll()
        {
            return _Rex_Hopdong_Laodong_Phuluc_Service.Get_All_Rex_Hopdong_Laodong_Phuluc_SelectAll();
        }

        [WebMethod(Description = "Trả về danh sách tất cả Hợp đồng lao dong phu luc by Id_Hopdong_Laodong")]
        public string Get_Rex_Hopdong_Laodong_Phuluc_Select_By_Id_Hdld(object Id_Hopdong_Laodong)
        {
            return _Rex_Hopdong_Laodong_Phuluc_Service.Get_All_Rex_Hopdong_Laodong_Phuluc_Select_By_Id_Hdld(Id_Hopdong_Laodong);
        }

        [WebMethod(Description = "Insert Hợp đồng lao dong phu luc ")]
        public object Rex_Hopdong_Laodong_Phuluc_Insert(Ecm.Domain.Rex.Rex_Hopdong_Laodong_Phuluc Rex_Hopdong_Laodong_Phuluc)
        {
            return _Rex_Hopdong_Laodong_Phuluc_Service.Rex_Hopdong_Laodong_Phuluc_Insert(Rex_Hopdong_Laodong_Phuluc);
        }

        [WebMethod(Description = "Update Hợp đồng lao dong phu luc ")]
        public object Rex_Hopdong_Laodong_Phuluc_Update(Ecm.Domain.Rex.Rex_Hopdong_Laodong_Phuluc Rex_Hopdong_Laodong_Phuluc)
        {
            return _Rex_Hopdong_Laodong_Phuluc_Service.Rex_Hopdong_Laodong_Phuluc_Update(Rex_Hopdong_Laodong_Phuluc);
        }

        [WebMethod(Description = "Delete Hợp đồng lao dong phu luc ")]
        public object Rex_Hopdong_Laodong_Phuluc_Delete(object Id_Hopdong_Laodong_Phuluc)
        {
            return _Rex_Hopdong_Laodong_Phuluc_Service.Rex_Hopdong_Laodong_Phuluc_Delete(Id_Hopdong_Laodong_Phuluc);
        }

        [WebMethod(Description = "Trả về danh sách tất cả Hợp đồng lao dong phu luc by Id_Nhansu_Nld")]
        public string Get_Rex_Hopdong_Laodong_Phuluc_Select_By_Id_Nhansu_Nld(object Id_Nhansu_Nld)
        {
            return _Rex_Hopdong_Laodong_Phuluc_Service.Get_All_Rex_Hopdong_Laodong_Phuluc_Select_By_Id_Nhansu_Nld(Id_Nhansu_Nld);
        }

        [WebMethod(Description = "Lay so hop dong cuoi cung + 1 tu DB Rex_Hopdong_Laodong_Phuluc.")]
        public object Get_Rex_Hopdong_Laodong_Phuluc_SoHD()
        {
            return _Rex_Hopdong_Laodong_Phuluc_Service.Get_Rex_Hopdong_Laodong_Phuluc_SoHD();
        }

        #endregion


        #region Phụ cấp


        //[WebMethod(Description = "Trả về collection (trong một mãng Rex_Phucap)")]
        //public string Get_Rex_Phucap_Collection1()
        //{
        //    DataSet rex_Phucap_Collection = _Rex_Phucap_Service.Get_Rex_Phucap_Collection();
        //    return rex_Phucap_Collection;
        //}
        //[WebMethod(Description = "Trả về collection (trong một mãng Rex_Phucap)")]
        //public string GetAll_Rex_Phucap_By_Kyluong_Collection3(itvsbiz.Domain.Rex.Rex_Phucap Rex_Phucap)
        //{
        //    return _Rex_Phucap_Service.GetDs_All_Rex_Phucap_By_Kyluong(Rex_Phucap);        
        //}
        //[WebMethod(Description = "Trả về collection (trong một mãng Rex_Phucap)")]
        //public string GetAll_Rex_Phucap_By_Bophan_Collection3(itvsbiz.Domain.Rex.Rex_Phucap Rex_Phucap)
        //{
        //    return _Rex_Phucap_Service.GetDs_All_Rex_Phucap_By_Bophan(Rex_Phucap);
        //}

        [WebMethod(Description = "Trả về Dataset (trong một mãng Rex_Phucap)")]
        public string Get_All_Rex_Phucap_byNhanSu_Collection(Ecm.Domain.Rex.Rex_Nhansu _Rex_Nhansu)
        {
            return _Rex_Phucap_Service.Get_All_Rex_Phucap_byNhanSu_Collection(_Rex_Nhansu);
        }

        [WebMethod(Description = "Trả về Dataset For Hopdong_Laodong(trong một mãng Rex_Phucap)")]
        public string Get_Rex_Phucap_For_Hopdong_Laodong_Collection(object Id_Nhansu, object Ngay_Batdau_Hdld)
        {
            return _Rex_Phucap_Service.Get_Rex_Phucap_For_Hopdong_Laodong_Collection(Id_Nhansu, Ngay_Batdau_Hdld);
        }

        //[WebMethod(Description = "Insert một đối tượng Rex_Phucap vào bảng Rex_Phucap từ một store rex_luong_nhom_init")]
        //public object Insert_Rex_Phucap(itvsbiz.Domain.Rex.Rex_Phucap rex_Phucap)
        //{
        //    return _Rex_Phucap_Service.Insert_Rex_Phucap(rex_Phucap);
        //}

        //[WebMethod(Description = "Update một đối tượng Rex_Phucap vào bảng Rex_Phucap")]
        //public object Update_Rex_Phucap(itvsbiz.Domain.Rex.Rex_Phucap rex_Phucap)
        //{
        //    return _Rex_Phucap_Service.Update_Rex_Phucap(rex_Phucap);
        //}

        [WebMethod(Description = "Delete một đối tượng Rex_Phucap vào bảng Rex_Phucap")]
        public object Delete_Rex_Phucap(Ecm.Domain.Rex.Rex_Phucap rex_Phucap)
        {
            return _Rex_Phucap_Service.Delete_Rex_Phucap(rex_Phucap);
        }


        [WebMethod(Description = "cập nhật một dataset Rex_Phucap vào trong bảng Rex_Phucap")]
        public object Update_Rex_Phucap_Collection(DataSet ds)
        {
            return _Rex_Phucap_Service.Update_Rex_Phucap_Collection(ds);
        }

        [WebMethod(Description = "Them moi phu cap")]
        public object Insert_Rex_Phucap_Collection(DataSet ds)
        {
            return _Rex_Phucap_Service.Insert_Rex_Phucap_Collection(ds);
        }

        [WebMethod(Description = "Xóa phu cap")]
        public object Delete_Rex_Phucap_Collection(DataSet ds)
        {
            return _Rex_Phucap_Service.Delete_Rex_Phucap_Collection(ds);
        }

        #endregion

        #endregion
    }
}
