using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using GoobizFrame.Windows.Forms;

namespace Ecm.Reports.Forms
{
    public partial class FrmRptWare_Hdbanhang_ByKhohanghoa :  GoobizFrame.Windows.Forms.FormXReport
    {
        Ecm.WebReferences.Classes.WareService objWareService = new Ecm.WebReferences.Classes.WareService();
        Ecm.WebReferences.Classes.ReportService objReportServices = new Ecm.WebReferences.Classes.ReportService();
        Ecm.WebReferences.Classes.MasterService objMasterService = new Ecm.WebReferences.Classes.MasterService();


        public FrmRptWare_Hdbanhang_ByKhohanghoa()
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
            lookUpEditMa_Cuahang.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().ToDataSet().Tables[0];
            try
            {
                if ("" +  GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocation("Id_Cuahang_Ban") != "")
                    lookUpEditMa_Cuahang.EditValue = "Ch" +
                     GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocation("Id_Cuahang_Ban");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            //try
            //{
            //    if ("" +  GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocationId_Cuahang_Ban() != "")
            //        lookUpEditMa_Cuahang.EditValue = "Kh" +
            //             GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocationId_Kho_Hanghoa_Mua();
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message); }

            //if ("" + lookUpEditMa_Cuahang.EditValue != "")
            //    lookUpEditMa_Cuahang.Properties.ReadOnly = true;
        }

        public override bool PerformQuery()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            hashtableControls.Add(lookUpEditMa_Cuahang, lblKho_Hanghoa.Text);

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return false;
            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return false;
            XtraReports.RptWare_Hdbanhang RptWare_Hdbanhang = new Ecm.Reports.XtraReports.RptWare_Hdbanhang();
            this.Report = RptWare_Hdbanhang;
            DataSet ds_Collection = objReportServices.RptWare_Hdbanhang_ByKhohanghoa(
                dtNgay_Batdau.DateTime, dtNgay_Ketthuc.DateTime, lookUpEditMa_Cuahang.EditValue).ToDataSet();
            Datasets.DsRptWare_Hdbanhang DsRpt = new Ecm.Reports.Datasets.DsRptWare_Hdbanhang();
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
            RptWare_Hdbanhang.xrLblNgay.Text += " * "+ lookUpEditMa_Cuahang.Text;
            RptWare_Hdbanhang.DataSource = DsRpt;

            #region RptWare_Hh_Kh_Tra
            XtraReports.rptWare_Hh_Kh_Tra RptWare_Hh_Kh_Tra = new Ecm.Reports.XtraReports.rptWare_Hh_Kh_Tra();
            DataSet dsWare_Hh_Kh_Tra = objReportServices.RptWare_Hh_Kh_Tra(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue , null , lookUpEditMa_Cuahang.GetColumnValue("Id_Cuahang_Ban"),null,null).ToDataSet();
            //    , (""+lookUpEditMa_Cuahang.GetColumnValue("Id_Kho_Hanghoa_Mua")=="")? null : lookUpEditMa_Cuahang.GetColumnValue("Id_Kho_Hanghoa_Mua")
            Datasets.DsWare_Hh_Kh_Tra DsWare_Hh_Kh_Tra = new Ecm.Reports.Datasets.DsWare_Hh_Kh_Tra();
            try
            {
                foreach (DataRow row in dsWare_Hh_Kh_Tra.Tables[0].Rows)
                    DsWare_Hh_Kh_Tra.Tables[0].ImportRow(row);
            }
            catch (Exception ex) { }

            RptWare_Hh_Kh_Tra.DataSource = DsWare_Hh_Kh_Tra;
            RptWare_Hh_Kh_Tra.CreateDocument();
            RptWare_Hdbanhang.Subreport.ReportSource = RptWare_Hh_Kh_Tra;
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

                RptWare_Hdbanhang.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                RptWare_Hdbanhang.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                RptWare_Hdbanhang.xrPic_Logo.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }

            #endregion
            RptWare_Hdbanhang.CreateDocument();

            this.printControl1.PrintingSystem = RptWare_Hdbanhang.PrintingSystem;

            return base.PerformQuery();
        }
    }
}

