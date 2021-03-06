namespace SunLine.SystemControl.Policy.Forms
{
    partial class Frmpol_Dm_Right_Add
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmpol_Dm_Right_Add));
            this.dgpol_Dm_Right = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblRight_Description = new DevExpress.XtraEditors.LabelControl();
            this.lblRight_System_Name = new DevExpress.XtraEditors.LabelControl();
            this.txtRight_Description = new DevExpress.XtraEditors.TextEdit();
            this.txtRight_System_Name = new DevExpress.XtraEditors.TextEdit();
            this.txtId_Right = new DevExpress.XtraEditors.TextEdit();
            this.lblId_Right = new DevExpress.XtraEditors.LabelControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.btbRight_Properties = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgpol_Dm_Right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRight_Description.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRight_System_Name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId_Right.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.LookAndFeel.SkinName = "Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // dgpol_Dm_Right
            // 
            this.dgpol_Dm_Right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgpol_Dm_Right.EmbeddedNavigator.TextStringFormat = "Dòng {0} / {1}";
            this.dgpol_Dm_Right.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dgpol_Dm_Right_EmbeddedNavigator_ButtonClick);
            this.dgpol_Dm_Right.Location = new System.Drawing.Point(0, 121);
            this.dgpol_Dm_Right.MainView = this.gridView1;
            this.dgpol_Dm_Right.Name = "dgpol_Dm_Right";
            this.dgpol_Dm_Right.Size = new System.Drawing.Size(602, 277);
            this.dgpol_Dm_Right.TabIndex = 0;
            this.dgpol_Dm_Right.UseEmbeddedNavigator = true;
            this.dgpol_Dm_Right.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.dgpol_Dm_Right.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgpol_Dm_Right_MouseClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.GridControl = this.dgpol_Dm_Right;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "STT";
            this.gridColumn1.FieldName = "Id_Right";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Quyền";
            this.gridColumn2.FieldName = "Right_System_Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowMove = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Mô tả";
            this.gridColumn3.FieldName = "Right_Description";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowMove = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblRight_Description);
            this.panelControl1.Controls.Add(this.lblRight_System_Name);
            this.panelControl1.Controls.Add(this.txtRight_Description);
            this.panelControl1.Controls.Add(this.txtRight_System_Name);
            this.panelControl1.Controls.Add(this.txtId_Right);
            this.panelControl1.Controls.Add(this.lblId_Right);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 60);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(602, 61);
            this.panelControl1.TabIndex = 6;
            // 
            // lblRight_Description
            // 
            this.lblRight_Description.Location = new System.Drawing.Point(294, 24);
            this.lblRight_Description.Name = "lblRight_Description";
            this.lblRight_Description.Size = new System.Drawing.Size(27, 13);
            this.lblRight_Description.TabIndex = 5;
            this.lblRight_Description.Text = "Mô tả";
            // 
            // lblRight_System_Name
            // 
            this.lblRight_System_Name.Location = new System.Drawing.Point(107, 24);
            this.lblRight_System_Name.Name = "lblRight_System_Name";
            this.lblRight_System_Name.Size = new System.Drawing.Size(32, 13);
            this.lblRight_System_Name.TabIndex = 4;
            this.lblRight_System_Name.Text = "Quyền";
            // 
            // txtRight_Description
            // 
            this.txtRight_Description.Location = new System.Drawing.Point(328, 20);
            this.txtRight_Description.Name = "txtRight_Description";
            this.txtRight_Description.Size = new System.Drawing.Size(225, 20);
            this.txtRight_Description.TabIndex = 2;
            // 
            // txtRight_System_Name
            // 
            this.txtRight_System_Name.Location = new System.Drawing.Point(145, 20);
            this.txtRight_System_Name.Name = "txtRight_System_Name";
            this.txtRight_System_Name.Size = new System.Drawing.Size(125, 20);
            this.txtRight_System_Name.TabIndex = 1;
            // 
            // txtId_Right
            // 
            this.txtId_Right.Enabled = false;
            this.txtId_Right.Location = new System.Drawing.Point(36, 20);
            this.txtId_Right.Name = "txtId_Right";
            this.txtId_Right.Size = new System.Drawing.Size(50, 20);
            this.txtId_Right.TabIndex = 0;
            // 
            // lblId_Right
            // 
            this.lblId_Right.Location = new System.Drawing.Point(12, 24);
            this.lblId_Right.Name = "lblId_Right";
            this.lblId_Right.Size = new System.Drawing.Size(18, 13);
            this.lblId_Right.TabIndex = 0;
            this.lblId_Right.Text = "STT";
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
            this.btbRight_Properties});
            this.barManager1.MaxItemId = 1;
            this.barManager1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barManager1_ItemClick);
            // 
            // barDockControl1
            // 
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Size = new System.Drawing.Size(602, 0);
            // 
            // barDockControl2
            // 
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 398);
            this.barDockControl2.Size = new System.Drawing.Size(602, 0);
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
            this.barDockControl4.Location = new System.Drawing.Point(602, 0);
            this.barDockControl4.Size = new System.Drawing.Size(0, 398);
            // 
            // btbRight_Properties
            // 
            this.btbRight_Properties.Caption = "Thông tin quyền";
            this.btbRight_Properties.Id = 0;
            this.btbRight_Properties.Name = "btbRight_Properties";
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btbRight_Properties)});
            this.popupMenu1.Manager = this.barManager;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // Frmpol_Dm_Right_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 398);
            this.Controls.Add(this.dgpol_Dm_Right);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frmpol_Dm_Right_Add";
            this.Text = "Frmpol_Dm_Right_Add";
            this.Load += new System.EventHandler(this.Frmpol_Dm_Right_Add_Load);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgpol_Dm_Right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRight_Description.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRight_System_Name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId_Right.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgpol_Dm_Right;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lblRight_Description;
        private DevExpress.XtraEditors.LabelControl lblRight_System_Name;
        private DevExpress.XtraEditors.TextEdit txtRight_Description;
        private DevExpress.XtraEditors.TextEdit txtRight_System_Name;
        private DevExpress.XtraEditors.TextEdit txtId_Right;
        private DevExpress.XtraEditors.LabelControl lblId_Right;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.BarButtonItem btbRight_Properties;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
    }
}