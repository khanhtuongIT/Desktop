using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Rex
{
    public partial class Frmrex_Dm_Tongiao_Add : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        //Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Tongiao = new DataSet();
        public Ecm.WebReferences.MasterService.Rex_Dm_Tongiao Selected_Rex_Dm_Tongiao;

        public Frmrex_Dm_Tongiao_Add()
        {
            InitializeComponent();
        }

        public override void DisplayInfo()
        {
            try
            {
                ds_Tongiao = objMasterService.Get_All_Rex_Dm_Tongiao_Collection().ToDataSet();
                dgrex_Dm_Tongiao.DataSource = ds_Tongiao;
                dgrex_Dm_Tongiao.DataMember = ds_Tongiao.Tables[0].TableName;

                this.Data = ds_Tongiao;
                this.GridControl = dgrex_Dm_Tongiao;
                this.DataBindingControl();
                this.ChangeStatus(false);
                this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public override void ClearDataBindings()
        {
            this.txtId_Tongiao.DataBindings.Clear();
            this.txtMa_Tongiao.DataBindings.Clear();
            this.txtTen_Tongiao.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();

                this.txtId_Tongiao.DataBindings.Add("EditValue", ds_Tongiao, ds_Tongiao.Tables[0].TableName + ".Id_Tongiao");
                this.txtMa_Tongiao.DataBindings.Add("EditValue", ds_Tongiao, ds_Tongiao.Tables[0].TableName + ".Ma_Tongiao");
                this.txtTen_Tongiao.DataBindings.Add("EditValue", ds_Tongiao, ds_Tongiao.Tables[0].TableName + ".Ten_Tongiao");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void ChangeStatus(bool editTable)
        {
            //this.dgrex_Dm_Tongiao.Enabled = !editTable;
            this.gridView1.OptionsBehavior.Editable = !editTable;
            this.txtMa_Tongiao.Properties.ReadOnly = !editTable;
            this.txtTen_Tongiao.Properties.ReadOnly = !editTable;
        }

        public override void ResetText()
        {
            this.txtId_Tongiao.EditValue = "";
            this.txtMa_Tongiao.EditValue = "";
            this.txtTen_Tongiao.EditValue = "";
        }

        private void Frmrex_Dm_Tongiao_Add_Load(object sender, EventArgs e)
        {
            this.DisplayInfo();
        }

        #region Event Override

        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Tongiao objRex_Dm_Tongiao = new Ecm.WebReferences.MasterService.Rex_Dm_Tongiao();
            objRex_Dm_Tongiao.Id_Tongiao = -1;
            objRex_Dm_Tongiao.Ma_Tongiao = txtMa_Tongiao.EditValue;
            objRex_Dm_Tongiao.Ten_Tongiao = txtTen_Tongiao.EditValue;
            return objMasterService.Insert_Rex_Dm_Tongiao(objRex_Dm_Tongiao);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Tongiao objRex_Dm_Tongiao = new Ecm.WebReferences.MasterService.Rex_Dm_Tongiao();
            objRex_Dm_Tongiao.Id_Tongiao = gridView1.GetFocusedRowCellValue("Id_Tongiao");
            objRex_Dm_Tongiao.Ma_Tongiao = txtMa_Tongiao.EditValue;
            objRex_Dm_Tongiao.Ten_Tongiao = txtTen_Tongiao.EditValue;
            return objMasterService.Update_Rex_Dm_Tongiao(objRex_Dm_Tongiao);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Tongiao objRex_Dm_Tongiao = new Ecm.WebReferences.MasterService.Rex_Dm_Tongiao();
            objRex_Dm_Tongiao.Id_Tongiao = gridView1.GetFocusedRowCellValue("Id_Tongiao");

            return objMasterService.Delete_Rex_Dm_Tongiao(objRex_Dm_Tongiao);
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

                GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(txtMa_Tongiao, lblMa_Tongiao.Text);
                hashtableControls.Add(txtTen_Tongiao, lblTen_Tongiao.Text);

                //hashtableControls.Remove(txtTen_Tongiao);
                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                {
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
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
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Tongiao.Text, lblMa_Tongiao.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Tongiao"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Tongiao"], "");

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgrex_Dm_Tongiao.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Tongiao.EmbeddedNavigator.Buttons.EndEdit);
                ds_Tongiao.Tables[0].Columns["Ma_Tongiao"].Unique = true;
                objMasterService.Update_Rex_Dm_Tongiao_Collection(this.ds_Tongiao);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Tongiao.Text, lblMa_Tongiao.Text });
                    return false;
                }
                //MessageBox.Show(ex.ToString());

            }
            this.DisplayInfo();
            return true;
        }

        public override bool PerformDelete()
        {
            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Rex_Dm_Tongiao"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Rex_Dm_Tongiao")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Tongiao", "Id_Tongiao", this.gridView1.GetFocusedRowCellValue("Id_Tongiao"))) > 0)
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
            return base.PerformDelete();
        }

        public override object PerformSelectOneObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Tongiao rex_Dm_Tongiao = new Ecm.WebReferences.MasterService.Rex_Dm_Tongiao();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Tongiao.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    rex_Dm_Tongiao.Id_Tongiao = dr["Id_Tongiao"];
                    rex_Dm_Tongiao.Ma_Tongiao = dr["Ma_Tongiao"];
                    rex_Dm_Tongiao.Ten_Tongiao = dr["Ten_Tongiao"];
                }
                Selected_Rex_Dm_Tongiao = rex_Dm_Tongiao;
                this.Dispose();
                this.Close();
                return rex_Dm_Tongiao;
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
            this.dgrex_Dm_Tongiao.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Tongiao.EmbeddedNavigator.Buttons.EndEdit);

        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Tongiao"];
            this.addnewrow_clicked = true;
        }

        private void dgrex_Dm_Tongiao_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + this.gridView1.GetFocusedRowCellValue("Id_Tongiao") != "")
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Tongiao", "Id_Tongiao", this.gridView1.GetFocusedRowCellValue("Id_Tongiao"))) > 0)
                    {
                        GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                        e.Handled = true;
                    }
            }
        }

        private void txtMa_Tongiao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;
        }
    }
}

