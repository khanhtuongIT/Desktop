using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Rex
{
    public partial class Frmrex_Dm_Tpbanthan_Add :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        //Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Tpbanthan = new DataSet();
        public Ecm.WebReferences.MasterService.Rex_Dm_Tpbanthan Selected_Rex_Dm_Tpbanthan;

        public Frmrex_Dm_Tpbanthan_Add()
        {
            InitializeComponent();
        }

        public override void DisplayInfo()
        {
            try
            {
                ds_Tpbanthan = objMasterService.Get_All_Rex_Dm_Tpbanthan_Collection().ToDataSet();
                dgrex_Dm_Tpbanthan.DataSource = ds_Tpbanthan;
                dgrex_Dm_Tpbanthan.DataMember = ds_Tpbanthan.Tables[0].TableName;

                this.Data = ds_Tpbanthan;
                this.GridControl = dgrex_Dm_Tpbanthan;

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
            this.txtId_Tpbanthan.DataBindings.Clear();
            this.txtMa_Tpbanthan.DataBindings.Clear();
            this.txtTen_Tpbanthan.DataBindings.Clear();
        }

        public void DataBindingControl()
        {
            try
            {
                ClearDataBindings();

                this.txtId_Tpbanthan.DataBindings.Add("EditValue", ds_Tpbanthan, ds_Tpbanthan.Tables[0].TableName + ".Id_Tpbanthan");
                this.txtMa_Tpbanthan.DataBindings.Add("EditValue", ds_Tpbanthan, ds_Tpbanthan.Tables[0].TableName + ".Ma_Tpbanthan");
                this.txtTen_Tpbanthan.DataBindings.Add("EditValue", ds_Tpbanthan, ds_Tpbanthan.Tables[0].TableName + ".Ten_Tpbanthan");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ChangeStatus(bool editTable)
        {
            //this.dgrex_Dm_Tpbanthan.Enabled = !editTable;
            this.gridView1.OptionsBehavior.Editable = !editTable;
            this.txtMa_Tpbanthan.Properties.ReadOnly = !editTable;
            this.txtTen_Tpbanthan.Properties.ReadOnly = !editTable;
        }

        public void ResetText()
        {
            this.txtId_Tpbanthan.EditValue = "";
            this.txtMa_Tpbanthan.EditValue = "";
            this.txtTen_Tpbanthan.EditValue = "";
        }

        private void Frmrex_Dm_Tpbanthan_Add_Load(object sender, EventArgs e)
        {
            this.DisplayInfo();
        }

        #region Event Override
        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Tpbanthan objRex_Dm_Tpbanthan = new Ecm.WebReferences.MasterService.Rex_Dm_Tpbanthan();
            objRex_Dm_Tpbanthan.Id_Tpbanthan = -1;
            objRex_Dm_Tpbanthan.Ma_Tpbanthan = txtMa_Tpbanthan.EditValue;
            objRex_Dm_Tpbanthan.Ten_Tpbanthan = txtTen_Tpbanthan.EditValue;

            return objMasterService.Insert_Rex_Dm_Tpbanthan(objRex_Dm_Tpbanthan);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Tpbanthan objRex_Dm_Tpbanthan = new Ecm.WebReferences.MasterService.Rex_Dm_Tpbanthan();
            objRex_Dm_Tpbanthan.Id_Tpbanthan = gridView1.GetFocusedRowCellValue("Id_Tpbanthan");
            objRex_Dm_Tpbanthan.Ma_Tpbanthan = txtMa_Tpbanthan.EditValue;
            objRex_Dm_Tpbanthan.Ten_Tpbanthan = txtTen_Tpbanthan.EditValue;


            return objMasterService.Update_Rex_Dm_Tpbanthan(objRex_Dm_Tpbanthan);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Tpbanthan objRex_Dm_Tpbanthan = new Ecm.WebReferences.MasterService.Rex_Dm_Tpbanthan();
            objRex_Dm_Tpbanthan.Id_Tpbanthan = gridView1.GetFocusedRowCellValue("Id_Tpbanthan");

            return objMasterService.Delete_Rex_Dm_Tpbanthan(objRex_Dm_Tpbanthan);
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
                hashtableControls.Add(txtMa_Tpbanthan, lblMa_Tpbanthan.Text);
                hashtableControls.Add(txtTen_Tpbanthan, lblTen_Tpbanthan.Text);

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
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Tpbanthan.Text, lblMa_Tpbanthan.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Tpbanthan"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Tpbanthan"], "");

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgrex_Dm_Tpbanthan.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Tpbanthan.EmbeddedNavigator.Buttons.EndEdit);
                ds_Tpbanthan.Tables[0].Columns["Ma_Tpbanthan"].Unique = true;
                objMasterService.Update_Rex_Dm_Tpbanthan_Collection(this.ds_Tpbanthan);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Tpbanthan.Text, lblMa_Tpbanthan.Text });
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
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Rex_Dm_Tpbanthan"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Rex_Dm_Tpbanthan")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Tpbanthan", "Id_Tpbanthan", this.gridView1.GetFocusedRowCellValue("Id_Tpbanthan"))) > 0)
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
            Ecm.WebReferences.MasterService.Rex_Dm_Tpbanthan rex_Dm_Tpbanthan = new Ecm.WebReferences.MasterService.Rex_Dm_Tpbanthan();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Tpbanthan.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    rex_Dm_Tpbanthan.Id_Tpbanthan = dr["Id_Tpbanthan"];
                    rex_Dm_Tpbanthan.Ma_Tpbanthan = dr["Ma_Tpbanthan"];
                    rex_Dm_Tpbanthan.Ten_Tpbanthan = dr["Ten_Tpbanthan"];
                }
                Selected_Rex_Dm_Tpbanthan = rex_Dm_Tpbanthan;
                this.Dispose();
                this.Close();
                return rex_Dm_Tpbanthan;
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
            this.dgrex_Dm_Tpbanthan.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Tpbanthan.EmbeddedNavigator.Buttons.EndEdit);

        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Tpbanthan"];
            this.addnewrow_clicked = true;
            //this.gridView1.OptionsBehavior.Editable = true;
        }

        private void dgrex_Dm_Tpbanthan_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + this.gridView1.GetFocusedRowCellValue("Id_Tpbanthan") != "")
                if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Tpbanthan", "Id_Tpbanthan", this.gridView1.GetFocusedRowCellValue("Id_Tpbanthan"))) > 0)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    e.Handled = true;
                }
            }
        }

        private void txtMa_Tpbanthan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;
        }
    }
}

