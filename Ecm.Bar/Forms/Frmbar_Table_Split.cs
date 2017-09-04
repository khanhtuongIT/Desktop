using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using System.Collections;

namespace Ecm.Bar.Forms
{
    public partial class Frmbar_Table_Split :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        Ecm.WebReferences.Classes.BarService objBarService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.BarService>();
        Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        DataSet dsTable_Order_Old = new DataSet();
        DataSet dsTable_Order_New = new DataSet();
        DataSet dsTable_Order_Chitiet = new DataSet();
        DataSet dsTable_OldOrder_Chitiet = new DataSet();
        DataSet dsCtrinh_Kmai_Chitiet;
        DataSet dsNhansu_Order;
        DataSet ds_Hanghoa_Ban;
        DataRow drChons_Old;
        DataRow drChons_New;
        System.Collections.Hashtable hashDataset = new System.Collections.Hashtable();
        object identity = null;
        object old_identity = null;

        DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition_Kv1;
        DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition_Kv2;

        #region local data
       
        DataSet dsSys_Lognotify = null;
        string xml_WARE_DM_HANGHOA_BAN = @"Resources\localdata\Ware_Dm_Hanghoa_Ban.xml";
        string xml_REX_NHANSU = @"Resources\localdata\Rex_Nhansu.xml";
        DateTime dtlc_ware_dm_hanghoa_ban;
        DateTime dtlc_rex_nhansu;

        #endregion

        public Frmbar_Table_Split()
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

        #region display,binding , changeStatus

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
             * */
            #endregion

            /*
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

             */

            ds_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
            dsNhansu_Order = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();

            dsCtrinh_Kmai_Chitiet = objWareService.Get_All_Ware_Ctrinh_Kmai_Chitiet_ByDate(objBarService.GetServerDateTime()).ToDataSet();
            gridLookUp_Nhansu_Order.DataSource = dsNhansu_Order.Tables[0];
            //gridLookUpEdit_Hanghoa_Ban
            gridLookUp_Hanghoa_Ban_Table_New.DataSource = ds_Hanghoa_Ban.Tables[0];
            gridLookUp_Hanghoa_Ban_Table_Old.DataSource = ds_Hanghoa_Ban.Tables[0];
        }

        public override void DisplayInfo()
        {
            try
            {
                if (this.FormState !=  GoobizFrame.Windows.Forms.FormState.View)
                    return;

                lblStatus_Bar.Text = "";
                btnSave.Enabled = false;
                LoadMasterData();
                object Id_Cuahang_Ban =  GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocation("Id_Cuahang_Ban");
                this.dsTable_Order_Old = objBarService.Get_All_Bar_Table_Order(true, Id_Cuahang_Ban).ToDataSet();
                this.dsTable_Order_Old.Tables[0].Columns.Add("Chon", typeof(Boolean));
                dgbar_Dm_Table_Old.DataSource = dsTable_Order_Old;
                dgbar_Dm_Table_Old.DataMember = dsTable_Order_Old.Tables[0].TableName;

                DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition = new DevExpress.XtraGrid.StyleFormatCondition();
                styleFormatCondition.Appearance.BackColor = Color.CornflowerBlue;
                styleFormatCondition.Appearance.Options.UseBackColor = true;
                styleFormatCondition.ApplyToRow = true;
                styleFormatCondition.Column = this.cvDm_Table_Old.Columns["Id_Table_Order"];
                styleFormatCondition.Condition = DevExpress.XtraGrid.FormatConditionEnum.Greater;
                styleFormatCondition.Value1 = 0;
                this.cvDm_Table_Old.FormatConditions.Add(styleFormatCondition);

                //this.dsTable_Order_New = objBarService.Get_All_Bar_Table_Order(null);               
                //dgbar_Dm_Table
                this.dsTable_Order_New = objBarService.Get_All_Bar_Table_Order_By_Id_Cuahang(Id_Cuahang_Ban).ToDataSet();
                dgbar_Dm_Table_New.DataSource = dsTable_Order_New;
                dgbar_Dm_Table_New.DataMember = dsTable_Order_New.Tables[0].TableName;
                this.cvDm_Table_New.FormatConditions.Add(styleFormatCondition); // apply format same with dgbar_Dm_Table_Old

                DataSet dsBar_Dm_Khuvuc = objMasterService.Get_All_Bar_Dm_Khuvuc_ByCuahang(new WebReferences.MasterService.Bar_Dm_Khuvuc() { 
                Id_Cuahang_Ban = Id_Cuahang_Ban,
                }).ToDataSet();
                dgBar_Dm_Khuvuc.DataSource = dsBar_Dm_Khuvuc.Tables[0];
                dgBar_Dm_Khuvuc_2.DataSource = dsBar_Dm_Khuvuc.Tables[0];

                btnBackDetail.Visible = false;
                btnNextDetail.Visible = false;
                btnNextResult.Visible = false;
                btnBackResult.Visible = false;
                btnChuyen_Ban.Visible = false;
                this.ChangeStatus(false);
                this.ChangeFormState( GoobizFrame.Windows.Forms.FormState.View);
            }
            catch (Exception ex)
            {
                 GoobizFrame.Windows.Forms.MessageDialog.Show(ex.ToString());
            }
        }

        void DisplayInfo2()
        {
            //panelControl_SelectOldTable.Visible = true;
            //panelControl_SelectOldTable.Dock = DockStyle.Fill;
            //panelControl_SelectNewTable.Visible = true;
            //panelControl_ViewResult.Visible = true;
            //panelControl_OldDetail.Visible = false;
        }

        public override void  DataBindingControl()
        {
            try
            {
                this.txtVitri_New.DataBindings.Clear();
                this.txtTen_Table_New.DataBindings.Clear();
                this.txtTen_Table_Old.DataBindings.Clear();
                this.txtVitri_Old.DataBindings.Clear();
                this.txtTen_Table_New.DataBindings.Add("EditValue", dsTable_Order_New, dsTable_Order_New.Tables[0].TableName + ".Ten_Table");
                this.txtVitri_New.DataBindings.Add("EditValue", dsTable_Order_New, dsTable_Order_New.Tables[0].TableName + ".ViTri");
                this.txtTen_Table_Old.DataBindings.Add("EditValue", dsTable_Order_Old, dsTable_Order_Old.Tables[0].TableName + ".Ten_Table");
                this.txtVitri_Old.DataBindings.Add("EditValue", dsTable_Order_Old, dsTable_Order_Old.Tables[0].TableName + ".ViTri");                
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
            lblStatus_Bar.Text = "";
            this.dgbar_Dm_Table_Old.Enabled = !editTable; 
            this.gridView2.OptionsBehavior.Editable = editTable;
        }

        #endregion

        #region Event Override
        public override bool PerformEdit()
        {
            if ("" + cvDm_Table_Old.GetFocusedRowCellValue("Id_Table_Order") == "")
                return false;
            this.ChangeStatus(true);
            return true;
        }

        public override bool PerformCancel()
        {
            this.DisplayInfo();
            this.FormState =  GoobizFrame.Windows.Forms.FormState.View;
            return true;
        }

        public override bool PerformSave()
        {
            try
            {
                this.DoClickEndEdit(dgbar_Table_Order_Detail); // dgbar_Table_Order_Detail.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                bool success = true;


                #region Lưu Old Order

                //Duyệt trên mỗi bàn được chọn để tách món (OldOrder)
                foreach (DictionaryEntry obj in hashDataset)
                {
                    Ecm.WebReferences.BarService.Bar_Table_Order bar_Table_Order = new Ecm.WebReferences.BarService.Bar_Table_Order();
                    dsTable_OldOrder_Chitiet = (DataSet)hashDataset[obj.Key];
                    //Cal_KhuyenMai_Table_Old();
                    foreach (DataRow dr in dsTable_OldOrder_Chitiet.Tables[0].Rows)
                    {
                        if (dr.RowState != DataRowState.Deleted)
                        {
                            dr["Thanhtien"] = Convert.ToDecimal(dr["Soluong"]) * Convert.ToDecimal(dr["Dongia"]);
                            dr["Thanhtien_Km"] = DBNull.Value;
                            dr["Per_Dongia"] = DBNull.Value;
                        }
                    }
                    objBarService.Update_Bar_Table_Order_Chitiet_Collection(dsTable_OldOrder_Chitiet);

                    dsTable_OldOrder_Chitiet.AcceptChanges();
                    if (dsTable_OldOrder_Chitiet.Tables[0].Rows.Count == 0)
                    {
                        bar_Table_Order.Id_Table_Order = obj.Key;
                        objBarService.Delete_Bar_Table_Order(bar_Table_Order);
                    }
                    else
                    {
                        DataRow[] drs = dsTable_Order_Old.Tables[0].Select("Id_Table_Order = " + obj.Key);
                        Ecm.WebReferences.BarService.Bar_Table_Order bar_Table_Order_Old = new Ecm.WebReferences.BarService.Bar_Table_Order();
                        bar_Table_Order_Old.Id_Table_Order = drs[0]["Id_Table_Order"];
                        bar_Table_Order_Old.Id_Ca_Lamviec = drs[0]["Id_Ca_Lamviec"];
                        bar_Table_Order_Old.Id_Cuahang_Ban = drs[0]["Id_Cuahang_Ban"];
                        bar_Table_Order_Old.Id_Khachhang = ("" + drs[0]["Id_Khachhang"] != "") ? drs[0]["Id_Khachhang"] : null; 
                        bar_Table_Order_Old.Id_Nhansu_Bill = null;
                        bar_Table_Order_Old.Id_Nhansu_Casher = null;
                        bar_Table_Order_Old.Id_Nhansu_Km = ("" + drs[0]["Id_Nhansu_Km"] != "") ? drs[0]["Id_Nhansu_Km"] : null;
                        bar_Table_Order_Old.Id_Nhansu_Order = drs[0]["Id_Nhansu_Order"]; //Convert.ToInt64( GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
                        bar_Table_Order_Old.Id_Table = drs[0]["Id_Table"];
                        bar_Table_Order_Old.Ngay_Order = drs[0]["Ngay_Order"];
                        bar_Table_Order_Old.Sochungtu = drs[0]["Sochungtu"];
                        bar_Table_Order_Old.Sotien = null;

                        objBarService.Update_Bar_Table_Order(bar_Table_Order_Old);
                    }         
                }

                #endregion

                #region Lưu New Order
                //neu bàn đã dc đặt thì ghép tất cả hh
                if ("" + identity == "") //nếu bàn mới chọn là bàn mới thì ghép hh sang bàn mới
                {
                    Ecm.WebReferences.BarService.Bar_Table_Order bar_Table_Order = new Ecm.WebReferences.BarService.Bar_Table_Order();
                    bar_Table_Order.Id_Table_Order = -1;
                    try
                    {
                        bar_Table_Order.Id_Ca_Lamviec = -1;// objWareService.Get_All_Ware_Dm_Ca_Lamviec_ByHours(DateTime.Now).Tables[0].Rows[0]["Id_Ca_Lamviec"];
                    }
                    catch { }
                    bar_Table_Order.Id_Nhansu_Order = Convert.ToInt64( GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
                    bar_Table_Order.Id_Cuahang_Ban = drChons_Old["Id_Cuahang_Ban"];//Convert.ToInt64( GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());

                    bar_Table_Order.Id_Table = drChons_New["Id_Table"];
                    bar_Table_Order.Ngay_Order = objBarService.GetServerDateTime();
                    bar_Table_Order.Sochungtu = "" + objWareService.GetNew_Sochungtu("bar_table_order", "sochungtu", "ORD");
                    //tạo bàn mới
                    identity = objBarService.Insert_Bar_Table_Order(bar_Table_Order);
                }
                else
                {
                    Ecm.WebReferences.BarService.Bar_Table_Order bar_Table_Order = new Ecm.WebReferences.BarService.Bar_Table_Order();
                    bar_Table_Order.Id_Table_Order = identity;
                    DataRow[] drs2 = dsTable_Order_Old.Tables[0].Select("Id_Table_Order = " + identity); ;
                    bar_Table_Order.Id_Nhansu_Bill = null;
                    bar_Table_Order.Sotien = null;
                    bar_Table_Order.Id_Ca_Lamviec = -1; //objWareService.Get_All_Ware_Dm_Ca_Lamviec_ByHours(DateTime.Now).Tables[0].Rows[0]["Id_Ca_Lamviec"];
                    bar_Table_Order.Id_Nhansu_Order = drs2[0]["Id_Nhansu_Order"];//Convert.ToInt64( GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
                    bar_Table_Order.Id_Cuahang_Ban = drChons_Old["Id_Cuahang_Ban"];//Convert.ToInt64( GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
                    bar_Table_Order.Id_Table = drChons_New["Id_Table"];
                    bar_Table_Order.Id_Khachhang = -1;
                    bar_Table_Order.Ngay_Order = objBarService.GetServerDateTime();
                    bar_Table_Order.Sochungtu = drChons_Old["Sochungtu"];
                    //update bàn cũ
                    objBarService.Update_Bar_Table_Order(bar_Table_Order);
                }

                //lưu ds món trong bàn mới
                foreach (DataRow dr in dsTable_Order_Chitiet.Tables[0].Rows)
                {
                    dr["Thanhtien_Km"] = DBNull.Value;
                    dr["Per_Dongia"] = DBNull.Value;
                    dr["Id_Table_Order"] = identity;
                }    
  
                objBarService.Update_Bar_Table_Order_Chitiet_Collection(dsTable_Order_Chitiet);
                #endregion

                if (success)
                {
                    lblStatus_Bar.Text = "Đã tách bàn thành công";
                    this.FormState =  GoobizFrame.Windows.Forms.FormState.View;
                    this.DisplayInfo();
                    dsTable_Order_Chitiet.Clear();
                    dsTable_OldOrder_Chitiet.Clear();
                    dgbar_OldTable_Order_Detail.DataSource = dsTable_OldOrder_Chitiet;
                    hashDataset.Clear();
                    dgbar_Dm_Table_New.Enabled = true;
                    this.FormState =  GoobizFrame.Windows.Forms.FormState.View;
                    identity = null;
                    resetText();
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
                     GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(),"");
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

        #region Click vào gridview --> move món ăn

       
        /// <summary>
        /// click gridButton_Go
        /// move item to new table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (txtTen_Table_New.Text != "")
                {
                    if (old_identity.Equals(identity))
                    {
                        lblStatus_Bar.Text = "Bàn cũ và bàn mới trùng nhau nên không tách chuyển được";
                        return;
                    }

                    decimal soluong_goc = 0;
                    decimal soluong_phucvu = 0;
                    decimal Soluong_Phucvu_Chuyen = 0;
                    decimal Soluong_Chuyen = 0;
                    decimal.TryParse("" + gvbar_OldTable_Order_Detail.GetDataRow(gvbar_OldTable_Order_Detail.FocusedRowHandle)["Soluong"], out soluong_goc);
                    decimal.TryParse("" + gvbar_OldTable_Order_Detail.GetDataRow(gvbar_OldTable_Order_Detail.FocusedRowHandle)["Soluong_Phucvu"], out soluong_phucvu);
                    decimal.TryParse("" + gvbar_OldTable_Order_Detail.GetDataRow(gvbar_OldTable_Order_Detail.FocusedRowHandle)["Soluong_Phucvu_Chuyen"], out Soluong_Phucvu_Chuyen);
                    decimal.TryParse("" + gvbar_OldTable_Order_Detail.GetDataRow(gvbar_OldTable_Order_Detail.FocusedRowHandle)["Soluong_Chuyen"], out Soluong_Chuyen);

                    if (Convert.ToInt32("0" + gvbar_OldTable_Order_Detail.GetDataRow(gvbar_OldTable_Order_Detail.FocusedRowHandle)["Soluong_Chuyen"]) == 0)
                    {
                        lblStatus_Bar.Text = "Số lượng chuyển không được bằng 0";
                        gvbar_OldTable_Order_Detail.SetFocusedRowCellValue(gvbar_OldTable_Order_Detail.Columns["Soluong_Chuyen"], soluong_goc);
                        return;
                    }
                    if (!check_Soluong_Chuyendi(gvbar_OldTable_Order_Detail.FocusedRowHandle, gvbar_OldTable_Order_Detail.FocusedColumn))
                    {
                        gvbar_OldTable_Order_Detail.SetFocusedRowCellValue(gvbar_OldTable_Order_Detail.Columns["Soluong_Chuyen"], soluong_goc);
                        gvbar_OldTable_Order_Detail.RefreshRow(gvbar_OldTable_Order_Detail.FocusedRowHandle);
                        return;
                    }
                    // check so luong PV chuyen di voi so luong phuc vu

                    if (soluong_phucvu - Soluong_Phucvu_Chuyen + Soluong_Chuyen > soluong_goc)
                    {
                        lblStatus_Bar.Text = "Có lỗi, số lượng món ăn không đúng, kiểm tra lại";
                        return;
                    }
                    if (Soluong_Phucvu_Chuyen > Soluong_Chuyen)
                    {
                        gvbar_OldTable_Order_Detail.SetFocusedRowCellValue(gvbar_OldTable_Order_Detail.Columns["Soluong_Phucvu_Chuyen"], gvbar_OldTable_Order_Detail.GetFocusedRowCellValue(gvbar_OldTable_Order_Detail.Columns["Soluong_Chuyen"]));
                        gvbar_OldTable_Order_Detail.RefreshRow(gvbar_OldTable_Order_Detail.FocusedRowHandle);
                    }

                    DataRow ndr = dsTable_Order_Chitiet.Tables[0].NewRow();
                    DataRow sdrOrder_Detail = (DataRow)gvbar_OldTable_Order_Detail.GetDataRow(gvbar_OldTable_Order_Detail.FocusedRowHandle);

                    ndr["Ngay_Order"]               = sdrOrder_Detail["Ngay_Order"];
                    ndr["Id_Hanghoa_Ban"]           = sdrOrder_Detail["Id_Hanghoa_Ban"];
                    ndr["Id_Table_Order_Chitiet"]   = sdrOrder_Detail["Id_Table_Order_Chitiet"];
                    ndr["Soluong"]                  = Convert.ToInt64(sdrOrder_Detail["Soluong_Chuyen"]);
                    ndr["Id_Table_Old"]             = drChons_Old["Id_Table_Order"];
                    ndr["Dongia"]                   = sdrOrder_Detail["Dongia"];
                    ndr["Id_Khachhang"]             = sdrOrder_Detail["Id_Khachhang"];
                    ndr["Thanhtien"]                = Convert.ToDecimal(ndr["Dongia"]) * Convert.ToDecimal(ndr["Soluong"]);
                    ndr["Soluong_Phucvu"]           = sdrOrder_Detail["Soluong_Phucvu_Chuyen"];
                    ndr["Soluong_Phucvu_Chuyen"]    = sdrOrder_Detail["Soluong_Phucvu_Chuyen"];
                    ndr["Id_Donvitinh"]             = sdrOrder_Detail["Id_Donvitinh"];
                    ndr["Id_Nhansu_Order"]          = sdrOrder_Detail["Id_Nhansu_Order"]; //lưu id nhân sự order trên món ăn
                    if (ndr["Soluong"].Equals(ndr["Soluong_Phucvu"]))
                        ndr["Served"] = true;
                    else
                        ndr["Served"] = sdrOrder_Detail["Served"];
                    ndr["Ten_Table_Old"] = drChons_Old["Ten_Table"];
                    ndr["Ghichu"] = sdrOrder_Detail["Ghichu"]
                                    + ">>Chuyển từ " + drChons_Old["Ten_Table"]
                                    + " sang " + drChons_New["Ten_Table"];

                    //use in Bar_Kitchen_Order_Chitiet
                    ndr["Guid_Octiet"]                  = sdrOrder_Detail["Guid_Octiet"];
                    ndr["Id_Table_Order_Chitiet_Old"]   = sdrOrder_Detail["Id_Table_Order_Chitiet"];

                    dgbar_Dm_Table_New.Enabled = false;
                    bool check = false;
                    for (int i = 0; i < dsTable_Order_Chitiet.Tables[0].Rows.Count; i++)
                    {
                        if (dsTable_Order_Chitiet.Tables[0].Rows[i]["Id_Table_Order_Chitiet"].Equals(gvbar_OldTable_Order_Detail.GetRowCellValue(gvbar_OldTable_Order_Detail.FocusedRowHandle, "Id_Table_Order_Chitiet")))
                        {
                            object value = Convert.ToInt32(dsTable_Order_Chitiet.Tables[0].Rows[i]["Soluong"]) + Convert.ToInt32(ndr["Soluong"]);
                            object value_PV = Convert.ToInt32(dsTable_Order_Chitiet.Tables[0].Rows[i]["Soluong_Phucvu"]) + Convert.ToInt32(ndr["Soluong_Phucvu"]);
                            dsTable_Order_Chitiet.Tables[0].Rows[i]["Soluong_Phucvu"] = value_PV;
                            dsTable_Order_Chitiet.Tables[0].Rows[i]["Soluong"] = value;
                            dsTable_Order_Chitiet.Tables[0].Rows[i]["Thanhtien"] = Convert.ToDecimal(value) * Convert.ToDecimal(dsTable_Order_Chitiet.Tables[0].Rows[i]["Dongia"]);
                            check = true;
                            break;
                        }
                    }
                    lblStatus_Bar.Text = "Để chọn bàn khác cần chuyển đến, click vào nút 'Bỏ qua' ";
                    btnSave.Enabled = true;
                    if (!check)
                        dsTable_Order_Chitiet.Tables[0].Rows.Add(ndr);
                    // check neu so luong = so luong chuyen di -->  delete record
                    if (Convert.ToInt64(gvbar_OldTable_Order_Detail.GetDataRow(gvbar_OldTable_Order_Detail.FocusedRowHandle)["Soluong_Chuyen"]) == Convert.ToInt64(gvbar_OldTable_Order_Detail.GetDataRow(gvbar_OldTable_Order_Detail.FocusedRowHandle)["Soluong"]))
                    {
                        gvbar_OldTable_Order_Detail.GetDataRow(gvbar_OldTable_Order_Detail.FocusedRowHandle).Delete();
                    }
                    else // cap nhat lai  record so luong
                    {
                        gvbar_OldTable_Order_Detail.SetFocusedRowCellValue(gvbar_OldTable_Order_Detail.Columns["Soluong"], Convert.ToInt32(gvbar_OldTable_Order_Detail.GetFocusedRowCellValue("Soluong")) - Convert.ToInt32(gvbar_OldTable_Order_Detail.GetFocusedRowCellValue("Soluong_Chuyen")));
                        gvbar_OldTable_Order_Detail.SetFocusedRowCellValue(gvbar_OldTable_Order_Detail.Columns["Soluong_Chuyen"], Convert.ToInt32(gvbar_OldTable_Order_Detail.GetFocusedRowCellValue("Soluong")));
                        if (gvbar_OldTable_Order_Detail.Columns["Soluong_Phucvu"] == gvbar_OldTable_Order_Detail.Columns["Soluong"] && gvbar_OldTable_Order_Detail.Columns["Soluong_Phucvu"] == gvbar_OldTable_Order_Detail.Columns["Soluong_Phucvu_Chuyen"])
                        {
                            gvbar_OldTable_Order_Detail.SetFocusedRowCellValue(gvbar_OldTable_Order_Detail.Columns["Soluong_Phucvu"], 0);
                            gvbar_OldTable_Order_Detail.SetFocusedRowCellValue(gvbar_OldTable_Order_Detail.Columns["Soluong_Phucvu_Chuyen"], gvbar_OldTable_Order_Detail.GetFocusedRowCellValue("Soluong_Phucvu"));
                        }
                        else
                        {
                            gvbar_OldTable_Order_Detail.SetFocusedRowCellValue(gvbar_OldTable_Order_Detail.Columns["Soluong_Phucvu"], Convert.ToInt32(gvbar_OldTable_Order_Detail.GetFocusedRowCellValue("Soluong_Phucvu")) - Convert.ToInt32(gvbar_OldTable_Order_Detail.GetFocusedRowCellValue("Soluong_Phucvu_Chuyen")));
                            gvbar_OldTable_Order_Detail.SetFocusedRowCellValue(gvbar_OldTable_Order_Detail.Columns["Soluong_Phucvu_Chuyen"], gvbar_OldTable_Order_Detail.GetFocusedRowCellValue("Soluong_Phucvu"));
                        }
                    }
                    if (gvbar_OldTable_Order_Detail.RowCount != 0)
                    {
                        if (gvbar_OldTable_Order_Detail.GetFocusedRowCellValue("Soluong").Equals(gvbar_OldTable_Order_Detail.GetFocusedRowCellValue("Soluong_Phucvu")))
                            gvbar_OldTable_Order_Detail.SetFocusedRowCellValue(gvbar_OldTable_Order_Detail.Columns["Served"], true);
                    }
                    if (hashDataset[old_identity] != null)
                    {
                        hashDataset.Remove(old_identity);
                        hashDataset.Add(old_identity, dsTable_OldOrder_Chitiet);
                    }
                    else
                        hashDataset.Add(old_identity, dsTable_OldOrder_Chitiet);
                    //}
                    if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.View)
                        this.FormState =  GoobizFrame.Windows.Forms.FormState.Edit;
                }
                else
                    //MessageBox.Show("");
                    lblStatus_Bar.Text = "Chưa chọn bàn mới";
            }
            catch (Exception ex) { GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString()); }
        }

        // click to move item back 
        void gridView2_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo gridHit = gridView2.CalcHitInfo(e.X, e.Y);
            if (gridHit.InRowCell && gridHit.Column.ColumnEditName == "gridButton_Back")
            {
                //check item thuoc ve bàn nào, neu la bàn cũ thì đc phép trả về      
                if (!gridView2.GetDataRow(gridHit.RowHandle)["Id_Table_Old"].ToString().Equals(""))
                {
                    dsTable_OldOrder_Chitiet = (DataSet)hashDataset[dsTable_Order_Chitiet.Tables[0].Rows[gridHit.RowHandle]["Id_Table_Old"]];
                    // check if Id_hanghoa_ban exist --> update soluong
                    for (int i = 0; i < dsTable_OldOrder_Chitiet.Tables[0].Rows.Count; i++)
                    {
                        if (dsTable_OldOrder_Chitiet.Tables[0].Rows[i].RowState != DataRowState.Deleted)
                        {
                            if (dsTable_OldOrder_Chitiet.Tables[0].Rows[i]["Id_Table_Order_Chitiet"].Equals(gridView2.GetDataRow(gridHit.RowHandle)["Id_Table_Order_Chitiet"]))
                            {
                                DataRow ndr2 = (DataRow)dsTable_OldOrder_Chitiet.Tables[0].Rows[i];
                                ndr2["Id_Hanghoa_Ban"] = gridView2.GetRowCellValue(gridHit.RowHandle, "Id_Hanghoa_Ban");
                                ndr2["Soluong"] = Convert.ToInt32(gridView2.GetDataRow(gridHit.RowHandle)["Soluong"]) + Convert.ToInt32(dsTable_OldOrder_Chitiet.Tables[0].Rows[i]["Soluong"]);
                                ndr2["Id_Table_Order_Chitiet"] = Convert.ToInt64(gridView2.GetDataRow(gridHit.RowHandle)["Id_Table_Order_Chitiet"]);
                                ndr2["Soluong_Chuyen"] = ndr2["Soluong"];
                                ndr2["Id_Table_Order"] = gridView2.GetDataRow(gridHit.RowHandle)["Id_Table_Old"];
                                ndr2["Ten_Table_Old"] = gridView2.GetDataRow(gridHit.RowHandle)["Ten_Table_Old"];
                                ndr2["Id_Khachhang"] = gridView2.GetDataRow(gridHit.RowHandle)["Id_Khachhang"];
                                ndr2["Dongia"] = gridView2.GetDataRow(gridHit.RowHandle)["Dongia"];
                                ndr2["Thanhtien"] = gridView2.GetDataRow(gridHit.RowHandle)["Thanhtien"];
                                ndr2["Soluong_Phucvu"] = Convert.ToInt32(gridView2.GetDataRow(gridHit.RowHandle)["Soluong_Phucvu"]) + Convert.ToInt32(dsTable_OldOrder_Chitiet.Tables[0].Rows[i]["Soluong_Phucvu"]);
                                ndr2["Soluong_Phucvu_Chuyen"] = ndr2["Soluong_Phucvu"];
                                ndr2["Ngay_Order"] = gridView2.GetRowCellValue(gridHit.RowHandle, "Ngay_Order");
                                ndr2["Id_Nhansu_Order"] = gridView2.GetRowCellValue(gridHit.RowHandle, "Id_Nhansu_Order");
                                ndr2["Id_Donvitinh"] = gridView2.GetRowCellValue(gridHit.RowHandle, "Id_Donvitinh");
                                object newValue = Convert.ToInt32(gridView2.GetDataRow(gridHit.RowHandle)["Soluong"]) + Convert.ToInt32(dsTable_OldOrder_Chitiet.Tables[0].Rows[i]["Soluong"]);
                                txtTen_Table_Old.Text = ndr2["Ten_Table_Old"].ToString();
                                dsTable_Order_Chitiet.Tables[0].Rows[gridHit.RowHandle].Delete();
                                dgbar_OldTable_Order_Detail.DataSource = dsTable_OldOrder_Chitiet;
                                return;
                            }
                        }
                    }
                    DataRow ndr = dsTable_OldOrder_Chitiet.Tables[0].NewRow();
                    ndr["Id_Hanghoa_Ban"] = gridView2.GetRowCellValue(gridHit.RowHandle, "Id_Hanghoa_Ban");
                    ndr["Soluong"] = Convert.ToInt32(gridView2.GetDataRow(gridHit.RowHandle)["Soluong"]);
                    ndr["Id_Table_Order_Chitiet"] = Convert.ToInt64(gridView2.GetDataRow(gridHit.RowHandle)["Id_Table_Order_Chitiet"]);
                    ndr["Soluong_Chuyen"] = ndr["Soluong"];
                    ndr["Id_Table_Order"] = gridView2.GetDataRow(gridHit.RowHandle)["Id_Table_Old"];
                    ndr["Id_Khachhang"] = gridView2.GetDataRow(gridHit.RowHandle)["Id_Khachhang"];
                    ndr["Ten_Table_Old"] = gridView2.GetDataRow(gridHit.RowHandle)["Ten_Table_Old"];
                    ndr["Soluong_Phucvu"] = gridView2.GetDataRow(gridHit.RowHandle)["Soluong_Phucvu"];
                    ndr["Soluong_Phucvu_Chuyen"] = gridView2.GetDataRow(gridHit.RowHandle)["Soluong_Phucvu"];
                    ndr["Ngay_Order"] = gridView2.GetDataRow(gridHit.RowHandle)["Ngay_Order"];
                    ndr["Id_Nhansu_Order"] = gridView2.GetDataRow(gridHit.RowHandle)["Id_Nhansu_Order"];
                    ndr["Id_Donvitinh"] = gridView2.GetDataRow(gridHit.RowHandle)["Id_Donvitinh"];
                    ndr["Dongia"] = gridView2.GetDataRow(gridHit.RowHandle)["Dongia"];
                    dsTable_OldOrder_Chitiet.Tables[0].Rows.Add(ndr);
                    txtTen_Table_Old.Text = ndr["Ten_Table_Old"].ToString();
                    dsTable_Order_Chitiet.Tables[0].Rows[gridHit.RowHandle].Delete();
                    dgbar_OldTable_Order_Detail.DataSource = dsTable_OldOrder_Chitiet;
                }
                else
                {
                    lblStatus_Bar.Text = "Không được chuyển món ăn này";
                }
            }
        }

        #endregion

        #region Chon chọn bàn

        /// Chon bàn cũ để tách
        void gridView_Dm_Table_Old_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit_Old = cvDm_Table_Old.CalcHitInfo(e.X, e.Y);
            if (cardHit_Old.InCard)
            {
                lblStatus_Bar.Text = "";
                cvDm_Table_Old.FocusedRowHandle = cardHit_Old.RowHandle;
                this.DoClickEndEdit(dgbar_Dm_Table_Old); //dgbar_Dm_Table_Old.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                drChons_Old = cvDm_Table_Old.GetDataRow(cardHit_Old.RowHandle);
                if (drChons_Old["Id_Booking"] != null && drChons_Old["Id_Booking"].ToString() != "")
                {
                    lblStatus_Bar.Text = "Bàn có booking, không được chọn bàn này để tách";
                    return;
                }
                if (drChons_Old != null)
                {
                    lblStatus_Bar.Text = "";
                    txtTen_Table_Old.Text = "" + drChons_Old["Ten_Table"];
                    txtVitri_Old.Text = "" + drChons_Old["Vitri"];
                    old_identity = drChons_Old["Id_Table_Order"];
                    dgbar_OldTable_Order_Detail.DataSource = null;
                    if (Convert.ToInt64(old_identity) == Convert.ToInt64("0" + identity))
                    {
                        if (gvbar_OldTable_Order_Detail.RowCount != 0)
                        {
                            dsTable_OldOrder_Chitiet.Tables[0].Reset();
                        }
                        lblStatus_Bar.Text = "Bàn cũ và bàn mới trùng nhau nên không tách chuyển được";
                        return;
                    }

                    if (drChons_Old["Lock"].ToString() != "")
                    {
                        if ((bool)drChons_Old["Lock"])
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

                    dsTable_OldOrder_Chitiet = (DataSet)hashDataset[old_identity];
                    if (dsTable_OldOrder_Chitiet == null)
                    {
                        dsTable_OldOrder_Chitiet = objBarService.Get_All_Bar_Table_Order_Chitiet_ById_Order(old_identity).ToDataSet();
                        dsTable_OldOrder_Chitiet.Tables[0].Columns.Add("Soluong_Chuyen", typeof(int));
                        dsTable_OldOrder_Chitiet.Tables[0].Columns.Add("Ten_Table_Old", typeof(string));
                        dsTable_OldOrder_Chitiet.Tables[0].Columns.Add("Vitri", typeof(string));
                        dsTable_OldOrder_Chitiet.Tables[0].Columns.Add("Id_Khachhang", typeof(int));
                        for (int i = 0; i < dsTable_OldOrder_Chitiet.Tables[0].Rows.Count; i++)
                        {
                            dsTable_OldOrder_Chitiet.Tables[0].Rows[i]["Id_Khachhang"] = drChons_Old["Id_Khachhang"];
                            dsTable_OldOrder_Chitiet.Tables[0].Rows[i]["Soluong_Chuyen"] = dsTable_OldOrder_Chitiet.Tables[0].Rows[i]["soluong"];
                            if (dsTable_OldOrder_Chitiet.Tables[0].Rows[i]["Soluong_Phucvu"].ToString() == "")
                            {
                                dsTable_OldOrder_Chitiet.Tables[0].Rows[i]["Soluong_Phucvu"] = 0;
                            }
                        }
                        hashDataset.Add(old_identity, dsTable_OldOrder_Chitiet);
                    }
                    txtTen_Table_Old.EditValue = drChons_Old["Ten_Table"];
                    txtVitri_Old.EditValue = drChons_Old["ViTri"];
                    dgbar_OldTable_Order_Detail.DataSource = dsTable_OldOrder_Chitiet;
                    dgbar_OldTable_Order_Detail.DataMember = dsTable_OldOrder_Chitiet.Tables[0].TableName;
                    btnBackDetail.Visible = true;
                    btnNextDetail.Visible = true;
                }
            }
        }

        ////click chọn bàn mới để tách
        void cardView_Dm_Table_New_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cvDm_Table_New.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                this.DoClickEndEdit(dgbar_Dm_Table_New); //dgbar_Dm_Table_New.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                drChons_New = cvDm_Table_New.GetDataRow(cardHit.RowHandle);
                txtTen_Table_New.Text = "" + drChons_New["Ten_Table"];
                txtVitri_New.Text = "" + drChons_New["Vitri"];
                cvDm_Table_New.FocusedRowHandle = cardHit.RowHandle;
                identity = drChons_New["Id_Table_Order"];
                if (drChons_New != null)
                {
                    lblStatus_Bar.Text = "";
                    if ("" + drChons_New["Id_Table_Order"] != "")
                    {
                        if (Convert.ToInt64(old_identity) == Convert.ToInt64(identity))
                        {
                            if (gridView2.RowCount != 0)
                            {
                                dsTable_Order_Chitiet.Tables[0].Reset();
                            }
                            lblStatus_Bar.Text = "Bàn cũ và bàn mới trùng nhau nên không tách chuyển được";
                            return;
                        }
                        //ban da co khach --> assign thong tin chung
                        txtTen_Table_New.EditValue = drChons_New["Ten_Table"];
                        txtVitri_New.EditValue = drChons_New["Vitri"];
                        //dtNgay_Order.EditValue = drChons_New["Ngay_Order"];
                        //-->show ds mon da chon
                        identity = drChons_New["Id_Table_Order"];
                        dsTable_Order_Chitiet = objBarService.Get_All_Bar_Table_Order_Chitiet_ById_Order(identity).ToDataSet();
                        dsTable_Order_Chitiet.Tables[0].Columns.Add("Id_Table_Old", typeof(Int64));
                        dsTable_Order_Chitiet.Tables[0].Columns.Add("Ten_Table_Old", typeof(string));
                        dsTable_Order_Chitiet.Tables[0].Columns.Add("Vitri", typeof(string));
                        dsTable_Order_Chitiet.Tables[0].Columns.Add("Id_Khachhang", typeof(int));
                    }
                    else
                    {
                        //ban chon ghep chua co khach --> assign thong tin chung
                        txtTen_Table_New.EditValue = drChons_New["Ten_Table"];
                        txtVitri_New.EditValue = drChons_New["Vitri"];
                        //dtNgay_Order.EditValue = DateTime.Now;
                        dsTable_Order_Chitiet = objBarService.Get_All_Bar_Table_Order_Chitiet_ById_Order(-1).ToDataSet();
                        dsTable_Order_Chitiet.Tables[0].Columns.Add("Id_Table_Old", typeof(Int64));
                        dsTable_Order_Chitiet.Tables[0].Columns.Add("Ten_Table_Old", typeof(string));
                        dsTable_Order_Chitiet.Tables[0].Columns.Add("Vitri", typeof(string));
                        dsTable_Order_Chitiet.Tables[0].Columns.Add("Id_Khachhang", typeof(int));
                    }
                    //show data on gridview
                    this.dgbar_Table_Order_Detail.DataSource = dsTable_Order_Chitiet;
                    this.dgbar_Table_Order_Detail.DataMember = dsTable_Order_Chitiet.Tables[0].TableName;
                    btnNextResult.Visible = true;
                    btnBackResult.Visible = true;
                }
                else
                {
                    lblStatus_Bar.Text = "Bạn phải chọn 1 bàn để ghép chuyển";
                }
            }
        }

        #endregion

        #region thay doi so luong chuyen
        /// <summary>
        /// chon mon de chuyen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void gridView_OldTable_Order_Detail_Click(object sender, EventArgs e)
        //{
        //    panelControl_OldDetail.Visible = false;
        //}

        //private void btnApply_Click(object sender, EventArgs e)
        //{
        //    panelControl_OldDetail.Visible = true;
        //}

        //private void btnCancelEdit_Click(object sender, EventArgs e)
        //{
        //    panelControl_OldDetail.Visible = true;
        //}

        private void keyboardcontrol1_UserKeyPressed(object sender,  GoobizFrame.Windows.Controls.TouchscreenKeyboard.KeyboardEventArgs e)
        {
            SendKeys.Send(e.KeyboardKeyPressed);
        }
        #endregion

        #region  click on Buttons

        /// <summary>
        /// in use
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dsTable_Order_Chitiet.Tables.Count == 0 || gridView2.RowCount == 0)
            {
                lblStatus_Bar.Text = "Không có thông tin thay đổi";
                return;
            }
            PerformSave();
        }

        /// <summary>
        /// in use
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            PerformCancel();
            PerformClose();
        }

        /// <summary>
        /// in use
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Page2_Click(object sender, EventArgs e)
        {
            cvDm_Table_New.MoveNextPage();
        }

        /// <summary>
        /// in use
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPre_Page2_Click(object sender, EventArgs e)
        {
            cvDm_Table_New.MovePrevPage();
        }

        /// <summary>
        /// in use
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Page1_Click(object sender, EventArgs e)
        {
            cvDm_Table_Old.MoveNextPage();
        }

        /// <summary>
        /// in use
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPre_Page1_Click(object sender, EventArgs e)
        {
            cvDm_Table_Old.MovePrevPage();
        }

        /// <summary>
        /// in use
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Deny_Click(object sender, EventArgs e)
        {
            this.FormState =  GoobizFrame.Windows.Forms.FormState.View;
            dgbar_Dm_Table_New.Enabled = true;
            dsTable_Order_Chitiet.Clear();
            dsTable_OldOrder_Chitiet.Clear();
            identity = null;
            lblStatus_Bar.Text = "";
            btnSave.Enabled = false;
            hashDataset.Clear();
            resetText();
        }

        private void resetText()
        {
            txtTen_Table_New.Text = "";
            txtTen_Table_Old.Text = "";
            txtVitri_New.Text = "";
            txtVitri_Old.Text = "";
        }

        /// <summary>
        /// in use
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBackDetail_Click(object sender, EventArgs e)
        {
            gvbar_OldTable_Order_Detail.MovePrevPage();
        }

        /// <summary>
        /// in use
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextDetail_Click(object sender, EventArgs e)
        {
            gvbar_OldTable_Order_Detail.MoveNextPage();
        }

        /// <summary>
        /// in use
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBackResult_Click(object sender, EventArgs e)
        {
            gridView2.MovePrevPage();
        }

        /// <summary>
        /// in use
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextResult_Click(object sender, EventArgs e)
        {
            gridView2.MoveNextPage();
        }
        #endregion

        /// <summary>
        /// Click vào --> nhập số lượng chuyển đi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemButtonEdit3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            object value =  GoobizFrame.Windows.Forms.FrmGNumboardInput.ShowInputDialog(
                "" + gvbar_OldTable_Order_Detail.GetFocusedRowCellValue("" + gvbar_OldTable_Order_Detail.FocusedColumn.FieldName));
            if (value.ToString().Contains("."))
            {
                lblStatus_Bar.Text = "Số lượng phải là số nguyên";
                return;
            }
            gvbar_OldTable_Order_Detail.SetFocusedRowCellValue(gvbar_OldTable_Order_Detail.FocusedColumn, value);
            gvbar_OldTable_Order_Detail.RefreshRow(gvbar_OldTable_Order_Detail.FocusedRowHandle);
            if (!check_Soluong_Chuyendi(gvbar_OldTable_Order_Detail.FocusedRowHandle, gvbar_OldTable_Order_Detail.FocusedColumn))
            {
                return;
            }
            if (!check_Soluong_Phucvu_Chuyendi(gvbar_OldTable_Order_Detail.FocusedRowHandle, gvbar_OldTable_Order_Detail.Columns["Soluong_Phucvu_Chuyen"]))
            {
                return;
            }
        }

        // kiểm tra số lượng chuyển đi
        private bool check_Soluong_Chuyendi(int gridViewFocusedRowHandle, DevExpress.XtraGrid.Columns.GridColumn gridView_Column)
        {
            object soluong_goc = gvbar_OldTable_Order_Detail.GetDataRow(gridViewFocusedRowHandle)["Soluong"];
            int Soluong_Chuyen = 0;
            int Soluong_Phucvu_Chuyen = 0;
            int.TryParse(""+gvbar_OldTable_Order_Detail.GetDataRow(gridViewFocusedRowHandle)["Soluong_Chuyen"], out Soluong_Chuyen);
            int.TryParse(""+gvbar_OldTable_Order_Detail.GetDataRow(gridViewFocusedRowHandle)["Soluong_Phucvu_Chuyen"], out Soluong_Phucvu_Chuyen);

            if (gvbar_OldTable_Order_Detail.GetDataRow(gridViewFocusedRowHandle)["Soluong_Chuyen"].ToString().Equals(""))
            {
                lblStatus_Bar.Text = "Số lượng chuyển đi không được để trống";
                gvbar_OldTable_Order_Detail.SetFocusedRowCellValue(gridView_Column, soluong_goc);
                return false;
            }
            if (Soluong_Chuyen == 0)
            {
                lblStatus_Bar.Text = "Số lượng chuyển đi không được bằng 0";
                gvbar_OldTable_Order_Detail.SetFocusedRowCellValue(gridView_Column, soluong_goc);
                return false;
            }
            if (Soluong_Chuyen > Convert.ToInt32(soluong_goc))
            {
                lblStatus_Bar.Text = "Số lượng chuyển đi không được lớn hơn số lượng trên bàn";
                gvbar_OldTable_Order_Detail.SetFocusedRowCellValue(gridView_Column, soluong_goc);
                return false;
            }

            if (Soluong_Chuyen < Soluong_Phucvu_Chuyen)
            {
                gvbar_OldTable_Order_Detail.SetFocusedRowCellValue("Soluong_Phucvu_Chuyen"
                    , gvbar_OldTable_Order_Detail.GetDataRow(gridViewFocusedRowHandle)["Soluong_Chuyen"]);
            }
            return true;
        }

        /// Click vào button --> nhập số lượng trả về
        void repositoryItemButtonEdit4_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            object value =  GoobizFrame.Windows.Forms.FrmGNumboardInput.ShowInputDialog(
                 "" + gvbar_OldTable_Order_Detail.GetFocusedRowCellValue("" + gvbar_OldTable_Order_Detail.FocusedColumn.FieldName));

            if (value.ToString().Contains("."))
            {
                lblStatus_Bar.Text = "Số lượng phải là số nguyên";
                return;
            }
            gvbar_OldTable_Order_Detail.SetFocusedRowCellValue(gvbar_OldTable_Order_Detail.FocusedColumn, value);
            gvbar_OldTable_Order_Detail.RefreshRow(gvbar_OldTable_Order_Detail.FocusedRowHandle);
            if (!check_Soluong_Phucvu_Chuyendi(gvbar_OldTable_Order_Detail.FocusedRowHandle, gvbar_OldTable_Order_Detail.FocusedColumn))
            {
                return;
            }
        }

        /// check số lượng PV chuyển đi, không đc lớn hơn số lượng chuyển đi và SL đã PV
        private bool check_Soluong_Phucvu_Chuyendi(int gridViewFocusedRowHandle, DevExpress.XtraGrid.Columns.GridColumn gridView_Column)
        {
            object soluong_PV = gvbar_OldTable_Order_Detail.GetDataRow(gridViewFocusedRowHandle)["Soluong_Phucvu"];
            object soluong_PV_Chuyen = gvbar_OldTable_Order_Detail.GetDataRow(gridViewFocusedRowHandle)["Soluong_Phucvu_Chuyen"];
            object soluong_goc = gvbar_OldTable_Order_Detail.GetDataRow(gridViewFocusedRowHandle)["Soluong"];
            object soluong_Chuyen = gvbar_OldTable_Order_Detail.GetDataRow(gridViewFocusedRowHandle)["Soluong_Chuyen"];
            lblStatus_Bar.Text = "";
            if (gvbar_OldTable_Order_Detail.GetDataRow(gridViewFocusedRowHandle)["Soluong_Phucvu_Chuyen"].ToString().Equals(""))
            {
                lblStatus_Bar.Text = "Số lượng phục vụ không được để trống";
                return false;
            }
            if (Convert.ToInt32("0" + soluong_PV) == 0)
            {
                gvbar_OldTable_Order_Detail.SetFocusedRowCellValue(gvbar_OldTable_Order_Detail.Columns["Soluong_Phucvu_Chuyen"], 0);
                return true;
            }
            if (Convert.ToInt32(soluong_PV) == Convert.ToInt32(soluong_goc))
            {
                if (Convert.ToInt32(soluong_Chuyen) == Convert.ToInt32(soluong_goc))
                {
                    gvbar_OldTable_Order_Detail.SetFocusedRowCellValue(gvbar_OldTable_Order_Detail.Columns["Soluong_Phucvu_Chuyen"], soluong_PV);
                    return true;
                }
                else
                {
                    gvbar_OldTable_Order_Detail.SetFocusedRowCellValue(gvbar_OldTable_Order_Detail.Columns["Soluong_Phucvu_Chuyen"], soluong_Chuyen);
                    return true;
                }
            }
            if (Convert.ToInt32(soluong_PV) < Convert.ToInt32(soluong_goc))
            {
                if (Convert.ToInt32(soluong_PV_Chuyen) > Convert.ToInt32(soluong_PV) && Convert.ToInt32(soluong_Chuyen) > Convert.ToInt32(soluong_PV))
                {
                    gvbar_OldTable_Order_Detail.SetFocusedRowCellValue(gvbar_OldTable_Order_Detail.Columns["Soluong_Phucvu_Chuyen"], soluong_PV);
                    return true;
                }
                if (Convert.ToInt32(soluong_PV_Chuyen) > Convert.ToInt32(soluong_Chuyen))
                {
                    lblStatus_Bar.Text = "Số lượng PV chuyển không đước lớn hơn số lượng chuyển";
                    gvbar_OldTable_Order_Detail.SetFocusedRowCellValue(gvbar_OldTable_Order_Detail.Columns["Soluong_Phucvu_Chuyen"], 0);
                    return false;
                }
                else
                {
                    if ((Convert.ToInt32(soluong_goc) - Convert.ToInt32(soluong_Chuyen)) < (Convert.ToInt32(soluong_PV) - Convert.ToInt32(soluong_PV_Chuyen)))
                    {
                        lblStatus_Bar.Text = "Số lượng chuyển đi không chính xác, kiểm tra lại";
                        return false;
                    }
                }
            }
            return true;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow dr_change = gvbar_OldTable_Order_Detail.GetDataRow(e.RowHandle);
            if (e.Column.FieldName == "Soluong_Chuyen")
                if (Convert.ToInt32("0" + dr_change["Soluong_Chuyen"]) == 0)
                {
                    lblStatus_Bar.Text = "Số lượng chuyển không được bằng 0";
                    dr_change["Soluong_Chuyen"] = dr_change["Soluong"];
                    return;
                }
        }

        #endregion

        private void cvBar_Dm_Khuvuc_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cvBar_Dm_Khuvuc.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                var id_khuvuc = cvBar_Dm_Khuvuc.GetRowCellValue(cardHit.RowHandle, "Id_Khuvuc");
                cvDm_Table_Old.Columns["Id_Khuvuc"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                        cvDm_Table_Old.Columns["Id_Khuvuc"], id_khuvuc);
                cvDm_Table_Old.ApplyColumnsFilter();
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

        private void cvBar_Dm_Khuvuc_2_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cvBar_Dm_Khuvuc_2.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                var id_khuvuc = cvBar_Dm_Khuvuc_2.GetRowCellValue(cardHit.RowHandle, "Id_Khuvuc");
                cvDm_Table_New.Columns["Id_Khuvuc"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                        cvDm_Table_New.Columns["Id_Khuvuc"], id_khuvuc);
                cvDm_Table_Old.ApplyColumnsFilter();

                styleFormatCondition_Kv2.Value1 = Convert.ToInt32(id_khuvuc);
            }
        }

        private void btnBack_Khuvuc_2_Click(object sender, EventArgs e)
        {
            cvBar_Dm_Khuvuc_2.MovePrevPage();
        }

        private void btnNext_Khuvuc_2_Click(object sender, EventArgs e)
        {
            cvBar_Dm_Khuvuc_2.MoveNextPage();
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

