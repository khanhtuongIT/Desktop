using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Ecm.Rex.Reports
{
    public partial class RptRex_Luong_Tonghop_TkQuyluong : DevExpress.XtraReports.UI.XtraReport
    {
        public RptRex_Luong_Tonghop_TkQuyluong()
        {
            InitializeComponent();
        }

        private void ReportFooter_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                var xrTableCell_Tienbangchu = this.FindControl("xrTableCell_Tienbangchu", true);
                var sotien = ((System.Data.DataSet)this.DataSource).Tables[0].Compute("sum(Tong_Quyluong)", "");
                xrTableCell_Tienbangchu.Text = GoobizFrame.Windows.HelperClasses.ReadNumber.ChangeNum2VNStr(Convert.ToDouble(sotien),"VNĐ");
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(System.Windows.Forms.MessageBoxIcon.Asterisk,
                    ex.Message, ex.ToString());
            }
        }

    }
}
