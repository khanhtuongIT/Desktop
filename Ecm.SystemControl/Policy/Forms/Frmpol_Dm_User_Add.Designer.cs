namespace SunLine.SystemControl.Policy.Forms
{
    partial class Frmpol_Dm_User_Add
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmpol_Dm_User_Add));
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btbUser_Properties = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.bteUser_Name = new DevExpress.XtraEditors.ButtonEdit();
            this.lookUpEdit_Nhansu = new DevExpress.XtraEditors.LookUpEdit();
            this.txtUser_Description = new DevExpress.XtraEditors.TextEdit();
            this.txtUser_Fullname = new DevExpress.XtraEditors.TextEdit();
            this.txtId_User = new DevExpress.XtraEditors.TextEdit();
            this.lblUser_Description = new DevExpress.XtraEditors.LabelControl();
            this.lblUser_Fullname = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblUser_Name = new DevExpress.XtraEditors.LabelControl();
            this.lblId_User = new DevExpress.XtraEditors.LabelControl();
            this.dgpol_Dm_User = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookUpEdit_Nhansu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.btnAdd_ADUser = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bteUser_Name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Nhansu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser_Description.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser_Fullname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId_User.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgpol_Dm_User)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Nhansu)).BeginInit();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.LookAndFeel.SkinName = "Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Khóa người dùng";
            this.gridColumn6.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn6.FieldName = "User_Disable";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btbUser_Properties)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // btbUser_Properties
            // 
            this.btbUser_Properties.Caption = "Thông tin người dùng";
            this.btbUser_Properties.Id = 25;
            this.btbUser_Properties.Name = "btbUser_Properties";
            // 
            // barManager1
            // 
            this.barManager1.Controller = this.barAndDockingController1;
            this.barManager1.DockControls.Add(this.barDockControl1);
            this.barManager1.DockControls.Add(this.barDockControl2);
            this.barManager1.DockControls.Add(this.barDockControl3);
            this.barManager1.DockControls.Add(this.barDockControl4);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btbUser_Properties});
            this.barManager1.MaxItemId = 0;
            this.barManager1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barManager1_ItemClick);
            // 
            // barDockControl1
            // 
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Size = new System.Drawing.Size(921, 0);
            // 
            // barDockControl2
            // 
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 432);
            this.barDockControl2.Size = new System.Drawing.Size(921, 0);
            // 
            // barDockControl3
            // 
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 0);
            this.barDockControl3.Size = new System.Drawing.Size(0, 432);
            // 
            // barDockControl4
            // 
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(921, 0);
            this.barDockControl4.Size = new System.Drawing.Size(0, 432);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.bteUser_Name);
            this.panelControl1.Controls.Add(this.lookUpEdit_Nhansu);
            this.panelControl1.Controls.Add(this.txtUser_Description);
            this.panelControl1.Controls.Add(this.txtUser_Fullname);
            this.panelControl1.Controls.Add(this.txtId_User);
            this.panelControl1.Controls.Add(this.lblUser_Description);
            this.panelControl1.Controls.Add(this.lblUser_Fullname);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.lblUser_Name);
            this.panelControl1.Controls.Add(this.lblId_User);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 60);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(921, 70);
            this.panelControl1.TabIndex = 0;
            // 
            // bteUser_Name
            // 
            this.bteUser_Name.Location = new System.Drawing.Point(168, 14);
            this.bteUser_Name.MenuManager = this.barManager;
            this.bteUser_Name.Name = "bteUser_Name";
            this.bteUser_Name.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Tìm AD User", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.bteUser_Name.Size = new System.Drawing.Size(182, 20);
            this.bteUser_Name.TabIndex = 12;
            this.bteUser_Name.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bteUser_Name_ButtonClick);
            // 
            // lookUpEdit_Nhansu
            // 
            this.lookUpEdit_Nhansu.Location = new System.Drawing.Point(402, 13);
            this.lookUpEdit_Nhansu.Name = "lookUpEdit_Nhansu";
            this.lookUpEdit_Nhansu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit_Nhansu.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Nhansu", "STT"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Nhansu", "Mã NS"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Hoten_Nhansu", "Tên NS")});
            this.lookUpEdit_Nhansu.Properties.DisplayMember = "Ma_Nhansu";
            this.lookUpEdit_Nhansu.Properties.NullText = "";
            this.lookUpEdit_Nhansu.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit_Nhansu.Properties.ValueMember = "Id_Nhansu";
            this.lookUpEdit_Nhansu.Size = new System.Drawing.Size(215, 20);
            this.lookUpEdit_Nhansu.TabIndex = 11;
            this.lookUpEdit_Nhansu.EditValueChanged += new System.EventHandler(this.lookUpEdit_Nhansu_EditValueChanged);
            // 
            // txtUser_Description
            // 
            this.txtUser_Description.Location = new System.Drawing.Point(47, 39);
            this.txtUser_Description.Name = "txtUser_Description";
            this.txtUser_Description.Size = new System.Drawing.Size(839, 20);
            this.txtUser_Description.TabIndex = 3;
            // 
            // txtUser_Fullname
            // 
            this.txtUser_Fullname.Location = new System.Drawing.Point(661, 13);
            this.txtUser_Fullname.Name = "txtUser_Fullname";
            this.txtUser_Fullname.Size = new System.Drawing.Size(225, 20);
            this.txtUser_Fullname.TabIndex = 2;
            // 
            // txtId_User
            // 
            this.txtId_User.Enabled = false;
            this.txtId_User.Location = new System.Drawing.Point(47, 12);
            this.txtId_User.Name = "txtId_User";
            this.txtId_User.Size = new System.Drawing.Size(50, 20);
            this.txtId_User.TabIndex = 0;
            // 
            // lblUser_Description
            // 
            this.lblUser_Description.Location = new System.Drawing.Point(12, 43);
            this.lblUser_Description.Name = "lblUser_Description";
            this.lblUser_Description.Size = new System.Drawing.Size(27, 13);
            this.lblUser_Description.TabIndex = 10;
            this.lblUser_Description.Text = "Mô tả";
            // 
            // lblUser_Fullname
            // 
            this.lblUser_Fullname.Location = new System.Drawing.Point(623, 17);
            this.lblUser_Fullname.Name = "lblUser_Fullname";
            this.lblUser_Fullname.Size = new System.Drawing.Size(32, 13);
            this.lblUser_Fullname.TabIndex = 8;
            this.lblUser_Fullname.Text = "Họ tên";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(356, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Nhân sự";
            // 
            // lblUser_Name
            // 
            this.lblUser_Name.Location = new System.Drawing.Point(113, 16);
            this.lblUser_Name.Name = "lblUser_Name";
            this.lblUser_Name.Size = new System.Drawing.Size(49, 13);
            this.lblUser_Name.TabIndex = 2;
            this.lblUser_Name.Text = "Định danh";
            // 
            // lblId_User
            // 
            this.lblId_User.Location = new System.Drawing.Point(12, 16);
            this.lblId_User.Name = "lblId_User";
            this.lblId_User.Size = new System.Drawing.Size(18, 13);
            this.lblId_User.TabIndex = 0;
            this.lblId_User.Text = "STT";
            // 
            // dgpol_Dm_User
            // 
            this.dgpol_Dm_User.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgpol_Dm_User.EmbeddedNavigator.TextStringFormat = "Dòng {0} / {1}";
            this.dgpol_Dm_User.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dgpol_Dm_User_EmbeddedNavigator_ButtonClick);
            this.dgpol_Dm_User.Location = new System.Drawing.Point(0, 130);
            this.dgpol_Dm_User.MainView = this.gridView1;
            this.dgpol_Dm_User.Name = "dgpol_Dm_User";
            this.dgpol_Dm_User.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gridLookUpEdit_Nhansu,
            this.repositoryItemCheckEdit1,
            this.repositoryItemButtonEdit1});
            this.dgpol_Dm_User.Size = new System.Drawing.Size(921, 279);
            this.dgpol_Dm_User.TabIndex = 1;
            this.dgpol_Dm_User.UseEmbeddedNavigator = true;
            this.dgpol_Dm_User.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.dgpol_Dm_User.Load += new System.EventHandler(this.Frmpol_Dm_User_Add_Load);
            this.dgpol_Dm_User.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgpol_Dm_User_MouseClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.gridColumn6;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = true;
            this.gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gridView1.GridControl = this.dgpol_Dm_User;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "STT";
            this.gridColumn1.FieldName = "Id_User";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Định danh";
            this.gridColumn2.ColumnEdit = this.repositoryItemButtonEdit1;
            this.gridColumn2.FieldName = "User_Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowMove = false;
            this.gridColumn2.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Tìm AD User", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEdit1_ButtonClick);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Họ tên";
            this.gridColumn3.FieldName = "User_Fullname";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Mô tả";
            this.gridColumn4.FieldName = "User_Description";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowMove = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Nhân sự";
            this.gridColumn5.ColumnEdit = this.gridLookUpEdit_Nhansu;
            this.gridColumn5.FieldName = "Id_Nhansu";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            // 
            // gridLookUpEdit_Nhansu
            // 
            this.gridLookUpEdit_Nhansu.AutoHeight = false;
            this.gridLookUpEdit_Nhansu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEdit_Nhansu.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Nhansu", "STT"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Nhansu", "Mã NS"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Hoten_Nhansu", "Họ tên")});
            this.gridLookUpEdit_Nhansu.DisplayMember = "Ma_Nhansu";
            this.gridLookUpEdit_Nhansu.Name = "gridLookUpEdit_Nhansu";
            this.gridLookUpEdit_Nhansu.NullText = "";
            this.gridLookUpEdit_Nhansu.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.gridLookUpEdit_Nhansu.ValueMember = "Id_Nhansu";
            // 
            // btnAdd_ADUser
            // 
            this.btnAdd_ADUser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAdd_ADUser.Location = new System.Drawing.Point(0, 409);
            this.btnAdd_ADUser.Name = "btnAdd_ADUser";
            this.btnAdd_ADUser.Size = new System.Drawing.Size(921, 23);
            this.btnAdd_ADUser.TabIndex = 12;
            this.btnAdd_ADUser.Text = "Thêm người dùng từ tài khoản AD Domain";
            this.btnAdd_ADUser.Click += new System.EventHandler(this.btnAdd_ADUser_Click);
            // 
            // Frmpol_Dm_User_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 432);
            this.Controls.Add(this.dgpol_Dm_User);
            this.Controls.Add(this.btnAdd_ADUser);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frmpol_Dm_User_Add";
            this.Text = "Frmpol_Dm_User_Add";
            this.Controls.SetChildIndex(this.barDockControl1, 0);
            this.Controls.SetChildIndex(this.barDockControl2, 0);
            this.Controls.SetChildIndex(this.barDockControl4, 0);
            this.Controls.SetChildIndex(this.barDockControl3, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.btnAdd_ADUser, 0);
            this.Controls.SetChildIndex(this.dgpol_Dm_User, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bteUser_Name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Nhansu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser_Description.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser_Fullname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId_User.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgpol_Dm_User)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Nhansu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtUser_Description;
        private DevExpress.XtraEditors.TextEdit txtUser_Fullname;
        private DevExpress.XtraEditors.TextEdit txtId_User;
        private DevExpress.XtraEditors.LabelControl lblUser_Description;
        private DevExpress.XtraEditors.LabelControl lblUser_Fullname;
        private DevExpress.XtraEditors.LabelControl lblUser_Name;
        private DevExpress.XtraEditors.LabelControl lblId_User;
        private DevExpress.XtraGrid.GridControl dgpol_Dm_User;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraBars.BarButtonItem btbUser_Properties;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_Nhansu;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridLookUpEdit_Nhansu;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.SimpleButton btnAdd_ADUser;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.ButtonEdit bteUser_Name;
    }
}