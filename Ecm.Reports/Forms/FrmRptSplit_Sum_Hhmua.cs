using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunLine.Reports.Forms
{
    public partial class FrmRptSplit_Sum_Hhmua : GoobizFrame.Windows.Forms.FormReportWithHeader
    {
        SunLine.WebReferences.Classes.WareService objWareService = new SunLine.WebReferences.Classes.WareService();
        SunLine.WebReferences.Classes.MasterService objMasterService = new SunLine.WebReferences.Classes.MasterService();
        SunLine.WebReferences.Classes.ReportService objReportServices = new SunLine.WebReferences.Classes.ReportService();


        public FrmRptSplit_Sum_Hhmua()
        {
            InitializeComponent();
            DisplayInfo();

            dtNgay_Batdau.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dtNgay_Ketthuc.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

        }

        void DisplayInfo()
        {
            lookUpEditKho_Hanghoa_Mua.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Kho_Hanghoa_Mua().Tables[0];
           
            //try
            //{
            //    if ("" + GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocationId_Kho_Hanghoa_Mua() != "")
            //        lookUpEditKho_Hanghoa_Mua.EditValue = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocationId_Kho_Hanghoa_Mua();
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message); }

            if ("" + lookUpEditKho_Hanghoa_Mua.EditValue != "")
                lookUpEditKho_Hanghoa_Mua.Properties.ReadOnly = true;
        }

        public override bool PerformQuery()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            hashtableControls.Add(lookUpEditKho_Hanghoa_Mua, lblKho_Hanghoa_Mua.Text);

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return false;

            XtraReports.RptSplit_Sum_Hhmua RptSplit_Sum_Hhmua = new SunLine.Reports.XtraReports.RptSplit_Sum_Hhmua();
            Datasets.Ds_RptSplit_Sum_Hhmua DsRpt = new SunLine.Reports.Datasets.Ds_RptSplit_Sum_Hhmua();
            this.Report = RptSplit_Sum_Hhmua;
            RptSplit_Sum_Hhmua.DataSource = DsRpt;

            DataSet ds_Collection = objReportServices.RptSplit_Sum_Hhmua(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEditKho_Hanghoa_Mua.EditValue);
            try
            {
                foreach (DataRow row in ds_Collection.Tables[0].Rows)
                    DsRpt.Tables[0].ImportRow(row);
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
            RptSplit_Sum_Hhmua.xrLblKho.Text = "Kho: " + lookUpEditKho_Hanghoa_Mua.Text;
            RptSplit_Sum_Hhmua.xrLblNgay.Text = lblNgay_Batdau.Text + " " + dtNgay_Batdau.Text + " " + lblNgay_Ketthuc.Text + " " + dtNgay_Ketthuc.Text;
            RptSplit_Sum_Hhmua.CreateDocument();

            #region subreport RptWare_Hh_Kh_Tra
            XtraReports.RptWare_Hh_Kh_Tra RptWare_Hh_Kh_Tra = new SunLine.Reports.XtraReports.RptWare_Hh_Kh_Tra();
            DataSet dsWare_Hh_Kh_Tra = objReportServices.RptWare_Hh_Kh_Tra(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEditKho_Hanghoa_Mua.EditValue, null);
            Datasets.DsWare_Hh_Kh_Tra DsWare_Hh_Kh_Tra = new SunLine.Reports.Datasets.DsWare_Hh_Kh_Tra();
            try
            {
                foreach (DataRow row in dsWare_Hh_Kh_Tra.Tables[0].Rows)
                    DsWare_Hh_Kh_Tra.Tables[0].ImportRow(row);
            }
            catch (Exception ex) { }

            RptWare_Hh_Kh_Tra.DataSource = DsWare_Hh_Kh_Tra;
            RptWare_Hh_Kh_Tra.CreateDocument();
            RptSplit_Sum_Hhmua.Subreport.ReportSource = RptWare_Hh_Kh_Tra;
            #endregion

            RptSplit_Sum_Hhmua.CreateDocument();
            this.printControl1.PrintingSystem = RptSplit_Sum_Hhmua.PrintingSystem;
            return base.PerformQuery();
        }
    }
}

