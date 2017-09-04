namespace Ecm.MasterTables.Forms.Ware
{
    partial class Frmware_Dm_Theocap_Add
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
            this.dgware_Dm_Donvitinh_Theocap = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraNav = new GoobizFrame.Windows.Controls.XtraHNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Donvitinh_Theocap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // dgware_Dm_Donvitinh_Theocap
            // 
            this.dgware_Dm_Donvitinh_Theocap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgware_Dm_Donvitinh_Theocap.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.dgware_Dm_Donvitinh_Theocap.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.dgware_Dm_Donvitinh_Theocap.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.dgware_Dm_Donvitinh_Theocap.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.dgware_Dm_Donvitinh_Theocap.EmbeddedNavigator.Buttons.First.Visible = false;
            this.dgware_Dm_Donvitinh_Theocap.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.dgware_Dm_Donvitinh_Theocap.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.dgware_Dm_Donvitinh_Theocap.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.dgware_Dm_Donvitinh_Theocap.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.dgware_Dm_Donvitinh_Theocap.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.dgware_Dm_Donvitinh_Theocap.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.dgware_Dm_Donvitinh_Theocap.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
            this.dgware_Dm_Donvitinh_Theocap.EmbeddedNavigator.TextStringFormat = "Dòng: {0} / {1}";
            this.dgware_Dm_Donvitinh_Theocap.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dgware_Dm_Donvitinh_Theocap_EmbeddedNavigator_ButtonClick);
            this.dgware_Dm_Donvitinh_Theocap.Location = new System.Drawing.Point(0, 65);
            this.dgware_Dm_Donvitinh_Theocap.MainView = this.gridView1;
            this.dgware_Dm_Donvitinh_Theocap.Name = "dgware_Dm_Donvitinh_Theocap";
            this.dgware_Dm_Donvitinh_Theocap.Size = new System.Drawing.Size(1103, 874);
            this.dgware_Dm_Donvitinh_Theocap.TabIndex = 4;
            this.dgware_Dm_Donvitinh_Theocap.UseEmbeddedNavigator = true;
            this.dgware_Dm_Donvitinh_Theocap.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.GridControl = this.dgware_Dm_Donvitinh_Theocap;
            this.gridView1.GroupPanelText = "[Kéo một cột vào đây để nhóm]";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Số thứ tự";
            this.gridColumn1.FieldName = "Id_Donvitinh";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Width = 20;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Mã cấp";
            this.gridColumn2.FieldName = "Id_Cap";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 258;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Tên cấp";
            this.gridColumn3.FieldName = "Giatri";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 772;
            // 
            // xtraNav
            // 
            this.xtraNav.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xtraNav.GridControl = this.dgware_Dm_Donvitinh_Theocap;
            this.xtraNav.Location = new System.Drawing.Point(0, 915);
            this.xtraNav.Margin = new System.Windows.Forms.Padding(0);
            this.xtraNav.Name = "xtraNav";
            this.xtraNav.Size = new System.Drawing.Size(1103, 24);
            this.xtraNav.TabIndex = 9;
            this.xtraNav.TextStringFormat = "Dòng: {0} / {1}";
            this.xtraNav.VisibleFirst = true;
            this.xtraNav.VisibleLast = true;
            this.xtraNav.VisibleNext = true;
            this.xtraNav.VisiblePageNext = true;
            this.xtraNav.VisiblePagePrev = true;
            this.xtraNav.VisiblePrev = true;
            // 
            // Frmware_Dm_Theocap_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 939);
            this.Controls.Add(this.xtraNav);
            this.Controls.Add(this.dgware_Dm_Donvitinh_Theocap);
            this.EditMode = GoobizFrame.Windows.Forms.FormUpdateWithToolbar.EditModes.Separate;
            this.FormState = GoobizFrame.Windows.Forms.FormState.View;
            this.Name = "Frmware_Dm_Theocap_Add";
            this.Load += new System.EventHandler(this.Frmware_Dm_Theocap_Add_Load);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Donvitinh_Theocap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgware_Dm_Donvitinh_Theocap;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private GoobizFrame.Windows.Controls.XtraHNavigator xtraNav;
    }
}