namespace SunLine.SystemControl.Policy.Forms
{
    partial class Frmpol_Dm_Role_Add
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmpol_Dm_Role_Add));
            this.dgpol_Dm_Role = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblRole_Description = new DevExpress.XtraEditors.LabelControl();
            this.lblRole_System_Name = new DevExpress.XtraEditors.LabelControl();
            this.txtRole_Description = new DevExpress.XtraEditors.TextEdit();
            this.txtRole_System_Name = new DevExpress.XtraEditors.TextEdit();
            this.txtId_Role = new DevExpress.XtraEditors.TextEdit();
            this.lblId_Role = new DevExpress.XtraEditors.LabelControl();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btbRole_Properties = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgpol_Dm_Role)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRole_Description.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRole_System_Name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId_Role.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.LookAndFeel.SkinName = "Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // dgpol_Dm_Role
            // 
            this.dgpol_Dm_Role.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgpol_Dm_Role.EmbeddedNavigator.TextStringFormat = "Dòng {0} / {1}";
            this.dgpol_Dm_Role.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dgpol_Dm_Role_EmbeddedNavigator_ButtonClick);
            this.dgpol_Dm_Role.Location = new System.Drawing.Point(0, 121);
            this.dgpol_Dm_Role.MainView = this.gridView1;
            this.dgpol_Dm_Role.Name = "dgpol_Dm_Role";
            this.dgpol_Dm_Role.Size = new System.Drawing.Size(621, 277);
            this.dgpol_Dm_Role.TabIndex = 0;
            this.dgpol_Dm_Role.UseEmbeddedNavigator = true;
            this.dgpol_Dm_Role.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.dgpol_Dm_Role.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgpol_Dm_Role_MouseClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.GridControl = this.dgpol_Dm_Role;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "STT";
            this.gridColumn1.FieldName = "Id_Role";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Nhóm quyền";
            this.gridColumn2.FieldName = "Role_System_Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowMove = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Mô tả";
            this.gridColumn3.FieldName = "Role_Description";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowMove = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblRole_Description);
            this.panelControl1.Controls.Add(this.lblRole_System_Name);
            this.panelControl1.Controls.Add(this.txtRole_Description);
            this.panelControl1.Controls.Add(this.txtRole_System_Name);
            this.panelControl1.Controls.Add(this.txtId_Role);
            this.panelControl1.Controls.Add(this.lblId_Role);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 60);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(621, 61);
            this.panelControl1.TabIndex = 6;
            // 
            // lblRole_Description
            // 
            this.lblRole_Description.Location = new System.Drawing.Point(317, 24);
            this.lblRole_Description.Name = "lblRole_Description";
            this.lblRole_Description.Size = new System.Drawing.Size(27, 13);
            this.lblRole_Description.TabIndex = 5;
            this.lblRole_Description.Text = "Mô tả";
            // 
            // lblRole_System_Name
            // 
            this.lblRole_System_Name.Location = new System.Drawing.Point(109, 24);
            this.lblRole_System_Name.Name = "lblRole_System_Name";
            this.lblRole_System_Name.Size = new System.Drawing.Size(60, 13);
            this.lblRole_System_Name.TabIndex = 4;
            this.lblRole_System_Name.Text = "Nhóm quyền";
            // 
            // txtRole_Description
            // 
            this.txtRole_Description.Location = new System.Drawing.Point(351, 20);
            this.txtRole_Description.Name = "txtRole_Description";
            this.txtRole_Description.Size = new System.Drawing.Size(225, 20);
            this.txtRole_Description.TabIndex = 2;
            // 
            // txtRole_System_Name
            // 
            this.txtRole_System_Name.Location = new System.Drawing.Point(175, 20);
            this.txtRole_System_Name.Name = "txtRole_System_Name";
            this.txtRole_System_Name.Size = new System.Drawing.Size(125, 20);
            this.txtRole_System_Name.TabIndex = 1;
            // 
            // txtId_Role
            // 
            this.txtId_Role.Enabled = false;
            this.txtId_Role.Location = new System.Drawing.Point(37, 20);
            this.txtId_Role.Name = "txtId_Role";
            this.txtId_Role.Size = new System.Drawing.Size(50, 20);
            this.txtId_Role.TabIndex = 0;
            // 
            // lblId_Role
            // 
            this.lblId_Role.Location = new System.Drawing.Point(12, 24);
            this.lblId_Role.Name = "lblId_Role";
            this.lblId_Role.Size = new System.Drawing.Size(18, 13);
            this.lblId_Role.TabIndex = 0;
            this.lblId_Role.Text = "STT";
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btbRole_Properties)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // btbRole_Properties
            // 
            this.btbRole_Properties.Caption = "Thông tin nhóm quyền";
            this.btbRole_Properties.Id = 1;
            this.btbRole_Properties.Name = "btbRole_Properties";
            // 
            // barManager1
            // 
            this.barManager1.Controller = this.barAndDockingController1;
            this.barManager1.DockControls.Add(this.barDockControl1);
            this.barManager1.DockControls.Add(this.barDockControl2);
            this.barManager1.DockControls.Add(this.barDockControl3);
            this.barManager1.DockControls.Add(this.barDockControl4);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btbRole_Properties});
            this.barManager1.MaxItemId = 2;
            this.barManager1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barManager1_ItemClick);
            // 
            // barDockControl1
            // 
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Size = new System.Drawing.Size(621, 0);
            // 
            // barDockControl2
            // 
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 398);
            this.barDockControl2.Size = new System.Drawing.Size(621, 0);
            // 
            // barDockControl3
            // 
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 0);
            this.barDockControl3.Size = new System.Drawing.Size(0, 398);
            // 
            // barDockControl4
            // 
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(621, 0);
            this.barDockControl4.Size = new System.Drawing.Size(0, 398);
            // 
            // Frmpol_Dm_Role_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 398);
            this.Controls.Add(this.dgpol_Dm_Role);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frmpol_Dm_Role_Add";
            this.Text = "Frmpol_Dm_Role_Add";
            this.Load += new System.EventHandler(this.Frmpol_Dm_Role_Add_Load);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgpol_Dm_Role)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRole_Description.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRole_System_Name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId_Role.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgpol_Dm_Role;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lblRole_Description;
        private DevExpress.XtraEditors.LabelControl lblRole_System_Name;
        private DevExpress.XtraEditors.TextEdit txtRole_Description;
        private DevExpress.XtraEditors.TextEdit txtRole_System_Name;
        private DevExpress.XtraEditors.TextEdit txtId_Role;
        private DevExpress.XtraEditors.LabelControl lblId_Role;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.BarButtonItem btbRole_Properties;
    }
}