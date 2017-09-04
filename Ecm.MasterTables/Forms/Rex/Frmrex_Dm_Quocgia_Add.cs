using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Rex
{
    public partial class Frmrex_Dm_Quocgia_Add :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        //Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Quocgia = new DataSet();
        public Ecm.WebReferences.MasterService.Rex_Dm_Quocgia Selected_Rex_Dm_Quocgia;
        public Frmrex_Dm_Quocgia_Add()
        {
            InitializeComponent();
        }

        public override void DisplayInfo()
        {
            try
            {
                ds_Quocgia = objMasterService.Get_All_Rex_Dm_Quocgia_Collection().ToDataSet();
                dgrex_Dm_Quocgia.DataSource = ds_Quocgia;
                dgrex_Dm_Quocgia.DataMember = ds_Quocgia.Tables[0].TableName;

                this.Data = ds_Quocgia;
                this.GridControl = dgrex_Dm_Quocgia;

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
            this.txtId_Quocgia.DataBindings.Clear();
            this.txtMa_Quocgia.DataBindings.Clear();
            this.txtTen_Quocgia.DataBindings.Clear();
        }

        public void DataBindingControl()
        {
            try
            {
                ClearDataBindings();

                this.txtId_Quocgia.DataBindings.Add("EditValue", ds_Quocgia, ds_Quocgia.Tables[0].TableName + ".Id_Quocgia");
                this.txtMa_Quocgia.DataBindings.Add("EditValue", ds_Quocgia, ds_Quocgia.Tables[0].TableName + ".Ma_Quocgia");
                this.txtTen_Quocgia.DataBindings.Add("EditValue", ds_Quocgia, ds_Quocgia.Tables[0].TableName + ".Ten_Quocgia");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ChangeStatus(bool editTable)
        {
            //this.dgrex_Dm_Quocgia.Enabled = !editTable;
            this.gridView1.OptionsBehavior.Editable = !editTable;
            this.txtMa_Quocgia.Properties.ReadOnly = !editTable;
            this.txtTen_Quocgia.Properties.ReadOnly = !editTable;
        }

        public void ResetText()
        {
            this.txtId_Quocgia.EditValue = "";
            this.txtMa_Quocgia.EditValue = "";
            this.txtTen_Quocgia.EditValue = "";
        }

        private void Frmrex_Dm_Quocgia_Add_Load(object sender, EventArgs e)
        {
            this.DisplayInfo();
        }

        #region Event Override
        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Quocgia objRex_Dm_Quocgia = new Ecm.WebReferences.MasterService.Rex_Dm_Quocgia();
            objRex_Dm_Quocgia.Id_Quocgia = -1;
            objRex_Dm_Quocgia.Ma_Quocgia = txtMa_Quocgia.EditValue;
            objRex_Dm_Quocgia.Ten_Quocgia = txtTen_Quocgia.EditValue;
            return objMasterService.Insert_Rex_Dm_Quocgia(objRex_Dm_Quocgia);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Quocgia objRex_Dm_Quocgia = new Ecm.WebReferences.MasterService.Rex_Dm_Quocgia();
            objRex_Dm_Quocgia.Id_Quocgia = gridView1.GetFocusedRowCellValue("Id_Quocgia");
            objRex_Dm_Quocgia.Ma_Quocgia = txtMa_Quocgia.EditValue;
            objRex_Dm_Quocgia.Ten_Quocgia = txtTen_Quocgia.EditValue;
            return objMasterService.Update_Rex_Dm_Quocgia(objRex_Dm_Quocgia);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Quocgia objRex_Dm_Quocgia = new Ecm.WebReferences.MasterService.Rex_Dm_Quocgia();
            objRex_Dm_Quocgia.Id_Quocgia = gridView1.GetFocusedRowCellValue("Id_Quocgia");

            return objMasterService.Delete_Rex_Dm_Quocgia(objRex_Dm_Quocgia);
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
                hashtableControls.Add(txtMa_Quocgia, lblMa_Quocgia.Text);
                hashtableControls.Add(txtTen_Quocgia, lblTen_Quocgia.Text);

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Add)
                {
                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, ds_Quocgia, "Ten_Quocgia"))
                        return false;
                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, ds_Quocgia, "Ma_Quocgia"))
                        return false;
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
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Quocgia.Text, lblMa_Quocgia.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Quocgia"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Quocgia"], "");

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgrex_Dm_Quocgia.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Quocgia.EmbeddedNavigator.Buttons.EndEdit);
                ds_Quocgia.Tables[0].Columns["Ma_Quocgia"].Unique = true;
                objMasterService.Update_Rex_Dm_Quocgia_Collection(this.ds_Quocgia);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Quocgia.Text, lblMa_Quocgia.Text });
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
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Rex_Dm_Quocgia"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Rex_Dm_Quocgia")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Quocgia", "Id_Quocgia", this.gridView1.GetFocusedRowCellValue("Id_Quocgia"))) > 0)
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
            Ecm.WebReferences.MasterService.Rex_Dm_Quocgia rex_Dm_Quocgia = new Ecm.WebReferences.MasterService.Rex_Dm_Quocgia();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Quocgia.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    rex_Dm_Quocgia.Id_Quocgia = dr["Id_Quocgia"];
                    rex_Dm_Quocgia.Ma_Quocgia = dr["Ma_Quocgia"];
                    rex_Dm_Quocgia.Ten_Quocgia = dr["Ten_Quocgia"];
                }
                Selected_Rex_Dm_Quocgia = rex_Dm_Quocgia;
                this.Dispose();
                this.Close();
                return rex_Dm_Quocgia;
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
            this.dgrex_Dm_Quocgia.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Quocgia.EmbeddedNavigator.Buttons.EndEdit);
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Quocgia"];
            this.addnewrow_clicked = true;
        }

        private void dgrex_Dm_Quocgia_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + this.gridView1.GetFocusedRowCellValue("Id_Quocgia") != "")
                if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Quocgia", "Id_Quocgia", this.gridView1.GetFocusedRowCellValue("Id_Quocgia"))) > 0)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    e.Handled = true;
                }
            }
        }

        private void txtMa_Quocgia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;
        }

     
    }
}

