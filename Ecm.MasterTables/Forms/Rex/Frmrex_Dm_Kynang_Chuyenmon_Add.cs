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
    public partial class Frmrex_Dm_Kynang_Chuyenmon_Add : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public WebReferences.Classes.MasterService objMasterService = new WebReferences.Classes.MasterService();
        DataSet ds_Kynang_Chuyenmon = new DataSet();
        public WebReferences.MasterService.Rex_Dm_Kynang_Chuyenmon Selected_Rex_Dm_Kynang_Chuyenmon;

        public Frmrex_Dm_Kynang_Chuyenmon_Add()
        {
            InitializeComponent();
            DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                ds_Kynang_Chuyenmon = objMasterService.Get_All_Rex_Dm_Kynang_Chuyenmon_Collection().ToDataSet();
                dgrex_Dm_Kynang_Chuyenmon.DataSource = ds_Kynang_Chuyenmon;
                dgrex_Dm_Kynang_Chuyenmon.DataMember = ds_Kynang_Chuyenmon.Tables[0].TableName;

                Data = ds_Kynang_Chuyenmon;
                GridControl = dgrex_Dm_Kynang_Chuyenmon;

                DataBindingControl();
                ChangeStatus(false);
                gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void ClearDataBindings()
        {
            txtMa_Kynang_Chuyenmon.DataBindings.Clear();
            txtTen_Kynang_Chuyemon.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                txtMa_Kynang_Chuyenmon.DataBindings.Add("EditValue", ds_Kynang_Chuyenmon, ds_Kynang_Chuyenmon.Tables[0].TableName + ".Ma_Kynang_Chuyenmon");
                txtTen_Kynang_Chuyemon.DataBindings.Add("EditValue", ds_Kynang_Chuyenmon, ds_Kynang_Chuyenmon.Tables[0].TableName + ".Ten_Kynang_Chuyenmon");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void ChangeStatus(bool editTable)
        {
            //this.dgrex_Dm_Kynang_Chuyenmon.Enabled = !editTable;
            gridView1.OptionsBehavior.Editable = !editTable;
            txtMa_Kynang_Chuyenmon.Properties.ReadOnly = !editTable;
            txtTen_Kynang_Chuyemon.Properties.ReadOnly = !editTable;
        }

        public override void ResetText()
        {
            txtMa_Kynang_Chuyenmon.EditValue = string.Empty;
            txtTen_Kynang_Chuyemon.EditValue = string.Empty;
        }
        
        #region Event Override

        public object InsertObject()
        {
            WebReferences.MasterService.Rex_Dm_Kynang_Chuyenmon objRex_Dm_Kynang_Chuyenmon = new WebReferences.MasterService.Rex_Dm_Kynang_Chuyenmon();
            objRex_Dm_Kynang_Chuyenmon.Id_Kynang_Chuyenmon = -1;
            objRex_Dm_Kynang_Chuyenmon.Ma_Kynang_Chuyenmon = txtMa_Kynang_Chuyenmon.EditValue;
            objRex_Dm_Kynang_Chuyenmon.Ten_Kynang_Chuyenmon = txtTen_Kynang_Chuyemon.EditValue;
            return objMasterService.Insert_Rex_Dm_Kynang_Chuyenmon(objRex_Dm_Kynang_Chuyenmon);
        }

        public object UpdateObject()
        {
            WebReferences.MasterService.Rex_Dm_Kynang_Chuyenmon objRex_Dm_Kynang_Chuyenmon = new WebReferences.MasterService.Rex_Dm_Kynang_Chuyenmon();
            objRex_Dm_Kynang_Chuyenmon.Id_Kynang_Chuyenmon = gridView1.GetFocusedRowCellValue("Id_Kynang_Chuyenmon");
            objRex_Dm_Kynang_Chuyenmon.Ma_Kynang_Chuyenmon = txtMa_Kynang_Chuyenmon.EditValue;
            objRex_Dm_Kynang_Chuyenmon.Ten_Kynang_Chuyenmon = txtTen_Kynang_Chuyemon.EditValue;
            return objMasterService.Update_Rex_Dm_Kynang_Chuyenmon(objRex_Dm_Kynang_Chuyenmon);
        }

        public object DeleteObject()
        {
            WebReferences.MasterService.Rex_Dm_Kynang_Chuyenmon objRex_Dm_Kynang_Chuyenmon = new WebReferences.MasterService.Rex_Dm_Kynang_Chuyenmon();
            objRex_Dm_Kynang_Chuyenmon.Id_Kynang_Chuyenmon = gridView1.GetFocusedRowCellValue("Id_Kynang_Chuyenmon");
            return objMasterService.Delete_Rex_Dm_Kynang_Chuyenmon(objRex_Dm_Kynang_Chuyenmon);
        }

        public override bool PerformAdd()
        {
            ClearDataBindings();
            ChangeStatus(true);
            ResetText();
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
                hashtableControls.Add(txtMa_Kynang_Chuyenmon, lblMa_Kynang_Chuyenmon.Text);
                hashtableControls.Add(txtTen_Kynang_Chuyemon, lblTen_Kynang_Chuyenmon.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                {
                    hashtableControls.Remove(txtTen_Kynang_Chuyemon);
                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, ds_Kynang_Chuyenmon, "Ma_Kynang_Chuyenmon"))
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
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Kynang_Chuyenmon.Text, lblMa_Kynang_Chuyenmon.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Kynang_Chuyenmon"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Kynang_Chuyenmon"], "");

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            hashtableControls.Remove(gridView1.Columns["Ten_Kynang_Chuyenmon"]);
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgrex_Dm_Kynang_Chuyenmon.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Kynang_Chuyenmon.EmbeddedNavigator.Buttons.EndEdit);
                ds_Kynang_Chuyenmon.Tables[0].Columns["Ma_Kynang_Chuyenmon"].Unique = true;
                objMasterService.Update_Rex_Dm_Kynang_Chuyenmon_Collection(ds_Kynang_Chuyenmon);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Kynang_Chuyenmon.Text, lblTen_Kynang_Chuyenmon.Text });
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
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Rex_Dm_Kynang_Chuyenmon"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Rex_Dm_Kynang_Chuyenmon")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Kynang_Chuyenmon", "Id_Kynang_Chuyenmon", this.gridView1.GetFocusedRowCellValue("Id_Kynang_Chuyenmon"))) > 0)
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
                }
                this.DisplayInfo();
            }
            return base.PerformDelete();
        }

        public override object PerformSelectOneObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Kynang_Chuyenmon rex_Dm_Kynang_Chuyenmon = new Ecm.WebReferences.MasterService.Rex_Dm_Kynang_Chuyenmon();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Kynang_Chuyenmon.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    rex_Dm_Kynang_Chuyenmon.Id_Kynang_Chuyenmon = dr["Id_Kynang_Chuyenmon"];
                    rex_Dm_Kynang_Chuyenmon.Ma_Kynang_Chuyenmon = dr["Ma_Kynang_Chuyenmon"];
                    rex_Dm_Kynang_Chuyenmon.Ten_Kynang_Chuyenmon = dr["Ten_Kynang_Chuyenmon"];
                }
                Selected_Rex_Dm_Kynang_Chuyenmon = rex_Dm_Kynang_Chuyenmon;
                this.Dispose();
                this.Close();
                return rex_Dm_Kynang_Chuyenmon;
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

        private void txtMa_Kynang_Chuyenmon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;
        }





    }
}

