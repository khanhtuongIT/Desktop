using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Rex.Forms
{
    public partial class FrmRptRex_Lylich_Trichngang : GoobizFrame.Windows.Forms.FormXReport
    {
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        public DataSet ds_danhsach_nhansu;
        DevExpress.XtraReports.UI.XtraReport rptLylich_Trichngang = new DevExpress.XtraReports.UI.XtraReport();
        DataSet dsHeso_Chuongtrinh;

        public FrmRptRex_Lylich_Trichngang()
        {
            InitializeComponent();
            DisplayInfo();
        }
        public void DisplayInfo()
        {
            dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_By_Nhomheso("Company").ToDataSet();

            lookUpEdit_Bophan.Properties.DataSource = objMasterService.Get_All_Rex_Dm_Bophan_Collection().ToDataSet().Tables[0];
            var rptTemp = new DataTable();
            rptTemp.Columns.AddRange(new DataColumn[]{
                new DataColumn("Repx", typeof(string)),
                new DataColumn("Ten_Rpt", typeof(string))
            });
            rptTemp.Rows.Add(new string[] { "rptRex_Nhansu_DSLLTN_1", "Mẫu 1: Danh sách lý lịch trích ngang" });
            rptTemp.Rows.Add(new string[] { "rptRex_Nhansu_DSLLTN_2", "Mẫu 2: Danh sách cán bộ công nhân viên" });
            rptTemp.Rows.Add(new string[] { "rptRex_Nhansu_DSLLTN_3", "Mẫu 3: Danh sách lý lịch trích ngang (đầy đủ)" });
            rptTemp.Rows.Add(new string[] { "rptRex_Nhansu_DSLLTN_4", "Mẫu 4: Danh sách tham gia BHXH" });
            lookUpEdit_RptTemplates.Properties.DataSource = rptTemp;
            lookUpEdit_RptTemplates.EditValue = "rptRex_Nhansu_DSLLTN_2";
        }
        public override bool PerformQuery()
        {

            try
            {
                if (lookUpEdit_Bophan.EditValue == null)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("Msg00013", new string[] { lblBophan.Text, lblBophan.Text });
                    lookUpEdit_Bophan.Focus();
                    return false;
                }

                rptLylich_Trichngang.FindControl("xrc_NgayBaocao", true).Text = string.Format("{0:dd/MM/yyyy}", dtNgay_Ketthuc.DateTime);

                if ("" + lookUpEdit_RptTemplates.EditValue == "rptRex_Nhansu_DSLLTN_4")
                    ds_danhsach_nhansu = objRexService.Get_Rex_Nhansu_Tgia_Bhxh(
                    lookUpEdit_Bophan.EditValue, dtNgay_Ketthuc.DateTime, chkInclude_Children.Checked, chkInclude_Thoiviec.Checked
                    ).ToDataSet();
                else
                ds_danhsach_nhansu = objRexService.Get_Danhsach_Nhansu_In_Lylich_Trichngang(
                    lookUpEdit_Bophan.EditValue, dtNgay_Ketthuc.DateTime, chkInclude_Children.Checked, chkInclude_Thoiviec.Checked
                    ).ToDataSet();
                rptLylich_Trichngang.DataSource = ds_danhsach_nhansu;
                rptLylich_Trichngang.CreateDocument();
               
                this.printControl1.PrintingSystem = rptLylich_Trichngang.PrintingSystem;
                return base.PerformQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        private void lookUpEdit_RptTemplates_EditValueChanged(object sender, EventArgs e)
        {
            switch ("" + lookUpEdit_RptTemplates.EditValue)
            {
                case "rptRex_Nhansu_DSLLTN_1":
                    rptLylich_Trichngang = new Ecm.Rex.Reports.rptRex_Nhansu_DSLLTN_4();
                    break;
                case "rptRex_Nhansu_DSLLTN_2":
                    rptLylich_Trichngang = new Ecm.Rex.Reports.rptRex_Nhansu_DSLLTN_4();
                    break;
                case "rptRex_Nhansu_DSLLTN_4":
                    rptLylich_Trichngang = new Ecm.Rex.Reports.rptRex_Nhansu_DSLLTN_4();
                    break;
                case "rptRex_Nhansu_DSLLTN_3":
                    rptLylich_Trichngang = new Ecm.Rex.Reports.rptRex_Nhansu_DSLLTN_4();
                    break;
            }
            this.Report = rptLylich_Trichngang;
            if (ds_danhsach_nhansu != null)
                rptLylich_Trichngang.DataSource = ds_danhsach_nhansu;

            ReportHelper.SetCompanyInfoAtHeader(rptLylich_Trichngang);

            //#region Set he so ctrinh - logo, ten cty

            
            //DataSet dsCompany_Paras = new DataSet();
            //dsCompany_Paras.Tables.Add("Company_Paras");
            //dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
            //dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
            //dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

            //byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

            //dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
            //    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
            //    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
            //    ,imageData
            //});

            //rptLylich_Trichngang.FindControl("xrc_CompanyName", true).DataBindings.Add(
            //    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
            //rptLylich_Trichngang.FindControl("xrc_CompanyAddress", true).DataBindings.Add(
            //    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
            //rptLylich_Trichngang.FindControl("xrPic_Logo", true).DataBindings.Add(
            //    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            

            //#endregion
            
            rptLylich_Trichngang.CreateDocument();

            this.printControl1.PrintingSystem = rptLylich_Trichngang.PrintingSystem;
            this.printControl1.Refresh();
        }

    }

    public class ReportHelper
    {
        static DataSet dsCompany_Paras;
        static DataSet dsHeso_Chuongtrinh;

        public static void SetCompanyInfoAtHeader(  DevExpress.XtraReports.UI.XtraReport  xReport)
        {
            try
            {
                if (dsHeso_Chuongtrinh == null)
                {
                    Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
                    dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_By_Nhomheso("Company").ToDataSet();
                }

                if (dsCompany_Paras == null)
                {
                    dsCompany_Paras = new DataSet();
                    dsCompany_Paras.Tables.Add("Company_Paras");
                    dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                    dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                    dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                  
                }

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                ,imageData
            });
                try
                {
                    xReport.FindControl("xrc_CompanyName", true).DataBindings.Add(
                        new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk,
                        ex.Message, ex.ToString());
                }

                try
                {
                    xReport.FindControl("xrc_CompanyAddress", true).DataBindings.Add(
                        new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk,
                        ex.Message, ex.ToString());
                }

                try
                {
                    xReport.FindControl("xrPic_Logo", true).DataBindings.Add(
                        new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk,
                        ex.Message, ex.ToString());
                }

                try
                {
                    xReport.FindControl("xrc_Ngaylap", true).Text = string.Format("ngày {0} tháng {1} năm {2}", new
                            object[] { DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year });
                    xReport.FindControl("xrc_Nguoilap", true).Text = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUserEntry("User_Fullname");

                }
                catch (Exception ex) {
                    GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk,
                        ex.Message, ex.ToString());
                }
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
            }
        }

        static void ReportFooter_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var band = sender as DevExpress.XtraReports.UI.Band;
          
        }
    }
}

