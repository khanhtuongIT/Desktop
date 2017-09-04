namespace SunLine.MasterTables.Forms.Ware
{
    partial class Frmware_Dm_Kho_Hanghoa_Mua_Add
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
            this.dgware_Dm_Kho_Hanghoa_Mua = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtTen_Kho_Hanghoa_Mua = new DevExpress.XtraEditors.TextEdit();
            this.lblTen_Kho_Hanghoa_Mua = new DevExpress.XtraEditors.LabelControl();
            this.txtMa_Kho_Hanghoa_Mua = new DevExpress.XtraEditors.TextEdit();
            this.lblMa_Kho_Hanghoa_Mua = new DevExpress.XtraEditors.LabelControl();
            this.txtId_Kho_Hanghoa_Mua = new DevExpress.XtraEditors.TextEdit();
            this.lblId_Kho_Hanghoa_Mua = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Kho_Hanghoa_Mua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen_Kho_Hanghoa_Mua.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa_Kho_Hanghoa_Mua.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId_Kho_Hanghoa_Mua.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.LookAndFeel.SkinName = "Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // dgware_Dm_Kho_Hanghoa_Mua
            // 
            this.dgware_Dm_Kho_Hanghoa_Mua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgware_Dm_Kho_Hanghoa_Mua.EmbeddedNavigator.Name = "";
            this.dgware_Dm_Kho_Hanghoa_Mua.EmbeddedNavigator.TextStringFormat = "Dòng: {0} / {1}";
            this.dgware_Dm_Kho_Hanghoa_Mua.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dgware_Dm_Kho_Hanghoa_Mua_EmbeddedNavigator_ButtonClick);
            this.dgware_Dm_Kho_Hanghoa_Mua.Location = new System.Drawing.Point(0, 91);
            this.dgware_Dm_Kho_Hanghoa_Mua.MainView = this.gridView1;
            this.dgware_Dm_Kho_Hanghoa_Mua.Name = "dgware_Dm_Kho_Hanghoa_Mua";
            this.dgware_Dm_Kho_Hanghoa_Mua.Size = new System.Drawing.Size(1264, 673);
            this.dgware_Dm_Kho_Hanghoa_Mua.TabIndex = 1;
            this.dgware_Dm_Kho_Hanghoa_Mua.UseEmbeddedNavigator = true;
            this.dgware_Dm_Kho_Hanghoa_Mua.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.GridControl = this.dgware_Dm_Kho_Hanghoa_Mua;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Số thứ tự";
            this.gridColumn1.FieldName = "Id_Kho_Hanghoa_Mua";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Mã kho hàng hóa mua";
            this.gridColumn2.FieldName = "Ma_Kho_Hanghoa_Mua";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 117;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Tên kho hàng hóa mua";
            this.gridColumn3.FieldName = "Ten_Kho_Hanghoa_Mua";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 121;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtTen_Kho_Hanghoa_Mua);
            this.panelControl1.Controls.Add(this.lblTen_Kho_Hanghoa_Mua);
            this.panelControl1.Controls.Add(this.txtMa_Kho_Hanghoa_Mua);
            this.panelControl1.Controls.Add(this.lblMa_Kho_Hanghoa_Mua);
            this.panelControl1.Controls.Add(this.txtId_Kho_Hanghoa_Mua);
            this.panelControl1.Controls.Add(this.lblId_Kho_Hanghoa_Mua);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1264, 67);
            this.toolTipController1.SetSuperTip(this.panelControl1, null);
            this.panelControl1.TabIndex = 0;
            // 
            // txtTen_Kho_Hanghoa_Mua
            // 
            this.txtTen_Kho_Hanghoa_Mua.Location = new System.Drawing.Point(564, 20);
            this.txtTen_Kho_Hanghoa_Mua.Name = "txtTen_Kho_Hanghoa_Mua";
            this.txtTen_Kho_Hanghoa_Mua.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtTen_Kho_Hanghoa_Mua.Properties.Appearance.Options.UseFont = true;
            this.txtTen_Kho_Hanghoa_Mua.Size = new System.Drawing.Size(200, 26);
            this.txtTen_Kho_Hanghoa_Mua.TabIndex = 2;
            // 
            // lblTen_Kho_Hanghoa_Mua
            // 
            this.lblTen_Kho_Hanghoa_Mua.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblTen_Kho_Hanghoa_Mua.Appearance.Options.UseFont = true;
            this.lblTen_Kho_Hanghoa_Mua.Location = new System.Drawing.Point(392, 24);
            this.lblTen_Kho_Hanghoa_Mua.Name = "lblTen_Kho_Hanghoa_Mua";
            this.lblTen_Kho_Hanghoa_Mua.Size = new System.Drawing.Size(165, 19);
            this.lblTen_Kho_Hanghoa_Mua.TabIndex = 4;
            this.lblTen_Kho_Hanghoa_Mua.Text = "Tên kho hàng hóa mua";
            // 
            // txtMa_Kho_Hanghoa_Mua
            // 
            this.txtMa_Kho_Hanghoa_Mua.Location = new System.Drawing.Point(176, 20);
            this.txtMa_Kho_Hanghoa_Mua.Name = "txtMa_Kho_Hanghoa_Mua";
            this.txtMa_Kho_Hanghoa_Mua.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtMa_Kho_Hanghoa_Mua.Properties.Appearance.Options.UseFont = true;
            this.txtMa_Kho_Hanghoa_Mua.Size = new System.Drawing.Size(200, 26);
            this.txtMa_Kho_Hanghoa_Mua.TabIndex = 1;
            // 
            // lblMa_Kho_Hanghoa_Mua
            // 
            this.lblMa_Kho_Hanghoa_Mua.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblMa_Kho_Hanghoa_Mua.Appearance.Options.UseFont = true;
            this.lblMa_Kho_Hanghoa_Mua.Location = new System.Drawing.Point(12, 24);
            this.lblMa_Kho_Hanghoa_Mua.Name = "lblMa_Kho_Hanghoa_Mua";
            this.lblMa_Kho_Hanghoa_Mua.Size = new System.Drawing.Size(158, 19);
            this.lblMa_Kho_Hanghoa_Mua.TabIndex = 2;
            this.lblMa_Kho_Hanghoa_Mua.Text = "Mã kho hàng hóa mua";
            // 
            // txtId_Kho_Hanghoa_Mua
            // 
            this.txtId_Kho_Hanghoa_Mua.Enabled = false;
            this.txtId_Kho_Hanghoa_Mua.Location = new System.Drawing.Point(855, 20);
            this.txtId_Kho_Hanghoa_Mua.Name = "txtId_Kho_Hanghoa_Mua";
            this.txtId_Kho_Hanghoa_Mua.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtId_Kho_Hanghoa_Mua.Properties.Appearance.Options.UseFont = true;
            this.txtId_Kho_Hanghoa_Mua.Size = new System.Drawing.Size(100, 26);
            this.txtId_Kho_Hanghoa_Mua.TabIndex = 0;
            this.txtId_Kho_Hanghoa_Mua.Visible = false;
            // 
            // lblId_Kho_Hanghoa_Mua
            // 
            this.lblId_Kho_Hanghoa_Mua.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblId_Kho_Hanghoa_Mua.Appearance.Options.UseFont = true;
            this.lblId_Kho_Hanghoa_Mua.Location = new System.Drawing.Point(783, 24);
            this.lblId_Kho_Hanghoa_Mua.Name = "lblId_Kho_Hanghoa_Mua";
            this.lblId_Kho_Hanghoa_Mua.Size = new System.Drawing.Size(67, 19);
            this.lblId_Kho_Hanghoa_Mua.TabIndex = 0;
            this.lblId_Kho_Hanghoa_Mua.Text = "Số thứ tự";
            this.lblId_Kho_Hanghoa_Mua.Visible = false;
            // 
            // Frmware_Dm_Kho_Hanghoa_Mua_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1264, 764);
            this.Controls.Add(this.dgware_Dm_Kho_Hanghoa_Mua);
            this.Controls.Add(this.panelControl1);
            this.Name = "Frmware_Dm_Kho_Hanghoa_Mua_Add";
            this.toolTipController1.SetSuperTip(this, null);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.dgware_Dm_Kho_Hanghoa_Mua, 0);
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Kho_Hanghoa_Mua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen_Kho_Hanghoa_Mua.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa_Kho_Hanghoa_Mua.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId_Kho_Hanghoa_Mua.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgware_Dm_Kho_Hanghoa_Mua;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtTen_Kho_Hanghoa_Mua;
        private DevExpress.XtraEditors.LabelControl lblTen_Kho_Hanghoa_Mua;
        private DevExpress.XtraEditors.TextEdit txtMa_Kho_Hanghoa_Mua;
        private DevExpress.XtraEditors.LabelControl lblMa_Kho_Hanghoa_Mua;
        private DevExpress.XtraEditors.TextEdit txtId_Kho_Hanghoa_Mua;
        private DevExpress.XtraEditors.LabelControl lblId_Kho_Hanghoa_Mua;
    }
}
