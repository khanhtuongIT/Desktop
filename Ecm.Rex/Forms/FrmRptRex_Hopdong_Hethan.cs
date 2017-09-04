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
    public partial class FrmRptRex_Hopdong_Hethan : GoobizFrame.Windows.Forms.FormXReport
    {
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();

        public FrmRptRex_Hopdong_Hethan()
        {
            InitializeComponent();

            dtNgay_Batdau.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgay_Batdau.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();

            dtNgay_Ketthuc.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgay_Ketthuc.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();


            dtNgay_Batdau.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dtNgay_Ketthuc.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            dtNgay_Batdau.Properties.MinValue = new DateTime(1950, 01, 01);
            dtNgay_Ketthuc.Properties.MinValue = new DateTime(1950, 01, 01);

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

            Reports.rptRex_Hopdong_Hethan _rptRex_Hopdong_Hethan = new Reports.rptRex_Hopdong_Hethan();
            Report = _rptRex_Hopdong_Hethan;

            ReportHelper.SetCompanyInfoAtHeader(_rptRex_Hopdong_Hethan);
            _rptRex_Hopdong_Hethan.FindControl("xrc_Ngay_Batdau", true).Text = string.Format("{0:dd/MM/yyyy}", dtNgay_Batdau.DateTime);
            _rptRex_Hopdong_Hethan.FindControl("xrc_Ngay_Ketthuc", true).Text = string.Format("{0:dd/MM/yyyy}", dtNgay_Ketthuc.DateTime);


            var dsReport = objRexService.Get_Rex_Nhansu_HethanHD(dtNgay_Batdau.DateTime, dtNgay_Ketthuc.DateTime, lookUpEdit_Bophan.EditValue);           
            _rptRex_Hopdong_Hethan.DataSource = dsReport;
            _rptRex_Hopdong_Hethan.CreateDocument();
            printControl1.PrintingSystem = _rptRex_Hopdong_Hethan.PrintingSystem;

            return base.PerformQuery();
        }
    }
}