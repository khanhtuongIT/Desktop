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
    public partial class Frmbar_Rent_Reserve_Info : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        Ecm.WebReferences.Classes.BarService objBarService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.BarService>();
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();

        private System.Diagnostics.Process _posk = null;
        private GoobizFrame.Windows.Public.OrderHashtable infoControls = new GoobizFrame.Windows.Public.OrderHashtable();

        DataSet dsBar_Rent_Reserve_Table;
        DataSet dsBar_Rent_Reserve_Phieuthu;

        private Guid guid_reserve;
        public Guid Current_Guid_Reserve { get { return guid_reserve; } set { guid_reserve = value; } }

        private object id_reserve;
        public object Current_Id_Reserve { get { return id_reserve; } set { id_reserve = value; } }

        private object id_cuahang_ban;
        public object Current_Id_Cuahang_Ban
        {
            get
            {
                id_cuahang_ban = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocation("Id_Cuahang_Ban");
                return id_cuahang_ban;
            }
        }

        public Frmbar_Rent_Reserve_Info()
        {
            InitializeComponent();
            DisplayInfo();
            ChangeFormState(GoobizFrame.Windows.Forms.FormState.View);
            this.AfterChangeFormState += new FormStateEventHandler(Frmbar_Rent_Reserve_Info_AfterChangeFormState);
            infoControls.Add(lookUpEdit_Khachhang, "Khách hàng yêu cầu nhập");
            infoControls.Add(dtNgay_Batdau, "Ngày đến  yêu cầu nhập");
            infoControls.Add(dtNgay_Ketthuc, "Ngày đi  yêu cầu nhập");
            infoControls.Add(lookUpEdit_Class, "loại phòng  yêu cầu nhập");
            infoControls.Add(txtSoluong_Phong, "SL phòng  yêu cầu nhập");
            infoControls.Add(txtReserver_Hoten, "Người đặt  yêu cầu nhập");
        }

        void Frmbar_Rent_Reserve_Info_AfterChangeFormState(object sender, FormStateEventArgs e)
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

                    this.btnRoom_Add.Enabled = true;
                    this.btnRoom_Delete.Enabled = true;

                    this.btnPthu_Add.Enabled = true;
                    this.btnPthu_Edit.Enabled = true;
                    this.btnPthu_Delete.Enabled = true;
                    break;

                case GoobizFrame.Windows.Forms.FormState.View:
                    this.btnAdd.Enabled = true;
                    this.btnEdit.Enabled = true;

                    this.btnSave.Enabled = false;
                    this.btnCancel.Enabled = false;

                    this.btnPrint.Enabled = true;
                    this.btnExit.Enabled = true;

                    this.btnRoom_Add.Enabled = false;
                    this.btnRoom_Delete.Enabled = false;

                    this.btnPthu_Add.Enabled = false;
                    this.btnPthu_Edit.Enabled = false;
                    this.btnPthu_Delete.Enabled = false;
                    break;
            }
        }

        void DisplayInfo_Reserve_Table()
        {
            if (Current_Guid_Reserve != null)
            {
                dsBar_Rent_Reserve_Table = objBarService.Get_All_Bar_Rent_Reserve_Table(Current_Guid_Reserve).ToDataSet();
                dgBar_Rent_Reserve_Table.DataSource = dsBar_Rent_Reserve_Table.Tables[0];
                if (cvBar_Rent_Reserve_Table.RowCount > 0)
                {
                    cvBar_Rent_Reserve_Table.FocusedRowHandle = 0;
                    cvBar_Rent_Reserve_Table.Focus();
                    GoobizFrame.Windows.MdiUtils.ThemeSettings.MakeConditionForSelectedCard(cvBar_Rent_Reserve_Table, "Id_Reserve_Table",
                        cvBar_Rent_Reserve_Table.GetFocusedRowCellValue("Id_Reserve_Table")
                        );
                }
            }
        }

        void DisplayInfo_Reserve_Phieuthu()
        {
            if (Current_Guid_Reserve != null)
            {
                dsBar_Rent_Reserve_Phieuthu = objBarService.Get_All_Bar_Rent_Reserve_Phieuthu(Current_Guid_Reserve).ToDataSet();
                dgBar_Rent_Reserve_Phieuthu.DataSource = dsBar_Rent_Reserve_Phieuthu.Tables[0];

                if (gvBar_Rent_Reserve_Phieuthu.RowCount > 0)
                {
                    gvBar_Rent_Reserve_Phieuthu.FocusedRowHandle = 0;
                    gvBar_Rent_Reserve_Phieuthu.Focus();
                }
            }
        }

        #region override methods of FormUpdateWithToolbar

        public override void DisplayInfo()
        {
            lookUpEdit_Class.Properties.DataSource = objMasterService.Get_All_Bar_Dm_Class().ToDataSet().Tables[0];
            lookUpEdit_Khachhang.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet().Tables[0];
            lookUpEdit_Nhansu_Ctu.Properties.DataSource = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet().Tables[0];
            gridLookUpEdit_Tiente.DataSource = objMasterService.Get_All_Ware_Dm_Tiente().ToDataSet().Tables[0];
            DisplayInfo_Reserve_Table();
            DisplayInfo_Reserve_Phieuthu();
            ChangeStatus(false);
            base.DisplayInfo();
        }

        public override void ChangeStatus(bool editTable)
        {
            lookUpEdit_Khachhang.Properties.ReadOnly = !editTable;
            dtNgay_Batdau.Properties.ReadOnly = !editTable;
            dtNgay_Ketthuc.Properties.ReadOnly = !editTable;
            lookUpEdit_Class.Properties.ReadOnly = !editTable;
            //txtSoluong_Phong.Properties.ReadOnly = !editTable;
            txtSoluong_Khach.Properties.ReadOnly = !editTable;
            txtReserver_Hoten.Properties.ReadOnly = !editTable;
            txtReserver_Cmnd.Properties.ReadOnly = !editTable;
            txtReserver_Tel.Properties.ReadOnly = !editTable;
            txtChietkhau_Tyle.Properties.ReadOnly = !editTable;
            txtChietkhau_Tienmat.Properties.ReadOnly = !editTable;
            txtReserver_Email.Properties.ReadOnly = !editTable;
            //chkThanhtoantruoc.Properties.ReadOnly = !editTable;
            dtNgay_Chungtu.Properties.ReadOnly = true;
            txtSo_Chungtu.Properties.ReadOnly = true;
            lookUpEdit_Nhansu_Ctu.Properties.ReadOnly = true;
            memGhichu.Properties.ReadOnly = !editTable;
            gvBar_Rent_Reserve_Phieuthu.OptionsBehavior.ReadOnly = !editTable;
        }

        public override void ResetText()
        {
            lookUpEdit_Khachhang.EditValue = null;
            dtNgay_Batdau.EditValue = null;
            dtNgay_Ketthuc.EditValue = null;
            lookUpEdit_Class.EditValue = null;
            txtSoluong_Phong.EditValue = 0;
            txtSoluong_Khach.EditValue = 0;
            txtReserver_Hoten.EditValue = null;
            txtReserver_Cmnd.EditValue = null;
            txtReserver_Tel.EditValue = null;
            txtChietkhau_Tyle.EditValue = null;
            txtChietkhau_Tienmat.EditValue = null;
            txtReserver_Email.EditValue = null;
            chkThanhtoantruoc.EditValue = null;
            dtNgay_Chungtu.EditValue = DateTime.Now;
            txtSo_Chungtu.Text = "" + objBarService.GetNew_Sochungtu("bar_rent_reserve", "So_Chungtu", "RRES"); ;
            lookUpEdit_Nhansu_Ctu.EditValue = Convert.ToInt64(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu()); ;
            memGhichu.EditValue = null;
            dgBar_Rent_Reserve_Phieuthu.DataSource = null;
            dgBar_Rent_Reserve_Table.DataSource = null;
        }

        public Ecm.WebReferences.BarService.Bar_Rent_Reserve GetEditValue()
        {
            return new Ecm.WebReferences.BarService.Bar_Rent_Reserve()
            {
                Id_Reserve = Current_Id_Reserve,
                Id_Khachhang = lookUpEdit_Khachhang.EditValue,
                Ngay_Batdau = (!string.IsNullOrEmpty("" + dtNgay_Batdau.EditValue)) ? dtNgay_Batdau.EditValue : null,
                Ngay_Ketthuc = (!string.IsNullOrEmpty("" + dtNgay_Ketthuc.EditValue)) ? dtNgay_Ketthuc.EditValue : null,
                Id_Class = (!string.IsNullOrEmpty("" + lookUpEdit_Class.EditValue)) ? lookUpEdit_Class.EditValue : null,
                Soluong_Phong = (!string.IsNullOrEmpty("" + txtSoluong_Phong.EditValue)) ? txtSoluong_Phong.EditValue : null,
                Soluong_Khach = (!string.IsNullOrEmpty("" + txtSoluong_Khach.EditValue)) ? txtSoluong_Khach.EditValue : null,
                Reserver_Hoten = (!string.IsNullOrEmpty("" + txtReserver_Hoten.EditValue)) ? txtReserver_Hoten.EditValue : null,
                Reserver_Cmnd = (!string.IsNullOrEmpty("" + txtReserver_Cmnd.EditValue)) ? txtReserver_Cmnd.EditValue : null,
                Reserver_Tel = (!string.IsNullOrEmpty("" + txtReserver_Tel.EditValue)) ? txtReserver_Tel.EditValue : null,
                Chietkhau_Tyle = (!string.IsNullOrEmpty("" + txtChietkhau_Tyle.EditValue)) ? txtChietkhau_Tyle.EditValue : null,
                Chietkhau_Tienmat = (!string.IsNullOrEmpty("" + txtChietkhau_Tienmat.EditValue)) ? txtChietkhau_Tienmat.EditValue : null,
                Reserver_Email = (!string.IsNullOrEmpty("" + txtReserver_Email.EditValue)) ? txtReserver_Email.EditValue : null,
                Thanhtoantruoc = (!string.IsNullOrEmpty("" + chkThanhtoantruoc.EditValue)) ? chkThanhtoantruoc.Checked : false,
                Ngay_Chungtu = dtNgay_Chungtu.DateTime,
                So_Chungtu = txtSo_Chungtu.EditValue,
                Id_Nhansu_Ctu = lookUpEdit_Nhansu_Ctu.EditValue,
                Ghichu = (!string.IsNullOrEmpty("" + memGhichu.EditValue)) ? memGhichu.EditValue : null,
                Id_Cuahang_Ban = Current_Id_Cuahang_Ban,
                Guid_Reserve = Current_Guid_Reserve,
            };
        }

        public override bool PerformAdd()
        {
            Current_Guid_Reserve = System.Guid.NewGuid();
            Current_Id_Reserve = -1;
            ResetText();
            this.SetInformation(infoControls);
            this.DisplayInfo_Reserve_Table();
            this.FormState = GoobizFrame.Windows.Forms.FormState.Add;
            this.ChangeStatus(true);
            dtNgay_Batdau.EditValue = DateTime.Now;
            dtNgay_Ketthuc.EditValue = DateTime.Now;
            return true;
        }

        public override bool PerformEdit()
        {
            try
            {
                if (Convert.ToInt64(Current_Id_Reserve) == -1) return false;
                var dsBar_Rent_Reserve = objBarService.GetBar_Rent_Reserve_ById(Current_Id_Reserve).ToDataSet();
                var drBar_Rent_Reserve = dsBar_Rent_Reserve.Tables[0].Rows[0];
                lookUpEdit_Khachhang.EditValue = drBar_Rent_Reserve["Id_Khachhang"];
                dtNgay_Batdau.EditValue = drBar_Rent_Reserve["Ngay_Batdau"];
                dtNgay_Ketthuc.EditValue = drBar_Rent_Reserve["Ngay_Ketthuc"];
                lookUpEdit_Class.EditValue = drBar_Rent_Reserve["Id_Class"];
                txtSoluong_Phong.EditValue = drBar_Rent_Reserve["Soluong_Phong"];
                txtSoluong_Khach.EditValue = drBar_Rent_Reserve["Soluong_Khach"];
                txtReserver_Hoten.EditValue = drBar_Rent_Reserve["Reserver_Hoten"];
                txtReserver_Cmnd.EditValue = drBar_Rent_Reserve["Reserver_Cmnd"];
                txtReserver_Tel.EditValue = drBar_Rent_Reserve["Reserver_Tel"];
                txtChietkhau_Tyle.EditValue = drBar_Rent_Reserve["Chietkhau_Tyle"];
                txtChietkhau_Tienmat.EditValue = drBar_Rent_Reserve["Chietkhau_Tienmat"];
                txtReserver_Email.EditValue = drBar_Rent_Reserve["Reserver_Email"];
                chkThanhtoantruoc.EditValue = drBar_Rent_Reserve["Thanhtoantruoc"];
                dtNgay_Chungtu.EditValue = drBar_Rent_Reserve["Ngay_Chungtu"];
                txtSo_Chungtu.EditValue = drBar_Rent_Reserve["So_Chungtu"];
                lookUpEdit_Nhansu_Ctu.EditValue = drBar_Rent_Reserve["Id_Nhansu_Ctu"];
                memGhichu.EditValue = drBar_Rent_Reserve["Ghichu"];
                Current_Guid_Reserve = ("" + drBar_Rent_Reserve["Guid_Reserve"] != "")
                    ? (System.Guid)drBar_Rent_Reserve["Guid_Reserve"]
                    : System.Guid.NewGuid();

                this.SetInformation(infoControls);
                this.DisplayInfo_Reserve_Table();
                this.DisplayInfo_Reserve_Phieuthu();
                this.FormState = GoobizFrame.Windows.Forms.FormState.Edit;
                this.ChangeStatus(true);
                return true;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                return false;
            }
        }

        public override bool PerformSave()
        {
            try
            {
                bool success = false;
                GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(lookUpEdit_Khachhang, "Khách hàng");
                hashtableControls.Add(dtNgay_Batdau, "Ngày đến");
                hashtableControls.Add(dtNgay_Ketthuc, "Ngày đi");
                hashtableControls.Add(lookUpEdit_Class, "loại phòng");
                hashtableControls.Add(txtSoluong_Phong, "SL phòng");
                hashtableControls.Add(txtReserver_Hoten, "Người đặt");
                success = GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls, this);
                if (cvBar_Rent_Reserve_Table.RowCount == 0)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] { "Phòng" });
                    return false;
                }
                if (success)
                {
                    if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                        success = (bool)this.InsertObject();

                    else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                        success = (bool)this.UpdateObject();
                }
                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc, labelControl5.Text, labelControl6.Text))
                    return false;
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
            try
            {
                var dsNewPhieuthu = dsBar_Rent_Reserve_Phieuthu.GetChanges(DataRowState.Added);
                if (dsNewPhieuthu != null)
                {
                    foreach (DataRow dr in dsNewPhieuthu.Tables[0].Rows)
                        objWareService.Delete_Ware_Phieu_Thu(new WebReferences.WareService.Ware_Phieu_Thu()
                        {
                            Id_Phieu_Thu = dr["Id_Phieu_Thu"],
                        });
                }
                this.ClearErrors();
                this.FormState = GoobizFrame.Windows.Forms.FormState.View;
                DisplayInfo();
                this.ChangeStatus(false);
                return true;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                return false;
            }
        }

        public object InsertObject()
        {
            try
            {
                Ecm.WebReferences.BarService.Bar_Rent_Reserve _Bar_Rent_Reserve = GetEditValue();
                _Bar_Rent_Reserve.Id_Reserve = -1;

                object identity = objBarService.Insert_Bar_Rent_Reserve(_Bar_Rent_Reserve);
                Current_Id_Reserve = identity;
                if (identity != null)
                {
                    this.DoClickEndEdit(dgBar_Rent_Reserve_Phieuthu);
                    objBarService.Update_Bar_Rent_Reserve_Phieuthu_Collection(dsBar_Rent_Reserve_Phieuthu);

                    this.DoClickEndEdit(dgBar_Rent_Reserve_Table);
                    if (dsBar_Rent_Reserve_Table != null)
                        foreach (DataRow row in dsBar_Rent_Reserve_Table.Tables[0].Rows)
                        {
                            if (row.RowState != DataRowState.Deleted)
                                row["Id_Reserve"] = identity;
                        }
                    objBarService.Update_Bar_Rent_Reserve_Table_Collection(dsBar_Rent_Reserve_Table);
                }
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
                Ecm.WebReferences.BarService.Bar_Rent_Reserve _Bar_Rent_Reserve = GetEditValue();
                objBarService.Update_Bar_Rent_Reserve(_Bar_Rent_Reserve);
                this.DoClickEndEdit(dgBar_Rent_Reserve_Phieuthu);
                objBarService.Update_Bar_Rent_Reserve_Phieuthu_Collection(dsBar_Rent_Reserve_Phieuthu);
                this.DoClickEndEdit(dgBar_Rent_Reserve_Table);
                objBarService.Update_Bar_Rent_Reserve_Table_Collection(dsBar_Rent_Reserve_Table);
                return true;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                return false;
            }
        }

        #endregion

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

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (this.FormState != GoobizFrame.Windows.Forms.FormState.View)
                this.PerformCancel();
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.PerformSave();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.PerformCancel();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.PerformAdd();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.PerformEdit();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.PerformPrintPreview();
        }

        private void btnRoom_Add_Click(object sender, EventArgs e)
        {
            try
            {
                System.Collections.Hashtable htproperties = new System.Collections.Hashtable();
                htproperties.Add("Ngay_Batdau", dtNgay_Batdau.DateTime);
                htproperties.Add("Ngay_Ketthuc", dtNgay_Ketthuc.DateTime);
                System.Windows.Forms.Form dialog = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowExternalDialog("Ecm.Bar.dll",
                       "Ecm.Bar.Forms.Rent.Frmbar_Rent_Reserve_RoomLookup", this, null, htproperties, false);
                if (dialog == null)
                    return;
                var SelectedObject = dialog.GetType().GetProperty("SelectedRow").GetValue(dialog, null) as System.Data.DataRow;
                if (SelectedObject == null) return;
                var sdr = dsBar_Rent_Reserve_Table.Tables[0].Select(string.Format("Id_Table={0}", SelectedObject["Id_Table"]));
                if (sdr.Length == 0)
                {
                    var ndr = dsBar_Rent_Reserve_Table.Tables[0].NewRow();
                    ndr["Id_Reserve_Table"] = DateTime.Now.Ticks;
                    ndr["Id_Reserve"] = Current_Id_Reserve;
                    ndr["Id_Table"] = SelectedObject["Id_Table"];
                    ndr["Guid_Reserve"] = Current_Guid_Reserve;
                    ndr["Ma_Table"] = SelectedObject["Ma_Table"];
                    ndr["Ten_Table"] = SelectedObject["Ten_Table"];
                    ndr["Ma_Class"] = SelectedObject["Ma_Class"];
                    ndr["Dongia"] = SelectedObject["Dongia"];
                    dsBar_Rent_Reserve_Table.Tables[0].Rows.Add(ndr);
                    txtSoluong_Phong.EditValue = cvBar_Rent_Reserve_Table.RowCount;
                }
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        private void btnRoom_Delete_Click(object sender, EventArgs e)
        {
            if (cvBar_Rent_Reserve_Table.GetFocusedRowCellValue("Id_Table") == null)
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] { "Phòng" });
                return;
            }
            try
            {
                var sdr = dsBar_Rent_Reserve_Table.Tables[0].Select(string.Format("Id_Table={0}", cvBar_Rent_Reserve_Table.GetFocusedRowCellValue("Id_Table")));
                sdr[0].Delete();
                txtSoluong_Phong.EditValue = cvBar_Rent_Reserve_Table.RowCount;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        private void btnPthu_Add_Click(object sender, EventArgs e)
        {
            var _Frmbar_Rent_Reserve_Phieu_Thu = new Frmbar_Rent_Reserve_Phieu_Thu();
            _Frmbar_Rent_Reserve_Phieu_Thu.barSystem.Visible = false;
            _Frmbar_Rent_Reserve_Phieu_Thu.Icon = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetProductIcon();
            _Frmbar_Rent_Reserve_Phieu_Thu.WindowState = System.Windows.Forms.FormWindowState.Normal;

            _Frmbar_Rent_Reserve_Phieu_Thu.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            _Frmbar_Rent_Reserve_Phieu_Thu.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            _Frmbar_Rent_Reserve_Phieu_Thu.ChangeFormState(GoobizFrame.Windows.Forms.FormState.Add);
            _Frmbar_Rent_Reserve_Phieu_Thu.PerformAdd();
            _Frmbar_Rent_Reserve_Phieu_Thu.ShowDialog();

            var SelectedObject = _Frmbar_Rent_Reserve_Phieu_Thu.GetType().GetProperty("SelectedWare_Phieu_Thu").GetValue(_Frmbar_Rent_Reserve_Phieu_Thu, null)
                as Ecm.WebReferences.WareService.Ware_Phieu_Thu;

            if (SelectedObject != null)
            {
                var ndr = dsBar_Rent_Reserve_Phieuthu.Tables[0].NewRow();
                ndr["Id_Reserve_Phieuthu"] = DateTime.Now.Ticks;
                ndr["Guid_Reserve"] = Current_Guid_Reserve;
                ndr["Id_Phieu_Thu"] = SelectedObject.Id_Phieu_Thu;
                ndr["Id_Reserve"] = Current_Id_Reserve;
                ndr["Sochungtu"] = SelectedObject.Sochungtu;
                ndr["Ngay_Chungtu"] = SelectedObject.Ngay_Chungtu;
                ndr["Lydo"] = SelectedObject.Lydo;
                ndr["Sotien"] = SelectedObject.Sotien;
                ndr["Id_Tiente"] = SelectedObject.Id_Tiente;
                dsBar_Rent_Reserve_Phieuthu.Tables[0].Rows.Add(ndr);
                this.chkThanhtoantruoc.Checked = true;
            }
        }

        private void btnPthu_Edit_Click(object sender, EventArgs e)
        {
            if ("" + gvBar_Rent_Reserve_Phieuthu.GetFocusedRowCellValue("Id_Phieu_Thu") == "")
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] { "phiếu thu" });
                return;
            }
            else
            {
                var _Frmbar_Rent_Reserve_Phieu_Thu = new Frmbar_Rent_Reserve_Phieu_Thu();
                _Frmbar_Rent_Reserve_Phieu_Thu.SelectedWare_Phieu_Thu = new WebReferences.WareService.Ware_Phieu_Thu()
                {
                    Id_Phieu_Thu = gvBar_Rent_Reserve_Phieuthu.GetFocusedRowCellValue("Id_Phieu_Thu"),
                    Chungtu_Goc = gvBar_Rent_Reserve_Phieuthu.GetFocusedRowCellValue("Chungtu_Goc"),
                    Id_Tiente = gvBar_Rent_Reserve_Phieuthu.GetFocusedRowCellValue("Id_Tiente"),
                    Lydo = gvBar_Rent_Reserve_Phieuthu.GetFocusedRowCellValue("Lydo"),
                    Ma_Doituong = gvBar_Rent_Reserve_Phieuthu.GetFocusedRowCellValue("Ma_Doituong"),
                    Ma_Kho_Hanghoa = gvBar_Rent_Reserve_Phieuthu.GetFocusedRowCellValue("Ma_Kho_Hanghoa"),
                    Ngay_Chungtu = gvBar_Rent_Reserve_Phieuthu.GetFocusedRowCellValue("Ngay_Chungtu"),
                    Nguoi_Nop = gvBar_Rent_Reserve_Phieuthu.GetFocusedRowCellValue("Nguoi_Nop"),
                    Sochungtu = gvBar_Rent_Reserve_Phieuthu.GetFocusedRowCellValue("Sochungtu"),
                    Sotien = gvBar_Rent_Reserve_Phieuthu.GetFocusedRowCellValue("Sotien"),
                    Sotien_Quydoi = gvBar_Rent_Reserve_Phieuthu.GetFocusedRowCellValue("Sotien_Quydoi"),
                    Tygia = gvBar_Rent_Reserve_Phieuthu.GetFocusedRowCellValue("Tygia"),
                };
                _Frmbar_Rent_Reserve_Phieu_Thu.barSystem.Visible = false;
                _Frmbar_Rent_Reserve_Phieu_Thu.Icon = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetProductIcon();
                _Frmbar_Rent_Reserve_Phieu_Thu.WindowState = System.Windows.Forms.FormWindowState.Normal;
                _Frmbar_Rent_Reserve_Phieu_Thu.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                _Frmbar_Rent_Reserve_Phieu_Thu.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                //_Frmbar_Rent_Reserve_Phieu_Thu.ChangeFormState(GoobizFrame.Windows.Forms.FormState.Edit);
                _Frmbar_Rent_Reserve_Phieu_Thu.PerformEdit();
                _Frmbar_Rent_Reserve_Phieu_Thu.ShowDialog();
                dsBar_Rent_Reserve_Phieuthu = objBarService.Get_All_Bar_Rent_Reserve_Phieuthu(Current_Guid_Reserve).ToDataSet();
                dgBar_Rent_Reserve_Phieuthu.DataSource = dsBar_Rent_Reserve_Phieuthu.Tables[0];
                //var SelectedObject = _Frmbar_Rent_Reserve_Phieu_Thu.GetType().GetProperty("SelectedWare_Phieu_Thu").GetValue(_Frmbar_Rent_Reserve_Phieu_Thu, null)
                //as Ecm.WebReferences.WareService.Ware_Phieu_Thu;

                //if (SelectedObject != null)
                //{
                //    gvBar_Rent_Reserve_Phieuthu.SetFocusedRowCellValue("Lydo", SelectedObject.Lydo);
                //    gvBar_Rent_Reserve_Phieuthu.SetFocusedRowCellValue("Sotien", SelectedObject.Sotien);
                //    gvBar_Rent_Reserve_Phieuthu.SetFocusedRowCellValue("Id_Tiente", SelectedObject.Id_Tiente);
                //}
            }
        }

        private void lookUpEdit_Khachhang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus
                && FormState != GoobizFrame.Windows.Forms.FormState.View)
            {
                Ecm.MasterTables.Forms.Ware.Frmware_Dm_Khachhang_Add frmKhachhang = new MasterTables.Forms.Ware.Frmware_Dm_Khachhang_Add();
                frmKhachhang.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                frmKhachhang.ShowDialog();
                lookUpEdit_Khachhang.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet().Tables[0];
                if (frmKhachhang.SelectedWare_Dm_Khachhang.Id_Khachhang != null)
                    lookUpEdit_Khachhang.EditValue = frmKhachhang.SelectedWare_Dm_Khachhang.Id_Khachhang;
            }
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete
                && FormState != GoobizFrame.Windows.Forms.FormState.View)
            {
                lookUpEdit_Khachhang.EditValue = null;
            }
        }

        private void cvBar_Rent_Reserve_Table_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //highlight
            var Id_Reserve_Table = cvBar_Rent_Reserve_Table.GetFocusedRowCellValue("Id_Reserve_Table");
            if (Id_Reserve_Table == null) return;
            GoobizFrame.Windows.MdiUtils.ThemeSettings.MakeConditionForSelectedCard(cvBar_Rent_Reserve_Table, "Id_Reserve_Table", Id_Reserve_Table);
        }

        private void btnPthu_Delete_Click(object sender, EventArgs e)
        {
            if ("" + gvBar_Rent_Reserve_Phieuthu.GetFocusedRowCellValue("Id_Phieu_Thu") == "")
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] { "phiếu thu" });
                return;
            }
            else
            if (GoobizFrame.Windows.Forms.UserMessage.Show("SYS_CONFIRM_BFDELETE", new string[]  {"Phiếu thu"}) == DialogResult.Yes)
            {
                Ecm.WebReferences.WareService.Ware_Phieu_Thu phieuthu = new WebReferences.WareService.Ware_Phieu_Thu();
                phieuthu.Id_Phieu_Thu = gvBar_Rent_Reserve_Phieuthu.GetFocusedRowCellValue("Id_Phieu_Thu");
                objWareService.Delete_Ware_Phieu_Thu(phieuthu);

                dsBar_Rent_Reserve_Phieuthu = objBarService.Get_All_Bar_Rent_Reserve_Phieuthu(Current_Guid_Reserve).ToDataSet();
                dgBar_Rent_Reserve_Phieuthu.DataSource = dsBar_Rent_Reserve_Phieuthu.Tables[0];
                chkThanhtoantruoc.Checked = false;
            }
        }

        private void lookUpEdit_Class_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus
                 && FormState != GoobizFrame.Windows.Forms.FormState.View)
            {
                Ecm.MasterTables.Forms.Ware.Frmware_Dm_Cuahang_Ban_Add frmCuahang = new MasterTables.Forms.Ware.Frmware_Dm_Cuahang_Ban_Add();
                frmCuahang.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                frmCuahang.ShowDialog();
                if (frmCuahang.ware_Dm_Cuahang_Ban != null)
                    lookUpEdit_Class.EditValue = frmCuahang.ware_Dm_Cuahang_Ban.Id_Cuahang_Ban;
            }
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete
                && FormState != GoobizFrame.Windows.Forms.FormState.View)
            {
                lookUpEdit_Class.EditValue = null;
            }
        }

    }
}
