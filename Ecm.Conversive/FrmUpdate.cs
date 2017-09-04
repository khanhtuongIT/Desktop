using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Net;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Collections;

namespace SunLine.Conversive
{
    public partial class FrmUpdate : DevExpress.XtraEditors.XtraForm
    {
        GoobizFrame.Profile.Config config = new GoobizFrame.Profile.Config(@"Resources\HostConfiguration.config");
        SunLine.Conversive.AutoUpdateConfig AutoUpdateConfig = new SunLine.Conversive.AutoUpdateConfig();
        static internal ArrayList myProcessArray = new ArrayList();
        private static Process myProcess; 

        public FrmUpdate()
        {
            InitializeComponent();
            this.Opacity = 0;
            this.ShowInTaskbar = false;
            //notifyIcon1 icon
            config.GroupName = "HostConfiguration";
            Icon ico = new Icon("" + config.GetValue("Theme", "ProductIcon"));
            notifyIcon1.Icon = ico;
        }

        private void FrmUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Opacity = 0;
            this.ShowInTaskbar = false;
            e.Cancel = true;
        }

        private void FrmUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                config.GroupName = "HostConfiguration";
                this.LookAndFeel.SetSkinStyle("" + config.GetValue("Theme", "ActiveSkinName"));
            }
            catch { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "item_LiveUpdate":
                    this.Opacity = 100;
                    this.ShowInTaskbar = true;
                    this.StartPosition = FormStartPosition.CenterScreen;
                    break;
                case "item_About":
                    FrmAboutme frmAbout = new FrmAboutme();
                    frmAbout.Show();
                    break;
                case "item_StopNotify":
                    if (timer1.Enabled)
                    {
                        timer1.Enabled = false;
                        item_StopNotify.Text = "Start Notify";
                    }
                    else
                    {
                        timer1.Enabled = true;
                        item_StopNotify.Text = "Stop Notify";
                    }
                    break;
                case "item_Exit":
                    Application.Exit();
                    break;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            config.GroupName = "HostConfiguration";
            string AutoUpdateConfigURL = "" + config.GetValue("AutoUpdate", "AutoUpdateConfigURL");
            
            AutoUpdateConfig.LoadConfig(AutoUpdateConfigURL, "", "");
            string updatePath = Application.StartupPath ;
            System.Reflection.Assembly ExecuteAss = System.Reflection.Assembly.LoadFile(updatePath + @"\SunLine.Client.exe");
            
            Version vCurrent = ExecuteAss.GetName().Version;                
            Version vConfig = new Version(AutoUpdateConfig.AvailableVersion);
                if (vConfig > vCurrent)
                {
                    notifyIcon1.BalloonTipText = "Version " + vConfig.ToString() + " At " + AutoUpdateConfig.AppFileURL;
                    notifyIcon1.BalloonTipTitle = "New SunLine availabe for update: ";
                    notifyIcon1.ShowBalloonTip(10000);

                    this.txtURL.Text = AutoUpdateConfig.AppFileURL;
                    this.txtCversion.Text = vCurrent.ToString();
                    this.txtVersion.Text = vConfig.ToString();
                }

                ExecuteAss = null;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            try
            {
                string AutoUpdateConfigURL = "" + config.GetValue("AutoUpdate", "AutoUpdateConfigURL");
                string updatePath = Application.StartupPath;

                AutoUpdateConfig.LoadConfig(AutoUpdateConfigURL, "", "");

                //create web request/response
                string url = AutoUpdateConfig.AppFileURL;
                string path = System.Environment.ExpandEnvironmentVariables("%TEMP%") + "\\" + url.Substring(url.LastIndexOf("/") + 1);
                string extract_dir = url.Substring(url.LastIndexOf("/") + 1);
                extract_dir = extract_dir.Substring(0, extract_dir.LastIndexOf(".zip"));

                HttpWebResponse Response;
                HttpWebRequest Request;


                Request = (HttpWebRequest)HttpWebRequest.Create(url);
                Request.Headers.Add("Translate: f");
                Request.Credentials = CredentialCache.DefaultCredentials;

                Response = (HttpWebResponse)Request.GetResponse();

                Stream respStream = null;
                respStream = Response.GetResponseStream();

                //Do the Download
                byte[] buffer = new byte[4096];
                int length;

                FileStream fs = File.Open(path, FileMode.Create, FileAccess.ReadWrite);

                length = respStream.Read(buffer, 0, 4096);
                while (length > 0)
                {
                    fs.Write(buffer, 0, length);
                    length = respStream.Read(buffer, 0, 4096);
                }
                fs.Close();

                //updatePath = System.IO.Directory.GetParent(updatePath).ToString();
                ICSharpCode.SharpZipLib.Zip.FastZip FastZip = new ICSharpCode.SharpZipLib.Zip.FastZip();
                FastZip.ExtractZip(path, updatePath , null);

                CopyDirectory(extract_dir , updatePath);
                System.IO.Directory.Delete(extract_dir, true);

                MessageBox.Show("Live Update finish!", "Live Update");
                timer1.Enabled = true;
                this.Opacity = 0;
                this.ShowInTaskbar = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                timer1.Enabled = true;
            }
        }

        public static void CopyDirectory(string Src,string Dst)
        {
            String[] Files;

            if(Dst[Dst.Length-1]!=Path.DirectorySeparatorChar) 
                Dst+=Path.DirectorySeparatorChar;
            if(!Directory.Exists(Dst)) 
                Directory.CreateDirectory(Dst);
            Files=Directory.GetFileSystemEntries(Src);
            foreach(string Element in Files)
            {
                // Sub directories
                try
                {
                    if (Directory.Exists(Element))
                        CopyDirectory(Element, Dst + Path.GetFileName(Element));
                    // Files in directory

                    else
                    {
                        File.Copy(Element, Dst + Path.GetFileName(Element), true);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    continue; 
                }
            }

        }
        
    }
}