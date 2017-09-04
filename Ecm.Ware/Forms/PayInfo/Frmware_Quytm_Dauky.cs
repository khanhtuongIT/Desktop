using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Quytm_Dauky :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Collection = new DataSet();

        public Frmware_Quytm_Dauky()
        {
            InitializeComponent();
            this.DisplayInfo();
        }

        #region Event Override

        public override void DisplayInfo()
        {
            try
            {
                //Get data Ware_Dm_Loai_Quytm
                DataSet dsWare_Dm_Loai_Quytm = objMasterService.Get_All_Ware_Dm_Loai_Quytm().ToDataSet();
                lookUpEdit_Loai_Quytm.Properties.DataSource = dsWare_Dm_Loai_Quytm.Tables[0];
                gridLookUpEdit_Loai_Quytm.DataSource = dsWare_Dm_Loai_Quytm.Tables[0];
                gridLookUpEdit_Loai_Quytm1.DataSource = dsWare_Dm_Loai_Quytm.Tables[0];

                //Get data Ware_Quytm_Dauky
                ds_Collection = objWareService.Get_All_Ware_Quytm_Dauky().ToDataSet();
                dgware_Quytm_Dauky.DataSource = ds_Collection;
                dgware_Quytm_Dauky.DataMember = ds_Collection.Tables[0].TableName;

                this.Data = ds_Collection;
                this.GridControl = dgware_Quytm_Dauky;
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

        void ClearDataBindings()
        {
            this.txtId_Quytm_Dauky.DataBindings.Clear();
            this.txtSotien.DataBindings.Clear();
            this.txtGhichu.DataBindings.Clear();
            this.lookUpEdit_Loai_Quytm.DataBindings.Clear();
        }

        public void DataBindingControl()
        {
            try
            {
                ClearDataBindings();

                this.txtId_Quytm_Dauky.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Quytm_Dauky");
                this.txtSotien.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Sotien");
                this.txtGhichu.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ghichu");
                this.lookUpEdit_Loai_Quytm.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Loai_Quytm");
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
  
            }
        }

        public void ChangeStatus(bool editTable)
        {
            this.gridView1.OptionsBehavior.Editable = !editTable;
            this.txtTen_Loai_Quytm.Properties.ReadOnly = !editTable;
            this.txtSotien.Properties.ReadOnly = !editTable;
            this.txtGhichu.Properties.ReadOnly = !editTable;
            this.lookUpEdit_Loai_Quytm.Properties.ReadOnly = !editTable;
        }

        public void ResetText()
        {
            this.txtId_Quytm_Dauky.EditValue = "";
            this.txtGhichu.EditValue = "";
            this.txtTen_Loai_Quytm.EditValue = "";
            this.txtSotien.EditValue = null;
            this.lookUpEdit_Loai_Quytm.EditValue = null;
        }

        public object InsertObject()
        {
            Ecm.WebReferences.WareService.Ware_Quytm_Dauky objWare_Quytm_Dauky = new Ecm.WebReferences.WareService.Ware_Quytm_Dauky();
            objWare_Quytm_Dauky.Id_Quytm_Dauky = -1;
            objWare_Quytm_Dauky.Ghichu = txtGhichu.EditValue;            
            if("" + txtSotien.EditValue != "")
                objWare_Quytm_Dauky.Sotien = txtSotien.EditValue;

            if ("" + lookUpEdit_Loai_Quytm.EditValue != "")
                objWare_Quytm_Dauky.Id_Loai_Quytm = lookUpEdit_Loai_Quytm.EditValue;

            return objWareService.Insert_Ware_Quytm_Dauky(objWare_Quytm_Dauky);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.WareService.Ware_Quytm_Dauky objWare_Quytm_Dauky = new Ecm.WebReferences.WareService.Ware_Quytm_Dauky();
            objWare_Quytm_Dauky.Id_Quytm_Dauky = gridView1.GetFocusedRowCellValue("Id_Quytm_Dauky");
            objWare_Quytm_Dauky.Ghichu = txtGhichu.EditValue;
            if ("" + txtSotien.EditValue != "")
                objWare_Quytm_Dauky.Sotien = txtSotien.EditValue;

            if ("" + lookUpEdit_Loai_Quytm.EditValue != "")
                objWare_Quytm_Dauky.Id_Loai_Quytm = lookUpEdit_Loai_Quytm.EditValue;

            return objWareService.Update_Ware_Quytm_Dauky(objWare_Quytm_Dauky);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.WareService.Ware_Quytm_Dauky objWare_Quytm_Dauky = new Ecm.WebReferences.WareService.Ware_Quytm_Dauky();
            objWare_Quytm_Dauky.Id_Quytm_Dauky = gridView1.GetFocusedRowCellValue("Id_Quytm_Dauky");
            return objWareService.Delete_Ware_Quytm_Dauky(objWare_Quytm_Dauky);
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
            return true;
        }

        public override bool PerformSave()
        {
            try
            {
                bool success = false;

                 GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(txtSotien, lblSotien.Text);
                hashtableControls.Add(lookUpEdit_Loai_Quytm, lblMa_Loai_Quytm.Text);

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
            hashtableControls.Add(gridView1.Columns["Sotien"], "");
            hashtableControls.Add(gridView1.Columns["Id_Loai_Quytm"], "");

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                this.DoClickEndEdit(dgware_Quytm_Dauky);
                objWareService.Update_Ware_Quytm_Dauky_Collection(this.ds_Collection);
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
            if ( GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Quytm_Dauky"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Quytm_Dauky")   }) == DialogResult.Yes)
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
            Ecm.WebReferences.WareService.Ware_Quytm_Dauky ware_Quytm_Dauky = new Ecm.WebReferences.WareService.Ware_Quytm_Dauky();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Collection.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    ware_Quytm_Dauky.Id_Quytm_Dauky = dr["Id_Quytm_Dauky"];
                    ware_Quytm_Dauky.Sotien = dr["Sotien"];
                    ware_Quytm_Dauky.Ghichu = dr["Ghichu"];
                    ware_Quytm_Dauky.Id_Loai_Quytm = dr["Id_Loai_Quytm"];
                }
                this.Dispose();
                this.Close();
                return ware_Quytm_Dauky;
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
            this.gridView1.FocusedColumn = gridView1.Columns["Id_Loai_Quytm"];
            this.addnewrow_clicked = true;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.DoClickEndEdit(dgware_Quytm_Dauky); 
        }

        private void lookUpEdit_Loai_Quytm_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit_Loai_Quytm.EditValue != null)
                txtTen_Loai_Quytm.EditValue = lookUpEdit_Loai_Quytm.GetColumnValue("Ten_Loai_Quytm");
        }
        #endregion


    }
}

