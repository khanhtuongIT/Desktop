namespace Ecm.Rex.Forms
{
    partial class FrmRptRex_Lylich_Trichngang
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
            this.lblBophan = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEdit_Bophan = new DevExpress.XtraEditors.LookUpEdit();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.lookUpEdit_RptTemplates = new DevExpress.XtraEditors.LookUpEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chkInclude_Children = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtNgay_Ketthuc = new DevExpress.XtraEditors.DateEdit();
            this.chkInclude_Thoiviec = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_Header)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Bophan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_RptTemplates.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkInclude_Children.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInclude_Thoiviec.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // printControl1
            // 
            this.printControl1.Size = new System.Drawing.Size(980, 442);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Location = new System.Drawing.Point(265, 47);
            this.splitContainerControl1.Size = new System.Drawing.Size(980, 442);
            this.splitContainerControl1.SplitterPosition = 40;
            // 
            // lblBophan
            // 
            this.lblBophan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBophan.Location = new System.Drawing.Point(3, 32);
            this.lblBophan.Name = "lblBophan";
            this.lblBophan.Size = new System.Drawing.Size(39, 13);
            this.lblBophan.TabIndex = 0;
            this.lblBophan.Text = "Bộ phận";
            // 
            // lookUpEdit_Bophan
            // 
            this.lookUpEdit_Bophan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lookUpEdit_Bophan.Location = new System.Drawing.Point(48, 29);
            this.lookUpEdit_Bophan.Name = "lookUpEdit_Bophan";
            this.lookUpEdit_Bophan.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookUpEdit_Bophan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit_Bophan.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Bophan", "STT"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Bophan_Order", "BP"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Bophan", "Mã BP"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Bophan", "Tên BP")});
            this.lookUpEdit_Bophan.Properties.DisplayMember = "Ten_Bophan";
            this.lookUpEdit_Bophan.Properties.NullText = "";
            this.lookUpEdit_Bophan.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lookUpEdit_Bophan.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit_Bophan.Properties.ValueMember = "Id_Bophan";
            this.lookUpEdit_Bophan.Size = new System.Drawing.Size(202, 20);
            this.lookUpEdit_Bophan.TabIndex = 1;
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
            this.dockPanel1.ID = new System.Guid("0865d824-1712-4c91-aecd-7c74f43bb3ad");
            this.dockPanel1.Location = new System.Drawing.Point(0, 47);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(265, 200);
            this.dockPanel1.Size = new System.Drawing.Size(265, 442);
            this.dockPanel1.Text = "Tùy chọn";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.groupControl2);
            this.dockPanel1_Container.Controls.Add(this.groupControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(257, 415);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.lookUpEdit_RptTemplates);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(0, 131);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(257, 45);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "Mẫu in";
            // 
            // lookUpEdit_RptTemplates
            // 
            this.lookUpEdit_RptTemplates.Dock = System.Windows.Forms.DockStyle.Top;
            this.lookUpEdit_RptTemplates.Location = new System.Drawing.Point(2, 22);
            this.lookUpEdit_RptTemplates.Name = "lookUpEdit_RptTemplates";
            this.lookUpEdit_RptTemplates.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookUpEdit_RptTemplates.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit_RptTemplates.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Repx", "Repx"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Rpt", "Ten_Rpt")});
            this.lookUpEdit_RptTemplates.Properties.DisplayMember = "Ten_Rpt";
            this.lookUpEdit_RptTemplates.Properties.NullText = "";
            this.lookUpEdit_RptTemplates.Properties.ValueMember = "Repx";
            this.lookUpEdit_RptTemplates.Size = new System.Drawing.Size(253, 20);
            this.lookUpEdit_RptTemplates.TabIndex = 0;
            this.lookUpEdit_RptTemplates.EditValueChanged += new System.EventHandler(this.lookUpEdit_RptTemplates_EditValueChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.tableLayoutPanel1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(257, 131);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "...";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lookUpEdit_Bophan, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblBophan, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkInclude_Children, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtNgay_Ketthuc, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkInclude_Thoiviec, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 22);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(253, 107);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // chkInclude_Children
            // 
            this.chkInclude_Children.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkInclude_Children.EditValue = true;
            this.chkInclude_Children.Location = new System.Drawing.Point(48, 55);
            this.chkInclude_Children.Name = "chkInclude_Children";
            this.chkInclude_Children.Properties.AutoWidth = true;
            this.chkInclude_Children.Properties.Caption = "Bao gồm bộ phận trực thuộc";
            this.chkInclude_Children.Size = new System.Drawing.Size(159, 19);
            this.chkInclude_Children.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Location = new System.Drawing.Point(3, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(21, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Năm";
            // 
            // dtNgay_Ketthuc
            // 
            this.dtNgay_Ketthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtNgay_Ketthuc.EditValue = null;
            this.dtNgay_Ketthuc.Location = new System.Drawing.Point(48, 3);
            this.dtNgay_Ketthuc.Name = "dtNgay_Ketthuc";
            this.dtNgay_Ketthuc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgay_Ketthuc.Properties.DisplayFormat.FormatString = "yyyy";
            this.dtNgay_Ketthuc.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgay_Ketthuc.Properties.EditFormat.FormatString = "yyyy";
            this.dtNgay_Ketthuc.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgay_Ketthuc.Properties.Mask.EditMask = "yyyy";
            this.dtNgay_Ketthuc.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtNgay_Ketthuc.Size = new System.Drawing.Size(202, 20);
            this.dtNgay_Ketthuc.TabIndex = 3;
            // 
            // chkInclude_Thoiviec
            // 
            this.chkInclude_Thoiviec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkInclude_Thoiviec.EditValue = true;
            this.chkInclude_Thoiviec.Location = new System.Drawing.Point(48, 80);
            this.chkInclude_Thoiviec.Name = "chkInclude_Thoiviec";
            this.chkInclude_Thoiviec.Properties.AutoWidth = true;
            this.chkInclude_Thoiviec.Properties.Caption = "Bao gồm nhân viên thôi việc";
            this.chkInclude_Thoiviec.Size = new System.Drawing.Size(157, 19);
            this.chkInclude_Thoiviec.TabIndex = 2;
            // 
            // FrmRptRex_Lylich_Trichngang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1276, 517);
            this.Controls.Add(this.dockPanel1);
            this.Name = "FrmRptRex_Lylich_Trichngang";
            this.SplitterPosition = 40;
            this.Controls.SetChildIndex(this.dockPanel1, 0);
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_Header)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Bophan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_RptTemplates.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkInclude_Children.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInclude_Thoiviec.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_Bophan;
        private DevExpress.XtraEditors.LabelControl lblBophan;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.CheckEdit chkInclude_Children;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_RptTemplates;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dtNgay_Ketthuc;
        private DevExpress.XtraEditors.CheckEdit chkInclude_Thoiviec;


    }
}
