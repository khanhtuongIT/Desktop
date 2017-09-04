using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunLine.MasterTables.Forms.Ware
{
    public partial class Frmware_Dm_Loai_Hanghoa_Mua_Add : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
               public MasterService.MasterService objMasterService = new SunLine.MasterTables.MasterService.MasterService();
        DataSet ds_Collection = new DataSet();
        public MasterService.Ware_Dm_Loai_Hanghoa_Mua SelectedWare_Dm_Loai_Hanghoa_Mua;

        public Frmware_Dm_Loai_Hanghoa_Mua_Add()
        {
            InitializeComponent();
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                //Get data Ware_Dm_Loai_Hanghoa_Mua
                DataSet dsWare_Dm_Nhom_Hanghoa_Mua = objMasterService.Get_All_Ware_Dm_Nhom_Hanghoa_Mua();
                lookUpEdit_Nhom_Hanghoa_Mua.Properties.DataSource   = dsWare_Dm_Nhom_Hanghoa_Mua.Tables[0];
                gridLookUpEdit_Nhom_Hanghoa_Mua.DataSource          = dsWare_Dm_Nhom_Hanghoa_Mua.Tables[0];

                //Get data Ware_Dm_Loai_Hanghoa_Mua
                ds_Collection = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Mua();
                dgware_Dm_Loai_Hanghoa_Mua.DataSource = ds_Collection;
                dgware_Dm_Loai_Hanghoa_Mua.DataMember = ds_Collection.Tables[0].TableName;

                this.Data = ds_Collection;
                this.GridControl = dgware_Dm_Loai_Hanghoa_Mua;

                this.DataBindingControl();

                this.ChangeStatus(false);

                this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif

                //GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }

        }

        void ClearDataBindings()
        {
            this.txtId_Loai_Hanghoa_Mua.DataBindings.Clear();
            this.txtMa_Loai_Hanghoa_Mua.DataBindings.Clear();
            this.txtTen_Loai_Hanghoa_Mua.DataBindings.Clear();
            this.lookUpEdit_Nhom_Hanghoa_Mua.DataBindings.Clear();
        }

        public void DataBindingControl()
        {
            try
            {
                ClearDataBindings();

                this.txtId_Loai_Hanghoa_Mua.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Loai_Hanghoa_Mua");
                this.txtMa_Loai_Hanghoa_Mua.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ma_Loai_Hanghoa_Mua");
                this.txtTen_Loai_Hanghoa_Mua.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ten_Loai_Hanghoa_Mua");
                this.lookUpEdit_Nhom_Hanghoa_Mua.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Nhom_Hanghoa_Mua");
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif

                //GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }
        }

        public void ChangeStatus(bool editTable)
        {
            this.dgware_Dm_Loai_Hanghoa_Mua.Enabled = !editTable;
            this.txtMa_Loai_Hanghoa_Mua.Properties.ReadOnly = !editTable;
            this.txtTen_Loai_Hanghoa_Mua.Properties.ReadOnly = !editTable;
            this.lookUpEdit_Nhom_Hanghoa_Mua.Properties.ReadOnly = !editTable;
        }

        public void ResetText()
        {
            this.txtId_Loai_Hanghoa_Mua.EditValue = "";
            this.txtMa_Loai_Hanghoa_Mua.EditValue = "";
            this.txtTen_Loai_Hanghoa_Mua.EditValue = "";
            this.lookUpEdit_Nhom_Hanghoa_Mua.EditValue = null;
        }

        #region Event Override
        public object InsertObject()
        {
            MasterService.Ware_Dm_Loai_Hanghoa_Mua objWare_Dm_Loai_Hanghoa_Mua = new SunLine.MasterTables.MasterService.Ware_Dm_Loai_Hanghoa_Mua();
            objWare_Dm_Loai_Hanghoa_Mua.Ma_Loai_Hanghoa_Mua = -1;
            objWare_Dm_Loai_Hanghoa_Mua.Ma_Loai_Hanghoa_Mua = txtMa_Loai_Hanghoa_Mua.EditValue;
            objWare_Dm_Loai_Hanghoa_Mua.Ten_Loai_Hanghoa_Mua = txtTen_Loai_Hanghoa_Mua.EditValue;
            
            if ("" + lookUpEdit_Nhom_Hanghoa_Mua.EditValue != "")
                    objWare_Dm_Loai_Hanghoa_Mua.Id_Nhom_Hanghoa_Mua = lookUpEdit_Nhom_Hanghoa_Mua.EditValue;

            return objMasterService.Insert_Ware_Dm_Loai_Hanghoa_Mua(objWare_Dm_Loai_Hanghoa_Mua);
        }

        public object UpdateObject()
        {
            MasterService.Ware_Dm_Loai_Hanghoa_Mua objWare_Dm_Loai_Hanghoa_Mua = new SunLine.MasterTables.MasterService.Ware_Dm_Loai_Hanghoa_Mua();
            objWare_Dm_Loai_Hanghoa_Mua.Id_Loai_Hanghoa_Mua = gridView1.GetFocusedRowCellValue("Id_Loai_Hanghoa_Mua");
            objWare_Dm_Loai_Hanghoa_Mua.Ma_Loai_Hanghoa_Mua = txtMa_Loai_Hanghoa_Mua.EditValue;
            objWare_Dm_Loai_Hanghoa_Mua.Ten_Loai_Hanghoa_Mua = txtTen_Loai_Hanghoa_Mua.EditValue;
            
            if ("" + lookUpEdit_Nhom_Hanghoa_Mua.EditValue != "")
                objWare_Dm_Loai_Hanghoa_Mua.Id_Nhom_Hanghoa_Mua = lookUpEdit_Nhom_Hanghoa_Mua.EditValue;

            return objMasterService.Update_Ware_Dm_Loai_Hanghoa_Mua(objWare_Dm_Loai_Hanghoa_Mua);
        }

        public object DeleteObject()
        {
            MasterService.Ware_Dm_Loai_Hanghoa_Mua objWare_Dm_Loai_Hanghoa_Mua = new SunLine.MasterTables.MasterService.Ware_Dm_Loai_Hanghoa_Mua();
            objWare_Dm_Loai_Hanghoa_Mua.Id_Loai_Hanghoa_Mua = gridView1.GetFocusedRowCellValue("Id_Loai_Hanghoa_Mua");
            return objMasterService.Delete_Ware_Dm_Loai_Hanghoa_Mua(objWare_Dm_Loai_Hanghoa_Mua);
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

                System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
                hashtableControls.Add(txtMa_Loai_Hanghoa_Mua, lblMa_Loai_Hanghoa_Mua.Text);
                hashtableControls.Add(txtTen_Loai_Hanghoa_Mua, lblTen_Loai_Hanghoa_Mua.Text);
                hashtableControls.Add(lookUpEdit_Nhom_Hanghoa_Mua, lblId_Nhom_Hanghoa_Mua.Text);

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
                if (ex.ToString().IndexOf("exists") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("Msg00014", new string[] { lblMa_Loai_Hanghoa_Mua.Text, lblMa_Loai_Hanghoa_Mua.Text.ToLower() });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Loai_Hanghoa_Mua"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Loai_Hanghoa_Mua"], "");
            hashtableControls.Add(gridView1.Columns["Id_Nhom_Hanghoa_Mua"], "");

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgware_Dm_Loai_Hanghoa_Mua.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                ds_Collection.Tables[0].Columns["Ma_Loai_Hanghoa_Mua"].Unique = true;
                objMasterService.Update_Ware_Dm_Loai_Hanghoa_Mua_Collection(this.ds_Collection);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("Msg00014", new string[] { lblMa_Loai_Hanghoa_Mua.Text, lblMa_Loai_Hanghoa_Mua.Text.ToLower() });
                    return false;
                }
                MessageBox.Show(ex.ToString());

            }
            this.DisplayInfo();
            return true;
        }

        public override bool PerformDelete()
        {
            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
            GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Dm_Loai_Hanghoa_Mua"),
            GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Dm_Loai_Hanghoa_Mua")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Ware_Dm_Loai_Hanghoa_Mua", "Id_Loai_Hanghoa_Mua", this.gridView1.GetFocusedRowCellValue("Id_Loai_Hanghoa_Mua"))) > 0)
                    {
                        GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                        return true;
                    }
                    this.DeleteObject();
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    //GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                }
                this.DisplayInfo();
            }
            return base.PerformDelete();
        }

        public override object PerformSelectOneObject()
        {
            MasterService.Ware_Dm_Loai_Hanghoa_Mua ware_Dm_Loai_Hanghoa_Mua = new SunLine.MasterTables.MasterService.Ware_Dm_Loai_Hanghoa_Mua();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Collection.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    ware_Dm_Loai_Hanghoa_Mua.Id_Loai_Hanghoa_Mua = dr["Id_Loai_Hanghoa_Mua"];
                    ware_Dm_Loai_Hanghoa_Mua.Ma_Loai_Hanghoa_Mua = dr["Ma_Loai_Hanghoa_Mua"];
                    ware_Dm_Loai_Hanghoa_Mua.Ten_Loai_Hanghoa_Mua = dr["Ten_Loai_Hanghoa_Mua"];
                    ware_Dm_Loai_Hanghoa_Mua.Id_Nhom_Hanghoa_Mua = dr["Id_Nhom_Hanghoa_Mua"];
                }
                SelectedWare_Dm_Loai_Hanghoa_Mua = ware_Dm_Loai_Hanghoa_Mua;
                this.Dispose();
                this.Close();
                return ware_Dm_Loai_Hanghoa_Mua;
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
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Loai_Hanghoa_Mua"];
            this.addnewrow_clicked = true;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.dgware_Dm_Loai_Hanghoa_Mua.EmbeddedNavigator.Buttons.EndEdit.DoClick();
        }

        private void dgware_Dm_Loai_Hanghoa_Mua_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if (Convert.ToInt32(objMasterService.GetExistReferences("Ware_Dm_Loai_Hanghoa_Mua", "Id_Loai_Hanghoa_Mua", this.gridView1.GetFocusedRowCellValue("Id_Loai_Hanghoa_Mua"))) > 0)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    e.Handled = true;
                }
            }
        }
    }
}

