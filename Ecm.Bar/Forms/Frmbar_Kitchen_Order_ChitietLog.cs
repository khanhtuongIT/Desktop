using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ecm.Bar.Forms
{
    public partial class Frmbar_Kitchen_Order_ChitietLog :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        Ecm.WebReferences.Classes.BarService objBarService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.BarService>();
        DataSet dsBar_Kitchen_Order_Chitiet;
        DataSet dsBar_Kitchen_Order_Chitiet_Top;
        DataSet dsBar_Kitchen_Order_Chitiet_NotLog;
        DataSet dsServedBar_Kitchen_Order_Chitiet;
        DataSet dsNVL;

        public Frmbar_Kitchen_Order_ChitietLog()
        {
            InitializeComponent();

            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Cancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_PrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            dtNgay_Batdau.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dtNgay_Ketthuc.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            DisplayInfo();
            lookUpEdit_Cuahang_Ban.EditValue =  GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocation("Id_Cuahang_Ban");

             GoobizFrame.Windows.MdiUtils.UserInterfaceHelper.SetGridViewMenu(gvBar_Kitchen_Order_Chitiet);
             GoobizFrame.Windows.MdiUtils.UserInterfaceHelper.SetGridViewMenu(gvBar_Kitchen_Order_Chitiet_Served);
             GoobizFrame.Windows.MdiUtils.UserInterfaceHelper.SetGridViewMenu(gvBar_Kitchen_Order_Chitiet_Top);
             GoobizFrame.Windows.MdiUtils.UserInterfaceHelper.SetGridViewMenu(gvNVL);
             GoobizFrame.Windows.MdiUtils.UserInterfaceHelper.SetGridViewMenu(gvNhom_Hanghoa_Ban);
             GoobizFrame.Windows.MdiUtils.UserInterfaceHelper.SetGridViewMenu(gvBar_Kitchen_Order_Chitiet_NotLog);
        }

        #region override
        public override void DisplayInfo()
        {
            lookUpEdit_Cuahang_Ban.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().ToDataSet().Tables[0];
            dgNhom_Hanghoa_Ban.DataSource = objMasterService.Get_All_Ware_Dm_Nhom_Hanghoa_Ban().ToDataSet().Tables[0];
        }

        public override bool PerformQuery()
        {
             GoobizFrame.Windows.Public.OrderHashtable htbControl1 = new  GoobizFrame.Windows.Public.OrderHashtable();
            //htbControl1.Add(lookUpEditMa_Kho_Hanghoa, lblKho_Hanghoa.Text);
            htbControl1.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            htbControl1.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            htbControl1.Add(lookUpEdit_Cuahang_Ban, lblCuahang_Ban.Text);
            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(htbControl1))
                return false;
            try
            {
                //dgBar_Kitchen_Order_Chitiet
                dsBar_Kitchen_Order_Chitiet = objBarService.GetLog_Bar_Kitchen_Order_Chitiet(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEdit_Cuahang_Ban.EditValue).ToDataSet();
                dgBar_Kitchen_Order_Chitiet.DataSource = dsBar_Kitchen_Order_Chitiet.Tables[0];
                gvBar_Kitchen_Order_Chitiet.BestFitColumns();

                //dgBar_Kitchen_Order_Chitiet_Top
                dsBar_Kitchen_Order_Chitiet_Top = objBarService.GetTopLog_Bar_Kitchen_Order_Chitiet(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEdit_Cuahang_Ban.EditValue).ToDataSet();
                dgBar_Kitchen_Order_Chitiet_Top.DataSource = dsBar_Kitchen_Order_Chitiet_Top.Tables[0];
                gvBar_Kitchen_Order_Chitiet_Top.BestFitColumns();
                dsBar_Kitchen_Order_Chitiet_Top.Tables[0].Columns.Add("Chon", typeof(bool));
                dsBar_Kitchen_Order_Chitiet_Top.Tables[0].Columns.Add("Copy_Ver", typeof(string));

                //dgBar_Kitchen_Order_Chitiet_Top
                dsBar_Kitchen_Order_Chitiet_NotLog = objBarService.GetNotLog_Bar_Kitchen_Order_Chitiet(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEdit_Cuahang_Ban.EditValue).ToDataSet();
                dgBar_Kitchen_Order_Chitiet_NotLog.DataSource = dsBar_Kitchen_Order_Chitiet_NotLog.Tables[0];
                gvBar_Kitchen_Order_Chitiet_NotLog.BestFitColumns();

                //dgBar_Kitchen_Order_Chitiet_Served
                dsServedBar_Kitchen_Order_Chitiet = objBarService.GetServed_Bar_Kitchen_Order_Chitiet(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEdit_Cuahang_Ban.EditValue).ToDataSet();
                dgBar_Kitchen_Order_Chitiet_Served.DataSource = dsServedBar_Kitchen_Order_Chitiet.Tables[0];
                gvBar_Kitchen_Order_Chitiet_Served.BestFitColumns();
               
                //dgBar_Kitchen_Order_Chitiet_Served
                dsNVL = objBarService.GetNVL_Bar_Kitchen_Order_Chitiet(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEdit_Cuahang_Ban.EditValue).ToDataSet();
                dgNVL.DataSource = dsNVL.Tables[0];
                gvNVL.BestFitColumns();

                return true;
            }
            catch (Exception ex)
            {
                 GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(),"");
                return false;
            }
        }

        public override bool PerformPrintPreview()
        {
            dgBar_Kitchen_Order_Chitiet.ShowPrintPreview();
            return base.PerformPrintPreview();
        } 

        #endregion

        private void btnFilter_Set_Click(object sender, EventArgs e)
        {
            if ("" + gvNhom_Hanghoa_Ban.GetFocusedRowCellValue("Id_Nhom_Hanghoa_Ban") != "")
            {
                gvBar_Kitchen_Order_Chitiet_Served.Columns["Id_Nhom_Hanghoa_Ban"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                    gvBar_Kitchen_Order_Chitiet_Served.Columns["Id_Nhom_Hanghoa_Ban"], gvNhom_Hanghoa_Ban.GetFocusedRowCellValue("Id_Nhom_Hanghoa_Ban"));
                
                gvBar_Kitchen_Order_Chitiet_NotLog.Columns["Id_Nhom_Hanghoa_Ban"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                    gvBar_Kitchen_Order_Chitiet_NotLog.Columns["Id_Nhom_Hanghoa_Ban"], gvNhom_Hanghoa_Ban.GetFocusedRowCellValue("Id_Nhom_Hanghoa_Ban"));
                
                gvNVL.Columns["Id_Nhom_Hanghoa_Ban"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                    gvNVL.Columns["Id_Nhom_Hanghoa_Ban"], gvNhom_Hanghoa_Ban.GetFocusedRowCellValue("Id_Nhom_Hanghoa_Ban"));
            }
        }

        private void btnFilter_Clear_Click(object sender, EventArgs e)
        {
            gvBar_Kitchen_Order_Chitiet_Served.Columns["Id_Nhom_Hanghoa_Ban"].ClearFilter();
            gvBar_Kitchen_Order_Chitiet_NotLog.Columns["Id_Nhom_Hanghoa_Ban"].ClearFilter();
            gvNVL.Columns["Id_Nhom_Hanghoa_Ban"].ClearFilter();
        }

        private void btnPrint_CopyVer_Click(object sender, EventArgs e)
        {
            this.DoClickEndEdit(dgBar_Kitchen_Order_Chitiet_Top);
            DataRow[] sdrKitchen_Order = dsBar_Kitchen_Order_Chitiet_Top.Tables[0].Select(string.Format("Chon = '{0}'", true));
            if (sdrKitchen_Order.Length > 0)
            {
                DataSets.DsBar_Kitchen_Order_Chitiet dsKitchen_Order = new Ecm.Bar.DataSets.DsBar_Kitchen_Order_Chitiet();
                Reports.RptBar_Kitchen_Order_Chitiet rptKitchen_Order = new Ecm.Bar.Reports.RptBar_Kitchen_Order_Chitiet();

                foreach (DataRow drKitchen_Order in sdrKitchen_Order)
                {
                    drKitchen_Order["Copy_Ver"] = "COPY";
                    dsKitchen_Order.Tables[0].ImportRow(drKitchen_Order);
                }
                rptKitchen_Order.DataSource = dsKitchen_Order;

                var reportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rptKitchen_Order);
                reportPrintTool.Print();
            }
        }
    }
}