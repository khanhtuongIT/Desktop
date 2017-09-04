using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;
using Ecm.WebReferences.MasterService;
using Ecm.WebReferences.ReportService;
using Ecm.WebReferences.WareService;

namespace Ecm.Reports.Forms
{
    public partial class FrmRptware_Baocao_Khohang : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        string report = "";

        Ecm.WebReferences.Classes.WareService objWareService = new Ecm.WebReferences.Classes.WareService();
        Ecm.WebReferences.Classes.MasterService objMasterService = new Ecm.WebReferences.Classes.MasterService();
        Ecm.WebReferences.Classes.ReportService objReportServices = new Ecm.WebReferences.Classes.ReportService();

        public FrmRptware_Baocao_Khohang()
        {
            InitializeComponent();
            dtNgay_Batdau.Properties.MinValue = new DateTime(2000, 01, 01);
            dtNgay_Ketthuc.Properties.MinValue = new DateTime(2000, 01, 01);
            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Cancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_PrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            lookUpEdit_Cuahang_Ban.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            DisplayInfo();
        }

        #region Override Method

        public override void DisplayInfo()
        {
            DataSet ds_collection = objMasterService.Ware_Dm_Cuahang_Ban_Select_Kho().ToDataSet();
            DataRow row = ds_collection.Tables[0].NewRow();
            row["Id_Cuahang_Ban"] = -1;
            row["Ma_Cuahang_Ban"] = "All";
            row["Ten_Cuahang_Ban"] = "Tất cả";
            ds_collection.Tables[0].Rows.Add(row);
            lookUpEdit_Cuahang_Ban.Properties.DataSource = ds_collection.Tables[0];

            ds_collection = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
            lookUpEdit_Mahang.Properties.DataSource = ds_collection.Tables[0];
            lookUpEdit_Tenhang.Properties.DataSource = ds_collection.Tables[0];

            ds_collection = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Ban().ToDataSet();
            lookUpEdit_Loai_Hanghoa.Properties.DataSource = ds_collection.Tables[0];
            lookUpEdit_TenNHomHang.Properties.DataSource = ds_collection.Tables[0];

            ds_collection = objMasterService.Get_All_Ware_Dm_Phanloai_Nhom_Hanghoa_Ban_Nxt(true).ToDataSet();
            lookUpEditPhanloai_Nhom_Hanghoa.Properties.DataSource = ds_collection.Tables[0];

            dtNgay_Batdau.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtNgay_Ketthuc.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1);
        }

        public override bool PerformQuery()
        {
            switch (report)
            {
                case "Rptware_Thekho":
                    Load_Rptware_Thekho();
                    break;

                case "Rptware_Hangton":
                    Load_Rptware_Hangton();
                    break;

                case "Rptware_Hangton_NL":
                    Load_Rptware_Hangton_NL();
                    break;

                case "Rptware_Kiemke_Khohang":
                    Load_Rptware_Kiemke_Khohang();
                    break;

                case "Rptware_Xuat_Luanchuyen_Chitiet":
                    Load_Rptware_Xuat_Luanchuyen_Chitiet();
                    break;

                case "Rptware_Xuat_Luanchuyen_Tonghop":
                    Load_Rptware_Xuat_Luanchuyen_Tonghop();
                    break;

                case "Rptware_Nhap_Luanchuyen_Chitiet":
                    Load_Rptware_Nhap_Luanchuyen_Chitiet();
                    break;

                case "Rptware_Nhap_Luanchuyen_Tonghop":
                    Load_Rptware_Nhap_Luanchuyen_Tonghop();
                    break;

                case "Rptware_Xuathang_Tra_Nhacungcap":
                    Load_Rptware_Xuathang_Tra_Nhacungcap();
                    break;

                case "Rptware_Nhaphang_Khachhang_Tra":
                    Load_Rptware_Nhaphang_Khachhang_Tra();
                    break;

                case "Rptware_Nhapxuatton":
                    Load_Rptware_Nhapxuatton();
                    break;

                case "Rptware_Nhapxuatton_NL":
                    Load_Rptware_Nhapxuatton_NL();
                    break;

                case "Rptware_Xuat_Chitiet":
                    Load_Rptware_Xuat_Chitiet();
                    break;

                case "Rptware_Xuat_Tonghop":
                    Load_Rptware_Xuat_Tonghop();
                    break;

                case "Rptware_Nhap_Chitiet":
                    Load_Rptware_Nhap_Chitiet();
                    break;

                case "Rptware_Nhap_Tonghop":
                    Load_Rptware_Nhap_Tonghop();
                    break;

                case "Rptware_Nhapxuat_Chitiet":
                    Load_Rptware_Nhapxuat_Chitiet();
                    break;

                default:
                    // GoobizFrame.Windows.Forms.MessageDialog.Show("Vui lòng chọn loại báo cáo.");
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Vui lòng chọn loại báo cáo.", "Thông tin...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
            return base.PerformQuery();
        }

        #endregion

        #region Event

        private void navBar_Thekho_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Xuatnhap_Thekho _Rptware_Thekho = new Ecm.Reports.XtraReports.rptWare_Xuatnhap_Thekho();

            #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData
                });

                _Rptware_Thekho.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _Rptware_Thekho.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                _Rptware_Thekho.xrPic_Logo.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }
            #endregion

            printControl_Baocao.PrintingSystem = _Rptware_Thekho.PrintingSystem;
            this.report = "Rptware_Thekho";
            _Rptware_Thekho.CreateDocument();
            Loaddata();
        }

        private void navBar_Tonkho_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Xuatnhap_Hangton _Rptware_Hangton = new Ecm.Reports.XtraReports.rptWare_Xuatnhap_Hangton();

            #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData
                });

                _Rptware_Hangton.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _Rptware_Hangton.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
            }
            #endregion

            printControl_Baocao.PrintingSystem = _Rptware_Hangton.PrintingSystem;
            this.report = "Rptware_Hangton";
            _Rptware_Hangton.CreateDocument();
            Loaddata();
        }

        private void navBar_Nhapxuatton_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Xuatnhap_Nhapxuatton _Rptware_Nhapxuatton = new Ecm.Reports.XtraReports.rptWare_Xuatnhap_Nhapxuatton();

            #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData
                });

                _Rptware_Nhapxuatton.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _Rptware_Nhapxuatton.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
            }
            #endregion

            printControl_Baocao.PrintingSystem = _Rptware_Nhapxuatton.PrintingSystem;
            this.report = "Rptware_Nhapxuatton";
            _Rptware_Nhapxuatton.CreateDocument();
            Loaddata();
        }

        private void navBar_Kiemke_Hangton_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Xuatnhap_Kiemke_Khohang _Rptware_Kiemke_Khohang = new Ecm.Reports.XtraReports.rptWare_Xuatnhap_Kiemke_Khohang();

            #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData
                });

                _Rptware_Kiemke_Khohang.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _Rptware_Kiemke_Khohang.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                _Rptware_Kiemke_Khohang.xrPic_Logo.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }
            #endregion

            printControl_Baocao.PrintingSystem = _Rptware_Kiemke_Khohang.PrintingSystem;
            this.report = "Rptware_Kiemke_Khohang";
            _Rptware_Kiemke_Khohang.CreateDocument();
            Loaddata();
        }

        private void navBar_Chitiet_Hangxuat_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Xuatnhap_Chitiet _Rptware_Xuatnhap_Chitiet = new Ecm.Reports.XtraReports.rptWare_Xuatnhap_Chitiet();

            #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData
                });

                _Rptware_Xuatnhap_Chitiet.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _Rptware_Xuatnhap_Chitiet.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
            }
            #endregion

            printControl_Baocao.PrintingSystem = _Rptware_Xuatnhap_Chitiet.PrintingSystem;
            this.report = "Rptware_Xuat_Chitiet";
            _Rptware_Xuatnhap_Chitiet.xrLabel_ReportName.Text = @"SỔ CHI TIẾT XUẤT HÀNG";
            _Rptware_Xuatnhap_Chitiet.xrTable_Loaiphieu.Text = @"PHIẾU XUẤT";
            _Rptware_Xuatnhap_Chitiet.CreateDocument();
            Loaddata();
        }

        private void navBar_Tonghop_Hangxuat_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Xuatnhap_Tonghop _Rptware_Xuatnhap_Tonghop = new Ecm.Reports.XtraReports.rptWare_Xuatnhap_Tonghop();

            #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData
                });

                _Rptware_Xuatnhap_Tonghop.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _Rptware_Xuatnhap_Tonghop.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
            }
            #endregion

            printControl_Baocao.PrintingSystem = _Rptware_Xuatnhap_Tonghop.PrintingSystem;
            this.report = "Rptware_Xuat_Tonghop";
            _Rptware_Xuatnhap_Tonghop.xrLabel_ReportName.Text = @"BÁO CÁO TỔNG HỢP HÀNG XUẤT";
            _Rptware_Xuatnhap_Tonghop.CreateDocument();
            Loaddata();
        }

        private void navBar_Chitiet_Hangnhap_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Xuatnhap_Chitiet _Rptware_Xuatnhap_Chitiet = new Ecm.Reports.XtraReports.rptWare_Xuatnhap_Chitiet();

            #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData
                });

                _Rptware_Xuatnhap_Chitiet.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _Rptware_Xuatnhap_Chitiet.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
            }
            #endregion

            printControl_Baocao.PrintingSystem = _Rptware_Xuatnhap_Chitiet.PrintingSystem;
            this.report = "Rptware_Nhap_Chitiet";
            _Rptware_Xuatnhap_Chitiet.xrLabel_ReportName.Text = @"SỔ CHI TIẾT NHẬP HÀNG";
            _Rptware_Xuatnhap_Chitiet.xrTable_Loaiphieu.Text = @"PHIẾU NHẬP";
            _Rptware_Xuatnhap_Chitiet.CreateDocument();
            Loaddata();
        }

        private void navBar_Tonghop_Hangnhap_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Xuatnhap_Tonghop _Rptware_Xuatnhap_Tonghop = new Ecm.Reports.XtraReports.rptWare_Xuatnhap_Tonghop();

            #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData
                });

                _Rptware_Xuatnhap_Tonghop.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _Rptware_Xuatnhap_Tonghop.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
            }
            #endregion

            printControl_Baocao.PrintingSystem = _Rptware_Xuatnhap_Tonghop.PrintingSystem;
            this.report = "Rptware_Nhap_Tonghop";
            _Rptware_Xuatnhap_Tonghop.xrLabel_ReportName.Text = @"BÁO CÁO TỔNG HỢP HÀNG NHẬP";
            _Rptware_Xuatnhap_Tonghop.CreateDocument();
            Loaddata();
        }

        private void navBar_Chitiet_Hangxuat_Luanchuyen_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Xuatnhap_Luanchuyen_Chitiet _Rptware_Xuatnhap_Luanchuyen_Chitiet = new Ecm.Reports.XtraReports.rptWare_Xuatnhap_Luanchuyen_Chitiet();

            #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData
                });

                _Rptware_Xuatnhap_Luanchuyen_Chitiet.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _Rptware_Xuatnhap_Luanchuyen_Chitiet.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                _Rptware_Xuatnhap_Luanchuyen_Chitiet.xrPic_Logo.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }
            #endregion

            printControl_Baocao.PrintingSystem = _Rptware_Xuatnhap_Luanchuyen_Chitiet.PrintingSystem;
            this.report = "Rptware_Xuat_Luanchuyen_Chitiet";
            _Rptware_Xuatnhap_Luanchuyen_Chitiet.xrLabel_ReportName.Text = @"BÁO CÁO CHI TIẾT HÀNG XUẤT LUÂN CHUYỂN";
            _Rptware_Xuatnhap_Luanchuyen_Chitiet.CreateDocument();
            Loaddata();
        }

        private void navBar_Tonghop_Hangxuat_Luanchuyen_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Xuatnhap_Luanchuyen_Tonghop _Rptware_Xuatnhap_Luanchuyen_Tonghop = new Ecm.Reports.XtraReports.rptWare_Xuatnhap_Luanchuyen_Tonghop();

            #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData
                });

                _Rptware_Xuatnhap_Luanchuyen_Tonghop.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _Rptware_Xuatnhap_Luanchuyen_Tonghop.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                _Rptware_Xuatnhap_Luanchuyen_Tonghop.xrPic_Logo.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }
            #endregion

            printControl_Baocao.PrintingSystem = _Rptware_Xuatnhap_Luanchuyen_Tonghop.PrintingSystem;
            this.report = "Rptware_Xuat_Luanchuyen_Tonghop";
            _Rptware_Xuatnhap_Luanchuyen_Tonghop.xrLabel_ReportName.Text = @"BÁO CÁO TỔNG HỢP HÀNG XUẤT LUÂN CHUYỂN";
            _Rptware_Xuatnhap_Luanchuyen_Tonghop.CreateDocument();
            Loaddata();
        }

        private void navBar_Chitiet_Hangnhap_Luanchuyen_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Xuatnhap_Luanchuyen_Chitiet _Rptware_Xuatnhap_Luanchuyen_Chitiet = new Ecm.Reports.XtraReports.rptWare_Xuatnhap_Luanchuyen_Chitiet();

            #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData
                });

                _Rptware_Xuatnhap_Luanchuyen_Chitiet.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _Rptware_Xuatnhap_Luanchuyen_Chitiet.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                _Rptware_Xuatnhap_Luanchuyen_Chitiet.xrPic_Logo.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }
            #endregion

            printControl_Baocao.PrintingSystem = _Rptware_Xuatnhap_Luanchuyen_Chitiet.PrintingSystem;
            this.report = "Rptware_Nhap_Luanchuyen_Chitiet";
            _Rptware_Xuatnhap_Luanchuyen_Chitiet.xrLabel_ReportName.Text = @"BÁO CÁO CHI TIẾT HÀNG NHẬP LUÂN CHUYỂN";
            _Rptware_Xuatnhap_Luanchuyen_Chitiet.CreateDocument();
            Loaddata();
        }

        private void navBar_Tonghop_Hangnhap_Luanchuyen_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Xuatnhap_Luanchuyen_Tonghop _Rptware_Xuatnhap_Luanchuyen_Tonghop = new Ecm.Reports.XtraReports.rptWare_Xuatnhap_Luanchuyen_Tonghop();

            #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData
                });

                _Rptware_Xuatnhap_Luanchuyen_Tonghop.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _Rptware_Xuatnhap_Luanchuyen_Tonghop.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                _Rptware_Xuatnhap_Luanchuyen_Tonghop.xrPic_Logo.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }
            #endregion

            printControl_Baocao.PrintingSystem = _Rptware_Xuatnhap_Luanchuyen_Tonghop.PrintingSystem;
            this.report = "Rptware_Nhap_Luanchuyen_Tonghop";
            _Rptware_Xuatnhap_Luanchuyen_Tonghop.xrLabel_ReportName.Text = @"BÁO CÁO TỔNG HỢP HÀNG NHẬP LUÂN CHUYỂN";
            _Rptware_Xuatnhap_Luanchuyen_Tonghop.CreateDocument();
            Loaddata();
        }

        private void navBar_Chitiet_Xuattra_Ccc_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Xuatnhap_Tra_Nhacungcap _Rptware_Xuathang_Tra_Nhacungcap = new Ecm.Reports.XtraReports.rptWare_Xuatnhap_Tra_Nhacungcap();

            #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData
                });

                _Rptware_Xuathang_Tra_Nhacungcap.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _Rptware_Xuathang_Tra_Nhacungcap.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                _Rptware_Xuathang_Tra_Nhacungcap.xrPic_Logo.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }
            #endregion

            printControl_Baocao.PrintingSystem = _Rptware_Xuathang_Tra_Nhacungcap.PrintingSystem;
            this.report = "Rptware_Xuathang_Tra_Nhacungcap";
            _Rptware_Xuathang_Tra_Nhacungcap.CreateDocument();
            Loaddata();

        }

        private void navBar_Chitiet_Nhap_Khachtrahang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Xuatnhap_Khachhang_Tra _Rptware_Nhaphang_Khachhang_Tra = new Ecm.Reports.XtraReports.rptWare_Xuatnhap_Khachhang_Tra();

            #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData
                });

                _Rptware_Nhaphang_Khachhang_Tra.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _Rptware_Nhaphang_Khachhang_Tra.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                _Rptware_Nhaphang_Khachhang_Tra.xrPic_Logo.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }
            #endregion

            printControl_Baocao.PrintingSystem = _Rptware_Nhaphang_Khachhang_Tra.PrintingSystem;
            this.report = "Rptware_Nhaphang_Khachhang_Tra";
            _Rptware_Nhaphang_Khachhang_Tra.CreateDocument();
            Loaddata();

        }

        #endregion

        #region Custom Method

        private void Load_Rptware_Thekho()
        {
            try
            {
                System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
                hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
                hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
                hashtableControls.Add(lookUpEdit_Cuahang_Ban, lblCuahang_Ban.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return;
                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                    return;

                Ecm.Reports.XtraReports.rptWare_Xuatnhap_Thekho _Rptware_Thekho = new Ecm.Reports.XtraReports.rptWare_Xuatnhap_Thekho();
                #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
                using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
                {
                    DataSet dsCompany_Paras = new DataSet();
                    dsCompany_Paras.Tables.Add("Company_Paras");
                    dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                    dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                    dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                    byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                    dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                        dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                        ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                        ,imageData
                    });

                    _Rptware_Thekho.xrc_CompanyName.DataBindings.Add(
                        new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                    _Rptware_Thekho.xrc_CompanyAddress.DataBindings.Add(
                        new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                    _Rptware_Thekho.xrPic_Logo.DataBindings.Add(
                        new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
                }
                #endregion

                _Rptware_Thekho.Parameters["Khohang"].Value = lookUpEdit_Cuahang_Ban.Text;
                _Rptware_Thekho.Parameters["Tungay"].Value = dtNgay_Batdau.EditValue;
                _Rptware_Thekho.Parameters["Tungay"].Value = String.Format("{0:dd/MM/yyyy}", dtNgay_Batdau.EditValue);
                _Rptware_Thekho.Parameters["Denngay"].Value = String.Format("{0:dd/MM/yyyy}", dtNgay_Ketthuc.EditValue);

                //DataSet dsReport = objReportServices.Rptware_Thekho(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEdit_Cuahang_Ban.EditValue, null).ToDataSet();
                //decimal soluong_ton = 0;
                //for (int i = 0; i < dsReport.Tables[0].Rows.Count; i++)
                //{
                //    if (i == 0)
                //    {
                //        decimal soluong_dk = 0;
                //        decimal soluong_nhap = 0;
                //        decimal soluong_xuat = 0;
                //        if ("" + dsReport.Tables[0].Rows[i][5] != "")
                //            soluong_dk = Convert.ToDecimal(dsReport.Tables[0].Rows[i][5]);
                //        if ("" + dsReport.Tables[0].Rows[i][6] != "")
                //            soluong_nhap = Convert.ToDecimal("0" + dsReport.Tables[0].Rows[i][6]);
                //        if ("" + dsReport.Tables[0].Rows[i][7] != "")
                //            soluong_xuat = Convert.ToDecimal("0" + dsReport.Tables[0].Rows[i][7]);
                //        soluong_ton = soluong_dk + soluong_nhap - soluong_xuat;
                //        dsReport.Tables[0].Rows[i][8] = soluong_ton;
                //    }
                //    else
                //    {
                //        decimal soluong_nhap = 0;
                //        decimal soluong_xuat = 0;
                //        if ("" + dsReport.Tables[0].Rows[i][6] != "")
                //            soluong_nhap = Convert.ToDecimal("0" + dsReport.Tables[0].Rows[i][6]);
                //        if ("" + dsReport.Tables[0].Rows[i][7] != "")
                //            soluong_xuat = Convert.ToDecimal("0" + dsReport.Tables[0].Rows[i][7]); soluong_ton = soluong_ton + soluong_nhap - soluong_xuat;
                //        dsReport.Tables[0].Rows[i][8] = soluong_ton;
                //    }
                //}
                //dsReport.AcceptChanges();
                //_Rptware_Thekho.DataSource = dsReport;
                //GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
                //_FrmPrintPreview.Report = _Rptware_Thekho;
                //_Rptware_Thekho.CreateDocument();
                //GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_Rptware_Thekho);
                //if (Convert.ToBoolean(oReportOptions.PrintPreview))
                //{
                //    _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                //    _FrmPrintPreview.printControl1.PrintingSystem = _Rptware_Thekho.PrintingSystem;
                //    _FrmPrintPreview.MdiParent = this.MdiParent;
                //    _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
                //}
                //else
                //{
                //    var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_Rptware_Thekho);
                //    ReportPrintTool.Print();
                //}
                //_FrmPrintPreview.Show();
                //_FrmPrintPreview.Activate();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
#endif
            }
        }

        private void Load_Rptware_Hangton()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            //hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            //hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            hashtableControls.Add(lookUpEdit_Cuahang_Ban, lblCuahang_Ban.Text);

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return;

            //DataSet ds_hangton = objWareService.Rptware_Nxt_Hhban(new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 1), new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59), lookUpEdit_Cuahang_Ban.EditValue, null, null);
            DataSet ds_hangton = objReportServices.Rptware_Nhapxuatton(Convert.ToInt64(lookUpEdit_Cuahang_Ban.EditValue), dtNgay_Batdau.DateTime.Date, dtNgay_Ketthuc.DateTime.Date, lookUpEdit_Mahang.EditValue, lookUpEdit_Loai_Hanghoa.EditValue).ToDataSet();
            Reports.XtraReports.rptWare_Xuatnhap_Hangton _Rptware_Hangton = new Ecm.Reports.XtraReports.rptWare_Xuatnhap_Hangton();
            GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            _FrmPrintPreview.Report = _Rptware_Hangton;

            #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData
                });

                _Rptware_Hangton.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _Rptware_Hangton.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
            }
            #endregion

            _Rptware_Hangton.xrTable_Kho.Text = lookUpEdit_Cuahang_Ban.Text;
            _Rptware_Hangton.xrTable_Denngay.Text = DateTime.Today.ToString("dd/MM/yyyy");
            _Rptware_Hangton.xrTable_Ngay.Text = DateTime.Today.Day.ToString();
            _Rptware_Hangton.xrTable_Thang.Text = DateTime.Today.Month.ToString();
            _Rptware_Hangton.xrTable_Nam.Text = DateTime.Today.Year.ToString();
            _Rptware_Hangton.DataSource = ds_hangton;

            _Rptware_Hangton.CreateDocument();
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_Rptware_Hangton);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                _FrmPrintPreview.printControl1.PrintingSystem = _Rptware_Hangton.PrintingSystem;
                _FrmPrintPreview.MdiParent = this.MdiParent;
                _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
                //if (!System.IO.Directory.Exists(@"E:\donhang"))
                //    System.IO.Directory.CreateDirectory(@"E:\donhang");
               // _Rptware_Hangton.ExportToPdf(@"E:\donhang\11.pdf" );
                //_FrmPrintPreview.Show();
                _FrmPrintPreview.Activate();
            }
            else
            {
                var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_Rptware_Hangton);
                ReportPrintTool.Print();
            }
            _FrmPrintPreview.Show();
            _FrmPrintPreview.Activate();
        }

        private void Load_Rptware_Hangton_NL()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            //hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            //hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            hashtableControls.Add(lookUpEdit_Cuahang_Ban, lblCuahang_Ban.Text);

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return;

            //DataSet ds_hangton = objWareService.Rptware_Nxt_Hhban(new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 1), new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59), lookUpEdit_Cuahang_Ban.EditValue, null, null);
            DataSet ds_hangton = objReportServices.Rptware_Nhapxuatton_Nguyenlieu(Convert.ToInt64(lookUpEdit_Cuahang_Ban.EditValue), dtNgay_Batdau.DateTime.Date, dtNgay_Ketthuc.DateTime.Date, lookUpEdit_Mahang.EditValue, lookUpEdit_Loai_Hanghoa.EditValue).ToDataSet();
            Reports.XtraReports.rptWare_Xuatnhap_Hangton _Rptware_Hangton = new Ecm.Reports.XtraReports.rptWare_Xuatnhap_Hangton();
            GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            _FrmPrintPreview.Report = _Rptware_Hangton;

            #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData
                });

                _Rptware_Hangton.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _Rptware_Hangton.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
            }
            #endregion

            _Rptware_Hangton.xrTable_Kho.Text = lookUpEdit_Cuahang_Ban.Text;
            _Rptware_Hangton.xrTable_Denngay.Text = DateTime.Today.ToString("dd/MM/yyyy");
            _Rptware_Hangton.xrTable_Ngay.Text = DateTime.Today.Day.ToString();
            _Rptware_Hangton.xrTable_Thang.Text = DateTime.Today.Month.ToString();
            _Rptware_Hangton.xrTable_Nam.Text = DateTime.Today.Year.ToString();
            _Rptware_Hangton.xrLabel_Title.Text = "BÁO CÁO NGUYÊN LIỆU TỒN";
            _Rptware_Hangton.DataSource = ds_hangton;

            _Rptware_Hangton.CreateDocument();
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_Rptware_Hangton);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                _FrmPrintPreview.printControl1.PrintingSystem = _Rptware_Hangton.PrintingSystem;
                _FrmPrintPreview.MdiParent = this.MdiParent;
                _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
                //if (!System.IO.Directory.Exists(@"E:\donhang"))
                //    System.IO.Directory.CreateDirectory(@"E:\donhang");
                // _Rptware_Hangton.ExportToPdf(@"E:\donhang\11.pdf" );
                //_FrmPrintPreview.Show();
                _FrmPrintPreview.Activate();
            }
            else
            {
                var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_Rptware_Hangton);
                ReportPrintTool.Print();
            }
            _FrmPrintPreview.Show();
            _FrmPrintPreview.Activate();
        }

        private void Load_Rptware_Kiemke_Khohang()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            //hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(lookUpEdit_Cuahang_Ban, lblCuahang_Ban.Text);

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return;

            Reports.XtraReports.rptWare_Xuatnhap_Kiemke_Khohang _Rptware_Kiemke_Khohang = new Ecm.Reports.XtraReports.rptWare_Xuatnhap_Kiemke_Khohang();
            #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));
                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData});

                _Rptware_Kiemke_Khohang.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _Rptware_Kiemke_Khohang.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                _Rptware_Kiemke_Khohang.xrPic_Logo.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }
            #endregion

            _Rptware_Kiemke_Khohang.Parameters["Khohang"].Value = lookUpEdit_Cuahang_Ban.Text;
            //_Rptware_Kiemke_Khohang.DataSource = objReportServices.Rptware_Kiemke_Khohang(lookUpEdit_Cuahang_Ban.EditValue, dtNgay_Batdau.EditValue);
            _Rptware_Kiemke_Khohang.DataSource = objReportServices.Rptware_Kiemke_Khohang(lookUpEdit_Cuahang_Ban.EditValue, dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue).ToDataSet();
            GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            _FrmPrintPreview.Report = _Rptware_Kiemke_Khohang;
            _Rptware_Kiemke_Khohang.CreateDocument();
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_Rptware_Kiemke_Khohang);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                _FrmPrintPreview.printControl1.PrintingSystem = _Rptware_Kiemke_Khohang.PrintingSystem;
                _FrmPrintPreview.MdiParent = this.MdiParent;
                _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
            }
            else
            {
                var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_Rptware_Kiemke_Khohang);
                ReportPrintTool.Print();
            }
            _FrmPrintPreview.Show();
            _FrmPrintPreview.Activate();
        }

        private void Load_Rptware_Nhapxuatton()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            hashtableControls.Add(lookUpEdit_Cuahang_Ban, lblCuahang_Ban.Text);

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return;
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return;

            Reports.XtraReports.rptWare_Xuatnhap_Nhapxuatton _Rptware_Nhapxuatton = new Ecm.Reports.XtraReports.rptWare_Xuatnhap_Nhapxuatton();
            GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            _FrmPrintPreview.Report = _Rptware_Nhapxuatton;
            #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData
                });

                _Rptware_Nhapxuatton.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _Rptware_Nhapxuatton.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
            }
            #endregion

            _Rptware_Nhapxuatton.Parameters["Khohang"].Value = lookUpEdit_Cuahang_Ban.Text;
            _Rptware_Nhapxuatton.Parameters["Tungay"].Value = String.Format("{0:dd/MM/yyyy}", dtNgay_Batdau.EditValue);
            _Rptware_Nhapxuatton.Parameters["Denngay"].Value = String.Format("{0:dd/MM/yyyy}", dtNgay_Ketthuc.EditValue);
            DataSet DsCollection = objReportServices.Rptware_Nhapxuatton(Convert.ToInt64(lookUpEdit_Cuahang_Ban.EditValue), dtNgay_Batdau.DateTime.Date, dtNgay_Ketthuc.DateTime.Date, lookUpEdit_Mahang.EditValue, lookUpEdit_Loai_Hanghoa.EditValue).ToDataSet();
            _Rptware_Nhapxuatton.DataSource = DsCollection;
            _Rptware_Nhapxuatton.xrTable_Ngay.Text = DateTime.Today.Day.ToString();
            _Rptware_Nhapxuatton.xrTable_Thang.Text = DateTime.Today.Month.ToString();
            _Rptware_Nhapxuatton.xrTable_Nam.Text = DateTime.Today.Year.ToString();

            //_FrmPrintPreview.printControl1.PrintingSystem = _Rptware_Nhapxuatton.PrintingSystem;
            _Rptware_Nhapxuatton.CreateDocument();
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_Rptware_Nhapxuatton);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                _FrmPrintPreview.printControl1.PrintingSystem = _Rptware_Nhapxuatton.PrintingSystem;
                _FrmPrintPreview.MdiParent = this.MdiParent;
                _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
            }
            else
            {
                var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_Rptware_Nhapxuatton);
                ReportPrintTool.Print();
            }
            _FrmPrintPreview.Show();
            _FrmPrintPreview.Activate();
        }

        private void Load_Rptware_Nhapxuatton_NL()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            hashtableControls.Add(lookUpEdit_Cuahang_Ban, lblCuahang_Ban.Text);

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return;
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return;

            Reports.XtraReports.rptWare_Xuatnhap_Nhapxuatton _Rptware_Nhapxuatton = new Ecm.Reports.XtraReports.rptWare_Xuatnhap_Nhapxuatton();
            GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            _FrmPrintPreview.Report = _Rptware_Nhapxuatton;
            #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData
                });

                _Rptware_Nhapxuatton.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _Rptware_Nhapxuatton.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
            }
            #endregion

            _Rptware_Nhapxuatton.Parameters["Khohang"].Value = lookUpEdit_Cuahang_Ban.Text;
            _Rptware_Nhapxuatton.Parameters["Tungay"].Value = String.Format("{0:dd/MM/yyyy}", dtNgay_Batdau.EditValue);
            _Rptware_Nhapxuatton.Parameters["Denngay"].Value = String.Format("{0:dd/MM/yyyy}", dtNgay_Ketthuc.EditValue);
            DataSet DsCollection = objReportServices.Rptware_Nhapxuatton_Nguyenlieu(Convert.ToInt64(lookUpEdit_Cuahang_Ban.EditValue), dtNgay_Batdau.DateTime.Date, dtNgay_Ketthuc.DateTime.Date, lookUpEdit_Mahang.EditValue, lookUpEdit_Loai_Hanghoa.EditValue).ToDataSet();
            _Rptware_Nhapxuatton.DataSource = DsCollection;
            _Rptware_Nhapxuatton.xrTable_Ngay.Text = DateTime.Today.Day.ToString();
            _Rptware_Nhapxuatton.xrTable_Thang.Text = DateTime.Today.Month.ToString();
            _Rptware_Nhapxuatton.xrTable_Nam.Text = DateTime.Today.Year.ToString();
            _Rptware_Nhapxuatton.xrLabel_Title.Text = "BÁO CÁO NHẬP - XUẤT - TỒN NGUYÊN LIỆU ";
            //_FrmPrintPreview.printControl1.PrintingSystem = _Rptware_Nhapxuatton.PrintingSystem;
            _Rptware_Nhapxuatton.CreateDocument();
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_Rptware_Nhapxuatton);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                _FrmPrintPreview.printControl1.PrintingSystem = _Rptware_Nhapxuatton.PrintingSystem;
                _FrmPrintPreview.MdiParent = this.MdiParent;
                _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
            }
            else
            {
                var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_Rptware_Nhapxuatton);
                ReportPrintTool.Print();
            }
            _FrmPrintPreview.Show();
            _FrmPrintPreview.Activate();
        }

        private void Load_Rptware_Xuat_Luanchuyen_Chitiet()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            hashtableControls.Add(lookUpEdit_Cuahang_Ban, lblCuahang_Ban.Text);

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return;
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return;

            DataSet ds_Xuat_Chittiet = objWareService.Get_All_Ware_Hanghoa_Ban_Xuat_Luanchuyen_Chitiet(lookUpEdit_Cuahang_Ban.EditValue, dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, null, null).ToDataSet();
            Reports.XtraReports.rptWare_Xuatnhap_Luanchuyen_Chitiet _Rptware_Xuatnhap_Luanchuyen_Chitiet = new Ecm.Reports.XtraReports.rptWare_Xuatnhap_Luanchuyen_Chitiet();

            #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData
                });

                _Rptware_Xuatnhap_Luanchuyen_Chitiet.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _Rptware_Xuatnhap_Luanchuyen_Chitiet.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                _Rptware_Xuatnhap_Luanchuyen_Chitiet.xrPic_Logo.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }
            #endregion

            _Rptware_Xuatnhap_Luanchuyen_Chitiet.xrLabel_ReportName.Text = @"BÁO CÁO CHI TIẾT HÀNG XUẤT LUÂN CHUYỂN";
            _Rptware_Xuatnhap_Luanchuyen_Chitiet.xrTable_Kho.Text = lookUpEdit_Cuahang_Ban.Text;
            _Rptware_Xuatnhap_Luanchuyen_Chitiet.xrTable_Denngay.Text = DateTime.Parse(dtNgay_Ketthuc.EditValue.ToString()).ToString("dd/MM/yyyy");
            _Rptware_Xuatnhap_Luanchuyen_Chitiet.xrTable_Tungay.Text = DateTime.Parse(dtNgay_Batdau.EditValue.ToString()).ToString("dd/MM/yyyy");
            _Rptware_Xuatnhap_Luanchuyen_Chitiet.xrTable_Ngay.Text = DateTime.Today.Day.ToString();
            _Rptware_Xuatnhap_Luanchuyen_Chitiet.xrTable_Thang.Text = DateTime.Today.Month.ToString();
            _Rptware_Xuatnhap_Luanchuyen_Chitiet.xrTable_Nam.Text = DateTime.Today.Year.ToString();
            _Rptware_Xuatnhap_Luanchuyen_Chitiet.DataSource = ds_Xuat_Chittiet;

            GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            _FrmPrintPreview.Report = _Rptware_Xuatnhap_Luanchuyen_Chitiet;
            _Rptware_Xuatnhap_Luanchuyen_Chitiet.CreateDocument();
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_Rptware_Xuatnhap_Luanchuyen_Chitiet);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                _FrmPrintPreview.printControl1.PrintingSystem = _Rptware_Xuatnhap_Luanchuyen_Chitiet.PrintingSystem;
                _FrmPrintPreview.MdiParent = this.MdiParent;
                _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
            }
            else
            {
                var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_Rptware_Xuatnhap_Luanchuyen_Chitiet);
                ReportPrintTool.Print();
            }
            _FrmPrintPreview.Show();
            _FrmPrintPreview.Activate();
        }

        private void Load_Rptware_Xuat_Luanchuyen_Tonghop()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            hashtableControls.Add(lookUpEdit_Cuahang_Ban, lblCuahang_Ban.Text);


            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return;
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return;
            DataSet ds_Xuat_Chittiet = objWareService.Get_All_Ware_Hanghoa_Ban_Xuat_Luanchuyen_Tonghop(lookUpEdit_Cuahang_Ban.EditValue, dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, null, null).ToDataSet();
            Reports.XtraReports.rptWare_Xuatnhap_Luanchuyen_Tonghop _Rptware_Xuatnhap_Luanchuyen_Tonghop = new Ecm.Reports.XtraReports.rptWare_Xuatnhap_Luanchuyen_Tonghop();

            #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData
                });

                _Rptware_Xuatnhap_Luanchuyen_Tonghop.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _Rptware_Xuatnhap_Luanchuyen_Tonghop.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                _Rptware_Xuatnhap_Luanchuyen_Tonghop.xrPic_Logo.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }
            #endregion

            _Rptware_Xuatnhap_Luanchuyen_Tonghop.xrLabel_ReportName.Text = @"BÁO CÁO TỔNG HỢP HÀNG XUẤT LUÂN CHUYỂN";
            _Rptware_Xuatnhap_Luanchuyen_Tonghop.xrTable_Kho.Text = lookUpEdit_Cuahang_Ban.Text;
            _Rptware_Xuatnhap_Luanchuyen_Tonghop.xrTable_Denngay.Text = DateTime.Parse(dtNgay_Ketthuc.EditValue.ToString()).ToString("dd/MM/yyyy");
            _Rptware_Xuatnhap_Luanchuyen_Tonghop.xrTable_Tungay.Text = DateTime.Parse(dtNgay_Batdau.EditValue.ToString()).ToString("dd/MM/yyyy");

            _Rptware_Xuatnhap_Luanchuyen_Tonghop.xrTable_ngay.Text = DateTime.Today.Day.ToString();
            _Rptware_Xuatnhap_Luanchuyen_Tonghop.xrTable_Thang.Text = DateTime.Today.Month.ToString();
            _Rptware_Xuatnhap_Luanchuyen_Tonghop.xrTable_Nam.Text = DateTime.Today.Year.ToString();
            _Rptware_Xuatnhap_Luanchuyen_Tonghop.DataSource = ds_Xuat_Chittiet;

            GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            _FrmPrintPreview.Report = _Rptware_Xuatnhap_Luanchuyen_Tonghop;
            _Rptware_Xuatnhap_Luanchuyen_Tonghop.CreateDocument();
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_Rptware_Xuatnhap_Luanchuyen_Tonghop);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                _FrmPrintPreview.printControl1.PrintingSystem = _Rptware_Xuatnhap_Luanchuyen_Tonghop.PrintingSystem;
                _FrmPrintPreview.MdiParent = this.MdiParent;
                _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
            }
            else
            {
                var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_Rptware_Xuatnhap_Luanchuyen_Tonghop);
                ReportPrintTool.Print();
            }
            _FrmPrintPreview.Show();
            _FrmPrintPreview.Activate();
        }

        private void Load_Rptware_Nhap_Luanchuyen_Chitiet()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            hashtableControls.Add(lookUpEdit_Cuahang_Ban, lblCuahang_Ban.Text);
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return;
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return;

            DataSet ds_Xuat_Chittiet = objWareService.Get_All_Ware_Hanghoa_Ban_Nhap_Luanchuyen_Chitiet(lookUpEdit_Cuahang_Ban.EditValue, dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, null, null).ToDataSet();
            Reports.XtraReports.rptWare_Xuatnhap_Luanchuyen_Chitiet _Rptware_Xuatnhap_Luanchuyen_Chitiet = new Ecm.Reports.XtraReports.rptWare_Xuatnhap_Luanchuyen_Chitiet();

            #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData
                });

                _Rptware_Xuatnhap_Luanchuyen_Chitiet.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _Rptware_Xuatnhap_Luanchuyen_Chitiet.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                _Rptware_Xuatnhap_Luanchuyen_Chitiet.xrPic_Logo.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }
            #endregion

            _Rptware_Xuatnhap_Luanchuyen_Chitiet.xrTable_Kho.Text = lookUpEdit_Cuahang_Ban.Text;
            _Rptware_Xuatnhap_Luanchuyen_Chitiet.xrTable_Denngay.Text = DateTime.Parse(dtNgay_Ketthuc.EditValue.ToString()).ToString("dd/MM/yyyy");
            _Rptware_Xuatnhap_Luanchuyen_Chitiet.xrTable_Tungay.Text = DateTime.Parse(dtNgay_Batdau.EditValue.ToString()).ToString("dd/MM/yyyy");

            _Rptware_Xuatnhap_Luanchuyen_Chitiet.xrTable_Ngay.Text = DateTime.Today.Day.ToString();
            _Rptware_Xuatnhap_Luanchuyen_Chitiet.xrTable_Thang.Text = DateTime.Today.Month.ToString();
            _Rptware_Xuatnhap_Luanchuyen_Chitiet.xrTable_Nam.Text = DateTime.Today.Year.ToString();
            _Rptware_Xuatnhap_Luanchuyen_Chitiet.DataSource = ds_Xuat_Chittiet;
            GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            _FrmPrintPreview.Report = _Rptware_Xuatnhap_Luanchuyen_Chitiet;
            _Rptware_Xuatnhap_Luanchuyen_Chitiet.CreateDocument();
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_Rptware_Xuatnhap_Luanchuyen_Chitiet);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                _FrmPrintPreview.printControl1.PrintingSystem = _Rptware_Xuatnhap_Luanchuyen_Chitiet.PrintingSystem;
                _FrmPrintPreview.MdiParent = this.MdiParent;
                _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
            }
            else
            {
                var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_Rptware_Xuatnhap_Luanchuyen_Chitiet);
                ReportPrintTool.Print();
            }
            _FrmPrintPreview.Show();
            _Rptware_Xuatnhap_Luanchuyen_Chitiet.xrLabel_ReportName.Text = @"BÁO CÁO CHI TIẾT HÀNG NHẬP LUÂN CHUYỂN";
            _FrmPrintPreview.Activate();
        }

        private void Load_Rptware_Nhap_Luanchuyen_Tonghop()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            hashtableControls.Add(lookUpEdit_Cuahang_Ban, lblCuahang_Ban.Text);

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return;
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return;
            DataSet ds_Xuat_Chittiet = objWareService.Get_All_Ware_Hanghoa_Ban_Nhap_Luanchuyen_Tonghop(lookUpEdit_Cuahang_Ban.EditValue, dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, null, null).ToDataSet();
            Reports.XtraReports.rptWare_Xuatnhap_Luanchuyen_Tonghop _Rptware_Xuatnhap_Luanchuyen_Tonghop = new Ecm.Reports.XtraReports.rptWare_Xuatnhap_Luanchuyen_Tonghop();

            #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData
                });

                _Rptware_Xuatnhap_Luanchuyen_Tonghop.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _Rptware_Xuatnhap_Luanchuyen_Tonghop.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                _Rptware_Xuatnhap_Luanchuyen_Tonghop.xrPic_Logo.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }
            #endregion

            _Rptware_Xuatnhap_Luanchuyen_Tonghop.xrLabel_ReportName.Text = @"BÁO CÁO TỔNG HỢP HÀNG NHẬP LUÂN CHUYỂN";
            _Rptware_Xuatnhap_Luanchuyen_Tonghop.xrTable_Kho.Text = lookUpEdit_Cuahang_Ban.Text;
            _Rptware_Xuatnhap_Luanchuyen_Tonghop.xrTable_Denngay.Text = DateTime.Parse(dtNgay_Ketthuc.EditValue.ToString()).ToString("dd/MM/yyyy");
            _Rptware_Xuatnhap_Luanchuyen_Tonghop.xrTable_Tungay.Text = DateTime.Parse(dtNgay_Batdau.EditValue.ToString()).ToString("dd/MM/yyyy");

            _Rptware_Xuatnhap_Luanchuyen_Tonghop.xrTable_ngay.Text = DateTime.Today.Day.ToString();
            _Rptware_Xuatnhap_Luanchuyen_Tonghop.xrTable_Thang.Text = DateTime.Today.Month.ToString();
            _Rptware_Xuatnhap_Luanchuyen_Tonghop.xrTable_Nam.Text = DateTime.Today.Year.ToString();
            _Rptware_Xuatnhap_Luanchuyen_Tonghop.DataSource = ds_Xuat_Chittiet;

            GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            _FrmPrintPreview.Report = _Rptware_Xuatnhap_Luanchuyen_Tonghop;
            _Rptware_Xuatnhap_Luanchuyen_Tonghop.CreateDocument();
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_Rptware_Xuatnhap_Luanchuyen_Tonghop);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                _FrmPrintPreview.printControl1.PrintingSystem = _Rptware_Xuatnhap_Luanchuyen_Tonghop.PrintingSystem;
                _FrmPrintPreview.MdiParent = this.MdiParent;
                _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
            }
            else
            {
                var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_Rptware_Xuatnhap_Luanchuyen_Tonghop);
                ReportPrintTool.Print();
            }
            _FrmPrintPreview.Show();
            _FrmPrintPreview.Activate();
        }

        private void Load_Rptware_Nhaphang_Khachhang_Tra()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            hashtableControls.Add(lookUpEdit_Cuahang_Ban, lblCuahang_Ban.Text);

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return;
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return;


            //DataSet dsWare_Hh_Kh_Tra = objReportServices.RptWare_Hh_Kh_Tra(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, null, lookUpEdit_Cuahang_Ban.EditValue, null, null).ToDataSet();
            //Reports.XtraReports.rptWare_Xuatnhap_Khachhang_Tra _Rptware_Nhaphang_Khachhang_Tra = new Ecm.Reports.XtraReports.rptWare_Xuatnhap_Khachhang_Tra();

            //#region Thiết lập hệ số chương trình (Logo, thông tin công ty)
            //using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            //{
            //    DataSet dsCompany_Paras = new DataSet();
            //    dsCompany_Paras.Tables.Add("Company_Paras");
            //    dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
            //    dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
            //    dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

            //    byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

            //    dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
            //        dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
            //        ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
            //        ,imageData
            //    });

            //    _Rptware_Nhaphang_Khachhang_Tra.xrc_CompanyName.DataBindings.Add(
            //        new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
            //    _Rptware_Nhaphang_Khachhang_Tra.xrc_CompanyAddress.DataBindings.Add(
            //        new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
            //    _Rptware_Nhaphang_Khachhang_Tra.xrPic_Logo.DataBindings.Add(
            //        new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            //}
            //#endregion

            //_Rptware_Nhaphang_Khachhang_Tra.xrTable_Kho.Text = lookUpEdit_Cuahang_Ban.Text;
            //_Rptware_Nhaphang_Khachhang_Tra.xrTable_Denngay.Text = DateTime.Parse(dtNgay_Ketthuc.EditValue.ToString()).ToString("dd/MM/yyyy");
            //_Rptware_Nhaphang_Khachhang_Tra.xrTable_Tungay.Text = DateTime.Parse(dtNgay_Batdau.EditValue.ToString()).ToString("dd/MM/yyyy");

            //_Rptware_Nhaphang_Khachhang_Tra.xrTable_ngay.Text = DateTime.Today.Day.ToString();
            //_Rptware_Nhaphang_Khachhang_Tra.xrTable_Thang.Text = DateTime.Today.Month.ToString();
            //_Rptware_Nhaphang_Khachhang_Tra.xrTable_Nam.Text = DateTime.Today.Year.ToString();
            //_Rptware_Nhaphang_Khachhang_Tra.DataSource = dsWare_Hh_Kh_Tra;

            //GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            //_FrmPrintPreview.Report = _Rptware_Nhaphang_Khachhang_Tra;
            //_Rptware_Nhaphang_Khachhang_Tra.CreateDocument();
            //GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_Rptware_Nhaphang_Khachhang_Tra);
            //if (Convert.ToBoolean(oReportOptions.PrintPreview))
            //{
            //    _FrmPrintPreview.Text = "" + oReportOptions.Caption;
            //    _FrmPrintPreview.printControl1.PrintingSystem = _Rptware_Nhaphang_Khachhang_Tra.PrintingSystem;
            //    _FrmPrintPreview.MdiParent = this.MdiParent;
            //    _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
            //}
            //else
            //{
            //    var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_Rptware_Nhaphang_Khachhang_Tra);
            //    ReportPrintTool.Print();
            //}
            //_FrmPrintPreview.Show();
            //_FrmPrintPreview.Activate();
        }

        private void Load_Rptware_Xuathang_Tra_Nhacungcap()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            hashtableControls.Add(lookUpEdit_Cuahang_Ban, lblCuahang_Ban.Text);

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return;
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return;


            DataSet dsWare_Hh_Kh_Tra = new DataSet();// objWareService.Get_All_Ware_Xuathang_Tra_Nhacungcap(lookUpEdit_Cuahang_Ban.EditValue, dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, null, null).ToDataSet();
            Reports.XtraReports.rptWare_Xuatnhap_Tra_Nhacungcap _Rptware_Xuathang_Tra_Nhacungcap = new Ecm.Reports.XtraReports.rptWare_Xuatnhap_Tra_Nhacungcap();

            #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData
                });

                _Rptware_Xuathang_Tra_Nhacungcap.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _Rptware_Xuathang_Tra_Nhacungcap.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                _Rptware_Xuathang_Tra_Nhacungcap.xrPic_Logo.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }
            #endregion

            _Rptware_Xuathang_Tra_Nhacungcap.xrTable_Kho.Text = lookUpEdit_Cuahang_Ban.Text;
            _Rptware_Xuathang_Tra_Nhacungcap.xrTable_Denngay.Text = DateTime.Parse(dtNgay_Ketthuc.EditValue.ToString()).ToString("dd/MM/yyyy");
            _Rptware_Xuathang_Tra_Nhacungcap.xrTable_Tungay.Text = DateTime.Parse(dtNgay_Batdau.EditValue.ToString()).ToString("dd/MM/yyyy");

            _Rptware_Xuathang_Tra_Nhacungcap.xrTable_ngay.Text = DateTime.Today.Day.ToString();
            _Rptware_Xuathang_Tra_Nhacungcap.xrTable_Thang.Text = DateTime.Today.Month.ToString();
            _Rptware_Xuathang_Tra_Nhacungcap.xrTable_Nam.Text = DateTime.Today.Year.ToString();
            _Rptware_Xuathang_Tra_Nhacungcap.DataSource = dsWare_Hh_Kh_Tra;

            GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            _FrmPrintPreview.Report = _Rptware_Xuathang_Tra_Nhacungcap;
            _Rptware_Xuathang_Tra_Nhacungcap.CreateDocument();
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_Rptware_Xuathang_Tra_Nhacungcap);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                _FrmPrintPreview.printControl1.PrintingSystem = _Rptware_Xuathang_Tra_Nhacungcap.PrintingSystem;
                _FrmPrintPreview.MdiParent = this.MdiParent;
                _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
            }
            else
            {
                var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_Rptware_Xuathang_Tra_Nhacungcap);
                ReportPrintTool.Print();
            }
            _FrmPrintPreview.Show();
            _FrmPrintPreview.Activate();
        }

        private void Load_Rptware_Xuat_Chitiet()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            hashtableControls.Add(lookUpEdit_Cuahang_Ban, lblCuahang_Ban.Text);

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return;
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return;

            DataSet ds_Xuat_Chittiet = objWareService.Get_All_Ware_Xuat_Chitiet(lookUpEdit_Cuahang_Ban.EditValue, dtNgay_Batdau.DateTime.Date, dtNgay_Ketthuc.DateTime.Date, lookUpEdit_Mahang.EditValue, null).ToDataSet();
            Reports.XtraReports.rptWare_Xuatnhap_Chitiet _Rptware_Xuatnhap_Chitiet = new Ecm.Reports.XtraReports.rptWare_Xuatnhap_Chitiet();

            #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData
                });

                _Rptware_Xuatnhap_Chitiet.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _Rptware_Xuatnhap_Chitiet.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
            }
            #endregion

            _Rptware_Xuatnhap_Chitiet.xrLabel_ReportName.Text = @"SỔ CHI TIẾT XUẤT HÀNG";
            _Rptware_Xuatnhap_Chitiet.xrTable_Loaiphieu.Text = @"PHIẾU XUẤT";

            _Rptware_Xuatnhap_Chitiet.xrTable_Kho.Text = lookUpEdit_Cuahang_Ban.Text;
            _Rptware_Xuatnhap_Chitiet.xrTable_Denngay.Text = DateTime.Parse(dtNgay_Ketthuc.EditValue.ToString()).ToString("dd/MM/yyyy");
            _Rptware_Xuatnhap_Chitiet.xrTable_Tungay.Text = DateTime.Parse(dtNgay_Batdau.EditValue.ToString()).ToString("dd/MM/yyyy");
            _Rptware_Xuatnhap_Chitiet.xrTable_ngay.Text = DateTime.Today.Day.ToString();
            _Rptware_Xuatnhap_Chitiet.xrTable_Thang.Text = DateTime.Today.Month.ToString();
            _Rptware_Xuatnhap_Chitiet.xrTable_Nam.Text = DateTime.Today.Year.ToString();
            _Rptware_Xuatnhap_Chitiet.DataSource = ds_Xuat_Chittiet;
            _Rptware_Xuatnhap_Chitiet.CreateDocument();
            string path_file = @"Resources\repx\rptWare_Xuatnhap_Chitiet.repx";
            if (System.IO.File.Exists(path_file))
                System.IO.File.Delete(path_file);
            GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            _FrmPrintPreview.Report = _Rptware_Xuatnhap_Chitiet;
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_Rptware_Xuatnhap_Chitiet);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                _FrmPrintPreview.printControl1.PrintingSystem = _Rptware_Xuatnhap_Chitiet.PrintingSystem;
                _FrmPrintPreview.MdiParent = this.MdiParent;
                _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
                _FrmPrintPreview.Show();
                _FrmPrintPreview.Activate();
            }
            else
            {
                var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_Rptware_Xuatnhap_Chitiet);
                ReportPrintTool.Print();
            }
            _FrmPrintPreview.Show();
            _FrmPrintPreview.Activate();
        }

        private void Load_Rptware_Nhap_Chitiet()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            hashtableControls.Add(lookUpEdit_Cuahang_Ban, lblCuahang_Ban.Text);

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return;
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return;
            DataSet ds_Xuat_Chittiet = objWareService.Get_All_Ware_Nhap_Chitiet(lookUpEdit_Cuahang_Ban.EditValue, dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEdit_Mahang.EditValue, null).ToDataSet();
            Reports.XtraReports.rptWare_Xuatnhap_Chitiet _Rptware_Xuatnhap_Chitiet = new Ecm.Reports.XtraReports.rptWare_Xuatnhap_Chitiet();

            #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData
                });

                _Rptware_Xuatnhap_Chitiet.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _Rptware_Xuatnhap_Chitiet.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
            }
            #endregion
            _Rptware_Xuatnhap_Chitiet.xrLabel_ReportName.Text = @"SỔ CHI TIẾT NHẬP HÀNG";
            _Rptware_Xuatnhap_Chitiet.xrTable_Loaiphieu.Text = @"PHIẾU NHẬP";
            _Rptware_Xuatnhap_Chitiet.xrTable_Kho.Text = lookUpEdit_Cuahang_Ban.Text;
            _Rptware_Xuatnhap_Chitiet.xrTable_Denngay.Text = DateTime.Parse(dtNgay_Ketthuc.EditValue.ToString()).ToString("dd/MM/yyyy");
            _Rptware_Xuatnhap_Chitiet.xrTable_Tungay.Text = DateTime.Parse(dtNgay_Batdau.EditValue.ToString()).ToString("dd/MM/yyyy");
            _Rptware_Xuatnhap_Chitiet.xrTable_ngay.Text = DateTime.Today.Day.ToString();
            _Rptware_Xuatnhap_Chitiet.xrTable_Thang.Text = DateTime.Today.Month.ToString();
            _Rptware_Xuatnhap_Chitiet.xrTable_Nam.Text = DateTime.Today.Year.ToString();
            _Rptware_Xuatnhap_Chitiet.DataSource = ds_Xuat_Chittiet;
            _Rptware_Xuatnhap_Chitiet.CreateDocument();
            string path_file = @"Resources\repx\rptWare_Xuatnhap_Chitiet.repx";
            if (System.IO.File.Exists(path_file))
                System.IO.File.Delete(path_file);
            GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            _FrmPrintPreview.Report = _Rptware_Xuatnhap_Chitiet;
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_Rptware_Xuatnhap_Chitiet);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                _FrmPrintPreview.printControl1.PrintingSystem = _Rptware_Xuatnhap_Chitiet.PrintingSystem;
                _FrmPrintPreview.MdiParent = this.MdiParent;
                _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
            }
            else
            {
                var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_Rptware_Xuatnhap_Chitiet);
                ReportPrintTool.Print();
            }
            _FrmPrintPreview.Show();
            _FrmPrintPreview.Activate();
        }

        private void Load_Rptware_Xuat_Tonghop()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            hashtableControls.Add(lookUpEdit_Cuahang_Ban, lblCuahang_Ban.Text);
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return;
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return;

            DataSet ds_Xuat_Chittiet = objWareService.Get_All_Ware_Xuat_Tonghop(lookUpEdit_Cuahang_Ban.EditValue, dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEdit_Mahang.EditValue, null).ToDataSet();
            Reports.XtraReports.rptWare_Xuatnhap_Tonghop _Rptware_Xuatnhap_Tonghop = new Ecm.Reports.XtraReports.rptWare_Xuatnhap_Tonghop();

            #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData
                });

                _Rptware_Xuatnhap_Tonghop.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _Rptware_Xuatnhap_Tonghop.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
            }
            #endregion

            _Rptware_Xuatnhap_Tonghop.xrLabel_ReportName.Text = @"BÁO CÁO TỔNG HỢP HÀNG XUẤT";
            _Rptware_Xuatnhap_Tonghop.xrTable_Kho.Text = lookUpEdit_Cuahang_Ban.Text;
            _Rptware_Xuatnhap_Tonghop.xrTable_Denngay.Text = DateTime.Parse(dtNgay_Ketthuc.EditValue.ToString()).ToString("dd/MM/yyyy");
            _Rptware_Xuatnhap_Tonghop.xrTable_Tungay.Text = DateTime.Parse(dtNgay_Batdau.EditValue.ToString()).ToString("dd/MM/yyyy");
            _Rptware_Xuatnhap_Tonghop.xrTable_ngay.Text = DateTime.Today.Day.ToString();
            _Rptware_Xuatnhap_Tonghop.xrTable_Thang.Text = DateTime.Today.Month.ToString();
            _Rptware_Xuatnhap_Tonghop.xrTable_Nam.Text = DateTime.Today.Year.ToString();
            _Rptware_Xuatnhap_Tonghop.DataSource = ds_Xuat_Chittiet;
            string path_file = @"Resources\repx\rptWare_Xuatnhap_Tonghop.repx";
            if (System.IO.File.Exists(path_file))
                System.IO.File.Delete(path_file);
            GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            _FrmPrintPreview.Report = _Rptware_Xuatnhap_Tonghop;
            _Rptware_Xuatnhap_Tonghop.CreateDocument();
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_Rptware_Xuatnhap_Tonghop);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                _FrmPrintPreview.printControl1.PrintingSystem = _Rptware_Xuatnhap_Tonghop.PrintingSystem;
                _FrmPrintPreview.MdiParent = this.MdiParent;
                _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
                _FrmPrintPreview.Show();
                _FrmPrintPreview.Activate();
            }
            else
            {
                var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_Rptware_Xuatnhap_Tonghop);
                ReportPrintTool.Print();
            }
            _FrmPrintPreview.Show();
            _FrmPrintPreview.Activate();
        }

        private void Load_Rptware_Nhap_Tonghop()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            hashtableControls.Add(lookUpEdit_Cuahang_Ban, lblCuahang_Ban.Text);

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return;
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return;
            DataSet ds_Xuat_Chittiet = objWareService.Get_All_Ware_Nhap_Tonghop(lookUpEdit_Cuahang_Ban.EditValue, dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEdit_Mahang.EditValue, null).ToDataSet();
            Reports.XtraReports.rptWare_Xuatnhap_Tonghop _Rptware_Xuatnhap_Tonghop = new Ecm.Reports.XtraReports.rptWare_Xuatnhap_Tonghop();

            #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData
                });

                _Rptware_Xuatnhap_Tonghop.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _Rptware_Xuatnhap_Tonghop.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
            }
            #endregion

            _Rptware_Xuatnhap_Tonghop.xrLabel_ReportName.Text = @"BÁO CÁO TỔNG HỢP HÀNG NHẬP";

            _Rptware_Xuatnhap_Tonghop.xrTable_Kho.Text = lookUpEdit_Cuahang_Ban.Text;
            _Rptware_Xuatnhap_Tonghop.xrTable_Denngay.Text = DateTime.Parse(dtNgay_Ketthuc.EditValue.ToString()).ToString("dd/MM/yyyy");
            _Rptware_Xuatnhap_Tonghop.xrTable_Tungay.Text = DateTime.Parse(dtNgay_Batdau.EditValue.ToString()).ToString("dd/MM/yyyy");
            _Rptware_Xuatnhap_Tonghop.xrTable_ngay.Text = DateTime.Today.Day.ToString();
            _Rptware_Xuatnhap_Tonghop.xrTable_Thang.Text = DateTime.Today.Month.ToString();
            _Rptware_Xuatnhap_Tonghop.xrTable_Nam.Text = DateTime.Today.Year.ToString();
            _Rptware_Xuatnhap_Tonghop.DataSource = ds_Xuat_Chittiet;
            string path_file = @"Resources\repx\rptWare_Xuatnhap_Tonghop.repx";
            if (System.IO.File.Exists(path_file))
                System.IO.File.Delete(path_file);
            GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            _FrmPrintPreview.Report = _Rptware_Xuatnhap_Tonghop;
            _Rptware_Xuatnhap_Tonghop.CreateDocument();
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_Rptware_Xuatnhap_Tonghop);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                _FrmPrintPreview.printControl1.PrintingSystem = _Rptware_Xuatnhap_Tonghop.PrintingSystem;
                _FrmPrintPreview.MdiParent = this.MdiParent;
                _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
            }
            else
            {
                var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_Rptware_Xuatnhap_Tonghop);
                ReportPrintTool.Print();
            }
            _FrmPrintPreview.Show();
            _FrmPrintPreview.Activate();
        }

        protected void Loaddata()
        {
            //lookUpEdit_Cuahang_Ban.EditValue = null;
            //dtNgay_Batdau.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            //dtNgay_Ketthuc.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1);
            //lookUpEdit_Cuahang_Ban.Focus();
        }

        #endregion

        private void lookUpEdit1_Properties_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEdit_Tenhang.EditValue = lookUpEdit_Mahang.EditValue;
        }

        private void lookUpEdit_Mahang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                lookUpEdit_Mahang.EditValue = null;
        }

        private void navBar_Chitiet_Nhapxuat_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Xuatnhap_Chitiet_Nhapxuat _Rptware_Xuatnhap_Chitiet = new Ecm.Reports.XtraReports.rptWare_Xuatnhap_Chitiet_Nhapxuat();
            printControl_Baocao.PrintingSystem = _Rptware_Xuatnhap_Chitiet.PrintingSystem;
            #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData
                });

                _Rptware_Xuatnhap_Chitiet.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _Rptware_Xuatnhap_Chitiet.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
            }
            #endregion
            
            this.report = "Rptware_Nhapxuat_Chitiet";
            //_Rptware_Xuatnhap_Chitiet.xrLabel_ReportName.Text = @"BÁO CÁO CHI TIẾT HÀNG NHẬP XUẤT";
            //_Rptware_Xuatnhap_Chitiet.xrTable_Loaiphieu.Text = @"CHỨNG TỪ";
            _Rptware_Xuatnhap_Chitiet.CreateDocument();
            Loaddata();
        }

        private void Load_Rptware_Nhapxuat_Chitiet()
        {
            if (lookUpEdit_Mahang.EditValue == null)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn mặt hàng.", "Thông tin...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpEdit_Mahang.Focus();
                return;
            }

            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            hashtableControls.Add(lookUpEdit_Cuahang_Ban, lblCuahang_Ban.Text);

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return;
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return;
            DataSet ds_Xuat_Chittiet = objWareService.GetAll_Ware_Nhapxuat_Chitiet(lookUpEdit_Cuahang_Ban.EditValue, dtNgay_Batdau.DateTime.Date, dtNgay_Ketthuc.DateTime.Date, lookUpEdit_Mahang.EditValue, null).ToDataSet();
            Reports.XtraReports.rptWare_Xuatnhap_Chitiet_Nhapxuat _Rptware_Xuatnhap_Chitiet = new Ecm.Reports.XtraReports.rptWare_Xuatnhap_Chitiet_Nhapxuat();

            GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            _FrmPrintPreview.Report = _Rptware_Xuatnhap_Chitiet;

            #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData
                });

                _Rptware_Xuatnhap_Chitiet.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _Rptware_Xuatnhap_Chitiet.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
            }
            #endregion

            //_Rptware_Xuatnhap_Chitiet.xrLabel_ReportName.Text = @"BÁO CÁO CHI TIẾT HÀNG NHẬP XUẤT";
            //_Rptware_Xuatnhap_Chitiet.xrTable_Loaiphieu.Text = @"CHỨNG TỪ";
            _Rptware_Xuatnhap_Chitiet.xrTable_Kho.Text = lookUpEdit_Cuahang_Ban.Text;
            _Rptware_Xuatnhap_Chitiet.xrTable_Denngay.Text = DateTime.Parse(dtNgay_Ketthuc.EditValue.ToString()).ToString("dd/MM/yyyy");
            _Rptware_Xuatnhap_Chitiet.xrDate_From.Text = DateTime.Parse(dtNgay_Batdau.EditValue.ToString()).ToString("dd/MM/yyyy");
            _Rptware_Xuatnhap_Chitiet.xrTable_ngay.Text = DateTime.Today.Day.ToString();
            _Rptware_Xuatnhap_Chitiet.xrTable_thang.Text = DateTime.Today.Month.ToString();
            _Rptware_Xuatnhap_Chitiet.xrTable_nam.Text = DateTime.Today.Year.ToString();
            decimal toncuoi = ((Convert.ToDecimal("0" + ds_Xuat_Chittiet.Tables[0].Compute("Sum(Soluong_Nhap)", "")))
                                - Convert.ToDecimal("0" + ds_Xuat_Chittiet.Tables[0].Compute("Sum(Soluong_Xuat)", "")));
            //var a = objMasterService.ware_dm_donvitinh_quydoi_Text(lookUpEdit_Mahang.EditValue, lookUpEdit_Mahang.GetColumnValue("Id_Donvitinh"), toncuoi);
            _Rptware_Xuatnhap_Chitiet.xrTableCell_Ton_Cuoiky.Text = "" + objMasterService.ware_dm_donvitinh_quydoi_Text(lookUpEdit_Mahang.EditValue, lookUpEdit_Mahang.GetColumnValue("Id_Donvitinh"), toncuoi);
            _Rptware_Xuatnhap_Chitiet.DataSource = ds_Xuat_Chittiet;
            _Rptware_Xuatnhap_Chitiet.CreateDocument();
            //string path_file = @"Resources\repx\rptWare_Xuatnhap_Chitiet.repx";
            //if (System.IO.File.Exists(path_file))
            //    System.IO.File.Delete(path_file);

            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_Rptware_Xuatnhap_Chitiet);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                _FrmPrintPreview.printControl1.PrintingSystem = _Rptware_Xuatnhap_Chitiet.PrintingSystem;
                _FrmPrintPreview.MdiParent = this.MdiParent;
                _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
            }
            else
            {
                var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_Rptware_Xuatnhap_Chitiet);
                ReportPrintTool.Print();
            }
            _FrmPrintPreview.Show();
            _FrmPrintPreview.Activate();
        }

        private void lookUpEdit_MaNhomhang_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEdit_TenNHomHang.EditValue = lookUpEdit_Loai_Hanghoa.EditValue;
            if (lookUpEdit_Loai_Hanghoa.EditValue != null)
            {
                DataSet ds_collection = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban_By_Id_Loai_Hanghoa_Ban(lookUpEdit_TenNHomHang.EditValue).ToDataSet();
                lookUpEdit_Mahang.Properties.DataSource = ds_collection.Tables[0];
                lookUpEdit_Tenhang.Properties.DataSource = ds_collection.Tables[0];
            }
            else
            {
                DataSet ds_collection = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
                lookUpEdit_Mahang.Properties.DataSource = ds_collection.Tables[0];
                lookUpEdit_Tenhang.Properties.DataSource = ds_collection.Tables[0];
            }
        }

        private void lookUpEdit_MaNhomhang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                lookUpEdit_Loai_Hanghoa.EditValue = null;

            }
        }

        private void lookUpEdit_Cuahang_Ban_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                lookUpEdit_Cuahang_Ban.EditValue = null;
        }

        private void lookUpEditPhanloai_Nhom_Hanghoa_EditValueChanged(object sender, EventArgs e)
        {
            if ("" + lookUpEditPhanloai_Nhom_Hanghoa.Text != "")
            {
                DataSet ds_collection = objMasterService.Ware_Dm_Loai_Hanghoa_Ban_SelectBy_Id_Phanloai_HHban(lookUpEditPhanloai_Nhom_Hanghoa.EditValue).ToDataSet();
                lookUpEdit_Loai_Hanghoa.Properties.DataSource = ds_collection.Tables[0];
            }
        }

        private void lookUpEditPhanloai_Nhom_Hanghoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                lookUpEditPhanloai_Nhom_Hanghoa.EditValue = null;
        }

        private void navBarItem_Tonkho_NL_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Xuatnhap_Hangton _Rptware_Hangton = new Ecm.Reports.XtraReports.rptWare_Xuatnhap_Hangton();

            #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData
                });

                _Rptware_Hangton.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _Rptware_Hangton.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
            }
            #endregion
            _Rptware_Hangton.xrLabel_Title.Text = "BÁO CÁO NGUYÊN LIỆU TỒN";
            printControl_Baocao.PrintingSystem = _Rptware_Hangton.PrintingSystem;
            this.report = "Rptware_Hangton_NL";
            _Rptware_Hangton.CreateDocument();
            Loaddata();
        }

        private void navBarItem_NXT_NL_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Xuatnhap_Nhapxuatton _Rptware_Nhapxuatton = new Ecm.Reports.XtraReports.rptWare_Xuatnhap_Nhapxuatton();

            #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData
                });

                _Rptware_Nhapxuatton.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _Rptware_Nhapxuatton.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
            }
            #endregion
            _Rptware_Nhapxuatton.xrLabel_Title.Text = "BÁO CÁO NHẬP - XUẤT - TỒN NGUYÊN LIỆU ";
            printControl_Baocao.PrintingSystem = _Rptware_Nhapxuatton.PrintingSystem;
            this.report = "Rptware_Nhapxuatton_NL";
            _Rptware_Nhapxuatton.CreateDocument();
            Loaddata();
        }

    }
}

