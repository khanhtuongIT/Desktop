using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Rex
{

    public partial class Frmrex_Dm_Loai_Nghiphep_Add :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Loai_Nghiphep = new DataSet();
        public Ecm.WebReferences.MasterService.Rex_Dm_Loai_Nghiphep Selected_Rex_Dm_Loai_Nghiphep;

        public Frmrex_Dm_Loai_Nghiphep_Add()
        {
            InitializeComponent();
            this.DisplayInfo();
            gridColumn5.Visible = false;
        }
        public override void DisplayInfo()
        {
            try
            {
                ds_Loai_Nghiphep = objMasterService.Get_All_Rex_Dm_Loai_Nghiphep_Collection().ToDataSet();
                dgrex_Dm_Loai_Nghiphep.DataSource = ds_Loai_Nghiphep;
                dgrex_Dm_Loai_Nghiphep.DataMember = ds_Loai_Nghiphep.Tables[0].TableName;

                this.Data = ds_Loai_Nghiphep;
                this.GridControl = dgrex_Dm_Loai_Nghiphep;

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
            this.txtMa_Loai_Nghiphep.DataBindings.Clear();
            this.txtTen_Loai_Nghiphep.DataBindings.Clear();
            this.chkHuongluong.DataBindings.Clear();
        }

        public void DataBindingControl()
        {
            try
            {
                ClearDataBindings();

                this.txtMa_Loai_Nghiphep.DataBindings.Add("EditValue", ds_Loai_Nghiphep, ds_Loai_Nghiphep.Tables[0].TableName + ".Ma_Loai_Nghiphep");
                this.txtTen_Loai_Nghiphep.DataBindings.Add("EditValue", ds_Loai_Nghiphep, ds_Loai_Nghiphep.Tables[0].TableName + ".Ten_Loai_Nghiphep");
                this.chkHuongluong.DataBindings.Add("Checked", ds_Loai_Nghiphep, ds_Loai_Nghiphep.Tables[0].TableName + ".Huongluong");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ChangeStatus(bool editTable)
        {
            //this.dgrex_Dm_Loai_Nghiphep.Enabled = !editTable;
            this.gridView1.OptionsBehavior.Editable = !editTable;
            this.txtMa_Loai_Nghiphep.Properties.ReadOnly = !editTable;
            this.txtTen_Loai_Nghiphep.Properties.ReadOnly = !editTable;
            this.chkHuongluong.Properties.ReadOnly = !editTable;
        }

        public override void ResetText()
        {
            this.txtMa_Loai_Nghiphep.EditValue = "";
            this.txtTen_Loai_Nghiphep.EditValue = "";
            this.chkHuongluong.Checked = false;
        }
        
        #region Event Override
        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Loai_Nghiphep objRex_Dm_Loai_Nghiphep = new Ecm.WebReferences.MasterService.Rex_Dm_Loai_Nghiphep();
            objRex_Dm_Loai_Nghiphep.Id_Loai_Nghiphep = -1;
            objRex_Dm_Loai_Nghiphep.Ma_Loai_Nghiphep = txtMa_Loai_Nghiphep.EditValue;
            objRex_Dm_Loai_Nghiphep.Ten_Loai_Nghiphep = txtTen_Loai_Nghiphep.EditValue;
            objRex_Dm_Loai_Nghiphep.Huongluong = chkHuongluong.Checked;

            return objMasterService.Insert_Rex_Dm_Loai_Nghiphep(objRex_Dm_Loai_Nghiphep);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Loai_Nghiphep objRex_Dm_Loai_Nghiphep = new Ecm.WebReferences.MasterService.Rex_Dm_Loai_Nghiphep();
            objRex_Dm_Loai_Nghiphep.Id_Loai_Nghiphep = gridView1.GetFocusedRowCellValue("Id_Loai_Nghiphep");
            objRex_Dm_Loai_Nghiphep.Ma_Loai_Nghiphep = txtMa_Loai_Nghiphep.EditValue;
            objRex_Dm_Loai_Nghiphep.Ten_Loai_Nghiphep = txtTen_Loai_Nghiphep.EditValue;
            objRex_Dm_Loai_Nghiphep.Huongluong = chkHuongluong.Checked;


            return objMasterService.Update_Rex_Dm_Loai_Nghiphep(objRex_Dm_Loai_Nghiphep);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Loai_Nghiphep objRex_Dm_Loai_Nghiphep = new Ecm.WebReferences.MasterService.Rex_Dm_Loai_Nghiphep();
            objRex_Dm_Loai_Nghiphep.Id_Loai_Nghiphep = gridView1.GetFocusedRowCellValue("Id_Loai_Nghiphep");

            return objMasterService.Delete_Rex_Dm_Loai_Nghiphep(objRex_Dm_Loai_Nghiphep);
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
                hashtableControls.Add(txtMa_Loai_Nghiphep, lblMa_Loai_Nghiphep.Text);
                hashtableControls.Add(txtTen_Loai_Nghiphep, lblTen_Loai_Nghiphep.Text);
                //hashtableControls.Add(chkHuongluong, lblHuongluong);

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                hashtableControls.Remove(txtTen_Loai_Nghiphep);

                if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Add)
                {
              
                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, (DataSet)dgrex_Dm_Loai_Nghiphep.DataSource, "Ma_Loai_Nghiphep"))
                        return false;
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    DataSet ds_Loai_Nghiphep_filter =  GoobizFrame.Windows.MdiUtils.Validator.datasetFillter(ds_Loai_Nghiphep, "Id_Loai_Nghiphep = " + gridView1.GetFocusedRowCellValue("Id_Loai_Nghiphep"));
                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, ds_Loai_Nghiphep_filter, "Ma_Loai_Nghiphep"))
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
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblTen_Loai_Nghiphep.Text, lblTen_Loai_Nghiphep.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Loai_Nghiphep"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Loai_Nghiphep"], "");
            //hashtableControls.Add(gridView1.Columns["Huongluong"], "");

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgrex_Dm_Loai_Nghiphep.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Loai_Nghiphep.EmbeddedNavigator.Buttons.EndEdit);
                ds_Loai_Nghiphep.Tables[0].Columns["Ma_Loai_Nghiphep"].Unique = true;
                objMasterService.Update_Rex_Dm_Loai_Nghiphep_Collection(this.ds_Loai_Nghiphep);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Loai_Nghiphep.Text, lblMa_Loai_Nghiphep.Text });
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
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Rex_Dm_Loai_Nghiphep"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Rex_Dm_Loai_Nghiphep")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Loai_Nghiphep", "Id_Loai_Nghiphep", this.gridView1.GetFocusedRowCellValue("Id_Loai_Nghiphep"))) > 0)
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
            Ecm.WebReferences.MasterService.Rex_Dm_Loai_Nghiphep rex_Dm_Loai_Nghiphep = new Ecm.WebReferences.MasterService.Rex_Dm_Loai_Nghiphep();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Loai_Nghiphep.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    rex_Dm_Loai_Nghiphep.Id_Loai_Nghiphep = dr["Id_Loai_Nghiphep"];
                    rex_Dm_Loai_Nghiphep.Ma_Loai_Nghiphep = dr["Ma_Loai_Nghiphep"];
                    rex_Dm_Loai_Nghiphep.Ten_Loai_Nghiphep = dr["Ten_Loai_Nghiphep"];
                    rex_Dm_Loai_Nghiphep.Huongluong = dr["Huongluong"];
                }
                Selected_Rex_Dm_Loai_Nghiphep = rex_Dm_Loai_Nghiphep;
                this.Dispose();
                this.Close();
                return rex_Dm_Loai_Nghiphep;
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
            this.dgrex_Dm_Loai_Nghiphep.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Loai_Nghiphep.EmbeddedNavigator.Buttons.EndEdit);
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Loai_Nghiphep"];
            this.addnewrow_clicked = true;
        }

        private void dgrex_Dm_Loai_Nghiphep_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + this.gridView1.GetFocusedRowCellValue("Id_Loai_Nghiphep") != "")
                if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Loai_Nghiphep", "Id_Loai_Nghiphep", this.gridView1.GetFocusedRowCellValue("Id_Loai_Nghiphep"))) > 0)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    e.Handled = true;
                }
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
        }

        private void txtMa_Loai_Nghiphep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;
        }


    }
}

