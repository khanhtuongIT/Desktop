using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;

namespace Ecm.SystemControl.DBUsers
{
    public partial class IDCardLogon : DevExpress.XtraEditors.XtraForm
    {
        Ecm.WebReferences.Classes.PolicyService objPolicy = new Ecm.WebReferences.Classes.PolicyService();
        Ecm.SystemControl.DBUsers.DatabaseLogon databaseLogon;
         GoobizFrame.Profile.Config config = new  GoobizFrame.Profile.Config(@"Resources\Default\ActiveDirectoryLogon.config");

        public IDCardLogon()
        {
            InitializeComponent();
            //config = new  GoobizFrame.Profile.Config( GoobizFrame.Windows.MdiUtils.CultureInfoHelper.CurrentCultureInfoPath + @"\ActiveDirectoryLogon.config");
            //background
            //config.GroupName = "ActiveDirectoryLogon";
            //panelBackground.ContentImage = Image.FromFile("" + config.GetValue("Bitmaps", "Background"));
        }

        private void textUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        void LogOn()
        {
            DevExpress.Utils.WaitDialogForm WaitDialogForm = new DevExpress.Utils.WaitDialogForm();
            try
            {
                if (textUser.Text.Trim() == "")
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("Msg00008", new string[] {
                            labelUser.Text});
                    return;
                }
                else
                {
                    string user_name = textUser.Text;
                    //Mã hóa password nếu password không rỗng
                    string user_password = "";
                    if (user_password != null && user_password != "")
                        user_password = SecurityManager.HashData(user_password);
                    //Tạo đối tượng Pol_Dm_User
                    Ecm.WebReferences.PolicyService.Pol_Dm_User Pol_Dm_User = new Ecm.WebReferences.PolicyService.Pol_Dm_User();
                    Pol_Dm_User.User_Name = user_name;
                    Pol_Dm_User.User_Password = user_password;
                    DataSet dsPol_Dm_User_Set = objPolicy.Pol_Dm_User_Select_ByMa_Nhansu(user_name).ToDataSet();
                    if (dsPol_Dm_User_Set.Tables[0].Rows.Count > 0)
                    {
                        //Lưu định danh của người đăng nhập 
                         GoobizFrame.Windows.MdiUtils.ThemeSettings.SetCurrentUser("" + dsPol_Dm_User_Set.Tables[0].Rows[0]["User_Name"]);
                         GoobizFrame.Windows.MdiUtils.ThemeSettings.SetCurrentUserId("" + dsPol_Dm_User_Set.Tables[0].Rows[0]["Id_User"]);
                         GoobizFrame.Windows.MdiUtils.ThemeSettings.SetCurrentId_Nhansu("" + dsPol_Dm_User_Set.Tables[0].Rows[0]["Id_Nhansu"]);
                         GoobizFrame.Windows.MdiUtils.ThemeSettings.SetCurrentUserEntry("User_Fullname", "" + dsPol_Dm_User_Set.Tables[0].Rows[0]["User_Fullname"]);

                        Ecm.WebReferences.PolicyService.Pol_User_Right Pol_User_Right = new Ecm.WebReferences.PolicyService.Pol_User_Right();
                        Pol_User_Right.Id_User = dsPol_Dm_User_Set.Tables[0].Rows[0]["Id_User"];
                        DataSet dsPol_User_Right = objPolicy.Select_Pol_User_Right_ByIDUser3(Pol_User_Right).ToDataSet();
                        if (dsPol_User_Right.Tables[0].Rows.Count == 1)
                             GoobizFrame.Windows.MdiUtils.ThemeSettings.SetCurrentUserRight("" + dsPol_User_Right.Tables[0].Rows[0]["Right_System_Name"]);
                        else
                             GoobizFrame.Windows.MdiUtils.ThemeSettings.SetCurrentUserRight("");

                         GoobizFrame.Windows.MdiUtils.MdiChecker.UnLockParentForm(this.ParentForm);
                        //SetSystemTime(objPolicy.GetCurrentDateTime());

                        WaitDialogForm.Close();
                         GoobizFrame.Windows.MdiUtils.MdiChecker.NotifyLogon.NotifyAfterLogon();
                        this.Close();
                    }
                    else
                         GoobizFrame.Windows.Forms.UserMessage.Show("Msg00007", new string[] {
                            textUser.Text});
                }
            }
            catch (Exception ex)
            {
                 GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), this.GetType().Name);
            }
            WaitDialogForm.Close();
        }

        private void buttonLogon_Click(object sender, EventArgs e)
        {
            databaseLogon = (SystemControl.DBUsers.DatabaseLogon) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(this.MdiParent, "DatabaseLogon");
            if (databaseLogon == null)
                databaseLogon = new DatabaseLogon();
            databaseLogon.MdiParent = this.MdiParent;
            databaseLogon.Show();
            databaseLogon.Activate();
            this.Close();
        }

        private void textUser_TextChanged(object sender, EventArgs e)
        {
            //LogOn();
        }

        private void textUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && textUser.Text != "")
                LogOn();
        }

        
    }
}