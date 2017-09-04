namespace Ecm.MasterTables.Forms.Rex
{
    partial class Frmrex_Dm_Chuyenmon_Add
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
            this.dgrex_Dm_Chuyenmon = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMa_Chuyenmon = new DevExpress.XtraEditors.LabelControl();
            this.txtMa_Chuyenmon = new DevExpress.XtraEditors.TextEdit();
            this.txtTen_Chuyenmon = new DevExpress.XtraEditors.TextEdit();
            this.lblTen_Chuyenmon = new DevExpress.XtraEditors.LabelControl();
            this.txtId_Chuyenmon = new DevExpress.XtraEditors.TextEdit();
            this.xtraHNavigator1 = new GoobizFrame.Windows.Controls.XtraHNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrex_Dm_Chuyenmon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa_Chuyenmon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen_Chuyenmon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId_Chuyenmon.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.LookAndFeel.SkinName = "Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // dgrex_Dm_Chuyenmon
            // 
            this.dgrex_Dm_Chuyenmon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrex_Dm_Chuyenmon.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.dgrex_Dm_Chuyenmon.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.dgrex_Dm_Chuyenmon.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.dgrex_Dm_Chuyenmon.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.dgrex_Dm_Chuyenmon.EmbeddedNavigator.Buttons.First.Visible = false;
            this.dgrex_Dm_Chuyenmon.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.dgrex_Dm_Chuyenmon.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.dgrex_Dm_Chuyenmon.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.dgrex_Dm_Chuyenmon.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.dgrex_Dm_Chuyenmon.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.dgrex_Dm_Chuyenmon.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.dgrex_Dm_Chuyenmon.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
            this.dgrex_Dm_Chuyenmon.EmbeddedNavigator.TextStringFormat = "Dòng: {0} / {1}";
            this.dgrex_Dm_Chuyenmon.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dgrex_Dm_Chuyenmon_EmbeddedNavigator_ButtonClick_1);
            this.dgrex_Dm_Chuyenmon.Location = new System.Drawing.Point(0, 130);
            this.dgrex_Dm_Chuyenmon.MainView = this.gridView1;
            this.dgrex_Dm_Chuyenmon.Name = "dgrex_Dm_Chuyenmon";
            this.dgrex_Dm_Chuyenmon.Size = new System.Drawing.Size(1011, 581);
            this.dgrex_Dm_Chuyenmon.TabIndex = 1;
            this.dgrex_Dm_Chuyenmon.UseEmbeddedNavigator = true;
            this.dgrex_Dm_Chuyenmon.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.GridControl = this.dgrex_Dm_Chuyenmon;
            this.gridView1.GroupPanelText = "[Kéo một cột vào đây để nhóm]";
            this.gridView1.Name = "gridView1";
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow_1);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Số thứ tự";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Mã chuyên môn";
            this.gridColumn2.FieldName = "Ma_Chuyenmon";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Tên chuyên môn";
            this.gridColumn3.FieldName = "Ten_Chuyenmon";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.tableLayoutPanel1);
            this.panelControl1.Controls.Add(this.txtId_Chuyenmon);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 65);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1011, 65);
            this.panelControl1.TabIndex = 0;
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
            this.tableLayoutPanel1.Controls.Add(this.lblMa_Chuyenmon, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtMa_Chuyenmon, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTen_Chuyenmon, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTen_Chuyenmon, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1007, 61);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // lblMa_Chuyenmon
            // 
            this.lblMa_Chuyenmon.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMa_Chuyenmon.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblMa_Chuyenmon.Location = new System.Drawing.Point(3, 6);
            this.lblMa_Chuyenmon.Name = "lblMa_Chuyenmon";
            this.lblMa_Chuyenmon.Size = new System.Drawing.Size(112, 19);
            this.lblMa_Chuyenmon.TabIndex = 2;
            this.lblMa_Chuyenmon.Text = "Mã chuyên môn";
            // 
            // txtMa_Chuyenmon
            // 
            this.txtMa_Chuyenmon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMa_Chuyenmon.Location = new System.Drawing.Point(121, 3);
            this.txtMa_Chuyenmon.Name = "txtMa_Chuyenmon";
            this.txtMa_Chuyenmon.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtMa_Chuyenmon.Properties.Appearance.Options.UseFont = true;
            this.txtMa_Chuyenmon.Size = new System.Drawing.Size(300, 26);
            this.txtMa_Chuyenmon.TabIndex = 0;
            this.txtMa_Chuyenmon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMa_Chuyenmon_KeyPress);
            // 
            // txtTen_Chuyenmon
            // 
            this.txtTen_Chuyenmon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTen_Chuyenmon.Location = new System.Drawing.Point(572, 3);
            this.txtTen_Chuyenmon.Name = "txtTen_Chuyenmon";
            this.txtTen_Chuyenmon.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtTen_Chuyenmon.Properties.Appearance.Options.UseFont = true;
            this.txtTen_Chuyenmon.Size = new System.Drawing.Size(300, 26);
            this.txtTen_Chuyenmon.TabIndex = 1;
            // 
            // lblTen_Chuyenmon
            // 
            this.lblTen_Chuyenmon.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTen_Chuyenmon.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblTen_Chuyenmon.Location = new System.Drawing.Point(447, 6);
            this.lblTen_Chuyenmon.Name = "lblTen_Chuyenmon";
            this.lblTen_Chuyenmon.Size = new System.Drawing.Size(119, 19);
            this.lblTen_Chuyenmon.TabIndex = 4;
            this.lblTen_Chuyenmon.Text = "Tên chuyên môn";
            // 
            // txtId_Chuyenmon
            // 
            this.txtId_Chuyenmon.Enabled = false;
            this.txtId_Chuyenmon.Location = new System.Drawing.Point(902, 20);
            this.txtId_Chuyenmon.Name = "txtId_Chuyenmon";
            this.txtId_Chuyenmon.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtId_Chuyenmon.Properties.Appearance.Options.UseFont = true;
            this.txtId_Chuyenmon.Size = new System.Drawing.Size(66, 26);
            this.txtId_Chuyenmon.TabIndex = 5;
            this.txtId_Chuyenmon.Visible = false;
            // 
            // xtraHNavigator1
            // 
            this.xtraHNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xtraHNavigator1.GridControl = this.dgrex_Dm_Chuyenmon;
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
            // Frmrex_Dm_Chuyenmon_Add
            // 
            this.AllowRefresh = true;
            this.ClientSize = new System.Drawing.Size(1011, 735);
            this.Controls.Add(this.dgrex_Dm_Chuyenmon);
            this.Controls.Add(this.xtraHNavigator1);
            this.Controls.Add(this.panelControl1);
            this.EditMode = GoobizFrame.Windows.Forms.FormUpdateWithToolbar.EditModes.Separate;
            this.FormState = GoobizFrame.Windows.Forms.FormState.View;
            this.Name = "Frmrex_Dm_Chuyenmon_Add";
            this.Load += new System.EventHandler(this.Frmrex_Dm_Chuyenmon_Add_Load);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrex_Dm_Chuyenmon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa_Chuyenmon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen_Chuyenmon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId_Chuyenmon.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgrex_Dm_Chuyenmon;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtTen_Chuyenmon;
        private DevExpress.XtraEditors.LabelControl lblTen_Chuyenmon;
        private DevExpress.XtraEditors.TextEdit txtMa_Chuyenmon;        
        private DevExpress.XtraEditors.LabelControl lblMa_Chuyenmon;
        //private DevExpress.XtraEditors.LabelControl lblId_Chuyenmon;
        private DevExpress.XtraEditors.TextEdit txtId_Chuyenmon;
        private  GoobizFrame.Windows.Controls.XtraHNavigator xtraHNavigator1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

    }
}
