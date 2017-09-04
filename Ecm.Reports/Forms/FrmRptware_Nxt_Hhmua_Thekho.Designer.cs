namespace SunLine.Reports.Forms
{
    partial class FrmRptware_Nxt_Hhmua_Thekho
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
            this.dtNgay_Ketthuc = new DevExpress.XtraEditors.DateEdit();
            this.lblNgay_Ketthuc = new DevExpress.XtraEditors.LabelControl();
            this.dtNgay_Batdau = new DevExpress.XtraEditors.DateEdit();
            this.lblNgay_Batdau = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEdit_Hanghoa_Mua = new DevExpress.XtraEditors.LookUpEdit();
            this.lblId_Hanghoa_Mua = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEditKho_Hanghoa_Mua = new DevExpress.XtraEditors.LookUpEdit();
            this.lblKho_Hanghoa_Mua = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_Header)).BeginInit();
            this.panelControl_Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Batdau.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Batdau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Hanghoa_Mua.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditKho_Hanghoa_Mua.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // printControl1
            // 
            this.printControl1.Location = new System.Drawing.Point(0, 117);
            this.printControl1.Size = new System.Drawing.Size(1129, 375);
            // 
            // panelControl_Header
            // 
            this.panelControl_Header.Controls.Add(this.lookUpEditKho_Hanghoa_Mua);
            this.panelControl_Header.Controls.Add(this.lblKho_Hanghoa_Mua);
            this.panelControl_Header.Controls.Add(this.lookUpEdit_Hanghoa_Mua);
            this.panelControl_Header.Controls.Add(this.lblId_Hanghoa_Mua);
            this.panelControl_Header.Controls.Add(this.dtNgay_Ketthuc);
            this.panelControl_Header.Controls.Add(this.lblNgay_Ketthuc);
            this.panelControl_Header.Controls.Add(this.dtNgay_Batdau);
            this.panelControl_Header.Controls.Add(this.lblNgay_Batdau);
            this.panelControl_Header.Location = new System.Drawing.Point(0, 26);
            this.panelControl_Header.Size = new System.Drawing.Size(1129, 91);
            // 
            // dtNgay_Ketthuc
            // 
            this.dtNgay_Ketthuc.EditValue = new System.DateTime(2009, 4, 16, 11, 42, 11, 239);
            this.dtNgay_Ketthuc.Location = new System.Drawing.Point(391, 16);
            this.dtNgay_Ketthuc.Name = "dtNgay_Ketthuc";
            this.dtNgay_Ketthuc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgay_Ketthuc.Properties.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss tt";
            this.dtNgay_Ketthuc.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgay_Ketthuc.Properties.EditFormat.FormatString = "dd/MM/yyyy hh:mm:ss tt";
            this.dtNgay_Ketthuc.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgay_Ketthuc.Properties.Mask.EditMask = "dd/MM/yyyy hh:mm:ss tt";
            this.dtNgay_Ketthuc.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtNgay_Ketthuc.Size = new System.Drawing.Size(287, 20);
            this.dtNgay_Ketthuc.TabIndex = 95;
            // 
            // lblNgay_Ketthuc
            // 
            this.lblNgay_Ketthuc.Location = new System.Drawing.Point(318, 19);
            this.lblNgay_Ketthuc.Name = "lblNgay_Ketthuc";
            this.lblNgay_Ketthuc.Size = new System.Drawing.Size(47, 13);
            this.lblNgay_Ketthuc.TabIndex = 92;
            this.lblNgay_Ketthuc.Text = "Đến ngày";
            // 
            // dtNgay_Batdau
            // 
            this.dtNgay_Batdau.EditValue = new System.DateTime(2009, 4, 16, 11, 42, 23, 643);
            this.dtNgay_Batdau.Location = new System.Drawing.Point(59, 15);
            this.dtNgay_Batdau.Name = "dtNgay_Batdau";
            this.dtNgay_Batdau.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgay_Batdau.Properties.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss tt";
            this.dtNgay_Batdau.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgay_Batdau.Properties.EditFormat.FormatString = "dd/MM/yyyy hh:mm:ss tt";
            this.dtNgay_Batdau.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgay_Batdau.Properties.Mask.EditMask = "dd/MM/yyyy hh:mm:ss tt";
            this.dtNgay_Batdau.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtNgay_Batdau.Size = new System.Drawing.Size(249, 20);
            this.dtNgay_Batdau.TabIndex = 94;
            // 
            // lblNgay_Batdau
            // 
            this.lblNgay_Batdau.Location = new System.Drawing.Point(10, 18);
            this.lblNgay_Batdau.Name = "lblNgay_Batdau";
            this.lblNgay_Batdau.Size = new System.Drawing.Size(40, 13);
            this.lblNgay_Batdau.TabIndex = 93;
            this.lblNgay_Batdau.Text = "Từ ngày";
            // 
            // lookUpEdit_Hanghoa_Mua
            // 
            this.lookUpEdit_Hanghoa_Mua.Location = new System.Drawing.Point(391, 42);
            this.lookUpEdit_Hanghoa_Mua.Name = "lookUpEdit_Hanghoa_Mua";
            this.lookUpEdit_Hanghoa_Mua.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit_Hanghoa_Mua.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Hanghoa_Mua", "Stt", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Hanghoa_Mua", "Mã hàng mua", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Hanghoa_Mua", "Tên hàng mua", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.lookUpEdit_Hanghoa_Mua.Properties.DisplayMember = "Ten_Hanghoa_Mua";
            this.lookUpEdit_Hanghoa_Mua.Properties.NullText = "";
            this.lookUpEdit_Hanghoa_Mua.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lookUpEdit_Hanghoa_Mua.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit_Hanghoa_Mua.Properties.ValueMember = "Id_Hanghoa_Mua";
            this.lookUpEdit_Hanghoa_Mua.Size = new System.Drawing.Size(287, 20);
            this.lookUpEdit_Hanghoa_Mua.TabIndex = 96;
            // 
            // lblId_Hanghoa_Mua
            // 
            this.lblId_Hanghoa_Mua.Location = new System.Drawing.Point(318, 46);
            this.lblId_Hanghoa_Mua.Name = "lblId_Hanghoa_Mua";
            this.lblId_Hanghoa_Mua.Size = new System.Drawing.Size(69, 13);
            this.lblId_Hanghoa_Mua.TabIndex = 97;
            this.lblId_Hanghoa_Mua.Text = "Hàng hóa mua";
            // 
            // lookUpEditKho_Hanghoa_Mua
            // 
            this.lookUpEditKho_Hanghoa_Mua.Location = new System.Drawing.Point(61, 41);
            this.lookUpEditKho_Hanghoa_Mua.Name = "lookUpEditKho_Hanghoa_Mua";
            this.lookUpEditKho_Hanghoa_Mua.Properties.AutoSearchColumnIndex = 2;
            this.lookUpEditKho_Hanghoa_Mua.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditKho_Hanghoa_Mua.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Kho_Hanghoa_Mua", "Stt", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Kho_Hanghoa_Mua", "Mã kho HH mua", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Kho_Hanghoa_Mua", "Tên kho HH mua", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.lookUpEditKho_Hanghoa_Mua.Properties.DisplayMember = "Ten_Kho_Hanghoa_Mua";
            this.lookUpEditKho_Hanghoa_Mua.Properties.NullText = "";
            this.lookUpEditKho_Hanghoa_Mua.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lookUpEditKho_Hanghoa_Mua.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditKho_Hanghoa_Mua.Properties.ValueMember = "Id_Kho_Hanghoa_Mua";
            this.lookUpEditKho_Hanghoa_Mua.Size = new System.Drawing.Size(249, 20);
            this.lookUpEditKho_Hanghoa_Mua.TabIndex = 98;
            // 
            // lblKho_Hanghoa_Mua
            // 
            this.lblKho_Hanghoa_Mua.Location = new System.Drawing.Point(10, 45);
            this.lblKho_Hanghoa_Mua.Name = "lblKho_Hanghoa_Mua";
            this.lblKho_Hanghoa_Mua.Size = new System.Drawing.Size(45, 13);
            this.lblKho_Hanghoa_Mua.TabIndex = 99;
            this.lblKho_Hanghoa_Mua.Text = "Kho hàng";
            // 
            // FrmRptware_Nxt_Hhmua_Thekho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1129, 517);
            this.Name = "FrmRptware_Nxt_Hhmua_Thekho";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_Header)).EndInit();
            this.panelControl_Header.ResumeLayout(false);
            this.panelControl_Header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Batdau.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Batdau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Hanghoa_Mua.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditKho_Hanghoa_Mua.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dtNgay_Ketthuc;
        private DevExpress.XtraEditors.LabelControl lblNgay_Ketthuc;
        private DevExpress.XtraEditors.DateEdit dtNgay_Batdau;
        private DevExpress.XtraEditors.LabelControl lblNgay_Batdau;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_Hanghoa_Mua;
        private DevExpress.XtraEditors.LabelControl lblId_Hanghoa_Mua;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditKho_Hanghoa_Mua;
        private DevExpress.XtraEditors.LabelControl lblKho_Hanghoa_Mua;
    }
}
