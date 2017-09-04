namespace Ecm.MasterTables.Forms.Ware
{
    partial class Frmware_Dm_Loai_Hanghoa_Ban_Dialog
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
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCheck_Choice = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.xtraHNavigator1 = new GoobizFrame.Windows.Controls.XtraHNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Loai_Hanghoa_Ban)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUp_Nhom_Hanghoa_Ban)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCheck_Choice)).BeginInit();
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
            this.dgware_Dm_Loai_Hanghoa_Ban.Location = new System.Drawing.Point(0, 65);
            this.dgware_Dm_Loai_Hanghoa_Ban.MainView = this.gridView1;
            this.dgware_Dm_Loai_Hanghoa_Ban.Name = "dgware_Dm_Loai_Hanghoa_Ban";
            this.dgware_Dm_Loai_Hanghoa_Ban.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gridLookUp_Nhom_Hanghoa_Ban,
            this.gridCheck_Choice});
            this.dgware_Dm_Loai_Hanghoa_Ban.Size = new System.Drawing.Size(638, 309);
            this.dgware_Dm_Loai_Hanghoa_Ban.TabIndex = 4;
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
            this.gridColumn4,
            this.gridColumn5});
            this.gridView1.GridControl = this.dgware_Dm_Loai_Hanghoa_Ban;
            this.gridView1.GroupCount = 1;
            this.gridView1.GroupPanelText = "[Kéo một cột vào đây để nhóm]";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn4, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Số thứ tự";
            this.gridColumn1.FieldName = "Id_Loai_Hanghoa_Ban";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Mã loại hàng hóa";
            this.gridColumn2.FieldName = "Ma_Loai_Hanghoa_Ban";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 138;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Tên loại hàng hóa";
            this.gridColumn3.FieldName = "Ten_Loai_Hanghoa_Ban";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 142;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Nhóm hàng hóa";
            this.gridColumn4.ColumnEdit = this.gridLookUp_Nhom_Hanghoa_Ban;
            this.gridColumn4.FieldName = "Id_Nhom_Hanghoa_Ban";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // gridLookUp_Nhom_Hanghoa_Ban
            // 
            this.gridLookUp_Nhom_Hanghoa_Ban.AutoHeight = false;
            this.gridLookUp_Nhom_Hanghoa_Ban.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUp_Nhom_Hanghoa_Ban.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Nhom_Hanghoa_Ban", "Stt"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Nhom_Hanghoa_Ban", "Mã nhóm HH bán"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Nhom_Hanghoa_Ban", "Tên nhóm HH bán")});
            this.gridLookUp_Nhom_Hanghoa_Ban.DisplayMember = "Ten_Nhom_Hanghoa_Ban";
            this.gridLookUp_Nhom_Hanghoa_Ban.Name = "gridLookUp_Nhom_Hanghoa_Ban";
            this.gridLookUp_Nhom_Hanghoa_Ban.NullText = "";
            this.gridLookUp_Nhom_Hanghoa_Ban.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.gridLookUp_Nhom_Hanghoa_Ban.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.gridLookUp_Nhom_Hanghoa_Ban.ValueMember = "Id_Nhom_Hanghoa_Ban";
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "Chọn";
            this.gridColumn5.ColumnEdit = this.gridCheck_Choice;
            this.gridColumn5.FieldName = "Chon";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            // 
            // gridCheck_Choice
            // 
            this.gridCheck_Choice.AutoHeight = false;
            this.gridCheck_Choice.Name = "gridCheck_Choice";
            this.gridCheck_Choice.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // xtraHNavigator1
            // 
            this.xtraHNavigator1.ButtonModes = GoobizFrame.Windows.Controls.XtraHNavigator.NavigatorButtonModes.ShowNavigators;
            this.xtraHNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xtraHNavigator1.GridControl = this.dgware_Dm_Loai_Hanghoa_Ban;
            this.xtraHNavigator1.Location = new System.Drawing.Point(0, 374);
            this.xtraHNavigator1.Margin = new System.Windows.Forms.Padding(0);
            this.xtraHNavigator1.Name = "xtraHNavigator1";
            this.xtraHNavigator1.Size = new System.Drawing.Size(638, 24);
            this.xtraHNavigator1.TabIndex = 11;
            this.xtraHNavigator1.TextStringFormat = "Dòng: {0} / {1}";
            this.xtraHNavigator1.VisibleAppend = false;
            this.xtraHNavigator1.VisibleCancelEdit = false;
            this.xtraHNavigator1.VisibleEdit = false;
            this.xtraHNavigator1.VisibleEndEdit = false;
            this.xtraHNavigator1.VisibleFirst = true;
            this.xtraHNavigator1.VisibleLast = true;
            this.xtraHNavigator1.VisibleNext = true;
            this.xtraHNavigator1.VisiblePageNext = true;
            this.xtraHNavigator1.VisiblePagePrev = true;
            this.xtraHNavigator1.VisiblePrev = true;
            this.xtraHNavigator1.VisibleRemove = false;
            // 
            // Frmware_Dm_Loai_Hanghoa_Ban_Dialog
            // 
            this.ClientSize = new System.Drawing.Size(638, 398);
            this.Controls.Add(this.dgware_Dm_Loai_Hanghoa_Ban);
            this.Controls.Add(this.xtraHNavigator1);
            this.EditMode = GoobizFrame.Windows.Forms.FormUpdateWithToolbar.EditModes.Separate;
            this.FormState = GoobizFrame.Windows.Forms.FormState.View;
            this.Name = "Frmware_Dm_Loai_Hanghoa_Ban_Dialog";
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Loai_Hanghoa_Ban)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUp_Nhom_Hanghoa_Ban)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCheck_Choice)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit gridCheck_Choice;
        private  GoobizFrame.Windows.Controls.XtraHNavigator xtraHNavigator1;
    }
}
