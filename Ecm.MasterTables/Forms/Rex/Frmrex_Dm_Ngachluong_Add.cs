using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Rex
{
    public partial class Frmrex_Dm_Ngachluong_Add :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public Ecm.WebReferences.MasterService.Rex_Dm_Ngachluong Rex_Dm_Ngachluong = new Ecm.WebReferences.MasterService.Rex_Dm_Ngachluong();
        DataSet dsNgachluong = new DataSet();
        public Frmrex_Dm_Ngachluong_Add()
        {
            InitializeComponent();
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                dsNgachluong = objMasterService.Get_All_Rex_Dm_Ngachluong_Collection().ToDataSet();
                dgrex_Dm_Ngachluong.DataSource = dsNgachluong;
                dgrex_Dm_Ngachluong.DataMember = dsNgachluong.Tables[0].TableName;

                this.Data = dsNgachluong;
                this.GridControl = dgrex_Dm_Ngachluong;

                this.DataBindingControl();
                this.ChangeStatus(false);
                gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }

        }

        void ClearDataBindings()
        {
            this.txtMa_Ngachluong.DataBindings.Clear();
            this.txtTen_Ngachluong.DataBindings.Clear();
        }

        public void DataBindingControl()
        {
            try
            {
                ClearDataBindings();

                this.txtMa_Ngachluong.DataBindings.Add("EditValue", dsNgachluong, dsNgachluong.Tables[0].TableName + ".Ma_Ngachluong");
                this.txtTen_Ngachluong.DataBindings.Add("EditValue", dsNgachluong, dsNgachluong.Tables[0].TableName + ".Ten_Ngachluong");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ChangeStatus(bool editable)
        {
            //dgrex_Dm_Ngachluong.Enabled = !editable;
            this.gridView1.OptionsBehavior.Editable = !editable;
            txtMa_Ngachluong.Properties.ReadOnly = !editable;
            txtTen_Ngachluong.Properties.ReadOnly = !editable;
        }

        public void ResetText()
        {
            ClearDataBindings();
            this.txtMa_Ngachluong.EditValue = "";
            this.txtTen_Ngachluong.EditValue = "";
        }

        #region Event Override
        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Ngachluong rex_Dm_Ngachluong = new Ecm.WebReferences.MasterService.Rex_Dm_Ngachluong();
            rex_Dm_Ngachluong.Id_Ngachluong = -1;
            rex_Dm_Ngachluong.Ma_Ngachluong = this.txtMa_Ngachluong.Text;
            rex_Dm_Ngachluong.Ten_Ngachluong = this.txtTen_Ngachluong.Text;
            return objMasterService.Insert_Rex_Dm_Ngachluong(rex_Dm_Ngachluong);
        }
        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Ngachluong rex_Dm_Ngachluong = new Ecm.WebReferences.MasterService.Rex_Dm_Ngachluong();
            rex_Dm_Ngachluong.Id_Ngachluong = gridView1.GetFocusedRowCellValue("Id_Ngachluong");
            rex_Dm_Ngachluong.Ma_Ngachluong = this.txtMa_Ngachluong.Text;
            rex_Dm_Ngachluong.Ten_Ngachluong = this.txtTen_Ngachluong.Text;
            return objMasterService.Update_Rex_Dm_Ngachluong(rex_Dm_Ngachluong);
        }
        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Ngachluong rex_Dm_Ngachluong = new Ecm.WebReferences.MasterService.Rex_Dm_Ngachluong();
            rex_Dm_Ngachluong.Id_Ngachluong = gridView1.GetFocusedRowCellValue("Id_Ngachluong");
            return objMasterService.Delete_Rex_Dm_Ngachluong(rex_Dm_Ngachluong);
        }
        public override bool PerformAdd()
        {
            ResetText();
            this.ChangeStatus(true);
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
                bool saved = false;
                 GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(txtMa_Ngachluong, lblMa_Ngachluong.Text);
                hashtableControls.Add(txtTen_Ngachluong, lblTen_Ngachluong.Text);

                System.Collections.Hashtable htb_Ma = new System.Collections.Hashtable();
                System.Collections.Hashtable htb_Ten = new System.Collections.Hashtable();
                htb_Ma.Add(txtMa_Ngachluong, lblMa_Ngachluong.Text);
                htb_Ten.Add(txtTen_Ngachluong, lblTen_Ngachluong.Text);

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Add)
                {
                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htb_Ma, (DataSet)dgrex_Dm_Ngachluong.DataSource, "Ma_Ngachluong"))
                        return false;
                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htb_Ten, (DataSet)dgrex_Dm_Ngachluong.DataSource, "Ten_Ngachluong"))
                        return false;
                    this.InsertObject();
                    saved = true;
                }
                else if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    txtId_Ngachluong.Visible = true;
                    DataSet _ds =  GoobizFrame.Windows.MdiUtils.Validator.datasetFillter((DataSet)dgrex_Dm_Ngachluong.DataSource, "Id_Ngachluong = " + txtId_Ngachluong.Text);
                    txtId_Ngachluong.Visible = false;
                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htb_Ma, _ds, "Ma_Ngachluong"))
                        return false;
                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htb_Ten, _ds, "Ten_Ngachluong"))
                        return false;
                    this.UpdateObject();
                    saved = true;
                }
                if (saved)
                {
                    this.DisplayInfo();
                }
                return saved;
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("exists") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblTen_Ngachluong.Text, lblTen_Ngachluong.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Ngachluong"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Ngachluong"], "");
            if (!  GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgrex_Dm_Ngachluong.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Ngachluong.EmbeddedNavigator.Buttons.EndEdit);
                dsNgachluong.Tables[0].Columns["Ma_Ngachluong"].Unique = true;

                objMasterService.Update_Rex_Dm_Ngachluong_Collection(dsNgachluong);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Ngachluong.Text, lblMa_Ngachluong.Text });
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
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Rex_Dm_Ngachluong"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Rex_Dm_Ngachluong")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Ngachluong", "Id_Ngachluong", this.gridView1.GetFocusedRowCellValue("Id_Ngachluong"))) > 0)
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
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = dsNgachluong.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    Rex_Dm_Ngachluong = new Ecm.WebReferences.MasterService.Rex_Dm_Ngachluong();
                    Rex_Dm_Ngachluong.Id_Ngachluong     = dr["Id_Ngachluong"];
                    Rex_Dm_Ngachluong.Ma_Ngachluong     = dr["Ma_Ngachluong"];
                    Rex_Dm_Ngachluong.Ten_Ngachluong    = dr["Ten_Ngachluong"];
                }
                this.Dispose();
                return Rex_Dm_Ngachluong;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#endif
                return null;
            }
        }
        #endregion

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //dgrex_Dm_Ngachluong.EmbeddedNavigator.Buttons.EndEdit.DoClick();
            this.DoClickEndEdit(dgrex_Dm_Ngachluong);
        }
      
        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView1.FocusedColumn = gridView1.Columns[1];
            this.addnewrow_clicked = true;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtId_Ngachluong.EditValue = gridView1.GetFocusedRowCellValue(gridView1.Columns["Id_Ngachluong"]);
        }

        private void dgrex_Dm_Ngachluong_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + this.gridView1.GetFocusedRowCellValue("Id_Ngachluong") != "")
                if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Ngachluong", "Id_Ngachluong", this.gridView1.GetFocusedRowCellValue("Id_Ngachluong"))) > 0)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    e.Handled = true;
                }
            }
        }

        private void txtMa_Ngachluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;
        }
    }
}

