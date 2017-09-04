namespace Ecm.MasterTables.Forms.Ware
{
    partial class Frmware_Dm_Donvitinh_Add
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmware_Dm_Donvitinh_Add));
            this.dgware_Dm_Donvitinh = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtTen_Donvitinh = new DevExpress.XtraEditors.TextEdit();
            this.lblMa_Donvitinh = new DevExpress.XtraEditors.LabelControl();
            this.lblTen_Donvitinh = new DevExpress.XtraEditors.LabelControl();
            this.txtMa_Donvitinh = new DevExpress.XtraEditors.TextEdit();
            this.txtId_Donvitinh = new DevExpress.XtraEditors.TextEdit();
            this.lblId_Donvitinh = new DevExpress.XtraEditors.LabelControl();
            this.xtraHNavigator1 = new GoobizFrame.Windows.Controls.XtraHNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Donvitinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen_Donvitinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa_Donvitinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId_Donvitinh.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.LookAndFeel.SkinName = "Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // dgware_Dm_Donvitinh
            // 
            this.dgware_Dm_Donvitinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgware_Dm_Donvitinh.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.dgware_Dm_Donvitinh.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.dgware_Dm_Donvitinh.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.dgware_Dm_Donvitinh.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.dgware_Dm_Donvitinh.EmbeddedNavigator.Buttons.First.Visible = false;
            this.dgware_Dm_Donvitinh.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.dgware_Dm_Donvitinh.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.dgware_Dm_Donvitinh.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.dgware_Dm_Donvitinh.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.dgware_Dm_Donvitinh.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.dgware_Dm_Donvitinh.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.dgware_Dm_Donvitinh.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
            this.dgware_Dm_Donvitinh.EmbeddedNavigator.TextStringFormat = "Dòng: {0} / {1}";
            this.dgware_Dm_Donvitinh.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dgware_Dm_Donvitinh_EmbeddedNavigator_ButtonClick);
            this.dgware_Dm_Donvitinh.Location = new System.Drawing.Point(0, 132);
            this.dgware_Dm_Donvitinh.MainView = this.gridView1;
            this.dgware_Dm_Donvitinh.Name = "dgware_Dm_Donvitinh";
            this.dgware_Dm_Donvitinh.Size = new System.Drawing.Size(1023, 585);
            this.dgware_Dm_Donvitinh.TabIndex = 0;
            this.dgware_Dm_Donvitinh.UseEmbeddedNavigator = true;
            this.dgware_Dm_Donvitinh.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.GridControl = this.dgware_Dm_Donvitinh;
            this.gridView1.GroupPanelText = "[Kéo một cột vào đây để nhóm]";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Số thứ tự";
            this.gridColumn1.FieldName = "Id_Donvitinh";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Mã đơn vị tính";
            this.gridColumn2.FieldName = "Ma_Donvitinh";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 300;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Tên đơn vị tính";
            this.gridColumn3.FieldName = "Ten_Donvitinh";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 264;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.tableLayoutPanel1);
            this.panelControl1.Controls.Add(this.txtId_Donvitinh);
            this.panelControl1.Controls.Add(this.lblId_Donvitinh);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 65);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1023, 67);
            this.panelControl1.TabIndex = 0;
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.txtTen_Donvitinh, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblMa_Donvitinh, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTen_Donvitinh, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtMa_Donvitinh, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1019, 63);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // txtTen_Donvitinh
            // 
            this.txtTen_Donvitinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTen_Donvitinh.Location = new System.Drawing.Point(450, 3);
            this.txtTen_Donvitinh.Name = "txtTen_Donvitinh";
            this.txtTen_Donvitinh.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtTen_Donvitinh.Properties.Appearance.Options.UseFont = true;
            this.txtTen_Donvitinh.Size = new System.Drawing.Size(200, 26);
            this.txtTen_Donvitinh.TabIndex = 1;
            // 
            // lblMa_Donvitinh
            // 
            this.lblMa_Donvitinh.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMa_Donvitinh.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblMa_Donvitinh.Location = new System.Drawing.Point(3, 6);
            this.lblMa_Donvitinh.Name = "lblMa_Donvitinh";
            this.lblMa_Donvitinh.Size = new System.Drawing.Size(101, 19);
            this.lblMa_Donvitinh.TabIndex = 2;
            this.lblMa_Donvitinh.Text = "Mã đơn vị tính";
            // 
            // lblTen_Donvitinh
            // 
            this.lblTen_Donvitinh.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTen_Donvitinh.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblTen_Donvitinh.Location = new System.Drawing.Point(336, 6);
            this.lblTen_Donvitinh.Name = "lblTen_Donvitinh";
            this.lblTen_Donvitinh.Size = new System.Drawing.Size(108, 19);
            this.lblTen_Donvitinh.TabIndex = 4;
            this.lblTen_Donvitinh.Text = "Tên đơn vị tính";
            // 
            // txtMa_Donvitinh
            // 
            this.txtMa_Donvitinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMa_Donvitinh.Location = new System.Drawing.Point(110, 3);
            this.txtMa_Donvitinh.Name = "txtMa_Donvitinh";
            this.txtMa_Donvitinh.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtMa_Donvitinh.Properties.Appearance.Options.UseFont = true;
            this.txtMa_Donvitinh.Size = new System.Drawing.Size(200, 26);
            this.txtMa_Donvitinh.TabIndex = 0;
            this.txtMa_Donvitinh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMa_Donvitinh_KeyPress);
            // 
            // txtId_Donvitinh
            // 
            this.txtId_Donvitinh.Enabled = false;
            this.txtId_Donvitinh.Location = new System.Drawing.Point(900, 20);
            this.txtId_Donvitinh.Name = "txtId_Donvitinh";
            this.txtId_Donvitinh.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtId_Donvitinh.Properties.Appearance.Options.UseFont = true;
            this.txtId_Donvitinh.Size = new System.Drawing.Size(100, 26);
            this.txtId_Donvitinh.TabIndex = 0;
            this.txtId_Donvitinh.Visible = false;
            // 
            // lblId_Donvitinh
            // 
            this.lblId_Donvitinh.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblId_Donvitinh.Location = new System.Drawing.Point(826, 24);
            this.lblId_Donvitinh.Name = "lblId_Donvitinh";
            this.lblId_Donvitinh.Size = new System.Drawing.Size(68, 19);
            this.lblId_Donvitinh.TabIndex = 0;
            this.lblId_Donvitinh.Text = "Số thứ tự";
            this.lblId_Donvitinh.Visible = false;
            // 
            // xtraHNavigator1
            // 
            this.xtraHNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xtraHNavigator1.GridControl = this.dgware_Dm_Donvitinh;
            this.xtraHNavigator1.Location = new System.Drawing.Point(0, 717);
            this.xtraHNavigator1.Margin = new System.Windows.Forms.Padding(0);
            this.xtraHNavigator1.Name = "xtraHNavigator1";
            this.xtraHNavigator1.Size = new System.Drawing.Size(1023, 24);
            this.xtraHNavigator1.TabIndex = 9;
            this.xtraHNavigator1.TextStringFormat = "Dòng: {0} / {1}";
            this.xtraHNavigator1.VisibleFirst = true;
            this.xtraHNavigator1.VisibleLast = true;
            this.xtraHNavigator1.VisibleNext = true;
            this.xtraHNavigator1.VisiblePageNext = true;
            this.xtraHNavigator1.VisiblePagePrev = true;
            this.xtraHNavigator1.VisiblePrev = true;
            // 
            // Frmware_Dm_Donvitinh_Add
            // 
            this.AllowRefresh = true;
            this.AllowSelect = true;
            this.ClientSize = new System.Drawing.Size(1023, 741);
            this.Controls.Add(this.dgware_Dm_Donvitinh);
            this.Controls.Add(this.xtraHNavigator1);
            this.Controls.Add(this.panelControl1);
            this.EditMode = GoobizFrame.Windows.Forms.FormUpdateWithToolbar.EditModes.Separate;
            this.FormState = GoobizFrame.Windows.Forms.FormState.View;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frmware_Dm_Donvitinh_Add";
            this.Text = "Đơn vị tính";
            this.Load += new System.EventHandler(this.Frmware_Dm_Donvitinh_Add_Load);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Donvitinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen_Donvitinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa_Donvitinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId_Donvitinh.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgware_Dm_Donvitinh;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtTen_Donvitinh;
        private DevExpress.XtraEditors.LabelControl lblTen_Donvitinh;
        private DevExpress.XtraEditors.TextEdit txtMa_Donvitinh;
        private DevExpress.XtraEditors.LabelControl lblMa_Donvitinh;
        private DevExpress.XtraEditors.TextEdit txtId_Donvitinh;
        private DevExpress.XtraEditors.LabelControl lblId_Donvitinh;
        private  GoobizFrame.Windows.Controls.XtraHNavigator xtraHNavigator1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
