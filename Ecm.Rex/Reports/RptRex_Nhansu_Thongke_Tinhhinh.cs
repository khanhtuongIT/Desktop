using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using GoobizFrame.Windows.Forms;

namespace Ecm.Rex.Reports
{
    public partial class RptRex_Nhansu_Thongke_Tinhhinh : DevExpress.XtraReports.UI.XtraReport
    {
        public RptRex_Nhansu_Thongke_Tinhhinh()
        {
            InitializeComponent();
        }

        private void PageHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            Ecm.WebReferences.Classes.MasterService objMasterTables = new WebReferences.Classes.MasterService();
            var dsLoai_Hopdong = objMasterTables.Get_All_Rex_Dm_Loai_Hopdong_Collection().ToDataSet();
            if (dsLoai_Hopdong.Tables[0].Rows.Count > 0)
            {
                while (xrtLoai_Hopdong.Rows[0].Cells.Count < dsLoai_Hopdong.Tables[0].Rows.Count)
                {
                    xrtLoai_Hopdong.Rows[0].Cells.Add(new XRTableCell());
                }

                while (xrTable6.Rows[0].Cells.Count < dsLoai_Hopdong.Tables[0].Rows.Count)
                {
                    xrTable6.Rows[0].Cells.Add(new XRTableCell());
                }

                while (xrTable7.Rows[0].Cells.Count < dsLoai_Hopdong.Tables[0].Rows.Count)
                {
                    xrTable7.Rows[0].Cells.Add(new XRTableCell());
                }
            }

            float w = xrtLoai_Hopdong.SizeF.Width / xrtLoai_Hopdong.Rows[0].Cells.Count;
            for (int i = 0; i < dsLoai_Hopdong.Tables[0].Rows.Count; i++)
            {
                xrtLoai_Hopdong.Rows[0].Cells[i].Text = "" + dsLoai_Hopdong.Tables[0].Rows[i]["Ten_Loai_Hopdong"];
                xrtLoai_Hopdong.Rows[0].Cells[i].WidthF = w;
                
                xrTable6.Rows[0].Cells[i].WidthF = w;
                //xrTable6.Rows[0].Cells[i].DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                //        new DevExpress.XtraReports.UI.XRBinding("Text", null, "Rex_Nhansu_Thongke." + dsLoai_Hopdong.Tables[0].Rows[i]["Ma_Loai_Hopdong"], "{0:#,#}")});

                xrTable7.Rows[0].Cells[i].WidthF = w;
                //xrTable7.Rows[0].Cells[i].DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                //        new DevExpress.XtraReports.UI.XRBinding("Text", null, "Rex_Nhansu_Thongke." + dsLoai_Hopdong.Tables[0].Rows[i]["Ma_Loai_Hopdong"])});
                //var summary = new DevExpress.XtraReports.UI.XRSummary();
                //summary.FormatString = "{0:#,#}";
                //summary.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
                //xrTable7.Rows[0].Cells[i].Summary = summary;
            }
        }

    }
}
