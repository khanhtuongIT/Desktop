using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Hdmuahang :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();

        public DataSet ds_Selected = new DataSet();
        DataSet ds_Hdmuahang = new DataSet();
        DataSet ds_Hdmuahang_Chitiet = new DataSet();
        DataSet ds_Hanghoa_Ban = new DataSet();
        public DataRow dr_Hdmuahang;
        object sochungtuOld;

        public Frmware_Hdmuahang()
        {
            InitializeComponent();
            this.dtNgay_Chungtu.Properties.MinValue = new DateTime(2000, 01, 01);
            this.dtNgay_Thanhtoan.Properties.MinValue = new DateTime(2000, 01, 01);
            //date mask
            dtNgay_Chungtu.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgay_Chungtu.Properties.Mask.EditMask =  GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();

            dtNgay_Thanhtoan.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgay_Thanhtoan.Properties.Mask.EditMask =  GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();

            this.DisplayInfo();
            this.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }


        #region Event Override


        public override void DisplayInfo()
        {
            try
            {
                //Get data Ware_Dm_Nhacungcap
                DataSet dsKhachhang = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
                lookUpEdit_Nhacungcap.Properties.DataSource = dsKhachhang.Tables[0];

                //Get data Ware_Dm_Hanghoa_Mua 
                ds_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
                gridLookUp_Ten_Hanghoa.DataSource = ds_Hanghoa_Ban.Tables[0];
                gridLookUp_Ma_Hanghoa.DataSource = ds_Hanghoa_Ban.Tables[0];

                //Get data Ware_Dm_Donvitinh
                gridLookUp_Donvitinh.DataSource = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet().Tables[0];
                //Get data Ware_Hdmuahang
                this.dtThang_Nam.EditValue = DateTime.Now;
                //Reload_Chungtu(dtThang_Nam.DateTime);
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }

        public override void ClearDataBindings()
        {
            this.txtNguoiban.DataBindings.Clear();
            this.txtNguoimua.DataBindings.Clear();
            this.txtPhuongthuc_Thanhtoan.DataBindings.Clear();
            this.txtSo_Seri.DataBindings.Clear();
            this.txtSochungtu.DataBindings.Clear();
            this.txtTongtien.DataBindings.Clear();
            this.txtSotien_Thanhtoan.DataBindings.Clear();
            this.dtNgay_Chungtu.DataBindings.Clear();
            this.dtNgay_Thanhtoan.DataBindings.Clear();
            this.lookUpEdit_Nhacungcap.DataBindings.Clear();
            this.txtSotien_Thanhtoan.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtNguoiban.DataBindings.Add("EditValue", ds_Hdmuahang, ds_Hdmuahang.Tables[0].TableName + ".Hoten_Nguoiban");
                this.txtNguoimua.DataBindings.Add("EditValue", ds_Hdmuahang, ds_Hdmuahang.Tables[0].TableName + ".Hoten_Nguoimua");
                this.txtPhuongthuc_Thanhtoan.DataBindings.Add("EditValue", ds_Hdmuahang, ds_Hdmuahang.Tables[0].TableName + ".Phuongthuc_Thanhtoan");
                this.txtSo_Seri.DataBindings.Add("EditValue", ds_Hdmuahang, ds_Hdmuahang.Tables[0].TableName + ".So_Seri");
                this.txtSochungtu.DataBindings.Add("EditValue", ds_Hdmuahang, ds_Hdmuahang.Tables[0].TableName + ".Sochungtu");
                this.txtTongtien.DataBindings.Add("EditValue", ds_Hdmuahang, ds_Hdmuahang.Tables[0].TableName + ".Sotien");
                this.txtSotien_Thanhtoan.DataBindings.Add("EditValue", ds_Hdmuahang, ds_Hdmuahang.Tables[0].TableName + ".Sotien_Thanhtoan");
                this.dtNgay_Chungtu.DataBindings.Add("EditValue", ds_Hdmuahang, ds_Hdmuahang.Tables[0].TableName + ".Ngay_Chungtu");
                this.dtNgay_Thanhtoan.DataBindings.Add("EditValue", ds_Hdmuahang, ds_Hdmuahang.Tables[0].TableName + ".Ngay_Thanhtoan");
                this.lookUpEdit_Nhacungcap.DataBindings.Add("EditValue", ds_Hdmuahang, ds_Hdmuahang.Tables[0].TableName + ".Id_Khachhang");
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
            this.dgware_Hdmuahang.Enabled = !editTable;
            gvware_Hdmuahang_Chitiet.OptionsBehavior.Editable = editTable;
            this.txtNguoiban.Properties.ReadOnly = !editTable;
            this.txtNguoimua.Properties.ReadOnly = !editTable;
            this.txtPhuongthuc_Thanhtoan.Properties.ReadOnly = !editTable;
            this.txtSo_Seri.Properties.ReadOnly = !editTable;
            this.txtSochungtu.Properties.ReadOnly = !editTable;
            this.dtNgay_Chungtu.Properties.ReadOnly = !editTable;
            this.dtNgay_Thanhtoan.Properties.ReadOnly = !editTable;
            this.dgware_Hdmuahang_Chitiet.EmbeddedNavigator.Buttons.Append.Enabled = editTable;
            this.dgware_Hdmuahang_Chitiet.EmbeddedNavigator.Buttons.Remove.Enabled = editTable;
            this.lookUpEdit_Nhacungcap.Properties.ReadOnly = !editTable;
            btnImport_Hanghoa_Mua.Enabled = editTable;
            this.btnLap_Phieuchi.Enabled = !editTable;
        }

        public override void ResetText()
        {
            this.txtNguoiban.EditValue = "";
            this.txtNguoimua.EditValue = "";
            this.txtPhuongthuc_Thanhtoan.EditValue = "";
            this.txtSo_Seri.EditValue = "";
            this.txtSochungtu.EditValue = "";
            this.dtNgay_Chungtu.EditValue = objWareService.GetServerDateTime();
            this.dtNgay_Thanhtoan.EditValue = objWareService.GetServerDateTime();
            this.txtSotien.EditValue = null;
            this.txtTongtien.EditValue = null;
            this.lookUpEdit_Nhacungcap.EditValue = null;
            this.txtSotien_Vat.EditValue = null;
            this.txtDiachi.EditValue = "";
            this.txtDienthoai.EditValue = "";
            this.txtMasothue.EditValue = "";
            this.txtSotien_Thanhtoan.EditValue = "";
            this.ds_Hdmuahang_Chitiet = objWareService.Get_All_Ware_Hdmuahang_Chitiet_By_Hdmuahang(0).ToDataSet();
            this.dgware_Hdmuahang_Chitiet.DataSource = ds_Hdmuahang_Chitiet.Tables[0];
        }

        public object InsertObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Hdmuahang objWare_Hdmuahang = new Ecm.WebReferences.WareService.Ware_Hdmuahang();
                objWare_Hdmuahang.Id_Hdmuahang = -1;
                objWare_Hdmuahang.Hoten_Nguoiban = txtNguoiban.EditValue;
                objWare_Hdmuahang.Hoten_Nguoimua = txtNguoimua.EditValue;
                objWare_Hdmuahang.Phuongthuc_Thanhtoan = txtPhuongthuc_Thanhtoan.EditValue;
                objWare_Hdmuahang.So_Seri = txtSo_Seri.EditValue;
                objWare_Hdmuahang.Sochungtu = txtSochungtu.EditValue;
                objWare_Hdmuahang.Ngay_Chungtu = dtNgay_Chungtu.EditValue;
                objWare_Hdmuahang.Ngay_Thanhtoan = dtNgay_Thanhtoan.EditValue;

                System.Collections.Hashtable htbTen_Table = new System.Collections.Hashtable();
                htbTen_Table.Add(txtSochungtu, txtSochungtu.EditValue);

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htbTen_Table, ds_Hdmuahang, "sochungtu"))
                    return false;

                if ("" + txtTongtien.EditValue != "")
                    objWare_Hdmuahang.Sotien = txtTongtien.EditValue;
                if ("" + lookUpEdit_Nhacungcap.EditValue != "")
                    objWare_Hdmuahang.Id_Khachhang = lookUpEdit_Nhacungcap.EditValue;

                object identity = objWareService.Insert_Ware_Hdmuahang(objWare_Hdmuahang);
                if (identity != null)
                {
                    this.DoClickEndEdit(dgware_Hdmuahang_Chitiet);
                    foreach (DataRow dr in ds_Hdmuahang_Chitiet.Tables[0].Rows)
                    {
                        dr["Id_Hdmuahang"] = identity;
                    }
                    //update hdmuahang_chitiet
                    objWareService.Update_Ware_Hdmuahang_Chitiet_Collection(ds_Hdmuahang_Chitiet);
                    //update don gia cho nhap kho
                    //objWareService.Ware_Nhap_Hh_Chitiet_UpdateDongia_FrHdmuahang(identity, -1);
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
                Ecm.WebReferences.WareService.Ware_Hdmuahang objWare_Hdmuahang = new Ecm.WebReferences.WareService.Ware_Hdmuahang();
                objWare_Hdmuahang.Id_Hdmuahang = gridView1.GetFocusedRowCellValue("Id_Hdmuahang");
                objWare_Hdmuahang.Hoten_Nguoiban = txtNguoiban.EditValue;
                objWare_Hdmuahang.Hoten_Nguoimua = txtNguoimua.EditValue;
                objWare_Hdmuahang.Phuongthuc_Thanhtoan = txtPhuongthuc_Thanhtoan.EditValue;
                objWare_Hdmuahang.So_Seri = txtSo_Seri.EditValue;
                objWare_Hdmuahang.Sochungtu = txtSochungtu.EditValue;
                objWare_Hdmuahang.Ngay_Chungtu = dtNgay_Chungtu.EditValue;
                objWare_Hdmuahang.Ngay_Thanhtoan = dtNgay_Thanhtoan.EditValue;

                System.Collections.Hashtable htbTen_Table = new System.Collections.Hashtable();
                htbTen_Table.Add(txtSochungtu, txtSochungtu.EditValue);

                if (!sochungtuOld.Equals(txtSochungtu.EditValue))
                {
                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htbTen_Table, ds_Hdmuahang, "sochungtu"))
                        return false;
                }
                if ("" + txtTongtien.EditValue != "")
                    objWare_Hdmuahang.Sotien = txtTongtien.EditValue;

                if ("" + lookUpEdit_Nhacungcap.EditValue != "")
                    objWare_Hdmuahang.Id_Khachhang = lookUpEdit_Nhacungcap.EditValue;

                //update donmuahang
                objWareService.Update_Ware_Hdmuahang(objWare_Hdmuahang);
                //update donmuahang_chitiet
                this.DoClickEndEdit(dgware_Hdmuahang_Chitiet);
                foreach (DataRow dr in ds_Hdmuahang_Chitiet.Tables[0].Rows)
                {
                    if (dr.RowState == DataRowState.Added)
                        dr["Id_Hdmuahang"] = gridView1.GetFocusedRowCellValue("Id_Hdmuahang");
                }

                objWareService.Update_Ware_Hdmuahang_Chitiet_Collection(ds_Hdmuahang_Chitiet);
                //objWareService.Ware_Nhap_Hh_Chitiet_UpdateDongia_FrHdmuahang(gridView1.GetFocusedRowCellValue("Id_Hdmuahang"), -1);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.WareService.Ware_Hdmuahang objWare_Hdmuahang = new Ecm.WebReferences.WareService.Ware_Hdmuahang();
            objWare_Hdmuahang.Id_Hdmuahang = gridView1.GetFocusedRowCellValue("Id_Hdmuahang");
            return objWareService.Delete_Ware_Hdmuahang(objWare_Hdmuahang);
        }

        public override bool PerformAdd()
        {
            ClearDataBindings();
            this.ChangeStatus(true);
            this.ResetText();
            return true;
        }

        public override bool PerformEdit()
        {
            if (gridView1.GetFocusedRowCellValue("Sochungtu") == null)
                return false;
            if (objWareService.Check_Hdmuahang_Dachi(gridView1.GetFocusedRowCellValue("Sochungtu")))
            {
                 GoobizFrame.Windows.Forms.MessageDialog.Show("Hóa đơn đã được lập phiếu chi, không thể sửa.");
                return false;
            }
            sochungtuOld = txtSochungtu.EditValue;
            this.ChangeStatus(true);
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
                System.Collections.Hashtable htbControl1 = new System.Collections.Hashtable();
                htbControl1.Add(txtSochungtu, lblSochungtu.Text);
                htbControl1.Add(dtNgay_Chungtu, lblNgay_Chungtu.Text);
                htbControl1.Add(dtNgay_Thanhtoan, lblNgay_Thanhtoan.Text);
                htbControl1.Add(txtSo_Seri, lblSo_Seri.Text);
                htbControl1.Add(lookUpEdit_Nhacungcap, lblNha_Cungcap.Text);
                htbControl1.Add(txtPhuongthuc_Thanhtoan, lblPhuongthuc_Thanhtoan.Text);

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(htbControl1))
                    return false;

                if (gvware_Hdmuahang_Chitiet.RowCount == 0)
                {
                     GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa có hàng hóa, nhập hàng hóa");
                    return false;
                }

                System.Collections.Hashtable htbControl2 = new System.Collections.Hashtable();
                htbControl2.Add(gvware_Hdmuahang_Chitiet.Columns["Id_Hanghoa_Ban"], "");
                htbControl2.Add(gvware_Hdmuahang_Chitiet.Columns["Soluong"], "");
                htbControl2.Add(gvware_Hdmuahang_Chitiet.Columns["Dongia"], "");
                htbControl2.Add(gvware_Hdmuahang_Chitiet.Columns["Per_VAT"], "");

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(htbControl2, gvware_Hdmuahang_Chitiet))
                    return false;

                try
                {
                    Constraint constraint = new UniqueConstraint("constraint",
                     new DataColumn[] { ds_Hdmuahang_Chitiet.Tables[0].Columns["Id_Hanghoa_Ban"], 
                                        ds_Hdmuahang_Chitiet.Tables[0].Columns["Id_Donvitinh"] }, false);
                    ds_Hdmuahang_Chitiet.Tables[0].Constraints.Clear();
                    ds_Hdmuahang_Chitiet.Tables[0].Constraints.Add(constraint);
                }
                catch (Exception ex)
                {
                    if (ex.ToString().IndexOf("These columns don't currently have unique values") != -1)
                    {
                         GoobizFrame.Windows.Forms.MessageDialog.Show("Hàng hóa và đơn vị tính đã tồn tại, vui lòng nhập lại");
                        return false;
                    }
                    MessageBox.Show(ex.ToString());
                }

                if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Add)
                    success = (bool)this.InsertObject();
                else if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Edit)
                    success = (bool)this.UpdateObject();

                if (success)
                {
                    this.DisplayInfo();
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
            if (gridView1.GetFocusedRowCellValue("Sochungtu") == null)
                return false;
            if (objWareService.Check_Hdmuahang_Dachi(gridView1.GetFocusedRowCellValue("Sochungtu")))
            {
                 GoobizFrame.Windows.Forms.MessageDialog.Show("Hóa đơn đã được lập phiếu chi, không thể xóa.");
                return false;
            }
            if ( GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Hdmuahang"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Hdmuahang")   }) == DialogResult.Yes)
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

        public override object PerformSelectOneObject()
        {
            Ecm.WebReferences.WareService.Ware_Hdmuahang ware_Hdmuahang = new Ecm.WebReferences.WareService.Ware_Hdmuahang();
            try
            {
                if (txtSotien_Thanhtoan.EditValue.Equals(txtTongtien.EditValue))
                {
                     GoobizFrame.Windows.Forms.MessageDialog.Show("Hóa đơn này đã xuất phiếu chi đủ tiền, nên không thể xuất thêm Phiếu Chi");
                    return false;
                }
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                if (ds_Hdmuahang.Tables[0].Rows[focusedRow] != null)
                    dr_Hdmuahang = ds_Hdmuahang.Tables[0].Rows[focusedRow];
                this.Dispose();
                this.Close();
                return dr_Hdmuahang;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return null;
            }
        }
        #endregion

        #region Even

        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Soluong" || e.Column.FieldName == "Dongia" || e.Column.FieldName == "Per_VAT")
            {
                try
                {
                    decimal soluong = 0;
                    int vat = 0;
                    decimal dongia = 0;
                    decimal dongia_vat = 0;
                    decimal thanhtien = 0;

                    if ("" + gvware_Hdmuahang_Chitiet.GetFocusedRowCellValue("Soluong") != "")
                    {
                        soluong = Convert.ToDecimal(gvware_Hdmuahang_Chitiet.GetFocusedRowCellValue("Soluong"));
                        if (soluong <= 0)
                        {
                             GoobizFrame.Windows.Forms.MessageDialog.Show("Số lượng phải lớn hơn 0, vui lòng nhập lại.");
                            gvware_Hdmuahang_Chitiet.SetFocusedRowCellValue(gvware_Hdmuahang_Chitiet.Columns["Soluong"], null);
                            return;
                        }
                    }

                    if ("" + gvware_Hdmuahang_Chitiet.GetFocusedRowCellValue("Dongia") != "")
                        dongia = Convert.ToDecimal(gvware_Hdmuahang_Chitiet.GetFocusedRowCellValue("Dongia"));

                    if ("" + gvware_Hdmuahang_Chitiet.GetFocusedRowCellValue("Per_VAT") != "")
                        vat = Convert.ToInt32(gvware_Hdmuahang_Chitiet.GetFocusedRowCellValue("Per_VAT"));

                    //if (vat == 0)
                    //    dongia_vat = dongia;
                    //else
                    //    dongia_vat = ((vat / 100) + 1) * dongia;
                    dongia_vat = (vat * dongia) / 100;

                    //Thành tiền trong database là [numeric(18, 2) = (16 số nguyên và 2 số thập phân)]. Nếu đơn giá vược quá 16 ký tự thì hiện thông báo lỗi.
                    thanhtien = dongia_vat * soluong;
                    if (thanhtien.ToString().Length > 16)
                    {
                         GoobizFrame.Windows.Forms.MessageDialog.Show("Giá trị thành tiền vượt quá khả năng lưu trữ.");
                        gvware_Hdmuahang_Chitiet.SetFocusedRowCellValue(gvware_Hdmuahang_Chitiet.Columns["Soluong"], null);
                        gvware_Hdmuahang_Chitiet.SetFocusedRowCellValue(gvware_Hdmuahang_Chitiet.Columns["Dongia"], null);
                        gvware_Hdmuahang_Chitiet.SetFocusedRowCellValue(gvware_Hdmuahang_Chitiet.Columns["Per_VAT"], null);
                    }
                    else
                    {
                        gvware_Hdmuahang_Chitiet.SetFocusedRowCellValue("Sotien_VAT", dongia_vat * soluong);
                        //gridView4.SetFocusedRowCellValue("Dongia_VAT", dongia * soluong);
                        gvware_Hdmuahang_Chitiet.SetFocusedRowCellValue("Thanhtien", soluong * dongia);
                    }
                }
                catch (Exception ex)
                {
                     GoobizFrame.Windows.Forms.MessageDialog.Show("Giá trị thành tiền vượt quá khả năng lưu trữ.");
                    gvware_Hdmuahang_Chitiet.SetFocusedRowCellValue(gvware_Hdmuahang_Chitiet.Columns["Soluong"], null);
                    gvware_Hdmuahang_Chitiet.SetFocusedRowCellValue(gvware_Hdmuahang_Chitiet.Columns["Dongia"], null);
                    gvware_Hdmuahang_Chitiet.SetFocusedRowCellValue(gvware_Hdmuahang_Chitiet.Columns["Per_VAT"], null);
                }
            }

            if (e.Column.FieldName == "Id_Hanghoa_Ban")
            {
                gvware_Hdmuahang_Chitiet.SetFocusedRowCellValue(gvware_Hdmuahang_Chitiet.Columns["Id_Donvitinh"]
                         , ((System.Data.DataRowView)gridLookUp_Ten_Hanghoa.GetDataSourceRowByKeyValue(e.Value))["Id_Donvitinh"]);
            }
            if (e.Column.FieldName == "Thanhtien")
            {
                this.DoClickEndEdit(dgware_Hdmuahang_Chitiet);
            }
            set_Value_Sotien();
        }

        private void lookUpEdit_Nhacungcap_EditValueChanged(object sender, EventArgs e)
        {
            if ("" + lookUpEdit_Nhacungcap.EditValue != "")
            {
                txtMasothue.EditValue = lookUpEdit_Nhacungcap.GetColumnValue("Masothue");
                txtDiachi.EditValue = lookUpEdit_Nhacungcap.GetColumnValue("Diachi_Khachhang");
                txtDienthoai.EditValue = lookUpEdit_Nhacungcap.GetColumnValue("Dienthoai");
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if ("" + gridView1.GetFocusedRowCellValue("Id_Hdmuahang") != "")
                this.DisplayInfo2();
        }

        private void gridLookUpEdit_Hanghoa_Mua_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                try
                {
                    var dialog = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowDialogOfMetaData(
                        "Ecm.MasterTables.dll",
                        "Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Ban_FullEdit", this);

                    if (dialog == null)
                        return;
                    var SelectedObject = dialog.GetType().GetProperty("Selected_Ware_Dm_Hanghoa_Ban").GetValue(dialog, null)
                        as Ecm.WebReferences.MasterService.Ware_Dm_Hanghoa_Ban;
                    var DsDm_Hanghoa_Ban = dialog.GetType().GetProperty("DsDm_Hanghoa_Ban").GetValue(dialog, null) as DataSet;

                    if (SelectedObject != null)
                    {
                        gridLookUp_Ten_Hanghoa.DataSource = DsDm_Hanghoa_Ban.Tables[0];

                        gvware_Hdmuahang_Chitiet.SetFocusedRowCellValue(gvware_Hdmuahang_Chitiet.Columns["Id_Hanghoa_Ban"], SelectedObject.Id_Hanghoa_Ban);

                    }
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                }

               
            }
        }

        private void gridView4_RowCountChanged(object sender, EventArgs e)
        {
            if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.View)
                return;
            set_Value_Sotien();
        }

        private void gridLookUpEdit_Donvitinh_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                Ecm.MasterTables.Forms.Ware.Frmware_Dm_Donvitinh_Add frm_Donvitinh = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Donvitinh_Add();
                if (gvware_Hdmuahang_Chitiet.GetFocusedRowCellValue(gvware_Hdmuahang_Chitiet.Columns["Id_Hanghoa_Ban"]).ToString() == "")
                    return;
                frm_Donvitinh.setId_Hanghoa_Ban(gvware_Hdmuahang_Chitiet.GetFocusedRowCellValue(gvware_Hdmuahang_Chitiet.Columns["Id_Hanghoa_Ban"]));
                frm_Donvitinh.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                frm_Donvitinh.item_Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                frm_Donvitinh.ShowDialog();
                if (frm_Donvitinh.SelecteWare_Dm_Donvitinh != null)
                {
                    gvware_Hdmuahang_Chitiet.SetFocusedRowCellValue(gvware_Hdmuahang_Chitiet.Columns["Id_Donvitinh"], frm_Donvitinh.SelecteWare_Dm_Donvitinh.Id_Donvitinh);
                }
                gvware_Hdmuahang_Chitiet.BestFitColumns();
            }
        }

        private void btnLap_Phieuchi_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal("0" + txtTongtien.EditValue).Equals(Convert.ToDecimal("0" + txtSotien_Thanhtoan.EditValue)))
            {
                 GoobizFrame.Windows.Forms.MessageDialog.Show("Hóa đơn này đã thanh toán đủ nên không thể lập phiếu phi ");
                return;
            }
            Ecm.Ware.Forms.Frmware_Phieu_Chi frm_PhieuChi = new Frmware_Phieu_Chi();
            int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
            if (ds_Hdmuahang.Tables[0].Rows[focusedRow] != null)
                dr_Hdmuahang = ds_Hdmuahang.Tables[0].Rows[focusedRow];
            frm_PhieuChi.set_Chungtu_Goc(dr_Hdmuahang,
                Convert.ToDecimal(txtTongtien.EditValue) - Convert.ToDecimal("0" + txtSotien_Thanhtoan.EditValue),
                lookUpEdit_Nhacungcap.GetColumnValue("Ma_Khachhang"));
            frm_PhieuChi.txtDiachi.EditValue = lookUpEdit_Nhacungcap.GetColumnValue("Diachi_Khachhang");
            frm_PhieuChi.ShowDialog();
            this.DisplayInfo();
        }

        private void gridView4_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvware_Hdmuahang_Chitiet.SetFocusedRowCellValue(gvware_Hdmuahang_Chitiet.Columns["Per_VAT"], 10);
        }

        #endregion

        #region Custom Method

        //deonguyen - 07/10/2010
        public void Load_Hdmuahang_ByNhacungcap(object Id_Nhacungcap)
        {
            //Get data Ware_Dm_Nhacungcap
            //DataSet ds_NhaCC = objMasterService.Get_All_Ware_Dm_Nhacungcap().ToDataSet();
            //lookUpEdit_Nhacungcap.Properties.DataSource = ds_NhaCC.Tables[0];

            //Get data Ware_Dm_Hanghoa_Mua 
            ds_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
            gridLookUp_Ten_Hanghoa.DataSource = ds_Hanghoa_Ban.Tables[0];
            gridLookUp_Ma_Hanghoa.DataSource = ds_Hanghoa_Ban.Tables[0];

            //Get data Ware_Dm_Donvitinh
            gridLookUp_Donvitinh.DataSource = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet().Tables[0];
            //Get data Ware_Hdmuahang
            ds_Hdmuahang = objWareService.Get_All_Ware_Hdmuahang_ByNhacungcap(Id_Nhacungcap).ToDataSet();
            dgware_Hdmuahang.DataSource = ds_Hdmuahang;
            dgware_Hdmuahang.DataMember = ds_Hdmuahang.Tables[0].TableName;
            this.DataBindingControl();
            this.ChangeStatus(false);
            this.gridView1.BestFitColumns();
            DisplayInfo2();
        }

        void DisplayInfo2()
        {
            if ("" + gridView1.GetFocusedRowCellValue("Id_Hdmuahang") == "")
            {
                dgware_Hdmuahang_Chitiet.DataSource = null;
                return;
            }
            this.ds_Hdmuahang_Chitiet = objWareService.Get_All_Ware_Hdmuahang_Chitiet_By_Hdmuahang(gridView1.GetFocusedRowCellValue("Id_Hdmuahang")).ToDataSet();
            this.ds_Hdmuahang_Chitiet.Tables[0].Columns.Add("Chon", typeof(Boolean));
            this.dgware_Hdmuahang_Chitiet.DataSource = ds_Hdmuahang_Chitiet;
            this.dgware_Hdmuahang_Chitiet.DataMember = ds_Hdmuahang_Chitiet.Tables[0].TableName;
            set_Value_Sotien();
        }

        void set_Value_Sotien()
        {
            this.DoClickEndEdit(dgware_Hdmuahang_Chitiet);
            this.txtTongtien.EditValue = gvware_Hdmuahang_Chitiet.Columns["Thanhtien"].SummaryItem.SummaryValue;
            this.txtSotien_Vat.EditValue = ds_Hdmuahang_Chitiet.Tables[0].Compute("Sum(Sotien_VAT)", "");
            this.txtSotien.EditValue = Convert.ToDecimal(txtTongtien.EditValue) - Convert.ToDecimal("0" + txtSotien_Vat.EditValue);
        }
        #endregion

        private void gridText_Soluong_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if ("" + e.NewValue == "")
                {
                    gvware_Hdmuahang_Chitiet.SetFocusedRowCellValue(gvware_Hdmuahang_Chitiet.Columns["Soluong"], null);
                    e.Cancel = true;
                }
                else if (e.NewValue.ToString().Length > 10)
                {
                    // GoobizFrame.Windows.Forms.MessageDialog.Show("Giá trị số lượng không hợp lệ, vui lòng nhập lại.");
                    //gridView4.SetFocusedRowCellValue(gridView4.Columns["Soluong"], null);
                    e.Cancel = true;
                }
                //else if (Convert.ToInt32(e.NewValue) <= 0)
                //{
                //     GoobizFrame.Windows.Forms.MessageDialog.Show("Số lượng phải lớn hơn 0, vui lòng nhập lại.");
                //    gridView4.SetFocusedRowCellValue(gridView4.Columns["Soluong"], null);
                //    e.Cancel = true;
                //}
            }
            catch (Exception ex)
            {
                //Nếu số lượng vượt quá khả năng nhập liệu sẽ hiện thông báo lỗi.
                // GoobizFrame.Windows.Forms.MessageDialog.Show("Giá trị số lượng không hợp lệ, vui lòng nhập lại.");
                //gridView4.SetFocusedRowCellValue(gridView4.Columns["Soluong"], null);
                e.Cancel = true;
            }
        }

        private void gridText_Dongia_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if ("" + e.NewValue == "")
                {
                    gvware_Hdmuahang_Chitiet.SetFocusedRowCellValue(gvware_Hdmuahang_Chitiet.Columns["Dongia"], null);
                    e.Cancel = true;
                }
                else if (e.NewValue.ToString().Length > 16)
                {
                    e.Cancel = true;
                }
                else if (Convert.ToDecimal(e.NewValue) <= 0)
                {
                     GoobizFrame.Windows.Forms.MessageDialog.Show("Đơn giá phải lớn hơn 0, vui lòng nhập lại.");
                    gvware_Hdmuahang_Chitiet.SetFocusedRowCellValue(gvware_Hdmuahang_Chitiet.Columns["Soluong"], null);
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                //Nếu đơn giá vượt quá khả năng nhập liệu sẽ hiện thông báo lỗi.
                // GoobizFrame.Windows.Forms.MessageDialog.Show("Giá trị đơn giá không hợp lệ, vui lòng nhập lại.");
                //gridView4.SetFocusedRowCellValue(gridView4.Columns["Dongia"], null);
                e.Cancel = true;
            }
        }

        void Reload_Chungtu(object Ngay_Chungtu)
        {
            ds_Hdmuahang = objWareService.Get_All_Ware_Hdmuahang(Ngay_Chungtu).ToDataSet();
            dgware_Hdmuahang.DataSource = ds_Hdmuahang;
            dgware_Hdmuahang.DataMember = ds_Hdmuahang.Tables[0].TableName;
            this.DataBindingControl();
            this.ChangeStatus(false);
            this.gridView1.BestFitColumns();
            DisplayInfo2();
        }

        private void dtThang_Nam_EditValueChanged(object sender, EventArgs e)
        {
            if (dtThang_Nam.Text != "")
                Reload_Chungtu(dtThang_Nam.DateTime);
            else
                Reload_Chungtu(null);
        }

        private void gridLookUp_Ma_Hanghoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                try
                {
                    var dialog = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowDialogOfMetaData(
                        "Ecm.MasterTables.dll",
                        "Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Ban_FullEdit", this);

                    if (dialog == null)
                        return;

                    ds_Hanghoa_Ban = dialog.GetType().GetProperty("DsDm_Hanghoa_Ban").GetValue(dialog, null) as DataSet;
                    gridLookUp_Ten_Hanghoa.DataSource = ds_Hanghoa_Ban.Tables[0];
                    gridLookUp_Ma_Hanghoa.DataSource = ds_Hanghoa_Ban.Tables[0];

                    var SelectedObject = dialog.GetType().GetProperty("Selected_Ware_Dm_Hanghoa_Ban").GetValue(dialog, null)
                        as Ecm.WebReferences.MasterService.Ware_Dm_Hanghoa_Ban;

                    if (SelectedObject != null)
                        gvware_Hdmuahang_Chitiet.SetFocusedRowCellValue("Id_Hanghoa_Ban", SelectedObject.Id_Hanghoa_Ban);
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                }
            }
        }

    }
}

