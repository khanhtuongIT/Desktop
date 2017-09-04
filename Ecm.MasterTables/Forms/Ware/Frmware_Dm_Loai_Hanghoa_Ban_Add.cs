using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Ware
{
    public partial class Frmware_Dm_Loai_Hanghoa_Ban_Add : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Collection = new DataSet();
        object Ten_Loai_Hanghoa = null;
        public Ecm.WebReferences.MasterService.Ware_Dm_Loai_Hanghoa_Ban SelectedWare_Dm_Loai_Hanghoa_Ban;
        Frmware_Dm_Nhom_Hanghoa_Ban_Add frmware_Dm_Nhom_Hanghoa_Ban_Add = new Frmware_Dm_Nhom_Hanghoa_Ban_Add();

        public Frmware_Dm_Loai_Hanghoa_Ban_Add()
        {
            InitializeComponent();
            this.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                ds_Collection = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Ban().ToDataSet();
                dgware_Dm_Loai_Hanghoa_Ban.DataSource = ds_Collection;
                dgware_Dm_Loai_Hanghoa_Ban.DataMember = ds_Collection.Tables[0].TableName;

                this.Data = ds_Collection;
                this.GridControl = dgware_Dm_Loai_Hanghoa_Ban;
                this.DataBindingControl();
                this.ChangeStatus(false);
                dgware_Dm_Loai_Hanghoa_Ban.Enabled = true;
                this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                // GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }
        }

        public override void ClearDataBindings()
        {
            this.txtMa_Loai_Hanghoa_Ban.DataBindings.Clear();
            this.txtTen_Loai_Hanghoa_Ban.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtMa_Loai_Hanghoa_Ban.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ma_Loai_Hanghoa_Ban");
                this.txtTen_Loai_Hanghoa_Ban.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ten_Loai_Hanghoa_Ban");
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                // GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }
        }

        public override void ChangeStatus(bool editTable)
        {
            //this.dgware_Dm_Loai_Hanghoa_Ban.Enabled = !editTable;
            gridView1.OptionsBehavior.Editable = !editTable;
            this.txtMa_Loai_Hanghoa_Ban.Properties.ReadOnly = !editTable;
            this.txtTen_Loai_Hanghoa_Ban.Properties.ReadOnly = !editTable;
        }

        public override void ResetText()
        {
            this.txtMa_Loai_Hanghoa_Ban.EditValue = "";
            this.txtTen_Loai_Hanghoa_Ban.EditValue = "";
        }

        #region Event Override
        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Loai_Hanghoa_Ban objWare_Dm_Loai_Hanghoa_Ban = new Ecm.WebReferences.MasterService.Ware_Dm_Loai_Hanghoa_Ban();
            objWare_Dm_Loai_Hanghoa_Ban.Id_Loai_Hanghoa_Ban = -1;
            objWare_Dm_Loai_Hanghoa_Ban.Ma_Loai_Hanghoa_Ban = txtMa_Loai_Hanghoa_Ban.EditValue;
            objWare_Dm_Loai_Hanghoa_Ban.Ten_Loai_Hanghoa_Ban = txtTen_Loai_Hanghoa_Ban.EditValue;
            return objMasterService.Insert_Ware_Dm_Loai_Hanghoa_Ban(objWare_Dm_Loai_Hanghoa_Ban);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Loai_Hanghoa_Ban objWare_Dm_Loai_Hanghoa_Ban = new Ecm.WebReferences.MasterService.Ware_Dm_Loai_Hanghoa_Ban();
            objWare_Dm_Loai_Hanghoa_Ban.Id_Loai_Hanghoa_Ban = gridView1.GetFocusedRowCellValue("Id_Loai_Hanghoa_Ban");
            objWare_Dm_Loai_Hanghoa_Ban.Ma_Loai_Hanghoa_Ban = txtMa_Loai_Hanghoa_Ban.EditValue;
            objWare_Dm_Loai_Hanghoa_Ban.Ten_Loai_Hanghoa_Ban = txtTen_Loai_Hanghoa_Ban.EditValue;
            return objMasterService.Update_Ware_Dm_Loai_Hanghoa_Ban(objWare_Dm_Loai_Hanghoa_Ban);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Loai_Hanghoa_Ban objWare_Dm_Loai_Hanghoa_Ban = new Ecm.WebReferences.MasterService.Ware_Dm_Loai_Hanghoa_Ban();
            objWare_Dm_Loai_Hanghoa_Ban.Id_Loai_Hanghoa_Ban = gridView1.GetFocusedRowCellValue("Id_Loai_Hanghoa_Ban");
            return objMasterService.Delete_Ware_Dm_Loai_Hanghoa_Ban(objWare_Dm_Loai_Hanghoa_Ban);
        }

        public override bool PerformAdd()
        {
            ClearDataBindings();
            this.ChangeStatus(true);
            //dgware_Dm_Loai_Hanghoa_Ban.Enabled = false;
            this.ResetText();
            return true;
        }

        public override bool PerformEdit()
        {
            this.ChangeStatus(true);
            return base.PerformEdit();
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

                GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(txtMa_Loai_Hanghoa_Ban, lblMa_Loai_Hanghoa_Ban.Text);
                hashtableControls.Add(txtTen_Loai_Hanghoa_Ban, lblTen_Loai_Hanghoa_Ban.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                hashtableControls.Remove(txtMa_Loai_Hanghoa_Ban);

                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                {
                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, ds_Collection, "Ten_Loai_Hanghoa_Ban"))
                        return false;
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    if (!txtTen_Loai_Hanghoa_Ban.EditValue.Equals(Ten_Loai_Hanghoa))
                    {
                        if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, ds_Collection, "Ten_Loai_Hanghoa_Ban"))
                            return false;
                    }
                    success = (bool)this.UpdateObject();
                }

                if (success)
                {
                    Ten_Loai_Hanghoa = null;
                    this.DisplayInfo();
                }
                return success;
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("exists") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Loai_Hanghoa_Ban.Text, lblMa_Loai_Hanghoa_Ban.Text.ToLower() });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Loai_Hanghoa_Ban"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Loai_Hanghoa_Ban"], "");

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistGrid(hashtableControls, gridView1))
                return false;

            hashtableControls.Add(gridView1.Columns["Id_Nhom_Hanghoa_Ban"], "");
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgware_Dm_Loai_Hanghoa_Ban.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Loai_Hanghoa_Ban.EmbeddedNavigator.Buttons.EndEdit);
                ds_Collection.Tables[0].Columns["Ma_Loai_Hanghoa_Ban"].Unique = true;
                objMasterService.Update_Ware_Dm_Loai_Hanghoa_Ban_Collection(this.ds_Collection);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Loai_Hanghoa_Ban.Text, lblMa_Loai_Hanghoa_Ban.Text.ToLower() });
                }
                //MessageBox.Show(ex.ToString());
            }
            this.DisplayInfo();
            return true;
        }

        public override bool PerformDelete()
        {
            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Dm_Loai_Hanghoa_Ban"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Dm_Loai_Hanghoa_Ban")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Ware_Dm_Loai_Hanghoa_Ban", "Id_Loai_Hanghoa_Ban", this.gridView1.GetFocusedRowCellValue("Id_Loai_Hanghoa_Ban"))) > 0)
                    {
                        GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                        return true;
                    }
                    this.DeleteObject();
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    // GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                }
                this.DisplayInfo();
            }
            return base.PerformDelete();
        }

        public override object PerformSelectOneObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Loai_Hanghoa_Ban ware_Dm_Loai_Hanghoa_Ban = new Ecm.WebReferences.MasterService.Ware_Dm_Loai_Hanghoa_Ban();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Collection.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    ware_Dm_Loai_Hanghoa_Ban.Id_Loai_Hanghoa_Ban = dr["Id_Loai_Hanghoa_Ban"];
                    ware_Dm_Loai_Hanghoa_Ban.Ma_Loai_Hanghoa_Ban = dr["Ma_Loai_Hanghoa_Ban"];
                    ware_Dm_Loai_Hanghoa_Ban.Ten_Loai_Hanghoa_Ban = dr["Ten_Loai_Hanghoa_Ban"];
                    ware_Dm_Loai_Hanghoa_Ban.Id_Nhom_Hanghoa_Ban = dr["Id_Nhom_Hanghoa_Ban"];
                }
                SelectedWare_Dm_Loai_Hanghoa_Ban = ware_Dm_Loai_Hanghoa_Ban;
                this.Dispose();
                this.Close();
                return ware_Dm_Loai_Hanghoa_Ban;
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

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Loai_Hanghoa_Ban"];
            gridView1.SetFocusedRowCellValue("Id_Nhom_Hanghoa_Ban", 3);
            this.addnewrow_clicked = true;
            this.gridView1.OptionsBehavior.Editable = true;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.dgware_Dm_Loai_Hanghoa_Ban.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Loai_Hanghoa_Ban.EmbeddedNavigator.Buttons.EndEdit);
        }

        private void dgware_Dm_Loai_Hanghoa_Ban_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + this.gridView1.GetFocusedRowCellValue("Id_Loai_Hanghoa_Ban") != "")
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Ware_Dm_Loai_Hanghoa_Ban", "Id_Loai_Hanghoa_Ban", this.gridView1.GetFocusedRowCellValue("Id_Loai_Hanghoa_Ban"))) > 0)
                    {
                        GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                        e.Handled = true;
                    }
            }
        }

        private void btnNhom_Hanghoa_Ban_Click(object sender, EventArgs e)
        {
            if (frmware_Dm_Nhom_Hanghoa_Ban_Add.IsDisposed || frmware_Dm_Nhom_Hanghoa_Ban_Add == null)
                frmware_Dm_Nhom_Hanghoa_Ban_Add = new Frmware_Dm_Nhom_Hanghoa_Ban_Add();
            GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmware_Dm_Nhom_Hanghoa_Ban_Add);
            GoobizFrame.Windows.PlugIn.RightHelpers.CheckUserRightAction(frmware_Dm_Nhom_Hanghoa_Ban_Add);
            frmware_Dm_Nhom_Hanghoa_Ban_Add.Text = "Thêm Nhóm Hàng hóa";
            frmware_Dm_Nhom_Hanghoa_Ban_Add.Show();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Ten_Loai_Hanghoa = gridView1.GetFocusedRowCellValue("Ten_Loai_Hanghoa_Ban");
        }

        private void txtMa_Loai_Hanghoa_Ban_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;

        }
    }
}

