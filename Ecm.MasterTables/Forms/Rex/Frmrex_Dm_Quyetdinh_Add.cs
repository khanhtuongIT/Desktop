
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Rex
{
    public partial class Frmrex_Dm_Quyetdinh_Add :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Quyetdinh = new DataSet();
        public Ecm.WebReferences.MasterService.Rex_Dm_Quyetdinh Selected_Rex_Dm_Quyetdinh;

        public Frmrex_Dm_Quyetdinh_Add()
        {
            InitializeComponent();
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                ds_Quyetdinh = objMasterService.Get_All_Rex_Dm_Quyetdinh_Collection().ToDataSet();
                dgrex_Dm_Quyetdinh.DataSource = ds_Quyetdinh;
                dgrex_Dm_Quyetdinh.DataMember = ds_Quyetdinh.Tables[0].TableName;

                this.Data = ds_Quyetdinh;
                this.GridControl = dgrex_Dm_Quyetdinh;

                this.DataBindingControl();
                this.ChangeStatus(false);
                this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void ClearDataBindings()
        {
            this.txtMa_Quyetdinh.DataBindings.Clear();
            this.txtSohieu.DataBindings.Clear();
            this.txtTrichyeu.DataBindings.Clear();
            this.txtNoidung.DataBindings.Clear();
            this.txtNguoiky.DataBindings.Clear();
            this.dtNgay_Ky.DataBindings.Clear();
            this.dtNgay_Batdau.DataBindings.Clear();
            this.dtNgay_Ketthuc.DataBindings.Clear();
        }

        public void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtMa_Quyetdinh.DataBindings.Add("EditValue", ds_Quyetdinh, ds_Quyetdinh.Tables[0].TableName + ".Ma_Quyetdinh");
                this.txtSohieu.DataBindings.Add("EditValue", ds_Quyetdinh, ds_Quyetdinh.Tables[0].TableName + ".Sohieu");
                this.txtTrichyeu.DataBindings.Add("EditValue", ds_Quyetdinh, ds_Quyetdinh.Tables[0].TableName + ".Trichyeu");
                this.txtNoidung.DataBindings.Add("EditValue", ds_Quyetdinh, ds_Quyetdinh.Tables[0].TableName + ".Noidung");
                this.txtNguoiky.DataBindings.Add("EditValue", ds_Quyetdinh, ds_Quyetdinh.Tables[0].TableName + ".Nguoiky");
                this.dtNgay_Ky.DataBindings.Add("EditValue", ds_Quyetdinh, ds_Quyetdinh.Tables[0].TableName + ".Ngayky");
                this.dtNgay_Batdau.DataBindings.Add("EditValue", ds_Quyetdinh, ds_Quyetdinh.Tables[0].TableName + ".Ngaybatdau");
                this.dtNgay_Ketthuc.DataBindings.Add("EditValue", ds_Quyetdinh, ds_Quyetdinh.Tables[0].TableName + ".Ngayketthuc");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ChangeStatus(bool editTable)
        {
            //this.dgrex_Dm_Quyetdinh.Enabled = !editTable;
            this.gridView1.OptionsBehavior.Editable = !editTable;
            this.txtMa_Quyetdinh.Properties.ReadOnly = !editTable;
            this.txtSohieu.Properties.ReadOnly = !editTable;
            this.txtTrichyeu.Properties.ReadOnly = !editTable;
            this.txtNoidung.Properties.ReadOnly = !editTable;
            this.txtNguoiky.Properties.ReadOnly = !editTable;
            this.dtNgay_Ky.Properties.ReadOnly = !editTable;
            this.dtNgay_Batdau.Properties.ReadOnly = !editTable;
            this.dtNgay_Ketthuc.Properties.ReadOnly = !editTable;
        }

        public override void  ResetText()
        {
            this.txtMa_Quyetdinh.EditValue = "";
            this.txtSohieu.EditValue = "";
            this.txtTrichyeu.EditValue = "";
            this.txtNoidung.EditValue = "";
            this.txtNguoiky.EditValue = "";
            this.dtNgay_Ky.EditValue = DateTime.Now;
            this.dtNgay_Batdau.EditValue = DateTime.Now;
            this.dtNgay_Ketthuc.EditValue = DateTime.Now;
        }

        private void Frmrex_Dm_Quyetdinh_Add_Load(object sender, EventArgs e)
        {
            this.DisplayInfo();
        }

        #region Event Override
        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Quyetdinh objRex_Dm_Quyetdinh = new Ecm.WebReferences.MasterService.Rex_Dm_Quyetdinh();

            objRex_Dm_Quyetdinh.Id_Quyetdinh = -1;
            objRex_Dm_Quyetdinh.Ma_Quyetdinh = txtMa_Quyetdinh.EditValue;
            objRex_Dm_Quyetdinh.Sohieu = txtSohieu.EditValue;
            objRex_Dm_Quyetdinh.Trichyeu = txtTrichyeu.EditValue;
            objRex_Dm_Quyetdinh.Noidung = txtNoidung.EditValue;
            objRex_Dm_Quyetdinh.Nguoiky = txtNguoiky.EditValue;
            objRex_Dm_Quyetdinh.Ngayky = dtNgay_Ky.EditValue;
            objRex_Dm_Quyetdinh.Ngaybatdau = dtNgay_Batdau.EditValue;
            objRex_Dm_Quyetdinh.Ngayketthuc = dtNgay_Ketthuc.EditValue;

            return objMasterService.Insert_Rex_Dm_Quyetdinh(objRex_Dm_Quyetdinh);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Quyetdinh objRex_Dm_Quyetdinh = new Ecm.WebReferences.MasterService.Rex_Dm_Quyetdinh();
            objRex_Dm_Quyetdinh.Id_Quyetdinh = gridView1.GetFocusedRowCellValue("Id_Quyetdinh");
            objRex_Dm_Quyetdinh.Ma_Quyetdinh = txtMa_Quyetdinh.EditValue;
            objRex_Dm_Quyetdinh.Sohieu = txtSohieu.EditValue;
            objRex_Dm_Quyetdinh.Trichyeu = txtTrichyeu.EditValue;
            objRex_Dm_Quyetdinh.Noidung = txtNoidung.EditValue;
            objRex_Dm_Quyetdinh.Nguoiky = txtNguoiky.EditValue;
            objRex_Dm_Quyetdinh.Ngayky = dtNgay_Ky.EditValue;
            objRex_Dm_Quyetdinh.Ngaybatdau = dtNgay_Batdau.EditValue;
            objRex_Dm_Quyetdinh.Ngayketthuc = dtNgay_Ketthuc.EditValue;

            return objMasterService.Update_Rex_Dm_Quyetdinh(objRex_Dm_Quyetdinh);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Quyetdinh objRex_Dm_Quyetdinh = new Ecm.WebReferences.MasterService.Rex_Dm_Quyetdinh();
            objRex_Dm_Quyetdinh.Id_Quyetdinh = gridView1.GetFocusedRowCellValue("Id_Quyetdinh");
            return objMasterService.Delete_Rex_Dm_Quyetdinh(objRex_Dm_Quyetdinh);
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
            this.ChangeStatus(true);
            return true;
        }

        public override bool PerformCancel()
        {
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
                hashtableControls.Add(txtMa_Quyetdinh, lblMa_Quyetdinh.Text);
                hashtableControls.Add(txtSohieu, lblSohieu.Text);

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;
                                
                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                    return false;

                if(FormState ==  GoobizFrame.Windows.Forms.FormState.Add)
                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, ds_Quyetdinh, "Sohieu"))
                        return false;

                System.Collections.Hashtable htb = new System.Collections.Hashtable();
                htb.Add(txtMa_Quyetdinh, lblMa_Quyetdinh.Text);

                if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Add)
                {
                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htb, (DataSet)dgrex_Dm_Quyetdinh.DataSource, "Ma_Quyetdinh"))
                        return false;
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
                if (ex.ToString().IndexOf("exists") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Quyetdinh.Text, lblMa_Quyetdinh.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Quyetdinh"], "");
            hashtableControls.Add(gridView1.Columns["Sohieu"], "");

            this.DoClickEndEdit(dgrex_Dm_Quyetdinh);//dgrex_Dm_Quyetdinh.EmbeddedNavigator.Buttons.EndEdit.DoClick();
            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistGrid(hashtableControls, gridView1))
                return false;

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckDateGrid(gridView1.Columns["Ngaybatdau"], gridView1.Columns["Ngayketthuc"], gridView1))
                return false;

            try
            {               
                //ds_Quyetdinh.Tables[0].Columns["Ma_Quyetdinh"].Unique = true;
                //ds_Quyetdinh.Tables[0].Columns["Sohieu"].Unique = true;
                objMasterService.Update_Rex_Dm_Quyetdinh_Collection(this.ds_Quyetdinh);
            }
            catch (Exception ex)
            {
                //if (ex.ToString().IndexOf("Unique") != -1)
                //{
                //     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Quyetdinh.Text, lblMa_Quyetdinh.Text });
                //    return false;
                //}
                //MessageBox.Show(ex.ToString());
            }
            this.DisplayInfo();
            return true;
        }

        public override bool PerformDelete()
        {
            if ( GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Rex_Dm_Quyetdinh"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Rex_Dm_Quyetdinh")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Quyetdinh", "Id_Quyetdinh", this.gridView1.GetFocusedRowCellValue("Id_Quyetdinh"))) > 0)
                    {
                         GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                        return true;
                    }
                    this.DeleteObject();
                }
                catch (Exception ex)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                }
                this.DisplayInfo();
            }
            return base.PerformDelete();
        }

        public override object PerformSelectOneObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Quyetdinh rex_Dm_Quyetdinh = new Ecm.WebReferences.MasterService.Rex_Dm_Quyetdinh();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Quyetdinh.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    rex_Dm_Quyetdinh.Id_Quyetdinh = dr["Id_Quyetdinh"];
                    rex_Dm_Quyetdinh.Ma_Quyetdinh = dr["Ma_Quyetdinh"];
                    rex_Dm_Quyetdinh.Sohieu = dr["Sohieu"];
                    rex_Dm_Quyetdinh.Trichyeu = dr["Trichyeu"];
                    rex_Dm_Quyetdinh.Noidung = dr["Noidung"];
                    rex_Dm_Quyetdinh.Nguoiky = dr["Nguoiky"];
                    rex_Dm_Quyetdinh.Ngayky = dr["Ngayky"];
                    rex_Dm_Quyetdinh.Ngaybatdau = dr["Ngaybatdau"];
                    rex_Dm_Quyetdinh.Ngayketthuc = dr["Ngayketthuc"];
                }
                Selected_Rex_Dm_Quyetdinh = rex_Dm_Quyetdinh;
                this.Dispose();
                this.Close();
                return rex_Dm_Quyetdinh;
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

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.addnewrow_clicked = true;
            gridView1.SetFocusedRowCellValue(gridView1.Columns["Ngayky"], DateTime.Today);
            gridView1.SetFocusedRowCellValue(gridView1.Columns["Ngaybatdau"], DateTime.Today);
            gridView1.SetFocusedRowCellValue(gridView1.Columns["Ngayketthuc"], DateTime.Today);
        }

        private void dgrex_Dm_Quyetdinh_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + this.gridView1.GetFocusedRowCellValue("Id_Quyetdinh") != "")
                if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Quyetdinh", "Id_Quyetdinh", this.gridView1.GetFocusedRowCellValue("Id_Quyetdinh"))) > 0)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    e.Handled = true;
                }
            }
        }

        private void txtMa_Quyetdinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;
        }

    }
}

