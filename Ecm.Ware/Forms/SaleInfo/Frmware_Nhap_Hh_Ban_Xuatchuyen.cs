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
    public partial class Frmware_Nhap_Hh_Ban_Xuatchuyen : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        DataSet ds_Nhap_Hh_Ban_Chitiet = new DataSet();
        object id_nhansu_current;
        object id_kho;
        public DataRow[] _selectedRows;

        public Frmware_Nhap_Hh_Ban_Xuatchuyen(object Id_Kho)
        {
            InitializeComponent();
            this.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Cancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Query.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_PrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            id_nhansu_current = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu();
            id_kho = Id_Kho;
            this.DisplayInfo();
        }

        void Reload_Hanghoa()
        {
            try
            {
                DateTime ngay_hientai = DateTime.Now;
                ds_Nhap_Hh_Ban_Chitiet = objWareService.Rptware_Nxt_Hhban(new DateTime(ngay_hientai.Year, ngay_hientai.Month, ngay_hientai.Day, 0, 0, 0)
                                                        , new DateTime(ngay_hientai.Year, ngay_hientai.Month, ngay_hientai.Day, 23, 59, 59), id_kho, null, null).ToDataSet();

                //this.ds_Nhap_Hh_Ban_Chitiet = objWareService.Ware_Nhap_Hh_Ban_Chitiet_SelectAll_DateHang(id_kho).ToDataSet();
                ds_Nhap_Hh_Ban_Chitiet.Tables[0].Columns.Add("Chon", typeof(bool));
                this.dgware_Nhap_Hh_Ban_Chitiet.DataSource = ds_Nhap_Hh_Ban_Chitiet;
                this.dgware_Nhap_Hh_Ban_Chitiet.DataMember = ds_Nhap_Hh_Ban_Chitiet.Tables[0].TableName;
                gvware_Nhap_Hh_Ban_Chitiet.BestFitColumns();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }

        public override void DisplayInfo()
        {
            Reload_Hanghoa();
        }

        public override bool PerformPrintPreview()
        {
            try
            {
                DataSets.DsNhap_Vattu dsWare_Nhap_Vattu = new Ecm.Ware.DataSets.DsNhap_Vattu();
                Reports.rptNhap_Vattu_Date rptNhap_Vattu = new Reports.rptNhap_Vattu_Date();
                GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
                frmPrintPreview.Report = rptNhap_Vattu;
                rptNhap_Vattu.DataSource = dsWare_Nhap_Vattu;
                //Ware_Nhap_Vattu
                //DataRow rWare_Nhap_Vattu = dsWare_Nhap_Vattu.Tables["ware_nhap_hh_mua"].NewRow();
                //dsWare_Nhap_Vattu.Tables["ware_nhap_hh_mua"].Rows.Add(rWare_Nhap_Vattu);
                //Ware_Nhap_Vattu_Chitiet
                for (int i = 0; i < gvware_Nhap_Hh_Ban_Chitiet.RowCount; i++)
                {
                    DataRow rWare_Nhap_Chitiet = dsWare_Nhap_Vattu.Tables["ware_nhap_hh_mua_chitiet"].NewRow();
                    //rWare_Nhap_Vattu_Chitiet["id_nhap_hh_mua_chitiet"] = i + 1;
                    rWare_Nhap_Chitiet["Stt"] = i + 1;
                    rWare_Nhap_Chitiet["Ten_Hanghoa_Ban"] = gvware_Nhap_Hh_Ban_Chitiet.GetRowCellValue(i, "Ten_Hanghoa_Ban");
                    rWare_Nhap_Chitiet["Date_Nhap"] = gvware_Nhap_Hh_Ban_Chitiet.GetRowCellValue(i, "Date_Nhap");
                    rWare_Nhap_Chitiet["Date_Xuat"] = gvware_Nhap_Hh_Ban_Chitiet.GetRowCellValue(i, "Date_Xuat");
                    rWare_Nhap_Chitiet["Soluong"] = gvware_Nhap_Hh_Ban_Chitiet.GetRowCellValue(i, "Soluong");
                    rWare_Nhap_Chitiet["NgayDa_Sudung"] = gvware_Nhap_Hh_Ban_Chitiet.GetRowCellValue(i, "NgayDa_Sudung");
                    rWare_Nhap_Chitiet["Han_Sd"] = gvware_Nhap_Hh_Ban_Chitiet.GetRowCellValue(i, "Han_Sd");
                    rWare_Nhap_Chitiet["Conlai"] = gvware_Nhap_Hh_Ban_Chitiet.GetRowCellValue(i, "Conlai");
                    dsWare_Nhap_Vattu.Tables["ware_nhap_hh_mua_chitiet"].Rows.Add(rWare_Nhap_Chitiet);
                }
                dsWare_Nhap_Vattu.AcceptChanges();
                rptNhap_Vattu.xrNgay_Chungtu.Text = String.Format("{0:dd/MM/yyyy }", objWareService.GetServerDateTime()); 
                #region Set he so ctrinh - logo, ten cty

                Ecm.WebReferences.Classes.MasterService objMasterService = new WebReferences.Classes.MasterService();
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
                    rptNhap_Vattu.xrc_CompanyName.DataBindings.Add(
                        new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                    rptNhap_Vattu.xrc_CompanyAddress.DataBindings.Add(
                        new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                }

                #endregion
                rptNhap_Vattu.CreateDocument();
                GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(rptNhap_Vattu);
                if (Convert.ToBoolean(oReportOptions.PrintPreview))
                {
                    //frmPrintPreview.Text = "In Phiếu Nhập kho";  // "" + oReportOptions.Caption;
                    frmPrintPreview.printControl1.PrintingSystem = rptNhap_Vattu.PrintingSystem;
                    frmPrintPreview.MdiParent = this.MdiParent;
                    frmPrintPreview.Show();
                    frmPrintPreview.Activate();
                }
                else
                {
                    var reportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rptNhap_Vattu);
                    reportPrintTool.Print();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override object PerformSelectOneObject()
        {
            DoClickEndEdit(dgware_Nhap_Hh_Ban_Chitiet);
            if (MdiParent != null) return null;
            try
            {
                if (ds_Nhap_Hh_Ban_Chitiet == null || ds_Nhap_Hh_Ban_Chitiet.Tables.Count == 0) return false;

                _selectedRows = ds_Nhap_Hh_Ban_Chitiet.Tables[0].Select("Chon=true");
                if (_selectedRows == null || _selectedRows.Length == 0)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] { "Tên hàng" });
                    return false;
                }
                Dispose();
                return _selectedRows;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("Msg00130", new string[] { ex.Message });
            }
            return base.PerformSelectOneObject();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            Reload_Hanghoa();
        }
      
    }
}

