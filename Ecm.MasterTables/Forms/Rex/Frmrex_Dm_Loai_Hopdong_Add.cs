using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Rex
{
    public partial class Frmrex_Dm_Loai_Hopdong_Add :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        //Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Loai_Hopdong = new DataSet();

        public Frmrex_Dm_Loai_Hopdong_Add()
        {
            InitializeComponent();
           
        }

        public override void DisplayInfo()
        {
            try
            {
                ds_Loai_Hopdong = objMasterService.Get_All_Rex_Dm_Loai_Hopdong_Collection().ToDataSet();
                dgrex_Dm_Loai_Hopdong.DataSource = ds_Loai_Hopdong;
                dgrex_Dm_Loai_Hopdong.DataMember = ds_Loai_Hopdong.Tables[0].TableName;

                this.Data = ds_Loai_Hopdong;
                this.GridControl = dgrex_Dm_Loai_Hopdong;

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
            this.txtId_Loai_Hopdong.DataBindings.Clear();
            this.txtMa_Loai_Hopdong.DataBindings.Clear();
            this.txtTen_Loai_Hopdong.DataBindings.Clear();
            this.txtThoihan.DataBindings.Clear();
            this.chkBhxh.DataBindings.Clear();
        }

        public void DataBindingControl()
        {
            try
            {
                ClearDataBindings();

                this.txtId_Loai_Hopdong.DataBindings.Add("EditValue", ds_Loai_Hopdong, ds_Loai_Hopdong.Tables[0].TableName +    ".Id_Loai_Hopdong");
                this.txtMa_Loai_Hopdong.DataBindings.Add("EditValue", ds_Loai_Hopdong, ds_Loai_Hopdong.Tables[0].TableName +    ".Ma_Loai_Hopdong");
                this.txtTen_Loai_Hopdong.DataBindings.Add("EditValue", ds_Loai_Hopdong, ds_Loai_Hopdong.Tables[0].TableName +   ".Ten_Loai_Hopdong");
                this.txtThoihan.DataBindings.Add("EditValue", ds_Loai_Hopdong, ds_Loai_Hopdong.Tables[0].TableName +            ".Thoihan");
                this.chkBhxh.DataBindings.Add("EditValue", ds_Loai_Hopdong, ds_Loai_Hopdong.Tables[0].TableName +               ".Bhxh");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ChangeStatus(bool editTable)
        {
            //this.dgrex_Dm_Loai_Hopdong.Enabled              = !editTable;
            this.gridView1.OptionsBehavior.Editable = !editTable;
            this.txtMa_Loai_Hopdong.Properties.ReadOnly     = !editTable;
            this.txtTen_Loai_Hopdong.Properties.ReadOnly    = !editTable;
            this.txtThoihan.Properties.ReadOnly             = !editTable;
            this.chkBhxh.Properties.ReadOnly                = !editTable;
        }

        public void ResetText()
        {
            this.txtId_Loai_Hopdong.EditValue   = "";
            this.txtMa_Loai_Hopdong.EditValue   = "";
            this.txtTen_Loai_Hopdong.EditValue  = "";
            this.txtThoihan.EditValue           = "";
            this.chkBhxh.EditValue              = "";
        }

        private void Frmrex_Dm_Loai_Hopdong_Add_Load(object sender, EventArgs e)
        {
            this.DisplayInfo();
        }

        #region Event Override
        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Loai_Hopdong objRex_Dm_Loai_Hopdong = new Ecm.WebReferences.MasterService.Rex_Dm_Loai_Hopdong();
            objRex_Dm_Loai_Hopdong.Id_Loai_Hopdong  = -1;
            objRex_Dm_Loai_Hopdong.Ma_Loai_Hopdong  = txtMa_Loai_Hopdong.EditValue;
            objRex_Dm_Loai_Hopdong.Ten_Loai_Hopdong = txtTen_Loai_Hopdong.EditValue;
            if ("" + txtThoihan.EditValue != "")
                objRex_Dm_Loai_Hopdong.Thoihan = txtThoihan.EditValue;
            else
                objRex_Dm_Loai_Hopdong.Thoihan = null;
            objRex_Dm_Loai_Hopdong.Bhxh             = chkBhxh.EditValue;

            return objMasterService.Insert_Rex_Dm_Loai_Hopdong(objRex_Dm_Loai_Hopdong);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Loai_Hopdong objRex_Dm_Loai_Hopdong = new Ecm.WebReferences.MasterService.Rex_Dm_Loai_Hopdong();
            objRex_Dm_Loai_Hopdong.Id_Loai_Hopdong = gridView1.GetFocusedRowCellValue("Id_Loai_Hopdong");
            objRex_Dm_Loai_Hopdong.Ma_Loai_Hopdong  = txtMa_Loai_Hopdong.EditValue;
            objRex_Dm_Loai_Hopdong.Ten_Loai_Hopdong = txtTen_Loai_Hopdong.EditValue;
            if ("" + txtThoihan.EditValue != "")
                objRex_Dm_Loai_Hopdong.Thoihan = txtThoihan.EditValue;
            else
                objRex_Dm_Loai_Hopdong.Thoihan = null;
            objRex_Dm_Loai_Hopdong.Bhxh             = chkBhxh.EditValue;

            return objMasterService.Update_Rex_Dm_Loai_Hopdong(objRex_Dm_Loai_Hopdong);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Loai_Hopdong objRex_Dm_Loai_Hopdong = new Ecm.WebReferences.MasterService.Rex_Dm_Loai_Hopdong();
            objRex_Dm_Loai_Hopdong.Id_Loai_Hopdong = gridView1.GetFocusedRowCellValue("Id_Loai_Hopdong");

            return objMasterService.Delete_Rex_Dm_Loai_Hopdong(objRex_Dm_Loai_Hopdong);
        }

        public override bool PerformAdd()
        {
            ClearDataBindings();
            this.ChangeStatus(true);
            this.ResetText();
            this.txtThoihan.Text = "3";
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
                hashtableControls.Add(txtMa_Loai_Hopdong, lblMa_Loai_Hopdong.Text);
                hashtableControls.Add(txtTen_Loai_Hopdong, lblTen_Loai_Hopdong.Text);

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
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Loai_Hopdong.Text, lblMa_Loai_Hopdong.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Loai_Hopdong"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Loai_Hopdong"], "");

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                //dgrex_Dm_Loai_Hopdong.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                this.DoClickEndEdit(dgrex_Dm_Loai_Hopdong);
                ds_Loai_Hopdong.Tables[0].Columns["Ma_Loai_Hopdong"].Unique = true;

                objMasterService.Update_Rex_Dm_Loai_Hopdong_Collection(this.ds_Loai_Hopdong);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Loai_Hopdong.Text, lblMa_Loai_Hopdong.Text });
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
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Rex_Dm_Loai_Hopdong"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Rex_Dm_Loai_Hopdong")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Loai_Hopdong", "Id_Loai_Hopdong", this.gridView1.GetFocusedRowCellValue("Id_Loai_Hopdong"))) > 0)
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
            Ecm.WebReferences.MasterService.Rex_Dm_Loai_Hopdong rex_Dm_Loai_Hopdong = new Ecm.WebReferences.MasterService.Rex_Dm_Loai_Hopdong();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Loai_Hopdong.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    rex_Dm_Loai_Hopdong.Id_Loai_Hopdong = dr["Id_Loai_Hopdong"];
                    rex_Dm_Loai_Hopdong.Ma_Loai_Hopdong = dr["Ma_Loai_Hopdong"];
                    rex_Dm_Loai_Hopdong.Ten_Loai_Hopdong = dr["Ten_Loai_Hopdong"];
                }
                this.Dispose();
                this.Close();
                return rex_Dm_Loai_Hopdong;
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
            //this.dgrex_Dm_Loai_Hopdong.EmbeddedNavigator.Buttons.EndEdit.DoClick();
            this.DoClickEndEdit(dgrex_Dm_Loai_Hopdong);
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Loai_Hopdong"];
            this.gridView1.SetRowCellValue(e.RowHandle, "Thoihan", 3);
            this.addnewrow_clicked = true;
        }

        private void dgrex_Dm_Loai_Hopdong_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + this.gridView1.GetFocusedRowCellValue("Id_Loai_Hopdong") != "")
                if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Loai_Hopdong", "Id_Loai_Hopdong", this.gridView1.GetFocusedRowCellValue("Id_Loai_Hopdong"))) > 0)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    e.Handled = true;
                }
            }
        }

        private void txtMa_Loai_Hopdong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;
        }

        private void gridText_Thoihan_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue != null)
            {
                if (e.NewValue.ToString() == "" || e.NewValue.ToString() == "0")
                    e.Cancel = true;

                if (e.NewValue.ToString().Length > 4)
                    e.Cancel = true;
            }
        }

    }
}

