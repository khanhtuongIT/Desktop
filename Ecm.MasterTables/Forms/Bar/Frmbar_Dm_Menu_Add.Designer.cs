namespace Ecm.MasterTables.Forms.Bar
{
    partial class Frmbar_Dm_Menu_Add
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
            this.dgbar_Dm_Menu = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookUpEditNhom_Hanghoa_Ban = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lookUpEdit_Nhom_Hanghoa_Ban = new DevExpress.XtraEditors.LookUpEdit();
            this.lblId_Nhom_Hanghoa_Ban = new DevExpress.XtraEditors.LabelControl();
            this.btnNhom_Hanghoa = new DevExpress.XtraEditors.SimpleButton();
            this.chkVisible = new DevExpress.XtraEditors.CheckEdit();
            this.txtGhichu = new DevExpress.XtraEditors.TextEdit();
            this.lblGhichu = new DevExpress.XtraEditors.LabelControl();
            this.txtTen_Menu = new DevExpress.XtraEditors.TextEdit();
            this.lblTen_Menu = new DevExpress.XtraEditors.LabelControl();
            this.txtMa_Menu = new DevExpress.XtraEditors.TextEdit();
            this.lblMa_Menu = new DevExpress.XtraEditors.LabelControl();
            this.xtraHNavigator1 = new GoobizFrame.Windows.Controls.XtraHNavigator();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgbar_Dm_Menu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditNhom_Hanghoa_Ban)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Nhom_Hanghoa_Ban.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVisible.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhichu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen_Menu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa_Menu.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.LookAndFeel.SkinName = "Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // dgbar_Dm_Menu
            // 
            this.dgbar_Dm_Menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgbar_Dm_Menu.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.dgbar_Dm_Menu.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.dgbar_Dm_Menu.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.dgbar_Dm_Menu.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.dgbar_Dm_Menu.EmbeddedNavigator.Buttons.First.Visible = false;
            this.dgbar_Dm_Menu.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.dgbar_Dm_Menu.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.dgbar_Dm_Menu.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.dgbar_Dm_Menu.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.dgbar_Dm_Menu.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.dgbar_Dm_Menu.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.dgbar_Dm_Menu.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
            this.dgbar_Dm_Menu.EmbeddedNavigator.TextStringFormat = "Dòng: {0} / {1}";
            this.dgbar_Dm_Menu.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dgbar_Dm_Menu_EmbeddedNavigator_ButtonClick);
            this.dgbar_Dm_Menu.Location = new System.Drawing.Point(0, 164);
            this.dgbar_Dm_Menu.MainView = this.gridView1;
            this.dgbar_Dm_Menu.Name = "dgbar_Dm_Menu";
            this.dgbar_Dm_Menu.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.gridLookUpEditNhom_Hanghoa_Ban});
            this.dgbar_Dm_Menu.Size = new System.Drawing.Size(1026, 562);
            this.dgbar_Dm_Menu.TabIndex = 1;
            this.dgbar_Dm_Menu.UseEmbeddedNavigator = true;
            this.dgbar_Dm_Menu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
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
            this.gridColumn6});
            this.gridView1.GridControl = this.dgbar_Dm_Menu;
            this.gridView1.GroupPanelText = "[Kéo một cột vào đây để nhóm]";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Số thứ tự";
            this.gridColumn1.FieldName = "Id_Menu";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Mã menu";
            this.gridColumn2.FieldName = "Ma_Menu";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Tên menu";
            this.gridColumn3.FieldName = "Ten_Menu";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Ghi chú";
            this.gridColumn4.FieldName = "Ghichu";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "Hiện menu";
            this.gridColumn5.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn5.FieldName = "Visible";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "Nhóm hàng hóa";
            this.gridColumn6.ColumnEdit = this.gridLookUpEditNhom_Hanghoa_Ban;
            this.gridColumn6.FieldName = "Id_Nhom_Hanghoa_Ban";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 93;
            // 
            // gridLookUpEditNhom_Hanghoa_Ban
            // 
            this.gridLookUpEditNhom_Hanghoa_Ban.AutoHeight = false;
            this.gridLookUpEditNhom_Hanghoa_Ban.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEditNhom_Hanghoa_Ban.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Nhom_Hanghoa_Ban", "STT", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Nhom_Hanghoa_Ban", "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Nhom_Hanghoa_Ban", "Tên")});
            this.gridLookUpEditNhom_Hanghoa_Ban.DisplayMember = "Ten_Nhom_Hanghoa_Ban";
            this.gridLookUpEditNhom_Hanghoa_Ban.Name = "gridLookUpEditNhom_Hanghoa_Ban";
            this.gridLookUpEditNhom_Hanghoa_Ban.NullText = "";
            this.gridLookUpEditNhom_Hanghoa_Ban.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.gridLookUpEditNhom_Hanghoa_Ban.ValueMember = "Id_Nhom_Hanghoa_Ban";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.tableLayoutPanel1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 65);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1026, 99);
            this.panelControl1.TabIndex = 0;
            // 
            // lookUpEdit_Nhom_Hanghoa_Ban
            // 
            this.lookUpEdit_Nhom_Hanghoa_Ban.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lookUpEdit_Nhom_Hanghoa_Ban.Location = new System.Drawing.Point(123, 3);
            this.lookUpEdit_Nhom_Hanghoa_Ban.Name = "lookUpEdit_Nhom_Hanghoa_Ban";
            this.lookUpEdit_Nhom_Hanghoa_Ban.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lookUpEdit_Nhom_Hanghoa_Ban.Properties.Appearance.Options.UseFont = true;
            this.lookUpEdit_Nhom_Hanghoa_Ban.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit_Nhom_Hanghoa_Ban.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Nhom_Hanghoa_Ban", "Stt", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Nhom_Hanghoa_Ban", "Mã nhóm HH bán"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Nhom_Hanghoa_Ban", "Tên nhóm HH bán")});
            this.lookUpEdit_Nhom_Hanghoa_Ban.Properties.DisplayMember = "Ten_Nhom_Hanghoa_Ban";
            this.lookUpEdit_Nhom_Hanghoa_Ban.Properties.NullText = "";
            this.lookUpEdit_Nhom_Hanghoa_Ban.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lookUpEdit_Nhom_Hanghoa_Ban.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit_Nhom_Hanghoa_Ban.Properties.ValueMember = "Id_Nhom_Hanghoa_Ban";
            this.lookUpEdit_Nhom_Hanghoa_Ban.Size = new System.Drawing.Size(192, 26);
            this.lookUpEdit_Nhom_Hanghoa_Ban.TabIndex = 0;
            // 
            // lblId_Nhom_Hanghoa_Ban
            // 
            this.lblId_Nhom_Hanghoa_Ban.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblId_Nhom_Hanghoa_Ban.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblId_Nhom_Hanghoa_Ban.Location = new System.Drawing.Point(3, 6);
            this.lblId_Nhom_Hanghoa_Ban.Name = "lblId_Nhom_Hanghoa_Ban";
            this.lblId_Nhom_Hanghoa_Ban.Size = new System.Drawing.Size(114, 19);
            this.lblId_Nhom_Hanghoa_Ban.TabIndex = 14;
            this.lblId_Nhom_Hanghoa_Ban.Text = "Nhóm hàng hóa";
            // 
            // btnNhom_Hanghoa
            // 
            this.btnNhom_Hanghoa.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnNhom_Hanghoa.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnNhom_Hanghoa.Appearance.Options.UseFont = true;
            this.btnNhom_Hanghoa.Appearance.Options.UseTextOptions = true;
            this.btnNhom_Hanghoa.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnNhom_Hanghoa.Location = new System.Drawing.Point(321, 3);
            this.btnNhom_Hanghoa.Name = "btnNhom_Hanghoa";
            this.btnNhom_Hanghoa.Size = new System.Drawing.Size(77, 25);
            this.btnNhom_Hanghoa.TabIndex = 5;
            this.btnNhom_Hanghoa.Text = "Thêm nhóm";
            this.btnNhom_Hanghoa.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // chkVisible
            // 
            this.chkVisible.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkVisible.Location = new System.Drawing.Point(775, 4);
            this.chkVisible.Name = "chkVisible";
            this.chkVisible.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.chkVisible.Properties.Appearance.Options.UseFont = true;
            this.chkVisible.Properties.Caption = "Hiện menu";
            this.chkVisible.Size = new System.Drawing.Size(109, 24);
            this.chkVisible.TabIndex = 4;
            // 
            // txtGhichu
            // 
            this.txtGhichu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtGhichu.Location = new System.Drawing.Point(494, 35);
            this.txtGhichu.Name = "txtGhichu";
            this.txtGhichu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtGhichu.Properties.Appearance.Options.UseFont = true;
            this.txtGhichu.Size = new System.Drawing.Size(275, 26);
            this.txtGhichu.TabIndex = 3;
            // 
            // lblGhichu
            // 
            this.lblGhichu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblGhichu.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblGhichu.Location = new System.Drawing.Point(423, 38);
            this.lblGhichu.Name = "lblGhichu";
            this.lblGhichu.Size = new System.Drawing.Size(54, 19);
            this.lblGhichu.TabIndex = 6;
            this.lblGhichu.Text = "Ghi chú";
            // 
            // txtTen_Menu
            // 
            this.txtTen_Menu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.txtTen_Menu, 2);
            this.txtTen_Menu.Location = new System.Drawing.Point(123, 35);
            this.txtTen_Menu.Name = "txtTen_Menu";
            this.txtTen_Menu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtTen_Menu.Properties.Appearance.Options.UseFont = true;
            this.txtTen_Menu.Size = new System.Drawing.Size(275, 26);
            this.txtTen_Menu.TabIndex = 2;
            // 
            // lblTen_Menu
            // 
            this.lblTen_Menu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTen_Menu.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblTen_Menu.Location = new System.Drawing.Point(3, 38);
            this.lblTen_Menu.Name = "lblTen_Menu";
            this.lblTen_Menu.Size = new System.Drawing.Size(72, 19);
            this.lblTen_Menu.TabIndex = 4;
            this.lblTen_Menu.Text = "Tên menu";
            // 
            // txtMa_Menu
            // 
            this.txtMa_Menu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtMa_Menu.Location = new System.Drawing.Point(494, 3);
            this.txtMa_Menu.Name = "txtMa_Menu";
            this.txtMa_Menu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtMa_Menu.Properties.Appearance.Options.UseFont = true;
            this.txtMa_Menu.Size = new System.Drawing.Size(275, 26);
            this.txtMa_Menu.TabIndex = 1;
            // 
            // lblMa_Menu
            // 
            this.lblMa_Menu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMa_Menu.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblMa_Menu.Location = new System.Drawing.Point(423, 6);
            this.lblMa_Menu.Name = "lblMa_Menu";
            this.lblMa_Menu.Size = new System.Drawing.Size(65, 19);
            this.lblMa_Menu.TabIndex = 2;
            this.lblMa_Menu.Text = "Mã menu";
            // 
            // xtraHNavigator1
            // 
            this.xtraHNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xtraHNavigator1.GridControl = this.dgbar_Dm_Menu;
            this.xtraHNavigator1.Location = new System.Drawing.Point(0, 726);
            this.xtraHNavigator1.Margin = new System.Windows.Forms.Padding(0);
            this.xtraHNavigator1.Name = "xtraHNavigator1";
            this.xtraHNavigator1.Size = new System.Drawing.Size(1026, 24);
            this.xtraHNavigator1.TabIndex = 4;
            this.xtraHNavigator1.TextStringFormat = "Dòng: {0} / {1}";
            this.xtraHNavigator1.VisibleFirst = true;
            this.xtraHNavigator1.VisibleLast = true;
            this.xtraHNavigator1.VisibleNext = true;
            this.xtraHNavigator1.VisiblePageNext = true;
            this.xtraHNavigator1.VisiblePagePrev = true;
            this.xtraHNavigator1.VisiblePrev = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lblId_Nhom_Hanghoa_Ban, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkVisible, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnNhom_Hanghoa, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtGhichu, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.lookUpEdit_Nhom_Hanghoa_Ban, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblGhichu, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblMa_Menu, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTen_Menu, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtMa_Menu, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTen_Menu, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1022, 95);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // Frmbar_Dm_Menu_Add
            // 
            this.AllowRefresh = true;
            this.AllowSelect = true;
            this.ClientSize = new System.Drawing.Size(1026, 750);
            this.Controls.Add(this.dgbar_Dm_Menu);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.xtraHNavigator1);
            this.EnableDelete = true;
            this.Name = "Frmbar_Dm_Menu_Add";
            this.Controls.SetChildIndex(this.xtraHNavigator1, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.dgbar_Dm_Menu, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgbar_Dm_Menu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditNhom_Hanghoa_Ban)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Nhom_Hanghoa_Ban.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVisible.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhichu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen_Menu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa_Menu.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgbar_Dm_Menu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtTen_Menu;
        private DevExpress.XtraEditors.LabelControl lblTen_Menu;
        private DevExpress.XtraEditors.TextEdit txtMa_Menu;
        private DevExpress.XtraEditors.LabelControl lblMa_Menu;
        private DevExpress.XtraEditors.TextEdit txtGhichu;
        private DevExpress.XtraEditors.LabelControl lblGhichu;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridLookUpEditNhom_Hanghoa_Ban;
        private DevExpress.XtraEditors.CheckEdit chkVisible;
        private DevExpress.XtraEditors.SimpleButton btnNhom_Hanghoa;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_Nhom_Hanghoa_Ban;
        private DevExpress.XtraEditors.LabelControl lblId_Nhom_Hanghoa_Ban;
        private  GoobizFrame.Windows.Controls.XtraHNavigator xtraHNavigator1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
