namespace Ecm.Rex.Forms
{
    partial class FrmRptRex_Hopdong_Hethan
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
            this.lookUpEdit_Bophan = new DevExpress.XtraEditors.LookUpEdit();
            this.lblBophan = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Ngaybatdau = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Ngayketthuc = new DevExpress.XtraEditors.LabelControl();
            this.dtNgay_Batdau = new DevExpress.XtraEditors.DateEdit();
            this.dtNgay_Ketthuc = new DevExpress.XtraEditors.DateEdit();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_Header)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Bophan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Batdau.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Batdau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // printControl1
            // 
            this.printControl1.Size = new System.Drawing.Size(1045, 442);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Location = new System.Drawing.Point(200, 47);
            this.splitContainerControl1.Size = new System.Drawing.Size(1045, 442);
            this.splitContainerControl1.SplitterPosition = 35;
            // 
            // lookUpEdit_Bophan
            // 
            this.lookUpEdit_Bophan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lookUpEdit_Bophan.Location = new System.Drawing.Point(56, 55);
            this.lookUpEdit_Bophan.Name = "lookUpEdit_Bophan";
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
            this.lookUpEdit_Bophan.Size = new System.Drawing.Size(133, 20);
            this.lookUpEdit_Bophan.TabIndex = 3;
            // 
            // lblBophan
            // 
            this.lblBophan.Location = new System.Drawing.Point(3, 55);
            this.lblBophan.Name = "lblBophan";
            this.lblBophan.Size = new System.Drawing.Size(39, 13);
            this.lblBophan.TabIndex = 2;
            this.lblBophan.Text = "Bộ phận";
            // 
            // lbl_Ngaybatdau
            // 
            this.lbl_Ngaybatdau.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.lbl_Ngaybatdau.Location = new System.Drawing.Point(3, 3);
            this.lbl_Ngaybatdau.Name = "lbl_Ngaybatdau";
            this.lbl_Ngaybatdau.Size = new System.Drawing.Size(40, 13);
            this.lbl_Ngaybatdau.TabIndex = 8;
            this.lbl_Ngaybatdau.Text = "Từ ngày";
            // 
            // lbl_Ngayketthuc
            // 
            this.lbl_Ngayketthuc.Location = new System.Drawing.Point(3, 29);
            this.lbl_Ngayketthuc.Name = "lbl_Ngayketthuc";
            this.lbl_Ngayketthuc.Size = new System.Drawing.Size(47, 13);
            this.lbl_Ngayketthuc.TabIndex = 9;
            this.lbl_Ngayketthuc.Text = "Đến ngày";
            // 
            // dtNgay_Batdau
            // 
            this.dtNgay_Batdau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtNgay_Batdau.EditValue = null;
            this.dtNgay_Batdau.Location = new System.Drawing.Point(56, 3);
            this.dtNgay_Batdau.Name = "dtNgay_Batdau";
            this.dtNgay_Batdau.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgay_Batdau.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtNgay_Batdau.Size = new System.Drawing.Size(133, 20);
            this.dtNgay_Batdau.TabIndex = 6;
            // 
            // dtNgay_Ketthuc
            // 
            this.dtNgay_Ketthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtNgay_Ketthuc.EditValue = null;
            this.dtNgay_Ketthuc.Location = new System.Drawing.Point(56, 29);
            this.dtNgay_Ketthuc.Name = "dtNgay_Ketthuc";
            this.dtNgay_Ketthuc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgay_Ketthuc.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtNgay_Ketthuc.Size = new System.Drawing.Size(133, 20);
            this.dtNgay_Ketthuc.TabIndex = 7;
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
            this.dockPanel1.ID = new System.Guid("eadbca05-a1a0-419b-a15b-3b29be31652a");
            this.dockPanel1.Location = new System.Drawing.Point(0, 47);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.Size = new System.Drawing.Size(200, 442);
            this.dockPanel1.Tag = "";
            this.dockPanel1.Text = "Tùy chọn";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.tableLayoutPanel1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(192, 415);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lookUpEdit_Bophan, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.dtNgay_Ketthuc, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblBophan, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Ngayketthuc, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Ngaybatdau, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtNgay_Batdau, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(192, 415);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // FrmRptRex_Hopdong_Hethan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 517);
            this.Controls.Add(this.dockPanel1);
            this.Name = "FrmRptRex_Hopdong_Hethan";
            this.SplitterPosition = 35;
            this.Text = "FrmRptRex_Hopdong_Hethan";
            this.Controls.SetChildIndex(this.dockPanel1, 0);
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_Header)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Bophan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Batdau.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Batdau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_Bophan;
        private DevExpress.XtraEditors.LabelControl lblBophan;
        private DevExpress.XtraEditors.LabelControl lbl_Ngaybatdau;
        private DevExpress.XtraEditors.LabelControl lbl_Ngayketthuc;
        private DevExpress.XtraEditors.DateEdit dtNgay_Batdau;
        private DevExpress.XtraEditors.DateEdit dtNgay_Ketthuc;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}