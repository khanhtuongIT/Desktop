using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using System.Text.RegularExpressions;

namespace Ecm.MasterTables.Forms.Rex
{
    public partial class Frmrex_Dm_Coquan_Add :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public Ecm.WebReferences.MasterService.Rex_Dm_Coquan Rex_Dm_Coquan = new Ecm.WebReferences.MasterService.Rex_Dm_Coquan();
        DataSet ds_Rex_Dm_Coquan = new DataSet();

        public Frmrex_Dm_Coquan_Add()
        {
            InitializeComponent();
            DisplayInfo();
        }
        
        public override void DisplayInfo()
        {
            ds_Rex_Dm_Coquan = objMasterService.Get_All_Rex_Dm_Coquan_Collection().ToDataSet();
            dgrex_Dm_Coquan.DataSource = ds_Rex_Dm_Coquan;
            dgrex_Dm_Coquan.DataMember = ds_Rex_Dm_Coquan.Tables[0].TableName;

            this.Data = ds_Rex_Dm_Coquan;
            DatabindingControl();
            ChangeStatus(false);
            base.DisplayInfo();
            this.gridView1.BestFitColumns();
        }

        void ClearDataBinding() {
            this.txt_Id_Coquan.DataBindings.Clear();
            this.txtDiachi.DataBindings.Clear();
            this.txtDienthoai.DataBindings.Clear();
            this.txtEmail.DataBindings.Clear();
            this.txtMa_Coquan.DataBindings.Clear();
            this.txtMasothue.DataBindings.Clear();
            this.txtTen_Coquan.DataBindings.Clear();
            this.txtWebsite.DataBindings.Clear();
        }

        void DatabindingControl() 
        {
            try
            {
                ClearDataBinding();
                this.txtDiachi.DataBindings.Add("Text", ds_Rex_Dm_Coquan, ds_Rex_Dm_Coquan.Tables[0].TableName + ".Diachi");
                this.txtDienthoai.DataBindings.Add("Text", ds_Rex_Dm_Coquan, ds_Rex_Dm_Coquan.Tables[0].TableName + ".Dienthoai");
                this.txtEmail.DataBindings.Add("Text", ds_Rex_Dm_Coquan, ds_Rex_Dm_Coquan.Tables[0].TableName + ".Email");
                this.txtMa_Coquan.DataBindings.Add("Text", ds_Rex_Dm_Coquan, ds_Rex_Dm_Coquan.Tables[0].TableName + ".Ma_Coquan");
                this.txtMasothue.DataBindings.Add("Text", ds_Rex_Dm_Coquan, ds_Rex_Dm_Coquan.Tables[0].TableName + ".Masothue");
                this.txtTen_Coquan.DataBindings.Add("Text", ds_Rex_Dm_Coquan, ds_Rex_Dm_Coquan.Tables[0].TableName + ".Ten_Coquan");
                this.txtWebsite.DataBindings.Add("Text", ds_Rex_Dm_Coquan, ds_Rex_Dm_Coquan.Tables[0].TableName + ".Website");
                txt_Id_Coquan.Visible = true;
                this.txt_Id_Coquan.DataBindings.Add("Text", ds_Rex_Dm_Coquan, ds_Rex_Dm_Coquan.Tables[0].TableName + ".Id_Coquan");
                txt_Id_Coquan.Visible = false;
            }
            catch (Exception ex) {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }

        #region event  override
        void ResetText() 
        {
            this.txt_Id_Coquan.Text = "";
            this.txtDiachi.Text = "";
            this.txtDienthoai.Text = "";
            this.txtEmail.Text = "";
            this.txtMa_Coquan.Text = "";
            this.txtMasothue.Text = "";
            this.txtTen_Coquan.Text = "";
            this.txtWebsite.Text = "";
        }

        void ChangeStatus(bool editvalue) 
        {
            //gridView1.OptionsBehavior.Editable = !editvalue;
            //this.dgrex_Dm_Coquan.Enabled = !editvalue;
            this.gridView1.OptionsBehavior.Editable = !editvalue;

            txtDiachi.Properties.ReadOnly = !editvalue;
            txtDienthoai.Properties.ReadOnly = !editvalue;
            txtEmail.Properties.ReadOnly = !editvalue;
            txtMa_Coquan.Properties.ReadOnly = !editvalue;
            txtMasothue.Properties.ReadOnly = !editvalue;
            txtTen_Coquan.Properties.ReadOnly = !editvalue;
            txtWebsite.Properties.ReadOnly = !editvalue;
            //this.dgrex_Dm_Coquan.EmbeddedNavigator.Buttons.Append.Visible = editvalue;
            //this.dgrex_Dm_Coquan.EmbeddedNavigator.Buttons.Remove.Visible = editvalue;
        }

        public object InsertObject() {
            Ecm.WebReferences.MasterService.Rex_Dm_Coquan Rex_Dm_Coquan = new Ecm.WebReferences.MasterService.Rex_Dm_Coquan();
            Rex_Dm_Coquan.Diachi = txtDiachi.EditValue;
            Rex_Dm_Coquan.Dienthoai = txtDienthoai.EditValue;
            Rex_Dm_Coquan.Email = txtEmail.EditValue;
            Rex_Dm_Coquan.Ma_Coquan = txtMa_Coquan.EditValue;
            Rex_Dm_Coquan.Masothue = txtMasothue.EditValue;
            Rex_Dm_Coquan.Ten_Coquan = txtTen_Coquan.EditValue;
            Rex_Dm_Coquan.Website = txtWebsite.EditValue;
            return objMasterService.Insert_Rex_Dm_Coquan(Rex_Dm_Coquan);
        }

        public object UpdateObject() {
            Ecm.WebReferences.MasterService.Rex_Dm_Coquan Rex_Dm_Coquan = new Ecm.WebReferences.MasterService.Rex_Dm_Coquan();
            Rex_Dm_Coquan.Id_Coquan = txt_Id_Coquan.EditValue;
            Rex_Dm_Coquan.Diachi = txtDiachi.EditValue;
            Rex_Dm_Coquan.Dienthoai = txtDienthoai.EditValue;
            Rex_Dm_Coquan.Email = txtEmail.EditValue;
            Rex_Dm_Coquan.Ma_Coquan = txtMa_Coquan.EditValue;
            Rex_Dm_Coquan.Masothue = txtMasothue.EditValue;
            Rex_Dm_Coquan.Ten_Coquan = txtTen_Coquan.EditValue;
            Rex_Dm_Coquan.Website = txtWebsite.EditValue;
            try
            {
                return objMasterService.Update_Rex_Dm_Coquan(Rex_Dm_Coquan);
            }
            catch (Exception ex)
            {
                // GoobizFrame.Windows.Forms.MessageDialog.Show(ex.ToString());
                 GoobizFrame.Windows.Forms.MessageDialog.Show("Mã Cơ quan đã tồn tại, nhập lại Mã cơ quan");
                return false;
            }
        }

        public object DeleteObject() {
            Ecm.WebReferences.MasterService.Rex_Dm_Coquan Rex_Dm_Coquan = new Ecm.WebReferences.MasterService.Rex_Dm_Coquan();
            Rex_Dm_Coquan.Id_Coquan = gridView1.GetFocusedRowCellValue("Id_Coquan");
            return objMasterService.Detele_Rex_Dm_Coquan(Rex_Dm_Coquan);
        }

        public override bool PerformAdd()
        {
            ClearDataBinding();
            ChangeStatus(true);
            ResetText();


            return true;
        }

        public override bool PerformEdit()
        {
            ChangeStatus(true);
            this.txt_Id_Coquan.EditValue = gridView1.GetFocusedRowCellValue(gridView1.Columns["Id_Coquan"]);
            return true;
        }

        public override bool PerformCancel()
        {
            DisplayInfo();
            ChangeStatus(false);
            return true;
        }

        public override bool PerformDelete()
        {
            bool save = false;
            if ( GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Rex_Dm_Coquan"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Rex_Dm_Coquan")}) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Coquan", "Id_Coquan", this.gridView1.GetFocusedRowCellValue("Id_Coquan"))) > 0)
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
            return base.PerformDelete(); ;
        }

        public override bool PerformSave()
        {          
            try
            {
                System.Collections.Hashtable htb = new System.Collections.Hashtable();
                htb.Add(txtMa_Coquan, lblMa_Coquan.Text);
                htb.Add(txtTen_Coquan, lblTen_Coquan.Text);

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(htb))
                    return false;

                if ("" + txtEmail.EditValue != "")
                {
                    String patterm = "[_]?([a-zA-Z1-9]+[_]?[a-zA-Z1-9]+)+[_]?[@][_]?([a-zA-Z1-9]+[_]?[a-zA-Z1-9]+)+[_]?([.][a-zA-Z1-9]+)+";
                    Regex check = new Regex(patterm, RegexOptions.IgnorePatternWhitespace);
                    if (!check.IsMatch(txtEmail.Text))
                    {
                         GoobizFrame.Windows.Forms.MessageDialog.Show("Email nhập chưa đúng ,nhập lại");
                        txtEmail.Focus();
                        return false;
                    }
                }

                if ("" + txtWebsite.EditValue != "")
                {
                    String patterm = "(http://)[_]?([a-zA-Z1-9]+[_]?[a-zA-Z1-9]+)+[_]?([.][a-zA-Z1-9]+)+";
                    Regex check = new Regex(patterm, RegexOptions.IgnorePatternWhitespace);
                    if (!check.IsMatch(txtWebsite.Text))
                    {
                         GoobizFrame.Windows.Forms.MessageDialog.Show("Website nhập chưa đúng ,nhập lại");
                        txtWebsite.Focus();
                        return false;
                    }
                }

                bool save = false;
                if (FormState ==  GoobizFrame.Windows.Forms.FormState.Add)
                    save = (bool)this.InsertObject();
                if (FormState ==  GoobizFrame.Windows.Forms.FormState.Edit)
                    save = (bool)this.UpdateObject();

                if (save)
                {
                    DisplayInfo();
                    //return true;
                }
                return save;
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("exists") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Coquan.Text, lblMa_Coquan.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
            dgrex_Dm_Coquan.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Coquan.EmbeddedNavigator.Buttons.EndEdit);
            
            System.Collections.Hashtable htb = new System.Collections.Hashtable();
            htb.Add(gridView1.Columns["Ma_Coquan"], "");
            htb.Add(gridView1.Columns["Ten_Coquan"], "");

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(htb, gridView1))
                return false;
            
            try
            {
                ds_Rex_Dm_Coquan.Tables[0].Columns["Ma_Coquan"].Unique = true;
                objMasterService.Update_Rex_Dm_Coquan_Collection(ds_Rex_Dm_Coquan);
            }
            catch (Exception ex) 
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Coquan.Text, lblMa_Coquan.Text });
                    return false;
                }
                //MessageBox.Show(ex.ToString());
            }
            DisplayInfo();
            return true;
        }
        #endregion

        #region Even

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            dgrex_Dm_Coquan.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Coquan.EmbeddedNavigator.Buttons.EndEdit);
            //save_perform = true;
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView1.FocusedColumn = gridView1.Columns["Ma_Coquan"];
            this.addnewrow_clicked = true;
            gridView1.OptionsBehavior.Editable = true;

        }

        private void dgrex_Dm_Coquan_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Coquan", "Id_Coquan", this.gridView1.GetFocusedRowCellValue("Id_Coquan"))) > 0)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    e.Handled = true;
                }
            }
        }

        private void txtMa_Coquan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;
        }
        #endregion

    }
}

