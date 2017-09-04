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
    public partial class Frmrex_Dm_Chuyenmon_Add : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        //Ecm.WebReferences.Classes.MasterService objMasterService  = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Chuyenmon = new DataSet();
        public Ecm.WebReferences.MasterService.Rex_Dm_Chuyenmon Selected_Rex_Dm_Chuyenmon;
        public Frmrex_Dm_Chuyenmon_Add()
        {
            InitializeComponent();
        }

        public override void DisplayInfo()
        {
            try
            {
                ds_Chuyenmon = objMasterService.Get_All_Rex_Dm_Chuyenmon_Collection().ToDataSet();
                dgrex_Dm_Chuyenmon.DataSource = ds_Chuyenmon;
                dgrex_Dm_Chuyenmon.DataMember = ds_Chuyenmon.Tables[0].TableName;

                this.Data = ds_Chuyenmon;
                this.GridControl = dgrex_Dm_Chuyenmon;

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
            this.txtId_Chuyenmon.Visible = true;
            this.txtId_Chuyenmon.DataBindings.Clear();
            this.txtId_Chuyenmon.Visible = false;
            this.txtMa_Chuyenmon.DataBindings.Clear();
            this.txtTen_Chuyenmon.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();

                this.txtId_Chuyenmon.DataBindings.Add("EditValue", ds_Chuyenmon, ds_Chuyenmon.Tables[0].TableName + ".Id_Chuyenmon");
                this.txtMa_Chuyenmon.DataBindings.Add("EditValue", ds_Chuyenmon, ds_Chuyenmon.Tables[0].TableName + ".Ma_Chuyenmon");
                this.txtTen_Chuyenmon.DataBindings.Add("EditValue", ds_Chuyenmon, ds_Chuyenmon.Tables[0].TableName + ".Ten_Chuyenmon");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void ChangeStatus(bool editTable)
        {
            //this.dgrex_Dm_Chuyenmon.Enabled = !editTable;
            this.gridView1.OptionsBehavior.Editable = !editTable;
            this.txtMa_Chuyenmon.Properties.ReadOnly = !editTable;
            this.txtTen_Chuyenmon.Properties.ReadOnly = !editTable;
        }

        public override void ResetText()
        {
            this.txtId_Chuyenmon.EditValue = "";
            this.txtMa_Chuyenmon.EditValue = "";
            this.txtTen_Chuyenmon.EditValue = "";
        }

        private void Frmrex_Dm_Chuyenmon_Add_Load(object sender, EventArgs e)
        {
            this.DisplayInfo();
        }

        #region Event Override
        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Chuyenmon objRex_Dm_Chuyenmon = new Ecm.WebReferences.MasterService.Rex_Dm_Chuyenmon();
            objRex_Dm_Chuyenmon.Id_Chuyenmon = -1;
            objRex_Dm_Chuyenmon.Ma_Chuyenmon = txtMa_Chuyenmon.EditValue;
            objRex_Dm_Chuyenmon.Ten_Chuyenmon = txtTen_Chuyenmon.EditValue;
            return objMasterService.Insert_Rex_Dm_Chuyenmon(objRex_Dm_Chuyenmon);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Chuyenmon objRex_Dm_Chuyenmon = new Ecm.WebReferences.MasterService.Rex_Dm_Chuyenmon();
            objRex_Dm_Chuyenmon.Id_Chuyenmon = gridView1.GetFocusedRowCellValue("Id_Chuyenmon");
            objRex_Dm_Chuyenmon.Ma_Chuyenmon = txtMa_Chuyenmon.EditValue;
            objRex_Dm_Chuyenmon.Ten_Chuyenmon = txtTen_Chuyenmon.EditValue;
            return objMasterService.Update_Rex_Dm_Chuyenmon(objRex_Dm_Chuyenmon);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Chuyenmon objRex_Dm_Chuyenmon = new Ecm.WebReferences.MasterService.Rex_Dm_Chuyenmon();
            objRex_Dm_Chuyenmon.Id_Chuyenmon = gridView1.GetFocusedRowCellValue("Id_Chuyenmon");
            return objMasterService.Delete_Rex_Dm_Chuyenmon(objRex_Dm_Chuyenmon);
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
                hashtableControls.Add(txtMa_Chuyenmon, lblMa_Chuyenmon.Text);
                hashtableControls.Add(txtTen_Chuyenmon, lblTen_Chuyenmon.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                {
                    hashtableControls.Remove(txtTen_Chuyenmon);
                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, ds_Chuyenmon, "Ma_Chuyenmon"))
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
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Chuyenmon.Text, lblMa_Chuyenmon.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Chuyenmon"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Chuyenmon"], "");

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            hashtableControls.Remove(gridView1.Columns["Ten_Chuyenmon"]);
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgrex_Dm_Chuyenmon.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Chuyenmon.EmbeddedNavigator.Buttons.EndEdit);
                ds_Chuyenmon.Tables[0].Columns["Ma_Chuyenmon"].Unique = true;
                objMasterService.Update_Rex_Dm_Chuyenmon_Collection(this.ds_Chuyenmon);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Chuyenmon.Text, lblMa_Chuyenmon.Text });
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
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Rex_Dm_Chuyenmon"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Rex_Dm_Chuyenmon")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Chuyenmon", "Id_Chuyenmon", this.gridView1.GetFocusedRowCellValue("Id_Chuyenmon"))) > 0)
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
            Ecm.WebReferences.MasterService.Rex_Dm_Chuyenmon rex_Dm_Chuyenmon = new Ecm.WebReferences.MasterService.Rex_Dm_Chuyenmon();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Chuyenmon.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    rex_Dm_Chuyenmon.Id_Chuyenmon = dr["Id_Chuyenmon"];
                    rex_Dm_Chuyenmon.Ma_Chuyenmon = dr["Ma_Chuyenmon"];
                    rex_Dm_Chuyenmon.Ten_Chuyenmon = dr["Ten_Chuyenmon"];
                }
                Selected_Rex_Dm_Chuyenmon = rex_Dm_Chuyenmon;
                this.Dispose();
                this.Close();
                return rex_Dm_Chuyenmon;
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
            this.dgrex_Dm_Chuyenmon.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Chuyenmon.EmbeddedNavigator.Buttons.EndEdit);
        }

        private void dgrex_Dm_Chuyenmon_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Chuyenmon", "Id_Chuyenmon", this.gridView1.GetFocusedRowCellValue("Id_Chuyenmon"))) > 0)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    e.Handled = true;
                }
            }
        }

        private void gridView1_InitNewRow_1(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Chuyenmon"];
            this.addnewrow_clicked = true;
        }

        private void dgrex_Dm_Chuyenmon_EmbeddedNavigator_ButtonClick_1(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + this.gridView1.GetFocusedRowCellValue("Id_Chuyenmon") != "")
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Chuyenmon", "Id_Chuyenmon", this.gridView1.GetFocusedRowCellValue("Id_Chuyenmon"))) > 0)
                    {
                        GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                        e.Handled = true;
                    }
            }
        }

        private void txtMa_Chuyenmon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;

        }



    }
}

