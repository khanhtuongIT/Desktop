using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ecm.SystemControl.SystemInfo
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();

            //SplashBitmap
            GoobizFrame.Profile.Config config = GoobizFrame.Windows.Public.HostConfiguration.Instance;
            config.GroupName = "HostConfiguration";
            this.pictureEdit1.Image = Image.FromFile("" + config.GetValue("Theme", "SplashBitmap"));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        
    }
}