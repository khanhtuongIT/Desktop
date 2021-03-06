using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SunLine.SystemControl.Policy.Forms
{
    public partial class Frmpol_Dm_User_Add : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        SunLine.WebReferences.Classes.PolicyService objPolicy = new SunLine.WebReferences.Classes.PolicyService();
        SunLine.WebReferences.PolicyService.Pol_Dm_User Pol_Dm_User = new SunLine.WebReferences.PolicyService.Pol_Dm_User();
        DataSet dsUser = new DataSet();

        Frmpol_Dm_User_Properties _Frmpol_Dm_User_Properties;

        public Frmpol_Dm_User_Add()
        {
            InitializeComponent();
            //update GUI with current CultureInfo
            //System.Collections.ArrayList controls = new System.Collections.ArrayList();
            //controls.Add(this.lblId_User);
            //controls.Add(this.lblUser_Name);
            //controls.Add(this.lblUser_Fullname);
            //controls.Add(this.lblUser_Description);
            //controls.Add(this.gridColumn1);
            //controls.Add(this.gridColumn2);
            //controls.Add(this.gridColumn3);
            //controls.Add(this.gridColumn4);
            //controls.Add(this.btbUser_Properties);
            //SunLine.CultureInfo.Utils.CultureInfoHelper.SetupFormCultureInfo(this, controls);
            //SunLine.CultureInfo.Utils.CultureInfoHelper.SetupEmbeddedNavigatorCultureInfo(this, dgpol_Dm_User);

            string adPath = GoobizFrame.Windows.Forms.ADUsers.ADHelper.GetCurrentDomain();
            if (adPath != "")
            {
                btnAdd_ADUser.Text += ": "+ adPath;
                btnAdd_ADUser.Enabled = true;
            }
            else
                btnAdd_ADUser.Enabled = false;
        }

        private void Frmpol_Dm_User_Add_Load(object sender, EventArgs e)
        {
            this.DisplayInfo();
            this.ChangeStatus(false);
        }

        public override void DisplayInfo()
        {
            try
            {
                //lookup
                DataSet dsRex_Nhansu = objPolicy.Get_All_Rex_Nhansu_Collection3();
                lookUpEdit_Nhansu.Properties.DataSource = dsRex_Nhansu.Tables[0];
                gridLookUpEdit_Nhansu.DataSource = dsRex_Nhansu.Tables[0];

                //gridview1
                dsUser = objPolicy.Get_Pol_Dm_User_Collection3();
                dgpol_Dm_User.DataSource = dsUser;
                dgpol_Dm_User.DataMember = dsUser.Tables[0].TableName;

                this.Data = dsUser;
                this.GridControl = dgpol_Dm_User;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), this.GetType().Name);

                //////SunLine.HelperClasses.ExceptionLogger.LogException1(ex);
            }

            try
            {
                ClearDataBinding();
                if (dsUser.Tables[0].Rows.Count > 0)
                {
                    txtId_User.DataBindings.Add("Text", dsUser, dsUser.Tables[0].TableName + ".Id_User");
                    bteUser_Name.DataBindings.Add("Text", dsUser, dsUser.Tables[0].TableName + ".User_Name");
                    txtUser_Fullname.DataBindings.Add("Text", dsUser, dsUser.Tables[0].TableName + ".User_Fullname");
                    txtUser_Description.DataBindings.Add("Text", dsUser, dsUser.Tables[0].TableName + ".User_Description");
                    lookUpEdit_Nhansu.DataBindings.Add("EditValue", dsUser, dsUser.Tables[0].TableName + ".Id_Nhansu");
                }

            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), this.GetType().Name);
            }

            
        }

        public void ClearDataBinding()
        {
            txtId_User.DataBindings.Clear();
            bteUser_Name.DataBindings.Clear();
            txtUser_Fullname.DataBindings.Clear();
            txtUser_Description.DataBindings.Clear();
            lookUpEdit_Nhansu.DataBindings.Clear();
        }

        public void ChangeStatus(bool editable)
        {
            this.dgpol_Dm_User.Enabled = !editable;
            this.bteUser_Name.Properties.ReadOnly = !editable;
            this.txtUser_Fullname.Properties.ReadOnly = !editable;
            this.txtUser_Description.Properties.ReadOnly = !editable;
            this.lookUpEdit_Nhansu.Properties.ReadOnly = !editable;
        }
        

        #region event override
        public object InsertObject()
        {
            SunLine.WebReferences.PolicyService.Pol_Dm_User Pol_Dm_User = new SunLine.WebReferences.PolicyService.Pol_Dm_User();
            Pol_Dm_User.User_Name = this.bteUser_Name.Text;
            Pol_Dm_User.User_Fullname = this.txtUser_Fullname.Text;
            Pol_Dm_User.User_Description = this.txtUser_Description.Text;
            Pol_Dm_User.Id_Nhansu =  this.lookUpEdit_Nhansu.EditValue;

            //get new identity
            Pol_Dm_User.Id_User =  objPolicy.Pol_Dm_User_Insert(Pol_Dm_User);

            return Pol_Dm_User.Id_User;
        }
        public object UpdateObject()
        {
            SunLine.WebReferences.PolicyService.Pol_Dm_User Pol_Dm_User = new SunLine.WebReferences.PolicyService.Pol_Dm_User();
            Pol_Dm_User.Id_User = Convert.ToInt64(this.txtId_User.Text);
            Pol_Dm_User.User_Name = this.bteUser_Name.Text;
            Pol_Dm_User.User_Fullname = txtUser_Fullname.Text;
            Pol_Dm_User.User_Description = this.txtUser_Description.Text;
            Pol_Dm_User.Id_Nhansu = this.lookUpEdit_Nhansu.EditValue;

            return objPolicy.Pol_Dm_User_Update(Pol_Dm_User);
        }
        public object DeleteObject()
        {
            SunLine.WebReferences.PolicyService.Pol_Dm_User Pol_Dm_User = new SunLine.WebReferences.PolicyService.Pol_Dm_User();
            Pol_Dm_User.Id_User = Convert.ToInt64(this.txtId_User.Text);
            return objPolicy.Pol_Dm_User_Delete(Pol_Dm_User);
        }
        public override bool PerformAdd()
        {
            this.ClearDataBinding();
            this.ChangeStatus(true);
            this.txtId_User.Text = "";
            this.bteUser_Name.Text = "";
            this.txtUser_Fullname.Text = "";
            this.txtUser_Description.Text = "";
            return true;
        }
        public override bool PerformEdit()
        {
            this.ClearDataBinding();
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
            bool saved = false;
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(bteUser_Name, lblUser_Name.Text);
            hashtableControls.Add(txtUser_Fullname, lblUser_Fullname.Text);

            System.Collections.Hashtable htb_User_Name = new System.Collections.Hashtable();
            htb_User_Name.Add(bteUser_Name, lblUser_Name.Text);

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return false;
            if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
            {
                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htb_User_Name, (DataSet)dgpol_Dm_User.DataSource, "User_Name"))
                    return false;
                this.InsertObject();
                saved = true;
            }
            else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
            {
                DataSet _ds = GoobizFrame.Windows.MdiUtils.Validator.datasetFillter((DataSet)dgpol_Dm_User.DataSource, "Id_User = " + txtId_User.Text);
                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htb_User_Name, _ds, "User_Name"))
                    return false;
                this.UpdateObject();
                saved = true;
            }
            if (saved)
            {
                this.DisplayInfo();
                this.ChangeStatus(false);
            }
            return saved;
        }
        public override bool PerformSaveChanges()
        {
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["User_Name"], "");
            hashtableControls.Add(gridView1.Columns["User_Fullname"], "");

            System.Collections.Hashtable htb_User_Name = new System.Collections.Hashtable();
            htb_User_Name.Add(gridView1.Columns["User_Name"], "");
            htb_User_Name.Add(gridView1.Columns["Id_Nhansu"], "");

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistGrid(htb_User_Name, gridView1))
                return false;

            try
            {
                dgpol_Dm_User.EmbeddedNavigator.Buttons.DoClick(dgpol_Dm_User.EmbeddedNavigator.Buttons.EndEdit);
                objPolicy.Update_Pol_Dm_User_Collection(dsUser);
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), this.GetType().Name);
            }
            this.DisplayInfo();
            return true;
        }
        public override bool PerformDelete()
        {
            if ("" + gridView1.GetFocusedRowCellValue("Id_User") == GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUserId()
                || "" + gridView1.GetFocusedRowCellValue("User_Name") == "admin")
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
            }
            else if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
            GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Pol_Dm_User"),
            GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Pol_Dm_User")   }) == DialogResult.Yes)
            {
                try
                {
                    this.DeleteObject();
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), this.GetType().Name);
                }
                this.DisplayInfo();
            }
            return base.PerformDelete();
        }

        public override object PerformSelectOneObject()
        {
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = dsUser.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    Pol_Dm_User.Id_User = dr["Id_User"];
                    Pol_Dm_User.User_Name = dr["User_Name"];
                    Pol_Dm_User.User_Fullname = dr["User_Fullname"];
                    Pol_Dm_User.User_Description = dr["User_Description"];
                }
                this.Dispose();
                this.Close();
                return Pol_Dm_User;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), this.GetType().Name);
                return null;
            }
        }
        #endregion

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Id_Nhansu")
            {
                gridView1.SetFocusedRowCellValue(gridView1.Columns["User_Fullname"],
                    ((System.Data.DataRowView)gridLookUpEdit_Nhansu.GetDataSourceRowByKeyValue(e.Value))["Hoten_Nhansu"]);
            }
            else if (e.Column.FieldName == "User_Disable")
            {
                if ("" + gridView1.GetFocusedRowCellValue("Id_User") == GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUserId()
                                || "" + gridView1.GetFocusedRowCellValue("User_Name") == "admin")
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                    gridView1.CancelUpdateCurrentRow();
                }
            }

            this.dgpol_Dm_User.EmbeddedNavigator.Buttons.DoClick(dgpol_Dm_User.EmbeddedNavigator.Buttons.EndEdit);
        }

        private void dgpol_Dm_User_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Append)
            {
                this.gridView1.FocusedColumn = gridView1.Columns["User_Name"];
                this.addnewrow_clicked = true;
            }
            else if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + gridView1.GetFocusedRowCellValue("Id_User") == GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUserId()
                                || "" + gridView1.GetFocusedRowCellValue("User_Name") == "admin")
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                    e.Handled = true;
                }
                else if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
                    GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Pol_Dm_User"),
                    GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Pol_Dm_User")   }) == DialogResult.No)
                {
                    e.Handled = true;
                }
            }
        }

        private void dgpol_Dm_User_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (item_Edit.Enabled == true)
                    this.popupMenu1.ShowPopup(MousePosition);
            }
        }
        
        private void barManager1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch(e.Item.Name)
            {
                case "btbUser_Properties":
                    if (_Frmpol_Dm_User_Properties == null || _Frmpol_Dm_User_Properties.IsDisposed == true)
                        _Frmpol_Dm_User_Properties = new Frmpol_Dm_User_Properties();
                    _Frmpol_Dm_User_Properties.Text = e.Item.Caption;
                    _Frmpol_Dm_User_Properties.Id_User = Convert.ToInt64(this.gridView1.GetFocusedRowCellValue("Id_User"));
                    _Frmpol_Dm_User_Properties.StartPosition = FormStartPosition.CenterScreen;
                    _Frmpol_Dm_User_Properties.ShowDialog();
                    this.DisplayInfo();
                    break;
            }
        }
       

        private void lookUpEdit_Nhansu_EditValueChanged(object sender, EventArgs e)
        {
            txtUser_Fullname.Text = ""+lookUpEdit_Nhansu.GetColumnValue("Hoten_Nhansu");

            
        }

        private void btnAdd_ADUser_Click(object sender, EventArgs e)
        {
            GoobizFrame.Windows.Forms.ADUsers.FrmADDomainUsers_Dialog frmADDomainUsers_Dialog = new GoobizFrame.Windows.Forms.ADUsers.FrmADDomainUsers_Dialog();
            frmADDomainUsers_Dialog.ShowDialog();

            if (frmADDomainUsers_Dialog.Dr_Selected_ADUsers.Length > 0)
            {
                foreach (DataRow dr_ADUser in frmADDomainUsers_Dialog.Dr_Selected_ADUsers)
                {
                    DataRow ndr_User = dsUser.Tables[0].NewRow();

                    ndr_User["User_Name"] = dr_ADUser["SamAccountName"];

                    dsUser.Tables[0].Rows.Add(ndr_User);
                }
            }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
            {
                GoobizFrame.Windows.Forms.ADUsers.FrmADDomainUsers_Dialog frmADDomainUsers_Dialog = new GoobizFrame.Windows.Forms.ADUsers.FrmADDomainUsers_Dialog();
                frmADDomainUsers_Dialog.ShowDialog();

                if (frmADDomainUsers_Dialog.Dr_Selected_ADUsers.Length > 0)
                {
                    gridView1.SetFocusedRowCellValue(gridView1.Columns["User_Name"], frmADDomainUsers_Dialog.Dr_Selected_ADUsers[0]["SamAccountName"]);
                }
            }
        }

        private void bteUser_Name_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
            {
                GoobizFrame.Windows.Forms.ADUsers.FrmADDomainUsers_Dialog frmADDomainUsers_Dialog = new GoobizFrame.Windows.Forms.ADUsers.FrmADDomainUsers_Dialog();
                frmADDomainUsers_Dialog.ShowDialog();

                if (frmADDomainUsers_Dialog.Dr_Selected_ADUsers.Length > 0)
                {
                    bteUser_Name.Text = ""+frmADDomainUsers_Dialog.Dr_Selected_ADUsers[0]["SamAccountName"];
                }
            }
        }
    }
}