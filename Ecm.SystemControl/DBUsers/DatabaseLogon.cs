using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using GoobizFrame.Windows.Forms;

namespace Ecm.SystemControl.DBUsers
{
    public partial class DatabaseLogon : DevExpress.XtraEditors.XtraForm
    {
        Ecm.SystemControl.DBUsers.IDCardLogon objIDCardLogon;
        public struct SystemTime

        {

            public ushort Year;

            public ushort Month;

            public ushort DayOfWeek;

            public ushort Day;

            public ushort Hour;

            public ushort Minute;

            public ushort Second;

            public ushort Millisecond;

            public void FromDateTime(DateTime time)
            {
                Year = (ushort)time.Year;
                Month = (ushort)time.Month;
                DayOfWeek = (ushort)time.DayOfWeek;
                Day = (ushort)time.Day;
                Hour = (ushort)time.Hour;
                Minute = (ushort)time.Minute;
                Second = (ushort)time.Second;
                Millisecond = (ushort)time.Millisecond;
            }

        };

        
        [DllImport("kernel32.dll", EntryPoint = "GetSystemTime", SetLastError = true)]
        public extern static void Win32GetSystemTime(ref SystemTime sysTime);

        [DllImport("kernel32.dll", EntryPoint = "SetSystemTime", SetLastError = true)]
        public extern static bool Win32SetSystemTime(ref SystemTime sysTime);

        [DllImport("kernel32.dll")]
        static extern bool SetLocalTime([In] ref SystemTime lpLocalTime);

         GoobizFrame.Profile.Config config = new  GoobizFrame.Profile.Config(@"Resources\Default\ActiveDirectoryLogon.config");
        Ecm.WebReferences.Classes.PolicyService objPolicy = new Ecm.WebReferences.Classes.PolicyService();
        public event EventHandler LogonDomain;

        private void SetSystemTime(DateTime datetime)
        {
            // Set system date and time
            SystemTime updatedTime = new SystemTime();
            updatedTime.FromDateTime(datetime);
            // Call the unmanaged function that sets the new date and time instantly
            SetLocalTime(ref updatedTime);
        }

        public DatabaseLogon()
        {
            InitializeComponent();
            //UpdateGUI();
            //config = new  GoobizFrame.Profile.Config( GoobizFrame.Windows.CultureInfo.CultureInfoHelper.CurrentCultureInfoPath + @"\ActiveDirectoryLogon.config");
            //UpdateGUI();
        }

        private void checkLogonDomain_CheckedChanged(object sender, EventArgs e)
        {
            if (checkLogonDomain.Checked)
            {
                if (LogonDomain != null)
                    LogonDomain(sender, e);
            }
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
                    string user_password = textPassword.Text;
                    //Mã hóa password nếu password không rỗng
                    if (user_password != null && user_password != "")
                        user_password = SecurityManager.HashData(user_password);
                    //Tạo đối tượng Pol_Dm_User
                    Ecm.WebReferences.PolicyService.Pol_Dm_User Pol_Dm_User = new Ecm.WebReferences.PolicyService.Pol_Dm_User();
                    Pol_Dm_User.User_Name = user_name;
                    Pol_Dm_User.User_Password = user_password;
                    DataSet dsPol_Dm_User_Set = objPolicy.Pol_Dm_User_Select_ByAuth(Pol_Dm_User).ToDataSet();
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
                        SetSystemTime(objPolicy.GetCurrentDateTime());

                        WaitDialogForm.Close();
                         GoobizFrame.Windows.MdiUtils.MdiChecker.NotifyLogon.NotifyAfterLogon();
                        this.Close();
                    }
                    else
                         GoobizFrame.Windows.Forms.UserMessage.Show("Msg00007", new string[] {
                            textUser.Text});
                }
            }
            catch (Exception ex) {
                 GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), this.GetType().Name);
            }
            WaitDialogForm.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void buttonLogon_Click(object sender, EventArgs e)
        {
            LogOn();
        }

        //void UpdateGUI()
        //{
        //    //text
        //    config.GroupName = "ActiveDirectoryLogon";
        //    labelUser.Text = "" + config.GetValue("ControlText", labelUser.Name);
        //    labelPassword.Text = "" + config.GetValue("ControlText", labelPassword.Name);
        //    checkLogonDomain.Text = "" + config.GetValue("ControlText", checkLogonDomain.Name);
        //    buttonLogon.Text = "" + config.GetValue("ControlText", buttonLogon.Name);
        //    buttonCancel.Text = "" + config.GetValue("ControlText", buttonCancel.Name);

        //    //background
        //    panelBackground.ContentImage = Image.FromFile("" + config.GetValue("Bitmaps", "Background"));
        //}

        private void DatabaseLogon_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (this.ParentForm != null)
            //    this.ParentForm.Activate();
        }

        private void buttonCardLogon_Click(object sender, EventArgs e)
        {
            objIDCardLogon = (SystemControl.DBUsers.IDCardLogon) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(this.MdiParent, "IDCardLogon");
            if (objIDCardLogon == null)
                objIDCardLogon = new SystemControl.DBUsers.IDCardLogon();
            objIDCardLogon.MdiParent = this.MdiParent;
            objIDCardLogon.Show();
            objIDCardLogon.Activate();
            this.Close();
        }

        

       
    }
}