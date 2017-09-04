using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Ecm.Rex.Reports
{
    public partial class RptRex_Luongtonghop_ATM : DevExpress.XtraReports.UI.XtraReport
    {
        public RptRex_Luongtonghop_ATM()
        {
            InitializeComponent();
        }

        private void ReportFooter_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var ds = this.DataSource as System.Data.DataSet;
            this.xrTableCell_Tienbangchu.Text = GoobizFrame.Windows.HelperClasses.ReadNumber.ChangeNum2VNStr(
                Convert.ToDouble("0"+ds.Tables[0].Compute("sum(Thuclanh)", ""))
                , " đồng"
                );
            this.xrTableCell_NgayLap.Text = DateTime.Now.Day.ToString();
            this.xrTableCell_Thanglap.Text = DateTime.Now.Month.ToString();
            this.xrTableCell_Namlap.Text = DateTime.Now.Year.ToString();
            this.xrTableCell_Nguoilap.Text = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUserEntry("User_Fullname");

            if (Convert.ToInt32(ds.Tables[0].Compute("count(Taikhoan_Nganhang)", "")) == 0)
                this.xrTableCell_Kynhan.Text = "Ký nhận";
        }

    }
}
