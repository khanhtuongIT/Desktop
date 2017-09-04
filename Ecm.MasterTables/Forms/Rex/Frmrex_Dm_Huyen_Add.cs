using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Rex
{
    public partial class Frmrex_Dm_Huyen_Add :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        //Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Huyen = new DataSet();
        public Ecm.WebReferences.MasterService.Rex_Dm_Huyen Selected_Rex_Dm_Huyen;
        public Frmrex_Dm_Huyen_Add()
        {
            InitializeComponent();
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                DataSet ds_Tinh = new DataSet();
                ds_Tinh = objMasterService.Get_All_Rex_Dm_Tinh_With_Tenquocgia_Collection().ToDataSet();
                lookUp_Tinh.Properties.DataSource = ds_Tinh.Tables[0];
                gridLookUp_Tinh.DataSource = ds_Tinh.Tables[0];

                //LookupEdit_Tinh.Properties.data = ds_Tinh.Tables[0].TableName;
                ds_Huyen = objMasterService.Get_All_Rex_Dm_Huyen_Collection().ToDataSet();
                dgrex_Dm_Huyen.DataSource = ds_Huyen;
                dgrex_Dm_Huyen.DataMember = ds_Huyen.Tables[0].TableName;

                this.Data = ds_Huyen;
                this.GridControl = dgrex_Dm_Huyen;

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
            this.lookUp_Tinh.DataBindings.Clear();
            this.txtMa_Huyen.DataBindings.Clear();
            this.txtTen_Huyen.DataBindings.Clear();
        }

        public void DataBindingControl()
        {
            try
            {
                ClearDataBindings();

                this.lookUp_Tinh.DataBindings.Add("EditValue", ds_Huyen, ds_Huyen.Tables[0].TableName + ".Id_Tinh");
                this.txtMa_Huyen.DataBindings.Add("EditValue", ds_Huyen, ds_Huyen.Tables[0].TableName + ".Ma_Huyen");
                this.txtTen_Huyen.DataBindings.Add("EditValue", ds_Huyen, ds_Huyen.Tables[0].TableName + ".Ten_Huyen");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ChangeStatus(bool editTable)
        {
            //this.dgrex_Dm_Huyen.Enabled = !editTable;
            this.gridView1.OptionsBehavior.Editable = !editTable;
            this.txtMa_Huyen.Properties.ReadOnly = !editTable;
            this.txtTen_Huyen.Properties.ReadOnly = !editTable;
            this.lookUp_Tinh.Properties.ReadOnly = !editTable;
        }

        public void ResetText()
        {
            this.lookUp_Tinh.EditValue = "";
            this.txtMa_Huyen.EditValue = "";
            this.txtTen_Huyen.EditValue = "";
        }

        private void Frmrex_Dm_Huyen_Add_Load(object sender, EventArgs e)
        {
            //this.DisplayInfo();
        }

        #region Event Override
        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Huyen objRex_Dm_Huyen = new Ecm.WebReferences.MasterService.Rex_Dm_Huyen();
            objRex_Dm_Huyen.Id_Huyen = -1;
            objRex_Dm_Huyen.Ma_Huyen = txtMa_Huyen.EditValue;
            objRex_Dm_Huyen.Ten_Huyen = txtTen_Huyen.EditValue;
            objRex_Dm_Huyen.Id_Tinh = lookUp_Tinh.EditValue;
            return objMasterService.Insert_Rex_Dm_Huyen(objRex_Dm_Huyen);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Huyen objRex_Dm_Huyen = new Ecm.WebReferences.MasterService.Rex_Dm_Huyen();
            objRex_Dm_Huyen.Id_Huyen = gridView1.GetFocusedRowCellValue("Id_Huyen");
            objRex_Dm_Huyen.Ma_Huyen = txtMa_Huyen.EditValue;
            objRex_Dm_Huyen.Ten_Huyen = txtTen_Huyen.EditValue;
            objRex_Dm_Huyen.Id_Tinh = lookUp_Tinh.EditValue;
            return objMasterService.Update_Rex_Dm_Huyen(objRex_Dm_Huyen);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Huyen objRex_Dm_Huyen = new Ecm.WebReferences.MasterService.Rex_Dm_Huyen();
            objRex_Dm_Huyen.Id_Huyen = gridView1.GetFocusedRowCellValue("Id_Huyen");

            return objMasterService.Delete_Rex_Dm_Huyen(objRex_Dm_Huyen);
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
                hashtableControls.Add(txtMa_Huyen, lblMa_Huyen.Text);
                hashtableControls.Add(txtTen_Huyen, lblTen_Huyen.Text);
                hashtableControls.Add(lookUp_Tinh, lblId_Tinh.Text);

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;


                if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Add)
                {
                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, (DataSet)dgrex_Dm_Huyen.DataSource, "Ma_Huyen"))
                        return false;
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    DataSet ds_Huyen_filter =  GoobizFrame.Windows.MdiUtils.Validator.datasetFillter(ds_Huyen, "Id_Huyen = " + gridView1.GetFocusedRowCellValue("Id_Huyen"));
                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, ds_Huyen_filter, "Ma_Huyen"))
                        return false;
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
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblTen_Huyen.Text, lblTen_Huyen.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Huyen"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Huyen"], "");
            hashtableControls.Add(gridView1.Columns["Id_Tinh"], "");

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgrex_Dm_Huyen.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Huyen.EmbeddedNavigator.Buttons.EndEdit);
                ds_Huyen.Tables[0].Columns["Ma_Huyen"].Unique = true;

                Constraint constraint = new UniqueConstraint("constraint1",
                new DataColumn[] {ds_Huyen.Tables[0].Columns["Ten_Huyen"],
                ds_Huyen.Tables[0].Columns["Id_Tinh"]}, false);
                ds_Huyen.Tables[0].Constraints.Add(constraint);
                objMasterService.Update_Rex_Dm_Huyen_Collection(this.ds_Huyen);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("contains non-unique values") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Huyen.Text, lblMa_Huyen.Text });
                    return false;
                }
                if (ex.ToString().IndexOf("These columns don't currently have unique values") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblTen_Huyen.Text, lblTen_Huyen.Text });
                    return false;
                }
                //MessageBox.Show(ex.ToString());

            }
            this.DisplayInfo();
            return true;
        }

        public override bool PerformDelete()
        {
            if ( GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Rex_Dm_Huyen"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Rex_Dm_Huyen")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Huyen", "Id_Huyen", this.gridView1.GetFocusedRowCellValue("Id_Huyen"))) > 0)
                    {
                         GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                        return true;
                    }
                    this.DeleteObject();
                }
                catch (Exception ex)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    // GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                }
                this.DisplayInfo();
            }
            return base.PerformDelete();
        }

        public override object PerformSelectOneObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Huyen rex_Dm_Huyen = new Ecm.WebReferences.MasterService.Rex_Dm_Huyen();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Huyen.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    rex_Dm_Huyen.Id_Huyen = dr["Id_Huyen"];
                    rex_Dm_Huyen.Ma_Huyen = dr["Ma_Huyen"];
                    rex_Dm_Huyen.Ten_Huyen = dr["Ten_Huyen"];
                    rex_Dm_Huyen.Id_Tinh = dr["Id_Tinh"];
                }
                Selected_Rex_Dm_Huyen = rex_Dm_Huyen;
                this.Dispose();
                this.Close();
                return rex_Dm_Huyen;
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

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.dgrex_Dm_Huyen.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Huyen.EmbeddedNavigator.Buttons.EndEdit);
        }

        private void dgrex_Dm_Huyen_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + this.gridView1.GetFocusedRowCellValue("Id_Huyen") != "")
                if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Huyen", "Id_Huyen", this.gridView1.GetFocusedRowCellValue("Id_Huyen"))) > 0)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    e.Handled = true;
                }
            }
        }

        private void gridView1_InitNewRow_1(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Huyen"];
            this.addnewrow_clicked = true;
        }

        private void txtMa_Huyen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;
        }

    }


}
