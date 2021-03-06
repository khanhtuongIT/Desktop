namespace SunLine.SystemControl.Policy.Forms
{
    partial class Frmpol_Dm_Action_Add
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmpol_Dm_Action_Add));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblAction_Description = new DevExpress.XtraEditors.LabelControl();
            this.lblAction_Name = new DevExpress.XtraEditors.LabelControl();
            this.txtAction_Description = new DevExpress.XtraEditors.TextEdit();
            this.txtAction_Name = new DevExpress.XtraEditors.TextEdit();
            this.txtId_Action = new DevExpress.XtraEditors.TextEdit();
            this.lblId_Action = new DevExpress.XtraEditors.LabelControl();
            this.dgpol_Dm_Action = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAction_Description.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAction_Name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId_Action.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgpol_Dm_Action)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.LookAndFeel.SkinName = "Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblAction_Description);
            this.panelControl1.Controls.Add(this.lblAction_Name);
            this.panelControl1.Controls.Add(this.txtAction_Description);
            this.panelControl1.Controls.Add(this.txtAction_Name);
            this.panelControl1.Controls.Add(this.txtId_Action);
            this.panelControl1.Controls.Add(this.lblId_Action);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(596, 61);
            this.toolTipController1.SetSuperTip(this.panelControl1, null);
            this.panelControl1.TabIndex = 4;
            // 
            // lblAction_Description
            // 
            this.lblAction_Description.Location = new System.Drawing.Point(300, 24);
            this.lblAction_Description.Name = "lblAction_Description";
            this.lblAction_Description.Size = new System.Drawing.Size(27, 13);
            this.lblAction_Description.TabIndex = 5;
            this.lblAction_Description.Text = "Mô tả";
            // 
            // lblAction_Name
            // 
            this.lblAction_Name.Location = new System.Drawing.Point(104, 24);
            this.lblAction_Name.Name = "lblAction_Name";
            this.lblAction_Name.Size = new System.Drawing.Size(42, 13);
            this.lblAction_Name.TabIndex = 4;
            this.lblAction_Name.Text = "Thao tác";
            // 
            // txtAction_Description
            // 
            this.txtAction_Description.Location = new System.Drawing.Point(334, 20);
            this.txtAction_Description.Name = "txtAction_Description";
            this.txtAction_Description.Size = new System.Drawing.Size(225, 20);
            this.txtAction_Description.TabIndex = 2;
            // 
            // txtAction_Name
            // 
            this.txtAction_Name.Location = new System.Drawing.Point(152, 20);
            this.txtAction_Name.Name = "txtAction_Name";
            this.txtAction_Name.Size = new System.Drawing.Size(125, 20);
            this.txtAction_Name.TabIndex = 1;
            // 
            // txtId_Action
            // 
            this.txtId_Action.Enabled = false;
            this.txtId_Action.Location = new System.Drawing.Point(36, 20);
            this.txtId_Action.Name = "txtId_Action";
            this.txtId_Action.Size = new System.Drawing.Size(50, 20);
            this.txtId_Action.TabIndex = 0;
            // 
            // lblId_Action
            // 
            this.lblId_Action.Location = new System.Drawing.Point(12, 24);
            this.lblId_Action.Name = "lblId_Action";
            this.lblId_Action.Size = new System.Drawing.Size(18, 13);
            this.lblId_Action.TabIndex = 0;
            this.lblId_Action.Text = "STT";
            // 
            // dgpol_Dm_Action
            // 
            this.dgpol_Dm_Action.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgpol_Dm_Action.EmbeddedNavigator.Name = "";
            this.dgpol_Dm_Action.EmbeddedNavigator.TextStringFormat = "Dòng {0} / {1}";
            this.dgpol_Dm_Action.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dgpol_Dm_Action_EmbeddedNavigator_ButtonClick);
            this.dgpol_Dm_Action.Location = new System.Drawing.Point(0, 85);
            this.dgpol_Dm_Action.MainView = this.gridView1;
            this.dgpol_Dm_Action.Name = "dgpol_Dm_Action";
            this.dgpol_Dm_Action.Size = new System.Drawing.Size(596, 313);
            this.dgpol_Dm_Action.TabIndex = 0;
            this.dgpol_Dm_Action.UseEmbeddedNavigator = true;
            this.dgpol_Dm_Action.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.GridControl = this.dgpol_Dm_Action;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "STT";
            this.gridColumn1.FieldName = "Id_Action";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Thao tác";
            this.gridColumn2.FieldName = "Action_Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowMove = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Mô tả";
            this.gridColumn3.FieldName = "Action_Description";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowMove = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // Frmpol_Dm_Action_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 398);
            this.Controls.Add(this.dgpol_Dm_Action);
            this.Controls.Add(this.panelControl1);
            this.Name = "Frmpol_Dm_Action_Add";
            this.toolTipController1.SetSuperTip(this, null);
            this.Text = "Frmpol_Dm_Action_Add";
            this.Load += new System.EventHandler(this.Frmpol_Dm_Action_Add_Load);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.dgpol_Dm_Action, 0);
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAction_Description.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAction_Name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId_Action.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgpol_Dm_Action)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lblId_Action;
        private DevExpress.XtraEditors.LabelControl lblAction_Description;
        private DevExpress.XtraEditors.LabelControl lblAction_Name;
        private DevExpress.XtraEditors.TextEdit txtAction_Description;
        private DevExpress.XtraEditors.TextEdit txtAction_Name;
        private DevExpress.XtraEditors.TextEdit txtId_Action;
        private DevExpress.XtraGrid.GridControl dgpol_Dm_Action;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
    }
}