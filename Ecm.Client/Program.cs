using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Reflection;
using  GoobizFrame.Windows;
 

namespace Ecm.Client
{
    static class Program
    {
        //static itvsbiz.SystemControl.Policy.Auth.RightHelpers RightHelpers = new itvsbiz.SystemControl.Policy.Auth.RightHelpers();
        //static itvsbiz.SystemControl.Policy.Auth.Authorization objAuthorization = new itvsbiz.SystemControl.Policy.Auth.Authorization();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            RunAsDebug(args);

        }

        /// <summary>
        /// Hiển thị form chính
        /// hiển thị các trạng thái ban đầu của chương trình trên splash screen
        /// </summary>
        /// <param name="args"></param>
        static void DoStartup(string[] args)
        {
            try
            {
                GoobizFrame.Windows.MdiUtils.Register.IsPrivateBuiltApp = true;
                GoobizFrame.Windows.Forms.FrmMainUseRibbon frmMainUseRibbon = new GoobizFrame.Windows.Forms.FrmMainUseRibbon();
                GoobizFrame.Windows.MdiUtils.MdiChecker.ShowDatabaseLogon(frmMainUseRibbon);

                //itvs.Li  veUpdate.FrmUpdate frmUpdate = new itvs.LiveUpdate.FrmUpdate();
                Application.Run(frmMainUseRibbon);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        static void RunAsDebug(string[] args)
        {
            GoobizFrame.Windows.Splasher.Splasher.Show();
            GoobizFrame.Windows.TrayMessage.TrayMessage.Show();
            //	process application startup
            DoStartup(args);

            //	if the form is still shown...
            GoobizFrame.Windows.Splasher.Splasher.Close();
        }



    }
}