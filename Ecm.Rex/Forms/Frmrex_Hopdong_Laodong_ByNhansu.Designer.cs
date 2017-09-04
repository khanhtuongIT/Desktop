namespace Ecm.Rex.Forms
{
    partial class Frmrex_Hopdong_Laodong_ByNhansu
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
            this.dgrex_Hopdong_Laodong = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookUp_Nhansu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookUp_Loai_Hopdong = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridDate_Ngay_Batdau = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookUpEdit_Nhansu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.xtraHNavigator1 = new GoobizFrame.Windows.Controls.XtraHNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrex_Hopdong_Laodong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUp_Nhansu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUp_Loai_Hopdong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDate_Ngay_Batdau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDate_Ngay_Batdau.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Nhansu)).BeginInit();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.LookAndFeel.SkinName = "Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // dgrex_Hopdong_Laodong
            // 
            this.dgrex_Hopdong_Laodong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrex_Hopdong_Laodong.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.dgrex_Hopdong_Laodong.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.dgrex_Hopdong_Laodong.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.dgrex_Hopdong_Laodong.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.dgrex_Hopdong_Laodong.EmbeddedNavigator.Buttons.First.Visible = false;
            this.dgrex_Hopdong_Laodong.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.dgrex_Hopdong_Laodong.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.dgrex_Hopdong_Laodong.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.dgrex_Hopdong_Laodong.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.dgrex_Hopdong_Laodong.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.dgrex_Hopdong_Laodong.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.dgrex_Hopdong_Laodong.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
            this.dgrex_Hopdong_Laodong.EmbeddedNavigator.TextStringFormat = "{0}/{1}";
            this.dgrex_Hopdong_Laodong.Location = new System.Drawing.Point(0, 65);
            this.dgrex_Hopdong_Laodong.MainView = this.gridView1;
            this.dgrex_Hopdong_Laodong.Name = "dgrex_Hopdong_Laodong";
            this.dgrex_Hopdong_Laodong.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gridLookUpEdit_Nhansu,
            this.gridLookUp_Loai_Hopdong,
            this.gridDate_Ngay_Batdau,
            this.gridLookUp_Nhansu});
            this.dgrex_Hopdong_Laodong.Size = new System.Drawing.Size(959, 297);
            this.dgrex_Hopdong_Laodong.TabIndex = 4;
            this.dgrex_Hopdong_Laodong.UseEmbeddedNavigator = true;
            this.dgrex_Hopdong_Laodong.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn7,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.gridView1.GridControl = this.dgrex_Hopdong_Laodong;
            this.gridView1.GroupPanelText = "[Kéo một cột vào đây để nhóm]";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "STT";
            this.gridColumn1.FieldName = "Id_Hopdong_Laodong";
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
            this.gridColumn2.Caption = "Số hợp đồng";
            this.gridColumn2.FieldName = "Ma_Hopdong_Laodong";
            this.gridColumn2.MinWidth = 135;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 135;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "Mã nhân sự";
            this.gridColumn7.ColumnEdit = this.gridLookUp_Nhansu;
            this.gridColumn7.FieldName = "Id_Nhansu";
            this.gridColumn7.MinWidth = 135;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            this.gridColumn7.Width = 135;
            // 
            // gridLookUp_Nhansu
            // 
            this.gridLookUp_Nhansu.AutoHeight = false;
            this.gridLookUp_Nhansu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUp_Nhansu.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Nhansu", "STT", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Nhansu", "Mã nhân sự")});
            this.gridLookUp_Nhansu.DisplayMember = "Ma_Nhansu";
            this.gridLookUp_Nhansu.Name = "gridLookUp_Nhansu";
            this.gridLookUp_Nhansu.NullText = "";
            this.gridLookUp_Nhansu.ValueMember = "Id_Nhansu";
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Họ tên";
            this.gridColumn3.FieldName = "Hoten";
            this.gridColumn3.MinWidth = 165;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 165;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Loại hợp đồng";
            this.gridColumn4.ColumnEdit = this.gridLookUp_Loai_Hopdong;
            this.gridColumn4.FieldName = "Id_Loai_Hopdong";
            this.gridColumn4.MinWidth = 165;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 165;
            // 
            // gridLookUp_Loai_Hopdong
            // 
            this.gridLookUp_Loai_Hopdong.AutoHeight = false;
            this.gridLookUp_Loai_Hopdong.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.gridLookUp_Loai_Hopdong.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Loai_Hopdong", "Stt", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Loai_Hopdong", 50, "Mã loại hợp đồng"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Loai_Hopdong", 100, "Tên loại hợp đồng")});
            this.gridLookUp_Loai_Hopdong.DisplayMember = "Ten_Loai_Hopdong";
            this.gridLookUp_Loai_Hopdong.Name = "gridLookUp_Loai_Hopdong";
            this.gridLookUp_Loai_Hopdong.NullText = "";
            this.gridLookUp_Loai_Hopdong.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.gridLookUp_Loai_Hopdong.ValueMember = "Id_Loai_Hopdong";
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "Ngày bắt đầu";
            this.gridColumn5.ColumnEdit = this.gridDate_Ngay_Batdau;
            this.gridColumn5.FieldName = "Ngay_Batdau";
            this.gridColumn5.MinWidth = 165;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 165;
            // 
            // gridDate_Ngay_Batdau
            // 
            this.gridDate_Ngay_Batdau.AutoHeight = false;
            this.gridDate_Ngay_Batdau.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridDate_Ngay_Batdau.Name = "gridDate_Ngay_Batdau";
            this.gridDate_Ngay_Batdau.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "Ngày kết thúc";
            this.gridColumn6.ColumnEdit = this.gridDate_Ngay_Batdau;
            this.gridColumn6.FieldName = "Ngay_Ketthuc";
            this.gridColumn6.MinWidth = 165;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 165;
            // 
            // gridLookUpEdit_Nhansu
            // 
            this.gridLookUpEdit_Nhansu.AutoHeight = false;
            this.gridLookUpEdit_Nhansu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEdit_Nhansu.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Nhansu", "Stt"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Nhansu", 100, "Tên nhân sự")});
            this.gridLookUpEdit_Nhansu.DisplayMember = "Ten_Nhansu";
            this.gridLookUpEdit_Nhansu.Name = "gridLookUpEdit_Nhansu";
            this.gridLookUpEdit_Nhansu.NullText = "";
            this.gridLookUpEdit_Nhansu.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.gridLookUpEdit_Nhansu.ValueMember = "Id_Nhansu";
            // 
            // xtraHNavigator1
            // 
            this.xtraHNavigator1.ButtonModes = GoobizFrame.Windows.Controls.XtraHNavigator.NavigatorButtonModes.ShowNavigators;
            this.xtraHNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xtraHNavigator1.GridControl = this.dgrex_Hopdong_Laodong;
            this.xtraHNavigator1.Location = new System.Drawing.Point(0, 362);
            this.xtraHNavigator1.Margin = new System.Windows.Forms.Padding(0);
            this.xtraHNavigator1.Name = "xtraHNavigator1";
            this.xtraHNavigator1.Size = new System.Drawing.Size(959, 22);
            this.xtraHNavigator1.TabIndex = 5;
            this.xtraHNavigator1.TextStringFormat = "{0}/{1}";
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
            // Frmrex_Hopdong_Laodong_ByNhansu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 384);
            this.Controls.Add(this.dgrex_Hopdong_Laodong);
            this.Controls.Add(this.xtraHNavigator1);
            this.Name = "Frmrex_Hopdong_Laodong_ByNhansu";
            this.Text = "Frmrex_Hopdong_Laodong_ByNhansu";
            this.Controls.SetChildIndex(this.xtraHNavigator1, 0);
            this.Controls.SetChildIndex(this.dgrex_Hopdong_Laodong, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrex_Hopdong_Laodong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUp_Nhansu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUp_Loai_Hopdong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDate_Ngay_Batdau.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDate_Ngay_Batdau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Nhansu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgrex_Hopdong_Laodong;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridLookUp_Nhansu;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridLookUp_Loai_Hopdong;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit gridDate_Ngay_Batdau;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridLookUpEdit_Nhansu;
        private GoobizFrame.Windows.Controls.XtraHNavigator xtraHNavigator1;
    }
}