namespace SunLine.Ware.Forms
{
    partial class Frmware_ChangeDocStatus_Dialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmware_ChangeDocStatus_Dialog));
            this.lookUpEdit_Nhansu = new DevExpress.XtraEditors.LookUpEdit();
            this.lblNguoi_Lap = new DevExpress.XtraEditors.LabelControl();
            this.dtNgay = new DevExpress.XtraEditors.DateEdit();
            this.lblNgay_Muahang = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtGhichu = new DevExpress.XtraEditors.MemoEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Nhansu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhichu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lookUpEdit_Nhansu
            // 
            this.lookUpEdit_Nhansu.EditValue = "";
            this.lookUpEdit_Nhansu.Enabled = false;
            this.lookUpEdit_Nhansu.Location = new System.Drawing.Point(77, 25);
            this.lookUpEdit_Nhansu.Name = "lookUpEdit_Nhansu";
            this.lookUpEdit_Nhansu.Properties.AutoSearchColumnIndex = 2;
            this.lookUpEdit_Nhansu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit_Nhansu.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Nhansu", "Id", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Nhansu", "Mã nhân sự", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Nhansu", "Họ tên", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.lookUpEdit_Nhansu.Properties.DisplayMember = "Ten_Nhansu";
            this.lookUpEdit_Nhansu.Properties.NullText = "";
            this.lookUpEdit_Nhansu.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lookUpEdit_Nhansu.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit_Nhansu.Properties.ValueMember = "Id_Nhansu";
            this.lookUpEdit_Nhansu.Size = new System.Drawing.Size(430, 20);
            this.lookUpEdit_Nhansu.TabIndex = 90;
            // 
            // lblNguoi_Lap
            // 
            this.lblNguoi_Lap.Location = new System.Drawing.Point(25, 29);
            this.lblNguoi_Lap.Name = "lblNguoi_Lap";
            this.lblNguoi_Lap.Size = new System.Drawing.Size(40, 13);
            this.lblNguoi_Lap.TabIndex = 91;
            this.lblNguoi_Lap.Text = "Nhân sự";
            // 
            // dtNgay
            // 
            this.dtNgay.EditValue = "";
            this.dtNgay.Enabled = false;
            this.dtNgay.Location = new System.Drawing.Point(77, 51);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgay.Properties.Mask.EditMask = "";
            this.dtNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtNgay.Size = new System.Drawing.Size(430, 20);
            this.dtNgay.TabIndex = 92;
            // 
            // lblNgay_Muahang
            // 
            this.lblNgay_Muahang.Location = new System.Drawing.Point(25, 55);
            this.lblNgay_Muahang.Name = "lblNgay_Muahang";
            this.lblNgay_Muahang.Size = new System.Drawing.Size(25, 13);
            this.lblNgay_Muahang.TabIndex = 93;
            this.lblNgay_Muahang.Text = "Ngày";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(25, 80);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(35, 13);
            this.labelControl1.TabIndex = 93;
            this.labelControl1.Text = "Ghi chú";
            // 
            // txtGhichu
            // 
            this.txtGhichu.Location = new System.Drawing.Point(77, 77);
            this.txtGhichu.Name = "txtGhichu";
            this.txtGhichu.Size = new System.Drawing.Size(430, 96);
            this.txtGhichu.TabIndex = 94;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(319, 188);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 95;
            this.btnOK.Text = "Chấp nhận";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(400, 188);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(107, 23);
            this.btnCancel.TabIndex = 95;
            this.btnCancel.Text = "Không chấp nhận";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Frmware_ChangeDocStatus_Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 234);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtGhichu);
            this.Controls.Add(this.dtNgay);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lblNgay_Muahang);
            this.Controls.Add(this.lookUpEdit_Nhansu);
            this.Controls.Add(this.lblNguoi_Lap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frmware_ChangeDocStatus_Dialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frmware_ChangeDocStatus_Dialog";
            this.Load += new System.EventHandler(this.Frmware_ChangeDocStatus_Dialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Nhansu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhichu.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_Nhansu;
        private DevExpress.XtraEditors.LabelControl lblNguoi_Lap;
        private DevExpress.XtraEditors.DateEdit dtNgay;
        private DevExpress.XtraEditors.LabelControl lblNgay_Muahang;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit txtGhichu;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.Timer timer1;
    }
}