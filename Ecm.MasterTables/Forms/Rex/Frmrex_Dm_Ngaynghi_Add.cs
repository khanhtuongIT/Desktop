using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Rex
{
    public partial class Frmrex_Dm_Ngaynghi_Add :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Ngaynghi = new DataSet();
        public Ecm.WebReferences.MasterService.Rex_Dm_Ngaynghi Selected_Rex_Dm_Ngaynghi;

        public Frmrex_Dm_Ngaynghi_Add()
        {
            InitializeComponent();
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                ds_Ngaynghi = objMasterService.Get_All_Rex_Dm_Ngaynghi_Collection().ToDataSet();
                dgrex_Dm_Ngaynghi.DataSource = ds_Ngaynghi;
                dgrex_Dm_Ngaynghi.DataMember = ds_Ngaynghi.Tables[0].TableName;

                this.Data = ds_Ngaynghi;
                this.GridControl = dgrex_Dm_Ngaynghi;

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
            this.txtMa_Ngaynghi.DataBindings.Clear();
            this.txtTen_Ngaynghi.DataBindings.Clear();
            this.dateEdit1.DataBindings.Clear();
        }

        public void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtMa_Ngaynghi.DataBindings.Add("EditValue", ds_Ngaynghi, ds_Ngaynghi.Tables[0].TableName + ".Ma_Ngaynghi");
                this.txtTen_Ngaynghi.DataBindings.Add("EditValue", ds_Ngaynghi, ds_Ngaynghi.Tables[0].TableName + ".Ten_Ngaynghi");
                this.dateEdit1.DataBindings.Add("EditValue", ds_Ngaynghi, ds_Ngaynghi.Tables[0].TableName + ".Ngaynghi");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ChangeStatus(bool editTable)
        {
            //this.dgrex_Dm_Ngaynghi.Enabled = !editTable;
            this.gridView1.OptionsBehavior.Editable = !editTable;
            this.txtMa_Ngaynghi.Properties.ReadOnly = !editTable;
            this.txtTen_Ngaynghi.Properties.ReadOnly = !editTable;
            this.dateEdit1.Properties.ReadOnly = !editTable;
        }

        public void ResetText()
        {
            this.txtMa_Ngaynghi.EditValue = "";
            this.txtTen_Ngaynghi.EditValue = "";
            this.dateEdit1.EditValue = DateTime.Now;
        }

        private void Frmrex_Dm_Ngaynghi_Add_Load(object sender, EventArgs e)
        {
            this.DisplayInfo();
        }

        #region Event Override
        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Ngaynghi objRex_Dm_Ngaynghi = new Ecm.WebReferences.MasterService.Rex_Dm_Ngaynghi();

            objRex_Dm_Ngaynghi.Id_Ngaynghi = -1;
            objRex_Dm_Ngaynghi.Ma_Ngaynghi = txtMa_Ngaynghi.EditValue;
            objRex_Dm_Ngaynghi.Ten_Ngaynghi = txtTen_Ngaynghi.EditValue;
            objRex_Dm_Ngaynghi.Ngaynghi = dateEdit1.EditValue;

            return objMasterService.Insert_Rex_Dm_Ngaynghi(objRex_Dm_Ngaynghi);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Ngaynghi objRex_Dm_Ngaynghi = new Ecm.WebReferences.MasterService.Rex_Dm_Ngaynghi();
            objRex_Dm_Ngaynghi.Id_Ngaynghi = gridView1.GetFocusedRowCellValue("Id_Ngaynghi");
            objRex_Dm_Ngaynghi.Ma_Ngaynghi = txtMa_Ngaynghi.EditValue;
            objRex_Dm_Ngaynghi.Ten_Ngaynghi = txtTen_Ngaynghi.EditValue;
            objRex_Dm_Ngaynghi.Ngaynghi = dateEdit1.EditValue;

            return objMasterService.Update_Rex_Dm_Ngaynghi(objRex_Dm_Ngaynghi);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Ngaynghi objRex_Dm_Ngaynghi = new Ecm.WebReferences.MasterService.Rex_Dm_Ngaynghi();
            objRex_Dm_Ngaynghi.Id_Ngaynghi = gridView1.GetFocusedRowCellValue("Id_Ngaynghi");

            return objMasterService.Delete_Rex_Dm_Ngaynghi(objRex_Dm_Ngaynghi);
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
                hashtableControls.Add(txtMa_Ngaynghi, lblMa_Ngaynghi.Text);
                hashtableControls.Add(txtTen_Ngaynghi, lblTen_Ngaynghi.Text);
                hashtableControls.Add(dateEdit1, lblNgay.Text);

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;
                System.Collections.Hashtable htb = new System.Collections.Hashtable();
                htb.Add(txtMa_Ngaynghi, lblMa_Ngaynghi.Text);

                if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Add)
                {
                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htb, (DataSet)dgrex_Dm_Ngaynghi.DataSource, "Ma_Ngaynghi"))
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
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblTen_Ngaynghi.Text, lblTen_Ngaynghi.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Ngaynghi"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Ngaynghi"], "");
            hashtableControls.Add(gridView1.Columns["Ngaynghi"], "");

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgrex_Dm_Ngaynghi.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Ngaynghi.EmbeddedNavigator.Buttons.EndEdit);
                ds_Ngaynghi.Tables[0].Columns["Ma_Ngaynghi"].Unique = true;
                objMasterService.Update_Rex_Dm_Ngaynghi_Collection(this.ds_Ngaynghi);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Ngaynghi.Text, lblMa_Ngaynghi.Text });
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
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Rex_Dm_Ngaynghi"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Rex_Dm_Ngaynghi")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Ngaynghi", "Id_Ngaynghi", this.gridView1.GetFocusedRowCellValue("Id_Ngaynghi"))) > 0)
                    {
                         GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                        return true;
                    }
                    this.DeleteObject();
                }
                catch (Exception ex)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                }
                this.DisplayInfo();
            }
            return base.PerformDelete();
        }

        public override object PerformSelectOneObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Ngaynghi rex_Dm_Ngaynghi = new Ecm.WebReferences.MasterService.Rex_Dm_Ngaynghi();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Ngaynghi.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    rex_Dm_Ngaynghi.Id_Ngaynghi = dr["Id_Ngaynghi"];
                    rex_Dm_Ngaynghi.Ma_Ngaynghi = dr["Ma_Ngaynghi"];
                    rex_Dm_Ngaynghi.Ten_Ngaynghi = dr["Ten_Ngaynghi"];
                    rex_Dm_Ngaynghi.Ngaynghi = dr["Ngaynghi"];
                }
                Selected_Rex_Dm_Ngaynghi = rex_Dm_Ngaynghi;
                this.Dispose();
                this.Close();
                return rex_Dm_Ngaynghi;
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
            this.addnewrow_clicked = true;
            gridView1.SetFocusedRowCellValue(gridView1.Columns["Ngaynghi"], DateTime.Now);
        }

        private void dgrex_Dm_Ngaynghi_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + this.gridView1.GetFocusedRowCellValue("Id_Ngaynghi") != "")
                if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Ngaynghi", "Id_Ngaynghi", this.gridView1.GetFocusedRowCellValue("Id_Ngaynghi"))) > 0)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    e.Handled = true;
                }
            }
        }

        private void txtMa_Ngaynghi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;
        }
 
    }
}

