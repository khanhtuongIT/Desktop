using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraNavBar;
using DevExpress.Utils;
using Ecm.Rex.Reports;

namespace Ecm.Rex.Forms
{
    public partial class FrmRptRex_Thamgia_Tochuc : GoobizFrame.Windows.Forms.FormXReport
    {
        // Methods
        public FrmRptRex_Thamgia_Tochuc()
        {
            this.InitializeComponent();
            this.DisplayInfo();
        }

        private void DisplayInfo()
        {
            this.lookUpEdit_Bophan.Properties.DataSource = this.objMasterTables.Get_All_Rex_Dm_Bophan_Collection().ToDataSet().Tables[0];
            this.lookUpEditDm_Tochuc.Properties.DataSource = this.objMasterTables.Get_All_Rex_Dm_Tochuc_Collection().ToDataSet().Tables[0];
            this.lookUpEdit_Bophan.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            this.lookUpEditDm_Tochuc.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
        }

        private void lookUpEditDm_Tochuc_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                this.lookUpEditDm_Tochuc.EditValue = null;
            }
        }

        public override bool PerformQuery()
        {
            this.dsThongke = this.objRex.Rex_Thamgia_Tochuc_Thongke(this.lookUpEdit_Bophan.EditValue, this.dtNgay_Ketthuc.DateTime, this.lookUpEditDm_Tochuc.EditValue, this.chkInc_Nhanvien_Thoiviec.Checked).ToDataSet();
            try
            {
                if (!Directory.Exists(@"Resources\Schema"))
                {
                    Directory.CreateDirectory(@"Resources\Schema");
                }
                this.dsThongke.WriteXmlSchema(@"Resources\Schema\RptRex_Thamgia_Tochuc_Thongke.xml");
            }
            catch
            {
            }
            if ((this.xreport == null) || this.xreport.IsDisposed)
            {
                this.xreport = new RptRex_Thamgia_Tochuc_Thongke();
            }
            base.Report = this.xreport;
            //ReportHelper.SetCompanyInfoAtHeader(this.xreport);
            this.xreport.FindControl("xrc_Ngay_Ketthuc", true).Text = string.Format("{0:dd/MM/yyyy}", this.dtNgay_Ketthuc.DateTime);
            this.xreport.DataSource = this.dsThongke;
            this.xreport.CreateDocument();
            base.printControl1.PrintingSystem = this.xreport.PrintingSystem;
            return base.PerformQuery();
        }

    }
}