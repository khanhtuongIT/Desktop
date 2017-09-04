using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;
using GoobizFrame.Windows.Forms;
using Ecm.WebReferences.MasterService;
using Ecm.WebReferences.ReportService;
using Ecm.WebReferences.WareService;

namespace Ecm.Reports.Forms
{
    public partial class FrmRptSplit_Sum_Hhban :  GoobizFrame.Windows.Forms.FormXReport
    {
        Ecm.WebReferences.Classes.WareService objWareService = new Ecm.WebReferences.Classes.WareService();
        Ecm.WebReferences.Classes.MasterService objMasterService = new Ecm.WebReferences.Classes.MasterService();
        Ecm.WebReferences.Classes.ReportService objReportServices = new Ecm.WebReferences.Classes.ReportService();

        public FrmRptSplit_Sum_Hhban()
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
            lookUpEditCuahang_Ban.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().ToDataSet().Tables[0];
            try
            {
                if ("" +  GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocation("Id_Cuahang_Ban") != "")
                    lookUpEditCuahang_Ban.EditValue =  GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocation("Id_Cuahang_Ban");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            if ("" + lookUpEditCuahang_Ban.EditValue != "")
                lookUpEditCuahang_Ban.Properties.ReadOnly = true;
        }

        public override bool PerformQuery()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            hashtableControls.Add(lookUpEditCuahang_Ban, lblCuahang_Ban.Text);

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return false;

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return false;            
            //init
            Datasets.DsRptSplit_Sum_Hhban DsRpt = new Ecm.Reports.Datasets.DsRptSplit_Sum_Hhban();
            XtraReports.rptSplit_Sum_Hhban RptSplit_Sum_Hhban = new Ecm.Reports.XtraReports.rptSplit_Sum_Hhban();
            this.Report = RptSplit_Sum_Hhban;
            RptSplit_Sum_Hhban.DataSource = DsRpt;

            DataSet ds_Collection = objReportServices.RptSplit_Sum_Hhban(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEditCuahang_Ban.EditValue).ToDataSet();
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
            RptSplit_Sum_Hhban.xrLblKho.Text = "Tại: " + lookUpEditCuahang_Ban.Text;
            RptSplit_Sum_Hhban.xrLblNgay.Text = lblNgay_Batdau.Text + " " + dtNgay_Batdau.Text + " " + lblNgay_Ketthuc.Text + " " + dtNgay_Ketthuc.Text;
            RptSplit_Sum_Hhban.CreateDocument();

            #region subreport RptWare_Hh_Kh_Tra
            DataSet dsWare_Hh_Kh_Tra = objReportServices.RptWare_Hh_Kh_Tra(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, null, lookUpEditCuahang_Ban.EditValue,null,null).ToDataSet();
            XtraReports.rptWare_Hh_Kh_Tra RptWare_Hh_Kh_Tra = new Ecm.Reports.XtraReports.rptWare_Hh_Kh_Tra();
            Datasets.DsWare_Hh_Kh_Tra DsWare_Hh_Kh_Tra = new Ecm.Reports.Datasets.DsWare_Hh_Kh_Tra();
            RptWare_Hh_Kh_Tra.DataSource = DsWare_Hh_Kh_Tra;

            try
            {
                foreach (DataRow row in dsWare_Hh_Kh_Tra.Tables[0].Rows)
                    DsWare_Hh_Kh_Tra.Tables[0].ImportRow(row);
            }
            catch (Exception ex) { }

            RptSplit_Sum_Hhban.Subreport.ReportSource = RptWare_Hh_Kh_Tra;
            RptWare_Hh_Kh_Tra.xrTable1.Width = 1030;
            RptWare_Hh_Kh_Tra.xrTable2.Width = 1030;
            RptWare_Hh_Kh_Tra.xrTable3.Width = 1030;
            RptWare_Hh_Kh_Tra.CreateDocument();
            #endregion

            #region Set he so ctrinh - logo, ten cty
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

                RptSplit_Sum_Hhban.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                RptSplit_Sum_Hhban.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                RptSplit_Sum_Hhban.xrPic_Logo.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }
            #endregion

            RptSplit_Sum_Hhban.CreateDocument();
            this.printControl1.PrintingSystem = RptSplit_Sum_Hhban.PrintingSystem;
            return base.PerformQuery();
        }
    }
}

