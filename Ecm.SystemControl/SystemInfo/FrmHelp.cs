using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SunLine.SystemControl.SystemInfo
{
    public partial class FrmHelp : Form
    {
        public FrmHelp()
        {
            InitializeComponent();

            string path = System.Environment.CurrentDirectory;
            path += @"\" + GoobizFrame.Windows.CultureInfo.CultureInfoHelper.CurrentCultureInfoPath + @"\Helpme.swf";
            axShockwaveFlash1.Movie = path;
            axShockwaveFlash1.Play();

            webBrowser1.Navigate("Goobiz.html");
        }
    }
}