using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;
using System.IO;

namespace Ecm.Bar.Forms.Rent
{
    public partial class Frmbar_Rent_Checkin_Order : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        Ecm.WebReferences.Classes.BarService objBarService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.BarService>();
        Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();

        DataSet dsTable_Order = new DataSet();
        DataSet dsRent_Checkin_Table_Hanghoa = new DataSet();
        //DataSet dsRent_Checkin_Table_Hanghoa_Log = new DataSet(); //log data same: bar_kitchen_order_chitiet
        DataSet dsMenu_Hanghoa_Ban;
        DataSet dsNhom_Hanghoa_Ban;
        DataSet dsCtrinh_Kmai_Rent_Chitiet;
        DataSet ds_Hanghoa_Ban = null;
        DataSet dsNhansu_Order;
        DataSet ds_Khachhang;
        DataSet dsBar_Dm_Menu;
        DataSet dsKhachhang_KM;
        DataSet ds_Menu_Hanghoa_Monitor = new DataSet();
        DataSet ds_Ware_Dm_Donvitinh;
        DataSet ds_hanghoa_afterThongke = new DataSet();
        int index_CardMenu = 0; // nếu index_CardMenu = 0 --> ko load lại Menu

        bool checkButton = false;
        bool AllowEdit_Per_Dongia = false;
        bool print_bill = false;
        decimal vip_per_dongia = 0;
        int Id_Nhansu_Km = -1;
        System.Collections.Hashtable Images = new System.Collections.Hashtable();
        public DataRow[] drs_Hanghoa;
        object Id_Cuahang_Ban;
        object Id_Nhom_Hanghoa_Ban;
        object Current_Id_Khuvuc = null;
        object id_bar_rent_checkin_table;
        object current_id_nhansu;
        //string LogTime = "init";

        public object Id_Bar_Rent_Checkin_Table
        {
            get { return id_bar_rent_checkin_table; }
            set { this.id_bar_rent_checkin_table = value; }
        }

        DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2;

        #region local data
        DataSet dsSys_Lognotify = null;

        //datetime last change
        DateTime dtlc_bar_table_order_chitiet;
        DateTime dtlc_bar_table_order_chitiet_temp = DateTime.Now;

        #endregion

        public Frmbar_Rent_Checkin_Order()
        {
            InitializeComponent();
            //item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            BarSystem.Visible = false;

            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");

            LoadMasterTable();
            DisplayInfo();
        }

        public Frmbar_Rent_Checkin_Order(object Id_Checkin_Table, object Id_Khuvuc)
        {
            id_bar_rent_checkin_table = Id_Checkin_Table;
            Current_Id_Khuvuc = Id_Khuvuc;
            InitializeComponent();
            BarSystem.Visible = false;
            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");
            LoadMasterTable();
            DisplayInfo();
        }

        void ShowTabPage(DevExpress.XtraTab.XtraTabPage xtraTabPage)
        {
            try
            {
                if (xtraTabControl_Leftside.SelectedTabPage == xtraTabPage) return;
                while (xtraTabControl_Leftside.TabPages.Count > 0)
                    xtraTabControl_Leftside.TabPages.RemoveAt(0);
                xtraTabControl_Leftside.TabPages.Add(xtraTabPage);
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        #region Event Override

        public object InsertObject()
        {
            this.DoClickEndEdit(dgbar_Table_Order); //dgbar_Table_Order.EmbeddedNavigator.Buttons.EndEdit.DoClick();
            foreach (DataRow dr in dsRent_Checkin_Table_Hanghoa.Tables[0].Rows)
            {
                if (dr.RowState == DataRowState.Deleted) continue;
                //dr["Id_Bar_Rent_Checkin_Table"] = DateTime.Now.Ticks;
                dr["Id_Bar_Rent_Checkin_Table"] = id_bar_rent_checkin_table;
                dr["Ngay_Order"] = Convert.ToDateTime(objBarService.GetServerDateTime());
                dr["Guid_Octiet"] = Guid.NewGuid();
            }
            objBarService.Update_Bar_Rent_Checkin_table_Hanghoa_Collection(dsRent_Checkin_Table_Hanghoa);
            //objBarService.WriteLogNotification(string.Format("{0}-{1}-{2}-{3}\r\n", new object[] { DateTime.Now, identity, bar_Table_Order.Id_Nhansu_Order, "Ins" }));         
            return true;
        }

        public object UpdateObject()
        {
            //update donmuahang_chitiet
            this.DoClickEndEdit(dgbar_Table_Order); //  dgbar_Table_Order.EmbeddedNavigator.Buttons.EndEdit.DoClick();
            gvbar_Table_Order.EndInit();
            foreach (DataRow dr in dsRent_Checkin_Table_Hanghoa.Tables[0].Rows)
            {
                if (dr.RowState == DataRowState.Added)
                {
                    dr["Ngay_Order"] = Convert.ToDateTime(objBarService.GetServerDateTime());
                    dr["Guid_Octiet"] = Guid.NewGuid();
                }
            }
            objBarService.Update_Bar_Rent_Checkin_table_Hanghoa_Collection(dsRent_Checkin_Table_Hanghoa);
            return true;
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.BarService.Bar_Table_Order bar_Table_Order = new Ecm.WebReferences.BarService.Bar_Table_Order();
            return objBarService.Delete_Bar_Table_Order(bar_Table_Order);
        }

        public override bool PerformAdd()
        {
            btnSave.Text = "Gửi Order";
            ClearDataBindings();
            this.ChangeStatus(true);
            this.ResetText();
            ShowMenuToOrder();
            AllowEdit_Per_Dongia = false;
            ChangeFormState(GoobizFrame.Windows.Forms.FormState.Add);
            return true;
        }

        public override bool PerformEdit()
        {
            btnSave.Text = "Lưu Order";
            //if (!current_id_nhansu.Equals("" + lookUp_Nhansu_Order.EditValue))
            //{
            //    //this.ChangeStatus(false);
            //    btnSave.Enabled = false;
            //    btnDelete.Enabled = false;
            //    btnKhachhang.Enabled = false;
            //    lblWarning.Text = "Bạn không thể điều chỉnh bàn này";
            //    return false;
            //}
            FormState = GoobizFrame.Windows.Forms.FormState.Edit;
            this.ChangeStatus(true);
            AllowEdit_Per_Dongia = false;
            ShowMenuToOrder();
            return true;
        }

        public override bool PerformCancel()
        {
            dsTable_Order.RejectChanges();
            dsRent_Checkin_Table_Hanghoa.RejectChanges();
            this.DisplayInfo();
            this.ChangeStatus(false);
            this.FormState = GoobizFrame.Windows.Forms.FormState.View;
            return true;
        }

        public override bool PerformSave()
        {
            try
            {
                bool success = false;
                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                    success = (bool)this.InsertObject();

                else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                    success = (bool)this.UpdateObject();

                if (success)
                {
                    this.DisplayInfo();
                    this.FormState = GoobizFrame.Windows.Forms.FormState.View;
                }
                return success;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                return false;
            }
        }

        public override bool PerformDelete()
        {
            try
            {
                //ko the xoa ban da served 
                if (dsRent_Checkin_Table_Hanghoa.Tables[0].Select("Served = true").Length > 0
                    || dsRent_Checkin_Table_Hanghoa.Tables[0].Select("Soluong_Phucvu > 0").Length > 0)
                {
                    //GoobizFrame.Windows.Forms.UserMessage.Show("ORDER_SERVED", new string[] { });
                    lblWarning.Text = "Bàn đã có món pha chế xong nên không thể hủy";
                    return false;
                }
            }
            catch (Exception ex) { GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString()); }

            lblWarning.Text = "Liên hệ với quản lý để hủy bàn";
            GoobizFrame.Windows.Forms.Policy.Authorization.Actions Actions = GoobizFrame.Windows.MdiUtils.MdiChecker.ShowIDCardLogonWithResult(this);
            if (Actions.Count == 0 || !Actions.Contains("EnableUnlock"))
            {
                lblWarning.Text = "Tài khoản không hợp lệ";
                return false;
            }
            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
            GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Bar_Table_Order"),
            GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Bar_Table_Order")   }) == DialogResult.Yes)
            {
                try
                {
                    this.DeleteObject();
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                    GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                }
                this.DisplayInfo();
                return base.PerformDelete();
            }
            else
                return false;
        }

        public override bool PerformPrintPreview()
        {
            //this.dsRent_Checkin_Table_Hanghoa = objBarService.Get_All_Bar_Table_Order_Chitiet_ById_Order(SelectedId_Table_Order).ToDataSet();
            Ecm.Bar.DataSets.dsHdbanhang_Chitiet dsrHdbanhang_Chitiet = new Ecm.Bar.DataSets.dsHdbanhang_Chitiet();
            Ecm.Bar.Reports.rptHdbanhang_noVAT rptHdbanhang_noVAT = new Ecm.Bar.Reports.rptHdbanhang_noVAT();
            //GoobizFrame.Windows.Forms.FormReport frmPrintPreview = new GoobizFrame.Windows.Forms.FormReport();
            GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            frmPrintPreview.Report = rptHdbanhang_noVAT;
            //frmPrintPreview.Name = this.Name;
            //frmPrintPreview.EnablePrintPreview = this.EnablePrintPreview;
            rptHdbanhang_noVAT.DataSource = dsrHdbanhang_Chitiet;
            int i = 1;
            foreach (DataRow dr in dsRent_Checkin_Table_Hanghoa.Tables[0].Rows)
            {
                if (dr.RowState != DataRowState.Deleted)
                {
                    DataRow drnew = dsrHdbanhang_Chitiet.Tables[0].NewRow();
                    foreach (DataColumn dc in dsRent_Checkin_Table_Hanghoa.Tables[0].Columns)
                    {
                        try
                        {
                            if (drnew.Table.Columns.Contains(dc.ColumnName))
                                drnew[dc.ColumnName] = dr[dc.ColumnName];
                        }
                        catch (Exception ex)
                        {
                            GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                            continue;
                        }
                    }
                    drnew["Ten_Hanghoa"] = dr["Ten_Hanghoa_Ban"]; // gridLookUp_Hanghoa_Ban_Chitiet.GetDisplayText(dr["Id_Hanghoa_Ban"]);
                    drnew["Dongia_Ban"] = dr["Dongia"];
                    drnew["Thanhtien"] = dr["Thanhtien"];
                    drnew["Stt"] = i++;
                    dsrHdbanhang_Chitiet.Tables[0].Rows.Add(drnew);
                }
            }
            //add parameter values
            //rptHdbanhang_noVAT.xrLbl_Tieude.Text = "HÓA ĐƠN KHÁCH HÀNG";
            rptHdbanhang_noVAT.tbc_Ngay.Text = "" + dtNgay_Order.Text + "    * Bàn: " + txtTen_Table.Text;
            rptHdbanhang_noVAT.tbcSochungtu.Text = "" + txtSochungtu.Text;
            rptHdbanhang_noVAT.lblNhansu_Bill.Text = lookUp_Nhansu_Bill.Text;
            decimal thanhtien = Convert.ToDecimal("0" + dsRent_Checkin_Table_Hanghoa.Tables[0].Compute("Sum(thanhtien)", ""));
            rptHdbanhang_noVAT.PageSize = new Size(800, 1400 + 100 * Convert.ToInt32(dsrHdbanhang_Chitiet.Tables[0].Rows.Count));
            //Trừ tiền cọc booking
            //if ("" + txtTien_Booking.EditValue != "")
            //{
            //    decimal Thanhtien_TG = Convert.ToDecimal("0" +
            //        dsrHdbanhang_Chitiet.Tables[0].Rows[dsrHdbanhang_Chitiet.Tables[0].Rows.Count - 1]["Thanhtien_TG"]);
            //    Thanhtien_TG -= Convert.ToDecimal(txtTien_Booking.EditValue);
            //    dsrHdbanhang_Chitiet.Tables[0].Rows[dsrHdbanhang_Chitiet.Tables[0].Rows.Count - 1]["Thanhtien_TG"] = Thanhtien_TG;
            //    rptHdbanhang_noVAT.xrTable_Tien_Booking.Visible = true;
            //    rptHdbanhang_noVAT.lblTien_Booking.Text = string.Format("{0:#,#}", txtTien_Booking.EditValue);
            //}
            //else
            //{
            //    rptHdbanhang_noVAT.xrTable6.Location = new System.Drawing.Point(21, 42);
            //    rptHdbanhang_noVAT.xrTable4.Location = new System.Drawing.Point(21, 135);
            //}
            #region Set he so ctrinh - logo, ten cty

            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));
                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);
                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData});
                rptHdbanhang_noVAT.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                rptHdbanhang_noVAT.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                rptHdbanhang_noVAT.xrPic_Logo.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }
            #endregion
            rptHdbanhang_noVAT.lblTongcong.Text = thanhtien.ToString();
            string str = GoobizFrame.Windows.HelperClasses.ReadNumber.ChangeNum2VNStr((double)thanhtien, " đồng.");
            str = str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower();
            rptHdbanhang_noVAT.tbcThanhtien_Bangchu.Text = str;
            rptHdbanhang_noVAT.CreateDocument();
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(rptHdbanhang_noVAT);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                frmPrintPreview.Text = "" + oReportOptions.Caption;
                frmPrintPreview.printControl1.PrintingSystem = rptHdbanhang_noVAT.PrintingSystem;
                frmPrintPreview.MdiParent = this.MdiParent;
                frmPrintPreview.Text = this.Text + "(Xem trang in)";
                frmPrintPreview.Show();
                frmPrintPreview.Activate();
            }
            else
            {
                var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rptHdbanhang_noVAT);
                ReportPrintTool.Print();
            }
            return base.PerformPrintPreview();
        }
        #endregion

        #region master view
        /// <summary>
        /// Truy xuat DateTime thay doi du lieu cuoi cung
        private DateTime GetLastChange_FrmLognotify(string table_name)
        {
            try
            {
                var sdr = dsSys_Lognotify.Tables[0].Select(string.Format("Table_Name='{0}'", table_name));
                if (sdr != null && sdr.Length > 0)
                    return Convert.ToDateTime(sdr[0]["Last_Change"]);
                else
                    return DateTime.MinValue;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                return new DateTime(2010, 01, 01);
            }
        }

        void LoadTableMenu()
        {
            ds_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
            dsBar_Dm_Menu = objMasterService.Get_Visible_Bar_Dm_Menu().ToDataSet();
            dsCtrinh_Kmai_Rent_Chitiet = objWareService.Ware_Ctrinh_Kmai_Chitiet_SelectByDate_WithHanghoa(objBarService.GetServerDateTime(), true).ToDataSet();
            //dgbar_Dm_Menu
            dgbar_Dm_Menu.DataSource = dsBar_Dm_Menu.Tables[0];
            gridLookUp_Menu.DataSource = dsBar_Dm_Menu.Tables[0];
            //dgbar_Dm_Menu_Hanghoa_Ban
            dsMenu_Hanghoa_Ban = objMasterService.Get_Visible_Bar_Dm_Menu_Hanghoa_Ban_Collection(null, Current_Id_Khuvuc).ToDataSet();
            dgbar_Dm_Menu_Hanghoa_Ban.DataSource = dsMenu_Hanghoa_Ban.Tables[0];
            gridLookUp_Hanghoa_Ban_Chitiet.DataSource = ds_Hanghoa_Ban.Tables[0];
            gridLookUp_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
        }

        void LoadMasterTable()
        {
            try
            {
                current_id_nhansu = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu();
                ds_Khachhang = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
                dsNhansu_Order = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
                lookUp_Nhansu_Order.Properties.DataSource = dsNhansu_Order.Tables[0];
                lookUp_Nhansu_Bill.Properties.DataSource = dsNhansu_Order.Tables[0];
                cardView_Nhom_Hanghoa_Ban.FocusedRowHandle = 0;
                FilterNhom_Hanghoa_Ban();
                dsNhom_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Nhom_Hanghoa_Ban_ByBarMenu().ToDataSet();
                ds_Ware_Dm_Donvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
                //don vi tinh
                gridLookUpEdit_Donvitinh.DataSource = ds_Ware_Dm_Donvitinh.Tables[0];
                gridLookUp_Donvitinh.DataSource = ds_Ware_Dm_Donvitinh.Tables[0];

                //dgNhom_Hanghoa_Ban
                dgNhom_Hanghoa_Ban.DataSource = dsNhom_Hanghoa_Ban.Tables[0];
                if (dsNhom_Hanghoa_Ban.Tables[0].Rows.Count > 0)
                {
                    int i = Convert.ToInt32("0" + dsNhom_Hanghoa_Ban.Tables[0].Rows[0]["Id_Nhom_Hanghoa_Ban"]);
                    foreach (DataRow drNhom_Hanghoa_Ban in dsNhom_Hanghoa_Ban.Tables[0].Rows)
                    {
                        DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition = new DevExpress.XtraGrid.StyleFormatCondition();
                        styleFormatCondition.Appearance.BackColor = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetColor(Convert.ToInt32(drNhom_Hanghoa_Ban["Id_Nhom_Hanghoa_Ban"]));
                        styleFormatCondition.Appearance.Options.UseBackColor = true;
                        styleFormatCondition.ApplyToRow = true;
                        styleFormatCondition.Column = this.cardView_bar_Dm_Menu.Columns["Id_Nhom_Hanghoa_Ban"];
                        styleFormatCondition.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
                        styleFormatCondition.Value1 = Convert.ToInt32(drNhom_Hanghoa_Ban["Id_Nhom_Hanghoa_Ban"]);
                        this.cardView_bar_Dm_Menu.FormatConditions.Add(styleFormatCondition);
                        this.cardView_Nhom_Hanghoa_Ban.FormatConditions.Add(styleFormatCondition);
                    }
                }
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        public override void DisplayInfo()
        {
            try
            {
                index_CardMenu = 0;
                lblWarning.Text = "";
                Id_Cuahang_Ban = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocation("Id_Cuahang_Ban");
                if ("" + Id_Cuahang_Ban == "")
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] { "cửa hàng" });
                    return;
                }
                ClearDataBindings();
                //khu vuc
                var dsbar_dm_khuvuc = objMasterService.Get_All_Bar_Dm_Khuvuc_ByCuahang(new WebReferences.MasterService.Bar_Dm_Khuvuc()
                {
                    Id_Cuahang_Ban = Id_Cuahang_Ban
                }).ToDataSet();
                //this.DataBindingControl();
                this.ChangeStatus(false);
                btnSave.Text = "Gửi Order";
                ChangeFormState(GoobizFrame.Windows.Forms.FormState.View);
                if (ds_Hanghoa_Ban == null)
                    LoadTableMenu();
                //get all log
                //dsSys_Lognotify = objMasterService.GetAll_Sys_Lognotify();
                dsRent_Checkin_Table_Hanghoa = objBarService.Get_Bar_Rent_Checkin_table_Hanghoa_By_Checkin_Table(id_bar_rent_checkin_table).ToDataSet();
                dgbar_Table_Order.DataSource = dsRent_Checkin_Table_Hanghoa.Tables[0];
                ShowDetail();
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        public override void ClearDataBindings()
        {
            this.txtTen_Table.DataBindings.Clear();
            this.txtVitri.DataBindings.Clear();
            this.dtNgay_Order.DataBindings.Clear();
            this.lookUp_Nhansu_Order.DataBindings.Clear();
            this.lookUp_Nhansu_Bill.DataBindings.Clear();
            this.txtSochungtu.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtTen_Table.DataBindings.Add("EditValue", dsTable_Order, dsTable_Order.Tables[0].TableName + ".Ten_Table");
                this.txtVitri.DataBindings.Add("EditValue", dsTable_Order, dsTable_Order.Tables[0].TableName + ".Vitri");
                this.txtSochungtu.DataBindings.Add("EditValue", dsTable_Order, dsTable_Order.Tables[0].TableName + ".Sochungtu");
                this.dtNgay_Order.DataBindings.Add("EditValue", dsTable_Order, dsTable_Order.Tables[0].TableName + ".Ngay_Order");
                this.lookUp_Nhansu_Order.DataBindings.Add("EditValue", dsTable_Order, dsTable_Order.Tables[0].TableName + ".Id_Nhansu_Order");
                this.lookUp_Nhansu_Bill.DataBindings.Add("EditValue", dsTable_Order, dsTable_Order.Tables[0].TableName + ".Id_Nhansu_Bill");
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        #endregion

        #region detail view

        /// Tinh khuyen mai
        void Cal_KhuyenMai()
        {
            try
            {
                DataSet Ctrinh_Km_Rent = objWareService.Get_All_Ware_Ctrinh_Kmai_ByDate(DateTime.Now, true).ToDataSet();
                decimal per_dongia = 0;
                if (Ctrinh_Km_Rent != null && Ctrinh_Km_Rent.Tables[0].Rows.Count > 0)
                    if (Convert.ToBoolean(Ctrinh_Km_Rent.Tables[0].Rows[0]["Giam_Hoadon"]))
                        per_dongia = Convert.ToDecimal("0" + Ctrinh_Km_Rent.Tables[0].Rows[0]["Per_Hoadon"]);
                foreach (DataRow dr in dsRent_Checkin_Table_Hanghoa.Tables[0].Rows)
                {
                    //set giam gia theo khuyen mai
                    if (dsCtrinh_Kmai_Rent_Chitiet != null
                    && dsCtrinh_Kmai_Rent_Chitiet.Tables.Count > 0
                    && dsCtrinh_Kmai_Rent_Chitiet.Tables[0].Rows.Count > 0)
                    {
                        //tim gia tri khuyen mai tu ds khuyen mai chi tiet
                        //dua vao id hang hoa
                        DataRow[] sdr = null;
                        if (dr.RowState == DataRowState.Deleted)
                            continue;
                        if (dr["Id_Donvitinh"].ToString() != "")
                        {
                            DataRow[] sdr_Hanghoa = dsCtrinh_Kmai_Rent_Chitiet.Tables[0].Select("Id_Hanghoa_Ban=" + dr["Id_Hanghoa_Ban"]);
                            for (int i = 0; i < sdr_Hanghoa.Length; i++)
                            {
                                if ("" + sdr_Hanghoa[i]["Id_Donvitinh"] != "")
                                {
                                    sdr = dsCtrinh_Kmai_Rent_Chitiet.Tables[0].Select("Id_Donvitinh = " + sdr_Hanghoa[i]["Id_Donvitinh"]);
                                    break;
                                }
                                else
                                    sdr = sdr_Hanghoa;
                            }
                            //neu co gia tri km & hang hoa trong hoa don chua co khuyen mai nao khac
                            if (per_dongia != 0)
                                dr["Per_Dongia"] = per_dongia;
                            else
                                if (sdr != null
                                    && sdr.Length > 0
                                    && "" + dr["Per_Dongia"] == "")
                                    dr["Per_Dongia"] = Convert.ToDecimal("0" + sdr[0]["Per_Dongia"]);
                        }
                    }
                    //neu hang hoa da duoc phuc vu -> tinh thanh tien
                    if ("" + dr["Served"] == "True")
                        dr["Thanhtien"] = Convert.ToDecimal(dr["Soluong"]) * Convert.ToDecimal("0" + dr["Dongia"]) * (1 - Convert.ToDecimal("0" + dr["Per_Dongia"]) / 100);
                    else
                        dr["Thanhtien"] = DBNull.Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #region code not use
        ///// <summary>
        ///// tinh lai % giam don gia cho VIP card
        ///// </summary>
        //void Recal_Dongia()
        //{
        //    //Get_All_Ware_Vip_Member_HhDetail_By_Khachhang
        //    DataSet dsVip_Member_HhDetail_By_Khachhang =
        //        objWareService.Get_All_Ware_Vip_Member_HhDetail_By_Khachhang(lookUpEdit_Khachhang.EditValue, dtNgay_Order.EditValue);

        //    //Update Min quota
        //    objWareService.Update_Ware_Khachhang_Min_Quota(lookUpEdit_Khachhang.EditValue, dtNgay_Order.EditValue);
        //    //-1 : not limit
        //    decimal min_quota = -1;
        //    decimal max_quota = 0;
        //    decimal km_per_dongia = 0;

        //    DataSet dsWare_Khachhang_Quota = objWareService.Get_All_Ware_Khachhang_Quota_Detail_By_Khachhang(lookUpEdit_Khachhang.EditValue);
        //    try
        //    {
        //        //get so tien han muc con lai
        //        min_quota = Convert.ToDecimal(dsWare_Khachhang_Quota.Tables[0].Rows[0]["Min_Quota"]);
        //        max_quota = Convert.ToDecimal(dsWare_Khachhang_Quota.Tables[0].Rows[0]["Max_Quota"]);
        //        txtMin_Quota.EditValue = min_quota;
        //        txtPer_Dongia.EditValue = vip_per_dongia;
        //    }
        //    catch (Exception ex)
        //    {
        //        min_quota = 0;
        //        GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message);
        //    }

        //    foreach (DataRow row in dsRent_Checkin_Table_Hanghoa.Tables[0].Rows)
        //    {
        //        if ("" + row["Served"] != "True") continue;

        //        //set giam gia theo khuyen mai
        //        if (dsCtrinh_Kmai_Chitiet != null
        //        && dsCtrinh_Kmai_Chitiet.Tables.Count > 0
        //        && dsCtrinh_Kmai_Chitiet.Tables[0].Rows.Count > 0)
        //        {
        //            DataRow[] sdr = dsCtrinh_Kmai_Chitiet.Tables[0].Select("Id_Hanghoa_Ban=" + row["Id_Hanghoa_Ban"]);
        //            if (sdr != null && sdr.Length > 0)
        //            {
        //                km_per_dongia = Convert.ToDecimal("0" + sdr[0]["Per_Dongia"]);
        //                row["Per_Dongia"] = km_per_dongia;
        //            }

        //        }
        //        decimal tt1 = 0;
        //        decimal tt2 = 0;
        //        decimal balance = 0;
        //        decimal new_perc = 0;

        //        //neu co giam gia theo km -> tinh lai % giam gia 
        //        if (km_per_dongia != 0)
        //            tt1 = Convert.ToDecimal(row["Soluong"]) * Convert.ToDecimal(row["Dongia"]) * (1 - Convert.ToDecimal(km_per_dongia) / 100);
        //        else
        //            tt1 = Convert.ToDecimal(row["Soluong"]) * Convert.ToDecimal(row["Dongia"]);

        //        tt2 = tt1 * (1 - Convert.ToDecimal(vip_per_dongia) / 100);
        //        balance = tt1 - tt2;

        //        if (max_quota == 0
        //            && dsVip_Member_HhDetail_By_Khachhang.Tables.Count > 0 && dsVip_Member_HhDetail_By_Khachhang.Tables[0].Rows.Count > 0)
        //        {
        //            try
        //            {
        //                //khach hang thuoc vip class A/ B/ C
        //                DataRow drPer_Hoadon = dsVip_Member_HhDetail_By_Khachhang.Tables[0].Select("Id_Hanghoa_Ban="
        //                    + row["Id_Hanghoa_Ban"])[0];
        //                decimal vipclass_per_dongia = Convert.ToDecimal(drPer_Hoadon["Per_Hoadon"]);
        //                new_perc = km_per_dongia + (100 - km_per_dongia) * vipclass_per_dongia / 100;
        //            }
        //            catch (Exception ex)
        //            {
        //                continue;
        //            }
        //        }
        //        //neu con trong han muc
        //        else if (min_quota > 0 && min_quota - balance >= 0 || min_quota == -1)
        //            new_perc = km_per_dongia + (100 - km_per_dongia) * vip_per_dongia / 100;
        //        else if (min_quota > 0)
        //        {
        //            decimal tt = Convert.ToDecimal(row["Soluong"]) * Convert.ToDecimal(row["Dongia"]);
        //            decimal tt_conlai = tt1 - min_quota;
        //            new_perc = 100 - (tt_conlai * 100) / tt;
        //        }

        //        //set giam gia moi & tinh lai han muc
        //        row["Per_Dongia"] = new_perc;
        //        min_quota = (min_quota == -1 || max_quota == 0) ? min_quota : min_quota - balance;

        //        try
        //        {
        //            row["Thanhtien"] =
        //                Convert.ToDecimal(row["Soluong"]) * Convert.ToDecimal(row["Dongia"]) * (1 - Convert.ToDecimal("0" + row["Per_Dongia"]) / 100);
        //        }
        //        catch (Exception exception) { }

        //        dgbar_Table_Order.EmbeddedNavigator.Buttons.EndEdit.DoClick();
        //    }
        //}
        #endregion


        //void Recal_Dongia()
        //{
        //    try
        //    {
        //        ////Update Min quota nhanvuong --> chuyển code update sang performsave();
        //        //if ("" + lookUp_Khachhang.EditValue != "" && Convert.ToInt32(lookUp_Khachhang.EditValue) != -1)
        //        //    objWareService.Update_Ware_Khachhang_Min_Quota(lookUp_Khachhang.EditValue, NgayChungtu);
        //        dsKhachhang_KM = objWareService.Get_All_Ware_Khachhang_Quota_Detail_By_Khachhang(lookUp_Khachhang.EditValue).ToDataSet();
        //        if (dsKhachhang_KM.Tables.Count > 0 && dsKhachhang_KM.Tables[0].Rows.Count > 0)
        //        {
        //            #region check nếu khách hàng có thẻ VIP
        //            if (dsKhachhang_KM.Tables[0].Rows[0]["Id_Vip_Member"].ToString() != "") // check if khach hang VIP
        //            {
        //            }
        //            #endregion
        //            #region khach hang Quota
        //            else
        //            {
        //                Decimal sumBill = Convert.ToDecimal("0" + dsRent_Checkin_Table_Hanghoa.Tables[0].Compute("sum(Thanhtien)", ""));
        //                Decimal minQuota = Convert.ToDecimal("0" + dsKhachhang_KM.Tables[0].Rows[0]["Min_Quota"]);
        //                if (gvbar_Table_Order.RowCount != 0)
        //                {
        //                    if (sumBill <= minQuota) // nếu tổng số tiền nhỏ hơn số tiền quota
        //                    {
        //                        foreach (DataRow row in dsRent_Checkin_Table_Hanghoa.Tables[0].Rows)
        //                        {
        //                            row["Thanhtien_Km"] = row["Thanhtien"];
        //                        }
        //                        if (minQuota == 0)
        //                            minQuota = Convert.ToDecimal("0" + dsKhachhang_KM.Tables[0].Rows[0]["Max_Quota"]);                         
        //                        lblWarning.Text = "Khách hàng " + dsKhachhang_KM.Tables[0].Rows[0]["Ten_Khachhang"] + " có quota là: " + Convert.ToInt32(minQuota);
        //                        return;
        //                    }
        //                    else
        //                    {
        //                        object percentKM = minQuota / sumBill;
        //                        foreach (DataRow row in dsRent_Checkin_Table_Hanghoa.Tables[0].Rows)
        //                        {
        //                            row["Thanhtien_Km"] = Convert.ToDecimal("0" + Convert.ToDecimal(row["Thanhtien"]) * Convert.ToDecimal(percentKM));
        //                        }
        //                    }
        //                }                     
        //                lblWarning.Text = "Khách hàng " + dsKhachhang_KM.Tables[0].Rows[0]["Ten_Khachhang"] + " có quota là: " + Convert.ToInt32(minQuota);
        //            }
        //        }
        //        this.DoClickEndEdit(dgbar_Table_Order); //dgbar_Table_Order.EmbeddedNavigator.Buttons.EndEdit.DoClick();
        //            #endregion
        //    }
        //    catch (Exception ex)
        //    {
        //        GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
        //    }
        //}

        /// <summary>
        /// show master info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInfo_Click(object sender, EventArgs e)
        {
        }

        public bool checkUser_KM()
        {
            //neu thay doi field KM(Per_Dongia) --> phai xac nhan nguoi thay doi co quyen hay khong
            GoobizFrame.Windows.Forms.Policy.Authorization.Actions Actions = GoobizFrame.Windows.MdiUtils.MdiChecker.ShowIDCardLogonWithResult(this);
            if (Actions.Count == 0 || !Actions.Contains("EnableReduce"))
            {
                lblWarning.Text = "Thẻ khuyến mãi không có hiệu lực";
                return false;
            }
            else
            {
                AllowEdit_Per_Dongia = true;
                Id_Nhansu_Km = Convert.ToInt32(Actions.Id_Nhansu);
                return true;
            }
        }

        /// <summary>
        /// Xóa món ăn khỏi bàn (chỉ xóa món ăn chưa phục vụ)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_btnXoamon_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (Convert.ToInt32("0" + gvbar_Table_Order.GetFocusedRowCellValue("Soluong_Phucvu")) > 0)
            {
                lblWarning.Text = "Không thể xóa, Số lượng đã phục vụ: " + gvbar_Table_Order.GetFocusedRowCellValue("Soluong_Phucvu");
                return;
            }
            else
                if ("" + gvbar_Table_Order.GetFocusedRowCellValue("Served") == ""
                    || !Convert.ToBoolean(gvbar_Table_Order.GetFocusedRowCellValue("Served")))
                {
                    try
                    {
                        if (!current_id_nhansu.Equals("" + gvbar_Table_Order.GetFocusedRowCellValue("Id_Nhansu_Order")))
                        {
                            lblWarning.Text = "Bạn không thể xóa món ăn này. Món ăn này do nhân viên khác order";
                            return;
                        }
                        //if (MessageBox.Show("Bạn có chắc muốn xóa món này ra khỏi hóa đơn?", "Confirm Dialog", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[] { "Món " }) == DialogResult.Yes)
                        {
                            //dsRent_Checkin_Table_Hanghoa.Tables[0].Rows.RemoveAt(gridView2.FocusedRowHandle);
                            gvbar_Table_Order.GetDataRow(gvbar_Table_Order.FocusedRowHandle).Delete();
                            gvbar_Table_Order.MoveLastVisible();
                        }
                    }
                    catch (Exception ex)
                    {
                        GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                    }
                }
        }

        /// <summary>
        /// Click button --> nhập Ghi chú
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //if (!Convert.ToBoolean(gvbar_Table_Order.GetFocusedRowCellValue(gvbar_Table_Order.Columns["Booking"])))
            //    if (!current_id_nhansu.Equals("" + gvbar_Table_Order.GetFocusedRowCellValue("Id_Nhansu_Order")))
            //    {
            //        lblWarning.Text = "Bạn không thể chỉnh sửa món ăn này. Món ăn này do nhân viên khác order";
            //        return;
            //    }
            DataRowView drHanghoa_Ban = (DataRowView)gridLookUp_Hanghoa_Ban_Chitiet.GetDataSourceRowByKeyValue(
                gvbar_Table_Order.GetFocusedRowCellValue("Id_Hanghoa_Ban"));
            string vGhichu = GoobizFrame.Windows.Forms.FrmGKeyboardInput.ShowInputDialog(
               "" + gvbar_Table_Order.GetFocusedRowCellValue(gvbar_Table_Order.FocusedColumn.FieldName), drHanghoa_Ban["Id_Nhom_Hanghoa_Ban"]);
            gvbar_Table_Order.SetFocusedRowCellValue(gvbar_Table_Order.FocusedColumn, vGhichu);
            gvbar_Table_Order.RefreshRow(gvbar_Table_Order.FocusedRowHandle);
        }

        /// <summary>
        /// nhap sl, km
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (("" + gvbar_Table_Order.GetFocusedRowCellValue(gvbar_Table_Order.Columns["Served"]) == "True"))
            {
                lblWarning.Text = "Món ăn này đã được pha chế xong, bạn không được chỉnh sửa.";
                return;
            }
            //if (!Convert.ToBoolean(gvbar_Table_Order.GetFocusedRowCellValue(gvbar_Table_Order.Columns["Booking"])))
            //    if (!current_id_nhansu.Equals("" + gvbar_Table_Order.GetFocusedRowCellValue("Id_Nhansu_Order")))
            //    {
            //        lblWarning.Text = "Bạn không thể chỉnh sửa món ăn này. Món ăn này do nhân viên khác order";
            //        return;
            //    }
            object value = GoobizFrame.Windows.Forms.FrmGNumboardInput.ShowInputDialog(
                "" + gvbar_Table_Order.GetFocusedRowCellValue("" + gvbar_Table_Order.FocusedColumn.FieldName));
            if (value.ToString().Contains("."))
            {
                lblWarning.Text = "Số lượng phải là số nguyên";
                return;
            }
            if (value.ToString().Contains("-"))
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Số lượng không được nhập số âm");
                value = value.ToString().Replace("-", "");
                gvbar_Table_Order.SetFocusedRowCellValue(gvbar_Table_Order.FocusedColumn, value);
                return;
            }
            if (value.ToString().Length >= 6)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Số lượng nhập không chính xác");
                //value = value.ToString().Substring(0, 5);
                gvbar_Table_Order.SetFocusedRowCellValue(gvbar_Table_Order.FocusedColumn, 1);
                return;
            }
            if (value.Equals(""))
                gvbar_Table_Order.SetFocusedRowCellValue(gvbar_Table_Order.FocusedColumn, DBNull.Value);
            else
            {
                int index = gvbar_Table_Order.FocusedRowHandle;
                DataRow[] dtr = dsMenu_Hanghoa_Ban.Tables[0].Select("Id_Hanghoa_Ban = " + gvbar_Table_Order.GetFocusedRowCellValue(gvbar_Table_Order.Columns["Id_Hanghoa_Ban"]));
                if (dtr.Length > 0 && Convert.ToBoolean(dtr[0]["Bc_NXT"]) == true)
                {
                    dtr = null;
                    dtr = dsRent_Checkin_Table_Hanghoa.Tables[0].Select("Id_Hanghoa_Ban = " + gvbar_Table_Order.GetFocusedRowCellValue(gvbar_Table_Order.Columns["Id_Hanghoa_Ban"]));
                    int soluong = Convert.ToInt32(value);
                    if (dtr.Length > 0 && dtr.Length != 1)
                        for (int i = 0; i < dtr.Length; i++)
                        {
                            soluong += Convert.ToInt32(dtr[i]["Soluong"]);
                        }
                    decimal soluong_ton = Get_Soluong_Ton_Quydoi(gvbar_Table_Order.GetFocusedRowCellValue(gvbar_Table_Order.Columns["Id_Hanghoa_Ban"]), gvbar_Table_Order.GetFocusedRowCellValue(gvbar_Table_Order.Columns["Id_Donvitinh"]));
                    if (soluong > soluong_ton)
                    {
                        GoobizFrame.Windows.Forms.MessageDialog.Show("Không đủ số lượng xuất theo yêu cầu, vui lòng kiểm tra lại, số lượng tồn hiện tại là : " + soluong_ton.ToString());
                        for (int i = 0; i < dtr.Length; i++)
                            gvbar_Table_Order.SetFocusedRowCellValue(gvbar_Table_Order.FocusedColumn, 1);
                        return;
                    }
                }
                gvbar_Table_Order.SetFocusedRowCellValue(gvbar_Table_Order.FocusedColumn, value);
            }
            gvbar_Table_Order.RefreshRow(gvbar_Table_Order.FocusedRowHandle);
        }

        /// <summary>
        /// nhap km all order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtKM_All_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (!AllowEdit_Per_Dongia)
            {
                if (checkUser_KM() == false)
                    return;
            }
        }

        /// <summary>
        /// gan value km
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #endregion

        #region Custom Button

        private void btnpic_PrintOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvbar_Table_Order.RowCount == 0)
                {
                    //  GoobizFrame.Windows.Forms.MessageDialog.Show("Bạn hiện tại đang trống");
                    lblWarning.Text = "Bàn hiện tại đang trống";
                    return;
                }
                if (dsRent_Checkin_Table_Hanghoa.Tables[0].Select("Served is null or Served = 0").Length > 0)
                {
                    lblWarning.Text = "Bàn có một vài món chưa phục vụ nên không thể thu tiền";
                    return;
                }
            }
            catch (Exception ex) { GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString()); }

            print_bill = true;
            //if(dsRent_Checkin_Table_Hanghoa.HasChanges())
            //{
            try
            {
                checkButton = true;
                this.UpdateObject();
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());

                return;
            }
            //}
            //if (success)
            //{                
            PerformPrintPreview();
            print_bill = false;
            DisplayInfo();
            //btnPrintOrder.Enabled = false;
            //}            
        }

        private void btnMenu_3_Click(object sender, EventArgs e)
        {
            ShowMenuToOrder();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            PerformClose();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            ChangeFormState(GoobizFrame.Windows.Forms.FormState.Edit);
            PerformEdit();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (PerformDelete())
            {
                FormState = GoobizFrame.Windows.Forms.FormState.View;
                //btnPrintOrder.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DoClickEndEdit(dgbar_Table_Order); //dgbar_Table_Order.EmbeddedNavigator.Buttons.EndEdit.DoClick();
            for (int i = 0; i < dsRent_Checkin_Table_Hanghoa.Tables[0].Rows.Count; i++)
            {
                if (dsRent_Checkin_Table_Hanghoa.Tables[0].Rows[i].RowState != DataRowState.Deleted)
                {
                    if (Convert.ToInt32(dsRent_Checkin_Table_Hanghoa.Tables[0].Rows[i]["Soluong"]) == 0)
                    {
                        lblWarning.Text = "Số lượng không được bằng 0 ";
                        dsRent_Checkin_Table_Hanghoa.Tables[0].Rows[i]["Soluong"] = 1;
                        return;
                    }
                }
            }
            Cal_KhuyenMai();
            checkButton = false;
            PerformSave();
            // ChangeFormState(GoobizFrame.Windows.Forms.FormState.View);
            timer1.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            PerformCancel();
            timer1.Enabled = true;
            //btnPrintOrder.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Logon process

        void LockAction()
        {
            xtraTabControl_Leftside.Enabled = false;
        }

        public override void ChangeStatus(bool editTable)
        {
            gvbar_Table_Order.OptionsBehavior.Editable = editTable;
            btnSave.Enabled = editTable;
            btnCancel.Enabled = editTable;
            CvDm_Menu_Hanghoa_Ban.OptionsBehavior.Editable = editTable;
            btnEdit.Enabled = !editTable;
            btnClose.Enabled = !editTable;
        }

        //private void changeVisibleButton(bool boo)
        //{
        //    btnGhep_Ban.Visible = boo;
        //    btnTach_Ban.Visible = boo;
        //    btnNextTable.Visible = boo;
        //    btnBackTable.Visible = boo;
        //    btnBooking.Visible = boo;
        //}

        private void textUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            //khong cho phep nhap text vao o ma nhân su
            e.Handled = true;
        }

        private void Frmbar_Table_Order_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == Keys.Insert && this.MdiParent == null)
            //{
            //    panelLogon.Visible = true;
            //    textUser.Focus();
            //    textUser.Text = "";
            //}
        }

        private void textUser_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //    if (textUser.Text != "")
            //        LogOn();
        }

        #endregion

        #region AddNewOrderDetails

        public decimal Get_Soluong_Ton_Quydoi(object Id_Hanghoa_Ban, object Id_Donvitinh)
        {
            try
            {
                var _Id_Donvitinh = ds_Hanghoa_Ban.Tables[0].Select(string.Format("Id_Hanghoa_Ban={0}", Id_Hanghoa_Ban))[0]["Id_Donvitinh"];
                DataSet ds_hh_nxt = Get_Soluong_Ton_Quydoi(Id_Cuahang_Ban, Id_Hanghoa_Ban, Id_Donvitinh);
                decimal soluong_ton_quydoi = 0;
                if ("" + Id_Donvitinh == "" + _Id_Donvitinh)
                    soluong_ton_quydoi = System.Convert.ToDecimal("0" + ds_hh_nxt.Tables[0].Compute("sum(Soluong_Ton_Qdoi)", ""));
                else
                    soluong_ton_quydoi = Convert.ToDecimal("0" + ds_hh_nxt.Tables[0].Compute("sum(Soluong_Ton)",
                        string.Format("Id_Hanghoa_Ban={0} and Id_Donvitinh={1}", Id_Hanghoa_Ban, Id_Donvitinh)));
                return soluong_ton_quydoi;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                return 0;
            }
        }

        public DataSet Get_Soluong_Ton_Quydoi(object Id_Cuahang_Ban, object Id_Hanghoa_Ban, object Id_Donvitinh)
        {
            try
            {
                DateTime current_date = objWareService.GetServerDateTime();
                int today = 1;
                if (current_date.Day == 1)
                    today = 1;
                else
                    today = current_date.Day - 1;

                return objWareService.Rptware_Nxt_Hhban_Qdoi(new DateTime(current_date.Year, current_date.Month, today, 0, 0, 0),
                                                                current_date, Id_Cuahang_Ban, Id_Hanghoa_Ban, Id_Donvitinh).ToDataSet();
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                return null;
            }
        }

        // thêm mới món ăn vào bàn
        void gridView_Dm_Menu_Hanghoa_Ban_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = CvDm_Menu_Hanghoa_Ban.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                if (CvDm_Menu_Hanghoa_Ban.FocusedRowHandle >= 0
                    //&& dsRent_Checkin_Table_Hanghoa.Tables.Count > 0
            && FormState != GoobizFrame.Windows.Forms.FormState.View)
                {
                    if ("" + CvDm_Menu_Hanghoa_Ban.GetRowCellValue(cardHit.RowHandle, "Dongia") != "")
                    {
                        try
                        {
                            object id_hanghoa_ban = CvDm_Menu_Hanghoa_Ban.GetRowCellValue(cardHit.RowHandle, "Id_Hanghoa_Ban");
                            object id_donvitinh = CvDm_Menu_Hanghoa_Ban.GetRowCellValue(cardHit.RowHandle, "Id_Donvitinh");
                            if (Convert.ToBoolean(CvDm_Menu_Hanghoa_Ban.GetRowCellValue(cardHit.RowHandle, "Bc_NXT"))) // nếu true --> check NXT
                            {
                                DataRow[] dtr = dsRent_Checkin_Table_Hanghoa.Tables[0].Select("Id_Hanghoa_Ban = " + id_hanghoa_ban);
                                int soluong = 0;
                                if (dtr.Length > 0)
                                {
                                    for (int i = 0; i < dtr.Length; i++)
                                    {
                                        soluong += Convert.ToInt32(dtr[i]["Soluong"]);
                                    }
                                    soluong += 1;
                                }
                                else
                                    soluong = 1;
                                if (soluong > Get_Soluong_Ton_Quydoi(id_hanghoa_ban, id_donvitinh))
                                {
                                    lblWarning.Text = "Không đủ số lượng xuất theo yêu cầu, vui lòng kiểm tra lại";
                                    return;
                                }
                                else
                                    addNewRow_Into_Order(id_hanghoa_ban, id_donvitinh, CvDm_Menu_Hanghoa_Ban.GetRowCellValue(cardHit.RowHandle, "Dongia"));
                            }
                            else
                                addNewRow_Into_Order(id_hanghoa_ban, id_donvitinh, CvDm_Menu_Hanghoa_Ban.GetRowCellValue(cardHit.RowHandle, "Dongia"));
                        }
                        catch (Exception ex) { GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString()); }
                    }
                    else
                        lblWarning.Text = CvDm_Menu_Hanghoa_Ban.GetRowCellDisplayText(cardHit.RowHandle, CvDm_Menu_Hanghoa_Ban.Columns["Id_Hanghoa_Ban"]) + " chưa có giá bán";
                }
            }
        }

        void addNewRow_Into_Order(object id_hanghoa, object id_donvitinh, object dongia)
        {
            DataRow ndr = dsRent_Checkin_Table_Hanghoa.Tables[0].NewRow();
            ndr["Id_Bar_Rent_Checkin_Table_Hanghoa"] = DateTime.Now.Ticks;
            ndr["Id_Hanghoa_Ban"] = id_hanghoa;
            ndr["Id_Donvitinh"] = id_donvitinh;
            ndr["Soluong"] = 1;
            ndr["Dongia"] = dongia;
            //ndr["Thanhtien"] = Convert.ToDecimal("0" + dongia) * Convert.ToDecimal("0" + ndr["Soluong"]);
            ndr["Id_Nhansu_Order"] = current_id_nhansu;
            dsRent_Checkin_Table_Hanghoa.Tables[0].Rows.Add(ndr);
            gvbar_Table_Order.MoveLastVisible();
            lblWarning.Text = "";
            dgbar_Table_Order.DataSource = dsRent_Checkin_Table_Hanghoa.Tables[0];
        }

        #endregion

        #region Show Menu

        void ShowMenuToOrder()
        {
            CvDm_Menu_Hanghoa_Ban.Columns["Id_Menu"].Visible = false; //btnMenu_2.Visible = false;
            dgbar_Dm_Menu.Visible = true;
            dgNhom_Hanghoa_Ban.Dock = DockStyle.Fill;
            lblWarning.Text = "";

            if (cardView_Nhom_Hanghoa_Ban.RowCount > 0)
            {
                cardView_Nhom_Hanghoa_Ban.FocusedRowHandle = 0;
                cardView_bar_Dm_Menu.Columns["Id_Nhom_Hanghoa_Ban"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                    cardView_bar_Dm_Menu.Columns["Id_Nhom_Hanghoa_Ban"], cardView_Nhom_Hanghoa_Ban.GetFocusedRowCellValue("Id_Nhom_Hanghoa_Ban"));
                cardView_bar_Dm_Menu.ApplyColumnsFilter();

                if (cardView_bar_Dm_Menu.RowCount > 0)
                {
                    cardView_bar_Dm_Menu.FocusedRowHandle = 0;
                    CvDm_Menu_Hanghoa_Ban.Columns["Id_Menu"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                        CvDm_Menu_Hanghoa_Ban.Columns["Id_Menu"], cardView_bar_Dm_Menu.GetFocusedRowCellValue("Id_Menu"));
                    CvDm_Menu_Hanghoa_Ban.ApplyColumnsFilter();
                    CvDm_Menu_Hanghoa_Ban.FocusedRowHandle = -1;
                }
            }
        }

        void cardView_Nhom_Hanghoa_Ban_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cardView_Nhom_Hanghoa_Ban.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                Id_Nhom_Hanghoa_Ban = cardView_Nhom_Hanghoa_Ban.GetRowCellValue(cardHit.RowHandle, cardView_Nhom_Hanghoa_Ban.Columns["Id_Nhom_Hanghoa_Ban"]);
                FilterNhom_Hanghoa_Ban();
            }
        }

        void FilterNhom_Hanghoa_Ban()
        {
            if (cardView_Nhom_Hanghoa_Ban.FocusedRowHandle >= 0
                && FormState != GoobizFrame.Windows.Forms.FormState.View)
                try
                {
                    cardView_bar_Dm_Menu.Columns["Id_Nhom_Hanghoa_Ban"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                    cardView_bar_Dm_Menu.Columns["Id_Nhom_Hanghoa_Ban"], Id_Nhom_Hanghoa_Ban);
                    cardView_bar_Dm_Menu.ApplyColumnsFilter();

                    if (cardView_bar_Dm_Menu.RowCount > 0)
                    {
                        cardView_bar_Dm_Menu.FocusedRowHandle = 0;
                        CvDm_Menu_Hanghoa_Ban.Columns["Id_Menu"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                            CvDm_Menu_Hanghoa_Ban.Columns["Id_Menu"], cardView_bar_Dm_Menu.GetFocusedRowCellValue("Id_Menu"));
                        CvDm_Menu_Hanghoa_Ban.ApplyColumnsFilter();
                        CvDm_Menu_Hanghoa_Ban.FocusedRowHandle = -1;
                    }
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                }
        }

        private void txtMa_Hanghoa_Ban_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtMa_Hanghoa_Ban.Text != "")
                {
                    Filter_Dm_Menu_Hanghoa_Ban();
                }
            }
        }

        private void btnSearch_HhBan_Click(object sender, EventArgs e)
        {
            if (txtMa_Hanghoa_Ban.Text != "")
            {
                Filter_Dm_Menu_Hanghoa_Ban();
            }
        }

        void Filter_Dm_Menu_Hanghoa_Ban()
        {
            CvDm_Menu_Hanghoa_Ban.ClearColumnsFilter();
            CvDm_Menu_Hanghoa_Ban.Columns["Ma_Hanghoa_Ban"].FilterInfo
                    = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(" Ma_Hanghoa_Ban like '" +
                   txtMa_Hanghoa_Ban.EditValue + "%'");
            CvDm_Menu_Hanghoa_Ban.Columns["Id_Menu"].Visible = true;
            CvDm_Menu_Hanghoa_Ban.Columns["Id_Menu"].VisibleIndex = 0;
        }

        #endregion

        void ShowDetail()
        {
            try
            {
                lblWarning.Text = "";
                lookUp_Nhansu_Bill.EditValue = Convert.ToInt64(current_id_nhansu);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #region Edit Row --> edit ghi chu, so luong, khuyen mai
        private void keyboardcontrol1_UserKeyPressed(object sender, GoobizFrame.Windows.Controls.TouchscreenKeyboard.KeyboardEventArgs e)
        {
            SendKeys.Send(e.KeyboardKeyPressed);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            gvbar_Table_Order.UpdateCurrentRow();
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            gvbar_Table_Order.GetDataRow(gvbar_Table_Order.FocusedRowHandle).CancelEdit();
        }

        #endregion

        //panel of sub menu
        private void cardView_bar_Dm_Menu_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo CardHitInfo = cardView_bar_Dm_Menu.CalcHitInfo(e.X, e.Y);
            if (CardHitInfo.InCard)
            {
                if (CardHitInfo.RowHandle >= 0
               && FormState != GoobizFrame.Windows.Forms.FormState.View)
                    try
                    {
                        object id_menu = cardView_bar_Dm_Menu.GetRowCellValue(CardHitInfo.RowHandle, "Id_Menu");
                        CvDm_Menu_Hanghoa_Ban.ClearColumnsFilter();
                        CvDm_Menu_Hanghoa_Ban.Columns["Id_Menu"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(CvDm_Menu_Hanghoa_Ban.Columns["Id_Menu"],
                           id_menu);
                    }
                    catch (Exception ex)
                    {
                        GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                    }
            }
        }

        #region button back to display list table

        private void btDisplayTable_Click(object sender, EventArgs e)
        {
            DisplayInfo();
            //btnPrintOrder.Enabled = false;
        }

        private void btDisplayTable2_Click(object sender, EventArgs e)
        {
            DisplayInfo();
        }

        #endregion

        #region button back to menu

        private void btnMenu_Click(object sender, EventArgs e)
        {
            ShowMenuToOrder();
        }

        private void btnMenu_2_Click(object sender, EventArgs e)
        {
            ShowMenuToOrder();
        }

        #endregion

        #region button Back & Next

        private void btnBackMenu_Click(object sender, EventArgs e)
        {
            cardView_bar_Dm_Menu.MovePrevPage();
            if (index_CardMenu != 0)
                index_CardMenu -= 1;
        }

        private void btnNextMenu_Click(object sender, EventArgs e)
        {
            cardView_bar_Dm_Menu.MoveNextPage();
            index_CardMenu += 1;
        }

        private void btnBackMenu_Detail_Click(object sender, EventArgs e)
        {
            CvDm_Menu_Hanghoa_Ban.MovePrevPage();
        }

        private void btnNextMenu_Detail_Click(object sender, EventArgs e)
        {
            CvDm_Menu_Hanghoa_Ban.MoveNextPage();
        }

        private void btnBackDetail_Click(object sender, EventArgs e)
        {
            gvbar_Table_Order.MovePrevPage();
        }

        private void btnNextDetail_Click(object sender, EventArgs e)
        {
            gvbar_Table_Order.MoveNextPage();
        }

        #endregion

        void panelControl_Menu_Click(object sender, EventArgs e)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        private void keyboardcontrol2_UserKeyPressed(object sender, GoobizFrame.Windows.Controls.TouchscreenKeyboard.KeyboardEventArgs e)
        {
            SendKeys.Send(e.KeyboardKeyPressed);
        }

        private void txtMa_Hanghoa_Ban_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtMa_Hanghoa_Ban.Text = "" + GoobizFrame.Windows.Forms.FrmGKeyboardInput.ShowInputDialog(txtMa_Hanghoa_Ban.Text);
        }

        private void txtMa_Hanghoa_Ban_Validating(object sender, CancelEventArgs e)
        {
            if (txtMa_Hanghoa_Ban.Text != "")
            {
                Filter_Dm_Menu_Hanghoa_Ban();
            }
        }

        private void gridButton_KM_Chitiet_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (!AllowEdit_Per_Dongia)
            {
                if (checkUser_KM() == false)
                    return;
            }
            else
            //if (checkUser_KM())
            {
                object value = GoobizFrame.Windows.Forms.FrmGNumboardInput.ShowInputDialog(
                    "" + gvbar_Table_Order.GetFocusedRowCellValue("" + gvbar_Table_Order.FocusedColumn.FieldName));
                if (value.ToString().Contains("."))
                {
                    lblWarning.Text = "Khuyến mãi phải là số nguyên";
                    return;
                }
                if (value.ToString().Contains("-"))
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Khuyến mãi không được nhập số âm");
                    value = value.ToString().Replace("-", "");
                    gvbar_Table_Order.SetFocusedRowCellValue(gvbar_Table_Order.FocusedColumn, value);
                    return;
                }
                if (value.ToString().Length >= 6)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Khuyến mãi nhập không chính xác");
                    value = value.ToString().Substring(0, 5);
                    gvbar_Table_Order.SetFocusedRowCellValue(gvbar_Table_Order.FocusedColumn, value);
                    return;
                }
                if (value.Equals(""))
                    gvbar_Table_Order.SetFocusedRowCellValue(gvbar_Table_Order.FocusedColumn, DBNull.Value);
                else
                    gvbar_Table_Order.SetFocusedRowCellValue(gvbar_Table_Order.FocusedColumn, value);
                gvbar_Table_Order.RefreshRow(gvbar_Table_Order.FocusedRowHandle);
            }
        }

        private void btnBack_Nhom_Click(object sender, EventArgs e)
        {
            cardView_Nhom_Hanghoa_Ban.MovePrevPage();
        }

        private void btnNext_Nhom_Click(object sender, EventArgs e)
        {
            cardView_Nhom_Hanghoa_Ban.MoveNextPage();
        }

        private void gvbar_Table_Order_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvbar_Table_Order.SetFocusedRowCellValue("Id_Bar_Rent_Checkin_Table", long.MaxValue - gvbar_Table_Order.RowCount);
        }

        private void gvbar_Table_Order_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //if (("" + gridView2.GetFocusedRowCellValue("Served") == "True"))
            //{
            //    lblWarning.Text = "Món ăn này đã được pha chế xong, bạn không được chỉnh sửa.";
            //    gridView2.CancelUpdateCurrentRow();
            //    return;
            //}
            if (!current_id_nhansu.Equals("" + gvbar_Table_Order.GetFocusedRowCellValue("Id_Nhansu_Order")))
            {
                lblWarning.Text = "Bạn không thể chỉnh sửa món ăn này. Món ăn này do nhân viên khác order";
                gvbar_Table_Order.CancelUpdateCurrentRow();
                return;
            }
            DataRow[] dtr_In_Db = null;
            lblWarning.Text = "";
            DataRow dr_change = gvbar_Table_Order.GetDataRow(e.RowHandle);
            if (dr_change == null) return;
            if (dr_change.RowState != DataRowState.Added)
                dtr_In_Db = dsRent_Checkin_Table_Hanghoa.Tables[0].Select("Id_Bar_Rent_Checkin_Table = " + dr_change["Id_Bar_Rent_Checkin_Table"]);
            switch (e.Column.FieldName)
            {
                case "Ghichu":
                    if (!current_id_nhansu.Equals("" + gvbar_Table_Order.GetFocusedRowCellValue("Id_Nhansu_Order")))
                    {
                        lblWarning.Text = "Bạn không thể chỉnh sửa món ăn này. Món ăn này do nhân viên khác order";
                        return;
                    }
                    //if (!gridView2.GetFocusedRowCellValue(gridView2.Columns["Id_Nhansu_Order"]).ToString().Equals(current_id_nhansu))
                    //{
                    //    lblWarning.Text = "Bạn không được chỉnh sửa món ăn này. Món ăn này do nhân viên khác order";
                    //    dr_change.RejectChanges();
                    //    return;
                    //}
                    break;
                case "Per_Dongia":
                    if ("" + dr_change["Per_Dongia"] != "")
                    {
                        lblWarning.Text = "";
                        if (Convert.ToDecimal("0" + dr_change["Per_Dongia"]) > 100 || Convert.ToDecimal("0" + dr_change["Per_Dongia"]) < 0)
                        {
                            lblWarning.Text = "Giá trị khuyến mãi không hợp lệ (từ 0 - 100)";
                            if (dr_change.RowState == DataRowState.Added)
                            {
                                dr_change["Per_Dongia"] = DBNull.Value;
                                return;
                            }
                            else
                            {
                                dr_change.RejectChanges();
                                return;
                            }
                        }
                        ///neu user nhap gia tri khuyen mai de giam don gia
                        if (!AllowEdit_Per_Dongia)
                        {
                            if (checkUser_KM() == false)
                            {
                                dr_change.CancelEdit();
                                dr_change.RejectChanges();
                            }
                        }
                    }
                    break;
                case "Id_Hanghoa_Ban":
                    if ("" + gvbar_Table_Order.GetFocusedRowCellValue(gvbar_Table_Order.Columns["Served"]) != "True")
                    {
                        dr_change["Id_Donvitinh"] =
                        ((System.Data.DataRowView)gridLookUp_Hanghoa_Ban_Chitiet.GetDataSourceRowByKeyValue(e.Value))["Id_Donvitinh"];
                        dr_change["Dongia"] =
                           ((System.Data.DataRowView)gridLookUp_Hanghoa_Ban_Chitiet.GetDataSourceRowByKeyValue(e.Value))["Dongia_Ban"];
                    }
                    else
                    {
                        dr_change.CancelEdit();
                    }
                    break;
                case "Soluong":
                    if (("" + gvbar_Table_Order.GetFocusedRowCellValue(gvbar_Table_Order.Columns["Served"]) == "True"
                                  && dr_change.RowState != DataRowState.Added))
                        dr_change.RejectChanges();
                    else
                    {
                        //if (!current_id_nhansu.Equals("" + gvbar_Table_Order.GetFocusedRowCellValue("Id_Nhansu_Order")))
                        //{
                        //    lblWarning.Text = "Bạn không thể chỉnh sửa món ăn này. Món ăn này do nhân viên khác order";
                        //    return;
                        //}
                        object SL_PV = dr_change["Soluong_Phucvu"];
                        object Soluong = dr_change["Soluong"];
                        if (Soluong.ToString().Contains("-"))
                        {
                            lblWarning.Text = "Số lượng không được nhập số âm";
                            return;
                        }
                        if (Soluong.ToString().Length >= 6)
                        {
                            lblWarning.Text = "Số lượng nhập không chính xác";
                            dr_change["Soluong"] = 1;
                            return;
                        }
                        if (Convert.ToInt32("0" + Soluong) == 0)
                        {
                            lblWarning.Text = "Số lượng phải lớn hơn 0";
                            if (dr_change.RowState == DataRowState.Added)
                            {
                                dr_change["Soluong"] = 1;
                                return;
                            }
                            else
                            {
                                dr_change.RejectChanges();
                                return;
                            }
                        }
                        if (Convert.ToInt32("0" + SL_PV) == 0)
                            return;
                        if (Convert.ToInt32("0" + SL_PV) > Convert.ToInt32("0" + Soluong))
                        {
                            lblWarning.Text = "Số lượng không được dưới số lượng đã phục vụ: " + SL_PV;
                            dr_change.RejectChanges();
                        }
                        else if (Convert.ToInt32("0" + SL_PV) == Convert.ToInt32("0" + Soluong))
                            dr_change["Served"] = true;
                        dr_change["Thanhtien"] = Convert.ToDecimal("0" + dr_change["Dongia"]) * Convert.ToDecimal(Soluong)
                           * (1 - Convert.ToDecimal("0" + dr_change["Per_Dongia"]) / 100);
                    }
                    break;
                case "Served":
                    if (!current_id_nhansu.Equals("" + gvbar_Table_Order.GetFocusedRowCellValue("Id_Nhansu_Order")))
                    {
                        lblWarning.Text = "Bạn không thể chỉnh sửa món ăn này. Món ăn này do nhân viên khác order";
                        dr_change.RejectChanges();
                        return;
                    }
                    if (!Convert.ToBoolean(dr_change["Served"]) && dr_change.RowState != DataRowState.Added)
                    {
                        dr_change.RejectChanges();
                        //lblWarning.Text = "Món ăn đã được phục vụ";
                        //break;
                    }
                    if ("" + dr_change["Served"] == "" || !Convert.ToBoolean(dr_change["Served"]))
                    {
                        gvbar_Table_Order.RefreshRow(e.RowHandle);
                        if (dtr_In_Db != null)
                            dr_change["Soluong_Phucvu"] = dtr_In_Db[0]["Soluong_Phucvu"];
                    }
                    else
                    {
                        dr_change["Soluong_Phucvu"] = dr_change["Soluong"];
                        dr_change["Thanhtien"] = Convert.ToDecimal("0" + dr_change["Dongia"]) * Convert.ToDecimal("0" + dr_change["Soluong"])
                           * (1 - Convert.ToDecimal("0" + dr_change["Per_Dongia"]) / 100);
                        //Recal_Dongia();  //hiển thị quota sai => thuynguyen dời xuống sự kiện in hóa đơn tạm
                    }
                    break;
            }
            try
            {
                if ("" + dr_change["Served"] != "" && Convert.ToBoolean(dr_change["Served"]))
                {
                    ///tinh lai thanh tien
                    dr_change["Thanhtien"] = Convert.ToDecimal(dr_change["Soluong"]) * Convert.ToDecimal("0" + dr_change["Dongia"])
                                    * (1 - Convert.ToDecimal("0" + dr_change["Per_Dongia"]) / 100);
                    //if ("" + dr_change["Per_Dongia"] != "")
                    //    dr_change["Thanhtien_Km"] = Convert.ToDecimal(dr_change["Per_Dongia"]) * (Convert.ToDecimal(dr_change["Soluong"]) * Convert.ToDecimal("0" + dr_change["Dongia"])) / 100;
                }
                else
                {
                    dr_change["Thanhtien"] = DBNull.Value;
                }
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        private void gvbar_Table_Order_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "Served":
                    gvbar_Table_Order.SetFocusedRowCellValue(e.Column.FieldName, e.Value);
                    break;
            }
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            this.PerformEdit();
        }

    }
}
