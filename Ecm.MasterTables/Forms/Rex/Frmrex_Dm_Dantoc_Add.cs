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

    public partial class Frmrex_Dm_Dantoc_Add : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        //Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Dantoc = new DataSet();
        public Ecm.WebReferences.MasterService.Rex_Dm_Dantoc Selected_Rex_Dm_Dantoc;

        public Frmrex_Dm_Dantoc_Add()
        {
            InitializeComponent();
        }

        public override void DisplayInfo()
        {
            try
            {
                ds_Dantoc = objMasterService.Get_All_Rex_Dm_Dantoc_Collection().ToDataSet();
                dgrex_Dm_Dantoc.DataSource = ds_Dantoc;
                dgrex_Dm_Dantoc.DataMember = ds_Dantoc.Tables[0].TableName;

                this.Data = ds_Dantoc;
                this.GridControl = dgrex_Dm_Dantoc;
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
            this.txtId_Dantoc.DataBindings.Clear();
            this.txtMa_Dantoc.DataBindings.Clear();
            this.txtTen_Dantoc.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtId_Dantoc.DataBindings.Add("EditValue", ds_Dantoc, ds_Dantoc.Tables[0].TableName + ".Id_Dantoc");
                this.txtMa_Dantoc.DataBindings.Add("EditValue", ds_Dantoc, ds_Dantoc.Tables[0].TableName + ".Ma_Dantoc");
                this.txtTen_Dantoc.DataBindings.Add("EditValue", ds_Dantoc, ds_Dantoc.Tables[0].TableName + ".Ten_Dantoc");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void ChangeStatus(bool editTable)
        {
            //this.dgrex_Dm_Dantoc.Enabled = !editTable;
            this.gridView1.OptionsBehavior.Editable = !editTable;
            this.txtMa_Dantoc.Properties.ReadOnly = !editTable;
            this.txtTen_Dantoc.Properties.ReadOnly = !editTable;
        }

        public override void ResetText()
        {
            this.txtId_Dantoc.EditValue = "";
            this.txtMa_Dantoc.EditValue = "";
            this.txtTen_Dantoc.EditValue = "";
        }

        private void Frmrex_Dm_Dantoc_Add_Load(object sender, EventArgs e)
        {
            this.DisplayInfo();
        }

        #region Event Override
        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Dantoc objRex_Dm_Dantoc = new Ecm.WebReferences.MasterService.Rex_Dm_Dantoc();
            objRex_Dm_Dantoc.Id_Dantoc = -1;
            objRex_Dm_Dantoc.Ma_Dantoc = txtMa_Dantoc.EditValue;
            objRex_Dm_Dantoc.Ten_Dantoc = txtTen_Dantoc.EditValue;

            return objMasterService.Insert_Rex_Dm_Dantoc(objRex_Dm_Dantoc);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Dantoc objRex_Dm_Dantoc = new Ecm.WebReferences.MasterService.Rex_Dm_Dantoc();
            objRex_Dm_Dantoc.Id_Dantoc = gridView1.GetFocusedRowCellValue("Id_Dantoc");
            objRex_Dm_Dantoc.Ma_Dantoc = txtMa_Dantoc.EditValue;
            objRex_Dm_Dantoc.Ten_Dantoc = txtTen_Dantoc.EditValue;
            return objMasterService.Update_Rex_Dm_Dantoc(objRex_Dm_Dantoc);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Dantoc objRex_Dm_Dantoc = new Ecm.WebReferences.MasterService.Rex_Dm_Dantoc();
            objRex_Dm_Dantoc.Id_Dantoc = gridView1.GetFocusedRowCellValue("Id_Dantoc");
            return objMasterService.Delete_Rex_Dm_Dantoc(objRex_Dm_Dantoc);
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
                hashtableControls.Add(txtMa_Dantoc, lblMa_Dantoc.Text);
                hashtableControls.Add(txtTen_Dantoc, lblTen_Dantoc.Text);


                //hashtableControls.Remove(txtTen_Dantoc);
                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                {
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
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Dantoc.Text, lblMa_Dantoc.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Dantoc"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Dantoc"], "");

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgrex_Dm_Dantoc.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Dantoc.EmbeddedNavigator.Buttons.EndEdit);
                ds_Dantoc.Tables[0].Columns["Ma_Dantoc"].Unique = true;

                objMasterService.Update_Rex_Dm_Dantoc_Collection(this.ds_Dantoc);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Dantoc.Text, lblMa_Dantoc.Text });
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
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Rex_Dm_Dantoc"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Rex_Dm_Dantoc")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Dantoc", "Id_Dantoc", this.gridView1.GetFocusedRowCellValue("Id_Dantoc"))) > 0)
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
            Ecm.WebReferences.MasterService.Rex_Dm_Dantoc rex_Dm_Dantoc = new Ecm.WebReferences.MasterService.Rex_Dm_Dantoc();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Dantoc.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    rex_Dm_Dantoc.Id_Dantoc = dr["Id_Dantoc"];
                    rex_Dm_Dantoc.Ma_Dantoc = dr["Ma_Dantoc"];
                    rex_Dm_Dantoc.Ten_Dantoc = dr["Ten_Dantoc"];
                }
                Selected_Rex_Dm_Dantoc = rex_Dm_Dantoc;
                this.Dispose();
                this.Close();
                return rex_Dm_Dantoc;
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
            this.dgrex_Dm_Dantoc.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Dantoc.EmbeddedNavigator.Buttons.EndEdit);
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Dantoc"];
            this.addnewrow_clicked = true;
        }

        private void dgrex_Dm_Dantoc_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Dantoc", "Id_Dantoc", this.gridView1.GetFocusedRowCellValue("Id_Dantoc"))) > 0)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    e.Handled = true;
                }
            }
        }

        private void txtMa_Dantoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;
        }
    }
}

