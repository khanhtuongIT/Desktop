using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{
    /// <summary>
    /// author: nhanvuong
    /// date: 22/10/2010
    /// </summary>
    public partial class Frmware_Hdbanhang_Xuatkho_MngrEdit :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
       
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        DataSet ds_Xkbanhang = new DataSet();
        DataSet ds_Xkbanhang_Chitiet = new DataSet();
        DataSet ds_Hanghoa_Ban = new DataSet();        
        DataSet ds_Nhansu;
        DataSet ds_Donvitinh;
        public DataRow dr_hdXuatkho;
        object LocationId_Cuahang_Ban;

        public Frmware_Hdbanhang_Xuatkho_MngrEdit()
        {
            InitializeComponent();
            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");
            this.dtNgay_Chungtu_View.Properties.MinValue = new DateTime(2000,01,01);
            this.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Cancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            this.DisplayInfo();
            //this.item_PrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        #region local data
        DataSet dsSys_Lognotify = null;
        string xml_WARE_DM_HANGHOA_BAN = @"Resources\localdata\Ware_Dm_Hanghoa_Ban.xml";
        string xml_REX_NHANSU = @"Resources\localdata\Rex_Nhansu.xml";
        string xml_WARE_DM_DONVITINH = @"Resources\localdata\Ware_Dm_Donvitinh.xml";        
        DateTime dtlc_ware_dm_hanghoa_ban;
        DateTime dtlc_ware_dm_donvitinh;
        DateTime dtlc_rex_nhansu;        
        #endregion

        #region display info

        /// <summary>
        /// Truy xuat DateTime thay doi du lieu cuoi cung
        /// </summary>
        /// <param name="table_name"></param>
        /// <returns></returns>
        private DateTime GetLastChange_FrmLognotify(string table_name)
        {
            try
            {
                return Convert.ToDateTime(dsSys_Lognotify.Tables[0].Select(string.Format("Table_Name='{0}'", table_name))[0]["Last_Change"]);
            }
            catch (Exception ex)
            {
                return new DateTime(2010, 01, 01);
            }
        }

        void LoadMasterData()
        {
            //load data from local xml when last change at local differ from database
            dsSys_Lognotify = objMasterService.Get_Sys_Lognotify_SelectLastChange_OfTables("[ware_dm_donvitinh],[ware_dm_hanghoa_ban], [rex_nhansu]").ToDataSet();
            dtlc_rex_nhansu = GetLastChange_FrmLognotify("REX_NHANSU");
            dtlc_ware_dm_donvitinh = GetLastChange_FrmLognotify("WARE_DM_DONVITINH");           
            dtlc_ware_dm_hanghoa_ban = GetLastChange_FrmLognotify("WARE_DM_HANGHOA_BAN");

            if (DateTime.Compare(dtlc_ware_dm_hanghoa_ban, System.IO.File.GetLastWriteTime(xml_WARE_DM_HANGHOA_BAN)) > 0
            || !System.IO.File.Exists(xml_WARE_DM_HANGHOA_BAN))
            {
                ds_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
                ds_Hanghoa_Ban.WriteXml(xml_WARE_DM_HANGHOA_BAN, XmlWriteMode.WriteSchema);
            }
            else
            {
                ds_Hanghoa_Ban = new DataSet();
                ds_Hanghoa_Ban.ReadXml(xml_WARE_DM_HANGHOA_BAN);
            }          
            if (DateTime.Compare(dtlc_rex_nhansu, System.IO.File.GetLastWriteTime(xml_REX_NHANSU)) > 0
                || !System.IO.File.Exists(xml_REX_NHANSU))
            {
                ds_Nhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
                ds_Nhansu.WriteXml(xml_REX_NHANSU, XmlWriteMode.WriteSchema);
            }
            else
            {
                ds_Nhansu = new DataSet();
                ds_Nhansu.ReadXml(xml_REX_NHANSU);
            }
            if (DateTime.Compare(dtlc_ware_dm_donvitinh, System.IO.File.GetLastWriteTime(xml_WARE_DM_DONVITINH)) > 0
                || !System.IO.File.Exists(xml_WARE_DM_DONVITINH))
            {
                ds_Donvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
                ds_Donvitinh.WriteXml(xml_WARE_DM_DONVITINH, XmlWriteMode.WriteSchema);
            }
            else
            {
                ds_Donvitinh = new DataSet();
                ds_Donvitinh.ReadXml(xml_WARE_DM_DONVITINH);
            }
            lookUpEditMa_Cuahang_Ban.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().ToDataSet().Tables[0];
            gridLookUpEdit_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
            lookUpEdit_Nhansu_Banhang.Properties.DataSource = ds_Nhansu.Tables[0];
            gridLookUpEdit_Donvitinh.DataSource = ds_Donvitinh.Tables[0];
            if (lookUpEdit_Khachhang.Properties.DataSource == null)
                lookUpEdit_Khachhang.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet().Tables[0];
        }

        public override void DisplayInfo()
        {
            //Set lại trạng thái form là view
            FormState =  GoobizFrame.Windows.Forms.FormState.View;
            LocationId_Cuahang_Ban =  GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocation("Id_Cuahang_Ban");
            LoadMasterData();
            gridView1.Focus();
            ReloadDs_XkBanhang();
            object identity = gridView1.GetFocusedRowCellValue("Id_Xuatkho_Banhang");
            if (identity == null)
            {
                dgware_Hdbanhang_Chitiet.DataSource = null;
                return;
            }
            ds_Xkbanhang_Chitiet = objWareService.Get_All_Ware_Xuatkho_Banhang_Chitiet_By_Id_Xuatkho_Banhang(identity).ToDataSet();
            dgware_Hdbanhang_Chitiet.DataSource = ds_Xkbanhang_Chitiet;
            dgware_Hdbanhang_Chitiet.DataMember = ds_Xkbanhang_Chitiet.Tables[0].TableName;
        }

        public override void ClearDataBindings()
        {
            this.txtSochungtu.DataBindings.Clear();
            this.dtNgay_Chungtu.DataBindings.Clear();
            this.lookUpEdit_Khachhang.DataBindings.Clear();
            this.lookUpEdit_Nhansu_Banhang.DataBindings.Clear();
            this.txtSotien_Thanhtoan.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            this.ClearDataBindings();
            this.txtSochungtu.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Sochungtu");
            this.dtNgay_Chungtu.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Ngay_Chungtu");
            this.lookUpEdit_Nhansu_Banhang.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Id_Nhansu_Bh");
            this.txtSotien_Thanhtoan.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Sotien_Thanhtoan");
            this.lookUpEdit_Khachhang.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Id_Khachhang");
        }

        #endregion

        #region event override

        public override bool PerformTest()
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue("Id_Xuatkho_Banhang") == null)
                    return false;
                 GoobizFrame.Windows.MdiUtils.MdiChecker.ShowFormDocProgress(
                    "Ware_Xuatkho_Banhang" //Table name
                    , "Id_Xuatkho_Banhang" //PK name
                    , gridView1.GetFocusedRowCellValue("Id_Xuatkho_Banhang") //value
                    ,  GoobizFrame.Windows.Forms.DocProgress.Enumerators.EDocumentProcessStatus.TestDoc //New enum DocStatus
                    , false);
                ReloadDs_XkBanhang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return base.PerformTest();
        }

        public override bool PerformVerify()
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue("Id_Xuatkho_Banhang") == null)
                    return false;
                 GoobizFrame.Windows.MdiUtils.MdiChecker.ShowFormDocProgress(
                    "Ware_Xuatkho_Banhang" //Table name
                    , "Id_Xuatkho_Banhang" //PK name
                    , gridView1.GetFocusedRowCellValue("Id_Xuatkho_Banhang") //value
                    ,  GoobizFrame.Windows.Forms.DocProgress.Enumerators.EDocumentProcessStatus.VerifyDoc //New enum DocStatus
                    , false);            
                Ecm.WebReferences.WareService.DocumentProcessStatus DocumentProcessStatus = new Ecm.WebReferences.WareService.DocumentProcessStatus();
                DocumentProcessStatus.Tablename = "Ware_Xuatkho_Banhang";
                DocumentProcessStatus.PK_Name = "Id_Xuatkho_Banhang";
                DocumentProcessStatus.Identity = gridView1.GetFocusedRowCellValue("Id_Xuatkho_Banhang");
                DocumentProcessStatus = objWareService.Get_DocumentProcessStatus(DocumentProcessStatus);
                ReloadDs_XkBanhang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return base.PerformVerify();
        }


        public override bool PerformPrintPreview()
        {
            if (gridView1.GetFocusedRowCellValue("Id_Xuatkho_Banhang") == null)
            {
                 GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa có Hóa đơn nào được chọn, vui lòng chọn lại");
                return false;
            }
            DataSets.DsHdbanhang_Xuatkho dsXuatkho_Chitiet = new Ecm.Ware.DataSets.DsHdbanhang_Xuatkho();
            ds_Xkbanhang_Chitiet = objWareService.Get_All_Ware_Xuatkho_Banhang_Chitiet_By_Id_Xuatkho_Banhang(gridView1.GetFocusedRowCellValue("Id_Xuatkho_Banhang")).ToDataSet();
            Reports.rptHdbanhang_VAT rptVAT = new Ecm.Ware.Reports.rptHdbanhang_VAT();
             GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new  GoobizFrame.Windows.Forms.FrmPrintPreview();
            frmPrintPreview.Report = rptVAT;
            rptVAT.DataSource = dsXuatkho_Chitiet;
            int i = 1;
            foreach (DataRow dtr in ds_Xkbanhang_Chitiet.Tables[0].Rows)
            {
                DataRow dtrNew = dsXuatkho_Chitiet.Tables[0].NewRow();
                foreach (DataColumn dtc in ds_Xkbanhang_Chitiet.Tables[0].Columns)
                {
                    try
                    {
                        dtrNew[dtc.ColumnName] = dtr[dtc.ColumnName];
                    }
                    catch (Exception ex)
                    {
                    }
                }
                dtrNew["Stt"] = i;
                i++;
                dsXuatkho_Chitiet.Tables[0].Rows.Add(dtrNew);
            }

            #region Set he so ctrinh - logo, ten cty
            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyWebsite", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyTel", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyFaxEmail", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyTax", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("BankingAcc", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));
                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyWebsite"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyTel"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyFaxEmail"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyTax"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","BankingAcc"))[0]["Heso"]
                    ,imageData});

                rptVAT.tbcCompany_Name.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                rptVAT.tbcCompany_Address.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                rptVAT.tbcCompany_Masothue.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyTax"));
                rptVAT.tbcCompany_Tel.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyTel"));
                rptVAT.tbcCompany_Account.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".BankingAcc"));
            }
            #endregion
            DataSet dsTemp = objWareService.Get_All_Ware_Xuatkho_Banhang_ById(gridView1.GetFocusedRowCellValue("Id_Xuatkho_Banhang")).ToDataSet();    
            DataRow dtrXkBanhang = dsTemp.Tables[0].Rows[0];
            rptVAT.tbcNgay_Chungtu.Text = "" + string.Format("{0:dd/MM/yyyy hh:mm:ss tt}", dtNgay_Chungtu.Text);
            rptVAT.tbcSo_Chungtu.Text = txtSochungtu.Text;
            rptVAT.tbcNguoinhan.Text = dtrXkBanhang["Nguoinhan"].ToString();
            if (lookUpEdit_Khachhang.EditValue != null && lookUpEdit_Khachhang.Text != "")
            {
                rptVAT.tbcKhachhang.Text = lookUpEdit_Khachhang.GetColumnValue("Ten_Khachhang").ToString();
                rptVAT.tbcKhachhang_Diachi.Text = txtDiachi.Text;
                rptVAT.tbcKhachhang_Masothue.Text = lookUpEdit_Khachhang.GetColumnValue("Masothue").ToString();
            }
            rptVAT.tbcThanhtien.Text = dtrXkBanhang["Sotien"].ToString();
            
            rptVAT.tbcTien_Vat0.Text = dtrXkBanhang["Sotien_VAT"].ToString();
            rptVAT.tbcTongcong.Text = dtrXkBanhang["Sotien"].ToString();
            rptVAT.lblNhansu_Banhang.Text = lookUpEdit_Nhansu_Banhang.Text;
            double thanhtien = Convert.ToDouble(dtrXkBanhang["Sotien"].ToString());
            string str =  GoobizFrame.Windows.HelperClasses.ReadNumber.ChangeNum2VNStr(thanhtien, " đồng.");
            str = str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower();
            rptVAT.tbcThanhtien_Bangchu.Text = str; 
            rptVAT.tbcTien_Vat0.Text = ds_Xkbanhang_Chitiet.Tables[0].Compute("Sum(Thanhtien_VAT)", "Per_VAT = '0'").ToString();
            rptVAT.tbcTien_Vat5.Text = ds_Xkbanhang_Chitiet.Tables[0].Compute("Sum(Thanhtien_VAT)", "Per_VAT = '5'").ToString();
            rptVAT.tbcTien_Vat10.Text = ds_Xkbanhang_Chitiet.Tables[0].Compute("Sum(Thanhtien_VAT)", "Per_VAT = '10'").ToString();
            rptVAT.xrTongcong_VAT.Text = ds_Xkbanhang_Chitiet.Tables[0].Compute("Sum(Thanhtien_VAT)", "").ToString();            
            rptVAT.CreateDocument();
             GoobizFrame.Windows.Forms.ReportOptions oReportOptionsVAT =  GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(rptVAT);
             if (Convert.ToBoolean(oReportOptionsVAT.PrintPreview))
             {
                 frmPrintPreview.Text = " Hóa đơn VAT";
                 frmPrintPreview.printControl1.PrintingSystem = rptVAT.PrintingSystem;
                 frmPrintPreview.MdiParent = this.MdiParent;
                 frmPrintPreview.Text = "Hóa đơn VAT (Xem trang in)";
                 frmPrintPreview.Show();
                 frmPrintPreview.Activate();
             }
             else
             {
                 var reportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rptVAT);
                 reportPrintTool.Print();
             }
            return base.PerformPrintPreview();
        }

        #endregion

        #region process controls

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            object identity = gridView1.GetFocusedRowCellValue("Id_Xuatkho_Banhang");
            if (identity == null)
            {
                dgware_Hdbanhang_Chitiet.DataSource = null;
                return;
            }
            ds_Xkbanhang_Chitiet = objWareService.Get_All_Ware_Xuatkho_Banhang_Chitiet_By_Id_Xuatkho_Banhang(identity).ToDataSet();
            dgware_Hdbanhang_Chitiet.DataSource = ds_Xkbanhang_Chitiet;
            dgware_Hdbanhang_Chitiet.DataMember = ds_Xkbanhang_Chitiet.Tables[0].TableName;
            if (ds_Xkbanhang_Chitiet.Tables[0].Rows[0]["Dongia_Ban"].ToString() == "")
            {
                gridView4.Columns["Dongia_Ban"].Visible = false;
                gridView4.Columns["Dongia_Bansi"].Visible = true;
            }
            else
            {
                gridView4.Columns["Dongia_Ban"].Visible = true;
                gridView4.Columns["Dongia_Bansi"].Visible = false;
            }
            identity = gridView1.GetFocusedRowCellValue("Doc_Process_Status");
            if (identity.ToString() == "2")
            {
                btnLapPhieuThu.Enabled = true;
                item_PrintPreview.Enabled = true;
                 GoobizFrame.Windows.PlugIn.RightHelpers.CheckUserRightAction(this);

            }
            else
            {
                btnLapPhieuThu.Enabled = false;
                item_PrintPreview.Enabled = false;
            }
        }

        private void dtNgay_Chungtu_View_EditValueChanged(object sender, EventArgs e)
        {
            ReloadDs_XkBanhang();
        }

        private void lookUpEditMa_Cuahang_Ban_EditValueChanged(object sender, EventArgs e)
        {
            ReloadDs_XkBanhang();
        }

        void ReloadDs_XkBanhang()
        {
            if (dtNgay_Chungtu_View.EditValue != null && lookUpEditMa_Cuahang_Ban.EditValue != null)
                ds_Xkbanhang = objWareService.Get_All_Ware_Xuatkho_Banhang_ByCuahang_ByDate(lookUpEditMa_Cuahang_Ban.EditValue, dtNgay_Chungtu_View.EditValue).ToDataSet();
            else
                ds_Xkbanhang = objWareService.Get_All_Ware_Xuatkho_Banhang().ToDataSet();
            dgware_Hdbanhang.DataSource = ds_Xkbanhang;
            dgware_Hdbanhang.DataMember = ds_Xkbanhang.Tables[0].TableName;
            this.DataBindingControl();
            if (gridView1.RowCount == 0)
                btnLapPhieuThu.Enabled = false;
            else
                btnLapPhieuThu.Enabled = true;
        }

        private void lookUpEdit_Khachhang_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit_Khachhang.EditValue != null)
                this.txtDiachi.EditValue = lookUpEdit_Khachhang.GetColumnValue("Diachi_Khachhang");
            else
                this.txtDiachi.EditValue = null;
        }

        private void btnLapPhieuThu_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("Id_Xuatkho_Banhang") == null)
                return ;
            int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
            DataRow dr_hdXuatkho = null;            
            Ecm.Ware.Forms.Frmware_Phieu_Thu frm_PhieuThu = new Frmware_Phieu_Thu();            
            if (ds_Xkbanhang.Tables[0].Rows[focusedRow] != null)
                dr_hdXuatkho = ds_Xkbanhang.Tables[0].Rows[focusedRow];
            if (txtSotien_Thanhtoan.EditValue.Equals(dr_hdXuatkho["Sotien"]))
            {
                 GoobizFrame.Windows.Forms.MessageDialog.Show("Hóa đơn này đã thanh toán đủ tiền, nên không thể xuất thêm Phiếu thu");
                return ;
            }
            if (frm_PhieuThu.set_Chungtu_Goc(dr_hdXuatkho,lookUpEdit_Khachhang.GetColumnValue("Ma_Khachhang")  , txtSotien_Thanhtoan.EditValue))
                frm_PhieuThu.ShowDialog();
            this.DisplayInfo();
        }

        private void chkShowPreview_CheckedChanged(object sender, EventArgs e)
        {
            gridView1.OptionsView.ShowPreview = chkShowPreview.Checked;
        }

        #endregion

        

    }
}