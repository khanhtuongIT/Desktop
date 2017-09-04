using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Ecm.Reports.XtraReports
{
    public partial class rptWare_Xuatnhap_Kiemke_Khohang : DevExpress.XtraReports.UI.XtraReport
    {
        public rptWare_Xuatnhap_Kiemke_Khohang()
        {
            InitializeComponent();

            this.Parameters["Ngay"].Value = DateTime.Today.ToString("dd");
            this.Parameters["Thang"].Value = DateTime.Today.ToString("MM");
            this.Parameters["Nam"].Value = DateTime.Today.ToString("yyyy");
            this.Parameters["Ngaylap"].Value = DateTime.Today.ToString("dd/MM/yyyy");
        }

    }
}
