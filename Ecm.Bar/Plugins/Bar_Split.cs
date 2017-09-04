using System;
using System.Collections.Generic;
using System.Text;
using  GoobizFrame.Windows.PlugIn;

namespace Ecm.Bar.Plugins
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Bar_Split: IPlugin
    {

        bool DataLoaded = false;
        #region Forms
        //Ecm.Reports.Forms.FrmRptSplit_Sum_Hhban_4Bar FrmRptSplit_Sum_Hhban_4Bar;

         GoobizFrame.Windows.Forms.FormReportWithHeader frmPrintPreview;


        #endregion

        public Bar_Split()
        {
            m_strName = "Đang kiểm tra";
            m_PluginItemConfig = @"";
        }

        public void SetMdiParent(System.Windows.Forms.Form mdiParent)
        {
            this.mdiParent = mdiParent;
        }

        public void BarManager_ItemClick(object sender, EventArgs e)
        {
            DevExpress.Utils.WaitDialogForm WaitDialogForm = new DevExpress.Utils.WaitDialogForm();

            string formName = "";
            string formText = "";

            if (e.GetType() == typeof(DevExpress.XtraNavBar.NavBarLinkEventArgs))
            {
                formName = ((DevExpress.XtraNavBar.NavBarLinkEventArgs)e).Link.ItemName;
                formText = ((DevExpress.XtraNavBar.NavBarLinkEventArgs)e).Link.Caption;
            }
            else if (e.GetType() == typeof(DevExpress.XtraBars.ItemClickEventArgs))
            {
                formName = ((DevExpress.XtraBars.ItemClickEventArgs)e).Item.Name;
                formText = ((DevExpress.XtraBars.ItemClickEventArgs)e).Item.Caption;
            }
            else
            {
                formName = ((System.Windows.Forms.Control)sender).Name;
                formText = ((System.Windows.Forms.Control)sender).Text;
            }

            switch (formName)
            {
                case "FormReportWithHeader":
                    break;

                case "FrmRptSplit_Sum_Hhban_4Bar":
                    GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowExternalForm("Ecm.Reports.dll", "Ecm.Reports.Forms.FrmRptSplit_Sum_Hhban_4Bar", this.MdiParent);
                    //if (FrmRptSplit_Sum_Hhban_4Bar == null || FrmRptSplit_Sum_Hhban_4Bar.IsDisposed)
                    //    FrmRptSplit_Sum_Hhban_4Bar = new Ecm.Reports.Forms.FrmRptSplit_Sum_Hhban_4Bar();
                    //FrmRptSplit_Sum_Hhban_4Bar.Text = formText;
                    //FrmRptSplit_Sum_Hhban_4Bar.MdiParent = this.MdiParent;
                    //FrmRptSplit_Sum_Hhban_4Bar.Show();
                    //FrmRptSplit_Sum_Hhban_4Bar.Activate();

                    break;

                //default:
                //    if (frmPrintPreview == null || frmPrintPreview.IsDisposed)
                //        frmPrintPreview = new  GoobizFrame.Windows.Forms.FormReportWithHeader();
                //    Ecm.Reports.XtraReports.XRpt_Designing objXRpt_Designing = new Ecm.Reports.XtraReports.XRpt_Designing();
                //    objXRpt_Designing.xrLabel1.Text = formText;

                //    frmPrintPreview.printControl1.PrintingSystem = objXRpt_Designing.PrintingSystem;
                //    objXRpt_Designing.CreateDocument();
                //    frmPrintPreview.Report = objXRpt_Designing;

                //    frmPrintPreview.MdiParent = this.MdiParent;
                //    frmPrintPreview.Show();
                //    frmPrintPreview.Activate();
                //    break;
              
            }
            WaitDialogForm.Close();
        }

        #region Implements Interface
        private string m_strName;
        private string m_PluginItemConfig;
        private IPluginHost m_Host;

        private System.Windows.Forms.Form mdiParent;
        public System.Windows.Forms.Form MdiParent
        {
            get { return mdiParent; }
            set { mdiParent = value; }
        }
        public string Name
        { get { return m_strName; } set { m_strName = value; } }

        public string PluginItemConfig
        { get { return m_PluginItemConfig; } set { m_PluginItemConfig = value; } }

        //public void Show(System.Windows.Forms.Form mdiParent)
        //{ 
        //    Main1 mn = new Main1();
        //    mn.ShowDialog();
        //}

        public IPluginHost Host
        {
            get { return m_Host; }
            set
            {
                m_Host = value;
                m_Host.Register(this);
            }
        }

        public void PreLoadData()
        {
            new System.Threading.Thread(new System.Threading.ThreadStart(this.PreLoadThread)).Start();
        }

        void PreLoadThread()
        {
            lock (this)
            {
               

                

                DataLoaded = true;
            }
        }
        #endregion
    }
}
