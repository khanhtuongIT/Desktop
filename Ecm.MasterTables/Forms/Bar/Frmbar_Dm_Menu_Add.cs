using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Bar
{
    public partial class Frmbar_Dm_Menu_Add :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        //Ecm.WebReferences.Classes.MasterService objMasterService = new Ecm.Bar.Ecm.WebReferences.Classes.MasterService();
        public Ecm.WebReferences.MasterService.Bar_Dm_Menu SelectedBar_Dm_Menu;
        Ecm.MasterTables.Forms.Ware.Frmware_Dm_Nhom_Hanghoa_Ban_Add frmware_Dm_Nhom_Hanghoa_Ban_Add = new  Ecm.MasterTables.Forms.Ware.Frmware_Dm_Nhom_Hanghoa_Ban_Add();
        DataSet ds_Collection = new DataSet();
        public Frmbar_Dm_Menu_Add()
        {
            InitializeComponent();
            this.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            
            try
            {
                //gridLookUpEditNhom_Hanghoa_Ban
                DataSet dsNhom_Hanghoa = objMasterService.Get_All_Ware_Dm_Nhom_Hanghoa_Ban().ToDataSet();
                gridLookUpEditNhom_Hanghoa_Ban.DataSource = dsNhom_Hanghoa.Tables[0] ;
                lookUpEdit_Nhom_Hanghoa_Ban.Properties.DataSource = dsNhom_Hanghoa.Tables[0];

                //dgbar_Dm_Menu
                ds_Collection = objMasterService.Get_All_Bar_Dm_Menu().ToDataSet();
                dgbar_Dm_Menu.DataSource = ds_Collection;
                dgbar_Dm_Menu.DataMember = ds_Collection.Tables[0].TableName;

                this.Data = ds_Collection;
                this.GridControl = dgbar_Dm_Menu;

                this.DataBindingControl();

                this.ChangeStatus(false);

                this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif

                ////Ecm.HelperClasses.ExceptionLogger.LogException1(ex);
            }

        }

        public override void  ClearDataBindings()
        {
            //this.txtId_Menu.DataBindings.Clear();
            this.txtMa_Menu.DataBindings.Clear();
            this.txtTen_Menu.DataBindings.Clear();
            this.txtGhichu.DataBindings.Clear();
            lookUpEdit_Nhom_Hanghoa_Ban.DataBindings.Clear();
        }
        public override void  DataBindingControl()
        {
            try
            {
                this.ClearDataBindings();
                //this.txtId_Menu.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName +    ".Id_Menu");
                this.txtMa_Menu.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName +    ".Ma_Menu");
                this.txtTen_Menu.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName +   ".Ten_Menu");
                this.txtGhichu.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName +     ".Ghichu");
                this.lookUpEdit_Nhom_Hanghoa_Ban.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Nhom_Hanghoa_Ban");
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                ////Ecm.HelperClasses.ExceptionLogger.LogException1(ex);
            }
        }

        public override void  ChangeStatus(bool editTable)
        {
            //this.dgbar_Dm_Menu.Enabled              = !editTable;
            this.txtMa_Menu.Properties.ReadOnly     = !editTable;
            this.txtTen_Menu.Properties.ReadOnly    = !editTable;
            this.txtGhichu.Properties.ReadOnly      = !editTable;
            this.lookUpEdit_Nhom_Hanghoa_Ban.Properties.ReadOnly = !editTable;
        }

        public override void  ResetText()
        {
            //this.txtId_Menu.EditValue   = "";
            this.txtMa_Menu.EditValue   = "";
            this.txtTen_Menu.EditValue  = "";
            this.txtGhichu.EditValue    = "";
        }

        #region Event Override
        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Bar_Dm_Menu objBar_Dm_Menu = new Ecm.WebReferences.MasterService.Bar_Dm_Menu();
            objBar_Dm_Menu.Id_Menu  = -1;
            objBar_Dm_Menu.Ma_Menu  = txtMa_Menu.EditValue;
            objBar_Dm_Menu.Ten_Menu = txtTen_Menu.EditValue;
            objBar_Dm_Menu.Ghichu = (txtGhichu.Text == "") ? null : txtGhichu.EditValue;
            objBar_Dm_Menu.Id_Nhom_Hanghoa_Ban = lookUpEdit_Nhom_Hanghoa_Ban.EditValue;

            objMasterService.Insert_Bar_Dm_Menu(objBar_Dm_Menu);
            return true;
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Bar_Dm_Menu objBar_Dm_Menu = new Ecm.WebReferences.MasterService.Bar_Dm_Menu();
            objBar_Dm_Menu.Id_Menu = gridView1.GetFocusedRowCellValue("Id_Menu");
            objBar_Dm_Menu.Ma_Menu = txtMa_Menu.EditValue;
            objBar_Dm_Menu.Ten_Menu = txtTen_Menu.EditValue;
            objBar_Dm_Menu.Id_Nhom_Hanghoa_Ban = lookUpEdit_Nhom_Hanghoa_Ban.EditValue;
            objBar_Dm_Menu.Ghichu = (txtGhichu.Text == "")? null : txtGhichu.EditValue;

            objMasterService.Update_Bar_Dm_Menu(objBar_Dm_Menu);
            return true;
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Bar_Dm_Menu objBar_Dm_Menu = new Ecm.WebReferences.MasterService.Bar_Dm_Menu();
            objBar_Dm_Menu.Id_Menu = gridView1.GetFocusedRowCellValue("Id_Menu");

            return objMasterService.Delete_Bar_Dm_Menu(objBar_Dm_Menu);
        }

        public override bool PerformAdd()
        {
            this.ClearDataBindings();
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
                hashtableControls.Add(txtMa_Menu, lblMa_Menu.Text);
                hashtableControls.Add(txtTen_Menu, lblTen_Menu.Text);

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
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Menu.Text, lblMa_Menu.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Menu"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Menu"], "");

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgbar_Dm_Menu.EmbeddedNavigator.Buttons.DoClick(dgbar_Dm_Menu.EmbeddedNavigator.Buttons.EndEdit);
                ds_Collection.Tables[0].Columns["Ma_Menu"].Unique = true;

                objMasterService.Update_Bar_Dm_Menu_Collection(this.ds_Collection);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Menu.Text, lblMa_Menu.Text });
                    return false;
                }
 

            }
            this.DisplayInfo();
            return true;
        }

        public override bool PerformDelete()
        {
            if ( GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Bar_Dm_Menu"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Bar_Dm_Menu")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Bar_Dm_Menu", "Id_Menu", this.gridView1.GetFocusedRowCellValue("Id_Menu"))) > 0)
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
            Ecm.WebReferences.MasterService.Bar_Dm_Menu bar_Dm_Menu = new Ecm.WebReferences.MasterService.Bar_Dm_Menu();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Collection.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    bar_Dm_Menu.Id_Menu     = dr["Id_Menu"];
                    bar_Dm_Menu.Ma_Menu     = dr["Ma_Menu"];
                    bar_Dm_Menu.Ten_Menu    = dr["Ten_Menu"];
                    bar_Dm_Menu.Ghichu      = dr["Ghichu"];
                }
                this.SelectedBar_Dm_Menu = bar_Dm_Menu;
                this.Dispose();
                this.Close();
                return bar_Dm_Menu;
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
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Menu"];
            this.addnewrow_clicked = true;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.dgbar_Dm_Menu.EmbeddedNavigator.Buttons.DoClick(dgbar_Dm_Menu.EmbeddedNavigator.Buttons.EndEdit);
        }

        private void dgbar_Dm_Menu_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if (MessageBox.Show("Bạn có chắc xóa menu và các món ăn trong menu này?", "Confirm Dialog", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    e.Handled = true;
                    gridView1.DeleteRow(gridView1.FocusedRowHandle);         
                }
                //if (Convert.ToInt32(objMasterService.GetExistReferences("Bar_Dm_Menu", "Id_Menu", this.gridView1.GetFocusedRowCellValue("Id_Menu"))) > 0)
                //{
                //     GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                //    e.Handled = true;
                //}
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (frmware_Dm_Nhom_Hanghoa_Ban_Add.IsDisposed || frmware_Dm_Nhom_Hanghoa_Ban_Add == null)
                frmware_Dm_Nhom_Hanghoa_Ban_Add = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Nhom_Hanghoa_Ban_Add();
             GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmware_Dm_Nhom_Hanghoa_Ban_Add);
             GoobizFrame.Windows.PlugIn.RightHelpers.CheckUserRightAction(frmware_Dm_Nhom_Hanghoa_Ban_Add);
            frmware_Dm_Nhom_Hanghoa_Ban_Add.Show();
            this.DisplayInfo();
        }
    }
}

