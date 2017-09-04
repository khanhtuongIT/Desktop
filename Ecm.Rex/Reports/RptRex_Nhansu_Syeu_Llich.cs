using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.IO;

namespace Ecm.Rex.Reports
{
    public partial class RptRex_Nhansu_Syeu_Llich : DevExpress.XtraReports.UI.XtraReport
    {
        public RptRex_Nhansu_Syeu_Llich()
        {
            InitializeComponent();
        }

        private void DetailReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                var dsRex_Nhansu = this.DataSource as Datasets.DsRex_Nhansu;

                DevExpress.Data.Browsing.DataBrowser db = this.fDataContext[this.DataSource, "Rex_Nhansu"];
                System.Data.DataRowView dr = db.Current as System.Data.DataRowView;

                try
                {
                    if ("" + dr["Hinh"] != "")
                    {
                        byte[] byte_Picture = (byte[])dr["Hinh"];
                        MemoryStream stream_Picture = new MemoryStream(byte_Picture);
                        Image image = Image.FromStream(stream_Picture, true);
                        var picbox = this.FindControl("xrPicture_Nhansu", false) as DevExpress.XtraReports.UI.XRPictureBox;

                        picbox.Image = image;
                    }
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(System.Windows.Forms.MessageBoxIcon.Asterisk,
                        ex.Message, ex.ToString());
                }

                #region subreport
                if ("" + dr["Id_Nhansu"] != "")
                {
                    //sub report rptRex_Phucap
                    dsRex_Nhansu.Tables["Rex_Phucap"].DefaultView.RowFilter = string.Format("Id_Nhansu={0}", dr["Id_Nhansu"]);
                    Reports.rptRex_Phucap rptPhucap = new Reports.rptRex_Phucap();
                    var xrSub_Phucap = this.FindControl("xrSub_Phucap", true) as DevExpress.XtraReports.UI.XRSubreport;
                    xrSub_Phucap.ReportSource = rptPhucap;
                    rptPhucap.DataSource = dsRex_Nhansu.Tables["Rex_Phucap"].DefaultView;
                    rptPhucap.CreateDocument();

                    //sub report rptRex_Quatrinh_Daotao
                    dsRex_Nhansu.Tables["Rex_Quatrinh_Daotao"].DefaultView.RowFilter = string.Format("Id_Nhansu={0}", dr["Id_Nhansu"]);
                    Reports.rptRex_Quatrinh_Daotao rptDaotao = new rptRex_Quatrinh_Daotao();
                    var xrSub_Daotao = this.FindControl("xrSub_Daotao", true) as DevExpress.XtraReports.UI.XRSubreport;
                    xrSub_Daotao.ReportSource = rptDaotao;
                    rptDaotao.DataSource = dsRex_Nhansu.Tables["Rex_Quatrinh_Daotao"].DefaultView;
                    rptDaotao.CreateDocument();

                    //sub report rptRex_Quatrinh_Congtac
                    dsRex_Nhansu.Tables["Rex_Quatrinh_Congtac"].DefaultView.RowFilter = string.Format("Id_Nhansu={0}", dr["Id_Nhansu"]);
                    var rptcongtac = new rptRex_Quatrinh_Congtac();
                    var xrSub_Congtac = this.FindControl("xrSub_Congtac", true) as DevExpress.XtraReports.UI.XRSubreport;
                    xrSub_Congtac.ReportSource = rptcongtac;
                    rptcongtac.DataSource = dsRex_Nhansu.Tables["Rex_Quatrinh_Congtac"].DefaultView;
                    rptcongtac.CreateDocument();

                    //sub report rptRex_Quanhe_Giadinh
                    dsRex_Nhansu.Tables["Rex_Quanhe_Giadinh"].DefaultView.RowFilter = string.Format("Id_Nhansu={0}", dr["Id_Nhansu"]);
                    var rptRex_Quanhe_Giadinh = new rptRex_Quanhe_Giadinh();
                    var xrSub_Quanhe_Giadinh = this.FindControl("xrSub_Quanhe_Giadinh", true) as DevExpress.XtraReports.UI.XRSubreport;
                    xrSub_Quanhe_Giadinh.ReportSource = rptRex_Quanhe_Giadinh;
                    rptRex_Quanhe_Giadinh.DataSource = dsRex_Nhansu.Tables["Rex_Quanhe_Giadinh"].DefaultView;
                    rptRex_Quanhe_Giadinh.CreateDocument();

                    //sub report rptRex_Quanhe_Giadinh
                    dsRex_Nhansu.Tables["Rex_Dienbien_Luong"].DefaultView.RowFilter = string.Format("Id_Nhansu={0}", dr["Id_Nhansu"]);
                    var rptRex_Dienbien_Luong = new rptRex_Dienbien_Luong();
                    var xrSub_Dienbien_Luong = this.FindControl("xrSub_Dienbien_Luong", true) as DevExpress.XtraReports.UI.XRSubreport;
                    xrSub_Dienbien_Luong.ReportSource = rptRex_Dienbien_Luong;
                    rptRex_Dienbien_Luong.DataSource = dsRex_Nhansu.Tables["Rex_Dienbien_Luong"].DefaultView;
                    rptRex_Dienbien_Luong.CreateDocument();




                }
                #endregion
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status =
                    new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(System.Windows.Forms.MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

    }
}
