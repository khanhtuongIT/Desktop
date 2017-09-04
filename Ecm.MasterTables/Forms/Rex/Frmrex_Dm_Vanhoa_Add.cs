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
    public partial class Frmrex_Dm_Vanhoa_Add : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        //Ecm.WebReferences.Classes.MasterService objMasterService  = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Vanhoa = new DataSet();
        public Ecm.WebReferences.MasterService.Rex_Dm_Vanhoa Selected_Rex_Dm_Vanhoa;
        public Frmrex_Dm_Vanhoa_Add()
        {
            InitializeComponent();
        }

        public override void DisplayInfo()
        {
            try
            {
                ds_Vanhoa = objMasterService.Get_All_Rex_Dm_Vanhoa_Collection().ToDataSet();
                dgrex_Dm_Vanhoa.DataSource = ds_Vanhoa;
                dgrex_Dm_Vanhoa.DataMember = ds_Vanhoa.Tables[0].TableName;

                this.Data = ds_Vanhoa;
                this.GridControl = dgrex_Dm_Vanhoa;
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
            this.txtId_Vanhoa.DataBindings.Clear();
            this.txtMa_Vanhoa.DataBindings.Clear();
            this.txtTen_Vanhoa.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();

                this.txtId_Vanhoa.DataBindings.Add("EditValue", ds_Vanhoa, ds_Vanhoa.Tables[0].TableName + ".Id_Vanhoa");
                this.txtMa_Vanhoa.DataBindings.Add("EditValue", ds_Vanhoa, ds_Vanhoa.Tables[0].TableName + ".Ma_Vanhoa");
                this.txtTen_Vanhoa.DataBindings.Add("EditValue", ds_Vanhoa, ds_Vanhoa.Tables[0].TableName + ".Ten_Vanhoa");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void ChangeStatus(bool editTable)
        {
            //this.dgrex_Dm_Vanhoa.Enabled = !editTable;
            this.gridView1.OptionsBehavior.Editable = !editTable;
            this.txtMa_Vanhoa.Properties.ReadOnly = !editTable;
            this.txtTen_Vanhoa.Properties.ReadOnly = !editTable;
        }

        public override void ResetText()
        {
            this.txtId_Vanhoa.EditValue = "";
            this.txtMa_Vanhoa.EditValue = "";
            this.txtTen_Vanhoa.EditValue = "";
        }

        private void Frmrex_Dm_Vanhoa_Add_Load(object sender, EventArgs e)
        {
            this.DisplayInfo();
        }

        #region Event Override
        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Vanhoa objRex_Dm_Vanhoa = new Ecm.WebReferences.MasterService.Rex_Dm_Vanhoa();
            objRex_Dm_Vanhoa.Id_Vanhoa = -1;
            objRex_Dm_Vanhoa.Ma_Vanhoa = txtMa_Vanhoa.EditValue;
            objRex_Dm_Vanhoa.Ten_Vanhoa = txtTen_Vanhoa.EditValue;

            return objMasterService.Insert_Rex_Dm_Vanhoa(objRex_Dm_Vanhoa);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Vanhoa objRex_Dm_Vanhoa = new Ecm.WebReferences.MasterService.Rex_Dm_Vanhoa();
            objRex_Dm_Vanhoa.Id_Vanhoa = gridView1.GetFocusedRowCellValue("Id_Vanhoa");
            objRex_Dm_Vanhoa.Ma_Vanhoa = txtMa_Vanhoa.EditValue;
            objRex_Dm_Vanhoa.Ten_Vanhoa = txtTen_Vanhoa.EditValue;


            return objMasterService.Update_Rex_Dm_Vanhoa(objRex_Dm_Vanhoa);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Vanhoa objRex_Dm_Vanhoa = new Ecm.WebReferences.MasterService.Rex_Dm_Vanhoa();
            objRex_Dm_Vanhoa.Id_Vanhoa = gridView1.GetFocusedRowCellValue("Id_Vanhoa");

            return objMasterService.Delete_Rex_Dm_Vanhoa(objRex_Dm_Vanhoa);
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
                hashtableControls.Add(txtMa_Vanhoa, lblMa_Vanhoa.Text);
                hashtableControls.Add(txtTen_Vanhoa, lblTen_Vanhoa.Text);

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
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Vanhoa.Text, lblMa_Vanhoa.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Vanhoa"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Vanhoa"], "");

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgrex_Dm_Vanhoa.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Vanhoa.EmbeddedNavigator.Buttons.EndEdit);
                ds_Vanhoa.Tables[0].Columns["Ma_Vanhoa"].Unique = true;
                objMasterService.Update_Rex_Dm_Vanhoa_Collection(this.ds_Vanhoa);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Vanhoa.Text, lblMa_Vanhoa.Text });
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
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Rex_Dm_Vanhoa"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Rex_Dm_Vanhoa")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Vanhoa", "Id_Vanhoa", this.gridView1.GetFocusedRowCellValue("Id_Vanhoa"))) > 0)
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
            Ecm.WebReferences.MasterService.Rex_Dm_Vanhoa rex_Dm_Vanhoa = new Ecm.WebReferences.MasterService.Rex_Dm_Vanhoa();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Vanhoa.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    rex_Dm_Vanhoa.Id_Vanhoa = dr["Id_Vanhoa"];
                    rex_Dm_Vanhoa.Ma_Vanhoa = dr["Ma_Vanhoa"];
                    rex_Dm_Vanhoa.Ten_Vanhoa = dr["Ten_Vanhoa"];
                }
                Selected_Rex_Dm_Vanhoa = rex_Dm_Vanhoa;
                this.Dispose();
                this.Close();
                return rex_Dm_Vanhoa;
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
            this.dgrex_Dm_Vanhoa.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Vanhoa.EmbeddedNavigator.Buttons.EndEdit);

        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Vanhoa"];
            this.addnewrow_clicked = true;
        }

        private void dgrex_Dm_Vanhoa_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + this.gridView1.GetFocusedRowCellValue("Id_Vanhoa") != "")
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Vanhoa", "Id_Vanhoa", this.gridView1.GetFocusedRowCellValue("Id_Vanhoa"))) > 0)
                    {
                        GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                        e.Handled = true;
                    }
            }
        }

        private void txtMa_Vanhoa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;
        }
    }
}

