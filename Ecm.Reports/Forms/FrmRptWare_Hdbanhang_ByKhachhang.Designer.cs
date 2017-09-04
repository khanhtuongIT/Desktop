namespace SunLine.Reports.Forms
{
    partial class FrmRptWare_Hdbanhang_ByKhachhang
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
            this.lookUpEdit_Khachhang = new DevExpress.XtraEditors.LookUpEdit();
            this.lblKhachhang = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_Header)).BeginInit();
            this.panelControl_Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Batdau.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Batdau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Khachhang.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // printControl1
            // 
            this.printControl1.Location = new System.Drawing.Point(0, 76);
            this.printControl1.Size = new System.Drawing.Size(1129, 416);
            // 
            // panelControl_Header
            // 
            this.panelControl_Header.Controls.Add(this.lookUpEdit_Khachhang);
            this.panelControl_Header.Controls.Add(this.lblKhachhang);
            this.panelControl_Header.Controls.Add(this.dtNgay_Ketthuc);
            this.panelControl_Header.Controls.Add(this.lblNgay_Ketthuc);
            this.panelControl_Header.Controls.Add(this.dtNgay_Batdau);
            this.panelControl_Header.Controls.Add(this.lblNgay_Batdau);
            this.panelControl_Header.Location = new System.Drawing.Point(0, 26);
            // 
            // dtNgay_Ketthuc
            // 
            this.dtNgay_Ketthuc.EditValue = new System.DateTime(2009, 4, 16, 11, 42, 11, 239);
            this.dtNgay_Ketthuc.Location = new System.Drawing.Point(304, 15);
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
            this.dtNgay_Ketthuc.Size = new System.Drawing.Size(175, 20);
            this.dtNgay_Ketthuc.TabIndex = 95;
            // 
            // lblNgay_Ketthuc
            // 
            this.lblNgay_Ketthuc.Location = new System.Drawing.Point(250, 18);
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
            this.dtNgay_Batdau.Size = new System.Drawing.Size(175, 20);
            this.dtNgay_Batdau.TabIndex = 94;
            // 
            // lblNgay_Batdau
            // 
            this.lblNgay_Batdau.Location = new System.Drawing.Point(13, 18);
            this.lblNgay_Batdau.Name = "lblNgay_Batdau";
            this.lblNgay_Batdau.Size = new System.Drawing.Size(40, 13);
            this.lblNgay_Batdau.TabIndex = 93;
            this.lblNgay_Batdau.Text = "Từ ngày";
            // 
            // lookUpEdit_Khachhang
            // 
            this.lookUpEdit_Khachhang.Location = new System.Drawing.Point(571, 15);
            this.lookUpEdit_Khachhang.Name = "lookUpEdit_Khachhang";
            this.lookUpEdit_Khachhang.Properties.AutoSearchColumnIndex = 2;
            this.lookUpEdit_Khachhang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit_Khachhang.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Khachhang", "Stt", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Khachhang", "Mã Khách hàng", 100),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Khachhang", "Tên Khách hàng", 100),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Diachi_Khachhang", "Địa chỉ", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Masothue", "Mã số thuế", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Dienthoai", "Điện thoại", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.lookUpEdit_Khachhang.Properties.DisplayMember = "Ten_Khachhang";
            this.lookUpEdit_Khachhang.Properties.NullText = "";
            this.lookUpEdit_Khachhang.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lookUpEdit_Khachhang.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit_Khachhang.Properties.ValueMember = "Id_Khachhang";
            this.lookUpEdit_Khachhang.Size = new System.Drawing.Size(300, 20);
            this.lookUpEdit_Khachhang.TabIndex = 109;
            // 
            // lblKhachhang
            // 
            this.lblKhachhang.Location = new System.Drawing.Point(500, 18);
            this.lblKhachhang.Name = "lblKhachhang";
            this.lblKhachhang.Size = new System.Drawing.Size(56, 13);
            this.lblKhachhang.TabIndex = 110;
            this.lblKhachhang.Text = "Khách hàng";
            // 
            // FrmRptWare_Hdbanhang_ByKhachhang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1129, 517);
            this.Name = "FrmRptWare_Hdbanhang_ByKhachhang";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_Header)).EndInit();
            this.panelControl_Header.ResumeLayout(false);
            this.panelControl_Header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Batdau.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Batdau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Khachhang.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dtNgay_Ketthuc;
        private DevExpress.XtraEditors.LabelControl lblNgay_Ketthuc;
        private DevExpress.XtraEditors.DateEdit dtNgay_Batdau;
        private DevExpress.XtraEditors.LabelControl lblNgay_Batdau;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_Khachhang;
        private DevExpress.XtraEditors.LabelControl lblKhachhang;
    }
}
