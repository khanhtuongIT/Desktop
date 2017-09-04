using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Ecm.Reports.XtraReports
{
    public partial class rptWare_Muahang_Xuattra_Chitiet : DevExpress.XtraReports.UI.XtraReport
    {
        public rptWare_Muahang_Xuattra_Chitiet()
        {
            InitializeComponent();

            Parameters["Ngay"].Value = DateTime.Today.ToString("dd");
            Parameters["Thang"].Value = DateTime.Today.ToString("MM");
            Parameters["Nam"].Value = DateTime.Today.ToString("yyyy");
        }
    }
}
