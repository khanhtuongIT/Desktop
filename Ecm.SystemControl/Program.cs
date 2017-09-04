using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ecm.SystemControl
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

             GoobizFrame.Windows.Forms.FrmHostConfiguration oFrmHostConfiguration = new  GoobizFrame.Windows.Forms.FrmHostConfiguration();
            
            //UCSetMachineLocation
            Ecm.SystemControl.SystemInfo.UCSetMachineLocation ucSetMachineLocation1 = new Ecm.SystemControl.SystemInfo.UCSetMachineLocation();
            ucSetMachineLocation1.Location = new System.Drawing.Point(33, 21);
            ucSetMachineLocation1.Name = "ucSetMachineLocation1";
            ucSetMachineLocation1.Size = new System.Drawing.Size(245, 223);
            oFrmHostConfiguration.AddControl(ucSetMachineLocation1, "Tùy chọn vị trí máy");

            //UCWebReferences
             GoobizFrame.Windows.Forms.UCWebReferences ucWebReferences = new  GoobizFrame.Windows.Forms.UCWebReferences();
            ucWebReferences.Location = new System.Drawing.Point(33, 21);
            ucWebReferences.Name = "ucSetMachineLocation1";
            ucWebReferences.Size = new System.Drawing.Size(245, 223);
            oFrmHostConfiguration.AddControl(ucWebReferences, "Tùy chọn webservices");

            Application.Run(oFrmHostConfiguration);


        }
    }
}