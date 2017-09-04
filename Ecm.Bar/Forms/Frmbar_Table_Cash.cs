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
    public partial class Frmbar_Table_Cash : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        Ecm.WebReferences.Classes.BarService objBarService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.BarService>();
        Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();

        DataSet dsTable_Order = new DataSet();
        DataSet dsTable_Order_Chitiet = new DataSet();
        DataSet ds_Hanghoa_Ban = new DataSet();
        DataSet ds_Khachhang = new DataSet();
        DataSet dsNhansu_Order = new DataSet();
        decimal vip_per_dongia = 0;

        object Id_Table_Order;
        object Sochungtu;
        object Id_Nhansu_Bill;
        object Id_Nhansu_Order;
        object Id_Table;
        object Ngay_Order;
        object Id_Cuahang_Ban;
        object Id_Booking;
        object Tien_Booking;
        int Id_Nhansu_Km = -1;
        int Count_Item_in_Table = 0;

        int FocusedRowHandle = 0;
        string LogTime = "init";
        DateTime dtlc_bar_table_order_chitiet;
        DateTime dtlc_bar_table_order_chitiet_temp = DateTime.Now;

        DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition_Kv1;
        DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition_Kv2;


        #region local data

        DataSet dsSys_Lognotify_db = null;
        DataSet dsSys_Lognotify = null;
        string xml_WARE_DM_HANGHOA_BAN = @"Resources\localdata\Ware_Dm_Hanghoa_Ban.xml";
        string xml_REX_NHANSU = @"Resources\localdata\Rex_Nhansu.xml";
        string xml_WARE_DM_KHACHHANG = @"Resources\localdata\Ware_Dm_Khachhang.xml";

        DateTime dtlc_ware_dm_hanghoa_ban;
        DateTime dtlc_rex_nhansu;
        DateTime dtlc_ware_dm_khachhang;

        #endregion

        public Frmbar_Table_Cash()
        {
            InitializeComponent();
            //if (!System.IO.Directory.Exists(@"Resources\localdata"))                
            //    System.IO.Directory.CreateDirectory(@"Resources\localdata");
            this.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            BarSystem.Visible = false;

            this.DisplayInfo();
            xtraTabControl2.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            ShowTabPage(xtraTabPage_TableOrder);

            //ShowLogonForm();

            #region Gán quyền thao tác trên form
            btnSplit.Enabled = EnableQuery;
            btnCash.Enabled = EnableEdit;
            #endregion

            MakeConditionForSelectedRowKhuvuc();
        }

        void ShowTabPage(DevExpress.XtraTab.XtraTabPage xtraTabPage)
        {
            if (xtraTabControl2.SelectedTabPage == xtraTabPage) return;

            //foreach ( DevExpress.XtraTab.XtraTabPage tp in xtraTabControl1.TabPages)
            while (xtraTabControl2.TabPages.Count > 0)
                xtraTabControl2.TabPages.RemoveAt(0);

            xtraTabControl2.TabPages.Add(xtraTabPage);
        }

        void MakeConditionForSelectedRowKhuvuc()
        {
            this.cvBar_Dm_Khuvuc.FormatConditions.Clear();
            styleFormatCondition_Kv1 = new DevExpress.XtraGrid.StyleFormatCondition();
            styleFormatCondition_Kv1.Appearance.BackColor = System.Drawing.Color.MidnightBlue;
            styleFormatCondition_Kv1.Appearance.ForeColor = System.Drawing.Color.White;
            styleFormatCondition_Kv1.Appearance.Options.UseBackColor = true;
            styleFormatCondition_Kv1.Appearance.Options.UseForeColor = true;
            styleFormatCondition_Kv1.ApplyToRow = true;
            styleFormatCondition_Kv1.Column = this.gridColumn_Id_Khuvuc;
            styleFormatCondition_Kv1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition_Kv1.Value1 = long.MaxValue;
            this.cvBar_Dm_Khuvuc.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
                    styleFormatCondition_Kv1});
        }

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

        void LoadMasterData()
        {
            #region code old, not use
            /*
            string vlog_WARE_DM_HANGHOA_BAN = log_WARE_DM_HANGHOA_BAN;
            string vlog_WARE_HANGHOA_DINHGIA = log_WARE_HANGHOA_DINHGIA;
            string vlog_REX_NHANSU = log_REX_NHANSU;
            string vlog_WARE_DM_KHACHHANG = log_WARE_DM_KHACHHANG;

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
                foreach (DataRow dr in dsSys_Lognotify_db.Tables[0].Rows)
                {
                    DataRow[] sdr = dsSys_Lognotify.Tables[0].Select("Table_Name = '" + dr["table_name"] + "'");
                    if (sdr == null || sdr.Length == 0)
                        haschange_atlast = true;
                    else if ("" + sdr[0]["Last_Change"] != "" + dr["Last_Change"])
                        haschange_atlast = true;

                    if (haschange_atlast) break;
                }

                if (haschange_atlast)
                {
                    dsSys_Lognotify_db.WriteXml(Sys_Lognotify_Path, XmlWriteMode.WriteSchema);

                    log_WARE_DM_HANGHOA_BAN = (dsSys_Lognotify.Tables[0].Select("Table_Name='WARE_DM_HANGHOA_BAN'").Length > 0)
                    ? "" + dsSys_Lognotify.Tables[0].Select("Table_Name='WARE_DM_HANGHOA_BAN'")[0]["Last_Change"] : "";
                    log_WARE_HANGHOA_DINHGIA = (dsSys_Lognotify.Tables[0].Select("Table_Name='WARE_HANGHOA_DINHGIA'").Length > 0)
                        ? "" + dsSys_Lognotify.Tables[0].Select("Table_Name='WARE_HANGHOA_DINHGIA'")[0]["Last_Change"] : "";
                    log_REX_NHANSU = (dsSys_Lognotify.Tables[0].Select("Table_Name='REX_NHANSU'").Length > 0)
                        ? "" + dsSys_Lognotify.Tables[0].Select("Table_Name='REX_NHANSU'")[0]["Last_Change"] : "";
                    log_WARE_DM_KHACHHANG = (dsSys_Lognotify.Tables[0].Select("Table_Name='WARE_DM_KHACHHANG'").Length > 0)
                        ? "" + dsSys_Lognotify.Tables[0].Select("Table_Name='WARE_DM_KHACHHANG'")[0]["Last_Change"] : "";
                    log_BAR_TABLE_ORDER_CHITIET = (dsSys_Lognotify.Tables[0].Select("Table_Name='bar_table_order_chitiet'").Length > 0)
                        ? "" + dsSys_Lognotify.Tables[0].Select("Table_Name='bar_table_order_chitiet'")[0]["Last_Change"] : "";


                    vlog_WARE_DM_HANGHOA_BAN = (dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_DM_HANGHOA_BAN'").Length > 0)
                        ? "" + dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_DM_HANGHOA_BAN'")[0]["Last_Change"] : "";
                    vlog_WARE_HANGHOA_DINHGIA = (dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_HANGHOA_DINHGIA'").Length > 0)
                        ? "" + dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_HANGHOA_DINHGIA'")[0]["Last_Change"] : "";
                    vlog_REX_NHANSU = (dsSys_Lognotify_db.Tables[0].Select("Table_Name='REX_NHANSU'").Length > 0)
                        ? "" + dsSys_Lognotify_db.Tables[0].Select("Table_Name='REX_NHANSU'")[0]["Last_Change"] : "";
                    vlog_WARE_DM_KHACHHANG = (dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_DM_KHACHHANG'").Length > 0)
                        ? "" + dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_DM_KHACHHANG'")[0]["Last_Change"] : "";
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
             if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");
            //load data from local xml when last change at local differ from database
            dsSys_Lognotify_db = objMasterService.GetAll_Sys_Lognotify().ToDataSet();
            dsSys_Lognotify = objMasterService.Get_Sys_Lognotify_SelectLastChange_OfTables("[ware_dm_hanghoa_ban], "
                             + " [rex_nhansu], [ware_dm_khachhang]").ToDataSet();

            dtlc_ware_dm_hanghoa_ban = GetLastChange_FrmLognotify("WARE_DM_HANGHOA_BAN");
            dtlc_rex_nhansu = GetLastChange_FrmLognotify("REX_NHANSU");
            dtlc_ware_dm_khachhang = GetLastChange_FrmLognotify("WARE_DM_KHACHHANG");

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
            if (DateTime.Compare(dtlc_ware_dm_khachhang, System.IO.File.GetLastWriteTime(xml_WARE_DM_KHACHHANG)) > 0
                || !System.IO.File.Exists(xml_WARE_DM_KHACHHANG))
            {
                ds_Khachhang = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
                ds_Khachhang.WriteXml(xml_WARE_DM_KHACHHANG, XmlWriteMode.WriteSchema);
            }
            else
            {
                ds_Khachhang = new DataSet();
                ds_Khachhang.ReadXml(xml_WARE_DM_KHACHHANG);
            }
            if (DateTime.Compare(dtlc_rex_nhansu, System.IO.File.GetLastWriteTime(xml_REX_NHANSU)) > 0
                || !System.IO.File.Exists(xml_REX_NHANSU))
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

            ds_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
            ds_Khachhang = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
            dsNhansu_Order = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();

            //lookUpEdit_Nhansu_Cash
            lookUpEdit_Nhansu_Cash.Properties.DataSource = dsNhansu_Order.Tables[0];
            gridLookUp_Nhansu_Order.DataSource = dsNhansu_Order.Tables[0];
            lookUpEdit_Nhansu_Bill.Properties.DataSource = dsNhansu_Order.Tables[0];
            lookUpEdit_Nhansu_Order.Properties.DataSource = dsNhansu_Order.Tables[0];

            gridLookUp_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
            lookUpEdit_Khachhang.Properties.DataSource = ds_Khachhang.Tables[0];
        }

        void DisplayInfo2()
        {
            if ("" + Id_Table_Order == "")
            {
                this.dgbar_Table_Cash.DataSource = null;
                txtThanhtien.EditValue = "";
                chkFinish.Checked = false;

                dsTable_Order_Chitiet = null;
                return;
            }
            this.dsTable_Order_Chitiet = objBarService.Get_All_Bar_Table_Order_Chitiet_ById_Order(Id_Table_Order).ToDataSet();
            Count_Item_in_Table = dsTable_Order_Chitiet.Tables[0].Rows.Count; // Đếm số món ăn hiện có trên bàn
            this.dgbar_Table_Cash.DataSource = dsTable_Order_Chitiet;
            this.dgbar_Table_Cash.DataMember = dsTable_Order_Chitiet.Tables[0].TableName;
            this.DoClickEndEdit(dgbar_Table_Cash); // dgbar_Table_Cash.EmbeddedNavigator.Buttons.EndEdit.DoClick();
            txtThanhtien.EditValue = Convert.ToDecimal(gridView2.Columns["Thanhtien"].SummaryItem.SummaryValue) - Convert.ToDecimal("0" + gridView2.GetFocusedRowCellValue("Tien_Booking"));
            chkFinish.Checked = false;
        }

        //Tự động làm mới dữ liệu
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (FormState == GoobizFrame.Windows.Forms.FormState.View
                    || panelControl_Detail.Visible == false)
                {
                    //LoadMasterData();
                    //DataSet dsLog = objBarService.GetMessageLog();
                    //string vLogTime = (dsLog.Tables.Count > 0) ? "" + dsLog.Tables[0].Rows[0]["Last_Change"] : "";
                    //dsSys_Lognotify_db = objMasterService.Get_Sys_Lognotify_SelectLastChange_OfTables("[BAR_TABLE_ORDER_CHITIET]");
                    //string vLogTime = "" + dsSys_Lognotify_db.Tables[0].Select("Table_Name='Bar_Table_Order_Chitiet'")[0]["Last_Change"];       
                    dsSys_Lognotify = objMasterService.Get_Sys_Lognotify_SelectLastChange_OfTables("[BAR_TABLE_ORDER_CHITIET]").ToDataSet();
                    dtlc_bar_table_order_chitiet = GetLastChange_FrmLognotify("BAR_TABLE_ORDER_CHITIET");
                    //if (LogTime != vLogTime)
                    if (DateTime.Compare(dtlc_bar_table_order_chitiet, dtlc_bar_table_order_chitiet_temp) > 0)
                    {
                        DisplayInfo();
                        cvbar_Dm_Table_Old.FocusedRowHandle = FocusedRowHandle;
                        dtlc_bar_table_order_chitiet_temp = dtlc_bar_table_order_chitiet;
                        //LogTime = vLogTime;
                    }
                }
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        

        void ShowDetail()
        {
            timer1.Enabled = false;
            ShowTabPage(xtraTabPage_Detail);

            this.DisplayInfo2();
            if (dsTable_Order_Chitiet != null
                            && dsTable_Order_Chitiet.Tables.Count > 0
                            && dsTable_Order_Chitiet.Tables[0].Rows.Count > 0)
            {
                try
                {
                    //show nv nhan bill cho khach
                    if ("" + Id_Nhansu_Bill != "")
                        lookUpEdit_Nhansu_Bill.EditValue = Convert.ToInt64(Id_Nhansu_Bill);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

                if (dsTable_Order_Chitiet.Tables[0].Select("Served is null").Length > 0)
                    btnCash.Enabled = false;
                else
                {
                    ChangeFormState(GoobizFrame.Windows.Forms.FormState.Edit);
                    PerformEdit();
                    btnCash.Enabled = true;
                }
            }
            this.DoClickEndEdit(dgbar_Table_Cash); //dgbar_Table_Cash.EmbeddedNavigator.Buttons.EndEdit.DoClick();
            txtThanhtien.EditValue = Convert.ToDecimal("0" + dsTable_Order_Chitiet.Tables[0].Compute("sum(Thanhtien_TG)", ""));
        }

        #region Override Section

        public override void DisplayInfo()
        {
            try
            {
                LoadMasterData();
                //this.dsTable_Order = objBarService.Get_All_Bar_Table_Order(null);
                Id_Cuahang_Ban = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocation("Id_Cuahang_Ban");
                this.dsTable_Order = objBarService.Get_All_Bar_Table_Order_By_Id_Cuahang(Id_Cuahang_Ban).ToDataSet();
                dgbar_Dm_Table_Old.DataSource = dsTable_Order;
                dgbar_Dm_Table_Old.DataMember = dsTable_Order.Tables[0].TableName;
                //khu vuc
                DataSet dsBar_Dm_Khuvuc = objMasterService.Get_All_Bar_Dm_Khuvuc_ByCuahang(new WebReferences.MasterService.Bar_Dm_Khuvuc()
                {
                    Id_Cuahang_Ban = Id_Cuahang_Ban,
                }).ToDataSet();
                dgBar_Dm_Khuvuc.DataSource = dsBar_Dm_Khuvuc.Tables[0];
                if (cvBar_Dm_Khuvuc.RowCount > 0)
                {
                    cvBar_Dm_Khuvuc.FocusedRowHandle = 0;
                    cvbar_Dm_Table_Old.Columns["Id_Khuvuc"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                        cvbar_Dm_Table_Old.Columns["Id_Khuvuc"],
                        cvBar_Dm_Khuvuc.GetFocusedRowCellValue("Id_Khuvuc")
                        );
                    cvbar_Dm_Table_Old.ApplyColumnsFilter();
                    styleFormatCondition_Kv1.Value1 = Convert.ToInt32(cvBar_Dm_Khuvuc.GetFocusedRowCellValue("Id_Khuvuc"));
                }

                this.DataBindingControl();
                this.ChangeStatus(false);
                ResetText();
                ShowTabPage(xtraTabPage_TableOrder);
            }
            catch (Exception ex)
            {
                ShowTabPage(xtraTabPage_Lock);
                lblMessage.Text = ex.Message;
            }
        }

        public override void DataBindingControl()
        {
            try
            {
                this.txtTen_Table.DataBindings.Clear();
                this.txtVitri.DataBindings.Clear();
                this.txtThanhtien.DataBindings.Clear();
                this.txtSochungtu.DataBindings.Clear();
                this.txtTien_Booking.DataBindings.Clear();
                this.dtNgay_Cash.DataBindings.Clear();
                this.lookUpEdit_Nhansu_Cash.DataBindings.Clear();
                this.lookUpEdit_Nhansu_Order.DataBindings.Clear();
                this.lookUpEdit_Nhansu_Bill.DataBindings.Clear();
                this.lookUpEdit_Khachhang.DataBindings.Clear();
                this.txtTien_Conlai.DataBindings.Clear();
                this.txtTien_Conlai.DataBindings.Add("EditValue", dsTable_Order, dsTable_Order.Tables[0].TableName + ".Sotien_Tru_Booking");
                this.txtTen_Table.DataBindings.Add("EditValue", dsTable_Order, dsTable_Order.Tables[0].TableName + ".Ten_Table");
                this.txtVitri.DataBindings.Add("EditValue", dsTable_Order, dsTable_Order.Tables[0].TableName + ".Vitri");
                this.txtSochungtu.DataBindings.Add("EditValue", dsTable_Order, dsTable_Order.Tables[0].TableName + ".Sochungtu");
                this.txtTien_Booking.DataBindings.Add("EditValue", dsTable_Order, dsTable_Order.Tables[0].TableName + ".Tien_Booking");
                this.dtNgay_Cash.DataBindings.Add("EditValue", dsTable_Order, dsTable_Order.Tables[0].TableName + ".Ngay_Casher");
                this.txtThanhtien.DataBindings.Add("EditValue", dsTable_Order, dsTable_Order.Tables[0].TableName + ".Sotien");
                this.lookUpEdit_Nhansu_Cash.DataBindings.Add("EditValue", dsTable_Order, dsTable_Order.Tables[0].TableName + ".Id_Nhansu_Casher");
                this.lookUpEdit_Nhansu_Bill.DataBindings.Add("EditValue", dsTable_Order, dsTable_Order.Tables[0].TableName + ".Id_Nhansu_Bill");
                this.lookUpEdit_Nhansu_Order.DataBindings.Add("EditValue", dsTable_Order, dsTable_Order.Tables[0].TableName + ".Id_Nhansu_Order");
                this.lookUpEdit_Khachhang.DataBindings.Add("EditValue", dsTable_Order, dsTable_Order.Tables[0].TableName + ".Id_Khachhang");
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
            this.dgbar_Dm_Table_Old.Enabled = !editTable;
            this.dtNgay_Cash.Properties.ReadOnly = !editTable;
            this.chkFinish.Enabled = editTable;
        }

        public override void ResetText()
        {
            lookUpEdit_Khachhang.EditValue = "";
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.BarService.Bar_Table_Order bar_Table_Order = new Ecm.WebReferences.BarService.Bar_Table_Order();
            bar_Table_Order.Id_Table_Order = Id_Table_Order;

            bar_Table_Order.Id_Nhansu_Order = Id_Nhansu_Order;
            bar_Table_Order.Id_Nhansu_Bill = ("" + lookUpEdit_Nhansu_Bill.EditValue != "") ? lookUpEdit_Nhansu_Bill.EditValue : -1;
            bar_Table_Order.Id_Nhansu_Casher = lookUpEdit_Nhansu_Cash.EditValue;
            bar_Table_Order.Id_Nhansu_Km = Id_Nhansu_Km;

            bar_Table_Order.Id_Table = Id_Table;
            bar_Table_Order.Ngay_Order = Ngay_Order;
            bar_Table_Order.Id_Ca_Lamviec = -1;// gridView1.GetFocusedRowCellValue("Id_Ca_Lamviec");
            bar_Table_Order.Ngay_Casher = dtNgay_Cash.EditValue;
            bar_Table_Order.Sotien = dsTable_Order_Chitiet.Tables[0].Compute("sum(Thanhtien_TG)", "");

            bar_Table_Order.Sochungtu = txtSochungtu.Text;
            bar_Table_Order.Id_Cuahang_Ban = Id_Cuahang_Ban;
            bar_Table_Order.Id_Khachhang = ("" + lookUpEdit_Khachhang.EditValue != "") ? lookUpEdit_Khachhang.EditValue : -1;

            bar_Table_Order.Finish = true;
            objBarService.Update_Bar_Table_Order(bar_Table_Order);

            if (Id_Booking != null && Id_Booking.ToString() != "")
                objBarService.Update_Bar_Table_Booking_to_Finish(Id_Booking);
            //update donmuahang_chitiet
            this.DoClickEndEdit(dgbar_Table_Cash); //dgbar_Table_Cash.EmbeddedNavigator.Buttons.EndEdit.DoClick();
            foreach (DataRow dr in dsTable_Order_Chitiet.Tables[0].Rows)
            {
                if (dr.RowState == DataRowState.Added)
                    dr["Id_Table_Order"] = Id_Table_Order;
            }
            //Update_Bar_Table_Order_Chitiet_Collection
            objBarService.Update_Bar_Table_Order_Chitiet_Collection(dsTable_Order_Chitiet);
            return true;
        }

        public override bool PerformEdit()
        {
            if ("" + Id_Table_Order == "")
                return false;
            this.ChangeStatus(true);
            this.dtNgay_Cash.EditValue = objBarService.GetServerDateTime();
            this.lookUpEdit_Nhansu_Cash.EditValue = Convert.ToInt64(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());

            return true;
        }

        public override bool PerformCancel()
        {
            this.DisplayInfo();
            return true;
        }

        public override bool PerformSave()
        {
            try
            {
                bool success = false;
                System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
                hashtableControls.Add(dtNgay_Cash, lblNgay_Cash.Text);
                hashtableControls.Add(lookUpEdit_Nhansu_Bill, labelControl1.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                if (dsTable_Order_Chitiet.Tables[0].Select("Served is null").Length > 0)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Bàn có một vài món chưa phục vụ nên không thể thu tiền");
                    return false;
                }
                success = (bool)this.UpdateObject();
                if (success)
                {
                    this.DisplayInfo();

                    new System.Threading.Thread(new System.Threading.ThreadStart(this.Xuat_Nvl)).Start();
                }
                return success;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public override bool PerformPrintPreview()
        {
            Ecm.Bar.DataSets.dsHdbanhang_Chitiet dsrHdbanhang_Chitiet = new Ecm.Bar.DataSets.dsHdbanhang_Chitiet();
            Ecm.Bar.Reports.rptHdbanhang_noVAT rptHdbanhang_noVAT = new Ecm.Bar.Reports.rptHdbanhang_noVAT();
            //            GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            frmPrintPreview.Report = rptHdbanhang_noVAT;
            //frmPrintPreview.Name = this.Name;
            //frmPrintPreview.EnablePrintPreview = this.EnablePrintPreview;
            rptHdbanhang_noVAT.DataSource = dsrHdbanhang_Chitiet;

            int i = 1;
            foreach (DataRow dr in dsTable_Order_Chitiet.Tables[0].Rows)
            {
                DataRow drnew = dsrHdbanhang_Chitiet.Tables[0].NewRow();
                foreach (DataColumn dc in dsTable_Order_Chitiet.Tables[0].Columns)
                {
                    try
                    {
                        drnew[dc.ColumnName] = dr[dc.ColumnName];
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
                drnew["Ten_Hanghoa"] = dr["Ten_Hanghoa_Ban"];
                drnew["Dongia_Ban"] = dr["Dongia"];
                drnew["Thanhtien"] = dr["Thanhtien"];
                drnew["Stt"] = i++;
                dsrHdbanhang_Chitiet.Tables[0].Rows.Add(drnew);
            }
            //add parameter values
            rptHdbanhang_noVAT.tbc_Ngay.Text = "" + dtNgay_Cash.Text + "    * Bàn: " + txtTen_Table.Text;
            rptHdbanhang_noVAT.tbcSochungtu.Text = "" + Sochungtu;
            rptHdbanhang_noVAT.lblNhansu_Bill.Text = lookUpEdit_Nhansu_Bill.Text;
            rptHdbanhang_noVAT.lblNhansu_Bill.Text = lookUpEdit_Nhansu_Bill.Text;
            rptHdbanhang_noVAT.lblKhachhang.Text = lookUpEdit_Khachhang.Text;

            double thanhtien = Convert.ToDouble(dsTable_Order_Chitiet.Tables[0].Compute("sum(Thanhtien)", ""));
            if (txtTien_Booking.Text != "")
                thanhtien -= Convert.ToDouble(txtTien_Booking.EditValue);
            rptHdbanhang_noVAT.PageSize = new Size(800, 1400 + 100 * Convert.ToInt32(dsrHdbanhang_Chitiet.Tables[0].Rows.Count));
            //Trừ tiền cọc booking
            if ("" + Tien_Booking != "")
            {
                decimal Thanhtien_TG = Convert.ToDecimal("0" +
                    dsrHdbanhang_Chitiet.Tables[0].Rows[dsrHdbanhang_Chitiet.Tables[0].Rows.Count - 1]["Thanhtien_TG"]);
                Thanhtien_TG -= Convert.ToDecimal(Tien_Booking);
                dsrHdbanhang_Chitiet.Tables[0].Rows[dsrHdbanhang_Chitiet.Tables[0].Rows.Count - 1]["Thanhtien_TG"] = Thanhtien_TG;
                rptHdbanhang_noVAT.xrTable_Tien_Booking.Visible = true;
                rptHdbanhang_noVAT.lblTien_Booking.Text = string.Format("{0:#,#}", Tien_Booking);
            }
            else
            {
                rptHdbanhang_noVAT.xrTable6.Location = new System.Drawing.Point(21, 42);
                rptHdbanhang_noVAT.xrTable4.Location = new System.Drawing.Point(21, 135);
                //thanhtien -= Convert.ToDouble("0" + dsTable_Order_Chitiet.Tables[0].Compute("Sum(Thanhtien_Km)", ""));
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
                    ,imageData
                });

                rptHdbanhang_noVAT.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                rptHdbanhang_noVAT.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                rptHdbanhang_noVAT.xrPic_Logo.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }
            #endregion

            rptHdbanhang_noVAT.lbl_Dathutien.Visible = true;
            if (lookUpEdit_Khachhang.EditValue != null) // check if khách hàng quota --> hiển thị thông tin giảm giá
            {
                //ds_Khachhang = objWareService.Get_All_Ware_Khachhang_Quota_Detail_By_Khachhang(lookUpEdit_Khachhang.EditValue).ToDataSet();
                //if (ds_Khachhang.Tables.Count > 0 && ds_Khachhang.Tables[0].Rows.Count > 0)
                //{
                //    if (ds_Khachhang.Tables[0].Rows[0]["Id_Vip_Member"].ToString() == "") // check if khach hang quota
                //    {
                //        rptHdbanhang_noVAT.lblSotien_Giam.Visible = true;
                //        rptHdbanhang_noVAT.xrSotien_Giam.Visible = true;
                //        thanhtien -= Convert.ToDouble("0" + dsTable_Order_Chitiet.Tables[0].Compute("Sum(Thanhtien_Km)", ""));
                //    }
                //}
            }
            rptHdbanhang_noVAT.lblTongcong.Text = thanhtien.ToString();
            string str = GoobizFrame.Windows.HelperClasses.ReadNumber.ChangeNum2VNStr(thanhtien, " đồng.");
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


        public void Xuat_Nvl()
        {
            try
            {
                objBarService.Bar_Table_Order_Xuat_Nvl(Id_Cuahang_Ban, Id_Table_Order, null);
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        #region Event Handling
        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Per_Dongia")
            {
                if ("" + gridView2.GetFocusedRowCellValue("Per_Dongia") != ""
                    && "" + gridView2.GetFocusedRowCellValue("Dongia") != ""
                    && "" + gridView2.GetFocusedRowCellValue("Soluong") != "")
                {
                    //tinh thanh tien
                    gridView2.SetFocusedRowCellValue(gridView2.Columns["Thanhtien"],
                        Convert.ToDecimal(gridView2.GetFocusedRowCellValue("Soluong"))
                                                                 * Convert.ToDecimal(gridView2.GetFocusedRowCellValue("Dongia"))
                                                                 * (1 - Convert.ToDecimal(gridView2.GetFocusedRowCellValue("Per_Dongia")) / 100));
                    this.DoClickEndEdit(dgbar_Table_Cash); // dgbar_Table_Cash.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                    txtThanhtien.EditValue = Convert.ToDecimal(gridView2.Columns["Thanhtien"].SummaryItem.SummaryValue);
                }
            }
        }

        private void dgbar_Table_Cash_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + gridView2.GetFocusedRowCellValue(gridView2.Columns["Served"]) != "")
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Món này đã phục vụ nên không thể xóa", "Thông báo");
                    e.Handled = true; //cancel
                }
            }
        }

        private void btnpic_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnpic_BackTableOrder_Click(object sender, EventArgs e)
        {
            ShowTabPage(xtraTabPage_TableOrder);
            PerformCancel();
            ChangeFormState(GoobizFrame.Windows.Forms.FormState.View);
            timer1.Enabled = true;
            Count_Item_in_Table = 0;
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            this.dsTable_Order_Chitiet = objBarService.Get_All_Bar_Table_Order_Chitiet_ById_Order(Id_Table_Order).ToDataSet();
            if (dsTable_Order_Chitiet.Tables[0].Select("Served is null").Length > 0)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Bàn có một vài món chưa phục vụ nên không thể thu tiền");
                return;
            }
            if (Count_Item_in_Table != dsTable_Order_Chitiet.Tables[0].Rows.Count)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Số lượng món ăn có thay đổi nên không thể thu tiền được, vui lòng kiểm tra lại");
                return;
            }
            if (lookUpEdit_Nhansu_Bill.Text == "")
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Nhân viên In hóa đơn không được rỗng, vui lòng kiểm tra lại");
                return;
            }
            PerformPrintPreview();
            chkFinish.Checked = true;
            PerformSave();
            ChangeFormState(GoobizFrame.Windows.Forms.FormState.View);
            timer1.Enabled = true;
        }

        private void btnpic_Delete1Row_Click(object sender, EventArgs e)
        {
            if (FormState != GoobizFrame.Windows.Forms.FormState.View)
            {
                if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[] { "món" }) == DialogResult.Yes
                    && "" + gridView2.GetFocusedRowCellValue(gridView2.Columns["Served"]) == "")

                    this.DoClickEndEdit(dgbar_Table_Cash); //dgbar_Table_Cash.EmbeddedNavigator.Buttons.Remove.DoClick();
                else
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Món này đã phục vụ nên không thể xóa", "Thông báo");
            }
        }

        #region Logon process

        void ShowLogonForm()
        {
            if (this.MdiParent == null)
            {
                panelLogon.Visible = true;
                panelLogon.Dock = DockStyle.Fill;
                splitContainerControl_TableOrder.Visible = false;
                panelControl_Detail.Visible = false;
                item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                btnCash.Enabled = false;
                BarSystem.Visible = false;
                item_Delete.Enabled = false;
                item_Edit.Enabled = false;
            }
            else
            {
                panelLogon.Visible = false;
                splitContainerControl_TableOrder.Visible = true;
                splitContainerControl_TableOrder.Dock = DockStyle.Fill;
            }
        }

        private void textUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            //khong cho phep nhap text vao o ma nhân su
            e.Handled = true;
        }

        #endregion

        private void btnBackMenu_Click(object sender, EventArgs e)
        {
            cvbar_Dm_Table_Old.MovePrevPage();
            cvbar_Dm_Table_Old.Focus();
            FocusedRowHandle = cvbar_Dm_Table_Old.FocusedRowHandle;
        }

        private void btnNextMenu_Click(object sender, EventArgs e)
        {
            cvbar_Dm_Table_Old.MoveNextPage();
            cvbar_Dm_Table_Old.Focus();
            FocusedRowHandle = cvbar_Dm_Table_Old.FocusedRowHandle;
        }

      

        

        private void btnBackDetail_Click(object sender, EventArgs e)
        {
            gridView2.MovePrevPage();
        }

        private void btnNextDetail_Click(object sender, EventArgs e)
        {
            gridView2.MoveNextPage();
        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cvbar_Dm_Table_Old.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                cvbar_Dm_Table_Old.FocusedRowHandle = cardHit.RowHandle;
                try
                {
                    Id_Table_Order = cvbar_Dm_Table_Old.GetRowCellValue(cardHit.RowHandle, "Id_Table_Order");
                    DataRow[] dtr = dsTable_Order.Tables[0].Select("Id_Table_Order = " + Id_Table_Order);
                    Sochungtu = dtr[0]["Sochungtu"];
                    Id_Nhansu_Bill = dtr[0]["Id_Nhansu_Bill"];
                    Id_Nhansu_Order = dtr[0]["Id_Nhansu_Order"];
                    Id_Table = dtr[0]["Id_Table"];
                    Ngay_Order = dtr[0]["Ngay_Order"];
                    Id_Cuahang_Ban = dtr[0]["Id_Cuahang_Ban"];
                    Id_Booking = dtr[0]["Id_Booking"];
                    Tien_Booking = dtr[0]["Tien_Booking"];
                    if (dtr[0]["Id_Nhansu_Km"].ToString() == "")
                        Id_Nhansu_Km = 0;
                    else
                        Id_Nhansu_Km = Convert.ToInt32(dtr[0]["Id_Nhansu_Km"]);
                    if ("" + Id_Table_Order != "")
                        ShowDetail();

                    if ("" + Id_Nhansu_Bill == "" || Id_Nhansu_Bill.ToString() == "-1")
                        btnCash.Enabled = false;
                }
                catch (Exception ex) { GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString()); }
            }
        }

        private void btnSplit_Click(object sender, EventArgs e)
        {
            var frmRptSplit_Sum_Hhban_4Bar = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowExternalForm("Ecm.Reports.dll", "Ecm.Reports.Forms.FrmRptSplit_Sum_Hhban_4Bar", this);
            //Ecm.Reports.Forms.FrmRptSplit_Sum_Hhban_4Bar frmRptSplit_Sum_Hhban_4Bar = new Ecm.Reports.Forms.FrmRptSplit_Sum_Hhban_4Bar();
            //frmRptSplit_Sum_Hhban_4Bar.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnpic_Logon_Click(object sender, EventArgs e)
        {
            ShowLogonForm();
        }
        #endregion

      
        private void cvBar_Dm_Khuvuc_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cvBar_Dm_Khuvuc.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                var id_khuvuc = cvBar_Dm_Khuvuc.GetRowCellValue(cardHit.RowHandle, "Id_Khuvuc");
                cvbar_Dm_Table_Old.Columns["Id_Khuvuc"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                        cvbar_Dm_Table_Old.Columns["Id_Khuvuc"], id_khuvuc);
                cvbar_Dm_Table_Old.ApplyColumnsFilter();
                styleFormatCondition_Kv1.Value1 = Convert.ToInt32(id_khuvuc);
            }
        }

        private void btnBack_Khuvuc_Click(object sender, EventArgs e)
        {
            cvBar_Dm_Khuvuc.MovePrevPage();
        }

        private void btnNext_Khuvuc_Click(object sender, EventArgs e)
        {
            cvBar_Dm_Khuvuc.MoveNextPage();
        }
    }
}

