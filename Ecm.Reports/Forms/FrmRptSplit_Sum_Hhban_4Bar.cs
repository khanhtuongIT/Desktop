using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using GoobizFrame.Windows.Forms;
using Ecm.WebReferences.MasterService;
using Ecm.WebReferences.WareService;

namespace Ecm.Reports.Forms
{
    public partial class FrmRptSplit_Sum_Hhban_4Bar :  GoobizFrame.Windows.Forms.FormXReport
    {
        Ecm.WebReferences.Classes.WareService objWareService = new Ecm.WebReferences.Classes.WareService();
        Ecm.WebReferences.Classes.ReportService objReportServices = new Ecm.WebReferences.Classes.ReportService();
        Ecm.WebReferences.Classes.MasterService objMasterService = new Ecm.WebReferences.Classes.MasterService();

        DataSet dsCa_Lamviec;

        public FrmRptSplit_Sum_Hhban_4Bar()
        {
            InitializeComponent();
            dtNgay_Batdau.Properties.MinValue = new DateTime(2000, 01, 01);
            dtNgay_Ketthuc.Properties.MinValue = new DateTime(2000, 01, 01);

            dtNgay_Batdau.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dtNgay_Ketthuc.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            DisplayInfo();
            lookUpEditCuahang_Ban.Properties.ReadOnly = true;
        }

        void DisplayInfo()
        {
            lookUpEditCuahang_Ban.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().ToDataSet().Tables[0];
            dsCa_Lamviec = objMasterService.Get_All_Rex_Dm_Ca_Lamviec().ToDataSet();
            lookUpEdit_Ca_Lamviec.Properties.DataSource = dsCa_Lamviec.Tables[0];

            try
            {
                if ("" +  GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocation("Id_Cuahang_Ban") != "")
                    lookUpEditCuahang_Ban.EditValue =  GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocation("Id_Cuahang_Ban");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            //if ("" + lookUpEditCuahang_Ban.EditValue != "")
            //    lookUpEditCuahang_Ban.Properties.ReadOnly = true;
        }

        public override bool PerformQuery()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);    
            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return false;
            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return false;
            Datasets.DsRptSplit_Sum_Hhban DsRpt = new Ecm.Reports.Datasets.DsRptSplit_Sum_Hhban();
            XtraReports.rptSplit_Sum_Hhban RptSplit_Sum_Hhban = new Ecm.Reports.XtraReports.rptSplit_Sum_Hhban();
            this.Report = RptSplit_Sum_Hhban;
            RptSplit_Sum_Hhban.DataSource = DsRpt;
            DataSet ds_Collection = objReportServices.RptSplit_Sum_Hhban_4Bar(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue
                ,lookUpEditCuahang_Ban.EditValue).ToDataSet();
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
                    ,imageData});

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

        private void lookUpEdit_Ca_Lamviec_EditValueChanged(object sender, EventArgs e)
        {
            if ("" + lookUpEdit_Ca_Lamviec.EditValue != "")
            {
                var sdrCa_Lamviec = dsCa_Lamviec.Tables[0].Select(string.Format("Id_Ca_Lamviec = {0}", lookUpEdit_Ca_Lamviec.EditValue))[0];
                dtNgay_Batdau.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                        Convert.ToDateTime(sdrCa_Lamviec["Gio_Batdau"]).Hour,
                                        Convert.ToDateTime(sdrCa_Lamviec["Gio_Batdau"]).Minute,
                                        Convert.ToDateTime(sdrCa_Lamviec["Gio_Batdau"]).Second);
                dtNgay_Ketthuc.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                        Convert.ToDateTime(sdrCa_Lamviec["Gio_Ketthuc"]).Hour,
                                        Convert.ToDateTime(sdrCa_Lamviec["Gio_Ketthuc"]).Minute,
                                        Convert.ToDateTime(sdrCa_Lamviec["Gio_Ketthuc"]).Second);
            }
        }

        private void lookUpEdit_Ca_Lamviec_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                dtNgay_Batdau.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                dtNgay_Ketthuc.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

                lookUpEdit_Ca_Lamviec.EditValue = null;
            }
        }

    }
}

