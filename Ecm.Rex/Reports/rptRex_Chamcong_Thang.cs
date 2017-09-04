using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Ecm.Rex.Reports
{
    public partial class rptRex_Chamcong_Thang : DevExpress.XtraReports.UI.XtraReport
    {
        int stt = -1;

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            stt++;
            xrcSTT.Text = stt.ToString();
        }

        public rptRex_Chamcong_Thang()
        {
            InitializeComponent();
        }

    }
}
