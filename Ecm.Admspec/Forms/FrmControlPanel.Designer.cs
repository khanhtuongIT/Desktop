namespace SunLine.Admspec.Forms
{
    partial class FrmControlPanel
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
            this.xtraTabPanes = new DevExpress.XtraTab.XtraTabControl();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabPanes)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabPanes
            // 
            this.xtraTabPanes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabPanes.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
            this.xtraTabPanes.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal;
            this.xtraTabPanes.Location = new System.Drawing.Point(0, 0);
            this.xtraTabPanes.Margin = new System.Windows.Forms.Padding(5);
            this.xtraTabPanes.Name = "xtraTabPanes";
            this.xtraTabPanes.Size = new System.Drawing.Size(950, 460);
            this.xtraTabPanes.TabIndex = 0;
            this.xtraTabPanes.Text = "xtraTabControl1";
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "Nhập xuất hàng hóa";
            this.navBarGroup2.Expanded = true;
            this.navBarGroup2.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // navBarItem1
            // 
            this.navBarItem1.Caption = "Dự trù mua hàng hóa và nguyên liệu";
            this.navBarItem1.Name = "navBarItem1";
            // 
            // FrmControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 460);
            this.Controls.Add(this.xtraTabPanes);
            this.Name = "FrmControlPanel";
            this.Text = "FrmControlPanel";
            this.Activated += new System.EventHandler(this.FrmControlPanel_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabPanes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabPanes;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarItem navBarItem1;





    }
}