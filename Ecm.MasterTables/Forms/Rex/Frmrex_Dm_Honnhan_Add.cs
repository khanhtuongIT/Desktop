using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Rex
{
    public partial class Frmrex_Dm_Honnhan_Add :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        //Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Honnhan = new DataSet();
        public Ecm.WebReferences.MasterService.Rex_Dm_Honnhan Selected_Rex_Dm_Honnhan;
        public Frmrex_Dm_Honnhan_Add()
        {
            InitializeComponent();
        }

        public override void DisplayInfo()
        {
            try
            {
                ds_Honnhan = objMasterService.Get_All_Rex_Dm_Honnhan_Collection().ToDataSet();
                dgrex_Dm_Honnhan.DataSource = ds_Honnhan;
                dgrex_Dm_Honnhan.DataMember = ds_Honnhan.Tables[0].TableName;

                this.Data = ds_Honnhan;
                this.GridControl = dgrex_Dm_Honnhan;

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
            this.txtId_Honnhan.DataBindings.Clear();
            this.txtMa_Honnhan.DataBindings.Clear();
            this.txtTen_Honnhan.DataBindings.Clear();
        }

        public void DataBindingControl()
        {
            try
            {
                ClearDataBindings();

                this.txtId_Honnhan.DataBindings.Add("EditValue", ds_Honnhan, ds_Honnhan.Tables[0].TableName + ".Id_Honnhan");
                this.txtMa_Honnhan.DataBindings.Add("EditValue", ds_Honnhan, ds_Honnhan.Tables[0].TableName + ".Ma_Honnhan");
                this.txtTen_Honnhan.DataBindings.Add("EditValue", ds_Honnhan, ds_Honnhan.Tables[0].TableName + ".Ten_Honnhan");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ChangeStatus(bool editTable)
        {
            this.gridView1.OptionsBehavior.Editable = !editTable;
            //this.dgrex_Dm_Honnhan.Enabled = !editTable;
            this.txtMa_Honnhan.Properties.ReadOnly = !editTable;
            this.txtTen_Honnhan.Properties.ReadOnly = !editTable;
        }

        public void ResetText()
        {
            this.txtId_Honnhan.EditValue = "";
            this.txtMa_Honnhan.EditValue = "";
            this.txtTen_Honnhan.EditValue = "";
        }

        private void Frmrex_Dm_Honnhan_Add_Load(object sender, EventArgs e)
        {
            this.DisplayInfo();
        }

        #region Event Override
        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Honnhan objRex_Dm_Honnhan = new Ecm.WebReferences.MasterService.Rex_Dm_Honnhan();
            objRex_Dm_Honnhan.Id_Honnhan = -1;
            objRex_Dm_Honnhan.Ma_Honnhan = txtMa_Honnhan.EditValue;
            objRex_Dm_Honnhan.Ten_Honnhan = txtTen_Honnhan.EditValue;

            return objMasterService.Insert_Rex_Dm_Honnhan(objRex_Dm_Honnhan);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Honnhan objRex_Dm_Honnhan = new Ecm.WebReferences.MasterService.Rex_Dm_Honnhan();
            objRex_Dm_Honnhan.Id_Honnhan = gridView1.GetFocusedRowCellValue("Id_Honnhan");
            objRex_Dm_Honnhan.Ma_Honnhan = txtMa_Honnhan.EditValue;
            objRex_Dm_Honnhan.Ten_Honnhan = txtTen_Honnhan.EditValue;


            return objMasterService.Update_Rex_Dm_Honnhan(objRex_Dm_Honnhan);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Honnhan objRex_Dm_Honnhan = new Ecm.WebReferences.MasterService.Rex_Dm_Honnhan();
            objRex_Dm_Honnhan.Id_Honnhan = gridView1.GetFocusedRowCellValue("Id_Honnhan");

            return objMasterService.Delete_Rex_Dm_Honnhan(objRex_Dm_Honnhan);
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
                hashtableControls.Add(txtMa_Honnhan, lblMa_Honnhan.Text);
                hashtableControls.Add(txtTen_Honnhan, lblTen_Honnhan.Text);

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
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
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Honnhan.Text, lblMa_Honnhan.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Honnhan"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Honnhan"], "");

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgrex_Dm_Honnhan.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Honnhan.EmbeddedNavigator.Buttons.EndEdit);
                ds_Honnhan.Tables[0].Columns["Ma_Honnhan"].Unique = true;

                objMasterService.Update_Rex_Dm_Honnhan_Collection(this.ds_Honnhan);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Honnhan.Text, lblMa_Honnhan.Text });
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
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Rex_Dm_Honnhan"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Rex_Dm_Honnhan")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Honnhan", "Id_Honnhan", this.gridView1.GetFocusedRowCellValue("Id_Honnhan"))) > 0)
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
            Ecm.WebReferences.MasterService.Rex_Dm_Honnhan rex_Dm_Honnhan = new Ecm.WebReferences.MasterService.Rex_Dm_Honnhan();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Honnhan.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    rex_Dm_Honnhan.Id_Honnhan = dr["Id_Honnhan"];
                    rex_Dm_Honnhan.Ma_Honnhan = dr["Ma_Honnhan"];
                    rex_Dm_Honnhan.Ten_Honnhan = dr["Ten_Honnhan"];
                }
                Selected_Rex_Dm_Honnhan = rex_Dm_Honnhan;
                this.Dispose();
                this.Close();
                return rex_Dm_Honnhan;
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
            this.dgrex_Dm_Honnhan.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Honnhan.EmbeddedNavigator.Buttons.EndEdit);
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Honnhan"];
            this.addnewrow_clicked = true;
            //this.gridView1.OptionsBehavior.Editable = true;
        }

        private void dgrex_Dm_Honnhan_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + this.gridView1.GetFocusedRowCellValue("Id_Honnhan") != "")
                if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Honnhan", "Id_Honnhan", this.gridView1.GetFocusedRowCellValue("Id_Honnhan"))) > 0)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    e.Handled = true;
                }
            }
        }

        private void txtMa_Honnhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;
        }

    }
}

