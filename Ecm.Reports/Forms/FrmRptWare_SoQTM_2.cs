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
    public partial class FrmRptWare_SoQTM_2 :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.WareService objWareService = new Ecm.WebReferences.Classes.WareService();
        Ecm.WebReferences.Classes.ReportService objReportServices = new Ecm.WebReferences.Classes.ReportService();
        Ecm.WebReferences.Classes.MasterService objMasterService = new Ecm.WebReferences.Classes.MasterService();

        XtraReports.Rptware_SoQTM RptWare_SoQTM = new Ecm.Reports.XtraReports.Rptware_SoQTM();

        DataSet ds_Collection;

        public FrmRptWare_SoQTM_2()
        {
            InitializeComponent();

            DisplayInfo();
            dtNgay_Batdau.Properties.MinValue = new DateTime(2000, 01, 01);
            dtNgay_Ketthuc.Properties.MinValue = new DateTime(2000, 01, 01);

            dtNgay_Batdau.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dtNgay_Ketthuc.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            this.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Cancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        public override void DisplayInfo()
        {
            gridLookUpEdit_Kho_Hanghoa.DataSource = objMasterService.Get_All_Ware_Dm_Kho_Hanghoa().ToDataSet().Tables[0];
            base.DisplayInfo();
        }

        public override bool PerformQuery()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            //hashtableControls.Add(lookUpEditCuahang_Ban, lblCuahang_Ban.Text);

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return false;
            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return false;
            ds_Collection = objReportServices.RptWare_SoQTM_2(dtNgay_Batdau.DateTime, dtNgay_Ketthuc.DateTime).ToDataSet();

            dgSoQTM_2.DataSource = ds_Collection.Tables[0];
            gridView1.BestFitColumns();

            gridView1.Focus();
            gridView1.FocusedRowHandle = 0;
            if (""+gridView1.GetFocusedRowCellValue("Ma_Kho_Hanghoa") != "")
                ShowRPTDetail();
            
            return base.PerformQuery();

        }

        public override bool PerformPrintPreview()
        {
            //printControl1.PrintingSystem.PrintDlg();
            return base.PerformPrintPreview();
        }

        void ShowRPTDetail()
        {
            DateTime selected_row_date = Convert.ToDateTime( gridView1.GetFocusedRowCellValue("Ngay_Chungtu") );
            DateTime dtNgay_Batdau = new DateTime(selected_row_date.Year, selected_row_date.Month, selected_row_date.Day, 0, 0, 0);
            DateTime dtNgay_Ketthuc = new DateTime(selected_row_date.Year, selected_row_date.Month, selected_row_date.Day, 23, 59, 59);

            DataSet ds_Collection2 = objReportServices.RptWare_SoQTM_ByKhohanghoa(
                dtNgay_Batdau, dtNgay_Ketthuc, gridView1.GetFocusedRowCellValue("Ma_Kho_Hanghoa")).ToDataSet();
            DataSet ds_Sotien_Ton = objReportServices.RptWare_SoQTM_GetTon(dtNgay_Batdau, dtNgay_Ketthuc).ToDataSet();
            Datasets.Ds_RptWare_SoQTM DsRpt = new Ecm.Reports.Datasets.Ds_RptWare_SoQTM();
            try
            {
                foreach (DataRow row in ds_Collection2.Tables[0].Rows)
                    DsRpt.Tables[0].ImportRow(row);
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
            RptWare_SoQTM.xrLblNgay.Text = 
                lblNgay_Batdau.Text + " " + string.Format("{0:dd/MM/yyyy }", dtNgay_Batdau) + " * " +
                lblNgay_Ketthuc.Text + " " + string.Format("{0:dd/MM/yyyy }", dtNgay_Ketthuc) + " * Khu vực: " +
                gridView1.GetFocusedRowCellDisplayText("Ma_Kho_Hanghoa");
            RptWare_SoQTM.xrcellSotien_Tondk.Text = string.Format("{0:#,#}", ds_Sotien_Ton.Tables[0].Rows[0]["Sotien_Tondk"]);
            RptWare_SoQTM.xrcel_Sotien_Tonck.Text = string.Format("{0:#,#}", ds_Sotien_Ton.Tables[0].Rows[0]["Sotien_Tonck"]);
            RptWare_SoQTM.DataSource = DsRpt;
            RptWare_SoQTM.CreateDocument();

            this.printControl1.PrintingSystem = RptWare_SoQTM.PrintingSystem;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if ("" + gridView1.GetFocusedRowCellValue("Ma_Kho_Hanghoa") != "")
                ShowRPTDetail();
        }

        private void btnShow_RptSoQTM_Click(object sender, EventArgs e)
        {
            FrmRptWare_SoQTM FrmRptWare_SoQTM = new FrmRptWare_SoQTM();
            FrmRptWare_SoQTM.MdiParent = this.MdiParent;
            FrmRptWare_SoQTM.Show();
            FrmRptWare_SoQTM.Activate();
            FrmRptWare_SoQTM.Text = this.Text + " * " + btnShow_RptSoQTM.Text;

            FrmRptWare_SoQTM.dtNgay_Batdau.DateTime = this.dtNgay_Batdau.DateTime;
            FrmRptWare_SoQTM.dtNgay_Ketthuc.DateTime = this.dtNgay_Ketthuc.DateTime;
            FrmRptWare_SoQTM.PerformQuery();
        }

        
      
    }
}