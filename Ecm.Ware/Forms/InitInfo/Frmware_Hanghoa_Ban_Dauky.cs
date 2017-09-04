using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Hanghoa_Ban_Dauky :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();

        DataSet ds_Collection = new DataSet();

        public Frmware_Hanghoa_Ban_Dauky()
        {
            InitializeComponent();
            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.DisplayInfo();
        }

        #region Event Override
        public override void DisplayInfo()
        {
            try
            {
                //Get data Ware_Dm_Cuahang_Ban
                DataSet dsWare_Dm_Cuahang_Ban = objMasterService.Ware_Dm_Cuahang_Ban_Select_Kho().ToDataSet();
                //lookUpEdit_Cuahang_Ban.Properties.DataSource = dsWare_Dm_Cuahang_Ban.Tables[0];
                gridLookUpEdit_Cuahang_Ban.DataSource = dsWare_Dm_Cuahang_Ban.Tables[0];

                //Get data Ware_Dm_Hanghoa_Ban
                DataSet dsWare_Dm_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
                //lookUpEdit_Hanghoa_Ban.Properties.DataSource = dsWare_Dm_Hanghoa_Ban.Tables[0];
                gridLookUpEdit_Hanghoa_Ban.DataSource = dsWare_Dm_Hanghoa_Ban.Tables[0];
                gridLookupEdit_Tenhang.DataSource = dsWare_Dm_Hanghoa_Ban.Tables[0];

                //Get data Ware_Dm_Donvitinh
                DataSet dsWare_Dm_Donvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
                //lookUpEdit_Donvitinh.Properties.DataSource = dsWare_Dm_Donvitinh.Tables[0];
                gridLookUpEdit_Donvitinh.DataSource = dsWare_Dm_Donvitinh.Tables[0];

                //Get data Ware_Hanghoa_Ban_Dauky
                ds_Collection = objWareService.Get_All_Ware_Hanghoa_Ban_Dauky().ToDataSet();
                dgware_Hanghoa_Ban_Dauky.DataSource = ds_Collection;
                dgware_Hanghoa_Ban_Dauky.DataMember = ds_Collection.Tables[0].TableName;

                this.Data = ds_Collection;
                this.GridControl = dgware_Hanghoa_Ban_Dauky;
                //this.ChangeStatus(false);
                this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }

        }

        public override void ChangeStatus(bool editTable)
        {
            this.dgware_Hanghoa_Ban_Dauky.Enabled = !editTable;
        }

        public override bool PerformEdit()
        {
            this.ChangeStatus(true);
            return true;
        }

        public override bool PerformCancel()
        {
            this.DisplayInfo();
            this.ChangeStatus(false);
            return true;
        }

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Soluong"], "");
            hashtableControls.Add(gridView1.Columns["Id_Cuahang_Ban"], "");
            hashtableControls.Add(gridView1.Columns["Id_Hanghoa_Ban"], "");
            hashtableControls.Add(gridView1.Columns["Id_Donvitinh"], "");

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                this.DoClickEndEdit(dgware_Hanghoa_Ban_Dauky); //dgware_Hanghoa_Ban_Dauky.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                objWareService.Update_Ware_Hanghoa_Ban_Dauky_Collection(this.ds_Collection);
            }
            catch (Exception ex)
            {
                //Error here
                 GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                return false;
            }
            this.DisplayInfo();
            return true;
        }

        public override object PerformSelectOneObject()
        {
//            Ecm.WebReferences.WareService.Ware_Hanghoa_Ban_Dauky ware_Hanghoa_Ban_Dauky = new Ecm.WebReferences.WareService.Ware_Hanghoa_Ban_Dauky();
//            try
//            {
//                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
//                DataRow dr = ds_Collection.Tables[0].Rows[focusedRow];
//                if (dr != null)
//                {
//                    ware_Hanghoa_Ban_Dauky.Id_Hanghoa_Ban_Dauky = dr["Id_Hanghoa_Ban_Dauky"];
//                    ware_Hanghoa_Ban_Dauky.Ngay_Nhap        = dr["Ngay_Nhap"];
//                    ware_Hanghoa_Ban_Dauky.Soluong          = dr["Soluong"];
//                    ware_Hanghoa_Ban_Dauky.Id_Cuahang_Ban   = dr["Id_Cuahang_Ban"];
//                    ware_Hanghoa_Ban_Dauky.Id_Hanghoa_Ban   = dr["Id_Hanghoa_Ban"];
//                    ware_Hanghoa_Ban_Dauky.Id_Donvitinh     = dr["Id_Donvitinh"];
//                }
//                this.Dispose();
//                this.Close();
                //return ware_Hanghoa_Ban_Dauky;
//            }
//            catch (Exception ex)
//            {
//#if DEBUG
//                MessageBox.Show(ex.Message);
//#endif
                return null;
//            }
        }
       
        #endregion

        #region Even

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Soluong"];
            //this.gridView1.SetFocusedRowCellValue(gridView1.Columns["Ngay_Nhap"], objWareService.GetServerDateTime());
            this.addnewrow_clicked = true;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Id_Hanghoa_Ban")
            {
                gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Donvitinh"]
                    , ((System.Data.DataRowView)gridLookUpEdit_Hanghoa_Ban.GetDataSourceRowByKeyValue(e.Value))["Id_Donvitinh"]);
            }
            if (e.Column.FieldName == "Soluong" || e.Column.FieldName == "Dongia")
            {
                decimal soluong = Convert.ToDecimal("0" + gridView1.GetFocusedRowCellValue("Soluong"));
                decimal dongia = Convert.ToDecimal("0" + gridView1.GetFocusedRowCellValue("Dongia"));
                gridView1.SetFocusedRowCellValue("Thanhtien", soluong * dongia);
            }
        }

        private void gridLookUpEdit_Hanghoa_Ban_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                try
                {
                    var dialog = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowDialogOfMetaData(
                        "Ecm.MasterTables.dll",
                        "Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Ban_FullEdit", this);

                    if (dialog == null)
                        return;
                    var SelectedObject = dialog.GetType().GetProperty("Selected_Ware_Dm_Hanghoa_Ban").GetValue(dialog, null)
                        as Ecm.WebReferences.MasterService.Ware_Dm_Hanghoa_Ban;
                    var DsDm_Hanghoa_Ban = dialog.GetType().GetProperty("DsDm_Hanghoa_Ban").GetValue(dialog, null) as DataSet;

                    if (SelectedObject != null)
                    {
                        gridLookUpEdit_Hanghoa_Ban.DataSource = DsDm_Hanghoa_Ban.Tables[0];

                        gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Hanghoa_Ban"], SelectedObject.Id_Hanghoa_Ban);

                    }
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                }               
            }
        }

        #endregion

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridView1.FocusedColumn.VisibleIndex == gridView1.VisibleColumns.Count - 1
               && "" + gridView1.GetFocusedRowCellValue("Id_Hanghoa_Ban") != "")
                gridView1.AddNewRow();
        }
    }
}

