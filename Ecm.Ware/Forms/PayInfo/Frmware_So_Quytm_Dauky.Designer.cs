namespace Ecm.Ware.Forms
{
    partial class Frmware_So_Quytm_Dauky
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
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblSotien = new DevExpress.XtraEditors.LabelControl();
            this.txtSotien = new DevExpress.XtraEditors.TextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.lblDonvi_Tiente = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSotien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.LookAndFeel.SkinName = "Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tableLayoutPanel1.SetColumnSpan(this.lblTitle, 3);
            this.lblTitle.Location = new System.Drawing.Point(56, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(198, 19);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Tạo quỹ tiền mặt đầu kỳ";
            // 
            // lblSotien
            // 
            this.lblSotien.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSotien.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblSotien.Location = new System.Drawing.Point(3, 51);
            this.lblSotien.Name = "lblSotien";
            this.lblSotien.Size = new System.Drawing.Size(49, 19);
            this.lblSotien.TabIndex = 11;
            this.lblSotien.Text = "Số tiền";
            // 
            // txtSotien
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtSotien, 2);
            this.txtSotien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSotien.Location = new System.Drawing.Point(58, 48);
            this.txtSotien.Name = "txtSotien";
            this.txtSotien.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtSotien.Properties.Appearance.Options.UseFont = true;
            this.txtSotien.Properties.Appearance.Options.UseTextOptions = true;
            this.txtSotien.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtSotien.Properties.DisplayFormat.FormatString = "n0";
            this.txtSotien.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSotien.Properties.EditFormat.FormatString = "n0";
            this.txtSotien.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSotien.Properties.Mask.EditMask = "n0";
            this.txtSotien.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSotien.Properties.Mask.ShowPlaceHolders = false;
            this.txtSotien.Size = new System.Drawing.Size(250, 26);
            this.txtSotien.TabIndex = 3;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.tableLayoutPanel1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 65);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(352, 172);
            this.panelControl1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnClose, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblSotien, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnAdd, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtSotien, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblTitle, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDonvi_Tiente, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(348, 168);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.Location = new System.Drawing.Point(186, 99);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.Location = new System.Drawing.Point(58, 99);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblDonvi_Tiente
            // 
            this.lblDonvi_Tiente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDonvi_Tiente.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.lblDonvi_Tiente.Location = new System.Drawing.Point(177, 80);
            this.lblDonvi_Tiente.Name = "lblDonvi_Tiente";
            this.lblDonvi_Tiente.Size = new System.Drawing.Size(93, 13);
            this.lblDonvi_Tiente.TabIndex = 14;
            this.lblDonvi_Tiente.Text = "Đơn vị : ngàn đồng";
            // 
            // Frmware_So_Quytm_Dauky
            // 
            this.AllowRefresh = true;
            this.ClientSize = new System.Drawing.Size(352, 237);
            this.Controls.Add(this.panelControl1);
            this.EditMode = GoobizFrame.Windows.Forms.FormUpdateWithToolbar.EditModes.Separate;
            this.FormState = GoobizFrame.Windows.Forms.FormState.View;
            this.Name = "Frmware_So_Quytm_Dauky";
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSotien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblSotien;
        private DevExpress.XtraEditors.TextEdit txtSotien;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.LabelControl lblDonvi_Tiente;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

    }
}
