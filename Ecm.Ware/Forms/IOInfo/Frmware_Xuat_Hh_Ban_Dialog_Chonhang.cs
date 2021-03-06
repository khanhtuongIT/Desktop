using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Xuat_Hh_Ban_Dialog_Chonhang : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        DataSet ds_Xkbanhang = new DataSet();
        DataSet ds_Xkbanhang_Chitiet = new DataSet();
        DataSet ds_Hanghoa_Ban;
        DataSet dsDonvitinh = new DataSet();
        DataSet dsNhansu;
        object Sochungtu;
        DataSet ds_Role_User;
        public DataRow[] _selectedRows;

        public Frmware_Xuat_Hh_Ban_Dialog_Chonhang(object sochungtu)
        {
            InitializeComponent();
            Sochungtu = sochungtu;
            //reset lookup edit as delete value
            lookUpEdit_Nhansu_Lap.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            //LocationId_Cuahang_Ban = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocation("Id_Cuahang_Ban");
            this.item_Query.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Verify.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Test.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Cancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_PrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            this.DisplayInfo();
        }

        void LoadMasterData()
        {
            ds_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
            dsNhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
            dsDonvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();

            gridLookUpEdit_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
            gridLookUpEdit_Ma_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
            //lookUpEdit_Nhansu_Kk
            lookUpEdit_Nhansu_Lap.Properties.DataSource = dsNhansu.Tables[0];
            lookupEdit_Nhansu_Bh.Properties.DataSource = dsNhansu.Tables[0];
            gridLookUpEdit_Donvitinh.DataSource = dsDonvitinh.Tables[0];

            DataSet ds_collection = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
            lookupEditKhachhang.Properties.DataSource = ds_collection.Tables[0];
            lookupEdit_MaKhachhang.Properties.DataSource = ds_collection.Tables[0];

            DataSet dsCuahang_Ban = objMasterService.Ware_Dm_Cuahang_Ban_Select_Kho().ToDataSet();
            lookUpEdit_KhoEdit.Properties.DataSource = dsCuahang_Ban.Tables[0];
            lookUpEditKhuvuc.Properties.DataSource = objMasterService.Ware_Dm_Cuahang_Ban_Select_Sale().ToDataSet().Tables[0];
        }

        public override void DisplayInfo()
        {
            try
            {
                ResetText();
                LoadMasterData();
                ds_Xkbanhang = objWareService.Ware_Xuatkho_Banhang_SelectBy_Sochungtu(Sochungtu).ToDataSet();
                DataBindingControl();
                ds_Xkbanhang_Chitiet = objWareService.Ware_Xuatkho_Banhang_Chitiet_SelectBy_Sochungtu(Sochungtu).ToDataSet();
                ds_Xkbanhang_Chitiet.Tables[0].Columns.Add("Chon", typeof(bool));
                this.dgware_Hdbanhang_Chitiet.DataSource = ds_Xkbanhang_Chitiet;
                this.dgware_Hdbanhang_Chitiet.DataMember = ds_Xkbanhang_Chitiet.Tables[0].TableName;
                gvware_Xuat_Hanghoa_Ban_Chitiet.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void ClearDataBindings()
        {
            this.lookUpEdit_KhoEdit.DataBindings.Clear();
            this.dtNgay_Chungtu.DataBindings.Clear();
            this.lookUpEdit_Nhansu_Lap.DataBindings.Clear();
            this.lookupEditKhachhang.DataBindings.Clear();
            lookupEdit_MaKhachhang.DataBindings.Clear();
            lookupEdit_Nhansu_Bh.DataBindings.Clear();
            this.txtGhichu.DataBindings.Clear();
            dtNgaygiao.DataBindings.Clear();
            lookUpEditKhuvuc.DataBindings.Clear();
            dtNgay_Thutien.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                this.ClearDataBindings();
                this.dtNgay_Chungtu.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Ngay_Chungtu");
                this.lookUpEdit_KhoEdit.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Id_Cuahang_Ban");
                this.lookUpEdit_Nhansu_Lap.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Id_Nhansu_Edit");
                this.lookupEdit_Nhansu_Bh.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Id_Nhansu_Bh");
                this.lookupEditKhachhang.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Id_Khachhang");
                lookupEdit_MaKhachhang.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Id_Khachhang");
                this.txtGhichu.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Ghichu_Edit");
                dtNgaygiao.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Ngay_Thanhtoan");
                dtNgay_Thutien.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Ngay_Thutien");
                lookUpEditKhuvuc.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Id_Khuvuc");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void ChangeStatus(bool editTable)
        {
            //this.dgware_Hdbanhang.Enabled = !editTable;
            this.txtGhichu.Properties.ReadOnly = !editTable;
            //this.lookUpEdit_Kho_View.Properties.ReadOnly = editTable;
            this.dgware_Hdbanhang_Chitiet.EmbeddedNavigator.Enabled = editTable;
            this.gvware_Xuat_Hanghoa_Ban_Chitiet.OptionsBehavior.Editable = editTable;
            lookUpEdit_KhoEdit.Properties.ReadOnly = !editTable;
            lookupEdit_MaKhachhang.Properties.ReadOnly = !editTable;
        }

        public override void ResetText()
        {
            this.lookupEditKhachhang.EditValue = null;
            lookupEdit_MaKhachhang.EditValue = null;
            this.dtNgay_Thutien.EditValue = null;
            this.txtDiachi.EditValue = null;
            lookUpEdit_Nhansu_Lap.EditValue = null;
            dtNgaygiao.EditValue = null;
            lookUpEditKhuvuc.EditValue = null;
            lookupEdit_Nhansu_Bh.EditValue = null;
            this.lookUpEdit_KhoEdit.EditValue = null;
            this.dtNgay_Chungtu.EditValue = null;
            txtGhichu.EditValue = null;
            this.ds_Xkbanhang_Chitiet = objWareService.Get_All_Ware_Xuatkho_Banhang_Chitiet_By_Id_Xuatkho_Banhang(0).ToDataSet();
            this.dgware_Hdbanhang_Chitiet.DataSource = ds_Xkbanhang_Chitiet.Tables[0];
        }

        public override object PerformSelectOneObject()
        {
            DoClickEndEdit(dgware_Hdbanhang_Chitiet);
            if (MdiParent != null) return null;
            try
            {
                if (ds_Xkbanhang_Chitiet == null || ds_Xkbanhang_Chitiet.Tables.Count == 0) return false;

                _selectedRows = ds_Xkbanhang_Chitiet.Tables[0].Select("Chon=true");
                if (_selectedRows == null || _selectedRows.Length == 0)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] { "Tên hàng" });
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

        private void gridLookUpEdit_Hanghoa_Ban_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
                {
                    Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Ban_Dialog frmware_Dm_Hanghoa_Ban_Dialog = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Ban_Dialog();
                    frmware_Dm_Hanghoa_Ban_Dialog.Text = "Hàng hóa";
                    GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmware_Dm_Hanghoa_Ban_Dialog);
                    frmware_Dm_Hanghoa_Ban_Dialog.ShowDialog();

                    if (frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows != null
                        && frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows.Length > 0)
                    {
                        gvware_Xuat_Hanghoa_Ban_Chitiet.SetFocusedRowCellValue(gvware_Xuat_Hanghoa_Ban_Chitiet.Columns["Id_Hanghoa_Ban"]
                            , frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[0]["Id_Hanghoa_Ban"]);
                        gvware_Xuat_Hanghoa_Ban_Chitiet.SetFocusedRowCellValue(gvware_Xuat_Hanghoa_Ban_Chitiet.Columns["Id_Donvitinh"]
                            , frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[0]["Id_Donvitinh"]);
                        gvware_Xuat_Hanghoa_Ban_Chitiet.SetFocusedRowCellValue(gvware_Xuat_Hanghoa_Ban_Chitiet.Columns["Dongia_Ban"]
                            , frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[0]["Dongia_Ban"]);
                        //object Id_Cuahang_Ban = gridView1.GetFocusedRowCellValue("Id_Cuahang_Ban");
                        if (frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows.Length > 1)
                        {
                            for (int i = 1; i < frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows.Length; i++)
                            {
                                DataRow nrow = ds_Xkbanhang_Chitiet.Tables[0].NewRow();
                                //nrow["Id_Cuahang_Ban"] = Id_Cuahang_Ban;
                                nrow["Id_Hanghoa_Ban"] = frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[i]["Id_Hanghoa_Ban"];
                                nrow["Id_Donvitinh"] = frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[i]["Id_Donvitinh"];
                                nrow["Dongia"] = frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[i]["Dongia_Ban"];
                                ds_Xkbanhang_Chitiet.Tables[0].Rows.Add(nrow);
                            }
                        }
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

        private void gridView5_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (gvware_Xuat_Hanghoa_Ban_Chitiet.GetFocusedDataRow() == null) return;

                object id_khuvuc = lookUpEditKhuvuc.EditValue;
                switch (e.Column.FieldName)
                {
                    case "Soluong":
                        decimal soluong_donhang = Convert.ToDecimal("0" + gvware_Xuat_Hanghoa_Ban_Chitiet.GetFocusedRowCellValue("Soluong_Conlai_Bef"));
                        if (Convert.ToDecimal("0" + gvware_Xuat_Hanghoa_Ban_Chitiet.GetFocusedRowCellValue("Soluong_Conlai")) > soluong_donhang)
                        {
                            GoobizFrame.Windows.Forms.MessageDialog.Show("Số lượng không được lớn hơn số lượng đơn hàng");
                            gvware_Xuat_Hanghoa_Ban_Chitiet.SetFocusedRowCellValue("Soluong_Conlai", gvware_Xuat_Hanghoa_Ban_Chitiet.GetFocusedRowCellValue("Soluong_Conlai_Bef"));
                        }
                        break;
                }
                gvware_Xuat_Hanghoa_Ban_Chitiet.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lookupEditKhachhang_EditValueChanged(object sender, EventArgs e)
        {
            if (lookupEditKhachhang.EditValue != null)
                this.txtDiachi.EditValue = lookupEditKhachhang.GetColumnValue("Diachi_Khachhang");
            else
                this.txtDiachi.EditValue = null;
        }

        private void btnDonhang_Click(object sender, EventArgs e)
        {
            if (lookupEditKhachhang.EditValue == null)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn Khách hàng, vui lòng chọn lại");
                return;
            }
            Frmware_Hdbanhang_noVAT_Hhban frmDonhang = new Frmware_Hdbanhang_noVAT_Hhban(lookupEditKhachhang.EditValue);
            frmDonhang.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            frmDonhang.gridColumnChon.Visible = true;
            frmDonhang.gridColumnChon.VisibleIndex = 0;
            frmDonhang.ShowDialog();
            if (frmDonhang._selectedRows != null && frmDonhang._selectedRows.Length > 0)
            {
                Fill_Dondathang(frmDonhang._selectedRows);
            }
        }

        private void Fill_Dondathang(DataRow[] sdrware_DonDatHang_Chitiet)
        {
            try
            {
                foreach (DataRow dtr in sdrware_DonDatHang_Chitiet)
                {
                    // Add nhap vattu chi tiet 
                    DataRow rNha_Chitiet = ds_Xkbanhang_Chitiet.Tables[0].NewRow();
                    rNha_Chitiet["Id_Hanghoa_Ban"] = dtr["Id_Hanghoa_Ban"];
                    rNha_Chitiet["Id_Donvitinh"] = dtr["Id_Donvitinh"];
                    rNha_Chitiet["Barcode_Txt"] = dtr["Barcode_Txt"];
                    rNha_Chitiet["Soluong"] = dtr["Soluong"];
                    //rNha_Chitiet["Ten_Mathang"] = dtr["Ten_Mathang"];
                    //rNha_Chitiet["Ten_Donvitinh"] = dtr["Ten_Donvitinh"];
                    rNha_Chitiet["Dongia_Ban"] = dtr["Dongia_Ban"];
                    rNha_Chitiet["Thanhtien"] = dtr["Thanhtien"];
                    ds_Xkbanhang_Chitiet.Tables[0].Rows.Add(rNha_Chitiet);
                }
            }
            catch (Exception ex)
            { ex.ToString(); }
        }

        private void lookupEdit_MaKhachhang_EditValueChanged(object sender, EventArgs e)
        {
            lookupEditKhachhang.EditValue = lookupEdit_MaKhachhang.EditValue;
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataRow row in ds_Xkbanhang_Chitiet.Tables[0].Rows)
            {
                row["Chon"] = checkEdit1.Checked;
            }
        }

    }
}