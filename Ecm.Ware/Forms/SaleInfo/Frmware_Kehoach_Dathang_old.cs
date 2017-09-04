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
    public partial class Frmware_Kehoach_Dathang_old : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();

        DataSet ds_Kehoach_Dathang = new DataSet();
        DataSet ds_Kehoach_Dathang_Chitiet = new DataSet();
        DataSet ds_Hanghoa_Ban = new DataSet();
        DataSet ds_Khachhang;
        DataSet ds_Nhansu;        
        object identity;
        object id_nhansu_current;
        //public DataRow[] _selectedRows;

        #region Initialize

        public Frmware_Kehoach_Dathang_old()
        {
            InitializeComponent();
            xtraTabControl_Main.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
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
            lookUpEdit_Nhansu.Properties.DataSource = ds_Nhansu.Tables[0];
            lookUpEdit_Nhansu_View.Properties.DataSource = ds_Nhansu.Tables[0];
            gridLookupEdit_Nhansu_View.DataSource = ds_Nhansu.Tables[0];
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

            ds_Khachhang = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
            gridLookupEdit_Khachhang.DataSource = ds_Khachhang.Tables[0];
        }

        void Load_Gridview()
        {
            object id_nhansu = (Convert.ToInt64(lookUpEdit_Nhansu_View.EditValue) == -1) ? null : lookUpEdit_Nhansu_View.EditValue;
            ds_Kehoach_Dathang = objWareService.Ware_Kehoach_Dathang_GetAll(id_nhansu, dtNgay_Chungtu_View.EditValue).ToDataSet();
            dgware_Kehoach.DataSource = ds_Kehoach_Dathang;
            dgware_Kehoach.DataMember = ds_Kehoach_Dathang.Tables[0].TableName;
        }

        #endregion

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
            this.dtNgay_Batdau.DataBindings.Clear();
            this.lookUpEdit_Nhansu.DataBindings.Clear();
            dtNgay_Ketthuc.DataBindings.Clear();
            txGhichu.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                //ClearDataBindings();
                this.dtNgay_Batdau.DataBindings.Add("EditValue", ds_Kehoach_Dathang, ds_Kehoach_Dathang.Tables[0].TableName + ".Ngay_Batdau");
                dtNgay_Ketthuc.DataBindings.Add("EditValue", ds_Kehoach_Dathang, ds_Kehoach_Dathang.Tables[0].TableName + ".Ngay_Ketthuc");
                txGhichu.DataBindings.Add("EditValue", ds_Kehoach_Dathang, ds_Kehoach_Dathang.Tables[0].TableName + ".Ghichu");
                this.lookUpEdit_Nhansu.DataBindings.Add("EditValue", ds_Kehoach_Dathang, ds_Kehoach_Dathang.Tables[0].TableName + ".Id_Nhansu");
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
            this.dgware_Kehoach.Enabled = !editTable;
            gvKehoach_Chitiet.OptionsBehavior.Editable = editTable;
            dtNgay_Ketthuc.Properties.ReadOnly = !editTable;
            dtNgay_Batdau.Properties.ReadOnly = !editTable;
            txGhichu.Properties.ReadOnly = !editTable;
        }

        public override void ResetText()
        {
            txGhichu.EditValue = null;
            lookUpEdit_Nhansu.EditValue = null;
            dtNgay_Batdau.EditValue = null;
            dtNgay_Ketthuc.EditValue = null;
            this.ds_Kehoach_Dathang_Chitiet = objWareService.Get_All_Ware_Hdbanhang_Chitiet_By_Hdbanhang(-1).ToDataSet();
            this.dgware_Kehoach_Chitiet.DataSource = ds_Kehoach_Dathang_Chitiet.Tables[0];
        }

        public object InsertObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Kehoach_Dathang objWare_kehoach = new Ecm.WebReferences.WareService.Ware_Kehoach_Dathang();
                objWare_kehoach.Ngay_Batdau = dtNgay_Batdau.EditValue;
                objWare_kehoach.Ngay_Ketthuc = dtNgay_Ketthuc.EditValue;
                objWare_kehoach.Id_Nhansu = lookUpEdit_Nhansu.EditValue;
                objWare_kehoach.Ghichu = txGhichu.EditValue;
                identity = objWareService.Ware_Kehoach_Dathang_Insert(objWare_kehoach);

                if (identity != null)
                {
                    DoClickEndEdit(dgware_Kehoach_Chitiet);
                    foreach (DataRow dr in ds_Kehoach_Dathang_Chitiet.Tables[0].Rows)
                    {
                        if (dr.RowState != DataRowState.Deleted)
                            dr["Id_Kehoach_Dathang"] = identity;
                    }
                    objWareService.Update_Ware_Kehoach_Dathang_Chitiet_Collection(ds_Kehoach_Dathang_Chitiet);
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
                Ecm.WebReferences.WareService.Ware_Kehoach_Dathang objWare_kehoach = new Ecm.WebReferences.WareService.Ware_Kehoach_Dathang();
                objWare_kehoach.Id_Kehoach_Dathang = identity;
                objWare_kehoach.Ngay_Batdau = dtNgay_Batdau.EditValue;
                objWare_kehoach.Ngay_Ketthuc = dtNgay_Ketthuc.EditValue;
                objWare_kehoach.Id_Nhansu = lookUpEdit_Nhansu.EditValue;
                objWare_kehoach.Ghichu = txGhichu.EditValue;
                objWareService.Ware_Kehoach_Dathang_Update(objWare_kehoach);

                this.DoClickEndEdit(dgware_Kehoach_Chitiet);
                foreach (DataRow dr in ds_Kehoach_Dathang_Chitiet.Tables[0].Rows)
                {
                    if (dr.RowState == DataRowState.Added)
                        dr["Id_Kehoach_Dathang"] = identity;
                }
                objWareService.Update_Ware_Kehoach_Dathang_Chitiet_Collection(ds_Kehoach_Dathang_Chitiet);
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
            return objWareService.Ware_Kehoach_Dathang_Delete(identity);
        }

        public override bool PerformAdd()
        {
            this.ResetText();
            lookUpEdit_Nhansu.EditValue = Convert.ToInt64(id_nhansu_current);
            this.ChangeStatus(true);
            dtNgay_Batdau.EditValue = objWareService.GetServerDateTime();
            this.ds_Kehoach_Dathang_Chitiet = objWareService.Ware_Kehoach_Dathang_Chitiet_SelectById_Kehoach_Dathang(-1).ToDataSet();
            this.dgware_Kehoach_Chitiet.DataSource = ds_Kehoach_Dathang_Chitiet.Tables[0];
            return true;
        }

        public override bool PerformEdit()
        {
            if ("" + gvKehoach.GetFocusedRowCellValue("Id_Kehoach_Dathang") == "")
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn kế hoạch đặt hàng, vui lòng chọn lại");
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
            if ("" + gvKehoach.GetFocusedRowCellValue("Id_Kehoach_Dathang") == "")
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn kế hoạch đặt hàng, vui lòng chọn lại");
                return false;
            }
            if (GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUser().ToUpper() != "ADMIN")
                if (!id_nhansu_current.Equals("" + lookUpEdit_Nhansu.EditValue))
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
                DataRow[] sdr = ds_Kehoach_Dathang.Tables[0].Select("Id_Hdbanhang = " + identity);
                DataSets.dsHdbanhang_Chitiet dsrHdbanhang_Chitiet = new Ecm.Ware.DataSets.dsHdbanhang_Chitiet();
                Reports.rptHdbanhang_noVAT rptHdbanhang_noVAT = new Ecm.Ware.Reports.rptHdbanhang_noVAT();
                GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
                frmPrintPreview.Report = rptHdbanhang_noVAT;
                //frmPrintPreview.Name = this.Name;
                //frmPrintPreview.EnablePrintPreview = this.EnablePrintPreview;
                rptHdbanhang_noVAT.DataSource = dsrHdbanhang_Chitiet;
                int i = 1;
                foreach (DataRow dr in ds_Kehoach_Dathang_Chitiet.Tables[0].Rows)
                {
                    DataRow drnew = dsrHdbanhang_Chitiet.Tables[0].NewRow();
                    foreach (DataColumn dc in ds_Kehoach_Dathang_Chitiet.Tables[0].Columns)
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
                lookUpEdit_Nhansu.EditValue = sdr[0]["Id_Nhansu_Bh"];
                rptHdbanhang_noVAT.lblNhansu_Bill.Text = lookUpEdit_Nhansu.Text;
                DataRow[] sdrKhachhang = null;
                if (Convert.ToInt32(sdr[0]["Id_Khachhang"]) != -1)
                {
                    sdrKhachhang = ds_Khachhang.Tables[0].Select("Id_Khachhang=" + sdr[0]["Id_Khachhang"]);
                    rptHdbanhang_noVAT.lblKhachhang.Text = "" +
                       ((sdrKhachhang != null && sdrKhachhang.Length > 0) ? sdrKhachhang[0]["Ten_Khachhang"] : "");
                }
                rptHdbanhang_noVAT.tbcSochungtu.Text = sdr[0]["Sochungtu"].ToString();
                double thanhtien = Convert.ToDouble(ds_Kehoach_Dathang_Chitiet.Tables[0].Compute("sum(Thanhtien_TG)", ""));
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
                ex.ToString();
                return false;
            }
            return base.PerformPrintPreview();
        }

        #endregion

        #region Event

        private void gridView4_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if ("" + gvKehoach_Chitiet.GetFocusedRowCellValue("Id_Hdbanhang_Chitiet") == "")
                return;
            dgware_Kehoach_Chitiet.DataSource = ds_Kehoach_Dathang_Chitiet.Tables[0];
        }

        private void btnSplit_Click(object sender, EventArgs e)
        {
            GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowDialogOfMetaData("Ecm.Reports.dll", "Ecm.Reports.Forms.FrmRptSplit_Sum_Hhban", this.MdiParent);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PerformPrintPreview();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.DisplayInfo_Details();
        }

        #endregion

        void DisplayInfo_Details()
        {
            identity = gvKehoach.GetFocusedRowCellValue("Id_Kehoach_Dathang");
            this.ds_Kehoach_Dathang_Chitiet = objWareService.Ware_Kehoach_Dathang_Chitiet_SelectById_Kehoach_Dathang(identity).ToDataSet();
            this.dgware_Kehoach_Chitiet.DataSource = ds_Kehoach_Dathang_Chitiet.Tables[0];
            gvKehoach_Chitiet.BestFitColumns();
            DataBindingControl();
        }

        private void gvHoadon_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ClearDataBindings();
            ResetText();
            if (e.FocusedRowHandle >= 0)
                DisplayInfo_Details();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            Load_Gridview();
        }

        private void Frmware_Kehoach_Dathang_Load(object sender, EventArgs e)
        {
            DisplayInfo();
        }

        private void gvKehoach_Chitiet_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //Kiem tra so luong ton
            this.DoClickEndEdit(dgware_Kehoach_Chitiet);
            if (e.Column.FieldName == "Soluong")
            {
                gvKehoach_Chitiet.SetFocusedRowCellValue("Sanluong_Tong_Thang", Convert.ToDecimal("0" + gvKehoach_Chitiet.GetFocusedRowCellValue("Sanluong_Tuan1"))
                                                                            + Convert.ToDecimal("0" + gvKehoach_Chitiet.GetFocusedRowCellValue("Sanluong_Tuan2"))
                                                                            + Convert.ToDecimal("0" + gvKehoach_Chitiet.GetFocusedRowCellValue("Sanluong_Tuan3"))
                                                                            + Convert.ToDecimal("0" + gvKehoach_Chitiet.GetFocusedRowCellValue("Sanluong_Tuan4")));
            }
            gvKehoach_Chitiet.BestFitColumns();
        }

    }
}