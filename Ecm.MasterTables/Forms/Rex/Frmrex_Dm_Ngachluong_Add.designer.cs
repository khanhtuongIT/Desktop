namespace Ecm.MasterTables.Forms.Rex
{
    partial class Frmrex_Dm_Ngachluong_Add
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
            this.dgrex_Dm_Ngachluong = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtTen_Ngachluong = new DevExpress.XtraEditors.TextEdit();
            this.txtMa_Ngachluong = new DevExpress.XtraEditors.TextEdit();
            this.txtId_Ngachluong = new DevExpress.XtraEditors.TextEdit();
            this.lblTen_Ngachluong = new DevExpress.XtraEditors.LabelControl();
            this.lblMa_Ngachluong = new DevExpress.XtraEditors.LabelControl();
            this.lblId_Ngachluong = new DevExpress.XtraEditors.LabelControl();
            this.xtraHNavigator1 = new GoobizFrame.Windows.Controls.XtraHNavigator();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrex_Dm_Ngachluong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen_Ngachluong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa_Ngachluong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId_Ngachluong.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.LookAndFeel.SkinName = "Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // dgrex_Dm_Ngachluong
            // 
            this.dgrex_Dm_Ngachluong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrex_Dm_Ngachluong.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.dgrex_Dm_Ngachluong.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.dgrex_Dm_Ngachluong.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.dgrex_Dm_Ngachluong.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.dgrex_Dm_Ngachluong.EmbeddedNavigator.Buttons.First.Visible = false;
            this.dgrex_Dm_Ngachluong.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.dgrex_Dm_Ngachluong.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.dgrex_Dm_Ngachluong.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.dgrex_Dm_Ngachluong.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.dgrex_Dm_Ngachluong.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.dgrex_Dm_Ngachluong.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.dgrex_Dm_Ngachluong.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
            this.dgrex_Dm_Ngachluong.EmbeddedNavigator.TextStringFormat = "Dòng : {0}/ {1}";
            this.dgrex_Dm_Ngachluong.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dgrex_Dm_Ngachluong_EmbeddedNavigator_ButtonClick);
            this.dgrex_Dm_Ngachluong.Location = new System.Drawing.Point(0, 130);
            this.dgrex_Dm_Ngachluong.MainView = this.gridView1;
            this.dgrex_Dm_Ngachluong.Name = "dgrex_Dm_Ngachluong";
            this.dgrex_Dm_Ngachluong.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.repositoryItemLookUpEdit2,
            this.repositoryItemMemoEdit1});
            this.dgrex_Dm_Ngachluong.Size = new System.Drawing.Size(1011, 581);
            this.dgrex_Dm_Ngachluong.TabIndex = 1;
            this.dgrex_Dm_Ngachluong.UseEmbeddedNavigator = true;
            this.dgrex_Dm_Ngachluong.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.GridControl = this.dgrex_Dm_Ngachluong;
            this.gridView1.GroupPanelText = "[Kéo một cột vào đây để nhóm]";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "STT";
            this.gridColumn1.FieldName = "Id_Ngachluong";
            this.gridColumn1.MinWidth = 50;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Width = 105;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Mã ngạch lương";
            this.gridColumn2.FieldName = "Ma_Ngachluong";
            this.gridColumn2.MinWidth = 165;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 176;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Tên ngạch lương";
            this.gridColumn3.ColumnEdit = this.repositoryItemMemoEdit1;
            this.gridColumn3.FieldName = "Ten_Ngachluong";
            this.gridColumn3.MinWidth = 165;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 174;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.tableLayoutPanel1);
            this.panelControl2.Controls.Add(this.txtId_Ngachluong);
            this.panelControl2.Controls.Add(this.lblId_Ngachluong);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 65);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1011, 65);
            this.panelControl2.TabIndex = 0;
            // 
            // txtTen_Ngachluong
            // 
            this.txtTen_Ngachluong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTen_Ngachluong.Location = new System.Drawing.Point(574, 3);
            this.txtTen_Ngachluong.Name = "txtTen_Ngachluong";
            this.txtTen_Ngachluong.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtTen_Ngachluong.Properties.Appearance.Options.UseFont = true;
            this.txtTen_Ngachluong.Size = new System.Drawing.Size(300, 26);
            this.txtTen_Ngachluong.TabIndex = 1;
            // 
            // txtMa_Ngachluong
            // 
            this.txtMa_Ngachluong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMa_Ngachluong.Location = new System.Drawing.Point(122, 3);
            this.txtMa_Ngachluong.Name = "txtMa_Ngachluong";
            this.txtMa_Ngachluong.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtMa_Ngachluong.Properties.Appearance.Options.UseFont = true;
            this.txtMa_Ngachluong.Size = new System.Drawing.Size(300, 26);
            this.txtMa_Ngachluong.TabIndex = 0;
            this.txtMa_Ngachluong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMa_Ngachluong_KeyPress);
            // 
            // txtId_Ngachluong
            // 
            this.txtId_Ngachluong.Enabled = false;
            this.txtId_Ngachluong.Location = new System.Drawing.Point(992, 19);
            this.txtId_Ngachluong.Name = "txtId_Ngachluong";
            this.txtId_Ngachluong.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtId_Ngachluong.Properties.Appearance.Options.UseFont = true;
            this.txtId_Ngachluong.Size = new System.Drawing.Size(100, 26);
            this.txtId_Ngachluong.TabIndex = 0;
            this.txtId_Ngachluong.Visible = false;
            // 
            // lblTen_Ngachluong
            // 
            this.lblTen_Ngachluong.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTen_Ngachluong.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblTen_Ngachluong.Location = new System.Drawing.Point(448, 6);
            this.lblTen_Ngachluong.Name = "lblTen_Ngachluong";
            this.lblTen_Ngachluong.Size = new System.Drawing.Size(120, 19);
            this.lblTen_Ngachluong.TabIndex = 6;
            this.lblTen_Ngachluong.Text = "Tên ngạch lương";
            // 
            // lblMa_Ngachluong
            // 
            this.lblMa_Ngachluong.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMa_Ngachluong.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblMa_Ngachluong.Location = new System.Drawing.Point(3, 6);
            this.lblMa_Ngachluong.Name = "lblMa_Ngachluong";
            this.lblMa_Ngachluong.Size = new System.Drawing.Size(113, 19);
            this.lblMa_Ngachluong.TabIndex = 4;
            this.lblMa_Ngachluong.Text = "Mã ngạch lương";
            // 
            // lblId_Ngachluong
            // 
            this.lblId_Ngachluong.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblId_Ngachluong.Location = new System.Drawing.Point(919, 23);
            this.lblId_Ngachluong.Name = "lblId_Ngachluong";
            this.lblId_Ngachluong.Size = new System.Drawing.Size(67, 19);
            this.lblId_Ngachluong.TabIndex = 0;
            this.lblId_Ngachluong.Text = "Số thự tự";
            this.lblId_Ngachluong.Visible = false;
            // 
            // xtraHNavigator1
            // 
            this.xtraHNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xtraHNavigator1.GridControl = this.dgrex_Dm_Ngachluong;
            this.xtraHNavigator1.Location = new System.Drawing.Point(0, 711);
            this.xtraHNavigator1.Margin = new System.Windows.Forms.Padding(0);
            this.xtraHNavigator1.Name = "xtraHNavigator1";
            this.xtraHNavigator1.Size = new System.Drawing.Size(1011, 24);
            this.xtraHNavigator1.TabIndex = 9;
            this.xtraHNavigator1.TextStringFormat = "Dòng : {0}/ {1}";
            this.xtraHNavigator1.VisibleFirst = true;
            this.xtraHNavigator1.VisibleLast = true;
            this.xtraHNavigator1.VisibleNext = true;
            this.xtraHNavigator1.VisiblePageNext = true;
            this.xtraHNavigator1.VisiblePagePrev = true;
            this.xtraHNavigator1.VisiblePrev = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lblMa_Ngachluong, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTen_Ngachluong, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtMa_Ngachluong, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTen_Ngachluong, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1007, 61);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // Frmrex_Dm_Ngachluong_Add
            // 
            this.AllowRefresh = true;
            this.ClientSize = new System.Drawing.Size(1011, 735);
            this.Controls.Add(this.dgrex_Dm_Ngachluong);
            this.Controls.Add(this.xtraHNavigator1);
            this.Controls.Add(this.panelControl2);
            this.Name = "Frmrex_Dm_Ngachluong_Add";
            this.Controls.SetChildIndex(this.panelControl2, 0);
            this.Controls.SetChildIndex(this.xtraHNavigator1, 0);
            this.Controls.SetChildIndex(this.dgrex_Dm_Ngachluong, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrex_Dm_Ngachluong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen_Ngachluong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa_Ngachluong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId_Ngachluong.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgrex_Dm_Ngachluong;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl lblTen_Ngachluong;
        private DevExpress.XtraEditors.LabelControl lblMa_Ngachluong;
        private DevExpress.XtraEditors.LabelControl lblId_Ngachluong;
        private DevExpress.XtraEditors.TextEdit txtTen_Ngachluong;
        private DevExpress.XtraEditors.TextEdit txtMa_Ngachluong;
        private DevExpress.XtraEditors.TextEdit txtId_Ngachluong;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private  GoobizFrame.Windows.Controls.XtraHNavigator xtraHNavigator1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
