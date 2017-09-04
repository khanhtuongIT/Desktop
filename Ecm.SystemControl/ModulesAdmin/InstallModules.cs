using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;

namespace Ecm.SystemControl.ModulesAdmin
{
    public partial class InstallModules : DevExpress.XtraEditors.XtraForm,  GoobizFrame.Windows.Forms.IFormUserActions
    {
        System.Data.DataSet dsPlugins = new DataSet();

         GoobizFrame.Profile.Config hostConfiguration;
         GoobizFrame.Profile.Config pluginConfigs;
        string pluginConfigFile;
        ModuleProperies moduleProperies;
        Ecm.WebReferences.Classes.PolicyService objPolicyService;// = new Ecm.WebReferences.Classes.PolicyService();
        DataSet dsPol_Dm_User;

        #region user rights
        private bool enableAdd = true;
        private bool enableEdit = true;
        private bool enableDelete = false;
        private bool enableQuery = true;
        private bool enablePrintPreview = true;
        private bool enableTest = false;
        private bool enableVerify = false;

        private bool denied = false;
        private  GoobizFrame.Windows.PlugIn.Authorization.Actions _UserActions;


        /// <summary>
        /// cho phép thêm mới
        /// </summary>
        [Category("InstallModules")]
        public bool EnableAdd
        {
            get { return enableAdd; }
            set
            {
                enableAdd = value;
                item_InstallPlugin.Enabled = enableAdd;
                dgPlugins.EmbeddedNavigator.Buttons.Append.Enabled = enableAdd;
            }
        }
        /// <summary>
        /// cho phép cập nhật
        /// </summary>
        [Category("InstallModules")]
        public bool EnableEdit
        {
            get { return enableEdit; }
            set
            {
                enableEdit = value;
                item_Config.Enabled = enableEdit;
                dgPlugins.EmbeddedNavigator.Buttons.Edit.Enabled = enableEdit;
                gridView1.OptionsBehavior.Editable = enableEdit;
            }
        }
        /// <summary>
        /// cho phép xóa
        /// </summary>
        [Category("InstallModules")]
        public bool EnableDelete
        {
            get { return enableDelete; }
            set
            {
                enableDelete = value;
                item_RemovePlugin.Enabled = enableDelete;
                dgPlugins.EmbeddedNavigator.Buttons.Remove.Enabled = enableDelete;

            }
        }
        /// <summary>
        /// cho phép lập báo cáo
        /// </summary>
        [Category("InstallModules")]
        public bool EnableQuery
        {
            get { return enableQuery; }
            set
            {
                enableQuery = value;
            }
        }
        /// <summary>
        /// cho phép in
        /// </summary>
        [Category("InstallModules")]
        public bool EnablePrintPreview
        {
            get { return enablePrintPreview; }
            set
            {
                enablePrintPreview = value;
            }
        }

        /// <summary>
        /// cho phép kiểm tra chứng từ
        /// </summary>
        [Category("InstallModules")]
        public bool EnableTest
        {
            get { return enableTest; }
            set
            {
                enableTest = value;
                //item_Test.Enabled = enableTest;
            }
        }

        /// <summary>
        /// cho phép xác nhận chứng từ
        /// </summary>
        [Category("InstallModules")]
        public bool EnableVerify
        {
            get { return enableVerify; }
            set
            {
                enableVerify = value;
                //item_Verify.Enabled = enableVerify;
            }
        }

        [Category("InstallModules")]
        public bool Denied
        {
            get { return denied; }
            set
            {
                denied = value;
                if (denied)
                    timer1.Interval = 5;
            }
        }

        /// <summary>
        /// danh sach tat ca thao tac duoc phep thuc hien
        /// </summary>
        [Category("InstallModules")]
        public  GoobizFrame.Windows.PlugIn.Authorization.Actions UserActions
        {
            get { return _UserActions; }
            set { _UserActions = value; }
        }
        #endregion


        bool _CancelClosed = false;
        public bool CancelClosed { get { return _CancelClosed; } set { _CancelClosed = value; } }

        public InstallModules()
        {
            InitializeComponent();

            objPolicyService = new Ecm.WebReferences.Classes.PolicyService();
            DisplayInfo();
       }
        void DisplayInfo()
        {
            //lookUpEdit_Dm_User
            dsPol_Dm_User = objPolicyService.Get_Pol_Dm_User_Collection3().ToDataSet();
            lookUpEdit_Dm_User.Properties.DataSource = dsPol_Dm_User.Tables[0];

            DisplayInfo2();

        }

        void DisplayInfo2()
        {
            //HostConfiguration
            string profile_folder = Application.StartupPath + @"\Resources\" + lookUpEdit_Dm_User.EditValue + @"\";

            GoobizFrame.Profile.Config hostConfiguration = GoobizFrame.Windows.Public.HostConfiguration.Instance;
            hostConfiguration.GroupName = "HostConfiguration";
            pluginConfigFile = "" + hostConfiguration.GetValue("Plugins", "PluginConfigFile");
           
            if (!System.IO.Directory.Exists(profile_folder))
            {
                System.IO.Directory.CreateDirectory(profile_folder);
                System.IO.File.Copy(pluginConfigFile, pluginConfigFile.Replace("Resources", profile_folder));

                //change Plugins.config
                 GoobizFrame.Profile.Config configPlugins = new  GoobizFrame.Profile.Config(profile_folder + "Plugins.config");
                configPlugins.GroupName = "Plugins";
                foreach (string section in configPlugins.GetSectionNames())
                {
                    string PluginItemConfig = "" + configPlugins.GetValue(section, "PluginItemConfig");
                    PluginItemConfig = PluginItemConfig.Replace("Resources", @"Resources\" + lookUpEdit_Dm_User.EditValue);
                    configPlugins.SetValue(section, "PluginItemConfig", PluginItemConfig);
                }
            }

            pluginConfigs = new  GoobizFrame.Profile.Config(pluginConfigFile.Replace("Resources", profile_folder));
            pluginConfigs.GroupName = "Plugins";
            dsPlugins = new DataSet();
            dsPlugins.Tables.Add("Plugins");
            dsPlugins.Tables[0].Columns.Add("Name");
            dsPlugins.Tables[0].Columns.Add("Assembly");
            dsPlugins.Tables[0].Columns.Add("PluginType");
            dsPlugins.Tables[0].Columns.Add("PluginItemConfig");
            dsPlugins.Tables[0].Columns.Add("SelectAsDefaultModule", typeof(bool));
            dsPlugins.Tables[0].Columns.Add("LoadModule", typeof(bool));
            string[] sectionNames = pluginConfigs.GetSectionNames();
            foreach (string section in sectionNames)
            {
                System.Data.DataRow newRow = dsPlugins.Tables[0].NewRow();
                newRow["Name"] = section;
                newRow["Assembly"] = "" + pluginConfigs.GetValue(section, "Assembly");
                newRow["PluginType"] = "" + pluginConfigs.GetValue(section, "PluginType");
                newRow["PluginItemConfig"] = "" + pluginConfigs.GetValue(section, "PluginItemConfig");
                newRow["SelectAsDefaultModule"] = Convert.ToBoolean( pluginConfigs.GetValue(section, "SelectAsDefaultModule") );
                newRow["LoadModule"] = Convert.ToBoolean( pluginConfigs.GetValue(section, "LoadModule") );
                dsPlugins.Tables[0].Rows.Add(newRow);
            }
            dsPlugins.AcceptChanges();
            dsPlugins.Tables[0].RowChanging += new DataRowChangeEventHandler(InstallModules_RowChanging);
            dgPlugins.DataSource = dsPlugins.Tables[0];
            

            if (!DesignMode)
                 GoobizFrame.Windows.MdiUtils.UserInterfaceHelper.UpdateButtonItems(barManager1);

            item_Save.Enabled = false;
        }

        void InstallModules_RowChanging(object sender, DataRowChangeEventArgs e)
        {
            item_Save.Enabled = true;
        }

        private void barManager1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "item_Close":
                    this.Close();
                    break;
                case "item_Properties":
                    if ("" + gridView1.GetFocusedRowCellValue("Assembly") != "")
                    {
                        string assembly = Application.StartupPath + @"\" + gridView1.GetFocusedRowCellValue("Assembly");
                        moduleProperies = (ModuleProperies) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(this.MdiParent, "ModuleProperies");
                        if (moduleProperies == null || moduleProperies.IsDisposed)
                            moduleProperies = new ModuleProperies();

                        moduleProperies.AssemblyName = assembly;
                        moduleProperies.MdiParent = this.MdiParent;
                        moduleProperies.Show();
                        moduleProperies.Activate();
                    }
                    break;

                case "item_RemovePlugin":
                    if ( GoobizFrame.Windows.Forms.UserMessage.Show("Msg00018", new string[] { gridView1.GetFocusedRowCellDisplayText("Name")  }) == DialogResult.Yes)
                    {
                        pluginConfigs.GroupName = "Plugins";
                        pluginConfigs.SetValue(gridView1.GetFocusedRowCellDisplayText("Name"), "LoadModule", false);
                        gridView1.SetFocusedRowCellValue(gridView1.Columns["LoadModule"], false);
                    }
                    break;
                case "item_Save":
                    foreach (DataRow rPlugin in dsPlugins.GetChanges().Tables[0].Rows)
                    {
                        //string PluginItemConfig = "" + pluginConfigs.GetValue("" + rPlugin["Name"], "PluginItemConfig");
                        //if ("" + lookUpEdit_Dm_User.EditValue != "")
                        //{
                        //    PluginItemConfig = PluginItemConfig.Replace("Resources", "Resources\\" + lookUpEdit_Dm_User.EditValue);
                        //    pluginConfigs.SetValue("" + rPlugin["Name"], "PluginItemConfig", PluginItemConfig);
                        //}
                        pluginConfigs.SetValue(""+rPlugin["Name"], "LoadModule", rPlugin["LoadModule"]);
                        pluginConfigs.SetValue(""+rPlugin["Name"], "SelectAsDefaultModule", rPlugin["SelectAsDefaultModule"]);
                    }

                    //if ("" + lookUpEdit_Dm_User.EditValue != "")
                        this.UploadFile(pluginConfigFile.Replace("Resources", "Resources/" + lookUpEdit_Dm_User.EditValue), "" + lookUpEdit_Dm_User.EditValue);

                    //Application.Restart();

                    item_Save.Enabled = false;
                    break;
                case "item_InstallPlugin":
                    break;
            }
        }

        private void dgPlugins_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) { this.popupMenu1.ShowPopup(Control.MousePosition); }
        }

        private void lookUpEdit_Dm_User_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.Utils.WaitDialogForm WaitDialogForm = new DevExpress.Utils.WaitDialogForm();

            DisplayInfo2();

            WaitDialogForm.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (denied)
                this.Close();
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
    }
}