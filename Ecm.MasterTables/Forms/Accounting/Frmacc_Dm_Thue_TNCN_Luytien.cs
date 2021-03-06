using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Accounting
{
    public partial class Frmacc_Dm_Thue_TNCN_Luytien : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.MasterService objMasterTables = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet dsAcc_Dm_Thue_Tncn_Luytien = new DataSet();
        object identity;

        public Frmacc_Dm_Thue_TNCN_Luytien()
        {
            InitializeComponent();
        }

        #region ClearDatabinding & AddDatabinding & ChangeStatus & ClearText
        private void ClearDatabinding()
        {
            try
            {
                txtBacthue.DataBindings.Clear();
                txtThuesuat.DataBindings.Clear();
                txtThunhap_Tinhthue_Nam_From.DataBindings.Clear();
                txtThunhap_Tinhthue_Nam_To.DataBindings.Clear();
                txtThunhap_Tinhthue_Thang_From.DataBindings.Clear();
                txtThunhap_Tinhthue_Thang_To.DataBindings.Clear();
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
            }
        }

        private void AddDatabinding()
        {
            try
            {
                txtBacthue.DataBindings.Add("EditValue", dsAcc_Dm_Thue_Tncn_Luytien, dsAcc_Dm_Thue_Tncn_Luytien.Tables[0].TableName + ".Bacthue");
                txtThuesuat.DataBindings.Add("EditValue", dsAcc_Dm_Thue_Tncn_Luytien, dsAcc_Dm_Thue_Tncn_Luytien.Tables[0].TableName + ".Thuesuat");
                txtThunhap_Tinhthue_Nam_From.DataBindings.Add("EditValue", dsAcc_Dm_Thue_Tncn_Luytien, dsAcc_Dm_Thue_Tncn_Luytien.Tables[0].TableName + ".Thunhap_Tinhthue_Nam_From");
                txtThunhap_Tinhthue_Nam_To.DataBindings.Add("EditValue", dsAcc_Dm_Thue_Tncn_Luytien, dsAcc_Dm_Thue_Tncn_Luytien.Tables[0].TableName + ".Thunhap_Tinhthue_Nam_To");
                txtThunhap_Tinhthue_Thang_From.DataBindings.Add("EditValue", dsAcc_Dm_Thue_Tncn_Luytien, dsAcc_Dm_Thue_Tncn_Luytien.Tables[0].TableName + ".Thunhap_Tinhthue_Thang_From");
                txtThunhap_Tinhthue_Thang_To.DataBindings.Add("EditValue", dsAcc_Dm_Thue_Tncn_Luytien, dsAcc_Dm_Thue_Tncn_Luytien.Tables[0].TableName + ".Thunhap_Tinhthue_Thang_To");
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
            }
        }

        public override void ChangeStatus(bool editable)
        {
            dgacc_Dm_Thue_Tncn_Luytien.Enabled = !editable;
            txtBacthue.Properties.ReadOnly = !editable;
            txtThuesuat.Properties.ReadOnly = !editable;
            txtThunhap_Tinhthue_Nam_From.Properties.ReadOnly = !editable;
            txtThunhap_Tinhthue_Nam_To.Properties.ReadOnly = !editable;
            txtThunhap_Tinhthue_Thang_From.Properties.ReadOnly = !editable;
            txtThunhap_Tinhthue_Thang_To.Properties.ReadOnly = !editable;

        }

        private void ClearText()
        {
            txtBacthue.EditValue = null;
            txtThuesuat.EditValue = null;
            txtThunhap_Tinhthue_Nam_From.EditValue = null;
            txtThunhap_Tinhthue_Nam_To.EditValue = null;
            txtThunhap_Tinhthue_Thang_From.EditValue = null;
            txtThunhap_Tinhthue_Thang_To.EditValue = null;
        }
        #endregion

        #region InsertObject & UpdateObject & DeleteObject

        private bool InsertObject()
        {
            try
            {
                Ecm.WebReferences.MasterService.Acc_Dm_Thue_Tncn_Luytien acc_Dm_Thue_Tncn_Luytien = new Ecm.WebReferences.MasterService.Acc_Dm_Thue_Tncn_Luytien();
                acc_Dm_Thue_Tncn_Luytien.Bacthue = txtBacthue.EditValue + "";
                acc_Dm_Thue_Tncn_Luytien.Thuesuat = txtThuesuat.EditValue + "";
                acc_Dm_Thue_Tncn_Luytien.Thunhap_Tinhthue_Nam_From = txtThunhap_Tinhthue_Nam_From.EditValue + "";
                acc_Dm_Thue_Tncn_Luytien.Thunhap_Tinhthue_Nam_To = txtThunhap_Tinhthue_Nam_To.EditValue + "";
                acc_Dm_Thue_Tncn_Luytien.Thunhap_Tinhthue_Thang_From = txtThunhap_Tinhthue_Thang_From.EditValue + "";
                acc_Dm_Thue_Tncn_Luytien.Thunhap_Tinhthue_Thang_To = txtThunhap_Tinhthue_Thang_To.EditValue + "";
                identity = objMasterTables.Insert_Acc_Dm_Thue_Tncn_Luytien(acc_Dm_Thue_Tncn_Luytien);
                return true;

                return true;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
                return false;
            }
        }

        private bool UpdateObject()
        {
            try
            {
                identity = bandedGridView1.GetFocusedRowCellValue("Id_Thue_Tncn_Luytien");
                Ecm.WebReferences.MasterService.Acc_Dm_Thue_Tncn_Luytien acc_Dm_Thue_Tncn_Luytien = new Ecm.WebReferences.MasterService.Acc_Dm_Thue_Tncn_Luytien();
                acc_Dm_Thue_Tncn_Luytien.Bacthue = txtBacthue.EditValue + "";
                acc_Dm_Thue_Tncn_Luytien.Thuesuat = txtThuesuat.EditValue + "";
                acc_Dm_Thue_Tncn_Luytien.Thunhap_Tinhthue_Nam_From = txtThunhap_Tinhthue_Nam_From.EditValue + "";
                acc_Dm_Thue_Tncn_Luytien.Thunhap_Tinhthue_Nam_To = txtThunhap_Tinhthue_Nam_To.EditValue + "";
                acc_Dm_Thue_Tncn_Luytien.Thunhap_Tinhthue_Thang_From = txtThunhap_Tinhthue_Thang_From.EditValue + "";
                acc_Dm_Thue_Tncn_Luytien.Thunhap_Tinhthue_Thang_To = txtThunhap_Tinhthue_Thang_To.EditValue + "";
                acc_Dm_Thue_Tncn_Luytien.Id_Thue_Tncn_Luytien = identity;
                objMasterTables.Update_Acc_Dm_Thue_Tncn_Luytien(acc_Dm_Thue_Tncn_Luytien);

                return true;
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("ACCESS_DENIED") != -1)
                    GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { "" });
                else
                    GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
                return false;
            }
        }

        private object DeleteObject()
        {
            try
            {
                Ecm.WebReferences.MasterService.Acc_Dm_Thue_Tncn_Luytien acc_Dm_Thue_Tncn_Luytien = new Ecm.WebReferences.MasterService.Acc_Dm_Thue_Tncn_Luytien();
                acc_Dm_Thue_Tncn_Luytien.Id_Thue_Tncn_Luytien = bandedGridView1.GetFocusedRowCellValue("Id_Thue_Tncn_Luytien");
                objMasterTables.Delete_Acc_Dm_Thue_Tncn_Luytien(acc_Dm_Thue_Tncn_Luytien);

                return true;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
                return false;
            }
        }

        #endregion

        #region Override Methods 

        public override void DisplayInfo()
        {
            try
            {
                #region load dữ liệu lên lookupedit


                #endregion

                dsAcc_Dm_Thue_Tncn_Luytien = objMasterTables.Get_Acc_Dm_Thue_Tncn_Luytien_Collection().ToDataSet();
                dgacc_Dm_Thue_Tncn_Luytien.DataSource = dsAcc_Dm_Thue_Tncn_Luytien;
                dgacc_Dm_Thue_Tncn_Luytien.DataMember = dsAcc_Dm_Thue_Tncn_Luytien.Tables[0].TableName;
                ClearDatabinding();
                AddDatabinding();
                
                if (bandedGridView1.RowCount <= 0)
                {
                    ClearDatabinding();
                    ClearText();
                }
                ChangeStatus(false);
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
            }
        }

        public override bool PerformAdd()
        {
            try
            {
                identity = null;
                ClearDatabinding();
                ChangeStatus(true);
                ClearText();

                return true;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
                return false;
            }
        }

        public override bool PerformEdit()
        {
            if (!bandedGridView1.IsDataRow(bandedGridView1.FocusedRowHandle))
                return false;
            ChangeStatus(true);
            return true;

        }

        public override bool PerformCancel()
        {
            try
            {
                DisplayInfo();
                this.ChangeStatus(false);
                return true;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
                return false;
            }
        }

        public override bool PerformDelete()
        {
            if (!bandedGridView1.IsDataRow(bandedGridView1.FocusedRowHandle))
                return false;
            if (GoobizFrame.Windows.Forms.UserMessage.Show("SYS_CONFIRM_BFDELETE", new string[]  {
            GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("acc_dm_thue_tncn_luytien"),
            GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("acc_dm_thue_tncn_luytien")   }) == DialogResult.Yes)
            {
                try
                {
                    this.DeleteObject();
                }
                catch (Exception ex)
                {
                    if (ex.ToString().IndexOf("ACCESS_DENIED") != -1)
                        GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { "" });
                    else
                        GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.ToString(), this.Text);
                }
                DisplayInfo();
            }
            return base.PerformDelete();
        }

        public override bool PerformSave()
        {
            bool Saved = false;
            try
            {
                GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(txtBacthue, lblBacthue);
                hashtableControls.Add(txtThuesuat, lblThuesuat);
                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                {
                    Saved = this.InsertObject();
                }
                else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    Saved = this.UpdateObject();
                }
                if (Saved)
                {
                    this.ChangeStatus(false);
                    DisplayInfo();
                }
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
                return false;
            }
            return Saved;
        }

        public override bool PerformSaveChanges()
        {
            bool saved = false;

            try
            {
                objMasterTables.Update_Acc_Dm_Thue_Tncn_Luytien_Collection(dsAcc_Dm_Thue_Tncn_Luytien);
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
            }

            this.DisplayInfo();
            saved = true;

            return saved;
        }

        #endregion 

        private void Frmacc_Dm_Thue_TNCN_Luytien_Load(object sender, EventArgs e)
        {
            DisplayInfo();
        }
    }
}