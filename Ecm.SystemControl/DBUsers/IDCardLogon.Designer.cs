namespace Ecm.SystemControl.DBUsers
{
    partial class IDCardLogon
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
            this.panelBackground = new DevExpress.XtraEditors.PanelControl();
            this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.buttonLogon = new DevExpress.XtraEditors.SimpleButton();
            this.textUser = new DevExpress.XtraEditors.TextEdit();
            this.labelUser = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelBackground)).BeginInit();
            this.panelBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBackground
            // 
            this.panelBackground.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelBackground.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelBackground.ContentImage = global::Ecm.SystemControl.Properties.Resources.LogonBg;
            this.panelBackground.Controls.Add(this.buttonCancel);
            this.panelBackground.Controls.Add(this.buttonLogon);
            this.panelBackground.Controls.Add(this.textUser);
            this.panelBackground.Controls.Add(this.labelUser);
            this.panelBackground.Location = new System.Drawing.Point(244, 96);
            this.panelBackground.Name = "panelBackground";
            this.panelBackground.Size = new System.Drawing.Size(369, 271);
            this.panelBackground.TabIndex = 1;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.buttonCancel.Appearance.Options.UseFont = true;
            this.buttonCancel.Appearance.Options.UseForeColor = true;
            this.buttonCancel.Location = new System.Drawing.Point(252, 215);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Thoát";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonLogon
            // 
            this.buttonLogon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonLogon.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogon.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.buttonLogon.Appearance.Options.UseFont = true;
            this.buttonLogon.Appearance.Options.UseForeColor = true;
            this.buttonLogon.Location = new System.Drawing.Point(102, 215);
            this.buttonLogon.Name = "buttonLogon";
            this.buttonLogon.Size = new System.Drawing.Size(147, 23);
            this.buttonLogon.TabIndex = 3;
            this.buttonLogon.Text = "Đăng nhập bằng tài khoản";
            this.buttonLogon.Click += new System.EventHandler(this.buttonLogon_Click);
            // 
            // textUser
            // 
            this.textUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textUser.Location = new System.Drawing.Point(42, 171);
            this.textUser.Name = "textUser";
            this.textUser.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.textUser.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUser.Properties.Appearance.ForeColor = System.Drawing.Color.Crimson;
            this.textUser.Properties.Appearance.Options.UseBackColor = true;
            this.textUser.Properties.Appearance.Options.UseFont = true;
            this.textUser.Properties.Appearance.Options.UseForeColor = true;
            this.textUser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.textUser.Properties.PasswordChar = '*';
            this.textUser.Size = new System.Drawing.Size(285, 35);
            this.textUser.TabIndex = 0;
            this.textUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textUser_KeyPress);
            this.textUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textUser_KeyDown);
            this.textUser.TextChanged += new System.EventHandler(this.textUser_TextChanged);
            // 
            // labelUser
            // 
            this.labelUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelUser.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUser.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.labelUser.Appearance.Options.UseFont = true;
            this.labelUser.Appearance.Options.UseForeColor = true;
            this.labelUser.Location = new System.Drawing.Point(137, 148);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(94, 19);
            this.labelUser.TabIndex = 5;
            this.labelUser.Text = "Mã nhân viên";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelBackground);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(856, 462);
            this.panelControl1.TabIndex = 2;
            // 
            // IDCardLogon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 462);
            this.Controls.Add(this.panelControl1);
            this.Name = "IDCardLogon";
            this.Text = "IDCardLogon";
            ((System.ComponentModel.ISupportInitialize)(this.panelBackground)).EndInit();
            this.panelBackground.ResumeLayout(false);
            this.panelBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelBackground;
        private DevExpress.XtraEditors.SimpleButton buttonCancel;
        private DevExpress.XtraEditors.SimpleButton buttonLogon;
        private DevExpress.XtraEditors.TextEdit textUser;
        private DevExpress.XtraEditors.LabelControl labelUser;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}