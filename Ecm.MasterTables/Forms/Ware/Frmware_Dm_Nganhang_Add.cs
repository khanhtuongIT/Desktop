using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Ware
{
    public partial class Frmware_Dm_Nganhang_Add : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Collection = new DataSet();
        public Ecm.WebReferences.MasterService.Ware_Dm_Nganhang ware_Dm_Nganhang;

        public Frmware_Dm_Nganhang_Add()
        {
            InitializeComponent();
        }

        private void Frmware_Dm_Nganhang_Add_Load(object sender, EventArgs e)
        {
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                ds_Collection = objMasterService.Get_All_Ware_Dm_Nganhang().ToDataSet();
                dgware_Dm_Nganhang.DataSource = ds_Collection;
                dgware_Dm_Nganhang.DataMember = ds_Collection.Tables[0].TableName;

                this.Data = ds_Collection;
                this.GridControl = dgware_Dm_Nganhang;

                this.DataBindingControl();
                this.ChangeStatus(false);
                this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                //// GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }

        }

        public override void ClearDataBindings()
        {
            this.txtId_Nganhang.DataBindings.Clear();
            this.txtMa_Nganhang.DataBindings.Clear();
            this.txtTen_Nganhang.DataBindings.Clear();
            this.txtDiachi.DataBindings.Clear();
            this.txtDienthoai.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtId_Nganhang.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Nganhang");
                this.txtMa_Nganhang.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ma_Nganhang");
                this.txtTen_Nganhang.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ten_Nganhang");
                this.txtDiachi.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Diachi");
                this.txtDienthoai.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Dienthoai");
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                //// GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex); 
            }
        }

        public override void ChangeStatus(bool editTable)
        {
            //this.dgware_Dm_Nganhang.Enabled             = !editTable;
            this.txtMa_Nganhang.Properties.ReadOnly = !editTable;
            this.txtTen_Nganhang.Properties.ReadOnly = !editTable;
            this.txtDiachi.Properties.ReadOnly = !editTable;
            this.txtDienthoai.Properties.ReadOnly = !editTable;
        }

        public override void ResetText()
        {
            this.txtId_Nganhang.EditValue = null;
            this.txtMa_Nganhang.EditValue = null;
            this.txtTen_Nganhang.EditValue = null;
            this.txtDiachi.EditValue = null;
            this.txtDienthoai.EditValue = null;
        }

        #region Event Override
        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Nganhang objWare_Dm_Nganhang = new Ecm.WebReferences.MasterService.Ware_Dm_Nganhang();
            objWare_Dm_Nganhang.Id_Nganhang = -1;
            objWare_Dm_Nganhang.Ma_Nganhang = txtMa_Nganhang.EditValue;
            objWare_Dm_Nganhang.Ten_Nganhang = txtTen_Nganhang.EditValue;
            objWare_Dm_Nganhang.Diachi = txtDiachi.EditValue;
            objWare_Dm_Nganhang.Dienthoai = txtDienthoai.EditValue;
            return objMasterService.Insert_Ware_Dm_Nganhang(objWare_Dm_Nganhang);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Nganhang objWare_Dm_Nganhang = new Ecm.WebReferences.MasterService.Ware_Dm_Nganhang();
            objWare_Dm_Nganhang.Id_Nganhang = gridView1.GetFocusedRowCellValue("Id_Nganhang");
            objWare_Dm_Nganhang.Ma_Nganhang = txtMa_Nganhang.EditValue;
            objWare_Dm_Nganhang.Ten_Nganhang = txtTen_Nganhang.EditValue;
            objWare_Dm_Nganhang.Diachi = txtDiachi.EditValue;
            objWare_Dm_Nganhang.Dienthoai = txtDienthoai.EditValue;
            return objMasterService.Update_Ware_Dm_Nganhang(objWare_Dm_Nganhang);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Nganhang objWare_Dm_Nganhang = new Ecm.WebReferences.MasterService.Ware_Dm_Nganhang();
            objWare_Dm_Nganhang.Id_Nganhang = gridView1.GetFocusedRowCellValue("Id_Nganhang");
            return objMasterService.Delete_Ware_Dm_Nganhang(objWare_Dm_Nganhang);
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
                hashtableControls.Add(txtMa_Nganhang, lblMa_Nganhang.Text);
                hashtableControls.Add(txtTen_Nganhang, lblTen_Nganhang.Text);

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
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Nganhang.Text, lblMa_Nganhang.Text.ToLower() });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Nganhang"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Nganhang"], "");

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgware_Dm_Nganhang.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Nganhang.EmbeddedNavigator.Buttons.EndEdit);
                ds_Collection.Tables[0].Columns["Ma_Nganhang"].Unique = true;
                objMasterService.Update_Ware_Dm_Nganhang_Collection(this.ds_Collection);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Nganhang.Text, lblMa_Nganhang.Text.ToLower() });
                    return false;
                }
            }
            this.DisplayInfo();
            return true;
        }

        public override bool PerformDelete()
        {
            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Dm_Nganhang"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Dm_Nganhang")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Ware_Dm_Nganhang", "Id_Nganhang", this.gridView1.GetFocusedRowCellValue("Id_Nganhang"))) > 0)
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
            ware_Dm_Nganhang = new Ecm.WebReferences.MasterService.Ware_Dm_Nganhang();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Collection.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    ware_Dm_Nganhang.Id_Nganhang = dr["Id_Nganhang"];
                    ware_Dm_Nganhang.Ma_Nganhang = dr["Ma_Nganhang"];
                    ware_Dm_Nganhang.Ten_Nganhang = dr["Ten_Nganhang"];
                    ware_Dm_Nganhang.Diachi = dr["Diachi"];
                    ware_Dm_Nganhang.Dienthoai = dr["Dienthoai"];
                }
                this.Dispose();
                this.Close();
                return ware_Dm_Nganhang;
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
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Nganhang"];
            this.addnewrow_clicked = true;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.dgware_Dm_Nganhang.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Nganhang.EmbeddedNavigator.Buttons.EndEdit);
        }

        private void dgware_Dm_Nganhang_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if (Convert.ToInt32(objMasterService.GetExistReferences("Ware_Dm_Nganhang", "Id_Nganhang", this.gridView1.GetFocusedRowCellValue("Id_Nganhang"))) > 0)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    e.Handled = true;
                }
            }
        }

    }
}


