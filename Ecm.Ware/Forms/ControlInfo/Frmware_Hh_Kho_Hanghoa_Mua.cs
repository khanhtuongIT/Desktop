using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunLine.Ware.Forms
{
    public partial class Frmware_Hh_Kho_Hanghoa_Mua : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public WareService.WareService objWareService = new SunLine.Ware.WareService.WareService();
        public MasterService.MasterService objMasterService = new SunLine.Ware.MasterService.MasterService();
        DataSet ds_Collection = new DataSet();

        public Frmware_Hh_Kho_Hanghoa_Mua()
        {
            InitializeComponent();
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                //Get data Ware_Hanghoa_Mua
                DataSet dsWare_Hanghoa_Mua = objMasterService.Get_All_Ware_Dm_Hanghoa_Mua();
                lookUpEdit_Hanghoa_Mua.Properties.DataSource = dsWare_Hanghoa_Mua.Tables[0];
                gridLookUpEdit_Hanghoa_Mua.DataSource = dsWare_Hanghoa_Mua.Tables[0];

                //Get data Ware_Kho_Hanghoa_Mua
                DataSet dsWare_Kho_Hanghoa_Mua = objMasterService.Get_All_Ware_Dm_Kho_Hanghoa_Mua();
                lookUpEdit_Kho_Hanghoa_Mua.Properties.DataSource = dsWare_Kho_Hanghoa_Mua.Tables[0];
                gridLookUpEdit_Kho_Hanghoa_Mua.DataSource = dsWare_Kho_Hanghoa_Mua.Tables[0];
                dgware_Dm_Kho_Hanghoa_Mua.DataSource = dsWare_Kho_Hanghoa_Mua.Tables[0];

                gridLookUpEdit_Loai_Hanghoa_Mua.DataSource = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Mua().Tables[0];

                //Get data Ware_Hh_Kho_Hanghoa_Mua
                ds_Collection = objWareService.Get_All_Ware_Hh_Kho_Hanghoa_Mua();
                dgware_Hh_Kho_Hanghoa_Mua.DataSource = ds_Collection;
                dgware_Hh_Kho_Hanghoa_Mua.DataMember = ds_Collection.Tables[0].TableName;

                this.Data = ds_Collection;
                this.GridControl = dgware_Hh_Kho_Hanghoa_Mua;

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
            this.txtId_Hh_Kho_Hanghoa_Mua.DataBindings.Clear();
            this.txtGhichu.DataBindings.Clear();

            this.lookUpEdit_Kho_Hanghoa_Mua.DataBindings.Clear();
            this.lookUpEdit_Hanghoa_Mua.DataBindings.Clear();
        }

        public void DataBindingControl()
        {
            try
            {
                ClearDataBindings();

                this.txtId_Hh_Kho_Hanghoa_Mua.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Hh_Kho_Hanghoa_Mua");
                this.txtGhichu.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ghichu");

                this.lookUpEdit_Kho_Hanghoa_Mua.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Kho_Hanghoa_Mua");
                this.lookUpEdit_Hanghoa_Mua.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Hanghoa_Mua");
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
            this.dgware_Hh_Kho_Hanghoa_Mua.Enabled = !editTable;
            this.txtGhichu.Properties.ReadOnly = !editTable;
            this.lookUpEdit_Kho_Hanghoa_Mua.Properties.ReadOnly = !editTable;
            this.lookUpEdit_Hanghoa_Mua.Properties.ReadOnly = !editTable;
        }

        public void ResetText()
        {
            this.txtId_Hh_Kho_Hanghoa_Mua.EditValue = "";
            this.txtGhichu.EditValue                = "";

            this.lookUpEdit_Kho_Hanghoa_Mua.EditValue   = null;
            this.lookUpEdit_Hanghoa_Mua.EditValue       = null;
        }

        #region Event Override
        public object InsertObject()
        {
            WareService.Ware_Hh_Kho_Hanghoa_Mua objWare_Hh_Kho_Hanghoa_Mua = new SunLine.Ware.WareService.Ware_Hh_Kho_Hanghoa_Mua();
            objWare_Hh_Kho_Hanghoa_Mua.Id_Hh_Kho_Hanghoa_Mua = -1;
            objWare_Hh_Kho_Hanghoa_Mua.Ghichu = txtGhichu.EditValue;

            if ("" + lookUpEdit_Kho_Hanghoa_Mua.EditValue != "")
                objWare_Hh_Kho_Hanghoa_Mua.Id_Kho_Hanghoa_Mua = lookUpEdit_Kho_Hanghoa_Mua.EditValue;
            if ("" + lookUpEdit_Hanghoa_Mua.EditValue != "")
                objWare_Hh_Kho_Hanghoa_Mua.Id_Hanghoa_Mua = lookUpEdit_Hanghoa_Mua.EditValue;

            return objWareService.Insert_Ware_Hh_Kho_Hanghoa_Mua(objWare_Hh_Kho_Hanghoa_Mua);
        }

        public object UpdateObject()
        {
            WareService.Ware_Hh_Kho_Hanghoa_Mua objWare_Hh_Kho_Hanghoa_Mua = new SunLine.Ware.WareService.Ware_Hh_Kho_Hanghoa_Mua();
            objWare_Hh_Kho_Hanghoa_Mua.Id_Hh_Kho_Hanghoa_Mua = gridView1.GetFocusedRowCellValue("Id_Hh_Kho_Hanghoa_Mua");
            objWare_Hh_Kho_Hanghoa_Mua.Ghichu = txtGhichu.EditValue;

            if ("" + lookUpEdit_Kho_Hanghoa_Mua.EditValue != "")
                objWare_Hh_Kho_Hanghoa_Mua.Id_Kho_Hanghoa_Mua = lookUpEdit_Kho_Hanghoa_Mua.EditValue;
            if ("" + lookUpEdit_Hanghoa_Mua.EditValue != "")
                objWare_Hh_Kho_Hanghoa_Mua.Id_Hanghoa_Mua = lookUpEdit_Hanghoa_Mua.EditValue;

            return objWareService.Update_Ware_Hh_Kho_Hanghoa_Mua(objWare_Hh_Kho_Hanghoa_Mua);
        }

        public object DeleteObject()
        {
            WareService.Ware_Hh_Kho_Hanghoa_Mua objWare_Hh_Kho_Hanghoa_Mua = new SunLine.Ware.WareService.Ware_Hh_Kho_Hanghoa_Mua();
            objWare_Hh_Kho_Hanghoa_Mua.Id_Hh_Kho_Hanghoa_Mua = gridView1.GetFocusedRowCellValue("Id_Hh_Kho_Hanghoa_Mua");

            return objWareService.Delete_Ware_Hh_Kho_Hanghoa_Mua(objWare_Hh_Kho_Hanghoa_Mua);
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
                hashtableControls.Add(lookUpEdit_Kho_Hanghoa_Mua, lblId_Kho_Hanghoa_Mua.Text);
                hashtableControls.Add(lookUpEdit_Hanghoa_Mua, lblId_Hanghoa_Mua.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                {
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                {
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
                    GoobizFrame.Windows.Forms.UserMessage.Show("Msg00014", new string[] { lblId_Hanghoa_Mua.Text, lblId_Hanghoa_Mua.Text.ToLower() });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(gridView1.Columns["Id_Hanghoa_Mua"], "");
            hashtableControls.Add(gridView1.Columns["Id_Kho_Hanghoa_Mua"], "");

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistGridOnComplex(new string[] { "Id_Kho_Hanghoa_Mua", "Id_Hanghoa_Mua" }, gridView1))
                return false;
            try
            {
                dgware_Hh_Kho_Hanghoa_Mua.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                objWareService.Update_Ware_Hh_Kho_Hanghoa_Mua_Collection(this.ds_Collection);
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#endif
                //Error here
                GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                return false;
            }
            this.DisplayInfo();
            return true;
        }

        public override bool PerformDelete()
        {
            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
            GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Hh_Kho_Hanghoa_Mua"),
            GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Hh_Kho_Hanghoa_Mua")   }) == DialogResult.Yes)
            {
                try
                {
                    this.DeleteObject();
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                }
                this.DisplayInfo();
            }
            return base.PerformDelete();
        }

        public override object PerformSelectOneObject()
        {
            WareService.Ware_Hh_Kho_Hanghoa_Mua ware_Hh_Kho_Hanghoa_Mua = new SunLine.Ware.WareService.Ware_Hh_Kho_Hanghoa_Mua();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Collection.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    ware_Hh_Kho_Hanghoa_Mua.Id_Hh_Kho_Hanghoa_Mua = dr["Id_Hh_Kho_Hanghoa_Mua"];
                    ware_Hh_Kho_Hanghoa_Mua.Id_Hanghoa_Mua = dr["Id_Hanghoa_Mua"];
                    ware_Hh_Kho_Hanghoa_Mua.Id_Kho_Hanghoa_Mua = dr["Id_Kho_Hanghoa_Mua"];
                    ware_Hh_Kho_Hanghoa_Mua.Ghichu = dr["Ghichu"];
                }
                this.Dispose();
                this.Close();
                return ware_Hh_Kho_Hanghoa_Mua;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return null;
            }
        }
        #endregion

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Id_Hanghoa_Mua")
            {
                gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Loai_Hanghoa_Mua"]
                    , ((System.Data.DataRowView)gridLookUpEdit_Hanghoa_Mua.GetDataSourceRowByKeyValue(e.Value))["Id_Loai_Hanghoa_Mua"]);
                gridView1.SetFocusedRowCellValue(gridView1.Columns["Ten_Hanghoa_Mua"]
                    , ((System.Data.DataRowView)gridLookUpEdit_Hanghoa_Mua.GetDataSourceRowByKeyValue(e.Value))["Ten_Hanghoa_Mua"]);
            }
            this.dgware_Hh_Kho_Hanghoa_Mua.EmbeddedNavigator.Buttons.EndEdit.DoClick();
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Id_Hh_Kho_Hanghoa_Mua"];
            gridView1.SetRowCellValue(e.RowHandle, "Id_Kho_Hanghoa_Mua", gridView2.GetFocusedRowCellValue("Id_Kho_Hanghoa_Mua"));
            this.addnewrow_clicked = true;
        }

        //private void gridLookUpEdit_Hanghoa_Mua_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{
        //    if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
        //    {
        //        //SunLine.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Mua_Dialog frmware_Dm_Hanghoa_Mua_Dialog = new SunLine.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Mua_Dialog();
        //        frmware_Dm_Hanghoa_Mua_Dialog.Text = "Hàng hóa";
        //        GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmware_Dm_Hanghoa_Mua_Dialog);
        //        frmware_Dm_Hanghoa_Mua_Dialog.ShowDialog();

        //        if (frmware_Dm_Hanghoa_Mua_Dialog.SelectedRows != null
        //            && frmware_Dm_Hanghoa_Mua_Dialog.SelectedRows.Length > 0)
        //        {
        //            //gridLookUpEdit_Hanghoa_Mua.DataSource = frmware_Dm_Hanghoa_Mua_Dialog.Data.Tables[0];

        //            gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Hanghoa_Mua"]
        //                , frmware_Dm_Hanghoa_Mua_Dialog.SelectedRows[0]["Id_Hanghoa_Mua"]);

        //            object Id_Kho_Hanghoa_Mua = gridView1.GetFocusedRowCellValue("Id_Kho_Hanghoa_Mua");
        //            if (frmware_Dm_Hanghoa_Mua_Dialog.SelectedRows.Length > 1)
        //            {
        //                for (int i = 1; i < frmware_Dm_Hanghoa_Mua_Dialog.SelectedRows.Length; i++)
        //                {
        //                    DataRow nrow = ds_Collection.Tables[0].NewRow();
        //                    nrow["Id_Kho_Hanghoa_Mua"] = Id_Kho_Hanghoa_Mua;
        //                    nrow["Id_Hanghoa_Mua"] = frmware_Dm_Hanghoa_Mua_Dialog.SelectedRows[i]["Id_Hanghoa_Mua"];
        //                    ds_Collection.Tables[0].Rows.Add(nrow);
        //                }
        //            }
        //        }
        //    }
        //}

        private void dgware_Dm_Kho_Hanghoa_Mua_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {

        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView2.FocusedRowHandle >= 0)
                gridView1.Columns["Id_Kho_Hanghoa_Mua"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                gridView1.Columns["Id_Kho_Hanghoa_Mua"], gridView2.GetFocusedRowCellValue("Id_Kho_Hanghoa_Mua")
                );
        }
    }
}

