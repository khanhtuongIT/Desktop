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
    public partial class Frmware_Phantich_Thitruong : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();

        DataSet ds_phantich_thitruong = new DataSet();
        DataSet ds_phantich_thitruong_Chitiet = new DataSet();
        DataSet ds_Hanghoa_Ban = new DataSet();
        DataSet ds_Nhansu;
        object identity;
        object id_nhansu_current;
        //public DataRow[] _selectedRows;

        public Frmware_Phantich_Thitruong()
        {
            InitializeComponent();
            id_nhansu_current = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu();
            item_Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            dtNgay_Chungtu_View.EditValue = objWareService.GetServerDateTime();
        }

        void LoadMasterData()
        {
            ds_Nhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
            DataRow row = ds_Nhansu.Tables[0].NewRow();
            row["Id_Nhansu"] = -1;
            row["Ma_Nhansu"] = "All";
            row["Hoten_Nhansu"] = "Tất cả";
            ds_Nhansu.Tables[0].Rows.Add(row);
            lookUpEdit_Nhansu_Banhang.Properties.DataSource = ds_Nhansu.Tables[0];
            lookUpEdit_Nhansu_View.Properties.DataSource = ds_Nhansu.Tables[0];
            lookUpEdit_Nhansu_View.EditValue = Convert.ToInt64(-1);
            DataSet ds_collection = objMasterService.GetRole_System_Name_ById_User(id_nhansu_current).ToDataSet();
            if (ds_collection.Tables[0].Rows.Count > 0 &&
                "" + ds_collection.Tables[0].Rows[0]["Role_System_Name"] != "Administrators")
            {
                lookUpEdit_Nhansu_View.EditValue = Convert.ToInt64(id_nhansu_current);
                lookUpEdit_Nhansu_View.Enabled = false;
            }
            ds_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa().ToDataSet();
            gridLookUpEdit_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
            gridLookUpEdit_Ma_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];

            DataSet dsCuahang = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().ToDataSet();
            lookUpEditKhuvuc.Properties.DataSource = dsCuahang.Tables[0];
            gridLookupEdit_Khuvuc.DataSource = dsCuahang.Tables[0];
        }

        void Load_Gridview()
        {
            object id_nhansu = (Convert.ToInt64(lookUpEdit_Nhansu_View.EditValue) == -1) ? null : lookUpEdit_Nhansu_View.EditValue;
            ds_phantich_thitruong = objWareService.Ware_Phantich_Thitruong_SelectAll(id_nhansu, dtNgay_Chungtu_View.EditValue).ToDataSet();
            dgware_Phantich_Thitruong.DataSource = ds_phantich_thitruong;
            dgware_Phantich_Thitruong.DataMember = ds_phantich_thitruong.Tables[0].TableName;
        }

        #region Event Override
        /// <summary>
        /// load master data
        /// </summary>
        public override void DisplayInfo()
        {
            //Set lại trạng thái form là view
            FormState = GoobizFrame.Windows.Forms.FormState.View;
            try
            {
                ResetText();
                LoadMasterData();
                Load_Gridview();
                this.ChangeStatus(false);
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
            }
        }

        public override void ClearDataBindings()
        {
            this.dtNgay_Taophieu.DataBindings.Clear();
            this.lookUpEdit_Nhansu_Banhang.DataBindings.Clear();
            lookUpEditKhuvuc.DataBindings.Clear();
            txtTuyen_Banhang.DataBindings.Clear();
            txtGhinhan_Them.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                //ClearDataBindings();
                dtNgay_Taophieu.DataBindings.Add("EditValue", ds_phantich_thitruong, ds_phantich_thitruong.Tables[0].TableName + ".Ngay_Taophieu");
                lookUpEdit_Nhansu_Banhang.DataBindings.Add("EditValue", ds_phantich_thitruong, ds_phantich_thitruong.Tables[0].TableName + ".Id_Nhansu");
                lookUpEditKhuvuc.DataBindings.Add("EditValue", ds_phantich_thitruong, ds_phantich_thitruong.Tables[0].TableName + ".Id_Khuvuc");
                txtTuyen_Banhang.DataBindings.Add("EditValue", ds_phantich_thitruong, ds_phantich_thitruong.Tables[0].TableName + ".Tuyen_Banhang");
                txtGhinhan_Them.DataBindings.Add("EditValue", ds_phantich_thitruong, ds_phantich_thitruong.Tables[0].TableName + ".Ghichu");
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
            tableLayoutPanel_Top_Left.Enabled = !editTable;
            this.dgware_Phantich_Thitruong.Enabled = !editTable;
            gvPhantich_Thitruong_Chitiet.OptionsBehavior.Editable = editTable;
            lookUpEditKhuvuc.Properties.ReadOnly = !editTable;
            txtGhinhan_Them.Properties.ReadOnly = !editTable;
            txtTuyen_Banhang.Properties.ReadOnly = !editTable;
        }

        public override void ResetText()
        {
            lookUpEditKhuvuc.EditValue = null;
            txtTuyen_Banhang.EditValue = null;
            txtGhinhan_Them.EditValue = null;
            lookUpEdit_Nhansu_Banhang.EditValue = null;
            dtNgay_Taophieu.EditValue = null;
            this.ds_phantich_thitruong_Chitiet = objWareService.Get_All_Ware_Hdbanhang_Chitiet_By_Hdbanhang(-1).ToDataSet();
            this.dgware_Phantich_Thitruong_Chitiet.DataSource = ds_phantich_thitruong_Chitiet.Tables[0];
        }

        public object InsertObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Phantich_Thitruong _Ware_Phantich_Thitruong = new Ecm.WebReferences.WareService.Ware_Phantich_Thitruong();
                _Ware_Phantich_Thitruong.Ngay_Taophieu = dtNgay_Taophieu.EditValue;
                _Ware_Phantich_Thitruong.Id_Nhansu = lookUpEdit_Nhansu_Banhang.EditValue;
                _Ware_Phantich_Thitruong.Id_Khuvuc = ("" + lookUpEditKhuvuc.EditValue != "") ? lookUpEditKhuvuc.EditValue : -1;
                _Ware_Phantich_Thitruong.Tuyen_Banhang = txtTuyen_Banhang.EditValue;
                _Ware_Phantich_Thitruong.Ghichu = txtGhinhan_Them.EditValue;
                identity = objWareService.Ware_Phantich_Thitruong_Insert(_Ware_Phantich_Thitruong);
                if (identity != null)
                {
                    DoClickEndEdit(dgware_Phantich_Thitruong_Chitiet);
                    foreach (DataRow dr in ds_phantich_thitruong_Chitiet.Tables[0].Rows)
                    {
                        if (dr.RowState != DataRowState.Deleted)
                            dr["Id_Phantich_Thitruong"] = identity;
                    }
                    objWareService.Update_Ware_Phantich_Thitruong_Chitiet_Collection(ds_phantich_thitruong_Chitiet);
                }
                return true;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
                return false;
            }
        }

        public object UpdateObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Phantich_Thitruong _Ware_Phantich_Thitruong = new Ecm.WebReferences.WareService.Ware_Phantich_Thitruong();
                _Ware_Phantich_Thitruong.Ngay_Taophieu = dtNgay_Taophieu.EditValue;
                _Ware_Phantich_Thitruong.Id_Nhansu = lookUpEdit_Nhansu_Banhang.EditValue;
                _Ware_Phantich_Thitruong.Id_Khuvuc = ("" + lookUpEditKhuvuc.EditValue != "") ? lookUpEditKhuvuc.EditValue : -1;
                _Ware_Phantich_Thitruong.Tuyen_Banhang = txtTuyen_Banhang.EditValue;
                _Ware_Phantich_Thitruong.Ghichu = txtGhinhan_Them.EditValue;
                objWareService.Ware_Phantich_Thitruong_Update(_Ware_Phantich_Thitruong);
                this.DoClickEndEdit(dgware_Phantich_Thitruong_Chitiet);
                foreach (DataRow dr in ds_phantich_thitruong_Chitiet.Tables[0].Rows)
                {
                    if (dr.RowState == DataRowState.Added)
                        dr["Id_Phantich_Thitruong"] = identity;
                }
                objWareService.Update_Ware_Phantich_Thitruong_Chitiet_Collection(ds_phantich_thitruong_Chitiet);
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
            return objWareService.Ware_Phantich_Thitruong_Delete(identity);
        }

        public override bool PerformAdd()
        {
            this.ResetText();
            this.ChangeStatus(true);
            lookUpEdit_Nhansu_Banhang.EditValue = Convert.ToInt64(id_nhansu_current);
            dtNgay_Taophieu.EditValue = objWareService.GetServerDateTime();
            this.ds_phantich_thitruong_Chitiet = objWareService.Ware_Phantich_Thitruong_Chitiet_SelectBy_Id_Phantich_Thitruong(-1).ToDataSet();
            this.dgware_Phantich_Thitruong_Chitiet.DataSource = ds_phantich_thitruong_Chitiet.Tables[0];
            return true;
        }

        public override bool PerformEdit()
        {
            if ("" + gvPhantich_Thitruong.GetFocusedRowCellValue("Id_Phantich_Thitruong") == "")
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn đơn hàng, vui lòng chọn lại");
                return false;
            }
            this.ChangeStatus(true);
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
                System.Collections.Hashtable htbControl1 = new System.Collections.Hashtable();
                //htbControl1.Add(txtSotien_Vat, lblSotien_Vat.Text);
                //htbControl1.Add(lookUpEdit_Cuahang_Ban, lblCuahang_Ban.Text);
                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(htbControl1))
                    return false;
                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                {
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                    success = (bool)this.UpdateObject();
                if (success)
                {
                    this.DisplayInfo();
                }
                return success;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return false;
            }
        }

        public override bool PerformDelete()
        {
            if (GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUser().ToUpper() != "ADMIN")
                if (!id_nhansu_current.Equals("" + lookUpEdit_Nhansu_Banhang.EditValue))
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                    return false;
                }
            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Hdbanhang"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Hdbanhang")   }) == DialogResult.Yes)
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
            return base.PerformDelete();
        }

        public override bool PerformPrintPreview()
        {
            if (identity == null)
                return false;
            try
            {
                DataRow[] sdr = ds_phantich_thitruong.Tables[0].Select("Id_Hdbanhang = " + identity);
                DataSets.dsHdbanhang_Chitiet dsrHdbanhang_Chitiet = new Ecm.Ware.DataSets.dsHdbanhang_Chitiet();
                Reports.rptHdbanhang_noVAT rptHdbanhang_noVAT = new Ecm.Ware.Reports.rptHdbanhang_noVAT();
                GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
                frmPrintPreview.Report = rptHdbanhang_noVAT;
                //frmPrintPreview.Name = this.Name;
                //frmPrintPreview.EnablePrintPreview = this.EnablePrintPreview;
                rptHdbanhang_noVAT.DataSource = dsrHdbanhang_Chitiet;
                int i = 1;
                foreach (DataRow dr in ds_phantich_thitruong_Chitiet.Tables[0].Rows)
                {
                    DataRow drnew = dsrHdbanhang_Chitiet.Tables[0].NewRow();
                    foreach (DataColumn dc in ds_phantich_thitruong_Chitiet.Tables[0].Columns)
                    {
                        try
                        {
                            drnew[dc.ColumnName] = dr[dc.ColumnName];
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    drnew["Ten_Hanghoa"] = dr["Ten_Hanghoa_Ban"];
                    drnew["Ma_Hanghoa"] = dr["Ma_Hanghoa_Ban"];
                    drnew["Stt"] = i++;
                    dsrHdbanhang_Chitiet.Tables[0].Rows.Add(drnew);
                }
                //add parameter values
                rptHdbanhang_noVAT.xrLbl_Tieude.Text = "HÓA ĐƠN KHÁCH HÀNG";
                rptHdbanhang_noVAT.tbc_Ngay.Text = "" + string.Format("{0:dd/MM/yyyy hh:mm:ss tt}", sdr[0]["Ngay_Chungtu"]);
                lookUpEdit_Nhansu_Banhang.EditValue = sdr[0]["Id_Nhansu_Bh"];
                rptHdbanhang_noVAT.lblNhansu_Bill.Text = lookUpEdit_Nhansu_Banhang.Text;
                DataRow[] sdrKhachhang = null;
                //if (Convert.ToInt32(sdr[0]["Id_Khachhang"]) != -1)
                //{
                //    sdrKhachhang = ds_Khachhang.Tables[0].Select("Id_Khachhang=" + sdr[0]["Id_Khachhang"]);
                //    rptHdbanhang_noVAT.lblKhachhang.Text = "" +
                //       ((sdrKhachhang != null && sdrKhachhang.Length > 0) ? sdrKhachhang[0]["Ten_Khachhang"] : "");
                //}
                rptHdbanhang_noVAT.tbcSochungtu.Text = sdr[0]["Sochungtu"].ToString();
                double thanhtien = Convert.ToDouble(ds_phantich_thitruong_Chitiet.Tables[0].Compute("sum(Thanhtien_TG)", ""));
                string str = GoobizFrame.Windows.HelperClasses.ReadNumber.ChangeNum2VNStr(thanhtien, " đồng.");
                str = str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower();
                rptHdbanhang_noVAT.tbcThanhtien_Bangchu.Text = str;
                rptHdbanhang_noVAT.lblTongcong.Text = thanhtien.ToString();
                rptHdbanhang_noVAT.PageSize = new Size(800, 2000 + 120 * Convert.ToInt32(dsrHdbanhang_Chitiet.Tables[0].Rows.Count));
                rptHdbanhang_noVAT.xrTable6.Location = new System.Drawing.Point(21, 42);
                rptHdbanhang_noVAT.xrTable4.Location = new System.Drawing.Point(21, 135);
                DataSet dsHeso_Chuongtrinh;
                #region Set he so ctrinh - logo, ten cty
                using (DataSet dsCompany_Paras = new DataSet())
                {
                    dsCompany_Paras.Tables.Add("Company_Paras");
                    dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                    dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                    dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                    dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet();
                    byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                    dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData});

                    rptHdbanhang_noVAT.xrc_CompanyName.DataBindings.Add(
                        new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                    rptHdbanhang_noVAT.xrc_CompanyAddress.DataBindings.Add(
                        new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                    rptHdbanhang_noVAT.xrPic_Logo.DataBindings.Add(
                        new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
                }
                #endregion

                rptHdbanhang_noVAT.CreateDocument();
                GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(rptHdbanhang_noVAT);
                if (Convert.ToBoolean(oReportOptions.PrintPreview))
                {
                    frmPrintPreview.Text = "" + oReportOptions.Caption;
                    frmPrintPreview.printControl1.PrintingSystem = rptHdbanhang_noVAT.PrintingSystem;
                    frmPrintPreview.MdiParent = this.MdiParent;
                    frmPrintPreview.Text = this.Text + "(Xem trang in)";
                    frmPrintPreview.Show();
                    frmPrintPreview.Activate();
                }
                else
                {
                    var reportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rptHdbanhang_noVAT);
                    reportPrintTool.Print();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return base.PerformPrintPreview();
        }

        #endregion

        void DisplayInfo_Details()
        {
            identity = gvPhantich_Thitruong.GetFocusedRowCellValue("Id_Phantich_Thitruong");
            this.ds_phantich_thitruong_Chitiet = objWareService.Ware_Phantich_Thitruong_Chitiet_SelectBy_Id_Phantich_Thitruong(identity).ToDataSet();
            this.dgware_Phantich_Thitruong_Chitiet.DataSource = ds_phantich_thitruong_Chitiet.Tables[0];
            gvPhantich_Thitruong_Chitiet.BestFitColumns();
            DataBindingControl();
        }

        private void gvHoadon_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ClearDataBindings();
            ResetText();
            if (e.FocusedRowHandle >= 0)
                DisplayInfo_Details();
        }

        private void Frmware_Hdbanhang_noVAT_Hhban_Load(object sender, EventArgs e)
        {
            DisplayInfo();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            Load_Gridview();
        }

        private void gvPhantich_Thitruong_Chitiet_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //Kiem tra so luong ton
            this.DoClickEndEdit(dgware_Phantich_Thitruong_Chitiet);
            if (e.Column.FieldName == "Dongia_Doithu" || e.Column.FieldName == "Hotro_Tienmat"
                || e.Column.FieldName == "Khuyenmai_Khac" || e.Column.FieldName == "Vanchuyen"
                || e.Column.FieldName == "Bocvac" || e.Column.FieldName == "Khoiluong_25_40")
            {
                decimal tongcong_hotro = Convert.ToDecimal("0" + gvPhantich_Thitruong_Chitiet.GetFocusedRowCellValue("Hotro_Tienmat"))
                                        + Convert.ToDecimal("0" + gvPhantich_Thitruong_Chitiet.GetFocusedRowCellValue("Khuyenmai_Khac"))
                                        + Convert.ToDecimal("0" + gvPhantich_Thitruong_Chitiet.GetFocusedRowCellValue("Vanchuyen"))
                                        + Convert.ToDecimal("0" + gvPhantich_Thitruong_Chitiet.GetFocusedRowCellValue("Bocvac"));
                gvPhantich_Thitruong_Chitiet.SetFocusedRowCellValue("Tongcong_Hotro", tongcong_hotro);
                decimal giaban_tailo = Convert.ToDecimal("0" + gvPhantich_Thitruong_Chitiet.GetFocusedRowCellValue("Dongia_Doithu")) - tongcong_hotro;
                decimal khoiluong_25_40 = (Convert.ToDecimal("0" + gvPhantich_Thitruong_Chitiet.GetFocusedRowCellValue("Khoiluong_25_40")) == 0) ? 1 : Convert.ToDecimal("0" + gvPhantich_Thitruong_Chitiet.GetFocusedRowCellValue("Khoiluong_25_40"));
                gvPhantich_Thitruong_Chitiet.SetFocusedRowCellValue("Giaban_Tailo", giaban_tailo);
                gvPhantich_Thitruong_Chitiet.SetFocusedRowCellValue("Thanhtien_Tailo", giaban_tailo * khoiluong_25_40);
            }
            gvPhantich_Thitruong_Chitiet.BestFitColumns();
        }


    }
}