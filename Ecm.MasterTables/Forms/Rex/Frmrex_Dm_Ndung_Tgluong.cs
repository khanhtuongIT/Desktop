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
    public partial class Frmrex_Dm_Ndung_Tgluong : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Ndung_Tgluong = new DataSet();
        public Ecm.WebReferences.MasterService.Rex_Dm_Ndung_Tgluong Selected_Rex_Dm_Ndung_Tgluong;

        public Frmrex_Dm_Ndung_Tgluong()
        {
            InitializeComponent();
            Text = "Nội dung tăng lương";
        }

        //private void dgrex_Dm_Chungchi_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{

        //}

        public override void DisplayInfo()
        {
            try
            {
                ds_Ndung_Tgluong = objMasterService.Get_All_Rex_Dm_Ndung_Tgluong_Collection().ToDataSet();
                dgrex_Dm_Ndung_Tgluong.DataSource = ds_Ndung_Tgluong;
                dgrex_Dm_Ndung_Tgluong.DataMember = ds_Ndung_Tgluong.Tables[0].TableName;

                Data = ds_Ndung_Tgluong;
                GridControl = dgrex_Dm_Ndung_Tgluong;

                DataBindingControl();
                ChangeStatus(false);
                gvrex_Dm_Ndung_Tgluong.BestFitColumns();
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
            txtMa_Ndung_Tgluong.DataBindings.Clear();
            txtNdung_Tgluong.DataBindings.Clear();
            chkTang_Luong.DataBindings.Clear();
            chkThue_Tncn.DataBindings.Clear();
        }

        public void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                txtMa_Ndung_Tgluong.DataBindings.Add("EditValue", ds_Ndung_Tgluong, ds_Ndung_Tgluong.Tables[0].TableName + ".Ma_Ndung_Tgluong");
                txtNdung_Tgluong.DataBindings.Add("EditValue", ds_Ndung_Tgluong, ds_Ndung_Tgluong.Tables[0].TableName + ".Noidung");
                chkTang_Luong.DataBindings.Add("EditValue", ds_Ndung_Tgluong, ds_Ndung_Tgluong.Tables[0].TableName + ".Pb_Tangluong");
                chkThue_Tncn.DataBindings.Add("EditValue", ds_Ndung_Tgluong, ds_Ndung_Tgluong.Tables[0].TableName + ".Pb_Thue_Tncn");
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }

        public void ChangeStatus(bool editTable)
        {
            dgrex_Dm_Ndung_Tgluong.Enabled = !editTable;
            //gvrex_Dm_Ndung_Tgluong.OptionsBehavior.Editable = !editTable;
            txtMa_Ndung_Tgluong.Properties.ReadOnly = !editTable;
            txtNdung_Tgluong.Properties.ReadOnly = !editTable;
            chkTang_Luong.Properties.ReadOnly = !editTable;
            chkThue_Tncn.Properties.ReadOnly = !editTable;
        }

        public void ResetText()
        {
            txtMa_Ndung_Tgluong.EditValue = "";
            txtNdung_Tgluong.EditValue = "";
            chkTang_Luong.EditValue = false;
            chkThue_Tncn.EditValue = false;
        }

        #region Event Override
        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Ndung_Tgluong objRex_Dm_Ndung_Tgluong = new Ecm.WebReferences.MasterService.Rex_Dm_Ndung_Tgluong();
            //objRex_Dm_Ndung_Tgluong.Id_Ndung_Tgluong = -1;
            objRex_Dm_Ndung_Tgluong.Ma_Ndung_Tgluong = txtMa_Ndung_Tgluong.EditValue;
            objRex_Dm_Ndung_Tgluong.Noidung = txtNdung_Tgluong.EditValue;
            objRex_Dm_Ndung_Tgluong.Pb_Tangluong = chkTang_Luong.EditValue;
            objRex_Dm_Ndung_Tgluong.Pb_Thue_Tncn = chkThue_Tncn.EditValue;

            objMasterService.Insert_Rex_Dm_Ndung_Tgluong(objRex_Dm_Ndung_Tgluong);
            return true;
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Ndung_Tgluong objRex_Dm_Ndung_Tgluong = new Ecm.WebReferences.MasterService.Rex_Dm_Ndung_Tgluong();
            objRex_Dm_Ndung_Tgluong.Id_Ndung_Tgluong = gvrex_Dm_Ndung_Tgluong.GetFocusedRowCellValue("Id_Ndung_Tgluong");
            objRex_Dm_Ndung_Tgluong.Ma_Ndung_Tgluong = txtMa_Ndung_Tgluong.EditValue;
            objRex_Dm_Ndung_Tgluong.Noidung = txtNdung_Tgluong.EditValue;
            objRex_Dm_Ndung_Tgluong.Pb_Tangluong = chkTang_Luong.EditValue;
            objRex_Dm_Ndung_Tgluong.Pb_Thue_Tncn = chkThue_Tncn.EditValue;

            objMasterService.Update_Rex_Dm_Ndung_Tgluong(objRex_Dm_Ndung_Tgluong);
            return true;
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Ndung_Tgluong objRex_Dm_Ndung_Tgluong = new Ecm.WebReferences.MasterService.Rex_Dm_Ndung_Tgluong();
            objRex_Dm_Ndung_Tgluong.Id_Ndung_Tgluong = gvrex_Dm_Ndung_Tgluong.GetFocusedRowCellValue("Id_Ndung_Tgluong");

            objMasterService.Delete_Rex_Dm_Ndung_Tgluong(objRex_Dm_Ndung_Tgluong);
            return true;
        }

        public override bool PerformAdd()
        {
            ClearDataBindings();
            ChangeStatus(true);
            ResetText();
            return true;
        }

        public override bool PerformEdit()
        {
            ChangeStatus(true);
            return true;
        }

        public override bool PerformCancel()
        {
            //DisplayInfo();
            ChangeStatus(false);
            return true;
        }

        public override bool PerformSave()
        {
            try
            {
                bool success = false;

                GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(txtMa_Ndung_Tgluong, lblMa_Ndung_Tgluong.Text);
                hashtableControls.Add(txtNdung_Tgluong, lblNdung_Tgluong.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                {
                    success = Convert.ToBoolean(InsertObject());
                }
                else if (FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    success = Convert.ToBoolean(UpdateObject());
                }

                if (success)
                {
                    DisplayInfo();
                }
                return success;
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("exists") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Ndung_Tgluong.Text, lblNdung_Tgluong.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gvrex_Dm_Ndung_Tgluong.Columns["Ma_Ndung_Tgluong"], "");
            hashtableControls.Add(gvrex_Dm_Ndung_Tgluong.Columns["Noidung"], "");

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gvrex_Dm_Ndung_Tgluong))
                return false;

            try
            {
                dgrex_Dm_Ndung_Tgluong.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Ndung_Tgluong.EmbeddedNavigator.Buttons.EndEdit);
                ds_Ndung_Tgluong.Tables[0].Columns["Ma_Ndung_Tgluong"].Unique = true;

                objMasterService.Update_Rex_Dm_Ndung_Tgluong_Collection(ds_Ndung_Tgluong);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Ndung_Tgluong.Text, lblNdung_Tgluong.Text });
                    return false;
                }
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
            DisplayInfo();
            return true;
        }

        public override bool PerformDelete()
        {
            if (GoobizFrame.Windows.Forms.UserMessage.Show("SYS_CONFIRM_BFDELETE", new string[]  {
            GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Rex_Dm_Ndung_Tgluong"),
            GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Rex_Dm_Ndung_Tgluong")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Ndung_Tgluong", "Id_Ndung_Tgluong", this.gvrex_Dm_Ndung_Tgluong.GetFocusedRowCellValue("Id_Ndung_Tgluong"))) > 0)
                    {
                        GoobizFrame.Windows.Forms.UserMessage.Show("SYS_DATA_INUSE", new string[] { Text.ToLower() });
                        return true;
                    }
                    this.DeleteObject();
                }
                catch
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_DATA_INUSE", new string[] { this.Text.ToLower() });

                }
                DisplayInfo();
            }
            return base.PerformDelete();
        }

        public override object PerformSelectOneObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Ndung_Tgluong Rex_Dm_Ndung_Tgluong = new Ecm.WebReferences.MasterService.Rex_Dm_Ndung_Tgluong();
            try
            {
                int focusedRow = gvrex_Dm_Ndung_Tgluong.GetDataSourceRowIndex(gvrex_Dm_Ndung_Tgluong.FocusedRowHandle);
                DataRow dr = ds_Ndung_Tgluong.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    Rex_Dm_Ndung_Tgluong.Id_Ndung_Tgluong = dr["Id_Ndung_Tgluong"];
                    Rex_Dm_Ndung_Tgluong.Ma_Ndung_Tgluong = dr["Ma_Ndung_Tgluong"];
                    Rex_Dm_Ndung_Tgluong.Noidung = dr["Noidung"];
                    Rex_Dm_Ndung_Tgluong.Pb_Tangluong = dr["Pb_Tangluong"];
                    Rex_Dm_Ndung_Tgluong.Pb_Thue_Tncn = dr["Pb_Thue_Tncn"];
                }
                Selected_Rex_Dm_Ndung_Tgluong = Rex_Dm_Ndung_Tgluong;
                Dispose();
                Close();
                return Rex_Dm_Ndung_Tgluong;
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

        private void dgrex_Dm_Ndung_Tgluong_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Ndung_Tgluong", "Id_Ndung_Tgluong", this.gvrex_Dm_Ndung_Tgluong.GetFocusedRowCellValue("Id_Ndung_Tgluong"))) > 0)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_DATA_INUSE", new string[] { this.Text.ToLower() });
                    e.Handled = true;
                }
            }
        }

        private void Frmrex_Dm_Ndung_Tgluong_Load(object sender, EventArgs e)
        {
            DisplayInfo();
        }

        private void gvrex_Dm_Ndung_Tgluong_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            dgrex_Dm_Ndung_Tgluong.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Ndung_Tgluong.EmbeddedNavigator.Buttons.EndEdit);
        }

        private void gvrex_Dm_Ndung_Tgluong_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvrex_Dm_Ndung_Tgluong.FocusedColumn = gvrex_Dm_Ndung_Tgluong.Columns["Ma_Ndung_Tgluong"];
            addnewrow_clicked = true;
        }

        private void txtMa_Ndung_Tgluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;
        }
    }
}