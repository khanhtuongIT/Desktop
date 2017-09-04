using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Ware
{
    public partial class Frmware_Dm_Hanghoa_Ban_FrKhhhban :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet dsWare_Hhban_Quydoi_Hhmua = new DataSet();
        private DevExpress.XtraGrid.GridControl dgware_Dm_Hanghoa_Ban;
        private DevExpress.XtraGrid.Views.Grid.GridView gvNguyenlieu;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridLookUpEdit_Ma_Hanghoa_Ban;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridLookUpEdit_Hanghoa_Ban;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridLookUpEdit_Loai_Hanghoa_Ban;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridLookUpEdit_Nhom_Hanghoa_Ban;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridLookUpEdit_Donvitinh;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;

        object id_kh_hh_ban;
        public object Id_Kh_Hh_Ban
        {
            get { return id_kh_hh_ban; }
            set 
            {
                id_kh_hh_ban = value;
                DisplayInfo();
            }
        }

        public Frmware_Dm_Hanghoa_Ban_FrKhhhban()
        {
            InitializeComponent();

            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            DisplayInfo();
        }

        #region Override Events

        public override void DisplayInfo()
        {
            //gridLookUpEdit_Hanghoa_Ban
            DataSet ds_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
            gridLookUpEdit_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
            gridLookUpEdit_Ma_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];

            //gridLookUpEdit_Loai_Hanghoa_Ban
            gridLookUpEdit_Loai_Hanghoa_Ban.DataSource = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Ban().ToDataSet().Tables[0];

            //gridLookUpEdit_Nhom_Hanghoa_Ban
            gridLookUpEdit_Nhom_Hanghoa_Ban.DataSource = objMasterService.Get_All_Ware_Dm_Nhom_Hanghoa_Ban().ToDataSet().Tables[0];

            //dgware_Dm_Hanghoa_Ban
            if (id_kh_hh_ban != null)
            {
                objMasterService.Ware_Hhban_Quydoi_Hhmua_Init();

                dsWare_Hhban_Quydoi_Hhmua = objMasterService.Ware_Hhban_Quydoi_Hhmua_SelectByKhhhban(id_kh_hh_ban).ToDataSet();
                dgware_Dm_Hanghoa_Ban.DataSource = dsWare_Hhban_Quydoi_Hhmua;
                dgware_Dm_Hanghoa_Ban.DataMember = dsWare_Hhban_Quydoi_Hhmua.Tables[0].TableName;
            }

            gvNguyenlieu.BestFitColumns();

            base.DisplayInfo();
        }

        public override bool PerformQuery()
        {
            DisplayInfo();
            return base.PerformQuery();
        }

        public override bool PerformPrintPreview()
        {
            dgware_Dm_Hanghoa_Ban.ShowPrintPreview();
            return base.PerformPrintPreview();
        }

        #endregion

        private void dgware_Dm_Hanghoa_Ban_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {

        }

        private void btnExpExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFileDialog = new SaveFileDialog();
            SaveFileDialog.Filter = "Excel|*.xls";
            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                dgware_Dm_Hanghoa_Ban.ExportToXls(SaveFileDialog.FileName);
            }
        }

        private void dgware_Dm_Hanghoa_Ban_Click(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.dgware_Dm_Hanghoa_Ban = new DevExpress.XtraGrid.GridControl();
            this.gvNguyenlieu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookUpEdit_Ma_Hanghoa_Ban = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookUpEdit_Hanghoa_Ban = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookUpEdit_Loai_Hanghoa_Ban = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookUpEdit_Nhom_Hanghoa_Ban = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookUpEdit_Donvitinh = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Hanghoa_Ban)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNguyenlieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Ma_Hanghoa_Ban)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Hanghoa_Ban)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Loai_Hanghoa_Ban)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Nhom_Hanghoa_Ban)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Donvitinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // dgware_Dm_Hanghoa_Ban
            // 
            this.dgware_Dm_Hanghoa_Ban.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgware_Dm_Hanghoa_Ban.EmbeddedNavigator.TextStringFormat = "Dòng: {0} / {1}";
            this.dgware_Dm_Hanghoa_Ban.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dgware_Dm_Hanghoa_Ban_EmbeddedNavigator_ButtonClick);
            this.dgware_Dm_Hanghoa_Ban.Location = new System.Drawing.Point(0, 65);
            this.dgware_Dm_Hanghoa_Ban.MainView = this.gvNguyenlieu;
            this.dgware_Dm_Hanghoa_Ban.Name = "dgware_Dm_Hanghoa_Ban";
            this.dgware_Dm_Hanghoa_Ban.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gridLookUpEdit_Loai_Hanghoa_Ban,
            this.gridLookUpEdit_Donvitinh,
            this.repositoryItemTextEdit1,
            this.gridLookUpEdit_Nhom_Hanghoa_Ban,
            this.gridLookUpEdit_Ma_Hanghoa_Ban,
            this.gridLookUpEdit_Hanghoa_Ban});
            this.dgware_Dm_Hanghoa_Ban.Size = new System.Drawing.Size(1131, 362);
            this.dgware_Dm_Hanghoa_Ban.TabIndex = 6;
            this.dgware_Dm_Hanghoa_Ban.UseEmbeddedNavigator = true;
            this.dgware_Dm_Hanghoa_Ban.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNguyenlieu});
            // 
            // gvNguyenlieu
            // 
            this.gvNguyenlieu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.gridColumn12,
            this.gridColumn13});
            this.gvNguyenlieu.GridControl = this.dgware_Dm_Hanghoa_Ban;
            this.gvNguyenlieu.GroupPanelText = "[Kéo một cột vào đây để nhóm]";
            this.gvNguyenlieu.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Soluong_NLSX", null, "* Số lượng NL: {0:n}")});
            this.gvNguyenlieu.Name = "gvNguyenlieu";
            this.gvNguyenlieu.OptionsBehavior.Editable = false;
            this.gvNguyenlieu.OptionsView.AllowCellMerge = true;
            this.gvNguyenlieu.OptionsView.ColumnAutoWidth = false;
            this.gvNguyenlieu.OptionsView.ShowAutoFilterRow = true;
            this.gvNguyenlieu.OptionsView.ShowFooter = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã HHSX";
            this.gridColumn1.ColumnEdit = this.gridLookUpEdit_Ma_Hanghoa_Ban;
            this.gridColumn1.FieldName = "Id_Hanghoa_Ban_Tp";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            // 
            // gridLookUpEdit_Ma_Hanghoa_Ban
            // 
            this.gridLookUpEdit_Ma_Hanghoa_Ban.AutoHeight = false;
            this.gridLookUpEdit_Ma_Hanghoa_Ban.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEdit_Ma_Hanghoa_Ban.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Hanghoa_Ban", "STT"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Hanghoa_Ban", "Mã")});
            this.gridLookUpEdit_Ma_Hanghoa_Ban.DisplayMember = "Ma_Hanghoa_Ban";
            this.gridLookUpEdit_Ma_Hanghoa_Ban.Name = "gridLookUpEdit_Ma_Hanghoa_Ban";
            this.gridLookUpEdit_Ma_Hanghoa_Ban.NullText = "";
            this.gridLookUpEdit_Ma_Hanghoa_Ban.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.gridLookUpEdit_Ma_Hanghoa_Ban.ValueMember = "Id_Hanghoa_Ban";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên HHSX";
            this.gridColumn2.ColumnEdit = this.gridLookUpEdit_Hanghoa_Ban;
            this.gridColumn2.FieldName = "Id_Hanghoa_Ban_Tp";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            // 
            // gridLookUpEdit_Hanghoa_Ban
            // 
            this.gridLookUpEdit_Hanghoa_Ban.AutoHeight = false;
            this.gridLookUpEdit_Hanghoa_Ban.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEdit_Hanghoa_Ban.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Hanghoa_Ban", "STT"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Hanghoa_Ban", "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Hanghoa_Ban", "Tên")});
            this.gridLookUpEdit_Hanghoa_Ban.DisplayMember = "Ten_Hanghoa_Ban";
            this.gridLookUpEdit_Hanghoa_Ban.Name = "gridLookUpEdit_Hanghoa_Ban";
            this.gridLookUpEdit_Hanghoa_Ban.NullText = "";
            this.gridLookUpEdit_Hanghoa_Ban.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.gridLookUpEdit_Hanghoa_Ban.ValueMember = "Id_Hanghoa_Ban";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "ĐVT TPSX";
            this.gridColumn3.FieldName = "Ten_Donvitinh_Tp";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 5;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Mã NL";
            this.gridColumn4.FieldName = "Ma_Hanghoa_Ban_Nl";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 6;
            this.gridColumn4.Width = 127;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Tên NL";
            this.gridColumn5.FieldName = "Ten_Hanghoa_Ban_Nl";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 7;
            this.gridColumn5.Width = 112;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "ĐVT NL";
            this.gridColumn6.FieldName = "Ten_Donvitinh_Nl";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 10;
            this.gridColumn6.Width = 57;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn7.Caption = "SL NL / 1 ĐV TP";
            this.gridColumn7.DisplayFormat.FormatString = "{n:###,###,###.####}";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.FieldName = "Soluong_Nl_Block_Per1Tp";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 8;
            this.gridColumn7.Width = 114;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Đơn giá mua NL";
            this.gridColumn8.DisplayFormat.FormatString = "n";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "Dongia_Mua_Nl";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Width = 122;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Đơn giá vốn TP";
            this.gridColumn9.DisplayFormat.FormatString = "n";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn9.FieldName = "Dongia_Ban_Tp";
            this.gridColumn9.GroupFormat.FormatString = "n";
            this.gridColumn9.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Dongia_Ban_Tp", "n0")});
            this.gridColumn9.Width = 157;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Loại HHSX";
            this.gridColumn10.ColumnEdit = this.gridLookUpEdit_Loai_Hanghoa_Ban;
            this.gridColumn10.FieldName = "Id_Loai_Hanghoa_Ban";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 1;
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
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Nhóm HHSX";
            this.gridColumn11.ColumnEdit = this.gridLookUpEdit_Nhom_Hanghoa_Ban;
            this.gridColumn11.FieldName = "Id_Nhom_Hanghoa_Ban";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 0;
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
            this.gridColumn12.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn12.Caption = "SL TPSX";
            this.gridColumn12.DisplayFormat.FormatString = "n";
            this.gridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn12.FieldName = "Soluong_TPKH";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn12.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 4;
            // 
            // gridColumn13
            // 
            this.gridColumn13.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn13.Caption = "SL NL";
            this.gridColumn13.DisplayFormat.FormatString = "n";
            this.gridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn13.FieldName = "Soluong_NLKH";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn13.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 9;
            // 
            // gridLookUpEdit_Donvitinh
            // 
            this.gridLookUpEdit_Donvitinh.AutoHeight = false;
            this.gridLookUpEdit_Donvitinh.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.gridLookUpEdit_Donvitinh.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Donvitinh", "STT"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Donvitinh", "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Donvitinh", "Tên")});
            this.gridLookUpEdit_Donvitinh.DisplayMember = "Ten_Donvitinh";
            this.gridLookUpEdit_Donvitinh.Name = "gridLookUpEdit_Donvitinh";
            this.gridLookUpEdit_Donvitinh.NullText = "";
            this.gridLookUpEdit_Donvitinh.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.gridLookUpEdit_Donvitinh.ValueMember = "Id_Donvitinh";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Mask.EditMask = "([1-9]\\d*([.]\\d)?\\d?)|[0]";
            this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.repositoryItemTextEdit1.Mask.ShowPlaceHolders = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // Frmware_Dm_Hanghoa_Ban_FrKhhhban
            // 
            this.AllowPrint = true;
            this.AllowQuery = true;
            this.ClientSize = new System.Drawing.Size(1131, 427);
            this.Controls.Add(this.dgware_Dm_Hanghoa_Ban);
            this.Name = "Frmware_Dm_Hanghoa_Ban_FrKhhhban";
            this.Controls.SetChildIndex(this.dgware_Dm_Hanghoa_Ban, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Hanghoa_Ban)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNguyenlieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Ma_Hanghoa_Ban)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Hanghoa_Ban)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Loai_Hanghoa_Ban)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Nhom_Hanghoa_Ban)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Donvitinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);

        }

    }
}

