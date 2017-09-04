namespace Ecm.Rex.Forms
{
    partial class Frmrex_Chon_Thang
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.txtNam_Kyluong = new DevExpress.XtraEditors.SpinEdit();
            this.lblNam_Kyluong = new DevExpress.XtraEditors.LabelControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.barButton_Nhansu = new DevExpress.XtraBars.BarButtonItem();
            this.barButton_Loaihopdong = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnThang_Mot = new DevExpress.XtraEditors.SimpleButton();
            this.btnThang_Hai = new DevExpress.XtraEditors.SimpleButton();
            this.btnThang_Ba = new DevExpress.XtraEditors.SimpleButton();
            this.btnThang_Tu = new DevExpress.XtraEditors.SimpleButton();
            this.btnThang_Nam = new DevExpress.XtraEditors.SimpleButton();
            this.btnThang_Sau = new DevExpress.XtraEditors.SimpleButton();
            this.btnThang_Bay = new DevExpress.XtraEditors.SimpleButton();
            this.btnThang_Tam = new DevExpress.XtraEditors.SimpleButton();
            this.btnThang_Chin = new DevExpress.XtraEditors.SimpleButton();
            this.btnThang_Muoi = new DevExpress.XtraEditors.SimpleButton();
            this.btnThang_Muoimot = new DevExpress.XtraEditors.SimpleButton();
            this.btnThang_Muoihai = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam_Kyluong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTipController1
            // 
            this.toolTipController1.IconSize = DevExpress.Utils.ToolTipIconSize.Small;
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.LookAndFeel.SkinName = "Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.txtNam_Kyluong);
            this.panelControl3.Controls.Add(this.lblNam_Kyluong);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(2, 2);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(370, 36);
            this.panelControl3.TabIndex = 0;
            // 
            // txtNam_Kyluong
            // 
            this.txtNam_Kyluong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNam_Kyluong.EditValue = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.txtNam_Kyluong.Location = new System.Drawing.Point(278, 3);
            this.txtNam_Kyluong.Name = "txtNam_Kyluong";
            this.txtNam_Kyluong.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNam_Kyluong.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject1.Font = new System.Drawing.Font("Tahoma", 12F);
            serializableAppearanceObject1.Options.UseFont = true;
            this.txtNam_Kyluong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, false)});
            this.txtNam_Kyluong.Properties.IsFloatValue = false;
            this.txtNam_Kyluong.Properties.Mask.EditMask = "\\d{0,4}";
            this.txtNam_Kyluong.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtNam_Kyluong.Properties.MaxLength = 4;
            this.txtNam_Kyluong.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtNam_Kyluong.Properties.MinValue = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.txtNam_Kyluong.Size = new System.Drawing.Size(84, 26);
            this.txtNam_Kyluong.TabIndex = 19;
            // 
            // lblNam_Kyluong
            // 
            this.lblNam_Kyluong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNam_Kyluong.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblNam_Kyluong.Location = new System.Drawing.Point(173, 7);
            this.lblNam_Kyluong.Name = "lblNam_Kyluong";
            this.lblNam_Kyluong.Size = new System.Drawing.Size(33, 19);
            this.lblNam_Kyluong.TabIndex = 18;
            this.lblNam_Kyluong.Text = "Năm";
            // 
            // barManager1
            // 
            this.barManager1.Controller = this.barAndDockingController1;
            this.barManager1.DockControls.Add(this.barDockControl1);
            this.barManager1.DockControls.Add(this.barDockControl2);
            this.barManager1.DockControls.Add(this.barDockControl3);
            this.barManager1.DockControls.Add(this.barDockControl4);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButton_Nhansu,
            this.barButton_Loaihopdong});
            this.barManager1.MaxItemId = 2;
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Size = new System.Drawing.Size(374, 0);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 304);
            this.barDockControl2.Size = new System.Drawing.Size(374, 0);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 0);
            this.barDockControl3.Size = new System.Drawing.Size(0, 304);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(374, 0);
            this.barDockControl4.Size = new System.Drawing.Size(0, 304);
            // 
            // barButton_Nhansu
            // 
            this.barButton_Nhansu.Caption = "Cập nhật nhân sự";
            this.barButton_Nhansu.Id = 0;
            this.barButton_Nhansu.Name = "barButton_Nhansu";
            // 
            // barButton_Loaihopdong
            // 
            this.barButton_Loaihopdong.Caption = "Cập nhật loại hợp đồng";
            this.barButton_Loaihopdong.Id = 1;
            this.barButton_Loaihopdong.Name = "barButton_Loaihopdong";
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButton_Nhansu),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButton_Loaihopdong)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // btnThang_Mot
            // 
            this.btnThang_Mot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThang_Mot.Location = new System.Drawing.Point(3, 3);
            this.btnThang_Mot.Name = "btnThang_Mot";
            this.btnThang_Mot.Size = new System.Drawing.Size(86, 62);
            this.btnThang_Mot.TabIndex = 18;
            this.btnThang_Mot.Text = "Tháng 1";
            // 
            // btnThang_Hai
            // 
            this.btnThang_Hai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThang_Hai.Location = new System.Drawing.Point(95, 3);
            this.btnThang_Hai.Name = "btnThang_Hai";
            this.btnThang_Hai.Size = new System.Drawing.Size(86, 62);
            this.btnThang_Hai.TabIndex = 19;
            this.btnThang_Hai.Text = "Tháng 2";
            // 
            // btnThang_Ba
            // 
            this.btnThang_Ba.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThang_Ba.Location = new System.Drawing.Point(187, 3);
            this.btnThang_Ba.Name = "btnThang_Ba";
            this.btnThang_Ba.Size = new System.Drawing.Size(86, 62);
            this.btnThang_Ba.TabIndex = 20;
            this.btnThang_Ba.Text = "Tháng 3";
            // 
            // btnThang_Tu
            // 
            this.btnThang_Tu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThang_Tu.Location = new System.Drawing.Point(279, 3);
            this.btnThang_Tu.Name = "btnThang_Tu";
            this.btnThang_Tu.Size = new System.Drawing.Size(88, 62);
            this.btnThang_Tu.TabIndex = 21;
            this.btnThang_Tu.Text = "Tháng 4";
            // 
            // btnThang_Nam
            // 
            this.btnThang_Nam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThang_Nam.Location = new System.Drawing.Point(3, 71);
            this.btnThang_Nam.Name = "btnThang_Nam";
            this.btnThang_Nam.Size = new System.Drawing.Size(86, 62);
            this.btnThang_Nam.TabIndex = 22;
            this.btnThang_Nam.Text = "Tháng 5";
            // 
            // btnThang_Sau
            // 
            this.btnThang_Sau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThang_Sau.Location = new System.Drawing.Point(95, 71);
            this.btnThang_Sau.Name = "btnThang_Sau";
            this.btnThang_Sau.Size = new System.Drawing.Size(86, 62);
            this.btnThang_Sau.TabIndex = 23;
            this.btnThang_Sau.Text = "Tháng 6";
            // 
            // btnThang_Bay
            // 
            this.btnThang_Bay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThang_Bay.Location = new System.Drawing.Point(187, 71);
            this.btnThang_Bay.Name = "btnThang_Bay";
            this.btnThang_Bay.Size = new System.Drawing.Size(86, 62);
            this.btnThang_Bay.TabIndex = 24;
            this.btnThang_Bay.Text = "Tháng 7";
            // 
            // btnThang_Tam
            // 
            this.btnThang_Tam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThang_Tam.Location = new System.Drawing.Point(279, 71);
            this.btnThang_Tam.Name = "btnThang_Tam";
            this.btnThang_Tam.Size = new System.Drawing.Size(88, 62);
            this.btnThang_Tam.TabIndex = 25;
            this.btnThang_Tam.Text = "Tháng 8";
            // 
            // btnThang_Chin
            // 
            this.btnThang_Chin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThang_Chin.Location = new System.Drawing.Point(3, 139);
            this.btnThang_Chin.Name = "btnThang_Chin";
            this.btnThang_Chin.Size = new System.Drawing.Size(86, 62);
            this.btnThang_Chin.TabIndex = 26;
            this.btnThang_Chin.Text = "Tháng 9";
            // 
            // btnThang_Muoi
            // 
            this.btnThang_Muoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThang_Muoi.Location = new System.Drawing.Point(95, 139);
            this.btnThang_Muoi.Name = "btnThang_Muoi";
            this.btnThang_Muoi.Size = new System.Drawing.Size(86, 62);
            this.btnThang_Muoi.TabIndex = 27;
            this.btnThang_Muoi.Text = "Tháng 10";
            // 
            // btnThang_Muoimot
            // 
            this.btnThang_Muoimot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThang_Muoimot.Location = new System.Drawing.Point(187, 139);
            this.btnThang_Muoimot.Name = "btnThang_Muoimot";
            this.btnThang_Muoimot.Size = new System.Drawing.Size(86, 62);
            this.btnThang_Muoimot.TabIndex = 28;
            this.btnThang_Muoimot.Text = "Tháng 11";
            // 
            // btnThang_Muoihai
            // 
            this.btnThang_Muoihai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThang_Muoihai.Location = new System.Drawing.Point(279, 139);
            this.btnThang_Muoihai.Name = "btnThang_Muoihai";
            this.btnThang_Muoihai.Size = new System.Drawing.Size(88, 62);
            this.btnThang_Muoihai.TabIndex = 29;
            this.btnThang_Muoihai.Text = "Tháng 12";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnThang_Mot, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnThang_Muoihai, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnThang_Hai, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnThang_Muoimot, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnThang_Ba, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnThang_Tu, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnThang_Chin, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnThang_Nam, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnThang_Tam, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnThang_Sau, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnThang_Bay, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnThang_Muoi, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 38);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(370, 199);
            this.tableLayoutPanel1.TabIndex = 34;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.tableLayoutPanel1);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 65);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(374, 239);
            this.panelControl1.TabIndex = 35;
            // 
            // Frmrex_Chon_Thang
            // 
            this.AllowRefresh = true;
            this.ClientSize = new System.Drawing.Size(374, 304);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.Name = "Frmrex_Chon_Thang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.SetChildIndex(this.barDockControl1, 0);
            this.Controls.SetChildIndex(this.barDockControl2, 0);
            this.Controls.SetChildIndex(this.barDockControl4, 0);
            this.Controls.SetChildIndex(this.barDockControl3, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam_Kyluong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.BarButtonItem barButton_Nhansu;
        private DevExpress.XtraBars.BarButtonItem barButton_Loaihopdong;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraEditors.SpinEdit txtNam_Kyluong;
        private DevExpress.XtraEditors.LabelControl lblNam_Kyluong;
        private DevExpress.XtraEditors.SimpleButton btnThang_Muoihai;
        private DevExpress.XtraEditors.SimpleButton btnThang_Muoimot;
        private DevExpress.XtraEditors.SimpleButton btnThang_Muoi;
        private DevExpress.XtraEditors.SimpleButton btnThang_Chin;
        private DevExpress.XtraEditors.SimpleButton btnThang_Tam;
        private DevExpress.XtraEditors.SimpleButton btnThang_Bay;
        private DevExpress.XtraEditors.SimpleButton btnThang_Sau;
        private DevExpress.XtraEditors.SimpleButton btnThang_Nam;
        private DevExpress.XtraEditors.SimpleButton btnThang_Tu;
        private DevExpress.XtraEditors.SimpleButton btnThang_Ba;
        private DevExpress.XtraEditors.SimpleButton btnThang_Hai;
        private DevExpress.XtraEditors.SimpleButton btnThang_Mot;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}
