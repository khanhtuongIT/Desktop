using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunLine.MasterTables.Forms.Ware
{
    public partial class Frmware_Dm_Hanghoa_Mua_Import : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
               public MasterService.MasterService objMasterService = new SunLine.MasterTables.MasterService.MasterService();
        DataSet ds_Collection = new DataSet();
        DataSet dsMaps = new DataSet();
        public MasterService.Ware_Dm_Hanghoa_Mua SelectedWare_Dm_Hanghoa_Mua;
        GoobizFrame.Windows.Tools.FrmImportFromExcel FrmImportFromExcel;
       
        
        public Frmware_Dm_Hanghoa_Mua_Import()
        {
            InitializeComponent();
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                //Get data Ware_Dm_Loai_Hanghoa_Mua
                DataSet dsWare_Dm_Loai_Hanghoa_Mua = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Mua();
                gridLookUpEdit_Loai_Hanghoa_Mua.DataSource = dsWare_Dm_Loai_Hanghoa_Mua.Tables[0];

                //Get data Ware_Dm_Hanghoa_Mua
                ds_Collection = objMasterService.Get_All_Ware_Dm_Hanghoa_Mua_Import(txtBlockNo.Text);

                dgware_Dm_Hanghoa_Mua.DataSource = ds_Collection;
                dgware_Dm_Hanghoa_Mua.DataMember = ds_Collection.Tables[0].TableName;

                this.Data = ds_Collection;
                this.GridControl = dgware_Dm_Hanghoa_Mua;

                //gridLookUpEdit_ColumnsMap
                DataSet dsFieldNames = new DataSet();
                dsFieldNames.Tables.Add("ColumnsMap");
                dsFieldNames.Tables[0].Columns.Add("FieldName");
                dsFieldNames.Tables[0].Columns.Add("Caption");
                foreach (DevExpress.XtraGrid.Columns.GridColumn gridColumn in gridView1.Columns)
                {
                    DataRow ndr = dsFieldNames.Tables[0].NewRow();
                    ndr["FieldName"] = gridColumn.FieldName;
                    ndr["Caption"] = gridColumn.Caption;
                    dsFieldNames.Tables[0].Rows.Add(ndr);
                }
                dsFieldNames.AcceptChanges();
                gridLookUpEdit_ColumnsMap.DataSource = dsFieldNames.Tables[0];
                //click delete --> delete selected value
                gridLookUpEdit_ColumnsMap.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(
                    GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);

                this.ChangeStatus(false);

                this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif

                ////GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }

        }

        
        public void ChangeStatus(bool editTable)
        {
            gridView1.OptionsBehavior.Editable = editTable;
            gridView2.OptionsBehavior.Editable = editTable;
            btnOpenExcel.Enabled = editTable;
            btnShowMappedData.Enabled = editTable;
        }

       

        #region Event Override
        
        public override bool PerformAdd()
        {
            txtBlockNo.EditValue = objMasterService.GetNew_Sochungtu("ware_dm_hanghoa_mua_import", "block_no", "");
            this.ChangeStatus(true);
            return true;
        }
        
        public override bool PerformCancel()
        {
            this.DisplayInfo();
            this.ChangeStatus(false);
            return true;
        }

        public override bool PerformSave()
        {
            try
            {
                bool success = false;
                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                {
                    //success = (bool)this.InsertObject();
                }
                else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    //success = (bool)this.UpdateObject();
                }

                if (success)
                {
                    this.DisplayInfo();
                }
                return success;
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("exists") != -1)
                {
                    //GoobizFrame.Windows.Forms.UserMessage.Show("Msg00014", new string[] { lblMa_Hanghoa_Mua.Text, lblMa_Hanghoa_Mua.Text.ToLower() });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
            if (ds_Collection.Tables[0].Rows.Count == 0)
                return false;

            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Hanghoa_Mua"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Hanghoa_Mua"], "");
            hashtableControls.Add(gridView1.Columns["Id_Loai_Hanghoa_Mua"], "");


            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgware_Dm_Hanghoa_Mua.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                ds_Collection.Tables[0].Columns["Ma_Hanghoa_Mua"].Unique = true;
                objMasterService.Update_Ware_Dm_Hanghoa_Mua_Import_Collection(this.ds_Collection);

                objMasterService.InsertBatch_Ware_Dm_Hanghoa_Mua_Import(txtBlockNo.Text);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1 && ex.ToString().IndexOf("Ma_Hanghoa_Mua") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("Msg00014", new string[] { gridView1.Columns["Ma_Hanghoa_Mua"].Caption, gridView1.Columns["Ma_Hanghoa_Mua"].Caption.ToLower() });
                    return false;
                }
                //Error here
                GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                return false;
            }
            this.DisplayInfo();
            return true;
        }

       

        #endregion

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Hanghoa_Mua"];
            this.addnewrow_clicked = true;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                //if ("" + gridView1.GetFocusedRowCellValue("Barcode_Txt") == "")
                    if (e.Column.FieldName == "Ma_Hanghoa_Mua" || e.Column.FieldName == "Id_Loai_Hanghoa_Mua")
                    {
                        DataRowView drv = (DataRowView)gridLookUpEdit_Loai_Hanghoa_Mua.GetDataSourceRowByKeyValue(gridView1.GetFocusedRowCellValue("Id_Loai_Hanghoa_Mua"));

                        gridView1.SetFocusedRowCellValue(
                            gridView1.Columns["Barcode_Txt"],
                            drv["Ma_Nhom_Hanghoa_Mua"]
                        + " "
                        + drv["Ma_Loai_Hanghoa_Mua"]
                        + " "
                        + gridView1.GetFocusedRowCellValue("Ma_Hanghoa_Mua")
                       );
                    }
                this.dgware_Dm_Hanghoa_Mua.EmbeddedNavigator.Buttons.EndEdit.DoClick();
            }
            catch(Exception ex)
            {
            }
        }

       

        private void dgware_Dm_Hanghoa_Mua_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if (Convert.ToInt32(objMasterService.GetExistReferences("Ware_Dm_Hanghoa_Mua_Import", "Id_Hanghoa_Mua_Import", this.gridView1.GetFocusedRowCellValue("Id_Hanghoa_Mua_Import"))) > 0)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    e.Handled = true;
                }
            }
        }

        private void gridLookUpEdit_Loai_Hanghoa_Mua_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                Frmware_Dm_Loai_Hanghoa_Mua_Add frmware_Dm_Loai_Hanghoa_Mua_Add = new Frmware_Dm_Loai_Hanghoa_Mua_Add();
                frmware_Dm_Loai_Hanghoa_Mua_Add.Text = "Loại hàng hóa";
                GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmware_Dm_Loai_Hanghoa_Mua_Add);
                frmware_Dm_Loai_Hanghoa_Mua_Add.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                frmware_Dm_Loai_Hanghoa_Mua_Add.ShowDialog();

                if (frmware_Dm_Loai_Hanghoa_Mua_Add.SelectedWare_Dm_Loai_Hanghoa_Mua != null)
                {
                    gridLookUpEdit_Loai_Hanghoa_Mua.DataSource = frmware_Dm_Loai_Hanghoa_Mua_Add.Data.Tables[0];

                    gridView1.SetFocusedRowCellValue(
                        gridView1.Columns["Id_Loai_Hanghoa_Mua"]
                        , frmware_Dm_Loai_Hanghoa_Mua_Add.SelectedWare_Dm_Loai_Hanghoa_Mua.Id_Loai_Hanghoa_Mua);
                }
            }
        }

        private void Frmware_Dm_Hanghoa_Mua_Import_Load(object sender, EventArgs e)
        {
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void btnOpenExcel_Click(object sender, EventArgs e)
        {
            FrmImportFromExcel = new GoobizFrame.Windows.Tools.FrmImportFromExcel();
            FrmImportFromExcel.ShowDialog();
            if (FrmImportFromExcel.DsImportData != null && FrmImportFromExcel.DsImportData.Tables.Count > 0)
            {
                dsMaps = new DataSet();
                dsMaps.Tables.Add();
                dsMaps.Tables[0].Columns.Add("Excel_Col");
                dsMaps.Tables[0].Columns.Add("FieldName");
                foreach(DataColumn col in FrmImportFromExcel.DsImportData.Tables[0].Columns)
                {
                    DataRow ndr = dsMaps.Tables[0].NewRow();
                    ndr["Excel_Col"] = col.ColumnName;
                    dsMaps.Tables[0].Rows.Add(ndr);
                }
                dsMaps.AcceptChanges();

                dgColumnsMap.DataSource = dsMaps;
                dgColumnsMap.DataMember = dsMaps.Tables[0].TableName;

                //show selected data
                gridView3.Columns.Clear();
                int visibleIndex = 0;
                foreach (DataColumn col in FrmImportFromExcel.DsImportData.Tables[0].Columns)
                {
                    try
                    {
                        DevExpress.XtraGrid.Columns.GridColumn GridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
                        GridColumn.FieldName = col.ColumnName;
                        GridColumn.Caption = col.ColumnName;
                        GridColumn.VisibleIndex = visibleIndex++;
                        GridColumn.Visible = true;

                        gridView3.Columns.Add(GridColumn);
                    }
                    catch (Exception ex) { continue; }
                }

                dgDataImport.DataSource = FrmImportFromExcel.DsImportData;
                dgDataImport.DataMember = FrmImportFromExcel.DsImportData.Tables[0].TableName;
                gridView3.BestFitColumns();
                
                
            }
        }


        private void btnShowMappedData_Click(object sender, EventArgs e)
        {
            if (FrmImportFromExcel == null || FrmImportFromExcel.DsImportData == null)
                return;
            dgColumnsMap.EmbeddedNavigator.Buttons.EndEdit.DoClick();
            ds_Collection.Clear();

            foreach (DataRow imp_row in FrmImportFromExcel.DsImportData.Tables[0].Rows)
            {
                DataRow ndr = ds_Collection.Tables[0].NewRow();
                ndr["Block_No"] = txtBlockNo.Text;
                foreach (DataRow map_row in dsMaps.Tables[0].Rows)
                {
                    try
                    {
                        if ("" + map_row["FieldName"] != "")
                            ndr["" + map_row["FieldName"]] = imp_row["" + map_row["Excel_Col"]];
                    }
                    catch (Exception ex){ continue; }
                }
                ds_Collection.Tables[0].Rows.Add(ndr);
            }

           
        }
    }
}

