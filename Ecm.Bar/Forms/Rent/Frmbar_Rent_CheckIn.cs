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
using DevExpress.XtraReports.UI;

namespace Ecm.Bar.Forms.Rent
{
    public partial class Frmbar_Rent_CheckIn : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        Ecm.WebReferences.Classes.BarService objBarService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.BarService>();
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();

        DataSet dsbar_Rent_Checkin = new DataSet();
        private object id_Checkin;
        public object Current_Id_Checkin { get { return id_Checkin; } set { id_Checkin = value; } }

        private Guid guid_checkin;
        public Guid Current_Guid_Checkin { get { return guid_checkin; } set { guid_checkin = value; } }

        private object id_cuahang_ban;
        public object Current_Id_Cuahang_Ban
        {
            get
            {
                id_cuahang_ban = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocation("Id_Cuahang_Ban");
                return id_cuahang_ban;
            }
        }

        Frmbar_Rent_Checkin_Info _Frmbar_Rent_Checkin_Info = null;
        Frmbar_Rent_Reserve_RoomLookup _Frmbar_Rent_Reserve_RoomLookup = null;

        public Frmbar_Rent_CheckIn()
        {
            InitializeComponent();
            this.barSystem.Visible = false;
            this.AfterCheckUserRightAction += new EventHandler(Frmbar_Rent_Checkin_AfterCheckUserRightAction);
            DisplayInfo();
        }

        void Frmbar_Rent_Checkin_AfterCheckUserRightAction(object sender, EventArgs e)
        {
            this.btnAdd.Enabled = this.EnableAdd;
            this.btnEdit.Enabled = this.EnableEdit;
            this.btnDelete.Enabled = this.EnableDelete;
        }

        #region Events override

        public override void ClearDataBindings()
        {
            lookUpEdit_Khachhang.DataBindings.Clear();
            lookUpEdit_RentLevel.DataBindings.Clear();
            dtNgay_Batdau.DataBindings.Clear();
            dtNgay_Ketthuc.DataBindings.Clear();
            lookUpEdit_Class.DataBindings.Clear();
            txtSoluong_Phong.DataBindings.Clear();
            txtSoluong_Khach.DataBindings.Clear();
            txtCheckin_Hoten.DataBindings.Clear();
            txtCheckin_Cmnd.DataBindings.Clear();
            txtCheckin_Tel.DataBindings.Clear();
            txtChietkhau_Tyle.DataBindings.Clear();
            txtChietkhau_Tienmat.DataBindings.Clear();
            txtCheckin_Email.DataBindings.Clear();
            chkThanhtoantruoc.DataBindings.Clear();
            dtNgay_Chungtu.DataBindings.Clear();
            txtSo_Chungtu.DataBindings.Clear();
            lookUpEdit_Nhansu_Ctu.DataBindings.Clear();
            memGhichu.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                lookUpEdit_Khachhang.DataBindings.Add("EditValue", dsbar_Rent_Checkin, dsbar_Rent_Checkin.Tables[0].TableName + ".Id_Khachhang");
                lookUpEdit_RentLevel.DataBindings.Add("EditValue", dsbar_Rent_Checkin, dsbar_Rent_Checkin.Tables[0].TableName + ".Id_Rentlevel");
                dtNgay_Batdau.DataBindings.Add("EditValue", dsbar_Rent_Checkin, dsbar_Rent_Checkin.Tables[0].TableName + ".Ngay_Batdau");
                dtNgay_Ketthuc.DataBindings.Add("EditValue", dsbar_Rent_Checkin, dsbar_Rent_Checkin.Tables[0].TableName + ".Ngay_Ketthuc");
                lookUpEdit_Class.DataBindings.Add("EditValue", dsbar_Rent_Checkin, dsbar_Rent_Checkin.Tables[0].TableName + ".Id_Class");
                txtSoluong_Phong.DataBindings.Add("EditValue", dsbar_Rent_Checkin, dsbar_Rent_Checkin.Tables[0].TableName + ".Soluong_Phong");
                txtSoluong_Khach.DataBindings.Add("EditValue", dsbar_Rent_Checkin, dsbar_Rent_Checkin.Tables[0].TableName + ".Soluong_Khach");
                txtCheckin_Hoten.DataBindings.Add("EditValue", dsbar_Rent_Checkin, dsbar_Rent_Checkin.Tables[0].TableName + ".Checkin_Hoten");
                txtCheckin_Cmnd.DataBindings.Add("EditValue", dsbar_Rent_Checkin, dsbar_Rent_Checkin.Tables[0].TableName + ".Checkin_Cmnd");
                txtCheckin_Tel.DataBindings.Add("EditValue", dsbar_Rent_Checkin, dsbar_Rent_Checkin.Tables[0].TableName + ".Checkin_Tel");
                txtChietkhau_Tyle.DataBindings.Add("EditValue", dsbar_Rent_Checkin, dsbar_Rent_Checkin.Tables[0].TableName + ".Chietkhau_Tyle");
                txtChietkhau_Tienmat.DataBindings.Add("EditValue", dsbar_Rent_Checkin, dsbar_Rent_Checkin.Tables[0].TableName + ".Chietkhau_Tienmat");
                txtCheckin_Email.DataBindings.Add("EditValue", dsbar_Rent_Checkin, dsbar_Rent_Checkin.Tables[0].TableName + ".Checkin_Email");
                chkThanhtoantruoc.DataBindings.Add("EditValue", dsbar_Rent_Checkin, dsbar_Rent_Checkin.Tables[0].TableName + ".Thanhtoantruoc");
                dtNgay_Chungtu.DataBindings.Add("EditValue", dsbar_Rent_Checkin, dsbar_Rent_Checkin.Tables[0].TableName + ".Ngay_Chungtu");
                txtSo_Chungtu.DataBindings.Add("EditValue", dsbar_Rent_Checkin, dsbar_Rent_Checkin.Tables[0].TableName + ".So_Chungtu");
                lookUpEdit_Nhansu_Ctu.DataBindings.Add("EditValue", dsbar_Rent_Checkin, dsbar_Rent_Checkin.Tables[0].TableName + ".Id_Nhansu_Ctu");
                memGhichu.DataBindings.Add("EditValue", dsbar_Rent_Checkin, dsbar_Rent_Checkin.Tables[0].TableName + ".Ghichu");
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }

        public override void ResetText()
        {
            lookUpEdit_Khachhang.EditValue = null;
            lookUpEdit_RentLevel.EditValue = null;
            dtNgay_Batdau.EditValue = null;
            dtNgay_Ketthuc.EditValue = null;
            lookUpEdit_Class.EditValue = null;
            txtSoluong_Phong.EditValue = null;
            txtSoluong_Khach.EditValue = null;
            txtCheckin_Hoten.EditValue = null;
            txtCheckin_Cmnd.EditValue = null;
            txtCheckin_Tel.EditValue = null;
            txtChietkhau_Tyle.EditValue = null;
            txtChietkhau_Tienmat.EditValue = null;
            txtCheckin_Email.EditValue = null;
            chkThanhtoantruoc.EditValue = null;
            dtNgay_Chungtu.EditValue = DateTime.Now;
            txtSo_Chungtu.EditValue = null;
            lookUpEdit_Nhansu_Ctu.EditValue = Convert.ToInt64(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu()); ;
            memGhichu.EditValue = null;
        }

        public override void DisplayInfo()
        {
            try
            {
                var dsDm_Khachhang = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
                gridLookUpEdit_Khachhang.DataSource = dsDm_Khachhang.Tables[0];
                lookUpEdit_Khachhang.Properties.DataSource = dsDm_Khachhang.Tables[0];
                lookUpEdit_Class.Properties.DataSource = objMasterService.Get_All_Bar_Dm_Class().ToDataSet().Tables[0];
                lookUpEdit_Nhansu_Ctu.Properties.DataSource = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet().Tables[0];
                lookUpEdit_RentLevel.Properties.DataSource = objMasterService.Get_All_Bar_Dm_Rentlevel_Collection().ToDataSet().Tables[0];
                dsbar_Rent_Checkin = objBarService.Get_All_Bar_Rent_Checkin(null, Current_Id_Cuahang_Ban, false).ToDataSet();
                dgBar_Rent_CheckIn.DataSource = dsbar_Rent_Checkin;
                dgBar_Rent_CheckIn.DataMember = dsbar_Rent_Checkin.Tables[0].TableName;
                DataBindingControl();
                if (cvBar_Rent_CheckIn.RowCount == 0)
                    ResetText();
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        public override void ChangeStatus(bool editTable)
        {
            lookUpEdit_Khachhang.Properties.ReadOnly = !editTable;
            lookUpEdit_RentLevel.Properties.ReadOnly = !editTable;
            dtNgay_Batdau.Properties.ReadOnly = !editTable;
            dtNgay_Ketthuc.Properties.ReadOnly = !editTable;
            lookUpEdit_Class.Properties.ReadOnly = !editTable;
            txtSoluong_Phong.Properties.ReadOnly = !editTable;
            txtSoluong_Khach.Properties.ReadOnly = !editTable;
            txtCheckin_Hoten.Properties.ReadOnly = !editTable;
            txtCheckin_Cmnd.Properties.ReadOnly = !editTable;
            txtCheckin_Tel.Properties.ReadOnly = !editTable;
            txtChietkhau_Tyle.Properties.ReadOnly = !editTable;
            txtChietkhau_Tienmat.Properties.ReadOnly = !editTable;
            txtCheckin_Email.Properties.ReadOnly = !editTable;
            chkThanhtoantruoc.Properties.ReadOnly = !editTable;
            dtNgay_Chungtu.Properties.ReadOnly = true;
            txtSo_Chungtu.Properties.ReadOnly = true;
            lookUpEdit_Nhansu_Ctu.Properties.ReadOnly = true;
            memGhichu.Properties.ReadOnly = !editTable;
            cvBar_Rent_CheckIn.OptionsBehavior.Editable = false;
        }

        public override bool PerformPrintPreview()
        {
            Current_Id_Checkin = cvBar_Rent_CheckIn.GetFocusedRowCellValue("Id_Checkin");
            if (Current_Id_Checkin == null)
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] { "danh sách đặt phòng" });
                return false;
            }
            if ("" + lookUpEdit_RentLevel.EditValue == "")
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] { labelControl19.Text });
                return false;
            }
            dsbar_Rent_Checkin = objBarService.GetBar_Rent_Checkin_ById4Print(Current_Id_Checkin, lookUpEdit_RentLevel.EditValue, DateTime.Now).ToDataSet();
            Ecm.Bar.DataSets.dsHdbanhang_Chitiet dsrHdbanhang_Chitiet = new Ecm.Bar.DataSets.dsHdbanhang_Chitiet();
            Ecm.Bar.Reports.rptHdbanhang_Hotel rptHdbanhang = new Ecm.Bar.Reports.rptHdbanhang_Hotel();
            GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            frmPrintPreview.Report = rptHdbanhang;

            int i = 1;
            foreach (DataRow dr in dsbar_Rent_Checkin.Tables[0].Rows)
            {
                if (dr.RowState != DataRowState.Deleted)
                {
                    DataRow drnew = dsrHdbanhang_Chitiet.Tables[0].NewRow();
                    foreach (DataColumn dc in dsbar_Rent_Checkin.Tables[0].Columns)
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
                    dsrHdbanhang_Chitiet.Tables[0].Rows.Add(drnew);
                }
            }
            //add parameter values
            rptHdbanhang.tbc_Ngay.Text = "" + dtNgay_Chungtu.Text;
            rptHdbanhang.tbcSochungtu.Text = "" + txtSo_Chungtu.Text;
            rptHdbanhang.lblNhansu_Bill.Text = lookUpEdit_Nhansu_Ctu.Text;
            rptHdbanhang.lblKhachhang.Text = lookUpEdit_Khachhang.Text;
            DataSet dsOrder_Chitiet;
            decimal thanhtien_order = 0;
            foreach (DataRow row in dsrHdbanhang_Chitiet.Tables["Hdbanhang_Chitiet"].Rows)
            {
                dsOrder_Chitiet = objBarService.Get_Bar_Rent_Checkin_table_Hanghoa_By_Checkin_Table_4Print(row["Id_Bar_Rent_Checkin_Table"]).ToDataSet();
                foreach (DataRow dtr in dsOrder_Chitiet.Tables[0].Rows)
                {
                    dsrHdbanhang_Chitiet.Tables["Order_Chitiet"].ImportRow(dtr);
                }
                thanhtien_order += Convert.ToDecimal("0" + dsOrder_Chitiet.Tables[0].Compute("Sum(Thanhtien)", ""));
            }
            decimal thanhtien = Convert.ToDecimal("0" + dsbar_Rent_Checkin.Tables[0].Compute("Sum(thanhtien)", ""));
            thanhtien += thanhtien_order;
            var da_thanhtoan = objBarService.Get_Bar_Rent_Checkin_Dathanhtoan_ById_Checkin(Current_Id_Checkin);
            thanhtien -= Convert.ToDecimal("0" + da_thanhtoan);
            rptHdbanhang.PageSize = new Size(800, 1400 + 100 * Convert.ToInt32(dsrHdbanhang_Chitiet.Tables[0].Rows.Count));

            //Trừ tiền cọc 
            if (Convert.ToDecimal("0" + da_thanhtoan) > 0)
            {
                decimal Thanhtien_TG = Convert.ToDecimal("0" +
                    dsrHdbanhang_Chitiet.Tables[0].Rows[dsrHdbanhang_Chitiet.Tables[0].Rows.Count - 1]["Thanhtien_TG"]);
                Thanhtien_TG -= Convert.ToDecimal(da_thanhtoan);
                dsrHdbanhang_Chitiet.Tables[0].Rows[dsrHdbanhang_Chitiet.Tables[0].Rows.Count - 1]["Thanhtien_TG"] = Thanhtien_TG;
                rptHdbanhang.xrTable_Tien_Booking.Visible = true;
                rptHdbanhang.lblTien_Booking.Text = string.Format("{0:#,#}", da_thanhtoan);
            }
            else
            {
                rptHdbanhang.xrTable6.Location = new System.Drawing.Point(21, 42);
                rptHdbanhang.xrTable4.Location = new System.Drawing.Point(21, 135);
            }
            decimal thanhtien_order_per_room = 0;
            foreach (DataRow row in dsrHdbanhang_Chitiet.Tables["Hdbanhang_Chitiet"].Rows)
            {
                thanhtien_order_per_room = Convert.ToDecimal("0" + dsrHdbanhang_Chitiet.Tables["Order_Chitiet"].Compute("Sum(Thanhtien)", "Id_Bar_Rent_Checkin_Table = " + row["Id_Bar_Rent_Checkin_Table"]));
                row["Total_Per_Room"] = Convert.ToDecimal("0" + row["Thanhtien"]) + thanhtien_order_per_room;
            }
            rptHdbanhang.DataSource = dsrHdbanhang_Chitiet;
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

            rptHdbanhang.lblTongcong.Text = String.Format("{0:n0}", Convert.ToDouble(thanhtien));
            string str = GoobizFrame.Windows.HelperClasses.ReadNumber.ChangeNum2VNStr((double)thanhtien, " đồng.");
            str = str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower();
            rptHdbanhang.tbcThanhtien_Bangchu.Text = str;
            rptHdbanhang.tbc_Ngay_Batdau.Text = dtNgay_Batdau.Text;
            rptHdbanhang.tbc_Ngay_Ketthuc.Text = dtNgay_Ketthuc.Text;
            if (Convert.ToDecimal("" +  dsbar_Rent_Checkin.Tables[0].Rows[0]["Per_Dongia"] ) == 0)
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

        #endregion

        #region Process Buttons

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //// xóa file tmp trong folder Default\AppForms để update label khi Loadform
            //string path_file = @"Resources\Default\AppForms\Ecm.Bar.Frmbar_Rent_Checkin_Info";
            //if (System.IO.File.Exists(path_file))
            //    System.IO.File.Delete(path_file);
            _Frmbar_Rent_Checkin_Info = new Frmbar_Rent_Checkin_Info();
            _Frmbar_Rent_Checkin_Info.barSystem.Visible = false;
            _Frmbar_Rent_Checkin_Info.Icon = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetProductIcon();
            //_Frmbar_Rent_Checkin_Info.ChangeFormState(GoobizFrame.Windows.Forms.FormState.Add);
            _Frmbar_Rent_Checkin_Info.PerformAdd();
            _Frmbar_Rent_Checkin_Info.ShowDialog();
            DisplayInfo();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (cvBar_Rent_CheckIn.GetFocusedRowCellValue("Id_Checkin") == null)
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] { "danh sách đặt phòng" });
                return;
            }
            //// xóa file tmp trong folder Default\AppForms để update label khi Loadform
            //string path_file = @"Resources\Default\AppForms\Ecm.Bar.Frmbar_Rent_Checkin_Info";
            //if (System.IO.File.Exists(path_file))
            //    System.IO.File.Delete(path_file);
            _Frmbar_Rent_Checkin_Info = new Frmbar_Rent_Checkin_Info();
            _Frmbar_Rent_Checkin_Info.barSystem.Visible = false;
            _Frmbar_Rent_Checkin_Info.Icon = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetProductIcon();
            //_Frmbar_Rent_Checkin_Info.ChangeFormState(GoobizFrame.Windows.Forms.FormState.Edit);
            _Frmbar_Rent_Checkin_Info.Current_Id_Checkin = cvBar_Rent_CheckIn.GetFocusedRowCellValue("Id_Checkin");
            _Frmbar_Rent_Checkin_Info.PerformEdit();
            _Frmbar_Rent_Checkin_Info.ShowDialog();
            DisplayInfo();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cvBar_Rent_CheckIn.GetFocusedRowCellValue("Id_Checkin") == null)
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] { "danh sách đặt phòng" });
                return;
            }
            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[] { "thông tin này" }) == DialogResult.Yes)
            {
                objBarService.Delete_Bar_Rent_Checkin(new WebReferences.BarService.Bar_Rent_Checkin()
                {
                    Id_Checkin = cvBar_Rent_CheckIn.GetFocusedRowCellValue("Id_Checkin")
                });
                DisplayInfo();
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            DisplayInfo();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            cvBar_Rent_CheckIn.MovePrevPage();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            cvBar_Rent_CheckIn.MoveNextPage();
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
                objBarService.Insert_Bar_Rent_Checkin_ByReserved(frm_reserve.Current_Id_Reserve, sochungtu, DateTime.Now);
                DisplayInfo();
            }
        }

        #endregion

        private void gNumboard1_UserKeyPressed(object sender, GoobizFrame.Windows.Controls.TouchscreenKeyboard.KeyboardEventArgs e)
        {
            SendKeys.Send(e.KeyboardKeyPressed);
        }

        private void cvBar_Rent_Reserve_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cvBar_Rent_CheckIn.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                cvBar_Rent_CheckIn.FocusedRowHandle = cardHit.RowHandle;
                Current_Id_Checkin = cvBar_Rent_CheckIn.GetRowCellValue(cardHit.RowHandle, "Id_Checkin");
                //highlight
                GoobizFrame.Windows.MdiUtils.ThemeSettings.MakeConditionForSelectedCard(cvBar_Rent_CheckIn, "Id_Checkin", Current_Id_Checkin);
            }
        }

        void DisplayByArrivalDate(object thang, object nam)
        {
            if (thang != null && nam != null)
            {
                dsbar_Rent_Checkin = objBarService.Get_All_Bar_Rent_Checkin_ByArrivalDate(new DateTime(int.Parse("" + nam), int.Parse("" + thang), 1), Current_Id_Cuahang_Ban).ToDataSet();
                dgBar_Rent_CheckIn.DataSource = dsbar_Rent_Checkin.Tables[0];
            }
        }

        private void btnRoomLookup_Click(object sender, EventArgs e)
        {
            _Frmbar_Rent_Reserve_RoomLookup = new Frmbar_Rent_Reserve_RoomLookup();
            _Frmbar_Rent_Reserve_RoomLookup.barSystem.Visible = false;
            _Frmbar_Rent_Reserve_RoomLookup.Icon = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetProductIcon();
            _Frmbar_Rent_Reserve_RoomLookup.WindowState = System.Windows.Forms.FormWindowState.Normal;
            _Frmbar_Rent_Reserve_RoomLookup.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            _Frmbar_Rent_Reserve_RoomLookup.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            _Frmbar_Rent_Reserve_RoomLookup.Ngay_Batdau = DateTime.Now;
            _Frmbar_Rent_Reserve_RoomLookup.Ngay_Ketthuc = DateTime.Now;
            _Frmbar_Rent_Reserve_RoomLookup.ShowDialog();
        }

        private void cvBar_Rent_Reserve_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Current_Id_Checkin = cvBar_Rent_CheckIn.GetFocusedRowCellValue("Id_Checkin");
            GoobizFrame.Windows.MdiUtils.ThemeSettings.MakeConditionForSelectedCard(cvBar_Rent_CheckIn, "Id_Checkin", Current_Id_Checkin);
        }

        private void btn_Checkout_Click(object sender, EventArgs e)
        {
            if (cvBar_Rent_CheckIn.GetFocusedRowCellValue("Id_Checkin") == null)
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] { "danh sách đặt phòng" });
                return;
            }
            if ("" + lookUpEdit_RentLevel.EditValue == "")
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] { labelControl19.Text });
                return;
            }
            DataSet dsCheckin_Table_Collection = objBarService.Get_All_Bar_Rent_Checkin_Table(cvBar_Rent_CheckIn.GetFocusedRowCellValue("Guid_Checkin")).ToDataSet();
            if (dsCheckin_Table_Collection.Tables[0].Rows.Count > 1) //check nếu có hơn 2 phòng thì hiển thị danh sách phòng --> check out từng phòng
            {
                if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00040", new string[] { }) == DialogResult.Yes)
                    objBarService.Update_Bar_Rent_Check_Out(cvBar_Rent_CheckIn.GetFocusedRowCellValue("Id_Checkin"));
                else
                {
                    _Frmbar_Rent_Checkin_Info = new Frmbar_Rent_Checkin_Info();
                    _Frmbar_Rent_Checkin_Info.barSystem.Visible = false;
                    _Frmbar_Rent_Checkin_Info.Icon = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetProductIcon();
                    _Frmbar_Rent_Checkin_Info.Current_Id_Checkin = cvBar_Rent_CheckIn.GetFocusedRowCellValue("Id_Checkin");
                    _Frmbar_Rent_Checkin_Info.ChangeFormState(GoobizFrame.Windows.Forms.FormState.View);
                    _Frmbar_Rent_Checkin_Info.Check_Out();
                    _Frmbar_Rent_Checkin_Info.ShowDialog();
                }
            }
            else if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00038", new string[] { }) == DialogResult.Yes)
                objBarService.Update_Bar_Rent_Check_Out(cvBar_Rent_CheckIn.GetFocusedRowCellValue("Id_Checkin"));
            this.PerformPrintPreview();
            this.DisplayInfo();
            new System.Threading.Thread(new System.Threading.ThreadStart(this.Xuat_Nvl)).Start();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.PerformPrintPreview();
        }

        private void btnDisplay_Click_1(object sender, EventArgs e)
        {
            DisplayInfo();
        }

        public void Xuat_Nvl()
        {
            try
            {
                objBarService.Bar_Table_Order_Xuat_Nvl(Current_Id_Cuahang_Ban, null, Current_Id_Checkin);
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

    }
}
