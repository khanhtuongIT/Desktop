using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace Ecm.Bar.Reports
{
    public partial class rptHdbanhang_Hotel : DevExpress.XtraReports.UI.XtraReport
    {
        public rptHdbanhang_Hotel()
        {
            InitializeComponent();
        }

        private void rptHdbanhang_Hotel_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //DataSet dsCollection = (DataSet)DataSource;
            //decimal tien_per_phong = 10000; 

            //if (dsCollection  != null)
            //{
            //    foreach (DataRow dtr in dsCollection.Tables[0].Rows)
            //    { 
            //        tien_per_phong += Convert.ToDecimal(dtr["Thanhtien"]);
            //    }                
            //}
            //xrTableCeTienPerPhong.Text = tien_per_phong.ToString();
        }

    }
}
