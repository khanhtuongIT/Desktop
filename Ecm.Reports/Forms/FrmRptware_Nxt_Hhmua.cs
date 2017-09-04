using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunLine.Reports.Forms
{
    public partial class FrmRptware_Nxt_Hhmua : GoobizFrame.Windows.Forms.FormReportWithHeader
    {
        SunLine.WebReferences.Classes.WareService objWareService = new SunLine.WebReferences.Classes.WareService();
        SunLine.WebReferences.Classes.MasterService objMasterService = new SunLine.WebReferences.Classes.MasterService();
        SunLine.WebReferences.Classes.ReportService objReportServices = new SunLine.WebReferences.Classes.ReportService();

        public FrmRptware_Nxt_Hhmua()
        {
            InitializeComponent();

            dtNgay_Batdau.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dtNgay_Ketthuc.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            DisplayInfo();
        }

        void DisplayInfo()
        {

            lookUpEditKho_Hanghoa_Mua.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Kho_Hanghoa_Mua().Tables[0];
        }

        public override bool PerformQuery()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            hashtableControls.Add(lookUpEditKho_Hanghoa_Mua, lblKho_Hanghoa_Mua.Text);

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return false;

            XtraReports.Rptware_Nxt_Hhmua Rptware_Nxt_Hhmua = new SunLine.Reports.XtraReports.Rptware_Nxt_Hhmua();
            this.Report = Rptware_Nxt_Hhmua;
            DataSet ds_Collection = objReportServices.Rptware_Nxt_Hhmua(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEditKho_Hanghoa_Mua.EditValue);
            Datasets.DsWare_Nxt_Hhmua DsRpt = new SunLine.Reports.Datasets.DsWare_Nxt_Hhmua();
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
            Rptware_Nxt_Hhmua.xrLblKho.Text = "Kho: "+ lookUpEditKho_Hanghoa_Mua.Text;
            Rptware_Nxt_Hhmua.xrLbkNgay.Text = lblNgay_Batdau.Text + " " + dtNgay_Batdau.Text + " " + lblNgay_Ketthuc.Text + " " + dtNgay_Ketthuc.Text;
            Rptware_Nxt_Hhmua.DataSource = DsRpt;
            Rptware_Nxt_Hhmua.CreateDocument();

            this.printControl1.PrintingSystem = Rptware_Nxt_Hhmua.PrintingSystem;

            return base.PerformQuery();
        }
    }
}

