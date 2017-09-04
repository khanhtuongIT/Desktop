namespace Ecm.MasterTables.Forms.Ware
{
    partial class Frmware_Dm_Nganhang_Add
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
            this.dgware_Dm_Nganhang = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridText_Dienthoai = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMa_Nganhang = new DevExpress.XtraEditors.LabelControl();
            this.txtDienthoai = new DevExpress.XtraEditors.TextEdit();
            this.txtMa_Nganhang = new DevExpress.XtraEditors.TextEdit();
            this.lblDienthoai = new DevExpress.XtraEditors.LabelControl();
            this.lblDiachi = new DevExpress.XtraEditors.LabelControl();
            this.txtTen_Nganhang = new DevExpress.XtraEditors.TextEdit();
            this.txtDiachi = new DevExpress.XtraEditors.TextEdit();
            this.lblTen_Nganhang = new DevExpress.XtraEditors.LabelControl();
            this.txtId_Nganhang = new DevExpress.XtraEditors.TextEdit();
            this.lblId_Nganhang = new DevExpress.XtraEditors.LabelControl();
            this.xtraHNavigator1 = new GoobizFrame.Windows.Controls.XtraHNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Nganhang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridText_Dienthoai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienthoai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa_Nganhang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen_Nganhang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiachi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId_Nganhang.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.LookAndFeel.SkinName = "Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // dgware_Dm_Nganhang
            // 
            this.dgware_Dm_Nganhang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgware_Dm_Nganhang.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.dgware_Dm_Nganhang.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.dgware_Dm_Nganhang.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.dgware_Dm_Nganhang.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.dgware_Dm_Nganhang.EmbeddedNavigator.Buttons.First.Visible = false;
            this.dgware_Dm_Nganhang.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.dgware_Dm_Nganhang.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.dgware_Dm_Nganhang.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.dgware_Dm_Nganhang.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.dgware_Dm_Nganhang.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.dgware_Dm_Nganhang.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.dgware_Dm_Nganhang.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
            this.dgware_Dm_Nganhang.EmbeddedNavigator.TextStringFormat = "Dòng : {0}/ {1}";
            this.dgware_Dm_Nganhang.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dgware_Dm_Nganhang_EmbeddedNavigator_ButtonClick);
            this.dgware_Dm_Nganhang.Location = new System.Drawing.Point(0, 154);
            this.dgware_Dm_Nganhang.MainView = this.gridView1;
            this.dgware_Dm_Nganhang.Name = "dgware_Dm_Nganhang";
            this.dgware_Dm_Nganhang.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gridText_Dienthoai,
            this.repositoryItemMemoEdit1,
            this.repositoryItemMemoEdit2});
            this.dgware_Dm_Nganhang.Size = new System.Drawing.Size(1008, 571);
            this.dgware_Dm_Nganhang.TabIndex = 1;
            this.dgware_Dm_Nganhang.UseEmbeddedNavigator = true;
            this.dgware_Dm_Nganhang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gridView1.GridControl = this.dgware_Dm_Nganhang;
            this.gridView1.GroupPanelText = "[Kéo một cột vào đây để nhóm]";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "STT";
            this.gridColumn1.FieldName = "Id_Nganhang";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Width = 67;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Mã ngân hàng";
            this.gridColumn2.FieldName = "Ma_Nganhang";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 134;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Tên ngân hàng";
            this.gridColumn3.ColumnEdit = this.repositoryItemMemoEdit1;
            this.gridColumn3.FieldName = "Ten_Nganhang";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 223;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Địa chỉ";
            this.gridColumn4.ColumnEdit = this.repositoryItemMemoEdit2;
            this.gridColumn4.FieldName = "Diachi";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 218;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "Điện thoại";
            this.gridColumn5.ColumnEdit = this.gridText_Dienthoai;
            this.gridColumn5.FieldName = "Dienthoai";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 122;
            // 
            // gridText_Dienthoai
            // 
            this.gridText_Dienthoai.AutoHeight = false;
            this.gridText_Dienthoai.Mask.EditMask = "[+|(]?[0-9]+[)]?([.|-]?[\\(0-9\\)]+)+";
            this.gridText_Dienthoai.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.gridText_Dienthoai.Mask.ShowPlaceHolders = false;
            this.gridText_Dienthoai.Name = "gridText_Dienthoai";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.tableLayoutPanel1);
            this.panelControl2.Controls.Add(this.txtId_Nganhang);
            this.panelControl2.Controls.Add(this.lblId_Nganhang);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 65);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1008, 89);
            this.panelControl2.TabIndex = 0;
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
            this.tableLayoutPanel1.Controls.Add(this.lblMa_Nganhang, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDienthoai, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtMa_Nganhang, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDienthoai, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDiachi, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTen_Nganhang, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDiachi, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTen_Nganhang, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1004, 85);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // lblMa_Nganhang
            // 
            this.lblMa_Nganhang.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMa_Nganhang.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblMa_Nganhang.Location = new System.Drawing.Point(3, 6);
            this.lblMa_Nganhang.Name = "lblMa_Nganhang";
            this.lblMa_Nganhang.Size = new System.Drawing.Size(100, 19);
            this.lblMa_Nganhang.TabIndex = 2;
            this.lblMa_Nganhang.Text = "Mã ngân hàng";
            // 
            // txtDienthoai
            // 
            this.txtDienthoai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDienthoai.Location = new System.Drawing.Point(548, 35);
            this.txtDienthoai.Name = "txtDienthoai";
            this.txtDienthoai.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtDienthoai.Properties.Appearance.Options.UseFont = true;
            this.txtDienthoai.Properties.Mask.EditMask = "[+|(]?[0-9]+[)]?([.|-]?[\\(0-9\\)]+)+";
            this.txtDienthoai.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtDienthoai.Properties.Mask.ShowPlaceHolders = false;
            this.txtDienthoai.Size = new System.Drawing.Size(300, 26);
            this.txtDienthoai.TabIndex = 4;
            // 
            // txtMa_Nganhang
            // 
            this.txtMa_Nganhang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMa_Nganhang.Location = new System.Drawing.Point(109, 3);
            this.txtMa_Nganhang.Name = "txtMa_Nganhang";
            this.txtMa_Nganhang.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtMa_Nganhang.Properties.Appearance.Options.UseFont = true;
            this.txtMa_Nganhang.Size = new System.Drawing.Size(300, 26);
            this.txtMa_Nganhang.TabIndex = 1;
            // 
            // lblDienthoai
            // 
            this.lblDienthoai.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDienthoai.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblDienthoai.Location = new System.Drawing.Point(435, 38);
            this.lblDienthoai.Name = "lblDienthoai";
            this.lblDienthoai.Size = new System.Drawing.Size(72, 19);
            this.lblDienthoai.TabIndex = 12;
            this.lblDienthoai.Text = "Điện thoại";
            // 
            // lblDiachi
            // 
            this.lblDiachi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDiachi.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblDiachi.Location = new System.Drawing.Point(3, 38);
            this.lblDiachi.Name = "lblDiachi";
            this.lblDiachi.Size = new System.Drawing.Size(48, 19);
            this.lblDiachi.TabIndex = 10;
            this.lblDiachi.Text = "Địa chỉ";
            // 
            // txtTen_Nganhang
            // 
            this.txtTen_Nganhang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTen_Nganhang.Location = new System.Drawing.Point(548, 3);
            this.txtTen_Nganhang.Name = "txtTen_Nganhang";
            this.txtTen_Nganhang.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtTen_Nganhang.Properties.Appearance.Options.UseFont = true;
            this.txtTen_Nganhang.Size = new System.Drawing.Size(300, 26);
            this.txtTen_Nganhang.TabIndex = 2;
            // 
            // txtDiachi
            // 
            this.txtDiachi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDiachi.Location = new System.Drawing.Point(109, 35);
            this.txtDiachi.Name = "txtDiachi";
            this.txtDiachi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtDiachi.Properties.Appearance.Options.UseFont = true;
            this.txtDiachi.Size = new System.Drawing.Size(300, 26);
            this.txtDiachi.TabIndex = 3;
            // 
            // lblTen_Nganhang
            // 
            this.lblTen_Nganhang.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTen_Nganhang.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblTen_Nganhang.Location = new System.Drawing.Point(435, 6);
            this.lblTen_Nganhang.Name = "lblTen_Nganhang";
            this.lblTen_Nganhang.Size = new System.Drawing.Size(107, 19);
            this.lblTen_Nganhang.TabIndex = 4;
            this.lblTen_Nganhang.Text = "Tên ngân hàng";
            // 
            // txtId_Nganhang
            // 
            this.txtId_Nganhang.Enabled = false;
            this.txtId_Nganhang.Location = new System.Drawing.Point(765, 13);
            this.txtId_Nganhang.Name = "txtId_Nganhang";
            this.txtId_Nganhang.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtId_Nganhang.Properties.Appearance.Options.UseFont = true;
            this.txtId_Nganhang.Size = new System.Drawing.Size(67, 26);
            this.txtId_Nganhang.TabIndex = 0;
            this.txtId_Nganhang.Visible = false;
            // 
            // lblId_Nganhang
            // 
            this.lblId_Nganhang.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblId_Nganhang.Location = new System.Drawing.Point(692, 17);
            this.lblId_Nganhang.Name = "lblId_Nganhang";
            this.lblId_Nganhang.Size = new System.Drawing.Size(68, 19);
            this.lblId_Nganhang.TabIndex = 0;
            this.lblId_Nganhang.Text = "Số thứ tự";
            this.lblId_Nganhang.Visible = false;
            // 
            // xtraHNavigator1
            // 
            this.xtraHNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xtraHNavigator1.GridControl = this.dgware_Dm_Nganhang;
            this.xtraHNavigator1.Location = new System.Drawing.Point(0, 725);
            this.xtraHNavigator1.Margin = new System.Windows.Forms.Padding(0);
            this.xtraHNavigator1.Name = "xtraHNavigator1";
            this.xtraHNavigator1.Size = new System.Drawing.Size(1008, 24);
            this.xtraHNavigator1.TabIndex = 11;
            this.xtraHNavigator1.TextStringFormat = "Dòng : {0}/ {1}";
            this.xtraHNavigator1.VisibleFirst = true;
            this.xtraHNavigator1.VisibleLast = true;
            this.xtraHNavigator1.VisibleNext = true;
            this.xtraHNavigator1.VisiblePageNext = true;
            this.xtraHNavigator1.VisiblePagePrev = true;
            this.xtraHNavigator1.VisiblePrev = true;
            // 
            // Frmware_Dm_Nganhang_Add
            // 
            this.AllowRefresh = true;
            this.ClientSize = new System.Drawing.Size(1008, 749);
            this.Controls.Add(this.dgware_Dm_Nganhang);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.xtraHNavigator1);
            this.EditMode = GoobizFrame.Windows.Forms.FormUpdateWithToolbar.EditModes.Separate;
            this.FormState = GoobizFrame.Windows.Forms.FormState.View;
            this.Name = "Frmware_Dm_Nganhang_Add";
            this.Load += new System.EventHandler(this.Frmware_Dm_Nganhang_Add_Load);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Nganhang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridText_Dienthoai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienthoai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa_Nganhang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen_Nganhang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiachi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId_Nganhang.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgware_Dm_Nganhang;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit txtMa_Nganhang;
        private DevExpress.XtraEditors.TextEdit txtDienthoai;
        private DevExpress.XtraEditors.LabelControl lblDienthoai;
        private DevExpress.XtraEditors.TextEdit txtDiachi;
        private DevExpress.XtraEditors.LabelControl lblDiachi;
        private DevExpress.XtraEditors.TextEdit txtTen_Nganhang;
        private DevExpress.XtraEditors.TextEdit txtId_Nganhang;
        private DevExpress.XtraEditors.LabelControl lblTen_Nganhang;
        private DevExpress.XtraEditors.LabelControl lblMa_Nganhang;
        private DevExpress.XtraEditors.LabelControl lblId_Nganhang;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit gridText_Dienthoai;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private  GoobizFrame.Windows.Controls.XtraHNavigator xtraHNavigator1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
