using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Hdbanhang_Xuatkho :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        DataSet ds_Xkbanhang = new DataSet();
        DataSet ds_Xkbanhang_Chitiet = new DataSet();
        DataSet ds_Hanghoa_Ban = new DataSet();
        DataSet ds_Hanghoa_Ban_after_Thongke = new DataSet();
        DataSet dsDm_Loai_Hanghoa_Ban;
        DataSet ds_Nhansu;
        DataSet ds_Donvitinh;
        public DataRow dr_hdXuatkho;
        object identity;
        object LocationId_Cuahang_Ban;
        object id_donvitinh = null;

        public Frmware_Hdbanhang_Xuatkho()
        {
            InitializeComponent();
            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");
            xtraTabControl2.ShowTabHeader = DevExpress.Utils.DefaultBoolean.True;
            xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            this.dtNgay_Xuatkho.Properties.MinValue = new DateTime(2000,01,01);
            BarSystem.Visible = false;
            lblStatus_Bar.Text = "";
            dtNgay_Xuatkho.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgay_Xuatkho.Properties.Mask.EditMask =  GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();
            ShowLogonForm();
        }

        #region local data
        DataSet dsSys_Lognotify = null;
        string xml_WARE_DM_HANGHOA_BAN = @"Resources\localdata\Ware_Dm_Hanghoa_Ban.xml";
        string xml_REX_NHANSU = @"Resources\localdata\Rex_Nhansu.xml";
        string xml_WARE_DM_DONVITINH = @"Resources\localdata\Ware_Dm_Donvitinh.xml";
        string xml_WARE_DM_LOAI_HANGHOA_BAN = @"Resources\localdata\WARE_DM_LOAI_HANGHOA_BAN_BYLOCATION.xml";
        DateTime dtlc_ware_dm_hanghoa_ban;
        DateTime dtlc_ware_dm_donvitinh;
        DateTime dtlc_rex_nhansu;
        DateTime dtlc_ware_dm_loai_hanghoa_by_location;
        #endregion

        #region display information
        /// <summary>
        ///  Show tabpage 
        /// </summary>
        /// <param name="xtraTabPage"></param>
        void ShowTabPage(DevExpress.XtraTab.XtraTabPage xtraTabPage)
        {
            try
            {
                while (xtraTabControl1.TabPages.Count > 0)
                    xtraTabControl1.TabPages.RemoveAt(0);
                xtraTabControl1.TabPages.Add(xtraTabPage);
            }
            catch (Exception ex)
            { }

        }

        void ShowTabPages(DevExpress.XtraTab.XtraTabControl xtraTabControl,
                 DevExpress.XtraTab.XtraTabPage xtraTabPage)
        {
            while (xtraTabControl.TabPages.Count > 0)
                xtraTabControl.TabPages.RemoveAt(0);
            xtraTabControl.TabPages.Add(xtraTabPage);
        }

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
            //load data from local xml when last change at local differ from database
            dsSys_Lognotify = objMasterService.Get_Sys_Lognotify_SelectLastChange_OfTables("[ware_dm_donvitinh],[ware_dm_hanghoa_ban], [rex_nhansu], [ware_dm_loai_hanghoa_ban]").ToDataSet();

            dtlc_rex_nhansu = GetLastChange_FrmLognotify("REX_NHANSU");
            dtlc_ware_dm_donvitinh = GetLastChange_FrmLognotify("WARE_DM_DONVITINH");
            dtlc_ware_dm_loai_hanghoa_by_location = GetLastChange_FrmLognotify("WARE_DM_LOAI_HANGHOA_BAN");
            dtlc_ware_dm_hanghoa_ban = GetLastChange_FrmLognotify("WARE_DM_HANGHOA_BAN");

            if (DateTime.Compare(dtlc_ware_dm_hanghoa_ban, System.IO.File.GetLastWriteTime(xml_WARE_DM_HANGHOA_BAN)) > 0
            || !System.IO.File.Exists(xml_WARE_DM_HANGHOA_BAN))
            {
                ds_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
                ds_Hanghoa_Ban.WriteXml(xml_WARE_DM_HANGHOA_BAN, XmlWriteMode.WriteSchema);
            }
            else
            {
                ds_Hanghoa_Ban = new DataSet();
                ds_Hanghoa_Ban.ReadXml(xml_WARE_DM_HANGHOA_BAN);
            }
            if (DateTime.Compare(dtlc_ware_dm_loai_hanghoa_by_location, System.IO.File.GetLastWriteTime(xml_WARE_DM_LOAI_HANGHOA_BAN)) > 0
              || !System.IO.File.Exists(xml_WARE_DM_LOAI_HANGHOA_BAN))
            {
                dsDm_Loai_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Ban_SelectBy_Id_Cuahang_Ban(LocationId_Cuahang_Ban).ToDataSet();
                dsDm_Loai_Hanghoa_Ban.WriteXml(xml_WARE_DM_LOAI_HANGHOA_BAN, XmlWriteMode.WriteSchema);
            }
            else if (dsDm_Loai_Hanghoa_Ban == null || dsDm_Loai_Hanghoa_Ban.Tables.Count == 0)
            {
                dsDm_Loai_Hanghoa_Ban = new DataSet();
                dsDm_Loai_Hanghoa_Ban.ReadXml(xml_WARE_DM_LOAI_HANGHOA_BAN);
            }
            if (DateTime.Compare(dtlc_rex_nhansu, System.IO.File.GetLastWriteTime(xml_REX_NHANSU)) > 0
                || !System.IO.File.Exists(xml_REX_NHANSU))
            {
                ds_Nhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
                ds_Nhansu.WriteXml(xml_REX_NHANSU, XmlWriteMode.WriteSchema);
            }
            else if (ds_Nhansu == null || ds_Nhansu.Tables.Count == 0)
            {
                ds_Nhansu = new DataSet();
                ds_Nhansu.ReadXml(xml_REX_NHANSU);
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
            lookUpEdit_Cuahang_Ban.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().ToDataSet().Tables[0];
            ds_Hanghoa_Ban_after_Thongke = objWareService.Get_All_Ware_Dm_Hanghoa_Ban_Dinhgia_After_Thongke(LocationId_Cuahang_Ban).ToDataSet();
            gridLookUpEdit_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
            gridLookUpEdit_Ma_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
            //Get data Rex_Nhansu
            lookUpEdit_Nhansu_Banhang.Properties.DataSource = ds_Nhansu.Tables[0];
            lookUpEdit_Nhansu_Banhang.EditValue = Convert.ToInt64( GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
            gridLookUpEdit_Loai_Hanghoa_Ban.DataSource = dsDm_Loai_Hanghoa_Ban.Tables[0];
            gridLookup_Donvitinh.DataSource = ds_Donvitinh.Tables[0];
            gridLookUpEdit_Donvitinh.DataSource = ds_Donvitinh.Tables[0];
            if (lookupEditKhachhang.Properties.DataSource == null)
                lookupEditKhachhang.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet().Tables[0];
        }

        public override void DisplayInfo()
        {
            //Set lại trạng thái form là view
            FormState =  GoobizFrame.Windows.Forms.FormState.View;

            LocationId_Cuahang_Ban =  GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocation("Id_Cuahang_Ban");
            splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1;
            LoadMasterData();
            this.gridLookup_Donvitinh.Buttons[0].Visible = false;
            this.lblStatus_Bar.Text = "";
        }

        public void DisplayInfo_DsHoadon()
        {
            if ("" + gridView2.GetFocusedRowCellValue("Id_Xuatkho_Banhang") == "")
            {
                ds_Xkbanhang_Chitiet = new DataSet();
                return;
            }
            else
            {
                identity = gridView2.GetFocusedRowCellValue("Id_Xuatkho_Banhang");
                this.ds_Xkbanhang_Chitiet = objWareService.Get_All_Ware_Xuatkho_Banhang_Chitiet_By_Id_Xuatkho_Banhang(identity).ToDataSet();
                if (!ds_Xkbanhang_Chitiet.Tables[0].Columns.Contains("Ten_Donvitinh"))
                    ds_Xkbanhang_Chitiet.Tables[0].Columns.Add("Ten_Donvitinh", typeof(string));

                this.dgware_Hdbanhang_Chitiet.DataSource = ds_Xkbanhang_Chitiet.Tables[0];
                for (int i = 0; i < ds_Xkbanhang_Chitiet.Tables[0].Rows.Count; i++)
                {
                    DataRow[] dtr_Donvitinh = ds_Donvitinh.Tables[0].Select("Id_Donvitinh = " + ds_Xkbanhang_Chitiet.Tables[0].Rows[i]["Id_Donvitinh"]);
                    gridView4.SetRowCellValue(i, gridView4.Columns["Ten_Donvitinh"], dtr_Donvitinh[0]["Ten_Donvitinh"]);
                }
                if (ds_Xkbanhang_Chitiet.Tables[0].Rows.Count == 0)
                    return;
                if ("" + ds_Xkbanhang_Chitiet.Tables[0].Rows[0]["Dongia_Bansi"] != "")
                {
                    gridView4.Columns["Dongia_Bansi"].Visible = true;
                    gridView4.Columns["Dongia_Ban"].Visible = false;
                    chkDongia_Bansi.Checked = true;
                }
                else
                {
                    gridView4.Columns["Dongia_Bansi"].Visible = false;
                    gridView4.Columns["Dongia_Ban"].Visible = true;
                    chkDongia_Bansi.Checked = false;
                }
                gridView4.BestFitColumns();
                object status = gridView2.GetFocusedRowCellValue("Doc_Process_Status");
                if (status.ToString() != "")
                {
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                }
                else
                {
                    this.btnEdit.Enabled = EnableEdit;
                    this.btnDelete.Enabled = EnableDelete;
                }
            }
        }

        void setColorHanghoa()
        {
            dgware_Dm_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban_after_Thongke.Tables[0];
            dgware_Dm_Loai_Hanghoa_Ban.DataSource = dsDm_Loai_Hanghoa_Ban;
            dgware_Dm_Loai_Hanghoa_Ban.DataMember = dsDm_Loai_Hanghoa_Ban.Tables[0].TableName;
            if (cardView2.FormatConditions.Count == 0)
            {
                if (dsDm_Loai_Hanghoa_Ban.Tables[0].Rows.Count > 0)
                {
                    int i = Convert.ToInt32("0" + dsDm_Loai_Hanghoa_Ban.Tables[0].Rows[0]["Id_Nhom_Hanghoa_Ban"]);
                    foreach (DataRow drNhom_Hanghoa_Ban in dsDm_Loai_Hanghoa_Ban.Tables[0].Rows)
                    {
                        DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition = new DevExpress.XtraGrid.StyleFormatCondition();
                        styleFormatCondition.Appearance.BackColor =  GoobizFrame.Windows.MdiUtils.ThemeSettings.GetColor(Convert.ToInt32(drNhom_Hanghoa_Ban["Id_Nhom_Hanghoa_Ban"]) % i);
                        styleFormatCondition.Appearance.Options.UseBackColor = true;
                        styleFormatCondition.ApplyToRow = true;
                        styleFormatCondition.Column = this.cardView2.Columns["Id_Nhom_Hanghoa_Ban"];
                        styleFormatCondition.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
                        styleFormatCondition.Value1 = Convert.ToInt32(drNhom_Hanghoa_Ban["Id_Nhom_Hanghoa_Ban"]);
                        this.cardView2.FormatConditions.Add(styleFormatCondition);
                    }
                    this.cardView2.Columns["Id_Nhom_Hanghoa_Ban"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                }
            }
        }

        #endregion

        #region Logon process

        /// <summary>
        /// show screen logon
        /// </summary>
        void ShowLogonForm()
        {
            //if (FormState ==  GoobizFrame.Windows.Forms.FormState.View)
            //{
            //    btnLapPhieuThu.Enabled = false;
            //    BarSystem.Visible = false;
            //    item_Delete.Enabled = false;
            //    item_Edit.Enabled = false;
            //    btnLogon.Visible = true;
            //}
            //else
            //    ShowTabPage(xtraTabPage_Sale);
        }

        /// <summary>
        /// verify logon
        /// </summary>
        private void idCardLogonControl1_AfterLogon_1()
        {
             GoobizFrame.Windows.PlugIn.RightHelpers.CheckUserRightAction(this);
            ShowTabPage(xtraTabPage_Sale);
            btnLapPhieuThu.Enabled = true;
            DisplayInfo();
            if (EnableAdd)
            {
                ChangeFormState( GoobizFrame.Windows.Forms.FormState.Add);
                PerformAdd();
            }
            else
            {
                this.btnCancel.Enabled = false;
                this.btnEdit.Enabled = EnableEdit;
                this.btnDelete.Enabled = EnableDelete;
                this.btnAdd.Enabled = EnableAdd;
            }
            //btnPrint.Enabled = EnableAdd;
            this.btnChon_HH.Enabled = EnableAdd;                        
            ShowTabPages(xtraTabControl2, xtraTabPage_Loaihang);
        }

        #endregion

        #region event override

        public object InsertObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Xuatkho_Banhang objWare_Xuatkho_Banhang = new Ecm.WebReferences.WareService.Ware_Xuatkho_Banhang();
                objWare_Xuatkho_Banhang.Id_Xuatkho_Banhang = -1;
                txtSochungtu.EditValue = objWareService.Getnew_Sohoadon_XuatkhoBh(
                    ((DataRowView)lookUpEdit_Cuahang_Ban.Properties.GetDataSourceRowByKeyValue(LocationId_Cuahang_Ban))["Ma_Cuahang_Ban"]);
                objWare_Xuatkho_Banhang.Sochungtu = txtSochungtu.EditValue;
                objWare_Xuatkho_Banhang.Sotien = txtSotien.EditValue;
                objWare_Xuatkho_Banhang.Sotien_Vat = txtSotien_Vat.EditValue;
                objWare_Xuatkho_Banhang.Ngay_Chungtu = dtNgay_Chungtu.EditValue;
                objWare_Xuatkho_Banhang.Ngay_Thanhtoan = dtNgay_Chungtu.EditValue;
                objWare_Xuatkho_Banhang.Nguoinhan = (txtNguoinhan.Text == "") ? null : txtNguoinhan.EditValue;
                objWare_Xuatkho_Banhang.Per_Chietkhau = (txtChietkhau.Text == "") ? null : txtChietkhau.EditValue;
                objWare_Xuatkho_Banhang.Thanhtien_Chietkhau = (txtSotien_Chietkhau.Text == "") ? null : txtSotien_Chietkhau.EditValue;

                if ("" + lookUpEdit_Cuahang_Ban.EditValue != "")
                    objWare_Xuatkho_Banhang.Id_Cuahang_Ban = lookUpEdit_Cuahang_Ban.EditValue;

                if ("" + lookUpEdit_Nhansu_Banhang.EditValue != "")
                    objWare_Xuatkho_Banhang.Id_Nhansu_Bh = lookUpEdit_Nhansu_Banhang.EditValue;

                objWare_Xuatkho_Banhang.Id_Khachhang = ("" + lookupEditKhachhang.EditValue != "") ? lookupEditKhachhang.EditValue : -1;
                identity = objWareService.Insert_ware_xuatkho_banhang(objWare_Xuatkho_Banhang);

                if (identity != null)
                {
                    dgware_Hdbanhang_Chitiet.EmbeddedNavigator.Buttons.DoClick(dgware_Hdbanhang_Chitiet.EmbeddedNavigator.Buttons.EndEdit);
                    foreach (DataRow dr in ds_Xkbanhang_Chitiet.Tables[0].Rows)
                    {
                        dr["Id_Xuatkho_Banhang"] = identity;
                    }
                    objWareService.Update_Ware_Xuatkho_Banhang_Chitiet_Collection(ds_Xkbanhang_Chitiet);
                }
                return true;
            }
            catch (Exception ex)
            {
                 GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
                return false;
            }
        }

        public object UpdateObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Xuatkho_Banhang objWare_Xuatkho_Banhang = new Ecm.WebReferences.WareService.Ware_Xuatkho_Banhang();
                objWare_Xuatkho_Banhang.Id_Xuatkho_Banhang = identity;
                objWare_Xuatkho_Banhang.Sochungtu = txtSochungtu.EditValue;
                objWare_Xuatkho_Banhang.Sotien = txtSotien.EditValue;
                objWare_Xuatkho_Banhang.Sotien_Vat = txtSotien_Vat.EditValue;
                objWare_Xuatkho_Banhang.Ngay_Chungtu = dtNgay_Chungtu.EditValue;
                objWare_Xuatkho_Banhang.Ngay_Thanhtoan = dtNgay_Chungtu.EditValue;
                objWare_Xuatkho_Banhang.Nguoinhan = (txtNguoinhan.Text == "") ? null : txtNguoinhan.EditValue;
                objWare_Xuatkho_Banhang.Per_Chietkhau = (txtChietkhau.Text == "") ? null : txtChietkhau.EditValue;
                objWare_Xuatkho_Banhang.Thanhtien_Chietkhau = (txtSotien_Chietkhau.Text == "") ? null : txtSotien_Chietkhau.EditValue;

                if ("" + lookUpEdit_Cuahang_Ban.EditValue != "")
                    objWare_Xuatkho_Banhang.Id_Cuahang_Ban = lookUpEdit_Cuahang_Ban.EditValue;

                if ("" + lookUpEdit_Nhansu_Banhang.EditValue != "")
                    objWare_Xuatkho_Banhang.Id_Nhansu_Bh = lookUpEdit_Nhansu_Banhang.EditValue;

                objWare_Xuatkho_Banhang.Id_Khachhang = ("" + lookupEditKhachhang.EditValue != "") ? lookupEditKhachhang.EditValue : -1;
                objWare_Xuatkho_Banhang.Id_Nhansu_Edit = Convert.ToInt64( GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
                objWare_Xuatkho_Banhang.Ghichu_Edit = null;
                objWareService.Update_ware_xuatkho_banhang(objWare_Xuatkho_Banhang);
                if (identity != null)
                {
                    dgware_Hdbanhang_Chitiet.EmbeddedNavigator.Buttons.DoClick(dgware_Hdbanhang_Chitiet.EmbeddedNavigator.Buttons.EndEdit);
                    foreach (DataRow dr in ds_Xkbanhang_Chitiet.Tables[0].Rows)
                    {
                        if (dr.RowState == DataRowState.Added)
                            dr["Id_Xuatkho_Banhang"] = identity;
                    }
                    objWareService.Update_Ware_Xuatkho_Banhang_Chitiet_Collection(ds_Xkbanhang_Chitiet);
                }
                return true;
            }
            catch (Exception ex)
            {
                 GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
                return false;
            }
        }

        public object DeleteObject()
        {
            try
            {
                if (identity == null)
                    return false;
                objWareService.Delete_Ware_Xuatkho_Banhang(identity);
                return true;
            }
            catch (Exception ex)
            {
                 GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
                return false;
            }
        }

        public override bool PerformAdd()
        {
            try
            {
                lblStatus_Bar.Text = "";
                ChangeFormState( GoobizFrame.Windows.Forms.FormState.Add);
                splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both;
                //setColorHanghoa();
                this.gridLookup_Donvitinh.Buttons[0].Visible = true;
                ResetText();
                this.ClearDataBindings();
                ChangeStatus(true);
                ChangeStatusButton(true);
                dtNgay_Chungtu.DateTime = DateTime.Now;
                lookUpEdit_Cuahang_Ban.EditValue = Convert.ToInt64(LocationId_Cuahang_Ban);
                txtSochungtu.EditValue = objWareService.Getnew_Sohoadon_XuatkhoBh(
                    ((DataRowView)lookUpEdit_Cuahang_Ban.Properties.GetDataSourceRowByKeyValue(LocationId_Cuahang_Ban))["Ma_Cuahang_Ban"]);
                this.txtSoluong.EditValue = 1;
                ShowTabPages(xtraTabControl2, xtraTabPage_Loaihang);
                this.btnPrint.Enabled = false;
            }
            catch (Exception ex)
            { }
            return base.PerformAdd();
        }

        public override bool PerformSave()
        {
            try
            {
                if (Convert.ToDecimal("0" + txtChietkhau.EditValue) > 100)
                {
                    lblStatus_Bar.Text = "Chiết khấu không được lớn hơn 100, vui lòng nhập lại";
                    txtChietkhau.Focus();
                    return false;
                }
                bool success = false;
                System.Collections.Hashtable htbControl1 = new System.Collections.Hashtable();
                htbControl1.Add(txtSochungtu, lblSochungtu.Text);
                htbControl1.Add(txtSotien, lblSotien.Text);
                htbControl1.Add(txtNguoinhan, lblNguoi_Nhan.Text);
                htbControl1.Add(txtTen_Khachhang, lblKhachhang.Text);
                htbControl1.Add(dtNgay_Chungtu, lblNgay_Chungtu.Text);
                htbControl1.Add(lookUpEdit_Cuahang_Ban, lblCuahang_Ban.Text);
                htbControl1.Add(lookUpEdit_Nhansu_Banhang, lblNhansu_Banhang.Text);
                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(htbControl1))
                    return false;
                if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Add)
                    success = (bool)this.InsertObject();
                if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Edit)
                    success = (bool)this.UpdateObject();
                return success;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public override bool PerformEdit()
        {
            lblStatus_Bar.Text = "";
            ChangeFormState( GoobizFrame.Windows.Forms.FormState.Edit);
            splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both;
            setColorHanghoa();
            this.gridLookup_Donvitinh.Buttons[0].Visible = true;
            this.ClearDataBindings();
            ChangeStatus(true);
            ChangeStatusButton(true);
            this.txtSoluong.EditValue = 1;
            ShowTabPages(xtraTabControl2, xtraTabPage_Loaihang);
            return base.PerformEdit();
        }

        public override bool PerformPrintPreview()
        {
            if (ds_Xkbanhang_Chitiet.Tables.Count == 0 || ds_Xkbanhang_Chitiet.Tables[0].Rows.Count == 0)
            {
                lblStatus_Bar.Text = "Chưa có Hóa đơn nào được chọn, vui lòng chọn lại";
                return false;
            }
            DataSets.DsHdbanhang_Xuatkho dsXuatkho_Chitiet = new Ecm.Ware.DataSets.DsHdbanhang_Xuatkho();
            Reports.rptHdbanhang_Xuatkho rptXuatkho = new Ecm.Ware.Reports.rptHdbanhang_Xuatkho();
             GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new  GoobizFrame.Windows.Forms.FrmPrintPreview();
            frmPrintPreview.Report = rptXuatkho;
            //frmPrintPreview.Name = this.Name;
            //frmPrintPreview.EnablePrintPreview = this.EnablePrintPreview;
            rptXuatkho.DataSource = dsXuatkho_Chitiet;
            int i = 1;
            foreach (DataRow dtr in ds_Xkbanhang_Chitiet.Tables[0].Rows)
            {
                DataRow dtrNew = dsXuatkho_Chitiet.Tables[0].NewRow();
                foreach (DataColumn dtc in ds_Xkbanhang_Chitiet.Tables[0].Columns)
                {
                    try
                    {
                        dtrNew[dtc.ColumnName] = dtr[dtc.ColumnName];
                    }
                    catch (Exception ex)
                    {
                    }
                }
                dtrNew["Stt"] = i;
                i++;
                dsXuatkho_Chitiet.Tables[0].Rows.Add(dtrNew);
            }

            #region Set he so ctrinh - logo, ten cty
            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyWebsite", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyTel", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyFaxEmail", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyTax", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("BankingAcc", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyWebsite"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyTel"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyFaxEmail"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyTax"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","BankingAcc"))[0]["Heso"]
                    ,imageData});

                rptXuatkho.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                rptXuatkho.xrCompany_Name.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                rptXuatkho.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                rptXuatkho.xrCompany_Address.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                rptXuatkho.xrCompany_Website.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyWebsite"));
                rptXuatkho.xrCompany_Tel.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyTel"));
                rptXuatkho.xrCompany_Masothue.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyTax"));
                rptXuatkho.xrCompany_Email.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyFaxEmail"));
                //rptXuatkho.xrPic_Logo.DataBindings.Add(
                //new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }
            #endregion

            rptXuatkho.xrCuahang_Ban.Text = lookUpEdit_Cuahang_Ban.Text;
            rptXuatkho.xrSochungtu.Text = txtSochungtu.Text;
            rptXuatkho.tbcNgay_Chungtu.Text = "" + string.Format("{0:dd/MM/yyyy hh:mm:ss tt}", dtNgay_Chungtu.Text);
            rptXuatkho.xrNgay_Chungtu.Text = "" + string.Format("{0:dd/MM/yyyy hh:mm:ss tt}", dtNgay_Chungtu.Text);
            rptXuatkho.xrNguoiNhan.Text = txtNguoinhan.Text;
            rptXuatkho.xrKhachhang.Text = txtTen_Khachhang.Text;
            rptXuatkho.xrKhachhang_Diachi.Text = txtDiachi.Text;
            rptXuatkho.xrKhachhang_Masothue.Text = txtMasothue.Text;
            rptXuatkho.xrKhachhang_Dienthoai.Text = txtDienthoai.Text;
            rptXuatkho.xrKhachhang_Masothue.Text = txtMasothue.Text;
            rptXuatkho.xrNguoiLap_Kyten.Text = lookUpEdit_Nhansu_Banhang.Text;
            if (chkDongia_Bansi.Checked)
                rptXuatkho.xrDongia.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", null, "DataTable1.Dongia_Bansi", "{0:#,#}")});

            rptXuatkho.CreateDocument();
             GoobizFrame.Windows.Forms.ReportOptions oReportOptions =  GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(rptXuatkho);
             if (Convert.ToBoolean(oReportOptions.PrintPreview))
             {
                 frmPrintPreview.Text = "" + oReportOptions.Caption;
                 frmPrintPreview.printControl1.PrintingSystem = rptXuatkho.PrintingSystem;
                 frmPrintPreview.MdiParent = this.MdiParent;
                 frmPrintPreview.Text = this.Text + "(Xem trang in)";
                 frmPrintPreview.Show();
                 frmPrintPreview.Activate();
             }
             else
             {
                 var reportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rptXuatkho);
                 reportPrintTool.Print();
             }

            this.lblStatus_Bar.Text = "";
            return base.PerformPrintPreview();
        }

        public override bool PerformCancel()
        {
            this.ChangeFormState( GoobizFrame.Windows.Forms.FormState.View);
            DisplayInfo();
            ChangeStatus(false);
            ChangeStatusButton(false);
            this.gridView2.FocusedRowHandle = 0;
            DisplayInfo_DsHoadon();
            this.gridColumn35.Visible = false;
            this.txtSoluong.EditValue = null;
            this.txtSochungtu.EditValue = null;
            this.dtNgay_Chungtu.EditValue = null;
            ds_Xkbanhang = objWareService.Get_All_Ware_Xuatkho_Banhang_ByCuahang_ByDate(LocationId_Cuahang_Ban, null).ToDataSet();
            DataBindingControl();
            return base.PerformCancel();
        }

        public override bool PerformDelete()
        {
            try
            {
                Ecm.WebReferences.WareService.DocumentProcessStatus DocumentProcessStatus = new Ecm.WebReferences.WareService.DocumentProcessStatus();
                DocumentProcessStatus.Tablename = "ware_xuatkho_banhang";
                DocumentProcessStatus.PK_Name = "id_xuatkho_banhang";
                DocumentProcessStatus.Identity = identity;
                DocumentProcessStatus = objWareService.Get_DocumentProcessStatus(DocumentProcessStatus);
                if (objWareService.GetEDocumentProcessStatus((int)DocumentProcessStatus.Doc_Process_Status) != Ecm.WebReferences.WareService.EDocumentProcessStatus.NewDoc)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("TASK_VERIFIED", new string[] { });
                    return false;
                }
                if ( GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
                 GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("ware_xuatkho_banhang")}) == DialogResult.Yes)
                {
                    try
                    {
                        this.DeleteObject();
                    }
                    catch (Exception ex)
                    {
                         GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                    }
                    //this.DisplayInfo();
                }
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
                return false;
#endif
            }
            return base.PerformDelete();
        }

        #endregion

        #region binding, changestatus, resettext

        public override void ClearDataBindings()
        {
            this.txtSochungtu.DataBindings.Clear();
            this.txtSotien.DataBindings.Clear();
            this.txtSotien_Vat.DataBindings.Clear();
            this.txtTongtien_Hang.DataBindings.Clear();
            this.txtChietkhau.DataBindings.Clear();
            this.txtSotien_Chietkhau.DataBindings.Clear();
            this.txtNguoinhan.DataBindings.Clear();
            this.dtNgay_Chungtu.DataBindings.Clear();
            this.lookUpEdit_Cuahang_Ban.DataBindings.Clear();
            this.lookUpEdit_Nhansu_Banhang.DataBindings.Clear();
            this.lookupEditKhachhang.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            this.ClearDataBindings();
            this.txtSochungtu.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Sochungtu");
            this.txtSotien.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Sotien");
            this.txtSotien_Vat.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Sotien_Vat");
            this.txtTongtien_Hang.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Thanhtien_NotVAT");
            this.txtSotien_Chietkhau.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Thanhtien_Chietkhau");
            this.txtChietkhau.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Per_Chietkhau");
            this.txtNguoinhan.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Nguoinhan");
            this.dtNgay_Chungtu.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Ngay_Chungtu");
            this.lookUpEdit_Cuahang_Ban.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Id_Cuahang_Ban");
            this.lookUpEdit_Nhansu_Banhang.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Id_Nhansu_Bh");
            this.lookupEditKhachhang.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Id_Khachhang");
        }

        public override void ResetText()
        {
            this.lookupEditKhachhang.EditValue = null;
            this.txtTen_Khachhang.EditValue = null;
            this.txtNguoinhan.EditValue = null;
            this.txtDiachi.EditValue = null;
            this.txtDienthoai.EditValue = null;
            this.txtMasothue.EditValue = null;
            this.txtMa_Khachhang.EditValue = null;

            this.txtSotien.EditValue = null;
            this.txtChietkhau.EditValue = 0;
            this.txtSotien_Chietkhau.EditValue = null;
            this.txtSotien_Vat.Text = "";
            this.txtSotien.EditValue = null;
            this.txtTongtien_Hang.EditValue = null;

            this.txtMa_Hanghoa.Text = "";
            this.txtBarcode_Txt.Text = "";
            this.txtDinhmuc_No.EditValue = null;
            this.txtTong_No.EditValue = null;
            this.txtSochungtu.EditValue = null;
            this.dtNgay_Chungtu.EditValue = null;
            this.ds_Xkbanhang_Chitiet = objWareService.Get_All_Ware_Xuatkho_Banhang_Chitiet_By_Id_Xuatkho_Banhang(0).ToDataSet();
            this.dgware_Hdbanhang_Chitiet.DataSource = ds_Xkbanhang_Chitiet.Tables[0];
        }

        public override void ChangeStatus(bool editTable)
        {
            gridView4.OptionsBehavior.Editable = editTable;
            this.txtMa_Hanghoa.Properties.ReadOnly = !editTable;
            this.txtBarcode_Txt.Properties.ReadOnly = !editTable;
            this.txtSoluong.Properties.ReadOnly = !editTable;
            this.txtNguoinhan.Properties.ReadOnly = !editTable;
            this.txtChietkhau.Properties.ReadOnly = !editTable;
            this.gridColumn35.Visible = editTable; // ẩn, hiện button xóa
        }

        void ChangeStatusButton(bool editTable)
        {
            btnCancel.Enabled = editTable;
            btnChon_HH.Enabled = editTable;
            btnHdbanhang.Enabled = !editTable;
            btnAdd.Enabled = (!editTable) ? EnableAdd : false;
            btnPrint.Enabled = (!editTable) ? true : false;
            btnDelete.Enabled = (!editTable) ? EnableDelete : false;
            chkDongia_Bansi.Enabled = editTable;
            btnEdit.Enabled = (!editTable) ? EnableEdit : false;
            btnLapPhieuThu.Enabled = !editTable;
            btnLogon.Enabled = !editTable;
            btnClose.Enabled = !editTable;
        }

        #endregion

        #region process cardview, gridview
        private void cardView2_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cardView2.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                object id_loai_Hh = cardView2.GetRowCellValue(cardHit.RowHandle, "Id_Loai_Hanghoa_Ban");
                cardView1.Columns["Id_Loai_Hanghoa_Ban"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
               "Id_Loai_Hanghoa_Ban = " + id_loai_Hh);
                ShowTabPages(xtraTabControl2, xtraTabPage_Hanghoa);
            }
        }

        private void cardView1_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cardView1.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                cardView1.FocusedRowHandle = cardHit.RowHandle; // set lại focus cho card view
                id_donvitinh = cardView1.GetFocusedRowCellValue(cardView1.Columns["Id_Donvitinh"]);
                AddNewOrderDetail(cardView1.GetFocusedRowCellValue(cardView1.Columns["Barcode_Txt"]).ToString(), txtSoluong.EditValue);
            }
        }

        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.DoClickEndEdit(dgware_Hdbanhang_Chitiet);
            if (e.Column.FieldName == "Soluong")
            {
                lblStatus_Bar.Text = "";
                if (gridView4.GetFocusedRowCellValue("Soluong").ToString().Equals(""))
                {
                    lblStatus_Bar.Text = "Số lượng không được rỗng";
                    gridView4.SetFocusedRowCellValue(gridView4.FocusedColumn, 1);
                    return;
                }
                if (gridView4.GetFocusedRowCellValue("Soluong").ToString().Length > 5)
                {
                    lblStatus_Bar.Text = "Số lượng nhập không chính xác";
                    gridView4.SetFocusedRowCellValue(gridView4.FocusedColumn, 1);
                    return;
                }
                int soluong = Convert.ToInt32(gridView4.GetFocusedRowCellValue("Soluong"));
                if (soluong.ToString().Contains("-"))
                {
                    lblStatus_Bar.Text = "Số lượng không được nhập số âm";
                    string soluong_New = soluong.ToString().Replace("-", "");
                    gridView4.SetFocusedRowCellValue(gridView4.FocusedColumn, soluong_New);
                    return;
                }
                if (soluong == 0)
                {
                    lblStatus_Bar.Text = "Số lượng không được bằng 0";
                    gridView4.SetFocusedRowCellValue(gridView4.FocusedColumn, 1);
                    return;
                }
                if (soluong.ToString().Length >= 6)
                {
                    soluong = Convert.ToInt32(soluong.ToString().Substring(0, 5));
                    gridView4.SetFocusedRowCellValue(gridView4.FocusedColumn, soluong);
                    return;
                }

                var soluong_ton = Get_Soluong_Ton_Quydoi(gridView4.GetFocusedRowCellValue("Id_Hanghoa_Ban"),
                                    gridView4.GetFocusedRowCellValue("Id_Donvitinh"));
                if (soluong_ton < soluong)
                {
                    //lblStatus_Bar.Text = "Không đủ số lượng để xuất theo yêu cầu";
                     GoobizFrame.Windows.Forms.MessageDialog.Show("Không đủ số lượng để xuất theo yêu cầu");
                     gridView4.SetFocusedRowCellValue(gridView4.Columns["Soluong"], soluong_ton);
                    return;
                }
            }
            if (e.Column.FieldName == "Soluong" || e.Column.FieldName == "Dongia_Ban" || e.Column.FieldName == "Dongia_Bansi" || e.Column.FieldName == "Per_VAT")
            {
                set_Value_on_Gridview4();
            }
            if (e.Column.FieldName == "Id_Hanghoa_Ban")
            {
                DataRow[] dtr = ds_Hanghoa_Ban_after_Thongke.Tables[0].Select("Id_Hanghoa_Ban = " + gridView4.GetFocusedRowCellValue("Id_Hanghoa_Ban"));
                if (dtr == null || dtr.Length == 0)
                {
                    lblStatus_Bar.Text = "Hàng hóa chưa được định giá";
                    gridView4.CancelUpdateCurrentRow();
                }
                gridView4.SetFocusedRowCellValue(gridView4.Columns["Id_Donvitinh"], dtr[0]["Id_Donvitinh"]);
                if (!chkDongia_Bansi.Checked)
                    gridView4.SetFocusedRowCellValue(gridView4.Columns["Dongia_Ban"], dtr[0]["Dongia_Ban"]);
                else
                    gridView4.SetFocusedRowCellValue(gridView4.Columns["Dongia_Bansi"], dtr[0]["Dongia_Bansi"]);
            }
            set_Value_Thanhtien();
            gridView4.BestFitColumns();
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            lblStatus_Bar.Text = "";
            DisplayInfo_DsHoadon();
        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //if (MessageBox.Show("Bạn có chắc muốn xóa hàng hóa này?", "Confirm Dialog", MessageBoxButtons.YesNo) == DialogResult.Yes)
            if ( GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string []{"Hàng hóa "}) == DialogResult.Yes)
            {
                ds_Xkbanhang_Chitiet.Tables[0].Rows[gridView4.FocusedRowHandle].Delete();
                dgware_Hdbanhang_Chitiet.DataSource = ds_Xkbanhang_Chitiet;
                dgware_Hdbanhang_Chitiet.DataMember = ds_Xkbanhang_Chitiet.Tables[0].TableName;
                if (gridView4.RowCount == 0)
                    btnPrint.Enabled = false;
                set_Value_Thanhtien();
            }
        }

        #endregion

        #region Clicks Buttons

        // Tạo mới
        private void btnAdd_Click(object sender, EventArgs e)
        {
            PerformAdd();
        }
        // Bỏ qua
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.PerformCancel();
            this.ResetText();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.FormState !=  GoobizFrame.Windows.Forms.FormState.View)
            {
                if (PerformSave())
                {
                    this.PerformPrintPreview();
                    this.PerformAdd();
                }
            }
            else
                this.PerformPrintPreview();
        }

        // Lập phiếu thu
        private void btnLapPhieuThu_Click(object sender, EventArgs e)
        {
            //if (gridView2.RowCount != 0)
            //{
            //    lblStatus_Bar.Text = "";
            //    int focusedRow = gridView2.GetDataSourceRowIndex(gridView2.FocusedRowHandle);
            //    Ecm.Ware.Forms.Frmware_Phieu_Thu frm_PhieuThu = new Frmware_Phieu_Thu();
            //    if (ds_Xkbanhang.Tables[0].Rows[focusedRow] != null)
            //        dr_hdXuatkho = ds_Xkbanhang.Tables[0].Rows[focusedRow];
            //    frm_PhieuThu.set_Chungtu_Goc(dr_hdXuatkho, txtKhachhang.EditValue);
            //    frm_PhieuThu.ShowDialog();
            //}
            //else
            //    lblStatus_Bar.Text = "Chưa có Hóa đơn nào được chọn, vui lòng chọn lại";
        }

        // Tìm hàng
        private void btnChon_HH_Click(object sender, EventArgs e)
        {
            splitContainerControl1.PanelVisibility = (splitContainerControl1.PanelVisibility != DevExpress.XtraEditors.SplitPanelVisibility.Both)
                                         ? DevExpress.XtraEditors.SplitPanelVisibility.Both
                                         : DevExpress.XtraEditors.SplitPanelVisibility.Panel1;
            ShowTabPages(xtraTabControl2, xtraTabPage_Loaihang);
        }

        // Loại hàng
        private void btnLoai_Hanghoa_Ban_Click(object sender, EventArgs e)
        {
            ShowTabPages(xtraTabControl2, xtraTabPage_Loaihang);
        }

        // Danh sách hóa đơn
        private void btnHdbanhang_Click(object sender, EventArgs e)
        {
            splitContainerControl1.PanelVisibility = (splitContainerControl1.PanelVisibility != DevExpress.XtraEditors.SplitPanelVisibility.Both)
                                                     ? DevExpress.XtraEditors.SplitPanelVisibility.Both
                                                     : DevExpress.XtraEditors.SplitPanelVisibility.Panel1;
            if (splitContainerControl1.PanelVisibility == DevExpress.XtraEditors.SplitPanelVisibility.Both)
            {
                ShowTabPages(xtraTabControl2, xtraTabPage_DsHoaDon);
                this.ReloadDs_XkBanhang();
                dgware_Hdbanhang.DataSource = ds_Xkbanhang;
                dgware_Hdbanhang.DataMember = ds_Xkbanhang.Tables[0].TableName;
            }
            DisplayInfo_DsHoadon();
            dtNgay_Xuatkho.EditValue = DateTime.Today;
        }

        // Đăng xuất
        private void btnLogon_Click(object sender, EventArgs e)
        {
            ChangeFormState( GoobizFrame.Windows.Forms.FormState.View);
            ShowLogonForm();
        }

        // kết thúc
        private void btnClose_Click(object sender, EventArgs e)
        {
            ChangeFormState( GoobizFrame.Windows.Forms.FormState.View);
            this.Close();
        }

        // sửa phiếu xk
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if ("" + gridView2.GetFocusedRowCellValue("Id_Xuatkho_Banhang") == "")
            {
                return;
            }
            this.PerformEdit();
        }

        // xóa phiếu xk
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ("" + gridView2.GetFocusedRowCellValue("Id_Xuatkho_Banhang") == "")
            {
                return;
            }
            this.PerformDelete();
            this.ReloadDs_XkBanhang();
        }

        #endregion

        #region process data

        // update lại values thanhtien_VAT & thanhtien trên gridview4
        void set_Value_on_Gridview4()
        {
            decimal dongia = 0;
            decimal per_vat = 0;
            if (!chkDongia_Bansi.Checked)
                dongia = Convert.ToDecimal(gridView4.GetFocusedRowCellValue(gridView4.Columns["Dongia_Ban"]));
            else
                dongia = Convert.ToDecimal(gridView4.GetFocusedRowCellValue("0" + gridView4.Columns["Dongia_Bansi"]));
            per_vat = (Convert.ToDecimal(gridView4.GetFocusedRowCellValue("Per_VAT")) / 100) / ((Convert.ToDecimal(gridView4.GetFocusedRowCellValue("Per_VAT")) + 100) / 100);
            gridView4.SetFocusedRowCellValue(gridView4.Columns["Thanhtien_VAT"], per_vat * (Convert.ToDecimal(gridView4.GetFocusedRowCellValue("Soluong")) * dongia));
            //Convert.ToDecimal(txtSotien.EditValue) * Convert.ToDecimal(0.1) / Convert.ToDecimal(1.1);
            gridView4.SetFocusedRowCellValue(gridView4.Columns["Thanhtien"], (Convert.ToDecimal(gridView4.GetFocusedRowCellValue("Soluong"))) * dongia);
        }

        // update values of panel hiển thị số tiền
        void set_Value_Thanhtien()
        {
            this.txtSotien.EditValue = Convert.ToDecimal(gridView4.Columns["Thanhtien"].SummaryItem.SummaryValue);
            this.txtSotien_Vat.EditValue = ds_Xkbanhang_Chitiet.Tables[0].Compute("Sum(Thanhtien_VAT)", "");
            this.txtTongtien_Hang.EditValue = Convert.ToDecimal("0" + txtSotien.EditValue) - Convert.ToDecimal("0" + txtSotien_Vat.EditValue);
            this.txtSotien_Chietkhau.EditValue = Convert.ToDecimal("0" + txtChietkhau.EditValue) * Convert.ToDecimal(txtSotien.EditValue) / 100;
        }

        /// <summary>
        /// add new row into ds_Xkbanhang_Chitiet
        /// </summary>
        /// <param name="Barcode_Txt">Barcode_Txt</param>
        /// <param name="Soluong">Soluong</param>
        void AddNewOrderDetail(string Barcode_Txt, object Soluong)
        {
            try   //kiem tra so luong ton
            {
                this.lblStatus_Bar.Text = "";
                DataRow nrow = null;
                DataRow[] sr = ds_Hanghoa_Ban_after_Thongke.Tables[0].Select("Barcode_Txt = '" + Barcode_Txt + "'");
                if (sr != null && sr.Length > 0)
                {
                    sr = ds_Hanghoa_Ban_after_Thongke.Tables[0].Select("Barcode_Txt = '" + Barcode_Txt + "'");
                    bool check = false;
                    if (sr == null || sr.Length == 0
                        || "" + sr[0]["Dongia_Ban"] == "") //|| "" + sr[0]["Dongia_Bansi"] == "")
                    {
                        lblStatus_Bar.Text = "Hàng hóa này chưa có Đơn giá, nhập lại Đơn giá";
                        return;
                    }
                    if (Get_Soluong_Ton_Quydoi(sr[0]["Id_Hanghoa_Ban"], id_donvitinh) < Convert.ToInt32(txtSoluong.EditValue))
                    {
                        lblStatus_Bar.Text = "Không đủ số lượng để xuất theo yêu cầu";
                        return;
                    }
                    if (ds_Xkbanhang_Chitiet.Tables[0].Rows.Count == 0)
                        check = false;
                    else
                    {
                        DataRow[] sdrHdbanhang_Chitiet = ds_Xkbanhang_Chitiet.Tables[0].Select("Id_Hanghoa_Ban =" + sr[0]["Id_Hanghoa_Ban"]
                                                                + "and Id_Donvitinh = " + id_donvitinh);
                        if (sdrHdbanhang_Chitiet.Length > 0)
                        {
                            nrow = sdrHdbanhang_Chitiet[0];
                            int soluong = Convert.ToInt32(nrow["Soluong"]) + Convert.ToInt32(txtSoluong.EditValue);
                            if (Get_Soluong_Ton_Quydoi(sr[0]["Id_Hanghoa_Ban"], id_donvitinh) < soluong)
                            {
                                lblStatus_Bar.Text = "Không đủ số lượng để xuất theo yêu cầu";
                                return;
                            }
                            nrow["Soluong"] = soluong;
                            decimal per_vat = 0;
                            per_vat = (Convert.ToDecimal(nrow["Per_VAT"]) / 100) / ((Convert.ToDecimal(nrow["Per_VAT"]) + 100) / 100);
                            if (!chkDongia_Bansi.Checked)
                            {
                                nrow["Thanhtien_VAT"] = per_vat * (Convert.ToDecimal(nrow["Soluong"]) * Convert.ToDecimal(nrow["Dongia_Ban"]));
                                nrow["Thanhtien"] = Convert.ToDecimal(nrow["Soluong"]) * Convert.ToDecimal(nrow["Dongia_Ban"]);
                            }
                            else
                            {
                                nrow["Thanhtien_VAT"] = per_vat * (Convert.ToDecimal(nrow["Soluong"]) * Convert.ToDecimal(nrow["Dongia_Bansi"]));
                                nrow["Thanhtien"] = Convert.ToDecimal(nrow["Soluong"]) * Convert.ToDecimal(nrow["Dongia_Bansi"]);
                            }
                            gridView4.FocusedRowHandle = gridView4.LocateByValue(0, gridView4.Columns["Id_Hanghoa_Ban"], sr[0]["Id_Hanghoa_Ban"]);
                            check = true;
                        }
                    }
                    if (!check)
                    {
                        nrow = ds_Xkbanhang_Chitiet.Tables[0].NewRow();//gridView4.AddNewRow();      
                        nrow["Id_Hanghoa_Ban"] = sr[0]["Id_Hanghoa_Ban"];
                        nrow["Ten_Hanghoa_Ban"] = sr[0]["Ten_Hanghoa_Ban"];
                        nrow["Ma_Hanghoa_Ban"] = sr[0]["Ma_Hanghoa_Ban"];
                        nrow["Ten_Donvitinh"] = sr[0]["Ten_Donvitinh"];
                        nrow["Id_Donvitinh"] = id_donvitinh;
                        nrow["Soluong"] = Soluong;
                        decimal dongia_ban = 0;
                        if (!chkDongia_Bansi.Checked)
                        {
                            nrow["Dongia_Ban"] = sr[0]["Dongia_Ban"];
                            nrow["Dongia"] = sr[0]["Dongia_Ban"];
                            dongia_ban = Convert.ToDecimal(nrow["Dongia_Ban"]);
                            gridView4.Columns["Dongia_Bansi"].Visible = false;
                            gridView4.Columns["Dongia_Ban"].Visible = true;
                        }
                        else
                        {
                            if (sr[0]["Dongia_Bansi"].ToString() == "")
                            {
                                lblStatus_Bar.Text = sr[0]["Ten_Hanghoa_Ban"] + " chưa có đơn giá bán sỉ ";
                                //ds_Xkbanhang_Chitiet.Tables[0].Rows[gridView4.RowCount - 1].Delete();
                                return;
                            }
                            nrow["Dongia_Bansi"] = sr[0]["Dongia_Bansi"];
                            nrow["Dongia"] = sr[0]["Dongia_Bansi"];
                            dongia_ban = Convert.ToDecimal(nrow["Dongia_Bansi"]);
                            gridView4.Columns["Dongia_Bansi"].Visible = true;
                            gridView4.Columns["Dongia_Ban"].Visible = false;
                        }
                        nrow["Per_VAT"] = 10;
                        nrow["Thanhtien_VAT"] = Convert.ToDecimal(0.1) / Convert.ToDecimal(1.1) * (Convert.ToDecimal(nrow["Soluong"]) * dongia_ban);
                        nrow["Thanhtien"] = Convert.ToDecimal(nrow["Soluong"]) * dongia_ban;
                        ds_Xkbanhang_Chitiet.Tables[0].Rows.Add(nrow);
                    }
                    this.DoClickEndEdit(dgware_Hdbanhang_Chitiet);
                    set_Value_Thanhtien();
                    txtBarcode_Txt.Text = "";
                    gridView4.BestFitColumns();
                    txtSoluong.EditValue = 1;
                    if (!btnPrint.Enabled)
                        btnPrint.Enabled = true;
                }
                else
                {
                    lblStatus_Bar.Text = "Hàng hóa này không tồn tại, vui lòng nhập lại";
                    txtBarcode_Txt.EditValue = null;
                    txtBarcode_Txt.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public decimal Get_Soluong_Ton_Quydoi(object Id_Hanghoa_Ban, object Id_Donvitinh)
        {
            try
            {
                var _Id_Donvitinh = ds_Hanghoa_Ban.Tables[0].Select(string.Format("Id_Hanghoa_Ban={0}", Id_Hanghoa_Ban))[0]["Id_Donvitinh"];
                DataSet ds_hh_nxt = Get_Soluong_Ton_Quydoi(lookUpEdit_Cuahang_Ban.EditValue, Id_Hanghoa_Ban, Id_Donvitinh);
                decimal soluong_ton_quydoi = 0;
                soluong_ton_quydoi = (Id_Donvitinh == _Id_Donvitinh)
                ? Convert.ToDecimal("0" + ds_hh_nxt.Tables[0].Compute("sum(Soluong_Ton_Qdoi)",
                        string.Format("Id_Hanghoa_Ban={0}", Id_Hanghoa_Ban)))
                : Convert.ToDecimal("0" + ds_hh_nxt.Tables[0].Compute("sum(Soluong_Ton)",
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

        //load lại ds xuất kho bán hàng 
        void ReloadDs_XkBanhang()
        {
            ds_Xkbanhang = objWareService.Get_All_Ware_Xuatkho_Banhang_ByCuahang_ByDate(LocationId_Cuahang_Ban, dtNgay_Xuatkho.EditValue).ToDataSet();
            dgware_Hdbanhang.DataSource = ds_Xkbanhang;
            dgware_Hdbanhang.DataMember = ds_Xkbanhang.Tables[0].TableName;
            this.DataBindingControl();
            if (gridView2.RowCount == 0)
                ResetText();
        }
        #endregion

        #region Process controls

        private void gridLookUpEdit_Donvitinh_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //Ecm.Ware.Forms.Frmware_Hdbanhang_Donvitinh_Dialog frm_Donvitinh = new Frmware_Hdbanhang_Donvitinh_Dialog();
            //frm_Donvitinh.setId_Hanghoa_Ban(gridView4.GetFocusedRowCellValue(gridView4.Columns["Id_Hanghoa_Ban"]));
            //frm_Donvitinh.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //frm_Donvitinh.item_Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //frm_Donvitinh.ShowDialog();
            //if (frm_Donvitinh.Id_Donvitinh != null)
            //{
            //    DataRow[] dtr_Donvitinh = ds_Donvitinh.Tables[0].Select("Id_Donvitinh = " + frm_Donvitinh.Id_Donvitinh);
            //    gridView4.SetFocusedRowCellValue(gridView4.Columns["Ten_Donvitinh"], dtr_Donvitinh[0]["Ten_Donvitinh"]);
            //    gridView4.SetFocusedRowCellValue(gridView4.Columns["Id_Donvitinh"], dtr_Donvitinh[0]["Id_Donvitinh"]);
            //    DataSet ds_HhDinhgia_By_Id_Hanghoa = objWareService.Get_All_Ware_Hanghoa_Dinhgia_By_Id_HhBan(gridView4.GetFocusedRowCellValue("Id_Hanghoa_Ban")).ToDataSet();
            //    DataRow[] dtr_GiaHanghoa_By_DVT = ds_HhDinhgia_By_Id_Hanghoa.Tables[0].Select("Id_Donvitinh = " + dtr_Donvitinh[0]["Id_Donvitinh"]);
            //    if (dtr_GiaHanghoa_By_DVT.Length == 0)
            //    {
            //        lblStatus_Bar.Text = "Hàng hóa này chưa có đơn giá";
            //        return;
            //    }
            //    if (chkDongia_Bansi.Checked)
            //        gridView4.SetFocusedRowCellValue(gridView4.Columns["Dongia_Bansi"], dtr_GiaHanghoa_By_DVT[0]["Dongia_Bansi"]);
            //    else
            //        gridView4.SetFocusedRowCellValue(gridView4.Columns["Dongia_Ban"], dtr_GiaHanghoa_By_DVT[0]["Dongia_Banle"]);

            //    int soluong = Convert.ToInt32(gridView4.GetFocusedRowCellValue(gridView4.Columns["Soluong"]));
            //    if (Get_Soluong_Ton_Quydoi(gridView4.GetFocusedRowCellValue(gridView4.Columns["Id_Hanghoa_Ban"]),
            //                                gridView4.GetFocusedRowCellValue(gridView4.Columns["Id_Donvitinh"])) < soluong)
            //    {
            //        lblStatus_Bar.Text = "Không đủ số lượng để xuất theo yêu cầu";
            //        gridView4.SetFocusedRowCellValue(gridView4.Columns["Soluong"], soluong);
            //        return;
            //    }
            //}
            //frm_Donvitinh.Dispose();
        }

        private void txtKhachhang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (this.FormState !=  GoobizFrame.Windows.Forms.FormState.View)
                    if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
                    {
                        Ecm.MasterTables.Forms.Ware.Frmware_Dm_Khachhang_Add frmware_Dm_Khachhang_Add = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Khachhang_Add();
                        frmware_Dm_Khachhang_Add.StartPosition = FormStartPosition.CenterScreen;
                        frmware_Dm_Khachhang_Add.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        frmware_Dm_Khachhang_Add.item_Cancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        frmware_Dm_Khachhang_Add.item_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        frmware_Dm_Khachhang_Add.item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        frmware_Dm_Khachhang_Add.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        frmware_Dm_Khachhang_Add.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        frmware_Dm_Khachhang_Add.ChangeFormState( GoobizFrame.Windows.Forms.FormState.View);
                        frmware_Dm_Khachhang_Add.gvDm_Khahhang.OptionsBehavior.Editable = false;
                        frmware_Dm_Khachhang_Add.panelControl2.Visible = false;
                        frmware_Dm_Khachhang_Add.panelControl1.Visible = false;
                        frmware_Dm_Khachhang_Add.splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1;
                        frmware_Dm_Khachhang_Add.ShowDialog();
                        if (frmware_Dm_Khachhang_Add.Id_Khachhang != null)
                        {
                            this.lookupEditKhachhang.EditValue = frmware_Dm_Khachhang_Add.Id_Khachhang[0];
                        }
                    }
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void txtChietkhau_EditValueChanged(object sender, EventArgs e)
        {
            if (FormState !=  GoobizFrame.Windows.Forms.FormState.View && txtSotien.Text != "")
            {
                lblStatus_Bar.Text = "";
                if (txtChietkhau.EditValue != null)
                    if (Convert.ToDecimal("0" + txtChietkhau.EditValue) > 100)
                    {
                        lblStatus_Bar.Text = "Chiết khấu không được lớn hơn 100, vui lòng nhập lại";
                        txtChietkhau.EditValue = null;
                        txtChietkhau.Focus();
                        return;
                    }
                    else
                        this.txtSotien_Chietkhau.EditValue = Convert.ToDecimal(txtChietkhau.EditValue) * Convert.ToDecimal(txtSotien.EditValue) / 100;
            }
        }

        private void lookupEditKhachhang_EditValueChanged(object sender, EventArgs e)
        {
            if (lookupEditKhachhang.EditValue != null)
            {
                this.txtTen_Khachhang.EditValue = lookupEditKhachhang.GetColumnValue("Ten_Khachhang");
                this.txtDiachi.EditValue = lookupEditKhachhang.GetColumnValue("Diachi_Khachhang");
                this.txtMasothue.EditValue = lookupEditKhachhang.GetColumnValue("Masothue");
                this.txtDienthoai.EditValue = lookupEditKhachhang.GetColumnValue("Dienthoai");
                this.txtDinhmuc_No.EditValue = lookupEditKhachhang.GetColumnValue("Dinhmuc_No");
            }
            else
            {
                this.txtTen_Khachhang.EditValue = null;
                this.txtDiachi.EditValue = null;
                this.txtMasothue.EditValue = null;
                this.txtDienthoai.EditValue = null;
                this.txtDinhmuc_No.EditValue = null;
            }
        }

        private void chkDongia_Bansi_CheckedChanged(object sender, EventArgs e)
        {
            if (FormState ==  GoobizFrame.Windows.Forms.FormState.View
                     || FormState ==  GoobizFrame.Windows.Forms.FormState.Cancel)
                return;
            if (gridView4.RowCount == 0)
                return;
            if (gridView4.Columns["Id_Hanghoa_Ban"].ToString() == "")
                return;
            System.Collections.ArrayList List_ItemToDelete = new System.Collections.ArrayList();
            DataRow[] dtr = null;
            if (!chkDongia_Bansi.Checked)
            {
                gridView4.Columns["Dongia_Bansi"].Visible = false;
                gridView4.Columns["Dongia_Ban"].Visible = true;
                for (int i = 0; i < gridView4.RowCount; i++)
                {
                    dtr = ds_Hanghoa_Ban_after_Thongke.Tables[0].Select("Id_Hanghoa_Ban = " + gridView4.GetRowCellValue(i, gridView4.Columns["Id_Hanghoa_Ban"])
                                                                    + "and  Id_Donvitinh = " + gridView4.GetRowCellValue(i, gridView4.Columns["Id_Donvitinh"]));
                    gridView4.SetRowCellValue(i, gridView4.Columns["Dongia_Ban"], dtr[0]["Dongia_Ban"]);
                    gridView4.SetRowCellValue(i, gridView4.Columns["Dongia_Bansi"], null);
                    decimal thanhtien_VAT;
                    decimal thanhtien;
                    thanhtien_VAT = Convert.ToDecimal(gridView4.GetRowCellValue(i, gridView4.Columns["Per_VAT"])) *
                        (Convert.ToDecimal(gridView4.GetRowCellValue(i, gridView4.Columns["Soluong"])) * Convert.ToDecimal(gridView4.GetRowCellValue(i, gridView4.Columns["Dongia_Ban"])) / 100);

                    thanhtien = (Convert.ToDecimal(gridView4.GetRowCellValue(i, gridView4.Columns["Soluong"])) * Convert.ToDecimal("0" + gridView4.GetRowCellValue(i, gridView4.Columns["Dongia_Ban"])));
                    gridView4.SetRowCellValue(i, gridView4.Columns["Thanhtien"], thanhtien);
                }
            }
            else
            {
                gridView4.Columns["Dongia_Bansi"].Visible = true;
                gridView4.Columns["Dongia_Ban"].Visible = false;
                bool check = false;
                for (int i = 0; i < ds_Xkbanhang_Chitiet.Tables[0].Rows.Count; )
                {
                    dtr = ds_Hanghoa_Ban_after_Thongke.Tables[0].Select("Id_Hanghoa_Ban = " + gridView4.GetRowCellValue(i, gridView4.Columns["Id_Hanghoa_Ban"]) + "and Id_Donvitinh = " + gridView4.GetRowCellValue(i, gridView4.Columns["Id_Donvitinh"]));
                    gridView4.SetRowCellValue(i, gridView4.Columns["Dongia_Bansi"], dtr[0]["Dongia_Bansi"]);
                    gridView4.SetRowCellValue(i, gridView4.Columns["Dongia_Ban"], null);
                    if (Convert.ToDecimal("0" + gridView4.GetRowCellValue(i, gridView4.Columns["Dongia_Bansi"])) == 0)
                    {
                        List_ItemToDelete.Add(gridView4.GetRowCellValue(i, gridView4.Columns["Id_Hanghoa_Ban"]));
                        gridView4.SetRowCellValue(i, gridView4.Columns["Thanhtien"], 0);
                        check = true;
                    }
                    else
                    {
                        decimal thanhtien_VAT;
                        decimal thanhtien;
                        thanhtien_VAT = Convert.ToDecimal(gridView4.GetRowCellValue(i, gridView4.Columns["Per_VAT"])) *
                            (Convert.ToDecimal(gridView4.GetRowCellValue(i, gridView4.Columns["Soluong"])) * Convert.ToDecimal(gridView4.GetRowCellValue(i, gridView4.Columns["Dongia_Bansi"])) / 100);
                        gridView4.SetRowCellValue(i, gridView4.Columns["Thanhtien_VAT"], thanhtien_VAT);
                        thanhtien = (Convert.ToDecimal(gridView4.GetRowCellValue(i, gridView4.Columns["Soluong"])) * Convert.ToDecimal("0" + gridView4.GetRowCellValue(i, gridView4.Columns["Dongia_Bansi"]))) + thanhtien_VAT;
                        gridView4.SetRowCellValue(i, gridView4.Columns["Thanhtien"], thanhtien);
                    }
                    i++;
                }
                if (check)
                {
                    if ( GoobizFrame.Windows.Forms.MessageDialog.Show(" Hàng hóa chưa có đơn giá bán sỉ, xóa khỏi danh sách ", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        for (int x = 0; x < List_ItemToDelete.Count; x++)
                        {
                            object id_hanghoa_ban = List_ItemToDelete[x];
                            for (int j = 0; j < ds_Xkbanhang_Chitiet.Tables[0].Rows.Count; j++)
                            {
                                if (ds_Xkbanhang_Chitiet.Tables[0].Rows[j]["Id_Hanghoa_Ban"].Equals(id_hanghoa_ban))
                                    ds_Xkbanhang_Chitiet.Tables[0].Rows[j].Delete();
                            }
                        }
                    }
                    else
                        dgware_Hdbanhang_Chitiet.DataSource = ds_Xkbanhang_Chitiet.Tables[0];
                }
            }
        }

        private void txtMa_Hanghoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtMa_Hanghoa.Text != "")
            {
                DataRow[] dtr = ds_Hanghoa_Ban.Tables[0].Select("Ma_Hanghoa_Ban = '" + txtMa_Hanghoa.EditValue + "'");
                if (dtr.Length > 0)
                {
                    AddNewOrderDetail(dtr[0]["Barcode_Txt"].ToString(), txtSoluong.EditValue);
                    txtMa_Hanghoa.Text = "";
                }
                else
                    lblStatus_Bar.Text = "Hàng hóa này không tồn tại, vui lòng nhập lại";
            }
        }

        private void txtBarcode_Txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtBarcode_Txt.Text != "")
                AddNewOrderDetail(txtBarcode_Txt.Text, txtSoluong.EditValue);
        }

        private void dtNgay_Xuatkho_EditValueChanged(object sender, EventArgs e)
        {
            if (dtNgay_Xuatkho.EditValue != null)
            {
                this.ReloadDs_XkBanhang();
                DisplayInfo_DsHoadon();
            }
        }

        private void chkShowPreviewDsHoadon_CheckedChanged(object sender, EventArgs e)
        {
            gridView2.OptionsView.ShowPreview = chkShowPreviewDsHoadon.Checked;
        }

        #endregion

        private void txtChietkhau_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue.ToString() != ""
                && Convert.ToInt32(e.NewValue) > 100)
                e.Cancel = true;
        }





    }
}


