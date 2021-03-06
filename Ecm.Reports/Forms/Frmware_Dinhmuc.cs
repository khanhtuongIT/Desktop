using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;

namespace Ecm.Reports.Forms
{
    public partial class Frmware_Dinhmuc : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        Ecm.WebReferences.Classes.ReportService objReportServices = new Ecm.WebReferences.Classes.ReportService();

        public Frmware_Dinhmuc()
        {
            InitializeComponent();
            dtNgay_Batdau.Properties.MinValue = new DateTime(2000, 01, 01);
            dtNgay_Ketthuc.Properties.MinValue = new DateTime(2000, 01, 01);
            dtNgay_Batdau.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtNgay_Ketthuc.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1);
            barSystem.Visible = false;
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            this.Dispose();   
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            dgware_Dinhmuc.DataSource = objMasterService.Ware_Dinhmuc_ByDate(dtNgay_Batdau.DateTime, dtNgay_Ketthuc.DateTime).ToDataSet().Tables[0];
            DataSet dsTon = objReportServices.Rptware_Nhapxuatton_Giatri_Ton(dtNgay_Batdau.DateTime, dtNgay_Ketthuc.DateTime).ToDataSet();
            txtTon.EditValue = Convert.ToDecimal("0" + dsTon.Tables[0].Compute("sum(Thanhtien)", ""));
            txtXuat.EditValue = Convert.ToDecimal("0" + gvDinhmuc_Chitiet.Columns["Tongxuat"].SummaryItem.SummaryValue);
            txtNhap.EditValue = Convert.ToDecimal("0" + gvDinhmuc_Chitiet.Columns["Tongnhap"].SummaryItem.SummaryValue);
            txtChi.EditValue = Convert.ToDecimal("0" + gvDinhmuc_Chitiet.Columns["Chiphi"].SummaryItem.SummaryValue);
            txtLoinhuan.EditValue =( Convert.ToDecimal(txtXuat.EditValue) - Convert.ToDecimal(txtNhap.EditValue) - Convert.ToDecimal(txtChi.EditValue)) + Convert.ToDecimal(txtTon.EditValue);
        }
    }
}

