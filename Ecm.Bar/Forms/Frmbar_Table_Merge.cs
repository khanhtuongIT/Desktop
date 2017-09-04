using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using Ecm.WebReferences.BarService;

namespace Ecm.Bar.Forms
{
    public partial class Frmbar_Table_Merge :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        Ecm.WebReferences.Classes.BarService objBarService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.BarService>();
        Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        DataSet dsTable_Order_Old = new DataSet();
        DataSet dsTable_Order_Old_2 = new DataSet();
        DataSet dsTable_Order_New = new DataSet();
        DataSet dsTable_Order_Chitiet = new DataSet();
        //DataSet dsKhachhang_KM;
        DataSet dsCtrinh_Kmai_Chitiet;

        DataRow[] drChons_Old;
        DataRow drChons_New;

        object identity_Old;
        object identity;
        object identity_New2;
        object Id_Nhansu_Order_New = null;
        int position;
        object Id_Cuahang_Ban;

        DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition_Kv1;
        DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition_Kv2;

        #region local data

        DataSet dsNhansu_Order;
        DataSet ds_Hanghoa_Ban;

        DataSet dsSys_Lognotify = null;
        string xml_WARE_DM_HANGHOA_BAN = @"Resources\localdata\Ware_Dm_Hanghoa_Ban.xml";
        string xml_REX_NHANSU = @"Resources\localdata\Rex_Nhansu.xml";
        DateTime dtlc_ware_dm_hanghoa_ban;
        DateTime dtlc_rex_nhansu;

        #endregion

        public Frmbar_Table_Merge()
        {
            InitializeComponent();
            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");
            //khong cho add, delete
            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            MakeConditionForSelectedRowKhuvuc();

            this.FormState =  GoobizFrame.Windows.Forms.FormState.View;
            this.DisplayInfo();
            //ChangeFormState( GoobizFrame.Windows.Forms.FormState.Edit);
            BarSystem.Visible = false;
        }

        #region display & binding, changeStatus

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

        void LoadMasterData()
        {
            #region
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
                DataSet dsSys_Lognotify_db = objMasterService.GetAll_Sys_Lognotify();
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

                    vlog_WARE_DM_HANGHOA_BAN = (dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_DM_HANGHOA_BAN'").Length > 0)
                        ? "" + dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_DM_HANGHOA_BAN'")[0]["Last_Change"] : "";
                    vlog_WARE_HANGHOA_DINHGIA = (dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_HANGHOA_DINHGIA'").Length > 0)
                        ? "" + dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_HANGHOA_DINHGIA'")[0]["Last_Change"] : "";
                    vlog_REX_NHANSU = (dsSys_Lognotify_db.Tables[0].Select("Table_Name='REX_NHANSU'").Length > 0)
                        ? "" + dsSys_Lognotify_db.Tables[0].Select("Table_Name='REX_NHANSU'")[0]["Last_Change"] : "";
                    vlog_WARE_DM_KHACHHANG = (dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_DM_KHACHHANG'").Length > 0)
                        ? "" + dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_DM_KHACHHANG'")[0]["Last_Change"] : "";

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

            dsSys_Lognotify = objMasterService.Get_Sys_Lognotify_SelectLastChange_OfTables(" [ware_dm_hanghoa_ban], "
                + "[rex_nhansu]").ToDataSet();

            dtlc_ware_dm_hanghoa_ban = GetLastChange_FrmLognotify("WARE_DM_HANGHOA_BAN");
            dtlc_rex_nhansu = GetLastChange_FrmLognotify("REX_NHANSU");
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
                dsNhansu_Order = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
                dsNhansu_Order.WriteXml(xml_REX_NHANSU, XmlWriteMode.WriteSchema);
            }
            else if (dsNhansu_Order == null || dsNhansu_Order.Tables.Count == 0)
            {
                dsNhansu_Order = new DataSet();
                dsNhansu_Order.ReadXml(xml_REX_NHANSU);
            }
            gridLookUp_Nhansu_Order.DataSource = dsNhansu_Order.Tables[0];
            //gridLookUpEdit_Hanghoa_Ban
            gridLookUp_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
            dsCtrinh_Kmai_Chitiet = objWareService.Get_All_Ware_Ctrinh_Kmai_Chitiet_ByDate(objBarService.GetServerDateTime()).ToDataSet();
            Id_Cuahang_Ban =  GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocation("Id_Cuahang_Ban");
        }

        public override void DisplayInfo()
        {
            lblStatus_Bar.Text = "";
            try
            {
                if (this.FormState !=  GoobizFrame.Windows.Forms.FormState.View)
                    return;

                LoadMasterData();
                this.dsTable_Order_Old = objBarService.Get_All_Bar_Table_Order(true, Id_Cuahang_Ban).ToDataSet();
                this.dsTable_Order_Old.Tables[0].Columns.Add("Chon", typeof(Boolean));
                dgbar_Dm_Table_Old.DataSource = dsTable_Order_Old;
                dgbar_Dm_Table_Old.DataMember = dsTable_Order_Old.Tables[0].TableName;
                // set color for girdView_Old
                this.gridViewDm_Table_Old.FormatConditions.Add(setConditionFormat(gridViewDm_Table_Old_2.Columns["Id_Table_Order"], Color.CornflowerBlue));

                dsTable_Order_Old_2 = dsTable_Order_Old.Clone();
                dgDm_Table_Old_2.DataSource = dsTable_Order_Old_2;
                dgDm_Table_Old_2.DataMember = dsTable_Order_Old_2.Tables[0].TableName;
                //set color for gridview_old_2
                this.gridViewDm_Table_Old_2.FormatConditions.Add(setConditionFormat(gridViewDm_Table_Old_2.Columns["Id_Table_Order"], Color.LightPink));

                //this.dsTable_Order_New = objBarService.Get_All_Bar_Table_Order(null);                
                //dgbar_Dm_Table
                this.dsTable_Order_New = objBarService.Get_All_Bar_Table_Order_By_Id_Cuahang(Id_Cuahang_Ban).ToDataSet();
                dgbar_Dm_Table_New.DataSource = dsTable_Order_New;
                dgbar_Dm_Table_New.DataMember = dsTable_Order_New.Tables[0].TableName;
                // set color for gridView_New (change color with table not empty
                this.cardViewDm_Table_New.FormatConditions.Add(setConditionFormat(cardViewDm_Table_New.Columns["Id_Table_Order"], Color.CornflowerBlue));


                //khu vuc
                DataSet dsBar_Dm_Khuvuc = objMasterService.Get_All_Bar_Dm_Khuvuc_ByCuahang(new WebReferences.MasterService.Bar_Dm_Khuvuc()
                {
                    Id_Cuahang_Ban = Id_Cuahang_Ban,
                }).ToDataSet();
                dgBar_Dm_Khuvuc.DataSource = dsBar_Dm_Khuvuc.Tables[0];
                if (cvBar_Dm_Khuvuc.RowCount > 0)
                {
                    cvBar_Dm_Khuvuc.FocusedRowHandle = 0;
                    gridViewDm_Table_Old.Columns["Id_Khuvuc"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                        gridViewDm_Table_Old.Columns["Id_Khuvuc"],
                        cvBar_Dm_Khuvuc.GetFocusedRowCellValue("Id_Khuvuc")
                        );
                }
                dgBar_Dm_Khuvuc_2.DataSource = dsBar_Dm_Khuvuc.Tables[0];
                if (cvBar_Dm_Khuvuc_2.RowCount > 0)
                {
                    cvBar_Dm_Khuvuc_2.FocusedRowHandle = 0;
                    cardViewDm_Table_New.Columns["Id_Khuvuc"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                        cardViewDm_Table_New.Columns["Id_Khuvuc"],
                        cvBar_Dm_Khuvuc_2.GetFocusedRowCellValue("Id_Khuvuc")
                        );
                }


                this.ChangeStatus(false);
                btnSave.Enabled = false;
                //this.DisplayInfo2();
                panelControl_SelectOldTable.Visible = true;
                panelControl_SelectOldTable.Dock = DockStyle.Fill;
                //panelControl_SelectNewTable.Visible = true;
                panelControl_ViewResult.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public DevExpress.XtraGrid.StyleFormatCondition setConditionFormat(DevExpress.XtraGrid.Columns.GridColumn column, Color color)
        {
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition = new DevExpress.XtraGrid.StyleFormatCondition();
            styleFormatCondition.Appearance.BackColor = color;
            styleFormatCondition.Appearance.Options.UseBackColor = true;
            styleFormatCondition.ApplyToRow = true;
            styleFormatCondition.Column = column;
            styleFormatCondition.Condition = DevExpress.XtraGrid.FormatConditionEnum.Greater;
            styleFormatCondition.Value1 = 0;
            return styleFormatCondition;
        }

        void DisplayInfo2()
        {
            //if ("" + gridView1.GetFocusedRowCellValue("Id_Table_Order") == "")
            //{
            //    this.dgbar_Table_Order_Detail.DataSource = null;
            //    return;
            //}
            //this.dsTable_Order_Chitiet = objBarService.Get_All_Bar_Table_Order_Chitiet_ById_Order(gridView1.GetFocusedRowCellValue("Id_Table_Order"));
            //this.dgbar_Table_Order_Detail.DataSource = dsTable_Order_Chitiet;
            //this.dgbar_Table_Order_Detail.DataMember = dsTable_Order_Chitiet.Tables[0].TableName;
        }

        public override void  DataBindingControl()
        {
            try
            {
                this.txtVitri.DataBindings.Clear();
                //this.dtNgay_Order.DataBindings.Clear();
                //this.lookUpEdit_Nhansu_Order.DataBindings.Clear();
                // this.txtVitri.DataBindings.Add("EditValue", dsTable_Order_Old, dsTable_Order_Old.Tables[0].TableName + ".Vitri");
                //this.dtNgay_Order.DataBindings.Add("EditValue", dsTable_Order_Old, dsTable_Order_Old.Tables[0].TableName + ".Ngay_Order");
                //this.lookUpEdit_Nhansu_Order.DataBindings.Add("EditValue", dsTable_Order_Old, dsTable_Order_Old.Tables[0].TableName + ".Id_Nhansu_Order");
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                ////Ecm.HelperClasses.ExceptionLogger.LogException1(ex);
            }
        }

        public override void ChangeStatus(bool editTable)
        {
            this.dgbar_Dm_Table_Old.Enabled = !editTable;
            //this.dtNgay_Order.Properties.ReadOnly = !editTable;
        }
        #endregion

        #region Event Override
        public object UpdateObject()
        {
            #region not use
            //BarService.Bar_Table_Order bar_Table_Order = new Ecm.Bar.BarService.Bar_Table_Order();
            //bar_Table_Order.Id_Table_Order = gridView1.GetFocusedRowCellValue("Id_Table_Order");
            //bar_Table_Order.Id_Ca_Lamviec = lookUpEdit_Ca_Lamviec.EditValue;
            //bar_Table_Order.Id_Nhansu_Order = lookUpEdit_Nhansu_Order.EditValue;
            //bar_Table_Order.Id_Table = gridView1.GetFocusedRowCellValue("Id_Table");
            //bar_Table_Order.Ngay_Order = dtNgay_Order.EditValue;
            //objBarService.Update_Bar_Table_Order(bar_Table_Order);
            //update donmuahang_chitiet
            // dgbar_Table_Order_Detail.EmbeddedNavigator.Buttons.EndEdit.DoClick();
            //foreach (DataRow dr in dsTable_Order_Chitiet.Tables[0].Rows)
            //{
            //    if (dr.RowState == DataRowState.Added)
            //    {
            //        dr["Id_Table_Order"] = gridView1.GetFocusedRowCellValue("Id_Table_Order");
            //        dr["Booking"] = true;
            //    }

            //}
            //Update_Bar_Table_Order_Chitiet_Collection
            #endregion

            this.DoClickEndEdit(dgbar_Table_Order_Detail);
            objBarService.Update_Bar_Table_Order_Chitiet_Collection(dsTable_Order_Chitiet);
            return true;
        }

        public override bool PerformEdit()
        {
            if ("" + gridViewDm_Table_Old.GetFocusedRowCellValue("Id_Table_Order") == "")
                return false;
            this.ChangeStatus(true);
            return true;
        }

        public override bool PerformCancel()
        {
            performReset();
            this.DisplayInfo();
            this.FormState =  GoobizFrame.Windows.Forms.FormState.View;
            btnSave.Enabled = false;
            return true;
        }

        public override bool PerformSave()
        {
            try
            {
                bool success = false;

                //neu bàn đã dc đặt thì ghép tất cả hh
                if (identity == null || Convert.ToInt32(identity) == -1)
                {
                    //nếu bàn mới chọn là bàn mới thì ghép hh sang bàn mới                    
                    Ecm.WebReferences.BarService.Bar_Table_Order bar_Table_Order = new Ecm.WebReferences.BarService.Bar_Table_Order();
                    bar_Table_Order.Id_Table_Order = -1;
                    bar_Table_Order.Id_Ca_Lamviec = -1; //objWareService.Get_All_Ware_Dm_Ca_Lamviec_ByHours(DateTime.Now).Tables[0].Rows[0]["Id_Ca_Lamviec"];
                    //bar_Table_Order.Id_Nhansu_Order = Convert.ToInt64(dsTable_Order_Old_2.Tables[0].Rows[0]["Id_Nhansu_Order"]);//Convert.ToInt64( GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
                    bar_Table_Order.Id_Nhansu_Order = Convert.ToInt64( GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
                    bar_Table_Order.Id_Cuahang_Ban = Convert.ToInt64(dsTable_Order_Old_2.Tables[0].Rows[0]["Id_Cuahang_Ban"]);//Convert.ToInt64( GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
                    bar_Table_Order.Id_Table = Convert.ToInt64(drChons_New["Id_Table"]);
                    bar_Table_Order.Id_Khachhang = -1;
                    bar_Table_Order.Ngay_Order = objBarService.GetServerDateTime();
                    bar_Table_Order.Sochungtu = "" + objWareService.GetNew_Sochungtu("bar_table_order", "sochungtu", "ORD");
                    identity = objBarService.Insert_Bar_Table_Order(bar_Table_Order);
                }
                else
                {
                    Ecm.WebReferences.BarService.Bar_Table_Order bar_Table_Order = new Ecm.WebReferences.BarService.Bar_Table_Order();
                    bar_Table_Order.Id_Table_Order = identity;
                    bar_Table_Order.Id_Nhansu_Bill = null;
                    bar_Table_Order.Sotien = null;
                    bar_Table_Order.Id_Ca_Lamviec = -1; //objWareService.Get_All_Ware_Dm_Ca_Lamviec_ByHours(DateTime.Now).Tables[0].Rows[0]["Id_Ca_Lamviec"];
                    //bar_Table_Order.Id_Nhansu_Order = Convert.ToInt64(dsTable_Order_Old_2.Tables[0].Rows[0]["Id_Nhansu_Order"]);//Convert.ToInt64( GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
                    bar_Table_Order.Id_Nhansu_Order = Id_Nhansu_Order_New;
                    bar_Table_Order.Id_Cuahang_Ban = Convert.ToInt64(dsTable_Order_Old_2.Tables[0].Rows[0]["Id_Cuahang_Ban"]);//Convert.ToInt64( GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
                    bar_Table_Order.Id_Table = Convert.ToInt64(drChons_New["Id_Table"]);
                    bar_Table_Order.Id_Khachhang = -1;
                    bar_Table_Order.Ngay_Order = objBarService.GetServerDateTime();
                    bar_Table_Order.Sochungtu = dsTable_Order_Old_2.Tables[0].Rows[0]["Sochungtu"];
                    objBarService.Update_Bar_Table_Order(bar_Table_Order);
                }
                foreach (DataRow dr in dsTable_Order_Chitiet.Tables[0].Rows)
                {
                    dr["Per_Dongia"] = DBNull.Value;
                    dr["Thanhtien_Km"] = DBNull.Value;
                    dr["Id_Table_Order"] = identity;
                }
                #region code old, not use
                //// check trong ds old table  
                //for (int i = 0; i < dsTable_Order_Old_2.Tables[0].Rows.Count; i++)
                //{
                //    object id_khachhang = dsTable_Order_Old_2.Tables[0].Rows[i]["Id_Khachhang"];
                //    if ("" + id_khachhang.ToString() != "" && id_khachhang.ToString() != "-1") // có id khách hàng
                //    {
                //        dsKhachhang_KM = objWareService.Get_All_Ware_Khachhang_Quota_Detail_By_Khachhang(id_khachhang);
                //        if (dsKhachhang_KM.Tables[0].Rows[0]["Id_Vip_Member"].ToString() != "") // check if khach hang VIP
                //        {
                //            Cal_KhuyenMai();
                //            objBarService.Update_Bar_Table_Order_Chitiet_Collection(dsTable_Order_Old_2);
                //        }
                //        else // khách hàng quota
                //        {
                //            objBarService.Update_Bar_Table_Order_Chitiet_Collection(dsTable_Order_Old_2);
                //            objWareService.Update_Ware_Khachhang_Min_Quota(id_khachhang, dsTable_Order_Old_2.Tables[0].Rows[i]["Ngay_Order"]);
                //        }
                //        objBarService.Update_Id_Khachhang_Bar_Table_Order(dsTable_Order_Old_2.Tables[0].Rows[i]["Id_Table_Order"]);
                //    }
                //}

                //// check table mới (bàn đc ghép)
                //if (drChons_New["Id_Khachhang"].ToString() != "" && drChons_New["Id_Khachhang"].ToString() != "-1")
                //{
                //    dsKhachhang_KM = objWareService.Get_All_Ware_Khachhang_Quota_Detail_By_Khachhang(drChons_New["Id_Khachhang"]);
                //    if (dsKhachhang_KM.Tables[0].Rows[0]["Id_Vip_Member"].ToString() != "") // check if khach hang VIP
                //    {
                //        Cal_KhuyenMai();
                //        objBarService.Update_Bar_Table_Order_Chitiet_Collection(dsTable_Order_Chitiet);
                //    }
                //    else // khách hàng quota
                //    {
                //        objBarService.Update_Bar_Table_Order_Chitiet_Collection(dsTable_Order_Chitiet);
                //        objWareService.Update_Ware_Khachhang_Min_Quota(drChons_New["Id_Khachhang"], drChons_New["Ngay_Order"]);
                //    }
                //    objBarService.Update_Id_Khachhang_Bar_Table_Order(drChons_New["Id_Table_Order"]);
                //}
                #endregion

                objBarService.Update_Bar_Table_Order_Chitiet_Collection(dsTable_Order_Chitiet);
                foreach (DataRow drs in dsTable_Order_Old_2.Tables[0].Rows)
                {
                    if (identity.ToString() != "")
                    {
                        if (Convert.ToInt64(drs["Id_Table_Order"] + "") != Convert.ToInt64(identity))
                        {
                            //nếu bàn dc ghép mà khác với bàn ghép thì xóa bàn dc ghép. group bàn mới. 
                            Ecm.WebReferences.BarService.Bar_Table_Order bar_Table_Order = new Ecm.WebReferences.BarService.Bar_Table_Order();
                            bar_Table_Order.Id_Table_Order = drs["Id_Table_Order"];
                            objBarService.Delete_Bar_Table_Order(bar_Table_Order);
                            //objBarService.WriteLogNotification(string.Format("{0}-{1}-{2}-{3}\r\n", new object[] { DateTime.Now, bar_Table_Order.Id_Table_Order, bar_Table_Order.Id_Nhansu_Order, "Del" }));
                        }
                        else
                        {
                            Ecm.WebReferences.BarService.Bar_Table_Order bar_Table_Order = new Ecm.WebReferences.BarService.Bar_Table_Order();
                            bar_Table_Order.Id_Table_Order = drs["Id_Table_Order"];
                            bar_Table_Order.Id_Ca_Lamviec = drs["Id_Ca_Lamviec"];
                            bar_Table_Order.Id_Cuahang_Ban = drs["Id_Cuahang_Ban"];
                            bar_Table_Order.Id_Khachhang = -1;
                            bar_Table_Order.Id_Nhansu_Bill = null;
                            bar_Table_Order.Id_Nhansu_Casher = null;
                            bar_Table_Order.Id_Nhansu_Km = null;
                            bar_Table_Order.Id_Nhansu_Order = drs["Id_Nhansu_Order"];
                            bar_Table_Order.Id_Table = drs["Id_Table"];
                            bar_Table_Order.Ngay_Order = drs["Ngay_Order"];
                            bar_Table_Order.Sochungtu = drs["Sochungtu"];
                            bar_Table_Order.Sotien = null;
                            //bar_Table_Order.Id_Booking = drs["Id_Booking"];
                            objBarService.Update_Bar_Table_Order(bar_Table_Order);
                        }
                    }
                }
                success = true;
                if (success)
                {
                    // GoobizFrame.Windows.Forms.MessageDialog.Show("", "Thông báo");
                    lblStatus_Bar.Text = "Đã ghép bàn thành công";
                    this.FormState =  GoobizFrame.Windows.Forms.FormState.View;
                    this.dgbar_Table_Order_Detail.DataSource = dsTable_Order_Chitiet;
                    this.dgbar_Table_Order_Detail.DataMember = dsTable_Order_Chitiet.Tables[0].TableName;
                    performReset();
                    this.DisplayInfo();
                    this.FormState =  GoobizFrame.Windows.Forms.FormState.View;
                }
                return success;
            }
            catch (Exception ex)
            {
                if (ex.Message.ToUpper().Contains("DBCONCURRENCYEXCEPTION"))
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("DBCONCURRENCYEXCEPTION", new string[] { });
                }
                else
                     GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message);
                return false;
            }
        }
        #endregion

        void Cal_KhuyenMai()
        {
            foreach (DataRow dr in dsTable_Order_Chitiet.Tables[0].Rows)
            {
                //set giam gia theo khuyen mai
                if (dsCtrinh_Kmai_Chitiet != null
                && dsCtrinh_Kmai_Chitiet.Tables.Count > 0
                && dsCtrinh_Kmai_Chitiet.Tables[0].Rows.Count > 0)
                {
                    DataRow[] sdr = dsCtrinh_Kmai_Chitiet.Tables[0].Select("Id_Hanghoa_Ban=" + dr["Id_Hanghoa_Ban"]);
                    if (sdr != null && sdr.Length > 0)//&& "" + dr["Per_Dongia"] == "")
                        dr["Per_Dongia"] = Convert.ToDecimal("0" + sdr[0]["Per_Dongia"]);
                    else
                        dr["Per_Dongia"] = 0;
                }

            }
        }

        #region Event Handling
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.DisplayInfo2();
        }

        private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if ("" + gridViewDm_Table_Old.GetFocusedRowCellValue("Id_Table_Order") == "")
                gridViewDm_Table_Old.SetFocusedRowCellValue(gridViewDm_Table_Old.Columns["Chon"], false);
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Chon")
            {
                bool chon = false;
                try { chon = Convert.ToBoolean(gridViewDm_Table_Old.GetFocusedRowCellValue(gridViewDm_Table_Old.Columns["Chon"])); }
                catch { }
                if (chon)
                {
                    if ("" + gridViewDm_Table_Old.GetFocusedRowCellValue(gridViewDm_Table_Old.Columns["Id_Nhansu_Order"]) == "")
                    {
                        // GoobizFrame.Windows.Forms.MessageDialog.Show("", "Thông báo");
                        lblStatus_Bar.Text = "Bạn không thể chọn bàn trống";
                        gridViewDm_Table_Old.GetDataRow(gridViewDm_Table_Old.GetDataSourceRowIndex(e.RowHandle)).RejectChanges();
                    }
                }
            }
        }

        #region click vào gridview_Table_Old để chọn bàn cần chuyển

        // chon ban cu de ghep
        void gridViewDm_Table_Old_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = gridViewDm_Table_Old.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                try
                {
                    lblStatus_Bar.Text = "";
                    DataRow drChons_Old2 = gridViewDm_Table_Old.GetDataRow(cardHit.RowHandle);
                    identity_Old = drChons_Old2["Id_Table"];
                    if (drChons_Old2["Id_Booking"] != null && drChons_Old2["Id_Booking"].ToString() != "")
                    {
                        lblStatus_Bar.Text = "Bàn có booking, không được chọn bàn này để ghép";
                        return;
                    }
                    if (drChons_Old2["Lock"].ToString() != "")
                    {
                        if ((bool)drChons_Old2["Lock"])
                        {
                            lblStatus_Bar.Text = "Bàn này đã in hóa đơn, liên hệ với quản lý để thay đổi";
                             GoobizFrame.Windows.Forms.Policy.Authorization.Actions Actions =  GoobizFrame.Windows.MdiUtils.MdiChecker.ShowIDCardLogonWithResult(this);
                            if (Actions.Count == 0 || !Actions.Contains("EnableUnlock"))
                            {
                                lblStatus_Bar.Text = "Tài khoản không hợp lệ";
                                return;
                            }
                            else
                                lblStatus_Bar.Text = "";
                        }
                    }
                    if (dsTable_Order_Old_2.Tables[0].Rows.Count == 0)
                    {
                        dsTable_Order_Old_2.Tables[0].ImportRow(gridViewDm_Table_Old.GetDataRow(cardHit.RowHandle));
                        if (drChons_New == null)
                        {
                            return;
                        }
                        performMerge(position);
                    }
                    else
                    {
                        for (int i = 0; i < dsTable_Order_Old_2.Tables[0].Rows.Count; i++)
                        {
                            if (dsTable_Order_Old_2.Tables[0].Rows[i]["Id_Table_Order"].Equals(gridViewDm_Table_Old.GetDataRow(cardHit.RowHandle)["Id_Table_Order"]))
                            {
                                break;
                            }
                            if (i == dsTable_Order_Old_2.Tables[0].Rows.Count - 1)
                            {
                                dsTable_Order_Old_2.Tables[0].ImportRow(gridViewDm_Table_Old.GetDataRow(cardHit.RowHandle));
                                if (drChons_New == null)
                                {
                                    return;
                                }
                                performMerge(position);
                            }
                        }
                    }
                }
                catch (Exception ex) { GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString()); }
            }
        }
        #endregion

        #region click vào panel table_old_2 để remove table chọn

        void gridViewDm_Table_Old_2_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = gridViewDm_Table_Old_2.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                try
                {
                    lblStatus_Bar.Text = "";
                    object idTableOrder = dsTable_Order_Old_2.Tables[0].Rows[cardHit.RowHandle]["Id_Table_Order"];
                    dsTable_Order_Old_2.Tables[0].Rows.Remove(gridViewDm_Table_Old_2.GetDataRow(cardHit.RowHandle));
                    if (dsTable_Order_Old_2.Tables[0].Rows.Count == 0)
                    {
                        btnSave.Enabled = false;
                    }
                    performRemoveItem(idTableOrder);
                }
                catch (Exception ex) { GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString()); }
            }
        }
        #endregion

        #region click vào cardView_table_New để chọn bàn cần ghép

        // chon ban moi de ghep
        void cardViewDm_Table_New_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.FormState =  GoobizFrame.Windows.Forms.FormState.Edit;
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cardViewDm_Table_New.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                DataRow dr = cardViewDm_Table_New.GetDataRow(cardHit.RowHandle);
                txtTen_Table.Text = "" + dr["Ten_Table"];
                txtVitri.Text = "" + dr["Vitri"];
                lblStatus_Bar.Text = "";
                if (gridViewDm_Table_Old_2.RowCount == 0)
                {
                    lblStatus_Bar.Text = "Bạn phải chọn ít nhất 1 bàn để ghép";
                    return;
                }
                string tableName = dsTable_Order_New.Tables[0].Rows[cardHit.RowHandle]["Ten_Table"].ToString();
                if ( GoobizFrame.Windows.Forms.MessageDialog.Show("Bạn có muốn ghép các bàn đã chọn với bàn " + tableName, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    position = cardHit.RowHandle;
                    performMerge(position);
                }
            }
        }

        void performMerge(int position)
        {
            this.DoClickEndEdit(dgbar_Dm_Table_New); //dgbar_Dm_Table_New.EmbeddedNavigator.Buttons.EndEdit.DoClick();
            drChons_New = cardViewDm_Table_New.GetDataRow(position);
            identity_New2 = drChons_New["Id_Table"];

            if (drChons_New != null)
            {
                if (dsTable_Order_Old_2.Tables[0].Rows.Count == 1) // kiem tra ban dc ghep va ban ghep giong nhau
                {
                    if (identity_New2.Equals(dsTable_Order_Old_2.Tables[0].Rows[0]["Id_Table"]))
                    {
                        lblStatus_Bar.Text = "Không được ghép hai bàn giống nhau";
                        btnSave.Enabled = false;
                        return;
                    }
                }
                btnSave.Enabled = true;
                if ("" + drChons_New["Id_Table_Order"] != "")
                {
                    //ban da co khach --> assign thong tin chung
                    Id_Nhansu_Order_New = drChons_New["Id_Nhansu_Order"];
                    txtTen_Table.EditValue = drChons_New["Ten_Table"];
                    txtVitri.EditValue = drChons_New["Vitri"];
                    //-->show ds mon da chon
                    identity = drChons_New["Id_Table_Order"];
                    dsTable_Order_Chitiet = objBarService.Get_All_Bar_Table_Order_Chitiet_ById_Order(identity).ToDataSet();
                }
                else
                {
                    //ban chon ghep chua co khach    --> assign thong tin chung
                    txtTen_Table.EditValue = drChons_New["Ten_Table"];
                    txtVitri.EditValue = drChons_New["Vitri"];
                    identity = -1;
                    dsTable_Order_Chitiet = objBarService.Get_All_Bar_Table_Order_Chitiet_ById_Order(-1).ToDataSet();
                }
                //chuyen tat ca cac mon sang ban moi
                //drChons_Old = dsTable_Order_Old_2.Tables[0].Select();
                foreach (DataRow s_row in dsTable_Order_Old_2.Tables[0].Rows)
                {
                    try
                    {
                        // if (Convert.ToInt64(s_row["Id_Table_Order"] + "") == Convert.ToInt64(identity)) continue;
                        DataSet dsChitiet = objBarService.Get_All_Bar_Table_Order_Chitiet_ById_Order(s_row["Id_Table_Order"]).ToDataSet();
                        foreach (DataRow d_row in dsChitiet.Tables[0].Rows)
                        {
                            try
                            {
                                DataRow n_row = dsTable_Order_Chitiet.Tables[0].NewRow();
                                foreach (DataColumn col in n_row.Table.Columns)
                                    try
                                    {
                                        n_row[col.ColumnName] = d_row[col.ColumnName];
                                    }
                                    catch { continue; }
                                if (!s_row["Ten_Table"].Equals(drChons_New["Ten_Table"]))
                                {
                                    dsTable_Order_Chitiet.Tables[0].Rows.Add(n_row);
                                    n_row.AcceptChanges();
                                    n_row.SetModified();
                                    n_row["Ghichu"] = n_row["Ghichu"]
                                        + " >> Ghép : " + "từ: " + s_row["Ten_Table"]
                                        + " đến: " + drChons_New["Ten_Table"];
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
                //show data on gridview
                this.dgbar_Table_Order_Detail.DataSource = dsTable_Order_Chitiet;
                this.dgbar_Table_Order_Detail.DataMember = dsTable_Order_Chitiet.Tables[0].TableName;
            }
            else
            {
                lblStatus_Bar.Text = "Bạn phải chọn ít nhất 1 bàn để ghép";
            }
        }

        void performRemoveItem(object idTableOrder)
        {
            drChons_Old = dsTable_Order_Old_2.Tables[0].Select();
            if (drChons_Old.Length == 0)
            {
                dsTable_Order_Chitiet = objBarService.Get_All_Bar_Table_Order_Chitiet_ById_Order(identity).ToDataSet();
                dsTable_Order_Chitiet.AcceptChanges();
            }
            foreach (DataRow s_row in drChons_Old)
            {
                // if (Convert.ToInt64(s_row["Id_Table_Order"] + "") == Convert.ToInt64(identity)) continue;
                DataSet dsChitiet = objBarService.Get_All_Bar_Table_Order_Chitiet_ById_Order(idTableOrder).ToDataSet();
                for (int i = 0; i < dsTable_Order_Chitiet.Tables[0].Rows.Count; i++)
                {
                    for (int x = 0; x < dsChitiet.Tables[0].Rows.Count; x++)
                    {
                        if (!drChons_New["Id_Table_Order"].Equals(idTableOrder))
                        {
                            if (dsTable_Order_Chitiet.Tables[0].Rows[i]["Id_Table_Order"].Equals(dsChitiet.Tables[0].Rows[x]["Id_Table_Order"]))
                            {
                                dsTable_Order_Chitiet.Tables[0].Rows[i].Delete();
                                dsTable_Order_Chitiet.AcceptChanges();
                                //  dsTable_Order_Chitiet.SetModified();
                            }
                        }
                    }
                }
                if (dsTable_Order_Old_2.Tables[0].Rows[0]["Id_Table_Order"].Equals(drChons_New["Id_Table_Order"])
                    && dsTable_Order_Old_2.Tables[0].Rows.Count == 1)
                {
                    lblStatus_Bar.Text = "Không được ghép 2 bàn giống nhau";
                    btnSave.Enabled = false;
                    return;
                }
            }
            //show data on gridview
            this.dgbar_Table_Order_Detail.DataSource = dsTable_Order_Chitiet;
            this.dgbar_Table_Order_Detail.DataMember = dsTable_Order_Chitiet.Tables[0].TableName;
        }

        void performReset()
        {
            dsTable_Order_Old_2.Clear();
            dsTable_Order_Chitiet.Clear();
            drChons_Old = null;
            drChons_New = null;
            identity_Old = null;
            identity = null;
            identity_New2 = null;
            txtTen_Table.Text = "";
            txtVitri.Text = "";
        }

        #endregion

        #region các button: <<, >>,save, ghép bàn, bỏ qua,...
        private void btnBack1_Click(object sender, EventArgs e)
        {
            gridViewDm_Table_Old.MovePrevPage();
        }

        private void btnNext1_Click(object sender, EventArgs e)
        {
            gridViewDm_Table_Old.MoveNextPage();
        }

        void btnNext2_Click(object sender, System.EventArgs e)
        {
            cardViewDm_Table_New.MoveNextPage();
        }

        void btnBack2_Click(object sender, System.EventArgs e)
        {
            cardViewDm_Table_New.MovePrevPage();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (identity_New2 == null)
            {          
                lblStatus_Bar.Text = "Bạn chưa chọn bàn để ghép";
                return;
            }
            PerformSave();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            PerformCancel();
            PerformClose();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ChangeFormState( GoobizFrame.Windows.Forms.FormState.View);
            PerformClose();
        }

        

        #endregion

        private void btnBackDetail_Click(object sender, EventArgs e)
        {
            gridView2.MovePrevPage();
        }

        private void btnNextDetail_Click(object sender, EventArgs e)
        {
            gridView2.MoveNextPage();
        }

        private void btn_Deny_Click(object sender, EventArgs e)
        {
            this.FormState =  GoobizFrame.Windows.Forms.FormState.View;
            txtTen_Table.Text = "";
            txtVitri.Text = "";
            drChons_New = null;
            drChons_Old = null;
            PerformCancel();
        }
        #endregion

        private void btnBack_Khuvuc_Click(object sender, EventArgs e)
        {
            cvBar_Dm_Khuvuc.MovePrevPage();
        }

        private void btnNext_Khuvuc_Click(object sender, EventArgs e)
        {
            cvBar_Dm_Khuvuc.MoveNextPage();
        }

        private void btnBack_Khuvuc_2_Click(object sender, EventArgs e)
        {
            cvBar_Dm_Khuvuc_2.MovePrevPage();

        }

        private void btnNext_Khuvuc_2_Click(object sender, EventArgs e)
        {
            cvBar_Dm_Khuvuc_2.MoveNextPage();

        }

        private void cvBar_Dm_Khuvuc_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cvBar_Dm_Khuvuc.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                var id_khuvuc = cvBar_Dm_Khuvuc.GetRowCellValue(cardHit.RowHandle, "Id_Khuvuc");
                gridViewDm_Table_Old.Columns["Id_Khuvuc"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                        gridViewDm_Table_Old.Columns["Id_Khuvuc"],
                        id_khuvuc
                        );
                styleFormatCondition_Kv1.Value1 = Convert.ToInt32(id_khuvuc);
            }
        }

        private void cvBar_Dm_Khuvuc_2_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cvBar_Dm_Khuvuc_2.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                var id_khuvuc = cvBar_Dm_Khuvuc_2.GetRowCellValue(cardHit.RowHandle, "Id_Khuvuc");
                cardViewDm_Table_New.Columns["Id_Khuvuc"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                        cardViewDm_Table_New.Columns["Id_Khuvuc"],
                        id_khuvuc
                        );
                styleFormatCondition_Kv2.Value1 = Convert.ToInt32( id_khuvuc );
            }
        }

        void MakeConditionForSelectedRowKhuvuc()
        {
            //cvBar_Dm_Khuvuc
            this.cvBar_Dm_Khuvuc.FormatConditions.Clear();
            styleFormatCondition_Kv1 = new DevExpress.XtraGrid.StyleFormatCondition();
            styleFormatCondition_Kv1.Appearance.BackColor = System.Drawing.Color.MidnightBlue;
            styleFormatCondition_Kv1.Appearance.ForeColor = System.Drawing.Color.White;
            styleFormatCondition_Kv1.Appearance.Options.UseBackColor = true;
            styleFormatCondition_Kv1.Appearance.Options.UseForeColor = true;
            styleFormatCondition_Kv1.ApplyToRow = true;
            styleFormatCondition_Kv1.Column = this.cvBar_Dm_Khuvuc.Columns["Id_Khuvuc"];
            styleFormatCondition_Kv1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition_Kv1.Value1 = long.MaxValue;
            this.cvBar_Dm_Khuvuc.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
                    styleFormatCondition_Kv1});

            //cvBar_Dm_Khuvuc_2
            this.cvBar_Dm_Khuvuc_2.FormatConditions.Clear();
            styleFormatCondition_Kv2 = new DevExpress.XtraGrid.StyleFormatCondition();
            styleFormatCondition_Kv2.Appearance.BackColor = System.Drawing.Color.MidnightBlue;
            styleFormatCondition_Kv2.Appearance.ForeColor = System.Drawing.Color.White;
            styleFormatCondition_Kv2.Appearance.Options.UseBackColor = true;
            styleFormatCondition_Kv2.Appearance.Options.UseForeColor = true;
            styleFormatCondition_Kv2.ApplyToRow = true;
            styleFormatCondition_Kv2.Column = this.cvBar_Dm_Khuvuc_2.Columns["Id_Khuvuc"];
            styleFormatCondition_Kv2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition_Kv2.Value1 = long.MaxValue;
            this.cvBar_Dm_Khuvuc_2.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
                    styleFormatCondition_Kv2});
        }

    }
}

