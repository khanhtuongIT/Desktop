namespace Ecm.SystemControl.DBUsers
{
    partial class DatabaseLogon
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
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelBackground = new DevExpress.XtraEditors.PanelControl();
            this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.buttonCardLogon = new DevExpress.XtraEditors.SimpleButton();
            this.buttonLogon = new DevExpress.XtraEditors.SimpleButton();
            this.textPassword = new DevExpress.XtraEditors.TextEdit();
            this.labelPassword = new DevExpress.XtraEditors.LabelControl();
            this.textUser = new DevExpress.XtraEditors.TextEdit();
            this.labelUser = new DevExpress.XtraEditors.LabelControl();
            this.checkLogonDomain = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBackground)).BeginInit();
            this.panelBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkLogonDomain.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.panelBackground);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(897, 776);
            this.panelControl2.TabIndex = 1;
            // 
            // panelBackground
            // 
            this.panelBackground.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelBackground.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelBackground.ContentImage = global::Ecm.SystemControl.Properties.Resources.LogonBg;
            this.panelBackground.Controls.Add(this.buttonCancel);
            this.panelBackground.Controls.Add(this.buttonCardLogon);
            this.panelBackground.Controls.Add(this.buttonLogon);
            this.panelBackground.Controls.Add(this.textPassword);
            this.panelBackground.Controls.Add(this.labelPassword);
            this.panelBackground.Controls.Add(this.textUser);
            this.panelBackground.Controls.Add(this.labelUser);
            this.panelBackground.Controls.Add(this.checkLogonDomain);
            this.panelBackground.Location = new System.Drawing.Point(264, 253);
            this.panelBackground.Name = "panelBackground";
            this.panelBackground.Size = new System.Drawing.Size(369, 271);
            this.panelBackground.TabIndex = 0;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.buttonCancel.Appearance.Options.UseFont = true;
            this.buttonCancel.Appearance.Options.UseForeColor = true;
            this.buttonCancel.Location = new System.Drawing.Point(249, 220);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonCardLogon
            // 
            this.buttonCardLogon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonCardLogon.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCardLogon.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.buttonCardLogon.Appearance.Options.UseFont = true;
            this.buttonCardLogon.Appearance.Options.UseForeColor = true;
            this.buttonCardLogon.Location = new System.Drawing.Point(45, 220);
            this.buttonCardLogon.Name = "buttonCardLogon";
            this.buttonCardLogon.Size = new System.Drawing.Size(129, 23);
            this.buttonCardLogon.TabIndex = 3;
            this.buttonCardLogon.Text = "Quét thẻ nhân viên";
            this.buttonCardLogon.Click += new System.EventHandler(this.buttonCardLogon_Click);
            // 
            // buttonLogon
            // 
            this.buttonLogon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonLogon.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogon.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.buttonLogon.Appearance.Options.UseFont = true;
            this.buttonLogon.Appearance.Options.UseForeColor = true;
            this.buttonLogon.Location = new System.Drawing.Point(174, 220);
            this.buttonLogon.Name = "buttonLogon";
            this.buttonLogon.Size = new System.Drawing.Size(75, 23);
            this.buttonLogon.TabIndex = 3;
            this.buttonLogon.Text = "Logon";
            this.buttonLogon.Click += new System.EventHandler(this.buttonLogon_Click);
            // 
            // textPassword
            // 
            this.textPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textPassword.EditValue = "";
            this.textPassword.Location = new System.Drawing.Point(108, 173);
            this.textPassword.Name = "textPassword";
            this.textPassword.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.textPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textPassword.Properties.Appearance.ForeColor = System.Drawing.Color.Crimson;
            this.textPassword.Properties.Appearance.Options.UseBackColor = true;
            this.textPassword.Properties.Appearance.Options.UseFont = true;
            this.textPassword.Properties.Appearance.Options.UseForeColor = true;
            this.textPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.textPassword.Properties.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(219, 20);
            this.textPassword.TabIndex = 1;
            // 
            // labelPassword
            // 
            this.labelPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPassword.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.labelPassword.Appearance.Options.UseFont = true;
            this.labelPassword.Appearance.Options.UseForeColor = true;
            this.labelPassword.Location = new System.Drawing.Point(35, 175);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(55, 16);
            this.labelPassword.TabIndex = 6;
            this.labelPassword.Text = "Password";
            // 
            // textUser
            // 
            this.textUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textUser.EditValue = "";
            this.textUser.Location = new System.Drawing.Point(108, 147);
            this.textUser.Name = "textUser";
            this.textUser.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.textUser.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textUser.Properties.Appearance.ForeColor = System.Drawing.Color.Crimson;
            this.textUser.Properties.Appearance.Options.UseBackColor = true;
            this.textUser.Properties.Appearance.Options.UseFont = true;
            this.textUser.Properties.Appearance.Options.UseForeColor = true;
            this.textUser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.textUser.Size = new System.Drawing.Size(219, 20);
            this.textUser.TabIndex = 0;
            // 
            // labelUser
            // 
            this.labelUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelUser.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUser.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.labelUser.Appearance.Options.UseFont = true;
            this.labelUser.Appearance.Options.UseForeColor = true;
            this.labelUser.Location = new System.Drawing.Point(35, 149);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(62, 16);
            this.labelUser.TabIndex = 5;
            this.labelUser.Text = "User name";
            // 
            // checkLogonDomain
            // 
            this.checkLogonDomain.Location = new System.Drawing.Point(106, 198);
            this.checkLogonDomain.Name = "checkLogonDomain";
            this.checkLogonDomain.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkLogonDomain.Properties.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.checkLogonDomain.Properties.Appearance.Options.UseFont = true;
            this.checkLogonDomain.Properties.Appearance.Options.UseForeColor = true;
            this.checkLogonDomain.Properties.Caption = "Logon Domain";
            this.checkLogonDomain.Size = new System.Drawing.Size(208, 19);
            this.checkLogonDomain.TabIndex = 2;
            this.checkLogonDomain.CheckedChanged += new System.EventHandler(this.checkLogonDomain_CheckedChanged);
            // 
            // DatabaseLogon
            // 
            this.AcceptButton = this.buttonLogon;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 776);
            this.Controls.Add(this.panelControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DatabaseLogon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logon";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DatabaseLogon_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBackground)).EndInit();
            this.panelBackground.ResumeLayout(false);
            this.panelBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkLogonDomain.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelBackground;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelUser;
        private DevExpress.XtraEditors.TextEdit textUser;
        private DevExpress.XtraEditors.LabelControl labelPassword;
        private DevExpress.XtraEditors.TextEdit textPassword;
        private DevExpress.XtraEditors.SimpleButton buttonLogon;
        private DevExpress.XtraEditors.SimpleButton buttonCancel;
        private DevExpress.XtraEditors.CheckEdit checkLogonDomain;
        private DevExpress.XtraEditors.SimpleButton buttonCardLogon;
    }
}