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
    using DevExpress.XtraEditors.Container;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraBars.Docking;
    using DevExpress.XtraNavBar;
    using DevExpress.Utils;
    using WebReferences.MasterService;
    using WebReferences.RexService;
    using Reports;

    partial class FrmRptRex_Thamgia_Tochuc
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
            this.components = new Container();
            this.dockManager1 = new DockManager(this.components);
            this.dockPanel1 = new DockPanel();
            this.dockPanel1_Container = new ControlContainer();
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.lookUpEdit_Bophan = new LookUpEdit();
            this.labelControl2 = new LabelControl();
            this.lblBophan = new LabelControl();
            this.lbl_Ngayketthuc = new LabelControl();
            this.dtNgay_Ketthuc = new DateEdit();
            this.lookUpEditDm_Tochuc = new LookUpEdit();
            this.chkInc_Nhanvien_Thoiviec = new CheckEdit();
            base.panelControl_Header.BeginInit();
            base.splitContainerControl1.BeginInit();
            base.splitContainerControl1.SuspendLayout();
            this.dockManager1.BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.lookUpEdit_Bophan.Properties.BeginInit();
            this.dtNgay_Ketthuc.Properties.VistaTimeProperties.BeginInit();
            this.dtNgay_Ketthuc.Properties.BeginInit();
            this.lookUpEditDm_Tochuc.Properties.BeginInit();
            this.chkInc_Nhanvien_Thoiviec.Properties.BeginInit();
            base.SuspendLayout();
            base.printControl1.Size = new Size(900, 0x185);
            base.splitContainerControl1.Location = new Point(0xd7, 0x2f);
            base.splitContainerControl1.Size = new Size(900, 0x185);
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DockPanel[] { this.dockPanel1 });
            this.dockManager1.TopZIndexControls.AddRange(new string[] { "DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.StatusBar", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl" });
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DockingStyle.Left;
            this.dockPanel1.ID = new Guid("24602a7b-911f-4e3d-a8cb-f23481704648");
            this.dockPanel1.Location = new Point(0, 0x2f);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.OriginalSize = new Size(0xd7, 200);
            this.dockPanel1.Size = new Size(0xd7, 0x185);
            this.dockPanel1.Text = "T\x00f9y chọn";
            this.dockPanel1_Container.Controls.Add(this.tableLayoutPanel1);
            this.dockPanel1_Container.Location = new Point(4, 0x17);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new Size(0xcf, 0x16a);
            this.dockPanel1_Container.TabIndex = 0;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            this.tableLayoutPanel1.Controls.Add(this.lookUpEdit_Bophan, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelControl2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblBophan, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Ngayketthuc, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtNgay_Ketthuc, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lookUpEditDm_Tochuc, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkInc_Nhanvien_Thoiviec, 1, 3);
            this.tableLayoutPanel1.Dock = DockStyle.Fill;
            this.tableLayoutPanel1.Location = new Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            this.tableLayoutPanel1.Size = new Size(0xcf, 0x16a);
            this.tableLayoutPanel1.TabIndex = 0;
            this.lookUpEdit_Bophan.Anchor = AnchorStyles.Right | AnchorStyles.Left;
            this.lookUpEdit_Bophan.Location = new Point(0x38, 0x1d);
            this.lookUpEdit_Bophan.Name = "lookUpEdit_Bophan";
            this.lookUpEdit_Bophan.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.lookUpEdit_Bophan.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("Id_Bophan", "STT"), new LookUpColumnInfo("Ten_Bophan_Order", "BP"), new LookUpColumnInfo("Ma_Bophan", "M\x00e3 BP"), new LookUpColumnInfo("Ten_Bophan", "T\x00ean BP") });
            this.lookUpEdit_Bophan.Properties.DisplayMember = "Ten_Bophan";
            this.lookUpEdit_Bophan.Properties.NullText = "";
            this.lookUpEdit_Bophan.Properties.SearchMode = SearchMode.AutoComplete;
            this.lookUpEdit_Bophan.Properties.TextEditStyle = TextEditStyles.Standard;
            this.lookUpEdit_Bophan.Properties.ValueMember = "Id_Bophan";
            this.lookUpEdit_Bophan.Size = new Size(0x94, 20);
            this.lookUpEdit_Bophan.TabIndex = 7;
            this.labelControl2.Location = new Point(3, 0x37);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(0x26, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Tổ chức";
            this.lblBophan.Location = new Point(3, 0x1d);
            this.lblBophan.Name = "lblBophan";
            this.lblBophan.Size = new Size(0x27, 13);
            this.lblBophan.TabIndex = 6;
            this.lblBophan.Text = "Bộ phận";
            this.lbl_Ngayketthuc.Location = new Point(3, 3);
            this.lbl_Ngayketthuc.Name = "lbl_Ngayketthuc";
            this.lbl_Ngayketthuc.Size = new Size(0x2f, 13);
            this.lbl_Ngayketthuc.TabIndex = 11;
            this.lbl_Ngayketthuc.Text = "Đến ng\x00e0y";
            this.dtNgay_Ketthuc.Anchor = AnchorStyles.Right | AnchorStyles.Left;
            this.dtNgay_Ketthuc.EditValue = null;
            this.dtNgay_Ketthuc.Location = new Point(0x38, 3);
            this.dtNgay_Ketthuc.Name = "dtNgay_Ketthuc";
            this.dtNgay_Ketthuc.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.dtNgay_Ketthuc.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtNgay_Ketthuc.Properties.DisplayFormat.FormatType = FormatType.DateTime;
            this.dtNgay_Ketthuc.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtNgay_Ketthuc.Properties.EditFormat.FormatType = FormatType.DateTime;
            this.dtNgay_Ketthuc.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtNgay_Ketthuc.Properties.VistaTimeProperties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.dtNgay_Ketthuc.Size = new Size(0x94, 20);
            this.dtNgay_Ketthuc.TabIndex = 10;
            this.lookUpEditDm_Tochuc.Anchor = AnchorStyles.Right | AnchorStyles.Left;
            this.lookUpEditDm_Tochuc.Location = new Point(0x38, 0x37);
            this.lookUpEditDm_Tochuc.Name = "lookUpEditDm_Tochuc";
            this.lookUpEditDm_Tochuc.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo), new EditorButton(ButtonPredefines.Delete) });
            this.lookUpEditDm_Tochuc.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("Id_Tochuc", "Id"), new LookUpColumnInfo("Ma_Tochuc", "M\x00e3"), new LookUpColumnInfo("Ten_Tochuc", "T\x00ean") });
            this.lookUpEditDm_Tochuc.Properties.DisplayMember = "Ten_Tochuc";
            this.lookUpEditDm_Tochuc.Properties.NullText = "";
            this.lookUpEditDm_Tochuc.Properties.TextEditStyle = TextEditStyles.Standard;
            this.lookUpEditDm_Tochuc.Properties.ValueMember = "Id_Tochuc";
            this.lookUpEditDm_Tochuc.Size = new Size(0x94, 20);
            this.lookUpEditDm_Tochuc.TabIndex = 12;
            this.lookUpEditDm_Tochuc.ButtonClick += new ButtonPressedEventHandler(this.lookUpEditDm_Tochuc_ButtonClick);
            this.chkInc_Nhanvien_Thoiviec.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.chkInc_Nhanvien_Thoiviec.Location = new Point(0x38, 0x51);
            this.chkInc_Nhanvien_Thoiviec.Name = "chkInc_Nhanvien_Thoiviec";
            this.chkInc_Nhanvien_Thoiviec.Properties.Caption = "Bao gồm NV th\x00f4i việc";
            this.chkInc_Nhanvien_Thoiviec.Size = new Size(0x94, 0x13);
            this.chkInc_Nhanvien_Thoiviec.TabIndex = 13;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x47a, 0x1d0);
            base.Controls.Add(this.dockPanel1);
            base.Name = "FrmRptRex_Thamgia_Tochuc";
            this.Text = "FrmRptRex_Thamgia_Tochuc";
            base.Controls.SetChildIndex(this.dockPanel1, 0);
            base.Controls.SetChildIndex(base.splitContainerControl1, 0);
            base.panelControl_Header.EndInit();
            base.splitContainerControl1.EndInit();
            base.splitContainerControl1.ResumeLayout(false);
            this.dockManager1.EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.lookUpEdit_Bophan.Properties.EndInit();
            this.dtNgay_Ketthuc.Properties.VistaTimeProperties.EndInit();
            this.dtNgay_Ketthuc.Properties.EndInit();
            this.lookUpEditDm_Tochuc.Properties.EndInit();
            this.chkInc_Nhanvien_Thoiviec.Properties.EndInit();
            base.ResumeLayout(false);
        }



        #endregion

        private CheckEdit chkInc_Nhanvien_Thoiviec;
        private DockManager dockManager1;
        private DockPanel dockPanel1;
        private ControlContainer dockPanel1_Container;
        private DataSet dsThongke;
        private DateEdit dtNgay_Ketthuc;
        private LabelControl labelControl2;
        private LabelControl lbl_Ngayketthuc;
        private LabelControl lblBophan;
        private LookUpEdit lookUpEdit_Bophan;
        private LookUpEdit lookUpEditDm_Tochuc;
        private MasterService objMasterTables = new MasterService();
        private RexService objRex = new RexService();
        private TableLayoutPanel tableLayoutPanel1;
        private RptRex_Thamgia_Tochuc_Thongke xreport;


    }
}