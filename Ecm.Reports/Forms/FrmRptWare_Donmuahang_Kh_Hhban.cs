using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunLine.Reports.Forms
{
    public partial class FrmRptWare_Donmuahang_Kh_Hhban : GoobizFrame.Windows.Forms.FormReportWithHeader
    {
        SunLine.WebReferences.Classes.WareService objWareService = new SunLine.WebReferences.Classes.WareService();
        SunLine.WebReferences.Classes.ReportService objReportServices = new SunLine.WebReferences.Classes.ReportService();


        public FrmRptWare_Donmuahang_Kh_Hhban()
        {
            InitializeComponent();
            DisplayInfo();
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

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return false;

            XtraReports.RptWare_Donmuahang_Kh_Hhban RptWare_Donmuahang_Kh_Hhban = new SunLine.Reports.XtraReports.RptWare_Donmuahang_Kh_Hhban();
            this.Report = RptWare_Donmuahang_Kh_Hhban;
            DataSet ds_Collection = objReportServices.RptWare_Donmuahang_Kh(dtNgay_Batdau.DateTime, dtNgay_Ketthuc.DateTime);
            Datasets.Ds_RptWare_Donmuahang_Kh_Hhban DsRpt = new SunLine.Reports.Datasets.Ds_RptWare_Donmuahang_Kh_Hhban();
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
            RptWare_Donmuahang_Kh_Hhban.xrLblNgay.Text = lblNgay_Batdau.Text + " " + dtNgay_Batdau.Text + " " + lblNgay_Ketthuc.Text + " " + dtNgay_Ketthuc.Text;
            RptWare_Donmuahang_Kh_Hhban.DataSource = DsRpt;
            RptWare_Donmuahang_Kh_Hhban.CreateDocument();

            this.printControl1.PrintingSystem = RptWare_Donmuahang_Kh_Hhban.PrintingSystem;

            return base.PerformQuery();
        }
    }
}

