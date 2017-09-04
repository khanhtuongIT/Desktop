using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DevExpress.XtraVerticalGrid;
using System.IO;
using DevExpress.XtraPivotGrid;

namespace Ecm.Ware.Reports
{
    public partial class rptKehoach_Banhang : DevExpress.XtraReports.UI.XtraReport
    {
        public bool bc_Banhang = false;

        public rptKehoach_Banhang()
        {
            InitializeComponent();
        }

        void xrPivotGrid1_FieldValueDisplayText(object sender, DevExpress.XtraReports.UI.PivotGrid.PivotFieldDisplayTextEventArgs e)
        {
            if (e.DisplayText == "Grand Total")
                e.DisplayText = "CUSTOM";
        }

        private void rptKehoach_Banhang_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DataSource == null) return;
            DataSet dsTemp = (DataSet)this.DataSource;
            int max_width = xrPivotGrid1.Width;

            DataTable distinctTable = dsTemp.Tables[0].DefaultView.ToTable("DistinctTable", true, "Ten_Hanghoa_Ban");
            int width_row = (max_width - 100) / (distinctTable.Rows.Count + 3);
            fieldTenHanghoaBan1.Width = width_row;
            xrPivotGrid1.FieldValueDisplayText += xrPivotGrid1_FieldValueDisplayText;
        }

        private void xrPivotGrid1_FieldValueDisplayText_1(object sender, DevExpress.XtraReports.UI.PivotGrid.PivotFieldDisplayTextEventArgs e)
        {
            if (e.DisplayText == "Grand Total")
                e.DisplayText = "CUSTOM";
        }

    }
}
