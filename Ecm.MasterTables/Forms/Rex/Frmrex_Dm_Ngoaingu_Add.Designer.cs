namespace Ecm.MasterTables.Forms.Rex
{
    partial class Frmrex_Dm_Ngoaingu_Add
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
            this.dgrex_Dm_Ngoaingu = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Ma_Ngoaingu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Ten_Ngoaingu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtTrinhdo = new DevExpress.XtraEditors.TextEdit();
            this.lblTrinhdo = new DevExpress.XtraEditors.LabelControl();
            this.txtTen_Ngoaingu = new DevExpress.XtraEditors.TextEdit();
            this.lblTen_Ngoaingu = new DevExpress.XtraEditors.LabelControl();
            this.txtMa_Ngoaingu = new DevExpress.XtraEditors.TextEdit();
            this.lblMa_Ngoaingu = new DevExpress.XtraEditors.LabelControl();
            this.xtraHNavigator1 = new GoobizFrame.Windows.Controls.XtraHNavigator();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrex_Dm_Ngoaingu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrinhdo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen_Ngoaingu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa_Ngoaingu.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.LookAndFeel.SkinName = "Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // dgrex_Dm_Ngoaingu
            // 
            this.dgrex_Dm_Ngoaingu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrex_Dm_Ngoaingu.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.dgrex_Dm_Ngoaingu.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.dgrex_Dm_Ngoaingu.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.dgrex_Dm_Ngoaingu.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.dgrex_Dm_Ngoaingu.EmbeddedNavigator.Buttons.First.Visible = false;
            this.dgrex_Dm_Ngoaingu.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.dgrex_Dm_Ngoaingu.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.dgrex_Dm_Ngoaingu.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.dgrex_Dm_Ngoaingu.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.dgrex_Dm_Ngoaingu.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.dgrex_Dm_Ngoaingu.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.dgrex_Dm_Ngoaingu.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
            this.dgrex_Dm_Ngoaingu.EmbeddedNavigator.TextStringFormat = "Dòng: {0} / {1}";
            this.dgrex_Dm_Ngoaingu.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dgrex_Dm_Ngoaingu_EmbeddedNavigator_ButtonClick);
            this.dgrex_Dm_Ngoaingu.Location = new System.Drawing.Point(0, 130);
            this.dgrex_Dm_Ngoaingu.MainView = this.gridView1;
            this.dgrex_Dm_Ngoaingu.Name = "dgrex_Dm_Ngoaingu";
            this.dgrex_Dm_Ngoaingu.Size = new System.Drawing.Size(1011, 581);
            this.dgrex_Dm_Ngoaingu.TabIndex = 1;
            this.dgrex_Dm_Ngoaingu.UseEmbeddedNavigator = true;
            this.dgrex_Dm_Ngoaingu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.Ma_Ngoaingu,
            this.Ten_Ngoaingu,
            this.gridColumn2});
            this.gridView1.GridControl = this.dgrex_Dm_Ngoaingu;
            this.gridView1.GroupPanelText = "[Kéo một cột vào đây để nhóm]";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow_1);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Số thứ tự";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // Ma_Ngoaingu
            // 
            this.Ma_Ngoaingu.AppearanceHeader.Options.UseTextOptions = true;
            this.Ma_Ngoaingu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Ma_Ngoaingu.Caption = "Mã ngoại ngữ";
            this.Ma_Ngoaingu.FieldName = "Ma_Ngoaingu";
            this.Ma_Ngoaingu.Name = "Ma_Ngoaingu";
            this.Ma_Ngoaingu.Visible = true;
            this.Ma_Ngoaingu.VisibleIndex = 0;
            // 
            // Ten_Ngoaingu
            // 
            this.Ten_Ngoaingu.AppearanceHeader.Options.UseTextOptions = true;
            this.Ten_Ngoaingu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Ten_Ngoaingu.Caption = "Tên ngoại ngữ";
            this.Ten_Ngoaingu.FieldName = "Ten_Ngoaingu";
            this.Ten_Ngoaingu.Name = "Ten_Ngoaingu";
            this.Ten_Ngoaingu.Visible = true;
            this.Ten_Ngoaingu.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Trình độ";
            this.gridColumn2.FieldName = "Ten_Trinhdo";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.tableLayoutPanel1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 65);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1011, 65);
            this.panelControl1.TabIndex = 0;
            // 
            // txtTrinhdo
            // 
            this.txtTrinhdo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTrinhdo.Location = new System.Drawing.Point(735, 3);
            this.txtTrinhdo.Name = "txtTrinhdo";
            this.txtTrinhdo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtTrinhdo.Properties.Appearance.Options.UseFont = true;
            this.txtTrinhdo.Size = new System.Drawing.Size(200, 26);
            this.txtTrinhdo.TabIndex = 5;
            // 
            // lblTrinhdo
            // 
            this.lblTrinhdo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTrinhdo.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblTrinhdo.Location = new System.Drawing.Point(668, 6);
            this.lblTrinhdo.Name = "lblTrinhdo";
            this.lblTrinhdo.Size = new System.Drawing.Size(61, 19);
            this.lblTrinhdo.TabIndex = 6;
            this.lblTrinhdo.Text = "Trình độ";
            // 
            // txtTen_Ngoaingu
            // 
            this.txtTen_Ngoaingu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTen_Ngoaingu.Location = new System.Drawing.Point(442, 3);
            this.txtTen_Ngoaingu.Name = "txtTen_Ngoaingu";
            this.txtTen_Ngoaingu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtTen_Ngoaingu.Properties.Appearance.Options.UseFont = true;
            this.txtTen_Ngoaingu.Size = new System.Drawing.Size(200, 26);
            this.txtTen_Ngoaingu.TabIndex = 1;
            // 
            // lblTen_Ngoaingu
            // 
            this.lblTen_Ngoaingu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTen_Ngoaingu.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblTen_Ngoaingu.Location = new System.Drawing.Point(332, 6);
            this.lblTen_Ngoaingu.Name = "lblTen_Ngoaingu";
            this.lblTen_Ngoaingu.Size = new System.Drawing.Size(104, 19);
            this.lblTen_Ngoaingu.TabIndex = 4;
            this.lblTen_Ngoaingu.Text = "Tên ngoại ngữ";
            // 
            // txtMa_Ngoaingu
            // 
            this.txtMa_Ngoaingu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMa_Ngoaingu.Location = new System.Drawing.Point(106, 3);
            this.txtMa_Ngoaingu.Name = "txtMa_Ngoaingu";
            this.txtMa_Ngoaingu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtMa_Ngoaingu.Properties.Appearance.Options.UseFont = true;
            this.txtMa_Ngoaingu.Size = new System.Drawing.Size(200, 26);
            this.txtMa_Ngoaingu.TabIndex = 0;
            this.txtMa_Ngoaingu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMa_Ngoaingu_KeyPress);
            // 
            // lblMa_Ngoaingu
            // 
            this.lblMa_Ngoaingu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMa_Ngoaingu.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblMa_Ngoaingu.Location = new System.Drawing.Point(3, 6);
            this.lblMa_Ngoaingu.Name = "lblMa_Ngoaingu";
            this.lblMa_Ngoaingu.Size = new System.Drawing.Size(97, 19);
            this.lblMa_Ngoaingu.TabIndex = 2;
            this.lblMa_Ngoaingu.Text = "Mã ngoại ngữ";
            // 
            // xtraHNavigator1
            // 
            this.xtraHNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xtraHNavigator1.GridControl = this.dgrex_Dm_Ngoaingu;
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
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lblMa_Ngoaingu, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTrinhdo, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtMa_Ngoaingu, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTrinhdo, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTen_Ngoaingu, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTen_Ngoaingu, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1007, 61);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // Frmrex_Dm_Ngoaingu_Add
            // 
            this.AllowRefresh = true;
            this.ClientSize = new System.Drawing.Size(1011, 735);
            this.Controls.Add(this.dgrex_Dm_Ngoaingu);
            this.Controls.Add(this.xtraHNavigator1);
            this.Controls.Add(this.panelControl1);
            this.Name = "Frmrex_Dm_Ngoaingu_Add";
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.xtraHNavigator1, 0);
            this.Controls.SetChildIndex(this.dgrex_Dm_Ngoaingu, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrex_Dm_Ngoaingu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTrinhdo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen_Ngoaingu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa_Ngoaingu.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgrex_Dm_Ngoaingu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn Ma_Ngoaingu;
        private DevExpress.XtraGrid.Columns.GridColumn Ten_Ngoaingu;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtTen_Ngoaingu;
        private DevExpress.XtraEditors.LabelControl lblTen_Ngoaingu;
        private DevExpress.XtraEditors.TextEdit txtMa_Ngoaingu;
        private DevExpress.XtraEditors.LabelControl lblMa_Ngoaingu;
        private  GoobizFrame.Windows.Controls.XtraHNavigator xtraHNavigator1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.TextEdit txtTrinhdo;
        private DevExpress.XtraEditors.LabelControl lblTrinhdo;
        private DevExpress.XtraEditors.TextEdit txtTen_Trinhdo;
        private DevExpress.XtraEditors.LabelControl lblMa_Trinhdo;
        private DevExpress.XtraEditors.LabelControl lblTen_Trinhdo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
