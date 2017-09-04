using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;
using System.Text.RegularExpressions;

namespace Ecm.MasterTables.Forms.Ware
{
    public partial class Frmware_Dm_Khachhang_Dialog : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Collection = new DataSet();
        private Ecm.WebReferences.MasterService.Ware_Dm_Khachhang ware_Dm_Khachhang = new Ecm.WebReferences.MasterService.Ware_Dm_Khachhang();
        public Ecm.WebReferences.MasterService.Ware_Dm_Khachhang SelectedWare_Dm_Khachhang
        {
            get { return ware_Dm_Khachhang; }
            set { ware_Dm_Khachhang = value; }
        }

        public Frmware_Dm_Khachhang_Dialog()
        {
            InitializeComponent();            
        }

        public Frmware_Dm_Khachhang_Dialog(object Id_Khachhang, object Ma_Khachhang) : this()
        {
            SelectedWare_Dm_Khachhang.Ma_Khachhang = Ma_Khachhang;
            SelectedWare_Dm_Khachhang.Id_Khachhang = Id_Khachhang;
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                ds_Collection = objMasterService.Search_Ware_Dm_Khachhang(SelectedWare_Dm_Khachhang).ToDataSet();
                this.DataBindingControl();
                ChangeStatus(true);
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }
        }

        public override void ClearDataBindings()
        {
            this.txtMa_Khachhang.DataBindings.Clear();
            this.txtTen_Khachhang.DataBindings.Clear();
            this.txtDiachi_Khachhang.DataBindings.Clear();
            this.txtMasothue.DataBindings.Clear();
            this.txtDienthoai.DataBindings.Clear();
            this.txtFax.DataBindings.Clear();
            this.txtEmail.DataBindings.Clear();
            this.txtWebsite.DataBindings.Clear();
            this.txtNgaysinh.DataBindings.Clear();
            this.txtDinhmuc_No.DataBindings.Clear();
            this.txtCmnd.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtMa_Khachhang.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ma_Khachhang");
                this.txtTen_Khachhang.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ten_Khachhang");
                this.txtCmnd.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Cmnd");
                this.txtDiachi_Khachhang.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Diachi_Khachhang");
                this.txtMasothue.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Masothue");
                this.txtDienthoai.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Dienthoai");
                this.txtFax.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Fax");
                this.txtEmail.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Email");
                this.txtWebsite.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Website");
                this.txtNgaysinh.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ngay_Sinh");
                this.txtDinhmuc_No.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Dinhmuc_No");
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }
        }

        public override void ChangeStatus(bool editTable)
        {            
            this.txtMa_Khachhang.Properties.ReadOnly = editTable;
            this.txtNgaysinh.Properties.ReadOnly = editTable;
            this.txtTen_Khachhang.Properties.ReadOnly = editTable;
            this.txtCmnd.Properties.ReadOnly = editTable;
            this.txtDiachi_Khachhang.Properties.ReadOnly = editTable;
            this.txtMasothue.Properties.ReadOnly = editTable;
            this.txtDienthoai.Properties.ReadOnly = editTable;
            this.txtFax.Properties.ReadOnly = editTable;
            this.txtEmail.Properties.ReadOnly = editTable;
            this.txtWebsite.Properties.ReadOnly = editTable;
            this.txtNgaysinh.Properties.ReadOnly = editTable;
            this.txtDinhmuc_No.Properties.ReadOnly = editTable;
            btnExit.Enabled = editTable;
            btnEdit.Enabled = editTable;
            btnCancel.Enabled = !editTable;
            btnSave.Enabled = !editTable;
        }

        #region Event Override

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Khachhang objWare_Dm_Khachhang = new Ecm.WebReferences.MasterService.Ware_Dm_Khachhang();
            objWare_Dm_Khachhang.Id_Khachhang = SelectedWare_Dm_Khachhang.Id_Khachhang;
            objWare_Dm_Khachhang.Ma_Khachhang = txtMa_Khachhang.EditValue;
            objWare_Dm_Khachhang.Ten_Khachhang = txtTen_Khachhang.EditValue;

            if ("" + txtDiachi_Khachhang.EditValue == "")
                objWare_Dm_Khachhang.Diachi_Khachhang = null;
            else
                objWare_Dm_Khachhang.Diachi_Khachhang = txtDiachi_Khachhang.EditValue;

            if ("" + txtMasothue.EditValue == "")
                objWare_Dm_Khachhang.Masothue = null;
            else
                objWare_Dm_Khachhang.Masothue = txtMasothue.EditValue;

            if ("" + txtDienthoai.EditValue == "")
                objWare_Dm_Khachhang.Dienthoai = null;
            else
                objWare_Dm_Khachhang.Dienthoai = txtDienthoai.EditValue;

            if ("" + txtFax.EditValue == "")
                objWare_Dm_Khachhang.Fax = null;
            else
                objWare_Dm_Khachhang.Fax = txtFax.EditValue;

            if ("" + txtEmail.EditValue == "")
                objWare_Dm_Khachhang.Email = null;
            else
                objWare_Dm_Khachhang.Email = txtEmail.EditValue;

            if ("" + txtWebsite.EditValue == "")
                objWare_Dm_Khachhang.Website = null;
            else
                objWare_Dm_Khachhang.Website = txtWebsite.EditValue;

            if ("" + txtNgaysinh.EditValue == "")
                objWare_Dm_Khachhang.Ngay_Sinh = null;
            else
                objWare_Dm_Khachhang.Ngay_Sinh = GoobizFrame.Windows.MdiUtils.DateTimeMask.YMDFromShortDatePattern(
                    this.txtNgaysinh.Text, GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat());
            objWare_Dm_Khachhang.Cmnd = "" + txtCmnd.EditValue == "" ? null : txtCmnd.EditValue;
            objWare_Dm_Khachhang.Dinhmuc_No = "" + txtDinhmuc_No.EditValue == "" ? null : txtDinhmuc_No.EditValue;
            return objMasterService.Update_Ware_Dm_Khachhang(objWare_Dm_Khachhang);
        }

        public override bool PerformEdit()
        {
            this.ChangeStatus(false);
            return true;
        }

        public override bool PerformCancel()
        {
            this.DisplayInfo();
            return true;
        }

        public override bool PerformSave()
        {
            try
            {
                bool success = false;
                GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(txtMa_Khachhang, lblMa_Khachhang.Text);
                hashtableControls.Add(txtTen_Khachhang, lblTen_Khachhang.Text);
                hashtableControls.Add(txtCmnd, lblCmnd.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                if ("" + txtEmail.EditValue != "")
                {
                    String patterm = "[_]?([a-zA-Z1-9]+[_]?[a-zA-Z1-9]+)+[_]?[@][_]?([a-zA-Z1-9]+[_]?[a-zA-Z1-9]+)+[_]?([.][a-zA-Z1-9]+)+";
                    Regex check = new Regex(patterm, RegexOptions.IgnorePatternWhitespace);
                    if (!check.IsMatch(txtEmail.Text))
                    {
                        GoobizFrame.Windows.Forms.MessageDialog.Show("Email nhập chưa đúng ,nhập lại");
                        return false;
                    }
                }
                if ("" + txtWebsite.EditValue != "")
                {
                    String patterm = "(http://)[_]?([a-zA-Z1-9]+[_]?[a-zA-Z1-9]+)+[_]?([.][a-zA-Z1-9]+)+";
                    Regex check = new Regex(patterm, RegexOptions.IgnorePatternWhitespace);
                    if (!check.IsMatch(txtWebsite.Text))
                    {
                        GoobizFrame.Windows.Forms.MessageDialog.Show("Website nhập chưa đúng ,nhập lại");
                        return false;
                    }
                }
                success = (bool)this.UpdateObject();

                if (success)
                    this.DisplayInfo();
                return success;
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("exists_Ma_Khachhang") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Khachhang.Text, lblMa_Khachhang.Text.ToLower() });
                }
                else if (ex.ToString().IndexOf("exists_Masothue") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMasothue.Text, lblMasothue.Text.ToLower() });
                }
                return false;
            }
        }

        #endregion

        #region process buttons

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.PerformCancel();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.PerformSave();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.PerformEdit();
        }

        #endregion

    }
}

