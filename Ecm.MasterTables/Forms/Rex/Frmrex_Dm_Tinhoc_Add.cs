using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Rex
{

    public partial class Frmrex_Dm_Tinhoc_Add : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Tinhoc = new DataSet();
        public Ecm.WebReferences.MasterService.Rex_Dm_Tinhoc Selected_Rex_Dm_Tinhoc;

        public Frmrex_Dm_Tinhoc_Add()
        {
            InitializeComponent();
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                ds_Tinhoc = objMasterService.Get_All_Rex_Dm_Tinhoc_Collection().ToDataSet();
                dgrex_Dm_Tinhoc.DataSource = ds_Tinhoc;
                dgrex_Dm_Tinhoc.DataMember = ds_Tinhoc.Tables[0].TableName;

                this.Data = ds_Tinhoc;
                this.GridControl = dgrex_Dm_Tinhoc;

                this.DataBindingControl();

                this.ChangeStatus(false);

                this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void ClearDataBindings()
        {
            this.txtMa_Tinhoc.DataBindings.Clear();
            this.txtTen_Tinhoc.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtMa_Tinhoc.DataBindings.Add("EditValue", ds_Tinhoc, ds_Tinhoc.Tables[0].TableName + ".Ma_Tinhoc");
                this.txtTen_Tinhoc.DataBindings.Add("EditValue", ds_Tinhoc, ds_Tinhoc.Tables[0].TableName + ".Ten_Tinhoc");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void ChangeStatus(bool editTable)
        {
            //this.dgrex_Dm_Tinhoc.Enabled = !editTable;
            this.gridView1.OptionsBehavior.Editable = !editTable;
            this.txtMa_Tinhoc.Properties.ReadOnly = !editTable;
            this.txtTen_Tinhoc.Properties.ReadOnly = !editTable;
        }

        public override void ResetText()
        {
            this.txtMa_Tinhoc.EditValue = "";
            this.txtTen_Tinhoc.EditValue = "";
        }

        #region Event Override
        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Tinhoc objRex_Dm_Tinhoc = new Ecm.WebReferences.MasterService.Rex_Dm_Tinhoc();
            objRex_Dm_Tinhoc.Id_Tinhoc = -1;
            objRex_Dm_Tinhoc.Ma_Tinhoc = txtMa_Tinhoc.EditValue;
            objRex_Dm_Tinhoc.Ten_Tinhoc = txtTen_Tinhoc.EditValue;
            return objMasterService.Insert_Rex_Dm_Tinhoc(objRex_Dm_Tinhoc);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Tinhoc objRex_Dm_Tinhoc = new Ecm.WebReferences.MasterService.Rex_Dm_Tinhoc();
            objRex_Dm_Tinhoc.Id_Tinhoc = gridView1.GetFocusedRowCellValue("Id_Tinhoc");
            objRex_Dm_Tinhoc.Ma_Tinhoc = txtMa_Tinhoc.EditValue;
            objRex_Dm_Tinhoc.Ten_Tinhoc = txtTen_Tinhoc.EditValue;
            return objMasterService.Update_Rex_Dm_Tinhoc(objRex_Dm_Tinhoc);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Tinhoc objRex_Dm_Tinhoc = new Ecm.WebReferences.MasterService.Rex_Dm_Tinhoc();
            objRex_Dm_Tinhoc.Id_Tinhoc = gridView1.GetFocusedRowCellValue("Id_Tinhoc");
            return objMasterService.Delete_Rex_Dm_Tinhoc(objRex_Dm_Tinhoc);
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

                GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(txtMa_Tinhoc, lblMa_Tinhoc.Text);
                hashtableControls.Add(txtTen_Tinhoc, lblTen_Tinhoc.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                hashtableControls.Remove(txtTen_Tinhoc);
                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                {
                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, (DataSet)dgrex_Dm_Tinhoc.DataSource, "Ma_Tinhoc"))
                        return false;
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
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblTen_Tinhoc.Text, lblTen_Tinhoc.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Tinhoc"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Tinhoc"], "");
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgrex_Dm_Tinhoc.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Tinhoc.EmbeddedNavigator.Buttons.EndEdit);
                ds_Tinhoc.Tables[0].Columns["Ma_Tinhoc"].Unique = true;
                objMasterService.Update_Rex_Dm_Tinhoc_Collection(this.ds_Tinhoc);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Tinhoc.Text, lblMa_Tinhoc.Text });
                    return false;
                }
                if (ex.ToString().IndexOf("exists") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblTen_Tinhoc.Text, lblTen_Tinhoc.Text });
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
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Rex_Dm_Tinhoc"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Rex_Dm_Tinhoc")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Tinhoc", "Id_Tinhoc", this.gridView1.GetFocusedRowCellValue("Id_Tinhoc"))) > 0)
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
            Ecm.WebReferences.MasterService.Rex_Dm_Tinhoc rex_Dm_Tinhoc = new Ecm.WebReferences.MasterService.Rex_Dm_Tinhoc();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Tinhoc.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    rex_Dm_Tinhoc.Id_Tinhoc = dr["Id_Tinhoc"];
                    rex_Dm_Tinhoc.Ma_Tinhoc = dr["Ma_Tinhoc"];
                    rex_Dm_Tinhoc.Ten_Tinhoc = dr["Ten_Tinhoc"];
                }
                Selected_Rex_Dm_Tinhoc = rex_Dm_Tinhoc;
                this.Dispose();
                this.Close();
                return rex_Dm_Tinhoc;
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
            this.dgrex_Dm_Tinhoc.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Tinhoc.EmbeddedNavigator.Buttons.EndEdit);
        }

        private void dgrex_Dm_Tinhoc_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + this.gridView1.GetFocusedRowCellValue("Id_Tinhoc") != "")
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Tinhoc", "Id_Tinhoc", this.gridView1.GetFocusedRowCellValue("Id_Tinhoc"))) > 0)
                    {
                        GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                        e.Handled = true;
                    }
            }
        }

        private void gridView1_InitNewRow_1(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Tinhoc"];
            this.addnewrow_clicked = true;
        }

        private void txtMa_Tinhoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;

        }
    }
}