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
    public partial class Frmrex_Dm_Tinh_Add : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        //Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Tinh = new DataSet();
        public Ecm.WebReferences.MasterService.Rex_Dm_Tinh Selected_Rex_Dm_Tinh;
       
        public Frmrex_Dm_Tinh_Add()
        {
            InitializeComponent();
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                DataSet ds_Quocgia = new DataSet();
                ds_Quocgia = objMasterService.Get_All_Rex_Dm_Quocgia_Collection().ToDataSet();
                lookUp_Quocgia.Properties.DataSource = ds_Quocgia.Tables[0];
                gridLookUp_Quocgia.DataSource = ds_Quocgia.Tables[0];

                ds_Tinh = objMasterService.Get_All_Rex_Dm_Tinh_Collection().ToDataSet();
                dgrex_Dm_Tinh.DataSource = ds_Tinh;
                dgrex_Dm_Tinh.DataMember = ds_Tinh.Tables[0].TableName;

                this.Data = ds_Tinh;
                this.GridControl = dgrex_Dm_Tinh;
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
            this.lookUp_Quocgia.DataBindings.Clear();
            this.txtMa_Tinh.DataBindings.Clear();
            this.txtTen_Tinh.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.lookUp_Quocgia.DataBindings.Add("EditValue", ds_Tinh, ds_Tinh.Tables[0].TableName + ".Id_Quocgia");
                this.txtMa_Tinh.DataBindings.Add("EditValue", ds_Tinh, ds_Tinh.Tables[0].TableName + ".Ma_Tinh");
                this.txtTen_Tinh.DataBindings.Add("EditValue", ds_Tinh, ds_Tinh.Tables[0].TableName + ".Ten_Tinh");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void ChangeStatus(bool editTable)
        {
            //this.dgrex_Dm_Tinh.Enabled = !editTable;
            this.gridView1.OptionsBehavior.Editable = !editTable;
            this.txtMa_Tinh.Properties.ReadOnly = !editTable;
            this.txtTen_Tinh.Properties.ReadOnly = !editTable;
            this.lookUp_Quocgia.Properties.ReadOnly = !editTable;
        }

        public override void ResetText()
        {
            this.lookUp_Quocgia.EditValue = "";
            this.txtMa_Tinh.EditValue = "";
            this.txtTen_Tinh.EditValue = "";
        }

        private void Frmrex_Dm_Tinh_Add_Load(object sender, EventArgs e)
        {
            //this.DisplayInfo();
        }

        #region Event Override
        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Tinh objRex_Dm_Tinh = new Ecm.WebReferences.MasterService.Rex_Dm_Tinh();
            objRex_Dm_Tinh.Id_Tinh = -1;
            objRex_Dm_Tinh.Ma_Tinh = txtMa_Tinh.EditValue;
            objRex_Dm_Tinh.Ten_Tinh = txtTen_Tinh.EditValue;
            objRex_Dm_Tinh.Id_Quocgia = lookUp_Quocgia.EditValue;
            return objMasterService.Insert_Rex_Dm_Tinh(objRex_Dm_Tinh);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Tinh objRex_Dm_Tinh = new Ecm.WebReferences.MasterService.Rex_Dm_Tinh();
            objRex_Dm_Tinh.Id_Tinh = gridView1.GetFocusedRowCellValue("Id_Tinh");
            objRex_Dm_Tinh.Ma_Tinh = txtMa_Tinh.EditValue;
            objRex_Dm_Tinh.Ten_Tinh = txtTen_Tinh.EditValue;
            objRex_Dm_Tinh.Id_Quocgia = lookUp_Quocgia.EditValue;
            return objMasterService.Update_Rex_Dm_Tinh(objRex_Dm_Tinh);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Tinh objRex_Dm_Tinh = new Ecm.WebReferences.MasterService.Rex_Dm_Tinh();
            objRex_Dm_Tinh.Id_Tinh = gridView1.GetFocusedRowCellValue("Id_Tinh");
            return objMasterService.Delete_Rex_Dm_Tinh(objRex_Dm_Tinh);
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
                hashtableControls.Add(txtMa_Tinh, lblMa_Tinh.Text);
                hashtableControls.Add(txtTen_Tinh, lblTen_Tinh.Text);
                hashtableControls.Add(lookUp_Quocgia, lblId_Quocgia.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;


                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                {
                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, (DataSet)dgrex_Dm_Tinh.DataSource, "Ma_Tinh"))
                        return false;
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    DataSet ds_Tinh_filter = GoobizFrame.Windows.MdiUtils.Validator.datasetFillter(ds_Tinh, "Id_Tinh = " + gridView1.GetFocusedRowCellValue("Id_Tinh"));
                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, ds_Tinh_filter, "Ma_Tinh"))
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
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblTen_Tinh.Text, lblTen_Tinh.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Tinh"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Tinh"], "");
            hashtableControls.Add(gridView1.Columns["Id_Quocgia"], "");

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgrex_Dm_Tinh.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Tinh.EmbeddedNavigator.Buttons.EndEdit);
                ds_Tinh.Tables[0].Columns["Ma_Tinh"].Unique = true;

                Constraint constraint = new UniqueConstraint("constraint1",
                new DataColumn[] {ds_Tinh.Tables[0].Columns["Ten_Tinh"],
                ds_Tinh.Tables[0].Columns["Id_Quocgia"]}, false);
                ds_Tinh.Tables[0].Constraints.Add(constraint);

                objMasterService.Update_Rex_Dm_Tinh_Collection(this.ds_Tinh);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("contains non-unique values") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Tinh.Text, lblMa_Tinh.Text });
                    return false;
                }
                if (ex.ToString().IndexOf("These columns don't currently have unique values") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblTen_Tinh.Text, lblTen_Tinh.Text });
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
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Rex_Dm_Tinh"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Rex_Dm_Tinh")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Tinh", "Id_Tinh", this.gridView1.GetFocusedRowCellValue("Id_Tinh"))) > 0)
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
            Ecm.WebReferences.MasterService.Rex_Dm_Tinh rex_Dm_Tinh = new Ecm.WebReferences.MasterService.Rex_Dm_Tinh();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Tinh.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    rex_Dm_Tinh.Id_Tinh = dr["Id_Tinh"];
                    rex_Dm_Tinh.Ma_Tinh = dr["Ma_Tinh"];
                    rex_Dm_Tinh.Ten_Tinh = dr["Ten_Tinh"];
                    rex_Dm_Tinh.Id_Quocgia = dr["Id_Quocgia"];
                }
                Selected_Rex_Dm_Tinh = rex_Dm_Tinh;
                this.Dispose();
                this.Close();
                return rex_Dm_Tinh;
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
            this.dgrex_Dm_Tinh.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Tinh.EmbeddedNavigator.Buttons.EndEdit);
        }

        private void dgrex_Dm_Tinh_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + this.gridView1.GetFocusedRowCellValue("Id_Tinh") != "")
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Tinh", "Id_Tinh", this.gridView1.GetFocusedRowCellValue("Id_Tinh"))) > 0)
                    {
                        GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                        e.Handled = true;
                    }
            }
        }

        private void gridView1_InitNewRow_1(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Tinh"];
            this.addnewrow_clicked = true;
        }

        private void txtMa_Tinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;
        }
    }


}
