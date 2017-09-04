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
    public partial class Frmware_Congtac_Ketqua : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        DataSet ds_Congtac = new DataSet();
        DataSet ds_Congtac_Chitiet = new DataSet();

        DataSet ds_Khachhang;
        DataSet ds_Nhansu;
        object LocationId_Cuahang_Ban;
        object id_nhansu_current;
        //public DataRow[] _selectedRows;
        object identity;

        public Frmware_Congtac_Ketqua()
        {
            InitializeComponent();
            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");
            xtraTabControl_Main.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            LocationId_Cuahang_Ban = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocation("Id_Cuahang_Ban");
            id_nhansu_current = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu();
            //DisplayInfo();
            item_Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
            lookUpEdit_Nhansu_View.Properties.DataSource = ds_Nhansu.Tables[0];
            LookupEdit_Nhansu2.Properties.DataSource = ds_Nhansu.Tables[0];
            lookUpEdit_Nhansu_View.EditValue = Convert.ToInt64(-1);

            DataSet ds_collection = objMasterService.GetRole_System_Name_ById_User(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUserId()).ToDataSet();
            if (ds_collection.Tables[0].Rows.Count > 0 &&
                "" + ds_collection.Tables[0].Rows[0]["Role_System_Name"] != "Administrators")
            {
                lookUpEdit_Nhansu_View.EditValue = Convert.ToInt64(id_nhansu_current);
                lookUpEdit_Nhansu_View.Enabled = false;
            }

            ds_Khachhang = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
            lookupEdit_MaKhachhang.Properties.DataSource = ds_Khachhang.Tables[0];
            gridLookupEdit_Khachhang.DataSource = ds_Khachhang.Tables[0];

            DataSet dsCuahang = objMasterService.Ware_Dm_Cuahang_Ban_Select_Sale().ToDataSet();
            lookUpEdit_Cuahang_Ban.Properties.DataSource = dsCuahang.Tables[0];
            gridLookUpEdit_Cuahang_Ban.DataSource = dsCuahang.Tables[0];
        }

        void Load_Gridview()
        {
            object id_nhansu = (Convert.ToInt64(lookUpEdit_Nhansu_View.EditValue) == -1) ? null : lookUpEdit_Nhansu_View.EditValue;
            ds_Congtac = objWareService.Ware_Congtac_SelectAll(id_nhansu, dtNgay_Chungtu_View.EditValue).ToDataSet();
            dgware_Congtac.DataSource = ds_Congtac;
            dgware_Congtac.DataMember = ds_Congtac.Tables[0].TableName;
            DisplayInfo_Details();
        }

        #region Event Override

        public override void DisplayInfo()
        {
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

        public override void ChangeStatus(bool editTable)
        {
            dgware_Congtac.Enabled = !editTable;
            gvCongtac_Chitiet.OptionsBehavior.Editable = editTable;
            tableLayoutPanel1.Enabled = !editTable;
            panelControl_Cash.Enabled = !editTable;
        }
      
        #region not use

        //public override bool PerformDelete()
        //{
        //    if (GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUser().ToUpper() != "ADMIN")
        //        if (!id_nhansu_current.Equals("" + LookupEdit_Nhansu2.EditValue))
        //        {
        //            GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
        //            return false;
        //        }
        //    if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
        //     GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Hdbanhang"),
        //     GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Hdbanhang")   }) == DialogResult.Yes)
        //    {
        //        try
        //        {
        //            this.DeleteObject();
        //        }
        //        catch (Exception ex)
        //        {
        //            GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
        //        }
        //        this.DisplayInfo();
        //    }
        //    return base.PerformDelete();
        //}

//        public override bool PerformSave()
//        {
//            try
//            {
//                bool success = false;
//                System.Collections.Hashtable htbControl1 = new System.Collections.Hashtable();
//                //htbControl1.Add(txtSotien_Vat, lblSotien_Vat.Text);
//                //htbControl1.Add(lookUpEdit_Cuahang_Ban, lblCuahang_Ban.Text);
//                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(htbControl1))
//                    return false;
//                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
//                {
//                    success = (bool)this.InsertObject();
//                }
//                else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
//                    success = (bool)this.UpdateObject();
//                if (success)
//                {
//                    //if ("" + lookupEdit_MaKhachhang.EditValue != "") //Update Min quota
//                    //    objWareService.Update_Ware_Khachhang_Min_Quota(lookupEdit_MaKhachhang.EditValue, dtNgay_Chungtu.EditValue);
//                    this.DisplayInfo();
//                }
//                return success;
//            }
//            catch (Exception ex)
//            {
//#if DEBUG
//                MessageBox.Show(ex.Message);
//#endif
//                return false;
//            }
//        }

//        public object InsertObject()
//        {
//            //try
//            //{
//            //    Ecm.WebReferences.WareService.Ware_Congtac objWare_Congtac = new Ecm.WebReferences.WareService.Ware_Congtac();
//            //    objWare_Congtac.Id_Cuahang_Ban = lookUpEdit_Cuahang_Ban.EditValue;
//            //    objWare_Congtac.Ngay_Congtac = dtNgay_Congtac.EditValue;
//            //    objWare_Congtac.Noidung = txtNoidung.EditValue;
//            //    objWare_Congtac.Id_Nhansu = LookupEdit_Nhansu2.EditValue;
//            //    objWare_Congtac.Id_Khachhang = ("" + lookupEdit_MaKhachhang.EditValue != "") ? lookupEdit_MaKhachhang.EditValue : -1;
//            //    objWare_Congtac.Ketqua = "";

//            //    identity = objWareService.Ware_Congtac_Insert(objWare_Congtac);
//            //    return true;
//            //}
//            //catch (Exception ex)
//            //{
//            //    GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
//            //    return false;
//            //}
//            return true;
//        }

//        public object UpdateObject()
//        {
//            try
//            {
//                Ecm.WebReferences.WareService.Ware_Congtac objWare_Congtac = new Ecm.WebReferences.WareService.Ware_Congtac();
//                objWare_Congtac.Id_Cuahang_Ban = lookUpEdit_Cuahang_Ban.EditValue;
//                objWare_Congtac.Ngay_Congtac = dtNgay_Congtac.EditValue;
//                objWare_Congtac.Noidung = txtNoidung.Text;
//                objWare_Congtac.Id_Nhansu = LookupEdit_Nhansu2.EditValue;
//                objWare_Congtac.Id_Khachhang = ("" + lookupEdit_MaKhachhang.EditValue != "") ? lookupEdit_MaKhachhang.EditValue : -1;
//                objWare_Congtac.Ketqua = null;
//                objWare_Congtac.Id_Congtac = identity;

//                objWareService.Ware_Congtac_Update(objWare_Congtac);
//                //update donmuahang_chitiet
//                //this.DoClickEndEdit(dgware_Congtac_Chitiet);
//                //foreach (DataRow dr in ds_Congtac_Chitiet.Tables[0].Rows)
//                //{
//                //    if (dr.RowState == DataRowState.Added)
//                //        dr["Id_Congtac"] = txtId_Hdbanhang.EditValue;
//                //}
//                //objWareService.Update_Ware_Hdbanhang_Chitiet_Collection(ds_Congtac_Chitiet);
//                return true;
//            }
//            catch (Exception ex)
//            {
//#if DEBUG
//                MessageBox.Show(ex.Message);
//#endif
//                return false;
//            }
//        }

//        public object DeleteObject()
//        {
//            return objWareService.Ware_Congtac_Delete(identity);
//        }

//        public override bool PerformAdd()
        //{
        //    LookupEdit_Nhansu2.EditValue = Convert.ToInt64(id_nhansu_current);
        //    DataSet ds_Cuahang_Ban_ByNhansu = objMasterService.Get_All_Ware_Dm_Cuahang_Ban_By_Id_Nhansu(id_nhansu_current).ToDataSet();
        //    this.ChangeStatus(true);
        //    dtNgay_Congtac.EditValue = objWareService.GetServerDateTime();
        //    return true;
        //}

        //public override object PerformSelectOneObject()
        //{
        //    //DoClickEndEdit(dgware_Congtac_Chitiet);
        //    //if (MdiParent != null) return null;
        //    //try
        //    //{
        //    //    if (ds_Congtac_Chitiet == null || ds_Congtac_Chitiet.Tables.Count == 0) return false;

        //    //    _selectedRows = ds_Congtac_Chitiet.Tables[0].Select("Chon=true");
        //    //    if (_selectedRows == null || _selectedRows.Length == 0)
        //    //    {
        //    //        GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] { this.gridColumn21.Caption });
        //    //        return false;
        //    //    }
        //    //    Dispose();
        //    //    return _selectedRows;
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    GoobizFrame.Windows.Forms.UserMessage.Show("Msg00130", new string[] { ex.Message });
        //    //}
        //    return base.PerformSelectOneObject();
        //}
        #endregion

        public override bool PerformEdit()
        {            
            LookupEdit_Nhansu2.EditValue = Convert.ToInt64(id_nhansu_current);
            this.ChangeStatus(true);
            return true;
        }

        public override bool PerformCancel()
        {
            //this.gridColumn31.Visible = true;
            this.DisplayInfo();
            return true;
        }

        public override bool PerformSaveChanges()
        {
            DoClickEndEdit(dgware_Congtac_Chitiet);
            try
            {
                objWareService.Update_Ware_Ware_Congtac_Collection(ds_Congtac_Chitiet);
                DisplayInfo();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return base.PerformSaveChanges();
        }

        public override bool PerformPrintPreview()
        {
            if (identity == null)
                return false;
            try
            {
                DataSets.DsCongtac _dsCongtac = new Ecm.Ware.DataSets.DsCongtac();
                Reports.rptCongtac _rptCongtac = new Ecm.Ware.Reports.rptCongtac();
                GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
                frmPrintPreview.Report = _rptCongtac;
                //frmPrintPreview.Name = this.Name;
                //frmPrintPreview.EnablePrintPreview = this.EnablePrintPreview;
                _rptCongtac.DataSource = _dsCongtac;
                int i = 1;
                foreach (DataRow dr in ds_Congtac_Chitiet.Tables[0].Rows)
                {
                    DataRow drnew = _dsCongtac.Tables[0].NewRow();
                    foreach (DataColumn dc in ds_Congtac_Chitiet.Tables[0].Columns)
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
                    //drnew["Ten_Hanghoa_Ban"] = dr["Ten_Hanghoa_Ban"];
                    //drnew["Ma_Hanghoa"] = dr["Ma_Hanghoa_Ban"];
                    //drnew["Stt"] = i++;
                    _dsCongtac.Tables[0].Rows.Add(drnew);
                }
                //add parameter values
                _rptCongtac.xrTableCell_Nhanvien.Text = LookupEdit_Nhansu2.Text;

                #region Set he so ctrinh - logo, ten cty
                using (DataSet dsCompany_Paras = new DataSet())
                {
                    dsCompany_Paras.Tables.Add("Company_Paras");
                    dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                    dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                    dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                    DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet();
                    byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                    dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData});

                    _rptCongtac.xrc_CompanyName.DataBindings.Add(
                        new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                    _rptCongtac.xrc_CompanyAddress.DataBindings.Add(
                        new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                }
                #endregion

                //if (txtTenHang_Doithu.Text != "") // check if khách hàng quota --> hiển thị thông tin giảm giá
                //{
                //    DataSet dsKhachhang_KM = objWareService.Get_All_Ware_Khachhang_Quota_Detail_By_Khachhang(txtTenHang_Doithu.EditValue).ToDataSet();
                //    if (dsKhachhang_KM.Tables.Count > 0 && dsKhachhang_KM.Tables[0].Rows.Count > 0)
                //    {
                //        if (dsKhachhang_KM.Tables[0].Rows[0]["Id_Vip_Member"].ToString() == "") // check if khach hang quota
                //        {
                //            rptHdbanhang_noVAT.lblSotien_Giam.Visible = true;
                //            rptHdbanhang_noVAT.xrSotien_Giam.Visible = true;
                //        }
                //    }
                //}
                _rptCongtac.CreateDocument();
                GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_rptCongtac);
                if (Convert.ToBoolean(oReportOptions.PrintPreview))
                {
                    frmPrintPreview.Text = "" + oReportOptions.Caption;
                    frmPrintPreview.printControl1.PrintingSystem = _rptCongtac.PrintingSystem;
                    frmPrintPreview.MdiParent = this.MdiParent;
                    frmPrintPreview.Text = this.Text + "(Xem trang in)";
                    frmPrintPreview.Show();
                    frmPrintPreview.Activate();
                }
                else
                {
                    var reportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_rptCongtac);
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

        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //Kiem tra so luong ton
            this.DoClickEndEdit(dgware_Congtac_Chitiet);
            gvCongtac_Chitiet.BestFitColumns();
        }

        private void gridView4_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if ("" + gvCongtac_Chitiet.GetFocusedRowCellValue("Id_Hdbanhang_Chitiet") == "")
                return;
            dgware_Congtac_Chitiet.DataSource = ds_Congtac_Chitiet.Tables[0];
        }

        private void lookUpEdit_Khachhang_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (FormState == GoobizFrame.Windows.Forms.FormState.View && "" + lookupEdit_MaKhachhang.EditValue != "")
                    lookupEdit_MaKhachhang.Text = "" + ((DataRowView)lookupEdit_MaKhachhang.Properties.GetDataSourceRowByKeyValue(lookupEdit_MaKhachhang.EditValue))["Ma_Khachhang"];
            }
            catch { lookupEdit_MaKhachhang.Text = ""; }
        }

        void DisplayInfo_Details()
        {
            object id_nhansu = lookUpEdit_Nhansu_View.EditValue;
            //identity = gvCongtac.GetFocusedRowCellValue("Id_Congtac");
            //if (identity == null) return;
            this.ds_Congtac_Chitiet = objWareService.Ware_Congtac_SelectByDate(gvCongtac.GetFocusedRowCellValue("Thang_Congtac"), gvCongtac.GetFocusedRowCellValue("Nam_Congtac"), gvCongtac.GetFocusedRowCellValue("Id_Nhansu")).ToDataSet();
            //ds_Congtac_Chitiet.Tables[0].Columns.Add("Chon", typeof(bool));
            dgware_Congtac_Chitiet.DataSource = ds_Congtac_Chitiet;
            dgware_Congtac_Chitiet.DataMember = ds_Congtac_Chitiet.Tables[0].TableName;
            
            this.Data = ds_Congtac_Chitiet;
            this.GridControl = dgware_Congtac_Chitiet;
            //DataBindingControl();
            gvCongtac_Chitiet.BestFitColumns();
        }

        private void lookupEdit_MaKhachhang_EditValueChanged(object sender, EventArgs e)
        {
            //if (lookupEdit_MaKhachhang.EditValue == null) return;
            //txtTen_Khachhang.Text = lookupEdit_MaKhachhang.GetColumnValue("Ten_Khachhang") + "";
        }

        private void Frmware_Hdbanhang_noVAT_Hhban_Load(object sender, EventArgs e)
        {
            DisplayInfo();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            Load_Gridview();
        }

        private void gvCongtac_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DisplayInfo_Details();
        }

        private void gvCongtac_Chitiet_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (FormState == GoobizFrame.Windows.Forms.FormState.View)
                if (ds_Congtac_Chitiet.Tables.Count > 0 && "" + gvCongtac_Chitiet.GetFocusedRowCellValue("Id_Congtac") != "")
                {
                    identity = gvCongtac_Chitiet.GetFocusedRowCellValue("Id_Congtac");
                    DataRow[] row = ds_Congtac_Chitiet.Tables[0].Select("Id_Congtac = " + identity);
                    if (row.Length > 0)
                    {
                        txtNoidung.EditValue = row[0]["Noidung"];
                        txtKetqua.EditValue = row[0]["Ketqua"];
                        dtNgay_Congtac.EditValue = row[0]["Ngay_Congtac"];
                        LookupEdit_Nhansu2.EditValue = row[0]["Id_Nhansu"];
                        lookupEdit_MaKhachhang.EditValue = row[0]["Id_Khachhang"];
                        lookUpEdit_Cuahang_Ban.EditValue = row[0]["Id_Cuahang_Ban"];
                        txtTen_Khachhang.EditValue = row[0]["Ten_Khachhang"];
                    }
                }
        }

        private void gvCongtac_Chitiet_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvCongtac_Chitiet.SetFocusedRowCellValue("Id_Nhansu", LookupEdit_Nhansu2.EditValue);
        }

        private void lookUpEdit_Nhansu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                lookUpEdit_Nhansu_View.EditValue = null;
        }

    }
}