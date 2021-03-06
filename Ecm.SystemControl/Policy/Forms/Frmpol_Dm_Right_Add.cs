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
    public partial class Frmpol_Dm_Right_Add : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        SunLine.WebReferences.Classes.PolicyService objPolicy = new SunLine.WebReferences.Classes.PolicyService();
        SunLine.WebReferences.PolicyService.Pol_Dm_Right Pol_Dm_Right = new SunLine.WebReferences.PolicyService.Pol_Dm_Right();
        DataSet dsRight = new DataSet();

        GoobizFrame.Windows.Forms.Policy.Frmpol_Dm_Right_Properties _Frmpol_Dm_Right_Properties;

        public Frmpol_Dm_Right_Add()
        {
            InitializeComponent();
            //update GUI with current CultureInfo
            //System.Collections.ArrayList controls = new System.Collections.ArrayList();
            //controls.Add(this.lblId_Right);
            //controls.Add(this.lblRight_System_Name);
            //controls.Add(this.lblRight_Description);
            //controls.Add(this.gridColumn1);
            //controls.Add(this.gridColumn2);
            //controls.Add(this.gridColumn3);
            //controls.Add(this.btbRight_Properties);
            //GoobizFrame.Windows.CultureInfo.CultureInfoHelper.SetupFormCultureInfo(this, controls);
            //GoobizFrame.Windows.CultureInfo.CultureInfoHelper.SetupEmbeddedNavigatorCultureInfo(this, dgpol_Dm_Right);
        }

        private void Frmpol_Dm_Right_Add_Load(object sender, EventArgs e)
        {
            this.DisplayInfo();
            this.ChangeStatus(false);
        }

        public override void DisplayInfo()
        {
            try
            {
                dsRight = objPolicy.Get_Pol_Dm_Right_Collection3();

                dgpol_Dm_Right.DataSource = dsRight;
                dgpol_Dm_Right.DataMember = dsRight.Tables[0].TableName;

                this.Data = dsRight;
                this.GridControl = dgpol_Dm_Right;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), this.GetType().Name);

                //////SunLine.HelperClasses.ExceptionLogger.LogException1(ex);
            }

            try
            {
                txtId_Right.DataBindings.Clear();
                txtRight_System_Name.DataBindings.Clear();
                txtRight_Description.DataBindings.Clear();
                if (dsRight.Tables[0].Rows.Count > 0)
                {
                    txtId_Right.DataBindings.Add("Text", dsRight, dsRight.Tables[0].TableName + ".Id_Right");
                    txtRight_System_Name.DataBindings.Add("Text", dsRight, dsRight.Tables[0].TableName + ".Right_System_Name");
                    txtRight_Description.DataBindings.Add("Text", dsRight, dsRight.Tables[0].TableName + ".Right_Description");
                }
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), this.GetType().Name);
            }
        }

        public void ChangeStatus(bool editable)
        {
            this.dgpol_Dm_Right.Enabled = !editable;
            this.txtRight_System_Name.Properties.ReadOnly = !editable;
            this.txtRight_Description.Properties.ReadOnly = !editable;
        }

        #region event override
        public object InsertObject()
        {
            SunLine.WebReferences.PolicyService.Pol_Dm_Right Pol_Dm_Right = new SunLine.WebReferences.PolicyService.Pol_Dm_Right();
            Pol_Dm_Right.Right_System_Name = this.txtRight_System_Name.Text;
            Pol_Dm_Right.Right_Description = this.txtRight_Description.Text;
            return objPolicy.Pol_Dm_Right_Insert(Pol_Dm_Right);
        }
        public object UpdateObject()
        {
            SunLine.WebReferences.PolicyService.Pol_Dm_Right Pol_Dm_Right = new SunLine.WebReferences.PolicyService.Pol_Dm_Right();
            Pol_Dm_Right.Id_Right = Convert.ToInt64(this.txtId_Right.Text);
            Pol_Dm_Right.Right_System_Name = this.txtRight_System_Name.Text;
            Pol_Dm_Right.Right_Description = this.txtRight_Description.Text;
            return objPolicy.Pol_Dm_Right_Update(Pol_Dm_Right);
        }
        public object DeleteObject()
        {
            SunLine.WebReferences.PolicyService.Pol_Dm_Right Pol_Dm_Right = new SunLine.WebReferences.PolicyService.Pol_Dm_Right();
            Pol_Dm_Right.Id_Right = Convert.ToInt64(this.txtId_Right.Text);
            return objPolicy.Pol_Dm_Right_Delete(Pol_Dm_Right);
        }
        public override bool PerformAdd()
        {
            this.ChangeStatus(true);
            this.txtId_Right.Text = "";
            this.txtRight_System_Name.Text = "";
            this.txtRight_Description.Text = "";
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
            hashtableControls.Add(txtRight_System_Name, lblRight_System_Name.Text);

            System.Collections.Hashtable htb_Right_System_Name = new System.Collections.Hashtable();
            htb_Right_System_Name.Add(txtRight_System_Name, lblRight_System_Name.Text);

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return false;
            if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
            {
                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htb_Right_System_Name, (DataSet)dgpol_Dm_Right.DataSource, "Right_System_Name"))
                    return false;
                this.InsertObject();
                saved = true;
            }
            else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
            {
                DataSet _ds = GoobizFrame.Windows.MdiUtils.Validator.datasetFillter((DataSet)dgpol_Dm_Right.DataSource, "Id_Right = " + txtId_Right.Text);
                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htb_Right_System_Name, _ds, "Right_System_Name"))
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
            hashtableControls.Add(gridView1.Columns["Right_System_Name"], "");

            System.Collections.Hashtable htb_Right_System_Name = new System.Collections.Hashtable();
            htb_Right_System_Name.Add(gridView1.Columns["Right_System_Name"], "");

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;
            //if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistGrid(htb_Right_System_Name, gridView1))
            //    return false;

            try
            {
                dgpol_Dm_Right.EmbeddedNavigator.Buttons.DoClick(dgpol_Dm_Right.EmbeddedNavigator.Buttons.EndEdit);
                objPolicy.Update_Pol_Dm_Right_Collection(dsRight);
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
            GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Pol_Dm_Right"),
            GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Pol_Dm_Right")   }) == DialogResult.Yes)
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
                DataRow dr = dsRight.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    Pol_Dm_Right.Id_Right = dr["Id_Right"];
                    Pol_Dm_Right.Right_System_Name = dr["Right_System_Name"];
                    Pol_Dm_Right.Right_Description = dr["Right_Description"];
                }
                this.Dispose();
                this.Close();
                return Pol_Dm_Right;
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
            this.dgpol_Dm_Right.EmbeddedNavigator.Buttons.DoClick(dgpol_Dm_Right.EmbeddedNavigator.Buttons.EndEdit);
        }

        private void dgpol_Dm_Right_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Append)
            {
                this.gridView1.FocusedColumn = gridView1.Columns["Right_System_Name"];
                this.addnewrow_clicked = true;
            }
        }

        private void dgpol_Dm_Right_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Right)
            {
                if(item_Edit.Enabled ==true)
                    this.popupMenu1.ShowPopup(MousePosition);
            }
        }

        private void barManager1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "btbRight_Properties":
                    if (_Frmpol_Dm_Right_Properties == null || _Frmpol_Dm_Right_Properties.IsDisposed == true)
                        _Frmpol_Dm_Right_Properties = new GoobizFrame.Windows.Forms.Policy.Frmpol_Dm_Right_Properties();
                    _Frmpol_Dm_Right_Properties.Text = e.Item.Caption;
                    _Frmpol_Dm_Right_Properties.Id_Right = Convert.ToInt64(this.gridView1.GetFocusedRowCellValue("Id_Right"));
                    _Frmpol_Dm_Right_Properties.StartPosition = FormStartPosition.CenterScreen;
                    _Frmpol_Dm_Right_Properties.ShowDialog();
                    this.DisplayInfo();
                    break;
            }
        }
    }
}