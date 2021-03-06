using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Dm_Khachhang_Info :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        DataSet ds_Collection;
        DataSet dsKhachang;
        private string ma_khachhang;
        public string Ma_Khachhang
        {
            set
            {
                ma_khachhang = value;
                txtMa_Khachhang.Text = ma_khachhang;
                GeInfo_KhachHang();
                gKeyboard1.Visible = false;
            }
        }
        public Frmware_Dm_Khachhang_Info()
        {
            InitializeComponent();
            DevExpress.Skins.SkinManager.DisableFormSkins();
            DisplayInfo();
            xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            this.ShowTabpage(xtraTabControl1, xtraTabPage1);
            this.ShowTabpage(xtraTabControl2, xtraTabPage3);
            this.btnSearch.Enabled = false;
            this.ChangeStatus(false);
            BarSystem.Visible = false;

        }

        public void ShowTabpage(DevExpress.XtraTab.XtraTabControl xTabControl, DevExpress.XtraTab.XtraTabPage xTabpage)
        {
            if (xTabControl.TabPages.Count > 0)
                xTabControl.TabPages.Clear();
            xTabControl.TabPages.Add(xTabpage);
        }

        /// <summary>
        /// clear editvalue
        /// </summary>
        void ClearControl()
        {
            txtMa_Khachhang.EditValue = null;
            lookUpEditKhachhang.EditValue = null;
            txtNgaysinh.EditValue = null;
            txtDiachi_Khachhang.EditValue = null;
            txtDienthoai.EditValue = null;
            txtFax.EditValue = null;
            txtEmail.EditValue = null;

            lookUpEditVip_Member.EditValue = null;
            dtNgay_Batdau.EditValue = null;
            dtNgay_Ketthuc.EditValue = null;
            dtNgay_Batdau_Vip.EditValue = null;
            dtNgay_Ketthuc_Vip.EditValue = null;
            txtMark.EditValue = null;

            dgware_Hanghoa_Bangke_Chitiet.DataSource = null;
        }

        public void GeInfo_KhachHang()
        {
            try
            {
                this.lblStatus_Bar.Text = "";
                if (txtMa_Khachhang.Text != "")
                {
                    DataRow[] dr = dsKhachang.Tables[0].Select("Ma_Khachhang = '" + txtMa_Khachhang.EditValue + "'");
                    if (dr.Length == 0)
                    {
                        this.ChangeStatus(false);
                        this.lblStatus_Bar.Text = "Mã khách hàng không tồn tại. Vui lòng nhập lại";
                        txtMa_Khachhang.EditValue = null;
                        txtMa_Khachhang.Focus();
                        return;
                    }
                    btnSearch.Text = "Xóa hết";
                    this.ChangeStatus(true);
                    lookUpEditKhachhang.EditValue = dr[0]["Id_Khachhang"];
                    txtNgaysinh.EditValue =  GoobizFrame.Windows.MdiUtils.DateTimeMask.YMDToShortDatePattern("" + lookUpEditKhachhang.GetColumnValue("Ngay_Sinh"),
                         GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat());
                    txtDiachi_Khachhang.EditValue = lookUpEditKhachhang.GetColumnValue("Diachi_Khachhang");
                    txtDienthoai.EditValue = lookUpEditKhachhang.GetColumnValue("Dienthoai");
                    txtFax.EditValue = lookUpEditKhachhang.GetColumnValue("Fax");
                    txtEmail.EditValue = lookUpEditKhachhang.GetColumnValue("Email");

                    //get mark
                    //DataSet dsKhachhang_Quota = objWareService.Get_All_Ware_Khachhang_Quota_Detail_By_Khachhang(lookUpEditKhachhang.EditValue).ToDataSet();
                    //if (dsKhachhang_Quota.Tables[0].Rows.Count != 0)
                    //{
                    //    lookUpEditVip_Member.EditValue = dsKhachhang_Quota.Tables[0].Rows[0]["Id_Vip_Member"];
                    //    dtNgay_Batdau.EditValue = dsKhachhang_Quota.Tables[0].Rows[0]["Ngay_Batdau"];
                    //    dtNgay_Ketthuc.EditValue = dsKhachhang_Quota.Tables[0].Rows[0]["Ngay_Ketthuc"];
                    //    dtNgay_Batdau_Vip.EditValue = dsKhachhang_Quota.Tables[0].Rows[0]["Ngay_Batdau_Vip"];
                    //    dtNgay_Ketthuc_Vip.EditValue = dsKhachhang_Quota.Tables[0].Rows[0]["Ngay_Ketthuc_Vip"];
                    //    txtMark.EditValue = dsKhachhang_Quota.Tables[0].Rows[0]["Mark"];
                    //}
                    //else
                    //{
                    //    lookUpEditVip_Member.EditValue = null;
                    //    dtNgay_Batdau.EditValue = null;
                    //    dtNgay_Ketthuc.EditValue = null;
                    //    dtNgay_Batdau_Vip.EditValue = null;
                    //    dtNgay_Ketthuc_Vip.EditValue = null;
                    //    txtMark.EditValue = null;
                    //}
                    //get doanh so
                    DataSet dsRptWare_Hdbanhang_ByKhachhang = objWareService.RptWare_Hdbanhang_ByKhachhang(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEditKhachhang.EditValue).ToDataSet();
                    dgware_Hanghoa_Bangke_Chitiet.DataSource = dsRptWare_Hdbanhang_ByKhachhang.Tables[0];
                    this.lblNgayhientai.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Today);

                    bandedGridView1.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                //ClearControl();                
            }
        }

        #region  Override

        public void ChangeStatus(bool editable)
        {
            txtMa_Khachhang.Properties.ReadOnly = editable;
            btnView.Enabled = editable;
            btnView_Doanhso.Enabled = editable;
        }

        public override void DisplayInfo()
        {
            //lookUpEditKhachhang
            dsKhachang = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
            lookUpEditKhachhang.Properties.DataSource = dsKhachang.Tables[0];

            //lookUpEditVip_Member
            //lookUpEditVip_Member.Properties.DataSource = objWareService.Get_All_Ware_Vip_Member().ToDataSet().Tables[0];
            base.DisplayInfo();

        }

        public override bool PerformPrintPreview()
        {
            dgware_Hanghoa_Bangke_Chitiet.Text = lookUpEditKhachhang.Text;

            dgware_Hanghoa_Bangke_Chitiet.ShowPrintPreview();
            return base.PerformPrintPreview();
        }
        #endregion

        #region  Even

        private void txtMa_Khachhang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                GeInfo_KhachHang();
            }
        }

        private void gKeyboard1_UserKeyPressed(object sender,  GoobizFrame.Windows.Controls.TouchscreenKeyboard.KeyboardEventArgs e)
        {
            SendKeys.Send(e.KeyboardKeyPressed);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            Reports.rptWare_Dm_Khachhang_Info objrptWare_Dm_Khachhang_Info = new Ecm.Ware.Reports.rptWare_Dm_Khachhang_Info();
             GoobizFrame.Windows.Forms.FormReportWithHeader objReport = new  GoobizFrame.Windows.Forms.FormReportWithHeader();
            objReport.Report = objrptWare_Dm_Khachhang_Info;

            objrptWare_Dm_Khachhang_Info.tbc_Hoten.Text = lookUpEditKhachhang.Text;
            objrptWare_Dm_Khachhang_Info.tbcSodienthoai.Text = txtDienthoai.Text;
            objrptWare_Dm_Khachhang_Info.lblMathe.Text = txtMa_Khachhang.Text;
            objrptWare_Dm_Khachhang_Info.tbcDiem.Text = string.Format("{0:dd/MM/yyyy}", lblNgayhientai.Text);
            objrptWare_Dm_Khachhang_Info.tbcDiemTC.Text = txtMark.Text;
            objrptWare_Dm_Khachhang_Info.tbcNgayin.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Today);

            #region Set he so ctrinh - logo, ten cty

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
                    ,imageData
                });

                objrptWare_Dm_Khachhang_Info.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                objrptWare_Dm_Khachhang_Info.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                objrptWare_Dm_Khachhang_Info.xrPic_Logo.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }

            #endregion

            objrptWare_Dm_Khachhang_Info.CreateDocument();

            objReport.printControl1.PrintingSystem = objrptWare_Dm_Khachhang_Info.PrintingSystem;
            objReport.MdiParent = this.MdiParent;
            objReport.Text = this.Text + "(Xem trang in)";
            objReport.Show();
            objReport.Activate();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            this.ShowTabpage(xtraTabControl2, xtraTabPage3);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (btnSearch.Text.Equals("Tìm"))
            {
                this.GeInfo_KhachHang();
            }
            else
            {
                btnSearch.Text = "Tìm";
                this.ShowTabpage(xtraTabControl2, xtraTabPage3);

                this.ClearControl();
                txtMa_Khachhang.Focus();
                this.ChangeStatus(false);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            this.ShowTabpage(xtraTabControl2, xtraTabPage4);
        }

        private void btnView_Doanhso_Click(object sender, EventArgs e)
        {
            this.ShowTabpage(xtraTabControl1, xtraTabPage2);
            bandedGridView1.BestFitColumns();


        }

        private void btnClose1_Click(object sender, EventArgs e)
        {
            this.ShowTabpage(xtraTabControl1, xtraTabPage1);
            this.ShowTabpage(xtraTabControl2, xtraTabPage3);
        }

        private void txtMa_Khachhang_EditValueChanged(object sender, EventArgs e)
        {
            if (txtMa_Khachhang.Text == "")
                this.btnSearch.Enabled = false;
            else
                this.btnSearch.Enabled = true;
        }

        private void Frmware_Dm_Khachhang_Info_Load(object sender, EventArgs e)
        {
            txtMa_Khachhang.Focus();
        }

        private void btnCloseAll_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        #endregion

    }
}