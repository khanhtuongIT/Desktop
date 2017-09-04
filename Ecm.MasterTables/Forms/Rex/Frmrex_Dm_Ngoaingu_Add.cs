using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Rex
{

    public partial class Frmrex_Dm_Ngoaingu_Add :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Ngoaingu = new DataSet();
        public Ecm.WebReferences.MasterService.Rex_Dm_Ngoaingu Selected_Rex_Dm_Ngoaingu;
        
        public Frmrex_Dm_Ngoaingu_Add()
        {
            InitializeComponent();
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                ds_Ngoaingu = objMasterService.Get_All_Rex_Dm_Ngoaingu_Collection().ToDataSet();
                dgrex_Dm_Ngoaingu.DataSource = ds_Ngoaingu;
                dgrex_Dm_Ngoaingu.DataMember = ds_Ngoaingu.Tables[0].TableName;

                this.Data = ds_Ngoaingu;
                this.GridControl = dgrex_Dm_Ngoaingu;

                this.DataBindingControl();
                this.ChangeStatus(false);
                this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void ClearDataBindings()
        {
            this.txtMa_Ngoaingu.DataBindings.Clear();
            this.txtTen_Ngoaingu.DataBindings.Clear();
            this.txtTrinhdo.DataBindings.Clear();
        }

        public void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtMa_Ngoaingu.DataBindings.Add("EditValue", ds_Ngoaingu, ds_Ngoaingu.Tables[0].TableName + ".Ma_Ngoaingu");
                this.txtTen_Ngoaingu.DataBindings.Add("EditValue", ds_Ngoaingu, ds_Ngoaingu.Tables[0].TableName + ".Ten_Ngoaingu");
                this.txtTrinhdo.DataBindings.Add("EditValue", ds_Ngoaingu, ds_Ngoaingu.Tables[0].TableName + ".Ten_Trinhdo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ChangeStatus(bool editTable)
        {
            //this.dgrex_Dm_Ngoaingu.Enabled = !editTable;
            this.gridView1.OptionsBehavior.Editable = !editTable;
            this.txtMa_Ngoaingu.Properties.ReadOnly = !editTable;
            this.txtTen_Ngoaingu.Properties.ReadOnly = !editTable;
            this.txtTrinhdo.Properties.ReadOnly = !editTable;
        }

        public void ResetText()
        {
            this.txtMa_Ngoaingu.EditValue = "";
            this.txtTen_Ngoaingu.EditValue = "";
            this.txtTrinhdo.EditValue = "";
        }

        #region Event Override
        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Ngoaingu objRex_Dm_Ngoaingu = new Ecm.WebReferences.MasterService.Rex_Dm_Ngoaingu();
            objRex_Dm_Ngoaingu.Id_Ngoaingu  = -1;
            objRex_Dm_Ngoaingu.Ma_Ngoaingu  = txtMa_Ngoaingu.EditValue;
            objRex_Dm_Ngoaingu.Ten_Ngoaingu = txtTen_Ngoaingu.EditValue;
            objRex_Dm_Ngoaingu.Ten_Trinhdo  = txtTrinhdo.EditValue;
            return objMasterService.Insert_Rex_Dm_Ngoaingu(objRex_Dm_Ngoaingu);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Ngoaingu objRex_Dm_Ngoaingu = new Ecm.WebReferences.MasterService.Rex_Dm_Ngoaingu();
            objRex_Dm_Ngoaingu.Id_Ngoaingu = gridView1.GetFocusedRowCellValue("Id_Ngoaingu");
            objRex_Dm_Ngoaingu.Ma_Ngoaingu = txtMa_Ngoaingu.EditValue;
            objRex_Dm_Ngoaingu.Ten_Ngoaingu = txtTen_Ngoaingu.EditValue;
            objRex_Dm_Ngoaingu.Ten_Trinhdo = txtTrinhdo.EditValue;
            return objMasterService.Update_Rex_Dm_Ngoaingu(objRex_Dm_Ngoaingu);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Ngoaingu objRex_Dm_Ngoaingu = new Ecm.WebReferences.MasterService.Rex_Dm_Ngoaingu();
            objRex_Dm_Ngoaingu.Id_Ngoaingu = gridView1.GetFocusedRowCellValue("Id_Ngoaingu");

            return objMasterService.Delete_Rex_Dm_Ngoaingu(objRex_Dm_Ngoaingu);
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

                 GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(txtMa_Ngoaingu, lblMa_Ngoaingu.Text);
                hashtableControls.Add(txtTen_Ngoaingu, lblTen_Ngoaingu.Text);
                hashtableControls.Add(txtTrinhdo, lblTrinhdo.Text);

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                hashtableControls.Remove(txtTen_Ngoaingu);
                hashtableControls.Remove(txtTrinhdo);
                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, (DataSet)dgrex_Dm_Ngoaingu.DataSource, "Ma_Ngoaingu"))
                    return false;

                if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Add)
                {

                    success = (bool)this.InsertObject();
                }
                else if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Edit)
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
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblTen_Ngoaingu.Text, lblTen_Ngoaingu.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Ngoaingu"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Ngoaingu"], "");
            //hashtableControls.Add(gridView1.Columns["Ten_Trinhdo"], "");
            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgrex_Dm_Ngoaingu.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Ngoaingu.EmbeddedNavigator.Buttons.EndEdit);
                ds_Ngoaingu.Tables[0].Columns["Ma_Ngoaingu"].Unique = true;
                objMasterService.Update_Rex_Dm_Ngoaingu_Collection(this.ds_Ngoaingu);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Ngoaingu.Text, lblMa_Ngoaingu.Text });
                    return false;
                }
                if (ex.ToString().IndexOf("exists") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Ngoaingu.Text, lblTen_Ngoaingu.Text });
                    return false;
                }
                if (ex.ToString().IndexOf("exists") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Trinhdo.Text, lblTrinhdo.Text });
                    return false;
                }
                //MessageBox.Show(ex.ToString());

            }
            this.DisplayInfo();
            return true;
        }

        public override bool PerformDelete()
        {
            if ( GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Rex_Dm_Ngoaingu"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Rex_Dm_Ngoaingu")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Ngoaingu", "Id_Ngoaingu", this.gridView1.GetFocusedRowCellValue("Id_Ngoaingu"))) > 0)
                    {
                         GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                        return true;
                    }
                    this.DeleteObject();
                }
                catch (Exception ex)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    // GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                }
                this.DisplayInfo();
            }
            return base.PerformDelete();
        }

        public override object PerformSelectOneObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Ngoaingu rex_Dm_Ngoaingu = new Ecm.WebReferences.MasterService.Rex_Dm_Ngoaingu();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Ngoaingu.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    rex_Dm_Ngoaingu.Id_Ngoaingu = dr["Id_Ngoaingu"];
                    rex_Dm_Ngoaingu.Ma_Ngoaingu = dr["Ma_Ngoaingu"];
                    rex_Dm_Ngoaingu.Ten_Ngoaingu = dr["Ten_Ngoaingu"];
                    rex_Dm_Ngoaingu.Ten_Ngoaingu = dr["Ten_Trinhdo"];
                }
                Selected_Rex_Dm_Ngoaingu = rex_Dm_Ngoaingu;
                this.Dispose();
                this.Close();
                return rex_Dm_Ngoaingu;
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
            this.dgrex_Dm_Ngoaingu.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Ngoaingu.EmbeddedNavigator.Buttons.EndEdit);
        }

        private void dgrex_Dm_Ngoaingu_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + this.gridView1.GetFocusedRowCellValue("Id_Ngoaingu") != "")
                if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Ngoaingu", "Id_Ngoaingu", this.gridView1.GetFocusedRowCellValue("Id_Ngoaingu"))) > 0)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    e.Handled = true;
                }
            }
        }

        private void gridView1_InitNewRow_1(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Ngoaingu"];
            this.addnewrow_clicked = true;
        }

        private void txtMa_Ngoaingu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;

        }

    }
}