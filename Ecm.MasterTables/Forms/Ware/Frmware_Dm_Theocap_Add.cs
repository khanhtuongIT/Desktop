using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ecm.MasterTables.Forms.Ware
{
    public partial class Frmware_Dm_Theocap_Add : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objmasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Collection = new DataSet();
        object ten_cap = null;

        public Frmware_Dm_Theocap_Add()
        {
            InitializeComponent();
            this.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void Frmware_Dm_Theocap_Add_Load(object sender, EventArgs e)
        {
            DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                ds_Collection = objmasterService.Ware_Dm_Cap_SelectAll().ToDataSet();
                dgware_Dm_Donvitinh_Theocap.DataSource = ds_Collection;
                dgware_Dm_Donvitinh_Theocap.DataMember = ds_Collection.Tables[0].TableName;
                this.Data = ds_Collection;

                this.GridControl = dgware_Dm_Donvitinh_Theocap;
                this.DataBindingControl();

                this.ChangeStatus(false);
                dgware_Dm_Donvitinh_Theocap.Enabled = true;
                this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);


            }
        }


        public override void ChangeStatus(bool editTable)
        {
            this.gridView1.OptionsBehavior.Editable = !editTable;
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



        public object InsertObject()
        {
            // Ecm.WebReferences.MasterService.Ware_Dm_Cap objWare_Dm_cap = new Ecm.WebReferences.MasterService.Ware_Dm_Cap();
            // objWare_Dm_cap.Id_Cap = txtMa_cap.EditValue;
            // objWare_Dm_cap.Giatri= txtTen_cap.EditValue;
            //return objMasterService.Update_Ware_Dm_Cap_Collection(objWare_Dm_cap);
            return null;
        }

        public object UpdateObject()
        {
            //Ecm.WebReferences.MasterService.Ware_Dm_Cap_SelectAll objWare_Dm_cap = new Ecm.WebReferences.MasterService.Ware_Dm_Cap_SelectAll();
            // objWare_Dm_cap.Id_Cap = txtMa_cap.EditValue;
            // objWare_Dm_cap.Giatri = txtTen_cap.EditValue;
            //return objMasterService.Update_Ware_Dm_Cap_Collection(objWare_Dm_cap);
            return null;
        }

        public object DeleteObject()
        {
            //Ecm.WebReferences.MasterService.Ware_Dm_Cap_SelectAll objWare_Dm_cap = new Ecm.WebReferences.MasterService.Ware_Dm_Cap_SelectAll();
            // objWare_Dm_cap.Id_Cap=gridView1.GetFocusedRowCellValue("Id_Cap");
            //return objMasterService.Update_Ware_Dm_Cap_Collection(objWare_Dm_cap);             
            return null;
        }




        public override bool PerformSave()
        {
            dgware_Dm_Donvitinh_Theocap.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Donvitinh_Theocap.EmbeddedNavigator.Buttons.EndEdit);

            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Id_Cap"], "");
            hashtableControls.Add(gridView1.Columns["Giatri"], "");

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistGrid(hashtableControls, gridView1))
                return false;

            try
            {
                ds_Collection.Tables[0].Columns["Id_Cap"].Unique = true;
                objmasterService.Update_Ware_Dm_Cap_Collection(this.ds_Collection);
            }
            catch (Exception ex)
            {
                ex.ToString();
                //MessageBox.Show(ex.ToString());
            }
            this.DisplayInfo();
            return true;
        }

        public override bool PerformSaveChanges()
        {
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Giatri"], "");


            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgware_Dm_Donvitinh_Theocap.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Donvitinh_Theocap.EmbeddedNavigator.Buttons.EndEdit);
                objmasterService.Update_Ware_Dm_Cap_Collection(this.ds_Collection);

            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { gridColumn3.Caption, gridColumn3.Caption.ToLower() });
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
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Dm_Cap_SelectAll"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Dm_Cap_SelectAll")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objmasterService.GetExistReferences("Ware_Dm_Cap_SelectAll", "Id_Cap", this.gridView1.GetFocusedRowCellValue("Id_Cap"))) > 0)
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
            return true;
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Id_Cap"];
            this.addnewrow_clicked = true;
            gridView1.OptionsBehavior.Editable = true;
            this.ChangeFormState(GoobizFrame.Windows.Forms.FormState.Add);
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.dgware_Dm_Donvitinh_Theocap.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Donvitinh_Theocap.EmbeddedNavigator.Buttons.EndEdit);
        }

        private void dgware_Dm_Donvitinh_Theocap_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if (Convert.ToInt32(objmasterService.GetExistReferences("Ware_Dm_Cap_SelectAll", "Id_Cap", this.gridView1.GetFocusedRowCellValue("Id_Cap"))) > 0)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    e.Handled = true;
                }
            }

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ten_cap = gridView1.GetFocusedRowCellValue("Giatri");
        }

        private void txtMa_cap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(29))
            {
                e.Handled = true;
            }
        }


    }
}