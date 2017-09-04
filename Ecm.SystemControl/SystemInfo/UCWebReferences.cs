using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SunLine.SystemControl.SystemInfo
{
    public partial class UCWebReferences : UserControl
    {
        GoobizFrame.Profile.Config config = new GoobizFrame.Profile.Config(@"Resources\HostConfiguration.config");
        DataSet dsConfig = new DataSet("WebReferences");

        public UCWebReferences()
        {
            InitializeComponent();

            DisplayInfo();
        }

        void ChangeStatus(bool editable)
        {
            gridView1.OptionsBehavior.Editable = editable;

            btn_cWebReferences.Enabled = editable;
            btn_sWebReferences.Enabled = editable;
            btn_eWebReferences.Enabled = !editable;
        }

        public void DisplayInfo()
        {
            dsConfig = new DataSet("WebReferences");
            dsConfig.Tables.Add("WebReferences");
            dsConfig.Tables[0].Columns.Add("GroupName");
            dsConfig.Tables[0].Columns.Add("Section");
            dsConfig.Tables[0].Columns.Add("Key");
            dsConfig.Tables[0].Columns.Add("Value");
            dsConfig.Tables[0].Columns.Add("Status");

            config.GroupName = "WebReferences";
            string[] SectionNames = config.GetSectionNames();
            foreach (string section in SectionNames)
            {
                string[] EntryNames = config.GetEntryNames(section);
                foreach (string entry in EntryNames)
                {
                    DataRow rConfig = dsConfig.Tables[0].NewRow();
                    rConfig["GroupName"] = config.GroupName;
                    rConfig["Section"] = section;
                    rConfig["Key"] = entry;
                    rConfig["Value"] = config.GetValue(section, entry);

                    if (section == "Webservices")
                        rConfig["Status"] =
                            (GoobizFrame.Windows.Public.WsProxy.CheckWebService("" + rConfig["Value"]))
                            ? "Tồn tại" : "Không tìm thấy";

                    dsConfig.Tables[0].Rows.Add(rConfig);
                }
            }

            dsConfig.AcceptChanges();
            dgWebReferences.DataSource = null;
            dgWebReferences.DataSource = dsConfig;
            dgWebReferences.DataMember = "WebReferences";


            ChangeStatus(false);
        }

        private void btn_eWebReferences_Click(object sender, EventArgs e)
        {
            ChangeStatus(true);
        }

        private void btn_cWebReferences_Click(object sender, EventArgs e)
        {
            DisplayInfo();
        }

        private void btn_sWebReferences_Click(object sender, EventArgs e)
        {
            foreach (DataRow r in dsConfig.Tables[0].Rows)
                config.SetValue("" + r["Section"], "" + r["Key"], "" + r["Value"]);

            DisplayInfo();
        }
    }
}
