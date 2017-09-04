namespace Ecm.MasterTables.Forms.Rex
{
    partial class Frmrex_Dm_Xa_Add
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
            this.dgrex_Dm_Xa = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookUp_Huyen = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lookUp_Huyen = new DevExpress.XtraEditors.LookUpEdit();
            this.lblId_Huyen = new DevExpress.XtraEditors.LabelControl();
            this.txtTen_Xa = new DevExpress.XtraEditors.TextEdit();
            this.lblTen_Xa = new DevExpress.XtraEditors.LabelControl();
            this.txtMa_Xa = new DevExpress.XtraEditors.TextEdit();
            this.lblMa_Xa = new DevExpress.XtraEditors.LabelControl();
            this.xtraHNavigator1 = new GoobizFrame.Windows.Controls.XtraHNavigator();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrex_Dm_Xa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUp_Huyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_Huyen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen_Xa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa_Xa.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.LookAndFeel.SkinName = "Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // dgrex_Dm_Xa
            // 
            this.dgrex_Dm_Xa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrex_Dm_Xa.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.dgrex_Dm_Xa.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.dgrex_Dm_Xa.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.dgrex_Dm_Xa.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.dgrex_Dm_Xa.EmbeddedNavigator.Buttons.First.Visible = false;
            this.dgrex_Dm_Xa.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.dgrex_Dm_Xa.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.dgrex_Dm_Xa.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.dgrex_Dm_Xa.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.dgrex_Dm_Xa.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.dgrex_Dm_Xa.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.dgrex_Dm_Xa.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
            this.dgrex_Dm_Xa.EmbeddedNavigator.TextStringFormat = "Dòng: {0} / {1}";
            this.dgrex_Dm_Xa.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dgrex_Dm_Xa_EmbeddedNavigator_ButtonClick);
            this.dgrex_Dm_Xa.Location = new System.Drawing.Point(0, 130);
            this.dgrex_Dm_Xa.MainView = this.gridView1;
            this.dgrex_Dm_Xa.Name = "dgrex_Dm_Xa";
            this.dgrex_Dm_Xa.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gridLookUp_Huyen});
            this.dgrex_Dm_Xa.Size = new System.Drawing.Size(1011, 581);
            this.dgrex_Dm_Xa.TabIndex = 1;
            this.dgrex_Dm_Xa.UseEmbeddedNavigator = true;
            this.dgrex_Dm_Xa.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gridView1.GridControl = this.dgrex_Dm_Xa;
            this.gridView1.GroupPanelText = "[Kéo một cột vào đây để nhóm]";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow_1);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Số thứ tự";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Mã xã/phường";
            this.gridColumn2.FieldName = "Ma_Xa";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Tên xã/phường";
            this.gridColumn3.FieldName = "Ten_Xa";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Huyện/quận";
            this.gridColumn4.ColumnEdit = this.gridLookUp_Huyen;
            this.gridColumn4.FieldName = "Id_Huyen";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // gridLookUp_Huyen
            // 
            this.gridLookUp_Huyen.AutoHeight = false;
            this.gridLookUp_Huyen.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUp_Huyen.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name13", "STT", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Huyen", "Mã Huyện"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Huyen", "Tên Huyện"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Tinh", "Tỉnh")});
            this.gridLookUp_Huyen.DisplayMember = "Ten_Huyen";
            this.gridLookUp_Huyen.Name = "gridLookUp_Huyen";
            this.gridLookUp_Huyen.NullText = "";
            this.gridLookUp_Huyen.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.gridLookUp_Huyen.ValueMember = "Id_Huyen";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.tableLayoutPanel1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 65);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1011, 65);
            this.panelControl1.TabIndex = 0;
            // 
            // lookUp_Huyen
            // 
            this.lookUp_Huyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lookUp_Huyen.Location = new System.Drawing.Point(770, 3);
            this.lookUp_Huyen.Name = "lookUp_Huyen";
            this.lookUp_Huyen.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lookUp_Huyen.Properties.Appearance.Options.UseFont = true;
            this.lookUp_Huyen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUp_Huyen.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Huyen", "Id_Huyen", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Huyen", "Mã Huyện"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Huyen", "Tên Huyện"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Tinh", "Tỉnh")});
            this.lookUp_Huyen.Properties.DisplayMember = "Ten_Huyen";
            this.lookUp_Huyen.Properties.NullText = "";
            this.lookUp_Huyen.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lookUp_Huyen.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUp_Huyen.Properties.ValueMember = "Id_Huyen";
            this.lookUp_Huyen.Size = new System.Drawing.Size(200, 26);
            this.lookUp_Huyen.TabIndex = 5;
            this.lookUp_Huyen.ToolTip = "Kích chuột phải thêm mới thông tin huyện";
            this.lookUp_Huyen.ToolTipController = this.toolTipController1;
            this.lookUp_Huyen.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // lblId_Huyen
            // 
            this.lblId_Huyen.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblId_Huyen.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblId_Huyen.Location = new System.Drawing.Point(678, 6);
            this.lblId_Huyen.Name = "lblId_Huyen";
            this.lblId_Huyen.Size = new System.Drawing.Size(86, 19);
            this.lblId_Huyen.TabIndex = 6;
            this.lblId_Huyen.Text = "Huyện/quận";
            // 
            // txtTen_Xa
            // 
            this.txtTen_Xa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTen_Xa.Location = new System.Drawing.Point(452, 3);
            this.txtTen_Xa.Name = "txtTen_Xa";
            this.txtTen_Xa.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtTen_Xa.Properties.Appearance.Options.UseFont = true;
            this.txtTen_Xa.Size = new System.Drawing.Size(200, 26);
            this.txtTen_Xa.TabIndex = 1;
            // 
            // lblTen_Xa
            // 
            this.lblTen_Xa.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTen_Xa.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblTen_Xa.Location = new System.Drawing.Point(337, 6);
            this.lblTen_Xa.Name = "lblTen_Xa";
            this.lblTen_Xa.Size = new System.Drawing.Size(109, 19);
            this.lblTen_Xa.TabIndex = 4;
            this.lblTen_Xa.Text = "Tên xã/phường";
            // 
            // txtMa_Xa
            // 
            this.txtMa_Xa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMa_Xa.Location = new System.Drawing.Point(111, 3);
            this.txtMa_Xa.Name = "txtMa_Xa";
            this.txtMa_Xa.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtMa_Xa.Properties.Appearance.Options.UseFont = true;
            this.txtMa_Xa.Size = new System.Drawing.Size(200, 26);
            this.txtMa_Xa.TabIndex = 0;
            this.txtMa_Xa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMa_Xa_KeyPress);
            // 
            // lblMa_Xa
            // 
            this.lblMa_Xa.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMa_Xa.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblMa_Xa.Location = new System.Drawing.Point(3, 6);
            this.lblMa_Xa.Name = "lblMa_Xa";
            this.lblMa_Xa.Size = new System.Drawing.Size(102, 19);
            this.lblMa_Xa.TabIndex = 2;
            this.lblMa_Xa.Text = "Mã xã/phường";
            // 
            // xtraHNavigator1
            // 
            this.xtraHNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xtraHNavigator1.GridControl = this.dgrex_Dm_Xa;
            this.xtraHNavigator1.Location = new System.Drawing.Point(0, 711);
            this.xtraHNavigator1.Margin = new System.Windows.Forms.Padding(0);
            this.xtraHNavigator1.Name = "xtraHNavigator1";
            this.xtraHNavigator1.Size = new System.Drawing.Size(1011, 24);
            this.xtraHNavigator1.TabIndex = 9;
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
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lblMa_Xa, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblId_Huyen, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.lookUp_Huyen, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTen_Xa, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtMa_Xa, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTen_Xa, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1007, 61);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // Frmrex_Dm_Xa_Add
            // 
            this.AllowRefresh = true;
            this.ClientSize = new System.Drawing.Size(1011, 735);
            this.Controls.Add(this.dgrex_Dm_Xa);
            this.Controls.Add(this.xtraHNavigator1);
            this.Controls.Add(this.panelControl1);
            this.Name = "Frmrex_Dm_Xa_Add";
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.xtraHNavigator1, 0);
            this.Controls.SetChildIndex(this.dgrex_Dm_Xa, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrex_Dm_Xa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUp_Huyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_Huyen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen_Xa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa_Xa.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgrex_Dm_Xa;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtTen_Xa;
        private DevExpress.XtraEditors.LabelControl lblTen_Xa;
        private DevExpress.XtraEditors.TextEdit txtMa_Xa;
        private DevExpress.XtraEditors.LabelControl lblMa_Xa;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridLookUp_Huyen;
        private DevExpress.XtraEditors.LookUpEdit lookUp_Huyen;
        private DevExpress.XtraEditors.LabelControl lblId_Huyen;
        private  GoobizFrame.Windows.Controls.XtraHNavigator xtraHNavigator1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
