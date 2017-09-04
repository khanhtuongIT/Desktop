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
    public partial class Frmware_Dm_Xe_Add : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Collection = new DataSet();
        object Ten_Khohang = null;
        public Ecm.WebReferences.MasterService.Ware_Dm_Xe ware_Dm_Xe;

        public Frmware_Dm_Xe_Add()
        {
            InitializeComponent();
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                ds_Collection = objMasterService.GetAll_Ware_Dm_Xe().ToDataSet();
                dgware_Dm_Xe.DataSource = ds_Collection;
                dgware_Dm_Xe.DataMember = ds_Collection.Tables[0].TableName;

                this.Data = ds_Collection;
                this.GridControl = dgware_Dm_Xe;
                this.DataBindingControl();

                this.ChangeStatus(false);
                dgware_Dm_Xe.Enabled = true;
                this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                //// GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }
        }

        public override void ClearDataBindings()
        {
            this.txtMa_Xe.DataBindings.Clear();
            this.txtTen_Xe.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtMa_Xe.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ma_Xe");
                this.txtTen_Xe.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ten_Xe");
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                ////// GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }
        }

        public override void ChangeStatus(bool editTable)
        {
            this.gridView1.OptionsBehavior.Editable = !editTable;
            //this.dgware_Dm_Xe.Enabled = !editTable;
            this.txtMa_Xe.Properties.ReadOnly = !editTable;
            this.txtTen_Xe.Properties.ReadOnly = !editTable;
        }

        public override void ResetText()
        {
            this.txtMa_Xe.EditValue = null;
            this.txtTen_Xe.EditValue = null;
        }

        #region Event Override

        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Xe objWare_Dm_Xe = new Ecm.WebReferences.MasterService.Ware_Dm_Xe();
            objWare_Dm_Xe.Id_Xe = -1;
            objWare_Dm_Xe.Ma_Xe = txtMa_Xe.EditValue;
            objWare_Dm_Xe.Ten_Xe = txtTen_Xe.EditValue;
            return objMasterService.Insert_Ware_Dm_Xe(objWare_Dm_Xe);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Xe objWare_Dm_Xe = new Ecm.WebReferences.MasterService.Ware_Dm_Xe();
            objWare_Dm_Xe.Id_Xe = gridView1.GetFocusedRowCellValue("Id_Xe");
            objWare_Dm_Xe.Ma_Xe = txtMa_Xe.EditValue;
            objWare_Dm_Xe.Ten_Xe = txtTen_Xe.EditValue;
            return objMasterService.Update_Ware_Dm_Xe(objWare_Dm_Xe);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Xe objWare_Dm_Xe = new Ecm.WebReferences.MasterService.Ware_Dm_Xe();
            objWare_Dm_Xe.Id_Xe = gridView1.GetFocusedRowCellValue("Id_Xe");
            return objMasterService.Delete_Ware_Dm_Xe(objWare_Dm_Xe);
        }

        public override bool PerformAdd()
        {
            ClearDataBindings();
            this.ChangeStatus(true);
            this.ResetText();
            //dgware_Dm_Xe.Enabled = false;
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
                GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(txtMa_Xe, lblMa_Xe.Text);
                hashtableControls.Add(txtTen_Xe, lblTen_Xe.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                hashtableControls.Remove(txtMa_Xe);
                //if (!txtTen_Xe.EditValue.Equals(Ten_Khohang))
                //{
                //    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htbTen_Cuahang, ds_Collection, "Ten_Xe"))
                //        return false;
                //}

                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                {
                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, ds_Collection, "Ten_Xe"))
                        return false;
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    if (!txtTen_Xe.EditValue.Equals(Ten_Khohang))
                    {
                        if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, ds_Collection, "Ten_Xe"))
                            return false;
                    }
                    success = (bool)this.UpdateObject();
                }

                if (success)
                {
                    Ten_Khohang = null;
                    this.DisplayInfo();
                }
                return success;
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("exists") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Xe.Text, lblMa_Xe.Text.ToLower() });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Xe"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Xe"], "");

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgware_Dm_Xe.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Xe.EmbeddedNavigator.Buttons.EndEdit);
                this.ds_Collection.Tables[0].Columns["Ma_Xe"].Unique = true;
                objMasterService.Update_Ware_Dm_Xe_Collection(this.ds_Collection);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Xe.Text, lblMa_Xe.Text.ToLower() });
                    return false;
                }
                //MessageBox.Show(ex.ToString());
            }
            this.DisplayInfo();
            return true;
        }

        public override bool PerformDelete()
        {
            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Dm_Xe"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Dm_Xe")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Ware_Dm_Xe", "Id_Xe", this.gridView1.GetFocusedRowCellValue("Id_Xe"))) > 0)
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
            try
            {
                ware_Dm_Xe = new Ecm.WebReferences.MasterService.Ware_Dm_Xe();
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Collection.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    ware_Dm_Xe.Id_Xe = dr["Id_Xe"];
                    ware_Dm_Xe.Ma_Xe = dr["Ma_Xe"];
                    ware_Dm_Xe.Ten_Xe = dr["Ten_Xe"];
                }
                this.Dispose();
                this.Close();
                return ware_Dm_Xe;
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

        #region events

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Xe"];
            this.addnewrow_clicked = true;
            this.gridView1.OptionsBehavior.Editable = true;
            gridView1.SetFocusedRowCellValue("Kho_Hang", false);
            this.ChangeFormState(GoobizFrame.Windows.Forms.FormState.Add);
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.dgware_Dm_Xe.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Xe.EmbeddedNavigator.Buttons.EndEdit);
        }

        private void dgware_Dm_Xe_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + this.gridView1.GetFocusedRowCellValue("Id_Xe") != "")
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Ware_Dm_Xe", "Id_Xe", this.gridView1.GetFocusedRowCellValue("Id_Xe"))) > 0)
                    {
                        GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                        e.Handled = true;
                    }
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Ten_Khohang = gridView1.GetFocusedRowCellValue("Ten_Xe");
        }

        private void txtMa_Xe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;
        }

        #endregion

    }
}

