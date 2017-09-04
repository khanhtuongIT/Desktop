using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace Ecm.Bar.Reports
{
    public partial class rptHdbanhang_VAT : DevExpress.XtraReports.UI.XtraReport
    {
        public rptHdbanhang_VAT()
        {
            InitializeComponent();
        }

        private void xrTableCell77_TextChanged(object sender, EventArgs e)
        {
            if(xrTable4.Rows.LastRow.Cells[5].Text != "")
                xrTableRow22.Visible = true;
            else
                xrTableRow22.Visible = false;
        }

    }
}
