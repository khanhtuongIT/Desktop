namespace Ecm.MasterTables.Forms.Ware
{
    partial class Frmware_Dm_Soquy_Add
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
            this.dgware_Dm_Soquy = new DevExpress.XtraGrid.GridControl();
            this.gvDm_Soquy = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookupEdit_Kho = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCheckEdit_Khohang = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.xtraHNavigator1 = new GoobizFrame.Windows.Controls.XtraHNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Soquy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDm_Soquy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookupEdit_Kho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCheckEdit_Khohang)).BeginInit();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.LookAndFeel.SkinName = "Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // dgware_Dm_Soquy
            // 
            this.dgware_Dm_Soquy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgware_Dm_Soquy.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.dgware_Dm_Soquy.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.dgware_Dm_Soquy.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.dgware_Dm_Soquy.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.dgware_Dm_Soquy.EmbeddedNavigator.Buttons.First.Visible = false;
            this.dgware_Dm_Soquy.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.dgware_Dm_Soquy.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.dgware_Dm_Soquy.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.dgware_Dm_Soquy.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.dgware_Dm_Soquy.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.dgware_Dm_Soquy.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.dgware_Dm_Soquy.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
            this.dgware_Dm_Soquy.EmbeddedNavigator.TextStringFormat = "Dòng: {0} / {1}";
            this.dgware_Dm_Soquy.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dgware_Dm_Cuahang_Ban_EmbeddedNavigator_ButtonClick);
            this.dgware_Dm_Soquy.Location = new System.Drawing.Point(0, 65);
            this.dgware_Dm_Soquy.MainView = this.gvDm_Soquy;
            this.dgware_Dm_Soquy.Name = "dgware_Dm_Soquy";
            this.dgware_Dm_Soquy.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gridCheckEdit_Khohang,
            this.gridLookupEdit_Kho});
            this.dgware_Dm_Soquy.Size = new System.Drawing.Size(1008, 660);
            this.dgware_Dm_Soquy.TabIndex = 1;
            this.dgware_Dm_Soquy.UseEmbeddedNavigator = true;
            this.dgware_Dm_Soquy.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDm_Soquy});
            // 
            // gvDm_Soquy
            // 
            this.gvDm_Soquy.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gvDm_Soquy.GridControl = this.dgware_Dm_Soquy;
            this.gvDm_Soquy.GroupPanelText = "[Kéo một cột vào đây để nhóm]";
            this.gvDm_Soquy.Name = "gvDm_Soquy";
            this.gvDm_Soquy.OptionsNavigation.AutoFocusNewRow = true;
            this.gvDm_Soquy.OptionsView.ShowGroupPanel = false;
            this.gvDm_Soquy.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gvDm_Soquy.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Số thứ tự";
            this.gridColumn1.FieldName = "Id_Cuahang_Ban";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Mã sổ quỹ";
            this.gridColumn2.FieldName = "Ma_Soquy";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 330;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Tên sổ quỹ";
            this.gridColumn3.FieldName = "Ten_Soquy";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 418;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Kho";
            this.gridColumn4.ColumnEdit = this.gridLookupEdit_Kho;
            this.gridColumn4.FieldName = "Id_Cuahang_Ban";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 242;
            // 
            // gridLookupEdit_Kho
            // 
            this.gridLookupEdit_Kho.AutoHeight = false;
            this.gridLookupEdit_Kho.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookupEdit_Kho.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Cuahang_Ban", "Stt", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Cuahang_Ban", 30, "Mã kho"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Cuahang_Ban", 70, "Tên kho")});
            this.gridLookupEdit_Kho.DisplayMember = "Ten_Cuahang_Ban";
            this.gridLookupEdit_Kho.Name = "gridLookupEdit_Kho";
            this.gridLookupEdit_Kho.NullText = "";
            this.gridLookupEdit_Kho.ValueMember = "Id_Cuahang_Ban";
            // 
            // gridCheckEdit_Khohang
            // 
            this.gridCheckEdit_Khohang.AutoHeight = false;
            this.gridCheckEdit_Khohang.Name = "gridCheckEdit_Khohang";
            this.gridCheckEdit_Khohang.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.gridCheckEdit_Khohang.ValueGrayed = false;
            // 
            // xtraHNavigator1
            // 
            this.xtraHNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xtraHNavigator1.GridControl = this.dgware_Dm_Soquy;
            this.xtraHNavigator1.Location = new System.Drawing.Point(0, 725);
            this.xtraHNavigator1.Margin = new System.Windows.Forms.Padding(0);
            this.xtraHNavigator1.Name = "xtraHNavigator1";
            this.xtraHNavigator1.Size = new System.Drawing.Size(1008, 24);
            this.xtraHNavigator1.TabIndex = 8;
            this.xtraHNavigator1.TextStringFormat = "Dòng: {0} / {1}";
            this.xtraHNavigator1.VisibleFirst = true;
            this.xtraHNavigator1.VisibleLast = true;
            this.xtraHNavigator1.VisibleNext = true;
            this.xtraHNavigator1.VisiblePageNext = true;
            this.xtraHNavigator1.VisiblePagePrev = true;
            this.xtraHNavigator1.VisiblePrev = true;
            // 
            // Frmware_Dm_Soquy_Add
            // 
            this.AllowRefresh = true;
            this.ClientSize = new System.Drawing.Size(1008, 749);
            this.Controls.Add(this.dgware_Dm_Soquy);
            this.Controls.Add(this.xtraHNavigator1);
            this.EditMode = GoobizFrame.Windows.Forms.FormUpdateWithToolbar.EditModes.Separate;
            this.FormState = GoobizFrame.Windows.Forms.FormState.View;
            this.Name = "Frmware_Dm_Soquy_Add";
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Soquy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDm_Soquy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookupEdit_Kho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCheckEdit_Khohang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgware_Dm_Soquy;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDm_Soquy;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private GoobizFrame.Windows.Controls.XtraHNavigator xtraHNavigator1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit gridCheckEdit_Khohang;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridLookupEdit_Kho;
    }
}
