namespace Ecm.Rex.Forms
{
    partial class Frmrex_Nhansu_Import
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tabNhansu_Imp = new DevExpress.XtraTab.XtraTabControl();
            this.tabNhansu_Excel = new DevExpress.XtraTab.XtraTabPage();
            this.dgNhansu_Excel = new DevExpress.XtraGrid.GridControl();
            this.gvNhansu_Excel = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraHNavigator1 = new GoobizFrame.Windows.Controls.XtraHNavigator();
            this.tabNhansu_ImpMap = new DevExpress.XtraTab.XtraTabPage();
            this.dgNhansu_ImpMap = new DevExpress.XtraGrid.GridControl();
            this.gvNhansu_ImpMap = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridComboBox_Nhansu_Excel = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.xtraHNavigator2 = new GoobizFrame.Windows.Controls.XtraHNavigator();
            this.btnSave_Heso_Chuongtrinh = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnFillFromFile = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lblId_Bophan = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEdit_Bophan = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEdit_Bophan1 = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tabNhansu_Imp)).BeginInit();
            this.tabNhansu_Imp.SuspendLayout();
            this.tabNhansu_Excel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgNhansu_Excel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNhansu_Excel)).BeginInit();
            this.tabNhansu_ImpMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgNhansu_ImpMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNhansu_ImpMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridComboBox_Nhansu_Excel)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Bophan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Bophan1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tabNhansu_Imp
            // 
            this.tabNhansu_Imp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabNhansu_Imp.Location = new System.Drawing.Point(0, 33);
            this.tabNhansu_Imp.Name = "tabNhansu_Imp";
            this.tabNhansu_Imp.SelectedTabPage = this.tabNhansu_Excel;
            this.tabNhansu_Imp.Size = new System.Drawing.Size(836, 448);
            this.tabNhansu_Imp.TabIndex = 0;
            this.tabNhansu_Imp.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabNhansu_Excel,
            this.tabNhansu_ImpMap});
            // 
            // tabNhansu_Excel
            // 
            this.tabNhansu_Excel.Controls.Add(this.dgNhansu_Excel);
            this.tabNhansu_Excel.Controls.Add(this.xtraHNavigator1);
            this.tabNhansu_Excel.Name = "tabNhansu_Excel";
            this.tabNhansu_Excel.Size = new System.Drawing.Size(830, 422);
            this.tabNhansu_Excel.Text = "Danh sách nhân sự từ tập tin";
            // 
            // dgNhansu_Excel
            // 
            this.dgNhansu_Excel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgNhansu_Excel.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.dgNhansu_Excel.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.dgNhansu_Excel.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.dgNhansu_Excel.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.dgNhansu_Excel.EmbeddedNavigator.Buttons.First.Visible = false;
            this.dgNhansu_Excel.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.dgNhansu_Excel.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.dgNhansu_Excel.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.dgNhansu_Excel.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.dgNhansu_Excel.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.dgNhansu_Excel.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.dgNhansu_Excel.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
            this.dgNhansu_Excel.EmbeddedNavigator.TextStringFormat = "{0} / {1}";
            this.dgNhansu_Excel.Location = new System.Drawing.Point(0, 0);
            this.dgNhansu_Excel.MainView = this.gvNhansu_Excel;
            this.dgNhansu_Excel.Name = "dgNhansu_Excel";
            this.dgNhansu_Excel.Size = new System.Drawing.Size(830, 400);
            this.dgNhansu_Excel.TabIndex = 0;
            this.dgNhansu_Excel.UseEmbeddedNavigator = true;
            this.dgNhansu_Excel.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNhansu_Excel});
            // 
            // gvNhansu_Excel
            // 
            this.gvNhansu_Excel.GridControl = this.dgNhansu_Excel;
            this.gvNhansu_Excel.Name = "gvNhansu_Excel";
            this.gvNhansu_Excel.OptionsBehavior.Editable = false;
            this.gvNhansu_Excel.OptionsView.ShowGroupedColumns = true;
            this.gvNhansu_Excel.OptionsView.ShowGroupPanel = false;
            // 
            // xtraHNavigator1
            // 
            this.xtraHNavigator1.ButtonModes = GoobizFrame.Windows.Controls.XtraHNavigator.NavigatorButtonModes.ShowNavigators;
            this.xtraHNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xtraHNavigator1.GridControl = this.dgNhansu_Excel;
            this.xtraHNavigator1.Location = new System.Drawing.Point(0, 400);
            this.xtraHNavigator1.Margin = new System.Windows.Forms.Padding(0);
            this.xtraHNavigator1.Name = "xtraHNavigator1";
            this.xtraHNavigator1.Size = new System.Drawing.Size(830, 22);
            this.xtraHNavigator1.TabIndex = 115;
            this.xtraHNavigator1.TextStringFormat = "{0} / {1}";
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
            // tabNhansu_ImpMap
            // 
            this.tabNhansu_ImpMap.Controls.Add(this.dgNhansu_ImpMap);
            this.tabNhansu_ImpMap.Controls.Add(this.tableLayoutPanel2);
            this.tabNhansu_ImpMap.Name = "tabNhansu_ImpMap";
            this.tabNhansu_ImpMap.Size = new System.Drawing.Size(830, 422);
            this.tabNhansu_ImpMap.Text = "Bảng ánh xạ";
            // 
            // dgNhansu_ImpMap
            // 
            this.dgNhansu_ImpMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgNhansu_ImpMap.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.dgNhansu_ImpMap.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.dgNhansu_ImpMap.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.dgNhansu_ImpMap.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.dgNhansu_ImpMap.EmbeddedNavigator.Buttons.First.Visible = false;
            this.dgNhansu_ImpMap.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.dgNhansu_ImpMap.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.dgNhansu_ImpMap.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.dgNhansu_ImpMap.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.dgNhansu_ImpMap.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.dgNhansu_ImpMap.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.dgNhansu_ImpMap.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
            this.dgNhansu_ImpMap.EmbeddedNavigator.TextStringFormat = "{0} / {1}";
            this.dgNhansu_ImpMap.Location = new System.Drawing.Point(0, 0);
            this.dgNhansu_ImpMap.MainView = this.gvNhansu_ImpMap;
            this.dgNhansu_ImpMap.Name = "dgNhansu_ImpMap";
            this.dgNhansu_ImpMap.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gridComboBox_Nhansu_Excel});
            this.dgNhansu_ImpMap.Size = new System.Drawing.Size(830, 394);
            this.dgNhansu_ImpMap.TabIndex = 116;
            this.dgNhansu_ImpMap.UseEmbeddedNavigator = true;
            this.dgNhansu_ImpMap.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNhansu_ImpMap});
            // 
            // gvNhansu_ImpMap
            // 
            this.gvNhansu_ImpMap.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gvNhansu_ImpMap.GridControl = this.dgNhansu_ImpMap;
            this.gvNhansu_ImpMap.Name = "gvNhansu_ImpMap";
            this.gvNhansu_ImpMap.OptionsView.ShowGroupedColumns = true;
            this.gvNhansu_ImpMap.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id_Heso_Chuongtrinh";
            this.gridColumn1.FieldName = "Id_Heso_Chuongtrinh";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên trường DL";
            this.gridColumn2.FieldName = "Ma_Heso_Chuongtrinh";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Mô tả";
            this.gridColumn3.FieldName = "Ten_Heso_Chuongtrinh";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Nhóm";
            this.gridColumn4.FieldName = "Nhom_Heso_Chuongtrinh";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Tên cột Excel";
            this.gridColumn5.ColumnEdit = this.gridComboBox_Nhansu_Excel;
            this.gridColumn5.FieldName = "Heso";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            // 
            // gridComboBox_Nhansu_Excel
            // 
            this.gridComboBox_Nhansu_Excel.AutoHeight = false;
            this.gridComboBox_Nhansu_Excel.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridComboBox_Nhansu_Excel.Name = "gridComboBox_Nhansu_Excel";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.xtraHNavigator2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSave_Heso_Chuongtrinh, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 394);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(830, 28);
            this.tableLayoutPanel2.TabIndex = 118;
            // 
            // xtraHNavigator2
            // 
            this.xtraHNavigator2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraHNavigator2.ButtonModes = GoobizFrame.Windows.Controls.XtraHNavigator.NavigatorButtonModes.ShowNavigators;
            this.xtraHNavigator2.GridControl = this.dgNhansu_ImpMap;
            this.xtraHNavigator2.Location = new System.Drawing.Point(0, 0);
            this.xtraHNavigator2.Margin = new System.Windows.Forms.Padding(0);
            this.xtraHNavigator2.Name = "xtraHNavigator2";
            this.xtraHNavigator2.Size = new System.Drawing.Size(710, 22);
            this.xtraHNavigator2.TabIndex = 118;
            this.xtraHNavigator2.TextStringFormat = "{0} / {1}";
            this.xtraHNavigator2.VisibleAppend = false;
            this.xtraHNavigator2.VisibleCancelEdit = false;
            this.xtraHNavigator2.VisibleEdit = false;
            this.xtraHNavigator2.VisibleEndEdit = false;
            this.xtraHNavigator2.VisibleFirst = true;
            this.xtraHNavigator2.VisibleLast = true;
            this.xtraHNavigator2.VisibleNext = true;
            this.xtraHNavigator2.VisiblePageNext = true;
            this.xtraHNavigator2.VisiblePagePrev = true;
            this.xtraHNavigator2.VisiblePrev = true;
            this.xtraHNavigator2.VisibleRemove = false;
            // 
            // btnSave_Heso_Chuongtrinh
            // 
            this.btnSave_Heso_Chuongtrinh.Location = new System.Drawing.Point(713, 3);
            this.btnSave_Heso_Chuongtrinh.Name = "btnSave_Heso_Chuongtrinh";
            this.btnSave_Heso_Chuongtrinh.Size = new System.Drawing.Size(114, 23);
            this.btnSave_Heso_Chuongtrinh.TabIndex = 119;
            this.btnSave_Heso_Chuongtrinh.Text = "Lưu bảng ánh xạ";
            this.btnSave_Heso_Chuongtrinh.Click += new System.EventHandler(this.btnSave_Heso_Chuongtrinh_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnFillFromFile, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnOK, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblId_Bophan, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lookUpEdit_Bophan, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lookUpEdit_Bophan1, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(836, 33);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnFillFromFile
            // 
            this.btnFillFromFile.Location = new System.Drawing.Point(563, 3);
            this.btnFillFromFile.Name = "btnFillFromFile";
            this.btnFillFromFile.Size = new System.Drawing.Size(108, 20);
            this.btnFillFromFile.TabIndex = 2;
            this.btnFillFromFile.Text = "Chọn NV từ tập tin";
            this.btnFillFromFile.Click += new System.EventHandler(this.btnFillFromFile_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(677, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 20);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "Đồng ý";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(758, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 20);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Kết thúc";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblId_Bophan
            // 
            this.lblId_Bophan.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblId_Bophan.Location = new System.Drawing.Point(3, 6);
            this.lblId_Bophan.Name = "lblId_Bophan";
            this.lblId_Bophan.Size = new System.Drawing.Size(39, 13);
            this.lblId_Bophan.TabIndex = 57;
            this.lblId_Bophan.Text = "Bộ phận";
            // 
            // lookUpEdit_Bophan
            // 
            this.lookUpEdit_Bophan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lookUpEdit_Bophan.Location = new System.Drawing.Point(48, 3);
            this.lookUpEdit_Bophan.Name = "lookUpEdit_Bophan";
            this.lookUpEdit_Bophan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.lookUpEdit_Bophan.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Bophan", "Stt"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Bophan", 50, "Mã bộ phận"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Bophan", 100, "Tên bộ phận")});
            this.lookUpEdit_Bophan.Properties.DisplayMember = "Ma_Bophan";
            this.lookUpEdit_Bophan.Properties.NullText = "";
            this.lookUpEdit_Bophan.Properties.ReadOnly = true;
            this.lookUpEdit_Bophan.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lookUpEdit_Bophan.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit_Bophan.Properties.ValueMember = "Id_Bophan";
            this.lookUpEdit_Bophan.Size = new System.Drawing.Size(179, 20);
            this.lookUpEdit_Bophan.TabIndex = 55;
            this.lookUpEdit_Bophan.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // lookUpEdit_Bophan1
            // 
            this.lookUpEdit_Bophan1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lookUpEdit_Bophan1.Location = new System.Drawing.Point(233, 3);
            this.lookUpEdit_Bophan1.Name = "lookUpEdit_Bophan1";
            this.lookUpEdit_Bophan1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.lookUpEdit_Bophan1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Bophan", "Stt"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Bophan", 50, "Mã bộ phận"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Bophan", 100, "Tên bộ phận")});
            this.lookUpEdit_Bophan1.Properties.DisplayMember = "Ten_Bophan";
            this.lookUpEdit_Bophan1.Properties.NullText = "";
            this.lookUpEdit_Bophan1.Properties.ReadOnly = true;
            this.lookUpEdit_Bophan1.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lookUpEdit_Bophan1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit_Bophan1.Properties.ValueMember = "Id_Bophan";
            this.lookUpEdit_Bophan1.Size = new System.Drawing.Size(324, 20);
            this.lookUpEdit_Bophan1.TabIndex = 56;
            this.lookUpEdit_Bophan1.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // Frmrex_Nhansu_Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 481);
            this.Controls.Add(this.tabNhansu_Imp);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Frmrex_Nhansu_Import";
            this.Text = "Nhập DS CBNV từ tập tin";
            ((System.ComponentModel.ISupportInitialize)(this.tabNhansu_Imp)).EndInit();
            this.tabNhansu_Imp.ResumeLayout(false);
            this.tabNhansu_Excel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgNhansu_Excel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNhansu_Excel)).EndInit();
            this.tabNhansu_ImpMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgNhansu_ImpMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNhansu_ImpMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridComboBox_Nhansu_Excel)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Bophan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Bophan1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabNhansu_Imp;
        private DevExpress.XtraTab.XtraTabPage tabNhansu_Excel;
        private DevExpress.XtraTab.XtraTabPage tabNhansu_ImpMap;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnFillFromFile;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraGrid.GridControl dgNhansu_Excel;
        private DevExpress.XtraGrid.Views.Grid.GridView gvNhansu_Excel;
        private GoobizFrame.Windows.Controls.XtraHNavigator xtraHNavigator1;
        private DevExpress.XtraGrid.GridControl dgNhansu_ImpMap;
        private DevExpress.XtraGrid.Views.Grid.GridView gvNhansu_ImpMap;
        private DevExpress.XtraEditors.LabelControl lblId_Bophan;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_Bophan;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_Bophan1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox gridComboBox_Nhansu_Excel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private GoobizFrame.Windows.Controls.XtraHNavigator xtraHNavigator2;
        private DevExpress.XtraEditors.SimpleButton btnSave_Heso_Chuongtrinh;
    }
}