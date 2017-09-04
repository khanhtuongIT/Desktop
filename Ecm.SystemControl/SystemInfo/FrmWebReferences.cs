using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ecm.SystemControl.SystemInfo
{
    public partial class FrmWebReferences :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        GoobizFrame.Profile.Config config = GoobizFrame.Windows.Public.HostConfiguration.Instance;
        DataSet dsConfig = new DataSet("WebReferences");

        public FrmWebReferences()
        {
            InitializeComponent();
            DisplayInfo();
            this.EnableAdd = false;
        }

        public override void DisplayInfo()
        {
            dsConfig = new DataSet("WebReferences");
            dsConfig.Tables.Add("WebReferences");
            dsConfig.Tables[0].Columns.Add("GroupName");
            dsConfig.Tables[0].Columns.Add("Section");
            dsConfig.Tables[0].Columns.Add("Entry");
            dsConfig.Tables[0].Columns.Add("Url");

            config.GroupName = "WebReferences";
            string [] SectionNames = config.GetSectionNames();
            foreach (string section in SectionNames)
            {
                string[] EntryNames = config.GetEntryNames(section);
                foreach (string entry in EntryNames)
                {
                    DataRow rConfig = dsConfig.Tables[0].NewRow();
                    rConfig["GroupName"]    = config.GroupName;
                    rConfig["Section"]      = section;
                    rConfig["Entry"]        = entry;
                    rConfig["Url"]          = config.GetValue(section, entry);
                    dsConfig.Tables[0].Rows.Add(rConfig);
                }
            }
            
            dsConfig.AcceptChanges();
            dgWebReferences.DataSource = null;
            dgWebReferences.DataSource = dsConfig;
            dgWebReferences.DataMember = "WebReferences";

            this.Data = dsConfig;
            this.GridControl = dgWebReferences;
        }

        private void btnLoadFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "WebReferences.config|*.config";
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                config = new  GoobizFrame.Profile.Config(OpenFileDialog.FileName);
                DisplayInfo();
                ChangeFormState( GoobizFrame.Windows.Forms.FormState.Edit);
            }

        }

        public override bool PerformSave()
        {
            config = new  GoobizFrame.Profile.Config(Application.StartupPath + @"\Resources\WebReferences.config");
            config.GroupName = "WebReferences";
            foreach (DataRow r in dsConfig.Tables[0].Rows)
                config.SetValue("" + r["Section"], "" + r["Entry"], "" + r["Url"]);
            
            Application.Restart();

            return base.PerformSave();
        }
    }
}