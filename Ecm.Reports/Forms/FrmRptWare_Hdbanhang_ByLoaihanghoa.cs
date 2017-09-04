using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunLine.Reports.Forms
{
    public partial class FrmRptWare_Hdbanhang_ByLoaihanghoa : GoobizFrame.Windows.Forms.FormReportWithHeader
    {
        SunLine.WebReferences.Classes.WareService objWareService = new SunLine.WebReferences.Classes.WareService();
        SunLine.WebReferences.Classes.ReportService objReportServices = new SunLine.WebReferences.Classes.ReportService();
        SunLine.WebReferences.Classes.MasterService objMasterService = new SunLine.WebReferences.Classes.MasterService();


        public FrmRptWare_Hdbanhang_ByLoaihanghoa()
        {
            InitializeComponent();
            DisplayInfo();

            dtNgay_Batdau.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dtNgay_Ketthuc.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

        }

        void DisplayInfo()
        {
            lookUpEditMa_Loai_Hanghoa.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa().Tables[0];
        }

        public override bool PerformQuery()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            hashtableControls.Add(lookUpEditMa_Loai_Hanghoa, lblLoai_Hanghoa.Text);

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return false;

            XtraReports.RptWare_Hdbanhang RptWare_Hdbanhang = new SunLine.Reports.XtraReports.RptWare_Hdbanhang();
            this.Report = RptWare_Hdbanhang;
            DataSet ds_Collection = objReportServices.RptWare_Hdbanhang_ByLoaihanghoa(dtNgay_Batdau.DateTime, dtNgay_Ketthuc.DateTime, lookUpEditMa_Loai_Hanghoa.EditValue);
            Datasets.DsRptWare_Hdbanhang DsRpt = new SunLine.Reports.Datasets.DsRptWare_Hdbanhang();
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
            RptWare_Hdbanhang.xrLblNgay.Text = lblNgay_Batdau.Text + " " + dtNgay_Batdau.Text + " " + lblNgay_Ketthuc.Text + " " + dtNgay_Ketthuc.Text;
            RptWare_Hdbanhang.xrLblNgay.Text += " * "+ lookUpEditMa_Loai_Hanghoa.Text;
            RptWare_Hdbanhang.DataSource = DsRpt;
            RptWare_Hdbanhang.Subreport.ReportSource = null;
            RptWare_Hdbanhang.CreateDocument();

            this.printControl1.PrintingSystem = RptWare_Hdbanhang.PrintingSystem;

            return base.PerformQuery();
        }
    }
}

