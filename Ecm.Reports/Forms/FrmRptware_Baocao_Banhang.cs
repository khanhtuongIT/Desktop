using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;
using Ecm.WebReferences.MasterService;
using Ecm.WebReferences.ReportService;
using Ecm.WebReferences.WareService;

namespace Ecm.Reports.Forms
{
    public partial class FrmRptware_Baocao_Banhang : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        string report = "";
        public Ecm.WebReferences.Classes.WareService objWareService = new Ecm.WebReferences.Classes.WareService();
        Ecm.WebReferences.Classes.MasterService objMasterService = new Ecm.WebReferences.Classes.MasterService();
        Ecm.WebReferences.Classes.ReportService objReportService = new Ecm.WebReferences.Classes.ReportService();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();

        public FrmRptware_Baocao_Banhang()
        {
            InitializeComponent();

            dtNgay_Batdau.Properties.MinValue = new DateTime(2000, 01, 01);
            dtNgay_Ketthuc.Properties.MinValue = new DateTime(2000, 01, 01);

            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Cancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_PrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            //lookUp_Loai_Hanghoa_Ban.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler( GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            lookUpEdit_Doituong.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            //lookUpEdit_Hanghoa_Ban.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler( GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            lookUpEditCuahang_Ban.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            DisplayInfo();
        }

        #region Override Method
        public override void DisplayInfo()
        {
            try
            {
                lookUpEditCuahang_Ban.Properties.DataSource = objMasterService.Ware_Dm_Cuahang_Ban_Select_Sale().ToDataSet().Tables[0];
                DataTable dtb = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet().Tables[0];
                lookUpEdit_Khachhang.Properties.DataSource = dtb;
                lookUpEdit_Doituong.Properties.DataSource = dtb;
                //ds_Donvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
                ////ds_Khachhang = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
                DataTable dtb2 = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet().Tables[0];
                lookUpEdit_Nhansu_Banhang.Properties.DataSource = dtb2;

                dtb = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet().Tables[0];
                lookUpEdit_Mahang.Properties.DataSource = dtb;
                lookUpEdit_Tenhang.Properties.DataSource = dtb;
                //lookUpEdit_Hanghoa_Ban.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().Tables[0];
                //lookUp_Loai_Hanghoa_Ban.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Ban().Tables[0];
                lookUpEdit_MaNhomhang.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Ban().ToDataSet().Tables[0];

                dtNgay_Batdau.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1, 0, 0, 1);
                dtNgay_Ketthuc.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1, 23, 59, 59).AddMonths(1).AddDays(-1);
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
#endif
            }
        }

        //lập báo cáo
        public override bool PerformQuery()
        {
            try
            {
                switch (report)
                {
                        // in report công nợ đã thu
                    case "rptWare_Banhang_Congno_Thu":
                        Load_rptWare_Banhang_Congno_Thu();
                        break;
                        // in report chi tiết các khoản nợ
                    case "rptWare_Congno_Chitiet":
                        Load_rptWare_Congno_Chitiet();
                        break;
                        // in report công nợ chưa thua
                    case "rptWare_Banhang_Congno_Chuathu":
                        Load_rptWare_Banhang_Congno_Chuathu();
                        break;

                    case "rptWare_Banhang_Nhaptra_Chitiet":
                        Load_rptWare_Hh_Kh_Tra();
                        break;

                    case "rptWare_Banhang_Congno_Tonghop":
                        Load_Rptware_Banhang_Congno_Tonghop();
                        break;

                    case "rptWare_Banhang_Chitiet":
                        Load_Rptware_Banhang_Chitiet();
                        break;

                    case "rptWare_Banhang_Tonghop_Mathang":
                        Load_Rpt_Ware_Hh_Ban_Tonghop_ByMathang();
                        break;

                    case "rptWare_Banhang_Tonghop_Mathang_Nhanvien_Bh":
                        Load_Rpt_Ware_Hh_Ban_Tonghop_ByMathang_Nhanvien_Bh();
                        break;

                    case "rptWare_Banhang_Tonghop_Khachhang":
                        Load_Rpt_Ware_Hh_Ban_Tonghop_ByKhachhang();
                        break;

                    case "rptWare_Banhang_Tonghop_Nhanvien":
                        Load_Rpt_Hh_Bah_Tonghop_ByNhanvien();
                        break;

                    case "rptWare_Banhang_Tonghop_Khuvuc":
                        Load_Rptware_Banhang_Tonghop_Khuvuc();
                        break;

                    case "rptWare_Baocao_Banhang":
                        Load_rptWare_Baocao_Banhang();
                        break;

                    case "rptWare_Baocao_Giavon_Giaban":
                        Load_rptWare_Baocao_Giavon_Giaban();
                        break;
                    default:
                        GoobizFrame.Windows.Forms.MessageDialog.Show("Vui lòng chọn loại báo cáo.", "Thông tin...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
#endif
                return false;
            }
            return base.PerformQuery();
        }
        #endregion

        #region Event load report trong navBar

        private void navItem_Tonghop_Congno_Phaitra_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Banhang_Congno_Tonghop _rptWare_Banhang_Congno_Tonghop = new Ecm.Reports.XtraReports.rptWare_Banhang_Congno_Tonghop();
            this.report = "rptWare_Banhang_Congno_Tonghop";
            setHesoChuongtrinh(_rptWare_Banhang_Congno_Tonghop.xrc_CompanyName, _rptWare_Banhang_Congno_Tonghop.xrc_CompanyAddress, null);
            printControl_Baocao.PrintingSystem = _rptWare_Banhang_Congno_Tonghop.PrintingSystem;
            _rptWare_Banhang_Congno_Tonghop.CreateDocument();
            Loaddata();
        }

        private void navItem_Chitiet_Tienmuahang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Banhang_Chitiet _rptWare_Banhang_Chitiet = new Ecm.Reports.XtraReports.rptWare_Banhang_Chitiet();
            setHesoChuongtrinh(_rptWare_Banhang_Chitiet.xrc_CompanyName, _rptWare_Banhang_Chitiet.xrc_CompanyAddress, null);
            printControl_Baocao.PrintingSystem = _rptWare_Banhang_Chitiet.PrintingSystem;
            this.report = "rptWare_Banhang_Chitiet";
            //_rptWare_Banhang_Chitiet.xrTableRow_KH.Visible = true;
            //_rptWare_Banhang_Chitiet.xrTableCell_TenKH.Text = lookUpEdit_Khachhang.Text + " - " + lookUpEdit_Doituong.Text;
            _rptWare_Banhang_Chitiet.CreateDocument();
            Loaddata();
        }

        private void navItem_Chitiet_Tienxuat_Trahang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Banhang_Nhaptra_Chitiet rpt_Nhaptra_Chitiet = new Ecm.Reports.XtraReports.rptWare_Banhang_Nhaptra_Chitiet();
            setHesoChuongtrinh(rpt_Nhaptra_Chitiet.xrc_CompanyName, rpt_Nhaptra_Chitiet.xrc_CompanyAddress, rpt_Nhaptra_Chitiet.xrPic_Logo);
            printControl_Baocao.PrintingSystem = rpt_Nhaptra_Chitiet.PrintingSystem;
            this.report = "rptWare_Banhang_Nhaptra_Chitiet";
            rpt_Nhaptra_Chitiet.CreateDocument();
            Loaddata();
        }

        private void navItem_Chitiet_Tientra_Congno_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Banhang_Congno_Thu _rptWare_Banhang_Congno_Thu = new Ecm.Reports.XtraReports.rptWare_Banhang_Congno_Thu();
            setHesoChuongtrinh(_rptWare_Banhang_Congno_Thu.xrc_CompanyName, _rptWare_Banhang_Congno_Thu.xrc_CompanyAddress, _rptWare_Banhang_Congno_Thu.xrPic_Logo);
            printControl_Baocao.PrintingSystem = _rptWare_Banhang_Congno_Thu.PrintingSystem;
            this.report = "rptWare_Banhang_Congno_Thu";
            _rptWare_Banhang_Congno_Thu.CreateDocument();
            Loaddata();
        }

        private void navItem_Danhsach_Chungtu_Congno_Chuathu_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Banhang_Congno_Chuathu _rptWare_Banhang_Congno_Chuathu = new Ecm.Reports.XtraReports.rptWare_Banhang_Congno_Chuathu();
            setHesoChuongtrinh(_rptWare_Banhang_Congno_Chuathu.xrc_CompanyName, _rptWare_Banhang_Congno_Chuathu.xrc_CompanyAddress, _rptWare_Banhang_Congno_Chuathu.xrPic_Logo);
            printControl_Baocao.PrintingSystem = _rptWare_Banhang_Congno_Chuathu.PrintingSystem;
            this.report = "rptWare_Banhang_Congno_Chuathu";
            _rptWare_Banhang_Congno_Chuathu.CreateDocument();
            Loaddata();
        }

        private void navItem_Chitiet_Congno_Theophieuxuat_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Loaddata();
        }

        //Tổng hợp bán hàng theo Nhân viên
        private void navItem_Danhsach_Phieuxuat_Cohoahong_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            XtraReports.rptWare_Banhang_Tonghop_Nhanvien rptTonghop_Nhanvien = new Ecm.Reports.XtraReports.rptWare_Banhang_Tonghop_Nhanvien();
            setHesoChuongtrinh(rptTonghop_Nhanvien.xrc_CompanyName, rptTonghop_Nhanvien.xrc_CompanyAddress, null);
            printControl_Baocao.PrintingSystem = rptTonghop_Nhanvien.PrintingSystem;
            this.report = "rptWare_Banhang_Tonghop_Nhanvien";
            rptTonghop_Nhanvien.CreateDocument();
            Loaddata();
        }

        //Tổng hợp bán hàng theo khách hàng
        private void navItem_Tonghop_Hoahong_Cuakhach_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            XtraReports.rptWare_Banhang_Tonghop_Khachhang rptBanhang_Khachhang = new Ecm.Reports.XtraReports.rptWare_Banhang_Tonghop_Khachhang();
            setHesoChuongtrinh(rptBanhang_Khachhang.xrc_CompanyName, rptBanhang_Khachhang.xrc_CompanyAddress, null);
            printControl_Baocao.PrintingSystem = rptBanhang_Khachhang.PrintingSystem;
            this.report = "rptWare_Banhang_Tonghop_Khachhang";
            rptBanhang_Khachhang.CreateDocument();
            Loaddata();
        }

        //Tổng hợp bán hàng theo mặt hàng
        private void navBar_Tonghop_Banhang_Mathang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            XtraReports.rptWare_Banhang_Tonghop_Mathang rptBanhang_Tonghop = new Ecm.Reports.XtraReports.rptWare_Banhang_Tonghop_Mathang();
            setHesoChuongtrinh(rptBanhang_Tonghop.xrc_CompanyName, rptBanhang_Tonghop.xrc_CompanyAddress, null);
            printControl_Baocao.PrintingSystem = rptBanhang_Tonghop.PrintingSystem;
            this.report = "rptWare_Banhang_Tonghop_Mathang";
            rptBanhang_Tonghop.xrTableCell_KH.Text = lookUpEdit_Khachhang.Text + " - " + lookUpEdit_Doituong.Text;
            rptBanhang_Tonghop.CreateDocument();
            Loaddata();
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            XtraReports.rptWare_Banhang_Tonghop_Khuvuc rptBanhang_Tonghop = new Ecm.Reports.XtraReports.rptWare_Banhang_Tonghop_Khuvuc();
            setHesoChuongtrinh(rptBanhang_Tonghop.xrc_CompanyName, rptBanhang_Tonghop.xrc_CompanyAddress, rptBanhang_Tonghop.xrPic_Logo);
            printControl_Baocao.PrintingSystem = rptBanhang_Tonghop.PrintingSystem;
            this.report = "rptWare_Banhang_Tonghop_Khuvuc";
            rptBanhang_Tonghop.CreateDocument();
            Loaddata();
        }

        #endregion

        #region Custom Moethod

        void setNgay_Thang_Nam(DevExpress.XtraReports.UI.XRTableCell ngay, DevExpress.XtraReports.UI.XRTableCell thang, DevExpress.XtraReports.UI.XRTableCell nam)
        {
            ngay.Text = DateTime.Now.Day.ToString();
            thang.Text = DateTime.Now.Month.ToString();
            nam.Text = DateTime.Now.Year.ToString();
        }

        void setHesoChuongtrinh(DevExpress.XtraReports.UI.XRTableCell companyName,
           DevExpress.XtraReports.UI.XRTableCell companyAddress, DevExpress.XtraReports.UI.XRPictureBox companyLogo)
        {
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

                companyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                companyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                //companyLogo.DataBindings.Add(
                //    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }
        }

        private void Load_rptWare_Banhang_Congno_Thu()
        {
            try
            {
                System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
                hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
                hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return;

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                    return;

                GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
                //gọi report cong no da thu
                Ecm.Reports.XtraReports.rptWare_Banhang_Congno_Thu _rptWare_Banhang_Congno_Thu = new Ecm.Reports.XtraReports.rptWare_Banhang_Congno_Thu();
                _FrmPrintPreview.Report = _rptWare_Banhang_Congno_Thu;
                // gán dữ liệu vào dataset
                // dữ liệu được lấy từ webservice.
                DataSet ds_Congnothu = objWareService.Get_RptWare_Banhang_Congno_Thu(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEdit_Doituong.EditValue).ToDataSet();

                // Thiết lập hệ số chương trình (Logo, thông tin công ty)
                setHesoChuongtrinh(_rptWare_Banhang_Congno_Thu.xrc_CompanyName, _rptWare_Banhang_Congno_Thu.xrc_CompanyAddress, _rptWare_Banhang_Congno_Thu.xrPic_Logo);
                _rptWare_Banhang_Congno_Thu.xrTable_tungay.Text = dtNgay_Batdau.DateTime.ToString("dd/MM/yyyy");
                _rptWare_Banhang_Congno_Thu.xrTable_Denngay.Text = dtNgay_Ketthuc.DateTime.ToString("dd/MM/yyyy");
                _rptWare_Banhang_Congno_Thu.xrTable_Ngay.Text = DateTime.Today.Day.ToString();
                _rptWare_Banhang_Congno_Thu.xrTable_Thang.Text = DateTime.Today.Month.ToString();
                _rptWare_Banhang_Congno_Thu.xrTable_Nam.Text = DateTime.Today.Year.ToString();
                _rptWare_Banhang_Congno_Thu.DataSource = ds_Congnothu;

                _rptWare_Banhang_Congno_Thu.CreateDocument();
                GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_rptWare_Banhang_Congno_Thu);
                if (Convert.ToBoolean(oReportOptions.PrintPreview))
                {
                    _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                    _FrmPrintPreview.printControl1.PrintingSystem = _rptWare_Banhang_Congno_Thu.PrintingSystem;
                    _FrmPrintPreview.MdiParent = this.MdiParent;
                    _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
                    _FrmPrintPreview.Show();
                    _FrmPrintPreview.Activate();
                }
                else
                {
                    var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_rptWare_Banhang_Congno_Thu);
                    ReportPrintTool.Print();
                }
                _FrmPrintPreview.Show();
                _FrmPrintPreview.Activate();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void Load_rptWare_Banhang_Congno_Chuathu()
        {
            try
            {
                System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
                hashtableControls.Add(lookUpEdit_Doituong, lblDoituong.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return;

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                    return;

                DataSet ds_Congno_Chuathu = objWareService.Get_RptWare_Banhang_Congno_Chuathu(lookUpEdit_Doituong.EditValue).ToDataSet();
                Ecm.Reports.XtraReports.rptWare_Banhang_Congno_Chuathu _rptWare_Banhang_Congno_Chuathu = new Ecm.Reports.XtraReports.rptWare_Banhang_Congno_Chuathu();
                GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
                _FrmPrintPreview.Report = _rptWare_Banhang_Congno_Chuathu;
                //Thiết lập hệ số chương trình (Logo, thông tin công ty
                setHesoChuongtrinh(_rptWare_Banhang_Congno_Chuathu.xrc_CompanyName, _rptWare_Banhang_Congno_Chuathu.xrc_CompanyAddress, _rptWare_Banhang_Congno_Chuathu.xrPic_Logo);

                _rptWare_Banhang_Congno_Chuathu.xrTable_Denngay.Text = DateTime.Today.ToString("dd/MM/yyyy");
                _rptWare_Banhang_Congno_Chuathu.xrTable_Ngay.Text = DateTime.Today.Day.ToString();
                _rptWare_Banhang_Congno_Chuathu.xrTable_Thang.Text = DateTime.Today.Month.ToString();
                _rptWare_Banhang_Congno_Chuathu.xrTable_Nam.Text = DateTime.Today.Year.ToString();
                _rptWare_Banhang_Congno_Chuathu.xrTable_Khachhang.Text = lookUpEdit_Doituong.Text;
                _rptWare_Banhang_Congno_Chuathu.DataSource = ds_Congno_Chuathu;
                _rptWare_Banhang_Congno_Chuathu.CreateDocument();
                GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_rptWare_Banhang_Congno_Chuathu);
                if (Convert.ToBoolean(oReportOptions.PrintPreview))
                {
                    _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                    _FrmPrintPreview.printControl1.PrintingSystem = _rptWare_Banhang_Congno_Chuathu.PrintingSystem;
                    _FrmPrintPreview.MdiParent = this.MdiParent;
                    _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
                    _FrmPrintPreview.Show();
                    _FrmPrintPreview.Activate();
                }
                else
                {
                    var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_rptWare_Banhang_Congno_Chuathu);
                    ReportPrintTool.Print();
                }
                _FrmPrintPreview.Show();
                _FrmPrintPreview.Activate();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }

        }

        //Báo cáo chi tiết tiền hàng trả lại
        protected void Load_rptWare_Hh_Kh_Tra()
        {
            System.Collections.Hashtable hastTable = new System.Collections.Hashtable();
            hastTable.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hastTable.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            hastTable.Add(lookUpEditCuahang_Ban, lblCuahang_Ban.Text);

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hastTable))
                return;

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return;

            Reports.XtraReports.rptWare_Banhang_Nhaptra_Chitiet rpt_Nhaptra_Chitiet = new Ecm.Reports.XtraReports.rptWare_Banhang_Nhaptra_Chitiet();
            Datasets.DsWare_Hh_Kh_Tra dsHh_Kh_Tra = new Ecm.Reports.Datasets.DsWare_Hh_Kh_Tra();
            //DataSet dsTemp = objWareService.Get_All_Ware_Hh_Kh_Tra_Chitiet_ByKhachhang(lookUpEdit_Doituong.EditValue, dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEditCuahang_Ban.EditValue).ToDataSet();
            DataSet dsTemp = new DataSet();
            int i = 1;
            foreach (DataRow dtr in dsTemp.Tables[0].Rows)
            {
                DataRow dtrNew = dsHh_Kh_Tra.Tables[0].NewRow();
                foreach (DataColumn dtc in dsTemp.Tables[0].Columns)
                {
                    try
                    {
                        dtrNew[dtc.ColumnName] = dtr[dtc.ColumnName];
                    }
                    catch (Exception ex)
                    { }
                }
                dtrNew["Stt"] = i;
                i++;
                dsHh_Kh_Tra.Tables[0].Rows.Add(dtrNew);
            }
            GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            _FrmPrintPreview.Report = rpt_Nhaptra_Chitiet;

            setHesoChuongtrinh(rpt_Nhaptra_Chitiet.xrc_CompanyName, rpt_Nhaptra_Chitiet.xrc_CompanyAddress, rpt_Nhaptra_Chitiet.xrPic_Logo);
            rpt_Nhaptra_Chitiet.xrTable_Tungay.Text = dtNgay_Batdau.Text;
            rpt_Nhaptra_Chitiet.xrTable_Denngay.Text = dtNgay_Ketthuc.Text;
            rpt_Nhaptra_Chitiet.xrTable_Kho.Text = lookUpEditCuahang_Ban.Text;
            rpt_Nhaptra_Chitiet.xrKhachhang.Text = lookUpEdit_Doituong.Text;
            rpt_Nhaptra_Chitiet.DataSource = dsHh_Kh_Tra;
            rpt_Nhaptra_Chitiet.CreateDocument();
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(rpt_Nhaptra_Chitiet);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                _FrmPrintPreview.printControl1.PrintingSystem = rpt_Nhaptra_Chitiet.PrintingSystem;
                _FrmPrintPreview.MdiParent = this.MdiParent;
                _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
                _FrmPrintPreview.Show();
                _FrmPrintPreview.Activate();
            }
            else
            {
                var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rpt_Nhaptra_Chitiet);
                ReportPrintTool.Print();
            }
            _FrmPrintPreview.Show();
            _FrmPrintPreview.Activate();
        }

        private void Load_Rptware_Banhang_Congno_Tonghop()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            //hashtableControls.Add(lookUpEditCuahang_Ban, lblCuahang_Ban.Text);

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return;

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return;

            XtraReports.rptWare_Banhang_Congno_Tonghop _rptWare_Banhang_Congno_Tonghop = new Ecm.Reports.XtraReports.rptWare_Banhang_Congno_Tonghop();
            GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            _FrmPrintPreview.Report = _rptWare_Banhang_Congno_Tonghop;
            // Thiết lập hệ số chương trình (Logo, thông tin công ty)
            setHesoChuongtrinh(_rptWare_Banhang_Congno_Tonghop.xrc_CompanyName, _rptWare_Banhang_Congno_Tonghop.xrc_CompanyAddress, null);

            _rptWare_Banhang_Congno_Tonghop.Parameters["Tungay"].Value = dtNgay_Batdau.Text;
            _rptWare_Banhang_Congno_Tonghop.Parameters["Denngay"].Value = dtNgay_Ketthuc.Text;

            DataSet dsReport = objReportService.Rptware_Banhang_Congno_Tonghop(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEdit_Doituong.EditValue).ToDataSet();
            _rptWare_Banhang_Congno_Tonghop.DataSource = dsReport;
            _rptWare_Banhang_Congno_Tonghop.CreateDocument();
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_rptWare_Banhang_Congno_Tonghop);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                _FrmPrintPreview.printControl1.PrintingSystem = _rptWare_Banhang_Congno_Tonghop.PrintingSystem;
                _FrmPrintPreview.MdiParent = this.MdiParent;
                _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
                _FrmPrintPreview.Show();
                _FrmPrintPreview.Activate();
            }
            else
            {
                var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_rptWare_Banhang_Congno_Tonghop);
                ReportPrintTool.Print();
            }
            _FrmPrintPreview.Show();
            _FrmPrintPreview.Activate();
        }

        private void Load_Rptware_Banhang_Chitiet()
        {
            if (lookUpEdit_Doituong.EditValue == null)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn khách hàng", "Thông tin...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpEdit_Khachhang.Focus();
                return;
            }
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            //hashtableControls.Add(lookUpEditCuahang_Ban, lblCuahang_Ban.Text);


            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return;
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return;

            XtraReports.rptWare_Banhang_Chitiet _rptWare_Banhang_Chitiet = new Ecm.Reports.XtraReports.rptWare_Banhang_Chitiet();
            GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            _FrmPrintPreview.Report = _rptWare_Banhang_Chitiet;
            // Thiết lập hệ số chương trình (Logo, thông tin công ty)
            setHesoChuongtrinh(_rptWare_Banhang_Chitiet.xrc_CompanyName, _rptWare_Banhang_Chitiet.xrc_CompanyAddress, null);
            _rptWare_Banhang_Chitiet.GroupHeader_KH.Visible = false;
            _rptWare_Banhang_Chitiet.Parameters["Tungay"].Value = dtNgay_Batdau.Text;
            _rptWare_Banhang_Chitiet.Parameters["Denngay"].Value = dtNgay_Ketthuc.Text;
            _rptWare_Banhang_Chitiet.xrTableRow_KH.Visible = true;
            _rptWare_Banhang_Chitiet.xrTable_Ngay.Text = DateTime.Today.Day.ToString();
            _rptWare_Banhang_Chitiet.xrTable_Thang.Text = DateTime.Today.Month.ToString();
            _rptWare_Banhang_Chitiet.xrTable_Nam.Text = DateTime.Today.Year.ToString();

            _rptWare_Banhang_Chitiet.xrTableCell_TenKH.Text = lookUpEdit_Khachhang.Text + " - " + lookUpEdit_Doituong.Text;
            DataSet dsReport = objReportService.Rptware_Banhang_Chitiet_Hanghoa(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEdit_Doituong.EditValue, lookUpEdit_Mahang.EditValue).ToDataSet();
            _rptWare_Banhang_Chitiet.DataSource = dsReport;
            _rptWare_Banhang_Chitiet.CreateDocument();
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_rptWare_Banhang_Chitiet);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                _FrmPrintPreview.printControl1.PrintingSystem = _rptWare_Banhang_Chitiet.PrintingSystem;
                _FrmPrintPreview.MdiParent = this.MdiParent;
                _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
                _FrmPrintPreview.Show();
                _FrmPrintPreview.Activate();
            }
            else
            {
                var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_rptWare_Banhang_Chitiet);
                ReportPrintTool.Print();
            }
            _FrmPrintPreview.Show();
            _FrmPrintPreview.Activate();
        }

        //Tổng hợp bán hàng theo mặt hàng
        private void Load_Rpt_Ware_Hh_Ban_Tonghop_ByMathang()
        {
            if (lookUpEdit_Doituong.EditValue == null)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn khách hàng", "Thông tin...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpEdit_Doituong.Focus();
                return;
            }
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return;
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return;

            XtraReports.rptWare_Banhang_Tonghop_Mathang rptBanhang_Tonghop = new Ecm.Reports.XtraReports.rptWare_Banhang_Tonghop_Mathang();
            GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            _FrmPrintPreview.Report = rptBanhang_Tonghop;
            setHesoChuongtrinh(rptBanhang_Tonghop.xrc_CompanyName, rptBanhang_Tonghop.xrc_CompanyAddress, null);
            DataSet dsReport = objReportService.RptWare_Hdbanhang_ByLoaihanghoa_new(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEdit_Doituong.EditValue, null, null, lookUpEdit_MaNhomhang.EditValue).ToDataSet();
            rptBanhang_Tonghop.xrDate_From.Text = dtNgay_Batdau.Text;
            rptBanhang_Tonghop.xrDate_To.Text = dtNgay_Ketthuc.Text;
            rptBanhang_Tonghop.xrTableCell_KH.Text = lookUpEdit_Khachhang.Text + " - " + lookUpEdit_Doituong.Text;
            setNgay_Thang_Nam(rptBanhang_Tonghop.xrNgay, rptBanhang_Tonghop.xrThang, rptBanhang_Tonghop.xrNam);
            rptBanhang_Tonghop.DataSource = dsReport;
            rptBanhang_Tonghop.CreateDocument();
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(rptBanhang_Tonghop);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                _FrmPrintPreview.printControl1.PrintingSystem = rptBanhang_Tonghop.PrintingSystem;
                _FrmPrintPreview.MdiParent = this.MdiParent;
                _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
                _FrmPrintPreview.Show();
                _FrmPrintPreview.Activate();
            }
            else
            {
                var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rptBanhang_Tonghop);
                ReportPrintTool.Print();
            }
            _FrmPrintPreview.Show();
            _FrmPrintPreview.Activate();
            //System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            //hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            //hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            //if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
            //    return;
            //if (! GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
            //    return;

            //XtraReports.rptWare_Banhang_Tonghop_Mathang rptBanhang_Tonghop = new Ecm.Reports.XtraReports.rptWare_Banhang_Tonghop_Mathang();
            //setHesoChuongtrinh(rptBanhang_Tonghop.xrc_CompanyName, rptBanhang_Tonghop.xrc_CompanyAddress, rptBanhang_Tonghop.xrPic_Logo);
            //DataSet dsReport = objReportService.RptWare_Hdbanhang_ByLoaihanghoa(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUp_Loai_Hanghoa_Ban.EditValue, lookUpEdit_Doituong.EditValue);
            //rptBanhang_Tonghop.xrDate_From.Text = dtNgay_Batdau.Text;
            //rptBanhang_Tonghop.xrDate_To.Text = dtNgay_Ketthuc.Text;
            //setNgay_Thang_Nam(rptBanhang_Tonghop.xrNgay, rptBanhang_Tonghop.xrThang, rptBanhang_Tonghop.xrNam);

            //rptBanhang_Tonghop.DataSource = dsReport;
            //rptBanhang_Tonghop.ShowPreview();
        }

        //Tổng hợp bán hàng theo khách hàng
        private void Load_Rpt_Ware_Hh_Ban_Tonghop_ByKhachhang()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return;
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return;
            XtraReports.rptWare_Banhang_Tonghop_Khachhang rpt_Tonghop_Khachhang = new Ecm.Reports.XtraReports.rptWare_Banhang_Tonghop_Khachhang();
            GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            _FrmPrintPreview.Report = rpt_Tonghop_Khachhang;
            setHesoChuongtrinh(rpt_Tonghop_Khachhang.xrc_CompanyName, rpt_Tonghop_Khachhang.xrc_CompanyAddress, null);
            DataSet dsReport = new DataSet(); //objReportService.RptWare_Tonghop_Banhang_ByKhachhang(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEdit_Doituong.EditValue).ToDataSet();
            rpt_Tonghop_Khachhang.xrDate_From.Text = dtNgay_Batdau.Text;
            rpt_Tonghop_Khachhang.xrDate_To.Text = dtNgay_Ketthuc.Text;
            setNgay_Thang_Nam(rpt_Tonghop_Khachhang.xrNgay, rpt_Tonghop_Khachhang.xrThang, rpt_Tonghop_Khachhang.xrNam);

            rpt_Tonghop_Khachhang.DataSource = dsReport;
            rpt_Tonghop_Khachhang.CreateDocument();
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(rpt_Tonghop_Khachhang);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                _FrmPrintPreview.printControl1.PrintingSystem = rpt_Tonghop_Khachhang.PrintingSystem;
                _FrmPrintPreview.MdiParent = this.MdiParent;
                _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
                _FrmPrintPreview.Show();
                _FrmPrintPreview.Activate();
            }
            else
            {
                var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rpt_Tonghop_Khachhang);
                ReportPrintTool.Print();
            }
            _FrmPrintPreview.Show();
            _FrmPrintPreview.Activate();
        }

        //Tổng hợp bán hàng theo Nhân viên
        private void Load_Rpt_Hh_Bah_Tonghop_ByNhanvien()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return;
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return;

            XtraReports.rptWare_Banhang_Tonghop_Nhanvien rpt_Tonghop_Nhanvien = new Ecm.Reports.XtraReports.rptWare_Banhang_Tonghop_Nhanvien();            
            GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            _FrmPrintPreview.Report = rpt_Tonghop_Nhanvien;

            setHesoChuongtrinh(rpt_Tonghop_Nhanvien.xrc_CompanyName, rpt_Tonghop_Nhanvien.xrc_CompanyAddress, null);
            rpt_Tonghop_Nhanvien.xrDate_From.Text = dtNgay_Batdau.Text;
            rpt_Tonghop_Nhanvien.xrDate_To.Text = dtNgay_Ketthuc.Text;
            setNgay_Thang_Nam(rpt_Tonghop_Nhanvien.xrNgay, rpt_Tonghop_Nhanvien.xrThang, rpt_Tonghop_Nhanvien.xrNam);
            DataSet dsReport = objReportService.RptWare_Hdbanhang_ByNhanvien_Loaihang(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, null, lookUpEdit_Doituong.EditValue, lookUpEdit_MaNhomhang.EditValue).ToDataSet();
            rpt_Tonghop_Nhanvien.DataSource = dsReport;
            rpt_Tonghop_Nhanvien.CreateDocument();
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(rpt_Tonghop_Nhanvien);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                _FrmPrintPreview.printControl1.PrintingSystem = rpt_Tonghop_Nhanvien.PrintingSystem;
                _FrmPrintPreview.MdiParent = this.MdiParent;
                _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
                _FrmPrintPreview.Show();
                _FrmPrintPreview.Activate();
            }
            else
            {
                var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rpt_Tonghop_Nhanvien);
                ReportPrintTool.Print();
            }
            _FrmPrintPreview.Show();
            _FrmPrintPreview.Activate();
        }

        private void Load_Rpt_Ware_Hh_Ban_Tonghop_ByMathang_Nhanvien_Bh()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return;
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return;

            if (lookUpEdit_Nhansu_Banhang.EditValue == null)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn nhân viên bán hàng", "Thông tin...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpEdit_Nhansu_Banhang.Focus();
                return;
            }
            XtraReports.rptWare_Banhang_Tonghop_Mathang rptBanhang_Tonghop = new Ecm.Reports.XtraReports.rptWare_Banhang_Tonghop_Mathang();
            GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            _FrmPrintPreview.Report = rptBanhang_Tonghop;

            DataSet dsReport = objReportService.RptWare_Hdbanhang_ByLoaihanghoa_ByNhanvien_New(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEdit_Nhansu_Banhang.EditValue, null, lookUpEdit_MaNhomhang.EditValue).ToDataSet();
            rptBanhang_Tonghop.xrDate_From.Text = dtNgay_Batdau.Text;
            rptBanhang_Tonghop.xrDate_To.Text = dtNgay_Ketthuc.Text;
            rptBanhang_Tonghop.xrTableRow_Nhanvien_Bh.Visible = true;
            rptBanhang_Tonghop.xrTableCell_Nhanvien_Bh.Text = lookUpEdit_Nhansu_Banhang.Text.ToUpper();
            rptBanhang_Tonghop.xrLabel_Titlle.Text = "TỔNG HỢP CHI TIẾT BÁN HÀNG THEO NHÂN VIÊN";
            rptBanhang_Tonghop.xrTableRow_KH.Visible = false;
            setNgay_Thang_Nam(rptBanhang_Tonghop.xrNgay, rptBanhang_Tonghop.xrThang, rptBanhang_Tonghop.xrNam);
            setHesoChuongtrinh(rptBanhang_Tonghop.xrc_CompanyName, rptBanhang_Tonghop.xrc_CompanyAddress, null);
            rptBanhang_Tonghop.DataSource = dsReport;
            rptBanhang_Tonghop.CreateDocument();
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(rptBanhang_Tonghop);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                _FrmPrintPreview.printControl1.PrintingSystem = rptBanhang_Tonghop.PrintingSystem;
                _FrmPrintPreview.MdiParent = this.MdiParent;
                _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
                _FrmPrintPreview.Show();
                _FrmPrintPreview.Activate();
            }
            else
            {
                var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rptBanhang_Tonghop);
                ReportPrintTool.Print();
            }
            _FrmPrintPreview.Show();
            _FrmPrintPreview.Activate();
        }

        /// <summary>
        /// Tổng hợp bán hàng theo khu vực
        /// </summary>
        private void Load_Rptware_Banhang_Tonghop_Khuvuc()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            hashtableControls.Add(lookUpEditCuahang_Ban, lblCuahang_Ban.Text);

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return;
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return;

            XtraReports.rptWare_Banhang_Tonghop_Khuvuc rpt_Tonghop = new Ecm.Reports.XtraReports.rptWare_Banhang_Tonghop_Khuvuc();
            GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            _FrmPrintPreview.Report = rpt_Tonghop;

            setHesoChuongtrinh(rpt_Tonghop.xrc_CompanyName, rpt_Tonghop.xrc_CompanyAddress, rpt_Tonghop.xrPic_Logo);
            rpt_Tonghop.paramTungay.Value = dtNgay_Batdau.Text;
            rpt_Tonghop.paramDenngay.Value = dtNgay_Ketthuc.Text;
            rpt_Tonghop.paramCuahang.Value = lookUpEditCuahang_Ban.Text;
            DataSet dsReport = objReportService.RptWare_Hdbanhang_ByKhuvuc(Convert.ToDateTime(dtNgay_Batdau.EditValue), Convert.ToDateTime(dtNgay_Ketthuc.EditValue), Convert.ToInt64(lookUpEditCuahang_Ban.EditValue)).ToDataSet();
            rpt_Tonghop.DataSource = dsReport;
            DataSet dsSubReport = objReportService.RptWare_Hh_Kh_Tra(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, null, lookUpEditCuahang_Ban.EditValue, null, null).ToDataSet();
            //XtraReports.rptWare_Hh_Kh_Tra _rptWare_Hh_Kh_Tra = new Ecm.Reports.XtraReports.rptWare_Hh_Kh_Tra();
            //_rptWare_Hh_Kh_Tra.DataSource = dsSubReport;
            //rpt_Tonghop.Subreport.ReportSource = _rptWare_Hh_Kh_Tra;
            rpt_Tonghop.CreateDocument();
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(rpt_Tonghop);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                _FrmPrintPreview.printControl1.PrintingSystem = rpt_Tonghop.PrintingSystem;
                _FrmPrintPreview.MdiParent = this.MdiParent;
                _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
                _FrmPrintPreview.Show();
                _FrmPrintPreview.Activate();
            }
            else
            {
                var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rpt_Tonghop);
                ReportPrintTool.Print();
            }
            _FrmPrintPreview.Show();
            _FrmPrintPreview.Activate();
        }

        protected void Loaddata()
        {
            //lookUpEditCuahang_Ban.EditValue = null;
            //lookUpEdit_Doituong.EditValue = null;
            //lookUpEdit_Khachhang.EditValue = null;
            //lookUpEdit_Hanghoa_Ban.EditValue = null;
            //lookUp_Loai_Hanghoa_Ban.EditValue = null;

            //dtNgay_Batdau.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            //dtNgay_Ketthuc.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1);
            //lookUpEditCuahang_Ban.Focus();
        }

        //công nợ chi tiết
        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Congno_Chitiet _rptWare_Congno_Chitiet = new Ecm.Reports.XtraReports.rptWare_Congno_Chitiet();
            this.report = "rptWare_Congno_Chitiet";
            setHesoChuongtrinh(_rptWare_Congno_Chitiet.xrc_CompanyName, _rptWare_Congno_Chitiet.xrc_CompanyAddress, null);
            printControl_Baocao.PrintingSystem = _rptWare_Congno_Chitiet.PrintingSystem;
            _rptWare_Congno_Chitiet.CreateDocument();
            Loaddata();
        }

        private void Load_rptWare_Congno_Chitiet()
        {
            try
            {
                System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
                hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
                hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return;

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                    return;

                DataSet ds_Congnothu = objReportService.Rptware_Congno_Chitiet(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEdit_Doituong.EditValue).ToDataSet();
                Ecm.Reports.XtraReports.rptWare_Congno_Chitiet _rptWare_Congno_Chitiet = new Ecm.Reports.XtraReports.rptWare_Congno_Chitiet();
                //_rptWare_Congno_Chitiet.xrTable_Ngay.Text = DateTime.Today.Day.ToString();
                //_rptWare_Congno_Chitiet.xrTable_Thang.Text = DateTime.Today.Month.ToString();
                //_rptWare_Congno_Chitiet.xrTable_Nam.Text = DateTime.Today.Year.ToString();
                _rptWare_Congno_Chitiet.DataSource = ds_Congnothu;
                GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
                _FrmPrintPreview.Report = _rptWare_Congno_Chitiet;
                // Thiết lập hệ số chương trình (Logo, thông tin công ty)
                setHesoChuongtrinh(_rptWare_Congno_Chitiet.xrc_CompanyName, _rptWare_Congno_Chitiet.xrc_CompanyAddress, null);
                _rptWare_Congno_Chitiet.xrDate_From.Text = dtNgay_Batdau.DateTime.ToString("dd/MM/yyyy");
                _rptWare_Congno_Chitiet.xrDate_To.Text = dtNgay_Ketthuc.DateTime.ToString("dd/MM/yyyy");
                _rptWare_Congno_Chitiet.CreateDocument();
                GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_rptWare_Congno_Chitiet);
                if (Convert.ToBoolean(oReportOptions.PrintPreview))
                {
                    _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                    _FrmPrintPreview.printControl1.PrintingSystem = _rptWare_Congno_Chitiet.PrintingSystem;
                    _FrmPrintPreview.MdiParent = this.MdiParent;
                    _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
                    _FrmPrintPreview.Show();
                    _FrmPrintPreview.Activate();
                }
                else
                {
                    var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_rptWare_Congno_Chitiet);
                    ReportPrintTool.Print();
                }
                _FrmPrintPreview.Show();
                _FrmPrintPreview.Activate();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }

        #endregion

        private void lookUpEditCuahang_Ban_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEdit_Doituong.Properties.DataSource = objMasterService.Ware_Dm_Khachhang_SelectBy_Khuvuc(lookUpEditCuahang_Ban.EditValue).ToDataSet().Tables[0];
            lookUpEdit_Khachhang.Properties.DataSource = objMasterService.Ware_Dm_Khachhang_SelectBy_Khuvuc(lookUpEditCuahang_Ban.EditValue).ToDataSet().Tables[0];
        }

        private void lookUpEdit_Khachhang_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEdit_Doituong.EditValue = lookUpEdit_Khachhang.EditValue;
        }

        private void navBarItem4_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            XtraReports.rptWare_Banhang_Tonghop_Mathang rptBanhang_Tonghop = new Ecm.Reports.XtraReports.rptWare_Banhang_Tonghop_Mathang();
            rptBanhang_Tonghop.xrTableRow_Nhanvien_Bh.Visible = true;
            setHesoChuongtrinh(rptBanhang_Tonghop.xrc_CompanyName, rptBanhang_Tonghop.xrc_CompanyAddress, null);
            printControl_Baocao.PrintingSystem = rptBanhang_Tonghop.PrintingSystem;
            rptBanhang_Tonghop.xrTableCell_Nhanvien_Bh.Text = lookUpEdit_Nhansu_Banhang.Text.ToUpper();
            rptBanhang_Tonghop.xrLabel_Titlle.Text = "CHI TIẾT BÁN HÀNG THEO NHÂN VIÊN";
            this.report = "rptWare_Banhang_Tonghop_Mathang_Nhanvien_Bh";
            rptBanhang_Tonghop.CreateDocument();
            Loaddata();
        }

        private void lookUpEdit_Khachhang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                lookUpEdit_Khachhang.EditValue = null;
        }

        private void lookUpEdit_Nhansu_Banhang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                lookUpEdit_Nhansu_Banhang.EditValue = null;
        }

        private void lookUpEdit_Mahang_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEdit_Tenhang.EditValue = lookUpEdit_Mahang.EditValue;
        }

        private void lookUpEdit_Mahang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                lookUpEdit_Mahang.EditValue = null;
        }

        private void lookUpEdit_MaNhomhang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                lookUpEdit_MaNhomhang.EditValue = null;
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            XtraReports.rptWare_Baocao_Banhang rptBaocao_Banhang = new Ecm.Reports.XtraReports.rptWare_Baocao_Banhang();
            rptBaocao_Banhang.xrTableRow_Nhanvien_Bh.Visible = true;
            setHesoChuongtrinh(rptBaocao_Banhang.xrc_CompanyName, rptBaocao_Banhang.xrc_CompanyAddress, null);
            printControl_Baocao.PrintingSystem = rptBaocao_Banhang.PrintingSystem;
            rptBaocao_Banhang.xrTableCell_Nhanvien_Bh.Text = lookUpEdit_Nhansu_Banhang.Text.ToUpper();
            this.report = "rptWare_Baocao_Banhang";
            rptBaocao_Banhang.CreateDocument();
        }

        private void Load_rptWare_Baocao_Giavon_Giaban()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return;
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return;           

            XtraReports.rptWare_Baocao_Giavon_Giaban _rptWare_Baocao_Giavon_Giaban = new Ecm.Reports.XtraReports.rptWare_Baocao_Giavon_Giaban();

           
            GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            _FrmPrintPreview.Report = _rptWare_Baocao_Giavon_Giaban;
            setHesoChuongtrinh(_rptWare_Baocao_Giavon_Giaban.xrc_Table_CompanyName, _rptWare_Baocao_Giavon_Giaban.xrc_Table_Address, null);

           
           //DataSet dsReport = objReportService.Rptware_Banhang_Chitiet_Hanghoa(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEdit_Doituong.EditValue, lookUpEdit_Mahang.EditValue).ToDataSet();
           // DataSet dsReport = objReportService.Rptware_Banhang_Chitiet_Hanghoa(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEdit_Doituong.EditValue ,lookUpEdit_Nhansu_Banhang.EditValue, null, lookUpEdit_MaNhomhang.EditValue).ToDataSet();

            DataSet dsReport = new DataSet();  //objReportService.RptWare_Baocao_Trigia_Giavon_Giaban(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEdit_Doituong.EditValue, lookUpEditCuahang_Ban.EditValue, lookUpEdit_MaNhomhang.EditValue, lookUpEdit_Mahang.EditValue).ToDataSet();
            _rptWare_Baocao_Giavon_Giaban.xrTableCell_Tungay.Text = dtNgay_Batdau.Text;
            _rptWare_Baocao_Giavon_Giaban.xrTableCell_Denngay.Text = dtNgay_Ketthuc.Text;
            setNgay_Thang_Nam(_rptWare_Baocao_Giavon_Giaban.xrTable_Ngay, _rptWare_Baocao_Giavon_Giaban.xrTable_Thang, _rptWare_Baocao_Giavon_Giaban.xrTable_Nam);
            _rptWare_Baocao_Giavon_Giaban.DataSource = dsReport;
            _rptWare_Baocao_Giavon_Giaban.CreateDocument();
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_rptWare_Baocao_Giavon_Giaban);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                _FrmPrintPreview.printControl1.PrintingSystem = _rptWare_Baocao_Giavon_Giaban.PrintingSystem;
                _FrmPrintPreview.MdiParent = this.MdiParent;
                _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
                _FrmPrintPreview.Show();
                _FrmPrintPreview.Activate();
            }
            else
            {
                var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_rptWare_Baocao_Giavon_Giaban);
                ReportPrintTool.Print();
            }
            _FrmPrintPreview.Show();
            _FrmPrintPreview.Activate();
        }

        private void Load_rptWare_Baocao_Banhang()
        {
            //if (lookUpEdit_Doituong.EditValue == null)
            //{
            //    GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn khách hàng", "Thông tin...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    lookUpEdit_Doituong.Focus();
            //    return;
            //}
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return;
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return;

            XtraReports.rptWare_Baocao_Banhang _rptWare_Baocao_Banhang = new Ecm.Reports.XtraReports.rptWare_Baocao_Banhang();
            GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            _FrmPrintPreview.Report = _rptWare_Baocao_Banhang;
            setHesoChuongtrinh(_rptWare_Baocao_Banhang.xrc_CompanyName, _rptWare_Baocao_Banhang.xrc_CompanyAddress, null);
            DataSet dsReport = objReportService.RptWare_Hdbanhang_ByLoaihanghoa_new(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEdit_Doituong.EditValue, lookUpEdit_Nhansu_Banhang.EditValue, null, lookUpEdit_MaNhomhang.EditValue).ToDataSet();
            _rptWare_Baocao_Banhang.xrDate_From.Text = dtNgay_Batdau.Text;
            _rptWare_Baocao_Banhang.xrDate_To.Text = dtNgay_Ketthuc.Text;
            _rptWare_Baocao_Banhang.xrTableRow_Nhanvien_Bh.Visible = true;
            _rptWare_Baocao_Banhang.xrTableCell_Nhanvien_Bh.Text = lookUpEdit_Nhansu_Banhang.Text;
            setNgay_Thang_Nam(_rptWare_Baocao_Banhang.xrNgay, _rptWare_Baocao_Banhang.xrThang, _rptWare_Baocao_Banhang.xrNam);
            _rptWare_Baocao_Banhang.DataSource = dsReport;
            _rptWare_Baocao_Banhang.CreateDocument();
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_rptWare_Baocao_Banhang);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                _FrmPrintPreview.printControl1.PrintingSystem = _rptWare_Baocao_Banhang.PrintingSystem;
                _FrmPrintPreview.MdiParent = this.MdiParent;
                _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
                _FrmPrintPreview.Show();
                _FrmPrintPreview.Activate();
            }
            else
            {
                var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_rptWare_Baocao_Banhang);
                ReportPrintTool.Print();
            }
            _FrmPrintPreview.Show();
            _FrmPrintPreview.Activate();
        }

        private void navBar_Baocao_Giavon_Giaban_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Baocao_Giavon_Giaban _rptWare_Baocao_Giavon_Giaban = new Ecm.Reports.XtraReports.rptWare_Baocao_Giavon_Giaban();
            printControl_Baocao.PrintingSystem = _rptWare_Baocao_Giavon_Giaban.PrintingSystem;          
            this.report = "rptWare_Baocao_Giavon_Giaban";
            setHesoChuongtrinh(_rptWare_Baocao_Giavon_Giaban.xrc_Table_CompanyName, _rptWare_Baocao_Giavon_Giaban.xrc_Table_Address, null);
            
            _rptWare_Baocao_Giavon_Giaban.CreateDocument();
            Loaddata();
        }

        private void lookUpEdit_MaNhomhang_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit_MaNhomhang.EditValue != null)
            {
                DataSet ds_collection = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban_By_Id_Loai_Hanghoa_Ban(lookUpEdit_MaNhomhang.EditValue).ToDataSet();
                lookUpEdit_Mahang.Properties.DataSource = ds_collection.Tables[0];
                lookUpEdit_Tenhang.Properties.DataSource = ds_collection.Tables[0];
            }
            else
            {
                DataSet ds_collection = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
                lookUpEdit_Mahang.Properties.DataSource = ds_collection.Tables[0];
                lookUpEdit_Tenhang.Properties.DataSource = ds_collection.Tables[0];
            }
        }

    }
}

