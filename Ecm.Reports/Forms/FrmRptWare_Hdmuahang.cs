using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunLine.Reports.Forms
{
    public partial class FrmRptWare_Hdmuahang : GoobizFrame.Windows.Forms.FormReportWithHeader
    {
        SunLine.WebReferences.Classes.WareService objWareService = new SunLine.WebReferences.Classes.WareService();
        SunLine.WebReferences.Classes.ReportService objReportServices = new SunLine.WebReferences.Classes.ReportService();


        public FrmRptWare_Hdmuahang()
        {
            InitializeComponent();
            DisplayInfo();

            dtNgay_Batdau.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 5, 0, 0);
            dtNgay_Ketthuc.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

        }

        void DisplayInfo()
        {
            //lookUpEditCuahang_Ban.Properties.DataSource = objWareService.Get_All_Ware_Dm_Cuahang_Ban().Tables[0];
        }

        public override bool PerformQuery()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            //hashtableControls.Add(lookUpEditCuahang_Ban, lblCuahang_Ban.Text);

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return false;

            XtraReports.RptWare_Muahang_Chitiet RptWare_Hdmuahang = new SunLine.Reports.XtraReports.RptWare_Muahang_Chitiet();
            this.Report = RptWare_Hdmuahang;
            DataSet ds_Collection = objReportServices.RptWare_Hdmuahang(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue);
            Datasets.DsRptWare_Hdmuahang DsRpt = new SunLine.Reports.Datasets.DsRptWare_Hdmuahang();
            try
            {
                foreach (DataRow row in ds_Collection.Tables[0].Rows)
                    DsRpt.Tables[0].ImportRow(row);
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
            RptWare_Hdmuahang.DataSource = DsRpt;
            RptWare_Hdmuahang.CreateDocument();

            this.printControl1.PrintingSystem = RptWare_Hdmuahang.PrintingSystem;

            return base.PerformQuery();
        }
    }
}

