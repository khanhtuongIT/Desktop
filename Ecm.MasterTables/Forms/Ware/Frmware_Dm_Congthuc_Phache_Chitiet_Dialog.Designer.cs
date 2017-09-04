namespace Ecm.MasterTables.Forms.Ware
{
    partial class Frmware_Dm_Congthuc_Phache_Chitiet_Dialog
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
            this.dgware_Dm_Congthuc_Phache_Chitiet = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookUp_Congthuc_Phache = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookUp_Hanghoa_Mua = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridText_Soluong = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookUp_Donvitinh = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookUp_Nhom_Hanghoa_Ban = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookUp_Loai_Hanghoa_Ban = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCheck_Choice = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Congthuc_Phache_Chitiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUp_Congthuc_Phache)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUp_Hanghoa_Mua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridText_Soluong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUp_Donvitinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUp_Nhom_Hanghoa_Ban)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUp_Loai_Hanghoa_Ban)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCheck_Choice)).BeginInit();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.LookAndFeel.SkinName = "Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // dgware_Dm_Congthuc_Phache_Chitiet
            // 
            this.dgware_Dm_Congthuc_Phache_Chitiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgware_Dm_Congthuc_Phache_Chitiet.EmbeddedNavigator.TextStringFormat = "Dòng: {0} / {1}";
            this.dgware_Dm_Congthuc_Phache_Chitiet.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dgware_Dm_Congthuc_Phache_Chitiet_EmbeddedNavigator_ButtonClick);
            this.dgware_Dm_Congthuc_Phache_Chitiet.Location = new System.Drawing.Point(0, 65);
            this.dgware_Dm_Congthuc_Phache_Chitiet.MainView = this.gridView1;
            this.dgware_Dm_Congthuc_Phache_Chitiet.Name = "dgware_Dm_Congthuc_Phache_Chitiet";
            this.dgware_Dm_Congthuc_Phache_Chitiet.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gridLookUp_Hanghoa_Mua,
            this.gridLookUp_Congthuc_Phache,
            this.gridText_Soluong,
            this.gridLookUp_Donvitinh,
            this.gridLookUp_Nhom_Hanghoa_Ban,
            this.gridLookUp_Loai_Hanghoa_Ban,
            this.gridCheck_Choice});
            this.dgware_Dm_Congthuc_Phache_Chitiet.Size = new System.Drawing.Size(638, 333);
            this.dgware_Dm_Congthuc_Phache_Chitiet.TabIndex = 4;
            this.dgware_Dm_Congthuc_Phache_Chitiet.UseEmbeddedNavigator = true;
            this.dgware_Dm_Congthuc_Phache_Chitiet.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
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
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10});
            this.gridView1.GridControl = this.dgware_Dm_Congthuc_Phache_Chitiet;
            this.gridView1.GroupCount = 3;
            this.gridView1.GroupPanelText = "[Kéo một cột vào đây để nhóm]";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn7, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn8, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn2, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Số thứ tự";
            this.gridColumn1.FieldName = "Id_Congthuc_Phache_Chitiet";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Width = 77;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "CT pha chế";
            this.gridColumn2.ColumnEdit = this.gridLookUp_Congthuc_Phache;
            this.gridColumn2.FieldName = "Id_Congthuc_Phache";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridLookUp_Congthuc_Phache
            // 
            this.gridLookUp_Congthuc_Phache.AutoHeight = false;
            this.gridLookUp_Congthuc_Phache.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.gridLookUp_Congthuc_Phache.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Congthuc_Phache", "Stt", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Congthuc_Phache", "Mã CT pha chế"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Congthuc_Phache", "Tên CT pha chế")});
            this.gridLookUp_Congthuc_Phache.DisplayMember = "Ten_Congthuc_Phache";
            this.gridLookUp_Congthuc_Phache.Name = "gridLookUp_Congthuc_Phache";
            this.gridLookUp_Congthuc_Phache.NullText = "";
            this.gridLookUp_Congthuc_Phache.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.gridLookUp_Congthuc_Phache.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.gridLookUp_Congthuc_Phache.ValueMember = "Id_Congthuc_Phache";
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Nguyên liệu";
            this.gridColumn3.ColumnEdit = this.gridLookUp_Hanghoa_Mua;
            this.gridColumn3.FieldName = "Id_Hanghoa_Ban";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // gridLookUp_Hanghoa_Mua
            // 
            this.gridLookUp_Hanghoa_Mua.AutoHeight = false;
            this.gridLookUp_Hanghoa_Mua.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.gridLookUp_Hanghoa_Mua.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Hanghoa_Ban", "Stt", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Hanghoa_Ban", "Mã HH mua"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Hanghoa_Ban", "Tên HH mua")});
            this.gridLookUp_Hanghoa_Mua.DisplayMember = "Ten_Hanghoa_Ban";
            this.gridLookUp_Hanghoa_Mua.Name = "gridLookUp_Hanghoa_Mua";
            this.gridLookUp_Hanghoa_Mua.NullText = "";
            this.gridLookUp_Hanghoa_Mua.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.gridLookUp_Hanghoa_Mua.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.gridLookUp_Hanghoa_Mua.ValueMember = "Id_Hanghoa_Ban";
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Số lượng";
            this.gridColumn4.ColumnEdit = this.gridText_Soluong;
            this.gridColumn4.DisplayFormat.FormatString = "n";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "Soluong";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // gridText_Soluong
            // 
            this.gridText_Soluong.AutoHeight = false;
            this.gridText_Soluong.Mask.EditMask = "([0-9]\\d*([.]\\d)?\\d?)|[0]";
            this.gridText_Soluong.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.gridText_Soluong.Mask.ShowPlaceHolders = false;
            this.gridText_Soluong.Name = "gridText_Soluong";
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "Đơn vị tính";
            this.gridColumn5.ColumnEdit = this.gridLookUp_Donvitinh;
            this.gridColumn5.FieldName = "Id_Donvitinh";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            // 
            // gridLookUp_Donvitinh
            // 
            this.gridLookUp_Donvitinh.AutoHeight = false;
            this.gridLookUp_Donvitinh.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.gridLookUp_Donvitinh.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Donvitinh", "Stt", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Donvitinh", "Mã ĐVT"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Donvitinh", "Tên ĐVT")});
            this.gridLookUp_Donvitinh.DisplayMember = "Ten_Donvitinh";
            this.gridLookUp_Donvitinh.Name = "gridLookUp_Donvitinh";
            this.gridLookUp_Donvitinh.NullText = "";
            this.gridLookUp_Donvitinh.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.gridLookUp_Donvitinh.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.gridLookUp_Donvitinh.ValueMember = "Id_Donvitinh";
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "Ghi chú";
            this.gridColumn6.FieldName = "Ghichu";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "Nhóm hàng hóa";
            this.gridColumn7.ColumnEdit = this.gridLookUp_Nhom_Hanghoa_Ban;
            this.gridColumn7.FieldName = "Id_Nhom_Hanghoa_Ban";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            // 
            // gridLookUp_Nhom_Hanghoa_Ban
            // 
            this.gridLookUp_Nhom_Hanghoa_Ban.AutoHeight = false;
            this.gridLookUp_Nhom_Hanghoa_Ban.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUp_Nhom_Hanghoa_Ban.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Nhom_Hanghoa_Ban", "STT", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Nhom_Hanghoa_Ban", "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Nhom_Hanghoa_Ban", "Tên")});
            this.gridLookUp_Nhom_Hanghoa_Ban.DisplayMember = "Ten_Nhom_Hanghoa_Ban";
            this.gridLookUp_Nhom_Hanghoa_Ban.Name = "gridLookUp_Nhom_Hanghoa_Ban";
            this.gridLookUp_Nhom_Hanghoa_Ban.NullText = "";
            this.gridLookUp_Nhom_Hanghoa_Ban.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.gridLookUp_Nhom_Hanghoa_Ban.ValueMember = "Id_Nhom_Hanghoa_Ban";
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.Caption = "Loại hàng hóa";
            this.gridColumn8.ColumnEdit = this.gridLookUp_Loai_Hanghoa_Ban;
            this.gridColumn8.FieldName = "Id_Loai_Hanghoa_Ban";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            // 
            // gridLookUp_Loai_Hanghoa_Ban
            // 
            this.gridLookUp_Loai_Hanghoa_Ban.AutoHeight = false;
            this.gridLookUp_Loai_Hanghoa_Ban.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUp_Loai_Hanghoa_Ban.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Loai_Hanghoa_Ban", "STT", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Loai_Hanghoa_Ban", "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Loai_Hanghoa_Ban", "Tên")});
            this.gridLookUp_Loai_Hanghoa_Ban.DisplayMember = "Ten_Loai_Hanghoa_Ban";
            this.gridLookUp_Loai_Hanghoa_Ban.Name = "gridLookUp_Loai_Hanghoa_Ban";
            this.gridLookUp_Loai_Hanghoa_Ban.NullText = "";
            this.gridLookUp_Loai_Hanghoa_Ban.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.gridLookUp_Loai_Hanghoa_Ban.ValueMember = "Id_Loai_Hanghoa_Ban";
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.Caption = "SL hàng hóa";
            this.gridColumn9.DisplayFormat.FormatString = "n";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn9.FieldName = "Soluong_Pack";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 5;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.Caption = "Chọn";
            this.gridColumn10.ColumnEdit = this.gridCheck_Choice;
            this.gridColumn10.FieldName = "Chon";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 0;
            this.gridColumn10.Width = 83;
            // 
            // gridCheck_Choice
            // 
            this.gridCheck_Choice.AutoHeight = false;
            this.gridCheck_Choice.Name = "gridCheck_Choice";
            this.gridCheck_Choice.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // Frmware_Dm_Congthuc_Phache_Chitiet_Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 398);
            this.Controls.Add(this.dgware_Dm_Congthuc_Phache_Chitiet);
            this.Name = "Frmware_Dm_Congthuc_Phache_Chitiet_Dialog";
            this.Text = "Frmware_Dm_Congthuc_Phache_Chitiet_Dialog";
            this.Controls.SetChildIndex(this.dgware_Dm_Congthuc_Phache_Chitiet, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Congthuc_Phache_Chitiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUp_Congthuc_Phache)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUp_Hanghoa_Mua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridText_Soluong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUp_Donvitinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUp_Nhom_Hanghoa_Ban)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUp_Loai_Hanghoa_Ban)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCheck_Choice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgware_Dm_Congthuc_Phache_Chitiet;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridLookUp_Congthuc_Phache;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridLookUp_Hanghoa_Mua;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit gridText_Soluong;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridLookUp_Donvitinh;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridLookUp_Nhom_Hanghoa_Ban;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridLookUp_Loai_Hanghoa_Ban;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit gridCheck_Choice;
    }
}