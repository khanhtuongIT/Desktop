using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunLine.MasterTables.Forms.Ware
{
    public partial class Frmware_Dm_Hanghoa_Mua_Add : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
               public MasterService.MasterService objMasterService = new SunLine.MasterTables.MasterService.MasterService();
        DataSet ds_Collection = new DataSet();
        public MasterService.Ware_Dm_Hanghoa_Mua SelectedWare_Dm_Hanghoa_Mua;
        object id_kho_hanghoa_mua;
        public object Id_Kho_Hanghoa_Mua
        {
            set 
            {
                id_kho_hanghoa_mua = value;
                DisplayInfo();
            }
        }
        
        public Frmware_Dm_Hanghoa_Mua_Add()
        {
            InitializeComponent();
            if (! DesignMode)
                this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                //Get data Ware_Dm_Loai_Hanghoa_Mua
                DataSet dsWare_Nhasanxuat = objMasterService.Get_All_Ware_Dm_Nhasanxuat();
                lookUpEdit_Nhasanxuat.Properties.DataSource     = dsWare_Nhasanxuat.Tables[0];
                gridLookUpEdit_Nhasanxuat.DataSource = dsWare_Nhasanxuat.Tables[0];

                //Get data Ware_Dm_Loai_Hanghoa_Mua
                DataSet dsWare_Dm_Loai_Hanghoa_Mua = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Mua();
                lookUpEdit_Loai_Hanghoa_Mua.Properties.DataSource = dsWare_Dm_Loai_Hanghoa_Mua.Tables[0];
                gridLookUpEdit_Loai_Hanghoa_Mua.DataSource = dsWare_Dm_Loai_Hanghoa_Mua.Tables[0];

                //gridLookUpEdit_Nhom_Hanghoa_Mua
                gridLookUpEdit_Nhom_Hanghoa_Mua.DataSource = objMasterService.Get_All_Ware_Dm_Nhom_Hanghoa_Mua().Tables[0];

                //Get data Ware_Dm_Hanghoa_Mua
                if (id_kho_hanghoa_mua==null)
                    ds_Collection = objMasterService.Get_All_Ware_Dm_Hanghoa_Mua();
                else
                    ds_Collection = objMasterService.Get_All_Ware_Dm_Hanghoa_MuaBy_Id_Kho_Hh_Mua(id_kho_hanghoa_mua, null);

                dgware_Dm_Hanghoa_Mua.DataSource = ds_Collection;
                dgware_Dm_Hanghoa_Mua.DataMember = ds_Collection.Tables[0].TableName;

                //lookUpEdit_Donvitinh
                DataSet dsDm_Donvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh();
                lookUpEdit_Donvitinh.Properties.DataSource = dsDm_Donvitinh.Tables[0];
                gridLookUpEdit_Donvitinh.DataSource = dsDm_Donvitinh.Tables[0];

                this.Data = ds_Collection;
                this.GridControl = dgware_Dm_Hanghoa_Mua;

                this.DataBindingControl();

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

        void ClearDataBindings()
        {
            this.txtId_Hanghoa_Mua.DataBindings.Clear();
            this.txtMa_Hanghoa_Mua.DataBindings.Clear();
            this.txtTen_Hanghoa_Mua.DataBindings.Clear();
            this.txtSize.DataBindings.Clear();
            this.txtQuycach.DataBindings.Clear();
            this.txtSoluong_Min.DataBindings.Clear();
            this.txtBarcode_Txt.DataBindings.Clear();
            this.lookUpEdit_Loai_Hanghoa_Mua.DataBindings.Clear();
            this.lookUpEdit_Nhasanxuat.DataBindings.Clear();
            this.lookUpEdit_Donvitinh.DataBindings.Clear();
        }
            
        public void DataBindingControl()
        {
            try
            {
                ClearDataBindings();

                this.txtId_Hanghoa_Mua.DataBindings.Add("Text", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Hanghoa_Mua");
                this.txtMa_Hanghoa_Mua.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ma_Hanghoa_Mua");
                this.txtTen_Hanghoa_Mua.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ten_Hanghoa_Mua");
                this.txtSize.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Size");
                this.txtQuycach.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Quycach");
                this.txtSoluong_Min.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Soluong_Min");
                this.txtBarcode_Txt.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Barcode_Txt");

                this.lookUpEdit_Loai_Hanghoa_Mua.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Loai_Hanghoa_Mua");
                this.lookUpEdit_Nhasanxuat.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Nhasanxuat");
                this.lookUpEdit_Donvitinh.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Donvitinh");
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
            this.dgware_Dm_Hanghoa_Mua.Enabled = !editTable;
            this.txtMa_Hanghoa_Mua.Properties.ReadOnly = !editTable;
            this.txtTen_Hanghoa_Mua.Properties.ReadOnly = !editTable;
            this.txtSize.Properties.ReadOnly = !editTable;
            this.txtQuycach.Properties.ReadOnly = !editTable;
            this.txtSoluong_Min.Properties.ReadOnly = !editTable;
            this.txtBarcode_Txt.Properties.ReadOnly = !editTable;
            this.lookUpEdit_Loai_Hanghoa_Mua.Properties.ReadOnly = !editTable;
            this.lookUpEdit_Nhasanxuat.Properties.ReadOnly = !editTable;
            this.lookUpEdit_Donvitinh.Properties.ReadOnly = !editTable;
        }

        public void ResetText()
        {
            this.txtId_Hanghoa_Mua.EditValue = "";
            this.txtMa_Hanghoa_Mua.EditValue = "";
            this.txtTen_Hanghoa_Mua.EditValue = "";
            this.txtSize.EditValue = "";
            this.txtQuycach.EditValue = "";
            this.txtSoluong_Min.EditValue = null;
            this.txtBarcode_Txt.EditValue = "";
            this.lookUpEdit_Loai_Hanghoa_Mua.EditValue = null;
            this.lookUpEdit_Nhasanxuat.EditValue = null;
            this.lookUpEdit_Donvitinh.EditValue = null;
        }

        #region Event Override
        public object InsertObject()
        {
            MasterService.Ware_Dm_Hanghoa_Mua objWare_Dm_Hanghoa_Mua = new SunLine.MasterTables.MasterService.Ware_Dm_Hanghoa_Mua();
            objWare_Dm_Hanghoa_Mua.Id_Hanghoa_Mua = -1;
            objWare_Dm_Hanghoa_Mua.Ma_Hanghoa_Mua = txtMa_Hanghoa_Mua.EditValue;
            objWare_Dm_Hanghoa_Mua.Ten_Hanghoa_Mua = txtTen_Hanghoa_Mua.EditValue;
            objWare_Dm_Hanghoa_Mua.Size = txtSize.EditValue;
            objWare_Dm_Hanghoa_Mua.Quycach = txtQuycach.EditValue;
            objWare_Dm_Hanghoa_Mua.Barcode_Txt          = txtBarcode_Txt.EditValue;

            if ("" + txtSoluong_Min.EditValue != "")
                objWare_Dm_Hanghoa_Mua.Soluong_Min = txtSoluong_Min.EditValue;
           
            if ("" + lookUpEdit_Loai_Hanghoa_Mua.EditValue != "")
                objWare_Dm_Hanghoa_Mua.Id_Loai_Hanghoa_Mua = lookUpEdit_Loai_Hanghoa_Mua.EditValue;
            
            if ("" + lookUpEdit_Nhasanxuat.EditValue != "")
                objWare_Dm_Hanghoa_Mua.Id_Nhasanxuat        = lookUpEdit_Nhasanxuat.EditValue;

            if ("" + lookUpEdit_Donvitinh.EditValue != "")
                objWare_Dm_Hanghoa_Mua.Id_Donvitinh         = lookUpEdit_Donvitinh.EditValue;

            return objMasterService.Insert_Ware_Dm_Hanghoa_Mua(objWare_Dm_Hanghoa_Mua);
        }

        public object UpdateObject()
        {
            MasterService.Ware_Dm_Hanghoa_Mua objWare_Dm_Hanghoa_Mua = new SunLine.MasterTables.MasterService.Ware_Dm_Hanghoa_Mua();
            objWare_Dm_Hanghoa_Mua.Id_Hanghoa_Mua = gridView1.GetFocusedRowCellValue("Id_Hanghoa_Mua");
            objWare_Dm_Hanghoa_Mua.Ma_Hanghoa_Mua = txtMa_Hanghoa_Mua.EditValue;
            objWare_Dm_Hanghoa_Mua.Ten_Hanghoa_Mua = txtTen_Hanghoa_Mua.EditValue;
            objWare_Dm_Hanghoa_Mua.Size = "" + txtSize.EditValue;
            objWare_Dm_Hanghoa_Mua.Quycach = "" + txtQuycach.EditValue;
            objWare_Dm_Hanghoa_Mua.Barcode_Txt = txtBarcode_Txt.EditValue;
            
            if ("" + txtSoluong_Min.EditValue != "")
                objWare_Dm_Hanghoa_Mua.Soluong_Min = txtSoluong_Min.EditValue;

            if ("" + lookUpEdit_Loai_Hanghoa_Mua.EditValue != "")
                objWare_Dm_Hanghoa_Mua.Id_Loai_Hanghoa_Mua = lookUpEdit_Loai_Hanghoa_Mua.EditValue;

            if ("" + lookUpEdit_Nhasanxuat.EditValue != "")
                objWare_Dm_Hanghoa_Mua.Id_Nhasanxuat = lookUpEdit_Nhasanxuat.EditValue;

            if ("" + lookUpEdit_Donvitinh.EditValue != "")
                objWare_Dm_Hanghoa_Mua.Id_Donvitinh = lookUpEdit_Donvitinh.EditValue;

            return objMasterService.Update_Ware_Dm_Hanghoa_Mua(objWare_Dm_Hanghoa_Mua);
        }

        public object DeleteObject()
        {
            MasterService.Ware_Dm_Hanghoa_Mua objWare_Dm_Hanghoa_Mua = new SunLine.MasterTables.MasterService.Ware_Dm_Hanghoa_Mua();
            objWare_Dm_Hanghoa_Mua.Id_Hanghoa_Mua = gridView1.GetFocusedRowCellValue("Id_Hanghoa_Mua");

            return objMasterService.Delete_Ware_Dm_Hanghoa_Mua(objWare_Dm_Hanghoa_Mua);
        }

        public override bool PerformAdd()
        {
            ClearDataBindings();
            this.ChangeStatus(true);
            this.ResetText();
            return true;
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

        public override bool PerformSave()
        {
            try
            {
                bool success = false;

                System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
                hashtableControls.Add(txtMa_Hanghoa_Mua, lblMa_Hanghoa_Mua.Text);
                hashtableControls.Add(txtTen_Hanghoa_Mua, lblTen_Hanghoa_Mua.Text);
                hashtableControls.Add(lookUpEdit_Loai_Hanghoa_Mua, lblId_Loai_Hanghoa_Mua.Text);

                System.Collections.Hashtable htbBarCode = new System.Collections.Hashtable();
                htbBarCode.Add(txtBarcode_Txt, lblBarcode_Txt.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;
               
                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                {
                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htbBarCode, ds_Collection, "Barcode_Txt"))
                        return false;
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    DataSet _ds = GoobizFrame.Windows.MdiUtils.Validator.datasetFillter((DataSet)dgware_Dm_Hanghoa_Mua.DataSource, "Id_Hanghoa_Mua = " + gridView1.GetFocusedRowCellValue("Id_Hanghoa_Mua"));
                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htbBarCode, _ds, "Barcode_Txt"))
                        return false;
                    success = (bool)this.UpdateObject();
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
                    GoobizFrame.Windows.Forms.UserMessage.Show("Msg00014", new string[] { lblMa_Hanghoa_Mua.Text, lblMa_Hanghoa_Mua.Text.ToLower() });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Hanghoa_Mua"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Hanghoa_Mua"], "");
            hashtableControls.Add(gridView1.Columns["Id_Loai_Hanghoa_Mua"], "");

            System.Collections.Hashtable htbBarCode = new System.Collections.Hashtable();
            htbBarCode.Add(gridView1.Columns["Barcode_Txt"], "");

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistGrid(htbBarCode, gridView1))
                return false;
            try
            {
                dgware_Dm_Hanghoa_Mua.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                ds_Collection.Tables[0].Columns["Ma_Hanghoa_Mua"].Unique = true;
                objMasterService.Update_Ware_Dm_Hanghoa_Mua_Collection(this.ds_Collection);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("Msg00014", new string[] { lblMa_Hanghoa_Mua.Text, lblMa_Hanghoa_Mua.Text.ToLower() });
                    return false;
                }
                
                MessageBox.Show(ex.ToString());

            }
            this.DisplayInfo();
            return true;
        }

        public override bool PerformDelete()
        {
            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
            GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Dm_Hanghoa_Mua"),
            GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Dm_Hanghoa_Mua")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Ware_Dm_Hanghoa_Mua", "Id_Hanghoa_Mua", this.gridView1.GetFocusedRowCellValue("Id_Hanghoa_Mua"))) > 0)
                    {
                        GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                        return true;
                    }
                    this.DeleteObject();
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    //GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                }
                this.DisplayInfo();
            }
            return base.PerformDelete();
        }

        public override object PerformSelectOneObject()
        {
            MasterService.Ware_Dm_Hanghoa_Mua ware_Dm_Hanghoa_Mua = new SunLine.MasterTables.MasterService.Ware_Dm_Hanghoa_Mua();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Collection.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    ware_Dm_Hanghoa_Mua.Id_Hanghoa_Mua = dr["Id_Hanghoa_Mua"];
                    ware_Dm_Hanghoa_Mua.Ma_Hanghoa_Mua = dr["Ma_Hanghoa_Mua"];
                    ware_Dm_Hanghoa_Mua.Ten_Hanghoa_Mua = dr["Ten_Hanghoa_Mua"];
                    ware_Dm_Hanghoa_Mua.Size = dr["Size"];
                    ware_Dm_Hanghoa_Mua.Quycach = dr["Quycach"];
                    ware_Dm_Hanghoa_Mua.Id_Loai_Hanghoa_Mua = dr["Id_Loai_Hanghoa_Mua"];
                    ware_Dm_Hanghoa_Mua.Id_Nhasanxuat = dr["Id_Nhasanxuat"];
                    ware_Dm_Hanghoa_Mua.Id_Donvitinh = dr["Id_Donvitinh"];
                    ware_Dm_Hanghoa_Mua.Soluong_Min = dr["Soluong_Min"];
                }
                SelectedWare_Dm_Hanghoa_Mua = ware_Dm_Hanghoa_Mua;
                this.Dispose();
                this.Close();
                return ware_Dm_Hanghoa_Mua;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return null;
            }
        }

        public override bool PerformPrintPreview()
        {
            dgware_Dm_Hanghoa_Mua.ShowPrintPreview();
            return base.PerformPrintPreview();
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
                if ("" + gridView1.GetFocusedRowCellValue("Barcode_Txt") == "")
                    if (e.Column.FieldName == "Ma_Hanghoa_Mua" || e.Column.FieldName == "Id_Loai_Hanghoa_Mua")
                    {
                        DataRowView drv = (DataRowView)gridLookUpEdit_Loai_Hanghoa_Mua.GetDataSourceRowByKeyValue(gridView1.GetFocusedRowCellValue("Id_Loai_Hanghoa_Mua"));

                        gridView1.SetFocusedRowCellValue(
                            gridView1.Columns["Barcode_Txt"],
                        //    drv["Ma_Nhom_Hanghoa_Mua"]
                        //+ " "
                        //+ drv["Ma_Loai_Hanghoa_Mua"]
                        //+ " "+
                         gridView1.GetFocusedRowCellValue("Ma_Hanghoa_Mua")
                       );
                    }
                this.dgware_Dm_Hanghoa_Mua.EmbeddedNavigator.Buttons.EndEdit.DoClick();
            }
            catch(Exception ex)
            {
            }
        }

        private void gridLookUpEdit_Donvitinh_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                Frmware_Dm_Donvitinh_Add objFrmware_Dm_Donvitinh_Add = new Frmware_Dm_Donvitinh_Add();
                objFrmware_Dm_Donvitinh_Add.ShowDialog();
                objFrmware_Dm_Donvitinh_Add.Text = lblDonvitinh.Text;
                if (objFrmware_Dm_Donvitinh_Add.SelecteWware_Dm_Donvitinh != null)
                {
                    //lookUpEdit_Donvitinh
                    DataSet dsDm_Donvitinh = objFrmware_Dm_Donvitinh_Add.Data;
                    lookUpEdit_Donvitinh.Properties.DataSource = dsDm_Donvitinh.Tables[0];
                    gridLookUpEdit_Donvitinh.DataSource = dsDm_Donvitinh.Tables[0];

                    gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Donvitinh"], objFrmware_Dm_Donvitinh_Add.SelecteWware_Dm_Donvitinh.Id_Donvitinh);
                }
            }
        }

        private void txtMa_Hanghoa_Mua_EditValueChanged(object sender, EventArgs e)
        {
            if (txtBarcode_Txt.Text == "" && this.FormState != GoobizFrame.Windows.Forms.FormState.View)
                try
                {
                    txtBarcode_Txt.EditValue = "" +
                       ((DataRowView)lookUpEdit_Loai_Hanghoa_Mua.Properties.GetDataSourceRowByKeyValue(lookUpEdit_Loai_Hanghoa_Mua.EditValue))["Ma_Nhom_Hanghoa_Mua"]
                       + " "
                       + ((DataRowView)lookUpEdit_Loai_Hanghoa_Mua.Properties.GetDataSourceRowByKeyValue(lookUpEdit_Loai_Hanghoa_Mua.EditValue))["Ma_Loai_Hanghoa_Mua"]

                       + " "
                       + txtMa_Hanghoa_Mua.EditValue;
                }
                catch { }
        }

        private void lookUpEdit_Loai_Hanghoa_Mua_EditValueChanged(object sender, EventArgs e)
        {
            txtMa_Hanghoa_Mua_EditValueChanged(sender, e);
        }

        private void dgware_Dm_Hanghoa_Mua_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if (Convert.ToInt32(objMasterService.GetExistReferences("Ware_Dm_Hanghoa_Mua", "Id_Hanghoa_Mua", this.gridView1.GetFocusedRowCellValue("Id_Hanghoa_Mua"))) > 0)
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
                frmware_Dm_Loai_Hanghoa_Mua_Add.ShowDialog();

                if (frmware_Dm_Loai_Hanghoa_Mua_Add.SelectedWare_Dm_Loai_Hanghoa_Mua != null)
                {
                    gridLookUpEdit_Loai_Hanghoa_Mua.DataSource = frmware_Dm_Loai_Hanghoa_Mua_Add.Data.Tables[0];

                    gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Loai_Hanghoa_Mua"], frmware_Dm_Loai_Hanghoa_Mua_Add.SelectedWare_Dm_Loai_Hanghoa_Mua.Id_Loai_Hanghoa_Mua);
                }
            }
        }

        private void btnGen_Barcode_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                gridView1.FocusedRowHandle = i;
                if ("" + gridView1.GetFocusedRowCellValue("Barcode_Txt") == "")
                {
                    DataRowView drv = (DataRowView)gridLookUpEdit_Loai_Hanghoa_Mua.GetDataSourceRowByKeyValue(gridView1.GetFocusedRowCellValue("Id_Loai_Hanghoa_Mua"));

                    gridView1.SetFocusedRowCellValue(
                        gridView1.Columns["Barcode_Txt"],
                    //    drv["Ma_Nhom_Hanghoa_Mua"]
                    //+ " "
                    //+ drv["Ma_Loai_Hanghoa_Mua"]
                    //+ " "
                    gridView1.GetFocusedRowCellValue("Ma_Hanghoa_Mua")
                   );
                }
            }
        }

        private void gridLookUpEdit_Nhasanxuat_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                Frmware_Dm_Nhasanxuat_Add objFrmware_Dm_Nhasanxuat_Add = new Frmware_Dm_Nhasanxuat_Add();
                objFrmware_Dm_Nhasanxuat_Add.Text = lblNhasanxuat.Text;
                GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(objFrmware_Dm_Nhasanxuat_Add);
                objFrmware_Dm_Nhasanxuat_Add.ShowDialog();

                if (objFrmware_Dm_Nhasanxuat_Add.Selected_Ware_Dm_Nhasanxuat != null)
                {
                    DataSet dsNhasanxuat = objFrmware_Dm_Nhasanxuat_Add.Data;
                    lookUpEdit_Nhasanxuat.Properties.DataSource = dsNhasanxuat.Tables[0];
                    gridLookUpEdit_Nhasanxuat.DataSource = dsNhasanxuat.Tables[0];

                    gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Nhasanxuat"], objFrmware_Dm_Nhasanxuat_Add.Selected_Ware_Dm_Nhasanxuat.Id_Nhasanxuat);
                }
            }
        }
    }
}

