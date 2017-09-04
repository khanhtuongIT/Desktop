using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Ecm.Reports.XtraReports
{
    public partial class rptWare_Xuatnhap_Thekho : DevExpress.XtraReports.UI.XtraReport
    {
        public rptWare_Xuatnhap_Thekho()
        {
            InitializeComponent();

            this.Parameters["Ngay"].Value = DateTime.Today.ToString("dd");
            this.Parameters["Thang"].Value = DateTime.Today.ToString("MM");
            this.Parameters["Nam"].Value = DateTime.Today.ToString("yyyy");
        }

    }
}
