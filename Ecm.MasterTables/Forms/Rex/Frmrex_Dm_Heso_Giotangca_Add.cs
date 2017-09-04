using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ecm.MasterTables.Forms.Rex
{
    public partial class Frmrex_Dm_Heso_Giotangca_Add :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Heso_Giotangca = new DataSet();
        public Ecm.WebReferences.MasterService.Rex_Dm_Heso_Giotangca Selected_Rex_Dm_Heso_Giotangca;

        public Frmrex_Dm_Heso_Giotangca_Add()
        {
            InitializeComponent();
            DisplayInfo();
        }        

        public override void DisplayInfo()
        {
            try
            {
                ds_Heso_Giotangca = objMasterService.Get_All_Rex_Dm_Heso_Giotangca_Collection().ToDataSet();
                dgrex_Dm_Heso_Giotangca.DataSource = ds_Heso_Giotangca;
                dgrex_Dm_Heso_Giotangca.DataMember = ds_Heso_Giotangca.Tables[0].TableName;

                this.Data = ds_Heso_Giotangca;
                this.GridControl = dgrex_Dm_Heso_Giotangca;

                this.DataBindingControl();
                this.ChangeStatus(false);
                this.gvwrex_Dm_Heso_Giotangca.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region methods override

        public override void  ClearDataBindings()
        {
            this.txtId_Heso_Giotangca.DataBindings.Clear();
            this.txtMa_Heso_Giotangca.DataBindings.Clear();
            this.txtTen_Heso_Giotangca.DataBindings.Clear();
            this.txtHeso.DataBindings.Clear();
            this.dtNgay_Batdau.DataBindings.Clear();
            this.dtNgay_Ketthuc.DataBindings.Clear();
        }

        public override void  DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtId_Heso_Giotangca.DataBindings.Add("EditValue", ds_Heso_Giotangca, ds_Heso_Giotangca.Tables[0].TableName + ".Id_Heso_Giotangca");
                this.txtMa_Heso_Giotangca.DataBindings.Add("EditValue", ds_Heso_Giotangca, ds_Heso_Giotangca.Tables[0].TableName + ".Ma_Heso_Giotangca");
                this.txtTen_Heso_Giotangca.DataBindings.Add("EditValue", ds_Heso_Giotangca, ds_Heso_Giotangca.Tables[0].TableName + ".Ten_Heso_Giotangca");
                this.txtHeso.DataBindings.Add("EditValue", ds_Heso_Giotangca, ds_Heso_Giotangca.Tables[0].TableName + ".Heso");
                this.dtNgay_Batdau.DataBindings.Add("EditValue", ds_Heso_Giotangca, ds_Heso_Giotangca.Tables[0].TableName + ".Ngay_Batdau");
                this.dtNgay_Ketthuc.DataBindings.Add("EditValue", ds_Heso_Giotangca, ds_Heso_Giotangca.Tables[0].TableName + ".Ngay_Ketthuc");
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void ChangeStatus(bool editTable)
        {
            //this.gvwrex_Dm_Heso_Giotangca.OptionsBehavior.Editable = !editTable;
            //this.dgrex_Dm_Heso_Giotangca.Enabled = !editTable;
            this.txtMa_Heso_Giotangca.Properties.ReadOnly = !editTable;
            this.txtTen_Heso_Giotangca.Properties.ReadOnly = !editTable;
            this.txtHeso.Properties.ReadOnly = !editTable;
            this.dtNgay_Batdau.Properties.ReadOnly = !editTable;
            this.dtNgay_Ketthuc.Properties.ReadOnly = !editTable;
        }

        public override void  ResetText()
        {
            this.txtMa_Heso_Giotangca.EditValue = "";
            this.txtTen_Heso_Giotangca.EditValue = "";
            this.txtHeso.EditValue = "";
            this.dtNgay_Batdau.EditValue = DateTime.Now;
            this.dtNgay_Ketthuc.EditValue = DateTime.Now;
        }

        #endregion

        #region Event Override

        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Heso_Giotangca objRex_Dm_Heso_Giotangca = new Ecm.WebReferences.MasterService.Rex_Dm_Heso_Giotangca();

            objRex_Dm_Heso_Giotangca.Ma_Heso_Giotangca = txtMa_Heso_Giotangca.EditValue;
            objRex_Dm_Heso_Giotangca.Ten_Heso_Giotangca = txtTen_Heso_Giotangca.EditValue;
            objRex_Dm_Heso_Giotangca.Heso = txtHeso.EditValue;
            objRex_Dm_Heso_Giotangca.Ngay_Batdau = dtNgay_Batdau.EditValue;
            objRex_Dm_Heso_Giotangca.Ngay_Ketthuc = dtNgay_Ketthuc.EditValue;

            return objMasterService.Insert_Rex_Dm_Heso_Giotangca(objRex_Dm_Heso_Giotangca);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Heso_Giotangca objRex_Dm_Heso_Giotangca = new Ecm.WebReferences.MasterService.Rex_Dm_Heso_Giotangca();
            objRex_Dm_Heso_Giotangca.Id_Heso_Giotangca = gvwrex_Dm_Heso_Giotangca.GetFocusedRowCellValue("Id_Heso_Giotangca");

            objRex_Dm_Heso_Giotangca.Ma_Heso_Giotangca = txtMa_Heso_Giotangca.EditValue;
            objRex_Dm_Heso_Giotangca.Ten_Heso_Giotangca = txtTen_Heso_Giotangca.EditValue;
            objRex_Dm_Heso_Giotangca.Heso = txtHeso.EditValue;
            objRex_Dm_Heso_Giotangca.Ngay_Batdau = dtNgay_Batdau.EditValue;
            objRex_Dm_Heso_Giotangca.Ngay_Ketthuc = dtNgay_Batdau.EditValue;

            return objMasterService.Update_Rex_Dm_Heso_Giotangca(objRex_Dm_Heso_Giotangca);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Heso_Giotangca objRex_Dm_Heso_Giotangca = new Ecm.WebReferences.MasterService.Rex_Dm_Heso_Giotangca();
            objRex_Dm_Heso_Giotangca.Id_Heso_Giotangca = gvwrex_Dm_Heso_Giotangca.GetFocusedRowCellValue("Id_Heso_Giotangca");

            return objMasterService.Delete_Rex_Dm_Heso_Giotangca(objRex_Dm_Heso_Giotangca);
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
                hashtableControls.Add(txtMa_Heso_Giotangca, lblMa_Heso_Giotangca.Text);
                hashtableControls.Add(txtTen_Heso_Giotangca, lblTen_Heso_Giotangca.Text);
                hashtableControls.Add(txtHeso, lblHeso.Text);
                hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
                hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                    return false;

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckDateGrid(gvwrex_Dm_Heso_Giotangca.Columns["Ngay_Batdau"], gvwrex_Dm_Heso_Giotangca.Columns["Ngay_Ketthuc"], gvwrex_Dm_Heso_Giotangca))
                    return false;

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;
                System.Collections.Hashtable htb = new System.Collections.Hashtable();
                htb.Add(txtMa_Heso_Giotangca, lblMa_Heso_Giotangca.Text);

                if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Add)
                {
                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htb, (DataSet)dgrex_Dm_Heso_Giotangca.DataSource, "Ma_Heso_Giotangca"))
                        return false;
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    txtId_Heso_Giotangca.Visible = true;
                    DataSet _ds =  GoobizFrame.Windows.MdiUtils.Validator.datasetFillter((DataSet)dgrex_Dm_Heso_Giotangca.DataSource, "Id_Heso_Giotangca = " + txtId_Heso_Giotangca.Text);
                    txtId_Heso_Giotangca.Visible = false;
                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htb, _ds, "Ma_Heso_Giotangca"))
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
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblTen_Heso_Giotangca.Text, lblTen_Heso_Giotangca.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gvwrex_Dm_Heso_Giotangca.Columns["Ma_Heso_Giotangca"], "");
            hashtableControls.Add(gvwrex_Dm_Heso_Giotangca.Columns["Ten_Heso_Giotangca"], "");
            hashtableControls.Add(gvwrex_Dm_Heso_Giotangca.Columns["Heso"], "");
            hashtableControls.Add(gvwrex_Dm_Heso_Giotangca.Columns["Ngay_Batdau"], "");
            hashtableControls.Add(gvwrex_Dm_Heso_Giotangca.Columns["Ngay_Ketthuc"], "");

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gvwrex_Dm_Heso_Giotangca))
                return false;

            try
            {
                dgrex_Dm_Heso_Giotangca.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Heso_Giotangca.EmbeddedNavigator.Buttons.EndEdit);
                ds_Heso_Giotangca.Tables[0].Columns["Ma_Heso_Giotangca"].Unique = true;
                objMasterService.Update_Rex_Dm_Heso_Giotangca_Collection(this.ds_Heso_Giotangca);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Heso_Giotangca.Text, lblMa_Heso_Giotangca.Text });
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
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Rex_Dm_Heso_Giotangca"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Rex_Dm_Heso_Giotangca")   }) == DialogResult.Yes)
            {
                try
                {
                    int t = int.Parse(this.gvwrex_Dm_Heso_Giotangca.GetFocusedRowCellValue("Id_Heso_Giotangca").ToString());
                    if (Convert.ToInt32(objMasterService.GetExistReferences("rex_dm_heso_giotangca", "id_heso_giotangca", this.gvwrex_Dm_Heso_Giotangca.GetFocusedRowCellValue("Id_Heso_Giotangca"))) > 0)
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
            Ecm.WebReferences.MasterService.Rex_Dm_Heso_Giotangca rex_Dm_Heso_Giotangca = new Ecm.WebReferences.MasterService.Rex_Dm_Heso_Giotangca();
            try
            {
                int focusedRow = gvwrex_Dm_Heso_Giotangca.GetDataSourceRowIndex(gvwrex_Dm_Heso_Giotangca.FocusedRowHandle);
                DataRow dr = ds_Heso_Giotangca.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    rex_Dm_Heso_Giotangca.Id_Heso_Giotangca = dr["Id_Heso_Giotangca"];
                    rex_Dm_Heso_Giotangca.Ma_Heso_Giotangca = dr["Ma_Heso_Giotangca"];
                    rex_Dm_Heso_Giotangca.Ten_Heso_Giotangca = dr["Ten_Heso_Giotangca"];
                    rex_Dm_Heso_Giotangca.Heso = dr["Heso"];
                    rex_Dm_Heso_Giotangca.Ngay_Batdau = dr["Ngay_Batdau"];
                    rex_Dm_Heso_Giotangca.Ngay_Ketthuc = dr["Ngay_Ketthuc"];
                }
                Selected_Rex_Dm_Heso_Giotangca = rex_Dm_Heso_Giotangca;
                this.Dispose();
                this.Close();
                return rex_Dm_Heso_Giotangca;
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

        #region process controls

        private void gvwrex_Dm_Heso_Giotangca_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            //if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            //{
            //    if ("" + this.gvwrex_Dm_Heso_Giotangca.GetFocusedRowCellValue("Id_Heso_Giotangca") != "")
            //        if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Heso_Giotangca", "Id_Heso_Giotangca", this.gvwrex_Dm_Heso_Giotangca.GetFocusedRowCellValue("Id_Heso_Giotangca"))) > 0)
            //        {
            //             GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
            //            e.Handled = true;
            //        }
            //}
        }

        private void gvwrex_Dm_Heso_Giotangca_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.addnewrow_clicked = true;
            gvwrex_Dm_Heso_Giotangca.SetFocusedRowCellValue(gvwrex_Dm_Heso_Giotangca.Columns["Ngay_Batdau"], DateTime.Now);
            gvwrex_Dm_Heso_Giotangca.SetFocusedRowCellValue(gvwrex_Dm_Heso_Giotangca.Columns["Ngay_Ketthuc"], DateTime.Now);
        }

        private void txtMa_Heso_Giotangca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;
        }
        #endregion

        private void gridText_Heso_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue != null)
            {
                if (e.NewValue.ToString() == "" || e.NewValue.ToString() == "0.00" || e.NewValue.ToString().Contains("-"))
                    e.Cancel = true;

                else if (e.NewValue.ToString().Length > 7)
                    e.Cancel = true;
            }
        }

    }
}