using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ecm.Rex.Forms
{
    public partial class FrmRptRex_Nhansu_Thongke_Chitieu : GoobizFrame.Windows.Forms.FormXReport
    {
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        DataSet dsThongke;
        Reports.RptRex_Nhansu_Thongke_Chitieu xreport;
        Reports.rptRex_Nhansu_DSLLTN_4 xreport_chitiet;

        public FrmRptRex_Nhansu_Thongke_Chitieu()
        {
            InitializeComponent();
        }

        public override bool PerformQuery()
        {
            //dsThongke = objRexService.Rex_Nhansu_Thongke_Chitieu(null, dtNgay_Ketthuc.DateTime, chkInclude_Thoiviec.Checked).ToDataSet();
            //dgThongke.DataSource = dsThongke.Tables[0];

            //xreport = new Reports.RptRex_Nhansu_Thongke_Chitieu();
            //this.Report = xreport;
            //ReportHelper.SetCompanyInfoAtHeader(xreport);
            //xreport.FindControl("xrc_NgayBaocao", true).Text = string.Format("{0:dd/MM/yyyy}", dtNgay_Ketthuc.DateTime);               
            //xreport.DataSource = dsThongke;
            //xreport.CreateDocument();
            //printControl1.PrintingSystem = xreport.PrintingSystem;
            return base.PerformQuery();
        }

        private void gvThongke_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvThongke.GetFocusedDataRow() != null)
            {
                var dr = gvThongke.GetFocusedDataRow();
                var dsChitiet = objRexService.Rex_Nhansu_Thongke_Chitieu_Chitiet(dr["Ma_Chitieu"], dtNgay_Ketthuc.DateTime, chkInclude_Thoiviec.Checked,
                    dr["Giatri"]);
                if (xreport_chitiet == null)
                    xreport_chitiet = new Reports.rptRex_Nhansu_DSLLTN_4();
                this.Report = xreport_chitiet;
                //ReportHelper.SetCompanyInfoAtHeader(xreport_chitiet);
                xreport_chitiet.FindControl("xrc_NgayBaocao", true).Text = string.Format("{0:dd/MM/yyyy}", dtNgay_Ketthuc.DateTime);
                xreport_chitiet.FindControl("xrReport_Name", true).Text = "DANH SÁCH CÁN BỘ CÔNG NHÂN VIÊN";

                try 
                {
                    xreport_chitiet.FindControl("xrt_Chitieu_Tke", true).Visible = true;
                    xreport_chitiet.FindControl("xrc_Chitieu", true).Text = ""+dr["Chitieu"];
                    xreport_chitiet.FindControl("xrc_Ten_Chitieu", true).Text = "" + dr["Ten_Chitieu"];
                
                }
                catch { }

                xreport_chitiet.DataSource = dsChitiet;
                xreport_chitiet.CreateDocument();
                printControl1.PrintingSystem = xreport_chitiet.PrintingSystem;
            }
        }
    }
}