namespace Ecm.Bar.Forms
{
    partial class Frmbar_Kitchen_Printer
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
            this.xtraHNavigator1 = new GoobizFrame.Windows.Controls.XtraHNavigator();
            this.dgBar_Kitchen_Printer = new DevExpress.XtraGrid.GridControl();
            this.gvBar_Kitchen_Printer = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridComboBox_Printer = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookUpEdit_Nhom_Hanghoa_Ban = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblId_Cuahang_Ban = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEdit_Cuahang_Ban = new DevExpress.XtraEditors.LookUpEdit();
            this.lblPc_Code = new DevExpress.XtraEditors.LabelControl();
            this.lblPc_Name = new DevExpress.XtraEditors.LabelControl();
            this.txtPc_Code = new DevExpress.XtraEditors.TextEdit();
            this.txtPc_Name = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBar_Kitchen_Printer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBar_Kitchen_Printer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridComboBox_Printer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Nhom_Hanghoa_Ban)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Cuahang_Ban.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPc_Code.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPc_Name.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // xtraHNavigator1
            // 
            this.xtraHNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xtraHNavigator1.GridControl = this.dgBar_Kitchen_Printer;
            this.xtraHNavigator1.Location = new System.Drawing.Point(0, 401);
            this.xtraHNavigator1.Margin = new System.Windows.Forms.Padding(0);
            this.xtraHNavigator1.Name = "xtraHNavigator1";
            this.xtraHNavigator1.Size = new System.Drawing.Size(1043, 22);
            this.xtraHNavigator1.TabIndex = 0;
            this.xtraHNavigator1.TextStringFormat = "Dòng {0}/{1}";
            this.xtraHNavigator1.VisibleFirst = true;
            this.xtraHNavigator1.VisibleLast = true;
            this.xtraHNavigator1.VisibleNext = true;
            this.xtraHNavigator1.VisiblePageNext = true;
            this.xtraHNavigator1.VisiblePagePrev = true;
            this.xtraHNavigator1.VisiblePrev = true;
            // 
            // dgBar_Kitchen_Printer
            // 
            this.dgBar_Kitchen_Printer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgBar_Kitchen_Printer.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.dgBar_Kitchen_Printer.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.dgBar_Kitchen_Printer.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.dgBar_Kitchen_Printer.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.dgBar_Kitchen_Printer.EmbeddedNavigator.Buttons.First.Visible = false;
            this.dgBar_Kitchen_Printer.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.dgBar_Kitchen_Printer.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.dgBar_Kitchen_Printer.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.dgBar_Kitchen_Printer.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.dgBar_Kitchen_Printer.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.dgBar_Kitchen_Printer.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.dgBar_Kitchen_Printer.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
            this.dgBar_Kitchen_Printer.EmbeddedNavigator.TextStringFormat = "Dòng {0}/{1}";
            this.dgBar_Kitchen_Printer.Location = new System.Drawing.Point(0, 97);
            this.dgBar_Kitchen_Printer.MainView = this.gvBar_Kitchen_Printer;
            this.dgBar_Kitchen_Printer.Name = "dgBar_Kitchen_Printer";
            this.dgBar_Kitchen_Printer.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gridLookUpEdit_Nhom_Hanghoa_Ban,
            this.gridComboBox_Printer});
            this.dgBar_Kitchen_Printer.Size = new System.Drawing.Size(1043, 304);
            this.dgBar_Kitchen_Printer.TabIndex = 1;
            this.dgBar_Kitchen_Printer.UseEmbeddedNavigator = true;
            this.dgBar_Kitchen_Printer.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvBar_Kitchen_Printer,
            this.gridView2});
            // 
            // gvBar_Kitchen_Printer
            // 
            this.gvBar_Kitchen_Printer.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.gvBar_Kitchen_Printer.GridControl = this.dgBar_Kitchen_Printer;
            this.gvBar_Kitchen_Printer.Name = "gvBar_Kitchen_Printer";
            this.gvBar_Kitchen_Printer.OptionsView.ColumnAutoWidth = false;
            this.gvBar_Kitchen_Printer.OptionsView.ShowGroupPanel = false;
            this.gvBar_Kitchen_Printer.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gvBar_Kitchen_Printer_InitNewRow);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id_Kitchen_Printer";
            this.gridColumn1.FieldName = "Id_Kitchen_Printer";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Pc_Code";
            this.gridColumn2.FieldName = "Pc_Code";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Pc_Name";
            this.gridColumn3.FieldName = "Pc_Name";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Khu vực";
            this.gridColumn4.FieldName = "Id_Cuahang_Ban";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Tên máy in bếp";
            this.gridColumn5.ColumnEdit = this.gridComboBox_Printer;
            this.gridColumn5.FieldName = "Printer";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 85;
            // 
            // gridComboBox_Printer
            // 
            this.gridComboBox_Printer.AutoHeight = false;
            this.gridComboBox_Printer.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridComboBox_Printer.Name = "gridComboBox_Printer";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Nhóm hàng hóa";
            this.gridColumn6.ColumnEdit = this.gridLookUpEdit_Nhom_Hanghoa_Ban;
            this.gridColumn6.FieldName = "Id_Nhom_Hanghoa_Ban";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 87;
            // 
            // gridLookUpEdit_Nhom_Hanghoa_Ban
            // 
            this.gridLookUpEdit_Nhom_Hanghoa_Ban.AutoHeight = false;
            this.gridLookUpEdit_Nhom_Hanghoa_Ban.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEdit_Nhom_Hanghoa_Ban.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Nhom_Hanghoa_Ban", "STT"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Nhom_Hanghoa_Ban", "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Nhom_Hanghoa_Ban", "Tên")});
            this.gridLookUpEdit_Nhom_Hanghoa_Ban.DisplayMember = "Ten_Nhom_Hanghoa_Ban";
            this.gridLookUpEdit_Nhom_Hanghoa_Ban.Name = "gridLookUpEdit_Nhom_Hanghoa_Ban";
            this.gridLookUpEdit_Nhom_Hanghoa_Ban.NullText = "";
            this.gridLookUpEdit_Nhom_Hanghoa_Ban.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.gridLookUpEdit_Nhom_Hanghoa_Ban.ValueMember = "Id_Nhom_Hanghoa_Ban";
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.dgBar_Kitchen_Printer;
            this.gridView2.Name = "gridView2";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.lblId_Cuahang_Ban, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lookUpEdit_Cuahang_Ban, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblPc_Code, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblPc_Name, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPc_Code, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPc_Name, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 65);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1043, 32);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lblId_Cuahang_Ban
            // 
            this.lblId_Cuahang_Ban.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblId_Cuahang_Ban.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblId_Cuahang_Ban.Location = new System.Drawing.Point(698, 6);
            this.lblId_Cuahang_Ban.Name = "lblId_Cuahang_Ban";
            this.lblId_Cuahang_Ban.Size = new System.Drawing.Size(57, 19);
            this.lblId_Cuahang_Ban.TabIndex = 98;
            this.lblId_Cuahang_Ban.Text = "Khu vực";
            // 
            // lookUpEdit_Cuahang_Ban
            // 
            this.lookUpEdit_Cuahang_Ban.Dock = System.Windows.Forms.DockStyle.Top;
            this.lookUpEdit_Cuahang_Ban.Location = new System.Drawing.Point(761, 3);
            this.lookUpEdit_Cuahang_Ban.Name = "lookUpEdit_Cuahang_Ban";
            this.lookUpEdit_Cuahang_Ban.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lookUpEdit_Cuahang_Ban.Properties.Appearance.Options.UseFont = true;
            this.lookUpEdit_Cuahang_Ban.Properties.AutoSearchColumnIndex = 2;
            this.lookUpEdit_Cuahang_Ban.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit_Cuahang_Ban.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Cuahang_Ban", "STT", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Cuahang_Ban", "Mã kho"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Cuahang_Ban", "Tên kho")});
            this.lookUpEdit_Cuahang_Ban.Properties.DisplayMember = "Ten_Cuahang_Ban";
            this.lookUpEdit_Cuahang_Ban.Properties.NullText = "";
            this.lookUpEdit_Cuahang_Ban.Properties.ReadOnly = true;
            this.lookUpEdit_Cuahang_Ban.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lookUpEdit_Cuahang_Ban.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit_Cuahang_Ban.Properties.ValueMember = "Id_Cuahang_Ban";
            this.lookUpEdit_Cuahang_Ban.Size = new System.Drawing.Size(279, 26);
            this.lookUpEdit_Cuahang_Ban.TabIndex = 97;
            // 
            // lblPc_Code
            // 
            this.lblPc_Code.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPc_Code.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblPc_Code.Location = new System.Drawing.Point(3, 6);
            this.lblPc_Code.Name = "lblPc_Code";
            this.lblPc_Code.Size = new System.Drawing.Size(55, 19);
            this.lblPc_Code.TabIndex = 98;
            this.lblPc_Code.Text = "Mã máy";
            // 
            // lblPc_Name
            // 
            this.lblPc_Name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPc_Name.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblPc_Name.Location = new System.Drawing.Point(347, 6);
            this.lblPc_Name.Name = "lblPc_Name";
            this.lblPc_Name.Size = new System.Drawing.Size(62, 19);
            this.lblPc_Name.TabIndex = 98;
            this.lblPc_Name.Text = "Tên máy";
            // 
            // txtPc_Code
            // 
            this.txtPc_Code.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtPc_Code.Location = new System.Drawing.Point(64, 3);
            this.txtPc_Code.Name = "txtPc_Code";
            this.txtPc_Code.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPc_Code.Properties.Appearance.Options.UseFont = true;
            this.txtPc_Code.Properties.ReadOnly = true;
            this.txtPc_Code.Size = new System.Drawing.Size(277, 26);
            this.txtPc_Code.TabIndex = 99;
            // 
            // txtPc_Name
            // 
            this.txtPc_Name.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtPc_Name.Location = new System.Drawing.Point(415, 3);
            this.txtPc_Name.Name = "txtPc_Name";
            this.txtPc_Name.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPc_Name.Properties.Appearance.Options.UseFont = true;
            this.txtPc_Name.Properties.ReadOnly = true;
            this.txtPc_Name.Size = new System.Drawing.Size(277, 26);
            this.txtPc_Name.TabIndex = 99;
            // 
            // Frmbar_Kitchen_Printer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 423);
            this.Controls.Add(this.dgBar_Kitchen_Printer);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.xtraHNavigator1);
            this.Name = "Frmbar_Kitchen_Printer";
            this.Text = "Thiết lập in bếp";
            this.Controls.SetChildIndex(this.xtraHNavigator1, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.dgBar_Kitchen_Printer, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBar_Kitchen_Printer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBar_Kitchen_Printer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridComboBox_Printer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Nhom_Hanghoa_Ban)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Cuahang_Ban.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPc_Code.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPc_Name.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private  GoobizFrame.Windows.Controls.XtraHNavigator xtraHNavigator1;
        private DevExpress.XtraGrid.GridControl dgBar_Kitchen_Printer;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBar_Kitchen_Printer;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridLookUpEdit_Nhom_Hanghoa_Ban;
        private DevExpress.XtraEditors.LabelControl lblId_Cuahang_Ban;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_Cuahang_Ban;
        private DevExpress.XtraEditors.LabelControl lblPc_Code;
        private DevExpress.XtraEditors.LabelControl lblPc_Name;
        private DevExpress.XtraEditors.TextEdit txtPc_Code;
        private DevExpress.XtraEditors.TextEdit txtPc_Name;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox gridComboBox_Printer;
    }
}