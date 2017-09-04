namespace Ecm.MasterTables.Forms.Ware
{
    partial class Frmware_Dm_Loai_Hanghoa_Ban_Add
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
            this.dgware_Dm_Loai_Hanghoa_Ban = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookUp_Nhom_Hanghoa_Ban = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtTen_Loai_Hanghoa_Ban = new DevExpress.XtraEditors.TextEdit();
            this.lblTen_Loai_Hanghoa_Ban = new DevExpress.XtraEditors.LabelControl();
            this.lblMa_Loai_Hanghoa_Ban = new DevExpress.XtraEditors.LabelControl();
            this.txtMa_Loai_Hanghoa_Ban = new DevExpress.XtraEditors.TextEdit();
            this.xtraHNavigator1 = new GoobizFrame.Windows.Controls.XtraHNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Loai_Hanghoa_Ban)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUp_Nhom_Hanghoa_Ban)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen_Loai_Hanghoa_Ban.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa_Loai_Hanghoa_Ban.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.LookAndFeel.SkinName = "Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // dgware_Dm_Loai_Hanghoa_Ban
            // 
            this.dgware_Dm_Loai_Hanghoa_Ban.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgware_Dm_Loai_Hanghoa_Ban.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.dgware_Dm_Loai_Hanghoa_Ban.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.dgware_Dm_Loai_Hanghoa_Ban.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.dgware_Dm_Loai_Hanghoa_Ban.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.dgware_Dm_Loai_Hanghoa_Ban.EmbeddedNavigator.Buttons.First.Visible = false;
            this.dgware_Dm_Loai_Hanghoa_Ban.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.dgware_Dm_Loai_Hanghoa_Ban.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.dgware_Dm_Loai_Hanghoa_Ban.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.dgware_Dm_Loai_Hanghoa_Ban.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.dgware_Dm_Loai_Hanghoa_Ban.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.dgware_Dm_Loai_Hanghoa_Ban.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.dgware_Dm_Loai_Hanghoa_Ban.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
            this.dgware_Dm_Loai_Hanghoa_Ban.EmbeddedNavigator.TextStringFormat = "Dòng: {0} / {1}";
            this.dgware_Dm_Loai_Hanghoa_Ban.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dgware_Dm_Loai_Hanghoa_Ban_EmbeddedNavigator_ButtonClick);
            this.dgware_Dm_Loai_Hanghoa_Ban.Location = new System.Drawing.Point(0, 112);
            this.dgware_Dm_Loai_Hanghoa_Ban.MainView = this.gridView1;
            this.dgware_Dm_Loai_Hanghoa_Ban.Name = "dgware_Dm_Loai_Hanghoa_Ban";
            this.dgware_Dm_Loai_Hanghoa_Ban.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gridLookUp_Nhom_Hanghoa_Ban});
            this.dgware_Dm_Loai_Hanghoa_Ban.Size = new System.Drawing.Size(1054, 340);
            this.dgware_Dm_Loai_Hanghoa_Ban.TabIndex = 1;
            this.dgware_Dm_Loai_Hanghoa_Ban.UseEmbeddedNavigator = true;
            this.dgware_Dm_Loai_Hanghoa_Ban.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gridView1.GridControl = this.dgware_Dm_Loai_Hanghoa_Ban;
            this.gridView1.GroupPanelText = "[Kéo một cột vào đây để nhóm]";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Số thứ tự";
            this.gridColumn1.FieldName = "Id_Loai_Hanghoa_Ban";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Mã nhóm hàng";
            this.gridColumn2.FieldName = "Ma_Loai_Hanghoa_Ban";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 218;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Tên nhóm hàng";
            this.gridColumn3.FieldName = "Ten_Loai_Hanghoa_Ban";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 404;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Nhóm hàng hóa";
            this.gridColumn4.ColumnEdit = this.gridLookUp_Nhom_Hanghoa_Ban;
            this.gridColumn4.FieldName = "Id_Nhom_Hanghoa_Ban";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Width = 132;
            // 
            // gridLookUp_Nhom_Hanghoa_Ban
            // 
            this.gridLookUp_Nhom_Hanghoa_Ban.AutoHeight = false;
            this.gridLookUp_Nhom_Hanghoa_Ban.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUp_Nhom_Hanghoa_Ban.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Nhom_Hanghoa_Ban", "Stt", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Nhom_Hanghoa_Ban", "Mã nhóm HH bán"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Nhom_Hanghoa_Ban", "Tên nhóm HH bán")});
            this.gridLookUp_Nhom_Hanghoa_Ban.DisplayMember = "Ten_Nhom_Hanghoa_Ban";
            this.gridLookUp_Nhom_Hanghoa_Ban.Name = "gridLookUp_Nhom_Hanghoa_Ban";
            this.gridLookUp_Nhom_Hanghoa_Ban.NullText = "";
            this.gridLookUp_Nhom_Hanghoa_Ban.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.gridLookUp_Nhom_Hanghoa_Ban.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.gridLookUp_Nhom_Hanghoa_Ban.ValueMember = "Id_Nhom_Hanghoa_Ban";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.tableLayoutPanel1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 65);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1054, 47);
            this.panelControl1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.txtTen_Loai_Hanghoa_Ban, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTen_Loai_Hanghoa_Ban, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblMa_Loai_Hanghoa_Ban, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtMa_Loai_Hanghoa_Ban, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1050, 43);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // txtTen_Loai_Hanghoa_Ban
            // 
            this.txtTen_Loai_Hanghoa_Ban.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTen_Loai_Hanghoa_Ban.Location = new System.Drawing.Point(483, 3);
            this.txtTen_Loai_Hanghoa_Ban.Name = "txtTen_Loai_Hanghoa_Ban";
            this.txtTen_Loai_Hanghoa_Ban.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtTen_Loai_Hanghoa_Ban.Properties.Appearance.Options.UseFont = true;
            this.txtTen_Loai_Hanghoa_Ban.Size = new System.Drawing.Size(223, 26);
            this.txtTen_Loai_Hanghoa_Ban.TabIndex = 2;
            // 
            // lblTen_Loai_Hanghoa_Ban
            // 
            this.lblTen_Loai_Hanghoa_Ban.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTen_Loai_Hanghoa_Ban.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblTen_Loai_Hanghoa_Ban.Location = new System.Drawing.Point(364, 6);
            this.lblTen_Loai_Hanghoa_Ban.Name = "lblTen_Loai_Hanghoa_Ban";
            this.lblTen_Loai_Hanghoa_Ban.Size = new System.Drawing.Size(113, 19);
            this.lblTen_Loai_Hanghoa_Ban.TabIndex = 4;
            this.lblTen_Loai_Hanghoa_Ban.Text = "Tên nhóm hàng";
            // 
            // lblMa_Loai_Hanghoa_Ban
            // 
            this.lblMa_Loai_Hanghoa_Ban.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMa_Loai_Hanghoa_Ban.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblMa_Loai_Hanghoa_Ban.Location = new System.Drawing.Point(3, 6);
            this.lblMa_Loai_Hanghoa_Ban.Name = "lblMa_Loai_Hanghoa_Ban";
            this.lblMa_Loai_Hanghoa_Ban.Size = new System.Drawing.Size(106, 19);
            this.lblMa_Loai_Hanghoa_Ban.TabIndex = 2;
            this.lblMa_Loai_Hanghoa_Ban.Text = "Mã nhóm hàng";
            // 
            // txtMa_Loai_Hanghoa_Ban
            // 
            this.txtMa_Loai_Hanghoa_Ban.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMa_Loai_Hanghoa_Ban.Location = new System.Drawing.Point(115, 3);
            this.txtMa_Loai_Hanghoa_Ban.Name = "txtMa_Loai_Hanghoa_Ban";
            this.txtMa_Loai_Hanghoa_Ban.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtMa_Loai_Hanghoa_Ban.Properties.Appearance.Options.UseFont = true;
            this.txtMa_Loai_Hanghoa_Ban.Size = new System.Drawing.Size(223, 26);
            this.txtMa_Loai_Hanghoa_Ban.TabIndex = 1;
            this.txtMa_Loai_Hanghoa_Ban.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMa_Loai_Hanghoa_Ban_KeyPress);
            // 
            // xtraHNavigator1
            // 
            this.xtraHNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xtraHNavigator1.GridControl = this.dgware_Dm_Loai_Hanghoa_Ban;
            this.xtraHNavigator1.Location = new System.Drawing.Point(0, 452);
            this.xtraHNavigator1.Margin = new System.Windows.Forms.Padding(0);
            this.xtraHNavigator1.Name = "xtraHNavigator1";
            this.xtraHNavigator1.Size = new System.Drawing.Size(1054, 24);
            this.xtraHNavigator1.TabIndex = 4;
            this.xtraHNavigator1.TextStringFormat = "Dòng: {0} / {1}";
            this.xtraHNavigator1.VisibleFirst = true;
            this.xtraHNavigator1.VisibleLast = true;
            this.xtraHNavigator1.VisibleNext = true;
            this.xtraHNavigator1.VisiblePageNext = true;
            this.xtraHNavigator1.VisiblePagePrev = true;
            this.xtraHNavigator1.VisiblePrev = true;
            // 
            // Frmware_Dm_Loai_Hanghoa_Ban_Add
            // 
            this.AllowRefresh = true;
            this.AllowSelect = true;
            this.ClientSize = new System.Drawing.Size(1054, 476);
            this.Controls.Add(this.dgware_Dm_Loai_Hanghoa_Ban);
            this.Controls.Add(this.xtraHNavigator1);
            this.Controls.Add(this.panelControl1);
            this.EditMode = GoobizFrame.Windows.Forms.FormUpdateWithToolbar.EditModes.Separate;
            this.FormState = GoobizFrame.Windows.Forms.FormState.View;
            this.Name = "Frmware_Dm_Loai_Hanghoa_Ban_Add";
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Loai_Hanghoa_Ban)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUp_Nhom_Hanghoa_Ban)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen_Loai_Hanghoa_Ban.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa_Loai_Hanghoa_Ban.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgware_Dm_Loai_Hanghoa_Ban;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridLookUp_Nhom_Hanghoa_Ban;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtTen_Loai_Hanghoa_Ban;
        private DevExpress.XtraEditors.LabelControl lblTen_Loai_Hanghoa_Ban;
        private DevExpress.XtraEditors.TextEdit txtMa_Loai_Hanghoa_Ban;
        private DevExpress.XtraEditors.LabelControl lblMa_Loai_Hanghoa_Ban;
        private  GoobizFrame.Windows.Controls.XtraHNavigator xtraHNavigator1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
