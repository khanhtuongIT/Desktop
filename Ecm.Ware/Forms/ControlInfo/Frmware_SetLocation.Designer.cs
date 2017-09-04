namespace SunLine.Ware.Forms
{
    partial class Frmware_SetLocation
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
            this.lookUpEditMa_Kho_Hanghoa = new DevExpress.XtraEditors.LookUpEdit();
            this.lblKho_Hanghoa = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditMa_Kho_Hanghoa.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.LookAndFeel.SkinName = "Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // lookUpEditMa_Kho_Hanghoa
            // 
            this.lookUpEditMa_Kho_Hanghoa.Location = new System.Drawing.Point(75, 39);
            this.lookUpEditMa_Kho_Hanghoa.Name = "lookUpEditMa_Kho_Hanghoa";
            this.lookUpEditMa_Kho_Hanghoa.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpEditMa_Kho_Hanghoa.Properties.Appearance.Options.UseFont = true;
            this.lookUpEditMa_Kho_Hanghoa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditMa_Kho_Hanghoa.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Cuahang_Ban", "STT", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Cuahang_Ban", "Mã KV", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Cuahang_Ban", "Tên KV", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.lookUpEditMa_Kho_Hanghoa.Properties.DisplayMember = "Ten_Cuahang_Ban";
            this.lookUpEditMa_Kho_Hanghoa.Properties.NullText = "";
            this.lookUpEditMa_Kho_Hanghoa.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditMa_Kho_Hanghoa.Properties.ValueMember = "Id_Cuahang_Ban";
            this.lookUpEditMa_Kho_Hanghoa.Size = new System.Drawing.Size(253, 26);
            this.lookUpEditMa_Kho_Hanghoa.TabIndex = 99;
            // 
            // lblKho_Hanghoa
            // 
            this.lblKho_Hanghoa.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKho_Hanghoa.Appearance.Options.UseFont = true;
            this.lblKho_Hanghoa.Location = new System.Drawing.Point(13, 42);
            this.lblKho_Hanghoa.Name = "lblKho_Hanghoa";
            this.lblKho_Hanghoa.Size = new System.Drawing.Size(56, 20);
            this.lblKho_Hanghoa.TabIndex = 98;
            this.lblKho_Hanghoa.Text = "Khu vực";
            // 
            // Frmware_SetLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 398);
            this.Controls.Add(this.lookUpEditMa_Kho_Hanghoa);
            this.Controls.Add(this.lblKho_Hanghoa);
            this.Name = "Frmware_SetLocation";
            this.toolTipController1.SetSuperTip(this, null);
            this.Text = "Frmware_SetLocation";
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditMa_Kho_Hanghoa.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lookUpEditMa_Kho_Hanghoa;
        private DevExpress.XtraEditors.LabelControl lblKho_Hanghoa;
    }
}