namespace Ecm.MasterTables.Forms.Rex
{
    partial class Frmrex_Dm_Honnhan_Add
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
            this.dgrex_Dm_Honnhan = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtTen_Honnhan = new DevExpress.XtraEditors.TextEdit();
            this.lblTen_Honnhan = new DevExpress.XtraEditors.LabelControl();
            this.txtMa_Honnhan = new DevExpress.XtraEditors.TextEdit();
            this.lblMa_Honnhan = new DevExpress.XtraEditors.LabelControl();
            this.txtId_Honnhan = new DevExpress.XtraEditors.TextEdit();
            this.lblId_Honnhan = new DevExpress.XtraEditors.LabelControl();
            this.xtraHNavigator1 = new GoobizFrame.Windows.Controls.XtraHNavigator();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrex_Dm_Honnhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen_Honnhan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa_Honnhan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId_Honnhan.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.LookAndFeel.SkinName = "Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // dgrex_Dm_Honnhan
            // 
            this.dgrex_Dm_Honnhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrex_Dm_Honnhan.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.dgrex_Dm_Honnhan.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.dgrex_Dm_Honnhan.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.dgrex_Dm_Honnhan.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.dgrex_Dm_Honnhan.EmbeddedNavigator.Buttons.First.Visible = false;
            this.dgrex_Dm_Honnhan.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.dgrex_Dm_Honnhan.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.dgrex_Dm_Honnhan.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.dgrex_Dm_Honnhan.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.dgrex_Dm_Honnhan.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.dgrex_Dm_Honnhan.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.dgrex_Dm_Honnhan.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
            this.dgrex_Dm_Honnhan.EmbeddedNavigator.TextStringFormat = "Dòng: {0} / {1}";
            this.dgrex_Dm_Honnhan.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dgrex_Dm_Honnhan_EmbeddedNavigator_ButtonClick);
            this.dgrex_Dm_Honnhan.Location = new System.Drawing.Point(0, 130);
            this.dgrex_Dm_Honnhan.MainView = this.gridView1;
            this.dgrex_Dm_Honnhan.Name = "dgrex_Dm_Honnhan";
            this.dgrex_Dm_Honnhan.Size = new System.Drawing.Size(1011, 581);
            this.dgrex_Dm_Honnhan.TabIndex = 1;
            this.dgrex_Dm_Honnhan.UseEmbeddedNavigator = true;
            this.dgrex_Dm_Honnhan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.GridControl = this.dgrex_Dm_Honnhan;
            this.gridView1.GroupPanelText = "[Kéo một cột vào đây để nhóm]";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Số thứ tự";
            this.gridColumn1.FieldName = "Id_Honnhan";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Mã hôn nhân";
            this.gridColumn2.FieldName = "Ma_Honnhan";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Tên hôn nhân";
            this.gridColumn3.FieldName = "Ten_Honnhan";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.tableLayoutPanel1);
            this.panelControl1.Controls.Add(this.txtId_Honnhan);
            this.panelControl1.Controls.Add(this.lblId_Honnhan);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 65);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1011, 65);
            this.panelControl1.TabIndex = 0;
            // 
            // txtTen_Honnhan
            // 
            this.txtTen_Honnhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTen_Honnhan.Location = new System.Drawing.Point(532, 3);
            this.txtTen_Honnhan.Name = "txtTen_Honnhan";
            this.txtTen_Honnhan.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtTen_Honnhan.Properties.Appearance.Options.UseFont = true;
            this.txtTen_Honnhan.Size = new System.Drawing.Size(300, 26);
            this.txtTen_Honnhan.TabIndex = 1;
            // 
            // lblTen_Honnhan
            // 
            this.lblTen_Honnhan.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTen_Honnhan.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblTen_Honnhan.Location = new System.Drawing.Point(427, 6);
            this.lblTen_Honnhan.Name = "lblTen_Honnhan";
            this.lblTen_Honnhan.Size = new System.Drawing.Size(99, 19);
            this.lblTen_Honnhan.TabIndex = 4;
            this.lblTen_Honnhan.Text = "Tên hôn nhân";
            // 
            // txtMa_Honnhan
            // 
            this.txtMa_Honnhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMa_Honnhan.Location = new System.Drawing.Point(101, 3);
            this.txtMa_Honnhan.Name = "txtMa_Honnhan";
            this.txtMa_Honnhan.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtMa_Honnhan.Properties.Appearance.Options.UseFont = true;
            this.txtMa_Honnhan.Size = new System.Drawing.Size(300, 26);
            this.txtMa_Honnhan.TabIndex = 0;
            this.txtMa_Honnhan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMa_Honnhan_KeyPress);
            // 
            // lblMa_Honnhan
            // 
            this.lblMa_Honnhan.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMa_Honnhan.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblMa_Honnhan.Location = new System.Drawing.Point(3, 6);
            this.lblMa_Honnhan.Name = "lblMa_Honnhan";
            this.lblMa_Honnhan.Size = new System.Drawing.Size(92, 19);
            this.lblMa_Honnhan.TabIndex = 2;
            this.lblMa_Honnhan.Text = "Mã hôn nhân";
            // 
            // txtId_Honnhan
            // 
            this.txtId_Honnhan.Enabled = false;
            this.txtId_Honnhan.Location = new System.Drawing.Point(987, 19);
            this.txtId_Honnhan.Name = "txtId_Honnhan";
            this.txtId_Honnhan.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtId_Honnhan.Properties.Appearance.Options.UseFont = true;
            this.txtId_Honnhan.Size = new System.Drawing.Size(100, 26);
            this.txtId_Honnhan.TabIndex = 0;
            this.txtId_Honnhan.Visible = false;
            // 
            // lblId_Honnhan
            // 
            this.lblId_Honnhan.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblId_Honnhan.Location = new System.Drawing.Point(914, 23);
            this.lblId_Honnhan.Name = "lblId_Honnhan";
            this.lblId_Honnhan.Size = new System.Drawing.Size(67, 19);
            this.lblId_Honnhan.TabIndex = 0;
            this.lblId_Honnhan.Text = "Số thứ tự";
            this.lblId_Honnhan.Visible = false;
            // 
            // xtraHNavigator1
            // 
            this.xtraHNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xtraHNavigator1.GridControl = this.dgrex_Dm_Honnhan;
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
            this.tableLayoutPanel1.Controls.Add(this.lblMa_Honnhan, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTen_Honnhan, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtMa_Honnhan, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTen_Honnhan, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1007, 61);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // Frmrex_Dm_Honnhan_Add
            // 
            this.AllowRefresh = true;
            this.ClientSize = new System.Drawing.Size(1011, 735);
            this.Controls.Add(this.dgrex_Dm_Honnhan);
            this.Controls.Add(this.xtraHNavigator1);
            this.Controls.Add(this.panelControl1);
            this.Name = "Frmrex_Dm_Honnhan_Add";
            this.Load += new System.EventHandler(this.Frmrex_Dm_Honnhan_Add_Load);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.xtraHNavigator1, 0);
            this.Controls.SetChildIndex(this.dgrex_Dm_Honnhan, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrex_Dm_Honnhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen_Honnhan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa_Honnhan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId_Honnhan.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgrex_Dm_Honnhan;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtTen_Honnhan;
        private DevExpress.XtraEditors.LabelControl lblTen_Honnhan;
        private DevExpress.XtraEditors.TextEdit txtMa_Honnhan;
        private DevExpress.XtraEditors.LabelControl lblMa_Honnhan;
        private DevExpress.XtraEditors.TextEdit txtId_Honnhan;
        private DevExpress.XtraEditors.LabelControl lblId_Honnhan;
        private  GoobizFrame.Windows.Controls.XtraHNavigator xtraHNavigator1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
