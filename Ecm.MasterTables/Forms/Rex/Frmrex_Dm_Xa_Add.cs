using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Rex
{
    public partial class Frmrex_Dm_Xa_Add :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        //Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Xa = new DataSet();
        public Ecm.WebReferences.MasterService.Rex_Dm_Xa Selected_Rex_Dm_Xa;
        public Frmrex_Dm_Xa_Add()
        {
            InitializeComponent();
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                DataSet ds_Huyen = new DataSet();
                ds_Huyen = objMasterService.Get_All_Rex_Dm_Huyen_With_Tentinh_Collection().ToDataSet();
                lookUp_Huyen.Properties.DataSource = ds_Huyen.Tables[0];
                gridLookUp_Huyen.DataSource = ds_Huyen.Tables[0];

                //LookupEdit_Huyen.Properties.data = ds_Huyen.Tables[0].TableName;

                ds_Xa = objMasterService.Get_All_Rex_Dm_Xa_Collection().ToDataSet();
                dgrex_Dm_Xa.DataSource = ds_Xa;
                dgrex_Dm_Xa.DataMember = ds_Xa.Tables[0].TableName;

                this.Data = ds_Xa;
                this.GridControl = dgrex_Dm_Xa;

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
            this.lookUp_Huyen.DataBindings.Clear();
            this.txtMa_Xa.DataBindings.Clear();
            this.txtTen_Xa.DataBindings.Clear();
        }

        public void DataBindingControl()
        {
            try
            {
                ClearDataBindings();

                this.lookUp_Huyen.DataBindings.Add("EditValue", ds_Xa, ds_Xa.Tables[0].TableName + ".Id_Huyen");
                this.txtMa_Xa.DataBindings.Add("EditValue", ds_Xa, ds_Xa.Tables[0].TableName + ".Ma_Xa");
                this.txtTen_Xa.DataBindings.Add("EditValue", ds_Xa, ds_Xa.Tables[0].TableName + ".Ten_Xa");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ChangeStatus(bool editTable)
        {
            //this.dgrex_Dm_Xa.Enabled = !editTable;
            this.gridView1.OptionsBehavior.Editable = !editTable;
            this.txtMa_Xa.Properties.ReadOnly = !editTable;
            this.txtTen_Xa.Properties.ReadOnly = !editTable;
            this.lookUp_Huyen.Properties.ReadOnly = !editTable;
        }

        public override void  ResetText()
        {
            this.lookUp_Huyen.EditValue = "";
            this.txtMa_Xa.EditValue = "";
            this.txtTen_Xa.EditValue = "";
        }

        private void Frmrex_Dm_Xa_Add_Load(object sender, EventArgs e)
        {
            //this.DisplayInfo();
        }

        #region Event Override
        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Xa objRex_Dm_Xa = new Ecm.WebReferences.MasterService.Rex_Dm_Xa();
            objRex_Dm_Xa.Id_Xa = -1;
            objRex_Dm_Xa.Ma_Xa = txtMa_Xa.EditValue;
            objRex_Dm_Xa.Ten_Xa = txtTen_Xa.EditValue;
            objRex_Dm_Xa.Id_Huyen = lookUp_Huyen.EditValue;

            return objMasterService.Insert_Rex_Dm_Xa(objRex_Dm_Xa);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Xa objRex_Dm_Xa = new Ecm.WebReferences.MasterService.Rex_Dm_Xa();
            objRex_Dm_Xa.Id_Xa = gridView1.GetFocusedRowCellValue("Id_Xa");
            objRex_Dm_Xa.Ma_Xa = txtMa_Xa.EditValue;
            objRex_Dm_Xa.Ten_Xa = txtTen_Xa.EditValue;
            objRex_Dm_Xa.Id_Huyen = lookUp_Huyen.EditValue;

            return objMasterService.Update_Rex_Dm_Xa(objRex_Dm_Xa);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Xa objRex_Dm_Xa = new Ecm.WebReferences.MasterService.Rex_Dm_Xa();
            objRex_Dm_Xa.Id_Xa = gridView1.GetFocusedRowCellValue("Id_Xa");

            return objMasterService.Delete_Rex_Dm_Xa(objRex_Dm_Xa);
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
                hashtableControls.Add(txtMa_Xa, lblMa_Xa.Text);
                hashtableControls.Add(txtTen_Xa, lblTen_Xa.Text);
                hashtableControls.Add(lookUp_Huyen, lblId_Huyen.Text);

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;
                
                

                if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Add)
                {  
                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, (DataSet)dgrex_Dm_Xa.DataSource, "Ma_Xa"))
                        return false;                  
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    DataSet ds_Xa_filter =  GoobizFrame.Windows.MdiUtils.Validator.datasetFillter(ds_Xa, "Id_Xa = " + gridView1.GetFocusedRowCellValue("Id_Xa"));
                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, ds_Xa_filter, "Ma_Xa"))
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
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblTen_Xa.Text, lblTen_Xa.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Xa"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Xa"], "");
            hashtableControls.Add(gridView1.Columns["Id_Huyen"], "");

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgrex_Dm_Xa.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Xa.EmbeddedNavigator.Buttons.EndEdit);
                ds_Xa.Tables[0].Columns["Ma_Xa"].Unique = true;

                Constraint constraint = new UniqueConstraint("constraint1",
                new DataColumn[] {ds_Xa.Tables[0].Columns["Ten_Xa"],
                ds_Xa.Tables[0].Columns["Id_Huyen"]}, false);
                ds_Xa.Tables[0].Constraints.Add(constraint);

                objMasterService.Update_Rex_Dm_Xa_Collection(this.ds_Xa);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("contains non-unique values") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Xa.Text, lblMa_Xa.Text });
                    return false;
                }
                if (ex.ToString().IndexOf("These columns don't currently have unique values") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblTen_Xa.Text, lblTen_Xa.Text });
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
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Rex_Dm_Xa"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Rex_Dm_Xa")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Xa", "Id_Xa", this.gridView1.GetFocusedRowCellValue("Id_Xa"))) > 0)
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
            Ecm.WebReferences.MasterService.Rex_Dm_Xa rex_Dm_Xa = new Ecm.WebReferences.MasterService.Rex_Dm_Xa();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Xa.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    rex_Dm_Xa.Id_Xa = dr["Id_Xa"];
                    rex_Dm_Xa.Ma_Xa = dr["Ma_Xa"];
                    rex_Dm_Xa.Ten_Xa = dr["Ten_Xa"];
                    rex_Dm_Xa.Id_Huyen = dr["Id_Huyen"];
                }
                Selected_Rex_Dm_Xa = rex_Dm_Xa;
                this.Dispose();
                this.Close();
                return rex_Dm_Xa;
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
            this.dgrex_Dm_Xa.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Xa.EmbeddedNavigator.Buttons.EndEdit);
        }

        private void dgrex_Dm_Xa_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + this.gridView1.GetFocusedRowCellValue("Id_Xa") != "")
                if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Xa", "Id_Xa", this.gridView1.GetFocusedRowCellValue("Id_Xa"))) > 0)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    e.Handled = true;
                }
            }
        }

        private void gridView1_InitNewRow_1(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Xa"];
            this.addnewrow_clicked = true;
        }

        private void txtMa_Xa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;
        }
    }
}
