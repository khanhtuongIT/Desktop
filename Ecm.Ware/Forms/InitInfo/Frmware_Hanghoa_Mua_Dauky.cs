using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunLine.Ware.Forms
{
    public partial class Frmware_Hanghoa_Mua_Dauky : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public SunLine.WebReferences.Classes.WareService objWareService = new SunLine.WebReferences.Classes.WareService();
        public SunLine.WebReferences.Classes.MasterService objMasterService = new SunLine.WebReferences.Classes.MasterService();

        DataSet ds_Collection = new DataSet();

        public Frmware_Hanghoa_Mua_Dauky()
        {
            InitializeComponent();
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                //Get data Ware_Dm_Kho_Hanghoa_Mua
                DataSet dsWare_Dm_Kho_Hanghoa_Mua = objMasterService.Get_All_Ware_Dm_Kho_Hanghoa_Mua();
                lookUpEdit_Kho_Hanghoa_Mua.Properties.DataSource = dsWare_Dm_Kho_Hanghoa_Mua.Tables[0];
                gridLookUpEdit_Kho_Hanghoa_Mua.DataSource        = dsWare_Dm_Kho_Hanghoa_Mua.Tables[0];

                //Get data Ware_Dm_Hanghoa_Mua
                DataSet dsWare_Dm_Hanghoa_Mua = objMasterService.Get_All_Ware_Dm_Hanghoa_Mua();
                lookUpEdit_Hanghoa_Mua.Properties.DataSource    = dsWare_Dm_Hanghoa_Mua.Tables[0];
                gridLookUpEdit_Hanghoa_Mua.DataSource           = dsWare_Dm_Hanghoa_Mua.Tables[0];

                //Get data Ware_Dm_Donvitinh
                DataSet dsWare_Dm_Donvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh();
                lookUpEdit_Donvitinh.Properties.DataSource      = dsWare_Dm_Donvitinh.Tables[0];
                gridLookUpEdit_Donvitinh.DataSource             = dsWare_Dm_Donvitinh.Tables[0];

                //Get data Ware_Hanghoa_Mua_Dauky
                ds_Collection = objWareService.Get_All_Ware_Hanghoa_Mua_Dauky();
                dgware_Hanghoa_Mua_Dauky.DataSource             = ds_Collection;
                dgware_Hanghoa_Mua_Dauky.DataMember             = ds_Collection.Tables[0].TableName;

                this.Data = ds_Collection;
                this.GridControl = dgware_Hanghoa_Mua_Dauky;

                this.DataBindingControl();

                this.ChangeStatus(false);

                this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif

                ////GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }

        }

        void ClearDataBinding()
        {
            this.txtId_Hanghoa_Mua_Dauky.DataBindings.Clear();
            this.dtThang_Nam.DataBindings.Clear();
            this.txtSoluong.DataBindings.Clear();

            this.lookUpEdit_Kho_Hanghoa_Mua.DataBindings.Clear();
            this.lookUpEdit_Hanghoa_Mua.DataBindings.Clear();
            this.lookUpEdit_Donvitinh.DataBindings.Clear();
        }

        public void DataBindingControl()
        {
            try
            {
                ClearDataBinding();

                this.txtId_Hanghoa_Mua_Dauky.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Hanghoa_Mua_Dauky");
                this.dtThang_Nam.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ngay_Nhap");
                this.txtSoluong.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Soluong");

                this.lookUpEdit_Kho_Hanghoa_Mua.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Kho_Hanghoa_Mua");
                this.lookUpEdit_Hanghoa_Mua.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Hanghoa_Mua");
                this.lookUpEdit_Donvitinh.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Donvitinh");
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif

                ////GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }
        }

        public void ChangeStatus(bool editTable)
        {
            this.dgware_Hanghoa_Mua_Dauky.Enabled = !editTable;
            this.dtThang_Nam.Properties.ReadOnly = !editTable;
            this.txtSoluong.Properties.ReadOnly = !editTable;

            this.lookUpEdit_Kho_Hanghoa_Mua.Properties.ReadOnly = !editTable;
            this.lookUpEdit_Hanghoa_Mua.Properties.ReadOnly = !editTable;
            this.lookUpEdit_Donvitinh.Properties.ReadOnly = !editTable;
        }

        public void ResetText()
        {
            this.txtId_Hanghoa_Mua_Dauky.EditValue = "";
            //this.dtThang_Nam.EditValue = "";
            this.txtSoluong.EditValue = null;

            this.lookUpEdit_Kho_Hanghoa_Mua.EditValue = null;
            this.lookUpEdit_Hanghoa_Mua.EditValue = null;
            this.lookUpEdit_Donvitinh.EditValue = null;
        }

        #region Event Override
        public object InsertObject()
        {
            SunLine.WebReferences.WareService.Ware_Hanghoa_Mua_Dauky objWare_Hanghoa_Mua_Dauky = new SunLine.WebReferences.WareService.Ware_Hanghoa_Mua_Dauky();
            objWare_Hanghoa_Mua_Dauky.Id_Hanghoa_Mua_Dauky = -1;
            objWare_Hanghoa_Mua_Dauky.Ngay_Nhap = dtThang_Nam.EditValue;
            if("" + txtSoluong.EditValue != "")
                objWare_Hanghoa_Mua_Dauky.Soluong = txtSoluong.EditValue;
            if ("" + lookUpEdit_Kho_Hanghoa_Mua.EditValue != "")
                objWare_Hanghoa_Mua_Dauky.Id_Kho_Hanghoa_Mua = lookUpEdit_Kho_Hanghoa_Mua.EditValue;
            if ("" + lookUpEdit_Hanghoa_Mua.EditValue != "")
                objWare_Hanghoa_Mua_Dauky.Id_Hanghoa_Mua = lookUpEdit_Hanghoa_Mua.EditValue;
            if ("" + lookUpEdit_Donvitinh.EditValue != "")
                objWare_Hanghoa_Mua_Dauky.Id_Donvitinh = lookUpEdit_Donvitinh.EditValue;

            return objWareService.Insert_Ware_Hanghoa_Mua_Dauky(objWare_Hanghoa_Mua_Dauky);
        }

        public object UpdateObject()
        {
            SunLine.WebReferences.WareService.Ware_Hanghoa_Mua_Dauky objWare_Hanghoa_Mua_Dauky = new SunLine.WebReferences.WareService.Ware_Hanghoa_Mua_Dauky();
            objWare_Hanghoa_Mua_Dauky.Id_Hanghoa_Mua_Dauky = gridView1.GetFocusedRowCellValue("Id_Hanghoa_Mua_Dauky");
            objWare_Hanghoa_Mua_Dauky.Ngay_Nhap = dtThang_Nam.EditValue;
            
            if ("" + txtSoluong.EditValue != "")
                objWare_Hanghoa_Mua_Dauky.Soluong = txtSoluong.EditValue;
            if ("" + lookUpEdit_Kho_Hanghoa_Mua.EditValue != "")
                objWare_Hanghoa_Mua_Dauky.Id_Kho_Hanghoa_Mua = lookUpEdit_Kho_Hanghoa_Mua.EditValue;
            if ("" + lookUpEdit_Hanghoa_Mua.EditValue != "")
                objWare_Hanghoa_Mua_Dauky.Id_Hanghoa_Mua = lookUpEdit_Hanghoa_Mua.EditValue;
            if ("" + lookUpEdit_Donvitinh.EditValue != "")
                objWare_Hanghoa_Mua_Dauky.Id_Donvitinh = lookUpEdit_Donvitinh.EditValue;

            return objWareService.Update_Ware_Hanghoa_Mua_Dauky(objWare_Hanghoa_Mua_Dauky);
        }

        public object DeleteObject()
        {
            SunLine.WebReferences.WareService.Ware_Hanghoa_Mua_Dauky objWare_Hanghoa_Mua_Dauky = new SunLine.WebReferences.WareService.Ware_Hanghoa_Mua_Dauky();
            objWare_Hanghoa_Mua_Dauky.Id_Hanghoa_Mua_Dauky = gridView1.GetFocusedRowCellValue("Id_Hanghoa_Mua_Dauky");

            return objWareService.Delete_Ware_Hanghoa_Mua_Dauky(objWare_Hanghoa_Mua_Dauky);
        }

        public override bool PerformAdd()
        {
            ClearDataBinding();
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

                GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(txtSoluong, lblSoluong.Text);
                hashtableControls.Add(dtThang_Nam, lblThang_Nam.Text);
                hashtableControls.Add(lookUpEdit_Kho_Hanghoa_Mua, lblId_Kho_Hanghoa_Mua.Text);
                hashtableControls.Add(lookUpEdit_Hanghoa_Mua, lblId_Hanghoa_Mua.Text);
                hashtableControls.Add(lookUpEdit_Donvitinh, lblId_Donvitinh.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
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
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ngay_Nhap"], "");
            hashtableControls.Add(gridView1.Columns["Soluong"], "");
            hashtableControls.Add(gridView1.Columns["Id_Kho_Hanghoa_Mua"], "");
            hashtableControls.Add(gridView1.Columns["Id_Hanghoa_Mua"], "");
            hashtableControls.Add(gridView1.Columns["Id_Donvitinh"], "");

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                this.DoClickEndEdit(dgware_Hanghoa_Mua_Dauky); //dgware_Hanghoa_Mua_Dauky.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                objWareService.Update_Ware_Hanghoa_Mua_Dauky_Collection(this.ds_Collection);
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
            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
            GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Hanghoa_Mua_Dauky"),
            GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Hanghoa_Mua_Dauky")   }) == DialogResult.Yes)
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
            SunLine.WebReferences.WareService.Ware_Hanghoa_Mua_Dauky ware_Hanghoa_Mua_Dauky = new SunLine.WebReferences.WareService.Ware_Hanghoa_Mua_Dauky();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Collection.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    ware_Hanghoa_Mua_Dauky.Id_Hanghoa_Mua_Dauky = dr["Id_Hanghoa_Mua_Dauky"];
                    ware_Hanghoa_Mua_Dauky.Ngay_Nhap = dr["Ngay_Nhap"];
                    ware_Hanghoa_Mua_Dauky.Soluong = dr["Soluong"];
                    ware_Hanghoa_Mua_Dauky.Id_Kho_Hanghoa_Mua = dr["Id_Kho_Hanghoa_Mua"];
                    ware_Hanghoa_Mua_Dauky.Id_Hanghoa_Mua = dr["Id_Hanghoa_Mua"];
                    ware_Hanghoa_Mua_Dauky.Id_Donvitinh = dr["Id_Donvitinh"];
                }
                this.Dispose();
                this.Close();
                return ware_Hanghoa_Mua_Dauky;
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
            this.gridView1.FocusedColumn = gridView1.Columns["Soluong"];
            this.gridView1.SetFocusedRowCellValue(gridView1.Columns["Ngay_Nhap"], objWareService.GetServerDateTime());
            this.addnewrow_clicked = true;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Id_Hanghoa_Mua")
            {
                gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Donvitinh"]
                     , ((System.Data.DataRowView)gridLookUpEdit_Hanghoa_Mua.GetDataSourceRowByKeyValue(e.Value))["Id_Donvitinh"]);
            }
            //this.dgware_Hanghoa_Mua_Dauky.EmbeddedNavigator.Buttons.EndEdit.DoClick();
        }

        private void lookUpEdit_Hanghoa_Mua_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataRowView drv = (System.Data.DataRowView)lookUpEdit_Hanghoa_Mua.Properties.GetDataSourceRowByKeyValue(lookUpEdit_Hanghoa_Mua.EditValue);
                lookUpEdit_Donvitinh.EditValue = drv["Id_Donvitinh"];

            }
            catch { }
        }
    }
}

