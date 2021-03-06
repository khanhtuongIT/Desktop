﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunLine.Reports.Forms
{
    public partial class FrmRptware_Nxt_Hhban_Thekho : GoobizFrame.Windows.Forms.FormReportWithHeader
    {
        SunLine.WebReferences.Classes.WareService objWareService = new SunLine.WebReferences.Classes.WareService();
        SunLine.WebReferences.Classes.ReportService objReportServices = new SunLine.WebReferences.Classes.ReportService();
        SunLine.WebReferences.Classes.MasterService objMasterService = new SunLine.WebReferences.Classes.MasterService();


        public FrmRptware_Nxt_Hhban_Thekho()
        {
            InitializeComponent();
            DisplayInfo();
        }
        void DisplayInfo()
        {
            //lookUpEditCuahang_Ban
            lookUpEditCuahang_Ban.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().Tables[0];

            //lookUpEdit_Hanghoa_Ban
            DataSet dsWare_Dm_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban();
            lookUpEdit_Hanghoa_Ban.Properties.DataSource = dsWare_Dm_Hanghoa_Ban.Tables[0];
        }
        public override bool PerformQuery()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            hashtableControls.Add(lookUpEditCuahang_Ban, lblCuahang_Ban.Text);

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return false;

            XtraReports.Rptware_Nxt_Hhban_Thekho Rptware_Nxt_Hhban_Thekho = new SunLine.Reports.XtraReports.Rptware_Nxt_Hhban_Thekho();
            this.Report = Rptware_Nxt_Hhban_Thekho;
//            DataSet ds_Collection = objReportServices.Rptware_Nxt_Hhban_Thekho(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEditCuahang_Ban.EditValue);
//            Datasets.DsWare_Hhban_Thekho DsRpt = new SunLine.Reports.Datasets.DsWare_Hhban_Thekho();
//            try
//            {
//                foreach (DataRow row in ds_Collection.Tables[0].Rows)
//                    DsRpt.Tables[0].ImportRow(row);
//            }
//            catch (Exception ex)
//            {
//#if DEBUG
//                MessageBox.Show(ex.Message);
//#endif
//            }
            Rptware_Nxt_Hhban_Thekho.xrLblMa_Hanghoa.Text = ""+lookUpEdit_Hanghoa_Ban.GetColumnValue("Ma_Hanghoa_Ban");
            Rptware_Nxt_Hhban_Thekho.xrLblTen_Hanghoa.Text = ""+lookUpEdit_Hanghoa_Ban.GetColumnValue("Ten_Hanghoa_Ban");
            Rptware_Nxt_Hhban_Thekho.xrLblKho.Text = "Cửa hàng: " + lookUpEditCuahang_Ban.Text;
            Rptware_Nxt_Hhban_Thekho.xrLbkNgay.Text = lblNgay_Batdau.Text + " " + dtNgay_Batdau.Text + " " + lblNgay_Ketthuc.Text + " " + dtNgay_Ketthuc.Text;
            //Rptware_Nxt_Hhban_Thekho.DataSource = DsRpt;
            Rptware_Nxt_Hhban_Thekho.CreateDocument();

            this.printControl1.PrintingSystem = Rptware_Nxt_Hhban_Thekho.PrintingSystem;

            return base.PerformQuery();
        }
    }
}

