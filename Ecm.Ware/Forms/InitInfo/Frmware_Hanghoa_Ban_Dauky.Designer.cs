namespace Ecm.Ware.Forms
{
    partial class Frmware_Hanghoa_Ban_Dauky
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
            this.dgware_Hanghoa_Ban_Dauky = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridDateEdit_Thang_Nam = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookUpEdit_Cuahang_Ban = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookUpEdit_Hanghoa_Ban = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCalEdit_Numeric = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookUpEdit_Donvitinh = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookupEdit_Tenhang = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Hanghoa_Ban_Dauky)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDateEdit_Thang_Nam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDateEdit_Thang_Nam.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Cuahang_Ban)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Hanghoa_Ban)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCalEdit_Numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Donvitinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookupEdit_Tenhang)).BeginInit();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.LookAndFeel.SkinName = "Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // dgware_Hanghoa_Ban_Dauky
            // 
            this.dgware_Hanghoa_Ban_Dauky.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgware_Hanghoa_Ban_Dauky.EmbeddedNavigator.TextStringFormat = "Dòng: {0} / {1}";
            this.dgware_Hanghoa_Ban_Dauky.Location = new System.Drawing.Point(0, 65);
            this.dgware_Hanghoa_Ban_Dauky.MainView = this.gridView1;
            this.dgware_Hanghoa_Ban_Dauky.Name = "dgware_Hanghoa_Ban_Dauky";
            this.dgware_Hanghoa_Ban_Dauky.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gridDateEdit_Thang_Nam,
            this.gridLookUpEdit_Cuahang_Ban,
            this.gridLookUpEdit_Hanghoa_Ban,
            this.gridLookUpEdit_Donvitinh,
            this.gridLookupEdit_Tenhang,
            this.gridCalEdit_Numeric});
            this.dgware_Hanghoa_Ban_Dauky.Size = new System.Drawing.Size(1008, 668);
            this.dgware_Hanghoa_Ban_Dauky.TabIndex = 1;
            this.dgware_Hanghoa_Ban_Dauky.UseEmbeddedNavigator = true;
            this.dgware_Hanghoa_Ban_Dauky.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn7,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10});
            this.gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(842, 545, 216, 183);
            this.gridView1.GridControl = this.dgware_Hanghoa_Ban_Dauky;
            this.gridView1.GroupCount = 1;
            this.gridView1.GroupPanelText = "[Kéo một cột vào đây để nhóm]";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn3, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Số thứ tự";
            this.gridColumn1.FieldName = "Id_Hanghoa_Ban_Dauky";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Ngày đầu kỳ";
            this.gridColumn2.ColumnEdit = this.gridDateEdit_Thang_Nam;
            this.gridColumn2.FieldName = "Ngay_Nhap";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridDateEdit_Thang_Nam
            // 
            this.gridDateEdit_Thang_Nam.AutoHeight = false;
            this.gridDateEdit_Thang_Nam.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridDateEdit_Thang_Nam.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridDateEdit_Thang_Nam.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridDateEdit_Thang_Nam.EditFormat.FormatString = "dd/MM/yyyy";
            this.gridDateEdit_Thang_Nam.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridDateEdit_Thang_Nam.Mask.EditMask = "dd/MM/yyyy";
            this.gridDateEdit_Thang_Nam.Name = "gridDateEdit_Thang_Nam";
            this.gridDateEdit_Thang_Nam.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Kho ";
            this.gridColumn3.ColumnEdit = this.gridLookUpEdit_Cuahang_Ban;
            this.gridColumn3.FieldName = "Id_Cuahang_Ban";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 80;
            // 
            // gridLookUpEdit_Cuahang_Ban
            // 
            this.gridLookUpEdit_Cuahang_Ban.AutoHeight = false;
            this.gridLookUpEdit_Cuahang_Ban.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEdit_Cuahang_Ban.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Cuahang_Ban", "Stt", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Cuahang_Ban", "Mã cửa hàng bán"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Cuahang_Ban", "Tên cửa hàng bán")});
            this.gridLookUpEdit_Cuahang_Ban.DisplayMember = "Ten_Cuahang_Ban";
            this.gridLookUpEdit_Cuahang_Ban.Name = "gridLookUpEdit_Cuahang_Ban";
            this.gridLookUpEdit_Cuahang_Ban.NullText = "";
            this.gridLookUpEdit_Cuahang_Ban.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.gridLookUpEdit_Cuahang_Ban.ValueMember = "Id_Cuahang_Ban";
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "Kho";
            this.gridColumn7.ColumnEdit = this.gridLookUpEdit_Cuahang_Ban;
            this.gridColumn7.FieldName = "Id_Cuahang_Ban";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            this.gridColumn7.Width = 184;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Mã Hàng";
            this.gridColumn4.ColumnEdit = this.gridLookUpEdit_Hanghoa_Ban;
            this.gridColumn4.FieldName = "Id_Hanghoa_Ban";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 170;
            // 
            // gridLookUpEdit_Hanghoa_Ban
            // 
            this.gridLookUpEdit_Hanghoa_Ban.AutoHeight = false;
            this.gridLookUpEdit_Hanghoa_Ban.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.gridLookUpEdit_Hanghoa_Ban.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.gridLookUpEdit_Hanghoa_Ban.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Hanghoa_Ban", "Stt", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Hanghoa_Ban", "Mã hàng hóa sản xuất"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Hanghoa_Ban", "Tên hàng hóa sản xuất")});
            this.gridLookUpEdit_Hanghoa_Ban.DisplayMember = "Ma_Hanghoa_Ban";
            this.gridLookUpEdit_Hanghoa_Ban.Name = "gridLookUpEdit_Hanghoa_Ban";
            this.gridLookUpEdit_Hanghoa_Ban.NullText = "";
            this.gridLookUpEdit_Hanghoa_Ban.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.gridLookUpEdit_Hanghoa_Ban.ValueMember = "Id_Hanghoa_Ban";
            this.gridLookUpEdit_Hanghoa_Ban.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.gridLookUpEdit_Hanghoa_Ban_ButtonClick);
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "Số lượng";
            this.gridColumn5.ColumnEdit = this.gridCalEdit_Numeric;
            this.gridColumn5.DisplayFormat.FormatString = "n";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "Soluong";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 211;
            // 
            // gridCalEdit_Numeric
            // 
            this.gridCalEdit_Numeric.AutoHeight = false;
            this.gridCalEdit_Numeric.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridCalEdit_Numeric.DisplayFormat.FormatString = "n";
            this.gridCalEdit_Numeric.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridCalEdit_Numeric.EditFormat.FormatString = "n";
            this.gridCalEdit_Numeric.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridCalEdit_Numeric.Mask.EditMask = "n";
            this.gridCalEdit_Numeric.Name = "gridCalEdit_Numeric";
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "Đơn vị tính";
            this.gridColumn6.ColumnEdit = this.gridLookUpEdit_Donvitinh;
            this.gridColumn6.FieldName = "Id_Donvitinh";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 214;
            // 
            // gridLookUpEdit_Donvitinh
            // 
            this.gridLookUpEdit_Donvitinh.AutoHeight = false;
            this.gridLookUpEdit_Donvitinh.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEdit_Donvitinh.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Donvitinh", "Stt", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Donvitinh", "Mã DVT"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Donvitinh", "Tên DVT")});
            this.gridLookUpEdit_Donvitinh.DisplayMember = "Ten_Donvitinh";
            this.gridLookUpEdit_Donvitinh.Name = "gridLookUpEdit_Donvitinh";
            this.gridLookUpEdit_Donvitinh.NullText = "";
            this.gridLookUpEdit_Donvitinh.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.gridLookUpEdit_Donvitinh.ValueMember = "Id_Donvitinh";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Tên hàng";
            this.gridColumn8.ColumnEdit = this.gridLookupEdit_Tenhang;
            this.gridColumn8.FieldName = "Id_Hanghoa_Ban";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 2;
            this.gridColumn8.Width = 211;
            // 
            // gridLookupEdit_Tenhang
            // 
            this.gridLookupEdit_Tenhang.AutoHeight = false;
            this.gridLookupEdit_Tenhang.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookupEdit_Tenhang.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Hanghoa_Ban", "Id_Hanghoa_Ban"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Hanghoa_Ban", "Ten_Hanghoa_Ban")});
            this.gridLookupEdit_Tenhang.DisplayMember = "Ten_Hanghoa_Ban";
            this.gridLookupEdit_Tenhang.Name = "gridLookupEdit_Tenhang";
            this.gridLookupEdit_Tenhang.NullText = "";
            this.gridLookupEdit_Tenhang.ReadOnly = true;
            this.gridLookupEdit_Tenhang.ValueMember = "Id_Hanghoa_Ban";
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Đơn giá";
            this.gridColumn9.ColumnEdit = this.gridCalEdit_Numeric;
            this.gridColumn9.DisplayFormat.FormatString = "n0";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn9.FieldName = "Dongia";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 5;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Thành tiền";
            this.gridColumn10.ColumnEdit = this.gridCalEdit_Numeric;
            this.gridColumn10.DisplayFormat.FormatString = "n0";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn10.FieldName = "Thanhtien";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 6;
            // 
            // Frmware_Hanghoa_Ban_Dauky
            // 
            this.AllowRefresh = true;
            this.ClientSize = new System.Drawing.Size(1008, 733);
            this.Controls.Add(this.dgware_Hanghoa_Ban_Dauky);
            this.EditMode = GoobizFrame.Windows.Forms.FormUpdateWithToolbar.EditModes.Separate;
            this.FormState = GoobizFrame.Windows.Forms.FormState.View;
            this.Name = "Frmware_Hanghoa_Ban_Dauky";
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Hanghoa_Ban_Dauky)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDateEdit_Thang_Nam.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDateEdit_Thang_Nam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Cuahang_Ban)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Hanghoa_Ban)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCalEdit_Numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Donvitinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookupEdit_Tenhang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgware_Hanghoa_Ban_Dauky;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit gridDateEdit_Thang_Nam;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridLookUpEdit_Cuahang_Ban;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridLookUpEdit_Hanghoa_Ban;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridLookUpEdit_Donvitinh;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridLookupEdit_Tenhang;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit gridCalEdit_Numeric;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
    }
}
