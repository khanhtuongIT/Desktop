using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using DevExpress.XtraEditors;
using Ecm.WebReferences.Classes;
//using Ecm.WebReferences.MasterService;

namespace Ecm.Rex.Forms
{
    public partial class FrmRptRex_Nghiviec : GoobizFrame.Windows.Forms.FormXReport
    {
              
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();

        public FrmRptRex_Nghiviec()
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

            Rex.Reports.rptRex_Nghiviec _rptRex_Nghiviec = new Ecm.Rex.Reports.rptRex_Nghiviec();
            this.Report = _rptRex_Nghiviec;

            ReportHelper.SetCompanyInfoAtHeader(_rptRex_Nghiviec);
            _rptRex_Nghiviec.FindControl("xrc_Ngay_Batdau", true).Text = string.Format("{0:dd/MM/yyyy}", dtNgay_Batdau.DateTime);
            _rptRex_Nghiviec.FindControl("xrc_Ngay_Ketthuc", true).Text = string.Format("{0:dd/MM/yyyy}", dtNgay_Ketthuc.DateTime);


            var dsReport = objRexService.Get_Rex_Nghiviec_Report(lookUpEdit_Bophan.EditValue, dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue);
            
            _rptRex_Nghiviec.DataSource = dsReport;

            _rptRex_Nghiviec.CreateDocument();

            this.printControl1.PrintingSystem = _rptRex_Nghiviec.PrintingSystem;

            return base.PerformQuery();
        }
    }
}