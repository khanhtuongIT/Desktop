namespace Ecm.Rex.Forms
{
    partial class FrmRptRex_Nghiphep
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
            this.lookUpEdit_Bophan = new DevExpress.XtraEditors.LookUpEdit();
            this.lblBophan = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Ngaybatdau = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Ngayketthuc = new DevExpress.XtraEditors.LabelControl();
            this.dtNgay_Batdau = new DevExpress.XtraEditors.DateEdit();
            this.dtNgay_Ketthuc = new DevExpress.XtraEditors.DateEdit();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_Header)).BeginInit();
            this.panelControl_Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Bophan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Batdau.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Batdau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // printControl1
            // 
            this.printControl1.Size = new System.Drawing.Size(1245, 397);
            // 
            // panelControl_Header
            // 
            this.panelControl_Header.Controls.Add(this.tableLayoutPanel1);
            this.panelControl_Header.Size = new System.Drawing.Size(1245, 40);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 47);
            this.splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both;
            this.splitContainerControl1.Size = new System.Drawing.Size(1245, 442);
            this.splitContainerControl1.SplitterPosition = 40;
            // 
            // lookUpEdit_Bophan
            // 
            this.lookUpEdit_Bophan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lookUpEdit_Bophan.Location = new System.Drawing.Point(599, 3);
            this.lookUpEdit_Bophan.Name = "lookUpEdit_Bophan";
            this.lookUpEdit_Bophan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit_Bophan.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Bophan", "STT"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Bophan", "Mã BP"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Bophan", "Tên BP")});
            this.lookUpEdit_Bophan.Properties.DisplayMember = "Ten_Bophan";
            this.lookUpEdit_Bophan.Properties.NullText = "";
            this.lookUpEdit_Bophan.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lookUpEdit_Bophan.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit_Bophan.Properties.ValueMember = "Id_Bophan";
            this.lookUpEdit_Bophan.Size = new System.Drawing.Size(200, 20);
            this.lookUpEdit_Bophan.TabIndex = 3;
            // 
            // lblBophan
            // 
            this.lblBophan.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBophan.Location = new System.Drawing.Point(554, 6);
            this.lblBophan.Name = "lblBophan";
            this.lblBophan.Size = new System.Drawing.Size(39, 13);
            this.lblBophan.TabIndex = 2;
            this.lblBophan.Text = "Bộ phận";
            // 
            // lbl_Ngaybatdau
            // 
            this.lbl_Ngaybatdau.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Ngaybatdau.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.lbl_Ngaybatdau.Location = new System.Drawing.Point(3, 6);
            this.lbl_Ngaybatdau.Name = "lbl_Ngaybatdau";
            this.lbl_Ngaybatdau.Size = new System.Drawing.Size(40, 13);
            this.lbl_Ngaybatdau.TabIndex = 8;
            this.lbl_Ngaybatdau.Text = "Từ ngày";
            // 
            // lbl_Ngayketthuc
            // 
            this.lbl_Ngayketthuc.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Ngayketthuc.Location = new System.Drawing.Point(275, 6);
            this.lbl_Ngayketthuc.Name = "lbl_Ngayketthuc";
            this.lbl_Ngayketthuc.Size = new System.Drawing.Size(47, 13);
            this.lbl_Ngayketthuc.TabIndex = 9;
            this.lbl_Ngayketthuc.Text = "Đến ngày";
            // 
            // dtNgay_Batdau
            // 
            this.dtNgay_Batdau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtNgay_Batdau.EditValue = null;
            this.dtNgay_Batdau.Location = new System.Drawing.Point(49, 3);
            this.dtNgay_Batdau.Name = "dtNgay_Batdau";
            this.dtNgay_Batdau.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgay_Batdau.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtNgay_Batdau.Size = new System.Drawing.Size(200, 20);
            this.dtNgay_Batdau.TabIndex = 6;
            // 
            // dtNgay_Ketthuc
            // 
            this.dtNgay_Ketthuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtNgay_Ketthuc.EditValue = null;
            this.dtNgay_Ketthuc.Location = new System.Drawing.Point(328, 3);
            this.dtNgay_Ketthuc.Name = "dtNgay_Ketthuc";
            this.dtNgay_Ketthuc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgay_Ketthuc.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtNgay_Ketthuc.Size = new System.Drawing.Size(200, 20);
            this.dtNgay_Ketthuc.TabIndex = 7;
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 443F));
            this.tableLayoutPanel1.Controls.Add(this.lookUpEdit_Bophan, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtNgay_Ketthuc, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblBophan, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Ngayketthuc, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Ngaybatdau, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtNgay_Batdau, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1245, 40);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // FrmRptRex_Nghiphep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 517);
            this.Name = "FrmRptRex_Nghiphep";
            this.ShowHeaderPanel = true;
            this.SplitterPosition = 40;
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_Header)).EndInit();
            this.panelControl_Header.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Bophan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Batdau.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Batdau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties)).EndInit();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}