using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;

namespace Ecm.Reports.Forms
{
    public partial class FrmRptware_Baocao_Tonghop :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {

        string report = "";
        public Ecm.WebReferences.Classes.WareService objWareService = new Ecm.WebReferences.Classes.WareService();
        Ecm.WebReferences.Classes.MasterService objMasterService = new Ecm.WebReferences.Classes.MasterService();
        Ecm.WebReferences.Classes.ReportService objReportService = new Ecm.WebReferences.Classes.ReportService();
  
        public FrmRptware_Baocao_Tonghop()
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

            DisplayInfo();
        }


        #region Override Method
    
        public override void DisplayInfo()
        {
            try
            {
                dtNgay_Batdau.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                dtNgay_Ketthuc.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1);
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
                    case "rptWare_Tonghop_Hoadon_Banhang_Thue":
                        Load_RptWare_Tonghop_Hoadon_Banhang_Thue();
                        break;
                    case "rptWare_Tonghop_Hoadon_Muahang_Thue":
                        Load_Rptware_Tonghop_Hoadon_Muahang_Thue();
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


        private void navItem_Tonghop_Hoadon_Muahang_Thue_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            XtraReports.rptWare_Tonghop_Hoadon_Muahang_Thue _rptWare_Tonghop_Hoadon_Muahang_Thue = new Ecm.Reports.XtraReports.rptWare_Tonghop_Hoadon_Muahang_Thue();
            setHesoChuongtrinh(_rptWare_Tonghop_Hoadon_Muahang_Thue.xrc_CompanyName, _rptWare_Tonghop_Hoadon_Muahang_Thue.xrc_CompanyAddress, _rptWare_Tonghop_Hoadon_Muahang_Thue.xrPic_Logo);
            printControl_Baocao.PrintingSystem = _rptWare_Tonghop_Hoadon_Muahang_Thue.PrintingSystem;
            this.report = "rptWare_Tonghop_Hoadon_Muahang_Thue";
            _rptWare_Tonghop_Hoadon_Muahang_Thue.CreateDocument();
        }

        private void navItem_Tonghop_Hoadon_Banhang_Thue_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            XtraReports.rptWare_Tonghop_Hoadon_Banhang_Thue _rptWare_Tonghop_Hoadon_Banhang_Thue = new Ecm.Reports.XtraReports.rptWare_Tonghop_Hoadon_Banhang_Thue();
            setHesoChuongtrinh(_rptWare_Tonghop_Hoadon_Banhang_Thue.xrc_CompanyName, _rptWare_Tonghop_Hoadon_Banhang_Thue.xrc_CompanyAddress, _rptWare_Tonghop_Hoadon_Banhang_Thue.xrPic_Logo);
            printControl_Baocao.PrintingSystem = _rptWare_Tonghop_Hoadon_Banhang_Thue.PrintingSystem;
            this.report = "rptWare_Tonghop_Hoadon_Banhang_Thue";
            _rptWare_Tonghop_Hoadon_Banhang_Thue.CreateDocument();
        }
 
        #endregion

        #region Custom Moethod

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
                companyLogo.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }
        }

        private void Load_RptWare_Tonghop_Hoadon_Banhang_Thue()
        {
            try
            {
                System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
                hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
                hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return;
                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                    return;
                DataSet ds_Congnothu = objWareService.Get_RptWare_Tonghop_Hoadon_Banhang_Thue(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.DateTime.AddHours(23).AddMinutes(59).AddSeconds(59)).ToDataSet();
                Ecm.Reports.XtraReports.rptWare_Tonghop_Hoadon_Banhang_Thue _rptWare_Tonghop_Hoadon_Banhang_Thue = new Ecm.Reports.XtraReports.rptWare_Tonghop_Hoadon_Banhang_Thue();
                setHesoChuongtrinh(_rptWare_Tonghop_Hoadon_Banhang_Thue.xrc_CompanyName, _rptWare_Tonghop_Hoadon_Banhang_Thue.xrc_CompanyAddress, _rptWare_Tonghop_Hoadon_Banhang_Thue.xrPic_Logo);
                // Thiết lập hệ số chương trình (Logo, thông tin công ty)
                _rptWare_Tonghop_Hoadon_Banhang_Thue.Parameters["Tungay"].Value = dtNgay_Batdau.Text;
                _rptWare_Tonghop_Hoadon_Banhang_Thue.Parameters["Denngay"].Value = dtNgay_Ketthuc.Text; 
                _rptWare_Tonghop_Hoadon_Banhang_Thue.DataSource = ds_Congnothu;
                GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
                _FrmPrintPreview.Report = _rptWare_Tonghop_Hoadon_Banhang_Thue;
                _rptWare_Tonghop_Hoadon_Banhang_Thue.CreateDocument();
                GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_rptWare_Tonghop_Hoadon_Banhang_Thue);
                if (Convert.ToBoolean(oReportOptions.PrintPreview))
                {
                    _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                    _FrmPrintPreview.printControl1.PrintingSystem = _rptWare_Tonghop_Hoadon_Banhang_Thue.PrintingSystem;
                    _FrmPrintPreview.MdiParent = this.MdiParent;
                    _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
                    _FrmPrintPreview.Show();
                    _FrmPrintPreview.Activate();
                }
                else
                {
                    var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_rptWare_Tonghop_Hoadon_Banhang_Thue);
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

        private void Load_Rptware_Tonghop_Hoadon_Muahang_Thue()
        {
            try
            {
                System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
                hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
                hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return;
                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                    return;
                DataSet dsReport = objReportService.Rptware_Tonghop_Hoadon_Muahang_Thue(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.DateTime.AddHours(23).AddMinutes(59).AddSeconds(59)).ToDataSet();
                Ecm.Reports.XtraReports.rptWare_Tonghop_Hoadon_Muahang_Thue _rptWare_Tonghop_Hoadon_Muahang_Thue = new Ecm.Reports.XtraReports.rptWare_Tonghop_Hoadon_Muahang_Thue();

                setHesoChuongtrinh(_rptWare_Tonghop_Hoadon_Muahang_Thue.xrc_CompanyName, _rptWare_Tonghop_Hoadon_Muahang_Thue.xrc_CompanyAddress, _rptWare_Tonghop_Hoadon_Muahang_Thue.xrPic_Logo);

                // Thiết lập hệ số chương trình (Logo, thông tin công ty)
                _rptWare_Tonghop_Hoadon_Muahang_Thue.Parameters["Tungay"].Value = dtNgay_Batdau.Text;
                _rptWare_Tonghop_Hoadon_Muahang_Thue.Parameters["Denngay"].Value = dtNgay_Ketthuc.Text;
                _rptWare_Tonghop_Hoadon_Muahang_Thue.DataSource = dsReport;
                GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
                _FrmPrintPreview.Report = _rptWare_Tonghop_Hoadon_Muahang_Thue;
                _rptWare_Tonghop_Hoadon_Muahang_Thue.CreateDocument();
                GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_rptWare_Tonghop_Hoadon_Muahang_Thue);
                if (Convert.ToBoolean(oReportOptions.PrintPreview))
                {
                    _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                    _FrmPrintPreview.printControl1.PrintingSystem = _rptWare_Tonghop_Hoadon_Muahang_Thue.PrintingSystem;
                    _FrmPrintPreview.MdiParent = this.MdiParent;
                    _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
                    _FrmPrintPreview.Show();
                    _FrmPrintPreview.Activate();
                }
                else
                {
                    var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_rptWare_Tonghop_Hoadon_Muahang_Thue);
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

    }
}

