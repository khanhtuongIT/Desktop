using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Rex
{

    public partial class Frmrex_Dm_Loai_Nhanvien_Add :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Loai_Nhanvien = new DataSet();
        public Ecm.WebReferences.MasterService.Rex_Dm_Loai_Nhanvien Selected_Rex_Dm_Loai_Nhanvien;

        public Frmrex_Dm_Loai_Nhanvien_Add()
        {
            InitializeComponent();
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                ds_Loai_Nhanvien = objMasterService.Get_All_Rex_Dm_Loai_Nhanvien_Collection().ToDataSet();
                dgrex_Dm_Loai_Nhanvien.DataSource = ds_Loai_Nhanvien;
                dgrex_Dm_Loai_Nhanvien.DataMember = ds_Loai_Nhanvien.Tables[0].TableName;

                this.Data = ds_Loai_Nhanvien;
                this.GridControl = dgrex_Dm_Loai_Nhanvien;

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
            this.txtMa_Loai_Nhanvien.DataBindings.Clear();
            this.txtTen_Loai_Nhanvien.DataBindings.Clear();
        }

        public void DataBindingControl()
        {
            try
            {
                ClearDataBindings();

                this.txtMa_Loai_Nhanvien.DataBindings.Add("EditValue", ds_Loai_Nhanvien, ds_Loai_Nhanvien.Tables[0].TableName + ".Ma_Loai_Nhanvien");
                this.txtTen_Loai_Nhanvien.DataBindings.Add("EditValue", ds_Loai_Nhanvien, ds_Loai_Nhanvien.Tables[0].TableName + ".Ten_Loai_Nhanvien");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ChangeStatus(bool editTable)
        {
            //this.dgrex_Dm_Loai_Nhanvien.Enabled = !editTable;
            this.gridView1.OptionsBehavior.Editable = !editTable;
            this.txtMa_Loai_Nhanvien.Properties.ReadOnly = !editTable;
            this.txtTen_Loai_Nhanvien.Properties.ReadOnly = !editTable;
        }

        public void ResetText()
        {
            this.txtMa_Loai_Nhanvien.EditValue = "";
            this.txtTen_Loai_Nhanvien.EditValue = "";
        }

        #region Event Override
        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Loai_Nhanvien objRex_Dm_Loai_Nhanvien = new Ecm.WebReferences.MasterService.Rex_Dm_Loai_Nhanvien();
            objRex_Dm_Loai_Nhanvien.Id_Loai_Nhanvien = -1;
            objRex_Dm_Loai_Nhanvien.Ma_Loai_Nhanvien = txtMa_Loai_Nhanvien.EditValue;
            objRex_Dm_Loai_Nhanvien.Ten_Loai_Nhanvien = txtTen_Loai_Nhanvien.EditValue;
            return objMasterService.Insert_Rex_Dm_Loai_Nhanvien(objRex_Dm_Loai_Nhanvien);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Loai_Nhanvien objRex_Dm_Loai_Nhanvien = new Ecm.WebReferences.MasterService.Rex_Dm_Loai_Nhanvien();
            objRex_Dm_Loai_Nhanvien.Id_Loai_Nhanvien = gridView1.GetFocusedRowCellValue("Id_Loai_Nhanvien");
            objRex_Dm_Loai_Nhanvien.Ma_Loai_Nhanvien = txtMa_Loai_Nhanvien.EditValue;
            objRex_Dm_Loai_Nhanvien.Ten_Loai_Nhanvien = txtTen_Loai_Nhanvien.EditValue;
            return objMasterService.Update_Rex_Dm_Loai_Nhanvien(objRex_Dm_Loai_Nhanvien);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Loai_Nhanvien objRex_Dm_Loai_Nhanvien = new Ecm.WebReferences.MasterService.Rex_Dm_Loai_Nhanvien();
            objRex_Dm_Loai_Nhanvien.Id_Loai_Nhanvien = gridView1.GetFocusedRowCellValue("Id_Loai_Nhanvien");
            return objMasterService.Delete_Rex_Dm_Loai_Nhanvien(objRex_Dm_Loai_Nhanvien);
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
                hashtableControls.Add(txtMa_Loai_Nhanvien, lblMa_Loai_Nhanvien.Text);
                hashtableControls.Add(txtTen_Loai_Nhanvien, lblTen_Loai_Nhanvien.Text);

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                hashtableControls.Remove(txtTen_Loai_Nhanvien);
                if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Add)
                {
                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, (DataSet)dgrex_Dm_Loai_Nhanvien.DataSource, "Ma_Loai_Nhanvien" ))
                       return false;
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    DataSet ds_Loai_Nhanvien_filter =  GoobizFrame.Windows.MdiUtils.Validator.datasetFillter(ds_Loai_Nhanvien, "Id_Loai_Nhanvien = " + gridView1.GetFocusedRowCellValue("Id_Loai_Nhanvien"));
                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, ds_Loai_Nhanvien_filter, "Ma_Loai_Nhanvien"))
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
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblTen_Loai_Nhanvien.Text, lblTen_Loai_Nhanvien.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Loai_Nhanvien"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Loai_Nhanvien"], "");

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgrex_Dm_Loai_Nhanvien.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Loai_Nhanvien.EmbeddedNavigator.Buttons.EndEdit);
                ds_Loai_Nhanvien.Tables[0].Columns["Ma_Loai_Nhanvien"].Unique = true;

                objMasterService.Update_Rex_Dm_Loai_Nhanvien_Collection(this.ds_Loai_Nhanvien);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Loai_Nhanvien.Text, lblMa_Loai_Nhanvien.Text });
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
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Rex_Dm_Loai_Nhanvien"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Rex_Dm_Loai_Nhanvien")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Loai_Nhanvien", "Id_Loai_Nhanvien", this.gridView1.GetFocusedRowCellValue("Id_Loai_Nhanvien"))) > 0)
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
            Ecm.WebReferences.MasterService.Rex_Dm_Loai_Nhanvien rex_Dm_Loai_Nhanvien = new Ecm.WebReferences.MasterService.Rex_Dm_Loai_Nhanvien();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Loai_Nhanvien.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    rex_Dm_Loai_Nhanvien.Id_Loai_Nhanvien = dr["Id_Loai_Nhanvien"];
                    rex_Dm_Loai_Nhanvien.Ma_Loai_Nhanvien = dr["Ma_Loai_Nhanvien"];
                    rex_Dm_Loai_Nhanvien.Ten_Loai_Nhanvien = dr["Ten_Loai_Nhanvien"];
                }
                Selected_Rex_Dm_Loai_Nhanvien = rex_Dm_Loai_Nhanvien;
                this.Dispose();
                this.Close();
                return rex_Dm_Loai_Nhanvien;
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
            this.dgrex_Dm_Loai_Nhanvien.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Loai_Nhanvien.EmbeddedNavigator.Buttons.EndEdit);
        }

        private void dgrex_Dm_Loai_Nhanvien_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + this.gridView1.GetFocusedRowCellValue("Id_Loai_Nhanvien") != "")
                if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Loai_Nhanvien", "Id_Loai_Nhanvien", this.gridView1.GetFocusedRowCellValue("Id_Loai_Nhanvien"))) > 0)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    e.Handled = true;
                }
            }
        }

        private void gridView1_InitNewRow_1(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Loai_Nhanvien"];
            this.addnewrow_clicked = true;
        }

        private void txtMa_Loai_Nhanvien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;

        }
    }
}

