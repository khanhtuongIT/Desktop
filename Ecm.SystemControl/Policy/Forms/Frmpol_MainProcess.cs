using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunLine.SystemControl.Policy.Forms
{
    public partial class Frmpol_MainProcess : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        SunLine.WebReferences.Classes.PolicyService objPolicy = new SunLine.WebReferences.Classes.PolicyService();
        SunLine.WebReferences.PolicyService.Pol_Dm_Role Pol_Dm_Role = new SunLine.WebReferences.PolicyService.Pol_Dm_Role();
        DataSet dsRole = new DataSet();
        DataSet DataSet_Pol_Dm_Right;
        DataSet DataSet_Pol_Dm_User;
        object Id_Role;

        Frmpol_Dm_Right_Find _Frmpol_Dm_Right_Find;
        Frmpol_Dm_User_Find _Frmpol_Dm_User_Find;
        Frmpol_Dm_Right_Properties _Frmpol_Dm_Right_Properties;
        Frmpol_Dm_User_Properties _Frmpol_Dm_User_Properties;

        public Frmpol_MainProcess()
        {
            InitializeComponent();

            DisplayInfo();
            DisplayRight();
            DisplayAction();
            DisplayUser();

            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }
        public void DisplayInfo()
        {
            try
            {
                dsRole = objPolicy.Get_Pol_Dm_Role_Collection3();
                dgpol_Dm_Role.DataSource = dsRole;
                dgpol_Dm_Role.DataMember = dsRole.Tables[0].TableName;


                this.Data = dsRole;
                this.GridControl = dgpol_Dm_Role;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), this.GetType().Name);

                //////SunLine.HelperClasses.ExceptionLogger.LogException1(ex);
            }


        }

        #region event override
        public override bool PerformSaveChanges()
        {
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Role_System_Name"], "");

            System.Collections.Hashtable htb_Role_System_Name = new System.Collections.Hashtable();
            htb_Role_System_Name.Add(gridView1.Columns["Role_System_Name"], "");

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistGrid(htb_Role_System_Name, gridView1))
                return false;

            try
            {
                dgpol_Dm_Role.EmbeddedNavigator.Buttons.DoClick(dgpol_Dm_Role.EmbeddedNavigator.Buttons.EndEdit);
                objPolicy.Update_Pol_Dm_Role_Collection(dsRole);
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
            GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Pol_Dm_Role"),
            GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Pol_Dm_Role")   }) == DialogResult.Yes)
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
        public object DeleteObject()
        {
            SunLine.WebReferences.PolicyService.Pol_Dm_Role Pol_Dm_Role = new SunLine.WebReferences.PolicyService.Pol_Dm_Role();
            Pol_Dm_Role.Id_Role = Convert.ToInt64(this.gridView1.GetFocusedRowCellValue("Id_Role"));
            return objPolicy.Pol_Dm_Role_Delete(Pol_Dm_Role);
        }
        public override bool PerformCancel()
        {
            this.DisplayInfo();
            DisplayRight();
            DisplayAction();
            DisplayUser();

            return true;
        }
        #endregion

        private void dgpol_Dm_Role_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {

        }

        /// <summary>
        /// focus role
        /// - display right & user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            dgpol_Role_Right.DataSource = null;
            dgpol_Role_Action.DataSource = null;
            dgpol_Role_User.DataSource = null;

            if (gridView1.FocusedRowHandle >= 0)
            {
                Id_Role = gridView1.GetFocusedRowCellValue("Id_Role");
                if ("" + Id_Role != "")
                {
                    DisplayRight();
                    DisplayUser();
                    DisplayAction();
                }
                
            }
        }

        /// <summary>
        /// display right
        /// </summary>
        public void DisplayRight()
        {
            Id_Role = gridView1.GetFocusedRowCellValue("Id_Role");
            SunLine.WebReferences.PolicyService.Pol_Role_Right Pol_Role_Right = new SunLine.WebReferences.PolicyService.Pol_Role_Right();
            Pol_Role_Right.Id_Role = Id_Role;
            DataSet_Pol_Dm_Right = objPolicy.Select_Pol_Role_Right_ByIDRole3(Pol_Role_Right);
            DataSet_Pol_Dm_Right.Tables[0].Columns.Add("Chon", typeof(bool));
            this.dgpol_Role_Right.DataSource = DataSet_Pol_Dm_Right.Tables[0];
            if (DataSet_Pol_Dm_Right.Tables[0].Rows.Count > 0)
            {
                this.btbRole_Right_Delete.Enabled = true;
            }
            else
            {
                this.btbRole_Right_Delete.Enabled = false;
            }
            chkAll_role_right.EditValue = null;
            
        }

        /// <summary>
        /// display user
        /// </summary>
        public void DisplayUser()
        {
            SunLine.WebReferences.PolicyService.Pol_User_Role Pol_User_Role = new SunLine.WebReferences.PolicyService.Pol_User_Role();
            Pol_User_Role.Id_Role = Id_Role;
            DataSet_Pol_Dm_User = objPolicy.Select_Pol_User_Role_ByIDRole3(Pol_User_Role);
            DataSet_Pol_Dm_User.Tables[0].Columns.Add("Chon", typeof(bool));
            this.dgpol_Role_User.DataSource = DataSet_Pol_Dm_User.Tables[0];
            if (DataSet_Pol_Dm_User.Tables[0].Rows.Count > 0)
            {
                this.btbRole_User_Delete.Enabled = true;
            }
            else
            {
                this.btbRole_User_Delete.Enabled = false;
            }

            chkAll_User_Role.EditValue = null;
        }

        /// <summary>
        /// focus right
        /// - display action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView4_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView4.FocusedRowHandle >= 0)
            {
                    DisplayAction();
            }
        }

        /// <summary>
        /// display action
        /// </summary>
        public void DisplayAction()
        {
            object Id_Right = this.gridView4.GetFocusedRowCellValue("Id_Right");
            if ("" + Id_Right != "")
            {
                //chkAll_Action.EditValue = null;

                SunLine.WebReferences.PolicyService.Pol_Action_Role Pol_Action_Role = new SunLine.WebReferences.PolicyService.Pol_Action_Role();
                Pol_Action_Role.Id_Role = Id_Role;
                Pol_Action_Role.Id_Right = Convert.ToInt64(this.gridView4.GetFocusedRowCellValue("Id_Right"));
                DataSet DataSet_Pol_Dm_Action = objPolicy.Select_Pol_Action_Role_ByID_RoleRight3(Pol_Action_Role);
                //DataSet_Pol_Dm_Action.Tables[0].Columns["IsActive"].DataType =  typeof(bool);
                this.dgpol_Role_Action.DataSource = DataSet_Pol_Dm_Action.Tables[0];
                
            }
        }

        private void btbRole_Right_Delete_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = GoobizFrame.Windows.Forms.UserMessage.Show("Msg00021", new string[] { "quyền" });
            if (dlgResult == DialogResult.Yes)
            {
                this.DeleteRight();
            }
        }
        /// <summary>
        /// delete right
        /// </summary>
        /// <returns></returns>
        public bool DeleteRight()
        {
            try
            {
                DataRow  [] sdr_Pol_Dm_Right = DataSet_Pol_Dm_Right.Tables[0].Select("Chon = true");
                for (int i = 0; i < sdr_Pol_Dm_Right.Length; i++)
                {
                    SunLine.WebReferences.PolicyService.Pol_Role_Right Pol_Role_Right = new SunLine.WebReferences.PolicyService.Pol_Role_Right();
                    Pol_Role_Right.Id_Right = Convert.ToInt64(sdr_Pol_Dm_Right[i]["Id_Right"]);
                    Pol_Role_Right.Id_Role = Id_Role;
                    objPolicy.Pol_Role_Right_Delete(Pol_Role_Right);
                }
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), this.GetType().Name);
                return false;
            }
            this.DisplayRight();
            return true;
        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "IsActive")
            {
                try
                {
                    SunLine.WebReferences.PolicyService.Pol_Action_Role Pol_Action_Role = new SunLine.WebReferences.PolicyService.Pol_Action_Role();
                    Pol_Action_Role.Id_Action = gridView2.GetFocusedRowCellValue("Id_Action");
                    Pol_Action_Role.Id_Right = Convert.ToInt64(this.gridView4.GetFocusedRowCellValue("Id_Right"));
                    Pol_Action_Role.Id_Role = Id_Role;
                    if (Convert.ToBoolean(e.Value))
                        objPolicy.Pol_Action_Role_Insert(Pol_Action_Role);
                    else
                        objPolicy.Pol_Action_Role_Delete(Pol_Action_Role);

                    DisplayAction();
                }
                catch { }
            }
        }


        private void btbRole_Right_Add_Click(object sender, EventArgs e)
        {
            if (_Frmpol_Dm_Right_Find == null || _Frmpol_Dm_Right_Find.IsDisposed == true)
                _Frmpol_Dm_Right_Find = new Frmpol_Dm_Right_Find();
            GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(_Frmpol_Dm_Right_Find);
            GoobizFrame.Windows.PlugIn.RightHelpers.CheckUserRightAction(_Frmpol_Dm_Right_Find);
            _Frmpol_Dm_Right_Find.ShowDialog();
            if (_Frmpol_Dm_Right_Find.Id_Right_Selected != null && _Frmpol_Dm_Right_Find.Id_Right_Selected.Length > 0)
                this.AddRight(_Frmpol_Dm_Right_Find.Id_Right_Selected);
            this.DisplayRight();
        }

        /// <summary>
        /// add right
        /// </summary>
        /// <param name="Id_Right_Set"></param>
        public void AddRight(long[] Id_Right_Set)
        {
            for (int i = 0; i < Id_Right_Set.Length; i++)
            {
                try
                {
                    SunLine.WebReferences.PolicyService.Pol_Role_Right Pol_Role_Right = new SunLine.WebReferences.PolicyService.Pol_Role_Right();
                    Pol_Role_Right.Id_Right = Id_Right_Set[i];
                    Pol_Role_Right.Id_Role = Id_Role;
                    objPolicy.Pol_Role_Right_Insert(Pol_Role_Right);
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), this.GetType().Name);
                }
            }
        }

        private void btbRole_User_Delete_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = GoobizFrame.Windows.Forms.UserMessage.Show("Msg00021", new string[] { "người dùng" });
            if (dlgResult == DialogResult.Yes)
            {
                this.DeleteUser();
            }
        }

        public bool DeleteUser()
        {
            try
            {
                DataRow  [] sdr_Pol_Dm_User = DataSet_Pol_Dm_User.Tables[0].Select("Chon = true");
                
                for (int i = 0; i < sdr_Pol_Dm_User.Length; i++)
                {
                    SunLine.WebReferences.PolicyService.Pol_User_Role Pol_User_Role = new SunLine.WebReferences.PolicyService.Pol_User_Role();
                    Pol_User_Role.Id_User = Convert.ToInt64(sdr_Pol_Dm_User[i]["Id_User"]);
                    Pol_User_Role.Id_Role = Id_Role;
                    objPolicy.Pol_User_Role_Delete(Pol_User_Role);
                }
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), this.GetType().Name);
                return false;
            }
            this.DisplayUser();
            return true;
        }

        private void btbRole_User_Add_Click(object sender, EventArgs e)
        {
            if (_Frmpol_Dm_User_Find == null || _Frmpol_Dm_User_Find.IsDisposed == true)
                _Frmpol_Dm_User_Find = new Frmpol_Dm_User_Find();
            _Frmpol_Dm_User_Find.StartPosition = FormStartPosition.CenterScreen;
            _Frmpol_Dm_User_Find.ShowDialog();
            if (_Frmpol_Dm_User_Find.Id_User_Selected != null && _Frmpol_Dm_User_Find.Id_User_Selected.Length > 0)
                this.AddUser(_Frmpol_Dm_User_Find.Id_User_Selected);
            this.DisplayUser();
        }
         
        public void AddUser(long[] Id_User_Set)
        {
            for (int i = 0; i < Id_User_Set.Length; i++)
            {
                try
                {
                    SunLine.WebReferences.PolicyService.Pol_User_Role Pol_User_Role = new SunLine.WebReferences.PolicyService.Pol_User_Role();
                    Pol_User_Role.Id_User = Id_User_Set[i];
                    Pol_User_Role.Id_Role = Id_Role;
                    objPolicy.Pol_User_Role_Insert(Pol_User_Role);
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), this.GetType().Name);
                }
            }
        }

        private void chkAll_role_right_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataRow dr in DataSet_Pol_Dm_Right.Tables[0].Rows)
                dr["Chon"] = chkAll_role_right.EditValue;
        }

        private void chkAll_User_Role_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataRow dr in DataSet_Pol_Dm_User.Tables[0].Rows)
                dr["Chon"] = chkAll_User_Role.EditValue;
        }

        private void chkAll_Action_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                gridView2.FocusedRowHandle = i;
                gridView2.Focus();
                gridView2.SetRowCellValue(i, "IsActive", chkAll_Action.Checked);
            }
        }

        /// <summary>
        /// show Frmpol_Dm_Right_Properties
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (_Frmpol_Dm_Right_Properties == null || _Frmpol_Dm_Right_Properties.IsDisposed == true)
                _Frmpol_Dm_Right_Properties = new Frmpol_Dm_Right_Properties();
            _Frmpol_Dm_Right_Properties.Text = gridView4.FocusedColumn.Caption + ": " + gridView4.GetFocusedRowCellDisplayText("Right_Description");
            _Frmpol_Dm_Right_Properties.Id_Right = Convert.ToInt64(this.gridView4.GetFocusedRowCellValue("Id_Right"));
            GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(_Frmpol_Dm_Right_Properties);
          
            _Frmpol_Dm_Right_Properties.ShowDialog();
        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (_Frmpol_Dm_User_Properties == null || _Frmpol_Dm_User_Properties.IsDisposed)
                _Frmpol_Dm_User_Properties = new Frmpol_Dm_User_Properties();
            _Frmpol_Dm_User_Properties.Id_User = Convert.ToInt64( gridView3.GetFocusedRowCellValue("Id_User") );
            _Frmpol_Dm_User_Properties.Text = gridView3.FocusedColumn.Caption + ": " + gridView3.GetFocusedRowCellDisplayText("User_Fullname");
            GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(_Frmpol_Dm_User_Properties);

            _Frmpol_Dm_User_Properties.ShowDialog();
        }
    }
}