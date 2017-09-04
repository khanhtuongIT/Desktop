namespace Ecm.MasterTables.Forms.Ware
{
    partial class Frmware_Dm_Donvitinh_Quydoi_Add
    {
        

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgware_Dm_Donvitinh_Quydoi = new DevExpress.XtraGrid.GridControl();
            this.gvChitiet = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookUp_Hanghoa_Ban = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridText_Soluong_Goc = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridText_Soluong_Quydoi = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookUp_Donvitinh = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookUpEdit_Donvitinh2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.xtraHNavigator1 = new GoobizFrame.Windows.Controls.XtraHNavigator();
            this.dsWare_Dm_Khachhang = new Ecm.MasterTables.DataSets.DsWare_Dm_Khachhang();
            this.wareDmKhachhangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Donvitinh_Quydoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChitiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUp_Hanghoa_Ban)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridText_Soluong_Goc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridText_Soluong_Quydoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUp_Donvitinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Donvitinh2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsWare_Dm_Khachhang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wareDmKhachhangBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.LookAndFeel.SkinName = "Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // dgware_Dm_Donvitinh_Quydoi
            // 
            this.dgware_Dm_Donvitinh_Quydoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgware_Dm_Donvitinh_Quydoi.EmbeddedNavigator.Buttons.Append.Enabled = false;
            this.dgware_Dm_Donvitinh_Quydoi.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.dgware_Dm_Donvitinh_Quydoi.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.dgware_Dm_Donvitinh_Quydoi.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.dgware_Dm_Donvitinh_Quydoi.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.dgware_Dm_Donvitinh_Quydoi.EmbeddedNavigator.Buttons.First.Visible = false;
            this.dgware_Dm_Donvitinh_Quydoi.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.dgware_Dm_Donvitinh_Quydoi.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.dgware_Dm_Donvitinh_Quydoi.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.dgware_Dm_Donvitinh_Quydoi.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.dgware_Dm_Donvitinh_Quydoi.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.dgware_Dm_Donvitinh_Quydoi.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.dgware_Dm_Donvitinh_Quydoi.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.dgware_Dm_Donvitinh_Quydoi.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
            this.dgware_Dm_Donvitinh_Quydoi.EmbeddedNavigator.TextStringFormat = "Dòng: {0} / {1}";
            this.dgware_Dm_Donvitinh_Quydoi.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dgware_Dm_Donvitinh_Quydoi_EmbeddedNavigator_ButtonClick);
            this.dgware_Dm_Donvitinh_Quydoi.Location = new System.Drawing.Point(0, 65);
            this.dgware_Dm_Donvitinh_Quydoi.MainView = this.gvChitiet;
            this.dgware_Dm_Donvitinh_Quydoi.Name = "dgware_Dm_Donvitinh_Quydoi";
            this.dgware_Dm_Donvitinh_Quydoi.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gridLookUp_Donvitinh,
            this.gridLookUpEdit_Donvitinh2,
            this.gridText_Soluong_Goc,
            this.gridText_Soluong_Quydoi,
            this.gridLookUp_Hanghoa_Ban});
            this.dgware_Dm_Donvitinh_Quydoi.Size = new System.Drawing.Size(1008, 643);
            this.dgware_Dm_Donvitinh_Quydoi.TabIndex = 1;
            this.dgware_Dm_Donvitinh_Quydoi.UseEmbeddedNavigator = true;
            this.dgware_Dm_Donvitinh_Quydoi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvChitiet});
            // 
            // gvChitiet
            // 
            this.gvChitiet.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.gvChitiet.GridControl = this.dgware_Dm_Donvitinh_Quydoi;
            this.gvChitiet.GroupPanelText = "[Kéo một cột vào đây để nhóm]";
            this.gvChitiet.Name = "gvChitiet";
            this.gvChitiet.OptionsView.ShowGroupPanel = false;
            this.gvChitiet.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gvChitiet.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Số thứ tự";
            this.gridColumn1.FieldName = "Id_Donvitinh_Quydoi";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "Mã hàng hóa";
            this.gridColumn7.ColumnEdit = this.gridLookUp_Hanghoa_Ban;
            this.gridColumn7.FieldName = "Id_Hanghoa_Ban";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            this.gridColumn7.Width = 141;
            // 
            // gridLookUp_Hanghoa_Ban
            // 
            this.gridLookUp_Hanghoa_Ban.AutoHeight = false;
            this.gridLookUp_Hanghoa_Ban.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.gridLookUp_Hanghoa_Ban.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUp_Hanghoa_Ban.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Hanghoa_Ban", "STT", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Hanghoa_Ban", "Mã hàng hóa"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Hanghoa_Ban", "Tên hàng hóa")});
            this.gridLookUp_Hanghoa_Ban.DisplayMember = "Ma_Hanghoa_Ban";
            this.gridLookUp_Hanghoa_Ban.Name = "gridLookUp_Hanghoa_Ban";
            this.gridLookUp_Hanghoa_Ban.NullText = "";
            this.gridLookUp_Hanghoa_Ban.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.gridLookUp_Hanghoa_Ban.ValueMember = "Id_Hanghoa_Ban";
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.Caption = "Tên hàng hóa";
            this.gridColumn8.FieldName = "Ten_Hanghoa_Ban";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            this.gridColumn8.Width = 250;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Số lượng 1";
            this.gridColumn2.ColumnEdit = this.gridText_Soluong_Goc;
            this.gridColumn2.DisplayFormat.FormatString = "n0";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn2.FieldName = "Soluong1";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 61;
            // 
            // gridText_Soluong_Goc
            // 
            this.gridText_Soluong_Goc.AutoHeight = false;
            this.gridText_Soluong_Goc.DisplayFormat.FormatString = "n0";
            this.gridText_Soluong_Goc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridText_Soluong_Goc.EditFormat.FormatString = "n0";
            this.gridText_Soluong_Goc.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridText_Soluong_Goc.Mask.EditMask = "([0-9]\\d*([.]\\d)?\\d?)|[0]";
            this.gridText_Soluong_Goc.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.gridText_Soluong_Goc.Mask.ShowPlaceHolders = false;
            this.gridText_Soluong_Goc.Name = "gridText_Soluong_Goc";
            this.gridText_Soluong_Goc.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.gridText_Soluong_Goc_EditValueChanging);
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Số lượng 2";
            this.gridColumn3.ColumnEdit = this.gridText_Soluong_Quydoi;
            this.gridColumn3.DisplayFormat.FormatString = "n";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn3.FieldName = "Soluong2";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 63;
            // 
            // gridText_Soluong_Quydoi
            // 
            this.gridText_Soluong_Quydoi.AutoHeight = false;
            this.gridText_Soluong_Quydoi.DisplayFormat.FormatString = "n";
            this.gridText_Soluong_Quydoi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridText_Soluong_Quydoi.EditFormat.FormatString = "n";
            this.gridText_Soluong_Quydoi.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridText_Soluong_Quydoi.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.gridText_Soluong_Quydoi.Mask.ShowPlaceHolders = false;
            this.gridText_Soluong_Quydoi.Name = "gridText_Soluong_Quydoi";
            this.gridText_Soluong_Quydoi.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.gridText_Soluong_Quydoi_EditValueChanging);
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Ghi chú";
            this.gridColumn4.FieldName = "Ghichu";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 6;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "Đơn vị tính";
            this.gridColumn5.ColumnEdit = this.gridLookUp_Donvitinh;
            this.gridColumn5.FieldName = "Id_Donvitinh1";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 87;
            // 
            // gridLookUp_Donvitinh
            // 
            this.gridLookUp_Donvitinh.AutoHeight = false;
            this.gridLookUp_Donvitinh.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUp_Donvitinh.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Donvitinh", "Stt", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Donvitinh", "Mã đơn vị tính"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Donvitinh", "Tên đơn vị tính")});
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
            this.gridColumn6.Caption = "Đơn vị quy đổi";
            this.gridColumn6.ColumnEdit = this.gridLookUp_Donvitinh;
            this.gridColumn6.FieldName = "Id_Donvitinh2";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 87;
            // 
            // gridLookUpEdit_Donvitinh2
            // 
            this.gridLookUpEdit_Donvitinh2.AutoHeight = false;
            this.gridLookUpEdit_Donvitinh2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEdit_Donvitinh2.Name = "gridLookUpEdit_Donvitinh2";
            this.gridLookUpEdit_Donvitinh2.NullText = "";
            this.gridLookUpEdit_Donvitinh2.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.gridLookUpEdit_Donvitinh2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // xtraHNavigator1
            // 
            this.xtraHNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xtraHNavigator1.GridControl = this.dgware_Dm_Donvitinh_Quydoi;
            this.xtraHNavigator1.Location = new System.Drawing.Point(0, 708);
            this.xtraHNavigator1.Margin = new System.Windows.Forms.Padding(0);
            this.xtraHNavigator1.Name = "xtraHNavigator1";
            this.xtraHNavigator1.Size = new System.Drawing.Size(1008, 24);
            this.xtraHNavigator1.TabIndex = 9;
            this.xtraHNavigator1.TextStringFormat = "Dòng: {0} / {1}";
            this.xtraHNavigator1.VisibleFirst = true;
            this.xtraHNavigator1.VisibleLast = true;
            this.xtraHNavigator1.VisibleNext = true;
            this.xtraHNavigator1.VisiblePageNext = true;
            this.xtraHNavigator1.VisiblePagePrev = true;
            this.xtraHNavigator1.VisiblePrev = true;
            // 
            // dsWare_Dm_Khachhang
            // 
            this.dsWare_Dm_Khachhang.DataSetName = "DsWare_Dm_Khachhang";
            this.dsWare_Dm_Khachhang.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // wareDmKhachhangBindingSource
            // 
            this.wareDmKhachhangBindingSource.DataMember = "Ware_Dm_Khachhang";
            this.wareDmKhachhangBindingSource.DataSource = this.dsWare_Dm_Khachhang;
            // 
            // Frmware_Dm_Donvitinh_Quydoi_Add
            // 
            this.AllowRefresh = true;
            this.ClientSize = new System.Drawing.Size(1008, 732);
            this.Controls.Add(this.dgware_Dm_Donvitinh_Quydoi);
            this.Controls.Add(this.xtraHNavigator1);
            this.EditMode = GoobizFrame.Windows.Forms.FormUpdateWithToolbar.EditModes.Separate;
            this.FormState = GoobizFrame.Windows.Forms.FormState.View;
            this.Name = "Frmware_Dm_Donvitinh_Quydoi_Add";
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Donvitinh_Quydoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChitiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUp_Hanghoa_Ban)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridText_Soluong_Goc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridText_Soluong_Quydoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUp_Donvitinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Donvitinh2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsWare_Dm_Khachhang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wareDmKhachhangBindingSource)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        private DevExpress.XtraGrid.GridControl dgware_Dm_Donvitinh_Quydoi;
        private DevExpress.XtraGrid.Views.Grid.GridView gvChitiet;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridLookUp_Hanghoa_Ban;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit gridText_Soluong_Goc;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit gridText_Soluong_Quydoi;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridLookUp_Donvitinh;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridLookUpEdit_Donvitinh2;
        private GoobizFrame.Windows.Controls.XtraHNavigator xtraHNavigator1;
        private System.ComponentModel.IContainer components;
        private DataSets.DsWare_Dm_Khachhang dsWare_Dm_Khachhang;
        private System.Windows.Forms.BindingSource wareDmKhachhangBindingSource;
    }
}
