using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Rex.Forms
{
    public partial class FrmRptRex_Thongke_Phepnam : GoobizFrame.Windows.Forms.FormXReport
    {
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        Reports.rptRex_Thongke_Phepnam xreport = new Reports.rptRex_Thongke_Phepnam();
        DataSet dsThongke;

        public FrmRptRex_Thongke_Phepnam()
        {
            InitializeComponent();
            DisplayInfo();
        }

        void DisplayInfo()
        {
            lookUpEdit_Bophan.Properties.DataSource = objMasterService.Get_All_Rex_Dm_Bophan_Collection().ToDataSet().Tables[0];
            lookUpEdit_Loai_Nghiphep.Properties.DataSource = objMasterService.Get_All_Rex_Dm_Loai_Nghiphep_Collection().ToDataSet().Tables[0];
        }

        public override bool PerformQuery()
        {
            if (""+lookUpEdit_Loai_Nghiphep.EditValue == "")
                dsThongke = objRexService.Get_All_Rex_Nghiphep_By_Bophan_Nam(lookUpEdit_Bophan.EditValue, dtNgay_Ketthuc.DateTime.Year).ToDataSet();
            else
                dsThongke = objRexService.Get_All_Rex_Nghiphep_By_Bophan_Loai_Nam(lookUpEdit_Bophan.EditValue, dtNgay_Ketthuc.DateTime.Year, lookUpEdit_Loai_Nghiphep.EditValue).ToDataSet();

            this.Report = xreport;
            ReportHelper.SetCompanyInfoAtHeader(xreport);

            xreport.FindControl("xrc_NgayBaocao", true).Text = string.Format("{0:yyyy}", dtNgay_Ketthuc.DateTime);

            xreport.DataSource = dsThongke;
            xreport.CreateDocument();
            printControl1.PrintingSystem = xreport.PrintingSystem;

            return base.PerformQuery();
        }

        private void lookUpEdit_Loai_Nghiphep_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                lookUpEdit_Loai_Nghiphep.EditValue = null;

        }
    }
}
