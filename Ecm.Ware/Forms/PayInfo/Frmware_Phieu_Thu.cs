using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Phieu_Thu : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet dsCollection = new DataSet();
        DataSet dsCollection_Chitiet = new DataSet();
        object _id_phieuthu;
        object sotien_quydoi = null;
        decimal Sotien_Conlai = 0;
        object id_nhansu_current;
        DataSet ds_Role_User;
        DataTable dtb_soquy;

        public Frmware_Phieu_Thu()
        {
            InitializeComponent();
            dtNgay_Chungtu.Properties.MinValue = new DateTime(2000, 01, 01);
            dtNgay_Chungtu.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgay_Chungtu.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();
            id_nhansu_current = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu();
            ds_Role_User = objMasterService.GetRole_System_Name_ById_User(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUserId()).ToDataSet();
            dtThang_Nam.DateTime = objWareService.GetServerDateTime();
            this.DisplayInfo();
        }

        #region Event Override

        public override void DisplayInfo()
        {
            try
            {
                //Get data Get_All_Rex_Nhansu_Collection
                this.ChangeFormState(GoobizFrame.Windows.Forms.FormState.View);
                DataSet dsNhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
                lookUpEdit_Nhansu_Lapphieu.Properties.DataSource = dsNhansu.Tables[0];
                lookUpEditNhansu_Nop.Properties.DataSource = dsNhansu.Tables[0];
                lookUpEditNhansu_Nop.EditValue = null;
                //Get data Get_All_Ware_Dm_Doituong
                DataSet dsDoituong = objMasterService.Get_All_Ware_Dm_Doituong().ToDataSet();
                lookUpEdit_Ma_Khachhang.Properties.DataSource = dsDoituong.Tables[0];
                lookUpEditTen_Khachhang.Properties.DataSource = dsDoituong.Tables[0];
                lookUpEdit_MaKH_View.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet().Tables[0];
                lookUpEditMa_Kho_Hanghoa.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().ToDataSet().Tables[0];
                this.ChangeStatus(false);

                //dtThang_Nam.EditValue = null;
                //gvPhieuThu.Columns["Thang"].ClearFilter();
                //gvPhieuThu.Columns["Nam"].ClearFilter();
                gvPhieuThu.OptionsBehavior.Editable = false;
                Sotien_Conlai = 0;

                if (ds_Role_User.Tables[0].Rows.Count > 0 && "" + ds_Role_User.Tables[0].Rows[0]["Role_System_Name"] == "Administrators")
                {
                    item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

                //DataSet ds_collection = objMasterService.GetRole_System_Name_ById_User(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUserId()).ToDataSet();
                //if (ds_collection.Tables[0].Rows.Count > 0 &&
                //    "" + ds_collection.Tables[0].Rows[0]["Role_System_Name"] == "Administrators")
                //{
                dtb_soquy = objMasterService.GetAll_Ware_Dm_Soquy(null).ToDataSet().Tables[0];
                DataRow row = dtb_soquy.NewRow();
                row["Id_Soquy"] = -1;
                row["Ma_Soquy"] = "All";
                row["Ten_Soquy"] = "Tất cả";
                dtb_soquy.Rows.Add(row);
                //}
                //else
                //{
                //    dtb_soquy = objMasterService.GetAll_Ware_Dm_Soquy_By_Id_Nhansu(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu()).ToDataSet().Tables[0];
                //}
                lookUpEdit_Soquy.Properties.DataSource = dtb_soquy;
                Load_Gridview();
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
            this.LookupEditChungtu_Goc.DataBindings.Clear();
            this.txtId_Phieu_Thu.DataBindings.Clear();
            this.txtLydo.DataBindings.Clear();
            this.txtSochungtu.DataBindings.Clear();
            this.txtSotien_Quydoi.DataBindings.Clear();
            this.dtNgay_Chungtu.DataBindings.Clear();
            this.lookUpEdit_Ma_Khachhang.DataBindings.Clear();
            this.txtNguoi_Nop.DataBindings.Clear();
            this.lookUpEdit_Nhansu_Lapphieu.DataBindings.Clear();
            lookUpEditMa_Kho_Hanghoa.DataBindings.Clear();
            lookUpEditTen_Khachhang.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.LookupEditChungtu_Goc.DataBindings.Add("EditValue", dsCollection_Chitiet, dsCollection_Chitiet.Tables[0].TableName + ".Chungtu_Goc");
                this.txtId_Phieu_Thu.DataBindings.Add("EditValue", dsCollection_Chitiet, dsCollection_Chitiet.Tables[0].TableName + ".Id_Phieu_Thu");
                this.txtLydo.DataBindings.Add("EditValue", dsCollection_Chitiet, dsCollection_Chitiet.Tables[0].TableName + ".Lydo");
                this.txtSochungtu.DataBindings.Add("EditValue", dsCollection_Chitiet, dsCollection_Chitiet.Tables[0].TableName + ".Sochungtu");
                this.txtSotien_Quydoi.DataBindings.Add("EditValue", dsCollection_Chitiet, dsCollection_Chitiet.Tables[0].TableName + ".Sotien_Quydoi");
                this.dtNgay_Chungtu.DataBindings.Add("EditValue", dsCollection_Chitiet, dsCollection_Chitiet.Tables[0].TableName + ".Ngay_Chungtu");
                lookUpEditTen_Khachhang.DataBindings.Add("EditValue", dsCollection_Chitiet, dsCollection_Chitiet.Tables[0].TableName + ".Ma_Doituong");
                this.lookUpEdit_Ma_Khachhang.DataBindings.Add("EditValue", dsCollection_Chitiet, dsCollection_Chitiet.Tables[0].TableName + ".Ma_Doituong");
                this.txtNguoi_Nop.DataBindings.Add("EditValue", dsCollection_Chitiet, dsCollection_Chitiet.Tables[0].TableName + ".Nguoi_Nop");
                this.lookUpEdit_Nhansu_Lapphieu.DataBindings.Add("EditValue", dsCollection_Chitiet, dsCollection_Chitiet.Tables[0].TableName + ".Id_Nhansu_Lapphieu");
                this.lookUpEditMa_Kho_Hanghoa.DataBindings.Add("EditValue", dsCollection_Chitiet, dsCollection_Chitiet.Tables[0].TableName + ".Id_Khuvuc");
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
            //this.dgacc_Phieu_Thu.Enabled = !editable;
            btnPhanbo.Enabled = editable;
            this.LookupEditChungtu_Goc.Properties.ReadOnly = !editable;
            this.txtId_Phieu_Thu.Properties.ReadOnly = !editable;
            this.txtLydo.Properties.ReadOnly = !editable;
            this.txtNguoi_Nop.Properties.ReadOnly = !editable;
            this.txtSotien_Quydoi.Enabled = editable;
            this.lookUpEdit_Ma_Khachhang.Properties.ReadOnly = !editable;
            this.lookUpEditMa_Kho_Hanghoa.Properties.ReadOnly = !editable;
            lookUpEditNhansu_Nop.Properties.ReadOnly = !editable;
            dockPanel1.Enabled = !editable;
            dgPhieuthu_Chitiet.Enabled = !editable;
        }

        public override void ResetText()
        {
            this.LookupEditChungtu_Goc.EditValue = null;
            this.txtId_Phieu_Thu.EditValue = null;
            this.txtLydo.EditValue = null;
            this.txtSotien_Quydoi.EditValue = null;
            this.txtSotien_Chu.EditValue = null;
            this.txtNguoi_Nop.Text = "";            
            this.lookUpEdit_Ma_Khachhang.EditValue = null;
            lookUpEditTen_Khachhang.EditValue = null;
            lookUpEditNhansu_Nop.EditValue = null;
            this.lookUpEditMa_Kho_Hanghoa.EditValue = null;
            dtNgay_Chungtu.EditValue = null;
            this.lookUpEdit_Nhansu_Lapphieu.EditValue = null;// Convert.ToInt64(id_nhansu_current);
            txtSochungtu.EditValue = null;
            txtDiachi.Text = "";
            dgPhieuthu_Chitiet.DataSource = null;
        }

        public object InsertObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Phieu_Thu objWare_Phieu_Thu = new Ecm.WebReferences.WareService.Ware_Phieu_Thu();
                objWare_Phieu_Thu.Id_Phieu_Thu = -1;
                objWare_Phieu_Thu.Sochungtu = txtSochungtu.EditValue;
                objWare_Phieu_Thu.Ngay_Chungtu = dtNgay_Chungtu.EditValue;
                objWare_Phieu_Thu.Id_Cuahang_Ban = lookUpEdit_Soquy.EditValue; // id_Soquy
                objWare_Phieu_Thu.Ma_Doituong = lookUpEdit_Ma_Khachhang.Text;
                objWare_Phieu_Thu.Ten_Doituong = null;
                objWare_Phieu_Thu.Nguoi_Nop = txtNguoi_Nop.Text;
                objWare_Phieu_Thu.Chungtu_Goc = ("" + LookupEditChungtu_Goc.EditValue == "") ? null : LookupEditChungtu_Goc.EditValue;
                objWare_Phieu_Thu.Lydo = "" + txtLydo.EditValue;
                objWare_Phieu_Thu.Id_Tiente = null;
                objWare_Phieu_Thu.Guid_Ctu = Guid.NewGuid();
                objWare_Phieu_Thu.Id_Khachhang = null; // lookUpEdit_Ma_Khachhang.EditValue;
                if ("" + lookUpEdit_Nhansu_Lapphieu.EditValue != "")
                    objWare_Phieu_Thu.Id_Nhansu_Lapphieu = lookUpEdit_Nhansu_Lapphieu.EditValue;

                if ("" + lookUpEditMa_Kho_Hanghoa.GetColumnValue("Id_Kho_Hanghoa_Mua") != "")
                    objWare_Phieu_Thu.Id_Kho_Hanghoa_Mua = lookUpEditMa_Kho_Hanghoa.GetColumnValue("Id_Kho_Hanghoa_Mua");

                objWare_Phieu_Thu.Sotien_Quydoi = txtSotien_Quydoi.EditValue;
                objWareService.Insert_Ware_Phieu_Thu(objWare_Phieu_Thu);
                return true;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return false;
            }
        }

        public object UpdateObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Phieu_Thu objWare_Phieu_Thu = new Ecm.WebReferences.WareService.Ware_Phieu_Thu();
                objWare_Phieu_Thu.Id_Phieu_Thu = gvPhieuthu_Chitiet.GetFocusedRowCellValue("Id_Phieu_Thu");
                objWare_Phieu_Thu.Sochungtu = txtSochungtu.EditValue;
                objWare_Phieu_Thu.Ngay_Chungtu = dtNgay_Chungtu.EditValue;
                objWare_Phieu_Thu.Id_Cuahang_Ban = lookUpEdit_Soquy.EditValue; // id_Soquy
                objWare_Phieu_Thu.Ma_Doituong = lookUpEdit_Ma_Khachhang.Text;
                objWare_Phieu_Thu.Ten_Doituong = null;
                objWare_Phieu_Thu.Id_Khachhang = null;// lookUpEdit_Ma_Khachhang.EditValue;
                objWare_Phieu_Thu.Nguoi_Nop = txtNguoi_Nop.Text;
                objWare_Phieu_Thu.Chungtu_Goc = ("" + LookupEditChungtu_Goc.EditValue == "") ? null : LookupEditChungtu_Goc.EditValue;
                objWare_Phieu_Thu.Lydo = "" + txtLydo.EditValue;
                objWare_Phieu_Thu.Id_Tiente = null;
                if ("" + lookUpEdit_Nhansu_Lapphieu.EditValue != "")
                    objWare_Phieu_Thu.Id_Nhansu_Lapphieu = lookUpEdit_Nhansu_Lapphieu.EditValue;

                if ("" + lookUpEditMa_Kho_Hanghoa.GetColumnValue("Id_Kho_Hanghoa_Mua") != "")
                    objWare_Phieu_Thu.Id_Kho_Hanghoa_Mua = lookUpEditMa_Kho_Hanghoa.GetColumnValue("Id_Kho_Hanghoa_Mua");

                objWare_Phieu_Thu.Sotien_Quydoi = txtSotien_Quydoi.EditValue;
                objWareService.Update_Ware_Phieu_Thu(objWare_Phieu_Thu);
                return true;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return false;
            }
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.WareService.Ware_Phieu_Thu objWare_Phieu_Thu = new Ecm.WebReferences.WareService.Ware_Phieu_Thu();
            objWare_Phieu_Thu.Id_Phieu_Thu = gvPhieuthu_Chitiet.GetFocusedRowCellValue("Id_Phieu_Thu");
            return objWareService.Delete_Ware_Phieu_Thu(objWare_Phieu_Thu);
        }

        public override bool PerformAdd()
        {
            if ("" + lookUpEdit_Soquy.EditValue == "" || Convert.ToDecimal(lookUpEdit_Soquy.EditValue) == -1)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn sổ quỹ, vui lòng chọn lại");
                lookUpEdit_Soquy.Focus();
                return false;
            }
            ClearDataBindings();
            this.ResetText();
            this.ChangeStatus(true);
            lookUpEdit_Nhansu_Lapphieu.EditValue = Convert.ToInt64(id_nhansu_current);
            dtNgay_Chungtu.EditValue = objWareService.GetServerDateTime();
            dtThang_Nam.EditValue = objWareService.GetServerDateTime().Month + "/" + objWareService.GetServerDateTime().Year;
            txtSochungtu.EditValue = objWareService.GetNew_Sochungtu("ware_phieu_thu", "sochungtu", "THU_" + lookUpEdit_Soquy.GetColumnValue("Ma_Soquy") + "-");

            return true;
        }

        public override bool PerformEdit()
        {
            if (gvPhieuthu_Chitiet.GetFocusedRowCellValue("Id_Phieu_Thu") == null)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn phiếu thu, vui lòng chọn lại");
                return false;
            }
            _id_phieuthu = gvPhieuthu_Chitiet.GetFocusedRowCellValue("Id_Phieu_Thu");
            if (ds_Role_User.Tables[0].Rows.Count > 0 &&
                            "" + ds_Role_User.Tables[0].Rows[0]["Role_System_Name"] == "Administrators")
            {
                this.ChangeStatus(true);
                return true;
            }
            return false;
        }

        public override bool PerformCancel()
        {
            this.ChangeFormState(GoobizFrame.Windows.Forms.FormState.View);
            this.DisplayInfo();
            return true;
        }

        public override bool PerformSave()
        {
            try
            {
                bool success = false;
                if (!Check_Control())
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
                    //PerformPrintPreview();
                    this.DisplayInfo();
                }
                return success;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        private bool Check_Control()
        {
            GoobizFrame.Windows.Public.OrderHashtable htbControl1 = new GoobizFrame.Windows.Public.OrderHashtable();
            htbControl1.Add(txtNguoi_Nop, lblNguoi_Nop.Text);
            htbControl1.Add(txtLydo, lblLydo.Text);
            htbControl1.Add(txtSotien_Quydoi, lblSotien_Quydoi.Text);

            if (lookUpEdit_Ma_Khachhang.EditValue == null && lookUpEditMa_Kho_Hanghoa.EditValue == null)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Khu vực nhận hoặc đối tượng không được rỗng, vui lòng nhập lại");
                return false;
            }

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(htbControl1))
                return false;

            if (LookupEditChungtu_Goc.Text != "")
            {
                if (Sotien_Conlai != 0 && Convert.ToDecimal(txtSotien_Quydoi.EditValue) > Sotien_Conlai)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Số tiền nhập không chính xác, vui lòng kiểm tra lại");
                    txtSotien_Quydoi.Focus();
                    return false;
                }
            }

            if (LookupEditChungtu_Goc.Text != "")
            {
                decimal Sotien = 0;
                DataSet ds_HdXuatkho = objWareService.Get_All_Ware_Xuatkho_Banhang().ToDataSet();
                if (ds_HdXuatkho.Tables[0].Select("Sochungtu = '" + LookupEditChungtu_Goc.EditValue + "'").Length > 0)
                {
                    Sotien = Convert.ToDecimal(ds_HdXuatkho.Tables[0].Compute("Sum(Sotien)", "Sochungtu = '" + LookupEditChungtu_Goc.EditValue + "'"));
                    if (Convert.ToDecimal(txtSotien_Quydoi.EditValue) > Sotien)
                    {
                        GoobizFrame.Windows.Forms.MessageDialog.Show("Hóa đơn này đã thanh toán đủ tiền, nên không thể xuất thêm Phiếu thu");
                        return false;
                    }
                }
            }
            return true;
        }

        public override bool PerformDelete()
        {
            try
            {
                if (gvPhieuthu_Chitiet.GetFocusedRowCellValue("Id_Phieu_Thu") == null)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn phiếu thu, vui lòng chọn lại");
                    return false;
                }
                _id_phieuthu = gvPhieuthu_Chitiet.GetFocusedRowCellValue("Id_Phieu_Thu");
                if (ds_Role_User.Tables[0].Rows.Count > 0 &&
                            "" + ds_Role_User.Tables[0].Rows[0]["Role_System_Name"] == "Administrators")

                    if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
                     GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Phieu_Thu"),
                     GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Phieu_Thu")   }) == DialogResult.Yes)
                    {
                        try
                        {
                            this.DeleteObject();
                        }
                        catch (Exception ex)
                        {
                            GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                        }
                        this.DisplayInfo();
                    }
                return true;
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
                return false;
#endif
            }
            return base.PerformDelete();
        }

        public override bool PerformPrintPreview()
        {
            if (gvPhieuthu_Chitiet.GetFocusedRowCellValue("Id_Phieu_Thu") == null)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn phiếu thu, vui lòng chọn lại");
                return false;
            }
            _id_phieuthu = gvPhieuthu_Chitiet.GetFocusedRowCellValue("Id_Phieu_Thu");
            Reports.rptPhieu_Thu rptPhieu_Thu = new Ecm.Ware.Reports.rptPhieu_Thu();
            GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            frmPrintPreview.Report = rptPhieu_Thu;

            //add parameter values
            rptPhieu_Thu.tbcDiachi.Text = txtDiachi.Text;
            rptPhieu_Thu.tbcLydo.Text = txtLydo.Text;
            rptPhieu_Thu.tbcNam.Text = "" + dtNgay_Chungtu.DateTime.Year;
            rptPhieu_Thu.tbcThang.Text = "" + dtNgay_Chungtu.DateTime.Month;
            rptPhieu_Thu.tbcNgay.Text = "" + dtNgay_Chungtu.DateTime.Day;
            rptPhieu_Thu.tbcNguoi_Noptien.Text = txtNguoi_Nop.Text;
            rptPhieu_Thu.tbcNguoi_Noptien_Kyten.Text = "" + txtNguoi_Nop.Text;
            rptPhieu_Thu.tbcNhansu_Lapphieu.Text = "" + lookUpEdit_Nhansu_Lapphieu.Text;
            rptPhieu_Thu.tbcGhichu.Text = "" + LookupEditChungtu_Goc.Text;
            rptPhieu_Thu.tbcSochungtu.Text = txtSochungtu.Text;
            rptPhieu_Thu.tbcSotien.Text = string.Format("{0:#,#}", txtSotien_Quydoi.EditValue);
            double sotien = Convert.ToDouble(txtSotien_Quydoi.EditValue);
            string str = GoobizFrame.Windows.HelperClasses.ReadNumber.ChangeNum2VNStr(sotien, " đồng.");
            str = str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower();
            rptPhieu_Thu.tbcSotien_Bangchu.Text = str;
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
                        ,imageData
                    });

                rptPhieu_Thu.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                rptPhieu_Thu.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
            }

            #endregion

            rptPhieu_Thu.CreateDocument();
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(rptPhieu_Thu);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                frmPrintPreview.Text = "" + oReportOptions.Caption;
                frmPrintPreview.printControl1.PrintingSystem = rptPhieu_Thu.PrintingSystem;
                frmPrintPreview.MdiParent = this.MdiParent;
                frmPrintPreview.Show();
                frmPrintPreview.Activate();
            }
            else
            {
                var reportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rptPhieu_Thu);
                reportPrintTool.Print();
            }

            return base.PerformPrintPreview();
            //}
            return false;
        }

        #endregion

        #region Even

        private void lookUpEdit_Nguoinop_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //try
            //{
            //    if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            //    {
            //        if (this.FormState == GoobizFrame.Windows.Forms.FormState.View)
            //            return;
            //        Ecm.MasterTables.Forms.Ware.Frmware_Dm_Doituong frmware_Dm_Doituong = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Doituong();
            //        frmware_Dm_Doituong.StartPosition = FormStartPosition.CenterScreen;
            //        frmware_Dm_Doituong.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //        frmware_Dm_Doituong.item_Cancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //        frmware_Dm_Doituong.item_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //        frmware_Dm_Doituong.Text = "Chọn đối tượng";
            //        frmware_Dm_Doituong.ShowDialog();
            //        if (frmware_Dm_Doituong.drDoituong != null)
            //        {
            //            lookUpEdit_Ma_Khachhang.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Doituong().ToDataSet().Tables[0];
            //            this.lookUpEdit_Ma_Khachhang.EditValue = frmware_Dm_Doituong.drDoituong["Ma_Doituong"];
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ex.ToString();
            //}
        }

        private void txtSotien_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if ("" + txtSotien_Quydoi.EditValue != "")
                {
                    decimal sotien1 = Convert.ToDecimal(txtSotien_Quydoi.EditValue);
                    if (txtSotien_Quydoi.Text != "")
                    {
                        double sotien = Convert.ToDouble(txtSotien_Quydoi.EditValue);
                        txtSotien_Chu.Text = GoobizFrame.Windows.HelperClasses.ReadNumber.ChangeNum2VNStr(sotien, " đồng.");
                        txtSotien_Chu.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(GoobizFrame.Windows.HelperClasses.ReadNumber.ChangeNum2VNStr(sotien, " đồng."));
                    }
                    else
                        txtSotien_Chu.Text = "";
                }
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Số tiền không hợp lý, vui lòng nhập lại!");
                txtSotien_Quydoi.Text = @"0";
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if ("" + gvPhieuThu.GetFocusedRowCellValue("Guid_Ctu") == "")
                    ResetText();
                else
                {
                    dsCollection_Chitiet = objWareService.Ware_Phieu_Thu_SelectBy_Guid_Ctu(gvPhieuThu.GetFocusedRowCellValue("Guid_Ctu")).ToDataSet();
                    dgPhieuthu_Chitiet.DataSource = dsCollection_Chitiet;
                    dgPhieuthu_Chitiet.DataMember = dsCollection_Chitiet.Tables[0].TableName;
                    gvPhieuthu_Chitiet_FocusedRowChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void txtChungtu_Goc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            //{
            //    if (this.FormState == GoobizFrame.Windows.Forms.FormState.View)
            //        return;

            //    Frmware_Hdbanhang_Dialog frmware_Hdbanhang_Dialog = new Frmware_Hdbanhang_Dialog();
            //    frmware_Hdbanhang_Dialog.setDs_Xuatkho_Banhang();
            //    frmware_Hdbanhang_Dialog.Text = "Chọn Chứng từ gốc";
            //    frmware_Hdbanhang_Dialog.gridColumn_Sotien_Thanhtoan.Visible = true;
            //    frmware_Hdbanhang_Dialog.StartPosition = FormStartPosition.CenterScreen;
            //    frmware_Hdbanhang_Dialog.ShowDialog();
            //    if (frmware_Hdbanhang_Dialog.drHdbanhang != null)
            //    {
            //        Sotien_Conlai = Convert.ToDecimal("0" + frmware_Hdbanhang_Dialog.drHdbanhang["Sotien"]);
            //        txtSotien_Quydoi.EditValue = Sotien_Conlai;
            //        LookupEditChungtu_Goc.EditValue = frmware_Hdbanhang_Dialog.drHdbanhang["Sochungtu"];
            //        lookUpEdit_Ma_Khachhang.EditValue = "KH - " + frmware_Hdbanhang_Dialog.drHdbanhang["Ma_Khachhang"];
            //        //txtSotien_Quydoi.EditValue = frmware_Hdbanhang_Dialog.drHdbanhang["Sotien"];                
            //    }
            //}
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                LookupEditChungtu_Goc.EditValue = null;
        }

        private void lookUpEdit_Nguoinop_EditValueChanged(object sender, EventArgs e)
        {
            if ("" + lookUpEdit_Ma_Khachhang.EditValue != "")
            {
                this.txtDiachi.EditValue = lookUpEdit_Ma_Khachhang.GetColumnValue("Diachi");
                if (FormState == GoobizFrame.Windows.Forms.FormState.View) return;
                lookUpEditTen_Khachhang.EditValue = lookUpEdit_Ma_Khachhang.EditValue;
                LookupEditChungtu_Goc.Properties.DataSource = objWareService.Ware_Phieu_Thu_SelectXuatkho_NotPayByMa_Khachhang(lookUpEdit_Ma_Khachhang.EditValue).ToDataSet().Tables[0];
            }
        }

        private void dtThang_Nam_EditValueChanged(object sender, EventArgs e)
        {
            //Load_Gridview();
        }

        private void txtChungtu_Goc_EditValueChanged(object sender, EventArgs e)
        {
            if (FormState != GoobizFrame.Windows.Forms.FormState.View)
                if ("" + LookupEditChungtu_Goc.EditValue != "")
                    txtSotien_Quydoi.EditValue = LookupEditChungtu_Goc.GetColumnValue("Sotien_Conlai");
                else
                    txtSotien_Quydoi.EditValue = null;
        }

        private void txtSotien_Quydoi_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue != null)
                if (e.NewValue.ToString().Length > 16)
                    e.Cancel = true;
        }

        private void txtSotien_Nguyente_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue != null)
                if (e.NewValue.ToString().Length > 10)
                    e.Cancel = true;
        }

        #endregion

        #region Custom Method

        public bool set_Chungtu_Goc(DataRow Hd_Xuatkho, object Ma_Nhacungcap, object sotien_dachi)
        {
            decimal Sotien_Dachi = 0;
            //if (dsCollection_Chitiet.Tables[0].Select("Chungtu_Goc = '" + Hd_Xuatkho["Sochungtu"] + "'").Length > 0)
            Sotien_Dachi = Convert.ToDecimal(sotien_dachi);
            this.ChangeFormState(GoobizFrame.Windows.Forms.FormState.Add);
            this.Text = "Lập phiếu Thu tiền mặt";
            this.PerformAdd();
            lookUpEdit_Ma_Khachhang.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Doituong().ToDataSet().Tables[0];
            lookUpEdit_Ma_Khachhang.EditValue = "KH - " + Ma_Nhacungcap.ToString();
            //txtSotien_Quydoi.EditValue = Convert.ToDecimal(Hd_Xuatkho["Sotien"]) - Sotien_Dachi;
            Sotien_Conlai = Convert.ToDecimal(Hd_Xuatkho["Sotien"]);
            LookupEditChungtu_Goc.EditValue = Hd_Xuatkho["Sochungtu"];
            if (LookupEditChungtu_Goc.EditValue == null)
                return false;
            else
                return true;
        }

        #endregion

        private void lookUpEditMa_Kho_Hanghoa_Properties_EditValueChanged(object sender, EventArgs e)
        {
            if ("" + lookUpEditMa_Kho_Hanghoa.EditValue != "" && FormState != GoobizFrame.Windows.Forms.FormState.View)
                lookUpEdit_Ma_Khachhang.Properties.DataSource = objMasterService.Ware_Dm_Khachhang_SelectBy_Khuvuc_New(lookUpEditMa_Kho_Hanghoa.EditValue).ToDataSet().Tables[0];
        }

        private void lookUpEditMa_Kho_Hanghoa_EditValueChanged(object sender, EventArgs e)
        {
            if ("" + lookUpEditMa_Kho_Hanghoa.EditValue == "")
                return;
            DataSet dsKhachhang = objMasterService.Ware_Dm_Khachhang_SelectBy_Khuvuc_New(lookUpEditMa_Kho_Hanghoa.EditValue).ToDataSet();
            lookUpEdit_Ma_Khachhang.Properties.DataSource = dsKhachhang.Tables[0];
            lookUpEditTen_Khachhang.Properties.DataSource = dsKhachhang.Tables[0];
            txtDiachi.EditValue = null;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            Load_Gridview();
        }

        void Load_Gridview()
        {
            //Get data Ware_Phieu_Thu
            if ("" + lookUpEdit_Soquy.EditValue == "")
            {
                //GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn sổ quỹ, vui lòng chọn lại");
                lookUpEdit_Soquy.Focus();
                return;
            }
            dsCollection = objWareService.Ware_Phieu_Thu_SelectAll_New(lookUpEdit_Soquy.EditValue, dtThang_Nam.DateTime, lookUpEdit_MaKH_View.EditValue).ToDataSet();
            dgacc_Phieu_Thu.DataSource = dsCollection.Tables[0];            
        }

        private void lookUpEdit_MaKH_View_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                lookUpEdit_MaKH_View.EditValue = null;
        }

        private void lookUpEditNhansu_Nop_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEditNhansu_Nop.EditValue == null)
                txtNguoi_Nop.EditValue = null;
            else
                txtNguoi_Nop.EditValue = lookUpEditNhansu_Nop.GetColumnValue("Hoten_Nhansu");
        }

        private void btnPhanbo_Click(object sender, EventArgs e)
        {
            if (!Check_Control())
                return ;
            if (MessageBox.Show("Phân bổ phiếu thu?", "Confirm Dialog", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataSet ds_Chungtu_Goc = objWareService.Ware_Phieu_Thu_SelectXuatkho_NotPayByMa_Khachhang(lookUpEdit_Ma_Khachhang.EditValue).ToDataSet();
                decimal sotien_phanbo = Convert.ToDecimal("0" + txtSotien_Quydoi.EditValue);
                foreach (DataRow row in ds_Chungtu_Goc.Tables[0].Rows)
                {
                    if (sotien_phanbo > 0)
                        if (Convert.ToDecimal("0" + row["Thanhtien"]) >= Convert.ToDecimal("0" + row["Sotien_Dathu"]))
                        {
                            if (Convert.ToDecimal("0" + row["Sotien_Dathu"]) >= 0)
                            {
                                if (Convert.ToDecimal("0" + row["Sotien_Conlai"]) <= sotien_phanbo)
                                {
                                    row["Sotien_Phanbo"] = Convert.ToDecimal("0" + row["Sotien_Conlai"]);
                                    sotien_phanbo = sotien_phanbo - Convert.ToDecimal("0" + row["Sotien_Conlai"]);
                                }
                                else
                                {
                                    row["Sotien_Phanbo"] = sotien_phanbo;
                                    sotien_phanbo = 0;
                                }
                            }
                            else
                            {
                                row["Sotien_Phanbo"] = row["Thanhtien"];
                                sotien_phanbo = sotien_phanbo - Convert.ToDecimal("0" + row["Sotien_Dathu"]);
                            }
                        }
                        else
                        {
                            row["Sotien_Phanbo"] = sotien_phanbo;
                            sotien_phanbo = 0;
                        }
                    row["Sotien_Conlai"] = Convert.ToDecimal("0" + row["Thanhtien"]) - Convert.ToDecimal("0" + row["Sotien_Dathu"]) - Convert.ToDecimal("0" + row["Sotien_Phanbo"]);
                }
                if (sotien_phanbo > 0) // neu so tien phieu thu > so tien cong no --> tao phieu thu ky gui
                {
                    DataRow row_new = ds_Chungtu_Goc.Tables[0].NewRow();
                    row_new["Ngay_Chungtu"] = DateTime.Now;
                    row_new["Sochungtu"] = null;
                    row_new["Thanhtien"] = 0;
                    row_new["Sotien_Dathu"] = 0;
                    row_new["Sotien_Phanbo"] = sotien_phanbo;
                    row_new["Sotien_Conlai"] = 0;
                    ds_Chungtu_Goc.Tables[0].Rows.Add(row_new);
                }
                bool check = false;
                DateTime Ngay_Chungtu = DateTime.Now;
                object guid_ctu = Guid.NewGuid();
                foreach (DataRow row in ds_Chungtu_Goc.Tables[0].Rows)
                {
                    if (Convert.ToDecimal("0" + row["Sotien_Phanbo"]) <= 0)
                        break;
                    Ecm.WebReferences.WareService.Ware_Phieu_Thu objWare_Phieu_Thu = new Ecm.WebReferences.WareService.Ware_Phieu_Thu();
                    objWare_Phieu_Thu.Id_Phieu_Thu = -1;
                    objWare_Phieu_Thu.Id_Cuahang_Ban = lookUpEdit_Soquy.EditValue; // id_Soquy
                    objWare_Phieu_Thu.Ma_Doituong = lookUpEdit_Ma_Khachhang.Text;
                    objWare_Phieu_Thu.Ten_Doituong = null;
                    objWare_Phieu_Thu.Nguoi_Nop = txtNguoi_Nop.Text;
                    objWare_Phieu_Thu.Sochungtu = objWareService.GetNew_Sochungtu("ware_phieu_thu", "sochungtu", "THU_" + lookUpEdit_Soquy.GetColumnValue("Ma_Soquy") + "-"); ;
                    objWare_Phieu_Thu.Ngay_Chungtu = Ngay_Chungtu;
                    objWare_Phieu_Thu.Chungtu_Goc = "" + row["Sochungtu"];
                    objWare_Phieu_Thu.Id_Nhansu_Lapphieu = Convert.ToInt64(id_nhansu_current); ;
                    objWare_Phieu_Thu.Id_Kho_Hanghoa_Mua = null;
                    objWare_Phieu_Thu.Lydo = "" + txtLydo.EditValue;
                    objWare_Phieu_Thu.Id_Tiente = null;
                    objWare_Phieu_Thu.Id_Khachhang = null; // lookUpEdit_Ma_Khachhang.EditValue;
                    objWare_Phieu_Thu.Guid_Ctu = guid_ctu;
                    objWare_Phieu_Thu.Sotien_Quydoi = row["Sotien_Phanbo"];
                    objWareService.Insert_Ware_Phieu_Thu(objWare_Phieu_Thu);
                    check = true;
                }
                if (check)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Đã phân bổ phiếu thu thành công!");
                    PerformCancel();
                }
            }
        }

        private void gvPhieuthu_Chitiet_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvPhieuthu_Chitiet.FocusedRowHandle >= 0)
            {
                DataBindingControl();
                if (lookUpEdit_Ma_Khachhang.Text != "")
                    LookupEditChungtu_Goc.Properties.DataSource = objWareService.Ware_Phieu_Thu_SelectXuatkho_By_Ma_Khachhang(lookUpEdit_Ma_Khachhang.EditValue).ToDataSet().Tables[0];
            }
        }

        private void lookUpEdit_Soquy_EditValueChanged(object sender, EventArgs e)
        {
            //Load_Gridview();
        }

    }
}

