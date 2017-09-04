using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using System.IO;

namespace Ecm.Bar.Forms
{
    public partial class Frmbar_Table_Booking : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        Ecm.WebReferences.Classes.BarService objBarService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.BarService>();
        Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();


        DataSet dsTable_Order = new DataSet();
        DataSet dsTable_Booking_Chitiet = new DataSet();
        DataSet dsTable_Booking = new DataSet();
        DataSet dsTable_Order_Chitiet_Log = new DataSet();
        DataSet dsMenu_Hanghoa_Ban;
        DataSet dsNhom_Hanghoa_Ban;
        DataSet ds_Hanghoa_Ban = null;
        DataSet dsNhansu_Booking;
        DataSet dsBar_Dm_Menu;
        DataSet ds_Donvitinh;
        System.Collections.Hashtable Images = new System.Collections.Hashtable();
        public DataRow[] drs_Hanghoa;
        object SelectedId_Table_Booking;
        object Id_Nhom_Hanghoa_Ban;
        string Status_Booking;
        int Current_gridview1_focused;

        #region local data

        DataSet dsSys_Lognotify = null;
        string xml_WARE_DM_HANGHOA_BAN = @"Resources\localdata\Ware_Dm_Hanghoa_Ban.xml";
        string xml_REX_NHANSU = @"Resources\localdata\Rex_Nhansu.xml";
        string xml_WARE_DM_DONVITINH = @"Resources\localdata\Ware_Dm_Donvitinh.xml";
        string xml_WARE_DM_LOAI_HANGHOA_BAN = @"Resources\localdata\WARE_DM_LOAI_HANGHOA_BAN_BYLOCATION.xml";
        string xml_BAR_DM_MENU_HANGHOA_BAN = @"Resources\localdata\BAR_DM_MENU_HANGHOA_BAN.xml";
        string xml_BAR_DM_MENU = @"Resources\localdata\BAR_DM_MENU.xml";
        string xml_WARE_DM_HANGHOA_BAN_IN_MENU = @"Resources\localdata\WARE_DM_HANGHOA_BAN_INMENU.xml";

        DateTime dtlc_rex_nhansu;
        DateTime dtlc_ware_dm_donvitinh;        
        DateTime dtlc_ware_dm_loai_hanghoa_by_location;
        DateTime dtlc_ware_dm_hanghoa_ban;
        DateTime dtlc_bar_dm_menu;
        DateTime dtlc_ware_dm_hanghoa_in_menu;

        #endregion

        public Frmbar_Table_Booking()
        {
            InitializeComponent();
            dtNgay_Nhan_Booking.Properties.MinValue = DateTime.Today;
            dtNgay_Den.Properties.MinValue = DateTime.Today;
            dtNgay_Xacnhan.Properties.MinValue = DateTime.Today;
            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");

            xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            BarSystem.Visible = false;
            splitContainer.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1;
            this.idCardLogonControl1.Form = this;
            ShowLogonForm();
            #region Gán quyền thao tác trên form
            //btnThemmoi.Enabled = EnableAdd;
            //btnSua_Booking.Enabled = EnableEdit;
            //btnDelete.Enabled = EnableDelete;
            //btnpic_PrintBooking.Enabled = EnablePrintPreview;
            #endregion

        }

        void ShowTabPage(DevExpress.XtraTab.XtraTabControl xtraTabControl,
                         DevExpress.XtraTab.XtraTabPage xtraTabPage)
        {
            while (xtraTabControl.TabPages.Count > 0)
                xtraTabControl.TabPages.RemoveAt(0);
            xtraTabControl.TabPages.Add(xtraTabPage);
            if (FormState == GoobizFrame.Windows.Forms.FormState.Edit && xtraTabPage == xtraTabPage_Info)
                gridView1.FocusedRowHandle = Current_gridview1_focused;
        }

        void Filter_Dm_Menu_Hanghoa_Ban()
        {
            gridView_Dm_Menu_Hanghoa_Ban.ClearColumnsFilter();
            gridView_Dm_Menu_Hanghoa_Ban.Columns["Ma_Hanghoa_Ban"].FilterInfo
                    = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(" Ma_Hanghoa_Ban like '" +
                   txtMa_Hanghoa_Ban.EditValue + "%'");
            gridView_Dm_Menu_Hanghoa_Ban.Columns["Id_Menu"].Visible = true;
            gridView_Dm_Menu_Hanghoa_Ban.Columns["Id_Menu"].VisibleIndex = 0;
        }

        /// <summary>
        /// sau khi logon thanh cong
        /// </summary>
        private void idCardLogonControl1_AfterLogon()
        {
            GoobizFrame.Windows.PlugIn.RightHelpers.CheckUserRightAction(this);
            splitContainer.Panel1.Enabled = true;
            panel_Details.Visible = true;
            panel_Details.Dock = DockStyle.Fill;
            ShowTabPage(xtraTabControl1, xtraTabPage_Info);
            panelControl4.Visible = true;
            splitContainer.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both;
            DisplayInfo();
        }

        #region Event Override
        public object InsertObject()
        {
            Ecm.WebReferences.BarService.Bar_Table_Booking bar_table_booking = new Ecm.WebReferences.BarService.Bar_Table_Booking();
            bar_table_booking.Id_Booking = -1;
            bar_table_booking.Ma_Booking = txtMa_Booking.EditValue;
            bar_table_booking.Ngay_Den = dtNgay_Den.EditValue;
            bar_table_booking.Ngay_Xacnhan = (dtNgay_Xacnhan.Text == "") ? null : dtNgay_Xacnhan.EditValue;
            bar_table_booking.Ngay_Nhan_Booking = dtNgay_Nhan_Booking.EditValue;
            bar_table_booking.NhanSu_Booking = lookUpEdit_Nhansu_Booking.EditValue;
            bar_table_booking.Ten_Khachhang_Booking = txtTeN_Khachhang_Booking.EditValue;
            if ("" + txtTien_Booking.EditValue != "")
                bar_table_booking.Tien_Booking = txtTien_Booking.EditValue;
            else
                bar_table_booking.Tien_Booking = 0;
            bar_table_booking.GhiChu = (txtGhichu.Text == "") ? null : txtGhichu.EditValue;
            object identity = objBarService.Insert_Bar_Table_Booking(bar_table_booking);

            if (identity != null)
            {
                for (int i = 0; i < dsTable_Booking_Chitiet.Tables[0].Rows.Count; i++)
                {
                    dsTable_Booking_Chitiet.Tables[0].Rows[i]["Id_Booking"] = identity;
                }
                dgbar_Table_Booking.EmbeddedNavigator.Buttons.DoClick(dgbar_Table_Booking.EmbeddedNavigator.Buttons.EndEdit);
                objBarService.Update_Bar_Table_Booking_Chitiet_Collection(dsTable_Booking_Chitiet);
            }
            //objBarService.WriteLogNotification(string.Format("{0}-{1}-{2}-{3}\r\n", new object[] { DateTime.Now, identity, bar_Table_Order.Id_Nhansu_Order, "Ins" }));
            return true;
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.BarService.Bar_Table_Booking bar_table_booking = new Ecm.WebReferences.BarService.Bar_Table_Booking();
            bar_table_booking.Id_Booking = SelectedId_Table_Booking;
            bar_table_booking.Ma_Booking = txtMa_Booking.EditValue;
            bar_table_booking.Ngay_Den = dtNgay_Den.EditValue;
            bar_table_booking.Ngay_Xacnhan = (dtNgay_Xacnhan.Text == "") ? null : dtNgay_Xacnhan.EditValue;
            bar_table_booking.Ngay_Nhan_Booking = dtNgay_Nhan_Booking.EditValue;
            bar_table_booking.NhanSu_Booking = "" + lookUpEdit_Nhansu_Booking.EditValue;
            bar_table_booking.Ten_Khachhang_Booking = txtTeN_Khachhang_Booking.EditValue;
            if ("" + txtTien_Booking.EditValue != "")
                bar_table_booking.Tien_Booking = txtTien_Booking.EditValue;
            else
                bar_table_booking.Tien_Booking = 0;
            bar_table_booking.GhiChu = (txtGhichu.Text == "")? null : txtGhichu.EditValue;
            objBarService.Update_Bar_Table_Booking(bar_table_booking);

            dgbar_Table_Booking.EmbeddedNavigator.Buttons.DoClick(dgbar_Table_Booking.EmbeddedNavigator.Buttons.EndEdit);
            foreach (DataRow dr in dsTable_Booking_Chitiet.Tables[0].Rows)
            {
                if (dr.RowState == DataRowState.Added)
                    dr["Id_Booking"] = SelectedId_Table_Booking;
            }
            if (dsTable_Booking_Chitiet.HasChanges())
            {
                objBarService.Update_Bar_Table_Booking_Chitiet_Collection(dsTable_Booking_Chitiet);
                dsTable_Booking_Chitiet.AcceptChanges();
            }
            return true;
        }

        public object DeleteObject()
        {
            if ("" + SelectedId_Table_Booking != "")
                return objBarService.Delete_Bar_Table_Booking(SelectedId_Table_Booking);
            else
                return null;
        }

        public override bool PerformAdd()
        {
            lblStatus_Bar.Text = "";
            this.ResetText();
            txtMa_Booking.Text = "" + objWareService.GetNew_Sochungtu("bar_table_booking", "Ma_Booking", "BKG");
            dtNgay_Nhan_Booking.EditValue = objBarService.GetServerDateTime();
            lookUpEdit_Nhansu_Booking.EditValue = Convert.ToInt64(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
            ChangeFormState(GoobizFrame.Windows.Forms.FormState.Add);
            txtTeN_Khachhang_Booking.Focus();
            this.ChangeStatus(true);
            ClearDataBindings();
            return true;
        }

        public override bool PerformEdit()
        {
            if (gridView1.GetFocusedRowCellValue("NhanSu_Booking") == null)
                return false;
            lblStatus_Bar.Text = "";
            if (!GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals(gridView1.GetFocusedRowCellValue("NhanSu_Booking").ToString()))
            {
                lblStatus_Bar.Text = "Bạn không thể chỉnh sửa Booking này";
                return false;
            }
            if ("" + SelectedId_Table_Booking == "")
            {
                lblStatus_Bar.Text = "Vui lòng chọn Booking";
                return false;
            }
            if (Status_Booking == "True")
            {
                lblStatus_Bar.Text = "Booking này đã kết thúc, không được chỉnh sửa";
                return false;
            }
            DataRow[] dtr = objBarService.Get_All_Bar_Table_Order(null, null).ToDataSet().Tables[0].Select("Id_Booking = " + SelectedId_Table_Booking);
            if (dtr.Length > 0)
            {
                lblStatus_Bar.Text = "Booking này đã được sử dụng, không được chỉnh sửa";
                return false;
            }
            //kiểm tra: nếu đã qua ngày xác nhận (khoảng thời gian cho phép khách hàng thay đổi) => không cho sửa            
            if ("" + dtNgay_Xacnhan.EditValue != "")   /*dành cho những booking không có ngày xác nhận*/
                if (Convert.ToDateTime(dtNgay_Xacnhan.EditValue).CompareTo(DateTime.Today) < 0)
                {
                    lblStatus_Bar.Text = "Booking này đã xác nhận, không được chỉnh sửa";
                    return false;
                }
            Current_gridview1_focused = gridView1.FocusedRowHandle;
            this.ChangeFormState(GoobizFrame.Windows.Forms.FormState.Edit);
            this.ChangeStatus(true);
            return true;
        }

        public override bool PerformCancel()
        {
            this.ChangeFormState(GoobizFrame.Windows.Forms.FormState.View);
            this.DisplayInfo();
            return true;
        }

        public override bool PerformSave()
        {
            try
            {
                lblStatus_Bar.Text = "";
                bool success = false;

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Nhan_Booking, dtNgay_Den, lblNgay_Nhan_Booking.Text, lblNgay_Den.Text))
                    return false;
                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Nhan_Booking, dtNgay_Xacnhan, lblNgay_Nhan_Booking.Text, lblNgay_Xacnhan.Text))
                    return false;
                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Xacnhan, dtNgay_Den, lblNgay_Xacnhan.Text, lblNgay_Den.Text))
                    return false;
                System.Collections.Hashtable htb_Null = new System.Collections.Hashtable();
                //  htb_Null.Add(txtTien_Booking, lblTien_Booking.Text);
                htb_Null.Add(txtTeN_Khachhang_Booking, lblTen_Khachhang_Booking.Text);
                htb_Null.Add(dtNgay_Den, lblNgay_Den.Text);
                //htb_Null.Add(dtNgay_Xacnhan, lblNgay_Xacnhan.Text);
                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(htb_Null))
                    return false;
                if (gridView2.RowCount == 0)
                {
                    lblStatus_Bar.Text = "Chưa chọn món, xin vui lòng chọn món";
                    return false;
                }

                //if (!checkTien_Boooking())
                //{
                //    GoobizFrame.Windows.Forms.MessageDialog.Show("Tiền booking nhập không đúng, vui lòng nhập lại");
                //    txtTien_Booking.Focus();
                //    return false;
                //}

                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                {
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    success = (bool)this.UpdateObject();
                }
                if (success)
                {
                    PerformPrintPreview();
                    this.FormState = GoobizFrame.Windows.Forms.FormState.View;
                    this.DisplayInfo();
                    timer1.Enabled = true;
                    ShowTabPage(xtraTabControl1, xtraTabPage_Info);
                }
                return success;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.ToString());
                //GoobizFrame.Windows.Forms.MessageDialog.Show("Không thể sửa thông tin booking này");
                return false;
            }
        }

        public override bool PerformDelete()
        {
            bool success = false;
            //if (GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUser().ToUpper() == "ADMIN")
            //if (!GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + lookUpEdit_Nhansu_Order.EditValue))
            //{
            //    GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
            //    return false;
            //}
            //try
            //{
            //    GoobizFrame.Windows.Forms.UserMessage.Show("ORDER_SERVED", new string[] { });
            //    DisplayInfo();
            //    changeStatusButton(false);
            //}
            //catch { }
            //kiểm tra: nếu đã qua ngày xác nhận (khoảng thời gian cho phép khách hàng thay đổi) => không cho xóa
            if ("" + dtNgay_Xacnhan.EditValue != "")  /*dành cho những booking không có ngày xác nhận*/
                if (Convert.ToDateTime(dtNgay_Xacnhan.EditValue).CompareTo(DateTime.Today) < 0)
                {
                    lblStatus_Bar.Text = "Booking này đã xác nhận, không được hủy";
                    return false;
                }
            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
            GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Bar_Table_Booking"),
            GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Bar_Table_Booking")   }) == DialogResult.Yes)
            {
                try
                {
                    success = (bool)this.DeleteObject();
                }
                catch (Exception ex)
                {
                    //GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                    lblStatus_Bar.Text = "Không thể xóa thông tin  booking này";
                }
                if (success)
                {
                    this.ChangeFormState(GoobizFrame.Windows.Forms.FormState.View);
                    this.DisplayInfo();
                    timer1.Enabled = true;
                    ShowTabPage(xtraTabControl1, xtraTabPage_Info);
                }
            }
            return success;
        }

        public override bool PerformPrintPreview()
        {
            lblStatus_Bar.Text = "";
            if (dsTable_Booking_Chitiet == null || dsTable_Booking_Chitiet.Tables.Count == 0) return false;
            if (dsTable_Booking_Chitiet.Tables[0].Rows.Count == 0) return false;

            Ecm.Bar.DataSets.dsHd_Booking_Chitiet dsHd_Booking_Chitiet = new Ecm.Bar.DataSets.dsHd_Booking_Chitiet();
            int i = 1;
            foreach (DataRow dr in dsTable_Booking_Chitiet.Tables[0].Rows)
            {
                DataRow drnew = dsHd_Booking_Chitiet.Tables[0].NewRow();
                drnew["Ten_Hanghoa"] = gridLookUp_Hanghoa_Ban.GetDisplayText(dr["Id_Hanghoa_Ban"]);
                drnew["Soluong"] = dr["Soluong"];
                drnew["Stt"] = i++;
                dsHd_Booking_Chitiet.Tables[0].Rows.Add(drnew);
            }
            Ecm.Bar.Reports.rptHd_Booking rptHd_Booking = new Ecm.Bar.Reports.rptHd_Booking();
            GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            frmPrintPreview.Report = rptHd_Booking;
            rptHd_Booking.DataSource = dsHd_Booking_Chitiet;
            //frmPrintPreview.Name = this.Name;
            //frmPrintPreview.EnablePrintPreview = this.EnablePrintPreview;
            //add parameter values           
            rptHd_Booking.lblSoHD.Text = "" + txtMa_Booking.EditValue;
            rptHd_Booking.tbcNgay_Booking.Text = "" + dtNgay_Nhan_Booking.Text;
            rptHd_Booking.tbcNgayden.Text = "" + dtNgay_Den.Text;
            rptHd_Booking.lblNhanvien_Booking.Text = lookUpEdit_Nhansu_Booking.Text;
            rptHd_Booking.lblKhachhang.Text = txtTeN_Khachhang_Booking.Text;
            if ("" + txtTien_Booking.EditValue != "")
                rptHd_Booking.lblTien_Booking.Text = String.Format("{0:#,#}", txtTien_Booking.EditValue);
            else
                rptHd_Booking.lblTien_Booking.Text = "0";

            double thanhtien = Convert.ToDouble("0" + txtTien_Booking.EditValue);
            string str = GoobizFrame.Windows.HelperClasses.ReadNumber.ChangeNum2VNStr(thanhtien, " đồng.");
            str = str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower();

            rptHd_Booking.tbcThanhtien_Bangchu.Text = str;
            rptHd_Booking.PageSize = new Size(800, 1400 + 100 * Convert.ToInt32(dsHd_Booking_Chitiet.Tables[0].Rows.Count));

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

                rptHd_Booking.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                rptHd_Booking.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                rptHd_Booking.xrPic_Logo.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }
            #endregion
            rptHd_Booking.CreateDocument();
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(rptHd_Booking);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                //frmPrintPreview.Text = "" + oReportOptions.Caption;
                frmPrintPreview.Text = "Biên nhận Đặt Bàn";
                frmPrintPreview.printControl1.PrintingSystem = rptHd_Booking.PrintingSystem;
                frmPrintPreview.MdiParent = this.MdiParent;
                frmPrintPreview.Show();
                frmPrintPreview.Activate();
            }
            else
            {
                var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rptHd_Booking);
                ReportPrintTool.Print();
            }
            return base.PerformPrintPreview();
        }

        #endregion

        #region master view

        /// <summary>
        /// Truy xuat DateTime thay doi du lieu cuoi cung
        /// </summary>
        /// <param name="table_name"></param>
        /// <returns></returns>
        private DateTime GetLastChange_FrmLognotify(string table_name)
        {
            try
            {
                return Convert.ToDateTime(dsSys_Lognotify.Tables[0].Select(string.Format("Table_Name='{0}'", table_name))[0]["Last_Change"]);
            }
            catch (Exception ex)
            {
                return new DateTime(2010, 01, 01);
            }
        }

        void LoadMasterTable()
        {
            #region code old, not use
            /*
            string vlog_WARE_DM_HANGHOA_BAN = log_WARE_DM_HANGHOA_BAN;
            string vlog_WARE_HANGHOA_DINHGIA = log_WARE_HANGHOA_DINHGIA;
            string vlog_REX_NHANSU = log_REX_NHANSU;
            string vlog_CTRINH_KMAI_CHITIET = log_CTRINH_KMAI_CHITIET;
            string vlog_WARE_DM_KHACHHANG = log_WARE_DM_KHACHHANG;
            string vlog_BAR_DM_MENU = log_BAR_DM_MENU;
            string vlog_BAR_DM_MENU_HANGHOA_BAN = log_BAR_DM_MENU_HANGHOA_BAN;
            Exists_Sys_Lognotify_Path = System.IO.File.Exists(Sys_Lognotify_Path);

            if (Exists_Sys_Lognotify_Path)
            {
                #region Exists_Sys_Lognotify_Path
                //get last change at local
                dsSys_Lognotify = new DataSet();
                dsSys_Lognotify.ReadXml(Sys_Lognotify_Path);

                //write new log change from database --> write to local last change
                dsSys_Lognotify_db = objMasterService.GetAll_Sys_Lognotify();
                bool haschange_atlast = false;
                string table_changed = "";
                foreach (DataRow dr in dsSys_Lognotify_db.Tables[0].Rows)
                {
                    DataRow[] sdr = dsSys_Lognotify.Tables[0].Select("Table_Name = '" + dr["table_name"] + "'");
                    if (sdr == null || sdr.Length == 0)
                        haschange_atlast = true;
                    else if ("" + sdr[0]["Last_Change"] != "" + dr["Last_Change"])
                    {
                        haschange_atlast = true;
                        table_changed = "" + dr["table_name"];
                    }

                    if (haschange_atlast) break;
                }

                if (haschange_atlast)
                {
                    dsSys_Lognotify_db.WriteXml(Sys_Lognotify_Path, XmlWriteMode.WriteSchema);

                    log_WARE_DM_HANGHOA_BAN = (dsSys_Lognotify.Tables[0].Select("Table_Name='Ware_Dm_Hanghoa_Ban'").Length > 0)
                    ? "" + dsSys_Lognotify.Tables[0].Select("Table_Name='Ware_Dm_Hanghoa_Ban'")[0]["Last_Change"] : "";
                    log_WARE_HANGHOA_DINHGIA = (dsSys_Lognotify.Tables[0].Select("Table_Name='Ware_Hanghoa_Dinhgia'").Length > 0)
                        ? "" + dsSys_Lognotify.Tables[0].Select("Table_Name='Ware_Hanghoa_Dinhgia'")[0]["Last_Change"] : "";
                    log_REX_NHANSU = (dsSys_Lognotify.Tables[0].Select("Table_Name='REX_NHANSU'").Length > 0)
                        ? "" + dsSys_Lognotify.Tables[0].Select("Table_Name='REX_NHANSU'")[0]["Last_Change"] : "";
                    log_CTRINH_KMAI_CHITIET = (dsSys_Lognotify.Tables[0].Select("Table_Name='WARE_CTRINH_KMAI'").Length > 0)
                        ? "" + dsSys_Lognotify.Tables[0].Select("Table_Name='WARE_CTRINH_KMAI'")[0]["Last_Change"] : "";
                    log_WARE_DM_KHACHHANG = (dsSys_Lognotify.Tables[0].Select("Table_Name='WARE_DM_KHACHHANG'").Length > 0)
                        ? "" + dsSys_Lognotify.Tables[0].Select("Table_Name='WARE_DM_KHACHHANG'")[0]["Last_Change"] : "";
                    log_BAR_DM_MENU = (dsSys_Lognotify.Tables[0].Select("Table_Name='BAR_DM_MENU'").Length > 0)
                        ? "" + dsSys_Lognotify.Tables[0].Select("Table_Name='BAR_DM_MENU'")[0]["Last_Change"] : "";
                    log_BAR_DM_MENU_HANGHOA_BAN = (dsSys_Lognotify.Tables[0].Select("Table_Name='Bar_Dm_Menu_Hanghoa_Ban'").Length > 0)
                        ? "" + dsSys_Lognotify.Tables[0].Select("Table_Name='Bar_Dm_Menu_Hanghoa_Ban'")[0]["Last_Change"] : "";
                    log_BAR_TABLE_ORDER_CHITIET = (dsSys_Lognotify.Tables[0].Select("Table_Name='bar_table_order_chitiet'").Length > 0)
                        ? "" + dsSys_Lognotify.Tables[0].Select("Table_Name='bar_table_order_chitiet'")[0]["Last_Change"] : "";
                    vlog_WARE_DM_HANGHOA_BAN = (dsSys_Lognotify_db.Tables[0].Select("Table_Name='Ware_Dm_Hanghoa_Ban'").Length > 0)
                        ? "" + dsSys_Lognotify_db.Tables[0].Select("Table_Name='Ware_Dm_Hanghoa_Ban'")[0]["Last_Change"] : "";
                    vlog_WARE_HANGHOA_DINHGIA = (dsSys_Lognotify_db.Tables[0].Select("Table_Name='Ware_Hanghoa_Dinhgia'").Length > 0)
                        ? "" + dsSys_Lognotify_db.Tables[0].Select("Table_Name='Ware_Hanghoa_Dinhgia'")[0]["Last_Change"] : "";
                    vlog_REX_NHANSU = (dsSys_Lognotify_db.Tables[0].Select("Table_Name='REX_NHANSU'").Length > 0)
                        ? "" + dsSys_Lognotify_db.Tables[0].Select("Table_Name='REX_NHANSU'")[0]["Last_Change"] : "";
                    vlog_CTRINH_KMAI_CHITIET = (dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_CTRINH_KMAI'").Length > 0)
                        ? "" + dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_CTRINH_KMAI'")[0]["Last_Change"] : "";
                    vlog_WARE_DM_KHACHHANG = (dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_DM_KHACHHANG'").Length > 0)
                        ? "" + dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_DM_KHACHHANG'")[0]["Last_Change"] : "";
                    vlog_BAR_DM_MENU = (dsSys_Lognotify_db.Tables[0].Select("Table_Name='BAR_DM_MENU'").Length > 0)
                        ? "" + dsSys_Lognotify_db.Tables[0].Select("Table_Name='BAR_DM_MENU'")[0]["Last_Change"] : "";
                    vlog_BAR_DM_MENU_HANGHOA_BAN = (dsSys_Lognotify_db.Tables[0].Select("Table_Name='Bar_Dm_Menu_Hanghoa_Ban'").Length > 0)
                        ? "" + dsSys_Lognotify_db.Tables[0].Select("Table_Name='Bar_Dm_Menu_Hanghoa_Ban'")[0]["Last_Change"] : "";
                    vlog_BAR_TABLE_ORDER_CHITIET = (dsSys_Lognotify_db.Tables[0].Select("Table_Name='bar_table_order_chitiet'").Length > 0)
                        ? "" + dsSys_Lognotify_db.Tables[0].Select("Table_Name='bar_table_order_chitiet'")[0]["Last_Change"] : "";

                }
                #endregion
            }
            else
            {
                #region ! Exists_Sys_Lognotify_Path
                //load last change
                dsSys_Lognotify = objMasterService.GetAll_Sys_Lognotify();
                dsSys_Lognotify.AcceptChanges();
                dsSys_Lognotify.WriteXml(Sys_Lognotify_Path, XmlWriteMode.WriteSchema);
                #endregion
            }
            */
            #endregion

            /*
             //load data from local xml when last change at local differ from database
            dsSys_Lognotify = objMasterService.Get_Sys_Lognotify_SelectLastChange_OfTables("[ware_hanghoa_dinhgia], [ware_dm_hanghoa_ban], "
                  + "[ware_dm_donvitinh], [rex_nhansu], [bar_dm_menu], [ware_dm_loai_hanghoa_ban], [Bar_Dm_Menu_Hanghoa_Ban]").ToDataSet();
            dtlc_ware_dm_hanghoa_ban = GetLastChange_FrmLognotify("WARE_DM_HANGHOA_BAN");
            dtlc_rex_nhansu = GetLastChange_FrmLognotify("REX_NHANSU");
            dtlc_ware_dm_donvitinh = GetLastChange_FrmLognotify("WARE_DM_DONVITINH");
            //dtlc_ware_dm_khachhang          = GetLastChange_FrmLognotify("WARE_DM_KHACHHANG");
            dtlc_ware_dm_loai_hanghoa_by_location = GetLastChange_FrmLognotify("WARE_DM_LOAI_HANGHOA_BAN");
            dtlc_bar_dm_menu = GetLastChange_FrmLognotify("BAR_DM_MENU");
            dtlc_ware_dm_hanghoa_in_menu = GetLastChange_FrmLognotify("BAR_DM_MENU_HANGHOA_BAN");
              //load data from local xml when last change at local differ from database
            if (DateTime.Compare(dtlc_ware_dm_hanghoa_ban, System.IO.File.GetLastWriteTime(xml_WARE_DM_HANGHOA_BAN)) > 0
                || !System.IO.File.Exists(xml_WARE_DM_HANGHOA_BAN))
            {
                ds_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
                ds_Hanghoa_Ban.WriteXml(xml_WARE_DM_HANGHOA_BAN, XmlWriteMode.WriteSchema);
            }
            else if (ds_Hanghoa_Ban == null || ds_Hanghoa_Ban.Tables.Count == 0)
            {
                ds_Hanghoa_Ban = new DataSet();
                ds_Hanghoa_Ban.ReadXml(xml_WARE_DM_HANGHOA_BAN);
            }
             if (DateTime.Compare(dtlc_rex_nhansu, System.IO.File.GetLastWriteTime(xml_REX_NHANSU)) > 0
                || !System.IO.File.Exists(xml_REX_NHANSU))
            {
                dsNhansu_Booking = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
                dsNhansu_Booking.WriteXml(xml_REX_NHANSU, XmlWriteMode.WriteSchema);
            }
            else if (dsNhansu_Booking == null || dsNhansu_Booking.Tables.Count == 0)
            {
                dsNhansu_Booking = new DataSet();
                dsNhansu_Booking.ReadXml(xml_REX_NHANSU);
            }
             
             if (DateTime.Compare(dtlc_bar_dm_menu, System.IO.File.GetLastWriteTime(xml_BAR_DM_MENU)) > 0
                || !System.IO.File.Exists(xml_BAR_DM_MENU))
            {
                dsBar_Dm_Menu = objMasterService.Get_Visible_Bar_Dm_Menu().ToDataSet();
                dsBar_Dm_Menu.WriteXml(xml_BAR_DM_MENU, XmlWriteMode.WriteSchema);
            }
            else if (dsBar_Dm_Menu == null || dsBar_Dm_Menu.Tables.Count == 0)
            {
                dsBar_Dm_Menu = new DataSet();
                dsBar_Dm_Menu.ReadXml(xml_BAR_DM_MENU);
            }
             if (DateTime.Compare(dtlc_ware_dm_hanghoa_in_menu, System.IO.File.GetLastWriteTime(xml_BAR_DM_MENU_HANGHOA_BAN)) > 0
                || !System.IO.File.Exists(xml_BAR_DM_MENU_HANGHOA_BAN))
            {
                dsMenu_Hanghoa_Ban = objMasterService.Get_Visible_Bar_Dm_Menu_Hanghoa_Ban_Collection().ToDataSet();
                dsMenu_Hanghoa_Ban.WriteXml(xml_BAR_DM_MENU_HANGHOA_BAN, XmlWriteMode.WriteSchema);
            }
            else if (dsMenu_Hanghoa_Ban == null || dsMenu_Hanghoa_Ban.Tables.Count == 0)
            {
                dsMenu_Hanghoa_Ban = new DataSet();
                dsMenu_Hanghoa_Ban.ReadXml(xml_BAR_DM_MENU_HANGHOA_BAN);
            }
             
             if (DateTime.Compare(dtlc_ware_dm_donvitinh, System.IO.File.GetLastWriteTime(xml_WARE_DM_DONVITINH)) > 0
                || !System.IO.File.Exists(xml_WARE_DM_DONVITINH))
            {
                ds_Donvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
                ds_Donvitinh.WriteXml(xml_WARE_DM_DONVITINH, XmlWriteMode.WriteSchema);
            }
            else if (ds_Donvitinh == null || ds_Donvitinh.Tables.Count == 0)
            {
                ds_Donvitinh = new DataSet();
                ds_Donvitinh.ReadXml(xml_WARE_DM_DONVITINH);
            }

             */
            LoadDm_Nhom_Hanghoa_Ban();

            ds_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
            dsNhansu_Booking = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
            dsBar_Dm_Menu = objMasterService.Get_Visible_Bar_Dm_Menu().ToDataSet();
            dsMenu_Hanghoa_Ban = objMasterService.Get_Visible_Bar_Dm_Menu_Hanghoa_Ban_Collection(null, null).ToDataSet();
            ds_Donvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();

            //dgbar_Dm_Menu
            this.dgbar_Dm_Menu.DataSource = dsBar_Dm_Menu.Tables[0];

            gridLookUp_Hanghoa_Ban_Menu.DataSource = ds_Hanghoa_Ban.Tables[0];
            gridLookUp_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];

            lookUpEdit_Nhansu_Booking.Properties.DataSource = dsNhansu_Booking.Tables[0];
            gridLookUp_Donvitinh.DataSource = ds_Donvitinh.Tables[0];
            gridLookUpEdit_Donvitinh.DataSource = ds_Donvitinh.Tables[0];
        }

        void LoadDm_Nhom_Hanghoa_Ban()
        {
            try
            {
                //dgCuahang_Ban.DataSource = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().Tables[0];              
                dsNhom_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Nhom_Hanghoa_Ban_ByBarMenu().ToDataSet();
                dgNhom_Hanghoa_Ban.DataSource = dsNhom_Hanghoa_Ban.Tables[0];
                dgNhom_Hanghoa_Ban.MainView = cardView_Nhom_Hanghoa_Ban;
                dgNhom_Hanghoa_Ban.Visible = true;
                int i = Convert.ToInt32(dsNhom_Hanghoa_Ban.Tables[0].Rows[0]["Id_Nhom_Hanghoa_Ban"]);
                foreach (DataRow drNhom_Hanghoa_Ban in dsNhom_Hanghoa_Ban.Tables[0].Rows)
                {
                    DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition = new DevExpress.XtraGrid.StyleFormatCondition();
                    styleFormatCondition.Appearance.BackColor = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetColor(Convert.ToInt32(drNhom_Hanghoa_Ban["Id_Nhom_Hanghoa_Ban"]) % i);
                    styleFormatCondition.Appearance.Options.UseBackColor = true;
                    styleFormatCondition.ApplyToRow = true;
                    styleFormatCondition.Column = this.cardView_bar_Dm_Menu.Columns["Id_Nhom_Hanghoa_Ban"];
                    styleFormatCondition.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
                    styleFormatCondition.Value1 = Convert.ToInt32(drNhom_Hanghoa_Ban["Id_Nhom_Hanghoa_Ban"]);
                    this.cardView_bar_Dm_Menu.FormatConditions.Add(styleFormatCondition);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void DisplayInfo()
        {
            try
            {
                this.txtMa_Booking.EditValue = null;
                this.dtNgay_Nhan_Booking.EditValue = null;
                this.lookUpEdit_Nhansu_Booking.EditValue = null;
                LoadMasterTable();
                lblStatus_Bar.Text = "";
                dgBooking.Enabled = true;
                int i = Convert.ToInt32(dsBar_Dm_Menu.Tables[0].Rows[0]["Id_Nhom_Hanghoa_Ban"]);
                if (cardView_bar_Dm_Menu.FormatConditions.Count < 4)
                    foreach (DataRow drNhom_Hanghoa_Ban in dsBar_Dm_Menu.Tables[0].Rows)
                    {
                        DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition = new DevExpress.XtraGrid.StyleFormatCondition();
                        styleFormatCondition.Appearance.BackColor = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetColor(Convert.ToInt32(drNhom_Hanghoa_Ban["Id_Nhom_Hanghoa_Ban"]) % i);
                        styleFormatCondition.Appearance.Options.UseBackColor = true;
                        styleFormatCondition.ApplyToRow = true;
                        styleFormatCondition.Column = this.cardView_bar_Dm_Menu.Columns["Id_Nhom_Hanghoa_Ban"];
                        styleFormatCondition.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
                        styleFormatCondition.Value1 = Convert.ToInt32(drNhom_Hanghoa_Ban["Id_Nhom_Hanghoa_Ban"]);
                        this.cardView_bar_Dm_Menu.FormatConditions.Add(styleFormatCondition);
                    }
                //this.dsMenu_Hanghoa_Ban = objMasterService.Get_Visible_Bar_Dm_Menu_Hanghoa_Ban_Collection();
                this.dgbar_Dm_Menu_Hanghoa_Ban.DataSource = dsMenu_Hanghoa_Ban;
                this.dgbar_Dm_Menu_Hanghoa_Ban.DataMember = dsMenu_Hanghoa_Ban.Tables[0].TableName;
                try
                {
                    this.dsTable_Booking = objBarService.Get_All_Bar_Table_Booking().ToDataSet();
                    this.dgBooking.DataSource = dsTable_Booking;
                    this.dgBooking.DataMember = dsTable_Booking.Tables[0].TableName;
                }
                catch (Exception ex)
                {
                    this.dgBooking.DataMember = dsTable_Booking.Tables[0].TableName;
                }
                if (gridView1.RowCount > 0)
                    SelectedId_Table_Booking = gridView1.GetFocusedRowCellValue("Id_Booking");
                if (gridView1.RowCount == 0)
                    this.ResetText();
                dgBooking.EmbeddedNavigator.Buttons.DoClick(dgBooking.EmbeddedNavigator.Buttons.EndEdit);
                this.DataBindingControl();
                this.ChangeStatus(false);
                DisplayInfo2();
            }
            catch (Exception ex)
            {
                splitContainer.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1;
                ShowTabPage(xtraTabControl1, xtraTabPage_Lock);
                lblMessage.Text = ex.Message;
            }
        }

        void DisplayInfo2()
        {
            try
            {
                if (btnCancel.Enabled || btnSave.Enabled) return;
                if ("" + SelectedId_Table_Booking == "")
                {
                    this.dgbar_Table_Booking.DataSource = null;
                    return;
                }
                this.dsTable_Booking_Chitiet = objBarService.GetAll_Bar_Table_Booking_Chitiet_By_Id_Booking(SelectedId_Table_Booking).ToDataSet();
                this.dgbar_Table_Booking.DataSource = dsTable_Booking_Chitiet;
                this.dgbar_Table_Booking.DataMember = dsTable_Booking_Chitiet.Tables[0].TableName;
                dgbar_Table_Booking.EmbeddedNavigator.Buttons.DoClick(dgbar_Table_Booking.EmbeddedNavigator.Buttons.EndEdit);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void ClearDataBindings()
        {
            this.txtMa_Booking.DataBindings.Clear();
            this.txtTeN_Khachhang_Booking.DataBindings.Clear();
            this.txtTien_Booking.DataBindings.Clear();
            this.dtNgay_Den.DataBindings.Clear();
            this.dtNgay_Nhan_Booking.DataBindings.Clear();
            this.dtNgay_Xacnhan.DataBindings.Clear();
            this.txtGhichu.DataBindings.Clear();
            this.lookUpEdit_Nhansu_Booking.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtMa_Booking.DataBindings.Add("EditValue", dsTable_Booking, dsTable_Booking.Tables[0].TableName + ".Ma_Booking");
                this.txtTeN_Khachhang_Booking.DataBindings.Add("EditValue", dsTable_Booking, dsTable_Booking.Tables[0].TableName + ".Ten_KhachHang_Booking");
                this.txtTien_Booking.DataBindings.Add("EditValue", dsTable_Booking, dsTable_Booking.Tables[0].TableName + ".Tien_Booking");
                this.dtNgay_Nhan_Booking.DataBindings.Add("EditValue", dsTable_Booking, dsTable_Booking.Tables[0].TableName + ".Ngay_Nhan_Booking");
                this.dtNgay_Den.DataBindings.Add("EditValue", dsTable_Booking, dsTable_Booking.Tables[0].TableName + ".Ngay_Den");
                this.dtNgay_Xacnhan.DataBindings.Add("EditValue", dsTable_Booking, dsTable_Booking.Tables[0].TableName + ".Ngay_Xacnhan");
                this.txtGhichu.DataBindings.Add("EditValue", dsTable_Booking, dsTable_Booking.Tables[0].TableName + ".Ghichu");
                this.lookUpEdit_Nhansu_Booking.DataBindings.Add("EditValue", dsTable_Booking, dsTable_Booking.Tables[0].TableName + ".NhanSu_Booking");
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }

        public override void ChangeStatus(bool editTable)
        {
            this.txtGhichu.Properties.ReadOnly = !editTable;
            //this.txtMa_Booking.Properties.ReadOnly = !editTable;
            this.txtMa_Hanghoa_Ban.Properties.ReadOnly = !editTable;
            this.txtTeN_Khachhang_Booking.Properties.ReadOnly = !editTable;
            this.txtTien_Booking.Properties.ReadOnly = !editTable;
            //this.lookUpEdit_Nhansu_Booking.Properties.ReadOnly = !editTable;
            this.dtNgay_Den.Properties.ReadOnly = !editTable;
            this.dtNgay_Xacnhan.Properties.ReadOnly = !editTable;
            btnSave.Enabled = editTable;
            btnCancel.Enabled = editTable;
            btnChoice.Enabled = editTable;
            btnClose.Enabled = !editTable;
            btnpic_Logon.Enabled = !editTable;
            btnThemmoi.Enabled = (!editTable) ? EnableAdd : false;
            btnSua_Booking.Enabled = (dsTable_Booking.Tables[0].Rows.Count > 0 && FormState == GoobizFrame.Windows.Forms.FormState.View) ? EnableEdit : false;
            btnDelete.Enabled = (dsTable_Booking.Tables[0].Rows.Count > 0 && FormState == GoobizFrame.Windows.Forms.FormState.View) ? EnableDelete : false;
            btnpic_PrintBooking.Enabled = (dsTable_Booking.Tables[0].Rows.Count > 0 && FormState == GoobizFrame.Windows.Forms.FormState.View) ? EnablePrintPreview : false;
            gridView2.OptionsBehavior.Editable = editTable;
            gridColumn78.Visible = editTable;
            this.gridButton_Soluong.Buttons[0].Visible = editTable;
            this.gridButton_Ghichu.Buttons[0].Visible = editTable;
        }

        public override void ResetText()
        {
            this.txtGhichu.EditValue = null;
            this.txtTien_Booking.EditValue = null;
            this.txtTeN_Khachhang_Booking.EditValue = null;
            this.dtNgay_Den.EditValue = null;
            this.dtNgay_Xacnhan.EditValue = null;
            this.dsTable_Booking_Chitiet = objBarService.GetAll_Bar_Table_Booking_Chitiet_By_Id_Booking(-1).ToDataSet();
            this.dgbar_Table_Booking.DataSource = dsTable_Booking_Chitiet.Tables[0];
        }

        #endregion

        #region detail view

        /// <summary>
        /// change value
        /// Per_Dongia
        /// Soluong
        /// Id_Hanghoa_Ban
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            lblStatus_Bar.Text = "";
            DataRow dr_change = gridView2.GetDataRow(e.RowHandle);
            if (dr_change == null) return;
            switch (e.Column.FieldName)
            {
                case "Id_Hanghoa_Ban":
                    if ("" + gridView2.GetFocusedRowCellValue(gridView2.Columns["Served"]) != "True")
                    {
                        dr_change["Id_Donvitinh"] =
                        ((System.Data.DataRowView)gridLookUp_Hanghoa_Ban.GetDataSourceRowByKeyValue(e.Value))["Id_Donvitinh"];
                        dr_change["Dongia"] =
                           ((System.Data.DataRowView)gridLookUp_Hanghoa_Ban.GetDataSourceRowByKeyValue(e.Value))["Dongia_Ban"];
                    }
                    else
                    {
                        dr_change.CancelEdit();
                    }
                    break;
                case "Soluong":
                    if ("" + gridView2.GetFocusedRowCellValue(gridView2.Columns["Served"]) == "True"
                        && dr_change.RowState != DataRowState.Added)
                    {
                        dr_change.RejectChanges();
                    }
                    else
                    {
                        object SL_PV = dr_change["Soluong_Phucvu"];
                        object Soluong = dr_change["Soluong"];
                        if (Convert.ToInt32("0" + Soluong) == 0)
                        {
                            lblStatus_Bar.Text = "Số lượng phải lớn hơn 0";
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
                            lblStatus_Bar.Text = "Số lượng không được dưới số lượng đã phục vụ: " + SL_PV;
                            dr_change.RejectChanges();
                        }
                        else if (Convert.ToInt32("0" + SL_PV) == Convert.ToInt32("0" + Soluong))
                            dr_change["Served"] = true;
                        dr_change["Thanhtien"] = Convert.ToDecimal(dr_change["Dongia"]) * Convert.ToDecimal(Soluong)
                           * (1 - Convert.ToDecimal("0" + dr_change["Per_Dongia"]) / 100);
                    }
                    break;
                case "Served":
                    if (!Convert.ToBoolean(dr_change["Served"]) && dr_change.RowState != DataRowState.Added)
                        dr_change.RejectChanges();
                    if ("" + dr_change["Served"] == "" || !Convert.ToBoolean(dr_change["Served"]))
                    {
                        gridView2.RefreshRow(e.RowHandle);
                        dr_change["Soluong_Phucvu"] = DBNull.Value;
                    }
                    else
                    {
                        dr_change["Soluong_Phucvu"] = dr_change["Soluong"];
                        dr_change["Thanhtien"] = Convert.ToDecimal(dr_change["Dongia"]) * Convert.ToDecimal(dr_change["Soluong"])
                           * (1 - Convert.ToDecimal("0" + dr_change["Per_Dongia"]) / 100);
                        //Recal_Dongia();  //hiển thị quota sai => thuynguyen dời xuống sự kiện in hóa đơn tạm
                    }
                    break;
            }
            try
            {
                if (Convert.ToBoolean(dr_change["Served"]))
                {
                    ///tinh lai thanh tien
                    dr_change["Thanhtien"] =
                        Convert.ToDecimal(dr_change["Soluong"])
                    * Convert.ToDecimal("0" + dr_change["Dongia"])
                    * (1 - Convert.ToDecimal("0" + dr_change["Per_Dongia"]) / 100);

                }
                else
                {
                    dr_change["Thanhtien"] = DBNull.Value;
                }
            }
            catch (Exception ex) { GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString()); }
        }


        #endregion

        #region Custom Button
        private void btnpic_PrintOrder_Click(object sender, EventArgs e)
        {
            bool success = false;
            {
                try
                {
                    success = (bool)this.UpdateObject();
                }
                catch (Exception ex)
                {
                    //GoobizFrame.Windows.Forms.MessageDialog.Show("Bàn chưa được lưu, không thể in hóa đơn tạm.Vui lòng lưu order");
                    return;
                }

                if (success)
                {
                    PerformPrintPreview();
                }
            }
        }


        private void simpleButton3_Click(object sender, EventArgs e)
        {
            dockPanel1.Visibility = (dockPanel1.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Visible)
                ? DevExpress.XtraBars.Docking.DockVisibility.Hidden
                : DevExpress.XtraBars.Docking.DockVisibility.Visible;
            dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Top;
        }

        private void btnMenu_3_Click(object sender, EventArgs e)
        {
            ShowMenuToOrder();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            PerformClose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            PerformCancel();
            ChangeFormState(GoobizFrame.Windows.Forms.FormState.View);
            timer1.Enabled = true;
        }

        #endregion

        #region Logon process

        void ShowLogonForm()
        {
            if (FormState == GoobizFrame.Windows.Forms.FormState.View)
            {
                //dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;    
                //panelControl_Logonbg.Visible = true;
                //panelControl_Logonbg.ContentImage = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetSplashBitmap();
                ShowTabPage(xtraTabControl1, xtraTabPage_Logon);
                panelLogon.Visible = true;
                panelControl4.Visible = false;
            }
            else
            {
                ShowTabPage(xtraTabControl1, xtraTabPage_Logon);
                panelControl4.Visible = true;
            }
        }

        #endregion

        #region Show Menu
        void ShowMenuToOrder()
        {
            //gridView_Dm_Menu_Hanghoa_Ban.Columns["Id_Menu"].Visible = false; btnMenu_2.Visible = false;
            dgbar_Dm_Menu.Visible = true;
            lblStatus_Bar.Text = "";
        }

        void HideMenuToShowListHH()
        {
            //ShowTabPage(xtraTabPage_Menu_Detail);
            gridView_Dm_Menu_Hanghoa_Ban.ApplyColumnsFilter();
            //gridView_Dm_Menu_Hanghoa_Ban.FocusedRowHandle = -1;
        }

        #endregion

        #region Event Handling
        private void btnChoice_Click(object sender, EventArgs e)
        {
            lblStatus_Bar.Text = "";
            ShowTabPage(xtraTabControl1, xtraTabPage_Menu);
            btnChoice.Enabled = false;
        }

        private void btDisplayInfo_Click(object sender, EventArgs e)
        {
            lblStatus_Bar.Text = "";
            ShowTabPage(xtraTabControl1, xtraTabPage_Info);
            btnChoice.Enabled = true;
        }

        private void cardView_bar_Dm_Menu_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cardView_bar_Dm_Menu.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                //ShowTabPage(xtraTabControl1, xtraTabPage_Menu_Detail);
                object id_Menu = cardView_bar_Dm_Menu.GetRowCellValue(cardHit.RowHandle, "Id_Menu"); 
                gridView_Dm_Menu_Hanghoa_Ban.Columns["Id_Menu"].FilterInfo =
                    new DevExpress.XtraGrid.Columns.ColumnFilterInfo(gridView_Dm_Menu_Hanghoa_Ban.Columns["Id_Menu"], id_Menu);
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            lblStatus_Bar.Text = "";
            ShowTabPage(xtraTabControl1, xtraTabPage_Menu);
        }

        private void btDisplayInfo2_Click(object sender, EventArgs e)
        {
            lblStatus_Bar.Text = "";
            ShowTabPage(xtraTabControl1, xtraTabPage_Info);
            btnChoice.Enabled = true;
        }

        private void btnBackMenu_Detail_Click(object sender, EventArgs e)
        {
            gridView_Dm_Menu_Hanghoa_Ban.MovePrevPage();
        }

        private void btnNextMenu_Detail_Click(object sender, EventArgs e)
        {
            gridView_Dm_Menu_Hanghoa_Ban.MoveNextPage();
        }

        private void gridView_Dm_Menu_Hanghoa_Ban_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo gridHit = gridView_Dm_Menu_Hanghoa_Ban.CalcHitInfo(e.X, e.Y);
            if (gridHit.InCard)
            {
                if (gridView_Dm_Menu_Hanghoa_Ban.FocusedRowHandle >= 0
                        && dsTable_Booking_Chitiet.Tables.Count > 0
                        && FormState != GoobizFrame.Windows.Forms.FormState.View)
                {
                    lblStatus_Bar.Text = "";
                    DataRow dtr;
                    bool check = false;
                    dgbar_Table_Booking.EmbeddedNavigator.Buttons.DoClick(dgbar_Table_Booking.EmbeddedNavigator.Buttons.EndEdit);
                    if ("" + gridView_Dm_Menu_Hanghoa_Ban.GetRowCellValue(gridHit.RowHandle, "Dongia") != "")
                    {
                        for (int i = 0; i < dsTable_Booking_Chitiet.Tables[0].Rows.Count; i++)
                        {
                            if (dsTable_Booking_Chitiet.Tables[0].Rows[i].RowState != DataRowState.Deleted)
                                if (dsTable_Booking_Chitiet.Tables[0].Rows[i]["Id_Hanghoa_Ban"].Equals(gridView_Dm_Menu_Hanghoa_Ban.GetRowCellValue(gridHit.RowHandle, "Id_Hanghoa_Ban"))
                                    && dsTable_Booking_Chitiet.Tables[0].Rows[i]["Id_Donvitinh"].Equals(gridView_Dm_Menu_Hanghoa_Ban.GetRowCellValue(gridHit.RowHandle, "Id_Donvitinh")))
                                {
                                    dtr = dsTable_Booking_Chitiet.Tables[0].Rows[i];
                                    dtr["Soluong"] = Convert.ToInt32(dsTable_Booking_Chitiet.Tables[0].Rows[i]["Soluong"]) + 1;
                                    gridView2.FocusedRowHandle = i;
                                    check = true;
                                }
                        }
                        if (!check)
                        {
                            dtr = dsTable_Booking_Chitiet.Tables[0].NewRow();
                            dtr["id_hanghoa_ban"] = gridView_Dm_Menu_Hanghoa_Ban.GetRowCellValue(gridHit.RowHandle, "Id_Hanghoa_Ban");
                            dtr["Soluong"] = 1;
                            dtr["Dongia"] = gridView_Dm_Menu_Hanghoa_Ban.GetRowCellValue(gridHit.RowHandle, "Dongia");
                            dtr["Id_Donvitinh"] = gridView_Dm_Menu_Hanghoa_Ban.GetRowCellValue(gridHit.RowHandle, "Id_Donvitinh");

                            dsTable_Booking_Chitiet.Tables[0].Rows.Add(dtr);
                        }
                    }
                    else
                        lblStatus_Bar.Text = string.Format("{0} chưa có giá bán", gridView_Dm_Menu_Hanghoa_Ban.GetRowCellDisplayText(gridHit.RowHandle, "Id_Hanghoa_Ban"));
                }
            }
        }

        private void grid_btnXoamon_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //if (MessageBox.Show("Bạn có chắc muốn xóa món này ra khỏi hóa đơn?", "Confirm Dialog", MessageBoxButtons.YesNo) == DialogResult.Yes)
            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[] { "Món " }) == DialogResult.Yes)
            {
                dsTable_Booking_Chitiet.Tables[0].Rows[gridView2.FocusedRowHandle].Delete();
                gridView2.MoveLastVisible();
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            PerformCancel();
            ChangeFormState(GoobizFrame.Windows.Forms.FormState.View);
            timer1.Enabled = true;
            ShowTabPage(xtraTabControl1, xtraTabPage_Info);
        }

        private void btnpic_Logon_Click(object sender, EventArgs e)
        {
            splitContainer.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1;
            ShowLogonForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //if (panelLogon.Visible) return;
            if (SelectedId_Table_Booking == null)
            {
                lblStatus_Bar.Text = "Chưa có booking nào được chọn, vui lòng chọn lại booking để xóa";
                return;
            }
            DataRow[] dtr = objBarService.Get_All_Bar_Table_Order(null, null).ToDataSet().Tables[0].Select("Id_Booking = " + SelectedId_Table_Booking);
            if (dtr.Length > 0)
            {
                lblStatus_Bar.Text = "Không thể xóa booking này";
                return;
            }
            if (Status_Booking == "True")
            {
                lblStatus_Bar.Text = "Không thể xóa booking này";
                return;
            }
            lblStatus_Bar.Text = "";
            if (!GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals(gridView1.GetFocusedRowCellValue("NhanSu_Booking").ToString()))
            {
                lblStatus_Bar.Text = "Bạn không thể hủy Booking này, Booking này do nhân viên khác thực hiện";
                return;
            }

            PerformDelete();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            object value = GoobizFrame.Windows.Forms.FrmGNumboardInput.ShowInputDialog(
              "" + gridView2.GetFocusedRowCellValue("" + gridView2.FocusedColumn.FieldName));
            if (value.ToString().Contains("."))
            {
                lblStatus_Bar.Text = "Số lượng phải là số nguyên";
                return;
            }
            if (value.ToString().Contains("-"))
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Số lượng không được nhập số âm");
                value = value.ToString().Replace("-", "");
                gridView2.SetFocusedRowCellValue(gridView2.FocusedColumn, value);
                return;
            }
            if (value.ToString().Length >= 6)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Số lượng nhập không chính xác");
                value = value.ToString().Substring(0, 5);
                gridView2.SetFocusedRowCellValue(gridView2.FocusedColumn, value);
                return;
            }
            if (value.Equals(""))
                gridView2.SetFocusedRowCellValue(gridView2.FocusedColumn, DBNull.Value);
            else
                gridView2.SetFocusedRowCellValue(gridView2.FocusedColumn, value);
            gridView2.RefreshRow(gridView2.FocusedRowHandle);
        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRowView drHanghoa_Ban = (DataRowView)gridLookUp_Hanghoa_Ban.GetDataSourceRowByKeyValue(
               gridView2.GetFocusedRowCellValue("Id_Hanghoa_Ban"));
            string vGhichu = GoobizFrame.Windows.Forms.FrmGKeyboardInput.ShowInputDialog(
               "" + gridView2.GetFocusedRowCellValue(gridView2.FocusedColumn.FieldName), drHanghoa_Ban["Id_Nhom_Hanghoa_Ban"]
               );
            gridView2.SetFocusedRowCellValue(gridView2.FocusedColumn, vGhichu);
            gridView2.RefreshRow(gridView2.FocusedRowHandle);
        }

        private void btnThemmoi_Click(object sender, EventArgs e)
        {
            PerformAdd();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PerformSave();
        }

        private void btnpic_PrintBooking_Click(object sender, EventArgs e)
        {
            PerformPrintPreview();
        }

        private void btnSua_Booking_Click(object sender, EventArgs e)
        {
            if (PerformEdit())
                dgBooking.Enabled = false;
        }

        private void btnSearch_HhBan_Click(object sender, EventArgs e)
        {
            lblStatus_Bar.Text = "";
            if (txtMa_Hanghoa_Ban.Text != "")
            {
                Filter_Dm_Menu_Hanghoa_Ban();
                HideMenuToShowListHH();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ShowTabPage(xtraTabControl1, xtraTabPage_Info);
        }

        private void btnBackDetail_Click(object sender, EventArgs e)
        {
            gridView2.MovePrevPage();
        }

        private void btnNextDetail_Click(object sender, EventArgs e)
        {
            gridView2.MoveNextPage();
        }

        private void btnBackMenu_Click(object sender, EventArgs e)
        {
            cardView_bar_Dm_Menu.MovePrevPage();
        }

        private void btnNextMenu_Click(object sender, EventArgs e)
        {
            cardView_bar_Dm_Menu.MoveNextPage();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (this.FormState != GoobizFrame.Windows.Forms.FormState.Add && gridView1.FocusedRowHandle >= 0)
            {
                lblStatus_Bar.Text = "";
                if ("" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Finish") != "")
                    Status_Booking = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Finish").ToString();
                SelectedId_Table_Booking = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Id_Booking");
                DataBindingControl();
                DisplayInfo2();
            }
        }

        private void gridView2_CellValueChanged_1(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Soluong")
            {
                object Soluong = gridView2.GetFocusedRowCellValue(gridView2.Columns["Soluong"]);
                if (Soluong.ToString().Length >= 6)
                {
                    lblStatus_Bar.Text = "Số lượng nhập không chính xác";
                    Soluong = Soluong.ToString().Substring(0, 5);
                    gridView2.SetFocusedRowCellValue(gridView2.Columns["Soluong"], Soluong);
                    return;
                }
                if (Convert.ToInt32(Soluong) == 0)
                {
                    lblStatus_Bar.Text = "Số lượng nhập không được bằng 0";
                    gridView2.SetFocusedRowCellValue(gridView2.Columns["Soluong"], 1);
                    return;
                }
            }
        }
        #endregion

        private void txtTien_Booking_Validated(object sender, EventArgs e)
        {
            if (!checkTien_Boooking())
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Tiền booking nhập không đúng, vui lòng nhập lại");
                txtTien_Booking.EditValue = null;
                txtTien_Booking.Focus();
            }
        }

        private bool checkTien_Boooking()
        {
            if (txtTien_Booking.Text.Length <= 10)
                return true;
            else
                return false;
        }

        private void cardView_Nhom_Hanghoa_Ban_MouseDown(object sender, MouseEventArgs e)
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
                        gridView_Dm_Menu_Hanghoa_Ban.Columns["Id_Menu"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                            gridView_Dm_Menu_Hanghoa_Ban.Columns["Id_Menu"], cardView_bar_Dm_Menu.GetFocusedRowCellValue("Id_Menu"));
                        gridView_Dm_Menu_Hanghoa_Ban.ApplyColumnsFilter();

                        gridView_Dm_Menu_Hanghoa_Ban.FocusedRowHandle = -1;
                    }

                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                }
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            cardView_Nhom_Hanghoa_Ban.MovePrevPage();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            cardView_Nhom_Hanghoa_Ban.MoveNextPage();
        }
    }
}
