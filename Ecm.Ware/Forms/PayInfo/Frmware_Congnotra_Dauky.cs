using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Congnotra_Dauky :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Collection = new DataSet();
        object _id_congnotra;

        #region Initialize
        public Frmware_Congnotra_Dauky()
        {
            InitializeComponent();
            this.DisplayInfo();
            dtNgay_Chungtu.Properties.MinValue = new DateTime(2000, 01, 01);
        }
        #endregion

        #region Event Override

        public override void DisplayInfo()
        {
            try
            {
                ////Get data Ware_Dm_Nhacungcap
                //DataSet dsWare_Dm_Nhacungcap = objMasterService.Get_All_Ware_Dm_Nhacungcap();
                //lookUpEdit_Nhacungcap.Properties.DataSource = dsWare_Dm_Nhacungcap.Tables[0];
                //gridLookUp_Ma_Nhacungcap.DataSource = dsWare_Dm_Nhacungcap.Tables[0];
                //gridLookUp_Ten_Nhacungcap.DataSource = dsWare_Dm_Nhacungcap.Tables[0];


                //Get data Get_All_Ware_Dm_Doituong
                DataSet dsDoituong = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
                lookUpEdit_Nhacungcap.Properties.DataSource = dsDoituong.Tables[0];
                gridLookUp_Ma_Nhacungcap.DataSource = dsDoituong.Tables[0];
                gridLookUp_Ten_Nhacungcap.DataSource = dsDoituong.Tables[0];


                DataSet dsTiente = objMasterService.Get_All_Ware_Dm_Tiente().ToDataSet();
                lookUpEdit_Tiente.Properties.DataSource = dsTiente.Tables[0];
                gridLookUp_Tiente.DataSource = dsTiente.Tables[0];

                //Get data Ware_Congnotra_Dauky
                ds_Collection = objWareService.Get_All_Ware_Congnotra_Dauky().ToDataSet();
                dgware_Congnotra_Dauky.DataSource = ds_Collection;
                dgware_Congnotra_Dauky.DataMember = ds_Collection.Tables[0].TableName;

                this.Data = ds_Collection;
                this.GridControl = dgware_Congnotra_Dauky;

                this.DataBindingControl();

                this.ChangeStatus(false);

                this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif

                //// GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }

        }

        void ClearDataBindings()
        {
            lookUpEdit_Nhacungcap.DataBindings.Clear();
            txtChungtu_Goc.DataBindings.Clear();
            dtNgay_Chungtu.DataBindings.Clear();
            txtSotien.DataBindings.Clear();
            lookUpEdit_Tiente.DataBindings.Clear();
            txtTygia.DataBindings.Clear();
            txtSotien_Quydoi.DataBindings.Clear();
            txtGhichu.DataBindings.Clear();
        }

        public void DataBindingControl()
        {
            try
            {
                ClearDataBindings();

                lookUpEdit_Nhacungcap.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Khachhang");
                txtChungtu_Goc.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Chungtu_Goc");
                dtNgay_Chungtu.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ngay_Chungtu");
                txtSotien.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Sotien");
                lookUpEdit_Tiente.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Tiente");
                txtTygia.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Tygia");
                txtSotien_Quydoi.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Sotien_Quydoi");
                txtGhichu.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ghichu");
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif

                //// GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }
        }

        public void ChangeStatus(bool editable)
        {

            lookUpEdit_Nhacungcap.Properties.ReadOnly = !editable;
            txtTen_Nhacungcap.Properties.ReadOnly = true;
            txtChungtu_Goc.Properties.ReadOnly = !editable;
            lookUpEdit_Tiente.Properties.ReadOnly = !editable;
            txtTygia.Properties.ReadOnly = !editable;
            txtGhichu.Properties.ReadOnly = !editable;
            txtSotien.Properties.ReadOnly = !editable;
            txtSotien_Quydoi.Properties.ReadOnly = true;
            dtNgay_Chungtu.Properties.ReadOnly = !editable;
            dgware_Congnotra_Dauky.Enabled = !editable; 

        }

        public void ResetText()
        {
            lookUpEdit_Nhacungcap.EditValue = null;
            txtTen_Nhacungcap.Text = "";
            txtChungtu_Goc.Text = "";
            dtNgay_Chungtu.EditValue = null;
            txtSotien.Text = "";
            lookUpEdit_Tiente.EditValue = null;
            txtTygia.Text = "";
            txtSotien_Quydoi.Text = "";
            txtGhichu.Text = "";
        }

        public object InsertObject()
        {
            Ecm.WebReferences.WareService.Ware_Congnotra_Dauky objWare_Congnotra_Dauky = new Ecm.WebReferences.WareService.Ware_Congnotra_Dauky();
            objWare_Congnotra_Dauky.Id_Khachhang = lookUpEdit_Nhacungcap.EditValue;
            if (txtChungtu_Goc.Text != "")
                objWare_Congnotra_Dauky.Chungtu_Goc = txtChungtu_Goc.Text;
            objWare_Congnotra_Dauky.Ngay_Chungtu = dtNgay_Chungtu.EditValue;
            objWare_Congnotra_Dauky.Sotien = Convert.ToDecimal(txtSotien.Text);
            objWare_Congnotra_Dauky.Id_Tiente = lookUpEdit_Tiente.EditValue;
            if ("" + txtTygia.Text != "")
                objWare_Congnotra_Dauky.Tygia = Convert.ToDecimal(txtTygia.Text);
            if ("" + txtSotien_Quydoi.Text != "")
                objWare_Congnotra_Dauky.Sotien_Quydoi = Convert.ToDecimal(txtSotien_Quydoi.Text);
            objWare_Congnotra_Dauky.Ghichu = txtGhichu.Text;
            return objWareService.Insert_Ware_Congnotra_Dauky(objWare_Congnotra_Dauky);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.WareService.Ware_Congnotra_Dauky objWare_Congnotra_Dauky = new Ecm.WebReferences.WareService.Ware_Congnotra_Dauky();
            objWare_Congnotra_Dauky.Id_Congnotra_Dauky = gridView1.GetFocusedRowCellValue("Id_Congnotra_Dauky");
            objWare_Congnotra_Dauky.Id_Khachhang = lookUpEdit_Nhacungcap.EditValue;
            if (txtChungtu_Goc.Text != "")
                objWare_Congnotra_Dauky.Chungtu_Goc = txtChungtu_Goc.Text; objWare_Congnotra_Dauky.Ngay_Chungtu = dtNgay_Chungtu.EditValue;
            objWare_Congnotra_Dauky.Sotien =  Convert.ToDecimal(txtSotien.Text);
            objWare_Congnotra_Dauky.Id_Tiente = lookUpEdit_Tiente.EditValue;
            if ("" + txtTygia.Text != "")
                objWare_Congnotra_Dauky.Tygia = Convert.ToDecimal(txtTygia.Text);
            if ("" + txtSotien_Quydoi.Text != "")
                objWare_Congnotra_Dauky.Sotien_Quydoi = Convert.ToDecimal(txtSotien_Quydoi.Text);
            objWare_Congnotra_Dauky.Ghichu = txtGhichu.Text;

            return objWareService.Update_Ware_Congnotra_Dauky(objWare_Congnotra_Dauky);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.WareService.Ware_Congnotra_Dauky objWare_Congnotra_Dauky = new Ecm.WebReferences.WareService.Ware_Congnotra_Dauky();
            objWare_Congnotra_Dauky.Id_Congnotra_Dauky = gridView1.GetFocusedRowCellValue("Id_Congnotra_Dauky");

            return objWareService.Delete_Ware_Congnotra_Dauky(objWare_Congnotra_Dauky);
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
            if("" + _id_congnotra != "")
            {
                this.ChangeStatus(true);
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

                 GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(lookUpEdit_Nhacungcap, lblMa_Nhacungcap.Text);
                //hashtableControls.Add(txtChungtu_Goc, lblChungtu_Goc.Text);
                hashtableControls.Add(dtNgay_Chungtu, lblNgay_Chungtu.Text);
                hashtableControls.Add(txtSotien,lblSotien.Text);
                hashtableControls.Add(lookUpEdit_Tiente, lblTiente.Text);
                hashtableControls.Add(txtTygia, lblTygia.Text);

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Add)
                {
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    success = (bool)this.UpdateObject();
                }

                if (success)
                {
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

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Chungtu_Goc"], "");
            hashtableControls.Add(gridView1.Columns["Ngay_Chungtu"], "");
            hashtableControls.Add(gridView1.Columns["Sotien"], "");
            hashtableControls.Add(gridView1.Columns["Id_Nhacungcap"], "");

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                this.DoClickEndEdit(dgware_Congnotra_Dauky); //dgware_Congnotra_Dauky.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                objWareService.Update_Ware_Congnotra_Dauky_Collection(this.ds_Collection);
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
            if("" + _id_congnotra != "")
            {
                if ( GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
                 GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Congnotra_Dauky"),
                 GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Congnotra_Dauky")   }) == DialogResult.Yes)
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
            return false;
        }

        public override object PerformSelectOneObject()
        {
            Ecm.WebReferences.WareService.Ware_Congnotra_Dauky ware_Congnotra_Dauky = new Ecm.WebReferences.WareService.Ware_Congnotra_Dauky();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Collection.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    ware_Congnotra_Dauky.Id_Congnotra_Dauky = dr["Id_Congnotra_Dauky"];
                    ware_Congnotra_Dauky.Sotien_Quydoi = dr["Sotien"];
                    ware_Congnotra_Dauky.Ghichu = dr["Ghichu"];
                    ware_Congnotra_Dauky.Id_Khachhang = dr["Id_Khachhang"];
                }
                this.Dispose();
                this.Close();
                return ware_Congnotra_Dauky;
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

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Id_Nhacungcap"];
            this.addnewrow_clicked = true;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.DoClickEndEdit(dgware_Congnotra_Dauky); //this.dgware_Congnotra_Dauky.EmbeddedNavigator.Buttons.EndEdit.DoClick();
        }

        private void lookUpEdit_Nhacungcap_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit_Nhacungcap.EditValue != null)
                txtTen_Nhacungcap.EditValue = lookUpEdit_Nhacungcap.GetColumnValue("Ten_Khachhang");
        }

        private void txtChungtu_Goc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
                {
                    if ("" + lookUpEdit_Nhacungcap.EditValue == "")
                    {
                         GoobizFrame.Windows.Forms.MessageDialog.Show("Vui lòng chọn nhà cung cấp.");
                        return;
                    }

                    Frmware_Hdmuahang _Frmware_Hdmuahang = new Frmware_Hdmuahang();
                    _Frmware_Hdmuahang.StartPosition = FormStartPosition.CenterScreen;
                    _Frmware_Hdmuahang.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    _Frmware_Hdmuahang.item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    _Frmware_Hdmuahang.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    _Frmware_Hdmuahang.item_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    _Frmware_Hdmuahang.item_Cancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    _Frmware_Hdmuahang.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    _Frmware_Hdmuahang.Load_Hdmuahang_ByNhacungcap(lookUpEdit_Nhacungcap.EditValue);
                    _Frmware_Hdmuahang.ShowDialog();

                    if (_Frmware_Hdmuahang.dr_Hdmuahang != null)
                    {
                        txtChungtu_Goc.EditValue = _Frmware_Hdmuahang.dr_Hdmuahang["Sochungtu"];
                        dtNgay_Chungtu.EditValue = _Frmware_Hdmuahang.dr_Hdmuahang["Ngay_Chungtu"];
                        if ("" + _Frmware_Hdmuahang.dr_Hdmuahang["Sotien"] != "" && "" + _Frmware_Hdmuahang.dr_Hdmuahang["Sotien_Thanhtoan"] != "")
                            txtSotien.EditValue = Convert.ToDecimal(_Frmware_Hdmuahang.dr_Hdmuahang["Sotien"]) - Convert.ToDecimal(_Frmware_Hdmuahang.dr_Hdmuahang["Sotien_Thanhtoan"]);
                        else if ("" + _Frmware_Hdmuahang.dr_Hdmuahang["Sotien"] != "")
                            txtSotien.EditValue = Convert.ToDecimal(_Frmware_Hdmuahang.dr_Hdmuahang["Sotien"]);

                        //if ("" + Frmware_Hdmuahang.dr_Hdmuahang["Tongtien"] != "" && "" + Frmware_Hdmuahang.dr_Hdmuahang["Sotien_Thanhtoan"] != "")
                        //    txtSotien.EditValue = Convert.ToDecimal(Frmware_Hdmuahang.dr_Hdmuahang["Tongtien"]) - Convert.ToDecimal(Frmware_Hdmuahang.dr_Hdmuahang["Sotien_Thanhtoan"]);
                        //else if ("" + Frmware_Hdmuahang.dr_Hdmuahang["Tongtien"] != "")
                        //    txtSotien.EditValue = Convert.ToDecimal(Frmware_Hdmuahang.dr_Hdmuahang["Tongtien"]);
                    }
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void txtSotien_EditValueChanged(object sender, EventArgs e)
        {
            if ("" + lookUpEdit_Tiente.EditValue != "")
            {
                if (txtTygia.Text != "")
                {
                    if (txtSotien.Text != "")
                    {
                        try
                        {
                            txtSotien_Quydoi.EditValue = Convert.ToDecimal(txtSotien.EditValue) * Convert.ToDecimal(txtTygia.EditValue);
                            decimal sotienquydoi = Convert.ToDecimal(txtSotien_Quydoi.EditValue);
                        }
                        catch (Exception ex)
                        {
                             GoobizFrame.Windows.Forms.MessageDialog.Show("Số tiền không hợp lệ, vui lòng nhập lại.");
                            txtSotien.Text = @"0";
                            txtSotien_Quydoi.EditValue = @"0";
                            txtChungtu_Goc.Focus();
                        }

                    }
                    else
                    {
                        txtSotien_Quydoi.EditValue = @"0";
                    }
                }
            }

        }

        private void txtTygia_EditValueChanged(object sender, EventArgs e)
        {
            if (txtTygia.Text != "")
            {
                if (txtSotien.Text != "")
                {
                    try
                    {
                        txtSotien_Quydoi.EditValue = Convert.ToDecimal(txtSotien.EditValue) * Convert.ToDecimal(txtTygia.EditValue);
                        decimal sotienquydoi = Convert.ToDecimal(txtSotien_Quydoi.EditValue);
                    }
                    catch (Exception ex)
                    {
                         GoobizFrame.Windows.Forms.MessageDialog.Show("Giá trị nhập không hợp lệ, vui lòng nhập lại.");
                        this.txtTygia.EditValue = @"0";
                        txtSotien_Quydoi.EditValue = @"0";
                        txtChungtu_Goc.Focus();
                    }

                }
                else
                {
                    txtSotien_Quydoi.EditValue = @"0";
                }
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                _id_congnotra = gridView1.GetFocusedRowCellValue("Id_Congnotra_Dauky");

            }
        }

        private void lookUpEdit_Tiente_EditValueChanged(object sender, EventArgs e)
        {
            this.txtTygia.EditValue = lookUpEdit_Tiente.GetColumnValue("Tygia_Vnd");
        }

        #endregion

     

  }
}

