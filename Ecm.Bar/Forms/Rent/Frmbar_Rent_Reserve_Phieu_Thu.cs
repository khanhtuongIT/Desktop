using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;
using GoobizFrame.Profile;

namespace Ecm.Bar.Forms.Rent
{
    public partial class Frmbar_Rent_Reserve_Phieu_Thu : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();

        Ecm.WebReferences.WareService.Ware_Phieu_Thu _SelectedWare_Phieu_Thu;
        public Ecm.WebReferences.WareService.Ware_Phieu_Thu SelectedWare_Phieu_Thu
        {
            get { return _SelectedWare_Phieu_Thu; }
            set { _SelectedWare_Phieu_Thu = value; }
        }

        object current_id_phieuthu;
        public object Current_Id_Phieu_Thu { get { return current_id_phieuthu; } set { current_id_phieuthu = value; } }

        private GoobizFrame.Windows.Public.OrderHashtable infoControls = new GoobizFrame.Windows.Public.OrderHashtable();
        private System.Diagnostics.Process _posk = null;
        object sotien_quydoi = null;
        decimal Sotien_Conlai = 0;

        public Frmbar_Rent_Reserve_Phieu_Thu()
        {
            InitializeComponent();
            this.barSystem.Visible = false;
            this.AfterChangeFormState += new FormStateEventHandler(Frmbar_Rent_Reserve_Phieu_Thu_AfterChangeFormState);
            DisplayInfo();

            infoControls.Add(txtNguoi_Nop, lblNguoi_Nop.Text + " yêu cầu nhập");
            infoControls.Add(txtLydo, lblLydo.Text + " yêu cầu nhập");
            infoControls.Add(txtSotien_Quydoi, lblSotien_Quydoi.Text + " yêu cầu nhập");
            infoControls.Add(txtSotien_Nguyente, lblSotien_Nguyente.Text + " yêu cầu nhập");
            infoControls.Add(lookUpEdit_Tiente, lblTiente.Text + " yêu cầu nhập");
            infoControls.Add(txtTygia, lblTygia.Text + " yêu cầu nhập");
            infoControls.Add(lookUpEditMa_Kho_Hanghoa, lblKho_Hanghoa.Text + " yêu cầu nhập");
        }

        void Frmbar_Rent_Reserve_Phieu_Thu_AfterChangeFormState(object sender, FormStateEventArgs e)
        {
            switch (e.NewFormState)
            {
                case GoobizFrame.Windows.Forms.FormState.Add:
                case GoobizFrame.Windows.Forms.FormState.Edit:
                    this.btnAdd.Enabled = false;
                    this.btnEdit.Enabled = false;

                    this.btnSave.Enabled = true;
                    this.btnCancel.Enabled = true;

                    this.btnPrint.Enabled = false;
                    this.btnExit.Enabled = false;

                    break;

                case GoobizFrame.Windows.Forms.FormState.View:
                    this.btnAdd.Enabled = true;
                    this.btnEdit.Enabled = true;

                    this.btnSave.Enabled = false;
                    this.btnCancel.Enabled = false;

                    this.btnPrint.Enabled = true;
                    this.btnExit.Enabled = true;

                    break;

            }
        }

        public override void DisplayInfo()
        {
            try
            {
                DataSet dsNhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
                lookUpEdit_Nhansu_Lapphieu.Properties.DataSource = dsNhansu.Tables[0];

                //Get data Get_All_Ware_Dm_Doituong
                DataSet dsDoituong = objMasterService.Get_All_Ware_Dm_Doituong().ToDataSet();
                lookUpEdit_Doituong.Properties.DataSource = dsDoituong.Tables[0];

                //Get data Get_All_Ware_Dm_Tiente
                DataSet dsTiente = objMasterService.Get_All_Ware_Dm_Tiente().ToDataSet();
                lookUpEdit_Tiente.Properties.DataSource = dsTiente.Tables[0];
                lookUpEditMa_Kho_Hanghoa.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().ToDataSet().Tables[0];

                Sotien_Conlai = 0;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        public override void ChangeStatus(bool editable)
        {
            this.txtChungtu_Goc.Properties.ReadOnly = !editable;
            this.txtLydo.Properties.ReadOnly = !editable;
            this.txtSochungtu.Properties.ReadOnly = true;
            this.txtDiachi.Properties.ReadOnly = true;
            this.txtSotien_Chu.Properties.ReadOnly = true;
            this.txtTygia.Properties.ReadOnly = true;
            this.dtNgay_Chungtu.Properties.ReadOnly = true;
            this.txtNguoi_Nop.Properties.ReadOnly = !editable;
            this.txtSotien_Quydoi.Enabled = editable;
            this.txtSotien_Nguyente.Properties.ReadOnly = !editable;
            this.lookUpEdit_Nhansu_Lapphieu.Properties.ReadOnly = true;
            this.lookUpEdit_Doituong.Properties.ReadOnly = !editable;
            this.lookUpEdit_Tiente.Properties.ReadOnly = !editable;
            this.txtTygia.Properties.ReadOnly = !editable;
            this.lookUpEditMa_Kho_Hanghoa.Properties.ReadOnly = !editable;
        }

        public override void ResetText()
        {
            this.txtChungtu_Goc.EditValue = "";
            this.txtLydo.EditValue = "";
            this.txtSotien_Quydoi.EditValue = "";
            this.txtSotien_Nguyente.EditValue = "";
            this.txtTygia.EditValue = "";
            this.txtSotien_Chu.EditValue = "";
            this.txtNguoi_Nop.Text = "";
            this.lookUpEdit_Doituong.EditValue = null;
            this.lookUpEdit_Tiente.EditValue = null;
            this.lookUpEditMa_Kho_Hanghoa.EditValue = null;
            this.lookUpEdit_Nhansu_Lapphieu.EditValue = Convert.ToInt64(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
            this.dtNgay_Chungtu.EditValue = objWareService.GetServerDateTime();
            this.txtSochungtu.EditValue = objWareService.GetNew_Sochungtu("ware_phieu_thu", "sochungtu", "THU");

        }

        public Ecm.WebReferences.WareService.Ware_Phieu_Thu GetEditValue()
        {
            return new Ecm.WebReferences.WareService.Ware_Phieu_Thu()
            {
                Id_Phieu_Thu = (Current_Id_Phieu_Thu != null) ? Current_Id_Phieu_Thu : -1,
                Sochungtu = txtSochungtu.EditValue,
                Ngay_Chungtu = dtNgay_Chungtu.EditValue,
                Ma_Kho_Hanghoa = ("" + lookUpEditMa_Kho_Hanghoa.EditValue != "") ? lookUpEditMa_Kho_Hanghoa.EditValue : null,
                Ma_Doituong = ("" + lookUpEdit_Doituong.EditValue != "") ? lookUpEdit_Doituong.GetColumnValue("Ma_Doituong") : null,
                Ten_Doituong = ("" + lookUpEdit_Doituong.EditValue != "") ? lookUpEdit_Doituong.GetColumnValue("Ten_Doituong") : null,
                Nguoi_Nop = txtNguoi_Nop.Text,
                Chungtu_Goc = ("" + txtChungtu_Goc.EditValue != "") ? txtChungtu_Goc.EditValue : null,
                Lydo = ("" + txtLydo.EditValue != "") ? txtLydo.EditValue : null,
                Id_Nhansu_Lapphieu = ("" + lookUpEdit_Nhansu_Lapphieu.EditValue != "") ? lookUpEdit_Nhansu_Lapphieu.EditValue : null,
                Sotien = txtSotien_Nguyente.EditValue,
                Tygia = txtTygia.EditValue,
                Id_Tiente = lookUpEdit_Tiente.EditValue,
                Sotien_Quydoi = txtSotien_Quydoi.EditValue,
            };
        }

        public override bool PerformAdd()
        {
            this.ResetText();
            lookUpEdit_Nhansu_Lapphieu.EditValue = Convert.ToInt64(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());

            this.SetInformation(infoControls);
            this.FormState = GoobizFrame.Windows.Forms.FormState.Add;
            this.ChangeStatus(true);
            return true;
        }

        public override bool PerformEdit()
        {
            if (SelectedWare_Phieu_Thu == null) return false;
            current_id_phieuthu = SelectedWare_Phieu_Thu.Id_Phieu_Thu;
            this.txtChungtu_Goc.EditValue = SelectedWare_Phieu_Thu.Chungtu_Goc;
            this.txtLydo.EditValue = SelectedWare_Phieu_Thu.Lydo;
            this.txtSotien_Quydoi.EditValue = SelectedWare_Phieu_Thu.Sotien_Quydoi;
            this.txtSotien_Nguyente.EditValue = SelectedWare_Phieu_Thu.Sotien;
            this.txtTygia.EditValue = SelectedWare_Phieu_Thu.Tygia;
            this.txtNguoi_Nop.EditValue = SelectedWare_Phieu_Thu.Nguoi_Nop;
            this.lookUpEdit_Doituong.EditValue = SelectedWare_Phieu_Thu.Ma_Doituong;
            this.lookUpEdit_Tiente.EditValue = SelectedWare_Phieu_Thu.Id_Tiente;
            this.lookUpEditMa_Kho_Hanghoa.EditValue = SelectedWare_Phieu_Thu.Ma_Kho_Hanghoa;
            this.lookUpEdit_Nhansu_Lapphieu.EditValue = SelectedWare_Phieu_Thu.Id_Nhansu_Lapphieu;
            this.dtNgay_Chungtu.EditValue = SelectedWare_Phieu_Thu.Ngay_Chungtu;
            this.txtSochungtu.EditValue = SelectedWare_Phieu_Thu.Sochungtu;
            this.SetInformation(infoControls);
            this.FormState = GoobizFrame.Windows.Forms.FormState.Edit;
            this.ChangeStatus(true);
            return true;
        }

        public override bool PerformSave()
        {
            try
            {
                bool success = false;

                GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(txtNguoi_Nop, lblNguoi_Nop.Text);
                hashtableControls.Add(txtLydo, lblLydo.Text);
                hashtableControls.Add(txtSotien_Quydoi, lblSotien_Quydoi.Text);
                hashtableControls.Add(txtSotien_Nguyente, lblSotien_Nguyente.Text);
                hashtableControls.Add(lookUpEdit_Tiente, lblTiente.Text);
                hashtableControls.Add(txtTygia, lblTygia.Text);
                hashtableControls.Add(lookUpEditMa_Kho_Hanghoa, lblKho_Hanghoa.Text);
                success = GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls, this);

                if (success)
                {
                    if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                        success = (bool)this.InsertObject();

                    else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                        success = (bool)this.UpdateObject();
                }

                if (success)
                {
                    this.DisplayInfo();
                    this.SetInformation(infoControls);
                    this.FormState = GoobizFrame.Windows.Forms.FormState.View;
                }

                return success;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                return false;
            }
        }

        public override bool PerformCancel()
        {
            this.ClearErrors();
            this.FormState = GoobizFrame.Windows.Forms.FormState.View;
            DisplayInfo();
            this.ChangeStatus(false);
            return true;
        }

        public object InsertObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Phieu_Thu objWare_Phieu_Thu = GetEditValue();
                object identity = objWareService.Insert_Ware_Phieu_Thu(objWare_Phieu_Thu);
                Current_Id_Phieu_Thu = identity;
                SelectedWare_Phieu_Thu = objWare_Phieu_Thu;
                SelectedWare_Phieu_Thu.Id_Phieu_Thu = identity;
                return true;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                return false;
            }
        }

        public object UpdateObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Phieu_Thu objWare_Phieu_Thu = GetEditValue();
                objWareService.Update_Ware_Phieu_Thu(objWare_Phieu_Thu);
                return true;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                return false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.PerformAdd();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.PerformEdit();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.PerformSave();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.PerformCancel();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.PerformPrintPreview();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOSK_Click(object sender, EventArgs e)
        {
            if (_posk == null || _posk.HasExited)
            {
                _posk = System.Diagnostics.Process.Start("osk.exe");
            }
            else
            {
                _posk.Kill();
                _posk.Dispose();
                _posk = null;
            }
        }

        private void txtSotien_Nguyente_EditValueChanged(object sender, EventArgs e)
        {
            Calculate_TienQuyDoi();
        }

        private void txtTygia_EditValueChanged(object sender, EventArgs e)
        {
            Calculate_TienQuyDoi();
        }

        void Calculate_TienQuyDoi()
        {
            if ("" + txtTygia.EditValue == "")
                txtTygia.EditValue = 1;
            decimal sotien = Convert.ToDecimal("0" + txtSotien_Nguyente.EditValue) * Convert.ToDecimal("0" + txtTygia.EditValue);
            txtSotien_Quydoi.EditValue = sotien;
            if (sotien > 0)
            {
                var sotien_chu = GoobizFrame.Windows.HelperClasses.ReadNumber.ChangeNum2VNStr((double)sotien, " đồng.");
                txtSotien_Chu.Text = sotien_chu;
            }
        }

        private void lookUpEdit_Doituong_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus
                && FormState != GoobizFrame.Windows.Forms.FormState.View)
            {
                Ecm.MasterTables.Forms.Ware.Frmware_Dm_Doituong frmDoituong = new MasterTables.Forms.Ware.Frmware_Dm_Doituong();
                frmDoituong.ShowDialog();
                if (frmDoituong.drDoituong != null)
                    lookUpEdit_Doituong.EditValue = frmDoituong.drDoituong["Ma_Doituong"];
            }
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete
                && FormState != GoobizFrame.Windows.Forms.FormState.View)
            {
                lookUpEdit_Doituong.EditValue = null;
            }
        }

        private void lookUpEditMa_Kho_Hanghoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus
               && FormState != GoobizFrame.Windows.Forms.FormState.View)
            {
                Ecm.MasterTables.Forms.Ware.Frmware_Dm_Cuahang_Ban_Add frmCuahang = new MasterTables.Forms.Ware.Frmware_Dm_Cuahang_Ban_Add();
                frmCuahang.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                frmCuahang.ShowDialog();
                if (frmCuahang.ware_Dm_Cuahang_Ban != null)
                    lookUpEditMa_Kho_Hanghoa.EditValue = frmCuahang.ware_Dm_Cuahang_Ban.Id_Cuahang_Ban;
            }
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete
                && FormState != GoobizFrame.Windows.Forms.FormState.View)
            {
                lookUpEditMa_Kho_Hanghoa.EditValue = null;
            }
        }

    }
}
