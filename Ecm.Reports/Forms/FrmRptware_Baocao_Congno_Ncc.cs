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
    public partial class FrmRptware_Baocao_Congno_Ncc : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        string report = "";
        public Ecm.WebReferences.Classes.WareService objWareService = new Ecm.WebReferences.Classes.WareService();
        Ecm.WebReferences.Classes.MasterService objMasterService = new Ecm.WebReferences.Classes.MasterService();
        Ecm.WebReferences.Classes.ReportService objReportService = new Ecm.WebReferences.Classes.ReportService();

        public FrmRptware_Baocao_Congno_Ncc()
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

            //lookUp_Loai_Hanghoa_Ban.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler( GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            lookUpEditTen_Ncc.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            //lookUpEdit_Hanghoa_Ban.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler( GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            lookUpEdit_Cuahang_Ban.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            DisplayInfo();
        }

        #region Override Method
        public override void DisplayInfo()
        {
            try
            {
                DataSet ds_collection = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
                lookUpEdit_Mahang.Properties.DataSource = ds_collection.Tables[0];
                lookUpEdit_Tenhang.Properties.DataSource = ds_collection.Tables[0];

                lookUpEdit_Cuahang_Ban.Properties.DataSource = objMasterService.Ware_Dm_Cuahang_Ban_Select_Kho().ToDataSet().Tables[0];
                DataTable dtb = objMasterService.Get_All_Ware_Dm_Nhacungcap().ToDataSet().Tables[0];
                lookUpEditMa_Ncc.Properties.DataSource = dtb;
                lookUpEditTen_Ncc.Properties.DataSource = dtb;
                //lookUpEdit_Hanghoa_Ban.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().Tables[0];
                //lookUp_Loai_Hanghoa_Ban.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Ban().Tables[0];

                dtNgay_Batdau.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1, 0, 0, 1);
                dtNgay_Ketthuc.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1, 23, 59, 59).AddMonths(1).AddDays(-1);
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
#endif
            }
        }

        public override bool PerformQuery()
        {
            try
            {
                switch (report)
                {
                    case "rptWare_Banhang_Congno_Tonghop":
                        Load_Rptware_Banhang_Congno_Tonghop();
                        break;

                    case "rptWare_Congno_Chitiet":
                        Load_rptWare_Congno_Chitiet();
                        break;

                    case "Rptware_Nhap_Chitiet":
                        Load_Rptware_Nhap_Chitiet();
                        break;

                    default:
                        GoobizFrame.Windows.Forms.MessageDialog.Show("Vui lòng chọn loại báo cáo.", "Thông tin...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
#endif
                return false;
            }
            return base.PerformQuery();
        }
        #endregion

        #region Event

        private void navItem_Tonghop_Congno_Phaitra_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Banhang_Congno_Tonghop _rptWare_Banhang_Congno_Tonghop = new Ecm.Reports.XtraReports.rptWare_Banhang_Congno_Tonghop();
            this.report = "rptWare_Banhang_Congno_Tonghop";
            setHesoChuongtrinh(_rptWare_Banhang_Congno_Tonghop.xrc_CompanyName, _rptWare_Banhang_Congno_Tonghop.xrc_CompanyAddress, null);
            printControl_Baocao.PrintingSystem = _rptWare_Banhang_Congno_Tonghop.PrintingSystem;
            _rptWare_Banhang_Congno_Tonghop.xrTableCell_Ma.Text = "Mã NCC";
            _rptWare_Banhang_Congno_Tonghop.xrTableCell_Ten.Text = "Tên Nhà cung cấp";
            _rptWare_Banhang_Congno_Tonghop.CreateDocument();
        }

        private void navItem_Chitiet_Tienmuahang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Banhang_Chitiet _rptWare_Banhang_Chitiet = new Ecm.Reports.XtraReports.rptWare_Banhang_Chitiet();
            setHesoChuongtrinh(_rptWare_Banhang_Chitiet.xrc_CompanyName, _rptWare_Banhang_Chitiet.xrc_CompanyAddress, null);
            printControl_Baocao.PrintingSystem = _rptWare_Banhang_Chitiet.PrintingSystem;
            this.report = "rptWare_Banhang_Chitiet";
            _rptWare_Banhang_Chitiet.CreateDocument();
        }

        private void navItem_Chitiet_Tienxuat_Trahang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Banhang_Nhaptra_Chitiet rpt_Nhaptra_Chitiet = new Ecm.Reports.XtraReports.rptWare_Banhang_Nhaptra_Chitiet();
            setHesoChuongtrinh(rpt_Nhaptra_Chitiet.xrc_CompanyName, rpt_Nhaptra_Chitiet.xrc_CompanyAddress, rpt_Nhaptra_Chitiet.xrPic_Logo);
            printControl_Baocao.PrintingSystem = rpt_Nhaptra_Chitiet.PrintingSystem;
            this.report = "rptWare_Banhang_Nhaptra_Chitiet";
            rpt_Nhaptra_Chitiet.CreateDocument();
        }

        private void navItem_Chitiet_Tientra_Congno_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Banhang_Congno_Thu _rptWare_Banhang_Congno_Thu = new Ecm.Reports.XtraReports.rptWare_Banhang_Congno_Thu();
            setHesoChuongtrinh(_rptWare_Banhang_Congno_Thu.xrc_CompanyName, _rptWare_Banhang_Congno_Thu.xrc_CompanyAddress, _rptWare_Banhang_Congno_Thu.xrPic_Logo);
            printControl_Baocao.PrintingSystem = _rptWare_Banhang_Congno_Thu.PrintingSystem;
            this.report = "rptWare_Banhang_Congno_Thu";
            _rptWare_Banhang_Congno_Thu.CreateDocument();
        }

        private void navItem_Danhsach_Chungtu_Congno_Chuathu_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Banhang_Congno_Chuathu _rptWare_Banhang_Congno_Chuathu = new Ecm.Reports.XtraReports.rptWare_Banhang_Congno_Chuathu();
            setHesoChuongtrinh(_rptWare_Banhang_Congno_Chuathu.xrc_CompanyName, _rptWare_Banhang_Congno_Chuathu.xrc_CompanyAddress, _rptWare_Banhang_Congno_Chuathu.xrPic_Logo);
            printControl_Baocao.PrintingSystem = _rptWare_Banhang_Congno_Chuathu.PrintingSystem;
            this.report = "rptWare_Banhang_Congno_Chuathu";
            _rptWare_Banhang_Congno_Chuathu.CreateDocument();
        }

        #endregion

        #region Custom Moethod

        void setNgay_Thang_Nam(DevExpress.XtraReports.UI.XRTableCell ngay, DevExpress.XtraReports.UI.XRTableCell thang, DevExpress.XtraReports.UI.XRTableCell nam)
        {
            ngay.Text = DateTime.Now.Day.ToString();
            thang.Text = DateTime.Now.Month.ToString();
            nam.Text = DateTime.Now.Year.ToString();
        }

        void setHesoChuongtrinh(DevExpress.XtraReports.UI.XRTableCell companyName,
           DevExpress.XtraReports.UI.XRTableCell companyAddress, DevExpress.XtraReports.UI.XRPictureBox companyLogo)
        {
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

                companyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                companyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                //companyLogo.DataBindings.Add(
                //    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }
        }

        private void Load_Rptware_Banhang_Congno_Tonghop()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            //hashtableControls.Add(lookUpEditCuahang_Ban, lblCuahang_Ban.Text);

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return;

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return;

            XtraReports.rptWare_Banhang_Congno_Tonghop _rptWare_Banhang_Congno_Tonghop = new Ecm.Reports.XtraReports.rptWare_Banhang_Congno_Tonghop();

            // Thiết lập hệ số chương trình (Logo, thông tin công ty)
            DataSet dsReport = objReportService.Rptware_Banhang_Congno_Tonghop_Ncc(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEditTen_Ncc.EditValue).ToDataSet();
            _rptWare_Banhang_Congno_Tonghop.DataSource = dsReport;
            GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            _FrmPrintPreview.Report = _rptWare_Banhang_Congno_Tonghop;
            setHesoChuongtrinh(_rptWare_Banhang_Congno_Tonghop.xrc_CompanyName, _rptWare_Banhang_Congno_Tonghop.xrc_CompanyAddress, null);
            _rptWare_Banhang_Congno_Tonghop.xrTableCell_DateFrom.Text = dtNgay_Batdau.Text;
            _rptWare_Banhang_Congno_Tonghop.xrTableCell_DateTo.Text = dtNgay_Ketthuc.Text;
            _rptWare_Banhang_Congno_Tonghop.xrTableCell_Ma.Text = "Mã NCC";
            _rptWare_Banhang_Congno_Tonghop.xrTableCell_Ten.Text = "Tên Nhà cung cấp";
            _rptWare_Banhang_Congno_Tonghop.xrTable_Ngay.Text = DateTime.Today.Day.ToString();
            _rptWare_Banhang_Congno_Tonghop.xrTable_Thang.Text = DateTime.Today.Month.ToString();
            _rptWare_Banhang_Congno_Tonghop.xrTable_Nam.Text = DateTime.Today.Year.ToString();
            _rptWare_Banhang_Congno_Tonghop.CreateDocument();
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_rptWare_Banhang_Congno_Tonghop);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                _FrmPrintPreview.printControl1.PrintingSystem = _rptWare_Banhang_Congno_Tonghop.PrintingSystem;
                _FrmPrintPreview.MdiParent = this.MdiParent;
                _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
                _FrmPrintPreview.Show();
                _FrmPrintPreview.Activate();
            }
            else
            {
                var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_rptWare_Banhang_Congno_Tonghop);
                ReportPrintTool.Print();
            }
            _FrmPrintPreview.Show();
            _FrmPrintPreview.Activate();
        }

        //công nợ chi tiết
        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Congno_Chitiet _rptWare_Congno_Chitiet = new Ecm.Reports.XtraReports.rptWare_Congno_Chitiet();
            this.report = "rptWare_Congno_Chitiet";
            setHesoChuongtrinh(_rptWare_Congno_Chitiet.xrc_CompanyName, _rptWare_Congno_Chitiet.xrc_CompanyAddress, null);
            printControl_Baocao.PrintingSystem = _rptWare_Congno_Chitiet.PrintingSystem;
            _rptWare_Congno_Chitiet.xrTableCell_KH.Text = "Tên NCC";
            _rptWare_Congno_Chitiet.CreateDocument();
        }

        private void Load_rptWare_Congno_Chitiet()
        {
            try
            {
                System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
                hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
                hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
                hashtableControls.Add(lookUpEditMa_Ncc, lblDoituong.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return;

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                    return;

                DataSet ds_Congnothu = objReportService.RptCongno_NCC_Chitiet(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEditTen_Ncc.EditValue).ToDataSet();
                Ecm.Reports.XtraReports.rptWare_Congno_Chitiet _rptWare_Congno_Chitiet = new Ecm.Reports.XtraReports.rptWare_Congno_Chitiet();
                _rptWare_Congno_Chitiet.DataSource = ds_Congnothu;
                GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
                _FrmPrintPreview.Report = _rptWare_Congno_Chitiet;
                // Thiết lập hệ số chương trình (Logo, thông tin công ty)
                setHesoChuongtrinh(_rptWare_Congno_Chitiet.xrc_CompanyName, _rptWare_Congno_Chitiet.xrc_CompanyAddress, null);
                _rptWare_Congno_Chitiet.xrDate_From.Text = dtNgay_Batdau.DateTime.ToString("dd/MM/yyyy");
                _rptWare_Congno_Chitiet.xrDate_To.Text = dtNgay_Ketthuc.DateTime.ToString("dd/MM/yyyy");
                _rptWare_Congno_Chitiet.xrTableCell_TenKH.Text = lookUpEditTen_Ncc.Text + " - " + lookUpEditMa_Ncc.Text;
                _rptWare_Congno_Chitiet.xrTableCell_Dienthoai.Text = lookUpEditMa_Ncc.GetColumnValue("Dienthoai").ToString();
                _rptWare_Congno_Chitiet.xrTableCell_Diachi.Text = lookUpEditMa_Ncc.GetColumnValue("Diachi_Nhacungcap").ToString();
                _rptWare_Congno_Chitiet.xrTableCell_KH.Text = "Tên NCC";
                _rptWare_Congno_Chitiet.xrTable_Ngay.Text = DateTime.Today.Day.ToString();
                _rptWare_Congno_Chitiet.xrTable_Thang.Text = DateTime.Today.Month.ToString();
                _rptWare_Congno_Chitiet.xrTable_Nam.Text = DateTime.Today.Year.ToString();
                _rptWare_Congno_Chitiet.CreateDocument();
                GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_rptWare_Congno_Chitiet);
                if (Convert.ToBoolean(oReportOptions.PrintPreview))
                {
                    _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                    _FrmPrintPreview.printControl1.PrintingSystem = _rptWare_Congno_Chitiet.PrintingSystem;
                    _FrmPrintPreview.MdiParent = this.MdiParent;
                    _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
                    _FrmPrintPreview.Show();
                    _FrmPrintPreview.Activate();
                }
                else
                {
                    var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_rptWare_Congno_Chitiet);
                    ReportPrintTool.Print();
                }
                _FrmPrintPreview.Show();
                _FrmPrintPreview.Activate();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }

        #endregion

        private void lookUpEditCuahang_Ban_EditValueChanged(object sender, EventArgs e)
        {
            //lookUpEditTen_Ncc.Properties.DataSource = objMasterService.Ware_Dm_Khachhang_SelectBy_Khuvuc(lookUpEditCuahang_Ban.EditValue).ToDataSet().Tables[0];
            //lookUpEditMa_Ncc.Properties.DataSource = objMasterService.Ware_Dm_Khachhang_SelectBy_Khuvuc(lookUpEditCuahang_Ban.EditValue).ToDataSet().Tables[0];
        }

        private void lookUpEdit_Khachhang_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditTen_Ncc.EditValue = lookUpEditMa_Ncc.EditValue;
        }

        private void lookUpEdit_Khachhang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                lookUpEditMa_Ncc.EditValue = null;
        }

        private void navBarItem_Hangnhap_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
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

        private void lookUpEdit_Mahang_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEdit_Tenhang.EditValue = lookUpEdit_Mahang.EditValue;
        }

        private void lookUpEdit_Mahang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                lookUpEdit_Mahang.EditValue = null;
        }

    }
}

