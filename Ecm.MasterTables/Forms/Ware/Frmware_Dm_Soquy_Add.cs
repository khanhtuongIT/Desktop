using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Ware
{
    public partial class Frmware_Dm_Soquy_Add :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Collection = new DataSet();
        //public Ecm.WebReferences.MasterService.Ware_Dm_Cuahang_Ban ware_Dm_Cuahang_Ban ;

        public Frmware_Dm_Soquy_Add()
        {
            InitializeComponent();
            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                gridLookupEdit_Kho.DataSource = objMasterService.Ware_Dm_Cuahang_Ban_Select_Kho().ToDataSet().Tables[0];
                ds_Collection = objMasterService.GetAll_Ware_Dm_Soquy(null).ToDataSet();
                dgware_Dm_Soquy.DataSource = ds_Collection;
                dgware_Dm_Soquy.DataMember = ds_Collection.Tables[0].TableName;

                this.Data = ds_Collection;
                this.GridControl = dgware_Dm_Soquy;
                this.DataBindingControl();

                this.ChangeStatus(false);
                this.gvDm_Soquy.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void  ChangeStatus(bool editTable)
        {           
            this.gvDm_Soquy.OptionsBehavior.Editable = !editTable;
        }

        #region Event Override

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
           return PerformSaveChanges();
        }

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gvDm_Soquy.Columns["Ma_Soquy"], "");
            hashtableControls.Add(gvDm_Soquy.Columns["Ten_Soquy"], "");

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gvDm_Soquy))
                return false;

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistGrid(hashtableControls, gvDm_Soquy))
                return false;

            try
            {
                dgware_Dm_Soquy.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Soquy.EmbeddedNavigator.Buttons.EndEdit);
                this.ds_Collection.Tables[0].Columns["Ma_Soquy"].Unique = true;
                objMasterService.Update_Ware_Dm_Soquy_Collection(this.ds_Collection);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { gridColumn3.Caption});
                    return false;
                }
                //MessageBox.Show(ex.ToString());
            }
            this.DisplayInfo();
            return true;
        }

        public override object PerformSelectOneObject()
        {            
//            try
//            {
//                ware_Dm_Cuahang_Ban = new Ecm.WebReferences.MasterService.Ware_Dm_Cuahang_Ban();
//                int focusedRow = gvDm_Soquy.GetDataSourceRowIndex(gvDm_Soquy.FocusedRowHandle);
//                DataRow dr = ds_Collection.Tables[0].Rows[focusedRow];
//                if (dr != null)
//                {
//                    ware_Dm_Cuahang_Ban.Id_Cuahang_Ban = dr["Id_Cuahang_Ban"];
//                    ware_Dm_Cuahang_Ban.Ma_Cuahang_Ban = dr["Ma_Cuahang_Ban"];
//                    ware_Dm_Cuahang_Ban.Ten_Cuahang_Ban = dr["Ten_Cuahang_Ban"];
//                }
//                this.Dispose();
//                this.Close();
//                return ware_Dm_Cuahang_Ban;
//            }
//            catch (Exception ex)
//            {
//#if DEBUG
//                MessageBox.Show(ex.Message);
//#endif
                return null;
            //}
        }
       
        #endregion

        #region events

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gvDm_Soquy.FocusedColumn = gvDm_Soquy.Columns["Ma_Soquy"];
            this.addnewrow_clicked = true;
            this.gvDm_Soquy.OptionsBehavior.Editable = true;
            this.ChangeFormState( GoobizFrame.Windows.Forms.FormState.Add);
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.dgware_Dm_Soquy.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Soquy.EmbeddedNavigator.Buttons.EndEdit);
        }

        private void dgware_Dm_Cuahang_Ban_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            //if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            //{
            //    if ("" + this.gvDm_Soquy.GetFocusedRowCellValue("Id_Cuahang_Ban") != "")
            //        if (Convert.ToInt32(objMasterService.GetExistReferences("Ware_Dm_Cuahang_Ban", "Id_Cuahang_Ban", this.gvDm_Soquy.GetFocusedRowCellValue("Id_Cuahang_Ban"))) > 0)
            //        {
            //             GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
            //            e.Handled = true;
            //        }
            //}
        }

        #endregion
        
    }
}

