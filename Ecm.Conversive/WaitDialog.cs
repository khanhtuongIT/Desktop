using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunLine.Conversive
{
    public partial class WaitDialog : Form
    {
        GoobizFrame.Profile.Config config = new GoobizFrame.Profile.Config(@"Resources\HostConfiguration.config");

        public WaitDialog()
        {
            InitializeComponent();
            AutoUpdate();
        }

        #region Auto Update
        private void AutoUpdate()
        {
            try
            {
                autoUpdater = new SunLine.Conversive.AutoUpdater();
                config.GroupName = "HostConfiguration";
                autoUpdater.ConfigURL = "" + config.GetValue("AutoUpdate", "AutoUpdateConfigURL");
                autoUpdater.RestartForm = new Conversive.Confirm();
                autoUpdater.TryUpdate();
            }
            catch (Exception ex)
            {
                //GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.StackTrace, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}