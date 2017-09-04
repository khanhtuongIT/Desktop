using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Phieu_Thu_Ds : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet dsPhieuthu = new DataSet();
        DataSet dsPhieuthu_Chitiet = new DataSet();
        object _id_phieuthu;
        object id_nhansu_current;
        DataSet ds_Role_User;
        DataSet dsKhachhang;
        object gui_ctu;
        int sotien = 0;

        public Frmware_Phieu_Thu_Ds()
        {
            InitializeComponent();
            dtNgay_Chungtu.Properties.MinValue = new DateTime(2000, 01, 01);
            dtNgay_Chungtu.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgay_Chungtu.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();
            id_nhansu_current = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu();
            ds_Role_User = objMasterService.GetRole_System_Name_ById_User(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUserId()).ToDataSet();
            item_Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            dtThang_Nam.EditValue = DateTime.Now;
            this.DisplayInfo();
        }

        #region Event Override

        public override void DisplayInfo()
        {
            try
            {
                gui_ctu = Guid.Empty;
                this.ChangeFormState(GoobizFrame.Windows.Forms.FormState.View);
                DataSet dsNhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
                lookUpEdit_Nhansu_Lapphieu.Properties.DataSource = dsNhansu.Tables[0];
                lookUpEditNhansu_Nop.Properties.DataSource = dsNhansu.Tables[0];

                dsKhachhang = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
                gridLookupEdit_Khachhang.DataSource = dsKhachhang.Tables[0];
                //Get data Get_All_Ware_Dm_Doituong
                lookUpEdit_Cuahang_Ban.Properties.DataSource = objMasterService.Ware_Dm_Cuahang_Ban_Select_Sale().ToDataSet().Tables[0];
                this.ChangeStatus(false);
                this.gvPhieuthu_Chitiet.BestFitColumns();
                lookUpEdit_Soquy.Properties.DataSource = objMasterService.GetAll_Ware_Dm_Soquy(null).ToDataSet().Tables[0];
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
            this.txtSochungtu.DataBindings.Clear();
            this.dtNgay_Chungtu.DataBindings.Clear();
            this.txtNguoi_Nop.DataBindings.Clear();
            this.lookUpEdit_Nhansu_Lapphieu.DataBindings.Clear();
            lookUpEdit_Cuahang_Ban.DataBindings.Clear();

        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtSochungtu.DataBindings.Add("EditValue", dsPhieuthu_Chitiet, dsPhieuthu_Chitiet.Tables[0].TableName + ".Sochungtu");
                this.dtNgay_Chungtu.DataBindings.Add("EditValue", dsPhieuthu_Chitiet, dsPhieuthu_Chitiet.Tables[0].TableName + ".Ngay_Chungtu");
                this.txtNguoi_Nop.DataBindings.Add("EditValue", dsPhieuthu_Chitiet, dsPhieuthu_Chitiet.Tables[0].TableName + ".Nguoi_Nop");
                this.lookUpEdit_Nhansu_Lapphieu.DataBindings.Add("EditValue", dsPhieuthu_Chitiet, dsPhieuthu_Chitiet.Tables[0].TableName + ".Id_Nhansu_Lapphieu");
                this.lookUpEdit_Cuahang_Ban.DataBindings.Add("EditValue", dsPhieuthu_Chitiet, dsPhieuthu_Chitiet.Tables[0].TableName + ".Id_Khuvuc");
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
            lookUpEditNhansu_Nop.Properties.ReadOnly = !editable;
            txtNguoi_Nop.Properties.ReadOnly = !editable;
            lookUpEdit_Cuahang_Ban.Properties.ReadOnly = !editable;
            gridColumnDelete.Visible = editable;
            dgPhieu_Thu.Enabled = !editable;
            gvPhieuthu_Chitiet.OptionsBehavior.Editable = editable;
            splitContainerControl1.Panel1.Enabled = !editable;
        }

        public override void ResetText()
        {
            this.txtNguoi_Nop.Text = "";
            lookUpEditNhansu_Nop.EditValue = null;
            this.lookUpEdit_Cuahang_Ban.EditValue = null;
            dtNgay_Chungtu.EditValue = null;
            this.lookUpEdit_Nhansu_Lapphieu.EditValue = null;// Convert.ToInt64(id_nhansu_current);
            txtSochungtu.EditValue = null;
            dgPhieuthu_Chitiet.DataSource = null;
        }

        public override bool PerformCancel()
        {
            this.DisplayInfo();
            this.ChangeStatus(false);
            return true;
        }

        public object InsertObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Phieu_Thu objWare_Phieu_Thu = new Ecm.WebReferences.WareService.Ware_Phieu_Thu();
                objWare_Phieu_Thu.Id_Phieu_Thu = -1;
                objWare_Phieu_Thu.Sochungtu = txtSochungtu.EditValue;
                objWare_Phieu_Thu.Ngay_Chungtu = dtNgay_Chungtu.EditValue;
                objWare_Phieu_Thu.Ten_Doituong = null;
                objWare_Phieu_Thu.Nguoi_Nop = txtNguoi_Nop.Text;
                objWare_Phieu_Thu.Id_Tiente = null;
                objWare_Phieu_Thu.Guid_Ctu = Guid.NewGuid();
                objWare_Phieu_Thu.Id_Khachhang = null; // lookUpEdit_Ma_Khachhang.EditValue;
                if ("" + lookUpEdit_Nhansu_Lapphieu.EditValue != "")
                    objWare_Phieu_Thu.Id_Nhansu_Lapphieu = lookUpEdit_Nhansu_Lapphieu.EditValue;

                if ("" + lookUpEdit_Cuahang_Ban.GetColumnValue("Id_Kho_Hanghoa_Mua") != "")
                    objWare_Phieu_Thu.Id_Kho_Hanghoa_Mua = lookUpEdit_Cuahang_Ban.GetColumnValue("Id_Kho_Hanghoa_Mua");

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
                objWare_Phieu_Thu.Ten_Doituong = null;
                objWare_Phieu_Thu.Id_Khachhang = null;// lookUpEdit_Ma_Khachhang.EditValue;
                objWare_Phieu_Thu.Nguoi_Nop = txtNguoi_Nop.Text;
                objWare_Phieu_Thu.Id_Tiente = null;
                if ("" + lookUpEdit_Nhansu_Lapphieu.EditValue != "")
                    objWare_Phieu_Thu.Id_Nhansu_Lapphieu = lookUpEdit_Nhansu_Lapphieu.EditValue;

                if ("" + lookUpEdit_Cuahang_Ban.GetColumnValue("Id_Kho_Hanghoa_Mua") != "")
                    objWare_Phieu_Thu.Id_Kho_Hanghoa_Mua = lookUpEdit_Cuahang_Ban.GetColumnValue("Id_Kho_Hanghoa_Mua");

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
            if (lookUpEdit_Soquy.EditValue == null)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn sổ quỹ, vui lòng chọn lại");
                lookUpEdit_Soquy.Focus();
                return false;
            }
            //ClearDataBindings();
            this.ResetText();
            this.ChangeStatus(true);
            gui_ctu = Guid.NewGuid();
            lookUpEdit_Nhansu_Lapphieu.EditValue = Convert.ToInt64(id_nhansu_current);
            txtSochungtu.EditValue = objWareService.GetNew_Sochungtu("ware_phieu_thu", "sochungtu", "THU_" + lookUpEdit_Soquy.GetColumnValue("Ma_Soquy") + "-");
            dtNgay_Chungtu.EditValue = objWareService.GetServerDateTime();
            dsPhieuthu_Chitiet = objWareService.Ware_Phieu_Thu_SelectBy_PhieuXuat(null).ToDataSet();
            dgPhieuthu_Chitiet.DataSource = dsPhieuthu_Chitiet;
            dgPhieuthu_Chitiet.DataMember = dsPhieuthu_Chitiet.Tables[0].TableName;
            this.Data = dsPhieuthu_Chitiet;
            this.GridControl = dgPhieuthu_Chitiet;
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
            this.ChangeStatus(true);
            dsPhieuthu_Chitiet = objWareService.Ware_Phieu_Thu_SelectBy_Guid_Ctu_Edit("" + gvPhieuThu.GetFocusedRowCellValue("Guid_Ctu")).ToDataSet();
            dgPhieuthu_Chitiet.DataSource = dsPhieuthu_Chitiet;
            dgPhieuthu_Chitiet.DataMember = dsPhieuthu_Chitiet.Tables[0].TableName;
            return true;
        }

        public override bool PerformSave()
        {
            return PerformSaveChanges();
        }

        public override bool PerformSaveChanges()
        {
            try
            {
                DoClickEndEdit(dgPhieuthu_Chitiet);
                foreach (DataRow row in dsPhieuthu_Chitiet.Tables[0].Rows)
                {
                    if (row.RowState != DataRowState.Deleted)
                        row["Nguoi_Nop"] = "" + txtNguoi_Nop.Text;
                }
                objWareService.Update_Ware_Phieu_Thu_Collection2(dsPhieuthu_Chitiet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            this.DisplayInfo();
            return base.PerformSaveChanges();
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

                    if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[] {
                     GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Phieu_Thu"),
                     GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Phieu_Thu") }) == DialogResult.Yes)
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
            rptPhieu_Thu.tbcNam.Text = "" + dtNgay_Chungtu.DateTime.Year;
            rptPhieu_Thu.tbcThang.Text = "" + dtNgay_Chungtu.DateTime.Month;
            rptPhieu_Thu.tbcNgay.Text = "" + dtNgay_Chungtu.DateTime.Day;
            rptPhieu_Thu.tbcNguoi_Noptien.Text = txtNguoi_Nop.Text;
            rptPhieu_Thu.tbcNguoi_Noptien_Kyten.Text = "" + txtNguoi_Nop.Text;
            rptPhieu_Thu.tbcNhansu_Lapphieu.Text = "" + lookUpEdit_Nhansu_Lapphieu.Text;
            rptPhieu_Thu.tbcSochungtu.Text = txtSochungtu.Text;
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

                dsCompany_Paras.Tables[0].Rows.Add(new object[] { dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyName"))[0]["Heso"]
                        , dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyAddress"))[0]["Heso"]
                        , imageData
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
        }

        #endregion

        void Load_Gridview()
        {
            dsPhieuthu = objWareService.Ware_Phieu_Thu_SelectAll_New(lookUpEdit_Soquy.EditValue, dtThang_Nam.DateTime, null).ToDataSet();
            dgPhieu_Thu.DataSource = dsPhieuthu;
            dgPhieu_Thu.DataMember = dsPhieuthu.Tables[0].TableName;
            gvPhieuThu.BestFitColumns();
        }

        private void lookUpEditNhansu_Nop_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEditNhansu_Nop.EditValue == null)
                txtNguoi_Nop.EditValue = null;
            else
                txtNguoi_Nop.EditValue = lookUpEditNhansu_Nop.GetColumnValue("Hoten_Nhansu");
        }

        private void lookUpEdit_Cuahang_Ban_EditValueChanged(object sender, EventArgs e)
        {
            if ("" + lookUpEdit_Cuahang_Ban.Text != "")
            {
                if (FormState != GoobizFrame.Windows.Forms.FormState.View)
                {
                    gridLookupEdit_Chungtu_Goc.DataSource = objWareService.Ware_Phieu_Thu_SelectXuatkho_NotPay_ById_Cuahang_Ban(lookUpEdit_Cuahang_Ban.EditValue).ToDataSet().Tables[0];
                    gridLookupEdit_Khachhang.DataSource = objMasterService.Ware_Dm_Khachhang_SelectBy_Khuvuc(lookUpEdit_Cuahang_Ban.EditValue).ToDataSet().Tables[0];
                }
                else
                    gridLookupEdit_Chungtu_Goc.DataSource = objWareService.Ware_Phieu_Thu_SelectPhieu_Xuatkho_ById_Cuahang_Ban(lookUpEdit_Cuahang_Ban.EditValue).ToDataSet().Tables[0];
            }
        }

        private void gvPhieuthu_Chitiet_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvPhieuthu_Chitiet.SetFocusedRowCellValue("Sochungtu", txtSochungtu.EditValue);
            gvPhieuthu_Chitiet.SetFocusedRowCellValue("Ngay_Chungtu", dtNgay_Chungtu.EditValue);
            gvPhieuthu_Chitiet.SetFocusedRowCellValue("Id_Cuahang_Ban", lookUpEdit_Soquy.EditValue);
            gvPhieuthu_Chitiet.SetFocusedRowCellValue("Nguoi_Nop", "" + txtNguoi_Nop.Text);
            gvPhieuthu_Chitiet.SetFocusedRowCellValue("Guid_Ctu", "" + gui_ctu);
            gvPhieuthu_Chitiet.SetFocusedRowCellValue("Id_Nhansu_Lapphieu", id_nhansu_current);
            gvPhieuthu_Chitiet.FocusedColumn = gvPhieuthu_Chitiet.VisibleColumns[0];
        }

        private void gvPhieuthu_Chitiet_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Ma_Doituong")
            {
                if ("" + gvPhieuthu_Chitiet.GetFocusedRowCellValue("Ma_Doituong") == "") return;
                DataRow[] dtr = dsKhachhang.Tables[0].Select("Ma_Khachhang = '" + gvPhieuthu_Chitiet.GetFocusedRowCellValue("Ma_Doituong") + "' ", "");
                gvPhieuthu_Chitiet.SetFocusedRowCellValue("Ten_Doituong", dtr[0]["Ten_Khachhang"]);
                gvPhieuthu_Chitiet.SetFocusedRowCellValue("Diachi", dtr[0]["Diachi_Khachhang"]);
            }
        }

        private void gvPhieuthu_Chitiet_KeyDown(object sender, KeyEventArgs e)
        {
            if (gvPhieuthu_Chitiet.FocusedColumn.VisibleIndex == gvPhieuthu_Chitiet.VisibleColumns.Count - 1
                && e.KeyCode == Keys.Enter
                && "" + gvPhieuthu_Chitiet.GetFocusedRowCellValue("Ma_Doituong") != "" && gvPhieuthu_Chitiet.FocusedRowHandle == gvPhieuthu_Chitiet.RowCount - 1)
                gvPhieuthu_Chitiet.AddNewRow();
        }

        private void gridButtonEdit_Delete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
                gvPhieuthu_Chitiet.DeleteRow(gvPhieuthu_Chitiet.FocusedRowHandle);
        }

        private void dtThang_Nam_EditValueChanged(object sender, EventArgs e)
        {
            Load_Gridview();
        }

        private void lookUpEdit_Soquy_EditValueChanged(object sender, EventArgs e)
        {
            Load_Gridview();
        }

        private void gvPhieuThu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if ("" + gvPhieuThu.GetFocusedRowCellValue("Guid_Ctu") == "")
                    ResetText();
                else
                {
                    dsPhieuthu_Chitiet = objWareService.Ware_Phieu_Thu_SelectBy_Guid_Ctu(gvPhieuThu.GetFocusedRowCellValue("Guid_Ctu")).ToDataSet();
                    dgPhieuthu_Chitiet.DataSource = dsPhieuthu_Chitiet;
                    dgPhieuthu_Chitiet.DataMember = dsPhieuthu_Chitiet.Tables[0].TableName;
                    DataBindingControl();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

    }
}
