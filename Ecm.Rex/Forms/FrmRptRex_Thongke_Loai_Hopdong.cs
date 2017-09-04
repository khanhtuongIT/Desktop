using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using DevExpress.XtraEditors;
using Ecm.Rex.Datasets;


namespace Ecm.Rex.Forms
{
    /// <summary>
    /// Nhanvuong
    /// 11/9/2010
    /// Thong ke nhan su by Id_loai_Hopdong_Laodong
    /// </summary>
    
    public partial class FrmRptRex_Thongke_Loai_Hopdong : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview(); 
        
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Collection = new DataSet();

        public FrmRptRex_Thongke_Loai_Hopdong()
        {
            InitializeComponent();

            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Cancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            #region format datetime
            this.dtNgay_Batdau.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtNgay_Batdau.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();

            this.dtNgay_Ketthuc.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtNgay_Ketthuc.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();

            this.gridDate_Ngay.Mask.UseMaskAsDisplayFormat = true;
            this.gridDate_Ngay.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();

            dtNgay_Batdau.Properties.MinValue = new DateTime(1950, 01, 01);
            dtNgay_Ketthuc.Properties.MinValue = new DateTime(1950, 01, 01);

            #endregion

            DisplayInfo();
        }

        public override void DisplayInfo()
        {
            lookUpEdit_Bophan.Properties.DataSource = objMasterService.Get_All_Rex_Dm_Bophan_Collection().ToDataSet().Tables[0];
            lookUpEdit_Loai_Hopdong.Properties.DataSource = objMasterService.Get_All_Rex_Dm_Loai_Hopdong_Collection().ToDataSet().Tables[0];
            lookUpEdit_Loai_Hopdong.EditValue = null;
        }

        public override bool PerformQuery()
        {

            try
            {
                GoobizFrame.Windows.Public.OrderHashtable hashTable = new GoobizFrame.Windows.Public.OrderHashtable();
                hashTable.Add(dtNgay_Batdau, lbl_Ngaybatdau.Text);
                hashTable.Add(dtNgay_Ketthuc, lbl_Ngayketthuc.Text);
                hashTable.Add(lookUpEdit_Bophan, lblBophan.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashTable))
                    return false;

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                    return false;

                ds_Collection = objRexService.Get_Rex_Nhansu_Thongke_By_LoaiHD(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue,
                                                                    lookUpEdit_Bophan.EditValue, lookUpEdit_Loai_Hopdong.EditValue).ToDataSet();
                this.dgrex_Thongke_Loai_Hopdong.DataSource = ds_Collection.Tables[0];
                return true;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Lỗi: " + ex.Message);
                return false;
            }
        }

        public override bool PerformPrintPreview()
        {

            try
            {
                GoobizFrame.Windows.Public.OrderHashtable hashTable = new GoobizFrame.Windows.Public.OrderHashtable();
                hashTable.Add(dtNgay_Batdau, lbl_Ngaybatdau.Text);
                hashTable.Add(dtNgay_Ketthuc, lbl_Ngayketthuc.Text);
                hashTable.Add(lookUpEdit_Bophan, lblBophan.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashTable))
                    return false;

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                    return false;

                ds_Collection = objRexService.Get_Rex_Nhansu_Thongke_By_LoaiHD(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue,
                                                                  lookUpEdit_Bophan.EditValue, lookUpEdit_Loai_Hopdong.EditValue).ToDataSet();
                Datasets.dsRex_Thongke_Loai_Hopdong dsRex_Thongke_Loai_Hopdong = new dsRex_Thongke_Loai_Hopdong();

                foreach (DataRow dt in ds_Collection.Tables[0].Rows)
                {
                    dsRex_Thongke_Loai_Hopdong.Tables[0].ImportRow(dt);
                }

                int i = 1;
                string group = "";
                foreach (DataRow dt in dsRex_Thongke_Loai_Hopdong.Tables[0].Rows)
                {
                    if (group.Equals(dt["Id_Loai_Hopdong"].ToString()))
                    {
                        dt["Stt"] = i.ToString();
                        i++;
                    }
                    else
                    {
                        group = dt["Id_Loai_Hopdong"].ToString();
                        i = 1;
                        dt["Stt"] = i.ToString();
                        i++;
                    }
                }

                //khoi tao report thong ke phep nam
                Reports.rptRex_Thongke_Loai_Hopdong objrptRex_Thongke_Loai_Hopdong = new Ecm.Rex.Reports.rptRex_Thongke_Loai_Hopdong();
                if (frmPrintPreview == null || frmPrintPreview.IsDisposed) frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview(); 
                frmPrintPreview.Report = objrptRex_Thongke_Loai_Hopdong;
                objrptRex_Thongke_Loai_Hopdong.DataSource = dsRex_Thongke_Loai_Hopdong;

                objrptRex_Thongke_Loai_Hopdong.xrTable_BoPhan.Text = lookUpEdit_Bophan.Text;
                objrptRex_Thongke_Loai_Hopdong.xrTable_Tungay.Text = Convert.ToDateTime(dtNgay_Batdau.EditValue.ToString()).ToString("dd/MM/yyyy");
                objrptRex_Thongke_Loai_Hopdong.xrTable_Denngay.Text = Convert.ToDateTime(dtNgay_Ketthuc.EditValue.ToString()).ToString("dd/MM/yyyy");

                objrptRex_Thongke_Loai_Hopdong.xrTable_ngay.Text = DateTime.Now.Day.ToString();
                objrptRex_Thongke_Loai_Hopdong.xrTable_thang.Text = DateTime.Now.Month.ToString();
                objrptRex_Thongke_Loai_Hopdong.xrTable_nam.Text = DateTime.Now.Year.ToString();


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

                    objrptRex_Thongke_Loai_Hopdong.xrc_CompanyName.DataBindings.Add(
                        new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                    objrptRex_Thongke_Loai_Hopdong.xrc_CompanyAddress.DataBindings.Add(
                        new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                    //rptPhieu_Chi.xrPic_Logo.DataBindings.Add(
                    //    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
                }

                #endregion


                objrptRex_Thongke_Loai_Hopdong.CreateDocument();

                frmPrintPreview.printControl1.PrintingSystem = objrptRex_Thongke_Loai_Hopdong.PrintingSystem;
                frmPrintPreview.MdiParent = this.MdiParent;
                frmPrintPreview.Text = this.Text + "(Xem trang in)";
                frmPrintPreview.Show();
                return base.PerformPrintPreview();
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Lỗi: " + ex.Message);
                return false;
            }

        }

    }
}