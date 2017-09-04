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
    public partial class FrmRptware_Baocao_Muahang :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        string report = "";
        Ecm.WebReferences.Classes.WareService objWareService = new Ecm.WebReferences.Classes.WareService();
        Ecm.WebReferences.Classes.MasterService objMasterService = new Ecm.WebReferences.Classes.MasterService();
        Ecm.WebReferences.Classes.ReportService objReportService = new Ecm.WebReferences.Classes.ReportService();

        public FrmRptware_Baocao_Muahang()
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

            lookUp_Loai_Hanghoa_Ban.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler( GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            lookUpEdit_Doituong.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler( GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            lookUpEdit_Hanghoa_Ban.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler( GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            lookUpEditCuahang_Ban.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler( GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);

            DisplayInfo();
        }

        #region Override Method
        public override void DisplayInfo()
        {
            try
            {
                lookUpEditCuahang_Ban.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().ToDataSet().Tables[0];
                lookUpEdit_Doituong.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet().Tables[0];
                lookUpEdit_Hanghoa_Ban.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet().Tables[0];
                lookUp_Loai_Hanghoa_Ban.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Ban().ToDataSet().Tables[0];

                dtNgay_Batdau.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                dtNgay_Ketthuc.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1);
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
#endif 
            }
        }

        public override bool PerformQuery()
        {
            try
            {
                switch (report)
                {
                    case "rptWare_Muahang_Congno_Tra":
                        Load_rptWare_Muahang_Congno_Tra();
                        break;

                    case "rptWare_Muahang_Congno_Chuatra":                        
                        Load_rptWare_Muahang_Congno_Chuatra();
                        break;

                    case "rptWare_Muahang_Xuattra_Chitiet":
                        Load_Rptware_Muahang_Xuattra_Chitiet();
                        break;

                    case "rptWare_Muahang_Chitiet":
                        LoadRptChitiet_Hangmua();
                        break;

                    case "rptWare_Muahang_Congno_Tonghop":
                        Load_Rptware_Muahang_Congno_Tonghop();
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

        #region Event
        private void navItem_Chitiet_Congno_Phaitra_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Loaddata();
        }

        private void navItem_Tonghop_Congno_Phaitra_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Muahang_Congno_Tonghop _rptWare_Muahang_Congno_Tonghop = new Ecm.Reports.XtraReports.rptWare_Muahang_Congno_Tonghop();
            this.report = "rptWare_Muahang_Congno_Tonghop";
            setHesoChuongtrinh(_rptWare_Muahang_Congno_Tonghop.xrc_CompanyName, _rptWare_Muahang_Congno_Tonghop.xrc_CompanyAddress, _rptWare_Muahang_Congno_Tonghop.xrPic_Logo);
            printControl_Baocao.PrintingSystem = _rptWare_Muahang_Congno_Tonghop.PrintingSystem;
            _rptWare_Muahang_Congno_Tonghop.CreateDocument();
            Loaddata();
        }

        private void navItem_Thongke_Noquahan_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Loaddata();
        }

        private void navItem_Chitiet_Tienmuahang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Muahang_Chitiet rptWare_Muahang = new Ecm.Reports.XtraReports.rptWare_Muahang_Chitiet();
            setHesoChuongtrinh(rptWare_Muahang.xrc_CompanyName, rptWare_Muahang.xrc_CompanyAddress, rptWare_Muahang.xrPic_Logo);
            printControl_Baocao.PrintingSystem = rptWare_Muahang.PrintingSystem;
            this.report = "rptWare_Muahang_Chitiet";
            rptWare_Muahang.CreateDocument();
            Loaddata();
        }

        private void navItem_Chitiet_Tienxuat_Trahang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            XtraReports.rptWare_Muahang_Xuattra_Chitiet _rptWare_Muahang_Xuattra_Chitiet = new Ecm.Reports.XtraReports.rptWare_Muahang_Xuattra_Chitiet();

            // Thiết lập hệ số chương trình (Logo, thông tin công ty)
            setHesoChuongtrinh(_rptWare_Muahang_Xuattra_Chitiet.xrc_CompanyName, _rptWare_Muahang_Xuattra_Chitiet.xrc_CompanyAddress, _rptWare_Muahang_Xuattra_Chitiet.xrPic_Logo);
          
            this.report = "rptWare_Muahang_Xuattra_Chitiet";
            printControl_Baocao.PrintingSystem = _rptWare_Muahang_Xuattra_Chitiet.PrintingSystem;
            _rptWare_Muahang_Xuattra_Chitiet.CreateDocument();
            Loaddata();
        }

        private void navItem_Chitiet_Tientra_Congno_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Muahang_Congno_Tra _rptWare_Muahang_Congno_Tra = new Ecm.Reports.XtraReports.rptWare_Muahang_Congno_Tra();

            // Thiết lập hệ số chương trình (Logo, thông tin công ty)
            setHesoChuongtrinh(_rptWare_Muahang_Congno_Tra.xrc_CompanyName, _rptWare_Muahang_Congno_Tra.xrc_CompanyAddress, _rptWare_Muahang_Congno_Tra.xrPic_Logo);

            printControl_Baocao.PrintingSystem = _rptWare_Muahang_Congno_Tra.PrintingSystem;
            this.report = "rptWare_Muahang_Congno_Tra";
            _rptWare_Muahang_Congno_Tra.CreateDocument();
            Loaddata();
        }

        private void navItem_Danhsach_Chungtu_Congno_Chuathu_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Reports.XtraReports.rptWare_Muahang_Congno_Chuatra _rptWare_Muahang_Congno_Chuatra = new Ecm.Reports.XtraReports.rptWare_Muahang_Congno_Chuatra();

            // Thiết lập hệ số chương trình (Logo, thông tin công ty)
            setHesoChuongtrinh(_rptWare_Muahang_Congno_Chuatra.xrc_CompanyName, _rptWare_Muahang_Congno_Chuatra.xrc_CompanyAddress, _rptWare_Muahang_Congno_Chuatra.xrPic_Logo);

            printControl_Baocao.PrintingSystem = _rptWare_Muahang_Congno_Chuatra.PrintingSystem;
            this.report = "rptWare_Muahang_Congno_Chuatra";
            _rptWare_Muahang_Congno_Chuatra.CreateDocument();
            Loaddata();
        }

        private void navItem_Chitiet_Congno_Theophieuxuat_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Loaddata();
        }

        private void navItem_Danhsach_Phieuxuat_Cohoahong_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Loaddata();
        }

        private void navItem_Tonghop_Hoahong_Cuakhach_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Loaddata();
        }

        private void lookUpEdit_Hanghoa_Ban_EditValueChanged(object sender, EventArgs e)
        {
            if ("" + lookUpEdit_Hanghoa_Ban != "")
            {
                txtMa_Hanghoa.EditValue = lookUpEdit_Hanghoa_Ban.GetColumnValue("Ma_Hanghoa_Ban");
            }
        }


        private void lookUpEdit_Doituong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                lookUpEdit_Doituong.EditValue = null;
            }
        }

        private void lookUpEdit_Hanghoa_Ban_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                lookUpEdit_Hanghoa_Ban.EditValue = null;
                txtMa_Hanghoa.EditValue = null;
            }
        }

        private void lookUp_Loai_Hanghoa_Ban_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                lookUp_Loai_Hanghoa_Ban.EditValue = null;
            }
        }
     

        #endregion

        #region Custom Method
        private void Load_Rptware_Muahang_Xuattra_Chitiet()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            hashtableControls.Add(lookUpEditCuahang_Ban, lblCuahang_Ban.Text);

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return;
            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return;

            XtraReports.rptWare_Muahang_Xuattra_Chitiet _rptWare_Muahang_Xuattra_Chitiet = new Ecm.Reports.XtraReports.rptWare_Muahang_Xuattra_Chitiet();
            // Thiết lập hệ số chương trình (Logo, thông tin công ty)
            setHesoChuongtrinh(_rptWare_Muahang_Xuattra_Chitiet.xrc_CompanyName, _rptWare_Muahang_Xuattra_Chitiet.xrc_CompanyAddress, _rptWare_Muahang_Xuattra_Chitiet.xrPic_Logo);      

            _rptWare_Muahang_Xuattra_Chitiet.Parameters["Kho"].Value = lookUpEditCuahang_Ban.Text;
            _rptWare_Muahang_Xuattra_Chitiet.Parameters["Tungay"].Value = dtNgay_Batdau.Text;
            _rptWare_Muahang_Xuattra_Chitiet.Parameters["Denngay"].Value = dtNgay_Ketthuc.Text;
            DataSet dsReport = objReportService.Rptware_Muahang_Xuattra_Chitiet(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue,lookUpEditCuahang_Ban.EditValue, lookUpEdit_Doituong.EditValue).ToDataSet();
            _rptWare_Muahang_Xuattra_Chitiet.DataSource = dsReport;
            GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            _FrmPrintPreview.Report = _rptWare_Muahang_Xuattra_Chitiet;
            _rptWare_Muahang_Xuattra_Chitiet.CreateDocument();
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_rptWare_Muahang_Xuattra_Chitiet);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                _FrmPrintPreview.printControl1.PrintingSystem = _rptWare_Muahang_Xuattra_Chitiet.PrintingSystem;
                _FrmPrintPreview.MdiParent = this.MdiParent;
                _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
            }
            else
            {
                var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_rptWare_Muahang_Xuattra_Chitiet);
                ReportPrintTool.Print();
            }
            _FrmPrintPreview.Show();
            _FrmPrintPreview.Activate();        
        }

        private void Load_rptWare_Muahang_Congno_Tra()
        {
            try
            {
                System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
                hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
                hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return;
                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                    return;

                DataSet ds_Congnotra = objWareService.Get_RptWare_Muahang_Congno_Tra(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue,lookUpEdit_Doituong.EditValue).ToDataSet();
                Ecm.Reports.XtraReports.rptWare_Muahang_Congno_Tra _rptWare_Muahang_Congno_Tra = new Ecm.Reports.XtraReports.rptWare_Muahang_Congno_Tra();

                // Thiết lập hệ số chương trình (Logo, thông tin công ty)
                setHesoChuongtrinh(_rptWare_Muahang_Congno_Tra.xrc_CompanyName, _rptWare_Muahang_Congno_Tra.xrc_CompanyAddress, _rptWare_Muahang_Congno_Tra.xrPic_Logo);

                _rptWare_Muahang_Congno_Tra.xrTable_tungay.Text = dtNgay_Batdau.DateTime.ToString("dd/MM/yyyy");
                _rptWare_Muahang_Congno_Tra.xrTable_Denngay.Text = dtNgay_Ketthuc.DateTime.ToString("dd/MM/yyyy");

                _rptWare_Muahang_Congno_Tra.xrTable_Ngay.Text = DateTime.Today.Day.ToString();
                _rptWare_Muahang_Congno_Tra.xrTable_Thang.Text = DateTime.Today.Month.ToString();
                _rptWare_Muahang_Congno_Tra.xrTable_Nam.Text = DateTime.Today.Year.ToString();

                _rptWare_Muahang_Congno_Tra.DataSource = ds_Congnotra;

                GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
                _FrmPrintPreview.Report = _rptWare_Muahang_Congno_Tra;
                _rptWare_Muahang_Congno_Tra.CreateDocument();
                GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_rptWare_Muahang_Congno_Tra);
                if (Convert.ToBoolean(oReportOptions.PrintPreview))
                {
                    _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                    _FrmPrintPreview.printControl1.PrintingSystem = _rptWare_Muahang_Congno_Tra.PrintingSystem;
                    _FrmPrintPreview.MdiParent = this.MdiParent;
                    _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
                }
                else
                {
                    var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_rptWare_Muahang_Congno_Tra);
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

        private void Load_rptWare_Muahang_Congno_Chuatra()
        {
            try
            {
                System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
                hashtableControls.Add(lookUpEdit_Doituong, lblDoituong.Text);

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return;
                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                    return;
                DataSet ds_Congno_Chuatra = objWareService.Get_RptWare_Muahang_Congno_Chuatra(lookUpEdit_Doituong.EditValue).ToDataSet();

                Ecm.Reports.XtraReports.rptWare_Muahang_Congno_Chuatra _rptWare_Muahang_Congno_Chuatra = new Ecm.Reports.XtraReports.rptWare_Muahang_Congno_Chuatra();

                //Thiết lập hệ số chương trình (Logo, thông tin công ty
                setHesoChuongtrinh(_rptWare_Muahang_Congno_Chuatra.xrc_CompanyName, _rptWare_Muahang_Congno_Chuatra.xrc_CompanyAddress, _rptWare_Muahang_Congno_Chuatra.xrPic_Logo);

                _rptWare_Muahang_Congno_Chuatra.xrTable_Denngay.Text = DateTime.Today.ToString("dd/MM/yyyy");
                _rptWare_Muahang_Congno_Chuatra.xrTable_Ngay.Text = DateTime.Today.Day.ToString();
                _rptWare_Muahang_Congno_Chuatra.xrTable_Thang.Text = DateTime.Today.Month.ToString();
                _rptWare_Muahang_Congno_Chuatra.xrTable_Nam.Text = DateTime.Today.Year.ToString();
                _rptWare_Muahang_Congno_Chuatra.xrTable_Nhacungcap.Text = lookUpEdit_Doituong.Text;
                
                _rptWare_Muahang_Congno_Chuatra.DataSource = ds_Congno_Chuatra;

                GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
                _FrmPrintPreview.Report = _rptWare_Muahang_Congno_Chuatra;
                _rptWare_Muahang_Congno_Chuatra.CreateDocument();
                GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_rptWare_Muahang_Congno_Chuatra);
                if (Convert.ToBoolean(oReportOptions.PrintPreview))
                {
                    _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                    _FrmPrintPreview.printControl1.PrintingSystem = _rptWare_Muahang_Congno_Chuatra.PrintingSystem;
                    _FrmPrintPreview.MdiParent = this.MdiParent;
                    _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
                }
                else
                {
                    var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_rptWare_Muahang_Congno_Chuatra);
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

        void LoadRptChitiet_Hangmua()
        {
            System.Collections.Hashtable hastTable = new System.Collections.Hashtable();
            hastTable.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hastTable.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            //hastTable.Add(lookUpEdit_Doituong, lblDoituong.Text);

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hastTable))
                return;
            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return;

            Reports.XtraReports.rptWare_Muahang_Chitiet rptWare_Muahang = new Ecm.Reports.XtraReports.rptWare_Muahang_Chitiet();
            Datasets.DsRptWare_Hdmuahang dsHdmuahang = new Ecm.Reports.Datasets.DsRptWare_Hdmuahang();
            DataSet dstemp = objWareService.Get_All_Ware_Hdmuahang_ByNhacungcap_ByDate(lookUpEdit_Doituong.EditValue,dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue).ToDataSet();
            int i = 1;
            foreach (DataRow dtr in dstemp.Tables[0].Rows)
            {
                DataRow dtrNew = dsHdmuahang.Tables[0].NewRow();
                foreach (DataColumn dtc in dstemp.Tables[0].Columns)
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
                dsHdmuahang.Tables[0].Rows.Add(dtrNew);
            }
            setHesoChuongtrinh(rptWare_Muahang.xrc_CompanyName, rptWare_Muahang.xrc_CompanyAddress, rptWare_Muahang.xrPic_Logo);
            rptWare_Muahang.xrDate_From.Text = dtNgay_Batdau.Text;
            rptWare_Muahang.xrDate_To.Text = dtNgay_Ketthuc.Text;
            rptWare_Muahang.xrNgayKy.Text = DateTime.Now.Day.ToString();
            rptWare_Muahang.xrThangKy.Text = DateTime.Now.Month.ToString();
            rptWare_Muahang.xrNamKy.Text = DateTime.Now.Year.ToString();
            rptWare_Muahang.DataSource = dsHdmuahang;

            GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            _FrmPrintPreview.Report = rptWare_Muahang;
            rptWare_Muahang.CreateDocument();
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(rptWare_Muahang);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                _FrmPrintPreview.printControl1.PrintingSystem = rptWare_Muahang.PrintingSystem;
                _FrmPrintPreview.MdiParent = this.MdiParent;
                _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
            }
            else
            {
                var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rptWare_Muahang);
                ReportPrintTool.Print();
            }
            _FrmPrintPreview.Show();
            _FrmPrintPreview.Activate();
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
                companyLogo.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }
        }

        private void Load_Rptware_Muahang_Congno_Tonghop()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            //hashtableControls.Add(lookUpEditCuahang_Ban, lblCuahang_Ban.Text);
            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return;
            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return;
            XtraReports.rptWare_Muahang_Congno_Tonghop _rptWare_Muahang_Congno_Tonghop = new Ecm.Reports.XtraReports.rptWare_Muahang_Congno_Tonghop();

            // Thiết lập hệ số chương trình (Logo, thông tin công ty)
            setHesoChuongtrinh(_rptWare_Muahang_Congno_Tonghop.xrc_CompanyName, _rptWare_Muahang_Congno_Tonghop.xrc_CompanyAddress, _rptWare_Muahang_Congno_Tonghop.xrPic_Logo);

            _rptWare_Muahang_Congno_Tonghop.Parameters["Tungay"].Value = dtNgay_Batdau.Text;
            _rptWare_Muahang_Congno_Tonghop.Parameters["Denngay"].Value = dtNgay_Ketthuc.Text;

            DataSet dsReport = objReportService.Rptware_Muahang_Congno_Tonghop(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEdit_Doituong.EditValue).ToDataSet();
            _rptWare_Muahang_Congno_Tonghop.DataSource = dsReport;

            GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            _FrmPrintPreview.Report = _rptWare_Muahang_Congno_Tonghop;
            _rptWare_Muahang_Congno_Tonghop.CreateDocument();
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_rptWare_Muahang_Congno_Tonghop);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                _FrmPrintPreview.Text = "" + oReportOptions.Caption;
                _FrmPrintPreview.printControl1.PrintingSystem = _rptWare_Muahang_Congno_Tonghop.PrintingSystem;
                _FrmPrintPreview.MdiParent = this.MdiParent;
                _FrmPrintPreview.Text = this.Text + "(Xem trang in)";
            }
            else
            {
                var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_rptWare_Muahang_Congno_Tonghop);
                ReportPrintTool.Print();
            }
            _FrmPrintPreview.Show();
            _FrmPrintPreview.Activate();
        }

        protected void Loaddata()
        {
            lookUpEditCuahang_Ban.EditValue = null;
            lookUpEdit_Doituong.EditValue = null;
            lookUpEdit_Hanghoa_Ban.EditValue = null;
            lookUp_Loai_Hanghoa_Ban.EditValue = null;

            dtNgay_Batdau.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtNgay_Ketthuc.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1);
        }


        #endregion

    }
}

