namespace Ecm.Ware.Forms
{
    partial class FrmRptware_Nxt_Hhmua_Notify
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lookUpEditKho_Hanghoa_Mua = new DevExpress.XtraEditors.LookUpEdit();
            this.lblKho_Hanghoa_Mua = new DevExpress.XtraEditors.LabelControl();
            this.dgware_Nxt_Hhmua_Notify = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditKho_Hanghoa_Mua.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Nxt_Hhmua_Notify)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.LookAndFeel.SkinName = "Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "gridColumn11";
            this.gridColumn11.FieldName = "Notify";
            this.gridColumn11.Name = "gridColumn11";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.tableLayoutPanel1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 65);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(976, 47);
            this.panelControl1.TabIndex = 10;
            // 
            // lookUpEditKho_Hanghoa_Mua
            // 
            this.lookUpEditKho_Hanghoa_Mua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lookUpEditKho_Hanghoa_Mua.Location = new System.Drawing.Point(54, 3);
            this.lookUpEditKho_Hanghoa_Mua.Name = "lookUpEditKho_Hanghoa_Mua";
            this.lookUpEditKho_Hanghoa_Mua.Properties.AutoSearchColumnIndex = 2;
            this.lookUpEditKho_Hanghoa_Mua.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditKho_Hanghoa_Mua.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Kho_Hanghoa_Mua", "Stt", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Kho_Hanghoa_Mua", "Mã kho HH mua"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Kho_Hanghoa_Mua", "Tên kho HH mua")});
            this.lookUpEditKho_Hanghoa_Mua.Properties.DisplayMember = "Ten_Kho_Hanghoa_Mua";
            this.lookUpEditKho_Hanghoa_Mua.Properties.NullText = "";
            this.lookUpEditKho_Hanghoa_Mua.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lookUpEditKho_Hanghoa_Mua.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditKho_Hanghoa_Mua.Properties.ValueMember = "Id_Kho_Hanghoa_Mua";
            this.lookUpEditKho_Hanghoa_Mua.Size = new System.Drawing.Size(458, 20);
            this.lookUpEditKho_Hanghoa_Mua.TabIndex = 90;
            this.lookUpEditKho_Hanghoa_Mua.EditValueChanged += new System.EventHandler(this.lookUpEditKho_Hanghoa_Mua_EditValueChanged);
            // 
            // lblKho_Hanghoa_Mua
            // 
            this.lblKho_Hanghoa_Mua.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblKho_Hanghoa_Mua.Location = new System.Drawing.Point(3, 6);
            this.lblKho_Hanghoa_Mua.Name = "lblKho_Hanghoa_Mua";
            this.lblKho_Hanghoa_Mua.Size = new System.Drawing.Size(45, 13);
            this.lblKho_Hanghoa_Mua.TabIndex = 91;
            this.lblKho_Hanghoa_Mua.Text = "Kho hàng";
            // 
            // dgware_Nxt_Hhmua_Notify
            // 
            this.dgware_Nxt_Hhmua_Notify.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgware_Nxt_Hhmua_Notify.EmbeddedNavigator.TextStringFormat = "Dòng: {0} / {1}";
            this.dgware_Nxt_Hhmua_Notify.Location = new System.Drawing.Point(0, 112);
            this.dgware_Nxt_Hhmua_Notify.MainView = this.gridView1;
            this.dgware_Nxt_Hhmua_Notify.Name = "dgware_Nxt_Hhmua_Notify";
            this.dgware_Nxt_Hhmua_Notify.Size = new System.Drawing.Size(976, 325);
            this.dgware_Nxt_Hhmua_Notify.TabIndex = 21;
            this.dgware_Nxt_Hhmua_Notify.UseEmbeddedNavigator = true;
            this.dgware_Nxt_Hhmua_Notify.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn5,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11});
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.LightCoral;
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.gridColumn11;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = "1";
            this.gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gridView1.GridControl = this.dgware_Nxt_Hhmua_Notify;
            this.gridView1.GroupPanelText = "[Kéo một cột vào đây để nhóm]";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Số thứ tự";
            this.gridColumn1.FieldName = "Stt";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Mã hh";
            this.gridColumn5.FieldName = "Ma_Hanghoa_Mua";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên hh";
            this.gridColumn2.FieldName = "Ten_Hanghoa_Mua";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn3.Caption = "ĐVT";
            this.gridColumn3.FieldName = "Ten_Donvitinh";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "SL đầu kỳ";
            this.gridColumn4.FieldName = "Soluong_Dk";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "SL Nhập";
            this.gridColumn6.FieldName = "Soluong_Nhap";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "SL xuất";
            this.gridColumn7.FieldName = "Soluong_Xuat";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "SL bán";
            this.gridColumn8.FieldName = "Soluong_Ban";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "SL tồn";
            this.gridColumn9.FieldName = "Soluong_Ton";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 7;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "SL cảnh báo";
            this.gridColumn10.FieldName = "Soluong_Min";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 8;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lookUpEditKho_Hanghoa_Mua, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblKho_Hanghoa_Mua, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(972, 43);
            this.tableLayoutPanel1.TabIndex = 22;
            // 
            // FrmRptware_Nxt_Hhmua_Notify
            // 
            this.AllowPrint = true;
            this.AllowRefresh = true;
            this.ClientSize = new System.Drawing.Size(976, 437);
            this.Controls.Add(this.dgware_Nxt_Hhmua_Notify);
            this.Controls.Add(this.panelControl1);
            this.Name = "FrmRptware_Nxt_Hhmua_Notify";
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.dgware_Nxt_Hhmua_Notify, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditKho_Hanghoa_Mua.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Nxt_Hhmua_Notify)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditKho_Hanghoa_Mua;
        private DevExpress.XtraEditors.LabelControl lblKho_Hanghoa_Mua;
        private DevExpress.XtraGrid.GridControl dgware_Nxt_Hhmua_Notify;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
