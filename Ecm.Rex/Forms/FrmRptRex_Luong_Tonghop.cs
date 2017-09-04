using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking;
using DevExpress.Utils;
using GoobizFrame.Windows.Forms;
using Ecm.Rex.Reports;

namespace Ecm.Rex.Forms
{
    public partial class FrmRptRex_Luong_Tonghop : GoobizFrame.Windows.Forms.FormXReport
    {

        // Methods
        public FrmRptRex_Luong_Tonghop()
        {
            this.InitializeComponent();
            this.DisplayInfo();
        }

        private void DisplayInfo()
        {
            this.dtThangNam.DateTime = DateTime.Now;
            this.dsBophan = this.objMasterTables.Get_All_Rex_Dm_Bophan_Collection().ToDataSet();
            this.lookUpEdit_Bophan.Properties.DataSource = this.dsBophan.Tables[0];
        }
        private void dtThangNam_EditValueChanged(object sender, EventArgs e)
        {
            DataSet set = this.objRex.Get_All_Rex_Kyluong_ByThangNam(this.dtThangNam.DateTime.Month, this.dtThangNam.DateTime.Year).ToDataSet();
            this.id_kyluong = set.Tables[0].Rows[0]["Id_Kyluong"];
        }

     

        private void navBarControl1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            DataSet set;
           
            Reports.RptRex_Luongtonghop_ATM p_atm;
            string str;
            string str2;
            DevExpress.XtraReports.UI.XtraReport report;
            WaitDialogForm form = new WaitDialogForm("Vui l\x00f2ng chờ trong v\x00e0i gi\x00e2y", "Đang thực hiện");
            switch (e.Link.Item.Name)
            {
                
                case "navRex_Tamung_Ky1":
                    {
                        DataSet set2 = this.objRex.Rex_Tamung_Ky1_SelectByBophan(this.dtThangNam.DateTime.Year, this.dtThangNam.DateTime.Month, this.lookUpEdit_Bophan.EditValue, true).ToDataSet();
                        this.rptRex_Tamung_Ky1 = new Reports.RptRex_Tamung_Ky1();
                        base.Report = this.rptRex_Tamung_Ky1;
                        ReportHelper.SetCompanyInfoAtHeader(this.rptRex_Tamung_Ky1);
                        this.rptRex_Tamung_Ky1.FindControl("xrc_Ngay_Ketthuc", true).Text = string.Format("{0:MM/yyyy}", this.dtThangNam.DateTime);
                        this.rptRex_Tamung_Ky1.DataSource = set2;
                        this.rptRex_Tamung_Ky1.CreateDocument();
                        base.printControl1.PrintingSystem = this.rptRex_Tamung_Ky1.PrintingSystem;
                        break;
                    }
                case "navChamcong":
                    {
                        DataSet set3 = this.objRex.Get_All_Rex_Chamcong_Thang_Collection(this.dtThangNam.DateTime.Year, this.dtThangNam.DateTime.Month, this.lookUpEdit_Bophan.EditValue, true, true).ToDataSet();
                        this.rptRex_Chamcong_Thang = new  Reports.rptRex_Chamcong_Thang();
                        base.Report = this.rptRex_Chamcong_Thang;
                        ReportHelper.SetCompanyInfoAtHeader(this.rptRex_Chamcong_Thang);
                        this.rptRex_Chamcong_Thang.FindControl("xrc_Ngay_Ketthuc", true).Text = string.Format("{0:MM/yyyy}", this.dtThangNam.DateTime);
                        this.rptRex_Chamcong_Thang.DataSource = set3;
                        this.rptRex_Chamcong_Thang.CreateDocument();
                        base.printControl1.PrintingSystem = this.rptRex_Chamcong_Thang.PrintingSystem;
                        break;
                    }
                case "navPrint_Bangchitiet":
                    {
                        this.dsrex_Luong_Tonghop = this.objRex.Get_Rex_Luong_Tonghop_By_Kyluong_Id_Bophan(this.id_kyluong, this.lookUpEdit_Bophan.EditValue, true).ToDataSet();
                        RptRex_Luongtonghop_Bangctiet xtraReport = new  RptRex_Luongtonghop_Bangctiet();
                        this.PrintBangLuongChitiet(xtraReport, this.dsrex_Luong_Tonghop, "");
                        break;
                    }
                case "navPrint_BangATM":
                    this.dsrex_Luong_Tonghop = this.objRex.Get_Rex_Luong_Tonghop_By_Kyluong_Id_Bophan(this.id_kyluong, this.lookUpEdit_Bophan.EditValue, true).ToDataSet();
                    p_atm = new  Reports.RptRex_Luongtonghop_ATM();
                    this.PrintBangLuongChitiet(p_atm, this.dsrex_Luong_Tonghop, "Taikhoan_Nganhang is not null");
                    break;

                case "navPrint_BangTM":
                    this.dsrex_Luong_Tonghop = this.objRex.Get_Rex_Luong_Tonghop_By_Kyluong_Id_Bophan(this.id_kyluong, this.lookUpEdit_Bophan.EditValue, true).ToDataSet();
                    p_atm = new  Reports.RptRex_Luongtonghop_ATM();
                    this.PrintBangLuongChitiet(p_atm, this.dsrex_Luong_Tonghop, "Taikhoan_Nganhang is null");
                    break;

                case "navPrint_BangAll":
                    this.dsrex_Luong_Tonghop = this.objRex.Get_Rex_Luong_Tonghop_By_Kyluong_Id_Bophan(this.id_kyluong, this.lookUpEdit_Bophan.EditValue, true).ToDataSet();
                    p_atm = new  Reports.RptRex_Luongtonghop_ATM();
                    this.PrintBangLuongChitiet(p_atm, this.dsrex_Luong_Tonghop, "");
                    break;

                case "navTrichnop_BHXH":
                    {
                        DataSet set4 = this.objRex.Get_Rex_Luong_Tonghop_BHXH(this.dtThangNam.DateTime.Year, this.dtThangNam.DateTime.Month, this.lookUpEdit_Bophan.EditValue, true).ToDataSet();
                        this.rptRex_Luongtonghop_Bhxh = new  Reports.RptRex_Luongtonghop_Bhxh();
                        base.Report = this.rptRex_Luongtonghop_Bhxh;
                        ReportHelper.SetCompanyInfoAtHeader(this.rptRex_Luongtonghop_Bhxh);
                        this.rptRex_Luongtonghop_Bhxh.FindControl("xrc_Ngay_Ketthuc", true).Text = string.Format("{0:MM/yyyy}", this.dtThangNam.DateTime);
                        this.rptRex_Luongtonghop_Bhxh.DataSource = set4;
                        this.rptRex_Luongtonghop_Bhxh.CreateDocument();
                        base.printControl1.PrintingSystem = this.rptRex_Luongtonghop_Bhxh.PrintingSystem;
                        break;
                    }
                case "navTrichnop_Kphi_Cdoan":
                    {
                        DataSet set5 = this.objRex.Get_Rex_Luong_Tonghop_Kpcd(this.dtThangNam.DateTime.Year, this.dtThangNam.DateTime.Month, this.lookUpEdit_Bophan.EditValue, true).ToDataSet();
                        RptRex_Luongtonghop_Kpcd xReport = new  RptRex_Luongtonghop_Kpcd();
                        base.Report = xReport;
                        ReportHelper.SetCompanyInfoAtHeader(xReport);
                        xReport.FindControl("xrc_Ngay_Ketthuc", true).Text = string.Format("{0:MM/yyyy}", this.dtThangNam.DateTime);
                        xReport.DataSource = set5;
                        xReport.CreateDocument();
                        base.printControl1.PrintingSystem = xReport.PrintingSystem;
                        break;
                    }
                case "navThongke_Tncn":
                    {
                        DataSet set6 = this.objRex.Get_Rex_Luong_Tonghop_Tncn(this.dtThangNam.DateTime.Year, this.lookUpEdit_Bophan.EditValue, true).ToDataSet();
                        RptRex_Luongtonghop_Tncn tncn = new  RptRex_Luongtonghop_Tncn();
                        base.Report = tncn;
                        ReportHelper.SetCompanyInfoAtHeader(tncn);
                        tncn.FindControl("xrc_Ngay_Ketthuc", true).Text = string.Format("{0:yyyy}", this.dtThangNam.DateTime);
                        tncn.DataSource = set6;
                        tncn.CreateDocument();
                        base.printControl1.PrintingSystem = tncn.PrintingSystem;
                        break;
                    }
                //case "navKetqua_Sx_Sum":
                //    {
                //        DataSet set7 = this.objPro.Get_Pro_Ketqua_Sx_Sum(this.dtThangNam.DateTime.Year, this.dtThangNam.DateTime.Month, this.lookUpEdit_Bophan.EditValue, null, -1, true);
                //        str = "Ecm.Pro.dll";
                //        str2 = "Ecm.Pro.Reports.RptPro_Ketqua_Sx";
                //        report = GoobizFrame.Windows.MdiUtils.ThemeSettings.CreateInstance(str, str2) as DevExpress.XtraReports.UI. XtraReport;
                //        if (report != null)
                //        {
                //            base.Report = report;
                //            ReportHelper.SetCompanyInfoAtHeader(report);
                //            report.FindControl("xrc_Ngay_Ketthuc", true).Text = string.Format("{0:MM/yyyy}", this.dtThangNam.DateTime);
                //            report.DataSource = set7;
                //            report.CreateDocument();
                //            base.printControl1.PrintingSystem = report.PrintingSystem;
                //        }
                //        break;
                //    }
                //case "navKetqua_Sx_Chitiet":
                //    {
                //        DataSet set8 = this.objPro.GetAll_Pro_Ketqua_Sx_Chitiet(this.dtThangNam.DateTime.Year, this.dtThangNam.DateTime.Month, this.lookUpEdit_Bophan.EditValue, null, -1, true);
                //        str = "Ecm.Pro.dll";
                //        str2 = "Ecm.Pro.Reports.RptPro_Ketqua_Sxcn";
                //        report = GoobizFrame.Windows.MdiUtils.ThemeSettings .CreateInstance(str, str2) as DevExpress.XtraReports.UI. XtraReport;
                //        if (report != null)
                //        {
                //            base.Report = report;
                //            ReportHelper.SetCompanyInfoAtHeader(report);
                //            report.FindControl("xrc_Ngay_Ketthuc", true).Text = string.Format("{0:MM/yyyy}", this.dtThangNam.DateTime);
                //            report.DataSource = set8;
                //            report.CreateDocument();
                //            base.printControl1.PrintingSystem = report.PrintingSystem;
                //        }
                //        break;
                //    }
            }
            form.Close();
        }

        public override bool PerformQuery()
        {
            this.dsrex_Luong_Tonghop = this.objRex.Get_Rex_Luong_Tonghop_By_Kyluong_Id_Bophan(this.id_kyluong, this.lookUpEdit_Bophan.EditValue, true).ToDataSet();
            Reports.RptRex_Luongtonghop_Bangctiet xtraReport = new   Reports.RptRex_Luongtonghop_Bangctiet();
            this.PrintBangLuongChitiet(xtraReport, this.dsrex_Luong_Tonghop, "");
            return base.PerformQuery();
        }

        private void PrintBangLuongChitiet(DevExpress.XtraReports.UI. XtraReport XtraReport, DataSet dsLuong_Tonghop, string Filter)
        {
            base.Report = XtraReport;
            ReportHelper.SetCompanyInfoAtHeader(XtraReport);
            Datasets.DsRex_Luong_Tonghop tonghop = new Datasets.DsRex_Luong_Tonghop();
            foreach (DataRow row in dsLuong_Tonghop.Tables[0].Select(Filter))
            {
                DataRow row2 = tonghop.Tables[0].NewRow();
                foreach (DataColumn column in row2.Table.Columns)
                {
                    try
                    {
                        row2[column.ColumnName] = row[column.ColumnName];
                        continue;
                    }
                    catch
                    {
                        continue;
                    }
                }
                tonghop.Tables[0].Rows.Add(row2);
            }
            tonghop.AcceptChanges();
            XtraReport.DataSource = tonghop;
            XtraReport.FindControl("xrc_Ngay_Ketthuc", true).Text = string.Format("{0:MM/yyyy}", this.dtThangNam.DateTime);
            XtraReport.CreateDocument();
            base.printControl1.PrintingSystem = XtraReport.PrintingSystem;
        }
    }

 

}