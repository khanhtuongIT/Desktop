using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Ecm.Ware.Reports
{
    public partial class rptNhap_Vattu_Date : DevExpress.XtraReports.UI.XtraReport
    {
        public rptNhap_Vattu_Date()
        {
            InitializeComponent();
        }

        private void ReportFooter_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

    }
}
