using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Hdbanhang_noVAT_Hhban_BK170814 : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        DataSet ds_Hdbanhang = new DataSet();
        DataSet ds_Hdbanhang_Chitiet = new DataSet();
        DataSet ds_Hanghoa_Ban_after_Thongke = new DataSet();
        DataSet dsCtrinh_Kmai_Chitiet;
        DataSet dsDm_Loai_Hanghoa_Ban;
        DataSet ds_Khachhang;
        DataSet ds_Nhansu;
        DataSet ds_Donvitinh;
        DataSet dsHeso_Chuongtrinh;
        double thanhtien;
        object identity;
        decimal vip_per_dongia = 0;
        bool AllowEdit_Per_Dongia = false;
        int Id_Nhansu_Km = -1;
        object sotien_mat;
        object sotien_thua;
        object LocationId_Cuahang_Ban;
        int Id_Hdbanhang_Chitiet;
        object id_donvitinh = null;

        #region local data
        DataSet dsSys_Lognotify = null;
        string xml_REX_NHANSU = @"Resources\localdata\Rex_Nhansu.xml";
        string xml_WARE_DM_DONVITINH = @"Resources\localdata\Ware_Dm_Donvitinh.xml";
        string xml_WARE_DM_KHACHHANG = @"Resources\localdata\Ware_Dm_Khachhang.xml";
        DateTime dtlc_ware_dm_donvitinh;
        DateTime dtlc_rex_nhansu;
        DateTime dtlc_ware_dm_khachhang;
        DateTime dtlc_ware_dm_loai_hanghoa_by_location;
        #endregion

        #region Initialize

        public Frmware_Hdbanhang_noVAT_Hhban_BK170814()
        {
            InitializeComponent();

            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");
            xtraTabControl_Main.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            xtraTabControl2.ShowTabHeader = DevExpress.Utils.DefaultBoolean.True;
            BarSystem.Visible = false;
            lblStatus_Bar.Text = "";

            ShowLogonForm();

            #region Gán quyền thao tác trên form
            //btnAdd.Enabled = EnableAdd;
            #endregion
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

        /// <summary>
        /// query danh sach hang hoa thuoc vao cua hang hien tai
        /// </summary>
        void LoadMasterData()
        {
            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");

            dsSys_Lognotify = objMasterService.Get_Sys_Lognotify_SelectLastChange_OfTables("[ware_dm_donvitinh], [rex_nhansu], [ware_dm_loai_hanghoa_ban]").ToDataSet();
            dtlc_rex_nhansu = GetLastChange_FrmLognotify("REX_NHANSU");
            dtlc_ware_dm_donvitinh = GetLastChange_FrmLognotify("WARE_DM_DONVITINH");
            dtlc_ware_dm_loai_hanghoa_by_location = GetLastChange_FrmLognotify("WARE_DM_LOAI_HANGHOA_BAN");
            if (DateTime.Compare(dtlc_rex_nhansu, System.IO.File.GetLastWriteTime(xml_REX_NHANSU)) > 0
                || !System.IO.File.Exists(xml_REX_NHANSU))
            {
                ds_Nhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
                ds_Nhansu.WriteXml(xml_REX_NHANSU, XmlWriteMode.WriteSchema);
            }
            else
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
            //dsCtrinh_Kmai_Chitiet = objWareService.Get_All_Ware_Ctrinh_Kmai_Chitiet_ByDate(objWareService.GetServerDateTime()).ToDataSet();
            dsDm_Loai_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Ban_SelectBy_Id_Cuahang_Ban(LocationId_Cuahang_Ban).ToDataSet();
            ds_Hanghoa_Ban_after_Thongke = objWareService.Get_All_Ware_Dm_Hanghoa_Ban_Dinhgia_After_Thongke(LocationId_Cuahang_Ban).ToDataSet();
            gridLookUpEdit_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban_after_Thongke.Tables[0];
            gridLookUpEdit_Ma_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban_after_Thongke.Tables[0];
            //Get data Rex_Nhansu
            lookUpEdit_Nhansu_Banhang.Properties.DataSource = ds_Nhansu.Tables[0];
            //lookUpEdit_Nhansu_Banhang.EditValue = Convert.ToInt64( GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
            gridLookUpEdit_Loai_Hanghoa_Ban.DataSource = dsDm_Loai_Hanghoa_Ban.Tables[0];
            gridLookup_Donvitinh.DataSource = ds_Donvitinh.Tables[0];
        }
        #endregion

        #region Event Override
        /// <summary>
        /// load master data
        /// </summary>
        public override void DisplayInfo()
        {
            //Set lại trạng thái form là view
            FormState = GoobizFrame.Windows.Forms.FormState.View;

            panelControl5.Visible = true;
            try
            {
                dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet();
                //get id_cuahang dua vao vi tri cua may ban hang - set tu Frmware_SetLocation
                LocationId_Cuahang_Ban = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocation("Id_Cuahang_Ban");
                lookUpEdit_Cuahang_Ban.EditValue = Convert.ToInt64(LocationId_Cuahang_Ban);
                //dtNgay_Chungtu.DateTime = objWareService.GetServerDateTime();                
                lookUpEdit_Nhansu_Banhang.EditValue = Convert.ToInt64(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
                if (lookUpEdit_Cuahang_Ban.Properties.DataSource == null)
                    lookUpEdit_Cuahang_Ban.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().ToDataSet().Tables[0];
                txtBarcode_Txt.EditValue = null;
                txtKm_All.Enabled = false;
                txtMa_Khachhang.Enabled = false;
                this.ChangeStatus(false);
                if (gridView1.RowCount > 0)
                {
                    gridView1.Focus();
                    this.gridView1.BestFitColumns();
                }
                DisplayInfo2();
                id_donvitinh = null;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
            }
        }

        void setColorHanghoa()
        {
            dgware_Dm_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban_after_Thongke.Tables[0];  //ds_Hanghoa_Ban.Tables[0];
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
                        styleFormatCondition.Appearance.BackColor = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetColor(Convert.ToInt32(drNhom_Hanghoa_Ban["Id_Nhom_Hanghoa_Ban"]) % i);
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

        /// <summary>
        /// ClearDataBindings
        /// </summary>
        public override void ClearDataBindings()
        {
            this.txtId_Hdbanhang.DataBindings.Clear();
            this.txtSochungtu.DataBindings.Clear();
            this.txtSotien.DataBindings.Clear();
            this.txtSotien_Vat.DataBindings.Clear();
            this.dtNgay_Chungtu.DataBindings.Clear();
            this.lookUpEdit_Cuahang_Ban.DataBindings.Clear();
            this.lookUpEdit_Nhansu_Banhang.DataBindings.Clear();
            lookUpEdit_Khachhang.DataBindings.Clear();
        }

        /// <summary>
        /// Add DataBinding
        /// </summary>
        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtId_Hdbanhang.DataBindings.Add("EditValue", ds_Hdbanhang, ds_Hdbanhang.Tables[0].TableName + ".Id_Hdbanhang");
                this.txtSochungtu.DataBindings.Add("EditValue", ds_Hdbanhang, ds_Hdbanhang.Tables[0].TableName + ".Sochungtu");
                this.txtSotien.DataBindings.Add("EditValue", ds_Hdbanhang, ds_Hdbanhang.Tables[0].TableName + ".Sotien");
                this.txtSotien_Vat.DataBindings.Add("EditValue", ds_Hdbanhang, ds_Hdbanhang.Tables[0].TableName + ".Sotien_Vat");
                this.dtNgay_Chungtu.DataBindings.Add("EditValue", ds_Hdbanhang, ds_Hdbanhang.Tables[0].TableName + ".Ngay_Chungtu");
                this.lookUpEdit_Cuahang_Ban.DataBindings.Add("EditValue", ds_Hdbanhang, ds_Hdbanhang.Tables[0].TableName + ".Id_Cuahang_Ban");
                this.lookUpEdit_Nhansu_Banhang.DataBindings.Add("EditValue", ds_Hdbanhang, ds_Hdbanhang.Tables[0].TableName + ".Id_Nhansu_Bh");
                lookUpEdit_Khachhang.DataBindings.Add("EditValue", ds_Hdbanhang, ds_Hdbanhang.Tables[0].TableName + ".Id_Khachhang");
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif

            }
        }

        /// <summary>
        /// change control status as change formstate
        /// </summary>
        /// <param name="editTable"></param>
        public override void ChangeStatus(bool editTable)
        {
            this.dgware_Hdbanhang.Enabled = !editTable;
            gridView4.OptionsBehavior.Editable = editTable;
            this.txtBarcode_Txt.Properties.ReadOnly = !editTable;
            this.txtSoluong.Properties.ReadOnly = !editTable;
            //alway lock
            this.txtId_Hdbanhang.Properties.ReadOnly = true;
            this.txtSochungtu.Properties.ReadOnly = true;
            this.dtNgay_Chungtu.Properties.ReadOnly = true;
            this.lookUpEdit_Cuahang_Ban.Properties.ReadOnly = true;
            this.lookUpEdit_Nhansu_Banhang.Properties.ReadOnly = true;
            this.txtSotien.Properties.ReadOnly = true;
            txtMa_Khachhang.Properties.ReadOnly = !editTable;
            btnLogon.Enabled = !editTable;
            btnAdd.Enabled = (!editTable) ? this.EnableAdd : false;
            btnPrint.Enabled = (!editTable) ? EnablePrintPreview : false;
            btnCancel.Enabled = editTable;
            btnChon_HH.Enabled = editTable;
            //tabpage ds hang hoa ban
            xtraTabPage4.PageEnabled = editTable;
            this.chkDongia_Bansi.Enabled = editTable;
            this.chkDongia_Bansi.Checked = false;
            repositoryItemButtonEdit3.Buttons[0].Visible = editTable;
            repositoryItemButtonEdit4.Buttons[0].Visible = editTable;
        }

        /// <summary>
        /// reset control editvalue
        /// </summary>
        public override void ResetText()
        {
            lblStatus_Bar.Text = "";
            this.txtId_Hdbanhang.EditValue = "";
            this.txtSotien.EditValue = "";
            this.txtSotien_Vat.EditValue = "";
            this.txtSotien_Khachtra.EditValue = "";
            this.txtSotien_Thua.EditValue = "";
            txtKm_All.EditValue = 0;
            txtMin_Quota.EditValue = "";
            txtMa_Khachhang.EditValue = "";
            lookUpEdit_Khachhang.EditValue = DBNull.Value;
            Id_Nhansu_Km = -1;
            Id_Hdbanhang_Chitiet = 0;
            this.ds_Hdbanhang_Chitiet = objWareService.Get_All_Ware_Hdbanhang_Chitiet_By_Hdbanhang(0).ToDataSet();
            this.dgware_Hdbanhang_Chitiet.DataSource = ds_Hdbanhang_Chitiet.Tables[0];
        }

        public object InsertObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Hdbanhang objWare_Hdbanhang = new Ecm.WebReferences.WareService.Ware_Hdbanhang();
                objWare_Hdbanhang.Id_Hdbanhang = -1;
                txtSochungtu.EditValue = objWareService.Getnew_Sohoadon_NoVAT(
                ((DataRowView)lookUpEdit_Cuahang_Ban.Properties.GetDataSourceRowByKeyValue(lookUpEdit_Cuahang_Ban.EditValue))["Ma_Cuahang_Ban"]);
                objWare_Hdbanhang.Sochungtu = txtSochungtu.EditValue;
                objWare_Hdbanhang.Sotien = txtSotien.EditValue;
                objWare_Hdbanhang.Sotien_Vat = txtSotien_Vat.EditValue;
                objWare_Hdbanhang.Ngay_Chungtu = dtNgay_Chungtu.EditValue;
                objWare_Hdbanhang.Ngay_Thanhtoan = dtNgay_Chungtu.EditValue;
                objWare_Hdbanhang.NoVAT = true;

                if ("" + lookUpEdit_Cuahang_Ban.EditValue != "")
                    objWare_Hdbanhang.Id_Cuahang_Ban = lookUpEdit_Cuahang_Ban.EditValue;

                if ("" + lookUpEdit_Nhansu_Banhang.EditValue != "")
                    objWare_Hdbanhang.Id_Nhansu_Bh = lookUpEdit_Nhansu_Banhang.EditValue;

                objWare_Hdbanhang.Id_Khachang = ("" + lookUpEdit_Khachhang.EditValue != "") ? lookUpEdit_Khachhang.EditValue : -1;
                objWare_Hdbanhang.Id_Nhansu_Km = Id_Nhansu_Km;
                identity = objWareService.Insert_Ware_Hdbanhang(objWare_Hdbanhang);
                if (identity != null)
                {
                    dgware_Hdbanhang_Chitiet.EmbeddedNavigator.Buttons.DoClick(dgware_Hdbanhang_Chitiet.EmbeddedNavigator.Buttons.EndEdit);
                    foreach (DataRow dr in ds_Hdbanhang_Chitiet.Tables[0].Rows)
                    {
                        dr["Id_Hdbanhang"] = identity;
                    }
                    //update hdmuahang_chitiet
                    objWareService.Update_Ware_Hdbanhang_Chitiet_Collection(ds_Hdbanhang_Chitiet);
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
                Ecm.WebReferences.WareService.Ware_Hdbanhang objWare_Hdbanhang = new Ecm.WebReferences.WareService.Ware_Hdbanhang();
                objWare_Hdbanhang.Id_Hdbanhang = txtId_Hdbanhang.EditValue;
                objWare_Hdbanhang.Sochungtu = txtSochungtu.EditValue;
                objWare_Hdbanhang.Sotien = txtSotien.EditValue;
                objWare_Hdbanhang.Sotien_Vat = txtSotien_Vat.EditValue;
                objWare_Hdbanhang.Ngay_Chungtu = dtNgay_Chungtu.EditValue;
                objWare_Hdbanhang.Hoten_Nguoimua = "";
                objWare_Hdbanhang.Per_Vat = 0;
                objWare_Hdbanhang.Phuongthuc_Thanhtoan = "TM";
                objWare_Hdbanhang.So_Seri = "N/A";
                objWare_Hdbanhang.Ngay_Thanhtoan = dtNgay_Chungtu.EditValue;
                objWare_Hdbanhang.Id_Khachang = -1;
                objWare_Hdbanhang.NoVAT = true;

                if ("" + lookUpEdit_Cuahang_Ban.EditValue != "")
                    objWare_Hdbanhang.Id_Cuahang_Ban = lookUpEdit_Cuahang_Ban.EditValue;

                if ("" + lookUpEdit_Nhansu_Banhang.EditValue != "")
                    objWare_Hdbanhang.Id_Nhansu_Bh = lookUpEdit_Nhansu_Banhang.EditValue;

                objWare_Hdbanhang.Id_Khachang = ("" + lookUpEdit_Khachhang.EditValue != "") ? lookUpEdit_Khachhang.EditValue : -1;
                objWare_Hdbanhang.Id_Nhansu_Km = Id_Nhansu_Km;
                //update donmuahang
                objWareService.Update_Ware_Hdbanhang(objWare_Hdbanhang);

                //update donmuahang_chitiet
                this.DoClickEndEdit(dgware_Hdbanhang_Chitiet);
                foreach (DataRow dr in ds_Hdbanhang_Chitiet.Tables[0].Rows)
                {
                    if (dr.RowState == DataRowState.Added)
                        dr["Id_Hdbanhang"] = txtId_Hdbanhang.EditValue;
                }

                objWareService.Update_Ware_Hdbanhang_Chitiet_Collection(ds_Hdbanhang_Chitiet);
                return true;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return false;
            }
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.WareService.Ware_Hdbanhang objWare_Hdbanhang = new Ecm.WebReferences.WareService.Ware_Hdbanhang();
            objWare_Hdbanhang.Id_Hdbanhang = txtId_Hdbanhang.EditValue;
            return objWareService.Delete_Ware_Hdbanhang(objWare_Hdbanhang);
        }

        void changeStatusButton(bool boo)
        {
            btnCancel.Enabled = boo;
            lblStatus_Bar.Text = "";
            btnCash.Visible = boo;
            btnKhachhang.Enabled = boo;
            btnKm_All.Enabled = boo;
            txtSoluong.Enabled = boo;
            txtBarcode_Txt.Enabled = boo;
            txtSotien_Khachtra.Enabled = boo;
            btnPrint.Visible = (!boo) ? EnablePrintPreview : false;
            btnHdbanhang.Enabled = !boo;
            btnLogon.Enabled = !boo;
            btnSplit.Enabled = (!boo) ? EnableQuery : false;
            btnClose.Enabled = !boo;
            btnAdd.Enabled = !boo;
        }

        public override bool PerformAdd()
        {
            this.gridColumn31.Visible = false;
            gridColumn35.Visible = true;
            repositoryItemButtonEdit1.Buttons[0].Visible = false;
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            AllowEdit_Per_Dongia = false;
            splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1;
            changeStatusButton(true);
            this.ResetText();
            lookUpEdit_Cuahang_Ban.EditValue = Convert.ToInt64(LocationId_Cuahang_Ban);
            lookUpEdit_Nhansu_Banhang.EditValue = Convert.ToInt64(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
            DataSet ds_Cuahang_Ban_ByNhansu = objMasterService.Get_All_Ware_Dm_Cuahang_Ban_By_Id_Nhansu(lookUpEdit_Nhansu_Banhang.EditValue).ToDataSet();
            DataRow dtr = null;
            bool check = false;
            if (ds_Cuahang_Ban_ByNhansu.Tables[0].Rows.Count == 0)
                check = true;
            else
            {
                for (int i = 0; i < ds_Cuahang_Ban_ByNhansu.Tables[0].Rows.Count; i++)
                {
                    dtr = ds_Cuahang_Ban_ByNhansu.Tables[0].Rows[i];
                    if (!dtr["Ten_Cuahang_Ban"].Equals(lookUpEdit_Cuahang_Ban.Text))
                        check = true;
                    else
                    {
                        check = false;
                        break;
                    }
                }
            }
            if (check)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Bạn không có quyền thao tác trên cửa hàng " + lookUpEdit_Cuahang_Ban.Text + "\n vui lòng hủy thao tác");
                lookUpEdit_Nhansu_Banhang.EditValue = null;
                btnCancel.Enabled = false;
                btnKm_All.Enabled = false;
                btnCash.Enabled = false;
                btnKhachhang.Enabled = false;
                btnLogon.Enabled = true;
                btnClose.Enabled = true;
                return false;
            }
            LoadMasterData();
            setColorHanghoa();
            this.ChangeStatus(true);
            txtBarcode_Txt.Focus();
            dtNgay_Chungtu.EditValue = objWareService.GetServerDateTime();
            txtSochungtu.EditValue = objWareService.Getnew_Sohoadon_NoVAT(
                ((DataRowView)lookUpEdit_Cuahang_Ban.Properties.GetDataSourceRowByKeyValue(lookUpEdit_Cuahang_Ban.EditValue))["Ma_Cuahang_Ban"]);
            btnCash.Enabled = false;
            return true;
        }

        public override bool PerformEdit()
        {
            if (!GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + lookUpEdit_Nhansu_Banhang.EditValue))
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                return false;
            }
            this.ChangeStatus(true);
            AllowEdit_Per_Dongia = false;
            Id_Nhansu_Km = -1;
            return true;
        }

        public override bool PerformCancel()
        {
            this.gridColumn31.Visible = true;
            changeStatusButton(false);
            this.DisplayInfo();
            return true;
        }

        public override bool PerformSave()
        {
            try
            {
                bool success = false;
                System.Collections.Hashtable htbControl1 = new System.Collections.Hashtable();
                htbControl1.Add(txtSochungtu, lblSochungtu.Text);
                htbControl1.Add(txtSotien, lblSotien.Text);
                htbControl1.Add(txtSotien_Vat, lblSotien_Vat.Text);
                htbControl1.Add(dtNgay_Chungtu, lblNgay_Chungtu.Text);
                htbControl1.Add(lookUpEdit_Cuahang_Ban, lblCuahang_Ban.Text);
                htbControl1.Add(lookUpEdit_Nhansu_Banhang, lblNhansu_Banhang.Text);
                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(htbControl1))
                    return false;
                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                {
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                    success = (bool)this.UpdateObject();
                if (success)
                {
                    //if ("" + lookUpEdit_Khachhang.EditValue != "") //Update Min quota
                    //    objWareService.Update_Ware_Khachhang_Min_Quota(lookUpEdit_Khachhang.EditValue, dtNgay_Chungtu.EditValue);
                    this.DisplayInfo();
                }
                return success;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return false;
            }
        }

        public override bool PerformDelete()
        {
            if (GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUser().ToUpper() != "ADMIN")
                if (!GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + lookUpEdit_Nhansu_Banhang.EditValue))
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                    return false;
                }
            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Hdbanhang"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Hdbanhang")   }) == DialogResult.Yes)
            {
                try
                {
                    this.DeleteObject();
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                }
                this.DisplayInfo();
            }
            return base.PerformDelete();
        }

        public override bool PerformPrintPreview()
        {
            if (identity == null)
                return false;
            try
            {
                DataRow[] sdr = ds_Hdbanhang.Tables[0].Select("Id_Hdbanhang = " + identity);
                DataSets.dsHdbanhang_Chitiet dsrHdbanhang_Chitiet = new Ecm.Ware.DataSets.dsHdbanhang_Chitiet();
                Reports.rptHdbanhang_noVAT rptHdbanhang_noVAT = new Ecm.Ware.Reports.rptHdbanhang_noVAT();
                GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
                frmPrintPreview.Report = rptHdbanhang_noVAT;
                //frmPrintPreview.Name = this.Name;
                //frmPrintPreview.EnablePrintPreview = this.EnablePrintPreview;
                rptHdbanhang_noVAT.DataSource = dsrHdbanhang_Chitiet;
                int i = 1;
                foreach (DataRow dr in ds_Hdbanhang_Chitiet.Tables[0].Rows)
                {
                    DataRow drnew = dsrHdbanhang_Chitiet.Tables[0].NewRow();
                    foreach (DataColumn dc in ds_Hdbanhang_Chitiet.Tables[0].Columns)
                    {
                        try
                        {
                            drnew[dc.ColumnName] = dr[dc.ColumnName];
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    drnew["Ten_Hanghoa"] = dr["Ten_Hanghoa_Ban"];
                    drnew["Ma_Hanghoa"] = dr["Ma_Hanghoa_Ban"];
                    drnew["Stt"] = i++;
                    dsrHdbanhang_Chitiet.Tables[0].Rows.Add(drnew);
                }
                //add parameter values
                rptHdbanhang_noVAT.xrLbl_Tieude.Text = "HÓA ĐƠN KHÁCH HÀNG";
                rptHdbanhang_noVAT.tbc_Ngay.Text = "" + string.Format("{0:dd/MM/yyyy hh:mm:ss tt}", sdr[0]["Ngay_Chungtu"]);
                lookUpEdit_Nhansu_Banhang.EditValue = sdr[0]["Id_Nhansu_Bh"];
                rptHdbanhang_noVAT.lblNhansu_Bill.Text = lookUpEdit_Nhansu_Banhang.Text;
                DataRow[] sdrKhachhang = null;
                if (Convert.ToInt32(sdr[0]["Id_Khachhang"]) != -1)
                {
                    Load_Khachhang();
                    sdrKhachhang = ds_Khachhang.Tables[0].Select("Id_Khachhang=" + sdr[0]["Id_Khachhang"]);
                    rptHdbanhang_noVAT.lblKhachhang.Text = "" +
                       ((sdrKhachhang != null && sdrKhachhang.Length > 0) ? sdrKhachhang[0]["Ten_Khachhang"] : "");
                }
                rptHdbanhang_noVAT.tbcSochungtu.Text = sdr[0]["Sochungtu"].ToString();
                double thanhtien = Convert.ToDouble(ds_Hdbanhang_Chitiet.Tables[0].Compute("sum(Thanhtien_TG)", ""));
                string str = GoobizFrame.Windows.HelperClasses.ReadNumber.ChangeNum2VNStr(thanhtien, " đồng.");
                str = str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower();
                rptHdbanhang_noVAT.tbcThanhtien_Bangchu.Text = str;
                rptHdbanhang_noVAT.lblTongcong.Text = thanhtien.ToString();
                rptHdbanhang_noVAT.PageSize = new Size(800, 2000 + 120 * Convert.ToInt32(dsrHdbanhang_Chitiet.Tables[0].Rows.Count));
                rptHdbanhang_noVAT.xrTable6.Location = new System.Drawing.Point(21, 42);
                rptHdbanhang_noVAT.xrTable4.Location = new System.Drawing.Point(21, 135);

                #region Set he so ctrinh - logo, ten cty
                using (DataSet dsCompany_Paras = new DataSet())
                {
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
                //if (lookUpEdit_Khachhang.Text != "") // check if khách hàng quota --> hiển thị thông tin giảm giá
                //{
                //    DataSet dsKhachhang_KM = objWareService.Get_All_Ware_Khachhang_Quota_Detail_By_Khachhang(lookUpEdit_Khachhang.EditValue).ToDataSet();
                //    if (dsKhachhang_KM.Tables.Count > 0 && dsKhachhang_KM.Tables[0].Rows.Count > 0)
                //    {
                //        if (dsKhachhang_KM.Tables[0].Rows[0]["Id_Vip_Member"].ToString() == "") // check if khach hang quota
                //        {
                //            rptHdbanhang_noVAT.lblSotien_Giam.Visible = true;
                //            rptHdbanhang_noVAT.xrSotien_Giam.Visible = true;
                //        }
                //    }
                //}
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
                    var reportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rptHdbanhang_noVAT);
                    reportPrintTool.Print();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return base.PerformPrintPreview();
        }
        #endregion

        #region Logon process


        /// <summary>
        /// show screen logon
        /// </summary>
        void ShowLogonForm()
        {
            if (FormState == GoobizFrame.Windows.Forms.FormState.View)
            {
                panelControl5.Visible = false;
                ShowTabPage(xtraTabPage_Logon);
                item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnCash.Enabled = false;
                BarSystem.Visible = false;
                item_Delete.Enabled = false;
                item_Edit.Enabled = false;
                btnLogon.Visible = true;
            }
            else
            {
                ShowTabPage(xtraTabPage_Sale);
            }
        }

        #endregion

        #region Even


        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //Kiem tra so luong ton
            lblStatus_Bar.Text = "";
            this.DoClickEndEdit(dgware_Hdbanhang_Chitiet);
            if (e.Column.FieldName == "Soluong")
            {
                int soluong = Convert.ToInt32(gridView4.GetFocusedRowCellValue("Soluong"));
                if (soluong.ToString().Contains("-"))
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Số lượng không được nhập số âm");
                    string soluong_New = soluong.ToString().Replace("-", "");
                    gridView4.SetFocusedRowCellValue(gridView4.FocusedColumn, soluong_New);
                    return;
                }
                if (soluong == 0)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Số lượng không được bằng 0");
                    gridView4.SetFocusedRowCellValue(gridView4.FocusedColumn, 1);
                    return;
                }
                if (soluong.ToString().Length >= 6)
                {
                    soluong = Convert.ToInt32(soluong.ToString().Substring(0, 5));
                    gridView4.SetFocusedRowCellValue(gridView4.FocusedColumn, soluong);
                    return;
                }
                if (Get_Soluong_Ton_Quydoi(gridView4.GetFocusedRowCellValue("Id_Hanghoa_Ban"),
                                    gridView4.GetFocusedRowCellValue("Id_Donvitinh")) < soluong)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Không đủ số lượng để xuất theo yêu cầu");
                    gridView4.SetFocusedRowCellValue(gridView4.Columns["Soluong"], Get_Soluong_Ton_Quydoi(gridView4.GetFocusedRowCellValue("Id_Hanghoa_Ban"),
                                    gridView4.GetFocusedRowCellValue("Id_Donvitinh")));
                    return;
                }
            }
            if (e.Column.FieldName == "Soluong" || e.Column.FieldName == "Dongia_Ban" || e.Column.FieldName == "Per_Dongia")
            {
                if ("" + gridView4.GetFocusedRowCellValue("Soluong") != ""
                       && "" + gridView4.GetFocusedRowCellValue("Dongia_Ban") != "")
                {
                    gridView4.SetFocusedRowCellValue(gridView4.Columns["Thanhtien"],
                        Convert.ToDecimal(gridView4.GetFocusedRowCellValue("Soluong"))
                                    * Convert.ToDecimal(gridView4.GetFocusedRowCellValue("Dongia_Ban")) * (1 - Convert.ToDecimal(gridView4.GetFocusedRowCellValue("Per_Dongia")) / 100));
                    //                gridView4.SetFocusedRowCellValue(gridView4.Columns["Thanhtien_Km"],
                    //Convert.ToDecimal(gridView4.GetFocusedRowCellValue("Soluong"))
                    //            * (Convert.ToDecimal(gridView4.GetFocusedRowCellValue("Dongia_Ban")) * Convert.ToDecimal(gridView4.GetFocusedRowCellValue("Per_Dongia")) / 100));

                    this.DoClickEndEdit(dgware_Hdbanhang_Chitiet); // dgware_Hdbanhang_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                }
            }
            if (e.Column.FieldName == "Soluong" || e.Column.FieldName == "Per_Dongia" || e.Column.FieldName == "Dongia_Bansi")
            {
                if ("" + gridView4.GetFocusedRowCellValue("Soluong") != ""
                          && "" + gridView4.GetFocusedRowCellValue("Dongia_Bansi") != "")
                {
                    gridView4.SetFocusedRowCellValue(gridView4.Columns["Thanhtien"],
                        Convert.ToDecimal(gridView4.GetFocusedRowCellValue("Soluong"))
                                    * Convert.ToDecimal(gridView4.GetFocusedRowCellValue("Dongia_Bansi")) * (1 - Convert.ToDecimal(gridView4.GetFocusedRowCellValue("Per_Dongia")) / 100));
                    //gridView4.SetFocusedRowCellValue(gridView4.Columns["Thanhtien_Km"],
                    //    Convert.ToDecimal(gridView4.GetFocusedRowCellValue("Soluong"))
                    //                * (Convert.ToDecimal(gridView4.GetFocusedRowCellValue("Dongia_Bansi")) * Convert.ToDecimal(gridView4.GetFocusedRowCellValue("Per_Dongia")) / 100));
                    this.DoClickEndEdit(dgware_Hdbanhang_Chitiet); //dgware_Hdbanhang_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                }
            }
            if (e.Column.FieldName == "Thanhtien")
            {
                gridView4.FocusedRowHandle = gridView4.RowCount;
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
                //set giam gia theo ct km
                gridView4.SetFocusedRowCellValue(gridView4.Columns["Per_Dongia"], 0);
            }         
            //if (txtMa_Khachhang.Text != "")
            //    Recal_Dongia();
            //else
            //{
            //    this.DoClickEndEdit(dgware_Hdbanhang_Chitiet); // dgware_Hdbanhang_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
            //    txtSotien.EditValue = Convert.ToDecimal(gridView4.Columns["Thanhtien"].SummaryItem.SummaryValue);
            //}
            gridView4.BestFitColumns();
            txtSotien_Khachtra.Text = "";
            txtSotien_Thua.Text = "";
        }

        private void txtSotien_EditValueChanged(object sender, EventArgs e)
        {
            if (txtSotien.Text != "")
                txtSotien_Vat.EditValue = Convert.ToDecimal(txtSotien.EditValue) * Convert.ToDecimal(0.1) / Convert.ToDecimal(1.1);
        }

        private void txtTien_Khachtra_EditValueChanged(object sender, EventArgs e)
        {
            if (txtSotien_Khachtra.Text != "")
                txtSotien_Thua.EditValue = Convert.ToDecimal(txtSotien_Khachtra.EditValue) - Convert.ToDecimal(gridView4.Columns["Thanhtien"].SummaryItem.SummaryValue);
            else
                txtSotien_Thua.EditValue = null;
        }

        private void gridView4_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if ("" + gridView4.GetFocusedRowCellValue("Id_Hdbanhang_Chitiet") == "")
                return;
            dgware_Hdbanhang_Chitiet.DataSource = ds_Hdbanhang_Chitiet.Tables[0];
        }

        private void lookUpEdit_Cuahang_Ban_EditValueChanged(object sender, EventArgs e)
        {
            object Id_Cuahang_Ban = lookUpEdit_Cuahang_Ban.EditValue;
            if (Id_Cuahang_Ban != null)
            {
                ds_Hdbanhang = objWareService.Get_All_Ware_Hdbanhang_Novat_Hhban_Cash_ByCuahang(Id_Cuahang_Ban).ToDataSet();
                dgware_Hdbanhang.RefreshDataSource();
            }
        }

        private void Frmware_Hdbanhang_noVAT_Hhban_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.PageUp)
                txtSotien_Khachtra.Focus();
            else if (e.KeyData == Keys.PageDown)
                txtSoluong.Focus();
            else if (e.KeyData == Keys.Insert)
                txtBarcode_Txt.Focus();
        }

        private void txtBarcode_Txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBarcode_Txt.SelectAll();
                txtBarcode_Txt.Focus();
            }
        }

        private void txtMa_Khachhang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblStatus_Bar.Text = "";
                if (txtMa_Khachhang.Text != "")
                    Check_Khachhang();
                else
                    resetTheKhachHang();
            }
        }

        private void lookUpEdit_Khachhang_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (FormState == GoobizFrame.Windows.Forms.FormState.View && "" + lookUpEdit_Khachhang.EditValue != "")
                    txtMa_Khachhang.Text = "" + ((DataRowView)lookUpEdit_Khachhang.Properties.GetDataSourceRowByKeyValue(lookUpEdit_Khachhang.EditValue))["Ma_Khachhang"];
            }
            catch { txtMa_Khachhang.Text = ""; }
        }

        private void gridView4_RowCountChanged(object sender, EventArgs e)
        {
            try
            {
                this.DoClickEndEdit(dgware_Hdbanhang_Chitiet); //dgware_Hdbanhang_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                txtSotien.EditValue = Convert.ToDecimal("0" + gridView4.Columns["Thanhtien"].SummaryItem.SummaryValue) - Convert.ToDecimal("0" + ds_Hdbanhang_Chitiet.Tables[0].Compute("sum(Thanhtien_Km)", ""));
                txtSotien_Khachtra.Text = "";
                txtSotien_Thua.Text = "";
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.ToString());
            }
        }

        /// <summary>
        /// show Frmware_Dm_Loai_Hanghoa_Ban_Dialog
        /// select Id_Loai_Hanghoa_Ban
        /// filter cardView1 with Id_Loai_Hanghoa_Ban
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Ban_Dialog frmware_Dm_Loai_Hanghoa_Ban_Dialog = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Ban_Dialog();
            frmware_Dm_Loai_Hanghoa_Ban_Dialog.Text = "Loại hàng hóa";
            GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmware_Dm_Loai_Hanghoa_Ban_Dialog);
            frmware_Dm_Loai_Hanghoa_Ban_Dialog.ShowDialog();
            if (frmware_Dm_Loai_Hanghoa_Ban_Dialog.SelectedRows != null && frmware_Dm_Loai_Hanghoa_Ban_Dialog.SelectedRows.Length > 0)
            {
                object Id_Loai_Hanghoa_Ban = frmware_Dm_Loai_Hanghoa_Ban_Dialog.SelectedRows[0]["Id_Loai_Hanghoa_Ban"];
                cardView1.Columns["Id_Loai_Hanghoa_Ban"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                        cardView1.Columns["Id_Loai_Hanghoa_Ban"], Id_Loai_Hanghoa_Ban);
            }
        }

        #region xtraTabPage4


        private void repositoryItemCalcEdit1_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            cardView1.GetDataRow(cardView1.GetDataSourceRowIndex(cardView1.FocusedRowHandle)).EndEdit();
        }

        private void repositoryItemCalcEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                AddNewOrderDetail("" + cardView1.GetFocusedRowCellValue("Barcode_Txt"), cardView1.GetFocusedRowCellValue("Soluong"));
                cardView1.GetDataRow(cardView1.GetDataSourceRowIndex(cardView1.FocusedRowHandle)).RejectChanges();
            }
            else if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
                cardView1.GetDataRow(cardView1.GetDataSourceRowIndex(cardView1.FocusedRowHandle)).RejectChanges();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            cardView1.MovePrevPage();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            cardView1.MoveNextPage();
        }

        #endregion

        #region custom button

        // button tạo mới
        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtBarcode_Txt.Enabled = true;
            txtSoluong.Enabled = true;
            txtSotien_Khachtra.Enabled = true;
            PerformAdd();
            this.ClearDataBindings();
            ChangeFormState(GoobizFrame.Windows.Forms.FormState.Add);
        }

        // button bỏ qua
        private void btnCancel_Click(object sender, EventArgs e)
        {
            splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1;
            txtBarcode_Txt.Enabled = false;
            txtSotien_Khachtra.Enabled = false;
            txtSoluong.Enabled = false;
            ShowTabPage(xtraTabControl2, xtraTabPage1);
            gridView1.FocusedRowHandle = ds_Hdbanhang.Tables[0].Rows.Count;
            PerformCancel();
            ChangeFormState(GoobizFrame.Windows.Forms.FormState.Cancel);
            this.ResetText();
            this.txtSochungtu.EditValue = null;
            this.dtNgay_Chungtu.EditValue = null;
        }

        // button thanh toán
        private void btnCash_Click(object sender, EventArgs e)
        {
            lblStatus_Bar.Text = "";
            double dongia = 0;
            for (int i = 0; i < ds_Hdbanhang_Chitiet.Tables[0].Rows.Count; i++)
            {
                if (chkDongia_Bansi.Checked)
                    dongia = Convert.ToDouble("0" + ds_Hdbanhang_Chitiet.Tables[0].Rows[i]["Dongia_Bansi"]);
                else
                    dongia = Convert.ToDouble("0" + ds_Hdbanhang_Chitiet.Tables[0].Rows[i]["Dongia_Ban"]);
                if (dongia == 0)
                {
                    lblStatus_Bar.Text = "Có hàng hóa chưa có đơn giá, nhập lại";
                    return;
                }
                dongia = 0;
            }
            ChangeFormState(GoobizFrame.Windows.Forms.FormState.Add);
            thanhtien = Convert.ToDouble(gridView4.Columns["Thanhtien"].SummaryItem.SummaryValue);
            sotien_mat = txtSotien_Khachtra.EditValue;
            sotien_thua = txtSotien_Thua.EditValue;
            PerformSave();
            this.ds_Hdbanhang = objWareService.Get_All_Ware_Hdbanhang_ById_Hdbanhang(identity).ToDataSet();
            this.ds_Hdbanhang_Chitiet = objWareService.Get_All_Ware_Hdbanhang_Chitiet_By_Hdbanhang(identity).ToDataSet();
            PerformPrintPreview();
            PerformAdd();
        }

        // button đăng xuất
        private void btnLogon_Click(object sender, EventArgs e)
        {
            ChangeFormState(GoobizFrame.Windows.Forms.FormState.View);
            ShowLogonForm();
        }

        // button kết thúc
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // button tìm hàng
        private void btnChon_HH_Click(object sender, EventArgs e)
        {
            ShowTabPage(xtraTabControl2, xtraTabPage3);
            splitContainerControl1.PanelVisibility =
            (splitContainerControl1.PanelVisibility != DevExpress.XtraEditors.SplitPanelVisibility.Both)
            ? DevExpress.XtraEditors.SplitPanelVisibility.Both
            : DevExpress.XtraEditors.SplitPanelVisibility.Panel1;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            cardView2.MovePrevPage();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            cardView2.MoveNextPage();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            ShowTabPage(xtraTabControl2, xtraTabPage3);
        }

        #endregion

        #region xtraTabPage_Hdbanhang_Chitiet2
        private void repositoryItemCalcEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                cardView2.GetDataRow(cardView2.FocusedRowHandle).Delete();
            }
        }

        // button khuyến mãi
        private void btnKm_All_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow dr_change = gridView4.GetDataRow(gridView4.FocusedRowHandle);
                if (!AllowEdit_Per_Dongia)
                {
                    GoobizFrame.Windows.Forms.Policy.Authorization.Actions Actions = GoobizFrame.Windows.MdiUtils.MdiChecker.ShowIDCardLogonWithResult(this);
                    if (Actions.Count == 0)
                    {
                        if (gridView4.RowCount > 0)
                            dr_change.CancelEdit();
                        if (Actions.Id_Nhansu != null)
                            lblStatus_Bar.Text = "Nhân viên này không được phép giảm giá";
                        else
                            lblStatus_Bar.Text = "";
                    }
                    else if (Actions.Contains("EnableReduce"))
                    {
                        lblStatus_Bar.Text = "";
                        AllowEdit_Per_Dongia = true;
                        txtKm_All.Enabled = true;
                        this.gridColumn5.OptionsColumn.AllowEdit = true;
                        repositoryItemButtonEdit1.Buttons[0].Visible = true;
                        Id_Nhansu_Km = Convert.ToInt32(Actions.Id_Nhansu);
                    }
                }
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message);
            }
        }

        //button thẻ khách hàng
        private void btnKhachhang_Click(object sender, EventArgs e)
        {
            Load_Khachhang();
            txtMa_Khachhang.Enabled = true;
            txtMa_Khachhang.Text = GoobizFrame.Windows.Forms.FrmGKeyboardInput.ShowInputDialog(txtMa_Khachhang.Text);
            Check_Khachhang();
        }

        private void btnBack_Loai_Hanghoa_Ban_Click(object sender, EventArgs e)
        {
            cardView2.MovePrevPage();
        }

        private void btnNext_Loai_Hanghoa_Ban_Click(object sender, EventArgs e)
        {
            cardView2.MoveNextPage();
        }

        // button loại hàng
        private void btnLoai_Hanghoa_Ban_Click(object sender, EventArgs e)
        {
            ShowTabPage(xtraTabControl2, xtraTabPage3);
        }

        // button ds hóa đơn
        private void btnHdbanhang_Click(object sender, EventArgs e)
        {
            splitContainerControl1.PanelVisibility =
             (splitContainerControl1.PanelVisibility != DevExpress.XtraEditors.SplitPanelVisibility.Both)
             ? DevExpress.XtraEditors.SplitPanelVisibility.Both
             : DevExpress.XtraEditors.SplitPanelVisibility.Panel1;

            ShowTabPage(xtraTabControl2, xtraTabPage1);
            //Get data Ware_Hdbanhang
            ds_Hdbanhang = objWareService.Get_All_Ware_Hdbanhang_Novat_Hhban_ByCuahang(LocationId_Cuahang_Ban).ToDataSet(); //objWareService.Get_All_Ware_Hdbanhang_ByCuahang(LocationId_Cuahang_Ban);
            dgware_Hdbanhang.DataSource = ds_Hdbanhang;
            dgware_Hdbanhang.DataMember = ds_Hdbanhang.Tables[0].TableName;
            DisplayInfo2();
        }

        //button giao ca
        private void btnSplit_Click(object sender, EventArgs e)
        {
            GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowDialogOfMetaData("Ecm.Reports.dll", "Ecm.Reports.Forms.FrmRptSplit_Sum_Hhban", this.MdiParent);
        }
        #endregion

        private void txtSoluong_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            lblStatus_Bar.Text = "";
            txtSoluong.EditValue = GoobizFrame.Windows.Forms.FrmGNumboardInput.ShowInputDialog(txtSoluong.Text);
        }

        #region xử lý các text box
        private void txtBarcode_Txt_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                //if ("" +  GoobizFrame.Windows.Forms.FrmGKeyboardInput.ShowInputDialog(txtBarcode_Txt.Text) == "")
                txtBarcode_Txt.EditValue = GoobizFrame.Windows.Forms.FrmGKeyboardInput.ShowInputDialog(txtBarcode_Txt.Text);
                if (txtBarcode_Txt.Text != "")
                    AddNewOrderDetail(txtBarcode_Txt.Text, txtSoluong.EditValue);
            }
            catch (Exception ex)
            {
#if (BEGUG)
                MessageBox.Show(ex.Message);
#endif
            }
        }

        // nhap khuyen mai
        private void txtKm_All_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtKm_All.EditValue = GoobizFrame.Windows.Forms.FrmGNumboardInput.ShowInputDialog(txtKm_All.EditValue);
            Check_Km_All();
        }

        // nhap mã khách hàng
        private void txtMa_Khachhang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtMa_Khachhang.EditValue = GoobizFrame.Windows.Forms.FrmGKeyboardInput.ShowInputDialog(txtMa_Khachhang.Text);
            Check_Khachhang();
        }

        private void txtKm_All_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtKm_All.EditValue = GoobizFrame.Windows.Forms.FrmGNumboardInput.ShowInputDialog(txtKm_All.EditValue);
                Check_Km_All();
            }
        }

        private void txtSoluong_EditValueChanged(object sender, EventArgs e)
        {
            // txtSoluong.EditValue =  GoobizFrame.Windows.Forms.FrmGNumboardInput.ShowInputDialog(txtSoluong.EditValue);
            lblStatus_Bar.Text = "";
            if (txtSoluong.Text.Contains("."))
            {
                lblStatus_Bar.Text = "Số lượng chỉ được phép nhập số nguyên";
                txtSoluong.EditValue = 1;
                return;
            }
            if (txtSoluong.EditValue == null)
            {
                lblStatus_Bar.Text = "Số lượng không được để rỗng, nhập lại";
                txtSoluong.EditValue = 1;
                return;
            }
            if (txtSoluong.Text == "0")
            {
                lblStatus_Bar.Text = "Số lượng không được bằng 0";
                txtSoluong.EditValue = 1;
                return;
            }
            if (txtSoluong.Text.Contains("-"))
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Số lượng không được nhập số âm");
                object value = txtSoluong.Text.Replace("-", " ");
                txtSoluong.EditValue = value;
            }
        }

        private void txtSotien_Khachtra_EditValueChanged(object sender, EventArgs e)
        {
            if (txtSotien_Khachtra.Text != "")
            {
                try
                {
                    txtSotien_Thua.EditValue = Convert.ToDecimal(txtSotien_Khachtra.EditValue) - Convert.ToDecimal(txtSotien.EditValue);

                    if (txtSotien_Khachtra.Text == "0")
                    {
                        lblStatus_Bar.Text = "Tiền khách trả không được = 0";
                        txtSotien_Khachtra.EditValue = DBNull.Value;
                        txtSotien_Thua.EditValue = DBNull.Value;
                        return;
                    }
                    lblStatus_Bar.Text = "";
                    object tienKhachDua = txtSotien_Khachtra.EditValue;
                    if (tienKhachDua.ToString() == "" || txtSotien.EditValue == "")
                    {
                        return;
                    }
                    if (Convert.ToDouble(tienKhachDua) == 0)
                    {
                        lblStatus_Bar.Text = "Số tiền khách đưa không được bằng 0";
                        return;
                    }

                    if (Convert.ToDouble(tienKhachDua) < Convert.ToDouble(txtSotien.EditValue))
                    {
                        lblStatus_Bar.Text = "Số tiền khách đưa không được nhỏ hơn số tiền trên hóa đơn";
                        txtSotien_Thua.EditValue = null;
                        return;
                    }
                    txtSotien_Thua.EditValue = Convert.ToDouble(tienKhachDua) - Convert.ToDouble(txtSotien.EditValue);
                }
                catch
                {
                    lblStatus_Bar.Text = "Số tiền khách đưa chỉ được nhập số, nhập lại.";
                    txtSotien_Khachtra.Focus();
                    txtSotien_Khachtra.EditValue = "";
                    return;
                }
            }
            else
                txtSotien_Thua.EditValue = null;
        }

        private void txtSoluong_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSoluong.EditValue = GoobizFrame.Windows.Forms.FrmGNumboardInput.ShowInputDialog(txtSoluong.EditValue);
                if (txtSoluong.Text.Contains("."))
                {
                    lblStatus_Bar.Text = "Số lượng chỉ được phép nhập số nguyên";
                    txtSoluong.EditValue = 1;
                    return;
                }

                if (txtSoluong.EditValue == null)
                {
                    lblStatus_Bar.Text = "Số lượng không được để rỗng, nhập lại";
                    txtSoluong.EditValue = 1;
                    return;
                }
                if (txtSoluong.Text == "0")
                {
                    lblStatus_Bar.Text = "Số lượng không được bằng 0";
                    txtSoluong.EditValue = 1;
                    return;
                }
            }

        }

        /// <summary>
        /// Nhập số tiền khách trả 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSotien_Khachtra_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtSotien_Khachtra.EditValue = GoobizFrame.Windows.Forms.FrmGNumboardInput.ShowInputDialog(txtSotien_Khachtra.EditValue);
            if (txtSotien_Khachtra.Text == "0")
            {
                lblStatus_Bar.Text = "Tiền khách trả không được = 0";
                txtSotien_Khachtra.EditValue = DBNull.Value;
                txtSotien_Thua.EditValue = null;
                return;
            }
            if (txtSotien_Khachtra.Text.Contains("-"))
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Tiền khách trả không được nhập số âm");
                object value = txtSotien_Khachtra.Text.Replace("-", "");
                txtSotien_Khachtra.EditValue = value;
            }
        }
        #endregion

        #region button tren grid
        // Xóa hàng hóa trên grid
        void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //if (MessageBox.Show("Bạn có chắc muốn xóa hàng hóa này?", "Confirm Dialog", MessageBoxButtons.YesNo) == DialogResult.Yes)
            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[] { "Hàng hóa " }) == DialogResult.Yes)
            {
                ds_Hdbanhang_Chitiet.Tables[0].Rows[gridView4.FocusedRowHandle].Delete();
                dgware_Hdbanhang_Chitiet.DataSource = ds_Hdbanhang_Chitiet;
                dgware_Hdbanhang_Chitiet.DataMember = ds_Hdbanhang_Chitiet.Tables[0].TableName;
                if (gridView4.RowCount == 0)
                    btnCash.Enabled = false;
                //else
                //    Recal_Dongia();
            }
        }

        // Nhập số lượng trên grid
        void repositoryItemButtonEdit3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            object value = GoobizFrame.Windows.Forms.FrmGNumboardInput.ShowInputDialog("" + gridView4.GetFocusedRowCellValue("" + gridView4.FocusedColumn.FieldName));
            if (value.ToString().Contains("."))
            {
                lblStatus_Bar.Text = "Số lượng chỉ được phép nhập số nguyên";
                gridView4.SetFocusedRowCellValue(gridView4.FocusedColumn, 1);
                return;
            }
            if (value == null)
            {
                lblStatus_Bar.Text = "Số lượng không được để rỗng, nhập lại";
                gridView4.SetFocusedRowCellValue(gridView4.FocusedColumn, 1);
                return;
            }
            if (value.ToString() == "0")
            {
                lblStatus_Bar.Text = "Số lượng không được bằng 0";
                gridView4.SetFocusedRowCellValue(gridView4.FocusedColumn, 1);
                return;
            }
            if (value.ToString().Contains("-"))
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Số lượng không được nhập số âm");
                value = value.ToString().Replace("-", "");
            }
            if (value.ToString().Length >= 6)
            {
                //value = value.ToString().Substring(0, 5);
                GoobizFrame.Windows.Forms.MessageDialog.Show("Số lượng nhập không đúng");
                gridView4.SetFocusedRowCellValue(gridView4.Columns["Soluong"], 1);
                return;
            }
            gridView4.SetFocusedRowCellValue(gridView4.FocusedColumn, value);
            gridView4.RefreshRow(gridView4.FocusedRowHandle);
        }

        // Nhập KM trên grid
        void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            object value = GoobizFrame.Windows.Forms.FrmGNumboardInput.ShowInputDialog(
                                  "" + gridView4.GetFocusedRowCellValue("" + gridView4.FocusedColumn.FieldName)
                                  );
            if (value.ToString().Contains("."))
            {
                lblStatus_Bar.Text = "Khuyến mãi chỉ được phép nhập số";
                gridView4.SetFocusedRowCellValue(gridView4.FocusedColumn, 0);
                return;
            }
            if (value.ToString().Length > 3)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Khuyến mãi nhập không đúng");
                gridView4.SetFocusedRowCellValue(gridView4.FocusedColumn, 0);
                return;
            }
            if (Convert.ToInt32(value) < 0 || Convert.ToInt32(value) > 100)
            {
                lblStatus_Bar.Text = "Khuyến mãi chỉ được phép nhập trong khoảng từ 0 đến 100";
                gridView4.SetFocusedRowCellValue(gridView4.FocusedColumn, 0);
                return;
            }
            if (value.Equals(""))
                gridView4.SetFocusedRowCellValue(gridView4.FocusedColumn, DBNull.Value);
            else
                gridView4.SetFocusedRowCellValue(gridView4.FocusedColumn, value);
            gridView4.RefreshRow(gridView4.FocusedRowHandle);
        }
        #endregion

        /// <summary>
        /// CLick on ds loại hàng hóa --> chọn loại hàng hóa bán
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cardView2_MouseDown_1(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cardView2.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                object id_loai_Hh = cardView2.GetRowCellValue(cardHit.RowHandle, "Id_Loai_Hanghoa_Ban");
                cardView1.Columns["Id_Loai_Hanghoa_Ban"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
               "Id_Loai_Hanghoa_Ban = " + id_loai_Hh);
                ShowTabPage(xtraTabControl2, xtraTabPage4);
            }
        }

        /// <summary>
        /// Chọn hàng hóa bán
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cardView1_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cardView1.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                cardView1.FocusedRowHandle = cardHit.RowHandle;
                id_donvitinh = cardView1.GetFocusedRowCellValue(cardView1.Columns["Id_Donvitinh"]);
                AddNewOrderDetail(cardView1.GetFocusedRowCellValue("Barcode_Txt").ToString(), txtSoluong.EditValue);
            }
        }

        private void Frmware_Hdbanhang_noVAT_Hhban_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DataRow[] sdr = dsSys_Lognotify.Tables[0].Select("Table_Name='Ware_Ctrinh_Kmai'");
                if (sdr != null && sdr.Length > 0)
                    sdr[0].Delete();
                dsSys_Lognotify.AcceptChanges();
            }
            catch { }
        }

        /// <summary>
        /// in hóa đơn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PerformPrintPreview();
        }

        /// <summary>
        /// chọn hóa đơn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.DisplayInfo2();
        }

        private void chkDongia_Bansi_CheckedChanged(object sender, EventArgs e)
        {
            if (FormState == GoobizFrame.Windows.Forms.FormState.View
                        || FormState == GoobizFrame.Windows.Forms.FormState.Cancel)
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
                    dtr = ds_Hanghoa_Ban_after_Thongke.Tables[0].Select("Id_Hanghoa_Ban = " + gridView4.GetRowCellValue(i, gridView4.Columns["Id_Hanghoa_Ban"]) + "and  Id_Donvitinh = " + gridView4.GetRowCellValue(i, gridView4.Columns["Id_Donvitinh"]));

                    gridView4.SetRowCellValue(i, gridView4.Columns["Dongia_Ban"], dtr[0]["Dongia_Ban"]);
                    gridView4.SetRowCellValue(i, gridView4.Columns["Dongia_Bansi"], null);                   
                }
            }
            else
            {
                gridView4.Columns["Dongia_Bansi"].Visible = true;
                gridView4.Columns["Dongia_Ban"].Visible = false;
                bool check = false;
                for (int i = 0; i < ds_Hdbanhang_Chitiet.Tables[0].Rows.Count; )
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
                        //decimal thanhtien;
                        //if (dsCtrinh_Kmai_Chitiet != null
                        //        && dsCtrinh_Kmai_Chitiet.Tables.Count > 0
                        //        && dsCtrinh_Kmai_Chitiet.Tables[0].Rows.Count > 0)
                        //{
                        //    DataRow[] sdr = dsCtrinh_Kmai_Chitiet.Tables[0].Select("Id_Hanghoa_Ban=" + gridView4.GetRowCellValue(i, gridView4.Columns["Id_Hanghoa_Ban"])
                        //                                                        + " and Id_Donvitinh=" + gridView4.GetRowCellValue(i, gridView4.Columns["Id_Donvitinh"]));
                        //    if (sdr != null && sdr.Length > 0)
                        //    {
                        //        gridView4.SetRowCellValue(i, gridView4.Columns["Per_Dongia"], sdr[0]["Per_Dongia"]);
                        //        thanhtien = Convert.ToDecimal(gridView4.GetRowCellValue(i, gridView4.Columns["Soluong"]))
                        //                            * Convert.ToDecimal("0" + gridView4.GetRowCellValue(i, gridView4.Columns["Dongia_Bansi"]))
                        //                            * (1 - Convert.ToDecimal(sdr[0]["Per_Dongia"]) / 100);
                        //        gridView4.SetRowCellValue(i, gridView4.Columns["Thanhtien"], thanhtien);
                        //    }
                        //}
                        //else
                        //{
                        //    thanhtien = Convert.ToDecimal(gridView4.GetRowCellValue(i, gridView4.Columns["Soluong"]))
                        //                        * Convert.ToDecimal("0" + gridView4.GetRowCellValue(i, gridView4.Columns["Dongia_Bansi"]));
                        //    gridView4.SetRowCellValue(i, gridView4.Columns["Thanhtien"], thanhtien);
                        //}
                    }
                    i++;
                }
                if (check)
                {
                    if (GoobizFrame.Windows.Forms.MessageDialog.Show(" Hàng hóa chưa có đơn giá bán sỉ, xóa khỏi danh sách ", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        for (int x = 0; x < List_ItemToDelete.Count; x++)
                        {
                            object id_hanghoa_ban = List_ItemToDelete[x];
                            for (int j = 0; j < ds_Hdbanhang_Chitiet.Tables[0].Rows.Count; j++)
                            {
                                if (ds_Hdbanhang_Chitiet.Tables[0].Rows[j]["Id_Hanghoa_Ban"].Equals(id_hanghoa_ban))
                                    ds_Hdbanhang_Chitiet.Tables[0].Rows[j].Delete();
                            }
                        }
                    }
                    else
                        dgware_Hdbanhang_Chitiet.DataSource = ds_Hdbanhang_Chitiet.Tables[0];
                }
            }
        }

        // Thay đổi Đơn vị tính
        void repositoryItemButtonEdit4_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            lblStatus_Bar.Text = "";
            Ecm.Ware.Forms.Frmware_Hdbanhang_Donvitinh_Dialog frm_Donvitinh = new Frmware_Hdbanhang_Donvitinh_Dialog();
            frm_Donvitinh.setId_Hanghoa_Ban(gridView4.GetFocusedRowCellValue(gridView4.Columns["Id_Hanghoa_Ban"]));
            frm_Donvitinh.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            frm_Donvitinh.item_Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            frm_Donvitinh.ShowDialog();
            if (frm_Donvitinh.Id_Donvitinh != null)
            {
                DataSet ds_HhDinhgia_By_Id_Hanghoa = objWareService.Get_All_Ware_Hanghoa_Dinhgia_By_Id_HhBan(gridView4.GetFocusedRowCellValue("Id_Hanghoa_Ban")).ToDataSet();// get ds hh định giá by id_hanghoa_ban
                DataRow[] dtr_GiaHanghoa_By_DVT = ds_HhDinhgia_By_Id_Hanghoa.Tables[0].Select("Id_Donvitinh = " + frm_Donvitinh.Id_Donvitinh);//select hh định giá từ ds_HhDinhgia_By_Id_Hanghoa với id_DTV mới
                if (dtr_GiaHanghoa_By_DVT.Length == 0)
                {
                    lblStatus_Bar.Text = "Hàng hóa này chưa có đơn giá";
                    gridView4.CancelUpdateCurrentRow();
                    return;
                }

                DataRow[] dtr_Donvitinh = ds_Donvitinh.Tables[0].Select("Id_Donvitinh = " + frm_Donvitinh.Id_Donvitinh);
                gridView4.SetFocusedRowCellValue(gridView4.Columns["Ten_Donvitinh"], dtr_Donvitinh[0]["Ten_Donvitinh"]);
                gridView4.SetFocusedRowCellValue(gridView4.Columns["Id_Donvitinh"], dtr_Donvitinh[0]["Id_Donvitinh"]);

                if (chkDongia_Bansi.Checked)
                    gridView4.SetFocusedRowCellValue(gridView4.Columns["Dongia_Bansi"], dtr_GiaHanghoa_By_DVT[0]["Dongia_Bansi"]);
                else
                    gridView4.SetFocusedRowCellValue(gridView4.Columns["Dongia_Ban"], dtr_GiaHanghoa_By_DVT[0]["Dongia_Banle"]);

                int soluong = Convert.ToInt32(gridView4.GetFocusedRowCellValue(gridView4.Columns["Soluong"]));
                if (Get_Soluong_Ton_Quydoi(gridView4.GetFocusedRowCellValue(gridView4.Columns["Id_Hanghoa_Ban"]),
                                            gridView4.GetFocusedRowCellValue(gridView4.Columns["Id_Donvitinh"])) < soluong)
                {
                    lblStatus_Bar.Text = "Không đủ số lượng để xuất theo yêu cầu";
                    gridView4.SetFocusedRowCellValue(gridView4.Columns["Soluong"], soluong);
                    return;
                }
            }
            frm_Donvitinh.Dispose();
        }

        private void btnBack_hdbh_chitiet_Click(object sender, EventArgs e)
        {
            gridView4.MovePrevPage();
        }

        private void btnNext_hdbh_chitiet_Click(object sender, EventArgs e)
        {
            gridView4.MoveNextPage();
        }

        private void btnBack_hdbh_Click(object sender, EventArgs e)
        {
            gridView1.MovePrevPage();
        }

        private void btnNext_hdbh_Click(object sender, EventArgs e)
        {
            gridView1.MoveNextPage();
        }
        #endregion

        #region custom method

        /// <summary>
        /// ShowTabPage
        /// </summary>
        /// <param name="xtraTabControl2">xtraTabControl</param>
        /// <param name="xtraTabPage">xtraTabPage</param>
        void ShowTabPage(DevExpress.XtraTab.XtraTabControl xtraTabControl, DevExpress.XtraTab.XtraTabPage xtraTabPage)
        {
            while (xtraTabControl.TabPages.Count > 0)
                xtraTabControl.TabPages.RemoveAt(0);
            xtraTabControl.TabPages.Add(xtraTabPage);
        }

        /// <summary>
        /// Show TabPage on xtraTabControl_Main
        /// </summary>
        /// <param name="xtraTabPage"></param>
        void ShowTabPage(DevExpress.XtraTab.XtraTabPage xtraTabPage)
        {
            try
            {
                while (xtraTabControl_Main.TabPages.Count > 0)
                    xtraTabControl_Main.TabPages.RemoveAt(0);
                xtraTabControl_Main.TabPages.Add(xtraTabPage);
            }
            catch (Exception ex)
            { }
        }


        private void idCardLogonControl1_AfterLogon()
        {
            GoobizFrame.Windows.PlugIn.RightHelpers.CheckUserRightAction(this);
            ShowTabPage(xtraTabPage_Sale);
            DisplayInfo();
            btnKm_All.Enabled = EnableAdd;
            btnKhachhang.Enabled = EnableAdd;
            btnCash.Enabled = EnableAdd;
            btnSplit.Enabled = EnableQuery;
            if (EnableAdd)
            {
                ChangeFormState(GoobizFrame.Windows.Forms.FormState.Add);
                PerformAdd();
            }
            else
                ShowTabPage(xtraTabControl2, xtraTabPage1);
        }


        /// <summary>
        /// scan barode hang hoa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBarcode_Txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && "" + txtBarcode_Txt.Text != "")
                AddNewOrderDetail(txtBarcode_Txt.Text, txtSoluong.EditValue);
        }

        /// <summary>
        /// add new row into ds_Hdbanhang_Chitiet
        /// </summary>
        /// <param name="Barcode_Txt">Barcode_Txt</param>
        /// <param name="Soluong">Soluong</param>
        void AddNewOrderDetail(string Barcode_Txt, object Soluong)
        {
            lblStatus_Bar.Text = "";
            if (ds_Hdbanhang_Chitiet.Tables[0].Rows.Count == 0) //set ngay chung tu tai thoi diem chon hang hoa dau tien
                dtNgay_Chungtu.EditValue = objWareService.GetServerDateTime();
            try
            {
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
                    //if (id_donvitinh.ToString() == "")
                    id_donvitinh = sr[0]["Id_Donvitinh"];
                    //kiem tra so luong ton
                    if (Get_Soluong_Ton_Quydoi(sr[0]["Id_Hanghoa_Ban"], id_donvitinh) < Convert.ToInt32(txtSoluong.EditValue))
                    {
                        lblStatus_Bar.Text = "Không đủ số lượng để xuất theo yêu cầu";
                        return;
                    }
                    if (ds_Hdbanhang_Chitiet.Tables[0].Rows.Count == 0)
                        check = false;
                    else
                    {
                        DataRow[] sdrHdbanhang_Chitiet = ds_Hdbanhang_Chitiet.Tables[0].Select("Id_Hanghoa_Ban =" + sr[0]["Id_Hanghoa_Ban"]
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
                            nrow["Per_Dongia"] = nrow["Per_Dongia"];
                            if (!chkDongia_Bansi.Checked)
                            {
                                nrow["Thanhtien"] = Convert.ToDecimal(nrow["Soluong"]) * Convert.ToDecimal(nrow["Dongia_Ban"])
                                                            * (1 - Convert.ToDecimal("0" + nrow["Per_Dongia"]) / 100);
                                //nrow["Thanhtien_Km"] = Convert.ToDecimal(nrow["Soluong"]) * (Convert.ToDecimal(nrow["Dongia_Ban"]) * Convert.ToDecimal("0" + nrow["Per_Dongia"]) / 100);

                            }
                            else
                            {
                                nrow["Thanhtien"] = Convert.ToDecimal(nrow["Soluong"]) * Convert.ToDecimal(nrow["Dongia_Bansi"])
                                                     * (1 - Convert.ToDecimal("0" + nrow["Per_Dongia"]) / 100);
                                //nrow["Thanhtien_Km"] = Convert.ToDecimal(nrow["Soluong"]) * (Convert.ToDecimal(nrow["Dongia_Bansi"]) * Convert.ToDecimal("0" + nrow["Per_Dongia"]) / 100);
                            }
                            //xđ vị trí dòng hàng hóa đã tồn tại trên grid
                            gridView4.FocusedRowHandle = gridView4.LocateByValue(0, gridView4.Columns["Id_Hanghoa_Ban"], sr[0]["Id_Hanghoa_Ban"]);
                            check = true;
                        }
                    }
                    if (!check)
                    {
                        nrow = ds_Hdbanhang_Chitiet.Tables[0].NewRow();//gridView4.AddNewRow();
                        ds_Hdbanhang_Chitiet.Tables[0].Rows.Add(nrow);
                        nrow["Id_Hanghoa_Ban"] = sr[0]["Id_Hanghoa_Ban"];
                        nrow["Id_Hdbanhang_Chitiet"] = ++Id_Hdbanhang_Chitiet;
                        nrow["Soluong"] = Soluong;
                        if (!chkDongia_Bansi.Checked)
                        {
                            nrow["Dongia_Ban"] = sr[0]["Dongia_Ban"];
                            gridView4.Columns["Dongia_Bansi"].Visible = false;
                            gridView4.Columns["Dongia_Ban"].Visible = true;
                        }
                        else
                        {
                            if (sr[0]["Dongia_Bansi"].ToString() == "")
                            {
                                lblStatus_Bar.Text = sr[0]["Ten_Hanghoa_Ban"] + " chưa có đơn giá bán sỉ ";
                                ds_Hdbanhang_Chitiet.Tables[0].Rows[gridView4.RowCount - 1].Delete();
                                return;
                            }
                            nrow["Dongia_Bansi"] = sr[0]["Dongia_Bansi"];
                            gridView4.Columns["Dongia_Bansi"].Visible = true;
                            gridView4.Columns["Dongia_Ban"].Visible = false;
                        }
                        DataRow[] dtr_Donvitinh = ds_Donvitinh.Tables[0].Select("Id_Donvitinh = " + id_donvitinh);
                        nrow["Ten_Donvitinh"] = dtr_Donvitinh[0]["Ten_Donvitinh"];
                        nrow["Barcode_Txt"] = sr[0]["Barcode_Txt"];
                        nrow["Id_Donvitinh"] = id_donvitinh;
                        //set giam gia theo ct km
                        if (txtKm_All.Text.ToString() != "0")
                            nrow["Per_Dongia"] = txtKm_All.EditValue;
                        else
                        {
                            nrow["Per_Dongia"] = 0;
                            //if (dsCtrinh_Kmai_Chitiet != null
                            //    && dsCtrinh_Kmai_Chitiet.Tables.Count > 0
                            //    && dsCtrinh_Kmai_Chitiet.Tables[0].Rows.Count > 0)
                            //{
                            //    DataRow[] sdr = dsCtrinh_Kmai_Chitiet.Tables[0].Select("Id_Hanghoa_Ban=" + sr[0]["Id_Hanghoa_Ban"]
                            //                                                           + "and Id_Donvitinh =" + sr[0]["Id_Donvitinh"]);
                            //    if (sdr != null && sdr.Length > 0)
                            //        nrow["Per_Dongia"] = sdr[0]["Per_Dongia"];
                            //}
                        }
                        //tinh thanh tien
                        if (!chkDongia_Bansi.Checked)
                        {
                            nrow["Thanhtien"] = Convert.ToDecimal(nrow["Soluong"]) * Convert.ToDecimal(nrow["Dongia_Ban"]) * (1 - Convert.ToDecimal(nrow["Per_Dongia"]) / 100);
                            //nrow["Thanhtien_Km"] = Convert.ToDecimal(nrow["Soluong"]) * (Convert.ToDecimal(nrow["Dongia_Ban"]) * Convert.ToDecimal(nrow["Per_Dongia"]) / 100);
                        }
                        else
                        {
                            nrow["Thanhtien"] = Convert.ToDecimal(nrow["Soluong"]) * Convert.ToDecimal(nrow["Dongia_Bansi"]) * (1 - Convert.ToDecimal(nrow["Per_Dongia"]) / 100);
                            //nrow["Thanhtien_Km"] = Convert.ToDecimal(nrow["Soluong"]) * (Convert.ToDecimal(nrow["Dongia_Bansi"]) * Convert.ToDecimal(nrow["Per_Dongia"]) / 100);
                        }
                        gridView4.FocusedRowHandle = gridView4.RowCount - 1;
                    }
                    //set thanh tien
                    if (txtMa_Khachhang.EditValue.ToString() != "")
                    {
                        Cal_KhuyenMai();
                    }
                    else
                    {
                        this.DoClickEndEdit(dgware_Hdbanhang_Chitiet); // dgware_Hdbanhang_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                        txtSotien.EditValue = gridView4.Columns["Thanhtien"].SummaryItem.SummaryValue;
                    }
                    //Recal_Dongia();
                    txtBarcode_Txt.Text = "";
                    gridView4.BestFitColumns();
                    txtSoluong.EditValue = 1;
                    if (!btnCash.Enabled)
                        btnCash.Enabled = true;
                }
                else
                {
                    lblStatus_Bar.Text = "Hàng hóa này không tồn tại, vui lòng nhập lại";
                    txtBarcode_Txt.EditValue = null;
                    txtBarcode_Txt.Focus();
                }
                id_donvitinh = null;
            }
            catch (Exception ex)
            { }
        }

        public decimal Get_Soluong_Ton_Quydoi(object Id_Hanghoa_Ban, object Id_Donvitinh)
        {
            try
            {
                var _Id_Donvitinh = ds_Hanghoa_Ban_after_Thongke.Tables[0].Select(string.Format("Id_Hanghoa_Ban={0}", Id_Hanghoa_Ban))[0]["Id_Donvitinh"];
                DataSet ds_hh_nxt = Get_Soluong_Ton_Quydoi(LocationId_Cuahang_Ban, Id_Hanghoa_Ban, Id_Donvitinh);
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
                                                                current_date, Id_Cuahang_Ban, Id_Hanghoa_Ban, Id_Donvitinh)
                                                                .ToDataSet();
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                return null;
            }
        }

        void DisplayInfo2()
        {
            this.DataBindingControl();
            gridColumn35.Visible = false;
            txtMin_Quota.EditValue = "";
            if ("" + gridView1.GetFocusedRowCellValue("Id_Hdbanhang") == "")
            {
                ds_Hdbanhang_Chitiet = new DataSet();
                return;
            }
            else
            {
                identity = gridView1.GetFocusedRowCellValue("Id_Hdbanhang");
                this.ds_Hdbanhang_Chitiet = objWareService.Get_All_Ware_Hdbanhang_Chitiet_By_Hdbanhang(identity).ToDataSet();
                if (!ds_Hdbanhang_Chitiet.Tables[0].Columns.Contains("Ten_Donvitinh"))
                    ds_Hdbanhang_Chitiet.Tables[0].Columns.Add("Ten_Donvitinh", typeof(string));

                this.dgware_Hdbanhang_Chitiet.DataSource = ds_Hdbanhang_Chitiet.Tables[0];
                for (int i = 0; i < ds_Hdbanhang_Chitiet.Tables[0].Rows.Count; i++)
                {
                    DataRow[] dtr_Donvitinh = ds_Donvitinh.Tables[0].Select("Id_Donvitinh = " + ds_Hdbanhang_Chitiet.Tables[0].Rows[i]["Id_Donvitinh"]);
                    gridView4.SetRowCellValue(i, gridView4.Columns["Ten_Donvitinh"], dtr_Donvitinh[0]["Ten_Donvitinh"]);
                }
                if (ds_Hdbanhang_Chitiet.Tables[0].Rows.Count == 0)
                    return;
                if ("" + ds_Hdbanhang_Chitiet.Tables[0].Rows[0]["Dongia_Bansi"] != "")
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
            }
        }


        void Load_Khachhang()
        {
            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");
            dsSys_Lognotify = objMasterService.Get_Sys_Lognotify_SelectLastChange_OfTables(" [ware_dm_khachhang]").ToDataSet();
            dtlc_ware_dm_khachhang = GetLastChange_FrmLognotify("WARE_DM_KHACHHANG");

            if (DateTime.Compare(dtlc_ware_dm_khachhang, System.IO.File.GetLastWriteTime(xml_WARE_DM_KHACHHANG)) > 0
                || !System.IO.File.Exists(xml_WARE_DM_KHACHHANG))
            {
                ds_Khachhang = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
                ds_Khachhang.WriteXml(xml_WARE_DM_KHACHHANG, XmlWriteMode.WriteSchema);
            }
            else if (ds_Khachhang == null || ds_Khachhang.Tables.Count == 0)
            {
                ds_Khachhang = new DataSet();
                ds_Khachhang.ReadXml(xml_WARE_DM_KHACHHANG);
            }
            if (lookUpEdit_Khachhang.Properties.DataSource == null)
                lookUpEdit_Khachhang.Properties.DataSource = ds_Khachhang.Tables[0];
        }

        /// <summary>
        /// Tinh khuyen mai
        /// </summary>
        void Cal_KhuyenMai()
        {
            //foreach (DataRow dr in ds_Hdbanhang_Chitiet.Tables[0].Rows)
            //{
            //    //set giam gia theo khuyen mai
            //    if (dsCtrinh_Kmai_Chitiet != null
            //    && dsCtrinh_Kmai_Chitiet.Tables.Count > 0
            //    && dsCtrinh_Kmai_Chitiet.Tables[0].Rows.Count > 0)
            //    {
            //        DataRow[] sdr = dsCtrinh_Kmai_Chitiet.Tables[0].Select("Id_Hanghoa_Ban=" + dr["Id_Hanghoa_Ban"]
            //                                                                + "and Id_Donvitinh = " + dr["Id_Donvitinh"]);
            //        if (sdr != null && sdr.Length > 0)
            //            if (Convert.ToDecimal("0" + dr["Per_Dongia"]) < Convert.ToDecimal("0" + sdr[0]["Per_Dongia"]))
            //                dr["Per_Dongia"] = Convert.ToDecimal("0" + sdr[0]["Per_Dongia"]);
            //    }
            //    if (!chkDongia_Bansi.Checked)
            //        dr["Thanhtien"] = Convert.ToDecimal(dr["Soluong"]) * Convert.ToDecimal(dr["Dongia_Ban"]) * (1 - Convert.ToDecimal("0" + dr["Per_Dongia"]) / 100);
            //    else
            //        dr["Thanhtien"] = Convert.ToDecimal(dr["Soluong"]) * Convert.ToDecimal(dr["Dongia_Bansi"]) * (1 - Convert.ToDecimal("0" + dr["Per_Dongia"]) / 100);
            //}
        }

        void Check_Km_All()
        {
            lblStatus_Bar.Text = "";
            object value = txtKm_All.EditValue;
            if (value.ToString().Contains("."))
            {
                lblStatus_Bar.Text = "Khuyến mãi chỉ được phép nhập số";
                txtKm_All.EditValue = 0;
                return;
            }
            if (Convert.ToInt32(value) < 0 || Convert.ToInt32(value) > 100)
            {
                lblStatus_Bar.Text = "Khuyến mãi chỉ được phép nhập trong khoảng từ 0 đến 100";
                txtKm_All.EditValue = 0;
                return;
            }
            if (gridView4.RowCount > 0)
            {
                for (int i = 0; i < ds_Hdbanhang_Chitiet.Tables[0].Rows.Count; i++)
                {
                    DataRow dtr = ds_Hdbanhang_Chitiet.Tables[0].Rows[i];
                    dtr["Per_Dongia"] = txtKm_All.EditValue;
                    object thanhtien = 0;
                    //object thanhtien_Km = 0;
                    if (!chkDongia_Bansi.Checked)
                    {
                        thanhtien = Convert.ToDouble(dtr["Dongia_Ban"]) * Convert.ToDouble(dtr["Soluong"]);
                        //thanhtien_Km = Convert.ToDouble(dtr["Soluong"]) * (Convert.ToDouble(dtr["Dongia_Ban"]) * Convert.ToDouble(dtr["Per_Dongia"]) / 100);
                    }
                    else
                    {
                        thanhtien = Convert.ToDouble(dtr["Dongia_Bansi"]) * Convert.ToDouble(dtr["Soluong"]);
                        //thanhtien_Km = Convert.ToDouble(dtr["Soluong"]) * (Convert.ToDouble(dtr["Dongia_Bansi"]) * Convert.ToDouble(dtr["Per_Dongia"]) / 100);
                    }
                    dtr["Thanhtien"] = Convert.ToDouble(thanhtien) * (100 - Convert.ToDouble(dtr["Per_Dongia"])) / 100;
                    //dtr["Thanhtien_Km"] = thanhtien_Km;
                }
                txtSotien.EditValue = Convert.ToDouble("0" + gridColumn25.SummaryText);
            }
        }

        void Check_Khachhang()
        {
            lblStatus_Bar.Text = "";
            if (txtMa_Khachhang.Text != "")
            {
                try
                {
                    DataTable dt = (DataTable)lookUpEdit_Khachhang.Properties.DataSource;
                    lookUpEdit_Khachhang.EditValue = dt.Select("Ma_Khachhang = '" + txtMa_Khachhang.Text + "'")[0]["Id_Khachhang"];
                    Cal_KhuyenMai();
                }
                catch (Exception ex)
                {
                    lblStatus_Bar.Text = "Mã khách hàng không tồn tại, nhập lại";
                    txtMa_Khachhang.EditValue = null;
                    txtMa_Khachhang.Focus();
                    lookUpEdit_Khachhang.EditValue = DBNull.Value;
                }
            }
            else
            {
                resetTheKhachHang();
            }
        }

        void resetTheKhachHang()
        {
            lookUpEdit_Khachhang.EditValue = null;
            txtMin_Quota.EditValue = 0;
            txtKm_All.EditValue = 0;
            foreach (DataRow row in ds_Hdbanhang_Chitiet.Tables[0].Rows)
            {
                row["Thanhtien_Km"] = 0;
                row["Thanhtien"] = Convert.ToDecimal(row["Dongia_Ban"]) * Convert.ToDecimal(row["Soluong"]);
                row["Per_Dongia"] = 0;
                //if (dsCtrinh_Kmai_Chitiet != null
                //    && dsCtrinh_Kmai_Chitiet.Tables.Count > 0
                //    && dsCtrinh_Kmai_Chitiet.Tables[0].Rows.Count > 0)
                //{
                //    DataRow[] sdr = dsCtrinh_Kmai_Chitiet.Tables[0].Select("Id_Hanghoa_Ban=" + row["Id_Hanghoa_Ban"]
                //                                                        + "and Id_Donvitinh = " + row["Id_Donvitinh"]);
                //    if (sdr != null && sdr.Length > 0)
                //        row["Per_Dongia"] = sdr[0]["Per_Dongia"];
                //}
            }
        }
        #endregion




    }
}