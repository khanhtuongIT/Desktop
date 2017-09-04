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
    public partial class Frmbar_Kitchen_Printer :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public Ecm.WebReferences.Classes.BarService objBarService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.BarService>();
        DataSet dsKitchen_Printer;

        public Frmbar_Kitchen_Printer()
        {
            InitializeComponent();

            this.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            //SetGridViewMenu
             GoobizFrame.Windows.MdiUtils.UserInterfaceHelper.SetGridViewMenu(gvBar_Kitchen_Printer);

            DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                txtPc_Code.Text =  GoobizFrame.Windows.Public.HardwareInformation.GetLongProcessorId().ToString();
                txtPc_Name.Text = System.Windows.Forms.SystemInformation.ComputerName;
                lookUpEdit_Cuahang_Ban.EditValue = Convert.ToInt64(
                     GoobizFrame.Windows.MdiUtils.ThemeSettings.GetValue("HostConfiguration", "Location", "Id_Cuahang_Ban"));

                lookUpEdit_Cuahang_Ban.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().ToDataSet().Tables[0];
                gridLookUpEdit_Nhom_Hanghoa_Ban.DataSource = objMasterService.Get_All_Ware_Dm_Nhom_Hanghoa_Ban().ToDataSet().Tables[0];

                gridComboBox_Printer.Items.Clear();
                gridComboBox_Printer.Items.AddRange( GoobizFrame.Windows.Public.PrintHelper.GetPrintersCollection());

                dsKitchen_Printer = objBarService.Get_All_Bar_Kitchen_Printer_ByPC_Code(txtPc_Code.Text).ToDataSet();
                dgBar_Kitchen_Printer.DataSource = dsKitchen_Printer;
                dgBar_Kitchen_Printer.DataMember = dsKitchen_Printer.Tables[0].TableName;

                this.Data = dsKitchen_Printer;
                this.GridControl = dgBar_Kitchen_Printer;

                gvBar_Kitchen_Printer.BestFitColumns();
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString()); 
            }
            base.DisplayInfo();
        }

        public override bool PerformCancel()
        {
            return base.PerformCancel();
        }

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable htControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            htControls.Add(gvBar_Kitchen_Printer.Columns["Printer"], "");
            htControls.Add(gvBar_Kitchen_Printer.Columns["Id_Nhom_Hanghoa_Ban"], "");
            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(htControls, gvBar_Kitchen_Printer))
                return false;

            System.Collections.Hashtable htExistGrid = new System.Collections.Hashtable();
            htExistGrid.Add(gvBar_Kitchen_Printer.Columns["Id_Nhom_Hanghoa_Ban"], "");
            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistGrid(htExistGrid, gvBar_Kitchen_Printer))
                return false;

            try
            {
                this.DoClickEndEdit(dgBar_Kitchen_Printer);
                dsKitchen_Printer.Tables[0].Columns["Id_Nhom_Hanghoa_Ban"].Unique = true;
                objBarService.Update_Bar_Kitchen_Printer_Collection(this.dsKitchen_Printer);
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString()); 

                return false;
            }
            this.DisplayInfo();
            return true;
        }

        private void gvBar_Kitchen_Printer_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvBar_Kitchen_Printer.SetFocusedRowCellValue("Pc_Code", txtPc_Code.Text);
            gvBar_Kitchen_Printer.SetFocusedRowCellValue("Pc_Name", txtPc_Name.Text);
            gvBar_Kitchen_Printer.SetFocusedRowCellValue("Id_Cuahang_Ban", lookUpEdit_Cuahang_Ban.EditValue);
        }
    }
}