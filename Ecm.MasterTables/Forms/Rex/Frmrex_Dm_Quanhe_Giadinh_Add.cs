using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Rex
{

    public partial class Frmrex_Dm_Quanhe_Giadinh_Add :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Quanhe_Giadinh = new DataSet();
        public Ecm.WebReferences.MasterService.Rex_Dm_Quanhe_Giadinh Selected_Rex_Dm_Quanhe_Giadinh;

        public Frmrex_Dm_Quanhe_Giadinh_Add()
        {
            InitializeComponent();
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                ds_Quanhe_Giadinh = objMasterService.Get_All_Rex_Dm_Quanhe_Giadinh_Collection().ToDataSet();
                dgrex_Dm_Quanhe_Giadinh.DataSource = ds_Quanhe_Giadinh;
                dgrex_Dm_Quanhe_Giadinh.DataMember = ds_Quanhe_Giadinh.Tables[0].TableName;

                this.Data = ds_Quanhe_Giadinh;
                this.GridControl = dgrex_Dm_Quanhe_Giadinh;

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
            this.txtMa_Quanhe_Giadinh.DataBindings.Clear();
            this.txtTen_Quanhe_Giadinh.DataBindings.Clear();
        }

        public void DataBindingControl()
        {
            try
            {
                ClearDataBindings();

                this.txtMa_Quanhe_Giadinh.DataBindings.Add("EditValue", ds_Quanhe_Giadinh, ds_Quanhe_Giadinh.Tables[0].TableName + ".Ma_Quanhe_Giadinh");
                this.txtTen_Quanhe_Giadinh.DataBindings.Add("EditValue", ds_Quanhe_Giadinh, ds_Quanhe_Giadinh.Tables[0].TableName + ".Ten_Quanhe_Giadinh");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ChangeStatus(bool editTable)
        {
            //this.dgrex_Dm_Quanhe_Giadinh.Enabled = !editTable;
            this.gridView1.OptionsBehavior.Editable = !editTable;
            this.txtMa_Quanhe_Giadinh.Properties.ReadOnly = !editTable;
            this.txtTen_Quanhe_Giadinh.Properties.ReadOnly = !editTable;
        }

        public override void  ResetText()
        {
            this.txtMa_Quanhe_Giadinh.EditValue = "";
            this.txtTen_Quanhe_Giadinh.EditValue = "";
        }



        #region Event Override
        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Quanhe_Giadinh objRex_Dm_Quanhe_Giadinh = new Ecm.WebReferences.MasterService.Rex_Dm_Quanhe_Giadinh();
            objRex_Dm_Quanhe_Giadinh.Id_Quanhe_Giadinh = -1;
            objRex_Dm_Quanhe_Giadinh.Ma_Quanhe_Giadinh = txtMa_Quanhe_Giadinh.EditValue;
            objRex_Dm_Quanhe_Giadinh.Ten_Quanhe_Giadinh = txtTen_Quanhe_Giadinh.EditValue;

            return objMasterService.Insert_Rex_Dm_Quanhe_Giadinh(objRex_Dm_Quanhe_Giadinh);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Quanhe_Giadinh objRex_Dm_Quanhe_Giadinh = new Ecm.WebReferences.MasterService.Rex_Dm_Quanhe_Giadinh();
            objRex_Dm_Quanhe_Giadinh.Id_Quanhe_Giadinh = gridView1.GetFocusedRowCellValue("Id_Quanhe_Giadinh");
            objRex_Dm_Quanhe_Giadinh.Ma_Quanhe_Giadinh = txtMa_Quanhe_Giadinh.EditValue;
            objRex_Dm_Quanhe_Giadinh.Ten_Quanhe_Giadinh = txtTen_Quanhe_Giadinh.EditValue;


            return objMasterService.Update_Rex_Dm_Quanhe_Giadinh(objRex_Dm_Quanhe_Giadinh);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Quanhe_Giadinh objRex_Dm_Quanhe_Giadinh = new Ecm.WebReferences.MasterService.Rex_Dm_Quanhe_Giadinh();
            objRex_Dm_Quanhe_Giadinh.Id_Quanhe_Giadinh = gridView1.GetFocusedRowCellValue("Id_Quanhe_Giadinh");

            return objMasterService.Delete_Rex_Dm_Quanhe_Giadinh(objRex_Dm_Quanhe_Giadinh);
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
                hashtableControls.Add(txtMa_Quanhe_Giadinh, lblMa_Quanhe_Giadinh.Text);
                hashtableControls.Add(txtTen_Quanhe_Giadinh, lblTen_Quanhe_Giadinh.Text);

                //hashtableControls.Remove(txtTen_Quanhe_Giadinh);
                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                hashtableControls.Remove(txtTen_Quanhe_Giadinh);
                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, (DataSet)dgrex_Dm_Quanhe_Giadinh.DataSource, "Ma_Quanhe_Giadinh"))
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
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblTen_Quanhe_Giadinh.Text, lblTen_Quanhe_Giadinh.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Quanhe_Giadinh"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Quanhe_Giadinh"], "");
            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            hashtableControls.Remove(gridView1.Columns["Ten_Quanhe_Giadinh"]);
            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgrex_Dm_Quanhe_Giadinh.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Quanhe_Giadinh.EmbeddedNavigator.Buttons.EndEdit);
                ds_Quanhe_Giadinh.Tables[0].Columns["Ma_Quanhe_Giadinh"].Unique = true;

                objMasterService.Update_Rex_Dm_Quanhe_Giadinh_Collection(this.ds_Quanhe_Giadinh);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Quanhe_Giadinh.Text, lblMa_Quanhe_Giadinh.Text });
                    return false;
                }
                if (ex.ToString().IndexOf("exists") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblTen_Quanhe_Giadinh.Text, lblTen_Quanhe_Giadinh.Text });
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
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Rex_Dm_Quanhe_Giadinh"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Rex_Dm_Quanhe_Giadinh")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Quanhe_Giadinh", "Id_Quanhe_Giadinh", this.gridView1.GetFocusedRowCellValue("Id_Quanhe_Giadinh"))) > 0)
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
            Ecm.WebReferences.MasterService.Rex_Dm_Quanhe_Giadinh rex_Dm_Quanhe_Giadinh = new Ecm.WebReferences.MasterService.Rex_Dm_Quanhe_Giadinh();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Quanhe_Giadinh.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    rex_Dm_Quanhe_Giadinh.Id_Quanhe_Giadinh = dr["Id_Quanhe_Giadinh"];
                    rex_Dm_Quanhe_Giadinh.Ma_Quanhe_Giadinh = dr["Ma_Quanhe_Giadinh"];
                    rex_Dm_Quanhe_Giadinh.Ten_Quanhe_Giadinh = dr["Ten_Quanhe_Giadinh"];
                }
                Selected_Rex_Dm_Quanhe_Giadinh = rex_Dm_Quanhe_Giadinh;
                this.Dispose();
                this.Close();
                return rex_Dm_Quanhe_Giadinh;
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
            this.dgrex_Dm_Quanhe_Giadinh.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Quanhe_Giadinh.EmbeddedNavigator.Buttons.EndEdit);
            //string s = this.gridView1.GetFocusedRowCellValue("Ma_Quanhe_Giadinh").ToString();
            //MessageBox.Show(s);
        }

        private void dgrex_Dm_Quanhe_Giadinh_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + this.gridView1.GetFocusedRowCellValue("Id_Quanhe_Giadinh") != "")
                if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Quanhe_Giadinh", "Id_Quanhe_Giadinh", this.gridView1.GetFocusedRowCellValue("Id_Quanhe_Giadinh"))) > 0)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    e.Handled = true;
                }
            }
        }

        private void gridView1_InitNewRow_1(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.addnewrow_clicked = true;
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Quanhe_Giadinh"];   
        }

        private void txtMa_Quanhe_Giadinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;
        }

    }
}