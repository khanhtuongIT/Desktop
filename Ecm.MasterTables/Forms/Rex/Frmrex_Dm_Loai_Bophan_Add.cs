using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Rex
{

    public partial class Frmrex_Dm_Loai_Bophan_Add :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Loai_Bophan = new DataSet();
        public Ecm.WebReferences.MasterService.Rex_Dm_Loai_Bophan Selected_Rex_Dm_Loai_Bophan;

        public Frmrex_Dm_Loai_Bophan_Add()
        {
            InitializeComponent();
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                ds_Loai_Bophan = objMasterService.Get_All_Rex_Dm_Loai_Bophan_Collection().ToDataSet();
                dgrex_Dm_Loai_Bophan.DataSource = ds_Loai_Bophan;
                dgrex_Dm_Loai_Bophan.DataMember = ds_Loai_Bophan.Tables[0].TableName;

                this.Data = ds_Loai_Bophan;
                this.GridControl = dgrex_Dm_Loai_Bophan;

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
            this.txtMa_Loai_Bophan.DataBindings.Clear();
            this.txtTen_Loai_Bophan.DataBindings.Clear();
        }

        public void DataBindingControl()
        {
            try
            {
                ClearDataBindings();

                this.txtMa_Loai_Bophan.DataBindings.Add("EditValue", ds_Loai_Bophan, ds_Loai_Bophan.Tables[0].TableName + ".Ma_Loai_Bophan");
                this.txtTen_Loai_Bophan.DataBindings.Add("EditValue", ds_Loai_Bophan, ds_Loai_Bophan.Tables[0].TableName + ".Ten_Loai_Bophan");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ChangeStatus(bool editTable)
        {
            //this.dgrex_Dm_Loai_Bophan.Enabled = !editTable;
            this.gridView1.OptionsBehavior.Editable = !editTable;
            this.txtMa_Loai_Bophan.Properties.ReadOnly = !editTable;
            this.txtTen_Loai_Bophan.Properties.ReadOnly = !editTable;
        }

        public void ResetText()
        {
            this.txtMa_Loai_Bophan.EditValue = "";
            this.txtTen_Loai_Bophan.EditValue = "";
        }

        #region Event Override
        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Loai_Bophan objRex_Dm_Loai_Bophan = new Ecm.WebReferences.MasterService.Rex_Dm_Loai_Bophan();
            objRex_Dm_Loai_Bophan.Id_Loai_Bophan = -1;
            objRex_Dm_Loai_Bophan.Ma_Loai_Bophan = txtMa_Loai_Bophan.EditValue;
            objRex_Dm_Loai_Bophan.Ten_Loai_Bophan = txtTen_Loai_Bophan.EditValue;
            return objMasterService.Insert_Rex_Dm_Loai_Bophan(objRex_Dm_Loai_Bophan);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Loai_Bophan objRex_Dm_Loai_Bophan = new Ecm.WebReferences.MasterService.Rex_Dm_Loai_Bophan();
            objRex_Dm_Loai_Bophan.Id_Loai_Bophan = gridView1.GetFocusedRowCellValue("Id_Loai_Bophan");
            objRex_Dm_Loai_Bophan.Ma_Loai_Bophan = txtMa_Loai_Bophan.EditValue;
            objRex_Dm_Loai_Bophan.Ten_Loai_Bophan = txtTen_Loai_Bophan.EditValue;
            return objMasterService.Update_Rex_Dm_Loai_Bophan(objRex_Dm_Loai_Bophan);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Loai_Bophan objRex_Dm_Loai_Bophan = new Ecm.WebReferences.MasterService.Rex_Dm_Loai_Bophan();
            objRex_Dm_Loai_Bophan.Id_Loai_Bophan = gridView1.GetFocusedRowCellValue("Id_Loai_Bophan");
            return objMasterService.Delete_Rex_Dm_Loai_Bophan(objRex_Dm_Loai_Bophan);
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
                hashtableControls.Add(txtMa_Loai_Bophan, lblMa_Loai_Bophan.Text);
                hashtableControls.Add(txtTen_Loai_Bophan, lblTen_Loai_Bophan.Text);

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                hashtableControls.Remove(txtTen_Loai_Bophan);
                if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Add)
                {
                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, (DataSet)dgrex_Dm_Loai_Bophan.DataSource, "Ma_Loai_Bophan"))
                        return false;
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    DataSet ds_Loai_Bophan_filter =  GoobizFrame.Windows.MdiUtils.Validator.datasetFillter(ds_Loai_Bophan, "Id_Loai_Bophan = " + gridView1.GetFocusedRowCellValue("Id_Loai_Bophan"));
                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, ds_Loai_Bophan_filter, "Ma_Loai_Bophan"))
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
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblTen_Loai_Bophan.Text, lblTen_Loai_Bophan.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Loai_Bophan"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Loai_Bophan"], "");

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgrex_Dm_Loai_Bophan.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Loai_Bophan.EmbeddedNavigator.Buttons.EndEdit);
                ds_Loai_Bophan.Tables[0].Columns["Ma_Loai_Bophan"].Unique = true;

                objMasterService.Update_Rex_Dm_Loai_Bophan_Collection(this.ds_Loai_Bophan);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Loai_Bophan.Text, lblMa_Loai_Bophan.Text });
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
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Rex_Dm_Loai_Bophan"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Rex_Dm_Loai_Bophan")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Loai_Bophan", "Id_Loai_Bophan", this.gridView1.GetFocusedRowCellValue("Id_Loai_Bophan"))) > 0)
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
            Ecm.WebReferences.MasterService.Rex_Dm_Loai_Bophan rex_Dm_Loai_Bophan = new Ecm.WebReferences.MasterService.Rex_Dm_Loai_Bophan();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Loai_Bophan.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    rex_Dm_Loai_Bophan.Id_Loai_Bophan = dr["Id_Loai_Bophan"];
                    rex_Dm_Loai_Bophan.Ma_Loai_Bophan = dr["Ma_Loai_Bophan"];
                    rex_Dm_Loai_Bophan.Ten_Loai_Bophan = dr["Ten_Loai_Bophan"];
                }
                Selected_Rex_Dm_Loai_Bophan = rex_Dm_Loai_Bophan;
                this.Dispose();
                this.Close();
                return rex_Dm_Loai_Bophan;
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
            this.dgrex_Dm_Loai_Bophan.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Loai_Bophan.EmbeddedNavigator.Buttons.EndEdit);
        }

        private void dgrex_Dm_Loai_Bophan_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + this.gridView1.GetFocusedRowCellValue("Id_Loai_Bophan") != "")
                if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Loai_Bophan", "Id_Loai_Bophan", this.gridView1.GetFocusedRowCellValue("Id_Loai_Bophan"))) > 0)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    e.Handled = true;
                }
            }
        }

        private void gridView1_InitNewRow_1(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Loai_Bophan"];
            this.addnewrow_clicked = true;
        }

        private void txtMa_Loai_Bophan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;
        }


    }
}

