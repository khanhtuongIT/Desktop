namespace Ecm.SystemControl.SystemInfo
{
    partial class UCSetMachineLocation
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_eLocation = new DevExpress.XtraEditors.SimpleButton();
            this.btn_sLocation = new DevExpress.XtraEditors.SimpleButton();
            this.btn_cLocation = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.dgware_Dm_Cuahang_Ban = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.xtraHNavigator1 = new  GoobizFrame.Windows.Controls.XtraHNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Cuahang_Ban)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_eLocation
            // 
            this.btn_eLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_eLocation.Location = new System.Drawing.Point(425, 3);
            this.btn_eLocation.Name = "btn_eLocation";
            this.btn_eLocation.Size = new System.Drawing.Size(75, 23);
            this.btn_eLocation.TabIndex = 102;
            this.btn_eLocation.Text = "Sửa";
            this.btn_eLocation.Click += new System.EventHandler(this.btn_eLocation_Click);
            // 
            // btn_sLocation
            // 
            this.btn_sLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_sLocation.Location = new System.Drawing.Point(508, 3);
            this.btn_sLocation.Name = "btn_sLocation";
            this.btn_sLocation.Size = new System.Drawing.Size(75, 23);
            this.btn_sLocation.TabIndex = 102;
            this.btn_sLocation.Text = "Lưu";
            this.btn_sLocation.Click += new System.EventHandler(this.btn_sLocation_Click);
            // 
            // btn_cLocation
            // 
            this.btn_cLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cLocation.Location = new System.Drawing.Point(591, 3);
            this.btn_cLocation.Name = "btn_cLocation";
            this.btn_cLocation.Size = new System.Drawing.Size(75, 23);
            this.btn_cLocation.TabIndex = 102;
            this.btn_cLocation.Text = "Bỏ qua";
            this.btn_cLocation.Click += new System.EventHandler(this.btn_cLocation_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btn_cLocation);
            this.panelControl1.Controls.Add(this.btn_eLocation);
            this.panelControl1.Controls.Add(this.btn_sLocation);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(667, 28);
            this.panelControl1.TabIndex = 103;
            // 
            // dgware_Dm_Cuahang_Ban
            // 
            this.dgware_Dm_Cuahang_Ban.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgware_Dm_Cuahang_Ban.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.dgware_Dm_Cuahang_Ban.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.dgware_Dm_Cuahang_Ban.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.dgware_Dm_Cuahang_Ban.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.dgware_Dm_Cuahang_Ban.EmbeddedNavigator.Buttons.First.Visible = false;
            this.dgware_Dm_Cuahang_Ban.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.dgware_Dm_Cuahang_Ban.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.dgware_Dm_Cuahang_Ban.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.dgware_Dm_Cuahang_Ban.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.dgware_Dm_Cuahang_Ban.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.dgware_Dm_Cuahang_Ban.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.dgware_Dm_Cuahang_Ban.EmbeddedNavigator.TextStringFormat = "Dòng: {0} / {1}";
            this.dgware_Dm_Cuahang_Ban.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dgware_Dm_Cuahang_Ban_EmbeddedNavigator_ButtonClick);
            this.dgware_Dm_Cuahang_Ban.Location = new System.Drawing.Point(0, 28);
            this.dgware_Dm_Cuahang_Ban.MainView = this.gridView1;
            this.dgware_Dm_Cuahang_Ban.Name = "dgware_Dm_Cuahang_Ban";
            this.dgware_Dm_Cuahang_Ban.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.dgware_Dm_Cuahang_Ban.Size = new System.Drawing.Size(667, 288);
            this.dgware_Dm_Cuahang_Ban.TabIndex = 104;
            this.dgware_Dm_Cuahang_Ban.UseEmbeddedNavigator = true;
            this.dgware_Dm_Cuahang_Ban.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gridView1.GridControl = this.dgware_Dm_Cuahang_Ban;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Số thứ tự";
            this.gridColumn1.FieldName = "Id_Cuahang_Ban";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Mã kho hàng";
            this.gridColumn2.FieldName = "Ma_Cuahang_Ban";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Tên kho hàng";
            this.gridColumn3.FieldName = "Ten_Cuahang_Ban";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Vị trí máy";
            this.gridColumn4.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn4.FieldName = "CurrentLocation";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // xtraHNavigator1
            // 
            this.xtraHNavigator1.ButtonModes =  GoobizFrame.Windows.Controls.XtraHNavigator.NavigatorButtonModes.ShowNavigators;
            this.xtraHNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xtraHNavigator1.GridControl = this.dgware_Dm_Cuahang_Ban;
            this.xtraHNavigator1.Location = new System.Drawing.Point(0, 316);
            this.xtraHNavigator1.Name = "xtraHNavigator1";
            this.xtraHNavigator1.Orientation =  GoobizFrame.Windows.Controls.XtraHNavigator.NavigatorOrientation.Horizontal;
            this.xtraHNavigator1.Size = new System.Drawing.Size(667, 44);
            this.xtraHNavigator1.TabIndex = 107;
            this.xtraHNavigator1.VisibleAppend = false;
            this.xtraHNavigator1.VisibleCancelEdit = false;
            this.xtraHNavigator1.VisibleEndEdit = false;
            this.xtraHNavigator1.VisibleFirst = true;
            this.xtraHNavigator1.VisibleLast = true;
            this.xtraHNavigator1.VisibleNext = true;
            this.xtraHNavigator1.VisiblePageNext = true;
            this.xtraHNavigator1.VisiblePagePrev = true;
            this.xtraHNavigator1.VisiblePrev = true;
            this.xtraHNavigator1.VisibleRemove = false;
            // 
            // UCSetMachineLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgware_Dm_Cuahang_Ban);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.xtraHNavigator1);
            this.Name = "UCSetMachineLocation";
            this.Size = new System.Drawing.Size(667, 360);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Cuahang_Ban)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_eLocation;
        private DevExpress.XtraEditors.SimpleButton btn_sLocation;
        private DevExpress.XtraEditors.SimpleButton btn_cLocation;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl dgware_Dm_Cuahang_Ban;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private  GoobizFrame.Windows.Controls.XtraHNavigator xtraHNavigator1;
    }
}
