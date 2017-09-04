using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Rex
{
    public partial class Frmrex_Dm_Khenthuong_Kyluat_Add :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        //Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Khenthuong_Kyluat = new DataSet();
        public Ecm.WebReferences.MasterService.Rex_Dm_Khenthuong_Kyluat Selected_Rex_Dm_Khenthuong_Kyluat;
        public Frmrex_Dm_Khenthuong_Kyluat_Add()
        {
            InitializeComponent();
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                DataSet ds_Loai_Ktkl = new DataSet();
                ds_Loai_Ktkl = objMasterService.Get_All_Rex_Dm_Loai_Ktkl_Collection().ToDataSet();
                lookUp_Loai_Ktkl.Properties.DataSource = ds_Loai_Ktkl.Tables[0];
                gridLookUp_Loai_Ktkl.DataSource = ds_Loai_Ktkl.Tables[0];

                //LookupEdit_Loai_Ktkl.Properties.data = ds_Loai_Ktkl.Tables[0].TableName;


                ds_Khenthuong_Kyluat = objMasterService.Get_All_Rex_Dm_Khenthuong_Kyluat_Collection().ToDataSet();
                dgrex_Dm_Khenthuong_Kyluat.DataSource = ds_Khenthuong_Kyluat;
                dgrex_Dm_Khenthuong_Kyluat.DataMember = ds_Khenthuong_Kyluat.Tables[0].TableName;

                this.Data = ds_Khenthuong_Kyluat;
                this.GridControl = dgrex_Dm_Khenthuong_Kyluat;

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
            this.lookUp_Loai_Ktkl.DataBindings.Clear();
            this.txtMa_Khenthuong_Kyluat.DataBindings.Clear();
            this.txtTen_Khenthuong_Kyluat.DataBindings.Clear();
        }

        public void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.lookUp_Loai_Ktkl.DataBindings.Add("EditValue", ds_Khenthuong_Kyluat, ds_Khenthuong_Kyluat.Tables[0].TableName + ".Id_Loai_Ktkl");
                this.txtMa_Khenthuong_Kyluat.DataBindings.Add("EditValue", ds_Khenthuong_Kyluat, ds_Khenthuong_Kyluat.Tables[0].TableName + ".Ma_Khenthuong_Kyluat");
                this.txtTen_Khenthuong_Kyluat.DataBindings.Add("EditValue", ds_Khenthuong_Kyluat, ds_Khenthuong_Kyluat.Tables[0].TableName + ".Ten_Khenthuong_Kyluat");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ChangeStatus(bool editTable)
        {
            //this.dgrex_Dm_Khenthuong_Kyluat.Enabled = !editTable;
            this.gridView1.OptionsBehavior.Editable = !editTable;
            this.txtMa_Khenthuong_Kyluat.Properties.ReadOnly = !editTable;
            this.txtTen_Khenthuong_Kyluat.Properties.ReadOnly = !editTable;
            this.lookUp_Loai_Ktkl.Properties.ReadOnly = !editTable;
        }

        public void ResetText()
        {
            this.lookUp_Loai_Ktkl.EditValue = "";
            this.txtMa_Khenthuong_Kyluat.EditValue = "";
            this.txtTen_Khenthuong_Kyluat.EditValue = "";
        }

        private void Frmrex_Dm_Khenthuong_Kyluat_Add_Load(object sender, EventArgs e)
        {
            //this.DisplayInfo();
        }

        #region Event Override
        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Khenthuong_Kyluat objRex_Dm_Khenthuong_Kyluat = new Ecm.WebReferences.MasterService.Rex_Dm_Khenthuong_Kyluat();
            objRex_Dm_Khenthuong_Kyluat.Id_Khenthuong_Kyluat = -1;
            objRex_Dm_Khenthuong_Kyluat.Ma_Khenthuong_Kyluat = txtMa_Khenthuong_Kyluat.EditValue;
            objRex_Dm_Khenthuong_Kyluat.Ten_Khenthuong_Kyluat = txtTen_Khenthuong_Kyluat.EditValue;
            objRex_Dm_Khenthuong_Kyluat.Id_Loai_Ktkl = lookUp_Loai_Ktkl.EditValue;

            return objMasterService.Insert_Rex_Dm_Khenthuong_Kyluat(objRex_Dm_Khenthuong_Kyluat);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Khenthuong_Kyluat objRex_Dm_Khenthuong_Kyluat = new Ecm.WebReferences.MasterService.Rex_Dm_Khenthuong_Kyluat();
            objRex_Dm_Khenthuong_Kyluat.Id_Khenthuong_Kyluat = gridView1.GetFocusedRowCellValue("Id_Khenthuong_Kyluat");
            objRex_Dm_Khenthuong_Kyluat.Ma_Khenthuong_Kyluat = txtMa_Khenthuong_Kyluat.EditValue;
            objRex_Dm_Khenthuong_Kyluat.Ten_Khenthuong_Kyluat = txtTen_Khenthuong_Kyluat.EditValue;
            objRex_Dm_Khenthuong_Kyluat.Id_Loai_Ktkl = lookUp_Loai_Ktkl.EditValue;

            return objMasterService.Update_Rex_Dm_Khenthuong_Kyluat(objRex_Dm_Khenthuong_Kyluat);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Khenthuong_Kyluat objRex_Dm_Khenthuong_Kyluat = new Ecm.WebReferences.MasterService.Rex_Dm_Khenthuong_Kyluat();
            objRex_Dm_Khenthuong_Kyluat.Id_Khenthuong_Kyluat = gridView1.GetFocusedRowCellValue("Id_Khenthuong_Kyluat");

            return objMasterService.Delete_Rex_Dm_Khenthuong_Kyluat(objRex_Dm_Khenthuong_Kyluat);
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
                hashtableControls.Add(txtMa_Khenthuong_Kyluat, lblMa_Khenthuong_Kyluat.Text);
                hashtableControls.Add(txtTen_Khenthuong_Kyluat, lblTen_Khenthuong_Kyluat.Text);
                hashtableControls.Add(lookUp_Loai_Ktkl, lblId_Loai_Ktkl.Text);


                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                hashtableControls.Remove(txtTen_Khenthuong_Kyluat);
                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, (DataSet)dgrex_Dm_Khenthuong_Kyluat.DataSource, "Ma_Khenthuong_Kyluat"))
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
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblTen_Khenthuong_Kyluat.Text, lblTen_Khenthuong_Kyluat.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Khenthuong_Kyluat"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Khenthuong_Kyluat"], "");
            hashtableControls.Add(gridView1.Columns["Id_Loai_Ktkl"], "");

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            //hashtableControls.Remove(gridView1.Columns["Ten_Khenthuong_Kyluat"]);
            //hashtableControls.Remove(txtTen_Khenthuong_Kyluat);
            //if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, (DataSet)dgrex_Dm_Khenthuong_Kyluat.DataSource, "Ma_Khenthuong_Kyluat"))
            //return false;

            try
            {
                dgrex_Dm_Khenthuong_Kyluat.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Khenthuong_Kyluat.EmbeddedNavigator.Buttons.EndEdit);
                ds_Khenthuong_Kyluat.Tables[0].Columns["Ma_Khenthuong_Kyluat"].Unique = true;
                objMasterService.Update_Rex_Dm_Khenthuong_Kyluat_Collection(this.ds_Khenthuong_Kyluat);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Khenthuong_Kyluat.Text, lblMa_Khenthuong_Kyluat.Text });
                    return false;
                }

                if (ex.ToString().IndexOf("exists") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblTen_Khenthuong_Kyluat.Text, lblTen_Khenthuong_Kyluat.Text });
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
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Rex_Dm_Khenthuong_Kyluat"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Rex_Dm_Khenthuong_Kyluat")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Khenthuong_Kyluat", "Id_Khenthuong_Kyluat", this.gridView1.GetFocusedRowCellValue("Id_Khenthuong_Kyluat"))) > 0)
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
            Ecm.WebReferences.MasterService.Rex_Dm_Khenthuong_Kyluat rex_Dm_Khenthuong_Kyluat = new Ecm.WebReferences.MasterService.Rex_Dm_Khenthuong_Kyluat();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Khenthuong_Kyluat.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    rex_Dm_Khenthuong_Kyluat.Id_Khenthuong_Kyluat = dr["Id_Khenthuong_Kyluat"];
                    rex_Dm_Khenthuong_Kyluat.Ma_Khenthuong_Kyluat = dr["Ma_Khenthuong_Kyluat"];
                    rex_Dm_Khenthuong_Kyluat.Ten_Khenthuong_Kyluat = dr["Ten_Khenthuong_Kyluat"];
                    rex_Dm_Khenthuong_Kyluat.Id_Loai_Ktkl = dr["Id_Loai_Ktkl"];
                }
                Selected_Rex_Dm_Khenthuong_Kyluat = rex_Dm_Khenthuong_Kyluat;
                this.Dispose();
                this.Close();
                return rex_Dm_Khenthuong_Kyluat;
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
            this.dgrex_Dm_Khenthuong_Kyluat.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Khenthuong_Kyluat.EmbeddedNavigator.Buttons.EndEdit);
        }

        private void dgrex_Dm_Khenthuong_Kyluat_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Khenthuong_Kyluat", "Id_Khenthuong_Kyluat", this.gridView1.GetFocusedRowCellValue("Id_Khenthuong_Kyluat"))) > 0)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    e.Handled = true;
                }
            }
        }

        private void gridView1_InitNewRow(object sender, EventArgs e)
        {
            //this.gridView1.FocusedColumn = gridView1.Columns["Ma_Khenthuong_Kyluat"];
            //this.addnewrow_clicked = true;
        }

        private void dgrex_Dm_Khenthuong_Kyluat_EmbeddedNavigator_ButtonClick_1(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + this.gridView1.GetFocusedRowCellValue("Id_Khenthuong_Kyluat") != "")
                if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Khenthuong_Kyluat", "Id_Khenthuong_Kyluat", this.gridView1.GetFocusedRowCellValue("Id_Khenthuong_Kyluat"))) > 0)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    e.Handled = true;
                }
            }
        }

        private void txtMa_Khenthuong_Kyluat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;
        }
    }


}
