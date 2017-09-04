using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Ecm.Reports.XtraReports
{
    public partial class rptWare_Congno_Chitiet_bk : DevExpress.XtraReports.UI.XtraReport
    {
        public rptWare_Congno_Chitiet_bk()
        {
            InitializeComponent();
            Parameters["Ngay"].Value = DateTime.Today.ToString("dd");
            Parameters["Thang"].Value = DateTime.Today.ToString("MM");
            Parameters["Nam"].Value = DateTime.Today.ToString("yyyy");
        }
    }
}
