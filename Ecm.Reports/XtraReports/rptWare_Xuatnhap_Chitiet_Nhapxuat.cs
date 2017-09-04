using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace Ecm.Reports.XtraReports
{
    public partial class rptWare_Xuatnhap_Chitiet_Nhapxuat : DevExpress.XtraReports.UI.XtraReport
    {
        public decimal soluong_xuat = 0;
        public decimal soluong_nhap = 0;
        decimal tongtien_no_ck = 0;
        decimal tongtien_co_ck = 0;

        public rptWare_Xuatnhap_Chitiet_Nhapxuat()
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
            e.Result = soluong_nhap;
            e.Handled = true;
        }

        private void xrTableCell9_SummaryReset(object sender, EventArgs e)
        {
            soluong_nhap = 0;
        }

        private void xrTableCell9_SummaryRowChanged(object sender, EventArgs e)
        {
            if ("" + GetCurrentColumnValue("Sochungtu") != "")
                soluong_nhap += Convert.ToDecimal("0" + GetCurrentColumnValue("soluong_nhap"));
        }

        private void xrTableCell27_SummaryReset(object sender, EventArgs e)
        {
            soluong_xuat = 0;
        }

        private void xrTableCell27_SummaryRowChanged(object sender, EventArgs e)
        {
            if ("" + GetCurrentColumnValue("Sochungtu") != "")
                soluong_xuat += Convert.ToDecimal("0" + GetCurrentColumnValue("soluong_xuat"));
        }

        private void xrTableCell27_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = soluong_xuat;
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

        private void xrTableCell_Ton_Cuoiky_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //try
            //{
            //    if (DataSource == null) return;
            //    DataSet dsCollection = (DataSet)DataSource;
            //    decimal nhap = Convert.ToDecimal(dsCollection.Tables[0].Compute("Sum(soluong_nhap)", ""));
            //    decimal xuat = Convert.ToDecimal(dsCollection.Tables[0].Compute("Sum(soluong_xuat)", ""));
            //    xrTableCell_Ton_Cuoiky.Text = (nhap - xuat).ToString();
            //    xrTableCell_Ton_Cuoiky.Text = string.Format("{0:#,##0.00}", Convert.ToDecimal(xrTableCell_Ton_Cuoiky.Text));
            //}
            //catch (Exception ex)
            //{
            //    ex.ToString();
            //}
        }

    }
}
