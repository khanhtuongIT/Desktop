using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using System.Net.Mail;
using System.Net;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Hdbanhang_noVAT_MngrEdit : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Hdbanhang = new DataSet();
        DataSet ds_Hdbanhang_Chitiet = new DataSet();
        DataSet ds_Hdbanhang_Chitiet_Log = new DataSet();
        //DataSet ds_Ware_Xuat_Hh_Ban;
        DataSet ds_Hanghoa_Ban;
        DataSet ds_Khachhang;
        DataSet ds_Nhansu;
        DataSet ds_Donvitinh;
        //DataSet ds_Hanghoa_Ban_after_Thongke;
        //DataSet ds_Ware_Xuat_Hh_Ban_Chitiet;
        //object Id_Xuat_Hh_Ban;
        double thanhtien;
        object identity;

        public Frmware_Hdbanhang_noVAT_MngrEdit()
        {
            InitializeComponent();
            //GoobizFrame.Windows.PlugIn.RightHelpers.CheckUserRightAction(this);
            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");

            //date mask
            this.dtNgay_Chungtu_View.Properties.MinValue = new DateTime(2000, 01, 01);
            //set current date time
            dtNgay_Chungtu_View.EditValue = objWareService.GetServerDateTime();
            this.BarSystem.Visible = false;
            this.AfterCheckUserRightAction += new EventHandler(Frmware_Hdbanhang_noVAT_MngrEdit_AfterCheckUserRightAction);
            LoadMasterData();
            Load_Gridview();
            this.ChangeStatus(false);
            gridLookUpEdit_Hanghoa_Ban.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            //gridLookUpEdit_Ma_Hanghoa_Ban2.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            //gridLookup_Hanghoa_Ban2.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            gridLookupEdit_Mahanghoa.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
        }

        void Frmware_Hdbanhang_noVAT_MngrEdit_AfterCheckUserRightAction(object sender, EventArgs e)
        {
            this.btnEdit.Enabled = EnableEdit;
            this.btnCash.Enabled = EnablePrintPreview;
        }

        #region Display, process data

        void LoadMasterData()
        {
            ds_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa().ToDataSet();
            gridLookUpEdit_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
            //gridLookUpEdit_Ma_Hanghoa_Ban2.DataSource = ds_Hanghoa_Ban.Tables[0];
            //gridLookup_Hanghoa_Ban2.DataSource = ds_Hanghoa_Ban.Tables[0];
            gridLookupEdit_Mahanghoa.DataSource = ds_Hanghoa_Ban.Tables[0];

            DataSet dsDonvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
            gridLookUpEdit_Donvitinh.DataSource = dsDonvitinh.Tables[0];
            //gridLookupEdit_Donvitinh2.DataSource = dsDonvitinh.Tables[0];

            ds_Khachhang = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
            ds_Nhansu = objRexService.Rex_Nhansu_SelectMail().ToDataSet();
            DataRow row = ds_Nhansu.Tables[0].NewRow();
            row["Id_Nhansu"] = -1;
            row["Ma_Nhansu"] = "All";
            row["Hoten_Nhansu"] = "Tất cả";
            ds_Nhansu.Tables[0].Rows.Add(row);
            ds_Donvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();


            lookUpEdit_Nhansu_Banhang.Properties.DataSource = ds_Nhansu.Tables[0];
            lookUpEdit_Nhansu_Banhang_View.Properties.DataSource = ds_Nhansu.Tables[0];
            lookUpEdit_Nhansu_Banhang_View.EditValue = Convert.ToInt64(-1);
            gridLookUpEdit_Nhansu.DataSource = ds_Nhansu.Tables[0];
            gridLookupEdit_Nhansu_Donhang.DataSource = ds_Nhansu.Tables[0];
            //lookUpEdit_Nhansu_Xuat2.Properties.DataSource = ds_Nhansu.Tables[0];
            //lookUpEdit_Nhansu_Nhap2.Properties.DataSource = ds_Nhansu.Tables[0];

            gridLookUpEdit_Donvitinh.DataSource = ds_Donvitinh.Tables[0];
            lookUpEdit_Khachhang.Properties.DataSource = ds_Khachhang.Tables[0];
            DataSet ds_Cuahang = objMasterService.Ware_Dm_Cuahang_Ban_Select_Sale().ToDataSet();
            row = ds_Cuahang.Tables[0].NewRow();
            row["Id_Cuahang_Ban"] = -1;
            row["Ma_Cuahang_Ban"] = "All";
            row["Ten_Cuahang_Ban"] = "Tất cả";
            ds_Cuahang.Tables[0].Rows.Add(row);
            lookUpEditMa_Cuahang_Ban.Properties.DataSource = ds_Cuahang.Tables[0];
            lookUpEditMa_Cuahang_Ban.EditValue = "All";

            //DataTable dtbKho = objMasterService.Ware_Dm_Cuahang_Ban_Select_Kho().ToDataSet().Tables[0];
            //row = dtbKho.NewRow();
            //row["Id_Cuahang_Ban"] = -1;
            //row["Ma_Cuahang_Ban"] = "All";
            //row["Ten_Cuahang_Ban"] = "Tất cả";
            //dtbKho.Rows.Add(row);
            ////gridLookUpEdit_Cuahang_Ban_Xuat.DataSource = dtbKho;
            ////lookUpEdit_Cuahang_Ban_Nhap2.Properties.DataSource = dtbKho;
            ////lookUpEdit_Cuahang_Ban_Xuat2.Properties.DataSource = dtbKho;
            //lookupEdit_Kho_View.Properties.DataSource = dtbKho;
            //lookupEdit_Kho_View.EditValue = -1;

            lookUpEditKhuvuc_View.Properties.DataSource = objMasterService.Ware_Dm_Cuahang_Ban_Select_Sale().ToDataSet().Tables[0];
        }

        void Load_Gridview()
        {
            //neu chon khu vuc cua hang ban
            //object id_nhansu = (Convert.ToInt64(lookUpEdit_Nhansu_Banhang_View.EditValue) == -1) ? null : lookUpEdit_Nhansu_Banhang_View.EditValue;
            //object id_khvuc = (Convert.ToInt64(lookUpEditMa_Cuahang_Ban.GetColumnValue("Id_Cuahang_Ban")) == -1) ? null : lookUpEditMa_Cuahang_Ban.GetColumnValue("Id_Cuahang_Ban");
            //if ("" + lookUpEditMa_Cuahang_Ban.GetColumnValue("Id_Cuahang_Ban") != "" && "" + dtNgay_Chungtu_View.EditValue != "")
            ds_Hdbanhang = objWareService.Get_All_Ware_Hdbanhang_Novat_Hhban_Edit(lookUpEditMa_Cuahang_Ban.GetColumnValue("Id_Cuahang_Ban"), dtNgay_Chungtu_View.EditValue, lookUpEdit_Nhansu_Banhang_View.EditValue).ToDataSet();
            if (ds_Hdbanhang.Tables.Count == 0)
                return;
            dgware_Hdbanhang.DataSource = ds_Hdbanhang;
            dgware_Hdbanhang.DataMember = ds_Hdbanhang.Tables[0].TableName;

            //ds_Ware_Xuat_Hh_Ban = objWareService.Get_All_Ware_Xuat_Hh_Ban(dtNgay_Chungtu_View.DateTime, lookupEdit_Kho_View.EditValue).ToDataSet();
            //dgware_Xuat_Hanghoa_Ban.DataSource = ds_Ware_Xuat_Hh_Ban;
            //dgware_Xuat_Hanghoa_Ban.DataMember = ds_Ware_Xuat_Hh_Ban.Tables[0].TableName;

            this.ClearDataBindings();
            this.DataBindingControl();

            //ClearDataBindings_Xuatchuyen();
            //DataBindingControl_Xuatchuyen();
            if ("" + identity != "")
                gridView1.FocusedRowHandle = gridView1.LocateByValue(0, gridView1.Columns["Id_Hdbanhang"], identity);
            changeStatusButton(true);
            DisplayInfo2();
            gridView1.SetRowExpanded(-1, true);
            gridColumn_Delete.Visible = false;
            lookUpEditMa_Cuahang_Ban.DataBindings.Clear();
        }

        public override void DisplayInfo()
        {
            try
            {
                //Set lại trạng thái form là view
                FormState = GoobizFrame.Windows.Forms.FormState.View;
                checkEdit_Congno.Checked = false;
                LoadMasterData();
                Load_Gridview();
                this.ChangeStatus(false);
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#endif
                // GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }
        }

        void DisplayInfo2()
        {
            try
            {
                if ("" + gridView1.GetFocusedRowCellValue("Id_Hdbanhang") == "")
                {
                    ds_Hdbanhang_Chitiet = new DataSet();
                    this.dgware_Hdbanhang_Chitiet.DataSource = null;
                    identity = null;
                    btnLuu_Chapnhan.Enabled = false;
                    return;
                }
                else
                {
                    identity = gridView1.GetFocusedRowCellValue("Id_Hdbanhang");
                    this.ds_Hdbanhang_Chitiet = objWareService.Get_All_Ware_Hdbanhang_Chitiet_By_Hdbanhang(identity).ToDataSet();
                    //allow print when have data
                    this.ds_Hdbanhang_Chitiet_Log = objWareService.Get_All_Ware_Hdbanhang_Chitiet_Log_ByHdbanhang(identity).ToDataSet();
                    SetDataSource_Hdbanhang_Chitiet();
                    if (Convert.ToInt64(gridView1.GetFocusedRowCellValue("Doc_Process_Status")) == 2)
                        btnLuu_Chapnhan.Enabled = false;
                    else
                        btnLuu_Chapnhan.Enabled = true;
                }
                //ChangeStatus(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void SetDataSource_Hdbanhang_Chitiet()
        {
            this.dgware_Hdbanhang_Chitiet.DataSource = null;
            if (ds_Hdbanhang_Chitiet_Log.Tables.Count == 0)
                return;
            //if (chkViewLog.Checked)
            //{
            //    this.dgware_Hdbanhang_Chitiet.DataSource = ds_Hdbanhang_Chitiet_Log;
            //    this.dgware_Hdbanhang_Chitiet.DataMember = ds_Hdbanhang_Chitiet_Log.Tables[0].TableName;
            //    gridColumn6.Visible = true;
            //    gridColumn7.Visible = true;
            //    gridColumn8.Visible = true;
            //}
            //else
            //{
            //    gridColumn6.Visible = false;
            //    gridColumn7.Visible = false;
            //    gridColumn8.Visible = false;
            //}
            dgware_Hdbanhang_Chitiet.DataSource = ds_Hdbanhang_Chitiet.Tables[0];
            gridView4.BestFitColumns();
            txtTongtien.EditValue = Convert.ToDecimal(gridView4.Columns["Thanhtien"].SummaryItem.SummaryValue) - Convert.ToDecimal("0" + txtHotro.EditValue);
        }

        private void refresh_Tick(object sender, EventArgs e)
        {
            //Load_Gridview();
        }

        #endregion

        #region process binding, status, resettext

        public override void ClearDataBindings()
        {
            this.txtSochungtu.DataBindings.Clear();
            this.txtGhichu_Edit.DataBindings.Clear();
            this.lookUpEdit_Nhansu_Banhang.DataBindings.Clear();
            lookUpEdit_Khachhang.DataBindings.Clear();
            txtGhichu.DataBindings.Clear();
            dtNgaygiao.DataBindings.Clear();
            lookUpEditKhuvuc_View.DataBindings.Clear();
            dtNgaythu_Tien.DataBindings.Clear();
            dtNgaytao.DataBindings.Clear();
            checkEdit_Congno.DataBindings.Clear();
            chkChiphi.DataBindings.Clear();
            chk_Dinhluong.DataBindings.Clear();
            txtHotro.DataBindings.Clear();
            txtCongno.DataBindings.Clear();
            txtLoai_Congno.DataBindings.Clear();
        }

        //public void ClearDataBindings_Xuatchuyen()
        //{
        //    txtSochungtu2.DataBindings.Clear();
        //    dtNgay_Chungtu_Xuat2.DataBindings.Clear();
        //    lookUpEdit_Cuahang_Ban_Nhap2.DataBindings.Clear();
        //    lookUpEdit_Cuahang_Ban_Xuat2.DataBindings.Clear();
        //    lookUpEdit_Nhansu_Nhap2.DataBindings.Clear();
        //    lookUpEdit_Nhansu_Xuat2.DataBindings.Clear();
        //    txtGhichu2.DataBindings.Clear();
        //}

        //private void DataBindingControl_Xuatchuyen()
        //{
        //    txtSochungtu2.DataBindings.Add("EditValue", ds_Ware_Xuat_Hh_Ban, ds_Ware_Xuat_Hh_Ban.Tables[0].TableName + ".Sochungtu");
        //    dtNgay_Chungtu_Xuat2.DataBindings.Add("EditValue", ds_Ware_Xuat_Hh_Ban, ds_Ware_Xuat_Hh_Ban.Tables[0].TableName + ".Ngay_Chungtu_Xuat");
        //    lookUpEdit_Cuahang_Ban_Nhap2.DataBindings.Add("EditValue", ds_Ware_Xuat_Hh_Ban, ds_Ware_Xuat_Hh_Ban.Tables[0].TableName + ".Id_Cuahang_Ban_Nhap");
        //    lookUpEdit_Cuahang_Ban_Xuat2.DataBindings.Add("EditValue", ds_Ware_Xuat_Hh_Ban, ds_Ware_Xuat_Hh_Ban.Tables[0].TableName + ".Id_Cuahang_Ban_Xuat");
        //    lookUpEdit_Nhansu_Nhap2.DataBindings.Add("EditValue", ds_Ware_Xuat_Hh_Ban, ds_Ware_Xuat_Hh_Ban.Tables[0].TableName + ".Id_Nhansu_Nhap");
        //    lookUpEdit_Nhansu_Xuat2.DataBindings.Add("EditValue", ds_Ware_Xuat_Hh_Ban, ds_Ware_Xuat_Hh_Ban.Tables[0].TableName + ".Id_Nhansu_Xuat");
        //    txtGhichu2.DataBindings.Add("EditValue", ds_Ware_Xuat_Hh_Ban, ds_Ware_Xuat_Hh_Ban.Tables[0].TableName + ".Ghichu");
        //}

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtSochungtu.DataBindings.Add("EditValue", ds_Hdbanhang, ds_Hdbanhang.Tables[0].TableName + ".Sochungtu");
                this.lookUpEdit_Nhansu_Banhang.DataBindings.Add("EditValue", ds_Hdbanhang, ds_Hdbanhang.Tables[0].TableName + ".Id_Nhansu_Bh");
                lookUpEdit_Khachhang.DataBindings.Add("EditValue", ds_Hdbanhang, ds_Hdbanhang.Tables[0].TableName + ".Id_Khachhang");
                txtGhichu_Edit.DataBindings.Add("EditValue", ds_Hdbanhang, ds_Hdbanhang.Tables[0].TableName + ".Ghichu_Edit");
                txtGhichu.DataBindings.Add("EditValue", ds_Hdbanhang, ds_Hdbanhang.Tables[0].TableName + ".Ghichu");
                dtNgaygiao.DataBindings.Add("EditValue", ds_Hdbanhang, ds_Hdbanhang.Tables[0].TableName + ".Ngay_Thanhtoan");
                lookUpEditKhuvuc_View.DataBindings.Add("EditValue", ds_Hdbanhang, ds_Hdbanhang.Tables[0].TableName + ".Id_Cuahang_Ban");
                dtNgaythu_Tien.DataBindings.Add("EditValue", ds_Hdbanhang, ds_Hdbanhang.Tables[0].TableName + ".Ngay_Thutien");
                dtNgaytao.DataBindings.Add("EditValue", ds_Hdbanhang, ds_Hdbanhang.Tables[0].TableName + ".Ngay_Chungtu");
                checkEdit_Congno.DataBindings.Add("EditValue", ds_Hdbanhang, ds_Hdbanhang.Tables[0].TableName + ".Congno");
                chkChiphi.DataBindings.Add("EditValue", ds_Hdbanhang, ds_Hdbanhang.Tables[0].TableName + ".Tinh_Chiphi");
                chk_Dinhluong.DataBindings.Add("EditValue", ds_Hdbanhang, ds_Hdbanhang.Tables[0].TableName + ".Tinh_Dinhluong");
                txtHotro.DataBindings.Add("EditValue", ds_Hdbanhang, ds_Hdbanhang.Tables[0].TableName + ".Chiphi_Vanchuyen");
                txtCongno.DataBindings.Add("EditValue", ds_Hdbanhang, ds_Hdbanhang.Tables[0].TableName + ".Sotien_Congno");
                txtLoai_Congno.DataBindings.Add("EditValue", ds_Hdbanhang, ds_Hdbanhang.Tables[0].TableName + ".Congno_Thang");
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                // GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }
        }

        public override void ChangeStatus(bool editTable)
        {
            this.xtraTabControl_View.Enabled = !editTable;
            gridView4.OptionsBehavior.Editable = editTable;
            //gvware_Xuat_Hanghoa_Ban_Chitiet.OptionsBehavior.Editable = editTable;
            checkEdit_Congno.Properties.ReadOnly = !editTable;
            this.txtGhichu_Edit.Properties.ReadOnly = !editTable;
            dtNgaythu_Tien.Properties.ReadOnly = !editTable;
            dtNgaygiao.Properties.ReadOnly = !editTable;
            this.lookUpEditMa_Cuahang_Ban.Properties.ReadOnly = editTable;
            txtMa_Khachhang.Properties.ReadOnly = !editTable;
            btnCash.Enabled = !editTable;
            panelControl4.Enabled = !editTable;
            chkChiphi.Properties.ReadOnly = !editTable;
            chk_Dinhluong.Properties.ReadOnly = !editTable;
            txtHotro.Properties.ReadOnly = !editTable;
        }

        void changeStatusButton(bool boo)
        {
            btnEdit.Enabled = (boo) ? EnableEdit : false;
            //btnCash.Enabled = (boo) ? EnablePrintPreview : false;
            btnCash.Enabled = (FormState == GoobizFrame.Windows.Forms.FormState.View) ? EnablePrintPreview : false;
            btnClose.Enabled = boo;
            btnLuu.Enabled = !boo;
            btnLuu_Chapnhan.Enabled = !boo;
            btnKhong_Chapnhan.Enabled = !boo;
            btnCancel.Enabled = !boo;
            btnChapnhan.Enabled = (boo) ? EnableEdit : false;
            refresh.Enabled = boo;
        }

        public override void ResetText()
        {
            txtLoai_Congno.EditValue = null;
            checkEdit_Congno.Checked = false;
            this.txtSochungtu.EditValue = null;
            this.txtGhichu_Edit.EditValue = null;
            txtMa_Khachhang.EditValue = null;
            lookUpEditKhuvuc_View.EditValue = null;
            lookUpEdit_Khachhang.EditValue = DBNull.Value;
            dtNgaythu_Tien.EditValue = null;
            dtNgaytao.EditValue = null;
            chkChiphi.EditValue = null;
            chk_Dinhluong.EditValue = null;
            txtHotro.EditValue = null;
            txtCongno.EditValue = null;
            this.ds_Hdbanhang_Chitiet = objWareService.Get_All_Ware_Hdbanhang_Chitiet_By_Hdbanhang(0).ToDataSet();
            this.dgware_Hdbanhang_Chitiet.DataSource = ds_Hdbanhang_Chitiet.Tables[0];
        }

        #endregion

        #region Event Override

        public object InsertObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Hdbanhang objWare_Hdbanhang = new Ecm.WebReferences.WareService.Ware_Hdbanhang();
                objWare_Hdbanhang.Id_Hdbanhang = -1;
                objWare_Hdbanhang.Sochungtu = txtSochungtu.EditValue;
                //objWare_Hdbanhang.Sotien = txtSotien.EditValue;
                //objWare_Hdbanhang.Sotien_Vat = txtSotien_Vat.EditValue;
                //objWare_Hdbanhang.Ngay_Chungtu = dtNgay_Chungtu.EditValue;
                objWare_Hdbanhang.NoVAT = true;

                if ("" + lookUpEditMa_Cuahang_Ban.GetColumnValue("Id_Cuahang_Ban") != "")
                    objWare_Hdbanhang.Id_Cuahang_Ban = lookUpEditMa_Cuahang_Ban.GetColumnValue("Id_Cuahang_Ban");

                if ("" + lookUpEdit_Nhansu_Banhang.EditValue != "")
                    objWare_Hdbanhang.Id_Nhansu_Bh = lookUpEdit_Nhansu_Banhang.EditValue;

                objWare_Hdbanhang.Id_Khachang = ("" + lookUpEdit_Khachhang.EditValue != "") ? lookUpEdit_Khachhang.EditValue : -1;
                identity = objWareService.Insert_Ware_Hdbanhang(objWare_Hdbanhang);

                if (identity != null)
                {
                    this.DoClickEndEdit(dgware_Hdbanhang_Chitiet); //dgware_Hdbanhang_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                    foreach (DataRow dr in ds_Hdbanhang_Chitiet.Tables[0].Rows)
                    {
                        dr["Id_Hdbanhang"] = identity;
                    }
                    objWareService.Update_Ware_Hdbanhang_Chitiet_Collection(ds_Hdbanhang_Chitiet);
                    objWareService.Update_Ware_Hdbanhang_Chitiet_Log_Collection(ds_Hdbanhang_Chitiet_Log);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public object UpdateObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Hdbanhang objWare_Hdbanhang = new Ecm.WebReferences.WareService.Ware_Hdbanhang();
                objWare_Hdbanhang.Id_Hdbanhang = gridView1.GetFocusedRowCellValue("Id_Hdbanhang");
                objWare_Hdbanhang.Sochungtu = gridView1.GetFocusedRowCellValue("Sochungtu");
                objWare_Hdbanhang.Sotien = gridView1.GetFocusedRowCellValue("Sotien");
                objWare_Hdbanhang.Sotien_Vat = gridView1.GetFocusedRowCellValue("Sotien_Vat");
                objWare_Hdbanhang.Ngay_Chungtu = gridView1.GetFocusedRowCellValue("Ngay_Chungtu");
                objWare_Hdbanhang.Hoten_Nguoimua = "";
                objWare_Hdbanhang.Per_Vat = 0;
                objWare_Hdbanhang.Phuongthuc_Thanhtoan = "TM";
                objWare_Hdbanhang.So_Seri = "N/A";
                objWare_Hdbanhang.Ngay_Thanhtoan = gridView1.GetFocusedRowCellValue("Ngay_Chungtu");
                objWare_Hdbanhang.NoVAT = true;
                if ("" + lookUpEdit_Nhansu_Banhang.EditValue != "")
                    objWare_Hdbanhang.Id_Nhansu_Bh = lookUpEdit_Nhansu_Banhang.EditValue;
                objWare_Hdbanhang.Ghichu = "" + txtGhichu.EditValue;
                objWare_Hdbanhang.Id_Khachang = ("" + lookUpEdit_Khachhang.EditValue != "") ? lookUpEdit_Khachhang.EditValue : -1;
                objWare_Hdbanhang.Id_Nhansu_Edit = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu();

                objWare_Hdbanhang.Id_Nhansu_Km = -1;
                objWare_Hdbanhang.Ghichu_Edit = "" + txtGhichu_Edit.EditValue;
                objWare_Hdbanhang.Doc_Process_Status = 2;
                //update donmuahang
                objWareService.Update_Ware_Hdbanhang(objWare_Hdbanhang);

                //update donmuahang_chitiet
                this.DoClickEndEdit(dgware_Hdbanhang_Chitiet); //dgware_Hdbanhang_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                foreach (DataRow dr in ds_Hdbanhang_Chitiet.Tables[0].Rows)
                {
                    if (dr.RowState == DataRowState.Added)
                        dr["Id_Hdbanhang"] = gridView1.GetFocusedRowCellValue("Id_Hdbanhang");
                }
                //ds_Hdbanhang_Chitiet.RejectChanges();
                //neu sua row
                //save row trong Ware_Hdbanhang_Chitiet_Log
                if (ds_Hdbanhang_Chitiet.HasChanges(DataRowState.Modified))
                {
                    DataTable dt_Modified = ds_Hdbanhang_Chitiet.Tables[0].GetChanges(DataRowState.Modified).Copy();
                    dt_Modified.RejectChanges();
                    foreach (DataRow dr_Modified in dt_Modified.Rows)
                    {
                        DataRow ndr_Log = ds_Hdbanhang_Chitiet_Log.Tables[0].NewRow();
                        foreach (DataColumn col in dt_Modified.Columns)
                            try
                            {
                                ndr_Log[col.ColumnName] = dr_Modified[col.ColumnName];
                            }
                            catch (Exception ex) { ex.ToString(); continue; }
                        ndr_Log["RowState"] = DataRowState.Modified.ToString();
                        ndr_Log["Id_Nhansu"] = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu(); //nhan su sua row
                        ndr_Log["Ngay_Hieuchinh"] = objWareService.GetServerDateTime();
                        ds_Hdbanhang_Chitiet_Log.Tables[0].Rows.Add(ndr_Log);
                    }
                }

                foreach (DataRow dr_Modified in ds_Hdbanhang_Chitiet.Tables[0].Rows)
                {
                    DataRow ndr_Log = ds_Hdbanhang_Chitiet_Log.Tables[0].NewRow();
                    foreach (DataColumn col in ds_Hdbanhang_Chitiet.Tables[0].Columns)
                        try
                        {
                            ndr_Log[col.ColumnName] = dr_Modified[col.ColumnName];
                        }
                        catch (Exception ex) { ex.ToString(); continue; }
                    ndr_Log["RowState"] = DataRowState.Added.ToString();
                    ndr_Log["Id_Nhansu"] = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu(); //nhan su sua row
                    ndr_Log["Ngay_Hieuchinh"] = objWareService.GetServerDateTime();
                    ds_Hdbanhang_Chitiet_Log.Tables[0].Rows.Add(ndr_Log);
                }
                objWareService.Update_Ware_Hdbanhang_Chitiet_Collection(ds_Hdbanhang_Chitiet);
                objWareService.Update_Ware_Hdbanhang_Chitiet_Log_Collection(ds_Hdbanhang_Chitiet_Log);
                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("TASK_OUTOFDATE") != -1)
                    GoobizFrame.Windows.Forms.UserMessage.Show("TASK_OUTOFDATE", new string[] { });
                else
                    MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.WareService.Ware_Hdbanhang objWare_Hdbanhang = new Ecm.WebReferences.WareService.Ware_Hdbanhang();
            return objWareService.Delete_Ware_Hdbanhang(objWare_Hdbanhang);
        }

        public override bool PerformEdit()
        {
            //if (! GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + lookUpEdit_Nhansu_Banhang.EditValue))
            //if ( GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUser().ToUpper() != "ADMIN")
            if (!EnableEdit)
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                return false;
            }
            this.ChangeStatus(true);
            //ds_Hanghoa_Ban_after_Thongke = objWareService.Get_All_Ware_Dm_Hanghoa_Ban_Dinhgia_After_Thongke(lookUpEditMa_Cuahang_Ban.GetColumnValue("Id_Cuahang_Ban")).ToDataSet();
            this.lookUpEditMa_Cuahang_Ban.DataBindings.Clear();
            this.lookUpEditMa_Cuahang_Ban.DataBindings.Add("EditValue", ds_Hdbanhang, ds_Hdbanhang.Tables[0].TableName + ".Id_Cuahang_Ban");
            gridColumn_Delete.Visible = true;
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
                DoClickEndEdit(dgware_Hdbanhang_Chitiet);
                foreach (DataRow dtr in ds_Hdbanhang_Chitiet.Tables[0].Rows)
                {
                    if (dtr.RowState != DataRowState.Deleted)
                        if (!check_soluong_ton(dtr["Id_Hanghoa_Ban"], dtr["Id_Donvitinh"], dtr["Soluong"]))
                            return false;
                }

                System.Collections.Hashtable htbControl1 = new System.Collections.Hashtable();
                htbControl1.Add(txtSochungtu, lblSochungtu.Text);
                htbControl1.Add(lookUpEdit_Nhansu_Banhang, lblNhansu_Banhang.Text);
                htbControl1.Add(txtGhichu_Edit, lblGhichu_Edit.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(htbControl1))
                    return false;

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
                    this.DisplayInfo();
                    DisplayInfo2();
                }
                return success;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
            DataRow[] sdr = ds_Hdbanhang.Tables[0].Select("Id_Hdbanhang = " + identity);

            DataSets.dsHdbanhang_Chitiet dsrHdbanhang_Chitiet = new Ecm.Ware.DataSets.dsHdbanhang_Chitiet();
            Reports.rptHdbanhang_noVAT rptHdbanhang_noVAT = new Ecm.Ware.Reports.rptHdbanhang_noVAT();
            GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            frmPrintPreview.Report = rptHdbanhang_noVAT;
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
                } drnew["Ten_Hanghoa"] = dr["Ten_Hanghoa_Ban"];
                drnew["Ma_Hanghoa"] = dr["Ma_Hanghoa_Ban"];
                drnew["Stt"] = i++;
                dsrHdbanhang_Chitiet.Tables[0].Rows.Add(drnew);
            }
            //add parameter values
            rptHdbanhang_noVAT.xrLbl_Tieude.Text = "HÓA ĐƠN KHÁCH HÀNG";
            rptHdbanhang_noVAT.tbc_Ngay.Text = "" + string.Format("{0:dd/MM/yyyy hh:mm:ss tt}", sdr[0]["Ngay_Chungtu"]);
            rptHdbanhang_noVAT.lblNhansu_Bill.Text = lookUpEdit_Nhansu_Banhang.Text;
            rptHdbanhang_noVAT.lblKhachhang.Text = lookUpEdit_Khachhang.Text;
            rptHdbanhang_noVAT.tbcSochungtu.Text = txtSochungtu.Text;

            double thanhtien = Convert.ToDouble(gridView4.Columns["Thanhtien"].SummaryItem.SummaryValue);
            for (int x = 0; x < dsrHdbanhang_Chitiet.Tables[0].Rows.Count; x++)
            {
                if (dsrHdbanhang_Chitiet.Tables[0].Rows[x]["Thanhtien_Km"] == null || dsrHdbanhang_Chitiet.Tables[0].Rows[x]["Thanhtien_Km"].ToString() == "")
                {
                    dsrHdbanhang_Chitiet.Tables[0].Rows[x]["Thanhtien_Km"] = 0;
                }
            }
            thanhtien -= Convert.ToDouble(dsrHdbanhang_Chitiet.Tables[0].Compute("Sum(Thanhtien_Km)", ""));
            string str = GoobizFrame.Windows.HelperClasses.ReadNumber.ChangeNum2VNStr(thanhtien, " đồng.");
            str = str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower();

            rptHdbanhang_noVAT.tbcThanhtien_Bangchu.Text = str;
            rptHdbanhang_noVAT.PageSize = new Size(800, 2000 + 120 * Convert.ToInt32(dsrHdbanhang_Chitiet.Tables[0].Rows.Count));
            rptHdbanhang_noVAT.xrTable6.Location = new System.Drawing.Point(21, 42);
            rptHdbanhang_noVAT.xrTable4.Location = new System.Drawing.Point(21, 135);

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
            return base.PerformPrintPreview();
        }
        #endregion

        #region process gridviews

        private bool check_soluong_ton(object id_hanghoa_ban, object id_donvitinh, object soluong)
        {
            //DataRow[] dtr = ds_Hanghoa_Ban_after_Thongke.Tables[0].Select("Id_Hanghoa_Ban = " + id_hanghoa_ban + " and Id_Donvitinh = " + id_donvitinh);
            //if (dtr.Length > 0)
            //{
            //    if (Convert.ToDecimal(dtr[0]["Soluong_Ton"]) < Convert.ToDecimal(soluong))
            //    {
            //        GoobizFrame.Windows.Forms.MessageDialog.Show("Không đủ số lượng xuất");
            //        return false;
            //    }
            //    else
            return true;
            //}
            //else
            //{
            //    GoobizFrame.Windows.Forms.MessageDialog.Show("Hàng hóa và đơn vị tính này chưa được định giá hoặc không đủ số lượng xuất");
            //    return false;
            //}
        }

        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.DoClickEndEdit(dgware_Hdbanhang_Chitiet);
            object id_khuvuc = lookUpEditKhuvuc_View.EditValue;
            if (e.Column.FieldName == "Soluong" || e.Column.FieldName == "Dongia_Ban" || e.Column.FieldName == "Per_Dongia")
            {
                if ("" + gridView4.GetFocusedRowCellValue("Id_Hanghoa_Ban") == "")
                    return;
                //if (!check_soluong_ton(gridView4.GetFocusedRowCellValue("Id_Hanghoa_Ban")
                //                        , gridView4.GetFocusedRowCellValue("Id_Donvitinh")
                //                        , gridView4.GetFocusedRowCellValue("Soluong")))
                //{
                //    gridView4.CancelUpdateCurrentRow();
                //    return;
                //}
                decimal soluong = Convert.ToDecimal("0" + gridView4.GetFocusedRowCellValue("Soluong"));
                decimal Per_Dongia = Convert.ToDecimal("0" + gridView4.GetFocusedRowCellValue("Per_Dongia"));

                gridView4.SetFocusedRowCellValue(gridView4.Columns["Thanhtien"],
                                   soluong * Convert.ToDecimal("0" + gridView4.GetFocusedRowCellValue("Dongia_Ban")) * (1 - Per_Dongia / 100));
            }
            if (e.Column.FieldName == "Id_Hanghoa_Ban")
            {
                if ("" + gridView4.GetFocusedRowCellValue("Id_Hanghoa_Ban") == "")
                    return;
                gridView4.SetFocusedRowCellValue(gridView4.Columns["Dongia_Ban"], 0);
                DataSet dsDinhgia_ById_Hanghoa = objWareService.Get_All_Ware_Hanghoa_Dinhgia_By_Id_HhBan(gridView4.GetFocusedRowCellValue("Id_Hanghoa_Ban")).ToDataSet();
                DataRow[] row = dsDinhgia_ById_Hanghoa.Tables[0].Select();
                if (row != null && row.Length > 0)
                {
                    gridView4.SetFocusedRowCellValue(gridView4.Columns["Id_Donvitinh"], row[0]["Id_Donvitinh"]);
                    DataSet dsHanghoa_Dinhgia_Khuvuc = objWareService.Get_All_Ware_Hanghoa_Dinhgia_Khuvuc(row[0]["Id_Hanghoa_Dinhgia"]).ToDataSet();
                    if (dsHanghoa_Dinhgia_Khuvuc.Tables[0].Rows.Count > 0 && id_khuvuc != null && id_khuvuc + "" != "")
                    {
                        DataRow[] dtr_gia_KV = dsHanghoa_Dinhgia_Khuvuc.Tables[0].Select("Id_Khuvuc = " + id_khuvuc);
                        if (dtr_gia_KV != null && dtr_gia_KV.Length > 0)
                            gridView4.SetFocusedRowCellValue(gridView4.Columns["Dongia_Ban"], dtr_gia_KV[0]["Dongia_Ban"]);
                    }
                    else
                    {
                        //DataRow[] dtr = ds_Hanghoa_Ban_after_Thongke.Tables[0].Select("Id_Hanghoa_Ban = " + gridView4.GetFocusedRowCellValue("Id_Hanghoa_Ban"));
                        //if (dtr == null || dtr.Length == 0)
                        //{
                        //    //lblStatus_Bar.Text = "Hàng hóa chưa được định giá";
                        //    gridView4.CancelUpdateCurrentRow();
                        //    return;
                        //}                        
                        gridView4.SetFocusedRowCellValue(gridView4.Columns["Dongia_Ban"], row[0]["Dongia_Banle"]);
                    }
                }
            }
            txtTongtien.EditValue = Convert.ToDecimal(gridView4.Columns["Thanhtien"].SummaryItem.SummaryValue) - Convert.ToDecimal("0" + txtHotro.EditValue);
        }

        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            this.DisplayInfo2();
        }

        private void gridView4_RowCountChanged(object sender, EventArgs e)
        {
            this.DoClickEndEdit(dgware_Hdbanhang_Chitiet); //dgware_Hdbanhang_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();          
        }

        private void dgware_Hdbanhang_Chitiet_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            //neu xoa row
            //save row vao Ware_Hdbanhang_Chitiet_Log
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove
                && GoobizFrame.Windows.Forms.UserMessage.Show("Msg00021", new string[] { "" }) == DialogResult.Yes)
            {
                DataRow ndr_Log = ds_Hdbanhang_Chitiet_Log.Tables[0].NewRow();
                DataRow fdr = gridView4.GetDataRow(gridView4.FocusedRowHandle);
                foreach (DataColumn col in fdr.Table.Columns)
                    ndr_Log[col.ColumnName] = fdr[col.ColumnName];
                ndr_Log["RowState"] = DataRowState.Deleted.ToString();
                ndr_Log["Id_Nhansu"] = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu(); //nhan su xoa row
                ndr_Log["Ngay_Hieuchinh"] = objWareService.GetServerDateTime();

                ds_Hdbanhang_Chitiet_Log.Tables[0].Rows.Add(ndr_Log);
            }
            else
                e.Handled = true;
        }

        private void gridLookUpEdit_Hanghoa_Ban_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                try
                {
                    Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Ban_Dialog Frmware_Dm_Hanghoa_Ban_Dialog = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Ban_Dialog();
                    Frmware_Dm_Hanghoa_Ban_Dialog.Text = "" + gridColumn21.Caption;
                    GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(Frmware_Dm_Hanghoa_Ban_Dialog);
                    Frmware_Dm_Hanghoa_Ban_Dialog.Id_Cuahang_Ban = lookUpEditMa_Cuahang_Ban.GetColumnValue("Id_Cuahang_Ban");
                    Frmware_Dm_Hanghoa_Ban_Dialog.Ngay_Chungtu = dtNgay_Chungtu_View.EditValue;
                    Frmware_Dm_Hanghoa_Ban_Dialog.ShowDialog();
                    if (Frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows.Length > 0)
                    {
                        gridView4.SetFocusedRowCellValue(gridView4.Columns["Id_Hanghoa_Ban"]
                            , Frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[0]["Id_Hanghoa_Ban"]);
                    }
                }
                catch { }
            }
        }

        #endregion

        #region process controls, buttons

        private void btnCash_Click(object sender, EventArgs e)
        {
            if (xtraTabControl_View.SelectedTabPage.Name == "xtraTabPage_Hoadon_View")
            {
                if (identity == null)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Bạn chưa chọn hóa đơn");
                    return;
                }
                thanhtien = Convert.ToDouble(gridView4.Columns["Thanhtien"].SummaryItem.SummaryValue);
                //PerformSave();
                this.ds_Hdbanhang_Chitiet = objWareService.Get_All_Ware_Hdbanhang_Chitiet_By_Hdbanhang(identity).ToDataSet();
                PerformPrintPreview();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PerformPrintPreview();
        }

        private void txtMa_Khachhang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtMa_Khachhang.Text != "")
                {
                    try
                    {
                        //DataTable dt = (DataTable)lookUpEdit_Khachhang.Properties.DataSource;
                        //lookUpEdit_Khachhang.EditValue = dt.Select("Ma_Khachhang = '" + txtMa_Khachhang.Text + "'")[0]["Id_Khachhang"];
                        //DataSet dsKhachhang_Vip = objWareService.Get_All_Ware_Khachhang_Vip_Detail_By_Khachhang(lookUpEdit_Khachhang.EditValue).ToDataSet();
                        //if (dsKhachhang_Vip != null && dsKhachhang_Vip.Tables.Count > 0)
                        //{
                        //    DataRow[] sdr = dsKhachhang_Vip.Tables[0].Select("Id_Cuahang_Ban=" + lookUpEditMa_Cuahang_Ban.GetColumnValue("Id_Cuahang_Ban"));
                        //    if (sdr != null && sdr.Length > 0)
                        //    {
                        //        vip_per_dongia = Convert.ToDecimal(sdr[0]["Per_Hoadon"]);
                        //    }
                        //}
                    }
                    catch (Exception ex)
                    {
                        GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message);
                        txtMa_Khachhang.SelectAll();
                        txtMa_Khachhang.Focus();
                        lookUpEdit_Khachhang.EditValue = DBNull.Value;
                    }
                }
            }
        }

        private void lookUpEdit_Khachhang_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (FormState == GoobizFrame.Windows.Forms.FormState.View && "" + lookUpEdit_Khachhang.EditValue != "")
                {
                    txtMa_Khachhang.Text = "" + ((DataRowView)lookUpEdit_Khachhang.Properties.GetDataSourceRowByKeyValue(lookUpEdit_Khachhang.EditValue))["Ma_Khachhang"];
                    txtLoai_Congno.Text = "" + ((DataRowView)lookUpEdit_Khachhang.Properties.GetDataSourceRowByKeyValue(lookUpEdit_Khachhang.EditValue))["Congno_Thang"];
                }
            }
            catch { txtMa_Khachhang.Text = ""; }
        }

        private void lookUpEditMa_Kho_Hanghoa_EditValueChanged(object sender, EventArgs e)
        {
            DisplayInfo();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            this.lookUpEditMa_Kho_Hanghoa_EditValueChanged(sender, e);
        }

        private void chkViewLog_CheckedChanged(object sender, EventArgs e)
        {
            SetDataSource_Hdbanhang_Chitiet();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (xtraTabControl_View.SelectedTabPage.Name == "xtraTabPage_Hoadon_View")
            {
                //if (Convert.ToInt64(lookUpEditMa_Cuahang_Ban.GetColumnValue("Id_Cuahang_Ban")) == -1)
                //{
                //    GoobizFrame.Windows.Forms.MessageDialog.Show("Bạn chưa chọn Khu vực, vui lòng chọn lại");
                //    lookUpEditMa_Cuahang_Ban.Focus();
                //    return;
                //}
                identity = gridView1.GetFocusedRowCellValue("Id_Hdbanhang");
                if (identity == null)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Bạn chưa chọn hóa đơn");
                    return;
                }
                if (PerformEdit())
                    changeStatusButton(false);
            }
            //else
            //{
            //    //if (Convert.ToInt64(lookupEdit_Kho_View.EditValue) == -1)
            //    //{
            //    //    GoobizFrame.Windows.Forms.MessageDialog.Show("Bạn chưa chọn Kho, vui lòng chọn lại");
            //    //    lookupEdit_Kho_View.Focus();
            //    //    return;
            //    //}
            //    Id_Xuat_Hh_Ban = gvXuatchuyen.GetFocusedRowCellValue("Id_Xuat_Hh_Ban");
            //    if (Id_Xuat_Hh_Ban == null)
            //    {
            //        GoobizFrame.Windows.Forms.MessageDialog.Show("Bạn chưa chọn phiếu xuất chuyển");
            //        return;
            //    }
            //    if (PerformEdit())
            //        changeStatusButton(false);
            //}
        }

        //private void Chapnhan_Donhang()
        //{
        //    identity = gridView1.GetFocusedRowCellValue("Id_Hdbanhang");
        //    Ecm.WebReferences.WareService.Ware_Hdbanhang objWare_Hdbanhang = new Ecm.WebReferences.WareService.Ware_Hdbanhang();
        //    objWare_Hdbanhang.Id_Hdbanhang = identity;
        //    objWare_Hdbanhang.Sochungtu = gridView1.GetFocusedRowCellValue("Sochungtu");
        //    objWare_Hdbanhang.Sotien = gridView1.GetFocusedRowCellValue("Sotien");
        //    objWare_Hdbanhang.Sotien_Vat = gridView1.GetFocusedRowCellValue("Sotien_Vat");
        //    objWare_Hdbanhang.Ngay_Chungtu = gridView1.GetFocusedRowCellValue("Ngay_Chungtu");
        //    objWare_Hdbanhang.Ngay_Thutien = gridView1.GetFocusedRowCellValue("Ngay_Thutien");
        //    objWare_Hdbanhang.Hoten_Nguoimua = "";
        //    objWare_Hdbanhang.Per_Vat = 0;
        //    objWare_Hdbanhang.Phuongthuc_Thanhtoan = "TM";
        //    objWare_Hdbanhang.So_Seri = "N/A";
        //    objWare_Hdbanhang.Ngay_Thanhtoan = gridView1.GetFocusedRowCellValue("Ngay_Chungtu");

        //    objWare_Hdbanhang.NoVAT = true;
        //    objWare_Hdbanhang.Ghichu = "" + txtGhichu.EditValue;
        //    if ("" + lookUpEdit_Nhansu_Banhang.EditValue != "")
        //        objWare_Hdbanhang.Id_Nhansu_Bh = lookUpEdit_Nhansu_Banhang.EditValue;

        //    objWare_Hdbanhang.Id_Khachang = ("" + lookUpEdit_Khachhang.EditValue != "") ? lookUpEdit_Khachhang.EditValue : -1;
        //    objWare_Hdbanhang.Id_Nhansu_Edit = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu();

        //    objWare_Hdbanhang.Id_Nhansu_Km = -1;
        //    objWare_Hdbanhang.Ghichu_Edit = "" + txtGhichu_Edit.EditValue;
        //    objWare_Hdbanhang.Doc_Process_Status = 2;
        //    objWareService.Update_Ware_Hdbanhang(objWare_Hdbanhang);
        //}

        private void Chapnhan_Xuatchuyen()
        {
            //Id_Xuat_Hh_Ban = gvXuatchuyen.GetFocusedRowCellValue("Id_Xuat_Hh_Ban");
            //Ecm.WebReferences.WareService.Ware_Xuat_Hh_Ban objWare_Xuat_Hh_Ban = new Ecm.WebReferences.WareService.Ware_Xuat_Hh_Ban();
            //objWare_Xuat_Hh_Ban.Id_Xuat_Hh_Ban = Id_Xuat_Hh_Ban;
            //objWare_Xuat_Hh_Ban.Sochungtu = txtSochungtu2.EditValue;
            //objWare_Xuat_Hh_Ban.Ghichu = "" + txtGhichu2.EditValue;
            //objWare_Xuat_Hh_Ban.Ngay_Chungtu_Xuat = dtNgay_Chungtu_Xuat2.EditValue;

            //if ("" + lookUpEdit_Cuahang_Ban_Nhap2.EditValue != "")
            //    objWare_Xuat_Hh_Ban.Id_Cuahang_Ban_Nhap = lookUpEdit_Cuahang_Ban_Nhap2.EditValue;
            //if ("" + lookUpEdit_Cuahang_Ban_Xuat2.EditValue != "")
            //    objWare_Xuat_Hh_Ban.Id_Cuahang_Ban_Xuat = lookUpEdit_Cuahang_Ban_Xuat2.EditValue;

            //if ("" + lookUpEdit_Nhansu_Nhap2.EditValue != "")
            //    objWare_Xuat_Hh_Ban.Id_Nhansu_Nhap = lookUpEdit_Nhansu_Nhap2.EditValue;
            //if ("" + lookUpEdit_Nhansu_Xuat2.EditValue != "")
            //    objWare_Xuat_Hh_Ban.Id_Nhansu_Xuat = lookUpEdit_Nhansu_Xuat2.EditValue;
            //objWare_Xuat_Hh_Ban.Doc_Process_Status = 2;
            //objWareService.Update_Ware_Xuat_Hh_Ban(objWare_Xuat_Hh_Ban);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (xtraTabControl_View.SelectedTabPage.Name == "xtraTabPage_Hoadon_View")
            {
                if (identity == null)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Bạn chưa chọn hóa đơn");
                    return;
                }
                if (MessageBox.Show("Chấp nhận đơn hàng này?", "Confirm Dialog", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    update_donhang(2);
                    changeStatusButton(true);
                    Frmware_Xuat_Hh_Ban_Dialog frmXuatkho = new Frmware_Xuat_Hh_Ban_Dialog(identity);
                    frmXuatkho.ShowDialog();
                    DisplayInfo();
                }
            }
            else
            {
                //if (Id_Xuat_Hh_Ban == null)
                //{
                //    GoobizFrame.Windows.Forms.MessageDialog.Show("Bạn chưa chọn phiếu xuất chuyển");
                //    return;
                //}
                if (MessageBox.Show("Chấp nhận phiếu xuất chuyển này?", "Confirm Dialog", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Chapnhan_Xuatchuyen();
                    changeStatusButton(true);
                    //Frmware_Xuat_Hh_Ban_Dialog frmXuatkho = new Frmware_Xuat_Hh_Ban_Dialog(identity);
                    //frmXuatkho.ShowDialog();
                    DisplayInfo();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            PerformCancel();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        #endregion

        private void gridTextPer_Giamgia_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue.ToString() == "")
            {
                gridView4.SetFocusedRowCellValue("Per_Dongia", null);
                gridView4.SetFocusedRowCellValue("Thanhtien_Km", null);
                e.Cancel = true;
                return;
            }
            if (Convert.ToInt32(e.NewValue) > 100)
                e.Cancel = true;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            Load_Gridview();
        }

        private void xtraTabControl_View_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl_View.SelectedTabPage.Name == "xtraTabPage_Hoadon_View")
                xtraTabControl2.SelectedTabPage = xtraTabPage_Hoadon_Chitiet;
            //else
            //    xtraTabControl2.SelectedTabPage = xtraTabPage_Xuatchuyen_Chitiet;
        }

        private void xtraTabControl2_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl2.SelectedTabPage.Name == "xtraTabPage_Hoadon_Chitiet")
                xtraTabControl_View.SelectedTabPage = xtraTabPage_Hoadon_View;
            //else
            //    xtraTabControl_View.SelectedTabPage = xtraTabPage_Xuatchuyen_View;
        }

        private void gvXuatchuyen_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            ////ClearDataBindings_Xuatchuyen();
            //if (gvXuatchuyen.FocusedRowHandle >= 0)
            //{
            //    //DataBindingControl_Xuatchuyen();
            //    Id_Xuat_Hh_Ban = gvXuatchuyen.GetFocusedRowCellValue("Id_Xuat_Hh_Ban");
            //    ds_Ware_Xuat_Hh_Ban_Chitiet = objWareService.Get_All_Ware_Xuat_Hh_Ban_Chitiet_By_Xuat_Hh_Ban(Id_Xuat_Hh_Ban != null ? Id_Xuat_Hh_Ban : 0).ToDataSet();
            //    this.dgware_Xuat_Hanghoa_Ban_Chitiet.DataSource = ds_Ware_Xuat_Hh_Ban_Chitiet.Tables[0];
            //    gvware_Xuat_Hanghoa_Ban_Chitiet.BestFitColumns();
            //}
            //else
            //    ResetText();
        }

        private void gvware_Xuat_Hanghoa_Ban_Chitiet_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            //switch (e.Column.FieldName)
            //{
            //    case "Soluong":
            //    case "Dongia":
            //        decimal soluong = 0;
            //        decimal dongia = 0;
            //        decimal thanhtien = 0;
            //        decimal soluong_ton = this.Get_Soluong_Ton_Quydoi(
            //               gvware_Xuat_Hanghoa_Ban_Chitiet.GetFocusedRowCellValue("Id_Hanghoa_Ban"),
            //               gvware_Xuat_Hanghoa_Ban_Chitiet.GetFocusedRowCellValue("Id_Donvitinh"));
            //        soluong = Convert.ToDecimal("0" + gvware_Xuat_Hanghoa_Ban_Chitiet.GetFocusedRowCellValue("Soluong"));
            //        dongia = Convert.ToDecimal("0" + gvware_Xuat_Hanghoa_Ban_Chitiet.GetFocusedRowCellValue("Dongia"));
            //        if (soluong_ton < soluong)
            //        {
            //            GoobizFrame.Windows.Forms.MessageDialog.Show("Không đủ số lượng để xuất theo yêu cầu");
            //            gvware_Xuat_Hanghoa_Ban_Chitiet.SetFocusedRowCellValue(gvware_Xuat_Hanghoa_Ban_Chitiet.Columns["Soluong"], soluong_ton);
            //            return;
            //        }
            //        if ((thanhtien * dongia).ToString().Length > 16)
            //        {
            //            GoobizFrame.Windows.Forms.MessageDialog.Show("Giá trị thành tiền vượt quá khả năng lưu trữ.");
            //            gvware_Xuat_Hanghoa_Ban_Chitiet.SetFocusedRowCellValue(gvware_Xuat_Hanghoa_Ban_Chitiet.Columns["Dongia"], null);
            //            gvware_Xuat_Hanghoa_Ban_Chitiet.SetFocusedRowCellValue(gvware_Xuat_Hanghoa_Ban_Chitiet.Columns["Soluong"], null);
            //            return;
            //        }
            //        gvware_Xuat_Hanghoa_Ban_Chitiet.SetFocusedRowCellValue("Thanhtien", soluong * dongia);
            //        break;
            //    case "Thanhtien":
            //        gvware_Xuat_Hanghoa_Ban_Chitiet.UpdateTotalSummary();
            //        //txtSotien.Text = gvware_Xuat_Hanghoa_Ban_Chitiet.Columns["Thanhtien"].SummaryText;
            //        break;
            //}
        }

        public decimal Get_Soluong_Ton_Quydoi(object Id_Hanghoa_Ban, object Id_Donvitinh)
        {
            //try
            //{
            //    var _Id_Donvitinh = ds_Hanghoa_Ban.Tables[0].Select(string.Format("Id_Hanghoa_Ban={0}", Id_Hanghoa_Ban))[0]["Id_Donvitinh"];
            //    DataSet ds_hh_nxt = Get_Soluong_Ton_Quydoi(lookUpEdit_Cuahang_Ban_Xuat2.EditValue, Id_Hanghoa_Ban, Id_Donvitinh);
            //    decimal soluong_ton_quydoi = 0;
            //    soluong_ton_quydoi = ("" + Id_Donvitinh == "" + _Id_Donvitinh)
            //    ? Convert.ToDecimal("0" + ds_hh_nxt.Tables[0].Compute("sum(Soluong_Ton_Qdoi)",
            //            string.Format("Id_Hanghoa_Ban={0}", Id_Hanghoa_Ban)))
            //    : Convert.ToDecimal("0" + ds_hh_nxt.Tables[0].Compute("sum(Soluong_Ton)",
            //            string.Format("Id_Hanghoa_Ban={0} and Id_Donvitinh={1}", Id_Hanghoa_Ban, Id_Donvitinh)));
            //    return soluong_ton_quydoi;
            //}
            //catch (Exception ex)
            //{
            //    GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            return 0;
            //}
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (xtraTabControl_View.SelectedTabPage.Name == "xtraTabPage_Hoadon_View")
            {
                update_donhang(gridView1.GetFocusedRowCellValue("Doc_Process_Status"));
                this.DoClickEndEdit(dgware_Hdbanhang_Chitiet);
                foreach (DataRow dr in ds_Hdbanhang_Chitiet.Tables[0].Rows)
                {
                    if (dr.RowState == DataRowState.Added)
                        dr["Id_Hdbanhang"] = identity;
                }
                objWareService.Update_Ware_Hdbanhang_Chitiet_Collection(ds_Hdbanhang_Chitiet);
            }
            //else
            //{
            //    this.DoClickEndEdit(dgware_Xuat_Hanghoa_Ban);
            //    objWareService.Update_Ware_Xuat_Hh_Ban_Chitiet_Collection(ds_Ware_Xuat_Hh_Ban_Chitiet);
            //}
            DisplayInfo();
        }

        void update_donhang(object doc_process)
        {
            Ecm.WebReferences.WareService.Ware_Hdbanhang objWare_Hdbanhang = new Ecm.WebReferences.WareService.Ware_Hdbanhang();
            objWare_Hdbanhang.Id_Hdbanhang = gridView1.GetFocusedRowCellValue("Id_Hdbanhang");
            objWare_Hdbanhang.Sochungtu = gridView1.GetFocusedRowCellValue("Sochungtu");
            objWare_Hdbanhang.Sotien = txtTongtien.EditValue;
            objWare_Hdbanhang.Sotien_Vat = gridView1.GetFocusedRowCellValue("Sotien_Vat");
            objWare_Hdbanhang.Ngay_Chungtu = gridView1.GetFocusedRowCellValue("Ngay_Chungtu");
            objWare_Hdbanhang.Hoten_Nguoimua = "";
            objWare_Hdbanhang.Per_Vat = 0;
            objWare_Hdbanhang.Phuongthuc_Thanhtoan = "TM";
            objWare_Hdbanhang.So_Seri = "N/A";
            objWare_Hdbanhang.Ngay_Thanhtoan = dtNgaygiao.EditValue;
            objWare_Hdbanhang.Ngay_Thutien = dtNgaythu_Tien.EditValue;
            objWare_Hdbanhang.NoVAT = true;
            objWare_Hdbanhang.Id_Cuahang_Ban = lookUpEditKhuvuc_View.EditValue;
            objWare_Hdbanhang.Congno = checkEdit_Congno.Checked; // if checked --> không gửi mail công nợ
            if ("" + lookUpEdit_Nhansu_Banhang.EditValue != "")
                objWare_Hdbanhang.Id_Nhansu_Bh = lookUpEdit_Nhansu_Banhang.EditValue;
            objWare_Hdbanhang.Ghichu = "" + txtGhichu.EditValue;
            objWare_Hdbanhang.Id_Khachang = ("" + lookUpEdit_Khachhang.EditValue != "") ? lookUpEdit_Khachhang.EditValue : -1;
            objWare_Hdbanhang.Id_Nhansu_Edit = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu();
            objWare_Hdbanhang.Id_Nhansu_Km = -1;
            objWare_Hdbanhang.Ghichu_Edit = "" + txtGhichu_Edit.EditValue;
            objWare_Hdbanhang.Doc_Process_Status = doc_process; // 
            objWare_Hdbanhang.Tinh_Dinhluong = chk_Dinhluong.Checked;
            objWare_Hdbanhang.Tinh_Chiphi = chkChiphi.Checked;
            objWare_Hdbanhang.Sotien_Congno = Convert.ToDecimal("0" + txtCongno.EditValue);
            objWare_Hdbanhang.Chiphi_Vanchuyen = Convert.ToDecimal("0" + txtHotro.EditValue);
            objWareService.Update_Ware_Hdbanhang_New(objWare_Hdbanhang);
        }

        private void btnLuu_Chapnhan_Click(object sender, EventArgs e)
        {
            if (xtraTabControl_View.SelectedTabPage.Name == "xtraTabPage_Hoadon_View")
            {
                if (MessageBox.Show("Lưu và Chấp nhận đơn hàng này?", "Confirm Dialog", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //update_donhang(gridView1.GetFocusedRowCellValue("Doc_Process_Status"));
                    this.DoClickEndEdit(dgware_Hdbanhang_Chitiet);
                    objWareService.Update_Ware_Hdbanhang_Chitiet_Collection(ds_Hdbanhang_Chitiet);
                    update_donhang(2);
                    changeStatusButton(true);
                    object Id_Hdbanhang = gridView1.GetFocusedRowCellValue("Id_Hdbanhang");
                    Frmware_Xuat_Hh_Ban_Dialog frmXuatkho = new Frmware_Xuat_Hh_Ban_Dialog(identity);
                    frmXuatkho.ShowDialog();
                    if (frmXuatkho.Ok)
                        SendMail("Yêu cầu duyệt ");                    
                    DisplayInfo();
                    gridView1.SetFocusedRowCellValue("Id_Hdbanhang", Id_Hdbanhang);
                    //DisplayInfo2();
                }
            }
            //else
            //{
            //    if (MessageBox.Show("Lưu và Chấp nhận phiếu xuất chuyển này?", "Confirm Dialog", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    {
            //        this.DoClickEndEdit(dgware_Xuat_Hanghoa_Ban);
            //        objWareService.Update_Ware_Xuat_Hh_Ban_Chitiet_Collection(ds_Ware_Xuat_Hh_Ban_Chitiet);
            //        Chapnhan_Xuatchuyen();
            //        changeStatusButton(true);
            //        //Frmware_Xuat_Hh_Ban_Dialog frmXuatkho = new Frmware_Xuat_Hh_Ban_Dialog(identity);
            //        //frmXuatkho.ShowDialog();
            //        DisplayInfo();
            //    }
            //}
        }

        private void gridButton_Xoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
            {
                if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[] { "Hàng hóa " }) == DialogResult.Yes)
                {
                    try
                    {
                        ds_Hdbanhang_Chitiet.Tables[0].Rows[gridView4.FocusedRowHandle].Delete();
                        dgware_Hdbanhang_Chitiet.DataSource = ds_Hdbanhang_Chitiet;
                        dgware_Hdbanhang_Chitiet.DataMember = ds_Hdbanhang_Chitiet.Tables[0].TableName;
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }
            }
        }

        private void btnKhong_Chapnhan_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Không chấp nhận đơn hàng này?", "Confirm Dialog", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                update_donhang(0);
                SendMail("Không chấp nhận");
                DisplayInfo();
            }
        }

        private void SendMail(string trangthai)
        {
            try
            {
                // send mail
                //if (!System.IO.Directory.Exists("D:\\donhang"))
                //    System.IO.Directory.CreateDirectory("D:\\donhang");
                //gvHdbang_Chitiet.ExportToPdf("D:\\donhang\\" + txtSochungtu.Text + ".pdf");
                string emailTo = "";
                Ecm.WebReferences.RexService.Rex_Nhansu nhansu = objRexService.Get_Rex_Nhansu_ById(lookUpEdit_Nhansu_Banhang.EditValue);
                DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet();

                if (trangthai.Equals("Không chấp nhận"))
                    emailTo = "" + nhansu.Email;
                else
                {
                    //emailTo =  dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyEmail"))[0]["Heso"].ToString();
                    ds_Nhansu = objRexService.Rex_Nhansu_SelectMail().ToDataSet();
                    emailTo = ds_Nhansu.Tables[0].Select("Tenkhac = 'admin' ", "")[0]["Email"].ToString();
                }
                if ("" + emailTo == "")
                        return;

                string smtpAddress = dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "Mail_Server"))[0]["Heso"].ToString(); //"smtp.gmail.com"
                int portNumber = Convert.ToInt32(dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "Port"))[0]["Heso"]); //587;
                bool enableSSL = Convert.ToBoolean(dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "SSL"))[0]["Heso"]);// true;
                string emailFrom = dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "Email_Server"))[0]["Heso"].ToString(); //"slivermirana@gmail.com";
                string password = dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "Password_Email"))[0]["Heso"].ToString(); ///"89076532011";
                string username = dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "Username"))[0]["Heso"].ToString(); ///;

                string subject = trangthai + " Đơn hàng " + txtSochungtu.Text;
                string body = trangthai.ToUpper() + " ĐƠN HÀNG " + txtSochungtu.Text.ToUpper();
                body += "<br/><br/>Khách hàng: " + lookUpEdit_Khachhang.Text + " - " + lookUpEditKhuvuc_View.Text;
                body += "<br/><br/>Địa chỉ: " + lookUpEdit_Khachhang.GetColumnValue("Diachi_Khachhang"); ;
                body += "<br/>Ngày giao: " + dtNgaygiao.Text;
                body += "<br/>Lý do: " + txtGhichu_Edit.Text;
                DataSet nhansu_KTVP = objRexService.Rex_Nhansu_SelectEmail_ByChungtu(txtSochungtu.EditValue).ToDataSet();
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFrom);
                    mail.To.Add("jkhanhjjj@gmail.com");
                    mail.CC.Add("slivermirana@gmail.com");
                    foreach (DataRow row_nhansu in nhansu_KTVP.Tables[0].Rows)
                    {
                        mail.CC.Add(row_nhansu["Email"].ToString());
                    }
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;
                    //mail.Attachments.Add(new Attachment("D:\\donhang\\" + txtSochungtu.Text + ".pdf"));
                    //mail.Attachments.Add(new Attachment("C:\\SomeZip.zip"));
                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        smtp.Credentials = new NetworkCredential(username, password);
                        smtp.EnableSsl = enableSSL;
                        smtp.Send(mail);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtHotro_EditValueChanged(object sender, EventArgs e)
        {
            txtTongtien.EditValue = Convert.ToDecimal(gridView4.Columns["Thanhtien"].SummaryItem.SummaryValue) - Convert.ToDecimal("0" + txtHotro.EditValue);
        }

    }
}