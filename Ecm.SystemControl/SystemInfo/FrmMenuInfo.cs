using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;

namespace Ecm.SystemControl.SystemInfo
{
    public partial class FrmMenuInfo :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        DataSet dsConfig = new DataSet("WebReferences");
        System.Collections.Hashtable Images = new System.Collections.Hashtable();
        DataSet dsPol_Dm_User;
        Ecm.WebReferences.Classes.PolicyService objPolicyService = new Ecm.WebReferences.Classes.PolicyService();
        public FrmMenuInfo()
        {
            InitializeComponent();
            DisplayInfo();

            lookUpEdit_Dm_User.ProcessNewValue +=new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler( GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);

        }

        public override void DisplayInfo()
        {
            //lookUpEdit_Dm_User
            dsPol_Dm_User = objPolicyService.Get_Pol_Dm_User_Collection3().ToDataSet();
            lookUpEdit_Dm_User.Properties.DataSource = dsPol_Dm_User.Tables[0];

            DisplayInfo2();
        }

        void DisplayInfo2()
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
            string profile_folder = Application.StartupPath + @"\Resources\" + lookUpEdit_Dm_User.EditValue + @"\";
            if (System.IO.Directory.Exists(profile_folder))
                config_files = System.IO.Directory.GetFiles(profile_folder);
            
            if (config_files == null || config_files.Length < 2)
            {
                //copy from default
                System.IO.Directory.CreateDirectory(profile_folder);
                string[] file_in_resources = System.IO.Directory.GetFiles(Application.StartupPath + @"\Resources\");
                foreach (string filename in file_in_resources)
                {
                    System.IO.FileInfo fileInfo = new System.IO.FileInfo(filename);
                    if (filename.LastIndexOf("Plugins.config") == -1)
                        fileInfo.CopyTo(profile_folder + fileInfo.Name, true);
                    else if (!System.IO.File.Exists(profile_folder + "Plugins.config"))
                    {
                        fileInfo.CopyTo(profile_folder + fileInfo.Name, true);

                        ////change Plugins.config
                         GoobizFrame.Profile.Config configPlugins = new  GoobizFrame.Profile.Config(profile_folder + "Plugins.config");
                        configPlugins.GroupName = "Plugins";
                        foreach (string section in configPlugins.GetSectionNames())
                        {
                            string PluginItemConfig = "" + configPlugins.GetValue(section, "PluginItemConfig");
                            PluginItemConfig = PluginItemConfig.Replace(@"Resources\", @"Resources\" + lookUpEdit_Dm_User.EditValue + @"\");
                            configPlugins.SetValue(section, "PluginItemConfig", PluginItemConfig);
                        }
                    }
                }

                

                //get list of config
                config_files = System.IO.Directory.GetFiles(profile_folder);
            }

            foreach (string file in config_files)
            {
                string file_in_profile = file;
                 GoobizFrame.Profile.Config config = new  GoobizFrame.Profile.Config(file_in_profile);
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
        void UpdateMenuInfo()
        {
            //update config entries
            foreach (DataRow rConfig in dsConfig.Tables[0].Rows)
            {
                try
                {
                     GoobizFrame.Profile.Config config = new  GoobizFrame.Profile.Config(""+rConfig["GroupName"]);
                    config.GroupName = "PluginItems";
                    config.SetValue("" + rConfig["PluginItem"], "Text", "" + rConfig["Text"]);
                    config.SetValue("" + rConfig["PluginItem"], "Description", "" + rConfig["Description"]);
                    config.SetValue("" + rConfig["PluginItem"], "CreateMenuItem", "" + rConfig["CreateMenuItem"]);
                    config.SetValue("" + rConfig["PluginItem"], "CreateToolbarItem", "" + rConfig["CreateToolbarItem"]);
                    config.SetValue("" + rConfig["PluginItem"], "CreateNavigatorItem", "" + rConfig["CreateNavigatorItem"]);
                }
                catch (Exception ex)
                {
                     GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), this.GetType().Name);
                    continue;
                }
            }

            //upload to profile
            string profile_folder = Application.StartupPath + @"\Resources\" + lookUpEdit_Dm_User.EditValue + @"\";
            string [] config_files = System.IO.Directory.GetFiles(profile_folder);
            foreach (string fileName in config_files)
                UploadFile(fileName, ""+lookUpEdit_Dm_User.EditValue);
        }
        #region override
        public override bool PerformSave()
        {
            UpdateMenuInfo();
            return base.PerformSave();
        }

        public override bool PerformSaveChanges()
        {
            UpdateMenuInfo();
            return base.PerformSaveChanges();
        }

        public override bool PerformDelete()
        {
            if ("" + lookUpEdit_Dm_User.EditValue != ""
                &&  GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[] { "profile " + lookUpEdit_Dm_User.EditValue }) == DialogResult.Yes)
            {
                string profile_folder = Application.StartupPath + @"\Resources\" + lookUpEdit_Dm_User.EditValue + @"\";
                
                if (System.IO.Directory.Exists(profile_folder))
                    System.IO.Directory.Delete(profile_folder, true);

                DisplayInfo2();
            }
                return base.PerformDelete();
        }
        #endregion

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

        private void lookUpEdit_Dm_User_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.Utils.WaitDialogForm WaitDialogForm = new DevExpress.Utils.WaitDialogForm();
            DisplayInfo2();
            WaitDialogForm.Close();
        }

        private void UploadFile(string filename, string profile)
        {
            try
            {
                // get the exact file name from the path
                String strFile = System.IO.Path.GetFileName(filename);
                // create an instance fo the web service
                Ecm.WebReferences.Classes.SystemService objSystemService = new Ecm.WebReferences.Classes.SystemService();
                // get the file information form the selected file
                FileInfo fInfo = new FileInfo(filename);
                // get the length of the file to see if it is possible
                // to upload it (with the standard 4 MB limit)
                long numBytes = fInfo.Length;
                double dLen = Convert.ToDouble(fInfo.Length / 1000000);
                // Default limit of 4 MB on web server
                // have to change the web.config to if
                // you want to allow larger uploads
                if (dLen < 4)
                {
                    // set up a file stream and binary reader for the
                    // selected file
                    FileStream fStream = new FileStream(filename,
                    FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fStream);
                    // convert the file to a byte array
                    byte[] data = br.ReadBytes((int)numBytes);
                    br.Close();
                    // pass the byte array (file) and file name to the web service
                    string sTmp = objSystemService.UploadFile(data, strFile, profile);
                    fStream.Close();
                    fStream.Dispose();
                    // this will always say OK unless an error occurs,
                    // if an error occurs, the service returns the error message
                    //MessageBox.Show("File Upload Status: " + sTmp, "File Upload");
                }
                else
                {
                    // Display message if the file was too large to upload
                    MessageBox.Show("The file selected exceeds the size limit for uploads.", "File Size");
                }
            }
            catch (Exception ex)
            {
                // display an error message to the user
                 GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), this.GetType().Name);
            }
        }

        private void btnSyn_Click(object sender, EventArgs e)
        {
            if ("" + lookUpEdit_Dm_User.EditValue != "")
                SynchronizeProfile(""+lookUpEdit_Dm_User.EditValue);
        }

        /// <summary>
        /// Đồng bộ config giữa hệ thống và profile của twnfd user
        /// </summary>
        /// <param name="profile">tên profile</param>
        private void SynchronizeProfile(string profile)
        {
             GoobizFrame.Profile.Config system_Config = new  GoobizFrame.Profile.Config(@"Resources\Plugins.config" );
            system_Config.GroupName = "Plugins";
             GoobizFrame.Profile.Config profile_Config = new  GoobizFrame.Profile.Config(@"Resources\"+ profile +@"\Plugins.config" );
            profile_Config.GroupName = "Plugins";

            //for each plugin
            foreach(string section in system_Config.GetSectionNames())
            {
                //update Plugins.config
                if (!profile_Config.HasSection(section))
                {
                    foreach (string entry in system_Config.GetEntryNames(section))
                        profile_Config.SetValue(section, entry, system_Config.GetValue(section, entry));
                   
                    //change path of plugin item
                    profile_Config.SetValue(section, "PluginItemConfig"
                        , profile_Config.GetValue(section, "PluginItemConfig").ToString().Replace("Resources", @"Resources\" + profile)
                        );
                   
                    //copy PluginItemConfig
                    System.IO.File.Copy(""+system_Config.GetValue(section, "PluginItemConfig")
                        , "" + profile_Config.GetValue(section, "PluginItemConfig"));
                }
                else
                {
                    //update PluginItemConfig
                     GoobizFrame.Profile.Config system_PluginItemConfig  =    new  GoobizFrame.Profile.Config( ""+system_Config.GetValue(section, "PluginItemConfig") );
                     GoobizFrame.Profile.Config profile_PluginItemConfig =    new  GoobizFrame.Profile.Config ( ""+profile_Config.GetValue(section, "PluginItemConfig") );
                    system_PluginItemConfig.GroupName = "PluginItems";
                    profile_PluginItemConfig.GroupName = "PluginItems";
                    foreach (string item_section in system_PluginItemConfig.GetSectionNames())
                    {
                        try
                        {
                            //old section
                            if (profile_PluginItemConfig.HasSection(item_section))
                            {
                                profile_PluginItemConfig.SetValue(item_section, "Text", system_PluginItemConfig.GetValue(item_section, "Text"));
                                profile_PluginItemConfig.SetValue(item_section, "Type", system_PluginItemConfig.GetValue(item_section, "Type"));
                                profile_PluginItemConfig.SetValue(item_section, "Description", system_PluginItemConfig.GetValue(item_section, "Description"));
                                profile_PluginItemConfig.SetValue(item_section, "Icon", system_PluginItemConfig.GetValue(item_section, "Icon"));
                            }
                            else
                            {
                                //new section
                                foreach (string item_entry in system_PluginItemConfig.GetEntryNames(item_section))
                                    profile_PluginItemConfig.SetValue(item_section, item_entry
                                        , system_PluginItemConfig.GetValue(item_section, item_entry));
                            }
                        }
                        catch (Exception ex)
                        {
                             GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), this.GetType().Name);
                        }
                    }
                }
            }

            //upload to profile
            string profile_folder = Application.StartupPath + @"\Resources\" + profile + @"\";
            string[] config_files = System.IO.Directory.GetFiles(profile_folder);
            foreach (string fileName in config_files)
                UploadFile(fileName, "" + lookUpEdit_Dm_User.EditValue);

            DisplayInfo2();
        }

    }
}