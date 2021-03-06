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
    public partial class Frmware_So_Quytm : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        WebReferences.Classes.ReportService objReportServices = new Ecm.WebReferences.Classes.ReportService();
        WebReferences.WareService.Ware_So_Quytm objWare_So_Quytm;
        DataSet dsCollection;

        #region Initialize

        public Frmware_So_Quytm()
        {
            InitializeComponent();
            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Cancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_PrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            dtNgay_Batdau.Properties.MinValue = new DateTime(2000, 01, 01);
            dtNgay_Ketthuc.Properties.MinValue = new DateTime(2000, 01, 01);

            dtNgay_Batdau.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtNgay_Ketthuc.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1);
        }

        private void Frmware_So_Quytm_Load(object sender, EventArgs e)
        {
            this.DisplayInfo();
        }
        #endregion

        #region override

        public override void DisplayInfo()
        {
            try
            {
                DataTable dtb_soquy;

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

                if (objWareService.Get_Ware_So_Quytm_ByCount() == 0)
                {
                    Frmware_So_Quytm_Dauky _Frmware_So_Quytm_Dauky = new Frmware_So_Quytm_Dauky();
                    _Frmware_So_Quytm_Dauky.BarSystem.Visible = false;
                    _Frmware_So_Quytm_Dauky.ShowDialog();
                }
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
                if (lookUpEdit_Soquy.EditValue == null)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn Sổ quỹ, vui lòng chọn lại");
                    lookUpEdit_Soquy.Focus();
                    return false;
                }
                decimal sodu_dauky = 0;

                //string thang = Convert.ToDateTime(dtNgay_Batdau.EditValue).Month.ToString();
                //string nam = Convert.ToDateTime(dtNgay_Batdau.EditValue).Year.ToString();

                //Tháng kế tiếp của tháng lập báo cáo
                //DateTime next_month = Convert.ToDateTime(dtNgay_Ketthuc.EditValue).AddMonths(1);
                //string thang_toi = next_month.Month.ToString();
                //string nam_thang_toi = next_month.Year.ToString();

                //Lấy số dư đầu kỳ (số dư cuối kỳ tháng trứoc)
                //objWare_So_Quytm = objWareService.Get_Ware_So_Quytm_ByThang_Nam_IdSoquy(thang, nam, lookUpEdit_Soquy.EditValue);
                DataSet dsDauky = new DataSet();
                dsDauky = objReportServices.RptWare_SoQTM(new DateTime(2014, 11, 1), dtNgay_Batdau.DateTime.AddDays(-1), lookUpEdit_Soquy.EditValue).ToDataSet();
                decimal tongthu_dk = Convert.ToDecimal("0" + dsDauky.Tables[0].Compute("sum(Sotien_Thu)", "")); //Convert.ToDecimal("0" + gridView1.Columns["Sotien_Thu"].SummaryText);
                decimal tongchi_dk = Convert.ToDecimal("0" + dsDauky.Tables[0].Compute("sum(Sotien_Chi)", "")); // Convert.ToDecimal("0" + gridView1.Columns["Sotien_Chi"].SummaryText);
                sodu_dauky = tongthu_dk - tongchi_dk;
                //sodu_dauky = Convert.ToDecimal(objWare_So_Quytm.Sotien);
                txtSoquy_Quytm_Dauky.EditValue = sodu_dauky;

                //Report
                System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
                hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
                hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                dsCollection = objReportServices.RptWare_SoQTM(dtNgay_Batdau.DateTime, dtNgay_Ketthuc.DateTime, lookUpEdit_Soquy.EditValue).ToDataSet();
                dgware_So_Quytm.DataSource = dsCollection.Tables[0];
                gridView1.BestFitColumns();

                decimal tongthu = Convert.ToDecimal("0" + gridView1.Columns["Sotien_Thu"].SummaryText);
                decimal tongchi = Convert.ToDecimal("0" + gridView1.Columns["Sotien_Chi"].SummaryText);

                //Tính số dư cuối kỳ
                txtSoquy_Quytm_Cuoiky.EditValue = sodu_dauky + tongthu - tongchi;

                //objWare_So_Quytm = objWareService.Get_Ware_So_Quytm_ByThang_Nam_IdSoquy(thang, nam, lookUpEdit_Soquy.EditValue);
                //if ("" + lookUpEdit_Soquy.EditValue != "-1")
                //{
                //    //Thêm số dư cuối kỳ vào DB (dùng làm số dư đầu kỳ tháng tới)
                //    objWare_So_Quytm.Thang = thang_toi;
                //    objWare_So_Quytm.Nam = nam_thang_toi;
                //    objWare_So_Quytm.Sotien = sodu_cuoiky;
                //    objWare_So_Quytm.Id_Soquy = lookUpEdit_Soquy.EditValue;
                //    objWareService.Insert_Ware_So_Quytm(objWare_So_Quytm);
                //}
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
#endif
                return false;
            }
            return true;
        }

        public override bool PerformPrintPreview()
        {
            try
            {
                if (dsCollection == null)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Báo cáo chưa được lập, vui lòng lập báo cáo trước khi in.");
                    return false;
                }


                Reports.rptWare_So_Quytm _rptWare_So_Quytm = new Ecm.Ware.Reports.rptWare_So_Quytm();

                #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
                using (DataSet dsHeso_Chuongtrinh = (new WebReferences.Classes.MasterService()).Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
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

                    _rptWare_So_Quytm.xrc_CompanyName.DataBindings.Add(
                        new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                    _rptWare_So_Quytm.xrc_CompanyAddress.DataBindings.Add(
                        new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                    _rptWare_So_Quytm.xrPic_Logo.DataBindings.Add(
                        new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
                }
                #endregion

                _rptWare_So_Quytm.Parameters["Sodu_Dauky"].Value = txtSoquy_Quytm_Dauky.Text;
                _rptWare_So_Quytm.Parameters["Sodu_Cuoiky"].Value = txtSoquy_Quytm_Cuoiky.Text;
                _rptWare_So_Quytm.DataSource = dsCollection.Tables[0];

                GoobizFrame.Windows.Forms.FrmPrintPreview _FrmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
                _FrmPrintPreview.Report = _rptWare_So_Quytm;
                _FrmPrintPreview.ShowDialog();
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
#endif
            }
            return base.PerformPrintPreview();
        }
        #endregion
    }
}

