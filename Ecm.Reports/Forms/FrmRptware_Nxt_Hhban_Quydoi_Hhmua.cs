using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunLine.Reports.Forms
{
    public partial class FrmRptware_Nxt_Hhban_Quydoi_Hhmua : GoobizFrame.Windows.Forms.FormReportWithHeader
    {
        SunLine.WebReferences.Classes.WareService objWareService = new SunLine.WebReferences.Classes.WareService();
        SunLine.WebReferences.Classes.ReportService objReportServices = new SunLine.WebReferences.Classes.ReportService();
        SunLine.WebReferences.Classes.MasterService objMasterService = new SunLine.WebReferences.Classes.MasterService();
        public FrmRptware_Nxt_Hhban_Quydoi_Hhmua()
        {
            InitializeComponent();
            DisplayInfo();
        }

        void DisplayInfo()
        {
            lookUpEditCuahang_Ban.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().Tables[0];
        }

        public override bool PerformQuery()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            hashtableControls.Add(lookUpEditCuahang_Ban, lblCuahang_Ban.Text);

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return false;

            XtraReports.Rptware_Nxt_Hhban_Quydoi_Hhmua Rptware_Nxt_Hhban_Quydoi_Hhmua = new SunLine.Reports.XtraReports.Rptware_Nxt_Hhban_Quydoi_Hhmua();
            this.Report = Rptware_Nxt_Hhban_Quydoi_Hhmua;
            DataSet ds_Collection = objReportServices.Rptware_Nxt_Hhban_Quydoi_Hhmua(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEditCuahang_Ban.EditValue);
            Datasets.DsWare_Nxt_Hhban_Quydoi_Hhmua DsRpt = new SunLine.Reports.Datasets.DsWare_Nxt_Hhban_Quydoi_Hhmua();
            try
            {
                foreach (DataRow row in ds_Collection.Tables[0].Rows)
                {
                    try
                    {
                        DsRpt.Tables["Nxt_Hhban"].ImportRow(row);
                    }
                    catch { }
                    DsRpt.Tables["Nxt_Hhmua"].ImportRow(row);
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
            Rptware_Nxt_Hhban_Quydoi_Hhmua.xrLblKho.Text = "Cửa hàng: " + lookUpEditCuahang_Ban.Text;
            Rptware_Nxt_Hhban_Quydoi_Hhmua.xrLbkNgay.Text = lblNgay_Batdau.Text + " " + dtNgay_Batdau.Text + " " + lblNgay_Ketthuc.Text + " " + dtNgay_Ketthuc.Text;
            Rptware_Nxt_Hhban_Quydoi_Hhmua.DataSource = DsRpt;
            Rptware_Nxt_Hhban_Quydoi_Hhmua.CreateDocument();

            this.printControl1.PrintingSystem = Rptware_Nxt_Hhban_Quydoi_Hhmua.PrintingSystem;

            return base.PerformQuery();
        }
    }
}

