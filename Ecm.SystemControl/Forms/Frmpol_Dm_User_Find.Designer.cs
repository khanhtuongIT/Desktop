namespace Ecm.SystemControl.Forms
{
    partial class Frmpol_Dm_User_Find
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmpol_Dm_User_Find));
            this.txtLocation = new DevExpress.XtraEditors.TextEdit();
            this.btbBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.btbSelect = new DevExpress.XtraEditors.SimpleButton();
            this.btbCancel = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkAll = new DevExpress.XtraEditors.CheckEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lblLocation = new DevExpress.XtraEditors.LabelControl();
            this.dgPol_Dm_User = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookUpEdit_Nhansu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.chkId_User = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPol_Dm_User)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Nhansu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkId_User)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(12, 29);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(389, 20);
            this.txtLocation.TabIndex = 0;
            // 
            // btbBrowse
            // 
            this.btbBrowse.Location = new System.Drawing.Point(408, 27);
            this.btbBrowse.Name = "btbBrowse";
            this.btbBrowse.Size = new System.Drawing.Size(74, 24);
            this.btbBrowse.TabIndex = 1;
            this.btbBrowse.Text = "Browse";
            // 
            // btbSelect
            // 
            this.btbSelect.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btbSelect.Location = new System.Drawing.Point(326, 5);
            this.btbSelect.Name = "btbSelect";
            this.btbSelect.Size = new System.Drawing.Size(75, 23);
            this.btbSelect.TabIndex = 0;
            this.btbSelect.Text = "Đồng ý";
            this.btbSelect.Click += new System.EventHandler(this.btbSelect_Click);
            // 
            // btbCancel
            // 
            this.btbCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btbCancel.Location = new System.Drawing.Point(407, 5);
            this.btbCancel.Name = "btbCancel";
            this.btbCancel.Size = new System.Drawing.Size(75, 23);
            this.btbCancel.TabIndex = 1;
            this.btbCancel.Text = "Thoát";
            this.btbCancel.Click += new System.EventHandler(this.btbCancel_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chkAll);
            this.panelControl1.Controls.Add(this.btbCancel);
            this.panelControl1.Controls.Add(this.btbSelect);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 291);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(492, 32);
            this.panelControl1.TabIndex = 9;
            // 
            // chkAll
            // 
            this.chkAll.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkAll.Location = new System.Drawing.Point(2, 2);
            this.chkAll.Name = "chkAll";
            this.chkAll.Properties.Caption = "Chọn tất cả";
            this.chkAll.Size = new System.Drawing.Size(118, 19);
            this.chkAll.TabIndex = 5;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.lblLocation);
            this.panelControl2.Controls.Add(this.btbBrowse);
            this.panelControl2.Controls.Add(this.txtLocation);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Enabled = false;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(492, 61);
            this.panelControl2.TabIndex = 10;
            // 
            // lblLocation
            // 
            this.lblLocation.Location = new System.Drawing.Point(12, 10);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(97, 13);
            this.lblLocation.TabIndex = 3;
            this.lblLocation.Text = "Chọn người dùng tại";
            // 
            // dgPol_Dm_User
            // 
            this.dgPol_Dm_User.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPol_Dm_User.Location = new System.Drawing.Point(0, 61);
            this.dgPol_Dm_User.MainView = this.gridView1;
            this.dgPol_Dm_User.Name = "dgPol_Dm_User";
            this.dgPol_Dm_User.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkId_User,
            this.repositoryItemCheckEdit1,
            this.gridLookUpEdit_Nhansu});
            this.dgPol_Dm_User.Size = new System.Drawing.Size(492, 230);
            this.dgPol_Dm_User.TabIndex = 1;
            this.dgPol_Dm_User.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
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
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.GridControl = this.dgPol_Dm_User;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowDetailButtons = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "STT";
            this.gridColumn1.FieldName = "Id_User";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Width = 39;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Định danh";
            this.gridColumn2.FieldName = "User_Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowMove = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 84;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Họ tên";
            this.gridColumn3.FieldName = "User_Fullname";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowMove = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 124;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Mô tả";
            this.gridColumn4.FieldName = "User_Description";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowMove = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 176;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Chọn";
            this.gridColumn5.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn5.FieldName = "Checked";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 48;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Nhân sự";
            this.gridColumn6.ColumnEdit = this.gridLookUpEdit_Nhansu;
            this.gridColumn6.FieldName = "Id_Nhansu";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            // 
            // gridLookUpEdit_Nhansu
            // 
            this.gridLookUpEdit_Nhansu.AutoHeight = false;
            this.gridLookUpEdit_Nhansu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEdit_Nhansu.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Nhansu", "Stt"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Nhansu", "Mã NS"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Hoten_Nhansu", "Họ tên")});
            this.gridLookUpEdit_Nhansu.DisplayMember = "Ma_Nhansu";
            this.gridLookUpEdit_Nhansu.Name = "gridLookUpEdit_Nhansu";
            this.gridLookUpEdit_Nhansu.NullText = "";
            this.gridLookUpEdit_Nhansu.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.gridLookUpEdit_Nhansu.ValueMember = "Id_Nhansu";
            // 
            // chkId_User
            // 
            this.chkId_User.AutoHeight = false;
            this.chkId_User.Name = "chkId_User";
            this.chkId_User.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.chkId_User.ValueGrayed = false;
            // 
            // Frmpol_Dm_User_Find
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 323);
            this.Controls.Add(this.dgPol_Dm_User);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frmpol_Dm_User_Find";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Frmpol_Dm_User_Find_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPol_Dm_User)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Nhansu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkId_User)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtLocation;
        private DevExpress.XtraEditors.SimpleButton btbBrowse;
        private DevExpress.XtraEditors.SimpleButton btbSelect;
        private DevExpress.XtraEditors.SimpleButton btbCancel;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl dgPol_Dm_User;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl lblLocation;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkId_User;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridLookUpEdit_Nhansu;
        private DevExpress.XtraEditors.CheckEdit chkAll;
    }
}