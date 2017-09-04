using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Rex
{

    public partial class Frmrex_Dm_Phuongthuc_Huongluong_Add :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Phuongthuc_Huongluong = new DataSet();
        public Ecm.WebReferences.MasterService.Rex_Dm_Phuongthuc_Huongluong Selected_Rex_Dm_Phuongthuc_Huongluong;

        public Frmrex_Dm_Phuongthuc_Huongluong_Add()
        {
            InitializeComponent();
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                ds_Phuongthuc_Huongluong = objMasterService.Get_All_Rex_Dm_Phuongthuc_Huongluong_Collection().ToDataSet();
                dgrex_Dm_Phuongthuc_Huongluong.DataSource = ds_Phuongthuc_Huongluong;
                dgrex_Dm_Phuongthuc_Huongluong.DataMember = ds_Phuongthuc_Huongluong.Tables[0].TableName;

                this.Data = ds_Phuongthuc_Huongluong;
                this.GridControl = dgrex_Dm_Phuongthuc_Huongluong;

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
            this.txtMa_Phuongthuc_Huongluong.DataBindings.Clear();
            this.txtTen_Phuongthuc_Huongluong.DataBindings.Clear();
        }

        public void DataBindingControl()
        {
            try
            {
                ClearDataBindings();

                this.txtMa_Phuongthuc_Huongluong.DataBindings.Add("EditValue", ds_Phuongthuc_Huongluong, ds_Phuongthuc_Huongluong.Tables[0].TableName + ".Ma_Phuongthuc_Huongluong");
                this.txtTen_Phuongthuc_Huongluong.DataBindings.Add("EditValue", ds_Phuongthuc_Huongluong, ds_Phuongthuc_Huongluong.Tables[0].TableName + ".Ten_Phuongthuc_Huongluong");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ChangeStatus(bool editTable)
        {
            //this.dgrex_Dm_Phuongthuc_Huongluong.Enabled = !editTable;
            this.gridView1.OptionsBehavior.Editable = !editTable;
            this.txtMa_Phuongthuc_Huongluong.Properties.ReadOnly = !editTable;
            this.txtTen_Phuongthuc_Huongluong.Properties.ReadOnly = !editTable;
        }

        public void ResetText()
        {
            this.txtMa_Phuongthuc_Huongluong.EditValue = "";
            this.txtTen_Phuongthuc_Huongluong.EditValue = "";
        }



        #region Event Override
        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Phuongthuc_Huongluong objRex_Dm_Phuongthuc_Huongluong = new Ecm.WebReferences.MasterService.Rex_Dm_Phuongthuc_Huongluong();
            objRex_Dm_Phuongthuc_Huongluong.Id_Phuongthuc_Huongluong = -1;
            objRex_Dm_Phuongthuc_Huongluong.Ma_Phuongthuc_Huongluong = txtMa_Phuongthuc_Huongluong.EditValue;
            objRex_Dm_Phuongthuc_Huongluong.Ten_Phuongthuc_Huongluong = txtTen_Phuongthuc_Huongluong.EditValue;
            return objMasterService.Insert_Rex_Dm_Phuongthuc_Huongluong(objRex_Dm_Phuongthuc_Huongluong);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Phuongthuc_Huongluong objRex_Dm_Phuongthuc_Huongluong = new Ecm.WebReferences.MasterService.Rex_Dm_Phuongthuc_Huongluong();
            objRex_Dm_Phuongthuc_Huongluong.Id_Phuongthuc_Huongluong = gridView1.GetFocusedRowCellValue("Id_Phuongthuc_Huongluong");
            objRex_Dm_Phuongthuc_Huongluong.Ma_Phuongthuc_Huongluong = txtMa_Phuongthuc_Huongluong.EditValue;
            objRex_Dm_Phuongthuc_Huongluong.Ten_Phuongthuc_Huongluong = txtTen_Phuongthuc_Huongluong.EditValue;


            return objMasterService.Update_Rex_Dm_Phuongthuc_Huongluong(objRex_Dm_Phuongthuc_Huongluong);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Phuongthuc_Huongluong objRex_Dm_Phuongthuc_Huongluong = new Ecm.WebReferences.MasterService.Rex_Dm_Phuongthuc_Huongluong();
            objRex_Dm_Phuongthuc_Huongluong.Id_Phuongthuc_Huongluong = gridView1.GetFocusedRowCellValue("Id_Phuongthuc_Huongluong");

            return objMasterService.Delete_Rex_Dm_Phuongthuc_Huongluong(objRex_Dm_Phuongthuc_Huongluong);
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
                hashtableControls.Add(txtMa_Phuongthuc_Huongluong, lblMa_Phuongthuc_Huongluong.Text);
                hashtableControls.Add(txtTen_Phuongthuc_Huongluong, lblTen_Phuongthuc_Huongluong.Text);

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Add)
                {
                    hashtableControls.Remove(txtTen_Phuongthuc_Huongluong);
                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, (DataSet)dgrex_Dm_Phuongthuc_Huongluong.DataSource, "Ma_Phuongthuc_Huongluong"))
                        return false;
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
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblTen_Phuongthuc_Huongluong.Text, lblTen_Phuongthuc_Huongluong.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Phuongthuc_Huongluong"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Phuongthuc_Huongluong"], "");
            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgrex_Dm_Phuongthuc_Huongluong.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Phuongthuc_Huongluong.EmbeddedNavigator.Buttons.EndEdit);
                ds_Phuongthuc_Huongluong.Tables[0].Columns["Ma_Phuongthuc_Huongluong"].Unique = true;

                objMasterService.Update_Rex_Dm_Phuongthuc_Huongluong_Collection(this.ds_Phuongthuc_Huongluong);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Phuongthuc_Huongluong.Text, lblMa_Phuongthuc_Huongluong.Text });
                    return false;
                }
                if (ex.ToString().IndexOf("exists") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblTen_Phuongthuc_Huongluong.Text, lblTen_Phuongthuc_Huongluong.Text });
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
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Rex_Dm_Phuongthuc_Huongluong"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Rex_Dm_Phuongthuc_Huongluong")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Phuongthuc_Huongluong", "Id_Phuongthuc_Huongluong", this.gridView1.GetFocusedRowCellValue("Id_Phuongthuc_Huongluong"))) > 0)
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
            Ecm.WebReferences.MasterService.Rex_Dm_Phuongthuc_Huongluong rex_Dm_Phuongthuc_Huongluong = new Ecm.WebReferences.MasterService.Rex_Dm_Phuongthuc_Huongluong();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Phuongthuc_Huongluong.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    rex_Dm_Phuongthuc_Huongluong.Id_Phuongthuc_Huongluong = dr["Id_Phuongthuc_Huongluong"];
                    rex_Dm_Phuongthuc_Huongluong.Ma_Phuongthuc_Huongluong = dr["Ma_Phuongthuc_Huongluong"];
                    rex_Dm_Phuongthuc_Huongluong.Ten_Phuongthuc_Huongluong = dr["Ten_Phuongthuc_Huongluong"];
                }
                Selected_Rex_Dm_Phuongthuc_Huongluong = rex_Dm_Phuongthuc_Huongluong;
                this.Dispose();
                this.Close();
                return rex_Dm_Phuongthuc_Huongluong;
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
            this.dgrex_Dm_Phuongthuc_Huongluong.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Phuongthuc_Huongluong.EmbeddedNavigator.Buttons.EndEdit);
            //string s = this.gridView1.GetFocusedRowCellValue("Ma_Phuongthuc_Huongluong").ToString();
            //MessageBox.Show(s);
        }

        private void dgrex_Dm_Phuongthuc_Huongluong_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + this.gridView1.GetFocusedRowCellValue("Id_Phuongthuc_Huongluong") != "")
                if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Phuongthuc_Huongluong", "Id_Phuongthuc_Huongluong", this.gridView1.GetFocusedRowCellValue("Id_Phuongthuc_Huongluong"))) > 0)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    e.Handled = true;
                }
            }
        }

        private void gridView1_InitNewRow_1(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Phuongthuc_Huongluong"];
            this.addnewrow_clicked = true;
        }

        private void txtMa_Phuongthuc_Huongluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;
        }

    }
}