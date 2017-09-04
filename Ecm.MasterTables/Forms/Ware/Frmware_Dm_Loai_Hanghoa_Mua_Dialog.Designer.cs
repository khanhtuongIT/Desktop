namespace SunLine.MasterTables.Forms.Ware
{
    partial class Frmware_Dm_Loai_Hanghoa_Mua_Dialog
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
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Loai_Hanghoa_Mua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Nhom_Hanghoa_Mua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
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
            this.dgware_Dm_Loai_Hanghoa_Mua.Location = new System.Drawing.Point(0, 24);
            this.dgware_Dm_Loai_Hanghoa_Mua.MainView = this.gridView1;
            this.dgware_Dm_Loai_Hanghoa_Mua.Name = "dgware_Dm_Loai_Hanghoa_Mua";
            this.dgware_Dm_Loai_Hanghoa_Mua.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gridLookUpEdit_Nhom_Hanghoa_Mua,
            this.repositoryItemCheckEdit1});
            this.dgware_Dm_Loai_Hanghoa_Mua.Size = new System.Drawing.Size(626, 349);
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
            this.gridColumn4,
            this.gridColumn5});
            this.gridView1.GridControl = this.dgware_Dm_Loai_Hanghoa_Mua;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn4, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
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
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridLookUpEdit_Nhom_Hanghoa_Mua
            // 
            this.gridLookUpEdit_Nhom_Hanghoa_Mua.AutoHeight = false;
            this.gridLookUpEdit_Nhom_Hanghoa_Mua.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEdit_Nhom_Hanghoa_Mua.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Nhom_Hanghoa_Mua", "Stt", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Nhom_Hanghoa_Mua", "Mã nhóm HH mua", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Nhom_Hanghoa_Mua", "Tên nhóm HH mua", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.gridLookUpEdit_Nhom_Hanghoa_Mua.DisplayMember = "Ten_Nhom_Hanghoa_Mua";
            this.gridLookUpEdit_Nhom_Hanghoa_Mua.Name = "gridLookUpEdit_Nhom_Hanghoa_Mua";
            this.gridLookUpEdit_Nhom_Hanghoa_Mua.NullText = "";
            this.gridLookUpEdit_Nhom_Hanghoa_Mua.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.gridLookUpEdit_Nhom_Hanghoa_Mua.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.gridLookUpEdit_Nhom_Hanghoa_Mua.ValueMember = "Id_Nhom_Hanghoa_Mua";
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "Chọn";
            this.gridColumn5.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn5.FieldName = "Chon";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // Frmware_Dm_Loai_Hanghoa_Mua_Dialog
            // 
            this.AllowRefresh = true;
            this.AllowSelect = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(626, 373);
            this.Controls.Add(this.dgware_Dm_Loai_Hanghoa_Mua);
            this.Name = "Frmware_Dm_Loai_Hanghoa_Mua_Dialog";
            this.toolTipController1.SetSuperTip(this, null);
            this.Controls.SetChildIndex(this.dgware_Dm_Loai_Hanghoa_Mua, 0);
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Loai_Hanghoa_Mua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Nhom_Hanghoa_Mua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
    }
}
