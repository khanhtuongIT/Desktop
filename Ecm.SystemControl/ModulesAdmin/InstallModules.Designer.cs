namespace Ecm.SystemControl.ModulesAdmin
{
    partial class InstallModules
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstallModules));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.item_InstallPlugin = new DevExpress.XtraBars.BarButtonItem();
            this.item_RemovePlugin = new DevExpress.XtraBars.BarButtonItem();
            this.item_Config = new DevExpress.XtraBars.BarButtonItem();
            this.item_Save = new DevExpress.XtraBars.BarButtonItem();
            this.item_Properties = new DevExpress.XtraBars.BarButtonItem();
            this.item_Close = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.dgPlugins = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAssembly = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPluginType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPluginItemConfig = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSelectAsDefaultModule = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.LoadModule = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lookUpEdit_Dm_User = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPlugins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Dm_User.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Images = this.imageCollection1;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.item_InstallPlugin,
            this.item_RemovePlugin,
            this.item_Config,
            this.item_Close,
            this.item_Properties,
            this.item_Save});
            this.barManager1.LargeImages = this.imageCollection1;
            this.barManager1.MaxItemId = 6;
            this.barManager1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barManager1_ItemClick);
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.item_InstallPlugin),
            new DevExpress.XtraBars.LinkPersistInfo(this.item_RemovePlugin),
            new DevExpress.XtraBars.LinkPersistInfo(this.item_Config),
            new DevExpress.XtraBars.LinkPersistInfo(this.item_Save),
            new DevExpress.XtraBars.LinkPersistInfo(this.item_Properties),
            new DevExpress.XtraBars.LinkPersistInfo(this.item_Close)});
            this.bar1.Text = "Tools";
            // 
            // item_InstallPlugin
            // 
            this.item_InstallPlugin.Caption = "item_InstallPlugin";
            this.item_InstallPlugin.Description = "Cài đặt Plugin";
            this.item_InstallPlugin.Hint = "Cài đặt Plugin";
            this.item_InstallPlugin.Id = 0;
            this.item_InstallPlugin.LargeImageIndex = 0;
            this.item_InstallPlugin.Name = "item_InstallPlugin";
            this.item_InstallPlugin.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // item_RemovePlugin
            // 
            this.item_RemovePlugin.Caption = "item_RemovePlugin";
            this.item_RemovePlugin.Description = "Xóa Plugin";
            this.item_RemovePlugin.Hint = "Xóa Plugin";
            this.item_RemovePlugin.Id = 1;
            this.item_RemovePlugin.LargeImageIndex = 1;
            this.item_RemovePlugin.Name = "item_RemovePlugin";
            // 
            // item_Config
            // 
            this.item_Config.Caption = "item_Config";
            this.item_Config.Id = 2;
            this.item_Config.Name = "item_Config";
            this.item_Config.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // item_Save
            // 
            this.item_Save.Caption = "item_Save";
            this.item_Save.Id = 5;
            this.item_Save.Name = "item_Save";
            // 
            // item_Properties
            // 
            this.item_Properties.Caption = "item_Properties";
            this.item_Properties.Id = 4;
            this.item_Properties.Name = "item_Properties";
            // 
            // item_Close
            // 
            this.item_Close.Caption = "item_Close";
            this.item_Close.Id = 3;
            this.item_Close.Name = "item_Close";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(906, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 454);
            this.barDockControlBottom.Size = new System.Drawing.Size(906, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 430);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(906, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 430);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(24, 24);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            // 
            // dgPlugins
            // 
            this.dgPlugins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPlugins.EmbeddedNavigator.Buttons.Append.Enabled = false;
            this.dgPlugins.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.dgPlugins.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.dgPlugins.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.dgPlugins.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.dgPlugins.EmbeddedNavigator.TextStringFormat = "Dòng : {0}/ {1}";
            this.dgPlugins.Location = new System.Drawing.Point(0, 69);
            this.dgPlugins.MainView = this.gridView1;
            this.dgPlugins.Name = "dgPlugins";
            this.dgPlugins.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.repositoryItemLookUpEdit2,
            this.repositoryItemCheckEdit1});
            this.dgPlugins.Size = new System.Drawing.Size(906, 385);
            this.dgPlugins.TabIndex = 21;
            this.dgPlugins.UseEmbeddedNavigator = true;
            this.dgPlugins.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.dgPlugins.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgPlugins_MouseClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnName,
            this.gridColumnAssembly,
            this.gridColumnPluginType,
            this.gridColumnPluginItemConfig,
            this.gridColumnSelectAsDefaultModule,
            this.LoadModule});
            this.gridView1.GridControl = this.dgPlugins;
            this.gridView1.GroupCount = 1;
            this.gridView1.GroupPanelText = "[Kéo một cột vào đây để nhóm]";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupedColumns = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumnAssembly, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumnName
            // 
            this.gridColumnName.Caption = "Name";
            this.gridColumnName.FieldName = "Name";
            this.gridColumnName.Name = "gridColumnName";
            this.gridColumnName.OptionsColumn.ReadOnly = true;
            this.gridColumnName.Visible = true;
            this.gridColumnName.VisibleIndex = 1;
            // 
            // gridColumnAssembly
            // 
            this.gridColumnAssembly.Caption = "Assembly";
            this.gridColumnAssembly.FieldName = "Assembly";
            this.gridColumnAssembly.Name = "gridColumnAssembly";
            this.gridColumnAssembly.OptionsColumn.ReadOnly = true;
            this.gridColumnAssembly.Visible = true;
            this.gridColumnAssembly.VisibleIndex = 0;
            // 
            // gridColumnPluginType
            // 
            this.gridColumnPluginType.Caption = "PluginType";
            this.gridColumnPluginType.FieldName = "PluginType";
            this.gridColumnPluginType.Name = "gridColumnPluginType";
            this.gridColumnPluginType.OptionsColumn.ReadOnly = true;
            this.gridColumnPluginType.Visible = true;
            this.gridColumnPluginType.VisibleIndex = 2;
            // 
            // gridColumnPluginItemConfig
            // 
            this.gridColumnPluginItemConfig.Caption = "PluginItemConfig";
            this.gridColumnPluginItemConfig.FieldName = "PluginItemConfig";
            this.gridColumnPluginItemConfig.Name = "gridColumnPluginItemConfig";
            this.gridColumnPluginItemConfig.OptionsColumn.ReadOnly = true;
            this.gridColumnPluginItemConfig.Visible = true;
            this.gridColumnPluginItemConfig.VisibleIndex = 3;
            // 
            // gridColumnSelectAsDefaultModule
            // 
            this.gridColumnSelectAsDefaultModule.Caption = "SelectAsDefaultModule";
            this.gridColumnSelectAsDefaultModule.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumnSelectAsDefaultModule.FieldName = "SelectAsDefaultModule";
            this.gridColumnSelectAsDefaultModule.Name = "gridColumnSelectAsDefaultModule";
            this.gridColumnSelectAsDefaultModule.Visible = true;
            this.gridColumnSelectAsDefaultModule.VisibleIndex = 4;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // LoadModule
            // 
            this.LoadModule.Caption = "LoadModule";
            this.LoadModule.ColumnEdit = this.repositoryItemCheckEdit1;
            this.LoadModule.FieldName = "LoadModule";
            this.LoadModule.Name = "LoadModule";
            this.LoadModule.Visible = true;
            this.LoadModule.VisibleIndex = 5;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.item_InstallPlugin),
            new DevExpress.XtraBars.LinkPersistInfo(this.item_RemovePlugin),
            new DevExpress.XtraBars.LinkPersistInfo(this.item_Config),
            new DevExpress.XtraBars.LinkPersistInfo(this.item_Properties)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lookUpEdit_Dm_User);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(906, 45);
            this.panelControl1.TabIndex = 22;
            // 
            // lookUpEdit_Dm_User
            // 
            this.lookUpEdit_Dm_User.Location = new System.Drawing.Point(155, 12);
            this.lookUpEdit_Dm_User.Name = "lookUpEdit_Dm_User";
            this.lookUpEdit_Dm_User.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit_Dm_User.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("User_Name", "User_Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("User_Fullname", "User_Fullname"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("User_Description", "User_Description")});
            this.lookUpEdit_Dm_User.Properties.DisplayMember = "User_Name";
            this.lookUpEdit_Dm_User.Properties.NullText = "";
            this.lookUpEdit_Dm_User.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit_Dm_User.Properties.ValueMember = "User_Name";
            this.lookUpEdit_Dm_User.Size = new System.Drawing.Size(298, 20);
            this.lookUpEdit_Dm_User.TabIndex = 1;
            this.lookUpEdit_Dm_User.EditValueChanged += new System.EventHandler(this.lookUpEdit_Dm_User_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(122, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Profile của người sử dụng";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // InstallModules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 454);
            this.Controls.Add(this.dgPlugins);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "InstallModules";
            this.Text = "InstallModules";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPlugins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Dm_User.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraBars.BarButtonItem item_InstallPlugin;
        private DevExpress.XtraBars.BarButtonItem item_RemovePlugin;
        private DevExpress.XtraGrid.GridControl dgPlugins;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private DevExpress.XtraBars.BarButtonItem item_Config;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAssembly;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPluginType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPluginItemConfig;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSelectAsDefaultModule;
        private DevExpress.XtraBars.BarButtonItem item_Close;
        private DevExpress.XtraBars.BarButtonItem item_Properties;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem item_Save;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn LoadModule;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_Dm_User;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Timer timer1;
    }
}