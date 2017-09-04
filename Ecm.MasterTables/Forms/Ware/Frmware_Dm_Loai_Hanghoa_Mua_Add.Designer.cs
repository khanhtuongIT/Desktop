namespace SunLine.MasterTables.Forms.Ware
{
    partial class Frmware_Dm_Loai_Hanghoa_Mua_Add
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
            this.dgware_Dm_Loai_Hanghoa_Mua = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookUpEdit_Nhom_Hanghoa_Mua = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnNhom_Hanghoa_Mua = new DevExpress.XtraEditors.SimpleButton();
            this.lookUpEdit_Nhom_Hanghoa_Mua = new DevExpress.XtraEditors.LookUpEdit();
            this.lblId_Nhom_Hanghoa_Mua = new DevExpress.XtraEditors.LabelControl();
            this.txtTen_Loai_Hanghoa_Mua = new DevExpress.XtraEditors.TextEdit();
            this.lblTen_Loai_Hanghoa_Mua = new DevExpress.XtraEditors.LabelControl();
            this.txtMa_Loai_Hanghoa_Mua = new DevExpress.XtraEditors.TextEdit();
            this.lblMa_Loai_Hanghoa_Mua = new DevExpress.XtraEditors.LabelControl();
            this.txtId_Loai_Hanghoa_Mua = new DevExpress.XtraEditors.TextEdit();
            this.lblId_Loai_Hanghoa_Mua = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Loai_Hanghoa_Mua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Nhom_Hanghoa_Mua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Nhom_Hanghoa_Mua.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen_Loai_Hanghoa_Mua.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa_Loai_Hanghoa_Mua.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId_Loai_Hanghoa_Mua.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.LookAndFeel.SkinName = "Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // dgware_Dm_Loai_Hanghoa_Mua
            // 
            this.dgware_Dm_Loai_Hanghoa_Mua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgware_Dm_Loai_Hanghoa_Mua.EmbeddedNavigator.Name = "";
            this.dgware_Dm_Loai_Hanghoa_Mua.EmbeddedNavigator.TextStringFormat = "Dòng: {0} / {1}";
            this.dgware_Dm_Loai_Hanghoa_Mua.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dgware_Dm_Loai_Hanghoa_Mua_EmbeddedNavigator_ButtonClick);
            this.dgware_Dm_Loai_Hanghoa_Mua.Location = new System.Drawing.Point(0, 110);
            this.dgware_Dm_Loai_Hanghoa_Mua.MainView = this.gridView1;
            this.dgware_Dm_Loai_Hanghoa_Mua.Name = "dgware_Dm_Loai_Hanghoa_Mua";
            this.dgware_Dm_Loai_Hanghoa_Mua.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gridLookUpEdit_Nhom_Hanghoa_Mua});
            this.dgware_Dm_Loai_Hanghoa_Mua.Size = new System.Drawing.Size(1264, 654);
            this.dgware_Dm_Loai_Hanghoa_Mua.TabIndex = 1;
            this.dgware_Dm_Loai_Hanghoa_Mua.UseEmbeddedNavigator = true;
            this.dgware_Dm_Loai_Hanghoa_Mua.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gridView1.GridControl = this.dgware_Dm_Loai_Hanghoa_Mua;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Số thứ tự";
            this.gridColumn1.FieldName = "Id_Loai_Hanghoa_Mua";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Mã loại hàng hóa mua";
            this.gridColumn2.FieldName = "Ma_Loai_Hanghoa_Mua";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 116;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Tên loại hàng hóa mua";
            this.gridColumn3.FieldName = "Ten_Loai_Hanghoa_Mua";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 120;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Nhóm hàng hóa mua";
            this.gridColumn4.ColumnEdit = this.gridLookUpEdit_Nhom_Hanghoa_Mua;
            this.gridColumn4.FieldName = "Id_Nhom_Hanghoa_Mua";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 110;
            // 
            // gridLookUpEdit_Nhom_Hanghoa_Mua
            // 
            this.gridLookUpEdit_Nhom_Hanghoa_Mua.AutoHeight = false;
            this.gridLookUpEdit_Nhom_Hanghoa_Mua.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEdit_Nhom_Hanghoa_Mua.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Nhom_Hanghoa_Mua", "Stt", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Nhom_Hanghoa_Mua", "Mã nhóm HH mua", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Nhom_Hanghoa_Mua", "Tên nhóm HH mua", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.gridLookUpEdit_Nhom_Hanghoa_Mua.DisplayMember = "Ten_Nhom_Hanghoa_Mua";
            this.gridLookUpEdit_Nhom_Hanghoa_Mua.Name = "gridLookUpEdit_Nhom_Hanghoa_Mua";
            this.gridLookUpEdit_Nhom_Hanghoa_Mua.NullText = "";
            this.gridLookUpEdit_Nhom_Hanghoa_Mua.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.gridLookUpEdit_Nhom_Hanghoa_Mua.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.gridLookUpEdit_Nhom_Hanghoa_Mua.ValueMember = "Id_Nhom_Hanghoa_Mua";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnNhom_Hanghoa_Mua);
            this.panelControl1.Controls.Add(this.lookUpEdit_Nhom_Hanghoa_Mua);
            this.panelControl1.Controls.Add(this.lblId_Nhom_Hanghoa_Mua);
            this.panelControl1.Controls.Add(this.txtTen_Loai_Hanghoa_Mua);
            this.panelControl1.Controls.Add(this.lblTen_Loai_Hanghoa_Mua);
            this.panelControl1.Controls.Add(this.txtMa_Loai_Hanghoa_Mua);
            this.panelControl1.Controls.Add(this.lblMa_Loai_Hanghoa_Mua);
            this.panelControl1.Controls.Add(this.txtId_Loai_Hanghoa_Mua);
            this.panelControl1.Controls.Add(this.lblId_Loai_Hanghoa_Mua);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1264, 86);
            this.toolTipController1.SetSuperTip(this.panelControl1, null);
            this.panelControl1.TabIndex = 0;
            // 
            // btnNhom_Hanghoa_Mua
            // 
            this.btnNhom_Hanghoa_Mua.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnNhom_Hanghoa_Mua.Appearance.Options.UseFont = true;
            this.btnNhom_Hanghoa_Mua.Appearance.Options.UseTextOptions = true;
            this.btnNhom_Hanghoa_Mua.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnNhom_Hanghoa_Mua.Location = new System.Drawing.Point(777, 23);
            this.btnNhom_Hanghoa_Mua.Name = "btnNhom_Hanghoa_Mua";
            this.btnNhom_Hanghoa_Mua.Size = new System.Drawing.Size(96, 41);
            this.btnNhom_Hanghoa_Mua.TabIndex = 14;
            this.btnNhom_Hanghoa_Mua.Text = "Thêm nhóm hàng hóa mua";
            // 
            // lookUpEdit_Nhom_Hanghoa_Mua
            // 
            this.lookUpEdit_Nhom_Hanghoa_Mua.Location = new System.Drawing.Point(174, 12);
            this.lookUpEdit_Nhom_Hanghoa_Mua.Name = "lookUpEdit_Nhom_Hanghoa_Mua";
            this.lookUpEdit_Nhom_Hanghoa_Mua.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lookUpEdit_Nhom_Hanghoa_Mua.Properties.Appearance.Options.UseFont = true;
            this.lookUpEdit_Nhom_Hanghoa_Mua.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit_Nhom_Hanghoa_Mua.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Nhom_Hanghoa_Mua", "Stt", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Nhom_Hanghoa_Mua", "Mã nhóm HH mua", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Nhom_Hanghoa_Mua", "Tên nhóm HH mua", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.lookUpEdit_Nhom_Hanghoa_Mua.Properties.DisplayMember = "Ten_Nhom_Hanghoa_Mua";
            this.lookUpEdit_Nhom_Hanghoa_Mua.Properties.NullText = "";
            this.lookUpEdit_Nhom_Hanghoa_Mua.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lookUpEdit_Nhom_Hanghoa_Mua.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit_Nhom_Hanghoa_Mua.Properties.ValueMember = "Id_Nhom_Hanghoa_Mua";
            this.lookUpEdit_Nhom_Hanghoa_Mua.Size = new System.Drawing.Size(585, 26);
            this.lookUpEdit_Nhom_Hanghoa_Mua.TabIndex = 3;
            // 
            // lblId_Nhom_Hanghoa_Mua
            // 
            this.lblId_Nhom_Hanghoa_Mua.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblId_Nhom_Hanghoa_Mua.Appearance.Options.UseFont = true;
            this.lblId_Nhom_Hanghoa_Mua.Location = new System.Drawing.Point(12, 16);
            this.lblId_Nhom_Hanghoa_Mua.Name = "lblId_Nhom_Hanghoa_Mua";
            this.lblId_Nhom_Hanghoa_Mua.Size = new System.Drawing.Size(150, 19);
            this.lblId_Nhom_Hanghoa_Mua.TabIndex = 6;
            this.lblId_Nhom_Hanghoa_Mua.Text = "Nhóm hàng hóa mua";
            // 
            // txtTen_Loai_Hanghoa_Mua
            // 
            this.txtTen_Loai_Hanghoa_Mua.Location = new System.Drawing.Point(559, 49);
            this.txtTen_Loai_Hanghoa_Mua.Name = "txtTen_Loai_Hanghoa_Mua";
            this.txtTen_Loai_Hanghoa_Mua.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtTen_Loai_Hanghoa_Mua.Properties.Appearance.Options.UseFont = true;
            this.txtTen_Loai_Hanghoa_Mua.Size = new System.Drawing.Size(200, 26);
            this.txtTen_Loai_Hanghoa_Mua.TabIndex = 2;
            // 
            // lblTen_Loai_Hanghoa_Mua
            // 
            this.lblTen_Loai_Hanghoa_Mua.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblTen_Loai_Hanghoa_Mua.Appearance.Options.UseFont = true;
            this.lblTen_Loai_Hanghoa_Mua.Location = new System.Drawing.Point(388, 53);
            this.lblTen_Loai_Hanghoa_Mua.Name = "lblTen_Loai_Hanghoa_Mua";
            this.lblTen_Loai_Hanghoa_Mua.Size = new System.Drawing.Size(164, 19);
            this.lblTen_Loai_Hanghoa_Mua.TabIndex = 4;
            this.lblTen_Loai_Hanghoa_Mua.Text = "Tên loại hàng hóa mua";
            // 
            // txtMa_Loai_Hanghoa_Mua
            // 
            this.txtMa_Loai_Hanghoa_Mua.Location = new System.Drawing.Point(174, 49);
            this.txtMa_Loai_Hanghoa_Mua.Name = "txtMa_Loai_Hanghoa_Mua";
            this.txtMa_Loai_Hanghoa_Mua.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtMa_Loai_Hanghoa_Mua.Properties.Appearance.Options.UseFont = true;
            this.txtMa_Loai_Hanghoa_Mua.Size = new System.Drawing.Size(200, 26);
            this.txtMa_Loai_Hanghoa_Mua.TabIndex = 1;
            // 
            // lblMa_Loai_Hanghoa_Mua
            // 
            this.lblMa_Loai_Hanghoa_Mua.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblMa_Loai_Hanghoa_Mua.Appearance.Options.UseFont = true;
            this.lblMa_Loai_Hanghoa_Mua.Location = new System.Drawing.Point(12, 53);
            this.lblMa_Loai_Hanghoa_Mua.Name = "lblMa_Loai_Hanghoa_Mua";
            this.lblMa_Loai_Hanghoa_Mua.Size = new System.Drawing.Size(157, 19);
            this.lblMa_Loai_Hanghoa_Mua.TabIndex = 2;
            this.lblMa_Loai_Hanghoa_Mua.Text = "Mã loại hàng hóa mua";
            // 
            // txtId_Loai_Hanghoa_Mua
            // 
            this.txtId_Loai_Hanghoa_Mua.Enabled = false;
            this.txtId_Loai_Hanghoa_Mua.Location = new System.Drawing.Point(960, 38);
            this.txtId_Loai_Hanghoa_Mua.Name = "txtId_Loai_Hanghoa_Mua";
            this.txtId_Loai_Hanghoa_Mua.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtId_Loai_Hanghoa_Mua.Properties.Appearance.Options.UseFont = true;
            this.txtId_Loai_Hanghoa_Mua.Size = new System.Drawing.Size(100, 26);
            this.txtId_Loai_Hanghoa_Mua.TabIndex = 0;
            this.txtId_Loai_Hanghoa_Mua.Visible = false;
            // 
            // lblId_Loai_Hanghoa_Mua
            // 
            this.lblId_Loai_Hanghoa_Mua.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblId_Loai_Hanghoa_Mua.Appearance.Options.UseFont = true;
            this.lblId_Loai_Hanghoa_Mua.Location = new System.Drawing.Point(889, 42);
            this.lblId_Loai_Hanghoa_Mua.Name = "lblId_Loai_Hanghoa_Mua";
            this.lblId_Loai_Hanghoa_Mua.Size = new System.Drawing.Size(67, 19);
            this.lblId_Loai_Hanghoa_Mua.TabIndex = 0;
            this.lblId_Loai_Hanghoa_Mua.Text = "Số thứ tự";
            this.lblId_Loai_Hanghoa_Mua.Visible = false;
            // 
            // Frmware_Dm_Loai_Hanghoa_Mua_Add
            // 
            this.AllowRefresh = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1264, 764);
            this.Controls.Add(this.dgware_Dm_Loai_Hanghoa_Mua);
            this.Controls.Add(this.panelControl1);
            this.Name = "Frmware_Dm_Loai_Hanghoa_Mua_Add";
            this.toolTipController1.SetSuperTip(this, null);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.dgware_Dm_Loai_Hanghoa_Mua, 0);
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Loai_Hanghoa_Mua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Nhom_Hanghoa_Mua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Nhom_Hanghoa_Mua.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen_Loai_Hanghoa_Mua.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa_Loai_Hanghoa_Mua.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId_Loai_Hanghoa_Mua.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgware_Dm_Loai_Hanghoa_Mua;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridLookUpEdit_Nhom_Hanghoa_Mua;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_Nhom_Hanghoa_Mua;
        private DevExpress.XtraEditors.LabelControl lblId_Nhom_Hanghoa_Mua;
        private DevExpress.XtraEditors.TextEdit txtTen_Loai_Hanghoa_Mua;
        private DevExpress.XtraEditors.LabelControl lblTen_Loai_Hanghoa_Mua;
        private DevExpress.XtraEditors.TextEdit txtMa_Loai_Hanghoa_Mua;
        private DevExpress.XtraEditors.LabelControl lblMa_Loai_Hanghoa_Mua;
        private DevExpress.XtraEditors.TextEdit txtId_Loai_Hanghoa_Mua;
        private DevExpress.XtraEditors.LabelControl lblId_Loai_Hanghoa_Mua;
        private DevExpress.XtraEditors.SimpleButton btnNhom_Hanghoa_Mua;
    }
}
