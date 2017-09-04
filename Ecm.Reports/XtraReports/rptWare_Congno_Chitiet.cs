using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Ecm.Reports.XtraReports
{
    public partial class rptWare_Congno_Chitiet : DevExpress.XtraReports.UI.XtraReport
    {
        public decimal thanhtien_co = 0;
        public decimal thanhtien_no = 0;
        decimal tongtien_no_ck = 0;
        decimal tongtien_co_ck = 0;

        public rptWare_Congno_Chitiet()
        {
            InitializeComponent();
            //Parameters["Ngay"].Value = DateTime.Today.ToString("dd");
            //Parameters["Thang"].Value = DateTime.Today.ToString("MM");
            //Parameters["Nam"].Value = DateTime.Today.ToString("yyyy");
        }

        private void rptWare_Congno_Chitiet_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            FormattingRule rule = new FormattingRule();
            this.FormattingRuleSheet.Add(rule);

            rule.DataSource = this.DataSource;
            rule.DataMember = this.DataMember;
            rule.Condition = "[Sochungtu] is null";
            //rule.Formatting.BackColor = Color.WhiteSmoke;
            //rule.Formatting.ForeColor = Color.IndianRed;
            rule.Formatting.Font = new Font("Tahoma", 10, FontStyle.Bold);
            this.Detail.FormattingRules.Add(rule);

            //if (xrTable1.Rows.Count > 0 && "" + GetCurrentColumnValue("Diengiai") != "")
            //    this.Detail.Controls.RemoveAt(CurrentRowIndex);

           
        }

        private void xrTableCell9_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = thanhtien_no;
            e.Handled = true;
        }

        private void xrTableCell9_SummaryReset(object sender, EventArgs e)
        {
            thanhtien_no = 0;
        }

        private void xrTableCell9_SummaryRowChanged(object sender, EventArgs e)
        {
            if ("" + GetCurrentColumnValue("Sochungtu") != "")
                thanhtien_no += Convert.ToDecimal("0" + GetCurrentColumnValue("Sotien_No"));
        }

        private void xrTableCell27_SummaryReset(object sender, EventArgs e)
        {
            thanhtien_co = 0;
        }

        private void xrTableCell27_SummaryRowChanged(object sender, EventArgs e)
        {
            if ("" + GetCurrentColumnValue("Sochungtu") != "")
                thanhtien_co += Convert.ToDecimal("0" + GetCurrentColumnValue("Sotien_Co"));
        }

        private void xrTableCell27_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = thanhtien_co;
            e.Handled = true;
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                if (((System.Data.DataRowView)GetCurrentRow()).Row["Diengiai"].ToString() == "")
                    e.Cancel = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

    }
}
