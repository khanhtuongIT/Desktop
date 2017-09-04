using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Ecm.Ware.Reports
{
    public partial class rptNhap_Vattu : DevExpress.XtraReports.UI.XtraReport
    {
        public rptNhap_Vattu()
        {
            InitializeComponent();
        }

        private void ReportFooter_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

    }
}
