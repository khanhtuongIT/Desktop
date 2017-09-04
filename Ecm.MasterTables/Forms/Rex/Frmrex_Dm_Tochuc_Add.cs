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

    public partial class Frmrex_Dm_Tochuc_Add : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Tochuc = new DataSet();
        public Ecm.WebReferences.MasterService.Rex_Dm_Tochuc Selected_Rex_Dm_Tochuc;

        public Frmrex_Dm_Tochuc_Add()
        {
            InitializeComponent();
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                ds_Tochuc = objMasterService.Get_All_Rex_Dm_Tochuc_Collection().ToDataSet();
                dgrex_Dm_Tochuc.DataSource = ds_Tochuc;
                dgrex_Dm_Tochuc.DataMember = ds_Tochuc.Tables[0].TableName;

                this.Data = ds_Tochuc;
                this.GridControl = dgrex_Dm_Tochuc;
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
            this.txtMa_Tochuc.DataBindings.Clear();
            this.txtTen_Tochuc.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtMa_Tochuc.DataBindings.Add("EditValue", ds_Tochuc, ds_Tochuc.Tables[0].TableName + ".Ma_Tochuc");
                this.txtTen_Tochuc.DataBindings.Add("EditValue", ds_Tochuc, ds_Tochuc.Tables[0].TableName + ".Ten_Tochuc");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void ChangeStatus(bool editTable)
        {
            //this.dgrex_Dm_Tochuc.Enabled = !editTable;
            this.gridView1.OptionsBehavior.Editable = !editTable;
            this.txtMa_Tochuc.Properties.ReadOnly = !editTable;
            this.txtTen_Tochuc.Properties.ReadOnly = !editTable;
        }

        public override void ResetText()
        {
            this.txtMa_Tochuc.EditValue = "";
            this.txtTen_Tochuc.EditValue = "";
        }
                
        #region Event Override

        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Tochuc objRex_Dm_Tochuc = new Ecm.WebReferences.MasterService.Rex_Dm_Tochuc();
            objRex_Dm_Tochuc.Id_Tochuc = -1;
            objRex_Dm_Tochuc.Ma_Tochuc = txtMa_Tochuc.EditValue;
            objRex_Dm_Tochuc.Ten_Tochuc = txtTen_Tochuc.EditValue;
            return objMasterService.Insert_Rex_Dm_Tochuc(objRex_Dm_Tochuc);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Tochuc objRex_Dm_Tochuc = new Ecm.WebReferences.MasterService.Rex_Dm_Tochuc();
            objRex_Dm_Tochuc.Id_Tochuc = gridView1.GetFocusedRowCellValue("Id_Tochuc");
            objRex_Dm_Tochuc.Ma_Tochuc = txtMa_Tochuc.EditValue;
            objRex_Dm_Tochuc.Ten_Tochuc = txtTen_Tochuc.EditValue;
            return objMasterService.Update_Rex_Dm_Tochuc(objRex_Dm_Tochuc);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Tochuc objRex_Dm_Tochuc = new Ecm.WebReferences.MasterService.Rex_Dm_Tochuc();
            objRex_Dm_Tochuc.Id_Tochuc = gridView1.GetFocusedRowCellValue("Id_Tochuc");

            return objMasterService.Delete_Rex_Dm_Tochuc(objRex_Dm_Tochuc);
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
                hashtableControls.Add(txtMa_Tochuc, lblMa_Tochuc.Text);
                hashtableControls.Add(txtTen_Tochuc, lblTen_Tochuc.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;
                /*System.Collections.Hashtable htb = new System.Collections.Hashtable();
                htb.Add(txtMa_Tochuc, lblMa_Tochuc.Text);

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htb, (DataSet)dgrex_Dm_Tochuc.DataSource, "Ma_Tochuc"))
                    return false;*/

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                {
                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, (DataSet)dgrex_Dm_Tochuc.DataSource, "Ma_Tochuc"))
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
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblTen_Tochuc.Text, lblTen_Tochuc.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Tochuc"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Tochuc"], "");
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgrex_Dm_Tochuc.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Tochuc.EmbeddedNavigator.Buttons.EndEdit);
                ds_Tochuc.Tables[0].Columns["Ma_Tochuc"].Unique = true;

                objMasterService.Update_Rex_Dm_Tochuc_Collection(this.ds_Tochuc);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Tochuc.Text, lblMa_Tochuc.Text });
                    return false;
                }
                if (ex.ToString().IndexOf("exists") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblTen_Tochuc.Text, lblTen_Tochuc.Text });
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
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Rex_Dm_Tochuc"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Rex_Dm_Tochuc")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Tochuc", "Id_Tochuc", this.gridView1.GetFocusedRowCellValue("Id_Tochuc"))) > 0)
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
            Ecm.WebReferences.MasterService.Rex_Dm_Tochuc rex_Dm_Tochuc = new Ecm.WebReferences.MasterService.Rex_Dm_Tochuc();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Tochuc.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    rex_Dm_Tochuc.Id_Tochuc = dr["Id_Tochuc"];
                    rex_Dm_Tochuc.Ma_Tochuc = dr["Ma_Tochuc"];
                    rex_Dm_Tochuc.Ten_Tochuc = dr["Ten_Tochuc"];
                }
                Selected_Rex_Dm_Tochuc = rex_Dm_Tochuc;
                this.Dispose();
                this.Close();
                return rex_Dm_Tochuc;
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
            this.dgrex_Dm_Tochuc.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Tochuc.EmbeddedNavigator.Buttons.EndEdit);
            //MessageBox.Show(s);
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Tochuc"];
            this.addnewrow_clicked = true;
        }

        private void dgrex_Dm_Tochuc_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + this.gridView1.GetFocusedRowCellValue("Id_Tochuc") != "")
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Tochuc", "Id_Tochuc", this.gridView1.GetFocusedRowCellValue("Id_Tochuc"))) > 0)
                    {
                        GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                        e.Handled = true;
                    }
            }
        }

        private void gridView1_InitNewRow_1(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.addnewrow_clicked = true;
        }

        private void txtMa_Tochuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;
        }


    }
}

