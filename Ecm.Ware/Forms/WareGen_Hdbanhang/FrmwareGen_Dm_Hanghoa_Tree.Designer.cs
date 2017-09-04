namespace Ecm.Ware.Forms.WareGen_Hdbanhang
{
    partial class FrmwareGen_Dm_Hanghoa_Tree
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
            DevExpress.XtraTreeList.TreeList treeList1;
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn6 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn7 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.treeListColumn8 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.gridLookUpEdit_Donvitinh = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.treeListColumn9 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn10 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnDisplay_Hanghoa = new DevExpress.XtraEditors.SimpleButton();
            this.dtNgay_Batdau = new DevExpress.XtraEditors.DateEdit();
            this.lblNgay_Batdau = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            treeList1 = new DevExpress.XtraTreeList.TreeList();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Donvitinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Batdau.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Batdau.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // treeList1
            // 
            treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn3,
            this.treeListColumn4,
            this.treeListColumn5,
            this.treeListColumn6,
            this.treeListColumn7,
            this.treeListColumn8,
            this.treeListColumn9,
            this.treeListColumn10});
            treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            treeList1.KeyFieldName = "Ma_Ql";
            treeList1.Location = new System.Drawing.Point(0, 107);
            treeList1.Name = "treeList1";
            treeList1.OptionsBehavior.PopulateServiceColumns = true;
            treeList1.ParentFieldName = "Ma_Ql_Pk";
            treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.gridLookUpEdit_Donvitinh});
            treeList1.Size = new System.Drawing.Size(795, 370);
            treeList1.TabIndex = 10;
            treeList1.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.treeList1_CellValueChanged);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "Id_Nhom_Hanghoa";
            this.treeListColumn1.FieldName = "Id_Nhom_Hanghoa";
            this.treeListColumn1.Name = "treeListColumn1";
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "Id_Loai_Hanghoa";
            this.treeListColumn2.FieldName = "Id_Loai_Hanghoa";
            this.treeListColumn2.Name = "treeListColumn2";
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "Id_Hanghoa_Mua";
            this.treeListColumn3.FieldName = "Id_Hanghoa_Mua";
            this.treeListColumn3.Name = "treeListColumn3";
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.Caption = "Mã hàng hóa";
            this.treeListColumn4.FieldName = "Ma_Hanghoa";
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 0;
            this.treeListColumn4.Width = 62;
            // 
            // treeListColumn5
            // 
            this.treeListColumn5.Caption = "Tên hàng hóa";
            this.treeListColumn5.FieldName = "Ten_Hanghoa";
            this.treeListColumn5.Name = "treeListColumn5";
            this.treeListColumn5.Visible = true;
            this.treeListColumn5.VisibleIndex = 1;
            this.treeListColumn5.Width = 514;
            // 
            // treeListColumn6
            // 
            this.treeListColumn6.Caption = "Id_Hanghoa_Ban";
            this.treeListColumn6.FieldName = "Id_Hanghoa_Ban";
            this.treeListColumn6.Name = "treeListColumn6";
            // 
            // treeListColumn7
            // 
            this.treeListColumn7.Caption = "Chọn";
            this.treeListColumn7.ColumnEdit = this.repositoryItemCheckEdit1;
            this.treeListColumn7.FieldName = "Chon";
            this.treeListColumn7.Name = "treeListColumn7";
            this.treeListColumn7.Visible = true;
            this.treeListColumn7.VisibleIndex = 5;
            this.treeListColumn7.Width = 67;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // treeListColumn8
            // 
            this.treeListColumn8.Caption = "ĐVT";
            this.treeListColumn8.ColumnEdit = this.gridLookUpEdit_Donvitinh;
            this.treeListColumn8.FieldName = "Id_Donvitinh";
            this.treeListColumn8.Name = "treeListColumn8";
            this.treeListColumn8.Visible = true;
            this.treeListColumn8.VisibleIndex = 2;
            this.treeListColumn8.Width = 82;
            // 
            // gridLookUpEdit_Donvitinh
            // 
            this.gridLookUpEdit_Donvitinh.AutoHeight = false;
            this.gridLookUpEdit_Donvitinh.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEdit_Donvitinh.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Donvitinh", "STT"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Donvitinh", "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Donvitinh", "Tên")});
            this.gridLookUpEdit_Donvitinh.DisplayMember = "Ma_Donvitinh";
            this.gridLookUpEdit_Donvitinh.Name = "gridLookUpEdit_Donvitinh";
            this.gridLookUpEdit_Donvitinh.NullText = "";
            this.gridLookUpEdit_Donvitinh.ValueMember = "Id_Donvitinh";
            // 
            // treeListColumn9
            // 
            this.treeListColumn9.Caption = "ĐG";
            this.treeListColumn9.FieldName = "Dongia_Ban";
            this.treeListColumn9.Format.FormatString = "n0";
            this.treeListColumn9.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.treeListColumn9.Name = "treeListColumn9";
            this.treeListColumn9.Visible = true;
            this.treeListColumn9.VisibleIndex = 3;
            this.treeListColumn9.Width = 96;
            // 
            // treeListColumn10
            // 
            this.treeListColumn10.Caption = "KM";
            this.treeListColumn10.FieldName = "Per_Dongia";
            this.treeListColumn10.Format.FormatString = "n";
            this.treeListColumn10.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.treeListColumn10.Name = "treeListColumn10";
            this.treeListColumn10.Visible = true;
            this.treeListColumn10.VisibleIndex = 4;
            this.treeListColumn10.Width = 95;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.tableLayoutPanel1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 65);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(795, 42);
            this.panelControl1.TabIndex = 9;
            // 
            // btnDisplay_Hanghoa
            // 
            this.btnDisplay_Hanghoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDisplay_Hanghoa.Location = new System.Drawing.Point(215, 3);
            this.btnDisplay_Hanghoa.Name = "btnDisplay_Hanghoa";
            this.btnDisplay_Hanghoa.Size = new System.Drawing.Size(133, 23);
            this.btnDisplay_Hanghoa.TabIndex = 99;
            this.btnDisplay_Hanghoa.Text = "Xem danh sách hàng hóa";
            this.btnDisplay_Hanghoa.Click += new System.EventHandler(this.btnDisplay_Hanghoa_Click);
            // 
            // dtNgay_Batdau
            // 
            this.dtNgay_Batdau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtNgay_Batdau.EditValue = new System.DateTime(2009, 4, 16, 11, 42, 23, 643);
            this.dtNgay_Batdau.Location = new System.Drawing.Point(34, 3);
            this.dtNgay_Batdau.Name = "dtNgay_Batdau";
            this.dtNgay_Batdau.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.dtNgay_Batdau.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgay_Batdau.Properties.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss tt";
            this.dtNgay_Batdau.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgay_Batdau.Properties.EditFormat.FormatString = "dd/MM/yyyy hh:mm:ss tt";
            this.dtNgay_Batdau.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgay_Batdau.Properties.Mask.EditMask = "dd/MM/yyyy hh:mm:ss tt";
            this.dtNgay_Batdau.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtNgay_Batdau.Size = new System.Drawing.Size(175, 18);
            this.dtNgay_Batdau.TabIndex = 98;
            // 
            // lblNgay_Batdau
            // 
            this.lblNgay_Batdau.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNgay_Batdau.Location = new System.Drawing.Point(3, 8);
            this.lblNgay_Batdau.Name = "lblNgay_Batdau";
            this.lblNgay_Batdau.Size = new System.Drawing.Size(25, 13);
            this.lblNgay_Batdau.TabIndex = 97;
            this.lblNgay_Batdau.Text = "Ngày";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnDisplay_Hanghoa, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblNgay_Batdau, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtNgay_Batdau, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(795, 42);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // FrmwareGen_Dm_Hanghoa_Tree
            // 
            this.AllowSelect = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 477);
            this.Controls.Add(treeList1);
            this.Controls.Add(this.panelControl1);
            this.Name = "FrmwareGen_Dm_Hanghoa_Tree";
            this.Text = "Dm hàng hóa";
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(treeList1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Donvitinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Batdau.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay_Batdau.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnDisplay_Hanghoa;
        private DevExpress.XtraEditors.DateEdit dtNgay_Batdau;
        private DevExpress.XtraEditors.LabelControl lblNgay_Batdau;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn6;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridLookUpEdit_Donvitinh;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn9;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}