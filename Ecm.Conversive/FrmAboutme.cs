using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunLine.Conversive
{
    public partial class FrmAboutme : Form
    {
        public FrmAboutme()
        {
            InitializeComponent();
        }

        private void FrmAboutme_Load(object sender, EventArgs e)
        {
          
            GoobizFrame.Profile.Config config = new GoobizFrame.Profile.Config(@"Resources\HostConfiguration.config");
            config.GroupName = "HostConfiguration";
            panelControl1.ContentImage =  Image.FromFile("" + config.GetValue("Theme", "SplashBitmap"));
            this.Text = "" + config.GetValue("Theme", "ProductTitle");
        }
    }
}