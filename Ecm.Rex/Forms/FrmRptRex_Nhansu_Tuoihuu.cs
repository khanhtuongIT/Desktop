using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using DevExpress.XtraEditors;
//using Ecm.WebReferences.MasterService;
using Ecm.WebReferences.Classes;

namespace Ecm.Rex.Forms
{
    public partial class FrmRptRex_Nhansu_Tuoihuu : GoobizFrame.Windows.Forms.FormXReport
    {
                Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        public DataSet ds_danhsach_nhansu;

        public FrmRptRex_Nhansu_Tuoihuu()
        {
            InitializeComponent();

            dtNgay_Batdau.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgay_Batdau.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();

            dtNgay_Ketthuc.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgay_Ketthuc.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();

            dtNgay_Batdau.Properties.MinValue = new DateTime(1950, 01, 01);
            dtNgay_Ketthuc.Properties.MinValue = new DateTime(1950, 01, 01);


            dtNgay_Batdau.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dtNgay_Ketthuc.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            lookUpEdit_Bophan.Properties.DataSource = objMasterService.Get_All_Rex_Dm_Bophan_Collection().ToDataSet().Tables[0];
        }

        public override bool PerformQuery()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lbl_Ngaybatdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lbl_Ngayketthuc.Text);
            hashtableControls.Add(lookUpEdit_Bophan, lblBophan.Text);

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return false;

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return false;

            Reports.rptRex_Nhansu_DSLLTN_4 _rptRex_Danhsach_Thuviec = new Reports.rptRex_Nhansu_DSLLTN_4();
            Report = _rptRex_Danhsach_Thuviec;
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

                _rptRex_Danhsach_Thuviec.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _rptRex_Danhsach_Thuviec.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                //rptPhieu_Chi.xrPic_Logo.DataBindings.Add(
                //    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }

            #endregion

            _rptRex_Danhsach_Thuviec.xrBophan.Text = lookUpEdit_Bophan.Text;
            string xrReport_Name = "DANH SÁCH NHÂN VIÊN ĐẾN TUỔI HƯU";
            _rptRex_Danhsach_Thuviec.FindControl("xrReport_Name", true).Text = xrReport_Name;
            _rptRex_Danhsach_Thuviec.FindControl("xrc_NgayBaocao", true).Text = string.Format("{0:dd/MM/yyyy}", dtNgay_Ketthuc.DateTime);

            ds_danhsach_nhansu = objRexService.Get_Rex_Nhansu_Dentuoihuu(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEdit_Bophan.EditValue).ToDataSet();

            _rptRex_Danhsach_Thuviec.DataSource = ds_danhsach_nhansu;

            _rptRex_Danhsach_Thuviec.CreateDocument();

            printControl1.PrintingSystem = _rptRex_Danhsach_Thuviec.PrintingSystem;

            return base.PerformQuery();
        }

    }
}