namespace Ecm.MasterTables.Forms.Ware
{
    partial class Frmware_Dm_Xe_Add
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
            this.dgware_Dm_Xe = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCheckEdit_Khohang = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMa_Xe = new DevExpress.XtraEditors.LabelControl();
            this.txtTen_Xe = new DevExpress.XtraEditors.TextEdit();
            this.txtMa_Xe = new DevExpress.XtraEditors.TextEdit();
            this.lblTen_Xe = new DevExpress.XtraEditors.LabelControl();
            this.xtraHNavigator1 = new GoobizFrame.Windows.Controls.XtraHNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Xe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCheckEdit_Khohang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen_Xe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa_Xe.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.LookAndFeel.SkinName = "Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // dgware_Dm_Xe
            // 
            this.dgware_Dm_Xe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgware_Dm_Xe.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.dgware_Dm_Xe.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.dgware_Dm_Xe.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.dgware_Dm_Xe.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.dgware_Dm_Xe.EmbeddedNavigator.Buttons.First.Visible = false;
            this.dgware_Dm_Xe.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.dgware_Dm_Xe.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.dgware_Dm_Xe.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.dgware_Dm_Xe.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.dgware_Dm_Xe.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.dgware_Dm_Xe.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.dgware_Dm_Xe.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
            this.dgware_Dm_Xe.EmbeddedNavigator.TextStringFormat = "Dòng: {0} / {1}";
            this.dgware_Dm_Xe.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dgware_Dm_Xe_EmbeddedNavigator_ButtonClick);
            this.dgware_Dm_Xe.Location = new System.Drawing.Point(0, 127);
            this.dgware_Dm_Xe.MainView = this.gridView1;
            this.dgware_Dm_Xe.Name = "dgware_Dm_Xe";
            this.dgware_Dm_Xe.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gridCheckEdit_Khohang});
            this.dgware_Dm_Xe.Size = new System.Drawing.Size(1008, 598);
            this.dgware_Dm_Xe.TabIndex = 1;
            this.dgware_Dm_Xe.UseEmbeddedNavigator = true;
            this.dgware_Dm_Xe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.GridControl = this.dgware_Dm_Xe;
            this.gridView1.GroupPanelText = "[Kéo một cột vào đây để nhóm]";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Số thứ tự";
            this.gridColumn1.FieldName = "Id_Xe";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Mã Xe";
            this.gridColumn2.FieldName = "Ma_Xe";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 330;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Tên Xe";
            this.gridColumn3.FieldName = "Ten_Xe";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 418;
            // 
            // gridCheckEdit_Khohang
            // 
            this.gridCheckEdit_Khohang.AutoHeight = false;
            this.gridCheckEdit_Khohang.Name = "gridCheckEdit_Khohang";
            this.gridCheckEdit_Khohang.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.gridCheckEdit_Khohang.ValueGrayed = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.tableLayoutPanel1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 65);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1008, 62);
            this.panelControl1.TabIndex = 0;
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
            this.tableLayoutPanel1.Controls.Add(this.lblMa_Xe, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTen_Xe, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtMa_Xe, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTen_Xe, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1004, 58);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // lblMa_Xe
            // 
            this.lblMa_Xe.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMa_Xe.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblMa_Xe.Location = new System.Drawing.Point(3, 6);
            this.lblMa_Xe.Name = "lblMa_Xe";
            this.lblMa_Xe.Size = new System.Drawing.Size(42, 19);
            this.lblMa_Xe.TabIndex = 2;
            this.lblMa_Xe.Text = "Mã Xe";
            // 
            // txtTen_Xe
            // 
            this.txtTen_Xe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTen_Xe.Location = new System.Drawing.Point(352, 3);
            this.txtTen_Xe.Name = "txtTen_Xe";
            this.txtTen_Xe.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtTen_Xe.Properties.Appearance.Options.UseFont = true;
            this.txtTen_Xe.Size = new System.Drawing.Size(220, 26);
            this.txtTen_Xe.TabIndex = 2;
            // 
            // txtMa_Xe
            // 
            this.txtMa_Xe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMa_Xe.Location = new System.Drawing.Point(51, 3);
            this.txtMa_Xe.Name = "txtMa_Xe";
            this.txtMa_Xe.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtMa_Xe.Properties.Appearance.Options.UseFont = true;
            this.txtMa_Xe.Size = new System.Drawing.Size(220, 26);
            this.txtMa_Xe.TabIndex = 1;
            this.txtMa_Xe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMa_Xe_KeyPress);
            // 
            // lblTen_Xe
            // 
            this.lblTen_Xe.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTen_Xe.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblTen_Xe.Location = new System.Drawing.Point(297, 6);
            this.lblTen_Xe.Name = "lblTen_Xe";
            this.lblTen_Xe.Size = new System.Drawing.Size(49, 19);
            this.lblTen_Xe.TabIndex = 4;
            this.lblTen_Xe.Text = "Tên Xe";
            // 
            // xtraHNavigator1
            // 
            this.xtraHNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xtraHNavigator1.GridControl = this.dgware_Dm_Xe;
            this.xtraHNavigator1.Location = new System.Drawing.Point(0, 725);
            this.xtraHNavigator1.Margin = new System.Windows.Forms.Padding(0);
            this.xtraHNavigator1.Name = "xtraHNavigator1";
            this.xtraHNavigator1.Size = new System.Drawing.Size(1008, 24);
            this.xtraHNavigator1.TabIndex = 8;
            this.xtraHNavigator1.TextStringFormat = "Dòng: {0} / {1}";
            this.xtraHNavigator1.VisibleFirst = true;
            this.xtraHNavigator1.VisibleLast = true;
            this.xtraHNavigator1.VisibleNext = true;
            this.xtraHNavigator1.VisiblePageNext = true;
            this.xtraHNavigator1.VisiblePagePrev = true;
            this.xtraHNavigator1.VisiblePrev = true;
            // 
            // Frmware_Dm_Xe_Add
            // 
            this.AllowRefresh = true;
            this.ClientSize = new System.Drawing.Size(1008, 749);
            this.Controls.Add(this.dgware_Dm_Xe);
            this.Controls.Add(this.xtraHNavigator1);
            this.Controls.Add(this.panelControl1);
            this.EditMode = GoobizFrame.Windows.Forms.FormUpdateWithToolbar.EditModes.Separate;
            this.FormState = GoobizFrame.Windows.Forms.FormState.View;
            this.Name = "Frmware_Dm_Xe_Add";
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Xe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCheckEdit_Khohang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen_Xe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa_Xe.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgware_Dm_Xe;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtTen_Xe;
        private DevExpress.XtraEditors.LabelControl lblTen_Xe;
        private DevExpress.XtraEditors.TextEdit txtMa_Xe;
        private DevExpress.XtraEditors.LabelControl lblMa_Xe;
        private  GoobizFrame.Windows.Controls.XtraHNavigator xtraHNavigator1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit gridCheckEdit_Khohang;
    }
}
