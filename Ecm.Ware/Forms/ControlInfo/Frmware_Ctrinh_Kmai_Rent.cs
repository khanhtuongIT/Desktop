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

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Ctrinh_Kmai_Rent : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();

        DataSet ds_Ctrinh_Kmai_Rent = new DataSet();
        DataSet ds_Ctrinh_Kmai_Chitiet = new DataSet();
        DataSet ds_Ctrinh_Kmai_Rent_Chitiet = new DataSet();
        DataSet ds_Ctrinh_Kmai_Chitiet_ByDate = new DataSet();
        object identity;
        public Frmware_Ctrinh_Kmai_Rent()
        {
            InitializeComponent();
            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");
            //date mask
            dtNgay_Batdau.Properties.MinValue = new DateTime(2000, 01, 01);
            dtNgay_Ketthuc.Properties.MinValue = new DateTime(2000, 01, 01);
            dtNgay_Batdau.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgay_Batdau.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();
            dtNgay_Ketthuc.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgay_Ketthuc.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();
            this.DisplayInfo();
        }

        #region Display info & process data, methods override

        void LoadMasterData()
        {
            //dsSys_Lognotify = objMasterService.Get_Sys_Lognotify_SelectLastChange_OfTables("[ware_dm_hanghoa_ban], [ware_dm_donvitinh]").ToDataSet();
            DataTable dtb = objMasterService.Get_All_Ware_Dm_Hanghoa_Tree(true, null, null).ToDataSet().Tables[0];
            gridLookUpEdit_Ma_Hanghoa.DataSource = dtb;

            dtb = objMasterService.Get_All_Bar_Dm_Class().ToDataSet().Tables[0];
            gridLookupEdit_Class.DataSource = dtb;

            dtb = objMasterService.Get_All_Bar_Dm_Rentlevel_Collection().ToDataSet().Tables[0];
            gridLookupEdit_RentLevel.DataSource = dtb;
        }

        public override void DisplayInfo()
        {
            try
            {
                LoadMasterData();
                ds_Ctrinh_Kmai_Rent = objWareService.Get_All_Ware_Ctrinh_Kmai_Rent().ToDataSet();
                dgware_Ctrinh_Kmai.DataSource = ds_Ctrinh_Kmai_Rent;
                dgware_Ctrinh_Kmai.DataMember = ds_Ctrinh_Kmai_Rent.Tables[0].TableName;
                this.DataBindingControl();
                this.ChangeStatus(false);
                DisplayInfo2();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }

        void DisplayInfo2()
        {
            identity = gvChuongtrinh_KM.GetFocusedRowCellValue("Id_Ctrinh_Kmai");
            if ("" + identity == "")
                return;
            ds_Ctrinh_Kmai_Chitiet = objWareService.Get_All_Ware_Ctrinh_Kmai_Chitiet_By_Ctrinh_Kmai(identity).ToDataSet();
            this.dgware_Ctrinh_Kmai_Chitiet.DataSource = ds_Ctrinh_Kmai_Chitiet;
            this.dgware_Ctrinh_Kmai_Chitiet.DataMember = ds_Ctrinh_Kmai_Chitiet.Tables[0].TableName;

            ds_Ctrinh_Kmai_Rent_Chitiet = objWareService.Get_All_Ware_Ctrinh_Kmai_Rent_Chitiet_By_Ctrinh_Kmai(identity).ToDataSet();
            this.dgware_Ctrinh_Kmai_Rent_Chitiet.DataSource = ds_Ctrinh_Kmai_Rent_Chitiet;
            this.dgware_Ctrinh_Kmai_Rent_Chitiet.DataMember = ds_Ctrinh_Kmai_Rent_Chitiet.Tables[0].TableName;
        }

        void setPer_Dongia()
        {
            for (int i = 0; i < ds_Ctrinh_Kmai_Chitiet.Tables[0].Rows.Count; i++)
            {
                gvChuongtrinhKM_Chitiet.SetRowCellValue(i, gvChuongtrinhKM_Chitiet.Columns["Per_Dongia"], txtPer_Hoadon.EditValue);
            }
        }

        public override void ClearDataBindings()
        {
            this.txtMa_Ctrinh_Kmai.DataBindings.Clear();
            this.txtTen_Ctrinh_Kmai.DataBindings.Clear();
            this.txtGhichu.DataBindings.Clear();
            this.txtPer_Hoadon.DataBindings.Clear();
            this.dtNgay_Batdau.DataBindings.Clear();
            this.dtNgay_Ketthuc.DataBindings.Clear();
            this.chkGiam_Hoadon.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtMa_Ctrinh_Kmai.DataBindings.Add("EditValue", ds_Ctrinh_Kmai_Rent, ds_Ctrinh_Kmai_Rent.Tables[0].TableName + ".Ma_Ctrinh_Kmai");
                this.txtTen_Ctrinh_Kmai.DataBindings.Add("EditValue", ds_Ctrinh_Kmai_Rent, ds_Ctrinh_Kmai_Rent.Tables[0].TableName + ".Ten_Ctrinh_Kmai");
                this.txtGhichu.DataBindings.Add("EditValue", ds_Ctrinh_Kmai_Rent, ds_Ctrinh_Kmai_Rent.Tables[0].TableName + ".Ghichu");
                this.txtPer_Hoadon.DataBindings.Add("EditValue", ds_Ctrinh_Kmai_Rent, ds_Ctrinh_Kmai_Rent.Tables[0].TableName + ".Per_Hoadon");
                this.chkGiam_Hoadon.DataBindings.Add("EditValue", ds_Ctrinh_Kmai_Rent, ds_Ctrinh_Kmai_Rent.Tables[0].TableName + ".Giam_Hoadon");
                this.dtNgay_Batdau.DataBindings.Add("EditValue", ds_Ctrinh_Kmai_Rent, ds_Ctrinh_Kmai_Rent.Tables[0].TableName + ".Ngay_Batdau");
                this.dtNgay_Ketthuc.DataBindings.Add("EditValue", ds_Ctrinh_Kmai_Rent, ds_Ctrinh_Kmai_Rent.Tables[0].TableName + ".Ngay_Ketthuc");
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
            this.dgware_Ctrinh_Kmai.Enabled = !editTable;
            this.txtMa_Ctrinh_Kmai.Properties.ReadOnly = !editTable;
            this.txtTen_Ctrinh_Kmai.Properties.ReadOnly = !editTable;
            this.txtGhichu.Properties.ReadOnly = !editTable;
            this.txtPer_Hoadon.Properties.ReadOnly = !editTable;
            this.chkGiam_Hoadon.Properties.ReadOnly = !editTable;
            this.dtNgay_Batdau.Properties.ReadOnly = !editTable;
            this.dtNgay_Ketthuc.Properties.ReadOnly = !editTable;
            this.dgware_Ctrinh_Kmai_Chitiet.EmbeddedNavigator.Enabled = editTable;
            this.gvChuongtrinhKM_Chitiet.OptionsBehavior.Editable = editTable;
            this.gvChuongtrinhKM_Rent_Chitiet.OptionsBehavior.Editable = editTable;
            btnImport_FrExcel.Enabled = editTable;
        }

        public override void ResetText()
        {
            this.txtMa_Ctrinh_Kmai.EditValue = "";
            this.txtTen_Ctrinh_Kmai.EditValue = "";
            this.txtGhichu.EditValue = "";
            this.txtPer_Hoadon.EditValue = null;
            this.chkGiam_Hoadon.EditValue = null;
            this.dtNgay_Batdau.EditValue = objWareService.GetServerDateTime();
            this.dtNgay_Ketthuc.EditValue = objWareService.GetServerDateTime();
            this.ds_Ctrinh_Kmai_Chitiet = objWareService.Get_All_Ware_Ctrinh_Kmai_Chitiet_By_Ctrinh_Kmai(0).ToDataSet();
            this.ds_Ctrinh_Kmai_Rent_Chitiet = objWareService.Get_All_Ware_Ctrinh_Kmai_Rent_Chitiet_By_Ctrinh_Kmai(0).ToDataSet();
            this.dgware_Ctrinh_Kmai_Chitiet.DataSource = ds_Ctrinh_Kmai_Chitiet.Tables[0];
            this.dgware_Ctrinh_Kmai_Rent_Chitiet.DataSource = ds_Ctrinh_Kmai_Rent_Chitiet.Tables[0];
        }

        #endregion

        #region Event Override

        public object InsertObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Ctrinh_Kmai objWare_Ctrinh_Kmai = new Ecm.WebReferences.WareService.Ware_Ctrinh_Kmai();
                objWare_Ctrinh_Kmai.Id_Ctrinh_Kmai = -1;
                objWare_Ctrinh_Kmai.Ma_Ctrinh_Kmai = txtMa_Ctrinh_Kmai.EditValue;
                objWare_Ctrinh_Kmai.Ten_Ctrinh_Kmai = txtTen_Ctrinh_Kmai.EditValue;
                objWare_Ctrinh_Kmai.Ghichu = txtGhichu.EditValue;
                objWare_Ctrinh_Kmai.Ngay_Batdau = dtNgay_Batdau.EditValue;
                objWare_Ctrinh_Kmai.Ngay_Ketthuc = dtNgay_Ketthuc.EditValue;
                objWare_Ctrinh_Kmai.Kmai_Rent = true;
                if ("" + txtPer_Hoadon.EditValue != "")
                    objWare_Ctrinh_Kmai.Per_Hoadon = txtPer_Hoadon.EditValue;
                if ("" + chkGiam_Hoadon.EditValue != "")
                    objWare_Ctrinh_Kmai.Giam_Hoadon = chkGiam_Hoadon.EditValue;

                object identity = objWareService.Insert_Ware_Ctrinh_Kmai(objWare_Ctrinh_Kmai);
                if (identity != null)
                {
                    this.DoClickEndEdit(dgware_Ctrinh_Kmai_Chitiet); //dgware_Ctrinh_Kmai_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                    foreach (DataRow dr in ds_Ctrinh_Kmai_Chitiet.Tables[0].Rows)
                    {
                        dr["Id_Ctrinh_Kmai"] = identity;
                    }
                    foreach (DataRow dr in ds_Ctrinh_Kmai_Rent_Chitiet.Tables[0].Rows)
                    {
                        dr["Id_Ctrinh_Kmai"] = identity;
                    }
                    objWareService.Update_Ware_Ctrinh_Kmai_Chitiet_Collection(ds_Ctrinh_Kmai_Chitiet);
                    objWareService.Update_Ware_Ctrinh_Kmai_Rent_Chitiet_Collection(ds_Ctrinh_Kmai_Rent_Chitiet); // update CTKM Khách sạn
                }
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

        public object UpdateObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Ctrinh_Kmai objWare_Ctrinh_Kmai = new Ecm.WebReferences.WareService.Ware_Ctrinh_Kmai();
                objWare_Ctrinh_Kmai.Id_Ctrinh_Kmai = gvChuongtrinh_KM.GetFocusedRowCellValue("Id_Ctrinh_Kmai");
                objWare_Ctrinh_Kmai.Ma_Ctrinh_Kmai = txtMa_Ctrinh_Kmai.EditValue;
                objWare_Ctrinh_Kmai.Ten_Ctrinh_Kmai = txtTen_Ctrinh_Kmai.EditValue;
                objWare_Ctrinh_Kmai.Ghichu = txtGhichu.EditValue;
                objWare_Ctrinh_Kmai.Ngay_Batdau = dtNgay_Batdau.EditValue;
                objWare_Ctrinh_Kmai.Ngay_Ketthuc = dtNgay_Ketthuc.EditValue;
                objWare_Ctrinh_Kmai.Kmai_Rent = true;
                if ("" + txtPer_Hoadon.EditValue != "")
                    objWare_Ctrinh_Kmai.Per_Hoadon = txtPer_Hoadon.EditValue;
                if ("" + chkGiam_Hoadon.EditValue != "")
                    objWare_Ctrinh_Kmai.Giam_Hoadon = chkGiam_Hoadon.EditValue;

                objWareService.Update_Ware_Ctrinh_Kmai(objWare_Ctrinh_Kmai);
                this.DoClickEndEdit(dgware_Ctrinh_Kmai_Chitiet);
                foreach (DataRow dr in ds_Ctrinh_Kmai_Chitiet.Tables[0].Rows)
                {
                    if (dr.RowState == DataRowState.Added)
                        dr["Id_Ctrinh_Kmai"] = gvChuongtrinh_KM.GetFocusedRowCellValue("Id_Ctrinh_Kmai");
                }
                foreach (DataRow dr in ds_Ctrinh_Kmai_Rent_Chitiet.Tables[0].Rows)
                {
                    if (dr.RowState == DataRowState.Added)
                        dr["Id_Ctrinh_Kmai"] = gvChuongtrinh_KM.GetFocusedRowCellValue("Id_Ctrinh_Kmai");
                }
                objWareService.Update_Ware_Ctrinh_Kmai_Chitiet_Collection(ds_Ctrinh_Kmai_Chitiet);
                objWareService.Update_Ware_Ctrinh_Kmai_Rent_Chitiet_Collection(ds_Ctrinh_Kmai_Rent_Chitiet); // update CTKM Khách sạn
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
            Ecm.WebReferences.WareService.Ware_Ctrinh_Kmai objWare_Ctrinh_Kmai = new Ecm.WebReferences.WareService.Ware_Ctrinh_Kmai();
            objWare_Ctrinh_Kmai.Id_Ctrinh_Kmai = gvChuongtrinh_KM.GetFocusedRowCellValue("Id_Ctrinh_Kmai");
            return objWareService.Delete_Ware_Ctrinh_Kmai(objWare_Ctrinh_Kmai);
        }

        public override bool PerformAdd()
        {
            this.ChangeStatus(true);
            ClearDataBindings();
            this.ResetText();
            return true;
        }

        public override bool PerformEdit()
        {
            if (gvChuongtrinh_KM.GetFocusedRowCellValue("Id_Ctrinh_Kmai") == null)
                return false;
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
                htbControl1.Add(txtMa_Ctrinh_Kmai, lblMa_Ctrinh_Kmai.Text);
                htbControl1.Add(txtTen_Ctrinh_Kmai, lblTen_Ctrinh_Kmai.Text);
                htbControl1.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
                htbControl1.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);

                System.Collections.Hashtable htbControl_Ma = new System.Collections.Hashtable();
                htbControl_Ma.Add(txtMa_Ctrinh_Kmai, lblMa_Ctrinh_Kmai.Text);

                System.Collections.Hashtable htbControl_Ten = new System.Collections.Hashtable();
                htbControl_Ten.Add(txtTen_Ctrinh_Kmai, lblTen_Ctrinh_Kmai.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(htbControl1))
                    return false;

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                    return false;
                if (gvChuongtrinhKM_Chitiet.RowCount == 0)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Vui lòng nhập hàng hóa", "Thông báo");
                    return false;
                }
                this.DoClickEndEdit(dgware_Ctrinh_Kmai_Chitiet); //dgware_Ctrinh_Kmai_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                try
                {
                    Constraint constraint = new UniqueConstraint("constraint1",
                            new DataColumn[] { ds_Ctrinh_Kmai_Chitiet.Tables[0].Columns["Ma_Ql"] }, false);
                    ds_Ctrinh_Kmai_Chitiet.Tables[0].Constraints.Clear();
                    ds_Ctrinh_Kmai_Chitiet.Tables[0].Constraints.Add(constraint);
                }
                catch (Exception ex)
                {
                    if (ex.ToString().IndexOf("These columns don't currently have unique values") != -1)
                    {
                        GoobizFrame.Windows.Forms.MessageDialog.Show("Hàng hóa và đơn vị tính thêm vào bị trùng, vui lòng nhập lại");
                        return false;
                    }
                }
                DataRow[] dtr = null;
                this.ds_Ctrinh_Kmai_Chitiet_ByDate = objWareService.Get_All_Ware_Ctrinh_Kmai_Chitiet_ByDate(dtNgay_Batdau.DateTime).ToDataSet();
                for (int i = 0; i < gvChuongtrinhKM_Chitiet.RowCount; i++)  // chek xem hàng hóa đã được dùng cho chương trình KM khác hay chưa
                {
                    if (ds_Ctrinh_Kmai_Chitiet_ByDate.Tables.Count > 0 && ds_Ctrinh_Kmai_Chitiet_ByDate.Tables[0].Rows.Count > 0)
                    {
                        DataRow row = gvChuongtrinhKM_Chitiet.GetDataRow(i);
                        dtr = ds_Ctrinh_Kmai_Chitiet_ByDate.Tables[0].Select("Ma_Ql = '" + gvChuongtrinhKM_Chitiet.GetRowCellValue(i, gvChuongtrinhKM_Chitiet.Columns["Ma_Ql"]) + " '");

                        if (gvChuongtrinhKM_Chitiet.GetDataRow(i).RowState == DataRowState.Modified)
                            if (dtr.Length >= 1)
                                if (!dtr[0]["Id_Ctrinh_Kmai_Chitiet"].Equals(gvChuongtrinhKM_Chitiet.GetRowCellValue(i, gvChuongtrinhKM_Chitiet.Columns["Id_Ctrinh_Kmai_Chitiet"])))
                                {
                                    GoobizFrame.Windows.Forms.MessageDialog.Show("Ngành hàng " + gvChuongtrinhKM_Chitiet.GetRowCellValue(i, gvChuongtrinhKM_Chitiet.Columns["Ten_Hanghoa_Ban"]) + " đã dùng cho chương trình Khuyến mãi khác, vui lòng kiểm tra lại");
                                    gvChuongtrinhKM_Chitiet.FocusedRowHandle = i;
                                    return false;
                                }
                        if (gvChuongtrinhKM_Chitiet.GetDataRow(i).RowState == DataRowState.Added)
                            if (dtr.Length >= 1)
                            {
                                GoobizFrame.Windows.Forms.MessageDialog.Show("Ngành hàng " + gvChuongtrinhKM_Chitiet.GetRowCellValue(i, gvChuongtrinhKM_Chitiet.Columns["Ten_Hanghoa_Ban"]) + " đã dùng cho chương trình Khuyến mãi khác, vui lòng kiểm tra lại");
                                gvChuongtrinhKM_Chitiet.FocusedRowHandle = i;
                                return false;
                            }
                        if (dtr.Length > 1)
                        {
                            GoobizFrame.Windows.Forms.MessageDialog.Show("Ngành hàng " + gvChuongtrinhKM_Chitiet.GetRowCellValue(i, gvChuongtrinhKM_Chitiet.Columns["Ten_Hanghoa_Ban"]) + " đã dùng cho chương trình Khuyến mãi khác, vui lòng kiểm tra lại");
                            gvChuongtrinhKM_Chitiet.FocusedRowHandle = i;
                            return false;
                        }
                    }
                }
                System.Collections.Hashtable htbGrid = new System.Collections.Hashtable();
                htbGrid.Add(gvChuongtrinhKM_Chitiet.Columns["Per_Dongia"], "");
                if (chkGiam_Hoadon.Checked)
                    if (txtPer_Hoadon.Text != "" && gvChuongtrinhKM_Chitiet.RowCount > 0)
                    {
                        if (Convert.ToDouble(txtPer_Hoadon.EditValue) > 100)
                        {
                            GoobizFrame.Windows.Forms.MessageDialog.Show("Giảm hóa đơn nhập không đúng, vui lòng nhập lại");
                            txtPer_Hoadon.EditValue = null;
                            return false;
                        }
                    }
                    else
                    {
                        GoobizFrame.Windows.Forms.MessageDialog.Show("Thông tin nhập chưa chính xác, bạn phải nhập giảm hóa đơn hoặc bỏ chọn 'Giảm hóa đơn'. ");
                        return false;
                    }
                htbGrid.Add(gvChuongtrinhKM_Chitiet.Columns["Ma_Ql"], "");
                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(htbGrid, gvChuongtrinhKM_Chitiet))
                    return false;

                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                {
                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htbControl_Ma, ds_Ctrinh_Kmai_Rent, "Ma_Ctrinh_Kmai"))
                        return false;
                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htbControl_Ten, ds_Ctrinh_Kmai_Rent, "Ten_Ctrinh_Kmai"))
                        return false;
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    ds_Ctrinh_Kmai_Rent = GoobizFrame.Windows.MdiUtils.Validator.datasetFillter(ds_Ctrinh_Kmai_Rent, "Id_Ctrinh_Kmai = " + gvChuongtrinh_KM.GetFocusedRowCellValue("Id_Ctrinh_Kmai"));
                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htbControl_Ma, ds_Ctrinh_Kmai_Rent, "Ma_Ctrinh_Kmai"))
                        return false;
                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htbControl_Ten, ds_Ctrinh_Kmai_Rent, "Ten_Ctrinh_Kmai"))
                        return false;
                    success = (bool)this.UpdateObject();
                }
                if (success)
                    this.DisplayInfo();

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
            if (gvChuongtrinh_KM.GetFocusedRowCellValue("Id_Ctrinh_Kmai") == null)
                return false;
            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Ctrinh_Kmai"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Ctrinh_Kmai")   }) == DialogResult.Yes)
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

        #endregion

        #region events

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.DisplayInfo2();
        }

        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Ma_Ql")
            {
                DataRow focus_row = gvChuongtrinhKM_Chitiet.GetDataRow(gvChuongtrinhKM_Chitiet.FocusedRowHandle);
                //focus_row["Id_Nhom_Hanghoa"] = ((System.Data.DataRowView)gridLookUpEdit_Ma_Hanghoa.GetDataSourceRowByKeyValue(e.Value))["Id_Nhom_Hanghoa"];
                //focus_row["Id_Loai_Hanghoa"] = ((System.Data.DataRowView)gridLookUpEdit_Ma_Hanghoa.GetDataSourceRowByKeyValue(e.Value))["Id_Loai_Hanghoa"];
                focus_row["Id_Hanghoa_Ban"] = ((System.Data.DataRowView)gridLookUpEdit_Ma_Hanghoa.GetDataSourceRowByKeyValue(e.Value))["Id_Hanghoa"];
            }
            if (e.Column.FieldName == "Id_Hanghoa_Ban")
            {
                if (e.Value.ToString() != "")
                {
                    gvChuongtrinhKM_Chitiet.SetFocusedRowCellValue(gvChuongtrinhKM_Chitiet.Columns["Ten_Hanghoa_Ban"]
                        , ((System.Data.DataRowView)gridLookUpEdit_Ma_Hanghoa.GetDataSourceRowByKeyValue(e.Value))["Ten_Hanghoa_Ban"]);
                    if (chkGiam_Hoadon.Checked)
                        gvChuongtrinhKM_Chitiet.SetFocusedRowCellValue(gvChuongtrinhKM_Chitiet.Columns["Per_Dongia"], txtPer_Hoadon.EditValue);
                }
            }
            if (e.Column.FieldName == "Per_Dongia")
            {
                //object value = gridView4.GetFocusedRowCellValue(gridView4.Columns["Per_Dongia"]);
                //if (value.ToString() != "")
                //    if (value.ToString().Length <= 3)
                //    {
                //        if (Convert.ToInt32(value) > 100 || Convert.ToInt32(value) < 0)
                //        {
                //             GoobizFrame.Windows.Forms.MessageDialog.Show("Giảm hóa đơn nhập không đúng, vui lòng nhập lại");
                //            gridView4.CancelUpdateCurrentRow();
                //            return;
                //        }
                //    }
                //    else
                //    {
                //         GoobizFrame.Windows.Forms.MessageDialog.Show("Giảm hóa đơn nhập không đúng, vui lòng nhập lại");
                //        gridView4.CancelUpdateCurrentRow();
                //        return;
                //    }
            }
        }

        private void chkGiam_Hoadon_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGiam_Hoadon.Checked)
                if (txtPer_Hoadon.Text != "" && gvChuongtrinhKM_Chitiet.RowCount > 0)
                {
                    if (Convert.ToDouble(txtPer_Hoadon.EditValue) <= 100)
                        setPer_Dongia();
                    else
                    {
                        GoobizFrame.Windows.Forms.MessageDialog.Show("Giảm hóa đơn nhập không đúng, vui lòng nhập lại");
                        return;
                    }
                }
        }

        private void gridText_Dongia_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if (e.NewValue.ToString() == "")
                {
                    gvChuongtrinhKM_Chitiet.SetFocusedRowCellValue("Per_Dongia", null);
                    e.Cancel = true;
                    return;
                }
                if (Convert.ToInt32(e.NewValue) > 100)
                    e.Cancel = true;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Giảm hóa đơn nhập không đúng, vui lòng nhập lại");
                return;
            }
        }

        private void btnImport_FrExcel_Click(object sender, EventArgs e)
        {
            Frmware_Ctrinh_Kmai_FrExcel frmware_Ctrinh_Kmai_FrExcel = new Frmware_Ctrinh_Kmai_FrExcel();
            frmware_Ctrinh_Kmai_FrExcel.Text = "Import Hàng hóa từ file Excel";
            frmware_Ctrinh_Kmai_FrExcel.ShowDialog();

            if (frmware_Ctrinh_Kmai_FrExcel.ds_Collection != null && frmware_Ctrinh_Kmai_FrExcel.ds_Collection.Tables.Count > 0)
            {
                foreach (DataRow dr in frmware_Ctrinh_Kmai_FrExcel.ds_Collection.Tables[0].Rows)
                {
                    DataRow ndr = ds_Ctrinh_Kmai_Chitiet.Tables[0].NewRow();
                    foreach (DataColumn col in ds_Ctrinh_Kmai_Chitiet.Tables[0].Columns)
                        try
                        {
                            ndr[col.ColumnName] = dr[col.ColumnName];
                        }
                        catch (Exception ex) { continue; }
                    ds_Ctrinh_Kmai_Chitiet.Tables[0].Rows.Add(ndr);
                }
            }
        }

        private void txtPer_Hoadon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && chkGiam_Hoadon.Checked && txtPer_Hoadon.Text != "")
            {
                if (Convert.ToDouble(txtPer_Hoadon.EditValue) <= 100)
                    setPer_Dongia();
                else
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Giảm hóa đơn nhập không đúng, vui lòng nhập lại");
                    return;
                }
            }
            if (e.KeyCode == Keys.Delete)
                txtPer_Hoadon.EditValue = null;
        }

        private void gridView4_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (FormState == GoobizFrame.Windows.Forms.FormState.View)
                return;
            ColumnView view = sender as ColumnView;
            GridColumn columnPer_Dongia = view.Columns["Per_Dongia"];
            GridColumn columnId_Hanghoa = view.Columns["Id_Hanghoa_Ban"];
            object per_dongia = view.GetRowCellValue(e.RowHandle, columnPer_Dongia);
            object id_hanghoa = view.GetRowCellValue(e.RowHandle, columnId_Hanghoa);
            if (per_dongia.ToString() != "")
            {
                if (Convert.ToInt32(per_dongia).ToString().Length > 3)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Giảm hóa đơn nhập không đúng, vui lòng nhập lại");
                    gvChuongtrinhKM_Chitiet.SetRowCellValue(e.RowHandle, "Per_Dongia", null);
                    return;
                }
                if (Convert.ToInt32(per_dongia) > 100 || Convert.ToInt32(per_dongia) < 0)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Giảm hóa đơn nhập không đúng, vui lòng nhập lại");
                    gvChuongtrinhKM_Chitiet.CancelUpdateCurrentRow();
                    return;
                }
            }
        }

        private void txtPer_Hoadon_EditValueChanged(object sender, EventArgs e)
        {
            if (chkGiam_Hoadon.Checked && txtPer_Hoadon.EditValue != null
                && this.FormState != GoobizFrame.Windows.Forms.FormState.View)
                setPer_Dongia();
        }

        private void gridLookUpEdit_Ma_Hanghoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            //{
            //    Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Tree Frmware_Dm_Hanghoa_Tree = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Tree();
            //    Frmware_Dm_Hanghoa_Tree.Text = "Hàng hóa";
            //    GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(Frmware_Dm_Hanghoa_Tree);
            //    Frmware_Dm_Hanghoa_Tree.ShowDialog();
            //    if (Frmware_Dm_Hanghoa_Tree.SelectedRow != null)
            //    {
            //        DataRow focus_row = gvChuongtrinhKM_Chitiet.GetDataRow(gvChuongtrinhKM_Chitiet.FocusedRowHandle);
            //        focus_row["Ma_Ql"] = Frmware_Dm_Hanghoa_Tree.SelectedRow["Ma_Ql"];
            //    }
            //}
        }

        private void txtPer_Hoadon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-')
                e.Handled = true;
        }

        private void gridLookupEdit_Class_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private void gridLookupEdit_RentLevel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                var dialog = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowExternalDialog("Ecm.MasterTables.dll",
                    "Ecm.MasterTables.Forms.Bar.Frmbar_Dm_Rentlevel",
                    this,
                    null,
                    null,
                    false);

                var dsBar_Dm_Rentlevel = objMasterService.Get_All_Bar_Dm_Rentlevel_Collection().ToDataSet();
                gridLookupEdit_RentLevel.DataSource = dsBar_Dm_Rentlevel.Tables[0];
            }
        }

        #endregion
    }
}

