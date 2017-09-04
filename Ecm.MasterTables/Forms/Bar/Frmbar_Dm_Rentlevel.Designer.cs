namespace Ecm.MasterTables.Forms.Bar
{
    partial class Frmbar_Dm_Rentlevel
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
            this.dgbar_Dm_Rentlevel = new DevExpress.XtraGrid.GridControl();
            this.gvbar_Dm_Rentlevel = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cardView1 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn34 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn36 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraHNavigator4 = new GoobizFrame.Windows.Controls.XtraHNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgbar_Dm_Rentlevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvbar_Dm_Rentlevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).BeginInit();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // dgbar_Dm_Rentlevel
            // 
            this.dgbar_Dm_Rentlevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgbar_Dm_Rentlevel.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.dgbar_Dm_Rentlevel.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.dgbar_Dm_Rentlevel.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.dgbar_Dm_Rentlevel.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.dgbar_Dm_Rentlevel.EmbeddedNavigator.Buttons.First.Visible = false;
            this.dgbar_Dm_Rentlevel.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.dgbar_Dm_Rentlevel.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.dgbar_Dm_Rentlevel.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.dgbar_Dm_Rentlevel.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.dgbar_Dm_Rentlevel.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.dgbar_Dm_Rentlevel.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.dgbar_Dm_Rentlevel.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
            this.dgbar_Dm_Rentlevel.EmbeddedNavigator.TextStringFormat = "Dòng: {0} / {1}";
            this.dgbar_Dm_Rentlevel.Location = new System.Drawing.Point(0, 65);
            this.dgbar_Dm_Rentlevel.MainView = this.gvbar_Dm_Rentlevel;
            this.dgbar_Dm_Rentlevel.Name = "dgbar_Dm_Rentlevel";
            this.dgbar_Dm_Rentlevel.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1});
            this.dgbar_Dm_Rentlevel.Size = new System.Drawing.Size(1131, 338);
            this.dgbar_Dm_Rentlevel.TabIndex = 14;
            this.dgbar_Dm_Rentlevel.UseEmbeddedNavigator = true;
            this.dgbar_Dm_Rentlevel.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvbar_Dm_Rentlevel,
            this.cardView1});
            // 
            // gvbar_Dm_Rentlevel
            // 
            this.gvbar_Dm_Rentlevel.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn4,
            this.gridColumn5});
            this.gvbar_Dm_Rentlevel.GridControl = this.dgbar_Dm_Rentlevel;
            this.gvbar_Dm_Rentlevel.GroupPanelText = "[Kéo một cột vào đây để nhóm]";
            this.gvbar_Dm_Rentlevel.Name = "gvbar_Dm_Rentlevel";
            this.gvbar_Dm_Rentlevel.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id_Facility";
            this.gridColumn1.FieldName = "Id_Rentlevel";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Mã";
            this.gridColumn2.ColumnEdit = this.repositoryItemComboBox1;
            this.gridColumn2.FieldName = "Ma_Rentlevel";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "Day",
            "Hour",
            "Month",
            "Year"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Tên";
            this.gridColumn4.FieldName = "Ten_Rentlevel";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Mô tả";
            this.gridColumn5.FieldName = "Ghichu";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            // 
            // cardView1
            // 
            this.cardView1.CardWidth = 150;
            this.cardView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn31,
            this.gridColumn32,
            this.gridColumn33,
            this.gridColumn34,
            this.gridColumn35,
            this.gridColumn36,
            this.gridColumn37});
            this.cardView1.FocusedCardTopFieldIndex = 0;
            this.cardView1.GridControl = this.dgbar_Dm_Rentlevel;
            this.cardView1.Name = "cardView1";
            this.cardView1.OptionsBehavior.Editable = false;
            this.cardView1.OptionsBehavior.ReadOnly = true;
            this.cardView1.OptionsView.ShowCardCaption = false;
            this.cardView1.OptionsView.ShowFieldCaptions = false;
            this.cardView1.OptionsView.ShowQuickCustomizeButton = false;
            // 
            // gridColumn31
            // 
            this.gridColumn31.Caption = "Id_Table";
            this.gridColumn31.FieldName = "Id_Table";
            this.gridColumn31.Name = "gridColumn31";
            // 
            // gridColumn32
            // 
            this.gridColumn32.Caption = "Ma_Table";
            this.gridColumn32.FieldName = "Ma_Table";
            this.gridColumn32.Name = "gridColumn32";
            this.gridColumn32.Visible = true;
            this.gridColumn32.VisibleIndex = 0;
            // 
            // gridColumn33
            // 
            this.gridColumn33.Caption = "Ten_Table";
            this.gridColumn33.FieldName = "Ten_Table";
            this.gridColumn33.Name = "gridColumn33";
            this.gridColumn33.Visible = true;
            this.gridColumn33.VisibleIndex = 1;
            // 
            // gridColumn34
            // 
            this.gridColumn34.Caption = "Vitri";
            this.gridColumn34.FieldName = "Vitri";
            this.gridColumn34.Name = "gridColumn34";
            this.gridColumn34.Visible = true;
            this.gridColumn34.VisibleIndex = 2;
            // 
            // gridColumn35
            // 
            this.gridColumn35.Caption = "Ghichu";
            this.gridColumn35.FieldName = "Ghichu";
            this.gridColumn35.Name = "gridColumn35";
            this.gridColumn35.Visible = true;
            this.gridColumn35.VisibleIndex = 3;
            // 
            // gridColumn36
            // 
            this.gridColumn36.Caption = "Soluong";
            this.gridColumn36.FieldName = "Soluong";
            this.gridColumn36.Name = "gridColumn36";
            this.gridColumn36.Visible = true;
            this.gridColumn36.VisibleIndex = 4;
            // 
            // gridColumn37
            // 
            this.gridColumn37.Caption = "Id_Khuvuc";
            this.gridColumn37.FieldName = "Id_Khuvuc";
            this.gridColumn37.Name = "gridColumn37";
            // 
            // xtraHNavigator4
            // 
            this.xtraHNavigator4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xtraHNavigator4.GridControl = this.dgbar_Dm_Rentlevel;
            this.xtraHNavigator4.Location = new System.Drawing.Point(0, 403);
            this.xtraHNavigator4.Margin = new System.Windows.Forms.Padding(0);
            this.xtraHNavigator4.Name = "xtraHNavigator4";
            this.xtraHNavigator4.Size = new System.Drawing.Size(1131, 24);
            this.xtraHNavigator4.TabIndex = 13;
            this.xtraHNavigator4.TextStringFormat = "Dòng: {0} / {1}";
            this.xtraHNavigator4.VisibleFirst = true;
            this.xtraHNavigator4.VisibleLast = true;
            this.xtraHNavigator4.VisibleNext = true;
            this.xtraHNavigator4.VisiblePageNext = true;
            this.xtraHNavigator4.VisiblePagePrev = true;
            this.xtraHNavigator4.VisiblePrev = true;
            // 
            // Frmbar_Dm_Rentlevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 427);
            this.Controls.Add(this.dgbar_Dm_Rentlevel);
            this.Controls.Add(this.xtraHNavigator4);
            this.EditMode = GoobizFrame.Windows.Forms.FormUpdateWithToolbar.EditModes.Separate;
            this.FormState = GoobizFrame.Windows.Forms.FormState.View;
            this.Name = "Frmbar_Dm_Rentlevel";
            this.Text = "Frmbar_Dm_Rentlevel";
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgbar_Dm_Rentlevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvbar_Dm_Rentlevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgbar_Dm_Rentlevel;
        private DevExpress.XtraGrid.Views.Grid.GridView gvbar_Dm_Rentlevel;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Views.Card.CardView cardView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn32;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn34;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn36;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn37;
        private GoobizFrame.Windows.Controls.XtraHNavigator xtraHNavigator4;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
    }
}