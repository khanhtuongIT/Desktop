using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Hdbanhang_VAT : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        Ecm.WebReferences.Classes.ReportService objReportService = new Ecm.WebReferences.Classes.ReportService();

        DataSet ds_Hdbanhang_vat = new DataSet();
        DataSet ds_Hdbanhang_Chitiet_vat = new DataSet();
        DataSet ds_Hanghoa_Ban_after_Thongke = new DataSet();
        DataSet ds_Khachhang;
        DataSet ds_Nhansu;
        DataSet ds_Donvitinh;

        double thanhtien;
        object identity;
        object id_nhansu_current;
        object id_khuvuc;
        object id_cap;
        public DataRow[] _selectedRows;
        object Id_Khachhang = null;

        DataSet dsHeso_Chuongtrinh = new DataSet();
        int Heso_Chuongtrinh;
        //string emailFrom;
        //string password;
        //string smtpAddress;
        //int portNumber;
        //bool enableSSL;

        public Frmware_Hdbanhang_VAT()
        {
            InitializeComponent();
            xtraTabControl_Main.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            id_nhansu_current = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu();
            //DisplayInfo();
            item_Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            item_PrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            dtNgay_Chungtu_View.EditValue = objWareService.GetServerDateTime();
            #region Gán quy?n thao tác trên form
            //btnAdd.Enabled = EnableAdd;
            //item_PrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (Heso_Chuongtrinh != 1)
            {
                gridLookUpEdit_Hanghoa_Ban.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                gridLookUpEdit_Ma_Hanghoa_Ban.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            }
            else
            {
                LookupEdit_Mahang.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                LookupEdit_Tenhang.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            }
            #endregion
        }

        public Frmware_Hdbanhang_VAT(object id_khachhang)
        {
            InitializeComponent();
            xtraTabControl_Main.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            id_nhansu_current = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu();
            Id_Khachhang = id_khachhang;
            //DisplayInfo();
            item_Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            dtNgay_Chungtu_View.EditValue = objWareService.GetServerDateTime();
            #region Gán quy?n thao tác trên form
            //btnAdd.Enabled = EnableAdd;
            #endregion
        }

        void LoadMasterData()
        {
            dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_By_Nhomheso("Cach_Tinh_Gia").ToDataSet();
            //Heso_Chuongtrinh = Convert.ToInt32(dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='Cap'", "Tinh giá theo cấp"))[0]["Heso"]);
            DataSet dsCuahang = objMasterService.Ware_Dm_Cuahang_Ban_Select_Sale().ToDataSet();
            lookUpEditKhuvuc_View.Properties.DataSource = dsCuahang.Tables[0];

            DataSet ds_collection = objMasterService.Ware_Dm_Hanghoa_Vat_SelectAll().ToDataSet();
            LookupEdit_Tenhang.DataSource = ds_collection.Tables[0];
            LookupEdit_Mahang.DataSource = ds_collection.Tables[0];

            //ds_collection = objMasterService.GetRole_System_Name_ById_User(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUserId()).ToDataSet();
            //if (ds_collection.Tables[0].Rows.Count > 0 &&
            //    "" + ds_collection.Tables[0].Rows[0]["Role_System_Name"] == "Administrators")
            //{
            //    DataSet dsCuahang = objMasterService.Ware_Dm_Cuahang_Ban_Select_Sale().ToDataSet();
            //    DataRow row = dsCuahang.Tables[0].NewRow();
            //    row["Id_Cuahang_Ban"] = -1;
            //    row["Ma_Cuahang_Ban"] = "All";
            //    row["Ten_Cuahang_Ban"] = "Tất cả";
            //    dsCuahang.Tables[0].Rows.Add(row);
            //    lookUpEditKhuvuc_View.Properties.DataSource = dsCuahang.Tables[0];
            //    lookUpEditKhuvuc_View.EditValue = Convert.ToInt64(-1);
            //}
            //else
            //{
            //    DataSet dsCuahang = objWareService.Get_Ware_Ql_Cuahang_Ban_By_Id_Nhansu(id_nhansu_current, false).ToDataSet();
            //    lookUpEditKhuvuc_View.Properties.DataSource = dsCuahang.Tables[0];
            //}
            ds_Nhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
            ds_Donvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
            ds_Khachhang = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
            lookUpEdit_Nhansu_Banhang.Properties.DataSource = ds_Nhansu.Tables[0];
            LookupEdit_DVT.DataSource = ds_Donvitinh.Tables[0];
            lookupEdit_MaKhachhang.Properties.DataSource = ds_Khachhang.Tables[0];

            //if (Heso_Chuongtrinh == 1)
            //{
            //    xtraTabPage1.PageVisible = false;
            //    DataSet ds_collection = objMasterService.Ware_Dm_Hanghoa_Vat_SelectAll().ToDataSet();

            //    LookupEdit_Tenhang.DataSource = ds_collection.Tables[0];
            //    LookupEdit_Mahang.DataSource = ds_collection.Tables[0];

            //    //ds_collection = objMasterService.GetRole_System_Name_ById_User(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUserId()).ToDataSet();
            //    //if (ds_collection.Tables[0].Rows.Count > 0 &&
            //    //    "" + ds_collection.Tables[0].Rows[0]["Role_System_Name"] == "Administrators")
            //    //{
            //    //    DataSet dsCuahang = objMasterService.Ware_Dm_Cuahang_Ban_Select_Sale().ToDataSet();
            //    //    DataRow row = dsCuahang.Tables[0].NewRow();
            //    //    row["Id_Cuahang_Ban"] = -1;
            //    //    row["Ma_Cuahang_Ban"] = "All";
            //    //    row["Ten_Cuahang_Ban"] = "Tất cả";
            //    //    dsCuahang.Tables[0].Rows.Add(row);
            //    //    lookUpEditKhuvuc_View.Properties.DataSource = dsCuahang.Tables[0];
            //    //    lookUpEditKhuvuc_View.EditValue = Convert.ToInt64(-1);
            //    //}
            //    //else
            //    //{
            //    //    DataSet dsCuahang = objWareService.Get_Ware_Ql_Cuahang_Ban_By_Id_Nhansu(id_nhansu_current, false).ToDataSet();
            //    //    lookUpEditKhuvuc_View.Properties.DataSource = dsCuahang.Tables[0];
            //    //}
            //    ds_Nhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
            //    ds_Donvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
            //    ds_Khachhang = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
            //    lookUpEdit_Nhansu_Banhang.Properties.DataSource = ds_Nhansu.Tables[0];
            //    LookupEdit_DVT.DataSource = ds_Donvitinh.Tables[0];
            //    lookupEdit_MaKhachhang.Properties.DataSource = ds_Khachhang.Tables[0];
            //}
            //else
            //{
            //    xtraTabPage2.PageVisible = false;
            //    DataSet ds_collection = objMasterService.Ware_Dm_Hanghoa_Vat_SelectAll().ToDataSet();
            //    gridLookUpEdit_Hanghoa_Ban.DataSource = ds_collection.Tables[0];
            //    gridLookUpEdit_Ma_Hanghoa_Ban.DataSource = ds_collection.Tables[0];

            //    //ds_collection = objMasterService.GetRole_System_Name_ById_User(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUserId()).ToDataSet();
            //    //if (ds_collection.Tables[0].Rows.Count > 0 &&
            //    //    "" + ds_collection.Tables[0].Rows[0]["Role_System_Name"] == "Administrators")
            //    //{
            //    //    DataSet dsCuahang = objMasterService.Ware_Dm_Cuahang_Ban_Select_Sale().ToDataSet();
            //    //    DataRow row = dsCuahang.Tables[0].NewRow();
            //    //    row["Id_Cuahang_Ban"] = -1;
            //    //    row["Ma_Cuahang_Ban"] = "All";
            //    //    row["Ten_Cuahang_Ban"] = "Tất cả";
            //    //    dsCuahang.Tables[0].Rows.Add(row);
            //    //    lookUpEditKhuvuc_View.Properties.DataSource = dsCuahang.Tables[0];
            //    //    lookUpEditKhuvuc_View.EditValue = Convert.ToInt64(-1);
            //    //}
            //    //else
            //    //{
            //    //    DataSet dsCuahang = objWareService.Get_Ware_Ql_Cuahang_Ban_By_Id_Nhansu(id_nhansu_current, false).ToDataSet();
            //    //    lookUpEditKhuvuc_View.Properties.DataSource = dsCuahang.Tables[0];
            //    //}
            //    ds_Nhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
            //    ds_Donvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
            //    ds_Khachhang = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
            //    lookUpEdit_Nhansu_Banhang.Properties.DataSource = ds_Nhansu.Tables[0];
            //    gridLookupEdit_Donvitinh.DataSource = ds_Donvitinh.Tables[0];
            //    lookupEdit_MaKhachhang.Properties.DataSource = ds_Khachhang.Tables[0];
            //}
        }

        void Load_Gridview()
        {
            //var id_cuahang = (Convert.ToInt64(lookUpEditKhuvuc_View.GetColumnValue("Id_Cuahang_Ban")) == -1) ? null : lookUpEditKhuvuc_View.GetColumnValue("Id_Cuahang_Ban");
            DataSet ds_collection = objMasterService.GetRole_System_Name_ById_User(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUserId()).ToDataSet();
            if (ds_collection.Tables[0].Rows.Count > 0 &&
                "" + ds_collection.Tables[0].Rows[0]["Role_System_Name"] == "Administrators")
                ds_Hdbanhang_vat = objWareService.Ware_Hdbanhang_Vat_SelectAll_Hhban(lookUpEditKhuvuc_View.GetColumnValue("Id_Cuahang_Ban"), dtNgay_Chungtu_View.EditValue, -1, lookUpEdit_MaKH_View.EditValue).ToDataSet();
            else
                ds_Hdbanhang_vat = objWareService.Ware_Hdbanhang_Vat_SelectAll_Hhban(lookUpEditKhuvuc_View.GetColumnValue("Id_Cuahang_Ban"), dtNgay_Chungtu_View.EditValue, id_nhansu_current, lookUpEdit_MaKH_View.EditValue).ToDataSet();

            dgware_Hdbanhang.DataSource = ds_Hdbanhang_vat;
            dgware_Hdbanhang.DataMember = ds_Hdbanhang_vat.Tables[0].TableName;
            ClearDataBindings();
            DisplayInfo_Details();
            gvHoadon.SetRowExpanded(-1, true);
        }

        #region Event Override

        public override void DisplayInfo()
        {
            //Set l?i tr?ng thái form là view
            FormState = GoobizFrame.Windows.Forms.FormState.View;
            try
            {
                this.lookUpEditKhuvuc_View.DataBindings.Clear();
                ResetText();
                LoadMasterData();
                Load_Gridview();
                this.ChangeStatus(false);
                //  btnSend.Enabled = false;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
            }
        }

        public override void ClearDataBindings()
        {
            this.txtId_Hdbanhang.DataBindings.Clear();
            this.txtSochungtu.DataBindings.Clear();
            txtGTGT.DataBindings.Clear();
            this.dtNgay_Chungtu.DataBindings.Clear();
            this.lookUpEdit_Nhansu_Banhang.DataBindings.Clear();
            lookupEdit_MaKhachhang.DataBindings.Clear();
            dtNgay_Xuat.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                this.txtId_Hdbanhang.DataBindings.Add("EditValue", ds_Hdbanhang_vat, ds_Hdbanhang_vat.Tables[0].TableName + ".Id_Hdbanhang");
                this.txtSochungtu.DataBindings.Add("EditValue", ds_Hdbanhang_vat, ds_Hdbanhang_vat.Tables[0].TableName + ".Sochungtu");
                txtGTGT.DataBindings.Add("EditValue", ds_Hdbanhang_vat, ds_Hdbanhang_vat.Tables[0].TableName + ".Per_Vat");
                this.dtNgay_Chungtu.DataBindings.Add("EditValue", ds_Hdbanhang_vat, ds_Hdbanhang_vat.Tables[0].TableName + ".Ngay_Chungtu");
                dtNgay_Xuat.DataBindings.Add("EditValue", ds_Hdbanhang_vat, ds_Hdbanhang_vat.Tables[0].TableName + ".Ngay_Xuat");
                this.lookUpEdit_Nhansu_Banhang.DataBindings.Add("EditValue", ds_Hdbanhang_vat, ds_Hdbanhang_vat.Tables[0].TableName + ".Id_Nhansu_Bh");
                lookupEdit_MaKhachhang.DataBindings.Add("EditValue", ds_Hdbanhang_vat, ds_Hdbanhang_vat.Tables[0].TableName + ".Id_Khachhang");
                //txtGhichu.DataBindings.Add("EditValue", ds_Hdbanhang_vat, ds_Hdbanhang_vat.Tables[0].TableName + ".Ghichu");
                // dtNgaygiao.DataBindings.Add("EditValue", ds_Hdbanhang_vat, ds_Hdbanhang_vat.Tables[0].TableName + ".Ngay_Thanhtoan");
                //dtNgay_Thutien.DataBindings.Add("EditValue", ds_Hdbanhang_vat, ds_Hdbanhang_vat.Tables[0].TableName + ".Ngay_Thutien");
                // txtLydo.DataBindings.Add("EditValue", ds_Hdbanhang_vat, ds_Hdbanhang_vat.Tables[0].TableName + ".Ghichu_Edit");
                //chkDinhluong.DataBindings.Add("EditValue", ds_Hdbanhang_vat, ds_Hdbanhang_vat.Tables[0].TableName + ".Tinh_Dinhluong");
                // txtHotro.DataBindings.Add("EditValue", ds_Hdbanhang_vat, ds_Hdbanhang_vat.Tables[0].TableName + ".Chiphi_Vanchuyen");
                //  txtCongno.DataBindings.Add("EditValue", ds_Hdbanhang_vat, ds_Hdbanhang_vat.Tables[0].TableName + ".Sotien_Congno");
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
            //this.dgware_Hdbanhang.Enabled = !editTable;
            //if (Heso_Chuongtrinh != 1)
            //{
            //    gvHdbang_Chitiet.OptionsBehavior.Editable = editTable;
            //}
            //else
            //{
            //    gridView2.OptionsBehavior.Editable = editTable;
            //}
            gvHdbang_Chitiet.OptionsBehavior.Editable = editTable;
            //alway lock
            //this.txtId_Hdbanhang.Properties.ReadOnly = true;
            //this.txtSotien.Properties.ReadOnly = true;
            lookupEdit_MaKhachhang.Properties.ReadOnly = !editTable;
            txtGTGT.Properties.ReadOnly = !editTable;
            dtNgay_Xuat.Properties.ReadOnly = !editTable;
            splitContainerControl1.Panel1.Enabled = !editTable;
            //txtGhichu.Properties.ReadOnly = !editTable;
            //chkDinhluong.Properties.ReadOnly = !editTable;
            // txtHotro.Properties.ReadOnly = !editTable;
            // dtNgaygiao.Properties.ReadOnly = !editTable;
            //  dtNgay_Thutien.Properties.ReadOnly = !editTable;
        }

        public override void ResetText()
        {
            this.txtId_Hdbanhang.EditValue = null;
            txtGTGT.EditValue = null;
            lookupEdit_MaKhachhang.EditValue = null;
            lookUpEdit_Nhansu_Banhang.EditValue = null;
            dtNgay_Chungtu.EditValue = null;
            txtSochungtu.EditValue = null;
            dtNgay_Xuat.EditValue = null;
            //  dtNgaygiao.EditValue = null;
            // dtNgay_Thutien.EditValue = null;
            //  txtGhichu.EditValue = null;
            //  txtLydo.EditValue = null;
            //chkDinhluong.EditValue = null;
            // txtHotro.EditValue = null;
            this.ds_Hdbanhang_Chitiet_vat = objWareService.Get_All_Ware_Hdbanhang_Chitiet_By_Hdbanhang(-1).ToDataSet();
            this.dgware_hdbanhang_chitiet_capgia.DataSource = ds_Hdbanhang_Chitiet_vat.Tables[0];
        }

        public object InsertObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Hdbanhang_Vat objWare_Hdbanhang_vat = new Ecm.WebReferences.WareService.Ware_Hdbanhang_Vat();
                objWare_Hdbanhang_vat.Id_Hdbanhang = -1;
                txtSochungtu.EditValue = objWareService.Getnew_Sohoadon_VAT(
                ((DataRowView)lookUpEditKhuvuc_View.Properties.GetDataSourceRowByKeyValue(lookUpEditKhuvuc_View.EditValue))["Ma_Cuahang_Ban"]);
                objWare_Hdbanhang_vat.Sochungtu = txtSochungtu.EditValue;
                // objWare_Hdbanhang_vat.Sotien = Convert.ToDecimal("0" + txtSotien.EditValue);
                objWare_Hdbanhang_vat.Sotien_Vat = 0;
                objWare_Hdbanhang_vat.Per_Vat = txtGTGT.EditValue;
                objWare_Hdbanhang_vat.Ngay_Chungtu = dtNgay_Chungtu.EditValue;
                //  objWare_Hdbanhang_vat.Ngay_Thanhtoan = dtNgaygiao.EditValue; // dùng ngày thanh toán làm ngày giao hàng
                // objWare_Hdbanhang_vat.Ngay_Thutien = dtNgay_Thutien.EditValue;
                objWare_Hdbanhang_vat.NoVAT = true;
                // objWare_Hdbanhang_vat.Sotien_Congno = Convert.ToDecimal("0" + txtCongno.EditValue);
                if ("" + lookUpEditKhuvuc_View.EditValue != "")
                    objWare_Hdbanhang_vat.Id_Cuahang_Ban = lookUpEditKhuvuc_View.EditValue;

                if ("" + lookUpEdit_Nhansu_Banhang.EditValue != "")
                    objWare_Hdbanhang_vat.Id_Nhansu_Bh = lookUpEdit_Nhansu_Banhang.EditValue;

                objWare_Hdbanhang_vat.Id_Khachang = ("" + lookupEdit_MaKhachhang.EditValue != "") ? lookupEdit_MaKhachhang.EditValue : -1;
                //objWare_Hdbanhang_vat.Ghichu = "" + txtGhichu.EditValue;
                // objWare_Hdbanhang_vat.Tinh_Dinhluong = ("" + chkDinhluong.EditValue == "") ? null : chkDinhluong.EditValue;
                // if (Convert.ToDecimal("0" + txtHotro.EditValue) > 0)
                //   objWare_Hdbanhang_vat.Tinh_Chiphi = true;
                //else
                objWare_Hdbanhang_vat.Tinh_Chiphi = false;
                objWare_Hdbanhang_vat.Ngay_Xuat = dtNgay_Xuat.EditValue;
                identity = objWareService.Insert_Ware_Hdbanhang_Vat(objWare_Hdbanhang_vat);
                if (identity != null)
                {
                    //    if (Heso_Chuongtrinh != 1)
                    //    {
                    dgware_Hdbanhang_Chitiet.EmbeddedNavigator.Buttons.DoClick(dgware_Hdbanhang_Chitiet.EmbeddedNavigator.Buttons.EndEdit);
                    foreach (DataRow dr in ds_Hdbanhang_Chitiet_vat.Tables[0].Rows)
                    {
                        if (dr.RowState != DataRowState.Deleted)
                            dr["Id_Hdbanhang"] = identity;
                    }
                    //update hdmuahang_chitiet
                    objWareService.Update_Ware_Hdbanhang_Chitiet_Vat_Collection(ds_Hdbanhang_Chitiet_vat);
                    //    }
                    //    else
                    //    {
                    //        dgware_hdbanhang_chitiet_capgia.EmbeddedNavigator.Buttons.DoClick(dgware_hdbanhang_chitiet_capgia.EmbeddedNavigator.Buttons.EndEdit);
                    //        foreach (DataRow dr in ds_Hdbanhang_Chitiet_Cap.Tables[0].Rows)
                    //        {
                    //            if (dr.RowState != DataRowState.Deleted)
                    //                dr["Id_Hdbanhang"] = identity;
                    //        }
                    //        //update hdmuahang_chitiet
                    //    }
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
                Ecm.WebReferences.WareService.Ware_Hdbanhang_Vat objWare_Hdbanhang_vat = new Ecm.WebReferences.WareService.Ware_Hdbanhang_Vat();
                objWare_Hdbanhang_vat.Id_Hdbanhang = identity;
                objWare_Hdbanhang_vat.Congno = false;
                objWare_Hdbanhang_vat.Sochungtu = txtSochungtu.EditValue;
                // objWare_Hdbanhang_vat.Sotien = txtSotien.EditValue;
                objWare_Hdbanhang_vat.Per_Vat = txtGTGT.EditValue;
                objWare_Hdbanhang_vat.Sotien_Vat = 0;
                objWare_Hdbanhang_vat.Ngay_Chungtu = dtNgay_Chungtu.EditValue;
                objWare_Hdbanhang_vat.Hoten_Nguoimua = "";
                objWare_Hdbanhang_vat.Phuongthuc_Thanhtoan = "TM";
                objWare_Hdbanhang_vat.So_Seri = "N/A";
                //  objWare_Hdbanhang_vat.Ngay_Thanhtoan = dtNgaygiao.EditValue; // dùng ngày thanh toán làm ngày giao hàng
                // objWare_Hdbanhang_vat.Ngay_Thutien = dtNgay_Thutien.EditValue;
                objWare_Hdbanhang_vat.Id_Khachang = lookupEdit_MaKhachhang.EditValue;
                objWare_Hdbanhang_vat.NoVAT = true;
                objWare_Hdbanhang_vat.Ngay_Xuat = dtNgay_Xuat.EditValue;
                if ("" + lookUpEditKhuvuc_View.EditValue != "")
                    objWare_Hdbanhang_vat.Id_Cuahang_Ban = lookUpEditKhuvuc_View.EditValue;

                if ("" + lookUpEdit_Nhansu_Banhang.EditValue != "")
                    objWare_Hdbanhang_vat.Id_Nhansu_Bh = lookUpEdit_Nhansu_Banhang.EditValue;

                objWare_Hdbanhang_vat.Id_Khachang = ("" + lookupEdit_MaKhachhang.EditValue != "") ? lookupEdit_MaKhachhang.EditValue : -1;
                // objWare_Hdbanhang_vat.Ghichu = "" + txtGhichu.EditValue;
                objWare_Hdbanhang_vat.Doc_Process_Status = 0;
                // objWare_Hdbanhang_vat.Tinh_Dinhluong = ("" + chkDinhluong.EditValue == "") ? null : chkDinhluong.EditValue;
                //  if (Convert.ToDecimal("0" + txtHotro.EditValue) > 0)
                //    objWare_Hdbanhang_vat.Tinh_Chiphi = true;
                // else
                objWare_Hdbanhang_vat.Tinh_Chiphi = false;
                //  objWare_Hdbanhang_vat.Chiphi_Vanchuyen = Convert.ToDecimal("0" + txtHotro.EditValue);
                //update donmuahang
                objWareService.Update_Ware_Hdbanhang_Vat(objWare_Hdbanhang_vat);

                //update donmuahang_chitiet
                this.DoClickEndEdit(dgware_Hdbanhang_Chitiet);
                foreach (DataRow dr in ds_Hdbanhang_Chitiet_vat.Tables[0].Rows)
                {
                    if (dr.RowState == DataRowState.Added)
                        dr["Id_Hdbanhang"] = identity;
                }
                objWareService.Update_Ware_Hdbanhang_Chitiet_Vat_Collection(ds_Hdbanhang_Chitiet_vat);
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
            Ecm.WebReferences.WareService.Ware_Hdbanhang_Vat objWare_Hdbanhang_vat = new Ecm.WebReferences.WareService.Ware_Hdbanhang_Vat();
            objWare_Hdbanhang_vat.Id_Hdbanhang = identity;
            return objWareService.Delete_Ware_Hdbanhang_Vat(objWare_Hdbanhang_vat);
        }

        public override bool PerformAdd()
        {
            if (lookUpEditKhuvuc_View.EditValue == null || Convert.ToInt64(lookUpEditKhuvuc_View.EditValue) == -1)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn khu vực, vui lòng chọn lại!");
                lookUpEditKhuvuc_View.Focus();
                return false;
            }
            //this.gridColumn31.Visible = false;
            if (Heso_Chuongtrinh != 1)
            {

                gridColumn35.Visible = true;
                //repositoryItemButtonEdit1.Buttons[0].Visible = false;
            }
            else
            {
                gridColumn29.Visible = true;
                //repositoryItemButtonEdit2.Buttons[0].Visible = false;
            }
            //this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.ResetText();
            lookUpEditKhuvuc_View.EditValue = Convert.ToInt64(lookUpEditKhuvuc_View.EditValue);
            lookUpEdit_Nhansu_Banhang.EditValue = Convert.ToInt64(id_nhansu_current);
            //ds_Khachhang = objMasterService.Ware_Dm_Khachhang_SelectBy_Khuvuc_Id_Nhansu(lookUpEditKhuvuc_View.EditValue, id_nhansu_current).ToDataSet();
            //lookupEdit_MaKhachhang.Properties.DataSource = ds_Khachhang.Tables[0];
            //DataSet ds_Cuahang_Ban_ByNhansu = objMasterService.Get_All_Ware_Dm_Cuahang_Ban_By_Id_Nhansu(id_nhansu_current).ToDataSet();
            //DataRow dtr = null;
            //bool check = false;
            //if (ds_Cuahang_Ban_ByNhansu.Tables[0].Rows.Count == 0)
            //    check = true;
            //else
            //{
            //    for (int i = 0; i < ds_Cuahang_Ban_ByNhansu.Tables[0].Rows.Count; i++)
            //    {
            //        dtr = ds_Cuahang_Ban_ByNhansu.Tables[0].Rows[i];
            //        //if (!dtr["Ten_Cuahang_Ban"].Equals(lookUpEditKhuvuc_View.Text))
            //        //    check = true;
            //        //else
            //        //{
            //        //    check = false;
            //        //    break;
            //        //}
            //    }
            //}
            //if (check)
            //{
            //GoobizFrame.Windows.Forms.MessageDialog.Show("B?n không có quy?n thao tác trên c?a hàng " + lookUpEditKhuvuc_View.Text + "\n vui lòng h?y thao tác");
            //lookUpEdit_Nhansu_Banhang.EditValue = null;
            //btnCancel.Enabled = false;
            //btnLogon.Enabled = true;
            //btnClose.Enabled = true;
            //return false;
            //}
            this.ChangeStatus(true);
            dtNgay_Chungtu.EditValue = objWareService.GetServerDateTime();
            //txtSochungtu.EditValue = objWareService.Getnew_Sohoadon_VAT(((DataRowView)lookUpEditKhuvuc_View.Properties.GetDataSourceRowByKeyValue(lookUpEditKhuvuc_View.EditValue))["Ma_Cuahang_Ban"]);

            //btnSend.Enabled = false;
            ds_Hanghoa_Ban_after_Thongke = objWareService.Get_All_Ware_Dm_Hanghoa_Ban_Dinhgia_After_Thongke(-1).ToDataSet();

            ds_Hdbanhang_Chitiet_vat = objWareService.Ware_Hdbanhang_Chitiet_Vat_SelectById_Hdbanhang_Vat(-1).ToDataSet();
            dgware_hdbanhang_chitiet_capgia.DataSource = ds_Hdbanhang_Chitiet_vat.Tables[0];
            gridView2.AddNewRow();

            dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_By_Nhomheso("Thue_GTGT").ToDataSet();
            txtGTGT.EditValue = dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='Thue_GTGT'"))[0]["Heso"];
            return true;
        }

        public override bool PerformEdit()
        {
            //if (lookUpEditKhuvuc_View.EditValue == null)
            //{
            //    GoobizFrame.Windows.Forms.MessageDialog.Show("Chua ch?n Khu v?c, vui lòng ch?n l?i");
            //    return false;
            //}
            if (gvHoadon.GetFocusedRowCellValue("Id_Hdbanhang") == null)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn đơn hàng, vui lòng chọn lại");
                return false;
            }
            //if (Convert.ToInt64(gvHoadon.GetFocusedRowCellValue("Doc_Process_Status")) > 0)
            //{
            //    GoobizFrame.Windows.Forms.MessageDialog.Show("Ðon hàng dã du?c g?i di ho?c dã duy?t, không th? xóa");
            //    return false;
            //}
            //if (!id_nhansu_current.Equals("" + lookUpEdit_Nhansu_Banhang.EditValue))
            //{
            //    GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
            //    return false;
            //}
            this.ChangeStatus(true);
            //btnSend.Enabled = false;
            if (Heso_Chuongtrinh != 1)
            {
                gridColumn35.Visible = true;
                this.lookUpEditKhuvuc_View.DataBindings.Clear();
                this.lookUpEditKhuvuc_View.DataBindings.Add("EditValue", ds_Hdbanhang_vat, ds_Hdbanhang_vat.Tables[0].TableName + ".Id_Cuahang_Ban");
                ds_Hanghoa_Ban_after_Thongke = objWareService.Get_All_Ware_Dm_Hanghoa_Ban_Dinhgia_After_Thongke(lookUpEditKhuvuc_View.EditValue).ToDataSet();
            }
            else
            {
                gridColumn29.Visible = true;
                this.lookUpEditKhuvuc_View.DataBindings.Clear();
                this.lookUpEditKhuvuc_View.DataBindings.Add("EditValue", ds_Hdbanhang_vat, ds_Hdbanhang_vat.Tables[0].TableName + ".Id_Cuahang_Ban");
                ds_Hanghoa_Ban_after_Thongke = objWareService.Get_All_Ware_Dm_Hanghoa_Ban_Dinhgia_After_Thongke(lookUpEditKhuvuc_View.EditValue).ToDataSet();
            }

            return true;
        }

        public override bool PerformCancel()
        {
            //this.gridColumn31.Visible = true;
            this.DisplayInfo();
            return true;
        }

        public override object PerformSelectOneObject()
        {
            DoClickEndEdit(dgware_Hdbanhang_Chitiet);
            if (MdiParent != null) return null;
            try
            {
                if (ds_Hdbanhang_Chitiet_vat == null || ds_Hdbanhang_Chitiet_vat.Tables.Count == 0) return false;

                _selectedRows = ds_Hdbanhang_Chitiet_vat.Tables[0].Select("Chon=true");
                if (_selectedRows == null || _selectedRows.Length == 0)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] { this.gridColumn21.Caption });
                    return false;
                }
                Dispose();
                return _selectedRows;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("Msg00130", new string[] { ex.Message });
            }

            return base.PerformSelectOneObject();

        }

        public override bool PerformSave()
        {
            try
            {
                bool success = false;
                System.Collections.Hashtable htbControl1 = new System.Collections.Hashtable();
                htbControl1.Add(dtNgay_Xuat, lblNgayXuat.Text);
                // htbControl1.Add(dtNgaygiao, lblNgaygiao.Text);
                // htbControl1.Add(dtNgay_Thutien, lblNgaythu.Text);
                htbControl1.Add(lookupEdit_MaKhachhang, labelControl3.Text);

                if (!Convert.ToBoolean(objWareService.Ware_Hdbanhang_Vat_Check_Ngayxuat(dtNgay_Xuat.EditValue))) // không cho phép tạo ngày xuất
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Ngày xuất không được nhỏ hơn phiếu đã tạo!");
                    dtNgay_Xuat.EditValue = null;
                }

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
                    //if ("" + lookupEdit_MaKhachhang.EditValue != "") //Update Min quota
                    //    objWareService.Update_Ware_Khachhang_Min_Quota(lookupEdit_MaKhachhang.EditValue, dtNgay_Chungtu.EditValue);
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
            //if (lookUpEditKhuvuc_View.EditValue == null)
            //{
            //    GoobizFrame.Windows.Forms.MessageDialog.Show("Chua ch?n Khu v?c, vui lòng ch?n l?i");
            //    return false;
            //}
            if (gvHoadon.GetFocusedRowCellValue("Id_Hdbanhang") == null)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn đơn hàng, vui lòng chọn lại");
                return false;
            }
            //if (Convert.ToInt64(gvHoadon.GetFocusedRowCellValue("Doc_Process_Status")) > 0)
            //{
            //    GoobizFrame.Windows.Forms.MessageDialog.Show("Ðon hàng đã được gửi đi hoặc được duyệt, không thể xóa");
            //    return false;
            //}
            //if (GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUser().ToUpper() != "ADMIN")
            //    if (!id_nhansu_current.Equals("" + lookUpEdit_Nhansu_Banhang.EditValue))
            //    {
            //        GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
            //        return false;
            //    }
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
            if (lookUpEditKhuvuc_View.EditValue == null)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chua chọn khu vực, vui lòng chọn lại");
                return false;
            }
            if (identity == null)
                return false;
            try
            {
                DataRow[] sdr = ds_Hdbanhang_vat.Tables[0].Select("Id_Hdbanhang = " + identity);
                DataSets.dsPhieuxuat_Giatri_Giatang dsrHdbanhang_VAT = new DataSets.dsPhieuxuat_Giatri_Giatang();
                Reports.rptPhieuxuat_Gtgt rptHdbanhang_VAT_gtgt = new Ecm.Ware.Reports.rptPhieuxuat_Gtgt();
                GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
                frmPrintPreview.Report = rptHdbanhang_VAT_gtgt;
                //frmPrintPreview.Name = this.Name;
                //frmPrintPreview.EnablePrintPreview = this.EnablePrintPreview;
                rptHdbanhang_VAT_gtgt.DataSource = dsrHdbanhang_VAT;
                int i = 1;
                foreach (DataRow dr in ds_Hdbanhang_Chitiet_vat.Tables[0].Rows)
                {
                    DataRow drnew = dsrHdbanhang_VAT.Tables[0].NewRow();
                    //foreach (DataColumn dc in ds_Hdbanhang_Chitiet_vat.Tables[0].Columns)
                    //{
                    //    try
                    //    {
                    //        drnew[dc.ColumnName] = dr[dc.ColumnName];
                    //    }
                    //    catch
                    //    {
                    //        continue;
                    //    }
                    //}
                    drnew["Ten_Hanghoa_Ban"] = dr["Ten_Hanghoa_Ban"];
                    drnew["Soluong"] = dr["Soluong"];
                    drnew["Thanhtien"] = dr["Thanhtien_Print"];
                    drnew["Ten_Donvitinh"] = dr["Ten_Donvitinh"];
                    drnew["Dongia_Ban"] = dr["Dongia_Ban_Print"];
                    //drnew["Ma_Hanghoa"] = dr["Ma_Hanghoa_Ban"];
                    drnew["Stt"] = i++;
                    dsrHdbanhang_VAT.Tables[0].Rows.Add(drnew);
                }
                //add parameter values
                // rptHdbanhang_VAT_gtgt.xrLbl_Tieude.Text = "HÓA ÐON KHÁCH HÀNG";
                // rptHdbanhang_VAT_gtgt.tbc_Ngay.Text = "" + string.Format("{0:dd/MM/yyyy hh:mm:ss tt}", sdr[0]["Ngay_Chungtu"]);
                lookUpEdit_Nhansu_Banhang.EditValue = sdr[0]["Id_Nhansu_Bh"];
                //rptHdbanhang_VAT_gtgt.lblNhansu_Bill.Text = lookUpEdit_Nhansu_Banhang.Text;
                DataRow[] sdrKhachhang = null;
                if (Convert.ToInt32(sdr[0]["Id_Khachhang"]) != -1)
                {
                    sdrKhachhang = ds_Khachhang.Tables[0].Select("Id_Khachhang=" + sdr[0]["Id_Khachhang"]);
                    rptHdbanhang_VAT_gtgt.xrTableCell_TenDonvi.Text = "" +
                       ((sdrKhachhang != null && sdrKhachhang.Length > 0) ? sdrKhachhang[0]["Ten_Khachhang"] : "");
                    rptHdbanhang_VAT_gtgt.xrTableCell_Diachi.Text = "" +
                       ((sdrKhachhang != null && sdrKhachhang.Length > 0) ? sdrKhachhang[0]["Diachi"] : "");
                    rptHdbanhang_VAT_gtgt.xrTableCell_Masothue.Text = "" +
                      ((sdrKhachhang != null && sdrKhachhang.Length > 0) ? sdrKhachhang[0]["Masothue"] : "");
                    rptHdbanhang_VAT_gtgt.xrTableCell_Sotaikhoan.Text = "" +
                      ((sdrKhachhang != null && sdrKhachhang.Length > 0) ? sdrKhachhang[0]["Sotaikhoan"] : "");
                    rptHdbanhang_VAT_gtgt.xrTableCell_Hoten.Text = "" +
                     ((sdrKhachhang != null && sdrKhachhang.Length > 0) ? sdrKhachhang[0]["Nguoi_Daidien"] : "");
                }
                // rptHdbanhang_VAT_gtgt.tbcSochungtu.Text = sdr[0]["Sochungtu"].ToString();
                decimal thanhtien_noVAT = Convert.ToDecimal(ds_Hdbanhang_Chitiet_vat.Tables[0].Compute("sum(Thanhtien)", ""));
                decimal thanhtien_VAT = Convert.ToDecimal(ds_Hdbanhang_Chitiet_vat.Tables[0].Compute("sum(Thanhtien_Print)", ""));
                rptHdbanhang_VAT_gtgt.xrTableCell_gtgt.Text = txtGTGT.Text;
                rptHdbanhang_VAT_gtgt.xrTableCell_Tongcong.Text = String.Format("{0:N}", thanhtien_VAT).Substring(0, String.Format("{0:N}", thanhtien_VAT).Length - 3).Replace(",", ".");
                decimal tien_GTGT = (thanhtien_noVAT * Convert.ToDecimal("0" + txtGTGT.EditValue)) / 100;
                rptHdbanhang_VAT_gtgt.xrTableCell_TienGtgt.Text = String.Format("{0:N}", tien_GTGT).Substring(0, String.Format("{0:N}", tien_GTGT).Length - 3).Replace(",",".");
                decimal tongtien = tien_GTGT + thanhtien_VAT;
                rptHdbanhang_VAT_gtgt.xrTableCell_TongTienthanhtoan.Text = String.Format("{0:N}", tongtien).Substring(0, String.Format("{0:N}", tongtien).Length - 3).Replace(",", ".");
                rptHdbanhang_VAT_gtgt.PageSize = new Size(800, 2000 + 120 * Convert.ToInt32(dsrHdbanhang_VAT.Tables[0].Rows.Count));

                string str = GoobizFrame.Windows.HelperClasses.ReadNumber.ChangeNum2VNStr(Convert.ToDouble(tongtien), " đồng.");
                str = str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower();
                rptHdbanhang_VAT_gtgt.xrTableCell_Sotien_Chu.Text = str;
                //rptHdbanhang_VAT_gtgt.xrTable6.Location = new System.Drawing.Point(21, 42);
                // rptHdbanhang_VAT_gtgt.xrTable4.Location = new System.Drawing.Point(21, 135);
                rptHdbanhang_VAT_gtgt.xrTableCell_Ngay.Text = DateTime.Today.Day.ToString();
                rptHdbanhang_VAT_gtgt.xrTableCell_thang.Text = DateTime.Today.Month.ToString();
                string nam = DateTime.Today.Year.ToString();
                rptHdbanhang_VAT_gtgt.xrTableCell_Nam.Text = nam.Substring(2, 2);

                DataSet dsHeso_Chuongtrinh;
                #region Set he so ctrinh - logo, ten cty
                using (DataSet dsCompany_Paras = new DataSet())
                {
                    dsCompany_Paras.Tables.Add("Company_Paras");
                    dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                    dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                    dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                    dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet();
                    byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                    dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData});

                    //rptHdbanhang_noVAT.xrc_CompanyName.DataBindings.Add(
                    //    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                    //rptHdbanhang_noVAT.xrc_CompanyAddress.DataBindings.Add(
                    //    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                    //rptHdbanhang_noVAT.xrPic_Logo.DataBindings.Add(
                    //    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
                }
                #endregion
                //if (lookupEdit_MaKhachhang.Text != "") // check if khách hàng quota --> hi?n th? thông tin gi?m giá
                //{
                //    DataSet dsKhachhang_KM = objWareService.Get_All_Ware_Khachhang_Quota_Detail_By_Khachhang(lookupEdit_MaKhachhang.EditValue).ToDataSet();
                //    if (dsKhachhang_KM.Tables.Count > 0 && dsKhachhang_KM.Tables[0].Rows.Count > 0)
                //    {
                //        if (dsKhachhang_KM.Tables[0].Rows[0]["Id_Vip_Member"].ToString() == "") // check if khach hang quota
                //        {
                //            rptHdbanhang_noVAT.lblSotien_Giam.Visible = true;
                //            rptHdbanhang_noVAT.xrSotien_Giam.Visible = true;
                //        }
                //    }
                //}
                rptHdbanhang_VAT_gtgt.CreateDocument();
                GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(rptHdbanhang_VAT_gtgt);
                if (Convert.ToBoolean(oReportOptions.PrintPreview))
                {
                    frmPrintPreview.Text = "" + oReportOptions.Caption;
                    frmPrintPreview.printControl1.PrintingSystem = rptHdbanhang_VAT_gtgt.PrintingSystem;
                    frmPrintPreview.MdiParent = this.MdiParent;
                    frmPrintPreview.Text = this.Text + "(Xem trang in)";
                    frmPrintPreview.Show();
                    frmPrintPreview.Activate();
                }
                else
                {
                    var reportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rptHdbanhang_VAT_gtgt);
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

        #region Even

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //Kiem tra so luong ton
            this.DoClickEndEdit(dgware_hdbanhang_chitiet_capgia);
            id_cap = lookupEdit_MaKhachhang.GetColumnValue("Id_Cap");
            if (e.Column.FieldName == "Id_Hanghoa_Ban")
            {
                if ("" + gridView2.GetFocusedRowCellValue("Id_Hanghoa_Ban") == "")
                    return;
                gridView2.SetFocusedRowCellValue(gridView2.Columns["Dongia_Ban"], 0);
                DataSet dsDinhgia_ById_Hanghoa = objWareService.Get_All_Ware_Hanghoa_Dinhgia_By_Id_HhBan(gridView2.GetFocusedRowCellValue("Id_Hanghoa_Ban")).ToDataSet();
                DataRow[] row = dsDinhgia_ById_Hanghoa.Tables[0].Select();
                if (row != null && row.Length > 0)
                {
                    gridView2.SetFocusedRowCellValue(gridView2.Columns["Id_Donvitinh"], row[0]["Id_Donvitinh"]);
                    DataSet dsHanghoa_Dinhgia_Cap = objWareService.Ware_Dongia_Cap_Selectall(row[0]["Id_Hanghoa_Dinhgia"]).ToDataSet();
                    if (dsHanghoa_Dinhgia_Cap.Tables[0].Rows.Count > 0 && id_cap != null && id_cap + "" != "")
                    {
                        DataRow[] dtr_gia_Cap = dsHanghoa_Dinhgia_Cap.Tables[0].Select("Id_Cap = " + id_cap);
                        if (dtr_gia_Cap != null && dtr_gia_Cap.Length > 0)
                            gridView2.SetFocusedRowCellValue(gridView2.Columns["Dongia_Ban"], dtr_gia_Cap[0]["Dongia_Ban"]);
                    }
                    else
                    {
                        gridView2.SetFocusedRowCellValue(gridView2.Columns["Dongia_Ban"], row[0]["Dongia_Banle"]);

                    }
                }
                if (lookupEdit_MaKhachhang.Text != "")
                {
                    object chietkhau = objMasterService.Ware_Dm_Khachhang_Nhansu_SelectChietkhau(lookupEdit_MaKhachhang.EditValue);
                    gridView2.SetFocusedRowCellValue(gridView2.Columns["Per_Dongia"], chietkhau);
                }
            }
            if (e.Column.FieldName == "Soluong")
            {
                if ("" + gridView2.GetFocusedRowCellValue("Id_Hanghoa_Ban") == "")
                    return;
                decimal soluong = Convert.ToDecimal("0" + gridView2.GetFocusedRowCellValue("Soluong"));
                DataSet dsSL_Ton = objWareService.ware_Hdbanhang_Chitiet_CheckSL(gridView2.GetFocusedRowCellValue("Id_Hanghoa_Ban")
                                                                                , gridView2.GetFocusedRowCellValue("Id_Donvitinh")
                                                                                , gridView2.GetFocusedRowCellValue("Id_Hdbanhang_Chitiet_Vat")).ToDataSet();
                if (dsSL_Ton.Tables[0].Rows.Count > 0)
                {
                    decimal sl_ton = Convert.ToDecimal("0" + dsSL_Ton.Tables[0].Rows[0]["Soluong_Ton"]);
                    if (soluong > sl_ton)
                    {
                        GoobizFrame.Windows.Forms.MessageDialog.Show("Số lượng không được lớn hơn số lượng nhập");
                        gridView2.SetFocusedRowCellValue("Soluong", sl_ton);
                    }
                }
                decimal Per_Dongia = Convert.ToDecimal("0" + gridView2.GetFocusedRowCellValue("Per_Dongia"));
                gridView2.SetFocusedRowCellValue("Thanhtien",
                    soluong * Convert.ToDecimal("0" + gridView2.GetFocusedRowCellValue("Dongia_Ban")) * (1 - Per_Dongia / 100));
                gridView2.BestFitColumns();
            }
        }

        private void gridView4_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if ("" + gvHdbang_Chitiet.GetFocusedRowCellValue("Id_Hdbanhang_Chitiet") == "")
                return;
            dgware_Hdbanhang_Chitiet.DataSource = ds_Hdbanhang_Chitiet_vat.Tables[0];
        }

        private void lookUpEdit_Khachhang_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (FormState == GoobizFrame.Windows.Forms.FormState.View && "" + lookupEdit_MaKhachhang.EditValue != "")
                    lookupEdit_MaKhachhang.Text = "" + ((DataRowView)lookupEdit_MaKhachhang.Properties.GetDataSourceRowByKeyValue(lookupEdit_MaKhachhang.EditValue))["Ma_Khachhang"];
            }
            catch { lookupEdit_MaKhachhang.Text = ""; }
        }

        private void gridView4_RowCountChanged(object sender, EventArgs e)
        {
            try
            {
                this.DoClickEndEdit(dgware_Hdbanhang_Chitiet);
                //txtSotien.EditValue = Convert.ToDecimal("0" + gvHdbang_Chitiet.Columns["Thanhtien"].SummaryItem.SummaryValue) - Convert.ToDecimal("0" + ds_Hdbanhang_Chitiet.Tables[0].Compute("sum(Thanhtien_Km)", ""));
                //txtSotien.EditValue = Convert.ToDecimal(gvHdbang_Chitiet.Columns["Thanhtien"].SummaryItem.SummaryValue) - Convert.ToDecimal("0" + txtHotro.EditValue);
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.ToString());
            }
        }

        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        #region xtraTabPage4

        //private void repositoryItemCalcEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        // {
        //     if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
        //     {
        //         AddNewOrderDetail("" + cardView1.GetFocusedRowCellValue("Barcode_Txt"), cardView1.GetFocusedRowCellValue("Soluong"));
        //         cardView1.GetDataRow(cardView1.GetDataSourceRowIndex(cardView1.FocusedRowHandle)).RejectChanges();
        //     }
        //     else if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
        //         cardView1.GetDataRow(cardView1.GetDataSourceRowIndex(cardView1.FocusedRowHandle)).RejectChanges();
        // }

        #endregion

        #region custom button

        // button t?o m?i
        private void btnAdd_Click(object sender, EventArgs e)
        {
            PerformAdd();
            this.ClearDataBindings();
            ChangeFormState(GoobizFrame.Windows.Forms.FormState.Add);
        }

        // button b? qua
        private void btnCancel_Click(object sender, EventArgs e)
        {
            PerformCancel();
            ChangeFormState(GoobizFrame.Windows.Forms.FormState.Cancel);
            this.ResetText();
            this.txtSochungtu.EditValue = null;
            this.dtNgay_Chungtu.EditValue = null;
        }

        // button thanh toán
        private void btnCash_Click(object sender, EventArgs e)
        {
            double dongia = 0;
            for (int i = 0; i < ds_Hdbanhang_Chitiet_vat.Tables[0].Rows.Count; i++)
            {
                dongia = Convert.ToDouble("0" + ds_Hdbanhang_Chitiet_vat.Tables[0].Rows[i]["Dongia_Ban"]);
                if (dongia == 0)
                {
                    //lblStatus_Bar.Text = "Có hàng hóa chua có don giá, nh?p l?i";
                    return;
                }
                dongia = 0;
            }
            ChangeFormState(GoobizFrame.Windows.Forms.FormState.Add);
            thanhtien = Convert.ToDouble(gvHdbang_Chitiet.Columns["Thanhtien"].SummaryItem.SummaryValue);
            PerformSave();

            //this.ds_Hdbanhang = objWareService.Get_All_Ware_Hdbanhang_ById_Hdbanhang(identity).ToDataSet();
            //this.ds_Hdbanhang_Chitiet = objWareService.Get_All_Ware_Hdbanhang_Chitiet_By_Hdbanhang(identity).ToDataSet();
            //PerformPrintPreview();
            //PerformAdd();
        }

        // button k?t thúc
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // button tìm hàng
        private void btnChon_HH_Click(object sender, EventArgs e)
        {
            splitContainerControl1.PanelVisibility =
            (splitContainerControl1.PanelVisibility != DevExpress.XtraEditors.SplitPanelVisibility.Both)
            ? DevExpress.XtraEditors.SplitPanelVisibility.Both
            : DevExpress.XtraEditors.SplitPanelVisibility.Panel1;
        }


        #endregion

        #region xtraTabPage_Hdbanhang_Chitiet2

        //button th? khách hàng
        private void btnKhachhang_Click(object sender, EventArgs e)
        {
            lookupEdit_MaKhachhang.Enabled = true;
            lookupEdit_MaKhachhang.Text = GoobizFrame.Windows.Forms.FrmGKeyboardInput.ShowInputDialog(lookupEdit_MaKhachhang.Text);
        }

        //button giao ca
        private void btnSplit_Click(object sender, EventArgs e)
        {
            GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowDialogOfMetaData("Ecm.Reports.dll", "Ecm.Reports.Forms.FrmRptSplit_Sum_Hhban", this.MdiParent);
        }
        #endregion

        // nhap mã khách hàng
        private void txtMa_Khachhang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            lookupEdit_MaKhachhang.EditValue = GoobizFrame.Windows.Forms.FrmGKeyboardInput.ShowInputDialog(lookupEdit_MaKhachhang.Text);
        }

        #region button tren grid
        // Xóa hàng hóa trên grid
        void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //if (MessageBox.Show("B?n có ch?c mu?n xóa hàng hóa này?", "Confirm Dialog", MessageBoxButtons.YesNo) == DialogResult.Yes)
            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[] { "Hàng hóa " }) == DialogResult.Yes)
            {
                ds_Hdbanhang_Chitiet_vat.Tables[0].Rows[gvHdbang_Chitiet.FocusedRowHandle].Delete();
                dgware_Hdbanhang_Chitiet.DataSource = ds_Hdbanhang_Chitiet_vat;
                dgware_Hdbanhang_Chitiet.DataMember = ds_Hdbanhang_Chitiet_vat.Tables[0].TableName;
                //Recal_Dongia();
            }
        }

        // Nh?p s? lu?ng trên grid
        void repositoryItemButtonEdit3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            object value = GoobizFrame.Windows.Forms.FrmGNumboardInput.ShowInputDialog("" + gvHdbang_Chitiet.GetFocusedRowCellValue("" + gvHdbang_Chitiet.FocusedColumn.FieldName));
            if (value == null)
            {
                gvHdbang_Chitiet.SetFocusedRowCellValue(gvHdbang_Chitiet.FocusedColumn, 1);
                return;
            }
            if (value.ToString() == "0")
            {
                gvHdbang_Chitiet.SetFocusedRowCellValue(gvHdbang_Chitiet.FocusedColumn, 1);
                return;
            }
            if (value.ToString().Contains("-"))
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("S? lu?ng không du?c nh?p s? âm");
                value = value.ToString().Replace("-", "");
            }
            if (value.ToString().Length >= 6)
            {
                //value = value.ToString().Substring(0, 5);
                GoobizFrame.Windows.Forms.MessageDialog.Show("S? lu?ng nh?p không dúng");
                gvHdbang_Chitiet.SetFocusedRowCellValue(gvHdbang_Chitiet.Columns["Soluong"], 1);
                return;
            }
            gvHdbang_Chitiet.SetFocusedRowCellValue(gvHdbang_Chitiet.FocusedColumn, value);
            gvHdbang_Chitiet.RefreshRow(gvHdbang_Chitiet.FocusedRowHandle);
        }

        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PerformPrintPreview();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.DisplayInfo_Details();
        }


        #endregion

        #region custom method

        public decimal Get_Soluong_Ton_Quydoi(object Id_Hanghoa_Ban, object Id_Donvitinh)
        {
            try
            {
                //var _Id_Donvitinh = ds_Hanghoa_Ban_after_Thongke.Tables[0].Select(string.Format("Id_Hanghoa_Ban={0}", Id_Hanghoa_Ban))[0]["Id_Donvitinh"];
                DataSet ds_hh_nxt = Get_Soluong_Ton_Quydoi(-1, Id_Hanghoa_Ban, Id_Donvitinh);
                decimal soluong_ton_quydoi = 0;
                //soluong_ton_quydoi = (Id_Donvitinh == _Id_Donvitinh)
                //? Convert.ToDecimal("0" + ds_hh_nxt.Tables[0].Compute("sum(Soluong_Ton_Qdoi)",
                //        string.Format("Id_Hanghoa_Ban={0}", Id_Hanghoa_Ban)))
                //: Convert.ToDecimal("0" + ds_hh_nxt.Tables[0].Compute("sum(Soluong_Ton)",
                //        string.Format("Id_Hanghoa_Ban={0} and Id_Donvitinh={1}", Id_Hanghoa_Ban, Id_Donvitinh)));
                soluong_ton_quydoi = Convert.ToDecimal("0" + ds_hh_nxt.Tables[0].Compute("sum(Soluong_Ton_Qdoi)", string.Format("Id_Hanghoa_Ban={0}", Id_Hanghoa_Ban)));
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

        void DisplayInfo_Details()
        {
            //gridColumn35.Visible = false;
            identity = gvHoadon.GetFocusedRowCellValue("Id_Hdbanhang");
            this.ds_Hdbanhang_Chitiet_vat = objWareService.Ware_Hdbanhang_Chitiet_Vat_SelectById_Hdbanhang_Vat(identity).ToDataSet();
            ds_Hdbanhang_Chitiet_vat.Tables[0].Columns.Add("Chon", typeof(bool));
            if (!ds_Hdbanhang_Chitiet_vat.Tables[0].Columns.Contains("Ten_Donvitinh"))
                ds_Hdbanhang_Chitiet_vat.Tables[0].Columns.Add("Ten_Donvitinh", typeof(string));
            this.dgware_hdbanhang_chitiet_capgia.DataSource = ds_Hdbanhang_Chitiet_vat.Tables[0];
            gvHdbang_Chitiet.BestFitColumns();
            DataBindingControl();
        }

        #endregion

        private void lookupEdit_MaKhachhang_EditValueChanged(object sender, EventArgs e)
        {
            if (lookupEdit_MaKhachhang.EditValue == null)
            {
                txtTen_Khachhang.Text = "";
                txtDiachi.Text = "";
                return;
            }
            txtTen_Khachhang.Text = lookupEdit_MaKhachhang.GetColumnValue("Ten_Khachhang") + "";
            txtDiachi.Text = lookupEdit_MaKhachhang.GetColumnValue("Diachi_Khachhang") + "";
            id_khuvuc = lookupEdit_MaKhachhang.GetColumnValue("Id_Khuvuc");
            foreach (DataRow dtr in ds_Hdbanhang_Chitiet_vat.Tables[0].Rows)
            {
                if ("" + gvHdbang_Chitiet.GetFocusedRowCellValue("Id_Hanghoa_Ban") == "" || FormState == GoobizFrame.Windows.Forms.FormState.View)
                    return;
                DataSet dsDinhgia_ById_Hanghoa = objWareService.Get_All_Ware_Hanghoa_Dinhgia_By_Id_HhBan(dtr["Id_Hanghoa_Ban"]).ToDataSet();
                DataRow[] row = dsDinhgia_ById_Hanghoa.Tables[0].Select("Ngay_Batdau = '" + dsDinhgia_ById_Hanghoa.Tables[0].Compute("max(Ngay_Batdau)", "") + "'");
                if (row != null && row.Length > 0)
                {
                    DataSet dsHanghoa_Dinhgia_Khuvuc = objWareService.Get_All_Ware_Hanghoa_Dinhgia_Khuvuc(row[0]["Id_Hanghoa_Dinhgia"]).ToDataSet();
                    if (dsHanghoa_Dinhgia_Khuvuc.Tables[0].Rows.Count > 0 && id_khuvuc + "" != "")
                    {
                        DataRow[] dtr_gia_KV = dsHanghoa_Dinhgia_Khuvuc.Tables[0].Select("Id_Khuvuc = " + id_khuvuc);
                        if (dtr_gia_KV != null && dtr_gia_KV.Length > 0)
                        {
                            dtr["Dongia_Ban"] = dtr_gia_KV[0]["Dongia_Ban"];
                            dtr["Thanhtien"] = Convert.ToDecimal("0" + dtr["Dongia_Ban"]) * Convert.ToDecimal("0" + dtr["Soluong"]);
                        }
                    }
                }
                dtr["Per_Dongia"] = objMasterService.Ware_Dm_Khachhang_Nhansu_SelectChietkhau(lookupEdit_MaKhachhang.EditValue);
            }
            if (FormState != GoobizFrame.Windows.Forms.FormState.View)
            {
                DataSet ds_Congno = objReportService.Rpt_Congno_Chitiet_New2(objWareService.GetServerDateTime(), objWareService.GetServerDateTime(), lookupEdit_MaKhachhang.Text).ToDataSet();
                //txtCongno.EditValue = ds_Congno.Tables[0].Compute("sum(Sotien_No_Ck)", "");
            }
        }

        private void gvHoadon_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ClearDataBindings();
            ResetText();
            if (gvHoadon.IsDataRow(gvHoadon.FocusedRowHandle))
                DisplayInfo_Details();
        }

        private void dtNgay_Chungtu_View_EditValueChanged(object sender, EventArgs e)
        {
            DisplayInfo();
        }

        private void Frmware_Hdbanhang_noVAT_Hhban_Load(object sender, EventArgs e)
        {
            DisplayInfo();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            Load_Gridview();
        }

        private void gvHdbang_Chitiet_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvHdbang_Chitiet.SetFocusedRowCellValue("Per_Dongia", 0);
        }

        private void lookUpEditKhuvuc_View_EditValueChanged(object sender, EventArgs e)
        {
            //if (lookUpEditKhuvuc_View.EditValue != null)
            //{
            //    DataSet ds_Khachhang = objMasterService.Ware_Dm_Khachhang_SelectBy_Khuvuc_Id_Nhansu(lookUpEditKhuvuc_View.EditValue, id_nhansu_current).ToDataSet();
            //    //lookupEdit_MaKhachhang.Properties.DataSource = ds_Khachhang.Tables[0];
            //    lookUpEdit_MaKH_View.Properties.DataSource = ds_Khachhang.Tables[0];
            //}
            Load_Gridview();
        }
        private void gridView2_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView2.SetFocusedRowCellValue("Per_Dongia", 0);
        }


        private void btnSend_Click(object sender, EventArgs e)
        {
            if (gvHoadon.GetFocusedRowCellValue("Id_Hdbanhang") == null)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chua ch?n don hàng, vui lòng ch?n l?i");
                return;
            }
            if (MessageBox.Show("G?i don hàng này di?", "Confirm Dialog", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    this.lookUpEditKhuvuc_View.DataBindings.Clear();
                    this.lookUpEditKhuvuc_View.DataBindings.Add("EditValue", ds_Hdbanhang_vat, ds_Hdbanhang_vat.Tables[0].TableName + ".Id_Cuahang_Ban");

                    Ecm.WebReferences.WareService.Ware_Hdbanhang objWare_Hdbanhang = new Ecm.WebReferences.WareService.Ware_Hdbanhang();
                    objWare_Hdbanhang.Id_Hdbanhang = identity;
                    objWare_Hdbanhang.Sochungtu = txtSochungtu.EditValue;
                    //objWare_Hdbanhang.Sotien = txtSotien.EditValue;
                    objWare_Hdbanhang.Sotien_Vat = 0;
                    objWare_Hdbanhang.Ngay_Chungtu = dtNgay_Chungtu.EditValue;
                    objWare_Hdbanhang.Hoten_Nguoimua = "";
                    objWare_Hdbanhang.Per_Vat = txtGTGT.EditValue;
                    objWare_Hdbanhang.Phuongthuc_Thanhtoan = "TM";
                    objWare_Hdbanhang.So_Seri = "N/A";
                    // objWare_Hdbanhang.Ngay_Thanhtoan = dtNgaygiao.EditValue; // dùng ngày thanh toán làm ngày giao hàng
                    //objWare_Hdbanhang.Ngay_Thutien = dtNgay_Thutien.EditValue;
                    objWare_Hdbanhang.Id_Khachang = lookupEdit_MaKhachhang.EditValue;
                    objWare_Hdbanhang.NoVAT = true;
                    objWare_Hdbanhang.Id_Cuahang_Ban = lookUpEditKhuvuc_View.EditValue;
                    // objWare_Hdbanhang.Sotien_Congno = Convert.ToDecimal("0" + txtCongno.EditValue);
                    if ("" + lookUpEdit_Nhansu_Banhang.EditValue != "")
                        objWare_Hdbanhang.Id_Nhansu_Bh = lookUpEdit_Nhansu_Banhang.EditValue;

                    objWare_Hdbanhang.Id_Khachang = ("" + lookupEdit_MaKhachhang.EditValue != "") ? lookupEdit_MaKhachhang.EditValue : -1;
                    objWare_Hdbanhang.Id_Nhansu_Km = -1;
                    //  objWare_Hdbanhang.Ghichu = "" + txtGhichu.EditValue;
                    // objWare_Hdbanhang.Ghichu_Edit = "" + txtLydo.EditValue;
                    objWare_Hdbanhang.Doc_Process_Status = 1;

                    //update donmuahang
                    objWareService.Update_Ware_Hdbanhang(objWare_Hdbanhang);

                    // send mail
                    //if (!System.IO.Directory.Exists("D:\\donhang"))
                    //    System.IO.Directory.CreateDirectory("D:\\donhang");
                    //gvHdbang_Chitiet.ExportToPdf("D:\\donhang\\" + txtSochungtu.Text + ".pdf");


                    DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet();
                    Ecm.WebReferences.RexService.Rex_Nhansu nhansu = objRexService.Rex_Nhansu_SelectMail_Nhansu_KTVP();
                    //g?i mail cho user thu?c b? ph?n K? Toán Van Phòng
                    //string emailTo = "" + nhansu.Email;
                    string emailTo = "" + "ecm@ptts.vn";
                    //string emailTo = dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyEmail"))[0]["Heso"].ToString();
                    //string emailTo = "hoangnhan1907@gmail.com";
                    string subject = "Ðon hàng " + txtSochungtu.Text + " - " + lookUpEdit_Nhansu_Banhang.Text;
                    string body = "Nhân viên bán hàng: " + lookUpEdit_Nhansu_Banhang.Text;
                    body += "<br/>Khách hàng: " + txtTen_Khachhang.Text + " - " + lookUpEditKhuvuc_View.Text;
                    body += "<br/>Ðịa chỉ: " + txtDiachi.Text;
                    // body += "<br/>Ngày giao: " + dtNgaygiao.Text;
                    //  body += "<br/>Ghi chú: " + txtGhichu.Text;

                    string smtpAddress = dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "Mail_Server"))[0]["Heso"].ToString(); //"smtp.longthanhmekong.com";
                    int portNumber = Convert.ToInt32(dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "Port"))[0]["Heso"]); //25;
                    bool enableSSL = Convert.ToBoolean(dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "SSL"))[0]["Heso"]);// false;
                    string emailFrom = dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "Email_Server"))[0]["Heso"].ToString(); //"info@longthanhmekong.com";
                    string password = dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "Password_Email"))[0]["Heso"].ToString(); ///"leminhlong18072007";

                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(emailFrom);
                        mail.To.Add(emailTo);
                        mail.Subject = subject;
                        mail.Body = body;
                        mail.IsBodyHtml = true;
                        // Can set to false, if you are sending pure text.
                        //mail.Attachments.Add(new Attachment("D:\\donhang\\" + txtSochungtu.Text + ".pdf"));
                        //mail.Attachments.Add(new Attachment("C:\\SomeZip.zip"));
                        using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                        {
                            smtp.Credentials = new NetworkCredential("info", password);
                            smtp.EnableSsl = enableSSL;
                            smtp.Send(mail);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.ToString());
                }
                DisplayInfo();
            }
        }

        private bool check_soluong_ton(object id_hanghoa_ban, object id_donvitinh, object soluong)
        {
            DataRow[] dtr = ds_Hanghoa_Ban_after_Thongke.Tables[0].Select("Id_Hanghoa_Ban = " + id_hanghoa_ban + " and Id_Donvitinh = " + id_donvitinh);
            if (dtr.Length > 0)
            {
                if (Convert.ToDecimal(dtr[0]["Soluong_Ton"]) < Convert.ToDecimal(soluong))
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Không d? s? lu?ng xu?t");
                    return false;
                }
                else
                    return true;
            }
            else
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Hàng hóa không d? s? lu?ng xu?t");
                return false;
            }
        }

        private void lookUpEdit_MaKH_View_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                lookUpEdit_MaKH_View.EditValue = null;
        }

        private void txtHotro_EditValueChanged(object sender, EventArgs e)
        {
            //txtSotien.EditValue = Convert.ToDecimal(gvHdbang_Chitiet.Columns["Thanhtien"].SummaryItem.SummaryValue) - Convert.ToDecimal("0" + txtHotro.EditValue);
        }

        private void dtNgaygiao_EditValueChanged(object sender, EventArgs e)
        {
            //ds_Khachhang = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
            // Kiem tra gia tri cua cot tinh cong no
            //if (Convert.ToBoolean(lookupEdit_MaKhachhang.GetColumnValue("Tinhcongno")))
            //{
            //    switch (Convert.ToInt64(lookupEdit_MaKhachhang.GetColumnValue("Congno_Thang")))
            //    {
            //        case 0:
            //            dtNgay_Thutien.Properties.ReadOnly = true;
            //            dtNgay_Thutien.EditValue = dtNgaygiao.EditValue;
            //            break;
            //        case 10:
            //            dtNgay_Thutien.Properties.ReadOnly = true;
            //            dtNgay_Thutien.EditValue = dtNgaygiao.DateTime.AddDays(10);
            //            break;
            //        case 30:
            //            dtNgay_Thutien.Properties.ReadOnly = true;
            //            dtNgay_Thutien.EditValue = new DateTime(dtNgay_Chungtu.DateTime.Year, dtNgay_Chungtu.DateTime.Month, 1, 23, 59, 59).AddMonths(1).AddDays(-1);
            //            break;
            //    }
            //}

            //else
            //{
            //    dtNgay_Thutien.Properties.ReadOnly = false;
            //}
        }

        private void gvHdbang_Chitiet_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //Kiem tra so luong ton
            this.DoClickEndEdit(dgware_Hdbanhang_Chitiet);
            id_khuvuc = lookupEdit_MaKhachhang.GetColumnValue("Id_Khuvuc");

            if (e.Column.FieldName == "Id_Hanghoa_Ban")
            {
                if ("" + gvHdbang_Chitiet.GetFocusedRowCellValue("Id_Hanghoa_Ban") == "")
                    return;
                gvHdbang_Chitiet.SetFocusedRowCellValue(gvHdbang_Chitiet.Columns["Dongia_Ban"], 0);
                DataSet dsDinhgia_ById_Hanghoa = objWareService.Get_All_Ware_Hanghoa_Dinhgia_By_Id_HhBan(gvHdbang_Chitiet.GetFocusedRowCellValue("Id_Hanghoa_Ban")).ToDataSet();
                DataRow[] row = dsDinhgia_ById_Hanghoa.Tables[0].Select();
                if (row != null && row.Length > 0)
                {

                    gvHdbang_Chitiet.SetFocusedRowCellValue(gvHdbang_Chitiet.Columns["Id_Donvitinh"], row[0]["Id_Donvitinh"]);

                    DataSet dsHanghoa_Dinhgia_Khuvuc = objWareService.Get_All_Ware_Hanghoa_Dinhgia_Khuvuc(row[0]["Id_Hanghoa_Dinhgia"]).ToDataSet();
                    if (dsHanghoa_Dinhgia_Khuvuc.Tables[0].Rows.Count > 0 && id_khuvuc != null && id_khuvuc + "" != "")
                    {
                        DataRow[] dtr_gia_KV = dsHanghoa_Dinhgia_Khuvuc.Tables[0].Select("Id_Khuvuc = " + id_khuvuc);
                        if (dtr_gia_KV != null && dtr_gia_KV.Length > 0)
                            gvHdbang_Chitiet.SetFocusedRowCellValue(gvHdbang_Chitiet.Columns["Dongia_Ban"], dtr_gia_KV[0]["Dongia_Ban"]);
                    }
                    else
                    {
                        gvHdbang_Chitiet.SetFocusedRowCellValue(gvHdbang_Chitiet.Columns["Dongia_Ban"], row[0]["Dongia_Banle"]);
                    }
                }
                if (lookupEdit_MaKhachhang.Text != "")
                {
                    object chietkhau = objMasterService.Ware_Dm_Khachhang_Nhansu_SelectChietkhau(lookupEdit_MaKhachhang.EditValue);
                    gvHdbang_Chitiet.SetFocusedRowCellValue(gvHdbang_Chitiet.Columns["Per_Dongia"], chietkhau);
                }
            }
            if (e.Column.FieldName == "Soluong")
            {
                if ("" + gvHdbang_Chitiet.GetFocusedRowCellValue("Id_Hanghoa_Ban") == "")
                    return;
                decimal soluong = Convert.ToDecimal("0" + gvHdbang_Chitiet.GetFocusedRowCellValue("Soluong"));
                DataSet dsSL_Ton = objWareService.ware_Hdbanhang_Chitiet_CheckSL(gvHdbang_Chitiet.GetFocusedRowCellValue("Id_Hanghoa_Ban")
                                                                                , gvHdbang_Chitiet.GetFocusedRowCellValue("Id_Donvitinh")
                                                                                , gvHdbang_Chitiet.GetFocusedRowCellValue("Id_Hdbanhang_Chitiet_Vat")).ToDataSet();
                if (dsSL_Ton.Tables[0].Rows.Count > 0)
                {
                    decimal sl_ton = Convert.ToDecimal("0" + dsSL_Ton.Tables[0].Rows[0]["Soluong_Ton"]);
                    if (soluong > sl_ton)
                    {
                        GoobizFrame.Windows.Forms.MessageDialog.Show("Số lượng không được lớn hơn số lượng nhập");
                        gvHdbang_Chitiet.CancelUpdateCurrentRow();
                    }
                }
                //decimal Per_Dongia = Convert.ToDecimal("0" + gvHdbang_Chitiet.GetFocusedRowCellValue("Per_Dongia"));
                //gvHdbang_Chitiet.SetFocusedRowCellValue(gvHdbang_Chitiet.Columns["Thanhtien"],
                //    soluong * Convert.ToDecimal("0" + gvHdbang_Chitiet.GetFocusedRowCellValue("Dongia_Ban")) * (1 - Per_Dongia / 100));


                gvHdbang_Chitiet.BestFitColumns();
            }
        }

        private void gvHdbang_Chitiet_KeyDown(object sender, KeyEventArgs e)
        {
            if (gvHdbang_Chitiet.FocusedColumn.VisibleIndex == gvHdbang_Chitiet.VisibleColumns.Count - 1
             && "" + gvHdbang_Chitiet.GetFocusedRowCellValue("Id_Hanghoa_Ban") != "" && gvHdbang_Chitiet.FocusedRowHandle == gvHdbang_Chitiet.RowCount - 1)
                gvHdbang_Chitiet.AddNewRow();
        }

        private void gridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridView2.FocusedColumn.VisibleIndex == gridView2.VisibleColumns.Count - 1
            && "" + gridView2.GetFocusedRowCellValue("Id_Hanghoa_Ban") != "" && gridView2.FocusedRowHandle == gridView2.RowCount - 1)
                gridView2.AddNewRow();
        }

        private void gridButtonEdit_Delete2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[] { "Hàng hóa " }) == DialogResult.Yes)
            {
                ds_Hdbanhang_Chitiet_vat.Tables[0].Rows[gridView2.FocusedRowHandle].Delete();
                dgware_hdbanhang_chitiet_capgia.DataSource = ds_Hdbanhang_Chitiet_vat;
                dgware_hdbanhang_chitiet_capgia.DataMember = ds_Hdbanhang_Chitiet_vat.Tables[0].TableName;
                //Recal_Dongia();
            }
        }

        private void dtNgay_Xuat_EditValueChanged(object sender, EventArgs e)
        {
            if (FormState != GoobizFrame.Windows.Forms.FormState.View && dtNgay_Xuat.EditValue != null)
            {
                if (!Convert.ToBoolean(objWareService.Ware_Hdbanhang_Vat_Check_Ngayxuat(dtNgay_Xuat.EditValue))) // không cho phép tạo ngày xuất
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Ngày xuất không được nhỏ hơn phiếu đã tạo!");
                    dtNgay_Xuat.EditValue = null;
                }
            }
        }


    }
}