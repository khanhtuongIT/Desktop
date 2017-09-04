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

    public partial class Frmrex_Dm_Chungchi_Add : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Chungchi = new DataSet();
        public Ecm.WebReferences.MasterService.Rex_Dm_Chungchi Selected_Rex_Dm_Chungchi;

        public Frmrex_Dm_Chungchi_Add()
        {
            InitializeComponent();
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                ds_Chungchi = objMasterService.Get_All_Rex_Dm_Chungchi_Collection().ToDataSet();
                dgrex_Dm_Chungchi.DataSource = ds_Chungchi;
                dgrex_Dm_Chungchi.DataMember = ds_Chungchi.Tables[0].TableName;

                this.Data = ds_Chungchi;
                this.GridControl = dgrex_Dm_Chungchi;
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
            this.txtMa_Chungchi.DataBindings.Clear();
            this.txtTen_Chungchi.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtMa_Chungchi.DataBindings.Add("EditValue", ds_Chungchi, ds_Chungchi.Tables[0].TableName + ".Ma_Chungchi");
                this.txtTen_Chungchi.DataBindings.Add("EditValue", ds_Chungchi, ds_Chungchi.Tables[0].TableName + ".Ten_Chungchi");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void ChangeStatus(bool editTable)
        {
            //this.dgrex_Dm_Chungchi.Enabled = !editTable;
            this.gridView1.OptionsBehavior.Editable = !editTable;
            this.txtMa_Chungchi.Properties.ReadOnly = !editTable;
            this.txtTen_Chungchi.Properties.ReadOnly = !editTable;
        }

        public override void ResetText()
        {
            this.txtMa_Chungchi.EditValue = "";
            this.txtTen_Chungchi.EditValue = "";
        }

        #region Event Override
        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Chungchi objRex_Dm_Chungchi = new Ecm.WebReferences.MasterService.Rex_Dm_Chungchi();
            objRex_Dm_Chungchi.Id_Chungchi = -1;
            objRex_Dm_Chungchi.Ma_Chungchi = txtMa_Chungchi.EditValue;
            objRex_Dm_Chungchi.Ten_Chungchi = txtTen_Chungchi.EditValue;

            return objMasterService.Insert_Rex_Dm_Chungchi(objRex_Dm_Chungchi);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Chungchi objRex_Dm_Chungchi = new Ecm.WebReferences.MasterService.Rex_Dm_Chungchi();
            objRex_Dm_Chungchi.Id_Chungchi = gridView1.GetFocusedRowCellValue("Id_Chungchi");
            objRex_Dm_Chungchi.Ma_Chungchi = txtMa_Chungchi.EditValue;
            objRex_Dm_Chungchi.Ten_Chungchi = txtTen_Chungchi.EditValue;


            return objMasterService.Update_Rex_Dm_Chungchi(objRex_Dm_Chungchi);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Chungchi objRex_Dm_Chungchi = new Ecm.WebReferences.MasterService.Rex_Dm_Chungchi();
            objRex_Dm_Chungchi.Id_Chungchi = gridView1.GetFocusedRowCellValue("Id_Chungchi");

            return objMasterService.Delete_Rex_Dm_Chungchi(objRex_Dm_Chungchi);
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
                hashtableControls.Add(txtMa_Chungchi, lblMa_Chungchi.Text);
                hashtableControls.Add(txtTen_Chungchi, lblTen_Chungchi.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                {
                    hashtableControls.Remove(txtTen_Chungchi);
                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, (DataSet)dgrex_Dm_Chungchi.DataSource, "Ma_Chungchi"))
                        return false;
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    hashtableControls.Remove(txtTen_Chungchi);
                    DataSet ds_Chungchi_filter = GoobizFrame.Windows.MdiUtils.Validator.datasetFillter(ds_Chungchi, "Id_Chungchi = " + gridView1.GetFocusedRowCellValue("Id_Chungchi"));
                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, ds_Chungchi_filter, "Ma_Chungchi"))
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
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblTen_Chungchi.Text, lblTen_Chungchi.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Chungchi"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Chungchi"], "");
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgrex_Dm_Chungchi.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Chungchi.EmbeddedNavigator.Buttons.EndEdit);
                ds_Chungchi.Tables[0].Columns["Ma_Chungchi"].Unique = true;

                objMasterService.Update_Rex_Dm_Chungchi_Collection(this.ds_Chungchi);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Chungchi.Text, lblMa_Chungchi.Text });
                    return false;
                }
                //if (ex.ToString().IndexOf("exists") != -1)
                //{
                //     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblTen_Chungchi.Text, lblTen_Chungchi.Text });
                //    return false;
                //}
                //MessageBox.Show(ex.ToString());

            }
            this.DisplayInfo();
            return true;
        }

        public override bool PerformDelete()
        {
            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Rex_Dm_Chungchi"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Rex_Dm_Chungchi")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Chungchi", "Id_Chungchi", this.gridView1.GetFocusedRowCellValue("Id_Chungchi"))) > 0)
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
            Ecm.WebReferences.MasterService.Rex_Dm_Chungchi rex_Dm_Chungchi = new Ecm.WebReferences.MasterService.Rex_Dm_Chungchi();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Chungchi.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    rex_Dm_Chungchi.Id_Chungchi = dr["Id_Chungchi"];
                    rex_Dm_Chungchi.Ma_Chungchi = dr["Ma_Chungchi"];
                    rex_Dm_Chungchi.Ten_Chungchi = dr["Ten_Chungchi"];
                }
                Selected_Rex_Dm_Chungchi = rex_Dm_Chungchi;
                this.Dispose();
                this.Close();
                return rex_Dm_Chungchi;
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
            this.dgrex_Dm_Chungchi.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Chungchi.EmbeddedNavigator.Buttons.EndEdit);
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Chungchi"];
            this.addnewrow_clicked = true;
        }

        private void dgrex_Dm_Chungchi_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + this.gridView1.GetFocusedRowCellValue("Id_Chungchi") != "")
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Chungchi", "Id_Chungchi", this.gridView1.GetFocusedRowCellValue("Id_Chungchi"))) > 0)
                    {
                        GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                        e.Handled = true;
                    }
            }
        }

        private void txtMa_Chungchi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;
        }


    }
}

