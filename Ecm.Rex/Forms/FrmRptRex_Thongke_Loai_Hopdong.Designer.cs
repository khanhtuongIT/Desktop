namespace Ecm.Rex.Forms
{
    partial class FrmRptRex_Thongke_Loai_Hopdong
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
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lbl_Ngaybatdau = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Ngayketthuc = new DevExpress.XtraEditors.LabelControl();
            this.dtNgay_Batdau = new DevExpress.XtraEditors.DateEdit();
            this.dtNgay_Ketthuc = new DevExpress.XtraEditors.DateEdit();
            this.lookUpEdit_Loai_Hopdong = new DevExpress.XtraEditors.LookUpEdit();
            this.lblLoai_Hopdong = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEdit_Bophan = new DevExpress.XtraEditors.LookUpEdit();
            this.lblBophan = new DevExpress.XtraEditors.LabelControl();
            this.dgrex_Thongke_Loai_Hopdong = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_Loai_Hopdong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Ma_Nhansu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Hoten_Nhansu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Ngay_Batdau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridDate_Ngay = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gridColumn_Ngay_Ketthuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraHNavigator1 = new GoobizFrame.Windows.Controls.XtraHNavigator();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Batdau.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Batdau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Loai_Hopdong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Bophan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrex_Thongke_Loai_Hopdong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDate_Ngay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDate_Ngay.VistaTimeProperties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.tableLayoutPanel1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 65);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1008, 57);
            this.panelControl2.TabIndex = 0;
            // 
            // lbl_Ngaybatdau
            // 
            this.lbl_Ngaybatdau.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Ngaybatdau.Location = new System.Drawing.Point(3, 6);
            this.lbl_Ngaybatdau.Name = "lbl_Ngaybatdau";
            this.lbl_Ngaybatdau.Size = new System.Drawing.Size(65, 13);
            this.lbl_Ngaybatdau.TabIndex = 28;
            this.lbl_Ngaybatdau.Text = "Ngày bắt đầu";
            // 
            // lbl_Ngayketthuc
            // 
            this.lbl_Ngayketthuc.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Ngayketthuc.Location = new System.Drawing.Point(236, 6);
            this.lbl_Ngayketthuc.Name = "lbl_Ngayketthuc";
            this.lbl_Ngayketthuc.Size = new System.Drawing.Size(67, 13);
            this.lbl_Ngayketthuc.TabIndex = 29;
            this.lbl_Ngayketthuc.Text = "Ngày kết thúc";
            // 
            // dtNgay_Batdau
            // 
            this.dtNgay_Batdau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtNgay_Batdau.EditValue = null;
            this.dtNgay_Batdau.Location = new System.Drawing.Point(74, 3);
            this.dtNgay_Batdau.MenuManager = this.barManager;
            this.dtNgay_Batdau.Name = "dtNgay_Batdau";
            this.dtNgay_Batdau.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgay_Batdau.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtNgay_Batdau.Size = new System.Drawing.Size(136, 20);
            this.dtNgay_Batdau.TabIndex = 1;
            // 
            // dtNgay_Ketthuc
            // 
            this.dtNgay_Ketthuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtNgay_Ketthuc.EditValue = null;
            this.dtNgay_Ketthuc.Location = new System.Drawing.Point(309, 3);
            this.dtNgay_Ketthuc.Name = "dtNgay_Ketthuc";
            this.dtNgay_Ketthuc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgay_Ketthuc.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtNgay_Ketthuc.Size = new System.Drawing.Size(142, 20);
            this.dtNgay_Ketthuc.TabIndex = 2;
            // 
            // lookUpEdit_Loai_Hopdong
            // 
            this.lookUpEdit_Loai_Hopdong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lookUpEdit_Loai_Hopdong.Location = new System.Drawing.Point(766, 3);
            this.lookUpEdit_Loai_Hopdong.Name = "lookUpEdit_Loai_Hopdong";
            this.lookUpEdit_Loai_Hopdong.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.lookUpEdit_Loai_Hopdong.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpEdit_Loai_Hopdong.Properties.Appearance.Options.UseFont = true;
            this.lookUpEdit_Loai_Hopdong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit_Loai_Hopdong.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Loai_Hopdong", "STT"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Loai_Hopdong", "Mã loại hợp đồng"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Loai_Hopdong", "Tên loại hợp đồng")});
            this.lookUpEdit_Loai_Hopdong.Properties.DisplayMember = "Ten_Loai_Hopdong";
            this.lookUpEdit_Loai_Hopdong.Properties.NullText = "";
            this.lookUpEdit_Loai_Hopdong.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lookUpEdit_Loai_Hopdong.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit_Loai_Hopdong.Properties.ValueMember = "Id_Loai_Hopdong";
            this.lookUpEdit_Loai_Hopdong.Size = new System.Drawing.Size(142, 19);
            this.lookUpEdit_Loai_Hopdong.TabIndex = 4;
            // 
            // lblLoai_Hopdong
            // 
            this.lblLoai_Hopdong.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLoai_Hopdong.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoai_Hopdong.Location = new System.Drawing.Point(691, 6);
            this.lblLoai_Hopdong.Name = "lblLoai_Hopdong";
            this.lblLoai_Hopdong.Size = new System.Drawing.Size(69, 13);
            this.lblLoai_Hopdong.TabIndex = 24;
            this.lblLoai_Hopdong.Text = "Loại hợp đồng";
            // 
            // lookUpEdit_Bophan
            // 
            this.lookUpEdit_Bophan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lookUpEdit_Bophan.Location = new System.Drawing.Point(523, 3);
            this.lookUpEdit_Bophan.Name = "lookUpEdit_Bophan";
            this.lookUpEdit_Bophan.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.lookUpEdit_Bophan.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpEdit_Bophan.Properties.Appearance.Options.UseFont = true;
            this.lookUpEdit_Bophan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit_Bophan.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Bophan", "STT"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Bophan", "Mã BP"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Bophan", "Tên BP")});
            this.lookUpEdit_Bophan.Properties.DisplayMember = "Ten_Bophan";
            this.lookUpEdit_Bophan.Properties.NullText = "";
            this.lookUpEdit_Bophan.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lookUpEdit_Bophan.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit_Bophan.Properties.ValueMember = "Id_Bophan";
            this.lookUpEdit_Bophan.Size = new System.Drawing.Size(142, 19);
            this.lookUpEdit_Bophan.TabIndex = 3;
            // 
            // lblBophan
            // 
            this.lblBophan.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBophan.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBophan.Location = new System.Drawing.Point(477, 6);
            this.lblBophan.Name = "lblBophan";
            this.lblBophan.Size = new System.Drawing.Size(40, 13);
            this.lblBophan.TabIndex = 22;
            this.lblBophan.Text = "Bộ phận";
            // 
            // dgrex_Thongke_Loai_Hopdong
            // 
            this.dgrex_Thongke_Loai_Hopdong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrex_Thongke_Loai_Hopdong.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.dgrex_Thongke_Loai_Hopdong.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.dgrex_Thongke_Loai_Hopdong.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.dgrex_Thongke_Loai_Hopdong.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.dgrex_Thongke_Loai_Hopdong.EmbeddedNavigator.Buttons.First.Visible = false;
            this.dgrex_Thongke_Loai_Hopdong.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.dgrex_Thongke_Loai_Hopdong.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.dgrex_Thongke_Loai_Hopdong.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.dgrex_Thongke_Loai_Hopdong.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.dgrex_Thongke_Loai_Hopdong.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.dgrex_Thongke_Loai_Hopdong.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.dgrex_Thongke_Loai_Hopdong.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
            this.dgrex_Thongke_Loai_Hopdong.EmbeddedNavigator.TextStringFormat = "{0}/{1}";
            this.dgrex_Thongke_Loai_Hopdong.Location = new System.Drawing.Point(0, 122);
            this.dgrex_Thongke_Loai_Hopdong.MainView = this.gridView1;
            this.dgrex_Thongke_Loai_Hopdong.MenuManager = this.barManager;
            this.dgrex_Thongke_Loai_Hopdong.Name = "dgrex_Thongke_Loai_Hopdong";
            this.dgrex_Thongke_Loai_Hopdong.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gridDate_Ngay});
            this.dgrex_Thongke_Loai_Hopdong.Size = new System.Drawing.Size(1008, 418);
            this.dgrex_Thongke_Loai_Hopdong.TabIndex = 10;
            this.dgrex_Thongke_Loai_Hopdong.UseEmbeddedNavigator = true;
            this.dgrex_Thongke_Loai_Hopdong.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_Loai_Hopdong,
            this.gridColumn_Ma_Nhansu,
            this.gridColumn_Hoten_Nhansu,
            this.gridColumn_Ngay_Batdau,
            this.gridColumn_Ngay_Ketthuc});
            this.gridView1.GridControl = this.dgrex_Thongke_Loai_Hopdong;
            this.gridView1.GroupCount = 1;
            this.gridView1.GroupPanelText = "[Kéo một cột vào đây để nhóm]";
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Id_Nhansu", null, "(SL = {0:#,#.#})")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn_Loai_Hopdong, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn_Loai_Hopdong
            // 
            this.gridColumn_Loai_Hopdong.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn_Loai_Hopdong.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn_Loai_Hopdong.Caption = "Loại hợp đồng";
            this.gridColumn_Loai_Hopdong.FieldName = "Ten_Loai_Hopdong";
            this.gridColumn_Loai_Hopdong.Name = "gridColumn_Loai_Hopdong";
            // 
            // gridColumn_Ma_Nhansu
            // 
            this.gridColumn_Ma_Nhansu.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn_Ma_Nhansu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn_Ma_Nhansu.Caption = "Mã nhân viên";
            this.gridColumn_Ma_Nhansu.FieldName = "Ma_Nhansu";
            this.gridColumn_Ma_Nhansu.Name = "gridColumn_Ma_Nhansu";
            this.gridColumn_Ma_Nhansu.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Id_Nhansu", "")});
            this.gridColumn_Ma_Nhansu.Visible = true;
            this.gridColumn_Ma_Nhansu.VisibleIndex = 0;
            // 
            // gridColumn_Hoten_Nhansu
            // 
            this.gridColumn_Hoten_Nhansu.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn_Hoten_Nhansu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn_Hoten_Nhansu.Caption = "Họ tên nhân viên";
            this.gridColumn_Hoten_Nhansu.FieldName = "Hoten_Nhansu";
            this.gridColumn_Hoten_Nhansu.Name = "gridColumn_Hoten_Nhansu";
            this.gridColumn_Hoten_Nhansu.Visible = true;
            this.gridColumn_Hoten_Nhansu.VisibleIndex = 1;
            // 
            // gridColumn_Ngay_Batdau
            // 
            this.gridColumn_Ngay_Batdau.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn_Ngay_Batdau.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn_Ngay_Batdau.Caption = "Ngày bắt đầu hợp đồng";
            this.gridColumn_Ngay_Batdau.ColumnEdit = this.gridDate_Ngay;
            this.gridColumn_Ngay_Batdau.FieldName = "Ngay_Batdau";
            this.gridColumn_Ngay_Batdau.Name = "gridColumn_Ngay_Batdau";
            this.gridColumn_Ngay_Batdau.Visible = true;
            this.gridColumn_Ngay_Batdau.VisibleIndex = 2;
            // 
            // gridDate_Ngay
            // 
            this.gridDate_Ngay.AutoHeight = false;
            this.gridDate_Ngay.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridDate_Ngay.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridDate_Ngay.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridDate_Ngay.EditFormat.FormatString = "dd/MM/yyyy";
            this.gridDate_Ngay.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridDate_Ngay.Mask.EditMask = "dd/MM/yyyy";
            this.gridDate_Ngay.Name = "gridDate_Ngay";
            this.gridDate_Ngay.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // gridColumn_Ngay_Ketthuc
            // 
            this.gridColumn_Ngay_Ketthuc.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn_Ngay_Ketthuc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn_Ngay_Ketthuc.Caption = "Ngày kết thúc hợp đồng";
            this.gridColumn_Ngay_Ketthuc.ColumnEdit = this.gridDate_Ngay;
            this.gridColumn_Ngay_Ketthuc.FieldName = "Ngay_Ketthuc";
            this.gridColumn_Ngay_Ketthuc.Name = "gridColumn_Ngay_Ketthuc";
            this.gridColumn_Ngay_Ketthuc.Visible = true;
            this.gridColumn_Ngay_Ketthuc.VisibleIndex = 3;
            // 
            // xtraHNavigator1
            // 
            this.xtraHNavigator1.ButtonModes = GoobizFrame.Windows.Controls.XtraHNavigator.NavigatorButtonModes.ShowNavigators;
            this.xtraHNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xtraHNavigator1.GridControl = this.dgrex_Thongke_Loai_Hopdong;
            this.xtraHNavigator1.Location = new System.Drawing.Point(0, 540);
            this.xtraHNavigator1.Margin = new System.Windows.Forms.Padding(0);
            this.xtraHNavigator1.Name = "xtraHNavigator1";
            this.xtraHNavigator1.Size = new System.Drawing.Size(1008, 32);
            this.xtraHNavigator1.TabIndex = 11;
            this.xtraHNavigator1.TextStringFormat = "{0}/{1}";
            this.xtraHNavigator1.VisibleAppend = false;
            this.xtraHNavigator1.VisibleCancelEdit = false;
            this.xtraHNavigator1.VisibleEdit = false;
            this.xtraHNavigator1.VisibleEndEdit = false;
            this.xtraHNavigator1.VisibleFirst = true;
            this.xtraHNavigator1.VisibleLast = true;
            this.xtraHNavigator1.VisibleNext = true;
            this.xtraHNavigator1.VisiblePageNext = true;
            this.xtraHNavigator1.VisiblePagePrev = true;
            this.xtraHNavigator1.VisiblePrev = true;
            this.xtraHNavigator1.VisibleRemove = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 12;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lookUpEdit_Loai_Hopdong, 10, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtNgay_Ketthuc, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblLoai_Hopdong, 9, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Ngayketthuc, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lookUpEdit_Bophan, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Ngaybatdau, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblBophan, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtNgay_Batdau, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1004, 53);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // FrmRptRex_Thongke_Loai_Hopdong
            // 
            this.AllowPrint = true;
            this.AllowQuery = true;
            this.AllowRefresh = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 572);
            this.Controls.Add(this.dgrex_Thongke_Loai_Hopdong);
            this.Controls.Add(this.xtraHNavigator1);
            this.Controls.Add(this.panelControl2);
            this.Name = "FrmRptRex_Thongke_Loai_Hopdong";
            this.Text = "FrmRptRex_Thongke_Nhansu";
            this.Controls.SetChildIndex(this.panelControl2, 0);
            this.Controls.SetChildIndex(this.xtraHNavigator1, 0);
            this.Controls.SetChildIndex(this.dgrex_Thongke_Loai_Hopdong, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Batdau.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Batdau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Loai_Hopdong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Bophan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrex_Thongke_Loai_Hopdong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDate_Ngay.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDate_Ngay)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl dgrex_Thongke_Loai_Hopdong;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Loai_Hopdong;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Ma_Nhansu;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Hoten_Nhansu;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_Loai_Hopdong;
        private DevExpress.XtraEditors.LabelControl lblLoai_Hopdong;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_Bophan;
        private DevExpress.XtraEditors.LabelControl lblBophan;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Ngay_Batdau;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Ngay_Ketthuc;
        private GoobizFrame.Windows.Controls.XtraHNavigator xtraHNavigator1;
        private DevExpress.XtraEditors.LabelControl lbl_Ngaybatdau;
        private DevExpress.XtraEditors.LabelControl lbl_Ngayketthuc;
        private DevExpress.XtraEditors.DateEdit dtNgay_Batdau;
        private DevExpress.XtraEditors.DateEdit dtNgay_Ketthuc;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit gridDate_Ngay;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

    }
}