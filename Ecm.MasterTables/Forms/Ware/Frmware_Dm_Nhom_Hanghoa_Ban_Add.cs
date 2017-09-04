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
    public partial class Frmware_Dm_Nhom_Hanghoa_Ban_Add : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Collection = new DataSet();
        object ten_Nhom_hanghoa;

        public Frmware_Dm_Nhom_Hanghoa_Ban_Add()
        {
            InitializeComponent();
            this.DisplayInfo();
        }


        #region Event Override

        public override void DisplayInfo()
        {
            try
            {
                ds_Collection = objMasterService.Get_All_Ware_Dm_Nhom_Hanghoa_Ban().ToDataSet();
                dgware_Dm_Nhom_Hanghoa_Ban.DataSource = ds_Collection;
                dgware_Dm_Nhom_Hanghoa_Ban.DataMember = ds_Collection.Tables[0].TableName;

                this.Data = ds_Collection;
                this.GridControl = dgware_Dm_Nhom_Hanghoa_Ban;

                this.DataBindingControl();
                this.ChangeStatus(false);
                this.gridView1.BestFitColumns();

                //dgware_Dm_Nhom_Hanghoa_Ban.Enabled = true;
                //dgware_Dm_Nhom_Hanghoa_Ban.EmbeddedNavigator.Buttons.Edit.Enabled = true;
                //gridView1.OptionsBehavior.Editable = true;
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
            this.txtId_Nhom_Hanghoa_Ban.DataBindings.Clear();
            this.txtMa_Nhom_Hanghoa_Ban.DataBindings.Clear();
            this.txtTen_Nhom_Hanghoa_Ban.DataBindings.Clear();
            this.chkBc_Nxt.DataBindings.Clear();
            this.chkBc_Doanhso.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtId_Nhom_Hanghoa_Ban.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Nhom_Hanghoa_Ban");
                this.txtMa_Nhom_Hanghoa_Ban.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ma_Nhom_Hanghoa_Ban");
                this.txtTen_Nhom_Hanghoa_Ban.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ten_Nhom_Hanghoa_Ban");
                this.chkBc_Doanhso.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".bc_doanhso");
                this.chkBc_Nxt.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".bc_nxt");
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
            //this.dgware_Dm_Nhom_Hanghoa_Ban.Enabled = !editTable;          
            gridView1.OptionsBehavior.Editable = !editTable;
            this.chkBc_Doanhso.Enabled = editTable;
            this.chkBc_Nxt.Enabled = editTable;
            this.txtMa_Nhom_Hanghoa_Ban.Properties.ReadOnly = !editTable;
            this.txtTen_Nhom_Hanghoa_Ban.Properties.ReadOnly = !editTable;
        }

        public override void ResetText()
        {
            this.txtId_Nhom_Hanghoa_Ban.EditValue = "";
            this.txtMa_Nhom_Hanghoa_Ban.EditValue = "";
            this.txtTen_Nhom_Hanghoa_Ban.EditValue = "";
            this.chkBc_Nxt.Checked = false;
            this.chkBc_Doanhso.Checked = false;
        }

        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Nhom_Hanghoa_Ban objWare_Dm_Nhom_Hanghoa_Ban = new Ecm.WebReferences.MasterService.Ware_Dm_Nhom_Hanghoa_Ban();
            objWare_Dm_Nhom_Hanghoa_Ban.Id_Nhom_Hanghoa_Ban = -1;
            objWare_Dm_Nhom_Hanghoa_Ban.Ma_Nhom_Hanghoa_Ban = txtMa_Nhom_Hanghoa_Ban.EditValue;
            objWare_Dm_Nhom_Hanghoa_Ban.Ten_Nhom_Hanghoa_Ban = txtTen_Nhom_Hanghoa_Ban.EditValue;
            objWare_Dm_Nhom_Hanghoa_Ban.Bc_Doanhso = chkBc_Doanhso.EditValue;
            objWare_Dm_Nhom_Hanghoa_Ban.Bc_Nguyenlieu_Chebien = DBNull.Value;
            objWare_Dm_Nhom_Hanghoa_Ban.Bc_Nxt = chkBc_Nxt.EditValue;

            return objMasterService.Insert_Ware_Dm_Nhom_Hanghoa_Ban(objWare_Dm_Nhom_Hanghoa_Ban);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Nhom_Hanghoa_Ban objWare_Dm_Nhom_Hanghoa_Ban = new Ecm.WebReferences.MasterService.Ware_Dm_Nhom_Hanghoa_Ban();
            objWare_Dm_Nhom_Hanghoa_Ban.Id_Nhom_Hanghoa_Ban = gridView1.GetFocusedRowCellValue("Id_Nhom_Hanghoa_Ban");
            objWare_Dm_Nhom_Hanghoa_Ban.Ma_Nhom_Hanghoa_Ban = txtMa_Nhom_Hanghoa_Ban.EditValue;
            objWare_Dm_Nhom_Hanghoa_Ban.Ten_Nhom_Hanghoa_Ban = txtTen_Nhom_Hanghoa_Ban.EditValue;

            if (chkBc_Doanhso.EditValue.ToString() == "")
                objWare_Dm_Nhom_Hanghoa_Ban.Bc_Doanhso = false;
            else
                objWare_Dm_Nhom_Hanghoa_Ban.Bc_Doanhso = chkBc_Doanhso.EditValue;

            objWare_Dm_Nhom_Hanghoa_Ban.Bc_Nguyenlieu_Chebien = DBNull.Value;

            if (chkBc_Nxt.EditValue.ToString() == "")
                objWare_Dm_Nhom_Hanghoa_Ban.Bc_Nxt = false;
            else
                objWare_Dm_Nhom_Hanghoa_Ban.Bc_Nxt = chkBc_Nxt.EditValue;

            return objMasterService.Update_Ware_Dm_Nhom_Hanghoa_Ban(objWare_Dm_Nhom_Hanghoa_Ban);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Nhom_Hanghoa_Ban objWare_Dm_Nhom_Hanghoa_Ban = new Ecm.WebReferences.MasterService.Ware_Dm_Nhom_Hanghoa_Ban();
            objWare_Dm_Nhom_Hanghoa_Ban.Id_Nhom_Hanghoa_Ban = gridView1.GetFocusedRowCellValue("Id_Nhom_Hanghoa_Ban");

            return objMasterService.Delete_Ware_Dm_Nhom_Hanghoa_Ban(objWare_Dm_Nhom_Hanghoa_Ban);
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
            ten_Nhom_hanghoa = gridView1.GetFocusedRowCellValue("Id_Nhom_Hanghoa_Ban");
            return true;
        }

        public override bool PerformCancel()
        {
            this.DisplayInfo();
            return true;
        }

        public override bool PerformSave()
        {
            try
            {
                bool success = false;
                GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(txtMa_Nhom_Hanghoa_Ban, lblMa_Nhom_Hanghoa_Ban.Text);
                hashtableControls.Add(txtTen_Nhom_Hanghoa_Ban, lblTen_Nhom_Hanghoa_Ban.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                this.dgware_Dm_Nhom_Hanghoa_Ban.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Nhom_Hanghoa_Ban.EmbeddedNavigator.Buttons.EndEdit);

                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                {
                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, ds_Collection, "Ma_Nhom_Hanghoa_Ban"))
                        return false;

                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, ds_Collection, "ten_nhom_hanghoa_ban"))
                        return false;
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    ds_Collection = GoobizFrame.Windows.MdiUtils.Validator.datasetFillter(ds_Collection,
                                        "id_nhom_hanghoa_ban = " + gridView1.GetFocusedRowCellValue("Id_Nhom_Hanghoa_Ban"));

                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, ds_Collection, "ten_nhom_hanghoa_ban"))
                        return false;

                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, ds_Collection, "Ma_Nhom_Hanghoa_Ban"))
                        return false;

                    success = (bool)this.UpdateObject();
                }
                if (success)
                    this.DisplayInfo();
                return success;
            }
            catch (Exception ex)
            {
                ex.ToString();
                //if (ex.ToString().IndexOf("exists") != -1)
                //{
                //     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Nhom_Hanghoa_Ban.Text, lblMa_Nhom_Hanghoa_Ban.Text.ToLower() });
                //}
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Nhom_Hanghoa_Ban"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Nhom_Hanghoa_Ban"], "");

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistGrid(hashtableControls, gridView1))
                return false;
            try
            {
                dgware_Dm_Nhom_Hanghoa_Ban.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Nhom_Hanghoa_Ban.EmbeddedNavigator.Buttons.EndEdit);
                //ds_Collection.Tables[0].Columns["Ma_Nhom_Hanghoa_Ban"].Unique = true;
                //ds_Collection.Tables[0].Columns["Ten_Nhom_Hanghoa_Ban"].Unique = true;
                objMasterService.Update_Ware_Dm_Nhom_Hanghoa_Ban_Collection(this.ds_Collection);
            }
            catch (Exception ex)
            {

                //if (ex.ToString().IndexOf("Unique") == 133)
                //{
                //     GoobizFrame.Windows.Forms.MessageDialog.Show("Tên nhóm hàng hóa đã tồn tại, vui lòng nhập lại ");
                //    return false;
                //}
                //if (ex.ToString().IndexOf("Unique") != -1)
                //{
                //     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Nhom_Hanghoa_Ban.Text, lblMa_Nhom_Hanghoa_Ban.Text.ToLower() });
                //    return false;
                //}
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
            this.DisplayInfo();
            return true;
        }

        public override bool PerformDelete()
        {
            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Dm_Nhom_Hanghoa_Ban"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Dm_Nhom_Hanghoa_Ban")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Ware_Dm_Nhom_Hanghoa_Ban", "Id_Nhom_Hanghoa_Ban", this.gridView1.GetFocusedRowCellValue("Id_Nhom_Hanghoa_Ban"))) > 0)
                    {
                        GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                        return true;
                    }
                    this.DeleteObject();
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    // GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                    //if (ex.ToString().IndexOf("FK") != -1)
                    //{
                    GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    //}
                }
                this.DisplayInfo();
            }
            return base.PerformDelete();
        }

        public override object PerformSelectOneObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Nhom_Hanghoa_Ban ware_Dm_Nhom_Hanghoa_Ban = new Ecm.WebReferences.MasterService.Ware_Dm_Nhom_Hanghoa_Ban();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Collection.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    ware_Dm_Nhom_Hanghoa_Ban.Id_Nhom_Hanghoa_Ban = dr["Id_Nhom_Hanghoa_Ban"];
                    ware_Dm_Nhom_Hanghoa_Ban.Ma_Nhom_Hanghoa_Ban = dr["Ma_Nhom_Hanghoa_Ban"];
                    ware_Dm_Nhom_Hanghoa_Ban.Ten_Nhom_Hanghoa_Ban = dr["Ten_Nhom_Hanghoa_Ban"];
                }
                this.Dispose();
                this.Close();
                return ware_Dm_Nhom_Hanghoa_Ban;
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

        #region Even

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Nhom_Hanghoa_Ban"];
            this.addnewrow_clicked = true;
            //ClearDataBindings();
            //this.ChangeStatus(true);
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.dgware_Dm_Nhom_Hanghoa_Ban.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Nhom_Hanghoa_Ban.EmbeddedNavigator.Buttons.EndEdit);
        }

        private void dgware_Dm_Nhom_Hanghoa_Ban_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + this.gridView1.GetFocusedRowCellValue("Id_Nhom_Hanghoa_Ban") != "")
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Ware_Dm_Nhom_Hanghoa_Ban", "Id_Nhom_Hanghoa_Ban", this.gridView1.GetFocusedRowCellValue("Id_Nhom_Hanghoa_Ban"))) > 0)
                    {
                        GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                        e.Handled = true;
                    }
            }
        }

        private void txtMa_Nhom_Hanghoa_Ban_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;

        }
        #endregion



    }
}

