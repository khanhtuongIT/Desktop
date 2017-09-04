using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Ecm.Rex.Reports
{
    public partial class RptRex_Luongtonghop_Phieuluong : DevExpress.XtraReports.UI.XtraReport
    {
        public RptRex_Luongtonghop_Phieuluong()
        {
            InitializeComponent();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void ReportFooter_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                var ds = this.DataSource as System.Data.DataSet;
                this.xrTableCell_Tienbangchu.Text = GoobizFrame.Windows.HelperClasses.ReadNumber.ChangeNum2VNStr(
                    Convert.ToDouble("0" + ds.Tables[0].Compute("sum(Thuclanh)", ""))
                    , " đồng"
                    );
                this.xrTableCell_NgayLap.Text = DateTime.Now.Day.ToString();
                this.xrTableCell_Thanglap.Text = DateTime.Now.Month.ToString();
                this.xrTableCell_Namlap.Text = DateTime.Now.Year.ToString();
                this.xrTableCell_Nguoilap.Text = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUserEntry("User_Fullname");
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(System.Windows.Forms.MessageBoxIcon.Asterisk,
                    ex.Message, ex.ToString());
            }
        }

    }
}
