namespace SunLine.SystemControl.SystemInfo
{
    partial class UCWebReferences
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_cWebReferences = new DevExpress.XtraEditors.SimpleButton();
            this.btn_eWebReferences = new DevExpress.XtraEditors.SimpleButton();
            this.btn_sWebReferences = new DevExpress.XtraEditors.SimpleButton();
            this.dgWebReferences = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgWebReferences)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btn_cWebReferences);
            this.panelControl1.Controls.Add(this.btn_eWebReferences);
            this.panelControl1.Controls.Add(this.btn_sWebReferences);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(636, 28);
            this.panelControl1.TabIndex = 104;
            // 
            // btn_cWebReferences
            // 
            this.btn_cWebReferences.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cWebReferences.Location = new System.Drawing.Point(560, 3);
            this.btn_cWebReferences.Name = "btn_cWebReferences";
            this.btn_cWebReferences.Size = new System.Drawing.Size(75, 23);
            this.btn_cWebReferences.TabIndex = 102;
            this.btn_cWebReferences.Text = "Bỏ qua";
            this.btn_cWebReferences.Click += new System.EventHandler(this.btn_cWebReferences_Click);
            // 
            // btn_eWebReferences
            // 
            this.btn_eWebReferences.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_eWebReferences.Location = new System.Drawing.Point(410, 3);
            this.btn_eWebReferences.Name = "btn_eWebReferences";
            this.btn_eWebReferences.Size = new System.Drawing.Size(75, 23);
            this.btn_eWebReferences.TabIndex = 102;
            this.btn_eWebReferences.Text = "Sửa";
            this.btn_eWebReferences.Click += new System.EventHandler(this.btn_eWebReferences_Click);
            // 
            // btn_sWebReferences
            // 
            this.btn_sWebReferences.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_sWebReferences.Location = new System.Drawing.Point(485, 3);
            this.btn_sWebReferences.Name = "btn_sWebReferences";
            this.btn_sWebReferences.Size = new System.Drawing.Size(75, 23);
            this.btn_sWebReferences.TabIndex = 102;
            this.btn_sWebReferences.Text = "Lưu";
            this.btn_sWebReferences.Click += new System.EventHandler(this.btn_sWebReferences_Click);
            // 
            // dgWebReferences
            // 
            this.dgWebReferences.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgWebReferences.EmbeddedNavigator.Buttons.Append.Enabled = false;
            this.dgWebReferences.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.dgWebReferences.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.dgWebReferences.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.dgWebReferences.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.dgWebReferences.EmbeddedNavigator.Name = "";
            this.dgWebReferences.EmbeddedNavigator.TextStringFormat = "Dòng : {0} / {1}";
            this.dgWebReferences.Location = new System.Drawing.Point(0, 28);
            this.dgWebReferences.MainView = this.gridView1;
            this.dgWebReferences.Name = "dgWebReferences";
            this.dgWebReferences.Size = new System.Drawing.Size(636, 286);
            this.dgWebReferences.TabIndex = 105;
            this.dgWebReferences.UseEmbeddedNavigator = true;
            this.dgWebReferences.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(460, 268, 216, 178);
            this.gridView1.GridControl = this.dgWebReferences;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn2, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "GroupName";
            this.gridColumn1.FieldName = "GroupName";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Section";
            this.gridColumn2.FieldName = "Section";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Tên";
            this.gridColumn3.FieldName = "Key";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 95;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Giá trị";
            this.gridColumn4.FieldName = "Value";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 520;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Trạng thái";
            this.gridColumn5.FieldName = "Status";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 166;
            // 
            // UCWebReferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgWebReferences);
            this.Controls.Add(this.panelControl1);
            this.Name = "UCWebReferences";
            this.Size = new System.Drawing.Size(636, 314);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgWebReferences)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_cWebReferences;
        private DevExpress.XtraEditors.SimpleButton btn_eWebReferences;
        private DevExpress.XtraEditors.SimpleButton btn_sWebReferences;
        private DevExpress.XtraGrid.GridControl dgWebReferences;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
    }
}
