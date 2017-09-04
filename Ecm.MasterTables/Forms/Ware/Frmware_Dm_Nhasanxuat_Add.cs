using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Ware
{
    public partial class Frmware_Dm_Nhasanxuat_Add :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        //Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Collection = new DataSet();
        public Ecm.WebReferences.MasterService.Ware_Dm_Nhasanxuat Selected_Ware_Dm_Nhasanxuat;
        public Frmware_Dm_Nhasanxuat_Add()
        {
            InitializeComponent();
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                //Get data Ware_Dm_Quocgia
                DataSet dsWare_Dm_Quocgia = objMasterService.Get_All_Rex_Dm_Quocgia_Collection().ToDataSet();
                lookUpEdit_Quocgia.Properties.DataSource     = dsWare_Dm_Quocgia.Tables[0];
                gridLookUp_Quocgia.DataSource = dsWare_Dm_Quocgia.Tables[0];

                //Get data Ware_Dm_Nhasanxuat
                ds_Collection = objMasterService.Get_All_Ware_Dm_Nhasanxuat().ToDataSet();
                dgware_Dm_Nhasanxuat.DataSource = ds_Collection;
                dgware_Dm_Nhasanxuat.DataMember = ds_Collection.Tables[0].TableName;

                this.Data = ds_Collection;
                this.GridControl = dgware_Dm_Nhasanxuat;

                this.DataBindingControl();

                this.ChangeStatus(false);

                this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#endif

                //// GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }

        }

        void ClearDataBindings()
        {
            this.txtId_Nhasanxuat.DataBindings.Clear();
            this.txtMa_Nhasanxuat.DataBindings.Clear();
            this.txtTen_Nhasanxuat.DataBindings.Clear();
            this.txtDiachi.DataBindings.Clear();
            this.txtMasothue.DataBindings.Clear();
            this.txtDienthoai.DataBindings.Clear();
            this.txtFax.DataBindings.Clear();
            this.txtEmail.DataBindings.Clear();
            this.txtWebsite.DataBindings.Clear();
            this.lookUpEdit_Quocgia.DataBindings.Clear();
        }

        public void DataBindingControl()
        {
            try
            {
                ClearDataBindings();

                this.txtId_Nhasanxuat.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Nhasanxuat");
                this.txtMa_Nhasanxuat.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ma_Nhasanxuat");
                this.txtTen_Nhasanxuat.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ten_Nhasanxuat");
                this.txtDiachi.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Diachi");
                this.txtMasothue.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Masothue");
                this.txtDienthoai.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Dienthoai");
                this.txtFax.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Fax");
                this.txtEmail.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Email");
                this.txtWebsite.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Website");
                this.lookUpEdit_Quocgia.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Quocgia");

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
            //this.dgware_Dm_Nhasanxuat.Enabled = !editTable;
            this.gridView1.OptionsBehavior.Editable = !editTable;
            this.txtMa_Nhasanxuat.Properties.ReadOnly = !editTable;
            this.txtTen_Nhasanxuat.Properties.ReadOnly = !editTable;
            this.txtDiachi.Properties.ReadOnly = !editTable;
            this.txtMasothue.Properties.ReadOnly = !editTable;
            this.txtDienthoai.Properties.ReadOnly = !editTable;
            this.txtFax.Properties.ReadOnly = !editTable;
            this.txtEmail.Properties.ReadOnly = !editTable;
            this.txtWebsite.Properties.ReadOnly = !editTable;
            this.lookUpEdit_Quocgia.Properties.ReadOnly = !editTable;
        }

        public void ResetText()
        {
            this.txtId_Nhasanxuat.EditValue = "";
            this.txtMa_Nhasanxuat.EditValue = "";
            this.txtTen_Nhasanxuat.EditValue = "";
            this.txtDiachi.EditValue = "";
            this.txtMasothue.EditValue = "";
            this.txtDienthoai.EditValue = "";
            this.txtFax.EditValue = "";
            this.txtEmail.EditValue = "";
            this.txtWebsite.EditValue = "";
            this.lookUpEdit_Quocgia.EditValue = "";
        }

        #region Event Override
        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Nhasanxuat objWare_Dm_Nhasanxuat = new Ecm.WebReferences.MasterService.Ware_Dm_Nhasanxuat();
            objWare_Dm_Nhasanxuat.Id_Nhasanxuat     = -1;
            objWare_Dm_Nhasanxuat.Ma_Nhasanxuat     = txtMa_Nhasanxuat.EditValue;
            objWare_Dm_Nhasanxuat.Ten_Nhasanxuat    = txtTen_Nhasanxuat.EditValue;
            objWare_Dm_Nhasanxuat.Diachi            = txtDiachi.EditValue;
            objWare_Dm_Nhasanxuat.Masothue          = txtMasothue.EditValue;
            objWare_Dm_Nhasanxuat.Dienthoai         = txtDienthoai.EditValue;
            objWare_Dm_Nhasanxuat.Fax               = txtFax.EditValue;
            objWare_Dm_Nhasanxuat.Email             = txtEmail.EditValue;
            objWare_Dm_Nhasanxuat.Website           = txtWebsite.EditValue;
            if ("" + lookUpEdit_Quocgia.EditValue != "")
                objWare_Dm_Nhasanxuat.Id_Quocgia    = lookUpEdit_Quocgia.EditValue;

            return objMasterService.Insert_Ware_Dm_Nhasanxuat(objWare_Dm_Nhasanxuat);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Nhasanxuat objWare_Dm_Nhasanxuat = new Ecm.WebReferences.MasterService.Ware_Dm_Nhasanxuat();
            objWare_Dm_Nhasanxuat.Id_Nhasanxuat = gridView1.GetFocusedRowCellValue("Id_Nhasanxuat");
            objWare_Dm_Nhasanxuat.Ma_Nhasanxuat     = txtMa_Nhasanxuat.EditValue;
            objWare_Dm_Nhasanxuat.Ten_Nhasanxuat    = txtTen_Nhasanxuat.EditValue;
            objWare_Dm_Nhasanxuat.Diachi            = txtDiachi.EditValue;
            objWare_Dm_Nhasanxuat.Masothue          = txtMasothue.EditValue;
            objWare_Dm_Nhasanxuat.Dienthoai         = txtDienthoai.EditValue;
            objWare_Dm_Nhasanxuat.Fax               = txtFax.EditValue;
            objWare_Dm_Nhasanxuat.Email             = txtEmail.EditValue;
            objWare_Dm_Nhasanxuat.Website           = txtWebsite.EditValue;
            if ("" + lookUpEdit_Quocgia.EditValue != "")
                objWare_Dm_Nhasanxuat.Id_Quocgia = lookUpEdit_Quocgia.EditValue;


            return objMasterService.Update_Ware_Dm_Nhasanxuat(objWare_Dm_Nhasanxuat);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Nhasanxuat objWare_Dm_Nhasanxuat = new Ecm.WebReferences.MasterService.Ware_Dm_Nhasanxuat();
            objWare_Dm_Nhasanxuat.Id_Nhasanxuat = gridView1.GetFocusedRowCellValue("Id_Nhasanxuat");

            return objMasterService.Delete_Ware_Dm_Nhasanxuat(objWare_Dm_Nhasanxuat);
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
                hashtableControls.Add(txtMa_Nhasanxuat, lblMa_Nhasanxuat.Text);
                hashtableControls.Add(txtTen_Nhasanxuat, lblTen_Nhasanxuat.Text);

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
                if (ex.ToString().IndexOf("exists_Ma_Nhasanxuat") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Nhasanxuat.Text, lblMa_Nhasanxuat.Text.ToLower() });
                }
                else if (ex.ToString().IndexOf("exists_Masothue") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMasothue.Text, lblMasothue.Text.ToLower() });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Nhasanxuat"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Nhasanxuat"], "");

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgware_Dm_Nhasanxuat.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Nhasanxuat.EmbeddedNavigator.Buttons.EndEdit);
                ds_Collection.Tables[0].Columns["Ma_Nhasanxuat"].Unique = true;
                ds_Collection.Tables[0].Columns["Masothue"].Unique = true;
                objMasterService.Update_Ware_Dm_Nhasanxuat_Collection(this.ds_Collection);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1 && ex.ToString().IndexOf("Ma_Nhasanxuat") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Nhasanxuat.Text, lblMa_Nhasanxuat.Text.ToLower() });

                    return false;
                }
                else if (ex.ToString().IndexOf("Unique") != -1 && ex.ToString().IndexOf("Masothue") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMasothue.Text, lblMasothue.Text.ToLower() });

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
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Dm_Nhasanxuat"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Dm_Nhasanxuat")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Ware_Dm_Nhasanxuat", "Id_Nhasanxuat", this.gridView1.GetFocusedRowCellValue("Id_Nhasanxuat"))) > 0)
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
            Ecm.WebReferences.MasterService.Ware_Dm_Nhasanxuat ware_Dm_Nhasanxuat = new Ecm.WebReferences.MasterService.Ware_Dm_Nhasanxuat();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Collection.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    ware_Dm_Nhasanxuat.Id_Nhasanxuat    = dr["Id_Nhasanxuat"];
                    ware_Dm_Nhasanxuat.Ma_Nhasanxuat    = dr["Ma_Nhasanxuat"];
                    ware_Dm_Nhasanxuat.Ten_Nhasanxuat   = dr["Ten_Nhasanxuat"];
                    ware_Dm_Nhasanxuat.Diachi           = dr["Diachi"];
                    ware_Dm_Nhasanxuat.Masothue         = dr["Masothue"];
                    ware_Dm_Nhasanxuat.Dienthoai        = dr["Dienthoai"];
                    ware_Dm_Nhasanxuat.Fax              = dr["Fax"];
                    ware_Dm_Nhasanxuat.Email            = dr["Email"];
                    ware_Dm_Nhasanxuat.Website          = dr["Website"];
                    ware_Dm_Nhasanxuat.Id_Quocgia       = dr["Id_Quocgia"];
                }
                Selected_Ware_Dm_Nhasanxuat = ware_Dm_Nhasanxuat;
                this.Dispose();
                this.Close();
                return ware_Dm_Nhasanxuat;
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
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Nhasanxuat"];
            this.addnewrow_clicked = true;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.dgware_Dm_Nhasanxuat.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Nhasanxuat.EmbeddedNavigator.Buttons.EndEdit);
        }

        private void dgware_Dm_Nhasanxuat_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if (Convert.ToInt32(objMasterService.GetExistReferences("Ware_Dm_Nhasanxuat", "Id_Nhasanxuat", this.gridView1.GetFocusedRowCellValue("Id_Nhasanxuat"))) > 0)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    e.Handled = true;
                }
            }
        }
    }
}

