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
    public partial class FrmRptware_Baocao_Congno : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        string report = "";
        public Ecm.WebReferences.Classes.WareService objWareService = new Ecm.WebReferences.Classes.WareService();
        Ecm.WebReferences.Classes.MasterService objMasterService = new Ecm.WebReferences.Classes.MasterService();
        Ecm.WebReferences.Classes.ReportService objReportService = new Ecm.WebReferences.Classes.ReportService();

        public FrmRptware_Baocao_Congno()
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
            lookUpEdit_TenKH.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            //lookUpEdit_Hanghoa_Ban.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler( GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            lookUpEditCuahang_Ban.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                lookUpEditCuahang_Ban.Properties.DataSource = objMasterService.Ware_Dm_Cuahang_Ban_Select_Sale().ToDataSet().Tables[0];
                DataTable dtb = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet().Tables[0];
                lookUpEdit_Khachhang.Properties.DataSource = dtb;
                lookUpEdit_TenKH.Properties.DataSource = dtb;
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

        #region Event

        private void navItem_Tonghop_Congno_Phaitra_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Banhang_Congno_Tonghop _rptWare_Banhang_Congno_Tonghop = new Ecm.Reports.XtraReports.rptWare_Banhang_Congno_Tonghop();
            this.report = "rptWare_Banhang_Congno_Tonghop";
            setHesoChuongtrinh(_rptWare_Banhang_Congno_Tonghop.xrc_CompanyName, _rptWare_Banhang_Congno_Tonghop.xrc_CompanyAddress, null);
            printControl_Baocao.PrintingSystem = _rptWare_Banhang_Congno_Tonghop.PrintingSystem;
            _rptWare_Banhang_Congno_Tonghop.CreateDocument();
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

        private void Load_rptWare_Banhang_Congno_Thu()
        {
            try
            {
                System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
                hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
                hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return;

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                    return;

                DataSet ds_Congnothu = objWareService.Get_RptWare_Banhang_Congno_Thu(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEdit_TenKH.EditValue).ToDataSet();
                Ecm.Reports.XtraReports.rptWare_Banhang_Congno_Thu _rptWare_Banhang_Congno_Thu = new Ecm.Reports.XtraReports.rptWare_Banhang_Congno_Thu();

                // Thiết lập hệ số chương trình (Logo, thông tin công ty)
                setHesoChuongtrinh(_rptWare_Banhang_Congno_Thu.xrc_CompanyName, _rptWare_Banhang_Congno_Thu.xrc_CompanyAddress, _rptWare_Banhang_Congno_Thu.xrPic_Logo);
                _rptWare_Banhang_Congno_Thu.xrTable_tungay.Text = dtNgay_Batdau.DateTime.ToString("dd/MM/yyyy");
                _rptWare_Banhang_Congno_Thu.xrTable_Denngay.Text = dtNgay_Ketthuc.DateTime.ToString("dd/MM/yyyy");

                _rptWare_Banhang_Congno_Thu.xrTable_Ngay.Text = DateTime.Today.Day.ToString();
                _rptWare_Banhang_Congno_Thu.xrTable_Thang.Text = DateTime.Today.Month.ToString();
                _rptWare_Banhang_Congno_Thu.xrTable_Nam.Text = DateTime.Today.Year.ToString();
                _rptWare_Banhang_Congno_Thu.DataSource = ds_Congnothu;
                GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
                _FrmPrintPreview.Report = _rptWare_Banhang_Congno_Thu;
                _rptWare_Banhang_Congno_Thu.CreateDocument();
                GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_rptWare_Banhang_Congno_Thu);
                if (Convert.ToBoolean(oReportOptions.PrintPreview))
                {
                    _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                    _FrmPrintPreview.printControl1.PrintingSystem = _rptWare_Banhang_Congno_Thu.PrintingSystem;
                    _FrmPrintPreview.MdiParent = this.MdiParent;
                    _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
                    _FrmPrintPreview.Show();
                    _FrmPrintPreview.Activate();
                }
                else
                {
                    var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_rptWare_Banhang_Congno_Thu);
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
            GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            _FrmPrintPreview.Report = _rptWare_Banhang_Congno_Tonghop;
            // Thiết lập hệ số chương trình (Logo, thông tin công ty)
            setHesoChuongtrinh(_rptWare_Banhang_Congno_Tonghop.xrc_CompanyName, _rptWare_Banhang_Congno_Tonghop.xrc_CompanyAddress, null);
            DataSet dsReport = objReportService.Rptware_Banhang_Congno_Tonghop_Khuvuc_New(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEdit_Khachhang.Text, lookUpEditCuahang_Ban.EditValue).ToDataSet();
            _rptWare_Banhang_Congno_Tonghop.DataSource = dsReport;
            _rptWare_Banhang_Congno_Tonghop.xrTableCell_DateFrom.Text = dtNgay_Batdau.Text;
            _rptWare_Banhang_Congno_Tonghop.xrTableCell_DateTo.Text = dtNgay_Ketthuc.Text;

           
            _rptWare_Banhang_Congno_Tonghop.xrTable_Ngay.Text = DateTime.Today.Day.ToString();
            _rptWare_Banhang_Congno_Tonghop.xrTable_Thang.Text = DateTime.Today.Month.ToString();
            _rptWare_Banhang_Congno_Tonghop.xrTable_Nam.Text = DateTime.Today.Year.ToString();

            //setNgay_Thang_Nam(_rptWare_Banhang_Congno_Tonghop.xrTable_Ngay, _rptWare_Banhang_Congno_Tonghop.xrTable_Thang, _rptWare_Banhang_Congno_Tonghop.xrTable_Nam);

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

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Congno_Chitiet _rptWare_Congno_Chitiet = new Ecm.Reports.XtraReports.rptWare_Congno_Chitiet();
            this.report = "rptWare_Congno_Chitiet";
            setHesoChuongtrinh(_rptWare_Congno_Chitiet.xrc_CompanyName, _rptWare_Congno_Chitiet.xrc_CompanyAddress, null);
            printControl_Baocao.PrintingSystem = _rptWare_Congno_Chitiet.PrintingSystem;
            _rptWare_Congno_Chitiet.CreateDocument();
        }

        private void Load_rptWare_Congno_Chitiet()
        {
            try
            {
                System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
                hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
                hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
                hashtableControls.Add(lookUpEdit_Khachhang, lblDoituong.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return;

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                    return;

                DataSet ds_Congnothu = objReportService.Rpt_Congno_Chitiet_New2(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEdit_Khachhang.Text).ToDataSet();
                Ecm.Reports.XtraReports.rptWare_Congno_Chitiet _rptWare_Congno_Chitiet = new Ecm.Reports.XtraReports.rptWare_Congno_Chitiet();
                _rptWare_Congno_Chitiet.DataSource = ds_Congnothu;
                GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
                _FrmPrintPreview.Report = _rptWare_Congno_Chitiet;
                // Thiết lập hệ số chương trình (Logo, thông tin công ty)
                setHesoChuongtrinh(_rptWare_Congno_Chitiet.xrc_CompanyName, _rptWare_Congno_Chitiet.xrc_CompanyAddress, null);
                _rptWare_Congno_Chitiet.xrDate_From.Text = dtNgay_Batdau.DateTime.ToString("dd/MM/yyyy");
                _rptWare_Congno_Chitiet.xrDate_To.Text = dtNgay_Ketthuc.DateTime.ToString("dd/MM/yyyy");
                _rptWare_Congno_Chitiet.xrTableCell_TenKH.Text = lookUpEdit_TenKH.Text + " - " + lookUpEdit_Khachhang.Text;
                _rptWare_Congno_Chitiet.xrTableCell_Dienthoai.Text = lookUpEdit_Khachhang.GetColumnValue("Dienthoai").ToString();
                _rptWare_Congno_Chitiet.xrTableCell_Diachi.Text = lookUpEdit_Khachhang.GetColumnValue("Diachi_Khachhang").ToString();


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
            lookUpEdit_TenKH.Properties.DataSource = objMasterService.Ware_Dm_Khachhang_SelectBy_Khuvuc(lookUpEditCuahang_Ban.EditValue).ToDataSet().Tables[0];
            lookUpEdit_Khachhang.Properties.DataSource = objMasterService.Ware_Dm_Khachhang_SelectBy_Khuvuc(lookUpEditCuahang_Ban.EditValue).ToDataSet().Tables[0];
        }

        private void lookUpEdit_Khachhang_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEdit_TenKH.EditValue = lookUpEdit_Khachhang.EditValue;
        }

        private void lookUpEdit_Khachhang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                lookUpEdit_Khachhang.EditValue = null;
        }

        private void lookUpEditCuahang_Ban_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                lookUpEditCuahang_Ban.EditValue = null;
        }
    }
}

