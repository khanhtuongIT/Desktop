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
    public partial class Frmware_Congnothu_Dauky : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Collection = new DataSet();
        object _id_congnothu;

        #region InitializeComponent

        public Frmware_Congnothu_Dauky()
        {
            InitializeComponent();
            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.DisplayInfo();
            //dtNgay_Chungtu.Properties.MinValue = new DateTime(2000, 01, 01);
        }
        #endregion

        #region Event Override

        public override void DisplayInfo()
        {
            try
            {
                //Get data Get_All_Ware_Dm_Doituong
                DataSet dsDoituong = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
                //lookUpEdit_Khachhang.Properties.DataSource = dsDoituong.Tables[0];
                gridLookUp_Ma_Khachhang.DataSource = dsDoituong.Tables[0];
                gridLookUp_Teb_Khachhang.DataSource = dsDoituong.Tables[0];

                dsDoituong = objMasterService.Get_All_Ware_Dm_Nhacungcap().ToDataSet();
                gridLookupEdit_MaNcc.DataSource = dsDoituong.Tables[0];
                gridLookupEdit_TenNCC.DataSource = dsDoituong.Tables[0];

                //Get data Ware_Congnothu_Dauky
                ds_Collection = objWareService.Get_All_Ware_Congnothu_Dauky().ToDataSet();
                dgware_Congnothu_Dauky.DataSource = ds_Collection;
                dgware_Congnothu_Dauky.DataMember = ds_Collection.Tables[0].TableName;

                this.Data = ds_Collection;
                this.GridControl = dgware_Congnothu_Dauky;
                this.DataBindingControl();

                this.ChangeStatus(false);
                this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }




        //public object InsertObject()
        //{
        //    Ecm.WebReferences.WareService.Ware_Congnothu_Dauky objWare_Congnothu_Dauky = new Ecm.WebReferences.WareService.Ware_Congnothu_Dauky();
        //    objWare_Congnothu_Dauky.Id_Congnothu_Dauky = -1;
        //    objWare_Congnothu_Dauky.Ghichu = txtGhichu.EditValue;

        //    if ("" + txtSotien_No.EditValue != "")
        //        objWare_Congnothu_Dauky.Sotien_No = txtSotien_No.EditValue;
        //    if ("" + txtSotien_Co.EditValue != "")
        //        objWare_Congnothu_Dauky.Sotien_Co = txtSotien_Co.EditValue;

        //    if ("" + lookUpEdit_Khachhang.EditValue != "")
        //        objWare_Congnothu_Dauky.Id_Khachhang = lookUpEdit_Khachhang.EditValue;

        //    if ("" + txtChungtu_Goc.EditValue != "")
        //        objWare_Congnothu_Dauky.Chungtu_goc = txtChungtu_Goc.EditValue;

        //    if ("" + dtNgay_Chungtu.EditValue != "")
        //        objWare_Congnothu_Dauky.Ngay_chungtu = dtNgay_Chungtu.EditValue;

        //    objWare_Congnothu_Dauky.Id_tiente = null;
        //    objWare_Congnothu_Dauky.Tygia = null;
        //    objWare_Congnothu_Dauky.Sotien_quydoi = null;
        //    return objWareService.Insert_Ware_Congnothu_Dauky(objWare_Congnothu_Dauky);
        //}

        //public object UpdateObject()
        //{
        //    Ecm.WebReferences.WareService.Ware_Congnothu_Dauky objWare_Congnothu_Dauky = new Ecm.WebReferences.WareService.Ware_Congnothu_Dauky();
        //    objWare_Congnothu_Dauky.Id_Congnothu_Dauky = txtcongno_thudauky.EditValue;
        //    objWare_Congnothu_Dauky.Ghichu = txtGhichu.EditValue;

        //    if ("" + txtSotien_No.EditValue != "")
        //        objWare_Congnothu_Dauky.Sotien_No = txtSotien_No.EditValue;
        //    if ("" + txtSotien_Co.EditValue != "")
        //        objWare_Congnothu_Dauky.Sotien_Co = txtSotien_Co.EditValue;

        //    if ("" + lookUpEdit_Khachhang.EditValue != "")
        //        objWare_Congnothu_Dauky.Id_Khachhang = lookUpEdit_Khachhang.EditValue;

        //    if ("" + txtChungtu_Goc.EditValue != "")
        //        objWare_Congnothu_Dauky.Chungtu_goc = txtChungtu_Goc.EditValue;

        //    if ("" + dtNgay_Chungtu.EditValue != "")
        //        objWare_Congnothu_Dauky.Ngay_chungtu = dtNgay_Chungtu.EditValue;
        //    objWare_Congnothu_Dauky.Id_tiente = null;
        //    objWare_Congnothu_Dauky.Tygia = null;
        //    objWare_Congnothu_Dauky.Sotien_quydoi = null;
        //    return objWareService.Update_Ware_Congnothu_Dauky(objWare_Congnothu_Dauky);
        //}

        //public object DeleteObject()
        //{
        //    Ecm.WebReferences.WareService.Ware_Congnothu_Dauky objWare_Congnothu_Dauky = new Ecm.WebReferences.WareService.Ware_Congnothu_Dauky();
        //    objWare_Congnothu_Dauky.Id_Congnothu_Dauky = gridView1.GetFocusedRowCellValue("Id_Congnothu_Dauky");
        //    return objWareService.Delete_Ware_Congnothu_Dauky(objWare_Congnothu_Dauky);
        //}

        public override bool PerformAdd()
        {
            ClearDataBindings();
            this.ChangeStatus(true);
            this.ResetText();
            return true;
        }

        public override bool PerformEdit()
        {
            _id_congnothu = gridView1.GetFocusedRowCellValue("Id_Congnothu_Dauky");
            if ("" + _id_congnothu != "")
            {
                this.ChangeStatus(true);
                //this.txtTen_Khachhang.Properties.ReadOnly = true;
                //this.lookUpEdit_Khachhang.Properties.ReadOnly = true;
                return true;
            }
            return false;
        }

        public override bool PerformCancel()
        {
            ResetText();
            this.DisplayInfo();
            this.ChangeStatus(false);
            return true;
        }

        public override bool PerformSave()
        {
            try
            {
                bool success = false;
                GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
                //hashtableControls.Add(lookUpEdit_Khachhang, lblMa_Khachhang.Text);
                //hashtableControls.Add(txtChungtu_Goc, lblChungtu_Goc.Text);
                //hashtableControls.Add(txtSotien_No, lblSotien.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                //if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                //{
                //    success = (bool)this.InsertObject();
                //}
                //else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                //{
                //    success = (bool)this.UpdateObject();
                //}

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

        public override bool PerformSaveChanges()
        {
            //GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            ////hashtableControls.Add(gridView1.Columns["Sotien"], "");
            //hashtableControls.Add(gridView1.Columns["Id_Khachhang"], "");

            //if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
            //    return false;

            try
            {
                this.DoClickEndEdit(dgware_Congnothu_Dauky);
                DataSet dsChanged = ds_Collection.GetChanges();
                objWareService.Update_Ware_Congnothu_Dauky_Collection2(dsChanged);
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#endif
                //Error here
                GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                return false;
            }
            this.DisplayInfo();
            return true;
        }

        public override bool PerformDelete()
        {
            _id_congnothu = gridView1.GetFocusedRowCellValue("Id_Congnothu_Dauky");
            if ("" + _id_congnothu != "")
            {
                if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
                 GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Congnothu_Dauky"),
                 GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Congnothu_Dauky")   }) == DialogResult.Yes)
                {
                    try
                    {
                        //this.DeleteObject();
                    }
                    catch (Exception ex)
                    {
                        GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                    }
                    this.DisplayInfo();
                }
                return base.PerformDelete();
            }
            return false;
        }

        public override object PerformSelectOneObject()
        {
            Ecm.WebReferences.WareService.Ware_Congnothu_Dauky ware_Congnothu_Dauky = new Ecm.WebReferences.WareService.Ware_Congnothu_Dauky();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Collection.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    ware_Congnothu_Dauky.Id_Congnothu_Dauky = dr["Id_Congnothu_Dauky"];
                    ware_Congnothu_Dauky.Sotien_No = dr["Sotien_No"];
                    ware_Congnothu_Dauky.Sotien_Co = dr["Sotien_Co"];
                    ware_Congnothu_Dauky.Ghichu = dr["Ghichu"];
                    ware_Congnothu_Dauky.Id_Khachhang = dr["Id_Khachhang"];
                }
                this.Dispose();
                this.Close();
                return ware_Congnothu_Dauky;
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

        private void gridLookUp_Ma_Khachhang_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            //gridLookUp_Ma_Khachhang.show
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridView1.FocusedColumn.VisibleIndex == gridView1.VisibleColumns.Count - 1
               && "" + gridView1.GetFocusedRowCellValue("Id_Khachhang") != "" && gridView1.FocusedRowHandle == gridView1.RowCount - 3)
                gridView1.AddNewRow();
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView1.SetFocusedRowCellValue("Ngay_chungtu", new DateTime(2015, 10, 1));
        }

        #region Event

        //private void lookUpEdit_Khachhang_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (lookUpEdit_Khachhang.EditValue != null)
        //        txtTen_Khachhang.EditValue = lookUpEdit_Khachhang.GetColumnValue("Ten_Khachhang");
        //}

        //private void txtChungtu_Goc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{
        //    if (lookUpEdit_Khachhang.EditValue != null)
        //    {
        //        Ecm.Ware.Forms.Frmware_Hdbanhang_Dialog _Frmware_Hdbanhang_Dialog = new Frmware_Hdbanhang_Dialog();

        //        _Frmware_Hdbanhang_Dialog.Text = @"Chọn hóa đơn";
        //        _Frmware_Hdbanhang_Dialog.loadDS_Hoadon(lookUpEdit_Khachhang.EditValue);
        //        _Frmware_Hdbanhang_Dialog.ShowDialog();

        //        if (_Frmware_Hdbanhang_Dialog.drHdbanhang != null)
        //        {
        //            txtChungtu_Goc.EditValue = _Frmware_Hdbanhang_Dialog.drHdbanhang["Sochungtu"];
        //            dtNgay_Chungtu.EditValue = _Frmware_Hdbanhang_Dialog.drHdbanhang["Ngay_Chungtu"];
        //            txtSotien_No.EditValue = _Frmware_Hdbanhang_Dialog.drHdbanhang["Sotien"];
        //        }
        //    }
        //    else
        //    {
        //        GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn khách hàng!");
        //        return;
        //    }

        //}

        #endregion

    }
}

