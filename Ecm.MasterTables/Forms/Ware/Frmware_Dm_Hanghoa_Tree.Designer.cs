namespace Ecm.MasterTables.Forms.Ware
{
    partial class Frmware_Dm_Hanghoa_Tree
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtMa_Hanghoa_Ban = new DevExpress.XtraEditors.TextEdit();
            this.lblMa_Hanghoa_Ban = new DevExpress.XtraEditors.LabelControl();
            this.lblTen_Hanghoa_Ban = new DevExpress.XtraEditors.LabelControl();
            this.txtTen_Hanghoa_Ban = new DevExpress.XtraEditors.TextEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            treeList1 = new DevExpress.XtraTreeList.TreeList();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(treeList1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa_Hanghoa_Ban.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen_Hanghoa_Ban.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.LookAndFeel.SkinName = "Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // treeList1
            // 
            treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn3,
            this.treeListColumn4,
            this.treeListColumn5});
            treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            treeList1.KeyFieldName = "Ma_Ql";
            treeList1.Location = new System.Drawing.Point(0, 130);
            treeList1.Name = "treeList1";
            treeList1.OptionsBehavior.PopulateServiceColumns = true;
            treeList1.ParentFieldName = "Ma_Ql_Pk";
            treeList1.Size = new System.Drawing.Size(577, 338);
            treeList1.TabIndex = 4;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "treeListColumn1";
            this.treeListColumn1.FieldName = "Id_Nhom_Hanghoa";
            this.treeListColumn1.Name = "treeListColumn1";
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "treeListColumn2";
            this.treeListColumn2.FieldName = "Id_Loai_Hanghoa";
            this.treeListColumn2.Name = "treeListColumn2";
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "treeListColumn3";
            this.treeListColumn3.FieldName = "Id_Hanghoa";
            this.treeListColumn3.Name = "treeListColumn3";
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn4.Caption = "Mã hàng hóa";
            this.treeListColumn4.FieldName = "Ma_Hanghoa";
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 0;
            this.treeListColumn4.Width = 99;
            // 
            // treeListColumn5
            // 
            this.treeListColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn5.Caption = "Tên hàng hóa";
            this.treeListColumn5.FieldName = "Ten_Hanghoa";
            this.treeListColumn5.Name = "treeListColumn5";
            this.treeListColumn5.Visible = true;
            this.treeListColumn5.VisibleIndex = 1;
            this.treeListColumn5.Width = 335;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtMa_Hanghoa_Ban, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblMa_Hanghoa_Ban, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTen_Hanghoa_Ban, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTen_Hanghoa_Ban, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSearch, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 65);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(577, 65);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // txtMa_Hanghoa_Ban
            // 
            this.txtMa_Hanghoa_Ban.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMa_Hanghoa_Ban.Location = new System.Drawing.Point(100, 3);
            this.txtMa_Hanghoa_Ban.Name = "txtMa_Hanghoa_Ban";
            this.txtMa_Hanghoa_Ban.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtMa_Hanghoa_Ban.Properties.Appearance.Options.UseFont = true;
            this.txtMa_Hanghoa_Ban.Size = new System.Drawing.Size(182, 26);
            this.txtMa_Hanghoa_Ban.TabIndex = 6;
            // 
            // lblMa_Hanghoa_Ban
            // 
            this.lblMa_Hanghoa_Ban.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMa_Hanghoa_Ban.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblMa_Hanghoa_Ban.Location = new System.Drawing.Point(3, 6);
            this.lblMa_Hanghoa_Ban.Name = "lblMa_Hanghoa_Ban";
            this.lblMa_Hanghoa_Ban.Size = new System.Drawing.Size(91, 19);
            this.lblMa_Hanghoa_Ban.TabIndex = 7;
            this.lblMa_Hanghoa_Ban.Text = "Mã hàng hóa";
            // 
            // lblTen_Hanghoa_Ban
            // 
            this.lblTen_Hanghoa_Ban.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTen_Hanghoa_Ban.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblTen_Hanghoa_Ban.Location = new System.Drawing.Point(288, 6);
            this.lblTen_Hanghoa_Ban.Name = "lblTen_Hanghoa_Ban";
            this.lblTen_Hanghoa_Ban.Size = new System.Drawing.Size(98, 19);
            this.lblTen_Hanghoa_Ban.TabIndex = 9;
            this.lblTen_Hanghoa_Ban.Text = "Tên hàng hóa";
            // 
            // txtTen_Hanghoa_Ban
            // 
            this.txtTen_Hanghoa_Ban.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTen_Hanghoa_Ban.Location = new System.Drawing.Point(392, 3);
            this.txtTen_Hanghoa_Ban.Name = "txtTen_Hanghoa_Ban";
            this.txtTen_Hanghoa_Ban.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtTen_Hanghoa_Ban.Properties.Appearance.Options.UseFont = true;
            this.txtTen_Hanghoa_Ban.Size = new System.Drawing.Size(182, 26);
            this.txtTen_Hanghoa_Ban.TabIndex = 8;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(499, 35);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // Frmware_Dm_Hanghoa_Tree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 468);
            this.Controls.Add(treeList1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Frmware_Dm_Hanghoa_Tree";
            this.Text = "Frmware_Dm_Hanghoa_Tree";
            this.Load += new System.EventHandler(this.Frmware_Dm_Hanghoa_Tree_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(treeList1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(treeList1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa_Hanghoa_Ban.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen_Hanghoa_Ban.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.TextEdit txtMa_Hanghoa_Ban;
        private DevExpress.XtraEditors.LabelControl lblMa_Hanghoa_Ban;
        private DevExpress.XtraEditors.LabelControl lblTen_Hanghoa_Ban;
        private DevExpress.XtraEditors.TextEdit txtTen_Hanghoa_Ban;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
    }
}