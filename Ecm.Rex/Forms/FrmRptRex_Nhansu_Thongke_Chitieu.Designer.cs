namespace Ecm.Rex.Forms
{
    partial class FrmRptRex_Nhansu_Thongke_Chitieu
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
            this.components = new System.ComponentModel.Container();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dgThongke = new DevExpress.XtraGrid.GridControl();
            this.gvThongke = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraHNavigator1 = new GoobizFrame.Windows.Controls.XtraHNavigator();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dtNgay_Ketthuc = new DevExpress.XtraEditors.DateEdit();
            this.chkInclude_Thoiviec = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_Header)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgThongke)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvThongke)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInclude_Thoiviec.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // printControl1
            // 
            this.printControl1.Size = new System.Drawing.Size(823, 389);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Location = new System.Drawing.Point(292, 47);
            this.splitContainerControl1.Size = new System.Drawing.Size(823, 389);
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("4285f29f-5b44-49c4-8a0b-30030caad63e");
            this.dockPanel1.Location = new System.Drawing.Point(0, 47);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(292, 200);
            this.dockPanel1.Size = new System.Drawing.Size(292, 389);
            this.dockPanel1.Text = "Tùy chọn";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.dgThongke);
            this.dockPanel1_Container.Controls.Add(this.xtraHNavigator1);
            this.dockPanel1_Container.Controls.Add(this.tableLayoutPanel1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(284, 362);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // dgThongke
            // 
            this.dgThongke.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgThongke.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.dgThongke.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.dgThongke.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.dgThongke.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.dgThongke.EmbeddedNavigator.Buttons.First.Visible = false;
            this.dgThongke.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.dgThongke.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.dgThongke.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.dgThongke.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.dgThongke.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.dgThongke.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.dgThongke.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
            this.dgThongke.EmbeddedNavigator.TextStringFormat = "{0}/{1}";
            this.dgThongke.Location = new System.Drawing.Point(0, 57);
            this.dgThongke.MainView = this.gvThongke;
            this.dgThongke.Name = "dgThongke";
            this.dgThongke.Size = new System.Drawing.Size(284, 283);
            this.dgThongke.TabIndex = 6;
            this.dgThongke.UseEmbeddedNavigator = true;
            this.dgThongke.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvThongke});
            // 
            // gvThongke
            // 
            this.gvThongke.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gvThongke.GridControl = this.dgThongke;
            this.gvThongke.GroupCount = 1;
            this.gvThongke.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Soluong", null, "Số NV: {0:#,#}")});
            this.gvThongke.Name = "gvThongke";
            this.gvThongke.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvThongke.OptionsView.ShowGroupPanel = false;
            this.gvThongke.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvThongke.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvThongke_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Chỉ tiêu";
            this.gridColumn1.FieldName = "Chitieu";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Ma_Chitieu";
            this.gridColumn2.FieldName = "Ma_Chitieu";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Chi tiết";
            this.gridColumn3.FieldName = "Ten_Chitieu";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Giatri";
            this.gridColumn4.FieldName = "Giatri";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Số nhân viên";
            this.gridColumn5.DisplayFormat.FormatString = "{0:#,#}";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "Soluong";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            // 
            // xtraHNavigator1
            // 
            this.xtraHNavigator1.ButtonModes = GoobizFrame.Windows.Controls.XtraHNavigator.NavigatorButtonModes.ShowNavigators;
            this.xtraHNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xtraHNavigator1.GridControl = this.dgThongke;
            this.xtraHNavigator1.Location = new System.Drawing.Point(0, 340);
            this.xtraHNavigator1.Margin = new System.Windows.Forms.Padding(0);
            this.xtraHNavigator1.Name = "xtraHNavigator1";
            this.xtraHNavigator1.Size = new System.Drawing.Size(284, 22);
            this.xtraHNavigator1.TabIndex = 7;
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
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dtNgay_Ketthuc, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkInclude_Thoiviec, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 57);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // dtNgay_Ketthuc
            // 
            this.dtNgay_Ketthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtNgay_Ketthuc.EditValue = null;
            this.dtNgay_Ketthuc.Location = new System.Drawing.Point(56, 3);
            this.dtNgay_Ketthuc.Name = "dtNgay_Ketthuc";
            this.dtNgay_Ketthuc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgay_Ketthuc.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtNgay_Ketthuc.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgay_Ketthuc.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtNgay_Ketthuc.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgay_Ketthuc.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtNgay_Ketthuc.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtNgay_Ketthuc.Size = new System.Drawing.Size(225, 20);
            this.dtNgay_Ketthuc.TabIndex = 3;
            // 
            // chkInclude_Thoiviec
            // 
            this.chkInclude_Thoiviec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkInclude_Thoiviec.EditValue = true;
            this.chkInclude_Thoiviec.Location = new System.Drawing.Point(56, 29);
            this.chkInclude_Thoiviec.Name = "chkInclude_Thoiviec";
            this.chkInclude_Thoiviec.Properties.AutoWidth = true;
            this.chkInclude_Thoiviec.Properties.Caption = "Bao gồm nhân viên thôi việc";
            this.chkInclude_Thoiviec.Size = new System.Drawing.Size(157, 19);
            this.chkInclude_Thoiviec.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Location = new System.Drawing.Point(3, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Đến ngày";
            // 
            // FrmRptRex_Nhansu_Thongke_Chitieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 464);
            this.Controls.Add(this.dockPanel1);
            this.Name = "FrmRptRex_Nhansu_Thongke_Chitieu";
            this.Text = "FrmRptRex_Nhansu_Thongke_Chitieu";
            this.Controls.SetChildIndex(this.dockPanel1, 0);
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_Header)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgThongke)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvThongke)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInclude_Thoiviec.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.DateEdit dtNgay_Ketthuc;
        private DevExpress.XtraEditors.CheckEdit chkInclude_Thoiviec;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl dgThongke;
        private DevExpress.XtraGrid.Views.Grid.GridView gvThongke;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private GoobizFrame.Windows.Controls.XtraHNavigator xtraHNavigator1;
    }
}