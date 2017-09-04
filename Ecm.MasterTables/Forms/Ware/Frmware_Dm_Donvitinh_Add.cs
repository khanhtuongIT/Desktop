using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Ware
{
    public partial class Frmware_Dm_Donvitinh_Add : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Collection = new DataSet();
        object Id_Hanghoa_Ban = null;
        object ten_dovitinh = null;

        private Ecm.WebReferences.MasterService.Ware_Dm_Donvitinh _SelecteWare_Dm_Donvitinh;
        public Ecm.WebReferences.MasterService.Ware_Dm_Donvitinh SelecteWare_Dm_Donvitinh
        {
            get { return _SelecteWare_Dm_Donvitinh; }
            set { _SelecteWare_Dm_Donvitinh = value; }
        }

        public DataSet DsWare_Dm_Donvitinh
        {
            get { return ds_Collection; }
        }

        public Frmware_Dm_Donvitinh_Add()
        {
            InitializeComponent();
            this.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void Frmware_Dm_Donvitinh_Add_Load(object sender, EventArgs e)
        {
            if (Id_Hanghoa_Ban == null)
                this.DisplayInfo();
        }

        public void setId_Hanghoa_Ban(object Id_Hanghoa)
        {
            Id_Hanghoa_Ban = Id_Hanghoa;
            ds_Collection = objMasterService.Ware_Dm_Donvitinh_Quydoi_By_Id_Hanghoa_Ban(Id_Hanghoa_Ban).ToDataSet();
            dgware_Dm_Donvitinh.DataSource = ds_Collection;
            dgware_Dm_Donvitinh.DataMember = ds_Collection.Tables[0].TableName;

            this.Data = ds_Collection;
            this.GridControl = dgware_Dm_Donvitinh;
            this.DataBindingControl();

            this.ChangeStatus(false);
            dgware_Dm_Donvitinh.Enabled = true;
            this.gridView1.BestFitColumns();
        }

        public override void DisplayInfo()
        {
            try
            {
                ds_Collection = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
                dgware_Dm_Donvitinh.DataSource = ds_Collection;
                dgware_Dm_Donvitinh.DataMember = ds_Collection.Tables[0].TableName;

                this.Data = ds_Collection;
                this.GridControl = dgware_Dm_Donvitinh;
                this.DataBindingControl();
                this.ChangeStatus(false);
                dgware_Dm_Donvitinh.Enabled = true;
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

        public override void ClearDataBindings()
        {
            this.txtId_Donvitinh.DataBindings.Clear();
            this.txtMa_Donvitinh.DataBindings.Clear();
            this.txtTen_Donvitinh.DataBindings.Clear();
        }
        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtId_Donvitinh.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Donvitinh");
                this.txtMa_Donvitinh.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ma_Donvitinh");
                this.txtTen_Donvitinh.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ten_Donvitinh");
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                //// GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }
        }

        public override void ChangeStatus(bool editTable)
        {
            gridView1.OptionsBehavior.Editable = !editTable;
            //dgware_Dm_Donvitinh.Enabled = !editTable;
            this.txtMa_Donvitinh.Properties.ReadOnly = !editTable;
            this.txtTen_Donvitinh.Properties.ReadOnly = !editTable;
        }

        public override void ResetText()
        {
            this.txtId_Donvitinh.EditValue = "";
            this.txtMa_Donvitinh.EditValue = "";
            this.txtTen_Donvitinh.EditValue = "";
        }

        #region Event Override
        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Donvitinh objWare_Dm_Donvitinh = new Ecm.WebReferences.MasterService.Ware_Dm_Donvitinh();
            objWare_Dm_Donvitinh.Id_Donvitinh = -1;
            objWare_Dm_Donvitinh.Ma_Donvitinh = txtMa_Donvitinh.EditValue;
            objWare_Dm_Donvitinh.Ten_Donvitinh = txtTen_Donvitinh.EditValue;
            return objMasterService.Insert_Ware_Dm_Donvitinh(objWare_Dm_Donvitinh);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Donvitinh objWare_Dm_Donvitinh = new Ecm.WebReferences.MasterService.Ware_Dm_Donvitinh();
            objWare_Dm_Donvitinh.Id_Donvitinh = gridView1.GetFocusedRowCellValue("Id_Donvitinh");
            objWare_Dm_Donvitinh.Ma_Donvitinh = txtMa_Donvitinh.EditValue;
            objWare_Dm_Donvitinh.Ten_Donvitinh = txtTen_Donvitinh.EditValue;
            return objMasterService.Update_Ware_Dm_Donvitinh(objWare_Dm_Donvitinh);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Donvitinh objWare_Dm_Donvitinh = new Ecm.WebReferences.MasterService.Ware_Dm_Donvitinh();
            objWare_Dm_Donvitinh.Id_Donvitinh = gridView1.GetFocusedRowCellValue("Id_Donvitinh");
            return objMasterService.Delete_Ware_Dm_Donvitinh(objWare_Dm_Donvitinh);
        }

        public override bool PerformAdd()
        {
            ClearDataBindings();
            this.ChangeStatus(true);
            //dgware_Dm_Donvitinh.Enabled = false;
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

                GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(txtMa_Donvitinh, lblMa_Donvitinh.Text);
                hashtableControls.Add(txtTen_Donvitinh, lblTen_Donvitinh.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;
                hashtableControls.Remove(txtMa_Donvitinh);

                //if (!txtTen_Donvitinh.EditValue.Equals(ten_dovitinh))
                //{
                //if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htbTen_Donvitinh, ds_Collection, "Ten_Donvitinh"))
                //    return false;
                //}

                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                {
                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, ds_Collection, "Ten_Donvitinh"))
                        return false;
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    if (!txtTen_Donvitinh.EditValue.Equals(ten_dovitinh))
                    {
                        if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, ds_Collection, "Ten_Donvitinh"))
                            return false;
                    }
                    success = (bool)this.UpdateObject();
                }
                if (success)
                {
                    ten_dovitinh = null;
                    this.DisplayInfo();
                }
                return success;
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("exists") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Donvitinh.Text, lblMa_Donvitinh.Text.ToLower() });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
            dgware_Dm_Donvitinh.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Donvitinh.EmbeddedNavigator.Buttons.EndEdit);

            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Donvitinh"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Donvitinh"], "");

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistGrid(hashtableControls, gridView1))
                return false;

            try
            {
                ds_Collection.Tables[0].Columns["Ma_Donvitinh"].Unique = true;
                objMasterService.Update_Ware_Dm_Donvitinh_Collection(this.ds_Collection);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Donvitinh.Text, lblMa_Donvitinh.Text.ToLower() });
                    this.gridView1.FocusedColumn = gridView1.Columns["Ma_Donvitinh"];
                    return false;
                }
                //MessageBox.Show(ex.ToString());

            }
            this.DisplayInfo();
            return true;
        }

        public override bool PerformDelete()
        {
            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Dm_Donvitinh"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Dm_Donvitinh")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Ware_Dm_Donvitinh", "Id_Donvitinh", this.gridView1.GetFocusedRowCellValue("Id_Donvitinh"))) > 0)
                    {
                        GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                        return true;
                    }
                    this.DeleteObject();
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    // GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                }
                this.DisplayInfo();
            }
            return base.PerformDelete();
        }

        public override object PerformSelectOneObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Donvitinh ware_Dm_Donvitinh = new Ecm.WebReferences.MasterService.Ware_Dm_Donvitinh();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Collection.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    ware_Dm_Donvitinh.Id_Donvitinh = dr["Id_Donvitinh"];
                    ware_Dm_Donvitinh.Ma_Donvitinh = dr["Ma_Donvitinh"];
                    ware_Dm_Donvitinh.Ten_Donvitinh = dr["Ten_Donvitinh"];
                }
                _SelecteWare_Dm_Donvitinh = ware_Dm_Donvitinh;

                this.Dispose();
                this.Close();
                return ware_Dm_Donvitinh;
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

        #region Evne

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Donvitinh"];
            this.addnewrow_clicked = true;
            gridView1.OptionsBehavior.Editable = true;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.dgware_Dm_Donvitinh.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Donvitinh.EmbeddedNavigator.Buttons.EndEdit);
        }

        private void dgware_Dm_Donvitinh_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if (Convert.ToInt32(objMasterService.GetExistReferences("Ware_Dm_Donvitinh", "Id_Donvitinh", this.gridView1.GetFocusedRowCellValue("Id_Donvitinh"))) > 0)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    e.Handled = true;
                }
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ten_dovitinh = gridView1.GetFocusedRowCellValue("Ten_Donvitinh");
        }

        private void txtMa_Donvitinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;

        }
        #endregion

    }

}

