namespace Ecm.Ware.Forms
{
    partial class Frmware_Dm_Cuahang_Ban_Dialog
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
            this.dgware_Dm_Cuahang_Ban = new DevExpress.XtraGrid.GridControl();
            this.gvCuahang_Ban = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCheckEdit_Chon = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.xtraHNavigator1 = new GoobizFrame.Windows.Controls.XtraHNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Cuahang_Ban)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCuahang_Ban)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCheckEdit_Chon)).BeginInit();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.LookAndFeel.SkinName = "Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // dgware_Dm_Cuahang_Ban
            // 
            this.dgware_Dm_Cuahang_Ban.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgware_Dm_Cuahang_Ban.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.dgware_Dm_Cuahang_Ban.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.dgware_Dm_Cuahang_Ban.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.dgware_Dm_Cuahang_Ban.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.dgware_Dm_Cuahang_Ban.EmbeddedNavigator.Buttons.First.Visible = false;
            this.dgware_Dm_Cuahang_Ban.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.dgware_Dm_Cuahang_Ban.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.dgware_Dm_Cuahang_Ban.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.dgware_Dm_Cuahang_Ban.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.dgware_Dm_Cuahang_Ban.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.dgware_Dm_Cuahang_Ban.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.dgware_Dm_Cuahang_Ban.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
            this.dgware_Dm_Cuahang_Ban.EmbeddedNavigator.TextStringFormat = "Dòng: {0} / {1}";
            this.dgware_Dm_Cuahang_Ban.Location = new System.Drawing.Point(0, 65);
            this.dgware_Dm_Cuahang_Ban.MainView = this.gvCuahang_Ban;
            this.dgware_Dm_Cuahang_Ban.Name = "dgware_Dm_Cuahang_Ban";
            this.dgware_Dm_Cuahang_Ban.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gridCheckEdit_Chon});
            this.dgware_Dm_Cuahang_Ban.Size = new System.Drawing.Size(542, 384);
            this.dgware_Dm_Cuahang_Ban.TabIndex = 1;
            this.dgware_Dm_Cuahang_Ban.UseEmbeddedNavigator = true;
            this.dgware_Dm_Cuahang_Ban.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCuahang_Ban});
            // 
            // gvCuahang_Ban
            // 
            this.gvCuahang_Ban.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gvCuahang_Ban.GridControl = this.dgware_Dm_Cuahang_Ban;
            this.gvCuahang_Ban.GroupPanelText = "[Kéo một cột vào đây để nhóm]";
            this.gvCuahang_Ban.Name = "gvCuahang_Ban";
            this.gvCuahang_Ban.OptionsNavigation.AutoFocusNewRow = true;
            this.gvCuahang_Ban.OptionsView.ShowAutoFilterRow = true;
            this.gvCuahang_Ban.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Số thứ tự";
            this.gridColumn1.FieldName = "Id_Cuahang_Ban";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Mã khu vực";
            this.gridColumn2.FieldName = "Ma_Cuahang_Ban";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 111;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Tên khu vực";
            this.gridColumn3.FieldName = "Ten_Cuahang_Ban";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 353;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Chọn";
            this.gridColumn4.ColumnEdit = this.gridCheckEdit_Chon;
            this.gridColumn4.FieldName = "Chon";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 61;
            // 
            // gridCheckEdit_Chon
            // 
            this.gridCheckEdit_Chon.AutoHeight = false;
            this.gridCheckEdit_Chon.Name = "gridCheckEdit_Chon";
            // 
            // xtraHNavigator1
            // 
            this.xtraHNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xtraHNavigator1.GridControl = this.dgware_Dm_Cuahang_Ban;
            this.xtraHNavigator1.Location = new System.Drawing.Point(0, 449);
            this.xtraHNavigator1.Margin = new System.Windows.Forms.Padding(0);
            this.xtraHNavigator1.Name = "xtraHNavigator1";
            this.xtraHNavigator1.Size = new System.Drawing.Size(542, 24);
            this.xtraHNavigator1.TabIndex = 8;
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
            // Frmware_Dm_Cuahang_Ban_Dialog
            // 
            this.AllowRefresh = true;
            this.AllowSelect = true;
            this.ClientSize = new System.Drawing.Size(542, 473);
            this.Controls.Add(this.dgware_Dm_Cuahang_Ban);
            this.Controls.Add(this.xtraHNavigator1);
            this.EditMode = GoobizFrame.Windows.Forms.FormUpdateWithToolbar.EditModes.Separate;
            this.EnableAdd = false;
            this.FormState = GoobizFrame.Windows.Forms.FormState.View;
            this.Name = "Frmware_Dm_Cuahang_Ban_Dialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Cuahang_Ban)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCuahang_Ban)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCheckEdit_Chon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgware_Dm_Cuahang_Ban;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCuahang_Ban;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private GoobizFrame.Windows.Controls.XtraHNavigator xtraHNavigator1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit gridCheckEdit_Chon;
    }
}
