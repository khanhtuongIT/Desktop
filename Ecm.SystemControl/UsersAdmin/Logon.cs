using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Ecm.SystemControl.UsersAdmin
{
    public class Logon
    {
        public static bool IsLogonDomain = true;
        //public static ADUsers.Forms.ActiveDirectoryLogon activeDirectoryLogon = new Ecm.ADUsers.Forms.ActiveDirectoryLogon();
        public static SystemControl.DBUsers.DatabaseLogon databaseLogon;//= new Ecm.DBUsers.Forms.DatabaseLogon();
        static Form FrmMain;

       /****
        * public static void ShowActiveDirectoryLogon(Form MainForm)
        {
            activeDirectoryLogon = (ADUsers.Forms.ActiveDirectoryLogon)  GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(MainForm, activeDirectoryLogon.Name);
            if (activeDirectoryLogon == null)
                activeDirectoryLogon = new Ecm.ADUsers.Forms.ActiveDirectoryLogon();
            activeDirectoryLogon.LogonDatabase += new EventHandler(activeDirectoryLogon_LogonDatabase);
            activeDirectoryLogon.MdiParent = MainForm;
            activeDirectoryLogon.Show();
            activeDirectoryLogon.Activate();

            FrmMain = MainForm;

            IsLogonDomain = true;
        }*/

        public static void ShowDatabaseLogon(Form MainForm)
        {
            try
            {
                databaseLogon = (SystemControl.DBUsers.DatabaseLogon) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(MainForm, "DatabaseLogon");
                if (databaseLogon == null)
                    databaseLogon = new SystemControl.DBUsers.DatabaseLogon();
                //databaseLogon.LogonDomain += new EventHandler(databaseLogon_LogonDomain);
                databaseLogon.MdiParent = MainForm;
                databaseLogon.Show();
                databaseLogon.Activate();

                FrmMain = MainForm;

                 GoobizFrame.Windows.MdiUtils.MdiChecker.CloseAllChildrenForm(MainForm, databaseLogon);

                // GoobizFrame.Windows.MdiUtils.MdiChecker.LockParentForm(MainForm);
                 GoobizFrame.Windows.MdiUtils.MdiChecker.ClearMenuParentForm(MainForm);

                 GoobizFrame.Windows.MdiUtils.ThemeSettings.SetCurrentUser("");

                IsLogonDomain = false;
            }
            catch (Exception ex)
            {
                 GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "ShowDatabaseLogon");
            }
        }

        /****
         * static void databaseLogon_LogonDomain(object sender, EventArgs e)
        {
            //Form MainForm = databaseLogon.MdiParent;           
            //ShowActiveDirectoryLogon(FrmMain);
            databaseLogon.Close();
        }*/

        static void activeDirectoryLogon_LogonDatabase(object sender, EventArgs e)
        {
            //Form MainForm = activeDirectoryLogon.MdiParent;
            ShowDatabaseLogon(FrmMain);
            //activeDirectoryLogon.Close();
        }
    }

    

}
