using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;
using System.Globalization;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Phieu_Chi : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();

        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet dsCollection = new DataSet();
        object Sotien_Quydoi = null;
        object _id_phieuchi;
        decimal Sotien_Conlai = 0;
        DataTable dtb_soquy;
        bool flag = false; // if flag = true --> close this form after print

        string lastCurrencyEdited = "";

        public Frmware_Phieu_Chi()
        {
            InitializeComponent();
            dtNgay_Chungtu.Properties.MinValue = new DateTime(2000, 01, 01);
            //date mask
            dtNgay_Chungtu.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgay_Chungtu.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();


            gridDate_Ngay_Chungtu.Mask.UseMaskAsDisplayFormat = true;
            gridDate_Ngay_Chungtu.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();            
            this.DisplayInfo();
        }

        #region Event Override

        public override void ResetText()
        {
            this.txtChungtu_Goc.EditValue = null;
            this.txtLydo.EditValue = null;
            this.txtSotien_Quydoi.EditValue = null;
            this.txtSotien_Chu.EditValue = null;
            this.txtDiachi.EditValue = null;
            this.txtNguoi_Nhan.EditValue = null;
            this.lookUpEditMa_NCC.EditValue = null;
            lookUpEditTen_NCC.EditValue = null;
            txtSochungtu.EditValue = null;
            checkEdit_Chiphi.EditValue = null;
            dtNgay_Chungtu.EditValue = null;
            lookUpEdit_Nhansu_Lapphieu.EditValue = null;
        }

        public override void DisplayInfo()
        {
            try
            {
                dtThang_Nam.EditValue = DateTime.Now;
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

                //    item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                //    item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                //}
                //else
                //{
                //    item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //    item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //    dtb_soquy = objMasterService.GetAll_Ware_Dm_Soquy_By_Id_Nhansu(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu()).ToDataSet().Tables[0];
                //}
                lookUpEdit_Soquy.Properties.DataSource = dtb_soquy;

                //Get data Get_All_Rex_Nhansu_Collection
                DataSet dsNhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
                lookUpEdit_Nhansu_Lapphieu.Properties.DataSource = dsNhansu.Tables[0];
                gridLookUpEdit_Nhansu_Lapphieu.DataSource = dsNhansu.Tables[0];
                lookUpEditNhansu_Nhan.Properties.DataSource = dsNhansu.Tables[0];
                lookUpEditNhansu_Nhan.EditValue = null;
                //Get data Get_All_Ware_Dm_Doituong
                DataSet dsDoituong = objMasterService.Get_All_Ware_Dm_Doituong().ToDataSet();
                lookUpEditMa_NCC.Properties.DataSource = dsDoituong.Tables[0];
                lookUpEditTen_NCC.Properties.DataSource = dsDoituong.Tables[0];
                gridLookUpEdit_Doituong.DataSource = dsDoituong.Tables[0];

                this.ChangeStatus(false);
                gvPhieuChi.OptionsBehavior.Editable = false;
                Sotien_Conlai = 0;
                flag = false;
                Load_Gridview();
                if (dsCollection.Tables.Count == 0)
                    return;
                this.DataBindingControl();
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
            this.txtChungtu_Goc.DataBindings.Clear();
            this.txtLydo.DataBindings.Clear();
            this.txtSochungtu.DataBindings.Clear();
            this.txtSotien_Quydoi.DataBindings.Clear();
            this.txtDiachi.DataBindings.Clear();
            this.dtNgay_Chungtu.DataBindings.Clear();
            this.txtNguoi_Nhan.DataBindings.Clear();
            this.lookUpEditMa_NCC.DataBindings.Clear();
            this.lookUpEdit_Nhansu_Lapphieu.DataBindings.Clear();
            lookUpEditTen_NCC.DataBindings.Clear();
            checkEdit_Chiphi.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtChungtu_Goc.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Chungtu_Goc");
                this.txtLydo.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Lydo");
                this.txtSochungtu.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Sochungtu");
                this.txtSotien_Quydoi.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Sotien_Quydoi");
                this.dtNgay_Chungtu.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Ngay_Chungtu");
                this.txtNguoi_Nhan.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Nguoi_Nhan");
                lookUpEditMa_NCC.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Ma_Doituong");
                lookUpEditTen_NCC.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Ma_Doituong");
                checkEdit_Chiphi.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Chiphi");
                this.lookUpEdit_Nhansu_Lapphieu.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Id_Nhansu_Lapphieu");
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }

        public override void ChangeStatus(bool editTable)
        {
            dockPanel1.Enabled = !editTable;
            this.txtChungtu_Goc.Properties.ReadOnly = !editTable;
            this.txtLydo.Properties.ReadOnly = !editTable;
            this.txtNguoi_Nhan.Properties.ReadOnly = !editTable;
            lookUpEditNhansu_Nhan.Properties.ReadOnly = !editTable;
            this.txtSotien_Quydoi.Enabled = editTable;
            this.lookUpEditMa_NCC.Properties.ReadOnly = !editTable;
            this.checkEdit_Chiphi.Properties.ReadOnly = !editTable;
        }

        public object InsertObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Phieu_Chi objWare_Phieu_Chi = new Ecm.WebReferences.WareService.Ware_Phieu_Chi();
                objWare_Phieu_Chi.Id_Phieu_Chi = -1;
                objWare_Phieu_Chi.Chungtu_Goc = txtChungtu_Goc.EditValue;
                objWare_Phieu_Chi.Lydo = txtLydo.EditValue;
                objWare_Phieu_Chi.Sochungtu = txtSochungtu.EditValue;
                objWare_Phieu_Chi.Sotien_Quydoi = txtSotien_Quydoi.EditValue;
                objWare_Phieu_Chi.Ngay_Chungtu = dtNgay_Chungtu.EditValue;
                objWare_Phieu_Chi.Nguoi_Nhan = (txtNguoi_Nhan.EditValue == null) ? null : txtNguoi_Nhan.EditValue;
                objWare_Phieu_Chi.Chiphi = ("" + checkEdit_Chiphi.EditValue == "") ? false : checkEdit_Chiphi.EditValue;
                objWare_Phieu_Chi.Sotien = null;
                objWare_Phieu_Chi.Tygia = null;
                objWare_Phieu_Chi.Ma_Doituong = lookUpEditMa_NCC.Text;
                objWare_Phieu_Chi.Id_Tiente = -1;

                if ("" + lookUpEdit_Nhansu_Lapphieu.EditValue != "")
                    objWare_Phieu_Chi.Id_Nhansu_Lapphieu = lookUpEdit_Nhansu_Lapphieu.EditValue;
                objWare_Phieu_Chi.Ma_Kho_Hanghoa = null;
                objWare_Phieu_Chi.Id_Cuahang_Ban = lookUpEdit_Soquy.EditValue; // id_Soquy
                objWare_Phieu_Chi.Id_Kho_Hanghoa_Mua = null;
                objWare_Phieu_Chi.Id_Ncc = null; //("" + lookUpEditMa_NCC.EditValue == "") ? null : lookUpEditMa_NCC.EditValue;

                objWareService.Insert_Ware_Phieu_Chi(objWare_Phieu_Chi);
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
                Ecm.WebReferences.WareService.Ware_Phieu_Chi objWare_Phieu_Chi = new Ecm.WebReferences.WareService.Ware_Phieu_Chi();
                objWare_Phieu_Chi.Id_Phieu_Chi = gvPhieuChi.GetFocusedRowCellValue("Id_Phieu_Chi");
                objWare_Phieu_Chi.Chungtu_Goc = "" + txtChungtu_Goc.EditValue;
                objWare_Phieu_Chi.Lydo = "" +  txtLydo.EditValue;
                objWare_Phieu_Chi.Sochungtu = "" + txtSochungtu.EditValue;
                objWare_Phieu_Chi.Sotien_Quydoi = txtSotien_Quydoi.EditValue;
                objWare_Phieu_Chi.Ngay_Chungtu = dtNgay_Chungtu.EditValue;
                objWare_Phieu_Chi.Nguoi_Nhan = (txtNguoi_Nhan.EditValue.ToString() == "") ? null : txtNguoi_Nhan.EditValue;
                objWare_Phieu_Chi.Sotien = null;
                objWare_Phieu_Chi.Tygia = null;
                objWare_Phieu_Chi.Ma_Doituong = lookUpEditMa_NCC.Text;
                objWare_Phieu_Chi.Id_Tiente = -1;
                objWare_Phieu_Chi.Chiphi = ("" + checkEdit_Chiphi.EditValue == "") ? false : checkEdit_Chiphi.EditValue;
                objWare_Phieu_Chi.Id_Ncc = null;// ("" + lookUpEditMa_NCC.EditValue == "") ? null : lookUpEditMa_NCC.EditValue;

                if ("" + lookUpEdit_Nhansu_Lapphieu.EditValue != "")
                    objWare_Phieu_Chi.Id_Nhansu_Lapphieu = lookUpEdit_Nhansu_Lapphieu.EditValue;

                //objWare_Phieu_Chi.Ma_Kho_Hanghoa = (lookUpEditMa_Kho_Hanghoa.EditValue.ToString() == "") ? null : lookUpEditMa_Kho_Hanghoa.EditValue;
                //objWare_Phieu_Chi.Id_Cuahang_Ban = (lookUpEditMa_Kho_Hanghoa.GetColumnValue("Id_Cuahang_Ban").ToString() == "") ? null : lookUpEditMa_Kho_Hanghoa.GetColumnValue("Id_Cuahang_Ban");
                //objWare_Phieu_Chi.Id_Kho_Hanghoa_Mua = (lookUpEditMa_Kho_Hanghoa.GetColumnValue("Id_Kho_Hanghoa_Mua") == null) ? null : lookUpEditMa_Kho_Hanghoa.GetColumnValue("Id_Kho_Hanghoa_Mua");
                objWare_Phieu_Chi.Ma_Kho_Hanghoa = null;
                objWare_Phieu_Chi.Id_Cuahang_Ban = lookUpEdit_Soquy.EditValue; // id_Soquy
                objWare_Phieu_Chi.Id_Kho_Hanghoa_Mua = null;
                objWareService.Update_Ware_Phieu_Chi(objWare_Phieu_Chi);
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
            Ecm.WebReferences.WareService.Ware_Phieu_Chi objWare_Phieu_Chi = new Ecm.WebReferences.WareService.Ware_Phieu_Chi();
            objWare_Phieu_Chi.Id_Phieu_Chi = gvPhieuChi.GetFocusedRowCellValue("Id_Phieu_Chi");
            return objWareService.Delete_Ware_Phieu_Chi(objWare_Phieu_Chi);
        }

        public override bool PerformAdd()
        {
            if ("" + lookUpEdit_Soquy.EditValue == "" || Convert.ToDecimal(lookUpEdit_Soquy.EditValue) == -1)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn sổ quỹ, vui lòng chọn lại");
                lookUpEdit_Soquy.Focus();
                return false;
            }
            try
            {
                FormState = GoobizFrame.Windows.Forms.FormState.Add;

                ClearDataBindings();
                this.ResetText();
                this.ChangeStatus(true);
                lookUpEdit_Nhansu_Lapphieu.EditValue = Convert.ToInt64(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());                
                dtThang_Nam.EditValue = objWareService.GetServerDateTime().Month + "/" + objWareService.GetServerDateTime().Year;
                txtSochungtu.EditValue = objWareService.GetNew_Sochungtu("ware_phieu_chi", "sochungtu", "CHI_" + lookUpEdit_Soquy.GetColumnValue("Ma_Soquy") + "-");
                dtNgay_Chungtu.EditValue = objWareService.GetServerDateTime();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public override bool PerformEdit()
        {
            if (gvPhieuChi.GetFocusedRowCellValue("Id_Phieu_Chi") == null)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn phiếu chi, vui lòng chọn lại");
                return false;
            }
            _id_phieuchi = gvPhieuChi.GetFocusedRowCellValue("Id_Phieu_Chi");
            try
            {
                FormState = GoobizFrame.Windows.Forms.FormState.Edit;

                if ("" + _id_phieuchi != "")
                {
                    //Ecm.WebReferences.WareService.DocumentProcessStatus DocumentProcessStatus = new Ecm.WebReferences.WareService.DocumentProcessStatus();
                    //DocumentProcessStatus.Tablename = "Ware_Phieu_Chi";
                    //DocumentProcessStatus.PK_Name = "Id_Phieu_Chi";
                    //DocumentProcessStatus.Identity = gvPhieuChi.GetFocusedRowCellValue("Id_Phieu_Chi");
                    //DocumentProcessStatus = objWareService.Get_DocumentProcessStatus(DocumentProcessStatus);
                    //if (objWareService.GetEDocumentProcessStatus((int)DocumentProcessStatus.Doc_Process_Status) != Ecm.WebReferences.WareService.EDocumentProcessStatus.NewDoc)
                    //{
                    //    GoobizFrame.Windows.Forms.UserMessage.Show("TASK_VERIFIED", new string[] { });
                    //    return false;
                    //}
                    //if (!GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + lookUpEdit_Nhansu_Lapphieu.EditValue))
                    //{
                    //    GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                    //    return false;
                    //}
                    this.ChangeStatus(true);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public override bool PerformCancel()
        {
            FormState = GoobizFrame.Windows.Forms.FormState.View;
            this.ResetText();
            this.DisplayInfo();
            return true;
        }

        public override bool PerformSave()
        {
            bool success = false;
            try
            {
                GoobizFrame.Windows.Public.OrderHashtable htbControl1 = new GoobizFrame.Windows.Public.OrderHashtable();
                //htbControl1.Add(lookUpEditMa_Kho_Hanghoa, lblKho_Hanghoa.Text);
                htbControl1.Add(txtNguoi_Nhan, lblNguoi_Nhan.Text);
                htbControl1.Add(txtLydo, lblLydo.Text);
                htbControl1.Add(txtSotien_Quydoi, lblSotien_Quydoi.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(htbControl1))
                    return false;

                //if (lookUpEdit_Nguoinop.EditValue == null && lookUpEditMa_Kho_Hanghoa.EditValue == null)
                //{
                //    GoobizFrame.Windows.Forms.MessageDialog.Show("Khu vực nhận hoặc đối tượng không được rỗng, vui lòng nhập lại");
                //    return false;
                //}

                if (txtChungtu_Goc.Text != "")
                {
                    if (Sotien_Conlai != 0 && Convert.ToDecimal(txtSotien_Quydoi.EditValue) > Sotien_Conlai)
                    {
                        GoobizFrame.Windows.Forms.MessageDialog.Show("Số tiền nhập không chính xác, vui lòng kiểm tra lại");
                        txtSotien_Quydoi.Focus();
                        return false;
                    }
                }
                if (txtChungtu_Goc.Text != "")
                {
                    decimal Sotien = 0;
                    DataSet ds_HdMuahang = objWareService.Get_All_Ware_Hdmuahang(null).ToDataSet();
                    if (ds_HdMuahang.Tables[0].Select("Sochungtu = '" + txtChungtu_Goc.EditValue + "'").Length > 0)
                    {
                        Sotien = Convert.ToDecimal(ds_HdMuahang.Tables[0].Compute("Sum(Sotien)", "Sochungtu = '" + txtChungtu_Goc.EditValue + "'"));
                        if (Convert.ToDecimal(txtSotien_Quydoi.EditValue) > Sotien)
                        {
                            GoobizFrame.Windows.Forms.MessageDialog.Show("Hóa đơn này đã thanh toán đủ tiền, nên không thể xuất thêm Phiếu Chi");
                            return false;
                        }
                    }
                }
                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                    success = (bool)this.InsertObject();

                else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                    success = (bool)this.UpdateObject();

                if (success)
                {
                    if (!this.IsDisposed)
                        this.DisplayInfo();
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return false;
            }
            return success;

        }

        public override bool PerformDelete()
        {
            if (gvPhieuChi.GetFocusedRowCellValue("Id_Phieu_Chi") == null)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn phiếu chi, vui lòng chọn lại");
                return false;
            }
            _id_phieuchi = gvPhieuChi.GetFocusedRowCellValue("Id_Phieu_Chi");
            try
            {
                if ("" + _id_phieuchi != "")
                {
                    //Ecm.WebReferences.WareService.DocumentProcessStatus DocumentProcessStatus = new Ecm.WebReferences.WareService.DocumentProcessStatus();
                    //DocumentProcessStatus.Tablename = "Ware_Phieu_Chi";
                    //DocumentProcessStatus.PK_Name = "Id_Phieu_Chi";
                    //DocumentProcessStatus.Identity = gvPhieuChi.GetFocusedRowCellValue("Id_Phieu_Chi");
                    //DocumentProcessStatus = objWareService.Get_DocumentProcessStatus(DocumentProcessStatus);
                    //if (objWareService.GetEDocumentProcessStatus((int)DocumentProcessStatus.Doc_Process_Status) != Ecm.WebReferences.WareService.EDocumentProcessStatus.NewDoc)
                    //{
                    //    GoobizFrame.Windows.Forms.UserMessage.Show("TASK_VERIFIED", new string[] { });
                    //    return false;
                    //}
                    //if (!GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + lookUpEdit_Nhansu_Lapphieu.EditValue))
                    //{
                    //    GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                    //    return false;
                    //}
                    if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
                     GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Phieu_Chi"),
                     GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Phieu_Chi")   }) == DialogResult.Yes)
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
                return false;
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
                return false;
#endif
            }
        }

        public override bool PerformPrintPreview()
        {
            if (gvPhieuChi.GetFocusedRowCellValue("Id_Phieu_Chi") == null)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn phiếu chi, vui lòng chọn lại");
                return false;
            }
            _id_phieuchi = gvPhieuChi.GetFocusedRowCellValue("Id_Phieu_Chi");
            //if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.View)
            //{
            //    if ("" + _id_phieuchi != "")
            //    {
            //        return false;
            //    }
            //}
            //else
            //{
            Reports.rptPhieu_Chi rptPhieu_Chi = new Ecm.Ware.Reports.rptPhieu_Chi();
            GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            frmPrintPreview.Report = rptPhieu_Chi;
            //add parameter values
            rptPhieu_Chi.tbcDiachi.Text = txtDiachi.Text;
            rptPhieu_Chi.tbcLydo.Text = txtLydo.Text;
            rptPhieu_Chi.tbcNam.Text = "" + dtNgay_Chungtu.DateTime.Year;
            rptPhieu_Chi.tbcThang.Text = "" + dtNgay_Chungtu.DateTime.Month;
            rptPhieu_Chi.tbcNgay.Text = "" + dtNgay_Chungtu.DateTime.Day;
            rptPhieu_Chi.tbcNguoi_Nhantien.Text = "" + txtNguoi_Nhan.Text;
            rptPhieu_Chi.tbcDonvi.Text = "" + lookUpEditMa_NCC.Text;
            rptPhieu_Chi.tbcNguoi_Nhantien_Kyten.Text = "" + txtNguoi_Nhan.Text;
            rptPhieu_Chi.tbcNhansu_Lapphieu.Text = "" + lookUpEdit_Nhansu_Lapphieu.Text;
            rptPhieu_Chi.tbcGhichu.Text = "" + txtChungtu_Goc.Text;
            rptPhieu_Chi.tbcSochungtu.Text = txtSochungtu.Text;
            rptPhieu_Chi.tbcSotien.Text = string.Format("{0:#,#}", txtSotien_Quydoi.EditValue);
            double sotien = Convert.ToDouble(txtSotien_Quydoi.EditValue);
            string str = GoobizFrame.Windows.HelperClasses.ReadNumber.ChangeNum2VNStr(sotien, " đồng.");
            str = str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower();
            rptPhieu_Chi.tbcSotien_Bangchu.Text = str;
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

                rptPhieu_Chi.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                rptPhieu_Chi.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
            }

            #endregion

            rptPhieu_Chi.CreateDocument();
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(rptPhieu_Chi);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                frmPrintPreview.Text = "" + oReportOptions.Caption;
                frmPrintPreview.printControl1.PrintingSystem = rptPhieu_Chi.PrintingSystem;
                frmPrintPreview.MdiParent = this.MdiParent;
                frmPrintPreview.Show();
                frmPrintPreview.Activate();
            }
            else
            {
                var reportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rptPhieu_Chi);
                reportPrintTool.Print();
            }
            if (flag)
                this.Dispose();
            return base.PerformPrintPreview();
            //}
            return false;
        }

        #endregion

        #region Even

        private void lookUpEdit_Nguoinop_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this.FormState != GoobizFrame.Windows.Forms.FormState.View)
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                {
                    lookUpEditMa_NCC.EditValue = null;
                }
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
                        txtSotien_Chu.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(GoobizFrame.Windows.HelperClasses.ReadNumber.ChangeNum2VNStr(sotien, " đồng."));                        
                    }
                    else
                        txtSotien_Chu.Text = "";
                }
                lastCurrencyEdited = txtSotien_Quydoi.Name;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Số tiền không hợp lý, vui lòng nhập lại!");
                txtSotien_Quydoi.Text = @"0";
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvPhieuChi.FocusedRowHandle >= 0)
            {
                DataBindingControl();
                _id_phieuchi = gvPhieuChi.GetFocusedRowCellValue("Id_Phieu_Chi");
                Sotien_Quydoi = gvPhieuChi.GetFocusedRowCellValue("Sotien");
                if (Sotien_Quydoi == null)
                    return;
            }
            else
            {
                ClearDataBindings();
                ResetText();
            }
        }

        private void txtChungtu_Goc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this.FormState != GoobizFrame.Windows.Forms.FormState.View)
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
                {
                    Frmware_Nhap_Hh_Ban _Frmware_Nhap_Hh_Ban = new Frmware_Nhap_Hh_Ban();
                    _Frmware_Nhap_Hh_Ban.StartPosition = FormStartPosition.CenterScreen;
                    _Frmware_Nhap_Hh_Ban.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    _Frmware_Nhap_Hh_Ban.item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    _Frmware_Nhap_Hh_Ban.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    _Frmware_Nhap_Hh_Ban.item_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    _Frmware_Nhap_Hh_Ban.item_Cancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    _Frmware_Nhap_Hh_Ban.item_Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    _Frmware_Nhap_Hh_Ban.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    _Frmware_Nhap_Hh_Ban.ShowDialog();
                    if (_Frmware_Nhap_Hh_Ban.ware_Nhap_Hh_Ban != null)
                    {
                        txtChungtu_Goc.EditValue = _Frmware_Nhap_Hh_Ban.ware_Nhap_Hh_Ban.Sochungtu;
                        //Sotien_Conlai = Convert.ToDecimal("0" + _Frmware_Nhap_Hh_Ban.dr_Hdmuahang["Sotien"]) - Convert.ToDecimal("0" + _Frmware_Nhap_Hh_Ban.dr_Hdmuahang["Sotien_Thanhtoan"]);
                        //if (Sotien_Conlai <= 0)
                        //{
                        //    GoobizFrame.Windows.Forms.MessageDialog.Show("Hóa đơn này đã xuất phiếu chi đủ tiền, nên không thể xuất thêm Phiếu Chi");
                        //    this.txtChungtu_Goc.EditValue = null;
                        //    this.txtSotien_Quydoi.EditValue = null;
                        //    this.txtSotien_Chu.Text = "";
                        //    return;
                        //}
                        //txtSotien_Quydoi.EditValue = Sotien_Conlai;
                        //this.lookUpEdit_Nguoinop.EditValue = "NCC - " + _Frmware_Nhap_Hh_Ban.dr_Hdmuahang["Ma_Khachhang"];
                    }
                }
        }

        public void lookUpEdit_Nguoinop_EditValueChange(object sender, EventArgs e)
        {
            this.txtDiachi.EditValue = lookUpEditMa_NCC.GetColumnValue("Diachi");
            lookUpEditTen_NCC.EditValue = lookUpEditMa_NCC.EditValue;
        }

        private void dtThang_Nam_EditValueChanged(object sender, EventArgs e)
        {
            if (dtThang_Nam.Text == "")
                return;
            DateTime dtValue = dtThang_Nam.DateTime;
            gvPhieuChi.Columns["Thang"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(gvPhieuChi.Columns["Thang"], dtValue.Month);
            gvPhieuChi.Columns["Nam"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(gvPhieuChi.Columns["Nam"], dtValue.Year);
        }

        private void txtChungtu_Goc_EditValueChanged(object sender, EventArgs e)
        {
            //if (FormState != GoobizFrame.Windows.Forms.FormState.View)
            //    if ("" + txtChungtu_Goc.EditValue != "")
            //    {
            //        txtSotien_Quydoi.Enabled = true;
            //        lookUpEdit_Nguoinop.Properties.ReadOnly = true;
            //        lookUpEdit_Nguoinop.Properties.Buttons[1].Enabled = false;
            //        this.lookUpEditMa_Kho_Hanghoa.Properties.ReadOnly = true;
            //    }
            //    else
            //    {
            //        txtSotien_Quydoi.Enabled = false;
            //        lookUpEdit_Nguoinop.Properties.ReadOnly = false;
            //        lookUpEdit_Nguoinop.Properties.Buttons[1].Enabled = true;
            //        this.lookUpEditMa_Kho_Hanghoa.Properties.ReadOnly = false;
            //    }
        }

        #endregion

        #region Custom Method

        public void set_Chungtu_Goc(DataRow dr_Hdmuahang, decimal sotien_conlai, object Ma_Nhacungcap)
        {
            this.ChangeFormState(GoobizFrame.Windows.Forms.FormState.Add);
            this.PerformAdd();
            lookUpEditMa_NCC.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Doituong().ToDataSet().Tables[0];
            txtChungtu_Goc.EditValue = dr_Hdmuahang["Sochungtu"];
            lookUpEditMa_NCC.EditValue = "KH - " + Ma_Nhacungcap.ToString();
            txtSotien_Quydoi.EditValue = sotien_conlai;
            Sotien_Conlai = sotien_conlai;
            flag = true;
        }

        private void lookUpEditMa_Kho_Hanghoa_EditValueChanged(object sender, EventArgs e)
        {
            //if ("" + lookUpEdit_Khuvuc.EditValue == "") return;
            //lookUpEditMa_NCC.Properties.DataSource = objMasterService.Ware_Dm_Khachhang_SelectBy_Khuvuc_New(lookUpEdit_Khuvuc.EditValue).ToDataSet().Tables[0];
        }

        #endregion

        private void btnFilter_Click(object sender, EventArgs e)
        {
            Load_Gridview();
        }

        void Load_Gridview()
        {
            if ("" + lookUpEdit_Soquy.EditValue == "")
            {
                //GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn sổ quỹ, vui lòng chọn lại");
                lookUpEdit_Soquy.Focus();
                return;
            }
            dsCollection = objWareService.GetAll_Ware_Phieu_Chi_Date(lookUpEdit_Soquy.EditValue, dtThang_Nam.DateTime).ToDataSet();
            dgware_Phieu_Chi.DataSource = dsCollection;
            dgware_Phieu_Chi.DataMember = dsCollection.Tables[0].TableName;
        }

        private void lookUpEditNhansu_Nop_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEditNhansu_Nhan.EditValue == null)
                txtNguoi_Nhan.EditValue = null;
            else
                txtNguoi_Nhan.EditValue = lookUpEditNhansu_Nhan.GetColumnValue("Hoten_Nhansu");
        }

    }
}

