#region edit
/*
 * edit     phuuongphan
 * date     06/04/2011
 * content  edit GUI
 */
#endregion
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;
using Ecm.Rex.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using OfficeOpenXml;
using System.Net.Mail;


namespace Ecm.Rex.Forms
{
    public partial class Frmrex_Nhansu : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        DataSet dsNhansu = new DataSet();
        DataSet ds_Bophan;
        DataSet ds_BotriNS = new DataSet();
        DataSet ds_Phucap = new DataSet();
        DataSet ds_Phucap_old = new DataSet();
        DataSet ds_Quanhe_Giadinh = new DataSet();
        DataSet ds_Dienbienluong = new DataSet();
        //private DataView filteredDataView;//dung cho tab Dien bien luong, chon ngach luong -> bac luong

        //int typeUpdate;
        public int[] id_nhansu_chon;
        object Id_Bophan;
        object Id_Nhansu;
        Ecm.WebReferences.RexService.Rex_Nhansu nhan_su;
        DevExpress.XtraTreeList.Nodes.TreeListNode focusedNode;

        //Ecm.WebReferences.RexService.Rex_Botri_Nhansu Rex_Botri_Nhansu = null;

        //Frmrex_Nhansu_Import frmrex_Nhansu_Import;

        public string XlsTemplate = @"\Resources\xls\rex_chamcong_thang.xlsx";
        public string LastXlsPath = "";
        DataSet dsExcelExp = new DataSet();
        DataSet dsHesochuongtrinh_Company = new DataSet();
        //int col = 1;
        int row = 9;

        public Frmrex_Nhansu()
        {
            InitializeComponent();

            dtNgay_Vaolam.Properties.MinValue = new DateTime(1975, 01, 01);
            dtNgaycap.Properties.MinValue = new DateTime(1950, 01, 01);

            for (int i = 1900; i <= DateTime.Today.Year; i++)
                cmbNamsinh.Properties.Items.Add(i);

            this.DisplayInfo();
        }

        void Luongtonghop_Init()
        {
            try
            {
                //tinh luong
                //objRexService.Rex_Luong_Tonghop_Init_ByBophan(DateTime.Now.Year, DateTime.Now.Month, Id_Bophan);
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
            }
        }

        #region Override Section

        public override void DisplayInfo()
        {
            try
            {
                //GoobizFrame.Windows.PlugIn.RightHelpers.CheckUserRightAction(this);
                dsHesochuongtrinh_Company = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_By_Nhomheso("Company").ToDataSet();
                //Get data master table REX                
                lookUp_NganHang.Properties.DataSource = objMasterService.Get_Acc_Dm_Nganhang_Collection3().ToDataSet().Tables[0];

                //TreeList
                ds_Bophan = objMasterService.Get_All_Rex_Dm_Bophan_Collection().ToDataSet();
                lookUp_Bophan.Properties.DataSource = ds_Bophan.Tables[0];
                treeListColumn1.TreeList.DataSource = ds_Bophan;
                treeListColumn1.TreeList.DataMember = ds_Bophan.Tables[0].TableName;
                gridLookUpEdit_Bophan.DataSource = ds_Bophan.Tables[0];
                this.txtCMND.SelectionLength = 9;
                this.ChangeStatus(false);
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }


        public override void ClearDataBindings()
        {

            try
            {
                this.txtMa_Nhansu.DataBindings.Clear();
                this.txtHo_Nhansu.DataBindings.Clear();
                this.txtTen_Nhansu.DataBindings.Clear();
                this.chkGioitinh.DataBindings.Clear();
                this.cmbNgaysinh.DataBindings.Clear();
                this.cmbThangsinh.DataBindings.Clear();
                this.cmbNamsinh.DataBindings.Clear();
                this.txtNoisinh.DataBindings.Clear();
                this.txtCMND.DataBindings.Clear();
                this.dtNgaycap.DataBindings.Clear();
                this.txtNoicap.DataBindings.Clear();
                this.txtHochieu.DataBindings.Clear();
                this.dtNgaycap_Hochieu.DataBindings.Clear();
                this.txtNoicap_Hochieu.DataBindings.Clear();
                this.dtNgay_Vaolam.DataBindings.Clear();
                this.lookUp_NganHang.DataBindings.Clear();
                this.txtTKNganHang.DataBindings.Clear();

                this.txtQuequan.DataBindings.Clear();
                this.txtDiachi_Tamtru.DataBindings.Clear();
                this.txtDiachi_Thuongtru.DataBindings.Clear();
                this.txtDienthoai_Nharieng.DataBindings.Clear();
                this.txtDienthoai.DataBindings.Clear();
                this.txtEmail.DataBindings.Clear();
                this.lookUp_Bophan.DataBindings.Clear();
                chkTruongnhom.DataBindings.Clear();
                checkEdit_Taixe.DataBindings.Clear();
                checkEditSale.DataBindings.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                txtMa_Nhansu.DataBindings.Add("Text", dsNhansu, dsNhansu.Tables[0].TableName + ".Ma_Nhansu");
                txtHo_Nhansu.DataBindings.Add("Text", dsNhansu, dsNhansu.Tables[0].TableName + ".Ho_Nhansu");
                txtTen_Nhansu.DataBindings.Add("Text", dsNhansu, dsNhansu.Tables[0].TableName + ".Ten_Nhansu");
                cmbNgaysinh.DataBindings.Add("EditValue", dsNhansu, dsNhansu.Tables[0].TableName + ".Ngay_Sinh");
                cmbThangsinh.DataBindings.Add("EditValue", dsNhansu, dsNhansu.Tables[0].TableName + ".Thangsinh");
                cmbNamsinh.DataBindings.Add("EditValue", dsNhansu, dsNhansu.Tables[0].TableName + ".Namsinh");
                chkGioitinh.DataBindings.Add("EditValue", dsNhansu, dsNhansu.Tables[0].TableName + ".Gioitinh");
                txtNoisinh.DataBindings.Add("EditValue", dsNhansu, dsNhansu.Tables[0].TableName + ".Noisinh");
                txtCMND.DataBindings.Add("EditValue", dsNhansu, dsNhansu.Tables[0].TableName + ".Cmnd");
                dtNgaycap.DataBindings.Add("EditValue", dsNhansu, dsNhansu.Tables[0].TableName + ".Ngaycap");
                txtNoicap.DataBindings.Add("EditValue", dsNhansu, dsNhansu.Tables[0].TableName + ".Noicap");
                this.txtHochieu.DataBindings.Add("EditValue", dsNhansu, dsNhansu.Tables[0].TableName + ".Hochieu");
                this.dtNgaycap_Hochieu.DataBindings.Add("EditValue", dsNhansu, dsNhansu.Tables[0].TableName + ".Ngaycap_Hochieu");
                this.txtNoicap_Hochieu.DataBindings.Add("EditValue", dsNhansu, dsNhansu.Tables[0].TableName + ".Noicap_Hochieu");
                dtNgay_Vaolam.DataBindings.Add("EditValue", dsNhansu, dsNhansu.Tables[0].TableName + ".Ngay_Vaolam");
                lookUp_NganHang.DataBindings.Add("EditValue", dsNhansu, dsNhansu.Tables[0].TableName + ".Id_Nganhang");
                txtTKNganHang.DataBindings.Add("Text", dsNhansu, dsNhansu.Tables[0].TableName + ".Taikhoan_Nganhang");

                txtQuequan.DataBindings.Add("EditValue", dsNhansu, dsNhansu.Tables[0].TableName + ".Quequan");
                txtDiachi_Thuongtru.DataBindings.Add("EditValue", dsNhansu, dsNhansu.Tables[0].TableName + ".Diachi_Thuongtru");
                txtDiachi_Tamtru.DataBindings.Add("EditValue", dsNhansu, dsNhansu.Tables[0].TableName + ".Diachi_Tamtru");
                txtDienthoai_Nharieng.DataBindings.Add("EditValue", dsNhansu, dsNhansu.Tables[0].TableName + ".Dienthoai_Nharieng");
                txtDienthoai.DataBindings.Add("EditValue", dsNhansu, dsNhansu.Tables[0].TableName + ".Dienthoai");
                txtEmail.DataBindings.Add("EditValue", dsNhansu, dsNhansu.Tables[0].TableName + ".Email");
                lookUp_Bophan.DataBindings.Add("EditValue", dsNhansu, dsNhansu.Tables[0].TableName + ".Id_Bophan");
                chkTruongnhom.DataBindings.Add("Checked", dsNhansu, dsNhansu.Tables[0].TableName + ".Truongnhom");
                checkEdit_Taixe.DataBindings.Add("Checked", dsNhansu, dsNhansu.Tables[0].TableName + ".Taixe");
                checkEditSale.DataBindings.Add("Checked", dsNhansu, dsNhansu.Tables[0].TableName + ".Sale");
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }

        public override void ChangeStatus(bool editable)
        {
            //**thong tin chung
            this.txtMa_Nhansu.Properties.ReadOnly = !editable;
            this.txtHo_Nhansu.Properties.ReadOnly = !editable;
            this.txtTen_Nhansu.Properties.ReadOnly = !editable;
            this.chkGioitinh.Properties.ReadOnly = !editable;
            this.cmbNgaysinh.Properties.ReadOnly = !editable;
            this.cmbThangsinh.Properties.ReadOnly = !editable;
            this.cmbNamsinh.Properties.ReadOnly = !editable;
            this.txtNoisinh.Properties.ReadOnly = !editable;
            this.txtCMND.Properties.ReadOnly = !editable;
            this.dtNgaycap.Properties.ReadOnly = !editable;
            this.txtNoicap.Properties.ReadOnly = !editable;
            this.txtHochieu.Properties.ReadOnly = !editable;
            this.dtNgaycap_Hochieu.Properties.ReadOnly = !editable;
            this.txtNoicap_Hochieu.Properties.ReadOnly = !editable;
            this.dtNgay_Vaolam.Properties.ReadOnly = !editable;
            this.lookUp_NganHang.Properties.ReadOnly = !editable;
            this.txtTKNganHang.Properties.ReadOnly = !editable;

            //** thong tin lien he           
            this.txtQuequan.Properties.ReadOnly = !editable;
            this.txtDiachi_Tamtru.Properties.ReadOnly = !editable;
            this.txtDiachi_Thuongtru.Properties.ReadOnly = !editable;
            this.txtDienthoai_Nharieng.Properties.ReadOnly = !editable;
            this.txtDienthoai.Properties.ReadOnly = !editable;
            this.txtEmail.Properties.ReadOnly = !editable;
            this.lookUp_Bophan.Properties.ReadOnly = !editable;
            this.dpBophan.Enabled = !editable;
            treeList_Bophan.Enabled = !editable;
            dgrex_Nhansu.Enabled = !editable;
            chkTruongnhom.Properties.ReadOnly = !editable;
            checkEdit_Taixe.Properties.ReadOnly = !editable;
            checkEditSale.Properties.ReadOnly = !editable;
        }

        public override void ResetText()
        {
            //**thong tin chung
            this.txtMa_Nhansu.EditValue = null;
            this.txtHo_Nhansu.EditValue = null;
            this.txtTen_Nhansu.EditValue = null;
            this.chkGioitinh.EditValue = null;
            this.cmbNgaysinh.EditValue = null;
            this.cmbThangsinh.EditValue = null;
            this.cmbNamsinh.EditValue = null;
            this.txtNoisinh.EditValue = null;
            this.txtCMND.EditValue = null;
            this.dtNgaycap.EditValue = null;
            this.txtNoicap.EditValue = null;
            this.txtHochieu.EditValue = null;
            this.dtNgaycap_Hochieu.EditValue = null;
            this.txtNoicap_Hochieu.EditValue = null;
            this.dtNgay_Vaolam.EditValue = null;
            this.lookUp_NganHang.EditValue = null;
            this.txtTKNganHang.EditValue = null;

            //** thong tin lien he           
            this.txtQuequan.EditValue = null;
            this.txtDiachi_Tamtru.EditValue = null;
            this.txtDiachi_Thuongtru.EditValue = null;
            this.txtDienthoai_Nharieng.EditValue = null;
            this.txtDienthoai.EditValue = null;
            this.txtEmail.EditValue = null;
            this.lookUp_Bophan.EditValue = null;
            //Rex_Botri_Nhansu = null;
            chkTruongnhom.Checked = false;
            checkEdit_Taixe.Checked = false;
            checkEditSale.Checked = false;
        }

        public object InsertObject()
        {
            Ecm.WebReferences.RexService.Rex_Nhansu objRex_Nhansu = new Ecm.WebReferences.RexService.Rex_Nhansu();
            objRex_Nhansu.Id_Nhansu = -1;

            //**thong tin chung
            objRex_Nhansu.Ma_Nhansu = this.txtMa_Nhansu.EditValue;
            objRex_Nhansu.Ho_Nhansu = this.txtHo_Nhansu.EditValue;
            objRex_Nhansu.Ten_Nhansu = this.txtTen_Nhansu.EditValue;
            objRex_Nhansu.Gioitinh = this.chkGioitinh.EditValue;
            objRex_Nhansu.Ngay_Sinh = ("" + this.cmbNgaysinh.EditValue != "") ? this.cmbNgaysinh.EditValue : objRex_Nhansu.Ngay_Sinh = null;
            objRex_Nhansu.Thangsinh = ("" + this.cmbThangsinh.EditValue != "") ? this.cmbThangsinh.EditValue : objRex_Nhansu.Thangsinh = null;
            if ("" + this.cmbNamsinh.EditValue != "") objRex_Nhansu.Namsinh = this.cmbNamsinh.EditValue;
            objRex_Nhansu.Noisinh = (txtNoisinh.Text == "") ? null : txtNoisinh.EditValue;
            objRex_Nhansu.Cmnd = (txtCMND.Text == "") ? null : txtCMND.EditValue;
            objRex_Nhansu.Noicap = this.txtNoicap.EditValue;
            if ("" + this.dtNgaycap.EditValue != "") objRex_Nhansu.Ngaycap = this.dtNgaycap.EditValue;
            objRex_Nhansu.Hochieu = (txtHochieu.Text == "") ? null : txtHochieu.EditValue;
            objRex_Nhansu.Noicap_Hochieu = this.txtNoicap_Hochieu.EditValue;
            if ("" + this.dtNgaycap_Hochieu.EditValue != "") objRex_Nhansu.Ngaycap_Hochieu = this.dtNgaycap_Hochieu.EditValue;
            if ("" + this.dtNgay_Vaolam.EditValue != "") objRex_Nhansu.Ngay_Vaolam = this.dtNgay_Vaolam.EditValue;
            if ("" + this.lookUp_NganHang.EditValue != "")
                objRex_Nhansu.Id_Nganhang = this.lookUp_NganHang.EditValue;
            objRex_Nhansu.Taikhoan_Nganhang = (txtTKNganHang.Text == "") ? null : txtTKNganHang.EditValue;

            //**thong tin lien lac
            objRex_Nhansu.Quequan = (txtQuequan.Text == "") ? null : txtQuequan.EditValue;
            objRex_Nhansu.Diachi_Thuongtru = (txtDiachi_Thuongtru.Text == "") ? null : txtDiachi_Thuongtru.EditValue;
            objRex_Nhansu.Diachi_Tamtru = (txtDiachi_Tamtru.Text == "") ? null : txtDiachi_Tamtru.EditValue;
            objRex_Nhansu.Dienthoai_Nharieng = (this.txtDienthoai_Nharieng.Text == "") ? null : txtDienthoai_Nharieng.EditValue;
            objRex_Nhansu.Dienthoai = (this.txtDienthoai.Text == "") ? null : txtDienthoai.EditValue;
            objRex_Nhansu.Email = (this.txtEmail.Text == "") ? null : txtEmail.EditValue;
            objRex_Nhansu.Id_Chuyenmon = null;
            if ("" + this.lookUp_Bophan.EditValue != "")
                objRex_Nhansu.Id_Bophan = this.lookUp_Bophan.EditValue;
            objRex_Nhansu.Truongnhom = chkTruongnhom.Checked;
            objRex_Nhansu.Taixe = checkEdit_Taixe.Checked;
            objRex_Nhansu.Sale = checkEditSale.Checked;
            object identity = objRexService.Insert_Rex_Nhansu(objRex_Nhansu);
            //Ecm.WebReferences.RexService.Rex_Botri_Nhansu Rex_Botri_Nhansu = new Ecm.WebReferences.RexService.Rex_Botri_Nhansu();
            //Rex_Botri_Nhansu.Id_Bophan = lookUp_Bophan.EditValue; ;
            //Rex_Botri_Nhansu.Id_Nhansu = identity;
            //Rex_Botri_Nhansu.Ngay_Batdau = objRex_Nhansu.Ngay_Vaolam;
            //Rex_Botri_Nhansu.Ngay_Ketthuc = null;
            //objRex_Nhansu.Truongnhom = chkTruongnhom.Checked;
            //return objRexService.Insert_Rex_Botri_Nhansu(Rex_Botri_Nhansu);
            return identity;
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.RexService.Rex_Nhansu objRex_Nhansu = new Ecm.WebReferences.RexService.Rex_Nhansu();
            objRex_Nhansu.Id_Nhansu = gvrex_Nhansu.GetFocusedRowCellValue("Id_Nhansu");

            //**thong tin chung
            objRex_Nhansu.Ma_Nhansu = this.txtMa_Nhansu.EditValue;
            objRex_Nhansu.Ho_Nhansu = this.txtHo_Nhansu.EditValue;
            objRex_Nhansu.Ten_Nhansu = this.txtTen_Nhansu.EditValue;
            objRex_Nhansu.Gioitinh = this.chkGioitinh.EditValue;
            objRex_Nhansu.Ngay_Sinh = ("" + this.cmbNgaysinh.EditValue != "") ? this.cmbNgaysinh.EditValue : objRex_Nhansu.Ngay_Sinh = null;
            objRex_Nhansu.Thangsinh = ("" + this.cmbThangsinh.EditValue != "") ? this.cmbThangsinh.EditValue : objRex_Nhansu.Thangsinh = null;
            if ("" + this.cmbNamsinh.EditValue != "") objRex_Nhansu.Namsinh = this.cmbNamsinh.EditValue;
            objRex_Nhansu.Noisinh = (txtNoisinh.Text == "") ? null : txtNoisinh.EditValue;
            objRex_Nhansu.Cmnd = (txtCMND.Text == "") ? null : txtCMND.EditValue;
            objRex_Nhansu.Noicap = this.txtNoicap.EditValue;
            if ("" + this.dtNgaycap.EditValue != "") objRex_Nhansu.Ngaycap = this.dtNgaycap.EditValue;
            objRex_Nhansu.Hochieu = (txtHochieu.Text == "") ? null : txtHochieu.EditValue;
            objRex_Nhansu.Noicap_Hochieu = (txtNoicap_Hochieu.Text == "") ? null : txtNoicap_Hochieu.EditValue;
            if ("" + this.dtNgaycap_Hochieu.EditValue != "") objRex_Nhansu.Ngaycap_Hochieu = this.dtNgaycap_Hochieu.EditValue;
            if ("" + this.dtNgay_Vaolam.EditValue != "") objRex_Nhansu.Ngay_Vaolam = this.dtNgay_Vaolam.EditValue;
            if ("" + this.lookUp_NganHang.EditValue != "")
                objRex_Nhansu.Id_Nganhang = this.lookUp_NganHang.EditValue;
            objRex_Nhansu.Taikhoan_Nganhang = (txtTKNganHang.Text == "") ? null : txtTKNganHang.EditValue;

            //**thong tin lien lac
            objRex_Nhansu.Quequan = (txtQuequan.Text == "") ? null : txtQuequan.EditValue;
            objRex_Nhansu.Diachi_Thuongtru = (txtDiachi_Thuongtru.Text == "") ? null : txtDiachi_Thuongtru.EditValue;
            objRex_Nhansu.Diachi_Tamtru = (txtDiachi_Tamtru.Text == "") ? null : txtDiachi_Tamtru.EditValue;
            objRex_Nhansu.Dienthoai_Nharieng = (this.txtDienthoai_Nharieng.Text == "") ? null : txtDienthoai_Nharieng.EditValue;
            objRex_Nhansu.Dienthoai = (this.txtDienthoai.Text == "") ? null : txtDienthoai.EditValue;
            objRex_Nhansu.Email = (this.txtEmail.Text == "") ? null : txtEmail.EditValue;

            objRex_Nhansu.Id_Chuyenmon = null;
            objRex_Nhansu.Id_Bophan = lookUp_Bophan.EditValue;
            objRex_Nhansu.Truongnhom = chkTruongnhom.Checked;
            objRex_Nhansu.Taixe = checkEdit_Taixe.Checked;
            objRex_Nhansu.Sale = checkEditSale.Checked;
            return objRexService.Update_Rex_Nhansu(objRex_Nhansu);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.RexService.Rex_Nhansu objRex_Nhansu = new Ecm.WebReferences.RexService.Rex_Nhansu();
            objRex_Nhansu.Id_Nhansu = gvrex_Nhansu.GetFocusedRowCellValue("Id_Nhansu");
            return objRexService.Delete_Rex_Nhansu(objRex_Nhansu);
        }

        public override bool PerformAdd()
        {
            ClearDataBindings();
            this.ChangeStatus(true);
            this.ResetText();
            //txtMa_Nhansu.Text = DateTime.Now.Ticks.ToString();
            txtMa_Nhansu.Text = "NS" + DateTime.Now.Day.ToString();
            txtMa_Nhansu.Focus();
            txtMa_Nhansu.SelectAll();
            return true;
        }

        public override bool PerformEdit()
        {
            if (!gvrex_Nhansu.IsDataRow(gvrex_Nhansu.FocusedRowHandle))
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn nhân sự.");
                return false;
            }
            this.ChangeStatus(true);
            return true;
        }

        public override bool PerformCancel()
        {
            //this.DisplayInfo();
            treeListColumn1.TreeList.FocusedNode = focusedNode;
            DisplayInfo2();
            ChangeStatus(false);
            return true;
        }

        // lưu đối tượng
        public override bool PerformSave()
        {
            try
            {
                bool success = false;
                GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(txtMa_Nhansu, lblMa_Nhansu.Text);
                hashtableControls.Add(txtHo_Nhansu, lblHo_Nhansu.Text);
                hashtableControls.Add(txtTen_Nhansu, lblTen_Nhansu.Text);
                hashtableControls.Add(cmbNamsinh, "Năm sinh");
                hashtableControls.Add(txtCMND, lblCMND.Text);
                hashtableControls.Add(dtNgaycap, lblNgaycap.Text);
                hashtableControls.Add(txtNoicap, lblNoicap.Text);
                hashtableControls.Add(dtNgay_Vaolam, lblNgay_Vaolam.Text);
                hashtableControls.Add(lookUp_Bophan, labelControl1.Text);

                System.Collections.Hashtable htb_Cmnd = new System.Collections.Hashtable();
                htb_Cmnd.Add(txtCMND, lblCMND.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                if ("" + cmbNgaysinh.Text != "" && "" + cmbThangsinh.Text != "" && "" + cmbNamsinh.Text != "")
                    if (!ValidateDate(cmbNamsinh.EditValue, cmbThangsinh.EditValue, cmbNgaysinh.EditValue))
                        return false;

                if (dtNgaycap.DateTime >= DateTime.Today)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Ngày cấp chứng minh nhân dân không hợp lý, vui lòng nhập lại");
                    dtNgaycap.EditValue = null;
                    return false;
                }

                try
                {
                    MailAddress mail = new MailAddress(txtEmail.Text);
                }
                catch (FormatException ex)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Định dạng mail không hợp lệ, vui lòng nhập lại");
                    return false;
                }

                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                {
                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htb_Cmnd, (DataSet)dgrex_Nhansu.DataSource, "Cmnd"))
                        return false;

                    success = Convert.ToBoolean(this.InsertObject());
                }
                else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    success = Convert.ToBoolean(UpdateObject());
                }
                if (success)
                {
                    treeListColumn1.TreeList.FocusedNode = focusedNode;
                    this.DisplayInfo2();
                    this.ChangeStatus(false);

                    //tinh luong
                    new System.Threading.Thread(new System.Threading.ThreadStart(Luongtonghop_Init)).Start();
                }
                return success;
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("exists") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Nhansu.Text, lblMa_Nhansu.Text });
                }
                else
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");

                }
                return false;
            }
        }

        public override bool PerformDelete()
        {
            if (!gvrex_Nhansu.IsDataRow(gvrex_Nhansu.FocusedRowHandle))
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn nhân sự.");
                return false;
            }

            if (gvrex_Nhansu.RowCount > 0)
            {
                if ("" + gvrex_Nhansu.GetFocusedRowCellValue("Id_Hopdong_Laodong") != "")
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Nhân sự đã lập hợp đồng lao động, không thể xóa.");
                    return false;
                }
                else
                {
                    if (GoobizFrame.Windows.Forms.UserMessage.Show("SYS_CONFIRM_BFDELETE", new string[] { txtMa_Nhansu.Text, txtHo_Nhansu.Text + " " + txtTen_Nhansu.Text }) == DialogResult.Yes)
                    {
                        try
                        {
                            this.DeleteObject();
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message.Contains("INUSE"))
                                GoobizFrame.Windows.Forms.UserMessage.Show("SYS_DATA_INUSE", new string[] { 
                                txtHo_Nhansu.Text + " " + txtTen_Nhansu.Text});
                            GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                        }
                        this.DisplayInfo();
                    }
                }
                return base.PerformDelete();
            }
            return false;
        }

        public override object PerformSelectOneObject()
        {
            try
            {
                this.id_nhansu_chon = gvrex_Nhansu.GetSelectedRows();
                this.Dispose();
                this.Close();
                return true;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return null;
            }
        }

        public override bool PerformPrintPreview()
        {
            Datasets.DsRex_Nhansu DsRpt = new Ecm.Rex.Datasets.DsRex_Nhansu();
            try
            {
                foreach (DataRow row in dsNhansu.Tables[0].Rows)
                    DsRpt.Tables[0].ImportRow(row);
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
            PrintPreview(DsRpt);
            return true;
        }

        #endregion

        #region Event Handling

        private void treeList_Bophan_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            GoobizFrame.Windows.PlugIn.RightHelpers.CheckUserRightAction(this);
            focusedNode = e.Node;
            Id_Bophan = Convert.ToInt64("" + e.Node.GetValue("Id_Bophan"));
            lookUp_Bophan.EditValue = Id_Bophan;
            DisplayInfo2();
        }

        private void btnPrint_SelectedDs_Click(object sender, EventArgs e)
        {
            //            Frmrex_Nhansu_Dialog2 Frmrex_Nhansu_Dialog2 = new Frmrex_Nhansu_Dialog2();
            //            GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(Frmrex_Nhansu_Dialog2);
            //            Frmrex_Nhansu_Dialog2.DisplayInfo();
            //            Frmrex_Nhansu_Dialog2.ShowDialog();
            //            if (Frmrex_Nhansu_Dialog2.Selected_Datarows != null && Frmrex_Nhansu_Dialog2.Selected_Datarows.Length > 0)
            //            {
            //                DataSets.DsRex_Nhansu DsRpt = new Ecm.Rex.DataSets.DsRex_Nhansu();
            //                try
            //                {
            //                    foreach (DataRow row in Frmrex_Nhansu_Dialog2.Selected_Datarows)
            //                        DsRpt.Tables[0].ImportRow(row);
            //                }
            //                catch (Exception ex)
            //                {
            //#if DEBUG
            //                    MessageBox.Show(ex.Message);
            //#endif
            //                }

            //                PrintPreview(DsRpt);
            //            }
        }

        private void lookUp_Chuyenmon_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            //{
            //    System.Windows.Forms.Form dialog = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowDialogOfMetaData("Ecm.MasterService.dll",
            //        "Ecm.MasterService.Forms.Rex.Frmrex_Dm_Chuyenmon_Add", this);
            //    if (dialog == null)
            //        return;
            //    var SelectedObject = dialog.GetType().GetProperty("Selected_Rex_Dm_Chuyenmon").GetValue(dialog, null)
            //       as Ecm.WebReferences.MasterService.Rex_Dm_Chuyenmon;

            //    DataSet dsDm_Chuyenmon = objMasterService.Get_All_Rex_Dm_Chuyenmon_Collection().ToDataSet();
            //    lookUp_Bophan.Properties.DataSource = dsDm_Chuyenmon.Tables[0];
            //    if (SelectedObject != null)
            //    {
            //        lookUp_Bophan.EditValue = SelectedObject.Id_Chuyenmon;
            //    }
            //}
        }

        #endregion

        #region Custome method

        //Ham dinh dang anh truoc khi Biding vao picture edit
        private void PictureFormat(object sender, ConvertEventArgs e)
        {
            if ("" + e.Value != "")
            {
                byte[] imagedata = (byte[])e.Value;
                MemoryStream ms = new MemoryStream();
                ms.Write(imagedata, 0, imagedata.Length);
                Image image = Image.FromStream(ms, true);
                e.Value = image;
            }
            else
            {
                e.Value = Ecm.Rex.Properties.Resources.clipping_picture;
            }
        }

        void PrintPreview(Datasets.DsRex_Nhansu DsRpt)
        {
            //init object XtraReport
            //Reports.rptRex_Nhansu_Inthe XtraReport = new Ecm.Rex.Reports.rptRex_Nhansu_Inthe();

            ////show form print preview
            //GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            ////objFormReport.FileName = txtXtra_Rpt_Name.Text;
            //frmPrintPreview.Report = XtraReport;
            //XtraReport.DataSource = DsRpt;

            //#region Set he so ctrinh - logo, ten cty

            //using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            //{
            //    DataSet dsCompany_Paras = new DataSet();
            //    dsCompany_Paras.Tables.Add("Company_Paras");
            //    dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
            //    dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
            //    dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

            //    byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

            //    dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
            //        dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
            //        ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
            //        ,imageData
            //    });

            //    XtraReport.xrTableCell_Company.DataBindings.Add(
            //       new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));

            //}

            //#endregion

            //XtraReport.CreateDocument();
            ////XtraReport.Print();

            //frmPrintPreview.printControl1.PrintingSystem = XtraReport.PrintingSystem;
            //frmPrintPreview.MdiParent = this.MdiParent;
            //frmPrintPreview.Text = this.Text + "(Xem trang in)";
            //frmPrintPreview.Show();
            //frmPrintPreview.Activate();
        }

        public void DisplayInfo2()
        {
            //if(isLoaded)
            lock (this)
            {
                try
                {
                    //txtNgaysinh.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
                    txtMa_Nhansu.Enabled = true;
                    if (treeList_Bophan.FocusedNode.GetDisplayText("Ten_Bophan").ToUpper() == "CHƯA BỐ TRÍ")
                        dsNhansu = objRexService.Get_All_Rex_Nhansu_Chuabotri_Collection().ToDataSet();
                    else
                        dsNhansu = objRexService.Get_Rex_Nhansu_ByBoPhan_Collection(Id_Bophan).ToDataSet();
                    //dsNhansu.Tables[0].Columns.Add("Trangthai_Hopdong");
                    //DataSet ds = objRex.GetAll_Rex_Nhansu_By_Bophan_Collection(id_bophan);
                    //foreach (DataRow row_rex_nhansu in dsNhansu.Tables[0].Rows)
                    //    row_rex_nhansu["Ngaysinh"] = GoobizFrame.Windows.MdiUtils.DateTimeMask.YMDToShortDatePattern("" + row_rex_nhansu["Ngaysinh"],
                    //        GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat());

                    dgrex_Nhansu.DataSource = dsNhansu;
                    dgrex_Nhansu.DataMember = dsNhansu.Tables[0].TableName;
                    DisplayNhansuInfo();
                    DataBindingControl();
                    if (gvrex_Nhansu.RowCount == 0)
                        ResetText();

                    //gvrex_Nhansu.Columns["Id_Bophan"].Visible = false;
                    this.gvrex_Nhansu.BestFitColumns();
                }
                catch (Exception ex)
                {
#if DEBUG
                    MessageBox.Show(ex.ToString());
#endif
                }
            }
        }

        private bool ValidateDate(object Nam, object Thang, object Ngay)
        {
            try
            {
                DateTime objDateTime = new DateTime(Convert.ToInt32(Nam), Convert.ToInt32(Thang), Convert.ToInt32(Ngay));
                DateTime.Parse(objDateTime.ToString());
            }
            catch
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Ngay sinh không hợp lệ, vui lòng chọn lại.");
                return false;
            }
            return true;
        }
        #endregion

        void DisplayNhansuInfo()
        {
            if ("" + gvrex_Nhansu.GetFocusedRowCellValue("Id_Nhansu") != "")
            {
                Id_Nhansu = gvrex_Nhansu.GetFocusedRowCellValue("Id_Nhansu");
                nhan_su = new Ecm.WebReferences.RexService.Rex_Nhansu();
                nhan_su.Id_Nhansu = Id_Nhansu;
            }
        }

        private void gvrex_Nhansu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DisplayNhansuInfo();
        }

        #region thong tin nhan su chi tiet
        #region BotriNS

        private void dgrex_Botri_Nhansu_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Append)
            {
                //if (gvrex_Botri_Nhansu.RowCount > 0)
                //{
                //    if ("" + gvrex_Botri_Nhansu.GetRowCellValue(gvrex_Botri_Nhansu.RowCount - 1, gvrex_Botri_Nhansu.Columns["Ngay_Ketthuc"]) != "")
                //    {
                //        DateTime dtNgay_Ketthuc = Convert.ToDateTime(gvrex_Botri_Nhansu.GetRowCellValue(gvrex_Botri_Nhansu.RowCount - 1, gvrex_Botri_Nhansu.Columns["Ngay_Ketthuc"]));
                //        //Ngày bố trí kế tiếp là ngày kết thúc kề trước cộng thêm một ngày.
                //        gridDate_Ngay_Batdau.MinValue = dtNgay_Ketthuc.AddDays(1);
                //        //Kiểm tra ngày kết thúc bố trí với ngày hiện tại.
                //        if (dtNgay_Ketthuc.CompareTo(DateTime.Today) >= 0)
                //        {
                //            GoobizFrame.Windows.Forms.MessageDialog.Show("Nhân sự đang được bố trí, không thể bố trí thêm.");
                //            e.Handled = true;
                //        }
                //    }
                //    else
                //    {
                //        GoobizFrame.Windows.Forms.MessageDialog.Show("Nhân sự đang được bố trí, không thể bố trí thêm.");
                //        e.Handled = true;
                //    }
                //}
            }
            else

                if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
                {
                }
        }


        #endregion

        #endregion

        private void navBarControl1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            switch (e.Link.ItemName)
            {
                //case "navImport_Nhansu":
                //    if (frmrex_Nhansu_Import == null || frmrex_Nhansu_Import.IsDisposed)
                //        frmrex_Nhansu_Import = new Frmrex_Nhansu_Import();
                //    frmrex_Nhansu_Import.ImpMode = Frmrex_Nhansu_Import.ImportMode.REX_NHANSU_IMP;
                //    frmrex_Nhansu_Import.Id_Bophan = Id_Bophan;
                //    frmrex_Nhansu_Import.ShowDialog();
                //    DisplayInfo2();
                //    break;

                //case "navImport_Tkhoan_Nghang":
                //    if (frmrex_Nhansu_Import == null || frmrex_Nhansu_Import.IsDisposed)
                //        frmrex_Nhansu_Import = new Frmrex_Nhansu_Import();
                //    frmrex_Nhansu_Import.ImpMode = Frmrex_Nhansu_Import.ImportMode.REX_NHANSU_ATM_IMP;
                //    frmrex_Nhansu_Import.Id_Bophan = Id_Bophan;
                //    frmrex_Nhansu_Import.ShowDialog();
                //    DisplayInfo2();
                //    break;

                case "navExport_Chamcong_ByBophan":
                    //col = 1;
                    row = 8;
                    XlsTemplate = @"\Resources\xls\rex_chamcong_thang.xlsx";
                    dsExcelExp = objRexService.GetAll_Rex_Botri_Nhansu_Stt(Id_Bophan, DateTime.Now.Year, DateTime.Now.Month).ToDataSet();
                    if (dsExcelExp.Tables[0].Rows.Count > 0)
                    {
                        SaveFileDialog ofd = new SaveFileDialog();
                        ofd.Filter = "Excel Files|*.xls|Excel 2007 Files|*.xlsx";
                        ofd.FileName = "rex_chamcong_thang_"
                            + DateTime.Now.Year.ToString() + "_"
                            + DateTime.Now.Month.ToString() + "_"
                            + "_" + treeList_Bophan.FocusedNode.GetValue("Ma_Bophan");
                        if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            LastXlsPath = ofd.FileName;
                            (new System.Threading.Thread(
                                   new System.Threading.ThreadStart(ExcelExp)
                                   )).Start();
                        }
                    }
                    break;

                case "navExport_LLTN_ByBophan":
                    //col = 1;
                    row = 8;
                    XlsTemplate = @"\Resources\xls\rex_danhsach_lltn.xlsx";
                    dsExcelExp = objRexService.Get_NhansuInfo_In_Hoso_ByBophan(Id_Bophan).ToDataSet();
                    if (dsExcelExp.Tables[0].Rows.Count > 0)
                    {
                        SaveFileDialog ofd = new SaveFileDialog();
                        ofd.Filter = "Excel Files|*.xls|Excel 2007 Files|*.xlsx";
                        ofd.FileName = "rex_danhsach_lltn_"
                            + DateTime.Now.Year.ToString() + "_"
                            + DateTime.Now.Month.ToString() + "_"
                            + "_" + treeList_Bophan.FocusedNode.GetValue("Ma_Bophan");
                        if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            LastXlsPath = ofd.FileName;
                            (new System.Threading.Thread(
                                   new System.Threading.ThreadStart(ExcelExp)
                                   )).Start();
                        }
                    }
                    break;

                case "navPrint_IDCard":
                    //           Ecm.Rex.Forms.Frmrex_Nhansu_Dialog2 frm_Nhansu2 = new Frmrex_Nhansu_Dialog2();
                    //            frm_Nhansu2.DisplayInfo();
                    //            frm_Nhansu2.ShowDialog();
                    //            if (frm_Nhansu2.Selected_Datarows != null)
                    //            {
                    //                DataSets.DsRex_Nhansu DsRpt = new Ecm.Rex.DataSets.DsRex_Nhansu();
                    //                try
                    //                {
                    //                    foreach (DataRow dr in frm_Nhansu2.Selected_Datarows)
                    //                        DsRpt.Tables[0].ImportRow(dr);
                    //                }
                    //                catch (Exception ex)
                    //                {
                    //#if DEBUG
                    //                    MessageBox.Show(ex.Message);
                    //#endif
                    //                }
                    //                PrintPreview(DsRpt);
                    //            }
                    break;

                //case "navNhansu_Info_Edit":
                //    if (!gvrex_Nhansu.IsDataRow(gvrex_Nhansu.FocusedRowHandle))
                //    {
                //        GoobizFrame.Windows.Forms.UserMessage.Show("Msg00126", new string[] { "" });
                //        return;
                //    }

                //    focusedNode = treeList_Bophan.FocusedNode;

                //    object id_nhansu = gvrex_Nhansu.GetFocusedRowCellValue("Id_Nhansu");
                //    Frmrex_Nhansu_Info frmNhansu_Info = new Frmrex_Nhansu_Info(id_nhansu);
                //    frmNhansu_Info.Text = "Cập nhật hồ sơ nhân viên";
                //    frmNhansu_Info.EnablePrintPreview = EnablePrintPreview;
                //    frmNhansu_Info.ShowDialog();
                //    treeList_Bophan.FocusedNode = focusedNode;
                //    this.DisplayInfo2();

                //    break;

                case "navNhansu_Info_Print":
                    try
                    {

                        DataSet ds_NhansuInfo_In_Hoso = objRexService.Get_NhansuInfo_In_Hoso(nhan_su).ToDataSet();
                        DataSet ds_phucap = objRexService.Get_Rex_Phucap_For_Hopdong_Laodong_Collection(Id_Nhansu, DateTime.Now).ToDataSet();
                        DataSet ds_qtrinh_dtao = objRexService.Get_Quatrinh_Daotao_In_Hoso_Nhansu(Id_Nhansu).ToDataSet();
                        DataSet ds_qtrinh_ctac = objRexService.Get_Quatrinh_Congtac_In_Hoso_Nhansu(Id_Nhansu).ToDataSet();
                        DataSet ds_qhe_gdinh = objRexService.Get_Quanhe_Giadinh_In_Hoso_Nhansu(Id_Nhansu).ToDataSet();
                        DataSet ds_dienbien_luong = objRexService.Get_Dienbien_Luong_In_Hoso_Nhansu(Id_Nhansu).ToDataSet();

                        NhansuInfoHelper.PrintSYLL(
                           ds_NhansuInfo_In_Hoso,
                           ds_phucap,
                           ds_qtrinh_dtao,
                           ds_qtrinh_ctac,
                           ds_qhe_gdinh,
                           ds_dienbien_luong, this);

                    }
                    catch (Exception ex)
                    {
                        GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
                    }
                    break;

                case "navNhansu_Info_PrintAll":
                    try
                    {

                        DataSet ds_NhansuInfo_In_Hoso = objRexService.Get_NhansuInfo_In_Hoso_ByBophan(Id_Bophan).ToDataSet();
                        DataSet ds_phucap = objRexService.Get_Phucap_In_Hoso_ByBophan(Id_Bophan).ToDataSet();
                        DataSet ds_qtrinh_dtao = objRexService.Get_Quatrinh_Daotao_In_Hoso_ByBophan(Id_Bophan).ToDataSet();
                        DataSet ds_qtrinh_ctac = objRexService.Get_Quatrinh_Congtac_In_Hoso_ByBophan(Id_Bophan).ToDataSet();
                        DataSet ds_qhe_gdinh = objRexService.Get_Quanhe_Giadinh_In_Hoso_ByBophan(Id_Bophan).ToDataSet();
                        DataSet ds_dienbien_luong = objRexService.Get_Dienbien_Luong_In_Hoso_ByBophan(Id_Bophan).ToDataSet();

                        NhansuInfoHelper.PrintSYLL(
                            ds_NhansuInfo_In_Hoso,
                            ds_phucap,
                            ds_qtrinh_dtao,
                            ds_qtrinh_ctac,
                            ds_qhe_gdinh,
                            ds_dienbien_luong,
                            this);
                    }
                    catch (Exception ex)
                    {
                        GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
                    }
                    break;

                //case "navHopdonglaodong":
                //    Frmrex_Hopdong_Laodong_ByNhansu frmrex_Hopdong_Laodong_ByNhansu = new Frmrex_Hopdong_Laodong_ByNhansu();
                //    frmrex_Hopdong_Laodong_ByNhansu.Id_Nhansu = gvrex_Nhansu.GetFocusedRowCellValue("Id_Nhansu");
                //    GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmrex_Hopdong_Laodong_ByNhansu);
                //    frmrex_Hopdong_Laodong_ByNhansu.ShowDialog();
                //    break;
            }
        }

        /// <summary>
        /// export excel
        /// </summary>
        void ExcelExp()
        {
            try
            {
                FileInfo newFile = new FileInfo(LastXlsPath);
                FileInfo template = new FileInfo(Application.StartupPath + XlsTemplate);

                ExcelPackage pck = new ExcelPackage(template);
                //Add the Content sheet
                //var ws = pck.Workbook.Worksheets.Add(""+lookUpEdit_Bophan.GetColumnValue("Ma_Bophan"));
                var ws = pck.Workbook.Worksheets["Sheet1"];
                ws.Name = "" + Id_Bophan;
                ws.View.ShowGridLines = true;

                #region CompanyName info
                ws.Cells[2, 3].Value = "" + dsHesochuongtrinh_Company.Tables[0].Select("ma_heso_chuongtrinh='CompanyName'")[0]["Heso"];

                try
                {
                    object logo = dsHesochuongtrinh_Company.Tables[0].Select("Nhom_Heso_Chuongtrinh = 'Company' and Ma_Heso_Chuongtrinh = 'CompanyLogo'")[0]["Heso"];
                    if ("" + logo != "")
                    {
                        byte[] imagedata = Convert.FromBase64String("" + logo);

                        //Read image data into a memory stream
                        MemoryStream ms = new MemoryStream(imagedata, 0, imagedata.Length);

                        ms.Write(imagedata, 0, imagedata.Length);

                        //Set image variable value using memory stream.
                        Image image = Image.FromStream(ms, true);

                        OfficeOpenXml.Drawing.ExcelPicture logoPic = null;
                        logoPic = ws.Drawings.AddPicture("Logo", image);
                        logoPic.From.Column = 0;
                        logoPic.From.Row = 0;
                        logoPic.SetSize(100, 100);
                    }

                }
                catch { }
                #endregion

                ws.Cells[5, 4].Value = treeList_Bophan.FocusedNode.GetDisplayText("Ten_Bophan");
                ws.Cells[6, 4].Value = string.Format("{0:MM/yyyy}", DateTime.Now);

                var range = ws.Cells[1, 1, 1, 100];
                var enumvalues = range.GetEnumerator();


                int i = 1;
                int end_index = 0;
                DevExpress.Utils.WaitDialogForm WaitDialogForm = new DevExpress.Utils.WaitDialogForm("Vui lòng chờ trong vài giât...", "Đang thực hiện");
                foreach (System.Data.DataRow r in dsExcelExp.Tables[0].Rows)
                {
                    //col = 1;
                    enumvalues.Reset();
                    int i_header = 1;
                    while (enumvalues.MoveNext())
                    {
                        try
                        {
                            if ("" + enumvalues.Current.Value != "~!>")
                                ws.Cells[row + i, i_header].Value = "" + r["" + enumvalues.Current.Value];
                            else
                                end_index = (end_index == 0) ? i_header : end_index;
                        }
                        catch (Exception ex) { ex.ToString(); }

                        i_header++;
                    }

                    i++;
                }
                var erow = ws.Row(1);
                erow.Hidden = true;

                var border = ws.Cells[row, 1, row + i - 1, end_index - 1].Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                WaitDialogForm.Close();
                //ws.Cells[string.Format("A{0}:D{1}",new object[]{1, irow-1})].Style.Border.Le

                pck.SaveAs(newFile);
                //open file
                System.Diagnostics.Process.Start(LastXlsPath);
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
            }
        }

        private void gridLookUp_Chucvu_Botri_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                System.Windows.Forms.Form dialog = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowDialogOfMetaData("Ecm.MasterService.dll",
                  "Ecm.MasterService.Forms.Rex.Frmrex_Dm_Chucvu_Add", this);
                if (dialog == null)
                    return;
                var SelectedObject = dialog.GetType().GetProperty("Selected_Rex_Dm_Chucvu").GetValue(dialog, null)
                    as Ecm.WebReferences.MasterService.Rex_Dm_Chucvu;

                var ds_Chucvu = objMasterService.Get_All_Rex_Dm_Chucvu_Collection().ToDataSet();
            }
        }

        private void gridLookUp_Bacluong_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                try
                {
                    System.Windows.Forms.Form dialog = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowDialogOfMetaData("Ecm.MasterService.dll",
                       "Ecm.MasterService.Forms.Rex.Frmrex_Dm_Bacluong_Add", this);
                    if (dialog == null)
                        return;
                    var SelectedObject = dialog.GetType().GetProperty("SelectedRex_Dm_Bacluong").GetValue(dialog, null)
                        as Ecm.WebReferences.MasterService.Rex_Dm_Bacluong;
                    var dsBacluong = objMasterService.Get_All_Rex_Dm_Bacluong_Collection().ToDataSet();
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "");
                }
            }
        }

        private void gridLookUp_Quyetdinh_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                System.Windows.Forms.Form dialog = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowDialogOfMetaData("Ecm.MasterService.dll",
                   "Ecm.MasterService.Forms.Rex.Frmrex_Dm_Quyetdinh_Add", this);
                if (dialog == null)
                    return;
                var SelectedObject = dialog.GetType().GetProperty("Selected_Rex_Dm_Quyetdinh").GetValue(dialog, null)
                    as Ecm.WebReferences.MasterService.Rex_Dm_Quyetdinh;

                var ds_Quyetdinh = objMasterService.Get_All_Rex_Dm_Quyetdinh_Collection();
            }
        }

        private void txtEmail_EditValueChanged(object sender, EventArgs e)
        {

        }

    }

    /// <summary>
    /// in so yeu ly lich
    /// </summary>
    public class NhansuInfoHelper
    {
        public static void PrintSYLL(DataSet ds_NhansuInfo_In_Hoso, DataSet ds_phucap, DataSet ds_qtrinh_dtao, DataSet ds_qtrinh_ctac, DataSet ds_qhe_gdinh, DataSet ds_dienbien_luong, System.Windows.Forms.Form owner)
        {
            DevExpress.Utils.WaitDialogForm WaitDialogForm = new DevExpress.Utils.WaitDialogForm("Vui lòng chờ vài giây...", "Đang thực hiện");
            try
            {
                Datasets.DsRex_Nhansu dsNhansuInfo = new Datasets.DsRex_Nhansu();

                //ds_NhansuInfo_In_Hoso
                foreach (DataRow drnhansu in ds_NhansuInfo_In_Hoso.Tables[0].Rows)
                {
                    DataRow ndrNhansuInfo = dsNhansuInfo.Tables["Rex_Nhansu"].NewRow();
                    foreach (DataColumn col in ndrNhansuInfo.Table.Columns)
                        try
                        {
                            ndrNhansuInfo[col.ColumnName] = drnhansu[col.ColumnName];
                        }
                        catch { continue; }
                    dsNhansuInfo.Tables["Rex_Nhansu"].Rows.Add(ndrNhansuInfo);
                    ndrNhansuInfo.AcceptChanges();
                }

                //detail: Phu cap
                foreach (DataRow dr in ds_phucap.Tables[0].Rows)
                {
                    DataRow ndrNhansuInfo = dsNhansuInfo.Tables["Rex_Phucap"].NewRow();
                    foreach (DataColumn col in ndrNhansuInfo.Table.Columns)
                        try
                        {
                            ndrNhansuInfo[col.ColumnName] = dr[col.ColumnName];
                        }
                        catch { continue; }
                    dsNhansuInfo.Tables["Rex_Phucap"].Rows.Add(ndrNhansuInfo);
                    ndrNhansuInfo.AcceptChanges();
                }

                //detail: dao tao                        
                foreach (DataRow dr in ds_qtrinh_dtao.Tables[0].Rows)
                {
                    DataRow ndrNhansuInfo = dsNhansuInfo.Tables["Rex_Quatrinh_Daotao"].NewRow();
                    foreach (DataColumn col in ndrNhansuInfo.Table.Columns)
                        try
                        {
                            ndrNhansuInfo[col.ColumnName] = dr[col.ColumnName];
                        }
                        catch { continue; }
                    dsNhansuInfo.Tables["Rex_Quatrinh_Daotao"].Rows.Add(ndrNhansuInfo);
                    ndrNhansuInfo.AcceptChanges();
                }

                //detail: qua trinh cong tac
                foreach (DataRow dr in ds_qtrinh_ctac.Tables[0].Rows)
                {
                    DataRow ndrNhansuInfo = dsNhansuInfo.Tables["Rex_Quatrinh_Congtac"].NewRow();
                    foreach (DataColumn col in ndrNhansuInfo.Table.Columns)
                        try
                        {
                            ndrNhansuInfo[col.ColumnName] = dr[col.ColumnName];
                        }
                        catch { continue; }
                    dsNhansuInfo.Tables["Rex_Quatrinh_Congtac"].Rows.Add(ndrNhansuInfo);
                    ndrNhansuInfo.AcceptChanges();
                }

                //detail: quan he gia dinh
                foreach (DataRow dr in ds_qhe_gdinh.Tables[0].Rows)
                {
                    DataRow ndrNhansuInfo = dsNhansuInfo.Tables["Rex_Quanhe_Giadinh"].NewRow();
                    foreach (DataColumn col in ndrNhansuInfo.Table.Columns)
                        try
                        {
                            ndrNhansuInfo[col.ColumnName] = dr[col.ColumnName];
                        }
                        catch { continue; }
                    dsNhansuInfo.Tables["Rex_Quanhe_Giadinh"].Rows.Add(ndrNhansuInfo);
                    ndrNhansuInfo.AcceptChanges();
                }

                //detail: dien bien luong
                foreach (DataRow dr in ds_dienbien_luong.Tables[0].Rows)
                {
                    DataRow ndrNhansuInfo = dsNhansuInfo.Tables["Rex_Dienbien_Luong"].NewRow();
                    foreach (DataColumn col in ndrNhansuInfo.Table.Columns)
                        try
                        {
                            ndrNhansuInfo[col.ColumnName] = dr[col.ColumnName];
                        }
                        catch { continue; }
                    dsNhansuInfo.Tables["Rex_Dienbien_Luong"].Rows.Add(ndrNhansuInfo);
                    ndrNhansuInfo.AcceptChanges();
                }

                //init object XtraReport
                Reports.RptRex_Nhansu_Syeu_Llich XtraReport = new Ecm.Rex.Reports.RptRex_Nhansu_Syeu_Llich();

                //show form print preview
                //if (objFormReport == null || objFormReport.IsDisposed)
                GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
                frmPrintPreview.Report = XtraReport;
                XtraReport.DataSource = dsNhansuInfo;

                XtraReport.CreateDocument();
                //XtraReport.Print();
                //XtraReport.xrlbNguoikhai.Text = nhan_su.Hoten_Nhansu.ToString();
                XtraReport.CreateDocument();
                frmPrintPreview.printControl1.PrintingSystem = XtraReport.PrintingSystem;
                frmPrintPreview.Text = owner.Text + " - In sơ yếu lý lịch";
                if (owner.IsMdiChild)
                {
                    frmPrintPreview.MdiParent = owner.MdiParent;
                    frmPrintPreview.Show();
                }
                else
                    frmPrintPreview.ShowDialog();
                frmPrintPreview.Activate();
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
            }

            WaitDialogForm.Close();
        }

    }
}

