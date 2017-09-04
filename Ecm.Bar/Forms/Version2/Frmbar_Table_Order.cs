using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;
using System.IO;

namespace Ecm.Bar.Forms.Version2
{
    public partial class Frmbar_Table_Order : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        Ecm.WebReferences.Classes.BarService objBarService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.BarService>();
        Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();

        DataSet dsTable_Order = new DataSet();
        DataSet dsTable_Order_Chitiet = new DataSet();
        //DataSet dsTable_Order_Chitiet_Log = new DataSet(); //log data same: bar_kitchen_order_chitiet
        DataSet dsMenu_Hanghoa_Ban;
        DataSet dsNhom_Hanghoa_Ban;
        DataSet dsCtrinh_Kmai_Chitiet;
        DataSet ds_Hanghoa_Ban = null;
        DataSet dsNhansu_Order;
        DataSet ds_Khachhang;
        DataSet dsBar_Dm_Menu;
        DataSet dsKhachhang_KM;
        DataSet dsBooking;
        DataSet dsBooking_Chitiet;
        DataSet ds_Menu_Hanghoa_Monitor = new DataSet();
        DataSet ds_Ware_Dm_Donvitinh;
        DataSet ds_Bar_Dm_Table_Vitri;
        DataSet ds_hanghoa_afterThongke = new DataSet();
        int index_CardMenu = 0; // nếu index_CardMenu = 0 --> ko load lại Menu

        bool checkButton = false;
        bool AllowEdit_Per_Dongia = false;
        bool print_bill = false;
        bool AccessDenied = true;
        bool lock_status = false;
        bool quota = false;
        decimal vip_per_dongia = 0;
        int Id_Nhansu_Km = -1;
        System.Collections.Hashtable Images = new System.Collections.Hashtable();
        public DataRow[] drs_Hanghoa;
        object SelectedId_Table_Order;
        object SelectedId_Khachhang;
        object Curent_Id_Table;
        object Id_Cuahang_Ban;
        object Id_Nhom_Hanghoa_Ban;
        object NgayChungtu;
        object SelectedId_Booking = null;
        object Current_Id_Khuvuc = null;
        //string LogTime = "init";

        DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2;


        #region local data
        DataSet dsSys_Lognotify = null;
        string xml_WARE_HANGHOA_DINHGIA = @"Resources\localdata\Ware_Hanghoa_Dinhgia.xml";
        string xml_WARE_DM_HANGHOA_BAN = @"Resources\localdata\WARE_DM_HANGHOA_BAN.xml";
        string xml_REX_NHANSU = @"Resources\localdata\REX_NHANSU.xml";
        string xml_WARE_DM_KHACHHANG = @"Resources\localdata\WARE_DM_KHACHHANG.xml";
        string xml_BAR_DM_MENU_VISIBLE = @"Resources\localdata\BAR_DM_MENU_VISIBLE.xml";
        string xml_BAR_DM_MENU_HANGHOA_BAN = @"Resources\localdata\BAR_DM_MENU_HANGHOA_BAN.xml";
        string xml_WARE_DM_DONVITINH = @"Resources\localdata\WARE_DM_DONVITINH.xml";
        string xml_BAR_DM_TABLE_VITRI = @"Resources\localdata\BAR_DM_TABLE_VITRI.xml";
        string xml_BAR_DM_TABLE = @"Resources\localdata\BAR_DM_TABLE.xml";
        string xml_WARE_DM_NHOM_HANGHOA_BAN_BYBARMENU = @"Resources\localdata\WARE_DM_NHOM_HANGHOA_BAN_BYBARMENU.xml";

        //datetime last change
        DateTime dtlc_ware_dm_hanghoa_ban;
        DateTime dtlc_bar_dm_menu_hanghoa_ban;
        DateTime dtlc_bar_dm_menu_visible;
        DateTime dtlc_ware_dm_khachhang;
        DateTime dtlc_rex_nhansu;
        DateTime dtlc_ware_dm_donvitinh;
        //DateTime dtlc_bar_dm_table_vitri;
        DateTime dtlc_bar_dm_table;
        DateTime dtlc_ware_hanghoa_dinhgia;
        DateTime dtlc_bar_table_order_chitiet;
        DateTime dtlc_bar_table_order_chitiet_temp = DateTime.Now;

        #endregion

        public Frmbar_Table_Order()
        {
            InitializeComponent();
            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            BarSystem.Visible = false;

            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");

            MakeConditionForSelectedRowKhuvuc();

            LoadMasterTable();
            DisplayInfo();
            LoadMasterTable_2();

            ShowLogonForm();
            //dockPanelKhachhang.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            //dockPanelInfo.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;

            gridView_Dm_Menu_Hanghoa_Ban.Columns["Id_Menu"].Visible = false;
            xtraTabControl_Leftside.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            ShowTabPage(xtraTabPage_Table);

            this.idCardLogonControl1.Select();

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

        void MakeConditionForSelectedRowKhuvuc()
        {
            this.cvBar_Dm_Khuvuc.FormatConditions.Clear();
            styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            styleFormatCondition2.Appearance.BackColor = System.Drawing.Color.MidnightBlue;
            styleFormatCondition2.Appearance.ForeColor = System.Drawing.Color.White;
            styleFormatCondition2.Appearance.Options.UseBackColor = true;
            styleFormatCondition2.Appearance.Options.UseForeColor = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Column = this.gridColumn_Id_Khuvuc;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition2.Value1 = long.MaxValue;
            this.cvBar_Dm_Khuvuc.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
                    styleFormatCondition2});
        }

        #region Event Override
        public object InsertObject()
        {
            Ecm.WebReferences.BarService.Bar_Table_Order bar_Table_Order = new Ecm.WebReferences.BarService.Bar_Table_Order();
            bar_Table_Order.Id_Table_Order = -1;
            bar_Table_Order.Id_Ca_Lamviec = -1;
            bar_Table_Order.Id_Nhansu_Order = Convert.ToInt64(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
            bar_Table_Order.Id_Table = Curent_Id_Table;
            bar_Table_Order.Ngay_Order = objBarService.GetServerDateTime();
            bar_Table_Order.Id_Nhansu_Bill = ("" + lookUp_Nhansu_Bill.EditValue != "" && print_bill) ? lookUp_Nhansu_Bill.EditValue : -1;
            txtSochungtu.Text = "" + objBarService.GetNew_Sochungtu("bar_table_order", "sochungtu", "ORD");
            bar_Table_Order.Sochungtu = txtSochungtu.Text;
            bar_Table_Order.Id_Khachhang = ("" + lookUp_Khachhang.EditValue != "") ? lookUp_Khachhang.EditValue : -1;
            bar_Table_Order.Id_Cuahang_Ban = Id_Cuahang_Ban;
            if (SelectedId_Booking != null)
            {
                bar_Table_Order.Id_Booking = SelectedId_Booking;
                DataRow[] dtr = objBarService.Get_All_Bar_Table_Booking().ToDataSet()
                    .Tables[0].Select("Id_Booking = " + SelectedId_Booking);
                bar_Table_Order.Tien_Booking = dtr[0]["Tien_Booking"];
            }
            else
            {
                bar_Table_Order.Id_Booking = null;
                bar_Table_Order.Tien_Booking = null;
            }
            object identity = objBarService.Insert_Bar_Table_Order(bar_Table_Order);
            if (identity != null)
            {
                this.DoClickEndEdit(dgbar_Table_Order); //dgbar_Table_Order.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                foreach (DataRow dr in dsTable_Order_Chitiet.Tables[0].Rows)
                {
                    //dr["Id_Table_Order_Chitiet"] = DateTime.Now.Ticks;
                    dr["Id_Table_Order"] = identity;
                    dr["Ngay_Order"] = Convert.ToDateTime(objBarService.GetServerDateTime());
                    if (SelectedId_Booking != null)
                        dr["Booking"] = true;
                    else
                        dr["Booking"] = DBNull.Value;

                    if ("" + dr["Guid_Octiet"] == "")
                        dr["Guid_Octiet"] = Guid.NewGuid();
                }
                objBarService.Update_Bar_Table_Order_Chitiet_Collection(dsTable_Order_Chitiet);
            }
            //objBarService.WriteLogNotification(string.Format("{0}-{1}-{2}-{3}\r\n", new object[] { DateTime.Now, identity, bar_Table_Order.Id_Nhansu_Order, "Ins" }));
            SelectedId_Booking = null;
            return true;
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.BarService.Bar_Table_Order bar_Table_Order = new Ecm.WebReferences.BarService.Bar_Table_Order();
            bar_Table_Order.Id_Table_Order = SelectedId_Table_Order;
            bar_Table_Order.Id_Ca_Lamviec = -1;
            if ("" + lookUp_Nhansu_Order.EditValue != "")
                bar_Table_Order.Id_Nhansu_Order = lookUp_Nhansu_Order.EditValue;
            else
                bar_Table_Order.Id_Nhansu_Order = -1;

            bar_Table_Order.Id_Table = Curent_Id_Table;
            if (dtNgay_Order.EditValue == null)
                bar_Table_Order.Ngay_Order = objBarService.GetServerDateTime();
            else
                bar_Table_Order.Ngay_Order = dtNgay_Order.EditValue;

            if (checkButton == true)
                bar_Table_Order.Sotien = Convert.ToDecimal("0" + dsTable_Order_Chitiet.Tables[0].Compute("Sum(Thanhtien)", ""))
                                          - Convert.ToDecimal("0" + dsTable_Order_Chitiet.Tables[0].Compute("Sum(Thanhtien_Km)", ""));
            //    bar_Table_Order.Sotien = (!dsTable_Order_Chitiet.HasChanges())
            //       ? dsTable_Order_Chitiet.Tables[0].Compute("Sum(Thanhtien_TG)", "")
            //       : Convert.ToDecimal("0" + dsTable_Order_Chitiet.Tables[0].Compute("Sum(Thanhtien)", ""));
            ////- Convert.ToDecimal("0" + dsTable_Order_Chitiet.Tables[0].Compute("Sum(Thanhtien_Km)", ""));
            else
                bar_Table_Order.Sotien = null;
            bar_Table_Order.Id_Cuahang_Ban = Id_Cuahang_Ban;
            bar_Table_Order.Id_Nhansu_Bill = ("" + lookUp_Nhansu_Bill.EditValue != "" && print_bill) ? lookUp_Nhansu_Bill.EditValue : -1;
            bar_Table_Order.Id_Vip_Member_Card = -1;
            bar_Table_Order.Id_Khachhang = ("" + lookUp_Khachhang.EditValue != "") ? lookUp_Khachhang.EditValue : -1;
            bar_Table_Order.Id_Nhansu_Km = Id_Nhansu_Km;
            bar_Table_Order.Sochungtu = txtSochungtu.Text;
            if (SelectedId_Booking != null)
            {
                bar_Table_Order.Id_Booking = SelectedId_Booking;
                DataRow[] dtr = objBarService.Get_All_Bar_Table_Booking().ToDataSet().Tables[0].Select("Id_Booking = " + SelectedId_Booking);
                bar_Table_Order.Tien_Booking = dtr[0]["Tien_Booking"];
            }
            else
            {
                bar_Table_Order.Id_Booking = null;
                bar_Table_Order.Tien_Booking = null;
            }

            //check_KhachHang();
            objBarService.Update_Bar_Table_Order(bar_Table_Order);
            objBarService.Bar_Table_Order_Update_Lock(SelectedId_Table_Order, false);

            //update donmuahang_chitiet
            this.DoClickEndEdit(dgbar_Table_Order); //  dgbar_Table_Order.EmbeddedNavigator.Buttons.EndEdit.DoClick();
            gvbar_Table_Order.EndInit();
            foreach (DataRow dr in dsTable_Order_Chitiet.Tables[0].Rows)
            {
                if (dr.RowState == DataRowState.Added)
                {
                    dr["Id_Table_Order"] = SelectedId_Table_Order;
                    dr["Ngay_Order"] = Convert.ToDateTime(objBarService.GetServerDateTime());
                    if (SelectedId_Booking != null)
                        dr["Booking"] = true;
                    else
                        dr["Booking"] = DBNull.Value;

                    if ("" + dr["Guid_Octiet"] == "")
                        dr["Guid_Octiet"] = Guid.NewGuid();

                }
            }

            /*//////////////////////////////////////////////////////////////////////////////////////////////////
            //bar_table_order_chitiet_log -> same: bar_kitchen_order_chitiet
            //neu sua row
            //save row trong Ware_Hdbanhang_Chitiet_Log
            if (dsTable_Order_Chitiet.HasChanges(DataRowState.Modified))
            {
                DataTable dt_Modified = dsTable_Order_Chitiet.Tables[0].GetChanges(DataRowState.Modified).Copy();
                dt_Modified.RejectChanges();
                foreach (DataRow dr_Modified in dt_Modified.Rows)
                {
                    DataRow ndr_Log = dsTable_Order_Chitiet_Log.Tables[0].NewRow();
                    foreach (DataColumn col in dt_Modified.Columns)
                        try
                        {
                            ndr_Log[col.ColumnName] = dr_Modified[col.ColumnName];
                        }
                        catch (Exception ex)
                        { continue; }
                    ndr_Log["RowState"] = DataRowState.Modified.ToString();
                    ndr_Log["Id_Nhansu"] = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu(); //nhan su sua row
                    ndr_Log["Ngay_Hieuchinh"] = objBarService.GetServerDateTime();
                    dsTable_Order_Chitiet_Log.Tables[0].Rows.Add(ndr_Log);
                }
            }
            objBarService.Update_Bar_Table_Order_Chitiet_Log_Collection(dsTable_Order_Chitiet_Log);
            ///////////////////////////////////////////////////////////////////////////////////////////////////////*/

            //Update_Bar_Table_Order_Chitiet_Collection   
            //dsTable_Order_Chitiet.Tables[0].Rows[0]["Soluong"] = 2;
            objBarService.Update_Bar_Table_Order_Chitiet_Collection(dsTable_Order_Chitiet);

            SelectedId_Booking = null;
            return true;
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.BarService.Bar_Table_Order bar_Table_Order = new Ecm.WebReferences.BarService.Bar_Table_Order();
            bar_Table_Order.Id_Table_Order = SelectedId_Table_Order;
            return objBarService.Delete_Bar_Table_Order(bar_Table_Order);
        }

        public override bool PerformAdd()
        {
            btnSave.Text = "Gửi Order";
            if ("" + SelectedId_Table_Order != "")
            {
                lblWarning.Text = "Bàn đã có khách, vui lòng chọn bàn khác";
                return false;
            }
            ClearDataBindings();
            this.ChangeStatus(true);
            this.ResetText();
            lookUp_Nhansu_Order.EditValue = Convert.ToInt64(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
            txtSochungtu.Text = "" + objBarService.GetNew_Sochungtu("bar_table_order", "sochungtu", "ORD");
            ShowMenuToOrder();
            AllowEdit_Per_Dongia = false;
            ChangeFormState(GoobizFrame.Windows.Forms.FormState.Add);
            return true;
        }

        public override bool PerformEdit()
        {
            btnSave.Text = "Lưu Order";
            //if (!GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + lookUp_Nhansu_Order.EditValue))
            //{
            //    //this.ChangeStatus(false);
            //    btnSave.Enabled = false;
            //    btnDelete.Enabled = false;
            //    btnKhachhang.Enabled = false;
            //    lblWarning.Text = "Bạn không thể điều chỉnh bàn này";
            //    return false;
            //}
            if ("" + SelectedId_Table_Order == "")
            {
                lblWarning.Text = "Bạn không thể điều chỉnh bàn trống";
                return false;
            }
            FormState = GoobizFrame.Windows.Forms.FormState.Edit;
            this.ChangeStatus(true);
            AllowEdit_Per_Dongia = false;
            ShowMenuToOrder();
            return true;
        }

        public override bool PerformCancel()
        {
            dsTable_Order.RejectChanges();
            dsTable_Order_Chitiet.RejectChanges();
            txtKM_All.EditValue = null;
            this.DisplayInfo();
            lookUp_Khachhang.EditValue = null;
            txtKM_All.Enabled = false;
            this.ChangeStatus(false);
            this.FormState = GoobizFrame.Windows.Forms.FormState.View;
            return true;
        }

        public override bool PerformSave()
        {
            try
            {
                bool success = false;
                //if ("" + lookUp_Khachhang.EditValue != "" && Convert.ToInt32(lookUp_Khachhang.EditValue) != -1)
                //    objWareService.Update_Ware_Khachhang_Min_Quota(lookUp_Khachhang.EditValue, NgayChungtu);
                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                    success = (bool)this.InsertObject();

                else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                    success = (bool)this.UpdateObject();

                if (success)
                {
                    this.DisplayInfo();
                    lookUp_Khachhang.EditValue = null;
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
            if (GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUser().ToUpper() != "ADMIN")
                if (!GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + lookUp_Nhansu_Order.EditValue))
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                    return false;
                }
            try
            {
                //ko the xoa ban da served 
                if (dsTable_Order_Chitiet.Tables[0].Select("Served = true").Length > 0
                    || dsTable_Order_Chitiet.Tables[0].Select("Soluong_Phucvu > 0").Length > 0)
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
            this.dsTable_Order_Chitiet = objBarService.Get_All_Bar_Table_Order_Chitiet_ById_Order(SelectedId_Table_Order).ToDataSet();
            Ecm.Bar.DataSets.dsHdbanhang_Chitiet dsrHdbanhang_Chitiet = new Ecm.Bar.DataSets.dsHdbanhang_Chitiet();
            Ecm.Bar.Reports.rptHdbanhang_noVAT rptHdbanhang_noVAT = new Ecm.Bar.Reports.rptHdbanhang_noVAT();
            //GoobizFrame.Windows.Forms.FormReport frmPrintPreview = new GoobizFrame.Windows.Forms.FormReport();
            GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            frmPrintPreview.Report = rptHdbanhang_noVAT;
            //frmPrintPreview.Name = this.Name;
            //frmPrintPreview.EnablePrintPreview = this.EnablePrintPreview;
            rptHdbanhang_noVAT.DataSource = dsrHdbanhang_Chitiet;
            int i = 1;
            foreach (DataRow dr in dsTable_Order_Chitiet.Tables[0].Rows)
            {
                if (dr.RowState != DataRowState.Deleted)
                {
                    DataRow drnew = dsrHdbanhang_Chitiet.Tables[0].NewRow();
                    foreach (DataColumn dc in dsTable_Order_Chitiet.Tables[0].Columns)
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
                    drnew["per_dongia"] = dr["Per_Dongia"];
                    drnew["Stt"] = i++;
                    dsrHdbanhang_Chitiet.Tables[0].Rows.Add(drnew);
                }
            }
            //add parameter values
            //rptHdbanhang_noVAT.xrLbl_Tieude.Text = "HÓA ĐƠN KHÁCH HÀNG";
            rptHdbanhang_noVAT.tbc_Ngay.Text = "" + dtNgay_Order.Text + "    * Bàn: " + txtTen_Table.Text;
            rptHdbanhang_noVAT.tbcSochungtu.Text = "" + txtSochungtu.Text;
            rptHdbanhang_noVAT.lblNhansu_Bill.Text = lookUp_Nhansu_Bill.Text;
            rptHdbanhang_noVAT.lblKhachhang.Text = lookUp_Khachhang.Text;
            decimal thanhtien = Convert.ToDecimal("0" + dsTable_Order_Chitiet.Tables[0].Compute("Sum(thanhtien)", ""));
            DataRow[] dtr_Order = dsTable_Order.Tables[0].Select("Id_Table_Order = " + SelectedId_Table_Order);
            if (dtr_Order[0]["Tien_Booking"].ToString() != "")
                thanhtien -= Convert.ToDecimal(dtr_Order[0]["Tien_Booking"]);
            rptHdbanhang_noVAT.PageSize = new Size(800, 1400 + 100 * Convert.ToInt32(dsrHdbanhang_Chitiet.Tables[0].Rows.Count));
            //Trừ tiền cọc booking
            if ("" + txtTien_Booking.EditValue != "")
            {
                decimal Thanhtien_TG = Convert.ToDecimal("0" +
                    dsrHdbanhang_Chitiet.Tables[0].Rows[dsrHdbanhang_Chitiet.Tables[0].Rows.Count - 1]["Thanhtien_TG"]);
                Thanhtien_TG -= Convert.ToDecimal(txtTien_Booking.EditValue);
                dsrHdbanhang_Chitiet.Tables[0].Rows[dsrHdbanhang_Chitiet.Tables[0].Rows.Count - 1]["Thanhtien_TG"] = Thanhtien_TG;
                rptHdbanhang_noVAT.xrTable_Tien_Booking.Visible = true;
                rptHdbanhang_noVAT.lblTien_Booking.Text = string.Format("{0:#,#}", txtTien_Booking.EditValue);
            }
            else
            {
                rptHdbanhang_noVAT.xrTable6.Location = new System.Drawing.Point(21, 42);
                rptHdbanhang_noVAT.xrTable4.Location = new System.Drawing.Point(21, 135);
            }
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
            //if (lookUp_Khachhang.Text != "") // check if khách hàng quota --> hiển thị thông tin giảm giá
            //{
            //    dsKhachhang_KM = objWareService.Get_All_Ware_Khachhang_Quota_Detail_By_Khachhang(lookUp_Khachhang.EditValue).ToDataSet();
            //    if (dsKhachhang_KM.Tables.Count > 0 && dsKhachhang_KM.Tables[0].Rows.Count > 0)
            //    {
            //        if (dsKhachhang_KM.Tables[0].Rows[0]["Id_Vip_Member"].ToString() == "") // check if khach hang quota
            //        {
            //            rptHdbanhang_noVAT.lblSotien_Giam.Visible = true;
            //            rptHdbanhang_noVAT.xrSotien_Giam.Visible = true;
            //            thanhtien -= Convert.ToDecimal("0" + dsTable_Order_Chitiet.Tables[0].Compute("Sum(Thanhtien_Km)", ""));
            //        }
            //    }
            //}
            rptHdbanhang_noVAT.lblTongcong.Text = thanhtien.ToString();
            string str = GoobizFrame.Windows.HelperClasses.ReadNumber.ChangeNum2VNStr((double)thanhtien, " đồng.");
            str = str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower();
            rptHdbanhang_noVAT.tbcThanhtien_Bangchu.Text = str;
            rptHdbanhang_noVAT.CreateDocument();
            objBarService.Bar_Table_Order_Update_Lock(SelectedId_Table_Order, true);
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
            quota = false;
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

        /// <summary>
        /// 
        /// </summary>
        void LoadTableMenu()
        {
            ds_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
            dsBar_Dm_Menu = objMasterService.Get_Visible_Bar_Dm_Menu().ToDataSet();

            dsCtrinh_Kmai_Chitiet = objWareService.Ware_Ctrinh_Kmai_Chitiet_SelectByDate_WithHanghoa(objBarService.GetServerDateTime(), false).ToDataSet();
            //dgbar_Dm_Menu
            dgbar_Dm_Menu.DataSource = dsBar_Dm_Menu.Tables[0];
            gridLookUp_Menu.DataSource = dsBar_Dm_Menu.Tables[0];
            //dgbar_Dm_Menu_Hanghoa_Ban
            dsMenu_Hanghoa_Ban = objMasterService.Get_Visible_Bar_Dm_Menu_Hanghoa_Ban_Collection(null, Current_Id_Khuvuc).ToDataSet();
            dgbar_Dm_Menu_Hanghoa_Ban.DataSource = dsMenu_Hanghoa_Ban.Tables[0];
            gridLookUp_Hanghoa_Ban_Chitiet.DataSource = ds_Hanghoa_Ban.Tables[0];
            gridLookUp_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
        }

        /// <summary>
        /// 
        /// </summary>
        void LoadMasterTable()
        {
            /*
             //            dsSys_Lognotify = objMasterService.Get_Sys_Lognotify_SelectLastChange_OfTables(
            //                //use in LoadMasterTable
            //"[WARE_DM_KHACHHANG], [REX_NHANSU],[BAR_TABLE_ORDER_CHITIET]," +
            //                //use in LoadMasterTable_2
            // "[WARE_DM_DONVITINH], [DM_BAR_TABLE]," +
            // "[BAR_DM_MENU], [BAR_DM_MENU_HANGHOA_BAN], [WARE_DM_HANGHOA_BAN]," +
            //                //use in LoadTableMenu
            // "[BAR_DM_MENU_HANGHOA_BAN]");

            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");

            dsSys_Lognotify = objMasterService.Get_Sys_Lognotify_SelectLastChange_OfTables(
                       "[WARE_DM_KHACHHANG], [REX_NHANSU]").ToDataSet();

            //get date time last change
            dtlc_ware_dm_khachhang = GetLastChange_FrmLognotify("ware_dm_khachhang");
            dtlc_rex_nhansu = GetLastChange_FrmLognotify("rex_nhansu");

            if (!System.IO.File.Exists(xml_WARE_DM_KHACHHANG)
                || DateTime.Compare(dtlc_ware_dm_khachhang, System.IO.File.GetLastWriteTime(xml_WARE_DM_KHACHHANG)) > 0)
            {
                ds_Khachhang = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
                ds_Khachhang.WriteXml(xml_WARE_DM_KHACHHANG, XmlWriteMode.WriteSchema);
            }
            else if (ds_Khachhang == null || ds_Khachhang.Tables.Count == 0)
            {
                ds_Khachhang = new DataSet();
                ds_Khachhang.ReadXml(xml_WARE_DM_KHACHHANG);
            }
            if (!System.IO.File.Exists(xml_REX_NHANSU)
                || DateTime.Compare(dtlc_rex_nhansu, System.IO.File.GetLastWriteTime(xml_REX_NHANSU)) > 0)
            {
                dsNhansu_Order = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
                dsNhansu_Order.WriteXml(xml_REX_NHANSU, XmlWriteMode.WriteSchema);
            }
            else if (dsNhansu_Order == null || dsNhansu_Order.Tables.Count == 0)
            {
                dsNhansu_Order = new DataSet();
                dsNhansu_Order.ReadXml(xml_REX_NHANSU);
            }
             */

            ds_Khachhang = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
            dsNhansu_Order = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();

            lookUp_Nhansu_Order.Properties.DataSource = dsNhansu_Order.Tables[0];
            //gridlookup_TableChitiet_Nhansu_Order.DataSource = dsNhansu_Order.Tables[0];
            gridLookUp_Nhansu_Order.DataSource = dsNhansu_Order.Tables[0];
            lookUp_Nhansu_Bill.Properties.DataSource = dsNhansu_Order.Tables[0];
            lookUp_Khachhang.Properties.DataSource = ds_Khachhang.Tables[0];
            cardView_Nhom_Hanghoa_Ban.FocusedRowHandle = 0;
            FilterNhom_Hanghoa_Ban();
        }

        void LoadMasterTable_2()
        {
            try
            {
                /*
                  dsSys_Lognotify = objMasterService.Get_Sys_Lognotify_SelectLastChange_OfTables(
                 "[WARE_DM_DONVITINH], [BAR_DM_MENU], [DM_BAR_TABLE], [BAR_DM_MENU_HANGHOA_BAN], [WARE_DM_HANGHOA_BAN]").ToDataSet();

                 //get datetime last change
                 dtlc_ware_dm_donvitinh = GetLastChange_FrmLognotify("WARE_DM_DONVITINH");
                 dtlc_bar_dm_menu_visible = GetLastChange_FrmLognotify("BAR_DM_MENU");
                 dtlc_bar_dm_menu_hanghoa_ban = GetLastChange_FrmLognotify("BAR_DM_MENU_HANGHOA_BAN");
                 dtlc_ware_dm_hanghoa_ban = GetLastChange_FrmLognotify("WARE_DM_HANGHOA_BAN");
                 dtlc_bar_dm_table = GetLastChange_FrmLognotify("DM_BAR_TABLE");

                 //WARE_DM_DONVITINH
                 if (!System.IO.File.Exists(xml_WARE_DM_DONVITINH)
                 || DateTime.Compare(dtlc_ware_dm_donvitinh, System.IO.File.GetLastWriteTime(xml_WARE_DM_DONVITINH)) > 0)
                 {
                     ds_Ware_Dm_Donvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
                     ds_Ware_Dm_Donvitinh.WriteXml(xml_WARE_DM_DONVITINH, XmlWriteMode.WriteSchema);
                 }
                 else if (ds_Ware_Dm_Donvitinh == null || ds_Ware_Dm_Donvitinh.Tables.Count == 0)
                 {
                     ds_Ware_Dm_Donvitinh = new DataSet();
                     ds_Ware_Dm_Donvitinh.ReadXml(xml_WARE_DM_DONVITINH);
                 }
                 //Bar_Dm_Table_Vitri
                 if (!System.IO.File.Exists(xml_BAR_DM_TABLE_VITRI)
                 || DateTime.Compare(dtlc_bar_dm_table, System.IO.File.GetLastWriteTime(xml_BAR_DM_TABLE)) > 0)
                 {
                     ds_Bar_Dm_Table_Vitri = objMasterService.Get_All_ViTri_Dm_Bar_Table().ToDataSet();
                     ds_Bar_Dm_Table_Vitri.WriteXml(xml_BAR_DM_TABLE_VITRI, XmlWriteMode.WriteSchema);
                 }
                 else
                 {
                     ds_Bar_Dm_Table_Vitri = new DataSet();
                     ds_Bar_Dm_Table_Vitri.ReadXml(xml_BAR_DM_TABLE_VITRI);
                 }
                 //WARE_DM_NHOM_HANGHOA_BAN_BYBARMENU
                 if (!System.IO.File.Exists(xml_WARE_DM_NHOM_HANGHOA_BAN_BYBARMENU)
                 || DateTime.Compare(dtlc_bar_dm_menu_visible, System.IO.File.GetLastWriteTime(xml_WARE_DM_NHOM_HANGHOA_BAN_BYBARMENU)) > 0
                 || DateTime.Compare(dtlc_bar_dm_menu_hanghoa_ban, System.IO.File.GetLastWriteTime(xml_WARE_DM_NHOM_HANGHOA_BAN_BYBARMENU)) > 0
                 || DateTime.Compare(dtlc_ware_dm_hanghoa_ban, System.IO.File.GetLastWriteTime(xml_WARE_DM_NHOM_HANGHOA_BAN_BYBARMENU)) > 0)
                 {
                     dsNhom_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Nhom_Hanghoa_Ban_ByBarMenu().ToDataSet();
                     dsNhom_Hanghoa_Ban.WriteXml(xml_WARE_DM_NHOM_HANGHOA_BAN_BYBARMENU, XmlWriteMode.WriteSchema);
                 }
                 else if (dsNhom_Hanghoa_Ban == null || dsNhom_Hanghoa_Ban.Tables.Count == 0)
                 {
                     dsNhom_Hanghoa_Ban = new DataSet();
                     dsNhom_Hanghoa_Ban.ReadXml(xml_WARE_DM_NHOM_HANGHOA_BAN_BYBARMENU);
                 }
                 */

                dsNhom_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Nhom_Hanghoa_Ban_ByBarMenu().ToDataSet();
                ds_Bar_Dm_Table_Vitri = objMasterService.Get_All_ViTri_Dm_Bar_Table().ToDataSet();

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
                txtMin_Quota.EditValue = "";
                txtMa_Khachhang.EditValue = "";

                Id_Cuahang_Ban = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocation("Id_Cuahang_Ban");
                if ("" + Id_Cuahang_Ban == "")
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] { "cửa hàng" });
                    return;
                }

                //dgbar_Dm_Table
                this.dsTable_Order = objBarService.Get_All_Bar_Table_Order_By_Id_Cuahang(Id_Cuahang_Ban).ToDataSet();
                dgbar_Dm_Table.DataSource = dsTable_Order;
                dgbar_Dm_Table.DataMember = dsTable_Order.Tables[0].TableName;
                dgbar_Dm_Table.RefreshDataSource();
                cvbar_Dm_Table.RefreshData();
                ClearDataBindings();

                //khu vuc
                var dsbar_dm_khuvuc = objMasterService.Get_All_Bar_Dm_Khuvuc_ByCuahang(new WebReferences.MasterService.Bar_Dm_Khuvuc()
                {
                    Id_Cuahang_Ban = Id_Cuahang_Ban
                }).ToDataSet();
                dgBar_Dm_Khuvuc.DataSource = dsbar_dm_khuvuc.Tables[0];
                if (cvBar_Dm_Khuvuc.RowCount > 0)
                {
                    cvBar_Dm_Khuvuc.FocusedRowHandle = 0;
                    cvbar_Dm_Table.Columns["Id_Khuvuc"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                        cvbar_Dm_Table.Columns["Id_Khuvuc"], cvBar_Dm_Khuvuc.GetFocusedRowCellValue("Id_Khuvuc")
                        );
                    cvbar_Dm_Table.ApplyColumnsFilter();
                    styleFormatCondition2.Value1 = Convert.ToInt32(cvBar_Dm_Khuvuc.GetFocusedRowCellValue("Id_Khuvuc"));
                }


                //this.DataBindingControl();
                this.ChangeStatus(false);
                cvbar_Dm_Table.FocusedRowHandle = -9999;
                dgbar_Table_Order.DataSource = null;
                btnSave.Text = "Gửi Order";
                txtKM_All.Properties.ReadOnly = true;
                ChangeFormState(GoobizFrame.Windows.Forms.FormState.View);
                if (ds_Hanghoa_Ban == null)
                    LoadTableMenu();
                // nhanvuong: nếu NV ko có quyền thêm mới, chỉnh sửa --> disable button tách, ghép bàn
                this.btnTach_Ban.Enabled = EnableEdit;
                this.btnGhep_Ban.Enabled = EnableEdit;
                this.dgbar_Dm_Table.Enabled = EnableAdd;

                //get all log
                //dsSys_Lognotify = objMasterService.GetAll_Sys_Lognotify();
            }
            catch (Exception ex)
            {
                ShowLogonForm();
                ShowTabPage(xtraTabPage_Lock);
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        public override void ClearDataBindings()
        {
            this.txtTien_Booking.Text = "";
            this.txtTien_Booking.DataBindings.Clear();
            this.txtTen_Table.DataBindings.Clear();
            this.txtVitri.DataBindings.Clear();
            this.dtNgay_Order.DataBindings.Clear();
            this.lookUp_Nhansu_Order.DataBindings.Clear();
            this.lookUp_Nhansu_Bill.DataBindings.Clear();
            this.lookUp_Khachhang.DataBindings.Clear();
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
                this.lookUp_Khachhang.DataBindings.Add("EditValue", dsTable_Order, dsTable_Order.Tables[0].TableName + ".Id_Khachhang");
                this.txtTien_Booking.DataBindings.Add("EditValue", dsTable_Order, dsTable_Order.Tables[0].TableName + ".Tien_Booking");
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        public override void ResetText()
        {
            txtMa_Khachhang.EditValue = "";
            lookUp_Khachhang.EditValue = DBNull.Value;
            this.dsTable_Order_Chitiet = objBarService.Get_All_Bar_Table_Order_Chitiet_ById_Order(-1).ToDataSet();
            this.dgbar_Table_Order.DataSource = dsTable_Order_Chitiet.Tables[0];
        }

        #endregion

        #region detail view

        /// <summary>
        /// Tinh khuyen mai
        /// </summary>
        void Cal_KhuyenMai()
        {
            foreach (DataRow dr in dsTable_Order_Chitiet.Tables[0].Rows)
            {
                //set giam gia theo khuyen mai
                if (dsCtrinh_Kmai_Chitiet != null
                && dsCtrinh_Kmai_Chitiet.Tables.Count > 0
                && dsCtrinh_Kmai_Chitiet.Tables[0].Rows.Count > 0)
                {
                    //tim gia tri khuyen mai tu ds khuyen mai chi tiet
                    //dua vao id hang hoa
                    DataRow[] sdr = null;
                    if (dr["Id_Donvitinh"].ToString() != "")
                    {
                        DataRow[] sdr_Hanghoa = dsCtrinh_Kmai_Chitiet.Tables[0].Select("Id_Hanghoa_Ban=" + dr["Id_Hanghoa_Ban"]);
                        for (int i = 0; i < sdr_Hanghoa.Length; i++)
                        {
                            if ("" + sdr_Hanghoa[i]["Id_Donvitinh"] != "")
                            {
                                sdr = dsCtrinh_Kmai_Chitiet.Tables[0].Select("Id_Donvitinh = " + sdr_Hanghoa[i]["Id_Donvitinh"]);
                                break;
                            }
                            else
                                sdr = sdr_Hanghoa;
                        }
                        
                        //neu co gia tri km & hang hoa trong hoa don chua co khuyen mai nao khac
                        if (sdr != null && sdr.Length > 0 && "" + dr["Per_Dongia"] == "")
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

        //    foreach (DataRow row in dsTable_Order_Chitiet.Tables[0].Rows)
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

        /// <summary>
        /// tinh lai gia gia cho VIP card
        /// </summary>
        /// 
        void Recal_Dongia()
        {
            try
            {
                txtMin_Quota.EditValue = null;
                if (lookUp_Khachhang.EditValue.ToString() == "" || lookUp_Khachhang.EditValue.ToString() == "-1")
                    return;
                ////Update Min quota nhanvuong --> chuyển code update sang performsave();
                //if ("" + lookUp_Khachhang.EditValue != "" && Convert.ToInt32(lookUp_Khachhang.EditValue) != -1)
                //    objWareService.Update_Ware_Khachhang_Min_Quota(lookUp_Khachhang.EditValue, NgayChungtu);
                //dsKhachhang_KM = objWareService.Get_All_Ware_Khachhang_Quota_Detail_By_Khachhang(lookUp_Khachhang.EditValue).ToDataSet();
                if (dsKhachhang_KM.Tables.Count > 0 && dsKhachhang_KM.Tables[0].Rows.Count > 0)
                {
                    #region check nếu khách hàng có thẻ VIP
                    //if (dsKhachhang_KM.Tables[0].Rows[0]["Id_Vip_Member"].ToString() != "") // check if khach hang VIP
                    //{
                    //    DataSet dsVip_Member_HhDetail_By_Khachhang =
                    //     objWareService.Get_All_Ware_Vip_Member_HhDetail_By_Khachhang(lookUp_Khachhang.EditValue, NgayChungtu).ToDataSet();
                    //    if (dsVip_Member_HhDetail_By_Khachhang != null && dsVip_Member_HhDetail_By_Khachhang.Tables[0].Rows.Count > 0)
                    //    {
                    //        foreach (DataRow row in dsTable_Order_Chitiet.Tables[0].Rows)
                    //        {
                    //            DataRow[] sdr = dsVip_Member_HhDetail_By_Khachhang.Tables[0].Select("Id_Hanghoa_Ban=" + row["Id_Hanghoa_Ban"]);
                    //            if (sdr != null && sdr.Length > 0) // check Hàng hóa có đang KM hay không
                    //            {
                    //                vip_per_dongia = Convert.ToDecimal(sdr[0]["Per_Hoadon"]);
                    //                if (vip_per_dongia > Convert.ToDecimal("0" + row["Per_Dongia"]))
                    //                    row["Per_Dongia"] = vip_per_dongia;
                    //                //txtPer_Dongia.EditValue = vip_per_dongia;
                    //            }
                    //            try
                    //            {
                    //                row["Thanhtien_Km"] = DBNull.Value;
                    //                row["Thanhtien"] =
                    //                    Convert.ToDecimal(row["Soluong"]) * Convert.ToDecimal("0" + row["Dongia"]) * (1 - Convert.ToDecimal("0" + row["Per_Dongia"]) / 100);
                    //            }
                    //            catch (Exception ex)
                    //            {
                    //                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                    //            }
                    //        }
                    //    }
                    //}
                    #endregion
                    #region khach hang Quota
                //    else
                //    {
                //        quota = true;
                //        Decimal sumBill = Convert.ToDecimal("0" + dsTable_Order_Chitiet.Tables[0].Compute("sum(Thanhtien)", ""));
                //        Decimal minQuota = Convert.ToDecimal("0" + dsKhachhang_KM.Tables[0].Rows[0]["Min_Quota"]);
                //        if ("" + SelectedId_Khachhang == "" + lookUp_Khachhang.EditValue)
                //        {
                //            minQuota = minQuota + Convert.ToDecimal("0" + dsTable_Order_Chitiet.Tables[0].Compute("sum(Thanhtien_Km)", ""));
                //            if (minQuota > Convert.ToDecimal("0" + dsKhachhang_KM.Tables[0].Rows[0]["Max_Quota"]))
                //                minQuota = Convert.ToDecimal("0" + dsKhachhang_KM.Tables[0].Rows[0]["Max_Quota"]);
                //        }
                //        if (gvbar_Table_Order.RowCount != 0)
                //        {
                //            if (sumBill <= minQuota) // nếu tổng số tiền nhỏ hơn số tiền quota
                //            {
                //                foreach (DataRow row in dsTable_Order_Chitiet.Tables[0].Rows)
                //                {
                //                    row["Thanhtien_Km"] = row["Thanhtien"];
                //                }
                //                if (minQuota == 0)
                //                    minQuota = Convert.ToDecimal("0" + dsKhachhang_KM.Tables[0].Rows[0]["Max_Quota"]);
                //                txtMin_Quota.EditValue = minQuota;
                //                lblWarning.Text = "Khách hàng " + dsKhachhang_KM.Tables[0].Rows[0]["Ten_Khachhang"] + " có quota là: " + Convert.ToInt32(minQuota);
                //                return;
                //            }
                //            else
                //            {
                //                object percentKM = minQuota / sumBill;
                //                foreach (DataRow row in dsTable_Order_Chitiet.Tables[0].Rows)
                //                {
                //                    row["Thanhtien_Km"] = Convert.ToDecimal("0" + Convert.ToDecimal(row["Thanhtien"]) * Convert.ToDecimal(percentKM));
                //                }
                //            }
                //        }
                //        txtMin_Quota.EditValue = minQuota;
                //        lblWarning.Text = "Khách hàng " + dsKhachhang_KM.Tables[0].Rows[0]["Ten_Khachhang"] + " có quota là: " + Convert.ToInt32(minQuota);
                //    }
                }
                if (Convert.ToDecimal("0" + gridView2.Columns["Thanhtien"].SummaryItem.SummaryValue) < Convert.ToDecimal("0" + dsKhachhang_KM.Tables[0].Rows[0]["Min_Quota"]))
                {
                    return;
                }
                this.DoClickEndEdit(dgbar_Table_Order); //dgbar_Table_Order.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                    #endregion
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        /// <summary>
        /// show form --> scan customer id (barcode)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKhachhang_Click(object sender, EventArgs e)
        {

            txtMa_Khachhang.Focus();
            txtMa_Khachhang.SelectAll();
        }

        /// <summary>
        /// show master info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInfo_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// verify customer id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMa_Khachhang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                check_KhachHang();
        }

        void check_KhachHang()
        {
            if (txtMa_Khachhang.Text != "")
            {
                try
                {
                    DataTable dt = (DataTable)lookUp_Khachhang.Properties.DataSource;
                    lookUp_Khachhang.EditValue = dt.Select("Ma_Khachhang = '" + txtMa_Khachhang.Text + "'")[0]["Id_Khachhang"];
                    //if ("" + lookUp_Khachhang.EditValue != "" && Convert.ToInt32(lookUp_Khachhang.EditValue) != -1) // tính lại min quota cho KH vừa nhập vào
                    //    objWareService.Update_Ware_Khachhang_Min_Quota(lookUp_Khachhang.EditValue, dtNgay_Order.EditValue);
                    //reset KM                    
                    foreach (DataRow dr in dsTable_Order_Chitiet.Tables[0].Rows)
                    {
                        dr["Per_Dongia"] = DBNull.Value;
                    }
                    //set lai giam gia theo km
                    Cal_KhuyenMai();
                    Recal_Dongia();
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                    txtMa_Khachhang.SelectAll();
                    txtMa_Khachhang.Focus();
                    lookUp_Khachhang.EditValue = DBNull.Value;
                    dsTable_Order_Chitiet.RejectChanges();
                    lblWarning.Text = "Mã khách hàng không tồn tại, nhập lại";
                }
            }
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
                        if (gvbar_Table_Order.GetFocusedRowCellValue(gvbar_Table_Order.Columns["Booking"]).ToString() != "")
                        {
                            if (!Convert.ToBoolean(gvbar_Table_Order.GetFocusedRowCellValue(gvbar_Table_Order.Columns["Booking"])))
                                if (!GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + gvbar_Table_Order.GetFocusedRowCellValue("Id_Nhansu_Order")))
                                {
                                    lblWarning.Text = "Bạn không thể xóa món ăn này. Món ăn này do nhân viên khác order";
                                    return;
                                }
                        }
                        else
                        {
                            if (!GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + gvbar_Table_Order.GetFocusedRowCellValue("Id_Nhansu_Order")))
                            {
                                lblWarning.Text = "Bạn không thể xóa món ăn này. Món ăn này do nhân viên khác order";
                                return;
                            }
                        }
                        if (SelectedId_Table_Order.ToString() != "")
                        {
                            lblWarning.Text = "Liên hệ với quản lý để xóa món này";
                            GoobizFrame.Windows.Forms.Policy.Authorization.Actions Actions = GoobizFrame.Windows.MdiUtils.MdiChecker.ShowIDCardLogonWithResult(this);
                            if (Actions.Count == 0 || !Actions.Contains("EnableUnlock"))
                            {
                                lblWarning.Text = "Tài khoản không hợp lệ";
                                return;
                            }
                            else
                                lblWarning.Text = "";
                        }
                        //if (MessageBox.Show("Bạn có chắc muốn xóa món này ra khỏi hóa đơn?", "Confirm Dialog", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[] { "Món " }) == DialogResult.Yes)
                        {
                            //dsTable_Order_Chitiet.Tables[0].Rows.RemoveAt(gridView2.FocusedRowHandle);
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
            if (gvbar_Table_Order.GetFocusedRowCellValue(gvbar_Table_Order.Columns["Booking"]).ToString() != "")
            {
                if (!Convert.ToBoolean(gvbar_Table_Order.GetFocusedRowCellValue(gvbar_Table_Order.Columns["Booking"])))
                    if (!GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + gvbar_Table_Order.GetFocusedRowCellValue("Id_Nhansu_Order")))
                    {
                        lblWarning.Text = "Bạn không thể chỉnh sửa món ăn này. Món ăn này do nhân viên khác order";
                        return;
                    }
            }
            else
            {
                if (!GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + gvbar_Table_Order.GetFocusedRowCellValue("Id_Nhansu_Order")))
                {
                    lblWarning.Text = "Bạn không thể chỉnh sửa món ăn này. Món ăn này do nhân viên khác order";
                    return;
                }
            }
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
            if (gvbar_Table_Order.GetFocusedRowCellValue(gvbar_Table_Order.Columns["Booking"]).ToString() != "")
            {
                if (!Convert.ToBoolean(gvbar_Table_Order.GetFocusedRowCellValue(gvbar_Table_Order.Columns["Booking"])))
                    if (!GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + gvbar_Table_Order.GetFocusedRowCellValue("Id_Nhansu_Order")))
                    {
                        lblWarning.Text = "Bạn không thể chỉnh sửa món ăn này. Món ăn này do nhân viên khác order";
                        return;
                    }
            }
            else
            {
                if (!GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + gvbar_Table_Order.GetFocusedRowCellValue("Id_Nhansu_Order")))
                {
                    lblWarning.Text = "Bạn không thể chỉnh sửa món ăn này. Món ăn này do nhân viên khác order";
                    return;
                }
            }

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
                    dtr = dsTable_Order_Chitiet.Tables[0].Select("Id_Hanghoa_Ban = " + gvbar_Table_Order.GetFocusedRowCellValue(gvbar_Table_Order.Columns["Id_Hanghoa_Ban"]));
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
            if (dsTable_Order_Chitiet.Tables[0].Rows.Count == 0)
                lblWarning.Text = "Bàn hiện tại đang trống";
            else
                txtKM_All.Text = "" + GoobizFrame.Windows.Forms.FrmGNumboardInput.ShowInputDialog(txtKM_All.Text);
        }

        /// <summary>
        /// gan value km
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtKM_All_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32("0" + txtKM_All.EditValue) > 100 || Convert.ToInt32("0" + txtKM_All.EditValue) < 0)
                {
                    lblWarning.Text = "Giá trị khuyến mãi không hợp lệ (từ 0 - 100)";
                    txtKM_All.EditValue = null;
                    return;
                }
                if (Convert.ToInt32("0" + txtKM_All.EditValue) == 0)
                {
                    for (int i = 0; i < dsTable_Order_Chitiet.Tables[0].Rows.Count; i++)
                    {
                        gvbar_Table_Order.SetRowCellValue(i, gvbar_Table_Order.Columns["Per_Dongia"], DBNull.Value);
                    }
                    return;
                }
                for (int i = 0; i < dsTable_Order_Chitiet.Tables[0].Rows.Count; i++)
                {
                    gvbar_Table_Order.SetRowCellValue(i, gvbar_Table_Order.Columns["Per_Dongia"], txtKM_All.EditValue);
                }
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                lblWarning.Text = "Giá trị Khuyến mãi chỉ được nhập số";
                txtKM_All.EditValue = null;
            }
        }
        #endregion

        #region Custom Button
        private void btnpic_PrintOrder_Click(object sender, EventArgs e)
        {
            //bool success = false;
            {
                object finish = objBarService.Get_Finish_Bar_Table_Order(SelectedId_Table_Order);
                if (Convert.ToBoolean(finish))
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Bàn đã thu tiền xong");
                    this.ShowTabPage(xtraTabPage_Table);
                    return;
                }
                try
                {
                    if (gvbar_Table_Order.RowCount == 0)
                    {
                        lblWarning.Text = "Bàn hiện tại đang trống";
                        return;
                    }
                    if (dsTable_Order_Chitiet.Tables[0].Select("Served is null or Served = 0").Length > 0)
                    {
                        lblWarning.Text = "Bàn có một vài món chưa phục vụ nên không thể thu tiền";
                        return;
                    }
                }
                catch (Exception ex) { GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString()); }

                print_bill = true;
                //if(dsTable_Order_Chitiet.HasChanges())
                //{
                try
                {
                    checkButton = true;
                    Cal_KhuyenMai();
                    this.UpdateObject();
                    Recal_Dongia();
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
                //Update Min quota
                //if ("" + lookUp_Khachhang.EditValue != "" && Convert.ToInt32(lookUp_Khachhang.EditValue) != -1)
                //    objWareService.Update_Ware_Khachhang_Min_Quota(lookUp_Khachhang.EditValue, dtNgay_Order.EditValue);
                print_bill = false;
                DisplayInfo();
                ShowTabPage(xtraTabPage_Table);
                btnPrintOrder.Enabled = false;
                //}
            }
        }


        private void btnMenu_3_Click(object sender, EventArgs e)
        {
            ShowMenuToOrder();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            PerformClose();
        }

        //private void btnAdd_Click(object sender, EventArgs e)
        //{
        //    if (panelLogon.Visible) return;
        //    timer1.Enabled = false;
        //    PerformAdd();
        //    ChangeFormState(GoobizFrame.Windows.Forms.FormState.Add);
        //}

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (groupControl_Logon.Visible) return;
            timer1.Enabled = false;
            ChangeFormState(GoobizFrame.Windows.Forms.FormState.Edit);
            PerformEdit();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (groupControl_Logon.Visible) return;
            if (PerformDelete())
            {
                FormState = GoobizFrame.Windows.Forms.FormState.View;
                btnPrintOrder.Enabled = false;
                ShowTabPage(xtraTabPage_Table);
            }
        }

        private void btnGhep_Ban_Click(object sender, EventArgs e)
        {
            if (groupControl_Logon.Visible) return;

            PerformCancel();
            if (dsBooking_Chitiet != null)
                dsBooking_Chitiet.Clear();
            ChangeFormState(GoobizFrame.Windows.Forms.FormState.View);
            btnPrintOrder.Enabled = false;
            ShowTabPage(xtraTabPage_Table);
            Frmbar_Table_Merge frmbar_Table_Merge = new Frmbar_Table_Merge();
            frmbar_Table_Merge.Text = "Ghép bàn";
            frmbar_Table_Merge.Icon = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetProductIcon();
            frmbar_Table_Merge.ShowDialog();
            DisplayInfo();
        }

        private void btnTach_Ban_Click(object sender, EventArgs e)
        {
            if (groupControl_Logon.Visible) return;
            PerformCancel();
            if (dsBooking_Chitiet != null)
                dsBooking_Chitiet.Clear();
            ChangeFormState(GoobizFrame.Windows.Forms.FormState.View);
            btnPrintOrder.Enabled = false;
            ShowTabPage(xtraTabPage_Table);
            Frmbar_Table_Split Frmbar_Table_Split = new Frmbar_Table_Split();
            Frmbar_Table_Split.Text = "Tách bàn";
            Frmbar_Table_Split.Icon = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetProductIcon();
            Frmbar_Table_Split.ShowDialog();
            DisplayInfo();
            //ShowLogonForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            object finish = "false";
            if ("" + SelectedId_Table_Order != "")
                finish = objBarService.Get_Finish_Bar_Table_Order(SelectedId_Table_Order);
            if (Convert.ToBoolean(finish))
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Bàn đã thu tiền xong");
                this.ShowTabPage(xtraTabPage_Table);
                return;
            }
            this.DoClickEndEdit(dgbar_Table_Order); //dgbar_Table_Order.EmbeddedNavigator.Buttons.EndEdit.DoClick();
            if (FormState == GoobizFrame.Windows.Forms.FormState.Add)
            {
                if (gvbar_Table_Order.RowCount == 0)
                {
                    lblWarning.Text = "Bàn hiện tại đang trống";
                    return;
                }
            }
            else
                if (gvbar_Table_Order.RowCount == 0)
                {
                    lblWarning.Text = "Bàn hiện tại đang trống";
                    return;
                }
            for (int i = 0; i < dsTable_Order_Chitiet.Tables[0].Rows.Count; i++)
            {
                if (dsTable_Order_Chitiet.Tables[0].Rows[i].RowState != DataRowState.Deleted)
                {
                    if (Convert.ToInt32(dsTable_Order_Chitiet.Tables[0].Rows[i]["Soluong"]) == 0)
                    {
                        lblWarning.Text = "Số lượng không được bằng 0 ";
                        dsTable_Order_Chitiet.Tables[0].Rows[i]["Soluong"] = 1;
                        return;
                    }
                }
            }
            checkButton = false;
            PerformSave();
            // ChangeFormState(GoobizFrame.Windows.Forms.FormState.View);
            timer1.Enabled = true;
            txtKM_All.EditValue = null;
            txtKM_All.Enabled = false;
            ShowTabPage(xtraTabPage_Table);
            if (dsBooking_Chitiet != null)
                dsBooking_Chitiet.Clear();
            //ShowLogonForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            PerformCancel();
            if (dsBooking_Chitiet != null)
                dsBooking_Chitiet.Clear();
            timer1.Enabled = true;
            btnPrintOrder.Enabled = false;
            ShowTabPage(xtraTabPage_Table);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Logon process

        private void btnpic_Logon_Click_1(object sender, EventArgs e)
        {
            SelectedId_Table_Order = null;
            ShowLogonForm();
            ClearDataBindings();
        }

        void LockAction()
        {
            xtraTabControl_Leftside.Enabled = false;
        }

        void ShowLogonForm()
        {
            try
            {
                ShowTabPage(xtraTabPage_Table);
                xtraTabControl_Leftside.Enabled = false;

                groupControl_Logon.Visible = true;
                groupControl_Logon.Dock = DockStyle.Fill;

                groupControl_Details.Visible = false;

                idCardLogonControl1.Focus();
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());

            }
        }


        private void changeStatusButton(bool boo)
        {
            btnBackDetail.Visible = boo;
            btnNextDetail.Visible = boo;
            txtKM_All.Enabled = boo;
        }

        public override void ChangeStatus(bool editTable)
        {
            this.dgbar_Dm_Table.Enabled = !editTable;
            gvbar_Table_Order.OptionsBehavior.Editable = editTable;
            btnSave.Enabled = editTable;
            btnCancel.Enabled = editTable;
            btnPrintOrder.Enabled = ("" + SelectedId_Table_Order != "");
            //btnPrintOrder.Enabled = editTable;
            //btnPrintOrder.Enabled = (this.FormState == GoobizFrame.Windows.Forms.FormState.Add) ? false : editTable;
            btnDelete.Enabled = ("" + SelectedId_Table_Order != "");
            btnDelete.Enabled = editTable;
            btnKhachhang_Input.Enabled = editTable;
            btnSave.Enabled = editTable;
            btnTach_Ban.Enabled = !editTable;
            btnGhep_Ban.Enabled = !editTable;
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
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = gridView_Dm_Menu_Hanghoa_Ban.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                if (gridView_Dm_Menu_Hanghoa_Ban.FocusedRowHandle >= 0
            && dsTable_Order_Chitiet.Tables.Count > 0
            && FormState != GoobizFrame.Windows.Forms.FormState.View)
                {
                    if ("" + gridView_Dm_Menu_Hanghoa_Ban.GetRowCellValue(cardHit.RowHandle, "Dongia") != "")
                    {
                        try
                        {
                            object id_hanghoa_ban = gridView_Dm_Menu_Hanghoa_Ban.GetRowCellValue(cardHit.RowHandle, "Id_Hanghoa_Ban");
                            object id_donvitinh = gridView_Dm_Menu_Hanghoa_Ban.GetRowCellValue(cardHit.RowHandle, "Id_Donvitinh");
                            if (Convert.ToBoolean(gridView_Dm_Menu_Hanghoa_Ban.GetRowCellValue(cardHit.RowHandle, "Bc_NXT"))) // nếu true --> check NXT
                            {
                                DataRow[] dtr = dsTable_Order_Chitiet.Tables[0].Select("Id_Hanghoa_Ban = " + id_hanghoa_ban);
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
                                    addNewRow_Into_Order(id_hanghoa_ban, id_donvitinh, gridView_Dm_Menu_Hanghoa_Ban.GetRowCellValue(cardHit.RowHandle, "Dongia"));
                            }
                            else
                                addNewRow_Into_Order(id_hanghoa_ban, id_donvitinh, gridView_Dm_Menu_Hanghoa_Ban.GetRowCellValue(cardHit.RowHandle, "Dongia"));
                        }
                        catch (Exception ex) { GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString()); }
                    }
                    else
                        lblWarning.Text = gridView_Dm_Menu_Hanghoa_Ban.GetRowCellDisplayText(cardHit.RowHandle, gridView_Dm_Menu_Hanghoa_Ban.Columns["Id_Hanghoa_Ban"]) + " chưa có giá bán";
                }
            }
        }

        void addNewRow_Into_Order(object id_hanghoa, object id_donvitinh, object dongia)
        {
            DataRow ndr = dsTable_Order_Chitiet.Tables[0].NewRow();
            ndr["Id_Table_Order_Chitiet"] = DateTime.Now.Ticks;
            ndr["Id_Hanghoa_Ban"] = id_hanghoa;
            ndr["Id_Donvitinh"] = id_donvitinh;
            ndr["Soluong"] = 1;
            ndr["Dongia"] = dongia;
            ndr["Id_Nhansu_Order"] = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu();
            if (txtKM_All.Text == "") // nếu ko có km all, check lại ct khuyến mãi
            {
                if (dsCtrinh_Kmai_Chitiet != null
                         && dsCtrinh_Kmai_Chitiet.Tables.Count > 0
                         && dsCtrinh_Kmai_Chitiet.Tables[0].Rows.Count > 0)
                {
                    DataRow[] sdr = dsCtrinh_Kmai_Chitiet.Tables[0].Select("Id_Hanghoa_Ban=" + ndr["Id_Hanghoa_Ban"]
                                                                            + "and Id_Donvitinh =" + ndr["Id_Donvitinh"]);
                    if (sdr != null && sdr.Length > 0)
                        ndr["Per_Dongia"] = Convert.ToDecimal("0" + sdr[0]["Per_Dongia"]);
                }
            }
            else
                ndr["Per_Dongia"] = ("" + txtKM_All.EditValue != "") ? txtKM_All.EditValue : DBNull.Value; // nếu có km all
            dsTable_Order_Chitiet.Tables[0].Rows.Add(ndr);
            txtKM_All.Enabled = true;
            if (gvbar_Table_Order.RowCount > 9)
            {
                btnBackDetail.Visible = true;
                btnNextDetail.Visible = true;
            }
            if (txtMa_Khachhang.EditValue != null) // check nếu có thẻ kh thì set lại per_dongia
                check_KhachHang();
            gvbar_Table_Order.MoveLastVisible();
            lblWarning.Text = "";
        }

        #endregion

        #region Show Menu
        void ShowMenuToOrder()
        {
            gridView_Dm_Menu_Hanghoa_Ban.Columns["Id_Menu"].Visible = false; //btnMenu_2.Visible = false;
            dgbar_Dm_Menu.Visible = true;
            dgNhom_Hanghoa_Ban.Dock = DockStyle.Fill;
            lblWarning.Text = "";
            ShowTabPage(xtraTabPage_Menu);

            if (cardView_Nhom_Hanghoa_Ban.RowCount > 0)
            {
                cardView_Nhom_Hanghoa_Ban.FocusedRowHandle = 0;

                cardView_bar_Dm_Menu.Columns["Id_Nhom_Hanghoa_Ban"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                    cardView_bar_Dm_Menu.Columns["Id_Nhom_Hanghoa_Ban"], cardView_Nhom_Hanghoa_Ban.GetFocusedRowCellValue("Id_Nhom_Hanghoa_Ban"));
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
            gridView_Dm_Menu_Hanghoa_Ban.ClearColumnsFilter();
            gridView_Dm_Menu_Hanghoa_Ban.Columns["Ma_Hanghoa_Ban"].FilterInfo
                    = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(" Ma_Hanghoa_Ban like '" +
                   txtMa_Hanghoa_Ban.EditValue + "%'");
            gridView_Dm_Menu_Hanghoa_Ban.Columns["Id_Menu"].Visible = true;
            gridView_Dm_Menu_Hanghoa_Ban.Columns["Id_Menu"].VisibleIndex = 0;
        }
        #endregion

        #region main gridview -->> gridView1

        /// <summary>
        /// Click vào panel Bàn, xem thông tin chi tiết of bàn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void gridView1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cvbar_Dm_Table.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                if (cardHit.RowHandle >= 0 && !AccessDenied)
                    cvbar_Dm_Table.FocusedRowHandle = cardHit.RowHandle;
                txtMa_Khachhang.EditValue = null;
                SelectedId_Table_Order = cvbar_Dm_Table.GetRowCellValue(cardHit.RowHandle, "Id_Table_Order");
                if (cvbar_Dm_Table.GetRowCellValue(cardHit.RowHandle, "Lock").ToString() != "")
                {
                    lock_status = Convert.ToBoolean(cvbar_Dm_Table.GetRowCellValue(cardHit.RowHandle, "Lock"));
                    if (lock_status)
                    {
                        lblWarning.Text = "Bàn này đã in hóa đơn, liên hệ với quản lý để thay đổi";
                        GoobizFrame.Windows.Forms.Policy.Authorization.Actions Actions = GoobizFrame.Windows.MdiUtils.MdiChecker.ShowIDCardLogonWithResult(this);
                        if (Actions.Count == 0 || !Actions.Contains("EnableUnlock"))
                        {
                            lblWarning.Text = "Tài khoản không hợp lệ";
                            return;
                        }
                    }
                }
                SelectedId_Khachhang = cvbar_Dm_Table.GetRowCellValue(cardHit.RowHandle, "Id_Khachhang");
                Curent_Id_Table = cvbar_Dm_Table.GetRowCellValue(cardHit.RowHandle, "Id_Table");
                //Id_Cuahang_Ban = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocation("Id_Cuahang_Ban");
                txtSochungtu.EditValue = cvbar_Dm_Table.GetRowCellValue(cardHit.RowHandle, "SoChungtu");
                NgayChungtu = ("" + cvbar_Dm_Table.GetRowCellValue(cardHit.RowHandle, "Ngay_Order") != "")
                    ? cvbar_Dm_Table.GetRowCellValue(cardHit.RowHandle, "Ngay_Order")
                    : objBarService.GetServerDateTime();
                if (cvbar_Dm_Table.GetRowCellValue(cardHit.RowHandle, "Id_Booking").ToString() != "")
                    btnBooking.Enabled = false;
                else
                    btnBooking.Enabled = true;
                this.txtMin_Quota.DataBindings.Clear();
                this.DataBindingControl();
                ShowDetail();
                Recal_Dongia();////////////////////////////////////////////////////////////////////////////////////
                //changeStatusButton(true);
                if (gvbar_Table_Order.RowCount == 0)
                {
                    txtKM_All.Enabled = false;
                    btnBackDetail.Visible = false;
                    btnNextDetail.Visible = false;
                    btnPrintOrder.Enabled = false;
                    btnKhachhang_Input.Enabled = false;
                    if ("" + SelectedId_Table_Order == "")
                        btnDelete.Enabled = false;
                    else
                        btnDelete.Enabled = true;
                }
                else
                {
                    txtKM_All.Enabled = true;
                    btnBackDetail.Visible = true;
                    btnNextDetail.Visible = true;
                }
                btnKhachhang_Input.Enabled = true;
            }
        }

        void ShowDetail()
        {
            lblWarning.Text = "";
            if (dsBooking_Chitiet != null && dsBooking_Chitiet.Tables[0].Rows.Count != 0)
            {
                if ("" + SelectedId_Table_Order == "")
                {
                    dsTable_Order_Chitiet = objBarService.Get_All_Bar_Table_Order_Chitiet_ById_Order(-1).ToDataSet();
                    for (int i = 0; i < dsBooking_Chitiet.Tables[0].Rows.Count; i++)
                    {
                        DataRow ndr = dsTable_Order_Chitiet.Tables[0].NewRow();
                        ndr["Id_Hanghoa_Ban"] = dsBooking_Chitiet.Tables[0].Rows[i]["Id_Hanghoa_Ban"];
                        ndr["Soluong"] = dsBooking_Chitiet.Tables[0].Rows[i]["Soluong"];
                        ndr["Dongia"] = dsBooking_Chitiet.Tables[0].Rows[i]["Dongia"];
                        dsTable_Order_Chitiet.Tables[0].Rows.Add(ndr);
                    }
                    txtKM_All.Enabled = true;
                    dgbar_Table_Order.DataSource = dsTable_Order_Chitiet.Tables[0];
                    this.FormState = GoobizFrame.Windows.Forms.FormState.Add;
                    this.timer1.Enabled = true;
                    ChangeStatus(true);
                }
                else
                    lblWarning.Text = "Bàn đã gọi món, nên xếp booking vào bàn khác";
            }
            else
            {
                if ("" + SelectedId_Table_Order == "")
                    PerformAdd();
                else
                {
                    lookUp_Nhansu_Bill.EditValue = Convert.ToInt64(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
                    //if (PerformEdit())
                    this.DisplayInfo2();
                    btnPrintOrder.Enabled = (dsTable_Order_Chitiet.Tables[0].Rows.Count > 0);
                }
            }
        }

        void DisplayInfo2()
        {
            try
            {
                if ("" + SelectedId_Table_Order == "")
                {
                    this.dgbar_Table_Order.DataSource = null;
                    return;
                }
                this.dsTable_Order_Chitiet = objBarService.Get_All_Bar_Table_Order_Chitiet_ById_Order(SelectedId_Table_Order).ToDataSet();
                //this.dsTable_Order_Chitiet_Log = objBarService.Get_All_Bar_Table_Order_Chitiet_Log_ById_Order(SelectedId_Table_Order);
                PerformEdit();
                //Cal_KhuyenMai();
                this.dgbar_Table_Order.DataSource = dsTable_Order_Chitiet.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

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

        #region panel of sub menu
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
                        gridView_Dm_Menu_Hanghoa_Ban.ClearColumnsFilter();
                        gridView_Dm_Menu_Hanghoa_Ban.Columns["Id_Menu"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(gridView_Dm_Menu_Hanghoa_Ban.Columns["Id_Menu"],
                           id_menu);
                    }
                    catch (Exception ex)
                    {
                        GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                    }
            }
        }
        #endregion

        #region button back to display list table
        private void btDisplayTable_Click(object sender, EventArgs e)
        {
            txtKM_All.Text = "";
            changeStatusButton(false);
            DisplayInfo();
            btnPrintOrder.Enabled = false;
            ShowTabPage(xtraTabPage_Table);
        }

        private void btDisplayTable2_Click(object sender, EventArgs e)
        {
            changeStatusButton(false);
            DisplayInfo();
            ShowTabPage(xtraTabPage_Table);
            txtKM_All.EditValue = null;
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
        private void btnBack_Click(object sender, EventArgs e)
        {
            cvbar_Dm_Table.MovePrevPage();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            cvbar_Dm_Table.MoveNextPage();
        }

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
            gridView_Dm_Menu_Hanghoa_Ban.MovePrevPage();
        }

        private void btnNextMenu_Detail_Click(object sender, EventArgs e)
        {
            gridView_Dm_Menu_Hanghoa_Ban.MoveNextPage();
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

        #region BOOKING

        private void btnBooking_Click(object sender, EventArgs e)
        {
            try
            {
                lblWarning.Text = "";
                dsBooking = objBarService.Get_All_Bar_Table_Booking().ToDataSet();
                DateTime dt = objBarService.GetServerDateTime(); //gio he thong cua server
                DataSet ds = new DataSet();
                ds.Merge(dsBooking.Tables[0].Select("finish is null and Ngay_Den = #" + String.Format("{0:MM/dd/yyyy}", dt) + "#"));
                DataRow[] drOrder_has_booking = objBarService.Get_All_Bar_Table_Order(null, null).ToDataSet().Tables[0].Select("Id_Booking is not null");
                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataRow dRow in drOrder_has_booking)
                    {
                        object id_book = dRow["Id_Booking"];
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            if (ds.Tables[0].Rows[i].RowState != DataRowState.Deleted && ds.Tables[0].Rows[i]["Id_Booking"].Equals(id_book))
                            {
                                ds.Tables[0].Rows[i].Delete();
                            }
                        }
                    }
                    dgBooking.DataSource = ds;
                    dgBooking.DataMember = ds.Tables[0].TableName;
                }
                else
                {
                    lblWarning.Text = "Không có booking nào trong hôm nay";
                    dgBooking.DataSource = null;
                }
                ShowTabPage(xtraTabPage_Booking);
                btn_Deny.Visible = false;
                txtTien_Booking.Visible = true;
                lblTien_Booking.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cardView2_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo CardHitInfo = cardView2.CalcHitInfo(e.X, e.Y);
            if (CardHitInfo.InCard)
            {
                if (CardHitInfo.RowHandle >= 0)
                    try
                    {
                        SelectedId_Booking = cardView2.GetRowCellValue(CardHitInfo.RowHandle, cardView2.Columns["Id_Booking"]);
                        dsBooking_Chitiet = objBarService.GetAll_Bar_Table_Booking_Chitiet_By_Id_Booking(SelectedId_Booking).ToDataSet();
                        this.txtTien_Booking.EditValue = cardView2.GetRowCellValue(CardHitInfo.RowHandle, cardView2.Columns["Tien_Booking"]);
                        dgbar_Table_Order.DataSource = dsBooking_Chitiet.Tables[0];
                        foreach (DataRow row in dsBooking_Chitiet.Tables[0].Rows)
                        {
                            DataRow newRow = dsTable_Order_Chitiet.Tables[0].NewRow();
                            newRow["Id_Hanghoa_Ban"] = row["Id_Hanghoa_Ban"];
                            newRow["Soluong"] = row["Soluong"];
                            newRow["Dongia"] = row["Dongia"];
                            dsTable_Order_Chitiet.Tables[0].Rows.Add(newRow);
                        }
                        //if ("" + cardView2.GetRowCellValue(CardHitInfo.RowHandle, cardView2.Columns["Sochungtu"])=="") 
                        this.btn_Deny.Visible = true;
                        this.btnSave.Enabled = false;
                        this.timer1.Enabled = false;
                        this.gvbar_Table_Order.OptionsBehavior.Editable = false;

                    }
                    catch (Exception ex) { GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString()); }

            }
        }

        // chọn booking
        private void btn_Deny_Click(object sender, EventArgs e)
        {
            ShowTabPage(xtraTabPage_Menu);
            dgbar_Table_Order.DataSource = dsTable_Order_Chitiet.Tables[0];
            for (int i = 0; i < gvbar_Table_Order.RowCount; i++)
            {
                gvbar_Table_Order.SetRowCellValue(i, gvbar_Table_Order.Columns["Booking"], true);
            }
            btnSave.Enabled = true;
            this.gvbar_Table_Order.OptionsBehavior.Editable = true;
        }

        private void simpleButton3_Click_1(object sender, EventArgs e)
        {
            lblWarning.Text = "";
            if (dsBooking_Chitiet != null)
                dsBooking_Chitiet.Clear();
            txtTien_Booking.Text = "";
            this.gvbar_Table_Order.OptionsBehavior.Editable = true;
            this.dsTable_Order_Chitiet = objBarService.Get_All_Bar_Table_Order_Chitiet_ById_Order(-1).ToDataSet();
            this.dgbar_Table_Order.DataSource = dsTable_Order_Chitiet.Tables[0];
            ShowTabPage(xtraTabPage_Menu);
            //PerformCancel();
        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (this.MdiParent != null && this.MdiParent.ActiveMdiChild.Name != this.Name)
                    return;

                if (dgbar_Dm_Menu.Visible)// || dgbar_Dm_Menu_Hanghoa_Ban.Visible)
                {
                    this.TopMost = true;
                    if (index_CardMenu == 0)
                        LoadTableMenu();
                }

                if (dgbar_Dm_Table.Visible)
                {
                    LoadMasterTable();
                    dsSys_Lognotify = objMasterService.Get_Sys_Lognotify_SelectLastChange_OfTables("[BAR_TABLE_ORDER_CHITIET]").ToDataSet();
                    dtlc_bar_table_order_chitiet = GetLastChange_FrmLognotify("BAR_TABLE_ORDER_CHITIET");
                    if (DateTime.Compare(dtlc_bar_table_order_chitiet, dtlc_bar_table_order_chitiet_temp) > 0)
                    {
                        ShowTabPage(xtraTabPage_Table);
                        DisplayInfo();
                        dtlc_bar_table_order_chitiet_temp = dtlc_bar_table_order_chitiet;
                    }
                }

                if (gvbar_Table_Order.OptionsBehavior.Editable)
                {
                    dsSys_Lognotify = objMasterService.Get_Sys_Lognotify_SelectLastChange_OfTables("[BAR_TABLE_ORDER_CHITIET]").ToDataSet();
                    dtlc_bar_table_order_chitiet = GetLastChange_FrmLognotify("BAR_TABLE_ORDER_CHITIET");
                    if (DateTime.Compare(dtlc_bar_table_order_chitiet, dtlc_bar_table_order_chitiet_temp) > 0)
                    {
                        var dsTable_Order_Chitiet_temp = objBarService.Get_All_Bar_Table_Order_Chitiet_ById_Order(SelectedId_Table_Order).ToDataSet();
                        foreach (DataRow dr in dsTable_Order_Chitiet.Tables[0].Rows)
                            if (dr.RowState != DataRowState.Added && dr.RowState != DataRowState.Deleted)
                            {
                                var sdr = dsTable_Order_Chitiet_temp.Tables[0].Select(string.Format("Id_Table_Order_Chitiet={0}", dr["Id_Table_Order_Chitiet"]));
                                bool served = false;
                                Boolean.TryParse("" + sdr[0]["Served"], out served);
                                if (served)
                                {
                                    foreach (DataColumn dc in dsTable_Order_Chitiet.Tables[0].Columns)
                                        dr[dc.ColumnName] = sdr[0][dc.ColumnName];
                                    dgbar_Table_Order.RefreshDataSource();
                                }
                            }
                        dtlc_bar_table_order_chitiet_temp = dtlc_bar_table_order_chitiet;
                    }
                }
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Error,
                    ex.Message, ex.ToString());
            }
        }

        void panelControl_Menu_Click(object sender, EventArgs e)
        {
            throw new Exception("The method or operation is not implemented.");
        }


        private void keyboardcontrol2_UserKeyPressed(object sender, GoobizFrame.Windows.Controls.TouchscreenKeyboard.KeyboardEventArgs e)
        {
            SendKeys.Send(e.KeyboardKeyPressed);
        }

        private void txtMa_Khachhang_Validating(object sender, CancelEventArgs e)
        {
            if (txtMa_Khachhang.Text != "")
            {
                try
                {
                    Cal_KhuyenMai();
                    DataTable dt = (DataTable)lookUp_Khachhang.Properties.DataSource;
                    lookUp_Khachhang.EditValue = dt.Select("Ma_Khachhang = '" + txtMa_Khachhang.Text + "'")[0]["Id_Khachhang"];
                    //DataSet dsKhachhang_Vip = objWareService.Get_All_Ware_Khachhang_Vip_Detail_By_Khachhang(lookUp_Khachhang.EditValue).ToDataSet();
                    //if (dsKhachhang_Vip != null && dsKhachhang_Vip.Tables.Count > 0)
                    //{
                    //    DataRow[] sdr = dsKhachhang_Vip.Tables[0].Select("Id_Cuahang_Ban=" + Id_Cuahang_Ban);
                    //    if (sdr != null && sdr.Length > 0)
                    //        vip_per_dongia = Convert.ToDecimal(sdr[0]["Per_Hoadon"]);
                    //    else
                    //        vip_per_dongia = 0;
                    //}
                    Recal_Dongia();
                }
                catch (Exception ex)
                {
                    txtMa_Khachhang.SelectAll();
                    txtMa_Khachhang.Focus();
                    lookUp_Khachhang.EditValue = DBNull.Value;
                    dsTable_Order_Chitiet.RejectChanges();
                }
            }
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

        private void Frmbar_Table_Order_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataRow[] sdr = dsSys_Lognotify.Tables[0].Select("Table_Name='Ware_Ctrinh_Kmai'");
            if (sdr != null && sdr.Length > 0)
                sdr[0].Delete();
        }

        private void txtMa_Khachhang_EditValueChanged(object sender, EventArgs e)
        {
            //check_KhachHang();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            cardView2.MovePrevPage();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            cardView2.MoveNextPage();
        }

        private void idCardLogonControl1_AfterLogon()
        {
            GoobizFrame.Windows.PlugIn.RightHelpers.CheckUserRightAction(this);
            xtraTabControl_Leftside.Enabled = this.EnableEdit;

            groupControl_Details.Visible = true;
            groupControl_Details.Dock = DockStyle.Fill;
            groupControl_Logon.Visible = false;

            AccessDenied = false;
            DisplayInfo();
            changeStatusButton(false);
            btnSave.Text = "Gửi Order";
            //changeVisibleButton(true);
            ShowTabPage(xtraTabPage_Table);
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

        private void cvBar_Dm_Khuvuc_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cvBar_Dm_Khuvuc.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                Current_Id_Khuvuc = cvBar_Dm_Khuvuc.GetRowCellValue(cardHit.RowHandle, "Id_Khuvuc");
                cvbar_Dm_Table.Columns["Id_Khuvuc"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                        cvbar_Dm_Table.Columns["Id_Khuvuc"], Current_Id_Khuvuc);
                cvbar_Dm_Table.ApplyColumnsFilter();
                styleFormatCondition2.Value1 = Current_Id_Khuvuc;

                try
                {
                    //load menu hang hoa
                    dsMenu_Hanghoa_Ban = objMasterService.Get_Visible_Bar_Dm_Menu_Hanghoa_Ban_Collection(null, Current_Id_Khuvuc).ToDataSet();
                    dgbar_Dm_Menu_Hanghoa_Ban.DataSource = dsMenu_Hanghoa_Ban.Tables[0];
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                }
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

        private void btnBack_Khuvuc_Click(object sender, EventArgs e)
        {
            cvBar_Dm_Khuvuc.MovePrevPage();
        }

        private void btnNext_Khuvuc_Click(object sender, EventArgs e)
        {
            cvBar_Dm_Khuvuc.MoveNextPage();
        }

        private void btnKhachhang_Input_Click(object sender, EventArgs e)
        {
            txtMa_Khachhang.Text = "" + GoobizFrame.Windows.Forms.FrmGKeyboardInput.ShowInputDialog(txtMa_Khachhang.Text);
            check_KhachHang();
        }

        private void gvbar_Table_Order_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvbar_Table_Order.SetFocusedRowCellValue("Id_Table_Order_Chitiet", long.MaxValue - gvbar_Table_Order.RowCount);
        }

        private void gvbar_Table_Order_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //if (("" + gridView2.GetFocusedRowCellValue("Served") == "True"))
            //{
            //    lblWarning.Text = "Món ăn này đã được pha chế xong, bạn không được chỉnh sửa.";
            //    gridView2.CancelUpdateCurrentRow();
            //    return;
            //}
            if (gvbar_Table_Order.GetFocusedRowCellValue(gvbar_Table_Order.Columns["Booking"]) != null
                && gvbar_Table_Order.GetFocusedRowCellValue(gvbar_Table_Order.Columns["Booking"]).ToString() != "")
            {
                if (!Convert.ToBoolean(gvbar_Table_Order.GetFocusedRowCellValue(gvbar_Table_Order.Columns["Booking"])))
                    if (!GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + gvbar_Table_Order.GetFocusedRowCellValue("Id_Nhansu_Order")))
                    {
                        lblWarning.Text = "Bạn không thể chỉnh sửa món ăn này. Món ăn này do nhân viên khác order";
                        gvbar_Table_Order.CancelUpdateCurrentRow();
                        return;
                    }
            }
            else
            {
                if (!GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + gvbar_Table_Order.GetFocusedRowCellValue("Id_Nhansu_Order")))
                {
                    lblWarning.Text = "Bạn không thể chỉnh sửa món ăn này. Món ăn này do nhân viên khác order";
                    gvbar_Table_Order.CancelUpdateCurrentRow();
                    return;
                }
            }
            DataRow[] dtr_In_Db = null;
            lblWarning.Text = "";
            DataRow dr_change = gvbar_Table_Order.GetDataRow(e.RowHandle);
            if (dr_change == null) return;
            if (dr_change.RowState != DataRowState.Added)
                dtr_In_Db = dsTable_Order_Chitiet.Tables[0].Select("Id_Table_Order_Chitiet = " + dr_change["Id_Table_Order_Chitiet"]);
            switch (e.Column.FieldName)
            {
                case "Ghichu":
                    if (gvbar_Table_Order.GetFocusedRowCellValue(gvbar_Table_Order.Columns["Booking"]).ToString() != "")
                    {
                        if (!Convert.ToBoolean(gvbar_Table_Order.GetFocusedRowCellValue(gvbar_Table_Order.Columns["Booking"])))
                            if (!GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + gvbar_Table_Order.GetFocusedRowCellValue("Id_Nhansu_Order")))
                            {
                                lblWarning.Text = "Bạn không thể chỉnh sửa món ăn này. Món ăn này do nhân viên khác order";
                                return;
                            }
                    }
                    else
                    {
                        if (!GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + gvbar_Table_Order.GetFocusedRowCellValue("Id_Nhansu_Order")))
                        {
                            lblWarning.Text = "Bạn không thể chỉnh sửa món ăn này. Món ăn này do nhân viên khác order";
                            return;
                        }
                    }
                    //if (!gridView2.GetFocusedRowCellValue(gridView2.Columns["Id_Nhansu_Order"]).ToString().Equals(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu()))
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
                        if (gvbar_Table_Order.GetFocusedRowCellValue(gvbar_Table_Order.Columns["Booking"]).ToString() != "")
                        {
                            if (!Convert.ToBoolean(gvbar_Table_Order.GetFocusedRowCellValue(gvbar_Table_Order.Columns["Booking"])))
                                if (!GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + gvbar_Table_Order.GetFocusedRowCellValue("Id_Nhansu_Order")))
                                {
                                    lblWarning.Text = "Bạn không thể chỉnh sửa món ăn này. Món ăn này do nhân viên khác order";
                                    return;
                                }
                        }
                        else
                        {
                            if (!GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + gvbar_Table_Order.GetFocusedRowCellValue("Id_Nhansu_Order")))
                            {
                                lblWarning.Text = "Bạn không thể chỉnh sửa món ăn này. Món ăn này do nhân viên khác order";
                                return;
                            }
                        }
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
                    if (gvbar_Table_Order.GetFocusedRowCellValue(gvbar_Table_Order.Columns["Booking"]).ToString() != "")
                    {
                        if (!Convert.ToBoolean(gvbar_Table_Order.GetFocusedRowCellValue(gvbar_Table_Order.Columns["Booking"])))
                            if (!GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + gvbar_Table_Order.GetFocusedRowCellValue("Id_Nhansu_Order")))
                            {
                                lblWarning.Text = "Bạn không thể chỉnh sửa món ăn này. Món ăn này do nhân viên khác order";
                                dr_change.RejectChanges();
                                return;
                            }
                    }
                    else
                    {
                        if (!GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + gvbar_Table_Order.GetFocusedRowCellValue("Id_Nhansu_Order")))
                        {
                            lblWarning.Text = "Bạn không thể chỉnh sửa món ăn này. Món ăn này do nhân viên khác order";
                            dr_change.RejectChanges();
                            return;
                        }
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

    }
}
