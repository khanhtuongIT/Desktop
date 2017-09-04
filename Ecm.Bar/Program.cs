using System;
using System.Collections.Generic;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Bar
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            RunAsDebug();

        }

        static void RunAsDebug()
        {
            //Hiển thị màn hình giới thiệu (spalsh screen)

            //	process application startup
            DoStartup();

            //	if the form is still shown...
        }

       

        /// <summary>
        /// Hiển thị form chính
        /// hiển thị các trạng thái ban đầu của chương trình trên splash screen
        /// </summary>
        /// <param name="args"></param>
        static void DoStartup()
        {
            //Forms.Version2.Frmbar_Table_Order Frmbar_Table_Order = new Ecm.Bar.Forms.Version2.Frmbar_Table_Order();
            //Application.Run(Frmbar_Table_Order);
        }

   
    }
}