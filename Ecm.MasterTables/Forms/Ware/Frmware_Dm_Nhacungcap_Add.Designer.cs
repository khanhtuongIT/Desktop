namespace Ecm.MasterTables.Forms.Ware
{
    partial class Frmware_Dm_Nhacungcap_Add
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
            this.dgware_Dm_Nhacungcap = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridText_Dienthoai = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridText_Fax = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridText_Email = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridText_Website = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.xtraHNavigator1 = new GoobizFrame.Windows.Controls.XtraHNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Nhacungcap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridText_Dienthoai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridText_Fax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridText_Email)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridText_Website)).BeginInit();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.LookAndFeel.SkinName = "Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // dgware_Dm_Nhacungcap
            // 
            this.dgware_Dm_Nhacungcap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgware_Dm_Nhacungcap.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.dgware_Dm_Nhacungcap.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.dgware_Dm_Nhacungcap.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.dgware_Dm_Nhacungcap.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.dgware_Dm_Nhacungcap.EmbeddedNavigator.Buttons.First.Visible = false;
            this.dgware_Dm_Nhacungcap.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.dgware_Dm_Nhacungcap.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.dgware_Dm_Nhacungcap.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.dgware_Dm_Nhacungcap.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.dgware_Dm_Nhacungcap.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.dgware_Dm_Nhacungcap.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.dgware_Dm_Nhacungcap.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
            this.dgware_Dm_Nhacungcap.EmbeddedNavigator.TextStringFormat = "Dòng: {0} / {1}";
            this.dgware_Dm_Nhacungcap.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dgware_Dm_Nhacungcap_EmbeddedNavigator_ButtonClick);
            this.dgware_Dm_Nhacungcap.Location = new System.Drawing.Point(0, 65);
            this.dgware_Dm_Nhacungcap.MainView = this.gridView1;
            this.dgware_Dm_Nhacungcap.Name = "dgware_Dm_Nhacungcap";
            this.dgware_Dm_Nhacungcap.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gridText_Dienthoai,
            this.gridText_Fax,
            this.gridText_Email,
            this.gridText_Website});
            this.dgware_Dm_Nhacungcap.Size = new System.Drawing.Size(1008, 660);
            this.dgware_Dm_Nhacungcap.TabIndex = 1;
            this.dgware_Dm_Nhacungcap.UseEmbeddedNavigator = true;
            this.dgware_Dm_Nhacungcap.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9});
            this.gridView1.GridControl = this.dgware_Dm_Nhacungcap;
            this.gridView1.GroupPanelText = "[Kéo một cột vào đây để nhóm]";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow_1);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Số thứ tự";
            this.gridColumn1.FieldName = "Id_Nhacungcap";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Mã nhà cung cấp";
            this.gridColumn2.FieldName = "Ma_Nhacungcap";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 123;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Tên nhà cung cấp";
            this.gridColumn3.FieldName = "Ten_Nhacungcap";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 180;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Địa chỉ";
            this.gridColumn4.FieldName = "Diachi_Nhacungcap";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 113;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "Mã số thuế";
            this.gridColumn5.FieldName = "Masothue";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 118;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "Điện thoại";
            this.gridColumn6.ColumnEdit = this.gridText_Dienthoai;
            this.gridColumn6.FieldName = "Dienthoai";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 113;
            // 
            // gridText_Dienthoai
            // 
            this.gridText_Dienthoai.AutoHeight = false;
            this.gridText_Dienthoai.Mask.EditMask = "[+|(]?[0-9]+[)]?([.|-]?[\\(0-9\\)]+)+";
            this.gridText_Dienthoai.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.gridText_Dienthoai.Mask.ShowPlaceHolders = false;
            this.gridText_Dienthoai.Name = "gridText_Dienthoai";
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "Fax";
            this.gridColumn7.ColumnEdit = this.gridText_Fax;
            this.gridColumn7.FieldName = "Fax";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            this.gridColumn7.Width = 95;
            // 
            // gridText_Fax
            // 
            this.gridText_Fax.AutoHeight = false;
            this.gridText_Fax.Mask.EditMask = "[+|(]?[0-9]+[)]?([.|-]?[\\(0-9\\)]+)+";
            this.gridText_Fax.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.gridText_Fax.Mask.ShowPlaceHolders = false;
            this.gridText_Fax.Name = "gridText_Fax";
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.Caption = "Email";
            this.gridColumn8.ColumnEdit = this.gridText_Email;
            this.gridColumn8.FieldName = "Email";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 118;
            // 
            // gridText_Email
            // 
            this.gridText_Email.AutoHeight = false;
            this.gridText_Email.Mask.EditMask = "[_]?([a-zA-Z1-9]+[_]?[a-zA-Z1-9]+)+[_]?[@][_]?([a-zA-Z1-9]+[_]?[a-zA-Z1-9]+)+[_]?" +
    "([.][a-zA-Z1-9]+)+";
            this.gridText_Email.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.gridText_Email.Mask.ShowPlaceHolders = false;
            this.gridText_Email.Name = "gridText_Email";
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.Caption = "Website";
            this.gridColumn9.ColumnEdit = this.gridText_Website;
            this.gridColumn9.FieldName = "Website";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Width = 130;
            // 
            // gridText_Website
            // 
            this.gridText_Website.AutoHeight = false;
            this.gridText_Website.Mask.EditMask = "(http://)[_]?([a-zA-Z1-9]+[_]?[a-zA-Z1-9]+)+[_]?([.][a-zA-Z1-9]+)+";
            this.gridText_Website.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.gridText_Website.Mask.ShowPlaceHolders = false;
            this.gridText_Website.Name = "gridText_Website";
            // 
            // xtraHNavigator1
            // 
            this.xtraHNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xtraHNavigator1.GridControl = this.dgware_Dm_Nhacungcap;
            this.xtraHNavigator1.Location = new System.Drawing.Point(0, 725);
            this.xtraHNavigator1.Margin = new System.Windows.Forms.Padding(0);
            this.xtraHNavigator1.Name = "xtraHNavigator1";
            this.xtraHNavigator1.Size = new System.Drawing.Size(1008, 24);
            this.xtraHNavigator1.TabIndex = 11;
            this.xtraHNavigator1.TextStringFormat = "Dòng: {0} / {1}";
            this.xtraHNavigator1.VisibleFirst = true;
            this.xtraHNavigator1.VisibleLast = true;
            this.xtraHNavigator1.VisibleNext = true;
            this.xtraHNavigator1.VisiblePageNext = true;
            this.xtraHNavigator1.VisiblePagePrev = true;
            this.xtraHNavigator1.VisiblePrev = true;
            // 
            // Frmware_Dm_Nhacungcap_Add
            // 
            this.AllowRefresh = true;
            this.ClientSize = new System.Drawing.Size(1008, 749);
            this.Controls.Add(this.dgware_Dm_Nhacungcap);
            this.Controls.Add(this.xtraHNavigator1);
            this.EditMode = GoobizFrame.Windows.Forms.FormUpdateWithToolbar.EditModes.Separate;
            this.EnableAdd = false;
            this.EnableDelete = true;
            this.EnableEdit = false;
            this.FormState = GoobizFrame.Windows.Forms.FormState.View;
            this.Name = "Frmware_Dm_Nhacungcap_Add";
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgware_Dm_Nhacungcap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridText_Dienthoai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridText_Fax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridText_Email)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridText_Website)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgware_Dm_Nhacungcap;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit gridText_Dienthoai;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit gridText_Fax;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit gridText_Email;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit gridText_Website;
        private GoobizFrame.Windows.Controls.XtraHNavigator xtraHNavigator1;
    }
}
