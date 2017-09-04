namespace Ecm.Reports.Forms
{
    partial class FrmRptware_Baocao_Tonghop
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
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.navBar_Baocao = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navItem_Tonghop_Hoadon_Muahang_Thue = new DevExpress.XtraNavBar.NavBarItem();
            this.navItem_Tonghop_Hoadon_Banhang_Thue = new DevExpress.XtraNavBar.NavBarItem();
            this.printControl_Baocao = new DevExpress.XtraPrinting.Control.PrintControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDieukien_Loc = new DevExpress.XtraEditors.LabelControl();
            this.dtNgay_Ketthuc = new DevExpress.XtraEditors.DateEdit();
            this.lblNgay_Batdau = new DevExpress.XtraEditors.LabelControl();
            this.lblNgay_Ketthuc = new DevExpress.XtraEditors.LabelControl();
            this.dtNgay_Batdau = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBar_Baocao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Batdau.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Batdau.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.LookAndFeel.SkinName = "Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // dockManager1
            // 
            this.dockManager1.Controller = this.barAndDockingController1;
            this.dockManager1.Form = this;
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.splitContainerControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 65);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1051, 595);
            this.panelControl1.TabIndex = 4;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.panelControl4);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.printControl_Baocao);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1051, 595);
            this.splitContainerControl1.SplitterPosition = 354;
            this.splitContainerControl1.TabIndex = 116;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.navBar_Baocao);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(0, 0);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(354, 595);
            this.panelControl4.TabIndex = 117;
            // 
            // navBar_Baocao
            // 
            this.navBar_Baocao.ActiveGroup = this.navBarGroup1;
            this.navBar_Baocao.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.navBar_Baocao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBar_Baocao.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1});
            this.navBar_Baocao.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navItem_Tonghop_Hoadon_Muahang_Thue,
            this.navItem_Tonghop_Hoadon_Banhang_Thue});
            this.navBar_Baocao.Location = new System.Drawing.Point(0, 0);
            this.navBar_Baocao.Name = "navBar_Baocao";
            this.navBar_Baocao.OptionsNavPane.ExpandedWidth = 354;
            this.navBar_Baocao.Size = new System.Drawing.Size(354, 595);
            this.navBar_Baocao.TabIndex = 1;
            this.navBar_Baocao.Text = "navBarControl1";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.navBarGroup1.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.navBarGroup1.Appearance.Options.UseFont = true;
            this.navBarGroup1.Appearance.Options.UseForeColor = true;
            this.navBarGroup1.Caption = "Chọn báo cáo";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navItem_Tonghop_Hoadon_Muahang_Thue),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navItem_Tonghop_Hoadon_Banhang_Thue)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // navItem_Tonghop_Hoadon_Muahang_Thue
            // 
            this.navItem_Tonghop_Hoadon_Muahang_Thue.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navItem_Tonghop_Hoadon_Muahang_Thue.Appearance.Options.UseFont = true;
            this.navItem_Tonghop_Hoadon_Muahang_Thue.Caption = "Tổng hợp hóa đơn mua hàng có thuế";
            this.navItem_Tonghop_Hoadon_Muahang_Thue.Name = "navItem_Tonghop_Hoadon_Muahang_Thue";
            this.navItem_Tonghop_Hoadon_Muahang_Thue.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navItem_Tonghop_Hoadon_Muahang_Thue_LinkClicked);
            // 
            // navItem_Tonghop_Hoadon_Banhang_Thue
            // 
            this.navItem_Tonghop_Hoadon_Banhang_Thue.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navItem_Tonghop_Hoadon_Banhang_Thue.Appearance.Options.UseFont = true;
            this.navItem_Tonghop_Hoadon_Banhang_Thue.Caption = "Tổng hợp hóa đơn bán hàng có thuế";
            this.navItem_Tonghop_Hoadon_Banhang_Thue.Name = "navItem_Tonghop_Hoadon_Banhang_Thue";
            this.navItem_Tonghop_Hoadon_Banhang_Thue.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navItem_Tonghop_Hoadon_Banhang_Thue_LinkClicked);
            // 
            // printControl_Baocao
            // 
            this.printControl_Baocao.BackColor = System.Drawing.Color.Empty;
            this.printControl_Baocao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printControl_Baocao.ForeColor = System.Drawing.Color.Empty;
            this.printControl_Baocao.IsMetric = false;
            this.printControl_Baocao.Location = new System.Drawing.Point(0, 0);
            this.printControl_Baocao.Name = "printControl_Baocao";
            this.printControl_Baocao.Size = new System.Drawing.Size(692, 595);
            this.printControl_Baocao.TabIndex = 0;
            this.printControl_Baocao.TooltipFont = new System.Drawing.Font("Tahoma", 8.25F);
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.tableLayoutPanel1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 660);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1051, 89);
            this.panelControl2.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lblDieukien_Loc, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtNgay_Ketthuc, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblNgay_Batdau, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblNgay_Ketthuc, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtNgay_Batdau, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1051, 89);
            this.tableLayoutPanel1.TabIndex = 114;
            // 
            // lblDieukien_Loc
            // 
            this.lblDieukien_Loc.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDieukien_Loc.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblDieukien_Loc.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.tableLayoutPanel1.SetColumnSpan(this.lblDieukien_Loc, 2);
            this.lblDieukien_Loc.Location = new System.Drawing.Point(3, 3);
            this.lblDieukien_Loc.Name = "lblDieukien_Loc";
            this.lblDieukien_Loc.Size = new System.Drawing.Size(121, 19);
            this.lblDieukien_Loc.TabIndex = 113;
            this.lblDieukien_Loc.Text = "Chọn điều kiện";
            // 
            // dtNgay_Ketthuc
            // 
            this.dtNgay_Ketthuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtNgay_Ketthuc.EditValue = null;
            this.dtNgay_Ketthuc.Location = new System.Drawing.Point(369, 28);
            this.dtNgay_Ketthuc.Name = "dtNgay_Ketthuc";
            this.dtNgay_Ketthuc.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgay_Ketthuc.Properties.Appearance.Options.UseFont = true;
            this.dtNgay_Ketthuc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgay_Ketthuc.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtNgay_Ketthuc.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgay_Ketthuc.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtNgay_Ketthuc.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgay_Ketthuc.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtNgay_Ketthuc.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtNgay_Ketthuc.Size = new System.Drawing.Size(202, 26);
            this.dtNgay_Ketthuc.TabIndex = 107;
            // 
            // lblNgay_Batdau
            // 
            this.lblNgay_Batdau.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNgay_Batdau.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgay_Batdau.Location = new System.Drawing.Point(3, 28);
            this.lblNgay_Batdau.Name = "lblNgay_Batdau";
            this.lblNgay_Batdau.Size = new System.Drawing.Size(57, 20);
            this.lblNgay_Batdau.TabIndex = 105;
            this.lblNgay_Batdau.Text = "Từ ngày";
            // 
            // lblNgay_Ketthuc
            // 
            this.lblNgay_Ketthuc.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNgay_Ketthuc.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgay_Ketthuc.Location = new System.Drawing.Point(294, 28);
            this.lblNgay_Ketthuc.Name = "lblNgay_Ketthuc";
            this.lblNgay_Ketthuc.Size = new System.Drawing.Size(69, 20);
            this.lblNgay_Ketthuc.TabIndex = 104;
            this.lblNgay_Ketthuc.Text = "Đến ngày";
            // 
            // dtNgay_Batdau
            // 
            this.dtNgay_Batdau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtNgay_Batdau.EditValue = null;
            this.dtNgay_Batdau.Location = new System.Drawing.Point(66, 28);
            this.dtNgay_Batdau.Name = "dtNgay_Batdau";
            this.dtNgay_Batdau.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgay_Batdau.Properties.Appearance.Options.UseFont = true;
            this.dtNgay_Batdau.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgay_Batdau.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtNgay_Batdau.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgay_Batdau.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtNgay_Batdau.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgay_Batdau.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtNgay_Batdau.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtNgay_Batdau.Size = new System.Drawing.Size(202, 26);
            this.dtNgay_Batdau.TabIndex = 106;
            // 
            // FrmRptware_Baocao_Tonghop
            // 
            this.AllowPrint = true;
            this.AllowQuery = true;
            this.AllowRefresh = true;
            this.ClientSize = new System.Drawing.Size(1051, 749);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.EditMode = GoobizFrame.Windows.Forms.FormUpdateWithToolbar.EditModes.Separate;
            this.FormState = GoobizFrame.Windows.Forms.FormState.View;
            this.Name = "FrmRptware_Baocao_Tonghop";
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBar_Baocao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Ketthuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Batdau.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Batdau.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.DateEdit dtNgay_Ketthuc;
        private DevExpress.XtraEditors.LabelControl lblNgay_Ketthuc;
        private DevExpress.XtraEditors.DateEdit dtNgay_Batdau;
        private DevExpress.XtraEditors.LabelControl lblNgay_Batdau;
        private DevExpress.XtraEditors.LabelControl lblDieukien_Loc;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraNavBar.NavBarControl navBar_Baocao;
        private DevExpress.XtraNavBar.NavBarItem navItem_Tonghop_Hoadon_Muahang_Thue;
        private DevExpress.XtraNavBar.NavBarItem navItem_Tonghop_Hoadon_Banhang_Thue;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraPrinting.Control.PrintControl printControl_Baocao;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
