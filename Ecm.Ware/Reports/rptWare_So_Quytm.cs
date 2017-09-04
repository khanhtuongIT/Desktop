using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Ecm.Ware.Reports
{
    public partial class rptWare_So_Quytm : DevExpress.XtraReports.UI.XtraReport
    {
        public rptWare_So_Quytm()
        {
            InitializeComponent();

            Parameters["Ngay"].Value = DateTime.Today.ToString("dd");
            Parameters["Thang"].Value = DateTime.Today.ToString("MM");
            Parameters["Nam"].Value = DateTime.Today.ToString("yyyy");
        }

    }
}
