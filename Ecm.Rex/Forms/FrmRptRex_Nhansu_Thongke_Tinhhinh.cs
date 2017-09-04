using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ecm.Rex.Forms
{
    public partial class FrmRptRex_Nhansu_Thongke_Tinhhinh : GoobizFrame.Windows.Forms.FormXReport
    {
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        Ecm.WebReferences.Classes.MasterService objMasterTables = new WebReferences.Classes.MasterService();
        DataSet dsThongke;
        DataSet dsLoai_Hopdong;

        Reports.RptRex_Nhansu_Thongke_Tinhhinh xreport;

        public FrmRptRex_Nhansu_Thongke_Tinhhinh()
        {
            InitializeComponent();
            DisplayInfo();
        }

        void DisplayInfo()
        {
            dsLoai_Hopdong = objMasterTables.Get_All_Rex_Dm_Loai_Hopdong_Collection().ToDataSet();
        }


        public override bool PerformQuery()
        {
            try
            {
                dsThongke = objRexService.Rex_Nhansu_Thongke_Tinhhinh(dtNgay_Ketthuc.DateTime, chkInclude_Thoiviec.Checked).ToDataSet();
                dsThongke.Tables[0].TableName = "Rex_Nhansu_Thongke";
                //dsThongke.Tables.Add(dsLoai_Hopdong.Tables[0].Copy());

                xreport = new Reports.RptRex_Nhansu_Thongke_Tinhhinh();
                //xreport.DataSourceSchema = dsThongke.GetXmlSchema();
                this.Report = xreport;
                //ReportHelper.SetCompanyInfoAtHeader(xreport);
                xreport.FindControl("xrc_NgayBaocao", true).Text = string.Format("{0:dd/MM/yyyy}", dtNgay_Ketthuc.DateTime);
                xreport.DataSource = dsThongke;
                xreport.CreateDocument();
                printControl1.PrintingSystem = xreport.PrintingSystem;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
                return false;
            }
            return base.PerformQuery();
        }

    }
}
