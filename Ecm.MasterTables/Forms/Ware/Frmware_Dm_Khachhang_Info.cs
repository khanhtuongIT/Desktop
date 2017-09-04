using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunLine.MasterTables.Forms.Ware
{
    public partial class Frmware_Dm_Khachhang_Info : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        MasterService.MasterService objMasterService = new SunLine.MasterTables.MasterService.MasterService();
        //MasterService.MasterService objMasterService = new SunLine.MasterTables.MasterService.MasterService();
        DataSet ds_Collection;
        DataSet dsKhachang;
        public Frmware_Dm_Khachhang_Info()
        {
            InitializeComponent();

            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Cancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            DisplayInfo();
        }

        /// <summary>
        /// clear editvalue
        /// </summary>
        void ClearControl()
        {
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

        public override void DisplayInfo()
        {
            //lookUpEditKhachhang
            dsKhachang = objMasterService.Get_All_Ware_Dm_Khachhang();
            lookUpEditKhachhang.Properties.DataSource = dsKhachang.Tables[0];

            //lookUpEditVip_Member
            lookUpEditVip_Member.Properties.DataSource = objMasterService.Get_All_Ware_Vip_Member().Tables[0];

            base.DisplayInfo();
        }

        public override bool PerformPrintPreview()
        {
            dgware_Hanghoa_Bangke_Chitiet.Text = lookUpEditKhachhang.Text;
            
            dgware_Hanghoa_Bangke_Chitiet.ShowPrintPreview();
            return base.PerformPrintPreview();
        }

        //private void txtMa_Khachhang_KeyDown(object sender, KeyEventArgs e)
        //{

        //    if (e.KeyData == Keys.Enter)
        //    {
        //        try
        //        {
        //            if (txtMa_Khachhang.Text != "")
        //            {
        //                lookUpEditKhachhang.EditValue =
        //                    dsKhachang.Tables[0].Select("Ma_Khachhang = '" + txtMa_Khachhang.EditValue + "'")[0]["Id_Khachhang"];
        //                txtNgaysinh.EditValue = lookUpEditKhachhang.GetColumnValue("Ngay_Sinh");
        //                txtDiachi_Khachhang.EditValue = lookUpEditKhachhang.GetColumnValue("Diachi_Khachhang");
        //                txtDienthoai.EditValue = lookUpEditKhachhang.GetColumnValue("Dienthoai");
        //                txtFax.EditValue = lookUpEditKhachhang.GetColumnValue("Fax");
        //                txtEmail.EditValue = lookUpEditKhachhang.GetColumnValue("Email");

        //                //get mark
        //                DataSet dsKhachhang_Quota = objMasterService.Get_All_Ware_Khachhang_Quota_Detail_By_Khachhang(lookUpEditKhachhang.EditValue);
        //                lookUpEditVip_Member.EditValue = dsKhachhang_Quota.Tables[0].Rows[0]["Id_Vip_Member"];
        //                dtNgay_Batdau.EditValue = dsKhachhang_Quota.Tables[0].Rows[0]["Ngay_Batdau"];
        //                dtNgay_Ketthuc.EditValue = dsKhachhang_Quota.Tables[0].Rows[0]["Ngay_Ketthuc"];
        //                dtNgay_Batdau_Vip.EditValue = dsKhachhang_Quota.Tables[0].Rows[0]["Ngay_Batdau_Vip"];
        //                dtNgay_Ketthuc_Vip.EditValue = dsKhachhang_Quota.Tables[0].Rows[0]["Ngay_Ketthuc_Vip"];
        //                txtMark.EditValue = dsKhachhang_Quota.Tables[0].Rows[0]["Mark"];

        //                //get doanh so
        //                DataSet dsRptWare_Hdbanhang_ByKhachhang = objMasterService.RptWare_Hdbanhang_ByKhachhang(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEditKhachhang.EditValue);
        //                dgware_Hanghoa_Bangke_Chitiet.DataSource = dsRptWare_Hdbanhang_ByKhachhang.Tables[0];
        //                bandedGridView1.BestFitColumns();
        //            }
        //        }
        //        catch (Exception ex) 
        //        {
        //            ClearControl();
        //        }
        //    }
        //}
    }
}