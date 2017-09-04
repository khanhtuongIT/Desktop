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
    public partial class Frmware_Dm_Cuahang_Ban_Add : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Collection = new DataSet();
        object Ten_Khohang = null;
        public Ecm.WebReferences.MasterService.Ware_Dm_Cuahang_Ban ware_Dm_Cuahang_Ban;
        DataSet dsHeso_Chuongtrinh = new DataSet();
        int Heso_Cap;
        
       

        public Frmware_Dm_Cuahang_Ban_Add()
        {
            InitializeComponent();
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_By_Nhomheso("Cach_Tinh_Gia").ToDataSet();
                Heso_Cap = Convert.ToInt32(dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='Cap'", "Tinh giá theo cấp"))[0]["Heso"]);
                if (Heso_Cap == 1)
                {
                    gridLookup_giaTheoCap.DataSource = objMasterService.Ware_Dm_Cap_SelectAll().ToDataSet().Tables[0];
                }

                ds_Collection = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().ToDataSet();
                dgware_Dm_Cuahang_Ban.DataSource = ds_Collection;
                dgware_Dm_Cuahang_Ban.DataMember = ds_Collection.Tables[0].TableName;

                this.Data = ds_Collection;
                this.GridControl = dgware_Dm_Cuahang_Ban;
                this.DataBindingControl();

                this.ChangeStatus(false);
                dgware_Dm_Cuahang_Ban.Enabled = true;
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
            this.txtMa_Cuahang_Ban.DataBindings.Clear();
            this.txtTen_Cuahang_Ban.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtMa_Cuahang_Ban.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ma_Cuahang_ban");
                this.txtTen_Cuahang_Ban.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ten_Cuahang_ban");
                
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                ////// GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }
        }

        public override void ChangeStatus(bool editTable)
        {
            this.gridView1.OptionsBehavior.Editable = !editTable;
            //this.dgware_Dm_Cuahang_Ban.Enabled = !editTable;
            this.txtMa_Cuahang_Ban.Properties.ReadOnly = !editTable;
            this.txtTen_Cuahang_Ban.Properties.ReadOnly = !editTable;
            
        }

        public override void ResetText()
        {
            this.txtMa_Cuahang_Ban.EditValue = null;
            this.txtTen_Cuahang_Ban.EditValue = null;
        }

        #region Event Override

        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Cuahang_Ban objWare_Dm_Cuahang_Ban = new Ecm.WebReferences.MasterService.Ware_Dm_Cuahang_Ban();
            objWare_Dm_Cuahang_Ban.Id_Cuahang_Ban = -1;
            objWare_Dm_Cuahang_Ban.Ma_Cuahang_Ban = txtMa_Cuahang_Ban.EditValue;
            objWare_Dm_Cuahang_Ban.Ten_Cuahang_Ban = txtTen_Cuahang_Ban.EditValue;
            return objMasterService.Insert_Ware_Dm_Cuahang_Ban(objWare_Dm_Cuahang_Ban);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Cuahang_Ban objWare_Dm_Cuahang_Ban = new Ecm.WebReferences.MasterService.Ware_Dm_Cuahang_Ban();
            objWare_Dm_Cuahang_Ban.Id_Cuahang_Ban = gridView1.GetFocusedRowCellValue("Id_Cuahang_Ban");
            objWare_Dm_Cuahang_Ban.Ma_Cuahang_Ban = txtMa_Cuahang_Ban.EditValue;
            objWare_Dm_Cuahang_Ban.Ten_Cuahang_Ban = txtTen_Cuahang_Ban.EditValue;
            return objMasterService.Update_Ware_Dm_Cuahang_Ban(objWare_Dm_Cuahang_Ban);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Cuahang_Ban objWare_Dm_Cuahang_Ban = new Ecm.WebReferences.MasterService.Ware_Dm_Cuahang_Ban();
            objWare_Dm_Cuahang_Ban.Id_Cuahang_Ban = gridView1.GetFocusedRowCellValue("Id_Cuahang_Ban");
            return objMasterService.Delete_Ware_Dm_Cuahang_Ban(objWare_Dm_Cuahang_Ban);
        }

        public override bool PerformAdd()
        {
            ClearDataBindings();
            this.ChangeStatus(true);
            this.ResetText();
            //dgware_Dm_Cuahang_Ban.Enabled = false;
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
                hashtableControls.Add(txtMa_Cuahang_Ban, lblMa_Cuahang_Ban.Text);
                hashtableControls.Add(txtTen_Cuahang_Ban, lblTen_Cuahang_Ban.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                hashtableControls.Remove(txtMa_Cuahang_Ban);
                //if (!txtTen_Cuahang_Ban.EditValue.Equals(Ten_Khohang))
                //{
                //    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htbTen_Cuahang, ds_Collection, "Ten_Cuahang_Ban"))
                //        return false;
                //}

                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                {
                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, ds_Collection, "Ten_Cuahang_Ban"))
                        return false;
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    if (!txtTen_Cuahang_Ban.EditValue.Equals(Ten_Khohang))
                    {
                        if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, ds_Collection, "Ten_Cuahang_Ban"))
                            return false;
                    }
                    success = (bool)this.UpdateObject();
                }

                if (success)
                {
                    Ten_Khohang = null;
                    this.DisplayInfo();

                }
                return success;
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("exists") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Cuahang_Ban.Text, lblMa_Cuahang_Ban.Text.ToLower() });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Cuahang_Ban"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Cuahang_Ban"], "");
           

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

         // hashtableControls.Add(gridView1.Columns["Id_Cap"],"");
            
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgware_Dm_Cuahang_Ban.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Cuahang_Ban.EmbeddedNavigator.Buttons.EndEdit);
                this.ds_Collection.Tables[0].Columns["Ma_Cuahang_Ban"].Unique = true;
                objMasterService.Update_Ware_Dm_Cuahang_Ban_Collection(this.ds_Collection);
               
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Cuahang_Ban.Text, lblMa_Cuahang_Ban.Text.ToLower() });
                    return false;
                }
             //  MessageBox.Show(ex.ToString());
            }
            this.DisplayInfo();
            return true;
        }

        public override bool PerformDelete()
        {
            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Dm_Cuahang_Ban"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Dm_Cuahang_Ban")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Ware_Dm_Cuahang_Ban", "Id_Cuahang_Ban", this.gridView1.GetFocusedRowCellValue("Id_Cuahang_Ban"))) > 0)
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
            try
            {
                ware_Dm_Cuahang_Ban = new Ecm.WebReferences.MasterService.Ware_Dm_Cuahang_Ban();
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Collection.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    ware_Dm_Cuahang_Ban.Id_Cuahang_Ban = dr["Id_Cuahang_Ban"];
                    ware_Dm_Cuahang_Ban.Ma_Cuahang_Ban = dr["Ma_Cuahang_Ban"];
                    ware_Dm_Cuahang_Ban.Ten_Cuahang_Ban = dr["Ten_Cuahang_Ban"];
                   ware_Dm_Cuahang_Ban.Id_Cap = dr["Id_Cap"];                    
                }
                this.Dispose();
                this.Close();
                return ware_Dm_Cuahang_Ban;
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

        #region events

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Cuahang_Ban"];
            gridView1.SetFocusedRowCellValue("Id_Cap", 3);

            this.addnewrow_clicked = true;
            this.gridView1.OptionsBehavior.Editable = true;

            gridView1.SetFocusedRowCellValue("Kho_Hang", false);
            this.ChangeFormState(GoobizFrame.Windows.Forms.FormState.Add);
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.dgware_Dm_Cuahang_Ban.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Cuahang_Ban.EmbeddedNavigator.Buttons.EndEdit);
        }

        private void dgware_Dm_Cuahang_Ban_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + this.gridView1.GetFocusedRowCellValue("Id_Cuahang_Ban") != "")
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Ware_Dm_Cuahang_Ban", "Id_Cuahang_Ban", this.gridView1.GetFocusedRowCellValue("Id_Cuahang_Ban"))) > 0)
                    {
                        GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                        e.Handled = true;
                    }
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Ten_Khohang = gridView1.GetFocusedRowCellValue("Ten_Cuahang_Ban");
        }

        private void txtMa_Cuahang_Ban_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;
        }

        #endregion

        private void dgware_Dm_Cuahang_Ban_Click(object sender, EventArgs e)
        {

        }

    }
}

