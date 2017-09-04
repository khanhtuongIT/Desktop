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
    public partial class FrmRptWare_SoQTM :  GoobizFrame.Windows.Forms.FormXReport
    {
        Ecm.WebReferences.Classes.WareService objWareService = new Ecm.WebReferences.Classes.WareService();
        Ecm.WebReferences.Classes.ReportService objReportServices = new Ecm.WebReferences.Classes.ReportService();


        public FrmRptWare_SoQTM()
        {
            InitializeComponent();
            DisplayInfo();

            dtNgay_Batdau.Properties.MinValue = new DateTime(2000, 01, 01);
            dtNgay_Ketthuc.Properties.MinValue = new DateTime(2000, 01, 01);


            dtNgay_Batdau.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dtNgay_Ketthuc.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

        }

        void DisplayInfo()
        {
            //lookUpEditCuahang_Ban.Properties.DataSource = objWareService.Get_All_Ware_Dm_Cuahang_Ban().Tables[0];
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
            XtraReports.Rptware_SoQTM RptWare_SoQTM = new Ecm.Reports.XtraReports.Rptware_SoQTM();
            this.Report = RptWare_SoQTM;


            DataSet ds_Collection = objReportServices.RptWare_SoQTM(dtNgay_Batdau.DateTime, dtNgay_Ketthuc.DateTime, null).ToDataSet();
            DataSet ds_Sotien_Ton = objReportServices.RptWare_SoQTM_GetTon(dtNgay_Batdau.DateTime, dtNgay_Ketthuc.DateTime).ToDataSet();
            Datasets.Ds_RptWare_SoQTM DsRpt = new Ecm.Reports.Datasets.Ds_RptWare_SoQTM();
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
            RptWare_SoQTM.xrLblNgay.Text = lblNgay_Batdau.Text + " " + string.Format("{0:dd/MM/yyyy }", dtNgay_Batdau.DateTime) + " " + lblNgay_Ketthuc.Text + " " + string.Format("{0:dd/MM/yyyy }", dtNgay_Ketthuc.DateTime);
            RptWare_SoQTM.xrcellSotien_Tondk.Text = string.Format("{0:#,#}", ds_Sotien_Ton.Tables[0].Rows[0]["Sotien_Tondk"]);
            RptWare_SoQTM.xrcel_Sotien_Tonck.Text = string.Format("{0:#,#}", ds_Sotien_Ton.Tables[0].Rows[0]["Sotien_Tonck"]);
            RptWare_SoQTM.DataSource = DsRpt;
            RptWare_SoQTM.CreateDocument();

            this.printControl1.PrintingSystem = RptWare_SoQTM.PrintingSystem;

            return base.PerformQuery();
        }
    }
}

