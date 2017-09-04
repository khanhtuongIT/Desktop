using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Ecm.Rex.Reports
{
    public partial class rptRex_Tamhoan_Hopdong : DevExpress.XtraReports.UI.XtraReport
    {
        private object id_bophan;
        private object ten_bophan;
        private object ngay_batdau;
        private object ngay_ketthuc;

        public object Id_Bophan
        {
            get
            {
                return id_bophan;
            }
            set
            {
                if (id_bophan == value)
                    return;
                id_bophan = value;
            }
        }
        public object Ten_Bophan
        {
            get
            {
                return ten_bophan;
            }
            set
            {
                if (ten_bophan == value)
                    return;
                ten_bophan = value;
            }
        }
        public object Ngay_Batdau
        {
            get
            {
                return ngay_batdau;
            }
            set
            {
                if (ngay_batdau == value)
                    return;
                ngay_batdau = value;
            }
        }
        public object Ngay_Ketthuc
        {
            get
            {
                return ngay_ketthuc;
            }
            set
            {
                if (ngay_ketthuc == value)
                    return;
                ngay_ketthuc = value;
            }
        }

        public rptRex_Tamhoan_Hopdong()
        {
            InitializeComponent();
        }

    }
}
