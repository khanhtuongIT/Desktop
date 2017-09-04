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
    public partial class Frmbar_Rent_Checkin_Info : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        Ecm.WebReferences.Classes.BarService objBarService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.BarService>();
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();

        private System.Diagnostics.Process _posk = null;
        private GoobizFrame.Windows.Public.OrderHashtable infoControls = new GoobizFrame.Windows.Public.OrderHashtable();

        DataSet dsBar_Rent_Checkin_Table;
        DataSet dsBar_Rent_Checkin_Khachhang;
        DataSet dsBar_Rent_Checkin_Phieuthu;
        DataSet dsBar_Dm_Table_Facility;
        DataSet dsBar_Order_Checkin;

        private Guid guid_checkin;
        public Guid Current_Guid_Checkin { get { return guid_checkin; } set { guid_checkin = value; } }
        object Current_Id_Khuvuc = null;
        private object id_checkin;
        public object Current_Id_Checkin { get { return id_checkin; } set { id_checkin = value; } }

        private object id_cuahang_ban;
        public object Current_Id_Cuahang_Ban
        {
            get
            {
                id_cuahang_ban = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocation("Id_Cuahang_Ban");
                return id_cuahang_ban;
            }
        }

        public Frmbar_Rent_Checkin_Info()
        {
            InitializeComponent();
            DisplayInfo();
            ChangeFormState(GoobizFrame.Windows.Forms.FormState.View);
            this.AfterChangeFormState += new FormStateEventHandler(Frmbar_Rent_Checkin_Info_AfterChangeFormState);
            infoControls.Add(lookUpEdit_Khachhang, "Khách hàng yêu cầu nhập");
            infoControls.Add(dtNgay_Batdau, "Ngày đến  yêu cầu nhập");
            infoControls.Add(lookUpEdit_Class, "loại phòng  yêu cầu nhập");
            infoControls.Add(txtSoluong_Phong, "SL phòng  yêu cầu nhập");
            infoControls.Add(txtCheckin_Hoten, "Người đặt  yêu cầu nhập");
        }

        void Frmbar_Rent_Checkin_Info_AfterChangeFormState(object sender, FormStateEventArgs e)
        {
            switch (e.NewFormState)
            {
                case GoobizFrame.Windows.Forms.FormState.Add:
                    this.btnReseved.Enabled = true;
                    this.btnAdd.Enabled = false;
                    this.btnEdit.Enabled = false;
                    this.btnOrder.Enabled = true;
                    this.btnAdd_Khachhang.Enabled = true;
                    this.btn_DeleteKhachhang.Enabled = true;
                    this.btn_Details_Khachhang.Enabled = false;
                    this.btnSave.Enabled = true;
                    this.btnCancel.Enabled = true;
                    this.btnCheckout.Enabled = false;
                    this.btnPrint.Enabled = false;
                    this.btnExit.Enabled = false;
                    this.btnRoom_Add.Enabled = true;
                    this.btnRoom_Delete.Enabled = true;
                    this.btnUndo.Enabled = true;
                    break;
                case GoobizFrame.Windows.Forms.FormState.Edit:
                    this.btnReseved.Enabled = false;
                    this.btnAdd.Enabled = false;
                    this.btnEdit.Enabled = false;
                    this.btnOrder.Enabled = true;
                    this.btnAdd_Khachhang.Enabled = true;
                    this.btn_DeleteKhachhang.Enabled = true;
                    this.btn_Details_Khachhang.Enabled = false;
                    this.btnSave.Enabled = true;
                    this.btnCancel.Enabled = true;
                    this.btnCheckout.Enabled = false;
                    this.btnPrint.Enabled = false;
                    this.btnExit.Enabled = false;
                    this.btnRoom_Add.Enabled = true;
                    this.btnRoom_Delete.Enabled = true;
                    this.btnUndo.Enabled = true;
                    break;

                case GoobizFrame.Windows.Forms.FormState.View:
                    this.btnReseved.Enabled = false;
                    this.btnAdd_Khachhang.Enabled = false;
                    this.btn_DeleteKhachhang.Enabled = false;
                    this.btnSave.Enabled = false;
                    this.btnCancel.Enabled = false;
                    this.btnRoom_Add.Enabled = false;
                    this.btnRoom_Delete.Enabled = false;
                    this.btnUndo.Enabled = false;
                    this.btnCheckout.Enabled = true;
                    this.btnAdd.Enabled = true;
                    this.btnEdit.Enabled = true;
                    this.btnOrder.Enabled = false;
                    this.btn_Details_Khachhang.Enabled = true;
                    this.btnPrint.Enabled = true;
                    this.btnExit.Enabled = true;
                    break;
            }
        }

        void DisplayInfo_Checkin_Table()
        {
            if (Current_Guid_Checkin != null)
            {
                dsBar_Rent_Checkin_Table = objBarService.Get_All_Bar_Rent_Checkin_Table(Current_Guid_Checkin).ToDataSet();
                dgBar_Rent_Checkin_Table.DataSource = dsBar_Rent_Checkin_Table.Tables[0];
            }
        }

        void DisplayInfo_Checkin_Phieuthu()
        {
            if (Current_Guid_Checkin != null)
            {
                dsBar_Rent_Checkin_Phieuthu = objBarService.Get_All_Bar_Rent_Checkin_Phieuthu(Current_Guid_Checkin).ToDataSet();
                dgBar_Rent_Checkin_Phieuthu.DataSource = dsBar_Rent_Checkin_Phieuthu.Tables[0];
            }
        }

        void DisplayInfo_Checkin_Khachhang()
        {
            var Guid_Checkin_Table = cvBar_Rent_Checkin_Table.GetFocusedRowCellValue("Guid_Checkin_Table");
            if ("" + Guid_Checkin_Table == "") return;
            dsBar_Rent_Checkin_Khachhang = objBarService.Bar_Rent_Checkin_Khachhang_SelectByGuid_Checkin_Table(Guid_Checkin_Table).ToDataSet();
            dsBar_Rent_Checkin_Khachhang.Tables[0].TableName = Guid_Checkin_Table.ToString();
            dgware_Dm_Khachhang.DataSource = dsBar_Rent_Checkin_Khachhang.Tables[Guid_Checkin_Table.ToString()];
            gvDm_Khachhang.BestFitColumns();
        }

        private void DisplayInfo_Table_Facility()
        {
            if ("" + cvBar_Rent_Checkin_Table.GetFocusedRowCellValue("Id_Table") != "")
            {
                dsBar_Dm_Table_Facility = objMasterService.Get_All_Bar_Dm_Table_Facility_Collection(cvBar_Rent_Checkin_Table.GetFocusedRowCellValue("Id_Table")).ToDataSet();
                dgDm_Table_Facility.DataSource = dsBar_Dm_Table_Facility.Tables[0];
                gvDm_Table_Facility.BestFitColumns();
            }
            else
                dgDm_Table_Facility.DataSource = null;
        }

        private void DisplayInfo_Order()
        {
            if ("" + cvBar_Rent_Checkin_Table.GetFocusedRowCellValue("Id_Checkin_Table") != "")
            {
                dsBar_Order_Checkin = objBarService.Get_Bar_Rent_Checkin_table_Hanghoa_By_Checkin_Table(cvBar_Rent_Checkin_Table.GetFocusedRowCellValue("Id_Checkin_Table")).ToDataSet();
                dgbar_Table_Order.DataSource = dsBar_Order_Checkin.Tables[0];
                gvbar_Table_Order.BestFitColumns();
            }
            else
                dgbar_Table_Order.DataSource = null;
        }

        #region override methods of FormUpdateWithToolbar

        public override void DisplayInfo()
        {
            lookUpEdit_Class.Properties.DataSource = objMasterService.Get_All_Bar_Dm_Class().ToDataSet().Tables[0];
            lookUpEdit_Khachhang.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet().Tables[0];
            lookUpEdit_Nhansu_Ctu.Properties.DataSource = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet().Tables[0];
            gridLookUpEdit_Tiente.DataSource = objMasterService.Get_All_Ware_Dm_Tiente().ToDataSet().Tables[0];
            lookUpEdit_Facility.DataSource = objMasterService.Get_All_Bar_Dm_Facility().ToDataSet().Tables[0];
            lookUpEdit_RentLevel.Properties.DataSource = objMasterService.Get_All_Bar_Dm_Rentlevel_Collection().ToDataSet().Tables[0];
            gridLookUp_Hanghoa_Ban_Chitiet.DataSource = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet().Tables[0];
            DisplayInfo_Checkin_Phieuthu();
            this.DisplayInfo_Checkin_Table();
            DisplayInfo_Checkin_Khachhang();
            cvBar_Rent_Checkin_Table_FocusedRowChanged(null, null);
            base.DisplayInfo();
        }

        public override void ChangeStatus(bool editTable)
        {
            lookUpEdit_Khachhang.Properties.ReadOnly = !editTable;
            lookUpEdit_RentLevel.Properties.ReadOnly = !editTable;
            dtNgay_Batdau.Properties.ReadOnly = !editTable;
            dtNgay_Ketthuc.Properties.ReadOnly = !editTable;
            dtNgay_Batdau_Table.Properties.ReadOnly = !editTable;
            dtNgay_Ketthuc_Table.Properties.ReadOnly = !editTable;
            lookUpEdit_Class.Properties.ReadOnly = !editTable;
            //txtSoluong_Phong.Properties.ReadOnly = !editTable;
            //txtSoluong_Khach.Properties.ReadOnly = !editTable;
            txtCheckin_Hoten.Properties.ReadOnly = !editTable;
            txtCheckin_Cmnd.Properties.ReadOnly = !editTable;
            txtCheckin_Tel.Properties.ReadOnly = !editTable;
            txtChietkhau_Tyle.Properties.ReadOnly = !editTable;
            txtChietkhau_Tienmat.Properties.ReadOnly = !editTable;
            txtCheckin_Email.Properties.ReadOnly = !editTable;
            memGhichu.Properties.ReadOnly = !editTable;
            gvbar_Table_Order.OptionsBehavior.ReadOnly = !editTable;
        }

        public override void ResetText()
        {
            lookUpEdit_Khachhang.EditValue = null;
            lookUpEdit_RentLevel.EditValue = null;
            dtNgay_Batdau.EditValue = null;
            dtNgay_Ketthuc.EditValue = null;
            dtNgay_Batdau_Table.EditValue = null;
            dtNgay_Ketthuc_Table.EditValue = null;
            lookUpEdit_Class.EditValue = null;
            txtSoluong_Phong.EditValue = 0;
            txtSoluong_Khach.EditValue = 0;
            txtCheckin_Hoten.EditValue = null;
            txtCheckin_Cmnd.EditValue = null;
            txtCheckin_Tel.EditValue = null;
            txtChietkhau_Tyle.EditValue = null;
            txtChietkhau_Tienmat.EditValue = null;
            txtCheckin_Email.EditValue = null;
            chkThanhtoantruoc.EditValue = null;
            chkPb_Reserved.EditValue = null;
            dtNgay_Chungtu.EditValue = DateTime.Now;
            txtSo_Chungtu.Text = "" + objBarService.GetNew_Sochungtu("bar_rent_checkin", "So_Chungtu", "IN");
            lookUpEdit_Nhansu_Ctu.EditValue = Convert.ToInt64(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu()); ;
            memGhichu.EditValue = null;
            dgBar_Rent_Checkin_Phieuthu.DataSource = null;
            dgBar_Rent_Checkin_Table.DataSource = null;
            dgware_Dm_Khachhang.DataSource = null;
            dgDm_Table_Facility.DataSource = null;
        }

        public Ecm.WebReferences.BarService.Bar_Rent_Checkin GetEditValue()
        {
            return new Ecm.WebReferences.BarService.Bar_Rent_Checkin()
            {
                Id_Checkin = Current_Id_Checkin,
                Id_Khachhang = lookUpEdit_Khachhang.EditValue,
                Id_Rentlevel = lookUpEdit_RentLevel.EditValue,
                Ngay_Batdau = (!string.IsNullOrEmpty("" + dtNgay_Batdau.EditValue)) ? dtNgay_Batdau.EditValue : null,
                Ngay_Ketthuc = (!string.IsNullOrEmpty("" + dtNgay_Ketthuc.EditValue)) ? dtNgay_Ketthuc.EditValue : null,
                Id_Class = (!string.IsNullOrEmpty("" + lookUpEdit_Class.EditValue)) ? lookUpEdit_Class.EditValue : null,
                Soluong_Phong = (!string.IsNullOrEmpty("" + txtSoluong_Phong.EditValue)) ? txtSoluong_Phong.EditValue : null,
                Soluong_Khach = (!string.IsNullOrEmpty("" + txtSoluong_Khach.EditValue)) ? txtSoluong_Khach.EditValue : null,
                Checkin_Hoten = (!string.IsNullOrEmpty("" + txtCheckin_Hoten.EditValue)) ? txtCheckin_Hoten.EditValue : null,
                Checkin_Cmnd = (!string.IsNullOrEmpty("" + txtCheckin_Cmnd.EditValue)) ? txtCheckin_Cmnd.EditValue : null,
                Checkin_Tel = (!string.IsNullOrEmpty("" + txtCheckin_Tel.EditValue)) ? txtCheckin_Tel.EditValue : null,
                Chietkhau_Tyle = (!string.IsNullOrEmpty("" + txtChietkhau_Tyle.EditValue)) ? txtChietkhau_Tyle.EditValue : null,
                Chietkhau_Tienmat = (!string.IsNullOrEmpty("" + txtChietkhau_Tienmat.EditValue)) ? txtChietkhau_Tienmat.EditValue : null,
                Checkin_Email = (!string.IsNullOrEmpty("" + txtCheckin_Email.EditValue)) ? txtCheckin_Email.EditValue : null,
                Thanhtoantruoc = (!string.IsNullOrEmpty("" + chkThanhtoantruoc.EditValue)) ? chkThanhtoantruoc.Checked : false,
                Ngay_Chungtu = dtNgay_Chungtu.DateTime,
                So_Chungtu = txtSo_Chungtu.EditValue,
                Id_Nhansu_Ctu = lookUpEdit_Nhansu_Ctu.EditValue,
                Ghichu = (!string.IsNullOrEmpty("" + memGhichu.EditValue)) ? memGhichu.EditValue : null,
                Id_Cuahang_Ban = Current_Id_Cuahang_Ban,
                Guid_Checkin = Current_Guid_Checkin,
            };
        }

        public override bool PerformAdd()
        {
            Current_Guid_Checkin = System.Guid.NewGuid();
            Current_Id_Checkin = -1;
            ResetText();
            this.SetInformation(infoControls);
            this.DisplayInfo_Checkin_Table();
            this.FormState = GoobizFrame.Windows.Forms.FormState.Add;
            this.ChangeStatus(true);
            dtNgay_Batdau.EditValue = DateTime.Now;
            return true;
        }

        public override bool PerformEdit()
        {
            try
            {
                if (Convert.ToInt32(Current_Id_Checkin) == -1) return false;
                var dsBar_Rent_Checkin = objBarService.GetBar_Rent_Checkin_ById(Current_Id_Checkin).ToDataSet();

                var drBar_Rent_Checkin = dsBar_Rent_Checkin.Tables[0].Rows[0];
                lookUpEdit_Khachhang.EditValue = drBar_Rent_Checkin["Id_Khachhang"];
                lookUpEdit_RentLevel.EditValue = drBar_Rent_Checkin["Id_Rentlevel"];
                dtNgay_Batdau.EditValue = drBar_Rent_Checkin["Ngay_Batdau"];
                dtNgay_Ketthuc.EditValue = drBar_Rent_Checkin["Ngay_Ketthuc"];
                lookUpEdit_Class.EditValue = drBar_Rent_Checkin["Id_Class"];
                txtCheckin_Hoten.EditValue = drBar_Rent_Checkin["Checkin_Hoten"];
                txtCheckin_Cmnd.EditValue = drBar_Rent_Checkin["Checkin_Cmnd"];
                txtCheckin_Tel.EditValue = drBar_Rent_Checkin["Checkin_Tel"];
                txtChietkhau_Tyle.EditValue = drBar_Rent_Checkin["Chietkhau_Tyle"];
                txtChietkhau_Tienmat.EditValue = drBar_Rent_Checkin["Chietkhau_Tienmat"];
                txtCheckin_Email.EditValue = drBar_Rent_Checkin["Checkin_Email"];
                chkThanhtoantruoc.EditValue = drBar_Rent_Checkin["Thanhtoantruoc"];
                chkPb_Reserved.Checked = Convert.ToBoolean(drBar_Rent_Checkin["Pb_Reserve"]);
                dtNgay_Chungtu.EditValue = drBar_Rent_Checkin["Ngay_Chungtu"];
                txtSo_Chungtu.EditValue = drBar_Rent_Checkin["So_Chungtu"];
                lookUpEdit_Nhansu_Ctu.EditValue = drBar_Rent_Checkin["Id_Nhansu_Ctu"];
                memGhichu.EditValue = drBar_Rent_Checkin["Ghichu"];
                Current_Guid_Checkin = ("" + drBar_Rent_Checkin["Guid_Checkin"] != "")
                                     ? (System.Guid)drBar_Rent_Checkin["Guid_Checkin"] : System.Guid.NewGuid();
                txtSoluong_Phong.EditValue = Convert.ToInt64(drBar_Rent_Checkin["Soluong_Phong"]);
                txtSoluong_Khach.EditValue = Convert.ToInt64(drBar_Rent_Checkin["Soluong_Khach"]);
                Current_Id_Khuvuc = drBar_Rent_Checkin["Id_Khuvuc"];
                if (!chkPb_Reserved.Checked)
                    btnUndo.Visible = false;
                else
                    btnUndo.Visible = true;
                this.SetInformation(infoControls);
                this.DisplayInfo_Checkin_Table();
                this.DisplayInfo_Checkin_Phieuthu();
                DisplayInfo_Checkin_Khachhang();
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
                //hashtableControls.Add(dtNgay_Ketthuc, "Ngày đi");
                hashtableControls.Add(lookUpEdit_Class, "loại phòng");
                hashtableControls.Add(txtSoluong_Phong, "SL phòng");
                hashtableControls.Add(txtCheckin_Hoten, "Người đặt");
                hashtableControls.Add(lookUpEdit_RentLevel, labelControl17.Text);
                success = GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls, this);
                if (cvBar_Rent_Checkin_Table.RowCount == 0)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] { "Phòng" });
                    return false;
                }
                if (gvDm_Khachhang.RowCount == 0)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] { "Khách hàng" });
                    return false;
                }
                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc, labelControl5.Text, labelControl6.Text))
                    return false;
                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau_Table, dtNgay_Ketthuc_Table, labelControl18.Text, labelControl19.Text))
                    return false;
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
                    this.ChangeStatus(false);
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

        public override bool PerformPrintPreview()
        {
            if ("" + cvBar_Rent_Checkin_Table.GetFocusedRowCellValue("Id_Checkin_Table") == "")
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] { "Phòng" });
                return false;
            }
            if ("" + lookUpEdit_RentLevel.EditValue == "")
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] { labelControl19.Text });
                return false;
            }
            DataSet dsBar_Rent_Checkin_Table4Print = objBarService.Bar_Rent_Checkin_Table_SelectById_4Print(cvBar_Rent_Checkin_Table.GetFocusedRowCellValue("Id_Checkin_Table"), lookUpEdit_RentLevel.EditValue).ToDataSet();
            Ecm.Bar.DataSets.dsHdbanhang_Chitiet dsrHdbanhang_Chitiet = new Ecm.Bar.DataSets.dsHdbanhang_Chitiet();
            Ecm.Bar.Reports.rptHdbanhang_Hotel rptHdbanhang = new Ecm.Bar.Reports.rptHdbanhang_Hotel();
            GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            frmPrintPreview.Report = rptHdbanhang;
            //frmPrintPreview.Name = this.Name;
            //frmPrintPreview.EnablePrintPreview = this.EnablePrintPreview;
            rptHdbanhang.DataSource = dsrHdbanhang_Chitiet;
            int i = 1;
            foreach (DataRow dr in dsBar_Rent_Checkin_Table4Print.Tables[0].Rows)
            {
                if (dr.RowState != DataRowState.Deleted)
                {
                    DataRow drnew = dsrHdbanhang_Chitiet.Tables["Hdbanhang_Chitiet"].NewRow();
                    foreach (DataColumn dc in dsBar_Rent_Checkin_Table4Print.Tables[0].Columns)
                    {
                        try
                        {
                            if (drnew.Table.Columns.Contains(dc.ColumnName))
                                drnew[dc.ColumnName] = dr[dc.ColumnName];
                        }
                        catch (Exception ex)
                        {
                            GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                            continue;
                        }
                    }
                    drnew["Ten_Hanghoa"] = dr["Ten_Hanghoa"]; // gridLookUp_Hanghoa_Ban_Chitiet.GetDisplayText(dr["Id_Hanghoa_Ban"]);
                    drnew["Dongia_Ban"] = dr["Dongia"];
                    drnew["Thanhtien"] = dr["Thanhtien"];
                    drnew["per_dongia"] = dr["Per_Dongia"];
                    drnew["Stt"] = i++;
                    dsrHdbanhang_Chitiet.Tables["Hdbanhang_Chitiet"].Rows.Add(drnew);
                }
            }
            //add parameter values
            rptHdbanhang.tbc_Ngay.Text = "" + dtNgay_Chungtu.Text;
            rptHdbanhang.tbcSochungtu.Text = "" + txtSo_Chungtu.Text;
            rptHdbanhang.lblNhansu_Bill.Text = lookUpEdit_Nhansu_Ctu.Text;
            rptHdbanhang.lblKhachhang.Text = lookUpEdit_Khachhang.Text;

            DataSet dsOrder_Chitiet = objBarService.Get_Bar_Rent_Checkin_table_Hanghoa_By_Checkin_Table_4Print(cvBar_Rent_Checkin_Table.GetFocusedRowCellValue("Id_Checkin_Table")).ToDataSet();
            foreach (DataRow dtr in dsOrder_Chitiet.Tables[0].Rows)
            {
                dsrHdbanhang_Chitiet.Tables["Order_Chitiet"].ImportRow(dtr);
            }
            decimal thanhtien = Convert.ToDecimal("0" + dsBar_Rent_Checkin_Table4Print.Tables[0].Compute("Sum(Thanhtien)", ""));
            decimal thanhtien_order = Convert.ToDecimal("0" + dsOrder_Chitiet.Tables[0].Compute("Sum(Thanhtien)", ""));
            thanhtien += thanhtien_order;
            if ("" + cvBar_Rent_Checkin_Table.GetFocusedRowCellValue("Id_Checkin_Phieuthu") != "")
            {
                var da_thanhtoan = objBarService.Get_Bar_Rent_Checkin_Dathanhtoan_ById_Checkin(Current_Id_Checkin);
                thanhtien -= Convert.ToDecimal("0" + da_thanhtoan);
                rptHdbanhang.PageSize = new Size(800, 1400 + 100 * Convert.ToInt32(dsrHdbanhang_Chitiet.Tables["Hdbanhang_Chitiet"].Rows.Count));
                //Trừ tiền cọc 
                if (Convert.ToDecimal("0" + da_thanhtoan) > 0)
                {
                    decimal Thanhtien_TG = Convert.ToDecimal("0" +
                        dsrHdbanhang_Chitiet.Tables["Hdbanhang_Chitiet"].Rows[dsrHdbanhang_Chitiet.Tables["Hdbanhang_Chitiet"].Rows.Count - 1]["Thanhtien_TG"]);
                    Thanhtien_TG -= Convert.ToDecimal(da_thanhtoan);
                    dsrHdbanhang_Chitiet.Tables["Hdbanhang_Chitiet"].Rows[dsrHdbanhang_Chitiet.Tables["Hdbanhang_Chitiet"].Rows.Count - 1]["Thanhtien_TG"] = Thanhtien_TG;
                    rptHdbanhang.xrTable_Tien_Booking.Visible = true;
                    rptHdbanhang.lblTien_Booking.Text = string.Format("{0:#,#}", da_thanhtoan);
                }
                else
                {
                    rptHdbanhang.xrTable6.Location = new System.Drawing.Point(21, 42);
                    rptHdbanhang.xrTable4.Location = new System.Drawing.Point(21, 135);
                }
            }

            #region Set he so ctrinh - logo, ten cty

            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));
                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);
                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData});
                rptHdbanhang.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                rptHdbanhang.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                rptHdbanhang.xrPic_Logo.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }
            #endregion

            string str = GoobizFrame.Windows.HelperClasses.ReadNumber.ChangeNum2VNStr((double)thanhtien, " đồng.");
            str = str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower();
            rptHdbanhang.tbcThanhtien_Bangchu.Text = str;
            rptHdbanhang.lblTongcong.Text = String.Format("{0:n0}", Convert.ToDouble(thanhtien));
            rptHdbanhang.tbc_Ngay_Batdau.Text = dtNgay_Batdau_Table.Text;
            rptHdbanhang.tbc_Ngay_Ketthuc.Text = dtNgay_Ketthuc_Table.Text;
            rptHdbanhang.xrTableRow20.Visible = false;
            if (Convert.ToDecimal("" + dsBar_Rent_Checkin_Table4Print.Tables[0].Rows[0]["Per_Dongia"]) == 0)
                rptHdbanhang.xrTableRow_Giamgia.Visible = false; //xrTable5
            rptHdbanhang.CreateDocument();
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(rptHdbanhang);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                frmPrintPreview.Text = "" + oReportOptions.Caption;
                frmPrintPreview.printControl1.PrintingSystem = rptHdbanhang.PrintingSystem;
                frmPrintPreview.MdiParent = this.MdiParent;
                frmPrintPreview.Text = this.Text + "(Xem trang in)";
                frmPrintPreview.Show();
                frmPrintPreview.Activate();
            }
            else
            {
                var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rptHdbanhang);
                ReportPrintTool.Print();
            }
            return base.PerformPrintPreview();
        }

        public void Check_Out()
        {
            try
            {
                if (Convert.ToInt32(Current_Id_Checkin) == -1) return;
                var dsBar_Rent_Checkin = objBarService.GetBar_Rent_Checkin_ById(Current_Id_Checkin).ToDataSet();

                var drBar_Rent_Checkin = dsBar_Rent_Checkin.Tables[0].Rows[0];
                lookUpEdit_Khachhang.EditValue = drBar_Rent_Checkin["Id_Khachhang"];
                lookUpEdit_RentLevel.EditValue = drBar_Rent_Checkin["Id_Rentlevel"];
                dtNgay_Batdau.EditValue = drBar_Rent_Checkin["Ngay_Batdau"];
                dtNgay_Ketthuc.EditValue = drBar_Rent_Checkin["Ngay_Ketthuc"];
                lookUpEdit_Class.EditValue = drBar_Rent_Checkin["Id_Class"];
                txtCheckin_Hoten.EditValue = drBar_Rent_Checkin["Checkin_Hoten"];
                txtCheckin_Cmnd.EditValue = drBar_Rent_Checkin["Checkin_Cmnd"];
                txtCheckin_Tel.EditValue = drBar_Rent_Checkin["Checkin_Tel"];
                txtChietkhau_Tyle.EditValue = drBar_Rent_Checkin["Chietkhau_Tyle"];
                txtChietkhau_Tienmat.EditValue = drBar_Rent_Checkin["Chietkhau_Tienmat"];
                txtCheckin_Email.EditValue = drBar_Rent_Checkin["Checkin_Email"];
                chkThanhtoantruoc.EditValue = drBar_Rent_Checkin["Thanhtoantruoc"];
                chkPb_Reserved.Checked = Convert.ToBoolean(drBar_Rent_Checkin["Pb_Reserve"]);
                dtNgay_Chungtu.EditValue = drBar_Rent_Checkin["Ngay_Chungtu"];
                txtSo_Chungtu.EditValue = drBar_Rent_Checkin["So_Chungtu"];
                lookUpEdit_Nhansu_Ctu.EditValue = drBar_Rent_Checkin["Id_Nhansu_Ctu"];
                memGhichu.EditValue = drBar_Rent_Checkin["Ghichu"];
                Current_Guid_Checkin = ("" + drBar_Rent_Checkin["Guid_Checkin"] != "")
                                     ? (System.Guid)drBar_Rent_Checkin["Guid_Checkin"] : System.Guid.NewGuid();
                txtSoluong_Phong.EditValue = Convert.ToInt64(drBar_Rent_Checkin["Soluong_Phong"]);
                txtSoluong_Khach.EditValue = Convert.ToInt64(drBar_Rent_Checkin["Soluong_Khach"]);

                //this.SetInformation(infoControls);
                this.DisplayInfo_Checkin_Table();
                this.DisplayInfo_Checkin_Phieuthu();
                this.DisplayInfo_Checkin_Khachhang();
                //this.ChangeStatus(false);
                return;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                return;
            }
        }

        public object InsertObject()
        {
            try
            {
                Ecm.WebReferences.BarService.Bar_Rent_Checkin _Bar_Rent_Checkin = GetEditValue();
                _Bar_Rent_Checkin.Id_Reserve = -1;
                object identity = objBarService.Insert_Bar_Rent_Checkin(_Bar_Rent_Checkin);
                Current_Id_Checkin = identity;
                if (identity != null)
                {
                    this.DoClickEndEdit(dgBar_Rent_Checkin_Phieuthu);
                    if (dsBar_Rent_Checkin_Phieuthu != null)
                    {
                        foreach (DataRow row in dsBar_Rent_Checkin_Phieuthu.Tables[0].Rows)
                        {
                            if (row.RowState != DataRowState.Deleted)
                                row["Id_Checkin"] = Current_Id_Checkin;
                        }
                        objBarService.Update_Bar_Rent_Checkin_Phieuthu_Collection(dsBar_Rent_Checkin_Phieuthu);
                    }
                    this.DoClickEndEdit(dgBar_Rent_Checkin_Table);
                    if (dsBar_Rent_Checkin_Table != null)
                    {
                        foreach (DataRow row in dsBar_Rent_Checkin_Table.Tables[0].Rows)
                        {
                            if (row.RowState != DataRowState.Deleted)
                            {
                                row["Id_Checkin"] = Current_Id_Checkin;
                            }
                        }
                        objBarService.Update_Bar_Rent_Checkin_Table_Collection(dsBar_Rent_Checkin_Table);
                    }
                    this.DoClickEndEdit(dgware_Dm_Khachhang);
                    if (dsBar_Rent_Checkin_Khachhang != null)
                        objBarService.Update_Bar_Rent_Checkin_Khachhang_Collection(dsBar_Rent_Checkin_Khachhang);

                    this.DoClickEndEdit(dgbar_Table_Order);
                    if (dsBar_Order_Checkin != null)
                        objBarService.Update_Bar_Rent_Checkin_table_Hanghoa_Collection(dsBar_Order_Checkin);
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
                Ecm.WebReferences.BarService.Bar_Rent_Checkin _Bar_Rent_Checkin = GetEditValue();
                objBarService.Update_Bar_Rent_Checkin(_Bar_Rent_Checkin);

                this.DoClickEndEdit(dgBar_Rent_Checkin_Phieuthu);
                if (dsBar_Rent_Checkin_Phieuthu != null)
                    objBarService.Update_Bar_Rent_Checkin_Phieuthu_Collection(dsBar_Rent_Checkin_Phieuthu);
                this.DoClickEndEdit(dgBar_Rent_Checkin_Table);
                if (dsBar_Rent_Checkin_Table != null)
                    objBarService.Update_Bar_Rent_Checkin_Table_Collection(dsBar_Rent_Checkin_Table);
                this.DoClickEndEdit(dgware_Dm_Khachhang);
                if (dsBar_Rent_Checkin_Khachhang != null)
                    objBarService.Update_Bar_Rent_Checkin_Khachhang_Collection(dsBar_Rent_Checkin_Khachhang);

                this.DoClickEndEdit(dgbar_Table_Order);
                if (dsBar_Order_Checkin != null)
                    objBarService.Update_Bar_Rent_Checkin_table_Hanghoa_Collection(dsBar_Order_Checkin);
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
                htproperties.Add("Ngay_Ketthuc", ("" + dtNgay_Ketthuc.EditValue == "") ? dtNgay_Batdau.DateTime.AddDays(1) : dtNgay_Ketthuc.DateTime);
                System.Windows.Forms.Form dialog = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowExternalDialog("Ecm.Bar.dll",
                       "Ecm.Bar.Forms.Rent.Frmbar_Rent_Reserve_RoomLookup", this, null, htproperties, false);
                if (dialog == null)
                    return;

                var SelectedObject = dialog.GetType().GetProperty("SelectedRow").GetValue(dialog, null) as System.Data.DataRow;
                if (SelectedObject == null) return;
                var sdr = dsBar_Rent_Checkin_Table.Tables[0].Select(string.Format("Id_Table={0}", SelectedObject["Id_Table"]));
                if (sdr.Length == 0)
                {
                    var ngay_batdau = DateTime.Now;
                    var ndr = dsBar_Rent_Checkin_Table.Tables[0].NewRow();
                    ndr["Id_Checkin_Table"] = DateTime.Now.Ticks;
                    ndr["Id_Checkin"] = Current_Id_Checkin;
                    ndr["Id_Table"] = SelectedObject["Id_Table"];
                    ndr["Guid_Checkin"] = Current_Guid_Checkin;
                    ndr["Ma_Table"] = SelectedObject["Ma_Table"];
                    ndr["Ten_Table"] = SelectedObject["Ten_Table"];
                    ndr["Ma_Class"] = SelectedObject["Ma_Class"];
                    ndr["Dongia"] = SelectedObject["Dongia"];
                    ndr["Ngay_Batdau"] = ngay_batdau;
                    ndr["Ngay_Ketthuc"] = (dtNgay_Ketthuc.EditValue == null) ? DBNull.Value : dtNgay_Ketthuc.EditValue;
                    ndr["Guid_Checkin_Table"] = System.Guid.NewGuid();
                    dsBar_Rent_Checkin_Table.Tables[0].Rows.Add(ndr);
                    txtSoluong_Phong.EditValue = cvBar_Rent_Checkin_Table.RowCount;
                    dtNgay_Batdau_Table.EditValue = ngay_batdau;
                }
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        private void btnRoom_Delete_Click(object sender, EventArgs e)
        {
            if (cvBar_Rent_Checkin_Table.GetFocusedRowCellValue("Id_Table") == null)
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] { "Phòng" });
                return;
            }
            if (!Check_Checkout())
                return;
            try
            {
                var sdr = dsBar_Rent_Checkin_Table.Tables[0].Select(string.Format("Id_Table={0}", cvBar_Rent_Checkin_Table.GetFocusedRowCellValue("Id_Table")));
                sdr[0].Delete();
                txtSoluong_Phong.EditValue = cvBar_Rent_Checkin_Table.RowCount;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        private void btnPthu_Add_Click(object sender, EventArgs e)
        {
            var _Frmbar_Rent_Checkin_Phieu_Thu = new Frmbar_Rent_Reserve_Phieu_Thu();
            _Frmbar_Rent_Checkin_Phieu_Thu.barSystem.Visible = false;
            _Frmbar_Rent_Checkin_Phieu_Thu.Icon = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetProductIcon();
            _Frmbar_Rent_Checkin_Phieu_Thu.WindowState = System.Windows.Forms.FormWindowState.Normal;
            _Frmbar_Rent_Checkin_Phieu_Thu.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            _Frmbar_Rent_Checkin_Phieu_Thu.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            _Frmbar_Rent_Checkin_Phieu_Thu.ChangeFormState(GoobizFrame.Windows.Forms.FormState.Add);
            _Frmbar_Rent_Checkin_Phieu_Thu.PerformAdd();
            _Frmbar_Rent_Checkin_Phieu_Thu.ShowDialog();
            var SelectedObject = _Frmbar_Rent_Checkin_Phieu_Thu.GetType().GetProperty("SelectedWare_Phieu_Thu").GetValue(_Frmbar_Rent_Checkin_Phieu_Thu, null)
                as Ecm.WebReferences.WareService.Ware_Phieu_Thu;

            if (SelectedObject != null)
            {
                var ndr = dsBar_Rent_Checkin_Phieuthu.Tables[0].NewRow();
                ndr["Id_Checkin_Phieuthu"] = DateTime.Now.Ticks;
                ndr["Guid_Checkin"] = Current_Guid_Checkin;
                ndr["Id_Phieu_Thu"] = SelectedObject.Id_Phieu_Thu;
                ndr["Id_Checkin"] = Current_Id_Checkin;
                ndr["Sochungtu"] = SelectedObject.Sochungtu;
                ndr["Ngay_Chungtu"] = SelectedObject.Ngay_Chungtu;
                ndr["Lydo"] = SelectedObject.Lydo;
                ndr["Sotien"] = SelectedObject.Sotien;
                ndr["Id_Tiente"] = SelectedObject.Id_Tiente;
                dsBar_Rent_Checkin_Phieuthu.Tables[0].Rows.Add(ndr);
            }
        }

        private void btnPthu_Edit_Click(object sender, EventArgs e)
        {
            if ("" + gvBar_Rent_Checkin_Phieuthu.GetFocusedRowCellValue("Id_Phieu_Thu") != "")
            {
                var _Frmbar_Rent_Reserve_Phieu_Thu = new Frmbar_Rent_Reserve_Phieu_Thu();
                _Frmbar_Rent_Reserve_Phieu_Thu.SelectedWare_Phieu_Thu = new WebReferences.WareService.Ware_Phieu_Thu()
                {
                    Id_Phieu_Thu = gvBar_Rent_Checkin_Phieuthu.GetFocusedRowCellValue("Id_Phieu_Thu"),
                    Chungtu_Goc = gvBar_Rent_Checkin_Phieuthu.GetFocusedRowCellValue("Chungtu_Goc"),
                    Id_Tiente = gvBar_Rent_Checkin_Phieuthu.GetFocusedRowCellValue("Id_Tiente"),
                    Lydo = gvBar_Rent_Checkin_Phieuthu.GetFocusedRowCellValue("Lydo"),
                    Ma_Doituong = gvBar_Rent_Checkin_Phieuthu.GetFocusedRowCellValue("Ma_Doituong"),
                    Ma_Kho_Hanghoa = gvBar_Rent_Checkin_Phieuthu.GetFocusedRowCellValue("Ma_Kho_Hanghoa"),
                    Ngay_Chungtu = gvBar_Rent_Checkin_Phieuthu.GetFocusedRowCellValue("Ngay_Chungtu"),
                    Nguoi_Nop = gvBar_Rent_Checkin_Phieuthu.GetFocusedRowCellValue("Nguoi_Nop"),
                    Sochungtu = gvBar_Rent_Checkin_Phieuthu.GetFocusedRowCellValue("Sochungtu"),
                };
                _Frmbar_Rent_Reserve_Phieu_Thu.barSystem.Visible = false;
                _Frmbar_Rent_Reserve_Phieu_Thu.Icon = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetProductIcon();
                _Frmbar_Rent_Reserve_Phieu_Thu.WindowState = System.Windows.Forms.FormWindowState.Normal;
                _Frmbar_Rent_Reserve_Phieu_Thu.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                _Frmbar_Rent_Reserve_Phieu_Thu.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                _Frmbar_Rent_Reserve_Phieu_Thu.ChangeFormState(GoobizFrame.Windows.Forms.FormState.Edit);
                _Frmbar_Rent_Reserve_Phieu_Thu.PerformEdit();
                _Frmbar_Rent_Reserve_Phieu_Thu.ShowDialog();
                var SelectedObject = _Frmbar_Rent_Reserve_Phieu_Thu.GetType().GetProperty("SelectedWare_Phieu_Thu").GetValue(_Frmbar_Rent_Reserve_Phieu_Thu, null)
                as Ecm.WebReferences.WareService.Ware_Phieu_Thu;

                if (SelectedObject != null)
                {
                    gvBar_Rent_Checkin_Phieuthu.SetFocusedRowCellValue("Lydo", SelectedObject.Lydo);
                    gvBar_Rent_Checkin_Phieuthu.SetFocusedRowCellValue("Sotien", SelectedObject.Sotien);
                    gvBar_Rent_Checkin_Phieuthu.SetFocusedRowCellValue("Id_Tiente", SelectedObject.Id_Tiente);
                }
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

        private void btnAdd_Khachhang_Click(object sender, EventArgs e)
        {
            if (!Check_Checkout())
                return;
            var Guid_Checkin_Table = cvBar_Rent_Checkin_Table.GetFocusedRowCellValue("Guid_Checkin_Table");
            if ("" + Guid_Checkin_Table == "")
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] { "phòng" });
                return;
            }
            Ecm.MasterTables.Forms.Ware.Frmware_Dm_Khachhang_Add frmKhachhang = new MasterTables.Forms.Ware.Frmware_Dm_Khachhang_Add();
            frmKhachhang.filter = true;
            frmKhachhang.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            frmKhachhang.ShowDialog();
            if (frmKhachhang.SelectedWare_Dm_Khachhang.Id_Khachhang != null)
            {
                DataTable dtbTmp = objBarService.Bar_Rent_Checkin_Khachhang_SelectByGuid_Checkin_Table(Guid_Checkin_Table).ToDataSet().Tables[0];
                dtbTmp.TableName = Guid_Checkin_Table.ToString();
                if (dsBar_Rent_Checkin_Khachhang == null)
                    dsBar_Rent_Checkin_Khachhang = objBarService.Bar_Rent_Checkin_Khachhang_SelectByGuid_Checkin_Table(Guid_Checkin_Table).ToDataSet();
                if (!dsBar_Rent_Checkin_Khachhang.Tables.Contains(Guid_Checkin_Table.ToString()))
                    dsBar_Rent_Checkin_Khachhang.Tables.Add(dtbTmp.Copy());

                var ndr = dsBar_Rent_Checkin_Khachhang.Tables["" + dtbTmp.TableName].NewRow();
                ndr["Guid_Checkin"] = Current_Guid_Checkin;
                ndr["Guid_Checkin_Table"] = cvBar_Rent_Checkin_Table.GetFocusedRowCellValue("Guid_Checkin_Table");
                ndr["Id_Khachhang"] = frmKhachhang.SelectedWare_Dm_Khachhang.Id_Khachhang;
                ndr["Ma_Khachhang"] = frmKhachhang.SelectedWare_Dm_Khachhang.Ma_Khachhang;
                ndr["Ten_Khachhang"] = frmKhachhang.SelectedWare_Dm_Khachhang.Ten_Khachhang;
                ndr["Diachi_Khachhang"] = frmKhachhang.SelectedWare_Dm_Khachhang.Diachi_Khachhang;
                ndr["Cmnd"] = frmKhachhang.SelectedWare_Dm_Khachhang.Cmnd;
                ndr["Dienthoai"] = frmKhachhang.SelectedWare_Dm_Khachhang.Dienthoai;
                ndr["Email"] = frmKhachhang.SelectedWare_Dm_Khachhang.Email;
                dsBar_Rent_Checkin_Khachhang.Tables[Guid_Checkin_Table.ToString()].Rows.Add(ndr);
                dgware_Dm_Khachhang.DataSource = dsBar_Rent_Checkin_Khachhang.Tables[Guid_Checkin_Table.ToString()];
                txtSoluong_Khach.EditValue = Convert.ToInt64(txtSoluong_Khach.EditValue) + 1;
            }
        }

        private void btn_DeleteKhachhang_Click(object sender, EventArgs e)
        {
            if (!Check_Checkout())
                return;
            if (gvDm_Khachhang.GetFocusedRowCellValue("Id_Khachhang") == null)
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] { "Khách hàng" });
                return;
            }
            if (dsBar_Rent_Checkin_Khachhang.Tables.Count > 0
                && cvBar_Rent_Checkin_Table.GetFocusedRowCellValue("Guid_Checkin_Table").ToString() != ""
                && dsBar_Rent_Checkin_Khachhang.Tables[cvBar_Rent_Checkin_Table.GetFocusedRowCellValue("Guid_Checkin_Table").ToString()].Rows.Count > 0)
            {
                try
                {
                    var sdr = dsBar_Rent_Checkin_Khachhang.Tables[cvBar_Rent_Checkin_Table.GetFocusedRowCellValue("Guid_Checkin_Table").ToString()].Select(string.Format("Id_Khachhang={0}", gvDm_Khachhang.GetFocusedRowCellValue("Id_Khachhang")));
                    sdr[0].Delete();
                    if (Convert.ToInt64(txtSoluong_Khach.EditValue) > 0)
                        txtSoluong_Khach.EditValue = Convert.ToInt64(txtSoluong_Khach.EditValue) - 1;
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                }
            }
        }

        private void btn_Details_Khachhang_Click(object sender, EventArgs e)
        {
            if (gvDm_Khachhang.GetFocusedRowCellValue("Id_Khachhang") == null)
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] { "Khách hàng" });
                return;
            }
            Ecm.MasterTables.Forms.Ware.Frmware_Dm_Khachhang_Dialog frmKhachhang = new MasterTables.Forms.Ware.Frmware_Dm_Khachhang_Dialog(gvDm_Khachhang.GetFocusedRowCellValue("Id_Khachhang"), gvDm_Khachhang.GetFocusedRowCellValue("Ma_Khachhang"));
            frmKhachhang.ShowDialog();
        }

        private void cvBar_Rent_Checkin_Table_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DisplayInfo_Table_Facility();
            DisplayInfo_Order();
            //DataBinding_Ngay(dsBar_Rent_Checkin_Table);
            var Guid_Checkin_Table = cvBar_Rent_Checkin_Table.GetFocusedRowCellValue("Guid_Checkin_Table");
            if (Guid_Checkin_Table == null) return;
            //highlight
            GoobizFrame.Windows.MdiUtils.ThemeSettings.MakeConditionForSelectedCard(cvBar_Rent_Checkin_Table, "Guid_Checkin_Table", Guid_Checkin_Table);

            if (FormState == GoobizFrame.Windows.Forms.FormState.View)
            {
                if ("" + cvBar_Rent_Checkin_Table.GetFocusedRowCellValue("Check_Out") != ""
                    && Convert.ToBoolean(cvBar_Rent_Checkin_Table.GetFocusedRowCellValue("Check_Out")))
                {
                    btnCheckout.Enabled = false;
                    btnOrder.Enabled = false;
                }
                else
                {
                    btnCheckout.Enabled = true;
                    btnOrder.Enabled = true;
                }
            }
            DataRow[] dtr = dsBar_Rent_Checkin_Table.Tables[0].Select("Guid_Checkin_Table = '" + Guid_Checkin_Table + "' ");
            if (dtr.Length > 0)
            {
                dtNgay_Batdau_Table.EditValue = dtr[0]["Ngay_Batdau"];
                dtNgay_Ketthuc_Table.EditValue = dtr[0]["Ngay_Ketthuc"];
            }
            if (dsBar_Rent_Checkin_Khachhang == null) return;
            DataTable dtbTmp = objBarService.Bar_Rent_Checkin_Khachhang_SelectByGuid_Checkin_Table(Guid_Checkin_Table).ToDataSet().Tables[0];
            dtbTmp.TableName = Guid_Checkin_Table.ToString();
            if (!dsBar_Rent_Checkin_Khachhang.Tables.Contains(Guid_Checkin_Table.ToString()))
                dsBar_Rent_Checkin_Khachhang.Tables.Add(dtbTmp.Copy());
            dgware_Dm_Khachhang.DataSource = dsBar_Rent_Checkin_Khachhang.Tables[Guid_Checkin_Table.ToString()];
            gvDm_Khachhang.BestFitColumns();
        }

        private void lookUpEdit_RentLevel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus
                && FormState != GoobizFrame.Windows.Forms.FormState.View)
            {
                var dialog = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowExternalDialog("Ecm.MasterTables.dll",
                                                            "Ecm.MasterTables.Forms.Bar.Frmbar_Dm_Rentlevel", this, null, null, false);
                var dsBar_Dm_Rentlevel = objMasterService.Get_All_Bar_Dm_Rentlevel_Collection().ToDataSet();
                lookUpEdit_RentLevel.Properties.DataSource = dsBar_Dm_Rentlevel.Tables[0];
            }
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete && FormState != GoobizFrame.Windows.Forms.FormState.View)
                lookUpEdit_RentLevel.EditValue = null;
        }

        private void dtNgay_Batdau_Table_EditValueChanged(object sender, EventArgs e)
        {
            if (dtNgay_Batdau_Table.EditValue == null || FormState == GoobizFrame.Windows.Forms.FormState.View) return;
            var Guid_Checkin_Table = cvBar_Rent_Checkin_Table.GetFocusedRowCellValue("Guid_Checkin_Table");
            if ("" + Guid_Checkin_Table == "")
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] { "phòng" });
                return;
            }
            DataRow[] dtr = dsBar_Rent_Checkin_Table.Tables[0].Select("Guid_Checkin_Table = '" + Guid_Checkin_Table + "' ");
            if (dtr.Length > 0)
            {
                if (dtr[0].RowState != DataRowState.Deleted)
                    dtr[0]["Ngay_Batdau"] = dtNgay_Batdau_Table.EditValue;
            }
        }

        private void dtNgay_Ketthuc_Table_EditValueChanged(object sender, EventArgs e)
        {
            //if (dtNgay_Ketthuc_Table.EditValue == null) return;
            var Guid_Checkin_Table = cvBar_Rent_Checkin_Table.GetFocusedRowCellValue("Guid_Checkin_Table");
            if ("" + Guid_Checkin_Table == "")
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] { "phòng" });
                return;
            }
            DataRow[] dtr = dsBar_Rent_Checkin_Table.Tables[0].Select("Guid_Checkin_Table = '" + Guid_Checkin_Table + "' ");
            if (dtr.Length > 0)
            {
                if (dtr[0].RowState != DataRowState.Deleted)
                    dtr[0]["Ngay_Ketthuc"] = (dtNgay_Ketthuc_Table.EditValue == null) ? DBNull.Value : dtNgay_Ketthuc_Table.EditValue;
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (cvBar_Rent_Checkin_Table.GetFocusedRowCellValue("Id_Checkin_Table") == null)
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] { "phòng" });
                return;
            }
            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00038", new string[] { }) == DialogResult.Yes)
            {
                if (gvBar_Rent_Checkin_Phieuthu.RowCount > 0
                    && !Convert.ToBoolean(gvBar_Rent_Checkin_Phieuthu.GetFocusedRowCellValue("Trangthai")))
                {
                    if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00041", new string[] { }) == DialogResult.Yes)
                    {
                        objBarService.Update_Bar_Rent_Checkin_PhieuThu_Trangthai(gvBar_Rent_Checkin_Phieuthu.GetFocusedRowCellValue("Id_Checkin_Phieuthu"),
                                                                                cvBar_Rent_Checkin_Table.GetFocusedRowCellValue("Id_Checkin_Table"));
                    }
                }
                var success = objBarService.Update_Bar_Rent_Checkin_Table_Check_Out(cvBar_Rent_Checkin_Table.GetFocusedRowCellValue("Id_Checkin_Table"));
                if (Convert.ToBoolean(success))
                {
                    this.btnCheckout.Enabled = false;
                    cvBar_Rent_Checkin_Table_FocusedRowChanged(null, null);
                    this.PerformPrintPreview();
                }
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (!Check_Checkout())
                return;
            var Id_Checkin_Table = cvBar_Rent_Checkin_Table.GetFocusedRowCellValue("Id_Checkin_Table");
            if ("" + Id_Checkin_Table == "")
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] { "phòng" });
                return;
            }
            Forms.Rent.Frmbar_Rent_Checkin_Order frmOrder = new Frmbar_Rent_Checkin_Order(Id_Checkin_Table, Current_Id_Khuvuc);
            frmOrder.Text = btnOrder.Text;
            frmOrder.item_Add.PerformClick();
            frmOrder.ShowDialog();
            cvBar_Rent_Checkin_Table_FocusedRowChanged(null, null);
        }

        private void btnReseved_Click(object sender, EventArgs e)
        {
            Current_Guid_Checkin = System.Guid.NewGuid();
            Frmbar_Rent_Reserve frm_reserve = new Frmbar_Rent_Reserve();
            frm_reserve.btnAdd.Visible = false;
            frm_reserve.btnDelete.Visible = false;
            frm_reserve.btnEdit.Visible = false;
            frm_reserve.btnSelect.Visible = true;
            frm_reserve.ShowDialog();
            if (frm_reserve.Current_Id_Reserve != null)
            {
                var sochungtu = "" + objBarService.GetNew_Sochungtu("bar_rent_checkin", "So_Chungtu", "IN");
                this.Current_Id_Checkin = objBarService.Insert_Bar_Rent_Checkin_ByReserved(frm_reserve.Current_Id_Reserve, sochungtu, DateTime.Now);
                this.PerformEdit();
                //DisplayInfo();
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(chkPb_Reserved.EditValue))
                if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00042", new string[] { }) == DialogResult.Yes)
                {
                    objBarService.Update_Bar_Rent_Checkin_Table_Reset_Table_Reserved(Current_Id_Checkin, Current_Guid_Checkin);
                    DisplayInfo();
                }
        }

        // Chuyển/ Đổi phòng
        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                if (cvBar_Rent_Checkin_Table.GetFocusedRowCellValue("Id_Table") == null)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] { "Phòng" });
                    return;
                }
                if (!Check_Checkout())
                    return;
                if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00043", new string[] { cvBar_Rent_Checkin_Table.GetFocusedRowCellValue("Ten_Table").ToString() }) == DialogResult.Yes)
                {
                    System.Collections.Hashtable htproperties = new System.Collections.Hashtable();
                    htproperties.Add("Ngay_Batdau", dtNgay_Batdau.DateTime);
                    htproperties.Add("Ngay_Ketthuc", ("" + dtNgay_Ketthuc.EditValue == "") ? dtNgay_Batdau.DateTime.AddDays(1) : dtNgay_Ketthuc.DateTime);
                    System.Windows.Forms.Form dialog = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowExternalDialog("Ecm.Bar.dll",
                           "Ecm.Bar.Forms.Rent.Frmbar_Rent_Reserve_RoomLookup", this, null, htproperties, false);
                    if (dialog == null)
                        return;

                    var SelectedObject = dialog.GetType().GetProperty("SelectedRow").GetValue(dialog, null) as System.Data.DataRow;
                    if (SelectedObject == null) return;
                    objBarService.Bar_Rent_Checkin_Table_ChangeTable(cvBar_Rent_Checkin_Table.GetFocusedRowCellValue("Id_Checkin_Table"), SelectedObject["Id_Table"]);
                    dsBar_Rent_Checkin_Table = objBarService.Get_All_Bar_Rent_Checkin_Table(Current_Guid_Checkin).ToDataSet();
                    dgBar_Rent_Checkin_Table.DataSource = dsBar_Rent_Checkin_Table.Tables[0];
                }
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        private bool Check_Checkout() // nếu phòng đã Check out --> return False
        {
            if ("" + cvBar_Rent_Checkin_Table.GetFocusedRowCellValue("Check_Out") != ""
             && Convert.ToBoolean(cvBar_Rent_Checkin_Table.GetFocusedRowCellValue("Check_Out")))
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("Msg00039", new string[] { });
                return false;
            }
            else
                return true;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tabPageInfo")
                tableLayoutPanel2.Visible = true;
            else
                tableLayoutPanel2.Visible = false;
        }

        private void lookUpEdit_Khachhang_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit_Khachhang.EditValue != null)
            {
                txtCheckin_Cmnd.EditValue = lookUpEdit_Khachhang.GetColumnValue("Cmnd");
                txtCheckin_Email.EditValue = lookUpEdit_Khachhang.GetColumnValue("Email");
                txtCheckin_Tel.EditValue = lookUpEdit_Khachhang.GetColumnValue("Dienthoai");
            }
        }

        private void lookUpEdit_Class_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete
                && FormState != GoobizFrame.Windows.Forms.FormState.View)
            {
                lookUpEdit_Class.EditValue = null;
            }
        }

        private void cardButtonEdit_Ten_Table_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (cvBar_Rent_Checkin_Table.GetFocusedRowCellValue("Note").ToString() != "")
                GoobizFrame.Windows.Forms.MessageDialog.Show(cvBar_Rent_Checkin_Table.GetFocusedRowCellValue("Note").ToString());
        }


    }
}
