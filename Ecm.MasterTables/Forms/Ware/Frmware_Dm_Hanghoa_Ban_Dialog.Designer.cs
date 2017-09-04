namespace Ecm.MasterTables.Forms.Ware
{
    partial class Frmware_Dm_Hanghoa_Ban_Dialog
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
            this.dgware_Dm_Hanghoa_Ban = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookUpEdit_Loai_Hanghoa_Ban = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookUp_Donvitinh = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCheck_Choice = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookUpEdit_Nhom_Hanghoa_Ban = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dgware_Dm_Loai_Hanghoa_Ban = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookUp_Nhom_Hanghoa_Ban = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.splitter1 = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Hanghoa_Ban)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Loai_Hanghoa_Ban)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUp_Donvitinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCheck_Choice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Nhom_Hanghoa_Ban)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Loai_Hanghoa_Ban)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUp_Nhom_Hanghoa_Ban)).BeginInit();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.LookAndFeel.SkinName = "Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // dgware_Dm_Hanghoa_Ban
            // 
            this.dgware_Dm_Hanghoa_Ban.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgware_Dm_Hanghoa_Ban.EmbeddedNavigator.TextStringFormat = "Dòng: {0} / {1}";
            this.dgware_Dm_Hanghoa_Ban.Location = new System.Drawing.Point(235, 65);
            this.dgware_Dm_Hanghoa_Ban.MainView = this.gridView1;
            this.dgware_Dm_Hanghoa_Ban.Name = "dgware_Dm_Hanghoa_Ban";
            this.dgware_Dm_Hanghoa_Ban.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gridLookUpEdit_Loai_Hanghoa_Ban,
            this.gridLookUp_Donvitinh,
            this.repositoryItemTextEdit1,
            this.gridCheck_Choice,
            this.gridLookUpEdit_Nhom_Hanghoa_Ban});
            this.dgware_Dm_Hanghoa_Ban.Size = new System.Drawing.Size(645, 423);
            this.dgware_Dm_Hanghoa_Ban.TabIndex = 4;
            this.dgware_Dm_Hanghoa_Ban.UseEmbeddedNavigator = true;
            this.dgware_Dm_Hanghoa_Ban.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
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
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12});
            this.gridView1.GridControl = this.dgware_Dm_Hanghoa_Ban;
            this.gridView1.GroupPanelText = "[Kéo một cột vào đây để nhóm]";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Số thứ tự";
            this.gridColumn1.FieldName = "Id_Hanghoa_Ban";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Mã hàng hóa";
            this.gridColumn2.FieldName = "Ma_Hanghoa_Ban";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Tên hàng hóa";
            this.gridColumn3.FieldName = "Ten_Hanghoa_Ban";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Loại hàng hóa sản xuất";
            this.gridColumn4.ColumnEdit = this.gridLookUpEdit_Loai_Hanghoa_Ban;
            this.gridColumn4.FieldName = "Id_Loai_Hanghoa_Ban";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // gridLookUpEdit_Loai_Hanghoa_Ban
            // 
            this.gridLookUpEdit_Loai_Hanghoa_Ban.AutoHeight = false;
            this.gridLookUpEdit_Loai_Hanghoa_Ban.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEdit_Loai_Hanghoa_Ban.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Loai_Hanghoa_Ban", "Stt"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Loai_Hanghoa_Ban", "Mã loại HH bán"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Loai_Hanghoa_Ban", "Tên loại HH bán")});
            this.gridLookUpEdit_Loai_Hanghoa_Ban.DisplayMember = "Ten_Loai_Hanghoa_Ban";
            this.gridLookUpEdit_Loai_Hanghoa_Ban.Name = "gridLookUpEdit_Loai_Hanghoa_Ban";
            this.gridLookUpEdit_Loai_Hanghoa_Ban.NullText = "";
            this.gridLookUpEdit_Loai_Hanghoa_Ban.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.gridLookUpEdit_Loai_Hanghoa_Ban.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.gridLookUpEdit_Loai_Hanghoa_Ban.ValueMember = "Id_Loai_Hanghoa_Ban";
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "Size";
            this.gridColumn5.FieldName = "Size";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "Quy cách";
            this.gridColumn6.FieldName = "Quycach";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "ĐVT";
            this.gridColumn7.ColumnEdit = this.gridLookUp_Donvitinh;
            this.gridColumn7.FieldName = "Id_Donvitinh";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            // 
            // gridLookUp_Donvitinh
            // 
            this.gridLookUp_Donvitinh.AutoHeight = false;
            this.gridLookUp_Donvitinh.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.gridLookUp_Donvitinh.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Donvitinh", "STT"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Donvitinh", "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Donvitinh", "Tên")});
            this.gridLookUp_Donvitinh.DisplayMember = "Ten_Donvitinh";
            this.gridLookUp_Donvitinh.Name = "gridLookUp_Donvitinh";
            this.gridLookUp_Donvitinh.NullText = "";
            this.gridLookUp_Donvitinh.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.gridLookUp_Donvitinh.ValueMember = "Id_Donvitinh";
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn8.Caption = "Số lượng cảnh báo";
            this.gridColumn8.ColumnEdit = this.repositoryItemTextEdit1;
            this.gridColumn8.DisplayFormat.FormatString = "n";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "Soluong_Min";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Width = 246;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Mask.EditMask = "([1-9]\\d*([.]\\d)?\\d?)|[0]";
            this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.repositoryItemTextEdit1.Mask.ShowPlaceHolders = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.Caption = "Mã vạch";
            this.gridColumn9.FieldName = "Barcode_Txt";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 6;
            this.gridColumn9.Width = 240;
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
            // 
            // gridCheck_Choice
            // 
            this.gridCheck_Choice.AutoHeight = false;
            this.gridCheck_Choice.Name = "gridCheck_Choice";
            this.gridCheck_Choice.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn11.Caption = "Nhóm hàng hóa";
            this.gridColumn11.ColumnEdit = this.gridLookUpEdit_Nhom_Hanghoa_Ban;
            this.gridColumn11.FieldName = "Id_Nhom_Hanghoa_Ban";
            this.gridColumn11.Name = "gridColumn11";
            // 
            // gridLookUpEdit_Nhom_Hanghoa_Ban
            // 
            this.gridLookUpEdit_Nhom_Hanghoa_Ban.AutoHeight = false;
            this.gridLookUpEdit_Nhom_Hanghoa_Ban.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEdit_Nhom_Hanghoa_Ban.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Nhom_Hanghoa_Ban", "STT"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Nhom_Hanghoa_Ban", "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Nhom_Hanghoa_Ban", "Tên")});
            this.gridLookUpEdit_Nhom_Hanghoa_Ban.DisplayMember = "Ten_Nhom_Hanghoa_Ban";
            this.gridLookUpEdit_Nhom_Hanghoa_Ban.Name = "gridLookUpEdit_Nhom_Hanghoa_Ban";
            this.gridLookUpEdit_Nhom_Hanghoa_Ban.NullText = "";
            this.gridLookUpEdit_Nhom_Hanghoa_Ban.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.gridLookUpEdit_Nhom_Hanghoa_Ban.ValueMember = "Id_Nhom_Hanghoa_Ban";
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Số lượng tồn";
            this.gridColumn12.FieldName = "Soluong_Ton";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 7;
            // 
            // dgware_Dm_Loai_Hanghoa_Ban
            // 
            this.dgware_Dm_Loai_Hanghoa_Ban.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgware_Dm_Loai_Hanghoa_Ban.EmbeddedNavigator.TextStringFormat = "Dòng: {0} / {1}";
            this.dgware_Dm_Loai_Hanghoa_Ban.Location = new System.Drawing.Point(0, 65);
            this.dgware_Dm_Loai_Hanghoa_Ban.MainView = this.gridView2;
            this.dgware_Dm_Loai_Hanghoa_Ban.Name = "dgware_Dm_Loai_Hanghoa_Ban";
            this.dgware_Dm_Loai_Hanghoa_Ban.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gridLookUp_Nhom_Hanghoa_Ban});
            this.dgware_Dm_Loai_Hanghoa_Ban.Size = new System.Drawing.Size(235, 423);
            this.dgware_Dm_Loai_Hanghoa_Ban.TabIndex = 7;
            this.dgware_Dm_Loai_Hanghoa_Ban.UseEmbeddedNavigator = true;
            this.dgware_Dm_Loai_Hanghoa_Ban.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17});
            this.gridView2.GridControl = this.dgware_Dm_Loai_Hanghoa_Ban;
            this.gridView2.GroupCount = 1;
            this.gridView2.GroupPanelText = "[Kéo một cột vào đây để nhóm]";
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn17, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView2.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView2_FocusedRowChanged);
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Số thứ tự";
            this.gridColumn14.FieldName = "Id_Loai_Hanghoa_Ban";
            this.gridColumn14.Name = "gridColumn14";
            // 
            // gridColumn15
            // 
            this.gridColumn15.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn15.Caption = "Mã loại hàng hóa";
            this.gridColumn15.FieldName = "Ma_Loai_Hanghoa_Ban";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.ReadOnly = true;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 0;
            this.gridColumn15.Width = 41;
            // 
            // gridColumn16
            // 
            this.gridColumn16.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn16.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn16.Caption = "Tên loại hàng hóa";
            this.gridColumn16.FieldName = "Ten_Loai_Hanghoa_Ban";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.ReadOnly = true;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 1;
            this.gridColumn16.Width = 173;
            // 
            // gridColumn17
            // 
            this.gridColumn17.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn17.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn17.Caption = "Nhóm";
            this.gridColumn17.ColumnEdit = this.gridLookUp_Nhom_Hanghoa_Ban;
            this.gridColumn17.FieldName = "Id_Nhom_Hanghoa_Ban";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 0;
            this.gridColumn17.Width = 132;
            // 
            // gridLookUp_Nhom_Hanghoa_Ban
            // 
            this.gridLookUp_Nhom_Hanghoa_Ban.AutoHeight = false;
            this.gridLookUp_Nhom_Hanghoa_Ban.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUp_Nhom_Hanghoa_Ban.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Nhom_Hanghoa_Ban", "Stt", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Nhom_Hanghoa_Ban", "Mã nhóm HH bán"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Nhom_Hanghoa_Ban", "Tên nhóm HH bán")});
            this.gridLookUp_Nhom_Hanghoa_Ban.DisplayMember = "Ten_Nhom_Hanghoa_Ban";
            this.gridLookUp_Nhom_Hanghoa_Ban.Name = "gridLookUp_Nhom_Hanghoa_Ban";
            this.gridLookUp_Nhom_Hanghoa_Ban.NullText = "";
            this.gridLookUp_Nhom_Hanghoa_Ban.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.gridLookUp_Nhom_Hanghoa_Ban.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.gridLookUp_Nhom_Hanghoa_Ban.ValueMember = "Id_Nhom_Hanghoa_Ban";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(235, 65);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 423);
            this.splitter1.TabIndex = 8;
            this.splitter1.TabStop = false;
            // 
            // Frmware_Dm_Hanghoa_Ban_Dialog
            // 
            this.AllowSelect = true;
            this.ClientSize = new System.Drawing.Size(880, 488);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.dgware_Dm_Hanghoa_Ban);
            this.Controls.Add(this.dgware_Dm_Loai_Hanghoa_Ban);
            this.EditMode = GoobizFrame.Windows.Forms.FormUpdateWithToolbar.EditModes.Separate;
            this.FormState = GoobizFrame.Windows.Forms.FormState.View;
            this.Name = "Frmware_Dm_Hanghoa_Ban_Dialog";
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Hanghoa_Ban)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Loai_Hanghoa_Ban)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUp_Donvitinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCheck_Choice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Nhom_Hanghoa_Ban)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Loai_Hanghoa_Ban)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUp_Nhom_Hanghoa_Ban)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgware_Dm_Hanghoa_Ban;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridLookUpEdit_Loai_Hanghoa_Ban;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridLookUp_Donvitinh;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit gridCheck_Choice;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridLookUpEdit_Nhom_Hanghoa_Ban;
        private DevExpress.XtraGrid.GridControl dgware_Dm_Loai_Hanghoa_Ban;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridLookUp_Nhom_Hanghoa_Ban;
        private System.Windows.Forms.Splitter splitter1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
    }
}
