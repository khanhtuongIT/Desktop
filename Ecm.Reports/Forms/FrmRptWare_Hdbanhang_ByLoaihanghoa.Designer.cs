namespace SunLine.Reports.Forms
{
    partial class FrmRptWare_Hdbanhang_ByLoaihanghoa
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
            this.lookUpEditMa_Loai_Hanghoa = new DevExpress.XtraEditors.LookUpEdit();
            this.lblLoai_Hanghoa = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_Header)).BeginInit();
            this.panelControl_Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Batdau.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Batdau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditMa_Loai_Hanghoa.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // printControl1
            // 
            this.printControl1.Location = new System.Drawing.Point(0, 76);
            this.printControl1.Size = new System.Drawing.Size(1129, 416);
            // 
            // panelControl_Header
            // 
            this.panelControl_Header.Controls.Add(this.lookUpEditMa_Loai_Hanghoa);
            this.panelControl_Header.Controls.Add(this.lblLoai_Hanghoa);
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
            // lookUpEditMa_Loai_Hanghoa
            // 
            this.lookUpEditMa_Loai_Hanghoa.Location = new System.Drawing.Point(566, 15);
            this.lookUpEditMa_Loai_Hanghoa.Name = "lookUpEditMa_Loai_Hanghoa";
            this.lookUpEditMa_Loai_Hanghoa.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpEditMa_Loai_Hanghoa.Properties.Appearance.Options.UseFont = true;
            this.lookUpEditMa_Loai_Hanghoa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditMa_Loai_Hanghoa.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Loai_Hanghoa", "Mã", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Loai_Hanghoa_Ban", "Id_Loai_Hanghoa_Ban", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Loai_Hanghoa_Mua", "Id_Loai_Hanghoa_Mua", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Loai_Hanghoa", "Tên", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.lookUpEditMa_Loai_Hanghoa.Properties.DisplayMember = "Ten_Loai_Hanghoa";
            this.lookUpEditMa_Loai_Hanghoa.Properties.NullText = "";
            this.lookUpEditMa_Loai_Hanghoa.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditMa_Loai_Hanghoa.Properties.ValueMember = "Ma_Loai_Hanghoa";
            this.lookUpEditMa_Loai_Hanghoa.Size = new System.Drawing.Size(352, 19);
            this.lookUpEditMa_Loai_Hanghoa.TabIndex = 97;
            // 
            // lblLoai_Hanghoa
            // 
            this.lblLoai_Hanghoa.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoai_Hanghoa.Appearance.Options.UseFont = true;
            this.lblLoai_Hanghoa.Location = new System.Drawing.Point(492, 18);
            this.lblLoai_Hanghoa.Name = "lblLoai_Hanghoa";
            this.lblLoai_Hanghoa.Size = new System.Drawing.Size(68, 13);
            this.lblLoai_Hanghoa.TabIndex = 96;
            this.lblLoai_Hanghoa.Text = "Loại hàng hóa";
            // 
            // FrmRptWare_Hdbanhang_ByLoaihanghoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1129, 517);
            this.Name = "FrmRptWare_Hdbanhang_ByLoaihanghoa";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_Header)).EndInit();
            this.panelControl_Header.ResumeLayout(false);
            this.panelControl_Header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Batdau.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Batdau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditMa_Loai_Hanghoa.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dtNgay_Ketthuc;
        private DevExpress.XtraEditors.LabelControl lblNgay_Ketthuc;
        private DevExpress.XtraEditors.DateEdit dtNgay_Batdau;
        private DevExpress.XtraEditors.LabelControl lblNgay_Batdau;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditMa_Loai_Hanghoa;
        private DevExpress.XtraEditors.LabelControl lblLoai_Hanghoa;
    }
}
