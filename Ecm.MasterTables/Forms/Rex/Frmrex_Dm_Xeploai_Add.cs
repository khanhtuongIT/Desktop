using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Rex
{

    public partial class Frmrex_Dm_Xeploai_Add :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Xeploai = new DataSet();
        public Ecm.WebReferences.MasterService.Rex_Dm_Xeploai Selected_Rex_Dm_Xeploai;

        public Frmrex_Dm_Xeploai_Add()
        {
            InitializeComponent();
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                ds_Xeploai = objMasterService.Get_All_Rex_Dm_Xeploai_Collection().ToDataSet();
                dgrex_Dm_Xeploai.DataSource = ds_Xeploai;
                dgrex_Dm_Xeploai.DataMember = ds_Xeploai.Tables[0].TableName;

                this.Data = ds_Xeploai;
                this.GridControl = dgrex_Dm_Xeploai;

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
            this.txtMa_Xeploai.DataBindings.Clear();
            this.txtTen_Xeploai.DataBindings.Clear();
        }

        public void DataBindingControl()
        {
            try
            {
                ClearDataBindings();

                this.txtMa_Xeploai.DataBindings.Add("EditValue", ds_Xeploai, ds_Xeploai.Tables[0].TableName + ".Ma_Xeploai");
                this.txtTen_Xeploai.DataBindings.Add("EditValue", ds_Xeploai, ds_Xeploai.Tables[0].TableName + ".Ten_Xeploai");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ChangeStatus(bool editTable)
        {
            //this.dgrex_Dm_Xeploai.Enabled = !editTable;
            this.gridView1.OptionsBehavior.Editable = !editTable;
            this.txtMa_Xeploai.Properties.ReadOnly = !editTable;
            this.txtTen_Xeploai.Properties.ReadOnly = !editTable;
        }

        public void ResetText()
        {
            this.txtMa_Xeploai.EditValue = "";
            this.txtTen_Xeploai.EditValue = "";
        }



        #region Event Override
        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Xeploai objRex_Dm_Xeploai = new Ecm.WebReferences.MasterService.Rex_Dm_Xeploai();
            objRex_Dm_Xeploai.Id_Xeploai = -1;
            objRex_Dm_Xeploai.Ma_Xeploai = txtMa_Xeploai.EditValue;
            objRex_Dm_Xeploai.Ten_Xeploai = txtTen_Xeploai.EditValue;

            return objMasterService.Insert_Rex_Dm_Xeploai(objRex_Dm_Xeploai);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Xeploai objRex_Dm_Xeploai = new Ecm.WebReferences.MasterService.Rex_Dm_Xeploai();
            objRex_Dm_Xeploai.Id_Xeploai = gridView1.GetFocusedRowCellValue("Id_Xeploai");
            objRex_Dm_Xeploai.Ma_Xeploai = txtMa_Xeploai.EditValue;
            objRex_Dm_Xeploai.Ten_Xeploai = txtTen_Xeploai.EditValue;

            return objMasterService.Update_Rex_Dm_Xeploai(objRex_Dm_Xeploai);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Xeploai objRex_Dm_Xeploai = new Ecm.WebReferences.MasterService.Rex_Dm_Xeploai();
            objRex_Dm_Xeploai.Id_Xeploai = gridView1.GetFocusedRowCellValue("Id_Xeploai");

            return objMasterService.Delete_Rex_Dm_Xeploai(objRex_Dm_Xeploai);
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
                hashtableControls.Add(txtMa_Xeploai, lblMa_Xeploai.Text);
                hashtableControls.Add(txtTen_Xeploai, lblTen_Xeploai.Text);

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                System.Collections.Hashtable htb = new System.Collections.Hashtable();
                htb.Add(txtMa_Xeploai, lblMa_Xeploai.Text);

                //if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htb, (DataSet)dgrex_Dm_Xeploai.DataSource, "Ma_Xeploai"))
                //    return false;

                //if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                //    return false;

                if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Add)
                {
                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htb, (DataSet)dgrex_Dm_Xeploai.DataSource, "Ma_Xeploai"))
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
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Xeploai.Text, lblMa_Xeploai.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Xeploai"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Xeploai"], "");
            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgrex_Dm_Xeploai.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Xeploai.EmbeddedNavigator.Buttons.EndEdit);
                ds_Xeploai.Tables[0].Columns["Ma_Xeploai"].Unique = true;

                objMasterService.Update_Rex_Dm_Xeploai_Collection(this.ds_Xeploai);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Xeploai.Text, lblMa_Xeploai.Text });
                    return false;
                }
                if (ex.ToString().IndexOf("exists") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblTen_Xeploai.Text, lblTen_Xeploai.Text });
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
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Rex_Dm_Xeploai"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Rex_Dm_Xeploai")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Xeploai", "Id_Xeploai", this.gridView1.GetFocusedRowCellValue("Id_Xeploai"))) > 0)
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
            Ecm.WebReferences.MasterService.Rex_Dm_Xeploai rex_Dm_Xeploai = new Ecm.WebReferences.MasterService.Rex_Dm_Xeploai();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Xeploai.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    rex_Dm_Xeploai.Id_Xeploai = dr["Id_Xeploai"];
                    rex_Dm_Xeploai.Ma_Xeploai = dr["Ma_Xeploai"];
                    rex_Dm_Xeploai.Ten_Xeploai = dr["Ten_Xeploai"];
                }
                Selected_Rex_Dm_Xeploai = rex_Dm_Xeploai;
                this.Dispose();
                this.Close();
                return rex_Dm_Xeploai;
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
            this.dgrex_Dm_Xeploai.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Xeploai.EmbeddedNavigator.Buttons.EndEdit);
            //string s = this.gridView1.GetFocusedRowCellValue("Ma_Xeploai").ToString();
            //MessageBox.Show(s);
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Xeploai"];
            this.addnewrow_clicked = true;
        }

        private void dgrex_Dm_Xeploai_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + this.gridView1.GetFocusedRowCellValue("") != "")
                if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Xeploai", "Id_Xeploai", this.gridView1.GetFocusedRowCellValue("Id_Xeploai"))) > 0)
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

        private void txtMa_Xeploai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;
        }



    }
}

