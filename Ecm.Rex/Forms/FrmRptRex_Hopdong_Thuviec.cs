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
    public partial class FrmRptRex_Hopdong_Thuviec : GoobizFrame.Windows.Forms.FormXReport
    {
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        public DataSet ds_danhsach_nhansu;

        public FrmRptRex_Hopdong_Thuviec()
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

            Rex.Reports.rptRex_Nhansu_DSLLTN_4 _rptRex_Danhsach_Thuviec = new Ecm.Rex.Reports.rptRex_Nhansu_DSLLTN_4();
            this.Report = _rptRex_Danhsach_Thuviec;
            _rptRex_Danhsach_Thuviec.xrBophan.Text = lookUpEdit_Bophan.Text;
            _rptRex_Danhsach_Thuviec.FindControl("xrReport_Name",true).Text = "DANH SÁCH NHÂN VIÊN THỬ VIỆC";
            _rptRex_Danhsach_Thuviec.FindControl("xrc_NgayBaocao", true).Text = string.Format("{0:dd/MM/yyyy}", dtNgay_Ketthuc.DateTime);


            //_rptRex_Danhsach_Thuviec.lblNgay.Text = DateTime.Today.ToString("dd");
            //_rptRex_Danhsach_Thuviec.lblThang.Text = DateTime.Today.ToString("MM");
            //_rptRex_Danhsach_Thuviec.lblNam.Text = DateTime.Today.ToString("yyyy");

            ds_danhsach_nhansu = objRexService.Get_Rex_Nhansu_Thuviec(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEdit_Bophan.EditValue).ToDataSet();

            _rptRex_Danhsach_Thuviec.DataSource = ds_danhsach_nhansu;

            _rptRex_Danhsach_Thuviec.CreateDocument();

            printControl1.PrintingSystem = _rptRex_Danhsach_Thuviec.PrintingSystem;

            return base.PerformQuery();
        }
    }
}