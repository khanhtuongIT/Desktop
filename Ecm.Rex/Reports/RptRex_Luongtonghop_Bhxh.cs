using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Ecm.Rex.Reports
{
    public partial class RptRex_Luongtonghop_Bhxh : DevExpress.XtraReports.UI.XtraReport
    {
        public RptRex_Luongtonghop_Bhxh()
        {
            InitializeComponent();
        }

        private void ReportFooter_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var ds = this.DataSource as System.Data.DataSet;
            this.xrTableCell_Tienbangchu.Text = GoobizFrame.Windows.HelperClasses.ReadNumber.ChangeNum2VNStr(
                Convert.ToDouble("0" + ds.Tables[0].Compute("sum(Baohiem)", ""))
                , " đồng"
                );
        }

    }
}
