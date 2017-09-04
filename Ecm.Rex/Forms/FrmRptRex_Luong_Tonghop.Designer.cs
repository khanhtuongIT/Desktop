namespace Ecm.Rex.Forms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;using GoobizFrame.Windows.Forms;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraBars.Docking;
    using DevExpress.XtraNavBar;
    using DevExpress.Utils;

    partial class FrmRptRex_Luong_Tonghop
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

        private void InitializeComponent()
        {
            this.components = new Container();
            this.dockManager1 = new DockManager(this.components);
            this.dockPanel1 = new DockPanel();
            this.dockPanel1_Container = new ControlContainer();
            this.navBarControl1 = new NavBarControl();
            this.navBarGroup1 = new NavBarGroup();
            this.navRex_Dongia_Luong_Congviec = new NavBarItem();
            this.navRex_Dongia_Luong_Hieunang = new NavBarItem();
            this.navRex_Tamung_Ky1 = new NavBarItem();
            this.navPrint_Bangchitiet = new NavBarItem();
            this.navPrint_BangATM = new NavBarItem();
            this.navPrint_BangTM = new NavBarItem();
            this.navPrint_BangAll = new NavBarItem();
            this.navChamcong = new NavBarItem();
            this.navKetqua_Sx_Sum = new NavBarItem();
            this.navKetqua_Sx_Chitiet = new NavBarItem();
            this.navTrichnop_BHXH = new NavBarItem();
            this.navTrichnop_Kphi_Cdoan = new NavBarItem();
            this.navThongke_Tncn = new NavBarItem();
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.lblBophan = new LabelControl();
            this.labelControl1 = new LabelControl();
            this.dtThangNam = new DateEdit();
            this.lookUpEdit_Bophan = new LookUpEdit();
            base.panelControl_Header.BeginInit();
            base.splitContainerControl1.BeginInit();
            base.splitContainerControl1.SuspendLayout();
            this.dockManager1.BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            this.navBarControl1.BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.dtThangNam.Properties.VistaTimeProperties.BeginInit();
            this.dtThangNam.Properties.BeginInit();
            this.lookUpEdit_Bophan.Properties.BeginInit();
            base.SuspendLayout();
            base.printControl1.Size = new Size(820, 0x185);
            base.splitContainerControl1.Location = new Point(0x127, 0x2f);
            base.splitContainerControl1.Size = new Size(820, 0x185);
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DockPanel[] { this.dockPanel1 });
            this.dockManager1.TopZIndexControls.AddRange(new string[] { "DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.StatusBar", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl" });
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DockingStyle.Left;
            this.dockPanel1.ID = new Guid("5a7e33aa-0d2a-4f6a-976d-476a607263ca");
            this.dockPanel1.Location = new Point(0, 0x2f);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.OriginalSize = new Size(0x127, 200);
            this.dockPanel1.Size = new Size(0x127, 0x185);
            this.dockPanel1.Text = "T\x00f9y chọn";
            this.dockPanel1_Container.Controls.Add(this.navBarControl1);
            this.dockPanel1_Container.Controls.Add(this.tableLayoutPanel1);
            this.dockPanel1_Container.Location = new Point(4, 0x17);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new Size(0x11f, 0x16a);
            this.dockPanel1_Container.TabIndex = 0;
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.Dock = DockStyle.Fill;
            this.navBarControl1.Groups.AddRange(new NavBarGroup[] { this.navBarGroup1 });
            this.navBarControl1.Items.AddRange(new NavBarItem[] { this.navRex_Dongia_Luong_Congviec, this.navRex_Dongia_Luong_Hieunang, this.navRex_Tamung_Ky1, this.navPrint_Bangchitiet, this.navPrint_BangATM, this.navPrint_BangTM, this.navPrint_BangAll, this.navChamcong, this.navKetqua_Sx_Sum, this.navKetqua_Sx_Chitiet, this.navTrichnop_BHXH, this.navTrichnop_Kphi_Cdoan, this.navThongke_Tncn });
            this.navBarControl1.Location = new Point(0, 0x39);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 0x11f;
            this.navBarControl1.Size = new Size(0x11f, 0x131);
            this.navBarControl1.TabIndex = 7;
            this.navBarControl1.Text = "navBarControl1";
            this.navBarControl1.LinkClicked += new NavBarLinkEventHandler(this.navBarControl1_LinkClicked);
            this.navBarGroup1.Caption = "B\x00e1o c\x00e1o";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.ItemLinks.AddRange(new NavBarItemLink[] { new NavBarItemLink(this.navRex_Dongia_Luong_Congviec), new NavBarItemLink(this.navRex_Dongia_Luong_Hieunang), new NavBarItemLink(this.navRex_Tamung_Ky1), new NavBarItemLink(this.navPrint_Bangchitiet), new NavBarItemLink(this.navPrint_BangATM), new NavBarItemLink(this.navPrint_BangTM), new NavBarItemLink(this.navPrint_BangAll), new NavBarItemLink(this.navChamcong), new NavBarItemLink(this.navKetqua_Sx_Sum), new NavBarItemLink(this.navKetqua_Sx_Chitiet), new NavBarItemLink(this.navTrichnop_BHXH), new NavBarItemLink(this.navTrichnop_Kphi_Cdoan), new NavBarItemLink(this.navThongke_Tncn) });
            this.navBarGroup1.Name = "navBarGroup1";
            this.navRex_Dongia_Luong_Congviec.Caption = "Đơn gi\x00e1 c\x00f4ng việc";
            this.navRex_Dongia_Luong_Congviec.Name = "navRex_Dongia_Luong_Congviec";
            this.navRex_Dongia_Luong_Hieunang.Caption = "Đơn gi\x00e1 định mức";
            this.navRex_Dongia_Luong_Hieunang.Name = "navRex_Dongia_Luong_Hieunang";
            this.navRex_Tamung_Ky1.Caption = "Tạm ứng kỳ 1";
            this.navRex_Tamung_Ky1.Name = "navRex_Tamung_Ky1";
            this.navPrint_Bangchitiet.Caption = "Bảng tiền lương chi tiết";
            this.navPrint_Bangchitiet.Name = "navPrint_Bangchitiet";
            this.navPrint_BangATM.Caption = "Bảng tiền lương ATM";
            this.navPrint_BangATM.Name = "navPrint_BangATM";
            this.navPrint_BangTM.Caption = "Bảng tiền lương tiền mặt";
            this.navPrint_BangTM.Name = "navPrint_BangTM";
            this.navPrint_BangAll.Caption = "Bảng tiền lương";
            this.navPrint_BangAll.Name = "navPrint_BangAll";
            this.navChamcong.Caption = "Chấm c\x00f4ng";
            this.navChamcong.Name = "navChamcong";
            this.navKetqua_Sx_Sum.Caption = "Bảng sản lượng";
            this.navKetqua_Sx_Sum.Name = "navKetqua_Sx_Sum";
            this.navKetqua_Sx_Chitiet.Caption = "Bảng sản lượng chi tiết";
            this.navKetqua_Sx_Chitiet.Name = "navKetqua_Sx_Chitiet";
            this.navTrichnop_BHXH.Caption = "Tr\x00edch nộp BHXH";
            this.navTrichnop_BHXH.Name = "navTrichnop_BHXH";
            this.navTrichnop_Kphi_Cdoan.Caption = "Tr\x00edch nộp kinh ph\x00ed c\x00f4ng đo\x00e0n";
            this.navTrichnop_Kphi_Cdoan.Name = "navTrichnop_Kphi_Cdoan";
            this.navThongke_Tncn.Caption = "Thống k\x00ea thu nhập c\x00e1 nh\x00e2n";
            this.navThongke_Tncn.Name = "navThongke_Tncn";
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20f));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20f));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20f));
            this.tableLayoutPanel1.Controls.Add(this.lblBophan, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtThangNam, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lookUpEdit_Bophan, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new  System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            this.tableLayoutPanel1.Size = new Size(0x11f, 0x39);
            this.tableLayoutPanel1.TabIndex = 6;
            this.lblBophan.Anchor = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left;
            this.lblBophan.Location = new  System.Drawing.Point(3, 0x20);
            this.lblBophan.Name = "lblBophan";
            this.lblBophan.Size = new Size(0x27, 13);
            this.lblBophan.TabIndex = 2;
            this.lblBophan.Text = "Bộ phận";
            this.labelControl1.Anchor = AnchorStyles.Right | AnchorStyles.Left;
            this.labelControl1.Location = new Point(3, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(0x35, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Th\x00e1ng năm";
            this.dtThangNam.Anchor = AnchorStyles.Right | AnchorStyles.Left;
            this.dtThangNam.EditValue = null;
            this.dtThangNam.Location = new Point(0x3e, 3);
            this.dtThangNam.Name = "dtThangNam";
            this.dtThangNam.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.dtThangNam.Properties.DisplayFormat.FormatString = "MM/yyyy";
            this.dtThangNam.Properties.DisplayFormat.FormatType = FormatType.DateTime;
            this.dtThangNam.Properties.EditFormat.FormatString = "MM/yyyy";
            this.dtThangNam.Properties.EditFormat.FormatType = FormatType.DateTime;
            this.dtThangNam.Properties.Mask.EditMask = "MM/yyyy";
            this.dtThangNam.Properties.VistaTimeProperties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.dtThangNam.Size = new Size(0xde, 20);
            this.dtThangNam.TabIndex = 1;
            this.dtThangNam.EditValueChanged += new EventHandler(this.dtThangNam_EditValueChanged);
            this.lookUpEdit_Bophan.Anchor = AnchorStyles.Right | AnchorStyles.Left;
            this.lookUpEdit_Bophan.Location = new Point(0x3e, 0x1d);
            this.lookUpEdit_Bophan.Name = "lookUpEdit_Bophan";
            this.lookUpEdit_Bophan.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            this.lookUpEdit_Bophan.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.lookUpEdit_Bophan.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("Id_Bophan", "STT"), new LookUpColumnInfo("Ten_Bophan_Order", "BP"), new LookUpColumnInfo("Ma_Bophan", "M\x00e3 BP"), new LookUpColumnInfo("Ten_Bophan", "T\x00ean BP") });
            this.lookUpEdit_Bophan.Properties.DisplayMember = "Ten_Bophan";
            this.lookUpEdit_Bophan.Properties.NullText = "";
            this.lookUpEdit_Bophan.Properties.SearchMode = SearchMode.AutoComplete;
            this.lookUpEdit_Bophan.Properties.TextEditStyle = TextEditStyles.Standard;
            this.lookUpEdit_Bophan.Properties.ValueMember = "Id_Bophan";
            this.lookUpEdit_Bophan.Size = new Size(0xde, 20);
            this.lookUpEdit_Bophan.TabIndex = 3;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x47a, 0x1d0);
            base.Controls.Add(this.dockPanel1);
            base.Name = "FrmRptRex_Luong_Tonghop";
            this.Text = "FrmRptRex_Luong_Tonghop";
            base.Controls.SetChildIndex(this.dockPanel1, 0);
            base.Controls.SetChildIndex(base.splitContainerControl1, 0);
            base.panelControl_Header.EndInit();
            base.splitContainerControl1.EndInit();
            base.splitContainerControl1.ResumeLayout(false);
            this.dockManager1.EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.navBarControl1.EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.dtThangNam.Properties.VistaTimeProperties.EndInit();
            this.dtThangNam.Properties.EndInit();
            this.lookUpEdit_Bophan.Properties.EndInit();
            base.ResumeLayout(false);
        }
        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private System.Data.DataSet dsBophan;
        private System.Data.DataSet dsrex_Luong_Tonghop = new DataSet();
        private DevExpress.XtraEditors.DateEdit dtThangNam;
        private object id_kyluong;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblBophan;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_Bophan;
        private DevExpress.XtraNavBar. NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem navChamcong;
        private DevExpress.XtraNavBar.NavBarItem navKetqua_Sx_Chitiet;
        private DevExpress.XtraNavBar.NavBarItem navKetqua_Sx_Sum;
        private DevExpress.XtraNavBar.NavBarItem navPrint_BangAll;
        private DevExpress.XtraNavBar.NavBarItem navPrint_BangATM;
        private DevExpress.XtraNavBar.NavBarItem navPrint_Bangchitiet;
        private DevExpress.XtraNavBar.NavBarItem navPrint_BangTM;
        private DevExpress.XtraNavBar.NavBarItem navRex_Dongia_Luong_Congviec;
        private DevExpress.XtraNavBar.NavBarItem navRex_Dongia_Luong_Hieunang;
        private DevExpress.XtraNavBar.NavBarItem navRex_Tamung_Ky1;
        private DevExpress.XtraNavBar.NavBarItem navThongke_Tncn;
        private DevExpress.XtraNavBar.NavBarItem navTrichnop_BHXH;
        private DevExpress.XtraNavBar.NavBarItem navTrichnop_Kphi_Cdoan;
        private Ecm.WebReferences.MasterService.MasterService objMasterTables = new  WebReferences.MasterService.MasterService();
        //private Ecm.WebReferences.Pro.Pro objPro = new WebReferences.Pro.Pro();
        private WebReferences.RexService.RexService objRex = new   WebReferences.RexService.RexService();
        private Reports.rptRex_Chamcong_Thang rptRex_Chamcong_Thang;
        private Reports.RptRex_Luongtonghop_Bhxh rptRex_Luongtonghop_Bhxh;
        private Reports.RptRex_Tamung_Ky1 rptRex_Tamung_Ky1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}