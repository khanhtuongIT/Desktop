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
    public partial class Frmpol_Change_Password : DevExpress.XtraEditors.XtraForm
    {
        private long id_user;
        private string user_name;
        private string old_password;

        SunLine.WebReferences.Classes.PolicyService objPolicy = new SunLine.WebReferences.Classes.PolicyService();

        public Frmpol_Change_Password()
        {
            InitializeComponent();
        }

        public bool UserInfo()
        {
            try
            {
                SunLine.WebReferences.PolicyService.Pol_Dm_User Pol_Dm_User = new SunLine.WebReferences.PolicyService.Pol_Dm_User();
                Pol_Dm_User.User_Name = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUser();
                DataSet Pol_Dm_User_Set = objPolicy.Pol_Dm_User_Select_ByName(Pol_Dm_User);
                this.id_user = Convert.ToInt64("" + Pol_Dm_User_Set.Tables[0].Rows[0]["Id_User"]);
                this.old_password = "" + Pol_Dm_User_Set.Tables[0].Rows[0]["User_Password"];
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), this.GetType().Name); 
                return false;
            }
            return true;
        }

        public bool ChangePassword()
        {
            try
            {
                if (!UserInfo())
                    return false;
                if (!CheckValidInput())
                    return false;
                if (!CheckOldPassword())
                    return false;
                SunLine.WebReferences.PolicyService.Pol_Dm_User Pol_Dm_User = new SunLine.WebReferences.PolicyService.Pol_Dm_User();
                Pol_Dm_User.Id_User = id_user;
                if (this.txtNew_Pass.Text != null && this.txtNew_Pass.Text != "")
                {
                    Pol_Dm_User.User_Password = SecurityManager.HashData(this.txtNew_Pass.Text);
                }
                else
                {
                    Pol_Dm_User.User_Password = "";
                }
                objPolicy.Pol_Dm_User_Password_Update(Pol_Dm_User);
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), this.GetType().Name); 
                //GoobizFrame.Windows.Forms.UserMessage.Show("Msg00022", new string[] { "thay đổi mật khẩu" });
                return false;
            }
            return true;
        }

        public bool CheckOldPassword()
        {
            if (this.old_password == null || this.old_password == "")
            {
                if (this.txtOld_Pass.Text != "")
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("Msg00019", new string[] { "Mật khẩu", "mật khẩu" });
                    this.txtOld_Pass.Focus();
                    return false;
                }
            }
            else
            {
                if (this.old_password != SecurityManager.HashData(this.txtOld_Pass.Text))
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("Msg00019", new string[] { "Mật khẩu", "mật khẩu" });
                    this.txtOld_Pass.Focus();
                    return false;
                }
            }
            return true;
        }

        public bool CheckValidInput()
        {
            if (this.txtNew_Pass.Text != this.txtConfirm_New.Text)
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("Msg00019", new string[] { "Mật khẩu mới", "mật khẩu mới" });
                this.txtConfirm_New.Focus();
                return false;
            }
            return true;
        }

        private void btbCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btbOk_Click(object sender, EventArgs e)
        {
            if (this.ChangePassword())
                this.Dispose();
        }
    }
}