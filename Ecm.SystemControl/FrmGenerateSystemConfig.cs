using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunLine.SystemControl
{
    public partial class FrmGenerateSystemConfig : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        DataSet dsConfig;
        System.Collections.Hashtable Images = new System.Collections.Hashtable();

        public FrmGenerateSystemConfig()
        {
            InitializeComponent();
            this.BarSystem.Visible = false;
            DisplayInfo();
        }

        void DisplayInfo()
        {
            DisplayInfo_LoadStartupForm();
            DisplayInfo_LoadMenuInfo();
            DisplayInfo_LoadPrintpreview();
        }
        #region Startup form
        /// <summary>
        /// Load startup form name
        /// </summary>
        void DisplayInfo_LoadStartupForm()
        {
            radioGroup_StartupForm.EditValue = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetStartupForm();
        }

        void SaveStartup()
        {
            GoobizFrame.Windows.MdiUtils.ThemeSettings.SetStartupForm("" + radioGroup_StartupForm.EditValue);
        }

        #endregion

        #region MenuInfo

        /// <summary>
        /// Load menu item text based on plugins configuration
        /// </summary>
        void DisplayInfo_LoadMenuInfo()
        {
            //dataset Configuration
            dsConfig = new DataSet("Configuration");
            dsConfig.Tables.Add("Configuration");
            dsConfig.Tables[0].Columns.Add("PluginItem");
            dsConfig.Tables[0].Columns.Add("ToolbarSettings");
            dsConfig.Tables[0].Columns.Add("GroupName");
            dsConfig.Tables[0].Columns.Add("Text");
            dsConfig.Tables[0].Columns.Add("Icon");
            dsConfig.Tables[0].Columns.Add("Description");
            dsConfig.Tables[0].Columns.Add("CreateMenuItem", typeof(bool));
            dsConfig.Tables[0].Columns.Add("CreateToolbarItem", typeof(bool));
            dsConfig.Tables[0].Columns.Add("CreateNavigatorItem", typeof(bool));

            string[] config_files = null;
            string profile_folder = Application.StartupPath + @"\Resources\" ;
            if (System.IO.Directory.Exists(profile_folder))
                config_files = System.IO.Directory.GetFiles(profile_folder);

            foreach (string file in config_files)
            {
                string file_in_profile = file;
                GoobizFrame.Profile.Config config = new GoobizFrame.Profile.Config(file_in_profile);
                try
                {
                    config.GroupName = "Settings";
                    string NewToolbarText = "[" + config.GetValue("MenuSettings", "NewMenuName")
                        + "] >>>"
                        + config.GetValue("ToolbarSettings", "NewToolbarText");

                    config.GroupName = "PluginItems";

                    foreach (string section in config.GetSectionNames())
                    {
                        //if (Convert.ToBoolean(config.GetValue(section, "CreateMenuItem"))
                        //    && Convert.ToBoolean(config.GetValue(section, "CreateToolbarItem"))
                        //    //&& Convert.ToBoolean(config.GetValue(section, "CreateNavigatorItem"))
                        //    )
                        //{
                        DataRow rConfig = dsConfig.Tables[0].NewRow();
                        rConfig["GroupName"] = file_in_profile;
                        rConfig["ToolbarSettings"] = NewToolbarText;
                        rConfig["PluginItem"] = section;
                        rConfig["Text"] = config.GetValue(section, "Text");
                        rConfig["Description"] = config.GetValue(section, "Description");
                        rConfig["Icon"] = config.GetValue(section, "Icon");
                        rConfig["CreateMenuItem"] = config.GetValue(section, "CreateMenuItem");
                        rConfig["CreateToolbarItem"] = config.GetValue(section, "CreateToolbarItem");
                        rConfig["CreateNavigatorItem"] = config.GetValue(section, "CreateNavigatorItem");

                        dsConfig.Tables[0].Rows.Add(rConfig);
                        //}
                    }

                }
                catch { continue; }
                dgMenuInfo.DataSource = null;
                dgMenuInfo.DataSource = dsConfig;
                dgMenuInfo.DataMember = "Configuration";
            }
        }

        /// <summary>
        /// Display Icon for each item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "Image" && e.IsGetData)
                {
                    DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;

                    string filename = (string)view.GetRowCellValue(e.RowHandle, "Icon");
                    if (!Images.ContainsKey(filename))
                    {
                        Image img = null;
                        try
                        {
                            img = Image.FromFile(filename);
                        }
                        catch
                        {
                        }
                        Images.Add(filename, img);
                    }
                    e.Value = Images[filename];
                }
            }
            catch { }
        }

        /// <summary>
        /// save menu info
        /// </summary>
        void UpdateMenuInfo()
        {
            //update config entries
            foreach (DataRow rConfig in dsConfig.Tables[0].Rows)
            {
                try
                {
                    GoobizFrame.Profile.Config config = new GoobizFrame.Profile.Config("" + rConfig["GroupName"]);
                    config.GroupName = "PluginItems";
                    config.SetValue("" + rConfig["PluginItem"], "Text", "" + rConfig["Text"]);
                    config.SetValue("" + rConfig["PluginItem"], "Description", "" + rConfig["Description"]);
                    config.SetValue("" + rConfig["PluginItem"], "CreateMenuItem", "" + rConfig["CreateMenuItem"]);
                    config.SetValue("" + rConfig["PluginItem"], "CreateToolbarItem", "" + rConfig["CreateToolbarItem"]);
                    config.SetValue("" + rConfig["PluginItem"], "CreateNavigatorItem", "" + rConfig["CreateNavigatorItem"]);
                }
                catch (Exception ex)
                {
#if DEBUG
                    MessageBox.Show(ex.ToString());
#endif
                    continue;
                }
            }
        }
        #endregion

        #region Printpreview
        void DisplayInfo_LoadPrintpreview()
        {
            chk_rptBaogia_Khachhang.Checked = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetPrintpreview("rptBaogia_Khachhang");
            chk_rptBarcode.Checked = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetPrintpreview("rptBarcode");
            chk_rptHdbanhang_noVAT.Checked = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetPrintpreview("rptHdbanhang_noVAT");
            chk_rptHdbanhang_VAT.Checked = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetPrintpreview("rptHdbanhang_VAT");
            chk_rptPhieu_Chi.Checked = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetPrintpreview("rptPhieu_Chi");
            chk_rptPhieu_Thu.Checked = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetPrintpreview("rptPhieu_Thu");
        }

        void UpdatePrintpreview()
        {
            GoobizFrame.Windows.MdiUtils.ThemeSettings.SetPrintpreview("rptBaogia_Khachhang",chk_rptBaogia_Khachhang.Checked);
            GoobizFrame.Windows.MdiUtils.ThemeSettings.SetPrintpreview("rptBarcode", chk_rptBarcode.Checked);
            GoobizFrame.Windows.MdiUtils.ThemeSettings.SetPrintpreview("rptHdbanhang_noVAT", chk_rptHdbanhang_noVAT.Checked);
            GoobizFrame.Windows.MdiUtils.ThemeSettings.SetPrintpreview("rptHdbanhang_VAT", chk_rptHdbanhang_VAT.Checked);
            GoobizFrame.Windows.MdiUtils.ThemeSettings.SetPrintpreview("rptPhieu_Chi", chk_rptPhieu_Chi.Checked);
            GoobizFrame.Windows.MdiUtils.ThemeSettings.SetPrintpreview("rptPhieu_Thu", chk_rptPhieu_Thu.Checked);
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveStartup();
            UpdateMenuInfo();
            UpdatePrintpreview();
            DisplayInfo();
        }

        private void FrmGenerateSystemConfig_Load(object sender, EventArgs e)
        {

        }

        private void xtraTabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPage_MenuInfo)
                DisplayInfo_LoadMenuInfo();
        }

        private void btnLoadPLUG_Click(object sender, EventArgs e)
        {
            GoobizFrame.Windows.Forms.FrmPreloadPLUG objFrmPreloadPLUG = new GoobizFrame.Windows.Forms.FrmPreloadPLUG();
            GoobizFrame.Windows.PlugIn.RightHelpers.CheckUserRightAction(objFrmPreloadPLUG);
            objFrmPreloadPLUG.ShowDialog();
        }

        private void btnFrmSys_Dm_Heso_Chuongtrinh_Click(object sender, EventArgs e)
        {
            SunLine.SystemControl.SystemInfo.FrmSys_Dm_Heso_Chuongtrinh frmSys_Dm_Heso_Chuongtrinh = new SunLine.SystemControl.SystemInfo.FrmSys_Dm_Heso_Chuongtrinh();
            GoobizFrame.Windows.PlugIn.RightHelpers.CheckUserRightAction(frmSys_Dm_Heso_Chuongtrinh);

            frmSys_Dm_Heso_Chuongtrinh.ShowDialog();
        }

        private void FrmGenerateSystemConfig_Activated(object sender, EventArgs e)
        {
            btnSave.Enabled = ! this.Denied;
            if ("" + GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUserId() == "")
            {
                //btnLoadPLUG.Enabled = false;
                btnFrmSys_Dm_Heso_Chuongtrinh.Enabled = false;
            }
        }
    }
}