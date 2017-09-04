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
    public partial class Frmware_Thumau : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        DataSet ds_Thumau = new DataSet();
        DataSet ds_Thumau_Chitiet = new DataSet();

        DataSet ds_hanghoa_ban;
        DataSet ds_Nhansu;
        object LocationId_Cuahang_Ban;
        object id_nhansu_current;
        //public DataRow[] _selectedRows;
        object identity;
       
        #region Initialize

        public Frmware_Thumau()
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
            DataSet ds_collection = objMasterService.GetRole_System_Name_ById_User(id_nhansu_current).ToDataSet();
            if (ds_collection.Tables[0].Rows.Count > 0 &&
                "" + ds_collection.Tables[0].Rows[0]["Role_System_Name"] != "Administrators")
            {
                lookUpEdit_Nhansu_View.EditValue = Convert.ToInt64(id_nhansu_current);
                lookUpEdit_Nhansu_View.Enabled = false;
            }

            ds_hanghoa_ban = objMasterService.Get_All_Ware_Dm_Hanghoa().ToDataSet();
            lookUpEdit_Hanghoa_Ban.Properties.DataSource = ds_hanghoa_ban.Tables[0];
            gridLookUpEdit_Hanghoa.DataSource = ds_hanghoa_ban.Tables[0];
        }

        void Load_Gridview()
        {
            object id_nhansu = (Convert.ToInt64(lookUpEdit_Nhansu_View.EditValue) == -1) ? null : lookUpEdit_Nhansu_View.EditValue;
            ds_Thumau = objWareService.Ware_Thumau_SelectAll(id_nhansu, dtNgay_Chungtu_View.EditValue).ToDataSet();
            dgware_Thumau.DataSource = ds_Thumau;
            dgware_Thumau.DataMember = ds_Thumau.Tables[0].TableName;
        }

        #endregion

        public override void DisplayInfo()
        {
            try
            {
                ResetText();
                LoadMasterData();
                Load_Gridview();
                this.ChangeStatus(false);
                DisplayInfo_Details();
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
            }
        }

        public override void ChangeStatus(bool editTable)
        {
            dgware_Thumau.Enabled = !editTable;
            gvThumau_Chitiet.OptionsBehavior.Editable = editTable;
            tableLayoutPanel1.Enabled = !editTable;
            panelControl_Cash.Enabled = !editTable;
        }

        public override void ResetText()
        {
            txtTen_Lobanh.EditValue = null;
            lookUpEdit_Hanghoa_Ban.EditValue = null;
            txtSoluong.EditValue = null;
            txtDongia.EditValue = null;
            txtTenHang_Doithu.EditValue = null;
            txtDongia_Doithu.EditValue = null;
            dtNgay_Thu.EditValue = null;
            txtSanluong.EditValue = null;
            txtKetqua.EditValue = null;
            LookupEdit_Nhansu2.EditValue = null;
        }

        public override bool PerformEdit()
        {
            ResetText();
            LookupEdit_Nhansu2.EditValue = Convert.ToInt64(id_nhansu_current);
            this.ChangeStatus(true);
            if (dgware_Thumau_Chitiet.DataSource == null)
            {
                this.ds_Thumau_Chitiet = objWareService.Ware_Thumau_SelectByDate(null).ToDataSet();
                dgware_Thumau_Chitiet.DataSource = ds_Thumau_Chitiet;
                dgware_Thumau_Chitiet.DataMember = ds_Thumau_Chitiet.Tables[0].TableName;
                this.Data = ds_Thumau_Chitiet;
                this.GridControl = dgware_Thumau_Chitiet;
            }
            return true;
        }

        public override bool PerformCancel()
        {
            //this.gridColumn31.Visible = true;
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

                if (success)
                {
                    //if ("" + lookupEdit_MaKhachhang.EditValue != "") //Update Min quota
                    //    objWareService.Update_Ware_Khachhang_Min_Quota(lookupEdit_MaKhachhang.EditValue, dtNgay_Chungtu.EditValue);
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

        public override bool PerformSaveChanges()
        {
            DoClickEndEdit(dgware_Thumau_Chitiet);
            try
            {
                objWareService.Update_Ware_Ware_Thumau_Collection(ds_Thumau_Chitiet);
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
                DataSets.dsThumau _dsThumau = new Ecm.Ware.DataSets.dsThumau();
                Reports.rptThumau _rptThumau = new Ecm.Ware.Reports.rptThumau();
                GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
                frmPrintPreview.Report = _rptThumau;
                //frmPrintPreview.Name = this.Name;
                //frmPrintPreview.EnablePrintPreview = this.EnablePrintPreview;
                _rptThumau.DataSource = _dsThumau;
                int i = 1;
                foreach (DataRow dr in ds_Thumau_Chitiet.Tables[0].Rows)
                {
                    DataRow drnew = _dsThumau.Tables[0].NewRow();
                    foreach (DataColumn dc in ds_Thumau_Chitiet.Tables[0].Columns)
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
                    drnew["Ten_Hanghoa_Ban"] = dr["Ten_Hanghoa_Ban"];
                    //drnew["Ma_Hanghoa"] = dr["Ma_Hanghoa_Ban"];
                    //drnew["Stt"] = i++;
                    _dsThumau.Tables[0].Rows.Add(drnew);
                }
                //add parameter values
                _rptThumau.xrTableCell_Nhanvien.Text = LookupEdit_Nhansu2.Text;

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

                    _rptThumau.xrc_CompanyName.DataBindings.Add(
                        new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                    _rptThumau.xrc_CompanyAddress.DataBindings.Add(
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
                _rptThumau.CreateDocument();
                GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_rptThumau);
                if (Convert.ToBoolean(oReportOptions.PrintPreview))
                {
                    frmPrintPreview.Text = "" + oReportOptions.Caption;
                    frmPrintPreview.printControl1.PrintingSystem = _rptThumau.PrintingSystem;
                    frmPrintPreview.MdiParent = this.MdiParent;
                    frmPrintPreview.Text = this.Text + "(Xem trang in)";
                    frmPrintPreview.Show();
                    frmPrintPreview.Activate();
                }
                else
                {
                    var reportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_rptThumau);
                    reportPrintTool.Print();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return base.PerformPrintPreview();
        }

        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.DoClickEndEdit(dgware_Thumau_Chitiet);
            gvThumau_Chitiet.BestFitColumns();
        }

        void DisplayInfo_Details()
        {
            ResetText();
            //identity = gvThumau.GetFocusedRowCellValue("Id_Thumau");
            //if (identity == null)
            //{
            //    dgware_Thumau_Chitiet.DataSource = null;
            //    return;
            //}
            this.ds_Thumau_Chitiet = objWareService.Ware_Thumau_SelectByDate(gvThumau.GetFocusedRowCellValue("Ngay_Thu")).ToDataSet();
            dgware_Thumau_Chitiet.DataSource = ds_Thumau_Chitiet;
            dgware_Thumau_Chitiet.DataMember = ds_Thumau_Chitiet.Tables[0].TableName;
            gvThumau_Chitiet.BestFitColumns();

            this.Data = ds_Thumau_Chitiet;
            this.GridControl = dgware_Thumau_Chitiet;
            Display_Control();
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
                Display_Control();
        }

        void Display_Control()
        {
            if (ds_Thumau_Chitiet.Tables.Count > 0 && "" + gvThumau_Chitiet.GetFocusedRowCellValue("Id_Thumau") != "")
            {
                identity = gvThumau_Chitiet.GetFocusedRowCellValue("Id_Thumau");
                DataRow[] row = ds_Thumau_Chitiet.Tables[0].Select("Id_Thumau = " + identity);
                if (row.Length > 0)
                {
                    txtTen_Lobanh.EditValue = row[0]["Ten_Lobanh"];
                    lookUpEdit_Hanghoa_Ban.EditValue = row[0]["Id_Hanghoa_Ban"];
                    txtSoluong.EditValue = row[0]["Soluong"];
                    txtDongia.EditValue = row[0]["Dongia"];
                    txtTenHang_Doithu.EditValue = row[0]["Tenhang_Doithu"];
                    txtDongia_Doithu.EditValue = row[0]["Dongia_Doithu"];
                    dtNgay_Thu.EditValue = row[0]["Ngay_Thu"];
                    txtSanluong.EditValue = row[0]["Sanluong"];
                    txtKetqua.EditValue = row[0]["Ketqua"];
                    LookupEdit_Nhansu2.EditValue = row[0]["Id_Nhansu"];
                }
            }        
        }

        private void gvCongtac_Chitiet_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvThumau_Chitiet.SetFocusedRowCellValue("Id_Nhansu", id_nhansu_current);
        }

        private void lookUpEdit_Nhansu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                lookUpEdit_Nhansu_View.EditValue = null;
        }

    }
}