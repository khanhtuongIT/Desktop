using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Ecm.Reports.XtraReports
{
    public partial class rptWare_Tonghop_Hoadon_Banhang_Thue : DevExpress.XtraReports.UI.XtraReport
    {
        public rptWare_Tonghop_Hoadon_Banhang_Thue()
        {
            InitializeComponent();

            Parameters["Ngay"].Value = DateTime.Today.ToString("dd");
            Parameters["Thang"].Value = DateTime.Today.ToString("MM");
            Parameters["Nam"].Value = DateTime.Today.ToString("yyyy");
        }
    }
}
