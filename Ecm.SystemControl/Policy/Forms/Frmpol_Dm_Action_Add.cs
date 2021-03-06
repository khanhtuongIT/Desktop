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
    public partial class Frmpol_Dm_Action_Add : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        SunLine.WebReferences.Classes.PolicyService objPolicy = new SunLine.WebReferences.Classes.PolicyService();
        SunLine.WebReferences.PolicyService.Pol_Dm_Action Pol_Dm_Action = new SunLine.WebReferences.PolicyService.Pol_Dm_Action();
        DataSet dsAction = new DataSet();

        public Frmpol_Dm_Action_Add()
        {
            InitializeComponent();

            //update GUI with current CultureInfo
            //System.Collections.ArrayList controls = new System.Collections.ArrayList();
            //controls.Add(this.lblId_Action);
            //controls.Add(this.lblAction_Name);
            //controls.Add(this.lblAction_Description);
            //controls.Add(this.gridColumn1);
            //controls.Add(this.gridColumn2);
            //controls.Add(this.gridColumn3);
            //GoobizFrame.Windows.CultureInfo.CultureInfoHelper.SetupFormCultureInfo(this, controls);
            //GoobizFrame.Windows.CultureInfo.CultureInfoHelper.SetupEmbeddedNavigatorCultureInfo(this, dgpol_Dm_Action);
        }

        private void Frmpol_Dm_Action_Add_Load(object sender, EventArgs e)
        {
            this.DisplayInfo();
            this.ChangeStatus(false);
        }

        public void DisplayInfo()
        {
            try
            {
                dsAction = objPolicy.Get_Pol_Dm_Action_Collection3();

                dgpol_Dm_Action.DataSource = dsAction;
                dgpol_Dm_Action.DataMember = dsAction.Tables[0].TableName;

                this.Data = dsAction;
                this.GridControl = dgpol_Dm_Action;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), this.GetType().Name);
                //////SunLine.HelperClasses.ExceptionLogger.LogException1(ex);
            }

            try
            {
                txtId_Action.DataBindings.Clear();
                txtAction_Name.DataBindings.Clear();
                txtAction_Description.DataBindings.Clear();
                if (dsAction.Tables[0].Rows.Count > 0)
                {
                    txtId_Action.DataBindings.Add("Text", dsAction, dsAction.Tables[0].TableName + ".Id_Action");
                    txtAction_Name.DataBindings.Add("Text", dsAction, dsAction.Tables[0].TableName + ".Action_Name");
                    txtAction_Description.DataBindings.Add("Text", dsAction, dsAction.Tables[0].TableName + ".Action_Description");
                }
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), this.GetType().Name);
            }
        }
        
        public void ChangeStatus(bool editable)
        {
            this.dgpol_Dm_Action.Enabled = !editable;
            this.txtAction_Name.Properties.ReadOnly = !editable;
            this.txtAction_Description.Properties.ReadOnly = !editable;
        }

        #region event override
        public object InsertObject()
        {
            SunLine.WebReferences.PolicyService.Pol_Dm_Action Pol_Dm_Action = new SunLine.WebReferences.PolicyService.Pol_Dm_Action();
            Pol_Dm_Action.Action_Name = this.txtAction_Name.Text;
            Pol_Dm_Action.Action_Description = this.txtAction_Description.Text;
            return objPolicy.Pol_Dm_Action_Insert(Pol_Dm_Action);
        }
        public object UpdateObject()
        {
            SunLine.WebReferences.PolicyService.Pol_Dm_Action Pol_Dm_Action = new SunLine.WebReferences.PolicyService.Pol_Dm_Action();
            Pol_Dm_Action.Id_Action = Convert.ToInt64(this.txtId_Action.Text);
            Pol_Dm_Action.Action_Name = this.txtAction_Name.Text;
            Pol_Dm_Action.Action_Description = this.txtAction_Description.Text;
            return objPolicy.Pol_Dm_Action_Update(Pol_Dm_Action);
        }
        public object DeleteObject()
        {
            SunLine.WebReferences.PolicyService.Pol_Dm_Action Pol_Dm_Action = new SunLine.WebReferences.PolicyService.Pol_Dm_Action();
            Pol_Dm_Action.Id_Action = Convert.ToInt64(this.txtId_Action.Text);
            return objPolicy.Pol_Dm_Action_Delete(Pol_Dm_Action);
        }
        public override bool PerformAdd()
        {
            this.ChangeStatus(true);
            this.txtId_Action.Text = "";
            this.txtAction_Name.Text = "";
            this.txtAction_Description.Text = "";
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
            bool saved = false;
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(txtAction_Name, lblAction_Name.Text);

            System.Collections.Hashtable htb_Action_Name = new System.Collections.Hashtable();
            htb_Action_Name.Add(txtAction_Name, lblAction_Name.Text);

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return false;
            if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
            {
                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htb_Action_Name, (DataSet)dgpol_Dm_Action.DataSource, "Action_Name"))
                    return false;
                this.InsertObject();
                saved = true;
            }
            else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
            {
                DataSet _ds = GoobizFrame.Windows.MdiUtils.Validator.datasetFillter((DataSet)dgpol_Dm_Action.DataSource, "Id_Action = " + txtId_Action.Text);
                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htb_Action_Name, _ds, "Action_Name"))
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
            hashtableControls.Add(gridView1.Columns["Action_Name"], "");

            System.Collections.Hashtable htb_Action_Name = new System.Collections.Hashtable();
            htb_Action_Name.Add(gridView1.Columns["Action_Name"], "");

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistGrid(htb_Action_Name, gridView1))
                return false;

            try
            {
                dgpol_Dm_Action.EmbeddedNavigator.Buttons.DoClick(dgpol_Dm_Action.EmbeddedNavigator.Buttons.EndEdit);
                objPolicy.Update_Pol_Dm_Action_Collection(dsAction);
            }
            catch (Exception ex)
            {
                //Error here
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), this.GetType().Name);
            }
            this.DisplayInfo();
            return true;
        }
        public override bool PerformDelete()
        {
            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
            GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Pol_Dm_Action"),
            GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Pol_Dm_Action")   }) == DialogResult.Yes)
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
                DataRow dr = dsAction.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    Pol_Dm_Action.Id_Action = dr["Id_Action"];
                    Pol_Dm_Action.Action_Name = dr["Action_Name"];
                    Pol_Dm_Action.Action_Description = dr["Action_Description"];
                }
                this.Dispose();
                this.Close();
                return Pol_Dm_Action;
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
            this.dgpol_Dm_Action.EmbeddedNavigator.Buttons.DoClick(dgpol_Dm_Action.EmbeddedNavigator.Buttons.EndEdit);
        }

        private void dgpol_Dm_Action_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Append)
            {
                this.gridView1.FocusedColumn = gridView1.Columns["Action_Name"];
                this.addnewrow_clicked = true;
            }
        }
    }
}