using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using itvs.Windows.PlugIn;
using System.Reflection;

namespace SunLine.Admspec.Forms
{
    public partial class FrmControlPanel : DevExpress.XtraEditors.XtraForm
    {
        itvs.Profile.Config config_panes = new  itvs.Profile.Config(@"Resources\ControlPanelPlugins.config");
        System.Collections.Hashtable htTabIndex = new System.Collections.Hashtable();
        IPlugin[] ipi;

        public FrmControlPanel()
        {
            InitializeComponent();

            LoadTabPanes();

            LoadItems();
        }

        /// <summary>
        /// Load Tab pages
        /// </summary>
        void LoadTabPanes()
        {
            config_panes.GroupName = "TabPanes";
            string[] sections = config_panes.GetSectionNames();
            int index = 0;
            foreach (string section in sections)
            {
                DevExpress.XtraTab.XtraTabPage objXtraTabPage = new DevExpress.XtraTab.XtraTabPage();
                objXtraTabPage.Name = section;
                objXtraTabPage.Text = ""+config_panes.GetValue(section, "Caption");
                try {
                    objXtraTabPage.Image = Image.FromFile(""+config_panes.GetValue(section, "Image"));
                }
                catch {}
                System.Windows.Forms.FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                flowLayoutPanel.Name = "flow_" + section;
                flowLayoutPanel.Dock = DockStyle.Fill;
                flowLayoutPanel.AutoScroll = true;
                objXtraTabPage.Controls.Add(flowLayoutPanel);

                xtraTabPanes.TabPages.Add(objXtraTabPage);
                htTabIndex.Add(section, index++);
            }
        }


        void LoadItems()
        {
             itvs.Profile.Config obj_Config = new  itvs.Profile.Config(@"Resources\Plugins.config");
            obj_Config.GroupName = "Plugins";
            //find all plugin name in appconfig
            string[] pluginNames = obj_Config.GetSectionNames();
            ipi = new IPlugin[pluginNames.Length];

            for (int i = 0; i < pluginNames.Length; i++)
            {
                //get file assembly from each entry in app config
                string pluginFile = "" + obj_Config.GetValue(pluginNames[i], "Assembly");
                //namespace
                string args = pluginFile.Substring(
                    pluginFile.LastIndexOf("\\") + 1,
                    pluginFile.IndexOf(".dll") -
                    pluginFile.LastIndexOf("\\") - 1);

                Type ObjType = null;
                //IPlugin ipi;
                // load the dll
                // load it
                Assembly ass = null;
                try
                {

                    ass = Assembly.Load(args);
                    if (ass != null)
                    {
                        ObjType = ass.GetType("" + obj_Config.GetValue(pluginNames[i], "PluginType"));
                    }
                    else
                        MessageBox.Show("CannotFindAssembly: " + ass.FullName);
                }
                catch (Exception ex)
                {
                     itvs.Windows.Forms.MessageDialog.Show(ex.Message + ex.Message + ex.Message, ex.ToString(), "LoadPlugin" );
                    //ExceptionLogger.LogException1(ex);
                    continue;
                }

                try
                {
                    // OK Lets create the object as we have the Report Type
                    if (ObjType != null)
                    {
                        if (!Convert.ToBoolean(obj_Config.GetValue(pluginNames[i], "LoadModule")))
                            continue;

                        ipi[i] = (IPlugin)Activator.CreateInstance(ObjType);
                        //assign plugin name
                        ipi[i].Name = pluginNames[i];
                        //PluginItemConfig path
                        ipi[i].PluginItemConfig = "" + obj_Config.GetValue(pluginNames[i], "PluginItemConfig");

                        ipi[i].SetMdiParent(this.MdiParent);
                         itvs.Profile.Config obj_ItemConfig = new  itvs.Profile.Config(ipi[i].PluginItemConfig);
                        obj_ItemConfig.GroupName = "PluginItems";
                        string[] sections = obj_ItemConfig.GetSectionNames();
                        if (sections != null && sections.Length > 0)
                        {
                            foreach (string section in sections)
                            {
                                try
                                {
                                    string tabpane = "" + obj_ItemConfig.GetValue(section, "TabPane");
                                    string text = "" + obj_ItemConfig.GetValue(section, "Text");
                                    string description = "" + obj_ItemConfig.GetValue(section, "Description");
                                    string type = "" + obj_ItemConfig.GetValue(section, "Type");
                                    string iconPath = "" + obj_ItemConfig.GetValue(section, "Icon");

                                    DevExpress.XtraEditors.LabelControl labelControl = new LabelControl();

                                    labelControl.Appearance.Image = Image.FromFile(iconPath);
                                    labelControl.Appearance.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
                                    labelControl.Appearance.Options.UseImage = true;
                                    labelControl.Appearance.Options.UseTextOptions = true;
                                    labelControl.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
                                    labelControl.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
                                    labelControl.Name = section;
                                    labelControl.Size = new System.Drawing.Size(63, 61);
                                    labelControl.Text = text;
                                    labelControl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                                    labelControl.AutoSizeMode = LabelAutoSizeMode.Vertical;
                                    labelControl.Cursor = Cursors.Hand;

                                    labelControl.Click += new EventHandler(ipi[i].BarManager_ItemClick);

                                    int tabindex = Convert.ToInt32(""+ htTabIndex[tabpane] );
                                    System.Windows.Forms.FlowLayoutPanel flowLayoutPanel = (System.Windows.Forms.FlowLayoutPanel)xtraTabPanes.TabPages[tabindex].Controls["flow_" + tabpane];
                                    flowLayoutPanel.Controls.Add(labelControl);

                                }
                                catch(Exception ex)
                                {
                                    //MessageBox.Show(ex.Message);
                                    continue;
                                }

                            }
                        }
                    }
                    else
                        MessageBox.Show("CannotFindPlugin" 
                            + obj_Config.GetValue(pluginNames[i], "PluginType") + " / " + ass.FullName);
                }
                catch (Exception ex)
                {
                     itvs.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "LoadPlugin" );
                    //ExceptionLogger.LogException1(ex);
                    continue;
                }

            }
        }

        private void FrmControlPanel_Activated(object sender, EventArgs e)
        {
            for (int i = 0; i < ipi.Length; i++)
            {
                try
                {
                    ipi[i].SetMdiParent(this.MdiParent);
                }
                catch { continue; }
            }
        }
    }
}