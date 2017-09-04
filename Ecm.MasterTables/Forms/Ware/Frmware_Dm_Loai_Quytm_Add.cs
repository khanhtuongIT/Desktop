using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Ware
{
    public partial class Frmware_Dm_Loai_Quytm_Add :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
               public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Collection = new DataSet();

        public Frmware_Dm_Loai_Quytm_Add()
        {
            InitializeComponent();
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                //Get data 
                ds_Collection = objMasterService.Get_All_Ware_Dm_Loai_Quytm().ToDataSet();
                dgware_Dm_Loai_Quytm.DataSource = ds_Collection;
                dgware_Dm_Loai_Quytm.DataMember = ds_Collection.Tables[0].TableName;

                this.Data = ds_Collection;
                this.GridControl = dgware_Dm_Loai_Quytm;

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
            this.txtId_Loai_Quytm.DataBindings.Clear();
            this.txtMa_Loai_Quytm.DataBindings.Clear();
            this.txtTen_Loai_Quytm.DataBindings.Clear();
            this.txtGhichu.DataBindings.Clear();
        }

        public void DataBindingControl()
        {
            try
            {
                ClearDataBindings();

                this.txtId_Loai_Quytm.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName +  ".Id_Loai_Quytm");
                this.txtMa_Loai_Quytm.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName +  ".Ma_Loai_Quytm");
                this.txtTen_Loai_Quytm.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ten_Loai_Quytm");
                this.txtGhichu.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName +         ".Ghichu");
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif

                //// GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }
        }

        public void ChangeStatus(bool editTable)
        {
            //this.dgware_Dm_Loai_Quytm.Enabled           = !editTable;
            this.txtMa_Loai_Quytm.Properties.ReadOnly   = !editTable;
            this.txtTen_Loai_Quytm.Properties.ReadOnly  = !editTable;
            this.txtGhichu.Properties.ReadOnly          = !editTable;
        }

        public void ResetText()
        {
            this.txtId_Loai_Quytm.EditValue = "";
            this.txtMa_Loai_Quytm.EditValue = "";
            this.txtTen_Loai_Quytm.EditValue = "";
            this.txtGhichu.EditValue = "";
        }

        #region Event Override
        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Loai_Quytm objWare_Dm_Loai_Quytm = new Ecm.WebReferences.MasterService.Ware_Dm_Loai_Quytm();
            objWare_Dm_Loai_Quytm.Id_Loai_Quytm     = -1;
            objWare_Dm_Loai_Quytm.Ma_Loai_Quytm     = txtMa_Loai_Quytm.EditValue;
            objWare_Dm_Loai_Quytm.Ten_Loai_Quytm    = txtTen_Loai_Quytm.EditValue;
            objWare_Dm_Loai_Quytm.Ghichu            = txtGhichu.EditValue;

            return objMasterService.Insert_Ware_Dm_Loai_Quytm(objWare_Dm_Loai_Quytm);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Loai_Quytm objWare_Dm_Loai_Quytm = new Ecm.WebReferences.MasterService.Ware_Dm_Loai_Quytm();
            objWare_Dm_Loai_Quytm.Id_Loai_Quytm = gridView1.GetFocusedRowCellValue("Id_Loai_Quytm");
            objWare_Dm_Loai_Quytm.Ma_Loai_Quytm     = txtMa_Loai_Quytm.EditValue;
            objWare_Dm_Loai_Quytm.Ten_Loai_Quytm    = txtTen_Loai_Quytm.EditValue;
            objWare_Dm_Loai_Quytm.Ghichu            = txtGhichu.EditValue;

            return objMasterService.Update_Ware_Dm_Loai_Quytm(objWare_Dm_Loai_Quytm);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Loai_Quytm objWare_Dm_Loai_Quytm = new Ecm.WebReferences.MasterService.Ware_Dm_Loai_Quytm();
            objWare_Dm_Loai_Quytm.Id_Loai_Quytm = gridView1.GetFocusedRowCellValue("Id_Loai_Quytm");

            return objMasterService.Delete_Ware_Dm_Loai_Quytm(objWare_Dm_Loai_Quytm);
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
                hashtableControls.Add(txtMa_Loai_Quytm, lblMa_Loai_Quytm.Text);
                hashtableControls.Add(txtTen_Loai_Quytm, lblTen_Loai_Quytm.Text);

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
                if (ex.ToString().IndexOf("exists") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Loai_Quytm.Text, lblMa_Loai_Quytm.Text.ToLower() });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Loai_Quytm"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Loai_Quytm"], "");

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgware_Dm_Loai_Quytm.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Loai_Quytm.EmbeddedNavigator.Buttons.EndEdit);
                ds_Collection.Tables[0].Columns["Ma_Loai_Quytm"].Unique = true;
                objMasterService.Update_Ware_Dm_Loai_Quytm_Collection(this.ds_Collection);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Loai_Quytm.Text, lblMa_Loai_Quytm.Text.ToLower() });
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
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Dm_Loai_Quytm"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Dm_Loai_Quytm")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Ware_Dm_Loai_Quytm", "Id_Loai_Quytm", this.gridView1.GetFocusedRowCellValue("Id_Loai_Quytm"))) > 0)
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
            Ecm.WebReferences.MasterService.Ware_Dm_Loai_Quytm ware_Dm_Loai_Quytm = new Ecm.WebReferences.MasterService.Ware_Dm_Loai_Quytm();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Collection.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    ware_Dm_Loai_Quytm.Id_Loai_Quytm    = dr["Id_Loai_Quytm"];
                    ware_Dm_Loai_Quytm.Ma_Loai_Quytm    = dr["Ma_Loai_Quytm"];
                    ware_Dm_Loai_Quytm.Ten_Loai_Quytm   = dr["Ten_Loai_Quytm"];
                    ware_Dm_Loai_Quytm.Ghichu           = dr["Ghichu"];
                }
                this.Dispose();
                this.Close();
                return ware_Dm_Loai_Quytm;
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
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Loai_Quytm"];
            this.addnewrow_clicked = true;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.dgware_Dm_Loai_Quytm.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Loai_Quytm.EmbeddedNavigator.Buttons.EndEdit);
        }

        private void dgware_Dm_Loai_Quytm_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if (Convert.ToInt32(objMasterService.GetExistReferences("Ware_Dm_Loai_Quytm", "Id_Loai_Quytm", this.gridView1.GetFocusedRowCellValue("Id_Loai_Quytm"))) > 0)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    e.Handled = true;
                }
            }
        }
    }
}

