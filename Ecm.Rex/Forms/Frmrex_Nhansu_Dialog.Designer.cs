namespace Ecm.Rex.Forms
{
    partial class Frmrex_Nhansu_Dialog
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
            this.components = new System.ComponentModel.Container();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.treeList_Bophan = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.dgrex_Nhansu = new DevExpress.XtraGrid.GridControl();
            this.gvrex_Nhansu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit_Ngayvaolam = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraHNavigator2 = new GoobizFrame.Windows.Controls.XtraHNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList_Bophan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrex_Nhansu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvrex_Nhansu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit_Ngayvaolam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit_Ngayvaolam.VistaTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.LookAndFeel.SkinName = "Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // dockManager1
            // 
            this.dockManager1.Controller = this.barAndDockingController1;
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.AllowDrop = true;
            this.dockPanel1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.dockPanel1.Appearance.Options.UseBackColor = true;
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("c368c568-1322-40ee-b26f-124732fc2911");
            this.dockPanel1.Location = new System.Drawing.Point(0, 65);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.ShowAutoHideButton = false;
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.Size = new System.Drawing.Size(200, 500);
            this.dockPanel1.Text = "Cơ cấu tổ chức công ty";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.treeList_Bophan);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(192, 473);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // treeList_Bophan
            // 
            this.treeList_Bophan.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.treeList_Bophan.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treeList_Bophan.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.treeList_Bophan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList_Bophan.KeyFieldName = "Id_Bophan";
            this.treeList_Bophan.Location = new System.Drawing.Point(0, 0);
            this.treeList_Bophan.Name = "treeList_Bophan";
            this.treeList_Bophan.OptionsBehavior.Editable = false;
            this.treeList_Bophan.ParentFieldName = "Id_Bophan_Ql";
            this.treeList_Bophan.Size = new System.Drawing.Size(192, 473);
            this.treeList_Bophan.TabIndex = 0;
            this.treeList_Bophan.AfterFocusNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treeList_Bophan_AfterFocusNode);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "Bộ phận";
            this.treeListColumn1.FieldName = "Ten_Bophan";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 93;
            // 
            // dgrex_Nhansu
            // 
            this.dgrex_Nhansu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrex_Nhansu.EmbeddedNavigator.Buttons.Append.Enabled = false;
            this.dgrex_Nhansu.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.dgrex_Nhansu.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.dgrex_Nhansu.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.dgrex_Nhansu.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.dgrex_Nhansu.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.dgrex_Nhansu.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.dgrex_Nhansu.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.dgrex_Nhansu.EmbeddedNavigator.Buttons.First.Visible = false;
            this.dgrex_Nhansu.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.dgrex_Nhansu.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.dgrex_Nhansu.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.dgrex_Nhansu.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.dgrex_Nhansu.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.dgrex_Nhansu.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.dgrex_Nhansu.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.dgrex_Nhansu.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
            this.dgrex_Nhansu.EmbeddedNavigator.TextStringFormat = "{0}/{1}";
            this.dgrex_Nhansu.Location = new System.Drawing.Point(200, 65);
            this.dgrex_Nhansu.MainView = this.gvrex_Nhansu;
            this.dgrex_Nhansu.Name = "dgrex_Nhansu";
            this.dgrex_Nhansu.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit_Ngayvaolam});
            this.dgrex_Nhansu.Size = new System.Drawing.Size(788, 478);
            this.dgrex_Nhansu.TabIndex = 4;
            this.dgrex_Nhansu.UseEmbeddedNavigator = true;
            this.dgrex_Nhansu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvrex_Nhansu});
            // 
            // gvrex_Nhansu
            // 
            this.gvrex_Nhansu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn21,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn13,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn20,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19});
            this.gvrex_Nhansu.GridControl = this.dgrex_Nhansu;
            this.gvrex_Nhansu.GroupPanelText = "[Kéo một cột vào đây để nhóm]";
            this.gvrex_Nhansu.Name = "gvrex_Nhansu";
            this.gvrex_Nhansu.OptionsBehavior.Editable = false;
            this.gvrex_Nhansu.OptionsSelection.MultiSelect = true;
            this.gvrex_Nhansu.OptionsView.ColumnAutoWidth = false;
            this.gvrex_Nhansu.OptionsView.RowAutoHeight = true;
            this.gvrex_Nhansu.OptionsView.ShowAutoFilterRow = true;
            this.gvrex_Nhansu.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn21
            // 
            this.gridColumn21.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn21.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn21.Caption = "Ngày vào làm";
            this.gridColumn21.ColumnEdit = this.repositoryItemDateEdit_Ngayvaolam;
            this.gridColumn21.FieldName = "Ngay_Vaolam";
            this.gridColumn21.MinWidth = 165;
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.Width = 165;
            // 
            // repositoryItemDateEdit_Ngayvaolam
            // 
            this.repositoryItemDateEdit_Ngayvaolam.AutoHeight = false;
            this.repositoryItemDateEdit_Ngayvaolam.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit_Ngayvaolam.Name = "repositoryItemDateEdit_Ngayvaolam";
            this.repositoryItemDateEdit_Ngayvaolam.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "STT";
            this.gridColumn1.FieldName = "Id_Nhansu";
            this.gridColumn1.MinWidth = 50;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Width = 50;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Mã nhân sự";
            this.gridColumn2.FieldName = "Ma_Nhansu";
            this.gridColumn2.MinWidth = 135;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 135;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Họ";
            this.gridColumn3.FieldName = "Ho_Nhansu";
            this.gridColumn3.MinWidth = 135;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 135;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Tên";
            this.gridColumn4.FieldName = "Ten_Nhansu";
            this.gridColumn4.MinWidth = 135;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 135;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "Ngày sinh";
            this.gridColumn5.FieldName = "Ngaysinh";
            this.gridColumn5.MinWidth = 165;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Width = 165;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Font = new System.Drawing.Font("Arial", 8.25F);
            this.gridColumn6.AppearanceCell.Options.UseFont = true;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "Giới tính";
            this.gridColumn6.FieldName = "Gioitinh";
            this.gridColumn6.MinWidth = 105;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 105;
            // 
            // gridColumn13
            // 
            this.gridColumn13.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn13.Caption = "Điện thoại";
            this.gridColumn13.FieldName = "Dienthoai";
            this.gridColumn13.MinWidth = 105;
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Width = 105;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "CMND";
            this.gridColumn7.FieldName = "Cmnd";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Width = 55;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Ngày cấp";
            this.gridColumn8.ColumnEdit = this.repositoryItemDateEdit_Ngayvaolam;
            this.gridColumn8.FieldName = "Ngaycap";
            this.gridColumn8.Name = "gridColumn8";
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Nơi cấp";
            this.gridColumn20.FieldName = "Noicap";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Width = 64;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Nơi sinh";
            this.gridColumn9.FieldName = "Noisinh";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Width = 37;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Quê quán";
            this.gridColumn10.FieldName = "Quequan";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Width = 37;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Địa chỉ thường trú";
            this.gridColumn11.FieldName = "Diachi_Thuongtru";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Width = 25;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Địa chỉ tạm trú";
            this.gridColumn12.FieldName = "Diachi_Tamtru";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Width = 35;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Dân tộc";
            this.gridColumn14.FieldName = "Ten_Dantoc";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Width = 20;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Tôn giáo";
            this.gridColumn15.FieldName = "Ten_Tongiao";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Width = 20;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Quốc tịch";
            this.gridColumn16.FieldName = "Ten_Quocgia";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Width = 20;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Thành phần gia đình";
            this.gridColumn17.FieldName = "Ten_Tpgiadinh";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Width = 20;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Thành phần bản thân";
            this.gridColumn18.FieldName = "Ten_Tpbanthan";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Width = 20;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Hình";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Width = 20;
            // 
            // xtraHNavigator2
            // 
            this.xtraHNavigator2.ButtonModes = GoobizFrame.Windows.Controls.XtraHNavigator.NavigatorButtonModes.ShowNavigators;
            this.xtraHNavigator2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xtraHNavigator2.GridControl = this.dgrex_Nhansu;
            this.xtraHNavigator2.Location = new System.Drawing.Point(200, 543);
            this.xtraHNavigator2.Margin = new System.Windows.Forms.Padding(0);
            this.xtraHNavigator2.Name = "xtraHNavigator2";
            this.xtraHNavigator2.Size = new System.Drawing.Size(788, 22);
            this.xtraHNavigator2.TabIndex = 14;
            this.xtraHNavigator2.TextStringFormat = "{0}/{1}";
            this.xtraHNavigator2.VisibleAppend = false;
            this.xtraHNavigator2.VisibleCancelEdit = false;
            this.xtraHNavigator2.VisibleEdit = false;
            this.xtraHNavigator2.VisibleEndEdit = false;
            this.xtraHNavigator2.VisibleFirst = true;
            this.xtraHNavigator2.VisibleLast = true;
            this.xtraHNavigator2.VisibleNext = true;
            this.xtraHNavigator2.VisiblePageNext = true;
            this.xtraHNavigator2.VisiblePagePrev = true;
            this.xtraHNavigator2.VisiblePrev = true;
            this.xtraHNavigator2.VisibleRemove = false;
            // 
            // Frmrex_Nhansu_Dialog
            // 
            this.AllowSelect = true;
            this.ClientSize = new System.Drawing.Size(988, 565);
            this.Controls.Add(this.dgrex_Nhansu);
            this.Controls.Add(this.xtraHNavigator2);
            this.Controls.Add(this.dockPanel1);
            this.Name = "Frmrex_Nhansu_Dialog";
            this.Controls.SetChildIndex(this.dockPanel1, 0);
            this.Controls.SetChildIndex(this.xtraHNavigator2, 0);
            this.Controls.SetChildIndex(this.dgrex_Nhansu, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList_Bophan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrex_Nhansu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvrex_Nhansu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit_Ngayvaolam.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit_Ngayvaolam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraTreeList.TreeList treeList_Bophan;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraGrid.GridControl dgrex_Nhansu;
        private DevExpress.XtraGrid.Views.Grid.GridView gvrex_Nhansu;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit_Ngayvaolam;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private GoobizFrame.Windows.Controls.XtraHNavigator xtraHNavigator2;
    }
}
