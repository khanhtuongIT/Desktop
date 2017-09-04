
namespace Ecm.Ware.Forms
{
    partial class Frmware_Xuat_Hh_Ban_Dialog
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
            this.lookUpEdit_Kho_View = new DevExpress.XtraEditors.LookUpEdit();
            this.lblId_Cuahang_Ban_Xuat = new DevExpress.XtraEditors.LabelControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnFilter = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Kho_View.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.LookAndFeel.SkinName = "Blue";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // lookUpEdit_Kho_View
            // 
            this.lookUpEdit_Kho_View.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lookUpEdit_Kho_View.Location = new System.Drawing.Point(75, 42);
            this.lookUpEdit_Kho_View.Name = "lookUpEdit_Kho_View";
            this.lookUpEdit_Kho_View.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lookUpEdit_Kho_View.Properties.Appearance.Options.UseFont = true;
            this.lookUpEdit_Kho_View.Properties.AutoSearchColumnIndex = 2;
            this.lookUpEdit_Kho_View.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit_Kho_View.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Cuahang_Ban", "STT", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma_Cuahang_Ban", "Mã kho"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten_Cuahang_Ban", "Tên kho")});
            this.lookUpEdit_Kho_View.Properties.DisplayMember = "Ten_Cuahang_Ban";
            this.lookUpEdit_Kho_View.Properties.NullText = "";
            this.lookUpEdit_Kho_View.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lookUpEdit_Kho_View.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit_Kho_View.Properties.ValueMember = "Id_Cuahang_Ban";
            this.lookUpEdit_Kho_View.Size = new System.Drawing.Size(244, 24);
            this.lookUpEdit_Kho_View.TabIndex = 5;
            // 
            // lblId_Cuahang_Ban_Xuat
            // 
            this.lblId_Cuahang_Ban_Xuat.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblId_Cuahang_Ban_Xuat.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lblId_Cuahang_Ban_Xuat.Location = new System.Drawing.Point(3, 45);
            this.lblId_Cuahang_Ban_Xuat.Name = "lblId_Cuahang_Ban_Xuat";
            this.lblId_Cuahang_Ban_Xuat.Size = new System.Drawing.Size(68, 18);
            this.lblId_Cuahang_Ban_Xuat.TabIndex = 96;
            this.lblId_Cuahang_Ban_Xuat.Text = "Chọn Kho ";
            // 
            // dockManager1
            // 
            this.dockManager1.Controller = this.barAndDockingController1;
            this.dockManager1.Form = this;
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.07246F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.53256F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.btnClose, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.lookUpEdit_Kho_View, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblId_Cuahang_Ban_Xuat, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnFilter, 2, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 65);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(485, 98);
            this.tableLayoutPanel2.TabIndex = 13;
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = System.Drawing.Color.SkyBlue;
            this.btnClose.Appearance.BackColor2 = System.Drawing.Color.SkyBlue;
            this.btnClose.Appearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.Appearance.Options.UseBorderColor = true;
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseTextOptions = true;
            this.btnClose.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.Image = global::Ecm.Ware.Properties.Resources.stop;
            this.btnClose.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnClose.Location = new System.Drawing.Point(407, 23);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 63);
            this.btnClose.TabIndex = 115;
            this.btnClose.Text = "Bỏ";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnFilter.Appearance.Options.UseFont = true;
            this.btnFilter.Image = global::Ecm.Ware.Properties.Resources.arrow_right;
            this.btnFilter.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnFilter.Location = new System.Drawing.Point(325, 23);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(76, 63);
            this.btnFilter.TabIndex = 155;
            this.btnFilter.Text = "OK";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // Frmware_Xuat_Hh_Ban_Dialog
            // 
            this.AllowPrint = true;
            this.AllowRefresh = true;
            this.ClientSize = new System.Drawing.Size(485, 163);
            this.Controls.Add(this.tableLayoutPanel2);
            this.EditMode = GoobizFrame.Windows.Forms.FormUpdateWithToolbar.EditModes.Separate;
            this.EnableAdd = false;
            this.EnableEdit = false;
            this.FormState = GoobizFrame.Windows.Forms.FormState.View;
            this.Name = "Frmware_Xuat_Hh_Ban_Dialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xuất hàng hóa";
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Kho_View.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_Kho_View;
        private DevExpress.XtraEditors.LabelControl lblId_Cuahang_Ban_Xuat;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.SimpleButton btnFilter;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}
