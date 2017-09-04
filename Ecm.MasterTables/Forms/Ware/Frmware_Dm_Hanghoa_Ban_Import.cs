using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Ware
{
    public partial class Frmware_Dm_Hanghoa_Ban_Import :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Collection = new DataSet();
        DataSet dsMaps = new DataSet();
        public Ecm.WebReferences.MasterService.Ware_Dm_Hanghoa_Ban SelectedWare_Dm_Hanghoa_Ban;
         GoobizFrame.Windows.Tools.FrmImportFromExcel frmImportFromExcel;

        public Frmware_Dm_Hanghoa_Ban_Import()
        {
            InitializeComponent();
            this.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barSystem.Visible = false;
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                //Get data Ware_Dm_Loai_Hanghoa_Ban
                DataSet dsWare_Dm_Loai_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Ban().ToDataSet();
                gridLookUp_Loai_Hanghoa_Ban.DataSource          = dsWare_Dm_Loai_Hanghoa_Ban.Tables[0];
                lookUp_Loai_Hanghoa_Ban.Properties.DataSource   = dsWare_Dm_Loai_Hanghoa_Ban.Tables[0];

                //Get data Ware_Dm_Hanghoa_Ban
                ds_Collection = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban_Import(txtBlockNo.Text).ToDataSet();
                ds_Collection.Tables[0].Columns.Add("Chon", typeof(bool));
                dgware_Dm_Hanghoa_Ban.DataSource = ds_Collection;
                dgware_Dm_Hanghoa_Ban.DataMember = ds_Collection.Tables[0].TableName;
                this.Data = ds_Collection;
                this.GridControl = dgware_Dm_Hanghoa_Ban;        
    
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
                gridLookUp_ColumnsMap.DataSource = dsFieldNames.Tables[0];
                //click delete --> delete selected value
                gridLookUp_ColumnsMap.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(
                     GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
                this.ChangeStatus(true);
                this.gridView1.BestFitColumns();
                showTabPages(tab_Dulieu);
                if (gridView3.RowCount > 0)
                    btn_Continue1.Visible = true;
                else
                    btn_Continue1.Visible = false;
            }
            catch (Exception ex)
            {
                 GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "");
            }
        }

        public override void  ChangeStatus(bool editTable)
        {
            gridView1.OptionsBehavior.Editable = editTable;
            gridView2.OptionsBehavior.Editable = editTable;
            btnOpenExcel.Enabled = editTable;
            btnShowMappedData.Enabled = editTable;
        }

        void showTabPages(DevExpress.XtraTab.XtraTabPage tabpage)
        {
            while (xtraTabControl1.TabPages.Count > 0)
                xtraTabControl1.TabPages.RemoveAt(0);
            xtraTabControl1.TabPages.Add(tabpage);
        }

        #region Event Override

        public override bool PerformAdd()
        {
            txtBlockNo.EditValue = objMasterService.GetNew_Sochungtu("ware_dm_hanghoa_ban_import", "block_no", "");
            this.ChangeStatus(true);
            return true;
        }

        public override bool PerformCancel()
        {
            this.DisplayInfo();      
            return true;
        }

        public override bool PerformSave()
        {
            PerformSaveChanges();
            return false;
            //try
            //{

            //    bool success = false;
            //    if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Add)
            //    {
            //        //success = (bool)this.InsertObject();
            //    }
            //    else if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Edit)
            //    {
            //        //success = (bool)this.UpdateObject();
            //    }

            //    if (success)
            //    {
            //        this.DisplayInfo();
            //        txtBlockNo.EditValue = null;
            //    }
            //    return success;
            //}
            //catch (Exception ex)
            //{
            //    if (ex.ToString().IndexOf("exists") != -1)
            //    {
            //        // GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Hanghoa_Ban.Text, lblMa_Hanghoa_Ban.Text.ToLower() });
            //    }
            //    return false;
            //}
        }

        public override bool PerformSaveChanges()
        {
            if (ds_Collection.Tables[0].Rows.Count == 0)
            {
                 GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa có dữ liệu, vui lòng kiểm tra lại");
                return false;
            }
            dgware_Dm_Hanghoa_Ban.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Hanghoa_Ban.EmbeddedNavigator.Buttons.EndEdit);
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Hanghoa_Ban"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Hanghoa_Ban"], "");
            hashtableControls.Add(gridView1.Columns["Id_Loai_Hanghoa_Ban"], "");
            hashtableControls.Add(gridView1.Columns["Ngay_Batdau"], "");
            hashtableControls.Add(gridView1.Columns["Dongia_Ban"], "");
            //hashtableControls.Add(gridView1.Columns["Id_Donvitinh"], "");
            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            hashtableControls.Add(gridView2.Columns["FieldName"], "");
            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView2))
                return false;

            //DataRow[] dtr = null;
            //for (int i = 0; i < gridView1.RowCount; i++)
            //{
            //    dtr = ds_All_Hanghoa_Ban.Tables[0].Select("Ma_Hanghoa ='" +gridView1.GetRowCellValue(i, gridView1.Columns["Ma_Hanghoa_Ban"])+ "'");
            //    if(dtr.Length >= 1){
            //         GoobizFrame.Windows.Forms.MessageDialog.Show("Mã hàng " + gridView1.GetRowCellValue(i, gridView1.Columns["Ma_Hanghoa_Ban"]) + " đã tồn tại, nhập lại Mã hàng hóa");
            //        return false;
            //    }
            //}
            try
            {                
                ds_Collection.Tables[0].Columns["Ma_Hanghoa_Ban"].Unique = true;
                objMasterService.Update_Ware_Dm_Hanghoa_Ban_Import_Collection(this.ds_Collection);
                objMasterService.InsertBatch_Ware_Dm_Hanghoa_Ban_Import(txtBlockNo.Text);
            }
            catch (Exception ex)
            {
#if DEBUG
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                    // GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Hanghoa_Ban.Text, lblMa_Hanghoa_Ban.Text.ToLower() });
                    return false;
                }
                MessageBox.Show(ex.ToString());
#endif
                //Error here
                 GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                return false;
            }
            this.dgDataImport.DataSource = null;
            this.DisplayInfo();
            txtBlockNo.EditValue = null;
            this.item_Save.Enabled = false;
            this.item_Cancel.Enabled = false;
            this.item_Add.Enabled = true;
            this.item_Close.Enabled = true;
            this.item_Edit.Enabled = true;
            this.ChangeFormState( GoobizFrame.Windows.Forms.FormState.View);
            return true;
        }

        #endregion

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Hanghoa_Ban"];
            this.addnewrow_clicked = true;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if ("" + gridView1.GetFocusedRowCellValue("Barcode_Txt") == "")
                    if (e.Column.FieldName == "Ma_Hanghoa_Ban" || e.Column.FieldName == "Id_Loai_Hanghoa_Ban")
                    {
                        DataRowView drv = (DataRowView)gridLookUp_Loai_Hanghoa_Ban.GetDataSourceRowByKeyValue(gridView1.GetFocusedRowCellValue("Id_Loai_Hanghoa_Ban"));

                        gridView1.SetFocusedRowCellValue(
                            gridView1.Columns["Barcode_Txt"],   gridView1.GetFocusedRowCellValue("Ma_Hanghoa_Ban"));
                    }
                this.dgware_Dm_Hanghoa_Ban.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Hanghoa_Ban.EmbeddedNavigator.Buttons.EndEdit);
            }
            catch (Exception ex)
            {
            }
        }

        private void dgware_Dm_Hanghoa_Ban_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if (Convert.ToInt32(objMasterService.GetExistReferences("Ware_Dm_Hanghoa_Ban_Import", "Id_Hanghoa_Ban_Import", this.gridView1.GetFocusedRowCellValue("Id_Hanghoa_Ban_Import"))) > 0)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    e.Handled = true;
                }
            }
        }

        private void gridLookUpEdit_Loai_Hanghoa_Ban_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                Frmware_Dm_Loai_Hanghoa_Ban_Add frmware_Dm_Loai_Hanghoa_Ban_Add = new Frmware_Dm_Loai_Hanghoa_Ban_Add();
                frmware_Dm_Loai_Hanghoa_Ban_Add.Text = "Loại hàng hóa";
                 GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmware_Dm_Loai_Hanghoa_Ban_Add);
                frmware_Dm_Loai_Hanghoa_Ban_Add.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                frmware_Dm_Loai_Hanghoa_Ban_Add.ShowDialog();

                if (frmware_Dm_Loai_Hanghoa_Ban_Add.SelectedWare_Dm_Loai_Hanghoa_Ban != null)
                {
                    gridLookUp_Loai_Hanghoa_Ban.DataSource = frmware_Dm_Loai_Hanghoa_Ban_Add.Data.Tables[0];
                    gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Loai_Hanghoa_Ban"], frmware_Dm_Loai_Hanghoa_Ban_Add.SelectedWare_Dm_Loai_Hanghoa_Ban.Id_Loai_Hanghoa_Ban);
                }
            }
        }

        private void Frmware_Dm_Hanghoa_Ban_Import_Load(object sender, EventArgs e)
        {
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void btnOpenExcel_Click(object sender, EventArgs e)
        {
            try
            {
                txtBlockNo.EditValue = objMasterService.GetNew_Sochungtu("ware_dm_hanghoa_ban_import", "block_no", "");
                frmImportFromExcel = new  GoobizFrame.Windows.Tools.FrmImportFromExcel();
                frmImportFromExcel.Text = "Nhập hàng hóa từ file Excel";
                frmImportFromExcel.ShowDialog();
                if (frmImportFromExcel.DsImportData != null && frmImportFromExcel.DsImportData.Tables.Count > 0)
                {
                    dsMaps = new DataSet();
                    dsMaps.Tables.Add();
                    dsMaps.Tables[0].Columns.Add("Excel_Col");
                    dsMaps.Tables[0].Columns.Add("FieldName");
                    foreach (DataColumn col in frmImportFromExcel.DsImportData.Tables[0].Columns)
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
                    foreach (DataColumn col in frmImportFromExcel.DsImportData.Tables[0].Columns)
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

                    dgDataImport.DataSource = frmImportFromExcel.DsImportData;
                    dgDataImport.DataMember = frmImportFromExcel.DsImportData.Tables[0].TableName;
                    gridView3.BestFitColumns();
                    showTabPages(tab_ChonCot);
                }
            }
            catch (Exception ex)
            {
                 GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(),"");
            }
        }


        private void btnShowMappedData_Click(object sender, EventArgs e)
        {
            //if (FrmImportFromExcel == null || FrmImportFromExcel.DsImportData == null)
            //    return;
            //dgColumnsMap.EmbeddedNavigator.Buttons.EndEdit.DoClick();
            //ds_Collection.Clear();

            //foreach (DataRow imp_row in FrmImportFromExcel.DsImportData.Tables[0].Rows)
            //{
            //    DataRow ndr = ds_Collection.Tables[0].NewRow();
            //    ndr["Block_No"] = txtBlockNo.Text;
            //    foreach (DataRow map_row in dsMaps.Tables[0].Rows)
            //    {
            //        try
            //        {
            //            if ("" + map_row["FieldName"] != "")
            //                ndr["" + map_row["FieldName"]] = imp_row["" + map_row["Excel_Col"]];
            //        }
            //        catch (Exception ex){ continue; }
            //    }
            //    ds_Collection.Tables[0].Rows.Add(ndr);
            //}
            PerformSaveChanges();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            showTabPages(tab_KetChuyen);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            showTabPages(tab_ChonCot);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            showTabPages(tab_ChonCot);
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            showTabPages(tab_Dulieu);
            if (gridView3.RowCount > 0)
                btn_Continue1.Visible = true;
            else
                btn_Continue1.Visible = false;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            showTabPages(tab_KetChuyen);
            if (frmImportFromExcel == null || frmImportFromExcel.DsImportData == null)
                return;
            dgColumnsMap.EmbeddedNavigator.Buttons.DoClick( dgColumnsMap.EmbeddedNavigator.Buttons.EndEdit);
            ds_Collection.Clear();

            foreach (DataRow imp_row in frmImportFromExcel.DsImportData.Tables[0].Rows)
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
                    catch (Exception ex) { continue; }
                }
                ds_Collection.Tables[0].Rows.Add(ndr);
            }
            gridView1.BestFitColumns();
        }

        private void btnSet_Loai_Hanghoa_Ban_Click(object sender, EventArgs e)
        {
            if (lookUp_Loai_Hanghoa_Ban.EditValue != null)
            {
                foreach(DataRow dr in ds_Collection.Tables[0].Select("Chon=true"))
                {
                    dr["Id_Loai_Hanghoa_Ban"]= lookUp_Loai_Hanghoa_Ban.EditValue;
                    //if ("" + gridView1.GetRowCellValue(i, gridView1.Columns["Barcode_Txt"]) == "")
                    //{
                    DataRowView drv = (DataRowView)gridLookUp_Loai_Hanghoa_Ban.GetDataSourceRowByKeyValue(lookUp_Loai_Hanghoa_Ban.EditValue);
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    dr["Barcode_Txt"] = //drv["Ma_Nhom_Hanghoa_Ban"] + " " + drv["Ma_Loai_Hanghoa_Ban"]+ " " + 
                        dr["Ma_Hanghoa_Ban"];///
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                }
                gridView1.BestFitColumns();
            }
        }
    }
}

