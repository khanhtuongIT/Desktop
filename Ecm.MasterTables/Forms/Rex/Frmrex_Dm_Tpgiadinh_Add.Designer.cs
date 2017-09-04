namespace Ecm.MasterTables.Forms.Rex
{
    partial class Frmrex_Dm_Tpgiadinh_Add
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
            this.dgrex_Dm_Tpgiadinh = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtTen_Tpgiadinh = new DevExpress.XtraEditors.TextEdit();
            this.lblTen_Tpgiadinh = new DevExpress.XtraEditors.LabelControl();
            this.txtMa_Tpgiadinh = new DevExpress.XtraEditors.TextEdit();
            this.lblMa_Tpgiadinh = new DevExpress.XtraEditors.LabelControl();
            this.txtId_Tpgiadinh = new DevExpress.XtraEditors.TextEdit();
            this.lblId_Tpgiadinh = new DevExpress.XtraEditors.LabelControl();
            this.xtraHNavigator1 = new GoobizFrame.Windows.Controls.XtraHNavigator();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrex_Dm_Tpgiadinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen_Tpgiadinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa_Tpgiadinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId_Tpgiadinh.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.LookAndFeel.SkinName = "Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // dgrex_Dm_Tpgiadinh
            // 
            this.dgrex_Dm_Tpgiadinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrex_Dm_Tpgiadinh.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.dgrex_Dm_Tpgiadinh.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.dgrex_Dm_Tpgiadinh.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.dgrex_Dm_Tpgiadinh.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.dgrex_Dm_Tpgiadinh.EmbeddedNavigator.Buttons.First.Visible = false;
            this.dgrex_Dm_Tpgiadinh.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.dgrex_Dm_Tpgiadinh.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.dgrex_Dm_Tpgiadinh.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.dgrex_Dm_Tpgiadinh.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.dgrex_Dm_Tpgiadinh.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.dgrex_Dm_Tpgiadinh.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.dgrex_Dm_Tpgiadinh.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
            this.dgrex_Dm_Tpgiadinh.EmbeddedNavigator.TextStringFormat = "Dòng: {0} / {1}";
            this.dgrex_Dm_Tpgiadinh.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dgrex_Dm_Tpgiadinh_EmbeddedNavigator_ButtonClick);
            this.dgrex_Dm_Tpgiadinh.Location = new System.Drawing.Point(0, 130);
            this.dgrex_Dm_Tpgiadinh.MainView = this.gridView1;
            this.dgrex_Dm_Tpgiadinh.Name = "dgrex_Dm_Tpgiadinh";
            this.dgrex_Dm_Tpgiadinh.Size = new System.Drawing.Size(1011, 581);
            this.dgrex_Dm_Tpgiadinh.TabIndex = 1;
            this.dgrex_Dm_Tpgiadinh.UseEmbeddedNavigator = true;
            this.dgrex_Dm_Tpgiadinh.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.GridControl = this.dgrex_Dm_Tpgiadinh;
            this.gridView1.GroupPanelText = "[Kéo một cột vào đây để nhóm]";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Số thứ tự";
            this.gridColumn1.FieldName = "Id_Tpgiadinh";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Mã tp gia đình";
            this.gridColumn2.FieldName = "Ma_Tpgiadinh";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Tên tp gia đình";
            this.gridColumn3.FieldName = "Ten_Tpgiadinh";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.tableLayoutPanel1);
            this.panelControl1.Controls.Add(this.txtId_Tpgiadinh);
            this.panelControl1.Controls.Add(this.lblId_Tpgiadinh);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 65);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1011, 65);
            this.panelControl1.TabIndex = 0;
            // 
            // txtTen_Tpgiadinh
            // 
            this.txtTen_Tpgiadinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTen_Tpgiadinh.Location = new System.Drawing.Point(550, 3);
            this.txtTen_Tpgiadinh.Name = "txtTen_Tpgiadinh";
            this.txtTen_Tpgiadinh.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtTen_Tpgiadinh.Properties.Appearance.Options.UseFont = true;
            this.txtTen_Tpgiadinh.Size = new System.Drawing.Size(300, 26);
            this.txtTen_Tpgiadinh.TabIndex = 1;
            // 
            // lblTen_Tpgiadinh
            // 
            this.lblTen_Tpgiadinh.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTen_Tpgiadinh.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblTen_Tpgiadinh.Location = new System.Drawing.Point(436, 6);
            this.lblTen_Tpgiadinh.Name = "lblTen_Tpgiadinh";
            this.lblTen_Tpgiadinh.Size = new System.Drawing.Size(108, 19);
            this.lblTen_Tpgiadinh.TabIndex = 4;
            this.lblTen_Tpgiadinh.Text = "Tên tp gia đình";
            // 
            // txtMa_Tpgiadinh
            // 
            this.txtMa_Tpgiadinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMa_Tpgiadinh.Location = new System.Drawing.Point(110, 3);
            this.txtMa_Tpgiadinh.Name = "txtMa_Tpgiadinh";
            this.txtMa_Tpgiadinh.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtMa_Tpgiadinh.Properties.Appearance.Options.UseFont = true;
            this.txtMa_Tpgiadinh.Size = new System.Drawing.Size(300, 26);
            this.txtMa_Tpgiadinh.TabIndex = 0;
            this.txtMa_Tpgiadinh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMa_Tpgiadinh_KeyPress);
            // 
            // lblMa_Tpgiadinh
            // 
            this.lblMa_Tpgiadinh.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMa_Tpgiadinh.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblMa_Tpgiadinh.Location = new System.Drawing.Point(3, 6);
            this.lblMa_Tpgiadinh.Name = "lblMa_Tpgiadinh";
            this.lblMa_Tpgiadinh.Size = new System.Drawing.Size(101, 19);
            this.lblMa_Tpgiadinh.TabIndex = 2;
            this.lblMa_Tpgiadinh.Text = "Mã tp gia đình";
            // 
            // txtId_Tpgiadinh
            // 
            this.txtId_Tpgiadinh.Enabled = false;
            this.txtId_Tpgiadinh.Location = new System.Drawing.Point(1002, 22);
            this.txtId_Tpgiadinh.Name = "txtId_Tpgiadinh";
            this.txtId_Tpgiadinh.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtId_Tpgiadinh.Properties.Appearance.Options.UseFont = true;
            this.txtId_Tpgiadinh.Size = new System.Drawing.Size(100, 26);
            this.txtId_Tpgiadinh.TabIndex = 0;
            this.txtId_Tpgiadinh.Visible = false;
            // 
            // lblId_Tpgiadinh
            // 
            this.lblId_Tpgiadinh.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblId_Tpgiadinh.Location = new System.Drawing.Point(929, 26);
            this.lblId_Tpgiadinh.Name = "lblId_Tpgiadinh";
            this.lblId_Tpgiadinh.Size = new System.Drawing.Size(67, 19);
            this.lblId_Tpgiadinh.TabIndex = 0;
            this.lblId_Tpgiadinh.Text = "Số thứ tự";
            this.lblId_Tpgiadinh.Visible = false;
            // 
            // xtraHNavigator1
            // 
            this.xtraHNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xtraHNavigator1.GridControl = this.dgrex_Dm_Tpgiadinh;
            this.xtraHNavigator1.Location = new System.Drawing.Point(0, 711);
            this.xtraHNavigator1.Margin = new System.Windows.Forms.Padding(0);
            this.xtraHNavigator1.Name = "xtraHNavigator1";
            this.xtraHNavigator1.Size = new System.Drawing.Size(1011, 24);
            this.xtraHNavigator1.TabIndex = 9;
            this.xtraHNavigator1.TextStringFormat = "Dòng: {0} / {1}";
            this.xtraHNavigator1.VisibleFirst = true;
            this.xtraHNavigator1.VisibleLast = true;
            this.xtraHNavigator1.VisibleNext = true;
            this.xtraHNavigator1.VisiblePageNext = true;
            this.xtraHNavigator1.VisiblePagePrev = true;
            this.xtraHNavigator1.VisiblePrev = true;
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
            this.tableLayoutPanel1.Controls.Add(this.lblMa_Tpgiadinh, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTen_Tpgiadinh, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTen_Tpgiadinh, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtMa_Tpgiadinh, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1007, 61);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // Frmrex_Dm_Tpgiadinh_Add
            // 
            this.AllowRefresh = true;
            this.ClientSize = new System.Drawing.Size(1011, 735);
            this.Controls.Add(this.dgrex_Dm_Tpgiadinh);
            this.Controls.Add(this.xtraHNavigator1);
            this.Controls.Add(this.panelControl1);
            this.Name = "Frmrex_Dm_Tpgiadinh_Add";
            this.Load += new System.EventHandler(this.Frmrex_Dm_Tpgiadinh_Add_Load);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.xtraHNavigator1, 0);
            this.Controls.SetChildIndex(this.dgrex_Dm_Tpgiadinh, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrex_Dm_Tpgiadinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen_Tpgiadinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa_Tpgiadinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId_Tpgiadinh.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgrex_Dm_Tpgiadinh;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtTen_Tpgiadinh;
        private DevExpress.XtraEditors.LabelControl lblTen_Tpgiadinh;
        private DevExpress.XtraEditors.TextEdit txtMa_Tpgiadinh;
        private DevExpress.XtraEditors.LabelControl lblMa_Tpgiadinh;
        private DevExpress.XtraEditors.TextEdit txtId_Tpgiadinh;
        private DevExpress.XtraEditors.LabelControl lblId_Tpgiadinh;
        private  GoobizFrame.Windows.Controls.XtraHNavigator xtraHNavigator1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
